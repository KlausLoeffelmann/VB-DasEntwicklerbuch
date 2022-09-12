Module mdlMain
    Sub Main()
        Dim locErsteAdr As New Adresse("Gaby", "Halek", "Musterstraﬂe 24", "32132 Buchhausen")
        Dim locZweiteAdr As New Adresse("Uwe", "Thiemann", "Autorenstr. 22", "32132 Buchhausen")
        locErsteAdr.BefreundetMit.Add(New Adresse("Petra", "Raubein", "Autorenstr. 12", "32132 Buchhausen"))
        locErsteAdr.BefreundetMit.Add(locZweiteAdr)
        locZweiteAdr.BefreundetMit.Add(New Adresse("Manuela", "Koch", "Autorenstr. 22", "32132 Buchhausen"))

        'Wenn Sie diese Zeile einbauen, erstellen Sie einen Zirkelverweis
        locZweiteAdr.BefreundetMit.Add(locErsteAdr)

        'Originaladresse ausgeben
        Console.WriteLine("Erste Adresse:")
        Console.WriteLine("==============")
        Console.WriteLine(locErsteAdr)

        Console.WriteLine("Zweite Adresse:")
        Console.WriteLine("==============")
        Console.WriteLine(locZweiteAdr)

        'Kopie anlegen
        Dim locAdrKopie As Adresse = CType(ADObjectCloner.DeepCopy(locErsteAdr), Adresse)
        Console.ReadLine()
    End Sub
End Module

<Serializable()> _
Public Class Adresse

    Private myName As String
    Private myVorname As String
    Private myStraﬂe As String
    Private myPLZOrt As String
    Private myErfasstAm As DateTime
    Private myErfasstVon As String
    Private myBefreundetMit As ArrayList

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        myName = Name
        myVorname = Vorname
        myStraﬂe = Straﬂe
        myPLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
        myBefreundetMit = New ArrayList
    End Sub

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public ReadOnly Property ErfasstAm() As DateTime
        Get
            Return myErfasstAm
        End Get
    End Property

    Public ReadOnly Property ErfasstVon() As String
        Get
            Return myErfasstVon
        End Get
    End Property

    Public Property BefreundetMit() As ArrayList
        Get
            Return myBefreundetMit
        End Get
        Set(ByVal Value As ArrayList)
            myBefreundetMit = Value
        End Set
    End Property

#Region "Die anderen Eigenschaften"

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property Straﬂe() As String
        Get
            Return myStraﬂe
        End Get
        Set(ByVal Value As String)
            myStraﬂe = Value
        End Set
    End Property

    Public Property PLZOrt() As String
        Get
            Return myPLZOrt
        End Get
        Set(ByVal Value As String)
            myPLZOrt = Value
        End Set
    End Property
#End Region

    Public Overloads Overrides Function ToString() As String
        Return ToString(0)
    End Function

    Public Overloads Function ToString(ByVal Indent As Integer) As String
        Dim locTemp As String
        locTemp = New String(" "c, Indent) + Name + ", " + Vorname + ", " + Straﬂe + ", " + PLZOrt + vbNewLine
        If BefreundetMit.Count > 0 Then
            locTemp += New String(" "c, Indent) + "--- Befreundet mit: ---" + vbNewLine
            For Each locAdr As Adresse In BefreundetMit
                locTemp += locAdr.ToString(Indent + 4) + vbNewLine
            Next
        End If
        Return locTemp
    End Function
End Class

