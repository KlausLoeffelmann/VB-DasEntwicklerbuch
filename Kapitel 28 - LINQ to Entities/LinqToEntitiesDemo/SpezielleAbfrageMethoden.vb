Imports System.Data.Objects

Module SpezielleAbfrageMethoden

    Sub main()
        'AnonymisierungsvermeidungBeiVerknüpftenAbfragen()
        KompilierteAbfragen()
    End Sub

    Sub AnonymisierungsvermeidungBeiVerknüpftenAbfragen()

        Dim awContext As New AWEntities()

        'Fragt alle Lieferanten ab, die Produkte haben, 
        'deren Namen ihrer Produktdetailsbeschreibungen mit "W" beginnen.
        Dim lieferanten = From lieferantItems In awContext.Vendor _
        From lieferantProduktItem In lieferantItems.ProductVendor _
            From productItem In awContext.Product _
                Where lieferantItems.VendorID = lieferantProduktItem.VendorID _
                    Where productItem.ProductID = lieferantProduktItem.ProductID _
                        Where productItem.Name.StartsWith("W") _
                            Select lieferantItems Distinct

        'Manuelles Lazy-Loading für die Gesamtausgabe verwenden:
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

    Sub KompilierteAbfragen()

        Dim awContext As New AWEntities()

        Dim kompilierteLieferantenAbfrage = CompiledQuery.Compile(Of AWEntities, _
                                                String, IQueryable(Of Vendor))( _
                        Function(context, Anfangsbuchstabe) From lieferant In context.Vendor _
                                Where lieferant.Name.StartsWith(Anfangsbuchstabe) _
                                Order By lieferant.Name _
                                Select lieferant)

        Dim abfrageNach_H = kompilierteLieferantenAbfrage(awContext, "H")

        For Each lieferant In abfrageNach_H
            Console.WriteLine(lieferant.AccountNumber & ": " & lieferant.Name)
            Console.WriteLine(New String("="c, 70))

            'Zu jedem Lieferanten die Produkte ausliefern
            For Each produkt In lieferant.ProductVendor
                Console.Write("ID:" & produkt.ProductID & " ")
                Console.WriteLine("Name:" & produkt.Product.Name)
            Next
            Console.WriteLine()
        Next

        Dim abfrageNach_W = kompilierteLieferantenAbfrage(awContext, "W")

        For Each lieferant In abfrageNach_W
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
