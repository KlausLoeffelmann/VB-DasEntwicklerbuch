Module mdlMain

    Sub Main()
        'Funktioniert nicht, ist in der �u�eren Klasse gekapselt
        Dim �ffentlicheInnereKlasseninstanz As New �ffentlicheInnereKlasse(10)
        'Funktioniert, wird �ber �u�ere Klasse referenziert
        Dim �ffentlicheInnereKlasseninstanz2 As New �u�ereKlasse.�ffentlicheInnereKlasse(10)
        'Funktioniert sowieso nicht, ist privat
        Dim PrivateInnereKlasseninstanz2 As New �u�ereKlasse.PrivateInnereKlasse(10)

    End Sub

End Module

Class �u�ereKlasse

    Dim myValue As Integer

    Private Class PrivateInnereKlasse

        Dim myValue As Integer

        Sub New(ByVal Value As Integer)
            myValue = Value

        End Sub
    End Class

    Public Class �ffentlicheInnereKlasse

        Dim myValue As Integer

        Sub New(ByVal Value As Integer)
            myValue = Value

            'Funktioniert, ist der richtige G�ltigkeitsbereich
            Dim PrivateInnereKlasseninstanz As New PrivateInnereKlasse(10)
            'Funktioniert sowieso, ist �ffentlich
            Dim �ffentlicheInnereKlasseninstanz As New �ffentlicheInnereKlasse(10)


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
    Inherits �u�ereKlasse

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
