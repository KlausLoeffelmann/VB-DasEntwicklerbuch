<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADSQLServerConnector
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbMain = New System.Windows.Forms.GroupBox
        Me.chkUseSXDefaultInstance = New System.Windows.Forms.CheckBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.lblUserID = New System.Windows.Forms.Label
        Me.optUseMixedMode = New System.Windows.Forms.RadioButton
        Me.optUseIntegratedSecurity = New System.Windows.Forms.RadioButton
        Me.InstanceCombo = New Activedev.SqlSupport.ADSqlInstanceInfoComboBox
        Me.lblServerInstances = New System.Windows.Forms.Label
        Me.gbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.chkUseSXDefaultInstance)
        Me.gbMain.Controls.Add(Me.txtPassword)
        Me.gbMain.Controls.Add(Me.lblPassword)
        Me.gbMain.Controls.Add(Me.txtUserID)
        Me.gbMain.Controls.Add(Me.lblUserID)
        Me.gbMain.Controls.Add(Me.optUseMixedMode)
        Me.gbMain.Controls.Add(Me.optUseIntegratedSecurity)
        Me.gbMain.Controls.Add(Me.InstanceCombo)
        Me.gbMain.Controls.Add(Me.lblServerInstances)
        Me.gbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbMain.Location = New System.Drawing.Point(0, 0)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(317, 195)
        Me.gbMain.TabIndex = 0
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Verbindung zur SQL Server-Instanz"
        '
        'chkUseSXDefaultInstance
        '
        Me.chkUseSXDefaultInstance.AutoSize = True
        Me.chkUseSXDefaultInstance.Location = New System.Drawing.Point(13, 52)
        Me.chkUseSXDefaultInstance.Name = "chkUseSXDefaultInstance"
        Me.chkUseSXDefaultInstance.Size = New System.Drawing.Size(295, 17)
        Me.chkUseSXDefaultInstance.TabIndex = 0
        Me.chkUseSXDefaultInstance.Text = "SQL Express Standardinstanz des Computers verwenden"
        Me.chkUseSXDefaultInstance.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(146, 163)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(165, 20)
        Me.txtPassword.TabIndex = 8
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(87, 166)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(53, 13)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Passwort:"
        '
        'txtUserID
        '
        Me.txtUserID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUserID.Location = New System.Drawing.Point(146, 138)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(165, 20)
        Me.txtUserID.TabIndex = 6
        Me.txtUserID.Text = "sa"
        '
        'lblUserID
        '
        Me.lblUserID.AutoSize = True
        Me.lblUserID.Location = New System.Drawing.Point(62, 141)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(78, 13)
        Me.lblUserID.TabIndex = 5
        Me.lblUserID.Text = "Benutzername:"
        '
        'optUseMixedMode
        '
        Me.optUseMixedMode.AutoSize = True
        Me.optUseMixedMode.Location = New System.Drawing.Point(9, 113)
        Me.optUseMixedMode.Name = "optUseMixedMode"
        Me.optUseMixedMode.Size = New System.Drawing.Size(289, 17)
        Me.optUseMixedMode.TabIndex = 4
        Me.optUseMixedMode.Text = "Mixed Mode - Folgende Kontoinformationen verwenden:"
        Me.optUseMixedMode.UseVisualStyleBackColor = True
        '
        'optUseIntegratedSecurity
        '
        Me.optUseIntegratedSecurity.AutoSize = True
        Me.optUseIntegratedSecurity.Checked = True
        Me.optUseIntegratedSecurity.Location = New System.Drawing.Point(9, 88)
        Me.optUseIntegratedSecurity.Name = "optUseIntegratedSecurity"
        Me.optUseIntegratedSecurity.Size = New System.Drawing.Size(225, 17)
        Me.optUseIntegratedSecurity.TabIndex = 3
        Me.optUseIntegratedSecurity.TabStop = True
        Me.optUseIntegratedSecurity.Text = "Integrierte Windows Sicherheit verwenden"
        Me.optUseIntegratedSecurity.UseVisualStyleBackColor = True
        '
        'InstanceCombo
        '
        Me.InstanceCombo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InstanceCombo.FormattingEnabled = True
        Me.InstanceCombo.Location = New System.Drawing.Point(126, 22)
        Me.InstanceCombo.Name = "InstanceCombo"
        Me.InstanceCombo.QueryInfoOnDropDown = True
        Me.InstanceCombo.Size = New System.Drawing.Size(185, 21)
        Me.InstanceCombo.TabIndex = 2
        '
        'lblServerInstances
        '
        Me.lblServerInstances.AutoSize = True
        Me.lblServerInstances.Location = New System.Drawing.Point(6, 25)
        Me.lblServerInstances.Name = "lblServerInstances"
        Me.lblServerInstances.Size = New System.Drawing.Size(114, 13)
        Me.lblServerInstances.TabIndex = 1
        Me.lblServerInstances.Text = "SQL Server-Instanzen:"
        '
        'ADSQLServerConnector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbMain)
        Me.MaximumSize = New System.Drawing.Size(0, 195)
        Me.MinimumSize = New System.Drawing.Size(317, 195)
        Me.Name = "ADSQLServerConnector"
        Me.Size = New System.Drawing.Size(317, 195)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents optUseMixedMode As System.Windows.Forms.RadioButton
    Friend WithEvents optUseIntegratedSecurity As System.Windows.Forms.RadioButton
    Friend WithEvents InstanceCombo As Activedev.SqlSupport.ADSqlInstanceInfoComboBox
    Friend WithEvents lblServerInstances As System.Windows.Forms.Label
    Friend WithEvents chkUseSXDefaultInstance As System.Windows.Forms.CheckBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents lblUserID As System.Windows.Forms.Label

End Class
