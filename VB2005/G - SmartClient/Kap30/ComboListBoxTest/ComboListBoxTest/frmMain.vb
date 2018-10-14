Public Class frmMain

    Private Sub btnMitDatenFüllen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMitDatenFüllen.Click
        With AdComboListBox1
            .Items.Add(New KurzAdresse(122, "Mayer", "Franz"))
            .Items.Add(New KurzAdresse(121, "Meier", "Heinz"))
            .Items.Add(New KurzAdresse(125, "Meier", "Franz"))
            .Items.Add(New KurzAdresse(122, "Löffler", "Heiner"))
            .Items.Add(New KurzAdresse(121, "Loffler", "Marianne"))
            .Items.Add(New KurzAdresse(125, "Löffelmann", "Klaus"))
            .Items.Add(New KurzAdresse(125, "Lörwald", "Uta"))
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Dispose()
    End Sub
End Class

Public Class KurzAdresse

    Private myNachname As String
    Private myVorname As String
    Private myID As Integer

    Sub New(ByVal ID As Integer, ByVal Nachname As String, ByVal Vorname As String)
        myID = ID
        myNachname = Nachname
        myVorname = Vorname
    End Sub

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal Value As String)
            myNachname = Value
        End Set
    End Property

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Nachname + ", " + Vorname + " : " + myID.ToString
    End Function

End Class
