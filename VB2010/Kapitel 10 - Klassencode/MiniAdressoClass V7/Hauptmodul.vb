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

        'Die Adressen nach Nachnamen sortieren
        Console.WriteLine()
        Console.Write("Adressen werden nach Namen sortiert ... ")
        AdressenSortieren((Function(k1 As Kontakt, k2 As Kontakt) _
                                String.Compare(k1.Nachname, k2.Nachname)))
        Console.WriteLine("fertig!")
        Console.WriteLine()

        'Die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Die Adressen nach Ortsnamen sortieren
        Console.WriteLine()
        Console.Write("Adressen werden nach Ortsnamen sortiert ... ")
        AdressenSortieren((Function(k1 As Kontakt, k2 As Kontakt) _
                                String.Compare(k1.Ort, k2.Ort)))
        Console.WriteLine("fertig!")
        Console.WriteLine()

        'Und jetzt nochmal die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Warten, bis das Programm beendet ist.
        Console.WriteLine()
        Console.WriteLine("Taste zum Beenden drücken...")
        Console.ReadKey()

    End Sub

    Sub AdressenAusgeben(ByVal von As Integer, ByVal bis As Integer)
        For c As Integer = von To bis
            Console.WriteLine(c.ToString("000") & ": " & Kontakte(c).KontaktText())
        Next
    End Sub

    'Lamda-Funktion nimmt zwei Kontakt-Objekte entgegen und liefert Integer zurück
    Sub AdressenSortieren(ByVal cDel As Func(Of Kontakt, Kontakt, Integer))

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
            'Ist Abbruchkriterium - deswegen herunterzählen
            delta \= 3

            'Shellsort's Kernalgorithmus
            For aeussererZaehler = delta To anzahlElemente - 1
                tempKontakt = Kontakte(aeussererZaehler)

                innererZaehler = aeussererZaehler
                Do
                    'Invoke ist optional! - Es geht auch ohne:
                    If cDel(tempKontakt, Kontakte(innererZaehler - delta)) = 1 OrElse _
                        cDel(tempKontakt, Kontakte(innererZaehler - delta)) = 0 Then Exit Do
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
