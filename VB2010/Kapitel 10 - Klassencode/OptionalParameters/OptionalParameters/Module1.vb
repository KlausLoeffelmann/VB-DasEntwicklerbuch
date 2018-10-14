Module OptionalParametersDemo

    Private Const MAXDATEVALUE As Date = #12/31/9999 11:59:59 PM#
    Private Const DEFAULTDATEFORMAT = "dd.MM.yyyy"

    Sub Main()

        PrintTimeDeltaOpt(


    End Sub

    Public Sub PrintTimeDeltaOpt(ByVal Starttime As Date, Optional ByVal Endtime As Date = MAXDATEVALUE,
                                 Optional ByVal TimeSpanCaption As String = "Zeitdifferenz: ",
                                 Optional ByVal DateFormatString As String = DEFAULTDATEFORMAT,
                                 Optional ByVal StartTimeCaption As String = "Startzeit: ",
                                 Optional ByVal EndTimeCaption As String = "Endzeit: ",
                                 Optional ByVal PrintDelimitter As Boolean = True)

        'Typisch für Optionale Parameter: 
        'Hier müssen wir "erkennen", ob ein optionaler Parameter
        'angegeben wurde, und diesen durch den Wert ersetzen,
        'den wir eigentlich "meinen".
        If Endtime = MAXDATEVALUE Then
            Endtime = DateTime.Now
        End If

        Dim zeitDifferenz = Endtime - Starttime

        Console.WriteLine(StartTimeCaption & "{0:" & DateFormatString & "}" & vbNewLine &
                          EndTimeCaption & "{1:" & DateFormatString & "}" & vbNewLine &
                          TimeSpanCaption & "{2:dd\.hh\:mm}", Starttime, Endtime, zeitDifferenz)

        If PrintDelimitter Then
            Console.WriteLine(New String("-"c, 75))
            Console.WriteLine()
        End If
    End Sub

End Module

