Module DynamicListDemo

    Sub Main()

        'Nehmen Sie die Auskommentierung der folgenden Zeilen zur�ck,
        'um mit dem zweiten Beispiel zu experimentieren.

        'Beispiel2()
        'Return

        Dim locZeitmesser As New HighSpeedTimeGauge
        Dim locAnzahlElemente As Integer = 50000
        Dim locDynamicList As New DynamicList
        Dim locRandom As New Random(Now.Millisecond)

        Console.WriteLine("Anlegen von {0} zuf�lligen Double-Elementen...", locAnzahlElemente)
        locZeitmesser.Start()
        For count As Integer = 1 To locAnzahlElemente
            locDynamicList.Add(locRandom.NextDouble * locRandom.Next)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("...in {0:#,##0} Millisekunden!", locZeitmesser.DurationInMilliSeconds)
        Console.ReadLine()
    End Sub

    Sub Beispiel2()
        Dim locZeitmesser As New HighSpeedTimeGauge
        Dim locAnzahlElemente As Integer = 50000
        Dim locDynamicList As New ArrayList
        Dim locRandom As New Random(Now.Millisecond)

        Console.WriteLine("Anlegen von {0} zuf�lligen Double-Elementen...", locAnzahlElemente)
        locZeitmesser.Start()
        For count As Integer = 1 To locAnzahlElemente
            locDynamicList.Add(locRandom.NextDouble * locRandom.Next)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("...in {0:#,##0} Millisekunden!", locZeitmesser.DurationInMilliSeconds)
        Console.ReadLine()

    End Sub

End Module

Class DynamicList
    Implements IEnumerable

    Protected myStepIncreaser As Integer
    Protected myCurrentArraySize As Integer
    Protected myCurrentCounter As Integer
    Protected myArray() As Object

    Sub New()
        MyClass.New(16)
    End Sub

    Sub New(ByVal StepIncreaser As Integer)
        myStepIncreaser = StepIncreaser
        myCurrentArraySize = myStepIncreaser
        ReDim myArray(myCurrentArraySize)
    End Sub

    Sub Add(ByVal Item As Object)

        'Pr�fen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hin�berkopieren. Dazu:

            'Neues Array wird gr��er:
            myCurrentArraySize += myStepIncreaser

            'tempor�res Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As Object

            'Elemente kopieren
            'Wichtig: Um das Kopieren m�ssen Sie sich,
            'anders als bei VB6, selber k�mmern!
            Array.Copy(myArray, locTempArray, myArray.Length)

            'tempor�res Array dem Memberarray zuweisen
            myArray = locTempArray
        End If

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf n�chstes Element erh�hen
        myCurrentCounter += 1

    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zur�ck
    Public Overridable ReadOnly Property Count() As Integer
        Get
            Return myCurrentCounter
        End Get
    End Property

    'Erlaubt das Zuweisen und Abfragen
    Default Public Overridable Property Item(ByVal Index As Integer) As Object
        Get
            Return myArray(Index)
        End Get

        Set(ByVal Value As Object)
            myArray(Index) = Value
        End Set
    End Property

    'Liefert den Enumerator der Basis (dem Array) zur�ck
    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return myArray.GetEnumerator
    End Function
End Class
