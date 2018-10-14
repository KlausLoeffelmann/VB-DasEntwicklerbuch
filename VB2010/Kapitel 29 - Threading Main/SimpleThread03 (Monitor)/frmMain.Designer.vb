<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnThreadStarten = New System.Windows.Forms.Button()
        Me.btnBeenden = New System.Windows.Forms.Button()
        Me.ThreadSafeTextWindow = New SimpleThread.ThreadSafeTextWindowComponent()
        Me.SuspendLayout()
        '
        'btnThreadStarten
        '
        Me.btnThreadStarten.Location = New System.Drawing.Point(12, 12)
        Me.btnThreadStarten.Name = "btnThreadStarten"
        Me.btnThreadStarten.Size = New System.Drawing.Size(248, 32)
        Me.btnThreadStarten.TabIndex = 5
        Me.btnThreadStarten.Text = "Thread starten"
        '
        'btnBeenden
        '
        Me.btnBeenden.Location = New System.Drawing.Point(284, 12)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 4
        Me.btnBeenden.Text = "Beenden"
        '
        'ThreadSafeTextWindow
        '
        Me.ThreadSafeTextWindow.HostingForm = Me
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 62)
        Me.Controls.Add(Me.btnThreadStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Simple Thread"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnThreadStarten As System.Windows.Forms.Button
    Friend WithEvents btnBeenden As System.Windows.Forms.Button
    Friend WithEvents ThreadSafeTextWindow As SimpleThread.ThreadSafeTextWindowComponent

End Class
