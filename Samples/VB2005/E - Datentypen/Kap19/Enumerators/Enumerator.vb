Module Enumerators

    Sub Main()

        'Das würde nicht funktionieren:
        'for d as Date=#24/12/2004# to #31/12/2004
        '    Console.WriteLine("Datum in Aufzählung: {0}", d)
        'Next d


        Dim locDatumsaufzählung As New Datumsaufzählung(#12/24/2004#, _
                                                        #12/31/2004#, _
                                                        New TimeSpan(1, 0, 0, 0))
        For Each d As Date In locDatumsaufzählung
            Console.WriteLine("Datum in Aufzählung: {0}", d)
        Next

    End Sub

End Module

Public Class Datumsaufzählung
    Implements IEnumerable

    Dim locDatumsaufzähler As Datumsaufzähler

    Sub New(ByVal StartDatum As Date, ByVal EndDatum As Date, ByVal Schrittweite As TimeSpan)
        locDatumsaufzähler = New Datumsaufzähler(StartDatum, EndDatum, Schrittweite)
    End Sub

    Public Function GetEnumerator() As System.Collections.IEnumerator _
                    Implements System.Collections.IEnumerable.GetEnumerator
        Return locDatumsaufzähler
    End Function
End Class

Public Class Datumsaufzähler
    Implements IEnumerator

    Private myStartDatum As Date
    Private myEndDatum As Date
    Private mySchrittweite As TimeSpan
    Private myAktuellesDatum As Date

    Sub New(ByVal StartDatum As Date, ByVal EndDatum As Date, ByVal Schrittweite As TimeSpan)
        myStartDatum = StartDatum
        myAktuellesDatum = StartDatum
        myEndDatum = EndDatum
        mySchrittweite = Schrittweite
    End Sub

    Public Property StartDatum() As Date
        Get
            Return myStartDatum
        End Get
        Set(ByVal Value As Date)
            myStartDatum = Value
        End Set
    End Property

    Public Property EndDatum() As Date
        Get
            Return myEndDatum
        End Get
        Set(ByVal Value As Date)
            myEndDatum = Value
        End Set
    End Property

    Public Property Schrittweite() As TimeSpan
        Get
            Return mySchrittweite
        End Get
        Set(ByVal Value As TimeSpan)
            mySchrittweite = Value
        End Set
    End Property

    Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
            Return myAktuellesDatum
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        myAktuellesDatum = myAktuellesDatum.Add(Schrittweite)
        If myAktuellesDatum > myEndDatum Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        myAktuellesDatum = myStartDatum
    End Sub
End Class
