Module mdlMain

    Sub Main()

        Dim locLong As Long

        locLong = &HFFFFFFFFFFFFFFFF
        Dim locNS As New NumberSystems(locLong)
        Console.WriteLine("{0} entspricht:", locLong)
        locNS.NumberSystem = 2 : Console.WriteLine("Binär: " & locNS.ToString)
        locNS.NumberSystem = 8 : Console.WriteLine("Oktal: " & locNS.ToString)
        locNS.NumberSystem = 10 : Console.WriteLine("Dezimal: " & locNS.ToString)
        locNS.NumberSystem = 16 : Console.WriteLine("Hexadezimal: " & locNS.ToString)
        locNS.NumberSystem = 32 : Console.WriteLine("Duotrigesimal: " & locNS.ToString)

        'Gegenbeispiel:
        Console.WriteLine()
        Console.WriteLine("Gegenbeispiel:")
        Console.Write("'7U23085PJGBD9' duotrigesimal entspricht dezimal: ")
        locNS = NumberSystems.Parse("7U23085PJGBD9", 32)
        Console.WriteLine(locNS.Value)

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden")
        Console.ReadLine()
        Exit Sub

    End Sub

    Sub NimmtWertetyp(ByRef Wertetyp As NumberSystems)

        Wertetyp.Value = 99

    End Sub

    Sub NimmtReferenzTyp(ByVal Referenztyp As ReferenzTyp)

        Referenztyp.Value = 99

    End Sub

End Module

Class ReferenzTyp

    Private myUnderlyingValue As Integer

    Sub New(ByVal Value As Integer)
        myUnderlyingValue = Value
    End Sub

    Property Value() As Integer
        Get
            Return myUnderlyingValue
        End Get
        Set(ByVal Value As Integer)
            myUnderlyingValue = Value
        End Set
    End Property
End Class