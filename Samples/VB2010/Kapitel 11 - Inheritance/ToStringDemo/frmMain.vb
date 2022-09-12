'Der Formularcode
Public Class frmMain

    Private Sub btnKontaktHinzufügen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKontaktHinzufügen.Click

        'Neues Kontaktobjekt instanzieren und es mit den Inhalten
        'der Textbox füllen
        Dim locKontakt As New Kontakt(txtVorname.Text, txtNachname.Text)

        'Der Listbox hinzufügen
        lstKontakte.Items.Add(locKontakt)
    End Sub
End Class

'Die Kontakt-Klasse
Public Class Kontakt

    Private myVorname As String
    Private myNachname As String

    Sub New(ByVal Vorname As String, ByVal Nachname As String)
        myVorname = Vorname
        myNachname = Nachname
    End Sub

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal value As String)
            myVorname = value
        End Set
    End Property

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal value As String)
            myNachname = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Nachname & ", " & Vorname
    End Function
End Class
