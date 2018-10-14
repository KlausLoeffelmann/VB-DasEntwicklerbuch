Public Class frmAuswertungBeraterReport
    'Variable dient als Parameter für die Abfrage im DataSet
    Public intBeraterAuswahl As Integer
    Private Sub frmAuswertungBeraterReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.ReportBeraterDataTable". Sie können sie bei Bedarf verschieben oder entfernen.

        Me.ReportBeraterDataTableTableAdapter.Fill(Me.HeckTickDataSet.ReportBeraterDataTable, intBeraterAuswahl)

        Me.ReportViewer1.RefreshReport()
    End Sub


End Class

