Module mdlMain

    Sub Main()

        'Instanzieren mit New und dadurch
        'Speicher f�r das Kontakt-Objekt
        'auf dem Managed Heap anlegen
        Dim objVarKontakt As New Kontakt With
            {.Nachname = "Halek",
            .Vorname = "Sarah",
            .Plz = "99999",
            .Ort = "Musterhausen"}

        'Nur Objektvariable anlegen,
        'es wird aber kein Speicher reserviert!
        Dim objVarKontakt2 As Kontakt

        'objVarKontakt2 "zeigt" ab jetzt auf
        'die selbe Instanz wie objVarKontakt
        objVarKontakt2 = objVarKontakt

        'Und das kann man auch beweisen:
        'Das �ndern der Instanz geschieht...
        objVarKontakt2.Nachname = "L�ffelmann"

        'durch beide Objektvariablen, die nat�rlich
        'auch dasselbe widerspiegeln.
        Console.WriteLine(objVarKontakt.Nachname)

        Console.WriteLine()
        Console.WriteLine("Zum Beenden Taste dr�cken")
        Console.ReadKey()
    End Sub

End Module

Class Kontakt

    Public Property Nachname As String
    Public Property Vorname As String
    Public Property Plz As String
    Public Property Ort As String

End Class
