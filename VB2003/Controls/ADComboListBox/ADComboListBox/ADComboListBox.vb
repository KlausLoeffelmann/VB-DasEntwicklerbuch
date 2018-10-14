Imports System.ComponentModel

Public Class ADComboListBox
    Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "

    ' UserControl1 �berschreibt den L�schvorgang zur Bereinigung der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F�r Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist f�r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents myTextBox As System.Windows.Forms.TextBox
    Friend WithEvents myListBox As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.myTextBox = New System.Windows.Forms.TextBox
        Me.myListBox = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'myTextBox
        '
        Me.myTextBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.myTextBox.Location = New System.Drawing.Point(0, 0)
        Me.myTextBox.Name = "myTextBox"
        Me.myTextBox.Size = New System.Drawing.Size(328, 20)
        Me.myTextBox.TabIndex = 0
        Me.myTextBox.Text = ""
        '
        'myListBox
        '
        Me.myListBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.myListBox.Location = New System.Drawing.Point(0, 20)
        Me.myListBox.Name = "myListBox"
        Me.myListBox.Size = New System.Drawing.Size(328, 199)
        Me.myListBox.TabIndex = 1
        '
        'ADComboListBox
        '
        Me.Controls.Add(Me.myListBox)
        Me.Controls.Add(Me.myTextBox)
        Me.Name = "ADComboListBox"
        Me.Size = New System.Drawing.Size(328, 224)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mySenderIsThis As Boolean
    Private myAutoComplete As Boolean
    Private myAutoSelect As Boolean

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Eigenschaften vorselektieren
        myAutoComplete = True
        myAutoSelect = True

        ' Die Listbox soll nicht mit der Tabulatortaste fokussiert werden d�rfen!
        myListBox.TabStop = False
    End Sub

    'Diese Funktionen nach unten durchrouten, weil diese Instanz...
    Public Function FindString(ByVal s As String) As Integer
        Return myListBox.FindString(s)
    End Function

    '...aber auch andere Instanzen sie h�ufig...
    Public Function FindString(ByVal s As String, ByVal startIndex As Integer) As Integer
        Return myListBox.FindString(s, startIndex)
    End Function

    '...ben�tigen.
    Public Function FindStringExact(ByVal s As String) As Integer
        Return myListBox.FindStringExact(s)
    End Function

    Private Sub myTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                      Handles myTextBox.TextChanged
        'L�st, durch die Ver�nderung der Text-Eigenschaft, OnTextChange des UserControls aus
        Me.Text = myTextBox.Text
        Console.WriteLine(Me.Text)
    End Sub

    'F�r unsere Zwecke m�ssen wir nur dieses Ereignis nach oben routen, aber...
    Private Sub myTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
                                    Handles myTextBox.KeyDown
        Me.OnKeyDown(e)
    End Sub

    'andere Anwendungen ben�tigen vielleicht auch dieses...
    Private Sub myTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
                                    Handles myTextBox.KeyPress
        Me.OnKeyPress(e)
    End Sub

    '...und dieses Ereignis.
    Private Sub myTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
                                    Handles myTextBox.KeyUp
        Me.OnKeyUp(e)
    End Sub

    'Der Entwickler, der unser Steuerelement verwendet, muss mitbekommen, wenn sich die Auswahl �ndert.
    'Aus diesem Grund m�ssen wir diese beiden Ereignisse nach oben durchreichen.
    Private Sub myListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                    Handles myListBox.SelectedIndexChanged
        OnSelectedIndexChanged(e)
    End Sub

    Protected Overridable Sub OnSelectedIndexChanged(ByVal e As EventArgs)
        'Den Listeneintrag in die TextBox kopieren
        'dabei ungewollte Rekursion verhindern
        mySenderIsThis = True
        Me.Text = myListBox.SelectedItem.ToString
        mySenderIsThis = False
        'Ereignis ausl�sen, damit auch andere Instanzen vom Ereignis erfahren
        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub myListBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                    Handles myListBox.SelectedValueChanged
        OnSelectedValueChanged(e)
    End Sub

    Protected Overridable Sub OnSelectedValueChanged(ByVal e As EventArgs)
        RaiseEvent SelectedValueChanged(Me, e)
    End Sub

    'Wird aufgerufen, *weil* der Handler myTextBox_TextChanged der TextBox die Text-Eigenschaft
    'des UserControls ver�ndert.
    'Wird damit aufgerufen, *sobald* irgendeine Ver�nderung im Eingabefeld vorgenommen wird
    '(ganz gleich, ob programmtechnisch oder durch den Anwender)
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        'Dieses Flag wird ben�tigt, damit eine Eingabebereichsver�nderung, die
        'programmtechisch durch das Steuerelement selbst vorgenommen wird, das Ereignis
        'nicht erneut ausl�st, und das Programm in einer Endlosschleife h�ngen bleibt.
        Console.WriteLine("OnTextChanged")
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

        'Zwischenspeichern, damit die Originaleingabe erhalten bleibt
        Dim locTemp As String = Me.Text
        'Index des Eintrags finden, dass der bisherigen Texteingabe entspricht
        Dim locIndex As Integer = Me.FindString(locTemp)
        'Nur wenn AutoComplete eingeschaltet ist �berhaupt etwas machen
        If AutoComplete Then
            If locIndex > -1 Then
                'Eintrag gefunden, zum einfacheren Handling in Variable kopieren
                Dim locFoundEntry As String = myListBox.Items(locIndex).ToString
                If locIndex > -1 Then
                    'Eintrag ins Eingabefeld kopieren
                    myTextBox.Text = locFoundEntry
                    'den noch nicht eingegebenen Teil markieren, damit
                    'er einfach �berschrieben werden kann
                    myTextBox.Select(locTemp.Length, locFoundEntry.Length - locTemp.Length)
                End If
            End If
        End If

        'AutoSelect-Eigenschaft im Bedarfsfall umsetzen:
        If AutoSelect Then
            'Passenden Eintrag gefunden, ...
            If locIndex > -1 Then
                '...dann selektieren.
                myListBox.SelectedIndex = locIndex
            End If
        End If
    End Sub

    'Wird ausgel�st, wenn eine Taste in der TextBox gedr�ckt wird
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Console.WriteLine("OnKeyDown")
        'Cursor-nach-unten, dann...
        If e.KeyCode = Keys.Down Then
            'Testen ob die Listbox nicht schon fokussiert ist, und ob bereits Eintr�ge vorhanden sind
            If Not myListBox.Focused AndAlso myListBox.Items.Count > 0 Then
                '...ListBox fokussieren,
                myListBox.Focus()
                'Wenn noch kein Eintrag in der Listbox ausgew�hlt war,
                If myListBox.SelectedIndex = -1 Then
                    'ersten Eintrag selektieren
                    myListBox.SelectedIndex = 0
                End If
                e.Handled = True
            End If
        Else
            'Wenn Delete oder Backspace gedr�ckt wird, dann keine Modifizierungen vornehmen
            mySenderIsThis = (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back)
        End If
        MyBase.OnKeyDown(e)
    End Sub

    'Hier kommen die Eigenschaften:
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

    <Description("Bestimmt oder ermittelt, ob mit dem Text �bereinstimmende Eintr�ge automatisch selektiert werden."), _
    Category("Verhalten"), _
    DefaultValue(GetType(Boolean), "True"), _
    Browsable(True)> _
    Public Property AutoSelect() As Boolean
        Get
            Return myAutoSelect
        End Get
        Set(ByVal Value As Boolean)
            myAutoSelect = Value
        End Set
    End Property

    'Die Texteigenschaft wird vom Designer f�r das UserControl und deren Ableitungen unterdr�ckt.
    'Mit Browsable(True) machen wir es im Eigenschaftenfenster wieder darstellbar.
    <Browsable(True)> _
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            'Neuen Text der Textbox zuordnen
            myTextBox.Text = Value
            'WICHTIG: Wenn diese Anweisung fehlt, wird OnTextChange nicht aufgerufen,
            'wenn die Texteigenschaft neu zugewiesen wird!
            MyBase.Text = Value
        End Set
    End Property

    <Description("Die Elemente im Listenfeld."), _
    Category("Daten"), _
    Browsable(True)> _
    Public ReadOnly Property Items() As ListBox.ObjectCollection
        Get
            Return myListBox.Items
        End Get
    End Property

End Class
