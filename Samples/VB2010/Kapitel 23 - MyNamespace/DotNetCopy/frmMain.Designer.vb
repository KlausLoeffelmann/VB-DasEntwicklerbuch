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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFileOpenCopyList = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmFileSaveCopyList = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmFileQuit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmNewCopyListEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEditCopyEntryEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmEditCopyListEntryDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmToolsStartNow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmToolsOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbLoadCopyList = New System.Windows.Forms.ToolStripButton()
        Me.tsbSaveCopyList = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbNewCopyListEntry = New System.Windows.Forms.ToolStripButton()
        Me.tsbEditCopyListEntry = New System.Windows.Forms.ToolStripButton()
        Me.tsbDeleteCopyListEntry = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbOptions = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbStartNow = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvwCopyEntries = New System.Windows.Forms.ListView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblCurrentPass = New System.Windows.Forms.Label()
        Me.lblProgressCaption = New System.Windows.Forms.Label()
        Me.lblCurrentDestinationPath = New System.Windows.Forms.Label()
        Me.lblDestFileInfo = New System.Windows.Forms.Label()
        Me.pbPrepareAndCopy = New System.Windows.Forms.ProgressBar()
        Me.lblCurrentSourcePath = New System.Windows.Forms.Label()
        Me.lblSourceFileInfo = New System.Windows.Forms.Label()
        Me.txtProtocol = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFile, Me.tsmEdit, Me.tsmTools})
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'tsmFile
        '
        resources.ApplyResources(Me.tsmFile, "tsmFile")
        Me.tsmFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFileOpenCopyList, Me.tsmFileSaveCopyList, Me.ToolStripMenuItem1, Me.tsmFileQuit})
        Me.tsmFile.Name = "tsmFile"
        '
        'tsmFileOpenCopyList
        '
        resources.ApplyResources(Me.tsmFileOpenCopyList, "tsmFileOpenCopyList")
        Me.tsmFileOpenCopyList.Name = "tsmFileOpenCopyList"
        '
        'tsmFileSaveCopyList
        '
        resources.ApplyResources(Me.tsmFileSaveCopyList, "tsmFileSaveCopyList")
        Me.tsmFileSaveCopyList.Name = "tsmFileSaveCopyList"
        '
        'ToolStripMenuItem1
        '
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        '
        'tsmFileQuit
        '
        resources.ApplyResources(Me.tsmFileQuit, "tsmFileQuit")
        Me.tsmFileQuit.Name = "tsmFileQuit"
        '
        'tsmEdit
        '
        resources.ApplyResources(Me.tsmEdit, "tsmEdit")
        Me.tsmEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNewCopyListEntry, Me.tsmEditCopyEntryEdit, Me.tsmEditCopyListEntryDelete})
        Me.tsmEdit.Name = "tsmEdit"
        '
        'tsmNewCopyListEntry
        '
        resources.ApplyResources(Me.tsmNewCopyListEntry, "tsmNewCopyListEntry")
        Me.tsmNewCopyListEntry.Name = "tsmNewCopyListEntry"
        '
        'tsmEditCopyEntryEdit
        '
        resources.ApplyResources(Me.tsmEditCopyEntryEdit, "tsmEditCopyEntryEdit")
        Me.tsmEditCopyEntryEdit.Name = "tsmEditCopyEntryEdit"
        '
        'tsmEditCopyListEntryDelete
        '
        resources.ApplyResources(Me.tsmEditCopyListEntryDelete, "tsmEditCopyListEntryDelete")
        Me.tsmEditCopyListEntryDelete.Name = "tsmEditCopyListEntryDelete"
        '
        'tsmTools
        '
        resources.ApplyResources(Me.tsmTools, "tsmTools")
        Me.tsmTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmToolsStartNow, Me.ToolStripMenuItem3, Me.tsmToolsOptions})
        Me.tsmTools.Name = "tsmTools"
        '
        'tsmToolsStartNow
        '
        resources.ApplyResources(Me.tsmToolsStartNow, "tsmToolsStartNow")
        Me.tsmToolsStartNow.Name = "tsmToolsStartNow"
        '
        'ToolStripMenuItem3
        '
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        '
        'tsmToolsOptions
        '
        resources.ApplyResources(Me.tsmToolsOptions, "tsmToolsOptions")
        Me.tsmToolsOptions.Name = "tsmToolsOptions"
        '
        'ToolStrip1
        '
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbLoadCopyList, Me.tsbSaveCopyList, Me.ToolStripSeparator1, Me.tsbNewCopyListEntry, Me.tsbEditCopyListEntry, Me.tsbDeleteCopyListEntry, Me.ToolStripSeparator2, Me.tsbOptions, Me.ToolStripSeparator3, Me.tsbStartNow})
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'tsbLoadCopyList
        '
        resources.ApplyResources(Me.tsbLoadCopyList, "tsbLoadCopyList")
        Me.tsbLoadCopyList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLoadCopyList.Name = "tsbLoadCopyList"
        '
        'tsbSaveCopyList
        '
        resources.ApplyResources(Me.tsbSaveCopyList, "tsbSaveCopyList")
        Me.tsbSaveCopyList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSaveCopyList.Name = "tsbSaveCopyList"
        '
        'ToolStripSeparator1
        '
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'tsbNewCopyListEntry
        '
        resources.ApplyResources(Me.tsbNewCopyListEntry, "tsbNewCopyListEntry")
        Me.tsbNewCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbNewCopyListEntry.Name = "tsbNewCopyListEntry"
        '
        'tsbEditCopyListEntry
        '
        resources.ApplyResources(Me.tsbEditCopyListEntry, "tsbEditCopyListEntry")
        Me.tsbEditCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbEditCopyListEntry.Name = "tsbEditCopyListEntry"
        '
        'tsbDeleteCopyListEntry
        '
        resources.ApplyResources(Me.tsbDeleteCopyListEntry, "tsbDeleteCopyListEntry")
        Me.tsbDeleteCopyListEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDeleteCopyListEntry.Name = "tsbDeleteCopyListEntry"
        '
        'ToolStripSeparator2
        '
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        '
        'tsbOptions
        '
        resources.ApplyResources(Me.tsbOptions, "tsbOptions")
        Me.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOptions.Name = "tsbOptions"
        '
        'ToolStripSeparator3
        '
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        '
        'tsbStartNow
        '
        resources.ApplyResources(Me.tsbStartNow, "tsbStartNow")
        Me.tsbStartNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbStartNow.Name = "tsbStartNow"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.lvwCopyEntries)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvwCopyEntries
        '
        resources.ApplyResources(Me.lvwCopyEntries, "lvwCopyEntries")
        Me.lvwCopyEntries.FullRowSelect = True
        Me.lvwCopyEntries.GridLines = True
        Me.lvwCopyEntries.MultiSelect = False
        Me.lvwCopyEntries.Name = "lvwCopyEntries"
        Me.lvwCopyEntries.UseCompatibleStateImageBehavior = False
        Me.lvwCopyEntries.View = System.Windows.Forms.View.Details
        '
        'TabPage2
        '
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Controls.Add(Me.btnCancel)
        Me.TabPage2.Controls.Add(Me.lblCurrentPass)
        Me.TabPage2.Controls.Add(Me.lblProgressCaption)
        Me.TabPage2.Controls.Add(Me.lblCurrentDestinationPath)
        Me.TabPage2.Controls.Add(Me.lblDestFileInfo)
        Me.TabPage2.Controls.Add(Me.pbPrepareAndCopy)
        Me.TabPage2.Controls.Add(Me.lblCurrentSourcePath)
        Me.TabPage2.Controls.Add(Me.lblSourceFileInfo)
        Me.TabPage2.Controls.Add(Me.txtProtocol)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblCurrentPass
        '
        resources.ApplyResources(Me.lblCurrentPass, "lblCurrentPass")
        Me.lblCurrentPass.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCurrentPass.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCurrentPass.Name = "lblCurrentPass"
        '
        'lblProgressCaption
        '
        resources.ApplyResources(Me.lblProgressCaption, "lblProgressCaption")
        Me.lblProgressCaption.Name = "lblProgressCaption"
        '
        'lblCurrentDestinationPath
        '
        resources.ApplyResources(Me.lblCurrentDestinationPath, "lblCurrentDestinationPath")
        Me.lblCurrentDestinationPath.AutoEllipsis = True
        Me.lblCurrentDestinationPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentDestinationPath.Name = "lblCurrentDestinationPath"
        '
        'lblDestFileInfo
        '
        resources.ApplyResources(Me.lblDestFileInfo, "lblDestFileInfo")
        Me.lblDestFileInfo.Name = "lblDestFileInfo"
        '
        'pbPrepareAndCopy
        '
        resources.ApplyResources(Me.pbPrepareAndCopy, "pbPrepareAndCopy")
        Me.pbPrepareAndCopy.Name = "pbPrepareAndCopy"
        '
        'lblCurrentSourcePath
        '
        resources.ApplyResources(Me.lblCurrentSourcePath, "lblCurrentSourcePath")
        Me.lblCurrentSourcePath.AutoEllipsis = True
        Me.lblCurrentSourcePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCurrentSourcePath.Name = "lblCurrentSourcePath"
        '
        'lblSourceFileInfo
        '
        resources.ApplyResources(Me.lblSourceFileInfo, "lblSourceFileInfo")
        Me.lblSourceFileInfo.Name = "lblSourceFileInfo"
        '
        'txtProtocol
        '
        resources.ApplyResources(Me.txtProtocol, "txtProtocol")
        Me.txtProtocol.Name = "txtProtocol"
        Me.txtProtocol.ReadOnly = True
        '
        'frmMain
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
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
