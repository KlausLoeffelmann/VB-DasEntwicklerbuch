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

            ProjektdatenEinfügen(locConnection, "Orcas", " (VS 2007) Schreiben des Entwicklerbuchs", _
                                 #2/1/2007#, #12/31/2007#, "Büro")

            ProjektdatenEinfügen(locConnection, "Katmai", "(SQL Server 2005) Schreiben des Crash-Kurs", _
                                 #3/1/2007#, #1/31/2008#, "Büro")

            Console.WriteLine("Betrachten Sie die hinzugefügten Daten nun im Server-Explorer")
            Console.WriteLine("Drücken Sie anschließend Return")
            Console.WriteLine()
            Console.ReadLine()

            ProjektdatenÄndern(locConnection, "Katmai", "(SQL Server 2007) Schreiben des Crash-Kurses", _
                                 #2/1/2007#, #10/31/2007#, "Ruprechts Büro")

            Console.WriteLine("Betrachten Sie die geänderten Daten nun im Server-Explorer")
            Console.WriteLine("Drücken Sie anschließend Return")
            Console.ReadLine()
        End Using

    End Sub

    Private Sub ProjektdatenEinfügen(ByVal Con As SqlConnection, ByVal Projektname As String, _
                                     ByVal Beschreibung As String, ByVal Startzeitpunkt As Date, _
                                        ByVal Endzeitpunkt As Date, ByVal Ausführungsort As String)
        Dim locCommand As SqlCommand
        Dim locSQLString As String = "INSERT INTO [Projekte] "

        locSQLString += "([Projektname],[Projektbeschreibung],[Startzeitpunkt],[Endzeitpunkt], [Ausführungsort])"
        locSQLString += " VALUES ('" + Projektname + "',"
        locSQLString += "'" + Beschreibung + "',"
        locSQLString += "'" + Startzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += "'" + Endzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += "'" + Ausführungsort + "')"
        Console.WriteLine(locSQLString)

        locCommand = New SqlCommand(locSQLString, Con)
        locCommand.ExecuteNonQuery()
    End Sub

    Private Sub ProjektdatenÄndern(ByVal Con As SqlConnection, ByVal Projektname As String, _
                                     ByVal Beschreibung As String, ByVal Startzeitpunkt As Date, _
                                        ByVal Endzeitpunkt As Date, ByVal Ausführungsort As String)

        Dim locCommand As SqlCommand
        Dim locSQLString As String = "UPDATE [Projekte] SET "

        locSQLString += " [Projektbeschreibung]='" + Beschreibung + "',"
        locSQLString += " [Startzeitpunkt]='" + Startzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += " [Endzeitpunkt]='" + Endzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += " [Ausführungsort]='" + Ausführungsort + "'"
        locSQLString += " WHERE Projektname='" + Projektname + "'"

        Console.WriteLine(locSQLString)

        locCommand = New SqlCommand(locSQLString, Con)
        locCommand.ExecuteNonQuery()
    End Sub
End Module

