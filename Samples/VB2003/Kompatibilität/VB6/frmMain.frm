VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form frmMain 
   BorderStyle     =   3  'Fester Dialog
   Caption         =   "Kompatibilitätsdemo"
   ClientHeight    =   5925
   ClientLeft      =   45
   ClientTop       =   735
   ClientWidth     =   7830
   LinkTopic       =   "frmMain"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5925
   ScaleWidth      =   7830
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'Bildschirmmitte
   Begin MSComDlg.CommonDialog CommonDialog 
      Left            =   7080
      Top             =   120
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Frame frmOptions 
      Caption         =   "Optionen"
      Height          =   2535
      Left            =   5040
      TabIndex        =   6
      Top             =   3120
      Width           =   2535
      Begin VB.OptionButton optOptions 
         Caption         =   "Zeichenfolgen"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   9
         Tag             =   "String"
         Top             =   1080
         Width           =   2175
      End
      Begin VB.OptionButton optOptions 
         Caption         =   "Datum-Werte"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   8
         Tag             =   "DateTime"
         Top             =   720
         Width           =   2175
      End
      Begin VB.OptionButton optOptions 
         Caption         =   "Ganze Zahlen"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   7
         Tag             =   "Integer"
         Top             =   360
         Value           =   -1  'True
         Width           =   2175
      End
   End
   Begin VB.TextBox txtValue 
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   720
      Width           =   4695
   End
   Begin VB.CommandButton btnSort 
      Caption         =   "Sortieren..."
      Height          =   375
      Left            =   5040
      TabIndex        =   4
      Top             =   1440
      Width           =   2535
   End
   Begin VB.CommandButton btnAdd 
      Caption         =   "Wert hinzufügen"
      Height          =   375
      Left            =   5040
      TabIndex        =   2
      Top             =   720
      Width           =   2535
   End
   Begin VB.CommandButton btnDelete 
      Caption         =   "Wert löschen"
      Height          =   375
      Left            =   5040
      TabIndex        =   3
      Top             =   2520
      Width           =   2535
   End
   Begin VB.ListBox lstValues 
      Height          =   3180
      Left            =   240
      TabIndex        =   5
      Top             =   2520
      Width           =   4575
   End
   Begin VB.Label Label1 
      Caption         =   "&Wert eingeben"
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   480
      Width           =   2415
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&Datei"
      Begin VB.Menu mnuGetList 
         Caption         =   "Liste &laden..."
         Shortcut        =   ^L
      End
      Begin VB.Menu mnuSaveList 
         Caption         =   "Liste &speichern..."
         Shortcut        =   ^S
      End
      Begin VB.Menu nuDUmmy1 
         Caption         =   "-"
      End
      Begin VB.Menu mnuQuitProgram 
         Caption         =   "Programm be&enden"
      End
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
DefInt A-Z          ' Standardtyp ist Int

Option Explicit     ' Besser ist das
Option Base 1       ' Arrays fangen bei 1 an

Dim myItemCounter   ' auf Formularebene gültig

Private Sub Form_Initialize()
    
    'Am Anfang des Programms
    'fangen wir bei 1 zu zählen an
    myItemCounter = 1
    
End Sub

Private Sub btnSort_Click()

    'Formular ist bereits instanziert,
    'kann direkt aufgerufen werden
    BuildList frmSort.Sort(GetItems)
    
End Sub

Private Sub btnAdd_Click()

    'Count ist Integer, locChar ist String mit fester Länge
    Dim locCount, locChar As String * 1
    Static locErrorCount As Integer
    Dim locItemType As ItemType
    
    'Wenn Integer, dann:
    If optOptions(ContentTypeEnum.Integer) Then
        'Überprüfen, ob Buchstaben vorkommen
        
        'txtValue.Text wird dabei automatisch angesprochen
        For locCount = 1 To Len(txtValue)
            
            locChar = Mid$(txtValue, locCount, 1)
            
            If locChar < "0" Or locChar > "9" Then
                
                Dim locIllegalChar As Boolean
                locIllegalChar = True
                Exit For
            
            End If
        
        Next locCount
        
        'locIllegalChar ist gültig und auf
        'locChar könnten wir auf zugreifen,
        'wenn wir wollten
        If locIllegalChar Then
            MsgBox "Bitte nur Zahlen eingeben" + vbCr + _
            "(Keine Zahlen, keine Trennzeichen)" + vbCr + _
            "Info: Das war die " + Str$(locErrorCount + 1) + ". Fehleingabe", _
            vbOKOnly + vbExclamation, "Falsche Eingabe"
            locErrorCount = locErrorCount + 1
            txtValue.SetFocus
            txtValue.SelStart = 0
            txtValue.SelLength = Len(txtValue)
            Exit Sub
        End If
    
        If Not IsRangeOk(txtValue) Then
            MsgBox "Wertebereich wurde überschritten!" + vbCr + _
            "(Nur im Integerbereich von 0 bis 32768)" + vbCr + _
            "Info: Das war die " + Str$(locErrorCount + 1) + ". Fehleingabe", _
            vbOKOnly + vbExclamation, "Falsche Eingabe"
            locErrorCount = locErrorCount + 1
            txtValue.SetFocus
            txtValue.SelStart = 0
            txtValue.SelLength = Len(txtValue)
            Exit Sub
        End If
        
        locItemType.Content = CInt(txtValue)

    
    'Wenn "Datums", dann:
    ElseIf optOptions(ContentTypeEnum.DateTime) Then
        If Not IsDate(txtValue) Then
            MsgBox "Kein Datumsformat!" + vbCr + _
            "Info: Das war die " + Str$(locErrorCount + 1) + ". Fehleingabe", _
            vbOKOnly + vbExclamation, "Falsche Eingabe"
            locErrorCount = locErrorCount + 1
            txtValue.SetFocus
            txtValue.SelStart = 0
            txtValue.SelLength = Len(txtValue)
            Exit Sub
        End If
        
        locItemType.Content = CDate(txtValue)
    
    'Wenn Zeichenkette, dann werden alle Eingaben akzeptiert
    Else
        locItemType.Content = txtValue
    End If
    
    locItemType.Nr = myItemCounter
    myItemCounter = myItemCounter + 1
    locItemType.CreatedAt = Now
    
    lstValues.AddItem ToString(locItemType)
    txtValue.SetFocus
    txtValue.SelStart = 0
    txtValue.SelLength = Len(txtValue)
    
