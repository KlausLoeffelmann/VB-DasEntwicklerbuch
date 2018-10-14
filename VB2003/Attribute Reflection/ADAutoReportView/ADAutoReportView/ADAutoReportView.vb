Imports System.Collections
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms

'Das eigentliche Steuerelement
Public Class ADAutoReportView
    Inherits System.Windows.Forms.ListView

    'Membervariablen
    Private myIList As IList
    Private myColumnNames As ADAutoReportColumns

    Sub New()
        MyBase.New()
        'Auf Detailansicht umschalten
        Me.View = Windows.Forms.View.Details
        'Trennlinien zwischen den Zeilen einschalten
        Me.GridLines = True
        'Bei Fokusverlust Markierung dennoch anzeigen
        Me.HideSelection = False
        'Ganze Reihe soll selektiert werden
        Me.FullRowSelect = True
    End Sub

#Region "Elemente-Klassen (privat)"
    'Geschachtelte Hilfsklasse, auf die nur das Steuerelement zugreifen kann.
    'Wird verwendet, um die Einstellungen für die Spalten zu speichern
    Private Class ADAutoReportColumns
        Inherits CollectionBase

        Public Function Add(ByVal AutoReportColumn As ADAutoReportColumn)
            Return MyBase.List.Add(AutoReportColumn)
        End Function

        Default Public Property Item(ByVal Index As Integer) As ADAutoReportColumn
            Get
                Return MyBase.List.Item(Index)
            End Get
            Set(ByVal Value As ADAutoReportColumn)
                MyBase.List(Index) = Value
            End Set
        End Property

        'Sortiert das ganze Array nach der Sortierreihenfolgenr. (Order-No),
        'damit die Spalten in der richtigen Reihenfolge angezeigt werden können.
        Public Sub ShellSortByOrderNo()

            Dim locOutCount, locInCount As Integer
            Dim locDelta As Integer
            Dim locARCTemp As ADAutoReportColumn

            locDelta = 1

            'Größten Wert der Distanzfolge ermitteln
            Do
                locDelta = 3 * locDelta + 1
            Loop Until locDelta > Me.List.Count

            Do
                'War einen zu groß, also wieder teilen
                locDelta /= 3

                'Shellsort's Kernalgorithmus
                For locOutCount = locDelta To Me.List.Count - 1
                    locARCTemp = Me(locOutCount)
                    locInCount = locOutCount
                    Do While (Me(locInCount - locDelta).OrderNo > locARCTemp.OrderNo)
                        Me(locInCount) = Me(locInCount - locDelta)
                        locInCount = locInCount - locDelta
                        If (locInCount <= locDelta) Then Exit Do
                    Loop
                    Me(locInCount) = locARCTemp
                Next
            Loop Until locDelta = 0

        End Sub

    End Class

    'Speichert eine einzelne Spalteneinstellung
    Private Class ADAutoReportColumn

        Private myPropertyName As String
        Private myDisplayName As String
        Private myExplicitlyDefined As Boolean
        Private myColumnWidth As Integer
        Private myOrderNo As Integer

        Sub New(ByVal PropertyName As String, ByVal Displayname As String)
            myPropertyName = PropertyName
            myDisplayName = Displayname
        End Sub

        'Speichert den Eigenschaftennamen
        Public Property PropertyName() As String
            Get
                Return myPropertyName
            End Get
            Set(ByVal Value As String)
                myPropertyName = Value
            End Set
        End Property

        'Speichert den Namen dieser Eigenschaft, der als Spaltentitel
        'angezeigt werden soll.
        Public Property DisplayName() As String
            Get
                Return myDisplayName
            End Get
            Set(ByVal Value As String)
                myDisplayName = Value
            End Set
        End Property

        'Dient zum Festhalten des Status, der bestimmt, ob die Spalte "nur"
        'aus einer Eigenschaft hervorging, oder gezielt durch ein Attribut
        'bestimmt wurde. Wenn keine Attribute die Eigenschaften eines Objekt-
        'Arrays definiert haben, werden alle Eigenschaften angezeigt, ansonsten
        'nur diejenigen, die mit Attributen dafür vorgesehen wurden.
        Public Property ExplicitlyDefined() As Boolean
            Get
                Return myExplicitlyDefined
            End Get
            Set(ByVal Value As Boolean)
                myExplicitlyDefined = Value
            End Set
        End Property

        'Speichert die Spaltenbreite
        Public Property ColumnWidth() As Integer
            Get
                Return myColumnWidth
            End Get
            Set(ByVal Value As Integer)
                myColumnWidth = Value
            End Set
        End Property

        'Speichert die Rangfolgennr. für das Sortieren der Spalten
        Public Property OrderNo() As Integer
            Get
                Return myOrderNo
            End Get
            Set(ByVal Value As Integer)
                myOrderNo = Value
            End Set
        End Property
    End Class
