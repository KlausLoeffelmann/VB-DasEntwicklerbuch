Public Class frmAuswertungBeraterReport
    'Variable dient als Parameter f�r die Abfrage im DataSet
    Public intBeraterAuswahl As Integer
    Private Sub frmAuswertungBeraterReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile l�dt Daten in die Tabelle "HeckTickDataSet.ReportBeraterDataTable". Sie k�nnen sie bei Bedarf verschieben oder entfernen.

        Me.ReportBeraterDataTableTableAdapter.Fill(Me.HeckTickDataSet.ReportBeraterDataTable, intBeraterAuswahl)

        Me.ReportViewer1.RefreshReport()
    End Sub


End Class

