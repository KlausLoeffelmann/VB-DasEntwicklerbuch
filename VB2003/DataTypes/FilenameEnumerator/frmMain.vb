Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDirectory As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPathForTestFiles As System.Windows.Forms.TextBox
    Friend WithEvents btnDateinamenInDatei As System.Windows.Forms.Button
    Friend WithEvents btnDirectory As System.Windows.Forms.Button
    Friend WithEvents btnRenameFiles As System.Windows.Forms.Button
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents btnTestFilesDirectory As System.Windows.Forms.Button
    Friend WithEvents btnGenerateTestFiles As System.Windows.Forms.Button
    Friend WithEvents btnUncheckAll As System.Windows.Forms.Button
    Friend WithEvents btnCheckAll As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckFound As System.Windows.Forms.Button
    Friend WithEvents btnReplaceChecked As System.Windows.Forms.Button
    Friend WithEvents txtReplace As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents fneFiles As FilenameEnum.FilenameEnumerator
    Friend WithEvents chkEpisodeNameFilter As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDirectory = New System.Windows.Forms.TextBox
        Me.btnDirectory = New System.Windows.Forms.Button
        Me.btnRenameFiles = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkEpisodeNameFilter = New System.Windows.Forms.CheckBox
        Me.txtReplace = New System.Windows.Forms.TextBox
        Me.btnReplaceChecked = New System.Windows.Forms.Button
        Me.btnCheckFound = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.btnTestFilesDirectory = New System.Windows.Forms.Button
        Me.txtPathForTestFiles = New System.Windows.Forms.TextBox
        Me.btnGenerateTestFiles = New System.Windows.Forms.Button
        Me.btnDateinamenInDatei = New System.Windows.Forms.Button
        Me.btnUncheckAll = New System.Windows.Forms.Button
        Me.btnCheckAll = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fneFiles = New FilenameEnum.FilenameEnumerator
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDirectory)
        Me.GroupBox1.Controls.Add(Me.btnDirectory)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Suchpfad:"
        '
        'txtDirectory
        '
        Me.txtDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDirectory.Location = New System.Drawing.Point(16, 32)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.ReadOnly = True
        Me.txtDirectory.Size = New System.Drawing.Size(472, 20)
        Me.txtDirectory.TabIndex = 0
        Me.txtDirectory.Text = "C:\"
        '
        'btnDirectory
        '
        Me.btnDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDirectory.Location = New System.Drawing.Point(504, 32)
        Me.btnDirectory.Name = "btnDirectory"
        Me.btnDirectory.Size = New System.Drawing.Size(96, 24)
        Me.btnDirectory.TabIndex = 1
        Me.btnDirectory.Text = "Verzeichnis..."
        '
        'btnRenameFiles
        '
        Me.btnRenameFiles.Location = New System.Drawing.Point(8, 56)
        Me.btnRenameFiles.Name = "btnRenameFiles"
        Me.btnRenameFiles.Size = New System.Drawing.Size(176, 24)
        Me.btnRenameFiles.TabIndex = 1
        Me.btnRenameFiles.Text = "Markierte Dateien umbenennen"
        Me.ToolTip1.SetToolTip(Me.btnRenameFiles, "Benennt alle markierte Dateien in den neuen Dateinamen um")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkEpisodeNameFilter)
        Me.GroupBox2.Controls.Add(Me.txtReplace)
        Me.GroupBox2.Controls.Add(Me.btnReplaceChecked)
        Me.GroupBox2.Controls.Add(Me.btnCheckFound)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.btnQuitProgram)
        Me.GroupBox2.Controls.Add(Me.btnTestFilesDirectory)
        Me.GroupBox2.Controls.Add(Me.txtPathForTestFiles)
        Me.GroupBox2.Controls.Add(Me.btnGenerateTestFiles)
        Me.GroupBox2.Controls.Add(Me.btnDateinamenInDatei)
        Me.GroupBox2.Controls.Add(Me.btnUncheckAll)
        Me.GroupBox2.Controls.Add(Me.btnCheckAll)
        Me.GroupBox2.Controls.Add(Me.btnRenameFiles)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(432, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(184, 430)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funktionen:"
        '
        'chkEpisodeNameFilter
        '
        Me.chkEpisodeNameFilter.Checked = True
        Me.chkEpisodeNameFilter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEpisodeNameFilter.Location = New System.Drawing.Point(16, 24)
        Me.chkEpisodeNameFilter.Name = "chkEpisodeNameFilter"
        Me.chkEpisodeNameFilter.Size = New System.Drawing.Size(160, 16)
        Me.chkEpisodeNameFilter.TabIndex = 0
        Me.chkEpisodeNameFilter.Text = "Seriennamen-Filter"
        '
        'txtReplace
        '
        Me.txtReplace.Location = New System.Drawing.Point(8, 336)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New System.Drawing.Size(168, 20)
        Me.txtReplace.TabIndex = 11
        Me.txtReplace.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtReplace, "Geben Sie hier den Begriff ein, durch den der Suchbegriff in den Namen der markie" & _
        "rten Dateien ersetzt werden soll")
        '
        'btnReplaceChecked
        '
        Me.btnReplaceChecked.Location = New System.Drawing.Point(8, 312)
        Me.btnReplaceChecked.Name = "btnReplaceChecked"
        Me.btnReplaceChecked.Size = New System.Drawing.Size(168, 24)
        Me.btnReplaceChecked.TabIndex = 10
        Me.btnReplaceChecked.Text = "Markierte ersetzen durch"
        Me.ToolTip1.SetToolTip(Me.btnReplaceChecked, "Ersetzt den Suchbegriff (oben einzugeben) durch den unten einzugebenen Begriff")
        '
        'btnCheckFound
        '
        Me.btnCheckFound.Location = New System.Drawing.Point(8, 264)
        Me.btnCheckFound.Name = "btnCheckFound"
        Me.btnCheckFound.Size = New System.Drawing.Size(168, 24)
        Me.btnCheckFound.TabIndex = 8
        Me.btnCheckFound.Text = "Alle markieren mit"
        Me.ToolTip1.SetToolTip(Me.btnCheckFound, "Markiert alle Dateiein, in denen der unten anzugebene Suchbegriff vorkommt")
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(8, 288)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(168, 20)
        Me.txtSearch.TabIndex = 9
        Me.txtSearch.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtSearch, "Geben SIe hier den Suchbegriff ein")
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnQuitProgram.Location = New System.Drawing.Point(8, 400)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(168, 24)
        Me.btnQuitProgram.TabIndex = 12
        Me.btnQuitProgram.Text = "Programm beenden"
        Me.ToolTip1.SetToolTip(Me.btnQuitProgram, "Beendet das Programm")
        '
        'btnTestFilesDirectory
        '
        Me.btnTestFilesDirectory.Location = New System.Drawing.Point(160, 192)
        Me.btnTestFilesDirectory.Name = "btnTestFilesDirectory"
        Me.btnTestFilesDirectory.Size = New System.Drawing.Size(24, 24)
        Me.btnTestFilesDirectory.TabIndex = 6
        Me.btnTestFilesDirectory.Text = "..."
        '
        'txtPathForTestFiles
        '
        Me.txtPathForTestFiles.Location = New System.Drawing.Point(8, 224)
        Me.txtPathForTestFiles.Name = "txtPathForTestFiles"
        Me.txtPathForTestFiles.Size = New System.Drawing.Size(152, 20)
        Me.txtPathForTestFiles.TabIndex = 7
        Me.txtPathForTestFiles.Text = "C:\"
        Me.ToolTip1.SetToolTip(Me.txtPathForTestFiles, "Das Ausgabeverzeichnis der Testdateien")
        '
        'btnGenerateTestFiles
        '
        Me.btnGenerateTestFiles.Location = New System.Drawing.Point(8, 192)
        Me.btnGenerateTestFiles.Name = "btnGenerateTestFiles"
        Me.btnGenerateTestFiles.Size = New System.Drawing.Size(176, 24)
        Me.btnGenerateTestFiles.TabIndex = 5
        Me.btnGenerateTestFiles.Text = "Testdateien generieren"
        Me.ToolTip1.SetToolTip(Me.btnGenerateTestFiles, "Generiert Testdateien aus der vorhandenen Dateinamenliste")
        '
        'btnDateinamenInDatei
        '
        Me.btnDateinamenInDatei.Location = New System.Drawing.Point(8, 152)
        Me.btnDateinamenInDatei.Name = "btnDateinamenInDatei"
        Me.btnDateinamenInDatei.Size = New System.Drawing.Size(176, 24)
        Me.btnDateinamenInDatei.TabIndex = 4
        Me.btnDateinamenInDatei.Text = "Dateinamen in Datei"
        Me.ToolTip1.SetToolTip(Me.btnDateinamenInDatei, "Legt eine Textdatei mit allen Dateinamen an")
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Location = New System.Drawing.Point(8, 120)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(176, 24)
        Me.btnUncheckAll.TabIndex = 3
        Me.btnUncheckAll.Text = "Markierungen aufheben"
        Me.ToolTip1.SetToolTip(Me.btnUncheckAll, "Hebt die Markierung aller Dateinamen wieder auf")
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(8, 88)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(176, 24)
        Me.btnCheckAll.TabIndex = 2
        Me.btnCheckAll.Text = "Alle markieren"
        Me.ToolTip1.SetToolTip(Me.btnCheckAll, "Markiert alle Dateinamen")
        '
        'fneFiles
        '
        Me.fneFiles.CheckBoxes = True
        Me.fneFiles.Directory = CType(resources.GetObject("fneFiles.Directory"), System.IO.DirectoryInfo)
        Me.fneFiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fneFiles.EpisodeNameFilter = True
        Me.fneFiles.GridLines = True
        Me.fneFiles.Location = New System.Drawing.Point(0, 88)
        Me.fneFiles.Name = "fneFiles"
        Me.fneFiles.Size = New System.Drawing.Size(432, 430)
        Me.fneFiles.TabIndex = 3
        Me.fneFiles.View = System.Windows.Forms.View.Details
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 518)
        Me.Controls.Add(Me.fneFiles)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMain"
        Me.Text = "Dateinamenausgleicher"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    'Wird vom Konstruktor aufgerufen, der sich in der
    'ausgeblendeten Designer-Region verbirgt!

    Private Sub btnDirectory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectory.Click

        Dim locFolderBrowser As New FolderBrowserDialog

        With locFolderBrowser
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Wählen Sie das Dateienverzeichnis aus:"
            Dim locResult As DialogResult = .ShowDialog()

            If locResult = DialogResult.OK Then
                txtDirectory.Text = .SelectedPath
                Me.fneFiles.Directory = New DirectoryInfo(.SelectedPath)
            End If
        End With
    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Dispose()
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
            If locDiaRes = DialogResult.OK Then
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

            If locResult = DialogResult.OK Then
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

