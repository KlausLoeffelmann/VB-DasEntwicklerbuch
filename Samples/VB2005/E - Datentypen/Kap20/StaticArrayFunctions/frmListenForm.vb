Imports System.Collections.ObjectModel

Public Class frmListenForm

    Private myAdressen As List(Of Adresse)      ' Alle Adressen
    Private myNach As AdressenSortierenNach     ' Aktuelle Sortierung
    Private myAktuellerSuchbegriff As String    ' Der zuletzt erfragte Suchbegriff

    'Dieses hier nicht als Ereignis einbinden - w�re von hinten, durch die Brust, ins Auge...
    'Besser �berschreiben - frmListenForm ist schlie�lich von Form abgeleitet!
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Basismethode aufrufen, damit das Formular machen kann,
        'was es machen muss, um alle einzurichten.
        MyBase.OnLoad(e)

        '50 Zufallsadressen als Collection(Of Adresse) generieren.
        myAdressen = Adresse.ZufallsAdressen(50)

        'Die Listview-Spalten einrichten
        Vorbereitungen()

        'Die generierten Zufallsadressen darstellen
        ElementeDarstellen()
    End Sub

    'Richtet lediglich die Listview ein.
    Sub Vorbereitungen()
        With Me.lvwAdressen
            'Alle Elemente l�schen.            
            .Items.Clear()
            With .Columns
                'Alle Spalten�berschriften l�schen.
                .Clear()
                'Spalten�berschriften einrichten.
                .Add("Nachname", -2)
                .Add("Vorname", -2)
                .Add("PLZ", -2)
                .Add("Ort", -2)
            End With
        End With
    End Sub

    Sub ElementeDarstellen()

        'Unterdr�ckt Neuzeichnen-Ereignisse bis zum
        'n�chsten EndUpdate; dadurch geht der Aufbau
        'der Elemente schneller und wackelt nicht.
        Me.lvwAdressen.BeginUpdate()

        'Alle Elemente der ListView l�schen.
        Me.lvwAdressen.Items.Clear()

        'F�r jedes Element der Liste wird ElementInListe aufgerufen.
        myAdressen.ForEach(New Action(Of Adresse)(AddressOf ElementInListe))

        'So werden die Spaltenbreiten optimal angepasst.
        For Each locCol As ColumnHeader In Me.lvwAdressen.Columns
            locCol.Width = -2
        Next

        'Aufbau der ListView ist beendet.
        Me.lvwAdressen.EndUpdate()
    End Sub

    'Der Action-Delegat: f�r jedes Element der Liste wird diese Aktion durchgef�hrt.
    Sub ElementInListe(ByVal Element As Adresse)
        'Neues ListView-Element - Name kommt zuerst.
        Dim locLvwItem As New ListViewItem(Element.Name)

        'Die Untereintr�ge setzen
        With locLvwItem.SubItems
            .Add(Element.Vorname)
            .Add(Element.PLZ)
            .Add(Element.Ort)
        End With

        'Zum Wiederfinden Referenz in Tag
        locLvwItem.Tag = Element

        'Zur Listview hinzuf�gen
        lvwAdressen.Items.Add(locLvwItem)
    End Sub

    'Wird aufgerufen, wenn eine der Spalten angeklickt wird.
    Private Sub lvwAdressen_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwAdressen.ColumnClick

        'Spaltennummer, die in e.Column steht, in AdressenSortierenNach konvertieren
        myNach = CType(e.Column, AdressenSortierenNach)

        'Die Auflistung mit Hilfe eines Comparison-Delegaten sortieren
        myAdressen.Sort(New Comparison(Of Adresse)(AddressOf AdressenVergleicher))

        'Die Elemente neu sortiert darstellen
        ElementeDarstellen()
    End Sub

    'Der Comparison-Delegat zum Vergleichen zweier Elemente.
    Function AdressenVergleicher(ByVal x As Adresse, ByVal y As Adresse) As Integer

        'Sortierung in Abh�ngigkeit von zuletzt angeklicktem
        'Spaltenkopf durchf�hren (siehe lvwAdressen_ColumnClick)
        Select Case myNach
            Case AdressenSortierenNach.Name
                Return x.Name.CompareTo(y.Name)
            Case AdressenSortierenNach.Ort
                Return x.Ort.CompareTo(y.Ort)
            Case AdressenSortierenNach.PLZ
                Return x.PLZ.CompareTo(y.PLZ)
            Case Else
                Return x.Vorname.CompareTo(y.Vorname)
        End Select
    End Function

    Private Sub btnSuchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuchen.Click

        'Suchbegriff abfragen
        Dim locSuchFormular As New frmSuchen

        'Den Suchbegriff merken, damit der Predicate-Delegat darauf 
        'zugreifen kann.
        myAktuellerSuchbegriff = locSuchFormular.Suchbegriff
        If String.IsNullOrEmpty(myAktuellerSuchbegriff) Then
            Return
        End If

        'Hier kann die Suche beginnen!
        Dim locGefundeneAdresse As Adresse = _
           myAdressen.Find(New Predicate(Of Adresse)(AddressOf AdressenFinder))

        'Wenn ein Element gefunden wurde, dieses markieren.
        If locGefundeneAdresse IsNot Nothing Then

            'Alle ListView-Elemente durchsuchen und �berpr�fen, ob ...
            For Each locLvwItem As ListViewItem In Me.lvwAdressen.Items

                '... die Tag-Referenz der Referenz des gesuchten Objekts entspricht.
                If locLvwItem.Tag Is locGefundeneAdresse Then

                    'Gefunden! ListView-Element markieren,
                    locLvwItem.Selected = True

                    'und daf�r sorgen, dass es im sichtbaren Bereich liegt.
                    locLvwItem.EnsureVisible()
                    Return
                End If
            Next
        End If
    End Sub

    'Der Predicate-Delegat zum Suchen eines Elements.
    Private Function AdressenFinder(ByVal adr As Adresse) As Boolean

        'Gesucht wird immer nach zuletzt ausgew�hltem Spaltenkopf.
        Select Case myNach
            Case AdressenSortierenNach.Name
                Return adr.Name = myAktuellerSuchbegriff
            Case AdressenSortierenNach.Ort
                Return adr.Ort = myAktuellerSuchbegriff
            Case AdressenSortierenNach.PLZ
                Return adr.PLZ = myAktuellerSuchbegriff
            Case Else
                Return adr.Vorname = myAktuellerSuchbegriff
        End Select
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class

Public Enum AdressenSortierenNach
    Name
    Vorname
    PLZ
    Ort
End Enum
