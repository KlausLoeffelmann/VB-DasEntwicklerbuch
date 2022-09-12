Public Class frmPreview
    Inherits System.Windows.Forms.Form

    Private myRtfText As String

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

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
    Friend WithEvents C1PrintPreview1 As C1.Win.C1PrintPreview.C1PrintPreview
    Friend WithEvents PreviewToolBarButton1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton2 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton3 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton4 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton5 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton6 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton7 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton8 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton9 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton10 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton11 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton12 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton13 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton14 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton15 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton16 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton17 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton18 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton19 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton20 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton21 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton22 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton23 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton24 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton25 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton26 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton27 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton28 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton29 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton30 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton31 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton32 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents PreviewToolBarButton33 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents C1PrintDocument1 As C1.C1PrintDocument.C1PrintDocument
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.C1PrintPreview1 = New C1.Win.C1PrintPreview.C1PrintPreview
        Me.PreviewToolBarButton1 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton2 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton3 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton4 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton5 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton6 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton7 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton8 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton9 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton10 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton11 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton12 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton13 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton14 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton15 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton16 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton17 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton18 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton19 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton20 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton21 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton22 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton23 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton24 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton25 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton26 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton27 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton28 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton29 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton30 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton31 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton32 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.PreviewToolBarButton33 = New C1.Win.C1PrintPreview.PreviewToolBarButton
        Me.C1PrintDocument1 = New C1.C1PrintDocument.C1PrintDocument
        CType(Me.C1PrintPreview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1PrintPreview1
        '
        Me.C1PrintPreview1.C1DPageSettings = "color:False;landscape:False;margins:100,100,100,100;papersize:827,1169,QQA0AA=="
        Me.C1PrintPreview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1PrintPreview1.Document = Me.C1PrintDocument1
        Me.C1PrintPreview1.Location = New System.Drawing.Point(0, 0)
        Me.C1PrintPreview1.Name = "C1PrintPreview1"
        Me.C1PrintPreview1.NavigationBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrintPreview1.NavigationBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrintPreview1.NavigationBar.OutlineView.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrintPreview1.NavigationBar.OutlineView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrintPreview1.NavigationBar.OutlineView.Indent = 19
        Me.C1PrintPreview1.NavigationBar.OutlineView.ItemHeight = 16
        Me.C1PrintPreview1.NavigationBar.OutlineView.TabIndex = 0
        Me.C1PrintPreview1.NavigationBar.OutlineView.Visible = False
        Me.C1PrintPreview1.NavigationBar.Padding = New System.Drawing.Point(6, 3)
        Me.C1PrintPreview1.NavigationBar.TabIndex = 2
        Me.C1PrintPreview1.NavigationBar.ThumbnailsView.AutoArrange = True
        Me.C1PrintPreview1.NavigationBar.ThumbnailsView.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrintPreview1.NavigationBar.ThumbnailsView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrintPreview1.NavigationBar.ThumbnailsView.TabIndex = 0
        Me.C1PrintPreview1.NavigationBar.ThumbnailsView.Visible = True
        Me.C1PrintPreview1.NavigationBar.Width = 160
        Me.C1PrintPreview1.Size = New System.Drawing.Size(784, 502)
        Me.C1PrintPreview1.Splitter.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.C1PrintPreview1.Splitter.Width = 3
        Me.C1PrintPreview1.StatusBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrintPreview1.StatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrintPreview1.StatusBar.TabIndex = 4
        Me.C1PrintPreview1.TabIndex = 0
        Me.C1PrintPreview1.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.PreviewToolBarButton1, Me.PreviewToolBarButton2, Me.PreviewToolBarButton3, Me.PreviewToolBarButton4, Me.PreviewToolBarButton5, Me.PreviewToolBarButton6, Me.PreviewToolBarButton7, Me.PreviewToolBarButton8, Me.PreviewToolBarButton9, Me.PreviewToolBarButton10, Me.PreviewToolBarButton11, Me.PreviewToolBarButton12, Me.PreviewToolBarButton13, Me.PreviewToolBarButton14, Me.PreviewToolBarButton15, Me.PreviewToolBarButton16, Me.PreviewToolBarButton17, Me.PreviewToolBarButton18, Me.PreviewToolBarButton19, Me.PreviewToolBarButton20, Me.PreviewToolBarButton21, Me.PreviewToolBarButton22, Me.PreviewToolBarButton23, Me.PreviewToolBarButton24, Me.PreviewToolBarButton25, Me.PreviewToolBarButton26, Me.PreviewToolBarButton27, Me.PreviewToolBarButton28, Me.PreviewToolBarButton29, Me.PreviewToolBarButton30, Me.PreviewToolBarButton31, Me.PreviewToolBarButton32, Me.PreviewToolBarButton33})
        Me.C1PrintPreview1.ToolBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrintPreview1.ToolBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PreviewToolBarButton1
        '
        Me.PreviewToolBarButton1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FileOpen
        Me.PreviewToolBarButton1.ImageIndex = 0
        Me.PreviewToolBarButton1.ToolTipText = "File Open"
        '
        'PreviewToolBarButton2
        '
        Me.PreviewToolBarButton2.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FileSave
        Me.PreviewToolBarButton2.ImageIndex = 1
        Me.PreviewToolBarButton2.ToolTipText = "File Save"
        '
        'PreviewToolBarButton3
        '
        Me.PreviewToolBarButton3.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FilePrint
        Me.PreviewToolBarButton3.ImageIndex = 2
        Me.PreviewToolBarButton3.ToolTipText = "Print"
        '
        'PreviewToolBarButton4
        '
        Me.PreviewToolBarButton4.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.PageSetup
        Me.PreviewToolBarButton4.ImageIndex = 3
        Me.PreviewToolBarButton4.ToolTipText = "Page Setup"
        '
        'PreviewToolBarButton5
        '
        Me.PreviewToolBarButton5.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.Reflow
        Me.PreviewToolBarButton5.ImageIndex = 4
        Me.PreviewToolBarButton5.ToolTipText = "Reflow"
        '
        'PreviewToolBarButton6
        '
        Me.PreviewToolBarButton6.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.Stop
        Me.PreviewToolBarButton6.ImageIndex = 5
        Me.PreviewToolBarButton6.ToolTipText = "Stop"
        Me.PreviewToolBarButton6.Visible = False
        '
        'PreviewToolBarButton7
        '
        Me.PreviewToolBarButton7.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'PreviewToolBarButton8
        '
        Me.PreviewToolBarButton8.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ShowNavigationBar
        Me.PreviewToolBarButton8.ImageIndex = 6
        Me.PreviewToolBarButton8.Pushed = True
        Me.PreviewToolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton8.ToolTipText = "Show Navigation Bar"
        '
        'PreviewToolBarButton9
        '
        Me.PreviewToolBarButton9.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'PreviewToolBarButton10
        '
        Me.PreviewToolBarButton10.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseHand
        Me.PreviewToolBarButton10.ImageIndex = 7
        Me.PreviewToolBarButton10.Pushed = True
        Me.PreviewToolBarButton10.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton10.ToolTipText = "Hand Tool"
        '
        'PreviewToolBarButton11
        '
        Me.PreviewToolBarButton11.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseZoom
        Me.PreviewToolBarButton11.ImageIndex = 8
        Me.PreviewToolBarButton11.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.PreviewToolBarButton11.ToolTipText = "Zoom In Tool"
        '
        'PreviewToolBarButton12
        '
        Me.PreviewToolBarButton12.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseZoomOut
        Me.PreviewToolBarButton12.ImageIndex = 25
        Me.PreviewToolBarButton12.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.PreviewToolBarButton12.ToolTipText = "Zoom Out Tool"
        Me.PreviewToolBarButton12.Visible = False
        '
        'PreviewToolBarButton13
        '
        Me.PreviewToolBarButton13.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseSelect
        Me.PreviewToolBarButton13.ImageIndex = 9
        Me.PreviewToolBarButton13.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton13.ToolTipText = "Select Text"
        '
        'PreviewToolBarButton14
        '
        Me.PreviewToolBarButton14.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FindText
        Me.PreviewToolBarButton14.ImageIndex = 10
        Me.PreviewToolBarButton14.ToolTipText = "Find Text"
        '
        'PreviewToolBarButton15
        '
        Me.PreviewToolBarButton15.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton15.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'PreviewToolBarButton16
        '
        Me.PreviewToolBarButton16.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoFirst
        Me.PreviewToolBarButton16.Enabled = False
        Me.PreviewToolBarButton16.ImageIndex = 11
        Me.PreviewToolBarButton16.ToolTipText = "First Page"
        '
        'PreviewToolBarButton17
        '
        Me.PreviewToolBarButton17.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoPrev
        Me.PreviewToolBarButton17.Enabled = False
        Me.PreviewToolBarButton17.ImageIndex = 12
        Me.PreviewToolBarButton17.ToolTipText = "Previous Page"
        '
        'PreviewToolBarButton18
        '
        Me.PreviewToolBarButton18.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoNext
        Me.PreviewToolBarButton18.ImageIndex = 13
        Me.PreviewToolBarButton18.ToolTipText = "Next Page"
        '
        'PreviewToolBarButton19
        '
        Me.PreviewToolBarButton19.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoLast
        Me.PreviewToolBarButton19.ImageIndex = 14
        Me.PreviewToolBarButton19.ToolTipText = "Last Page"
        '
        'PreviewToolBarButton20
        '
        Me.PreviewToolBarButton20.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton20.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'PreviewToolBarButton21
        '
        Me.PreviewToolBarButton21.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.HistoryPrev
        Me.PreviewToolBarButton21.Enabled = False
        Me.PreviewToolBarButton21.ImageIndex = 15
        Me.PreviewToolBarButton21.ToolTipText = "Previous View"
        Me.PreviewToolBarButton21.Visible = False
        '
        'PreviewToolBarButton22
        '
        Me.PreviewToolBarButton22.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.HistoryNext
        Me.PreviewToolBarButton22.Enabled = False
        Me.PreviewToolBarButton22.ImageIndex = 16
        Me.PreviewToolBarButton22.ToolTipText = "Next View"
        Me.PreviewToolBarButton22.Visible = False
        '
        'PreviewToolBarButton23
        '
        Me.PreviewToolBarButton23.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton23.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.PreviewToolBarButton23.Visible = False
        '
        'PreviewToolBarButton24
        '
        Me.PreviewToolBarButton24.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ZoomOut
        Me.PreviewToolBarButton24.ImageIndex = 17
        Me.PreviewToolBarButton24.ToolTipText = "Zoom Out"
        Me.PreviewToolBarButton24.Visible = False
        '
        'PreviewToolBarButton25
        '
        Me.PreviewToolBarButton25.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ZoomIn
        Me.PreviewToolBarButton25.ImageIndex = 18
        Me.PreviewToolBarButton25.ToolTipText = "Zoom In"
        Me.PreviewToolBarButton25.Visible = False
        '
        'PreviewToolBarButton26
        '
        Me.PreviewToolBarButton26.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton26.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.PreviewToolBarButton26.Visible = False
        '
        'PreviewToolBarButton27
        '
        Me.PreviewToolBarButton27.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewActualSize
        Me.PreviewToolBarButton27.ImageIndex = 19
        Me.PreviewToolBarButton27.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton27.ToolTipText = "Actual Size"
        '
        'PreviewToolBarButton28
        '
        Me.PreviewToolBarButton28.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewFullPage
        Me.PreviewToolBarButton28.ImageIndex = 20
        Me.PreviewToolBarButton28.Pushed = True
        Me.PreviewToolBarButton28.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton28.ToolTipText = "Full Page"
        '
        'PreviewToolBarButton29
        '
        Me.PreviewToolBarButton29.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewPageWidth
        Me.PreviewToolBarButton29.ImageIndex = 21
        Me.PreviewToolBarButton29.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton29.ToolTipText = "Page Width"
        '
        'PreviewToolBarButton30
        '
        Me.PreviewToolBarButton30.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewTwoPages
        Me.PreviewToolBarButton30.ImageIndex = 22
        Me.PreviewToolBarButton30.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.PreviewToolBarButton30.ToolTipText = "Two Pages"
        '
        'PreviewToolBarButton31
        '
        Me.PreviewToolBarButton31.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewFourPages
        Me.PreviewToolBarButton31.ImageIndex = 23
        Me.PreviewToolBarButton31.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.PreviewToolBarButton31.ToolTipText = "Four Pages"
        '
        'PreviewToolBarButton32
        '
        Me.PreviewToolBarButton32.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.PreviewToolBarButton32.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.PreviewToolBarButton32.Visible = False
        '
        'PreviewToolBarButton33
        '
        Me.PreviewToolBarButton33.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.Help
        Me.PreviewToolBarButton33.ImageIndex = 24
        Me.PreviewToolBarButton33.ToolTipText = "Help"
        Me.PreviewToolBarButton33.Visible = False
        '
        'C1PrintDocument1
        '
        Me.C1PrintDocument1.C1DPageSettings = "color:False;landscape:False;margins:100,100,100,100;papersize:827,1169,QQA0AA=="
        Me.C1PrintDocument1.ColumnSpacingStr = "0.5in"
        Me.C1PrintDocument1.ColumnSpacingUnit.DefaultType = True
        Me.C1PrintDocument1.ColumnSpacingUnit.UnitValue = "0.5in"
        Me.C1PrintDocument1.DefaultUnit = C1.C1PrintDocument.UnitTypeEnum.Inch
        Me.C1PrintDocument1.DocumentName = ""
        '
        'frmPreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 502)
        Me.Controls.Add(Me.C1PrintPreview1)
        Me.Name = "frmPreview"
        Me.Text = "frmPreview"
        CType(Me.C1PrintPreview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Sub New(ByVal rtfText As String)
        Me.new()
        myRtfText = rtfText

    End Sub

    Public Sub ShowPreview()
        GenerateDocument()
        Me.ShowDialog()
    End Sub

    Private Sub GenerateDocument()
        With C1PrintDocument1
            .Style.Font = New Font("Arial", 12, FontStyle.Regular)
            With .PageHeader
                .RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
                .RenderText.Text = "Kopfzeile - Seite [@@PageNo@@] von [@@PageCount@@]"
            End With
            With .PageFooter
                .RenderText.Style.TextAlignHorz = C1.C1PrintDocument.AlignHorzEnum.Center
                .RenderText.Style.TextAlignVert = C1.C1PrintDocument.AlignVertEnum.Bottom
                .RenderText.Text = "Fußzeile - Seite [@@PageNo@@] von [@@PageCount@@]"
            End With
            .StartDoc()
            .RenderBlockRichText(myRtfText)
            .EndDoc()
        End With
    End Sub
End Class
