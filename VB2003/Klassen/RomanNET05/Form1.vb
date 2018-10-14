Public Class Form1
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtErfasser As System.Windows.Forms.TextBox
    Friend WithEvents txtRömisch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtArabisch As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDokumenttitel As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtErfasser = New System.Windows.Forms.TextBox
        Me.txtRömisch = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtArabisch = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDokumenttitel = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Erfasser:"
        '
        'txtErfasser
        '
        Me.txtErfasser.Location = New System.Drawing.Point(112, 16)
        Me.txtErfasser.Name = "txtErfasser"
        Me.txtErfasser.Size = New System.Drawing.Size(232, 20)
        Me.txtErfasser.TabIndex = 1
        Me.txtErfasser.Text = ""
        '
        'txtRömisch
        '
        Me.txtRömisch.Location = New System.Drawing.Point(112, 56)
        Me.txtRömisch.Name = "txtRömisch"
        Me.txtRömisch.Size = New System.Drawing.Size(112, 20)
        Me.txtRömisch.TabIndex = 3
        Me.txtRömisch.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Jahr:"
        '
        'txtArabisch
        '
        Me.txtArabisch.Location = New System.Drawing.Point(232, 56)
        Me.txtArabisch.Name = "txtArabisch"
        Me.txtArabisch.Size = New System.Drawing.Size(112, 20)
        Me.txtArabisch.TabIndex = 4
        Me.txtArabisch.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(112, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Römisch"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(232, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Arabisch"
        '
        'txtDokumenttitel
        '
        Me.txtDokumenttitel.Location = New System.Drawing.Point(112, 88)
        Me.txtDokumenttitel.Multiline = True
        Me.txtDokumenttitel.Name = "txtDokumenttitel"
        Me.txtDokumenttitel.Size = New System.Drawing.Size(232, 64)
        Me.txtDokumenttitel.TabIndex = 8
        Me.txtDokumenttitel.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Dokumenttitel:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(376, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(104, 24)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(376, 48)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(104, 24)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Abbrechen"
        '
        'Form1
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(488, 174)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtDokumenttitel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtArabisch)
        Me.Controls.Add(Me.txtRömisch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtErfasser)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Datenerfassung - antike Bücher"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Dim var As Decimal




    End Sub
End Class
