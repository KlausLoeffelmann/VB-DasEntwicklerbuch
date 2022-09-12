Imports System.Reflection
Imports System.IO

Module mdlMain

    Sub Main()

        Dim locAdresse As New Adresse("Gaby", "Halek", "Buchstraﬂe 223", "32154 Autorhausen")
        PrintObjectInfo(locAdresse)
        Console.ReadLine()
        Exit Sub

        'Ein paar Type-Experimente:
        Dim locTest As New Adresse("Klaus", "Lˆffelmann", "Urlaubsgasse 17", "59555 Lippende")
        Dim locType1, locType2 As Type
        locType1 = locTest.GetType

        'Wichtig: Vollqualifizierte Namensangabe ist hier erforderlich;
        'der vollst‰ndige Namespace-Name (nicht: Assembly-Name!!!) muss
        'also mit angegeben werden.
        locType2 = Type.GetType("ReflectionDemo.Adresse")

        'Zwei Typobjekte miteinander vergleichen:
        Console.WriteLine("Der Typ " + locType1.FullName + _
                CStr(IIf(locType1 Is locType2, " entspricht ", " entspricht nicht ")) + _
                "dem Typ " + locType2.FullName)

        'So geht's auch; TypeOf funktioniert aber nur in Zusammenhang mit dem
        'Is-Operator:
        If TypeOf locTest Is ReflectionDemo.Adresse Then
            Console.WriteLine("Adresse-Typ erkannt!")
        Else
            Console.WriteLine("Adresse-Typ nichtr erkannt!")
        End If
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

        'Members und deren mˆgliche Attribute ermitteln
        Dim locMembers() As MemberInfo
        locMembers = locTypeInstanz.GetMembers()
        Console.WriteLine("Member-Liste:")
        For Each locMember As MemberInfo In locMembers
            Console.WriteLine("    *" + locMember.Name + ", " _
                                + locMember.MemberType.ToString)
            If locMember.GetCustomAttributes(True).Length > 0 Then
                Console.WriteLine("     " + New String("-"c, locMember.Name.Length))
            End If

            If locMember.MemberType = MemberTypes.Property Then
                Dim locPropertyInfo As PropertyInfo = CType(locMember, PropertyInfo)
                Console.WriteLine("     Wert: " + locPropertyInfo.GetValue([Object], Nothing).ToString)
            End If
        Next
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

    Public Overrides Function ToString() As String
        Dim locTemp As String
        locTemp = Name + ", " + Vorname + ", " + Straﬂe + ", " + PLZOrt + vbNewLine
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
