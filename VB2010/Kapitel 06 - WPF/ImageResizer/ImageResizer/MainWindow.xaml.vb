Imports System.Windows.Forms
Imports ActiveDevelop.Wpf.Imaging
Imports System.IO
Imports System.Threading.Tasks


Class MainWindow

    Private Sub MainWindow_Loaded(ByVal sender As Object,
                                  ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        'JPeg vorselektieren
        FormatComboBox.SelectedIndex = 0

        'Eigene Bilder + ImageConverter + Tagesdatum als Vorgabeverzeichnis bestimmen
        Dim myOutputFolder As String
        myOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        myOutputFolder &= "\ImageConverter\" & Now.ToString("yyyy-MM-dd")
        OutputFolderTextBox.Text = myOutputFolder
    End Sub

    Private Sub MenuItemBeenden_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub ChooseOutputFolderButton_Click(ByVal sender As System.Object,
                                            ByVal e As System.Windows.RoutedEventArgs)

        Dim folderBrowser = New FolderBrowserDialog

        'es dürfen neue Ordner angelegt werden
        folderBrowser.ShowNewFolderButton = True
        'der Titel wird festgesetzt
        folderBrowser.Description = "Zielverzeichnis wählen"

        'und der Dialog angezeigt
        Dim dr = folderBrowser.ShowDialog
        If dr = Forms.DialogResult.OK Then
            OutputFolderTextBox.Text = folderBrowser.SelectedPath
        End If
    End Sub


    'Ereignis verdrahtet mit Handles ...
    Private Sub AddImagesButton_Click(ByVal sender As System.Object,
                                      ByVal e As System.Windows.RoutedEventArgs) Handles AddImagesButton.Click

        'Wir verwenden OpenFileDialog aus Win32, weil er für WPF "gemacht" ist -
        'müssen ihn aber voll qualifizieren, weil es ihn in .Forms und .Win32 gibt.
        Dim fod = New Microsoft.Win32.OpenFileDialog
        'nur existierende Dateien und Pfade dürfen gewählt werden.
        fod.CheckPathExists = True
        fod.CheckFileExists = True
        'es dürfen mehrere Dateien ausgewählt werden
        fod.Multiselect = True
        'der Filter soll nach Bilddateitypen filtern
        fod.Filter = "JPeg-Dateien (*.jpg; *.jpeg)|*.jpg; *.jpeg" &
                    "|Bitmap-Dateien (*.bmp)|*.bmp" &
                    "|TIFF-Dateien (*.tif;*.tiff)|*.tif;*.tiff" &
                    "|PNG-Dateien (*.png)|*.png" &
                    "|Alle Dateien (*.*)|*.*"
        'nur gültige Win32 Dateinamen werden akzeptiert
        fod.ValidateNames = True
        'der Filtert steht standartmäßig auf "*.jpg"
        fod.DefaultExt = "*.jpg"

        'Den DialogResult des Dialogs speichern
        Dim dr = fod.ShowDialog
        'und auf Erfolg überprüfen
        If dr = True Then
            Array.ForEach(fod.FileNames, Sub(filename)
                                             FilenamesListBox.Items.Add(filename)
                                         End Sub)
        End If
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        'Das Vorschaufenster instanzieren und anzeigen
        Dim picViewer As New BitmapViewer
        picViewer.Show()

        'neue Breite einlesen:
        Dim myReduceToX = Integer.Parse(X_ResTextBox.Text)
        'Dateityp einlesen
        Dim newExtension = DirectCast(FormatComboBox.SelectedItem, ComboBoxItem).Content.ToString

        'Zahl der Berechnungen ermitteln und der Fortschrittsanzeige zuweisen
        Me.TotalProgressBar.Maximum = FilenamesListBox.Items.Count
        'Zähler für bisher fertiggestellte Berechnungen = Fortschritt
        Dim progressCount = 0

        'Für jedes Bild ..
        For Each filenameItem As String In FilenamesListBox.Items
            'den Dateinamen anzeigen
            CurrentFileTextBlock.Text = filenameItem
            'und speichern
            Dim fileInfo As New FileInfo(filenameItem)

            'den Manager instanzieren und eine Kopie des Bildes anfertigen
            Dim currentPicture As New WriteableBitmapManager(filenameItem)
            Dim mySmallWbm = currentPicture.CreateCompatible(myReduceToX)
            'den Verkleinerungsfaktor errechnen
            Dim pixelFakt As Double = currentPicture.WriteableBitmap.PixelWidth / myReduceToX

            'Stoppuhr anschmeißen
            Dim sw = Stopwatch.StartNew
            'Das Bild verkleinern
            For y = 0 To mySmallWbm.WriteableBitmap.PixelHeight - 1
                For x = 0 To myReduceToX - 1
                    mySmallWbm.SetPixel(x, y,
                       currentPicture.GetPixel(CInt(Math.Truncate(pixelFakt * x)),
                                                CInt(Math.Truncate(pixelFakt * y))))
                Next
            Next

            'und aktualisieren
            mySmallWbm.UpdateBitmap()

            'Stoppuhr stoppen
            sw.Stop()

            'das verkleinerte Bild anzeigen
            picViewer.ShowPicture(mySmallWbm, "Dauer der Konvertierung in ms: " & sw.ElapsedMilliseconds.ToString("#,##0.00"))

            'Böser Workaround - mehr dazu im Threading-Kapitel:
            System.Windows.Forms.Application.DoEvents()

            'Den Dateityp anpassen
            Dim newFilename = fileInfo.Name.Replace(fileInfo.Extension, newExtension)
            'den Ordner und das Postfix einbauen
            newFilename = OutputFolderTextBox.Text &
                          PostfixTextBox.Text & "\" & newFilename
            'Speichern
            mySmallWbm.SaveBitmap(newFilename)

            'und den Fortschritt anzeigen
            progressCount += 1
            TotalProgressBar.Value = progressCount

        Next

        picViewer.Close()
    End Sub
End Class
