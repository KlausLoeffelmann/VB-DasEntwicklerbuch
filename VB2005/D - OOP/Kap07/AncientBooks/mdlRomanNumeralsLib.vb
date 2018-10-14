Module mdlRomanNumeralsLib

    Public Function RomanNumeral(ByVal ArabicNumber As Integer) As String

        Dim locCount As Integer = 0
        Dim locDigitValue As Integer = 0
        Dim locRoman As String = ""
        Dim locDigits As String = ""

        'Diese römischen Basis-Numeralia gibt es:
        locDigits = "IVXLCDM"

        'Der maximal darstellbare Bereich - eine Null gibt es nicht.
        If ArabicNumber < 1 Or ArabicNumber > 3999 Then
            RomanNumeral = "#N/A#"
            Exit Function
        End If

        locCount = 1
        Do While ArabicNumber > 0
            locDigitValue = ArabicNumber Mod 10
            Select Case locDigitValue

                'Ziffern 1 bis 3 werden einfach hintereinander geschrieben (I, II, III).
                Case 1 To 3
                    locRoman = String$(locDigitValue, Mid$(locDigits, locCount, 1)) & locRoman

                    'Die 4. Ziffer ist der "Einer-Wert" vor dem nächsten "fünfer-Wert" (IV).
                Case 4
                    locRoman = Mid$(locDigits, locCount, 2) & locRoman

                    'Die 5. Ziffer hat ein eigenes Numerale (V).
                Case 5
                    locRoman = Mid$(locDigits, locCount + 1, 1) & locRoman

                    'Kombination aus "Fünfer-Werten" und "Einer-Werten" (VI, VII, VIII):
                Case 6 To 8
                    locRoman = Mid$(locDigits, locCount + 1, 1) & _
                    String$(locDigitValue - 5, Mid$(locDigits, locCount, 1)) & locRoman

                    'Kombination aus "Einer-Wert" und "Zehner-Wert" (IX):
                Case 9
                    locRoman = Mid$(locDigits, locCount, 1) & Mid$(locDigits, locCount + 2, 1) & locRoman

            End Select
            locCount = locCount + 2
            ArabicNumber = ArabicNumber \ 10
        Loop
        RomanNumeral = locRoman
    End Function

    Public Function ValueFromRomanNumeral(ByVal RomanNumeral As String) As Integer

        On Error GoTo vfrn_error

        RomanNumeral = UCase(RomanNumeral)

        Static Table(0 To 6, 0 To 1) As String

        Dim locCount As Integer
        Dim locChar As Char
        Dim retValue As Integer
        Dim z1 As Integer, z2 As Integer

        If RomanNumeral = "" Then
            ValueFromRomanNumeral = 0
            Exit Function
        End If

        'Tabelle zum Nachschlagen
        Table(0, 0) = "I" : Table(0, 1) = "1"
        Table(1, 0) = "V" : Table(1, 1) = "5"
        Table(2, 0) = "X" : Table(2, 1) = "10"
        Table(3, 0) = "L" : Table(3, 1) = "50"
        Table(4, 0) = "C" : Table(4, 1) = "100"
        Table(5, 0) = "D" : Table(5, 1) = "500"
        Table(6, 0) = "M" : Table(6, 1) = "1000"

        locCount = 1

        Do While locCount <= Len(RomanNumeral)
            locChar = Convert.ToChar(Mid(RomanNumeral, locCount, 1))

            If locCount < Len(RomanNumeral) Then
                For z1 = 0 To 6
                    If Table(z1, 0) = locChar Then Exit For
                Next z1
                For z2 = 0 To 6
                    If Table(z2, 0) = Mid(RomanNumeral, locCount + 1, 1) Then
                        Exit For
                    End If
                Next z2
                If Val(Table(z1, 1)) < Val(Table(z2, 1)) Then
                    'Stringfragment entfernen
                    RomanNumeral = Microsoft.VisualBasic.Left(RomanNumeral, locCount - 1) + Mid(RomanNumeral, locCount + 2)
                    retValue = retValue + (CInt(Table(z2, 1)) - CInt(Table(z1, 1)))
                Else
                    For z2 = 0 To 6
                        If Table(z2, 0) = locChar Then Exit For
                    Next z2
                    retValue = retValue + CInt(Table(z2, 1))
                    locCount = locCount + 1
                End If
            Else
                For z2 = 0 To 6
                    If Table(z2, 0) = locChar Then Exit For
                Next z2
                retValue = retValue + CInt(Table(z2, 1))
                locCount = locCount + 1
            End If
        Loop

        ValueFromRomanNumeral = retValue
        Exit Function

vfrn_error:
        ValueFromRomanNumeral = 0
        Exit Function

    End Function

#Region "'Mogelbereich', der die nicht mehr vorhandene String$-Funktion kompensiert"
    ' Hier hinter verbirgt sich die String$-Funktion aus VB6, die aber 
    ' überflüssig geworden ist.
    Private Function [String](ByVal number As Integer, ByVal character As String) As String
        Return New String(character.ToCharArray()(0), number)
    End Function

    Private Function [String](ByVal number As Integer, ByVal character As Integer) As String
        Return New String(Convert.ToChar(character), number)
    End Function
#End Region

End Module
