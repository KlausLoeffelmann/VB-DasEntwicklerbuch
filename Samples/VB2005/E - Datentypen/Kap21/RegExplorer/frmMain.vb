Imports System.IO
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions

Public Class frmMain
    Private myFilename As String
    Private myPatterns As Patterns
    Private myResultTextChanged As Boolean
    Private myGroupCaptures As Boolean

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Basisfunktion aufrufen
        MyBase.OnLoad(e)

        'Dateinamen für die Musterbibliothek zusammenbasteln
        Dim locFilename As String = My.Application.Info.DirectoryPath & _
                                      "\" & My.Settings.PatternLibraryFilename

        'Existiert die Datei schon?
        Dim locFI As New FileInfo(locFilename)
        If Not locFI.Exists Then
            'Nein - einen Standardeintrag erstellen.
            myPatterns = New Patterns
            myPatterns.Add(New Pattern("\w+", "", "Einzelne Wörter aus Text"))
            'Abspeichern.
            myPatterns.SerializeToXML(locFilename)
            Return
        End If

        'Die Datei existiert, sie kann geladen werden.
        myPatterns = Patterns.DeserializeFromFile(locFilename)
    End Sub

    'Verlassen der Anwendung.
    Private Sub tsmQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmQuitProgram.Click
        'Hauptformular schließen, das schließt die Anwendung.
        Me.Close()
    End Sub

    'Öffnen der Quelldatei.
    Private Sub tsmLoadSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmLoadSourceFile.Click

        Dim locOpenFile As New OpenFileDialog

        With locOpenFile
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.txt"
            .Filter = "Textdateien (*.txt)|*.txt|VB-Quelldateien (*.vb)|*.vb|Alle Dateien (*.*)|*.*"
            .Title = "Quelldatei öffnen"
            Dim locDiRes As DialogResult = .ShowDialog
            If locDiRes = Windows.Forms.DialogResult.OK Then
                'Mit My.Computer.FileSystem.ReadAllText ginge es auch!

                'Aber das hier ist die .NET-Framework-hochoffizielle-auch-in-
                'anderen-Sprachen-funktionierende Methode! ;-)
                Dim locTR As New StreamReader(.FileName)
                txtSourceText.Text = locTR.ReadToEnd
                locTR.Close()
                myFilename = .FileName
            End If
        End With
    End Sub

    'Speichern der Quelldatei:
    Private Sub tsmSaveSourceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSaveSourceFile.Click

        Dim locSaveFile As New SaveFileDialog

        With locSaveFile
            .OverwritePrompt = True
            .DefaultExt = "*.txt"
            .Filter = "Textdateien (*.txt)|*.txt|VB-Quelldateien (*.vb)|*.vb|Alle Dateien (*.*)|*.*"
            .Title = "Quelldatei speichern"
            Dim locDiRes As DialogResult = .ShowDialog
            If locDiRes = Windows.Forms.DialogResult.OK Then
                'Same here!
                Dim locTS As New StreamWriter(.FileName)
                locTS.Write(txtSourceText.Text)
                'Immer wichtig: Abziehen nicht vergessen.
                locTS.Flush()
                locTS.Close()
            End If
        End With
    End Sub

    'Das aktuelle Suchmuster im Hauptdialog der Bibliothek hinzufügen.
    Private Sub tsmSaveSearchPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSaveSearchPattern.Click, btnNewSearchPattern.Click

        'Die statische Funktion GetPattern instanziert auch gleich ein Formular,
        'was dann den Anwender das Muster aus der Liste auswählen lässt.
        Dim locPattern As Pattern = frmNewPattern.GetPattern( _
                New Pattern(txtSearchPattern.Text, txtReplacePattern.Text, ""))

        'locPattern ist Nothing, wenn Abbrechen geklickt wurde.
        If locPattern IsNot Nothing Then

            'Neues Suchmuster der Liste hinzufügen,
            myPatterns.Add(locPattern)

            'und die neue Liste abspeichern.
            myPatterns.SerializeToXML(My.Application.Info.DirectoryPath & _
                                      "\" & My.Settings.PatternLibraryFilename)
        End If
    End Sub

    'Die Suchfunktion soll ausgeührt werden:
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim locRegEx As Regex

        Try
            locRegEx = New Regex(txtSearchPattern.Text)
        Catch ex As Exception
            MessageBox.Show("Fehler beim Anlegen des RegEx-Objektes!" + ex.Message, _
                         "Fehler in Ausdruck:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

        Dim locRootNode As TreeNode

        'Die Ergebnisstruktur in der TreeView anzeigen.
        tvwResults.Nodes.Clear()
        With tvwResults.Nodes

            'Dateiname ist Wurzelknoten der TreeView.
            locRootNode = .Add(myFilename)

            'Alle Match-Objekte (Treffer) durchlaufen...
            For Each locMatch As Match In locRegEx.Matches(txtSourceText.Text)

                'und in der TreeView darstellen.
                Dim locMainNode As New TreeNode("'" + locMatch.Value + "'")
                locMainNode.Tag = locMatch
                locRootNode.Nodes.Add(locMainNode)

                'Falls es zu einem Match Captures gab...
                If locMatch.Captures.Count > 0 Then
                    Dim locCaptureNode As TreeNode = locMainNode.Nodes.Add("CAPTURES:")
                    For Each locCC As Capture In locMatch.Captures
                        '...auch diese unter jedem Match darstellen.
                        Dim locNode As TreeNode = locCaptureNode.Nodes.Add(locCC.Value)
                        locNode.Tag = locCC
                    Next
                End If

                'Das Gleiche gilt für Groups.
                If locMatch.Groups.Count > 0 Then
                    Dim locGroupNode As TreeNode = locMainNode.Nodes.Add("GROUPS:")
                    For Each locGroup As Group In locMatch.Groups
                        Dim locNode As TreeNode = locGroupNode.Nodes.Add(locGroup.Value)
                        locNode.Tag = locGroup

                        'Captures der einzelnen Gruppen nur im Bedarfsfall zeigen
                        If myGroupCaptures Then
                            If locGroup.Captures.Count > 0 Then
                                Dim locCaptureNode As TreeNode = locNode.Nodes.Add("CAPTURES:")
                                For Each locCC As Capture In locGroup.Captures
                                    Dim locGCNode As TreeNode = locCaptureNode.Nodes.Add(locCC.Value)
                                    locGCNode.Tag = locCC
                                Next
                            End If
                        End If
                    Next
                End If
            Next
        End With

    End Sub

    'Auswahl eines Suchmusters:
    Private Sub tsmChooseSearchPattern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmChooseSearchPattern.Click, btnPatternLibrary.Click
        Dim locPattern As Pattern = frmPatternLibrary.GetPattern(myPatterns)
        If Not (locPattern Is Nothing) Then
            Me.PatternEntry = locPattern
        End If

        'Liste neu laden; durch die Bibliotheksfunktion könnte ein Eintrag gelöscht worden
        'sein; die Übergabe erfolgt, die Einfachheit halber, über die Datei
        myPatterns = Patterns.DeserializeFromFile(My.Application.Info.DirectoryPath & _
                                      "\" & My.Settings.PatternLibraryFilename)

    End Sub

    'Liefert ein Muster aus den TextBox-Steuerelementen zurück 
    'oder setzt es dort hinein.
    Public Property PatternEntry() As Pattern
        Get
            Return New Pattern(txtSearchPattern.Text, txtReplacePattern.Text, "")
        End Get
        Set(ByVal Value As Pattern)
            txtSearchPattern.Text = Value.SearchPattern
            txtReplacePattern.Text = Value.ReplacePattern
        End Set
    End Property

    'Wird beim Auswählen eines Elements der Ergebnis-TreeView aufgerufen.
    Private Sub tvwResults_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwResults.AfterSelect

        Dim locNode As TreeNode = e.Node
        Dim locObject As Object = locNode.Tag
        Dim locString As String

        'Fall Wurzel ausgewählt wurde, gesamten Text darstellen
        If locNode.Parent Is Nothing Then
            txtResults.Text = txtSourceText.Text
            Return
        End If

        locObject = locNode.Tag

        'Kein gescheites Ergebnis -> und tschö!
        If (locObject Is Nothing) Then
            Return
        End If

        'Erster Eintrag, dann Status ausgeben Text im Source markieren
        If locObject.GetType().FullName = "System.Text.RegularExpressions.Match" Then
            Dim locMatch As Match = DirectCast(locObject, Match)
            locString = "Ergebnistext: " + "'" + locMatch.Value + "'" + vbNewLine
            locString += "An Position: " + locMatch.Index.ToString + vbNewLine
            locString += "Länge: " + locMatch.Length.ToString + vbNewLine + vbNewLine

            locString += "Groups:" + vbNewLine
            locString += "=======" + vbNewLine
            For Each locGroup As Group In locMatch.Groups
                locString += "'" + locGroup.Value + "'" + vbNewLine
            Next
            locString += vbNewLine
            locString += "Captures:" + vbNewLine
            locString += "=======" + vbNewLine
            For Each locCapture As Capture In locMatch.Captures
                locString += "'" + locCapture.Value + "'" + vbNewLine
            Next
            txtResults.Text = locString
            txtSourceText.SelectionStart = locMatch.Index
            txtSourceText.SelectionLength = locMatch.Length
            txtSourceText.ScrollToCaret()
            Return
        End If
    End Sub

    'Die Ersetzen-Funktion soll ausgeführt werden:
    Private Sub btnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplace.Click
        txtResults.Text = Regex.Replace(txtSourceText.Text, txtSearchPattern.Text, txtReplacePattern.Text)
    End Sub

    'Ergebnis in Quelltext kopieren:
    Private Sub tsmCopyResultToSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmCopyResultToSource.Click
        txtSourceText.Text = txtResults.Text
    End Sub

    'Quelltext löschen:
    Private Sub tsmClearSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmClearSource.Click

        'Sicherheitsabfrage:
        Dim locDR As DialogResult = MessageBox.Show("Sind Sie sicher?", "Quelltext löschen:", _
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locDR = Windows.Forms.DialogResult.Yes Then
            'Quelltext löschen.
            txtSourceText.Text = ""
        End If
    End Sub

    'Ergebnistext löschen:
    Private Sub tsmClearResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmClearResult.Click

        Dim locDR As DialogResult = MessageBox.Show("Sind Sie sicher?", "Ergebnixtext löschen:", _
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If locDR = Windows.Forms.DialogResult.Yes Then
            txtResults.Text = ""
        End If

    End Sub

    'Quelltext - alles markieren:
    Private Sub tsmSourceSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSourceSelectAll.Click
        txtSourceText.Focus()
        txtSourceText.SelectionStart = 0
        txtSourceText.SelectionLength = txtSourceText.Text.Length
    End Sub

    'Ergebnistext - alles markieren:
    Private Sub tsmResultSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmResultSelectAll.Click
        txtResults.Focus()
        txtResults.SelectionStart = 0
        txtResults.SelectionLength = txtSourceText.Text.Length
    End Sub

    'An- und abschalten der Anzeige der Group Captures:
    Private Sub tsmShowGroupCaptures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmShowGroupCaptures.Click
        'XOR vertauscht Bits.
        myGroupCaptures = myGroupCaptures Xor True
        'Durch ein Häkchen widerspiegeln lassen:
        tsmShowGroupCaptures.Checked = myGroupCaptures
    End Sub
End Class
