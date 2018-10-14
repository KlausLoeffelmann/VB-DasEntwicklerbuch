Public Class EinfacherAlarmgeber

    Private WithEvents myTrigger As Timer
    Private myAlarmzeit As Date
    Private myAlarmAktiviert As Boolean
    Private mySchwellwert As Integer = 2

    ''' <summary>
    ''' Wird ausgelöst, wenn eine bestimmte Zeit erreicht wurde.
    ''' </summary>
    ''' <param name="Sender">Das Objekt, das dieses Ereignis ausgelöst hat.</param>
    ''' <param name="e">AlarmEventArgs, die näheres zum Objekt aussagen.</param>
    ''' <remarks></remarks>
    Public Event Alarm(ByVal Sender As Object, ByVal e As AlarmEventArgs)

    Sub New(ByVal Alarmzeit As Date)
        Me.Alarmzeit = Alarmzeit
    End Sub

    Sub New(ByVal Alarmzeit As Date, ByVal Aktiviert As Boolean)
        Me.Alarmzeit = Alarmzeit
        Me.AlarmAktiviert = Aktiviert
    End Sub


    ''' <summary>
    ''' Ermittelt oder bestimmt, ob der Alarm aktiviert ist (True) oder nicht (False).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property AlarmAktiviert() As Boolean
        Get
            Return myAlarmAktiviert
        End Get
        Set(ByVal value As Boolean)
            If value <> myAlarmAktiviert Then
                If value Then
                    myTrigger = New Timer()
                    myTrigger.Interval = 1000
                    myTrigger.Start()
                    myAlarmAktiviert = True
                Else
                    myTrigger.Dispose()
                End If
            End If

        End Set
    End Property

    ''' <summary>
    ''' Ermittelt oder bestimmt, zu welcher Zeit - Aktivierung vorausgesetzt - der Alarm losgeht.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Property Alarmzeit() As Date
        Get
            Return myAlarmzeit
        End Get
        Set(ByVal value As Date)
            'Verhindern, dass dass die Alarmzeit in der Vergangenheit liegt
            'Dazu den Zeitteil des Datums an das aktuelle Datum hängen...
            value = Date.Now.Date.Add(value.TimeOfDay)
            '... und wenn der Zeitpunkt schon vorbei ist...
            If value < Date.Now Then
                '... diesen auf morgen verschieben.
                value = value.AddDays(1)
            End If
            myAlarmzeit = value
        End Set
    End Property

    Private Sub myTrigger_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTrigger.Tick
        If myAlarmzeit < DateTime.Now Then
            Dim locWeckzeitEventArgs As New AlarmEventArgs(Alarmzeit)
            OnWecken(locWeckzeitEventArgs)
            If locWeckzeitEventArgs.Neustellen Then
                Alarmzeit = locWeckzeitEventArgs.Alarmzeit
            Else
                AlarmAktiviert = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' Löst das Wecken aus.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub OnWecken(ByVal e As AlarmEventArgs)
        RaiseEvent Alarm(Me, e)
    End Sub
End Class

Public Class AlarmEventArgs
    Inherits EventArgs

    Private myAlarmzeit As Date
    Private myNeuStellen As Boolean

    Sub New(ByVal Alarmzeit As Date)
        myAlarmzeit = Alarmzeit
        myNeuStellen = True
    End Sub

    Sub New(ByVal Alarmzeit As Date, ByVal Neustellen As Boolean)
        myAlarmzeit = Alarmzeit
        myNeuStellen = Neustellen
    End Sub

    Public Property Alarmzeit() As Date
        Get
            Return myAlarmzeit
        End Get
        Set(ByVal value As Date)
            myAlarmzeit = value
        End Set
    End Property

    Public Property Neustellen() As Boolean
        Get
            Return myNeuStellen
        End Get
        Set(ByVal value As Boolean)
            myNeuStellen = value
        End Set
    End Property
End Class

