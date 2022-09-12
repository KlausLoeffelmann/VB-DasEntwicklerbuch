Module mdlMain

    Sub Main()

        Dim locLong As ULong
        locLong = &HFFFFFFFFFFFFFFFFUL
        Dim locNS As New NumberSystems(locLong)
        Console.WriteLine("{0:#,##0} entspricht:", locLong)

        locNS.NumberSystem = 2 : Console.WriteLine("Binär: " & locNS.ToString)
        locNS.NumberSystem = 8 : Console.WriteLine("Oktal: " & locNS.ToString)
        locNS.NumberSystem = 10 : Console.WriteLine("Dezimal: " & locNS.ToString)
        locNS.NumberSystem = 16 : Console.WriteLine("Hexadezimal: " & locNS.ToString)
        locNS.NumberSystem = 32 : Console.WriteLine("Duotrigesimal: " & locNS.ToString)

        'Der umgekehrte Weg:
        Console.WriteLine()
        Console.WriteLine("Gegenbeispiel:")
        Console.Write("'7U23085PJGBD9' duotrigesimal entspricht dezimal: ")
        locNS = NumberSystems.Parse("7U23085PJGBD9", 32)
        Console.WriteLine(locNS.Value)

        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden")
        Console.ReadLine()
        Exit Sub

        'Ab hier finden Sie Experimente
        'für den Rest des Strukturen-Kapitels.
        'Spielen Sie ruhig mit den folgenden
        'Zeilen ein wenig herum,
        'um trittsicherer beim Unterschied zwischen
        'Strukturen- und Klasseninstanzen zu werden!

        'Neuen Wertetyp deklarieren und definieren
        Dim Wertetyp1 As New NumberSystems(10)
        'Zweiter Wertetyp wird deklariert durch den ersten definiert
        Dim Wertetyp2 As NumberSystems = Wertetyp1

        'Zweiter Wertetyp bekommt anderen Wert
        Wertetyp2.Value = 20

        'Erster Wertetyp behält alten Wert
        Console.WriteLine(Wertetyp1.Value)
        Console.WriteLine(Wertetyp2.Value)

        'Neuen Verweistyp deklarieren und definieren
        Dim Referenztyp1 As New ReferenzTyp(10)
        'Zweiter Verweistyp wird deklariert durch den ersten definiert
        Dim Referenztyp2 As ReferenzTyp = Referenztyp1

        'Zweiter Verweistyp bekommt anderen Wert
        Referenztyp2.Value = 20

        'Erster damit ebenfalls!!!
        Console.WriteLine(Referenztyp1.Value)

        Wertetyp1 = New NumberSystems(10)
        NimmtWertetyp(Wertetyp1)
        Console.WriteLine(Wertetyp1.Value)
        NimmWerteTypAlsWert(Wertetyp1)
        Console.WriteLine(Wertetyp1.Value)
        Wertetyp2 = Wertetyp1
        Wertetyp2.Value = 50
        Console.WriteLine(Wertetyp1.Value)

        Referenztyp1 = New ReferenzTyp(10)
        NimmtReferenzTyp(Referenztyp1)
        Console.WriteLine(Referenztyp1.Value)


        Console.WriteLine()
        Console.WriteLine("Return drücken zum Beenden")
        Console.ReadLine()

        Dim EinWert As NumberSystems
        Dim EineReferenz As ReferenzTyp

        EinWert.Value = 10
        EineReferenz.Value = 10

    End Sub

    Sub NimmtWertetyp(ByRef Wertetyp As NumberSystems)
        Wertetyp.Value = 99
    End Sub

    Sub NimmWerteTypAlsWert(ByVal Wertetyp As NumberSystems)
        Wertetyp.Value = 101
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