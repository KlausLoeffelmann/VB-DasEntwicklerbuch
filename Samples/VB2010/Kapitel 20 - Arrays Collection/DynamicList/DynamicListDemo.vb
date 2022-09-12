Module DynamicListDemo

    Private Const SAMPLESIZE = 200000

    Sub Main()

        'Nehmen Sie die Auskommentierung der folgenden Zeilen zurück,
        'um mit dem zweiten Beispiel zu experimentieren.

        'Beispiel2()
        'Return

        Dim locDynamicList As New DynamicList
        Dim locRandom As New Random(Now.Millisecond)

        Console.WriteLine("Anlegen von {0} zufälligen Double-Elementen...", SAMPLESIZE)
        Dim locZeitmesser = Stopwatch.StartNew
        For count As Integer = 1 To SAMPLESIZE
            locDynamicList.Add(locRandom.NextDouble * locRandom.Next)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("...in {0:#,##0} Millisekunden!", locZeitmesser.ElapsedMilliseconds)
        Console.ReadLine()
    End Sub

    Sub Beispiel2()

        Dim locDynamicList As New ArrayList
        Dim locRandom As New Random(Now.Millisecond)

        Console.WriteLine("Anlegen von {0} zufälligen Double-Elementen...", SAMPLESIZE)
        Dim locZeitmesser = Stopwatch.StartNew
        For count As Integer = 1 To SAMPLESIZE
            locDynamicList.Add(locRandom.NextDouble * locRandom.Next)
        Next
        locZeitmesser.Stop()
        Console.WriteLine("...in {0:#,##0} Millisekunden!", locZeitmesser.ElapsedMilliseconds)
        Console.ReadLine()
    End Sub

End Module

Class DynamicList
    Implements IEnumerable

    Private myStepIncreaser As Integer
    Private myCurrentArraySize As Integer
    Private myCurrentCounter As Integer
    Private myArray() As Object

    Sub New()
        MyClass.New(16)
    End Sub

    Sub New(ByVal StepIncreaser As Integer)
        myStepIncreaser = StepIncreaser
        myCurrentArraySize = myStepIncreaser
        ReDim myArray(myCurrentArraySize)
    End Sub

    Sub Add(ByVal Item As Object)

        'Prüfen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hinüberkopieren. Dazu:

            'Neues Array wird größer:
            myCurrentArraySize += myStepIncreaser

            'temporäres Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As Object

            'Elemente kopieren
            'Wichtig: Um das Kopieren müssen Sie sich,
            'anders als bei VB6, selber kümmern!
            Array.Copy(myArray, locTempArray, myArray.Length)

            'temporäres Array dem Memberarray zuweisen
            myArray = locTempArray

            'Beim nächsten Mal werden mehr Elemente reserviert!
            myStepIncreaser *= 2
        End If

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf nächstes Element erhöhen
        myCurrentCounter += 1

    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zurück
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

    'Liefert den Enumerator der Basis (dem Array) zurück
    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return myArray.GetEnumerator
    End Function
End Class
