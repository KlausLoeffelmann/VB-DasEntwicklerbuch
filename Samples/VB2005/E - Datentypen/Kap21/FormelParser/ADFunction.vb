''' <summary>
''' Speichert die Parameter f�r eine Funktion, die vom FormelParser ber�cksichtigt werden kann.
''' </summary>
''' <remarks></remarks>
Public Class ADFunction
    Implements IComparable

    Public Delegate Function ADFunctionDelegate(ByVal parArray As Double()) As Double

    Protected myFunctionname As String
    Protected myParameters As Integer
    Protected myFunctionProc As ADFunctionDelegate
    Protected myConsts As ArrayList
    Protected myIsOperator As Boolean
    Protected myPriority As Byte

    ''' <summary>
    ''' Erstellt eine neue Intanz dieser Klasse. 
    ''' Verwenden Sie diese �berladungsversion, um Operatoren zu erstellen, die aus einem Zeichen bestehen,
    ''' </summary>
    ''' <param name="OperatorChar">Das Zeichen, das den Operator darstellt.</param>
    ''' <param name="FunctionProc">Der ADFunctionDelegat f�r die Berechnung durch diesen Operator.</param>
    ''' <param name="Priority">Die Operatorpriorit�t (3= Potenz, 2=Punkt, 1=Strich).</param>
    ''' <remarks></remarks>
    Sub New(ByVal OperatorChar As Char, ByVal FunctionProc As ADFunctionDelegate, ByVal Priority As Byte)

        If Priority < 1 Then
            Dim Up As New ArgumentException("Priority kann f�r Operatoren nicht kleiner 1 sein.")
            Throw Up
        End If

        myFunctionname = OperatorChar.ToString
        myParameters = 2
        myFunctionProc = FunctionProc
        myIsOperator = True
        myPriority = Priority
    End Sub

    ''' <summary>
    ''' Erstellt eine neue Intanz dieser Klasse. 
    ''' Verwenden Sie diese �berladungsversion, um Funktionen zu erstellen, die aus mehreren Zeichen bestehen.
    ''' </summary>
    ''' <param name="FunctionName">Die Zeichenfolge, die den Funktionsnamen darstellt.</param>
    ''' <param name="FunctionProc">Der ADFunctionDelegat f�r die Berechnung durch diese Funktion.</param>
    ''' <param name="Parameters">Die Anzahl der Parameter, die diese Funktion entgegen nimmt.</param>
    ''' <remarks></remarks>
    Sub New(ByVal FunctionName As String, ByVal FunctionProc As ADFunctionDelegate, ByVal Parameters As Integer)
        myFunctionname = FunctionName
        myFunctionProc = FunctionProc
        myParameters = Parameters
        myIsOperator = False
        myPriority = 0
    End Sub

    ''' <summary>
    ''' Liefert den Funktionsnamen bzw. das Operatorenzeichen zur�ck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FunctionName() As String
        Get
            Return myFunctionname
        End Get
    End Property

    ''' <summary>
    ''' Liefert die Anzahl der zur Anwendung kommenden Parameter f�r diese Funktion zur�ck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Parameters() As Integer
        Get
            Return myParameters
        End Get
    End Property

    ''' <summary>
    ''' Zeigt an, ob es sich bei dieser Instanz um einen Operator handelt.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsOperator() As Boolean
        Get
            Return myIsOperator
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt die Priorit�t, die dieser Operator hat. (3= Potenz, 2=Punkt, 1=Strich)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Priority() As Byte
        Get
            Return myPriority
        End Get
    End Property

    ''' <summary>
    ''' Ermittelt den Delegaten, der diese Funktion oder diesen Operator berechnet.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FunctionProc() As ADFunctionDelegate
        Get
            Return myFunctionProc
        End Get
    End Property

    ''' <summary>
    ''' Ruft den Delegaten auf, der diese Funktion (diesen Operator) berechnet.
    ''' </summary>
    ''' <param name="parArray">Das Array, dass die Argumente der Funktion enth�lt.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Operate(ByVal parArray As Double()) As Double
        If Parameters > -1 Then
            If parArray.Length <> Parameters Then
                Dim Up As New ArgumentException _
                    ("Anzahl Parameter entspricht nicht der Vorschrift der Funktion " & FunctionName)
                Throw Up
            End If
        End If
        Return myFunctionProc(parArray)
    End Function

    ''' <summary>
    ''' Vergleicht zwei Instanzen dieser Klasse anhand ihres Priorit�tswertes.
    ''' </summary>
    ''' <param name="obj">Eine ADFunction-Instanz, die mit dieser Instanz verglichen werden soll.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If obj.GetType Is GetType(ADFunction) Then
            Return myPriority.CompareTo(DirectCast(obj, ADFunction).Priority) * -1
        Else
            Dim up As New ArgumentException("Nur ActiveDev.Function-Objekte k�nnen verglichen/sortiert werden")
            Throw up
        End If
    End Function

End Class
