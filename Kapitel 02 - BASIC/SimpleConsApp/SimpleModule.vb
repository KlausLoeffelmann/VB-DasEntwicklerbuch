Module Module2

    Sub Main()

        Dim geburtsjahr As Date
        Dim alter As Integer

        Console.Write("Bitte geben Sie ihr Geburtsdatum ein (dd.mm.yyyy): ")
        geburtsjahr = CDate(Console.ReadLine())
        alter = (Now.Subtract(geburtsjahr)).Days \ 365
        Console.Write("Sie sind {0} Jahre alt", alter)
        Console.ReadKey()
    End Sub

End Module

