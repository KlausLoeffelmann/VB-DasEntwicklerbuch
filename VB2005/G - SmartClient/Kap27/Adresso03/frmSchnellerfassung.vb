'HINWEIS: Die vorliegende Version des Programms zeigt in Ergänzung zum
'Buchtext, wie Sie durch Vererbung eines DataGridViewTextBoxCell-Steuerelements
'(siehe Ende dieses Codes sowie Konstruktor des Formulars) einen Eingabebereich für eine Zelle
'schaffen, der über ihre eigentlichen Ausmaße hinausgeht.
Public Class frmSchnellerfassung

    Private myAdressen As Adressen
    Private myGebDatColumnIndex As Integer

    Private myLetzteAusnahme As Exception
    Private myZelleLetzteAusnahme As DataGridViewCell

    Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

        'Mehr Eingabebereich für die Namensspalte schaffen.
        dgvAdressen.Columns("NameDataGridViewTextBoxColumn").CellTemplate = New EditableMergedCell()
    End Sub

    Public Sub Schnellerfassung(ByVal adrListe As Adressen)
        'So werden die Adressen mit der BindungSource verknüpft.
        'WICHTIG: Binden Sie die Adressen nicht versehentlich an
        'die DataGridView-DataSource selbst!
        AdressenBindingSource.DataSource = adrListe
        Me.ShowDialog()
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Den Geburtsdatums-Index der Tabelle ermitteln, weil CellFormating
        'zeitkritisch ist, und so der Index nicht ständig aus dem Spaltennamen
        'ermittelt werden muss.
        myGebDatColumnIndex = dgvAdressen.Columns("GeburtsdatumDataGridViewTextBoxColumn").Index

        'Spaltenbreiten an Spaltenköpfe anpassen
        For Each locColumns As DataGridViewColumn In dgvAdressen.Columns
            locColumns.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        Next

        'Editiermodus festlegen - entweder bei der direkten Eingabe oder bei F2
        dgvAdressen.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
    End Sub

    'Wird aufgerufen, wenn der Anwender die OK-Schaltfläche betätigt.
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Zuweisen im modalen Dialog, schließt diesen.
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    'Wird aufgerufen, wenn eine neue Zelle zur aktuellen Zelle wird.
    Private Sub dgvAdressen_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAdressen.CurrentCellChanged
        With dgvAdressen
            tslZeile.Text = "Zeile: " & .CurrentCell.RowIndex.ToString
            tslSpalte.Text = "Spalte: " & .Columns(.CurrentCell.ColumnIndex).HeaderText
        End With
    End Sub

    'Wird aufgerufen, bevor das Bearbeiten einer Zelle startet.
    Private Sub dgvAdressen_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAdressen.CellBeginEdit

        'Verhindern, dass der Matchcode bearbeitet werden kann.
        If e.ColumnIndex = dgvAdressen.Columns("MatchcodeDataGridViewTextBoxColumn").Index Then

            'Neue Matchcodes können zwar bearbeitet werden, aber keine vorhandenen.
            'IsNewRow zeigt ein, ob es sich um die "Neue-DataGridView-Zeile" handelt.
            If Not dgvAdressen.CurrentRow.IsNewRow Then
                'Wie gesagt: NICHT neue Zeile, dann Bearbeitung nicht zulassen.
                e.Cancel = True
            End If
        End If
    End Sub

    'Wird für jede Zelle aufgerufen, wenn der Inhalt dieser formatiert wird.
    Private Sub dgvAdressen_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvAdressen.CellFormatting

        'Nur die Geburtsdatums-Spalte wird besonders formatiert.
        If e.ColumnIndex = myGebDatColumnIndex Then
            'Die Zelle ermitteln. Aus Geschwindigkeitsgründen sollte das in einem
            'Rutsch erfolgen; hier getrennt, damit es deutlicher wird.
            Dim locCurrentRow As DataGridViewRow = dgvAdressen.Rows(e.RowIndex)
            Dim locCurrentCell As DataGridViewCell = locCurrentRow.Cells(e.ColumnIndex)

            'Wenn ein Geburtsdatum zum Bearbeiten formatiert wird, 
            'dann ein "parse"-bares Format darstellen.
            If locCurrentCell.IsInEditMode Then
                e.CellStyle.Format = "dd.MM.yyyy"
            Else
                'Nur für die Anzeige ein "mehr informatives Format" darstellen.
                e.CellStyle.Format = "dd.MM.yyyy (dddd)"
            End If
        End If
    End Sub

    'Wird aufgerufen, wenn der Inhalt einer Zelle überprüft werden soll.
    Private Sub dgvAdressen_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvAdressen.CellValidating

        'Aktuell zu validierende Zeile und Zelle ermitteln
        Dim locCurrentRow As DataGridViewRow = dgvAdressen.Rows(e.RowIndex)
        Dim locCurrentCell As DataGridViewCell = locCurrentRow.Cells(e.ColumnIndex)

        'Zellen werden nur validiert, wenn sie bearbeitet wurden.
        '(Und beim Validieren *werden* sie noch bearbeitet)
        If locCurrentCell.IsInEditMode Then

            'Postleitzahleninhalt überprüfen
            If e.ColumnIndex = dgvAdressen.Columns("PLZDataGridViewTextBoxColumn").Index Then

                'Postleitzahlen dürfen nicht mehr als 5stellig sein,
                'und nur aus Ziffern bestehen.
                If (e.FormattedValue.ToString.Length < 6 And _
                    e.FormattedValue.ToString.Length > 4 And _
                    IsNumeric(e.FormattedValue.ToString)) Then
                    locCurrentCell.ErrorText = Nothing
                Else
                    locCurrentCell.ErrorText = "Die Postleitzahl hat das falsche Format!"
                End If

            ElseIf e.ColumnIndex = dgvAdressen.Columns("GeburtsdatumDataGridViewTextBoxColumn").Index Then

                'Geburtsdatumsformat überprüfen
                Dim locDate As Date
                If Not Date.TryParse(e.FormattedValue.ToString, locDate) Then
                    locCurrentCell.ErrorText = "Das eingegebene Datum hat das falsche Format!"
                Else
                    'Zurücksetzen
                    locCurrentCell.ErrorText = Nothing
                End If
            Else
                'Alle anderen Felder nur auf nicht vorhandene Eingabe überprüfen
                If String.IsNullOrEmpty(e.FormattedValue.ToString) Then
                    locCurrentCell.ErrorText = "Fehlende Eingabe!"
                Else
                    locCurrentCell.ErrorText = Nothing
                End If
            End If
        End If
    End Sub

    'Wird aufgerufen, wenn beim Wechseln der Zeile 
    'die Richtigkeit der Inhalte *aller* Zellen überprüft werden sollen.
    Private Sub dgvAdressen_RowValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAdressen.RowValidating

        'Alle Zellen der betroffenen Zeile durchlaufen
        For Each locCell As DataGridViewCell In dgvAdressen.Rows(e.RowIndex).Cells

            'Schauen, ob noch irgendwo ein Fehlertext vermerkt ist
            If Not String.IsNullOrEmpty(locCell.ErrorText) Then
                'Falls ja, dann auch einen Fehler auf Zeilenbasis eintragen
                dgvAdressen.Rows(e.RowIndex).ErrorText = "Diese Zeile hat noch nicht korrigierte Fehler!"
                e.Cancel = True
                Return
            End If
        Next

        'Keine der Zellen wies einen Fehler auf --> Zeilenfehler zurücksetzen.
        dgvAdressen.Rows(e.RowIndex).ErrorText = Nothing
    End Sub

    'Wird aufgerufen, wenn der Anwender auf das Kontrollkästchen klickt.
    Private Sub chkSpaltenbreitenAnpassen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpaltenbreitenAnpassen.CheckedChanged

        'Alle Spalten der Tabelle durchlaufen
        For Each locColumns As DataGridViewColumn In dgvAdressen.Columns
            If chkSpaltenbreitenAnpassen.Checked Then
                '... und die Spaltenbreiten entweder auf Basis der Inhalte der Zellen 
                '*und* der Kopfzeilentext ...
                locColumns.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            Else
                '... oder nur durch die Breite der Kopfzeilentexte bestimmen lassen.
                locColumns.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            End If
        Next
    End Sub

    'Wird bei Problemen mit der Datenbindung aufgerufen.
    Private Sub dgvAdressen_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAdressen.DataError

        'Ausnahme, die ausgelöst wurde, merken.
        myLetzteAusnahme = e.Exception

        'Den Ausnahmetext in der Statuszeile setzen
        tslAusnahmetext.Text = e.Exception.Message

        'Und merken, bei welcher Zelle die Ausnahme auftrat.
        myZelleLetzteAusnahme = dgvAdressen.CurrentCell
    End Sub

    'Wird aufgerufen, wenn der Anwender auf die Auslassungsschaltfläche (...) in der Statuszeile klickt.
    Private Sub tsbAusnahmeAnzeigen_ButtonClick(ByVal sender As System.Object, _
                    ByVal e As System.EventArgs) Handles tsbAusnahmeAnzeigen.Click

        'Rausfinden, ob es eine "letzte Ausnahme" überhaupt gab.
        If myLetzteAusnahme IsNot Nothing Then
            'Wenn ja, ein Nachrichtenfeld mit den Ausnahmedetails anzeigen.
            'Die Ausnahmedetails wurden in dgvAdressen_DataError festgehalten (siehe dort).
            MessageBox.Show("Letzte Ausnahme trat auf in Zeile: " & _
                            myZelleLetzteAusnahme.RowIndex & _
                            " Spalte: " & _
                            dgvAdressen.Columns(myZelleLetzteAusnahme.ColumnIndex).HeaderText & _
                            vbNewLine & vbNewLine & _
                            myLetzteAusnahme.Message & vbNewLine & vbNewLine & _
                            "Details:" & vbNewLine & vbNewLine & _
                            myLetzteAusnahme.StackTrace, "Letzte Datenausnahme:", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'Es gab keine "letzte Ausnahme":
            MessageBox.Show("Es sind bislang keine Datenausnahmen aufgetreten", _
                            "Letzte Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class

Public Class EditableMergedCell
    Inherits DataGridViewTextBoxCell


    Public Overrides Sub PositionEditingControl(ByVal setLocation As Boolean, ByVal setSize As Boolean, ByVal cellBounds As System.Drawing.Rectangle, ByVal cellClip As System.Drawing.Rectangle, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal singleVerticalBorderAdded As Boolean, ByVal singleHorizontalBorderAdded As Boolean, ByVal isFirstDisplayedColumn As Boolean, ByVal isFirstDisplayedRow As Boolean)
        ' the cell rectangle is the bounds of the merged cell
        Dim mergedRectangle As Rectangle = New Rectangle(cellBounds.Location, New Size(cellBounds.Width * 2, cellBounds.Height * 2))

        ' the cell clip tells the grid how much of the merged cell is visible. 
        Dim mergedCellClip As Rectangle = New Rectangle(cellClip.Location, New Size(cellClip.Width * 2, cellClip.Height * 2))

        MyBase.PositionEditingControl(setLocation, setSize, mergedRectangle, mergedCellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow)
    End Sub
    Public Overrides Function PositionEditingPanel(ByVal cellBounds As System.Drawing.Rectangle, ByVal cellClip As System.Drawing.Rectangle, ByVal cellStyle As System.Windows.Forms.DataGridViewCellStyle, ByVal singleVerticalBorderAdded As Boolean, ByVal singleHorizontalBorderAdded As Boolean, ByVal isFirstDisplayedColumn As Boolean, ByVal isFirstDisplayedRow As Boolean) As System.Drawing.Rectangle

        ' the cell rectangle is the bounds of the merged cell
        Dim mergedRectangle As Rectangle = New Rectangle(cellBounds.Location, New Size(cellBounds.Width * 2, cellBounds.Height * 2))

        ' the cell clip tells the grid how much of the merged cell is visible. 
        Dim mergedCellClip As Rectangle = New Rectangle(cellClip.Location, New Size(cellClip.Width * 2, cellClip.Height * 2))

        Return MyBase.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow)
    End Function
End Class

