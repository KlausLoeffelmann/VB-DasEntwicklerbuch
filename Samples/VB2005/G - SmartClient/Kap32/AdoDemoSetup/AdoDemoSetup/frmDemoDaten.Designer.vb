<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemoDaten
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
        Me.dtpVon = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpBis = New System.Windows.Forms.DateTimePicker
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnDatenErzeugen = New System.Windows.Forms.Button
        Me.pbDBSetupFortschritt = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblStatustext = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'dtpVon
        '
        Me.dtpVon.Location = New System.Drawing.Point(110, 43)
        Me.dtpVon.Name = "dtpVon"
        Me.dtpVon.Size = New System.Drawing.Size(186, 20)
        Me.dtpVon.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(53, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "zwischen"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(79, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "und"
        '
        'dtpBis
        '
        Me.dtpBis.Location = New System.Drawing.Point(110, 69)
        Me.dtpBis.Name = "dtpBis"
        Me.dtpBis.Size = New System.Drawing.Size(186, 20)
        Me.dtpBis.TabIndex = 10
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(456, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(99, 29)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDatenErzeugen
        '
        Me.btnDatenErzeugen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDatenErzeugen.Location = New System.Drawing.Point(321, 60)
        Me.btnDatenErzeugen.Name = "btnDatenErzeugen"
        Me.btnDatenErzeugen.Size = New System.Drawing.Size(99, 29)
        Me.btnDatenErzeugen.TabIndex = 12
        Me.btnDatenErzeugen.Text = "Daten erzeugen"
        Me.btnDatenErzeugen.UseVisualStyleBackColor = True
        '
        'pbDBSetupFortschritt
        '
        Me.pbDBSetupFortschritt.Location = New System.Drawing.Point(12, 185)
        Me.pbDBSetupFortschritt.Name = "pbDBSetupFortschritt"
        Me.pbDBSetupFortschritt.Size = New System.Drawing.Size(408, 22)
        Me.pbDBSetupFortschritt.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Fortschritt"
        '
        'lblStatustext
        '
        Me.lblStatustext.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatustext.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblStatustext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatustext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblStatustext.Location = New System.Drawing.Point(12, 137)
        Me.lblStatustext.Name = "lblStatustext"
        Me.lblStatustext.Size = New System.Drawing.Size(409, 45)
        Me.lblStatustext.TabIndex = 15
        Me.lblStatustext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Zeitdaten für Berater generieren"
        '
        'frmDemoDaten
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOK
        Me.ClientSize = New System.Drawing.Size(567, 221)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStatustext)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pbDBSetupFortschritt)
        Me.Controls.Add(Me.btnDatenErzeugen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpBis)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpVon)
        Me.Name = "frmDemoDaten"
        Me.Text = "Demodaten erstellen:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpVon As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpBis As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDatenErzeugen As System.Windows.Forms.Button
    Friend WithEvents pbDBSetupFortschritt As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblStatustext As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
