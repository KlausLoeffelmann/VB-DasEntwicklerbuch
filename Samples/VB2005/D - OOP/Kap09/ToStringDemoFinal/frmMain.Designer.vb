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
        Me.lstKontakte = New System.Windows.Forms.ListBox
        Me.btnKontaktHinzufügen = New System.Windows.Forms.Button
        Me.txtVorname = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNachname = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'lstKontakte
        '
        Me.lstKontakte.FormattingEnabled = True
        Me.lstKontakte.Location = New System.Drawing.Point(12, 12)
        Me.lstKontakte.Name = "lstKontakte"
        Me.lstKontakte.Size = New System.Drawing.Size(303, 316)
        Me.lstKontakte.TabIndex = 0
        '
        'btnKontaktHinzufügen
        '
        Me.btnKontaktHinzufügen.Location = New System.Drawing.Point(406, 153)
        Me.btnKontaktHinzufügen.Name = "btnKontaktHinzufügen"
        Me.btnKontaktHinzufügen.Size = New System.Drawing.Size(115, 31)
        Me.btnKontaktHinzufügen.TabIndex = 5
        Me.btnKontaktHinzufügen.Text = "Kontakt hinzufügen"
        Me.btnKontaktHinzufügen.UseVisualStyleBackColor = True
        '
        'txtVorname
        '
        Me.txtVorname.Location = New System.Drawing.Point(341, 69)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(180, 20)
        Me.txtVorname.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(338, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vorname:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(338, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nachname:"
        '
        'txtNachname
        '
        Me.txtNachname.Location = New System.Drawing.Point(341, 116)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(180, 20)
        Me.txtNachname.TabIndex = 4
        '
        'frmMain
        '
        Me.AcceptButton = Me.btnKontaktHinzufügen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 349)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVorname)
        Me.Controls.Add(Me.btnKontaktHinzufügen)
        Me.Controls.Add(Me.lstKontakte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ToString-Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstKontakte As System.Windows.Forms.ListBox
    Friend WithEvents btnKontaktHinzufügen As System.Windows.Forms.Button
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox

End Class
