<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Me.chkNeverOverwriteFiles = New System.Windows.Forms.CheckBox
        Me.chkOnlyOverwriteIfOlder = New System.Windows.Forms.CheckBox
        Me.chkEnableBackupHistory = New System.Windows.Forms.CheckBox
        Me.nudHistoryLevels = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkOnCopyErrorContinue = New System.Windows.Forms.CheckBox
        Me.chkCopySystemFiles = New System.Windows.Forms.CheckBox
        Me.chkCopyHiddenFiles = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.chkCopyFoldersRecursive = New System.Windows.Forms.CheckBox
        Me.chkBackupInHiddenFiles = New System.Windows.Forms.CheckBox
        Me.chkAutoSaveProtocol = New System.Windows.Forms.CheckBox
        Me.lblProtocolPath = New System.Windows.Forms.Label
        Me.btnPickProtocolPath = New System.Windows.Forms.Button
        CType(Me.nudHistoryLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkNeverOverwriteFiles
        '
        Me.chkNeverOverwriteFiles.AutoSize = True
        Me.chkNeverOverwriteFiles.Location = New System.Drawing.Point(12, 35)
        Me.chkNeverOverwriteFiles.Name = "chkNeverOverwriteFiles"
        Me.chkNeverOverwriteFiles.Size = New System.Drawing.Size(224, 17)
        Me.chkNeverOverwriteFiles.TabIndex = 0
        Me.chkNeverOverwriteFiles.Text = "Dateien grundsätzlich nicht überschreiben"
        Me.chkNeverOverwriteFiles.UseVisualStyleBackColor = True
        '
        'chkOnlyOverwriteIfOlder
        '
        Me.chkOnlyOverwriteIfOlder.AutoSize = True
        Me.chkOnlyOverwriteIfOlder.Location = New System.Drawing.Point(12, 58)
        Me.chkOnlyOverwriteIfOlder.Name = "chkOnlyOverwriteIfOlder"
        Me.chkOnlyOverwriteIfOlder.Size = New System.Drawing.Size(324, 17)
        Me.chkOnlyOverwriteIfOlder.TabIndex = 1
        Me.chkOnlyOverwriteIfOlder.Text = "Dateien nur überschreiben, falls älter als zu kopierende Dateien"
        Me.chkOnlyOverwriteIfOlder.UseVisualStyleBackColor = True
        '
        'chkEnableBackupHistory
        '
        Me.chkEnableBackupHistory.AutoSize = True
        Me.chkEnableBackupHistory.Location = New System.Drawing.Point(30, 81)
        Me.chkEnableBackupHistory.Name = "chkEnableBackupHistory"
        Me.chkEnableBackupHistory.Size = New System.Drawing.Size(211, 17)
        Me.chkEnableBackupHistory.TabIndex = 2
        Me.chkEnableBackupHistory.Text = "Wenn überschreiben, dann Backup mit"
        Me.chkEnableBackupHistory.UseVisualStyleBackColor = True
        '
        'nudHistoryLevels
        '
        Me.nudHistoryLevels.Location = New System.Drawing.Point(247, 80)
        Me.nudHistoryLevels.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudHistoryLevels.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudHistoryLevels.Name = "nudHistoryLevels"
        Me.nudHistoryLevels.Size = New System.Drawing.Size(32, 20)
        Me.nudHistoryLevels.TabIndex = 3
        Me.nudHistoryLevels.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(285, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Historie-Ebenen"
        '
        'chkOnCopyErrorContinue
        '
        Me.chkOnCopyErrorContinue.AutoSize = True
        Me.chkOnCopyErrorContinue.Location = New System.Drawing.Point(12, 143)
        Me.chkOnCopyErrorContinue.Name = "chkOnCopyErrorContinue"
        Me.chkOnCopyErrorContinue.Size = New System.Drawing.Size(317, 17)
        Me.chkOnCopyErrorContinue.TabIndex = 5
        Me.chkOnCopyErrorContinue.Text = "Kopieren nach dem Auftreten von Fehlern dennoch fortsetzen"
        Me.chkOnCopyErrorContinue.UseVisualStyleBackColor = True
        '
        'chkCopySystemFiles
        '
        Me.chkCopySystemFiles.AutoSize = True
        Me.chkCopySystemFiles.Location = New System.Drawing.Point(12, 166)
        Me.chkCopySystemFiles.Name = "chkCopySystemFiles"
        Me.chkCopySystemFiles.Size = New System.Drawing.Size(139, 17)
        Me.chkCopySystemFiles.TabIndex = 6
        Me.chkCopySystemFiles.Text = "Systemdateien kopieren"
        Me.chkCopySystemFiles.UseVisualStyleBackColor = True
        '
        'chkCopyHiddenFiles
        '
        Me.chkCopyHiddenFiles.AutoSize = True
        Me.chkCopyHiddenFiles.Location = New System.Drawing.Point(12, 189)
        Me.chkCopyHiddenFiles.Name = "chkCopyHiddenFiles"
        Me.chkCopyHiddenFiles.Size = New System.Drawing.Size(161, 17)
        Me.chkCopyHiddenFiles.TabIndex = 7
        Me.chkCopyHiddenFiles.Text = "Versteckte Dateien kopieren"
        Me.chkCopyHiddenFiles.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(196, 281)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(92, 33)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(294, 281)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 33)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'chkCopyFoldersRecursive
        '
        Me.chkCopyFoldersRecursive.AutoSize = True
        Me.chkCopyFoldersRecursive.Location = New System.Drawing.Point(12, 12)
        Me.chkCopyFoldersRecursive.Name = "chkCopyFoldersRecursive"
        Me.chkCopyFoldersRecursive.Size = New System.Drawing.Size(268, 17)
        Me.chkCopyFoldersRecursive.TabIndex = 10
        Me.chkCopyFoldersRecursive.Text = "Kopieren incl. der Unterordner eines Verzeichnisses"
        Me.chkCopyFoldersRecursive.UseVisualStyleBackColor = True
        '
        'chkBackupInHiddenFiles
        '
        Me.chkBackupInHiddenFiles.AutoSize = True
        Me.chkBackupInHiddenFiles.Location = New System.Drawing.Point(30, 104)
        Me.chkBackupInHiddenFiles.Name = "chkBackupInHiddenFiles"
        Me.chkBackupInHiddenFiles.Size = New System.Drawing.Size(263, 17)
        Me.chkBackupInHiddenFiles.TabIndex = 11
        Me.chkBackupInHiddenFiles.Text = "Backupdateien in 'versteckte Dateien' umwandeln"
        Me.chkBackupInHiddenFiles.UseVisualStyleBackColor = True
        '
        'chkAutoSaveProtocol
        '
        Me.chkAutoSaveProtocol.AutoSize = True
        Me.chkAutoSaveProtocol.Location = New System.Drawing.Point(12, 223)
        Me.chkAutoSaveProtocol.Name = "chkAutoSaveProtocol"
        Me.chkAutoSaveProtocol.Size = New System.Drawing.Size(246, 17)
        Me.chkAutoSaveProtocol.TabIndex = 12
        Me.chkAutoSaveProtocol.Text = "Protokoll automatisch speichern im Verzeichnis"
        Me.chkAutoSaveProtocol.UseVisualStyleBackColor = True
        '
        'lblProtocolPath
        '
        Me.lblProtocolPath.AutoEllipsis = True
        Me.lblProtocolPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblProtocolPath.Location = New System.Drawing.Point(30, 243)
        Me.lblProtocolPath.Name = "lblProtocolPath"
        Me.lblProtocolPath.Size = New System.Drawing.Size(321, 19)
        Me.lblProtocolPath.TabIndex = 13
        '
        'btnPickProtocolPath
        '
        Me.btnPickProtocolPath.Location = New System.Drawing.Point(357, 243)
        Me.btnPickProtocolPath.Name = "btnPickProtocolPath"
        Me.btnPickProtocolPath.Size = New System.Drawing.Size(29, 19)
        Me.btnPickProtocolPath.TabIndex = 14
        Me.btnPickProtocolPath.Text = "..."
        Me.btnPickProtocolPath.UseVisualStyleBackColor = True
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 326)
        Me.Controls.Add(Me.btnPickProtocolPath)
        Me.Controls.Add(Me.lblProtocolPath)
        Me.Controls.Add(Me.chkAutoSaveProtocol)
        Me.Controls.Add(Me.chkBackupInHiddenFiles)
        Me.Controls.Add(Me.chkCopyFoldersRecursive)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkCopyHiddenFiles)
        Me.Controls.Add(Me.chkCopySystemFiles)
        Me.Controls.Add(Me.chkOnCopyErrorContinue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudHistoryLevels)
        Me.Controls.Add(Me.chkEnableBackupHistory)
        Me.Controls.Add(Me.chkOnlyOverwriteIfOlder)
        Me.Controls.Add(Me.chkNeverOverwriteFiles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Optionen"
        CType(Me.nudHistoryLevels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkNeverOverwriteFiles As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlyOverwriteIfOlder As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableBackupHistory As System.Windows.Forms.CheckBox
    Friend WithEvents nudHistoryLevels As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOnCopyErrorContinue As System.Windows.Forms.CheckBox
    Friend WithEvents chkCopySystemFiles As System.Windows.Forms.CheckBox
    Friend WithEvents chkCopyHiddenFiles As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkCopyFoldersRecursive As System.Windows.Forms.CheckBox
    Friend WithEvents chkBackupInHiddenFiles As System.Windows.Forms.CheckBox
    Friend WithEvents chkAutoSaveProtocol As System.Windows.Forms.CheckBox
    Friend WithEvents lblProtocolPath As System.Windows.Forms.Label
    Friend WithEvents btnPickProtocolPath As System.Windows.Forms.Button
End Class
