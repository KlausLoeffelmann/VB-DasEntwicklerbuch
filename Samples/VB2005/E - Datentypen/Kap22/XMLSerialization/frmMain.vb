Imports System.Collections.ObjectModel

Public Class frmMain

    Private myAdressen As Adressen              ' Alle Adressen
    Private myNach As AdressenSortierenNach     ' Aktuelle Sortierung
    Private myAktuellerSuchbegriff As String    ' Der zuletzt erfragte Suchbegriff

    'Dieses hier nicht als Ereignis einbinden - wäre von hinten, durch die Brust, ins Auge...
    'Besser überschreiben - frmListenForm ist schließlich von Form abgeleitet!
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Basismethode aufrufen, damit das Formular machen kann,
        'was es machen muss, um alle einzurichten.
        MyBase.OnLoad(e)

        'Instanzieren.
        myAdressen = New Adressen

        'Die Listview-Spalten einrichten.
        Vorbereitungen()

        'Die generierten Zufallsadressen darstellen.
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
        'Neues ListView-Element - Name kommt zuerst.
        Dim locLvwItem As New ListViewItem(Element.Name)

        'Die Untereinträge setzen
        With locLvwItem.SubItems
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
        myNach = CType(e.Column, AdressenSortierenNach)

        'Die AUflistung mithilfe eines Comparison-Delegaten sortieren
        myAdressen.Sort(New Comparison(Of Adresse)(AddressOf AdressenVergleicher))

        'Die Elemente neu sortiert darstellen
        ElementeDarstellen()
    End Sub

    'Der Comparison-Delegat zum Vergleichen zweier Elemente.
    Function AdressenVergleicher(ByVal x As Adresse, ByVal y As Adresse) As Integer

        'Sortierung in Abhängigkeit von zuletzt angeklicktem
        'Spaltenkopf durchführen (siehe lvwAdressen_ColumnClick)
        Select Case myNach
            Case AdressenSortierenNach.Name
                Return x.Name.CompareTo(y.Name)
            Case AdressenSortierenNach.Ort
                Return x.Ort.CompareTo(y.Ort)
            Case AdressenSortierenNach.PLZ
                Return x.PLZ.CompareTo(y.PLZ)
            Case AdressenSortierenNach.Straße
                Return x.Straße.CompareTo(y.Straße)
            Case Else
                Return x.Vorname.CompareTo(y.Vorname)
        End Select
    End Function

    Private Sub tsmAdresseSuchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAdresseSuchen.Click
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

            'Alle ListView-Elemente durchsuchen und überprüfen, ob ...
            For Each locLvwItem As ListViewItem In Me.lvwAdressen.Items

                '... die Tag-Referenz der Referenz des gesuchten Objekts entspricht.
                If locLvwItem.Tag Is locGefundeneAdresse Then

                    'Gefunden! ListView-Element markieren,
                    locLvwItem.Selected = True

                    'und dafür sorgen, dass es im sichtbaren Bereich liegt.
                    locLvwItem.EnsureVisible()
                    Return
                End If
            Next
        End If
    End Sub

    'Der Predicate-Delegat zum Suchen eines Elements.
    Private Function AdressenFinder(ByVal adr As Adresse) As Boolean

        'Gesucht wird immer nach zuletzt ausgewähltem Spaltenkopf.
        Select Case myNach
            Case AdressenSortierenNach.Name
                Return adr.Name = myAktuellerSuchbegriff
            Case AdressenSortierenNach.Ort
                Return adr.Ort = myAktuellerSuchbegriff
            Case AdressenSortierenNach.PLZ
                Return adr.PLZ = myAktuellerSuchbegriff
            Case AdressenSortierenNach.Straße
                Return adr.Straße = myAktuellerSuchbegriff
            Case Else
                Return adr.Vorname = myAktuellerSuchbegriff
        End Select
    End Function

    Private Sub tsmAdressenLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmAdressenLöschen.Click
        If lvwAdressen.SelectedItems IsNot Nothing AndAlso lvwAdressen.SelectedItems.Count > 0 Then

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

    Private Sub tsmZufallsadressenAnfügen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmZufallsadressenAnfügen.Click

        '20 Zufallsadressen als Adressen-Auflistung generieren.
        For Each locAdresse As Adresse In Adressen.ZufallsAdressen(20)
            myAdressen.Add(locAdresse)
        Next
        ElementeDarstellen()
    End Sub

    'Wird aufgerufen, wenn der Anwender Datei/Adressliste öffnen wählt.
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

    'Wird aufgerufen, wenn der Anwender Datei/Adressliste speichern wählt.
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
End Class

Public Enum AdressenSortierenNach
    Name
    Vorname
    Straße
    PLZ
    Ort
End Enum
