Public Class frmEreignisse

    Private Sub EreignisSchaltfläche1(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button1.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button1 auslöst.
        MessageBox.Show("Button 1 wurde gedrückt!")

    End Sub

    Private Sub Button1Und2Ereignisse(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button2.Click, Button3.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button2 oder Button3 auslöst.
        MessageBox.Show(sender.ToString & "wurde gedrückt!")

    End Sub
End Class
