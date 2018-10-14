Imports System.Runtime.InteropServices

'Mitteilen, dass die Reihenfolge der
'Bytedefinitionen strikt einzuhalten ist!
<StructLayout(LayoutKind.Explicit)> _
Public Structure LongEx

    <FieldOffset(0)> Private myLong As Long
    <FieldOffset(0)> Private myULong As UInt64
    <FieldOffset(0)> Private myUInt As UInt32
    <FieldOffset(0)> Private myLowDWord As Integer
    <FieldOffset(4)> Private myHighDWord As Integer
    <FieldOffset(0)> Private myLowWord As Short
    <FieldOffset(2)> Private myHighWord As Short
    <FieldOffset(4)> Private myHighDWordLowWord As Short
    <FieldOffset(6)> Private myHighDWordHighWord As Short
    <FieldOffset(0)> Private myLowByte As Byte
    <FieldOffset(1)> Private myHighByte As Byte
    <FieldOffset(0)> Private myWord As Short
    <FieldOffset(0)> Private myDWord As Integer

    Sub New(ByVal a_Byte As Byte)
        myLong = a_Byte
    End Sub

    Sub New(ByVal a_Word As Short)
        myLong = a_Word
    End Sub

    Sub New(ByVal a_DWord As Integer)
        myLong = a_DWord
    End Sub

    Sub New(ByVal a_Long As Long)
        myLong = a_Long
    End Sub

    Property [Long]() As Long
        Get
            Return myLong
        End Get

        Set(ByVal Value As Long)
            myLong = Value
        End Set
    End Property

    Property ULong() As UInt64
        Get
            Return myULong
        End Get

        Set(ByVal Value As UInt64)
            myULong = Value
        End Set
    End Property

    Property UInt() As UInt32
        Get
            Return myUInt
        End Get
        Set(ByVal Value As UInt32)
            myUInt = Value
        End Set
    End Property


    Property DWord() As Integer
        Get
            Return myDWord
        End Get

        Set(ByVal Value As Integer)
            Value = DWord
        End Set
    End Property

    Property Word() As Short
        Get
            Return myWord
        End Get

        Set(ByVal Value As Short)
            Value = Value
        End Set
    End Property

    'Ist redundant, da das gleiche wie DWord, 
    'aber die Konsistenz...!
    Property LowDWord() As Integer
        Get
            Return myLowDWord
        End Get

        Set(ByVal Value As Integer)
            myLowDWord = Value
        End Set
    End Property

    Property HighDWord() As Integer
        Get
            Return myHighDWord
        End Get

        Set(ByVal Value As Integer)
            myHighDWord = Value
        End Set
    End Property

    Property LowWord() As Short
        Get
            Return myLowWord
        End Get

        Set(ByVal Value As Short)
            myLowWord = Value
        End Set
    End Property

    Property HighWord() As Short
        Get
            Return myHighWord
        End Get

        Set(ByVal Value As Short)
            myHighWord = Value
        End Set
    End Property

    Property HighDWordLowWord() As Short
        Get
            Return myHighDWordLowWord
        End Get

        Set(ByVal Value As Short)
            myHighDWordLowWord = Value
        End Set
    End Property

    Property HighDWordHighWord() As Short
        Get
            Return myHighDWordHighWord
        End Get

        Set(ByVal Value As Short)
            myHighDWordHighWord = Value
        End Set
    End Property

    Property LowByte() As Byte
        Get
            Return myLowByte
        End Get

        Set(ByVal Value As Byte)
            myLowByte = Value
        End Set
    End Property

    Property HighByte() As Byte
        Get
            Return myHighByte
        End Get

        Set(ByVal Value As Byte)
            Value = myHighByte
        End Set
    End Property

End Structure
