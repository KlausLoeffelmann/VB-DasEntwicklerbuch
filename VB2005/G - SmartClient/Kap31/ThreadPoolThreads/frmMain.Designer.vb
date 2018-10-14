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
        Me.chkMultithreading = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtAusgabe = New System.Windows.Forms.TextBox
        Me.btnBenchmarkStarten = New System.Windows.Forms.Button
        Me.btnBeenden = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkMultithreading
        '
        Me.chkMultithreading.Location = New System.Drawing.Point(20, 52)
        Me.chkMultithreading.Name = "chkMultithreading"
        Me.chkMultithreading.Size = New System.Drawing.Size(248, 24)
        Me.chkMultithreading.TabIndex = 9
        Me.chkMultithreading.Text = "Multithreading verwenden"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtAusgabe)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 314)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status:"
        '
        'txtAusgabe
        '
        Me.txtAusgabe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAusgabe.Location = New System.Drawing.Point(8, 24)
        Me.txtAusgabe.Multiline = True
        Me.txtAusgabe.Name = "txtAusgabe"
        Me.txtAusgabe.ReadOnly = True
        Me.txtAusgabe.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAusgabe.Size = New System.Drawing.Size(376, 282)
        Me.txtAusgabe.TabIndex = 0
        Me.txtAusgabe.WordWrap = False
        '
        'btnBenchmarkStarten
        '
        Me.btnBenchmarkStarten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBenchmarkStarten.Location = New System.Drawing.Point(12, 12)
        Me.btnBenchmarkStarten.Name = "btnBenchmarkStarten"
        Me.btnBenchmarkStarten.Size = New System.Drawing.Size(272, 32)
        Me.btnBenchmarkStarten.TabIndex = 7
        Me.btnBenchmarkStarten.Text = "Benchmark starten"
        '
        'btnBeenden
        '
        Me.btnBeenden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBeenden.Location = New System.Drawing.Point(300, 12)
        Me.btnBeenden.Name = "btnBeenden"
        Me.btnBeenden.Size = New System.Drawing.Size(104, 32)
        Me.btnBeenden.TabIndex = 6
        Me.btnBeenden.Text = "Beenden"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 410)
        Me.Controls.Add(Me.chkMultithreading)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBenchmarkStarten)
        Me.Controls.Add(Me.btnBeenden)
        Me.Name = "Form1"
        Me.Text = "Sortieren mit Thread-Pool-Threads"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkMultithreading As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAusgabe As System.Windows.Forms.TextBox
    Friend WithEvents btnBenchmarkStarten As System.Windows.Forms.Button
    Friend WithEvents btnBeenden As System.Windows.Forms.Button

End Class
