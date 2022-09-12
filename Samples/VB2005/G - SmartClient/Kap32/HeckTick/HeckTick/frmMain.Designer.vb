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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.NeueZeiterfassungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StammdatenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BeraterToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ProjekteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AuswertungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ProjekteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.BeraterToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusBar = New System.Windows.Forms.StatusStrip
        Me.StatusStripStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem2, Me.StammdatenToolStripMenuItem, Me.AuswertungToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BeendenToolStripMenuItem.Text = "&Beenden"
        '
        'BearbeitenToolStripMenuItem2
        '
        Me.BearbeitenToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NeueZeiterfassungToolStripMenuItem})
        Me.BearbeitenToolStripMenuItem2.Name = "BearbeitenToolStripMenuItem2"
        Me.BearbeitenToolStripMenuItem2.Size = New System.Drawing.Size(71, 20)
        Me.BearbeitenToolStripMenuItem2.Text = "Bearbeiten"
        '
        'NeueZeiterfassungToolStripMenuItem
        '
        Me.NeueZeiterfassungToolStripMenuItem.Name = "NeueZeiterfassungToolStripMenuItem"
        Me.NeueZeiterfassungToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.NeueZeiterfassungToolStripMenuItem.Text = "Neue Zeiterfassung"
        '
        'StammdatenToolStripMenuItem
        '
        Me.StammdatenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeraterToolStripMenuItem1, Me.ProjekteToolStripMenuItem})
        Me.StammdatenToolStripMenuItem.Name = "StammdatenToolStripMenuItem"
        Me.StammdatenToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.StammdatenToolStripMenuItem.Text = "Stammdaten"
        '
        'BeraterToolStripMenuItem1
        '
        Me.BeraterToolStripMenuItem1.Name = "BeraterToolStripMenuItem1"
        Me.BeraterToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.BeraterToolStripMenuItem1.Text = "Berater"
        '
        'ProjekteToolStripMenuItem
        '
        Me.ProjekteToolStripMenuItem.Name = "ProjekteToolStripMenuItem"
        Me.ProjekteToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ProjekteToolStripMenuItem.Text = "Projekte"
        '
        'AuswertungToolStripMenuItem
        '
        Me.AuswertungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProjekteToolStripMenuItem1, Me.BeraterToolStripMenuItem2})
        Me.AuswertungToolStripMenuItem.Name = "AuswertungToolStripMenuItem"
        Me.AuswertungToolStripMenuItem.Size = New System.Drawing.Size(77, 20)
        Me.AuswertungToolStripMenuItem.Text = "Auswertung"
        '
        'ProjekteToolStripMenuItem1
        '
        Me.ProjekteToolStripMenuItem1.Name = "ProjekteToolStripMenuItem1"
        Me.ProjekteToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.ProjekteToolStripMenuItem1.Text = "Projekte"
        '
        'BeraterToolStripMenuItem2
        '
        Me.BeraterToolStripMenuItem2.Name = "BeraterToolStripMenuItem2"
        Me.BeraterToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.BeraterToolStripMenuItem2.Text = "Berater"
        '
        'StatusBar
        '
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripStatus})
        Me.StatusBar.Location = New System.Drawing.Point(0, 544)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(792, 22)
        Me.StatusBar.TabIndex = 1
        Me.StatusBar.Text = "StatusStrip1"
        '
        'StatusStripStatus
        '
        Me.StatusStripStatus.Name = "StatusStripStatus"
        Me.StatusStripStatus.Size = New System.Drawing.Size(35, 17)
        Me.StatusStripStatus.Text = "Bereit"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "HeckTick Zeiterfassung"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusStripStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BearbeitenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeueZeiterfassungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StammdatenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeraterToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjekteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AuswertungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProjekteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeraterToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem

End Class
