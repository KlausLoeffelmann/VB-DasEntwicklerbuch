Module mdlMain

    Sub Main()
        Dim locAdrOriginal As New Adresse("Hans", "Mustermann", "Musterstra�e 22", "59555 Lippstadt")
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
        locAdrKopie = DirectCast(ADObjectCloner.DeepCopy(locAdrOriginal), Adresse)

        'Kopie ausgeben
        Console.WriteLine("Kopie:")
        Console.WriteLine("=========")
        Console.WriteLine(locAdrKopie)

        '�nderungen im Original:
        DirectCast(locAdrOriginal.BefreundetMit(1), Adresse).Nachname = "L�ffelmann-Beck"
        DirectCast(locAdrOriginal.BefreundetMit(2), Adresse).Nachname = "L�ffelmann-Beck"

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

    Sub New(ByVal Vorname As String, ByVal Nachname As String, ByVal Stra�e As String,
            ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Nachname = Nachname
        Me.Vorname = Vorname
        Me.Stra�e = Stra�e
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
    End Sub

    Public Property Nachname() As String
    Public Property Vorname() As String
    Public Property Stra�e() As String
    Public Property PLZOrt() As String
    Public Property BefreundetMit() As List(Of Adresse)

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

    Public Overrides Function ToString() As String
        Dim locTemp As String
        locTemp = Nachname + ", " + Vorname + ", " + Stra�e + ", " + PLZOrt + vbNewLine
        locTemp += "--- Befreundet mit: ---" + vbNewLine
        For Each locAdr As Adresse In BefreundetMit
            locTemp += "   * " + locAdr.ToShortString() + vbNewLine
        Next
        locTemp += vbNewLine
        Return locTemp
    End Function

    Public Function ToShortString() As String
        Return Nachname + ", " + Vorname
    End Function
End Class

