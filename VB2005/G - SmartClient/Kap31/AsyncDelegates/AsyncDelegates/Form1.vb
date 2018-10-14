Imports System.Collections.Generic
Imports System.ComponentModel

Public Class Form1

    Private Delegate Sub PrimzahlenErstellenDelegate(ByVal Max As Integer)
    Private Delegate Sub ErgebnisSetzenDelegate(ByVal ErgebnisText As String)

    Private myPrimzahlen As List(Of Long)
    Private myPZDelegate As PrimzahlenErstellenDelegate
    Private myErgebnisSetzenDelegate As ErgebnisSetzenDelegate
    Private myAsyncOperation As AsyncOperation

    Sub New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' F�gen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        myErgebnisSetzenDelegate = New ErgebnisSetzenDelegate(AddressOf ErgebnisSetzen)
    End Sub

    Private Sub btnBerechnungStarten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBerechnungStarten.Click
        'Delegate definieren.
        myPZDelegate = New PrimzahlenErstellenDelegate(AddressOf PrimzahlenErstellen)

        'Delegate ansynchrone aufrufen.
        myPZDelegate.BeginInvoke(Integer.Parse(txtAnzahlPrimzahlen.Text), AddressOf BerechnungAbgeschlossenCallback, Nothing)
    End Sub

    Private Sub PrimzahlenErstellen(ByVal Max As Integer)

        If (Max < 3) Then Return
        myPrimzahlen = New List(Of Long)

        For z As Integer = 2 To Max
            If IstPrimzahl(myPrimzahlen, z) Then
                myPrimzahlen.Add(z)
                'Direkte Manipulation des Steuerelements ist nicht m�glich,
                'da dieser Thread nicht dem UI-Thread entspricht.
                lblH�chstePrimzahl.Invoke(myErgebnisSetzenDelegate, myPrimzahlen(myPrimzahlen.Count - 1).ToString("#,##0"))
            End If
        Next
    End Sub

    Private Function IstPrimzahl(ByVal Primzahlen As List(Of Long), ByVal Number As Long) As Boolean

        For Each locTestZahl As Long In Primzahlen
            If (Number Mod locTestZahl = 0) Then Return False
            If (locTestZahl >= Math.Sqrt(Number)) Then Exit For
        Next
        Return True
    End Function

    'Delegatroutine f�r das Aktualisieren der Benutzeroberfl�che.
    'Notwendig, weil die Aktualisierung auf dem Thread des Delegaten ausgef�hrt wird.
    Private Sub ErgebnisSetzen(ByVal ErgebnisText As String)
        lblH�chstePrimzahl.Text = ErgebnisText
    End Sub

    'Der R�ckrufroutine des Delegaten, der aufgerufen wird, wenn seine Aufgabe beendet ist.
    Private Sub BerechnungAbgeschlossenCallback(ByVal ar As System.IAsyncResult)
        lblH�chstePrimzahl.Invoke(myErgebnisSetzenDelegate, myPrimzahlen(myPrimzahlen.Count - 1).ToString("#,##0"))
        myPZDelegate.EndInvoke(ar)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class
