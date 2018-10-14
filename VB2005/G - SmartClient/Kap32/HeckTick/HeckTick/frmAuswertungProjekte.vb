Public Class frmAuswertungProjekte
    Dim intIDProjektAuswahl As Integer
    Dim strProjektname As String


    Private Sub frmAuswertungProjekte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ProjekteTableAdapter1.Fill(Me.HeckTickDataSet1.Projekte)
        Me.cbProjekt.DataSource = HeckTickDataSet1.Projekte

        cbProjekt.DisplayMember = "Projektname"
        cbProjekt.ValueMember = "IDProjekte"
    End Sub

    Private Sub btnAuswer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuswer.Click
        Dim dr As DataRowView = CType(cbProjekt.SelectedItem, DataRowView)

        intIDProjektAuswahl = CInt(dr("IDProjekte"))
        strProjektname = CStr(dr("Projektname"))


        'Neue Instanz vom ProjekteReport-Formular erzeugen
        Dim frmAuswertungProjekteReport As New frmAuswertungProjekteReport
        frmAuswertungProjekteReport.intAuswertungProjekt = intIDProjektAuswahl
        frmAuswertungProjekteReport.Text = "Report für das Projekt " & strProjektname
        frmAuswertungProjekteReport.MdiParent = frmMain
        frmAuswertungProjekteReport.Show()
        Me.Close()
    End Sub
End Class