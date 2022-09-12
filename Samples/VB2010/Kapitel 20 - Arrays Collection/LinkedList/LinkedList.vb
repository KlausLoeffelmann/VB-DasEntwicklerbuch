Module LinkedList

    Sub Main()
        Dim locLinkedList As New LinkedList(Of Adresse)
        Dim locAdressen As ArrayList = Adresse.ZufallsAdressen(50)
        Dim locAdresse As Adresse = Nothing

        'Acht Adressen an das jeweilige Ende der LinkedList anfügen
        For c As Integer = 0 To 49

            'den 25. merken wir uns für die spätere Suche in der Liste
            If c = 25 Then
                locAdresse = DirectCast(locAdressen(c), Adresse)
            End If
            locLinkedList.AddLast(DirectCast(locAdressen(c), Adresse))
        Next

        Dim locLinkedListNode As LinkedListNode(Of Adresse)

        'Den Knoten finden, der dem 25. Adresseneintrag entsprach.
        locLinkedListNode = locLinkedList.Find(locAdresse)
        Console.WriteLine("Vor " & locLinkedListNode.Value.ToString & " kommt " & _
                          locLinkedListNode.Previous.Value.ToString & _
                          " und danach kommt " & locLinkedListNode.Next.Value.ToString)
        Console.WriteLine()

        'Eine neue Adresse vor dem 25. einfügen:
        Console.WriteLine("Sarah Halek vorher einfügen!")
        locLinkedList.AddBefore(locLinkedListNode, _
                New Adresse("SasiMatch", "Halek", "Sarah", "99999", "Musterhausen"))

        Console.WriteLine()

        'Das Gleiche nochmal ausgeben, es sollte die Änderungen jetzt widerspiegeln.
        Console.WriteLine("Vor " & locLinkedListNode.Value.ToString & " kommt " & _
                          locLinkedListNode.Previous.Value.ToString & _
                          " und danach kommt " & locLinkedListNode.Next.Value.ToString)
        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden")
        Console.ReadKey()
    End Sub

End Module
