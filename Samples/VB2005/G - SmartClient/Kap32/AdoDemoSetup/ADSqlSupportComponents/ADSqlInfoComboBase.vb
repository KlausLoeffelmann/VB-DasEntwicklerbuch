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

        'Wir m�ssen die Combobox jetzt selbst �ffnen, da
        'WM_REFLECTED f�r DropDown nicht mehr ausgel�st wird.
        'Nur dieser Umweg funktioniert, da ein Aufbauen der Liste
        'im durch WM_REFLECTED ausgel�sten OnDropDown-Ereignis
        'die Combobox sofort wieder schlie�t. Der Anwender
        'm�sste die Combobox also zweimal aufmachen.
        Me.DroppedDown = True
    End Sub

    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'WM_LBUTTONDOWN wird f�r die Combobox nur �ber dem DropDown-Button ausgel�st.
        'Das OnDropDownButtonClickedToOpen-Ereignis wird ausgel�st.
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
