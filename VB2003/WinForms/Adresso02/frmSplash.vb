Imports System.IO
Imports System.Reflection
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class frmSplash
    Inherits System.Windows.Forms.Form

    Private mypic As Bitmap
    Private myRegionOverPic As ArrayList
    'Maximal 100 Pixel nach unten, wenn das Bild es hergibt
    Private myMaxPicDepth As Integer = 150
    Private myPicOffset As Integer

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        LoadBitmap()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 176)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 40)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "!Adresso"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(160, 48)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Die bärenstarke Adressverwaltung"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 336)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 32)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Demo für ""Das Entwicklerbuch - MicrosoftPress"" von Klaus Löffelmann"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(336, 336)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(176, 32)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ArtWork: Gareth Clarke -http://clarke.loeffelmann.de"
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(528, 400)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Blue
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Wird vom Konstruktur aufgerufen, der sich
    'in der Windows-Form-Designer-Region versteckt
    Sub LoadBitmap()
        Dim locAssembly As [Assembly]
        Dim locResourceStream As Stream
        Dim locBinReader As BinaryReader
        Dim locCompColor As Color
        Dim locOld_Y, x, y As Integer

        locAssembly = [Assembly].GetExecutingAssembly
        'Achten Sie darauf, dass das Bild die gleiche Auflösung wie der Hintergrund hat
        'Sonst müssen Sie mit myPic.SetResolution die Auflösung entsprechend anpassen
        'Wichtig: Wenn Sie Elemente eingebunden haben, stellen Sie in den Eigenschaften
        'zum Element die Buildaktion auf "eingebettete Ressource"
        locResourceStream = locAssembly.GetManifestResourceStream("FormDataExchange.rolodexMed.jpg")
        'Bitmap aus Resource-Stream
        mypic = New Bitmap(locResourceStream)
        'Maximale Tiefe nicht kleiner als Bildhöhe!
        myMaxPicDepth = CInt(IIf(myMaxPicDepth > mypic.Height, mypic.Height, myMaxPicDepth))
        locResourceStream.Close()

        'Diese Routine testet das Bild von links, nach rechts und von
        'oben nach unten auf dessen Konturen und speichert sie in einem
        'Point-Array
        locCompColor = mypic.GetPixel(1, 1)
        myPicOffset = ClientSize.Width - mypic.Width
        myRegionOverPic = New ArrayList
        For x = 1 To mypic.Width - 1 Step 6
            For y = 2 To myMaxPicDepth - 1
                If Not locCompColor.Equals(mypic.GetPixel(x, y)) Then
                    Exit For
                End If
            Next
            If y <> locOld_Y Then
                myRegionOverPic.Add(New Point(myPicOffset + x, y))
                locOld_Y = y
            End If
        Next
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim locIA As New ImageAttributes
        Dim locBrush As New SolidBrush(Color.Blue)
        Dim locPen As New Pen(Color.Black, 2)
        Dim locPath As New GraphicsPath
        Dim locRegion As Region
        Dim locPoints As Point()

        locPoints = DirectCast(myRegionOverPic.ToArray(GetType(Point)), Point())
        With e.Graphics
            'Rolodex in die rechte, obere Ecke malen
            .DrawImage(mypic, New Point(ClientSize.Width - mypic.Width, 0))
            locPath.StartFigure()
            locPath.AddLine(0, 0, 0, myMaxPicDepth)
            locPath.AddCurve(locPoints)
            locPath.AddLine(ClientSize.Width, myMaxPicDepth, ClientSize.Width, 0)
            locPath.CloseFigure()
            locRegion = New Region(locPath)
            .FillRegion(locBrush, locRegion)
            'Umrandung malen
            '.DrawCurve(locPen, locPoints)
            .DrawLine(locPen, 1, myMaxPicDepth, myPicOffset, myMaxPicDepth)
            .DrawLine(locPen, ClientSize.Width - 1, myMaxPicDepth, ClientSize.Width - 1, ClientSize.Height - 1)
            .DrawLine(locPen, ClientSize.Width - 1, ClientSize.Height - 1, 0, ClientSize.Height - 1)
            .DrawLine(locPen, ClientSize.Width - 1, ClientSize.Height - 1, 1, ClientSize.Height - 1)
            .DrawLine(locPen, 1, ClientSize.Height - 1, 1, myMaxPicDepth)
        End With
    End Sub
End Class
