Module mdlMain

    Sub Main()

        Dim locTestKlasse As New TestKlasse("Dies ist ein Test")
        Console.WriteLine(locTestKlasse.AlteEigenschaft)
        Console.WriteLine(locTestKlasse.NeueEigenschaft)
        Console.ReadLine()

    End Sub

End Module

Public Class TestKlasse

    Dim myEigenschaft As String

    Sub New(ByVal einString As String)
        myEigenschaft = einString
    End Sub

    'Alte Version. Diese Eigenschaft ist obsolet
    <Obsolete("Sie sollten die AlteEigenschaft-Eigenschaft nicht mehr verwenden. " + _
              "Verwenden Sie stattdessen NeueEigenschaft", False)> _
    Property AlteEigenschaft() As String
        Get
            Return myEigenschaft
        End Get
        Set(ByVal Value As String)
            myEigenschaft = Value
        End Set
    End Property

    Property NeueEigenschaft() As String
        Get
            Return myEigenschaft
        End Get
        Set(ByVal Value As String)
            myEigenschaft = Value
        End Set
    End Property
End Class
