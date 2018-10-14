Module Enums

    Public Enum KontaktKategorie As Short
        Familie
        Freund
        Bekannter
        Kollege
        Gesch�ftspartner
        Kunde
        Lieferant
        ZuMeiden
        Firma
        AnsprechpartnerBeiFirmenKontakt
    End Enum

    Sub main()

        EnumFlags()

        Dim locKontakte As KontaktKategorie
        Dim locShort As Short

        locKontakte = KontaktKategorie.Gesch�ftspartner
        'Typumwandlung von Aufz�hlung zu zu Grunde liegenden Datentyp...
        locShort = locKontakte
        locShort = KontaktKategorie.Firma

        '...und umgekehrt, was sich schon ein wenig kniffeliger darstellt:
        locKontakte = DirectCast([Enum].ToObject(GetType(KontaktKategorie), locShort), KontaktKategorie)

        Console.WriteLine(locKontakte)

        'Ermittelt den Namen des zu Grunde liegenden primitiven einer Aufz�hlung 
        Console.WriteLine([Enum].GetUnderlyingType(GetType(KontaktKategorie)).Name)

        'Ermittelt den Typnamen anhand einer Aufz�hlungsvariablen
        Console.WriteLine([Enum].GetUnderlyingType(locKontakte.GetType).Name)

        'Umwandlung in einen String
        Console.WriteLine(locKontakte.ToString())

        'Umwandlung zur�ck in ein Enum-Element aus einem String
        Dim locString As String = "Gesch�ftspartner"
        locKontakte = DirectCast([Enum].Parse(GetType(KontaktKategorie), locString), KontaktKategorie)

        Console.ReadLine()

    End Sub

    Sub EnumFlags()

        Dim locKontakte As KontaktKategorien
        locKontakte = KontaktKategorien.Freund Or KontaktKategorien.Gesch�ftspartner
        'Console.WriteLine(locKontakte)
        'Console.WriteLine(locKontakte.ToString())

        'Achtung bei Flags! Bits m�ssen ausmaskiert werden!
        'Diese Abfrage liefert das falsche Ergebnis!
        If locKontakte = KontaktKategorien.Gesch�ftspartner Then
            Console.WriteLine("Du bist ein Gesch�ftspartner")
        Else
            Console.WriteLine("Du bist kein Gesch�ftspartner")
        End If


        'So ist's richtig; diese Abfrage liefert das richtige Ergebnis:
        If (locKontakte And KontaktKategorien.Freund) = KontaktKategorien.Freund Then
            Console.WriteLine("Du bist ein Freund")
        Else
            Console.WriteLine("Du bist kein Freund")
        End If

        'Und so funktionieren Kombiabfragen:
        If locKontakte = (KontaktKategorien.Freund Or KontaktKategorien.Gesch�ftspartner) Then
            Console.WriteLine("Du bist ein Freund und ein Gesch�ftspartner")
        End If

        Console.ReadLine()

    End Sub

End Module

<Flags()> _
Public Enum KontaktKategorien
    Keine = 0
    Familie = 1
    Freund = 2
    Bekannter = 4
    Kollege = 8
    Gesch�ftspartner = 16
    Kunde = 32
    Lieferant = 64
    ZuMeiden = 128
    Firma = 256
    AnsprechpartnerBeiFirmenKontakt = 512
End Enum
