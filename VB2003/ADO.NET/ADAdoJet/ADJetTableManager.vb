Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.OleDb
Imports ActiveDev
Imports System.Windows.Forms

Public Enum ADCreateIndexEnum
    CreateNone
    'Gegenstand stundenlanger Diskussionen: 
    'Ambiguous?, Simple?, NonUnique?, Redundant? : Vorschläge an klaus@loeffelmann.de
    CreateAmbiguous
    CreateUnique
End Enum

Public Class ADTypeNotSupportedException
    Inherits Exception

    Sub New()
    End Sub

    Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class

Public Class ADTableInfo

    Private myTablename As String
    Private myCreatePrimaryKey As Boolean
    Private myPrimaryKey As String

    Sub New()
        myTablename = Nothing
        myCreatePrimaryKey = False
        myPrimaryKey = Nothing
    End Sub

    Sub New(ByVal Tablename As String, ByVal CreatePrimaryKey As Boolean, ByVal PrimaryKey As String)
        myTablename = Tablename
        myCreatePrimaryKey = CreatePrimaryKey
        myPrimaryKey = PrimaryKey
    End Sub

    Public Property TableName() As String
        Get
            Return myTablename
        End Get
        Set(ByVal Value As String)
            myTablename = Value
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

Public Class ADFieldInfo

    Private myFieldName As String
    Private myDataType As OleDbType
    Private myLength As Integer
    Private myCreateIndex As ADCreateIndexEnum

    Sub New()
        myFieldName = Nothing
        myDataType = OleDbType.Empty
        myLength = -1
        myCreateIndex = ADCreateIndexEnum.CreateNone
    End Sub

    Sub New(ByVal Fieldname As String, ByVal DataType As OleDbType)
        myFieldName = Fieldname
        myDataType = DataType
        myLength = -1
    End Sub

    Sub New(ByVal Fieldname As String, ByVal DataType As OleDbType, ByVal Length As Integer)
        myFieldName = Fieldname
        myDataType = DataType
        myLength = Length
    End Sub

    Sub New(ByVal Fieldname As String, ByVal DataType As OleDbType, ByVal Length As Integer, ByVal CreateIndex As ADCreateIndexEnum)
        myFieldName = Fieldname
        myDataType = DataType
        myLength = Length
        myCreateIndex = CreateIndex
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

    Public Property DataType() As OleDbType
        Get
            Return myDataType
        End Get
        Set(ByVal Value As OleDbType)
            myDataType = Value
        End Set
    End Property

    Public Property CreateWithIndex() As ADCreateIndexEnum
        Get
            Return myCreateIndex
        End Get
        Set(ByVal Value As ADCreateIndexEnum)
            myCreateIndex = Value
        End Set
    End Property
End Class

