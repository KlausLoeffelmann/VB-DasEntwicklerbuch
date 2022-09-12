Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf�gen

    End Sub

    ' Die Form �berschreibt den L�schvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F�r Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist f�r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents btnLinieZeichnen As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnLinieZeichnen = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnLinieZeichnen
        '
        Me.btnLinieZeichnen.Location = New System.Drawing.Point(80, 96)
        Me.btnLinieZeichnen.Name = "btnLinieZeichnen"
        Me.btnLinieZeichnen.Size = New System.Drawing.Size(128, 32)
        Me.btnLinieZeichnen.TabIndex = 0
        Me.btnLinieZeichnen.Text = "Linie zeichnen"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnLinieZeichnen)
        Me.Name = "frmMain"
        Me.Text = "Einfache GDI-Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Klassenweiter Member, der von Click und OnPaint aus zug�nglich ist
    Private myDrawLineFlag As Boolean

    Private Sub btnLinieZeichnen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinieZeichnen.Click

        'Absofort darf gezeichnet werden!
        myDrawLineFlag = True
        'Client-Bereich f�r ung�ltig erkl�ren --> OnPaint wird ausgel�st,
        'und damit, da myDrawLineFlag jetzt true ist, die Linie gezeichnet.
        Me.Invalidate()

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        If myDrawLineFlag Then
            Dim g As Graphics = e.Graphics

            'Ermittelt das Graphics-Objekt, das zu einem bestimmten
            'Window geh�rt, dessen Handle (ID) zur Identifizierung dient.
            g = Graphics.FromHwnd(Me.Handle)

            'Schwarze, ein Pixel d�nne Linie zeichnen von (0,0) zu (500,500).
            'Koordinaten werden standardm��ig in Pixel angegeben;
            '(0,0) liegt in der linken, oberen Ecke des Client-Bereichs.
            Dim p As New SolidBrush(Color.Black)
            g.DrawLine(New Pen(Color.Black), 0, 0, 500, 500)
        End If
    End Sub
End Class
