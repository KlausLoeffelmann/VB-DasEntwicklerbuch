Public Class frmMain

    Private WithEvents myTimer As Timer
    Private WithEvents myTerminliste As Terminliste

    'Die Hintergrundfarbe der Uhr, die bei 
    'anhaltendem Alarm wechselt.
    Private myAktuelleFarbe As Color

    'Alarmdauer in 500ms-Schritten (=25 Sekunden).
    Private myAlarmDauer As Integer = 50

    'Zähler für die Dauer des Restalarms.
    Private myAlarmDownCounter As Integer

    'True: Alarm ist gerade aktiv --> die Uhr blinkt.
    Private myAlarmStatus As Boolean

    ' Ist dieser String nicht Nothing wird eine Textmeldung in der Uhr
    'angezeigt, ansonsten nicht.
    Private myLetzteAlarmmeldung As String

    Sub New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Diesen Time benötigen wir zum Darstellen der Uhr 
        'und zum Blinken der Uhr bei anhaltendem Alarm
        myTimer = New Timer()
        myTimer.Interval = 500
        myTimer.Start()

        'Standardhintergrundfarbe der Uhr ist weiß.
        myAktuelleFarbe = Color.White

        'Terminliste ist zunächst noch leer.
        myTerminliste = New Terminliste
    End Sub

    'Ereignisbehandlungsroutine, die ausgelöst wird,
    'wenn der Alarmgeber Alarm signalisiert, weil eine
    'bestimmte Uhrzeit erreicht wurde.
    Private Sub myAlarmgeber_Alarm(ByVal Sender As Object, ByVal e As AlarmEventArgs) Handles myTerminliste.Alarm
        'Wecker schellt!
        myAlarmStatus = True
        'Und zwar so lange.
        myAlarmDownCounter = myAlarmDauer
        'Abschalten sollten wir das Schellen können.
        btnAlarmAusschalten.Enabled = True

        'Hochgereichten Meldungstext setzen
        myLetzteAlarmmeldung = e.AlarmText

        'Aus Liste löschen
        lstTermine.Items.Remove(Sender)

        'Aus Terminliste löschen
        myTerminliste.Remove(DirectCast(Sender, Alarmgeber))
    End Sub

    'Ereignisbehandlungsroutine, die ausgelöst wird,
    'wenn der Inhalt der Picturebox neugezeichnet werden soll.
    Private Sub picWecker_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) _
                    Handles picWecker.Paint

        If myTerminliste IsNot Nothing AndAlso myTerminliste.Count > 0 Then
            'Wenn es Termine gibt, dann die Markierung des nächsten einzeichnen
            DrawClock(e.Graphics, Date.Now, myTerminliste.NächsterTermin, _
                      myLetzteAlarmmeldung, myAktuelleFarbe)
        Else
            DrawClock(e.Graphics, Date.Now, myLetzteAlarmmeldung, myAktuelleFarbe)
        End If
    End Sub

    'Wird vom Basisklassenteile von System.Windows.Forms.Form angesprungen,
    'wenn sich das Formular vergrößert oder verkleinert hat.
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

        'Wichtig: Basisfunktion aufrufen, sonst wird das 
        'Resize-Ereignis nicht mehr ausgelöst!
        MyBase.OnResize(e)

        'Inhalt der PictureBox neuzeichnen, 
        'wenn sich die Größe des Formulats geändert hat.
        picWecker.Invalidate()
    End Sub

    'Ereignisbehandlungsroutine, die ausgelöst wird,
    'wenn der Timer abgelaufen ist. Dies passiert 
    'alle 500 Millisekunden, und wir zeichnen dann
    'die komplette Uhr neu - berücksichtigen dabei
    'auch das Hintergrundblinken, falls der "Wecker 
    'gerade schellt".
    Private Sub myTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTimer.Tick

        'Läuft der Alarm gerade?
        If myAlarmStatus Then

            'Ja, Farben alle 500 ms wechseln
            If myAktuelleFarbe = Color.White Then
                myAktuelleFarbe = Color.Red
            Else
                myAktuelleFarbe = Color.White
            End If

            'Alarmdauerzähler vermindern
            myAlarmDownCounter -= 1
            If myAlarmDownCounter = 0 Then

                'Alarm ausschalten, wenn dieser abgelaufen ist.
                AlarmAusschalten(True)
            End If
        End If

        'Ganze Uhr in jedem Fall neuzeichnen.
        picWecker.Invalidate()
    End Sub

    'Wird aufgerufen, wenn der Anwender die Hinzufügen-Schaltfläche betätigt hat
    Private Sub btnHinzufügen_Click(ByVal sender As System.Object, _
                    ByVal e As System.EventArgs) Handles btnHinzufügen.Click

        Dim locAlarmzeit As Date

        'Zeit und Termingrund aus den TextBox-Steuerelementen holen.
        If Date.TryParse(mtbAlarmzeit.Text, locAlarmzeit) And _
            Not String.IsNullOrEmpty(txtGrund.Text) Then

            'Neues Alarmgeber-Objekt instanzieren, das wir anschließed
            'direkt zur Listbox...
            Dim locAlarm As New Alarmgeber(locAlarmzeit, txtGrund.Text, True)
            lstTermine.Items.Add(locAlarm)

            '...sowie zur Terminliste hinzufügen.
            myTerminliste.Add(locAlarm)

            'Uhr neuzeichnen, damit die Weckzeit des nächsten Termins als
            'roter Strich ins Ziffernblatt kommt!
            picWecker.Invalidate()
        Else

            'Ups! Solch eine Uhrzeit gibt es nicht - TryParse
            'ist fehlgeschlagen.
            MessageBox.Show("Bitte überprüfen Sie die Eingabe auf Fehler!")
        End If
    End Sub

    'Wenn es einen selektierten Termin gibt,
    'dann kann die Löschen-Schaltfläche aktiviert werden...
    Private Sub lstTermine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTermine.SelectedIndexChanged
        If lstTermine.SelectedIndex > -1 Then
            btnLöschen.Enabled = True
        Else
            '...anderenfalls nicht.
            btnLöschen.Enabled = False
        End If
    End Sub

    Private Sub btnLöschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLöschen.Click
        Dim locTermin As Alarmgeber

        'Zu löschenden Termin aus der Liste holen
        locTermin = DirectCast(lstTermine.SelectedItem, Alarmgeber)

        'Aus der Liste löschen
        lstTermine.Items.Remove(locTermin)

        'Und auch aus der Terminliste löschen.
        myTerminliste.Remove(locTermin)
    End Sub

    'Schaltet den Alarm aus.
    Private Sub AlarmAusschalten(ByVal NeuAktivieren As Boolean)

        'Alarmstatus zurücksetzen
        myAlarmStatus = False

        '"Snooze"-Knopf deaktivieren.
        btnAlarmAusschalten.Enabled = False

        'Hintergrund ist wieder weis
        myAktuelleFarbe = Color.White

        'Alarmmeldungstext zurücksetzen
        myLetzteAlarmmeldung = Nothing
    End Sub

    '"Snooze"-Schaltfläche wurde gedrückt...
    Private Sub btnAlarmAusschalten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmAusschalten.Click

        'also Alarm ausschalten
        AlarmAusschalten(True)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

