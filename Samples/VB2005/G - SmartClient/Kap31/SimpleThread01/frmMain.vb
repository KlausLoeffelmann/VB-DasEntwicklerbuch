Imports System.Threading

Public Class frmMain

    'Member-Variable, damit die Threads durchnummeriert werden k�nnen.
    'Dient nur zur sp�teren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochz�hlen und die Werteausgabe �bernimmt
    Private Sub UmfangreicheBerechnung()
        For c As Integer = 0 To 50
            'Dient zur Ausgabe des Wertes. TSWriteLine ist eine statische
            'Prozedur, die f�r die Darstellung des Fensters selbst sorgt,
            'sobald sie das erste Mal verwendet wird.
            ADThreadSafeInfoBox.TSWriteLine(Thread.CurrentThread.Name + ":: " + c.ToString)
            'Aktuellen Thread um 100ms verz�gern, damit die ganze
            'Geschichte nicht zu schnell vorbei ist.
            Thread.Sleep(100)
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
