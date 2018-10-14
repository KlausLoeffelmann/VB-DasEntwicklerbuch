Imports System.Runtime.InteropServices

Public Class KeyedCollectionEnumerator
    Implements IEnumerator

    Private myKeyedCollection As IKeyedCollection
    Private myIndex As Integer

    Sub New(ByVal KeyedCollection As IKeyedCollection)
        myKeyedCollection = KeyedCollection
        myIndex = -1
    End Sub

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return myKeyedCollection.Item(myIndex)
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        myIndex += 1
        If myIndex < myKeyedCollection.Count Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        myIndex = -1
    End Sub
End Class

<Serializable()> _
Public MustInherit Class KeyedCollectionBase
    Implements IKeyedCollection

    Private myIndexTable As ArrayList
    Private myKeyValueTable As Hashtable
    Private myEnumeratorIndex As Integer

    <StructLayout(LayoutKind.Explicit)> _
    Private Structure KeyedCollectionKey

        <FieldOffset(0)> Private myKey As Long
        <FieldOffset(0)> Private myMainKey As Integer
        <FieldOffset(2)> Private mySubKey As Integer

        Sub New(ByVal MainKey As Integer)
            myMainKey = MainKey
            mySubKey = 0
        End Sub

        'Wird benötigt, um bei Kollisionen den richtigen
        'Schlüssel zu finden
        Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
            If Not (TypeOf obj Is KeyedCollectionKey) Then
                Return False
            End If
            Return myKey.Equals(CType(obj, KeyedCollectionKey).Key)
        End Function

        'Wird benötigt, um den Index zu "berechnen"
        Public Overrides Function GetHashcode() As Integer
            Return myKey.GetHashCode
        End Function

        Public ReadOnly Property Key() As Long
            Get
                Return myKey
            End Get
        End Property

        Public Sub IncSubKey()
            mySubKey += 1
        End Sub
    End Structure

    Sub New()
        myIndexTable = New ArrayList
        myKeyValueTable = New Hashtable
    End Sub

    Sub New(ByVal capacity As Integer)
        myIndexTable = New ArrayList(capacity)
        myKeyValueTable = New Hashtable(capacity)
    End Sub

    Protected Overridable Function GenerateKeyForValue(ByVal value As Object) As Object
        Dim locKey As New KeyedCollectionKey(value.GetHashCode)
        Do While myKeyValueTable.ContainsKey(locKey)
            locKey.IncSubKey()
        Loop
        Return locKey
    End Function

    Private Overloads Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add
        Add(value, GenerateKeyForValue(value))
    End Function

    Private Overloads Function Add(ByVal value As Object, ByVal key As Object) As Integer Implements IKeyedCollection.Add
        myKeyValueTable.Add(key, value)
        myIndexTable.Add(key)
    End Function

    Private Function ContainsKey(ByVal key As Object) As Boolean Implements IKeyedCollection.ContainsKey
        Return myKeyValueTable.ContainsKey(key)
    End Function

    Private Function GetValue(ByVal key As Object) As Object Implements IKeyedCollection.GetValue
        Return myKeyValueTable(key)
    End Function

    Private Function IndexOfKey(ByVal key As Object) As Integer Implements IKeyedCollection.IndexOfKey
        Return myIndexTable.IndexOf(key)
    End Function

    Private Function CheckKey(ByVal key As Object, _
                              ByVal ThrowExceptionIfNotExist As Boolean, _
                              ByVal ThrowExceptionIfExist As Boolean) As Integer
        If Not myKeyValueTable.ContainsKey(key) Then
            If ThrowExceptionIfNotExist Then
                Dim up As New ArgumentException("Es ist kein Key mit diesem Wert vorhanden!")
                Throw up
            End If
        Else
            If ThrowExceptionIfExist Then
                Dim up As New ArgumentException("Ein Key mit diesem Wert ist bereits vorhanden!")
                Throw up
            End If
        End If
        Return myIndexTable.IndexOf(key)
    End Function

    Private Overloads Sub Insert(ByVal index As Integer, ByVal value As Object, ByVal key As Object) Implements IKeyedCollection.Insert
        CheckKey(key, False, True)
        myIndexTable.Insert(index, key)
        myKeyValueTable.Add(key, value)
    End Sub

    Private Overloads Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert
        Insert(index, value, GenerateKeyForValue(value))
    End Sub

    Private Sub InsertAfter(ByVal afterKey As Object, ByVal value As Object, ByVal key As Object) Implements IKeyedCollection.InsertAfter
        CheckKey(key, False, True)
        Dim locPos As Integer = CheckKey(afterKey, True, False) + 1
        myIndexTable.Insert(locPos, key)
        myKeyValueTable.Add(key, value)
    End Sub

    Private Sub InsertBefore(ByVal beforeKey As Object, ByVal value As Object, ByVal key As Object) Implements IKeyedCollection.InsertBefore
        CheckKey(key, False, True)
        Dim locPos As Integer = CheckKey(beforeKey, True, False)
        myIndexTable.Insert(locPos, key)
        myKeyValueTable.Add(key, value)
    End Sub

    Private Sub RemoveByKey(ByVal key As Object) Implements IKeyedCollection.RemoveByKey
        Dim locPos As Integer = CheckKey(key, True, False)
        myIndexTable.RemoveAt(locPos)
        myKeyValueTable.Remove(key)
    End Sub

    Private Sub SetValue(ByVal value As Object, ByVal key As Object) Implements IKeyedCollection.SetValue
        CheckKey(key, True, False)
        myKeyValueTable(key) = value
    End Sub

    Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo
        myKeyValueTable.CopyTo(array, index)
    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return myKeyValueTable.Count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return myKeyValueTable.IsSynchronized Or myIndexTable.IsSynchronized
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return New KeyedCollectionEnumerator(Me)
    End Function

    Public Sub Clear() Implements System.Collections.IList.Clear
        myKeyValueTable.Clear()
        myIndexTable.Clear()
    End Sub

    Private Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains
        Return myKeyValueTable.ContainsValue(value)
    End Function

    Private Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf
        For Each locDE As DictionaryEntry In myKeyValueTable
            If locDE.Value.Equals(value) Then
                Return myIndexTable.IndexOf(locDE.Key)
            End If
        Next
        Return -1
    End Function

    Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
        Get
            Return myKeyValueTable.IsFixedSize
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
        Get
            Return myKeyValueTable.IsFixedSize
        End Get
    End Property

    Private Property Item(ByVal index As Integer) As Object Implements System.Collections.IList.Item
        Get
            Return myKeyValueTable(myIndexTable(index))
        End Get
        Set(ByVal Value As Object)
            myKeyValueTable(myIndexTable(index)) = Value
        End Set
    End Property

    Private Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
        For Each locDE As DictionaryEntry In myKeyValueTable
            If locDE.Value.Equals(value) Then
                RemoveAt(myIndexTable.IndexOf(locDE.Key))
                Return
            End If
        Next
    End Sub

    Private Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
        myKeyValueTable.Remove(myIndexTable(index))
        myIndexTable.RemoveAt(index)
    End Sub

    Public ReadOnly Property List() As IKeyedCollection
        Get
            Return DirectCast(Me, IKeyedCollection)
        End Get
    End Property
End Class
