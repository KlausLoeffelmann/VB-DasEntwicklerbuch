Imports System.Runtime.InteropServices

Module mdlMain

    Sub Main()
        'Zur Bedeutung der Zeichenkette, der den höchsten
        'positiv darstellbaren 64-Bit-Wert als Konstante darstellt:
        ' ------ Hexdarstellung mit &H ----------- als 'U'nsigned 'L'ong
        Dim locLongEx As New LongEx(&HFEA912340000FFFFUL)
        Console.WriteLine("Wert von locLongEx: " & locLongEx.Value.ToString("#,##0"))
        Console.WriteLine("Vorzeichenbehaftet: " & locLongEx.SignedLong.ToString("#,##0"))
        Console.WriteLine("Oberer Integerteil, vorzeichenlos: " & locLongEx.HighUnsignedInt.ToString("#,##0"))
        Console.WriteLine("Unterer Integerteil, vorzeichenlos: " & locLongEx.LowUnsignedInt.ToString("#,##0"))
        Console.WriteLine("Oberer Integerteil, vorzeichenbehaftet: " & locLongEx.HighSignedInt.ToString("#,##0"))
        Console.WriteLine("Unterer Integerteil, vorzeichenbehaftet: " & locLongEx.LowSignedInt.ToString("#,##0"))
        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module

'Mitteilen, dass die Reihenfolge der
'Bytedefinitionen strikt einzuhalten ist!
<StructLayout(LayoutKind.Explicit)> _
Public Structure LongEx
    <FieldOffset(0)> Private myUnsignedLong As ULong
    <FieldOffset(0)> Private mySignedLong As Long
    <FieldOffset(0)> Private myLowUnsignedInt As UInteger
    <FieldOffset(4)> Private myHighUnsignedInt As UInteger
    <FieldOffset(0)> Private myLowSignedInt As Integer
    <FieldOffset(4)> Private myHighSignedInt As Integer

    Sub New(ByVal Value As ULong)
        myUnsignedLong = Value
    End Sub

    Sub New(ByVal Value As Long)
        mySignedLong = Value
    End Sub

    Sub New(ByVal value As UInteger)
        myLowUnsignedInt = value
    End Sub

    Sub New(ByVal value As Integer)
        myLowSignedInt = value
    End Sub

    Public Property Value() As ULong
        Get
            Return myUnsignedLong
        End Get
        Set(ByVal value As ULong)
            myUnsignedLong = value
        End Set
    End Property

    Public ReadOnly Property SignedLong() As Long
        Get
            Return mySignedLong
        End Get
    End Property

    Public ReadOnly Property HighUnsignedInt() As UInteger
        Get
            Return myHighUnsignedInt
        End Get
    End Property

    Public ReadOnly Property LowUnsignedInt() As UInteger
        Get
            Return myLowUnsignedInt
        End Get
    End Property

    Public ReadOnly Property HighSignedInt() As Integer
        Get
            Return myHighSignedInt
        End Get
    End Property

    Public ReadOnly Property LowSignedInt() As Integer
        Get
            Return myLowSignedInt
        End Get
    End Property
End Structure


