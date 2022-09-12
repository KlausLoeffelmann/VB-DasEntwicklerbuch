Public Class frmEreignisse

    Private Sub Button1Und2Ereignisse(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button1.Click, Button2.Click, Button3.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button2 oder Button3 auslöst.
        MessageBox.Show(sender.ToString & " wurde gedrückt!", "Ereignisbehandlung ergab:")

        'Schaltfläche, die gedrückt wurde, rot einfärben.

        'FEHLER! So geht es nicht, da Sender vom Typ Object ist:
        'sender.Backcolor = Color.Red

        'So geht es, denn es gibt nur Schaltflächen, also
        'ist es sicher in Button zu casten:
        Dim locGedrückterButton As Button
        locGedrückterButton = DirectCast(sender, Button)

        'Jetzt klappt es mit dem Roteinfärben
        locGedrückterButton.BackColor = Color.Red
    End Sub
End Class
