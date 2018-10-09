Public Class Form1

    Private mydoppelGeklickt As Boolean

    'OnLoad überschreiben - damit das Load-Ereignis behandeln, ...
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        '...und hier den Fenstertext setzen.
        Me.Text = "Doppelklicken Sie in das Fenster, um die Grafik darzustellen."
    End Sub

    'Wir hätten auch das Load-Ereignis behandeln können...
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
                Handles Me.Load
        'aber warum ein Ereignis der Instanz in der Instanz behandeln,
        'die das Ereignis auslöst? Dann lieber an der Stelle eingreifen,
        'die das Ereignis auslösen, und das ist OnLoad.
    End Sub

    'Grafik wird ins Fenster gemalt, sobald der Anwender doppelklickt.
    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        MyBase.OnDoubleClick(e)
        Dim g As Graphics = Graphics.FromHwnd(Me.Handle)
        DrawDemo(g)
        mydoppelGeklickt = True
    End Sub

    'Und hier wird gemalt.
    Public Sub DrawDemo(ByVal g As Graphics)

        'Erstmal den Fensterinhalt löschen.
        g.Clear(Color.White)

        'tatsächliche Breite des Clientbereichs ermitteln und merken
        Dim tatsächlicheBreiteGemerkt = Me.ClientSize.Width
        Dim linienZähler = 0

        'Jeden 5. Pixel berücksichtigen
        For x = 0 To tatsächlicheBreiteGemerkt Step 5

            'Erst die Linie von links oben nach rechts unten malen.
            g.DrawLine(Pens.Black, 0, 0, x, Me.ClientSize.Height)

            'Und dann noch eine von rechts oben nach links unten.
            g.DrawLine(Pens.Black, tatsächlicheBreiteGemerkt, _
                                0, tatsächlicheBreiteGemerkt - x, _
                                Me.ClientSize.Height)

            'Linienzähler aktualisieren
            linienZähler += 2
        Next

        'Im Fenstertitel über die Anzahl gemalter Linien informieren.
        Me.Text = "Anzahl Linien im Fenster: " & linienZähler
    End Sub

    'Wird ausgelöst, wenn der Fensterinhalt zerstört wurde
    'und neugezeichnet werden muss
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Nur wenn der Doppelklick bereits stattgefunden hat.
        If mydoppelGeklickt Then
            '
            DrawDemo(e.Graphics)
        End If
    End Sub
End Class