#Region "Codeteil, der die Uhr in die PictureBox zaubert"
    Private Sub DrawClock(ByVal g As Graphics, ByVal Zeit As Date, ByVal Meldungstext As String, ByVal Hintergrund As Color)
        DrawClock(g, Zeit, Nothing, Meldungstext, Hintergrund)
    End Sub

    Private Sub DrawClock(ByVal g As Graphics, ByVal Zeit As Date, ByVal Markierungszeit As Nullable(Of Date), _
                    ByVal Meldungstext As String, ByVal Hintergrund As Color)

        'Brushes und Pens erstellen
        Dim locStiftBreite As Single = 3
        Dim locHalbeStiftBreite As Single = locStiftBreite / 2
        Dim locMitte As PointF
        Dim locGröße As SizeF

        Dim locUhrAusmaße As RectangleF = New RectangleF( _
            locHalbeStiftBreite, locHalbeStiftBreite, _
            (picWecker.ClientSize.Width - 1) - locStiftBreite, _
            (picWecker.ClientSize.Height - 1) - locStiftBreite)

        'Mitte finden
        locMitte.X = picWecker.ClientSize.Width / 2.0F
        locMitte.Y = picWecker.ClientSize.Height / 2.0F

        'Größe abzüglich Uhrenrand
        locGröße.Width = locUhrAusmaße.Width / 2 - 5
        locGröße.Height = locUhrAusmaße.Height / 2 - 5

        'AntiAlias (Kantengättung) einschalten
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        'Hintergrund in angegebener Farbe setzen
        g.Clear(Hintergrund)

        'Äußeren Uhrenkreis zeichnen
        g.DrawEllipse(New Pen(Color.Black, locStiftBreite), locUhrAusmaße)

        'Zifferblatt malen
        Dim locAufschlag As Single
        For locWinkel As Single = 0 To 359 Step 30
            If locWinkel = 0 Or locWinkel = 90 Or locWinkel = 180 Or locWinkel = 270 Then
                locAufschlag = 20
            Else
                locAufschlag = 10
            End If

            Dim locPcStart As New PolarCoordinate(locMitte, locGröße.Width - 5, locGröße.Height - 5, locWinkel)
            Dim locPcEnd As New PolarCoordinate(locMitte, locGröße.Width - locAufschlag, _
                                locGröße.Height - locAufschlag, locWinkel)
            g.DrawLine(Pens.Black, locPcStart.Cartesian.X, _
                                  locPcStart.Cartesian.Y, _
                                  locPcEnd.Cartesian.X, _
                                  locPcEnd.Cartesian.Y)
        Next

        'Zeiger malen

        'Parameter für Stundenzeiger
        Dim locStundenZeigerWinkel As Single = Zeit.Hour
        If locStundenZeigerWinkel > 12 Then
            locStundenZeigerWinkel -= 12
        End If
        locStundenZeigerWinkel *= 30.0F
        locStundenZeigerWinkel += (Zeit.Minute / 2.0F)
        locStundenZeigerWinkel -= 90


        'Parameter für Alarmmarkierung
        Dim locMarkierungszeitWinkel As Single
        If Markierungszeit.HasValue Then
            locMarkierungszeitWinkel = Markierungszeit.Value.Hour
            If locMarkierungszeitWinkel > 12 Then
                locMarkierungszeitWinkel -= 12
            End If
            locMarkierungszeitWinkel *= 30.0F
            locMarkierungszeitWinkel += (Markierungszeit.Value.Minute / 2.0F)
            locMarkierungszeitWinkel -= 90
        End If

        'Parameter für Minutenzeiger
        Dim locMinutenZeigerWinkel As Single = Zeit.Minute
        locMinutenZeigerWinkel *= 6
        locMinutenZeigerWinkel -= 90


        'Parameter für Sekundenzeiger
        Dim locSekundenZeigerWInkel As Single = Zeit.Second
        locSekundenZeigerWInkel *= 6
        locSekundenZeigerWInkel -= 90

        'Stundenzeiger zuerst malen ...
        Dim locZeigerStart As New PolarCoordinate(locMitte, 0, 0, locStundenZeigerWinkel)
        Dim locZeigerEnde As New PolarCoordinate(locMitte, locGröße.Width / 2, locGröße.Height / 2, locStundenZeigerWinkel)
        g.DrawLine(New Pen(Color.Blue, 5), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... dann den Minutenzeiger ...
        locZeigerStart = New PolarCoordinate(locMitte, 0, 0, locMinutenZeigerWinkel)
        locZeigerEnde = New PolarCoordinate(locMitte, locGröße.Width - 25, locGröße.Height - 25, locMinutenZeigerWinkel)
        g.DrawLine(New Pen(Color.Blue, 3), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... dann den Sekundenzeiger ...
        locZeigerStart = New PolarCoordinate(locMitte, 0, 0, locSekundenZeigerWInkel)
        locZeigerEnde = New PolarCoordinate(locMitte, locGröße.Width - 20, locGröße.Height - 20, locSekundenZeigerWInkel)
        g.DrawLine(New Pen(Color.Black, 1), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... und falls eine Markierungszeit eingetragen werden soll, auch die malen!
        If Markierungszeit.HasValue Then
            locZeigerStart = New PolarCoordinate(locMitte, locGröße.Width / 4 * 3, locGröße.Height / 4 * 3, locMarkierungszeitWinkel)
            locZeigerEnde = New PolarCoordinate(locMitte, locGröße.Width - 5, locGröße.Height - 5, locMarkierungszeitWinkel)
            g.DrawLine(New Pen(Color.Red, 5), locZeigerStart.Cartesian.X, _
                                               locZeigerStart.Cartesian.Y, _
                                               locZeigerEnde.Cartesian.X, _
                                               locZeigerEnde.Cartesian.Y)

        End If

        'Neu in dieser Version: Der Meldungstext
        If Not String.IsNullOrEmpty(Meldungstext) Then
            lblAlarmmeldung.Text = Meldungstext
            lblAlarmmeldung.Visible = True
        Else
            lblAlarmmeldung.Visible = False
        End If
    End Sub
#End Region

End Class
