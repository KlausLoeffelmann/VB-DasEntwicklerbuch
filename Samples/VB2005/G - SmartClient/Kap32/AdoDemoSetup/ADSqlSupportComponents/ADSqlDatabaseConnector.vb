Public Class ADSqlDatabaseConnector

    Public Event ParametersChanged(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AssignCheckedStates()
    End Sub

    Private Sub optUseDatabasesOfInstance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUseDatabasesOfInstance.CheckedChanged
        AssignCheckedStates()
        OnParametersChanged()
    End Sub

    Private Sub AssignCheckedStates()
        lblDatabase.Enabled = optUseDatabasesOfInstance.Checked
        SqlDatabases.Enabled = optUseDatabasesOfInstance.Checked
        lblFileToAttach.Enabled = optAttachDatabase.Checked
        txtFileToAttach.Enabled = optAttachDatabase.Checked
        lblLogicalName.Enabled = optAttachDatabase.Checked
        txtLogicalDatabaseName.Enabled = optAttachDatabase.Checked
    End Sub

    Public Property CredentialMethod() As SqlCredentialMethods
        Get
            Return SqlDatabases.CredentialMethod
        End Get
        Set(ByVal value As SqlCredentialMethods)
            SqlDatabases.CredentialMethod = value
        End Set
    End Property

    Public Property CredentialParameters() As SqlMixedModeCredentialParameters
        Get
            Return SqlDatabases.CredentialParameters
        End Get
        Set(ByVal value As SqlMixedModeCredentialParameters)
            SqlDatabases.CredentialParameters = value
        End Set
    End Property

    Public Property SqlInstance() As SqlInstanceItem
        Get
            Return SqlDatabases.SqlInstance
        End Get
        Set(ByVal value As SqlInstanceItem)
            SqlDatabases.SqlInstance = value
        End Set
    End Property

    Private Sub btnFileSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileSelector.Click
        Dim locOfd As New OpenFileDialog()
        With locOfd
            .CheckFileExists = True
            .CheckPathExists = True
            .Filter = "SQL Server-Dateien (*.mdf)|*.mdf|Alle Dateien (*.*)|*.*"
            .Title = "SQL-Server-Datenbank öffnen"
            Dim locDr As DialogResult = .ShowDialog
            If locDr = DialogResult.OK Then
                txtFileToAttach.Text = .FileName
            End If
        End With
    End Sub

    Protected Overridable Sub OnParametersChanged()
        RaiseEvent ParametersChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub SqlParameters_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogicalDatabaseName.TextChanged, txtFileToAttach.TextChanged, SqlDatabases.TextChanged
        OnParametersChanged()
    End Sub

    Public Overrides Property Text() As String
        Get
            Return SqlDatabases.Text
        End Get
        Set(ByVal value As String)
            SqlDatabases.Text = value
        End Set
    End Property

    Public Property DatabaseSource() As SqlDatabaseSource
        Get
            If optAttachDatabase.Checked Then
                Return SqlDatabaseSource.FromFile
            Else
                Return SqlDatabaseSource.FromSqlServerInstance
            End If
        End Get
        Set(ByVal value As SqlDatabaseSource)
            If value = SqlDatabaseSource.FromFile Then
                optAttachDatabase.Checked = True
            Else
                optUseDatabasesOfInstance.Checked = True
            End If
        End Set
    End Property

    Public Property FileToAttach() As String
        Get
            Return txtFileToAttach.Text
        End Get
        Set(ByVal value As String)
            txtFileToAttach.Text = value
        End Set
    End Property

    Public Property LogicalDatabasename() As String
        Get
            Return txtLogicalDatabaseName.Text
        End Get
        Set(ByVal value As String)
            txtLogicalDatabaseName.Text = value
        End Set
    End Property
End Class
