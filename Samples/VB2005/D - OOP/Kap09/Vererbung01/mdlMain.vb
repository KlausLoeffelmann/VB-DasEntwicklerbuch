Module mdlMain

    Sub Main()
        Dim klasse1 As New ErsteKlasse
        klasse1.EinWert = 5
        Console.WriteLine(klasse1.AlsZeichenkette())

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste drücken")
        Console.ReadLine()
    End Sub

End Module

Class ErsteKlasse

    Protected myEinWert As Integer

    'Eigenschaft, um den Wert verändern zu können.
    Property EinWert() As Integer

        Get
            Return myEinWert
        End Get

        Set(ByVal Value As Integer)
            myEinWert = Value
        End Set

    End Property

    'Funktion, um den Inhalt als Zeichenkette (String) zurückzuliefern.
    Function AlsZeichenkette() As String

        Return CStr(myEinWert)

    End Function

End Class

