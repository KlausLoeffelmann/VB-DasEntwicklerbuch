Imports System.Threading

Public Class frmMain

    'Member-Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1

    'Member-Variablen, mit der demonstrativ "Mist gebaut" wird...
    Private myThreadString As String

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click

        'Neuen Thread erstellen; der Worker-Thread läuft darin als Lambda:
        Dim locThread As New Thread(
            Sub()
                Dim strTemp As String

                For c As Integer = 0 To 50
                    strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
                    'Nehmen Sie die Auskommentierung von SyncLock zurück,
                    'um den "Fehler" des Programms zu beheben
                    SyncLock Me
                        myThreadString = ""
                        For z As Integer = 0 To strTemp.Length - 1
                            'Simulieren des "Zusammenbastelns" der Zeichenfolge ...
                            myThreadString += strTemp.Substring(z, 1)
                            '... mit ein wenig mehr Arbeitsaufwand.
                            Thread.SpinWait(1000000)
                        Next
                        ThreadSafeTextWindow.TSWriteLine(myThreadString)
                    End SyncLock
                Next
            End Sub)

        'Thread wird in jedem Fall mit Anwendung beendet:
        locThread.IsBackground = True
        'Thread hat einen Namen:
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
        'Thread starten
        locThread.Start()
        'Zähler, damit die Threads durch ihren Namen unterschieden werden können
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Threads sind Background-Threads; ist also kein Problem.
        Me.Close()
    End Sub

End Class
