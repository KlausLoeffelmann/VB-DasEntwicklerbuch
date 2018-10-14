Imports System.Globalization

' Diese Datei fasst mehrere Beispiele zusammen.
' Ändern Sie das Startobjekt in den Projekteigenschaften,
' um die "richtige" Sub Main für Ihre Experimente auszuwählen.

Module FormatDemos

    Sub Main()

        Dim locDate As Date = #12/24/2003 10:33:00 PM#
        Dim locDouble As Double = 1234.56789

        Console.WriteLine(locDouble.ToString())
        Console.WriteLine(locDate.ToString())
        Console.ReadLine()

    End Sub

End Module

Module NumFormatInfoBeispiel
    Sub main()

        'zu verwendenden Wert definieren
        Dim locDouble As Double = 1234567.23
        'Kultureinstellungen sind englisch/britisch
        Dim locCultureInfo As New CultureInfo("en-GB")
        'Die Einstellungen, die CultureInfo auf Grund der Kultur schon
        'geleistet hat, über nehmen wir in ein NumberFormatInfo
        Dim locNumFormatInfo As NumberFormatInfo = locCultureInfo.NumberFormat

        '...dessen anzuwendende Regeln wir nun genauer spezifizieren können:
        locNumFormatInfo.CurrencyGroupSeparator = " "
        Console.WriteLine("Als Währung formatiert: " + locDouble.ToString("C", locNumFormatInfo))

        'auf die normale Fließkommadarstellung hat diese Einstellung keinen Einfluss:
        Console.WriteLine("Als Fließkommazahl formatiert: " + locDouble.ToString("n", locNumFormatInfo))

        'jetzt schon!
        locNumFormatInfo.NumberGroupSeparator = " "
        Console.WriteLine("Als Fließkommazahl formatiert: " + locDouble.ToString("n", locNumFormatInfo))

        Console.ReadLine()

    End Sub
End Module

Module FormatDemosCultureInfo

    Sub Main()

        Dim locDate As Date = #12/24/2003 10:33:00 PM#
        Dim locDouble As Double = 1234.56789
        Dim locCultureInfo As New CultureInfo("en-IE")
        'Dim locCultureInfo As CultureInfo = CultureInfo.InvariantCulture

        Console.WriteLine(locDouble.ToString(locCultureInfo))
        Console.WriteLine(locDate.ToString(locCultureInfo))
        'Console.WriteLine(locDouble.ToString(CultureInfo.CurrentCulture))
        'Console.WriteLine(locDate.ToString(CultureInfo.CurrentCulture))

        Dim locDoubleTest As Double = CDbl("1.234")
        Console.WriteLine(locDoubleTest)
        Console.ReadLine()

    End Sub

End Module

Module FormatDemosMusterzeichenfolgen

    Sub Main()

        Dim locDouble As Double
        Dim locFormat As String = "#,###.00;-#,###.0000;+-0.00000"
        locDouble = Math.PI + 10000 * Math.PI
        Console.WriteLine("locDouble hat den Wert: " + locDouble.ToString(locFormat))
        locDouble *= -1
        Console.WriteLine("locDouble hat den Wert: " + locDouble.ToString(locFormat))
        locDouble = 0
        Console.WriteLine("locDouble hat den Wert: " + locDouble.ToString(locFormat))

        locDouble = 12234.346
        Console.WriteLine("Sie bekommen {0} aus einem Lottogewinn.", locDouble.ToString("$#,###.00"))
        Console.WriteLine("Sie bekommen {0} aus einem Lottogewinn.", locDouble.ToString("C", New CultureInfo("en-US")))

        Console.ReadLine()


    End Sub

End Module
