Imports System.Data.Objects

Module DatenBearbeiten

    Sub main()

        'DatenÄndern()
        'DatenVerknüpftEinfügen()
        'DatenLöschen()
        DatenÄndernMitKollisionsprüfung()
    End Sub

    Sub DatenÄndern()

        Dim awContext As New AWEntities()

        Dim lieferant = (From lieferantItem In awContext.Vendor _
                          Where lieferantItem.Name.ToLower.StartsWith("hybrid") _
                          Order By lieferantItem.Name).First

        'Hin- und her ändern, damit es nicht nur einmal funktioniert:
        If lieferant.Name = "Hybrid Bicycle Center" Then
            lieferant.Name = "Hybrid Fahrrad Center"
        Else
            lieferant.Name = "Hybrid Bicycle Center"
        End If

        awContext.SaveChanges()

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()

    End Sub

    Sub DatenVerknüpftEinfügen()

        Dim awContext As New AWEntities()

        Dim neuerLieferant As New Vendor With {.Name = "ActiveDevelop", .CreditRating = 1, _
                                       .AccountNumber = "ACTDEV00001", .ModifiedDate = Now}

        ' den Trigger auf der Vendor-Tabelle deaktivieren
        ' da ein Lieferant eingentlich nicht gelöscht werden darf.
        ' wir können in diesem Fall aber eine Ausnahme machen
        ' da nur Sie auf der Datenbank arbeiten und keine Replication
        ' nutzen (dafür ist der Trigger gedacht)
        '
        ' WICHTIG: Beachten Sie, dass der Trigger auch für alle anderen Datenbankanwender 
        ' deaktiviert ist. D.h. im Produktionsbetrieb würden Sie hier ggf. eine Dateninkonsistenz riskieren.
        ' Wir können das hier auf unserer Spieldatenbank machen, 
        ' aber ein Datenbankadministrator würde wohl mächtig sauer werden.
        awContext.ExecuteStoreCommand("disable trigger Purchasing.dVendor on Purchasing.Vendor")

        ' erst einmal prüfen, ob noch Altlasten von uns da sind
        ' Die löschen wir dann erst mal!
        ' Und wir nutzen immer die selbe AccountNumber in diesem Beispiel.
        ' Also ermitteln wir die Daten anhand dieser AccountNumber (activedev.AccountNumber = neuerLieferant.AccountNumber).
        Dim activeDevVorhandeneDatensaetze = (From activedev In awContext.Vendor
                                   Where activedev.AccountNumber = neuerLieferant.AccountNumber).ToList()

        If activeDevVorhandeneDatensaetze.Count = 1 Then
            Dim activeDevVorhandenerDS = activeDevVorhandeneDatensaetze(0)
            ' ok es sind Altlasten vorhanden
            ' falls wir nicht LazyLoading verwenden, die ProductVendors nachladen
            If Not activeDevVorhandenerDS.ProductVendor.IsLoaded Then
                activeDevVorhandenerDS.ProductVendor.Load()
            End If
            Dim prodVendorCopy = activeDevVorhandenerDS.ProductVendor.ToArray()
            For Each prodvends In prodVendorCopy
                If Not prodvends.ProductReference.IsLoaded Then
                    prodvends.ProductReference.Load()
                End If
                awContext.DeleteObject(prodvends.Product)
                awContext.DeleteObject(prodvends)
            Next
            awContext.DeleteObject(activeDevVorhandenerDS)
            awContext.SaveChanges()
        End If




        'Das neue Produkt erstellen
        Dim neuesProdukt As New Product With {.Name = "Visual Basic 2010 - Das Entwicklerbuch", _
                                              .ProductNumber = "", _
                                              .ListPrice = 59, _
                                              .ModifiedDate = Now, _
                                              .DiscontinuedDate = #12/31/2011#, _
                                              .SellStartDate = #12/10/2008#, _
                                              .SellEndDate = #12/31/2011#, _
                                              .SafetyStockLevel = 5, _
                                              .ReorderPoint = 2}

        'Neues Lieferantenprodukt erstellen, das Produkt mit diesem,
        'und dieses mit dem Lieferanten verknüpfen

        Dim neuesLieferantenProdukt = New ProductVendor With {.Product = neuesProdukt, _
                                                .StandardPrice = 59, _
                                                .ModifiedDate = Now, _
                                                .UnitMeasureCode = "PC", _
                                                .AverageLeadTime = 19, _
                                                .MinOrderQty = 1, _
                                                .MaxOrderQty = 10}

        awContext.AddToVendor(neuerLieferant)
        neuerLieferant.ProductVendor.Add(neuesLieferantenProdukt)
        awContext.SaveChanges()

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()
    End Sub

    Sub DatenLöschen()

        Dim awContext As New AWEntities()

        'Die Entitätsobjekte ermitteln, die sich durch das angegebene Produkt ergeben:
        Dim lieferantProduct = (From lieferantProduktItem In awContext.ProductVendor _
                                 From productItem In awContext.Product _
                                  Where productItem.ProductID = lieferantProduktItem.ProductID _
                                  Where productItem.Name = "Visual Basic 2010 - Das Entwicklerbuch" _
                                   Select lieferantProduktItem).First

        'Nur zur Kontrolle
        Console.WriteLine(lieferantProduct.ProductID)

        'Lazy-Loading: Die übergeordneten Entitätsobjekte laden.
        'Zuerst das Lieferantenprodukt, dass dem ermittelten Produkt
        'zugeordnet ist.
        lieferantProduct.ProductReference.Load()

        'Und genau so einfach laden wir auch den übergeordneten Lieferanten.
        lieferantProduct.VendorReference.Load()

        'Die Referenzen auf die Entitäten müssen wir uns
        'temporär merken, weil DeleteObject sie mit
        'der übergeordneten Tabelle zerstört.
        Dim tmpProduct = lieferantProduct.Product
        Dim tmpVendor = lieferantProduct.Vendor

        'Reihenfolge des Löschens spielt jetzt ...
        awContext.DeleteObject(tmpVendor)

        '... keine Rolle mehr.
        awContext.DeleteObject(tmpProduct)

        'Das Entity Framework legt die richtige Reihenfolge fest!
        awContext.SaveChanges()

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()
    End Sub

    Sub DatenÄndernMitKollisionsprüfung()

        Dim awContext As New AWEntities()

        Dim lieferant = (From lieferantItem In awContext.Vendor _
                          Where lieferantItem.Name.ToLower.StartsWith("hybrid") _
                          Order By lieferantItem.Name).First

        'Hin- und her ändern, damit es nicht nur einmal funktioniert:
        If lieferant.Name = "Hybrid Bicycle Center" Then
            lieferant.Name = "Hybrid Fahrrad Center"
        Else
            lieferant.Name = "Hybrid Bicycle Center"
        End If
        'Zeitstempel für die letzte Änderung setzen
        lieferant.ModifiedDate = Date.Now

        Console.WriteLine("Wenn Sie wollen, können Sie nun den Datensatz mit der VendorID {0} mit dem SQL Server Management Studio ändern.", lieferant.VendorID)
        Console.WriteLine("Vergessen Sie nicht, mindestens ein Feld zu ändern, welches bei dem Parallelitätsmodus fixed eingestellt hat (typischerweise ModifiedDate).")
        Console.WriteLine("Oder starten Sie dieses Programm einfach nochmals (z.B. mit dem Windows Explorer aus dem Bin-Verzeichnis)")
        Console.WriteLine("Drücken Sie bitte im Anschluss eine Taste")

        Console.ReadKey()
        Console.WriteLine("")
        Console.WriteLine("")

        Try
            Dim anzahl = awContext.SaveChanges()
            Console.WriteLine("Keine Konflikte bei der Speicherung. " _
                              & anzahl & " Aktualisierungen gespeichert.")
        Catch ex As OptimisticConcurrencyException
            awContext.Refresh(RefreshMode.ClientWins, lieferant)

            awContext.SaveChanges()
            Console.WriteLine("Konfliktfehler wurde abgefangen, Änderungen wurden gespeichert!")
        End Try

        'Änderungen zurückschreiben
        awContext.SaveChanges()

        Console.WriteLine()
        Console.WriteLine("Taste drücken, zum Beenden")
        Console.ReadKey()

    End Sub


End Module
