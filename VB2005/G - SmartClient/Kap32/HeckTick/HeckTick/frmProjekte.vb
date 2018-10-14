Public Class frmProjekte

    Private Sub ProjekteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjekteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProjekteBindingSource.EndEdit()
        Me.ProjekteTableAdapter.Update(Me.HeckTickDataSet.Projekte)

    End Sub

    Private Sub frmProjekte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.Projekte". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ProjekteTableAdapter.Fill(Me.HeckTickDataSet.Projekte)

    End Sub
End Class