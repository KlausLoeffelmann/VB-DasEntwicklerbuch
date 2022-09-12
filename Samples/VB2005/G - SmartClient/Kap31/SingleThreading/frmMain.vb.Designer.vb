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
        Me.lblAusgabe = New System.Windows.Forms.Label
        Me.btnZählenStarten = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblAusgabe
        '
        Me.lblAusgabe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAusgabe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAusgabe.Location = New System.Drawing.Point(12, 76)
        Me.lblAusgabe.Name = "lblAusgabe"
        Me.lblAusgabe.Size = New System.Drawing.Size(384, 48)
        Me.lblAusgabe.TabIndex = 3
        Me.lblAusgabe.Text = "- - -"
        Me.lblAusgabe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZählenStarten
        '
        Me.btnZählenStarten.Location = New System.Drawing.Point(12, 12)
        Me.btnZählenStarten.Name = "btnZählenStarten"
        Me.btnZählenStarten.Size = New System.Drawing.Size(384, 40)
        Me.btnZählenStarten.TabIndex = 2
        Me.btnZählenStarten.Text = "Zählen starten..."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 141)
        Me.Controls.Add(Me.lblAusgabe)
        Me.Controls.Add(Me.btnZählenStarten)
        Me.Name = "Form1"
        Me.Text = "Single Thread"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblAusgabe As System.Windows.Forms.Label
    Friend WithEvents btnZählenStarten As System.Windows.Forms.Button

End Class
