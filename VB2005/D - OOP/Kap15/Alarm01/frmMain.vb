Public Class frmMain

    Private WithEvents myTimer As Timer
    Private WithEvents myAlarmgeber As EinfacherAlarmgeber

    Private myAktuelleFarbe As Color
    Private myAlarmDauer As Integer = 50
    Private myAlarmDownCounter As Integer
    Private myAlarmStatus As Boolean

    Sub New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' F�gen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        myTimer = New Timer()
        myTimer.Interval = 500
        myTimer.Start()
        myAktuelleFarbe = Color.White
    End Sub

    'Ereignisbehandlungsroutine, die ausgel�st wird,
    'wenn der Alarmgeber Alarm signalisiert, weil eine
    'bestimmte Uhrzeit erreicht wurde.
    Private Sub myAlarmgeber_Alarm(ByVal Sender As Object, ByVal e As AlarmEventArgs) Handles myAlarmgeber.Alarm
        'Wecker schellt!
        myAlarmStatus = True
        'Und zwar so lange.
        myAlarmDownCounter = myAlarmDauer
        'Abschalten sollten wir das Schellen k�nnen.
        btnAusschalten.Enabled = True
        'Und morgen um die gleiche Zeit, soll er wieder schellen.
        e.Neustellen = True
    End Sub

    'Ereignisbehandlungsroutine, die ausgel�st wird,
    'wenn der Inhalt der Picturebox neugezeichnet werden soll.
    Private Sub picWecker_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) _
                    Handles picWecker.Paint
        If myAlarmgeber IsNot Nothing AndAlso myAlarmgeber.AlarmAktiviert Then
            DrawClock(e.Graphics, Date.Now, myAlarmgeber.Alarmzeit, myAktuelleFarbe)
        Else
            DrawClock(e.Graphics, Date.Now, myAktuelleFarbe)
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

    'Schaltet den Alarm aus.
    Private Sub AlarmAusschalten(ByVal NeuAktivieren As Boolean)

        'Alarmstatus zur�cksetzen
        myAlarmStatus = False

        '"Snooze"-Knopf deaktivieren.
        btnAusschalten.Enabled = False

        'Hintergrund ist wieder weis
        myAktuelleFarbe = Color.White
    End Sub

    '"Snooze"-Schaltfl�che wurde gedr�ckt...
    Private Sub btnAusschalten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAusschalten.Click
        'also Alarm ausschalten, aber (True) f�r den n�chsten
        'Tag die Weckzeit wieder vorsehen.
        AlarmAusschalten(True)
    End Sub

    'Text der Alarmzeit hat sich ge�ndert...
    Private Sub mtbAlarmzeit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbAlarmzeit.TextChanged
        'Alarm ausschalten.
        chkAlarmAktivieren.Checked = False
    End Sub

    'Der Wecker wird komplett ein- oder ausgeschaltet.
    Private Sub chkAlarmAktivieren_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlarmAktivieren.CheckedChanged
        'Hier wird er eingeschaltet...
        If chkAlarmAktivieren.Checked Then
            Dim locAlarm As Date
            'Zeit aus der TextBox holen.
            If Date.TryParse(mtbAlarmzeit.Text, locAlarm) Then
                'Neues Alarmgeber-Objekt instanzieren, dessen
                'Ereignisse wir mitbekommen, da es WithEvents
                'deklariert wurde.
                myAlarmgeber = New EinfacherAlarmgeber(locAlarm, True)
                'Uhr Neuzeichnen, damit die Weckzeit als
                'roter Strich ins Ziffernblatt kommt!
                picWecker.Invalidate()
            Else
                'Ups! Solch eine Uhrzeit gibt es nicht - TryParse
                'ist fehlgeschlagen.
                MessageBox.Show("Bitte �berpr�fen Sie das Eingabeformat!")
            End If
        Else
            'Alarmgeber wird abgeschaltet.
            AlarmAusschalten(False)
            'Wir brauchen auch keine Ereignisse - es gibt nichts zum Wecken!
            myAlarmgeber = Nothing
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

#Region "Malcode"
    Private Sub DrawClock(ByVal g As Graphics, ByVal Zeit As Date, ByVal Hintergrund As Color)
        DrawClock(g, Zeit, Nothing, Hintergrund)
    End Sub

    Private Sub DrawClock(ByVal g As Graphics, ByVal Zeit As Date, ByVal Markierungszeit As Nullable(Of Date), ByVal Hintergrund As Color)

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
    End Sub
#End Region
End Class
