<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADSqlDatabaseConnector
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
        Me.gbDatabase = New System.Windows.Forms.GroupBox
        Me.lblLogicalName = New System.Windows.Forms.Label
        Me.txtLogicalDatabaseName = New System.Windows.Forms.TextBox
        Me.lblFileToAttach = New System.Windows.Forms.Label
        Me.btnFileSelector = New System.Windows.Forms.Button
        Me.txtFileToAttach = New System.Windows.Forms.TextBox
        Me.optAttachDatabase = New System.Windows.Forms.RadioButton
        Me.optUseDatabasesOfInstance = New System.Windows.Forms.RadioButton
        Me.lblDatabase = New System.Windows.Forms.Label
        Me.SqlDatabases = New Activedev.SqlSupport.ADSqlDatabasesInfoComboBox
        Me.gbDatabase.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatabase
        '
        Me.gbDatabase.Controls.Add(Me.lblLogicalName)
        Me.gbDatabase.Controls.Add(Me.txtLogicalDatabaseName)
        Me.gbDatabase.Controls.Add(Me.lblFileToAttach)
        Me.gbDatabase.Controls.Add(Me.btnFileSelector)
        Me.gbDatabase.Controls.Add(Me.txtFileToAttach)
        Me.gbDatabase.Controls.Add(Me.optAttachDatabase)
        Me.gbDatabase.Controls.Add(Me.optUseDatabasesOfInstance)
        Me.gbDatabase.Controls.Add(Me.lblDatabase)
        Me.gbDatabase.Controls.Add(Me.SqlDatabases)
        Me.gbDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbDatabase.Location = New System.Drawing.Point(0, 0)
        Me.gbDatabase.Name = "gbDatabase"
        Me.gbDatabase.Size = New System.Drawing.Size(269, 162)
        Me.gbDatabase.TabIndex = 0
        Me.gbDatabase.TabStop = False
        Me.gbDatabase.Text = "Auswahl der SQL-Datenbank:"
        '
        'lblLogicalName
        '
        Me.lblLogicalName.AutoSize = True
        Me.lblLogicalName.Location = New System.Drawing.Point(6, 135)
        Me.lblLogicalName.Name = "lblLogicalName"
        Me.lblLogicalName.Size = New System.Drawing.Size(87, 13)
        Me.lblLogicalName.TabIndex = 7
        Me.lblLogicalName.Text = "Logischer Name:"
        '
        'txtLogicalDatabaseName
        '
        Me.txtLogicalDatabaseName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLogicalDatabaseName.Location = New System.Drawing.Point(96, 132)
        Me.txtLogicalDatabaseName.Name = "txtLogicalDatabaseName"
        Me.txtLogicalDatabaseName.Size = New System.Drawing.Size(163, 20)
        Me.txtLogicalDatabaseName.TabIndex = 8
        '
        'lblFileToAttach
        '
        Me.lblFileToAttach.AutoSize = True
        Me.lblFileToAttach.Location = New System.Drawing.Point(58, 110)
        Me.lblFileToAttach.Name = "lblFileToAttach"
        Me.lblFileToAttach.Size = New System.Drawing.Size(35, 13)
        Me.lblFileToAttach.TabIndex = 4
        Me.lblFileToAttach.Text = "Datei:"
        '
        'btnFileSelector
        '
        Me.btnFileSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFileSelector.Location = New System.Drawing.Point(234, 106)
        Me.btnFileSelector.Name = "btnFileSelector"
        Me.btnFileSelector.Size = New System.Drawing.Size(25, 20)
        Me.btnFileSelector.TabIndex = 6
        Me.btnFileSelector.Text = "..."
        Me.btnFileSelector.UseVisualStyleBackColor = True
        '
        'txtFileToAttach
        '
        Me.txtFileToAttach.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileToAttach.Location = New System.Drawing.Point(96, 106)
        Me.txtFileToAttach.Name = "txtFileToAttach"
        Me.txtFileToAttach.Size = New System.Drawing.Size(137, 20)
        Me.txtFileToAttach.TabIndex = 5
        '
        'optAttachDatabase
        '
        Me.optAttachDatabase.AutoSize = True
        Me.optAttachDatabase.Location = New System.Drawing.Point(6, 85)
        Me.optAttachDatabase.Name = "optAttachDatabase"
        Me.optAttachDatabase.Size = New System.Drawing.Size(155, 17)
        Me.optAttachDatabase.TabIndex = 3
        Me.optAttachDatabase.Text = "Datenbankdatei anhängen:"
        Me.optAttachDatabase.UseVisualStyleBackColor = True
        '
        'optUseDatabasesOfInstance
        '
        Me.optUseDatabasesOfInstance.AutoSize = True
        Me.optUseDatabasesOfInstance.Checked = True
        Me.optUseDatabasesOfInstance.Location = New System.Drawing.Point(6, 24)
        Me.optUseDatabasesOfInstance.Name = "optUseDatabasesOfInstance"
        Me.optUseDatabasesOfInstance.Size = New System.Drawing.Size(261, 17)
        Me.optUseDatabasesOfInstance.TabIndex = 0
        Me.optUseDatabasesOfInstance.TabStop = True
        Me.optUseDatabasesOfInstance.Text = "In der Instanz vorhandene Datenbank verwenden"
        Me.optUseDatabasesOfInstance.UseVisualStyleBackColor = True
        '
        'lblDatabase
        '
        Me.lblDatabase.AutoSize = True
        Me.lblDatabase.Location = New System.Drawing.Point(30, 52)
        Me.lblDatabase.Name = "lblDatabase"
        Me.lblDatabase.Size = New System.Drawing.Size(63, 13)
        Me.lblDatabase.TabIndex = 1
        Me.lblDatabase.Text = "Datenbank:"
        '
        'SqlDatabases
        '
        Me.SqlDatabases.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SqlDatabases.CredentialMethod = Activedev.SqlSupport.SqlCredentialMethods.WindowsIntegratedSecurity
        Me.SqlDatabases.CredentialParameters = Nothing
        Me.SqlDatabases.FormattingEnabled = True
        Me.SqlDatabases.Location = New System.Drawing.Point(96, 49)
        Me.SqlDatabases.Name = "SqlDatabases"
        Me.SqlDatabases.QueryInfoOnDropDown = True
        Me.SqlDatabases.Size = New System.Drawing.Size(163, 21)
        Me.SqlDatabases.SqlInstance = Nothing
        Me.SqlDatabases.TabIndex = 2
        '
        'ADSqlDatabaseConnector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gbDatabase)
        Me.MaximumSize = New System.Drawing.Size(0, 162)
        Me.MinimumSize = New System.Drawing.Size(269, 162)
        Me.Name = "ADSqlDatabaseConnector"
        Me.Size = New System.Drawing.Size(269, 162)
        Me.gbDatabase.ResumeLayout(False)
        Me.gbDatabase.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatabase As System.Windows.Forms.GroupBox
    Friend WithEvents lblLogicalName As System.Windows.Forms.Label
    Friend WithEvents txtLogicalDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents lblFileToAttach As System.Windows.Forms.Label
    Friend WithEvents btnFileSelector As System.Windows.Forms.Button
    Friend WithEvents txtFileToAttach As System.Windows.Forms.TextBox
    Friend WithEvents optAttachDatabase As System.Windows.Forms.RadioButton
    Friend WithEvents optUseDatabasesOfInstance As System.Windows.Forms.RadioButton
    Friend WithEvents lblDatabase As System.Windows.Forms.Label
    Friend WithEvents SqlDatabases As Activedev.SqlSupport.ADSqlDatabasesInfoComboBox

End Class
