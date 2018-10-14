Public Enum WizardDialogResult
    Cancel
    OK
    Previous
    [Next]
End Enum

Public Interface IADWizard

    'Methoden, die ein Wizard-Formular implementieren muss:

    'Dialog darstellen
    Function ShowWDialog() As WizardDialogResult
    'Diese zweite Version wird benötigt, damit die Instanz, die dargestellt wird
    'dafür sorgen kann, dass eine zweite Instanz, die "unter" ihr liegt,
    'wieder verschwindet (siehe folgende, längere Erklärung).
    Function ShowWDialog(ByVal InstanceToHide As IADWizard) As WizardDialogResult

    'Spezielle Wizard-Einstellungen durchführen
    Sub SetWizardProperties(ByVal DialogCaption As String, ByVal StepNo As Integer)

    'Ist es der erste Schritt?
    Property FirstStep() As Boolean
    'Ist es der letzte Schritt?
    Property LastStep() As Boolean
    'Die aktuelle Schrittnummer
    Property StepNo() As Integer
    'ACHTUNG, Nachträglich ergänzt:
    'Owner eines Forms muss setzbar sein, damit alle Fenster über dem aufrufenden liegen;
    'Sonst flimmert der Assistent an sich zwar nicht, aber das Haupt-Fenster "scheint" beim
    'Schrittwechsel durch.
    Property Owner() As Form

    'Die folgenden Eigenschaften und Methoden dienen dazu,
    'das Flimmern an sich beim Schrittwechsel zu verhindern.
    'Der Basisdialog wird dabei vor dem Wechsel
    '"unter" den aktuell angezeigten Dialog geschoben,
    'damit flimmert der Desktop-Hintergrund nicht durch,
    'da der Basisdialog - bis auf die zusätzlichen Elemente der
    'individuellen Schritte - genau so aussieht, wie jeder Schritt-Dialog.

    'Einbindene Klasse muss dafür sorgen können,
    'dass ihr visuelles Equivalent ganz zuoberst liegen kann
    Property TopMost() As Boolean
    'Einbindende Klasse muss dafür sorgen können,
    'dass ihr visuelles Equivalent "verschwinden" kann
    Sub Hide()
    'Einbindende Klasse muss dafür sorgen können,
    'dass ihr visuelles Equivalent dargestellt werden kann,
    '*ohne* die Programmsteuerung an sich zu reißen
    'Die Show-Methode muss die Shown-Eigenschaft setzen,
    'Die Hide-Methode muss die Shown-Eigenschaft löschen!
    Sub Show()
    ReadOnly Property Shown() As Boolean

    'Ereignisse
    'Wird ausgelöst, wenn ein neuer Schritt nach
    'vorne oder zurück durchgeführt wurde
    Event DifferentWizardStep(ByVal sender As Object, ByVal e As DifferentWizardStepEventArgs)

End Interface

Public Class DifferentWizardStepEventArgs
    Inherits EventArgs

    Protected myWdr As WizardDialogResult
    Protected myStepNr As Integer
    Protected myCancel As Boolean

    Public Sub New(ByVal DialogResult As WizardDialogResult, ByVal StepNr As Integer, ByVal Cancel As Boolean)
        myWdr = DialogResult
        myStepNr = StepNr
        myCancel = Cancel
    End Sub

    'Informiert im Schritt-Wechsel-Ereignis über die
    'vom Benutzer gewünschte Aktion (vor, zurück, fertig, abbrechen).
    Public Overridable Property WizardDialogResult() As WizardDialogResult
        Get
            Return myWdr
        End Get
        Set(ByVal Value As WizardDialogResult)
            myWdr = Value
        End Set
    End Property

    'Informiert im Schritt-Wechsel-Ereignis über die aktuelle
    '(noch nicht gewechselte) Schritt-Nr.
    Public Overridable Property StepNr() As Integer
        Get
            Return myStepNr
        End Get
        Set(ByVal Value As Integer)
            myStepNr = Value
        End Set
    End Property

    'Hat eine Art Zurück-Info-Status. Setzt der Entwickler im
    'Ereignis dieses Flag auf True, weiß der Dialog, dass er
    'sich nicht beenden darf. Der Schrittwechsel wird abgebrochen.
    Public Overridable Property Cancel() As Boolean
        Get
            Return myCancel
        End Get
        Set(ByVal Value As Boolean)
            myCancel = Value
        End Set
    End Property
