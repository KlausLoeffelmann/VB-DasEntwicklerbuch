Module mdlMain

    Sub Main()
        '"Normales" Objekt, könnte problemlos finalisiert werden
        Dim locTest1 As New Testklasse(False, "Erstes Testobjekt")
        'Der Störenfried, da Warteschleifenflag gesetzt
        Dim locTest2 As New Testklasse(True, "Zweites Testobjekt")
    End Sub

End Module

Class Testklasse

    'Dieses Flag steuert den Einstieg in die Warteschleife
    Private myWaitInFinalize As Boolean
    'Eine Eigenschaft zum Unterscheiden von Klasseninstanzen
    Private myName As String

    'Flag für's Warten und den Namen definieren
    Sub New(ByVal WaitInFinalize As Boolean, ByVal Name As String)
        myWaitInFinalize = WaitInFinalize
        myName = Name
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()

        'Nur, wenn das Flag bei New gesetzt 
        'wurde, in die Warteschleife springen
        If myWaitInFinalize Then

            Dim locSecs As Integer
            Dim lastSec As Integer
            lastSec = Now.Second
            Do
                'Jede Sekunde eine Meldung ausgeben
                If lastSec <> Now.Second Then
                    lastSec = Now.Second
                    locSecs += 1
                    Console.WriteLine("Warte bereits {0} Sekunden", locSecs)
                    'Nach 60 Sekunden wäre Schluss
                    If locSecs = 60 Then Exit Do
                End If
            Loop

        End If
        'Erfolgreich finalisiert --> Meldung ausgeben
        Console.WriteLine("Objekt {0} wurde finalisiert!", myName)
    End Sub
End Class