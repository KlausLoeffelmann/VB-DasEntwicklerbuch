Public Class frmMain

    Private Sub btnSerialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialisieren.Click
        Dim locAdresse As New Adresse(txtVorname.Text, _
                                      txtNachname.Text, _
                                      txtStra�e.Text, _
                                      txtPLZOrt.Text)
        'Einen "unm�glichen" Dateinamen verwenden, damit, wie es der Zufall will,
        'nicht eine andere wichtige Datei gleichen Namens �berschrieben wird.
        Adresse.SerializeToFile(locAdresse, "C:\serializedemo_f4e3w21.txt")

        'Info �ber den Datensatz anzeigen
        txtErstelltAm.Text = locAdresse.ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
        txtErstelltVon.Text = locAdresse.ErfasstVon
    End Sub

    Private Sub btnDeserialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnDeserialisieren.Click
        'Adressenobjekt aus Datei deserialisieren
        Dim locAdresse As Adresse = Adresse.SerializeFromFile("C:\serializedemo_f4e3w21.txt")
        'Adressobjektdaten 
        With locAdresse
            txtVorname.Text = .Vorname
            txtNachname.Text = .Nachname
            txtStra�e.Text = .Stra�e
            txtPLZOrt.Text = .PLZOrt
            txtErstelltAm.Text = .ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
            txtErstelltVon.Text = .ErfasstVon
        End With
    End Sub

End Class
