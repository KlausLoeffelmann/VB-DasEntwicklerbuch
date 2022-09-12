Imports System.IO

Namespace My

    ' F�r MyApplication sind folgende Ereignisse verf�gbar:
    ' 
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgel�st.
    ' Shutdown: Wird nach dem Schlie�en aller Anwendungsformulare ausgel�st. Dieses Ereignis wird nicht ausgel�st, wenn die Anwendung nicht normal beendet wird.
    ' UnhandledException: Wird ausgel�st, wenn in der Anwendung eine unbehandelte Ausnahme auftritt.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgel�st, wenn diese bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgel�st.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup

            'Das Verzeichnis f�r die Protokolldatei beim ersten Mal setzen...
            If String.IsNullOrEmpty(My.Settings.Option_AutoSaveProtocolPath) Then
                My.Settings.Option_AutoSaveProtocolPath = _
                    My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\DotNetCopy Protokolle"
                Dim locDi As New DirectoryInfo(My.Settings.Option_AutoSaveProtocolPath)

                '�berpr�fen und
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

                    'Alle unn�tigen Leerzeichen entfernen und 
                    'Gro�-/Kleinschreibung 'Unsensiblisieren'
                    'HINWEIS: Das funktioniert nur in der Windows-Welt;
                    'kommt die Kopierlistendatei von einem Unix-Server, bitte darauf achten,
                    'dass der Dateiname daf�r auch komplett in Gro�buchstaben gesetzt ist,
                    'da Unix- (und Linux-) Derivate Gro�-/Kleinschreibung ber�cksichtigen!!!
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
                'Alles wird in der nicht sichtbaren Instanz des Hauptforms durchgef�hrt,
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

