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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.chkEpisodeNameFilter = New System.Windows.Forms.CheckBox
        Me.txtReplace = New System.Windows.Forms.TextBox
        Me.btnReplaceChecked = New System.Windows.Forms.Button
        Me.btnCheckFound = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnGenerateTestFiles = New System.Windows.Forms.Button
        Me.btnDateinamenInDatei = New System.Windows.Forms.Button
        Me.btnUncheckAll = New System.Windows.Forms.Button
        Me.btnCheckAll = New System.Windows.Forms.Button
        Me.txtPathForTestFiles = New System.Windows.Forms.TextBox
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.btnRenameFiles = New System.Windows.Forms.Button
        Me.txtDirectory = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnTestFilesDirectory = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDirectory = New System.Windows.Forms.Button
        Me.fneFiles = New Dateinamenangleicher.FilenameEnumerator
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkEpisodeNameFilter
        '
        Me.chkEpisodeNameFilter.Checked = True
        Me.chkEpisodeNameFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEpisodeNameFilter.Location = New System.Drawing.Point(16, 24)
        Me.chkEpisodeNameFilter.Name = "chkEpisodeNameFilter"
        Me.chkEpisodeNameFilter.Size = New System.Drawing.Size(160, 16)
        Me.chkEpisodeNameFilter.TabIndex = 0
        Me.chkEpisodeNameFilter.Text = "Seriennamen-Filter"
        '
        'txtReplace
        '
        Me.txtReplace.Location = New System.Drawing.Point(8, 336)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(168, 20)
        Me.txtReplace.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.txtReplace, "Geben Sie hier den Begriff ein, durch den der Suchbegriff in den Namen der markie" & _
                "rten Dateien ersetzt werden soll")
        '
        'btnReplaceChecked
        '
        Me.btnReplaceChecked.Location = New System.Drawing.Point(8, 312)
        Me.btnReplaceChecked.Name = "btnReplaceChecked"
        Me.btnReplaceChecked.Size = New System.Drawing.Size(168, 24)
        Me.btnReplaceChecked.TabIndex = 10
        Me.btnReplaceChecked.Text = "Markierte ersetzen durch"
        Me.ToolTip1.SetToolTip(Me.btnReplaceChecked, "Ersetzt den Suchbegriff (oben einzugeben) durch den unten einzugebenen Begriff")
        '
        'btnCheckFound
        '
        Me.btnCheckFound.Location = New System.Drawing.Point(8, 264)
        Me.btnCheckFound.Name = "btnCheckFound"
        Me.btnCheckFound.Size = New System.Drawing.Size(168, 24)
        Me.btnCheckFound.TabIndex = 8
        Me.btnCheckFound.Text = "Alle markieren mit"
        Me.ToolTip1.SetToolTip(Me.btnCheckFound, "Markiert alle Dateiein, in denen der unten anzugebene Suchbegriff vorkommt")
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(8, 288)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(168, 20)
        Me.txtSearch.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtSearch, "Geben SIe hier den Suchbegriff ein")
        '
        'btnGenerateTestFiles
        '
        Me.btnGenerateTestFiles.Location = New System.Drawing.Point(8, 192)
        Me.btnGenerateTestFiles.Name = "btnGenerateTestFiles"
        Me.btnGenerateTestFiles.Size = New System.Drawing.Size(143, 24)
        Me.btnGenerateTestFiles.TabIndex = 5
        Me.btnGenerateTestFiles.Text = "Testdateien generieren"
        Me.ToolTip1.SetToolTip(Me.btnGenerateTestFiles, "Generiert Testdateien aus der vorhandenen Dateinamenliste")
        '
        'btnDateinamenInDatei
        '
        Me.btnDateinamenInDatei.Location = New System.Drawing.Point(8, 152)
        Me.btnDateinamenInDatei.Name = "btnDateinamenInDatei"
        Me.btnDateinamenInDatei.Size = New System.Drawing.Size(168, 24)
        Me.btnDateinamenInDatei.TabIndex = 4
        Me.btnDateinamenInDatei.Text = "Dateinamen in Datei"
        Me.ToolTip1.SetToolTip(Me.btnDateinamenInDatei, "Legt eine Textdatei mit allen Dateinamen an")
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Location = New System.Drawing.Point(8, 120)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(168, 24)
        Me.btnUncheckAll.TabIndex = 3
        Me.btnUncheckAll.Text = "Markierungen aufheben"
        Me.ToolTip1.SetToolTip(Me.btnUncheckAll, "Hebt die Markierung aller Dateinamen wieder auf")
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(8, 88)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(168, 24)
        Me.btnCheckAll.TabIndex = 2
        Me.btnCheckAll.Text = "Alle markieren"
        Me.ToolTip1.SetToolTip(Me.btnCheckAll, "Markiert alle Dateinamen")
        '
        'txtPathForTestFiles
        '
        Me.txtPathForTestFiles.Location = New System.Drawing.Point(8, 224)
        Me.txtPathForTestFiles.Name = "txtPathForTestFiles"
        Me.txtPathForTestFiles.Size = New System.Drawing.Size(168, 20)
        Me.txtPathForTestFiles.TabIndex = 7
        Me.txtPathForTestFiles.Text = "C:\"
        Me.ToolTip1.SetToolTip(Me.txtPathForTestFiles, "Das Ausgabeverzeichnis der Testdateien")
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuitProgram.Location = New System.Drawing.Point(6, 537)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(168, 24)
        Me.btnQuitProgram.TabIndex = 12
        Me.btnQuitProgram.Text = "Programm beenden"
        Me.ToolTip1.SetToolTip(Me.btnQuitProgram, "Beendet das Programm")
        '
        'btnRenameFiles
        '
        Me.btnRenameFiles.Location = New System.Drawing.Point(8, 56)
        Me.btnRenameFiles.Name = "btnRenameFiles"
        Me.btnRenameFiles.Size = New System.Drawing.Size(168, 24)
        Me.btnRenameFiles.TabIndex = 1
        Me.btnRenameFiles.Text = "Markierte Dateien umbenennen"
        Me.ToolTip1.SetToolTip(Me.btnRenameFiles, "Benennt alle markierte Dateien in den neuen Dateinamen um")
        '
        'txtDirectory
        '
        Me.txtDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirectory.Location = New System.Drawing.Point(16, 32)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.ReadOnly = True
        Me.txtDirectory.Size = New System.Drawing.Size(678, 20)
        Me.txtDirectory.TabIndex = 0
        Me.txtDirectory.Text = "C:\"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkEpisodeNameFilter)
        Me.GroupBox2.Controls.Add(Me.txtReplace)
        Me.GroupBox2.Controls.Add(Me.btnReplaceChecked)
        Me.GroupBox2.Controls.Add(Me.btnCheckFound)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.btnQuitProgram)
        Me.GroupBox2.Controls.Add(Me.btnTestFilesDirectory)
        Me.GroupBox2.Controls.Add(Me.txtPathForTestFiles)
        Me.GroupBox2.Controls.Add(Me.btnGenerateTestFiles)
        Me.GroupBox2.Controls.Add(Me.btnDateinamenInDatei)
        Me.GroupBox2.Controls.Add(Me.btnUncheckAll)
        Me.GroupBox2.Controls.Add(Me.btnCheckAll)
        Me.GroupBox2.Controls.Add(Me.btnRenameFiles)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(624, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 573)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funktionen:"
        '
        'btnTestFilesDirectory
        '
        Me.btnTestFilesDirectory.Location = New System.Drawing.Point(152, 192)
        Me.btnTestFilesDirectory.Name = "btnTestFilesDirectory"
        Me.btnTestFilesDirectory.Size = New System.Drawing.Size(24, 24)
        Me.btnTestFilesDirectory.TabIndex = 6
        Me.btnTestFilesDirectory.Text = "..."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDirectory)
        Me.GroupBox1.Controls.Add(Me.btnDirectory)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 88)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Suchpfad:"
        '
        'btnDirectory
        '
        Me.btnDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirectory.Location = New System.Drawing.Point(700, 32)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(96, 24)
        Me.btnDirectory.TabIndex = 1
        Me.btnDirectory.Text = "Verzeichnis..."
        '
        'fneFiles
        '
        Me.fneFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fneFiles.CheckBoxes = True
        Me.fneFiles.Directory = CType(resources.GetObject("fneFiles.Directory"), System.IO.DirectoryInfo)
        Me.fneFiles.EpisodeNameFilter = True
        Me.fneFiles.GridLines = True
        Me.fneFiles.Location = New System.Drawing.Point(0, 94)
        Me.fneFiles.Name = "fneFiles"
        Me.fneFiles.Size = New System.Drawing.Size(618, 567)
        Me.fneFiles.TabIndex = 5
        Me.fneFiles.UseCompatibleStateImageBehavior = False
        Me.fneFiles.View = System.Windows.Forms.View.Details
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 661)
        Me.Controls.Add(Me.fneFiles)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMain"
        Me.Text = "Dateinamenausgleicher"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkEpisodeNameFilter As System.Windows.Forms.CheckBox
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnReplaceChecked As System.Windows.Forms.Button
    Friend WithEvents btnCheckFound As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerateTestFiles As System.Windows.Forms.Button
    Friend WithEvents btnDateinamenInDatei As System.Windows.Forms.Button
    Friend WithEvents btnUncheckAll As System.Windows.Forms.Button
    Friend WithEvents btnCheckAll As System.Windows.Forms.Button
    Friend WithEvents txtPathForTestFiles As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents btnRenameFiles As System.Windows.Forms.Button
    Friend WithEvents txtDirectory As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnTestFilesDirectory As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents fneFiles As Dateinamenangleicher.FilenameEnumerator

End Class
