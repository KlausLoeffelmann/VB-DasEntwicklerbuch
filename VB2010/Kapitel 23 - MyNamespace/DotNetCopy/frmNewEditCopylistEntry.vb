Imports System.IO

Public Class frmNewEditCopylistEntry

    Dim myCopyListEntry As CopyListEntry

    Public Function EditCopyListEntry(ByVal CopyListEntry As CopyListEntry) As CopyListEntry
        lblDestinationFolder.Text = CopyListEntry.DestFolder.ToString
        lblSourceFolder.Text = CopyListEntry.SourceFolder.ToString
        mtbSearchMask.Text = CopyListEntry.SearchMask

        'Dialog modal darstellen
        Me.ShowDialog()

        'Rückgabewert abhängig von Benutzeraktion (OK oder Abbrechen)
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myCopyListEntry
        Else
            Return Nothing
        End If
    End Function

    Public Function NewCopyListEntry() As CopyListEntry
        'Dialog modal darstellen
        Me.ShowDialog()

        'Rückgabewert abhängig von Benutzeraktion (OK oder Abbrechen)
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myCopyListEntry
        Else
            Return Nothing
        End If
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If String.IsNullOrEmpty(lblDestinationFolder.Text) Then
            MessageBox.Show("Bitte bestimmen Sie den Zielordner", "Fehlender Parameter", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If String.IsNullOrEmpty(lblSourceFolder.Text) Then
            MessageBox.Show("Bitte bestimmen Sie den Quellordner", "Fehlender Parameter", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        myCopyListEntry = New CopyListEntry
        myCopyListEntry.DestFolder = New DirectoryInfo(lblDestinationFolder.Text)
        myCopyListEntry.SourceFolder = New DirectoryInfo(lblSourceFolder.Text)
        myCopyListEntry.SearchMask = mtbSearchMask.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    ''' <summary>
    ''' Behandelt das Click-Ereignis beider Auslassungsschaltflächen zur Ordnerwahl.
    ''' </summary>
    ''' <param name="sender">Dient zur Unterscheidung der beiden Schaltflächen.</param>
    ''' <param name="e"></param>
    ''' <remarks>Die Parameter werden in Abhängigkeit des Inhalts von 'sender' angepasst.</remarks>
    Private Sub btnPickFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickSourceFolder.Click, btnPickDestinationFolder.Click
        Dim locFolderDialog As New FolderBrowserDialog
        With locFolderDialog
            'Sender ist die Auslassungsschaltfläche für die Quellordner-Auswahl:
            If sender Is btnPickSourceFolder Then
                .Description = "Quellordner wählen:"
                .ShowNewFolderButton = False
            Else
                'Sender ist die Auslassungsschaltfläche für die Zielordner-Auswahl:
                .Description = "Zielordner wählen:"
                'Bei der Auswahl des Zielordners das 
                'Anlegen eines neuen Ordners erlauben:
                .ShowNewFolderButton = True
            End If
            Dim locDr As DialogResult = .ShowDialog()
            If locDr = Windows.Forms.DialogResult.OK Then
                If sender Is btnPickSourceFolder Then
                    lblSourceFolder.Text = .SelectedPath
                Else
                    lblDestinationFolder.Text = .SelectedPath
                End If
            End If
        End With
    End Sub
End Class