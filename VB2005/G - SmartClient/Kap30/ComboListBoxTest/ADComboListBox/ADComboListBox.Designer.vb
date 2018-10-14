<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADComboListBox
    Inherits System.Windows.Forms.UserControl

    'UserControl1 überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.myTextBox = New System.Windows.Forms.TextBox
        Me.myListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'myTextBox
        '
        Me.myTextBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.myTextBox.Location = New System.Drawing.Point(0, 0)
        Me.myTextBox.Name = "myTextBox"
        Me.myTextBox.Size = New System.Drawing.Size(185, 20)
        Me.myTextBox.TabIndex = 0
        '
        'myListBox
        '
        Me.myListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.myListBox.FormattingEnabled = True
        Me.myListBox.Location = New System.Drawing.Point(0, 20)
        Me.myListBox.Name = "myListBox"
        Me.myListBox.Size = New System.Drawing.Size(185, 95)
        Me.myListBox.TabIndex = 1
        '
        'ADComboListBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.myListBox)
        Me.Controls.Add(Me.myTextBox)
        Me.Name = "ADComboListBox"
        Me.Size = New System.Drawing.Size(185, 121)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents myTextBox As System.Windows.Forms.TextBox
    Friend WithEvents myListBox As System.Windows.Forms.ListBox

End Class
