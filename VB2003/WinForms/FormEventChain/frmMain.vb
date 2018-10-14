Public Class frmMain
    Inherits System.Windows.Forms.Form


#Region " Vom Windows Form Designer generierter Code "

        Public Sub New()
            MyBase.New()

            ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
            InitializeComponent()
            'Application.AddMessageFilter(New frmMainMessageFilter)

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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents chkMouse As System.Windows.Forms.CheckBox
        Friend WithEvents chkCreateDestroy As System.Windows.Forms.CheckBox
        Friend WithEvents chkKeyboard As System.Windows.Forms.CheckBox
        Friend WithEvents chkPositioning As System.Windows.Forms.CheckBox
        Friend WithEvents chkFocussing As System.Windows.Forms.CheckBox
        Friend WithEvents btnCreateWithTestControl As System.Windows.Forms.Button
        Friend WithEvents chkRepaintLayout As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents chkFormular As System.Windows.Forms.CheckBox
        Friend WithEvents chkSchaltfläche As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents chkControlBox As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents chkHelpButton As System.Windows.Forms.CheckBox
        Friend WithEvents chkMinMax As System.Windows.Forms.CheckBox
        Friend WithEvents chkTopMost As System.Windows.Forms.CheckBox
        Friend WithEvents chkKeyPreview As System.Windows.Forms.CheckBox
        Friend WithEvents chkScrollBars As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowInTaskbar As System.Windows.Forms.CheckBox
        Friend WithEvents txtFormText As System.Windows.Forms.TextBox
        Friend WithEvents chkPreProcessing As System.Windows.Forms.CheckBox
    Friend WithEvents chkWndProcMessages As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkPreProcessing = New System.Windows.Forms.CheckBox
        Me.chkRepaintLayout = New System.Windows.Forms.CheckBox
        Me.chkFocussing = New System.Windows.Forms.CheckBox
        Me.chkPositioning = New System.Windows.Forms.CheckBox
        Me.chkKeyboard = New System.Windows.Forms.CheckBox
        Me.chkCreateDestroy = New System.Windows.Forms.CheckBox
        Me.chkMouse = New System.Windows.Forms.CheckBox
        Me.btnCreateWithTestControl = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkSchaltfläche = New System.Windows.Forms.CheckBox
        Me.chkFormular = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkScrollBars = New System.Windows.Forms.CheckBox
        Me.chkKeyPreview = New System.Windows.Forms.CheckBox
        Me.chkTopMost = New System.Windows.Forms.CheckBox
        Me.chkShowInTaskbar = New System.Windows.Forms.CheckBox
        Me.chkMinMax = New System.Windows.Forms.CheckBox
        Me.chkHelpButton = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFormText = New System.Windows.Forms.TextBox
        Me.chkControlBox = New System.Windows.Forms.CheckBox
        Me.chkWndProcMessages = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 208)
        Me.GroupBox1.TabIndex = 0
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
        'btnCreateWithTestControl
        '
        Me.btnCreateWithTestControl.Location = New System.Drawing.Point(144, 328)
        Me.btnCreateWithTestControl.Name = "btnCreateWithTestControl"
        Me.btnCreateWithTestControl.Size = New System.Drawing.Size(200, 32)
        Me.btnCreateWithTestControl.TabIndex = 1
        Me.btnCreateWithTestControl.Text = "Testform mit TestControl erzeugen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkSchaltfläche)
        Me.GroupBox2.Controls.Add(Me.chkFormular)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 232)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(248, 80)
        Me.GroupBox2.TabIndex = 3
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
        Me.GroupBox3.Location = New System.Drawing.Point(264, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 296)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Einstellungen für das Testformular"
        '
        'chkScrollBars
        '
        Me.chkScrollBars.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkScrollBars.Location = New System.Drawing.Point(8, 208)
        Me.chkScrollBars.Name = "chkScrollBars"
        Me.chkScrollBars.Size = New System.Drawing.Size(200, 40)
        Me.chkScrollBars.TabIndex = 8
        Me.chkScrollBars.Text = "Automatische Scrollbars (In diesem Fall andere TestControl-Positionierung im Form" & _
        "ular)"
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
        'chkWndProcMessages
        '
        Me.chkWndProcMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkWndProcMessages.Location = New System.Drawing.Point(8, 264)
        Me.chkWndProcMessages.Name = "chkWndProcMessages"
        Me.chkWndProcMessages.Size = New System.Drawing.Size(200, 16)
        Me.chkWndProcMessages.TabIndex = 9
        Me.chkWndProcMessages.Text = "WndProc-Messages anzeigen"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 374)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCreateWithTestControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmMain"
        Me.Text = "Formular und Control-Tester"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCreateWithTestControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                Handles btnCreateWithTestControl.Click
        Dim locfrmTest As frmTest
        Dim locTestControl As TestControl
        Dim locButton As Button

        'Einstellungen gelten für das Formular...
        If chkFormular.Checked Then
            locfrmTest = New frmTest( _
                        chkCreateDestroy.Checked, chkMouse.Checked, chkKeyboard.Checked, _
                     chkPositioning.Checked, chkRepaintLayout.Checked, chkFocussing.Checked, _
                     chkPreProcessing.Checked, chkWndProcMessages.Checked)
        Else
            locfrmTest = New frmTest
        End If

        '...und/oder für die TestButton-Komponente
        If chkSchaltfläche.Checked Then
            locTestControl = New TestControl( _
                        chkCreateDestroy.Checked, chkMouse.Checked, chkKeyboard.Checked, _
                     chkPositioning.Checked, chkRepaintLayout.Checked, chkFocussing.Checked, _
                     chkPreProcessing.Checked)
        Else
            locTestControl = New TestControl
        End If

        'Einstellungen für das Formular durchführen

        'Das Formular hat ein Viertel der Bildschirmgröße
        'und soll in der Bildschirmmitte des primären Bildschirms erscheinen
        Dim locBounds As Rectangle = Screen.PrimaryScreen.Bounds
        locfrmTest.Width = locBounds.Width \ 4
        locfrmTest.Height = locBounds.Height \ 4
        locfrmTest.StartPosition = FormStartPosition.CenterScreen
        locfrmTest.Text = txtFormText.Text

        'Einstellungen entsprechend der CheckBox-Controls im Formular
        locfrmTest.ControlBox = chkControlBox.Checked
        locfrmTest.MinimizeBox = chkMinMax.Checked
        locfrmTest.MaximizeBox = chkMinMax.Checked
        locfrmTest.HelpButton = chkHelpButton.Checked
        locfrmTest.ShowInTaskbar = chkShowInTaskbar.Checked
        locfrmTest.TopMost = chkTopMost.Checked
        locfrmTest.KeyPreview = chkKeyPreview.Checked
        locfrmTest.AutoScroll = chkScrollBars.Checked

        'TestControl mittig und im obeneren Drittel Formular platzieren 
        '- nicht zu klein oder zu groß
        locTestControl.Width = CInt(locfrmTest.ClientSize.Width / 2)
        locTestControl.Height = CInt(locfrmTest.ClientSize.Height / 3)
        locTestControl.Location = _
                New Point(CInt(locfrmTest.ClientSize.Width / 2 - locTestControl.Width / 2), _
                          CInt(locfrmTest.ClientSize.Height / 3 - locTestControl.Height / 2))

        'TestControl verankern, wenn die AutoScroll-Funktion des Formulars nicht gewünscht wird
        If Not chkScrollBars.Checked Then
            locTestControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or _
                                     AnchorStyles.Left Or AnchorStyles.Right
        End If

        'Schließschaltfläche im unteren Drittel positionieren
        locButton = New Button
        locButton.Width = CInt(locfrmTest.ClientSize.Width / 3)
        locButton.Height = CInt(locfrmTest.Height / 6)
        locButton.Location = _
                New Point(CInt(locfrmTest.ClientSize.Width / 2 - locButton.Width / 2), _
                          CInt(locfrmTest.ClientSize.Height / 4 * 3 - locButton.Height / 2))

        locButton.Text = "Formular &schließen"
        'Schließschaltfläche verankern, wenn die AutoScroll-Funktion des Formulars nicht gewünscht wird
        If Not chkScrollBars.Checked Then
            locButton.Anchor = AnchorStyles.Bottom Or _
                                     AnchorStyles.Left Or AnchorStyles.Right
        End If

        'Return und Escape lösen Click-Ereignis des Buttons aus
        Me.AcceptButton = locButton
        Me.CancelButton = locButton

        'Zur Laufzeit einstellen, dass das Click-Ereignis der Schließschaltfläche 
        'von TestButton-Click behandelt wird
        AddHandler locButton.Click, AddressOf TestButton_Click

        'Beide Controls der Formular-ControlCollection hinzufügen;
        'damit werden die beiden Komponenten windowstechnisch angelegt und dargestellt
        locfrmTest.Controls.Add(locTestControl)
        locfrmTest.Controls.Add(locButton)

        locfrmTest.Show()
    End Sub

    'Ereignis-Routine des Buttons; wird zur Laufzeit eingebunden (s.o.)
    Sub TestButton_Click(ByVal Sender As Object, ByVal e As EventArgs)

        Dim locButton As Button

        'Könnte schief gehen, wenn Sender nicht die Schaltfläche ist,
        'deswegen sichergehen durch Try/Catch
        Try
            'Das sendende Objekt herausfinden
            locButton = DirectCast(Sender, Button)
        Catch ex As Exception
            Return
        End Try
        'Sendende Objekt war der Button selbst, dann dessen Parent (das Formular) entsorgen.
        'Damit wird das Formular, das den Button enthält, geschlossen.
        locButton.Parent.Dispose()
    End Sub

End Class


