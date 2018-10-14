Public Class frmMain

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click

        Dim locFormPars As New ADFormularParser(txtFormular.Text)
        lblResult.Text = locFormPars.Result.ToString

    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub

    Private Sub btnCalculateEx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                Handles btnCalculateEx.Click
        Dim locFormPars As New ModifiedFormularParser(txtFormular.Text)
        lblResult.Text = locFormPars.Result.ToString
    End Sub
End Class

Public Class ModifiedFormularParser
    Inherits ADFormularParser

    Sub New(ByVal Formular As String)
        MyBase.New(Formular)
    End Sub

    Public Overrides Sub OnAddFunctions()
        'Benutzerdefinierte Funktion hinzufügen
        Functions.Add(New ADFunction("Double", AddressOf [Double], 1))
    End Sub

    Public Shared Function [Double](ByVal Args() As Double) As Double
        Return Args(0) * 2
    End Function

End Class