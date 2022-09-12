Public Class frmOptions

    Private Sub frmOptions_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Anwendungseinstellungen im Dialog widerspiegeln lassen:
        'Auch dazu wird My.Settings verwendet.
        chkCopyFoldersRecursive.Checked = My.Settings.Option_CopyFoldersRecursive
        chkCopyHiddenFiles.Checked = My.Settings.Option_CopyHiddenFiles
        chkCopySystemFiles.Checked = My.Settings.Option_CopySystemFiles
        chkEnableBackupHistory.Checked = My.Settings.Option_EnableBackupHistory
        nudHistoryLevels.Value = My.Settings.Option_HistoryLevels
        chkNeverOverwriteFiles.Checked = My.Settings.Option_NeverOverwriteFiles
        chkOnCopyErrorContinue.Checked = My.Settings.Option_OnCopyErrorContinue
        chkOnlyOverwriteIfOlder.Checked = My.Settings.Option_OnlyOverwriteIfOlder
        chkBackupInHiddenFiles.Checked = My.Settings.Option_BackupInHiddenFiles
        chkAutoSaveProtocol.Checked = My.Settings.Option_AutoSaveProtocol
        lblProtocolPath.Text = My.Settings.Option_AutoSaveProtocolPath
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Das Setzen des Dialogergebnisses bei einem modal aufgerufenen Dialog
        'bewirkt gleichzetig, dass dieser geschlossen wird!
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Die Einstellungen des Options-Dialogs in den Anwendungseinstellung speichern.
        'Auch dazu wird My.Settings verwendet.
        My.Settings.Option_CopyFoldersRecursive = chkCopyFoldersRecursive.Checked
        My.Settings.Option_CopyHiddenFiles = chkCopyHiddenFiles.Checked
        My.Settings.Option_CopySystemFiles = chkCopySystemFiles.Checked
        My.Settings.Option_EnableBackupHistory = chkEnableBackupHistory.Checked
        My.Settings.Option_HistoryLevels = CInt(nudHistoryLevels.Value)
        My.Settings.Option_NeverOverwriteFiles = chkNeverOverwriteFiles.Checked
        My.Settings.Option_OnCopyErrorContinue = chkOnCopyErrorContinue.Checked
        My.Settings.Option_OnlyOverwriteIfOlder = chkOnlyOverwriteIfOlder.Checked
        My.Settings.Option_BackupInHiddenFiles = chkBackupInHiddenFiles.Checked
        My.Settings.Option_AutoSaveProtocol = chkAutoSaveProtocol.Checked
        My.Settings.Option_AutoSaveProtocolPath = lblProtocolPath.Text

        'Das Setzen des Dialogergebnisses bei einem modal aufgerufenen Dialog
        'bewirkt gleichzetig, dass dieser geschlossen wird!
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'Widersprüchliche Einstellungen werden in den CheckedChanged-Ereignissen
    'abgefangen und geregelt:
    Private Sub chkEnableBackupHistory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnableBackupHistory.CheckedChanged
        If chkEnableBackupHistory.Checked Then
            chkOnlyOverwriteIfOlder.Checked = True
        End If
    End Sub

    Private Sub chkBackupInHiddenFiles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBackupInHiddenFiles.CheckedChanged
        If chkBackupInHiddenFiles.Checked Then
            chkEnableBackupHistory.Checked = True
        End If
    End Sub

    Private Sub chkOnlyOverwriteIfOlder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOnlyOverwriteIfOlder.CheckedChanged
        If chkOnlyOverwriteIfOlder.Checked Then
            chkNeverOverwriteFiles.Checked = False
        Else
            chkNeverOverwriteFiles.Checked = True
        End If
    End Sub

    Private Sub chkNeverOverwriteFiles_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNeverOverwriteFiles.CheckedChanged
        If chkNeverOverwriteFiles.Checked Then
            chkOnlyOverwriteIfOlder.Checked = False
            chkEnableBackupHistory.Checked = False
            chkBackupInHiddenFiles.Checked = False
        Else
            chkOnlyOverwriteIfOlder.Checked = True
        End If
    End Sub

    ''' <summary>
    ''' Behandelt das Click-Ereignis beider Auslassungsschaltflächen zur Ordnerwahl.
    ''' </summary>
    ''' <param name="sender">Dient zur Unterscheidung der beiden Schaltflächen.</param>
    ''' <param name="e"></param>
    ''' <remarks>Die Parameter werden in Abhängigkeit des Inhalts von 'sender' angepasst.</remarks>
    Private Sub btnPickProtocolPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickProtocolPath.Click
        Dim locFolderDialog As New FolderBrowserDialog
        With locFolderDialog
            'Sender ist die Auslassungsschaltfläche für die Quellordner-Auswahl:
            .Description = "Protokollordner wählen:"
            .ShowNewFolderButton = False
            .ShowNewFolderButton = True
            Dim locDr As DialogResult = .ShowDialog()
            If locDr = Windows.Forms.DialogResult.OK Then
                lblProtocolPath.Text = .SelectedPath
            End If
        End With
    End Sub
End Class