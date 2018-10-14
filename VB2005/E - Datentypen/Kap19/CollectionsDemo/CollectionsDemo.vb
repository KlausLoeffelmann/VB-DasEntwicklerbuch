Imports System.IO

Module CollectionsDemo

    Sub Main()
        ArrayListDemo()

        'Weitere Demo; einfach Auskommentierung zum Testen zurücknehmen.
        'QueueDemo()
        'StackDemo()
    End Sub

    Sub ArrayListDemo()

        Dim locMännerNamen As String() = {"Jürgen", "Uwe", "Klaus", "Christian", "José"}
        Dim locFrauenNamen As New ArrayList
        Dim locNamen As New ArrayList

        'ArrayList aus vorhandenem Array/Arraylist erstellen
        locNamen = New ArrayList(locMännerNamen)

        'ArrayList mit Add definieren
        locFrauenNamen.Add("Ute") : locFrauenNamen.Add("Miriam")
        locFrauenNamen.Add("Mellanie") : locFrauenNamen.Add("Anja")
        locFrauenNamen.Add("Stephanie") : locFrauenNamen.Add("Heidrun")

        'Arraylist einer anderen Arraylist hinzufügen:
        locNamen.AddRange(locFrauenNamen)

        'Arraylist in eine Arraylist einfügen
        Dim locHundenamen As String() = {"Hasso", "Bello", "Wauzi", "Wuffi", "Basko", "Franz"}
        'Einfügen *vor* dem 6. Element
        locNamen.InsertRange(5, locHundenamen)

        'ArrayList ein Array zurückwandeln
        Dim locAlleNamen As String()

        'Vorsicht: Fehler!
        'locAlleNamen = DirectCast(locNamen.ToArray, String())

        'Vorsicht: Ebenfalls Fehler!
        'locAlleNamen = DirectCast(locNamen.ToArray(GetType(String())), String())

        'So ist es richtig
        locAlleNamen = DirectCast(locNamen.ToArray(GetType(String)), String())

        'Repeat legt eine Arraylist aus wiederholten Items an
        locNamen.AddRange(ArrayList.Repeat("Dublettenname", 10))

        'Ein Element im Array mit der Item-Eigenschaft ändern
        locNamen(10) = "Fiffi"

        'Mit der Item-Eigenschaft geht es auch:
        locNamen.Item(13) = "Miriam"

        'Löschen des ersten zutreffenden Elementes aus der Liste
        locNamen.Remove("Basko")

        'Löschen eines Elementes an einer bestimmten Position
        locNamen.RemoveAt(4)

        'Löschen eines bestimmten Bereichs aus der ArrayList mit RemoveRange
        'Count ermittelt die Anzahl der Elemente in der ArrayList
        locNamen.RemoveRange(locNamen.Count - 6, 5)

        'Ausgeben der Elemente über die Default-Eigenschaft der ArrayList (Item)
        For i As Integer = 0 To locNamen.Count - 1
            Console.WriteLine("Der Name Nr. {0} lautet {1}", i, locNamen(i).ToString)
        Next

        'Anderes, als ein String-Objekt der ArrayList hinzufügen,
        'um den folgenden Fehler "vorzubereiten"
        locNamen.Add(New FileInfo("C:\TEST.TXT"))

        'Diese Schleife kann nicht bis zum Ende ausgeführt werden,
        'da ein Objekt nicht vom Typ String mit von der Partie ist!
        For Each einString As String In locNamen
            'Hier passiert irgendetwas mit dem String
            'nicht von Interesse, deswegen kein Rückgabewert
            einString.EndsWith("Peter")
        Next

        Console.ReadLine()

    End Sub

    Sub QueueDemo()

        Dim locQueue As New Queue
        Dim locString As String

        locQueue.Enqueue("Erstes Element")
        locQueue.Enqueue("Zweites Element")
        locQueue.Enqueue("Drittes Element")
        locQueue.Enqueue("Viertes Element")

        'Nachschauen, was am Anfang steht, ohne es zu entfernen
        Console.WriteLine("Element am Queue-Anfang:" + locQueue.Peek().ToString)
        Console.WriteLine()

        'Iterieren funktioniert auch
        For Each locString In locQueue
            Console.WriteLine(locString)
        Next
        Console.WriteLine()

        'Alle Elemente aus Queue entfernen und Ergebnis im Konsolenfenster anzeigen
        Do
            locString = CStr(locQueue.Dequeue)
            Console.WriteLine(locString)
        Loop Until locQueue.Count = 0
        Console.ReadLine()

    End Sub

    Sub StackDemo()

        Dim locStack As New Stack
        Dim locString As String

        locStack.Push("Erstes Element")
        locStack.Push("Zweites Element")
        locStack.Push("Drittes Element")
        locStack.Push("Viertes Element")

        'Nachschauen, was oben auf dem Stapel liegt, ohne das Element zu entfernen
        Console.WriteLine("Element zu oberst auf dem Stapel: " + locStack.Peek.ToString)
        Console.WriteLine()

        'Iterieren funktioniert auch
        For Each locString In locStack
            Console.WriteLine(locString)
        Next
        Console.WriteLine()

        'Alle Elemente vom Stack ziehen und Ergebnis im Konsolenfenster anzeigen
        Do
            locString = CStr(locStack.Pop)
            Console.WriteLine(locString)
        Loop Until locStack.Count = 0
        Console.ReadLine()

    End Sub

End Module

