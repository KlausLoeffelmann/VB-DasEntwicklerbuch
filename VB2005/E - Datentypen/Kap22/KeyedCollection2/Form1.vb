Imports System.XML.Serialization
Imports System.IO
Public Class Form1

    Private myAdressen As New Adressen

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myAdressen.Add(New Adresse(New IntKey(2), "Löffelmann", "Klaus"))
        myAdressen.Add(New Adresse(New IntKey(4), "Heckhuis", "Jürgen"))
        myAdressen.Add(New Adresse(New IntKey(6), "Sonntag", "Miriam"))
        myAdressen.Add(New Adresse(New IntKey(8), "Heckhuis", "Jürgen"))
        myAdressen.Add(New Adresse(New IntKey(10), "Vielstedde", "Anja"))
    End Sub

    Private Sub btnObjekteAusgeben_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjekteAusgeben.Click
        For count As Integer = 0 To 4
            Debug.Print(myAdressen(count).Nachname & ", " & myAdressen(count).Vorname)
        Next
    End Sub

    Private Sub btnObjekteSerialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjekteSerialisieren.Click
        Dim writer As New XmlSerializer(GetType(Adressen))
        Dim file As New StreamWriter("c:\testdaten_xml.xml")
        writer.Serialize(file, myAdressen)
        file.Close()
    End Sub

    Private Sub btnObjekteDeserialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjekteDeserialisieren.Click
        Dim reader As New XmlSerializer(GetType(Adressen))
        Dim file As New StreamReader("c:\testdaten_xml.xml")
        Dim fileData As Adressen
        fileData = CType(reader.Deserialize(file), Adressen)
    End Sub
End Class

Public Class Adressen
    Inherits System.Collections.ObjectModel.KeyedCollection(Of IntKey, Adresse)

    Protected Overrides Function GetKeyForItem(ByVal item As Adresse) As IntKey
        Return item.IDAdresse
    End Function
End Class

Public Class Adresse

    Private myIDAdresse As IntKey
    Private myNachname As String
    Private myVorname As String

    'Den brauchen wir fürs Deserialisieren!
    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal IDAdresse As IntKey, ByVal Nachname As String, ByVal Vorname As String)
        myIDAdresse = IDAdresse
        myNachname = Nachname
        myVorname = Vorname
    End Sub

    Public Property IDAdresse() As IntKey
        Get
            Return myIDAdresse
        End Get
        Set(ByVal value As IntKey)
            myIDAdresse = value
        End Set
    End Property

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal value As String)
            myNachname = value
        End Set
    End Property

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal value As String)
            myVorname = value
        End Set
    End Property
End Class

<Serializable()> _
Public Class IntKey

    Private myKey As Integer

    'Wichtig für die XML-Serialisierung: Parameterloser Konstruktor!
    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal Key As Integer)
        myKey = Key
    End Sub

    Public ReadOnly Property Key() As Integer
        Get
            Return myKey
        End Get
    End Property
End Class