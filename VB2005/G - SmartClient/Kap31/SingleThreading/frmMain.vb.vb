Public Class Form1

    Private Sub btnZählenStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZählenStarten.Click
        For z As Integer = 0 To 100000
            lblAusgabe.Text = z.ToString
            lblAusgabe.Refresh()
        Next
    End Sub
End Class
