Public Class VBIntElements

    Private myIntElements() As Integer

    Sub New(ByVal AmountOfElements As Integer)

        ReDim myIntElements(AmountOfElements - 1)
        Dim locRandom As New Random(DateTime.Now.Millisecond)

        For locCount As Integer = 0 To AmountOfElements - 1
            myIntElements(locCount) = locRandom.Next
        Next

    End Sub

    Sub ShellSort()

        Dim locOutCount, locInCount As Integer
        Dim locDelta As Integer
        Dim locIntTemp As Integer

        locDelta = 1

        'Größten Wert der Distanzfolge ermitteln
        Do
            locDelta = 3 * locDelta + 1
        Loop Until locDelta > myIntElements.Length

        Do
            'War einen zu groß, also wieder teilen
            locDelta /= 3

            'Shellsort's Kernalgorithmus
            For locOutCount = locDelta To myIntElements.Length - 1
                locIntTemp = myIntElements(locOutCount)
                locInCount = locOutCount
                Do While (myIntElements(locInCount - locDelta) > locIntTemp)
                    myIntElements(locInCount) = myIntElements(locInCount - locDelta)
                    locInCount = locInCount - locDelta
                    If (locInCount <= locDelta) Then Exit Do
                Loop
                myIntElements(locInCount) = locIntTemp
            Next
        Loop Until locDelta = 0

    End Sub

    'Die ersten 'AmountElements' auf dem Bildschirm ausgeben
    Sub PrintOut(ByVal AmountElements As Integer)

        For locCount As Integer = 0 To AmountElements - 1
            Console.WriteLine(myIntElements(locCount).ToString)
        Next

    End Sub

End Class

Public Class VBStrElements

    Private Const cChars = 10
    Private myStrElements() As String

    Sub New(ByVal AmountOfElements As Integer)

        ReDim myStrElements(AmountOfElements - 1)
        Dim locRandom As New Random(DateTime.Now.Millisecond)
        Dim locChars(cChars) As Char

        For locOutCount As Integer = 0 To AmountOfElements - 1
            For locInCount As Integer = 0 To cChars - 1
                Dim locIntTemp As Integer = Convert.ToInt32(locRandom.NextDouble * 52)
                If locIntTemp > 26 Then
                    locIntTemp += 97 - 26
                Else
                    locIntTemp += 65
                End If
                locChars(locInCount) = Convert.ToChar(locIntTemp)
            Next
            myStrElements(locOutCount) = New String(locChars)
        Next
    End Sub

    Sub ShellSort()

        Dim locOutCount, locInCount As Integer
        Dim locDelta As Integer
        Dim locStrTemp As String

        locDelta = 1

        'Größten Wert der Distanzfolge ermitteln
        Do
            locDelta = 3 * locDelta + 1
        Loop Until locDelta > myStrElements.Length

        Do
            'War einen zu groß, also wieder teilen
            locDelta /= 3

            'Shellsort's Kernalgorithmus
            For locOutCount = locDelta To myStrElements.Length - 1
                locStrTemp = myStrElements(locOutCount)
                locInCount = locOutCount
                Do While (myStrElements(locInCount - locDelta) > locStrTemp)
                    myStrElements(locInCount) = myStrElements(locInCount - locDelta)
                    locInCount = locInCount - locDelta
                    If (locInCount <= locDelta) Then Exit Do
                Loop
                myStrElements(locInCount) = locStrTemp
            Next
        Loop Until locDelta = 0

    End Sub




End Class
