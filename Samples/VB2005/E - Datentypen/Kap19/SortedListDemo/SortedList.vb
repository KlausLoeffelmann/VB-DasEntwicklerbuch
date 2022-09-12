Module SortedListDemo

    Sub Main()

        'Für den Tests des weiteren Beispiels, nehmen Sie die folgende Auskommentierung zurück.
        'SortedByFieldDemo()
        'Return

        Dim locZufallsAdressen As ArrayList = Adresse.ZufallsAdressen(6)
        Dim locAdressen As New SortedList

        Console.WriteLine("Ursprungsanordnung:")
        For Each locAdresse As Adresse In locZufallsAdressen
            Console.WriteLine(locAdresse)
            locAdressen.Add(locAdresse.Matchcode, locAdresse)
        Next

        'Zugriff per Index:
        Console.WriteLine()
        Console.WriteLine("Zugriff per Index:")
        For i As Integer = 0 To locAdressen.Count - 1
            Console.WriteLine(locAdressen.GetByIndex(i).ToString)
        Next

        Console.WriteLine()
        Console.WriteLine("Zugriff per Index:")
        'Zugriff per Enumerator
        For Each locDE As DictionaryEntry In locAdressen
            Console.WriteLine(locDE.Value.ToString)
        Next
        Console.ReadLine()
    End Sub

    Sub SortedByFieldDemo()
        Dim locZufallsAdressen As ArrayList = Adresse.ZufallsAdressen(15)
        Dim locAdressen As New SortedList
        Dim locAdressenKey As AdressenKey

        Console.WriteLine("Ursprungsanordnung:")
        For Each locAdresse As Adresse In locZufallsAdressen
            locAdressenKey = New AdressenKey(locAdresse.Matchcode, locAdresse.Name)
            locAdressen.Add(locAdressenKey, locAdresse)
            Console.WriteLine(locAdresse)
        Next

        Console.WriteLine()
        Console.WriteLine("Zugriff per Index:")
        'Zugriff per Enumerator
        For Each locDE As DictionaryEntry In locAdressen
            Console.WriteLine(locDE.Value.ToString)
        Next
        Console.ReadLine()
    End Sub

End Module
