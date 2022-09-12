Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "


    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 462)
        Me.Name = "Form1"
        Me.Text = "Stiftbreiten"

    End Sub

#End Region

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        'Auto-Invalidate bei Resize einschalten
        SetStyle(ControlStyles.ResizeRedraw, True)
        'Double-Buffering einschalten, um Flimmern zu verhindern
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

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
