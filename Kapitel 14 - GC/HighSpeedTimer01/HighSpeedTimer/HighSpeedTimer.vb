Imports System.ComponentModel
Imports System.Runtime.InteropServices

Public Class HighSpeedTimer

    Private myTimerID As Integer                ' ID des Multimedia-Timers
    Private myUser As Integer                   ' Benuzerdefinierter Parameter, nicht verwendet.
    Private myTimerCapabilities As TimerCaps    ' Hält die TimeCaps, die die Timerauflösung beschreiben
    Private myMode As Integer = 1               ' 0=Einmalig, 1=Periodisch. 1 wird vordefiniert.

    Private myPeriodInMs As Integer             ' Wie oft soll getriggert werden?
    Private myresolutionInMs As Integer         ' Welche Auflösung kann der Timer?
    Private myHasStarted As Boolean             ' Läuft der Timer?

    'Delegate, der für den Rückruf aus dem Betriebssystem benötigt wird,
    'wenn der Timer abgelaufen ist...
    Private Delegate Sub TimeProc(ByVal id As Integer, ByVal msg As Integer,
                                  ByVal user As Integer, ByVal reserved1 As Integer,
                                  ByVal reserved2 As Integer)

    '...und in dieser Delegatenvariable definiert wird.
    Private myCallBackTimeProc As TimeProc

    'Das Ereignis, was durch die Rückrufroutine ausgelöst wird,
    'wenn der Timer abgelaufen ist.
    Public Event Elapsed(ByVal sender As Object, ByVal e As EventArgs)

    'Ermittelt die Fähigkeiten des Timers auf diesem Rechner.
    <DllImport("winmm.dll")>
    Private Shared Function timeGetDevCaps(ByRef caps As TimerCaps,
                                           ByVal sizeOfTimerCaps As Integer) As Integer
    End Function

    'Erstellt und startet den Multi Media-Timer.
    <DllImport("winmm.dll")>
    Private Shared Function timeSetEvent(ByVal delay As Integer, ByVal resolution As Integer,
                                         ByVal CallBackProc As TimeProc, ByVal user As Integer,
                                         ByVal mode As Integer) As Integer
    End Function

    'Löscht einen Timer, der gerade in Betrieb ist.
    <DllImport("winmm.dll")>
    Private Shared Function timeKillEvent(ByVal id As Integer) As Integer
    End Function

    ''' <summary>
    ''' Erstellt eine Instanz dieser Klasse und setzt Wiederholungsfrequenz 
    ''' des Timer-Triggers und Auflösung in Millisekunden.
    ''' </summary>
    ''' <param name="periodInMs">Wiederholungsfrequenz - wie oft soll der Timer auslösen.</param>
    ''' <param name="resolutionInMs">Auflösung des Timers (der Wert 1ms liefert 
    ''' die genauesten Ergebnisse).</param>
    ''' <remarks></remarks>
    Sub New(ByVal periodInMs As Integer, ByVal resolutionInMs As Integer)
        'Ermittelt die Fähigkeiten des Multimedia Timers, die dann über 
        'TimerCapabilities aubrufbar sind.
        Dim ret = timeGetDevCaps(myTimerCapabilities, Marshal.SizeOf(myTimerCapabilities))

        myPeriodInMs = periodInMs
        myresolutionInMs = resolutionInMs
        myCallBackTimeProc = AddressOf CallBackTimeProc
    End Sub

    ''' <summary>
    ''' Startet den Timer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()

        If myHasStarted Then
            Return
        End If

        Dim ret = timeSetEvent(myPeriodInMs, myresolutionInMs,
                               myCallBackTimeProc, myUser, myMode)
        Dim hr = Marshal.GetHRForLastWin32Error
        If ret = 0 Then
            Throw New Win32Exception("Der Timer konnte nicht gestartet werden!")
        Else
            myTimerID = ret
            myHasStarted = True
        End If

    End Sub

    ''' <summary>
    ''' Stoppt den Timer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub [Stop]()
        If Not myHasStarted Then
            Return
        End If

        timeKillEvent(myTimerID)
    End Sub

    'Die Rückrufroutine, die vom Betriebssstem aufgerufen wird, 
    'wenn der Timer abgelaufen ist.
    Private Sub CallBackTimeProc(ByVal id As Integer, ByVal msg As Integer,
                                 ByVal user As Integer, ByVal param1 As Integer,
                                 ByVal param2 As Integer)
        RaiseEvent Elapsed(Me, EventArgs.Empty)
    End Sub

    ''' <summary>
    ''' Ermittelt die Möglichkeiten des Systems bezüglich des Timers.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TimerCapabilities As TimerCaps
        Get
            Return myTimerCapabilities
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt, ob der Timer gestartet wurde.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HasStarted As Boolean
        Get
            Return myHasStarted
        End Get
    End Property

End Class

'Wird benötigt für die Parameterübergabe an die Betriebssystemroutinen
<StructLayout(LayoutKind.Sequential)>
Public Structure TimerCaps
    Public PeriodMin As Integer
    Public periodMax As Integer
End Structure
