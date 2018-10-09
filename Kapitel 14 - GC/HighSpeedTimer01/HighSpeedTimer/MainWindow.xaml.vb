Class MainWindow

    'Die High Speed Timer-Klasse
    Private WithEvents myHst As HighSpeedTimer

    'Zähler für vergangene Millisekunden
    Private myCurrentMilliSeconds As Integer

    'Wird ausgeführt beim Starten und Stoppen des Timers.
    Private Sub StartStopButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles StartStopButton.Click

        'Was wir machen ist abhängig von der Schaltflächenbeschriftung.
        If Me.StartStopButton.Content.ToString = "Start" Then

            'Neues Timerobjekt mit einer Millisekunde Triggerzeit.
            myHst = New HighSpeedTimer(1, 1)

            'Zähler zurücksetzen
            myCurrentMilliSeconds = 0

            'Timer Starten.
            myHst.Start()

            'Schaltflächentext ändern.
            Me.StartStopButton.Content = "Stop"
        Else
            'Timer Stoppen
            myHst.Stop()

            'Schaltflächentext wieder zurücksetzen.
            Me.StartStopButton.Content = "Start"
        End If
    End Sub

    Private Sub myHst_Elapsed(ByVal sender As Object, ByVal e As System.EventArgs) Handles myHst.Elapsed

        'Count-Up-Zähler erhöhen.
        myCurrentMilliSeconds += 1

        'WICHTIG: Der Timer-Ticker läuft auf einem eigenen Thread.
        'Andere Threads dürfen aber nicht direkt in die Oberfläche schreiben,
        'deswegen muss der Thread umdelegiert werden, und zwar wie folgt:
        If Me.Dispatcher.CheckAccess Then
            'Gleicher Thread, dann können wir direkt verändern:
            '(Wird in diesem Beispiel nicht passieren, aber das Muster sollten Sie immer so verwenden.)
            ElapsedTimeLabel.Content = TimeSpan.FromMilliseconds(myCurrentMilliSeconds).ToString("hh\:mm\:ss\:fff")
        Else
            'Anderer Thread, dann müssen wir Dispatchen auf den UI-Thread.
            Me.Dispatcher.Invoke(Sub()
                                     ElapsedTimeLabel.Content = TimeSpan.FromMilliseconds(myCurrentMilliSeconds).ToString("hh\:mm\:ss\:fff")
                                 End Sub, {})
        End If
    End Sub
End Class
