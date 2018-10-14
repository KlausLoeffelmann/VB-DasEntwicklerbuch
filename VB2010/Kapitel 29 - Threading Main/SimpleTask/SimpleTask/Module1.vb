'Immer dran denken, diese Imports vorzunehmen,
'wenn Sie mit Task und Thread-Objekten arbeiten!
Imports System.Threading
Imports System.Threading.Tasks

Module Module1

    'Konstante, die bestimmt, wie oft in den Tasks geloopt wird.
    Private Const LOOPS As Integer = 8
    Private Const SPIN_ONE As Long = 8000000
    Private Const SPIN_TWO As Long = 10000000

    Sub Main()

        'WaitingForTasks()
        PassingReturningTaskValues()
        Console.ReadKey()
        Return

        'Erstellt einen Task - startet ihn aber nicht.
        Dim firstTask As New Task(
            Sub()
                Console.WriteLine("Starting Task ID: " & Task.CurrentId.ToString)
                Console.WriteLine("Equals Thread ID: " & Thread.CurrentThread.ManagedThreadId.ToString)
                For count = 0 To LOOPS
                    Console.WriteLine(String.Format("ThreadId: {0:000} - Count equals: {1}",
                                      Thread.CurrentThread.ManagedThreadId,
                                      count))
                    'Arbeitslast simulieren
                    Thread.SpinWait(SPIN_ONE)
                Next
            End Sub)

        'Erstellt einen Task über die Factory-Klasse und startet ihn.
        '(Über die Factory-Klasse geht das auch gar nicht anders.)
        Dim taskByFactory = Task.Factory.StartNew(
            Sub()
                Console.WriteLine("Starting Task ID: " & Task.CurrentId.ToString)
                Console.WriteLine("Equals Thread ID: " & Thread.CurrentThread.ManagedThreadId.ToString)
                For count = 0 To LOOPS
                    Console.WriteLine(String.Format("ThreadId: {0:000} - Count equals: {1}",
                                      Thread.CurrentThread.ManagedThreadId,
                                      count))
                    'Arbeitslast simulieren
                    Thread.SpinWait(SPIN_TWO)
                Next
            End Sub)

        'Der erste Task wird jetzt erst gestartet:
        firstTask.Start()

        'Wenn Sie eine Taste drücken, während die anderen
        'Tasks noch laufen, wird die Anwendung dennoch beendet.
        Console.WriteLine("Hauptthread ist fertig und wartet!")
        Console.Read()
    End Sub

    Sub WaitingForTasks()

        Dim firstTask As New Task(
            Sub()

                Console.WriteLine("Starting Task ID: " & Task.CurrentId.ToString)
                Console.WriteLine("Equals Thread ID: " & Thread.CurrentThread.ManagedThreadId.ToString)
                For count = 0 To LOOPS
                    Console.WriteLine(String.Format("ThreadId: {0:000} - Count equals: {1}",
                                      Thread.CurrentThread.ManagedThreadId,
                                      count))
                    'Arbeitslast simulieren
                    Thread.SpinWait(SPIN_ONE)
                Next
            End Sub)

        'Erstellt einen Task über die Factory-Klasse und startet ihn.
        '(Über die Factory-Klasse geht das auch gar nicht anders.)
        Dim taskByFactory = Task.Factory.StartNew(
            Sub()
                Console.WriteLine("Starting Task ID: " & Task.CurrentId.ToString)
                Console.WriteLine("Equals Thread ID: " & Thread.CurrentThread.ManagedThreadId.ToString)
                For count = 0 To LOOPS
                    Console.WriteLine(String.Format("ThreadId: {0:000} - Count equals: {1}",
                                      Thread.CurrentThread.ManagedThreadId,
                                      count))
                    'Arbeitslast simulieren
                    Thread.SpinWait(SPIN_TWO)
                Next
            End Sub)

        'Der erste Task wird jetzt erst gestartet:
        firstTask.Start()

        'Wenn Sie eine Taste drücken, während die anderen
        'Tasks noch laufen, wird die Anwendung dennoch beendet.
        Console.WriteLine("Hauptthread ist fertig und wartet auf Ergebnisse!")

        'Die Tasks, auf die die Anwendung warten soll, in ein Task-Array packen
        '(Lokaler Typrückschluss macht automatisch ein Array vom Typ Task daraus!)
        Dim tasksToWaitFor = {firstTask, taskByFactory}

        'Warten, bis der erste Task seine Aufgabe beendet hat:
        Dim taskFirstFinishedIndex = Task.WaitAny(tasksToWaitFor)

        'Rausfinden, welcher Task beendet wurde: Der Index steht im Rückgabewert von WaitAny.
        Console.WriteLine(If(tasksToWaitFor(taskFirstFinishedIndex) Is taskByFactory,
                             "Factory Task wurde zuerst beendet!",
                             "Manueller Task wurde zuerst beendet!"))

        'Warten, dass alle (restlichen) Tasks beendet wurden:
        Task.WaitAll(tasksToWaitFor)
        Console.WriteLine("Alle Tasks wurden beendet.")
        Console.Read()
    End Sub

    'Methode, die als Task ausgeführt werden soll und einen Parameter entgegen nimmt:
    '(Die Methode, die vorher der Statement Lambda war).
    Function WorkingProc(ByVal spinValue As Integer) As Long

        Dim sw = Stopwatch.StartNew

        Console.WriteLine("Starting Task ID: " & Task.CurrentId.ToString)
        Console.WriteLine("Equals Thread ID: " & Thread.CurrentThread.ManagedThreadId.ToString)
        For count = 0 To LOOPS
            Console.WriteLine(String.Format("ThreadId: {0:000} - Count equals: {1}",
                              Thread.CurrentThread.ManagedThreadId,
                              count))
            'Arbeitslast simulieren
            Thread.SpinWait(spinValue)
        Next

        sw.Stop()
        Return sw.ElapsedMilliseconds

    End Function

    Sub PassingReturningTaskValues()

        'Erstellt den ersten Task direkt, startet ihn aber noch nicht.
        Dim firstTask As New Task(Of Long)(AddressOf WorkingProc, SPIN_ONE)

        'Erstellt einen zweiten Task über die Factory-Klasse und startet ihn.
        Dim taskByFactory = Task.Factory.StartNew(Of Long)(AddressOf WorkingProc, SPIN_TWO)

        'Der erste Task wird jetzt erst gestartet:
        firstTask.Start()

        Console.WriteLine("Hauptthread ist fertig und wartet auf Ergebnisse!")

        'Die Tasks, auf die die Anwendung warten soll, in ein Task-Array packen
        '(Lokaler Typrückschluss macht automatisch ein Array vom Typ Task daraus!)
        Dim tasksToWaitFor = {firstTask, taskByFactory}

        'Warten, bis der erste Task seine Aufgabe beendet hat:
        Dim taskFirstFinishedIndex = Task.WaitAny(tasksToWaitFor)

        'Rausfinden, welcher Task beendet wurde: Der Index steht im Rückgabewert von WaitAny.
        Console.WriteLine(If(tasksToWaitFor(taskFirstFinishedIndex) Is taskByFactory,
                             "Factory Task wurde zuerst beendet nach ",
                             "Manueller Task wurde zuerst beendet nach ") &
                         tasksToWaitFor(taskFirstFinishedIndex).Result.ToString & " ms.")

        'Warten, dass alle (restlichen) Tasks beendet wurden:
        Task.WaitAll(tasksToWaitFor)
        Console.WriteLine("Alle Tasks wurden beendet.")
        Console.Read()
    End Sub

End Module
