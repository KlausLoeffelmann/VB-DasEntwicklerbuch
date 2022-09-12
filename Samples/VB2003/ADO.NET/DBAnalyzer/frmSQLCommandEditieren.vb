Public Class frmSQLCommandEditieren
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
    Friend WithEvents txtCommandString As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAbbrechen As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCommandString = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnAbbrechen = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtCommandString
        '
        Me.txtCommandString.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCommandString.Location = New System.Drawing.Point(8, 8)
        Me.txtCommandString.Multiline = True
        Me.txtCommandString.Name = "txtCommandString"
        Me.txtCommandString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCommandString.Size = New System.Drawing.Size(304, 192)
        Me.txtCommandString.TabIndex = 0
        Me.txtCommandString.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(328, 8)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(88, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'btnAbbrechen
        '
        Me.btnAbbrechen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbbrechen.Location = New System.Drawing.Point(328, 48)
        Me.btnAbbrechen.Name = "btnAbbrechen"
        Me.btnAbbrechen.Size = New System.Drawing.Size(88, 32)
        Me.btnAbbrechen.TabIndex = 3
        Me.btnAbbrechen.Text = "Abbrechen"
        '
        'frmSQLCommandEditieren
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnAbbrechen
        Me.ClientSize = New System.Drawing.Size(424, 214)
        Me.Controls.Add(Me.btnAbbrechen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtCommandString)
        Me.Name = "frmSQLCommandEditieren"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SELECT-Command editieren:"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myDialogResult As DialogResult

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles btnOK.Click
        myDialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub btnAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbbrechen.Click
        myDialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Public Function SELECTCommandEditieren(ByVal SELECTCommand As String) As String
        txtCommandString.Text = SELECTCommand
        Me.ShowDialog()
        If myDialogResult = DialogResult.OK Then
            If txtCommandString.Text = "" Then
                Return Nothing
            Else
                Return txtCommandString.Text
            End If
        Else
            Return Nothing
        End If
    End Function
End Class
