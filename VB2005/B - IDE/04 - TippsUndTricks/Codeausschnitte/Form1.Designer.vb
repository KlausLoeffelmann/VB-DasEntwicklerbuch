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
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtDateiname1 = New System.Windows.Forms.TextBox
        Me.btnDatei1Auswählen = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnDatei2Auswählen = New System.Windows.Forms.Button
        Me.txtDateiname2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(352, 18)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(102, 34)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtDateiname1
        '
        Me.txtDateiname1.Location = New System.Drawing.Point(12, 26)
        Me.txtDateiname1.Name = "txtDateiname1"
        Me.txtDateiname1.Size = New System.Drawing.Size(281, 20)
        Me.txtDateiname1.TabIndex = 1
        '
        'btnDatei1Auswählen
        '
        Me.btnDatei1Auswählen.Location = New System.Drawing.Point(299, 26)
        Me.btnDatei1Auswählen.Name = "btnDatei1Auswählen"
        Me.btnDatei1Auswählen.Size = New System.Drawing.Size(25, 20)
        Me.btnDatei1Auswählen.TabIndex = 2
        Me.btnDatei1Auswählen.Text = "..."
        Me.btnDatei1Auswählen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Dateiname 1:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Dateiname 2:"
        '
        'btnDatei2Auswählen
        '
        Me.btnDatei2Auswählen.Location = New System.Drawing.Point(299, 72)
        Me.btnDatei2Auswählen.Name = "btnDatei2Auswählen"
        Me.btnDatei2Auswählen.Size = New System.Drawing.Size(25, 20)
        Me.btnDatei2Auswählen.TabIndex = 5
        Me.btnDatei2Auswählen.Text = "..."
        Me.btnDatei2Auswählen.UseVisualStyleBackColor = True
        '
        'txtDateiname2
        '
        Me.txtDateiname2.Location = New System.Drawing.Point(12, 72)
        Me.txtDateiname2.Name = "txtDateiname2"
        Me.txtDateiname2.Size = New System.Drawing.Size(281, 20)
        Me.txtDateiname2.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 115)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDatei2Auswählen)
        Me.Controls.Add(Me.txtDateiname2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDatei1Auswählen)
        Me.Controls.Add(Me.txtDateiname1)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "Form1"
        Me.Text = "Codeausschnitte"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtDateiname1 As System.Windows.Forms.TextBox
    Friend WithEvents btnDatei1Auswählen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDatei2Auswählen As System.Windows.Forms.Button
    Friend WithEvents txtDateiname2 As System.Windows.Forms.TextBox

End Class
