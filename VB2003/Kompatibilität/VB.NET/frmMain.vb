Option Explicit On 
Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private myItemCounter As Integer = 1

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
    Public WithEvents mnuFile As System.Windows.Forms.MenuItem
    Public WithEvents mnuGetList As System.Windows.Forms.MenuItem
    Public WithEvents mnuSaveList As System.Windows.Forms.MenuItem
    Public WithEvents mnuQuitProgram As System.Windows.Forms.MenuItem
    Public WithEvents frmOptions As System.Windows.Forms.GroupBox
    Public WithEvents txtValue As System.Windows.Forms.TextBox
    Public WithEvents btnSort As System.Windows.Forms.Button
    Public WithEvents btnAdd As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Public WithEvents lstValues As System.Windows.Forms.ListBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents MainMenu As System.Windows.Forms.MainMenu
    Public WithEvents mnuDummy1 As System.Windows.Forms.MenuItem
    Public WithEvents optStrings As System.Windows.Forms.RadioButton
    Public WithEvents optDates As System.Windows.Forms.RadioButton
    Public WithEvents optInteger As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.MainMenu = New System.Windows.Forms.MainMenu
        Me.mnuFile = New System.Windows.Forms.MenuItem
        Me.mnuGetList = New System.Windows.Forms.MenuItem
        Me.mnuSaveList = New System.Windows.Forms.MenuItem
        Me.mnuDummy1 = New System.Windows.Forms.MenuItem
        Me.mnuQuitProgram = New System.Windows.Forms.MenuItem
        Me.frmOptions = New System.Windows.Forms.GroupBox
        Me.optStrings = New System.Windows.Forms.RadioButton
        Me.optDates = New System.Windows.Forms.RadioButton
        Me.optInteger = New System.Windows.Forms.RadioButton
        Me.txtValue = New System.Windows.Forms.TextBox
        Me.btnSort = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.lstValues = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.frmOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuGetList, Me.mnuSaveList, Me.mnuDummy1, Me.mnuQuitProgram})
        Me.mnuFile.Text = "&Datei"
        '
        'mnuGetList
        '
        Me.mnuGetList.Index = 0
        Me.mnuGetList.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.mnuGetList.Text = "Liste &laden..."
        '
        'mnuSaveList
        '
        Me.mnuSaveList.Index = 1
        Me.mnuSaveList.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSaveList.Text = "Liste &speichern..."
        '
        'mnuDummy1
        '
        Me.mnuDummy1.Index = 2
        Me.mnuDummy1.Text = "-"
        '
        'mnuQuitProgram
        '
        Me.mnuQuitProgram.Index = 3
        Me.mnuQuitProgram.Text = "Programm be&enden"
        '
        'frmOptions
        '
        Me.frmOptions.BackColor = System.Drawing.SystemColors.Control
        Me.frmOptions.Controls.Add(Me.optStrings)
        Me.frmOptions.Controls.Add(Me.optDates)
        Me.frmOptions.Controls.Add(Me.optInteger)
        Me.frmOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frmOptions.Location = New System.Drawing.Point(336, 209)
        Me.frmOptions.Name = "frmOptions"
        Me.frmOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frmOptions.Size = New System.Drawing.Size(169, 169)
        Me.frmOptions.TabIndex = 6
        Me.frmOptions.TabStop = False
        Me.frmOptions.Text = "Optionen"
        '
        'optStrings
        '
        Me.optStrings.BackColor = System.Drawing.SystemColors.Control
        Me.optStrings.Cursor = System.Windows.Forms.Cursors.Default
        Me.optStrings.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optStrings.Location = New System.Drawing.Point(8, 72)
        Me.optStrings.Name = "optStrings"
        Me.optStrings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optStrings.Size = New System.Drawing.Size(145, 17)
        Me.optStrings.TabIndex = 2
        Me.optStrings.TabStop = True
        Me.optStrings.Tag = "2"
        Me.optStrings.Text = "Zeichenfolgen"
        '
        'optDates
        '
        Me.optDates.BackColor = System.Drawing.SystemColors.Control
        Me.optDates.Cursor = System.Windows.Forms.Cursors.Default
        Me.optDates.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optDates.Location = New System.Drawing.Point(8, 48)
        Me.optDates.Name = "optDates"
        Me.optDates.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optDates.Size = New System.Drawing.Size(145, 17)
        Me.optDates.TabIndex = 1
        Me.optDates.TabStop = True
        Me.optDates.Tag = "1"
        Me.optDates.Text = "Datum-Werte"
        '
        'optInteger
        '
        Me.optInteger.BackColor = System.Drawing.SystemColors.Control
        Me.optInteger.Checked = True
        Me.optInteger.Cursor = System.Windows.Forms.Cursors.Default
        Me.optInteger.ForeColor = System.Drawing.SystemColors.ControlText
        Me.optInteger.Location = New System.Drawing.Point(8, 24)
        Me.optInteger.Name = "optInteger"
        Me.optInteger.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.optInteger.Size = New System.Drawing.Size(145, 17)
        Me.optInteger.TabIndex = 0
        Me.optInteger.TabStop = True
        Me.optInteger.Tag = "0"
        Me.optInteger.Text = "Ganze Zahlen"
        '
        'txtValue
        '
        Me.txtValue.AcceptsReturn = True
        Me.txtValue.AutoSize = False
        Me.txtValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValue.Location = New System.Drawing.Point(16, 49)
        Me.txtValue.MaxLength = 0
        Me.txtValue.Name = "txtValue"
        Me.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtValue.Size = New System.Drawing.Size(313, 25)
        Me.txtValue.TabIndex = 1
        Me.txtValue.Text = ""
        '
        'btnSort
        '
        Me.btnSort.BackColor = System.Drawing.SystemColors.Control
        Me.btnSort.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSort.Location = New System.Drawing.Point(336, 97)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSort.Size = New System.Drawing.Size(169, 25)
        Me.btnSort.TabIndex = 3
        Me.btnSort.Text = "Sortieren..."
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
        Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(336, 48)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAdd.Size = New System.Drawing.Size(169, 25)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Wert hinzufügen"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDelete.Location = New System.Drawing.Point(336, 169)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDelete.Size = New System.Drawing.Size(169, 25)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Wert löschen"
        '
        'lstValues
        '
        Me.lstValues.BackColor = System.Drawing.SystemColors.Window
        Me.lstValues.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstValues.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lstValues.Location = New System.Drawing.Point(16, 169)
        Me.lstValues.Name = "lstValues"
        Me.lstValues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstValues.Size = New System.Drawing.Size(305, 212)
        Me.lstValues.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(161, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Wert eingeben"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(520, 414)
        Me.Controls.Add(Me.frmOptions)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstValues)
        Me.Controls.Add(Me.Label1)
        Me.Menu = Me.MainMenu
        Me.Name = "frmMain"
        Me.Text = "Kompatiblitätsdemo"
        Me.frmOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Hier ist ein Region Beispiel über zwei Codeobjekte"

    Private Sub mnuQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitProgram.Click

        Me.Dispose()


    End Sub

    Private Sub txtValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.GotFocus

        'der folgende Codeteil ist ausgeblendet
        Me.AcceptButton = Me.btnAdd
        txtValue.SelectAll()

    End Sub
