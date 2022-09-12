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

    'Delegat f�r das Aufrufen von Invoke, da Controls nicht
    'Thread-Sicher sind. 
    Delegate Sub AddTBTextTSActuallyDelegate(ByVal tb As TextBox, ByVal txt As String)

    'Flag, dass bestimmt, wann alle Threads zu gehen haben
    Private myAbortAllThreads As Boolean

    'Zus�tzliches Synchronisierungsobjekt f�r "Alle Threads beenden!"
    Private myAutoResetEvent As AutoResetEvent

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
        'Zus�tzliches Synchronisierungsobjekt f�r "Alle Threads beenden!" initialisieren
        myAutoResetEvent = New AutoResetEvent(True)

    End Sub

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochz�hlen und die Werteausgabe �bernimmt
    Private Sub UmfangreicheBerechnung()

        Dim locMutexIndex As Integer
        Dim locTextBox As TextBox

        'Hier beginnt der 1. kritische Abschnitt der Mutextes
        'Warten, bis eine TextBox "frei" wird
        locMutexIndex = Mutex.WaitAny(myMutexes)
        'Thread beenden, wenn das "Alles-Threads-Beenden-Flag" w�hrend
        'des Wartens signalisiert wurde
        If myAbortAllThreads Then
            'Verwendeten Textbox-Mutex wieder freigeben,
            'sonst knallt es, wenn die anderen Threads in diesem
            'Abschnitt beendet werden sollen!
            myMutexes(locMutexIndex).ReleaseMutex()
            Exit Sub
        End If
        'Textbox, die dem freien Mutex entspricht finden
        locTextBox = myTxtBoxes(locMutexIndex)
        'Hier beginnt der 2. kritische Abschnitt f�r OnClosing
        myAutoResetEvent.Reset()
        For c As Integer = 0 To 20
            SyncLock Me
                'Falls abgebrochen werden soll,
                If myAbortAllThreads Then
                    'OnClosing benachrichtigen
                    myAutoResetEvent.Set()
                    'Verwendeten Textbox-Mutex wieder freigeben.
                    'Grund: Siehe oben.
                    myMutexes(locMutexIndex).ReleaseMutex()
                    Exit Sub
                End If
                'Text in die TextBox des Threads ausgeben
                AddTBTextTS(locTextBox, Thread.CurrentThread.Name + ":: " + c.ToString + vbNewLine)
                Console.WriteLine(Thread.CurrentThread.Name + ":: " + c.ToString + vbNewLine)
            End SyncLock
            'Eine zuf�llige Weile lang warten
            Thread.Sleep(myRandom.Next(50, 400))
        Next
        '2. kritische Abschnitt beendet (OnClosing)
        myAutoResetEvent.Set()
        'Hier ist der 1. kritische Abschitt wieder vorbei.
        'Verwendete TextBox (Mutex) wieder freigeben
        myMutexes(locMutexIndex).ReleaseMutex()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

        'WICHTIG: Ein einfaches Warten mit WaitOne reicht in diesem
        'Fall nicht aus, da es sich um den Hauptthread handelt.
        'Dann aber w�rde WaitOne die Nachrichtenwarteschlange blockieren,
        'und ohne die funktioniert Invoke nicht. Deswegen wird hier ein TimeOut
        'angegeben, der Nachrichtenwarteschlange die M�glichkeit gegeben, einmal
        '"Luft zu holen", und dann weiter gewartet.
        myAbortAllThreads = True
        'DoEvents beim Warten in ein-Millisekunden-Abst�nden ausl�sen
        Do While Not myAutoResetEvent.WaitOne(1, True)
            Application.DoEvents()
        Loop
    End Sub

    'Dient zum Setzen einer Eigenschaft auf einer TextBox indirekt �ber Invoke
    Private Sub AddTBTextTS(ByVal tb As TextBox, ByVal txt As String)
        Dim locDel As New AddTBTextTSActuallyDelegate(AddressOf AddTBTextTSActually)

        Me.Invoke(locDel, New Object() {tb, txt})

    End Sub

    Private Sub AddTBTextTSActually(ByVal tb As TextBox, ByVal txt As String)
        tb.Text += txt
        tb.SelectionStart = tb.Text.Length - 1
        tb.ScrollToCaret()
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

Public Class TeilweiseSynchronisiert

    <System.Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.Synchronized)> _
    Sub TuIrgendwasSynchronisiertes()
        'Hier die Anweisung
        'des Arbeitsthreads
    End Sub

    Sub TuIrgendwasAnderes()
        'Hier die Anweisung
        'des Arbeitsthreads
    End Sub

End Class

Public Class InterlockedTest

    Dim myThreadZ�hlerF�rInterlocked As Integer

    Sub Arbeitsthread()

        'Maximal 3 Threads kommen hier gleichzeitig hinein,
        'dann ist Schluss!
        If Interlocked.Increment(myThreadZ�hlerF�rInterlocked) <= 3 Then
            'Hier die Anweisungen
            'den Arbeitsthreads
            Interlocked.Decrement(myThreadZ�hlerF�rInterlocked)
        End If

    End Sub
End Class

Public Class ReaderWriteLockTest

    Dim myReaderWriterLock As New ReaderWriterLock
    Dim myAutoReset As New ManualResetEvent(False)

    Sub DateiLeseThread()
        'Hier kommt das Programm nur rein,
        'wenn nicht geschrieben wird, ein Schreibvorgang also
        'nicht zuvor durch ein myReaderWriterLock.AcquireWriterLock
        'eingeleitet wurde!
        '1000 Millisekunden wird auf den Lock gewartet
        myReaderWriterLock.AcquireReaderLock(1000)
        'Lese-Thread nur ausf�hren, wenn Lock erteilt wurde
        If myReaderWriterLock.IsReaderLockHeld Then
            'Hier die Anweisungen
            'des Arbeitsthreads
            'der aus einer Datei liest
            myReaderWriterLock.ReleaseReaderLock()
        Else
            'TimeOut, in die Datei konnte nicht rechtzeitig geschrieben werden.
        End If
    End Sub

    Sub DateiSchreibThread()
        'Hier kommt ein neuer Thread nicht eher rein,
        'als bis ein anderer Lese-Thread zu ende gelesen
        'oder ein anderer Schreib-Thread den Schreibvorgang
        'komplettiert hat.
        '1000 Millisekunden wird auf den Lock gewartet
        myReaderWriterLock.AcquireWriterLock(1000)
        'Schreib-Thread nur ausf�hren, wenn Lock erteilt wurde
        If myReaderWriterLock.IsWriterLockHeld Then
            'Hier die Anweisungen
            'des Arbeitsthreads
            'der in die Datei schreibt
            myReaderWriterLock.ReleaseWriterLock()
        Else
            'TimeOut, in die Datei konnte nicht rechtzeitig geschrieben werden.
        End If

    End Sub

End Class
