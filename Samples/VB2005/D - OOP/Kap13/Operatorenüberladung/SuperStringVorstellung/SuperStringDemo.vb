Module Main

    Sub Main()
        'Deklaration und Definition eines normalen Strings
        Dim locNormaloString As String
        locNormaloString = "Wenn man seinen Kopf gegen eine "
        locNormaloString = locNormaloString + "eine Wand schlägt, verbraucht man 150 Kalorien."
        Console.WriteLine("Ausgangszeichenfolge:")
        Console.WriteLine(locNormaloString)

        'Deklaration und Definition eines Super-Strings
        Dim locSuperString As New SuperString(locNormaloString)

        'SuperString-Funktionsdemo: Addieren (anhängen) anderer Strings
        Console.WriteLine()
        Console.WriteLine("'Addieren' von Strings - 'Toll, was?' anhängen:")
        'locSuperString = locSuperString.Addieren( _
        '        New SuperString(vbNewLine + " - Toll, was?"))
        locSuperString = locSuperString + New SuperString(vbNewLine + " - Toll, was?")
        Console.WriteLine(locSuperString.ToString)


        'Subtrahieren (rauslöschen) anderer Strings
        Console.WriteLine()
        Console.WriteLine("'Subtrahieren' von Strings - ', was?' abziehen:")
        'locSuperString = locSuperString.Subtrahieren( _
        '        New SuperString(", was"))
        locSuperString = locSuperString - New SuperString(", was")
        Console.WriteLine(locSuperString.ToString)
        Console.WriteLine()

        'Subtrahieren ist überladen - geht auch mit der Anzahl
        'der letzten Zeichen, die entfernt werden sollen.
        Console.WriteLine("'Subtrahieren' von Strings - die letzten 9 Zeichen abziehen:")
        locSuperString = locSuperString - 9
        Console.WriteLine(locSuperString.ToString)
        Console.WriteLine()

        'Vervielfachen von Strings
        Console.WriteLine("'Vervielfachen' von Strings:")
        locSuperString = locSuperString.Vervielfachen(4)
        Console.WriteLine(locSuperString.ToString)
        Console.WriteLine()

        '(Auf)teilen von Strings - schon etwas anspruchsvoller
        locSuperString = New SuperString("Der Glückskeks wurde 1916 von George Jung, " & _
                        "einem amerikanischem Nudelmacher erfunden.")
        Console.WriteLine("'(Auf)teilen' von Strings:")
        Console.WriteLine(locSuperString.ToString)
        Dim locSuperStrings() As SuperString
        locSuperStrings = locSuperString.Teilen(" "c)
        For Each locSString As SuperString In locSuperStrings
            Console.WriteLine(locSString.ToString)
        Next
        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
        Exit Sub

        TypkonvertierungsExperimente()
        ExperimenteFürBoolscheAusdrücke()

    End Sub

    Sub TypkonvertierungsExperimente()
        'Hier geht's mit impliziter (da typerweiternder) Konvertierung
        Dim einLong As Long, einInteger As Integer
        einInteger = 10
        einLong = einInteger

        'Das hier erfordert eine explizite, da typverkleinernde Konvertierung
        einLong = 1000
        einInteger = CType(einLong, Integer)

        'Aber auch diese Konvertierung muss explizit durchgeführt werden
        Dim einDouble As Double, einString As String
        einString = "1.828.488.382,45"
        einDouble = CType(einString, Long)

    End Sub

    Sub ExperimenteFürBoolscheAusdrücke()
        'Hier geht's mit impliziter (da typerweiternder) Konvertierung
        Console.Write("Möchten Sie weitere Daten eingeben (Ja, Nein):")
        Dim locSupStr As SuperString = Console.ReadLine
        If locSupStr Then
            Console.WriteLine("OK, dann geben Sie mal ein!")
        Else
            Console.WriteLine("dann halt nicht...")
        End If
        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub
End Module

