Imports System.Reflection
Imports System.IO

Module mdlMain

    Sub Main()

        Dim locAdresse As New Adresse("Beck", "Adriana", "Buchstraﬂe 223", "32154 Autorhausen") With
            {.BefreundetMit = New List(Of Adresse) From
                {New Adresse("Klaus", "Lˆffelmann", "One Microsoftway", "99999 Redmond")}}

        PrintObjectInfo(locAdresse)
        Console.ReadLine()

    End Sub

    Sub PrintObjectInfo(ByVal [Object] As Object)
        'Den Objekttypen ermitteln, um auf die Objektinhalte zuzugreifen
        Dim locTypeInstanz As Type = [Object].GetType

        'Die Nicht Benutzerdefinierten Attribute ausgeben:
        Console.WriteLine("Attribute der Klasse:" + locTypeInstanz.FullName)
        Console.WriteLine("Standardattribute:")
        Console.WriteLine("    *" + locTypeInstanz.Attributes.ToString())
        Console.WriteLine()

        'Benutzerdefinierteattribute der Klasse ermitteln
        '(Es kˆnnen auf diese Weise *nur* benutzerdefinierte Attribute ermittelt werden)
        Console.WriteLine("Benutzerattribute:")
        For Each locAttribute As Attribute In locTypeInstanz.GetCustomAttributes(True)
            Console.WriteLine("    * " + locAttribute.ToString())
        Next
        Console.WriteLine()

        'Members und deren mˆgliche Attribute ermitteln
        Dim locMembers() As MemberInfo
        locMembers = locTypeInstanz.GetMembers()
        Console.WriteLine("Member-Liste:")
        For Each locMember As MemberInfo In locMembers
            Console.WriteLine("    *" + locMember.Name + ", " _
                                + locMember.MemberType.ToString)
            If locMember.GetCustomAttributes(True).Length > 0 Then
                Console.WriteLine("     " + New String("-"c, locMember.Name.Length))
                For Each locAttribute As Attribute In locMember.GetCustomAttributes(False)
                    Console.WriteLine("         * " + locAttribute.ToString())
                    For Each locPropertyInfo As PropertyInfo In locAttribute.GetType.GetProperties
                        Console.Write("          " + locPropertyInfo.Name)
                        Console.WriteLine(": " + locPropertyInfo.GetValue(locAttribute, Nothing).ToString)
                    Next
                Next
            End If

            If locMember.MemberType = MemberTypes.Property Then
                Dim locPropertyInfo As PropertyInfo = CType(locMember, PropertyInfo)
                Console.WriteLine("     Wert: " + locPropertyInfo.GetValue([Object], Nothing).ToString)
            End If
        Next
    End Sub

End Module

<Serializable(), Mein("‹ber der Klasse")>
Public Class Adresse

    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    <Mein("‹ber dem Konstruktor")>
    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        Me.Name = Name
        Me.Vorname = Vorname
        Me.Straﬂe = Straﬂe
        Me.PLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
    End Sub

    <Mein("‹ber einer Eigenschaft")>
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

    <Mein("‹ber einer Methode")>
    Public Overrides Function ToString() As String
        Dim locTemp As String
        locTemp = Name + ", " + Vorname + ", " + Straﬂe + ", " + PLZOrt + vbNewLine
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

'Benutzerdefiniertes Attribut erstellen
<AttributeUsage(AttributeTargets.All)> 
Public Class MeinAttribute
    Inherits Attribute
    Private myName As String

    Public Sub New(ByVal name As String)
        myName = name
    End Sub 'New

    Public ReadOnly Property Name() As String
        Get
            Return myName
        End Get
    End Property
End Class
