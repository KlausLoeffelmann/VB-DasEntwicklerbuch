Imports System.Text.RegularExpressions

Public Class ADFunction
    Implements IComparable

    Public Delegate Function ADFunctionDelegate(ByVal parArray As Double()) As Double
    Protected myFunctionname As String  ' Name
    Protected myParameters As Integer   ' Anzahl Parameter
    Protected myFunctionProc As ADFunctionDelegate
    Protected myConsts As ArrayList
    Protected myIsOperator As Boolean
    Protected myPriority As Byte

    Sub New(ByVal Functionname As Char, ByVal FunctionProc As ADFunctionDelegate, ByVal Priority As Byte)

        If Priority < 1 Then
            Dim Up As New ArgumentException("Priority kann für Operatoren nicht kleiner 1 sein.")
            Throw Up
        End If

        myFunctionname = Functionname.ToString
        myParameters = 2
        myFunctionProc = FunctionProc
        myIsOperator = True
        myPriority = Priority
    End Sub

    Sub New(ByVal FunctionName As String, ByVal FunctionProc As ADFunctionDelegate, ByVal Parameters As Integer)
        myFunctionname = FunctionName
        myFunctionProc = FunctionProc
        myParameters = Parameters
        myIsOperator = False
        myPriority = 0
    End Sub

    Public ReadOnly Property FunctionName() As String
        Get
            Return myFunctionname
        End Get
    End Property

    Public ReadOnly Property Parameters() As Integer
        Get
            Return myParameters
        End Get
    End Property

    Public ReadOnly Property IsOperator() As Boolean
        Get
            Return myIsOperator
        End Get
    End Property

    Public ReadOnly Property Priority() As Byte
        Get
            Return myPriority
        End Get
    End Property

    Public ReadOnly Property FunctionProc() As ADFunctionDelegate
        Get
            Return myFunctionProc
        End Get
    End Property

    Public Function Operate(ByVal parArray As Double()) As Double
        If Parameters > -1 Then
            If parArray.Length <> Parameters Then
                Dim Up As New ArgumentException _
                    ("Anzahl Parameter entspricht nicht der Vorschrift der Funktion " & FunctionName)
                Throw Up
            End If
        End If
        Return myFunctionProc(parArray)
    End Function

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If obj.GetType.FullName = "ActiveDev.ADFunction" Then
            Return myPriority.CompareTo(DirectCast(obj, ActiveDev.ADFunction).Priority) * -1
        Else
            Dim up As New ArgumentException("Nur ActiveDev.Function-Objekte können verglichen/sortiert werden")
            Throw up
        End If
    End Function

End Class

