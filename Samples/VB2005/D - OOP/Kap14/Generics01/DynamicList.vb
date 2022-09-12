Class DynamicList
    Implements IEnumerable

    Protected myStep As Integer = 4         ' Schrittweite, die das Array erh�ht wird.
    Protected myCurrentArraySize As Integer ' Aktuelle Array-Gr��e
    Protected myCurrentCounter As Integer   ' Zeiger auf aktuelles Element
    Protected myArray() As Object           ' Array mit den Elementen.

    Sub New()
        myCurrentArraySize = myStep
        ReDim myArray(myCurrentArraySize - 1)
    End Sub

    Sub Add(ByVal Item As Object)

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf n�chstes Element erh�hen
        myCurrentCounter += 1

        'Pr�fen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hin�berkopieren. Dazu:

            'Neues Array wird gr��er:
            myCurrentArraySize += myStep

            'tempor�res Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As Object

            'Elemente kopieren; das geht mit dieser
            'statischen Methode extrem schnell, da zum Einen nur die
            'Zeiger kopiert werden, zum anderen diese Routine
            'intern nicht in Managed Code sondern nativem Assembler ausgef�hrt wird.
            Array.Copy(myArray, locTempArray, myArray.Length)

            'Auch hier werden nur die Zeiger auf die Elemente "verbogen".
            'Die vorherige Liste der Zeiger in myArray, die nun verwaist ist,
            'f�llt dem Garbage Collector zum Opfer.
            myArray = locTempArray
        End If
    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zur�ck
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
        'ist notwendig, um For/Each zu erm�glichen.

        'Ein Array ist Enumarable - deswegen klauen wir uns 
        'dessen GetEnumerator-Funktionalit�t.
        'Wir m�ssen blo� ein lokales Array erstellen,
        'das genau so viele Elemente hat, wie sich derzeitig
        'in der DynamicList-Instanz befinden, damit die noch
        'nicht genutzten Array-Elemente auch noch aufgez�hlt werden.
        'Aus diesem Grund verwenden wir eine lokale Kopie,
        'die exakt so gro� ist, wie wir Anzahl Elemente
        'in dieser Liste haben.
        Dim locTempArray(myCurrentCounter - 1) As Object
        Array.Copy(myArray, locTempArray, myCurrentCounter)
        Return locTempArray.GetEnumerator
    End Function
End Class
