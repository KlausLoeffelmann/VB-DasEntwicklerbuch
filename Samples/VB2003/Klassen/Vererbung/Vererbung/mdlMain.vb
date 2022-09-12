Module mdlMain

    Sub Main()
        Dim klasse1 As New ErsteKlasse
        klasse1.Value = 5
        Console.WriteLine(klasse1.InString())

        Dim klasse2 As New ZweiteKlasse
        'klasse2.Value = 5
        Console.WriteLine(klasse2.Value10Added)

        Console.WriteLine()
        Console.WriteLine("Return drücken, zum Beenden")
        Console.ReadLine()
    End Sub

End Module

Class ErsteKlasse

    Protected myValue As Integer

    Sub New(ByVal Value As Integer)

    End Sub

    'Eigenschaft, um den Wert verändern zu können
    Property Value() As Integer

        Get
            Return myValue
        End Get

        Set(ByVal Value As Integer)
            myValue = Value
        End Set

    End Property

    'Um die Funktion als String auszudrucken
    Function InString() As String

        Return myValue.ToString()

    End Function

End Class

Class ZweiteKlasse
    Inherits ErsteKlasse

    ReadOnly Property Value10Added() As Integer

        Get
            Return myValue + 10
        End Get

    End Property

End Class