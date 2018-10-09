<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnObjekteSerialisieren = New System.Windows.Forms.Button
        Me.btnObjekteDeserialisieren = New System.Windows.Forms.Button
        Me.btnObjekteAusgeben = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnObjekteSerialisieren
        '
        Me.btnObjekteSerialisieren.Location = New System.Drawing.Point(227, 50)
        Me.btnObjekteSerialisieren.Name = "btnObjekteSerialisieren"
        Me.btnObjekteSerialisieren.Size = New System.Drawing.Size(132, 32)
        Me.btnObjekteSerialisieren.TabIndex = 0
        Me.btnObjekteSerialisieren.Text = "Objekte serialisieren"
        Me.btnObjekteSerialisieren.UseVisualStyleBackColor = True
        '
        'btnObjekteDeserialisieren
        '
        Me.btnObjekteDeserialisieren.Location = New System.Drawing.Point(227, 88)
        Me.btnObjekteDeserialisieren.Name = "btnObjekteDeserialisieren"
        Me.btnObjekteDeserialisieren.Size = New System.Drawing.Size(132, 32)
        Me.btnObjekteDeserialisieren.TabIndex = 1
        Me.btnObjekteDeserialisieren.Text = "Objekte deserialisieren"
        Me.btnObjekteDeserialisieren.UseVisualStyleBackColor = True
        '
        'btnObjekteAusgeben
        '
        Me.btnObjekteAusgeben.Location = New System.Drawing.Point(227, 12)
        Me.btnObjekteAusgeben.Name = "btnObjekteAusgeben"
        Me.btnObjekteAusgeben.Size = New System.Drawing.Size(132, 32)
        Me.btnObjekteAusgeben.TabIndex = 2
        Me.btnObjekteAusgeben.Text = "Objekte ausgeben"
        Me.btnObjekteAusgeben.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 249)
        Me.Controls.Add(Me.btnObjekteAusgeben)
        Me.Controls.Add(Me.btnObjekteDeserialisieren)
        Me.Controls.Add(Me.btnObjekteSerialisieren)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnObjekteSerialisieren As System.Windows.Forms.Button
    Friend WithEvents btnObjekteDeserialisieren As System.Windows.Forms.Button
    Friend WithEvents btnObjekteAusgeben As System.Windows.Forms.Button

End Class
