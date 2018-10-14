Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Reflection

Module mdlMain

    'Datenbankname ist fest definiert
    Private Const myDatabaseName As String = "Testdatenbank.mdb"

    Sub Main()
        Dim locConnection As OleDbConnection
        Dim locCommand As OleDbCommand
        Dim locDataReader As OleDbDataReader
        Dim locPathAndName As String

        'Pfad zur Datenbank ermitteln
        locPathAndName = GetStartUpPath().Parent.Parent.FullName + "\" + myDatabaseName
        'Connection-Objekt holen, damit die Datenbankverbindung hergestellt werden kann
        locConnection = GetConnection(New FileInfo(locPathAndName))
        'Command-Objekt erstellen, mit der ein Befehl an die Datenbank abgesetzt
        'und ein ResultSet eingeholt werden kann
        locCommand = New OleDbCommand("SELECT TOP 15 * FROM Mitarbeiter ORDER BY [Nachname]", locConnection)
        'Wichtig für den DataReader: Verbindung muss geöffnet sein
        locConnection.Open()
        Console.WriteLine("Inhalt der Tabelle Mitarbeiter (erste 15. Datensätze, nach Nachnamen sortiert)")
        'Command-Objekt einweisen, dass er ein Reader-Objekt mit Datenzugriff erstellt
        locDataReader = locCommand.ExecuteReader()
        'Read holt den jeweils nächsten Datensatz und wird False, wenn es keinen weiteren gibt
        Do While locDataReader.Read
            'Alle Datenspalten durchlaufen
            For c As Integer = 0 To locDataReader.FieldCount - 1
                'GetValue holt das eigentliche Datum als Object
                Console.Write(locDataReader.GetValue(c).ToString + vbTab)
            Next
            'Datensatz komplett dargestellt, Zeilenwechsel
            Console.WriteLine()
        Loop
        'Auf Tastatureingabe warten
        Console.ReadLine()

    End Sub

    'Verbindungs-Zeichenkette setzen. Die folgende gilt nur für die Verbindung
    'zu einer Access-Datenbank
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
        'Neues Connection-Objekt generieren und zurückliefern
        Return New OleDbConnection(locConnectionString)

    End Function

    'Findet den Pfad, in dem die aktuelle Assembly (DLL, EXE) ausgeführt wird.
    Private Function GetStartUpPath() As DirectoryInfo
        Dim locAss As [Assembly] = [Assembly].GetExecutingAssembly
        Return New DirectoryInfo(Path.GetDirectoryName(locAss.Location))
    End Function

End Module

