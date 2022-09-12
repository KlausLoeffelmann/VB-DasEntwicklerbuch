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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNeuesDokument = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmÖffnen = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmProgrammBeenden = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmExtras = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmOptionen = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.tsmExtras})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(593, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNeuesDokument, Me.tsmÖffnen, Me.ToolStripMenuItem1, Me.tsmProgrammBeenden})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmNeuesDokument
        '
        Me.tsmNeuesDokument.Name = "tsmNeuesDokument"
        Me.tsmNeuesDokument.Size = New System.Drawing.Size(176, 22)
        Me.tsmNeuesDokument.Text = "&Neues Textdokument"
        '
        'tsmÖffnen
        '
        Me.tsmÖffnen.Name = "tsmÖffnen"
        Me.tsmÖffnen.Size = New System.Drawing.Size(176, 22)
        Me.tsmÖffnen.Text = "Ö&ffnen..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(173, 6)
        '
        'tsmProgrammBeenden
        '
        Me.tsmProgrammBeenden.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.tsmProgrammBeenden.Name = "tsmProgrammBeenden"
        Me.tsmProgrammBeenden.Size = New System.Drawing.Size(176, 22)
        Me.tsmProgrammBeenden.Text = "Programm be&enden"
        '
        'tsmExtras
        '
        Me.tsmExtras.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmOptionen})
        Me.tsmExtras.Name = "tsmExtras"
        Me.tsmExtras.Size = New System.Drawing.Size(50, 20)
        Me.tsmExtras.Text = "&Extras"
        '
        'tsmOptionen
        '
        Me.tsmOptionen.Name = "tsmOptionen"
        Me.tsmOptionen.Size = New System.Drawing.Size(152, 22)
        Me.tsmOptionen.Text = "&Optionen..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 430)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "MDIEdit"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmÖffnen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmProgrammBeenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNeuesDokument As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmExtras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmOptionen As System.Windows.Forms.ToolStripMenuItem

End Class
