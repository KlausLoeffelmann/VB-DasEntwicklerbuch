Imports System.Threading

Module mdlMain

    Dim varModule As Integer = 5

    Sub New()

    End Sub

    Sub Main()
        Dim locSingleton As Singleton = Singleton.GetInstance()
        Dim locSingleton2 As Singleton = Singleton.GetInstance()

        Console.WriteLine(locSingleton Is locSingleton2)
    End Sub

    Property test() As Integer
        Get

        End Get
        Set(ByVal Value As Integer)

        End Set
    End Property

End Module

Module anderes

    Sub Schreibwas()
        Console.WriteLine(varModule)
    End Sub
End Module

Class Singleton

    Private Shared locSingleton As Singleton
    Private Shared locMutex As New Mutex

    'Konstruktor ist privat,
    'damit kann die Klasse nur von "sich selbst" instanziert werden
    Private Sub New()

    End Sub

    'GetInstance gibt eine Singleton-Instanz zurück
    'Nur durch diese Funktion kann die Klasse instanziert werden
    Public Shared Function GetInstance() As Singleton
        'Vorgang Thread-sicher machen
        'Wartet, bis ein anderer Thread, der diese Klasse
        'instanziert, damit fertig ist
        locMutex.WaitOne()
        Try
            If locSingleton Is Nothing Then
                locSingleton = New Singleton
            End If
        Finally
            'Instanzieren abgeschlossen,
            '...kann weiter gehen...
            locMutex.ReleaseMutex()
        End Try

        'Instanz zurückliefern
        Return locSingleton

    End Function

End Class
