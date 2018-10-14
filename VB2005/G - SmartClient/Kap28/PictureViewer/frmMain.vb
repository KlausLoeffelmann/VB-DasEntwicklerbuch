'Wird benötigt für die Bildformate
Imports System.Drawing.Imaging
'Wird benötigt für die FileInfo
Imports System.IO

Public Class frmMain

    'Member-Array vom Typ FileInfo, das verwendet wird
    'alle Bilddateien eines Verzeichnisses einzulesen
    Private myFiles As FileInfo()
    'Zeiger auf das jeweils nächste Bild
    Private myNextFile As Integer

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
            If dr = Windows.Forms.DialogResult.Cancel Then
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
            If dr = Windows.Forms.DialogResult.Cancel Then
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
