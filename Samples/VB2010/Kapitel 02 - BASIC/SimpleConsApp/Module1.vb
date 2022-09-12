Option Infer On

Imports System.IO
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Module Module1

    Sub Main()

        'BooleanTest()
        'ArrayTest()
        'DoLoopDemo()
        ConditionCheck()
        'MultiplikationMitBitverschiebung()
        'Nullables()
        Console.ReadKey()
        Return

        Dim eingabe As String

        Do
            Console.Write("Bitte geben Sie Ihr Geburtsdatum ein (dd.mm.yyyy): ")
            eingabe = Console.ReadLine

            If eingabe = "uhrzeit" Then
                Console.WriteLine("Beim nächsten Ton ist es: " & Now.ToShortTimeString)
                Console.WriteLine()
                Beep()

            ElseIf eingabe = "heute" Then
                Console.WriteLine("Heute ist {0}, der {1}", _
                                  Now.ToString("dddd"), _
                                  Now.ToString("dd. MMMM yyyy"))
                Console.WriteLine()

            Else
                If eingabe IsNot Nothing AndAlso eingabe.Length > 6 Then

                    Try

                        Dim geburtsjahr As Date
                        Dim alter As Integer

                        geburtsjahr = Date.Parse(eingabe)
                        alter = CalcAlter(geburtsjahr)
                        Console.Write("Sie sind {0} Jahre alt", alter)
                        Console.WriteLine()
                        Console.WriteLine()
                    Catch ex As Exception
                        Console.WriteLine("Fehler: Ihre Eingabe hatte " & vbNewLine & _
                                          "vielleicht nicht das richtige Datumsformat!")
                        Console.WriteLine(ex.Message)
                        Console.WriteLine()
                        Console.WriteLine()
                    End Try
                End If
            End If
            'String.IsNullOrWhiteSpace ist eine statische Methode,
            'die überprüft, ob was anderes außer Leerzeichen (oder gar nichts)
            'eingegeben wurde.
        Loop While Not String.IsNullOrWhiteSpace(eingabe)

    End Sub

    ''' <summary>
    ''' Diese Methode berechnet das Alter in Jahren 
    ''' aus einem angegebenen Datum
    ''' </summary>
    ''' <param name="geburtsjahr">Das Geburtsdatum, das zur Altersberechnung dient</param>
    ''' <returns>Das Alter in Jahren.</returns>
    ''' <remarks>Keine besonderen Beerkungen sind erforderlich.</remarks>
    Function CalcAlter(ByVal geburtsjahr As Date) As Integer

        Dim retAlter As Integer
        Dim heute As Date = Date.Now
        Dim diffZumGeburtsdatum As TimeSpan

        diffZumGeburtsdatum = heute.Subtract(geburtsjahr)
        retAlter = diffZumGeburtsdatum.Days \ 365
        Return retAlter
    End Function
End Module

Public Module Testmodul

    Sub BooleanTest()
        Dim var = 5 = 5
        Console.WriteLine(var.ToString)
    End Sub

    Sub ArrayTest()
        Dim Name1 As String = "Lisa Feigenbaum"
        Dim Name2 As String = "Sarika Calla"
        Dim Name3 As String = "Ramona Leenings"
        Dim Name4 As String = "Beth Messi"
        Dim Name5 As String = "Tanja Gelo"

        Dim Namen() As String = {"Lisa Feigenbaum",
                                 "Sarika Calla",
                                 "Ramona Leenings",
                                 "Beth Messi",
                                 "Tanja Gelo"}

        Dim NameNo As Integer = 3
        Console.WriteLine(Namen(NameNo))
        Console.WriteLine("-------------------------")

        Dim AndereNamen As New List(Of String)
        AndereNamen.Add("Lisa Feigenbaum")
        AndereNamen.Add("Sarika Calla")
        AndereNamen.Add("Ramona Leenings")
        AndereNamen.Add("Beth Messi")
        AndereNamen.Add("Tanja Gelo")

        'Auf die dynamische Liste können Sie,
        'wie bei Arrays, auch per Index zugreifen
        Console.WriteLine(AndereNamen(NameNo))
        Console.WriteLine("-------------------------")

        'Mit For-Schleife durchlaufen und ausgeben:
        For index As Integer = 0 To Namen.Length - 1
            Console.WriteLine(Namen(index))
        Next
        Console.WriteLine("-------------------------")

        'Mit ForEach-Schleife durchlaufen und ausgeben:
        For Each name In Namen
            Console.WriteLine(name)
        Next
        Console.WriteLine("-------------------------")

        'Letztes Element erfährt Sonderbehandlung:
        For index As Integer = 0 To Namen.Length - 1
            If index < Namen.Length - 1 Then
                Console.WriteLine(Namen(index))
            Else
                Console.WriteLine("und last but not least: " & Namen(index))
            End If
        Next
        Console.WriteLine("-------------------------")
    End Sub

    Sub DoLoopDemo()

        Dim Namen() As String = {"Lisa Feigenbaum",
                                    "Sarika Calla",
                                    "Ramona Leenings",
                                    "Beth Messi",
                                    "Tanja Gelo"}

        'Die Namen einmal in aufsteigender Reihenfolge ...
        Dim index As Integer = 0
        Do While index < Namen.Length
            Console.WriteLine(Namen(index))
            index += 1
        Loop

        Console.WriteLine("-------------------------")
        Console.WriteLine("      und rückwärts:")
        Console.WriteLine("-------------------------")

        '... und in absteigender Reihenfolge ausgeben.
        index = Namen.Length - 1
        While index > -1
            Console.WriteLine(Namen(index))
            index -= 1
        End While

    End Sub

    Sub ConditionCheck()

        'Optionen ausgeben und Zeichen von der Tastatur lesen.
        Console.Write("Welche Funktion möchten Sie ausführen (1-9, 0 oder 'ende' zum Beenden): ")
        Dim eingabe = Console.ReadLine

        'Bei Eingabe von "0" oder "ende",
        If eingabe = "0" Or eingabe.ToUpper = "ENDE" Then
            'Methode beenden.
            Exit Sub
        End If

        'Wenn das gedrückte Zeichen größergleich "1" und kleinergleich "9" ist...
        If eingabe.Length = 1 And eingabe >= "1" And eingabe <= "9" Then
            '...dann war es eine gültige Auswahl, ...
            Console.WriteLine("Diese Funktion ist möglich!")
            '...anderenfalls...
        Else
            '...nicht.
            Console.WriteLine("Sie haben eine falsche Auswahl getroffen.")
        End If
    End Sub

    Public Sub MultiplikationMitBitverschiebung()
        Dim wert1, wert2, ergebniswert, hilfswert As Integer
        wert1 = 10
        wert2 = 5
        ergebniswert = 0
        hilfswert = wert2

        'Dieser Algorithmus funktioniert so, wie Sie
        'auch im Dezimalsystem "zu Fuß" multiplizieren:
        '
        '(10)   (5)
        '1010 * 101 =
        '------------
        '      1010 +
        '     0000  +
        '    1010
        '------------
        '    101010 = 50

        'Die "5" wird dazu bitweise nach rechts verschoben,
        'um ihr rechts äußeres Bit zu testen. Ist es gesetzt,
        'wird der Wert von 10 zunächst addiert, und dann sein
        'kompletter "Bitinhalt" um eine Stelle nach links verschoben; 
        'ist es hingegen nicht gesetzt, passiert gar nichts.
        'Dieser Vorgang wiederholt sich solange, bis alle
        'Bits von "5" verbraucht sind - die Variable hilfswert,
        'die diesen Wert verarbeitet, also 0 geworden ist.
        'Für eine Multiplikation sind also gerade so viele 
        'Additionen nötig, wie Bits im zweiten Wert gesetzt sind.
        Do
            If (hilfswert And 1) = 1 Then
                ergebniswert += wert1
            End If
            wert1 = wert1 << 1
            hilfswert = hilfswert >> 1
        Loop Until hilfswert = 0
        Console.WriteLine("Das Ergebnis lautet:" & ergebniswert)
    End Sub

    Public Sub Nullables()

        Dim count As Integer
        count = count + 1
        Console.WriteLine("Count ist: " & count.ToString)

        Dim nullableCount As Integer?
        nullableCount = 0
        nullableCount = nullableCount + 1
        Console.WriteLine("Nullable Count ist: " & nullableCount.ToString)

        Dim anotherNullable As Integer?         ' Hat keinen Wert, bzw. Wert ist unbekannt.
        anotherNullable = anotherNullable + 1   ' und dabei bleibt es.
        Console.WriteLine("anotherNullable ist: " & anotherNullable.ToString)

        Console.WriteLine("Hat nullableCount einen Wert: " & nullableCount.HasValue.ToString)
        Console.WriteLine("Hat anotherNullable einen Wert: " & anotherNullable.HasValue.ToString)
    End Sub
End Module

'Module TypeSafety

'    Sub TypeSafety()

'        'Nicht Typsicher: String --> Char geht nicht.
'        Dim einChar As Char = "H"

'        'Geht in Ordnung: Typliteral definiert als Char.
'        Dim einAndererChar As Char = "H"c

'        'Geht wieder nicht: Char darf nur ein Zeichen sein.
'        Dim nochEinAndererChar As Char="Hallo"c


'        Dim einString As String
'        einString = 3.14159

'        Dim einLong As Long = 1000
'        Dim einInteger As Integer

'        einInteger = einLong
'    End Sub

'End Module
