Module mdlMain

    Sub Main()

        Dim locGauge As New HighSpeedTimeGauge
        Dim locLoops As Integer = 1000000
        Dim locRandom As New Random(Now.Millisecond)

        Dim locDouble As Double
        Dim locDecimal As Decimal
        Dim locInt As Integer
        Dim loop1 As Integer
        Dim loop2 As Integer
        Dim charArray(7) As Char
        Dim locString As String

        For Durchläufe As Integer = 1 To 5
            locGauge.Start()
            For loop1 = 1 To locLoops
                locDouble = locRandom.Next(1, Integer.MaxValue \ 2)

                'Geht schneller als Convert.ToDecimal!
                locDecimal = New Decimal(locDouble)
                locDecimal *= 2

                'Damit der Compiler nichts wegoptimiert
                If locDecimal = 0 Then Exit For
                locInt = Convert.ToInt32(locDecimal)

                'Wieder damit der Compiler nichts wegoptimiert
                If locInt = 0 Then Exit For
                If locDouble = locInt Then Exit For

                'eine Zeichenkette aus Zufallszeichen erstellen
                'und in einen String packen; den String
                'anschließend in eine Zahl wandeln
                For loop2 = 0 To 7
                    charArray(loop2) = Convert.ToChar(locRandom.Next(8) + 49)
                Next

                locString = New String(charArray)
                locDouble = Double.Parse(locString)
                If locDouble = 0 Then Exit Sub

            Next
            locGauge.Stop()
            Console.WriteLine("{0} Programmdurchläufe mit Convert {1} Millisekunden.", _
                                locLoops, locGauge.DurationInMilliSeconds)
            locGauge.Reset()

            locGauge.Start()
            For loop1 = 1 To locLoops
                locDouble = locRandom.Next(1, Integer.MaxValue \ 2)

                'Geht schneller als Convert.ToDecimal!
                locDecimal = CDec(locDouble)
                locDecimal *= 2

                'Damit der Compiler nichts wegoptimiert
                If locDecimal = 0 Then Exit For
                locInt = CInt(locDecimal)

                'Wieder damit der Compiler nichts wegoptimiert
                If locInt = 0 Then Exit For
                If locDouble = locInt Then Exit For

                'eine Zeichenkette aus Zufallszeichen erstellen
                'und in einen String packen; den String
                'anschließend in eine Zahl wandeln
                For loop2 = 0 To 7
                    charArray(loop2) = ChrW(locRandom.Next(8) + 49)
                Next

                locString = CStr(charArray)
                locDouble = CDbl(locString)
                If locDouble = 0 Then Exit Sub

            Next
            locGauge.Stop()
            Console.WriteLine("{0} Programmdurchläufe mit CType {1} Millisekunden.", _
                                locLoops, locGauge.DurationInMilliSeconds)
            locGauge.Reset()
        Next Durchläufe

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden!")
        Console.ReadLine()

    End Sub

End Module
