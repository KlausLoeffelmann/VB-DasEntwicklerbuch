Module Module1

    Sub Main()

        Dim locBoolean As System.Boolean
        locBoolean = False ' Ausdruck ist 'falsch'
        locBoolean = True ' Ausdruck ist 'wahr'

        'Numerische Konvertierungen
        Dim locInt As Integer = CInt(locBoolean)    ' locInt ist -1
        locInt = Convert.ToInt32(locBoolean)        ' locInt ist jetzt +1!!!
        Dim locLong As Long = CLng(locBoolean)      ' locLong ist -1
        locLong = Convert.ToInt64(locBoolean)       ' locLonf ist +1

        locBoolean = CBool(-1)                      ' locBoolean ist True
        locBoolean = CBool(0)                       ' locBoolean ist False
        locBoolean = CBool(1)                       ' locBoolean ist True
        locBoolean = Convert.ToBoolean(-1)          ' locBoolean ist True
        locBoolean = Convert.ToBoolean(+1)          ' locBoolean ist True
        locBoolean = CBool(100)                     ' locBoolean ist True
        locBoolean = Convert.ToBoolean(100)         ' locBoolean ist True

        'String-Konvertierungshilfen
        Console.WriteLine(System.Boolean.FalseString)
        Console.WriteLine(System.Boolean.TrueString)

        'Vergleichsoperatoren
        Dim locString1 As String = "Uwe"
        Dim locString2 As String = "Klaus"

        locBoolean = (locString1 = locString2)      ' ergibt false
        locBoolean = (locString1 > locString2)      ' ergibt true
        locBoolean = (locString1 < locString2)      ' ergibt false
        locBoolean = (locString1 >= locString2)     ' ergibt true
        locBoolean = (locString1 <= locString2)     ' ergibt false
        locBoolean = (locString1 <> locString2)     ' ergibt true
        locBoolean = (locString1 Is locString2)     ' ergibt false

        locString2 = "Uwe"
        String.Intern(locString2)                   ' ergibt jetzt true, da beide
        locBoolean = (locString1 Is locString2)     ' Stringobjekte auf einen Bereich zeigen

        locString1 = "Klau's, und lass Dich nicht erwischen"
        locString2 = "Klaus*"
        locBoolean = (locString1 Like locString2)   ' ergibt False

        If locBoolean Then
            'Schachteln geht natürlich auch:
            If locString2 = "Klaus" Then
                Console.WriteLine("Namen gefunden!")
            Else
                Console.WriteLine("Keinen Namen gefunden!")
            End If
        ElseIf Now = #12:00:00 PM# Then
            Console.WriteLine("Mittag")
        ElseIf Now = #12:00:00 AM# Then
            Console.WriteLine("So spät noch auf?")
        Else
            Console.WriteLine("Es ist irgendwann sonst oder locString1 war nicht wie locString1...")
        End If


        locString1 = "Miriam"

        Select Case locString1

            Case "Miriam"
                Console.WriteLine("Treffer")

            Case Is > "M"
                Console.WriteLine("Name kommt nach 'M' im Alphabet")
                '(Da 'Miriam' > als 'M' ist, wird der Text ausgegeben!)

            Case Is < "M"
                Console.WriteLine("Name kommt vor 'M' im Alphabet")

            Case Else
                Console.WriteLine("Name beginnt mir 'M'")

                'case like "Miri"
                'Das funktioniert nicht!!!

        End Select

        Dim locCount As Integer

        'Raufzählen
        Do While locCount < 10
            locCount += 1
        Loop

        'locCount ist jetzt 10; wieder runterzählen
        Do
            locCount -= 1
        Loop Until locCount = 0

        'locCount ist jetzt 0; Wieder raufzählen
        While locCount < 10
            locCount += 1
        End While

        'locCount ist wieder 10; und wieder bis 0 runterzählen
        Do Until locCount = 0
            locCount -= 1
        Loop

        Console.ReadLine()

    End Sub

End Module
