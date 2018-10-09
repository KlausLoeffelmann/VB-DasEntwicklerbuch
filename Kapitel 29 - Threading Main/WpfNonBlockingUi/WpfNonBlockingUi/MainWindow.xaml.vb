Imports System.Threading
Imports System.Threading.Tasks

Class MainWindow

    Private Const MAXVALUE = 100
    Private Const SPINVALUE = 5000000

    Private Sub StartWorkingButton_Click(ByVal sender As System.Object,
                                         ByVal e As System.Windows.RoutedEventArgs) _
                                        Handles StartWorkingButton.Click

        MainProgress.Maximum = MAXVALUE

        Dim t As New Task(Sub()
                              For z = 0 To MAXVALUE
                                  Thread.SpinWait(SPINVALUE)

                                  'Auf UI-Thread delegieren, um den 
                                  'ProgressBar zu aktualisieren. Funktioniert
                                  'nur nicht, da Invoke einen funktionierenden
                                  'Message-Loop benötigt, und der wird durch
                                  't.Wait blockiert!!
                                  Dispatcher.Invoke(Sub(insideValue As Integer)
                                                        MainProgress.Value = insideValue
                                                    End Sub, z)
                              Next
                          End Sub)

        'Task starten
        t.Start()

        'Das blockiert den UI-Thread
        t.Wait()

        'Das werden wir nie sehen... :-(
        MessageBox.Show("Task abgeschlossen!")
    End Sub

    'Private Sub StartWorkingButton_Click(ByVal sender As System.Object,
    '                                 ByVal e As System.Windows.RoutedEventArgs) _
    '                                Handles StartWorkingButton.Click

    '    MainProgress.Maximum = MAXVALUE

    '    Dim t2 As New Task(
    '        Sub()
    '            Dim t As New Task(Sub()
    '                                  For z = 0 To MAXVALUE
    '                                      Thread.SpinWait(SPINVALUE)

    '                                      'Auf UI-Thread delegieren, um den 
    '                                      'ProgressBar zu aktualisieren.
    '                                      Dispatcher.Invoke(Sub(insideValue As Integer)
    '                                                            MainProgress.Value = insideValue
    '                                                        End Sub, z)
    '                                  Next
    '                              End Sub)

    '            'Worker-Task starten
    '            t.Start()

    '            'Das Blockiert den UI-Thread jetzt nicht mehr.
    '            t.Wait()

    '            'So wird es funktionieren:
    '            Dispatcher.Invoke(Sub()
    '                                  MessageBox.Show("Task abgeschlossen!")
    '                              End Sub)

    '        End Sub)

    '    'Übergeordneten Task starten.
    '    t2.Start()

    'End Sub

    'Private myCtSource As CancellationTokenSource
    'Private myCToken As CancellationToken

    'Private Sub StartWorkingButton_Click(ByVal sender As System.Object,
    '                             ByVal e As System.Windows.RoutedEventArgs) _
    '                            Handles StartWorkingButton.Click

    '    If StartWorkingButton.Content.ToString = "Stop!" Then
    '        If myCtSource IsNot Nothing Then
    '            myCtSource.Cancel()
    '            Exit Sub
    '        End If
    '    End If

    '    StartWorkingButton.Content = "Stop!"

    '    MainProgress.Maximum = MAXVALUE

    '    myCtSource = New CancellationTokenSource()
    '    myCToken = myCtSource.Token

    '    Dim sw = Stopwatch.StartNew

    '    Dim tMain As New Task(
    '        Sub()
    '            Dim t As New Task(
    '                Sub()
    '                    For z = 0 To MAXVALUE
    '                        Thread.SpinWait(SPINVALUE)

    '                        'Auf UI-Thread delegieren, um den 
    '                        'ProgressBar zu aktualisieren.
    '                        Dispatcher.Invoke(Sub(insideValue As Integer)
    '                                              MainProgress.Value = insideValue
    '                                          End Sub, z)
    '                        If myCToken.IsCancellationRequested Then
    '                            Debug.Print("Throwing Cancellation Requested Exception:" & sw.ElapsedMilliseconds.ToString)
    '                            myCToken.ThrowIfCancellationRequested()
    '                        End If
    '                    Next
    '                End Sub, myCToken)

    '            Dim t2 As New Task(
    '                Sub()
    '                    For z = 0 To MAXVALUE \ 10
    '                        Thread.SpinWait(SPINVALUE * 10)

    '                        'Auf UI-Thread delegieren, um den 
    '                        'ProgressBar zu aktualisieren.
    '                        Dispatcher.Invoke(Sub(insideValue As Integer)
    '                                              Label1.Content = "Task 2 ist auch aktiv:" & insideValue.ToString
    '                                          End Sub, z)
    '                        If myCToken.IsCancellationRequested Then
    '                            Debug.Print("Throwing Cancellation Requested Exception:" & sw.ElapsedMilliseconds.ToString)
    '                            myCToken.ThrowIfCancellationRequested()
    '                            'Throw New OperationCanceledException("Thrown manually")
    '                        End If
    '                    Next
    '                End Sub, myCToken)

    '            'Worker-Tasks starten
    '            t.Start()
    '            t2.Start()

    '            Try
    '                'In dieser Version kommt die Exception beim ersten Task-Abbruch.
    '                Task.WaitAll({t, t2}, myCToken)
    '                'In dieser Version kommt die AggregateException, wenn alle Task abgebrochen wurden.
    '                Task.WaitAll({t, t2})

    '                'Auf diese Weise wird der erste Abbruch schon abgefangen.
    '            Catch ex As OperationCanceledException
    '                Debug.Print("Caught Exception: " & sw.ElapsedMilliseconds.ToString)
    '                Dispatcher.Invoke(Sub()
    '                                      MessageBox.Show("Task abgebrochen!")
    '                                  End Sub)
    '                'Version, die ohne CancellationToken wartet.
    '                'Catch ex As AggregateException
    '                '    Dispatcher.Invoke(Sub()
    '                '                          MessageBox.Show("Alle Tasks abgebrochen!")
    '                '                      End Sub)
    '            End Try

    '            'Wenn die vorherigen Tasks abgebrochen wurden, startet dieser
    '            'Task gar nicht erst mehr - denn auch das wird durch myCToken gesteuert.
    '            Dim t3 = Task.Factory.StartNew(
    '                                Sub()
    '                                    Dispatcher.Invoke(Sub()
    '                                                          MessageBox.Show("Task 3 Start!")
    '                                                      End Sub)
    '                                End Sub, myCToken)


    '            Dispatcher.Invoke(Sub()
    '                                  If myCToken.IsCancellationRequested Then
    '                                      Label1.Content = "Abgebrochen."
    '                                      StartWorkingButton.Content = "Start!"
    '                                  Else
    '                                      Label1.Content = "Fertig."
    '                                      StartWorkingButton.Content = "Start!"
    '                                      MessageBox.Show("Task abgeschlossen!")
    '                                  End If
    '                              End Sub)

    '            Debug.Print("Status Task 1:" & t.Status.ToString)
    '            Debug.Print("Status Task 2:" & t2.Status.ToString)
    '            Debug.Print("Status Task 3:" & t3.Status.ToString)

    '        End Sub, myCToken)

    '    'Übergeordneten Task starten.
    '    tMain.Start()


    'End Sub
End Class
