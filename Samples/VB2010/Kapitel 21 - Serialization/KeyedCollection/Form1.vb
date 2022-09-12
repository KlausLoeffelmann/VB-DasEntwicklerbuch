Imports System.XML.Serialization
Imports System.IO
Public Class Form1

    Private myAdressen As New Adressen

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        myAdressen.Add(New Adresse(2, "Löffelmann", "Klaus"))
        myAdressen.Add(New Adresse(4, "Heckhuis", "Jürgen"))
        myAdressen.Add(New Adresse(6, "Sonntag", "Miriam"))
        myAdressen.Add(New Adresse(8, "Heckhuis", "Jürgen"))
        myAdressen.Add(New Adresse(10, "Vielstedde", "Anja"))
    End Sub

    Private Sub btnObjekteAusgeben_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObjekteAusgeben.Click
        For Each locAdresse As Adresse In myAdressen
            Debug.Print(locAdresse.Nachname & ", " & locAdresse.Vorname)
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
    Inherits System.Collections.ObjectModel.KeyedCollection(Of Integer, Adresse)

    Protected Overrides Function GetKeyForItem(ByVal item As Adresse) As Integer
        Return item.IDAdresse
    End Function
End Class

Public Class Adresse

    Private myIDAdresse As Integer
    Private myNachname As String
    Private myVorname As String

    'Den brauchen wir fürs Deserialisieren!
    Sub New()
        MyBase.new()
    End Sub

    Sub New(ByVal IDAdresse As Integer, ByVal Nachname As String, ByVal Vorname As String)
        myIDAdresse = IDAdresse
        myNachname = Nachname
        myVorname = Vorname
    End Sub

    Public Property IDAdresse() As Integer
        Get
            Return myIDAdresse
        End Get
        Set(ByVal value As Integer)
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
