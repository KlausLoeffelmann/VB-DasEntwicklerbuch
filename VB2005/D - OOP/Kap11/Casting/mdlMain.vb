Module Module1

    Sub Main()

        Dim EinInteger As Integer
        Dim EinLong As Long = 1000
        'Dim EinLong As Long = Integer.MaxValue + 1L
        'EinInteger = EinLong
        EinInteger = CInt(EinLong)
        EinInteger = CType(EinLong, Integer)
        EinInteger = Convert.ToInt32(EinInteger)

        Dim EinStringMitDatum As String = "24122003"
        Dim EinAndererStringMitDatum As String = "2412"
        Dim EinStringMitDouble As String = "1.123,23 €"
        Dim EinDatum As DateTime
        Dim EinDouble As Double

        'Ein Array mit möglichen Datumsformaten für Date.ParseExact
        Dim DatumsformatierungsFormate() As String = New String() {"ddMMyyyy", "ddMM"}

        'Beispiele für Datumskonvertierung
        EinDatum = DateTime.ParseExact(EinStringMitDatum, _
                                       DatumsformatierungsFormate, _
                                       Nothing, _
                                       Globalization.DateTimeStyles.AllowWhiteSpaces)
        Console.WriteLine("Datum " & EinDatum.ToString("ddd, dd.MMM.yyyy"))

        EinDatum = DateTime.ParseExact(EinAndererStringMitDatum, _
                                       DatumsformatierungsFormate, _
                                       Nothing, _
                                       Globalization.DateTimeStyles.AllowWhiteSpaces)
        Console.WriteLine("Datum " & EinDatum.ToString("ddd, dd.MMM.yyyy"))

        'Zahlenbeispiele
        EinDouble = Double.Parse(EinStringMitDouble, Globalization.NumberStyles.Currency)
        Console.WriteLine("Wert " & EinDouble.ToString("#,###.## Euro"))


        'So können fehlerhafte Eingabeformate abgefangen werden:

        'Version 1: Mit TryParse (gibt's für Datum- und numerische Typen)
        If Double.TryParse("1.234,56", EinDouble) Then
            Console.WriteLine("Zeichenkette konnte geparst werden. Ergebnis: " & EinDouble.ToString)
        Else
            Console.WriteLine("Zeichenkette konnte nicht geparst werden!")
        End If

        'Version 2: Mit einer Ausnahmebehandlung
        Try
            'Das kann nicht klappen!
            EinDatum = DateTime.ParseExact("2005_12_24", _
                               DatumsformatierungsFormate, _
                               Nothing, _
                               Globalization.DateTimeStyles.AllowWhiteSpaces)

        Catch ex As Exception
            Console.WriteLine("Das Parsen generierte eine Ausnahme:" & vbNewLine & _
                ex.Message)
        End Try

        'Klassen-Casting
        Dim locEineKlasse As EineKlasse
        Dim locAbgeleiteteKlasse As AbgeleiteteKlasse = New AbgeleiteteKlasse

        'Implizites Casting möglich, denn es geht in der Erbhierachie nach oben
        locEineKlasse = locAbgeleiteteKlasse

        'Geht nicht, Funktion nicht vorhanden
        'locEineKlasse.AddValues()

        'Geht auch nicht; es geht in der Erbhierachie nach unten, und dann 
        'kann implizit kann nicht konvertiert werden:
        'locAbgeleiteteKlasse = locEineKlasse

        'So gehts: 
        locAbgeleiteteKlasse = DirectCast(locEineKlasse, AbgeleiteteKlasse)
        'Kommt auf's Selbe raus:
        locAbgeleiteteKlasse = CType(locEineKlasse, AbgeleiteteKlasse)
        locAbgeleiteteKlasse.AddValues()

        Console.WriteLine("Abgeleitet: " & locAbgeleiteteKlasse.ToString())
        Console.WriteLine("Wertepaar: " & locEineKlasse.ToString())


        'Boxen von Wertetypen
        Dim locObjectArray(9) As Object
        Dim locRandom As New Random(Now.Millisecond)
        Dim locMaxValue As Integer

        For locCount As Integer = 0 To 9
            'Implizites Casting ist möglich, es geht in der Erbhierachie nach oben
            'aber Deckung! - Hier wird geboxt!
            locObjectArray(locCount) = New Matrjoschka(locRandom.Next)
        Next

        'Rausfinden, welches das Objekt mit der höchsten Generationsnummer war
        For locCount As Integer = 0 To 9
            'Zwar sind nur Matrjoschka-Werte im Array drinn, doch das Array
            '"kann" nur Objects. Die Generation-Eigenschaft steht nicht zur
            'Verfügung, deswegen funktioniert diese Zeile nicht:
            'locMaxValue = locObjectArray(locCount).Generation
            Dim locMatrjoschka As Matrjoschka

            'Entboxen - aus dem Referenzierten Wertetyp wird wieder ein "echter" Wertetyp
            locMatrjoschka = DirectCast(locObjectArray(locCount), Matrjoschka)

            'Jetzt kommen wir an die Generation-Eigenschaft heran:
            If locMaxValue < locMatrjoschka.Generation Then
                locMaxValue = locMatrjoschka.Generation
            End If
        Next

        Console.WriteLine("Die höchste Generationsnummer war: " & locMaxValue.ToString())

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden!")
        Console.ReadLine()
    End Sub

End Module

Structure Matrjoschka
    Private myGeneration As Integer

    Sub New(ByVal Generation As Integer)
        myGeneration = Generation
    End Sub

    Property Generation() As Integer
        Get
            Return myGeneration
        End Get
        Set(ByVal Value As Integer)
            myGeneration = Value
        End Set
    End Property

End Structure

Class EineKlasse

    Protected Wert1 As Integer
    Protected Wert2 As Integer

    Sub New()
        Wert1 = 10
        Wert2 = 20
    End Sub

    Public Overrides Function ToString() As String
        Return Wert1.ToString
    End Function

End Class

Class AbgeleiteteKlasse
    Inherits EineKlasse

    Public Sub AddValues()
        Wert1 += Wert2
    End Sub

End Class

