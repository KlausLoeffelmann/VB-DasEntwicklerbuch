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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AdComboBox1 As ActiveDev.ADComboBox
    Friend WithEvents btnMitDatenFüllen As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnMitDatenFüllen = New System.Windows.Forms.Button
        Me.AdComboBox1 = New ActiveDev.ADComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMitDatenFüllen)
        Me.GroupBox1.Controls.Add(Me.AdComboBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 128)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Werteauswahl mit ADComboBox"
        '
        'btnMitDatenFüllen
        '
        Me.btnMitDatenFüllen.Location = New System.Drawing.Point(28, 72)
        Me.btnMitDatenFüllen.Name = "btnMitDatenFüllen"
        Me.btnMitDatenFüllen.Size = New System.Drawing.Size(272, 24)
        Me.btnMitDatenFüllen.TabIndex = 3
        Me.btnMitDatenFüllen.Text = "ComboBox mit Daten füllen"
        '
        'AdComboBox1
        '
        Me.AdComboBox1.Location = New System.Drawing.Point(28, 40)
        Me.AdComboBox1.Name = "AdComboBox1"
        Me.AdComboBox1.Size = New System.Drawing.Size(272, 21)
        Me.AdComboBox1.TabIndex = 2
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(360, 32)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(112, 32)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(488, 190)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "ADComboBox Test"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnMitDatenFüllen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMitDatenFüllen.Click
        With AdComboBox1
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
