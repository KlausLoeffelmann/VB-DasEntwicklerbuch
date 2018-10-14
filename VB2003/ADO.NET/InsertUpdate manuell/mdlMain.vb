
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

    Private Sub MaschinenDatenEinf�gen(ByVal Con As OleDbConnection, ByVal Typbezeichnung As String, ByVal Beschreibung As String, _
                                        ByVal Standort As String, ByVal WartungN�tig As Boolean)
        Dim locCommand As OleDbCommand
        Dim locSQLString As String = "INSERT INTO [Maschinen] "

        locSQLString += "([Typbezeichnung],[Beschreibung],[Standort],[WartungN�tig])"
        locSQLString += " VALUES (""" + Typbezeichnung + ""","
        locSQLString += """" + Beschreibung + ""","
        locSQLString += """" + Standort + ""","
        locSQLString += CStr(IIf(WartungN�tig, -1, 0))
        locSQLString += ")"
        Console.WriteLine(locSQLString)

        locCommand = New OleDbCommand(locSQLString, Con)
        Con.Open()
        locCommand.ExecuteNonQuery()
        Con.Close()
    End Sub

    Private Sub Maschinendaten�ndern(ByVal Con As OleDbConnection, ByVal Zu�nderndeMaschine As String, ByVal Beschreibung As String, _
                                     ByVal Standort As String, ByVal WartungN�tig As Boolean)

        Dim locCommand As OleDbCommand
        Dim locSQLString As String = "UPDATE [Maschinen] SET "

        locSQLString += " [Beschreibung]=""" + Beschreibung + ""","
        locSQLString += "[Standort]=""" + Standort + ""","
        locSQLString += "[WartungN�tig]=" + CStr(IIf(WartungN�tig, -1, 0))
        locSQLString += " WHERE [Typbezeichnung]=""" + Zu�nderndeMaschine + """"
        Console.WriteLine(locSQLString)

        locCommand = New OleDbCommand(locSQLString, Con)
        Con.Open()
        locCommand.ExecuteNonQuery()
        Con.Close()

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

