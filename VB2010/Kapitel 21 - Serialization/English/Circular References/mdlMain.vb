Module mdlMain

    Sub Main()
        Dim firstContact As New Contact("Cate", "Hora", "Musterstraﬂe 24", "32132 Buchhausen")
        Dim secondContact As New Contact("Ramones", "Leenings", "Autorenstr. 22", "32132 Buchhausen")
        firstContact.FriendWith = New List(Of Contact) From
            {New Contact("Joan", "Doe", "Autorenstr. 12", "32132 Buchhausen"),
             secondContact}

        secondContact.FriendWith = New List(Of Contact) From
            {New Contact("Oli", "Hora", "Autorenstr. 22", "32132 Buchhausen")}

        'If you add this code line, you're creating a circular reference
        secondContact.FriendWith.Add(firstContact)

        'Originaladresse ausgeben
        Console.WriteLine("First Contact:")
        Console.WriteLine("==============")
        Console.WriteLine(firstContact)

        Console.WriteLine("Second Contact:")
        Console.WriteLine("==============")
        Console.WriteLine(secondContact)

        'Create a copy
        Dim locAdrCopy As Contact = CType(ObjectCloner.DeepCopy(firstContact), Contact)
        Console.ReadLine()
    End Sub
End Module

<Serializable()> _
Public Class Contact

    Private myDateCollected As DateTime
    Private myCollectedBy As String

    Sub New(ByVal Firstname As String, ByVal Lastname As String, ByVal AddressLine As String, ByVal ZipCity As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Lastname = Lastname
        Me.Firstname = Firstname
        Me.AddressLine = AddressLine
        Me.ZipCity = ZipCity
        myDateCollected = DateTime.Now
        myCollectedBy = Environment.UserName
    End Sub

    Public Property Lastname() As String
    Public Property Firstname() As String
    Public Property AddressLine() As String
    Public Property ZipCity() As String
    Public Property FriendWith() As List(Of Contact)

    Public ReadOnly Property DateCollected() As DateTime
        Get
            Return myDateCollected
        End Get
    End Property

    Public ReadOnly Property CollectedBy() As String
        Get
            Return myCollectedBy
        End Get
    End Property

    Public Overloads Overrides Function ToString() As String
        Return ToString(0)
    End Function

    Public Overloads Function ToString(ByVal Indent As Integer) As String
        Dim locTemp As String
        locTemp = New String(" "c, Indent) + Lastname + ", " + Firstname + ", " + AddressLine + ", " + ZipCity + vbNewLine
        If FriendWith IsNot Nothing AndAlso FriendWith.Count > 0 Then
            locTemp += New String(" "c, Indent) + "--- Friends with: ---" + vbNewLine
            For Each locAdr As Contact In FriendWith
                locTemp += locAdr.ToString(Indent + 4) + vbNewLine
            Next
        End If
        Return locTemp
    End Function
End Class
