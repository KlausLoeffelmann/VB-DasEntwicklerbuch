Imports System.Drawing
Imports System.Windows.Forms

Public Class TestControl
    Inherits ScrollableControl

    Public Sub New()
        MyBase.new()
    End Sub

    'Malt das komplette Control zuerst in eine Bitmap, und
    'die Bitmap anschließend in das Steuerelement
    Protected Overridable Sub DrawControlHiddenComplete(ByVal g As Graphics)

        Dim locBitmap As New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height, g)
        DrawControlBackground(Graphics.FromImage(locBitmap))
        DrawControl(Graphics.FromImage(locBitmap))
        g.DrawImage(locBitmap, 0, 0)
        locBitmap = New Bitmap(20, 20, g)
        Dim inttemp As Integer = locBitmap.Flags
        locBitmap.Dispose()
        locBitmap = Nothing

    End Sub

    'Wird von OnBackgroundPaint aufgerufen, damit der Hintergrund 
    'des Controls gelöscht wird. Zeichnet hier im Beispiel
    'einen gelben Hintergrund
    Protected Overridable Sub DrawControlBackground(ByVal g As Graphics)
        Dim locBrush As New SolidBrush(Color.Yellow)
        g.SetClip(Me.ClientRectangle, Drawing2D.CombineMode.Replace)
        g.FillRectangle(locBrush, Me.ClientRectangle)
    End Sub

    'Wird von OnPaint aufgerufen, damit das TestControl einen sichtbaren Inhalt hat
    'Zeichnet hier im Beispiel ein umrandetes Kreuz mit einer bestimmten Stiftdicke,
    'die von der Fokussierung der Komponente abhängig ist
    Protected Overridable Sub DrawControl(ByVal g As Graphics)
        Dim locPenWidth As Integer
        Dim locClientRecPenWidthIncluded As Rectangle

        'Wenn das Control fokussiert ist, 
        If Me.Focused Then
            locPenWidth = 4
        Else
            locPenWidth = 2
        End If

        'Die Dicke des Pens bei den Koordinaten berücksichtigen!
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

        'drittel so großes, schwarzes Rechteck zeichnen
        Dim locBrush As New SolidBrush(Color.Black)
        g.FillRectangle(locBrush, Me.ClientRectangle.X + Me.ClientRectangle.Width \ 6, _
                                  Me.ClientRectangle.Y + Me.ClientRectangle.Height \ 6, _
                                  CInt(Me.ClientRectangle.Width / 1.5F), CInt(Me.ClientRectangle.Height / 1.5F))
        'Halb so große, rote Ellipse hineinmalen
        locBrush = New SolidBrush(Color.Red)
        g.FillEllipse(locBrush, Me.ClientRectangle.X + Me.ClientRectangle.Width \ 4, _
                                  Me.ClientRectangle.Y + Me.ClientRectangle.Height \ 4, _
                                  Me.ClientRectangle.Width \ 2, Me.ClientRectangle.Height \ 2)

    End Sub

    'Wird aufgerufen, wenn das Control anzeigt, dass seine beinhaltenden Steuerelemente
    'aus irgendwelchen Gründen neu angeordnet werden müssen
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        MyBase.OnLayout(levent)
        Debug.WriteLine(String.Format( _
                    Me.ToString + ": OnLayout: AffectedControl={0}; AffectedProperty={1}", _
                    levent.AffectedControl, levent.AffectedProperty))
    End Sub

    'Wird aufgerufen, wenn der Hintergrund des Controls neu gezeichnet werden muss
    Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        Debug.WriteLine(Me.ToString + ": OnPaintBackground:" + pevent.ClipRectangle.ToString)
        'DrawControlBackground(pevent.Graphics)
    End Sub

    'Wird aufgerufen, wenn der Fensterinhalt neu gezeichnet werden muss
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Debug.WriteLine(Me.ToString + ": OnPaint:" + e.ClipRectangle.ToString)
        DrawControlHiddenComplete(e.Graphics)
    End Sub

    'Wird aufgerufen, wenn das Control fokussiert wird, aber nicht, wenn es
    'ein Container-Control ist, das weitere Komponenten enthält!
    '(In diesem Fall verwenden Sie OnEnter, um das Ereignis zu empfangen)
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        Debug.WriteLine(Me.ToString + ": OnGotFocus:" + e.ToString)
        'Das fokussierte Control sieht anders aus als das nicht-fokussierte;
        'deswegen: alles NeuZeichnen
        Invalidate()
    End Sub

    'Wird aufgerufen, wenn das Control den Fokus verloren hat, aber nicht, wenn es
    'ein Container-Control ist, das weitere Komponenten enthält!
    '(In diesem Fall verwenden Sie OnLeave, um das Ereignis zu empfangen)
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        Debug.WriteLine(Me.ToString + ": OnLostFocus:" + e.ToString)
        'Das fokussierte Control sieht anders aus als das nicht-fokussierte;
        'deswegen: alles Neuzeichnen
        Invalidate()
    End Sub
    'Wird aufgerufen, wenn sich die Ausmaße des Controls ändern
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)
        Debug.WriteLine(Me.ToString + ": OnResize:" + e.ToString)
        Invalidate()
    End Sub

End Class
