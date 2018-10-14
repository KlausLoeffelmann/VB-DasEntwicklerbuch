Imports System.Collections.ObjectModel

''' <summary>
''' Verwaltet eine Liste mit Alarmgeber-Objekten, und löst ein Ereignis aus 
''' wenn eines der Alarmgeber-Objekte 
''' </summary>
''' <remarks></remarks>
Public Class Terminliste
    Inherits Collection(Of Alarmgeber)

    ''' <summary>
    ''' Wird ausgelöst, wenn eines der dieser Instanz hinzugefügten 
    ''' Alarmgeber-Objekte seinerseits ein Alarm-Ereignis auslöst.
    ''' </summary>
    ''' <param name="sender">Referenz, auf das Alarmgeber-Objekt, das das Ereignis ausgelöst hat.</param>
    ''' <param name="e">AlarmEvetArgs-Instanz, die Parameter zum Ereignis enthalten.</param>
    ''' <remarks></remarks>
    Public Event Alarm(ByVal sender As Object, ByVal e As AlarmEventArgs)

    'Enthält Nothing oder das Datum des als nächstes anstehenden Termin.
    Private myNächsterTermin As Nullable(Of Date)

    'Wird beispielsweise durch Add oder Insert der Collection-Klasse ausgelöst.
    'Überschrieben, da das Alarm-Ereignis des Objektes mit der 
    'AlarmHandler-Prozedur verknüpft werden muss.
    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As Alarmgeber)

        'Das Alarm-Ereignis des Objektes dynamisch mit der Prozedur AlarmHandler verbinden.
        AddHandler item.Alarm, AddressOf AlarmHandler

        'Die Basisprozedur machen lassen, was sie machen muss
        '(nämlich das Element an die richtige Stelle setzen).
        MyBase.InsertItem(index, item)

        'Liste hat sich geändert - der nächste Termin könnte ein anderer werden!
        AktualisiereNächsteTerminEigenschaft()
    End Sub

    'Wird durch Zuweisung eines Elementes über die Item-Eigenschaft aufgerufen.
    'Überschrieben, da das Alarm-Ereignis des Objektes mit der 
    'AlarmHandler-Prozedur verknüpft werden muss.
    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As Alarmgeber)

        'Das alte Element an dieser Stelle lösen:
        RemoveHandler Me(index).Alarm, AddressOf AlarmHandler

        'Das neue Element verknüpfen
        AddHandler item.Alarm, AddressOf AlarmHandler

        'Die Basisprozedur machen lassen, was sie machen muss
        '(nämlich das Element an die richtige Stelle setzen).
        MyBase.SetItem(index, item)
    End Sub

    'Wird beispielsweise durch Remove oder RemoveAt der Collection-Klasse aufgerufen.
    'Überschrieben, um das verknüpfte Ereignis wieder mit AlarmHandler zu lösen.
    Protected Overrides Sub RemoveItem(ByVal index As Integer)

        'Das Alarm-Ereignis des Objektes dynamisch von der Prozedur AlarmHandler lösen.
        RemoveHandler Me(index).Alarm, AddressOf AlarmHandler

        'Die Basisprozedur machen lassen, was sie machen muss
        '(nämlich das Element aus der Liste löschen).
        MyBase.RemoveItem(index)

        'Liste hat sich geändert - der nächste Termin könnte ein anderer werden!
        AktualisiereNächsteTerminEigenschaft()
    End Sub

    'Beim Löschen aller Elemente werden die Ereignisse aller Objekte gelöst.
    Protected Overrides Sub ClearItems()

        'Alle Ereignisse lösen.
        For Each locItem As Alarmgeber In Me
            RemoveHandler locItem.Alarm, AddressOf AlarmHandler
        Next

        'Basisroutine aufrufen.
        MyBase.ClearItems()

        'Gibt keinen "nächsten Termin" mehr.
        myNächsterTermin = Nothing
    End Sub

    ''' <summary>
    ''' Löst ein Ereignis aus, sobald diese Routine ihrerseits als 
    ''' Ereignisbehandlungsroutine eines der Elemente in dieser Collection in Aktion tritt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AlarmHandler(ByVal sender As Object, ByVal e As AlarmEventArgs)
        RaiseEvent Alarm(sender, e)
    End Sub

    ''' <summary>
    ''' Sucht den als nächstes anliegenden Termin in der Elementeliste.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AktualisiereNächsteTerminEigenschaft()

        'Keine Elemente vorhanden...
        If Me.Count = 0 Then

            '...dann gibt es keinen nächsten Termin
            myNächsterTermin = Nothing
        Else

            'Alle Elemente durchsuchen, welches Element "jünger"
            'als alle anderen ist.
            myNächsterTermin = Me(0).Alarmzeit
            For Each locItem As Alarmgeber In Me
                If locItem.Alarmzeit < myNächsterTermin.Value Then
                    myNächsterTermin = locItem.Alarmzeit
                End If
            Next
        End If
    End Sub

    ''' <summary>
    ''' Liefert den nächsten anstehenden Termin oder Nothing zurück.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property NächterTermin() As Nullable(Of Date)
        Get

            'Nur Wert zurückliefern. Die Suche nach dem jüngsten
            'Datum wurde schon bei jeder Listenänderung durchgeführt.
            Return myNächsterTermin.Value
        End Get
    End Property
End Class

Public Class Alarmgeber

    Private WithEvents myTrigger As Timer
    Private myAlarmText As String
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

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String)
        Me.Alarmzeit = Alarmzeit
        Me.AlarmText = AlarmText
    End Sub

    Sub New(ByVal Alarmzeit As Date, ByVal AlarmText As String, ByVal Aktiviert As Boolean)
        Me.Alarmzeit = Alarmzeit
        Me.AlarmAktiviert = Aktiviert
        Me.AlarmText = AlarmText
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
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub OnWecken(ByVal e As AlarmEventArgs)
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

