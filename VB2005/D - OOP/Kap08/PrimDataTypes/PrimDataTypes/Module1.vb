Module Module1

    Sub Main()

        '*****************************************************
        'Klassen bzw. Strukturen speichern Daten...
        '*****************************************************

        'Einen Decimal-Datentyp deklarieren und ihm den Wert 11.100,34 zuweisen
        Dim locDecimal As New Decimal(11100.34)
        Console.WriteLine("locDecimal enthält den Wert:  " & locDecimal)

        'Einen Date-Datentyp deklarieren und ihm den Wert "10.8.2005" zuweisen
        Dim locDate As New Date(2005, 8, 10)
        Console.WriteLine("locDate enthält den Wert:  " & locDate)

        'Eine Leerzeile
        Console.WriteLine()

        '*****************************************************
        '...stellen aber auch Programmcode zur Verfügung
        '*****************************************************

        Dim locAusgabe As String
        'ToString wandelt unter Angabe des Formats den Wert
        'von locDecimal in eine Zeichenkette um
        locAusgabe = locDecimal.ToString("#,##0.0000 $")
        Console.WriteLine("Formatierte Zahlenausgabe:  " & locAusgabe)

        'DayOfWeek bestimmt den Wochentag des angegebenen Datums.
        Dim locWochentag As Integer
        locWochentag = locDate.DayOfWeek
        Console.WriteLine("Der " & locDate & " war der " & locWochentag & ". Tag der Woche!")

        'Auf Tastendruck warten
        Console.ReadKey()
    End Sub

End Module
