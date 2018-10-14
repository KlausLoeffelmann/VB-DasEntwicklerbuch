Module ComparerBeispiel

    Sub Main()
        Dim locAdressen(5) As Adresse

        locAdressen(0) = New Adresse("Löffelmann", "Klaus", "11111", "Soest")
        locAdressen(1) = New Adresse("Heckhuis", "Jürgen", "99999", "Gut Uhlenbusch")
        locAdressen(2) = New Adresse("Sonntag", "Miriam", "22222", "Dortmund")
        locAdressen(3) = New Adresse("Sonntag", "Christian", "33333", "Wuppertal")
        locAdressen(4) = New Adresse("Ademmer", "Uta", "55555", "Bad Waldholz")
        locAdressen(5) = New Adresse("Kaiser", "Wilhelm", "12121", "Ostenwesten")

        Console.WriteLine("Adressenliste:")
        Console.WriteLine(New String("="c, 40))
        DruckeAdressen(locAdressen)

        Console.WriteLine()
        Console.WriteLine("Adressenliste (sortiert):")
        Console.WriteLine(New String("="c, 40))
        'Array.Sort(locAdressen)
        DruckeAdressen(locAdressen)

        Console.ReadLine()
    End Sub

    Sub DruckeAdressen(ByVal Adressen As Adresse())
        For Each locString As Adresse In Adressen
            Console.WriteLine(locString)
        Next
    End Sub

End Module

Public Class Adresse
    'Implements IComparable

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

    'Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

    '    Dim locAdresse As Adresse

    '    Try
    '        locAdresse = DirectCast(obj, Adresse)
    '    Catch ex As InvalidCastException
    '        Dim up As New InvalidCastException("'CompareTo' der Klasse 'Adresse' kann keine Vergleiche " + _
    '                                           "mit Objekten anderen Typs durchführen!")
    '        Throw up
    '    End Try
    '    Return ToString.CompareTo(locAdresse.ToString)
    'End Function
End Class
