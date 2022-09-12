Imports System.Globalization

Module CustomFormatProvider

    Sub Main()

        'Ändern Sie die Auskommentierung und den Aufruf der SpielchenX-Prozedur,
        'um mit den anderen Beispielen zu experimentieren!

        'Spielchen4()
        'Return

        Dim locEngKultur As New CultureInfo("en-US")

        Console.Write("Geben Sie einen Wert in Metern zur Umrechnung ein: ")
        Dim locLaenge As New Laengen(Decimal.Parse(Console.ReadLine))

        'Umgerechneten Wert anzeigen:
        Console.WriteLine("        mm        |       cm         |         m        |        km        |")
        Console.WriteLine("{0,17} |{1,17} |{2,17} |{3,17} |", _
            locLaenge.ToString("s-d;#,##0.00000"), _
            locLaenge.ToString("k-d;#,##0.00000"), _
            locLaenge.ToString("m-d;#,##0.00000"), _
            locLaenge.ToString("g-d;#,##0.00000"))

        Console.WriteLine()
        'Umgerechneten Wert anzeigen:
        Console.WriteLine("      lines       |      inches      |       yards      |       miles      |")
        Console.WriteLine("{0,17} |{1,17} |{2,17} |{3,17} |", _
            locLaenge.ToString("s;#,##0.00000", locEngKultur), _
            locLaenge.ToString("k-e;#,##0.00000"), _
            locLaenge.ToString(";#,##0.00000", _
                New LaengenFormatInfo(LaengenKultur.EnglischAmerikanisch, LaengenAufloesung.Mittel)), _
            locLaenge.ToString("g;#,##0.00000", locEngKultur))
        Console.ReadLine()

    End Sub

    Sub Spielchen()

        'Definiert eine Laengen-Instanz mit 1 (einem Meter)
        Dim locLaenge As New Laengen(1)
        'Gibt auf einem deutschen System den Klasseninstanzwert in Millimeter aus.
        Console.WriteLine(locLaenge.ToString("s"))

        'Auf einem englischen oder amerikanischen System würde die vorherige Zeile
        'die gleiche Ausgabe, wie die folgende bewirken
        Console.WriteLine(locLaenge.ToString("s", New CultureInfo("en-US")))
        Console.ReadLine()
    End Sub

    Sub Spielchen2()

        'Definiert eine Laengen-Instanz mit 1 (einem Meter)
        Dim locLaenge As New Laengen(1)
        'Gibt auf jedem System den Klasseninstanzwert in Millimeter aus.
        Console.WriteLine(locLaenge.ToString("s-d"))
        'Gibt auf jedem System den Klasseninstanzwert in Lines aus.
        Console.WriteLine(locLaenge.ToString("s-e"))

        Console.ReadLine()
    End Sub

    Sub Spielchen3()

        'Definiert eine Laengen-Instanz mit 1 (einem Meter)
        Dim locLaenge As New Laengen(1)
        'Gibt auf jedem System den Klasseninstanzwert in Millimeter aus.
        Console.WriteLine(locLaenge.ToString("s-d;#,##0.00"))
        'Gibt auf jedem System den Klasseninstanzwert in Lines aus.
        Console.WriteLine(locLaenge.ToString("s-e;#,##0.00"))

        Console.ReadLine()
    End Sub

    Sub Spielchen4()

        'Definiert eine Laengen-Instanz mit 1 (einem Meter)
        Dim locLaenge As New Laengen(1)
        Dim locLaengenFormatInfo As New LaengenFormatInfo

        locLaengenFormatInfo.Aufloesung = LaengenAufloesung.SehrKlein
        locLaengenFormatInfo.Kultur = LaengenKultur.Deutsch

        'Gibt auf jedem System den Klasseninstanzwert in Millimeter aus.
        Console.WriteLine(locLaenge.ToString(locLaengenFormatInfo))
        'Gibt auf jedem System den Klasseninstanzwert in Lines aus.
        locLaengenFormatInfo.Kultur = LaengenKultur.EnglischAmerikanisch
        Console.WriteLine(locLaenge.ToString(locLaengenFormatInfo))

        Console.ReadLine()

    End Sub

    Sub FormatterTest()

        'Definiert eine Laengen-Instanz mit 1 (einem Meter)
        Dim locLaenge As New Laengen(1)
        Dim locLaengenFormatInfo As New LaengenFormatInfo

        locLaengenFormatInfo.Aufloesung = LaengenAufloesung.SehrKlein
        locLaengenFormatInfo.Kultur = LaengenKultur.EnglischAmerikanisch

        'Testen der Format-Funktion
        Dim locStr As String = String.Format(locLaengenFormatInfo, _
           "Testausgabe {0:; #.##0.00} eines Laengen-Objektes", _
            locLaenge)
        Console.WriteLine(locStr)

        'Testen des Formatters
        Console.WriteLine("Testausgabe {0:g-d; #.##0.00} eines Laengen-Objektes", locLaenge)

        Console.ReadLine()

    End Sub


