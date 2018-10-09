Public Class Form1

    Private myStopSignaled As Boolean

    Private Sub btnStartStopButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartStopButton.Click

        If btnStartStopButton.Text = "Start" Then
            btnStartStopButton.Text = "Stop"
            Dim sw = Stopwatch.StartNew

            Dim lastMs As Long

            Do
                'Warten auf die nächste Millisekunde
                Do
                    If lastMs <> sw.ElapsedMilliseconds Then
                        lastMs = sw.ElapsedMilliseconds
                        elapsedMillisecondsLabel.Text =
                            TimeSpan.FromMilliseconds(lastMs).ToString("hh\:mm\:ss\:fff")
                        My.Application.DoEvents()
                        If myStopSignaled Then
                            Return
                        End If
                    End If
                Loop
            Loop
        Else
            myStopSignaled = True
            btnStartStopButton.Text = "Stop"
        End If
    End Sub

    Private myTimer As Timer

    Private Sub TimerTestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTestButton.Click
        myTimer = New Timer
        myTimer.Interval = 1
        myTimer.Start()

        Dim sw = Stopwatch.StartNew
        Dim lastms = sw.ElapsedMilliseconds

        AddHandler myTimer.Tick, Sub(timerSender As Object, timer_e As EventArgs)
                                     Dim cms = sw.ElapsedMilliseconds
                                     Debug.Print("Vergangene Zeit: " & cms - lastms & " ms.")
                                     lastms = cms
                                 End Sub
    End Sub

End Class
