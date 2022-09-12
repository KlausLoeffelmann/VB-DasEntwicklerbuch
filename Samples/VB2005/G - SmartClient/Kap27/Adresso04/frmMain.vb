Public Class frmMain

    Private myAdressen As Adressen              ' Alle Adressen

    'Dieses hier nicht als Ereignis einbinden - wäre von hinten, durch die Brust, ins Auge...
    'Besser überschreiben - frmListenForm ist schließlich von Form abgeleitet!
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Basismethode aufrufen, damit das Formular machen kann,
        'was es machen muss, um Alles einzurichten.
        MyBase.OnLoad(e)

        'Instanzieren.
        myAdressen = New Adressen

        'Die Listview-Spalten einrichten.
        Vorbereitungen()

        'Die Adressenliste darstellen.
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
                .Add(My.Resources.Spalte_Matchcode, -2)
                .Add(My.Resources.Spalte_Nachname, -2)
                .Add(My.Resources.Spalte_Vorname, -2)
                .Add(My.Resources.Spalte_Straße, -2)
                .Add(My.Resources.Spalte_PLZ, -2)
                .Add(My.Resources.Spalte_Ort, -2)
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
        myAdressen.ForEach(New Action(Of Adresse)(AddressOf ElementInListe))

        'So werden die Spaltenbreiten optimal angepasst.
        For Each locCol As ColumnHeader In Me.lvwAdressen.Columns
            locCol.Width = -2
        Next

        'Aufbau der ListView ist beendet.
        Me.lvwAdressen.EndUpdate()
    End Sub

    'Der Action-Delegat: für jedes Element der Liste wird diese Aktion durchgeführt.
    Sub ElementInListe(ByVal Element As Adresse)
        'Neues ListView-Element - Matchcode kommt zuerst.
        Dim locLvwItem As New ListViewItem(Element.Matchcode)

        'Die Untereinträge setzen
        With locLvwItem.SubItems
            .Add(Element.Name)
            .Add(Element.Vorname)
            .Add(Element.Straße)
            .Add(Element.PLZ)
            .Add(Element.Ort)
        End With

        'Zum Wiederfinden Referenz in Tag
        locLvwItem.Tag = Element

        'Zur Listview hinzufügen
        lvwAdressen.Items.Add(locLvwItem)
    End Sub

    'Wird aufgerufen, wenn eine der Spalten angeklickt wird.
    Private Sub lvwAdressen_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwAdressen.ColumnClick

        'Spaltennummer, die in e.Column steht, in AdressenSortierenNach konvertieren
        Dim locNach As AdressenSortierenNach = CType(e.Column, AdressenSortierenNach)

        'Sortieren
        myAdressen.Sortieren(locNach)

        'Die Elemente neu sortiert darstellen
        ElementeDarstellen()
    End Sub

    'Wird aufgerufen, wenn der Anwender im Menü Bearbeiten 
    'den Menüpunkt Neue Adresse erfassen anklickt.
    Private Sub tsmNeueAdresseErfassen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNeueAdresseErfassen.Click

        'Nur aktualisieren, wenn das Neuanlegen erfolgreich war.
        If myAdressen.NeueAdresse() Then
            ElementeDarstellen()
        End If

    End Sub

    'Wird aufgerufen, wenn der Anwender im Menü Bearbeiten 
    'den Menüpunkt Adresse bearbeiten anklickt.
    Private Sub tsmAdresseBearbeiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAdresseBearbeiten.Click

        'Herausfinden, ob es überhaupt eine selektierte Adresse gibt
        If lvwAdressen.SelectedIndices.Count > 0 Then

            'Erste selektierte Adresse wird bearbeitet
            Dim locAdresse As Adresse = DirectCast(lvwAdressen.SelectedItems(0).Tag, Adresse)

            'Nur aktualisieren, wenn das Bearbeiten erfolgreich war.
            If myAdressen.AdresseBearbeiten(locAdresse) Then
                ElementeDarstellen()
            End If
        End If

    End Sub

    'Wird aufgerufen, wenn der Anwender aus dem Menü Bearbeiten den Menüpunkt Löschen aufruft
    Private Sub tsmAdressenLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAdressenLöschen.Click

        If lvwAdressen.SelectedItems.Count > 0 Then
            Dim locDr As DialogResult = MessageBox.Show(My.Resources.MB_Nachfrage_Löschen_Body, _
                                My.Resources.MB_Nachfrage_Löschen_Titel, MessageBoxButtons.YesNo, _
                                MessageBoxIcon.Question)
            If locDr = Windows.Forms.DialogResult.Yes Then
                For Each lvwItem As ListViewItem In lvwAdressen.SelectedItems
                    myAdressen.Remove(DirectCast(lvwItem.Tag, Adresse))
                Next
                ElementeDarstellen()
            End If
        End If

    End Sub

    Private Sub tsmAdresseSuchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAdresseSuchen.Click
        Dim locSuchFormular As New frmSuchen
        Dim locErsterGefundener As Boolean

        'Den Suchbegriff merken, damit der Predicate-Delegat darauf 
        'zugreifen kann.
        Dim locSuchbegriff As String = locSuchFormular.Suchbegriff
        If String.IsNullOrEmpty(locSuchbegriff) Then
            Return
        End If

        'Alle gefundenen Elemente durchlaufen, und...
        For Each locAdresse As Adresse In myAdressen.Suchen(locSuchbegriff)

            'jeweils alle ListView-Elemente durchsuchen und überprüfen, ob ...
            For Each locLvwItem As ListViewItem In Me.lvwAdressen.Items

                '... die Tag-Referenz der Referenz des gesuchten Objekts entspricht.
                If locLvwItem.Tag Is locAdresse Then

                    'Gefunden! ListView-Element markieren,
                    locLvwItem.Selected = True

                    'und dafür sorgen, dass es der erste gefundene 
                    'Eintrag im sichtbaren Bereich liegt.
                    If Not locErsterGefundener Then
                        locLvwItem.EnsureVisible()
                        locErsterGefundener = True
                    End If

                    'Gefunden, wir müssen in der ListView
                    'nicht weitersuchen!
                    Exit For
                End If
            Next
        Next
    End Sub

    'Wird aufgerufen, wenn der Anwender Zufallsadresse anfügen anklickt.
    Private Sub tsmZufallsadressenAnfügen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmZufallsadressenAnfügen.Click

        '20 Zufallsadressen als Adressen-Auflistung generieren.
        For Each locAdresse As Adresse In Adressen.ZufallsAdressen(20)
            myAdressen.Add(locAdresse)
        Next
        ElementeDarstellen()
    End Sub

    'Wird aufgerufen, wenn Anwender Datei/Adressliste öffnen wählt.
    Private Sub tsmAdresslisteLaden_Click(ByVal sender As System.Object, _
                        ByVal e As System.EventArgs) Handles tsmAdresslisteLaden.Click

        Dim dateiÖffnenDialog As New OpenFileDialog
        With dateiÖffnenDialog
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.xml"
            .Filter = "Adresso XML-Dateien" & " (" & "*.adrxml" & ")|" & "*.adrxml" & "|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Adressen deserialisieren
            myAdressen = Adressen.XmlDeserialize(.FileName)

            'Liste neu darstellen
            ElementeDarstellen()
        End With
    End Sub

    'Wird aufgerufen, wenn Anwender Datei/Adressliste speichern wählt.
    Private Sub tsmAdresslisteSpeichern_Click(ByVal sender As System.Object, _
                        ByVal e As System.EventArgs) Handles tsmAdresslisteSpeichern.Click

        Dim dateiSpeichernDialog As New SaveFileDialog

        With dateiSpeichernDialog
            .CheckPathExists = True
            .DefaultExt = "*.xml"
            .Filter = "Adresso XML-Dateien" & " (" & "*.adrxml" & ")|" & "*.adrxml" & "|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            'Adressen serialisieren
            myAdressen.XMLSerialize(.FileName)
        End With
    End Sub

    'Wird ausgelöst, wenn der Anwender einen Eintrag oder mehrere Einträge der Liste selektiert
    Private Sub lvwAdressen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwAdressen.SelectedIndexChanged

        If lvwAdressen.SelectedIndices.Count = 0 Then

            'Kein Eintrag selektiert
            tsslAusgewählteAdresse.Text = "Keine Adresse selektiert"
        ElseIf lvwAdressen.SelectedIndices.Count > 1 Then

            'Mehrere Einträge selektiert
            tsslAusgewählteAdresse.Text = "Mehrere Adressen selektiert"
        Else

            'Genau ein Eintrag selektiert, dann die Grunddaten und das Geburtsdatum darstellen
            Dim locAdresse As Adresse

            'Das ursprüngliche Adresse-Objekt aus der Liste holen.
            'Dieses wurde beim Erstellen der ListViewItems in deren
            'Tag-Eigenschaften gespeichert, und auf diese Weise wird
            'die Relation zwischen Listeneintrag und eigentlichem Objekt hergestellt.
            locAdresse = DirectCast(lvwAdressen.SelectedItems(0).Tag, Adresse)

            'Text für die Darstellung in der Statuszeile zusammenbasteln:
            Dim locStatusText As String
            locStatusText = locAdresse.Matchcode & ": "
            locStatusText &= locAdresse.Name & ", " & locAdresse.Vorname & " - Geboren am "
            locStatusText &= locAdresse.Geburtsdatum.ToLongDateString

            'Text in der Statuszeile darstellen.
            tsslAusgewählteAdresse.Text = locStatusText
        End If
    End Sub

    Private Sub tsmSchnellerfassung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSchnellerfassung.Click
        myAdressen.Schnellerfassung()
        ElementeDarstellen()
    End Sub

    Private Sub tsmProgrammBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmProgrammBeenden.Click
        Me.Close()
    End Sub
End Class
