Imports System.Text
Imports System.Runtime.InteropServices

#Region "LongEx-Struktur: Bietet Funktionalit�t zur Bin�rwertzerlegung"
<StructLayout(LayoutKind.Explicit)> _
Public Structure LongEx

    <FieldOffset(0)> Private myLong As Long
    <FieldOffset(0)> Private myLowDWord As Integer
    <FieldOffset(4)> Private myHighDWord As Integer
    <FieldOffset(0)> Private myLowWord As Short
    <FieldOffset(2)> Private myHighWord As Short
    <FieldOffset(4)> Private myHighDWordLowWord As Short
    <FieldOffset(6)> Private myHighDWordHighWord As Short
    <FieldOffset(0)> Private myLowByte As Byte
    <FieldOffset(1)> Private myHighByte As Byte
    <FieldOffset(0)> Private myWord As Short
    <FieldOffset(0)> Private myDWord As Integer

    Sub New(ByVal a_Byte As Byte)
        myLong = a_Byte
    End Sub

    Sub New(ByVal a_Word As Short)
        myLong = a_Word
    End Sub

    Sub New(ByVal a_DWord As Integer)
        myLong = a_DWord
    End Sub

    Sub New(ByVal a_Long As Long)
        myLong = a_Long
    End Sub

    Property [Long]() As Long
        Get
            Return myLong
        End Get

        Set(ByVal Value As Long)
            myLong = Value
        End Set
    End Property

    Property DWord() As Integer
        Get
            Return myDWord
        End Get

        Set(ByVal Value As Integer)
            Value = DWord
        End Set
    End Property

    Property Word() As Short
        Get
            Return myWord
        End Get

        Set(ByVal Value As Short)
            Value = Value
        End Set
    End Property

    'Ist redundant, da das gleiche wie DWord, 
    'aber die Konsistenz...!
    Property LowDWord() As Integer
        Get
            Return myLowDWord
        End Get

        Set(ByVal Value As Integer)
            myLowDWord = Value
        End Set
    End Property

    Property HighDWord() As Integer
        Get
            Return myHighDWord
        End Get

        Set(ByVal Value As Integer)
            myHighDWord = Value
        End Set
    End Property

    Property LowWord() As Short
        Get
            Return myLowWord
        End Get

        Set(ByVal Value As Short)
            myLowWord = Value
        End Set
    End Property

    Property HighWord() As Short
        Get
            Return myHighWord
        End Get

        Set(ByVal Value As Short)
            myHighWord = Value
        End Set
    End Property

    Property HighDWordLowWord() As Short
        Get
            Return myHighDWordLowWord
        End Get

        Set(ByVal Value As Short)
            myHighDWordLowWord = Value
        End Set
    End Property

    Property HighDWordHighWord() As Short
        Get
            Return myHighDWordHighWord
        End Get

        Set(ByVal Value As Short)
            myHighDWordHighWord = Value
        End Set
    End Property

    Property LowByte() As Byte
        Get
            Return myLowByte
        End Get

        Set(ByVal Value As Byte)
            myLowByte = Value
        End Set
    End Property

    Property HighByte() As Byte
        Get
            Return myHighByte
        End Get

        Set(ByVal Value As Byte)
            Value = myHighByte
        End Set
    End Property

End Structure
#End Region

