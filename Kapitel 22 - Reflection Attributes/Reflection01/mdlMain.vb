Imports System.Reflection
Imports System.IO

Module mdlMain

    Sub Main()

        Dim locAdresse As New Adresse("Beck", "Adriana", "Buchstraﬂe 223", "32154 Autorhausen") With
            {.BefreundetMit = New List(Of Adresse) From
                {New Adresse("Klaus", "Lˆffelmann", "One Microsoftway", "99999 Redmond")}}

        PrintObjectInfo(locAdresse)
        Console.ReadLine()
        Exit Sub

        'Ein paar Type-Experimente:
        Dim locFreund As New Adresse("Beck", "Adriana", "Buchstraﬂe 223", "32154 Autorhausen")

        Dim locTest As New Adresse("Klaus", "Lˆffelmann", "Urlaubsgasse 17", "59555 Lippende")
        Dim locType1, locType2 As Type
        locType1 = locTest.GetType

        'Wichtig: TypeOf funktioniert nur zusammen mit dem Is-Operator:
        If TypeOf locTest Is Reflection01.Adresse Then
            Console.WriteLine("Adresse-Typ erkannt!")
        Else
            Console.WriteLine("Adresse-Typ nicht erkannt!")
        End If

        'Und auch das ist eine Alternative, die dasselbe bewirkt:
        If locTest.GetType Is GetType(Reflection01.Adresse) Then
            Console.WriteLine("Adresse-Typ erkannt!")
        Else
            Console.WriteLine("Adresse-Typ nichtr erkannt!")
        End If

        'So funktioniert's, wenn zwei Typobjekte 
        'miteinander vergleichen werden sollen:

        locType2 = GetType(Adresse)                     ' Der Normalfall, GetType als Operator
        locType2 = GetType(Reflection01.Adresse)        ' Alternativ: mit Namespace
        locType2 = Type.GetType("Reflection01.Adresse") ' Alternativ: aus String

        Console.WriteLine("Der Typ " + locType1.FullName + _
                CStr(IIf(locType1 Is locType2, " entspricht ", " entspricht nicht ")) + _
                "dem Typ " + locType2.FullName)

        'Rausfinden, ob eine Typvariable (zum Beispiel auch Basisklasse oder Interface)
        'Kompatibel zum eigentlich instanziierten Objekt ist. 
        Dim adresseMitGebDatum As New AbgeleiteteAdresse With
            {.Name = "Leenings", .Vorname = "Ramona", .Straﬂe = "Irgendwoweg 12",
             .PLZOrt = "Someplace-Hausen",
             .BefreundetMit = New List(Of Adresse) From {locTest, locFreund},
             .Geburtsdatum = #7/24/1991#}

        If GetType(Adresse).IsAssignableFrom(adresseMitGebDatum.GetType) Then
            Console.WriteLine(adresseMitGebDatum.ToShortString &
                              " kann in Typ 'Adresse' gespeichert werden.")
        End If

        Console.ReadLine()

    End Sub

    Sub PrintObjectInfo(ByVal [Object] As Object)
        'Den Objekttypen ermitteln, um auf die Objektinhalte zuzugreifen
        Dim locTypeInstanz As Type = [Object].GetType

        'Die nicht benutzerdefinierten Attribute ausgeben:
        Console.WriteLine("Attribute der Klasse:" + locTypeInstanz.FullName)
        Console.WriteLine("Standardattribute:")
        Console.WriteLine("    *" + locTypeInstanz.Attributes.ToString())
        Console.WriteLine()

        'Members und deren mˆgliche Attribute ermitteln
        Dim locMembers() As MemberInfo
        'Holt alles (auﬂer nicht-ˆffentliche Elemente); 
        locMembers = locTypeInstanz.GetMembers()
        'F¸hrt dazu, dass nur nicht-ˆffentliche Felder geholt werden:
        'locMembers = locTypeInstanz.GetMembers(BindingFlags.Instance Or BindingFlags.NonPublic)
        Console.WriteLine("Member-Liste:")
        For Each locMember As MemberInfo In locMembers
            Console.WriteLine("    *" + locMember.Name + ", " _
                                + locMember.MemberType.ToString)
            If locMember.GetCustomAttributes(True).Length > 0 Then
                Console.WriteLine("     " + New String("-"c, locMember.Name.Length))
            End If

            'Wenn es sich um Eigenschaften handelt, holen wir auch den Wert.
            If locMember.MemberType = MemberTypes.Property Then
                Dim locPropertyInfo As PropertyInfo = DirectCast(locMember, PropertyInfo)
                Dim value = locPropertyInfo.GetValue([Object], Nothing)
                If value IsNot Nothing Then
                    Console.WriteLine("     Wert: " + value.ToString)
                End If
            End If

            'Feldinformationen ausgeben, wenn entsprechende
            'Bindingflags angegeben wurde.
            If locMember.MemberType = MemberTypes.Field Then
                Dim locFieldInfo As FieldInfo = DirectCast(locMember, FieldInfo)
                Dim value = locFieldInfo.GetValue([Object])
                If value IsNot Nothing Then
                    Console.WriteLine("     Wert: " + value.ToString)
                End If
            End If
        Next
    End Sub

End Module

<Serializable()> _
Public Class Adresse

    Sub New()
        MyBase.New()
    End Sub

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

Public Class AbgeleiteteAdresse
    Inherits Adresse

    Property Geburtsdatum As Date

End Class
