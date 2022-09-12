Imports System.IO

Module mdlMain

    'Die Inventardatei muss im Programmverzeichnis stehen.
    Private Filename As String = My.Application.Info.DirectoryPath & "\Inventar.txt"

    Sub Main()

        'Streamreader zum Einlesen der Textdateien
        Dim locSr As StreamReader
        Dim locList As New DynamicList  ' Die Dynamische Liste
        Dim locElements() As String     ' Die einzelnen ShopItem-Elemente
        Dim locShopItem As ShopItem     ' Ein einzelnes Shop-Element
        Dim locDisplayMode As PrintType ' Der Darstellungsmodus

        'Schauen, ob die Textdatei vorhanden ist:
        Try
            locSr = New StreamReader(Filename, System.Text.Encoding.Default)
        Catch ex As Exception
            Console.WriteLine("Fehler beim Lesen der Inventardatei!" & _
                              vbNewLine & ex.Message)
            Console.WriteLine()
            Console.WriteLine("Taste drücken zum Beenden")
            Console.ReadKey()
            Exit Sub
        End Try

        Console.WriteLine("Wählen Sie (1) für kurze und (2) für ausführliche Darstellung")



        Dim locKey As Char = Console.ReadKey.KeyChar
        If locKey = "1"c Then
            locDisplayMode = PrintType.Brief
        Else
            locDisplayMode = PrintType.Detailed
        End If

        Do
            Try
                'Zeile einlesen
                Dim locLine As String = locSr.ReadLine()

                'Nichts eingegeben, dann war's das!
                If String.IsNullOrEmpty(locLine) Then
                    locSr.Close()
                    Exit Do
                End If

                'Semikolon überlesen
                If Not locLine.StartsWith(";") Then

                    'So braucht man kein explizites Char-Array zu deklarieren
                    'um die Zeile in die durch Komma getrennten Elemente zu zerlegen
                    locElements = locLine.Split(New Char() {";"c})

                    If locElements(FieldOrder.Type) = "1" Then
                        locShopItem = New BookItem(locElements)
                    Else
                        locShopItem = New DVDItem(locElements)
                    End If
                    locList.Add(locShopItem)
                End If

            Catch ex As Exception
                Console.WriteLine("Fehler beim Auswerten der Inventardatei!" & _
                                  vbNewLine & ex.Message)
                Console.WriteLine()
                Console.WriteLine("Taste drücken zum Beenden")
                Console.ReadKey()
                locSr.Close()
                Exit Sub
            End Try

        Loop

        Dim locGrossAmount As Double = 0

        'Alle Elemente ausgeben
        For count As Integer = 0 To locList.Count - 1
            locList(count).PrintTypeSetting = locDisplayMode
            Console.WriteLine(locList(count).ToString())
            locGrossAmount += locList(count).GrossPrice
        Next

        Console.WriteLine()
        Console.WriteLine("-----------------------------")
        Console.WriteLine("Gesamtsumme: " & locGrossAmount.ToString("#,##0.00") & " Euro")
        Console.WriteLine("-----------------------------")
        Console.WriteLine("-----------------------------")
        Console.WriteLine()
        Console.WriteLine("Return drücken, zum Beenden")
        Console.ReadLine()

    End Sub

End Module

Enum PrintType  ' Reportform
    Brief       ' kurz
    Detailed    ' ausführlich
End Enum

Enum FieldOrder ' Zuständig für die Reihenfolge der Felder
    Type
    OrderNumber
    Titel
    AdditionalRemarks1
    GrossPrice
    AdditionalRemarks2
End Enum

MustInherit Class ShopItem

    Private myTitle As String                 ' Titel
    Private myNetPrice As Double              ' Nettopreis
    Private myOrderNumber As String           ' Artikelnummer
    Private myPrintTypeSetting As PrintType   ' Ausgabeform

    Public Sub New()
        myPrintTypeSetting = PrintType.Detailed
    End Sub

    Public Sub New(ByVal StringArray() As String)
        Title = StringArray(FieldOrder.Titel)
        GrossPrice = Double.Parse(StringArray(FieldOrder.GrossPrice)) / 100
        OrderNumber = StringArray(FieldOrder.OrderNumber)
        PrintTypeSetting = PrintType.Detailed
    End Sub

    Public Property Title() As String
        Get
            Return myTitle
        End Get
        Set(ByVal Value As String)
            myTitle = Value
        End Set
    End Property

    Public Property OrderNumber() As String
        Get
            Return myOrderNumber
        End Get
        Set(ByVal Value As String)
            myOrderNumber = Value
        End Set
    End Property

    Public Property NetPrice() As Double
        Get
            Return myNetPrice
        End Get

        Set(ByVal Value As Double)
            myNetPrice = Value
        End Set

    End Property

    Public ReadOnly Property NetPriceFormatted() As String
        Get
            Return NetPrice.ToString("#,##0.00") + " Euro"
        End Get
    End Property

    Public MustOverride Property GrossPrice() As Double

    Public ReadOnly Property GrossPriceFormatted() As String
        Get
            Return GrossPrice.ToString("#,##0.00") + " Euro"
        End Get
    End Property

    Public ReadOnly Property VATAmountFormatted() As String
        Get
            Return (GrossPrice - myNetPrice).ToString("#,##0.00") + " Euro"
        End Get
    End Property

    Public Overridable ReadOnly Property Description() As String
        Get
            Return OrderNumber & vbTab & Title
        End Get
    End Property

    Public Property PrintTypeSetting() As PrintType
        Get
            Return myPrintTypeSetting
        End Get

        Set(ByVal Value As PrintType)
            myPrintTypeSetting = Value
        End Set
    End Property

    Public Overrides Function ToString() As String

        If PrintTypeSetting = PrintType.Brief Then
            'Kurzform: Es wird in jedem Fall
            'die Description-Eigenschaft des Objektes
            'verwendet
            Return MyClass.Description & vbCr & vbLf & _
                Me.NetPriceFormatted & vbTab & Me.VATAmountFormatted & vbTab & _
                Me.GrossPriceFormatted & vbCr & vbLf
        Else
            'Langform: Die Description Eigenschaft des Objektes
            'selber wird verwendet
            Return Me.Description & vbCr & vbLf & _
                Me.NetPriceFormatted & vbTab & Me.VATAmountFormatted & vbTab & _
                Me.GrossPriceFormatted & vbCr & vbLf
        End If

    End Function

