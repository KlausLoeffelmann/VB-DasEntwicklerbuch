Option Explicit On 
Option Strict On

Public Class HighSpeedTimeGauge

    'Die Routinen brauchen wir zum "Hochgeschwindigkeitsmessen" aus dem Kernel
    Declare Auto Function QueryPerformanceFrequency Lib "Kernel32" (ByRef lpFrequency As Long) As Boolean
    Declare Auto Function QueryPerformanceCounter Lib "Kernel32" (ByRef lpPerformanceCount As Long) As Boolean

    'So ginge es übrigens auch:
    '<System.Runtime.InteropServices.DllImport("KERNEL32")> _
    'Private Shared Function QueryPerformanceCounter(ByRef lpPerformanceCount As Long) As Boolean
    'End Function

    '<System.Runtime.InteropServices.DllImport("KERNEL32")> _
    'Private Shared Function QueryPerformanceFrequency(ByRef lpFrequency As Long) As Boolean
    'End Function

    Private myStartValue As Long = 0
    Private myEndValue As Long = 0
    Private myDuration As Long = 0
    Private myFrequency As Long = 0

    Public Sub New()

        QueryPerformanceFrequency(myFrequency)

    End Sub

    Public Sub Start()

        myStartValue = 0
        QueryPerformanceCounter(myStartValue)

    End Sub

    Public Sub [Stop]()

        myEndValue = 0
        QueryPerformanceCounter(myEndValue)
        myDuration = myEndValue - myStartValue

    End Sub

    Public Sub Reset()

        myStartValue = 0
        myEndValue = 0
        myDuration = 0

    End Sub

    Public ReadOnly Property DurationInSeconds() As Double
        Get
            Return CDbl(myDuration) / CDbl(myFrequency)
        End Get
    End Property

    Public ReadOnly Property DurationInMilliSeconds() As Long

        Get
            Return CLng(1000 * DurationInSeconds)
        End Get

    End Property

    Public ReadOnly Property Frequency() As Long

        Get
            Return myFrequency
        End Get

    End Property

    Public Overrides Function ToString() As String
        Return DurationInMilliSeconds & " Millisekunden"
    End Function

End Class
