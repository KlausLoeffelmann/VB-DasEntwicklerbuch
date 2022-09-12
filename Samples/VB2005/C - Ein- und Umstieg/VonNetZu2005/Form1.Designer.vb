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
        Me.btnContinue = New System.Windows.Forms.Button
        Me.btnUsing = New System.Windows.Forms.Button
        Me.btnFormularOhneInstanz = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(12, 12)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(113, 39)
        Me.btnContinue.TabIndex = 0
        Me.btnContinue.Text = "Continue-Demo"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnUsing
        '
        Me.btnUsing.Location = New System.Drawing.Point(12, 57)
        Me.btnUsing.Name = "btnUsing"
        Me.btnUsing.Size = New System.Drawing.Size(113, 39)
        Me.btnUsing.TabIndex = 1
        Me.btnUsing.Text = "Using-Demo"
        Me.btnUsing.UseVisualStyleBackColor = True
        '
        'btnFormularOhneInstanz
        '
        Me.btnFormularOhneInstanz.Location = New System.Drawing.Point(12, 102)
        Me.btnFormularOhneInstanz.Name = "btnFormularOhneInstanz"
        Me.btnFormularOhneInstanz.Size = New System.Drawing.Size(113, 39)
        Me.btnFormularOhneInstanz.TabIndex = 2
        Me.btnFormularOhneInstanz.Text = "Formular ohne Instanz"
        Me.btnFormularOhneInstanz.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 39)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 157)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnFormularOhneInstanz)
        Me.Controls.Add(Me.btnUsing)
        Me.Controls.Add(Me.btnContinue)
        Me.Name = "Form1"
        Me.Text = "Von VB.NET zu VB2005"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents btnUsing As System.Windows.Forms.Button
    Friend WithEvents btnFormularOhneInstanz As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
