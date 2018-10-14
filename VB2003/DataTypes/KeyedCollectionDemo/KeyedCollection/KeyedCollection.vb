Public Class KeyedCollection
    Inherits KeyedCollectionBase

    Public Function Add(ByVal Value As Object) As Integer
        Return List.Add(Value)
    End Function

    Public Function Add(ByVal Value As Object, ByVal key As String) As Integer
        Return List.Add(Value, key)
    End Function

    Default Public Property Item(ByVal Index As Integer) As Object
        Get
            Return List.Item(Index)
        End Get
        Set(ByVal Value As Object)
            List.Item(Index) = Value
        End Set
    End Property

    Default Public Property Item(ByVal Key As String) As Object
        Get
            Return List.GetValue(Key)
        End Get
        Set(ByVal Value As Object)
            List.SetValue(Value, Key)
        End Set
    End Property

    Public Sub Remove(ByVal Value As Object)
        List.Remove(Value)
    End Sub

    Public Sub RemoveAt(ByVal index As Integer)
        List.RemoveAt(index)
    End Sub

    Public Sub RemoveByKey(ByVal key As String)
        List.RemoveByKey(key)
    End Sub

    Public Sub Insert(ByVal index As Integer, ByVal value As Object, ByVal key As String)
        List.Insert(index, value, key)
    End Sub

    Public Sub Insert(ByVal index As Integer, ByVal value As Object)
        List.Insert(index, value)
    End Sub

    Public Sub InsertAfter(ByVal afterkey As String, ByVal value As Object, ByVal key As String)
        List.InsertAfter(afterkey, value, key)
    End Sub

    Public Sub InsertBefore(ByVal beforekey As String, ByVal value As Object, ByVal key As String)
        List.InsertBefore(beforekey, value, key)
    End Sub

    Public Function IndexOf(ByVal value As Object) As Integer
        Return List.IndexOf(value)
    End Function

    Public Function IndexOfKey(ByVal key As String) As Integer
        Return List.IndexOfKey(key)
    End Function

    Public Function Contains(ByVal value As Object) As Boolean
        Return List.Contains(value)
    End Function

    Public Function ContainsKey(ByVal key As String) As Boolean
        Return List.ContainsKey(key)
    End Function

End Class
