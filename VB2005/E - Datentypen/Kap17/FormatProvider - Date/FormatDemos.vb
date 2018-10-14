Imports System.Globalization

' Diese Datei fasst mehrere Beispiele zusammen.
' Ändern Sie das Startobjekt in den Projekteigenschaften,
' um die "richtige" Sub Main für Ihre Experimente auszuwählen.

Module FormatDemos

    Sub Main()

        Dim locDate As Date
        locDate = #12/24/2003 10:33:00 PM#
        'Console.WriteLine("locDate hat den Wert: " + locDate.ToString())
        Console.WriteLine("locDate hat den Wert: " + locDate.ToString("gg dddd, dd. MMM yyyy - tt HH:mm", New CultureInfo("en-US")))
        Console.ReadLine()

    End Sub

End Module

Module VereinfachteFormatzeichenfolgen
    Sub main()
        Dim locDate As Date = #12/24/2005 10:32:22 PM#
        Dim locFormat As String

        locFormat = "dddd, dd. MMMM yyyy"
        Console.WriteLine("Datumsformatierung mit Formatzeichen:" + locDate.ToString(locFormat))
        Console.WriteLine("...und mit vereinfachten Formatzeichen:" + locDate.ToString("Y"))
        'Console.WriteLine("Die Zeichenfolge war:"+ShortDatePattern
        Console.ReadLine()

    End Sub
End Module

Module FormatDemosFormatzeichenfolgen
    Sub Main()
        Dim locDate As Date = #12/24/2005 10:32:22 PM#
        Dim locFormat As String

        'Normale Datumsausgabe; große M's ergeben den Monat
        locFormat = "dd.MM.yyyy"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, CultureInfo.CurrentCulture))

        'Falsche Ausgabe; anstelle des Monats werden Minuten ausgegen
        locFormat = "dd.mm.yyyy"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, CultureInfo.CurrentCulture))

        'Komplette Ausgabe, ausführlicher geht's nicht
        locFormat = "dddd, dd.MMMM.yyyy - HH:mm:ss:fffffff ""(Offset:"" zzz)"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, CultureInfo.CurrentCulture))

        'Falsche Ausgabe; der Text Uhrzeit steht nicht in Anführungszeichen
        locFormat = "Uhrzeit: HH:mm:ss"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, CultureInfo.CurrentCulture))

        'So geht es richtig:
        locFormat = """Uhrzeit:"" HH:mm:ss"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, CultureInfo.CurrentCulture))

        'PM-Anzeige funktioniert nicht bei deutschem...
        locFormat = """Uhrzeit:"" hh:mm:ss tt"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, New CultureInfo("de-DE")))

        '...aber beispielsweise bei amerikanischer Kultureinstellung
        locFormat = """Uhrzeit:"" hh:mm:ss tt"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, New CultureInfo("en-US")))

        'englisches Datumsformat trotz deutscher Kultureinstellung
        locFormat = """Date:"" MM\/dd\/yyyy"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, New CultureInfo("de-DE")))

        'Backslash davor nicht vergessen, sonst:
        locFormat = """Date:"" MM/dd/yyyy"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, New CultureInfo("de-DE")))

        'aber nur so mit englischen Texten:
        locFormat = """Date:"" MMMM, ""the"" dd. yyyy"
        Console.WriteLine("'{0}' : {1}", _
                            locFormat, _
                            locDate.ToString(locFormat, New CultureInfo("en-US")))

        Console.ReadLine()
    End Sub
End Module

Module DateTimeFormatInfoBeispiel
    Sub main()

        'zu verwendenden Wert definieren
        Dim locDate As Date = #12/24/2005 1:12:23 PM#
        'Kultureinstellungen sind deutsch
        Dim locCultureInfo As New CultureInfo("de-DE")
        'Die Einstellungen, die CultureInfo auf Grund der Kultur schon
        'geleistet hat, über nehmen wir in ein DateTimeFormatInfo
        Dim locDateTimeFormatInfo As DateTimeFormatInfo = locCultureInfo.DateTimeFormat

        '...dessen anzuwendende Regeln wir nun genauer spezifizieren können:
        locDateTimeFormatInfo.AMDesignator = "Vormittag"
        locDateTimeFormatInfo.PMDesignator = "Nachmittag"
        Console.WriteLine("Mit deutschen AM/PM-Designatoren: " _
            + locDate.ToString("dd.MM.yyyy hh:mm:ss - tt", locDateTimeFormatInfo))

        '12 Stunden drauf addieren:
        locDate = locDate.AddHours(12)
        Console.WriteLine("Mit deutschen AM/PM-Designatoren: " _
            + locDate.ToString("dd.MM.yyyy hh:mm:ss - tt", locDateTimeFormatInfo))

        Console.ReadLine()

    End Sub
End Module
