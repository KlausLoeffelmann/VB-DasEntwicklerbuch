Public Class AdressenKey

    Private myMatchcode As String
    Private myKeyValue As Integer

    Sub New(ByVal Matchcode As String)
        myKeyValue = Integer.Parse(Matchcode.Substring(4))
        myMatchcode = Matchcode
    End Sub

    'Wird benötigt, um bei Kollisionen den richtigen
    'Schlüssel zu finden
    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        'If Not (TypeOf obj Is AdressenKey) Then
        '    Dim up As New InvalidCastException("AdressenKey kann nur mit Objekten gleichen Typs verglichen werden")
        '    Throw up
        'End If
        Return myKeyValue.Equals(DirectCast(obj, AdressenKey).KeyValue)
    End Function

    'Wird benötigt, um den Index zu "berechnen"
    Public Overrides Function GetHashcode() As Integer
        Return myKeyValue
    End Function

    Public Overrides Function ToString() As String
        Return myKeyValue.ToString
    End Function

    Public Property KeyValue() As Integer
        Get
            Return myKeyValue
        End Get
        Set(ByVal Value As Integer)
            myKeyValue = Value
        End Set
    End Property

End Class

Public Class Adresse

    'Membervariablen, die die Daten halten:
    Protected myMatchcode As String
    Protected myName As String
    Protected myVorname As String
    Protected myPLZ As String
    Protected myOrt As String

    'Konstruktor - legt eine neue Instanz an
    Sub New(ByVal Matchcode As String, ByVal Name As String, ByVal Vorname As String, ByVal Plz As String, ByVal Ort As String)
        myMatchcode = Matchcode
        myName = Name
        myVorname = Vorname
        myPLZ = Plz
        myOrt = Ort
    End Sub

    'Mit Region ausgeblendet:
    'Die Eigenschaften der Klasse, um die Daten offen zu legen
#Region "Eigenschaften"
    Public Overridable Property Matchcode() As String
        Get
            Return myMatchcode
        End Get
        Set(ByVal Value As String)
            myMatchcode = Value
        End Set
    End Property

    Public Overridable Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public Overridable Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Overridable Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal Value As String)
            myPLZ = Value
        End Set
    End Property

    Public Overridable Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal Value As String)
            myOrt = Value
        End Set
    End Property
#End Region

    Public Overrides Function ToString() As String
        Return Matchcode + ": " + Name + ", " + Vorname + ", " + PLZ + " " + Ort
    End Function

    Public Shared Function ZufallsAdressen(ByVal Anzahl As Integer) As ArrayList

        Dim locArrayList As New ArrayList(Anzahl)
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locVornamen As String() = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}
        Dim locStädte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 1 To Anzahl
            Dim locName, locVorname, locMatchcode As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locMatchcode = locName.Substring(0, 2)
            locMatchcode += locVorname.Substring(0, 2)
            locMatchcode += i.ToString("00000000")
            locArrayList.Add(New Adresse( _
                            locMatchcode, _
                            locName, _
                            locVorname, _
                            locRandom.Next(99999).ToString("00000"), _
                            locStädte(locRandom.Next(locStädte.Length - 1))))

        Next
        Return locArrayList
    End Function

    Shared Sub AdressenAusgeben(ByVal Adressen As ArrayList)
        For Each Item As Object In Adressen
            Console.WriteLine(Item)
        Next
    End Sub

End Class

'Typsichere Adressen-Collection auf Wörterbuchbasies
Public Class Adressen
    Inherits DictionaryBase

    'Default Eigenschaft erlaubt das Auslesen der typsicheren Hashtable
    Default Public Property Item(ByVal key As AdressenKey) As Adresse
        Get
            Return DirectCast(Dictionary(key), Adresse)
        End Get
        Set(ByVal Value As Adresse)
            Dictionary(key) = Value
        End Set
    End Property

    'Liefert eine ICollection aller Keys zurück
    Public ReadOnly Property Keys() As ICollection
        Get
            Return Dictionary.Keys
        End Get
    End Property

    'Liefert eine ICollection aller Werte zurück
    Public ReadOnly Property Values() As ICollection
        Get
            Return Dictionary.Values
        End Get
    End Property

    'Erlaubt das Hinzufügen eines Eintrags typsicher
    Public Sub Add(ByVal key As AdressenKey, ByVal value As Adresse)
        Dictionary.Add(key, value)
    End Sub

    'Überprüft, ob ein bestimmter Key in der Liste enthalten ist
    Public Function Contains(ByVal key As AdressenKey) As Boolean
        Return Dictionary.Contains(key)
    End Function

    'Entfernt ein Element aus der Liste mit Hilfe seines Keys
    Public Sub Remove(ByVal key As AdressenKey)
        Dictionary.Remove(key)
    End Sub

End Class