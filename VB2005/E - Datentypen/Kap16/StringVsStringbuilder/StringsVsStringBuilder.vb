Imports System.Text

Module StringsVsStringBuilder

    Sub Main()
        Dim locTimeGauge As New HighSpeedTimeGauge
        Dim locAmountElements As Integer
        Dim locAmountCharsPerElement As Integer
        Dim locVBStringElements As VBStringElements
        Dim locVBStringBuilderElements As VBStringBuilderElements

        'StringBuilderBeispiele()
        'Return

        Console.Write("Geben Sie die String-Länge eines Elementes ein: ")
        locAmountCharsPerElement = Integer.Parse(Console.ReadLine)
        Console.Write("Geben die Anzahl der zu erzeugenden Elemente ein: ")
        locAmountElements = Integer.Parse(Console.ReadLine)
        Console.WriteLine()
        Console.WriteLine("Erzeugen von " & locAmountElements & " Stringelementen mit der String-Klasse...")
        locTimeGauge.Start()
        locVBStringElements = New VBStringElements(locAmountElements, locAmountCharsPerElement)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        locTimeGauge.Reset()
        Console.WriteLine("Erzeugen von " & locAmountElements & " Stringelementen mit der StringBuilder-Klasse...")
        locTimeGauge.Start()
        locVBStringBuilderElements = New VBStringBuilderElements(locAmountElements, locAmountCharsPerElement)
        locTimeGauge.Stop()
        Console.WriteLine("Dauer: " & locTimeGauge.ToString())
        locTimeGauge.Reset()
        Console.WriteLine()
        Console.ReadLine()

    End Sub

    Sub StringBuilderBeispiele()

        'Deklaration ohne Parameter:
        Dim locSB As New StringBuilder
        'Deklaration mit Kapazitätsreservierung
        locSB = New StringBuilder(1000)
        'Deklaration aus einem vorhandenen String
        locSB = New StringBuilder("Aus einem neuen String entstanden")
        'Deklaration aus String mit der Angabe einer zu reservierenden Kapazität
        locSB = New StringBuilder("Aus String entstanden mit Kapazität für weitere", 1000)

        locSB.Append(" - und das wird an den String angefügt")
        locSB.Insert(20, ">>das kommt irgendwo in die Mitte<<")
        locSB.Replace("String", "StringBuilder")
        locSB.Remove(0, 4)

        'StrinBuilder hat den String fertig zusammengesetzt,
        'in String umwandeln
        Dim locString As String = locSB.ToString
        Console.WriteLine(locString)
        Console.ReadLine()
    End Sub

End Module

Public Class VBStringElements

    Private myStrElements() As String

    Sub New(ByVal AmountOfElements As Integer, ByVal AmountChars As Integer)

        ReDim myStrElements(AmountOfElements - 1)
        Dim locRandom As New Random(DateTime.Now.Millisecond)
        Dim locString As String

        For locOutCount As Integer = 0 To AmountOfElements - 1
            locString = ""
            For locInCount As Integer = 0 To AmountChars - 1
                Dim locIntTemp As Integer = Convert.ToInt32(locRandom.NextDouble * 52)
                If locIntTemp > 26 Then
                    locIntTemp += 97 - 26
                Else
                    locIntTemp += 65
                End If
                locString += Convert.ToChar(locIntTemp).ToString
            Next
            myStrElements(locOutCount) = locString
        Next
    End Sub

End Class

Public Class VBStringBuilderElements

    Private myStrElements() As String

    Sub New(ByVal AmountOfElements As Integer, ByVal AmountChars As Integer)

        ReDim myStrElements(AmountOfElements - 1)
        Dim locRandom As New Random(DateTime.Now.Millisecond)
        Dim locStringBuilder As StringBuilder

        For locOutCount As Integer = 0 To AmountOfElements - 1
            locStringBuilder = New StringBuilder(AmountChars)
            For locInCount As Integer = 0 To AmountChars - 1
                Dim locIntTemp As Integer = Convert.ToInt32(locRandom.NextDouble * 52)
                If locIntTemp > 26 Then
                    locIntTemp += 97 - 26
                Else
                    locIntTemp += 65
                End If
                locStringBuilder.Append(Convert.ToChar(locIntTemp))
            Next
            myStrElements(locOutCount) = locStringBuilder.ToString
        Next
    End Sub

End Class
