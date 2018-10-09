Imports Microsoft.Win32
Imports System.Windows.Forms
Imports System.IO
Imports ActiveDevelop.Wpf.Imaging

Imports System.Threading
Imports System.Threading.Tasks

Public Class MainWindow

    Private myOutputFolder As String
    Private mySignalStop As Boolean

    Private Sub MainWindow_Loaded(ByVal sender As Object,
                                  ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        'JPeg vorselektieren
        FormatComboBox.SelectedIndex = 0

        'Eigene Bilder + ImageConverter + Tagesdatum als Vorgabeverzeichnis bestimmen.
        myOutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        myOutputFolder &= "\ImageConverter\" & Now.ToString("yyyy-MM-dd")
        OutputFolderTextBox.Text = myOutputFolder
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
                                             FilenamesListbox.Items.Add(filename)
                                         End Sub)
        End If
    End Sub

    '...und alternativ gesteuert über XAML.
    Private Sub ChooseOutputFolderButton_Click(ByVal sender As System.Object,
                                               ByVal e As System.Windows.RoutedEventArgs)

        Dim folderBrowser = New FolderBrowserDialog
        folderBrowser.ShowNewFolderButton = True
        folderBrowser.Description = "Zielverzeichnis wählen"
        Dim dr = folderBrowser.ShowDialog
        If dr = Forms.DialogResult.OK Then
            OutputFolderTextBox.Text = folderBrowser.SelectedPath
        End If
    End Sub

    Private Sub StartButton_Click(ByVal sender As System.Object,
                                  ByVal e As System.Windows.RoutedEventArgs) Handles StartButton.Click

        'Start_DedicatedTaskParallelFor()
        'ParallelForEach()
        'Return

        Dim swTotal = Stopwatch.StartNew

        If Me.StartButton.Content.ToString <> "Start!" Then
            mySignalStop = True
            Me.StartButton.Content = "Start!"
            Return
        End If

        Me.StartButton.Content = "Stop!"

        Dim picViewer As New BitmapViewer
        picViewer.Show()

        Dim myReduceToX = Integer.Parse(X_ResTextBox.Text)
        Dim newExtension = DirectCast(FormatComboBox.SelectedItem, ComboBoxItem).Content.ToString

        Me.TotalProgressBar.Maximum = FilenamesListbox.Items.Count
        Dim progressCount = 0

        For Each filenameItem As String In FilenamesListbox.Items
            CurrentFileTextBlock.Text = filenameItem
            Dim fileInfo As New FileInfo(filenameItem)
            Dim currentPicture As New WriteableBitmapManager(filenameItem)
            Dim mySmallWbm = currentPicture.CreateCompatible(myReduceToX)
            Dim pixelFakt As Double = currentPicture.WriteableBitmap.PixelWidth / myReduceToX

            Dim sw = Stopwatch.StartNew

            For y = 0 To mySmallWbm.WriteableBitmap.PixelHeight - 1
                For x = 0 To myReduceToX - 1
                    mySmallWbm.SetPixel(x, y,
                        currentPicture.GetPixel(CInt(Math.Truncate(pixelFakt * x)),
                                                CInt(Math.Truncate(pixelFakt * y))))
                Next
            Next

            mySmallWbm.UpdateBitmap()

            Dim newFilename = fileInfo.Name.Replace(fileInfo.Extension, "")

            newFilename = OutputFolderTextBox.Text &
                          "\" & newFilename & PostfixTextBox.Text & newExtension
            mySmallWbm.SaveBitmap(newFilename)
            sw.Stop()
            picViewer.ShowPicture(mySmallWbm, "Dauer der Konvertierung in ms: " & sw.ElapsedMilliseconds.ToString("#,##0.00"))
            progressCount += 1
            TotalProgressBar.Value = progressCount

            'Böser Workaround - mehr dazu im Threading-Kapitel:
            System.Windows.Forms.Application.DoEvents()

            If mySignalStop Then
                mySignalStop = False
                Exit For
            End If
        Next
        Me.StartButton.Content = "Start!"
        swTotal.Stop()
        picViewer.Close()
        CurrentFileTextBlock.Text = swTotal.ElapsedMilliseconds.ToString("#,##0") & " ms"
    End Sub

    Private Sub Start_DedicatedTaskParallelFor()

        Dim picViewer As New BitmapViewer
        Dim myReduceToX = Integer.Parse(X_ResTextBox.Text)
        Dim newExtension = DirectCast(FormatComboBox.SelectedItem, ComboBoxItem).Content.ToString
        Dim fileItems = FilenamesListbox.Items
        Dim outputFolder = OutputFolderTextBox.Text
        Dim postfix = PostfixTextBox.Text

        Dim totalSw = Stopwatch.StartNew

        Dim workerTask = Task.Factory.StartNew(
            Sub()
                Dispatcher.Invoke(Sub()
                                      If Me.StartButton.Content.ToString <> "Start!" Then
                                          mySignalStop = True
                                          Me.StartButton.Content = "Start!"
                                          Return
                                      End If

                                      Me.StartButton.Content = "Stop!"

                                      picViewer.Show()

                                      Me.TotalProgressBar.Maximum = FilenamesListbox.Items.Count
                                  End Sub)

                Dim progressCount = 0

                For Each filenameItem As String In fileItems

                    Dim fileInfo As New FileInfo(filenameItem)
                    Dim currentPicture As WriteableBitmapManager = Nothing
                    Dim mySmallWbm As WriteableBitmapManager = Nothing
                    Dim pixelFakt As Double
                    Dim pixelHeight As Integer

                    Dispatcher.Invoke(Sub(fileItem As String)
                                          CurrentFileTextBlock.Text = fileItem

                                          'Muss später angezeigt, deswegen auf dem UI-Thread
                                          'erstellt werden.
                                          currentPicture = New WriteableBitmapManager(fileItem)
                                          mySmallWbm = currentPicture.CreateCompatible(myReduceToX)
                                          pixelFakt = currentPicture.WriteableBitmap.PixelWidth / myReduceToX
                                          pixelHeight = mySmallWbm.WriteableBitmap.PixelHeight
                                      End Sub, filenameItem)


                    Dim sw = Stopwatch.StartNew

                    Parallel.For(0, pixelHeight,
                                 Sub(y)
                                     For x = 0 To myReduceToX - 1
                                         mySmallWbm.SetPixel(x, y,
                                             currentPicture.GetPixel(CInt(Math.Truncate(pixelFakt * x)), CInt(Math.Truncate(pixelFakt * y))))
                                     Next
                                 End Sub)


                    Dispatcher.Invoke(Sub(fileItem As String)
                                          'Wird angezeigt, deswegen umleiten zum UI-Thread.
                                          mySmallWbm.UpdateBitmap()
                                      End Sub, filenameItem)

                    Dim newFilename = fileInfo.Name.Replace(fileInfo.Extension, "")

                    newFilename = outputFolder &
                                  "\" & newFilename & postfix & newExtension
                    mySmallWbm.SaveBitmap(newFilename)
                    sw.Stop()
                    Dispatcher.Invoke(Sub()
                                          picViewer.ShowPicture(mySmallWbm, "Dauer der Konvertierung in ms: " & sw.ElapsedMilliseconds.ToString("#,##0.00"))
                                          progressCount += 1
                                          TotalProgressBar.Value = progressCount
                                      End Sub)

                    If mySignalStop Then
                        mySignalStop = False
                        Exit For
                    End If
                Next
                totalSw.Stop()
                Dispatcher.Invoke(Sub()
                                      Me.StartButton.Content = "Start!"
                                      CurrentFileTextBlock.Text = totalSw.ElapsedMilliseconds.ToString("#,##0") & " ms"
                                      picViewer.Close()
                                  End Sub)
            End Sub)
    End Sub

    Sub ParallelForEach()

        Dim myReduceToX = Integer.Parse(X_ResTextBox.Text)
        Dim newExtension = DirectCast(FormatComboBox.SelectedItem, ComboBoxItem).Content.ToString
        Dim fileItems = FilenamesListbox.Items.OfType(Of String)()
        Dim outputFolder = OutputFolderTextBox.Text
        Dim postfix = PostfixTextBox.Text

        Dim sw = Stopwatch.StartNew

        Dim workerTask = Task.Factory.StartNew(
            Sub()
                Dispatcher.Invoke(Sub()
                                      If Me.StartButton.Content.ToString <> "Start!" Then
                                          mySignalStop = True
                                          Me.StartButton.Content = "Start!"
                                          Return
                                      End If

                                      Me.StartButton.Content = "Stop!"

                                      Me.TotalProgressBar.Maximum = FilenamesListbox.Items.Count
                                  End Sub)

                Dim progressCount = 0

                Parallel.ForEach(fileItems, New ParallelOptions() With {.MaxDegreeOfParallelism = 4},
                                 Sub(filenameitem)

                                     If String.IsNullOrEmpty(Thread.CurrentThread.Name) Then
                                         Thread.CurrentThread.Name = "Thread for " & filenameitem
                                         Debug.Print("Started for " & filenameitem)
                                     End If

                                     'Darf nicht blockend sein, damit nicht der nächste Thread beginnt,
                                     'und wir irgendwann keinen Speicher mehr haben!
                                     Dispatcher.BeginInvoke(Sub(fileItem As String)
                                                                CurrentFileTextBlock.Text = fileItem
                                                            End Sub, filenameitem)

                                     Dim fileInfo As New FileInfo(filenameitem)
                                     Dim currentPicture As WriteableBitmapManager = Nothing
                                     Dim mySmallWbm As WriteableBitmapManager = Nothing
                                     Dim pixelFakt As Double
                                     Dim pixelHeight As Integer

                                     currentPicture = New WriteableBitmapManager(filenameitem)
                                     mySmallWbm = currentPicture.CreateCompatible(myReduceToX)
                                     pixelFakt = currentPicture.WriteableBitmap.PixelWidth / myReduceToX
                                     pixelHeight = mySmallWbm.WriteableBitmap.PixelHeight

                                     Parallel.For(0, pixelHeight,
                                                  Sub(y)
                                                      For x = 0 To myReduceToX - 1
                                                          mySmallWbm.SetPixel(x, y,
                                                              currentPicture.GetPixel(CInt(Math.Truncate(pixelFakt * x)), CInt(Math.Truncate(pixelFakt * y))))
                                                      Next
                                                  End Sub)

                                     mySmallWbm.UpdateBitmap()

                                     Dim newFilename = fileInfo.Name.Replace(fileInfo.Extension, "")

                                     newFilename = outputFolder &
                                                   "\" & newFilename & postfix & newExtension
                                     mySmallWbm.SaveBitmap(newFilename)
                                     progressCount += 1
                                     Dispatcher.BeginInvoke(Sub()
                                                                TotalProgressBar.Value = progressCount
                                                            End Sub)

                                     'If mySignalStop Then
                                     '    mySignalStop = False
                                     '    Exit For
                                     'End If
                                 End Sub)
                sw.Stop()
                Dispatcher.Invoke(Sub()
                                      Me.StartButton.Content = "Start!"
                                      CurrentFileTextBlock.Text = sw.ElapsedMilliseconds.ToString("#,##0") & " ms"
                                  End Sub)

            End Sub)


    End Sub

End Class
