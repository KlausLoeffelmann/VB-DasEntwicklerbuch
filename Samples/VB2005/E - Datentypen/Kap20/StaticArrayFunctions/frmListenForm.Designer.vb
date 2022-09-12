<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListenForm
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
        Me.lvwAdressen = New System.Windows.Forms.ListView
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnSuchen = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lvwAdressen
        '
        Me.lvwAdressen.FullRowSelect = True
        Me.lvwAdressen.HideSelection = False
        Me.lvwAdressen.Location = New System.Drawing.Point(12, 12)
        Me.lvwAdressen.MultiSelect = False
        Me.lvwAdressen.Name = "lvwAdressen"
        Me.lvwAdressen.Size = New System.Drawing.Size(486, 402)
        Me.lvwAdressen.TabIndex = 0
        Me.lvwAdressen.UseCompatibleStateImageBehavior = False
        Me.lvwAdressen.View = System.Windows.Forms.View.Details
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(504, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 37)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnSuchen
        '
        Me.btnSuchen.Location = New System.Drawing.Point(504, 55)
        Me.btnSuchen.Name = "btnSuchen"
        Me.btnSuchen.Size = New System.Drawing.Size(100, 37)
        Me.btnSuchen.TabIndex = 2
        Me.btnSuchen.Text = "Suchen..."
        Me.btnSuchen.UseVisualStyleBackColor = True
        '
        'frmListenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 426)
        Me.Controls.Add(Me.btnSuchen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lvwAdressen)
        Me.Name = "frmListenForm"
        Me.Text = "Adressenliste"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwAdressen As System.Windows.Forms.ListView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnSuchen As System.Windows.Forms.Button

End Class
