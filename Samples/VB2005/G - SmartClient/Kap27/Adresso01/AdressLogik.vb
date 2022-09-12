Imports System.Collections.ObjectModel
Imports System.XML.Serialization
Imports System.IO

<Serializable()> _
Public Class Adressen
    Inherits List(Of Adresse)

    Private mySortierenNach As AdressenSortierenNach

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse 
    ''' und erm�glicht das �bernehmen einer vorhandenen Auflistung in diese.
    ''' </summary>
    ''' <param name="collection">Die generische Adresse-Auflistung, deren Elemente 
    ''' in diese Auflistungsinstanz �bernommen werden sollen.</param>
    ''' <remarks></remarks>
    Sub New(ByVal collection As ICollection(Of Adresse))
        MyBase.New(collection)
    End Sub

    ''' <summary>
    ''' Gibt alle Adresse-Objekte als Instanz dieser Klasse zur�ck, 
    ''' in denen der angegebene Suchbegriff vorkam.
    ''' </summary>
    ''' <param name="Text">Suchbegriff, nachdem diese AUflistung durchsucht werden soll.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Suchen(ByVal Text As String) As Adressen

        'In dieser Adressen-Auflistung wird das Suchergebnis gesammelt.
        Dim locAdressen As New Adressen()

        For Each locAdresse As Adresse In Me
            If locAdresse.Name Like Text Then
                locAdressen.Add(locAdresse)
                'Direkt zum 'Next' springen.
                Continue For
            ElseIf locAdresse.Vorname Like Text Then
                locAdressen.Add(locAdresse)
                Continue For
            ElseIf locAdresse.Stra�e Like Text Then
                locAdressen.Add(locAdresse)
                Continue For
            ElseIf locAdresse.Ort Like Text Then
                locAdressen.Add(locAdresse)
                Continue For
            ElseIf locAdresse.PLZ.ToString Like Text Then
                locAdressen.Add(locAdresse)
            End If
        Next

        Return locAdressen
    End Function

    Public Sub Sortieren(ByVal SortierenNach As AdressenSortierenNach)

        'Das Array mit Hilfe eines Comparison-Delegaten sortieren
        mySortierenNach = SortierenNach
        Me.Sort(New Comparison(Of Adresse)(AddressOf AdressenVergleicher))

    End Sub

    'Der Comparison-Delegat zum Vergleichen zweier Elemente.
    Private Function AdressenVergleicher(ByVal x As Adresse, ByVal y As Adresse) As Integer

        Try
            'Sortierung in Abh�ngigkeit zur Suchspalte durchf�hren
            Select Case mySortierenNach
                Case AdressenSortierenNach.Matchcode
                    Return x.Matchcode.CompareTo(y.Matchcode)
                Case AdressenSortierenNach.Name
                    Return x.Name.CompareTo(y.Name)
                Case AdressenSortierenNach.Ort
                    Return x.Ort.CompareTo(y.Ort)
                Case AdressenSortierenNach.PLZ
                    Return x.PLZ.CompareTo(y.PLZ)
                Case AdressenSortierenNach.Stra�e
                    Return x.Stra�e.CompareTo(y.Stra�e)
                Case Else
                    Return x.Vorname.CompareTo(y.Vorname)
            End Select
        Catch ex As Exception
            'Abfangen, dass einer der Suchstrings Nothing ist.
            'Der ist dann immer kleiner als alle anderen!
            Return -1
        End Try

    End Function

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
    ''' <param name="Dateiname">Name der XML-Datei, aus der die Daten f�r 
    ''' diese AUflistungsinstanz entnommen werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function XmlDeserialize(ByVal Dateiname As String) As Adressen
        Dim locXmlLeser As New XmlSerializer(GetType(Adressen))
        Dim locXmlDatei As New StreamReader(Dateiname)
        Return CType(locXmlLeser.Deserialize(locXmlDatei), Adressen)
    End Function

    ''' <summary>
    ''' Liefert eine Instanz dieser Klasse mit Zufallsadressen zur�ck.
    ''' </summary>
    ''' <param name="Anzahl">Anzahl der Zufallsadressen, die erzeugt werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ZufallsAdressen(ByVal Anzahl As Integer) As List(Of Adresse)

        Dim locAdressListe As New List(Of Adresse)
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "L�ffelmann", "Thiemann", "M�ller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "V�llers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "H�rstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locStra�en As String() = {"Musterstra�e", "Alter Postweg", "Kirchgasse", "Buchweg", _
                                    "Kurgartenweg", "Wiedenbr�ckerstr.", "Edison Stra�e", _
                                    "Weidering", "Lange Stra�e", "Kurze Stra�e", "M�hlweg", _
                                    "Kahle Gasse"}

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
            Dim locName, locVorname, locMatchcode, locStra�e As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locStra�e = locStra�en(locRandom.Next(locStra�en.Length - 1))
            locMatchcode = locName.Substring(0, 2)
            locMatchcode += locVorname.Substring(0, 2)
            locMatchcode += i.ToString("00000000")
            locAdressListe.Add(New Adresse( _
                            locMatchcode, _
                            locName, _
                            locVorname, _
                            locStra�e, _
                            locRandom.Next(99999).ToString("00000"), _
                            locSt�dte(locRandom.Next(locSt�dte.Length - 1)), _
                            Date.FromOADate(#1/1/1950#.ToOADate + _
                                 locRandom.Next(CInt(#1/1/2000#.ToOADate - #1/1/1950#.ToOADate)))))

            'Hinweis f�r die Ermittlung der Zufallsgeburtsdaten:
            'ToOADate wandelt einen Datumswert in einen Double-Datentyp um.
            'Der Vorkommabereich enth�lt Jahre, Monate, Tage, 
            'der Nachkommabereich Stunden, Minuten, Sekunden.
            'FromOADate macht das Gegenteil, und wandelt einen Double
            'zur�ck in einen Date-Datentyp. Auf diese Weise wird in der
            'obenstehenden Zeile ein Zufallsdatum zwischen 1950 und 2000 generiert.
        Next
        Return locAdressListe
    End Function
End Class

Public Enum AdressenSortierenNach
    Matchcode
    Name
    Vorname
    Stra�e
    PLZ
    Ort
End Enum
