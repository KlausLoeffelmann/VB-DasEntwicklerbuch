Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()

        Dim Adressen As New ArrayList() From
            {New Adresse With
                {.Vorname = "Ramona", .Nachname = "Leenings"},
            New Adresse With
                {.Vorname = "Arnold", .Nachname = "Löffelmann"},
            New Adresse With
                {.Vorname = "Margarete", .Nachname = "Schindler"}}

        Dim andereAdressen As New ArrayList() From
            {{"Klaus", "Löffelmann"},
             {"Andreas", "Belke"},
             {"Marcus", "Pusch"}}
    End Sub

    Public Class Adresse
        Public Property Vorname As String
        Public Property Nachname As String
        Public Property PLZ As String
        Public Property Ort As String
    End Class

End Module

Module AdressenCollectionInitializer

    'Das Extension-Attribut kennzeichnet eine Methode
    'als Erweiterungsmethode. Der Typ des ersten Parameters
    'bestimmt den Typ, der erweitert werden soll.
    <Extension()> _
    Public Sub Add(ByVal adressenListe As ArrayList,
                   ByVal Vorname As String,
                   ByVal Nachname As String)

        adressenListe.Add(New Adresse With {.Vorname = Vorname,
                                            .Nachname = Nachname})
    End Sub

End Module
