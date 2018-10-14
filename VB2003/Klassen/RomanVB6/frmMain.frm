VERSION 5.00
Begin VB.Form frmMain 
   BorderStyle     =   3  'Fester Dialog
   Caption         =   "Datenerfassung - Antike Bücher"
   ClientHeight    =   2760
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7845
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2760
   ScaleWidth      =   7845
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows-Standard
   Begin VB.CommandButton cmdOK 
      Caption         =   "OK"
      Height          =   375
      Left            =   6240
      TabIndex        =   10
      Top             =   240
      Width           =   1455
   End
   Begin VB.CommandButton cmdAbbrechen 
      Caption         =   "Abbrechen"
      Height          =   375
      Left            =   6240
      TabIndex        =   9
      Top             =   720
      Width           =   1455
   End
   Begin VB.TextBox txtDokumenttitel 
      Height          =   735
      Left            =   960
      MultiLine       =   -1  'True
      TabIndex        =   8
      Top             =   1680
      Width           =   5055
   End
   Begin VB.TextBox txtArabisch 
      Height          =   285
      Left            =   2520
      TabIndex        =   4
      Top             =   960
      Width           =   1455
   End
   Begin VB.TextBox txtRömisch 
      Height          =   285
      Left            =   960
      TabIndex        =   3
      Top             =   960
      Width           =   1455
   End
   Begin VB.TextBox txtErfasser 
      Height          =   285
      Left            =   960
      TabIndex        =   1
      Top             =   240
      Width           =   3135
   End
   Begin VB.Label Label5 
      Caption         =   "Dokumenttitel"
      Height          =   255
      Left            =   960
      TabIndex        =   7
      Top             =   1440
      Width           =   1335
   End
   Begin VB.Label Label4 
      Caption         =   "Arabisch"
      Height          =   255
      Left            =   2520
      TabIndex        =   6
      Top             =   720
      Width           =   1455
   End
   Begin VB.Label Label3 
      Caption         =   "Römisch"
      Height          =   255
      Left            =   960
      TabIndex        =   5
      Top             =   720
      Width           =   1455
   End
   Begin VB.Label Label2 
      Caption         =   "Jahr:"
      Height          =   255
      Left            =   120
      TabIndex        =   2
      Top             =   960
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "Erfasser:"
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   735
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

'Überall im Formular zugänglich,
'wird gebraucht sobald Abbrechen gedrückt wird
Private myCancel As Boolean

Private Sub txtRömisch_Change()
    
    'Umwandeln, wenn sich der Text ändern
    txtArabisch.Text = ValueFromRomanNumeral(txtRömisch)

End Sub

Private Sub txtArabisch_Change()
    
    'Umwandln, wenn sich der Text ändert
    If txtArabisch <> "" Then
        txtRömisch = RomanNumeral(txtArabisch.Text)
    End If
    
End Sub

Private Sub cmdAbbrechen_Click()
    
    'Bei Abbruch, Flag setzen
    myCancel = True
    Me.Hide

End Sub

Private Sub cmdOK_Click()
    
    'Eigentlich überflüssig...
    myCancel = False
    Me.Hide

End Sub

Public Function Erfassungsdialog(Erfasser As String, DokTitel As String, Jahrzahl As Date) As Boolean

    'Formular darstellen
    'bleibt bis zum nächsten Hide stehen,
    'da modaler Dialog
    Me.Show 1
    
    'Überprüfen ob Abbrechen gedrückt wurde,
    If myCancel = True Then
        'Variablen zurückliefern
        Erfasser = ""
        DokTitel = ""
        Jahrzahl = ""
    Else
        'sonst die Inhalte des Dialoges zurückliefern
        Erfasser = txtErfasser.Text
        DokTitel = txtDokumenttitel.Text
        Jahrzahl = Val(txtArabisch.Text)
    End If
    
    'Anzeigen, dass Dialog Daten "hatte"
    Erfassungsdialog = myCancel Xor True
    
End Function

