Public Class frmZeiten

    Private Sub ZeitenBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.ZeitenBindingSource.EndEdit()
        Me.ZeitenTableAdapter.Update(Me.HeckTickDataSet.Zeiten)

    End Sub

    Private Sub frmZeiten_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile l�dt Daten in die Tabelle "HeckTickDataSet.Berater". Sie k�nnen sie bei Bedarf verschieben oder entfernen.
        Me.BeraterTableAdapter.Fill(Me.HeckTickDataSet.Berater)
        'TODO: Diese Codezeile l�dt Daten in die Tabelle "HeckTickDataSet.Projekte". Sie k�nnen sie bei Bedarf verschieben oder entfernen.
        Me.ProjekteTableAdapter.Fill(Me.HeckTickDataSet.Projekte)
        'TODO: Diese Codezeile l�dt Daten in die Tabelle "HeckTickDataSet.Zeiten". Sie k�nnen sie bei Bedarf verschieben oder entfernen.
        Me.ZeitenTableAdapter.Fill(Me.HeckTickDataSet.Zeiten)

    End Sub
End Class