Module mdlMain

    Sub Main()
        'Funktioniert nicht, ist in der äußeren Klasse gekapselt
        Dim ÖffentlicheInnereKlasseninstanz As New ÖffentlicheInnereKlasse(10)
        'Funktioniert, wird über Äußere Klasse referenziert
        Dim ÖffentlicheInnereKlasseninstanz2 As New ÄußereKlasse.ÖffentlicheInnereKlasse(10)
        'Funktioniert sowieso nicht, ist privat
        Dim PrivateInnereKlasseninstanz2 As New ÄußereKlasse.PrivateInnereKlasse(10)

    End Sub

End Module

Class ÄußereKlasse

    Dim myValue As Integer

    Private Class PrivateInnereKlasse

        Dim myValue As Integer

        Sub New(ByVal Value As Integer)
            myValue = Value

        End Sub
    End Class

    Public Class ÖffentlicheInnereKlasse

        Dim myValue As Integer

        Sub New(ByVal Value As Integer)
            myValue = Value

            'Funktioniert, ist der richtige Gültigkeitsbereich
            Dim PrivateInnereKlasseninstanz As New PrivateInnereKlasse(10)
            'Funktioniert sowieso, ist öffentlich
            Dim ÖffentlicheInnereKlasseninstanz As New ÖffentlicheInnereKlasse(10)


        End Sub
    End Class

    Sub New(ByVal Value As Integer)
        myValue = Value
    End Sub

    Public Overridable Property Value() As Integer
        Get
            Return myValue
        End Get
        Set(ByVal Value As Integer)
            myValue = Value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Class Klasse2
    Inherits ÄußereKlasse

    Sub New()
        MyBase.New(0)
    End Sub

    Public Overrides Property Value() As Integer
        Get

        End Get
        Set(ByVal Value As Integer)

        End Set
    End Property
End Class
