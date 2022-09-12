Imports System.IO

Public Class Form1

    Private Sub btnVbUndFrameworkTypen_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles btnVbUndFrameworkTypen.Click
        'Ein im VB-deklarierte Datentyp unterscheidet...
        Dim locDatum1 As Date
        '...sich nicht von seiner Framework-Version!
        Dim locDatum2 As System.DateTime

        'Das ging in VB6 übrigens auch nicht!
        locDatum1 = #12/24/2005 6:30:00 PM#

        'Hier ist der Beweis: Keiner meckert.
        locDatum2 = locDatum1

        'Übrigens: {0} und {1} werden durch die darauffolgenden 
        'Variableninhalte ersetzt. Hinter dem Doppelpunkt folgt
        'jeweils die Formatierungszeichenfolge.
        Debug.Print("Dieses Jahr am {0:dd.MM.yy}, also Heiligabend essen wir um {1:HH:mm}", _
            locDatum2.Date, _
            locDatum2.TimeOfDay)
    End Sub

    Private Sub btnVariablentypzeichen_Click(ByVal sender As System.Object, _
            ByVal EArgs As System.EventArgs) Handles btnVariablentypzeichen.Click

        'Beide sind Integer - anders als in VB6!
        Dim locInt1, locInt2 As Integer

        'Auch das geht...
        Dim locDate1, locDate2 As Date, locLong1, locLong2 As Long

        'Und das hier auch:
        Dim a%, b&, c@, d!, e#, f$
        f$ = "Muss was drin sein!"

        'Alle Variablentypen in Klartext ausgeben:
        Debug.Print("locInt1 ist: " & locInt1.GetType.ToString)
        Debug.Print("locInt2 ist: " & locInt2.GetType.ToString)
        Debug.Print("locDate1 ist: " & locDate1.GetType.ToString)
        Debug.Print("locDate2 ist: " & locDate2.GetType.ToString)
        Debug.Print("locLong1 ist: " & locLong1.GetType.ToString)
        Debug.Print("locLong2 ist: " & locLong2.GetType.ToString)

        Debug.Print("a ist: " & a.GetType.ToString)
        Debug.Print("b ist: " & b.GetType.ToString)
        Debug.Print("c ist: " & c.GetType.ToString)
        Debug.Print("d ist: " & d.GetType.ToString)
        Debug.Print("e ist: " & e.GetType.ToString)
        Debug.Print("f ist: " & f.GetType.ToString)
    End Sub

    Private Sub btnStringsSindObjekte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringsSindObjekte.Click

        Dim einString As String
        einString = "Ruprecht Dröge"

        'Position des Leerzeichens ermitteln
        Dim spacePos As Integer = einString.IndexOf(" "c)


        'Nur den Vornamen ermittelt - das ging "früher" mit Mid$
        einString = einString.Substring(0, spacePos)
        Debug.Print(einString)

    End Sub

    Private Sub btnDateiLesenDotNet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateiLesenDotNet.Click
        'WICHTIG:
        'Um auf die IO-Objekte zuzugreifen, muss "Imports System.IO"
        'am Anfang der Codedatei stehen!

        Dim meinDateiInhalt As String
        Dim dateiStromLeser As StreamReader

        Try
            'Diese folgenden Befehle probieren (try=versuchen, ausprobieren).
            dateiStromLeser = New StreamReader("C:\eineTextdatei.txt")
            meinDateiInhalt = dateiStromLeser.ReadToEnd()
            dateiStromLeser.Close()
            Debug.Print(meinDateiInhalt)
        Catch ex As FileNotFoundException
            'Hier werden nur FileNotFoundExceptions abgefangen
            MessageBox.Show("Datei wurde nicht gefunden!" & vbNewLine & _
                            vbNewLine & "Der Ausnahmetext lautete:" & vbNewLine & ex.Message, _
                            "Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            'Hier werden alle anderen bis zu diesem Zeitpunkt nicht
            'behandelten Ausnahmen abgefangen
            MessageBox.Show("Beim Verarbeiten der Datei trat eine Ausnahme auf!" & vbNewLine & _
                            "Die Ausnahme war vom Typ:" & ex.GetType.ToString & vbNewLine & _
                            vbNewLine & "Der Ausnahmetext lautete:" & vbNewLine & ex.Message, _
                            "Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDateiLesenVB6Stil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDateiLesenVB6Stil.Click
        'WICHTIG:
        'Um auf die IO-Objekte zuzugreifen, muss "Imports System.IO"
        'am Anfang der Codedatei stehen!

        Dim DateiNichtGefundenFlag As Boolean
        'Derselbe Blödsinn geht hier in .NET auch!
        On Error GoTo 1000

        Dim meinDateiInhalt As String
        '1: Wenn hier ein Fehler auftritt
        Dim dateiStromLeser As New StreamReader("C:\eineTextdatei.txt")
        '3: um das durch Resume Next hier wieder zu landen
        If DateiNichtGefundenFlag Then
            '4: und den Fehler abzufangen
            MessageBox.Show("Datei wurde nicht gefunden!")
        Else
            'Trat kein Fehler auf, wird dieser Block ausgeführt
            meinDateiInhalt = dateiStromLeser.ReadToEnd()
            dateiStromLeser.Close()
            'Und der Dateiinhalt ausgegeben.
            Debug.Print(meinDateiInhalt)
        End If
        Exit Sub

        '2: Fährt der Programmablauf hier fort
1000:   If Err.Number = 53 Then
            DateiNichtGefundenFlag = True
            Resume Next
        End If

    End Sub

    Private Sub btnTryCatchFinally_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTryCatchFinally.Click
        'WICHTIG:
        'Um auf die IO-Objekte zuzugreifen, muss "Imports System.IO"
        'am Anfang der Codedatei stehen!

        Dim meinDateiInhalt As String
        Dim dateiStromLeser As StreamReader

        Try
            'Diese folgenden Befehle probieren (try=versuchen, ausprobieren).
            dateiStromLeser = New StreamReader("C:\eineTextdatei.txt")
            Dim locZeile As String
            meinDateiInhalt = ""
            'Jetzt lesen wir zeilenweise aber viel zu viele Zeilen, 
            'und schießen daher irgendwann über das Ende der Datei hinaus:
            Try
                ' Wenn Ihre Datei "C:\eineTextdatei" nicht gerade
                ' 1001 Zeilen enthält, knallt es hier, denn:
                For zeilenzähler As Integer = 0 To 1000
                    locZeile = dateiStromLeser.ReadLine()
                    'locZeile ist jetzt Nothing, und dann kann
                    'die Konvertierung in Großbuchstaben nicht mehr
                    'funktionieren.
                    locZeile = locZeile.ToUpper
                    meinDateiInhalt &= locZeile
                Next
            Catch ex As NullReferenceException
                MessageBox.Show("Die Zeile konnte nicht in umgewandelt werden, weil sie leer war!")
                ' Return? Aber die Datei ist doch noch geöffnet!!!
                Return
            Finally
                ' Egal! Auch bei Return im Catch-Block wird Finally in jedem Fall noch ausgeführt!
                dateiStromLeser.Close()
            End Try
            'Aber diese Zeile wird nur im Erfolgfall abgearbeitet:
            Debug.Print(meinDateiInhalt)
        Catch ex As FileNotFoundException
            'Hier werden nur FileNotFoundExceptions abgefangen
            MessageBox.Show("Datei wurde nicht gefunden!" & vbNewLine & _
                            vbNewLine & "Der Ausnahmetext lautete:" & vbNewLine & ex.Message, _
                            "Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            'Hier werden alle anderen bis zu diesem Zeitpunkt nicht
            'behandelten Ausnahmen abgefangen
            MessageBox.Show("Beim Verarbeiten der Datei trat eine Ausnahme auf!" & vbNewLine & _
                            "Die Ausnahme war vom Typ:" & ex.GetType.ToString & vbNewLine & _
                            vbNewLine & "Der Ausnahmetext lautete:" & vbNewLine & ex.Message, _
                            "Ausnahme", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAndAlsoDemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAndAlsoDemo.Click
        Dim einString As String = "Klaus ist das Wort, mit dem diese Zeile beginnt"
        If einString IsNot Nothing AndAlso einString.Substring(0, 5).ToUpper = "KLAUS" Then
            MessageBox.Show("Die Zeichenfolge beginnt mit Klaus!")
        End If

        If einString IsNot Nothing And einString.Substring(0, 5).ToUpper = "KLAUS" Then
            MessageBox.Show("Die Zeichenfolge beginnt mit Klaus!")
        End If
    End Sub

    Private Sub btnSchleifendemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSchleifendemo.Click
        For zähler As Integer = 0 To 100
            Debug.Print("Wert:" & zähler)
        Next

        Dim auflistung As New ArrayList
        auflistung.Add(5)
        auflistung.Add(10)
        auflistung.Add(15)
        auflistung.Add(20)

        For Each element As Integer In auflistung
            Debug.Print("Wert:" & element)
        Next
    End Sub

    Private Sub btnMultiplikationMitBitverschiebung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMultiplikationMitBitverschiebung.Click
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
        Debug.Print("Das Ergebnis lautet:" & ergebniswert)
    End Sub
End Class