#Region "OpValue-Structure: Stellt Funktionalit�t zur Integerberechnung mit �berl�ufen bereit"
Friend Structure OpValue

    Private myValue As LongEx        ' eigentlicher Wert
    Private myBackLog As Integer    ' �berhang, beispielsweise nach einer Multiplikation
    Private myCarry As Boolean      ' �berlaufanzeige

    Public Sub New(ByVal Value As Integer, ByVal Carry As Boolean)
        myValue = New LongEx(Value)
        myCarry = Carry
    End Sub

    'Liefert den Wert zur�ck oder setzt ihn
    Public Property Value() As Integer
        Get
            Return myValue.DWord
        End Get

        Set(ByVal Value As Integer)
            myValue.DWord = Value
        End Set

    End Property

    'Pr�ft, ob das Carry-(�berlauf-) Flag gesetzt ist oder setzt es
    Public Property Carry() As Boolean

        Get
            Return myCarry
        End Get

        Set(ByVal Value As Boolean)
            myCarry = Value
        End Set

    End Property

    Public Property BackLog() As Integer

        Get
            Return myBackLog
        End Get

        Set(ByVal Value As Integer)
            myBackLog = BackLog
        End Set

    End Property

    'Setzt das Carryflag
    Public Sub SetCarry()
        myCarry = True
    End Sub

    'L�scht das Carryflag
    Public Sub ClrCarry()
        myCarry = False
    End Sub

    'int addieren und Carry mit zur�ckliefern
    Friend Shared Function Add(ByVal Value1 As Integer, ByVal Value2 As Integer) As OpValue

        Dim locResult As Long
        Dim locBack As OpValue  'Muss nicht initialisiert werden, ist Struktur

        locResult = Value1 + Value2
        If (locResult And CLng(2 ^ 16)) = CLng(2 ^ 16) Then
            locBack.SetCarry()
        End If

        locBack.Value = CInt(locResult)

        Return locBack

    End Function

    'Int Subtrahieren und Carry zur�ckliefern
    '(Carry ist true, wenn es einen Unterlauf gab)
    Friend Shared Function [Sub](ByVal Value1 As Integer, ByVal Value2 As Integer) As OpValue

        Dim locResult As Long
        Dim locBack As OpValue 'Muss nicht initialisiert werden, ist Struktur

        locResult = Value1 - Value2
        If (locResult And CLng(2 ^ 16)) = CLng(2 ^ 16) Then
            locBack.SetCarry()
        End If

        locBack.Value = CInt(locResult)

    End Function

End Structure
#End Region

