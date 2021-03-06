Public Class AdressenKey
    Implements IComparable

    Private myMatchcode As String
    Private myKeyValue As Integer
    Private myDataToSort As String

    Sub New(ByVal Matchcode As String, ByVal DataToSort As String)
        myKeyValue = Integer.Parse(Matchcode.Substring(0, 8))
        myMatchcode = Matchcode
        myDataToSort = DataToSort
    End Sub

    'Wird ben�tigt, um bei Kollisionen den richtigen
    'Schl�ssel zu finden
    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        Return myKeyValue.Equals(DirectCast(obj, AdressenKey).KeyValue)
    End Function

    'Wird ben�tigt, um den Index zu "berechnen"
    Public Overrides Function GetHashcode() As Integer
        Return myKeyValue
    End Function

    Public Overrides Function ToString() As String
        Return myMatchcode
    End Function

    Public Property KeyValue() As Integer
        Get
            Return myKeyValue
        End Get
        Set(ByVal Value As Integer)
            myKeyValue = Value
        End Set
    End Property

    Public Property DataToSort() As String
        Get
            Return myDataToSort
        End Get
        Set(ByVal Value As String)
            myDataToSort = Value
        End Set
    End Property

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If myMatchcode = DirectCast(obj, AdressenKey).myMatchcode Then
            Return 0
        End If
        If DataToSort.CompareTo(DirectCast(obj, AdressenKey).DataToSort) = 0 Then
            Return -1
        Else
            Return DataToSort.CompareTo(DirectCast(obj, AdressenKey).DataToSort)
        End If
    End Function
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

        Dim locNachnamen As String() = {"Heckhuis", "L�ffelmann", "Thiemann", "M�ller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "V�llers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "H�rstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locVornamen As String() = {"J�rgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "Jos�", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}
        Dim locSt�dte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "M�nchen", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschlei�heim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 1 To Anzahl
            Dim locName, locVorname, locMatchcode As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locMatchcode = (Anzahl - i).ToString("00000000")
            locMatchcode += locName.Substring(0, 2)
            locMatchcode += locVorname.Substring(0, 2)
            locArrayList.Add(New Adresse( _
                            locMatchcode, _
                            locName, _
                            locVorname, _
                            locRandom.Next(99999).ToString("00000"), _
                            locSt�dte(locRandom.Next(locSt�dte.Length - 1))))

        Next
        Return locArrayList
    End Function

    Shared Sub AdressenAusgeben(ByVal Adressen As ArrayList)
        For Each Item As Object In Adressen
            Console.WriteLine(Item)
        Next
    End Sub

End Class
