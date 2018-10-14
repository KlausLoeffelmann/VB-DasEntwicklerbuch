Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Sub btnDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectory.Click

        Dim locFolderBrowser As New FolderBrowserDialog

        With locFolderBrowser
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Wählen Sie das Dateienverzeichnis aus:"
            Dim locResult As DialogResult = .ShowDialog()

            If locResult = Windows.Forms.DialogResult.OK Then
                txtDirectory.Text = .SelectedPath
                Me.fneFiles.Directory = New DirectoryInfo(.SelectedPath)
            End If
        End With
    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub

    Private Sub btnCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckAll.Click
        fneFiles.CheckAll()
    End Sub

    Private Sub btnUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUncheckAll.Click
        fneFiles.UncheckAll()
    End Sub

    Private Sub btnDateinamenInDatei_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateinamenInDatei.Click

        Dim locSFD As New SaveFileDialog

        With locSFD
            .CheckPathExists = True
            .DefaultExt = "TXT"
            .Filter = "Text-Dateien (*.TXT)|.TXT|Alle Dateien (*.*)|*.*"
            .OverwritePrompt = True
            Dim locDiaRes As DialogResult = .ShowDialog()
            If locDiaRes = Windows.Forms.DialogResult.OK Then
                If Not (.FileName Is Nothing Or .FileName = String.Empty) Then

                    Dim locSW As StreamWriter = New StreamWriter(.FileName)
                    For Each locFEI As FilenameEnumeratorItem In fneFiles.Items
                        If locFEI.Checked Then
                            locSW.WriteLine(locFEI.Filename.FullName)
                        End If
                    Next
                    locSW.Flush()
                    locSW.Close()
                End If
            End If
        End With
    End Sub

    Private Sub btnTestFilesDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestFilesDirectory.Click
        Dim locFolderBrowser As New FolderBrowserDialog

        With locFolderBrowser
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowNewFolderButton = True
            .Description = "Wählen Sie das Testdateienverzeichnis aus:"
            Dim locResult As DialogResult = .ShowDialog()

            If locResult = Windows.Forms.DialogResult.OK Then
                txtPathForTestFiles.Text = .SelectedPath
            End If
        End With

    End Sub

    Private Sub btnGenerateTestFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateTestFiles.Click

        For Each locFEI As FilenameEnumeratorItem In fneFiles.Items
            If locFEI.Checked Then
                Dim locSW As StreamWriter = _
                   New StreamWriter(txtPathForTestFiles.Text + "\" + locFEI.Filename.Name)
                locSW.WriteLine("Dies ist nur eine Testdatei, und der ursprüngliche Dateipfad lautete:")
                locSW.WriteLine(locFEI.Filename.FullName)
                locSW.Flush()
                locSW.Close()
            End If
        Next

    End Sub

    Private Sub btnCheckFound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckFound.Click
        For Each locFEI As FilenameEnumeratorItem In fneFiles.Items
            Dim locFilename As String = locFEI.Filename.Name
            If locFilename.IndexOf(txtSearch.Text) > -1 Then
                locFEI.Checked = True
            Else
                locFEI.Checked = False
            End If
        Next
    End Sub

    Private Sub btnReplaceChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceChecked.Click
        For Each locFEI As FilenameEnumeratorItem In fneFiles.Items
            Dim locFilename As String = locFEI.SubItems(1).Text
            If locFEI.Checked Then
                If locFilename.IndexOf(txtSearch.Text) > -1 Then
                    locFilename = locFilename.Replace(txtSearch.Text, txtReplace.Text)
                    locFEI.SubItems(1).Text = locFilename
                End If
            End If
        Next
    End Sub

    Private Sub btnRenameFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenameFiles.Click
        For Each locFEI As FilenameEnumeratorItem In fneFiles.Items
            Dim locFileInfo As FileInfo = locFEI.Filename
            Dim locFilename As String = locFEI.SubItems(1).Text
            locFileInfo.MoveTo(locFileInfo.Directory.FullName + "\" + locFilename)
        Next
    End Sub

    Private Sub chkEpisodeNameFilter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEpisodeNameFilter.CheckedChanged
        fneFiles.EpisodeNameFilter = chkEpisodeNameFilter.Checked
    End Sub
End Class

