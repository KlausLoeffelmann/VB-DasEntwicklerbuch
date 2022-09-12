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
        Me.btnLinieZeichnen = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnLinieZeichnen
        '
        Me.btnLinieZeichnen.Location = New System.Drawing.Point(58, 96)
        Me.btnLinieZeichnen.Name = "btnLinieZeichnen"
        Me.btnLinieZeichnen.Size = New System.Drawing.Size(170, 53)
        Me.btnLinieZeichnen.TabIndex = 0
        Me.btnLinieZeichnen.Text = "Linie zeichnen"
        Me.btnLinieZeichnen.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnLinieZeichnen)
        Me.Name = "frmMain"
        Me.Text = "Einfache GDI+-Demo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLinieZeichnen As System.Windows.Forms.Button

End Class