Public Class BitArrayEx

    'Sollte sp�ter durch Attribute gehandelt werden
    Const AttribExtendToFit As Boolean = True

    'Wird als erstes "ausgef�hrt", aber nur einmal "pro Programm"
    Private Shared stBitTable() As Integer = {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80, &H100, &H200, &H400, &H800, &H1000, &H2000, &H4000, _
                            &H8000, &H10000, &H20000, &H40000, &H80000, &H100000, &H200000, &H400000, &H800000, &H1000000, _
                            &H2000000, &H4000000, &H8000000, &H10000000, &H20000000, &H40000000, &H80000000}
    'wird als zweites "ausgef�hrt", auch nur einmal "pro Programm"
    Private Shared stBitTableXOr(32) As Integer


    Private myLength As Integer
    Private myBitStorage As Integer()

    'Wird als drittes ausgef�hrt
    Shared Sub New()

        For count As Integer = 0 To 31
            stBitTableXOr(count) = stBitTable(count) Xor &HFFFFFFFF
        Next

    End Sub

    'Wird als viertes ausgef�hrt, beim Instanzieren der Klasse
    Public Sub New(ByVal Bits As Integer)

        myLength = Bits
        ReDim myBitStorage((myLength - 1) >> 5)

    End Sub

    Default Public Property Item(ByVal BitNumber As Integer) As Boolean

        Get
            If BitNumber < 1 Or BitNumber > myLength Then
                Throw New ArgumentOutOfRangeException("Index au�erhalb des g�ltigen Bereichs")
            End If

            Dim locBitTableIndex As Integer
            locBitTableIndex = BitNumber And 31
            BitNumber -= 1
            Dim arrayIndex As Integer = BitNumber >> 5
            Dim bitVal As Long = stBitTable(BitNumber And 31)
            Return (myBitStorage(arrayIndex) And stBitTable(BitNumber And 31)) = stBitTable(BitNumber And 31)
        End Get

        Set(ByVal Value As Boolean)
            BitNumber -= 1
            Dim locBitTableIndex As Integer = BitNumber >> 5
            If Value Then
                myBitStorage(locBitTableIndex) = myBitStorage(locBitTableIndex) Or stBitTable(BitNumber And 31)
            Else
                myBitStorage(locBitTableIndex) = myBitStorage(locBitTableIndex) And stBitTableXOr(BitNumber And 31)
            End If
        End Set

    End Property

    Public Function IsMoreExtensive(ByVal fba As BitArrayEx) As Boolean

        Return Me.myBitStorage.Length > fba.myBitStorage.Length

    End Function

    Public Sub ExtendToFit(ByVal NewLength As Integer)

        If NewLength < myLength Then
            Throw New ArgumentOutOfRangeException("Die neue Bitl�nge des Objektes muss l�nger sein als zuvor.")
        End If

        Dim locStorageTemp((NewLength - 1) >> 5) As Integer

        For c As Integer = 0 To myBitStorage.GetUpperBound(0)
            locStorageTemp(c) = myBitStorage(c)
        Next







    End Sub

    Public Function [And](ByVal fba As BitArrayEx) As BitArrayEx

        Dim locUBoundsMe As Integer
        Dim locUBoundsArg As Integer

        'Ung�ltiges Nullargument, Ausnahme schmei�en...
        If fba Is Nothing Then
            'Todo: Fehlertext �berarbeiten
            Throw New NullReferenceException("�bergebenes BitArrayEx-Objekt ist nicht initialisiert!")
        End If

        'Obergrenzen der Bitspeicher ermitteln
        locUBoundsMe = Me.myBitStorage.GetUpperBound(0)
        locUBoundsArg = fba.myBitStorage.GetUpperBound(0)

        'Falls das Argument gr��er ist als diese Klasse:
        If locUBoundsArg > locUBoundsMe Then
            If AttribExtendToFit Then
                Me.ExtendToFit(fba.myLength)
            Else
                'Todo: Fehlermeldung schmei�en
                Throw New ArgumentException("Das angegebene BitArrayEx-Objekt wei�t eine gr��ere" + vbCr + _
                                             "Bitl�nge, als dieses Objekt auf. Es wurde eine Ausnahme" + vbCr + _
                                             "ausgel�st, da das ExtendToFit-Attribut nicht auf 'Wahr' gesetzt wurde." + vbCr + _
                                             "Das angegebene BitArrayEx-Objekt muss �ber die gleiche oder eine" + vbCr + _
                                             "kleinere Bitl�nge verf�gen!")
            End If
        Else

            'Falls diese Klasse "gr��er" ist als das 
            'oder "gleich" ist mit dem Argument:
            For c As Integer = 0 To locUBoundsArg
                Me.myBitStorage(c) = Me.myBitStorage(c) And fba.myBitStorage(c)
            Next

            'die "nicht vorhandenen" Bits des Operanden ber�cksichtigen
            '(Schleife wird bei "gleich" gar nicht erst ausgef�hrt)
            For c As Integer = locUBoundsArg + 1 To locUBoundsMe
                Me.myBitStorage(c) = Me.myBitStorage(c) Xor Me.myBitStorage(c)
            Next
        End If

    End Function

    Public Function [Or](ByVal fba As BitArrayEx) As BitArrayEx

        Dim locUBounds As Integer

        If fba Is Nothing Then
            Throw New NullReferenceException("Assigned BitArrayEx-Object is not initialiszed!")
        End If

        'Hier die "elegante" Version...
        locUBounds = CInt(IIf( _
            Me.myBitStorage.GetUpperBound(0) < fba.myBitStorage.GetUpperBound(0), _
            Me.myBitStorage.GetUpperBound(0), fba.myBitStorage.GetUpperBound(0)))

        For c As Integer = 0 To locUBounds
            Me.myBitStorage(c) = Me.myBitStorage(c) Or fba.myBitStorage(c)
        Next

    End Function

    Public Function [xor](ByVal fba As BitArrayEx) As BitArrayEx

        Dim locUBounds As Integer

        '...und hier die "fixe" Version
        Dim locUBoundsArg As Integer

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)
        locUBoundsArg = fba.myBitStorage.GetUpperBound(0)
        If locUBounds < locUBoundsArg Then
            locUBounds = locUBoundsArg
        End If

        For c As Integer = 0 To locUBounds
            Me.myBitStorage(c) = Me.myBitStorage(c) Xor fba.myBitStorage(c)
        Next

    End Function

    Public Sub [not]()

        Dim locUBounds As Integer

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)

        For c As Integer = 0 To locUBounds
            Me.myBitStorage(c) = Not Me.myBitStorage(c)
        Next

    End Sub

    Public Function ShiftLeft() As Boolean

        Dim locUBounds As Integer
        Dim c As Integer
        Dim locRet As Boolean

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)

        locRet = Me(myLength)

        For c = locUBounds To 1 Step -1
            Me.myBitStorage(c) = Me.myBitStorage(c) << 1
            Me.myBitStorage(c) = Me.myBitStorage(c) Or CInt((Me.myBitStorage(c - 1) And stBitTable(31)) = stBitTable(31))
        Next
        Me.myBitStorage(c) = Me.myBitStorage(c) << 1

        Return locRet

    End Function

    Public Function ShiftRight() As Boolean

        Dim locUBounds As Integer
        Dim c As Integer
        Dim locRet As Boolean

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)

        locRet = Me(1)

        For c = 0 To locUBounds - 1
            Me.myBitStorage(c) = Me.myBitStorage(c) >> 1
            Me.myBitStorage(c) = Me.myBitStorage(c) Or CInt((Me.myBitStorage(c + 1) And stBitTable(0)) = stBitTable(0))
        Next
        Me.myBitStorage(c) = Me.myBitStorage(c) >> 1

        Return locRet

    End Function

    Public Function Add(ByVal fba As BitArrayEx) As Boolean

        Dim locUBounds As Integer
        Dim locValue As OpValue
        Dim c As Integer

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)

        For c = 0 To locUBounds - 2
            locValue = OpValue.Add(Me.myBitStorage(c), fba.myBitStorage(c))
            Me.myBitStorage(c) = locValue.Value

            '�berlauf ins n�chste Double-Word mitnehmen
            If locValue.Carry Then
                locValue.ClrCarry()
                Me.myBitStorage(c + 1) += 1
            End If

        Next

        'Letztes DWord gesondert ber�cksichten, da es keinen �berlauf
        'ins n�chste DWord geben kann
        'Warum so? Weil es schneller ist und eine If-Abfrage in der Schleife fehlt
        'Beispiel f�r Assembler-Code
        locValue = OpValue.Add(Me.myBitStorage(c), fba.myBitStorage(c))
        Me.myBitStorage(c) = locValue.Value

        Return locValue.Carry

    End Function

    Public Function [sub](ByVal fba As BitArrayEx) As Boolean

        Dim locUBounds As Integer
        Dim locValue As OpValue
        Dim c As Integer

        'Obergrenzen der Bitspeicher ermitteln
        locUBounds = Me.myBitStorage.GetUpperBound(0)

        For c = locUBounds To 1 Step -1
            locValue = OpValue.Sub(Me.myBitStorage(c), fba.myBitStorage(c))
            Me.myBitStorage(c) = locValue.Value

            '�berlauf ins n�chste Double-Word mitnehmen
            If locValue.Carry Then
                locValue.ClrCarry()
                Me.myBitStorage(c - 1) -= 1
            End If
        Next

        'Letztes DWord gesondert ber�cksichtigen, da es auch bei
        'der Subtraktion keinen Unterlauf ins n�chste DWord geben kann
        locValue = OpValue.Sub(Me.myBitStorage(c), fba.myBitStorage(c))
        Me.myBitStorage(c) = locValue.Value

        Return locValue.Carry

    End Function

    Public Overrides Function ToString() As String

        Dim locString As New StringBuilder(myLength)

        For c As Integer = myLength To 1 Step -1
            If Me(c) Then
                locString.Append("1")
            Else
                locString.Append("0")
            End If
        Next

        Return locString.ToString()

    End Function

End Class
