Module CompositeFormatting

    Sub Main()

        'ZweiteVersion()
        'Return

        Dim locBasisDatum As Date = #12/30/2005 1:12:32 PM#
        Dim locOffset As TimeSpan
        Dim locRandom As New Random(Now.Millisecond)

        'Backslash vor ', damit es gedruckt und nicht als Steuerzeichen interpretiert wird!
        Console.WriteLine("Es ist " + _
            locBasisDatum.ToString("dddd, ""den"" d. MMMM \'yy, HH:mm") + _
            "...")

        '15 Wiederholungen
        For count As Integer = 1 To 15
            locOffset = New TimeSpan(locRandom.Next(23), locRandom.Next(59), 0)
            locBasisDatum = locBasisDatum.Add(locOffset)
            Console.WriteLine("...und " + Math.Floor(locOffset.TotalHours).ToString() + _
                " Std. und " + locOffset.Minutes.ToString() + _
                " Min. später ist " _
                + locBasisDatum.ToString("dddd, ""der"" d. MMMM \'yy, HH:mm"))
        Next
        Console.ReadLine()

    End Sub

    Sub ZweiteVersion()

        Dim locBasisDatum As Date = #12/30/2005 1:12:32 PM#
        Dim locOffset As TimeSpan
        Dim locRandom As New Random(Now.Millisecond)

        With locBasisDatum
            Console.WriteLine("Es ist {0}, der {1}...", _
                .ToString("dddd"), _
                .ToString("d. MMMM \'yy, HH:mm"))

            '15 Wiederholungen
            For count As Integer = 1 To 15
                locOffset = New TimeSpan(locRandom.Next(23), locRandom.Next(59), 0)
                locBasisDatum = locBasisDatum.Add(locOffset)
                Console.WriteLine("...und {0} Std. und {1} Min. später ist {2}", _
                    Math.Floor(locOffset.TotalHours).ToString(), _
                    locOffset.Minutes.ToString(), _
                    locBasisDatum.ToString("dddd, ""der"" d. MMMM \'yy, HH:mm"))
            Next
        End With

        Console.ReadLine()

    End Sub

    Sub DritteVersion()

        Dim locBasisDatum As Date = #12/30/2005 1:12:32 PM#
        Dim locOffset As TimeSpan
        Dim locRandom As New Random(Now.Millisecond)

        With locBasisDatum
            Console.WriteLine("Es ist {0}, der {1}...", _
                .ToString("dddd"), _
                .ToString("d. MMMM \'yy, HH:mm"))

            '15 Wiederholungen
            For count As Integer = 1 To 15
                locOffset = New TimeSpan(locRandom.Next(23), locRandom.Next(59), 0)
                locBasisDatum = locBasisDatum.Add(locOffset)
                Console.WriteLine("...und {0,2} Std. und {1,2} Min. später ist {2,11}, der {3}", _
                    Math.Floor(locOffset.TotalHours).ToString(), _
                    locOffset.Minutes.ToString(), _
                    .ToString("dddd"), _
                    .ToString("dd. MMMM \'yy, HH:mm") _
                    )
            Next
        End With

        Console.ReadLine()

    End Sub

    Sub VierteVersion()

        Dim locBasisDatum As Date = #12/30/2005 1:12:32 PM#
        Dim locOffset As TimeSpan
        Dim locRandom As New Random(Now.Millisecond)

        Console.WriteLine("Es ist {0:dddd}, der {1:d. MMMM \'yy, HH:mm}...", _
            locBasisDatum.ToString(), _
            locBasisDatum)

        '15 Wiederholungen
        For count As Integer = 1 To 15
            locOffset = New TimeSpan(locRandom.Next(23), locRandom.Next(59), 0)
            locBasisDatum = locBasisDatum.Add(locOffset)
            Console.WriteLine("...und {0,2} Std. und {1,2} Min. später ist {2,11:dddd}, der {3:dd. MMMM \'yy, HH:mm}", _
                Math.Floor(locOffset.TotalHours).ToString(), _
                locOffset.Minutes.ToString(), _
                locBasisDatum, _
                locBasisDatum _
                )
        Next


        Console.ReadLine()

    End Sub


End Module
