Public Class frmAuswertungProjekteReport
    Public intAuswertungProjekt As Integer

    Private Sub frmAuswertungBerater2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.ReportProjektDataTable". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ReportProjektDataTableTableAdapter.Fill(Me.HeckTickDataSet.ReportProjektDataTable, intAuswertungProjekt)

        Me.ReportViewer1.RefreshReport()
    End Sub


End Class