Public Class TestControl
    Inherits Control

    Private myShowCreationDestroy As Boolean
    Private myShowMouse As Boolean
    Private myShowKeyboard As Boolean
    Private myShowPositioning As Boolean
    Private myShowRepaintAndLayout As Boolean
    Private myShowFocussing As Boolean
    Private myShowPreProcessing As Boolean

    'Standardkonstruktor: Basiskonstruktor aufrufen
    Public Sub New()
        MyBase.new()
    End Sub

    'Erweiterter Konstruktor: Parameter f�r die Debug-Ausgaben setzen
    Public Sub New(ByVal ShowCreationDestroy As Boolean, _
                    ByVal ShowMouse As Boolean, _
                    ByVal ShowKeyboard As Boolean, _
                    ByVal ShowPositioning As Boolean, _
                    ByVal ShowRepaintAndLayout As Boolean, _
                    ByVal ShowFocussing As Boolean, _
                    ByVal ShowPreProcessing As Boolean)
        MyBase.New()
        myShowCreationDestroy = ShowCreationDestroy
        myShowMouse = ShowMouse
        myShowKeyboard = ShowKeyboard
        myShowPositioning = ShowPositioning
        myShowRepaintAndLayout = ShowRepaintAndLayout
        myShowFocussing = ShowFocussing
        myShowPreProcessing = ShowPreProcessing
    End Sub

    'Wird von OnBackgroundPaint aufgerufen, damit der Hintergrund 
    'des Controls gel�scht wird. Zeichnet hier im Beispiel
    'einen gelben Hintergrund
    Protected Overridable Sub DrawControlBackground(ByVal g As Graphics)
        Dim locBrush As New SolidBrush(Color.Yellow)
        g.SetClip(Me.ClientRectangle, Drawing2D.CombineMode.Replace)
        g.FillRectangle(locBrush, Me.ClientRectangle)
    End Sub

    'Wird von OnPaint aufgerufen, damit das TestControl einen sichtbaren Inhalt hat
    'Zeichnet hier im Beispiel ein umrandetes Kreuz mit einer bestimmten Stiftdicke,
    'die von der Fokussierung der Komponente abh�ngig ist
    Protected Overridable Sub DrawControl(ByVal g As Graphics)
        Dim locPenWidth As Integer
        Dim locClientRecPenWidthIncluded As Rectangle

        'Wenn das Control fokussiert ist, 
        If Me.Focused Then
            locPenWidth = 4
        Else
            locPenWidth = 2
        End If

        'Die Dicke des Pens bei den Koordinaten ber�cksichtigen!
        locClientRecPenWidthIncluded = New Rectangle( _
            Me.ClientRectangle.X + locPenWidth \ 2, _
            Me.ClientRectangle.Y + locPenWidth \ 2, _
            Me.ClientRectangle.Width - locPenWidth, _
            Me.ClientRectangle.Height - locPenWidth)

        'Pen zum Malen
        Dim locPen As New Pen(Color.Black, locPenWidth)

        'Rahmen zeichnen
        g.DrawRectangle(locPen, locClientRecPenWidthIncluded)

        'Kreuz malen
        g.DrawLine(locPen, locClientRecPenWidthIncluded.X, locClientRecPenWidthIncluded.Y, _
                    locClientRecPenWidthIncluded.Right, locClientRecPenWidthIncluded.Bottom)

        g.DrawLine(locPen, locClientRecPenWidthIncluded.Right, locClientRecPenWidthIncluded.Y, _
                    locClientRecPenWidthIncluded.X, locClientRecPenWidthIncluded.Bottom)

    End Sub

    'Wird aufgerufen, nachdem das Window-Handle f�r die Control-Instanz erstellt wurde.
    Protected Overrides Sub OnHandleCreated(ByVal e As System.EventArgs)
        MyBase.OnHandleCreated(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnHandleCreated")
        End If
    End Sub

    'Tritt ein, nachdem die framework-seitigen Ressourcen f�r das Control erstellt wurden.
    'Die Basis-Funktion muss in den Frameowkrk-Versionen 1.0 und 1.1 nicht notwendiger
    'Weise aufgerufen werden; aus Aufw�rtskompatiblit�tsgr�nden sollte das aber dennoch passieren.
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnCreateControl")
        End If
    End Sub

    'Wird aufgerufen, wenn das Window-Handel zerst�rt wurde.
    Protected Overrides Sub OnHandleDestroyed(ByVal e As System.EventArgs)
        MyBase.OnHandleDestroyed(e)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": OnHandleDestroyed")
        End If
    End Sub

    'wird aufgerufen, wenn das Control entweder durch den GC oder durch
    'Dispose des einbindenden Controls/Formulars entsorgt wird
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
        If myShowCreationDestroy Then
            Debug.WriteLine(Me.ToString + ": Dispose")
        End If
    End Sub

    '*******************************************************
    'Mausereignisse
    '*******************************************************

    'Wird aufgerufen, wenn ein Mausbutton gedr�ckt wird und sich die Maus �ber einem
    'Bereich des Controls, aber nicht �ber einem ChildWindow-Bereich (andere Komponente) befindet.
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseDown: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                                    , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If
    End Sub

    'Wird aufgerufen, wenn ein Mausklick mit der linken Maustaste �ber einem
    'Bereich des Controls, aber nicht �ber einem ChildWindow-Bereich (andere Komponente)
    'durchgef�hrt wird.
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        MyBase.OnClick(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnClick")
        End If
    End Sub

    'Wird aufgerufen, wenn ein Doppelklick mit der linken Maustaste �ber einem
    'Bereich des Controls, aber nicht �ber einem ChildWindow-Bereich (andere Komponente)
    'durchgef�hrt wird.
    Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)
        MyBase.OnDoubleClick(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnDoubleClick")
        End If
    End Sub

    'Wird aufgerufen, wenn ein Mausbutton losgelassen wird, und sich die Maus �ber einem
    'Bereich des Controls, aber nicht �ber einem ChildWindow-Bereich (andere Komponente) befindet.
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseUp: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                                    , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If
    End Sub

    'Wird aufgerufen, wenn der Mauszeiger den Bereich des Controls
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

    'Wird aufgerufen, wenn der Mauszeiger �ber dem Bereich des Controls
    'aber nicht �ber einem ChildWindow-Bereich (andere Komponente) bewegt wird.
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseMove(e)
        If myShowMouse Then
            Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnMouseMove: x={0}; y={1}; delta={2}; button={3}; clicks={4}" _
                                            , e.X, e.Y, e.Delta, e.Button, e.Clicks))
        End If

    End Sub

    'Wird aufgerufen, wenn der Mauszeiger den Bereich des Controls verl�sst.
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        If myShowMouse Then
            Debug.WriteLine(Me.ToString + ": OnMouseLeave:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Mausrad
    'bewegt wird. Wichtig: Alle Komponenten empfangen dieses Ereignis!
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
    'Wird aufgerufen, wenn eine Taste gedr�ckt wird und das Control den Fokus hat.
    'Fungiert das Control als Container (von Scrollable- oder Container-Control abgeleitet), verwenden 
    'Sie die Tastaturvorverarbeitungsnachrichten-Ereignisse, um die Tastatur-Ereignisse auszuwerten, 
    'da sie selbst in diesem Fall nicht ausgel�st werden.
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        MyBase.OnKeyDown(e)
        If myShowKeyboard Then
            Debug.WriteLine(String.Format( _
                Me.ToString + ": OnkeyDown: KeyCode={0}; KeyData={1}; KeyValue={2}; Modifiers={3}", _
                                e.KeyCode, e.KeyData, e.KeyValue, e.Modifiers))
        End If
    End Sub

    'Wird aufgerufen, wenn eine Taste gedr�ckt wird und das Control fokussiert ist;
    'wird nicht aufgerufen, wenn eine Steuerungs-Taste (wie Strg oder Shift)
    'alleine oder in Kombination mit einer anderen gedr�ckt wird.
    'Fungiert das Control als Container (von Scrollable- oder Container-Control abgeleitet), verwenden 
    'Sie die Tastaturvorverarbeitungsnachrichten-Ereignisse, um die Tastatur-Ereignisse auszuwerten, 
    'da sie selbst in diesem Fall nicht ausgel�st werden.
    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        If myShowKeyboard Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnKeyPress: KeyChar={0}", _
                        e.KeyChar))
        End If
    End Sub

    'Wird ausgerufen, wenn eine Taste wieder losgelassen wird und das Control den Fokus hat
    'Fungiert das Control als Container (von Scrollable- oder Container-Control abgeleitet), verwenden 
    'Sie die Tastaturvorverarbeitungsnachrichten-Ereignisse, um die Tastatur-Ereignisse auszuwerten, 
    'da sie selbst in diesem Fall nicht ausgel�st werden.
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
    'Wird aufgerufen, wenn die Control-Position ver�ndert wird.
    Protected Overrides Sub OnMove(ByVal e As System.EventArgs)
        MyBase.OnMove(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnMove:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn sich die Position des Controls ver�ndert hat.
    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        MyBase.OnLocationChanged(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnLocationChanged:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn sich die Ausma�e des Controls �ndern.
    'Wenn das Control seinen Inhalt in Abh�ngigkeit seiner Gr��e ver�ndert,
    'sollte an dieser Stelle an Aufruf an Invalidate erfolgen, damit das parallel automatisch
    'ausgel�ste Paint-Ereignis verhindert wird und stattdessen ein neues Paint-
    'Ereignis ausgel�st wird, dass aber dann in der Lage ist, den Neuaufbau
    'des gesamten Client-Bereichs durchzuf�hren. Hintergrund: Das Standard-Paint-Ereignis kann nur
    'die neu zu zeichnenden Bereiche verarbeiten, und wird gar nicht ausgel�st, wenn das Control
    'nur verkleinert wird.
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnResize:" + e.ToString)
        End If
        Invalidate()
    End Sub

    'Wird aufgerufen, wenn sich die Ausma�e eines Controls ge�ndert haben.
    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)
        If myShowPositioning Then
            Debug.WriteLine(Me.ToString + ": OnSizeChanged:" + e.ToString)
        End If
    End Sub

    'Diese Prozedur dient zweierlei Dingen: Zum einen wird sie von der Basisklasse bei jedem Ereignis aufgerufen, 
    'das durch das �ndern der Gr��e oder der Position des Controls aufgerufen wird. Klassen, die diese Routine 
    '�berschreiben, k�nnen die Position und Ausma�e des Controls durch das Ver�ndern der Parameter auf der 
    'anderen Seite reglementieren. Wenn Sie also beispielsweise nicht wollen, dass die Ausma�e des 
    'Controls eine bestimmte Gr��e �berschreiten, definieren Sie in dieser Funktion f�r den 
    'entsprechenden Parameter einen neuen Wert, bevor Sie die Basisfunktion mit den ge�nderten 
    'Werten aufrufen. Der Parameter BoundsSpecified informiert Sie dar�ber, welcher 
    'Parameter durch ein Ereignis ge�ndert wurde.
    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, _
    ByVal height As Integer, ByVal specified As System.Windows.Forms.BoundsSpecified)
        MyBase.SetBoundsCore(x, y, width, height, specified)
        If myShowPositioning Then
            Debug.WriteLine(String.Format( _
                Me.ToString + ": SetBoundsCore: X={0}; y={1}; width={2}; height={3}; specified={4}" _
                                , x, y, width, height, specified))
        End If
    End Sub

    'Wird aufgerufen, wenn sich die Gr��e des Controls durch das Setzen. 
    'der ClientSize-Eigenschaft �ndern soll
    Protected Overrides Sub SetClientSizeCore(ByVal x As Integer, ByVal y As Integer)
        MyBase.SetClientSizeCore(x, y)
        If myShowPositioning Then
            Debug.WriteLine(String.Format(Me.ToString + ": SetClientSizeCore: X={0}; y={1}", x, y))
        End If
    End Sub

    '*******************************************************
    'Anordnen und Neuzeichnen
    '*******************************************************

    'Wird aufgerufen, wenn eine Entit�t das Neuzeichnen des Controlinhalts durch Invalidate anfordert
    'Hier im Beispielprogramm geschieht das durch Resize, GotFocus und LostFocus.
    Protected Overrides Sub OnInvalidated(ByVal e As System.Windows.Forms.InvalidateEventArgs)
        MyBase.OnInvalidated(e)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnInvalidated: InvalidRect={0}", _
                        e.InvalidRect))
        End If

    End Sub

    'Wird aufgerufen, wenn das Control anzeigt, dass seine beinhaltenden Steuerelemente
    'aus irgendwelchen Gr�nden neu angeordnet werden m�ssen.
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(String.Format( _
                        Me.ToString + ": OnLayout: AffectedControl={0}; AffectedProperty={1}", _
                        levent.AffectedControl, levent.AffectedProperty))
        End If
    End Sub

    'Wird aufgerufen, wenn der Hintergrund des Controls neu gezeichnet werden muss.
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(pevent)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(Me.ToString + ": OnPaintBackground:" + pevent.ClipRectangle.ToString)
        End If
        DrawControlBackground(pevent.Graphics)
    End Sub

    'Wird aufgerufen, wenn der Fensterinhalt neu gezeichnet werden muss.
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        If myShowRepaintAndLayout Then
            Debug.WriteLine(Me.ToString + ": OnPaint:" + e.ClipRectangle.ToString)
        End If
        DrawControl(e.Graphics)
    End Sub

    '*******************************************************
    'Fokussierung
    '*******************************************************

    'Wird aufgerufen, wenn das Control dabei ist, den Fokus zu erhalten.
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnEnter:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Control fokussiert wird, aber nicht, wenn es
    'ein Container-Control ist, das weitere Komponenten enth�lt!
    '(In diesem Fall verwenden Sie OnEnter, um das Ereignis zu empfangen)
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnGotFocus:" + e.ToString)
        End If
        'Das fokussierte Control sieht anders aus als das nicht-fokussierte;
        'deswegen: alles NeuZeichnen
        Invalidate()
    End Sub

    'Wird aufgerufen, wenn das Control dabei ist, den Fokus zu verlieren.
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnLeave:" + e.ToString)
        End If
    End Sub

    'Wird aufgerufen, wenn das Control den Fokus verloren hat, aber nicht, wenn es
    'ein Container-Control ist, das weitere Komponenten enth�lt!
    '(In diesem Fall verwenden Sie OnLeave, um das Ereignis zu empfangen)
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If myShowFocussing Then
            Debug.WriteLine(Me.ToString + ": OnLostFocus:" + e.ToString)
        End If
        'Das fokussierte Control sieht anders aus als das nicht-fokussierte;
        'deswegen: alles Neuzeichnen
        Invalidate()
    End Sub

    '*******************************************************
    'Tastatur-Vorverarbeitung
    '*******************************************************
    'Wird ausgel�st, wenn eine Befehlstaste (z.B. ALT+Anfangsbuchstabe) gedr�ckt wurde.
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, _
                                ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If myShowPreProcessing Then
            Debug.WriteLine(Me.ToString + ": ProcessCmdKey:" + _
                    msg.ToString + ": KeyData: " + keyData.ToString)
        End If
        'Wenn Ihre Instanz eine Nachricht verarbeitet hat, dann geben Sie
        'True als Funtionsergebnis zur�ck, sonst False. Die Basis rufen Sie nur
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde
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
        'auf (dann aber auf jeden Fall!), wenn die Nachricht NICHT verarbeitet wurde.
        Return MyBase.ProcessDialogKey(keyData)
    End Function
End Class
