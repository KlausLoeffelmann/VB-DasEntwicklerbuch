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
        Me.picWecker = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.mtbAlarmzeit = New System.Windows.Forms.MaskedTextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.lstTermine = New System.Windows.Forms.ListBox
        Me.txtGrund = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnHinzufügen = New System.Windows.Forms.Button
        Me.btnLöschen = New System.Windows.Forms.Button
        Me.btnAlarmAusschalten = New System.Windows.Forms.Button
        Me.lblAlarmmeldung = New System.Windows.Forms.Label
        CType(Me.picWecker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picWecker
        '
        Me.picWecker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picWecker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picWecker.Location = New System.Drawing.Point(12, 12)
        Me.picWecker.Name = "picWecker"
        Me.picWecker.Size = New System.Drawing.Size(239, 316)
        Me.picWecker.TabIndex = 0
        Me.picWecker.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(266, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Alarmzeit:"
        '
        'mtbAlarmzeit
        '
        Me.mtbAlarmzeit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtbAlarmzeit.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbAlarmzeit.Location = New System.Drawing.Point(269, 84)
        Me.mtbAlarmzeit.Mask = "99:99:99"
        Me.mtbAlarmzeit.Name = "mtbAlarmzeit"
        Me.mtbAlarmzeit.Size = New System.Drawing.Size(89, 20)
        Me.mtbAlarmzeit.TabIndex = 1
        Me.mtbAlarmzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(422, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(113, 32)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lstTermine
        '
        Me.lstTermine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTermine.FormattingEnabled = True
        Me.lstTermine.Location = New System.Drawing.Point(268, 159)
        Me.lstTermine.Name = "lstTermine"
        Me.lstTermine.Size = New System.Drawing.Size(177, 173)
        Me.lstTermine.TabIndex = 5
        '
        'txtGrund
        '
        Me.txtGrund.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtGrund.Location = New System.Drawing.Point(268, 129)
        Me.txtGrund.Name = "txtGrund"
        Me.txtGrund.Size = New System.Drawing.Size(177, 20)
        Me.txtGrund.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Grund:"
        '
        'btnHinzufügen
        '
        Me.btnHinzufügen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnHinzufügen.Location = New System.Drawing.Point(451, 128)
        Me.btnHinzufügen.Name = "btnHinzufügen"
        Me.btnHinzufügen.Size = New System.Drawing.Size(84, 21)
        Me.btnHinzufügen.TabIndex = 4
        Me.btnHinzufügen.Text = "Hinzufügen"
        Me.btnHinzufügen.UseVisualStyleBackColor = True
        '
        'btnLöschen
        '
        Me.btnLöschen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLöschen.Enabled = False
        Me.btnLöschen.Location = New System.Drawing.Point(451, 159)
        Me.btnLöschen.Name = "btnLöschen"
        Me.btnLöschen.Size = New System.Drawing.Size(84, 21)
        Me.btnLöschen.TabIndex = 6
        Me.btnLöschen.Text = "Löschen"
        Me.btnLöschen.UseVisualStyleBackColor = True
        '
        'btnAlarmAusschalten
        '
        Me.btnAlarmAusschalten.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAlarmAusschalten.Enabled = False
        Me.btnAlarmAusschalten.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAlarmAusschalten.Location = New System.Drawing.Point(268, 12)
        Me.btnAlarmAusschalten.Name = "btnAlarmAusschalten"
        Me.btnAlarmAusschalten.Size = New System.Drawing.Size(113, 32)
        Me.btnAlarmAusschalten.TabIndex = 7
        Me.btnAlarmAusschalten.Text = "Alarm ausschalten"
        Me.btnAlarmAusschalten.UseVisualStyleBackColor = True
        '
        'lblAlarmmeldung
        '
        Me.lblAlarmmeldung.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblAlarmmeldung.AutoEllipsis = True
        Me.lblAlarmmeldung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlarmmeldung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlarmmeldung.Location = New System.Drawing.Point(23, 125)
        Me.lblAlarmmeldung.Name = "lblAlarmmeldung"
        Me.lblAlarmmeldung.Size = New System.Drawing.Size(219, 67)
        Me.lblAlarmmeldung.TabIndex = 9
        Me.lblAlarmmeldung.Text = "Label3"
        Me.lblAlarmmeldung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 340)
        Me.Controls.Add(Me.lblAlarmmeldung)
        Me.Controls.Add(Me.btnAlarmAusschalten)
        Me.Controls.Add(Me.btnLöschen)
        Me.Controls.Add(Me.btnHinzufügen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGrund)
        Me.Controls.Add(Me.lstTermine)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.mtbAlarmzeit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picWecker)
        Me.MinimumSize = New System.Drawing.Size(551, 374)
        Me.Name = "frmMain"
        Me.Text = "Alarmwecker"
        CType(Me.picWecker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picWecker As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtbAlarmzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lstTermine As System.Windows.Forms.ListBox
    Friend WithEvents txtGrund As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnHinzufügen As System.Windows.Forms.Button
    Friend WithEvents btnLöschen As System.Windows.Forms.Button
    Friend WithEvents btnAlarmAusschalten As System.Windows.Forms.Button
    Friend WithEvents lblAlarmmeldung As System.Windows.Forms.Label

End Class
