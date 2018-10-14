Module mdlMain

    Sub Main()
        '"Men�" auf den Bildschirm zaubern:
        Console.WriteLine("M�chten Sie Daten erfassen und speichern (1)")
        Console.WriteLine("oder Daten laden und anzeigen (2)?  ")
        Console.Write("Ihre Auswahl  :")

        'Auswahl einlesen
        Dim locKey As String = Console.ReadLine()

        'Daten sollen erfasst werden
        If locKey = "1" Then

            Dim locAnzPersonen As Integer
            Dim locName, locVorname As String
            Dim locSoapWriter As SoapSerializer

            Console.Write("Wieviele Daten m�chten Sie eingeben?  :")
            locAnzPersonen = Integer.Parse(Console.ReadLine())
            If locAnzPersonen = 0 Then
                Exit Sub
            End If

            'Serializer vorbereiten
            locSoapWriter = New SoapSerializer

            'zum Schreiben �ffnen
            locSoapWriter.OpenForWriting("C:\Test.XML", True)

            'Anzahl der Datens�tze abspeichern
            locSoapWriter.WriteObject(locAnzPersonen)

            'Soviele Personen einlesen, wie zuvor eingegeben
            For locCount As Integer = 1 To locAnzPersonen
                Console.WriteLine()
                Console.WriteLine("-----------------------------------")
                Console.WriteLine("Eingabe der {0}. Person", locCount)
                Console.Write("Nachname: ")
                locName = Console.ReadLine
                Console.Write("Vorname: ")
                locVorname = Console.ReadLine

                'In das Objekt �bertragen und abspeichern
                Dim locData As New Dataset(locVorname, locName)
                locSoapWriter.WriteObject(locData)
            Next

            'Das kann 'mal schonmal vergessen!!!
            'locSoapWriter.Close()

            'Der umgekehrte Weg: Die Daten werden geladen
        Else

            Dim locAnzPersonen As Integer
            Dim locData As Dataset
            Dim locSoapReader As SoapSerializer

            'Deserializer vorbereiten
            locSoapReader = New SoapSerializer

            'zum Lesen �ffnen
            locSoapReader.OpenForReading("C:\Test.XML")

            'Anzahl der Datens�tze lesen und
            'zur�ckboxen von Object zu Wertetyp Integer
            locAnzPersonen = Convert.ToInt32(locSoapReader.ReadObject())

            'Soviele Personen-Datens�tze lesen, wie urspr�nglich erfasst
            For locCount As Integer = 1 To locAnzPersonen
                'Deserialisieren und in den alten Objekttyp zur�ckwandeln
                locData = DirectCast(locSoapReader.ReadObject(), Dataset)
                'Daten ausgeben
                Console.WriteLine(locData.ToString)
            Next

            'So geht es auch:
            'locSoapReader.Dispose()

        End If
    End Sub

End Module

<Serializable()> _
Class Dataset

    Private myFirstName As String
    Private myLastName As String

    Sub New(ByVal FirstName As String, ByVal LastName As String)
        myFirstName = FirstName
        myLastName = LastName
    End Sub

    Overrides Function ToString() As String
        Return myLastName & ", " & myFirstName
    End Function

End Class
