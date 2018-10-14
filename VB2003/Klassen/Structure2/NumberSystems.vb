Public Structure NumberSystems

    Private myUnderlyingValue As Long
    Private myNumberSystem As Integer
    Private Shared myDigits As Char()

    Shared Sub New()
        myDigits = New Char() {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c, "A"c, _
                               "B"c, "C"c, "D"c, "E"c, "F"c, "G"c, "H"c, "I"c, "J"c, "K"c, "L"c, _
                               "M"c, "N"c, "O"c, "P"c, "Q"c, "R"c, "S"c, "T"c, "U"c, "V"c, "W"c, _
                               "X"c, "Y"c, "Z"c}
    End Sub

    Sub New(ByVal Value As Integer)
        Me.New(CLng(Value), 16)
    End Sub

    Sub New(ByVal Value As Long)
        Me.New(Value, 16)
    End Sub

    Sub New(ByVal Value As Long, ByVal NumberSystem As Integer)

        myUnderlyingValue = Value
        If NumberSystem < 2 OrElse NumberSystem > 33 Then
            Dim Up As Exception = New OverflowException _
                ("Kennziffer des Zahlensystems au�erhalb des g�ltigen Bereichs!")
            'Kleiner Scherz f�r die Englisch sprechenden:
            Throw Up
        End If
        myNumberSystem = NumberSystem

    End Sub

    Public Property Value() As Long

        Get
            Return myUnderlyingValue
        End Get
        Set(ByVal Value As Long)
            myUnderlyingValue = Value
        End Set

    End Property

    Public Property NumberSystem() As Integer
        Get
            Return myNumberSystem
        End Get
        Set(ByVal Value As Integer)
            If Value < 2 OrElse Value > 33 Then
                Dim Up As Exception = New OverflowException _
                    ("Kennziffer des Zahlensystems au�erhalb des g�ltigen Bereichs!")
                Throw Up
            End If
            myNumberSystem = Value
        End Set
    End Property

    Public Property LongEx() As LongEx
        Get
            Return New LongEx(myUnderlyingValue)
        End Get
        Set(ByVal Value As LongEx)
            myUnderlyingValue = Value.Long
        End Set
    End Property

    Public Overrides Function ToString() As String

        Dim locResult As String
        Dim locLongEx As LongEx

        'tempor�re LongEx-Variable, f�r die Umwandlungen
        locLongEx.Long = myUnderlyingValue

        'tempor�re LongEx-Variable f�r Emulation 
        'der vorzeichenlosen 64-Bit-Integer-Division
        Dim locDec As Decimal

        Do
            'Vorzeichenbehaftetes Integer in Long konvertieren, damit die
            'richtige Ziffer berechnet werden kann
            Dim digit As Integer = CInt(Convert.ToInt64(locLongEx.UInt) Mod NumberSystem)
            locResult = CStr(myDigits(digit)) & locResult

            'F�r die Division vorbereiten; damit das Vorzeichen ber�cksichtigt wird
            'bleibt nur der daf�r ausreichend gro�e Decimal-Typ
            locDec = Convert.ToDecimal(locLongEx.ULong)

            'Integerdivision simulieren; erst dividieren, dann Nachkommastelle mit Truncate abschneiden
            locDec = Decimal.Truncate(Decimal.Divide(locDec, Convert.ToDecimal(NumberSystem)))

            'Ergebnis wieder zur�ckschreiben, damit am Schleifenanfang mit UInt
            '(vorzeichenloser Integer) auf die unteren 32 Bits zugegriffen werden kann
            locLongEx.ULong = Convert.ToUInt64(locDec)
        Loop Until locLongEx.Long = 0

        Return locResult

    End Function

    Public Shared Function Parse(ByVal Value As String, ByVal NumberSystem As Integer) As NumberSystems

        'Hier wird der Value zusammengebaut
        Dim locValue As Long
        Dim locLngTemp As Long
        Dim locValue2 As UInt64

        For count As Integer = 0 To Value.Length - 1
            Try
                'Aktuellen Zeichen im String, das verarbeitet wird
                Dim locTmpChar As String = Value.Substring(count, 1)

                'Bin�resuche anwenden, um das Zeichen im Array zu finden und damit die Ziffernummer
                Dim locDigitValue As Integer = CInt(Array.BinarySearch(myDigits, CChar(locTmpChar)))

                'Pr�fen, ob sich das Zeichen im G�ltigkeitsbereich befindet
                If locDigitValue >= NumberSystem OrElse locDigitValue < 0 Then
                    Dim Up As Exception = New FormatException _
                        ("Ziffer '" & locTmpChar & "' ist nicht Bestandteil des Zahlensystems!")
                    Throw Up
                End If

                'Aus der gefundenen Ziffernummer die Potenzbilden, und zum Gesamtwert addieren
                locValue += CLng(Math.Pow(NumberSystem, Value.Length - count - 1) * locDigitValue)

            Catch ex As Exception
                'F�r den Fall, dass zwischendurch 'was schiefgeht
                Dim Up As Exception = New InvalidCastException _
                    ("Ziffer des Zahlensystems au�erhalb des g�ltigen Bereichs!")
                Throw Up
            End Try

            'n�chstes Zeichen verarbeiten
        Next

        Return New NumberSystems(locValue, NumberSystem)

    End Function


End Structure