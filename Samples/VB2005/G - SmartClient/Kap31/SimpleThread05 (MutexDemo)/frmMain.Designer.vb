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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtHardware3 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtHardware2 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtHardware1 = New System.Windows.Forms.TextBox
        Me.btnThreadStarten = New System.Windows.Forms.Button
        Me.btnBeenden = New System.Windows.Forms.Button
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtHardware3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 388)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hardware-Ressource #3"
        '
        'txtHardware3
        '
        Me.txtHardware3.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware3.Multiline = True
        Me.txtHardware3.Name = "txtHardware3"
        Me.txtHardware3.ReadOnly = True
        Me.txtHardware3.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware3.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtHardware2)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 220)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Hardware-Ressource #2"
        '
        'txtHardware2
        '
        Me.txtHardware2.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware2.Multiline = True
        Me.txtHardware2.Name = "txtHardware2"
        Me.txtHardware2.ReadOnly = True
        Me.txtHardware2.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware2.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHardware1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(376, 160)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Hardware-Ressource #1"
        '
        'txtHardware1
        '
        Me.txtHardware1.Location = New System.Drawing.Point(8, 24)
        Me.txtHardware1.Multiline = True
        Me.txtHardware1.Name = "txtHardware1"
        Me.txtHardware1.ReadOnly = True
        Me.txtHardware1.Size = New System.Drawing.Size(360, 120)
        Me.txtHardware1.TabIndex = 0
        '
        'btnThreadStarten
        '
        Me.btnThreadStarten.Location = New System.Drawing.Point(12, 12)
        Me.btnThreadStarten.Name = "btnThreadStarten"
        Me.btnThreadStarten.Size = New System.Drawing.Size(256, 32)
        Me.btnThreadStarten.TabIndex = 8
        Me.btnThreadStarten.Text = "Threads starten"
        '
        'btnBeenden
        '
        Me.btnBeenden.Location = New System.Drawing.Point(284, 12)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 7
        Me.btnBeenden.Text = "Beenden"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 556)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnThreadStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "frmMain"
        Me.Text = "Simple Thread"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHardware1 As System.Windows.Forms.TextBox
    Friend WithEvents btnThreadStarten As System.Windows.Forms.Button
    Friend WithEvents btnBeenden As System.Windows.Forms.Button

End Class
