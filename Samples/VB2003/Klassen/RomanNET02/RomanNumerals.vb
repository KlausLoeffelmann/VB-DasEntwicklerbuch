Option Strict On
Option Explicit On 

Public Class RomanNumerals

    Private myUnderlyingValue As Integer

    Public Function ToRomanNumeral() As String

        'Statische Funktion aufrufen
        Return Me.RomanNumeralFromValue(myUnderlyingValue)

    End Function

    Public Sub New(ByVal RomanNumeral As String)

        'Statische Funktion aufrufen
        myUnderlyingValue = ValueFromRomanNumeral(RomanNumeral)

    End Sub

    Public Sub New(ByVal ArabicInt As Integer)

        'einfach der Instanzvariable zuweisem
        myUnderlyingValue = ArabicInt

    End Sub

#Region ""
    <Obsolete("Sie sollten diese Funktion nicht mehr sondern die Klassenkonstruktor verwenden", False)> _
    Public Sub FromNumeral(ByVal RomanNumeral As String)

        'Statische Funktion aufrufen
        myUnderlyingValue = ValueFromRomanNumeral(RomanNumeral)

    End Sub

    <Obsolete("Sie sollten diese Funktion nicht mehr sondern die Klassenkonstruktor verwenden", False)> _
    Public Sub FromInt(ByVal ArabicInt As Integer)

        'einfach der Instanzvariable zuweisem
        myUnderlyingValue = ArabicInt

    End Sub
#End Region

    Public Shared Function RomanNumeralFromValue(ByVal ArabicNumber As Integer) As String

        Dim locCount As Integer
        Dim locDigitValue As Integer
        Dim locRoman As String
        Dim locDigits As String

        'Diese römischen Numerales gibt es
        locDigits = "IVXLCDM"

        locCount = 1
        Do While ArabicNumber > 0

            locDigitValue = ArabicNumber Mod 10
            Select Case locDigitValue

                'Ziffern 1 bis 3 werden einfach hintereinander geschrieben (I, II, III)
            Case 1 To 3
                    locRoman = New String(CChar(locDigits.Substring(locCount - 1, 1)), locDigitValue) & locRoman

                    'Die 4. Ziffer ist der "Einer-Wert" vor dem nächsten "fünfer-Wert" (IV)
                Case 4
                    locRoman = locDigits.Substring(locCount - 1, 2) & locRoman

                    'Die 5. Ziffer hat ein eigenes Numerale (V)
                Case 5
                    locRoman = locDigits.Substring(locCount, 1) & locRoman

                    'Kombination aus "Fünfer-Werten" und einer Werten (VI, VII, VIII)
                Case 6 To 8
                    locRoman = locDigits.Substring(locCount, 1) & _
                            New String(CChar(locDigits.Substring(locCount - 1, 1)), locDigitValue - 5) & locRoman

                    'Kombination aus "Einer-Wert" und "Zehner-Wert" (IX)
                Case 9
                    locRoman = locDigits.Substring(locCount - 1, 1) & locDigits.Substring(locCount + 1, 1) & locRoman

            End Select
            locCount += 2
            ArabicNumber \= 10
        Loop

        Return locRoman

    End Function

    Public Shared Function ValueFromRomanNumeral(ByVal RomanNumeral As String) As Integer

        Static Table(6, 1) As String
        Dim locCount As Integer
        Dim locChar As Char
        Dim retValue As Integer
        Dim z1 As Integer, z2 As Integer

        If RomanNumeral = "" Then
            ValueFromRomanNumeral = 0
            Exit Function
        End If

        'Tabelle zum Nachschlagen
        'das geht eleganter, aber in dieser Version
        'soll es reichen.
        Table(0, 0) = "I" : Table(0, 1) = "1"
        Table(1, 0) = "V" : Table(1, 1) = "5"
        Table(2, 0) = "X" : Table(2, 1) = "10"
        Table(3, 0) = "L" : Table(3, 1) = "50"
        Table(4, 0) = "C" : Table(4, 1) = "100"
        Table(5, 0) = "D" : Table(5, 1) = "500"
        Table(6, 0) = "M" : Table(6, 1) = "1000"

        'eigentliche überflüssig, weil's VB macht,
        'aber Pflicht bei anderen .NET-Sprachen!
        locCount = 0

        Do While locCount < Len(RomanNumeral)

            locChar = RomanNumeral.Chars(locCount)

            If locCount < Len(RomanNumeral) - 1 Then
                For z1 = 0 To 6
                    If Table(z1, 0) = locChar Then Exit For
                Next z1
                For z2 = 0 To 6
                    If Table(z2, 0) = Mid$(RomanNumeral, locCount + 1, 1) Then
                        Exit For
                    End If
                Next z2
                If Val(Table(z1, 1)) < Val(Table(z2, 1)) Then

                    'Stringfragment entfernen
                    RomanNumeral = Left$(RomanNumeral, locCount - 1) + Mid$(RomanNumeral, locCount + 2)
                    retValue = retValue + Convert.ToInt32((Val(Table(z2, 1)) - Val(Table(z1, 1))))
                Else
                    For z2 = 0 To 6
                        If Table(z2, 0) = locChar Then Exit For
                    Next z2
                    retValue = retValue + Convert.ToInt32(Val(Table(z2, 1)))
                    locCount = locCount + 1
                End If
            Else
                For z2 = 0 To 6
                    If Table(z2, 0) = locChar Then Exit For
                Next z2
                retValue = retValue + Convert.ToInt32(Val(Table(z2, 1)))
                locCount = locCount + 1
            End If
        Loop

        ValueFromRomanNumeral = retValue
        Exit Function

    End Function


End Class