#End Region

    Private Function GetContentType() As ContentTypeEnum

        Dim locRadioButton As RadioButton

        'Welcher Typ wird gerade verarbeitet?
        'Dazu Controls-Collection des Rahmens durchlaufen
        For Each ctrl As Control In frmOptions.Controls
            'Ist das aktuelle Control ein Radio-Button?
            If ctrl.GetType.FullName = "RadioButton" Then
                'In Radio-Button casten
                locRadioButton = CType(ctrl, RadioButton)
                If locRadioButton.Checked Then
                    'Den Tag in einen Int, 
                    'und Int dann zu ContentTypeEnum casten
                    'Funktionsrückgabe geschieht durch Return 
                    Return CType(CInt(txtValue.Text), ContentTypeEnum)
                End If
                'es ginge übrigens auch ohne Umweg über eine Variable:
                'if CType(ctrl, RadioButton).Checked then
            End If
        Next

    End Function

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'locCount wird an dieser Stelle
        'nicht mehr definiert
        'Dim locCount As Integer
        Static locErrorCount As Integer

        'Muss nicht mit New deklariert werden
        'da es ein Werte- und kein Verweistyp ist
        Dim locItemType As ItemType

        'Muss hier deklariert werden,
        'da der Gültigkeitsbereich für
        'die gesamte Prozedur klar sein muss
        Dim locIllegalChar As Boolean

        'Wenn Integer, dann:
        If optInteger.Checked Then

            'Überprüfen, ob Buchstaben vorkommen

            'Zählvariable wird in For-Struktur deklariert
            'Achtung: Geht erst ab Visual Basic 2003
            For locCount As Integer = 1 To txtValue.Text.Length

                'Deklaration und Definition "in einem Rutsch"
                Dim locChar As Char = CChar(txtValue.Text.Substring(locCount - 1, 1))

                'Kurzschlussauswertung beschleunigt den Vorgang
                If locChar < "0" OrElse locChar > "9" Then
                    locIllegalChar = True
                    Exit For
                End If

            Next locCount

            'TODO: Diese Aufgabe steht im Aufgabenfenster
            'locIllegalChar ist gültig und auf
            'Auf locChar können wir nicht zugreifen,
            'da es nicht mehr im Gültigkeitsbereich liegt.
            If locIllegalChar Then
                MsgBox("Bitte nur Zahlen eingeben" & vbCr & "(Keine Zahlen, keine Trennzeichen)" & vbCr _
                        & "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", _
                        MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Falsche Eingabe")
                locErrorCount += 1
                txtValue.Focus()
                Exit Sub
            End If

            'TODO: Nott schreibt man nicht mit Doppel-T
            If Not IsRangeOkProper(txtValue.Text) Then
                MsgBox("Wertebereich wurde überschritten!" & vbCr & "(Nur im Integerbereich von 0 bis 32768)" & vbCr _
                        & "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", _
                        MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Falsche Eingabe")
                locErrorCount += 1
                txtValue.Focus()
                Exit Sub
            End If

            'Als Integer "geboxed"
            locItemType.Content = CInt(txtValue.Text)

        ElseIf optDates.Checked Then
            If Not IsDate(txtValue.Text) Then
                MsgBox("Kein Datumsformat!" & vbCr & _
                "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", _
                MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Fehlerhafte Eingabe")

                'Als DateTime "geboxed"
                locItemType.Content = CDate(txtValue.Text)

            End If
        Else
            locItemType.Content = txtValue.Text

            'Das wäre falsch!
            'liTemp.Content = txtValue
        End If

        locItemType.Nr = myItemCounter
        locItemType.CreatedAt = DateTime.Now
        myItemCounter += 1

        lstValues.Items.Add(locItemType)

        txtValue.Focus()

    End Sub

    <Obsolete("Alte Verfahrensweise - wollen wir nicht mehr machen...", True)> _
    Private Function IsRangeOk(ByRef IntChars As String) As Boolean

        On Error GoTo 1000

        Dim locTemp As Integer
        locTemp = CInt(IntChars)
        IsRangeOk = True
        Exit Function

        'Zeilennummern benötigen einen Doppelpunkt in VB.NET!
1000:   IsRangeOk = False
        Exit Function

    End Function

    Private Function IsRangeOkProper(ByRef IntChars As String) As Boolean

        Dim locTemp As Integer

        Try
            locTemp = CInt(IntChars)
            Return True
        Catch
            Return False
        End Try

    End Function

    Private Sub BuildList(ByRef Values As ItemTypes)

        Dim locCount As Integer = 1

        lstValues.Items.Clear()

        'Liste neu numerieren und aufbauen
        For Each IType As ItemType In Values
            IType.Nr = locCount
            locCount += 1
            lstValues.Items.Add(IType)
        Next

    End Sub

    Private Function GetItems() As ItemTypes

        'Rückgabewert vorbereiten
        Dim backItemTypes As New ItemTypes

        'Liste in Rückgabetyp kopieren
        For Each IType As ItemType In lstValues.Items
            backItemTypes.Add(IType)
        Next

        'und zurückgeben
        Return backItemTypes

    End Function

    Public Function GetListFromFile(ByRef Filename As String, ByRef BackType As ContentTypeEnum, Optional ByRef ShowErrorMessages As Boolean = True) As ItemTypes

        Dim i, ff, locAmountDataSets, locBackType As Integer
        Dim locItem As ItemType
        Dim Items As New ItemTypes
        Dim locString As String

        'Überflüssig, es gibt keine
        'Variant-Optionalen-Argumente mehr!
        'Dim locShowErrors As Boolean

        'Das Öffnen der Datei...
        Try
            ff = FreeFile()
            FileOpen(ff, Filename, OpenMode.Input)
        Catch ex As Exception

            If ShowErrorMessages Then
                MsgBox("Beim Öffnen der Datei" & vbCr & _
                Filename & vbCr & "ist ein Fehler aufgetreten." & vbCr _
                & "Bitte wiederholen Sie den Vorgang gegebenenfalls.", _
                MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Fehler beim Laden")
            End If

            BackType = ContentTypeEnum.Error
            Return Nothing

        End Try

        '...und deren Lesen können unterschiedliche
        'Fehlerbehandlungen notwendig machen,
        'deswegen *je* ein Try/Catch-Block
        Try
            Input(ff, locAmountDataSets)
            Input(ff, locBackType) : BackType = CType(locBackType, ContentTypeEnum)

            'Achtung: Array-Grenze beginnt standardmäßig bei 0, nicht bei 1!
            For i = 0 To locAmountDataSets - 1
                locString = LineInput(ff)
                locItem.Nr = CInt(locString)

                locString = LineInput(ff)

                Select Case BackType

                    Case ContentTypeEnum.Integer

                        locItem.Content = CInt(locString)

                    Case ContentTypeEnum.String
                        locItem.Content = CStr(locString)

                    Case ContentTypeEnum.DateTime
                        locItem.Content = CDate(locString)

                End Select

                locString = LineInput(ff)
                locItem.CreatedAt = CDate(locString)
                Items.Add(locItem)
            Next i

            'Zähler für das nächste Element setzen
            myItemCounter = i

            'Die Function ist hier noch nicht zu Ende, denn...
            Return Items

        Catch ex As Exception

            If ShowErrorMessages Then
                MsgBox("Beim Lesen der Datei" & vbCr & _
                Filename & vbCr & "ist ein Fehler aufgetreten." & vbCr _
                & "Bitte wiederholen Sie den Vorgang gegebenenfalls.", _
                MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Fehler beim Laden")
                BackType = ContentTypeEnum.Error
            End If

            Return Nothing

        Finally

            'das hier wird in jedem Falle ausgeführt,
            'egal ob Fehler, oder nicht - und damit
            'ist die geöffnete Datei garantiert zu!
            FileClose(ff)

        End Try

    End Function

    Public Function SaveListToFile(ByRef Filename As String, ByRef Items As ItemTypes, ByRef DType As ContentTypeEnum, Optional ByRef ShowErrorMessages As Boolean = True) As Boolean

        Dim i, ff, locVar As Integer
        Dim locType As ContentTypeEnum
        Dim locString As String

        'Überflüssig, es gibt keine
        'Variant-Optionalen-Argumente mehr!
        'Dim locShowErrors As Boolean

        'Das Öffnen der Datei...
        Try
            ff = FreeFile()
            FileOpen(ff, Filename, OpenMode.Output)

        Catch ex As Exception

            If ShowErrorMessages Then
                MsgBox("Beim Öffnen der Datei" & vbCr & _
                Filename & vbCr & "ist ein Fehler aufgetreten." & vbCr _
                & "Bitte wiederholen Sie den Vorgang gegebenenfalls.", _
                MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Fehler beim Laden")
            End If

            Return False

        End Try

        '...und deren Schreiben können unterschiedliche
        'Fehlerbehandlungen notwendig machen,
        'deswegen *je* ein Try/Catch-Block
        Try
            PrintLine(ff, Items.Count)
            PrintLine(ff, DType)
            For Each locItem As ItemType In Items
                PrintLine(ff, CStr(locItem.Nr))
                PrintLine(ff, CStr(locItem.Content))
                PrintLine(ff, CStr(locItem.CreatedAt))
            Next

            FileClose(ff)
            Return True

        Catch ex As Exception

            If ShowErrorMessages Then
                MsgBox("Beim Schreiben der Datei" & vbCr & _
                Filename & vbCr & "ist ein Fehler aufgetreten." & vbCr _
                & "Bitte wiederholen Sie den Vorgang gegebenenfalls.", _
                MsgBoxStyle.OKOnly Or MsgBoxStyle.Exclamation, "Fehler beim Laden")
            End If

            Return Nothing

        Finally

            'das hier wird in jedem Falle ausgeführt,
            'egal ob Fehler, oder nicht - und damit
            'ist die geöffnete Datei garantiert zu!
            FileClose(ff)

        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'Eintrag an ausgewählter Stelle löschen
        lstValues.Items.RemoveAt(lstValues.SelectedIndex)

        'Liste holen und wieder aufbauen,
        'dabei wird neu numeriert
        BuildList(GetItems())

    End Sub

    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click

        Dim locFrmSort As New frmSort

        BuildList(locFrmSort.Sort(GetItems))

    End Sub

    Private Sub mnuGetList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGetList.Click

        Dim locOpenFile As New OpenFileDialog
        Dim locBackType As ContentTypeEnum

        With locOpenFile
            .Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
            .InitialDirectory = "C:\"
            .DefaultExt = "*.LST"
            .CheckFileExists = True
            .AddExtension = True
            .Title = "Wertelisten laden"
            Dim locDr As DialogResult = .ShowDialog()

            If locDr = DialogResult.Cancel Then
                Exit Sub
            End If

            BuildList(GetListFromFile(.FileName, locBackType))

        End With

    End Sub

    Private Sub mnuSaveList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveList.Click

        Dim locSaveFile As New SaveFileDialog
        Dim locBackType As ContentTypeEnum

        With locSaveFile
            .Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
            .InitialDirectory = "C:\"
            .DefaultExt = "*.LST"
            .OverwritePrompt = True
            .AddExtension = True
            .Title = "Wertelisten laden"
            Dim locDR As DialogResult = .ShowDialog()

            If locDR = DialogResult.Cancel Then
                Exit Sub
            End If

            SaveListToFile(.FileName, GetItems(), GetContentType())

        End With

    End Sub
End Class

Public Enum ContentTypeEnum

    [Integer] = 0
    DateTime = 1
    [String] = 2
    [Error] = 3

End Enum

Public Class ItemTypes
    Inherits ArrayList

    Public Shadows Function Add(ByVal value As ItemType) As Integer

        Return MyBase.Add(value)

    End Function

    Default Public Shadows Property Item(ByVal index As Integer) As ItemType

        Get
            Return CType(MyBase.Item(index), ItemType)
        End Get

        Set(ByVal Value As ItemType)
            MyBase.Item(index) = Value
        End Set

    End Property
End Class

Public Structure ItemType

    Private myNr As Integer
    Private myContent As Object
    Private myCreatedAt As Date

    Public Sub New(ByVal Nr As Integer, ByVal Content As Object, ByVal CreatedAt As Date)

        myNr = Nr
        myContent = Content
        myCreatedAt = CreatedAt

    End Sub

    Public Sub New(ByVal ToParse As String, ByVal DesType As ContentTypeEnum)

        Dim Item() As String

        Item = Split(ToParse, vbTab)
        myNr = CInt(Item(0))

        'in Abhängigkeit vom gewählten Typen
        Select Case DesType

            'in das...
        Case ContentTypeEnum.Integer
                myContent = CInt(Item(1))

                'jeweilige 
            Case ContentTypeEnum.String
                myContent = CStr(Item(1))

                'Objekt "boxen"
            Case ContentTypeEnum.DateTime
                myContent = CDate(Item(1))

        End Select

        myCreatedAt = CDate(Item(2))

    End Sub

    Public Property Nr() As Integer

        Get
            Return myNr
        End Get

        Set(ByVal Value As Integer)
            myNr = Value
        End Set

    End Property

    Public Property Content() As Object
        Get
            Return myContent
        End Get
        Set(ByVal Value As Object)
            myContent = Value
        End Set
    End Property

    Public Property CreatedAt() As Date
        Get
            Return myCreatedAt
        End Get
        Set(ByVal Value As Date)
            myCreatedAt = Value
        End Set
    End Property

    Public Overrides Function ToString() As String

        Return Me.Nr.ToString() & ". " & vbTab & Me.Content.ToString & vbTab & Me.CreatedAt.ToString

    End Function

End Structure
