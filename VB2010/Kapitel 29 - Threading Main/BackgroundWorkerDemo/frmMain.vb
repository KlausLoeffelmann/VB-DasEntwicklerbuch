Public Class frmMain

    Private myPrimzahlen As List(Of Long)

    Private Sub btnBerechnungStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBerechnungStarten.Click

        'Festlegen, dass der BackgroundWorker über den Fortschritt berichten können soll.
        PrimzahlenBackgroundWorker.WorkerReportsProgress = True

        'Fortschrittsanzeige konfigurieren.
        pbBerechnungsfortschritt.Minimum = 0
        pbBerechnungsfortschritt.Maximum = 1000
        pbBerechnungsfortschritt.Value = 0
        lblGefundenText.Text = "Die höchte bislang gefundene Primzahl lautet:"

        'Ereignis auslösen lassen, damit der Thread
        'in der DoWork-Ereignisbehandlungsroutine gestartet werden kann.
        'Die Obergrenze wird aus dem Textfeld als Argument übergeben.
        Me.PrimzahlenBackgroundWorker.RunWorkerAsync(txtAnzahlPrimzahlen.Text)
    End Sub

    Private Sub PrimzahlenBackgroundWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                Handles PrimzahlenBackgroundWorker.DoWork

        'Das Argument (die Obergrenze) aus den Ereignisparametern wieder herauslesen.
        Dim locMax As Integer = CInt(e.Argument)

        'Ein paar Variablen für die Fortschrittsprozentanzeige einrichten.
        '(OK: Es sind Promille).
        Dim locProgressFaktor As Double = 1000 / locMax
        Dim locProgressAlt As Integer = 0
        Dim locProgressAktuell As Integer

        'Fertig, wenn Obergrenze kleiner 3 ist.
        If (locMax < 3) Then Return

        'Neues Array definieren, dass die Primzahlen enthält.
        '(Wir verwenden als Algorithmus das Sieb des Eratosthenes.)
        myPrimzahlen = New List(Of Long)

        For z As Integer = 2 To locMax
            If IstPrimzahl(myPrimzahlen, z) Then
                myPrimzahlen.Add(z)

                'Progressinformation senden. Das darf, da der Thread durch SendMessage
                '"gewechselt" wird, nicht zu häufig passieren, sonst hängt der
                'UI-Thread, der die BackgroundWorker-Komponente anfangs initiiert hat.
                locProgressAktuell = CInt(z * locProgressFaktor)
                If locProgressAktuell > locProgressAlt Then
                    locProgressAlt = locProgressAktuell
                    'Das ProgressChange-Ereignis auslösen, um über den
                    'Fortschritt zu informieren.
                    PrimzahlenBackgroundWorker.ReportProgress(locProgressAktuell)
                End If
            End If
        Next
    End Sub

    Private Function IstPrimzahl(ByVal Primzahlen As List(Of Long), ByVal Number As Long) As Boolean

        For Each locTestZahl As Long In Primzahlen
            If (Number Mod locTestZahl = 0) Then Return False
            If (locTestZahl >= Math.Sqrt(Number)) Then Exit For
        Next
        Return True
    End Function

    'Wird aufgerufen, wenn eine BackgroundWorker-Komponente mit
    'ReportProgress über den Fortschritt informiert. Dieser Ereignisbehandler
    'läuft dennoch auf dem UI-Thread und nicht dem DoWork-Thread. Er kann daher
    'ohne Probleme Steuerelemente direkt manipulieren.
    Private Sub PrimzahlenBackgroundWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles PrimzahlenBackgroundWorker.ProgressChanged
        pbBerechnungsfortschritt.Value = e.ProgressPercentage
        lblHöchstePrimzahl.Text = myPrimzahlen(myPrimzahlen.Count - 1).ToString("#,##0")
    End Sub

    'Wird aufgerufen, wenn der DoWork-Thread beendet wurde.
    'Auch dieser Ereignisbehandler läuft auf dem UI-Thread.
    Private Sub PrimzahlenBackgroundWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles PrimzahlenBackgroundWorker.RunWorkerCompleted
        lblGefundenText.Text = "Die höchte gefundene Primzahl im Bereich lautet:"
        lblHöchstePrimzahl.Text = myPrimzahlen(myPrimzahlen.Count - 1).ToString("#,##0")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class
