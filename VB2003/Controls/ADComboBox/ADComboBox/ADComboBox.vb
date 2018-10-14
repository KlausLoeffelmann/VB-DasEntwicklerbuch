Imports System.Windows.Forms ' Notwendig, wenn auf andere Steuerelemente zugegriffen werden soll
Imports System.Drawing  ' Wichtig, wenn eigene Grafikausgaben vorgenommen werden müssen
Imports System.ComponentModel ' Wichtig, um auf alle notwendigen Attribute zugreifen zu können

Public Class ADComboBox
    Inherits ComboBox

    Private myAutoComplete As Boolean
    Private mySenderIsThis As Boolean

    Sub New()
        myAutoComplete = True
    End Sub

    'Wird aufgerufen, sobald irgendeine Veränderung im Eingabefeld vorgenommen wird
    '(ganz gleich, ob programmtechnisch oder durch den Anwender)
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        'Dieses Flag wird benötigt, damit eine Eingabebereichsveränderung, die
        'programmtechisch durch das Steuerelement selbst vorgenommen wird, das Ereignis
        'nicht erneut auslöst, und das Programm in einer Endlosschleife hängen bleibt.
        If Not mySenderIsThis Then
            'Verhindern, dass das Ereignis durch eigene Manipulation erneut ausgelöst wird
            mySenderIsThis = True
            'Auto-Vervollständigen durchführen
            PerfAutoCompletion()
            mySenderIsThis = False
        End If
        'Basis-Funktion aufrufen nicht vergessen!
        MyBase.OnTextChanged(e)
    End Sub

    Private Sub PerfAutoCompletion()

        'Nur wenn AutoComplete eingeschaltet ist überhaupt etwas machen
        If AutoComplete Then
            'Zwischenspeichern, damit die Originaleingabe erhalten bleibt
            Dim locTemp As String = Me.Text
            'Index des Eintrags finden, dass der bisherigen Texteingabe entspricht
            Dim locIndex As Integer = Me.FindString(locTemp)
            If locIndex > -1 Then
                'Eintrag gefunden, zum einfacheren Handling in Variable kopieren
                Dim locFoundEntry As String = Me.Items(locIndex).ToString
                If locIndex > -1 Then
                    'Eintrag ins Eingabefeld kopieren
                    Me.Text = locFoundEntry
                    'den noch nicht eingegebenen Teil markieren, damit
                    'er einfach überschrieben werden kann
                    Me.Select(locTemp.Length, locFoundEntry.Length - locTemp.Length)
                End If
            End If
        End If
    End Sub

    'Wird ausgelöst, wenn eine Taste gedrückt wird
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        'Cursor-nach-unten, dann...
        If e.KeyCode = Keys.Down Then
            If Not Me.DroppedDown Then
                '...Dropdown-Bereich öffnen
                Me.DroppedDown = True
                e.Handled = True
            End If
        Else
            'Wenn Delete oder Backspace gedrückt wird, dann keine Modifizierungen vornehmen
            mySenderIsThis = (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back)
        End If
        MyBase.OnKeyDown(e)
    End Sub

    'Die einzige neue Eigenschaft:
    <Description("Bestimmt oder ermittelt, ob die Auto-Ergänzen-Funktion verwendet wird."), _
    Category("Verhalten"), _
    DefaultValue(GetType(Boolean), "True"), _
    Browsable(True)> _
    Public Property AutoComplete() As Boolean
        Get
            Return myAutoComplete
        End Get
        Set(ByVal Value As Boolean)
            myAutoComplete = Value
        End Set
    End Property
End Class
