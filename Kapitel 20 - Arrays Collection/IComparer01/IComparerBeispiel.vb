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

        'Alternativ: Sortieren mit Comparision-Delegat und Lambda:
        Array.Sort(Of Adresse)(locAdressen, Function(value1 As Adresse, value2 As Adresse)
                                                Return value1.ToString.CompareTo(value2.ToString)
                                            End Function)
        DruckeAdressenLambda(locAdressen)

        Console.ReadLine()
    End Sub

    Sub DruckeAdressen(ByVal Adressen As Adresse())
        For Each locString As Adresse In Adressen
            Console.WriteLine(locString)
        Next
    End Sub

    'Auch hier die ALternative mit einer Methode, die einen
    'Delegaten erwartet, der als Lambda formuliert werden kann:
    Sub DruckeAdressenLambda(ByVal Adressen As Adresse())
        Array.ForEach(Adressen, Sub(item)
                                    Console.WriteLine(item.ToString)
                                End Sub)
    End Sub

End Module

Public Class Adresse
    'Implements IComparable

    Sub New(ByVal Name As String, ByVal Vorname As String, ByVal Plz As String, ByVal Ort As String)
        Me.Name = Name
        Me.Vorname = Vorname
        Me.PLZ = Plz
        Me.Ort = Ort
    End Sub

    'Automatisch implementierte Eigenschaften
    Public Property Name() As String
    Public Property Vorname() As String
    Public Property PLZ() As String
    Public Property Ort() As String

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
