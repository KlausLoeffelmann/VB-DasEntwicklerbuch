Module Module1

    Sub Main()

        'Instanzieren mit New und dadurch
        'Speicher für das Kontakt-Objekt
        'auf dem Managed Heap anlegen.
        'Instanz gleichzeitig mit Daten initialisieren.
        Dim objVarKontakt As New Kontakt With {.Nachname = "Pfeiffer", _
                .Vorname = "Ute", .PLZ = "59555", .Ort = "Lippstadt"}

        'Nur Objektvariable anlegen,
        'es wird aber kein Speicher reserviert!
        Dim objVarKontakt2 As Kontakt

        'objVarKontakt2 "zeigt" ab jetzt auf
        'die selbe Instanz wie objVarKontakt
        objVarKontakt2 = objVarKontakt

        'Und das kann man auch beweisen:
        'Das Ändern der Instanz geschieht...
        objVarKontakt2.Nachname = "Dröge"

        'durch beide Objektvariablen, die natürlich
        'auch dasselbe widerspiegeln.
        Console.WriteLine(objVarKontakt.Nachname)

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste drücken")
        Console.ReadKey()
    End Sub

    Sub KlasseVerarbeiten()
        '.
        '.
        '.
        Dim tmpKontakt As New Kontakt
        tmpKontakt.Ort = Console.ReadLine

    End Sub
End Module

Public Class Kontakt
    Public Vorname As String
    Public Nachname As String
    Public PLZ As String
    Public Ort As String
End Class

