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
        Me.ThreadWithThreadButton = New System.Windows.Forms.Button()
        Me.btnBeenden = New System.Windows.Forms.Button()
        Me.ASyncInvokeButton = New System.Windows.Forms.Button()
        Me.ThreadWithTasksButton = New System.Windows.Forms.Button()
        Me.ThreadFromThreadpoolDirectly = New System.Windows.Forms.Button()
        Me.TextOutput = New SimpleThread.ThreadSafeTextWindowComponent()
        Me.SuspendLayout()
        '
        'ThreadWithThreadButton
        '
        Me.ThreadWithThreadButton.Location = New System.Drawing.Point(12, 88)
        Me.ThreadWithThreadButton.Name = "ThreadWithThreadButton"
        Me.ThreadWithThreadButton.Size = New System.Drawing.Size(248, 32)
        Me.ThreadWithThreadButton.TabIndex = 5
        Me.ThreadWithThreadButton.Text = "Thread mit Thread-Instanz starten"
        '
        'btnBeenden
        '
        Me.btnBeenden.Location = New System.Drawing.Point(284, 12)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 4
        Me.btnBeenden.Text = "Beenden"
        '
        'ASyncInvokeButton
        '
        Me.ASyncInvokeButton.Location = New System.Drawing.Point(12, 12)
        Me.ASyncInvokeButton.Name = "ASyncInvokeButton"
        Me.ASyncInvokeButton.Size = New System.Drawing.Size(248, 32)
        Me.ASyncInvokeButton.TabIndex = 6
        Me.ASyncInvokeButton.Text = "ASync Invoke"
        '
        'ThreadWithTasksButton
        '
        Me.ThreadWithTasksButton.Location = New System.Drawing.Point(12, 50)
        Me.ThreadWithTasksButton.Name = "ThreadWithTasksButton"
        Me.ThreadWithTasksButton.Size = New System.Drawing.Size(248, 32)
        Me.ThreadWithTasksButton.TabIndex = 7
        Me.ThreadWithTasksButton.Text = "Thread mit Task-Instanz (>= FW 4.0)"
        '
        'ThreadFromThreadpoolDirectly
        '
        Me.ThreadFromThreadpoolDirectly.Location = New System.Drawing.Point(12, 126)
        Me.ThreadFromThreadpoolDirectly.Name = "ThreadFromThreadpoolDirectly"
        Me.ThreadFromThreadpoolDirectly.Size = New System.Drawing.Size(248, 32)
        Me.ThreadFromThreadpoolDirectly.TabIndex = 8
        Me.ThreadFromThreadpoolDirectly.Text = "Thread aus Threadpool direkt ( < FW 4.0)"
        '
        'TextOutput
        '
        Me.TextOutput.HostingForm = Me
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 173)
        Me.Controls.Add(Me.ThreadFromThreadpoolDirectly)
        Me.Controls.Add(Me.ThreadWithTasksButton)
        Me.Controls.Add(Me.ASyncInvokeButton)
        Me.Controls.Add(Me.ThreadWithThreadButton)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Simple Threads"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ThreadWithThreadButton As System.Windows.Forms.Button
    Friend WithEvents btnBeenden As System.Windows.Forms.Button
    Friend WithEvents TextOutput As SimpleThread.ThreadSafeTextWindowComponent
    Friend WithEvents ThreadFromThreadpoolDirectly As System.Windows.Forms.Button
    Friend WithEvents ThreadWithTasksButton As System.Windows.Forms.Button
    Friend WithEvents ASyncInvokeButton As System.Windows.Forms.Button

End Class
