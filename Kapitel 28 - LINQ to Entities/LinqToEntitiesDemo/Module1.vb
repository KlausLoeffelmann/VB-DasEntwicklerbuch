Imports System.Data.Objects

Module Module1

    Sub Main()

        'AnonymisierungsvermeidungBeiVerknüpftenAbfragen()
        'KompilierteAbfragen()
        'Return

        'Wir verwenden in den Beispielen die Verbindungszeichenfolge aus der App.Config.
        'Ändern Sie die Zeichenfolge im Abschnitt ConnectionStrings, um die Beispiele
        'auf Ihre SQL Server-Instanz anzupassen. Sie müssen dazu nur den Provider-
        'ConnectionString innerhalb des Gesamt-ConnectionStrings anpassen.
        Dim awContext As New AWEntities()

        Dim lieferanten = From lieferant In awContext.Vendor _
                          Where lieferant.Name.StartsWith("H") _
                          Order By lieferant.Name

        'Mit dieser Anweisungen können wir rausfinden, 
        'welcher SQL-Text zur Anwendung kommen wird.
        Console.WriteLine(CType(lieferanten, ObjectQuery(Of Vendor)).ToTraceString)
        Console.WriteLine()


        For Each lieferant In lieferanten
            Console.WriteLine(lieferant.AccountNumber & ": " & lieferant.Name)
            Console.WriteLine(New String("="c, 70))

            'Zu jedem Lieferanten die Produkte ausliefern
            For Each produkt In lieferant.ProductVendor
                Console.Write("ID:" & produkt.ProductID & " ")
                Console.WriteLine("Name:" & produkt.Product.Name)
            Next
            Console.WriteLine()

        Next

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()
    End Sub

End Module
