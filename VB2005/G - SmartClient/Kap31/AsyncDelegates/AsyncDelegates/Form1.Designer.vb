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
        Me.btnBerechnungStarten = New System.Windows.Forms.Button
        Me.txtAnzahlPrimzahlen = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.lblHöchstePrimzahl = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnBerechnungStarten
        '
        Me.btnBerechnungStarten.Location = New System.Drawing.Point(346, 59)
        Me.btnBerechnungStarten.Name = "btnBerechnungStarten"
        Me.btnBerechnungStarten.Size = New System.Drawing.Size(120, 36)
        Me.btnBerechnungStarten.TabIndex = 0
        Me.btnBerechnungStarten.Text = "Berechnung Starten"
        Me.btnBerechnungStarten.UseVisualStyleBackColor = True
        '
        'txtAnzahlPrimzahlen
        '
        Me.txtAnzahlPrimzahlen.Location = New System.Drawing.Point(12, 33)
        Me.txtAnzahlPrimzahlen.Name = "txtAnzahlPrimzahlen"
        Me.txtAnzahlPrimzahlen.Size = New System.Drawing.Size(209, 20)
        Me.txtAnzahlPrimzahlen.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Anzahl zu berechnender Primzahlen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Die höchste Primzahl im Bereich lautet:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(346, 17)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 36)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblHöchstePrimzahl
        '
        Me.lblHöchstePrimzahl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHöchstePrimzahl.Location = New System.Drawing.Point(12, 89)
        Me.lblHöchstePrimzahl.Name = "lblHöchstePrimzahl"
        Me.lblHöchstePrimzahl.Size = New System.Drawing.Size(209, 20)
        Me.lblHöchstePrimzahl.TabIndex = 6
        Me.lblHöchstePrimzahl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 142)
        Me.Controls.Add(Me.lblHöchstePrimzahl)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnzahlPrimzahlen)
        Me.Controls.Add(Me.btnBerechnungStarten)
        Me.Name = "Form1"
        Me.Text = "Primzahlen berechnen - asynchroner Aufruf eines Delegaten"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBerechnungStarten As System.Windows.Forms.Button
    Friend WithEvents txtAnzahlPrimzahlen As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblHöchstePrimzahl As System.Windows.Forms.Label

End Class
