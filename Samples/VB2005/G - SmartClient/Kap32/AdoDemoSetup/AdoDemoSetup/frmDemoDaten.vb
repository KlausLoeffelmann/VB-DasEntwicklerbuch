Imports System.Data.SqlClient

Public Class frmDemoDaten

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        dtpVon.Value = Date.Now
        dtpBis.Value = Date.Now.AddDays(14)
    End Sub

    Private Sub dtpBis_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpBis.ValueChanged
        If dtpBis.Value < dtpVon.Value Then
            dtpVon.Value = dtpBis.Value.AddDays(-1)
        End If
    End Sub

    Private Sub dtpVon_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVon.ValueChanged
        If dtpVon.Value > dtpBis.Value Then
            dtpBis.Value = dtpVon.Value.AddDays(1)
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnDatenErzeugen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatenErzeugen.Click

        Dim locConn As New SqlConnection(My.Settings.HeckTickConnectionString)
        Try
            locConn.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler beim Herstellen der Verbindung:", _
                             MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End Try

        Using locConn

            lblStatustext.Text = "Vorhandene Daten l�schen..."
            lblStatustext.Refresh()

            Try
                Dim locCmd As New SqlCommand("DELETE From Zeiten", locConn)
                locCmd.ExecuteNonQuery()

                locCmd = New SqlCommand("DELETE From Berater", locConn)
                locCmd.ExecuteNonQuery()

                locCmd = New SqlCommand("DELETE From Projekte", locConn)
                locCmd.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Fehler beim L�schen der Daten:", _
                                 MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try

            ProjekteErstellen(locConn)
            BeraterdatenErstellen(20, locConn)
            ZeitdatenErstellen(dtpVon.Value, dtpBis.Value, False, False, locConn)
        End Using

    End Sub

    Private Sub ProjekteErstellen(ByVal conn As SqlConnection)

        Dim locProjekteAdapter As New DSHeckTickTableAdapters.TAProjekte()
        Dim locProjekteTable As New DSHeckTick.ProjekteDataTable
        locProjekteAdapter.Connection = conn

        locProjekteTable.AddProjekteRow("Visual Basic 2005 Entwicklerbuch", _
                                        "Erstellung eines 1.100 Seiten Buches f�r Microsoft Press", _
                                        #2/1/2005#, #3/15/2006#, "Office")

        locProjekteTable.AddProjekteRow("Adresso.NET", _
                                        "Erstellung einer Client-/Server-f�higen Adressenverwaltung", _
                                        #12/24/2005#, #6/30/2006#, "Office")

        locProjekteTable.AddProjekteRow("ASP.NET Fachlektorat", _
                                        "Fachlektorat von Holger Schwichtenbergs ASP.NET-Buch", _
                                        #12/24/2005#, #6/30/2006#, "Office")

        locProjekteTable.AddProjekteRow("HeckTick", _
                                        "Erstellung einer Client-/Server-f�higen Software zur Arbeitsstundenerfassung und Auswertung.", _
                                        #12/24/2005#, #6/30/2006#, "Vor Ort")
        locProjekteAdapter.Update(locProjekteTable)
    End Sub

    Private Sub BeraterdatenErstellen(ByVal Anzahl As Integer, ByVal Conn As SqlConnection)

        Dim locRandom As New Random(Now.Millisecond)

        Dim locTa As New DSHeckTickTableAdapters.TABerater()
        locTa.Connection = Conn

        Dim locNachnamen As String() = {"Heckhuis", "L�ffelmann", "Thiemann", "M�ller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "V�llers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "H�rstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locVornamen As String() = {"J�rgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "Jos�", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}

        Dim locStra�en As String() = {"Kurgartenweg", "Parkstra�e", "Alter Postweg", "Stadtstra�e", "Aue", _
                    "Windpockenallee", "Hauptstra�e", "S�dring", "Nordring", "Himmelspforte", _
                    "Thiemannweg", "Ausfallstra�e", "Absturzpfad", "Crash Ave", "Main Road", "Am Tor", _
                    "Am Brunnen", "Dorfplatz", "Dorfgasse", "Gassenstra�e", "Reiterweg", "Kleine Gasse", _
                    "Lange Stra�e", "Altstadtplatz"}

        Dim locSt�dte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "M�nchen", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschlei�heim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        'Alle Vorhandenen Daten l�schen
        lblStatustext.Text = "Vorhandene Beraterdaten l�schen..."
        lblStatustext.Refresh()

        lblStatustext.Text = "Beraterdaten generieren..."
        lblStatustext.Refresh()
        pbDBSetupFortschritt.Maximum = Anzahl
        For i As Integer = 1 To Anzahl
            Dim locName, locVorname As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locTa.Insert(locName, locVorname, locStra�en(locRandom.Next(locStra�en.Length - 1)), _
                                        locRandom.Next(99999).ToString("00000"), _
                                        locSt�dte(locRandom.Next(locSt�dte.Length - 1)))

            pbDBSetupFortschritt.Value = i
            pbDBSetupFortschritt.Refresh()
        Next
    End Sub

    Private Sub ZeitdatenErstellen(ByVal VonDatum As Date, ByVal BisDatum As Date, _
                                    ByVal SamstagsArbeiten As Boolean, ByVal SonntagsArbeiten As Boolean, _
                                    ByVal Conn As SqlConnection)

        Dim locArbeitsbegin As Date = #7:00:00 AM#


        Dim locBeraterTable As New DSHeckTick.BeraterDataTable
        Dim locBeraterAdapter As New DSHeckTickTableAdapters.TABerater

        Dim locProjekteTable As New DSHeckTick.ProjekteDataTable
        Dim locProjekteAdapter As New DSHeckTickTableAdapters.TAProjekte()

        Dim locZeitenAdapter As New DSHeckTickTableAdapters.TAZeiten()

        Dim locRandom As New Random(Now.Millisecond)
        Dim locStartZeit, locEndzeit As Date
        Dim locDauer As Integer
        Dim locProgressZ�hler As Integer

        Dim locT�tigkeiten As String() = {"Dokumentation �berarbeitet: Tabellen und Bildunterschriften kontrolliert.", _
                                          "Dokumentation produziert: PS-Dateien und PDF-Dateien aus allen Kapiteln produziert", _
                                          "Programmieraufwand: Abstraktion f�r Mockup; XML-Tags f�r sp�tere Dokumentation.", _
                                          "Organisation: Rekrutierung weiterer Mitarbeiter", _
                                          "Softwareentwicklung: Ausarbeitung von Klassenalgorithmen"}

        locBeraterAdapter.Connection = Conn
        locProjekteAdapter.Connection = Conn
        locZeitenAdapter.Connection = Conn

        locBeraterAdapter.Fill(locBeraterTable)
        locProjekteAdapter.Fill(locProjekteTable)

        Dim locTagez�hler As Date = VonDatum.Date
        pbDBSetupFortschritt.Maximum = CInt(BisDatum.Subtract(VonDatum).TotalDays)

        Do While locTagez�hler <= BisDatum.Date


            lblStatustext.Text = "Zeitdaten generieren f�r:" + vbNewLine + _
                                  locTagez�hler.ToString("dddd, dd.MM.yyyy")
            lblStatustext.Refresh()
            pbDBSetupFortschritt.Value = locProgressZ�hler
            pbDBSetupFortschritt.Refresh()
            locProgressZ�hler += 1

            If (Not SamstagsArbeiten) And Weekday(locTagez�hler) = 7 Then
                locTagez�hler = locTagez�hler.AddDays(1)
                Continue Do
            End If

            If (Not SonntagsArbeiten) And Weekday(locTagez�hler) = 1 Then
                locTagez�hler = locTagez�hler.AddDays(1)
                Continue Do
            End If


            'Alle Berater durchlaufen
            For Each locBerater As DSHeckTick.BeraterRow In locBeraterTable.Rows
                '10% Krankheitsstand/Urlaub sind realistisch
                If locRandom.Next(100) < 90 Then

                    'Zufallsprojekt rauspicken
                    Dim locProjekt As DSHeckTick.ProjekteRow

                    Dim locZeitOffset As Date = locArbeitsbegin.AddMinutes(locRandom.Next(-10, 120))
                    locStartZeit = locTagez�hler.Add(locZeitOffset.TimeOfDay)

                    'Morgens zwei Buchungen? (Wahrscheinlich daf�r ist 1:4)
                    If locRandom.Next(0, 3) = 2 Then
                        'Gleitzeit: Bis zu 120 Minuten sp�ter anfangen
                        locDauer = 100 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                        locStartZeit = locEndzeit
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                    Else
                        locDauer = 200 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                    End If

                    'Nachmittags zwei Buchungen? (Wahrscheinlich daf�r ist ebenfalls 1:4)
                    If locRandom.Next(0, 3) = 2 Then
                        locStartZeit = locEndzeit.AddMinutes(locRandom.Next(120)) ' Zuf�llige Pause einbauen
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                        locStartZeit = locEndzeit
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                    Else
                        locStartZeit = locEndzeit.AddMinutes(locRandom.Next(120)) ' Zuf�llige Pause einbauen
                        locDauer = 200 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locProjekt = locProjekteTable(locRandom.Next(0, locProjekteTable.Count - 1))
                        locZeitenAdapter.Insert(locProjekt.IDProjekte, locBerater.IDBerater, _
                                                    locStartZeit, locEndzeit, locT�tigkeiten(locRandom.Next(4)))
                    End If
                End If

            Next
            locTagez�hler = locTagez�hler.AddDays(1)
            'MessageQueue Zeit zum Luft holen geben!
            Application.DoEvents()
        Loop
    End Sub
End Class