<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchnellerfassung
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchnellerfassung))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tslZeile = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslSpalte = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tslAusnahmetext = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsbAusnahmeAnzeigen = New System.Windows.Forms.ToolStripDropDownButton
        Me.chkSpaltenbreitenAnpassen = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslZeile, Me.tslSpalte, Me.ToolStripStatusLabel3, Me.tslAusnahmetext, Me.tsbAusnahmeAnzeigen})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 434)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(754, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslZeile
        '
        Me.tslZeile.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslZeile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tslZeile.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.tslZeile.Name = "tslZeile"
        Me.tslZeile.Size = New System.Drawing.Size(37, 21)
        Me.tslZeile.Text = "Zeile:"
        '
        'tslSpalte
        '
        Me.tslSpalte.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslSpalte.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tslSpalte.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.tslSpalte.Name = "tslSpalte"
        Me.tslSpalte.Size = New System.Drawing.Size(45, 21)
        Me.tslSpalte.Text = "Spalte:"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.ToolStripStatusLabel3.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(194, 21)
        Me.ToolStripStatusLabel3.Text = "Fehlerausnahme durch Datenbindung:"
        '
        'tslAusnahmetext
        '
        Me.tslAusnahmetext.BorderSides = CType(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tslAusnahmetext.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tslAusnahmetext.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.tslAusnahmetext.Name = "tslAusnahmetext"
        Me.tslAusnahmetext.Size = New System.Drawing.Size(75, 21)
        Me.tslAusnahmetext.Text = "Ausnametext"
        '
        'tsbAusnahmeAnzeigen
        '
        Me.tsbAusnahmeAnzeigen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAusnahmeAnzeigen.Image = CType(resources.GetObject("tsbAusnahmeAnzeigen.Image"), System.Drawing.Image)
        Me.tsbAusnahmeAnzeigen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAusnahmeAnzeigen.Name = "tsbAusnahmeAnzeigen"
        Me.tsbAusnahmeAnzeigen.ShowDropDownArrow = False
        Me.tsbAusnahmeAnzeigen.Size = New System.Drawing.Size(31, 20)
        Me.tsbAusnahmeAnzeigen.Text = "(...)"
        Me.tsbAusnahmeAnzeigen.ToolTipText = "Zeigt Details der letzten aufgetretenen Datenbindungsausnahme an"
        '
        'chkSpaltenbreitenAnpassen
        '
        Me.chkSpaltenbreitenAnpassen.AutoSize = True
        Me.chkSpaltenbreitenAnpassen.Location = New System.Drawing.Point(12, 399)
        Me.chkSpaltenbreitenAnpassen.Name = "chkSpaltenbreitenAnpassen"
        Me.chkSpaltenbreitenAnpassen.Size = New System.Drawing.Size(253, 17)
        Me.chkSpaltenbreitenAnpassen.TabIndex = 5
        Me.chkSpaltenbreitenAnpassen.Text = "Spaltenbreiten automatisch an Inhalte anpassen"
        Me.chkSpaltenbreitenAnpassen.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(623, 389)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(119, 35)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmSchnellerfassung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 456)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.chkSpaltenbreitenAnpassen)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmSchnellerfassung"
        Me.Text = "Adressen-Schnellerfassung"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslZeile As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslSpalte As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslAusnahmetext As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chkSpaltenbreitenAnpassen As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tsbAusnahmeAnzeigen As System.Windows.Forms.ToolStripDropDownButton
End Class
