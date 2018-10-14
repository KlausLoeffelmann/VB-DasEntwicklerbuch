Public Class Primitives

    Public Shared Sub main()

        Dim locDouble1, locDouble2 As Double
        Dim locDec1, locDec2 As Decimal

        locDouble1 = 69.82
        locDouble2 = 69.2
        locDouble2 += 0.62

        Console.WriteLine("Die Aussage locDOuble1=locDouble2 ist {0}", locDouble1 = locDouble2)
        'Console.WriteLine("locDouble1 lautet {0}; locDouble2 lautet {1}", locDouble1, locDouble2)

        locDec1 = 69.82D
        locDec2 = 69.2D
        locDec2 += 0.62D
        Console.WriteLine("Die Aussage locDec1=locDec2 ist {0}", locDec1 = locDec2)

    End Sub

End Class
