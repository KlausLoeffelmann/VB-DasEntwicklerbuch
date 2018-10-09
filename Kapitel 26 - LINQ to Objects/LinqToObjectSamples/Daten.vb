Imports System.Collections.ObjectModel

Public Class Artikel

    Property IDGekauftVon() As Integer
    Property ArtikelName() As String
    Property ArtikelNummer() As String
    Property Kategorie() As String
    Property Anzahl() As Integer
    Property Einzelpreis() As Decimal

    Public Overrides Function ToString() As String
        Return Me.ArtikelNummer & ": " & Me.ArtikelName
    End Function

    Public Shared Function Zufallsartikel(ByVal Kontakte As List(Of Kontakt)) As List(Of Artikel)

        Dim tmpRandom As New Random(Now.Millisecond)
        Dim tmpArtikelliste As New List(Of Artikel)

        Dim tmpArtikelstamm As String() = {"DVD|Das Leben des Brian|1-234", _
                                      "DVD|Abgefahren - Mit Vollgas in die Liebe|2-134", _
                                      "DVD|Das Vermächstnis der Tempelritter|3-123", _
                                      "DVD|Was diese Frau so alles treibt|9-646", _
                                      "DVD|Mitten ins Herz|3-534", _
                                      "DVD|Der Teufel trägt Prada|4-324", _
                                      "DVD|Desperate Housewives - Staffel 2, Erster Teil|9-423", _
                                      "DVD|O.C., California - Die komplette zweite Staffel (7 DVDs)|5-554", _
                                      "DVD|24 - Season 6 [UK Import - Damn It!]|2-424", _
                                      "Bücher, EDV|Visual Basic 2005 - Das Entwicklerbuch|3-537", _
                                      "Bücher, EDV|Visual Basic 2008 - Das Entwicklerbuch|5-506", _
                                      "Bücher, EDV|Visual Basic 2008 - Neue Technologien - Crashkurs|5-518", _
                                      "Bücher, EDV|Microsoft Visual C# 2005 - Das Entwicklerbuch|3-543", _
                                      "Bücher, EDV|Programmieren mit dem .NET Compact Framework|5-401", _
                                      "Bücher, EDV|Microsoft SQL Server 2008 - Einführung in Konfiguration, Administration, Programmierung|5-513", _
                                      "Hörbuch|Harry Potter und die Heiligtümer des Todes| 4-444", _
                                      "Hörbuch|Die Rache der Zwerge|2-321", _
                                      "Hörbuch|Die Wächter|9-009", _
                                      "Hörbuch|Das Herz der Hölle|7-321", _
                                      "Bücher, Belletristik|Die Tore der Welt|9-445", _
                                      "Bücher, Belletristik|Die Kathredale des Meeres|5-436", _
                                      "Bücher, Belletristik|The Da Vinci Code|4-444", _
                                      "Bücher, Belletristik|Der Schwarm|3-333", _
                                      "Bücher, Belletristik|Tod und Teufel|6-666"}

        Dim tmpArtikel As Artikel

        'Jeder hat was gekauft! :-)
        For Each adrItem In Kontakte
            'Jeder hat zwischen einem und 20 Artikel gekauft
            For anzahlGekaufterArtikel = 1 To tmpRandom.Next(1, 20)
                tmpArtikel = New Artikel()
                Dim tmpStr() = tmpArtikelstamm(tmpRandom.Next(0, tmpArtikelstamm.Count - 1)).Split("|"c)
                tmpArtikel.IDGekauftVon = adrItem.ID
                tmpArtikel.ArtikelName = tmpStr(1)
                tmpArtikel.ArtikelNummer = tmpStr(2)
                tmpArtikel.Anzahl = tmpRandom.Next(1, 4)
                tmpArtikel.Einzelpreis = (tmpRandom.Next(1, 20) * 5) - 0.05D
                tmpArtikel.Kategorie = tmpStr(0)
                tmpArtikelliste.Add(tmpArtikel)
            Next
        Next
        Return tmpArtikelliste
    End Function


