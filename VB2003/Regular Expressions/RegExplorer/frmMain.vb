Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        FormInitialize()

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
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchPattern As System.Windows.Forms.TextBox
    Friend WithEvents txtReplacePattern As System.Windows.Forms.TextBox
    Friend WithEvents txtSourceText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents tvwResults As System.Windows.Forms.TreeView
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents MainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLoadSourceFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSaveSourceFile As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuQuitProgram As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSavePattern As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPickPattern As System.Windows.Forms.MenuItem
    Friend WithEvents btnPatternLibrary As System.Windows.Forms.Button
    Friend WithEvents btnNewSearchPattern As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuResultToSource As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteSourceText As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDeleteResultText As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectSource As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectResult As System.Windows.Forms.MenuItem
    Friend WithEvents mnuShowGroupCaptures As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Splitter2 = New System.Windows.Forms.Splitter
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnNewSearchPattern = New System.Windows.Forms.Button
        Me.btnPatternLibrary = New System.Windows.Forms.Button
        Me.btnReplace = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSourceText = New System.Windows.Forms.TextBox
        Me.txtReplacePattern = New System.Windows.Forms.TextBox
        Me.txtSearchPattern = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtResults = New System.Windows.Forms.TextBox
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.tvwResults = New System.Windows.Forms.TreeView
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.mnuLoadSourceFile = New System.Windows.Forms.MenuItem
        Me.mnuSaveSourceFile = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.mnuSavePattern = New System.Windows.Forms.MenuItem
        Me.mnuPickPattern = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuQuitProgram = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuResultToSource = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.mnuDeleteSourceText = New System.Windows.Forms.MenuItem
        Me.mnuDeleteResultText = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.mnuSelectSource = New System.Windows.Forms.MenuItem
        Me.mnuSelectResult = New System.Windows.Forms.MenuItem
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuShowGroupCaptures = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Splitter2
        '
        Me.Splitter2.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.Splitter2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter2.Location = New System.Drawing.Point(0, 334)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(776, 8)
        Me.Splitter2.TabIndex = 1
        Me.Splitter2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNewSearchPattern)
        Me.GroupBox1.Controls.Add(Me.btnPatternLibrary)
        Me.GroupBox1.Controls.Add(Me.btnReplace)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtSourceText)
        Me.GroupBox1.Controls.Add(Me.txtReplacePattern)
        Me.GroupBox1.Controls.Add(Me.txtSearchPattern)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 342)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnNewSearchPattern
        '
        Me.btnNewSearchPattern.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewSearchPattern.Location = New System.Drawing.Point(640, 72)
        Me.btnNewSearchPattern.Name = "btnNewSearchPattern"
        Me.btnNewSearchPattern.Size = New System.Drawing.Size(32, 24)
        Me.btnNewSearchPattern.TabIndex = 9
        Me.btnNewSearchPattern.Text = "..."
        Me.ToolTip.SetToolTip(Me.btnNewSearchPattern, "Neues Suchmuster")
        '
        'btnPatternLibrary
        '
        Me.btnPatternLibrary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPatternLibrary.Location = New System.Drawing.Point(640, 32)
        Me.btnPatternLibrary.Name = "btnPatternLibrary"
        Me.btnPatternLibrary.Size = New System.Drawing.Size(32, 24)
        Me.btnPatternLibrary.TabIndex = 8
        Me.btnPatternLibrary.Text = "..."
        Me.ToolTip.SetToolTip(Me.btnPatternLibrary, "Auswahl von Suchmustern")
        '
        'btnReplace
        '
        Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReplace.Location = New System.Drawing.Point(672, 72)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(96, 24)
        Me.btnReplace.TabIndex = 7
        Me.btnReplace.Text = "Ersetzen"
        Me.ToolTip.SetToolTip(Me.btnReplace, "Ersetzen ausführen")
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(672, 32)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(96, 24)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Suchen"
        Me.ToolTip.SetToolTip(Me.btnSearch, "Suche ausführen")
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(0, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Quelltext:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Ersetzungsmuster"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Suchmuster"
        '
        'txtSourceText
        '
        Me.txtSourceText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSourceText.HideSelection = False
        Me.txtSourceText.Location = New System.Drawing.Point(0, 112)
        Me.txtSourceText.Multiline = True
        Me.txtSourceText.Name = "txtSourceText"
        Me.txtSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSourceText.Size = New System.Drawing.Size(776, 222)
        Me.txtSourceText.TabIndex = 5
        Me.txtSourceText.Text = ""
        '
        'txtReplacePattern
        '
        Me.txtReplacePattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplacePattern.Location = New System.Drawing.Point(0, 72)
        Me.txtReplacePattern.Name = "txtReplacePattern"
        Me.txtReplacePattern.Size = New System.Drawing.Size(640, 20)
        Me.txtReplacePattern.TabIndex = 3
        Me.txtReplacePattern.Text = ""
        '
        'txtSearchPattern
        '
        Me.txtSearchPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchPattern.Location = New System.Drawing.Point(0, 32)
        Me.txtSearchPattern.Name = "txtSearchPattern"
        Me.txtSearchPattern.Size = New System.Drawing.Size(640, 20)
        Me.txtSearchPattern.TabIndex = 1
        Me.txtSearchPattern.Text = ""
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtResults)
        Me.Panel1.Controls.Add(Me.Splitter1)
        Me.Panel1.Controls.Add(Me.tvwResults)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 342)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 256)
        Me.Panel1.TabIndex = 5
        '
        'txtResults
        '
        Me.txtResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResults.Location = New System.Drawing.Point(208, 0)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(568, 256)
        Me.txtResults.TabIndex = 2
        Me.txtResults.Text = ""
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(200, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(8, 256)
        Me.Splitter1.TabIndex = 1
        Me.Splitter1.TabStop = False
        '
        'tvwResults
        '
        Me.tvwResults.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvwResults.HideSelection = False
        Me.tvwResults.ImageIndex = -1
        Me.tvwResults.Location = New System.Drawing.Point(0, 0)
        Me.tvwResults.Name = "tvwResults"
        Me.tvwResults.SelectedImageIndex = -1
        Me.tvwResults.Size = New System.Drawing.Size(200, 256)
        Me.tvwResults.TabIndex = 0
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLoadSourceFile, Me.mnuSaveSourceFile, Me.MenuItem4, Me.mnuSavePattern, Me.mnuPickPattern, Me.MenuItem3, Me.mnuShowGroupCaptures, Me.MenuItem6, Me.mnuQuitProgram})
        Me.MenuItem1.Text = "&Datei"
        '
        'mnuLoadSourceFile
        '
        Me.mnuLoadSourceFile.Index = 0
        Me.mnuLoadSourceFile.Text = "Quelltextdatei &laden..."
        '
        'mnuSaveSourceFile
        '
        Me.mnuSaveSourceFile.Index = 1
        Me.mnuSaveSourceFile.Text = "Queltextdatei speichern..."
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'mnuSavePattern
        '
        Me.mnuSavePattern.Index = 3
        Me.mnuSavePattern.Text = "Suchmuster speichern..."
        '
        'mnuPickPattern
        '
        Me.mnuPickPattern.Index = 4
        Me.mnuPickPattern.Text = "Suchmuster auswählen..."
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 5
        Me.MenuItem3.Text = "-"
        '
        'mnuQuitProgram
        '
        Me.mnuQuitProgram.Index = 8
        Me.mnuQuitProgram.Text = "Programm be&enden"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuResultToSource, Me.MenuItem5, Me.mnuDeleteSourceText, Me.mnuDeleteResultText, Me.MenuItem8, Me.mnuSelectSource, Me.mnuSelectResult})
        Me.MenuItem2.Text = "&Bearbeiten"
        '
        'mnuResultToSource
        '
        Me.mnuResultToSource.Index = 0
        Me.mnuResultToSource.Text = "Ergebnistext in Quelltext &kopieren"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "-"
        '
        'mnuDeleteSourceText
        '
        Me.mnuDeleteSourceText.Index = 2
        Me.mnuDeleteSourceText.Text = "Quelltext löschen..."
        '
        'mnuDeleteResultText
        '
        Me.mnuDeleteResultText.Index = 3
        Me.mnuDeleteResultText.Text = "Ergebnistext löschen..."
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 4
        Me.MenuItem8.Text = "-"
        '
        'mnuSelectSource
        '
        Me.mnuSelectSource.Index = 5
        Me.mnuSelectSource.Text = "Ganzen Quelltext markieren"
        '
        'mnuSelectResult
        '
        Me.mnuSelectResult.Index = 6
        Me.mnuSelectResult.Text = "Ganzen Ergebnistext markieren"
        '
        'mnuShowGroupCaptures
        '
        Me.mnuShowGroupCaptures.Index = 6
        Me.mnuShowGroupCaptures.Text = "Groupcaptures anzeigen"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 7
        Me.MenuItem6.Text = "-"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 598)
        Me.Controls.Add(Me.Splitter2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.MainMenu
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RegExplorer"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myFilename As String
    Private myPatterns As ArrayList
    Private myResultTextChanged As Boolean
    Private myGroupCaptures As Boolean

    Private Sub FormInitialize()

        Dim locFI As New FileInfo(Application.StartupPath + "\Library.RegEx")
        If Not locFI.Exists Then
            myPatterns = New ArrayList
            myPatterns.Add(New PatternEntry("\w+", "", "Einzelne Wörter aus Text"))
            ADSoapSerializer.SerializeToFile(New FileInfo(( _
                                            Application.StartupPath + "\Library.RegEx")), _
                                            myPatterns)
        End If

        myPatterns = DirectCast(ADSoapSerializer.SerializeFromFile(New FileInfo _
                                (Application.StartupPath + "\Library.RegEx")), _
                                    ArrayList)
    End Sub

    Private Sub mnuQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitProgram.Click
        Me.Dispose()
    End Sub

    Private Sub mnuLoadSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadSourceFile.Click

        Dim locOpenFile As New OpenFileDialog

        With locOpenFile
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.txt"
            .Filter = "Textdateien (*.txt)|*.txt|VB-Quelldateien (*.vb)|*.vb|Alle Dateien (*.*)|*.*"
            .Title = "Quelldatei öffnen"
            Dim locDiRes As DialogResult = .ShowDialog
            If locDiRes = DialogResult.OK Then
                Dim locTR As New StreamReader(.FileName)
                txtSourceText.Text = locTR.ReadToEnd
                locTR.Close()
                myFilename = .FileName
            End If

        End With

    End Sub

    Private Sub mnuSaveSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveSourceFile.Click
        Dim locSaveFile As New SaveFileDialog

        With locSaveFile
            .OverwritePrompt = True
            .DefaultExt = "*.txt"
            .Filter = "Textdateien (*.txt)|*.txt|VB-Quelldateien (*.vb)|*.vb|Alle Dateien (*.*)|*.*"
            .Title = "Quelldatei speichern"
            Dim locDiRes As DialogResult = .ShowDialog
            If locDiRes = DialogResult.OK Then
                Dim locTS As New StreamWriter(.FileName)
                locTS.Write(txtSourceText.Text)
                locTS.Flush()
                locTS.Close()
            End If
        End With

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim locRegEx As Regex

        Try
            locRegEx = New Regex(txtSearchPattern.Text)
        Catch ex As Exception
            MessageBox.Show("Fehler beim Anlegen des RegEx-Objektes!" + ex.Message, _
                         "Fehler in Ausdruck:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

        Dim locRootNode As TreeNode

        tvwResults.Nodes.Clear()
        With tvwResults.Nodes
            locRootNode = .Add(myFilename)

            For Each locMatch As Match In locRegEx.Matches(txtSourceText.Text)

                Dim locMainNode As New TreeNode("'" + locMatch.Value + "'")
                locMainNode.Tag = locMatch
                locRootNode.Nodes.Add(locMainNode)

                If locMatch.Captures.Count > 0 Then
                    Dim locCaptureNode As TreeNode = locMainNode.Nodes.Add("CAPTURES:")
                    For Each locCC As Capture In locMatch.Captures
                        Dim locNode As TreeNode = locCaptureNode.Nodes.Add(locCC.Value)
                        locNode.Tag = locCC
                    Next
                End If

                If locMatch.Groups.Count > 0 Then
                    Dim locGroupNode As TreeNode = locMainNode.Nodes.Add("GROUPS:")
                    For Each locGroup As Group In locMatch.Groups
                        Dim locNode As TreeNode = locGroupNode.Nodes.Add(locGroup.Value)
                        locNode.Tag = locGroup

                        'Captures der einzelnen Gruppen nur im Bedarfsfall zeigen
                        If myGroupCaptures Then
                            If locGroup.Captures.Count > 0 Then
                                Dim locCaptureNode As TreeNode = locNode.Nodes.Add("CAPTURES:")
                                For Each locCC As Capture In locGroup.Captures
                                    Dim locGCNode As TreeNode = locCaptureNode.Nodes.Add(locCC.Value)
                                    locGCNode.Tag = locCC
                                Next
                            End If
                        End If
                    Next
                End If
            Next
        End With

    End Sub

    Private Sub mnuPickPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPickPattern.Click, btnPatternLibrary.Click
        Dim locPatternEntry As PatternEntry = frmPatternLibrary.GetPatternEntry(myPatterns)
        If Not (locPatternEntry Is Nothing) Then
            Me.PatternEntry = locPatternEntry
        End If

        'Liste neu laden; durch die Bibliotheksfunktion könnte ein Eintrag gelöscht worden
        'sein; die Übergabe erfolgt, die Einfachheit halber, über die Datei
        myPatterns = DirectCast(ADSoapSerializer.SerializeFromFile(New FileInfo _
                                (Application.StartupPath + "\Library.RegEx")), _
                                    ArrayList)

    End Sub

    Private Property PatternEntry() As PatternEntry
        Get
            Return New PatternEntry(txtSearchPattern.Text, txtReplacePattern.Text, "")
        End Get
        Set(ByVal Value As PatternEntry)
            txtSearchPattern.Text = Value.SearchPattern
            txtReplacePattern.Text = Value.ReplacePattern
        End Set
    End Property

    Private Sub btnNewSearchPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSearchPattern.Click

        Dim locPatternEntry As PatternEntry
        locPatternentry = frmNewPattern.GetPatternEntry( _
                New PatternEntry(txtSearchPattern.Text, txtReplacePattern.Text, ""))

        If Not (locPatternEntry Is Nothing) Then
            myPatterns.Add(locPatternEntry)

            'Sofort speichern
            ADSoapSerializer.SerializeToFile(New FileInfo(( _
                                            Application.StartupPath + "\Library.RegEx")), _
                                            myPatterns)
        End If

    End Sub

    Private Sub tvwResults_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwResults.AfterSelect

        Dim locNode As TreeNode = e.Node
        Dim locObject As Object = locNode.Tag
        Dim locString As String

        'Root, dann gesamten Text darstellen
        If locNode.Parent Is Nothing Then
            txtResults.Text = txtSourceText.Text
            Return
        End If

        locObject = locNode.Tag

        'Kein gescheites Ergebnis -> und tschö!
        If (locObject Is Nothing) Then
            Return
        End If

        'Erster Eintrag, dann Status ausgeben Text im Source markieren
        If locObject.GetType().FullName = "System.Text.RegularExpressions.Match" Then
            Dim locMatch As Match = DirectCast(locObject, Match)
            locString = "Ergebnistext: " + "'" + locMatch.Value + "'" + vbNewLine
            locString += "An Position: " + locMatch.Index.ToString + vbNewLine
            locString += "Länge: " + locMatch.Length.ToString + vbNewLine + vbNewLine

            locString += "Groups:" + vbNewLine
            locString += "=======" + vbNewLine
            For Each locGroup As Group In locMatch.Groups
                locString += "'" + locGroup.Value + "'" + vbNewLine
            Next
            locString += vbNewLine
            locString += "Captures:" + vbNewLine
            locString += "=======" + vbNewLine
            For Each locCapture As Capture In locMatch.Captures
                locString += "'" + locCapture.Value + "'" + vbNewLine
            Next
            txtResults.Text = locString
            txtSourceText.SelectionStart = locMatch.Index
            txtSourceText.SelectionLength = locMatch.Length
            txtSourceText.ScrollToCaret()
            Return
        End If
    End Sub

    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        txtResults.Text = Regex.Replace(txtSourceText.Text, txtSearchPattern.Text, txtReplacePattern.Text)
    End Sub

    Private Sub mnuResultToSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuResultToSource.Click
        txtSourceText.Text = txtResults.Text
    End Sub

    Private Sub mnuDeleteSourceText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteSourceText.Click

        Dim locDR As DialogResult = MessageBox.Show("Sind Sie sicher?", "Quelltext löschen:", _
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locDR = DialogResult.Yes Then
            txtSourceText.Text = ""
        End If
    End Sub

    Private Sub mnuDeleteResultText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDeleteResultText.Click

        Dim locDR As DialogResult = MessageBox.Show("Sind Sie sicher?", "Ergebnixtext löschen:", _
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locDR = DialogResult.Yes Then
            txtResults.Text = ""
        End If

    End Sub

    Private Sub mnuSelectSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectSource.Click
        txtSourceText.Focus()
        txtSourceText.SelectionStart = 0
        txtSourceText.SelectionLength = txtSourceText.Text.Length
    End Sub

    Private Sub mnuSelectResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelectResult.Click
        txtResults.Focus()
        txtResults.SelectionStart = 0
        txtResults.SelectionLength = txtSourceText.Text.Length
    End Sub

    Private Sub mnuShowGroupCaptures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowGroupCaptures.Click
        myGroupCaptures = myGroupCaptures Xor True
        mnuShowGroupCaptures.Checked = myGroupCaptures
    End Sub
End Class

<Serializable()> _
Public Class PatternEntry

    Private mySearchPattern As String
    Private myReplacePattern As String
    Private myComment As String

    Sub New(ByVal SearchPattern As String, ByVal ReplacePattern As String, ByVal Comment As String)
        mySearchPattern = SearchPattern
        myReplacePattern = ReplacePattern
        myComment = Comment
    End Sub

    Public Property SearchPattern() As String
        Get
            Return mySearchPattern
        End Get
        Set(ByVal Value As String)
            mySearchPattern = Value
        End Set
    End Property

    Public Property ReplacePattern() As String
        Get
            Return myReplacePattern
        End Get
        Set(ByVal Value As String)
            myReplacePattern = Value
        End Set
    End Property

    Public Property Comment() As String
        Get
            Return myComment
        End Get
        Set(ByVal Value As String)
            myComment = Value
        End Set
    End Property
End Class
