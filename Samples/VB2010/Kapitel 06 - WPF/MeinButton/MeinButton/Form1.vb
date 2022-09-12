Public Class Form1
    Private Sub myButton()
        Dim btnClear As New Button
        btnClear.Width = 80
        btnClear.Height = 25
        btnClear.Location = New Point(50, 50)
        btnClear.Text = "Löschen"
        AddHandler btnClear.Click, AddressOf ClickButton
        Me.Controls.Add(btnClear)
        btnClear.Show()
    End Sub

    Private Sub ClickButton(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("Button 'btnClear' wurde gedrückt")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myButton()
    End Sub
End Class
