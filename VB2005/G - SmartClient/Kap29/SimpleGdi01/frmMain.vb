Public Class frmMain

    Private Sub btnLinieZeichnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinieZeichnen.Click

        Dim g As Graphics

        'Ermittelt das Graphics-Objekt, das zu einem bestimmten
        'Window gehört, dessen Handle (ID) zur Identifizierung dient.
        g = Graphics.FromHwnd(Me.Handle)

        'Schwarze, ein Pixel dünne Linie zeichnen von (0,0) zu (500,500).
        'Koordinaten werden standardmäßig in Pixel angegeben;
        '(0,0) liegt in der linken, oberen Ecke des Client-Bereichs.
        g.DrawLine(New Pen(Color.Black), 0, 0, 500, 500)

    End Sub

End Class
