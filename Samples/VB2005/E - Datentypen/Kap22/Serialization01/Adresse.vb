Imports System.IO

Public Class Adresse

    Private myName As String
    Private myVorname As String
    Private myStra�e As String
    Private myPLZOrt As String
    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Stra�e As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        myName = Name
        myVorname = Vorname
        myStra�e = Stra�e
        myPLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = My.User.Name
    End Sub

    'Alle �ffentlichen Felder in die Datei schreiben
    Public Shared Sub SerializeToFile(ByVal adr As Adresse, ByVal Filename As String)
        Dim locStreamWriter As New StreamWriter(Filename, False, System.Text.Encoding.Default)
        With locStreamWriter
            .WriteLine(adr.Vorname)
            .WriteLine(adr.Name)
            .WriteLine(adr.Stra�e)
            .WriteLine(adr.PLZOrt)
            .Flush()
            .Close()
        End With
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen
    Public Shared Function SerializeFromFile(ByVal Filename As String) As Adresse
        Dim locStreamReader As New StreamReader(Filename, System.Text.Encoding.Default)
        Dim locAdresse As Adresse
        With locStreamReader
            locAdresse = New Adresse(.ReadLine, .ReadLine, .ReadLine, .ReadLine)
        End With
        locStreamReader.Close()
        Return locAdresse
    End Function

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    'Die beiden folgenden Eigenschaften haben "Nur-Lesen-Status", da auch
    'der Entwickler das Anlegen-Datum nicht manipulieren darf!
    Public ReadOnly Property ErfasstAm() As DateTime
        Get
            Return myErfasstAm
        End Get
    End Property

    Public ReadOnly Property ErfasstVon() As String
        Get
            Return myErfasstVon
        End Get
    End Property

#Region "Die anderen Eigenschaften"

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property Stra�e() As String
        Get
            Return myStra�e
        End Get
        Set(ByVal Value As String)
            myStra�e = Value
        End Set
    End Property

    Public Property PLZOrt() As String
        Get
            Return myPLZOrt
        End Get
        Set(ByVal Value As String)
            myPLZOrt = Value
        End Set
    End Property
#End Region

End Class
