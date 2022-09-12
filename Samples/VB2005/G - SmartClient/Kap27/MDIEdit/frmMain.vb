Public Class frmMain

    'Der "Unbenannt"-Dateinamenzähler.
    Private myUnbekanntesDokumentZähler As Integer

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        'Den "Unbenannt"-Dateinamenzähler beim Laden des Formulars initialisieren.
        myUnbekanntesDokumentZähler = 1
    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Datei den Menüpunkt Neues Dokument auswählt.
    Private Sub NeuesDokument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNeuesDokument.Click
        'Neue Instanz des MDI-Dokuments erstellen.
        Dim locFrmTextdokument As New frmTextdokument

        'Dieser Instanz mitteilen, dass es ein MDI-untergeordnetes Fenster werden soll.
        locFrmTextdokument.MdiParent = Me

        'Die Funktion zum Anzeigen des neuen untergeordneten Fensters aufrufen.
        locFrmTextdokument.NeuesTextdokument(myUnbekanntesDokumentZähler)

        'Den "Unbenannt"-Dateinamenzähler um eins erhöhen.
        myUnbekanntesDokumentZähler += 1
    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Datei den Menüpunkt Öffnen auswählt.
    Private Sub tsmÖffnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmÖffnen.Click

        Dim dateiÖffnenDialog As New OpenFileDialog
        With dateiÖffnenDialog
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.txt"
            .Filter = "Textdateien" & " (" & "*.txt" & ")|" & "*.txt" & "|Alle Dateien (*.*)|*.*"

            'Dateinamen der zu öffnenden Textdatei ermitteln.
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Neue Instanz des MDI-Dokuments erstellen.
            Dim locFrmTextdokument As New frmTextdokument

            'Dieser Instanz mitteilen, dass es ein MDI-untergeordnetes Fenster werden soll.
            locFrmTextdokument.MdiParent = Me

            'Die Funktion zum Laden des Textes und Anzeigen des untergeordneten Fensters aufrufen.
            locFrmTextdokument.TextdokumentÖffnen(.FileName)
        End With
    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Extras den Menüpunkt Optionen auswählt.
    Private Sub tsmOptionen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmOptionen.Click
        MessageBox.Show("Hier für die Optionen-Funktion implementiert werden")
    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Datei den Menüpunkt Programm beenden auswählt.
    Private Sub tsmProgrammBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProgrammBeenden.Click
        Me.Close()
    End Sub

    'Wird beim Schließen des Formulars aufgerufen
    Protected Overrides Sub OnFormClosing(ByVal e As System.Windows.Forms.FormClosingEventArgs)
        MyBase.OnFormClosing(e)

        'Gibt es untergeordnete Fenster?
        If Me.MdiChildren IsNot Nothing AndAlso Me.MdiChildren.Length > 0 Then
            Dim locFenstertitel As String = ""

            'Die Fenstertitel der untergeordneten Fenster ermitteln
            For Each locForm As Form In Me.MdiChildren
                locFenstertitel &= locForm.Text & vbNewLine
            Next

            'Warnhinweis mit der Liste der noch offenen Fenster.
            Dim locDr As DialogResult = MessageBox.Show("Folgende Fenster sind noch geöffnet:" & _
                                vbNewLine & vbNewLine & locFenstertitel & _
                                vbNewLine & vbNewLine & _
                                "Soll die Anwendung dennoch geschlossen werden?", _
                                "Anwendung schließen:", MessageBoxButtons.YesNo, _
                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If locDr = Windows.Forms.DialogResult.No Then
                'Der Anwender hat Nein gesagt!
                'Das Fenster bleibt offen.
                e.Cancel = True
            End If
        End If
    End Sub
End Class
