<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBeraterSuchen
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
        Me.btnSuchen = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNachname = New System.Windows.Forms.TextBox
        Me.BeraterTableAdapter1 = New HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
        Me.HeckTickDataSet1 = New HeckTick.HeckTickDataSet
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSuchen
        '
        Me.btnSuchen.Location = New System.Drawing.Point(245, 31)
        Me.btnSuchen.Name = "btnSuchen"
        Me.btnSuchen.Size = New System.Drawing.Size(75, 23)
        Me.btnSuchen.TabIndex = 1
        Me.btnSuchen.Text = "Suchen"
        Me.btnSuchen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nachname:"
        '
        'txtNachname
        '
        Me.txtNachname.Location = New System.Drawing.Point(98, 33)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(100, 20)
        Me.txtNachname.TabIndex = 3
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
        'frmBeraterSuchen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 82)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSuchen)
        Me.Name = "frmBeraterSuchen"
        Me.Text = "Berater suchen"
        CType(Me.HeckTickDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSuchen As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents BeraterTableAdapter1 As HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
    Friend WithEvents HeckTickDataSet1 As HeckTick.HeckTickDataSet
End Class
