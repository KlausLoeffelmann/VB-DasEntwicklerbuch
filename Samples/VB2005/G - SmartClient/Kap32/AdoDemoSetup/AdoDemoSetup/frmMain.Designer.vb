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
        Me.tsmDBLöschenUndErstellen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDemodatenErstellen = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmProgrammBeenden = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmBeraterAnzeigen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmProjekteAnzeigen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmZeitenAnzeigen = New System.Windows.Forms.ToolStripMenuItem
        Me.VerbindungentestenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSQLInstanzTesten = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmSqlDatenbankTesten = New System.Windows.Forms.ToolStripMenuItem
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.ToolStripMenuItem2, Me.VerbindungentestenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(619, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmDBLöschenUndErstellen, Me.tsmDemodatenErstellen, Me.ToolStripMenuItem1, Me.tsmProgrammBeenden})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmDBLöschenUndErstellen
        '
        Me.tsmDBLöschenUndErstellen.Name = "tsmDBLöschenUndErstellen"
        Me.tsmDBLöschenUndErstellen.Size = New System.Drawing.Size(301, 22)
        Me.tsmDBLöschenUndErstellen.Text = "Demodatenbank löschen und neu erstellen"
        '
        'tsmDemodatenErstellen
        '
        Me.tsmDemodatenErstellen.Name = "tsmDemodatenErstellen"
        Me.tsmDemodatenErstellen.Size = New System.Drawing.Size(301, 22)
        Me.tsmDemodatenErstellen.Text = "Vorhandene Daten löschen und neu erstellen..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(298, 6)
        '
        'tsmProgrammBeenden
        '
        Me.tsmProgrammBeenden.Name = "tsmProgrammBeenden"
        Me.tsmProgrammBeenden.Size = New System.Drawing.Size(301, 22)
        Me.tsmProgrammBeenden.Text = "Programm be&enden"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBeraterAnzeigen, Me.tsmProjekteAnzeigen, Me.tsmZeitenAnzeigen})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripMenuItem2.Text = "&Ansicht"
        '
        'tsmBeraterAnzeigen
        '
        Me.tsmBeraterAnzeigen.Checked = True
        Me.tsmBeraterAnzeigen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.tsmBeraterAnzeigen.Name = "tsmBeraterAnzeigen"
        Me.tsmBeraterAnzeigen.Size = New System.Drawing.Size(179, 22)
        Me.tsmBeraterAnzeigen.Text = "Berater-Datentabelle"
        '
        'tsmProjekteAnzeigen
        '
        Me.tsmProjekteAnzeigen.Name = "tsmProjekteAnzeigen"
        Me.tsmProjekteAnzeigen.Size = New System.Drawing.Size(179, 22)
        Me.tsmProjekteAnzeigen.Text = "Projekte-Datentabelle"
        '
        'tsmZeitenAnzeigen
        '
        Me.tsmZeitenAnzeigen.Name = "tsmZeitenAnzeigen"
        Me.tsmZeitenAnzeigen.Size = New System.Drawing.Size(179, 22)
        Me.tsmZeitenAnzeigen.Text = "Zeiten-Datentabelle"
        '
        'VerbindungentestenToolStripMenuItem
        '
        Me.VerbindungentestenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmSQLInstanzTesten, Me.tsmSqlDatenbankTesten})
        Me.VerbindungentestenToolStripMenuItem.Name = "VerbindungentestenToolStripMenuItem"
        Me.VerbindungentestenToolStripMenuItem.Size = New System.Drawing.Size(119, 20)
        Me.VerbindungentestenToolStripMenuItem.Text = "Verbindungen &testen"
        '
        'tsmSQLInstanzTesten
        '
        Me.tsmSQLInstanzTesten.Name = "tsmSQLInstanzTesten"
        Me.tsmSQLInstanzTesten.Size = New System.Drawing.Size(237, 22)
        Me.tsmSQLInstanzTesten.Text = "zu einer SQL Server-Instanz..."
        '
        'tsmSqlDatenbankTesten
        '
        Me.tsmSqlDatenbankTesten.Name = "tsmSqlDatenbankTesten"
        Me.tsmSqlDatenbankTesten.Size = New System.Drawing.Size(237, 22)
        Me.tsmSqlDatenbankTesten.Text = "zu einer SQL Server-Datenbank..."
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 24)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(619, 417)
        Me.dgvData.TabIndex = 1
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 441)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "AdoDemoSetup für VB2005 - Das Entwicklerbuch"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDBLöschenUndErstellen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDemodatenErstellen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmProgrammBeenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerbindungentestenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSQLInstanzTesten As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSqlDatenbankTesten As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmBeraterAnzeigen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmProjekteAnzeigen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmZeitenAnzeigen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView

End Class
