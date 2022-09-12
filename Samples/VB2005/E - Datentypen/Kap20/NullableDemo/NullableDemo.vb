Module NullableDemo

    Sub Main()
        Dim locObj As Object
        Dim locNullOfInt As Nullable(Of Integer) = Nothing



        'Es gibt natürlich eine verwendbare Instanz, denn
        'Nullable(of ) ist ein Wertetyp!
        Console.WriteLine("Hat locNullOfInt einen Wert:" & locNullOfInt.HasValue)

        'Und dennoch ergibt das folgende Konstrukt True,
        'als würde locObj keine Referenz haben!
        locObj = locNullOfInt
        Console.WriteLine("Ist locObj Nothing?" & (locObj Is Nothing).ToString)
        Console.WriteLine()

        'Und auch das "Entboxen" geht!
        'Es gibt keine Null-Exception!
        locNullOfInt = DirectCast(locObj, Nullable(Of Integer))

        'Und geht das dann auch? - Natürlich!
        locNullOfInt = DirectCast(Nothing, Nullable(Of Integer))

        'Und noch weiter. Wir boxen einen Nullable(of Integer)
        locNullOfInt = 10
        '
        locObj = locNullOfInt
        Dim locInt As Integer = DirectCast(locObj, Integer)

        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()

        'Das geht übrigens nicht, obwohl Nullable die Contraits-Einschränkung im 
        'Grunde genommen erfüllt!
        'Dim locNullOfInt As Nullable(Of Nullable(Of Integer))
    End Sub
End Module
