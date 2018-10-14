Imports System.Drawing

Public Class frmProgress
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
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblDatabaseupdate As System.Windows.Forms.Label
    Friend WithEvents pgbTables As System.Windows.Forms.ProgressBar
    Friend WithEvents lblUpdateMessage As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblMessage = New System.Windows.Forms.Label
        Me.lblDatabaseupdate = New System.Windows.Forms.Label
        Me.pgbTables = New System.Windows.Forms.ProgressBar
        Me.lblUpdateMessage = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(16, 48)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(320, 56)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Die Datenbanktabellen werden auf Aktualität geprüft und gegebenenfalls angepasst." & _
        " Bitte warten Sie einen Moment, bis der Vorgang beendet ist."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDatabaseupdate
        '
        Me.lblDatabaseupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatabaseupdate.Location = New System.Drawing.Point(16, 8)
        Me.lblDatabaseupdate.Name = "lblDatabaseupdate"
        Me.lblDatabaseupdate.Size = New System.Drawing.Size(320, 32)
        Me.lblDatabaseupdate.TabIndex = 1
        Me.lblDatabaseupdate.Text = "Datentabellen updaten..."
        Me.lblDatabaseupdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pgbTables
        '
        Me.pgbTables.Location = New System.Drawing.Point(16, 128)
        Me.pgbTables.Name = "pgbTables"
        Me.pgbTables.Size = New System.Drawing.Size(312, 16)
        Me.pgbTables.TabIndex = 2
        '
        'lblUpdateMessage
        '
        Me.lblUpdateMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUpdateMessage.Location = New System.Drawing.Point(16, 144)
        Me.lblUpdateMessage.Name = "lblUpdateMessage"
        Me.lblUpdateMessage.Size = New System.Drawing.Size(312, 40)
        Me.lblUpdateMessage.TabIndex = 3
        Me.lblUpdateMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmProgress
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 214)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblUpdateMessage)
        Me.Controls.Add(Me.pgbTables)
        Me.Controls.Add(Me.lblDatabaseupdate)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmProgress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUpdateMessage.Click

    End Sub
End Class
