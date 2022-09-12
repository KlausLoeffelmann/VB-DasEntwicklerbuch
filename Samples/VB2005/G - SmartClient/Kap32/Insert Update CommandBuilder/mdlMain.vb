Imports System.Data.SQLClient

Module mdlMain

    Sub Main()

        Dim locConnection As SqlConnection

        'Connection-Objekt holen, damit die Datenbankverbindung hergestellt werden kann
        locConnection = New _
             SqlConnection("Data Source=.\SQLExpress;Initial Catalog=Hecktick;Integrated Security=True")

        'Verbindung �ffnen
        locConnection.Open()

        'Damit sorgen wir daf�r, dass die Verbindung wieder geschlossen wird,
        'wenn locConnection aus dem Using-Scope herausl�uft.
        Using locConnection

            'Alle Commands im DataAdapter definieren
            Dim locAdapter As New SqlDataAdapter

            'Die Selectabfrage f�r den Adapter definieren;
            'daraus generiert der CommandBuilder dann die 
            'anderen Command-Objekte f�rs Einf�gen, Aktualisieren und L�schen.
            locAdapter.SelectCommand = New SqlCommand("SELECT * FROM Projekte")
            locAdapter.SelectCommand.Connection = locConnection

            'Den CommandBuilder zuhilfe nehmen und dem Adapter zuweisen.
            Dim locCmdBuilder As New SqlCommandBuilder(locAdapter)

            'Neue Datentablle
            Dim locDataTable As New DataTable

            'K�nnten wir selber definieren, aber so geht's schneller.
            locAdapter.FillSchema(locDataTable, SchemaType.Source)

            'Neue Datenzeile
            Dim locDataRow As DataRow = locDataTable.NewRow()

            'Entsprechend des Datenschemas der Tabelle mit Datenf�llen.
            '(IDProjekte wird von Sql Server selbst geschrieben, da es ein
            ' AutoIncrement-Feld ist. Deswegen �bergeben wir hier 'Nothing')
            locDataRow.ItemArray = New Object() {Nothing, "Orcas", " (VS 2007) Schreiben des Entwicklerbuchs", _
                                 #2/1/2007#, #12/31/2007#, "B�ro"}
            'Die Zeile der Tabelle hinzuf�gen
            locDataTable.Rows.Add(locDataRow)

            'Das Gleiche mit einer weiteren Zeile
            locDataRow = locDataTable.NewRow
            locDataRow.ItemArray = New Object() {Nothing, "Katmai", "(SQL Server 2005) Schreiben des Crash-Kurs", _
                                 #3/1/2007#, #1/31/2008#, "B�ro"}
            locDataTable.Rows.Add(locDataRow)

            'Und nun die neue Tabelle mit der Datenbank synchronisieren.
            'Hier wird SQL-INSERT zweimal hinterinander ausgef�hrt.
            locAdapter.Update(locDataTable)

            Console.WriteLine("Betrachten Sie die hinzugef�gten Daten nun im Server-Explorer")
            Console.WriteLine("Dr�cken Sie anschlie�end Return")
            Console.WriteLine()
            Console.ReadLine()

            'DataTable neu einlesen
            locDataTable.Clear()
            locAdapter.Fill(locDataTable)

            'Jetzt verwenden wir eine View, um die 'Katmai'-Zeile zu ermitteln.
            'Das ist die, die wir als letztes ge�ndert haben!

            Dim locDataView As New DataView(locDataTable, "Projektname='Katmai'", _
                            "Projektname", DataViewRowState.CurrentRows)

            'Eigentlich k�nnen wir nur genau ein zur�ckbekommen.
            locDataRow = locDataView(0).Row

            'Daten �ndern.
            locDataRow.ItemArray = New Object() {Nothing, "Katmai", "(SQL Server 2007) Schreiben des Crash-Kurses", _
                                 #2/1/2007#, #10/31/2007#, "Ruprechts B�ro"}

            '�nderungen zur�ckschreiben.
            locAdapter.Update(locDataTable)

            Console.WriteLine("Betrachten Sie die ge�nderten Daten nun im Server-Explorer")
            Console.WriteLine("Dr�cken Sie anschlie�end Return")
            Console.ReadLine()
        End Using

    End Sub
End Module

