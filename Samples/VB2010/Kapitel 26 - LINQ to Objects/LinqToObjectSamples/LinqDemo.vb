Imports System.IO
Imports System.IO.IsolatedStorage
Module LinqDemo

    Private Const ELEMENTCOUNT = 200

    Private adrListe As List(Of Kontakt) = Kontakt.ZufallsKontakte(ELEMENTCOUNT)
    Private artListe As List(Of Artikel) '= Artikel.Zufallsartikel(adrListe)

    Sub Main()
        Test()
        'LINQAbfragenAufbau()
        'KombinierteKomplexeAbfrage()
        'SelectSpeedCompare()
        'SerialLinqsCompare()
        'Auflistungsvereinigung()
        'JoinDemo()
        'GroupByDemo()
        'GroupByJoinedCombined()
        'GroupJoin()
        'AggregateDemo()
        'JoinAggregateDemo()
        'PerformanceTest()
        'AsParallel()
        Console.ReadKey()

    End Sub

    Sub Test()

        Dim abfrage As IEnumerable(Of Kontakt)

        Dim meineKunden = Kontakt.ZufallsKontakte(100)

        abfrage = From kundenItem In meineKunden
                  Where kundenItem.Nachname.StartsWith("L")
                  Order By kundenItem.Vorname Descending

        For Each kundenItem In abfrage
            Console.WriteLine(kundenItem.ToString)
        Next



    End Sub

















    Sub LINQAbfragenAufbau()

        Console.WriteLine("Ergebnisliste 1:")
        Console.WriteLine("----------------")

        Dim ergebnisListe = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname
                            Select KontaktId = adrElement.ID,
                                   adrElement.Nachname,
                                   adrElement.Vorname,
                                   PlzOrtKombi = adrElement.PLZ & " " & adrElement.Ort
                            Where KontaktId > 50 And KontaktId < 100 And
                                    Nachname Like "L*"

        For Each ergebnisItem In ergebnisListe
            With ergebnisItem
                Console.WriteLine(.KontaktId & ": " &
                                  .Nachname & ", " & .Vorname &
                                  " - " & .PlzOrtKombi)
            End With
        Next

        Console.WriteLine()
        Console.WriteLine("Ergebnisliste 2:")
        Console.WriteLine("----------------")


        Dim ergebnisListe2 = From adrElement In adrListe
                    Where adrElement.ID > 50 And adrElement.ID < 100 And
                            adrElement.Nachname Like "L*"
                    Select KontaktId = adrElement.ID,
                           adrElement.Nachname,
                           adrElement.Vorname,
                           PlzOrtKombi = adrElement.PLZ & " " & adrElement.Ort
                    Order By Nachname, Vorname

        For Each ergebnisItem In ergebnisListe2
            With ergebnisItem
                Console.WriteLine(.KontaktId & ": " &
                                  .Nachname & ", " & .Vorname &
                                  " - " & .PlzOrtKombi)
            End With
        Next
    End Sub

    Sub KombinierteKomplexeAbfrage()

        Dim adrListeGruppiert = From adrElement In adrListe
                        Join artElement In artListe
                        On adrElement.ID Equals artElement.IDGekauftVon
                        Select adrElement.ID, adrElement.Nachname,
                               adrElement.Vorname, adrElement.PLZ,
                               artElement.ArtikelNummer, artElement.ArtikelName,
                               artElement.Anzahl, artElement.Einzelpreis,
                               Postenpreis = artElement.Anzahl * artElement.Einzelpreis
                        Order By Nachname, ArtikelNummer
                        Where (PLZ > "0" And PLZ < "50000")
                        Group ArtikelNummer, ArtikelName,
                              Anzahl, Einzelpreis, Postenpreis
                        By ID, Nachname, Vorname
                        Into Artikelliste = Group, AnzahlArtikel = Count(),
                             Gesamtpreis = Sum(Postenpreis)
                        Where Gesamtpreis > 1000


        For Each KundenItem In adrListeGruppiert
            With KundenItem
                Console.WriteLine(.ID & ": " & .Nachname & ", " & .Vorname & " - " & .AnzahlArtikel & " Artikel zu insgesamt " & .Gesamtpreis & " Euro")
                Console.WriteLine("     Details:")
                For Each ArtItem In KundenItem.Artikelliste
                    With ArtItem
                        Console.WriteLine("     " & .ArtikelNummer & ": " & .ArtikelName &
                                          "(" & .Anzahl & " Stück für insgesamt " &
                                          (.Einzelpreis * .Anzahl).ToString("#,##0.00") & " Euro)")
                    End With
                Next
            End With

        Next
        Console.ReadKey()
    End Sub

    Sub SelectSpeedCompare()

        Dim sw = Stopwatch.StartNew
        Console.WriteLine("Starte Test")
        sw.Start()
        Dim ergebnisListe = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname
                            Select KontaktId = adrElement.ID,
                                   adrElement.Nachname,
                                   adrElement.Vorname,
                                   PlzOrtKombi = adrElement.PLZ & " " & adrElement.Ort

        sw.Stop()
        Dim ersteAnzahl = ergebnisListe.Count
        Dim dauer1 = sw.ElapsedMilliseconds

        sw.Reset()
        sw.Start()
        Dim ergebnisListe2 = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname

        Dim zweiteAnzahl = ergebnisListe2.Count
        sw.Stop()
        Dim dauer2 = sw.ElapsedMilliseconds

        Console.WriteLine("Abfragedauer mit Select: " & dauer1 & " für " & ersteAnzahl & " Ergebniselemente.")
        Console.WriteLine("Abfragedauer ohne Select: " & dauer2 & " für " & zweiteAnzahl & " Ergebniselemente.")
    End Sub

    Sub SerialLinqsCompare()

        Dim sw = Stopwatch.StartNew
        Console.WriteLine("Starte Test")
        sw.Start()
        Dim ergebnisListe = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname

        Dim ergebnisListe2 = From adrElement In ergebnisListe
                            Where adrElement.Nachname Like "L*"

        ergebnisListe2 = From adrElement In ergebnisListe2
                            Where adrElement.ID > 50 And adrElement.ID < 200

        Dim ersteAnzahl = ergebnisListe2.Count
        sw.Stop()
        Console.WriteLine("Starte Test2")
        Dim dauer1 = sw.ElapsedMilliseconds

        sw.Reset()
        sw.Start()

        Dim ergebnisListe3 = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname
                            Where adrElement.Nachname Like "L*" And
                            adrElement.ID > 50 And adrElement.ID < 200

        Dim zweiteAnzahl = ergebnisListe3.Count
        sw.Stop()
        Dim dauer2 = sw.ElapsedMilliseconds

        Console.WriteLine("Abfragedauer serielle Abfrage: " & dauer1 & " für " & ersteAnzahl & " Ergebniselemente.")
        Console.WriteLine("Abfragedauer kombinierte Abfrage: " & dauer2 & " für " & zweiteAnzahl & " Ergebniselemente.")

        Console.WriteLine("Elemente der seriellen Abfrage: " & ergebnisListe2.Count)
    End Sub

    Sub Auflistungsvereinigung()

        Dim ergebnisliste = From adrElement In adrListe, artElement In artListe
        'Where adrElement.ID = artElement.IDGekauftVon

        For Each element In ergebnisliste

            With (element)
                Console.WriteLine(.adrElement.ID & ": " & .adrElement.Nachname &
                                  ", " & .adrElement.Vorname & ": " &
                                  .artElement.IDGekauftVon & ": " & .artElement.ArtikelName)
            End With
        Next
    End Sub

    Sub JoinDemo()
        Dim ergebnisliste = From adrElement In adrListe
                            Join artElement In artListe
                            On adrElement.ID Equals artElement.IDGekauftVon

        For Each element In ergebnisliste
            With element
                Console.WriteLine(.adrElement.ID & ": " & .adrElement.Nachname &
                                  ", " & .adrElement.Vorname & ": " &
                                  .artElement.IDGekauftVon & ": " & .artElement.ArtikelName)
            End With
        Next
    End Sub

    Sub GroupByDemo()
        Dim ergebnisliste = From adrElement In adrListe
                            Group By adrElement.Nachname Into Kontaktliste = Group
                            Order By Nachname

        For Each element In ergebnisliste
            With element
                Console.WriteLine(element.Nachname)
                For Each Kontakt In element.Kontaktliste
                    With Kontakt
                        Console.WriteLine(.ID & ": " & .Nachname & ", " & .Vorname)
                    End With
                Next
                Console.WriteLine()
            End With
        Next
    End Sub

    Sub GroupByJoinedCombined()
        Dim ergebnisliste = From adrElement In adrListe
                            Join artElement In artListe
                            On adrElement.ID Equals artElement.IDGekauftVon
                            Group artElement.IDGekauftVon, Artikelnummer = artElement.ArtikelNummer,
                                artElement.ArtikelName
                            By artElement.IDGekauftVon, adrElement.Nachname, adrElement.Vorname
                            Into Artikelliste = Group, AnzahlArtikel = Count() Order By Nachname

        For Each kontaktElement In ergebnisliste
            With kontaktElement

                Console.WriteLine(.IDGekauftVon & ": " & .Nachname & ", " & .Vorname)
                For Each Artikel In .Artikelliste
                    With Artikel
                        Console.WriteLine("   " & .Artikelnummer & ": " & .ArtikelName)
                    End With
                Next
                Console.WriteLine()
            End With
        Next
    End Sub

    Sub GroupJoin()
        Dim ergebnisliste = From adrElement In adrListe
                            Group Join artElement In artListe
                            On adrElement.ID Equals artElement.IDGekauftVon Into Artikelliste = Group

        For Each kontaktElement In ergebnisliste
            With kontaktElement

                Console.WriteLine(.adrElement.ID & ": " &
                                  .adrElement.Nachname & ", " &
                                  .adrElement.Vorname)
                For Each Artikel In .Artikelliste
                    With Artikel
                        Console.WriteLine("   " & .ArtikelNummer & ": " & .ArtikelName)
                    End With
                Next
                Console.WriteLine()
            End With
        Next
    End Sub

    Sub AggregateDemo()

        Dim scheinbarerUmsatz = Aggregate artElement In artListe
                           Into Summe = Sum(artElement.Einzelpreis)
        Console.WriteLine("Scheinbar beträgt der Umsatz {0:#,##0.00} Euro", scheinbarerUmsatz)

        Console.ReadKey()
        Console.Clear()

        Dim gesamtUmsatz = Aggregate artElement In artListe
                           Let Artikelumsatz = artElement.Einzelpreis * artElement.Anzahl
                           Into Summe = Sum(Artikelumsatz)
        Console.WriteLine("Der Umsatz beträgt {0:#,##0.00} Euro", gesamtUmsatz)
        Console.ReadKey()
        Console.Clear()

        Dim mehrereInfos = Aggregate artElement In artListe
                           Let Artikelumsatz = artElement.Einzelpreis * artElement.Anzahl
                           Into Summe = Sum(Artikelumsatz),
                                        Minimalpreis = Min(artElement.Einzelpreis),
                                        MaximalPreis = Max(artElement.Einzelpreis)
        Console.WriteLine("Der Umsatz beträgt {0:#,##0.00} Euro" & vbNewLine &
                          "Minimal- und Maximalpreis jeweils " &
                          "{1:#,##0.00} und {2:#,##0.00} Euro",
                          mehrereInfos.Summe, mehrereInfos.Minimalpreis,
                         mehrereInfos.MaximalPreis)

    End Sub

    Sub JoinAggregateDemo()
        Dim ergebnisListe = From adrElement In adrListe
                            Group Join artElement In artListe
                            On adrElement.ID Equals artElement.IDGekauftVon
                            Into JoinedList = Group,
                            KundenUmsatz = Sum(artElement.Einzelpreis * artElement.Anzahl)
                            Order By KundenUmsatz Descending
                            Take 10

        For Each item In ergebnisListe
            With item.adrElement
                Console.WriteLine(.ID & ": " & .Nachname & ", " &
                                  .Vorname & " --- Umsatz:" &
                                  item.KundenUmsatz.ToString("#,##0.00") &
                                  " Euro")
            End With
        Next
    End Sub

    Sub SimpleQuery()

        Dim ergebnisListe = (From adrElememnt In adrListe
                          Where adrElememnt.Nachname > "L").ToList()
        If ergebnisListe IsNot Nothing Then
            ergebnisListe.ForEach(Sub(value)
                                      Console.WriteLine(value.ToString)
                                  End Sub)
        End If




    End Sub

    Sub PerformanceTest()

        Console.WriteLine("Abfrage durchführen:")
        Console.WriteLine("--------------------")

        Dim sw = Stopwatch.StartNew
        Dim ergebnisListe = From adrElement In adrListe
                            Order By adrElement.Nachname, adrElement.Vorname
                            Where adrElement.ID > 50 And adrElement.ID < 100 And
                                    adrElement.Nachname Like "L*"

        Dim liste = ergebnisListe.ToList
        sw.Stop()
        Console.WriteLine("Die Abfrage benötigte: " & sw.ElapsedMilliseconds.ToString & " Millisekunden.")
    End Sub


    Sub AsParallel()

        Dim sw = Stopwatch.StartNew
        Console.WriteLine("Starte Abfrage 1 (as Parallel)")
        Dim ergebnisListe1 = From adrElement In adrListe.AsParallel
                            Where adrElement.Nachname Like "L*"
                            Order By adrElement.Nachname, adrElement.Vorname

        Dim ersteList = ergebnisListe1.ToList
        Dim lastElement = ersteList(ersteList.Count - 1)
        Console.WriteLine("Ende Abfrage 1")
        Console.WriteLine()
        sw.Stop()
        Dim dauer1 = sw.ElapsedMilliseconds
        sw.Reset()

        'List neu aufbauen
        adrListe = Kontakt.ZufallsKontakte(ELEMENTCOUNT)
        sw.Start()
        Console.WriteLine("Starte Abfrage 2 (seriell)")

        Dim ergebnisListe2 = From adrElement In adrListe
                            Where adrElement.Nachname Like "L*"
                            Order By adrElement.Nachname, adrElement.Vorname

        Dim zweiteList = ergebnisListe2.ToList
        sw.Stop()
        Dim dauer2 = sw.ElapsedMilliseconds

        Console.WriteLine("Abfragedauer parallele Abfrage: " & dauer1 & " für " & ersteList.Count & " Ergebniselemente.")
        Console.WriteLine("Abfragedauer serielle Abfrage: " & dauer2 & " für " & zweiteList.Count & " Ergebniselemente.")
    End Sub

End Module
