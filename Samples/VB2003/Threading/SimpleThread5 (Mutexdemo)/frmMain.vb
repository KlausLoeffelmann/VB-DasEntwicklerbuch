'Dieser Namensbereich enthält die benötigten Threading-Objekte
Imports System.Threading
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Dim a As System.Collections.Specialized.NameObjectCollectionBase

#Region " Vom Windows Form Designer generierter Code "

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents btnBeenden As System.Windows.Forms.Button
    Friend WithEvents btnThreadStarten As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware3 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnBeenden = New System.Windows.Forms.Button
        Me.btnThreadStarten = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtHardware1 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHardware2 = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtHardware3 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBeenden
        '
        Me.btnBeenden.Location = New System.Drawing.Point(280, 16)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 1
        Me.btnBeenden.Text = "Beenden"
        '
        'btnThreadStarten
        '
        Me.btnThreadStarten.Location = New System.Drawing.Point(8, 16)
        Me.btnThreadStarten.Name = "btnThreadStarten"
        Me.btnThreadStarten.Size = New System.Drawing.Size(256, 32)
        Me.btnThreadStarten.TabIndex = 3
        Me.btnThreadStarten.Text = "Threads starten"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHardware1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hardware-Ressource #1"
        '
        'txtHardware1
        '
        Me.txtHardware1.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware1.Multiline = True
        Me.txtHardware1.Name = "txtHardware1"
        Me.txtHardware1.ReadOnly = True
        Me.txtHardware1.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware1.TabIndex = 0
        Me.txtHardware1.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHardware2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hardware-Ressource #2"
        '
        'txtHardware2
        '
        Me.txtHardware2.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware2.Multiline = True
        Me.txtHardware2.Name = "txtHardware2"
        Me.txtHardware2.ReadOnly = True
        Me.txtHardware2.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware2.TabIndex = 0
        Me.txtHardware2.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtHardware3)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 392)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hardware-Ressource #3"
        '
        'txtHardware3
        '
        Me.txtHardware3.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware3.Multiline = True
        Me.txtHardware3.Name = "txtHardware3"
        Me.txtHardware3.ReadOnly = True
        Me.txtHardware3.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware3.TabIndex = 0
        Me.txtHardware3.Text = ""
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 558)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnThreadStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Simple Thread - Mutex-Demo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Member-Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1

    'Speicher für Mutex-Objekte
    Private myMutexes() As Mutex

    'Speicher für TextBox-Controls
    Private myTxtBoxes() As TextBox

    'Zufallsgenerator für die künstlichen Wartezeiten im
    'Arbeitsthread. Damit kann ein Thread unterschiedlich lange dauern.
    Private myRandom As Random

    'Delegat für das Aufrufen von Invoke, da Controls nicht
    'Thread-Sicher sind. 
    Delegate Sub AddTBTextTSActuallyDelegate(ByVal tb As TextBox, ByVal txt As String)

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        'Mutexes definieren
        myMutexes = New Mutex() {New Mutex, New Mutex, New Mutex}
        'Textbox-Array zuweisen
        myTxtBoxes = New TextBox() {txtHardware1, txtHardware2, txtHardware3}
        'Zufallsgenerator initialisieren
        myRandom = New Random(DateTime.Now.Millisecond)

    End Sub

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochzählen und die Werteausgabe übernimmt
    Private Sub UmfangreicheBerechnung()

        Dim locMutexIndex As Integer
        Dim locTextBox As TextBox

        'Hier beginnt der kritische Abschnitt
        'Warten, bis eine TextBox "frei" wird
        locMutexIndex = Mutex.WaitAny(myMutexes)
        'Textbox, die dem freien Mutex entspricht finden
        locTextBox = myTxtBoxes(locMutexIndex)
        For c As Integer = 0 To 50
            SyncLock Me
                'Text in die TextBox des Threads ausgeben
                AddTBTextTS(locTextBox, Thread.CurrentThread.Name + ":: " + c.ToString + vbNewLine)
            End SyncLock
            'Eine zufällige Weile lang warten
            Thread.CurrentThread.Sleep(myRandom.Next(50, 400))
        Next
        'Hier ist der kritische Abschitt wieder vorbei.
        'Verwendete TextBox (Mutex) wieder freigeben
        myMutexes(locMutexIndex).ReleaseMutex()
    End Sub

    'Dient zum Setzen einer Eigenschaft auf einer TextBox indirekt über Invoke
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

    Dim myThreadZählerFürInterlocked As Integer

    Sub Arbeitsthread()

        'Maximal 3 Threads kommen hier gleichzeitig hinein,
        'dann ist Schluss!
        If Interlocked.Increment(myThreadZählerFürInterlocked) <= 3 Then
            'Hier die Anweisungen
            'den Arbeitsthreads
            Interlocked.Decrement(myThreadZählerFürInterlocked)
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
        'Lese-Thread nur ausführen, wenn Lock erteilt wurde
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
        'Schreib-Thread nur ausführen, wenn Lock erteilt wurde
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
