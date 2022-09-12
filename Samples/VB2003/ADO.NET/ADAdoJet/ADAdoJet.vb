Imports System.IO
Imports System.Reflection
Imports System.Data
Imports System.Data.OleDb

Public Class ADAdoJet

#Region "Statische Funktionen"

    Public Shared Sub CreateDatabase(ByVal Database As FileInfo)
        CreateDatabase(Database, False)
    End Sub

    Public Shared Sub CreateDatabase(ByVal Database As FileInfo, ByVal OverwriteIfExist As Boolean)

        Dim locAssembly As [Assembly]
        Dim locResourceStream As Stream
        Dim locFileStream As FileStream
        Dim locBinWriter As BinaryWriter
        Dim locBinReader As BinaryReader

        If OverwriteIfExist Then
            locFileStream = New FileStream(Database.FullName, FileMode.Create)
        Else
            'Falls die Datei existiert, wird eine IOException ausgelöst
            locFileStream = New FileStream(Database.FullName, FileMode.CreateNew)
        End If

        locAssembly = [Assembly].GetExecutingAssembly
        locResourceStream = locAssembly.GetManifestResourceStream("ActiveDev.template.mdb")
        locBinWriter = New BinaryWriter(locFileStream)
        locBinReader = New BinaryReader(locResourceStream)

        Dim buffer(CInt(locResourceStream.Length - 1)) As Byte

        locBinReader.Read(buffer, 0, CInt(locResourceStream.Length))
        locBinWriter.Write(buffer)

        locBinReader.Close()
        locBinWriter.Flush()
        locBinWriter.Close()

        locResourceStream.Close()
        locFileStream.Close()

    End Sub

    Public Shared Function ExecuteSQLCommand(ByVal Connection As OleDbConnection, ByVal CommandString As String) As Integer

        Dim locCommand As OleDbCommand

        locCommand = New OleDbCommand(CommandString, Connection)
        Return locCommand.ExecuteNonQuery()
    End Function

    Public Shared Sub CreateTable(ByVal Connection As OleDbConnection, ByVal Table As ADTableInfo)
        If Table.CreatePrimaryKey = False Then
            CreateTable(Connection, Table.TableName)
        Else
            CreateTable(Connection, Table.TableName, Table.PrimaryKey)
        End If
    End Sub

    Public Shared Sub CreateTable(ByVal Connection As OleDbConnection, ByVal Tablename As String)
        ExecuteSQLCommand(Connection, "CREATE TABLE [" + Tablename + "]")
    End Sub

    Public Shared Sub CreateTable(ByVal Connection As OleDbConnection, ByVal Tablename As String, ByVal PrimaryKey As String)
        ExecuteSQLCommand(Connection, "CREATE TABLE [" + Tablename + "]")
        ExecuteSQLCommand(Connection, "ALTER TABLE [" + Tablename + "] ADD COLUMN " + PrimaryKey + " AUTOINCREMENT ")
        ExecuteSQLCommand(Connection, "CREATE INDEX PrimKey ON [" + Tablename + "] ([" + PrimaryKey + "]) WITH PRIMARY;")
    End Sub

    Public Shared Sub CreateField(ByVal Connection As OleDbConnection, ByVal Tablename As String, ByVal FieldInfo As ADFieldInfo)

        Dim locIndex As Boolean
        Dim locUnique As Boolean
        Dim locTypeName As String

        If FieldInfo.CreateWithIndex = ADCreateIndexEnum.CreateAmbiguous Then
            locIndex = True
        ElseIf FieldInfo.CreateWithIndex = ADCreateIndexEnum.CreateUnique Then
            locIndex = True
            locUnique = True
        End If

        If FieldInfo.DataType = OleDbType.WChar Then
            locTypeName = "TEXT(" + FieldInfo.FieldLength.ToString + ")"
        Else
            locTypeName = ToJetTypeString(FieldInfo.DataType)
        End If
        CreateField(Connection, Tablename, FieldInfo.FieldName, locTypeName, locIndex, locUnique)

    End Sub

    Public Shared Sub CreateField(ByVal Connection As OleDbConnection, ByVal Tablename As String, ByVal Fieldname As String, ByVal TypeName As String, ByVal Index As Boolean, ByVal Unique As Boolean)
        ExecuteSQLCommand(Connection, "ALTER TABLE [" + Tablename + "] ADD COLUMN [" + Fieldname + "] " + TypeName)
        If Index And (Not Unique) Then
            ExecuteSQLCommand(Connection, "CREATE INDEX [" + Fieldname + "] ON [" + Tablename + "] ([" + Fieldname + "])")
        ElseIf Index And Unique Then
            ExecuteSQLCommand(Connection, "CREATE UNIQUE INDEX [" + Fieldname + "] ON [" + Tablename + "] ([" + Fieldname + "])")
        End If
    End Sub

    Public Shared Function TableExist(ByVal Connection As OleDbConnection, ByVal Tablename As String) As Boolean

        Dim locDr As OleDbDataReader
        Dim locCmd As New OleDbCommand("SELECT * FROM [" + Tablename + "]", Connection)

        Try
            locDr = locCmd.ExecuteReader(CommandBehavior.SingleRow)
            Return True

        Catch ex As Exception
            Return False

        Finally
            If Not (locDr Is Nothing) Then
                locDr.Close()
            End If
        End Try
    End Function

    Public Shared Function FieldExist(ByVal Connection As OleDbConnection, ByVal Tablename As String, ByVal Fieldname As String) As Boolean

        Dim locDR As OleDbDataReader
        Dim locCmd As New OleDbCommand("SELECT * From [" + Tablename + "]", Connection)

        Try
            locDR = locCmd.ExecuteReader(CommandBehavior.SingleRow)
            Dim locObject As Object = locDR(Fieldname)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If Not (locDR Is Nothing) Then
                locDR.Close()
            End If
        End Try

    End Function

    Public Shared Function ToJetTypeString(ByVal dbtype As OleDbType) As String

        Select Case dbtype

            Case OleDbType.Binary, OleDbType.Boolean
                Return "YESNO"

            Case OleDbType.DBDate, OleDbType.DBTime, OleDbType.Date
                Return "DateTime"

            Case OleDbType.Integer
                Return "Long Integer"

            Case OleDbType.SmallInt
                Return "Integer"

            Case OleDbType.WChar
                Return "Text"

            Case OleDbType.VarWChar
                Return "Memo"

            Case OleDbType.LongVarBinary
                Return "OLEObject"

            Case OleDbType.Decimal
                Return "Decimal"

            Case OleDbType.Single
                Return "Single"

            Case OleDbType.Double
                Return "Double"

            Case OleDbType.UnsignedTinyInt
                Return "Byte"

            Case OleDbType.Currency
                Return "Currency"

            Case OleDbType.Guid
                Return "ReplicationID"

            Case Else
                Dim up As New ADTypeNotSupportedException("Der angegebene OleDbType kann nicht in eine Zeichenkette für die Verwendung bei ALTER TABLE unter jet40 konvertiert werden!")
                Throw up
        End Select
    End Function

#End Region

End Class
