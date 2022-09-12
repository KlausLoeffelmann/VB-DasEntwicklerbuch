Public Class frmMain

    Private Sub btnSerialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialisieren.Click
        Dim locAdresse As New Adresse(txtVorname.Text, _
                                      txtNachname.Text, _
                                      txtStraße.Text, _
                                      txtPLZOrt.Text)
        'Einen "unmöglichen" Dateinamen verwenden, damit, wie es der Zufall will,
        'nicht eine andere wichtige Datei gleichen Namens überschrieben wird.
        If optBinarySerializer.Checked Then
            'Binary Serializer verwenden
            Adresse.SerializeBinToFile(locAdresse, "C:\serializedemo_bin_f4e3w21.bin")
        Else
            'Soap Serializer verwenden
            Adresse.SerializeSoapToFile(locAdresse, "C:\serializedemo_soap_f4e3w21.txt")
        End If

        'Info über den Datensatz anzeigen
        txtErstelltAm.Text = locAdresse.ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
        txtErstelltVon.Text = locAdresse.ErfasstVon
    End Sub

    Private Sub btnDeserialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnDeserialisieren.Click
        Dim locAdresse As Adresse

        'Adressenobjekt aus Datei deserialisieren
        If optBinarySerializer.Checked Then
            locAdresse = Adresse.SerializeBinFromFile("C:\serializedemo_bin_f4e3w21.bin")
        Else
            locAdresse = Adresse.SerializeSoapFromFile("C:\serializedemo_soap_f4e3w21.txt")
        End If

        'Adressobjektdaten im Formular anzeigen
        With locAdresse
            txtVorname.Text = .Vorname
            txtNachname.Text = .Name
            txtStraße.Text = .Straße
            txtPLZOrt.Text = .PLZOrt
            txtErstelltAm.Text = .ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
            txtErstelltVon.Text = .ErfasstVon
        End With
    End Sub

End Class
