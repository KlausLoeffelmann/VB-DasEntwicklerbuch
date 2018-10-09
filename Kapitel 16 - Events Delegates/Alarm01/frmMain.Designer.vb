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
        Me.chkAlarmAktivieren = New System.Windows.Forms.CheckBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnAusschalten = New System.Windows.Forms.Button
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
        Me.picWecker.Size = New System.Drawing.Size(412, 332)
        Me.picWecker.TabIndex = 0
        Me.picWecker.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(430, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Alarmzeit:"
        '
        'mtbAlarmzeit
        '
        Me.mtbAlarmzeit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mtbAlarmzeit.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtbAlarmzeit.Location = New System.Drawing.Point(433, 86)
        Me.mtbAlarmzeit.Mask = "99:99:99"
        Me.mtbAlarmzeit.Name = "mtbAlarmzeit"
        Me.mtbAlarmzeit.Size = New System.Drawing.Size(113, 20)
        Me.mtbAlarmzeit.TabIndex = 2
        Me.mtbAlarmzeit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkAlarmAktivieren
        '
        Me.chkAlarmAktivieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkAlarmAktivieren.AutoSize = True
        Me.chkAlarmAktivieren.Location = New System.Drawing.Point(433, 123)
        Me.chkAlarmAktivieren.Name = "chkAlarmAktivieren"
        Me.chkAlarmAktivieren.Size = New System.Drawing.Size(113, 17)
        Me.chkAlarmAktivieren.TabIndex = 3
        Me.chkAlarmAktivieren.Text = "Wecker aktivieren"
        Me.chkAlarmAktivieren.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(433, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(113, 32)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAusschalten
        '
        Me.btnAusschalten.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAusschalten.Enabled = False
        Me.btnAusschalten.Location = New System.Drawing.Point(433, 160)
        Me.btnAusschalten.Name = "btnAusschalten"
        Me.btnAusschalten.Size = New System.Drawing.Size(113, 31)
        Me.btnAusschalten.TabIndex = 5
        Me.btnAusschalten.Text = "Ausschalten"
        Me.btnAusschalten.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 356)
        Me.Controls.Add(Me.btnAusschalten)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkAlarmAktivieren)
        Me.Controls.Add(Me.mtbAlarmzeit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.picWecker)
        Me.Name = "frmMain"
        Me.Text = "Alarmwecker"
        CType(Me.picWecker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picWecker As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mtbAlarmzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents chkAlarmAktivieren As System.Windows.Forms.CheckBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAusschalten As System.Windows.Forms.Button

End Class
