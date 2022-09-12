Imports System.Collections.ObjectModel
Imports System.XML.Serialization
Imports System.IO

<Serializable()> _
Public Class Adressen
    Inherits List(Of Adresse)

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse 
    ''' und ermöglicht das Übernehmen einer vorhandenen Auflistung in diese.
    ''' </summary>
    ''' <param name="collection">Die generische Adresse-Auflistung, deren Elemente 
    ''' in diese Auflistungsinstanz übernommen werden sollen.</param>
    ''' <remarks></remarks>
    Sub New(ByVal collection As ICollection(Of Adresse))
        MyBase.New(collection)
    End Sub

    ''' <summary>
    ''' Serialisiert alle Elemente dieser Auflistung in eine XML-Datei.
    ''' </summary>
    ''' <param name="Dateiname">Der Dateiname der XML-Datei.</param>
    ''' <remarks></remarks>
    Sub XMLSerialize(ByVal Dateiname As String)
        Dim locXmlWriter As New XmlSerializer(GetType(Adressen))
        Dim locXmlDatei As New StreamWriter(Dateiname)
        locXmlWriter.Serialize(locXmlDatei, Me)
        locXmlDatei.Flush()
        locXmlDatei.Close()
    End Sub

    ''' <summary>
    ''' Generiert aus einer XML-Datei eine neue Instanz dieser Auflistungsklasse.
    ''' </summary>
    ''' <param name="Dateiname">Name der XML-Datei, aus der die Daten für 
    ''' diese Auflistungsinstanz entnommen werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function XmlDeserialize(ByVal Dateiname As String) As Adressen
        Dim locXmlLeser As New XmlSerializer(GetType(Adressen))
        Dim locXmlDatei As New StreamReader(Dateiname)
        Return CType(locXmlLeser.Deserialize(locXmlDatei), Adressen)
    End Function

    ''' <summary>
    ''' Liefert eine Instanz dieser Klasse mit Zufallsadressen zurück.
    ''' </summary>
    ''' <param name="Anzahl">Anzahl der Zufallsadressen, die erzeugt werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ZufallsAdressen(ByVal Anzahl As Integer) As List(Of Adresse)

        Dim locAdressListe As New List(Of Adresse)
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locStraßen As String() = {"Musterstraße", "Alter Postweg", "Kirchgasse", "Buchweg", _
                                    "Kurgartenweg", "Wiedenbrückerstr.", "Edison Straße", _
                                    "Weidering", "Lange Straße", "Kurze Straße", "Mühlweg", _
                                    "Kahle Gasse"}

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
            Dim locName, locVorname, locMatchcode, locStraße As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locStraße = locStraßen(locRandom.Next(locStraßen.Length - 1))
            locMatchcode = locName.Substring(0, 2)
            locMatchcode += locVorname.Substring(0, 2)
            locMatchcode += i.ToString("00000000")
            locAdressListe.Add(New Adresse( _
                            locMatchcode, _
                            locName, _
                            locVorname, _
                            locStraße, _
                            locRandom.Next(99999).ToString("00000"), _
                            locStädte(locRandom.Next(locStädte.Length - 1))))
        Next
        Return locAdressListe
    End Function
End Class

<Serializable()> _
Public Class Adresse

    'Membervariablen, die die Daten halten:
    Protected myMatchcode As String
    Protected myName As String
    Protected myVorname As String
    Protected myStraße As String
    Protected myPLZ As String
    Protected myOrt As String

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks>Ein parameterloser Konstruktor wird benötigt, 
    ''' um XML-Serialisierung zu ermöglichen.</remarks>
    Sub New()
        MyBase.New()
    End Sub

    'Konstruktor - legt eine neue Instanz an
    Sub New(ByVal Matchcode As String, ByVal Name As String, ByVal Vorname As String, _
            ByVal Straße As String, ByVal Plz As String, ByVal Ort As String)
        myMatchcode = Matchcode
        myName = Name
        myVorname = Vorname
        myStraße = Straße
        myPLZ = Plz
        myOrt = Ort
    End Sub

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

    Public Overrides Function ToString() As String
        Return Matchcode & ":" & Name & ", " & Vorname
    End Function
End Class
