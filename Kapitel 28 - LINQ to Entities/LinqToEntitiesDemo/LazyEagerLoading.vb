Imports System.Data.Objects

Module LazyEagerLoading

    Sub main()
        'ManuellesNachladen()
        EagerLoading()

    End Sub

    Sub ManuellesNachladen()
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

            If Not lieferant.ProductVendor.IsLoaded Then
                lieferant.ProductVendor.Load()

                'Zu jedem Lieferanten die Produkte ausliefern
                For Each produkt In lieferant.ProductVendor
                    If Not produkt.ProductReference.IsLoaded Then
                        produkt.ProductReference.Load()
                        Console.Write("ID:" & produkt.ProductID & " ")
                        Console.WriteLine("Name:" & produkt.Product.Name)
                    End If
                Next
                Console.WriteLine()
            End If

        Next

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()

    End Sub

    Sub EagerLoading()
        Dim awContext As New AWEntities()

        Dim lieferanten = From lieferant In awContext.Vendor.Include("ProductVendor.Product") _
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
