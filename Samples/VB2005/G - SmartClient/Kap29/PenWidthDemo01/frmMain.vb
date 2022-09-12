Public Class frmMain

    Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        'Double Buffering einschalten, um Flimmern zu vermeiden
        Me.DoubleBuffered = True

        'Auto-Invalidate bei Resize einschalten
        SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    'Zeichnet jeweils ein Rechteck in einer dicken, schwarzen und einer
    'dünnen gelben Umrandung.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim locSchwarzerStift As New Pen(Color.Black, 10)
        Dim locGelberStift As New Pen(Color.Yellow, 1)
        Dim locFürRechteck As New Rectangle(20, 20, _
                                  ClientSize.Width - 40, ClientSize.Height - 40)
        Dim locOffsetDrittel As New Size(ClientSize.Width \ 6, ClientSize.Height \ 6)
        Dim locFürKreis As New Rectangle(locOffsetDrittel.Width, _
                                         locOffsetDrittel.Height, _
                                         ClientSize.Width - 2 * locOffsetDrittel.Width, _
                                         ClientSize.Height - 2 * locOffsetDrittel.Height)
        e.Graphics.DrawRectangle(locSchwarzerStift, _
                                 locFürRechteck)
        e.Graphics.DrawRectangle(locGelberStift, _
                                 locFürRechteck)
        e.Graphics.DrawEllipse(locSchwarzerStift, _
                                 locFürKreis)
        e.Graphics.DrawEllipse(locGelberStift, _
                                 locFürKreis)
    End Sub

End Class
