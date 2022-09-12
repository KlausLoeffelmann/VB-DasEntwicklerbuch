Public Class frmAdresseNeuUndBearbeiten

    'Hier steht das Ergebnis der beiden Funktionen
    Private myAdresse As Adresse

    'Delegat, mit dessen Hilfe ein doppelter Matchcode �berpr�ft wird.
    Private myMatchcodeCheckenProc As Adressen.MatchcodeCheckenDelegate

    ''' <summary>
    ''' Stellt diesen Dialog dar, und ermittelt das Objekt einer neuen Adresse.
    ''' </summary>
    ''' <param name="matchcodeChecken">Delegat, der auf eine Prozedur verweist, die doppelte 
    ''' Matchcodes in der Auflistung �berpr�ft.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function NeueAdresse(ByVal matchcodeChecken As Adressen.MatchcodeCheckenDelegate) As Adresse

        'Damit wird daf�r gesorgt, dass die Ressourcen f�r das Formular
        'nach Aufruf sofort wieder freigegeben werden!
        Using Me
            'Dialogtitel anpassen
            Me.Text = "Adresse bearbeiten"

            'Delegaten zuordnen - den brauchen wir sp�ter, um auf doppelte Matchcodes zu pr�fen.
            myMatchcodeCheckenProc = matchcodeChecken

            'Dialog modal darstellen. Das Programm "h�lt" an dieser 
            'Stelle quasi an, und nur noch Ereignisse innerhalb 
            'dieses Formulars werden verarbeitet.
            Me.ShowDialog()

            'Hier geht's erst weiter, wenn OK oder Abbrechen geklickt wurde.
            Return myAdresse
        End Using
    End Function

    ''' <summary>
    ''' Stellt diesen Dialog dar, l�sst den Anwender eine Adresse bearbeiten und liefert
    ''' ein neues Adresse-Objekt zur�ck, das die �nderungen widerspiegelt.
    ''' </summary>
    ''' <param name="adr">Adresse-Objekt, das bearbeitet wird. 
    ''' ACHTUNG! Das R�ckgabeobjekt stellt eine neuen Instanz dar!</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AdresseBearbeiten(ByVal adr As Adresse) As Adresse

        'Damit wird daf�r gesorgt, dass die Ressourcen f�r das Formular
        'nach Aufruf sofort wieder freigegeben werden!
        Using Me
            'Dialogtitel anpassen
            Me.Text = "Adresse bearbeiten"

            'Daten in die Maske kopieren.
            DatenInMaske(adr)

            'Matchcode darf nicht editiert werden:
            txtMatchcode.ReadOnly = True

            'Dialog modal darstellen. Das Programm "h�lt" an dieser 
            'Stelle quasi an, und nur noch Ereignisse innerhalb 
            'dieses Formulars werden verarbeitet.
            Me.ShowDialog()

            'Hier geht's erst weiter, wenn OK oder Abbrechen geklickt wurde.
            Return myAdresse
        End Using

    End Function

    'Wird aufgerufen beim Ausl�sen von OK-Schaltfl�che.
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        'Das Zuordnen eines Wertes f�r Dialogresult beendet den Dialog.
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    'Wird aufgerufen beim Ausl�sen von Abbrechen-Schaltfl�che.
    Private Sub btnAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbbrechen.Click

        'Das Zuordnen eines Wertes f�r Dialogresult beendet den Dialog.
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    'Wird aufgerufen, wenn das Formular geschlossen werden soll.
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        '�berpr�fung des Formulars nur, wenn OK geklickt wurde:
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then

            'Daten aus Maske gibt ein Adresse-Objekt nur dann zur�ck,
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
            'ausgel�st wurde. Dann wird auf jeden Fall Nothing als
            'Funktionsergebnis zur�ckgegeben.
            myAdresse = Nothing
        End If
    End Sub

    '�berpr�ft die Eingaben im Formular, und liefert
    'im Erfolgsfall ein fix-und-fertiges Adresse-Objekt
    'aus den Eingabefeldern zur�ck.
    Private Function DatenAusMaske() As Adresse

        Dim locFehler As Boolean

        'Alle m�glichen Vorherigen Fehler zur�cksetzen
        ErrProv.Clear()

        'Wenn keine Eingabe im Feld gemacht wurde,
        If String.IsNullOrEmpty(txtMatchcode.Text) Then

            'Fehlermeldung setzen.
            ErrProv.SetError(txtMatchcode, "Fehlende Eingabe!")
            locFehler = locFehler Or True

        Else

            'Der Delegat ist nur beim Neuanlegen einer Adresse vorhanden,
            'deswegen auf Vorhandensein �berpr�fen!
            If myMatchcodeCheckenProc IsNot Nothing Then
                'Feststellen, ob der Matchcode in der Auflistung schon existiert!
                'Das passiert in unserem Fall �ber einen Delegaten.
                If myMatchcodeCheckenProc.Invoke(txtMatchcode.Text) Then
                    ErrProv.SetError(txtMatchcode, "Dieser Matchcode ist schon vorhanden!")
                    locFehler = locFehler Or True
                End If

            End If
        End If

        '�hnlich bei allen anderen vorgehen.
        If String.IsNullOrEmpty(txtVorname.Text) Then
            ErrProv.SetError(txtVorname, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(txtNachname.Text) Then
            ErrProv.SetError(txtNachname, "Fehlende Eingabe!")
            locFehler = locFehler Or True
        End If

        If String.IsNullOrEmpty(txtStra�e.Text) Then
            ErrProv.SetError(txtStra�e, "Fehlende Eingabe!")
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

        'Fehler war vorhanden - Nothing zur�ckliefern
        If locFehler Then Return Nothing

        'Alles war OK, es gibt eine neue Adresse.
        Return New Adresse(txtMatchcode.Text, txtNachname.Text, _
                           txtVorname.Text, txtStra�e.Text, _
                           mtbPlz.Text, txtOrt.Text, locGebDate)
    End Function

    'Kopiert ein vorhandenes Adresse-Objekt in die Maske
    'f�r das weitere Bearbeiten.
    Private Sub DatenInMaske(ByVal adr As Adresse)
        txtMatchcode.Text = adr.Matchcode
        txtVorname.Text = adr.Vorname
        txtNachname.Text = adr.Name
        txtStra�e.Text = adr.Stra�e
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