Public Class ADFormularParser

    Protected myFormular As String
    Protected myFunctions As ArrayList
    Protected myOperators As ArrayList
    Protected Shared myPredefinedFunctions As ArrayList
    Protected myResult As Double
    Protected myIsCalculated As Boolean
    Protected myConsts As ArrayList
    Private myConstEnumCounter As Integer

    Protected Shared myXVariable As Double
    Protected Shared myYVariable As Double
    Protected Shared myZVariable As Double

    Shared Sub New()

        myPredefinedFunctions = New ArrayList

        With myPredefinedFunctions
            .Add(New ADFunction("+"c, AddressOf Addition, CByte(1)))
            .Add(New ADFunction("-"c, AddressOf Substraction, CByte(1)))
            .Add(New ADFunction("*"c, AddressOf Multiplication, CByte(2)))
            .Add(New ADFunction("/"c, AddressOf Division, CByte(2)))
            .Add(New ADFunction("\"c, AddressOf Remainder, CByte(2)))
            .Add(New ADFunction("^"c, AddressOf Power, CByte(3)))
            .Add(New ADFunction("PI", AddressOf PI, 1))
            .Add(New ADFunction("Sin", AddressOf Sin, 1))
            .Add(New ADFunction("Cos", AddressOf Cos, 1))
            .Add(New ADFunction("Tan", AddressOf Tan, 1))
            .Add(New ADFunction("Max", AddressOf Max, -1))
            .Add(New ADFunction("Min", AddressOf Min, -1))
            .Add(New ADFunction("Sqrt", AddressOf Sqrt, 1))
            .Add(New ADFunction("Tanh", AddressOf Tanh, 1))
            .Add(New ADFunction("LogDec", AddressOf LogDec, 1))
            .Add(New ADFunction("XVar", AddressOf XVar, 1))
            .Add(New ADFunction("YVar", AddressOf YVar, 1))
            .Add(New ADFunction("ZVar", AddressOf ZVar, 1))
        End With
    End Sub

    Sub New(ByVal Formular As String)

        'Vordefinierte Funktionen übertragen
        myFunctions = DirectCast(myPredefinedFunctions.Clone, ArrayList)
        myFormular = Formular
        OnAddFunctions()

    End Sub

    'Mit dem Überschreiben dieser Funktion kann der Entwickler eigene Funktionen hinzufügen
    Public Overridable Sub OnAddFunctions()
        'Nichts zu tun in der Basisfunktion
        Return
    End Sub

    Private Sub Calculate()

        Dim locFormular As String = myFormular
        Dim locOpStr As String

        'Operatorenliste sortieren
        myOperators = New ArrayList
        For Each adf As ADFunction In myFunctions
            If adf.IsOperator Then
                myOperators.Add(adf)
            End If
        Next
        myOperators.Sort()

        'Operatoren Zeichenkette zusammenbauen
        For Each ops As ADFunction In myFunctions
            If ops.IsOperator Then
                locOpStr += "\" + ops.FunctionName
            End If
        Next

        'White-Spaces entfernen
        'Syntax-Check für Klammern
        'Negativ-Vorzeichen verarbeiten
        locFormular = PrepareFormular(locFormular, locOpStr)

        'Konstanten 'rausparsen
        locFormular = GetConsts(locFormular)

        myResult = ParseSimpleTerm(Parse(locFormular, locOpStr))
        IsCalculated = True

    End Sub

    Protected Overridable Function Parse(ByVal Formular As String, ByVal OperatorRegEx As String) As String

        Dim locTemp As String
        Dim locTerm As Match
        Dim locFuncName As Match
        Dim locMoreInnerTerms As MatchCollection
        Dim locPreliminaryResult As New ArrayList
        Dim locFuncFound As Boolean
        Dim locOperatorRegEx As String = "\([\d\;" + OperatorRegEx + "]*\)"

        Dim adf As ADFunction

        locTerm = Regex.Match(Formular, locOperatorRegEx)
        If locTerm.Value <> "" Then
            locTemp = Formular.Substring(0, locTerm.Index)

            'Befindet sich ein Funktionsname davor?
            locFuncName = Regex.Match(locTemp, "[a-zA-Z]*", RegexOptions.RightToLeft)

            'Gibt es mehrere, durch ; getrennte Parameter?
            locMoreInnerTerms = Regex.Matches(locTerm.Value, "[\d" + OperatorRegEx + "]*[;|\)]")

            'Jeden Parameterterm auswerten und zum Parameter-Array hinzufügen
            For Each locMatch As Match In locMoreInnerTerms
                locTemp = locMatch.Value
                locTemp = locTemp.Replace(";", "").Replace(")", "")
                locPreliminaryResult.Add(ParseSimpleTerm(locTemp))
            Next

            'Möglicher Syntaxfehler: Mehrere Parameter, aber keine Funktion
            If locFuncName.Value = "" And locMoreInnerTerms.Count > 1 Then
                Dim up As New SyntaxErrorException _
                    ("Mehrere Klammerparameter aber kein Funktionsname angegeben!")
                Throw up
            End If

            If locFuncName.Value <> "" Then
                'Funktionsnamen suchen
                locFuncFound = False
                For Each adf In myFunctions
                    If adf.FunctionName.ToUpper = locFuncName.Value.ToUpper Then
                        locFuncFound = True
                        Exit For
                    End If
                Next

                If locFuncFound = False Then
                    Dim up As New SyntaxErrorException("Der Funktionsname wurde nicht gefunden")
                    Throw up
                Else
                    Formular = Formular.Replace(locFuncName.Value + locTerm.Value, myConstEnumCounter.ToString("000"))
                    Dim locArgs(locPreliminaryResult.Count - 1) As Double
                    locPreliminaryResult.CopyTo(locArgs)
                    myConsts.Add(adf.Operate(locArgs))
                    myConstEnumCounter += 1
                End If
            Else
                Formular = Formular.Replace(locTerm.Value, myConstEnumCounter.ToString("000"))
                myConsts.Add(CDbl(locPreliminaryResult(0)))
                myConstEnumCounter += 1
            End If
        Else
            Return Formular
        End If
        Formular = Parse(Formular, OperatorRegEx)
        Return Formular

    End Function

    Protected Overridable Function ParseSimpleTerm(ByVal Formular As String) As Double

        Dim locPos As Integer
        Dim locResult As Double

        'Klammern entfernen
        If Formular.IndexOfAny(New Char() {"("c, ")"c}) > -1 Then
            Formular = Formular.Remove(0, 1)
            Formular = Formular.Remove(Formular.Length - 1, 1)
        End If

        For Each adf As ADFunction In myOperators
            Do
                'Schauen, ob "nur" ein Wert
                If Formular.Length = 3 Then
                    Return CDbl(myConsts(Integer.Parse(Formular)))
                End If

                locPos = Formular.IndexOf(adf.FunctionName.ToCharArray()(0))
                If locPos = -1 Then
                    Exit Do
                Else
                    Dim locDblArr(1) As Double
                    'Operator gefunden - Teilterm ausrechnen
                    locDblArr(0) = CDbl(myConsts(Integer.Parse(Formular.Substring(locPos - 3, 3))))
                    locDblArr(1) = CDbl(myConsts(Integer.Parse(Formular.Substring(locPos + 1, 3))))

                    'Die entsprechende Funktion aufrufen
                    locResult = adf.Operate(locDblArr)

                    'Und den kompletten Ausdruck durch eine neue Konstante ersetzen
                    myConsts.Add(locResult)
                    Formular = Formular.Remove(locPos - 3, 7)
                    Formular = Formular.Insert(locPos - 3, myConstEnumCounter.ToString("000"))
                    myConstEnumCounter += 1
                End If
            Loop
        Next
    End Function

    Protected Overridable Function GetConsts(ByVal Formular As String) As String

        Dim locRegEx As New Regex("[\d,.]+[S]*")
        'Alle Ziffern mit Komma oder Punkt aber keine Whitespaces
        myConstEnumCounter = 0
        myConsts = New ArrayList
        Return locRegEx.Replace(Formular, AddressOf EnumConstsProc)

    End Function

    Protected Overridable Function EnumConstsProc(ByVal m As Match) As String

        Try
            myConsts.Add(Double.Parse(m.Value))
            Dim locString As String = myConstEnumCounter.ToString("000")
            myConstEnumCounter += 1
            Return locString
        Catch ex As Exception
            myConsts.Add(Double.NaN)
            Return "ERR"
        End Try
    End Function

    Protected Overridable Function PrepareFormular(ByVal Formular As String, ByVal OperatorRegEx As String) As String

        Dim locBracketCounter As Integer

        'Klammern überprüfen
        For Each locChar As Char In Formular.ToCharArray
            If locChar = "("c Then
                locBracketCounter += 1
            End If

            If locChar = ")"c Then
                locBracketCounter -= 1
                If locBracketCounter < 0 Then
                    Dim up As New SyntaxErrorException _
                           ("Zu viele Klammer-Zu-Zeichen.")
                    Throw up
                End If
            End If
        Next
        If locBracketCounter > 0 Then
            Dim up As New SyntaxErrorException _
                   ("Eine offene Klammer wurde nicht ordnungsgemäß geschlossen.")
            Throw up
        End If

        'White-Spaces entfernen
        Formular = Regex.Replace(Formular, "\s", "")

        'Vorzeichen verarbeiten
        If Formular.StartsWith("-") Or Formular.StartsWith("+") Then
            Formular = Formular.Insert(0, "0")
        End If

        Return Regex.Replace(Formular, _
                    "(?<operator>[" + OperatorRegEx + "])-(?<zahl>[\d\.\,]*)", _
                    "${operator}((0-1)*${zahl})")

    End Function

    Public Property Formular() As String
        Get
            Return myFormular
        End Get
        Set(ByVal Value As String)
            IsCalculated = False
            myFormular = Value
        End Set
    End Property

    Public ReadOnly Property Result() As Double
        Get
            If Not IsCalculated Then
                Calculate()
            End If
            Return myResult
        End Get
    End Property

    Public Property IsCalculated() As Boolean
        Get
            Return myIsCalculated
        End Get
        Set(ByVal Value As Boolean)
            myIsCalculated = Value
        End Set
    End Property

    Public Property Functions() As ArrayList
        Get
            Return myFunctions
        End Get
        Set(ByVal Value As ArrayList)
            myFunctions = Value
        End Set
    End Property

#Region "Mathematische Funktionen"
    Public Shared Function Addition(ByVal Args() As Double) As Double
        Return Args(0) + Args(1)
    End Function

    Public Shared Function Substraction(ByVal Args() As Double) As Double
        Return Args(0) - Args(1)
    End Function

    Public Shared Function Multiplication(ByVal Args() As Double) As Double
        Return Args(0) * Args(1)
    End Function

    Public Shared Function Division(ByVal Args() As Double) As Double
        Return Args(0) / Args(1)
    End Function

    Public Shared Function Remainder(ByVal Args() As Double) As Double
        Return Decimal.Remainder(New Decimal(Args(0)), New Decimal(Args(1)))
    End Function

    Public Shared Function Power(ByVal Args() As Double) As Double
        Return Args(0) ^ Args(1)
    End Function

    Public Shared Function Sin(ByVal Args() As Double) As Double
        Return Math.Sin(Args(0))
    End Function

    Public Shared Function Cos(ByVal Args() As Double) As Double
        Return Math.Cos(Args(0))
    End Function

    Public Shared Function Tan(ByVal Args() As Double) As Double
        Return Math.Tan(Args(0))
    End Function

    Public Shared Function Sqrt(ByVal Args() As Double) As Double
        Return Math.Sqrt(Args(0))
    End Function

    Public Shared Function PI(ByVal Args() As Double) As Double
        Return Math.PI
    End Function

    Public Shared Function Tanh(ByVal Args() As Double) As Double
        Return Math.Tanh(Args(0))
    End Function

    Public Shared Function LogDec(ByVal Args() As Double) As Double
        Return Math.Log10(Args(0))
    End Function

    Public Shared Function XVar(ByVal Args() As Double) As Double
        Return XVariable
    End Function

    Public Shared Function YVar(ByVal Args() As Double) As Double
        Return YVariable
    End Function

    Public Shared Function ZVar(ByVal Args() As Double) As Double
        Return ZVariable
    End Function

    Public Shared Function Max(ByVal Args() As Double) As Double

        Dim retDouble As Double

        If Args.Length = 0 Then
            Return 0
        Else
            retDouble = Args(0)
            For Each locDouble As Double In Args
                If retDouble < locDouble Then
                    retDouble = locDouble
                End If
            Next
        End If
        Return retDouble

    End Function

    Public Shared Function Min(ByVal Args() As Double) As Double

        Dim retDouble As Double

        If Args.Length = 0 Then
            Return 0
        Else
            retDouble = Args(0)
            For Each locDouble As Double In Args
                If retDouble > locDouble Then
                    retDouble = locDouble
                End If
            Next
        End If
        Return retDouble

    End Function

    Public Shared Property XVariable() As Double
        Get
            Return myXVariable
        End Get
        Set(ByVal Value As Double)
            myXVariable = Value
        End Set
    End Property

    Public Shared Property YVariable() As Double
        Get
            Return myYVariable
        End Get
        Set(ByVal Value As Double)
            myYVariable = Value
        End Set
    End Property

    Public Shared Property ZVariable() As Double
        Get
            Return myZVariable
        End Get
        Set(ByVal Value As Double)
            myZVariable = Value
        End Set
    End Property
#End Region

End Class