End Class

Class BookItem
    Inherits ShopItem

    Private myAuthor As String

    Public Sub New(ByVal StringArray() As String)
        MyBase.New(StringArray)
        Author = StringArray(FieldOrder.AdditionalRemarks1)
    End Sub

    Public Overridable Property Author() As String
        Get
            Return myAuthor
        End Get
        Set(ByVal Value As String)
            myAuthor = Value
        End Set
    End Property

    Public Overrides Property GrossPrice() As Double
        Get
            Return NetPrice * 1.07
        End Get

        Set(ByVal Value As Double)
            NetPrice = Value / 1.07
        End Set
    End Property

    Public Overrides ReadOnly Property Description() As String
        Get
            Return OrderNumber & vbTab & Title & vbCr & vbLf & "Autor: " & Author
        End Get
    End Property

End Class

Class DVDItem
    Inherits ShopItem

    Private myRunningTime As Integer
    Private myActor As String

    Public Sub New(ByVal StringArray() As String)
        MyBase.New(StringArray)
        RunningTime = Integer.Parse(StringArray(FieldOrder.AdditionalRemarks1))
        Actor = StringArray(FieldOrder.AdditionalRemarks2)
    End Sub

    Public Overridable Property RunningTime() As Integer
        Get
            Return myRunningTime
        End Get
        Set(ByVal Value As Integer)
            myRunningTime = Value
        End Set
    End Property

    Public Overridable Property Actor() As String
        Get
            Return myActor
        End Get
        Set(ByVal Value As String)
            myActor = Value
        End Set
    End Property

    Public Overrides ReadOnly Property Description() As String
        Get
            Return OrderNumber & vbTab & Title & vbCr & vbLf & "Laufzeit: " & myRunningTime & " Min." & vbCr & vbLf & "Hauptdarsteller: " & Actor
        End Get
    End Property

    Public Overrides Property GrossPrice() As Double
        Get
            Return NetPrice * 1.19
        End Get

        Set(ByVal Value As Double)
            NetPrice = Value / 1.19
        End Set
    End Property
End Class

Class DynamicList

    Private myStep As Integer = 4         ' Schrittweite, die das Array erhöht wird.
    Private myCurrentArraySize As Integer ' Aktuelle Array-Größe
    Private myCurrentCounter As Integer   ' Zeiger auf aktuelles Element
    Private myArray() As ShopItem         ' Array mit den Elementen.

    Sub New()
        myCurrentArraySize = myStep
        ReDim myArray(myCurrentArraySize - 1)
    End Sub

    Sub Add(ByVal Item As ShopItem)

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf nächstes Element erhöhen
        myCurrentCounter += 1

        'Prüfen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hinüberkopieren. Dazu:

            'Neues Array wird größer:
            myCurrentArraySize += myStep

            'temporäres Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As ShopItem

            'Elemente kopieren; das geht mit dieser
            'statischen Methode extrem schnell, da zum Einen nur die
            'Zeiger kopiert werden, zum anderen diese Routine
            'intern nicht in Managed Code sondern nativem Assembler ausgeführt wird.
            Array.Copy(myArray, locTempArray, myArray.Length)

            'Auch hier werden nur die Zeiger auf die Elemente "verbogen".
            'Die vorherige Liste der Zeiger in myArray, die nun verwaist ist,
            'fällt dem Garbage Collector zum Opfer.
            myArray = locTempArray
        End If
    End Sub

    'Liefert die Anzahl der vorhandenen Elemente zurück
    Public Overridable ReadOnly Property Count() As Integer
        Get
            Return myCurrentCounter
        End Get
    End Property

    'Erlaubt das Zuweisen 
    Default Public Overridable Property Item(ByVal Index As Integer) As ShopItem
        Get
            Return myArray(Index)
        End Get

        Set(ByVal Value As ShopItem)
            myArray(Index) = Value
        End Set
    End Property
End Class
