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
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents txtFormular As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents btnCalculateEx As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnCalculate = New System.Windows.Forms.Button
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.txtFormular = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblResult = New System.Windows.Forms.Label
        Me.btnCalculateEx = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnCalculate
        '
        Me.btnCalculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalculate.Location = New System.Drawing.Point(344, 32)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(128, 24)
        Me.btnCalculate.TabIndex = 0
        Me.btnCalculate.Text = "Berechnen"
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitProgram.Location = New System.Drawing.Point(344, 120)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(128, 24)
        Me.btnQuitProgram.TabIndex = 1
        Me.btnQuitProgram.Text = "Programm beenden"
        '
        'txtFormular
        '
        Me.txtFormular.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFormular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormular.HideSelection = False
        Me.txtFormular.Location = New System.Drawing.Point(16, 32)
        Me.txtFormular.Multiline = True
        Me.txtFormular.Name = "txtFormular"
        Me.txtFormular.Size = New System.Drawing.Size(320, 232)
        Me.txtFormular.TabIndex = 2
        Me.txtFormular.Text = "2 ^ sin (12+2*3^1,32235)/33,21+(12+12)*2"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 11)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "&Formel:"
        '
        'lblResult
        '
        Me.lblResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(16, 280)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(320, 24)
        Me.lblResult.TabIndex = 4
        Me.lblResult.Text = "unberechnet"
        Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCalculateEx
        '
        Me.btnCalculateEx.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalculateEx.Location = New System.Drawing.Point(344, 64)
        Me.btnCalculateEx.Name = "btnCalculateEx"
        Me.btnCalculateEx.Size = New System.Drawing.Size(128, 40)
        Me.btnCalculateEx.TabIndex = 5
        Me.btnCalculateEx.Text = "Berechnen mit erweiterten Funktionen"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 318)
        Me.Controls.Add(Me.btnCalculateEx)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFormular)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Controls.Add(Me.btnCalculate)
        Me.Name = "frmMain"
        Me.Text = "Formelparser"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click

        Dim locFormPars As New ADFormularParser(txtFormular.Text)
        lblResult.Text = locFormPars.Result.ToString

    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub

    Private Sub btnCalculateEx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                Handles btnCalculateEx.Click
        Dim locFormPars As New ModifiedFormularParser(txtFormular.Text)
        lblResult.Text = locFormPars.Result.ToString
    End Sub
End Class

Public Class ModifiedFormularParser
    Inherits ADFormularParser

    Sub New(ByVal Formular As String)
        MyBase.New(Formular)
    End Sub

    Public Overrides Sub OnAddFunctions()
        'Benutzerdefinierte Funktion hinzufügen
        Functions.Add(New ADFunction("Double", AddressOf [Double], 1))
    End Sub

    Public Shared Function [Double](ByVal Args() As Double) As Double
        Return Args(0) * 2
    End Function

End Class