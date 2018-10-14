Option Explicit On 
Option Strict On

Imports System.IO

Module mdlMain

    'Den müssen sie gegebenenfalls anpassen:
    'Falls Sie auf eine Netzwerkdatei zugreifen, setzen Sie die
    'Intranet-Sicherheitsrichtlinie auf voll vertrauenswürdig
    '(Systemsteuerung, Verwaltung, Assistenten)
    Private Const Filename As String = "D:\Writing\CurrProj\Microsoft\VB.NET\Prgs\Klassen\Inventory\obj\Debug\inventar.txt"

    Sub Main()
        Dim locFs As New StreamReader(Filename, System.Text.Encoding.Default)
        Dim locList As New DynamicList
        Dim locElements() As String
        Dim locShopItem As ShopItem
        Dim locDisplayMode As PrintType

        Console.WriteLine("Wählen Sie (1) für kurze und (2) für ausführliche Darstellung")
        Dim locKey As String = Console.ReadLine()
        If locKey = "1" Then
            locDIsplayMode = PrintType.Brief
        Else
            locDIsplayMode = PrintType.Detailed
        End If

        Do
            Try
                'Zeile einlesen
                Dim locLine As String = locFs.ReadLine()

                If locLine Is Nothing Then
                    locFs.Close()
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
                        locShopItem = New VideoOrDVD(locElements)
                    End If
                    locList.Add(locShopItem)
                End If

            Catch ex As Exception
                Console.WriteLine(New String("-"c, 80))
                Console.WriteLine(New String("!"c, 80))
                Console.WriteLine("Bei der Verarbeitung ist ein Fehler aufgetreten:")
                Console.WriteLine(ex.Message)
                locFs.Close()
                Exit Sub
            End Try

        Loop

        Dim locGrossAmount As Double = 0

        'Alle Elemente ausgeben
        For count As Integer = 0 To locList.Count - 1
            locList(count).PrintTypeSetting = locDIsplayMode
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

Enum FieldOrder ' Reihenfolge der Felder
    Type
    OrderNumber
    Titel
    AdditionalRemarks1
    GrossPrice
    AdditionalRemarks2
End Enum

Class ShopItem

    Protected myTitle As String                 ' Titel
    Protected myNetPrice As Double              ' Nettopreis
    Protected myOrderNumber As String           ' Artikelnummer
    Protected myPrintTypeSetting As PrintType   ' Ausgabeform

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

    Public Overridable Property GrossPrice() As Double
        Get
            Return myNetPrice * 1.16
        End Get

        Set(ByVal Value As Double)
            myNetPrice = Value / 1.16
        End Set
    End Property

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

    Protected myAuthor As String

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
            Return myNetPrice * 1.07
        End Get

        Set(ByVal Value As Double)
            myNetPrice = Value / 1.07
        End Set
    End Property

    Public Overrides ReadOnly Property Description() As String
        Get
            Return OrderNumber & vbTab & Title & vbCr & vbLf & "Autor: " & Author
        End Get
    End Property

End Class

Class VideoOrDVD
    Inherits ShopItem

    Protected myRunningTime As Integer
    Protected myActor As String

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

End Class

Class DynamicList

    Protected myStepIncreaser As Integer = 4
    Protected myCurrentArraySize As Integer
    Protected myCurrentCounter As Integer
    Protected myArray() As ShopItem

    Sub New()
        myCurrentArraySize = myStepIncreaser
        ReDim myArray(myCurrentArraySize)
    End Sub

    Sub Add(ByVal Item As ShopItem)

        'Prüfen, ob aktuelle Arraygrenze erreicht wurde
        If myCurrentCounter = myCurrentArraySize - 1 Then
            'Neues Array mit mehr Speicher anlegen,
            'und Elemente hinüberkopieren. Dazu:

            'Neues Array wird größer:
            myCurrentArraySize += myStepIncreaser

            'temporäres Array erstellen
            Dim locTempArray(myCurrentArraySize - 1) As ShopItem

            'Elemente kopieren
            'Wichtig: Um das Kopieren müssen Sie sich,
            'anders als bei VB6, selber kümmern!
            For locCount As Integer = 0 To myCurrentCounter
                locTempArray(locCount) = myArray(locCount)
            Next

            'temporäres Array dem Memberarray zuweisen
            myArray = locTempArray
        End If

        'Element im Array speichern
        myArray(myCurrentCounter) = Item

        'Zeiger auf nächstes Element erhöhen
        myCurrentCounter += 1

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
