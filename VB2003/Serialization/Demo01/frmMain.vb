Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f¸r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf¸gen

    End Sub

    ' Die Form ¸berschreibt den Lˆschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F¸r Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist f¸r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents Nachname As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSerialisieren As System.Windows.Forms.Button
    Friend WithEvents btnDeserialisieren As System.Windows.Forms.Button
    Friend WithEvents txtVorname As System.Windows.Forms.TextBox
    Friend WithEvents txtStraﬂe As System.Windows.Forms.TextBox
    Friend WithEvents txtPLZOrt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNachname As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtErstelltAm As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtErstelltVon As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVorname = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStraﬂe = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPLZOrt = New System.Windows.Forms.TextBox
        Me.btnSerialisieren = New System.Windows.Forms.Button
        Me.btnDeserialisieren = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNachname = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtErstelltAm = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtErstelltVon = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Vorname: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVorname
        '
        Me.txtVorname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVorname.Location = New System.Drawing.Point(152, 48)
        Me.txtVorname.Name = "txtVorname"
        Me.txtVorname.Size = New System.Drawing.Size(256, 20)
        Me.txtVorname.TabIndex = 3
        Me.txtVorname.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Straﬂe: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtStraﬂe
        '
        Me.txtStraﬂe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStraﬂe.Location = New System.Drawing.Point(152, 80)
        Me.txtStraﬂe.Name = "txtStraﬂe"
        Me.txtStraﬂe.Size = New System.Drawing.Size(256, 20)
        Me.txtStraﬂe.TabIndex = 5
        Me.txtStraﬂe.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "PLZ/Ort: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPLZOrt
        '
        Me.txtPLZOrt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPLZOrt.Location = New System.Drawing.Point(152, 112)
        Me.txtPLZOrt.Name = "txtPLZOrt"
        Me.txtPLZOrt.Size = New System.Drawing.Size(256, 20)
        Me.txtPLZOrt.TabIndex = 7
        Me.txtPLZOrt.Text = ""
        '
        'btnSerialisieren
        '
        Me.btnSerialisieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSerialisieren.Location = New System.Drawing.Point(432, 16)
        Me.btnSerialisieren.Name = "btnSerialisieren"
        Me.btnSerialisieren.Size = New System.Drawing.Size(128, 32)
        Me.btnSerialisieren.TabIndex = 8
        Me.btnSerialisieren.Text = "Serialisieren"
        '
        'btnDeserialisieren
        '
        Me.btnDeserialisieren.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeserialisieren.Location = New System.Drawing.Point(432, 56)
        Me.btnDeserialisieren.Name = "btnDeserialisieren"
        Me.btnDeserialisieren.Size = New System.Drawing.Size(128, 32)
        Me.btnDeserialisieren.TabIndex = 9
        Me.btnDeserialisieren.Text = "Deserialisieren"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Name: "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNachname
        '
        Me.txtNachname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNachname.Location = New System.Drawing.Point(152, 16)
        Me.txtNachname.Name = "txtNachname"
        Me.txtNachname.Size = New System.Drawing.Size(256, 20)
        Me.txtNachname.TabIndex = 1
        Me.txtNachname.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Erstellt am:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtErstelltAm
        '
        Me.txtErstelltAm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErstelltAm.Location = New System.Drawing.Point(152, 144)
        Me.txtErstelltAm.Name = "txtErstelltAm"
        Me.txtErstelltAm.ReadOnly = True
        Me.txtErstelltAm.Size = New System.Drawing.Size(256, 20)
        Me.txtErstelltAm.TabIndex = 12
        Me.txtErstelltAm.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 176)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Erstellt von:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtErstelltVon
        '
        Me.txtErstelltVon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtErstelltVon.Location = New System.Drawing.Point(152, 176)
        Me.txtErstelltVon.Name = "txtErstelltVon"
        Me.txtErstelltVon.ReadOnly = True
        Me.txtErstelltVon.Size = New System.Drawing.Size(256, 20)
        Me.txtErstelltVon.TabIndex = 14
        Me.txtErstelltVon.Text = ""
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 214)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtErstelltVon)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtErstelltAm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNachname)
        Me.Controls.Add(Me.btnDeserialisieren)
        Me.Controls.Add(Me.btnSerialisieren)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPLZOrt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStraﬂe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtVorname)
        Me.Name = "frmMain"
        Me.Text = "Serialisierungs-Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnSerialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerialisieren.Click
        Dim locAdresse As New Adresse(txtVorname.Text, _
                                      txtNachname.Text, _
                                      txtStraﬂe.Text, _
                                      txtPLZOrt.Text)
        'Einen "unmˆglichen" Dateinamen verwenden, damit, wie es der Zufall will,
        'nicht eine andere wichtige Datei gleichen Namens ¸berschrieben wird.
        Adresse.SerializeToFile(locAdresse, "C:\serializedemo_f4e3w21.txt")

        'Info ¸ber den Datensatz anzeigen
        txtErstelltAm.Text = locAdresse.ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
        txtErstelltVon.Text = locAdresse.ErfasstVon
    End Sub

    Private Sub btnDeserialisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnDeserialisieren.Click
        'Adressenobjekt aus Datei deserialisieren
        Dim locAdresse As Adresse = Adresse.SerializeFromFile("C:\serializedemo_f4e3w21.txt")
        'Adressobjektdaten 
        With locAdresse
            txtVorname.Text = .Vorname
            txtNachname.Text = .Name
            txtStraﬂe.Text = .Straﬂe
            txtPLZOrt.Text = .PLZOrt
            txtErstelltAm.Text = .ErfasstAm.ToString("dd.MM.yyyy HH:mm:ss")
            txtErstelltVon.Text = .ErfasstVon
        End With
    End Sub

