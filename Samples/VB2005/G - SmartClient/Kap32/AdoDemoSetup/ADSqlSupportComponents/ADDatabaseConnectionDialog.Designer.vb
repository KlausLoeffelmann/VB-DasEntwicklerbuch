<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADDatabaseConnectionDialog
    Inherits SqlSupport.ADSqlInstanceConnectionDialog

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
        Me.SqlDatabaseConnector = New ActiveDev.SqlSupport.ADSqlDatabaseConnector
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(139, 433)
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(237, 433)
        '
        'btnTestConnection
        '
        Me.btnTestConnection.Location = New System.Drawing.Point(12, 433)
        '
        'txtLoginString
        '
        Me.txtLoginString.Location = New System.Drawing.Point(12, 381)
        '
        'SqlDatabaseConnector
        '
        Me.SqlDatabaseConnector.CredentialMethod = ActiveDev.SqlSupport.SqlCredentialMethods.WindowsIntegratedSecurity
        Me.SqlDatabaseConnector.CredentialParameters = Nothing
        Me.SqlDatabaseConnector.DatabaseSource = ActiveDev.SqlSupport.SqlDatabaseSource.FromSqlServerInstance
        Me.SqlDatabaseConnector.FileToAttach = ""
        Me.SqlDatabaseConnector.Location = New System.Drawing.Point(12, 213)
        Me.SqlDatabaseConnector.LogicalDatabasename = ""
        Me.SqlDatabaseConnector.MaximumSize = New System.Drawing.Size(0, 162)
        Me.SqlDatabaseConnector.MinimumSize = New System.Drawing.Size(317, 162)
        Me.SqlDatabaseConnector.Name = "SqlDatabaseConnector"
        Me.SqlDatabaseConnector.Size = New System.Drawing.Size(317, 162)
        Me.SqlDatabaseConnector.SqlInstance = Nothing
        Me.SqlDatabaseConnector.TabIndex = 4
        '
        'ADDatabaseConnectionDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(337, 475)
        Me.Controls.Add(Me.SqlDatabaseConnector)
        Me.Name = "ADDatabaseConnectionDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Controls.SetChildIndex(Me.txtLoginString, 0)
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnTestConnection, 0)
        Me.Controls.SetChildIndex(Me.SqlDatabaseConnector, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SqlDatabaseConnector As Activedev.SqlSupport.ADSqlDatabaseConnector

End Class
