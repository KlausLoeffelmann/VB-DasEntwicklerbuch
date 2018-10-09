Option Strict On

'Co-Variance Demo
Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Mitarbeiter mithilfe von Auflistungs-Initialisierern füllen
        Dim mitarbeiter As New List(Of Mitarbeiter) From {
                    New Mitarbeiter With {.IDMitarbeiter = 1, .Nachname = "Leenings", .Vorname = "Ramona"},
                    New Mitarbeiter With {.IDMitarbeiter = 3, .Nachname = "Heckhuis", .Vorname = "Jürgen"},
                    New Mitarbeiter With {.IDMitarbeiter = 2, .Nachname = "Löffelmann", .Vorname = "Klaus"},
                    New Mitarbeiter With {.IDMitarbeiter = 3, .Nachname = "Pusch", .Vorname = "Marcus"},
                    New Mitarbeiter With {.IDMitarbeiter = 2, .Nachname = "Belke", .Vorname = "Andreas"}}

        Dim lieferanten As New List(Of Lieferant) From {
                    New Lieferant With {.IDLieferant = 1, .Nachname = "Thiemann", .Vorname = "Uwe"},
                    New Lieferant With {.IDLieferant = 2, .Nachname = "Löffelmann", .Vorname = "Klaus"},
                    New Lieferant With {.IDLieferant = 3, .Nachname = "Grauthof", .Vorname = "Kristin"}}

        'Wir können mit der Methode sowohl "mitarbeiter" als auch "lieferanten" verarbeiten, 
        'da beide Klassen, auf denen die Liste basieren, von AdressenBasis abgeleitet sind.
        'Eigentlich darf das nicht sein, da die Möglichkeit bestünde, so inhomogene Listen
        'zu schaffen. Kommt aber in diesem Fall nicht in Frage, da IEnumerable mit
        'OUT für seinen Typparameter definiert ist. Man kann die Liste also nur auslesen,
        'keine Elemente hinzufügen - und deswegen ist die Anwendung auf folgende Weise sicher:
        ListeAusgeben(mitarbeiter)
        ListeAusgeben(lieferanten)

        Dim comp As New AdressenBasisComparer()

        'Contra-Variance ist der Umgekehrte Fall.
        'Mitarbeiter wird für den Comparer erwartet, 
        'wir übergeben aber einen vom Typ AdressenBasis
        Dim ohneDubletten = mitarbeiter.Distinct(comp)
        ListeAusgeben(ohneDubletten)

    End Sub

    ''' <summary>
    ''' Druckt den Inhalt einer auf AdressenBasis basierenden Liste 
    ''' im Ausgabefenster aus (Debug/Windows/Output).
    ''' </summary>
    ''' <param name="adressenListe">Auf AdressenBasis basierende, unveränderliche Liste.</param>
    ''' <remarks></remarks>
    Sub ListeAusgeben(ByVal adressenListe As IEnumerable(Of AdressenBasis))
        For Each item In adressenListe
            Debug.Print(item.Nachname & ", " & item.Vorname)
        Next
    End Sub

    Sub WasNichtGeht()

        Dim basisListe As List(Of AdressenBasis)
        Dim abgeleiteteListe As New List(Of Mitarbeiter)

        'Das ist nicht erlaubt:
        'basisListe = abgeleiteteListe

    End Sub

End Class

Public Class AdressenBasis

    Property Vorname As String
    Property Nachname As String

End Class

Public Class Mitarbeiter
    Inherits AdressenBasis
    Implements IComparable(Of Mitarbeiter)

    Property IDMitarbeiter As Integer

    Public Function CompareTo(ByVal other As Mitarbeiter) As Integer _
        Implements System.IComparable(Of Mitarbeiter).CompareTo
        Return (Me.Nachname & Me.Vorname).CompareTo(other.Nachname & other.Vorname)
    End Function

End Class

Public Class Lieferant
    Inherits AdressenBasis

    Property IDLieferant As Integer
End Class

Public Class AdressenBasisComparer
    Implements IEqualityComparer(Of AdressenBasis)

    Public Function Equals1(ByVal x As AdressenBasis, ByVal y As AdressenBasis) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of AdressenBasis).Equals
        If (Object.ReferenceEquals(x, y)) Then Return True

        If (Object.ReferenceEquals(x, Nothing) OrElse
            Object.ReferenceEquals(y, Nothing)) Then
            Return False
        End If

        Return (x.Nachname = y.Nachname) AndAlso (x.Vorname = y.Vorname)
    End Function

    Public Function GetHashCode1(ByVal obj As AdressenBasis) As Integer Implements System.Collections.Generic.IEqualityComparer(Of AdressenBasis).GetHashCode
        If obj Is Nothing Then Return 0

        Dim hashVorname = If(obj.Vorname Is Nothing, 0, obj.Vorname.GetHashCode)
        Dim hashNachname = If(obj.Nachname Is Nothing, 0, obj.Nachname.GetHashCode)
        Return hashNachname Xor hashVorname
    End Function
End Class
