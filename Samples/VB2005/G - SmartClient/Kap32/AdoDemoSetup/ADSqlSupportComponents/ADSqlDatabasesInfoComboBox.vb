Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Public Class ADSqlDatabasesInfoComboBox
    Inherits ADSqlInfoComboBase

    Private mySqlDatabases As SqlDatabaseItems
    Private mySqlInstance As SqlInstanceItem
    Private mySqlCredentialMethod As SqlCredentialMethods
    Private mySqlCredentialParameters As SqlMixedModeCredentialParameters

    Protected Overrides Sub PopulateItemsInternal()

        Dim locSqlDatabasesDataTable As DataTable = Nothing

        MyBase.PopulateItemsInternal()

        If Connection Is Nothing Then
            Return
        End If

        If mySqlDatabases Is Nothing Then
            Try
                Dim locSqlConnection As New System.Data.SqlClient.SqlConnection()
                Using locSqlConnection
                    locSqlConnection.ConnectionString = Connection.ToString
                    locSqlConnection.Open()
                    locSqlDatabasesDataTable = locSqlConnection.GetSchema("Databases")
                    locSqlConnection.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Bei der Verbindungsherstellung zur ausgewählten" & vbNewLine & _
                                "SQL-Server-Instanz trat ein Fehler auf:" & vbNewLine & vbNewLine & _
                                ex.Message, "Fehler bei Verbindungsherstellung:", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If
        If locSqlDatabasesDataTable IsNot Nothing _
                AndAlso locSqlDatabasesDataTable.Rows.Count > 0 _
                AndAlso Me.Items.Count = 0 Then
            mySqlDatabases = New SqlDatabaseItems()
            For Each locDataRow As DataRow In locSqlDatabasesDataTable.Rows
                Dim locSqlDatabase As New SqlDatabaseItem( _
                                        CStr(locDataRow("database_name")), _
                                        CInt(locDataRow("dbid")), _
                                        CDate(locDataRow("create_date")))
                Me.Items.Add(locSqlDatabase)
                mySqlDatabases.Add(locSqlDatabase)
            Next
        End If
    End Sub

    Public ReadOnly Property Connection() As SqlClient.SqlConnectionStringBuilder
        Get
            If SqlInstance Is Nothing Then
                Dim locEx As New ADSqlConnectionBuilderException("Connection-String kann ohne Sql-Server-Instanz nicht erstellt werden. Setzen Sie zunächst die SqlInstance-Eigenschaft. Verwenden Sie im Bedarfsfall die statische Funktion 'SqlInstanceFromString' dieser Klasse.")
                Throw locEx
            End If

            If CredentialMethod = SqlCredentialMethods.MixedMode And _
               CredentialParameters Is Nothing Then
                Dim locEx As New ADSqlConnectionBuilderException("Connection-String benötigt bei MixedMode-Authentifizierung ein instanziertes SqlMixedModeCredentialParameters-Objekt.")
                Throw locEx
            End If

            Dim locConnBuilder As New SqlConnectionStringBuilder()
            locConnBuilder.DataSource = SqlInstance.ToString
            If CredentialMethod = SqlCredentialMethods.WindowsIntegratedSecurity Then
                locConnBuilder.IntegratedSecurity = True
            Else
                locConnBuilder.IntegratedSecurity = False
                locConnBuilder.UserID = CredentialParameters.UserID
                locConnBuilder.Password = CredentialParameters.Password
            End If
            Return locConnBuilder
        End Get
    End Property

    Public Property CredentialMethod() As SqlCredentialMethods
        Get
            Return mySqlCredentialMethod
        End Get
        Set(ByVal value As SqlCredentialMethods)
            mySqlCredentialMethod = value
            ResetDatabases()
        End Set
    End Property

    Public Property CredentialParameters() As SqlMixedModeCredentialParameters
        Get
            Return mySqlCredentialParameters
        End Get
        Set(ByVal value As SqlMixedModeCredentialParameters)
            mySqlCredentialParameters = value
            ResetDatabases()
        End Set
    End Property

    Public Property SqlInstance() As SqlInstanceItem
        Get
            Return mySqlInstance
        End Get
        Set(ByVal value As SqlInstanceItem)
            mySqlInstance = value
            ResetDatabases()
        End Set
    End Property

    Public Shared Function SqlInstanceFromString(ByVal InstancePath As String) As SqlInstanceItem
        If InstancePath Is Nothing Then
            Return Nothing
        End If

        Dim locStr As String = InstancePath.Replace("\\", "")
        locStr = locStr.Replace("//", "")
        locStr = locStr.Replace("/", "\")
        If locStr.IndexOf("\"c) > -1 Then
            Dim locStrArr() As String = locStr.Split("\"c)
            Return New SqlInstanceItem(locStrArr(0), locStrArr(1), False, "Unknown")
        Else
            Return New SqlInstanceItem(locStr, Nothing, False, "Unknown")
        End If
    End Function

    Public Sub ResetDatabases()
        Me.Items.Clear()
        Me.Text = ""
        mySqlDatabases = Nothing
    End Sub
End Class

Public Class SqlDatabaseItems
    Inherits System.Collections.ObjectModel.Collection(Of SqlDatabaseItem)
End Class

Public Class SqlDatabaseItem

    Private myDatabase As String
    Private myDbId As Integer
    Private myCreateDate As Date

    Friend Sub New(ByVal DatabaseName As String, ByVal InstanceName As Integer, ByVal IsClustered As Date)
        myDatabase = DatabaseName
        myDbId = InstanceName
        myCreateDate = IsClustered
    End Sub

    Public ReadOnly Property DatabaseName() As String
        Get
            Return myDatabase
        End Get
    End Property

    Public ReadOnly Property DbId() As Integer
        Get
            Return myDbId
        End Get
    End Property

    Public ReadOnly Property CreateDate() As Date
        Get
            Return myCreateDate
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return DatabaseName
    End Function
End Class

