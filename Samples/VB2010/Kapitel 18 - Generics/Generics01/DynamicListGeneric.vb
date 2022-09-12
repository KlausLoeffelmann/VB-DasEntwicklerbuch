Class DynamicList(Of flexiblerDatentyp)
    Implements IEnumerable

    Protected myStep As Integer = 4          ' Schrittweite, die das Array erh�ht wird.
    Protected myCurrentArraySize As Integer  ' Aktuelle Array-Gr��e
    Protected myCurrentCounter As Integer    ' Zeiger auf aktuelles Element
    Protected myArray() As flexiblerDatentyp ' Array mit den Elementen.

    Sub New()
        myCurrentArraySize = myStep
        ReDim myArray(myCurrentArraySize - 1)
    End Sub

    Sub Add(ByVal Item As flexiblerDatentyp)

        myArray(myCurrentCounter) = Item

        myCurrentCounter += 1

        If myCurrentCounter = myCurrentArraySize - 1 Then
            myCurrentArraySize += myStep

            'tempor�res Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As flexiblerDatentyp

            'Elemente kopieren;
            Array.Copy(myArray, locTempArray, myArray.Length)
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
    Default Public Overridable Property Item(ByVal Index As Integer) As flexiblerDatentyp
        Get
            Return myArray(Index)
        End Get

        Set(ByVal Value As flexiblerDatentyp)
            myArray(Index) = Value
        End Set
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Dim locTempArray(myCurrentCounter - 1) As flexiblerDatentyp
        Array.Copy(myArray, locTempArray, myCurrentCounter)
        Return locTempArray.GetEnumerator
    End Function
End Class
