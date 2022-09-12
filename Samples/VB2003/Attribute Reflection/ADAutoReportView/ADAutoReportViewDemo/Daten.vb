Imports System.Runtime.Interopservices

Public Class Adresse

    'Membervariablen, die die Daten halten:
    Protected myMatchcode As String
    Protected myName As String
    Protected myVorname As String
    Protected myStraﬂe As String
    Protected myPLZ As String
    Protected myOrt As String

    'Konstruktoren - erstellen eine neue Instanz an
    Sub New()
        MyBase.New()
    End Sub

    Sub New(ByVal Name As String, ByVal Vorname As String, ByVal Straﬂe As String, ByVal Plz As String, ByVal Ort As String)
        myName = Name
        myVorname = Vorname
        myStraﬂe = Straﬂe
        myPLZ = Plz
        myOrt = Ort
    End Sub

    Sub New(ByVal Matchcode As String, ByVal Name As String, ByVal Vorname As String, ByVal Straﬂe As String, ByVal Plz As String, ByVal Ort As String)
        Me.New(Name, Vorname, Straﬂe, Plz, Ort)
        myMatchcode = Matchcode
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

    Public Overridable Property Straﬂe() As String
        Get
            Return myStraﬂe
        End Get
        Set(ByVal Value As String)
            myStraﬂe = Value
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
        Return Matchcode + ": " + Name + ", " + Vorname + ", " + Straﬂe + ", " + PLZ + " " + Ort
    End Function

    Public Shared Function ZufallsAdressen(ByVal Anzahl As Integer) As Adressen

        Dim locAdressen As New Adressen
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Lˆffelmann", "Thiemann", "M¸ller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "V¸llers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hˆrstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locVornamen As String() = {"J¸rgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "JosÈ", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}

        Dim locStraﬂen As String() = {"Kurgartenweg", "Parkstraﬂe", "Alter Postweg", "Stadtstraﬂe", "Aue", _
                    "Windpockenallee", "Hauptstraﬂe", "S¸dring", "Nordring", "Himmelspforte", _
                    "Thiemannweg", "Ausfallstraﬂe", "Absturzpfad", "Crash Ave", "Main Road", "Am Tor", _
                    "Am Brunnen", "Dorfplatz", "Dorfgasse", "Gassenstraﬂe", "Reiterweg", "Kleine Gasse", _
                    "Lange Straﬂe", "Altstadtplatz"}

        Dim locSt‰dte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "M¸nchen", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleiﬂheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 1 To Anzahl
            Dim locName, locVorname, locMatchcode As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locMatchcode = GenMatchcode(locName, locVorname, locAdressen.ID)
            locAdressen.Add(New Adresse( _
                            locMatchcode, _
                            locName, _
                            locVorname, _
                            locStraﬂen(locRandom.Next(locStraﬂen.Length - 1)), _
                            locRandom.Next(99999).ToString("00000"), _
                            locSt‰dte(locRandom.Next(locSt‰dte.Length - 1))), locMatchcode)
        Next
        Return locAdressen
    End Function

    Shared Function GenMatchcode(ByVal Name As String, ByVal Vorname As String, ByVal Nummer As Integer) As String
        Dim locMatchcode As String
        locMatchcode = Name.Substring(0, 2)
        locMatchcode += Vorname.Substring(0, 2)
        locMatchcode += Nummer.ToString("00000000")
        Return locMatchcode
    End Function
End Class

'Typsichere Adressen-Collection auf Wˆrterbuchbasies
Public Class Adressen
    Inherits KeyedCollectionBase

    Private myID As Integer

    Sub New()
        myID = 1
    End Sub

    Public Sub Add(ByVal Adr As Adresse, ByVal Matchcode As String)
        myID += 1
        List.Add(Adr, Matchcode)
    End Sub

    Default Public Property Item(ByVal Index As Integer) As Adresse
        Get
            Return DirectCast(MyBase.List(Index), Adresse)
        End Get
        Set(ByVal Value As Adresse)
            MyBase.List(Index) = Value
        End Set
    End Property

    Default Public Property Item(ByVal Matchcode As String) As Adresse
        Get
            Return DirectCast(MyBase.List.GetValue(Matchcode), Adresse)
        End Get
        Set(ByVal Value As Adresse)
            MyBase.List.SetValue(Value, Matchcode)
        End Set
    End Property

    Sub RemoveByKey(ByVal Matchcode As String)
        MyBase.List.RemoveByKey(Matchcode)
    End Sub

    Sub RemoveAt(ByVal Index As Integer)
        MyBase.List.RemoveAt(Index)
    End Sub

    Public ReadOnly Property ID() As Integer
        Get
            Return myID
        End Get
    End Property
End Class

