Imports System.Globalization

Module Strings
    Sub Main()
        Dim locString As String = _
            "Weisheiten:" + vbNewLine + _
            "* Wenn man 8 Jahre, 7 Monate und 6 Tage schreien würde," + vbNewLine + _
            "  hätte man genug Energie produziert, um eine Tasse Kaffee heiß zu machen." + vbNewLine + _
            "* Wenn man seinen Kopf gegen die Wand schlägt, verbraucht man 150 Kalorien." + vbNewLine + _
            "* Elefanten sind die einzigen Tiere, die nicht springen können." + vbNewLine + _
            "* Eine Kakerlake kann 9 Tage ohne Kopf überleben, bevor sie verhungert." + vbNewLine + _
            "* Gold und andere Metalle entstehen ausschließlich in" + vbNewLine + _
            "  Supernovae (Sternenexplosionen)." + vbNewLine + _
            "* Der Mond besteht aus den Trümmern der Kollision eines Mars-großen" + vbNewLine + _
            "  Planeten mit der Erde." + vbNewLine + _
            "* New York wird ""Big Apple genannt"", weil ""Big Apple"" in der Sprache" + vbNewLine + _
            "  der Jazz-Musiker.""das große Los ziehen"" bedeutete. In New York Karriere" + vbNewLine + _
            "  zu machen war ihr großes Los." + vbNewLine + _
            "* Der Ausdruck ""08/15"" für etwas Unorginelles war ursprünglich " + vbNewLine + _
            "  die Typenbezeichnung für das Maschinengewehr LMG 08/15;" + vbNewLine + _
            "  er wurde Metapher für geistlosen, militärischen Drill." + vbNewLine + _
            "* ""Durch die Lappen gehen"" ist ein Begriff aus der Jagd:" + vbNewLine + _
            "  Hirsche liefen nicht durch eine aus Lappen bestehende," + vbNewLine + _
            "  flatternde Umzäunung - aus Angst. Außer manchmal."

        'Zahlenkombi durch Buchstaben ersetzen
        locString = locString.Replace("08/15", "Null-Acht-Fünfzehn")

        'Satzzeichen zählen
        Dim locPosition, locCount As Integer

        Do
            locPosition = locString.IndexOfAny(New Char() {"."c, ","c, ":"c, "?"c}, locPosition)
            If locPosition = -1 Then
                Exit Do
            Else
                locCount += 1
            End If
            locPosition += 1
        Loop

        Console.WriteLine("Der folgende Text...")
        Console.WriteLine(New String("="c, 79))
        Console.WriteLine(locString)
        Console.WriteLine(New String("="c, 79))
        Console.WriteLine("...verfügt über {0} Satzzeichen.", locCount)
        Console.WriteLine()
        Console.WriteLine("Und sieht nach dem Ersetzen von 'Big Apple' durch 'Großer Apfel' so aus:")
        Console.WriteLine(New String("="c, 79))

        'Noch eine Ersetzung
        locString = locString.Replace("Big Apple", "Großer Apfel")
        Console.WriteLine(locString)
        Console.ReadLine()

    End Sub

End Module
