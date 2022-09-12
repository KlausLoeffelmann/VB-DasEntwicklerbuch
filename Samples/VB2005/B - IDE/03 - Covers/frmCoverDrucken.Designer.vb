<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoverDrucken
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
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnDruckAufStandarddrucker = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(9, 11)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(638, 423)
        Me.PrintPreviewControl1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(381, 445)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(130, 40)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnDruckAufStandarddrucker
        '
        Me.btnDruckAufStandarddrucker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDruckAufStandarddrucker.Location = New System.Drawing.Point(517, 445)
        Me.btnDruckAufStandarddrucker.Name = "btnDruckAufStandarddrucker"
        Me.btnDruckAufStandarddrucker.Size = New System.Drawing.Size(130, 40)
        Me.btnDruckAufStandarddrucker.TabIndex = 2
        Me.btnDruckAufStandarddrucker.Text = "Drucken..."
        Me.btnDruckAufStandarddrucker.UseVisualStyleBackColor = True
        '
        'frmCoverDrucken
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 492)
        Me.Controls.Add(Me.btnDruckAufStandarddrucker)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.PrintPreviewControl1)
        Me.Name = "frmCoverDrucken"
        Me.Text = "Covervorschau zeigen und Cover drucken"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PrintPreviewControl1 As System.Windows.Forms.PrintPreviewControl
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnDruckAufStandarddrucker As System.Windows.Forms.Button
End Class
