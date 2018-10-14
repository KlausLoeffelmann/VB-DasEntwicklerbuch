Imports System.Threading

Public Class AdrMain

    Private Shared myAdressen As Adressen

    <STAThread()> _
    Shared Sub Main()

        Dim locFrmSplash As New frmSplash
        locFrmSplash.Show()
        locFrmSplash.Refresh()
        'Hier finden in Ihrem Programm die Initialisierungen statt
        myAdressen = Adresse.ZufallsAdressen(50)
        '2 Sekunden warten, sonst sieht man das tolle Bild gar nicht...
        '(Thanks, Gareth!)
        Thread.CurrentThread.Sleep(1000)
        locFrmSplash.Dispose()
        Application.Run(New frmMain)
    End Sub

    Public Shared ReadOnly Property Adressen() As Adressen
        Get
            Return myAdressen
        End Get
    End Property

End Class
