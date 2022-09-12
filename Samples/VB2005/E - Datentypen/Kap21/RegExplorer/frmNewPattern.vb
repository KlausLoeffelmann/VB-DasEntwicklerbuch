Public Class frmNewPattern

    Sub New(ByVal Pattern As Pattern)
        MyBase.New()

        'Wichtig bei ‹berladenen Formular-Konstruktoren:
        'Rufen Sie InitializeComponent auf!
        InitializeComponent()

        'Felder vorbelegen.
        txtComment.Text = Pattern.Comment
        txtSearchPattern.Text = Pattern.SearchPattern
        txtReplacePattern.Text = Pattern.ReplacePattern
    End Sub

    Function Pattern() As Pattern
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Return Nothing
        Else
            Return New Pattern(txtSearchPattern.Text, txtReplacePattern.Text, txtComment.Text)
        End If
    End Function

    Public Shared Function GetPattern(ByVal Pattern As Pattern) As Pattern

        Dim locForm As New frmNewPattern(Pattern)
        Return locForm.Pattern

    End Function

    'Wenn das Formular geschlossen wird...
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)

        '...und wenn das durch OK veranlasst wurde...
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            '...dann das Schlieﬂen nur zulassen, wenn mit den eingegebenen
            'Daten alles in Ordnung war.
            '(e.Cancel=true br‰che das Schlieﬂen ab).
            e.Cancel = ValidateDialogData()
        End If
    End Sub

    '‹berpr¸fen der Eingabedaten und anzeigen von Fehlern mit
    'dem Error-Provider:
    Function ValidateDialogData() As Boolean
        Dim locError As Boolean

        If txtSearchPattern.Text = "" Then
            ErrProvider.SetError(txtSearchPattern, "Bitte geben Sie das Suchmuster ein!")
            locError = locError Or True
        Else
            ErrProvider.SetError(txtSearchPattern, "")
        End If
        If txtComment.Text = "" Then
            ErrProvider.SetError(txtComment, "Bitte geben Sie einen Kommentar ein!")
            locError = locError Or True
        Else
            ErrProvider.SetError(txtSearchPattern, "")
        End If
        Return locError
    End Function

    'OK wurde angeklickt...
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Schlieﬂversuch des Formulars durch Setzen von DialogResult
        '(kann durch FormClosing verhindert werden!)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'Abbrechen wurde angeklickt.
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'Dann mischt sich FormClosing (siehe dort) nicht ein,
        'das Formular wird auf jeden Fall geschlossen.
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class