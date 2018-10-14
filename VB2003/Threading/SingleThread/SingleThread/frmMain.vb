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
    Friend WithEvents btnZ�hlenStarten As System.Windows.Forms.Button
    Friend WithEvents lblAusgabe As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnZ�hlenStarten = New System.Windows.Forms.Button
        Me.lblAusgabe = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnZ�hlenStarten
        '
        Me.btnZ�hlenStarten.Location = New System.Drawing.Point(16, 24)
        Me.btnZ�hlenStarten.Name = "btnZ�hlenStarten"
        Me.btnZ�hlenStarten.Size = New System.Drawing.Size(384, 40)
        Me.btnZ�hlenStarten.TabIndex = 0
        Me.btnZ�hlenStarten.Text = "Z�hlen starten..."
        '
        'lblAusgabe
        '
        Me.lblAusgabe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAusgabe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAusgabe.Location = New System.Drawing.Point(16, 88)
        Me.lblAusgabe.Name = "lblAusgabe"
        Me.lblAusgabe.Size = New System.Drawing.Size(384, 48)
        Me.lblAusgabe.TabIndex = 1
        Me.lblAusgabe.Text = "- - -"
        Me.lblAusgabe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(416, 158)
        Me.Controls.Add(Me.lblAusgabe)
        Me.Controls.Add(Me.btnZ�hlenStarten)
        Me.Name = "frmMain"
        Me.Text = "Single Thread"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnZ�hlenStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZ�hlenStarten.Click
        For z As Integer = 0 To 100000
            lblAusgabe.Text = z.ToString
            lblAusgabe.Refresh()
            Application.DoEvents()
        Next
    End Sub
End Class
