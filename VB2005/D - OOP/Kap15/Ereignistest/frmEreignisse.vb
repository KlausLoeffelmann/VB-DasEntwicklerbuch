Public Class frmEreignisse

    Private Sub Button1Und2Ereignisse(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles Button1.Click, Button2.Click, Button3.Click

        'Eine MessageBox wird dargestellt, wenn der Anwender Button2 oder Button3 ausl�st.
        MessageBox.Show(sender.ToString & " wurde gedr�ckt!", "Ereignisbehandlung ergab:")

        'Schaltfl�che, die gedr�ckt wurde, rot einf�rben.

        'FEHLER! So geht es nicht, da Sender vom Typ Object ist:
        'sender.Backcolor = Color.Red

        'So geht es, denn es gibt nur Schaltfl�chen, also
        'ist es sicher in Button zu casten:
        Dim locGedr�ckterButton As Button
        locGedr�ckterButton = DirectCast(sender, Button)

        'Jetzt klappt es mit dem Roteinf�rben
        locGedr�ckterButton.BackColor = Color.Red
    End Sub
End Class
