Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO

Public Class ADObjectCloner

    Public Shared Function DeepCopy(ByVal [Object] As Object) As Object
        Return DeserializeFromByteArray(SerializeToByteArray([Object]))
    End Function

    Shared Function SerializeToByteArray(ByVal [Object] As Object) As Byte()

        Dim retByte() As Byte
        Dim locMs As MemoryStream = New MemoryStream
        Dim locBinaryFormatter As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
        locBinaryFormatter.Serialize(locMs, [Object])
        locMs.Flush()
        locMs.Close()
        retByte = locMs.ToArray()
        Return retByte

    End Function

    Shared Function DeserializeFromByteArray(ByVal by As Byte()) As Object

        Dim locObject As Object

        Dim locFs As MemoryStream = New MemoryStream(by)
        Dim locBinaryFormatter As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.File))
        locObject = locBinaryFormatter.Deserialize(locFs)
        locFs.Close()
        Return locObject

    End Function

End Class
