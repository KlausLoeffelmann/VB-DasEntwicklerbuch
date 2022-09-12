Module LinqToXml

    Sub Demo()
        ' Liste mit Fahrzeugdaten aufbauen
        Dim fahrzeugliste As New List(Of Fahrzeug)
        fahrzeugliste.Add(New Fahrzeug With {.Kennzeichen = "MS-VB 2008", .Hersteller = "MAN", .Ladung = New Fahrzeug.LadungsBeschreibung With {.Menge = 10000, .Gut = "Salz"}})
        fahrzeugliste.Add(New Fahrzeug With {.Kennzeichen = "MS-C# 2008", .Hersteller = "Mercedes-Benz", .Ladung = New Fahrzeug.LadungsBeschreibung With {.Menge = 20000, .Gut = "Erdnüsse"}})
        fahrzeugliste.Add(New Fahrzeug With {.Kennzeichen = "MS-J# 2008", .Hersteller = "DAF", .Ladung = New Fahrzeug.LadungsBeschreibung With {.Menge = 5000, .Gut = "Wackeldackel"}})

        ' XElemet daraus mit LINQ erstellen
        Dim fuhrpark = New XElement("fuhrpark", _
                                    From fzg In fahrzeugliste _
                                    Select New XElement("fahrzeug", _
                                                        New XElement("kennzeichen", fzg.Kennzeichen), _
                                                        New XElement("hersteller", fzg.Hersteller), _
                                                        New XElement("ladung", fzg.Ladung.Gut, New XAttribute("menge", fzg.Ladung.Menge)) _
                                                        ))

        Console.WriteLine(fuhrpark)


        ' XElement mit LINQ und XML Literalen erstellen
        fuhrpark = <fuhrpark>
                       <%= From fzg In fahrzeugliste _
                           Select <fahrzeug>
                                      <kennzeichen><%= fzg.Kennzeichen %></kennzeichen>
                                      <hersteller><%= fzg.Hersteller %></hersteller>
                                      <ladung menge=<%= fzg.Ladung.Menge %>>
                                          <%= fzg.Ladung.Gut %>
                                      </ladung>
                                  </fahrzeug> _
                       %>
                   </fuhrpark>
        Console.WriteLine(fuhrpark)
        Console.ReadKey()




    End Sub

End Module

''' <summary>
''' Hilfsklasse für die Abbildung eines Fahrzeugs
''' </summary>
''' <remarks></remarks>
Public Class Fahrzeug
    Public Class LadungsBeschreibung
        Private _menge As Double
        Private _gut As String

        Public Property Menge() As Double
            Get
                Return _menge
            End Get
            Set(ByVal value As Double)
                _menge = value
            End Set
        End Property

        Public Property Gut() As String
            Get
                Return _gut
            End Get
            Set(ByVal value As String)
                _gut = value
            End Set
        End Property
    End Class
    Private _kennzeichen As String
    Private _ladung As LadungsBeschreibung
    Private _hersteller As String

    Public Property Kennzeichen() As String
        Get
            Return _kennzeichen
        End Get
        Set(ByVal value As String)
            _kennzeichen = value
        End Set
    End Property

    Public Property Ladung() As LadungsBeschreibung
        Get
            Return _ladung
        End Get
        Set(ByVal value As LadungsBeschreibung)
            _ladung = value
        End Set
    End Property

    Public Property Hersteller() As String
        Get
            Return _hersteller
        End Get
        Set(ByVal value As String)
            _hersteller = value
        End Set
    End Property
End Class
