Option Explicit On 
Option Strict On

Imports System.Threading

Module mdlMain

    Sub Main()

        Dim locVierteKlasse As New VierteKlasse
        Dim locErsteKlasse As ErsteKlasse = locVierteKlasse
        Dim locZweiteKlasse As ZweiteKlasse = locVierteKlasse
        Dim locDritteKlasse As DritteKlasse = locVierteKlasse

        Console.WriteLine(locErsteKlasse.EineFunktion_a)
        Console.WriteLine(locZweiteKlasse.EineFunktion_a)
        Console.WriteLine(locDritteKlasse.EineFunktion_b)
        Console.WriteLine(locVierteKlasse.EineFunktion_b)

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden!")
        Console.ReadLine()

    End Sub

End Module

Public Class ErsteKlasse

    Public Overridable Function EineFunktion_a() As String
        Return "Erste Klasse"
    End Function

End Class

Public Class ZweiteKlasse
    Inherits ErsteKlasse

    Public Overrides Function EineFunktion_a() As String
        Return "Zweite Klasse"
    End Function

End Class

Public Class DritteKlasse
    Inherits ZweiteKlasse

    '"Override" wurde gegen "Overridable Shadows" ausgetauscht:
    Public Overridable Function EineFunktion_b() As String
        Return "Dritte Klasse"
    End Function

End Class

Public Class VierteKlasse
    Inherits DritteKlasse

    Public Overrides Function EineFunktion_b() As String
        Return "Vierte Klasse"
    End Function

End Class
