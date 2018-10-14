Module mdlMain

    Sub Main()
        SimpleTest()
    End Sub

    Sub SimpleTest()

        Dim locKC As New KeyedCollection
        'Hinzuf�gen ohne Key
        locKC.Add("A Klaus L�ffelmann")
        'Hinzuf�gen mit Key
        locKC.Add("B Uwe Thiemann", "BUT")
        locKC.Add("C Ute Ademmer", "CUA")
        locKC.Add("A Klaus L�ffelmann")
        locKC.Add("E Klaus L�ffelmann", "EKL")
        'Einf�gen vor und hinter einem Objekt
        locKC.InsertBefore("BUT", "Before BUT", "BUTBefore")
        locKC.InsertAfter("BUT", "After BUT", "BUTAfter")
        'Einf�gen �ber Index
        locKC.Insert(locKC.Count, "Last Item", "LIT")
        'Entfernen mit Key
        locKC.RemoveByKey("BUT")
        'Entfernen mit index
        locKC.RemoveAt(0)
        'Entfernen mit Value (Vergleich �ber EQuals)
        locKC.Remove("A Klaus L�ffelmann")
        PrintItems(locKC)

        'Positions- und Elementsuche
        Console.WriteLine(locKC.IndexOf("C Ute Ademmer"))
        Console.WriteLine(locKC.IndexOfKey("CUA"))
        'Eintr�ge suchen, die nicht vorhanden sind
        Console.WriteLine(locKC.IndexOf("C Klaus L�ffelmann"))
        Console.WriteLine(locKC.IndexOfKey("ZZZ"))

        'Elemente �ndern:
        locKC(1) = "ge�nderter Eintrag"
        locKC("EKL") = "ge�nderter Eintrag"
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