End Class

Public Class ADNavigationableArrayList
    Inherits ArrayList

    Protected myItemPointer As Integer

    Public Sub New()
        myItemPointer = -1
    End Sub

    'Liefert das aktuelle Element der Collection zurück, oder bestimmt es.
    'Wenn die ArrayList beim Setzen noch leer ist, wird ein Element angelegt.
    Public Overridable Property CurrentItem() As Object
        Get
            If myItemPointer = -1 Then
                Throw New IndexOutOfRangeException("NavigationableArrayList ist leer")
            End If
            Return Me(myItemPointer)
        End Get
        Set(ByVal Value As Object)
            If myItemPointer = -1 Then
                Me.Add(Value)
                myItemPointer = 0
            Else
                Me(myItemPointer) = Value
            End If
        End Set
    End Property

    'Springt zum nächsten Element des Arrays, dass dann mit CurrentItem ermittelt werden kann
    'true, wenn es ein weiteres Element gibt, sonst false</returns>
    Public Overridable Function MoveNext() As Boolean
        If IsLast Then
            Return False
        End If

        If (myItemPointer < Me.Count - 1) Then
            myItemPointer += 1
            Return Not IsLast
        End If

    End Function

    'Springt zum vorherigen Element des Arrays, dass dann mit CurrentItem ermittelt werden kann
    'true, wenn es noch ein vorheriges Element gibt</returns>
    Public Overridable Function MovePrevious() As Boolean
        If IsFirst Then
            Return False
        End If

        If (myItemPointer > 0) Then
            myItemPointer -= 1
            Return Not IsFirst
        End If

    End Function

    'Springt zum ersten Element
    Public Overridable Sub MoveFirst()

        If myItemPointer > -1 Then
            myItemPointer = 0
        End If

    End Sub

    'Springt zum letzten Element
    Public Overridable Sub MoveLast()

        If myItemPointer > -1 Then
            myItemPointer = Me.Count - 1
        End If

    End Sub

    'Hängt der Liste ein Element an, aber ohne CurrentItem zu verändern,
    'es sei denn, es gab zuvor keine Elemente im Array
    Public Overrides Function Add(ByVal [object] As Object) As Integer

        If myItemPointer = -1 Then
            myItemPointer = 0
        End If
        Return MyBase.Add([object])

    End Function

    'Stellt fest, ob der Indexer auf das letzte Element der Liste zeigt
    Public ReadOnly Property IsLast() As Boolean
        Get
            If myItemPointer = -1 Then Return True
            If myItemPointer = Me.Count - 1 Then Return True
            Return False
        End Get
    End Property

    'Stellt fest, ob der Indexer auf das erste Element der Liste zeigt
    Public ReadOnly Property IsFirst() As Boolean
        Get
            If myItemPointer = -1 Then Return True
            If myItemPointer = 0 Then Return True
            Return False
        End Get
    End Property

End Class

