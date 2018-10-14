Module mdlMain

    Sub Main()
        SimpleTest()
    End Sub

    Sub SimpleTest()

        Dim locKC As New KeyedCollection
        'Hinzufügen ohne Key
        locKC.Add("A Klaus Löffelmann")
        'Hinzufügen mit Key
        locKC.Add("B Uwe Thiemann", "BUT")
        locKC.Add("C Ute Ademmer", "CUA")
        locKC.Add("A Klaus Löffelmann")
        locKC.Add("E Klaus Löffelmann", "EKL")
        'Einfügen vor und hinter einem Objekt
        locKC.InsertBefore("BUT", "Before BUT", "BUTBefore")
        locKC.InsertAfter("BUT", "After BUT", "BUTAfter")
        'Einfügen über Index
        locKC.Insert(locKC.Count, "Last Item", "LIT")
        'Entfernen mit Key
        locKC.RemoveByKey("BUT")
        'Entfernen mit index
        locKC.RemoveAt(0)
        'Entfernen mit Value (Vergleich über EQuals)
        locKC.Remove("A Klaus Löffelmann")
        PrintItems(locKC)

        'Positions- und Elementsuche
        Console.WriteLine(locKC.IndexOf("C Ute Ademmer"))
        Console.WriteLine(locKC.IndexOfKey("CUA"))
        'Einträge suchen, die nicht vorhanden sind
        Console.WriteLine(locKC.IndexOf("C Klaus Löffelmann"))
        Console.WriteLine(locKC.IndexOfKey("ZZZ"))

        'Elemente ändern:
        locKC(1) = "geänderter Eintrag"
        locKC("EKL") = "geänderter Eintrag"
        Console.WriteLine(New String("="c, 50))
        PrintItems(locKC)

        Console.ReadLine()
    End Sub

    Sub PrintItems(ByVal keyedCollection As KeyedCollection)
        For Each Item As Object In keyedCollection
            Console.WriteLine(Item.ToString)
        Next
    End Sub


End Module

