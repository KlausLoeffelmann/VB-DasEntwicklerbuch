'Dieser Namensbereich enthält die benötigten Threading-Objekte
Imports System.Threading

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        Thread.CurrentThread.Name = "MainThread"

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
    Friend WithEvents btnBeenden As System.Windows.Forms.Button
    Friend WithEvents btnThreadStarten As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnBeenden = New System.Windows.Forms.Button
        Me.btnThreadStarten = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'btnBeenden
        '
        Me.btnBeenden.Location = New System.Drawing.Point(280, 24)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 1
        Me.btnBeenden.Text = "Beenden"
        '
        'btnThreadStarten
        '
        Me.btnThreadStarten.Location = New System.Drawing.Point(8, 24)
        Me.btnThreadStarten.Name = "btnThreadStarten"
        Me.btnThreadStarten.Size = New System.Drawing.Size(248, 32)
        Me.btnThreadStarten.TabIndex = 3
        Me.btnThreadStarten.Text = "Thread starten"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(392, 86)
        Me.Controls.Add(Me.btnThreadStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Simple Thread"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Statische Variable, damit die Threads durchnummeriert werden können.
    'Dient nur zur späteren Unterscheidung des laufenden Threads, wenn
    'er Ergebnisse im Ausgabefenster darstellt.
    Private myArbeitsThreadNr As Integer = 1
    Private myThreadString As String

    'Dies ist der eigentliche Arbeits-Thread (Worker Thread), der das
    'Hochzählen und die Werteausgabe übernimmt
    Private Sub UmfangreicheBerechnung()

        Dim strTemp As String

        For c As Integer = 0 To 50
            strTemp = Thread.CurrentThread.Name + ":: " + c.ToString
            'Der Thread wartet maximal eine Sekunde; bekommt er in dieser
            'Zeit keinen Zugriff auf den Code, steigt er aus.
            If Not Monitor.TryEnter(Me, 1) Then
                ADThreadSafeInfoBox.TSWriteLine(Thread.CurrentThread.Name + " meldet: Gerade besetzt!")
                Thread.CurrentThread.Sleep(50)
            Else
                'Zugriff wurde gewährt - jetzt nimmt der Arbeits-Thread
                'erst seine eigentliche Arbeit auf
                myThreadString = ""
                For z As Integer = 0 To strTemp.Length - 1
                    myThreadString += strTemp.Substring(z, 1)
                    Thread.CurrentThread.Sleep(5)
                Next
                ADThreadSafeInfoBox.TSWriteLine(myThreadString)
                Monitor.Exit(Me)

            End If

        Next
    End Sub

    Private Sub btnThreadStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnThreadStarten.Click
        'Dieses Objekt kapselt den eigentlichen Thread
        Dim locThread As Thread
        'Dieses Objekt benötigen Sie, um die Prozedur zu bestimmen,
        'die den Thread ausführt.
        Dim locThreadStart As ThreadStart

        'Threadausführende Prozedur bestimmen
        locThreadStart = New ThreadStart(AddressOf UmfangreicheBerechnung)
        'ThreadStart-Objekt dem Thread-Objekt übergeben
        locThread = New Thread(locThreadStart)
        'Thread-Namen bestimmen
        locThread.Name = "Arbeits-Thread: " + myArbeitsThreadNr.ToString
        'Thread starten
        locThread.Start()
        'Zähler, damit die Threads durch ihren Namen unterschieden werden können
        myArbeitsThreadNr += 1

    End Sub

    Private Sub btnBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeenden.Click
        'Einfach so geht's normalerweise nicht
        Me.Close()
    End Sub
End Class
