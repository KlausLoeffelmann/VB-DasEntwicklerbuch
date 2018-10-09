Public Class frmMain

    Private WithEvents myTimer As Timer
    Private WithEvents myTerminliste As Terminliste

    'Die Hintergrundfarbe der Uhr, die bei 
    'anhaltendem Alarm wechselt.
    Private myAktuelleFarbe As Color

    'Alarmdauer in 500ms-Schritten (=25 Sekunden).
    Private myAlarmDauer As Integer = 50

    'Z�hler f�r die Dauer des Restalarms.
    Private myAlarmDownCounter As Integer

    'True: Alarm ist gerade aktiv --> die Uhr blinkt.
    Private myAlarmStatus As Boolean

    ' Ist dieser String nicht Nothing wird eine Textmeldung in der Uhr
    'angezeigt, ansonsten nicht.
    Private myLetzteAlarmmeldung As String

    Sub New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        'Diesen Time ben�tigen wir zum Darstellen der Uhr 
        'und zum Blinken der Uhr bei anhaltendem Alarm
        myTimer = New Timer()
        myTimer.Interval = 500
        myTimer.Start()

        'Standardhintergrundfarbe der Uhr ist wei�.
        myAktuelleFarbe = Color.White

        'Terminliste ist zun�chst noch leer.
        myTerminliste = New Terminliste
    End Sub

    'Ereignisbehandlungsroutine, die ausgel�st wird,
    'wenn der Alarmgeber Alarm signalisiert, weil eine
    'bestimmte Uhrzeit erreicht wurde.
    Private Sub myAlarmgeber_Alarm(ByVal Sender As Object, ByVal e As AlarmEventArgs) Handles myTerminliste.Alarm
        'Wecker schellt!
        myAlarmStatus = True
        'Und zwar so lange.
        myAlarmDownCounter = myAlarmDauer
        'Abschalten sollten wir das Schellen k�nnen.
        btnAlarmAusschalten.Enabled = True

        'Hochgereichten Meldungstext setzen
        myLetzteAlarmmeldung = e.AlarmText

        'Aus Liste l�schen
        lstTermine.Items.Remove(Sender)

        'Aus Terminliste l�schen
        myTerminliste.Remove(DirectCast(Sender, Alarmgeber))
    End Sub

    'Ereignisbehandlungsroutine, die ausgel�st wird,
    'wenn der Inhalt der Picturebox neugezeichnet werden soll.
    Private Sub picWecker_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) _
                    Handles picWecker.Paint

        If myTerminliste IsNot Nothing AndAlso myTerminliste.Count > 0 Then
            'Wenn es Termine gibt, dann die Markierung des n�chsten einzeichnen
            DrawClock(e.Graphics, Date.Now, myTerminliste.N�chsterTermin, _
                      myLetzteAlarmmeldung, myAktuelleFarbe)
        Else
            DrawClock(e.Graphics, Date.Now, myLetzteAlarmmeldung, myAktuelleFarbe)
        End If
    End Sub

    'Wird vom Basisklassenteile von System.Windows.Forms.Form angesprungen,
    'wenn sich das Formular vergr��ert oder verkleinert hat.
    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

        'Wichtig: Basisfunktion aufrufen, sonst wird das 
        'Resize-Ereignis nicht mehr ausgel�st!
        MyBase.OnResize(e)

        'Inhalt der PictureBox neuzeichnen, 
        'wenn sich die Gr��e des Formulats ge�ndert hat.
        picWecker.Invalidate()
    End Sub

    'Ereignisbehandlungsroutine, die ausgel�st wird,
    'wenn der Timer abgelaufen ist. Dies passiert 
    'alle 500 Millisekunden, und wir zeichnen dann
    'die komplette Uhr neu - ber�cksichtigen dabei
    'auch das Hintergrundblinken, falls der "Wecker 
    'gerade schellt".
    Private Sub myTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles myTimer.Tick

        'L�uft der Alarm gerade?
        If myAlarmStatus Then

            'Ja, Farben alle 500 ms wechseln
            If myAktuelleFarbe = Color.White Then
                myAktuelleFarbe = Color.Red
            Else
                myAktuelleFarbe = Color.White
            End If

            'Alarmdauerz�hler vermindern
            myAlarmDownCounter -= 1
            If myAlarmDownCounter = 0 Then

                'Alarm ausschalten, wenn dieser abgelaufen ist.
                AlarmAusschalten(True)
            End If
        End If

        'Ganze Uhr in jedem Fall neuzeichnen.
        picWecker.Invalidate()
    End Sub

    'Wird aufgerufen, wenn der Anwender die Hinzuf�gen-Schaltfl�che bet�tigt hat
    Private Sub btnHinzuf�gen_Click(ByVal sender As System.Object, _
                    ByVal e As System.EventArgs) Handles btnHinzuf�gen.Click

        Dim locAlarmzeit As Date

        'Zeit und Termingrund aus den TextBox-Steuerelementen holen.
        If Date.TryParse(mtbAlarmzeit.Text, locAlarmzeit) And _
            Not String.IsNullOrEmpty(txtGrund.Text) Then

            'Neues Alarmgeber-Objekt instanzieren, das wir anschlie�ed
            'direkt zur Listbox...
            Dim locAlarm As New Alarmgeber(locAlarmzeit, txtGrund.Text, True)
            lstTermine.Items.Add(locAlarm)

            '...sowie zur Terminliste hinzuf�gen.
            myTerminliste.Add(locAlarm)

            'Uhr neuzeichnen, damit die Weckzeit des n�chsten Termins als
            'roter Strich ins Ziffernblatt kommt!
            picWecker.Invalidate()
        Else

            'Ups! Solch eine Uhrzeit gibt es nicht - TryParse
            'ist fehlgeschlagen.
            MessageBox.Show("Bitte �berpr�fen Sie die Eingabe auf Fehler!")
        End If
    End Sub

    'Wenn es einen selektierten Termin gibt,
    'dann kann die L�schen-Schaltfl�che aktiviert werden...
    Private Sub lstTermine_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTermine.SelectedIndexChanged
        If lstTermine.SelectedIndex > -1 Then
            btnL�schen.Enabled = True
        Else
            '...anderenfalls nicht.
            btnL�schen.Enabled = False
        End If
    End Sub

    Private Sub btnL�schen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnL�schen.Click
        Dim locTermin As Alarmgeber

        'Zu l�schenden Termin aus der Liste holen
        locTermin = DirectCast(lstTermine.SelectedItem, Alarmgeber)

        'Aus der Liste l�schen
        lstTermine.Items.Remove(locTermin)

        'Und auch aus der Terminliste l�schen.
        myTerminliste.Remove(locTermin)
    End Sub

    'Schaltet den Alarm aus.
    Private Sub AlarmAusschalten(ByVal NeuAktivieren As Boolean)

        'Alarmstatus zur�cksetzen
        myAlarmStatus = False

        '"Snooze"-Knopf deaktivieren.
        btnAlarmAusschalten.Enabled = False

        'Hintergrund ist wieder weis
        myAktuelleFarbe = Color.White

        'Alarmmeldungstext zur�cksetzen
        myLetzteAlarmmeldung = Nothing
    End Sub

    '"Snooze"-Schaltfl�che wurde gedr�ckt...
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
        Dim locGr��e As SizeF

        Dim locUhrAusma�e As RectangleF = New RectangleF( _
            locHalbeStiftBreite, locHalbeStiftBreite, _
            (picWecker.ClientSize.Width - 1) - locStiftBreite, _
            (picWecker.ClientSize.Height - 1) - locStiftBreite)

        'Mitte finden
        locMitte.X = picWecker.ClientSize.Width / 2.0F
        locMitte.Y = picWecker.ClientSize.Height / 2.0F

        'Gr��e abz�glich Uhrenrand
        locGr��e.Width = locUhrAusma�e.Width / 2 - 5
        locGr��e.Height = locUhrAusma�e.Height / 2 - 5

        'AntiAlias (Kanteng�ttung) einschalten
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        'Hintergrund in angegebener Farbe setzen
        g.Clear(Hintergrund)

        '�u�eren Uhrenkreis zeichnen
        g.DrawEllipse(New Pen(Color.Black, locStiftBreite), locUhrAusma�e)

        'Zifferblatt malen
        Dim locAufschlag As Single
        For locWinkel As Single = 0 To 359 Step 30
            If locWinkel = 0 Or locWinkel = 90 Or locWinkel = 180 Or locWinkel = 270 Then
                locAufschlag = 20
            Else
                locAufschlag = 10
            End If

            Dim locPcStart As New PolarCoordinate(locMitte, locGr��e.Width - 5, locGr��e.Height - 5, locWinkel)
            Dim locPcEnd As New PolarCoordinate(locMitte, locGr��e.Width - locAufschlag, _
                                locGr��e.Height - locAufschlag, locWinkel)
            g.DrawLine(Pens.Black, locPcStart.Cartesian.X, _
                                  locPcStart.Cartesian.Y, _
                                  locPcEnd.Cartesian.X, _
                                  locPcEnd.Cartesian.Y)
        Next

        'Zeiger malen

        'Parameter f�r Stundenzeiger
        Dim locStundenZeigerWinkel As Single = Zeit.Hour
        If locStundenZeigerWinkel > 12 Then
            locStundenZeigerWinkel -= 12
        End If
        locStundenZeigerWinkel *= 30.0F
        locStundenZeigerWinkel += (Zeit.Minute / 2.0F)
        locStundenZeigerWinkel -= 90


        'Parameter f�r Alarmmarkierung
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

        'Parameter f�r Minutenzeiger
        Dim locMinutenZeigerWinkel As Single = Zeit.Minute
        locMinutenZeigerWinkel *= 6
        locMinutenZeigerWinkel -= 90


        'Parameter f�r Sekundenzeiger
        Dim locSekundenZeigerWInkel As Single = Zeit.Second
        locSekundenZeigerWInkel *= 6
        locSekundenZeigerWInkel -= 90

        'Stundenzeiger zuerst malen ...
        Dim locZeigerStart As New PolarCoordinate(locMitte, 0, 0, locStundenZeigerWinkel)
        Dim locZeigerEnde As New PolarCoordinate(locMitte, locGr��e.Width / 2, locGr��e.Height / 2, locStundenZeigerWinkel)
        g.DrawLine(New Pen(Color.Blue, 5), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... dann den Minutenzeiger ...
        locZeigerStart = New PolarCoordinate(locMitte, 0, 0, locMinutenZeigerWinkel)
        locZeigerEnde = New PolarCoordinate(locMitte, locGr��e.Width - 25, locGr��e.Height - 25, locMinutenZeigerWinkel)
        g.DrawLine(New Pen(Color.Blue, 3), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... dann den Sekundenzeiger ...
        locZeigerStart = New PolarCoordinate(locMitte, 0, 0, locSekundenZeigerWInkel)
        locZeigerEnde = New PolarCoordinate(locMitte, locGr��e.Width - 20, locGr��e.Height - 20, locSekundenZeigerWInkel)
        g.DrawLine(New Pen(Color.Black, 1), locZeigerStart.Cartesian.X, _
                                           locZeigerStart.Cartesian.Y, _
                                           locZeigerEnde.Cartesian.X, _
                                           locZeigerEnde.Cartesian.Y)

        '... und falls eine Markierungszeit eingetragen werden soll, auch die malen!
        If Markierungszeit.HasValue Then
            locZeigerStart = New PolarCoordinate(locMitte, locGr��e.Width / 4 * 3, locGr��e.Height / 4 * 3, locMarkierungszeitWinkel)
            locZeigerEnde = New PolarCoordinate(locMitte, locGr��e.Width - 5, locGr��e.Height - 5, locMarkierungszeitWinkel)
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
