Imports Activedev.SqlSupport
Imports System.Data
Imports System.Data.SqlClient

Public Class ADSqlInstanceConnectionDialog

    Protected myConnectionBuilder As SqlConnectionStringBuilder

    Public Function GetConnectionBuilder() As SqlConnectionStringBuilder
        myConnectionBuilder = Nothing
        Me.ShowDialog()
        If Me.DialogResult = Windows.Forms.DialogResult.OK Then
            Return myConnectionBuilder
        Else
            Return Nothing
        End If
    End Function

    Public Function GetConnectionBuilder(ByVal DialogTitel As String) As SqlConnectionStringBuilder
        Me.Text = DialogTitel
        Return GetConnectionBuilder()
    End Function

    Protected Overridable Function BuildConnectionBuilder() As SqlConnectionStringBuilder

        Dim locConnectionBuilder As SqlConnectionStringBuilder

        locConnectionBuilder = New SqlConnectionStringBuilder
        locConnectionBuilder.DataSource = SqlServerConnector.Text
        If SqlServerConnector.CredentialMethod = SqlCredentialMethods.WindowsIntegratedSecurity Then
            locConnectionBuilder.IntegratedSecurity = True
        Else
            locConnectionBuilder.IntegratedSecurity = False
            locConnectionBuilder.UserID = SqlServerConnector.CredentialParameters.UserID
            locConnectionBuilder.Password = SqlServerConnector.CredentialParameters.Password
        End If
        Return locConnectionBuilder

    End Function

    Protected Overridable Sub OnParametersChanged()
        If SqlServerConnector.Text = "" Then
            myConnectionBuilder = Nothing
            Return
        End If
        myConnectionBuilder = BuildConnectionBuilder()
        'TODO: RegEx-Objekt, dass das Passwort unleserlich macht.
        txtLoginString.Text = myConnectionBuilder.ToString
    End Sub

    Private Sub SqlServerConnector_ParametersChanges(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SqlServerConnector.ParametersChanged
        OnParametersChanged()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestConnection.Click
        Dim locConnection As New SqlConnection(myConnectionBuilder.ToString)
        Dim locMessage As String = "Die Verbindung konnte erfolgreich hergestellt werden!"
        Dim locIcon As MessageBoxIcon = MessageBoxIcon.Exclamation
        Using locConnection
            Try
                locConnection.Open()
            Catch ex As Exception
                locMessage = "Verbindungsherstellung war nicht möglich!" & _
                    vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & _
                    ex.StackTrace
                locIcon = MessageBoxIcon.Error
            End Try
        End Using
        MessageBox.Show(locMessage, "Verbindungstest:", MessageBoxButtons.OK, locIcon)
    End Sub
End Class