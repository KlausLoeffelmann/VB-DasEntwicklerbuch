Module Module1

    Sub Main()
        Dim locEigenschaftenTest As New EigenschaftenTest("Text f�r Eigenschaft")

        'Das Auslesen der Eigenschaft ist problemlos m�glich
        Console.WriteLine("Eigenschaft enth�lt: " & locEigenschaftenTest.EineEigenschaft)

        'Der Set-Zugriffsmodifizierer verbietet aber das Schreiben,
        'weil er 'private' ist.
        locEigenschaftenTest.EineEigenschaft = "Neuer Text"
    End Sub

End Module

Public Class EigenschaftenTest

    Private myEineEigenschaft As String

    Sub New(ByVal textF�rEigenschaft As String)
        'Ist erlaubt - die Klasse darf die
        'Eigenschaft beschreiben!
        EineEigenschaft = textF�rEigenschaft
    End Sub

    Public Property EineEigenschaft() As String
        Get
            Return myEineEigenschaft
        End Get
        Private Set(ByVal value As String)
            myEineEigenschaft = value
        End Set
    End Property

End Class


