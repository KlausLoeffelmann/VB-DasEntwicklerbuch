Module HashtableDemo

    Sub Main()

        'AdressenTesten()
        'Console.ReadLine()
        'Return
        'Dim locAnzahlAdressen As Integer = 1000000
        'Dim locZugriffsElemente As Integer = 2
        'Dim locMessungen As Integer = 3
        'Dim locZugriffe As Integer = 1000000
        'Dim locVorlageAdressen As ArrayList
        'Dim locAdressen As New Hashtable
        'Dim locTestKeys(locZugriffsElemente) As String
        'Dim locZeitmesser As New HighSpeedTimeGauge
        'Dim locRandom As New Random(Now.Millisecond)

        Dim locAnzahlAdressen As Integer = 1000000
        Dim locZugriffsElemente As Integer = 50
        Dim locMessungen As Integer = 5
        Dim locZugriffe As Integer = 1000000
        Dim locVorlageAdressen As ArrayList
        Dim locAdressen As New Hashtable(100000, 0.1)
        Dim locTestKeys(locZugriffsElemente) As AdressenKey
        Dim locZeitmesser As New HighSpeedTimeGauge
        Dim locRandom As New Random(Now.Millisecond)


        'Warten auf Startschuss
        Console.WriteLine("Drücken Sie Return, um zu beginnen", locZeitmesser.DurationInMilliSeconds)
        Console.ReadLine()

        'Viele Adressen erzeugen:
        Console.Write("Erzeugen von {0} zufälligen Adresseneinträgen...", locAnzahlAdressen)
        locZeitmesser.Start()
        locVorlageAdressen = adresse.ZufallsAdressen(locAnzahlAdressen)
        locZeitmesser.Stop()
        Console.WriteLine("fertig nach {0} ms", locZeitmesser.DurationInMilliSeconds)
        locZeitmesser.Reset()

        'Aufbauen der Hashtable
        Console.Write("Aufbauen der Hashtable mit zufälligen Adresseneinträgen...", locAnzahlAdressen)
        locZeitmesser.Start()
        For Each adresse As Adresse In locVorlageAdressen
            'Änderung: Nicht den String, sondern ein Key-Objekt verwenden
            locAdressen.Add(New AdressenKey(adresse.Matchcode), adresse)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("fertig nach {0} ms", locZeitmesser.DurationInMilliSeconds)
        locZeitmesser.Reset()

        '51 zufällige Adressen 'rauspicken.
        'Anderung: Die Key werden abgespeichert, nicht der Matchcode
        For i As Integer = 0 To locZugriffsElemente
            locTestKeys(i) = New AdressenKey( _
                DirectCast(locVorlageAdressen(locRandom.Next(locAnzahlAdressen)), Adresse).Matchcode)
        Next

        'Änderung: Kein Object mehr, sondern direkt ein AdressenKey
        Dim locTemp As AdressenKey
        Dim locTemp2, locTemp3 As Object


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
                locTemp3 = locTemp2.GetType
                Console.WriteLine("{0} ms", locZeitmesser.DurationInMilliSeconds)
            Next

            'Zugriff auf Arraylist für Vergleich
            For i As Integer = 0 To locZugriffsElemente
                Console.Write("{0} Zugriffe auf ArrayList-Element in ", locZugriffe)
                locZeitmesser.Start()
                For j As Integer = 1 To locZugriffe
                    locTemp2 = locVorlageAdressen(0)
                Next j
                locZeitmesser.Stop()
                locTemp3 = locTemp2.GetType
                Console.WriteLine("{0} ms", locZeitmesser.DurationInMilliSeconds)
            Next

        Next
        Console.ReadLine()

        Return

        'Iterieren durch die Hashtable
        For Each locDE As DictionaryEntry In locAdressen
            'in unserem Beispiel für den Key
            Dim locAdressenKey As AdressenKey = DirectCast(locDE.Key, AdressenKey)
            'in unserem Beispiel für das Objekte
            Dim locAdresse As Adresse = DirectCast(locDE.Value, Adresse)
        Next


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