Public Function RomanNumeral(ByVal ArabicNumber As Integer) As String
    
    Dim locCount As Integer
    Dim locDigitValue As Integer
    Dim locRoman As String
    Dim locDigits As String
    
    'Diese römischen Numerale gibt es
    locDigits = "IVXLCDM"
    
    'Der maximal darstellbare Bereich - eine Null gibt es nicht
    If ArabicNumber < 1 Or ArabicNumber > 3999 Then
        RomanNumeral = "#N/A#"
        Exit Function
    End If
  
    locCount = 1
    Do While ArabicNumber > 0
        locDigitValue = ArabicNumber Mod 10
        Select Case locDigitValue
        
            'Ziffern 1 bis 3 werden einfach hintereinander geschrieben (I, II, III)
            Case 1 To 3:
                locRoman = String$(locDigitValue, Mid$(locDigits, locCount, 1)) & locRoman
            
            'Die 4. Ziffer ist der "Einer-Wert" vor dem nächsten "fünfer-Wert" (IV)
            Case 4:
                locRoman = Mid$(locDigits, locCount, 2) & locRoman
        
            'Die 5. Ziffer hat ein eigenes Numeral (V)
            Case 5:
                locRoman = Mid$(locDigits, locCount + 1, 1) & locRoman
        
            'Kombination aus "Fünfer-Werten" und "Einer-Werten" (VI, VII, VIII)
            Case 6 To 8:
                locRoman = Mid$(locDigits, locCount + 1, 1) & String$(locDigitValue - 5, Mid$(locDigits, locCount, 1)) & locRoman
            
            'Kombination aus "Einer-Wert" und "Zehner-Wert" (IX)
            Case 9:
                locRoman = Mid$(locDigits, locCount, 1) & Mid$(locDigits, locCount + 2, 1) & locRoman
        
        End Select
        locCount = locCount + 2
        ArabicNumber = ArabicNumber \ 10
    Loop
    RomanNumeral = locRoman
End Function

Public Function ValueFromRomanNumeral(ByVal RomanNumeral As String) As Integer

    On Local Error GoTo vfrn_error
    
    Static Table(0 To 6, 0 To 1) As String
    Dim locCount As Integer
    Dim locChar As String * 1
    Dim retValue As Integer
    Dim z1 As Integer, z2 As Integer
    
    If RomanNumeral = "" Then
        ValueFromRomanNumeral = ""
        Exit Function
    End If
    
    'Tabelle zum Nachschlagen
    Table(0, 0) = "I": Table(0, 1) = "1"
    Table(1, 0) = "V": Table(1, 1) = "5"
    Table(2, 0) = "X": Table(2, 1) = "10"
    Table(3, 0) = "L": Table(3, 1) = "50"
    Table(4, 0) = "C": Table(4, 1) = "100"
    Table(5, 0) = "D": Table(5, 1) = "500"
    Table(6, 0) = "M": Table(6, 1) = "1000"
    
    locCount = 1
    
    Do While locCount <= Len(RomanNumeral)
        locChar = Mid$(RomanNumeral, locCount, 1)
        
        
        If locCount < Len(RomanNumeral) Then
            For z1 = 0 To 6
                If Table(z1, 0) = locChar Then Exit For
            Next z1
            For z2 = 0 To 6
                If Table(z2, 0) = Mid$(RomanNumeral, locCount + 1, 1) Then
                    Exit For
                End If
            Next z2
            If Val(Table(z1, 1)) < Val(Table(z2, 1)) Then
                'Stringfragment entfernen
                RomanNumeral = Left$(RomanNumeral, locCount - 1) + Mid$(RomanNumeral, locCount + 2)
                retValue = retValue + (Val(Table(z2, 1)) - Val(Table(z1, 1)))
            Else
                For z2 = 0 To 6
                    If Table(z2, 0) = locChar Then Exit For
                Next z2
                retValue = retValue + Val(Table(z2, 1))
                locCount = locCount + 1
            End If
        Else
            For z2 = 0 To 6
                If Table(z2, 0) = locChar Then Exit For
            Next z2
            retValue = retValue + Val(Table(z2, 1))
            locCount = locCount + 1
        End If
    Loop
    
    ValueFromRomanNumeral = retValue
    Exit Function
    
vfrn_error:
    ValueFromRomanNumeral = 0
    Exit Function

    
End Function

