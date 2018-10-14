Public Class frmAuswertungBerater
    Dim intBeraterAuswahl As Integer
    Dim strNachname As String
    Dim strVorname As String



    Private Sub frmAuswertung_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BeraterTableAdapter1.Fill(Me.HeckTickDataSet1.Berater)
        'Berater ComboBox binden
        Me.cbName.DataSource = HeckTickDataSet1.Berater

        cbName.DisplayMember = "Nachname"
        cbName.ValueMember = "IDBerater"

    End Sub


    Private Sub btnAuswerten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuswerten.Click
        Dim dr As DataRowView = CType(cbName.SelectedItem, DataRowView)
        intBeraterAuswahl = CInt(dr("IDBerater"))
        strNachname = CStr(dr("Nachname"))
        strVorname = CStr(dr("Vorname"))
        'Neue Instanz des BeraterReport-Formular erzeugen

        Dim report As New frmAuswertungBeraterReport
        report.intBeraterAuswahl = intBeraterAuswahl
        report.Text = "Report für " & strVorname & " " & strNachname
        report.MdiParent = frmMain
        report.Show()
        Me.Close()
    End Sub
End Class