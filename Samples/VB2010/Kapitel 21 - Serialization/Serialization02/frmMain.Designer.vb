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
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtErstelltVon = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtErstelltAm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNachname = New System.Windows.Forms.TextBox
        Me.btnDeserialisieren = New System.Windows.Forms.Button
        Me.btnSerialisieren = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPLZOrt = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStraße = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVorname = New System.Windows.Forms.TextBox
        Me.optSoapSerializer = New System.Windows.Forms.RadioButton
        Me.optBinarySerializer = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Erstellt von:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtErstelltVon
        '
        Me.txtErstelltVon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErstelltVon.Location = New System.Drawing.Point(103, 142)
        Me.txtErstelltVon.Name = "txtErstelltVon"
        Me.txtErstelltVon.ReadOnly = True
        Me.txtErstelltVon.Size = New System.Drawing.Size(233, 20)
        Me.txtErstelltVon.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Erstellt am:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtErstelltAm
        '
        Me.txtErstelltAm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErstelltAm.Location = New System.Drawing.Point(103, 116)
        Me.txtErstelltAm.Name = "txtErstelltAm"
        Me.txtErstelltAm.ReadOnly = True
        Me.txtErstelltAm.Size = New System.Drawing.Size(233, 20)
        Me.txtErstelltAm.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Name: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNachname
        '
        Me.txtNachname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNachname.Location = New System.Drawing.Point(103, 12)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(233, 20)
        Me.txtNachname.TabIndex = 16
        '
        'btnDeserialisieren
        '
        Me.btnDeserialisieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeserialisieren.Location = New System.Drawing.Point(361, 52)
        Me.btnDeserialisieren.Name = "btnDeserialisieren"
        Me.btnDeserialisieren.Size = New System.Drawing.Size(128, 32)
        Me.btnDeserialisieren.TabIndex = 24
        Me.btnDeserialisieren.Text = "Deserialisieren"
        '
        'btnSerialisieren
        '
        Me.btnSerialisieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSerialisieren.Location = New System.Drawing.Point(361, 12)
        Me.btnSerialisieren.Name = "btnSerialisieren"
        Me.btnSerialisieren.Size = New System.Drawing.Size(128, 32)
        Me.btnSerialisieren.TabIndex = 23
        Me.btnSerialisieren.Text = "Serialisieren"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "PLZ/Ort: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPLZOrt
        '
        Me.txtPLZOrt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPLZOrt.Location = New System.Drawing.Point(103, 90)
        Me.txtPLZOrt.Name = "txtPLZOrt"
        Me.txtPLZOrt.Size = New System.Drawing.Size(233, 20)
        Me.txtPLZOrt.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Straße: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStraße
        '
        Me.txtStraße.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStraße.Location = New System.Drawing.Point(103, 64)
        Me.txtStraße.Name = "txtStraße"
        Me.txtStraße.Size = New System.Drawing.Size(233, 20)
        Me.txtStraße.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Vorname: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVorname
        '
        Me.txtVorname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVorname.Location = New System.Drawing.Point(103, 38)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(233, 20)
        Me.txtVorname.TabIndex = 18
        '
        'optSoapSerializer
        '
        Me.optSoapSerializer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optSoapSerializer.AutoSize = True
        Me.optSoapSerializer.Checked = True
        Me.optSoapSerializer.Location = New System.Drawing.Point(376, 104)
        Me.optSoapSerializer.Name = "optSoapSerializer"
        Me.optSoapSerializer.Size = New System.Drawing.Size(95, 17)
        Me.optSoapSerializer.TabIndex = 30
        Me.optSoapSerializer.TabStop = True
        Me.optSoapSerializer.Text = "Soap-Serializer"
        '
        'optBinarySerializer
        '
        Me.optBinarySerializer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optBinarySerializer.AutoSize = True
        Me.optBinarySerializer.Location = New System.Drawing.Point(376, 127)
        Me.optBinarySerializer.Name = "optBinarySerializer"
        Me.optBinarySerializer.Size = New System.Drawing.Size(99, 17)
        Me.optBinarySerializer.TabIndex = 29
        Me.optBinarySerializer.Text = "Binary-Serializer"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 180)
        Me.Controls.Add(Me.optSoapSerializer)
        Me.Controls.Add(Me.optBinarySerializer)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtErstelltVon)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtErstelltAm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.btnDeserialisieren)
        Me.Controls.Add(Me.btnSerialisieren)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPLZOrt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStraße)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVorname)
        Me.Name = "frmMain"
        Me.Text = "Serialisierungsdemo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtErstelltVon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtErstelltAm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents btnDeserialisieren As System.Windows.Forms.Button
    Friend WithEvents btnSerialisieren As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPLZOrt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStraße As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents optSoapSerializer As System.Windows.Forms.RadioButton
    Friend WithEvents optBinarySerializer As System.Windows.Forms.RadioButton

End Class
