<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuswertungProjekte
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
        Me.btnAuswer = New System.Windows.Forms.Button
        Me.cbProjekt = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.HeckTickDataSet1 = New HeckTick.HeckTickDataSet
        Me.ProjekteTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAuswer
        '
        Me.btnAuswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuswer.Location = New System.Drawing.Point(266, 61)
        Me.btnAuswer.Name = "btnAuswer"
        Me.btnAuswer.Size = New System.Drawing.Size(75, 23)
        Me.btnAuswer.TabIndex = 5
        Me.btnAuswer.Text = "Auswerten"
        Me.btnAuswer.UseVisualStyleBackColor = True
        '
        'cbProjekt
        '
        Me.cbProjekt.FormattingEnabled = True
        Me.cbProjekt.Location = New System.Drawing.Point(119, 61)
        Me.cbProjekt.Name = "cbProjekt"
        Me.cbProjekt.Size = New System.Drawing.Size(121, 21)
        Me.cbProjekt.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Projektauswahl:"
        '
        'HeckTickDataSet1
        '
        Me.HeckTickDataSet1.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProjekteTableAdapter1
        '
        Me.ProjekteTableAdapter1.ClearBeforeFill = True
        '
        'frmAuswertungProjekte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 128)
        Me.Controls.Add(Me.btnAuswer)
        Me.Controls.Add(Me.cbProjekt)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAuswertungProjekte"
        Me.Text = "Auswertung Projekte"
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAuswer As System.Windows.Forms.Button
    Friend WithEvents cbProjekt As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HeckTickDataSet1 As HeckTick.HeckTickDataSet
    Friend WithEvents ProjekteTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
End Class
