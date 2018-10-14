'Typische Vorgehensweise bei der Prozeduralen Programmierung
'� la Visual Basic 6.0. Bis auf den Unterschied "Class" und "Form"
'(und einige ganz unwenseltiche Kleinigkeiten) w�re dieses Programm
'auch unter Visual Basic 6.0 lauff�hig und daf�r typisch.
Public Class frmRomanNumerals

    'Diese Flags dienen dazu, zu verhindern, dass eine �nderung
    'einer TextBox die �nderung der anderen nach sich zieht,
    'die wiederum die �nderung der ersten verursacht.
    'Durch vorheriges Setzen der entsprechenden Flags wird diese
    'Ereigniskette verhindert.
    Dim myDontPerformRoman As Boolean = False
    Dim myDontPerformArabic As Boolean = False

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Hide()
    End Sub

    Private Sub txtRomanYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRomanYear.TextChanged

        'Umwandeln, wenn sich der Text �ndern
        If Not myDontPerformRoman Then
            myDontPerformArabic = True
            txtArabicYear.Text = CStr(ValueFromRomanNumeral(txtRomanYear.Text))
            txtArabicYear.SelectAll()
            myDontPerformArabic = False
        End If

    End Sub

    Private Sub txtArabicYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtArabicYear.TextChanged

        'Umwandeln, wenn sich der Text �ndert
        If Not myDontPerformArabic Then
            myDontPerformRoman = True
            If txtArabicYear.Text <> "" Then
                txtRomanYear.Text = CStr(RomanNumeral(CInt(txtArabicYear.Text)))
                txtRomanYear.SelectAll()
            Else
                txtRomanYear.Text = ""
            End If
            myDontPerformRoman = False
        End If

    End Sub

    'Wichtig: Variablen sind als ByRef deklariert, damit sie Ergegbnisse zur�ckliefern k�nnen.
    Public Function EditOrNewBookData(ByRef Titel As String, ByRef Author As String, ByRef Editor As String, ByRef YearPublished As String, ByRef Notes As String) As DialogResult

        'Formular darstellen
        'bleibt bis zum n�chsten Hide stehen,
        'da modaler Dialog
        txtEditor.Text = Editor
        txtAuthor.Text = Author
        txtBookTitel.Text = Titel
        txtArabicYear.Text = YearPublished
        txtNotes.Text = Notes
        Me.ShowDialog()

        '�berpr�fen ob Abbrechen gedr�ckt wurde,
        If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then
            'Variablen zur�ckliefern
            Editor = ""
            Titel = ""
            YearPublished = ""
        Else
            'sonst die Inhalte des Dialoges zur�ckliefern
            Editor = txtEditor.Text
            Author = txtAuthor.Text
            Titel = txtBookTitel.Text
            YearPublished = txtArabicYear.Text
            Notes = txtNotes.Text
        End If

        'Anzeigen, dass Dialog Daten "hatte"
        EditOrNewBookData = Me.DialogResult

    End Function

End Class