End Class

Public Class Kontakt

    'Membervariablen, die die Daten halten:
    Private myID As Integer
    Private myName As String
    Private myVorname As String
    Private myStraße As String
    Private myPLZ As String
    Private myOrt As String

    'Konstruktor - legt eine neue Instanz an
    Sub New(ByVal ID As Integer, ByVal Name As String, _
            ByVal Vorname As String, ByVal Straße As String, _
            ByVal Plz As String, ByVal Ort As String)
        myID = ID
        myName = Name
        myVorname = Vorname
        myStraße = Straße
        myPLZ = Plz
        myOrt = Ort
    End Sub

    'Mit Region ausgeblendet:
    'Die Eigenschaften der Klasse, um die Daten offen zu legen
#Region "Eigenschaften"
    Public Overridable Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Overridable Property Nachname() As String
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

    Public Overridable Property Straße() As String
        Get
            Return myStraße
        End Get
        Set(ByVal value As String)
            myStraße = value
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
        Return """" + Nachname + ", " + Vorname + """"
    End Function

    Public Shared Function ZufallsKontakte(ByVal Anzahl As Integer) As List(Of Kontakt)

        Dim tmpAdressListe As New List(Of Kontakt)
        Dim tmpRandom As New Random(Now.Millisecond)

        Dim tmpNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
                    "Wördehoff", "Lehnert", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke", "Lehnert"}

        Dim tmpStraßen As String() = {"Wiedenbrückerstr.", "Stauffenbergstr.", "Schloßallee", "Parkstr.", _
                         "Kurgartenweg", "Alter Postweg", "Lange Wende", "Marktplatz", "Gassenstr", _
                         "Straßengasse", "Postplatz", "Platzstr.", "Gassenplatz", "Himmelsbachweg", _
                         "Weidering", "Potterberg", "Am Wördehof", "Leingartenweg", "Lehnertweg"}

        Dim tmpVornamen As String() = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth", "Angela", "Denise", "Kerstin"}

        Dim tmpStädte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        For i As Integer = 1 To Anzahl
            Dim tmpName, tmpVorname As String
            tmpName = tmpNachnamen(tmpRandom.Next(tmpNachnamen.Length - 1))
            tmpVorname = tmpVornamen(tmpRandom.Next(tmpNachnamen.Length - 1))
            tmpAdressListe.Add(New Kontakt( _
                            i, _
                            tmpName, _
                            tmpVorname, _
                            tmpStraßen(tmpRandom.Next(tmpStraßen.Length - 1)), _
                            tmpRandom.Next(99999).ToString("00000"), _
                            tmpStädte(tmpRandom.Next(tmpStädte.Length - 1))))
        Next
        Return tmpAdressListe
    End Function

    Shared Sub KontakteAusgeben(ByVal Kontakte As List(Of Kontakt))
        'Option Infer ist 'On', deswegen wird
        'Item automatisch zum Typ 'Adresse'
        For Each Item In Kontakte
            Console.WriteLine(Item)
        Next
    End Sub

End Class

Public Class AbDaten
    Dim myA As String
    Dim myB As String

    Sub New(ByVal a As String, ByVal b As String)
        myA = a
        myB = b
    End Sub

    Public Property A() As String
        Get
            Return myA
        End Get
        Set(ByVal value As String)
            myA = value
        End Set
    End Property

    Public Property B() As String
        Get
            Return myB
        End Get
        Set(ByVal value As String)
            myB = value
        End Set
    End Property
End Class

Public Class CdDaten
    Dim myC As String
    Dim myD As String

    Sub New(ByVal c As String, ByVal d As String)
        myC = c
        myD = d
    End Sub

    Public Property C() As String
        Get
            Return myC
        End Get
        Set(ByVal value As String)
            myC = value
        End Set
    End Property

    Public Property D() As String
        Get
            Return myD
        End Get
        Set(ByVal value As String)
            myD = value
        End Set
    End Property
End Class
