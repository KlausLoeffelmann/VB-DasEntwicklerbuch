Imports System.Runtime.CompilerServices

Public Module ExtensionModul

    <Extension>
    Public Function ObeyNewLines(stringMitReturn As String) As String
        If Not String.IsNullOrEmpty(stringMitReturn) Then
            Return stringMitReturn.Replace("\n", vbNewLine)
        End If
        Return stringMitReturn
    End Function

    <Extension>
    Public Function IsOddCount(collection As IList) As Boolean

    End Function


End Module
