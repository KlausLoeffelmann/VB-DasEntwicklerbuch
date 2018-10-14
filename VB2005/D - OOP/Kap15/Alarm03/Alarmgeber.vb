Public Class Alarmgeber

    Public Delegate Sub AlarmDelegate(ByVal sender As Object, ByVal e As AlarmEventArgs)

    Private WithEvents myTrigger As Timer
    Private myAlarmText As String
    Private myAlarmzeit As Date
    Private myAlarmAktiviert As Boolean
    Private mySchwellwert As Integer = 2
    Private myAlarmDelegate As AlarmDelegate

    ''' <summary>
    ''' Wird ausgelöst, wenn eine bestimmte Zeit erreicht wurde.
    ''' </summary>
    ''' <param name="Sender">Das Objekt, das dieses Ereignis ausgelöst hat.</param>
    ''' <param name="e">AlarmEventArgs, die näheres zum Objekt aussagen.</param>
    ''' <remarks></remarks>
    Public Event Alarm(ByVal Sender As Object, ByVal e As AlarmEventArgs)

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String, ByVal AlarmRückrufroutine As AlarmDelegate)
        Me.Alarmzeit = Alarmzeit
        Me.AlarmText = AlarmText
        myAlarmDelegate = AlarmRückrufroutine
    End Sub

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String, ByVal Aktiviert As Boolean, ByVal AlarmRückrufroutine As AlarmDelegate)
        Me.Alarmzeit = Alarmzeit
        Me.AlarmAktiviert = Aktiviert
        Me.AlarmText = AlarmText
        myAlarmDelegate = AlarmRückrufroutine
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

    Public Overridable Property AlarmText() As String
        Get
            Return myAlarmText
        End Get
        Set(ByVal value As String)
            myAlarmText = value
        End Set
    End Property

    Private Sub myTrigger_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTrigger.Tick
        If myAlarmzeit < DateTime.Now Then
            Dim locWeckzeitEventArgs As New AlarmEventArgs(Alarmzeit, Me.AlarmText)
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
    ''' Löst dabei nicht nur das Alarm-Ereignis aus, sondern ruft auch 
    ''' indirekt über einen Delegaten (sofern definiert) eine 
    ''' registrierte Prozedur "zurück".
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub OnWecken(ByVal e As AlarmEventArgs)
        If myAlarmDelegate IsNot Nothing Then
            myAlarmDelegate.Invoke(Me, e)
        End If
        RaiseEvent Alarm(Me, e)
    End Sub

    Public Overrides Function ToString() As String
        Return Alarmzeit.ToString("dd.MM.yyyy HH:mm:ss  -  ") & AlarmText
    End Function
End Class

Public Class AlarmEventArgs
    Inherits EventArgs

    Private myAlarmzeit As Date
    Private myAlarmText As String
    Private myNeuStellen As Boolean

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String)
        myAlarmzeit = Alarmzeit
        myAlarmText = AlarmText
        myNeuStellen = True
    End Sub

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String, ByVal Neustellen As Boolean)
        myAlarmzeit = Alarmzeit
        myAlarmText = AlarmText
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

    Public Property AlarmText() As String
        Get
            Return myAlarmText
        End Get
        Set(ByVal value As String)
            myAlarmText = value
        End Set
    End Property
End Class

