'Dieser Namensbereich enthält die benötigten Threading-Objekte
Imports System.Threading
Imports System.IO

Public Class frmMain

    Private Const cAmountOfElements As Integer = 600000
    Private Const cCharsPerString As Integer = 50
    Private Const cShowResults As Boolean = False

    'Delegaten für das Aufrufen von Invoke, da Controls nicht
    'Thread-Sicher sind. 
    'Für die Textbox zur Ausgabe
    Private Delegate Sub AddTBTextTSActuallyDelegate(ByVal txt As String)
    'Für das Einschalten der Buttons, wenn der Vorgang beendet ist.
    Private Delegate Sub TSEnableControlsDelegate()

    'Flag, dass bestimmt, wann alle Threads zu gehen haben,
    'wird nicht mehr benötigt, da alle Threads Hintergrund-Threads
    'sind, die automatisch bei Programmende mitbeendet werden.
    'Private myAbortAllThreads As Boolean

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

    'Simpler Zähler, der vom SortCompletion-Ereignis-Handler hochgezählt wird,
    'wenn ein Sortier-Thread beendet wurde
    Private mySortCompletion As Integer

    'Hilft beim Warten des Haupt-Threads auf Abschluss des Sortierens.
    Private mySyncUIResetEvent As ManualResetEvent

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

        'Synchronisation des UI-Threads, der angehalten wird,
        'bis beide Sortierungen beendet sind.
        mySyncUIResetEvent = New ManualResetEvent(False)

        'Ausgabetextbox bestimmen
        myAusgabeTextBox = Me.txtAusgabe

        'Controls disablen, damit kein zusätzlicher Hauptthread gestartet werden kann
        'Wenn der komplette Testparkur abgeschlossen ist, löst der Hauptthread ein
        'Ereignis aus, das das Formular einbindet. Diese Vorgehensweise dient nur der
        'Demonstration: Genau so gut könnte der Haupt-Thread die Controls auch indirekt
        'selbst wieder einschalten.
        btnBenchmarkStarten.Enabled = False
        btnBeenden.Enabled = False

        'Rückmeldungszähler zurücksetzen
        mySortCompletion = 0

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
        '(Das betrifft ist erster Linie das Erstellen des Test-Arrays).
    End Sub

    'Dies ist die eigentliche Haupt-Thread-Routine (aber nicht der UI-Thread!), die das Testarray
    'generiert und dann selbst wiederum entweder ein oder zwei Arbeits-Threads aufruft,
    'die die eigentliche Sortierung durchführen.
    Private Sub StartMainThread()

        Dim locStrings(cAmountOfElements - 1) As String
        Dim locGauge As New HighSpeedTimeGauge

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

            'Handler hinzufügen, der das Ende des Sortierens mitbekommt und dann wiederum
            'mySortCompletion hochzählt, damit die Warteschleife des Hauptthreads beendet werden kann
            AddHandler locFirstSortThread.SortCompleted, AddressOf SortCompletionHandler

            'los geht's
            locFirstSortThread.StartSortingAsynchron()

            'Warten, bis der Sortier-Thread abgeschlossen ist.
            'mySortCompletion wird durch das SortCompletion-Ereignis hochgezählt
            'wenn es 1 erreicht hat, schmeißt der Ereignishandler diesen Thread wieder an.
            mySyncUIResetEvent.WaitOne()

            'Handler wieder entfernen
            RemoveHandler locFirstSortThread.SortCompleted, AddressOf SortCompletionHandler

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

            'Zwei SortArrayThreaded-Instanzen erzeugen und ihnen die Teillisten übergeben
            Dim locFirstSortThread As New SortArrayThreaded(locFirstAL, "1. SortThread")
            Dim locSecondSortThread As New SortArrayThreaded(locSecondAL, "2. SortThread")

            AddTBText("Sortieren von " + cAmountOfElements.ToString + " Strings mit zwei Threads..." + vbNewLine)

            'Handler hinzufügen, die das Ende des Sortierens mitbekommem und dann wiederum
            'mySortCompletion hochzählen, damit die Warteschleife des Hauptthreads beendet werden kann
            AddHandler locFirstSortThread.SortCompleted, AddressOf SortCompletionHandler
            AddHandler locSecondSortThread.SortCompleted, AddressOf SortCompletionHandler

            'Los geht's!
            locFirstSortThread.StartSortingAsynchron()
            locSecondSortThread.StartSortingAsynchron()

            'Warten, bis beide Sortier-Threads beendet sind;
            'mySortCompletion wird durch das SortCompletion-Ereignis hochgezählt
            mySyncUIResetEvent.WaitOne()

            RemoveHandler locFirstSortThread.SortCompleted, AddressOf SortCompletionHandler
            RemoveHandler locSecondSortThread.SortCompleted, AddressOf SortCompletionHandler


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
                AddTBText(s + vbNewLine)
                AddTBText(vbNewLine)
            Next
        End If

        'Ereignis auslösen, das die Schaltflächen wieder einschaltet
        RaiseEvent MainThreadFinished()
        'Ereignishandler wieder entfernen
        RemoveHandler MainThreadFinished, AddressOf MainThreadFinishedHandler

    End Sub

    Private Sub SortCompletionHandler(ByVal sender As Object, ByVal e As SortCompletedEventArgs)
        mySortCompletion += 1
        If myUseTwoThread Then
            If mySortCompletion = 2 Then
                mySyncUIResetEvent.Set()
            End If
        Else
            If mySortCompletion = 1 Then
                mySyncUIResetEvent.Set()
            End If
        End If
    End Sub

    Private Sub MainThreadFinishedHandler()
        'Wichtig: Ruft ein Thread einen Ereignishandler auf, läuft dieser Ereignishandler
        'immer in dessen Thread, egal, zu welcher Klasse der Handler gehört. Deswegen
        'muss kann auch auf diesem Weg nur über Invoke auf den UI-Thread zugegriffen werden!
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
        'Da sowohl Arbeits- als auch Sortier-Threads als Hintegrund-Threads laufen,
        'ist kein Abbruchflag mehr erforderlich, anhand dessen ein Thread erkennen
        'kann, dass er ordentlich beendet werden soll. Hintergrund-Threads werden
        'automatisch mit der Anwendung beendet.
        'myAbortAllThreads = True
    End Sub

