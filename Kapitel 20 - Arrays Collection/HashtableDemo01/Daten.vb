Public Class Adresse

    'Konstruktor - legt eine neue Instanz an
    Sub New(ByVal Matchcode As String, ByVal Name As String, ByVal Vorname As String,
            ByVal Plz As String, ByVal Ort As String)
        Me.Matchcode = Matchcode
        Me.Name = Name
        Me.Vorname = Vorname
        Me.PLZ = Plz
        Me.Ort = Ort
    End Sub

    Public Overridable Property Matchcode() As String
    Public Overridable Property Name() As String
    Public Overridable Property Vorname() As String
    Public Overridable Property PLZ() As String
    Public Overridable Property Ort() As String

    Public Overrides Function ToString() As String
        Return Matchcode + ": " + Name + ", " + Vorname + ", " + PLZ + " " + Ort
    End Function

    Public Shared Function ZufallsAdressen(ByVal Anzahl As Integer) As ArrayList

        Dim locArrayList As New ArrayList(Anzahl)
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller",
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers",
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann",
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann",
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch",
                    "Clarke"}

        Dim locVornamen As String() = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans",
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja",
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete",
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel",
                    "Lothar", "Gareth"}
        Dim locStädte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest",
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld",
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing",
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 1 To Anzahl
            Dim locName, locVorname, locMatchcode As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locMatchcode = locName.Substring(0, 2)
            locMatchcode += locVorname.Substring(0, 2)
            locMatchcode += i.ToString("00000000")
            locArrayList.Add(New Adresse(
                            locMatchcode,
                            locName,
                            locVorname,
                            locRandom.Next(99999).ToString("00000"),
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
