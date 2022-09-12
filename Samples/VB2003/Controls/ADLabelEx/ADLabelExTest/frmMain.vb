Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents AdLabelEx1 As ActiveDev.ADLabelEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AdLabelEx2 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelEx3 As ActiveDev.ADLabelEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents AdLabelExToFlash2 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelExToFlash3 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelExToFlash1 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelEx7 As ActiveDev.ADLabelEx
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AdLabelEx8 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelEx9 As ActiveDev.ADLabelEx
    Friend WithEvents AdLabelEx10 As ActiveDev.ADLabelEx
    Friend WithEvents btnFlashIt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.AdLabelEx1 = New ActiveDev.ADLabelEx
        Me.Label1 = New System.Windows.Forms.Label
        Me.AdLabelEx2 = New ActiveDev.ADLabelEx
        Me.AdLabelEx3 = New ActiveDev.ADLabelEx
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.AdLabelExToFlash2 = New ActiveDev.ADLabelEx
        Me.AdLabelExToFlash3 = New ActiveDev.ADLabelEx
        Me.AdLabelExToFlash1 = New ActiveDev.ADLabelEx
        Me.AdLabelEx7 = New ActiveDev.ADLabelEx
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AdLabelEx10 = New ActiveDev.ADLabelEx
        Me.AdLabelEx9 = New ActiveDev.ADLabelEx
        Me.AdLabelEx8 = New ActiveDev.ADLabelEx
        Me.btnFlashIt = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdLabelEx1
        '
        Me.AdLabelEx1.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelEx1.Location = New System.Drawing.Point(16, 32)
        Me.AdLabelEx1.Name = "AdLabelEx1"
        Me.AdLabelEx1.Size = New System.Drawing.Size(168, 16)
        Me.AdLabelEx1.TabIndex = 0
        Me.AdLabelEx1.Text = "rechtsbündige Beschriftungen:"
        Me.AdLabelEx1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(208, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "rechtsbündige Beschriftungen:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdLabelEx2
        '
        Me.AdLabelEx2.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelEx2.Location = New System.Drawing.Point(16, 56)
        Me.AdLabelEx2.Name = "AdLabelEx2"
        Me.AdLabelEx2.Size = New System.Drawing.Size(168, 16)
        Me.AdLabelEx2.TabIndex = 2
        Me.AdLabelEx2.Text = "sauber untereinander:"
        Me.AdLabelEx2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdLabelEx3
        '
        Me.AdLabelEx3.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelEx3.Location = New System.Drawing.Point(16, 80)
        Me.AdLabelEx3.Name = "AdLabelEx3"
        Me.AdLabelEx3.Size = New System.Drawing.Size(168, 16)
        Me.AdLabelEx3.TabIndex = 3
        Me.AdLabelEx3.Text = "kann nur:"
        Me.AdLabelEx3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(208, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "sauber untereinander:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(208, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "kann das:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(208, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "normale Label nicht!"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdLabelExToFlash2
        '
        Me.AdLabelExToFlash2.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelExToFlash2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AdLabelExToFlash2.Location = New System.Drawing.Point(16, 104)
        Me.AdLabelExToFlash2.Name = "AdLabelExToFlash2"
        Me.AdLabelExToFlash2.Size = New System.Drawing.Size(168, 16)
        Me.AdLabelExToFlash2.TabIndex = 7
        Me.AdLabelExToFlash2.Text = "ADLabelEx!!!"
        Me.AdLabelExToFlash2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AdLabelExToFlash3
        '
        Me.AdLabelExToFlash3.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelExToFlash3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelExToFlash3.DirectionVertical = True
        Me.AdLabelExToFlash3.FlashBackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.AdLabelExToFlash3.FlashForeColor = System.Drawing.Color.Yellow
        Me.AdLabelExToFlash3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabelExToFlash3.Location = New System.Drawing.Point(392, 8)
        Me.AdLabelExToFlash3.Name = "AdLabelExToFlash3"
        Me.AdLabelExToFlash3.Size = New System.Drawing.Size(48, 304)
        Me.AdLabelExToFlash3.TabIndex = 8
        Me.AdLabelExToFlash3.Text = "Copyright (c) 2004 www.loeffelmann.de"
        Me.AdLabelExToFlash3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdLabelExToFlash1
        '
        Me.AdLabelExToFlash1.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelExToFlash1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabelExToFlash1.Location = New System.Drawing.Point(56, 8)
        Me.AdLabelExToFlash1.Name = "AdLabelExToFlash1"
        Me.AdLabelExToFlash1.Size = New System.Drawing.Size(104, 16)
        Me.AdLabelExToFlash1.TabIndex = 9
        Me.AdLabelExToFlash1.Text = "AdLabelEx:"
        Me.AdLabelExToFlash1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AdLabelEx7
        '
        Me.AdLabelEx7.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AdLabelEx7.Location = New System.Drawing.Point(240, 8)
        Me.AdLabelEx7.Name = "AdLabelEx7"
        Me.AdLabelEx7.Size = New System.Drawing.Size(104, 16)
        Me.AdLabelEx7.TabIndex = 10
        Me.AdLabelEx7.Text = "Label:"
        Me.AdLabelEx7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AdLabelEx10)
        Me.GroupBox1.Controls.Add(Me.AdLabelEx9)
        Me.GroupBox1.Controls.Add(Me.AdLabelEx8)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 128)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Automatische Abkürzungen:"
        '
        'AdLabelEx10
        '
        Me.AdLabelEx10.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx10.Location = New System.Drawing.Point(16, 96)
        Me.AdLabelEx10.Name = "AdLabelEx10"
        Me.AdLabelEx10.Size = New System.Drawing.Size(328, 16)
        Me.AdLabelEx10.TabIndex = 2
        Me.AdLabelEx10.Text = "Zeichenabkürzungen: Bei langen Texten muss der Benutzer wissen, was abgekürzt ist" & _
        "!"
        Me.AdLabelEx10.TextTrimming = System.Drawing.StringTrimming.EllipsisCharacter
        Me.AdLabelEx10.TextWrap = False
        '
        'AdLabelEx9
        '
        Me.AdLabelEx9.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx9.Location = New System.Drawing.Point(16, 64)
        Me.AdLabelEx9.Name = "AdLabelEx9"
        Me.AdLabelEx9.Size = New System.Drawing.Size(328, 16)
        Me.AdLabelEx9.TabIndex = 1
        Me.AdLabelEx9.Text = "Wortabkürzungen: Bei langen Texten muss der Benutzer wissen, was abgekürzt ist!"
        Me.AdLabelEx9.TextTrimming = System.Drawing.StringTrimming.EllipsisWord
        Me.AdLabelEx9.TextWrap = False
        '
        'AdLabelEx8
        '
        Me.AdLabelEx8.BackColor = System.Drawing.SystemColors.Control
        Me.AdLabelEx8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AdLabelEx8.Location = New System.Drawing.Point(16, 32)
        Me.AdLabelEx8.Name = "AdLabelEx8"
        Me.AdLabelEx8.Size = New System.Drawing.Size(328, 16)
        Me.AdLabelEx8.TabIndex = 0
        Me.AdLabelEx8.Text = "Dateinamen: C:\Windows\System32\Unterordner\LangerDateiname.txt"
        Me.AdLabelEx8.TextTrimming = System.Drawing.StringTrimming.EllipsisPath
        Me.AdLabelEx8.TextWrap = False
        '
        'btnFlashIt
        '
        Me.btnFlashIt.Location = New System.Drawing.Point(16, 288)
        Me.btnFlashIt.Name = "btnFlashIt"
        Me.btnFlashIt.Size = New System.Drawing.Size(360, 24)
        Me.btnFlashIt.TabIndex = 12
        Me.btnFlashIt.Text = "Und das kann das Label schonmal gar nicht!"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(450, 328)
        Me.Controls.Add(Me.btnFlashIt)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AdLabelEx7)
        Me.Controls.Add(Me.AdLabelExToFlash1)
        Me.Controls.Add(Me.AdLabelExToFlash3)
        Me.Controls.Add(Me.AdLabelExToFlash2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.AdLabelEx3)
        Me.Controls.Add(Me.AdLabelEx2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.AdLabelEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMain"
        Me.Text = "ADLabelEx-Demo"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnFlashIt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlashIt.Click

        AdLabelExToFlash1.Flash = Not AdLabelExToFlash1.Flash
        AdLabelExToFlash2.Flash = Not AdLabelExToFlash2.Flash
        AdLabelExToFlash3.Flash = Not AdLabelExToFlash3.Flash
    End Sub

End Class
