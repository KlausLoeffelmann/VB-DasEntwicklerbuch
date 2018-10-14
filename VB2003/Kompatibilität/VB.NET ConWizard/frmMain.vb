Option Strict Off
Option Explicit On
Friend Class frmMain
	Inherits System.Windows.Forms.Form
#Region "Vom Windows Form-Designer generierter Code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'Für das Startformular ist die zuerst erstellte Instanz die Standardinstanz.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'Dieser Aufruf ist für den Windows Form-Designer erforderlich.
		InitializeComponent()
		Form_Initialize_renamed()
	End Sub
	'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Wird vom Windows Form-Designer benötigt.
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents CommonDialog As AxMSComDlg.AxCommonDialog
	Public WithEvents _optOptions_2 As System.Windows.Forms.RadioButton
	Public WithEvents _optOptions_1 As System.Windows.Forms.RadioButton
	Public WithEvents _optOptions_0 As System.Windows.Forms.RadioButton
	Public WithEvents frmOptions As System.Windows.Forms.GroupBox
	Public WithEvents txtValue As System.Windows.Forms.TextBox
	Public WithEvents btnSort As System.Windows.Forms.Button
	Public WithEvents btnAdd As System.Windows.Forms.Button
	Public WithEvents btnDelete As System.Windows.Forms.Button
	Public WithEvents lstValues As System.Windows.Forms.ListBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents optOptions As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	Public WithEvents mnuGetList As System.Windows.Forms.MenuItem
	Public WithEvents mnuSaveList As System.Windows.Forms.MenuItem
	Public WithEvents nuDUmmy1 As System.Windows.Forms.MenuItem
	Public WithEvents mnuQuitProgram As System.Windows.Forms.MenuItem
	Public WithEvents mnuFile As System.Windows.Forms.MenuItem
	Public MainMenu1 As System.Windows.Forms.MainMenu
	'Hinweis: Die folgende Prozedur wird vom Windows Form-Designer benötigt.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Verändern mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.CommonDialog = New AxMSComDlg.AxCommonDialog
		Me.frmOptions = New System.Windows.Forms.GroupBox
		Me._optOptions_2 = New System.Windows.Forms.RadioButton
		Me._optOptions_1 = New System.Windows.Forms.RadioButton
		Me._optOptions_0 = New System.Windows.Forms.RadioButton
		Me.txtValue = New System.Windows.Forms.TextBox
		Me.btnSort = New System.Windows.Forms.Button
		Me.btnAdd = New System.Windows.Forms.Button
		Me.btnDelete = New System.Windows.Forms.Button
		Me.lstValues = New System.Windows.Forms.ListBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.optOptions = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me.mnuFile = New System.Windows.Forms.MenuItem
		Me.mnuGetList = New System.Windows.Forms.MenuItem
		Me.mnuSaveList = New System.Windows.Forms.MenuItem
		Me.nuDUmmy1 = New System.Windows.Forms.MenuItem
		Me.mnuQuitProgram = New System.Windows.Forms.MenuItem
		CType(Me.CommonDialog, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optOptions, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "Kompatibilitätstest"
		Me.ClientSize = New System.Drawing.Size(522, 395)
		Me.Location = New System.Drawing.Point(3, 49)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmMain"
		CommonDialog.OcxState = CType(resources.GetObject("CommonDialog.OcxState"), System.Windows.Forms.AxHost.State)
		Me.CommonDialog.Location = New System.Drawing.Point(472, 8)
		Me.CommonDialog.Name = "CommonDialog"
		Me.frmOptions.Text = "Optionen"
		Me.frmOptions.Size = New System.Drawing.Size(169, 169)
		Me.frmOptions.Location = New System.Drawing.Point(336, 208)
		Me.frmOptions.TabIndex = 6
		Me.frmOptions.BackColor = System.Drawing.SystemColors.Control
		Me.frmOptions.Enabled = True
		Me.frmOptions.ForeColor = System.Drawing.SystemColors.ControlText
		Me.frmOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frmOptions.Visible = True
		Me.frmOptions.Name = "frmOptions"
		Me._optOptions_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_2.Text = "Zeichenfolgen"
		Me._optOptions_2.Size = New System.Drawing.Size(145, 17)
		Me._optOptions_2.Location = New System.Drawing.Point(8, 72)
		Me._optOptions_2.TabIndex = 9
		Me._optOptions_2.Tag = "STRING"
		Me._optOptions_2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_2.BackColor = System.Drawing.SystemColors.Control
		Me._optOptions_2.CausesValidation = True
		Me._optOptions_2.Enabled = True
		Me._optOptions_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optOptions_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._optOptions_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optOptions_2.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optOptions_2.TabStop = True
		Me._optOptions_2.Checked = False
		Me._optOptions_2.Visible = True
		Me._optOptions_2.Name = "_optOptions_2"
		Me._optOptions_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_1.Text = "Datum-Werte"
		Me._optOptions_1.Size = New System.Drawing.Size(145, 17)
		Me._optOptions_1.Location = New System.Drawing.Point(8, 48)
		Me._optOptions_1.TabIndex = 8
		Me._optOptions_1.Tag = "DATE"
		Me._optOptions_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_1.BackColor = System.Drawing.SystemColors.Control
		Me._optOptions_1.CausesValidation = True
		Me._optOptions_1.Enabled = True
		Me._optOptions_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optOptions_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optOptions_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optOptions_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optOptions_1.TabStop = True
		Me._optOptions_1.Checked = False
		Me._optOptions_1.Visible = True
		Me._optOptions_1.Name = "_optOptions_1"
		Me._optOptions_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_0.Text = "Ganze Zahlen"
		Me._optOptions_0.Size = New System.Drawing.Size(145, 17)
		Me._optOptions_0.Location = New System.Drawing.Point(8, 24)
		Me._optOptions_0.TabIndex = 7
		Me._optOptions_0.Tag = "INTEGER"
		Me._optOptions_0.Checked = True
		Me._optOptions_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optOptions_0.BackColor = System.Drawing.SystemColors.Control
		Me._optOptions_0.CausesValidation = True
		Me._optOptions_0.Enabled = True
		Me._optOptions_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optOptions_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optOptions_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optOptions_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optOptions_0.TabStop = True
		Me._optOptions_0.Visible = True
		Me._optOptions_0.Name = "_optOptions_0"
		Me.txtValue.AutoSize = False
		Me.txtValue.Size = New System.Drawing.Size(313, 25)
		Me.txtValue.Location = New System.Drawing.Point(16, 48)
		Me.txtValue.TabIndex = 1
		Me.txtValue.AcceptsReturn = True
		Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtValue.BackColor = System.Drawing.SystemColors.Window
		Me.txtValue.CausesValidation = True
		Me.txtValue.Enabled = True
		Me.txtValue.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtValue.HideSelection = True
		Me.txtValue.ReadOnly = False
		Me.txtValue.Maxlength = 0
		Me.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtValue.MultiLine = False
		Me.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtValue.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtValue.TabStop = True
		Me.txtValue.Visible = True
		Me.txtValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtValue.Name = "txtValue"
		Me.btnSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnSort.Text = "Sortieren..."
		Me.btnSort.Size = New System.Drawing.Size(169, 25)
		Me.btnSort.Location = New System.Drawing.Point(336, 96)
		Me.btnSort.TabIndex = 4
		Me.btnSort.BackColor = System.Drawing.SystemColors.Control
		Me.btnSort.CausesValidation = True
		Me.btnSort.Enabled = True
		Me.btnSort.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnSort.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnSort.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnSort.TabStop = True
		Me.btnSort.Name = "btnSort"
		Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnAdd.Text = "Wert hinzufügen"
		Me.btnAdd.Size = New System.Drawing.Size(169, 25)
		Me.btnAdd.Location = New System.Drawing.Point(336, 48)
		Me.btnAdd.TabIndex = 2
		Me.btnAdd.BackColor = System.Drawing.SystemColors.Control
		Me.btnAdd.CausesValidation = True
		Me.btnAdd.Enabled = True
		Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnAdd.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnAdd.TabStop = True
		Me.btnAdd.Name = "btnAdd"
		Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnDelete.Text = "Wert löschen"
		Me.btnDelete.Size = New System.Drawing.Size(169, 25)
		Me.btnDelete.Location = New System.Drawing.Point(336, 168)
		Me.btnDelete.TabIndex = 3
		Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
		Me.btnDelete.CausesValidation = True
		Me.btnDelete.Enabled = True
		Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnDelete.TabStop = True
		Me.btnDelete.Name = "btnDelete"
		Me.lstValues.Size = New System.Drawing.Size(305, 215)
		Me.lstValues.Location = New System.Drawing.Point(16, 168)
		Me.lstValues.TabIndex = 5
		Me.lstValues.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lstValues.BackColor = System.Drawing.SystemColors.Window
		Me.lstValues.CausesValidation = True
		Me.lstValues.Enabled = True
		Me.lstValues.ForeColor = System.Drawing.SystemColors.WindowText
		Me.lstValues.IntegralHeight = True
		Me.lstValues.Cursor = System.Windows.Forms.Cursors.Default
		Me.lstValues.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.lstValues.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lstValues.Sorted = False
		Me.lstValues.TabStop = True
		Me.lstValues.Visible = True
		Me.lstValues.MultiColumn = False
		Me.lstValues.Name = "lstValues"
		Me.Label1.Text = "&Wert eingeben"
		Me.Label1.Size = New System.Drawing.Size(161, 17)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 0
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.mnuFile.Text = "&Datei"
		Me.mnuFile.Checked = False
		Me.mnuFile.Enabled = True
		Me.mnuFile.Visible = True
		Me.mnuFile.MDIList = False
		Me.mnuGetList.Text = "Liste &laden..."
		Me.mnuGetList.Shortcut = System.Windows.Forms.Shortcut.CtrlL
		Me.mnuGetList.Checked = False
		Me.mnuGetList.Enabled = True
		Me.mnuGetList.Visible = True
		Me.mnuGetList.MDIList = False
		Me.mnuSaveList.Text = "Liste &speichern..."
		Me.mnuSaveList.Shortcut = System.Windows.Forms.Shortcut.CtrlS
		Me.mnuSaveList.Checked = False
		Me.mnuSaveList.Enabled = True
		Me.mnuSaveList.Visible = True
		Me.mnuSaveList.MDIList = False
		Me.nuDUmmy1.Text = "-"
		Me.nuDUmmy1.Checked = False
		Me.nuDUmmy1.Enabled = True
		Me.nuDUmmy1.Visible = True
		Me.nuDUmmy1.MDIList = False
		Me.mnuQuitProgram.Text = "Programm be&enden"
		Me.mnuQuitProgram.Checked = False
		Me.mnuQuitProgram.Enabled = True
		Me.mnuQuitProgram.Visible = True
		Me.mnuQuitProgram.MDIList = False
		Me.Controls.Add(CommonDialog)
		Me.Controls.Add(frmOptions)
		Me.Controls.Add(txtValue)
		Me.Controls.Add(btnSort)
		Me.Controls.Add(btnAdd)
		Me.Controls.Add(btnDelete)
		Me.Controls.Add(lstValues)
		Me.Controls.Add(Label1)
		Me.frmOptions.Controls.Add(_optOptions_2)
		Me.frmOptions.Controls.Add(_optOptions_1)
		Me.frmOptions.Controls.Add(_optOptions_0)
		Me.optOptions.SetIndex(_optOptions_2, CType(2, Short))
		Me.optOptions.SetIndex(_optOptions_1, CType(1, Short))
		Me.optOptions.SetIndex(_optOptions_0, CType(0, Short))
		CType(Me.optOptions, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.CommonDialog, System.ComponentModel.ISupportInitialize).EndInit()
		Me.mnuFile.Index = 0
		MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuFile})
		Me.mnuGetList.Index = 0
		Me.mnuSaveList.Index = 1
		Me.nuDUmmy1.Index = 2
		Me.mnuQuitProgram.Index = 3
		mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem(){Me.mnuGetList, Me.mnuSaveList, Me.nuDUmmy1, Me.mnuQuitProgram})
		Me.Menu = MainMenu1
	End Sub
