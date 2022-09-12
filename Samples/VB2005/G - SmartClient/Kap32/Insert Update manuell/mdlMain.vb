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

            ProjektdatenEinf�gen(locConnection, "Orcas", " (VS 2007) Schreiben des Entwicklerbuchs", _
                                 #2/1/2007#, #12/31/2007#, "B�ro")

            ProjektdatenEinf�gen(locConnection, "Katmai", "(SQL Server 2005) Schreiben des Crash-Kurs", _
                                 #3/1/2007#, #1/31/2008#, "B�ro")

            Console.WriteLine("Betrachten Sie die hinzugef�gten Daten nun im Server-Explorer")
            Console.WriteLine("Dr�cken Sie anschlie�end Return")
            Console.WriteLine()
            Console.ReadLine()

            Projektdaten�ndern(locConnection, "Katmai", "(SQL Server 2007) Schreiben des Crash-Kurses", _
                                 #2/1/2007#, #10/31/2007#, "Ruprechts B�ro")

            Console.WriteLine("Betrachten Sie die ge�nderten Daten nun im Server-Explorer")
            Console.WriteLine("Dr�cken Sie anschlie�end Return")
            Console.ReadLine()
        End Using

    End Sub

    Private Sub ProjektdatenEinf�gen(ByVal Con As SqlConnection, ByVal Projektname As String, _
                                     ByVal Beschreibung As String, ByVal Startzeitpunkt As Date, _
                                        ByVal Endzeitpunkt As Date, ByVal Ausf�hrungsort As String)
        Dim locCommand As SqlCommand
        Dim locSQLString As String = "INSERT INTO [Projekte] "

        locSQLString += "([Projektname],[Projektbeschreibung],[Startzeitpunkt],[Endzeitpunkt], [Ausf�hrungsort])"
        locSQLString += " VALUES ('" + Projektname + "',"
        locSQLString += "'" + Beschreibung + "',"
        locSQLString += "'" + Startzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += "'" + Endzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += "'" + Ausf�hrungsort + "')"
        Console.WriteLine(locSQLString)

        locCommand = New SqlCommand(locSQLString, Con)
        locCommand.ExecuteNonQuery()
    End Sub

    Private Sub Projektdaten�ndern(ByVal Con As SqlConnection, ByVal Projektname As String, _
                                     ByVal Beschreibung As String, ByVal Startzeitpunkt As Date, _
                                        ByVal Endzeitpunkt As Date, ByVal Ausf�hrungsort As String)

        Dim locCommand As SqlCommand
        Dim locSQLString As String = "UPDATE [Projekte] SET "

        locSQLString += " [Projektbeschreibung]='" + Beschreibung + "',"
        locSQLString += " [Startzeitpunkt]='" + Startzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += " [Endzeitpunkt]='" + Endzeitpunkt.ToString("dd.MM.yyyy") + "',"
        locSQLString += " [Ausf�hrungsort]='" + Ausf�hrungsort + "'"
        locSQLString += " WHERE Projektname='" + Projektname + "'"

        Console.WriteLine(locSQLString)

        locCommand = New SqlCommand(locSQLString, Con)
        locCommand.ExecuteNonQuery()
    End Sub
End Module

