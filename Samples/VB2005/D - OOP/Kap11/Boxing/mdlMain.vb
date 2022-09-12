Interface IMussValueHaben
    Property Value() As Integer
End Interface

Module mdlMain

    Sub Main()
        Dim EinWertetyp As New Wertetyp(10)
        Dim EinVerweistyp As New Verweistyp(10)

        EinWertetyp.Value = 20
        Console.WriteLine(EinWertetyp.Value) ' 20 -> direkt geändert!
        WertetypÄndern(EinWertetyp)
        Console.WriteLine(EinWertetyp.Value) ' 20 -> in der Stackkopie geändert
        VerweistypÄndern(EinVerweistyp)
        Console.WriteLine(EinVerweistyp.Value) ' 30 -> auf dem Managed Heap geändert

        Dim EinInterface As IMussValueHaben = EinWertetyp
        ÜberInterfaceÄndern(EinInterface)
        Console.WriteLine(EinInterface.Value) ' 40, wird auf dem Managed Heap geändert
        Console.WriteLine(EinWertetyp.Value) ' 20, haben nichts miteinander zu tun

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden")
        Console.ReadLine()

    End Sub

    'Ändert die Eigenschaft des Wertetyps
    Sub WertetypÄndern(ByVal EinWertetyp As Wertetyp)
        EinWertetyp.Value = 30
    End Sub

    'Ändert die Eigenschaft des Verweistyps
    Sub VerweistypÄndern(ByVal EinVerweistyp As Verweistyp)
        EinVerweistyp.Value = 30
    End Sub

    'Ändert die Eigenschaft über das Interface
    Sub ÜberInterfaceÄndern(ByVal EinInterface As IMussValueHaben)
        EinInterface.Value = 40
    End Sub

End Module

'Testklasse des Wertetyps
Structure Wertetyp
    Implements IMussValueHaben

    Dim myValue As Integer

    Sub New(ByVal Value As Integer)
        myValue = Value
    End Sub

    Property Value() As Integer Implements IMussValueHaben.Value
        Get
            Return myValue
        End Get
        Set(ByVal Value As Integer)
            myValue = Value
        End Set
    End Property
End Structure

'Testklasse des Verweistyps
Class Verweistyp
    Implements IMussValueHaben

    Dim myValue As Integer

    Sub New(ByVal Value As Integer)
        myValue = Value
    End Sub

    Property Value() As Integer Implements IMussValueHaben.Value
        Get
            Return myValue
        End Get
        Set(ByVal Value As Integer)
            myValue = Value
        End Set
    End Property
End Class

Class WerteList
    Inherits ArrayList

    Shadows Sub Add(ByVal Value As Wertetyp)
        MyBase.Add(Value)
    End Sub

    Default Shadows Property Item(ByVal Index As Integer) As Wertetyp
        Get
            Return DirectCast(MyBase.Item(Index), Wertetyp)
        End Get
        Set(ByVal Value As Wertetyp)
            MyBase.Item(Index) = Value
        End Set
    End Property
End Class

Class VerweisList
    Inherits ArrayList

    Shadows Sub Add(ByVal Value As Verweistyp)
        MyBase.Add(Value)
    End Sub

    Default Shadows Property Item(ByVal Index As Integer) As Verweistyp
        Get
            Return DirectCast(MyBase.Item(Index), Verweistyp)
        End Get
        Set(ByVal Value As Verweistyp)
            MyBase.Item(Index) = Value
        End Set
    End Property
End Class