End Module

Public Enum LaengenAufloesung
    SehrKlein   ' Millimeter oder Line
    Klein       ' Zentimeter oder Inch
    Mittel      ' Meter oder Yard
    Groß        ' Kilometer oder Mile
End Enum

Public Enum LaengenKultur
    EnglischAmerikanisch
    Deutsch
End Enum

Public Class LaengenFormatInfo
    Implements IFormatProvider

    Private myKultur As LaengenKultur
    Private myAufloesung As LaengenAufloesung

    Sub New()
        myKultur = LaengenKultur.Deutsch
        myAufloesung = LaengenAufloesung.Mittel
    End Sub

    Sub New(ByVal Kultur As LaengenKultur)
        myKultur = Kultur
        myAufloesung = LaengenAufloesung.Mittel
    End Sub

    Sub New(ByVal Kultur As LaengenKultur, ByVal Aufloesung As LaengenAufloesung)
        myKultur = Kultur
        myAufloesung = Aufloesung
    End Sub

    Public Shared Function FromFormatProvider(ByVal formatProvider As IFormatProvider) As LaengenFormatInfo

        Dim retLaengenFormatInfo As LaengenFormatInfo

        If formatProvider Is Nothing Then
            formatProvider = CultureInfo.CurrentCulture
        End If

        If DirectCast(formatProvider, CultureInfo).ThreeLetterISOLanguageName = "deu" Then
            retLaengenFormatInfo = _
                New LaengenFormatInfo(LaengenKultur.Deutsch, LaengenAufloesung.Mittel)
        Else
            retLaengenFormatInfo = _
                New LaengenFormatInfo(LaengenKultur.EnglischAmerikanisch, LaengenAufloesung.Mittel)
        End If
        Return retLaengenFormatInfo

    End Function

    Public Function GetFormat(ByVal formatType As System.Type) As Object Implements System.IFormatProvider.GetFormat
        Trace.WriteLine("Ausgabe von GetFormat:" + formatType.Name)
        'Wird mein Typ verlangt?
        'If formatType.Name = "ICustomFormatter" Then
        '    'Ja, diese Instanz ist erlaubt zu handeln!
        '    Return Me
        'Else
        '    'Falscher Typ, diese Instanz darf nichts machen, denn
        '    'wenn sie als Provider einem nicht kompatiblen Typ
        '    'übergeben wird, geht's in die Hose
        '    Return Nothing
        'End If
    End Function

    Public Function Format(ByVal formatChars As String, _
                ByVal arg As Object, _
                ByVal formatProvider As System.IFormatProvider) As String _

        Dim locLaengen As Laengen

        Trace.WriteLine("Format (CustomFormatter-Signatur) wurde aufgerufen!")
        'Dafür sorgen, dass das zu formatierende Element und der FormatProvider übereinstimmen
        If Not TypeOf arg Is Laengen Then
            Return String.Format(formatProvider, formatChars, arg)
        End If

        locLaengen = DirectCast(arg, Laengen)

        'Dafür sorgen, dass die Formatzeichenfolge nie "nichts" ist.
        If formatChars Is Nothing Then
            formatChars = ""
        End If

        'Mit Semikolon können Formatzeichen für die Formatierung des eigentlichen Wertes folgen
        Dim locSemikolonPos As Integer = formatChars.IndexOf(";"c)

        'Standardzeichen für die Formatzeichen zur Werteformatierung vorgeben
        Dim locNumFormat As String = "G"

        'Doppelpunkt gefunden
        If locSemikolonPos > -1 Then
            'Das ist die Formatzeichenfolge für die Werteformatierung
            locNumFormat = formatChars.Substring(locSemikolonPos + 1)

            'Das für die Wahl der Längeneinheit
            formatChars = formatChars.Substring(0, locSemikolonPos)

            'Leerstring kommt nicht in Frage
            If locNumFormat = "" Then
                locNumFormat = "G"
            End If
        End If

        'Nur noch kein, eins oder drei Zeichen Kommen in Frage
        If formatChars.Length <> 0 And formatChars.Length <> 1 And formatChars.Length <> 3 Then
            Dim up As New FormatException("Ungültige(s) Formatzeichen für die Kulturbestimmung!")
            Throw up
        End If

        'Wenn drei Zeichen, dann wird die Einstellung des FormatProviders ignoriert; 
        'das Formatzeichen ist der Bestimmer!
        If formatChars.Length = 3 Then
            If formatChars.ToUpper.EndsWith("-D") Then
                formatProvider = New LaengenFormatInfo(LaengenKultur.Deutsch)
                formatChars = formatChars.Substring(0, 1)
            ElseIf formatChars.ToUpper.EndsWith("-E") Then
                formatProvider = New LaengenFormatInfo(LaengenKultur.EnglischAmerikanisch)
                formatChars = formatChars.Substring(0, 1)
            Else
                Dim up As New FormatException("Ungültiges Formatzeichen für die Kulturbestimmung!")
                Throw up
            End If
        End If

        'Zu diesem Zeitpunkt ist formatProvider unbedingt eine LaengenformatInfo,
        'das folgende Casting kann also nicht schiefgehen
        Dim locLaengenFormatInfo As LaengenFormatInfo = DirectCast(formatProvider, LaengenFormatInfo)

        'formatChars besteht aus (jetzt noch) nur einem Zeichen

        If formatChars.Length = 1 Then
            'S' für 'Sehr klein'
            If formatChars.ToUpper.StartsWith("S") Then
                locLaengenFormatInfo.Aufloesung = LaengenAufloesung.SehrKlein
            End If

            'K' für 'klein' 
            If formatChars.ToUpper.StartsWith("K") Then
                locLaengenFormatInfo.Aufloesung = LaengenAufloesung.Klein
            End If

            'M' für 'Mittel'
            If formatChars.ToUpper.StartsWith("M") Then
                locLaengenFormatInfo.Aufloesung = LaengenAufloesung.Mittel
            End If

            'G' für 'groß'
            If formatChars.ToUpper.StartsWith("G") Then
                locLaengenFormatInfo.Aufloesung = LaengenAufloesung.Groß
            End If
        End If

        With locLaengenFormatInfo
            'Und alle Stringausgaben anhand des Providers durchführen
            If .Kultur = LaengenKultur.Deutsch Then
                If .Aufloesung = LaengenAufloesung.SehrKlein Then
                    Return locLaengen.ToMillimeter.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Klein Then
                    Return locLaengen.ToCentimeter.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Mittel Then
                    Return locLaengen.ToMeter.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Groß Then
                    Return locLaengen.ToKilometer.ToString(locNumFormat)
                End If
            Else
                If .Aufloesung = LaengenAufloesung.SehrKlein Then
                    Return locLaengen.ToLine.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Klein Then
                    Return locLaengen.ToInch.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Mittel Then
                    Return locLaengen.ToYard.ToString(locNumFormat)
                ElseIf .Aufloesung = LaengenAufloesung.Groß Then
                    Return locLaengen.ToMile.ToString(locNumFormat)
                End If
            End If
        End With
    End Function

    Public Property Kultur() As LaengenKultur
        Get
            Return myKultur
        End Get
        Set(ByVal Value As LaengenKultur)
            myKultur = Value
        End Set
    End Property

    Public Property Aufloesung() As LaengenAufloesung
        Get
            Return myAufloesung
        End Get
        Set(ByVal Value As LaengenAufloesung)
            myAufloesung = Value
        End Set
    End Property
