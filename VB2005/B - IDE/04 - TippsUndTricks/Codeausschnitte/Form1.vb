Public Class Form1

    Private Sub btnDateiAusw‰hlen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatei1Ausw‰hlen.Click

        'Eine neue OpenFileDialog-Klasse instanzieren
        Dim datei÷ffnenDialog As New OpenFileDialog

        'Alles Weitere bezieht sich nun darauf, bis ëEnd Withí
        With datei÷ffnenDialog
            .CheckFileExists = True ' Datei muss existieren
            .CheckPathExists = True ' der Pfad ebenfalls
            .DefaultExt = "*.txt"   ' Standardendung ist *.TXT

            'Alle angezeigten Dateifilter werden folgendermaﬂen angegeben
            .Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"

            'Diese Enum-Variable nimmt das Dialogergebnis (OK, Abbrechen) entgegen
            Dim dialogErgebnis As DialogResult = .ShowDialog

            'Falls das Dialogergebnis 'Abbrechen' war, 
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                'raus hier!
                Exit Sub
            End If
            txtDateiname1.Text = .FileName
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub btnDatei2Ausw‰hlen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatei2Ausw‰hlen.Click

    End Sub
End Class
