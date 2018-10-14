Module Strings
    Sub Main()
        Dim locString As String = _
           "Einzelne, Elemente; durch, die , verschiedensten - Zeichen , getrennt."
        Console.WriteLine("Aus der Zeile:")
        Console.WriteLine(locString)
        Console.WriteLine()
        Console.WriteLine("Wird ein String-Array mit folgenden Elementen:")

        Dim locStringArray As String()
        locStringArray = locString.Split(New Char() {","c, ";"c, "-"c, "."c})
        For Each locStr As String In locStringArray
            Console.WriteLine(ReplaceEx(locStr, New Char() {","c, ";"c, "-"c, "."c}, Convert.ToChar(vbNullChar)).Trim)
        Next
        Console.ReadLine()
    End Sub

    Public Function ReplaceEx(ByVal str As String, ByVal SearchChars As Char(), ByVal ReplaceChar As Char) As String

        Dim locPos As Integer
        Do
            locPos = str.IndexOfAny(SearchChars)
            If locPos = -1 Then Exit Do
            If AscW(ReplaceChar) = 0 Then
                str = str.Remove(locPos, 1)
            Else
                str = str.Remove(locPos, 1).Insert(locPos, ReplaceChar.ToString)
            End If
        Loop
        Return str
    End Function

End Module