#End Region

    <Description("Definiert die in der ListView angezeigten Elemente" + _
                 "oder ermittelt diese")> _
    Public Property List() As IList
        Get
            Return myIList
        End Get

        'Setzen der Eigenschaft:
        Set(ByVal Value As IList)
            'Alle Inhalte löschen
            Me.Items.Clear()
            'Allte Spaltentitel löschen
            Me.Columns.Clear()
            If Value Is Nothing Then
                'Abbrechen, falls Nothing zugewiesen wurde
                Return
            Else
                'Liste zuweisen
                myIList = Value
                'Die Spaltennamen und Objekteigenschaften entweder durch das Objekt
                'selbst oder zugewiesene Attribute ermitteln und in myColumnNamens 
                'speichern.
                myColumnNames = GetColumnNames(Value)
                'Anschließend die Spaltentitel setzen...
                SetupColumns()
                '...und die Liste mit Einträgen füllen, die sich aus myIList ergeben
                SetupEntries()
            End If
        End Set
    End Property

    'Spaltentitel einsetzen
    Private Sub SetupColumns()
        With Me.Columns
            'TODO: Das Alignment könnte auch in Attributen untergebracht werden
            For Each cn As ADAutoReportColumn In myColumnNames
                .Add(cn.DisplayName, cn.ColumnWidth, Windows.Forms.HorizontalAlignment.Left)
            Next
        End With
    End Sub

    'Einträge in die Liste schreiben
    Private Sub SetupEntries()
        For Each obj As Object In myIList
            With Me.Items
                Dim locLvi As New ListViewItem
                'Erste darzustellende Eigenschaft erfährt Sonderbehandlung,
                'da sie nicht durch SubItems dargestellt wird
                'Mit GetPropValue wird die Stringumwandlung der Eigenschaft
                'eines Objektes ermittelt.
                locLvi.Text = GetPropValue(obj, myColumnNames(0).PropertyName)
                For c As Integer = 1 To myColumnNames.Count - 1
                    With locLvi.SubItems
                        .Add(GetPropValue(obj, myColumnNames(c).PropertyName))
                    End With
                Next
                'Eintrag der Liste hinzufügen
                .Add(locLvi)
            End With
        Next

        'Spaltenbreiten anpassen
        Dim ccount As Integer = 0
        For Each cn As ADAutoReportColumn In myColumnNames
            Me.Columns(ccount).Width = cn.ColumnWidth
            ccount += 1
        Next

    End Sub

    'Ermittelt den Inhalt der Eigenschaft eines Objektes als String
    Private Function GetPropValue(ByVal [object] As Object, ByVal PropertyName As String) As String

        Dim locPI As PropertyInfo = [object].GetType.GetProperty(PropertyName)
        Return locPI.GetValue([object], Nothing).ToString
    End Function

    'Ermittelt die durch die Objekteigenschaften vorgegebenen dazustellenden
    'Spalten, wenn keine Attribute verwendet werden. Werden Attribute verwendet,
    'ermittelt die Funktion nur die Eigenschaften eines Objektes, die mit einem
    'entsprechenden Attribut versehen sind.
    Private Function GetColumnNames(ByVal List As IList) As ADAutoReportColumns

        Dim locTypeToExamine As Type
        Dim locARCs As New ADAutoReportColumns
        Dim locExplicitlyDefined As Boolean = False

        If List Is Nothing Then
            'Soweit dürfte es eigentlich gar nicht kommen, aber wir gehen auf No. sicher.
            Dim Up As New NullReferenceException("Die Übergebende Liste ist leer!")
            Throw Up
        End If

        'Das erste Objekt ist maßgeblich für die Typen aller anderen Objekte.
        'Die Liste muss also homogen (Objektableitungen ausgenommen) sein, damit 
        'die automatische Element-Zuweisung reibungslos funktioniert.
        locTypeToExamine = List(0).GetType

        'Alle Eigenschaften des Objektes durchforsten
        For Each pi As PropertyInfo In locTypeToExamine.GetProperties
            'Vielleicht gibt es keine Attribute, die näheres bestimmen;
            'in diesem Fall wird jede Objekteigenschaft verwendet.
            'Anzeigename ist dann Eigenschaftenname.
            Dim locARC As New ADAutoReportColumn(pi.Name, pi.Name)
            'Vorgabebreite: Spalten automatisch angleichen
            locARC.ColumnWidth = -2
            'Nach Attributen Ausschau halten
            For Each a As Attribute In pi.GetCustomAttributes(True)
                'Nur reagieren, wenn es sich um unseren speziellen Typ handelt
                If TypeOf a Is ADAutoReportColumnAttribute Then
                    'Parameter aus dem Attribute-Objekt übernehmen
                    locARC.DisplayName = a.GetType.GetProperty("DisplayName").GetValue(a, Nothing).ToString
                    locARC.ColumnWidth = CInt(a.GetType.GetProperty("Width").GetValue(a, Nothing))
                    locARC.OrderNo = CInt(a.GetType.GetProperty("OrderNo").GetValue(a, Nothing))
                    locARC.ExplicitlyDefined = True
                    locExplicitlyDefined = True
                End If
            Next
            'Zur Spaltenkopf-Parameterliste hinzufügen
            locARCs.Add(locARC)
        Next

        'Wenn Attribute gefunden worden sind, dann die Eigenschaften
        'wieder rausschmeißen, denen kein Attribut zugewiesen wurde
        If locExplicitlyDefined Then

            Dim locCount As Integer = 0

            Do While locCount < locARCs.Count
                If Not locARCs(locCount).ExplicitlyDefined Then
                    locARCs.RemoveAt(locCount)
                Else
                    locCount += 1
                End If

            Loop
        End If
        'Reihenfolge berücksichtigen
        locARCs.ShellSortByOrderNo()
        Return locARCs

    End Function

