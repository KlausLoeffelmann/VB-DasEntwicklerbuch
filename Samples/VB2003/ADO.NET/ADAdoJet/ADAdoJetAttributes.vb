Imports System.Data
Imports System.Data.OleDb

<AttributeUsage(AttributeTargets.Class)> _
Public Class ReflectsJetTableAttribute
    Inherits System.Attribute

    Private myTableName As String
    Private myPrimaryKey As String
    Private myCreatePrimaryKey As Boolean

    Sub New()
        myTableName = Nothing
        myPrimaryKey = Nothing
        myCreatePrimaryKey = True
    End Sub

    Sub New(ByVal TableName As String)
        myTableName = TableName
        myPrimaryKey = Nothing
        myCreatePrimaryKey = True
    End Sub

    Sub New(ByVal IsPrimaryKey As Boolean)
        myTableName = TableName
        myPrimaryKey = Nothing
        myCreatePrimaryKey = IsPrimaryKey
    End Sub

    Sub New(ByVal TableName As String, ByVal IsPrimaryKey As Boolean)
        myTableName = TableName
        If IsPrimaryKey Then
            myPrimaryKey = "ID" + TableName
        Else
            myPrimaryKey = Nothing
        End If
        myCreatePrimaryKey = IsPrimaryKey
    End Sub

    Sub New(ByVal Tablename As String, ByVal PrimaryKey As String)
        myCreatePrimaryKey = True
        myPrimaryKey = PrimaryKey
        myTableName = Tablename
    End Sub

    Public Property TableName() As String
        Get
            Return myTableName
        End Get
        Set(ByVal Value As String)
            myTableName = Value
        End Set
    End Property

    Public Property PrimaryKey() As String
        Get
            Return myPrimaryKey
        End Get
        Set(ByVal Value As String)
            myPrimaryKey = Value
        End Set
    End Property

    Public Property CreatePrimaryKey() As Boolean
        Get
            Return myCreatePrimaryKey
        End Get
        Set(ByVal Value As Boolean)
            myCreatePrimaryKey = Value
        End Set
    End Property
End Class

<AttributeUsage(AttributeTargets.Property)> _
Public Class ReflectsJetTableFieldAttribute
    Inherits System.Attribute

    Private myFieldName As String
    Private myDifferingDataType As OleDbType
    Private myLength As Integer

    Sub New()
        myFieldName = Nothing
        myDifferingDataType = OleDbType.Empty
        myLength = -1
    End Sub

    Sub New(ByVal FieldName As String)
        myFieldName = FieldName
        myDifferingDataType = OleDbType.Empty
        myLength = -1
    End Sub

    Sub New(ByVal DifferingDataType As OleDb.OleDbType)
        myDifferingDataType = DifferingDataType
        myLength = -1
        myFieldName = Nothing
    End Sub

    Sub New(ByVal DifferingDataType As OleDb.OleDbType, ByVal Length As Integer)
        myDifferingDataType = DifferingDataType
        myLength = Length
        myFieldName = Nothing
    End Sub

    Sub New(ByVal FieldName As String, ByVal DifferingDataType As OleDb.OleDbType)
        myDifferingDataType = DifferingDataType
        myLength = -1
        myFieldName = FieldName
    End Sub

    Sub New(ByVal FieldName As String, ByVal DifferingDataType As OleDb.OleDbType, ByVal Length As Integer)
        myDifferingDataType = DifferingDataType
        myLength = Length
        myFieldName = FieldName
    End Sub

    Public Property FieldName() As String
        Get
            Return myFieldName
        End Get
        Set(ByVal Value As String)
            myFieldName = Value
        End Set
    End Property

    Public Property FieldLength() As Integer
        Get
            Return myLength
        End Get
        Set(ByVal Value As Integer)
            myLength = Value
        End Set
    End Property

    Public Property DifferingDataType() As OleDbType
        Get
            Return myDifferingDataType
        End Get
        Set(ByVal Value As OleDbType)
            myDifferingDataType = Value
        End Set
    End Property
End Class

<AttributeUsage(AttributeTargets.Property)> _
Public Class JetTableFieldIndex
    Inherits System.Attribute

    Dim myCreateIndex As ADCreateIndexEnum

    Sub New()
        myCreateIndex = ADCreateIndexEnum.CreateNone
    End Sub

    Sub New(ByVal CreateIndex As ADCreateIndexEnum)
        myCreateIndex = CreateIndex
    End Sub

    Public Property CreateIndex() As ADCreateIndexEnum
        Get
            Return myCreateIndex
        End Get
        Set(ByVal Value As ADCreateIndexEnum)
            myCreateIndex = Value
        End Set
    End Property
End Class
