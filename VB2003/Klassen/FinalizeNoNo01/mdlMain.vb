Module mdlMain

    Sub Main()
        Dim locTest As New Testklasse("Testklasse")
    End Sub

End Module

Class Testklasse

    Private myName As String

    Sub New(ByVal Name As String)
        myName = Name
    End Sub

    Sub WriteText()
        Console.Write(myName)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Dim locTemp As New Testklasse("locTemp")
        WriteText()
        Console.WriteLine(" wurde entsorgt")
    End Sub
End Class