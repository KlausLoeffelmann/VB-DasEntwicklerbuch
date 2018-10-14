Module mdlMain

    Sub Main()
        Dim locTest As New Testklasse("Erste Testklasse")
        Dim locTest2 As New Testklasse("Zweite Testklasse")
        locTest = Nothing
        locTest2 = Nothing
        GC.Collect()
        Console.WriteLine("Beide Objekte sind nun nicht mehr in Verwendung!")
    End Sub

End Module

Class Testklasse

    Private myName As String

    Sub New(ByVal Name As String)
        myName = Name
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        'Console.WriteLine(Me.myName & " wurde entsorgt")
        Console.WriteLine(Me.myName & " wurde entsorgt")
    End Sub
End Class