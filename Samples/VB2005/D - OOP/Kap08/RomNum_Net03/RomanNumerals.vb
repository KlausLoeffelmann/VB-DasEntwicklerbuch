Public Class RomanNumerals

    Private myUnderlyingValue As Integer = 1000
    Private Shared Table(6, 1) As String

    Shared Sub New()

        'Tabelle zum Nachschlagen
        'Diesmal statisch (Shared) deklariert - das spart schon einmal Zeit.
        Table(0, 0) = "I" : Table(0, 1) = "1"
        Table(1, 0) = "V" : Table(1, 1) = "5"
        Table(2, 0) = "X" : Table(2, 1) = "10"
        Table(3, 0) = "L" : Table(3, 1) = "50"
        Table(4, 0) = "C" : Table(4, 1) = "100"
        Table(5, 0) = "D" : Table(5, 1) = "500"
        Table(6, 0) = "M" : Table(6, 1) = "1000"

    End Sub


    Public Sub New(ByVal RomanNumeral As String)

        'Statische Funktion aufrufen.
        myUnderlyingValue = ValueFromRomanNumeral(RomanNumeral)

    End Sub

    Public Sub New(ByVal ArabicInt As Integer)

        'Einfach der Instanzvariablen zuweisen.
        myUnderlyingValue = ArabicInt

    End Sub

    Public Function ToRomanNumeral() As String

        'Statische Funktion aufrufen
        Return RomanNumeralFromValue(myUnderlyingValue)

    End Function


#Region "Obsolete Funktionen"
    <Obsolete("Verwenden Sie statt dieser Funktion den Klassenkonstruktor")> _
    Public Sub FromNumeral(ByVal RomanNumeral As String)

        'Statische Funktion aufrufen
        myUnderlyingValue = ValueFromRomanNumeral(RomanNumeral)

    End Sub

    <Obsolete("Verwenden Sie statt dieser Funktion den Klassenkonstruktor")> _
    Public Sub FromInt(ByVal ArabicInt As Integer)

        'einfach der Instanzvariable zuweisem
        myUnderlyingValue = ArabicInt

    End Sub
#End Region

    Public Shared Function RomanNumeralFromValue(ByVal ArabicNumber As Integer) As String

        Dim locCount As Integer = 0
        Dim locDigitValue As Integer = 0
        Dim locRoman As String = ""
        Dim locDigits As String = ""

        'Diese römischen Basisnumeralia gibt es
        locDigits = "IVXLCDM"

        locCount = 1
        Do While ArabicNumber > 0

            locDigitValue = ArabicNumber Mod 10
            Select Case locDigitValue

                'Ziffern 1 bis 3 werden einfach hintereinander geschrieben (I, II, III)
                Case 1 To 3

                    'VB6-Stil: locRoman = String$(locDigitValue, Mid$(locDigits, locCount, 1)) & locRoman
                    locRoman = New String(CChar(locDigits.Substring(locCount - 1, 1)), locDigitValue) & locRoman

                    'Die 4. Ziffer ist der "Einer-Wert" vor dem nächsten "Fünfer-Wert" (IV)
                Case 4
                    locRoman = locDigits.Substring(locCount - 1, 2) & locRoman

                    'Die 5. Ziffer hat ein eigenes Numerale (V)
                Case 5
                    'VB6-Stil: locRoman = Mid$(locDigits, locCount + 1, 1) & locRoman
                    locRoman = locDigits.Substring(locCount, 1) & locRoman

                    'Kombination aus "Fünfer-Werten" und "Einer-Werten" (VI, VII, VIII)
                Case 6 To 8
                    'VB6-Stil:
                    'locRoman = Mid$(locDigits, locCount + 1, 1) & _
                    'String$(locDigitValue - 5, Mid$(locDigits, locCount, 1)) & locRoman

                    locRoman = locDigits.Substring(locCount, 1) & _
                            New String(CChar(locDigits.Substring(locCount - 1, 1)), locDigitValue - 5) & locRoman

                    'Kombination aus "Einer-Wert" und "Zehner-Wert" (IX)
                Case 9
                    'VB6-Stil: locRoman = Mid$(locDigits, locCount, 1) & Mid$(locDigits, locCount + 2, 1) & locRoman
                    locRoman = locDigits.Substring(locCount - 1, 1) & locDigits.Substring(locCount + 1, 1) & locRoman

            End Select
            locCount += 2
            ArabicNumber \= 10
        Loop

        Return locRoman

    End Function

    Public Shared Function ValueFromRomanNumeral(ByVal RomanNumeral As String) As Integer

        Dim locCount As Integer
        Dim locChar As Char
        Dim retValue As Integer
        Dim z1 As Integer, z2 As Integer

        If RomanNumeral = "" Then
            Return 0
        End If

        locCount = 0

        Do While locCount < Len(RomanNumeral)

            locChar = RomanNumeral.Chars(locCount)

            'VB6-Stil: If locCount < Len(RomanNumeral) - 1 Then
            If locCount < RomanNumeral.Length - 1 Then
                For z1 = 0 To 6
                    If Table(z1, 0) = locChar Then Exit For
                Next z1
                For z2 = 0 To 6
                    'VB6-Stil If Table(z2, 0) = Mid$(RomanNumeral, locCount + 1, 1) Then
                    If Table(z2, 0) = RomanNumeral.Substring(locCount + 1, 1) Then
                        Exit For
                    End If
                Next z2
                If CInt(Table(z1, 1)) < CInt(Table(z2, 1)) Then

                    'Stringfragment entfernen
                    'VB6-Stil: RomanNumeral = Left$(RomanNumeral, locCount - 1) + Mid$(RomanNumeral, locCount + 2)
                    RomanNumeral = RomanNumeral.Substring(0, locCount - 1) + RomanNumeral.Substring(locCount + 2)
                    retValue = retValue + (CInt(Table(z2, 1)) - CInt(Table(z1, 1)))
                Else
                    For z2 = 0 To 6
                        If Table(z2, 0) = locChar Then Exit For
                    Next z2
                    'VB6-Stil: retValue = retValue + Convert.ToInt32(Val(Table(z2, 1)))
                    retValue += CInt(Table(z2, 1))
                    locCount += 1
                End If
            Else
                For z2 = 0 To 6
                    If Table(z2, 0) = locChar Then Exit For
                Next z2
                retValue += CInt(Table(z2, 1))
                locCount += 1
            End If
        Loop

        'VB6-Stil: ValueFromRomanNumeral = retValue : Exit Function
        Return retValue

    End Function


End Class