End Class

Public Class Laengen

    'Speichert die Länge in Meter
    Private myLaenge As Decimal

    Sub New(ByVal Meter As Decimal)
        myLaenge = Meter
    End Sub

    Public Function FromMile(ByVal Mile As Decimal) As Laengen
        Return New Laengen(Mile * 1609D)
    End Function

    Public Shared Function FromYard(ByVal Yard As Decimal) As Laengen
        Return New Laengen(Yard * 0.9144D)
    End Function

    Public Shared Function FromInch(ByVal Inch As Decimal) As Laengen
        Return New Laengen(Inch * 0.0254D)
    End Function

    Public Shared Function FromLine(ByVal Line As Decimal) As Laengen
        Return New Laengen(Line * 0.002117D)

    End Function

    Public Shared Function FromKilometer(ByVal Kilometer As Decimal) As Laengen
        Return New Laengen(Kilometer * 1000D)
    End Function

    Public Shared Function FromCentimeter(ByVal Centimeter As Decimal) As Laengen
        Return New Laengen(Centimeter * 0.01D)
    End Function

    Public Shared Function FromMillimeter(ByVal Millimeter As Decimal) As Laengen
        Return New Laengen(Millimeter * 0.001D)
    End Function

    Public Function ToMeter() As Decimal
        Return myLaenge
    End Function

    Public Function ToKilometer() As Decimal
        Return myLaenge * 0.001D
    End Function

    Public Function ToCentimeter() As Decimal
        Return myLaenge * 100D
    End Function

    Public Function ToMillimeter() As Decimal
        Return myLaenge * 1000D
    End Function

    Public Function ToMile() As Decimal
        Return myLaenge * 0.0006214D
    End Function

    Public Function ToYard() As Decimal
        Return myLaenge * 1.094D
    End Function

    Public Function ToInch() As Decimal
        Return myLaenge * 39.37D
    End Function

    Public Function ToLine() As Decimal
        Return myLaenge * 472.4D
    End Function

    Public Overloads Function ToString(ByVal format As String) As String
        Return ToString(format, Nothing)
    End Function

    Public Overloads Function ToString(ByVal formatProvider As System.IFormatProvider) As String
        Return ToString(Nothing, formatProvider)
    End Function

    Public Overloads Function ToString(ByVal formatChars As String, _
                ByVal formatProvider As System.IFormatProvider) As String

        Trace.WriteLine("ToString (Formattable-Signatur) wurde aufgerufen!")

        If (TypeOf formatProvider Is CultureInfo) Or formatProvider Is Nothing Then
            formatProvider = LaengenFormatInfo.FromFormatProvider(formatProvider)
        ElseIf Not (TypeOf formatProvider Is LaengenFormatInfo) Then
            Dim up As New FormatException("Der Format Provider wird für die Klasse Laengen nicht unterstützt!")
            Throw up
        End If

        'LaengenFormatInfo-Provider enthält die Format-Aufbereitungsroutine
        Return DirectCast(formatProvider, LaengenFormatInfo).Format(formatChars, Me, formatProvider)

    End Function

End Class
