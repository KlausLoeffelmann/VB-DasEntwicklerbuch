Imports System.Collections.ObjectModel

''' <summary>
''' Auflistung, in der alle Operatoren gleicher Priorit�t gesammelt werden, damit 
''' es die M�glichkeit gibt, sie von links nach rechts (in einem Rutsch) zu verarbeiten.
''' </summary>
''' <remarks></remarks>
Public Class ADOperatorsOfSamePriority
    Inherits Collection(Of ADFunction)

    Private myPriority As Byte

    Sub New()
        MyBase.New()
    End Sub

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As ADFunction)
        If Not item.IsOperator Then
            Dim locEx As New ArgumentException("Nur Operatoren (keine Funktionen) k�nnen dieser Auflistung hinzugef�gt werden!")
            Throw locEx
        End If
        If Me.Count = 0 Then
            myPriority = item.Priority
        Else
            '�berpr�fen, ob es dieselbe Priorit�t ist, sonst Ausnahme!
            If item.Priority <> myPriority Then
                Dim locEx As New ArgumentException("Nur Operatoren der Priorit�t " & myPriority & " k�nnen dieser Auflistung hinzugef�gt werden!")
                Throw locEx
            End If
        End If
        MyBase.InsertItem(index, item)
    End Sub

    Protected Overrides Sub SetItem(ByVal index As Integer, ByVal item As ADFunction)
        Dim locEx As New ArgumentException("Elemente k�nnen in dieser Auflistung nicht ausgetauscht werden!")
        Throw locEx
    End Sub

    ''' <summary>
    ''' Liefert die Priorit�t dieser Operatorenauflistung zur�ck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Priority() As Byte
        Get
            Return myPriority
        End Get
    End Property
End Class

''' <summary>
''' Fasst alle Operatorenlisten nach Priorit�t kategorisiert in einer �bergeordneten Auflistung zusammen.
''' </summary>
''' <remarks></remarks>
Public Class ADPrioritizedOperators
    Inherits KeyedCollection(Of Byte, ADOperatorsOfSamePriority)

    Private myHighestPriority As Byte
    Private myLowestPriority As Byte

    ''' <summary>
    ''' F�gt einer der untergeordneten Auflistungen einen neuen Operator hinzu, 
    ''' in Abh�ngigkeit von seiner Priorit�t.
    ''' </summary>
    ''' <param name="Function"></param>
    ''' <remarks></remarks>
    Public Sub AddFunction(ByVal [Function] As ADFunction)
        'Feststellen, ob es schon eine Auflistung f�r diese Operator-Priorit�t gibt
        If Me.Contains([Function].Priority) Then
            'Ja - dieser hinzuf�gen,
            Me([Function].Priority).Add([Function])
        Else
            'Nein - anlegen und hinzuf�gen.
            Dim locOperatorsOfSamePriority As New ADOperatorsOfSamePriority()
            locOperatorsOfSamePriority.Add([Function])
            Me.Add(locOperatorsOfSamePriority)
        End If
    End Sub

    Protected Overrides Function GetKeyForItem(ByVal item As ADOperatorsOfSamePriority) As Byte
        Return item.Priority
    End Function

    Protected Overrides Sub InsertItem(ByVal index As Integer, ByVal item As ADOperatorsOfSamePriority)

        If Me.Count = 0 Then
            myHighestPriority = item.Priority
            myLowestPriority = item.Priority
            MyBase.InsertItem(index, item)
            Return
        End If

        MyBase.InsertItem(index, item)

        If myHighestPriority < item.Priority Then
            myHighestPriority = item.Priority
        End If

        If myLowestPriority > item.Priority Then
            myLowestPriority = item.Priority
        End If
    End Sub

    ''' <summary>
    ''' Liefert alle Operatorzeichen einer bestimmten Priorit�t als Char-Array zur�ck.
    ''' </summary>
    ''' <param name="Priority">Die Priorit�t, deren Operatoren zusammengestellt werden sollen.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OperatorChars(ByVal Priority As Byte) As Char()
        If Me.Contains(Priority) Then
            Dim locChars As New List(Of Char)
            For Each locFunction As ADFunction In Me(Priority)
                locChars.Add(Convert.ToChar(locFunction.FunctionName))
            Next
            Return locChars.ToArray
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Liefert die Funktion zur�ck, die sich durch ein Operator-Zeichen einer bestimmten Priorit�t ergibt.
    ''' </summary>
    ''' <param name="Priority">Die Priorit�t, die den Operatoren entspricht, die nach den Operatorzeichen durchsucht werden sollen.</param>
    ''' <param name="OperatorChar">Das Operatorzeichen mit der angegebenen Priorit�t, dessen Funktionsklasse ermittelt werden soll.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function OperatorByChar(ByVal Priority As Byte, ByVal OperatorChar As Char) As ADFunction
        If Me.Contains(Priority) Then
            For Each locFunction As ADFunction In Me(Priority)
                If OperatorChar = Convert.ToChar(locFunction.FunctionName) Then
                    Return locFunction
                End If
            Next
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' Liefert die h�chste Priorit�tennummer zur�ck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HighestPriority() As Byte
        Get
            Return myHighestPriority
        End Get
    End Property

    ''' <summary>
    ''' Liefert die kleinste Priorit�tennummer zur�ck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LowestPriority() As Byte
        Get
            Return myLowestPriority
        End Get
    End Property
End Class
