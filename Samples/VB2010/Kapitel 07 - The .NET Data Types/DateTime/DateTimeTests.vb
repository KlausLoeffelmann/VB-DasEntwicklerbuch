Imports System.Globalization

Module Module1

    Sub Main()

        Dim Mitternacht As Date = #12:00:00 AM#
        Dim Mittag As Date = #12:00:00 PM#
        Dim Silvester As System.DateTime = #12/31/2004#
        Dim ZeitFürSekt As System.DateTime = #12/31/2004 11:58:00 PM#
        Dim ZeitFürAsperin As System.DateTime = #1/1/2005 11:58:00 AM#

        Dim locDate1 As Date = #3:15:00 PM#
        Dim locDate2 As Date = #4:23:32 PM#
        Dim locTimeSpan As TimeSpan = locDate2.Subtract(locDate1)
        Console.WriteLine("Der Zeitunterschied zwischen {0} und {1} beträgt", _
                          locDate1.ToString("HH:mm:ss"), _
                          locDate2.ToString("HH:mm:ss"))
        Console.WriteLine("{0} Sekunde(n) oder", locTimeSpan.TotalSeconds)
        Console.WriteLine("{0} Minute(n) und {1} Sekunde(n) oder", _
                           Math.Floor(locTimeSpan.TotalMinutes), _
                           locTimeSpan.Seconds)
        Console.WriteLine("{0} Stunde(n), {1} Minute(n) und {2} Sekunde(n) oder", _
                           Math.Floor(locTimeSpan.TotalHours), _
                           locTimeSpan.Minutes, locTimeSpan.Seconds)
        Console.WriteLine("{0} Ticks", _
                           locTimeSpan.Ticks)

        'Console.ReadLine()

        Dim locToParse As Date
        locToParse = Date.Parse("13.12.04") ' OK, deutsche Grundeinstellung wird verarbeitet
        locToParse = Date.Parse("6/7/04")   ' OK, aber deutsch trotz "/" wird angewendet
        locToParse = Date.Parse("13/12/04") ' OK, wie oben
        locToParse = Date.Parse("06.07")    ' OK, wird um Jahreszahl erweitert
        locToParse = Date.Parse("06,07,04") ' OK, Komma ist akzeptabel
        locToParse = Date.Parse("06,07")    ' OK, Komma ist akzeptabel; Jahreszahl wird ergänzt
        'locToParse = Date.Parse("06072004") ' --> Exception: wurde nicht als gültiges Datum erkannt!
        'locToParse = Date.Parse("060705")   ' --> Exception: wurde nicht als gültiges Datum erkannt!
        locToParse = Date.Parse("6,7,4")    ' OK, Komma wird akzeptiert; führende Nullen ergänzt

        locToParse = Date.Parse("14:00")    ' OK, 24-Stundendarstellung wird akzeptiert
        locToParse = Date.Parse("PM 11:00") ' OK, PM darf vorne...
        locToParse = Date.Parse("11:00 PM") ' ...und auch hinter der Zeitangabe stehen
        'locToParse = Date.Parse("12,00 PM") ' --> Exception: wurde nicht als gültiges Datum erkannt!
        'Beide Datum- Zeitkombinationen funktionieren:
        locToParse = Date.Parse("6.7.04 13:12")
        locToParse = Date.Parse("6,7,04 11:13 PM")

        Dim locToParseExact As Date
        Dim locZeitenMuster As String() = {"H,m", "H.m", "ddMMyy", "MM\/dd\/yy"}

        'Funktioniert, ist im Uhrzeitenmuster
        locToParseExact = Date.ParseExact("12,00", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.AllowWhiteSpaces)

        'Funktioniert, ist im Uhrzeitenmuster und "Whitespaces" sind erlaubt
        locToParseExact = Date.ParseExact(" 12 , 00 ", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.AllowWhiteSpaces)

        'Funktioniert nicht, ist zwar im Uhrzeitenmuster es sind aber keine "Whitespaces" erlaubt
        'locToParseExact = Date.ParseExact(" 12 , 00 ", _
        '                    locZeitenMuster, _
        '                    CultureInfo.CurrentCulture, _
        '                    DateTimeStyles.None)

        'Funktioniert, ist im Uhrzeitenmuster
        locToParseExact = Date.ParseExact("1,2", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.None)

        'Funktioniert, ist im Uhrzeitenmuster
        'Das Datum entspricht aber dem 1.1.0001, und wird
        'als Tooltip deswegen nicht mitangezeigt, im Gegensatz
        'zu allen anderen hier gezeigten Beispielen
        locToParseExact = Date.ParseExact("12.2", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.NoCurrentDateDefault)

        'Funktioniert, ist nicht im Uhrzeitenmuster, da hier Sekunden mit im Spiel sind
        'locToParseExact = Date.ParseExact("12,2,00", _
        '                    locZeitenMuster, _
        '                    CultureInfo.CurrentCulture, _
        '                    DateTimeStyles.NoCurrentDateDefault)

        'Funktioniert nicht, ist mit Doppelpunkt nicht im Uhrzeitenmuster
        'locToParseExact = Date.ParseExact("1:20", _
        '                    locZeitenMuster, _
        '                    CultureInfo.CurrentCulture, _
        '                    DateTimeStyles.None)

        'Funktioniert jetzt, da im Zeitenmuster als Datum hinterlegt
        '(drittes Element im String-Array)
        locToParseExact = Date.ParseExact("241205", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.AllowWhiteSpaces)

        'Funktioniert mit Übernahme im englisch-(irisch-)-amerikanischen Format,
        'da durch die Schrägstriche und der vorgegebenen Reihenfolge der Gruppen definiert.
        '(viertes Element im String-Array)
        locToParseExact = Date.ParseExact("12/24/05", _
                            locZeitenMuster, _
                            CultureInfo.CurrentCulture, _
                            DateTimeStyles.AllowWhiteSpaces)
    End Sub

End Module
