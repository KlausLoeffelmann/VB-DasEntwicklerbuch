'Wird benötigt für die Bildformate
Imports System.Drawing.Imaging
'Wird benötigt für die FileInfo
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    'Member-Array vom Typ FileInfo, das verwendet wird
    'alle Bilddateien eines Verzeichnisses einzulesen
    Private myFiles As FileInfo()
    'Zeiger auf das jeweils nächste Bild
    Private myNextFile As Integer

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        'Application.AddMessageFilter(New NachrichtenFänger)

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
    Friend WithEvents pnlPicture As System.Windows.Forms.Panel
    Friend WithEvents picViewArea As System.Windows.Forms.PictureBox
    'btnOpenBitmap bindet jetzt den Rechts-Klick ein
    Friend WithEvents btnOpenBitmap As PictureViewer.TestButton
    Friend WithEvents btnSaveBitmap As System.Windows.Forms.Button
    Friend WithEvents btnNextBitmap As New PictureViewer.TestButton
    Friend WithEvents btnQuitProgram As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlPicture = New System.Windows.Forms.Panel
        Me.picViewArea = New System.Windows.Forms.PictureBox
        Me.btnOpenBitmap = New PictureViewer.TestButton
        Me.btnSaveBitmap = New System.Windows.Forms.Button
        Me.btnNextBitmap = New PictureViewer.TestButton
        Me.btnQuitProgram = New System.Windows.Forms.Button
        Me.pnlPicture.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlPicture
        '
        Me.pnlPicture.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPicture.AutoScroll = True
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
        Me.ClientSize = New System.Drawing.Size(608, 414)
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

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        '!!!GANZ WICHTIG BEIM ÜBERSCHREIBEN: BASIS AUFRUFEN!!!
        MyBase.OnSizeChanged(e)

        'Wenn das Formular vergrößert oder verkleinert wird,
        'ändert sich automatisch auch die Bildgröße
        AlignPicViewArea()
    End Sub

    Private Sub AlignPicViewArea()

        Dim locXPos, locYPos As Integer

        If picViewArea.Bounds.Width < pnlPicture.Bounds.Width Then
            locXPos = CInt(pnlPicture.Bounds.Width / 2 - picViewArea.Bounds.Width / 2)
        Else
            locXPos = 0
        End If

        If picViewArea.Bounds.Height < pnlPicture.Bounds.Height Then
            locYPos = CInt(pnlPicture.Bounds.Height / 2 - picViewArea.Bounds.Height / 2)
        Else
            locYPos = 0
        End If

        picViewArea.Location = New Point(locXPos, locYPos)
    End Sub

    Private Sub btnOpenBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles btnOpenBitmap.Click
        'Mit linker Maustaste: letzten Ordner anzeigen
        '(Dazu muss nichts eingestellt werden, NT-basierende Betriebssysteme
        ' machen das bei OpenFileDialog und SaveFileDialog selbständig!)
        OpenWithOpenFileDialog(False)
    End Sub

    Private Sub btnOpenBitmap_RightClick(ByVal Sender As Object, ByVal E As System.EventArgs) _
                Handles btnOpenBitmap.RightClick
        'Mit rechter Maustaste: Ordner eigene Bilder anzeigen
        OpenWithOpenFileDialog(True)
    End Sub

    Private Sub OpenWithOpenFileDialog(ByVal SetPathToMyPictures As Boolean)
        Dim locFileOpen As New OpenFileDialog

        With locFileOpen
            Dim locFilter As String = "Alle Grafikdateien (*.bmp; *.jpg; *.tif; *.gif; *.png)|"
            locFilter += "*.bmp;*.jpg;*.tif;*.gif;*.png|"
            locFilter += "Bitmapdateien (*.bmp)|*.bmp|"
            locFilter += "JPeg-Dateien (*.jpg)|*.jpg|"
            locFilter += "Tif-Dateien (*.tif)|*.tif|"
            locFilter += "Gif-Dateien (*.gif)|*.gif|"
            locFilter += "Png-Dateien (*.png)|*.png|"
            locFilter += "Alle Dateien (*.*)|*.*"
            .Filter = locFilter
            .Title = "Grafik öffnen"

            If SetPathToMyPictures Then
                'Ordner 'Eigene Bilder' vorgeben, wenn verlangt
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            End If

            Dim dr As DialogResult = .ShowDialog
            If dr = DialogResult.Cancel Then
                Exit Sub
            End If
        End With
        'Bild darstellen und Liste laden
        LoadAndShowPicture(New FileInfo(locFileOpen.FileName), False)

    End Sub

    'Versucht eine Bilddatei zu laden und darzustellen
    Private Sub LoadAndShowPicture(ByVal PictureFile As FileInfo, ByVal SuppressGettingPictures As Boolean)
        Dim test As New NativeWindow
        Dim locImage As Image
        Dim locRf As RectangleF

        'Datei öffnen und in der PictureBox darstellen
        Try
            'Versuchen, das Bild aus der Datei zu laden
            locImage = Image.FromFile(PictureFile.FullName)
        Catch ex As Exception
            'Wenn was schief geht, Meldung ausgeben...
            MessageBox.Show("Beim Öffnen des Bildes ist ein Fehler aufgetreten" + vbNewLine + _
                            "Die genaue Fehlermeldung lautete:" + vbNewLine + ex.Message, _
                            "Fehler beim Öffnen!", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '...und tschüss!
            Return
        End Try

        'Alles gut gegangen: Bildgröße in Pixeln ermitteln
        locRf = locImage.GetBounds(GraphicsUnit.Pixel)
        'Anzeigebereich (PictureBox) ist so groß wie Bild
        picViewArea.ClientSize = New Size(CInt(locRf.Width), CInt(locRf.Height))
        'Paint für das Image wird von PictureBox durchgeführt
        picViewArea.Image = locImage
        'Dateiname in die Titelzeile
        Me.Text = "PictureViewer - " + PictureFile.FullName
        'Bildbereich poistionieren
        AlignPicViewArea()
        'Eine Liste mit allen Dateinamen anfordern für die Funktion
        'der Schaltfläche 'Nächste Grafik'
        If Not SuppressGettingPictures Then
            myFiles = GetAllPicturesInDirFromFilename(PictureFile)
        End If

    End Sub

    Private Function GetAllPicturesInDirFromFilename(ByVal Filename As FileInfo) As FileInfo()

        'Verzeichnis, in dem sich die Bilder befanden
        Dim locDir As DirectoryInfo = Filename.Directory
        Dim locArrayList As New ArrayList
        myNextFile = 0

        'Besten Beispiel für das Zusammenspiel von FileInfo,
        'ArrayList und Array. GetFiles ermittelt alle Dateien
        'in einem Verzeichnis, für die das Suchmuster passte
        locArrayList.AddRange(locDir.GetFiles("*.bmp"))
        locArrayList.AddRange(locDir.GetFiles("*.jpg"))
        locArrayList.AddRange(locDir.GetFiles("*.tif"))
        locArrayList.AddRange(locDir.GetFiles("*.gif"))
        locArrayList.AddRange(locDir.GetFiles("*.png"))
        Return DirectCast(locArrayList.ToArray(GetType(FileInfo)), FileInfo())

    End Function

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles btnQuitProgram.Click
        'Weg mit der Form; ist an ApplicationContext gebunden,
        'damit endet das Programm
        Me.Dispose()
    End Sub

    Private Sub btnSaveBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles btnSaveBitmap.Click
        Dim locFileSave As New SaveFileDialog
        Dim locImgFormat As ImageFormat

        With locFileSave
            Dim locFilter As String = "Bitmapdateien (*.bmp)|*.bmp|"
            locFilter += "JPeg-Dateien (*.jpg)|*.jpg|"
            locFilter += "Tif-Dateien (*.tif)|*.tif|"
            locFilter += "Gif-Dateien (*.gif)|*.gif|"
            locFilter += "Png-Dateien (*.png)|*.png|"
            locFilter += "Alle Dateien (*.*)|*.*"
            .Filter = locFilter
            .Title = "Grafik speichern unter"
            .OverwritePrompt = True

            Dim dr As DialogResult = .ShowDialog
            If dr = DialogResult.Cancel Then
                Exit Sub
            End If

            'Richtiges Dateiformat anhand der Extension herausfinden
            Dim locExt As String = New FileInfo(.FileName).Extension

            Select Case locExt.ToUpper

                Case ".BMP" : locImgFormat = ImageFormat.Bmp
                Case ".TIF" : locImgFormat = ImageFormat.Tiff
                Case ".JPG" : locImgFormat = ImageFormat.Jpeg
                Case ".GIF" : locImgFormat = ImageFormat.Gif
                Case ".PNG" : locImgFormat = ImageFormat.Png

                Case Else
                    MessageBox.Show("Leider wird das durch die Dateinamen-Extension" + vbNewLine + _
                                "angegebene Bildformat nicht unterstützt!", _
                                "Nicht unterstütztes Bildformat", MessageBoxButtons.OK, _
                                 MessageBoxIcon.Exclamation)
                    Return
            End Select

        End With

        'Datei speichern
        Try
            'Versuchen, das Bild in die Datei zu speichern
            picViewArea.Image.Save(locFileSave.FileName)
        Catch ex As Exception
            'Wenn 'was schief geht, Meldung ausgeben
            MessageBox.Show("Beim Speichern des Bildes ist ein Fehler aufgetreten" + vbNewLine + _
                            "Die genaue Fehlermeldung lautete:" + vbNewLine + ex.Message, _
                            "Fehler beim Öffnen!", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Nächstes Bild in der Liste zeigen
    Private Sub btnNextBitmap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextBitmap.Click

        If myFiles Is Nothing Then
            Return
        End If
        'Letzter Dateinamen in Liste erreicht?
        If myNextFile > myFiles.Length - 1 Then
            myNextFile = 0
        End If
        'Bild laden und darstellen, aber verhindern, dass neue
        'Bildliste eingelesen wird!
        LoadAndShowPicture(myFiles(myNextFile), True)
        myNextFile += 1
    End Sub

    'Falls mit rechter Maustaste geklickt wurde, dann
    'am Anfang der Liste neu beginnen
    Private Sub btnNextBitmap_RightClick(ByVal Sender As Object, ByVal E As System.EventArgs) Handles btnNextBitmap.RightClick
        myNextFile = 0
        btnNextBitmap_Click(Sender, E)
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
