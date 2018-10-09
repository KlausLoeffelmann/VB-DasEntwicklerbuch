Public Class Kontakt

    Private myVorname As String
    Private myNachname As String
    Private myPLZ As String
    Private myOrt As String

    Private myErstellungsdatum As Date

    'Sub New()
    '    myErstellungsdatum = Date.Now
    'End Sub

    ''Konstruktor übernimmt Initalisierungsparameter
    'Sub New(ByVal Vorname As String, ByVal Nachname As String, ByVal PLZ As String, ByVal Ort As String)

    '    'Member Variablen mit den übergebenen Werten initalisieren.
    '    myVorname = Vorname
    '    myNachname = Nachname
    '    myPLZ = PLZ
    '    myOrt = Ort

    '    'Und ruft- und das geht NUR als erstes oder gar nicht -
    '    Me.New()
    'End Sub


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

        Return Me.Nachname & ", " & Me.Vorname & ", " & _
                Me.PLZ & ", " & Me.Ort

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