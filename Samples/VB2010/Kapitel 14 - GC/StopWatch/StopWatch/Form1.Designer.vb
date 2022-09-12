<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.elapsedMillisecondsLabel = New System.Windows.Forms.Label()
        Me.btnStartStopButton = New System.Windows.Forms.Button()
        Me.TimerTestButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'elapsedMillisecondsLabel
        '
        Me.elapsedMillisecondsLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.elapsedMillisecondsLabel.AutoSize = True
        Me.elapsedMillisecondsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.elapsedMillisecondsLabel.Location = New System.Drawing.Point(68, 70)
        Me.elapsedMillisecondsLabel.Name = "elapsedMillisecondsLabel"
        Me.elapsedMillisecondsLabel.Size = New System.Drawing.Size(105, 24)
        Me.elapsedMillisecondsLabel.TabIndex = 3
        Me.elapsedMillisecondsLabel.Text = "0:00:00:00"
        '
        'btnStartStopButton
        '
        Me.btnStartStopButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnStartStopButton.Location = New System.Drawing.Point(49, 107)
        Me.btnStartStopButton.Name = "btnStartStopButton"
        Me.btnStartStopButton.Size = New System.Drawing.Size(143, 33)
        Me.btnStartStopButton.TabIndex = 2
        Me.btnStartStopButton.Text = "Start"
        Me.btnStartStopButton.UseVisualStyleBackColor = True
        '
        'TimerTestButton
        '
        Me.TimerTestButton.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TimerTestButton.Location = New System.Drawing.Point(49, 146)
        Me.TimerTestButton.Name = "TimerTestButton"
        Me.TimerTestButton.Size = New System.Drawing.Size(143, 33)
        Me.TimerTestButton.TabIndex = 4
        Me.TimerTestButton.Text = "TimerTest"
        Me.TimerTestButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(233, 184)
        Me.Controls.Add(Me.TimerTestButton)
        Me.Controls.Add(Me.elapsedMillisecondsLabel)
        Me.Controls.Add(Me.btnStartStopButton)
        Me.Name = "Form1"
        Me.Text = "StopWatch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents elapsedMillisecondsLabel As System.Windows.Forms.Label
    Friend WithEvents btnStartStopButton As System.Windows.Forms.Button
    Friend WithEvents TimerTestButton As System.Windows.Forms.Button

End Class
