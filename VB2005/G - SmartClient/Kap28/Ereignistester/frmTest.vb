Public Class frmTest

    Inherits System.Windows.Forms.Form

    Private myShowCreationDestroy As Boolean
    Private myShowMouse As Boolean
    Private myShowKeyboard As Boolean
    Private myShowPositioning As Boolean
    Private myShowRepaintAndLayout As Boolean
    Private myShowFocussing As Boolean
    Private myShowPreProcessing As Boolean
    Private myShowWndProcMessages As Boolean

    Sub New()
        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' F�gen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Public Sub New(ByVal ShowCreationDestroy As Boolean, _
                ByVal ShowMouse As Boolean, _
                ByVal ShowKeyboard As Boolean, _
                ByVal ShowPositioning As Boolean, _
                ByVal ShowRepaintAndLayout As Boolean, _
                ByVal ShowFocussing As Boolean, _
                ByVal ShowPreProcessing As Boolean, _
                ByVal ShowWndProcMessages As Boolean)
        MyBase.New()
        myShowCreationDestroy = ShowCreationDestroy
        myShowMouse = ShowMouse
        myShowKeyboard = ShowKeyboard
        myShowPositioning = ShowPositioning
        myShowRepaintAndLayout = ShowRepaintAndLayout
        myShowFocussing = ShowFocussing
        myShowPreProcessing = ShowPreProcessing
        myShowWndProcMessages = ShowWndProcMessages
        InitializeComponent()
    End Sub

    '*******************************************************
    'Erstellen, Aktivieren, Deaktivieren und Zerst�ren
    '*******************************************************

    'Wird aufgerufen, nachdem das Window-Handle f�r die Formular-Instanz erstellt wurde.
    'Ab diesem Zeitpunkt ist das Formular von der Ereigniswarteschlage erkennbar.
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnHandleCreated")
        End If
    End Sub

    'Tritt ein, kurz bevor die Formular-Instanz das erste Mal sichtbar wird.
    'Beachten Sie, dass das Fokussieren von Komponenten zu dieser Zeit noch 
    'nicht funktioniert und eine Ausnahme ausl�sen w�rde.
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnLoad")
        End If
    End Sub

    'Tritt ein, nachdem die framework-seitigen Ressourcen f�r das Formular erstellt wurden.
    'Die Basis-Funktion muss in den Framework-Versionen 1.0 und 1.1 nicht notwendiger
    'Weise aufgerufen werden; aus Aufw�rtskompatiblit�tsgr�nden sollte es aber dennoch passieren
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnCreateControl")
        End If
    End Sub

    'wird aufgerufen, wenn das Formular aktiviert wurde. Bei einem Formular wird diese Funktion
    'aufgerufen, wenn es zum zuoberst liegenden wird - entweder durch Benutzerklick auf das Formular,
    'oder, da es das Hauptfenster der Anwendung ist, dadurch, dass die Anwendung gestartet oder aktiviert wurde.
    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnActivated")
        End If
    End Sub

    'Wird aufgerufen, um einer ableitenden Klasse beim Initialisierungsvorgang die
    'M�glichkeit zu geben, die Sichtbarkeit (durch die Visible-Eigenschaft gesteuert) zu �ndern.
    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        MyBase.SetVisibleCore(value)
        If myShowCreationDestroy Then
            Debug.WriteLine(String.Format(Me.ToString + ": SetVisibleCore: value={0}", value))
        End If
    End Sub

    'Wird aufgerufen, wenn der Schlie�en-Vorgang des Formulars beginnt.
    'Damit kann das Schlie�en verhindert werden, indem die Cancel-Eigenschaft
    'von e auf True gesetzt wird.
    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnClosing")
        End If
    End Sub

    'Wird aufgerufen, wenn das Formular geschlossen wurde.
    Protected Overrides Sub OnClosed(ByVal e As System.EventArgs)
        MyBase.OnClosed(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnClosed")
        End If
    End Sub

    'Wird aufgerufen, wenn das Formular deaktiviert wurde.
    Protected Overrides Sub OnDeactivate(ByVal e As System.EventArgs)
        MyBase.OnDeactivate(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnDeactivate")
        End If
    End Sub

    'Wird aufgerufen, wenn das Window-Handle des Formulars zerst�rt wurde.
    Protected Overrides Sub OnHandleDestroyed(ByVal e As System.EventArgs)
        MyBase.OnHandleDestroyed(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnHandleDestroyed")
        End If
    End Sub

    ' Die Form �berschreibt den L�schvorgang der Basisklasse, um Komponenten zu bereinigen.
    ' Diese Routine wird in der Regel durch den Formular-Designer implementiert.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": Dispose")
        End If
    End Sub

    '*******************************************************
    'Mausereignisse
    '*******************************************************

    'Wird aufgerufen, wenn ein Mausbutton gedr�ckt wird und sich die Maus �ber einem
    'Bereich des Formulars, aber nicht �ber einem ChildWindow-Bereich (andere Komponente) befindet.
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseDown: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                            , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If
    End Sub

    'Wird aufgerufen, wenn ein Mausklick mit der linken Maustaste �ber einem
    'Bereich des Formulars, aber nicht �ber einem ChildWindow-Bereich (andere Komponente)
    'durchgef�hrt wird.
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnClick")
        End If
    End Sub

    'Wird aufgerufen, wenn ein Doppelklick mit der linken Maustaste �ber einem
    'Bereich des Formulars, aber nicht �ber einem ChildWindow-Bereich (andere Komponente)
    'durchgef�hrt wird.
    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        MyBase.OnDoubleClick(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnDoubleClick")
        End If
    End Sub

    'Wird aufgerufen, wenn ein Mausbutton losgelassen wird, und sich die Maus �ber einem
    'Bereich des Formulars, aber nicht �ber einem ChildWindow-Bereich (andere Komponente) befindet.
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseUp: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                            , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If
    End Sub

    'Wird aufgerufen, wenn der Mauszeiger den Bereich des Formulars
    'aber nicht einen ChildWindow-Bereich (andere Komponente) betritt.
    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnMouseEnter:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn der Mauszeiger das erste Mal nach dem Betreten
    'des Bereichs zur Ruhe gekommen ist.
    Protected Overrides Sub OnMouseHover(ByVal e As System.EventArgs)
        MyBase.OnMouseHover(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnMouseHover:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn der Mauszeiger �ber dem Bereich des Formulars
    'aber nicht �ber einem ChildWindow-Bereich (andere Komponente) bewegt wird.
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseMove: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If

    End Sub

    'Wird aufgerufen, wenn der Mauszeiger den Bereich des Formulars verl�sst.
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnMouseLeave:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Mausrad �ber dem Bereich des Formulars bewegt wird.
    'Dieses Ereignis wird f�r alle untergeordneten Komponenten (ChildWindows) ebenfalls ausgel�st!
    Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseWheel(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseWheel: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                    , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If
    End Sub

    '*******************************************************
    'Tastatur
    '*******************************************************
    'Wird aufgerufen, wenn eine Taste gedr�ckt wird.
    'Wird allerdings nicht aufgerufen, wenn es eine weitere, fokussierte Komponente im Formular gibt 
    'und die KeyPreview-Eigenschaft auf False gesetzt wurde bzw. die �berschriebene 
    'ProcessKeyPreview-Methode (s.u) das Ereignis schon verarbeitet hat.
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        If myShowKeyboard Then
            Debug.WriteLine(String.Format( _
                Me.ToString + ": OnkeyDown: KeyCode={0}; KeyData={1}; KeyValue={2}; Modifiers={3}", _
                    e.KeyCode, e.KeyData, e.KeyValue, e.Modifiers))
        End If
    End Sub

    'Wird aufgerufen, wenn eine Taste gedr�ckt wird; wird nicht aufgerufen,
    'wenn eine Steuerungs-Taste (wie Strg oder Shift) alleine oder in Kombination
    'mit einer anderen gedr�ckt wird.
    'Diese Prozedur wird auch dann nicht aufgerufen, wenn es eine weitere, fokussierte Komponente 
    'im Formular gibt und die KeyPreview-Eigenschaft auf False gesetzt wurde bzw. die �berschriebene 
    'ProcessKeyPreview-Methode (s.u) das Ereignis schon verarbeitet hat.
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If myShowKeyboard Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnKeyPress: KeyChar={0}", _
                        e.KeyChar))
        End If
    End Sub

    'Wird aufgerufen, wenn eine Taste wieder losgelassen wird.
    'Diese Prozedur wird auch dann nicht aufgerufen, wenn es eine weitere, fokussierte Komponente 
    'im Formular gibt und die KeyPreview-Eigenschaft auf False gesetzt wurde bzw. die �berschriebene 
    'ProcessKeyPreview-Methode (s.u) das Ereignis schon verarbeitet hat.
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyUp(e)
        If myShowKeyboard Then
            Debug.WriteLine(String.Format( _
                Me.ToString + ": OnKeyUp: KeyCode={0}; KeyData={1}; KeyValue={2}; Modifiers={3}", _
                    e.KeyCode, e.KeyData, e.KeyValue, e.Modifiers))
        End If
    End Sub

    '*******************************************************
    'Gr��e und Position
    '*******************************************************
    'Wird aufgerufen, wenn die Formularposition ver�ndert wird. Diese Methode wird kontinuierlich aufgerufen, 
    'w�hrend der Anwender das Formular verschiebt und die Anzeigeneinstellung so vorgenommen wurde, dass der 
    'Fensterinhalt beim Ziehen mit verschoben wird.
    Protected Overrides Sub OnMove(ByVal e As System.EventArgs)
        MyBase.OnMove(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnMove:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn sich die Position des Formulars ver�ndert hat. Diese Methode wird leider ebenfalls 
    'kontinuierlich aufgerufen, wenn die Anzeigeneinstellung so vorgenommen wurde, dass der Fensterinhalt 
    'beim Ziehen mit verschoben wird, so dass ein Ende der Verschiebeaktion hiermit nicht festgestellt werden kann. 
    'Um das zu erreichen, m�ssten Sie WndProc �berschreiben und die empfangene Nachricht dort 
    'auf WM_EXITSIZEMOVE �berpr�fen.
    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        MyBase.OnLocationChanged(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnLocationChanged:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn die Formulargr��e ver�ndert wird. Diese Methode wird kontinuierlich aufgerufen, 
    'w�hrend der Anwender das Formular vergr��ert oder verkleinert und die Anzeigeneinstellung so vorgenommen wurde, 
    'dass der Fensterinhalt beim Ziehen mit verschoben wird.
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnResize:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn sich die Gr��e des Formulars ver�ndert hat. Diese Methode wird leider ebenfalls 
    'kontinuierlich aufgerufen, wenn die Anzeigeneinstellung so vorgenommen wurde, dass der Fensterinhalt 
    'beim Ziehen mit verschoben wird, so dass ein Abschluss der Gr��en�nderung hiermit nicht festgestellt werden kann. 
    'Um das zu erreichen, m�ssten Sie WndProc �berschreiben und die empfangene Nachricht dort 
    'auf WM_EXITSIZEMOVE �berpr�fen.
    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnSizeChanged:" + e.ToString)
        End If
    End Sub

    '*******************************************************
    'Anordnen und Neuzeichnen
    '*******************************************************
    'Wird aufgerufen, wenn eine Entit�t das Neuzeichnen des Formularinhalts mit Invalidate anfordert.
    'Invalidate sollte in der Regel von OnResize aufgerufen werden, wenn der Inhalt des Fensters
    'in Abh�ngigkeit von der Fenstergr��e komplett neu gezeichnet werden muss.
    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnInvalidated: InvalidRect={0}", _
                        e.InvalidRect))
        End If

    End Sub

    'Wird aufgerufen, wenn das Formular anzeigt, dass seine beinhaltenden Steuerelemente
    'aus irgendwelchen Gr�nden neu angeordnet werden m�ssen
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnLayout: AffectedControl={0}; AffectedProperty={1}", _
                        levent.AffectedControl, levent.AffectedProperty))
        End If
    End Sub

    'Wird aufgerufen, wenn der Hintergrund des Formulars neu gezeichnet werden muss.
    'Das Graphics-Objekt, das mit dem Parameter vom Typ PaintEventArgs dem Ereignis �bergeben wird,
    'ist ausschlie�lich auf den Bereich geclipped, der neu gezeichnet werden muss. Wenn durch die
    'Vergr��erung des Fensters der Fensterinhalt komplett neu gezeichnet werden muss, dann sollte
    'OnResize bzw. das Resize-Ereignis die Methode Invalidate aufrufen, damit den Paint-Events
    'ein ungeclippter Bereich f�r das Neuzeichnen des kompletten Inhalts �bergeben wird.
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(pevent)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(Me.ToString + ": OnPaintBackground:" + pevent.ClipRectangle.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn der Fensterinhalt neu gezeichnet werden muss.
    'Das Graphics-Objekt, das mit dem Parameter vom Typ PaintEventArgs dem Ereignis �bergeben wird,
    'ist ausschlie�lich auf den Bereich geclipped, der neu gezeichnet werden muss. Wenn durch die
    'Vergr��erung des Fensters der Fensterinhalt komplett neu gezeichnet werden muss, dann sollte
    'OnResize bzw. das Resize-Ereignis die Methode Invalidate aufrufen, damit den Paint-Events
    'ein ungeclippter Bereich f�r das Neuzeichnen des kompletten Inhalts �bergeben wird.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(Me.ToString + ": OnPaint:" + e.ClipRectangle.ToString)
        End If
    End Sub

    '*******************************************************
    'Fokussierung
    '*******************************************************

    'Wird aufgerufen, wenn das Formular aktiviert wird, aber nur, wenn
    'es mindestens ein weiteres Control beinhaltet, das den Fokus beim Aktivieren
    'bekommen kann.
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnEnter:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Formular aktiviert wird, aber nur, wenn
    'es kein weiteres Control beinhaltet, das den Fokus beim Aktivieren
    'bekommen k�nnte.
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnGotFocus:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Formular deaktiviert wird (zum Beispiel weil ein
    'anderes Fenster in den Vordergrund geklickt wurde), aber nur, wenn es kein
    'weiteres Control beinhaltet, das den Fokus beim Deaktivieren verlieren k�nnte.
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnLostFocus:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Formular deaktiviert wird, aber nur, wenn
    'es mindestens ein weiteres Control beinhaltet, das den Fokus beim Deaktivieren
    'verlieren kann.
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnLeave:" + e.ToString)
        End If
    End Sub

    '*******************************************************
    'Tastaturvorverarbeitung
    '*******************************************************
    'Wird ausgel�st, wenn eine Befehlstaste (z.B. ALT+Anfangsbuchstabe) gedr�ckt wurde
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, _
                                ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If myShowPreProcessing Then
            Debug.WriteLine(Me.ToString + ": ProcessCmdKey:" + _
                    msg.ToString + ": KeyData: " + keyData.ToString)
        End If
        'Wenn Ihre Instanz eine Nachricht verarbeitet hat, dann geben Sie
        'True als Funtionsergebnis zur�ck, sonst False. Die Basis rufen Sie nur
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde.
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    'Wird ausgel�st, wenn eine Dialog-Taste (auch Steuerungstaste) gedr�ckt wurde.
    Protected Overrides Function ProcessDialogChar(ByVal charCode As Char) As Boolean
        If myShowPreProcessing Then
            Debug.WriteLine(Me.ToString + ": ProcessDialogChar: " + charCode)
        End If
        'Wenn Ihre Instanz eine Nachricht verarbeitet hat, dann geben Sie
        'True als Funtionsergebnis zur�ck, sonst False. Die Basis rufen Sie nur
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde
        Return MyBase.ProcessDialogChar(charCode)
    End Function

    'Wird ausgel�st, wenn eine Dialog-Taste (aber keine Steuerungstaste) gedr�ckt wurde.
    Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If myShowPreProcessing Then
            Debug.WriteLine(Me.ToString + ": ProcessDialogKey:" + _
                    ": KeyData: " + keyData.ToString)
        End If
        'Wenn Ihre Instanz eine Nachricht verarbeitet hat, dann geben Sie
        'True als Funtionsergebnis zur�ck, sonst False. Die Basis rufen Sie nur
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    'Wird bei jedem Tastenereignis des Formulars ausgel�st, und regelt bei Formularen,
    'ob in Abh�ngigkeit der KeyPreview-Eigenschaft Tastatur-Ereignis-Prozeduren aufgerufen werden.
    Protected Overrides Function ProcessKeyPreview(ByRef m As System.Windows.Forms.Message) As Boolean
        If myShowPreProcessing Then
            Debug.WriteLine(Me.ToString + ": ProcessKeyPreview:" + m.ToString)
        End If
        'Wenn Ihre Instanz eine Nachricht verarbeitet hat, dann geben Sie
        'True als Funtionsergebnis zur�ck, sonst False. Die Basis rufen Sie nur
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde
        Return MyBase.ProcessKeyPreview(m)
    End Function

    'Wird bei jeder Nachricht aufgerufen, die das Fenster in irgendeiner Form betreffen.
    'Um erweiterte Ereignisse selbst auszul�sen, �berschreiben Sie diese Prozedur.
    'Rufen Sie die Basisfunktion im Anschluss nur dann auf, wenn Sie m�chten, dass die Nachrichten,
    'die Sie bereits verarbeitet haben, von der Basisklasse auch verarbeitet werden sollen.
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If myShowWndProcMessages Then
            Console.WriteLine(m)
        End If
        MyBase.WndProc(m)
    End Sub

End Class