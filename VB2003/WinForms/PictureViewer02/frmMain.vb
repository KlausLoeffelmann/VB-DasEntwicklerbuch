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
    'Außer manchmal... :-)
    Friend WithEvents pnlPicture As System.Windows.Forms.Panel
    Friend WithEvents picViewArea As System.Windows.Forms.PictureBox
    Friend WithEvents btnOpenBitmap As System.Windows.Forms.Button

    'Jetzt muss auch die Objektvariable nicht vom Typ der Basisklasse
    'sondern der abgeleiteten Klasse definiert werden, damit
    'das neue Ereignis sichtbar wird
    Friend WithEvents btnSaveBitmap As TestButton

    Friend WithEvents btnNextBitmap As System.Windows.Forms.Button
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlPicture = New System.Windows.Forms.Panel
        Me.picViewArea = New System.Windows.Forms.PictureBox
        Me.btnOpenBitmap = New System.Windows.Forms.Button
        Me.btnSaveBitmap = New TestButton
        Me.btnNextBitmap = New System.Windows.Forms.Button
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.pnlPicture.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPicture
        '
        Me.pnlPicture.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlPicture.Controls.Add(Me.picViewArea)
        Me.pnlPicture.Location = New System.Drawing.Point(8, 8)
        Me.pnlPicture.Name = "pnlPicture"
        Me.pnlPicture.Size = New System.Drawing.Size(448, 400)
        Me.pnlPicture.TabIndex = 0
        '
        'picViewArea
        '
        Me.picViewArea.Location = New System.Drawing.Point(0, 0)
        Me.picViewArea.Name = "picViewArea"
        Me.picViewArea.Size = New System.Drawing.Size(360, 304)
        Me.picViewArea.TabIndex = 0
        Me.picViewArea.TabStop = False
        '
        'btnOpenBitmap
        '
        Me.btnOpenBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenBitmap.Location = New System.Drawing.Point(464, 16)
        Me.btnOpenBitmap.Name = "btnOpenBitmap"
        Me.btnOpenBitmap.Size = New System.Drawing.Size(136, 32)
        Me.btnOpenBitmap.TabIndex = 1
        Me.btnOpenBitmap.Text = "Grafik öf&fnen..."
        '
        'btnSaveBitmap
        '
        Me.btnSaveBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveBitmap.Location = New System.Drawing.Point(464, 56)
        Me.btnSaveBitmap.Name = "btnSaveBitmap"
        Me.btnSaveBitmap.Size = New System.Drawing.Size(136, 32)
        Me.btnSaveBitmap.TabIndex = 2
        Me.btnSaveBitmap.Text = "Grafik &speichern unter"
        '
        'btnNextBitmap
        '
        Me.btnNextBitmap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextBitmap.Location = New System.Drawing.Point(464, 96)
        Me.btnNextBitmap.Name = "btnNextBitmap"
        Me.btnNextBitmap.Size = New System.Drawing.Size(136, 32)
        Me.btnNextBitmap.TabIndex = 3
        Me.btnNextBitmap.Text = "&Nächste Grafik"
        '
        'btnQuitProgram
        '
        Me.btnQuitProgram.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitProgram.Location = New System.Drawing.Point(464, 136)
        Me.btnQuitProgram.Name = "btnQuitProgram"
        Me.btnQuitProgram.Size = New System.Drawing.Size(136, 32)
        Me.btnQuitProgram.TabIndex = 4
        Me.btnQuitProgram.Text = "Programm be&enden"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(608, 422)
        Me.Controls.Add(Me.btnQuitProgram)
        Me.Controls.Add(Me.btnNextBitmap)
        Me.Controls.Add(Me.btnSaveBitmap)
        Me.Controls.Add(Me.btnOpenBitmap)
        Me.Controls.Add(Me.pnlPicture)
        Me.Name = "frmMain"
        Me.Text = "PictureViewer"
        Me.pnlPicture.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOpenBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles btnOpenBitmap.Click

        Dim locFileOpen As New OpenFileDialog
        Dim test As New NativeWindow

        With locFileOpen
            'Nur Formate, die vom Framework unterstützt werden!
            Dim locFilter As String = "Bitmapdateien (*.bmp)|*.bmp|"
            locFilter += "JPeg-Dateien (*.jpg)|*.jpg|"
            locFilter += "Tif-Dateien (*.tif)|*.tif|"
            locFilter += "Gif-Dateien (*.gif)|*.gif|"
            locFilter += "Png-Dateien (*.png)|*.png|"
            locFilter += "Alle Dateien (*.*)|*.*"
            .Filter = locFilter
            .Title = "Grafik öffnen"

            'Ordner Eigene Bilder vorgeben
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)

            Dim dr As DialogResult = .ShowDialog
            If dr = DialogResult.Cancel Then
                Exit Sub
            End If
        End With

        'Datei öffnen und in der PictureBox darstellen
        Try
            picViewArea.Image = Image.FromFile(locFileOpen.FileName)
        Catch ex As Exception
            MessageBox.Show("Beim Öffnen des Bildes ist ein Fehler aufgetreten" + vbNewLine + _
                            "Die genaue Fehlermeldung lautete:" + vbNewLine + ex.Message, _
                            "Fehler beim Öffnen!", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnSaveBitmap_RightClick(ByVal Sender As Object, ByVal E As System.EventArgs) Handles btnSaveBitmap.RightClick
        MessageBox.Show("Klick mit rechter Maustaste wurde durchgeführt!")
    End Sub
End Class

Public Class TestButton
    Inherits Button

    Private Const WM_RBUTTONDOWN As Integer = &H204
    Private Const WM_RBUTTONUP As Integer = &H205
    Private myDownFlag As Boolean
    Public Event RightClick(ByVal Sender As Object, ByVal E As EventArgs)

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_RBUTTONDOWN Then
            myDownFlag = True
        End If
        If m.Msg = WM_RBUTTONUP And myDownFlag Then
            myDownFlag = False
            OnRightClick(Me, EventArgs.Empty)
        End If
        MyBase.WndProc(m)
    End Sub

    Protected Overridable Sub OnRightClick(ByVal Sender As Object, ByVal e As EventArgs)
        RaiseEvent RightClick(Sender, e)
    End Sub
End Class
