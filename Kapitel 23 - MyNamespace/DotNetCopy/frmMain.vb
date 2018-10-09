Imports System.IO
Imports System.Text
Imports System.Collections.ObjectModel

Public Class frmMain

    'Membervaribale, die beim Kopieren 'True' wird,
    'wenn der Anwender 'Abbrechen' geklickt hat.
    Private myCancelOperation As Boolean

    'In diesem Stringbuilder wird das Protokoll erstellt.
    Private myLogString As StringBuilder

    'Diese Queue dient zur Speicherung der jeweils 
    'letzten 100 Zeilen des Protokolls.
    Private myVisibleLineQueue As Queue

    'Lässt andere Prozeduren wissen, ob gerade kopiert wird.
    Private myCopyInProgress As Boolean

    'Hält fest, ob - bedingt durch Befehlszeilenargumente - 
    'der Kopiervorgang mit einer durch /autostart:kopierlistendatei.osd
    'angegebenen Datei automatisch gestartet und das Programm anschließend
    'beendet werden soll.
    Private myAutoStartMode As Boolean
    'Der ermittelte Dateiname steht dann hier drin:
    'Passiert beim Einlesen der Kopierlistendatei ein Fehler (eine Ausnahme),
    'wird ein Fehler im Ereignisprotokoll von Windows hinterlegt.
    'Die app.config-Datei wurde entsprechend geändert, damit mit
    'My.Application.Log.WriteException ein Eintrag im Anwendungs-
    'protokoll erfolgen kann.
    Private myAutoStartCopyList As String

    'Hält fest, ob die Anwendung im Silent-Modus gestartet werden soll,
    'bei dem keine Dialoge angezeigt und keine Ausgaben erfolgenden sollen.
    'Der Silent-Modus wird mit /silent initiiert.
    Private mySilentMode As Boolean

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Formular nicht schließen lassen, wenn das Kopieren gerade läuft!
        If myCopyInProgress Then
            MessageBox.Show("Das Formular kann derzeit nicht geschlossen werden, da der Kopiervorgang läuft!", _
                 "Formular schließen nicht möglich", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'Die Formularplatzierungen speichern
        My.Settings.frmMain_LastPosition = Me.Location
        My.Settings.frmMain_LastSize = Me.Size
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn das Formular geladen wird, und enthält die 
    ''' Initialisierung der ListView sowie das Anstoßen des Kopiervorgangs
    ''' (und das zuvor notwendige laden der Kopierliste), wenn das Programm
    ''' im Autostart (aber nicht im Silent) -Modus läuft.
    ''' (Silent-Modus wird in ApplicationEvents.vb gehandelt).
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Me.Load
        'Listview einrichten
        With Me.lvwCopyEntries.Columns
            'Die Texte für die Listview-Spalten aus der Ressource-Datei entnehmen
            .Add(My.Resources.ListViewSourcePathColumnName)
            .Add(My.Resources.ListViewSearchMaskColumnName)
            .Add(My.Resources.ListViewDestinationPathColumnName)
            'Spalten ausrichten
            AlignColumns()
        End With

        'Nur die Symbole/Menübefehle zugänglich machen,
        'die Sinn ergeben.
        ToggleCommands(False)

        'Fenstergröße und -position wiederherstellen, wenn
        'nicht im Silent-Modus
        If Not mySilentMode Then
            'Beim ersten Aufruf ist die Größe -1, dann bleibt die Default-
            'Position, die Settings werden aber sofort übernommen...
            If My.Settings.frmMain_LastPosition.X = -1 Then
                My.Settings.frmMain_LastPosition = Me.Location
                Me.Size = My.Settings.frmMain_LastSize
                My.Settings.Save()

                'anderenfalls werden die Settings-Einstellungen in die Formular-
                'Position übernommen
            Else
                Me.Location = My.Settings.frmMain_LastPosition
            End If
            Me.Size = My.Settings.frmMain_LastSize
        End If

        'Falls AutoStart und auch kein SilentMode
        If myAutoStartMode AndAlso Not mySilentMode Then
            'Dann das Formular jetzt schon darstellen, 
            'weil sich der ganze Prozess in Form_Load abspielt.
            Me.Show()
        End If

        'Falls AutoStart, findet alles hintereinander hier in FormLoad statt:
        If myAutoStartMode Then
            HandleAutoStart()
            'und danach ist Schluss!
            Me.Close()
        End If

    End Sub

    ''' <summary>
    ''' Sorgt für den automatischen Ablauf eines Kopiervorgangs im AutoStart-Modus
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub HandleAutoStart()
        Try
            'Versuchen, die Kopierliste zu laden.
            LoadCopyEntryList(myAutoStartCopyList)
        Catch ex As Exception
            'Ins Event-Log von Windows schreiben, dass eine 
            'Fehlermeldung beim Laden der Kopierliste aufgetreten ist.
            'WriteEntry schreibt deswegen ins EventLog, da in der app.config 
            'der entsprechende Eintrag unter 'SharedListeners' gemacht wurde.
            My.Application.Log.WriteException(ex, TraceEventType.Error, _
                "DotNetCopy sollte im AutoStart-Modus gestartet werden, " & _
                "aber beim Öffnen der Kopierlistendatei trat ein Fehler auf!")

            'Programm mit der Vorschlaghammer-Methode beenden:
            '(FormClose und FormClosing werden hier NICHT mehr ausgelöst).
            Me.Dispose()
            Exit Sub
        End Try
        'Windows Zeit zum Luftholen geben.
        My.Application.DoEvents()
        'Laut Kopierliste kopieren
        CopyFiles()
        'Programm mit der sanften Methode beenden
        '(FormClose und FormClosing werden hier ausgelöst).
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Optionen' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Diese Ereignisbehandlungsroutine behandelt, wie alle anderen Befehle,
    ''' zwei Ereignisse (siehe 'Handels')</remarks>
    Private Sub tsmToolsOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles tsmToolsOptions.Click, tsbOptions.Click
        'Direkter Instanzzugriff auf Options-Dialog mit My
        My.Forms.frmOptions.ShowDialog()
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Jetzt starten' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmToolsStartNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmToolsStartNow.Click, tsbStartNow.Click
        CopyFiles()
    End Sub


    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Kopiereintrag hinzufügen' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmNewCopyListEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmNewCopyListEntry.Click, tsbNewCopyListEntry.Click
        Dim locCopyListEntry As CopyListEntry
        'Formular "ohne Instanzierung" über den My-Namespace aufrufen
        locCopyListEntry = My.Forms.frmNewEditCopylistEntry.NewCopyListEntry
        'Wenn die Funktion einen Kopiereintrag zurückgegeben hat, dann
        If locCopyListEntry IsNot Nothing Then
            'diesen Eintrag zur Liste hinzufügen
            AddCopyListEntryToListView(locCopyListEntry)
        End If
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Kopierliste speichern' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmFileSaveCopyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileSaveCopyList.Click, tsbSaveCopyList.Click

        Dim locSfd As New SaveFileDialog
        With locSfd
            .DefaultExt = "*.ols"
            .Filter = "Ordnerlisten" & " (" & "*.ols" & ")|" & "*.ols" & "|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            SaveCopyEntryList(.FileName)
        End With
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Kopierliste speichern' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmFileOpenCopyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmFileOpenCopyList.Click, tsbLoadCopyList.Click

        Dim locOfd As New OpenFileDialog
        With locOfd
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.ols"
            .Filter = "Ordnerlisten" & " (" & "*.ols" & ")|" & "*.ols" & "|Alle Dateien (*.*)|*.*"
            Dim dialogErgebnis As DialogResult = .ShowDialog
            If dialogErgebnis = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            LoadCopyEntryList(.FileName)
        End With
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Kopierlisteneintrag bearbeiten' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmEditCopyEntryEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmEditCopyEntryEdit.Click, tsbEditCopyListEntry.Click
        Dim locCopyListEntry As CopyListEntry = DirectCast(lvwCopyEntries.SelectedItems(0).Tag, CopyListEntry)
        Dim locCopyListEntryEdited As CopyListEntry
        locCopyListEntryEdited = My.Forms.frmNewEditCopylistEntry.EditCopyListEntry(locCopyListEntry)
        If locCopyListEntryEdited IsNot Nothing Then
            Dim locItem As New ListViewItem(locCopyListEntryEdited.SourceFolder.ToString)
            locItem.SubItems.Add(locCopyListEntryEdited.SearchMask)
            locItem.SubItems.Add(locCopyListEntryEdited.DestFolder.ToString)
            locItem.Tag = locCopyListEntryEdited
            lvwCopyEntries.Items(lvwCopyEntries.SelectedIndices(0)) = locItem
            AlignColumns()
        End If
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Benutzer 'Kopierlisteneintrag löschen' 
    ''' oder das äquivalente Symbol anklickt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tsmEditCopyListEntryDelete_Click(ByVal sender As System.Object,
                        ByVal e As System.EventArgs) Handles tsmEditCopyListEntryDelete.Click, tsbDeleteCopyListEntry.Click
        lvwCopyEntries.Items.RemoveAt(lvwCopyEntries.SelectedIndices(0))
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myCancelOperation = True
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Anwender die ListView-Eintrags-Selektion ändert.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvwCopyEntries_SelectedIndexChanged(ByVal sender As System.Object,
                                ByVal e As System.EventArgs) Handles lvwCopyEntries.SelectedIndexChanged
        If lvwCopyEntries.SelectedIndices.Count > 0 Then
            ToggleCommands(True)
        Else
            ToggleCommands(False)
        End If
    End Sub

    ''' <summary>
    ''' Fügt einen Kopiereintrag, der als CopyListEntry-Objekt vorliegt, der ListView hinzu.
    ''' </summary>
    ''' <param name="copyListEntry">Instanz eines Kopiereintrag-Objekts, das der ListView hinzugefügt werden soll.</param>
    ''' <returns>ListViewItem, der dem hinzugefügten Eintrag in der ListView entspricht.</returns>
    ''' <remarks></remarks>
    Private Function AddCopyListEntryToListView(ByVal copyListEntry As CopyListEntry) As ListViewItem
        Dim locItem As ListViewItem = lvwCopyEntries.Items.Add(copyListEntry.SourceFolder.ToString)
        locItem.SubItems.Add(copyListEntry.SearchMask)
        locItem.SubItems.Add(copyListEntry.DestFolder.ToString)
        'Die Tag-Eigenschaft jedes ListView-Eintrags kann ein beliebiges Objekt speichern.
        'Diese Fähigkeit nutzen wir, um ein CopyListEntry-Instanz direkt dort abzulegen.
        'Beim Speichern können wir so beispielsweise durch die ganze Liste iterieren,
        'die einzelnen Elemente wieder herausholen und Sie in einer Textdatei speichern.
        locItem.Tag = copyListEntry
        AlignColumns()
        Return locItem
    End Function

    ''' <summary>
    ''' Sorgt dafür, dass beispielsweise nach dem Hinzufügen eines Eintrags 
    ''' die ListView-Spaltenbreiten angepasst werden, damit alle Texte sichtbar sind.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AlignColumns()
        For Each locColumn As ColumnHeader In lvwCopyEntries.Columns
            locColumn.Width = -2
        Next
    End Sub

    ''' <summary>
    ''' Speichert die Kopierliste in einer Textdatei.
    ''' </summary>
    ''' <param name="copyEntryListPath">Der Pfad und Dateiname der Kopierlistendatei.</param>
    ''' <remarks></remarks>
    Private Sub SaveCopyEntryList(ByVal copyEntryListPath As String)
        Dim locContent As String = ""
        'Durch die ganze Liste wandern (iterieren), und die
        'CopyListEntry-Elemente zum Abspeichern in einer Textdatei
        'wieder auslesen.
        For Each locItem As ListViewItem In lvwCopyEntries.Items
            Dim locCopyListEntry As CopyListEntry
            'Directcast ist notwendig, damit der Compiler weiß, welcher Typ
            'in der Tag-Eigenschaft gespeichert war.
            locCopyListEntry = DirectCast(locItem.Tag, CopyListEntry)
            'Durch ; getrennt erst alle in String ablegen
            locContent &= locCopyListEntry.SourceFolder.ToString & ";"
            locContent &= locCopyListEntry.SearchMask & ";"
            'Letztes Feld endet mit CR + LF (= VbNewLine)
            locContent &= locCopyListEntry.DestFolder.ToString & vbNewLine
        Next

        'In locContent steht jetzt die gesamte Liste im CSV-Format.
        'Den String können wir jetzt mithilfe von My in einem Rutsch
        'in einer Textdatei abspeichern.
        My.Computer.FileSystem.WriteAllText(copyEntryListPath, locContent, False)
    End Sub

    ''' <summary>
    ''' Lädt die Kopierliste aus einer Textdatei.
    ''' </summary>
    ''' <param name="copyEntryListPath">Der Ppfad und Dateiname der Kopierlistendatei.</param>
    ''' <remarks></remarks>
    Private Sub LoadCopyEntryList(ByVal copyEntryListPath As String)
        'Alle Elemente in der Liste löschen
        lvwCopyEntries.Items.Clear()
        'Listview nicht aktualisieren, bevor nicht alle Elemente dargestellt wurden!
        lvwCopyEntries.BeginUpdate()

        Dim locParser As FileIO.TextFieldParser

        'My stellt mit OpenTextFieldParser ein Objekt zur Verfügung, das
        'CSV-Dateien auseinandernehmen kann. Wir erstellen daraus wieder neue
        'CopyListEntry-Objekte, und fügen sie der Liste hinzu.
        'Dazu erstmal das Parser-Objekt erhalten...
        locParser = My.Computer.FileSystem.OpenTextFieldParser(copyEntryListPath, ";")

        'Und die einzelnen CSV-Zeilen, die es nun enthält, solange durchgehen,
        'wie Zeilen vorhanden sind.
        Do While Not locParser.EndOfData
            'Die jeweils nächste Zeile lesen und die einzelnen Felder
            'in ein String-Array separieren.
            Dim locFields As String() = locParser.ReadFields
            'Und daraus nun wieder die CopyListEntry-Instanz herstellen...
            Dim locCopyListEntry As New CopyListEntry
            locCopyListEntry.SourceFolder = New DirectoryInfo(locFields(0))
            locCopyListEntry.SearchMask = locFields(1)
            locCopyListEntry.DestFolder = New DirectoryInfo(locFields(2))
            AddCopyListEntryToListView(locCopyListEntry)
        Loop
        AlignColumns()
        'Erst jetzt darf die ListView wieder aktualisiert werden.
        lvwCopyEntries.EndUpdate()
    End Sub

    ''' <summary>
    ''' Die eigentliche Kopierroutine, die durch die My.Settings-Optionen gesteuert wird.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CopyFiles()
        Dim locCopyTaskItems As New ArrayList
        Dim locStartTime As Date = Now
        Dim locNotCaught As Boolean

        'Wird benötigt für die Textspeicherung des Protokolls.
        myLogString = New StringBuilder
        'Wird benötigt für die Ausschnittsdarstellung des Protokolls in der TextBox.
        myVisibleLineQueue = New Queue
        'Flag, das anzeigt, ob der Kopiervorgang abgebrochen werden soll.
        myCancelOperation = False
        'Flag, das Auskunft darüber gibt, ob der Kopiervorgang läuft
        myCopyInProgress = True

        'Auf die zweite Registerkarte umschalten, damit die
        'UI zu sehen ist.
        Me.TabControl1.SelectedTab = Me.TabPage2
        Me.btnCancel.Enabled = True

        'Fortschrittsanzeige initialisieren
        pbPrepareAndCopy.Minimum = 0
        pbPrepareAndCopy.Maximum = lvwCopyEntries.Items.Count + 1
        'Protokollanzeige löschen.
        txtProtocol.Text = ""

        'So wird protokolliert:
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("--- Pass 1: Zusammenstellen der Verzeichnisse")
        LogInProtocolWindow("--- Gestartet um: " & locStartTime.ToLongTimeString & _
                            " am:" & locStartTime.ToLongDateString)
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("")

        'In dieser Schleife werden zunächst alle Dateien ermittelt,
        'die es daraufhin zu untersuchen gilt, ob sie kopiert werden
        'müssen oder nicht.
        For locItemCount As Integer = 0 To lvwCopyEntries.Items.Count - 1
            Dim locCopyListEntry As CopyListEntry
            'CType ist notwendig, damit .NET weiß, welcher Typ
            'in der Tag-Eigenschaft gepspeichert war.
            locCopyListEntry = CType(lvwCopyEntries.Items(locItemCount).Tag, CopyListEntry)
            'UI aktualisieren
            lblCurrentPass.Text = "Pass 1: Kopiervorbereitung durch Zusammenstellung der Pfade..."
            lblSourceFileInfo.Text = "Unterverzeichnisse suchen in:"
            lblDestFileInfo.Text = ""
            lblProgressCaption.Text = "Fortschritt Vorbereitung:"
            lblCurrentSourcePath.Text = locCopyListEntry.SourceFolder.ToString
            LogInProtocolWindow(locCopyListEntry.SourceFolder.ToString)
            pbPrepareAndCopy.Value = locItemCount + 1

            'Windows die Möglichkeit geben, die Steuerelemente zu aktualisieren
            My.Application.DoEvents()

            'GetFiles aus My.Computer.FileSystem liefert die Namen aller 
            'Dateien im Stamm- und in dessen Unterverzeichnissen.
            Dim locFiles As ReadOnlyCollection(Of String)
            Try
                locNotCaught = False
                locFiles = My.Computer.FileSystem.GetFiles( _
                        locCopyListEntry.SourceFolder.ToString, _
                        FileIO.SearchOption.SearchAllSubDirectories, _
                        locCopyListEntry.SearchMask)
            Catch ex As Exception
                LogError(ex)
                'Wenn schon beim Zusammenstellen der Dateien Fehler aufgetreten sind,
                'sollte das Verzeichnis ausgelassen werden. In diesem Fall sollte dieser
                'schwerwiegende Fakt im Anwendungsprotokoll protokolliert werden!
                My.Application.Log.WriteException(ex, TraceEventType.Error, _
                    "DotNetCopy konnte das Verzeichnis " & _
                    locCopyListEntry.SourceFolder.ToString & " nicht durchsuchen., " & _
                    "Das Verzeichnis wurde daher nicht berüscksichtigt!")

                ' Es müsste wie "Catch" einen "NotCaught"-Zweig geben... ;-)
                locNotCaught = True
            End Try

            'Das Zusammenstellen der Dateien nur ausführen, wenn beim
            'Einlesen der Dateien kein Fehler (protokolliert in locNotCaught)
            'aufgetreten ist!
            If Not locNotCaught Then
                'Durch alle Dateien iterieren, und die Quellpfade bilden.
                For Each locFile As String In locFiles
                    Dim locCopyTaskItem As New CopyTaskItem
                    locCopyTaskItem.SourceFile = New FileInfo(locFile)

                    'Verzeichnisverweise an dieser Stelle übergehen, sodass nur
                    'eine Liste mit Dateien innerhalb der Verzeichnisse bleibt.
                    If Not (locCopyTaskItem.SourceFile.Attributes And FileAttributes.Directory) = _
                            FileAttributes.Directory Then
                        locCopyTaskItem.SourcePathPart = locCopyListEntry.SourceFolder.ToString
                        locCopyTaskItem.DestPathPart = locCopyListEntry.DestFolder.ToString
                        locCopyTaskItems.Add(locCopyTaskItem)
                    End If

                    'Ereignisbehandlung zulassen.
                    My.Application.DoEvents()
                    If myCancelOperation Then
                        myCancelOperation = False
                        CancelCopying()
                        Exit Sub
                    End If
                Next
            End If
        Next
        LogInProtocolWindow("")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("--- Pass 1 abgeschlossen")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("")
        LogInProtocolWindow("")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("--- Pass 2: Kopieren der Dateiinhalte")
        LogInProtocolWindow("--- Gestartet um: " & Now.ToLongTimeString & " am:" _
                                & Now.ToLongDateString)
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("")

        Dim locDoCopy As Boolean
        'Verzeichnisse sind erstellt, jetzt alle Dateien kopieren

        'UI-Aktualisieren
        lblCurrentPass.Text = "Pass 2: Kopieren aller zutreffenden Dateien..."
        lblSourceFileInfo.Text = "Kopieren der Datei:"
        lblDestFileInfo.Text = "in Zielverzeichnis:"
        lblProgressCaption.Text = "Kopierfortschritt:"
        pbPrepareAndCopy.Maximum = locCopyTaskItems.Count + 1
        pbPrepareAndCopy.Value = 0
        Dim locFileCount As Integer = 1
        My.Application.DoEvents()

        For Each locFileItem As CopyTaskItem In locCopyTaskItems
            Dim locDestPath, locOldDestPath As DirectoryInfo
            Dim locDestFile As FileInfo

            'Erstmal optimistisch davon ausgehen,
            'dass die Datei kopiert werden wird.
            locDoCopy = True

            With locFileItem
                'Den Zielpfad ermitteln
                locDestPath = New DirectoryInfo(.DestPathPart & .SourceFile.Directory.ToString.Replace(.SourcePathPart, ""))
                'Die Zieldatei samt Pfad ermitteln
                locDestFile = New FileInfo(locDestPath.ToString & "\" & .SourceFile.Name)

                'Wenn es sich um eine versteckte Datei handelt, aber 
                'versteckte Dateien nicht kopiert werden sollen...
                If (.SourceFile.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden AndAlso _
                    My.Settings.Option_CopyHiddenFiles = False Then
                    '...dann die Datei nicht kopieren.
                    locDoCopy = False
                    LogInProtocolWindow("Ausgelassen, da versteckte Datei: " & .SourceFile.ToString)
                End If

                'Wenn es sich um eine Systemdatei handelt, aber 
                'Systemdateien nicht kopiert werden sollen...
                If (.SourceFile.Attributes And FileAttributes.System) = FileAttributes.System AndAlso _
                    My.Settings.Option_CopySystemFiles = False Then
                    '...dann die Datei nicht kopieren.
                    locDoCopy = False
                    LogInProtocolWindow("Ausgelassen, da Systemdatei: " & .SourceFile.ToString)
                End If

                'Wenn sich die Datei schon am Zielort befindet,
                'Dateien aber grundsätzlich nicht überschrieben werden sollen...
                If locDestFile.Exists AndAlso My.Settings.Option_NeverOverwriteFiles Then
                    '...dann die Datei nicht kopieren.
                    locDoCopy = False
                    LogInProtocolWindow("Ausgelassen, da schon vorhanden: " & .SourceFile.ToString)
                End If

                'Wenn die Datei kopiert werden soll
                pbPrepareAndCopy.Value = locFileCount
                locFileCount += 1
                If locDoCopy Then
                    'Dafür sorgen, dass der Zielpfad vorhanden ist:
                    If Not locDestPath.Exists Then
                        locDestPath.Create()
                        LogInProtocolWindow("Zielpfad musste erstellt werden: " & locDestPath.ToString)
                    End If

                    'Datei mit Historiepflege kopieren
                    lblCurrentSourcePath.Text = .SourceFile.ToString
                    If locOldDestPath Is Nothing Then
                        locOldDestPath = New DirectoryInfo(locDestPath.ToString)
                        lblCurrentDestinationPath.Text = locDestPath.ToString
                    End If
                    If locOldDestPath.FullName <> locDestPath.FullName Then
                        lblCurrentDestinationPath.Text = locDestPath.ToString
                        LogInProtocolWindow("Verarbeite Verzeichnis: " & locDestPath.ToString)
                        locOldDestPath = New DirectoryInfo(locDestPath.ToString)
                    End If
                    Application.DoEvents()
                    If myCancelOperation Then
                        myCancelOperation = False
                        CancelCopying()
                        Exit Sub
                    End If
                    CopyFileInternal(.SourceFile, locDestFile)
                End If
            End With
        Next
        btnCancel.Enabled = False
        LogInProtocolWindow("")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("--- Pass 2 abgeschlossen")
        LogInProtocolWindow("--- um: " & Now.ToLongTimeString & " am:" & Now.ToLongDateString)
        LogInProtocolWindow("--- Gesamtdauer:" & Now.Subtract(locStartTime).TotalMinutes.ToString & " Minuten")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("")

        'Gesamtes Protokoll wieder anzeigen
        txtProtocol.Text = myLogString.ToString
        txtProtocol.SelectionStart = myLogString.Length
        txtProtocol.ScrollToCaret()
        pbPrepareAndCopy.Value = pbPrepareAndCopy.Maximum
        myCopyInProgress = False

        'Und im Bedarfsfall abspeichern
        If My.Settings.Option_AutoSaveProtocol Then
            Dim locProtocolFilename As String = "DNC" & Now.ToString("yyMMdd-HHmmss") & ".log"
            Dim locDi As New DirectoryInfo(My.Settings.Option_AutoSaveProtocolPath)
            If Not locDi.Exists Then
                locDi.Create()
            End If
            My.Computer.FileSystem.WriteAllText(locDi.ToString & "\" & locProtocolFilename, _
                txtProtocol.Text, False, System.Text.Encoding.Default)
        End If
    End Sub

    ''' <summary>
    ''' Wird aufgerufen, wenn der Kopiervorgang an einer Stelle abgebrochen werden soll.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CancelCopying()
        btnCancel.Enabled = False
        myCopyInProgress = False
        LogInProtocolWindow("")
        LogInProtocolWindow("------------------------------------------------------")
        LogInProtocolWindow("--- Vorgang abgebrochen")
        LogInProtocolWindow("--- um: " & Now.ToLongTimeString & " am:" & Now.ToLongDateString)
        LogInProtocolWindow("------------------------------------------------------")
    End Sub

    ''' <summary>
    ''' Interne Kopierroutine, die den eigentlichen 'Job' des Kopierens übernimmt.
    ''' </summary>
    ''' <param name="SourceFile">Quelldatei, die kopiert werden soll.</param>
    ''' <param name="DestFile">Zielpfad, in den die Datei hineinkopiert werden soll.</param>
    ''' <remarks></remarks>
    Private Sub CopyFileInternal(ByVal SourceFile As FileInfo, ByVal DestFile As FileInfo)
        'Falls die Zieldatei noch gar nicht existiert,
        'dann in jedem Fall kopieren
        If Not DestFile.Exists Then
            Try
                'Datei kopieren, ohne Windows-Benutzeroberfläche anzuzeigen.
                My.Computer.FileSystem.CopyFile(SourceFile.ToString, DestFile.ToString)
                LogInProtocolWindow("Kopiert, OK: " & SourceFile.ToString)
            Catch ex As Exception
                LogError(ex)
            End Try
            Exit Sub
        End If
        'Datei nur kopieren, wenn Sie jünger als die zu überschreibende ist
        If My.Settings.Option_OnlyOverwriteIfOlder Then
            If SourceFile.LastWriteTime > DestFile.LastWriteTime Then
                'Wenn das Historien-Backup aktiviert ist...
                If My.Settings.Option_EnableBackupHistory Then
                    '...dieses durchführen.
                    ManageFileBackupHistory(DestFile)
                End If
                Try
                    'Datei kopieren.
                    My.Computer.FileSystem.CopyFile(SourceFile.ToString, DestFile.ToString)
                    LogInProtocolWindow("Kopiert, OK: " & SourceFile.ToString)
                Catch ex As Exception
                    LogError(ex)
                End Try
            End If
        End If
    End Sub

    ''' <summary>
    ''' Sorgt dafür, dass im Bedarfsfall Backupversionen einer Datei erstellt werden, 
    ''' die durch eine neuere Version der Datei überschrieben werden soll.
    ''' </summary>
    ''' <param name="DestFile"></param>
    ''' <remarks></remarks>
    Private Sub ManageFileBackupHistory(ByVal DestFile As FileInfo)
        Dim locFileToProcess As FileInfo
        'Feststellen, ob das letzte Backup rausfliegt
        locFileToProcess = New FileInfo(DestFile.ToString & ".DNCBackup" & My.Settings.Option_HistoryLevels.ToString("0"))
        If locFileToProcess.Exists Then
            Try
                'Älteste Backupdatei löschen.
                locFileToProcess.Delete()
                LogInProtocolWindow("Aus Historie ausgeschieden: " & locFileToProcess.ToString)
            Catch ex As Exception
                LogError(ex)
            End Try
        End If

        'History nach oben hoch benennen
        For locHistoryCount As Integer = My.Settings.Option_HistoryLevels - 1 To 1 Step -1
            locFileToProcess = New FileInfo(DestFile.ToString & ".DNCBackup" & locHistoryCount.ToString("0"))
            If locFileToProcess.Exists Then
                Try

                    Dim locFileInfo As New FileInfo(DestFile.ToString & ".DNCBackup" & (locHistoryCount + 1).ToString("0"))

                    'Datei umbenennen
                    My.Computer.FileSystem.RenameFile(locFileToProcess.FullName, _
                        locFileInfo.Name)
                    LogInProtocolWindow("Historiepflege, raufgestuft: " & locFileToProcess.ToString)

                    'Die Backup-Datei in versteckte Datei umwandeln, falls notwendig
                    If My.Settings.Option_BackupInHiddenFiles Then
                        locFileInfo.Attributes = locFileInfo.Attributes Or FileAttributes.Hidden
                        LogInProtocolWindow("Historiepflege, Datei versteckt: " & locFileInfo.ToString)
                    End If

                Catch ex As Exception
                    LogError(ex)
                End Try
            End If
        Next

        'Eigentliche "alte" Datei umbenennen
        Try
            My.Computer.FileSystem.RenameFile(DestFile.FullName, _
                (New FileInfo(DestFile.ToString & ".DNCBackup1").Name))
            LogInProtocolWindow("Historiepflege, in Backup umgewandelt: " & DestFile.ToString)
        Catch ex As Exception
            LogError(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Stellt eine Zeile im Protokollfenster dar.
    ''' </summary>
    ''' <param name="Message">String ohne CR, der die Nachrichtenzeile des Protokolls enthält.</param>
    ''' <remarks></remarks>
    Sub LogInProtocolWindow(ByVal Message As String)
        Dim locString As String

        'String-Builder für das Protokoll verwenden - geht viel schneller!
        myLogString.Append(Message + vbNewLine)

        'auch aus Geschwindigkeitsgründen: Nur 100 Zeilen im Protokollfenster darstellen.
        myVisibleLineQueue.Enqueue(Message + vbNewLine)
        If myVisibleLineQueue.Count > 100 Then
            myVisibleLineQueue.Dequeue()
        End If

        'Aus der Queue (der Warteschlange) einen Gesamttext machen...
        Dim locSB As New StringBuilder
        For Each locLine As String In myVisibleLineQueue
            locSB.Append(locLine)
        Next

        '...zwischenspeichern (zum Länge berechnen)
        locString = locSB.ToString

        'in die Textbox packen
        txtProtocol.Text = locString
        'die Einfügemarke an den Anfang der letzten Zeile setzen
        txtProtocol.SelectionStart = locString.Length - Message.Length - 2
        'und die Einfügemarke in den sichtbaren Bereich scrollen.
        txtProtocol.ScrollToCaret()
    End Sub

    ''' <summary>
    ''' Wird im Ausnahmefall aufgerufen, und bewirkt die 
    ''' Fehlermeldungsanzeige sowie den Abbruch des Vorgangs im Bedarfsfall.
    ''' </summary>
    ''' <param name="ex">Exception-Instanz, die die Ausnahme 
    ''' (und damit auch den Fehlermeldungstext) enthält.</param>
    ''' <remarks></remarks>
    Sub LogError(ByVal ex As Exception)
        LogInProtocolWindow("Fehler: " & ex.Message)
        If Not My.Settings.Option_OnCopyErrorContinue Then
            myCancelOperation = True
        End If
    End Sub

    ''' <summary>
    ''' Schaltet bestimmte Menübefehle/Symbole, die nur bei selektiertem 
    ''' ListView-Eintrag zur Verfügung stehen, ein bzw. aus.
    ''' </summary>
    ''' <param name="OnOff">Bestimmt, ob die Elemente ein- (True) oder ausgeschaltet werden sollen.</param>
    ''' <remarks></remarks>
    Private Sub ToggleCommands(ByVal OnOff As Boolean)
        tsmEditCopyEntryEdit.Enabled = OnOff
        tsmEditCopyListEntryDelete.Enabled = OnOff
        tsbDeleteCopyListEntry.Enabled = OnOff
        tsbEditCopyListEntry.Enabled = OnOff
    End Sub

    Friend Property SilentMode() As Boolean
        Get
            Return mySilentMode
        End Get
        Set(ByVal value As Boolean)
            mySilentMode = value
        End Set
    End Property

    Friend Property AutoStartMode() As Boolean
        Get
            Return myAutoStartMode
        End Get
        Set(ByVal value As Boolean)
            myAutoStartMode = value
        End Set
    End Property

    Friend Property AutoStartCopyList() As String
        Get
            Return myAutoStartCopyList
        End Get
        Set(ByVal value As String)
            myAutoStartCopyList = value
        End Set
    End Property

    Sub DirInfoUndFileInfoTest()
        'DirectoryInfo-Objekt anlegen - der Pfad wird als Zeichenkette dem Konstruktor übergeben:
        Dim einDirInfo As New DirectoryInfo("C:\Ordner1\Unterordner")
        'Existiert das Verzeichnis?
        If Not einDirInfo.Exists Then
            Debug.Print("Ordner exestiert nicht, wird erstellt:")
            'Verzeichnis mit allen benötigten Unterverzeichnissen erstellen
            einDirInfo.Create()
        End If

        'Neues FileInfo-Objekt aus Pfad-/Dateinamenzeichenkette erstellen
        Dim einFileInfo As New FileInfo("c:\Order1\Unterordner\textfile.txt")

        'Jedes FileInfo-Objekt enthält auch ein DirectoryInfo-Objekt, das
        'über die Directory-Eigenschaft abrufbar ist:
        If Not einFileInfo.Directory.Exists Then
            'Pfad zur Datei im Bedarfsfall erstellen
            einFileInfo.Directory.Create()
        End If
        'Auf Vorhandensein der Datei prüfen:
        If Not einFileInfo.Exists Then
            'Eine simple Textdatei erstellen.
            My.Computer.FileSystem.WriteAllText(einFileInfo.FullName, "Dateiinhalt", False)
        End If
        Debug.Print("Die Erweiterung der Datei lautet: " & einFileInfo.Extension)
        Debug.Print("Der reine Dateiname lautet: " & einFileInfo.Name)
        Debug.Print("Voller Pfad und Dateiname zur Datei lauten: " & einFileInfo.FullName)
        Debug.Print("Die Datei hat folgende Attribute: " & einFileInfo.Attributes)
        Debug.Print("Die Datei wird jetzt ins Hauptverzeichnis kopiert!")
        'Wichtig: Pfad und neuer Dateiname müssen als Ziel beide angegeben werden!
        einFileInfo.CopyTo("C:\" & einFileInfo.Name)
        Debug.Print("Die Ausgangsdatei wird gelöscht!")
        einFileInfo.Delete()
    End Sub
End Class

''' <summary>
''' Diese Klasse speichert die Informationen für ein
''' zu kopierendes Verzeichnis der Kopierliste.
''' </summary>
''' <remarks></remarks>
Public Class CopyListEntry
    Public SourceFolder As DirectoryInfo
    Public SearchMask As String
    Public DestFolder As DirectoryInfo
End Class

''' <summary>
''' Diese Klasse speichert die Informationen für eine 
''' zu kopierende Datei innerhalb eines zu kopierenden 
''' Verzeichnisses.
''' </summary>
''' <remarks></remarks>
Public Class CopyTaskItem
    Public SourceFile As FileInfo
    Public SourcePathPart As String
    Public DestPathPart As String
End Class

