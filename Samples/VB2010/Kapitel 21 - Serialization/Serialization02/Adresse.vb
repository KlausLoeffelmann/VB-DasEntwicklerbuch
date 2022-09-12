Imports System.IO

<Serializable()> _
Public Class Adresse

    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Nachname As String, ByVal Straﬂe As String,
            ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Nachname = Nachname
        Me.Vorname = Vorname
        Me.Straﬂe = Straﬂe
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = My.User.Name
    End Sub

    'Alle ÷ffentlichen Felder in die Datei schreiben - Soap-Format
    Public Shared Sub SerializeSoapToFile(ByVal adr As Adresse, ByVal Filename As String)
        SoapSerializer.SerializeToFile(New FileInfo(Filename), adr)
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen - Soap-Format
    Public Shared Function SerializeSoapFromFile(ByVal Filename As String) As Adresse
        Return DirectCast(SoapSerializer.DeserializeFromFile(New FileInfo(Filename)), Adresse)
    End Function

    'Alle ÷ffentlichen Felder in die Datei schreiben - Binary-Format
    Public Shared Sub SerializeBinToFile(ByVal adr As Adresse, ByVal Filename As String)
        BinarySerializer.SerializeToFile(New FileInfo(Filename), adr)
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen - Binary-Format
    Public Shared Function SerializeBinFromFile(ByVal Filename As String) As Adresse
        Return DirectCast(BinarySerializer.DeserializeFromFile(New FileInfo(Filename)), Adresse)
    End Function

    Public Property Nachname() As String
    Public Property Vorname() As String
    Public Property Straﬂe() As String
    Public Property PLZOrt() As String

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