Public Structure SuperString

    Private myValue As String

    Public Sub New(ByVal Value As String)
        myValue = Value
    End Sub

    Public Overrides Function ToString() As String
        Return myValue
    End Function

    Public Function Addieren(ByVal andererString As SuperString) As SuperString
        Return New SuperString(myValue & andererString.ToString)
    End Function

    Public Function Subtrahieren(ByVal andererString As SuperString) As SuperString
        Return New SuperString(myValue.Replace(andererString.ToString, ""))
    End Function

    Public Function Subtrahieren(ByVal letztenZeichen As Integer) As SuperString
        Try
            Return New SuperString(myValue.Substring(0, myValue.Length - (letztenZeichen + 1)))
        Catch ex As Exception
            Return New SuperString(myValue)
        End Try
    End Function

    Public Function Vervielfachen(ByVal anzahl As Integer) As SuperString

        'Wir sind ordentlich und vermeiden Fehler! ;-)
        If myValue Is Nothing Then
            Return Nothing
        End If

        If myValue = "" Or anzahl < 1 Then
            Return New SuperString("")
        End If

        'Mit dem StringBuilder geht das am schnellsten!
        Dim locSB As New System.Text.StringBuilder

        'Einfach den Ausgangsstring sooft anhängen,
        'wie es 'anzahl' vorgibt.
        For c As Integer = 1 To anzahl
            locSB.Append(myValue)
        Next

        'und zurück damit!
        Return New SuperString(locSB.ToString)
    End Function

    Public Function Teilen(ByVal trennzeichen As Char) As SuperString()
        Dim locStringArray As String()
        locStringArray = myValue.Split(New Char() {trennzeichen})

        Dim locSuperStringArray(locStringArray.Length - 1) As SuperString
        For z As Integer = 0 To locStringArray.Length - 1
            locSuperStringArray(z) = New SuperString(locStringArray(z))
        Next
        Return locSuperStringArray

    End Function

    'Operator +:
    Public Shared Operator +(ByVal sstring1 As SuperString, ByVal sstring2 As SuperString) As SuperString
        Return sstring1.Addieren(sstring2)
    End Operator

    Public Shared Operator +(ByVal sstring1 As SuperString, ByVal sstring2 As String) As SuperString
        Return sstring1.Addieren(sstring2)
    End Operator

    Public Shared Operator -(ByVal sstring1 As SuperString, ByVal sstring2 As SuperString) As SuperString
        Return sstring1.Subtrahieren(sstring2)
    End Operator

    Public Shared Operator -(ByVal sstring1 As SuperString, ByVal anzahl As Integer) As SuperString
        Return sstring1.Subtrahieren(anzahl)
    End Operator

    Public Shared Operator *(ByVal sstring1 As SuperString, ByVal anzahl As Integer) As SuperString
        Return sstring1.Vervielfachen(anzahl)
    End Operator

    Public Shared Operator /(ByVal sstring1 As SuperString, ByVal trennzeichen As Char) As SuperString()
        Return sstring1.Teilen(trennzeichen)
    End Operator

    Public Shared Operator <>(ByVal sString1 As SuperString, ByVal sString2 As SuperString) As Boolean
        Return (sString1.ToString <> sString2.ToString)
    End Operator

    Public Shared Operator =(ByVal sString1 As SuperString, ByVal sString2 As SuperString) As Boolean
        Return (sString1.ToString = sString2.ToString)
    End Operator

    Public Shared Operator <(ByVal sString1 As SuperString, ByVal sString2 As SuperString) As Boolean
        Return (sString1.ToString < sString2.ToString)
    End Operator

    Public Shared Operator >(ByVal sString1 As SuperString, ByVal sString2 As SuperString) As Boolean
        Return (sString1.ToString > sString2.ToString)
    End Operator


    Public Shared Widening Operator CType(ByVal normaloString As String) As SuperString
        Return New SuperString(normaloString)
    End Operator

    Public Shared Widening Operator CType(ByVal SuperString As SuperString) As String
        Return SuperString.ToString
    End Operator

    'Public Shared Narrowing Operator CType(ByVal normaloString As String) As SuperString
    '    Return New SuperString(normaloString)
    'End Operator

    Public Shared Operator IsTrue(ByVal sString As SuperString) As Boolean
        Dim locString As String = sString
        locString = locString.ToUpper
        Select Case locString
            Case "JA"
                Return True
            Case "J"
                Return True
            Case "RICHTIG"
                Return True
            Case "WAHR"
                Return True
            Case "AUSGEWÄHLT"
                Return True
            Case "GEDRÜCKT"
                Return True
            Case "BESTÄTIGT"
                Return True
            Case "Y"
                Return True
            Case "YES"
                Return True
            Case "TRUE"
                Return True
            Case "CORRECT"
                Return True
            Case "SELECTED"
                Return True
            Case "PRESSED"
                Return True
            Case "ACCEPTED"
                Return True
            Case "CONFIRMED"
                Return True
        End Select
        Return False
    End Operator

    Public Shared Operator IsFalse(ByVal sString As SuperString) As Boolean
        If sString Then
            Return False
        Else
            Return True
        End If
    End Operator



End Structure
