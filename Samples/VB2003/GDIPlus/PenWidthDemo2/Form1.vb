Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private myDoppelklickTrigger As Boolean

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
        Me.Text = "Stiftbreiten - die Zweite!"

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
        'Nur um Tipparbeit zu sparen
        Dim g As Graphics = e.Graphics
        'Hier werden die Eckpunkte des offenen Dreiecks gespeichert
        Dim locDreiecksPunkte(3) As Point
        'Diese Variable dient nur dem Sparen der Tipparbeit
        Dim locCB As Size = Me.ClientSize
        'Hier werden die Eckpunkte des Dreiecks definiert
        Dim c As Integer
        'Zählvariable für die Schleife zum Zeichnen der Linien
        locDreiecksPunkte(0) = New Point(locCB.Width \ 5, (locCB.Height \ 4) * 3)
        locDreiecksPunkte(1) = New Point(locCB.Width \ 2, locCB.Height \ 4)
        locDreiecksPunkte(2) = New Point((locCB.Width \ 5) * 4, (locCB.Height \ 4) * 3)
        locDreiecksPunkte(3) = New Point((locCB.Width \ 5) * 2, (locCB.Height \ 4) * 3)

        'Zwei mögliche Malverfahren, dass sich bei jedem Doppelklick ändert:
        If Not myDoppelklickTrigger Then
            'Einzelne Linien malen
            Dim locPen As New Pen(Color.Black, 15)
            'Alle Eckpunkte per Linie miteinander verbinden
            For c = 0 To locDreiecksPunkte.Length - 2
                g.DrawLine(locPen, locDreiecksPunkte(c).X, locDreiecksPunkte(c).Y, _
                            locDreiecksPunkte(c + 1).X, locDreiecksPunkte(c + 1).Y)
            Next

            'das Gleiche nochmal in gelb und dünn
            locPen = New Pen(Color.Yellow, 1)
            For c = 0 To locDreiecksPunkte.Length - 2
                g.DrawLine(locPen, locDreiecksPunkte(c).X, locDreiecksPunkte(c).Y, _
                            locDreiecksPunkte(c + 1).X, locDreiecksPunkte(c + 1).Y)
            Next

        Else
            '...oder als Linienzug mit Hilfe des GraphicPaths-Objektes:
            Dim locPen As New Pen(Color.Black, 15)
            Dim locLinienverbund As New GraphicsPath
            For c = 0 To locDreiecksPunkte.Length - 2
                locLinienverbund.AddLine(locDreiecksPunkte(c).X, locDreiecksPunkte(c).Y, _
                            locDreiecksPunkte(c + 1).X, locDreiecksPunkte(c + 1).Y)
            Next

            'Mit dieser Anweisung würden Sie den Endpunkt des Linienzuges
            'mit dem Startpunkt verbinden und so die Figur schließen
            'locFigur.CloseFigure()
            e.Graphics.DrawPath(locPen, locLinienverbund)
            locPen = New Pen(Color.Yellow, 1)

            e.Graphics.DrawPath(locPen, locLinienverbund)
            e.Graphics.DrawPath(locPen, locLinienverbund)
        End If

    End Sub

    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        myDoppelklickTrigger = Not myDoppelklickTrigger
        Invalidate()
    End Sub
End Class
