Module mdlMain

    Sub Main()
        Dim locK�rperliste As New DynamicListK�rper(Of K�rperBasis)

        With locK�rperliste
            .Add(New Quader(10, 20, 30))
            .Add(New Pyramide(300, 30))
            .Add(New Pyramide(300, 30))
            .Add(New Quader(20, 10, 30))
        End With
        Console.WriteLine("Das Gesamtvolumen aller K�rper betr�gt:" & _
            locK�rperliste.Gesamtvolumen)

        Console.WriteLine()
        Console.WriteLine("Taste dr�cken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module