End Class

Public Class SortArrayThreaded

    Public Event SortCompleted(ByVal sender As Object, ByVal e As SortCompletedEventArgs)
    Private myArrayToSort As ArrayList
    Private myTerminateThread As Boolean
    Private mySortingComplete As Boolean
    Private myThreadName As String

    'Konstruktor übernimmt die zu sortierende Liste. Der ThreadName hat nur
    'dokumentarischen Charakter.
    Sub New(ByVal ArrayToSort As ArrayList, ByVal ThreadName As String)
        myArrayToSort = ArrayToSort
        myThreadName = ThreadName
    End Sub

    'Thread starten
    Public Sub StartSortingAsynchron()
        ThreadPool.QueueUserWorkItem(AddressOf SortArray)
    End Sub

    Private Sub SortArray(ByVal state As Object)

        Dim locSortCompletionStatus As SortCompletionStatus

        If Not myArrayToSort Is Nothing Then
            locSortCompletionStatus = Me.ShellSort()
        End If
        'Eine das Ereignis einbindenden Instanz mitteilen, dass der Thread beendet ist.
        RaiseEvent SortCompleted(Me, New SortCompletedEventArgs(locSortCompletionStatus, myThreadName))
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
    Private myThreadName As String

    Sub New(ByVal scs As SortCompletionStatus, ByVal ThreadName As String)
        mySortCompletionStatus = scs
    End Sub

    Public Property ThreadName() As String
        Get
            Return myThreadName
        End Get
        Set(ByVal Value As String)
            myThreadName = Value
        End Set
    End Property

    Public Property SortCompletionStatus() As SortCompletionStatus
        Get
            Return mySortCompletionStatus
        End Get
        Set(ByVal Value As SortCompletionStatus)
            mySortCompletionStatus = Value
        End Set
    End Property

End Class
