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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.FocusedColoredTextBox4 = New FocusColoredTextBoxDemo.FocusedColoredTextBox
        Me.FocusedColoredTextBox3 = New FocusColoredTextBoxDemo.FocusedColoredTextBox
        Me.FocusedColoredTextBox2 = New FocusColoredTextBoxDemo.FocusedColoredTextBox
        Me.FocusedColoredTextBox1 = New FocusColoredTextBoxDemo.FocusedColoredTextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Matchcode:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nachname:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Vorname:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Ort:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(357, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(98, 33)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FocusedColoredTextBox4
        '
        Me.FocusedColoredTextBox4.Location = New System.Drawing.Point(135, 90)
        Me.FocusedColoredTextBox4.Name = "FocusedColoredTextBox4"
        Me.FocusedColoredTextBox4.Size = New System.Drawing.Size(162, 20)
        Me.FocusedColoredTextBox4.TabIndex = 6
        '
        'FocusedColoredTextBox3
        '
        Me.FocusedColoredTextBox3.Location = New System.Drawing.Point(135, 64)
        Me.FocusedColoredTextBox3.Name = "FocusedColoredTextBox3"
        Me.FocusedColoredTextBox3.Size = New System.Drawing.Size(162, 20)
        Me.FocusedColoredTextBox3.TabIndex = 4
        '
        'FocusedColoredTextBox2
        '
        Me.FocusedColoredTextBox2.Location = New System.Drawing.Point(135, 38)
        Me.FocusedColoredTextBox2.Name = "FocusedColoredTextBox2"
        Me.FocusedColoredTextBox2.Size = New System.Drawing.Size(162, 20)
        Me.FocusedColoredTextBox2.TabIndex = 2
        '
        'FocusedColoredTextBox1
        '
        Me.FocusedColoredTextBox1.Location = New System.Drawing.Point(135, 12)
        Me.FocusedColoredTextBox1.Name = "FocusedColoredTextBox1"
        Me.FocusedColoredTextBox1.Size = New System.Drawing.Size(162, 20)
        Me.FocusedColoredTextBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 144)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.FocusedColoredTextBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.FocusedColoredTextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FocusedColoredTextBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FocusedColoredTextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FocusedColoredTextBox1 As FocusColoredTextBoxDemo.FocusedColoredTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FocusedColoredTextBox2 As FocusColoredTextBoxDemo.FocusedColoredTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FocusedColoredTextBox3 As FocusColoredTextBoxDemo.FocusedColoredTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FocusedColoredTextBox4 As FocusColoredTextBoxDemo.FocusedColoredTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button

End Class
