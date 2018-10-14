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
        Me.lvwAdressen = New System.Windows.Forms.ListView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAdresslisteLaden = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAdresslisteSpeichern = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmZufallsadressenAnfügen = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmProgrammBeenden = New System.Windows.Forms.ToolStripMenuItem
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmNeueAdresseErfassen = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAdresseBearbeiten = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmAdressenLöschen = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmAdresseSuchen = New System.Windows.Forms.ToolStripMenuItem
        Me.ssStatuszeile = New System.Windows.Forms.StatusStrip
        Me.tsslAusgewählteAdresse = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsmSchnellerfassung = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.ssStatuszeile.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvwAdressen
        '
        Me.lvwAdressen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwAdressen.FullRowSelect = True
        Me.lvwAdressen.HideSelection = False
        Me.lvwAdressen.Location = New System.Drawing.Point(0, 24)
        Me.lvwAdressen.Name = "lvwAdressen"
        Me.lvwAdressen.Size = New System.Drawing.Size(616, 402)
        Me.lvwAdressen.TabIndex = 0
        Me.lvwAdressen.UseCompatibleStateImageBehavior = False
        Me.lvwAdressen.View = System.Windows.Forms.View.Details
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem, Me.BearbeitenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(616, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAdresslisteLaden, Me.tsmAdresslisteSpeichern, Me.ToolStripMenuItem1, Me.tsmZufallsadressenAnfügen, Me.ToolStripSeparator1, Me.tsmProgrammBeenden})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.DateiToolStripMenuItem.Text = "&Datei"
        '
        'tsmAdresslisteLaden
        '
        Me.tsmAdresslisteLaden.Name = "tsmAdresslisteLaden"
        Me.tsmAdresslisteLaden.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.tsmAdresslisteLaden.Size = New System.Drawing.Size(228, 22)
        Me.tsmAdresslisteLaden.Text = "Adressliste &öf&fnen..."
        '
        'tsmAdresslisteSpeichern
        '
        Me.tsmAdresslisteSpeichern.Name = "tsmAdresslisteSpeichern"
        Me.tsmAdresslisteSpeichern.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.tsmAdresslisteSpeichern.Size = New System.Drawing.Size(228, 22)
        Me.tsmAdresslisteSpeichern.Text = "Adressliste &speichern..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(225, 6)
        '
        'tsmZufallsadressenAnfügen
        '
        Me.tsmZufallsadressenAnfügen.Name = "tsmZufallsadressenAnfügen"
        Me.tsmZufallsadressenAnfügen.Size = New System.Drawing.Size(228, 22)
        Me.tsmZufallsadressenAnfügen.Text = "Zufallsadressen anfügen"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'tsmProgrammBeenden
        '
        Me.tsmProgrammBeenden.Name = "tsmProgrammBeenden"
        Me.tsmProgrammBeenden.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.tsmProgrammBeenden.Size = New System.Drawing.Size(228, 22)
        Me.tsmProgrammBeenden.Text = "Programm be&enden"
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmNeueAdresseErfassen, Me.tsmSchnellerfassung, Me.tsmAdresseBearbeiten, Me.tsmAdressenLöschen, Me.ToolStripMenuItem2, Me.tsmAdresseSuchen})
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.BearbeitenToolStripMenuItem.Text = "&Bearbeiten"
        '
        'tsmNeueAdresseErfassen
        '
        Me.tsmNeueAdresseErfassen.Name = "tsmNeueAdresseErfassen"
        Me.tsmNeueAdresseErfassen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.tsmNeueAdresseErfassen.Size = New System.Drawing.Size(244, 22)
        Me.tsmNeueAdresseErfassen.Text = "&Neue Adresse erfassen..."
        '
        'tsmAdresseBearbeiten
        '
        Me.tsmAdresseBearbeiten.Name = "tsmAdresseBearbeiten"
        Me.tsmAdresseBearbeiten.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.tsmAdresseBearbeiten.Size = New System.Drawing.Size(244, 22)
        Me.tsmAdresseBearbeiten.Text = "Adresse &bearbeiten..."
        '
        'tsmAdressenLöschen
        '
        Me.tsmAdressenLöschen.Name = "tsmAdressenLöschen"
        Me.tsmAdressenLöschen.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.tsmAdressenLöschen.Size = New System.Drawing.Size(244, 22)
        Me.tsmAdressenLöschen.Text = "Ausgewählte Adresse &löschen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(241, 6)
        '
        'tsmAdresseSuchen
        '
        Me.tsmAdresseSuchen.Name = "tsmAdresseSuchen"
        Me.tsmAdresseSuchen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.tsmAdresseSuchen.Size = New System.Drawing.Size(244, 22)
        Me.tsmAdresseSuchen.Text = "&Suchen..."
        '
        'ssStatuszeile
        '
        Me.ssStatuszeile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslAusgewählteAdresse})
        Me.ssStatuszeile.Location = New System.Drawing.Point(0, 404)
        Me.ssStatuszeile.Name = "ssStatuszeile"
        Me.ssStatuszeile.Size = New System.Drawing.Size(616, 22)
        Me.ssStatuszeile.TabIndex = 4
        Me.ssStatuszeile.Text = "StatusStrip1"
        '
        'tsslAusgewählteAdresse
        '
        Me.tsslAusgewählteAdresse.Name = "tsslAusgewählteAdresse"
        Me.tsslAusgewählteAdresse.Size = New System.Drawing.Size(115, 17)
        Me.tsslAusgewählteAdresse.Text = "Ausgewählte Adresse:"
        '
        'tsmSchnellerfassung
        '
        Me.tsmSchnellerfassung.Name = "tsmSchnellerfassung"
        Me.tsmSchnellerfassung.Size = New System.Drawing.Size(244, 22)
        Me.tsmSchnellerfassung.Text = "Schnell&erfassung von Adressen..."
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 426)
        Me.Controls.Add(Me.ssStatuszeile)
        Me.Controls.Add(Me.lvwAdressen)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Adresso.NET"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ssStatuszeile.ResumeLayout(False)
        Me.ssStatuszeile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvwAdressen As System.Windows.Forms.ListView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DateiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAdresslisteSpeichern As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAdresslisteLaden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmProgrammBeenden As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmAdressenLöschen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmAdresseSuchen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmZufallsadressenAnfügen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ssStatuszeile As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslAusgewählteAdresse As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsmAdresseBearbeiten As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmNeueAdresseErfassen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmSchnellerfassung As System.Windows.Forms.ToolStripMenuItem

End Class
