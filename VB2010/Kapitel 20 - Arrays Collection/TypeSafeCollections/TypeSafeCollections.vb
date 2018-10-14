Imports System.IO

Module TypesafeCollections

    Sub Main()
        Dim locAdressen As New Adressen
        Dim locAdresse As New Adresse("Christian", "Sonntag", "99999", "Trinken")
        Dim locAndererTyp As New FileInfo("C:\Test.txt")

        'Kein Problem:
        locAdressen.Add(locAdresse)

        'Schon der Editor mault!
        'locAdressen.Add(locAndererTyp)

        'Auch kein Problem
        locAdresse = locAdressen(0)

        For Each eineAdresse As Adresse In locAdressen
            Console.WriteLine(eineAdresse)
        Next
        Console.ReadLine()
    End Sub

End Module

Public Class Adressen
    Inherits CollectionBase

    Public Overridable Function Add(ByVal Adr As Adresse) As Integer
        Return MyBase.List.Add(Adr)
    End Function

    Default Public Overridable Property Item(ByVal Index As Integer) As Adresse
        Get
            Return DirectCast(MyBase.List(Index), Adresse)
        End Get
        Set(ByVal Value As Adresse)
            MyBase.List(Index) = Value
        End Set
    End Property
End Class

Public Class Adresse
    Implements IComparable

    Protected myName As String
    Protected myVorname As String
    Protected myPLZ As String
    Protected myOrt As String

    Sub New(ByVal Name As String, ByVal Vorname As String, ByVal Plz As String, ByVal Ort As String)
        myName = Name
        myVorname = Vorname
        myPLZ = Plz
        myOrt = Ort
    End Sub

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal Value As String)
            myPLZ = Value
        End Set
    End Property

    Public Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal Value As String)
            myOrt = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Name + ", " + Vorname + ", " + PLZ + " " + Ort
    End Function

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

        Dim locAdresse As Adresse

        Try
            locAdresse = DirectCast(obj, Adresse)
        Catch ex As InvalidCastException
            Dim up As New InvalidCastException("'CompareTo' der Klasse 'Adresse' kann keine Vergleiche " + _
                                               "mit Objekten anderen Typs durchführen!")
            Throw up
        End Try
        Return ToString.CompareTo(locAdresse.ToString)
    End Function
End Class

'---------------------------------------------------------------------
'-- Nur zur Erklärung, hat nichts mit eigentlichem Programm zu tun! --
'---------------------------------------------------------------------
Interface ITest
    Function Add(ByVal obj As Object) As Integer
End Interface

MustInherit Class ITestKlasse
    Implements ITest

    Private Function ITestAdd(ByVal obj As Object) As Integer Implements ITest.Add
        Trace.WriteLine("ITestAdd:" + obj.ToString)
    End Function

End Class

Class ITestKlasseAbleitung
    Inherits ITestKlasse

    Public ReadOnly Property Test() As ITest
        Get
            Return DirectCast(Me, ITest)
        End Get
    End Property

    Public Sub Add(ByVal TypeSafe As Adresse)
        Test.Add(TypeSafe)
    End Sub
End Class
