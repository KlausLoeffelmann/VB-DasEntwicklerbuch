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
    Friend WithEvents lvwAdressen As System.Windows.Forms.ListView
    Friend WithEvents btnNewAddress As System.Windows.Forms.Button
    Friend WithEvents btnDeleteAddress As System.Windows.Forms.Button
    Friend WithEvents btnEditAddress As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnNewAddress = New System.Windows.Forms.Button
        Me.btnDeleteAddress = New System.Windows.Forms.Button
        Me.btnEditAddress = New System.Windows.Forms.Button
        Me.lvwAdressen = New System.Windows.Forms.ListView
        Me.SuspendLayout()
        '
        'btnNewAddress
        '
        Me.btnNewAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewAddress.Location = New System.Drawing.Point(488, 16)
        Me.btnNewAddress.Name = "btnNewAddress"
        Me.btnNewAddress.Size = New System.Drawing.Size(104, 32)
        Me.btnNewAddress.TabIndex = 1
        Me.btnNewAddress.Text = "Neue Adresse"
        '
        'btnDeleteAddress
        '
        Me.btnDeleteAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteAddress.Location = New System.Drawing.Point(488, 96)
        Me.btnDeleteAddress.Name = "btnDeleteAddress"
        Me.btnDeleteAddress.Size = New System.Drawing.Size(104, 32)
        Me.btnDeleteAddress.TabIndex = 2
        Me.btnDeleteAddress.Text = "Adresse löschen"
        '
        'btnEditAddress
        '
        Me.btnEditAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditAddress.Location = New System.Drawing.Point(488, 56)
        Me.btnEditAddress.Name = "btnEditAddress"
        Me.btnEditAddress.Size = New System.Drawing.Size(104, 32)
        Me.btnEditAddress.TabIndex = 3
        Me.btnEditAddress.Text = "Adresse bearbeiten"
        '
        'lvwAdressen
        '
        Me.lvwAdressen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwAdressen.FullRowSelect = True
        Me.lvwAdressen.GridLines = True
        Me.lvwAdressen.Location = New System.Drawing.Point(8, 16)
        Me.lvwAdressen.Name = "lvwAdressen"
        Me.lvwAdressen.Size = New System.Drawing.Size(464, 336)
        Me.lvwAdressen.TabIndex = 4
        Me.lvwAdressen.View = System.Windows.Forms.View.Details
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 374)
        Me.Controls.Add(Me.lvwAdressen)
        Me.Controls.Add(Me.btnEditAddress)
        Me.Controls.Add(Me.btnDeleteAddress)
        Me.Controls.Add(Me.btnNewAddress)
        Me.Name = "frmMain"
        Me.Text = "!Adresso - die bärenstarke Adressverwaltung ;-)"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Wird aufgerufen, wenn der Dialog geladen wird. Die einzelnen
    'Adressen werden in einer ListView gepspeichert, die
    'in die Detail-Ansicht geschaltet ist und damit als Tabelle
    'fungiert.
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        lvwAdressen.Columns.Add("Matchcode", -2, HorizontalAlignment.Left)
        lvwAdressen.Columns.Add("Name", -2, HorizontalAlignment.Left)
        lvwAdressen.Columns.Add("Vorname", -2, HorizontalAlignment.Left)
        lvwAdressen.Columns.Add("Straße", -2, HorizontalAlignment.Left)
        lvwAdressen.Columns.Add("PLZ", -2, HorizontalAlignment.Left)
        lvwAdressen.Columns.Add("Ort", -2, HorizontalAlignment.Left)
        'Das eigentliche Füllen der Adressen in die Liste
        'übernimmt die Adressen-Klasse selbst, der die 
        'ListView-Instanzt übergeben wird!
        AdrMain.Adressen.FillListView(lvwAdressen)
    End Sub

    'Wird überschrieben, um die Spaltenbreiten der ListView anzupassen
    Protected Overrides Sub OnLayout(ByVal levent As System.Windows.Forms.LayoutEventArgs)
        For Each locCol As ColumnHeader In lvwAdressen.Columns
            locCol.Width = -2
        Next
        MyBase.OnLayout(levent)
    End Sub

    'Event-Handler für die Schaltfläche Neue Adresse
    Private Sub btnNewAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                    Handles btnNewAddress.Click
        'Formularinstanz erstellen
        Dim locfrmNewEditAddress As New frmNewEditAddress
        'Formular darstellen und Adresse "holen" mit [New].
        'Die eckigen Klammern dienen nur der Vermeidung von
        'Problemen mit der Konstruktur-Anweisung New
        Dim locAdresse As Adresse = locfrmNewEditAddress.[New]
        If Not (locAdresse Is Nothing) Then
            'Matchcode hinzudichten
            locAdresse.Matchcode = Adresse.GenMatchcode(locAdresse.Name, _
                                                      locAdresse.Vorname, _
                                                      AdrMain.Adressen.ID)
            AdrMain.Adressen.Add(locAdresse, locAdresse.Matchcode)
            AdrMain.Adressen.FillListView(lvwAdressen)
        End If

    End Sub

    'Event-Handler für die Schaltfläche Adresse bearbeiten
    Private Sub btnEditAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles btnEditAddress.Click

        'Für das Editieren wird der gleiche Dialog verwendet,
        'wie beim Anlegen einer neuen Adresse - es wird nur eine
        'andere Funktion für die Darstellung des Dialogs
        'und das Bearbeiten der Adresse verwendet.
        Dim locfrmNewEditAddress As New frmNewEditAddress
        Dim locAdresse As Adresse
        Dim locMatchcode As String

        'Nur Bearbeiten, wenn ein Eintrag der Liste ausgewählt ist
        If lvwAdressen.SelectedIndices.Count = 1 Then
            'Der Matchcode ist in der Tag-Eigenschaft der Liste gespeichert,
            'und dank KeyedCollection können wir direkt über den Matchcode
            'auf die Liste zugreifen
            locMatchcode = lvwAdressen.SelectedItems(0).Tag.ToString
            locAdresse = AdrMain.Adressen(locMatchcode)
            locAdresse = locfrmNewEditAddress.Edit(locAdresse)
            If Not (locAdresse Is Nothing) Then
                'Bearbeitete Adresse gegen die alte austauschen
                locAdresse.Matchcode = locMatchcode
                AdrMain.Adressen(locMatchcode) = locAdresse
                'Liste neu aufbauen
                AdrMain.Adressen.FillListView(lvwAdressen)
            End If
        End If
    End Sub

    'Event-Handler für Adresse löschen
    Private Sub btnDeleteAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnDeleteAddress.Click
        Dim locfrmNewEditAddress As New frmNewEditAddress
        Dim locMatchcode As String

        'Nur löschen, wenn Eintrag ausgewählt
        If lvwAdressen.SelectedIndices.Count = 1 Then
            locMatchcode = lvwAdressen.SelectedItems(0).Tag.ToString
            lvwAdressen.Items.RemoveAt(lvwAdressen.SelectedIndices(0))
            AdrMain.Adressen.RemoveByKey(locMatchcode)
        End If
    End Sub
End Class
