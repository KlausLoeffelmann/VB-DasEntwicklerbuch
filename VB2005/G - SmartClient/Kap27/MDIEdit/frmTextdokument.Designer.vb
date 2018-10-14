<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextdokument
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
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmSpeichernUnter = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSuchen = New System.Windows.Forms.ToolStripMenuItem
        Me.txtEingabebereich = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(414, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.tsmSpeichernUnter})
        Me.DateiToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly
        Me.DateiToolStripMenuItem.MergeIndex = 0
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.ToolStripSeparator1.MergeIndex = 2
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'tsmSpeichernUnter
        '
        Me.tsmSpeichernUnter.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.tsmSpeichernUnter.MergeIndex = 3
        Me.tsmSpeichernUnter.Name = "tsmSpeichernUnter"
        Me.tsmSpeichernUnter.Size = New System.Drawing.Size(162, 22)
        Me.tsmSpeichernUnter.Text = "&Speichern unter..."
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSuchen})
        Me.BearbeitenToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert
        Me.BearbeitenToolStripMenuItem.MergeIndex = 1
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        '
        'tsmSuchen
        '
        Me.tsmSuchen.Name = "tsmSuchen"
        Me.tsmSuchen.Size = New System.Drawing.Size(152, 22)
        Me.tsmSuchen.Text = "Suchen..."
        '
        'txtEingabebereich
        '
        Me.txtEingabebereich.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEingabebereich.Location = New System.Drawing.Point(0, 24)
        Me.txtEingabebereich.Multiline = True
        Me.txtEingabebereich.Name = "txtEingabebereich"
        Me.txtEingabebereich.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtEingabebereich.Size = New System.Drawing.Size(414, 291)
        Me.txtEingabebereich.TabIndex = 1
        '
        'frmTextdokument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 315)
        Me.Controls.Add(Me.txtEingabebereich)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmTextdokument"
        Me.Text = "frmTextdokument"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSuchen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSpeichernUnter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtEingabebereich As System.Windows.Forms.TextBox
End Class
