Imports System.IO

Public Class Adresse

    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Nachname As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Nachname = Nachname
        Me.Vorname = Vorname
        Me.Straﬂe = Straﬂe
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = My.User.Name
    End Sub

    'Alle ˆffentlichen Felder in die Datei schreiben
    Public Shared Sub SerializeToFile(ByVal adr As Adresse, ByVal Filename As String)
        Dim locStreamWriter As New StreamWriter(Filename, False, System.Text.Encoding.Default)
        With locStreamWriter
            .WriteLine(adr.Vorname)
            .WriteLine(adr.Nachname)
            .WriteLine(adr.Straﬂe)
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

    Public Property Nachname() As String
    Public Property Vorname() As String
    Public Property Straﬂe() As String
    Public Property PLZOrt() As String

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


End Class
