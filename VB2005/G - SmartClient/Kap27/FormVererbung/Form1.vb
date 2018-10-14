Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim locString As String = ""

        For Each locControl As Control In Me.Controls
            If TypeOf locControl Is TextBox Then
                locString += "Inhalt von " + locControl.Name + ": "
                locString += DirectCast(locControl, TextBox).Text + vbNewLine
            End If
        Next
        locString = "Inhalt der TextBox-Komponenten im Formular:" + _
                    vbNewLine + vbNewLine + locString
        MessageBox.Show(locString, "Hinweis:")
    End Sub
End Class