End Sub

Private Sub lstValues_GotFocus()
    
    btnDelete.Default = True

End Sub

Private Sub mnuGetList_Click()

    On Local Error GoTo 10
        
    Dim locType As ContentTypeEnum
    
    With CommonDialog
        .DialogTitle = "Werteliste laden"
        .Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
        .DefaultExt = "*.vls"
        .InitDir = "C:\"
        .CancelError = True
        .ShowOpen
        
        BuildList GetListFromFile(.Filename, locType, True)
    End With
    
    Exit Sub
    
10  If Err.Number = cdlCancel Then
        Exit Sub
    Else
        MsgBox "Fehler beim Öffnen der Datei"
        Exit Sub
    End If
    
End Sub

Private Sub mnuQuitProgram_Click()

    Unload Me
    
End Sub

Private Sub mnuSaveList_Click()
    
    On Local Error GoTo 20
        
    Dim locType As ContentTypeEnum
    
    With CommonDialog
        .DialogTitle = "Werteliste laden"
        .Filter = "Wertelisten (*.vls)|*.vls|Alle Dateien (*.*)|*.*"
        .DefaultExt = "*.vls"
        .InitDir = "C:\"
        .CancelError = True
        .ShowSave
        
        SaveListToFile .Filename, GetItems, GetContentType, True
        
    End With
    
    Exit Sub
    
20: If Err.Number = cdlCancel Then
        Exit Sub
    Else
        MsgBox "Fehler beim Öffnen der Datei"
        Exit Sub
    End If

End Sub

Private Sub optOptions_Click(Index As Integer)

    Dim locBack
    
    'Beim Umstellen werden die Werte gelöscht
    locBack = MsgBox("Wenn Sie den Eingabetypen ändern," + vbCr + _
                "werden alle eingegebenen Werte gelöscht" + vbCr + _
                "Fortfahren?", vbYesNo + vbQuestion, "Werte umstellen?")
    
    If locBack = vbYes Then
        lstValues.Clear
    End If
    
End Sub

Private Sub txtValue_GotFocus()

    btnAdd.Default = True
    txtValue.SelStart = 0
    txtValue.SelLength = Len(txtValue)
    
End Sub

Private Function IsRangeOk(IntChars As String) As Boolean

    On Local Error GoTo 1000
    
    Dim locTemp As Integer
    locTemp = Val(IntChars)
    IsRangeOk = True
    Exit Function

    'Zeilennummern benötigen keinen Doppelpunkt in VB6!
1000 IsRangeOk = False
    Exit Function

End Function

Private Sub btnDelete_Click()
    
    'Abfangen, wenn gar kein Element markiert ist
    If lstValues.ListIndex = -1 Then
        MsgBox "Bitte wählen Sie ein Element aus der Liste zum Löschen aus!", _
                vbOKOnly + vbExclamation
        Exit Sub
    End If
    
    'Element löschen
    lstValues.RemoveItem lstValues.ListIndex
    
    'Liste auslesen und neu aufbauen
    BuildList GetItems
    
End Sub

Private Sub BuildList(Values() As ItemType)

    Dim i, locCount
    
    locCount = 1
    'Elemente der Liste löschen
    lstValues.Clear
    
    'Neu nummeriert der Liste
    'wieder hinzufügen
    For i = LBound(Values) To UBound(Values)
        Values(i).Nr = locCount
        locCount = locCount + 1
        lstValues.AddItem ToString(Values(i))
    Next
    
    'Damit es für die nächste Eingabe passt
    myItemCounter = locCount

End Sub

Private Function GetItems() As ItemType()

    'i ist Integer, locTemp ist String
    Dim i, locTemp As String
    ReDim backItems(lstValues.ListCount) As ItemType
    
    'Array aus der Liste aufbauen
    For i = 1 To lstValues.ListCount
        locTemp = lstValues.List(i - 1)
        backItems(i) = Parse(locTemp, GetContentType)
    Next i
    
    GetItems = backItems

End Function

Private Function GetContentType() As ContentTypeEnum
    
    Dim backOptType As Long
    
    'Welcher Typ wird gerade verarbeitet?
    For backOptType = 0 To 2
        If optOptions(backOptType) Then Exit For
    Next backOptType
    
    'Casting von Long zu Enum geschieht automatisch
    GetContentType = backOptType

End Function
