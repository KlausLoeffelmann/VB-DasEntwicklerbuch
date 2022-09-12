Module Hauptmodul

    Sub Main()

        'Hier 'mal farbtechnisch was Anderes im Konsolenfenster
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Clear()

        'Eine Adresse mit Parametrisierten Konstruktor angeben:
        Dim AngisKontakt As New Kontakt("Angela", "Wördehoff", _
                                        "99999", "Bahamas")

        'So geht's natürlich ab 2008 auch - das *ersetzt* aber nicht
        'den parametrisierten Konstruktor. Außerdem ist's mehr Tipparbeit.
        Dim LöffelsKontakt As New Kontakt With {.Vorname = "Klaus", _
                                                .Nachname = "Löffelmann", _
                                                .PLZ = "59555", _
                                                .Ort = "Lippstadt"}

    End Sub
End Module
