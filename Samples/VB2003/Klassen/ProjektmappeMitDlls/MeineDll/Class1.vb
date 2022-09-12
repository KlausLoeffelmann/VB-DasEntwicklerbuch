Public Class Class1

    Protected myValue As Integer

    Sub New(ByVal Value As Integer)
        myValue = Value
    End Sub

    Property Value() As Integer
        Get
            Return myValue
        End Get
        Set(ByVal Value As Integer)
            myValue = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return myValue.ToString()
    End Function

End Class
