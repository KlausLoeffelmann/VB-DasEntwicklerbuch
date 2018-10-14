<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZeitErfassen
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
        Me.cbName = New System.Windows.Forms.ComboBox
        Me.cbProjekt = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateStartzeit = New System.Windows.Forms.DateTimePicker
        Me.txtUhrStartzeit = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUhrEndzeit = New System.Windows.Forms.MaskedTextBox
        Me.dtpDateEndzeit = New System.Windows.Forms.DateTimePicker
        Me.txtArbBeschreibung = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.HeckTickDataSet1 = New HeckTick.HeckTickDataSet
        Me.ZeitenTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
        Me.BeraterTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
        Me.ProjekteTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbName
        '
        Me.cbName.FormattingEnabled = True
        Me.cbName.Location = New System.Drawing.Point(97, 28)
        Me.cbName.Name = "cbName"
        Me.cbName.Size = New System.Drawing.Size(121, 21)
        Me.cbName.TabIndex = 0
        '
        'cbProjekt
        '
        Me.cbProjekt.FormattingEnabled = True
        Me.cbProjekt.Location = New System.Drawing.Point(406, 28)
        Me.cbProjekt.Name = "cbProjekt"
        Me.cbProjekt.Size = New System.Drawing.Size(121, 21)
        Me.cbProjekt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(336, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Projekt:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Berater:"
        '
        'dtpDateStartzeit
        '
        Me.dtpDateStartzeit.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateStartzeit.Location = New System.Drawing.Point(94, 86)
        Me.dtpDateStartzeit.Name = "dtpDateStartzeit"
        Me.dtpDateStartzeit.Size = New System.Drawing.Size(124, 20)
        Me.dtpDateStartzeit.TabIndex = 4
        '
        'txtUhrStartzeit
        '
        Me.txtUhrStartzeit.Location = New System.Drawing.Point(158, 114)
        Me.txtUhrStartzeit.Name = "txtUhrStartzeit"
        Me.txtUhrStartzeit.Size = New System.Drawing.Size(60, 20)
        Me.txtUhrStartzeit.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Startzeit:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Uhrzeit:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(336, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Uhrzeit:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(336, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Endzeit:"
        '
        'txtUhrEndzeit
        '
        Me.txtUhrEndzeit.Location = New System.Drawing.Point(467, 115)
        Me.txtUhrEndzeit.Name = "txtUhrEndzeit"
        Me.txtUhrEndzeit.Size = New System.Drawing.Size(60, 20)
        Me.txtUhrEndzeit.TabIndex = 10
        '
        'dtpDateEndzeit
        '
        Me.dtpDateEndzeit.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateEndzeit.Location = New System.Drawing.Point(406, 87)
        Me.dtpDateEndzeit.Name = "dtpDateEndzeit"
        Me.dtpDateEndzeit.Size = New System.Drawing.Size(121, 20)
        Me.dtpDateEndzeit.TabIndex = 9
        '
        'txtArbBeschreibung
        '
        Me.txtArbBeschreibung.Location = New System.Drawing.Point(158, 162)
        Me.txtArbBeschreibung.Multiline = True
        Me.txtArbBeschreibung.Name = "txtArbBeschreibung"
        Me.txtArbBeschreibung.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtArbBeschreibung.Size = New System.Drawing.Size(369, 135)
        Me.txtArbBeschreibung.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Arbeitsbeschreibung:"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(339, 319)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(89, 30)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'HeckTickDataSet1
        '
        Me.HeckTickDataSet1.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZeitenTableAdapter1
        '
        Me.ZeitenTableAdapter1.ClearBeforeFill = True
        '
        'BeraterTableAdapter1
        '
        Me.BeraterTableAdapter1.ClearBeforeFill = True
        '
        'ProjekteTableAdapter1
        '
        Me.ProjekteTableAdapter1.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(441, 319)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 30)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Abbrechen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmZeitErfassen
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 373)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtArbBeschreibung)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtUhrEndzeit)
        Me.Controls.Add(Me.dtpDateEndzeit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtUhrStartzeit)
        Me.Controls.Add(Me.dtpDateStartzeit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbProjekt)
        Me.Controls.Add(Me.cbName)
        Me.Name = "frmZeitErfassen"
        Me.Text = "Zeit erfassen"
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeckTickDataSet1 As HeckTick.HeckTickDataSet
    Friend WithEvents ZeitenTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
    Friend WithEvents cbName As System.Windows.Forms.ComboBox
    Friend WithEvents cbProjekt As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BeraterTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
    Friend WithEvents ProjekteTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
    Friend WithEvents dtpDateStartzeit As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtUhrStartzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUhrEndzeit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpDateEndzeit As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtArbBeschreibung As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
