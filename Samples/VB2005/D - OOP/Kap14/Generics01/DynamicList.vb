Class DynamicList
    Implements IEnumerable

    Protected myStep As Integer = 4         ' Schrittweite, die das Array erhöht wird.
    Protected myCurrentArraySize As Integer ' Aktuelle Array-Größe
    Protected myCurrentCounter As Integer   ' Zeiger auf aktuelles Element
    Protected myArray() As Object           ' Array mit den Elementen.

    Sub New()
        myCurrentArraySize = myStep
        ReDim myArray(myCurrentArraySize - 1)
    End Sub

    Sub Add(ByVal Item As Object)

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf nächstes Element erhöhen
        myCurrentCounter += 1

        'Prüfen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hinüberkopieren. Dazu:

            'Neues Array wird größer:
            myCurrentArraySize += myStep

            'temporäres Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As Object

            'Elemente kopieren; das geht mit dieser
            'statischen Methode extrem schnell, da zum Einen nur die
            'Zeiger kopiert werden, zum anderen diese Routine
            'intern nicht in Managed Code sondern nativem Assembler ausgeführt wird.
            Array.Copy(myArray, locTempArray, myArray.Length)

            'Auch hier werden nur die Zeiger auf die Elemente "verbogen".
            'Die vorherige Liste der Zeiger in myArray, die nun verwaist ist,
            'fällt dem Garbage Collector zum Opfer.
            myArray = locTempArray
        End If
    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zurück
    Public Overridable ReadOnly Property Count() As Integer
        Get
            Return myCurrentCounter
        End Get
    End Property

    'Erlaubt das Zuweisen 
    Default Public Overridable Property Item(ByVal Index As Integer) As Object
        Get
            Return myArray(Index)
        End Get

        Set(ByVal Value As Object)
            myArray(Index) = Value
        End Set
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        'GetEnumerator muss implementiert werden, wenn die 
        'IEnumerable-Schnittstelle eingebunden wird. Die wiederum
        'ist notwendig, um For/Each zu ermöglichen.

        'Ein Array ist Enumarable - deswegen klauen wir uns 
        'dessen GetEnumerator-Funktionalität.
        'Wir müssen bloß ein lokales Array erstellen,
        'das genau so viele Elemente hat, wie sich derzeitig
        'in der DynamicList-Instanz befinden, damit die noch
        'nicht genutzten Array-Elemente auch noch aufgezählt werden.
        'Aus diesem Grund verwenden wir eine lokale Kopie,
        'die exakt so groß ist, wie wir Anzahl Elemente
        'in dieser Liste haben.
        Dim locTempArray(myCurrentCounter - 1) As Object
        Array.Copy(myArray, locTempArray, myCurrentCounter)
        Return locTempArray.GetEnumerator
    End Function
End Class
