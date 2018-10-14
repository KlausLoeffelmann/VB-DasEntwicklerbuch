Public Class Form1
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
    Friend WithEvents TestControl1 As TestControl.TestControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TestControl1 = New TestControl.TestControl
        Me.SuspendLayout()
        '
        'TestControl1
        '
        Me.TestControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TestControl1.AutoScroll = True
        Me.TestControl1.AutoScrollMinSize = New System.Drawing.Size(300, 300)
        Me.TestControl1.Location = New System.Drawing.Point(16, 16)
        Me.TestControl1.Name = "TestControl1"
        Me.TestControl1.Size = New System.Drawing.Size(208, 192)
        Me.TestControl1.TabIndex = 0
        Me.TestControl1.Text = "TestControl1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(256, 246)
        Me.Controls.Add(Me.TestControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
