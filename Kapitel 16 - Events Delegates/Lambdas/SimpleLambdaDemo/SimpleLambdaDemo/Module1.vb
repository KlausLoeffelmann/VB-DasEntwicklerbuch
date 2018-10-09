Module Module1

    Sub Main()

        Dim expressionLambda = Function(square As Double) square * square
        Dim expressionSub = Sub(ValueToPrint As Double) Console.WriteLine(ValueToPrint.ToString)

        '"Druckt" 144 aus. Erst wird 12*12 ausgeführt, dann das Ergebnis ausgegeben.
        expressionSub(expressionLambda(12))

        'Auf Taste warten, damit wir überhaupt was zu sehen bekommen.
        Console.ReadKey()

    End Sub

End Module
