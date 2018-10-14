Imports System.Threading

Public Class ADThreadSafeInfoBox
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

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
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtOutput
        '
        Me.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtOutput.Location = New System.Drawing.Point(0, 0)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOutput.Size = New System.Drawing.Size(488, 430)
        Me.txtOutput.TabIndex = 0
        Me.txtOutput.Text = ""
        '
        'ADThreadSafeInfoBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 430)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtOutput)
        Me.Name = "ADThreadSafeInfoBox"
        Me.ShowInTaskbar = False
        Me.Text = "Status:"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared myText As String
    Private Shared myInstance As ADThreadSafeInfoBox
    Private Shared myThread As Thread
    Private Shared myManualResetEvent As ManualResetEvent

    Private Delegate Sub TSWriteActallyDelegate()

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
        myInstance.Close()
        Application.ExitThread()
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
            'Synchronisierung: Wenn nach 500 Millisekunden 
            'keine TextBox vorhanden ist --> Befehl ignorieren
            If Not myManualResetEvent.WaitOne(500, True) Then
                Exit Sub
            End If
            myText += Message
            myInstance.Invoke(New TSWriteActallyDelegate(AddressOf TSWriteActually))
        End SyncLock
    End Sub

    'Thread-sichere Ausgabe in die TextBox mit Invoke
    Private Shared Sub TSWriteActually()
        myInstance.txtOutput.Text = myText
        myInstance.txtOutput.SelectionStart = myText.Length - 1
        myInstance.txtOutput.ScrollToCaret()
    End Sub
End Class
