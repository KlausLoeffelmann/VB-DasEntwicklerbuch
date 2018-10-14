Imports System.IO

<Serializable()> _
Public Class Adresse

    Private myName As String
    Private myVorname As String
    Private myStraﬂe As String
    Private myPLZOrt As String
    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        myName = Name
        myVorname = Vorname
        myStraﬂe = Straﬂe
        myPLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = My.User.Name
    End Sub

    'Alle ÷ffentlichen Felder in die Datei schreiben - Soap-Format
    Public Shared Sub SerializeSoapToFile(ByVal adr As Adresse, ByVal Filename As String)
        ADSoapSerializer.SerializeToFile(New FileInfo(Filename), adr)
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen - Soap-Format
    Public Shared Function SerializeSoapFromFile(ByVal Filename As String) As Adresse
        Return CType(ADSoapSerializer.DeserializeFromFile(New FileInfo(Filename)), Adresse)
    End Function

    'Alle ÷ffentlichen Felder in die Datei schreiben - Binary-Format
    Public Shared Sub SerializeBinToFile(ByVal adr As Adresse, ByVal Filename As String)
        ADBinarySerializer.SerializeToFile(New FileInfo(Filename), adr)
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen - Binary-Format
    Public Shared Function SerializeBinFromFile(ByVal Filename As String) As Adresse
        Return CType(ADBinarySerializer.DeserializeFromFile(New FileInfo(Filename)), Adresse)
    End Function

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

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

    Public Property Straﬂe() As String
        Get
            Return myStraﬂe
        End Get
        Set(ByVal Value As String)
            myStraﬂe = Value
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
