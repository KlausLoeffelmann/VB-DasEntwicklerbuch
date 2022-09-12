Public Class frmBerater

    Private Sub BeraterBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeraterBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.BeraterBindingSource.EndEdit()
        Me.BeraterTableAdapter.Update(Me.HeckTickDataSet.Berater)

    End Sub

    Private Sub frmBerater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.Zeiten". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ZeitenTableAdapter.Fill(Me.HeckTickDataSet.Zeiten)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.Berater". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.BeraterTableAdapter.Fill(Me.HeckTickDataSet.Berater)

    End Sub

    Private Sub btnSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.BeraterBindingSource.EndEdit()
        Me.BeraterTableAdapter.Update(Me.HeckTickDataSet.Berater)
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim frmBeraterSuchen As New frmBeraterSuchen
        frmBeraterSuchen.StartPosition = FormStartPosition.CenterScreen
        frmBeraterSuchen.Show()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.BindingContext(BeraterBindingSource).Position = 3
        Dim custDV As DataView = New DataView(HeckTickDataSet.Tables("Berater"), _
        "Nachname = 'Löffelmann'", _
        "Nachname", _
        DataViewRowState.CurrentRows)
        Me.BeraterBindingSource.DataSource = custDV


    End Sub
End Class