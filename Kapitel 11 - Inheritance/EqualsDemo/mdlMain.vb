Module mdlMain

    Sub Main()

        'Instanzieren mit New und dadurch
        'Speicher für das Kontakt-Objekt
        'auf dem Managed Heap anlegen
        Dim objVarKontakt As New Kontakt With {
            .Nachname = "Halek",
            .Vorname = "Sarah",
            .Plz = "99999",
            .Ort = "Musterhausen"}

        'objVarKontakt2 zeigt auf dasselbe Objekt;
        'die referenzierte Instanz ist dieselbe!
        Dim objVarKontakt2 As Kontakt
        objVarKontakt2 = objVarKontakt

        'objVarKontakt3 zeigt auf ein gleiches Objekt;
        'die referenzierte Instanz ist nicht dieselbe, nur die gleiche!
        Dim objVarKontakt3 As New Kontakt With {
                        .Nachname = "Halek",
                        .Vorname = "Sarah",
                        .Plz = "99999",
                        .Ort = "Musterhausen"}

        'Der Beweis dafür:
        Console.WriteLine("Die Aussage ""objVarKontakt entspricht objVarKontakt2 ist "" " & _
            objVarKontakt.Equals(objVarKontakt2))

        Console.WriteLine("Die Aussage ""objVarKontakt entspricht objVarKontakt3 ist "" " & _
            objVarKontakt.Equals(objVarKontakt3))

        Console.WriteLine()

        'Alternativ durch das IS-Schlüsselwort:
        Console.WriteLine("Die Aussage ""objVarKontakt entspricht objVarKontakt2 ist "" " & _
            (objVarKontakt Is objVarKontakt2))

        Console.WriteLine("Die Aussage ""objVarKontakt entspricht objVarKontakt3 ist "" " & _
            (objVarKontakt Is objVarKontakt3))

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste drücken")
        Console.ReadKey()
    End Sub

End Module

Class Kontakt

    Public Property Nachname As String
    Public Property Vorname As String
    Public Property Plz As String
    Public Property Ort As String

End Class

