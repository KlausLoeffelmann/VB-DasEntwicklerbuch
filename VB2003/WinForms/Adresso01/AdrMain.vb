Public Class AdrMain

    Private Shared myAdressen As Adressen

    <STAThread()> _
    Shared Sub Main()

        'Hier finden in Ihrem Programm die Initialisierungen statt
        myAdressen = Adresse.ZufallsAdressen(50)
        Application.Run(New frmMain)
    End Sub

    Public Shared ReadOnly Property Adressen() As Adressen
        Get
            Return myAdressen
        End Get
    End Property

End Class
