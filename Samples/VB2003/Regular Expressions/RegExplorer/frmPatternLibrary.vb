Imports System.IO

Public Class frmPatternLibrary
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
    Friend WithEvents lvwPatterns As System.Windows.Forms.ListView
    Friend WithEvents btnChoose As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lvwPatterns = New System.Windows.Forms.ListView
        Me.btnChoose = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDelete = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lvwPatterns
        '
        Me.lvwPatterns.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwPatterns.FullRowSelect = True
        Me.lvwPatterns.GridLines = True
        Me.lvwPatterns.Location = New System.Drawing.Point(8, 32)
        Me.lvwPatterns.Name = "lvwPatterns"
        Me.lvwPatterns.Size = New System.Drawing.Size(472, 240)
        Me.lvwPatterns.TabIndex = 0
        Me.lvwPatterns.View = System.Windows.Forms.View.Details
        '
        'btnChoose
        '
        Me.btnChoose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChoose.Location = New System.Drawing.Point(496, 32)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(88, 24)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Auswählen"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(496, 64)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(88, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Abbrechen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Gespeicherte Muster:"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(496, 112)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 24)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Löschen"
        '
        'frmPatternLibrary
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.lvwPatterns)
        Me.Name = "frmPatternLibrary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Musterbibliothek"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myCancel As Boolean

    Sub New(ByVal Patterns As ArrayList)
        Me.New()

        With lvwPatterns

            With .Columns
                .Add("Suchmuster", -2, HorizontalAlignment.Left)
                .Add("Ersetzungsmuster", -2, HorizontalAlignment.Left)
                .Add("Kommentar", -2, HorizontalAlignment.Left)
            End With

            With .Items
                For Each locPI As PatternEntry In Patterns
                    If Not (locPI Is Nothing) Then
                        Dim locItem As New ListViewItem
                        locItem.Tag = locPI
                        locItem.Text = locPI.SearchPattern
                        locItem.SubItems.Add(locPI.ReplacePattern)
                        locItem.SubItems.Add(locPI.Comment)
                        .Add(locItem)
                    End If
                Next
            End With
        End With

    End Sub

    Function PatternEntry() As PatternEntry
        Me.ShowDialog()
        If myCancel Then
            Me.Dispose()
            Return Nothing
        Else
            Me.Dispose()
            Return DirectCast(lvwPatterns.SelectedItems(0).Tag, PatternEntry)
        End If
    End Function

    Public Shared Function GetPatternEntry(ByVal Patterns As ArrayList) As PatternEntry

        Dim locForm As New frmPatternLibrary(Patterns)
        Return locForm.PatternEntry

    End Function

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If lvwPatterns.SelectedItems.Count = 0 Then
            MessageBox.Show("Bitte wählen Sie einen Eintrag aus", _
                            "Fehlende Auswahl")
            Return
        End If
        myCancel = False
        Me.Hide()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myCancel = True
        Me.Hide()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        If lvwPatterns.SelectedItems.Count > 0 Then
            Dim locDR As DialogResult = MessageBox.Show( _
                "Sind Sie sicher, dass Sie den Eintrag löschen wollen?", _
                "Eintrag löschen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If locDR = DialogResult.Yes Then
                lvwPatterns.SelectedItems(0).Remove()
            End If

            'Geänderte Liste abspeichern
            Dim locArray As New ArrayList
            For Each locLit As ListViewItem In lvwPatterns.Items
                locArray.Add(locLit.Tag)
            Next
            ADSoapSerializer.SerializeToFile(New FileInfo(( _
                                Application.StartupPath + "\Library.RegEx")), _
                                locArray)
        End If

    End Sub
End Class
