Public Class frmNewPattern
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
    Friend WithEvents txtSearchPattern As System.Windows.Forms.TextBox
    Friend WithEvents txtComment As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReplacePattern As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtSearchPattern = New System.Windows.Forms.TextBox
        Me.txtComment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReplacePattern = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ErrorProvider = New System.Windows.Forms.ErrorProvider
        Me.SuspendLayout()
        '
        'txtSearchPattern
        '
        Me.txtSearchPattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchPattern.Location = New System.Drawing.Point(8, 24)
        Me.txtSearchPattern.Name = "txtSearchPattern"
        Me.txtSearchPattern.Size = New System.Drawing.Size(384, 20)
        Me.txtSearchPattern.TabIndex = 1
        Me.txtSearchPattern.Text = ""
        '
        'txtComment
        '
        Me.txtComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComment.Location = New System.Drawing.Point(8, 120)
        Me.txtComment.Multiline = True
        Me.txtComment.Name = "txtComment"
        Me.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComment.Size = New System.Drawing.Size(384, 112)
        Me.txtComment.TabIndex = 5
        Me.txtComment.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Suchmuster"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(408, 24)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 24)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Speichern"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(408, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 24)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Abbrechen"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ersetzen-Muster"
        '
        'txtReplacePattern
        '
        Me.txtReplacePattern.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtReplacePattern.Location = New System.Drawing.Point(8, 72)
        Me.txtReplacePattern.Name = "txtReplacePattern"
        Me.txtReplacePattern.Size = New System.Drawing.Size(384, 20)
        Me.txtReplacePattern.TabIndex = 3
        Me.txtReplacePattern.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Kommentar"
        '
        'ErrorProvider
        '
        Me.ErrorProvider.ContainerControl = Me
        '
        'frmNewPattern
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(512, 246)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtReplacePattern)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtComment)
        Me.Controls.Add(Me.txtSearchPattern)
        Me.Name = "frmNewPattern"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Neuen Mustereintrag hinzufügen"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myCancel As Boolean

    Sub New(ByVal PatternEntry As PatternEntry)
        Me.New()
        txtComment.Text = PatternEntry.Comment
        txtSearchPattern.Text = PatternEntry.SearchPattern
        txtReplacePattern.Text = PatternEntry.ReplacePattern
    End Sub

    Function PatternEntry() As PatternEntry
        Me.ShowDialog()
        If myCancel Then
            Return Nothing
        Else
            Return New PatternEntry(txtSearchPattern.Text, txtReplacePattern.Text, txtComment.Text)
        End If
    End Function

    Public Shared Function GetPatternEntry(ByVal PatternEntry As PatternEntry) As PatternEntry

        Dim locForm As New frmNewPattern(PatternEntry)
        Return locForm.PatternEntry

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim locError As Boolean

        If txtSearchPattern.Text = "" Then
            ErrorProvider.SetError(txtSearchPattern, "Bitte geben Sie das Suchmuster ein!")
            locError = locError Or True
        Else
            ErrorProvider.SetError(txtSearchPattern, "")
        End If
        If txtComment.Text = "" Then
            ErrorProvider.SetError(txtComment, "Bitte geben Sie einen Kommentar ein!")
            locError = locError Or True
        Else
            ErrorProvider.SetError(txtSearchPattern, "")
        End If
        If locError Then
            Return
        End If

        myCancel = False
        Me.Hide()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        myCancel = True
        Me.Hide()

    End Sub
End Class
