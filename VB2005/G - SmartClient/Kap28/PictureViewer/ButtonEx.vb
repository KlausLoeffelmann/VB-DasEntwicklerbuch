Public Class ButtonEx
    Inherits Button

    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private myDownFlag As Boolean

    Public Event RightClick(ByVal Sender As Object, ByVal e As EventArgs)

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Debug.Print(m.ToString)
        If m.Msg = WM_RBUTTONDOWN Then
            myDownFlag = True
        End If
        If m.Msg = WM_RBUTTONUP And myDownFlag Then
            myDownFlag = False
            OnRightClick(Me, EventArgs.Empty)
        End If
        MyBase.WndProc(m)
    End Sub

    Protected Overridable Sub OnRightClick(ByVal Sender As Object, ByVal e As EventArgs)
        RaiseEvent RightClick(Sender, e)
    End Sub
End Class
