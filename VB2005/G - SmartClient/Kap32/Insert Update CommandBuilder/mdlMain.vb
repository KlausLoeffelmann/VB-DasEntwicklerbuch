Imports System.Data.SQLClient

Module mdlMain

    Sub Main()

        Dim locConnection As SqlConnection

        'Connection-Objekt holen, damit die Datenbankverbindung hergestellt werden kann
        locConnection = New _
             SqlConnection("Data Source=.\SQLExpress;Initial Catalog=Hecktick;Integrated Security=True")

        'Verbindung öffnen
        locConnection.Open()

        'Damit sorgen wir dafür, dass die Verbindung wieder geschlossen wird,
        'wenn locConnection aus dem Using-Scope herausläuft.
        Using locConnection

            'Alle Commands im DataAdapter definieren
            Dim locAdapter As New SqlDataAdapter

            'Die Selectabfrage für den Adapter definieren;
            'daraus generiert der CommandBuilder dann die 
            'anderen Command-Objekte fürs Einfügen, Aktualisieren und Löschen.
            locAdapter.SelectCommand = New SqlCommand("SELECT * FROM Projekte")
            locAdapter.SelectCommand.Connection = locConnection

            'Den CommandBuilder zuhilfe nehmen und dem Adapter zuweisen.
            Dim locCmdBuilder As New SqlCommandBuilder(locAdapter)

            'Neue Datentablle
            Dim locDataTable As New DataTable

            'Könnten wir selber definieren, aber so geht's schneller.
            locAdapter.FillSchema(locDataTable, SchemaType.Source)

            'Neue Datenzeile
            Dim locDataRow As DataRow = locDataTable.NewRow()

            'Entsprechend des Datenschemas der Tabelle mit Datenfüllen.
            '(IDProjekte wird von Sql Server selbst geschrieben, da es ein
            ' AutoIncrement-Feld ist. Deswegen übergeben wir hier 'Nothing')
            locDataRow.ItemArray = New Object() {Nothing, "Orcas", " (VS 2007) Schreiben des Entwicklerbuchs", _
                                 #2/1/2007#, #12/31/2007#, "Büro"}
            'Die Zeile der Tabelle hinzufügen
            locDataTable.Rows.Add(locDataRow)

            'Das Gleiche mit einer weiteren Zeile
            locDataRow = locDataTable.NewRow
            locDataRow.ItemArray = New Object() {Nothing, "Katmai", "(SQL Server 2005) Schreiben des Crash-Kurs", _
                                 #3/1/2007#, #1/31/2008#, "Büro"}
            locDataTable.Rows.Add(locDataRow)

            'Und nun die neue Tabelle mit der Datenbank synchronisieren.
            'Hier wird SQL-INSERT zweimal hinterinander ausgeführt.
            locAdapter.Update(locDataTable)

            Console.WriteLine("Betrachten Sie die hinzugefügten Daten nun im Server-Explorer")
            Console.WriteLine("Drücken Sie anschließend Return")
            Console.WriteLine()
            Console.ReadLine()

            'DataTable neu einlesen
            locDataTable.Clear()
            locAdapter.Fill(locDataTable)

            'Jetzt verwenden wir eine View, um die 'Katmai'-Zeile zu ermitteln.
            'Das ist die, die wir als letztes geändert haben!

            Dim locDataView As New DataView(locDataTable, "Projektname='Katmai'", _
                            "Projektname", DataViewRowState.CurrentRows)

            'Eigentlich können wir nur genau ein zurückbekommen.
            locDataRow = locDataView(0).Row

            'Daten ändern.
            locDataRow.ItemArray = New Object() {Nothing, "Katmai", "(SQL Server 2007) Schreiben des Crash-Kurses", _
                                 #2/1/2007#, #10/31/2007#, "Ruprechts Büro"}

            'Änderungen zurückschreiben.
            locAdapter.Update(locDataTable)

            Console.WriteLine("Betrachten Sie die geänderten Daten nun im Server-Explorer")
            Console.WriteLine("Drücken Sie anschließend Return")
            Console.ReadLine()
        End Using

    End Sub
End Module

