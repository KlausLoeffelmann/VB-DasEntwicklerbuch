Public Class frmAuswertungProjekteReport
    Public intAuswertungProjekt As Integer

    Private Sub frmAuswertungBerater2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: Diese Codezeile l�dt Daten in die Tabelle "HeckTickDataSet.ReportProjektDataTable". Sie k�nnen sie bei Bedarf verschieben oder entfernen.
        Me.ReportProjektDataTableTableAdapter.Fill(Me.HeckTickDataSet.ReportProjektDataTable, intAuswertungProjekt)

        Me.ReportViewer1.RefreshReport()
    End Sub


End Class