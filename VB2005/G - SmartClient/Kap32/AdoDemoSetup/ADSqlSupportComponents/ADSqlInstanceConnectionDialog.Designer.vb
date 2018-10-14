<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADSqlInstanceConnectionDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnTestConnection = New System.Windows.Forms.Button
        Me.txtLoginString = New System.Windows.Forms.TextBox
        Me.SqlServerConnector = New ActiveDev.SqlSupport.ADSQLServerConnector
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(139, 265)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(92, 30)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(237, 265)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(92, 30)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnTestConnection.Location = New System.Drawing.Point(12, 265)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(110, 30)
        Me.btnTestConnection.TabIndex = 3
        Me.btnTestConnection.Text = "Verbindung testen"
        Me.btnTestConnection.UseVisualStyleBackColor = True
        '
        'txtLoginString
        '
        Me.txtLoginString.Location = New System.Drawing.Point(12, 213)
        Me.txtLoginString.Multiline = True
        Me.txtLoginString.Name = "txtLoginString"
        Me.txtLoginString.Size = New System.Drawing.Size(317, 45)
        Me.txtLoginString.TabIndex = 6
        Me.txtLoginString.Text = "Server="
        '
        'SqlServerConnector
        '
        Me.SqlServerConnector.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlServerConnector.CredentialMethod = ActiveDev.SqlSupport.SqlCredentialMethods.WindowsIntegratedSecurity
        Me.SqlServerConnector.Location = New System.Drawing.Point(12, 12)
        Me.SqlServerConnector.MaximumSize = New System.Drawing.Size(0, 195)
        Me.SqlServerConnector.MinimumSize = New System.Drawing.Size(317, 195)
        Me.SqlServerConnector.Name = "SqlServerConnector"
        Me.SqlServerConnector.Size = New System.Drawing.Size(317, 195)
        Me.SqlServerConnector.TabIndex = 0
        '
        'ADSqlInstanceConnectionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 307)
        Me.Controls.Add(Me.txtLoginString)
        Me.Controls.Add(Me.btnTestConnection)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.SqlServerConnector)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ADSqlInstanceConnectionDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQL Server-Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SqlServerConnector As Activedev.SqlSupport.ADSQLServerConnector
    Protected Friend WithEvents btnOK As System.Windows.Forms.Button
    Protected Friend WithEvents btnCancel As System.Windows.Forms.Button
    Protected Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Protected Friend WithEvents txtLoginString As System.Windows.Forms.TextBox
End Class
