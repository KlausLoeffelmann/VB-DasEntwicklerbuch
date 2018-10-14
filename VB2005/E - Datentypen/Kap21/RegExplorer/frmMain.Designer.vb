<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmLoadSourceFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSaveSourceFile = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmSaveSearchPattern = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmChooseSearchPattern = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmShowGroupCaptures = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmQuitProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCopyResultToSource = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmClearResult = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmClearSource = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmSourceSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmResultSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.btnNewSearchPattern = New System.Windows.Forms.Button
        Me.btnPatternLibrary = New System.Windows.Forms.Button
        Me.btnReplace = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtReplacePattern = New System.Windows.Forms.TextBox
        Me.txtSearchPattern = New System.Windows.Forms.TextBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtSourceText = New System.Windows.Forms.TextBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.tvwResults = New System.Windows.Forms.TreeView
        Me.txtResults = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(790, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmLoadSourceFile, Me.tsmSaveSourceFile, Me.ToolStripMenuItem1, Me.tsmSaveSearchPattern, Me.tsmChooseSearchPattern, Me.tsmShowGroupCaptures, Me.ToolStripMenuItem2, Me.tsmQuitProgram})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmLoadSourceFile
        '
        Me.tsmLoadSourceFile.Name = "tsmLoadSourceFile"
        Me.tsmLoadSourceFile.Size = New System.Drawing.Size(203, 22)
        Me.tsmLoadSourceFile.Text = "Quelltextdatei &laden..."
        '
        'tsmSaveSourceFile
        '
        Me.tsmSaveSourceFile.Name = "tsmSaveSourceFile"
        Me.tsmSaveSourceFile.Size = New System.Drawing.Size(203, 22)
        Me.tsmSaveSourceFile.Text = "Quelltextdatei &speichern..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(200, 6)
        '
        'tsmSaveSearchPattern
        '
        Me.tsmSaveSearchPattern.Name = "tsmSaveSearchPattern"
        Me.tsmSaveSearchPattern.Size = New System.Drawing.Size(203, 22)
        Me.tsmSaveSearchPattern.Text = "Such&muster speichern..."
        '
        'tsmChooseSearchPattern
        '
        Me.tsmChooseSearchPattern.Name = "tsmChooseSearchPattern"
        Me.tsmChooseSearchPattern.Size = New System.Drawing.Size(203, 22)
        Me.tsmChooseSearchPattern.Text = "Suchmuster &auswählen..."
        '
        'tsmShowGroupCaptures
        '
        Me.tsmShowGroupCaptures.Name = "tsmShowGroupCaptures"
        Me.tsmShowGroupCaptures.Size = New System.Drawing.Size(203, 22)
        Me.tsmShowGroupCaptures.Text = "Group Captures anzeigen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(200, 6)
        '
        'tsmQuitProgram
        '
        Me.tsmQuitProgram.Name = "tsmQuitProgram"
        Me.tsmQuitProgram.Size = New System.Drawing.Size(203, 22)
        Me.tsmQuitProgram.Text = "Programm be&enden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmCopyResultToSource, Me.ToolStripMenuItem6, Me.tsmClearResult, Me.tsmClearSource, Me.ToolStripMenuItem5, Me.tsmSourceSelectAll, Me.tsmResultSelectAll})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        '
        'tsmCopyResultToSource
        '
        Me.tsmCopyResultToSource.Name = "tsmCopyResultToSource"
        Me.tsmCopyResultToSource.Size = New System.Drawing.Size(284, 22)
        Me.tsmCopyResultToSource.Text = "&Ereignistext in Quelltext kopieren..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(281, 6)
        '
        'tsmClearResult
        '
        Me.tsmClearResult.Name = "tsmClearResult"
        Me.tsmClearResult.Size = New System.Drawing.Size(284, 22)
        Me.tsmClearResult.Text = "Ergebnistex&t löschen"
        '
        'tsmClearSource
        '
        Me.tsmClearSource.Name = "tsmClearSource"
        Me.tsmClearSource.Size = New System.Drawing.Size(284, 22)
        Me.tsmClearSource.Text = "&Quelltext löschen"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(281, 6)
        '
        'tsmSourceSelectAll
        '
        Me.tsmSourceSelectAll.Name = "tsmSourceSelectAll"
        Me.tsmSourceSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.tsmSourceSelectAll.Size = New System.Drawing.Size(284, 22)
        Me.tsmSourceSelectAll.Text = "Gesamten Quelltext markieren"
        '
        'tsmResultSelectAll
        '
        Me.tsmResultSelectAll.Name = "tsmResultSelectAll"
        Me.tsmResultSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.tsmResultSelectAll.Size = New System.Drawing.Size(284, 22)
        Me.tsmResultSelectAll.Text = "Gesamtext Ergebnistext markieren "
        '
        'btnNewSearchPattern
        '
        Me.btnNewSearchPattern.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewSearchPattern.Location = New System.Drawing.Point(650, 91)
        Me.btnNewSearchPattern.Name = "btnNewSearchPattern"
        Me.btnNewSearchPattern.Size = New System.Drawing.Size(32, 24)
        Me.btnNewSearchPattern.TabIndex = 18
        Me.btnNewSearchPattern.Text = "..."
        '
        'btnPatternLibrary
        '
        Me.btnPatternLibrary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPatternLibrary.Location = New System.Drawing.Point(650, 51)
        Me.btnPatternLibrary.Name = "btnPatternLibrary"
        Me.btnPatternLibrary.Size = New System.Drawing.Size(32, 24)
        Me.btnPatternLibrary.TabIndex = 17
        Me.btnPatternLibrary.Text = "..."
        '
        'btnReplace
        '
        Me.btnReplace.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReplace.Location = New System.Drawing.Point(683, 91)
        Me.btnReplace.Name = "btnReplace"
        Me.btnReplace.Size = New System.Drawing.Size(96, 24)
        Me.btnReplace.TabIndex = 16
        Me.btnReplace.Text = "Ersetzen"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(682, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(96, 24)
        Me.btnSearch.TabIndex = 15
        Me.btnSearch.Text = "Suchen"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "&Quelltext:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "&Ersetzungsmuster"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "&Suchmuster"
        '
        'txtReplacePattern
        '
        Me.txtReplacePattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplacePattern.Location = New System.Drawing.Point(12, 94)
        Me.txtReplacePattern.Name = "txtReplacePattern"
        Me.txtReplacePattern.Size = New System.Drawing.Size(632, 20)
        Me.txtReplacePattern.TabIndex = 13
        '
        'txtSearchPattern
        '
        Me.txtSearchPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchPattern.Location = New System.Drawing.Point(12, 54)
        Me.txtSearchPattern.Name = "txtSearchPattern"
        Me.txtSearchPattern.Size = New System.Drawing.Size(632, 20)
        Me.txtSearchPattern.TabIndex = 11
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 137)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSourceText)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(767, 453)
        Me.SplitContainer1.SplitterDistance = 189
        Me.SplitContainer1.TabIndex = 19
        '
        'txtSourceText
        '
        Me.txtSourceText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSourceText.HideSelection = False
        Me.txtSourceText.Location = New System.Drawing.Point(0, 0)
        Me.txtSourceText.Multiline = True
        Me.txtSourceText.Name = "txtSourceText"
        Me.txtSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSourceText.Size = New System.Drawing.Size(767, 189)
        Me.txtSourceText.TabIndex = 6
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.tvwResults)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtResults)
        Me.SplitContainer2.Size = New System.Drawing.Size(767, 260)
        Me.SplitContainer2.SplitterDistance = 255
        Me.SplitContainer2.TabIndex = 0
        '
        'tvwResults
        '
        Me.tvwResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvwResults.HideSelection = False
        Me.tvwResults.Location = New System.Drawing.Point(0, 0)
        Me.tvwResults.Name = "tvwResults"
        Me.tvwResults.Size = New System.Drawing.Size(255, 260)
        Me.tvwResults.TabIndex = 1
        '
        'txtResults
        '
        Me.txtResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtResults.Location = New System.Drawing.Point(0, 0)
        Me.txtResults.Multiline = True
        Me.txtResults.Name = "txtResults"
        Me.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtResults.Size = New System.Drawing.Size(508, 260)
        Me.txtResults.TabIndex = 3
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 599)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnNewSearchPattern)
        Me.Controls.Add(Me.btnPatternLibrary)
        Me.Controls.Add(Me.btnReplace)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReplacePattern)
        Me.Controls.Add(Me.txtSearchPattern)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "RegExplorer"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btnNewSearchPattern As System.Windows.Forms.Button
    Friend WithEvents btnPatternLibrary As System.Windows.Forms.Button
    Friend WithEvents btnReplace As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReplacePattern As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchPattern As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmLoadSourceFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSaveSourceFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSaveSearchPattern As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmChooseSearchPattern As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmQuitProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCopyResultToSource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmClearSource As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmClearResult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSourceSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmResultSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtSourceText As System.Windows.Forms.TextBox
    Friend WithEvents tvwResults As System.Windows.Forms.TreeView
    Friend WithEvents txtResults As System.Windows.Forms.TextBox
    Friend WithEvents tsmShowGroupCaptures As System.Windows.Forms.ToolStripMenuItem

End Class
