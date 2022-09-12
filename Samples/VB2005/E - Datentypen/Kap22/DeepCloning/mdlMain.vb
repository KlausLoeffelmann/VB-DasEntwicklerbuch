Module mdlMain

    Sub Main()
        Dim locAdrOriginal As New Adresse("Hans", "Mustermann", "Musterstra�e 22", "59555 Lippstadt")
        Dim locAdrKopie As Adresse
        With locAdrOriginal.BefreundetMit
            .Add(New Adresse("Uwe", "Thiemann", "Autorstr. 33", "49595 Buchhausen"))
            .Add(New Adresse("Gaby", "Halek", "Autorstr. 34", "49595 Buchhausen"))
            .Add(New Adresse("Gabriele", "L�ffelmann", "Autorstr. 35", "49595 Buchhausen"))
        End With

        'Originaladresse ausgeben
        Console.WriteLine("Original:")
        Console.WriteLine("=========")
        Console.WriteLine(locAdrOriginal)

        'Kopie anlegen
        With locAdrOriginal
            locAdrKopie = New Adresse(.Vorname, .Name, .Stra�e, .PLZOrt)
            locAdrKopie.Name += " (Kopie)"
            locAdrKopie.BefreundetMit = .BefreundetMit
        End With

        'Kopie ausgeben
        Console.WriteLine("Kopie:")
        Console.WriteLine("=========")
        Console.WriteLine(locAdrKopie)

        '�nderungen im Original:
        CType(locAdrOriginal.BefreundetMit(1), Adresse).Name = "L�ffelmann-Halek"
        CType(locAdrOriginal.BefreundetMit(2), Adresse).Name = "L�ffelmann-Halek"

        'Kopie nach �nderungen im Original
        Console.WriteLine("Kopie nach �nderung im Original:")
        Console.WriteLine("================================")
        Console.WriteLine(locAdrKopie)
        Console.ReadLine()

    End Sub

End Module

<Serializable()> _
Public Class Adresse

    Private myName As String
    Private myVorname As String
    Private myStra�e As String
    Private myPLZOrt As String
    Private myErfasstAm As DateTime
    Private myErfasstVon As String
    Private myBefreundetMit As ArrayList

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Stra�e As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        myName = Name
        myVorname = Vorname
        myStra�e = Stra�e
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

    Public Property Stra�e() As String
        Get
            Return myStra�e
        End Get
        Set(ByVal Value As String)
            myStra�e = Value
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

    Public Overrides Function ToString() As String
        Dim locTemp As String
        locTemp = Name + ", " + Vorname + ", " + Stra�e + ", " + PLZOrt + vbNewLine
        locTemp += "--- Befreundet mit: ---" + vbNewLine
        For Each locAdr As Adresse In BefreundetMit
            locTemp += "   * " + locAdr.ToStringShort() + vbNewLine
        Next
        locTemp += vbNewLine
        Return locTemp
    End Function

    Public Function ToStringShort() As String
        Return Name + ", " + Vorname
    End Function
End Class

