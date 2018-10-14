<Serializable()> _
Public Class Adresse

    'Membervariablen, die die Daten halten:
    Protected myMatchcode As String
    Protected myName As String
    Protected myVorname As String
    Protected myStra�e As String
    Protected myPLZ As String
    Protected myOrt As String
    Protected myGeburtsdatum As Date

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    ''' <remarks>Ein parameterloser Konstruktor wird ben�tigt, 
    ''' um XML-Serialisierung zu erm�glichen.</remarks>
    Sub New()
        MyBase.New()
    End Sub

    'Konstruktor - legt eine neue Instanz an
    Sub New(ByVal Matchcode As String, ByVal Name As String, ByVal Vorname As String, _
            ByVal Stra�e As String, ByVal Plz As String, ByVal Ort As String, _
            ByVal Geburtsdatum As Date)
        myMatchcode = Matchcode
        myName = Name
        myVorname = Vorname
        myStra�e = Stra�e
        myPLZ = Plz
        myOrt = Ort
        myGeburtsdatum = Geburtsdatum
    End Sub

    Public Overridable Property Matchcode() As String
        Get
            Return myMatchcode
        End Get
        Set(ByVal Value As String)
            myMatchcode = Value
        End Set
    End Property

    Public Overridable Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public Overridable Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Overridable Property Stra�e() As String
        Get
            Return myStra�e
        End Get
        Set(ByVal value As String)
            myStra�e = value
        End Set
    End Property

    Public Overridable Property PLZ() As String
        Get
            Return myPLZ
        End Get
        Set(ByVal Value As String)
            myPLZ = Value
        End Set
    End Property

    Public Overridable Property Ort() As String
        Get
            Return myOrt
        End Get
        Set(ByVal Value As String)
            myOrt = Value
        End Set
    End Property

    Public Overridable Property Geburtsdatum() As Date
        Get
            Return myGeburtsdatum
        End Get
        Set(ByVal Value As Date)
            myGeburtsdatum = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Matchcode & ":" & Name & ", " & Vorname
    End Function
End Class
