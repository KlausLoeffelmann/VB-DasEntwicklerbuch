Public Class Main

    Shared Sub Main()

        'Text ausgeben; Anwender zur Eingabe auffordern
        Console.Write("Geben Sie eine Zahl zwischen 1 und 3.999 ein: ")

        'Zahl als Text einlesen, mit der statischen Methode Parse in Integer
        'umwandeln und das Ergebnis der Klasseninstanz zuweisen
        Dim locRomanNumeral As New RomanNumerals(Integer.Parse(Console.ReadLine))


        'Das römische Literale ausgeben, das in der Klasseninstanz gespeichert ist
        Console.WriteLine("Entspricht dem römischen Numerale " & locRomanNumeral.ToRomanNumeral)

        'Dies nur noch, damit nicht alles sofort wieder verschwindet
        Console.WriteLine()
        Console.WriteLine("Taste zum Beenden drücken...")
        Console.ReadKey()

    End Sub

End Class