Public Class ADJetTableUpdater

    Private Shared myFormProgress As frmProgress
    Private Shared myTablesToUpdate As Integer

    Public Shared Sub UpdateDatabase(ByVal Database As OleDbConnection, ByVal AssemblyContainingDBInfo As [Assembly], ByVal ShowProgress As Boolean)

        If ShowProgress Then
            myFormProgress = New frmProgress
            myFormProgress.Show()
            myFormProgress.Refresh()
        End If

        'Rausfinden, wieviele Tabellen es gibt
        myTablesToUpdate = 0
        For Each locType As Type In AssemblyContainingDBInfo.GetTypes()
            For Each locAttribute As Attribute In locType.GetCustomAttributes(True)
                If TypeOf locAttribute Is ActiveDev.ReflectsJetTableAttribute Then
                    Trace.WriteLine("ADJetTableUpdate.UpdateDatabase: Found Class " + locType.FullName + " for Updating Table")
                    myTablesToUpdate += 1
                End If
            Next
        Next

        If Not (myFormProgress Is Nothing) Then
            myFormProgress.pgbTables.Maximum = myTablesToUpdate
        End If

        'Tabellen updaten
        Try
            For Each locType As Type In AssemblyContainingDBInfo.GetTypes()
                For Each locAttribute As Attribute In locType.GetCustomAttributes(True)
                    If TypeOf locAttribute Is ActiveDev.ReflectsJetTableAttribute Then
                        myFormProgress.pgbTables.Value += 1
                        myFormProgress.pgbTables.Refresh()
                        UpdateDatabase(Database, locType)
                    End If
                Next
            Next
        Catch ex As Exception
            'Fehler nur Abfangen, um Formular schließen zu können
            If Not (myFormProgress Is Nothing) Then
                myFormProgress.Dispose()
                Throw ex
            End If
        End Try

        'Formular schließen
        If Not (myFormProgress Is Nothing) Then
            myFormProgress.Dispose()
        End If

    End Sub

    Public Shared Sub UpdateDatabase(ByVal Connection As OleDbConnection, ByVal ClassContainingDBInfo As Type)

        Dim locTableInfo As ADTableInfo
        Dim locFieldInfo As ADFieldInfo
        Dim locTableDidntExist As Boolean

        'Tabellenname für Typ ermitteln
        locTableInfo = GetTableInfo(ClassContainingDBInfo)

        If Not locTableInfo Is Nothing Then
            If Not (myFormProgress Is Nothing) Then
                myFormProgress.lblUpdateMessage.Text = "Updating Tabelle: " + locTableInfo.TableName
                myFormProgress.lblUpdateMessage.Refresh()
            End If

            'Tabelle erstellen, falls sie nicht existiert
            If Not ADAdoJet.TableExist(Connection, locTableInfo.TableName) Then
                ADAdoJet.CreateTable(Connection, locTableInfo)
                'damit die Feldprüfungen entfallen können...
                locTableDidntExist = True
            End If

            'Iterieren durch Eigenschaften der Klasse um betroffene Feldnamen zu finden
            For Each locPropertyInfo As PropertyInfo In ClassContainingDBInfo.GetProperties
                For Each locAttribute As Attribute In Attribute.GetCustomAttributes(locPropertyInfo)
                    If TypeOf locAttribute Is ActiveDev.ReflectsJetTableFieldAttribute Then
                        Trace.WriteLine("ADJetTableUpdate.UpdateDatabase: Found Field" + locPropertyInfo.Name + " for Updating Table")
                        locFieldInfo = GetFieldInfo(locPropertyInfo)
                        If locTableDidntExist Then
                            'Falls es die Tabelle nicht gab, kann es auch das Feld nicht geben
                            ADAdoJet.CreateField(Connection, locTableInfo.TableName, locFieldInfo)
                        Else
                            'anderenfalls: Nachschauen
                            If Not ADAdoJet.FieldExist(Connection, locTableInfo.TableName, locFieldInfo.FieldName) Then
                                ADAdoJet.CreateField(Connection, locTableInfo.TableName, locFieldInfo)
                            End If

                        End If

                    End If
                Next
            Next
        End If
    End Sub

    Private Shared Function GetTableInfo(ByVal [Type] As Type) As ADTableInfo

        Dim locTableInfo As New ADTableInfo

        With locTableInfo
            For Each locAttribute As Attribute In [Type].GetCustomAttributes(True)
                If TypeOf locAttribute Is ActiveDev.ReflectsJetTableAttribute Then
                    .TableName = DirectCast(locAttribute, ReflectsJetTableAttribute).TableName
                    .PrimaryKey = DirectCast(locAttribute, ReflectsJetTableAttribute).PrimaryKey
                    .CreatePrimaryKey = DirectCast(locAttribute, ReflectsJetTableAttribute).CreatePrimaryKey

                    If .TableName Is Nothing Then
                        .TableName = [Type].Name
                        If .CreatePrimaryKey = True Then
                            .PrimaryKey = "ID" + [Type].Name
                        End If
                    End If
                    Return locTableInfo
                End If
            Next
        End With
    End Function

    Private Shared Function GetFieldInfo(ByVal [Property] As PropertyInfo) As ADFieldInfo

        Dim locFieldInfo As New ADFieldInfo

        'Sicherstellen, dass Attribute für die Eigenschaft definiert ist
        Dim locAttribute As Attribute = Attribute.GetCustomAttribute([Property], GetType(ReflectsJetTableFieldAttribute))
        If locAttribute Is Nothing Then
            Return Nothing
        End If

        With locFieldInfo

            'Attributvorgaben in die CreateFieldInfo-Instanz übernehmen
            .FieldName = DirectCast(locAttribute, ReflectsJetTableFieldAttribute).FieldName
            .FieldLength = DirectCast(locAttribute, ReflectsJetTableFieldAttribute).FieldLength
            .DataType = DirectCast(locAttribute, ReflectsJetTableFieldAttribute).DifferingDataType
            .CreateWithIndex = ADCreateIndexEnum.CreateNone

            'Indexeinstellungen, falls vorhanden, ebenfalls übernehmen
            locAttribute = Attribute.GetCustomAttribute([Property], GetType(JetTableFieldIndex))
            If Not (locAttribute Is Nothing) Then
                .CreateWithIndex = DirectCast(locAttribute, JetTableFieldIndex).CreateIndex
            End If

            'Falls der Feldname nicht durch das Attribut definiert wurde,
            'ergibt er sich aus der Eigenschaft
            If .FieldName Is Nothing Then
                .FieldName = [Property].Name
            End If

            'Wenn kein Typ explizit definiert ist, dann vom Eigenschaftentyp ableiten
            If .DataType = OleDbType.Empty Then
                If [Property].GetType Is GetType(Byte) Then
                    .DataType = OleDbType.TinyInt
                ElseIf [Property].GetType Is GetType(Integer) Then
                    .DataType = OleDbType.Integer
                ElseIf [Property].GetType Is GetType(Single) Then
                    .DataType = OleDbType.Single
                ElseIf [Property].GetType Is GetType(Double) Then
                    .DataType = OleDbType.Double
                ElseIf [Property].GetType Is GetType(Decimal) Then
                    .DataType = OleDbType.Decimal
                ElseIf [Property].GetType Is GetType(Date) Then
                    .DataType = OleDbType.Date
                ElseIf [Property].GetType Is GetType(Boolean) Then
                    .DataType = OleDbType.Boolean
                ElseIf [Property].GetType Is GetType(String) Then
                    If .FieldLength < 256 Then
                        .DataType = OleDbType.VarChar
                    Else
                        .DataType = OleDbType.VarWChar
                    End If
                Else
                    Dim up As New ADTypeNotSupportedException("Der ermittelte Typ wird von ADJetTableUpdater nicht unterstützt!")
                    Throw up
                End If
            End If
            Return locFieldInfo
        End With
    End Function
End Class

