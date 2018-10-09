Module mdlMain

    Sub Main()

        Dim klasse1 As New ErsteKlasse(5)
        Console.WriteLine("Klasse1 ergibt durch ToString: " & klasse1.ToString())

        Dim klasse2 As ErsteKlasse
        klasse2 = New ZweiteKlasse(5)

        Console.WriteLine("Klasse2 ergibt durch ToString: " & klasse2.ToString())

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste dr�cken")
        Console.ReadKey()
    End Sub

End Module

Class ErsteKlasse

    Private myEinWert As Integer

    Sub New(ByVal NeuerWert As Integer)
        myEinWert = NeuerWert
    End Sub

    'Eigenschaft, um den Wert ver�ndern zu k�nnen
    Property EinWert() As Integer

        Get
            Return myEinWert
        End Get

        Set(ByVal Value As Integer)
            myEinWert = Value
        End Set

    End Property

    'Um die Funktion als String auszudrucken
    Public Overrides Function ToString() As String

        Return myEinWert.ToString()

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

    Public Overrides Function ToString() As String

        Return "der Wert lautet: " & MyBase.ToString()

    End Function

End Class