Public Class Something

    Shared Sub Main()
        Dim test1 As New Something("C"c, 1)
        Dim test2 As New Something("String", 2)
        test1.Foo(10)
        test1.Foo(CInt(10))
        test1.Foo(CLng(10))
        test1.Foo("C"c)
        test1.Foo("C")
        test1.Foo(CChar("c"))
        test1.Foo(CStr("C"))
        test1.Foo(CChar("c"), 1)
        test1.Foo(CStr("C"), 1)
        test1.Foo(1, CChar("c"))
        test1.Foo(1, CStr("C"))
    End Sub

    Sub New(ByVal aChar As String, ByVal aByte As Byte)
        Console.WriteLine("Char/Byte-Konstruktor")
    End Sub

    Sub New(ByVal achar As String, ByVal anInteger As Integer)
        Console.WriteLine("String/Integer-Konstruktor")
    End Sub

    Sub Foo(ByVal l As Integer)
        Console.WriteLine("Foo Integer")
    End Sub

    Sub Foo(ByVal l As Long)
        Console.WriteLine("Foo Long")
    End Sub

    Sub Foo(ByVal l As Char)
        Console.WriteLine("Foo Char")
    End Sub

    Sub Foo(ByVal l As String)
        Console.WriteLine("Foo String")
    End Sub

    Sub Foo(ByVal l As Char, ByVal i As Byte)
        Console.WriteLine("Foo Char/Byte")
    End Sub

    Sub Foo(ByVal l As String, ByVal i As Integer)
        Console.WriteLine("Foo String/Integer")
    End Sub

    Sub Foo(ByVal i As Byte, ByVal l As Char)
        Console.WriteLine("Foo Byte/Char")
    End Sub

    Sub Foo(ByVal i As Integer, ByVal l As String)
        Console.WriteLine("Foo Integer/String")
    End Sub





    Dim mySingle As Single() = {123, 234, 345}

    Public Property XYals() As Single()
        Get
            Return mySingle
        End Get
        Set(ByVal Value As Single())
            mySingle = Value
        End Set
    End Property
End Class