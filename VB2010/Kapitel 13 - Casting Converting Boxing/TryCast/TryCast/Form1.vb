Public Class Form1

    Private Sub Control_Click(ByVal sender As Object,
                              ByVal e As System.EventArgs) _
                          Handles TextBox1.Click, TextBox2.Click,
                          Button1.Click, Button2.Click

        'Wird handeln hier alle 4 Click-Ereignisse, in
        'sender kann also auf eine TextBox oder einen Button verweisen:

        'TryCast-Demo:
        Dim button = TryCast(sender, Button)
        If button IsNot Nothing Then
            MessageBox.Show("Eine Schaltfläche wurde angeklickt!")
        End If

        'IsAssinableForm-Demo
        If GetType(TextBox).IsAssignableFrom(sender.GetType) Then
            MessageBox.Show("Eine TextBox oder eine Ableitung wurde angeklickt!")
        End If
    End Sub

End Class
