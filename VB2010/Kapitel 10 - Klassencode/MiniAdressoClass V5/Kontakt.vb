Public Class Kontakt

    Private myVorname As String
    Private myNachname As String
    Private myPLZ As String
    Private myOrt As String
    Private myErstellungsdatum As Date

    'Parameterloser Konstruktor
    Sub New()
        myErstellungsdatum = Date.Now
    End Sub

    'Konstruktor übernimmt Initialisierungsparameter
    Sub New(ByVal Vorname As String, ByVal Nachname As String, _
            ByVal PLZ As String, ByVal Ort As String)

        'Und ruft - und das geht NUR als erstes oder gar nicht -
        'die parameterlose Konstruktorprozedur auf.
        Me.New()

        'Member-Variablen mit den übergebenen Werten initialisieren.
        myVorname = Vorname
        myNachname = Nachname
        myPLZ = PLZ
        myOrt = Ort
    End Sub

    Public ReadOnly Property ErstellungsDatum() As Date
        Get
            Return myErstellungsdatum
        End Get
    End Property

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal value As String)
            myVorname = value
        End Set
    End Property

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal value As String)
            myNachname = value
        End Set
    End Property

    Public Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal value As String)
            myPLZ = value
        End Set
    End Property

    Public Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal value As String)
            myOrt = EllipseString(value, 30)
        End Set
    End Property

    Public Function KontaktText() As String

        Return Nachname & ", " & Vorname & ", " & _
                PLZ & ", " & Ort

    End Function

    Private Function EllipseString(ByVal text As String, ByVal MaxLength As Integer) As String

        Dim tmpText As String

        If text.Length > MaxLength Then
            tmpText = text.Substring(0, MaxLength - 3) + "..."
        Else
            tmpText = text
        End If
        Return tmpText
    End Function

End Class