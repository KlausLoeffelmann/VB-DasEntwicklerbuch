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
        Me.btnFlashIt = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.AdLabelExToFlash3 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelEx8 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelExToFlash4 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelExToFlash1 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelEx7 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelEx6 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelEx5 = New ActiveDevelop.Controls.ADLabelEx
        Me.AdLabelExToFlash2 = New ActiveDevelop.Controls.ADLabelEx
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFlashIt
        '
        Me.btnFlashIt.Location = New System.Drawing.Point(21, 283)
        Me.btnFlashIt.Name = "btnFlashIt"
        Me.btnFlashIt.Size = New System.Drawing.Size(513, 24)
        Me.btnFlashIt.TabIndex = 18
        Me.btnFlashIt.Text = "Und das kann das Label schonmal gar nicht!"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AdLabelEx7)
        Me.GroupBox1.Controls.Add(Me.AdLabelEx6)
        Me.GroupBox1.Controls.Add(Me.AdLabelEx5)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 128)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Automatische Abkürzungen:"
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(213, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 35)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "...funktioniert mit dem Standardmäßigem Label nicht wirklich"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdLabelExToFlash3
        '
        Me.AdLabelExToFlash3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelExToFlash3.DirectionVertical = True
        Me.AdLabelExToFlash3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabelExToFlash3.Location = New System.Drawing.Point(403, 26)
        Me.AdLabelExToFlash3.Name = "AdLabelExToFlash3"
        Me.AdLabelExToFlash3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.AdLabelExToFlash3.Size = New System.Drawing.Size(131, 241)
        Me.AdLabelExToFlash3.TabIndex = 25
        Me.AdLabelExToFlash3.Text = "Copyright (c) 2003-2006 by ActiveDevelop - Klaus Löffelmann"
        Me.AdLabelExToFlash3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdLabelEx8
        '
        Me.AdLabelEx8.AutoHeight = True
        Me.AdLabelEx8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelEx8.Location = New System.Drawing.Point(213, 26)
        Me.AdLabelEx8.Name = "AdLabelEx8"
        Me.AdLabelEx8.Size = New System.Drawing.Size(168, 54)
        Me.AdLabelEx8.TabIndex = 23
        Me.AdLabelEx8.Text = "Die Höhe des Steuerelements wird bei AutoHeight automatisch durch die Breite und " & _
            "die Textmenge vorgegeben!"
        Me.AdLabelEx8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdLabelExToFlash4
        '
        Me.AdLabelExToFlash4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelExToFlash4.Location = New System.Drawing.Point(21, 98)
        Me.AdLabelExToFlash4.Name = "AdLabelExToFlash4"
        Me.AdLabelExToFlash4.Size = New System.Drawing.Size(168, 35)
        Me.AdLabelExToFlash4.TabIndex = 22
        Me.AdLabelExToFlash4.Text = "Zentriertes Auslassen von Texten..."
        Me.AdLabelExToFlash4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AdLabelExToFlash4.TextWrap = False
        '
        'AdLabelExToFlash1
        '
        Me.AdLabelExToFlash1.AutoHeight = True
        Me.AdLabelExToFlash1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelExToFlash1.Location = New System.Drawing.Point(21, 26)
        Me.AdLabelExToFlash1.Name = "AdLabelExToFlash1"
        Me.AdLabelExToFlash1.Size = New System.Drawing.Size(168, 16)
        Me.AdLabelExToFlash1.TabIndex = 19
        Me.AdLabelExToFlash1.Text = "Linksbündige Formatierung"
        Me.AdLabelExToFlash1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AdLabelEx7
        '
        Me.AdLabelEx7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx7.Location = New System.Drawing.Point(6, 96)
        Me.AdLabelEx7.Name = "AdLabelEx7"
        Me.AdLabelEx7.Size = New System.Drawing.Size(348, 16)
        Me.AdLabelEx7.TabIndex = 22
        Me.AdLabelEx7.Text = "Zeichenabkürzungen: Bei langen Texten muss der Benutzer wissen, was abgekürzt ist" & _
            "!"
        Me.AdLabelEx7.TextTrimming = System.Drawing.StringTrimming.EllipsisCharacter
        '
        'AdLabelEx6
        '
        Me.AdLabelEx6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx6.Location = New System.Drawing.Point(6, 62)
        Me.AdLabelEx6.Name = "AdLabelEx6"
        Me.AdLabelEx6.Size = New System.Drawing.Size(348, 16)
        Me.AdLabelEx6.TabIndex = 21
        Me.AdLabelEx6.Text = "Wortabkürzungen: Bei langen Texten muss der Benutzer wissen, was abgekürzt ist!"
        Me.AdLabelEx6.TextTrimming = System.Drawing.StringTrimming.EllipsisWord
        '
        'AdLabelEx5
        '
        Me.AdLabelEx5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx5.Location = New System.Drawing.Point(6, 30)
        Me.AdLabelEx5.Name = "AdLabelEx5"
        Me.AdLabelEx5.Size = New System.Drawing.Size(348, 16)
        Me.AdLabelEx5.TabIndex = 20
        Me.AdLabelEx5.Text = "Dateinamen: C:\Windows\System32\Unterordner\LangerDateiname.txt"
        Me.AdLabelEx5.TextTrimming = System.Drawing.StringTrimming.EllipsisPath
        '
        'AdLabelExToFlash2
        '
        Me.AdLabelExToFlash2.AutoHeight = True
        Me.AdLabelExToFlash2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelExToFlash2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabelExToFlash2.Location = New System.Drawing.Point(21, 48)
        Me.AdLabelExToFlash2.Name = "AdLabelExToFlash2"
        Me.AdLabelExToFlash2.Size = New System.Drawing.Size(168, 41)
        Me.AdLabelExToFlash2.TabIndex = 20
        Me.AdLabelExToFlash2.Text = "Zentrierte Formatierung"
        Me.AdLabelExToFlash2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 332)
        Me.Controls.Add(Me.AdLabelExToFlash3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AdLabelEx8)
        Me.Controls.Add(Me.AdLabelExToFlash4)
        Me.Controls.Add(Me.AdLabelExToFlash2)
        Me.Controls.Add(Me.AdLabelExToFlash1)
        Me.Controls.Add(Me.btnFlashIt)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmMain"
        Me.Text = "ADLabelEx-Demo"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnFlashIt As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AdLabelExToFlash1 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelExToFlash4 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelEx5 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelEx7 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelEx6 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelEx8 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AdLabelExToFlash3 As ActiveDevelop.Controls.ADLabelEx
    Friend WithEvents AdLabelExToFlash2 As ActiveDevelop.Controls.ADLabelEx

End Class
