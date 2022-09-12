Public Class frmMain
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region

    <STAThread()> _
    Public Shared Sub Main()

        Dim frmSplash As New frmMain
        frmSplash.Text = "Dies ist der Splash"
        frmSplash.Show()

        'Hier beginnt die Programminitialisierung
        Dim frmMainInstanz1 As New frmMain
        Dim frmMainInstanz2 As New frmMain
        frmMainInstanz1.Text = "Erstes Formular"
        frmMainInstanz2.Text = "Zweites Formular"

        'Hier gibt's noch 'was anderes zu initialisieren
        'Wir halten den aktuellen Thread das simulierend
        'einfach für 1000 Millisekunden an
        System.Threading.Thread.CurrentThread.Sleep(1000)

        'Initialisierung ist vorbei,
        'Splash schließen und verwerfen
        frmSplash.Dispose()

        'So können beide Dialoge (fast) gleichberechtigt
        'nebeneinander leben
        frmMainInstanz2.Show()
        Application.Run(frmMainInstanz1)

    End Sub

End Class

