Public Class frmPatternLibrary

    Private myPatterns As Patterns

    Sub New(ByVal Patterns As Patterns)
        MyBase.New()
        InitializeComponent()
        myPatterns = Patterns
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        With lvwPatterns

            With .Columns
                .Clear()
                .Add("Suchmuster", -2, HorizontalAlignment.Left)
                .Add("Ersetzungsmuster", -2, HorizontalAlignment.Left)
                .Add("Kommentar", -2, HorizontalAlignment.Left)
            End With

            If myPatterns Is Nothing Then Return

            With .Items
                For Each locPI As Pattern In myPatterns
                    If Not (locPI Is Nothing) Then
                        Dim locItem As New ListViewItem
                        locItem.Tag = locPI
                        locItem.Text = locPI.SearchPattern
                        locItem.SubItems.Add(locPI.ReplacePattern)
                        locItem.SubItems.Add(locPI.Comment)
                        .Add(locItem)
                    End If
                Next
            End With

            'Die Spalten so breit machen, dass alle Inhalte/Überschriften 
            'gut sichtbar sind.
            For Each locColumn As ColumnHeader In .Columns
                locColumn.Width = -2
            Next
        End With
    End Sub

    Function Pattern() As Pattern

        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Return Nothing
        Else
            Return DirectCast(lvwPatterns.SelectedItems(0).Tag, Pattern)
        End If

    End Function

    Public Shared Function GetPattern(ByVal Patterns As Patterns) As Pattern

        Dim locForm As New frmPatternLibrary(Patterns)
        Return locForm.Pattern

    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If lvwPatterns.SelectedItems.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie einen Eintrag aus", _
                            "Fehlende Auswahl")
            Return
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If lvwPatterns.SelectedItems.Count > 0 Then
            Dim locDR As DialogResult = MessageBox.Show( _
                "Sind Sie sicher, dass Sie den Eintrag löschen wollen?", _
                "Eintrag löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If locDR = Windows.Forms.DialogResult.Yes Then

                'Erst aus der Pattern-Liste entfernen,
                myPatterns.Remove(DirectCast(lvwPatterns.SelectedItems(0).Tag, Pattern))

                'dann aus der ListView-Liste entfernen.
                lvwPatterns.SelectedItems(0).Remove()

                'Liste abspeichern.
                myPatterns.SerializeToXML(My.Application.Info.DirectoryPath & _
                          "\" & My.Settings.PatternLibraryFilename)

            End If
        End If
    End Sub
End Class