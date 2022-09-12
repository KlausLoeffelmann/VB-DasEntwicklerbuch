<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.chkDemo = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnSpeichern = New System.Windows.Forms.Button
        Me.btnWiederherstellen = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkDemo
        '
        Me.chkDemo.AutoSize = True
        Me.chkDemo.Location = New System.Drawing.Point(113, 55)
        Me.chkDemo.Name = "chkDemo"
        Me.chkDemo.Size = New System.Drawing.Size(105, 17)
        Me.chkDemo.TabIndex = 0
        Me.chkDemo.Text = "Checkbox-Demo"
        Me.chkDemo.ThreeState = True
        Me.chkDemo.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(213, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 32)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnSpeichern
        '
        Me.btnSpeichern.Location = New System.Drawing.Point(10, 95)
        Me.btnSpeichern.Name = "btnSpeichern"
        Me.btnSpeichern.Size = New System.Drawing.Size(140, 31)
        Me.btnSpeichern.TabIndex = 2
        Me.btnSpeichern.Text = "Zustand speichern"
        Me.btnSpeichern.UseVisualStyleBackColor = True
        '
        'btnWiederherstellen
        '
        Me.btnWiederherstellen.Location = New System.Drawing.Point(156, 95)
        Me.btnWiederherstellen.Name = "btnWiederherstellen"
        Me.btnWiederherstellen.Size = New System.Drawing.Size(141, 31)
        Me.btnWiederherstellen.TabIndex = 3
        Me.btnWiederherstellen.Text = "Zustand wiederherstellen"
        Me.btnWiederherstellen.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 135)
        Me.Controls.Add(Me.btnWiederherstellen)
        Me.Controls.Add(Me.btnSpeichern)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkDemo)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDemo As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnSpeichern As System.Windows.Forms.Button
    Friend WithEvents btnWiederherstellen As System.Windows.Forms.Button

End Class
