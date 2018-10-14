Module mdlMain

    Sub Main()
        Dim locDoubleList As New DynamicListSortable(Of Double)
        locDoubleList.Add(124)
        locDoubleList.Add(1243)
        locDoubleList.Add(24)
        locDoubleList.Add(14)
        locDoubleList.Add(1)
        locDoubleList.Add(-32)
        locDoubleList.Add(231)
        locDoubleList.Add(143)

        locDoubleList.Sort()
        For Each locItem As Double In locDoubleList
            Console.WriteLine(locItem)
        Next
        Console.WriteLine()

        Dim locStringList As New DynamicListSortable(Of String)
        locStringList.Add("Klaus")
        locStringList.Add("Arnold")
        locStringList.Add("Sarah")
        locStringList.Add("Christiane")
        locStringList.Add("Jürgen")
        locStringList.Add("Uta")
        locStringList.Add("Helge")
        locStringList.Add("Uwe")

        locStringList.Sort()
        For Each locItem As String In locStringList
            Console.WriteLine(locItem)
        Next

        Console.WriteLine()
        Console.WriteLine("Taste drücken zum Beenden!")
        Console.ReadKey()
    End Sub

End Module

Public Class GenerischeKlasseMitInstanzierbarenTyp(Of flexiblerDatentyp As New)

    Public Sub TestMethode()
        Dim locTest As New flexiblerDatentyp

        'Und hier ist locTest jetzt als Datentyp instanziert!
        Console.WriteLine(locTest.ToString)
    End Sub
End Class

Public Class GenerischeKlasseNurMitWertetypen(Of flexiblerDatentyp As Structure)

    Public Sub TestMethode()
        Dim locWerteTyp As flexiblerDatentyp

        'Und hier ist locTest jetzt als Datentyp instanziert,
        'da Wertetypen keine Instanzierung mit New erfordern!
        Console.WriteLine(locWerteTyp.ToString)
    End Sub
End Class

Public Class GenerischeBeschränkungskombi(Of flexiblerDatentyp As {Structure, IComparable, IDisposable})

    Public Sub TestMethode()
        Dim locWerteTyp As flexiblerDatentyp
        Dim locWerteTyp2 As flexiblerDatentyp

        'Direkt verwendbar, da Wertetyp durch Struktur
        'Vergleichbar, dank IComparable
        locWerteTyp.CompareTo(locWerteTyp2)

        'Disposable, dank IDisposable
        locWerteTyp.Dispose()
        locWerteTyp2.Dispose()
    End Sub
End Class

Public Class GenerischesWörterbuch(Of Schlüsseltyp As {Structure, IComparable}, _
                        Werttyp As {New, IComparable, IDisposable})

    Public Sub TestMethode()
        Dim locWerteTyp As Schlüsseltyp
        Dim locWerteTyp2 As Werttyp

        'Direkt verwendbar, da Wertetyp durch Struktur
        'Vergleichbar, dank IComparable
        locWerteTyp.CompareTo(locWerteTyp2)

        'Disposable, dank IDisposable
        locWerteTyp2.Dispose()
    End Sub
End Class

