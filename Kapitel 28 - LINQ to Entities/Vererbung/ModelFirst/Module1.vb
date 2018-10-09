Module Module1

    Sub Main()
        Dim context As New modelFirstContainer()

        Dim neuerMitarbeiter As New Mitarbeiter() With {.AngestelltSeit = Date.Now, .Geburtstag = Date.Now, .Nachname = "Müller", .Vorname = "Hans"}
        context.AddToMitarbeiter(neuerMitarbeiter)


        Dim neuerEntwickler As New Entwickler() With {.AngestelltSeit = Date.Now, .Geburtstag = Date.Now, .Nachname = "Müller", .Vorname = "Lisa", .Programmiersprache = "Visual Basic .NET"}
        context.AddToMitarbeiter(neuerEntwickler)

        context.SaveChanges()

    End Sub

End Module
