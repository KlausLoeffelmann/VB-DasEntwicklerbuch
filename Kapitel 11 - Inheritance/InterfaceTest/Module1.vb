Interface IBaseInterface
    Property EineEigenschaft() As String
End Interface

Interface IMoreComplexInterface
    Property ZweiteEigenschaft() As String
End Interface

Public Class ComplexClass
    Implements IBaseInterface, IMoreComplexInterface

    Public Property EineEigenschaft() As String Implements IBaseInterface.EineEigenschaft
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property ZweiteEigenschaft() As String Implements IMoreComplexInterface.ZweiteEigenschaft
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class


Interface ITest
    Function EineMethode() As Integer
    Function ZweiteMethode() As String
    Function ToString() As String
End Interface

MustInherit Class AbstractTest
    Public MustOverride Property EineEigenschaft() As String
    Public MustOverride Function EineMethode(ByVal EinParameter As String) As String
End Class

Public Class BasiertAufAbstractTest
    Inherits AbstractTest

    Public Overrides Property EineEigenschaft() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Overrides Function EineMethode(ByVal EinParameter As String) As String

    End Function
End Class

Public Class BindetITestEin
    Implements ITest

    Public Property EineEigenschaft() As String Implements ITest.EineEigenschaft
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Function EineMethode() As Integer Implements ITest.EineMethode

    End Function

    Public Function ZweiteMethode() As String Implements ITest.ZweiteMethode

    End Function

    Public Overrides Function ToString() As String Implements ITest.ToString
        Return MyBase.ToString
    End Function

End Class

Module Module1

    Sub Main()

    End Sub

End Module
