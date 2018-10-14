Public Class Main

    Shared Sub Main()

        'Text ausgeben; Anwender zur Eingabe auffordern
        Console.Write("Geben Sie eine Zahl zwischen 1 und 3.999 ein: ")

        'Zahl als Text einlesen, mit der statischen Methode Parse 
        'in Integer umwandeln...
        Dim locInt As Integer = Integer.Parse(Console.ReadLine)

        'und das Ergebnis der Klasseninstanz zuweisen
        'An dieser Stelle befindet sich der Haltepunkt!
        Dim locRomanNumeral As New RomanNumerals(locInt)

        'Das römische Literale ausgeben, das in der Klasseninstanz gespeichert ist
        Console.WriteLine("Entspricht dem römischen Numerale " & locRomanNumeral.ToRomanNumeral)

        'Nur für den Abstand.
        Console.WriteLine()

        'Wert mit der neuen Eigenschaft verändern.
        locRomanNumeral.UnderlyingValue = 200

        'und neues Ergebnis ausgeben
        Console.WriteLine("und 200 entspricht dem römischen Numerale " & locRomanNumeral.ToRomanNumeral)

        'Nur für den Abstand.
        Console.WriteLine()

        'Hier wird auf die Default-Eigenschaft zugegriffen.
        For locCount As Integer = 0 To 6
            Console.WriteLine("Element Nr. {0} entspricht römischen Numeral {1}", locCount, locRomanNumeral(locCount))
        Next

        'Dies nur noch, damit nicht alles sofort wieder verschwindet.
        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden...")
        Console.ReadLine()

    End Sub

End Class
