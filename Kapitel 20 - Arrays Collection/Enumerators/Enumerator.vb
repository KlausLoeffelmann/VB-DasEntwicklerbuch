Module Enumerators

    Sub Main()

        'Das w�rde nicht funktionieren:
        'for d as Date=#24/12/2004# to #31/12/2004
        '    Console.WriteLine("Datum in Aufz�hlung: {0}", d)
        'Next d


        Dim locDatumsaufz�hlung As New Datumsaufz�hlung(#7/24/2010#,
                                                        #8/4/2010#,
                                                        New TimeSpan(1, 0, 0, 0))
        For Each d As Date In locDatumsaufz�hlung
            Console.WriteLine("Datum in Aufz�hlung: {0}", d)
        Next

    End Sub

End Module

Public Class Datumsaufz�hlung
    Implements IEnumerable

    Dim locDatumsaufz�hler As Datumsaufz�hler

    Sub New(ByVal StartDatum As Date, ByVal EndDatum As Date, ByVal Schrittweite As TimeSpan)
        locDatumsaufz�hler = New Datumsaufz�hler(StartDatum, EndDatum, Schrittweite)
    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator _
                    Implements System.Collections.IEnumerable.GetEnumerator
        Return locDatumsaufz�hler
    End Function
End Class

Public Class Datumsaufz�hler
    Implements IEnumerator

    Private myAktuellesDatum As Date

    Sub New(ByVal StartDatum As Date, ByVal EndDatum As Date, ByVal Schrittweite As TimeSpan)
        Me.StartDatum = StartDatum
        Me.EndDatum = EndDatum
        Me.Schrittweite = Schrittweite
        myAktuellesDatum = StartDatum
    End Sub

    Public Property StartDatum() As Date
    Public Property EndDatum() As Date
    Public Property Schrittweite() As TimeSpan

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return myAktuellesDatum
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        myAktuellesDatum = myAktuellesDatum.Add(Schrittweite)
        If myAktuellesDatum > EndDatum Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        myAktuellesDatum = StartDatum
    End Sub
End Class
