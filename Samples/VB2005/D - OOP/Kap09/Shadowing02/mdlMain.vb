Module mdlMain

    Sub Main()

        Dim locVierteKlasse As New VierteKlasse
        Dim locErsteKlasse As ErsteKlasse = locVierteKlasse
        Dim locZweiteKlasse As ZweiteKlasse = locVierteKlasse
        Dim locDritteKlasse As DritteKlasse = locVierteKlasse

        Console.WriteLine(locErsteKlasse.EineFunktion)
        Console.WriteLine(locZweiteKlasse.EineFunktion)
        Console.WriteLine(locDritteKlasse.EineFunktion)
        Console.WriteLine(locVierteKlasse.EineFunktion)

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module

Public Class ErsteKlasse

    Public Overridable Function EineFunktion() As String
        Return "Erste Klasse"
    End Function

End Class

Public Class ZweiteKlasse
    Inherits ErsteKlasse

    Public Overrides Function EineFunktion() As String
        Return "Zweite Klasse"
    End Function

End Class

Public Class DritteKlasse
    Inherits ZweiteKlasse

    '"Overrides" gegen "Overridable Shadows" austauschen:
    Public Overrides Function EineFunktion() As String
        Return "Dritte Klasse"
    End Function

End Class

Public Class VierteKlasse
    Inherits DritteKlasse

    Public Overrides Function EineFunktion() As String
        Return "Vierte Klasse"
    End Function

End Class
