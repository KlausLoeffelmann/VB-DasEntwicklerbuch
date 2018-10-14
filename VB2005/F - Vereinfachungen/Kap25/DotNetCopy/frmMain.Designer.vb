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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.tsmFile = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileOpenCopyList = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmFileSaveCopyList = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmFileQuit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNewCopyListEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditCopyEntryEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEditCopyListEntryDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmTools = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmToolsStartNow = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmToolsOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbLoadCopyList = New System.Windows.Forms.ToolStripButton
        Me.tsbSaveCopyList = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbNewCopyListEntry = New System.Windows.Forms.ToolStripButton
        Me.tsbEditCopyListEntry = New System.Windows.Forms.ToolStripButton
        Me.tsbDeleteCopyListEntry = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbStartNow = New System.Windows.Forms.ToolStripButton
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.lvwCopyEntries = New System.Windows.Forms.ListView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblCurrentPass = New System.Windows.Forms.Label
        Me.lblProgressCaption = New System.Windows.Forms.Label
        Me.lblCurrentDestinationPath = New System.Windows.Forms.Label
        Me.lblDestFileInfo = New System.Windows.Forms.Label
        Me.pbPrepareAndCopy = New System.Windows.Forms.ProgressBar
        Me.lblCurrentSourcePath = New System.Windows.Forms.Label
        Me.lblSourceFileInfo = New System.Windows.Forms.Label
        Me.txtProtocol = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.tsmEdit, Me.tsmTools})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(612, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmFile
        '
        Me.tsmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFileOpenCopyList, Me.tsmFileSaveCopyList, Me.ToolStripMenuItem1, Me.tsmFileQuit})
        Me.tsmFile.Name = "tsmFile"
        Me.tsmFile.Size = New System.Drawing.Size(44, 20)
        Me.tsmFile.Text = "&Datei"
        '
        'tsmFileOpenCopyList
        '
        Me.tsmFileOpenCopyList.Name = "tsmFileOpenCopyList"
        Me.tsmFileOpenCopyList.Size = New System.Drawing.Size(184, 22)
        Me.tsmFileOpenCopyList.Text = "Kopierliste öffnen..."
        '
        'tsmFileSaveCopyList
        '
        Me.tsmFileSaveCopyList.Name = "tsmFileSaveCopyList"
        Me.tsmFileSaveCopyList.Size = New System.Drawing.Size(184, 22)
        Me.tsmFileSaveCopyList.Text = "Kopierliste speichern..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(181, 6)
        '
        'tsmFileQuit
        '
        Me.tsmFileQuit.Name = "tsmFileQuit"
        Me.tsmFileQuit.Size = New System.Drawing.Size(184, 22)
        Me.tsmFileQuit.Text = "Be&enden"
        '
        'tsmEdit
        '
        Me.tsmEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNewCopyListEntry, Me.tsmEditCopyEntryEdit, Me.tsmEditCopyListEntryDelete})
        Me.tsmEdit.Name = "tsmEdit"
        Me.tsmEdit.Size = New System.Drawing.Size(71, 20)
        Me.tsmEdit.Text = "&Bearbeiten"
        '
        'tsmNewCopyListEntry
        '
        Me.tsmNewCopyListEntry.Name = "tsmNewCopyListEntry"
        Me.tsmNewCopyListEntry.Size = New System.Drawing.Size(230, 22)
        Me.tsmNewCopyListEntry.Text = "Neuer Kopierlisteneintrag..."
        '
        'tsmEditCopyEntryEdit
        '
        Me.tsmEditCopyEntryEdit.Enabled = False
        Me.tsmEditCopyEntryEdit.Name = "tsmEditCopyEntryEdit"
        Me.tsmEditCopyEntryEdit.Size = New System.Drawing.Size(230, 22)
        Me.tsmEditCopyEntryEdit.Text = "Kopierlisteneintrag bearbeiten..."
        '
        'tsmEditCopyListEntryDelete
        '
        Me.tsmEditCopyListEntryDelete.Enabled = False
        Me.tsmEditCopyListEntryDelete.Name = "tsmEditCopyListEntryDelete"
        Me.tsmEditCopyListEntryDelete.Size = New System.Drawing.Size(230, 22)
        Me.tsmEditCopyListEntryDelete.Text = "Kopierlisteneintrag löschen"
        '
        'tsmTools
        '
        Me.tsmTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmToolsStartNow, Me.ToolStripMenuItem3, Me.tsmToolsOptions})
        Me.tsmTools.Name = "tsmTools"
        Me.tsmTools.Size = New System.Drawing.Size(50, 20)
        Me.tsmTools.Text = "&Extras"
        '
        'tsmToolsStartNow
        '
        Me.tsmToolsStartNow.Name = "tsmToolsStartNow"
        Me.tsmToolsStartNow.Size = New System.Drawing.Size(140, 22)
        Me.tsmToolsStartNow.Text = "Jetzt starten!"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(137, 6)
        '
        'tsmToolsOptions
        '
        Me.tsmToolsOptions.Name = "tsmToolsOptions"
        Me.tsmToolsOptions.Size = New System.Drawing.Size(140, 22)
        Me.tsmToolsOptions.Text = "&Optionen..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbLoadCopyList, Me.tsbSaveCopyList, Me.ToolStripSeparator1, Me.tsbNewCopyListEntry, Me.tsbEditCopyListEntry, Me.tsbDeleteCopyListEntry, Me.ToolStripSeparator2, Me.tsbOptions, Me.ToolStripSeparator3, Me.tsbStartNow})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(612, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbLoadCopyList
        '
        Me.tsbLoadCopyList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLoadCopyList.Image = CType(resources.GetObject("tsbLoadCopyList.Image"), System.Drawing.Image)
        Me.tsbLoadCopyList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLoadCopyList.Name = "tsbLoadCopyList"
        Me.tsbLoadCopyList.Size = New System.Drawing.Size(23, 22)
        Me.tsbLoadCopyList.Text = "Kopierliste laden"
        '
        'tsbSaveCopyList
        '
        Me.tsbSaveCopyList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveCopyList.Image = CType(resources.GetObject("tsbSaveCopyList.Image"), System.Drawing.Image)
        Me.tsbSaveCopyList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSaveCopyList.Name = "tsbSaveCopyList"
        Me.tsbSaveCopyList.Size = New System.Drawing.Size(23, 22)
        Me.tsbSaveCopyList.Text = "Kopierliste speichern"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbNewCopyListEntry
        '
        Me.tsbNewCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewCopyListEntry.Image = CType(resources.GetObject("tsbNewCopyListEntry.Image"), System.Drawing.Image)
        Me.tsbNewCopyListEntry.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNewCopyListEntry.Name = "tsbNewCopyListEntry"
        Me.tsbNewCopyListEntry.Size = New System.Drawing.Size(23, 22)
        Me.tsbNewCopyListEntry.Text = "Neuer Kopierlisteneintrag"
        '
        'tsbEditCopyListEntry
        '
        Me.tsbEditCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditCopyListEntry.Image = CType(resources.GetObject("tsbEditCopyListEntry.Image"), System.Drawing.Image)
        Me.tsbEditCopyListEntry.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEditCopyListEntry.Name = "tsbEditCopyListEntry"
        Me.tsbEditCopyListEntry.Size = New System.Drawing.Size(23, 22)
        Me.tsbEditCopyListEntry.Text = "Kopierlisteneintrag bearbeiten"
        '
        'tsbDeleteCopyListEntry
        '
        Me.tsbDeleteCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDeleteCopyListEntry.Image = CType(resources.GetObject("tsbDeleteCopyListEntry.Image"), System.Drawing.Image)
        Me.tsbDeleteCopyListEntry.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDeleteCopyListEntry.Name = "tsbDeleteCopyListEntry"
        Me.tsbDeleteCopyListEntry.Size = New System.Drawing.Size(23, 22)
        Me.tsbDeleteCopyListEntry.Text = "Kopierlisteneintrag löschen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbOptions
        '
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOptions.Image = CType(resources.GetObject("tsbOptions.Image"), System.Drawing.Image)
        Me.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOptions.Name = "tsbOptions"
        Me.tsbOptions.Size = New System.Drawing.Size(23, 22)
        Me.tsbOptions.Text = "Optionen"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbStartNow
        '
        Me.tsbStartNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStartNow.Image = CType(resources.GetObject("tsbStartNow.Image"), System.Drawing.Image)
        Me.tsbStartNow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbStartNow.Name = "tsbStartNow"
        Me.tsbStartNow.Size = New System.Drawing.Size(23, 22)
        Me.tsbStartNow.Text = "Kopiervorgang starten"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 49)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(612, 377)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvwCopyEntries)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(604, 351)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Kopierliste"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvwCopyEntries
        '
        Me.lvwCopyEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwCopyEntries.FullRowSelect = True
        Me.lvwCopyEntries.GridLines = True
        Me.lvwCopyEntries.Location = New System.Drawing.Point(3, 3)
        Me.lvwCopyEntries.MultiSelect = False
        Me.lvwCopyEntries.Name = "lvwCopyEntries"
        Me.lvwCopyEntries.Size = New System.Drawing.Size(598, 345)
        Me.lvwCopyEntries.TabIndex = 0
        Me.lvwCopyEntries.UseCompatibleStateImageBehavior = False
        Me.lvwCopyEntries.View = System.Windows.Forms.View.Details
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnCancel)
        Me.TabPage2.Controls.Add(Me.lblCurrentPass)
        Me.TabPage2.Controls.Add(Me.lblProgressCaption)
        Me.TabPage2.Controls.Add(Me.lblCurrentDestinationPath)
        Me.TabPage2.Controls.Add(Me.lblDestFileInfo)
        Me.TabPage2.Controls.Add(Me.pbPrepareAndCopy)
        Me.TabPage2.Controls.Add(Me.lblCurrentSourcePath)
        Me.TabPage2.Controls.Add(Me.lblSourceFileInfo)
        Me.TabPage2.Controls.Add(Me.txtProtocol)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(615, 377)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ausführungsstatus"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(509, 338)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 20)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblCurrentPass
        '
        Me.lblCurrentPass.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentPass.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCurrentPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentPass.Location = New System.Drawing.Point(3, 6)
        Me.lblCurrentPass.Name = "lblCurrentPass"
        Me.lblCurrentPass.Size = New System.Drawing.Size(609, 23)
        Me.lblCurrentPass.TabIndex = 7
        Me.lblCurrentPass.Text = "Pass 1: Kopiervorbereitung durch Zusammenstellung der Pfade..."
        Me.lblCurrentPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProgressCaption
        '
        Me.lblProgressCaption.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProgressCaption.AutoSize = True
        Me.lblProgressCaption.Location = New System.Drawing.Point(5, 341)
        Me.lblProgressCaption.Name = "lblProgressCaption"
        Me.lblProgressCaption.Size = New System.Drawing.Size(119, 13)
        Me.lblProgressCaption.TabIndex = 6
        Me.lblProgressCaption.Text = "Fortschritt Vorbereitung:"
        '
        'lblCurrentDestinationPath
        '
        Me.lblCurrentDestinationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentDestinationPath.AutoEllipsis = True
        Me.lblCurrentDestinationPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentDestinationPath.Location = New System.Drawing.Point(165, 305)
        Me.lblCurrentDestinationPath.Name = "lblCurrentDestinationPath"
        Me.lblCurrentDestinationPath.Size = New System.Drawing.Size(436, 18)
        Me.lblCurrentDestinationPath.TabIndex = 5
        Me.lblCurrentDestinationPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDestFileInfo
        '
        Me.lblDestFileInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDestFileInfo.AutoSize = True
        Me.lblDestFileInfo.Location = New System.Drawing.Point(5, 310)
        Me.lblDestFileInfo.Name = "lblDestFileInfo"
        Me.lblDestFileInfo.Size = New System.Drawing.Size(79, 13)
        Me.lblDestFileInfo.TabIndex = 4
        Me.lblDestFileInfo.Text = "Kopieren nach:"
        '
        'pbPrepareAndCopy
        '
        Me.pbPrepareAndCopy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbPrepareAndCopy.Location = New System.Drawing.Point(165, 338)
        Me.pbPrepareAndCopy.Name = "pbPrepareAndCopy"
        Me.pbPrepareAndCopy.Size = New System.Drawing.Size(338, 20)
        Me.pbPrepareAndCopy.TabIndex = 3
        '
        'lblCurrentSourcePath
        '
        Me.lblCurrentSourcePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCurrentSourcePath.AutoEllipsis = True
        Me.lblCurrentSourcePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentSourcePath.Location = New System.Drawing.Point(165, 281)
        Me.lblCurrentSourcePath.Name = "lblCurrentSourcePath"
        Me.lblCurrentSourcePath.Size = New System.Drawing.Size(436, 18)
        Me.lblCurrentSourcePath.TabIndex = 2
        Me.lblCurrentSourcePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSourceFileInfo
        '
        Me.lblSourceFileInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblSourceFileInfo.AutoSize = True
        Me.lblSourceFileInfo.Location = New System.Drawing.Point(5, 284)
        Me.lblSourceFileInfo.Name = "lblSourceFileInfo"
        Me.lblSourceFileInfo.Size = New System.Drawing.Size(149, 13)
        Me.lblSourceFileInfo.TabIndex = 1
        Me.lblSourceFileInfo.Text = "Unterverzeichnisse suchen in:"
        '
        'txtProtocol
        '
        Me.txtProtocol.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProtocol.Location = New System.Drawing.Point(3, 32)
        Me.txtProtocol.Multiline = True
        Me.txtProtocol.Name = "txtProtocol"
        Me.txtProtocol.ReadOnly = True
        Me.txtProtocol.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProtocol.Size = New System.Drawing.Size(606, 237)
        Me.txtProtocol.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 426)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DotNetCopy:  ""My""-Demo in Visual Basic 2005 - Das Entwicklerbuch"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFileOpenCopyList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmFileSaveCopyList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmFileQuit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNewCopyListEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEditCopyListEntryDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmTools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmToolsOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmToolsStartNow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lvwCopyEntries As System.Windows.Forms.ListView
    Friend WithEvents tsmEditCopyEntryEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCurrentSourcePath As System.Windows.Forms.Label
    Friend WithEvents lblSourceFileInfo As System.Windows.Forms.Label
    Friend WithEvents txtProtocol As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrentPass As System.Windows.Forms.Label
    Friend WithEvents lblProgressCaption As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDestinationPath As System.Windows.Forms.Label
    Friend WithEvents lblDestFileInfo As System.Windows.Forms.Label
    Friend WithEvents pbPrepareAndCopy As System.Windows.Forms.ProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents tsbLoadCopyList As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSaveCopyList As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbNewCopyListEntry As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEditCopyListEntry As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbDeleteCopyListEntry As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbStartNow As System.Windows.Forms.ToolStripButton

End Class
