Public Class ADSQLServerConnector

    Private myOldInstance As String
    Private mySkipEvent As Boolean

    Public Event ParametersChanged(ByVal sender As Object, ByVal e As EventArgs)

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AssignCheckedStates()
    End Sub

    Private Sub chkUseSXDefaultInstance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseSXDefaultInstance.CheckedChanged

        If mySkipEvent Then
            mySkipEvent = False
            Return
        End If

        mySkipEvent = True
        If chkUseSXDefaultInstance.Checked Then
            myOldInstance = InstanceCombo.Text
            If InstanceCombo.Text = "" Then
                InstanceCombo.Text = ".\SQLEXPRESS"
            Else
                If InstanceCombo.Text.IndexOfAny(New Char() {"\"c, "/"c}) = -1 Then
                    InstanceCombo.Text &= "\SQLEXPRESS"
                Else
                    Dim locStrArr() As String
                    locStrArr = InstanceCombo.Text.Split(New Char() {"\"c, "/"c})
                    InstanceCombo.Text = locStrArr(0) & "\SQLEXPRESS"
                End If
            End If
        Else
            If InstanceCombo.Text <> myOldInstance Then
                InstanceCombo.Text = myOldInstance
            Else
                mySkipEvent = False
            End If
        End If
        OnParametersChanged()
    End Sub

    Private Sub optUseMixedMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optUseMixedMode.CheckedChanged
        AssignCheckedStates()
        OnParametersChanged()
    End Sub

    Protected Sub OnParametersChanged()
        RaiseEvent ParametersChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub AssignCheckedStates()
        lblPassword.Enabled = optUseMixedMode.Checked
        lblUserID.Enabled = optUseMixedMode.Checked
        txtPassword.Enabled = optUseMixedMode.Checked
        txtUserID.Enabled = optUseMixedMode.Checked
    End Sub

    Private Sub InstanceCombo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstanceCombo.TextChanged
        If mySkipEvent Then
            mySkipEvent = False
            Return
        End If

        myOldInstance = InstanceCombo.Text
        chkUseSXDefaultInstance.Checked = False
        OnParametersChanged()
    End Sub

    Public ReadOnly Property SqlInstance() As SqlInstanceItem
        Get
            Return InstanceCombo.SqlInstance
        End Get
    End Property

    Public Overrides Property Text() As String
        Get
            Return InstanceCombo.Text
        End Get
        Set(ByVal value As String)
            InstanceCombo.Text = MyBase.Text
        End Set
    End Property

    Public Property CredentialMethod() As SqlCredentialMethods
        Get
            If optUseIntegratedSecurity.Checked Then
                Return SqlCredentialMethods.WindowsIntegratedSecurity
            Else
                Return SqlCredentialMethods.MixedMode
            End If
        End Get
        Set(ByVal value As SqlCredentialMethods)
            If value = SqlCredentialMethods.WindowsIntegratedSecurity Then
                optUseIntegratedSecurity.Checked = True
            Else
                optUseMixedMode.Checked = True
            End If
        End Set
    End Property

    Public Property CredentialParameters() As SqlMixedModeCredentialParameters
        Get
            Return New SqlMixedModeCredentialParameters(txtUserID.Text, txtPassword.Text)
        End Get
        Set(ByVal value As SqlMixedModeCredentialParameters)
            If value Is Nothing Then
                txtPassword.Text = ""
                txtUserID.Text = ""
            Else
                txtPassword.Text = value.Password
                txtUserID.Text = value.UserID
            End If
        End Set
    End Property

    Private Sub txtCredential_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserID.TextChanged, txtPassword.TextChanged
        OnParametersChanged()
    End Sub
End Class
