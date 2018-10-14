Imports System.Globalization

Module Strings
    Sub Main()
        Dim locString As String = _
            "Weisheiten:" + vbNewLine + _
            "* Wenn man 8 Jahre, 7 Monate und 6 Tage schreien w�rde," + vbNewLine + _
            "  h�tte man genug Energie produziert, um eine Tasse Kaffee hei� zu machen." + vbNewLine + _
            "* Wenn man seinen Kopf gegen die Wand schl�gt, verbraucht man 150 Kalorien." + vbNewLine + _
            "* Elefanten sind die einzigen Tiere, die nicht springen k�nnen." + vbNewLine + _
            "* Eine Kakerlake kann 9 Tage ohne Kopf �berleben, bevor sie verhungert." + vbNewLine + _
            "* Gold und andere Metalle entstehen ausschlie�lich in" + vbNewLine + _
            "  Supernovae (Sternenexplosionen)." + vbNewLine + _
            "* Der Mond besteht aus den Tr�mmern der Kollision eines Mars-gro�en" + vbNewLine + _
            "  Planeten mit der Erde." + vbNewLine + _
            "* New York wird ""Big Apple genannt"", weil ""Big Apple"" in der Sprache" + vbNewLine + _
            "  der Jazz-Musiker.""das gro�e Los ziehen"" bedeutete. In New York Karriere" + vbNewLine + _
            "  zu machen war ihr gro�es Los." + vbNewLine + _
            "* Der Ausdruck ""08/15"" f�r etwas Unorginelles war urspr�nglich " + vbNewLine + _
            "  die Typenbezeichnung f�r das Maschinengewehr LMG 08/15;" + vbNewLine + _
            "  er wurde Metapher f�r geistlosen, milit�rischen Drill." + vbNewLine + _
            "* ""Durch die Lappen gehen"" ist ein Begriff aus der Jagd:" + vbNewLine + _
            "  Hirsche liefen nicht durch eine aus Lappen bestehende," + vbNewLine + _
            "  flatternde Umz�unung - aus Angst. Au�er manchmal."

        'Zahlenkombi durch Buchstaben ersetzen
        locString = locString.Replace("08/15", "Null-Acht-F�nfzehn")

        'Satzzeichen z�hlen
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
        Console.WriteLine("...verf�gt �ber {0} Satzzeichen.", locCount)
        Console.WriteLine()
        Console.WriteLine("Und sieht nach dem Ersetzen von 'Big Apple' durch 'Gro�er Apfel' so aus:")
        Console.WriteLine(New String("="c, 79))

        'Noch eine Ersetzung
        locString = locString.Replace("Big Apple", "Gro�er Apfel")
        Console.WriteLine(locString)
        Console.ReadLine()

    End Sub

End Module
