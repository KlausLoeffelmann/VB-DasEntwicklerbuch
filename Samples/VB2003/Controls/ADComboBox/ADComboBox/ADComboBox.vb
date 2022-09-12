Imports System.Windows.Forms ' Notwendig, wenn auf andere Steuerelemente zugegriffen werden soll
Imports System.Drawing  ' Wichtig, wenn eigene Grafikausgaben vorgenommen werden m�ssen
Imports System.ComponentModel ' Wichtig, um auf alle notwendigen Attribute zugreifen zu k�nnen

Public Class ADComboBox
    Inherits ComboBox

    Private myAutoComplete As Boolean
    Private mySenderIsThis As Boolean

    Sub New()
        myAutoComplete = True
    End Sub

    'Wird aufgerufen, sobald irgendeine Ver�nderung im Eingabefeld vorgenommen wird
    '(ganz gleich, ob programmtechnisch oder durch den Anwender)
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        'Dieses Flag wird ben�tigt, damit eine Eingabebereichsver�nderung, die
        'programmtechisch durch das Steuerelement selbst vorgenommen wird, das Ereignis
        'nicht erneut ausl�st, und das Programm in einer Endlosschleife h�ngen bleibt.
        If Not mySenderIsThis Then
            'Verhindern, dass das Ereignis durch eigene Manipulation erneut ausgel�st wird
            mySenderIsThis = True
            'Auto-Vervollst�ndigen durchf�hren
            PerfAutoCompletion()
            mySenderIsThis = False
        End If
        'Basis-Funktion aufrufen nicht vergessen!
        MyBase.OnTextChanged(e)
    End Sub

    Private Sub PerfAutoCompletion()

        'Nur wenn AutoComplete eingeschaltet ist �berhaupt etwas machen
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
                    'er einfach �berschrieben werden kann
                    Me.Select(locTemp.Length, locFoundEntry.Length - locTemp.Length)
                End If
            End If
        End If
    End Sub

    'Wird ausgel�st, wenn eine Taste gedr�ckt wird
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        'Cursor-nach-unten, dann...
        If e.KeyCode = Keys.Down Then
            If Not Me.DroppedDown Then
                '...Dropdown-Bereich �ffnen
                Me.DroppedDown = True
                e.Handled = True
            End If
        Else
            'Wenn Delete oder Backspace gedr�ckt wird, dann keine Modifizierungen vornehmen
            mySenderIsThis = (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back)
        End If
        MyBase.OnKeyDown(e)
    End Sub

    'Die einzige neue Eigenschaft:
    <Description("Bestimmt oder ermittelt, ob die Auto-Erg�nzen-Funktion verwendet wird."), _
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
