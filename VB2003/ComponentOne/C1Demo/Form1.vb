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
    Friend WithEvents chkBold As System.Windows.Forms.CheckBox
    Friend WithEvents chkItalic As System.Windows.Forms.CheckBox
    Friend WithEvents chkUnderlined As System.Windows.Forms.CheckBox
    Friend WithEvents rtfText As System.Windows.Forms.RichTextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.rtfText = New System.Windows.Forms.RichTextBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.chkBold = New System.Windows.Forms.CheckBox
        Me.chkItalic = New System.Windows.Forms.CheckBox
        Me.chkUnderlined = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'rtfText
        '
        Me.rtfText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtfText.Location = New System.Drawing.Point(8, 8)
        Me.rtfText.Name = "rtfText"
        Me.rtfText.Size = New System.Drawing.Size(456, 360)
        Me.rtfText.TabIndex = 0
        Me.rtfText.Text = ""
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(472, 224)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Drucken..."
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.Location = New System.Drawing.Point(472, 160)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(88, 23)
        Me.btnLoad.TabIndex = 5
        Me.btnLoad.Text = "Laden..."
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(472, 192)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Speichern..."
        '
        'chkBold
        '
        Me.chkBold.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkBold.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkBold.Location = New System.Drawing.Point(472, 24)
        Me.chkBold.Name = "chkBold"
        Me.chkBold.Size = New System.Drawing.Size(88, 24)
        Me.chkBold.TabIndex = 7
        Me.chkBold.Text = "Fett"
        Me.chkBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkItalic
        '
        Me.chkItalic.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkItalic.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkItalic.Location = New System.Drawing.Point(472, 56)
        Me.chkItalic.Name = "chkItalic"
        Me.chkItalic.Size = New System.Drawing.Size(88, 24)
        Me.chkItalic.TabIndex = 8
        Me.chkItalic.Text = "Kursiv"
        Me.chkItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkUnderlined
        '
        Me.chkUnderlined.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkUnderlined.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkUnderlined.Location = New System.Drawing.Point(472, 88)
        Me.chkUnderlined.Name = "chkUnderlined"
        Me.chkUnderlined.Size = New System.Drawing.Size(88, 24)
        Me.chkUnderlined.TabIndex = 9
        Me.chkUnderlined.Text = "Unterstrichen"
        Me.chkUnderlined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(576, 374)
        Me.Controls.Add(Me.chkUnderlined)
        Me.Controls.Add(Me.chkItalic)
        Me.Controls.Add(Me.chkBold)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rtfText)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub chkBold_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                       Handles chkBold.CheckedChanged

        Dim locNewFont As Font
        Dim locUsedFont As Font

        'Aktuelle markierten Font oder den unter der Einfügemarke ermitteln
        locUsedFont = rtfText.SelectionFont

        'Fonteigenschaften sind immer ReadOnly; also neues Font-Objekt generieren
        'und dabei die vorhadene entsprechende Schrifteigenschaft "umdrehen"
        locNewFont = New Font(locUsedFont, locUsedFont.Style Xor FontStyle.Bold)

        'Neuen Font weiterverwenden
        rtfText.SelectionFont = locNewFont

        'Der Bequemlichkeithalber wieder die rtfKomponente fokussieren
        rtfText.Focus()
    End Sub

    Private Sub chkItalic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles chkItalic.CheckedChanged

        Dim locNewFont As Font
        Dim locUsedFont As Font

        locUsedFont = rtfText.SelectionFont
        locNewFont = New Font(locUsedFont, locUsedFont.Style Xor FontStyle.Italic)
        rtfText.SelectionFont = locNewFont
        rtfText.Focus()

    End Sub

    Private Sub chkUnderlined_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles chkUnderlined.CheckedChanged

        Dim locNewFont As Font
        Dim locUsedFont As Font

        locUsedFont = rtfText.SelectionFont
        locNewFont = New Font(locUsedFont, locUsedFont.Style Xor FontStyle.Underline)
        rtfText.SelectionFont = locNewFont
        rtfText.Focus()

    End Sub

    
    Private Sub rtfText_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtfText.BindingContextChanged

    End Sub

    Private Sub rtfText_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                        Handles rtfText.SelectionChanged

        Dim locFont As Font

        'Font ermitteln
        locFont = rtfText.SelectionFont

        'Prüfen, ob bestimmte Schriftart "aktiv" ist, und dementsprechend
        'die Schaltflächen setzen
        chkBold.Checked = (locFont.Style And FontStyle.Bold) = FontStyle.Bold
        chkItalic.Checked = (locFont.Style And FontStyle.Italic) = FontStyle.Italic
        chkUnderlined.Checked = (locFont.Style And FontStyle.Underline) = FontStyle.Underline

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                            Handles btnLoad.Click

        Dim locFO As New OpenFileDialog

        locFO.Filter = "RTF-Texte (*.rtf)|*.rtf|Alle Dateien (*.*)|*.*"
        locFO.AddExtension = True
        locFO.CheckFileExists = True
        locFO.CheckPathExists = True
        Dim locDR As DialogResult = locFO.ShowDialog()
        If locDR = DialogResult.Abort Then
            Exit Sub
        End If
        rtfText.LoadFile(locFO.FileName)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                Handles btnSave.Click

        Dim locFS As New SaveFileDialog

        locFS.Filter = "RTF-Texte (*.rtf)|*.rtf|Alle Dateien (*.*)|*.*"
        locFS.AddExtension = True
        locFS.CheckFileExists = True
        locFS.CheckPathExists = True
        Dim locDR As DialogResult = locFS.ShowDialog()
        If locDR = DialogResult.Abort Then
            Exit Sub
        End If
        rtfText.SaveFile(locFS.FileName)

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim locfp As frmPreview = New frmPreview(rtfText.Rtf)

        locfp.ShowPreview()

    End Sub
End Class
