Imports System.Windows.Forms
Imports System.Data
Imports System.Data.Common

Public Class ADSqlInstanceInfoComboBox
    Inherits ADSqlInfoComboBase

    Private mySqlInstances As SqlInstanceItems
    Private mySqlInstance As SqlInstanceItem

    Sub New()
        MyBase.New()
        QueryInfoOnDropDown = True
    End Sub

    Protected Overrides Sub PopulateItemsInternal()

        Dim locSqlInstancesDataTable As DataTable = Nothing

        MyBase.PopulateItemsInternal()

        If mySqlInstances Is Nothing Then
            locSqlInstancesDataTable = GetSqlServerInstances()
        End If
        If locSqlInstancesDataTable IsNot Nothing _
                AndAlso locSqlInstancesDataTable.Rows.Count > 0 Then
            mySqlInstances = New SqlInstanceItems()
            For Each locDataRow As DataRow In locSqlInstancesDataTable.Rows
                Dim locSqlInstance As New SqlInstanceItem( _
                    CStr(IIf(locDataRow("ServerName") Is DBNull.Value, _
                                Nothing, locDataRow("ServerName"))), _
                    CStr(IIf(locDataRow("InstanceName") Is DBNull.Value, _
                                Nothing, locDataRow("InstanceName"))), _
                    CBool(IIf(locDataRow("IsClustered").ToString = "No", False, True)), _
                    CStr(IIf(locDataRow("Version") Is DBNull.Value, _
                                Nothing, locDataRow("Version"))) _
                                                        )
                Me.Items.Add(locSqlInstance)
                mySqlInstances.Add(locSqlInstance)
            Next
        End If
    End Sub

    Private Function GetSqlServerInstances() As DataTable

        Dim locDataSourceEnumerator As DbDataSourceEnumerator

        Dim locFactory As DbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient")
        locDataSourceEnumerator = locFactory.CreateDataSourceEnumerator
        Return locDataSourceEnumerator.GetDataSources()
    End Function

    Public ReadOnly Property SqlInstance() As SqlInstanceItem
        Get
            Return ADSqlDatabasesInfoComboBox.SqlInstanceFromString(Me.Text)
        End Get
    End Property

    Public ReadOnly Property SelectedSqlInstance() As SqlInstanceItem
        Get
            If Me.SelectedIndex = -1 Then
                Return Nothing
            End If
            Return DirectCast(Me.SelectedItem, SqlInstanceItem)
        End Get
    End Property
End Class

Public Class SqlInstanceItems
    Inherits System.Collections.ObjectModel.Collection(Of SqlInstanceItem)
End Class

Public Class SqlInstanceItem

    Private myServerName As String
    Private myInstanceName As String
    Private myIsClustered As Boolean
    Private myVersion As String

    Friend Sub New(ByVal ServerName As String, ByVal InstanceName As String, ByVal IsClustered As Boolean, ByVal Version As String)
        myServerName = ServerName
        myInstanceName = InstanceName
        myIsClustered = IsClustered
        myVersion = Version
    End Sub

    Public ReadOnly Property ServerName() As String
        Get
            Return myServerName
        End Get
    End Property

    Public ReadOnly Property InstanceName() As String
        Get
            Return myInstanceName
        End Get
    End Property

    Public ReadOnly Property IsClustered() As Boolean
        Get
            Return myIsClustered
        End Get
    End Property

    Public ReadOnly Property Version() As String
        Get
            Return myVersion
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim locRet As String = ""
        If myServerName IsNot Nothing Then
            locRet &= myServerName
        End If
        If myInstanceName IsNot Nothing Then
            locRet &= "\" & myInstanceName
        End If
        Return locRet
    End Function
End Class
