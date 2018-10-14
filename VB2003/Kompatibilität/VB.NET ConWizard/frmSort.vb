Option Strict Off
Option Explicit On
Friend Class frmSort
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
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents ProgressBar As AxMSComctlLib.AxProgressBar
	'Hinweis: Die folgende Prozedur wird vom Windows Form-Designer benötigt.
	'Das Verändern mit dem Windows Form-Designer ist nicht möglich.
	'Das Verändern mit dem Code-Editor ist nicht möglich.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSort))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.ProgressBar = New AxMSComctlLib.AxProgressBar
		CType(Me.ProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Sortieren"
		Me.ClientSize = New System.Drawing.Size(312, 202)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSort"
		Me.Frame1.Size = New System.Drawing.Size(289, 97)
		Me.Frame1.Location = New System.Drawing.Point(8, 24)
		Me.Frame1.TabIndex = 1
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me.Label1.Text = "Liste wird sortiert. Bitte haben Sie einen Augenblick Geduld."
		Me.Label1.Size = New System.Drawing.Size(257, 41)
		Me.Label1.Location = New System.Drawing.Point(16, 32)
		Me.Label1.TabIndex = 2
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
		ProgressBar.OcxState = CType(resources.GetObject("ProgressBar.OcxState"), System.Windows.Forms.AxHost.State)
		Me.ProgressBar.Size = New System.Drawing.Size(289, 25)
		Me.ProgressBar.Location = New System.Drawing.Point(8, 144)
		Me.ProgressBar.TabIndex = 0
		Me.ProgressBar.Name = "ProgressBar"
		Me.Controls.Add(Frame1)
		Me.Controls.Add(ProgressBar)
		Me.Frame1.Controls.Add(Label1)
		CType(Me.ProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Aktualisierungssupport "
	Private Shared m_vb6FormDefInstance As frmSort
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmSort
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmSort()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Friend Function Sort(ByRef Values() As ItemType) As ItemType()
		
		Dim locTemp As ItemType
		Dim locFlag As Boolean
		Dim count As Short
		
		Me.Show()
		Me.Refresh()
		
		ProgressBar.Min = LBound(Values)
		ProgressBar.Max = UBound(Values)
		
		While Not locFlag
			locFlag = True
			
			For count = LBound(Values) To UBound(Values) - 1
				
				'Dreieckstausch
				'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Values(count + 1).Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Values(count).Content konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				If Values(count).Content > Values(count + 1).Content Then
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts locTemp konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					locTemp = Values(count)
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Values(count) konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					Values(count) = Values(count + 1)
					'UPGRADE_WARNING: Die Standardeigenschaft des Objekts Values(count + 1) konnte nicht aufgelöst werden. Klicken Sie hier für weitere Informationen: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					Values(count + 1) = locTemp
					locFlag = False
					Exit For
				End If
				
				If ProgressBar.Value < count Then
					ProgressBar.Value = count
					ProgressBar.CtlRefresh()
				End If
				
			Next 
			
		End While
		
		Me.Hide()
		Me.Close()
		
		Sort = VB6.CopyArray(Values)
		
	End Function
End Class