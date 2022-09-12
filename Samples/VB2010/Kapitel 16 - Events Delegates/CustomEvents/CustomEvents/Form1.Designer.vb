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
        Me.DebugButton1 = New CustomEvents.DebugButton()
        Me.DebugButton2 = New CustomEvents.DebugButton()
        Me.DebugButton3 = New CustomEvents.DebugButton()
        Me.ResultDebugButton = New CustomEvents.DebugButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DebugButton1
        '
        Me.DebugButton1.Location = New System.Drawing.Point(119, 54)
        Me.DebugButton1.Name = "DebugButton1"
        Me.DebugButton1.Size = New System.Drawing.Size(138, 33)
        Me.DebugButton1.TabIndex = 0
        Me.DebugButton1.Text = "DebugButton1"
        Me.DebugButton1.UseVisualStyleBackColor = True
        '
        'DebugButton2
        '
        Me.DebugButton2.Location = New System.Drawing.Point(119, 93)
        Me.DebugButton2.Name = "DebugButton2"
        Me.DebugButton2.Size = New System.Drawing.Size(138, 33)
        Me.DebugButton2.TabIndex = 1
        Me.DebugButton2.Text = "DebugButton2"
        Me.DebugButton2.UseVisualStyleBackColor = True
        '
        'DebugButton3
        '
        Me.DebugButton3.Location = New System.Drawing.Point(119, 132)
        Me.DebugButton3.Name = "DebugButton3"
        Me.DebugButton3.Size = New System.Drawing.Size(138, 33)
        Me.DebugButton3.TabIndex = 2
        Me.DebugButton3.Text = "DebugButton3"
        Me.DebugButton3.UseVisualStyleBackColor = True
        '
        'ResultDebugButton
        '
        Me.ResultDebugButton.Location = New System.Drawing.Point(119, 198)
        Me.ResultDebugButton.Name = "ResultDebugButton"
        Me.ResultDebugButton.Size = New System.Drawing.Size(138, 33)
        Me.ResultDebugButton.TabIndex = 3
        Me.ResultDebugButton.Text = "Ergebnis"
        Me.ResultDebugButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(352, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Klicken Sie beliebig auf die Schaltflächen, um Arbeitslast zu simulieren."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 256)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ResultDebugButton)
        Me.Controls.Add(Me.DebugButton3)
        Me.Controls.Add(Me.DebugButton2)
        Me.Controls.Add(Me.DebugButton1)
        Me.Name = "Form1"
        Me.Text = "Custom Events - Benutzerdefinierte Ereignisse"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DebugButton1 As CustomEvents.DebugButton
    Friend WithEvents DebugButton2 As CustomEvents.DebugButton
    Friend WithEvents DebugButton3 As CustomEvents.DebugButton
    Friend WithEvents ResultDebugButton As CustomEvents.DebugButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
