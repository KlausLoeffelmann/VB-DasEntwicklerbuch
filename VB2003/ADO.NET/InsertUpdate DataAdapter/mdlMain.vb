Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Reflection

Module mdlMain

    Private Const myDatabaseName As String = "Testdatenbank.mdb"

    Sub Main()
        Dim locConnection As OleDbConnection
        Dim locCommand As New OleDbCommand
        Dim locPathAndName As String

        locPathAndName = GetStartUpPath().Parent.Parent.FullName + "\" + myDatabaseName
        locConnection = GetConnection(New FileInfo(locPathAndName))

        MaschinenDatenEinf�gen(locConnection, "Bosch X3A2_1", "Stanzmaschine", "Halle 12", False)
        MaschinenDatenEinf�gen(locConnection, "Bosch X3A2_2", "Auch Stanzmaschine", "Halle 12", False)
        MaschinenDatenEinf�gen(locConnection, "Bosch X3A2_3", "Presse", "Halle 12", False)
        Console.WriteLine("Betrachten Sie die hinzugef�gten Daten nun im Server-Explorer")
        Console.WriteLine("Dr�cken Sie anschlie�end Return")
        Console.WriteLine()
        Console.ReadLine()
        Maschinendaten�ndern(locConnection, "Bosch X3A2_2", "Stanzmaschine", "Halle 12", True)
        Console.WriteLine("Betrachten Sie die ge�nderten Daten nun im Server-Explorer")
        Console.WriteLine("Dr�cken Sie anschlie�end Return")
        Console.ReadLine()
    End Sub

    'F�gt einen Datensatz in die Maschinentabelle ein
    Private Sub MaschinenDatenEinf�gen(ByVal Con As OleDbConnection, ByVal Typbezeichnung As String, ByVal Beschreibung As String, _
                                        ByVal Standort As String, ByVal WartungN�tig As Boolean)

        Dim locDataTable As New DataTable
        Dim locSchemaCommand As New OleDbCommand

        'Schema f�r DataTable ermitteln, damit wir die DataTable nicht selbst aufbauen m�ssen
        locSchemaCommand.CommandText = "SELECT * FROM [Maschinen]"
        locSchemaCommand.Connection = Con
        Dim locDataAdapter As New OleDbDataAdapter(locSchemaCommand)
        locDataAdapter.FillSchema(locDataTable, SchemaType.Mapped)

        'Insert-Command erstellen
        Dim locInsertCommand As OleDbCommand
        Dim locInsertString As String = "INSERT INTO [Maschinen] "
        locInsertString += "([Typbezeichnung],[Beschreibung],[Standort],[WartungN�tig])"
        locInsertString += " VALUES (?,?,?,?)"
        Console.WriteLine(locInsertString)

        locInsertCommand = New OleDbCommand(locInsertString, Con)

        'Parameter-Array anlegen, damit der DataAdapter sp�ter wei�, welche Typen
        'er behandeln muss.
        Dim pc As OleDbParameterCollection = locInsertCommand.Parameters
        pc.Add("Typbezeichnung", OleDbType.VarWChar, 255, "Typbezeichnung")
        pc.Add("Beschreibung", OleDbType.VarWChar, 255, "Beschreibung")
        pc.Add("Standort", OleDbType.VarWChar, 255, "Standort")
        pc.Add("WartungN�tig", OleDbType.Boolean, 0, "WartungN�tig")

        'InsertCommand f�r den DataAdapter festlegen
        locDataAdapter.InsertCommand = locInsertCommand

        'Neue Datensatzvorlage erstellen
        Dim locNewRow As DataRow = locDataTable.NewRow()
        'Mit Daten f�llen
        locNewRow("Typbezeichnung") = Typbezeichnung
        locNewRow("Beschreibung") = Beschreibung
        locNewRow("Standort") = Standort
        locNewRow("WartungN�tig") = WartungN�tig

        'NICHT VERGESSEN: Den neuen Datensatz der Tabelle hinzuf�gen
        locDataTable.Rows.Add(locNewRow)

        'Update l�st den INSERT INTO-SQL-Befehl aus, bei dem die vorgegebenen Fragezeichen
        'zuvor von den DataRow-Inhalten ersetzt wurden
        locDataAdapter.Update(locDataTable)
    End Sub

    '�ndert einen Datensatz der Maschinentabelle
    Private Sub Maschinendaten�ndern(ByVal Con As OleDbConnection, ByVal Zu�nderndeMaschine As String, ByVal Beschreibung As String, _
                                     ByVal Standort As String, ByVal WartungN�tig As Boolean)

        Dim locDataTable As New DataTable
        Dim locSelectCommand As New OleDbCommand

        'Datensatz ermitteln, der ver�ndert werden soll...
        locSelectCommand.CommandText = "SELECT [IDMaschinen], [Typbezeichnung], [Beschreibung], [Standort], " + _
                                        "[WartungN�tig] FROM [Maschinen] WHERE [Typbezeichnung]=""" + _
                                        Zu�nderndeMaschine + """"
        locSelectCommand.Connection = Con
        Dim locDataAdapter As New OleDbDataAdapter
        locDataAdapter.SelectCommand = locSelectCommand

        '...dabei wird auch die DataTable-Struktur aufgebaut
        locDataAdapter.Fill(locDataTable)

        'Update-Command erstellen
        Dim locUpdateCommand As New OleDbCommand
        Dim locUpdateString As String = "UPDATE [Maschinen] SET "
        locUpdateString += " [Typbezeichnung]=?,"
        locUpdateString += " [Beschreibung]=?,"
        locUpdateString += "[Standort]=?,"
        locUpdateString += "[WartungN�tig]=?"
        locUpdateString += " WHERE [Typbezeichnung]=? AND "
        locUpdateString += " [Beschreibung]=? AND"
        locUpdateString += " [Standort]=? AND"
        locUpdateString += " [WartungN�tig]=?"

        Console.WriteLine(locUpdateString)

        locUpdateCommand = New OleDbCommand(locUpdateString, Con)

        'Erst die Parameter f�r das Zuweisen der zu �ndernden Parameter festlegen,...
        Dim pc As OleDbParameterCollection = locUpdateCommand.Parameters
        pc.Add("Typbezeichnung_Neu", OleDbType.VarWChar, 255, "Typbezeichnung")
        pc.Add("Beschreibung_Neu", OleDbType.VarWChar, 255, "Beschreibung")
        pc.Add("Standort_Neu", OleDbType.VarWChar, 255, "Standort")
        pc.Add("WartungN�tig_Neu", OleDbType.Boolean, 0, "WartungN�tig")

        '...und anschlie�end die Parameter, f�r das Finden des zu �ndernden Datensatzes.
        Dim p As OleDbParameter
        p = pc.Add("Typbezeichnung_Org", OleDbType.VarWChar, 255, "Typbezeichnung")
        'WICHTIG: Hier m�ssen die Originaldaten (Ursprungsdaten vor der Ver�nderung)
        '�bergeben werden
        p.SourceVersion = DataRowVersion.Original
        p = pc.Add("Beschreibung_Org", OleDbType.VarWChar, 255, "Beschreibung")
        p.SourceVersion = DataRowVersion.Original
        p = pc.Add("Standort_Org", OleDbType.VarWChar, 255, "Standort")
        p.SourceVersion = DataRowVersion.Original
        p = pc.Add("WartungN�tig_Org", OleDbType.Boolean, 0, "WartungN�tig")
        p.SourceVersion = DataRowVersion.Original
        locDataAdapter.UpdateCommand = locUpdateCommand

        'Jetzt k�nnen die Daten ge�ndert werden
        Dim locRow As DataRow = locDataTable.Rows(0)
        locRow("Beschreibung") = Beschreibung
        locRow("Standort") = Standort
        locRow("WartungN�tig") = WartungN�tig

        'Update l�st jetzt den update-SQL-Befehl aus, bei dem die vorgegebenen Fragezeichen
        'zuvor von den DataRow-Inhalten (den alten und den neuen) ersetzt wurden
        locDataAdapter.Update(locDataTable)
    End Sub

    Private Function GetConnection(ByVal AccessDatabaseName As FileInfo) As OleDbConnection

        Dim locConnectionString As String

        locConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;"
        locConnectionString += "Jet OLEDB:Registry Path=;"
        locConnectionString += "Jet OLEDB:Database Locking Mode=1;"
        locConnectionString += "Jet OLEDB:Database Password=;"
        locConnectionString += "Data Source=" + AccessDatabaseName.FullName + ";Password=;"
        locConnectionString += "Jet OLEDB:Engine Type=5;"
        locConnectionString += "Jet OLEDB:Global Bulk Transactions=1;"
        locConnectionString += "Provider=""Microsoft.Jet.OLEDB.4.0"";"
        locConnectionString += "Jet OLEDB:System database=;"
        locConnectionString += "Jet OLEDB:SFP=False;"
        locConnectionString += "Extended Properties=;"
        locConnectionString += "Mode=Share Deny None;"
        locConnectionString += "Jet OLEDB:New Database Password=;"
        locConnectionString += "Jet OLEDB:Create System Database=False;"
        locConnectionString += "Jet OLEDB:Compact Without Replica Repair=False;"
        locConnectionString += "User ID=Admin;"
        locConnectionString += "Jet OLEDB:Encrypt Database=False"
        Return New OleDbConnection(locConnectionString)

    End Function

    'Findet den Pfad, in dem die aktuelle Assembly (DLL, EXE) ausgef�hrt wird.
    Private Function GetStartUpPath() As DirectoryInfo
        Dim locAss As [Assembly] = [Assembly].GetExecutingAssembly
        Return New DirectoryInfo(Path.GetDirectoryName(locAss.Location))
    End Function

End Module

