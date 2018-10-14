<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.btnAddTitle = New System.Windows.Forms.Button
        Me.lvwBookItems = New System.Windows.Forms.ListView
        Me.chTitel = New System.Windows.Forms.ColumnHeader("")
        Me.chAuthor = New System.Windows.Forms.ColumnHeader("")
        Me.chEditor = New System.Windows.Forms.ColumnHeader("")
        Me.chYearPublished = New System.Windows.Forms.ColumnHeader("")
        Me.chYearPublishedRoman = New System.Windows.Forms.ColumnHeader("")
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtBookTitel = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNotes = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtArabicYear = New System.Windows.Forms.TextBox
        Me.txtRomanYear = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtEditor = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnEditTitle = New System.Windows.Forms.Button
        Me.btnSaveTitles = New System.Windows.Forms.Button
        Me.btnLoadTitles = New System.Windows.Forms.Button
        Me.txtAuthor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Location = New System.Drawing.Point(406, 359)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(221, 33)
        Me.btnQuitProgram.TabIndex = 0
        Me.btnQuitProgram.Text = "Programm beenden"
        '
        'btnAddTitle
        '
        Me.btnAddTitle.Location = New System.Drawing.Point(406, 180)
        Me.btnAddTitle.Name = "btnAddTitle"
        Me.btnAddTitle.Size = New System.Drawing.Size(221, 36)
        Me.btnAddTitle.TabIndex = 2
        Me.btnAddTitle.Text = "Titel hinzufügen"
        '
        'lvwBookItems
        '
        Me.lvwBookItems.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chTitel, Me.chAuthor, Me.chEditor, Me.chYearPublished, Me.chYearPublishedRoman})
        Me.lvwBookItems.FullRowSelect = True
        Me.lvwBookItems.GridLines = True
        Me.lvwBookItems.Location = New System.Drawing.Point(10, 12)
        Me.lvwBookItems.Name = "lvwBookItems"
        Me.lvwBookItems.Size = New System.Drawing.Size(617, 152)
        Me.lvwBookItems.TabIndex = 3
        Me.lvwBookItems.View = System.Windows.Forms.View.Details
        '
        'chTitel
        '
        Me.chTitel.Text = "Buchtitel"
        Me.chTitel.Width = 175
        '
        'chAuthor
        '
        Me.chAuthor.Text = "Autor"
        Me.chAuthor.Width = 120
        '
        'chEditor
        '
        Me.chEditor.Text = "Bearbeiter"
        Me.chEditor.Width = 149
        '
        'chYearPublished
        '
        Me.chYearPublished.Text = "veröffentlicht"
        Me.chYearPublished.Width = 76
        '
        'chYearPublishedRoman
        '
        Me.chYearPublishedRoman.Text = "röm. Darstellung"
        Me.chYearPublishedRoman.Width = 92
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtAuthor)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtBookTitel)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNotes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtArabicYear)
        Me.GroupBox1.Controls.Add(Me.txtRomanYear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtEditor)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 175)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(380, 260)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Titelinfo:"
        '
        'txtBookTitel
        '
        Me.txtBookTitel.BackColor = System.Drawing.SystemColors.Control
        Me.txtBookTitel.Location = New System.Drawing.Point(101, 41)
        Me.txtBookTitel.Name = "txtBookTitel"
        Me.txtBookTitel.Size = New System.Drawing.Size(258, 20)
        Me.txtBookTitel.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Buchtitel:"
        '
        'txtNotes
        '
        Me.txtNotes.BackColor = System.Drawing.SystemColors.Control
        Me.txtNotes.Location = New System.Drawing.Point(101, 142)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(273, 102)
        Me.txtNotes.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Anmerkungen:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(207, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Arabisch:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(100, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Römisch:"
        '
        'txtArabicYear
        '
        Me.txtArabicYear.BackColor = System.Drawing.SystemColors.Control
        Me.txtArabicYear.HideSelection = False
        Me.txtArabicYear.Location = New System.Drawing.Point(208, 116)
        Me.txtArabicYear.Name = "txtArabicYear"
        Me.txtArabicYear.Size = New System.Drawing.Size(88, 20)
        Me.txtArabicYear.TabIndex = 19
        '
        'txtRomanYear
        '
        Me.txtRomanYear.BackColor = System.Drawing.SystemColors.Control
        Me.txtRomanYear.HideSelection = False
        Me.txtRomanYear.Location = New System.Drawing.Point(101, 116)
        Me.txtRomanYear.Name = "txtRomanYear"
        Me.txtRomanYear.Size = New System.Drawing.Size(88, 20)
        Me.txtRomanYear.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Jahr:"
        '
        'txtEditor
        '
        Me.txtEditor.BackColor = System.Drawing.SystemColors.Control
        Me.txtEditor.Location = New System.Drawing.Point(101, 67)
        Me.txtEditor.Name = "txtEditor"
        Me.txtEditor.Size = New System.Drawing.Size(258, 20)
        Me.txtEditor.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Bearbeiter:"
        '
        'btnEditTitle
        '
        Me.btnEditTitle.Location = New System.Drawing.Point(406, 222)
        Me.btnEditTitle.Name = "btnEditTitle"
        Me.btnEditTitle.Size = New System.Drawing.Size(221, 36)
        Me.btnEditTitle.TabIndex = 5
        Me.btnEditTitle.Text = "Titel editieren"
        '
        'btnSaveTitles
        '
        Me.btnSaveTitles.Location = New System.Drawing.Point(406, 264)
        Me.btnSaveTitles.Name = "btnSaveTitles"
        Me.btnSaveTitles.Size = New System.Drawing.Size(221, 36)
        Me.btnSaveTitles.TabIndex = 6
        Me.btnSaveTitles.Text = "Alle Titel speichern"
        '
        'btnLoadTitles
        '
        Me.btnLoadTitles.Location = New System.Drawing.Point(406, 306)
        Me.btnLoadTitles.Name = "btnLoadTitles"
        Me.btnLoadTitles.Size = New System.Drawing.Size(221, 36)
        Me.btnLoadTitles.TabIndex = 7
        Me.btnLoadTitles.Text = "Titel laden"
        '
        'txtAuthor
        '
        Me.txtAuthor.BackColor = System.Drawing.SystemColors.Control
        Me.txtAuthor.Location = New System.Drawing.Point(101, 14)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(258, 20)
        Me.txtAuthor.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Autor:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 459)
        Me.Controls.Add(Me.btnLoadTitles)
        Me.Controls.Add(Me.btnSaveTitles)
        Me.Controls.Add(Me.btnEditTitle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvwBookItems)
        Me.Controls.Add(Me.btnAddTitle)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Name = "frmMain"
        Me.Text = "Datenerfassung antike Bücher"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    Friend WithEvents btnAddTitle As System.Windows.Forms.Button
    Friend WithEvents lvwBookItems As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEditTitle As System.Windows.Forms.Button
    Friend WithEvents btnSaveTitles As System.Windows.Forms.Button
    Friend WithEvents btnLoadTitles As System.Windows.Forms.Button
    Friend WithEvents chTitel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chEditor As System.Windows.Forms.ColumnHeader
    Friend WithEvents chYearPublished As System.Windows.Forms.ColumnHeader
    Friend WithEvents chYearPublishedRoman As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBookTitel As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtArabicYear As System.Windows.Forms.TextBox
    Friend WithEvents txtRomanYear As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEditor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chAuthor As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtAuthor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
