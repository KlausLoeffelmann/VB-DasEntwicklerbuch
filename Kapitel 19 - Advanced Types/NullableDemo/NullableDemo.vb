Module NullableDemo

    Sub Main()

        Dim i As Integer = Nothing



        Dim anObj As Object
        Dim aNullOfInt As Integer? = Nothing
        Dim anotherNullOfInt As Integer? = 5
        Dim yetAnotherNullOfInt As Integer?

        yetAnotherNullOfInt = aNullOfInt + anotherNullOfInt



        'Es gibt nat�rlich eine verwendbare Instanz, denn
        'Integer? ist ein Wertetyp!
        Console.WriteLine("Hat aNullOfInt einen Wert: " & aNullOfInt.HasValue)

        'Und dennoch ergibt das folgende Konstrukt True,
        'als w�rde locObj keine Referenz haben!
        anObj = aNullOfInt
        Console.WriteLine("Ist anObj Nothing? " & (anObj Is Nothing).ToString)
        Console.WriteLine()

        'Und auch das "Entboxen" geht!
        'Es gibt keine Null-Exception!
        aNullOfInt = DirectCast(anObj, Integer?)

        'Und geht das dann auch? - Nat�rlich!
        aNullOfInt = DirectCast(Nothing, Integer?)

        'Und noch weiter. Wir boxen einen Integer?
        aNullOfInt = 10
        '
        anObj = aNullOfInt
        Dim anInt As Integer = DirectCast(anObj, Integer)

        Console.WriteLine("Taste dr�cken zum Beenden!")
        Console.ReadKey()

        'Das geht �brigens nicht, obwohl Nullable die 
        'Constraints-Einschr�nkung im Grunde genommen erf�llt!
        'Dim anotherNullOfInt As Nullable(Of Integer?)

        anInt = Nothing

        aNullOfInt = Nothing
        anInt = CInt(aNullOfInt)

    End Sub
End Module
