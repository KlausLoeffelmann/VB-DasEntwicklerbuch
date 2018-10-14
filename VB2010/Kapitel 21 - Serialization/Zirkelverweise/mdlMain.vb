Module mdlMain

    Sub Main()
        Dim locErsteAdr As New Adresse("Cate", "Hora", "Musterstraﬂe 24", "32132 Buchhausen")
        Dim locZweiteAdr As New Adresse("Ramones", "Leenings", "Autorenstr. 22", "32132 Buchhausen")
        locErsteAdr.BefreundetMit = New List(Of Adresse) From
            {New Adresse("Joan", "Doe", "Autorenstr. 12", "32132 Buchhausen"),
             locZweiteAdr}

        locZweiteAdr.BefreundetMit = New List(Of Adresse) From
            {New Adresse("Oli", "Hora", "Autorenstr. 22", "32132 Buchhausen")}

        'Wenn Sie diese Zeile einbauen, erstellen Sie einen Zirkelverweis
        'locZweiteAdr.BefreundetMit.Add(locErsteAdr)

        'Originaladresse ausgeben
        Console.WriteLine("Erste Adresse:")
        Console.WriteLine("==============")
        Console.WriteLine(locErsteAdr)

        Console.WriteLine("Zweite Adresse:")
        Console.WriteLine("==============")
        Console.WriteLine(locZweiteAdr)

        'Kopie anlegen
        Dim locAdrKopie As Adresse = DirectCast(ObjectCloner.
            DeepCopy(locErsteAdr), Adresse)
        Console.ReadLine()
    End Sub
End Module

<Serializable()> _
Public Class Adresse

    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Name = Name
        Me.Vorname = Vorname
        Me.Straﬂe = Straﬂe
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
    End Sub

    Public Property Name() As String
    Public Property Vorname() As String
    Public Property Straﬂe() As String
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

    Public Overloads Overrides Function ToString() As String
        Return ToString(0)
    End Function

    Public Overloads Function ToString(ByVal Indent As Integer) As String
        Dim locTemp As String
        locTemp = New String(" "c, Indent) + Name + ", " + Vorname + ", " + Straﬂe + ", " + PLZOrt + vbNewLine
        If BefreundetMit IsNot Nothing AndAlso BefreundetMit.Count > 0 Then
            locTemp += New String(" "c, Indent) + "--- Befreundet mit: ---" + vbNewLine
            For Each locAdr As Adresse In BefreundetMit
                locTemp += locAdr.ToString(Indent + 4) + vbNewLine
            Next
        End If
        Return locTemp
    End Function
End Class