Public Class ADWizardHandler

    Protected mywizardDialogs As ADNavigationableArrayList
    Protected myWizardBaseDialog As IADWizard
    Protected myWizardBaseShown As Boolean
    Public Event DifferentWizardStep(ByVal sender As Object, ByVal e As DifferentWizardStepEventArgs)

    'Legt eine neue WizardHandler-Klasse an;
    'die darzustellenden Formulare werden als IADWizard-Schnittstellen-
    'Objekte übergeben. Damit können Sie dem Wizard jedes Objekt
    'zum "Assistentieren" übergeben, dass diese Schnittstelle einbindet.
    'Zusätzlich benötigt der Konstruktor das Basis-Formular, das er zum
    'Verhindern des Flimmerns benötigt, indem er das obere Formular
    'zu TopMost macht, und das Basis-Formular unterschiebt. Beim Schließen
    'eines Schritt-Formulars scheint dann nicht der Desktop sondern das
    '"untergeschobene" Assistenten-Basisformular durch, das ähnlich
    'gestaltet ist und so das Flimmern verhindert.
    Public Sub New(ByVal WizardTitel As String, ByVal Owner As Form, ByVal WizardBaseDialog As IADWizard, _
                   ByVal ParamArray WizardDialogs As IADWizard())

        myWizardBaseDialog = WizardBaseDialog
        'Nachträglich ergänzt: Owner muss gesetzt werden, damit alle Fenster über dem aufrufenden liegen;
        'Sonst flimmert der Assistent an sicht nicht, aber das einbindende Fenster scheint beim
        'Schrittwechsel durch.
        myWizardBaseDialog.Owner = Owner
        mywizardDialogs = New ADNavigationableArrayList
        Dim currentDialog As IADWizard

        'Dialoge der NavigationableArrayList hinzufügen
        For count As Integer = 0 To WizardDialogs.Length - 1
            currentDialog = WizardDialogs(count)

            'Festhalten, welcher Dialog dem ersten...
            currentDialog.FirstStep = (count = 0)
            'und welcher dem letzten Schritt entspricht.
            currentDialog.LastStep = (count = (WizardDialogs.Length - 1))
            'Dialog der Collection hinzufügen
            currentDialog.Owner = Owner
            mywizardDialogs.Add(currentDialog)
            'Den Ereignissbehandler einbinden
            AddHandler currentDialog.DifferentWizardStep, AddressOf OnDifferentWizardStep
            'Titel und Schrittnummer definieren
            currentDialog.SetWizardProperties(WizardTitel & " Schritt:" & count + 1, count + 1)
        Next

    End Sub

    'Diese Funktion rufen Sie auf, um den Wizard zu aktivieren.
    Public Overridable Function PerformWizard() As WizardDialogResult

        Dim myCurrentDialog As IADWizard
        Dim myWizardTemplate As Form = New ADFormWizardTemplate
        Dim myDialogResult As WizardDialogResult

        'Keine Assistentenschritte vorhanden -> Fehler!
        If (mywizardDialogs Is Nothing) Then
            Throw New ArgumentException("Die Collection, die die Assistentenformulare enthält, darf nicht null sein!")
        End If

        'Auf ersten Assistentenschritt positionieren
        mywizardDialogs.MoveFirst()

        Do
            myCurrentDialog = DirectCast(mywizardDialogs.CurrentItem, IADWizard)

            'Falls ein untergeschobene Instanz existiert, um das Flimmern 
            'beim Wechseln von Schritt zu Schritt zu verhindern,...
            If myWizardBaseDialog.Shown Then
                '...diese Instanz dem Schritt-Dialog übergeben, damit er sie im
                'OnPaint-Event schließen kann (zu dem Zeitpunkt ist der Schritt-
                'Dialog vollständig dargestellt, und sie verdeckt, da TopMost,
                'die "untergeschoebene" Instanz vollständig, die deswegen zu diesem
                'Zeitpunkt sicher entfernt werden kann).
                myDialogResult = myCurrentDialog.ShowWDialog(myWizardBaseDialog)
            Else
                'Falls es kein "Flimmerverhinderungsdialog" gab,
                'Darstellungsroutine normal aufrufen.
                myDialogResult = myCurrentDialog.ShowWDialog()
            End If

            'Auswerten, welcher Schritt durchgeführt wurde
            Select Case myDialogResult
                Case WizardDialogResult.Next
                    mywizardDialogs.MoveNext()

                Case WizardDialogResult.Previous
                    mywizardDialogs.MovePrevious()

                    'Schleife abbrechen bei Abbrechen
                Case WizardDialogResult.Cancel
                    Return WizardDialogResult.Cancel

                    'oder Fertig (OK)
                Case WizardDialogResult.OK
                    Return WizardDialogResult.OK

            End Select

        Loop

    End Function

    Public Overridable Sub OnDifferentWizardStep(ByVal sender As Object, ByVal e As DifferentWizardStepEventArgs)
        RaiseEvent DifferentWizardStep(sender, e)
        If Not e.Cancel Then
            'Nur, Falls der Empfänger das Schrittwechseln nicht unterbricht... 
            If e.WizardDialogResult = WizardDialogResult.Next Or _
                e.WizardDialogResult = WizardDialogResult.Previous Then
                'Im Sender steckt das ereignisauslösende Objekt
                'Das auf TopMost setzen, damit eine "untergeschobene"...
                DirectCast(sender, IADWizard).TopMost = True
                '...Instanz das Flimmern verhindern kann!
                'Diese Instanz wird im OnPaint-Event eines jeden
                'Assistentendialoges wieder geschlossen (siehe dort).
                myWizardBaseDialog.Show()
            End If
        End If
    End Sub

End Class
