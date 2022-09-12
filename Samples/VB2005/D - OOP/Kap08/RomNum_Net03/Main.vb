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

        'Das r�mische Literale ausgeben, das in der Klasseninstanz gespeichert ist
        Console.WriteLine("Entspricht dem r�mischen Numerale " & locRomanNumeral.ToRomanNumeral)

        'Nur zum Testen.
        Dim locOtherRomanNumeral As New RomanNumerals("XXXIV")  ' < < < <

        'Dies nur noch, damit nicht alles sofort wieder verschwindet
        Console.WriteLine()
        Console.WriteLine("Return dr�cken zum Beenden...")
        Console.ReadLine()

    End Sub

End Class
