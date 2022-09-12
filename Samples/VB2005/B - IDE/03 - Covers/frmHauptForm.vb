Option Strict On

Imports System.Net.Mail
Imports System.ComponentModel

Public Class frmHauptForm

    Private myBilddateiname As String

    Private Sub btnInlayDrucken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInlayDrucken.Click

        'Die Struktur FontSettings, die alle Font-Einstellungen enthält,
        'aus der Settings-Datei lesen.

        'Die einzelnen Coverdatenbestandteile aus
        'den Steuerelementen lesen
        Dim locCoverInhalt As New CoverInhalt
        locCoverInhalt.FilmTitel = txtNameDesFilms.Text
        locCoverInhalt.Schauspieler = txtSchauspieler.Text
        locCoverInhalt.Beschreibung = txtKurzbeschreibung.Text
        locCoverInhalt.Coverbild = picCoverbild.Image

        'Die Druckvorschau aufrufen:
        'Wir brauchen dazu eine neue Instanz des Formulars.
        'Es ginge zwar auch direkt über den Klassennamen ohne Instanzierung - 
        'aber das ist nicht OOP und wird boykottiert ;-)
        Dim locCoverDruckenForm As New frmCoverDrucken
        locCoverDruckenForm.DialogDarstellen(locCoverInhalt)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Das geht auch anders!
        Me.Close()
    End Sub

    ' Die folgende Methode ist ausgeblendet:
    Private Sub btnCoverbildWählen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCoverbildWählen.Click
        'Neue Instanz des OpenFileDialogs
        Dim locOfd As New OpenFileDialog

        'Parameter für den OpenFileDialog setzen
        With locOfd
            locOfd.CheckFileExists = True
            locOfd.DefaultExt = "*.bmp"
            locOfd.Filter = "JPeg-Bilder (*.jpg)|*.jpg|Windows Bitmap (*.bmp)|*.bmp|Alle Dateien (*.*)|*.*"

            'OpenFileDialog darstellen
            Dim locDr As DialogResult = locOfd.ShowDialog()
            'Falls Abbrechen angeklickt wurde...
            If locDr = Windows.Forms.DialogResult.Cancel Then
                '...nichts machen.
                Return
            End If

            'Bilddateinamen für das Speichern nach 
            'Programmende zwischenspeichern
            myBilddateiname = locOfd.FileName

            'Neues Image-Objekt, dass aus der Bilddatei entsteht
            picCoverbild.Image = GetCoverImage(myBilddateiname)
        End With
    End Sub

    Private Sub btnEingabenLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEingabenLöschen.Click
        'DialogResult ist eine Enum, die Dialogbox-"Ergebnisse" aufnimmt.
        Dim locDr As DialogResult
        'Nachfragen, ob gelöscht werden soll.
        locDr = MessageBox.Show("Sind Sie sicher?", "Eingaben löschen?", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        'Falls ja, dann alle Steuerelementinhalte zurücksetzen.
        If locDr = Windows.Forms.DialogResult.Yes Then
            txtKurzbeschreibung.Text = ""
            txtNameDesFilms.Text = ""
            txtSchauspieler.Text = ""
            myBilddateiname = ""
            picCoverbild.Image = Nothing
        End If
    End Sub

    'Das Hauptformular wird geschlossen - 
    'wir speichern die Daten der Maske in den Settings
    Private Sub frmHauptForm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.LetzteBeschreibung = txtKurzbeschreibung.Text
        My.Settings.LetzterFilmname = txtNameDesFilms.Text
        My.Settings.LetzterSchauspieler = txtSchauspieler.Text
        My.Settings.LetzterCoverbildDateiname = myBilddateiname
    End Sub

    Private Sub frmHauptForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Alle Eingabefelder mit den Settings vorbelegen
        txtKurzbeschreibung.Text = My.Settings.LetzteBeschreibung
        txtNameDesFilms.Text = My.Settings.LetzterFilmname
        txtSchauspieler.Text = My.Settings.LetzterSchauspieler

        'Selbe wie oben
        Dim locImage As Image = GetCoverImage(My.Settings.LetzterCoverbildDateiname)
        picCoverbild.Image = locImage
    End Sub

    ''' <summary>
    ''' Lädt ein Bild, so vorhanden, aus einer Datei und liefert das Bild als Image (oder Nothing) zurück.
    ''' </summary>
    ''' <param name="CoverbildDateiname">Name der Datei</param>
    ''' <returns>Bild aus der Bilddatei mit dem angegebenen Namen als Image-Objekt.</returns>
    ''' <remarks>Erstellt von Klaus Löffelmann am 26.10.2005</remarks>
    Function GetCoverImage(ByVal CoverbildDateiname As String) As Image
        Dim locImage As Image
        If CoverbildDateiname IsNot Nothing AndAlso CoverbildDateiname <> "" Then
            Try
                'Versuche das hier ohne Fehler, und...
                locImage = Image.FromFile(CoverbildDateiname)
                '...wenn kein Fehler auftrat, liefere das Ergebnis zurück:
                Return locImage
            Catch ex As Exception
                'Beim Auftreten eines Fehlers, landet man hier.

                Dim message As New MailMessage("absender@adresse", "an@adresse", _
                                 "Betreff", "Nachrichtentext")
                Dim emailClient As New SmtpClient("E-Mail-Servername")
                emailClient.Send(message)
            End Try
        End If
        Return Nothing
    End Function
End Class
