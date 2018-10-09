Imports System.Threading

Public Class frmMain

    'Member-Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1
    Private myThreadString As String

    'Die brauchen wir, um festzustellen, wie viele Threads unterwegs sind
    Private myThreadCount As Integer

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochzählen und die Werteausgabe übernimmt
    Private Sub UmfangreicheBerechnung()

        Dim strTemp As String
        Dim stepCount As Integer

        'Neuer Thread: Zählen!
        myThreadCount += 1

        'Hier beginnt der kritische Abschnitt
        Monitor.Enter(Me)
        For c As Integer = 0 To 50
            strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
            'Der Thread wartet maximal eine Sekunde; bekommt er in dieser
            'Zeit keinen Zugriff auf den Code, steigt er aus.
            'Zugriff wurde gewährt - jetzt nimmt der Arbeits-Thread
            'erst seine eigentliche Arbeit auf
            myThreadString = ""
            For z As Integer = 0 To strTemp.Length - 1
                myThreadString += strTemp.Substring(z, 1)
                Thread.Sleep(1)
            Next
            ThreadSafeTextWindow.TSWriteLine(myThreadString)
            'Der Thread darf sich nur dann Schlafen legen, wenn mindestens
            'ein weiterer Thread unterwegs ist, der ihn wieder wecken kann
            If myThreadCount > 1 Then
                stepCount += 1
                If stepCount = 5 Then
                    stepCount = 0
                    'Ablösung naht!
                    Monitor.Pulse(Me)
                    ThreadSafeTextWindow.TSWriteLine("Hab dich, du bist's")
                    'Abgelöster geht schlafen.
                    Monitor.Wait(Me)
                End If
            End If
        Next
        If myThreadCount > 1 Then
            'Alle anderen schlafen zu dieser Zeit.
            'Also mindestens einen wecken, bevor dieser Thread geht.
            'Passiert das nicht, schlafen die anderen bis zum nächsten Stromausfall...
            Monitor.Pulse(Me)
        End If
        'Hier ist der kritische Abschitt wieder vorbei.
        Monitor.Exit(Me)
        'Thread-Zähler vermindern.
        myThreadCount -= 1
    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click
        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As New Thread(AddressOf UmfangreicheBerechnung)

        'Wird vorzeitig beendet, wenn Anwendung beendet wird:
        locThread.IsBackground = True

        'Thread-Namen bestimmen
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
        'Thread starten
        locThread.Start()
        'Zähler, damit die Threads durch ihren Namen unterschieden werden können
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        Me.Close()
    End Sub

End Class
