Imports System.ComponentModel   ' EventHandlerList-Auslistung
Imports System.Threading        ' Thread.Sleep um Arbeitslast zu simulieren.

Public Class Form1

    'Ermittelt Zufallszahlen, die wir brauchen, um verschiedene 
    'Zeitspannen lange zu warten (zur Arbeitslastsimulation).
    Private myRandomGenerator As New Random

    'Die Ereignis-Behandlungsmethode für die Click-Ereignisse aller Debug-Buttons.
    Private Sub DebugButton_DebugClick(ByVal sender As Object,
                                       ByVal e As System.EventArgs) _
        Handles DebugButton1.DebugClick, DebugButton2.DebugClick,
                DebugButton3.DebugClick

        'Simulieren, dass die Arbeitslast zwischen 250 und 2000 ms dauert.
        'Die Schaltflächen werden dabei ge-disablet, damit man sieht,
        'wann es weiter geht.
        DirectCast(sender, Control).Enabled = False

        'Der Windows-Nachrichten-Warteschlange Zeit zum "Luftholen" geben,
        'damit das Disabeln der Schaltfläche stattfindet.
        My.Application.DoEvents()

        'Arbeitslast simulieren: Thread.Sleep setzt den aktuellen Thread aus.
        System.Threading.Thread.Sleep(myRandomGenerator.Next(250, 2000))

        'Danach die Schaltfläche wieder aktivieren.
        DirectCast(sender, Control).Enabled = True

    End Sub

    'Wird ausgelöst, wenn der Result-Button angeklickt wird,
    'und dann zeigt die Anwendung eine Liste der Ereignisse an,
    'die durch das Klicken der verschiedenen Debug-Schaltflächen 
    'zustande gekommen ist.
    Private Sub ResultDebugButton_Click(ByVal sender As System.Object,
                                        ByVal e As System.EventArgs) _
                                    Handles ResultDebugButton.Click

        'Das Ergebnisformular erzeugen wir jetzt 'on the fly'
        Dim resultForm As New Form With {.Text = "Ergebnisliste"}

        'Listbox dem Formular hinzufügen
        Dim resultList As New ListBox() With {.Dock = DockStyle.Fill}

        'Startposition des Fensters ist Mitte des Bildschirms.
        resultForm.StartPosition = FormStartPosition.CenterScreen

        'Ergebnisliste zuordnen:
        resultList.DataSource = DebugButton.DebugClickInfos

        'Die ListBox auf das Formular packen.
        resultForm.Controls.Add(resultList)

        'Dialog anzeigen.
        resultForm.ShowDialog()
    End Sub
End Class

'Diese Klasse speichert ein Ereignisdatensatz.
Public Class DebugClickInfo
    Public Property Sender As Object                ' Wer hat ausgelöst??
    Public Property EventTime As Date               ' Wann wurde ausgelöst?
    Public Property ExecutionDuration As TimeSpan   ' Wie lange hat Behandlung gedauert?

    'ToString ist überschrieben, damit wir eine Liste mit Instanzen
    'dieser Klasse direkt einer ListBox zuweisen können. Damit übernimmt
    'die DebugClickInfo-Klasse selber die Darstellung seines Inhalts als Text.
    Public Overrides Function ToString() As String

        'Rückgabestring zusammenbasteln. Erst der Ereigniszeitpunkt,
        'dann die Dauer und schließlich der Sender, der das Ereignis ausgelöst hat.
        Dim retString = EventTime.ToLongTimeString & ":  "
        retString &= ExecutionDuration.ToString("ss\:fff") & "    (Sender: "

        'Wenn es sich um ein Steuerelement als Sender handelt,
        'geben wir den Namen aus, anderenfalls das, was ToString liefert.
        If GetType(Control).IsAssignableFrom(Sender.GetType) Then
            retString += DirectCast(Sender, Control).Name
        Else
            retString += Sender.ToString
        End If

        retString &= ")"
        Return retString
    End Function
End Class

'Der DebugButton kann das Gleiche wie der "normale" Button
'bekommt aber ein zusätzliches Ereignis, dass durch einen 
'Custom Event Handler ein Protokoll aller "Klicks" führt.
Public Class DebugButton
    Inherits Button

    'Die Liste der Delegaten, wenn die Ereignisse in anderen Komponenten
    '(zum Beispiel vom Form in diesem Beispiel) registriert werden.
    Private myEventHandlers As EventHandlerList = New EventHandlerList

    'Die Ergebnisliste, in der verzeichnet wird, wie lange was gedauert hat.
    Private Shared s_debugClickInfos As New List(Of DebugClickInfo)

    'So bekommt die Komponente mit, wenn geklickt wurde.
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        RaiseEvent DebugClick(Me, e)
    End Sub

    'Dieser Code-Block definiert den CustomEreignis.
    Custom Event DebugClick As EventHandler

        'Wird aufgerufen, wenn eine Komponente, die das Ereignis 
        'konsumieren möchte, es "verdrahtet".
        AddHandler(ByVal value As EventHandler)
            'Den übergebenden EventHandler in der Ereignis-Delegaten-Liste 
            'dieser Instanz speichern. "DebugClick" ist hier ein beliebiger
            'aber eindeutiger Name, den wir zum Wiederfinden aller Registraten 
            'an diesem Ereignis benötigen.
            myEventHandlers.AddHandler("DebugClick", value)
        End AddHandler

        'Wird aufgerufen, wenn eine Komponante ein verdrahtetes Ereignis wieder löst.
        RemoveHandler(ByVal value As EventHandler)
            'EventHandler aus der Ereignis-Delegaten-Liste wieder entfernen.
            myEventHandlers.RemoveHandler("DebugClick", value)
        End RemoveHandler

        'Wird aufgerufen, wenn eine Instanz dieser Klasse 
        'das DebugClick-Ereignis auslöst.
        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)

            'Gibt es überhaupt Registraten an dieser Ereignis?
            If myEventHandlers.Item("DebugClick") IsNot Nothing Then
                'Alle Registraten des Ereignisses dieser Instanz durchlaufen
                For Each delItem In myEventHandlers.Item("DebugClick").GetInvocationList

                    'Alles entsprechend messen und ...
                    Dim eventTime = Now
                    Dim sw = Stopwatch.StartNew
                    CType(delItem, EventHandler).Invoke(sender, e)
                    sw.Stop()

                    '... die Ergebnisse in die Liste schreiben.
                    s_debugClickInfos.Add(New DebugClickInfo With {
                                          .EventTime = eventTime,
                                          .ExecutionDuration =
                                               TimeSpan.FromMilliseconds(sw.ElapsedMilliseconds),
                                          .Sender = sender
                                          })
                Next
            End If
        End RaiseEvent

    End Event

    'Statische Eigenschaft, die die Ergebnisliste der "Ereignisaufzeichnungen"
    'alle Instanzen dieser Klasse hat.
    Public Shared ReadOnly Property DebugClickInfos As List(Of DebugClickInfo)
        Get
            Return s_debugClickInfos
        End Get
    End Property

End Class
