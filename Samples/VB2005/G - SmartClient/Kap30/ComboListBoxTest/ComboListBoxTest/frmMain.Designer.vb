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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnMitDatenFüllen = New System.Windows.Forms.Button
        Me.AdComboListBox1 = New ActiveDevelop.Controls.ADComboListBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ComboListBox:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(332, 33)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnMitDatenFüllen
        '
        Me.btnMitDatenFüllen.Location = New System.Drawing.Point(332, 71)
        Me.btnMitDatenFüllen.Name = "btnMitDatenFüllen"
        Me.btnMitDatenFüllen.Size = New System.Drawing.Size(112, 38)
        Me.btnMitDatenFüllen.TabIndex = 3
        Me.btnMitDatenFüllen.Text = "ComboListBox mit Daten füllen"
        Me.btnMitDatenFüllen.UseVisualStyleBackColor = True
        '
        'AdComboListBox1
        '
        Me.AdComboListBox1.Location = New System.Drawing.Point(12, 33)
        Me.AdComboListBox1.Name = "AdComboListBox1"
        Me.AdComboListBox1.Size = New System.Drawing.Size(314, 202)
        Me.AdComboListBox1.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 249)
        Me.Controls.Add(Me.btnMitDatenFüllen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AdComboListBox1)
        Me.Name = "frmMain"
        Me.Text = "ComboListBox-Testformular"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AdComboListBox1 As ActiveDevelop.Controls.ADComboListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnMitDatenFüllen As System.Windows.Forms.Button

End Class
