Imports System.Threading
Imports System.Threading.Tasks

Public Class frmMain

    Private Const LOOPCOUNT = 100

    'Member-Variable, damit die Threads durchnummeriert werden k�nnen.
    'Dient nur zur sp�teren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochz�hlen und die Werteausgabe �bernimmt
    Private Sub ComplexCalculation()
        Thread.CurrentThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
        For c As Integer = 0 To LOOPCOUNT
            'Dient zur Ausgabe des Wertes. TSWriteLine ist eine statische
            'Prozedur, die f�r die Darstellung des Fensters selbst sorgt,
            'sobald sie das erste Mal verwendet wird.
            TextOutput.TSWriteLine(Thread.CurrentThread.Name + ":: " + c.ToString)
            'Aktuellen Thread um 100ms verz�gern, damit die ganze
            'Geschichte nicht zu schnell vorbei ist.
            Thread.Sleep(100)
        Next
    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles ThreadWithThreadButton.Click

        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As Thread
        'Dieses Objekt ben�tigen Sie, um die Prozedur zu bestimmen,
        'die den Thread ausf�hrt.
        Dim locThreadStart As ThreadStart

        'Threadausf�hrende Prozedur bestimmen
        locThreadStart = New ThreadStart(AddressOf ComplexCalculation)
        'ThreadStart-Objekt dem Thread-Objekt �bergeben
        locThread = New Thread(locThreadStart)
        'Einen Thread daraus machen, der beendet wird, wenn die Hauptanwendung sich beendet:
        locThread.IsBackground = True

        'Thread starten
        locThread.Start()
        'Z�hler, damit die Threads durch ihren Namen unterschieden werden k�nnen
        myArbeitsThreadNr += 1

    End Sub

    'Seit Visual Basic 2010 erspart der Compiler durch Multistatement Lambdas
    'einen Haufen Tipparbeit:
    Private Sub ThreadStartShortVersion()

        Dim locThread As New Thread(Sub()
                                        'Gleiche Schleife wie in Methode 'Umfangreiche Berechnung'.
                                        For c As Integer = 0 To LOOPCOUNT
                                            TextOutput.TSWriteLine(Thread.CurrentThread.Name + ":: " + c.ToString)
                                            Thread.Sleep(100)
                                        Next
                                    End Sub) With
                                 {.IsBackground = True,
                                  .Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString}
        locThread.Start()
        myArbeitsThreadNr += 1

        Dim helloWorldAction As Action = Sub()
                                             Debug.Print("Hello World!")
                                         End Sub
        helloWorldAction()

        'Alternativ, bewirkt dasselbe:
        helloWorldAction.Invoke()
    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Alles Background Threads oder Threadpool-Threads die hier verwendet werden;
        'wenn das Hauptfenster, das beim Schlie�en den UI-Thread
        'beendet, geschlossen wird, werden alle anderen Threads auch beendet.
        Me.Close()
    End Sub

    Private Sub ASyncInvokeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASyncInvokeButton.Click

        Dim aDelegate As action = AddressOf ComplexCalculation

        Dim asyncres As IAsyncResult = Nothing
        asyncres = aDelegate.BeginInvoke(Sub(value As Object)
                                             'Dieser Code wird ausgef�hrt,
                                             'wenn der Task abgeschlossen ist.
                                             TextOutput.TSWriteLine("Worker Thread abgeschlossen!")

                                             'Wichtig: Immer mit EndInvoke abschlie�en!
                                             aDelegate.EndInvoke(asyncres)
                                             TextOutput.TSWriteLine("EndInvoke abgeschlossen!")
                                         End Sub, New Object)
        myArbeitsThreadNr += 1
    End Sub

    Private Sub ThreadWithTasksButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThreadWithTasksButton.Click

        Dim t = Task.Factory.StartNew(AddressOf ComplexCalculation)

        'Alternative:
        Dim t2 = New Task(Sub()
                              'Gleiche Schleife wie in Methode 'Umfangreiche Berechnung'.
                              For c As Integer = 0 To LOOPCOUNT
                                  TextOutput.TSWriteLine(Thread.CurrentThread.Name + ":: " + c.ToString)
                                  Thread.Sleep(100)
                              Next
                          End Sub)
        t2.Start()


        t.ContinueWith(Sub()
                           TextOutput.TSWriteLine("Worker Thread abgeschlossen!")
                       End Sub)

    End Sub

    Private Sub ThreadFromThreadpoolDirectly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThreadFromThreadpoolDirectly.Click

        ThreadPool.QueueUserWorkItem(Sub(value)
                                         ComplexCalculation()
                                     End Sub)
    End Sub
End Class