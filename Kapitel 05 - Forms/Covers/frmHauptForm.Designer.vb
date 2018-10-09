<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHauptForm
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnInlayDrucken = New System.Windows.Forms.Button()
        Me.lblFilmname = New System.Windows.Forms.Label()
        Me.txtNameDesFilms = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSchauspieler = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKurzbeschreibung = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.picCoverbild = New System.Windows.Forms.PictureBox()
        Me.btnCoverbildWählen = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEingabenLöschen = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.picCoverbild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOK.Location = New System.Drawing.Point(431, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(113, 39)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnInlayDrucken
        '
        Me.btnInlayDrucken.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInlayDrucken.Location = New System.Drawing.Point(431, 57)
        Me.btnInlayDrucken.Name = "btnInlayDrucken"
        Me.btnInlayDrucken.Size = New System.Drawing.Size(113, 39)
        Me.btnInlayDrucken.TabIndex = 2
        Me.btnInlayDrucken.Text = "Inlay &drucken..."
        Me.btnInlayDrucken.UseVisualStyleBackColor = True
        '
        'lblFilmname
        '
        Me.lblFilmname.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFilmname.AutoSize = True
        Me.lblFilmname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFilmname.Location = New System.Drawing.Point(3, 5)
        Me.lblFilmname.Name = "lblFilmname"
        Me.lblFilmname.Size = New System.Drawing.Size(114, 15)
        Me.lblFilmname.TabIndex = 0
        Me.lblFilmname.Text = "&Name des Films:"
        Me.lblFilmname.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNameDesFilms
        '
        Me.txtNameDesFilms.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNameDesFilms.Location = New System.Drawing.Point(123, 3)
        Me.txtNameDesFilms.Name = "txtNameDesFilms"
        Me.txtNameDesFilms.Size = New System.Drawing.Size(278, 20)
        Me.txtNameDesFilms.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(3, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "&Schauspieler:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSchauspieler
        '
        Me.txtSchauspieler.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSchauspieler.Location = New System.Drawing.Point(123, 28)
        Me.txtSchauspieler.Multiline = True
        Me.txtSchauspieler.Name = "txtSchauspieler"
        Me.txtSchauspieler.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSchauspieler.Size = New System.Drawing.Size(278, 68)
        Me.txtSchauspieler.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Location = New System.Drawing.Point(3, 102)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "&Kurzbeschreibung:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKurzbeschreibung
        '
        Me.txtKurzbeschreibung.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtKurzbeschreibung.Location = New System.Drawing.Point(123, 102)
        Me.txtKurzbeschreibung.Multiline = True
        Me.txtKurzbeschreibung.Name = "txtKurzbeschreibung"
        Me.txtKurzbeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtKurzbeschreibung.Size = New System.Drawing.Size(278, 68)
        Me.txtKurzbeschreibung.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Panel1, 2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnCoverbildWählen)
        Me.Panel1.Location = New System.Drawing.Point(3, 176)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(398, 143)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.picCoverbild)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(362, 137)
        Me.Panel2.TabIndex = 1
        '
        'picCoverbild
        '
        Me.picCoverbild.Location = New System.Drawing.Point(3, 3)
        Me.picCoverbild.Name = "picCoverbild"
        Me.picCoverbild.Size = New System.Drawing.Size(354, 126)
        Me.picCoverbild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picCoverbild.TabIndex = 11
        Me.picCoverbild.TabStop = False
        '
        'btnCoverbildWählen
        '
        Me.btnCoverbildWählen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCoverbildWählen.Location = New System.Drawing.Point(371, 0)
        Me.btnCoverbildWählen.Name = "btnCoverbildWählen"
        Me.btnCoverbildWählen.Size = New System.Drawing.Size(24, 19)
        Me.btnCoverbildWählen.TabIndex = 0
        Me.btnCoverbildWählen.Text = "..."
        Me.btnCoverbildWählen.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblFilmname, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtNameDesFilms, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtKurzbeschreibung, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtSchauspieler, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(404, 322)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'btnEingabenLöschen
        '
        Me.btnEingabenLöschen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEingabenLöschen.Location = New System.Drawing.Point(431, 102)
        Me.btnEingabenLöschen.Name = "btnEingabenLöschen"
        Me.btnEingabenLöschen.Size = New System.Drawing.Size(113, 39)
        Me.btnEingabenLöschen.TabIndex = 3
        Me.btnEingabenLöschen.Text = "Eingaben löschen"
        Me.btnEingabenLöschen.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(556, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'frmHauptForm
        '
        Me.AcceptButton = Me.btnInlayDrucken
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(556, 346)
        Me.Controls.Add(Me.btnEingabenLöschen)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnInlayDrucken)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.Covers.My.MySettings.Default, "HauptformularPosition", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Location = Global.Covers.My.MySettings.Default.HauptformularPosition
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmHauptForm"
        Me.Text = "Covers - Der VB-Entwicklerbuch-Hüllen-Inlay-Generator"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.picCoverbild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnInlayDrucken As System.Windows.Forms.Button
    Friend WithEvents lblFilmname As System.Windows.Forms.Label
    Friend WithEvents txtNameDesFilms As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSchauspieler As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKurzbeschreibung As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCoverbildWählen As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents picCoverbild As System.Windows.Forms.PictureBox
    Friend WithEvents btnEingabenLöschen As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip

End Class
