Public Class frmAdresseNeuUndBearbeiten

    'Hier steht das Ergebnis der beiden Funktionen
    Private myAdresse As Adresse

    'Delegat, mit dessen Hilfe ein doppelter Matchcode überprüft wird.
    Private myMatchcodeCheckenProc As Adressen.MatchcodeCheckenDelegate

    ''' <summary>
    ''' Stellt diesen Dialog dar, und ermittelt das Objekt einer neuen Adresse.
    ''' </summary>
    ''' <param name="matchcodeChecken">Delegat, der auf eine Prozedur verweist, die doppelte 
    ''' Matchcodes in der Auflistung überprüft.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NeueAdresse(ByVal matchcodeChecken As Adressen.MatchcodeCheckenDelegate) As Adresse

        'Damit wird dafür gesorgt, dass die Ressourcen für das Formular
        'nach Aufruf sofort wieder freigegeben werden!
        Using Me
            'Dialogtitel anpassen
            Me.Text = "Adresse bearbeiten"

            'Delegaten zuordnen - den brauchen wir später, um auf doppelte Matchcodes zu prüfen.
            myMatchcodeCheckenProc = matchcodeChecken

            'Dialog modal darstellen. Das Programm "hält" an dieser 
            'Stelle quasi an, und nur noch Ereignisse innerhalb 
            'dieses Formulars werden verarbeitet.
            Me.ShowDialog()

            'Hier geht's erst weiter, wenn OK oder Abbrechen geklickt wurde.
            Return myAdresse
        End Using
    End Function

    ''' <summary>
    ''' Stellt diesen Dialog dar, lässt den Anwender eine Adresse bearbeiten und liefert
    ''' ein neues Adresse-Objekt zurück, das die Änderungen widerspiegelt.
    ''' </summary>
    ''' <param name="adr">Adresse-Objekt, das bearbeitet wird. 
    ''' ACHTUNG! Das Rückgabeobjekt stellt eine neuen Instanz dar!</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AdresseBearbeiten(ByVal adr As Adresse) As Adresse

        'Damit wird dafür gesorgt, dass die Ressourcen für das Formular
        'nach Aufruf sofort wieder freigegeben werden!
        Using Me
            'Dialogtitel anpassen
            Me.Text = "Adresse bearbeiten"

            'Daten in die Maske kopieren.
            DatenInMaske(adr)

            'Matchcode darf nicht editiert werden:
            txtMatchcode.ReadOnly = True

            'Dialog modal darstellen. Das Programm "hält" an dieser 
            'Stelle quasi an, und nur noch Ereignisse innerhalb 
            'dieses Formulars werden verarbeitet.
            Me.ShowDialog()

            'Hier geht's erst weiter, wenn OK oder Abbrechen geklickt wurde.
            Return myAdresse
        End Using

    End Function

    'Wird aufgerufen beim Auslösen von OK-Schaltfläche.
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'Das Zuordnen eines Wertes für Dialogresult beendet den Dialog.
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    'Wird aufgerufen beim Auslösen von Abbrechen-Schaltfläche.
    Private Sub btnAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbbrechen.Click

        'Das Zuordnen eines Wertes für Dialogresult beendet den Dialog.
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    'Wird aufgerufen, wenn das Formular geschlossen werden soll.
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        'Überprüfung des Formulars nur, wenn OK geklickt wurde:
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            'Daten aus Maske gibt ein Adresse-Objekt nur dann zurück,
            'wenn die Daten in Ordnung waren.
            myAdresse = DatenAusMaske()

            'Wenn myAdresse also Nothing und damit NICHT in Ordnung war, ...
            If myAdresse Is Nothing Then

                '... bleibt der Dialog, der ja eigentlich geschlossen werden soll,
                'offen - und das erreichen wir durch Setzen von
                e.Cancel = True
            End If
        Else
            'Dieser Zeile kann nur erreicht werden, wenn Abbrechen
            'ausgelöst wurde. Dann wird auf jeden Fall Nothing als
            'Funktionsergebnis zurückgegeben.
            myAdresse = Nothing
        End If
    End Sub

    'Überprüft die Eingaben im Formular, und liefert
    'im Erfolgsfall ein fix-und-fertiges Adresse-Objekt
    'aus den Eingabefeldern zurück.
    Private Function DatenAusMaske() As Adresse

        Dim locFehler As Boolean

        'Alle möglichen Vorherigen Fehler zurücksetzen
        ErrProv.Clear()

        'Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(txtMatchcode.Text) Then

            'Fehlermeldung setzen.
            ErrProv.SetError(txtMatchcode, "Fehlende Eingabe!")
            locFehler = locFehler Or True

        Else

            'Der Delegat ist nur beim Neuanlegen einer Adresse vorhanden,
            'deswegen auf Vorhandensein überprüfen!
            If myMatchcodeCheckenProc IsNot Nothing Then
                'Feststellen, ob der Matchcode in der Auflistung schon existiert!
                'Das passiert in unserem Fall über einen Delegaten.
                If myMatchcodeCheckenProc.Invoke(txtMatchcode.Text) Then
                    ErrProv.SetError(txtMatchcode, "Dieser Matchcode ist schon vorhanden!")
                    locFehler = locFehler Or True
                End If

            End If
        End If

        'Ähnlich bei allen anderen vorgehen.
        If String.IsNullOrEmpty(txtVorname.Text) Then
            ErrProv.SetError(txtVorname, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(txtNachname.Text) Then
            ErrProv.SetError(txtNachname, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(txtStraße.Text) Then
            ErrProv.SetError(txtStraße, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        Dim locGebDate As Date
        If Not Date.TryParse(mtbGeburtsdatum.Text, locGebDate) Then
            ErrProv.SetError(mtbGeburtsdatum, "Falsches Datumsformat!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(txtOrt.Text) Then
            ErrProv.SetError(txtOrt, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        'Fehler war vorhanden - Nothing zurückliefern
        If locFehler Then Return Nothing

        'Alles war OK, es gibt eine neue Adresse.
        Return New Adresse(txtMatchcode.Text, txtNachname.Text, _
                           txtVorname.Text, txtStraße.Text, _
                           mtbPlz.Text, txtOrt.Text, locGebDate)
    End Function

    'Kopiert ein vorhandenes Adresse-Objekt in die Maske
    'für das weitere Bearbeiten.
    Private Sub DatenInMaske(ByVal adr As Adresse)
        txtMatchcode.Text = adr.Matchcode
        txtVorname.Text = adr.Vorname
        txtNachname.Text = adr.Name
        txtStraße.Text = adr.Straße
        mtbPlz.Text = adr.PLZ
        txtOrt.Text = adr.Ort
        mtbGeburtsdatum.Text = adr.Geburtsdatum.ToShortDateString
        lblWochentag.Text = adr.Geburtsdatum.ToString("dddd")
    End Sub

    Private Sub mtbGeburtsdatum_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbGeburtsdatum.LostFocus
        Dim locGebDatum As Date
        If Date.TryParse(mtbGeburtsdatum.Text, locGebDatum) Then
            lblWochentag.Text = locGebDatum.ToString("dddd")
        End If
    End Sub
End Class