Public Class frmTextdokument

    ''' <summary>
    ''' Zeigt dieses Formular mit einem leeren Textfeld an
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NeuesTextdokument(ByVal DokumentNr As Integer)
        txtEingabebereich.Text = Nothing

        'Dokumentnamen "Unbenannt_X" im Titel anzeigen.
        Me.Text = "Unbenannt" & DokumentNr

        'Formular nicht-modal anzeigen.
        Me.Show()
    End Sub

    ''' <summary>
    ''' Zeigt dieses Formular an, und lädt eine Textdatei in den Eingabebereich.
    ''' </summary>
    ''' <param name="Dateiname"></param>
    ''' <remarks></remarks>
    Public Sub TextdokumentÖffnen(ByVal Dateiname As String)

        'Textdatei in den Eingabebereich laden.
        txtEingabebereich.Text = My.Computer.FileSystem.ReadAllText(Dateiname)

        'Dateinamen als Dokumentnamen im Titel anzeigen.
        Me.Text = Dateiname

        'Formular nicht-modal anzeigen.
        Me.Show()
    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Datei den Menüpunkt Speichern unter auswählt.
    Private Sub tsmSpeichernUnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSpeichernUnter.Click
        Dim dateiSpeichernDialog As New SaveFileDialog
        With dateiSpeichernDialog

            'Pfad muss vorhanden sein!
            .CheckPathExists = True

            'Warnen, wenn die Datei schon existiert!
            .OverwritePrompt = True

            'Dateinamenerweiterungen einrichten:
            .DefaultExt = "*.txt"
            .Filter = "Textdateien" & " (" & "*.txt" & ")|" & "*.txt" & "|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Textdatei speichern
            My.Computer.FileSystem.WriteAllText(.FileName, txtEingabebereich.Text, False)

            'Fenstertitel ist Dateiname
            Me.Text = .FileName
        End With
    End Sub

    'Wird aufgerufen, wenn der Anwender im Menü Bearbeiten auf Suchen klickt.
    Private Sub tsmSuchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSuchen.Click
        MessageBox.Show("Hier würde die Suchenfunktion implementiert werden!")
    End Sub
End Class