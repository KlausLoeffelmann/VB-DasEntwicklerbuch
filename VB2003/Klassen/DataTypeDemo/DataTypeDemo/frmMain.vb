Option Explicit On 
Option Strict On

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents btnAction As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAction = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(144, 248)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(144, 32)
        Me.btnAction.TabIndex = 0
        Me.btnAction.Text = "Tu was!"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 302)
        Me.Controls.Add(Me.btnAction)
        Me.Name = "frmMain"
        Me.Text = "FastBitArray - Testcontainer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click

        Dim temp As New BitArrayEx(64)
        Dim temp2 As New BitArrayEx(128)
        temp(1) = True
        temp(3) = True
        temp(64) = True

        Debug.WriteLine(temp.ToString)

        temp2(1) = True
        temp2(3) = True
        temp2(128) = True

        temp.And(temp2)
        temp.xor(temp2)

        Debug.WriteLine(temp.ToString())
        Debug.WriteLine(temp2.ToString())

    End Sub

End Class
