Public Class ADFormWizardTemplate
    Inherits System.Windows.Forms.Form
    'Vorschriften für Assistenten-Funktionen implementieren
    Implements IADWizard

    Protected myLastStep As Boolean = False
    Protected myFirstStep As Boolean = False
    Protected myStepNo As Integer = 0
    Protected myWizardDialogResult As WizardDialogResult = wizardDialogResult.Cancel
    Protected propertyBag As Hashtable
    Protected myInstanceToHide As IADWizard
    Protected myShown As Boolean

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
    Protected WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Protected WithEvents panel1 As System.Windows.Forms.Panel
    Protected WithEvents btnCancel As System.Windows.Forms.Button
    Protected WithEvents btnNext As System.Windows.Forms.Button
    Protected WithEvents btnPrev As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnPrev = New System.Windows.Forms.Button
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.groupBox1.Location = New System.Drawing.Point(0, 0)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(504, 118)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Location = New System.Drawing.Point(0, 112)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(504, 217)
        Me.groupBox2.TabIndex = 5
        Me.groupBox2.TabStop = False
        '
        'panel1
        '
        Me.panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.Controls.Add(Me.btnCancel)
        Me.panel1.Controls.Add(Me.btnNext)
        Me.panel1.Controls.Add(Me.btnPrev)
        Me.panel1.Location = New System.Drawing.Point(216, 336)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(289, 47)
        Me.panel1.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(196, 9)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 28)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Abbrechen"
        '
        'btnNext
        '
        Me.btnNext.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnNext.Location = New System.Drawing.Point(93, 9)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(85, 28)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Weiter >"
        '
        'btnPrev
        '
        Me.btnPrev.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrev.Location = New System.Drawing.Point(9, 9)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(84, 28)
        Me.btnPrev.TabIndex = 6
        Me.btnPrev.Text = "< Zurück"
        '
        'ADFormWizardTemplate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 390)
        Me.ControlBox = False
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.groupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ADFormWizardTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Event DifferentWizardStep(ByVal sender As Object, ByVal e As DifferentWizardStepEventArgs) _
                                    Implements IADWizard.DifferentWizardStep

    'Kümmert sich um die Eigenschaft FirstStep;
    'sie hat nicht nur informative Funktion, sondern
    'bestimmt auch das Ein-/Ausschalten
    'der Zurück-Schaltfläche.
    Public Overridable Property FirstStep() As Boolean Implements IADWizard.FirstStep

        Get
            Return myFirstStep
        End Get

        Set(ByVal Value As Boolean)
            myFirstStep = Value
            If Value Then
                btnPrev.Enabled = False
            Else
                btnPrev.Enabled = True
            End If
        End Set
    End Property

    'Kümmert sich um die Eigenschaft FirstStep;
    'sie hat nicht nur informative Funktion, sondern
    'bestimmt auch die Beschriftung
    'der Weiter/Fertig-Schaltfläche.
    Public Overridable Property LastStep() As Boolean Implements IADWizard.LastStep
        Get
            Return myLastStep
        End Get
        Set(ByVal Value As Boolean)
            myLastStep = Value
            If Value Then
                btnNext.Text = "Fertig!"
            Else
                btnNext.Text = "Weiter >"
            End If
        End Set
    End Property

    'Setzt Überschrift und Schrittnummer im Formular-Titel
    Public Overridable Sub SetWizardProperties(ByVal DialogCaption As String, ByVal StepNo As Integer) Implements IADWizard.SetWizardProperties
        myStepNo = StepNo
        Me.Text = DialogCaption
    End Sub

    'Setzt oder ermittelt die aktuelle Schrittnummer
    Public Overridable Property StepNo() As Integer Implements IADWizard.StepNo
        Get
            Return myStepNo
        End Get
        Set(ByVal Value As Integer)
            myStepNo = Value
        End Set
    End Property

    'Behandelt die Zurück-Schaltfläche und löst das Ereignis aus.
    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim locDiffWizStepEventArgs As DifferentWizardStepEventArgs

        myWizardDialogResult = WizardDialogResult.Previous
        locDiffWizStepEventArgs = New DifferentWizardStepEventArgs(myWizardDialogResult, Me.StepNo, False)
        'Ereignis auslösen.
        OnDifferentWizardStep(locDiffWizStepEventArgs)

        'Falls der Empfänger den Schrittwechsel nicht abgebrochen hat...
        If Not locDiffWizStepEventArgs.Cancel Then
            'Dialog schließen
            Me.Hide()
        End If

    End Sub

    'Macht prinzipiell das gleiche wie btn_Previous_Click
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim locDiffWizStepEventArgs As DifferentWizardStepEventArgs

        If Me.LastStep Then
            myWizardDialogResult = WizardDialogResult.OK
        Else
            myWizardDialogResult = WizardDialogResult.Next
        End If

        locDiffWizStepEventArgs = New DifferentWizardStepEventArgs(myWizardDialogResult, Me.StepNo, False)
        OnDifferentWizardStep(locDiffWizStepEventArgs)

        If Not locDiffWizStepEventArgs.Cancel Then
            Me.Hide()
        End If
    End Sub

    'Das Selbe hier.
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Dim locDiffWizStepEventArgs As DifferentWizardStepEventArgs

        myWizardDialogResult = WizardDialogResult.Cancel
        locDiffWizStepEventArgs = New DifferentWizardStepEventArgs(myWizardDialogResult, Me.StepNo, False)
        OnDifferentWizardStep(locDiffWizStepEventArgs)

        If Not locDiffWizStepEventArgs.Cancel Then
            Me.Hide()
        End If
    End Sub

    'Löst das eigentliche Ereignis aus, damit einbindende Klassen "mithören" können.
    Public Overridable Sub OnDifferentWizardStep(ByVal e As DifferentWizardStepEventArgs)
        RaiseEvent DifferentWizardStep(Me, e)
    End Sub

    'Bindet die TopMost-Eigenschaft der Schnittstelle ein.
    'Da TopMost der Basisklasse Form nicht als overridable markiert ist,
    'muss der Eigenschaftenname ein anderer sein.
    Public Property IADWizardTopMost() As Boolean Implements IADWizard.TopMost
        Get
            Return Me.TopMost
        End Get
        Set(ByVal Value As Boolean)
            Me.TopMost = Value
        End Set
    End Property

    'Bindet die Hide-Methode der Schnittstelle ein.
    'Da Hide der Basisklasse Form nicht als overridable markiert ist,
    'muss der Methodenname ein anderer sein.
    Public Sub IADWizardHide() Implements IADWizard.Hide
        myShown = False
        Me.Hide()
    End Sub

    'Bindet die Show-Methode der Schnittstelle ein.
    'Da Show der Basisklasse Form nicht als overridable markiert ist,
    'muss der Methodenname ein anderer sein.
    'Sie sorgt zusätzlich mit Refresh dafür, dass das Formular vollständig
    'dargestellt wird.
    Public Sub IADWizardShow() Implements IADWizard.Show
        myShown = True
        Me.Show()
        Me.Refresh()
    End Sub

    'Stellt den Dialog modal dar. Damit bekommt er eine eigene Ereignis-Warteschlange.
    Public Overridable Function ShowWDialog() As WizardDialogResult Implements IADWizard.ShowWDialog
        Me.ShowDialog()
        Return myWizardDialogResult
    End Function

    'Überladene Routine, der eine IADWizard-Instanz übergeben wird.
    'Dies ist notwendig, damit diese Instanz in OnPaint die Instanz,
    'die zum Vermeiden des Flimmerns dargestellt wird, wieder vom
    'Bildschirm entfernen kann.
    Public Overloads Function ShowWDialogOverloads(ByVal InstanceToHide As IADWizard) As WizardDialogResult Implements IADWizard.ShowWDialog
        myInstanceToHide = InstanceToHide
        Return Me.ShowWDialog
    End Function

    'Ermittelt, ob das Formular nicht-modal dargestellt wird, oder nicht.
    '(Wird durch IADWizard.Hide und IADWizard.Show gesteuert).
    Public ReadOnly Property Shown() As Boolean Implements IADWizard.Shown
        Get
            Return myShown
        End Get
    End Property

    'Wird überschrieben, damit eine unter dem Formular aus "Flimmergründen" liegende
    'IADWizard-Instanz (in diesem Beispiel immer die Basis-Klasse ADFormWizardTemplate)
    'wieder entfernt werden kann. Zu diesem Zeitpunkt verdeckt das Formular vollständig
    'den Hintergrund, so dass der Hilfsuntergrund (das Basis-Formular) nicht mehr benötigt wird.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Me.TopMost = False
        If Not (myInstanceToHide Is Nothing) Then
            If myInstanceToHide.Shown Then
                myInstanceToHide.Hide()
            End If
        End If

    End Sub

    'ACHTUNG, Nachträglich ergänzt:
    'Owner eines Forms muss setzbar sein, damit alle Fenster über dem aufrufenden liegen;
    'Sonst flimmert der Assistent an sich zwar nicht, aber das Haupt-Fenster "scheint" beim
    'Schrittwechsel durch.
    Public Property IDWizardOwner() As System.Windows.Forms.Form Implements IADWizard.Owner
        Get
            Return Me.Owner
        End Get
        Set(ByVal Value As System.Windows.Forms.Form)
            Me.Owner = Value
        End Set
    End Property
End Class
