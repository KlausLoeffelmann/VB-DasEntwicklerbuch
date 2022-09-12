Imports System.Text.RegularExpressions

Public Class ADFormularParser

    Protected myFormular As String
    Protected myFunctions As List(Of ADFunction)
    Protected myPriorizedOperators As ADPrioritizedOperators
    Protected Shared myPredefinedFunctions As List(Of ADFunction)
    Protected myResult As Double
    Protected myIsCalculated As Boolean
    Protected myConsts As ArrayList
    Private myConstEnumCounter As Integer

    Protected Shared myXVariable As Double
    Protected Shared myYVariable As Double
    Protected Shared myZVariable As Double

    'Definiert die Standardfunktionen statisch bei der ersten Verwendung dieser Klasse.
    Shared Sub New()

        myPredefinedFunctions = New List(Of ADFunction)

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

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <param name="Formular">Die auszuwertende Formel, die als Zeichenkette vorliegen muss.</param>
    ''' <remarks></remarks>
    Sub New(ByVal Formular As String)

        'Vordefinierte Funktionen �bertragen
        myFunctions = myPredefinedFunctions
        myFormular = Formular
        OnAddFunctions()

    End Sub

    'Mit dem �berschreiben dieser Funktion kann der Entwickler eigene Funktionen hinzuf�gen
    Public Overridable Sub OnAddFunctions()
        'Nichts zu tun in der Basisversion
        Return
    End Sub

    'Interne Funktion, die das Berechnen startet.
    Private Sub Calculate()

        Dim locFormular As String = myFormular
        Dim locOpStr As String = ""

        'Operatorenliste anlegen
        myPriorizedOperators = New ADPrioritizedOperators
        For Each adf As ADFunction In myFunctions
            If adf.IsOperator Then
                myPriorizedOperators.AddFunction(adf)
            End If
        Next

        'Operatoren Zeichenkette zusammenbauen

        For Each ops As ADFunction In myFunctions
            If ops.IsOperator Then
                locOpStr += "\" + ops.FunctionName
            End If
        Next

        'White-Spaces entfernen
        'Syntax-Check f�r Klammern
        'Negativ-Vorzeichen verarbeiten
        locFormular = PrepareFormular(locFormular, locOpStr)

        'Konstanten 'rausparsen
        locFormular = GetConsts(locFormular)

        myResult = ParseSimpleTerm(Parse(locFormular, locOpStr))
        IsCalculated = True

    End Sub

    '�berschreibbare Funktion, die die Formelauswertung steuert.
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

            'Jeden Parameterterm auswerten und zum Parameter-Array hinzuf�gen
            For Each locMatch As Match In locMoreInnerTerms
                locTemp = locMatch.Value
                locTemp = locTemp.Replace(";", "").Replace(")", "")
                locPreliminaryResult.Add(ParseSimpleTerm(locTemp))
            Next

            'M�glicher Syntaxfehler: Mehrere Parameter, aber keine Funktion
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
                    'Diese Warnung bezieht sich auf einen hypothetischen Fall,
                    'der aber nie eintreten kann!
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

    '�berschreibbare Funktion, die einen einfachen Term 
    '(ohne Funktionen, nur Operatoren) auswertet.
    Protected Overridable Function ParseSimpleTerm(ByVal Formular As String) As Double

        Dim locPos As Integer
        Dim locResult As Double

        'Klammern entfernen
        If Formular.IndexOfAny(New Char() {"("c, ")"c}) > -1 Then
            Formular = Formular.Remove(0, 1)
            Formular = Formular.Remove(Formular.Length - 1, 1)
        End If

        'Die Priorit�ten der verschiedenen Operatoren von oben nach unten durchlaufen
        For locPrioCount As Integer = myPriorizedOperators.HighestPriority To _
                    myPriorizedOperators.LowestPriority Step -1
            Do
                'Schauen, ob *nur* ein Wert
                If Formular.Length = 3 Then
                    Return CDbl(myConsts(Integer.Parse(Formular)))
                End If

                'Die Operatorenzeichen einer Ebene ermitteln
                Dim locCharArray As Char() = myPriorizedOperators.OperatorChars(CByte(locPrioCount))
                If locCharArray Is Nothing Then
                    'Gibt keinen Operator dieser Ebene, dann n�chste Hierarchie.
                    Exit Do
                End If

                'Nach einem der Operatoren dieser Hierarchieebene suchen
                locPos = Formular.IndexOfAny(locCharArray)
                If locPos = -1 Then
                    'Kein Operator dieser Ebene mehr in der Formel vorhanden - n�chste Hierarchie.
                    Exit Do
                Else
                    Dim locDblArr(1) As Double
                    'Operator gefunden - Teilterm ausrechnen
                    locDblArr(0) = CDbl(myConsts(Integer.Parse(Formular.Substring(locPos - 3, 3))))
                    locDblArr(1) = CDbl(myConsts(Integer.Parse(Formular.Substring(locPos + 1, 3))))

                    'Die entsprechende Funktion aufrufen, die durch die Hilfsklassen
                    'anhand Priorit�t und Operatorzeichen ermittelt werden kann.
                    Dim locOpChar As Char = Convert.ToChar(Formular.Substring(locPos, 1))
                    locResult = myPriorizedOperators.OperatorByChar( _
                                CByte(locPrioCount), locOpChar).Operate(locDblArr)

                    'Und den kompletten Ausdruck durch eine neue Konstante ersetzen
                    myConsts.Add(locResult)
                    Formular = Formular.Remove(locPos - 3, 7)
                    Formular = Formular.Insert(locPos - 3, myConstEnumCounter.ToString("000"))
                    myConstEnumCounter += 1
                End If
            Loop
        Next
    End Function

    '�berschreibbare Funktion, die die konstanten Zahlenwerte in der Formel ermittelt.
    Protected Overridable Function GetConsts(ByVal Formular As String) As String

        Dim locRegEx As New Regex("[\d,.]+[S]*")
        'Alle Ziffern mit Komma oder Punkt aber keine Whitespaces
        myConstEnumCounter = 0
        myConsts = New ArrayList
        Return locRegEx.Replace(Formular, AddressOf EnumConstsProc)

    End Function

    'R�ckruffunktion f�r das Auswerten der einzelnen Konstanten (siehe vorherige Zeile).
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

    'Hier werden vorbereitende Arbeiten durchgef�hrt.
    Protected Overridable Function PrepareFormular(ByVal Formular As String, ByVal OperatorRegEx As String) As String

        Dim locBracketCounter As Integer

        'Klammern �berpr�fen
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
                   ("Eine offene Klammer wurde nicht ordnungsgem�� geschlossen.")
            Throw up
        End If

        'White-Spaces entfernen
        Formular = Regex.Replace(Formular, "\s", "")

        'Vorzeichen verarbeiten
        If Formular.StartsWith("-") Or Formular.StartsWith("+") Then
            Formular = Formular.Insert(0, "0")
        End If

        'Sonderfall negative Klammer
        Formular = Regex.Replace(Formular, "\(-\(", "(0-(")

        Return Regex.Replace(Formular, _
                    "(?<operator>[" + OperatorRegEx + "\(])-(?<zahl>[\d\.\,]*)", _
                    "${operator}((0-1)*${zahl})")

    End Function

    ''' <summary>
    ''' Bestimmt oder ermittelt die zu berechnende Formel.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Formular() As String
        Get
            Return myFormular
        End Get
        Set(ByVal Value As String)
            IsCalculated = False
            myFormular = Value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt die Berechnung der Formel beim ersten Aufruf; 
    ''' speichert den berechneten Wert und ruft ihn bei allen folgenden Aufrufen 
    ''' nur ab, sofern sich der Formeltext zwischenzeitlich nicht ge�ndert hat.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Result() As Double
        Get
            If Not IsCalculated Then
                Calculate()
            End If
            Return myResult
        End Get
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, ob die Formel bereits berechnet wurde. Setzen Sie diese 
    ''' Eigenschaft vor der Verwendung von Result auf False, wenn Sie mit sich ver�ndernden 
    ''' Funktionen wie beispielsweise XVar arbeiten.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsCalculated() As Boolean
        Get
            Return myIsCalculated
        End Get
        Set(ByVal Value As Boolean)
            myIsCalculated = Value
        End Set
    End Property

    ''' <summary>
    ''' Ermittelt oder bestimmt die Funktionen, mit denen die Berechnungen 
    ''' einer Formel durchgef�hrt wird.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Functions() As List(Of ADFunction)
        Get
            Return myFunctions
        End Get
        Set(ByVal Value As List(Of ADFunction))
            IsCalculated = False
            myFunctions = Value
        End Set
    End Property
End Class
