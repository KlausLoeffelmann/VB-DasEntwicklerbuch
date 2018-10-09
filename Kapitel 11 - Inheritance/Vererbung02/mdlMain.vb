Module mdlMain

    Sub Main()

        Dim klasse1 As New ErsteKlasse(5)
        Console.WriteLine("Klasse1 ergibt durch AlsZeichenkette: " & klasse1.AlsZeichenkette())

        Dim klasse2 As New ZweiteKlasse(5)
        Console.WriteLine("Klasse2 ergibt durch AlsZeichenkette: " & klasse2.AlsZeichenkette())

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste drücken")
        Console.ReadKey()
    End Sub

End Module

Class ErsteKlasse

    Private myEinWert As Integer

    Sub New(ByVal NeuerWert As Integer)
        myEinWert = NeuerWert
    End Sub

    'Eigenschaft, um den Wert verändern zu können
    Property EinWert() As Integer

        Get
            Return myEinWert
        End Get

        Set(ByVal Value As Integer)
            myEinWert = Value
        End Set

    End Property

    'Funktion, um den Inhalt als Zeichenkette (String) zurückzuliefern.
    Public Overridable Function AlsZeichenkette() As String

        Return CStr(myEinWert)

    End Function

End Class

Class ZweiteKlasse
    Inherits ErsteKlasse

    Sub New(ByVal NeuerWert As Integer)
        MyBase.New(NeuerWert)
    End Sub

    ReadOnly Property Um10Mehr() As Integer

        Get
            Return EinWert + 10
        End Get

    End Property

    Public Overrides Function AlsZeichenkette() As String
        Return "der Wert lautet: " & MyBase.AlsZeichenkette()
    End Function

End Class