'Dieser Namensbereich enthält die benötigten Threading-Objekte
Imports System.Threading
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBenchmarkStarten As System.Windows.Forms.Button
    Friend WithEvents txtAusgabe As System.Windows.Forms.TextBox
    Friend WithEvents chkMultithreading As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnBeenden = New System.Windows.Forms.Button
        Me.btnBenchmarkStarten = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtAusgabe = New System.Windows.Forms.TextBox
        Me.chkMultithreading = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBeenden
        '
        Me.btnBeenden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBeenden.Location = New System.Drawing.Point(296, 16)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 1
        Me.btnBeenden.Text = "Beenden"
        '
        'btnBenchmarkStarten
        '
        Me.btnBenchmarkStarten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBenchmarkStarten.Location = New System.Drawing.Point(8, 16)
        Me.btnBenchmarkStarten.Name = "btnBenchmarkStarten"
        Me.btnBenchmarkStarten.Size = New System.Drawing.Size(272, 32)
        Me.btnBenchmarkStarten.TabIndex = 3
        Me.btnBenchmarkStarten.Text = "Benchmark starten"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtAusgabe)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 304)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status:"
        '
        'txtAusgabe
        '
        Me.txtAusgabe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAusgabe.Location = New System.Drawing.Point(8, 24)
        Me.txtAusgabe.Multiline = True
        Me.txtAusgabe.Name = "txtAusgabe"
        Me.txtAusgabe.ReadOnly = True
        Me.txtAusgabe.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAusgabe.Size = New System.Drawing.Size(376, 272)
        Me.txtAusgabe.TabIndex = 0
        Me.txtAusgabe.Text = ""
        Me.txtAusgabe.WordWrap = False
        '
        'chkMultithreading
        '
        Me.chkMultithreading.Location = New System.Drawing.Point(16, 56)
        Me.chkMultithreading.Name = "chkMultithreading"
        Me.chkMultithreading.Size = New System.Drawing.Size(248, 24)
        Me.chkMultithreading.TabIndex = 5
        Me.chkMultithreading.Text = "Multithreading verwenden"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 406)
        Me.Controls.Add(Me.chkMultithreading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBenchmarkStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Sortieren mit Threading"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const cAmountOfElements As Integer = 200000
    Private Const cCharsPerString As Integer = 100
    Private Const cShowResults As Boolean = False

    'Delegaten für das Aufrufen von Invoke, da Controls nicht
    'Thread-Sicher sind. 
    'Für die Textbox zur Ausgabe
    Private Delegate Sub AddTBTextTSActuallyDelegate(ByVal txt As String)
    'Für das Einschalten der Buttons, wenn der Vorgang beendet ist.
    Private Delegate Sub TSEnableControlsDelegate()

    'Flag, dass bestimmt, wann alle Threads zu gehen haben
    Private myAbortAllThreads As Boolean

    'Ausgabe-Textbox. Statisch deswegen, damit jeder Thread
    'zu jeder Zeit darauf zugreifen kann.
    Private Shared myAusgabeTextBox As TextBox

    'Synchronisation für die Ausgabe-Textbox
    Private Shared myAutoResetEvent As AutoResetEvent

    'Merkt sich thread-safe, ob die Sortierung mit einem oder
    'wei Threads durchgeführt werden soll.
    Private myUseTwoThread As Boolean

    'Ereignis, um dem UI-Thread mitteilen zu können,
    'dass der Hauptarbeits-Thread abgeschlossen ist.
    Private Event MainThreadFinished()

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Synchronisation für die Ausgabe-Textbox
        myAutoResetEvent = New AutoResetEvent(True)

    End Sub

    'Dient zum Setzen einer Eigenschaft auf der TextBox indirekt über Invoke
    Public Shared Sub AddTBText(ByVal txt As String)
        'Formular nicht mehr oder noch nicht dar...
        If AusgabeTextBox Is Nothing Then
            '...und tschö!
            Exit Sub
        End If
        'Threads synchronisieren: Hier beginnt kritischer Abschnitt
        myAutoResetEvent.Reset()
        Dim locDel As New AddTBTextTSActuallyDelegate(AddressOf AddTBTextTSActually)
        AusgabeTextBox.Invoke(locDel, New Object() {txt})
        myAutoResetEvent.Set()
    End Sub

    'Diese Routine wird indirekt über Invoke aufgerufen, und ist damit UI-Thread
    Private Shared Sub AddTBTextTSActually(ByVal txt As String)
        AusgabeTextBox.Text += txt
        AusgabeTextBox.SelectionStart = AusgabeTextBox.Text.Length - 1
        AusgabeTextBox.ScrollToCaret()
    End Sub

    'Liefert die Textbox als Eigenschaft
    Private Shared ReadOnly Property AusgabeTextBox() As TextBox
        Get
            Return myAusgabeTextBox
        End Get
    End Property

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBenchmarkStarten.Click
        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As Thread
        'Dieses Objekt benötigen Sie, um die Prozedur zu bestimmen,
        'die den Hauptthread ausführt.
        Dim locThreadStart As ThreadStart

        'Ausgabetextbox bestimmen
        myAusgabeTextBox = Me.txtAusgabe

        'Controls disablen, damit kein zusätzlicher Hauptthread gestartet werden kann
        'Wenn der komplette Testparkur abgeschlossen ist, löst der Hauptthread ein
        'Ereignis aus, das das Formular einbindet. Diese Vorgehensweise dient nur der
        'Demonstration: Genau so gut könnte der Haupt-Thread die Controls auch indirekt
        'selbst wieder einschalten.
        btnBenchmarkStarten.Enabled = False
        btnBeenden.Enabled = False

        'Festhalten, ob die Sortierung in einem oder zwei Threads erfolgen soll
        myUseTwoThread = Me.chkMultithreading.Checked

        'Threadausführende Prozedur bestimmen
        locThreadStart = New ThreadStart(AddressOf StartMainThread)
        'ThreadStart-Objekt dem Thread-Objekt übergeben
        locThread = New Thread(locThreadStart)
        'Thread-Namen bestimmen
        locThread.Name = "MainThread"
        'Haupt-Thread starten
        locThread.Start()

        'Der UI-Thread (die Nachrichtenwarteschlange) läuft jetzt leer nebenbei
        'Auf diese Weise kann der komplette Testparkur ruhig 100% Prozessorleistung
        'verschlingen; da er in einem Extra-Thread läuft bleibt das Programm
        'dennoch bedienbar.
    End Sub

    'Dies ist die eigentliche Haupt-Thread-Routine (aber nicht der UI-Thread!), die das Testarray
    'generiert und dann selbst wiederum entweder ein oder zwei Arbeits-Threads aufruft,
    'die die eigentliche Sortierung durchführen.
    Private Sub StartMainThread()

        Dim locStrings(cAmountOfElements - 1) As String
        Dim locGauge As New HighSpeedTimeGauge
        Dim locAutoResetEvents(1) As AutoResetEvent

        Dim locRandom As New Random(DateTime.Now.Millisecond)
        Dim locChars(cCharsPerString) As Char

        'Damit die Controls nach Abschluss des Sortierens auf dem Formular
        'wieder eingeschaltet werden können, muss der Haupt-Thread das Ende
        'der Sortierung mitbekommen. Deswegen: Ereignis
        AddHandler MainThreadFinished, AddressOf MainThreadFinishedHandler

        'String-Array erzeugen; hatten wir schon zig Mal...
        AddTBText("Erzeugen von " + cAmountOfElements.ToString + " Strings..." + vbNewLine)
        locGauge.Start()
        For locOutCount As Integer = 0 To cAmountOfElements - 1
            For locInCount As Integer = 0 To cCharsPerString - 1
                If myAbortAllThreads Then
                    RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler
                    Exit Sub
                End If
                Dim locIntTemp As Integer = Convert.ToInt32(locRandom.NextDouble * 52)
                If locIntTemp > 26 Then
                    locIntTemp += 97 - 26
                Else
                    locIntTemp += 65
                End If
                locChars(locInCount) = Convert.ToChar(locIntTemp)
            Next
            locStrings(locOutCount) = New String(locChars)
        Next
        locGauge.Stop()
        AddTBText("...in " + locGauge.DurationInMilliSeconds.ToString + " Millisekunden" + vbNewLine)
        AddTBText(vbNewLine)
        locGauge.Reset()

        If Not myUseTwoThread Then
            'Messung starten - hier wird mit nur einem Thread sortiert.
            locGauge.Start()
            Dim locFirstSortThread As New SortArrayThreaded(New ArrayList(locStrings), "1. SortThread")

            AddTBText("Sortieren von " + cAmountOfElements.ToString + " Strings mit einem Thread..." + vbNewLine)
            locAutoResetEvents(0) = locFirstSortThread.AutoResetEvent
            locFirstSortThread.StartSortingAsynchron()
            'Warten, bis der Sortier-Thread abgeschlossen ist. Der Sortier-Thread, der durch die
            'SortArrayThreaded-Klasse gekapselt wird, stellt eine AutoResetEvents-Eigenschaft bereit,
            'die signalisiert wird, wenn er zu ende sortiert hat.
            Do While Not locAutoResetEvents(0).WaitOne(1, True)
                'Mit Timeout-Wert warten, damit ein Eingreifen (Abbrechen) im Sortier-Thread möglich
                'bleibt, wenn das komplette Programm beendet werden soll.
                If myAbortAllThreads = True Then
                    'Die Dispose-Methode der SortArrayThread-Klasse bricht einen vielleicht laufenden
                    'Sortiert-Thread ab.
                    locFirstSortThread.Dispose()
                    RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler
                    Exit Sub
                End If
            Loop
            'Messung beenden
            locGauge.Stop()
            AddTBText("...in " + locGauge.DurationInMilliSeconds.ToString + " Millisekunden" + vbNewLine)
            AddTBText(vbNewLine)
            'Array-List zurück-casten.
            locStrings = CType(locFirstSortThread.ArrayList.ToArray(GetType(String)), String())
        Else
            'Es soll mit zwei Threads sortiert werden
            locGauge.Start()
            'Zwei Arraylists erstellen, die jeweils den oberen und den unteren Teil der
            'zu sortierenden Gesamtliste beinhalten.
            Dim locFirstAL As New ArrayList(locStrings.Length \ 2 + 1)
            Dim locSecondAL As New ArrayList(locStrings.Length \ 2 + 1)
            Dim locMitte As Integer = locStrings.Length \ 2

            'Elemente über beide ArrayLists verteilen
            For c As Integer = 0 To locMitte - 1
                locFirstAL.Add(locStrings(c))
                locSecondAL.Add(locStrings(c + locMitte))
            Next

            'Zwei SortArrayThreaded-Instanzhen erzeugen und ihnen die Teillisten übergeben
            Dim locFirstSortThread As New SortArrayThreaded(locFirstAL, "1. SortThread")
            Dim locSecondSortThread As New SortArrayThreaded(locSecondAL, "2. SortThread")

            AddTBText("Sortieren von " + cAmountOfElements.ToString + " Strings mit zwei Threads..." + vbNewLine)
            'Beide AutoResetEvent-Objekte der beiden Sortier-Threads in ein Array packen,
            'damit auf den Abschluss beider Threads gewartet werden kann.
            locAutoResetEvents(0) = locFirstSortThread.AutoResetEvent
            locAutoResetEvents(1) = locSecondSortThread.AutoResetEvent
            'Los geht's!
            locFirstSortThread.StartSortingAsynchron()
            locSecondSortThread.StartSortingAsynchron()
            'Warten, bis beide Sortier-Threads beendet sind; dabei die Erkennung eines
            'möglichen Programmabbruchs offen halten.
            Do While Not AutoResetEvent.WaitAll(locAutoResetEvents, 1, True)
                If myAbortAllThreads = True Then
                    locFirstSortThread.Dispose()
                    locSecondSortThread.Dispose()
                    RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler
                    Exit Sub
                End If
            Loop

            'Beide sortierten String-Arrays wieder zusammenführen
            Dim locIndexOnSecond As Integer
            Dim locTempArray As New ArrayList(cAmountOfElements)
            For locIndexOnFirst As Integer = 0 To locFirstAL.Count - 1
                Do
                    If locIndexOnSecond < locSecondAL.Count Then
                        If CType(locFirstAL(locIndexOnFirst), IComparable).CompareTo( _
                           CType(locSecondAL(locIndexOnSecond), IComparable)) < 0 Then
                            locTempArray.Add(locFirstAL(locIndexOnFirst))
                            Exit Do
                        Else
                            locTempArray.Add(locSecondAL(locIndexOnSecond))
                            locIndexOnSecond += 1
                        End If
                    Else
                        locTempArray.Add(locFirstAL(locIndexOnFirst))
                        Exit Do
                    End If
                Loop
                'Möglichen Abbruch auch an dieser Stelle berücksichtigen
                If myAbortAllThreads = True Then
                    locFirstSortThread.Dispose()
                    locSecondSortThread.Dispose()
                    RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler
                    Exit Sub
                End If
            Next
            'Falls es Reste aus dem zweiten Array gibt, diese auch noch kopieren
            If locIndexOnSecond < (locSecondAL.Count - 1) Then
                For c As Integer = locIndexOnSecond To locSecondAL.Count - 1
                    locTempArray.Add(locSecondAL(c))
                Next
            End If
            locStrings = CType(locTempArray.ToArray(GetType(String)), String())

            locGauge.Stop()
            AddTBText("...in " + locGauge.DurationInMilliSeconds.ToString + " Millisekunden" + vbNewLine)
            AddTBText(vbNewLine)
        End If

        'Falls das entsprechende Flag gesetzt ist, die Ergebnisse in die Textbox schreiben
        If cShowResults Then
            For Each s As String In locStrings
                If myAbortAllThreads Then
                    RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler
                    Exit Sub
                End If
                AddTBText(s + vbNewLine)
                AddTBText(vbNewLine)
            Next
        End If

        'Ereignis auslösen, das die Schaltflächen wieder einschaltet
        RaiseEvent MainThreadFinished()
        'Ereignishandler wieder entfernen
        RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler

    End Sub

    Private Sub MainThreadFinishedHandler()
        'Wichtig: Ruft ein Thread einen Ereignishandler auf, läuft dieser Ereignishandler
        'immer in dessen Thread, egal, zu welcher Klasse der Handler gehört. Deswegen
        'kann auch auf diesem Weg nur über Invoke auf den UI-Thread zugegriffen werden!
        Console.WriteLine("MainThread beendet: " + Thread.CurrentThread.Name)
        Me.Invoke(New TSEnableControlsDelegate(AddressOf TSEnableControlsActually))
    End Sub

    Private Sub TSEnableControlsActually()
        btnBeenden.Enabled = True
        btnBenchmarkStarten.Enabled = True
    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Nur schließen. OnClosing synchronisiert.
        Me.Close()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        'Falls eine TextBox-Ausgabe läuft, warten bis diese abgeschlossen ist.
        'Sonst erfolgt die Ausgabe wohlmöglich gerade zu der Zeit, wenn der Anwender
        'das Formular geschlossen hat. Dann wird die TextBox allerdings entladen,
        'ihr Handel zerstört und die Ausgabe löst eine Ausnahme aus, weil sie das
        'zerstörte Handle der TextBox verwenden will.
        Do While Not myAutoResetEvent.WaitOne(1, True)
            Application.DoEvents()
        Loop
        'Ausgabe sicher --> jetzt erst abbrechen.
        myAbortAllThreads = True
    End Sub

End Class

Public Class SortArrayThreaded
    Implements IDisposable

    Public Event SortCompleted(ByVal sender As Object, ByVal e As SortCompletedEventArgs)
    Private myArrayToSort As ArrayList
    Private myAutoResetEvent As AutoResetEvent
    Private myTerminateThread As Boolean
    Private myThreadStart As ThreadStart
    Private myThread As Thread
    Private mySortingComplete As Boolean

    'Konstruktor übernimmt die zu sortierende Liste. Der ThreadName hat nur
    'dokumentarischen Charakter.
    Sub New(ByVal ArrayToSort As ArrayList, ByVal ThreadName As String)
        myArrayToSort = ArrayToSort
        myThread = New Thread(New ThreadStart(AddressOf SortArray))
        myThread.Name = ThreadName
        myAutoResetEvent = New AutoResetEvent(True)
    End Sub

    'Thread starten und signalisieren, dass blockiert
    Public Sub StartSortingAsynchron()
        myAutoResetEvent.Reset()
        myThread.Start()
    End Sub

    Private Sub SortArray()

        Dim locSortCompletionStatus As SortCompletionStatus

        If Not myArrayToSort Is Nothing Then
            locSortCompletionStatus = Me.ShellSort()
        End If
        myAutoResetEvent.Set()
        'Dieses Ereignis könnte man einbinden, falls der Sort-Thread über das
        'Sortierende benachrichten soll.
        'RaiseEvent SortCompleted(Me, New SortCompletedEventArgs(locSortCompletionStatus))
    End Sub

    'Sortiert eine Arraylist, die IComparable-Member enthält.
    'Null-Werte oder inkompatible Typen werden nicht geprüft!
    Private Function ShellSort() As SortCompletionStatus

        Dim locOutCount, locInCount As Integer
        Dim locDelta As Integer
        Dim locElement As IComparable

        locDelta = 1

        'Größten Wert der Distanzfolge ermitteln
        Do
            locDelta = 3 * locDelta + 1
        Loop Until locDelta > myArrayToSort.Count

        Do
            'War einen zu groß, also wieder teilen
            locDelta \= 3

            'Shellsort's Kernalgorithmus
            For locOutCount = locDelta To myArrayToSort.Count - 1
                locElement = CType(myArrayToSort(locOutCount), IComparable)
                locInCount = locOutCount
                Do While CType(myArrayToSort(locInCount - locDelta), IComparable).CompareTo(locElement) = 1
                    If myTerminateThread Then
                        Return SortCompletionStatus.Aborted
                    End If
                    myArrayToSort(locInCount) = myArrayToSort(locInCount - locDelta)
                    locInCount = locInCount - locDelta
                    If (locInCount <= locDelta) Then Exit Do
                Loop
                myArrayToSort(locInCount) = locElement
            Next
        Loop Until locDelta = 0
        Return SortCompletionStatus.Completed

    End Function

    'Dispose beendet einen vielleicht noch laufenden Sortier-Thread
    Public Sub Dispose() Implements System.IDisposable.Dispose
        myTerminateThread = True
    End Sub

    'Stellt die benötigten Eigenschaften zur Verfügung
    Public ReadOnly Property AutoResetEvent() As AutoResetEvent
        Get
            Return myAutoResetEvent
        End Get
    End Property

    Public ReadOnly Property ArrayList() As ArrayList
        Get
            Return myArrayToSort
        End Get
    End Property
End Class

'Die beiden möglichen Ergebnisse, wenn der Sortier-Thread beendet wurde.
'Falls er durch Dispose abgebrochen wurde, liefert er Aborted zurück.
Public Enum SortCompletionStatus
    Completed
    Aborted
End Enum

'Dient nur der Ereignisübergabe, wenn Sie das SortCompleted-Ereignis
'nach Abbruch oder Abschluss des Sortierens auslösen wollen.
Public Class SortCompletedEventArgs
    Inherits EventArgs

    Private mySortCompletionStatus As SortCompletionStatus

    Sub New(ByVal scs As SortCompletionStatus)
        mySortCompletionStatus = scs
    End Sub

    Public Property SortCompletionStatus() As SortCompletionStatus
        Get
            Return mySortCompletionStatus
        End Get
        Set(ByVal Value As SortCompletionStatus)
            mySortCompletionStatus = Value
        End Set
    End Property

End Class
