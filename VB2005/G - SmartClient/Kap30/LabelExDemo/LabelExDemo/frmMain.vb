Public Class frmMain

    Private Sub btnFlashIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlashIt.Click
        AdLabelExToFlash1.Flash = Not AdLabelExToFlash1.Flash
        AdLabelExToFlash2.Flash = Not AdLabelExToFlash2.Flash
        AdLabelExToFlash3.Flash = Not AdLabelExToFlash3.Flash
    End Sub
End Class