#End Region 
#Region "Aktualisierungssupport "
	Private Shared m_vb6FormDefInstance As frmMain
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMain
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMain()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	'UPGRADE_NOTE: Die DefInt A-Z-Anweisung wurde entfernt. Variablen wurden explizit als Typ Short deklariert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1005"' ' Default is Int
	 ' Besser ist das ' Arrays fangen bei 1 an
	
	Dim NextItemNo As Short ' Global gültig
	
	Private Sub btnSort_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnSort.Click
		
		'Formular ist bereits instanziert,
		'kann direkt aufgerufen werden
		BuildList(frmSort.DefInstance.Sort(GetItems))
		
	End Sub
	
	'UPGRADE_NOTE: Form_Initialize wurde aktualisiert auf Form_Initialize_Renamed. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
	Private Sub Form_Initialize_Renamed()
		
		'Am Anfang des Programms
		'fangen wir bei 1 zu zählen an
		NextItemNo = 1
		
	End Sub
	
	Private Sub btnAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnAdd.Click
		
		'Count ist Integer, locChar is String mit fester Länge
		Dim count As Short
		Dim locChar As New VB6.FixedLengthString(1)
		Static locErrorCount As Short
		Dim liTemp As ItemType
		
		'Wenn Integer, dann:
		Dim locIllegalChar As Boolean
		If optOptions(ContentTypeEnum.Integer_Renamed).Checked Then
			'Überprüfen, ob Buchstaben vorkommen
			
			For count = 1 To Len(txtValue.Text)
				
				locChar.Value = Mid(txtValue.Text, count, 1)
				
				If locChar.Value < "0" Or locChar.Value > "9" Then
					
					locIllegalChar = True
					Exit For
					
				End If
				
			Next count
			
			'locIllegalChar ist gültig und auf
			'locChar könnten wir auf zugreifen,
			'wenn wir wollten
			If locIllegalChar Then
				MsgBox("Bitte nur Zahlen eingeben" & vbCr & "(Keine Zahlen, keine Trennzeichen)" & vbCr & "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Falsche Eingabe")
				locErrorCount = locErrorCount + 1
				txtValue.Focus()
				Exit Sub
			End If
			
			If Not IsRangeOk(txtValue.Text) Then
				MsgBox("Wertebereich wurde überschritten!" & vbCr & "(Nur im Integerbereich von 0 bis 32768)" & vbCr & "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Falsche Eingabe")
				locErrorCount = locErrorCount + 1
				txtValue.Focus()
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts liTemp.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			liTemp.Content = CShort(txtValue.Text)
			
			
			'Wenn "Datums", dann:
		ElseIf optOptions(mdlMain.ContentTypeEnum.DateTime).Checked Then 
			If Not IsDate(txtValue.Text) Then
				MsgBox("Kein eindeutiges Datum eingegeben!" & vbCr & "Info: Das war die " & Str(locErrorCount + 1) & ". Fehleingabe", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, "Falsche Eingabe")
				locErrorCount = locErrorCount + 1
				txtValue.Focus()
				Exit Sub
			End If
			
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts liTemp.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			liTemp.Content = CDate(txtValue.Text)
			
			'Wenn Zeichenkette, dann werden alle Eingaben akzeptiert
		Else
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts liTemp.Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			liTemp.Content = txtValue.Text
		End If
		
		liTemp.Nr = NextItemNo
		NextItemNo = NextItemNo + 1
		liTemp.CreatedAt = Now
		
		lstValues.Items.Add(ToString_Renamed(liTemp))
		txtValue.Focus()
		
	End Sub
	
	Private Sub lstValues_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstValues.Enter
		
		VB6.SetDefault(btnDelete, True)
		
	End Sub
	
	Public Sub mnuGetList_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGetList.Popup
		mnuGetList_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuGetList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuGetList.Click
		
		On Error GoTo 10
		
		Dim locType As mdlMain.ContentTypeEnum
		
		With CommonDialog
			.DialogTitle = "Werteliste laden"
			.Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
			.DefaultExt = "*.vls"
			.InitDir = "C:\"
			.CancelError = True
			.ShowOpen()
			
			BuildList(GetListFromFile(.Filename, locType, True))
		End With
		
		Exit Sub
		
