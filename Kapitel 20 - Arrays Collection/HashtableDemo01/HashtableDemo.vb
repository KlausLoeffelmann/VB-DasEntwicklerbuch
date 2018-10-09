Module HashtableDemo

    Sub Main()

        ''Für die weiteren Beispiele kommentieren Sie die folgenden drei Zeilen aus.
        'AdressenTesten()
        'Console.ReadLine()
        'Return

        Dim locAnzahlAdressen As Integer = 1000000
        Dim locZugriffsElemente As Integer = 2
        Dim locMessungen As Integer = 3
        Dim locZugriffe As Integer = 1000000
        Dim locVorlageAdressen As ArrayList
        Dim locAdressen As New Hashtable
        Dim locTestKeys(locZugriffsElemente) As String
        Dim locRandom As New Random(Now.Millisecond)

        'Dim locAnzahlAdressen As Integer = 1000000
        'Dim locZugriffsElemente As Integer = 25
        'Dim locMessungen As Integer = 3
        'Dim locZugriffe As Integer = 1000000
        'Dim locVorlageAdressen As ArrayList
        'Dim locAdressen As New Hashtable(100000, 0.1)
        'Dim locTestKeys(locZugriffsElemente) As String
        'Dim locZeitmesser As New HighSpeedTimeGauge
        'Dim locRandom As New Random(Now.Millisecond)


        'Warten auf Startschuss
        Console.WriteLine("Drücken Sie Return, um zu beginnen")
        Console.ReadLine()

        'Viele Adressen erzeugen:
        Console.Write("Erzeugen von {0} zufälligen Adresseneinträgen...", locAnzahlAdressen)
        Dim locZeitmesser = Stopwatch.StartNew
        locVorlageAdressen = adresse.ZufallsAdressen(locAnzahlAdressen)
        locZeitmesser.Stop()
        Console.WriteLine("fertig nach {0} ms", locZeitmesser.ElapsedMilliseconds)
        locZeitmesser.Reset()

        'Aufbauen der Hashtable
        Console.Write("Aufbauen der Hashtable mit zufälligen Adresseneinträgen...", locAnzahlAdressen)
        locZeitmesser.Start()
        For Each adresse As Adresse In locVorlageAdressen
            locAdressen.Add(adresse.Matchcode, adresse)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("fertig nach {0} ms", locZeitmesser.ElapsedMilliseconds)
        locZeitmesser.Reset()

        '51 zufällige Adressen 'rauspicken
        For i As Integer = 0 To locZugriffsElemente
            locTestKeys(i) = DirectCast(locVorlageAdressen(locRandom.Next(locAnzahlAdressen)), Adresse).Matchcode
        Next

        Dim locTemp As Object
        Dim locTemp2 As Object = Nothing

        'Zugreifen und Messen, wie lange das dauert
        'Das ganze 5 Mal, um die Messung zu bestätigen
        For z As Integer = 1 To locMessungen
            Console.WriteLine()
            Console.WriteLine("{0}. Messung:", z)
            For i As Integer = 0 To locZugriffsElemente
                Console.Write("{0} Zugriffe auf: {1} in ", locZugriffe, locTestKeys(i))
                locTemp = locTestKeys(i)
                locZeitmesser.Start()
                For j As Integer = 1 To locZugriffe
                    locTemp2 = locAdressen(locTemp)
                Next j
                locZeitmesser.Stop()
                locTemp = locTemp2.GetType
                Console.WriteLine("{0} ms", locZeitmesser.ElapsedMilliseconds)
                locZeitmesser.Reset()
            Next

            'Zugriff auf Arraylist für Vergleich
            For i As Integer = 0 To locZugriffsElemente
                Console.Write("{0} Zugriffe auf ArrayList-Element in ", locZugriffe)
                locZeitmesser.Start()
                For j As Integer = 1 To locZugriffe
                    locTemp2 = locVorlageAdressen(0)
                Next j
                locZeitmesser.Stop()
                locTemp = locTemp2.GetType
                Console.WriteLine("{0} ms", locZeitmesser.ElapsedMilliseconds)
                locZeitmesser.Reset()
            Next

        Next

        Console.ReadLine()

    End Sub

    Sub AdressenTesten()

        '15 zufällige Adressen erzeugen
        Dim locDemoAdressen As ArrayList = Adresse.ZufallsAdressen(15)

        'Adressen im Konsolenfenster ausgeben
        Console.WriteLine("Liste mit zufällig erzeugten Personendaten")
        Console.WriteLine(New String("="c, 30))
        Adresse.AdressenAusgeben(locDemoAdressen)

    End Sub

End Module


