<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnShowWeekday = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.lblResult = New System.Windows.Forms.Label
        Me.txtWeekday = New System.Windows.Forms.TextBox
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnShowWeekday
        '
        Me.btnShowWeekday.Location = New System.Drawing.Point(248, 14)
        Me.btnShowWeekday.Name = "btnShowWeekday"
        Me.btnShowWeekday.Size = New System.Drawing.Size(118, 27)
        Me.btnShowWeekday.TabIndex = 0
        Me.btnShowWeekday.Text = "Wochentag zeigen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Datum:"
        '
        'txtDate
        '
        Me.txtDate.Location = New System.Drawing.Point(64, 16)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(166, 20)
        Me.txtDate.TabIndex = 2
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(14, 67)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(47, 13)
        Me.lblResult.TabIndex = 3
        Me.lblResult.Text = "Ergebnis:"
        '
        'txtWeekday
        '
        Me.txtWeekday.Location = New System.Drawing.Point(15, 83)
        Me.txtWeekday.Name = "txtWeekday"
        Me.txtWeekday.Size = New System.Drawing.Size(214, 20)
        Me.txtWeekday.TabIndex = 4
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Location = New System.Drawing.Point(248, 47)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(118, 27)
        Me.btnQuitProgram.TabIndex = 5
        Me.btnQuitProgram.Text = "Programm beenden"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 176)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Controls.Add(Me.txtWeekday)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnShowWeekday)
        Me.Name = "frmMain"
        Me.Text = "Wochentagsermittlung"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnShowWeekday As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents txtWeekday As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button

End Class
