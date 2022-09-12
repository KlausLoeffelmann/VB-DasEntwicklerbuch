Module Module1

    Sub Main()
        Console.ReadKey()
        If Debugger.IsAttached Then
            Debugger.Break()
        End If
        Dim s = Square(12)
        Dim p = Power(2, 12)
        Console.WriteLine(s.ToString)
        Console.WriteLine(s.ToString)
    End Sub

    Function Square(ByVal var1 As Integer) As Integer
        Dim ret = var1 * var1
        Return ret
    End Function

    Function Power(ByVal var1 As Integer, ByVal var2 As Integer) As Integer
        For c As Integer = 1 To var2
            var1 *= var1
        Next
        Return var1
    End Function

End Module
