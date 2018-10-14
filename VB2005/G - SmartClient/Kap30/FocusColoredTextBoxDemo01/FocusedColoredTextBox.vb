Public Class FocusedColoredTextBox
    Inherits TextBox

    Private myFocusColor As Color        ' Fokus-Einfärbfarbe (intern)
    Private myOriginalBackcolor As Color ' Zwischenspeicher der ursprünglichen Farbe
    Private myOnFocusColor As Boolean    ' Flag, dass Autofärben bei Fokussierung bestimmt (intern)

    ''' <summary>
    ''' Instanziert eine neue Instanz dieser Klasse
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
        'NIE VERGESSEN, gerade bei Steuerelementen!
        'Den Basiskonstruktor aufrufen!
        MyBase.New()

        'Voreingestellter Wert ist gelb.
        myFocusColor = Color.Yellow

        'Voreingestellt ist: Bei Fokus wird eingefärbt.
        myOnFocusColor = True
    End Sub

    'Überschrieben: Färbt im Bedarfsfall mit FocusColor ein,
    'wenn das Steuerelement den Fokus erhält.
    Protected Overrides Sub OnGotFocus(ByVal e As System.EventArgs)
        MyBase.OnGotFocus(e)
        If OnFocusColor Then
            myOriginalBackcolor = Me.BackColor
            Me.BackColor = FocusColor
        End If
    End Sub

    'Überschrieben: Stellt die Ursprungshintergrundfarbe im,
    'Bedarfsfall wieder her, wenn das Steuerelement den Fokus verliert.
    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        MyBase.OnLostFocus(e)
        If OnFocusColor Then
            Me.BackColor = myOriginalBackcolor
        End If
    End Sub

    ''' <summary>
    ''' Bestimmt oder ermittelt die Farbe, die das Steuerelement automatisch erhält,
    ''' wenn es fokussiert wird, und wenn die OnFocusColor-Eigenschaft gesetzt wurde.
    ''' </summary>
    ''' <value>Die Farbe, die beim Fokussieren verwendet werden soll.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FocusColor() As Color
        Get
            Return myFocusColor
        End Get
        Set(ByVal value As Color)
            myFocusColor = value
        End Set
    End Property

    ''' <summary>
    ''' Bestimmt oder ermittelt, ob das Steuerelement bei Erhalt des Fokus 
    ''' automatisch mit der in FocusColor eingestellten Farbe eingefärbt werden soll.
    ''' </summary>
    ''' <value>True, wenn die Autoeinfärbung aktiviert werden soll.</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OnFocusColor() As Boolean
        Get
            Return myOnFocusColor
        End Get
        Set(ByVal value As Boolean)
            myOnFocusColor = value
        End Set
    End Property
End Class
