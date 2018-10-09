Imports System.Collections.ObjectModel

Public Class frmListenForm

    Private mySortierenNach As AdressenSortierenNach    ' Aktuelle Sortierung
    Private myAdressen As List(Of Adresse)              ' Alle Adressen

    'Dieses hier nicht als Ereignis einbinden - wäre von hinten, durch die Brust, ins Auge...
    'Besser überschreiben - frmListenForm ist schließlich von Form abgeleitet!
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
            'Alle Elemente löschen.            
            .Items.Clear()
            With .Columns
                'Alle Spaltenüberschriften löschen.
                .Clear()
                'Spaltenüberschriften einrichten.
                .Add("Nachname", -2)
                .Add("Vorname", -2)
                .Add("PLZ", -2)
                .Add("Ort", -2)
            End With
        End With
    End Sub

    Sub ElementeDarstellen()

        'Unterdrückt Neuzeichnen-Ereignisse bis zum
        'nächsten EndUpdate; dadurch geht der Aufbau
        'der Elemente schneller und wackelt nicht.
        Me.lvwAdressen.BeginUpdate()

        'Alle Elemente der ListView löschen.
        Me.lvwAdressen.Items.Clear()

        'Für jedes Element der Liste wird ElementInListe aufgerufen.
        myAdressen.ForEach(Sub(element)
                               Dim locLvwItem As New ListViewItem(element.Name)

                               'Die Untereinträge setzen
                               With locLvwItem.SubItems
                                   .Add(element.Vorname)
                                   .Add(element.PLZ)
                                   .Add(element.Ort)
                               End With

                               'Zum Wiederfinden Referenz in Tag
                               locLvwItem.Tag = element

                               'Zur Listview hinzufügen
                               lvwAdressen.Items.Add(locLvwItem)

                           End Sub)

        'So werden die Spaltenbreiten optimal angepasst.
        For Each locCol As ColumnHeader In Me.lvwAdressen.Columns
            locCol.Width = -2
        Next

        'Aufbau der ListView ist beendet.
        Me.lvwAdressen.EndUpdate()
    End Sub

    'Wird aufgerufen, wenn eine der Spalten angeklickt wird.
    Private Sub lvwAdressen_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwAdressen.ColumnClick

        'Spaltennummer, die in e.Column steht, in AdressenSortierenNach konvertieren
        mySortierenNach = CType(e.Column, AdressenSortierenNach)

        Select Case mySortierenNach
            Case AdressenSortierenNach.Name
                myAdressen.Sort(Function(adr1, adr2) String.Compare(adr1.Name, adr2.Name))

            Case AdressenSortierenNach.Vorname
                myAdressen.Sort(Function(adr1, adr2) String.Compare(adr1.Vorname, adr2.Vorname))

            Case AdressenSortierenNach.PLZ
                myAdressen.Sort(Function(adr1, adr2) String.Compare(adr1.PLZ, adr2.PLZ))

            Case AdressenSortierenNach.Ort
                'Mehrzeilige ginge natürlich auch ...
                myAdressen.Sort(Function(adr1, adr2)
                                    '... dann aber Return nicht vergessen!
                                    Return String.Compare(adr1.Ort, adr2.Ort)
                                End Function)

        End Select

        'Die Elemente neu sortiert darstellen
        ElementeDarstellen()
    End Sub

    Private Sub btnSuchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuchen.Click

        'Suchbegriff abfragen
        Dim suchFormular As New frmSuchen
        Dim aktuellerSuchbegriff As String    ' Der zuletzt erfragte Suchbegriff

        'Den Suchbegriff merken, damit der Predicate-Delegat darauf 
        'zugreifen kann.
        aktuellerSuchbegriff = suchFormular.Suchbegriff
        If String.IsNullOrEmpty(aktuellerSuchbegriff) Then
            Return
        End If

        'Hier kann die Suche beginnen!
        Dim locGefAdr As Adresse = Nothing

        Select Case mySortierenNach
            Case AdressenSortierenNach.Name
                locGefAdr = myAdressen.Find(Function(adr) adr.Name = aktuellerSuchbegriff)
            Case AdressenSortierenNach.Vorname
                locGefAdr = myAdressen.Find(Function(adr) adr.Vorname = aktuellerSuchbegriff)
            Case AdressenSortierenNach.PLZ
                locGefAdr = myAdressen.Find(Function(adr) adr.PLZ = aktuellerSuchbegriff)
            Case AdressenSortierenNach.Ort
                'Mehrzeilig ginge natürlich auch hier wieder ...
                locGefAdr = myAdressen.Find(Function(adr)
                                                '...dann aber - wieder - 'Return' nicht vergessen!
                                                Return adr.Ort = aktuellerSuchbegriff
                                            End Function)
        End Select

        'Wenn ein Element gefunden wurde, dieses markieren.
        If locGefAdr IsNot Nothing Then

            'Alle ListView-Elemente durchsuchen und überprüfen, ob ...
            For Each locLvwItem As ListViewItem In Me.lvwAdressen.Items

                '... die Tag-Referenz der Referenz des gesuchten Objekts entspricht.
                If locLvwItem.Tag Is locGefAdr Then

                    'Gefunden! ListView-Element markieren,
                    locLvwItem.Selected = True

                    'und dafür sorgen, dass es im sichtbaren Bereich liegt.
                    locLvwItem.EnsureVisible()
                    Return
                End If
            Next
        End If
    End Sub

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
