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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkWndProcMessages = New System.Windows.Forms.CheckBox
        Me.chkScrollBars = New System.Windows.Forms.CheckBox
        Me.chkKeyPreview = New System.Windows.Forms.CheckBox
        Me.chkTopMost = New System.Windows.Forms.CheckBox
        Me.chkShowInTaskbar = New System.Windows.Forms.CheckBox
        Me.chkMinMax = New System.Windows.Forms.CheckBox
        Me.chkHelpButton = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFormText = New System.Windows.Forms.TextBox
        Me.chkControlBox = New System.Windows.Forms.CheckBox
        Me.btnCreateWithTestControl = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkPreProcessing = New System.Windows.Forms.CheckBox
        Me.chkRepaintLayout = New System.Windows.Forms.CheckBox
        Me.chkFocussing = New System.Windows.Forms.CheckBox
        Me.chkPositioning = New System.Windows.Forms.CheckBox
        Me.chkKeyboard = New System.Windows.Forms.CheckBox
        Me.chkCreateDestroy = New System.Windows.Forms.CheckBox
        Me.chkMouse = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkSchaltfläche = New System.Windows.Forms.CheckBox
        Me.chkFormular = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkWndProcMessages)
        Me.GroupBox3.Controls.Add(Me.chkScrollBars)
        Me.GroupBox3.Controls.Add(Me.chkKeyPreview)
        Me.GroupBox3.Controls.Add(Me.chkTopMost)
        Me.GroupBox3.Controls.Add(Me.chkShowInTaskbar)
        Me.GroupBox3.Controls.Add(Me.chkMinMax)
        Me.GroupBox3.Controls.Add(Me.chkHelpButton)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtFormText)
        Me.GroupBox3.Controls.Add(Me.chkControlBox)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(268, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 296)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Einstellungen für das Testformular"
        '
        'chkWndProcMessages
        '
        Me.chkWndProcMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWndProcMessages.Location = New System.Drawing.Point(8, 264)
        Me.chkWndProcMessages.Name = "chkWndProcMessages"
        Me.chkWndProcMessages.Size = New System.Drawing.Size(200, 16)
        Me.chkWndProcMessages.TabIndex = 9
        Me.chkWndProcMessages.Text = "WndProc-Messages anzeigen"
        '
        'chkScrollBars
        '
        Me.chkScrollBars.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkScrollBars.Location = New System.Drawing.Point(8, 214)
        Me.chkScrollBars.Name = "chkScrollBars"
        Me.chkScrollBars.Size = New System.Drawing.Size(200, 44)
        Me.chkScrollBars.TabIndex = 8
        Me.chkScrollBars.Text = "Automatische Scrollbars (In diesem Fall andere TestControl- Positionierung im For" & _
            "mular)"
        '
        'chkKeyPreview
        '
        Me.chkKeyPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKeyPreview.Location = New System.Drawing.Point(8, 192)
        Me.chkKeyPreview.Name = "chkKeyPreview"
        Me.chkKeyPreview.Size = New System.Drawing.Size(200, 16)
        Me.chkKeyPreview.TabIndex = 7
        Me.chkKeyPreview.Text = "Vorschau auf Tastenverarbeitung"
        '
        'chkTopMost
        '
        Me.chkTopMost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTopMost.Location = New System.Drawing.Point(8, 168)
        Me.chkTopMost.Name = "chkTopMost"
        Me.chkTopMost.Size = New System.Drawing.Size(200, 16)
        Me.chkTopMost.TabIndex = 6
        Me.chkTopMost.Text = "Immer im Vordergrund (TopMost)"
        '
        'chkShowInTaskbar
        '
        Me.chkShowInTaskbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowInTaskbar.Location = New System.Drawing.Point(8, 144)
        Me.chkShowInTaskbar.Name = "chkShowInTaskbar"
        Me.chkShowInTaskbar.Size = New System.Drawing.Size(200, 16)
        Me.chkShowInTaskbar.TabIndex = 5
        Me.chkShowInTaskbar.Text = "In Taskbar anzeigen"
        '
        'chkMinMax
        '
        Me.chkMinMax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMinMax.Location = New System.Drawing.Point(8, 120)
        Me.chkMinMax.Name = "chkMinMax"
        Me.chkMinMax.Size = New System.Drawing.Size(200, 16)
        Me.chkMinMax.TabIndex = 4
        Me.chkMinMax.Text = "Minimize/Maximize"
        '
        'chkHelpButton
        '
        Me.chkHelpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkHelpButton.Location = New System.Drawing.Point(8, 96)
        Me.chkHelpButton.Name = "chkHelpButton"
        Me.chkHelpButton.Size = New System.Drawing.Size(200, 16)
        Me.chkHelpButton.TabIndex = 3
        Me.chkHelpButton.Text = "HelpButton"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Text (Überschrift)"
        '
        'txtFormText
        '
        Me.txtFormText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormText.Location = New System.Drawing.Point(8, 40)
        Me.txtFormText.Name = "txtFormText"
        Me.txtFormText.Size = New System.Drawing.Size(200, 20)
        Me.txtFormText.TabIndex = 1
        Me.txtFormText.Text = "TestForm1"
        '
        'chkControlBox
        '
        Me.chkControlBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkControlBox.Location = New System.Drawing.Point(8, 72)
        Me.chkControlBox.Name = "chkControlBox"
        Me.chkControlBox.Size = New System.Drawing.Size(200, 16)
        Me.chkControlBox.TabIndex = 0
        Me.chkControlBox.Text = "ControlBox"
        '
        'btnCreateWithTestControl
        '
        Me.btnCreateWithTestControl.Location = New System.Drawing.Point(148, 324)
        Me.btnCreateWithTestControl.Name = "btnCreateWithTestControl"
        Me.btnCreateWithTestControl.Size = New System.Drawing.Size(200, 32)
        Me.btnCreateWithTestControl.TabIndex = 6
        Me.btnCreateWithTestControl.Text = "Testform mit TestControl erzeugen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkPreProcessing)
        Me.GroupBox1.Controls.Add(Me.chkRepaintLayout)
        Me.GroupBox1.Controls.Add(Me.chkFocussing)
        Me.GroupBox1.Controls.Add(Me.chkPositioning)
        Me.GroupBox1.Controls.Add(Me.chkKeyboard)
        Me.GroupBox1.Controls.Add(Me.chkCreateDestroy)
        Me.GroupBox1.Controls.Add(Me.chkMouse)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 208)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Testeinstellungen für Ereignisse:"
        '
        'chkPreProcessing
        '
        Me.chkPreProcessing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPreProcessing.Location = New System.Drawing.Point(16, 168)
        Me.chkPreProcessing.Name = "chkPreProcessing"
        Me.chkPreProcessing.Size = New System.Drawing.Size(216, 32)
        Me.chkPreProcessing.TabIndex = 6
        Me.chkPreProcessing.Text = "Tastatur-Nachrichten-Vorverar- beitungsnachrichten anzeigen"
        '
        'chkRepaintLayout
        '
        Me.chkRepaintLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRepaintLayout.Location = New System.Drawing.Point(16, 120)
        Me.chkRepaintLayout.Name = "chkRepaintLayout"
        Me.chkRepaintLayout.Size = New System.Drawing.Size(216, 16)
        Me.chkRepaintLayout.TabIndex = 5
        Me.chkRepaintLayout.Text = "Repaint/Layout-Ereignisse anzeigen"
        '
        'chkFocussing
        '
        Me.chkFocussing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFocussing.Location = New System.Drawing.Point(16, 144)
        Me.chkFocussing.Name = "chkFocussing"
        Me.chkFocussing.Size = New System.Drawing.Size(216, 16)
        Me.chkFocussing.TabIndex = 4
        Me.chkFocussing.Text = "Fokussierungs-Ereignisse anzeigen"
        '
        'chkPositioning
        '
        Me.chkPositioning.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPositioning.Location = New System.Drawing.Point(16, 96)
        Me.chkPositioning.Name = "chkPositioning"
        Me.chkPositioning.Size = New System.Drawing.Size(216, 16)
        Me.chkPositioning.TabIndex = 3
        Me.chkPositioning.Text = "Positionierungs-Ereignisse anzeigen"
        '
        'chkKeyboard
        '
        Me.chkKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkKeyboard.Location = New System.Drawing.Point(16, 72)
        Me.chkKeyboard.Name = "chkKeyboard"
        Me.chkKeyboard.Size = New System.Drawing.Size(216, 16)
        Me.chkKeyboard.TabIndex = 2
        Me.chkKeyboard.Text = "Keyboard-Ereignisse anzeigen"
        '
        'chkCreateDestroy
        '
        Me.chkCreateDestroy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCreateDestroy.Location = New System.Drawing.Point(16, 24)
        Me.chkCreateDestroy.Name = "chkCreateDestroy"
        Me.chkCreateDestroy.Size = New System.Drawing.Size(216, 16)
        Me.chkCreateDestroy.TabIndex = 1
        Me.chkCreateDestroy.Text = "Create/Destroy-Ereignisse anzeigen"
        '
        'chkMouse
        '
        Me.chkMouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMouse.Location = New System.Drawing.Point(16, 48)
        Me.chkMouse.Name = "chkMouse"
        Me.chkMouse.Size = New System.Drawing.Size(216, 16)
        Me.chkMouse.TabIndex = 0
        Me.chkMouse.Text = "Mouse-Ereignisse anzeigen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSchaltfläche)
        Me.GroupBox2.Controls.Add(Me.chkFormular)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 228)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 80)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ereigniseinstellung gültig für:"
        '
        'chkSchaltfläche
        '
        Me.chkSchaltfläche.Checked = True
        Me.chkSchaltfläche.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSchaltfläche.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSchaltfläche.Location = New System.Drawing.Point(32, 48)
        Me.chkSchaltfläche.Name = "chkSchaltfläche"
        Me.chkSchaltfläche.Size = New System.Drawing.Size(136, 16)
        Me.chkSchaltfläche.TabIndex = 1
        Me.chkSchaltfläche.Text = "Test-Komponente"
        '
        'chkFormular
        '
        Me.chkFormular.Checked = True
        Me.chkFormular.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFormular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFormular.Location = New System.Drawing.Point(32, 24)
        Me.chkFormular.Name = "chkFormular"
        Me.chkFormular.Size = New System.Drawing.Size(136, 16)
        Me.chkFormular.TabIndex = 0
        Me.chkFormular.Text = "Formular"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 368)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCreateWithTestControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmMain"
        Me.Text = "Ereignistester"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkWndProcMessages As System.Windows.Forms.CheckBox
    Friend WithEvents chkScrollBars As System.Windows.Forms.CheckBox
    Friend WithEvents chkKeyPreview As System.Windows.Forms.CheckBox
    Friend WithEvents chkTopMost As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowInTaskbar As System.Windows.Forms.CheckBox
    Friend WithEvents chkMinMax As System.Windows.Forms.CheckBox
    Friend WithEvents chkHelpButton As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFormText As System.Windows.Forms.TextBox
    Friend WithEvents chkControlBox As System.Windows.Forms.CheckBox
    Friend WithEvents btnCreateWithTestControl As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPreProcessing As System.Windows.Forms.CheckBox
    Friend WithEvents chkRepaintLayout As System.Windows.Forms.CheckBox
    Friend WithEvents chkFocussing As System.Windows.Forms.CheckBox
    Friend WithEvents chkPositioning As System.Windows.Forms.CheckBox
    Friend WithEvents chkKeyboard As System.Windows.Forms.CheckBox
    Friend WithEvents chkCreateDestroy As System.Windows.Forms.CheckBox
    Friend WithEvents chkMouse As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkSchaltfläche As System.Windows.Forms.CheckBox
    Friend WithEvents chkFormular As System.Windows.Forms.CheckBox

End Class
