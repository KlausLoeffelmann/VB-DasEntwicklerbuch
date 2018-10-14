Module mdlMain

    Sub Main()
        Dim locListe As New DynamicList
        locListe.Add(123.32)
        locListe.Add(126.32)
        locListe.Add(124.52)
        locListe.Add(29.99)
        locListe.Add(13.54)
        'Der wird Probleme machen!
        locListe.Add(#12/31/2008 4:00:00 PM#)
        locListe.Add(43.32)
        For Each locItem As Double In locListe
            Console.WriteLine(locItem)
        Next

        Dim locDoubleListe As New DynamicList(Of Double)
        locDoubleListe.Add(123.32)
        locDoubleListe.Add(126.32)
        locDoubleListe.Add(124.52)
        'Date geht nicht:
        'locDoubleListe.Add(#10/18/2005 3:20:00 PM#)

        Dim locDateListe As New DynamicList(Of Date)
        locDateListe.Add(#12/31/2005 4:00:00 PM#)
        locDateListe.Add(#11/24/2005 6:20:00 PM#)
        locDateListe.Add(#10/18/2005 3:20:00 PM#)
        'Double geht nicht:
        'locDateListe.Add(124.52)

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module
