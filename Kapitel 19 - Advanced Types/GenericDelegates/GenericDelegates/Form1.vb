Public Class Form1

    Private myFunction As Func(Of Integer, Double, String) = AddressOf SomeFunction



    Private Function SomeFunction(ByVal par1 As Integer, ByVal par2 As Double) As String
        Return "Result"
    End Function


    'Definiert einen Delegaten auf eine Methode, die einen Parameter vom
    'Typ Object und einen vom Typ EventArgs entgegen nimmt.
    Private myClickHandler As Action(Of Object, EventArgs)

    'Ein EventHandler, der aufgerufen wird, wenn die aktuelle Uhrzeit nach 18:00 liegt.
    Private Sub NachtClickHandler(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("Gute Nacht, lieber Anweder!" &
                        vbNewLine & "Der Button wurde gedrückt")

    End Sub

    Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Dim MessageText As String = "Button1 wurde geklickt"

        'Vor 12 --> dann dieser Lambda als Delegate
        If Now.TimeOfDay < New TimeSpan(12, 0, 0) Then
            'Beachtenswert: die Typen von sender und e leiten 
            'sich aus der Signatur von myClickHandler ab (Typrückschluss).
            ' 'as Object' und 'as EventArgs' brauchen Sie als nicht mitangeben.
            myClickHandler = Sub(sender, e)
                                 MessageBox.Show("Guten Morgen lieber Anwender!" &
                                                 vbNewLine & MessageText)
                             End Sub

            'Vor 18 Uhr, dann dieser Lambda als Delegate
        ElseIf Now.TimeOfDay < New TimeSpan(18, 0, 0) Then
            'auch hier: Typrückschluss für Parameter des Lambdas.
            myClickHandler = Sub(sender, e)
                                 MessageBox.Show("Guten Tag lieber Anwender!" &
                                                 vbNewLine & MessageText)
                             End Sub
        Else
            'Sonst die NachtClickHandler Sub dem Action-Delegate zuweisen.
            myClickHandler = AddressOf NachtClickHandler
        End If


        'Hier wird das Click-Ereignis verdrahtet, das seinerseits 
        'den Action-Delegaten aufruft.
        AddHandler Button1.Click, Sub(sender, e)
                                      myClickHandler(sender, e)
                                  End Sub
    End Sub

    Sub TupleTest()

        'Definiert ein neues Tuple mit drei Werten.
        Dim t As New Tuple(Of Double, Integer, String)(3.1415926, 20, "Test")
        Debug.Print("Erster Wert des Tupels:" & t.Item1.ToString)
        Debug.Print("Zweiter Wert des Tupels:" & t.Item2.ToString)
        Debug.Print("Dritter Wert des Tupels:" & t.Item3)

        t = TupelFunktion
    End Sub

    Function TupelFunktion() As Tuple(Of Double, Integer, String)
        'Diese Funktion liefert drei Werte in einem Tuple gekapselt zurück.
        Return New Tuple(Of Double, Integer, String)(3.141592657, 20, "String")
    End Function




End Class
