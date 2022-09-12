Public Class frmMain

    Sub New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' F�gen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        'Double Buffering einschalten, um Flimmern zu vermeiden
        Me.DoubleBuffered = True

        'Auto-Invalidate bei Resize einschalten
        SetStyle(ControlStyles.ResizeRedraw, True)
    End Sub

    'Zeichnet jeweils ein Rechteck in einer dicken, schwarzen und einer
    'd�nnen gelben Umrandung.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim locSchwarzerStift As New Pen(Color.Black, 10)
        Dim locGelberStift As New Pen(Color.Yellow, 1)
        Dim locF�rRechteck As New Rectangle(20, 20, _
                                  ClientSize.Width - 40, ClientSize.Height - 40)
        Dim locOffsetDrittel As New Size(ClientSize.Width \ 6, ClientSize.Height \ 6)
        Dim locF�rKreis As New Rectangle(locOffsetDrittel.Width, _
                                         locOffsetDrittel.Height, _
                                         ClientSize.Width - 2 * locOffsetDrittel.Width, _
                                         ClientSize.Height - 2 * locOffsetDrittel.Height)
        e.Graphics.DrawRectangle(locSchwarzerStift, _
                                 locF�rRechteck)
        e.Graphics.DrawRectangle(locGelberStift, _
                                 locF�rRechteck)
        e.Graphics.DrawEllipse(locSchwarzerStift, _
                                 locF�rKreis)
        e.Graphics.DrawEllipse(locGelberStift, _
                                 locF�rKreis)
    End Sub

End Class
