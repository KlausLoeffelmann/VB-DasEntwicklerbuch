Module Hauptmodul

    Dim Kontakte(0 To 100) As Kontakt

    Sub Main()

        'Hier 'mal farbtechnisch was Anderes im Konsolenfenster
        Console.BackgroundColor = ConsoleColor.Red
        Console.ForegroundColor = ConsoleColor.Black
        Console.Clear()

        'Zufallsadressen generieren
        Console.Write("Zufallsadressen werden generiert ... ")
        ZufallsAdressenGenerieren()
        Console.WriteLine("fertig!")

        'Die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Die Adressen sortieren
        Console.WriteLine()
        Console.Write("Adressen werden sortiert ... ")
        AdressenSortieren()
        Console.WriteLine("fertig!")
        Console.WriteLine()

        'Und jetzt nochmal die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Warten, bis das Programm beendet ist.
        Console.WriteLine()
        Console.WriteLine("Taste zum Beenden drücken...")
        Console.ReadKey()

        'Hier ist Schluss, sonst rappelts in die Exception-Demo
        Exit Sub

        'Demo für eine NullReferenceException
        Dim k1 As New Kontakt With { _
            .Vorname = "Angela", _
            .Nachname = "Wördehoff", _
            .Ort = "Dresden", _
            .PLZ = "11111"}

        Dim k2 As Kontakt

        'Das geht ...
        Debug.Print(k1.KontaktText)

        '...voll daneben
        Debug.Print(k2.KontaktText)

        'Shared Access Test
        'Dim s As String = k1.EllipseString("Dies ist die abzuschneidende Zeichenkette", 20)

    End Sub

    Sub AdressenAusgeben(ByVal von As Integer, ByVal bis As Integer)
        For c As Integer = von To bis
            Console.WriteLine(c.ToString("000") & ": " & Kontakte(c).KontaktText())
        Next
    End Sub

    Sub AdressenSortieren()

        Dim anzahlElemente As Integer = 101

        Dim aeussererZaehler As Integer
        Dim innererZaehler As Integer
        Dim delta As Integer

        Dim tempKontakt As Kontakt

        delta = 1

        'Größten Wert der Distanzfolge ermitteln
        Do
            delta = 3 * delta + 1
        Loop Until delta > anzahlElemente

        Do
            'späteres Abbruchkriterium - wieder kleiner werden lassen
            delta \= 3

            'Shellsort's Kernalgorithmus
            For aeussererZaehler = delta To anzahlElemente - 1
                tempKontakt = Kontakte(aeussererZaehler)

                innererZaehler = aeussererZaehler
                Do
                    If tempKontakt.Nachname >= Kontakte(innererZaehler - delta).Nachname Then Exit Do
                    Kontakte(innererZaehler) = Kontakte(innererZaehler - delta)

                    innererZaehler = innererZaehler - delta
                    If (innererZaehler <= delta) Then Exit Do
                Loop
                Kontakte(innererZaehler) = tempKontakt
            Next
        Loop Until delta = 0
    End Sub

    Public Sub ZufallsAdressenGenerieren()

        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locStraßen As String() = {"Musterstraße", "Alter Postweg", "Kirchgasse", "Buchweg", _
                                    "Kurgartenweg", "Wiedenbrückerstr.", "Edison Straße", _
                                    "Weidering", "Lange Straße", "Kurze Straße", "Mühlweg", _
                                    "Kahle Gasse"}

        Dim locVornamen As String() = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}
        Dim locStädte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn im Zillerthal am Main", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 0 To 100

            Dim adr As New Kontakt

            adr.Nachname = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            adr.Vorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            adr.Ort = locStädte(locRandom.Next(locStädte.Length - 1))
            adr.PLZ = locRandom.Next(99999).ToString("00000")
            Kontakte(i) = adr
        Next
    End Sub
End Module
