Class DynamicListSortable(Of flexiblerDatentyp As IComparable)
    Implements IEnumerable

    Protected myStep As Integer = 4          ' Schrittweite, die das Array erhöht wird.
    Protected myCurrentArraySize As Integer  ' Aktuelle Array-Größe
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

            'temporäres Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As flexiblerDatentyp

            'Elemente kopieren;
            Array.Copy(myArray, locTempArray, myArray.Length)
            myArray = locTempArray
        End If
    End Sub

    'Sortiert die Elemente, die die DynamicListSortable speichert
    Public Sub Sort()
        Dim locÄußererZähler, locInnererZähler As Integer
        Dim locDelta As Integer
        Dim locItemTemp As flexiblerDatentyp

        locDelta = 1

        'Größten Wert der Distanzfolge ermitteln
        Do
            locDelta = 3 * locDelta + 1
        Loop Until locDelta > myCurrentCounter

        Do
            'War einen zu groß, also wieder teilen
            locDelta \= 3

            'Shellsort's Kernalgorithmus
            For locÄußererZähler = locDelta To myCurrentCounter - 1
                locItemTemp = Me.Item(locÄußererZähler)
                locInnererZähler = locÄußererZähler
                Do While (Me.Item(locInnererZähler - locDelta).CompareTo(locItemTemp) > 0)
                    Me.Item(locInnererZähler) = Me.Item(locInnererZähler - locDelta)
                    locInnererZähler = locInnererZähler - locDelta
                    If (locInnererZähler <= locDelta) Then Exit Do
                Loop
                Me.Item(locInnererZähler) = locItemTemp
            Next
        Loop Until locDelta = 0
    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zurück
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
