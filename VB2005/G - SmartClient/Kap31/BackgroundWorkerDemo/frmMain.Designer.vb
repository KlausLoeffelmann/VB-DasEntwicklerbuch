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
        Me.PrimzahlenBackgroundWorker = New System.ComponentModel.BackgroundWorker
        Me.lblHöchstePrimzahl = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.lblGefundenText = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAnzahlPrimzahlen = New System.Windows.Forms.TextBox
        Me.btnBerechnungStarten = New System.Windows.Forms.Button
        Me.pbBerechnungsfortschritt = New System.Windows.Forms.ProgressBar
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PrimzahlenBackgroundWorker
        '
        '
        'lblHöchstePrimzahl
        '
        Me.lblHöchstePrimzahl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHöchstePrimzahl.Location = New System.Drawing.Point(15, 138)
        Me.lblHöchstePrimzahl.Name = "lblHöchstePrimzahl"
        Me.lblHöchstePrimzahl.Size = New System.Drawing.Size(269, 20)
        Me.lblHöchstePrimzahl.TabIndex = 12
        Me.lblHöchstePrimzahl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(318, 25)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 36)
        Me.btnOK.TabIndex = 11
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblGefundenText
        '
        Me.lblGefundenText.AutoSize = True
        Me.lblGefundenText.Location = New System.Drawing.Point(12, 123)
        Me.lblGefundenText.Name = "lblGefundenText"
        Me.lblGefundenText.Size = New System.Drawing.Size(0, 13)
        Me.lblGefundenText.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Anzahl zu berechnender Primzahlen"
        '
        'txtAnzahlPrimzahlen
        '
        Me.txtAnzahlPrimzahlen.Location = New System.Drawing.Point(15, 41)
        Me.txtAnzahlPrimzahlen.Name = "txtAnzahlPrimzahlen"
        Me.txtAnzahlPrimzahlen.Size = New System.Drawing.Size(269, 20)
        Me.txtAnzahlPrimzahlen.TabIndex = 8
        '
        'btnBerechnungStarten
        '
        Me.btnBerechnungStarten.Location = New System.Drawing.Point(318, 67)
        Me.btnBerechnungStarten.Name = "btnBerechnungStarten"
        Me.btnBerechnungStarten.Size = New System.Drawing.Size(120, 36)
        Me.btnBerechnungStarten.TabIndex = 7
        Me.btnBerechnungStarten.Text = "Berechnung Starten"
        Me.btnBerechnungStarten.UseVisualStyleBackColor = True
        '
        'pbBerechnungsfortschritt
        '
        Me.pbBerechnungsfortschritt.Location = New System.Drawing.Point(15, 94)
        Me.pbBerechnungsfortschritt.Name = "pbBerechnungsfortschritt"
        Me.pbBerechnungsfortschritt.Size = New System.Drawing.Size(269, 20)
        Me.pbBerechnungsfortschritt.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Berechnungsfortschritt:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 202)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pbBerechnungsfortschritt)
        Me.Controls.Add(Me.lblHöchstePrimzahl)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblGefundenText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnzahlPrimzahlen)
        Me.Controls.Add(Me.btnBerechnungStarten)
        Me.Name = "frmMain"
        Me.Text = "Primzahlenberechnung - BackgroundWorker-Komponente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrimzahlenBackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblHöchstePrimzahl As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblGefundenText As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAnzahlPrimzahlen As System.Windows.Forms.TextBox
    Friend WithEvents btnBerechnungStarten As System.Windows.Forms.Button
    Friend WithEvents pbBerechnungsfortschritt As System.Windows.Forms.ProgressBar
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
