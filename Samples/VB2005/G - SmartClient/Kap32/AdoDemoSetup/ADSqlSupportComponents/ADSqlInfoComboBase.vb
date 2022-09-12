Public MustInherit Class ADSqlInfoComboBase
    Inherits ComboBox

    Private myQueryInfoOnDropDown As Boolean

    Sub New()
        MyBase.New()
    End Sub

    Protected Overridable Sub OnDropDownButtonClickedToOpen(ByVal e As System.EventArgs)

        If QueryInfoOnDropDown Then
            If Me.Items.Count = 0 Then
                PopulateItemsInternal()
            End If
        End If

        'Wir müssen die Combobox jetzt selbst öffnen, da
        'WM_REFLECTED für DropDown nicht mehr ausgelöst wird.
        'Nur dieser Umweg funktioniert, da ein Aufbauen der Liste
        'im durch WM_REFLECTED ausgelösten OnDropDown-Ereignis
        'die Combobox sofort wieder schließt. Der Anwender
        'müsste die Combobox also zweimal aufmachen.
        Me.DroppedDown = True
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'WM_LBUTTONDOWN wird für die Combobox nur über dem DropDown-Button ausgelöst.
        'Das OnDropDownButtonClickedToOpen-Ereignis wird ausgelöst.
        If m.Msg = &H201 Then
            If Not Me.DroppedDown Then
                OnDropDownButtonClickedToOpen(EventArgs.Empty)
                Return
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Public Property QueryInfoOnDropDown() As Boolean
        Get
            Return myQueryInfoOnDropDown
        End Get
        Set(ByVal value As Boolean)
            myQueryInfoOnDropDown = value
        End Set
    End Property

    Protected Overridable Sub PopulateItemsInternal()
        If Me.Items IsNot Nothing Then
            Me.Items.Clear()
        End If
    End Sub

    Public Sub PopulateInfoItemsManually()
        PopulateItemsInternal()
    End Sub
End Class