10: If Err.Number = MSComDlg.ErrorConstants.cdlCancel Then
			Exit Sub
		Else
			MsgBox("Fehler beim Öffnen der Datei")
			Exit Sub
		End If
		
	End Sub
	
	Public Sub mnuSaveList_Popup(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveList.Popup
		mnuSaveList_Click(eventSender, eventArgs)
	End Sub
	Public Sub mnuSaveList_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSaveList.Click
		
		On Error GoTo 20
		
		Dim locType As mdlMain.ContentTypeEnum
		
		With CommonDialog
			.DialogTitle = "Werteliste laden"
			.Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
			.DefaultExt = "*.vls"
			.InitDir = "C:\"
			.CancelError = True
			.ShowSave()
			
			SaveListToFile(.Filename, GetItems, GetContentType, True)
			
		End With
		
		Exit Sub
		
20: If Err.Number = MSComDlg.ErrorConstants.cdlCancel Then
			Exit Sub
		Else
			MsgBox("Fehler beim Öffnen der Datei")
			Exit Sub
		End If
		
	End Sub
	
	'UPGRADE_WARNING: Das Ereignis optOptions.CheckedChanged kann ausgelöst werden, wenn das Formular initialisiert wird. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2075"'
	Private Sub optOptions_CheckedChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles optOptions.CheckedChanged
		If eventSender.Checked Then
			Dim Index As Short = optOptions.GetIndex(eventSender)
			
			Dim locBack As Short
			
			'Beim Umstellen werden die Werte gelöscht
			locBack = MsgBox("Wenn Sie den Eingabetypen ändern," & vbCr & "werden alle eingegebenen Werte gelöscht" & vbCr & "Fortfahren?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Werte umstellen?")
			
			If locBack = MsgBoxResult.Yes Then
				lstValues.Items.Clear()
			End If
			
		End If
	End Sub
	
	Private Sub txtValue_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtValue.Enter
		
		VB6.SetDefault(btnAdd, True)
		txtValue.SelectionStart = 0
		txtValue.SelectionLength = Len(txtValue.Text)
		
	End Sub
	
	Private Function IsRangeOk(ByRef IntChars As String) As Boolean
		
		On Error GoTo 1000
		
		Dim locTemp As Short
		locTemp = Val(IntChars)
		IsRangeOk = True
		Exit Function
		
		'Zeilennummern benötigen keinen Doppelpunkt in VB6!
1000: IsRangeOk = False
		Exit Function
		
	End Function
	
	Private Sub btnDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDelete.Click
		
		'Abfangen, wenn gar kein Element markiert ist
		If lstValues.SelectedIndex = -1 Then
			MsgBox("Bitte wählen Sie ein Element aus der Liste zum Löschen aus!", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation)
			Exit Sub
		End If
		
		'Element löschen
		lstValues.Items.RemoveAt(lstValues.SelectedIndex)
		
		'Liste auslesen und neu aufbauen
		BuildList(GetItems)
		
	End Sub
	
	Private Sub BuildList(ByRef Values() As ItemType)
		
		Dim i, counter As Short
		
		counter = 1
		'Elemente der Liste löschen
		lstValues.Items.Clear()
		
		'Neu nummeriert der Liste
		'wieder hinzufügen
		For i = LBound(Values) To UBound(Values)
			Values(i).Nr = counter
			counter = counter + 1
			lstValues.Items.Add(ToString_Renamed(Values(i)))
		Next 
		
		'Damit es für die nächste Eingabe passt
		NextItemNo = counter
		
	End Sub
	
	Private Function GetItems() As ItemType()
		
		'i ist Integer, optType is Long, strTemp ist String
		Dim i As Short
		Dim locTemp As String
		'UPGRADE_WARNING: Die untere Begrenzung des Arrays varBack wurde von 1 in 0 geändert. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1033"'
		Dim varBack(lstValues.Items.Count) As ItemType
		
		'Array aus der Liste aufbauen
		For i = 1 To lstValues.Items.Count
			locTemp = VB6.GetItemString(lstValues, i - 1)
			'UPGRADE_WARNING: Die Standardeigenschaft des Objekts varBack(i) konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			varBack(i) = Parse(locTemp, GetContentType)
		Next i
		
		GetItems = VB6.CopyArray(varBack)
		
	End Function
	
	Private Function GetContentType() As mdlMain.ContentTypeEnum
		
		Dim optType As Integer
		
		'Welcher Typ wird gerade verarbeitet?
		For optType = 0 To 2
			If optOptions(optType).Checked Then Exit For
		Next optType
		
		'Casting von Long zu Enum geschieht automatisch
		GetContentType = optType
		
	End Function
End Class