﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSingleThreading
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnZählenStarten = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LastPrimeBeforeTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PrimesListBox = New System.Windows.Forms.ListBox()
        Me.PrimesToFindUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.ParDegTrackBar = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ParDegTextBox = New System.Windows.Forms.TextBox()
        CType(Me.PrimesToFindUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ParDegTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnZählenStarten
        '
        Me.btnZählenStarten.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZählenStarten.Location = New System.Drawing.Point(12, 123)
        Me.btnZählenStarten.Name = "btnZählenStarten"
        Me.btnZählenStarten.Size = New System.Drawing.Size(416, 34)
        Me.btnZählenStarten.TabIndex = 0
        Me.btnZählenStarten.Text = "Jetzt finden!"
        Me.btnZählenStarten.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Letzten"
        '
        'LastPrimeBeforeTextBox
        '
        Me.LastPrimeBeforeTextBox.Location = New System.Drawing.Point(185, 8)
        Me.LastPrimeBeforeTextBox.Name = "LastPrimeBeforeTextBox"
        Me.LastPrimeBeforeTextBox.Size = New System.Drawing.Size(198, 20)
        Me.LastPrimeBeforeTextBox.TabIndex = 3
        Me.LastPrimeBeforeTextBox.Text = "200000000"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(389, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "finden:"
        '
        'PrimesListBox
        '
        Me.PrimesListBox.FormattingEnabled = True
        Me.PrimesListBox.Location = New System.Drawing.Point(13, 205)
        Me.PrimesListBox.Name = "PrimesListBox"
        Me.PrimesListBox.Size = New System.Drawing.Size(415, 108)
        Me.PrimesListBox.Sorted = True
        Me.PrimesListBox.TabIndex = 5
        '
        'PrimesToFindUpDown
        '
        Me.PrimesToFindUpDown.Location = New System.Drawing.Point(60, 9)
        Me.PrimesToFindUpDown.Name = "PrimesToFindUpDown"
        Me.PrimesToFindUpDown.Size = New System.Drawing.Size(38, 20)
        Me.PrimesToFindUpDown.TabIndex = 6
        Me.PrimesToFindUpDown.Value = New Decimal(New Integer() {32, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(104, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Primzahlen vor"
        '
        'InfoLabel
        '
        Me.InfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoLabel.Location = New System.Drawing.Point(12, 179)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(412, 23)
        Me.InfoLabel.TabIndex = 8
        Me.InfoLabel.Text = "Teste:"
        Me.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ParDegTrackBar
        '
        Me.ParDegTrackBar.Location = New System.Drawing.Point(15, 72)
        Me.ParDegTrackBar.Maximum = 16
        Me.ParDegTrackBar.Minimum = 1
        Me.ParDegTrackBar.Name = "ParDegTrackBar"
        Me.ParDegTrackBar.Size = New System.Drawing.Size(363, 45)
        Me.ParDegTrackBar.TabIndex = 9
        Me.ParDegTrackBar.Value = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Parallelisierungsgrad:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ParDegTextBox
        '
        Me.ParDegTextBox.Location = New System.Drawing.Point(384, 72)
        Me.ParDegTextBox.Name = "ParDegTextBox"
        Me.ParDegTextBox.ReadOnly = True
        Me.ParDegTextBox.Size = New System.Drawing.Size(40, 20)
        Me.ParDegTextBox.TabIndex = 11
        Me.ParDegTextBox.Text = "1"
        '
        'frmSingleThreading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 325)
        Me.Controls.Add(Me.ParDegTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ParDegTrackBar)
        Me.Controls.Add(Me.InfoLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PrimesToFindUpDown)
        Me.Controls.Add(Me.PrimesListBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LastPrimeBeforeTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnZählenStarten)
        Me.Name = "frmSingleThreading"
        Me.Text = "Multithreading Demo - Finding Primes!"
        CType(Me.PrimesToFindUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ParDegTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnZählenStarten As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LastPrimeBeforeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrimesListBox As System.Windows.Forms.ListBox
    Friend WithEvents PrimesToFindUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents InfoLabel As System.Windows.Forms.Label
    Friend WithEvents ParDegTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ParDegTextBox As System.Windows.Forms.TextBox

End Class
