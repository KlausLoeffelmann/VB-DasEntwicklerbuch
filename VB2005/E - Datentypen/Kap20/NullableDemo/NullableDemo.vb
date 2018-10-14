Module NullableDemo

    Sub Main()
        Dim locObj As Object
        Dim locNullOfInt As Nullable(Of Integer) = Nothing



        'Es gibt nat�rlich eine verwendbare Instanz, denn
        'Nullable(of ) ist ein Wertetyp!
        Console.WriteLine("Hat locNullOfInt einen Wert:" & locNullOfInt.HasValue)

        'Und dennoch ergibt das folgende Konstrukt True,
        'als w�rde locObj keine Referenz haben!
        locObj = locNullOfInt
        Console.WriteLine("Ist locObj Nothing?" & (locObj Is Nothing).ToString)
        Console.WriteLine()

        'Und auch das "Entboxen" geht!
        'Es gibt keine Null-Exception!
        locNullOfInt = DirectCast(locObj, Nullable(Of Integer))

        'Und geht das dann auch? - Nat�rlich!
        locNullOfInt = DirectCast(Nothing, Nullable(Of Integer))

        'Und noch weiter. Wir boxen einen Nullable(of Integer)
        locNullOfInt = 10
        '
        locObj = locNullOfInt
        Dim locInt As Integer = DirectCast(locObj, Integer)

        Console.WriteLine("Taste dr�cken zum Beenden!")
        Console.ReadKey()

        'Das geht �brigens nicht, obwohl Nullable die Contraits-Einschr�nkung im 
        'Grunde genommen erf�llt!
        'Dim locNullOfInt As Nullable(Of Nullable(Of Integer))
    End Sub
End Module
