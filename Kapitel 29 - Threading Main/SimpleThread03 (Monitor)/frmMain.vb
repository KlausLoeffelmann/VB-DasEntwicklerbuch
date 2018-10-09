Imports System.Threading

Public Class frmMain

    'Statische Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1
    Private myThreadString As String

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click

        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As New Thread(
            Sub()

                'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
                'Hochzählen und die Werteausgabe übernimmt

                Dim strTemp As String

                For c As Integer = 0 To 50
                    strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
                    'Der Thread wartet maximal eine Sekunde; bekommt er in dieser
                    'Zeit keinen Zugriff auf den Code, steigt er aus.
                    If Not Monitor.TryEnter(Me, 1) Then
                        ThreadSafeTextWindow.TSWriteLine(Thread.CurrentThread.Name + " meldet: Gerade besetzt!")
                        Thread.Sleep(50)
                    Else
                        'Zugriff wurde gewährt - jetzt nimmt der Arbeits-Thread
                        'erst seine eigentliche Arbeit auf
                        myThreadString = ""
                        For z As Integer = 0 To strTemp.Length - 1
                            myThreadString += strTemp.Substring(z, 1)
                            Thread.Sleep(5)
                        Next
                        ThreadSafeTextWindow.TSWriteLine(myThreadString)
                        Monitor.Exit(Me)

                    End If

                Next

            End Sub)

        'Thread-Namen bestimmen
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString

        'Background-Thread bestimmen:
        locThread.IsBackground = True

        'Thread starten
        locThread.Start()
        'Zähler, damit die Threads durch ihren Namen unterschieden werden können
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Einfach so geht's normalerweise nicht
        Me.Close()
    End Sub

End Class
