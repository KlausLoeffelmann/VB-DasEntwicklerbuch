<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdresseNeuUndBearbeiten
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
        Debug.Print("Form is disposing!")
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnAbbrechen = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMatchcode = New System.Windows.Forms.TextBox
        Me.txtVorname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNachname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtStraße = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtOrt = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.mtbPlz = New System.Windows.Forms.MaskedTextBox
        Me.mtbGeburtsdatum = New System.Windows.Forms.MaskedTextBox
        Me.lblWochentag = New System.Windows.Forms.Label
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(374, 26)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 29)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAbbrechen
        '
        Me.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbbrechen.Location = New System.Drawing.Point(374, 61)
        Me.btnAbbrechen.Name = "btnAbbrechen"
        Me.btnAbbrechen.Size = New System.Drawing.Size(90, 29)
        Me.btnAbbrechen.TabIndex = 16
        Me.btnAbbrechen.Text = "Abbrechen"
        Me.btnAbbrechen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Matchcode:"
        '
        'txtMatchcode
        '
        Me.txtMatchcode.Location = New System.Drawing.Point(115, 26)
        Me.txtMatchcode.Name = "txtMatchcode"
        Me.txtMatchcode.Size = New System.Drawing.Size(216, 20)
        Me.txtMatchcode.TabIndex = 1
        '
        'txtVorname
        '
        Me.txtVorname.Location = New System.Drawing.Point(115, 52)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(216, 20)
        Me.txtVorname.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Vorname:"
        '
        'txtNachname
        '
        Me.txtNachname.Location = New System.Drawing.Point(115, 78)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(216, 20)
        Me.txtNachname.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Nachname:"
        '
        'txtStraße
        '
        Me.txtStraße.Location = New System.Drawing.Point(115, 104)
        Me.txtStraße.Name = "txtStraße"
        Me.txtStraße.Size = New System.Drawing.Size(216, 20)
        Me.txtStraße.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&Straße:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "&PLZ/"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "&Geburtsdatum:"
        '
        'txtOrt
        '
        Me.txtOrt.Location = New System.Drawing.Point(192, 130)
        Me.txtOrt.Name = "txtOrt"
        Me.txtOrt.Size = New System.Drawing.Size(139, 20)
        Me.txtOrt.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(40, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "&Ort:"
        '
        'mtbPlz
        '
        Me.mtbPlz.Location = New System.Drawing.Point(115, 130)
        Me.mtbPlz.Mask = "00000"
        Me.mtbPlz.Name = "mtbPlz"
        Me.mtbPlz.Size = New System.Drawing.Size(71, 20)
        Me.mtbPlz.TabIndex = 9
        Me.mtbPlz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mtbGeburtsdatum
        '
        Me.mtbGeburtsdatum.Location = New System.Drawing.Point(115, 156)
        Me.mtbGeburtsdatum.Mask = "00/00/0000"
        Me.mtbGeburtsdatum.Name = "mtbGeburtsdatum"
        Me.mtbGeburtsdatum.Size = New System.Drawing.Size(72, 20)
        Me.mtbGeburtsdatum.TabIndex = 13
        '
        'lblWochentag
        '
        Me.lblWochentag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWochentag.Location = New System.Drawing.Point(192, 156)
        Me.lblWochentag.Name = "lblWochentag"
        Me.lblWochentag.Size = New System.Drawing.Size(139, 20)
        Me.lblWochentag.TabIndex = 14
        Me.lblWochentag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'frmAdresseNeuUndBearbeiten
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnAbbrechen
        Me.ClientSize = New System.Drawing.Size(476, 201)
        Me.Controls.Add(Me.lblWochentag)
        Me.Controls.Add(Me.mtbGeburtsdatum)
        Me.Controls.Add(Me.mtbPlz)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtOrt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtStraße)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtVorname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMatchcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAbbrechen)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmAdresseNeuUndBearbeiten"
        Me.Text = "Neue Adresse anlegen/Adresse bearbeiten"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAbbrechen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMatchcode As System.Windows.Forms.TextBox
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtStraße As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOrt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents mtbPlz As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtbGeburtsdatum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblWochentag As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
End Class
