Module mdlMain

    Sub Main()
        Dim locAdrOriginal As New Adresse("Marcus", "Pusch", "Musterstra�e 22", "59555 Lippstadt")
        Dim locAdrKopie As Adresse
        locAdrOriginal.BefreundetMit = New List(Of Adresse) From {
                            New Adresse("Ramona", "Leenings", "Autorstr. 33", "49595 Buchhausen"),
                            New Adresse("Cate", "Hora", "Autorstr. 34", "49595 Buchhausen"),
                            New Adresse("Gabriele", "L�ffelmann", "Autorstr. 35", "49595 Buchhausen")}

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
        CType(locAdrOriginal.BefreundetMit(1), Adresse).Name = "L�ffelmann-Beck"
        CType(locAdrOriginal.BefreundetMit(2), Adresse).Name = "L�ffelmann-Beck"

        'Kopie nach �nderungen im Original
        Console.WriteLine("Kopie nach �nderung im Original:")
        Console.WriteLine("================================")
        Console.WriteLine(locAdrKopie)
        Console.ReadLine()

    End Sub

End Module

<Serializable()> _
Public Class Adresse

    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Stra�e As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Name = Name
        Me.Vorname = Vorname
        Me.Stra�e = Stra�e
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
    End Sub

    Public Property Name() As String
    Public Property Vorname() As String
    Public Property Stra�e() As String
    Public Property PLZOrt() As String

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

    Public Property BefreundetMit() As List(Of Adresse)

    Public Overrides Function ToString() As String
        Dim locTemp As String
        locTemp = Name + ", " + Vorname + ", " + Stra�e + ", " + PLZOrt + vbNewLine
        locTemp += "--- Befreundet mit: ---" + vbNewLine
        For Each locAdr As Adresse In BefreundetMit
            locTemp += "   * " + locAdr.ToShortString() + vbNewLine
        Next
        locTemp += vbNewLine
        Return locTemp
    End Function

    Public Function ToShortString() As String
        Return Name + ", " + Vorname
    End Function
End Class
