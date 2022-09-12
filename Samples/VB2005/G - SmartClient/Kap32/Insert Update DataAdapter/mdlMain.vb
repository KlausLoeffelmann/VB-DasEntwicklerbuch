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
            Dim locAdapter As SqlDataAdapter = DataAdapterVorbereiten(locConnection)

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

    Private Function DataAdapterVorbereiten(ByVal Conn As SqlConnection) As SqlDataAdapter

        Dim locDa As New SqlDataAdapter

        locDa = New System.Data.SqlClient.SqlDataAdapter

        locDa.SelectCommand = New SqlCommand("SELECT * FROM [Projekte]")
        locDa.SelectCommand.Connection = Conn

        locDa.DeleteCommand = New System.Data.SqlClient.SqlCommand
        locDa.DeleteCommand.Connection = Conn
        locDa.DeleteCommand.CommandText = "DELETE FROM [dbo].[Projekte] WHERE " & _
            "(([IDProjekte] = @Original_IDProjekte) AND ([Projektname]" & _
            " = @Original_Projektname) AND ((@IsNull_Projektbeschreibung = 1 AND " & _
            "[Projektbeschreibung] IS NULL) OR ([Projektbeschreibung] = @Original_Projektbeschreibung))" & _
            " AND ([Startzeitpunkt] = @Original_Startzeitpunkt) AND ([Endzeitpunkt] " & _
            "= @Original_Endzeitpunkt) AND ((@IsNull_Ausführungsort = 1 AND [Ausführungsort] " & _
            "IS NULL) OR ([Ausführungsort] = @Original_Ausführungsort)))"
        locDa.DeleteCommand.CommandType = System.Data.CommandType.Text
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_IDProjekte", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "IDProjekte", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Projektname", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektname", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@IsNull_Projektbeschreibung", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Projektbeschreibung", _
                System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Startzeitpunkt", System.Data.SqlDbType.DateTime, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Startzeitpunkt", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Endzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Endzeitpunkt", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@IsNull_Ausführungsort", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""))
        locDa.DeleteCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Ausführungsort", System.Data.SqlDbType.NVarChar, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))


        locDa.InsertCommand = New System.Data.SqlClient.SqlCommand
        locDa.InsertCommand.Connection = Conn
        locDa.InsertCommand.CommandText = "INSERT INTO [dbo].[Projekte] ([Projektname], [Projektbeschreibung], " & _
            "[Startzeitpunkt], [Endzeitpunkt], [Ausführungsort]) VALUES (@Projektname, " & _
            "@Projektbeschreibung, @Startzeitpunkt, @Endzeitpunkt, @Ausführungsort);"
        locDa.InsertCommand.CommandType = System.Data.CommandType.Text
        locDa.InsertCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Projektname", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektname", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.InsertCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Projektbeschreibung", System.Data.SqlDbType.NVarChar, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.InsertCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Startzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Startzeitpunkt", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.InsertCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Endzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Endzeitpunkt", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.InsertCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Ausführungsort", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))


        locDa.UpdateCommand = New System.Data.SqlClient.SqlCommand
        locDa.UpdateCommand.Connection = Conn
        locDa.UpdateCommand.CommandText = "UPDATE [dbo].[Projekte] " & _
            "SET [Projektname] = @Projektname, [Projektbeschreibung] =" & _
            " @Projektbeschreibung, [Startzeitpunkt] = @Startzeitpunkt, [Endzeitpunkt] = " & _
            "@Endzeitpunkt, [Ausführungsort] = @Ausführungsort WHERE (([IDProjekte] = " & _
            "@Original_IDProjekte) AND ([Projektname] = @Original_Projektname) AND " & _
            "((@IsNull_Projektbeschreibung = 1 AND [Projektbeschreibung] IS NULL) OR ([Projektbeschreibung] " & _
            "= @Original_Projektbeschreibung)) AND ([Startzeitpunkt] = @Original_Startzeitpunkt) " & _
            "AND ([Endzeitpunkt] = @Original_Endzeitpunkt) AND ((@IsNull_Ausführungsort = 1 AND" & _
            " [Ausführungsort] IS NULL) OR ([Ausführungsort] = @Original_Ausführungsort)));"
        locDa.UpdateCommand.CommandType = System.Data.CommandType.Text
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Projektname", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektname", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Projektbeschreibung", System.Data.SqlDbType.NVarChar, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Startzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Startzeitpunkt", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Endzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Endzeitpunkt", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Ausführungsort", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_IDProjekte", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "IDProjekte", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Projektname", System.Data.SqlDbType.NVarChar, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektname", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@IsNull_Projektbeschreibung", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Projektbeschreibung", _
                System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, _
                "Projektbeschreibung", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Startzeitpunkt", System.Data.SqlDbType.DateTime, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Startzeitpunkt", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Endzeitpunkt", System.Data.SqlDbType.DateTime, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Endzeitpunkt", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@IsNull_Ausführungsort", System.Data.SqlDbType.Int, 0, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Original, True, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@Original_Ausführungsort", System.Data.SqlDbType.NVarChar, _
                0, System.Data.ParameterDirection.Input, 0, 0, _
                "Ausführungsort", System.Data.DataRowVersion.Original, False, Nothing, "", "", ""))
        locDa.UpdateCommand.Parameters.Add( _
                New System.Data.SqlClient.SqlParameter("@IDProjekte", System.Data.SqlDbType.Int, 4, _
                System.Data.ParameterDirection.Input, 0, 0, _
                "IDProjekte", System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))

        Return locDa
    End Function
End Module

