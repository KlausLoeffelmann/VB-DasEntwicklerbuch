Imports System.Drawing.Drawing2D

Public Class frmMain
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
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 438)
        Me.MinimumSize = New System.Drawing.Size(40, 80)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"

    End Sub

#End Region

    'Legt fest, ob das Gitter gezeichnet werden soll, oder nicht.
    Private myDrawGrid As Boolean
    'Bestimmt, wie das Gitte gezeichnet werden soll
    Private myGridStyle As GridStyle
    'Bestimmt die Stiftbreite für das Zeichnen des Gitters/Rasters
    Private myGridLineWidth As Integer
    'Bestimmt die Stiftfarbe für das Zeichnen des Gitters/Rasters
    Private myGridColor As Color
    'Bestimmt die Hintergrundfarbe
    Private myBackground As Color
    'Bestimmt die Farben der oberen Balkenreihe
    Private myBarColors As Color()
    'Bestimmt die Grauschattierungen der darunterliegenden Balkenreihe
    Private myBarShades As Color()
    'Bestimmt die Grauschattierungen der Balkenreihe, in der sich die Beschriftung befindet
    Private myBarTitleShades As Color()
    'Definiert die Anzahl der Gitter-/Rasterspalten
    Private myGridCols As Integer
    'Definiert die Anzahl der Gitter-/Rasterzeilen
    Private myGridRows As Integer
    'Definiert, in Rasterzeilen gerechnet, den Abstand des "Bildes" von oben
    Private myUpperOffset As Integer
    'Definiert den Zeichenmodus
    Private mySmoothingMode As SmoothingMode

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        DrawGrid = True
        GridStyle = GridStyle.Lines
        GridLineWidth = 2
        GridColor = Color.White

        '18 Spalten und 14 Zeilen
        GridCols = 18
        GridRows = 14

        'Bild beginnt in der 3. Reihe
        UpperOffset = 2

        ' Alternative Einstellungen zum Experimentieren
        'DrawGrid = True
        'GridStyle = GridStyle.Dots
        'GridLineWidth = 5
        'GridColor = Color.Blue

        ''18 Spalten und 14 Zeilen
        'GridCols = 22
        'GridRows = 16

        ''Bild beginnt in der 3. Reihe
        'UpperOffset = 5


        'Hintergrund ca. 70% grau
        Background = Color.FromArgb(90, 90, 90)

        'Farben für die Farbbalken
        BarColors = New Color() {Color.Pink, Color.GreenYellow, Color.Magenta, Color.Olive, _
                                   Color.DarkMagenta, Color.DarkRed, Color.Indigo, Color.Black}
        'Farben für die darunterliegenden Grauflächen
        BarShades = New Color() {Color.FromArgb(0, 0, 0), _
                                   Color.FromArgb(90, 90, 90), _
                                   Color.FromArgb(130, 130, 130), _
                                   Color.FromArgb(180, 180, 180), _
                                   Color.FromArgb(255, 255, 255)}
        'Farben für die darunterliegenden Grauflächen der Titelzeile
        BarTitleShades = New Color() {Color.White, _
                                   Color.Black, _
                                   Color.Black, _
                                   Color.Black, _
                                   Color.White}

        'Fenstertitel
        Text = "Testbild .NET"
    End Sub

    'Wird aufgerufen, wenn das Bild aus irgendeinem Grund neu gezeichnet werden muss
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        paintBackground(e.Graphics)
        paintContent(e.Graphics)
    End Sub

    'Wird aufgerufen, wenn das Formular in seiner Größe verändert wird
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Invalidate()
    End Sub

    'Wird aufgerufen, wenn der Hintergrund des Bildes neu gezeichnet werden muss
    Private Sub paintBackground(ByVal g As Graphics)
        Dim locBrush As New SolidBrush(Background)

        g.FillRectangle(locBrush, ClientRectangle)
    End Sub

    'Hier wird der eigentliche Inhalt gezeichnet
    Private Sub paintContent(ByVal g As Graphics)

        Dim locPen As Pen
        Dim locBrush As Brush
        Dim locBarWidth As Single
        Dim locX As Single
        Dim locRectF As RectangleF

        g.SmoothingMode = mySmoothingMode

        'Raster malen im Bedarfsfall
        If DrawGrid Then
            paintGrid(g)
        End If

        'Figuren malen:

        'obere Balkenreihe mit Farbblöcken
        locRectF = New RectangleF(GridSize.Width * 3, GridSize.Height * myUpperOffset, _
                                GridSize.Width * 12, GridSize.Height * 3)
        locBarWidth = locRectF.Width / BarColors.Length / 1
        For i As Integer = 0 To BarColors.Length - 1
            locBrush = New SolidBrush(myBarColors(i))
            locRectF.Width = locBarWidth
            g.FillRectangle(locBrush, locRectF)
            locRectF.X += locBarWidth
        Next

        'darunter liegende Balkenreihe mit Grauschattierungen
        locRectF = New RectangleF(GridSize.Width * 3, GridSize.Height * (UpperOffset + 3), _
                                GridSize.Width * 12, GridSize.Height * 2)
        locBarWidth = locRectF.Width / BarShades.Length / 1
        For i As Integer = 0 To BarShades.Length - 1
            locBrush = New SolidBrush(myBarShades(i))
            locRectF.Width = locBarWidth
            g.FillRectangle(locBrush, locRectF)
            locRectF.X += locBarWidth
        Next

        'darunter liegende Balkenreihe mit Titel
        locRectF = New RectangleF(GridSize.Width * 3, GridSize.Height * (UpperOffset + 5), _
                                GridSize.Width * 12, GridSize.Height)
        locBarWidth = locRectF.Width / BarShades.Length / 1
        For i As Integer = 0 To BarTitleShades.Length - 1
            locBrush = New SolidBrush(myBarTitleShades(i))
            locRectF.Width = locBarWidth
            g.FillRectangle(locBrush, locRectF)
            locRectF.X += locBarWidth
        Next

        'darunter komplette zwei Reihen zunächst weiß
        locBrush = New SolidBrush(Color.White)
        g.FillRectangle(locBrush, GridSize.Width * 3, GridSize.Height * (UpperOffset + 6), _
                    GridSize.Width * 12, GridSize.Height * 2)

        'jeweils zwei Farbverlaufsstreifen...
        locRectF = New RectangleF(GridSize.Width * 3, GridSize.Height * (UpperOffset + 8), _
                                GridSize.Width * 8, GridSize.Height)
        locBrush = New LinearGradientBrush(locRectF, Color.Magenta, Color.Black, LinearGradientMode.Horizontal)
        g.FillRectangle(locBrush, locRectF)

        'der zweite Farbverlaufsstreifen
        locRectF = New RectangleF(GridSize.Width * 3, GridSize.Height * (UpperOffset + 9), _
                                GridSize.Width * 8, GridSize.Height)
        locBrush = New LinearGradientBrush(locRectF, Color.Blue, Color.Black, LinearGradientMode.Horizontal)
        g.FillRectangle(locBrush, locRectF)

        'grauer Kasten neben die Farbverläufe
        locBrush = New SolidBrush(Color.FromArgb(130, 130, 130))
        g.FillRectangle(locBrush, GridSize.Width * 11, GridSize.Height * (UpperOffset + 8), _
                                GridSize.Width * 4, GridSize.Height * 2)

        'Griffele malen
        'Zuerst grauer Kasten als Unterlage
        g.FillRectangle(locBrush, GridSize.Width * 4.5F, GridSize.Height * (UpperOffset + 6), _
                                GridSize.Width * 10.5F, GridSize.Height)

        'dann das linke, größere Geriffele malen
        locRectF = New RectangleF(GridSize.Width * 5, GridSize.Height * (UpperOffset + 6), _
                                GridSize.Width * 1.5F, GridSize.Height)

        drawAreaCorrugated(g, locRectF, Color.Black, Color.LightGray, 2, GridSize.Width)

        'das kleinere Geriffele rechts daneben malen
        locRectF.X = GridSize.Width * 6.75F
        locRectF.Width = GridSize.Width * 1.75F
        drawAreaCorrugated(g, locRectF, Color.Black, Color.LightGray, 1, GridSize.Width)

        'das noch kleinere Geriffele rechts daneben malen
        locRectF.X = GridSize.Width * 9.5F
        locRectF.Width = GridSize.Width * 1.75F
        drawAreaCorrugated(g, locRectF, Color.Black, Color.LightGray, 0.5F, GridSize.Width)

        'das Olivenfarbende daneben
        locRectF.X = GridSize.Width * 11.5F
        locRectF.Width = GridSize.Width * 3
        locBrush = New SolidBrush(Color.Olive)
        g.FillRectangle(locBrush, locRectF)

        'Zielkreuz Kreis in die Mitte
        locPen = New Pen(Color.White, 3)
        g.DrawEllipse(locPen, ClientSize.Width \ 2 - ClientSize.Height \ 2, 0, ClientSize.Height, ClientSize.Height)
        locPen.Width = 1
        g.DrawLine(locPen, GridSize.Width * 9, GridSize.Height * (UpperOffset + 3), _
                          GridSize.Width * 9, GridSize.Height * (UpperOffset + 7))
        g.DrawLine(locPen, GridSize.Width * 5, GridSize.Height * (UpperOffset + 5), _
                            GridSize.Width * 13, GridSize.Height * (UpperOffset + 5))

        'das kleine Dreieck in den weißen Zwischenraum
        Dim locPoints(2) As PointF
        locPoints(0) = New PointF(GridSize.Width * 8.75F, GridSize.Height * (UpperOffset + 7))
        locPoints(1) = New PointF(locPoints(0).X, GridSize.Height * (UpperOffset + 8))
        locPoints(2) = New PointF(GridSize.Width * 9.25F, locPoints(0).Y)
        g.FillPolygon(New SolidBrush(Color.Black), locPoints)

        'Texte hineinschreiben
        drawStringInFrame(g, New SolidBrush(Color.White), "VB.NET", "Arial", _
                        New RectangleF(GridSize.Width * 5.5F, GridSize.Height * (UpperOffset + 5), _
                                       GridSize.Width * 3, GridSize.Height))

        drawStringInFrame(g, New SolidBrush(Color.White), "Testbild", "Arial", _
                New RectangleF(GridSize.Width * 9, GridSize.Height * (UpperOffset + 5), _
                               GridSize.Width * 3.5F, GridSize.Height))

    End Sub

    'geriffelten Bereich malen
    Private Sub drawAreaCorrugated(ByVal g As Graphics, ByVal rectF As RectangleF, _
                           ByVal col1 As Color, ByVal col2 As Color, _
                           ByVal relCellStepWidth As Single, ByVal relCellWidth As Single)

        Dim locPCol1 As New SolidBrush(col1)
        Dim locPCol2 As New SolidBrush(col2)
        Dim locCurrentBrush As Brush
        Dim locAltFlag As Boolean = False
        Dim locStep As Single = relCellWidth / (1 / relCellStepWidth * 15)

        For x As Single = rectF.X To rectF.Right Step locStep
            locCurrentBrush = DirectCast(IIf(locAltFlag, locPCol1, locPCol2), SolidBrush)
            g.FillRectangle(locCurrentBrush, x, rectF.Y, locStep, rectF.Height)
            locAltFlag = Not locAltFlag
        Next

    End Sub

    'Zeichnet den Text, so dass er genau in ein Rechteck passt
    Private Sub drawStringInFrame(ByVal g As Graphics, ByVal brush As Brush, ByVal text As String, _
                                    ByVal fontName As String, ByVal rectF As RectangleF)

        'Skalierungseinstellungen zum Wiederherstellen speichern
        Dim locGState As GraphicsState = g.Save
        'Font mit 12 Pt. Höhe aus Fontnamen anlegen
        Dim locFont As New Font(fontName, 12, FontStyle.Regular)
        'Ausmaße des Strings messen
        Dim locSize As SizeF = g.MeasureString(text, locFont)
        'Faktoren für die Skalierung ermitteln, so dass der String...
        Dim locScaleV As Single = rectF.Height / locSize.Height
        'genau in das angegebene Rechteck passt
        Dim locScaleH As Single = rectF.Width / locSize.Width
        'Koordinatensystem verschieben
        g.TranslateTransform(rectF.X, rectF.Y)
        'KoordinatenSystem neu skalieren
        g.ScaleTransform(locScaleH, locScaleV)
        'String im skalierten Koordinatensystem ausgeben
        g.DrawString(text, locFont, brush, 0, 0)
        'Alte Skalierungs- und Transformationseinstellungen wiederherstellen
        g.Restore(locGState)

    End Sub

    'Zeichnet das Raster oder das Gitter
    Private Sub paintGrid(ByVal g As Graphics)

        Dim locPen As New Pen(GridColor, GridLineWidth)
        Dim locBrush As New SolidBrush(GridColor)

        If GridStyle = GridStyle.Dots Then
            For x As Single = 0 To ClientSize.Width Step GridSize.Width
                For y As Single = 0 To ClientSize.Height Step GridSize.Height
                    g.FillRectangle(locBrush, x, y, GridLineWidth, GridLineWidth)
                Next
            Next

        Else
            For x As Single = 0 To ClientSize.Width Step GridSize.Width
                g.DrawLine(locPen, x, 0, x, ClientSize.Height)
            Next

            For y As Single = 0 To ClientSize.Height Step GridSize.Height
                g.DrawLine(locPen, 0, y, ClientSize.Width, y)
            Next
        End If

    End Sub

    'Berechnet aus der Anzahl von Spalten/Zeilen und der Größe des Client-Bereichs
    'die Ausmaße eines Gitter-Kästchens
    Public ReadOnly Property GridSize() As SizeF
        Get
            Return New SizeF(CSng(ClientSize.Width / GridCols), CSng(ClientSize.Height / GridRows))
        End Get
    End Property

    Public Property DrawGrid() As Boolean
        Get
            Return myDrawGrid
        End Get
        Set(ByVal Value As Boolean)
            myDrawGrid = Value
        End Set
    End Property

    Public Property GridStyle() As GridStyle
        Get
            Return myGridStyle
        End Get
        Set(ByVal Value As GridStyle)
            myGridStyle = Value
        End Set
    End Property

    Public Property GridLineWidth() As Integer
        Get
            Return myGridLineWidth
        End Get
        Set(ByVal Value As Integer)
            myGridLineWidth = Value
        End Set
    End Property

    Public Property GridColor() As Color
        Get
            Return myGridColor
        End Get
        Set(ByVal Value As Color)
            myGridColor = Value
        End Set
    End Property

    Public Property GridCols() As Integer
        Get
            Return myGridCols
        End Get
        Set(ByVal Value As Integer)
            myGridCols = Value
        End Set
    End Property

    Public Property GridRows() As Integer
        Get
            Return myGridRows
        End Get
        Set(ByVal Value As Integer)
            myGridRows = Value
        End Set
    End Property

    Public Property UpperOffset() As Integer
        Get
            Return myUpperOffset
        End Get
        Set(ByVal Value As Integer)
            myUpperOffset = Value
        End Set
    End Property

    Public Property Background() As Color
        Get
            Return myBackground
        End Get
        Set(ByVal Value As Color)
            myBackground = Value
        End Set
    End Property

    Public Property BarColors() As Color()
        Get
            Return myBarColors
        End Get
        Set(ByVal Value As Color())
            myBarColors = Value
        End Set
    End Property

    Public Property BarShades() As Color()
        Get
            Return myBarShades
        End Get
        Set(ByVal Value As Color())
            myBarShades = Value
        End Set
    End Property

    Public Property BarTitleShades() As Color()
        Get
            Return myBarTitleShades
        End Get
        Set(ByVal Value As Color())
            myBarTitleShades = Value
        End Set
    End Property
End Class

Public Enum GridStyle
    Dots
    Lines
End Enum
