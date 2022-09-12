Public Interface IKeyedCollection
    Inherits ICollection, IList, IEnumerable

    Overloads Function Add(ByVal value As Object, ByVal key As Object) As Integer
    Function ContainsKey(ByVal key As Object) As Boolean
    Function GetValue(ByVal key As Object) As Object
    Function IndexOfKey(ByVal key As Object) As Integer
    Overloads Sub Insert(ByVal index As Integer, ByVal value As Object, ByVal key As Object)
    Sub InsertAfter(ByVal afterKey As Object, ByVal value As Object, ByVal key As Object)
    Sub InsertBefore(ByVal beforeKey As Object, ByVal value As Object, ByVal key As Object)
    Sub RemoveByKey(ByVal key As Object)
    Sub SetValue(ByVal value As Object, ByVal key As Object)

End Interface
