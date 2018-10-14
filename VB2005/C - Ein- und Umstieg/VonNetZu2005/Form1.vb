Imports System.IO

Public Class Form1

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        'For/Next-Schleife - Variante 1 - Mit Goto
        'Zahlen ausgeben, aber bis 10 nur gerade, ab 10 nur ungerade
        For c As Integer = 0 To 20
            If c < 10 Then
                If (c \ 2) * 2 <> c Then
                    GoTo SkipLoop
                End If
                Debug.Print("Gerade: " & c)
            End If

            If c > 10 Then
                If (c \ 2) * 2 = c Then
                    GoTo SkipLoop
                End If
                Debug.Print("Ungerade: " & c)
            End If
SkipLoop:
        Next

        'For/Next-Schleife - Variante 2 - Mit Continue For
        'Zahlen ausgeben, aber bis 10 nur gerade, ab 10 nur ungerade
        For c As Integer = 0 To 20
            If c < 10 Then
                If (c \ 2) * 2 <> c Then
                    Continue For
                End If
                Debug.Print("Gerade: " & c)
            End If

            If c > 10 Then
                If (c \ 2) * 2 = c Then
                    Continue For
                End If
                Debug.Print("Ungerade: " & c)
            End If
        Next
    End Sub

    Private Sub btnUsing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsing.Click
        'Schreiben einer Datei - herkömmliche Methode
        Dim locSw As StreamWriter
        Try
            locSw = New StreamWriter("C:\Textdatei1.txt")
            Try
                locSw.WriteLine("Erste Textzeile")
                locSw.WriteLine("Zweite Textzeile")
                'Schreibpuffer leeren
                locSw.Flush()
            Catch ex As Exception
                Debug.Print("Fehler beim Schreiben der Datei!")
            Finally
                'Alle Systemressourcen wieder freigeben
                locSw.Dispose()
            End Try
        Catch ex As Exception
            Debug.Print("Fehler beim Öffnen der Datei!")
        End Try

        'Schreiben einer Datei - mit Using wird die Lebensdauer von locSw2 gesteuert
        Try
            'Alternativ ginge auch die Weiterverwendung von locSw:
            'locSw = New StreamWriter("C:\Textdatei2.txt")
            'Using locSw 
            Using locSw2 As New StreamWriter("C:\Textdatei2.txt")
                Try
                    locSw2.WriteLine("Erste Textzeile")
                    locSw2.WriteLine("Zweite Textzeile")
                    'Schreibpuffer leeren
                    locSw2.Flush()
                Catch ex As Exception
                    Debug.Print("Fehler beim Schreiben der Datei!")
                End Try
                'Hier wird automatisch locSw.Dispose durchgeführt
            End Using
        Catch ex As Exception
            Debug.Print("Fehler beim Öffnen der Datei!")
        End Try
    End Sub

    Private Sub btnFormularOhneInstanz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormularOhneInstanz.Click
        Form2.ShowDialog()
        My.MyProject.Forms.Form2.ShowDialog()
    End Sub
End Class