End Class

'Dieses Attribut kann nur auf Eigenschaften angewendet werden
<AttributeUsage(AttributeTargets.Property)> _
Public Class ADAutoReportColumnAttribute
    Inherits Attribute

    Private myDisplayName As String
    Private myWidth As Integer
    Private myOrderNo As Integer
    'Vorgabe-Reihenfolgenr. für den Fall, dass diese nicht mit angegeben wurde
    Private Shared myDefaultOrderNo As Integer

    Shared Sub New()
        myDefaultOrderNo = 1
    End Sub

    'Konstruktoren, die den Darstellungsnamen...
    Sub New(ByVal DisplayName As String)
        myDisplayName = DisplayName
        myWidth = -2
        myOrderNo = myDefaultOrderNo
        myDefaultOrderNo += 1

    End Sub

    '...und optional die Breite der Tabellenspalte bestimmen...
    Sub New(ByVal DisplayName As String, ByVal Width As Integer)
        myDisplayName = DisplayName
        myWidth = Width
        myOrderNo = myDefaultOrderNo
        myDefaultOrderNo += 1
    End Sub

    '...sowie die Reihenfolge der Spalte.
    Sub New(ByVal DisplayName As String, ByVal Width As Integer, ByVal OrderNo As Integer)
        myDisplayName = DisplayName
        myWidth = Width
        myOrderNo = OrderNo
        If OrderNo > myDefaultOrderNo Then
            myDefaultOrderNo = OrderNo + 1
        End If
    End Sub

    'Name des Spaltenkopfs
    Public Property DisplayName() As String
        Get
            Return myDisplayName
        End Get
        Set(ByVal Value As String)
            myDisplayName = Value
        End Set
    End Property

    'Spaltenbreite
    Public Property Width() As Integer
        Get
            Return myWidth
        End Get
        Set(ByVal Value As Integer)
            myWidth = Value
        End Set
    End Property

    'Sortierschlüssel
    Public Property OrderNo() As Integer
        Get
            Return myOrderNo
        End Get
        Set(ByVal Value As Integer)
            myOrderNo = Value
        End Set
    End Property
End Class