End Class

Public Class Adresse

    Private myName As String
    Private myVorname As String
    Private myStraﬂe As String
    Private myPLZOrt As String
    Private myErfasstAm As DateTime
    Private myErfasstVon As String

    Sub New(ByVal Vorname As String, ByVal Name As String, ByVal Straﬂe As String, ByVal PLZOrt As String)
        'Konstruktor legt alle Member-Daten ein
        myName = Name
        myVorname = Vorname
        myStraﬂe = Straﬂe
        myPLZOrt = PLZOrt
        myErfasstAm = DateTime.Now
        myErfasstVon = Environment.UserName
    End Sub

    'Alle ÷ffentlichen Felder in die Datei schreiben
    Public Shared Sub SerializeToFile(ByVal adr As Adresse, ByVal Filename As String)
        Dim locStreamWriter As New StreamWriter(Filename, False, System.Text.Encoding.Default)
        With locStreamWriter
            .WriteLine(adr.Vorname)
            .WriteLine(adr.Name)
            .WriteLine(adr.Straﬂe)
            .WriteLine(adr.PLZOrt)
            .Flush()
            .Close()
        End With
    End Sub

    'Aus der Datei lesen und daraus ein neues Adressobjekt erstellen
    Public Shared Function SerializeFromFile(ByVal Filename As String) As Adresse
        Dim locStreamReader As New StreamReader(Filename, System.Text.Encoding.Default)
        Dim locAdresse As Adresse
        With locStreamReader
            locAdresse = New Adresse(.ReadLine, .ReadLine, .ReadLine, .ReadLine)
        End With
        locStreamReader.Close()
        Return locAdresse
    End Function

    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    'Die beiden folgenden Eigenschaften haben "Nur-Lesen-Status", da auch
    'der Entwickler das Anlegen-Datum nicht manipulieren darf!
    Public ReadOnly Property ErfasstAm() As DateTime
        Get
            Return myErfasstAm
        End Get
    End Property

    Public ReadOnly Property ErfasstVon() As String
        Get
            Return myErfasstVon
        End Get
    End Property

#Region "Die anderen Eigenschaften"

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property Straﬂe() As String
        Get
            Return myStraﬂe
        End Get
        Set(ByVal Value As String)
            myStraﬂe = Value
        End Set
    End Property

    Public Property PLZOrt() As String
        Get
            Return myPLZOrt
        End Get
        Set(ByVal Value As String)
            myPLZOrt = Value
        End Set
    End Property
#End Region

End Class
