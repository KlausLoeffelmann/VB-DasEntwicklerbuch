Imports System.Data.SqlClient

Public Class ADDatabaseConnectionDialog

    Private myThisControlChangedParameters As Boolean

    Public Property Title() As String
        Get
            Return Me.Text
        End Get
        Set(ByVal value As String)
            Me.Text = value
        End Set
    End Property

    Protected Overrides Sub OnParametersChanged()
        MyBase.OnParametersChanged()
        If Not myThisControlChangedParameters Then
            SqlDatabaseConnector.CredentialMethod = SqlServerConnector.CredentialMethod
            SqlDatabaseConnector.CredentialParameters = SqlServerConnector.CredentialParameters
            SqlDatabaseConnector.SqlInstance = SqlServerConnector.SqlInstance
        End If
        myThisControlChangedParameters = False
    End Sub

    Private Sub SqlDatabaseConnector_ParametersChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SqlDatabaseConnector.ParametersChanged
        myThisControlChangedParameters = True
        OnParametersChanged()
    End Sub

    Protected Overrides Function BuildConnectionBuilder() As System.Data.SqlClient.SqlConnectionStringBuilder
        Dim locBuilder As SqlConnectionStringBuilder = MyBase.BuildConnectionBuilder()
        If SqlDatabaseConnector.DatabaseSource = SqlDatabaseSource.FromFile Then
            locBuilder.AttachDBFilename = SqlDatabaseConnector.FileToAttach
            If SqlDatabaseConnector.LogicalDatabasename <> "" Then
                locBuilder.InitialCatalog = SqlDatabaseConnector.LogicalDatabasename
            End If
        Else
            If SqlDatabaseConnector.Text <> "" Then
                locBuilder.InitialCatalog = SqlDatabaseConnector.Text
            End If
        End If
        Return locBuilder
    End Function
End Class
