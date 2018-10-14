Public Class frmMain

    'Wird ausgelöst, wenn der Anwender auf die Schaltfläche 
    '[Titel hinzufügen] klickt.
    Private Sub btnAddTitel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                  Handles btnAddTitle.Click

        Dim locTitel As String
        Dim locAuthor As String
        Dim locEditor As String
        Dim locYearPublished As String
        Dim locNotes As String

        locTitel = ""
        locAuthor = ""
        locEditor = ""
        locYearPublished = ""
        locNotes = ""

        If frmRomanNumerals.EditOrNewBookData(locTitel, locAuthor, locEditor, locYearPublished, locNotes) _
                        = Windows.Forms.DialogResult.OK Then
            With lvwBookItems
                Dim locListViewItem As ListViewItem
                locListViewItem = .Items.Add(locTitel)
                locListViewItem.SubItems.Add(locAuthor)
                locListViewItem.SubItems.Add(locEditor)
                locListViewItem.SubItems.Add(locYearPublished)
                locListViewItem.SubItems.Add(RomanNumeral(CInt(locYearPublished)))
                'Die Anmerkungen werden nicht in der Liste dargestellt, müssen aber
                'irgendwo gespeichert werden. Deswegen wandern sie in die Tag-Eigenschaft
                'eines Eintrags der ListView, die jedes beliebige Objekt speichern kann.
                locListViewItem.Tag = locNotes
            End With
        End If

    End Sub

    Private Sub btnEditTitel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditTitle.Click

        Dim locTitel As String
        Dim locAuthor As String
        Dim locEditor As String
        Dim locYearPublished As String
        Dim locNotes As String

        If lvwBookItems.SelectedItems.Count > 0 Then
            With lvwBookItems.SelectedItems(0)
                'WICHTIG: SubItems(0) entspricht dem Item-Text, 
                'also dem Haupttext des Eintrags in einer ListView
                locTitel = .SubItems(0).Text
                locAuthor = .SubItems(1).Text
                locEditor = .SubItems(2).Text
                locYearPublished = .SubItems(3).Text
                locNotes = CStr(.Tag)
            End With

            If frmRomanNumerals.EditOrNewBookData(locTitel, locAuthor, locEditor, locYearPublished, locNotes) _
                            = Windows.Forms.DialogResult.OK Then
                Dim locListViewItem As ListViewItem = lvwBookItems.SelectedItems(0)
                locListViewItem.Text = locTitel
                locListViewItem.SubItems(1).Text = locEditor
                locListViewItem.SubItems(2).Text = locAuthor
                locListViewItem.SubItems(3).Text = locYearPublished
                locListViewItem.SubItems(4).Text = RomanNumeral(CInt(locYearPublished))
            End If
        End If
    End Sub

    Private Sub btnSaveTitels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveTitles.Click

        Dim locSFD As New SaveFileDialog()
        Dim locDR As DialogResult

        ' Gibt's was zu speichern?
        If lvwBookItems.Items.Count = 0 Then
            Exit Sub
        End If

        With locSFD
            .Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
            .OverwritePrompt = True
            .DefaultExt = "*.txt"
            locDR = .ShowDialog()
            If locDR = Windows.Forms.DialogResult.OK Then
                Dim locFF As Integer = FreeFile()
                FileOpen(locFF, .FileName, OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)

                'Anzahl der Elemente abspeichern
                PrintLine(locFF, lvwBookItems.Items.Count)

                Dim locItemCount As Integer
                Dim locSubItemCount As Integer
                Dim locLVW As ListViewItem
                For locItemCount = 1 To lvwBookItems.Items.Count
                    locLVW = lvwBookItems.Items(locItemCount - 1)
                    For locSubItemCount = 0 To 3
                        PrintLine(locFF, locLVW.SubItems(locSubItemCount).Text)
                    Next
                    PrintLine(locFF, locLVW.Tag)
                Next
                FileClose(locFF)
            End If
        End With
    End Sub

    Private Sub btnLoadTitels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadTitles.Click

        Dim locOFD As New OpenFileDialog()
        Dim locDR As DialogResult

        With locOFD
            .Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
            .CheckFileExists = True
            .DefaultExt = "*.txt"
            locDR = .ShowDialog()
            If locDR = Windows.Forms.DialogResult.OK Then
                Dim locFF As Integer = FreeFile()
                Dim locItems As Integer

                lvwBookItems.Items.Clear()
                FileOpen(locFF, .FileName, OpenMode.Input, OpenAccess.Read, OpenShare.Shared)

                'Anzahl der Elemente abspeichern
                Input(locFF, locItems)

                Dim locItemCount As Integer
                Dim locSubItemCount As Integer
                Dim locString As String = ""
                For locItemCount = 1 To locItems
                    Dim locLVW As New ListViewItem
                    lvwBookItems.Items.Add(locLVW)
                    For locSubItemCount = 0 To 3
                        Input(locFF, locString)
                        If locSubItemCount = 0 Then
                            locLVW.SubItems(0).Text = locString
                        Else
                            locLVW.SubItems.Add(locString)
                        End If
                    Next
                    Input(locFF, locString)
                    locLVW.Tag = locString
                Next
                FileClose(locFF)
            End If
        End With
    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub

    Private Sub lvwBookItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwBookItems.SelectedIndexChanged
        'Das neu ausgewählte Buch in der Vorschau anzeigen

        Dim locItem As ListViewItem = lvwBookItems.SelectedItems(0)
        txtAuthor.Text = locItem.SubItems(2).Text
        txtBookTitel.Text = locItem.SubItems(0).Text
        txtEditor.Text = locItem.SubItems(1).Text
        txtArabicYear.Text = locItem.SubItems(3).Text
        txtRomanYear.Text = RomanNumeral(CInt(locItem.SubItems(3).Text))
        txtNotes.Text = CStr(locItem.Tag)

    End Sub
End Class