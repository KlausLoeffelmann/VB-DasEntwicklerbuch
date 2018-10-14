Imports System.Threading

Public Class frmMain

    'Member-Variable, damit die Threads durchnummeriert werden k�nnen.
    'Dient nur zur sp�teren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1
    'Member-Variablen, mit der demonstrativ Mist gebaut wird...
    Private myThreadString As String

    'Dies ist der eigentliche Arbeits-Thread (auch "Worker Thread" genannt),
    'der das Hochz�hlen und die Werteausgabe �bernimmt
    Private Sub UmfangreicheBerechnung()

        Dim strTemp As String

        For c As Integer = 0 To 50
            strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
            'Nehmen Sie die Auskommentierung von SyncLock zur�ck,
            'um den "Fehler" des Programms zu beheben
            'SyncLock Me
            myThreadString = ""
            For z As Integer = 0 To strTemp.Length - 1
                myThreadString += strTemp.Substring(z, 1)
                Thread.Sleep(5)
            Next
            ADThreadSafeInfoBox.TSWriteLine(myThreadString)
            'End SyncLock

        Next
    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click
        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As Thread
        'Dieses Objekt ben�tigen Sie, um die Prozedur zu bestimmen,
        'die den Thread ausf�hrt.
        Dim locThreadStart As ThreadStart

        'Threadausf�hrende Prozedur bestimmen
        locThreadStart = New ThreadStart(AddressOf UmfangreicheBerechnung)
        'ThreadStart-Objekt dem Thread-Objekt �bergeben
        locThread = New Thread(locThreadStart)
        'Thread-Namen bestimmen
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
        'Thread starten
        locThread.Start()
        'Z�hler, damit die Threads durch ihren Namen unterschieden werden k�nnen
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Einfach so geht's normalerweise nicht
        Me.Close()
    End Sub

End Class
