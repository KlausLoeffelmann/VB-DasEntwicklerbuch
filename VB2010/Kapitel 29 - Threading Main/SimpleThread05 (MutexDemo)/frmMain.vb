Imports System.Threading

Public Class frmMain

    'Member-Variable, damit die Threads durchnummeriert werden k�nnen.
    'Dient nur zur sp�teren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1

    'Speicher f�r Mutex-Objekte
    Private myMutexes() As Mutex

    'Speicher f�r TextBox-Controls
    Private myTxtBoxes() As TextBox

    'Zufallsgenerator f�r die k�nstlichen Wartezeiten im
    'Arbeitsthread. Damit kann ein Thread unterschiedlich lange dauern.
    Private myRandom As Random

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()
        'Mutexes definieren
        myMutexes = New Mutex() {New Mutex, New Mutex, New Mutex}
        'Textbox-Array zuweisen
        myTxtBoxes = New TextBox() {txtHardware1, txtHardware2, txtHardware3}
        'Zufallsgenerator initialisieren
        myRandom = New Random(DateTime.Now.Millisecond)

    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click

        Dim locThread As New Thread(
            Sub()
                Dim locMutexIndex As Integer
                Dim locTextBox As TextBox

                'Hier beginnt der kritische Abschnitt
                'Warten, bis eine TextBox "frei" wird
                locMutexIndex = Mutex.WaitAny(myMutexes)

                'Textbox, die dem freien Mutex entspricht finden
                locTextBox = myTxtBoxes(locMutexIndex)
                For c As Integer = 0 To 50
                    SyncLock Me
                        If Me.IsHandleCreated Then
                            'Text in der ermittelten TextBox ausgeben
                            '(wir m�ssen zum UI-Thread delegieren, deswegen der Umweg �ber Invoke).
                            Me.BeginInvoke(Sub(tb As TextBox, txt As String)
                                               tb.Text += txt
                                               tb.SelectionStart = tb.Text.Length - 1
                                               tb.ScrollToCaret()
                                           End Sub, {locTextBox,
                                          Thread.CurrentThread.Name + ":: " + c.ToString + vbNewLine})
                        End If
                    End SyncLock
                    'Eine zuf�llige Weile lang warten
                    Thread.Sleep(myRandom.Next(50, 400))
                Next
                'Hier ist der kritische Abschitt wieder vorbei.
                'Verwendete TextBox (Mutex) wieder freigeben
                myMutexes(locMutexIndex).ReleaseMutex()
            End Sub)

        locThread.IsBackground = True
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString

        'Thread starten
        locThread.Start()
        'Z�hler, damit die Threads durch ihren Namen unterschieden werden k�nnen
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        Me.Close()
    End Sub
End Class

