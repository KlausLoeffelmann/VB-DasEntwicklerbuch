Public Class Primitives

    Public Shared Sub main()

        Dim locDouble1, locDouble2 As Double
        Dim locDec1, locDec2 As Decimal

        locDouble1 = 123.434D
        locDouble2 = 321.121D
        locDouble2 += 1
        locDouble1 += locDouble2
        Console.WriteLine("Ergebnis der Double-Berechnung: {0}", locDouble1)

        locDec1 = 123.434D
        locDec2 = 321.121D
        locDec2 += 1
        locDec1 += locDec2
        Console.WriteLine("Ergebnis der Decimal-Berechnung: {0}", locDec1)

    End Sub
End Class