Public Class FilenameEnumeratorItem
    Inherits ListViewItem

    Protected myFilename As FileInfo
    Protected myEpisodeNameFilter As Boolean

    Public Sub New(ByVal Filename As FileInfo, ByVal EpisodeNameFilter As Boolean)
        MyBase.new()
        myFilename = Filename
        myEpisodeNameFilter = EpisodeNameFilter
        Me.Text = myFilename.Name
        Me.SubItems.Add(NewFilename.Name)
        Me.SubItems.Add(myFilename.Directory.FullName)
    End Sub

    Public Property Filename() As FileInfo
        Get
            Return myFilename
        End Get
        Set(ByVal Value As FileInfo)
            myFilename = Value
        End Set
    End Property

    Public Overridable ReadOnly Property NewFilename() As FileInfo
        Get
            Dim locFilename As String = myFilename.Name
            Dim locParts As New ArrayList
            Dim blnCharTypesChanged As Boolean
            Dim locChar, locPrevChar As Char
            Dim locCurrentPart As String
            Dim locNumberStartPart, locNumberEndPart As Integer
            Dim locProhibitFurtherCharTypeChanges As Boolean

            Dim locPräfix, locNumPart, locPostfix As String

            If Not myEpisodeNameFilter Then
                Return myFilename
            End If

            'Finden des Nummern-Parts und Ersetzen aller Unterstriche
            'durch Leerzeichen
            For count As Integer = 0 To locFilename.Length - 1
                locChar = locFilename.Chars(count)
                If locChar = "_"c Then locChar = " "c

                'Den Nummernpart des Dateinamens suchen
                If Not locProhibitFurtherCharTypeChanges Then
                    If locChar.IsDigit(locChar) And Not blnCharTypesChanged Then
                        blnCharTypesChanged = True
                        'Falls "S" oder "s" davor stand, Buchstaben mit einbeziehen
                        If locPrevChar = "S"c Or locPrevChar = "s"c Then
                            locNumberStartPart = count - 1
                        Else
                            locNumberStartPart = count
                        End If
                    End If
                End If


                If Not locProhibitFurtherCharTypeChanges Then
                    'Wenn Nummernpart schon vorbei, und wieder ein Buchstabe...
                    If Char.IsLetter(locChar) And blnCharTypesChanged Then
                        If count < locFilename.Length - 2 Then
                            Dim locNextChar As Char = locFilename.Chars(count + 1)
                            '...aber nur wenn der Buchstabe kein Episodenkennzeichner ist...
                            If Not ((Char.IsLetter(locChar) And Char.IsDigit(locNextChar)) And _
                                (locChar = "E"c Or locChar = "e"c Or locChar = "x" Or locChar = "X")) Then
                                '...ist der Nummernpart vorbei und es folgt wieder Text
                                locNumberEndPart = count
                                locProhibitFurtherCharTypeChanges = True
                            End If
                        End If
                    End If
                End If
                locCurrentPart += locChar.ToString
                locPrevChar = locChar
            Next

            'Sonderfall: Dateiname endet mit Nummer
            If locNumberEndPart = 0 Then
                locNumberEndPart = locFilename.Length
            End If

            'Dateinamen auseinander bauen
            locPräfix = locCurrentPart.Substring(0, locNumberStartPart)
            locNumPart = locCurrentPart.Substring(locNumberStartPart, locNumberEndPart - locNumberStartPart)
            locPostfix = locCurrentPart.Substring(locNumberEndPart)

            'Alle denkbaren "Umbauten" im Dateinamen durchführen
            locPräfix = locPräfix.Replace("."c, " "c)
            locPräfix = locPräfix.Trim(New Char() {" "c, "-"c})
            locNumPart = locNumPart.Replace("."c, "")
            locNumPart = locNumPart.Replace("S"c, "")
            locNumPart = locNumPart.Replace("s"c, "")
            locNumPart = locNumPart.Replace("E"c, "x"c)
            locNumPart = locNumPart.Replace("e"c, "x"c)
            locNumPart = locNumPart.Replace("X"c, "x"c)
            locNumPart = locNumPart.Trim(New Char() {" "c, "-"c})
            locPostfix = locPostfix.Trim(New Char() {" "c, "-"c})

            'Und neuen Dateinamen zurückliefern
            Return New FileInfo(Filename.DirectoryName + "\" + locPräfix + " - " + locNumPart + " - " + locPostfix)
        End Get
    End Property

End Class

Public Class FilenameEnumerator
    Inherits ListView

    Protected myDirectory As DirectoryInfo
    Protected myEpisodeNameFilter As Boolean

    Public Sub New()
        MyBase.New()
        Initialize(New DirectoryInfo("C:\"))
    End Sub

    Public Sub New(ByVal Directory As DirectoryInfo)
        MyBase.New()
        Initialize(Directory)
    End Sub

    Private Sub Initialize(ByVal Directory As DirectoryInfo)
        Me.CheckBoxes = True
        Me.GridLines = True
        Me.View = System.Windows.Forms.View.Details
        Me.EpisodeNameFilter = True

        With Me.Columns
            .Add("Dateiname", -1, HorizontalAlignment.Left)
            .Add("Neuer Name", -1, HorizontalAlignment.Left)
            .Add("Pfad:", -1, HorizontalAlignment.Left)
        End With
        Me.Directory = Directory
    End Sub

    Protected Overridable Sub BuildItems()

        Items.Clear()
        If Directory Is Nothing Then
            Return
        End If

        'Keine Dateien im Designmode erzeugen,
        'damit kommt der Designer schlecht klar!
        If Me.DesignMode = True Then
            Exit Sub
        End If

        For Each locFI As FileInfo In Directory.GetFiles()
            Items.Add(New FilenameEnumeratorItem(locFI, EpisodeNameFilter))
        Next

    End Sub

    Public Property Directory() As DirectoryInfo
        Get
            Return myDirectory
        End Get
        Set(ByVal Value As DirectoryInfo)
            myDirectory = Value
            BuildItems()
            CheckAll()
        End Set
    End Property

    Public Overridable Sub CheckAll()
        For Each locFEI As FilenameEnumeratorItem In Items
            locFEI.Checked = True
        Next
    End Sub

    Public Overridable Sub UncheckAll()
        For Each locFEI As FilenameEnumeratorItem In Items
            locFEI.Checked = False
        Next
    End Sub

    Public Property EpisodeNameFilter() As Boolean
        Get
            Return myEpisodeNameFilter
        End Get
        Set(ByVal Value As Boolean)
            myEpisodeNameFilter = Value
            BuildItems()
            CheckAll()
        End Set
    End Property

End Class