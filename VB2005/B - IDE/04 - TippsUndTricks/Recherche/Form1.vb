Imports System.Net
Imports System.Net.Mail

Public Class Form1

    Private Sub btnSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                    Handles btnSendMail.Click

        'Gesucht und gefunden! - Aber Achtung. Die Anmeldedaten werden im Klartext übertragen!
        'Dieses Verfahren also nur bei Nicht-AD-Clients im Intranet anwenden!
        Dim myCred As New NetworkCredential("k_loeffel", "passwort", "ActiveDevelop.local")

        'Das wurde durch die Codeausschnittsbibliothek eingefügt
        Dim message As New MailMessage("VomTestprogramm@loeffelmann.de", _
                            "klaus@loeffelmann.de", _
                            "Testmail", _
                            "Das Programm hat eine Testnachricht versendet!")
        Dim emailClient As New SmtpClient("192.168.0.1")
        'Die Credentials übergeben wir nun!
        emailClient.UseDefaultCredentials = False
        emailClient.Credentials = myCred
        'Und ab dafür!
        emailClient.Send(message)
    End Sub
End Class
