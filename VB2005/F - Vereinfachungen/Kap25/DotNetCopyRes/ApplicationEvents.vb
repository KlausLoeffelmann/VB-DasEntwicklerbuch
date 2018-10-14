Imports System.IO

Namespace My

    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' 
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst. Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung nicht normal beendet wird.
    ' UnhandledException: Wird ausgelöst, wenn in der Anwendung eine unbehandelte Ausnahme auftritt.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn diese bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication

        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            MessageBox.Show("Die Netzwerkverfügbarkeit hat sich geändert!" & _
                "Das Netzwerk ist " & IIf(e.IsNetworkAvailable, "verfügbar", "nicht verfügbar").ToString)
        End Sub

        Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown
            Debug.Print("Die Anwendung wird jetzt beendet!")
        End Sub

        Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance
            MessageBox.Show("Sie können keine 2. Instanz dieser Anwendung starten!")
            e.BringToForeground = True
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            'Eine bislang nicht behandelte Ausnahme ist aufgetreten!
            Dim locDr As DialogResult = _
                    MessageBox.Show("Eine unbehandelte Ausnahme ist aufgetreten!" & _
                            vbNewLine & "Soll die Anwendung beendet werden?", _
                            "Unbehandelte Ausnahme", MessageBoxButtons.YesNo, _
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            If locDr = DialogResult.No Then
                e.ExitApplication = False
            End If
        End Sub

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup


            'Das Verzeichnis für die Protokolldatei beim ersten Mal setzen...
            If String.IsNullOrEmpty(My.Settings.Option_AutoSaveProtocolPath) Then
                My.Settings.Option_AutoSaveProtocolPath = _
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\DotNetCopy Protokolle"
                Dim locDi As New DirectoryInfo(My.Settings.Option_AutoSaveProtocolPath)

                'Überprüfen und
                If Not locDi.Exists Then
                    'im Bedarfsfall anlegen
                    locDi.Create()
                End If

                'Settings speichern
                My.Settings.Save()
            End If

            Dim locFrmMain As New frmMain

            'Kommandozeile auslesen
            If My.Application.CommandLineArgs.Count > 0 Then
                For Each locString As String In My.Application.CommandLineArgs

                    'Alle unnötigen Leerzeichen entfernen und 
                    'Groß-/Kleinschreibung 'Unsensiblisieren'
                    'HINWEIS: Das funktioniert nur in der Windows-Welt;
                    'kommt die Kopierlistendatei von einem Unix-Server, bitte darauf achten,
                    'dass der Dateiname dafür auch komplett in Großbuchstaben gesetzt ist,
                    'da Unix- (und Linux-) Derivate Groß-/Kleinschreibung berücksichtigen!!!
                    locString = locString.ToUpper.Trim

                    If locString = "/SILENT" Then
                        locFrmMain.SilentMode = True
                    End If

                    If locString.StartsWith("/AUTOSTART") Then
                        locFrmMain.AutoStartCopyList = locString.Replace("/AUTOSTART:", "")
                        locFrmMain.AutoStartMode = True
                    End If
                Next
            End If

            'Silentmode bleibt nur "an", wenn AutoStart aktiv ist.
            locFrmMain.SilentMode = locFrmMain.SilentMode And locFrmMain.AutoStartMode

            'Und wenn Silentmode, erfolgt keine Bindung des Formulars an den Anwendungskontext!
            If locFrmMain.SilentMode Then
                'Alles wird in der nicht sichtbaren Instanz des Hauptforms durchgeführt,
                locFrmMain.HandleAutoStart()
                'und bevor das "eigentliche" Programm durch das Hauptformular gestartet wird,
                'ist der ganze Zauber auch schon wieder vorbei.
                e.Cancel = True
            Else
                'Im Nicht-Silent-Modus wird das Formular an die Anwendung gebunden,
                'und los geht's!
                My.Application.MainForm = locFrmMain
            End If
        End Sub
    End Class

End Namespace

