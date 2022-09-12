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
    Friend WithEvents AdComboListBox1 As ActiveDev.ADComboListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnMitDatenFüllen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.AdComboListBox1 = New ActiveDev.ADComboListBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnMitDatenFüllen = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'AdComboListBox1
        '
        Me.AdComboListBox1.Location = New System.Drawing.Point(16, 24)
        Me.AdComboListBox1.Name = "AdComboListBox1"
        Me.AdComboListBox1.Size = New System.Drawing.Size(264, 224)
        Me.AdComboListBox1.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(296, 16)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(120, 32)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'btnMitDatenFüllen
        '
        Me.btnMitDatenFüllen.Location = New System.Drawing.Point(296, 56)
        Me.btnMitDatenFüllen.Name = "btnMitDatenFüllen"
        Me.btnMitDatenFüllen.Size = New System.Drawing.Size(120, 32)
        Me.btnMitDatenFüllen.TabIndex = 2
        Me.btnMitDatenFüllen.Text = "ComboListBox mit Daten füllen"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ADComboListBox"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 262)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnMitDatenFüllen)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.AdComboListBox1)
        Me.Name = "Form1"
        Me.Text = "ADComboListBox-Test"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnMitDatenFüllen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMitDatenFüllen.Click
        With AdComboListBox1
            .Items.Add(New KurzAdresse(122, "Mayer", "Franz"))
            .Items.Add(New KurzAdresse(121, "Meier", "Heinz"))
            .Items.Add(New KurzAdresse(125, "Meier", "Franz"))
            .Items.Add(New KurzAdresse(122, "Löffler", "Heiner"))
            .Items.Add(New KurzAdresse(121, "Loffler", "Marianne"))
            .Items.Add(New KurzAdresse(125, "Löffelmann", "Klaus"))
            .Items.Add(New KurzAdresse(125, "Lörwald", "Uta"))
        End With
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Dispose()
    End Sub
End Class

Public Class KurzAdresse

    Private myNachname As String
    Private myVorname As String
    Private myID As Integer

    Sub New(ByVal ID As Integer, ByVal Nachname As String, ByVal Vorname As String)
        myID = ID
        myNachname = Nachname
        myVorname = Vorname
    End Sub

    Public Property Nachname() As String
        Get
            Return myNachname
        End Get
        Set(ByVal Value As String)
            myNachname = Value
        End Set
    End Property

    Public Property Vorname() As String
        Get
            Return myVorname
        End Get
        Set(ByVal Value As String)
            myVorname = Value
        End Set
    End Property

    Public Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Nachname + ", " + Vorname + " : " + myID.ToString
    End Function

End Class
