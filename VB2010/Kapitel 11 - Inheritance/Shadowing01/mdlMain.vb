Module mdlMain

    Sub Main()
        Dim locBasisinstanz As New Basisklasse
        Console.WriteLine(locBasisinstanz.EineFunktion().ToString())

        locBasisinstanz = New AbgeleiteteKlasse
        Console.WriteLine(locBasisinstanz.EineFunktion().ToString())

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module

Public Class Basisklasse

    Protected test As Integer

    Sub New()
        test = 10
    End Sub

    Public Function EineFunktion() As Integer
        Return test * 2
    End Function

End Class

Public Class AbgeleiteteKlasse
    Inherits Basisklasse

    Public Function EineFunktion() As Integer
        Return test * 3
    End Function

End Class
