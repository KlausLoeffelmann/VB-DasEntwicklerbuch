Imports System.Data.SqlClient
Imports ActiveDev.SqlSupport


Public Class frmMain

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        Me.Show()

        'Feststellen, ob die Anwendung das erste Mal läuft.
        'Diese Benutzer-Settings-Variable wurde in den 
        'Projekteinstellungen definiert.
        If Not My.Settings.AppAnwendungZuvorGestartet Then
            Dim locDr As DialogResult = MessageBox.Show("AdoDemoSetup läuft zum ersten mal." & vbNewLine & _
                                      "Soll die Datenbank in einer SQL-Server-Instanz neu aufgesetzt werden?", _
                                      "Datenbank neu aufsetzen?", MessageBoxButtons.YesNo, _
                                      MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If locDr = Windows.Forms.DialogResult.Yes Then
                DatenbankNeuAufsetzen()
            End If
        End If
        AnsichtManager()
    End Sub

    Private Sub tsmTabelleWechseln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles tsmBeraterAnzeigen.Click, tsmProjekteAnzeigen.Click, tsmZeitenAnzeigen.Click
        tsmBeraterAnzeigen.Checked = False
        tsmProjekteAnzeigen.Checked = False
        tsmZeitenAnzeigen.Checked = False
        DirectCast(sender, ToolStripMenuItem).Checked = True
        AnsichtManager()
    End Sub

    Private Sub AnsichtManager()

        Dim locConn As New SqlConnection(My.Settings.HeckTickConnectionString)
        Using locConn

            Try
                If tsmBeraterAnzeigen.Checked Then
                    Dim locBeraterAdapter As New DSHeckTickTableAdapters.TABerater
                    Dim locBeraterTable As New DSHeckTick.BeraterDataTable
                    locBeraterAdapter.Connection = locConn
                    locBeraterAdapter.Fill(locBeraterTable)
                    dgvData.DataSource = locBeraterTable
                ElseIf tsmProjekteAnzeigen.Checked Then
                    Dim locProjekteAdapter As New DSHeckTickTableAdapters.TAProjekte
                    Dim locProjekteTable As New DSHeckTick.ProjekteDataTable
                    locProjekteAdapter.Connection = locConn
                    locProjekteAdapter.Fill(locProjekteTable)
                    dgvData.DataSource = locProjekteTable
                Else
                    Dim locZeitenAdapter As New DSHeckTickTableAdapters.TAZeiten
                    Dim locZeitenTable As New DSHeckTick.ZeitenDataTable
                    locZeitenAdapter.Connection = locConn
                    locZeitenAdapter.Fill(locZeitenTable)
                    dgvData.DataSource = locZeitenTable
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler bei der Datenbankabfrage!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Using
    End Sub

    Private Sub DatenbankNeuAufsetzen()
        'SQL Server-Instanz abfragen
        Dim locSqlInstanceConnDialog As New ADSqlInstanceConnectionDialog
        Dim locConnBuilder As SqlConnectionStringBuilder
        Dim locDr As DialogResult
        Dim locCmd As SqlCommand

        locConnBuilder = locSqlInstanceConnDialog.GetConnectionBuilder
        If locConnBuilder Is Nothing Then
            Me.Close()
            Return
        End If

        'Verbindung zur Datenbank aufbauen
        Dim locConn As New SqlConnection(locConnBuilder.ToString)

        'Mit Using sichergehen, dass die Verbindung auf jeden Fall wieder
        'geschlossen wird.
        Using locConn

            'Sicher ist sicher!
            Try
                locConn.Open()
            Catch ex As Exception
                'Ups - Verbindung ist fehlgeschlagen!
                MessageBox.Show("Die Verbindung zur Datenbank konnte nicht geöffnet werden!" & _
                                vbNewLine & vbNewLine & ex.Message, "Fehler beim Verbindungsaufbau!", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try

            'Feststellen, ob die Datenbank bereits existiert
            locCmd = New SqlCommand("SELECT * FROM Sys.Databases WHERE Name='HeckTick'", locConn)
            Dim locReader As SqlDataReader = locCmd.ExecuteReader
            If locReader.HasRows Then
                locDr = MessageBox.Show("Die Demo-Datenbank für dieses Projekt existiert bereits!" & vbNewLine & _
                                        "Möchten Sie die Datenbank löschen und eine neue anlegen?", _
                                        "Alte Datenbank löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                        MessageBoxDefaultButton.Button2)

                If locDr = Windows.Forms.DialogResult.Yes Then

                    'Reader schließen, sonst "geht" kein neuer Command.
                    locReader.Close()

                    'Alle anderen Verbindungen sausen lassen - falls beispielsweise noch
                    'der Visual Studio Server Explorer eine Verbindung auf sie hat.
                    locCmd = New SqlCommand("ALTER DATABASE HeckTick SET Single_User WITH ROLLBACK IMMEDIATE", locConn)
                    Try
                        locCmd.ExecuteScalar()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Fehler bei der Command-Ausführung:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End Try

                    'Datenbank "fallen lassen", also ohne Wenn und Aber löschen...
                    locCmd = New SqlCommand("DROP DATABASE HeckTick", locConn)
                    Try
                        locCmd.ExecuteScalar()
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Fehler bei der Command-Ausführung:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return
                    End Try
                End If
                locReader.Close()
            End If
        End Using


        Using locConn
            'Sicher ist schon wieder sicher!
            locConn = New SqlConnection(locConnBuilder.ToString)
            Try
                locConn.Open()
            Catch ex As Exception
                'Ups - Verbindung ist fehlgeschlagen!
                MessageBox.Show("Die Verbindung zur Datenbank konnte nicht geöffnet werden!" & _
                                vbNewLine & vbNewLine & ex.Message, "Fehler beim Verbindungsaufbau!", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try

            Try
                locCmd = New SqlCommand("CREATE DATABASE Hecktick", locConn)
                locCmd.ExecuteScalar()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler beim Anlegen der Datenbank:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

            locConnBuilder.InitialCatalog = "Hecktick"

            'Datenbanknamen in der Verbindungzeichenfolge ergänzen
            My.Settings.HeckTickConnectionString = locConnBuilder.ConnectionString
        End Using

        locConn = New SqlConnection(My.Settings.HeckTickConnectionString)

        'Neue Verbindung herstellen, in der jetzt auch die Datenbank berücksichtigt wird,
        'damit sich alle folgenden Befehle an den SQL-Server nicht nur auf dessen Instanz
        'selbst, sondern auch auf die Datenbank beziehen.
        Using locConn
            'Sicher ist schon wieder sicher!
            Try
                locConn.Open()
            Catch ex As Exception
                'Ups - Verbindung ist fehlgeschlagen!
                MessageBox.Show("Die Verbindung zur Datenbank konnte nicht geöffnet werden!" & _
                                vbNewLine & vbNewLine & ex.Message, "Fehler beim Verbindungsaufbau!", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try

            'Die Befehle zum Erstellen der Datenbank aus den Settings lesen.
            'GO trennt die einzelnen Befehle, die jeder für sich zur Datenbankerstellung
            'als Befehl gesendet werden müssen.
            Dim locCS As String = My.Settings.HeckTickDBCreationCommandText

            'Befehle, die durch 'GO {cr+lf}' getrennt sind, auseinander dröseln
            Dim locCommands As String() = locCS.Split(New String() {"GO" & vbNewLine}, _
                                                StringSplitOptions.RemoveEmptyEntries)

            For Each locSingleCommand As String In locCommands
                locCmd = New SqlCommand(locSingleCommand, locConn)
                Try
                    locCmd.ExecuteScalar()
                Catch ex As Exception
                    Debug.Print(ex.Message)
                End Try
            Next
        End Using

        My.Settings.AppAnwendungZuvorGestartet = True

        locDr = MessageBox.Show("Sollen Demo-Daten generiert werden?", _
                    "Demodaten generieren?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                     MessageBoxDefaultButton.Button1)
        If locDr = Windows.Forms.DialogResult.Yes Then
            Dim locFrm As New frmDemoDaten
            locFrm.ShowDialog()
        End If
        AnsichtManager()
    End Sub

    Private Sub tsmDemodatenErstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDemodatenErstellen.Click
        Dim locFrm As New frmDemoDaten
        locFrm.ShowDialog()
        AnsichtManager()
    End Sub

    Private Sub tsmDBLöschenUndErstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmDBLöschenUndErstellen.Click
        DatenbankNeuAufsetzen()
    End Sub

    Private Sub tsmSQLInstanzTesten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmSQLInstanzTesten.Click

    End Sub
End Class
