'Wichtig: In diesem Namespace befinden sich die SQL Server ADO-Klassen
Imports System.Data.SqlClient

Module mdlMain

    Sub Main()
        Dim locConnection As SqlConnection
        Dim locCommand As SqlCommand
        Dim locDataReader As SqlDataReader

        'Connection-Objekt holen, damit die Datenbankverbindung hergestellt werden kann
        locConnection = New SqlConnection _
                        ("Data Source=.\SQLExpress;Initial Catalog=Hecktick;Integrated Security=True")

        'W�rden Sie den "gemischten Modus" verwenden, w�re folgendes die richtige Wahl.
        'Aber aufgepasst: Das Passwort steht dann im Quellcode und kann leicht gefunden werden!
        'Eine Verschl�sselung des Passwortes wenigstens mit einfachen Mitteln w�re dann angezeigt.
        'locConnection = New SqlConnection _
        '                ("Data Source=.\SQLExpress;Initial Catalog=Hecktick;User ID=sa; Password=Irgendwas")

        'Wichtig: Verbindung muss ge�ffnet sein
        locConnection.Open()

        'Command-Objekt erstellen, mit der ein Befehl an die Datenbank abgesetzt
        'und ein ResultSet eingeholt werden kann
        locCommand = New SqlCommand("SELECT TOP 15 * FROM Berater ORDER BY [Nachname]", locConnection)

        'Damit sorgen wir daf�r, dass die Verbindung wieder geschlossen wird,
        'wenn locConnection aus dem Using-Scope herausl�uft.
        Using locConnection
            Console.WriteLine("Inhalt Tabelle Berater (ersten 15 Datens�tze, nach Nachnamen sortiert)")

            'Command-Objekt einweisen, dass er ein Reader-Objekt mit Datenzugriff erstellt
            locDataReader = locCommand.ExecuteReader()

            'Feststellen, ob �berhaupt Daten vorhanden sind:
            If locDataReader.HasRows Then
                'Read holt den jeweils n�chsten Datensatz und wird False, wenn es keinen weiteren gibt
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
            End If
        End Using
    End Sub

End Module

