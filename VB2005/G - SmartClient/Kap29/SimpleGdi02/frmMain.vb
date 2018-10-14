Public Class frmMain

    'Klassenweiter Member, der von Click und OnPaint aus zug�nglich ist.
    Private myDrawLineFlag As Boolean

    Private Sub btnLinieZeichnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinieZeichnen.Click

        'Ab sofort darf gezeichnet werden!
        myDrawLineFlag = True
        'Client-Bereich f�r ung�ltig erkl�ren --> OnPaint wird ausgel�st,
        'und damit, da myDrawLineFlag jetzt true ist, die Linie gezeichnet.
        Me.Invalidate()

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        If myDrawLineFlag Then
            Dim g As Graphics = e.Graphics

            'Ermittelt das Graphics-Objekt, das zu einem bestimmten
            'Window geh�rt, dessen Handle (ID) zur Identifizierung dient.
            g = Graphics.FromHwnd(Me.Handle)

            'Schwarze, ein Pixel d�nne Linie zeichnen von (0,0) zu (500,500).
            'Koordinaten werden standardm��ig in Pixel angegeben;
            '(0,0) liegt in der linken, oberen Ecke des Client-Bereichs.
            g.DrawLine(New Pen(Color.Black), 0, 0, 500, 500)
        End If
    End Sub
End Class
