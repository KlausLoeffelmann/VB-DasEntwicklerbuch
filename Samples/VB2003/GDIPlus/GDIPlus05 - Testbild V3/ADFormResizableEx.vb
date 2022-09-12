Public Class ADFormResizableEx
    Inherits System.Windows.Forms.Form

    'Damit wir wissen, welches Ereignis
    'gerade passiert
    Private Enum SizeMoveMode
        None
        Sizing
        Moving
    End Enum

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'ADFormResizableEx
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "ADFormResizableEx"
        Me.Text = "ADFormResizableEx"

    End Sub

#End Region

    'Diese Ereignisse gibt es
    Event ResizeBegin(ByVal sender As Object, ByVal e As EventArgs)
    Event ResizeEnd(ByVal sender As Object, ByVal e As EventArgs)
    Event MoveBegin(ByVal sender As Object, ByVal e As EventArgs)
    Event MoveEnd(ByVal sender As Object, ByVal e As EventArgs)

    'Nachrichtennamen verbergen die nüchternen Nummern
    '(geklaut aus der WinUser.H der C++-Include-Dateien)
    Private Const WM_ENTERSIZEMOVE As Integer = &H231
    Private Const WM_EXITSIZEMOVE As Integer = &H232
    Private Const WM_SIZING As Integer = &H214
    Private Const WM_MOVING As Integer = &H216

    'Dieser Member merkt sich den gerade stattfindenden Vorgang
    Private myCurrentSizeMoveMode As SizeMoveMode
    'Dieser Member merkt sich, ob der Startschuss bereits fiel
    Private mySizingMovingInProgress As Boolean

    Protected Overridable Sub OnResizeBegin(ByVal e As EventArgs)
        RaiseEvent ResizeBegin(Me, e)
    End Sub

    Protected Overridable Sub OnResizeEnd(ByVal e As EventArgs)
        RaiseEvent ResizeBegin(Me, e)
    End Sub

    Protected Overridable Sub OnMoveBegin(ByVal e As EventArgs)
        RaiseEvent MoveBegin(Me, e)
    End Sub

    Protected Overridable Sub OnMoveEnd(ByVal e As EventArgs)
        RaiseEvent MoveBegin(Me, e)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'Startschuss für eine der Aktionen gefallen?
        If m.Msg = WM_ENTERSIZEMOVE Then
            'Ja, merken!
            mySizingMovingInProgress = True
            'Aktion abgebrochen?
        ElseIf m.Msg = WM_EXITSIZEMOVE Then
            'Ist gerade am Vergrößern/Verkleinern?
            If myCurrentSizeMoveMode = SizeMoveMode.Sizing Then
                '--> ResizeEnd
                OnResizeEnd(EventArgs.Empty)
            ElseIf myCurrentSizeMoveMode = SizeMoveMode.Moving Then
                'sonst --> MoveEnd
                OnMoveEnd(EventArgs.Empty)
            End If
            'Keine Aktion mehr "unterwegs"
            mySizingMovingInProgress = False
            myCurrentSizeMoveMode = SizeMoveMode.None
        Else
            'Alle anderen Ereigniss behandln
            'Startschuss schon gefallen?
            If mySizingMovingInProgress Then
                'Ereignis schonmal ausgelöst?
                If myCurrentSizeMoveMode = SizeMoveMode.None Then
                    'Vergrößern gestartet?
                    If m.Msg = WM_SIZING Then
                        'Nein --> feuer frei für Vergrößern/Verkleinern
                        myCurrentSizeMoveMode = SizeMoveMode.Sizing
                        OnResizeBegin(EventArgs.Empty)
                    ElseIf m.Msg = WM_MOVING Then
                        'Nein --> feuer frei für Verschieben
                        myCurrentSizeMoveMode = SizeMoveMode.Moving
                        OnMoveBegin(EventArgs.Empty)
                    End If
                End If
            End If
        End If
        'WICHTIG, WICHTIG, WICHTIG!!!
        'Basis aufrufen, sonst geht goar nix!
        MyBase.WndProc(m)
    End Sub
End Class

