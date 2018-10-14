Module mdlMain

    Sub Main()

        Dim locGauge As New HighSpeedTimeGauge
        Dim locLoops As Integer = 25000000

        For durchläufe As Integer = 1 To 10
            locGauge.Start()
            For z As Integer = 1 To locLoops
                Dim locWertTyp As Wertetyp = New Wertetyp(3.14)
                Dim locWertTyp2 As Wertetyp = New Wertetyp(3.15) '*
                locWertTyp.CopyValue(locWertTyp2)                '*
                'locWertTyp.CopyValue(New Wertetyp(3.15))        
                'If locWertTyp.Value = locWertTyp2.Value Then Exit For
            Next
            locGauge.Stop()
            Console.WriteLine("{0} Funktionsaufrufe mit Wertetyp {1} Millisekunden.", _
                                locLoops, locGauge.DurationInMilliSeconds)
            locGauge.Reset()
            locGauge.Start()
            For z As Integer = 1 To locLoops
                Dim locRefTyp As ReferenzTyp = New ReferenzTyp(3.14)
                Dim locRefTyp2 As ReferenzTyp = New ReferenzTyp(3.15)
                locRefTyp.CopyValue(locRefTyp2)
                'locRefTyp.CopyValue(New ReferenzTyp(3.15))
                'If locRefTyp.Value = locRefTyp2.Value Then Exit For
            Next
            locGauge.Stop()
            Console.WriteLine("{0} Funktionsaufrufe mit Referenztyp {1} Millisekunden.", _
                                locLoops, locGauge.DurationInMilliSeconds)

            locGauge.Reset()
        Next durchläufe

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden!")
        Console.ReadLine()

    End Sub

End Module

Public Class ReferenzTyp

    'Private myValue As Double
    Private myValue As Double

    Sub New(ByVal Value As Double)
        myValue = Value
    End Sub

    Property Value() As Double
        Get
            Return myValue
        End Get
        Set(ByVal Value As Double)
            myValue = Value
        End Set
    End Property

    Sub CopyValue(ByVal ToCopy As ReferenzTyp)
        myValue = ToCopy.Value
    End Sub

End Class

Public Structure Wertetyp

    Private myValue As Double

    Sub New(ByVal Value As Double)
        myValue = Value
    End Sub

    Property Value() As Double
        Get
            Return myValue
        End Get
        Set(ByVal Value As Double)
            myValue = Value
        End Set
    End Property

    Sub CopyValue(ByVal ToCopy As Wertetyp)
        myValue = ToCopy.Value
    End Sub

End Structure
