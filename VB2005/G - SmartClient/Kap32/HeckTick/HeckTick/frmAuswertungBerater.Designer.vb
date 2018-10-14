<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuswertungBerater
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbName = New System.Windows.Forms.ComboBox
        Me.BeraterTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
        Me.HeckTickDataSet1 = New HeckTick.HeckTickDataSet
        Me.btnAuswerten = New System.Windows.Forms.Button
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Beraterauswahl:"
        '
        'cbName
        '
        Me.cbName.FormattingEnabled = True
        Me.cbName.Location = New System.Drawing.Point(125, 31)
        Me.cbName.Name = "cbName"
        Me.cbName.Size = New System.Drawing.Size(121, 21)
        Me.cbName.TabIndex = 1
        '
        'BeraterTableAdapter1
        '
        Me.BeraterTableAdapter1.ClearBeforeFill = True
        '
        'HeckTickDataSet1
        '
        Me.HeckTickDataSet1.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnAuswerten
        '
        Me.btnAuswerten.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAuswerten.Location = New System.Drawing.Point(271, 31)
        Me.btnAuswerten.Name = "btnAuswerten"
        Me.btnAuswerten.Size = New System.Drawing.Size(75, 23)
        Me.btnAuswerten.TabIndex = 2
        Me.btnAuswerten.Text = "Auswerten"
        Me.btnAuswerten.UseVisualStyleBackColor = True
        '
        'frmAuswertungBerater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 97)
        Me.Controls.Add(Me.btnAuswerten)
        Me.Controls.Add(Me.cbName)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAuswertungBerater"
        Me.Text = "Auswertung Berater"
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbName As System.Windows.Forms.ComboBox
    Friend WithEvents BeraterTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
    Friend WithEvents HeckTickDataSet1 As HeckTick.HeckTickDataSet
    Friend WithEvents btnAuswerten As System.Windows.Forms.Button
End Class
