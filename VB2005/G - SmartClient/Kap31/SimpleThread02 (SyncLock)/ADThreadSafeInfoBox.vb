Imports System.Threading

Public Class ADThreadSafeInfoBox
    Private Shared myText As String
    Private Shared myInstance As ADThreadSafeInfoBox
    Private Shared myThread As Thread
    Private Shared myManualResetEvent As ManualResetEvent

    Private Delegate Sub TSWriteActallyDelegate()
    Private Delegate Sub ThisInstanceCloseDelegate()

    Private Shared myThisInstanceCloseDelegate As ThisInstanceCloseDelegate

    Private Shared Sub ThisInstanceCloseActually()
        myInstance.Dispose()
    End Sub

    'Statischer Konstruktor erstellt neuen UI-Thread
    Shared Sub New()
        myText = ""
        myManualResetEvent = New ManualResetEvent(False)
        CreateInstanceThroughThread()
    End Sub

    'Teil des Konstruktors; könnte theoretisch auch von 
    'anderswo in Gang gesetzt werden. Diese Routine erstellt
    'den neuen UI-Thread und startet ihn...
    Private Shared Sub CreateInstanceThroughThread()
        myThread = New Thread(New ThreadStart(AddressOf CreateInstanceThroughThreadActually))
        myThread.Name = "2. UI-Thread"
        myThread.Start()
    End Sub

    '...und der neue UI-Thread erstellt jetzt das Formular
    'und bindet es an eine neue Nachrichtenwarteschlange.
    Private Shared Sub CreateInstanceThroughThreadActually()
        'Instanz des Formulars erstellen
        myInstance = New ADThreadSafeInfoBox
        'Wir müssen auf jeden Fall wissen, wann die Hauptapplikation (der Haupt-UI-Thread) geht.
        myThisInstanceCloseDelegate = New ThisInstanceCloseDelegate(AddressOf ThisInstanceCloseActually)

        AddHandler Application.ThreadExit, AddressOf ThreadExitHandler
        'Und wir müssen wissen, ab wann das Formular wirklich existiert;
        'vorher dürfen keine Ausgaben ins Formular erfolgen
        AddHandler myInstance.HandleCreated, AddressOf HandleCreatedHandler
        'und abwann nicht mehr. Für dieses Beispiel ist dieses Ereignis nicht soooo wichtig.
        AddHandler myInstance.HandleDestroyed, AddressOf HandleDestroyedHandler
        'Hier wird die Warteschlange gestartet
        Application.Run(myInstance)
    End Sub

    'Dieser Ereignis-Handler wird aufgerufen, wenn das Hauptprogramm beendet wird.
    'Der zweite UI-Thread wird damit beendet.
    Private Shared Sub ThreadExitHandler(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("ThreadExit")
        'Keine TextBox mehr vorhanden:
        ' Synchronisationsvoraussetzung für TSWrite schaffen
        myManualResetEvent.Reset()
        Try
            myInstance.Invoke(myThisInstanceCloseDelegate)
        Catch ex As Exception
        End Try
    End Sub

    'TSWrite signalisieren, dass die Ausgabe in die TextBox jetzt sicher ist,
    'da das Formular-Handle erstellt wurde.
    Private Shared Sub HandleCreatedHandler(ByVal sender As Object, ByVal e As EventArgs)
        Console.WriteLine("HandleCreated")
        myManualResetEvent.Set()
    End Sub

    'Vielleicht später mal wichtig; hier nur zur Demo.
    Private Shared Sub HandleDestroyedHandler(ByVal sender As Object, ByVal e As EventArgs)
        'Nur für Testzwecke
        Console.WriteLine("HandleDestroyed")
    End Sub

    'Nutzt TSWrite; siehe dort.
    Public Shared Sub TSWriteLine(ByVal Message As String)
        SyncLock (GetType(ADThreadSafeInfoBox))
            Message += vbNewLine
            TSWrite(Message)
        End SyncLock
    End Sub

    'Ausgabe ohne neue Zeile
    Public Shared Sub TSWrite(ByVal Message As String)
        SyncLock (GetType(ADThreadSafeInfoBox))
            'Synchronisierung: Wenn nach 50 Millisekunden 
            'keine TextBox vorhanden ist --> Befehl ignorieren
            If Not myManualResetEvent.WaitOne(50, True) Then
                Exit Sub
            End If
            myText += Message
            Try
                myInstance.Invoke(New TSWriteActallyDelegate(AddressOf TSWriteActually))
            Catch ex As Exception
            End Try
        End SyncLock
    End Sub

    'Thread-sichere Ausgabe in die TextBox mit Invoke
    Private Shared Sub TSWriteActually()
        myInstance.txtOutput.Text = myText
        myInstance.txtOutput.SelectionStart = myText.Length - 1
        myInstance.txtOutput.ScrollToCaret()
    End Sub
End Class