Imports System.WIndows.Forms

Module mdlMain

    Sub Main()

        Dim klasse1 As New ErsteKlasse(5)
        klasse1.EinWert = 5
        Console.WriteLine(klasse1.AlsZeichenkette())

        Dim klasse2 As New ZweiteKlasse
        klasse2.EinWert = 5

        Console.WriteLine(klasse2.Um10Mehr)
        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste drücken")
        Console.ReadKey()
    End Sub

End Module

Class ErsteKlasse

    Private myEinWert As Integer = 10

    'Eigenschaft, um den Wert verändern zu können.
    Property EinWert() As Integer
        Get
            Return myEinWert
        End Get
        Set(ByVal value As Integer)
            myEinWert = value
        End Set
    End Property

    'Funktion, um den Inhalt als Zeichenkette (String) zurückzuliefern.
    Function AlsZeichenkette() As String

        Return CStr(myEinWert)

    End Function

End Class

Class ZweiteKlasse
    Inherits ErsteKlasse

    ReadOnly Property Um10Mehr() As Integer
        Get
            Return EinWert + 10
        End Get
    End Property
End Class

