Imports System.Threading

Public Class frmMain

    'Statische Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1
    Private myThreadString As String

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochzählen und die Werteausgabe übernimmt
    Private Sub UmfangreicheBerechnung()

        Dim strTemp As String

        For c As Integer = 0 To 50
            strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
            'Der Thread wartet maximal eine Sekunde; bekommt er in dieser
            'Zeit keinen Zugriff auf den Code, steigt er aus.
            If Not Monitor.TryEnter(Me, 1) Then
                ADThreadSafeInfoBox.TSWriteLine(Thread.CurrentThread.Name + " meldet: Gerade besetzt!")
                Thread.Sleep(50)
            Else
                'Zugriff wurde gewährt - jetzt nimmt der Arbeits-Thread
                'erst seine eigentliche Arbeit auf
                myThreadString = ""
                For z As Integer = 0 To strTemp.Length - 1
                    myThreadString += strTemp.Substring(z, 1)
                    Thread.Sleep(5)
                Next
                ADThreadSafeInfoBox.TSWriteLine(myThreadString)
                Monitor.Exit(Me)

            End If

        Next
    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click
        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As Thread
        'Dieses Objekt benötigen Sie, um die Prozedur zu bestimmen,
        'die den Thread ausführt.
        Dim locThreadStart As ThreadStart

        'Threadausführende Prozedur bestimmen
        locThreadStart = New ThreadStart(AddressOf UmfangreicheBerechnung)
        'ThreadStart-Objekt dem Thread-Objekt übergeben
        locThread = New Thread(locThreadStart)
        'Thread-Namen bestimmen
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
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
