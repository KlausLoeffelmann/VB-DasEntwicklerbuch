Module Enums

    Public Enum KontaktKategorie As Short
        Familie
        Freund
        Bekannter
        Kollege
        Geschäftspartner
        Kunde
        Lieferant
        ZuMeiden
        Firma
        AnsprechpartnerBeiFirmenKontakt
    End Enum

    Sub main()

        'EnumFlags()

        Dim locKontakte As KontaktKategorie
        Dim locShort As Short

        locKontakte = KontaktKategorie.Geschäftspartner

        'Typumwandlung von Aufzählung zu zu Grunde liegenden Datentyp...
        locShort = locKontakte
        locShort = KontaktKategorie.Firma

        '...und umgekehrt, auch nicht schwieriger:
        locKontakte = CType(locShort, KontaktKategorie)

        Console.WriteLine(locKontakte)

        'Ermittelt den Namen des zu Grunde liegenden primitiven einer Aufzählung 
        Console.WriteLine([Enum].GetUnderlyingType(GetType(KontaktKategorie)).Name)

        'Ermittelt den Typnamen anhand einer Aufzählungsvariablen
        Console.WriteLine([Enum].GetUnderlyingType(locKontakte.GetType).Name)

        'Umwandlung in einen String
        Console.WriteLine(locKontakte.ToString())

        'Umwandlung zurück in ein Enum-Element aus einem String - schon anspruchsvoller!
        Dim locString As String = "Geschäftspartner"
        locKontakte = DirectCast([Enum].Parse(GetType(KontaktKategorie), locString), KontaktKategorie)

        'Mit dem .NET Framework 4.0 geht auch das ein wenig einfacher:
        If [Enum].TryParse(locString, locKontakte) Then
            Console.WriteLine("Enum-Wert Geschäftspartner wurde erkannt und umgewandelt!")
        End If
        Console.ReadLine()

        Dim test = "__̴ı̴̴̡̡̡ ̡͌l̡̡̡ ̡͌l̡*̡̡ ̴̡ı̴̴̡ ̡̡͡|̲̲̲͡͡͡ ̲▫̲͡ ̲̲̲͡͡π̲̲͡͡ ̲̲͡▫̲̲͡͡ ̲|̡̡̡ ̡ ̴̡ı̴̡̡ ̡͌l̡̡̡̡.__"

    End Sub

    Sub EnumFlags()

        Dim locKontakte As KontaktKategorien
        locKontakte = KontaktKategorien.Freund Or KontaktKategorien.Geschäftspartner
        'Console.WriteLine(locKontakte)
        'Console.WriteLine(locKontakte.ToString())

        'Achtung bei Flags! Bits müssen ausmaskiert werden!
        'Diese Abfrage liefert das falsche Ergebnis!
        If locKontakte = KontaktKategorien.Geschäftspartner Then
            Console.WriteLine("Du bist ein Geschäftspartner")
        Else
            Console.WriteLine("Du bist kein Geschäftspartner")
        End If


        'So ist's richtig; diese Abfrage liefert das richtige Ergebnis:
        If (locKontakte And KontaktKategorien.Freund) = KontaktKategorien.Freund Then
            Console.WriteLine("Du bist ein Freund")
        Else
            Console.WriteLine("Du bist kein Freund")
        End If

        'Mit dem .NET-Framework 4.0 geht das auch:
        If locKontakte.HasFlag(KontaktKategorien.Freund) Then
            Console.WriteLine("Du bist ein Freund")
        Else
            Console.WriteLine("Du bist kein Freund")
        End If

        'Und so funktionieren Kombiabfragen:
        If locKontakte = (KontaktKategorien.Freund Or KontaktKategorien.Geschäftspartner) Then
            Console.WriteLine("Du bist ein Freund und ein Geschäftspartner")
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
    Geschäftspartner = 16
    Kunde = 32
    Lieferant = 64
    ZuMeiden = 128
    Firma = 256
    AnsprechpartnerBeiFirmenKontakt = 512
End Enum
