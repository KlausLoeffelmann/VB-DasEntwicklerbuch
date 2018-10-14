Module Hauptmodul

    Dim Nachname(0 To 100) As String
    Dim Vorname(0 To 100) As String
    Dim PLZ(0 To 100) As String
    Dim Ort(0 To 100) As String

    Sub Main()

        Dim ersteAdresse As Adresse
        ersteAdresse = New Adresse("Klaus", "Löffelmann", "59556", "Lippstadt")
        ersteAdresse.Nachname = "Müller"
        ersteAdresse.Vorname = "Klaus"

        Dim zweiteAdresse As New Adresse
        zweiteAdresse.Nachname = ersteAdresse.Nachname
        zweiteAdresse.Vorname = ersteAdresse.Vorname
        zweiteAdresse.PLZ = ersteAdresse.PLZ
        zweiteAdresse.Ort = ersteAdresse.Ort

        Console.Write(ersteAdresse.Nachname + ", " + zweiteAdresse.Nachname)
        Console.ReadKey()

        Dim vorname As String
        vorname = "Peter"

        'Hier 'mal darstellungsmäßig was Anderes im Konsolenfenster
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.Black
        Console.Clear()

        'Zufallsadressen generieren
        Console.Write("Zufallsadressen werden generiert ... ")
        ZufallsAdressenGenerieren()
        Console.WriteLine("fertig!")

        'Die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Die Adressen sortieren
        Console.WriteLine()
        Console.Write("Adressen werden sortiert ... ")
        AdressenSortieren()
        Console.WriteLine("fertig!")
        Console.WriteLine()

        'Und jetzt nochmal die ersten 10 Zufallsadressen ausgeben
        AdressenAusgeben(0, 10)

        'Warten, bis das Programm beendet ist.
        Console.WriteLine()
        Console.WriteLine("Taste zum Beenden drücken...")
        Console.ReadKey()

    End Sub

    Sub AdressenAusgeben(ByVal von As Integer, ByVal bis As Integer)
        For c As Integer = von To bis
            Console.WriteLine(c.ToString("000") & ": " & Nachname(c) & ", " & Vorname(c) & _
                              ", " & PLZ(c) & ", " & Ort(c))
        Next
    End Sub

    Sub AdressenSortieren()

        'Beispiel für lokalen Typrückschluss
        Dim anzahlElemente = 101
        Dim delta = 1

        Dim aeussererZaehler As Integer
        Dim innererZaehler As Integer

        Dim tempVorname, tempNachname, tempPLZ, tempOrt As String

        'Größten Wert der Distanzfolge ermitteln
        Do
            delta = 3 * delta + 1
        Loop Until delta > anzahlElemente

        Do
            'Späteres Abbruchkriterium - entsprechend kleiner werden lassen
            delta \= 3

            'Shellsort's Kernalgorithmus
            For aeussererZaehler = delta To anzahlElemente - 1
                tempVorname = Vorname(aeussererZaehler)
                tempNachname = Nachname(aeussererZaehler)
                tempPLZ = PLZ(aeussererZaehler)
                tempOrt = Ort(aeussererZaehler)

                innererZaehler = aeussererZaehler
                Do
                    If tempNachname >= Nachname(innererZaehler - delta) Then Exit Do
                    Vorname(innererZaehler) = Vorname(innererZaehler - delta)
                    Nachname(innererZaehler) = Nachname(innererZaehler - delta)
                    PLZ(innererZaehler) = PLZ(innererZaehler - delta)

                    innererZaehler = innererZaehler - delta
                    If (innererZaehler <= delta) Then Exit Do
                Loop
                Vorname(innererZaehler) = tempVorname
                Nachname(innererZaehler) = tempNachname
                Ort(innererZaehler) = tempOrt
            Next
        Loop Until delta = 0
    End Sub

    Public Sub ZufallsAdressenGenerieren()

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

        For i As Integer = 0 To 100
            Dim locName, locVorname As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))

            Nachname(i) = locName
            Vorname(i) = locVorname
            Ort(i) = locStädte(locRandom.Next(locStädte.Length - 1))
            PLZ(i) = locRandom.Next(99999).ToString("00000")
        Next
    End Sub
End Module

Public Class Adresse
    Inherits Object

    Private myVorname As String
    Private myNachname As String
    Private myPLZ As String
    Private myOrt As String

    Sub New()
        Console.WriteLine("Der Konstruktor wurde aufgerufen")
    End Sub

    Sub New(ByVal vorname As String, ByVal nachname As String, _
            ByVal plz As String, ByVal ort As String)
        myVorname = vorname
        Me.Nachname = nachname
        myPLZ = plz
        myOrt = ort
    End Sub

    Public Sub Methode1(ByRef alter As Integer)
        alter = 10
    End Sub

    Public Function Methode2(ByVal name As String) As String
        Return name
    End Function

    Property Nachname() As String
        Get
            Return myNachname
        End Get

        Set(ByVal value As String)
            value = value.TrimEnd
            If value.Length > 20 Then
                myNachname = value.Substring(0, 20)
            Else
                myNachname = value
            End If
        End Set
    End Property

    Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal value As String)
            myVorname = value
        End Set
    End Property

    Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal value As String)
            myPLZ = value
        End Set
    End Property

    Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal value As String)
            myOrt = value
        End Set
    End Property
End Class
