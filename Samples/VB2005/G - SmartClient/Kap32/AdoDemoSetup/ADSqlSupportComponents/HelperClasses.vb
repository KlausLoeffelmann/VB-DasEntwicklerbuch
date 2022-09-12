Imports System.Data.SqlClient
Imports System.Collections.ObjectModel

Public Enum SqlCredentialMethods
    WindowsIntegratedSecurity
    MixedMode
End Enum

Public Enum SqlDatabaseSource
    FromSqlServerInstance
    FromFile
End Enum

Public Class SqlMixedModeCredentialParameters
    Private myUserID As String
    Private myPassword As String

    Sub New(ByVal Username As String, ByVal Password As String)
        myUserID = Username
        myPassword = Password
    End Sub

    Public Property UserID() As String
        Get
            Return myUserID
        End Get
        Set(ByVal value As String)
            myUserID = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return myPassword
        End Get
        Set(ByVal value As String)
            myPassword = value
        End Set
    End Property

    Public Shared Widening Operator CType(ByVal Combined As String) As SqlMixedModeCredentialParameters
        Dim locSepChars As Char() = New Char() {","c, ";"c, "/"c, "\"c}
        If Combined.IndexOfAny(locSepChars) > -1 Then
            Dim locStrArr() As String = Combined.Split(locSepChars)
            Return New SqlMixedModeCredentialParameters(locStrArr(0), locStrArr(1))
        Else
            Return New SqlMixedModeCredentialParameters(Combined, Nothing)
        End If
    End Operator
End Class

Public Class ADSqlDriveFoldersAndFilesListing

    Public Shared Function GetDrivenames(ByVal ConnectionString As String) As Collection(Of DBDriveItem)
        Dim locConnection As New SqlConnection(ConnectionString)
        Using locConnection
            Try
                locConnection.Open()
                Dim locCommand As New SqlCommand("master.dbo.xp_fixeddrives", locConnection)
                locCommand.CommandType = CommandType.StoredProcedure
                Dim locReader As SqlDataReader = locCommand.ExecuteReader
                If locReader.HasRows Then
                    Dim locItems As New Collection(Of DBDriveItem)
                    Do While locReader.Read
                        Dim locDriveItem As New DBDriveItem(locReader.GetString(0), locReader.GetInt32(1))
                        locItems.Add(locDriveItem)
                    Loop
                    Return locItems
                End If
                Return Nothing

            Catch ex As Exception
                Dim locMessage As String = "Beim Lesen der Laufwerksstruktur auf dem SQL-Server ist ein Fehler aufgetreten!" & _
                    vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & _
                    ex.StackTrace
                MessageBox.Show(locMessage, "Fehler beim SQL Server-Zugriff:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function

    Public Shared Function GetSubfoldersAndFiles(ByVal ConnectionString As String, ByVal BaseDir As String) As Collection(Of DBDirOrFileItem)
        Dim locConnection As New SqlConnection(ConnectionString)
        Using locConnection
            Try
                locConnection.Open()
                Dim locCommand As New SqlCommand("master.dbo.xp_dirtree", locConnection)
                locCommand.Parameters.Add("subdirectory", SqlDbType.NVarChar, 255).Value = BaseDir
                locCommand.Parameters.Add("depth", SqlDbType.Int).Value = 1
                locCommand.Parameters.Add("file", SqlDbType.Int).Value = 1
                locCommand.CommandType = CommandType.StoredProcedure
                Dim locReader As SqlDataReader = locCommand.ExecuteReader
                If locReader.HasRows Then
                    Dim locItems As New Collection(Of DBDirOrFileItem)
                    Do While locReader.Read
                        Dim locItem As New DBDirOrFileItem(locReader.GetString(0), CBool(IIf(locReader.GetInt32(2) = 0, False, True)))
                        locItems.Add(locItem)
                    Loop
                    Return locItems
                End If
                Return Nothing

            Catch ex As Exception
                Dim locMessage As String = "Beim Lesen der Laufwerksstruktur auf dem SQL-Server ist ein Fehler aufgetreten!" & _
                    vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & _
                    ex.StackTrace
                MessageBox.Show(locMessage, "Fehler beim SQL Server-Zugriff:", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Using
    End Function
End Class

Public Class ADSqlConnectionBuilderException
    Inherits ApplicationException

    Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class

Public Structure DBDriveItem
    Private myDriveLetter As String
    Private myFreeSpaceInMb As Integer

    Sub New(ByVal DriveLetter As String, ByVal FreeSpaceInMb As Integer)
        myDriveLetter = DriveLetter
        myFreeSpaceInMb = FreeSpaceInMb
    End Sub

    Public Property DriveLetter() As String
        Get
            Return myDriveLetter
        End Get
        Set(ByVal value As String)
            myDriveLetter = value
        End Set
    End Property

    Public Property FreeSpaceInMb() As Integer
        Get
            Return myFreeSpaceInMb
        End Get
        Set(ByVal value As Integer)
            myFreeSpaceInMb = value
        End Set
    End Property
End Structure

Public Structure DBDirOrFileItem
    Private myName As String
    Private myIsFile As Boolean

    Sub New(ByVal Name As String, ByVal IsFile As Boolean)
        myName = Name
        myIsFile = IsFile
    End Sub

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal value As String)
            myName = value
        End Set
    End Property

    Public Property IsFile() As Boolean
        Get
            Return myIsFile
        End Get
        Set(ByVal value As Boolean)
            myIsFile = value
        End Set
    End Property
End Structure
