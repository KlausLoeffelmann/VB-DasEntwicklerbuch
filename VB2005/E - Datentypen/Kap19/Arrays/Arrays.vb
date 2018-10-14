Module Arrays

    Sub Main()

        ' Diese Datei fasst mehrere Beispiele zusammen.
        ' Ändern Sie den folgenden Methodenaufruf (in Beispiel2, Beispiel3, etc.),
        ' um die anderen Beispiele laufen zu lassen.

        Beispiel1()
        Return

    End Sub

    Sub Beispiel1()

        'Array mit 10 Elementen fest deklarieren
        'Wichtig: Anders als in C# oder C++ wird der Index
        'des letzten Elementes nicht die Anzahl der Elemente
        'festgelegt! Elementzählung beginnt bei 0.
        'Die folgende Anweisung definiert also 10 Elemente:
        Dim locIntArray(9) As Integer
        'Zufallsgenerator initialisieren
        Dim locRandom As New Random(Now.Millisecond)

        For count As Integer = 0 To 9
            locIntArray(count) = locRandom.Next
        Next

        For count As Integer = 0 To 9
            Console.WriteLine("Element Nr. {0} hat den Wert {1}", count, locIntArray(count))
        Next

        Console.ReadLine()

    End Sub

    Sub Beispiel2()

        Dim locAnzahlStrings As Integer = 15
        Dim locStringArray(locAnzahlStrings) As String
        locStringArray = GeneriereStrings(locAnzahlStrings, 30)
        DruckeStrings(locStringArray)
        Console.ReadLine()
    End Sub

    Sub Beispiel3()

        Dim locAnzahlStrings As Integer = 15
        Dim locStringArray As String()
        locStringArray = GeneriereStrings(locAnzahlStrings, 30)
        Console.WriteLine("Ausgangsgröße: {0} Elemente. Es folgt der Inhalt:", locStringArray.Length)
        Console.WriteLine(New String("="c, 40))
        DruckeStrings(locStringArray)

        'Wir brauchen 10 weitere, die alten sollen aber erhalten bleiben!
        ReDim Preserve locStringArray(locStringArray.Length + 9)
        'bleiben die alten wirklich erhalten?
        Console.WriteLine()
        Console.WriteLine("Inhaltsüberprüfung:", locStringArray.Length)
        Console.WriteLine(New String("="c, 40))
        DruckeStrings(locStringArray)

        '10 weitere Elemente generieren
        Dim locTempStrings(9) As String
        '10 Zeichen mehr pro Element, so dass wir die neuen leicht erkennen können
        locTempStrings = GeneriereStrings(10, 40)
        'in das "alte" Array kopieren, aber ab Index 15
        locTempStrings.CopyTo(locStringArray, 15)

        'und nachschauen, was nun wirklich drinnen steht!
        Console.WriteLine()
        Console.WriteLine("Inhaltsüberprüfung:", locStringArray.Length)
        Console.WriteLine(New String("="c, 40))
        DruckeStrings(locStringArray)
        Console.ReadLine()
    End Sub

    Function GeneriereStrings(ByVal AnzahlStrings As Integer, ByVal LaengeStrings As Integer) As String()

        Dim locRandom As New Random(Now.Millisecond)
        Dim locChars(LaengeStrings - 1) As Char
        Dim locStrings(AnzahlStrings - 1) As String

        For locOutCount As Integer = 0 To AnzahlStrings - 1
            For locInCount As Integer = 0 To LaengeStrings - 1
                Dim locIntTemp As Integer = Convert.ToInt32(locRandom.NextDouble * 52)
                If locIntTemp > 26 Then
                    locIntTemp += 97 - 26
                Else
                    locIntTemp += 65
                End If
                locChars(locInCount) = Convert.ToChar(locIntTemp)
            Next
            locStrings(locOutCount) = New String(locChars)
        Next

        Return locStrings

    End Function

    Sub DruckeStrings(ByVal locStringArray As String())
        For count As Integer = 0 To locStringArray.Length - 1
            If Not (locStringArray(count) Is Nothing) Then
                Console.WriteLine(locStringArray(count))
            Else
                Console.WriteLine("--- NOTHING ---")
            End If
        Next
    End Sub

    Sub Beispiel4()

        Dim locDoubels(100) As Double
        Dim locIntegers(100) As Integer
        Dim locDecimals(100) As Decimal
        Dim locRandom As New Random(Now.Millisecond)

        'Jedes Array mit 101 Zufallszahlen füllen
        '(nicht vergessen: 100 ist das höchste Element nicht die Länge ;-)
        For count As Integer = 0 To 100
            locDoubels(count) = locRandom.NextDouble * locRandom.Next
            locDecimals(count) = Convert.ToDecimal(locRandom.NextDouble * locRandom.Next)
            locIntegers(count) = locRandom.Next
        Next

        Console.WriteLine("Das größte Element des Double-Arrays war {0}", CDbl(Max(locDoubels)))
        Console.WriteLine("Das größte Element des Integer-Arrays war {0}", CInt(Max(locIntegers)))
        Console.WriteLine("Das größte Element des Decimal-Arrays war {0}", CDec(Max(locDecimals)))
        Console.ReadLine()
    End Sub

    Enum Vergleich
        Kleiner = -1
        Gleich = 0
        Größer = 1
    End Enum

    Function Max(ByVal Array As System.Array) As IComparable

        'Leeres Array-Objekt, dann beenden
        If Array.Length = 0 Then
            Return Nothing
        End If

        'Kann nur vergleichbare Elemente vergleichen,
        'aber alle pimitiven Datentypen sind glücklicherweise
        'vergleichbar, und sie implementieren IComparable
        Dim locICElement As IComparable

        'Erstes Element als Basis holen
        locICElement = DirectCast(Array.GetValue(0), IComparable)
        If locICElement Is Nothing Then
            'Implementiert nicht IComparable, dann Abbrechen
            Return Nothing
        End If

        For Each locICSchleifenElement As IComparable In Array
            If locICSchleifenElement Is Nothing Then
                Return Nothing
            End If

            If locICSchleifenElement.CompareTo(locICElement) = Vergleich.Größer Then
                locICElement = locICSchleifenElement
            End If
        Next
        Return locICElement

    End Function

    Sub Beispiel5()

        Dim AuchDreiDimensional As Integer(,,)


        'Deklaration und Definition von Elementen mit Double-Werten
        Dim locDoubleArray As Double() = {123.45F, 5435.45F, 3.14159274F}

        'Deklaration und spätere Definition von Elementen mit Integer-Werten
        Dim locIntegerArray As Integer()
        locIntegerArray = New Integer() {1I, 2I, 3I, 3I, 4I}

        'Deklaration und spätere Definition von Elementen mit Date-Werten
        Dim locDateArray As Date()
        locDateArray = New Date() {#12/24/2005#, #12/31/2005#, #3/31/2006#}

        'Deklaration und Definition von Elementen im Char-Array:
        Dim locCharArray As Char() = {"V"c, "B"c, "."c, "N"c, "E"c, "T"c, " "c, _
                                    "r"c, "u"c, "l"c, "e"c, "s"c, "!"c}

        'Zweidimensionales Array
        Dim locZweiDimensional As Integer(,)
        locZweiDimensional = New Integer(,) {{10, 10}, {20, 20}, {30, 30}}

        'Oder verschachtelt (das ist nicht zwei-Dimensional)!
        Dim locVerschachtelt As Date()()
        locVerschachtelt = New Date()() {New Date() {#12/24/2004#, #12/31/2004#}, _
                                         New Date() {#12/24/2005#, #12/31/2005#}}

        Console.WriteLine("Außeres Array hat {0} Elemente.", locVerschachtelt.Length)
        Console.WriteLine("Array des 1. Elements hat {0} Elemente.", locVerschachtelt(0).Length)
        Console.ReadLine()

    End Sub

    Sub Beispiel6()

        'Einfach verschachtelt; Tiefe wird nicht definiert
        Dim EinfachVerschachtelt(10)() As Integer

        'Erstes Element hält ein Integer-Array mit drei Elmenten
        EinfachVerschachtelt(0) = New Integer() {10, 20, 30}

        'Zweites Element hält ein Integer-Array mit acht Elmenten
        EinfachVerschachtelt(1) = New Integer() {10, 20, 30, 40, 50, 60, 70, 80}

        'Druckt das dritte Element des zweiten Elementes (30) des Arrays
        Console.WriteLine(EinfachVerschachtelt(1)(2))

        'In einem Rutsch alles neu Zuweisen
        EinfachVerschachtelt = New Integer()() {New Integer() {30, 20, 10}, _
                                                New Integer() {80, 70, 60, 50, 40, 30, 20, 10}}

        'Druckt das dritte Element des zweiten Elementes (jetzt 60) des Arrays
        Console.WriteLine(EinfachVerschachtelt(1)(2))
        Console.ReadLine()

    End Sub

    Sub Beispiel7()

        'Array-Erstellen:
        Dim locNamen As String() = {"Jürgen", "Martina", "Hanna", "Gaby", "Michaela", "Miriam", "Ute", _
                                    "Leonie-Gundula", "Mellanie", "Uwe", "Andrea", "Klaus", "Anja", _
                                    "Myriam", "Daja", "Thomas", "José", "Kricke", "Flori", "Katrin", "Momo", _
                                    "Gareth", "Anne"}
        System.Array.Sort(locNamen)
        DruckeStrings(locNamen)
        Console.ReadLine()

        Console.WriteLine()
        Console.WriteLine("Absteigend sortiert:")
        Array.Reverse(locNamen)
        DruckeStrings(locNamen)
        Console.ReadLine()

    End Sub

    Sub Beispiel8()

        'Array-Erstellen:
        Dim locNamen As String() = {"Jürgen", "Martina", "Hanna", "Gaby", "Michaela", "Miriam", "Ute", _
                                    "Leonie-Gundula", "Mellanie", "Uwe", "Andrea", "Klaus", "Anja", _
                                    "Myriam", "Daja", "Thomas", "José", "Kricke", "Flori", "Katrin", "Momo", _
                                    "Gareth", "Anne", "Jürgen", "Gaby"}
        System.Array.Sort(locNamen)
        Console.WriteLine("Jürgen wurde gefunden an Position {0}", _
                System.Array.BinarySearch(locNamen, "Jürgen"))
        Console.ReadLine()
    End Sub

End Module
