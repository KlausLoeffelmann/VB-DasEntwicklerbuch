VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Begin VB.Form frmSort 
   Caption         =   "Sortieren"
   ClientHeight    =   3030
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3030
   ScaleWidth      =   4680
   StartUpPosition =   2  'Bildschirmmitte
   Begin VB.Frame Frame1 
      Height          =   1455
      Left            =   120
      TabIndex        =   1
      Top             =   360
      Width           =   4335
      Begin VB.Label Label1 
         Alignment       =   2  'Zentriert
         Caption         =   "Liste wird sortiert. Bitte haben Sie einen Augenblick Geduld."
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   240
         TabIndex        =   2
         Top             =   480
         Width           =   3855
      End
   End
   Begin MSComctlLib.ProgressBar ProgressBar 
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   2160
      Width           =   4335
      _ExtentX        =   7646
      _ExtentY        =   661
      _Version        =   393216
      Appearance      =   1
      Max             =   1000
   End
End
Attribute VB_Name = "frmSort"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Friend Function Sort(Values() As ItemType) As ItemType()

    Dim locTemp As ItemType
    Dim locFlag As Boolean
    Dim count As Integer
    
    Me.Show 0
    Me.Refresh
    
    ProgressBar.Min = LBound(Values)
    ProgressBar.Max = UBound(Values)
    
    While Not locFlag
        locFlag = True
            
        For count = LBound(Values) To UBound(Values) - 1
            
            'Dreieckstausch
            If Values(count).Content > Values(count + 1).Content Then
                locTemp = Values(count)
                Values(count) = Values(count + 1)
                Values(count + 1) = locTemp
                locFlag = False
                Exit For
            End If
            
            If ProgressBar.Value < count Then
                ProgressBar.Value = count
                ProgressBar.Refresh
            End If
            
        Next
    
    Wend
    
    Me.Hide
    Unload Me
    
    Sort = Values

End Function

