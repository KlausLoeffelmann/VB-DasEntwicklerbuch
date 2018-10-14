Public Class Form1

    Private myOriginalBackcolor As Color

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub txtMatchcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatchcode.GotFocus
        myOriginalBackcolor = txtMatchcode.BackColor
        txtMatchcode.BackColor = Color.Yellow
    End Sub

    Private Sub txtMatchcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMatchcode.LostFocus
        txtMatchcode.BackColor = myOriginalBackcolor
    End Sub

    Private Sub txtNachname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNachname.GotFocus
        myOriginalBackcolor = txtNachname.BackColor
        txtNachname.BackColor = Color.Yellow
    End Sub

    Private Sub txtNachname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNachname.LostFocus
        txtNachname.BackColor = myOriginalBackcolor
    End Sub

    Private Sub txtVorname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVorname.GotFocus
        myOriginalBackcolor = txtVorname.BackColor
        txtVorname.BackColor = Color.Yellow
    End Sub

    Private Sub txtVorname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVorname.LostFocus
        txtVorname.BackColor = myOriginalBackcolor
    End Sub

    Private Sub txtOrt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrt.GotFocus
        myOriginalBackcolor = txtOrt.BackColor
        txtOrt.BackColor = Color.Yellow
    End Sub

    Private Sub txtOrt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOrt.LostFocus
        txtOrt.BackColor = myOriginalBackcolor
    End Sub

End Class
