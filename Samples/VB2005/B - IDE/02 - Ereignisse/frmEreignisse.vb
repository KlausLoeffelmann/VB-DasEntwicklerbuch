Public Class frmEreignisse

    Private Sub EreignisSchaltfl�che1(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button1.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button1 ausl�st.
        MessageBox.Show("Button 1 wurde gedr�ckt!")

    End Sub

    Private Sub Button1Und2Ereignisse(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button2.Click, Button3.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button2 oder Button3 ausl�st.
        MessageBox.Show(sender.ToString & "wurde gedr�ckt!")

    End Sub
End Class
