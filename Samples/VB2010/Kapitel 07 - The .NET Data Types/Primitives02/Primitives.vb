Imports System.Globalization

Public Class Primitives

    Public Shared Sub main()

        Dim locDouble1, locDouble2 As Double
        Dim locDec1, locDec2 As Decimal

        locDouble1 = 69.82
        locDouble2 = 69.2
        locDouble2 += 0.62

        Console.WriteLine("Die Aussage locDouble1=locDouble2 ist {0}", locDouble1 = locDouble2)
        Console.WriteLine("aber locDouble1 lautet {0} und locDouble2 lautet {1}", locDouble1, locDouble2)

        locDec1 = 69.82D
        locDec2 = 69.2D
        locDec2 += 0.62D
        Console.WriteLine("Die Aussage locDec1=locDec2 ist {0}", locDec1 = locDec2)

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
        'End

        'Beispielcode für weiteres Beispiel
        Dim locString As String = "123,123,123"
        Dim locdouble As Double

        locdouble = Double.Parse(locString, CultureInfo.InvariantCulture)
        Console.WriteLine(locdouble.ToString(CultureInfo.InvariantCulture))
        Console.ReadKey()

    End Sub

End Class
