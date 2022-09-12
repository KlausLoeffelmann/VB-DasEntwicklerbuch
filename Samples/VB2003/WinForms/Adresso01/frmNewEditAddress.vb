Public Class frmNewEditAddress
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
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents txtOrt As System.Windows.Forms.TextBox
    Friend WithEvents txtPLZ As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtStraße As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtVorname = New System.Windows.Forms.TextBox
        Me.txtOrt = New System.Windows.Forms.TextBox
        Me.txtPLZ = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtStraße = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(320, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 32)
        Me.btnOK.TabIndex = 10
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(320, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 32)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Abbrechen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vorname:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(120, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(176, 20)
        Me.txtName.TabIndex = 1
        Me.txtName.Text = ""
        '
        'txtVorname
        '
        Me.txtVorname.Location = New System.Drawing.Point(120, 56)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(176, 20)
        Me.txtVorname.TabIndex = 3
        Me.txtVorname.Text = ""
        '
        'txtOrt
        '
        Me.txtOrt.Location = New System.Drawing.Point(120, 152)
        Me.txtOrt.Name = "txtOrt"
        Me.txtOrt.Size = New System.Drawing.Size(176, 20)
        Me.txtOrt.TabIndex = 9
        Me.txtOrt.Text = ""
        '
        'txtPLZ
        '
        Me.txtPLZ.Location = New System.Drawing.Point(120, 120)
        Me.txtPLZ.Name = "txtPLZ"
        Me.txtPLZ.Size = New System.Drawing.Size(176, 20)
        Me.txtPLZ.TabIndex = 7
        Me.txtPLZ.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Ort: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Postleitzahl:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStraße
        '
        Me.txtStraße.Location = New System.Drawing.Point(120, 88)
        Me.txtStraße.Name = "txtStraße"
        Me.txtStraße.Size = New System.Drawing.Size(176, 20)
        Me.txtStraße.TabIndex = 5
        Me.txtStraße.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Straße:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmNewEditAddress
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 208)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtStraße)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtOrt)
        Me.Controls.Add(Me.txtPLZ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtVorname)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmNewEditAddress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmNewEditAddress"
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Öffnetliche Funktion, die den Dialog für
    'das Editieren der Adresse vorbereitet.
    Public Function Edit(ByVal Adr As Adresse) As Adresse
        'Formulartitel anpassen
        Me.Text = "Adresse bearbeiten"
        'übegebene Adresse in die TextBox-Komponente schreiben
        txtName.Text = Adr.Name
        txtVorname.Text = Adr.Vorname
        txtStraße.Text = Adr.Straße
        txtPLZ.Text = Adr.PLZ
        txtOrt.Text = Adr.Ort
        'Dialog Modal darstellen. Damit wird eine eigene Ereigniswarteschlange eingerichtet
        'und die Ausführung wartet an dieser Stelle, bis der Dialog wieder verschwindet.
        'Andere Funktionen der Formular-Klasse können natürlich in dieser Zeit noch
        'ausgeführt werden (wie beispielsweise die Funktionen, die die Click-Ereignisse auswerten).
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.Cancel Then
            'Abbrechen wurde geklickt --> Dialog abbrechen
            Return Nothing
        Else
            'Sonst Adresse an die aufrufende Instanz zurückliefern
            Return GetDataFromFields()
        End If

    End Function

    'Es gilt prinzipiell das gleiche, das zu Edit gesagt wurde.
    Public Function [New]() As Adresse
        Me.Text = "Neue Adresse erfassen"
        Me.ShowDialog()
        If Me.DialogResult = DialogResult.Cancel Then
            Return Nothing
        Else
            Return GetDataFromFields()
        End If
    End Function

    'Generiert ein Adresse-Objekt aus den Textfeldern
    Public Function GetDataFromFields() As Adresse

        'Die eingegebenen Daten befinden sich in den Text-Eigenschaften
        'der TextBox-Komponenten des Formulars
        Dim locAdr As New Adresse(txtName.Text, txtVorname.Text, txtStraße.Text, _
                                  txtPLZ.Text, txtOrt.Text)
        Return locAdr

    End Function

    'Event-Handler für OK
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                Handles btnOK.Click
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    'Event-Handler für Abbrechen
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub
End Class
