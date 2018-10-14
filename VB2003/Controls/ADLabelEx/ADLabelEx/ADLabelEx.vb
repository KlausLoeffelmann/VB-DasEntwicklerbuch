Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Text
Imports System.ComponentModel

<Designer("ActiveDev.ADLabelExDesigner")> _
Public Class ADLabelEx
    Inherits Control

    Private Const WS_BORDER As Integer = &H800000
    Private Const WS_EX_CLIENTEDGE As Integer = &H200
    Private Const myFlashInterval As Integer = 400

    Private Shared myFlashTimer As Timer

    Private myBorderstyle As BorderStyle
    Private myTextAlign As ContentAlignment
    Private myUseMnemonic As Boolean
    Private myDirectionVertical As Boolean

    Private myAutoHeight As Boolean
    Private myRequestedHeight As Integer
    Private myTextWrap As Boolean
    Private myTextTrimming As StringTrimming

    Sub New()
        MyBase.new()
        'Eigenschaften initialisieren
        myBorderstyle = BorderStyle.None
        myTextAlign = ContentAlignment.TopLeft
        myUseMnemonic = True
        myTextWrap = True
        myTextTrimming = StringTrimming.None
        myFlashBackColor = Color.Empty
        myFlashForeColor = Color.Empty

        'Windows-Stile setzen
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.DoubleBuffer, True)

        'Initialwert für die Höhe merken
        myRequestedHeight = Me.Height

        'Flash-Ereignishandler einrichten
        AddHandler FlashOn, AddressOf FlashOnHandler
        AddHandler FlashOff, AddressOf FlashOffHandler
    End Sub

    'Definiert die Parameter für das Anlegen des "Windows-Window"
    Protected Overrides ReadOnly Property CreateParams() As CreateParams

        Get
            Dim params1 As CreateParams
            Dim style1 As BorderStyle
            params1 = MyBase.CreateParams

            'Möglicherweise eingeschaltete BorderStyles ausschalten
            params1.ExStyle = (params1.ExStyle And Not WS_EX_CLIENTEDGE)
            params1.Style = (params1.Style And Not WS_BORDER)

            'Herausfinden, welcher Borderstyle eingeschaltet werden soll
            style1 = Me.myBorderstyle
            Select Case style1 - 1

                Case 0
                    'Simpler Rand
                    params1.Style = (params1.Style Or WS_BORDER)

                Case 1
                    'Drei-D-Rand
                    params1.ExStyle = (params1.ExStyle Or WS_EX_CLIENTEDGE)
            End Select
            Return params1
        End Get
    End Property

    '**************************************************************************************
    '*** Alles für das Zeichnen    ********************************************************
    '**************************************************************************************

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'DrawString arbeitet mit RectangleF, ClientRectangle mit Rectangle;
        'deswegen die Werte ins andere "Format" konvertieren.
        Dim locRectf As New RectangleF(0, 0, ClientSize.Width, ClientSize.Height)
        'StringFormat-Objekt für die Ausgabe des Strings erzeugen
        Dim locSf As StringFormat = CreateStringFormat()

        'Diese "Version" malen, wenn nicht geblinkt wird, oder gerade die Aus-Phase stattfindet
        If Not Flash Or Not myFlashState Then
            'Bei der Ausgabe des Strings "CR" anhängen, damit wird bei rechtsbündiger und
            'zentrierter Formatierung die richtige Stringlänge berücksichtigt.
            e.Graphics.DrawString(Text + vbCr, Font, New SolidBrush(ForeColor), locRectf, locSf)
        Else
            'Sonst die An-Phase zeichnen, mit FlashBackColor und FlashForeColor
            e.Graphics.Clear(FlashBackColor)
            e.Graphics.DrawString(Text + vbCr, Font, New SolidBrush(FlashForeColor), locRectf, locSf)
        End If
        'Kein Speicher verschwenden!
        locSf.Dispose()
    End Sub

    'Bastelt aus der Einstellung für ContentAlignment das StringFormat-Objekt zusammen,
    'über das diese Eigenschaft bei der Ausgabe mit DrawString umgesetzt wird.
    Protected Overridable Function StringFormatForAlignment(ByVal textAlign As ContentAlignment) As StringFormat

        Dim locStringFormat As New StringFormat
        If (textAlign And ContentAlignment.BottomLeft) = ContentAlignment.BottomLeft Or _
            (textAlign And ContentAlignment.MiddleLeft) = ContentAlignment.MiddleLeft Or _
            (textAlign And ContentAlignment.TopLeft) = ContentAlignment.TopLeft Then
            locStringFormat.Alignment = StringAlignment.Near
        ElseIf (textAlign And ContentAlignment.BottomRight) = ContentAlignment.BottomRight Or _
                (textAlign And ContentAlignment.MiddleRight) = ContentAlignment.MiddleRight Or _
                (textAlign And ContentAlignment.TopRight) = ContentAlignment.TopRight Then
            locStringFormat.Alignment = StringAlignment.Far
        ElseIf (textAlign And ContentAlignment.BottomCenter) = ContentAlignment.BottomCenter Or _
                (textAlign And ContentAlignment.MiddleCenter) = ContentAlignment.MiddleCenter Or _
                (textAlign And ContentAlignment.TopCenter) = ContentAlignment.TopCenter Then
            locStringFormat.Alignment = StringAlignment.Center
        End If

        If (textAlign And ContentAlignment.TopLeft) = ContentAlignment.TopLeft Or _
            (textAlign And ContentAlignment.TopRight) = ContentAlignment.TopRight Or _
            (textAlign And ContentAlignment.TopCenter) = ContentAlignment.TopCenter Then
            locStringFormat.LineAlignment = StringAlignment.Near
        ElseIf (textAlign And ContentAlignment.MiddleLeft) = ContentAlignment.MiddleLeft Or _
                (textAlign And ContentAlignment.MiddleRight) = ContentAlignment.MiddleRight Or _
                (textAlign And ContentAlignment.MiddleCenter) = ContentAlignment.MiddleCenter Then
            locStringFormat.LineAlignment = StringAlignment.Center
        ElseIf (textAlign And ContentAlignment.BottomLeft) = ContentAlignment.BottomLeft Or _
                (textAlign And ContentAlignment.BottomCenter) = ContentAlignment.BottomCenter Or _
                (textAlign And ContentAlignment.BottomRight) = ContentAlignment.BottomRight Then
            locStringFormat.LineAlignment = StringAlignment.Far
        End If
        Return locStringFormat

    End Function

    'Baut das StringFormat-Objekt zusammen und berücksichtigt nicht nur ContentAlignment,
    'sondern auch andere Eigenschaften des AdLabelEx-Steuerelementes
    Protected Overridable Function CreateStringFormat() As StringFormat

        Dim locStringFormat As StringFormat

        'Grundsätzliche Einstellungen aufgrund des ContentAlignment holen
        locStringFormat = StringFormatForAlignment(Me.TextAlign)

        'RightToLeft-Einstellung für Arabische Sprachen berücksichtigen
        If Me.RightToLeft = RightToLeft.Yes Then
            locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.DirectionRightToLeft
        End If

        'Zugriffstastenanzeige berücksichtigen
        If Not Me.UseMnemonic Then
            locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None
        Else
            If (Me.ShowKeyboardCues) Then
                locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
            Else
                locStringFormat.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide
            End If
        End If

        'If Me.AutoSize Then
        '    locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.MeasureTrailingSpaces
        'End If

        'Möglichst genaue Formatierung
        locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.FitBlackBox
        'LineLimit wird nicht berücksichtigt, wenn der Text nicht in den Rahmen passt
        locStringFormat.FormatFlags = locStringFormat.FormatFlags And Not StringFormatFlags.LineLimit

        'Text um 90 Grad im Uhrzeigersinn drehen?
        If DirectionVertical Then
            locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.DirectionVertical
        End If

        'Textwrapping eingeschaltet?
        If Not TextWrap Then
            locStringFormat.FormatFlags = locStringFormat.FormatFlags Or StringFormatFlags.NoWrap
        End If

        'Das Trimming definieren
        locStringFormat.Trimming = TextTrimming

        'Wert zurückgeben
        Return locStringFormat

    End Function

    'Misst die "echten" Ausmaße des Strings; wird für diese Version nicht mehr benötigt,
    'aus "Wissen-wie-es-funktioniert-Gründen" ist es nach wie vor im Code.
    <Obsolete("Diese Funktion wird in dieser Klasse nicht mehr verwendet")> _
    Private Function MeasureDisplayString(ByVal g As Graphics, ByVal text As String, ByVal font As Font) As Size

        Dim locFormat As New StringFormat
        Dim locRectF As New RectangleF(0, 0, ClientSize.Width, 10000)
        Dim locRanges As CharacterRange() = {New CharacterRange(0, text.Length)}
        Dim locRegions As Region()

        locFormat.SetMeasurableCharacterRanges(locRanges)
        locRegions = g.MeasureCharacterRanges(text, font, locRectF, locFormat)
        locRectF = locRegions(0).GetBounds(g)
        Return New Size(CInt(locRectF.Width), CInt(locRectF.Height))
    End Function


    '**************************************************************************************
    '*** Größenhandling            ********************************************************
    '**************************************************************************************

    'Die neue Höhe einstellen. Diese Methode wird aufgerufen, wenn sich eine Eigenschaft
    'geändert hat, die die Höhe des Steuerelementes beeinflusst, wenn AutoHeight eingeschaltet ist.
    Private Sub AdjustHeight()

        Dim locRequestedHeightTemp As Integer

        locRequestedHeightTemp = myRequestedHeight

        Try
            If AutoHeight Then
                MyBase.Size = New Size(Me.Size.Width, PreferedHeight)
            Else
                MyBase.Size = New Size(Me.Size.Width, locRequestedHeightTemp)
            End If
        Finally
            myRequestedHeight = locRequestedHeightTemp
        End Try
    End Sub

    'Ermittelt die Höhe des Textes bei einer bestimmten Breite. Diese Funktion
    'wird von AdjustHeight für die automatische Höhenanpassung des Steuerelementes verwendet.
    Public Overridable ReadOnly Property PreferedHeight() As Integer
        Get
            Dim locHeightToReturn As Integer
            If Me.Text = "" Then
                locHeightToReturn = Me.FontHeight
            Else
                Dim locG As Graphics
                Dim locSf As StringFormat
                Dim locSizeF As SizeF
                locG = Graphics.FromHwnd(Me.Handle) ' Graphics-Objekt erzeugen
                locSf = CreateStringFormat()        ' gleiches StringFormat wie beim Ausgaben
                'Texthöhe automatisch ermittelt. Das erreichen Sie, wenn Sie für die Höhe 0 übergeben.
                locSizeF = locG.MeasureString(Text, Font, New SizeF(ClientSize.Width, 0), locSf)
                'Immer nach unten abrunden!
                locHeightToReturn = CInt(Math.Ceiling(locSizeF.Height))
            End If
            'Falls es einen Borderstyle gibt, 2 Pixel draufrechnen, damit es nicht
            'zu gequetscht wird.
            If BorderStyle <> BorderStyle.None Then
                locHeightToReturn += 2
            End If
            Return locHeightToReturn
        End Get
    End Property

    'Setzt alle Ausmaße des Steuerelements oder nur bestimmte Größenkomponenten,
    'die von specified bestimmt werden.
    Protected Overrides Sub SetBoundsCore(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal specified As System.Windows.Forms.BoundsSpecified)

        Dim locRect As New Rectangle

        'Falls AutoHeight eingeschaltet ist...
        If AutoHeight Then
            '...und die Breite bestimmt werden soll...
            If (specified And BoundsSpecified.Width) = BoundsSpecified.Width Then
                '...dann die neue Breite im Steuerelement setzen...
                MyBase.SetBoundsCore(x, y, width, height, specified)
                '...jetzt muss aber auch die Höhe neu errechnet werden
                AdjustHeight()
                '...und wenn die zwischengespeicherte Höhe gesetzt war...
                If myRequestedHeight > 0 Then
                    'dann bricht der Vorgang hier ab. Anderenfalls wurde myRequestedHeight nicht
                    'initialisiert, und zwar dadurch, dass Height noch 0 war, als das
                    'Steuerelement erstellt wurde. Erst die erste Zuweisung der Size-Eigenschaft
                    'bestimmt die Höhe, die aber selbst mit SetBoundsCore gesetzt wird. Aus diesem
                    'Grund kann myRequestedHeight beim ersten Durchlauf keinen anderen Wert als
                    '0 haben und muss entsprechend initialisiert werden.
                    Return
                End If
            End If
        End If

        'Aktuelle Ausmaße zwischenspeichern
        locRect = Me.Bounds
        If (specified And BoundsSpecified.Height) = BoundsSpecified.Height Then
            'myRequestedHeight wird neu definiert, wenn die Höhe (zum Beispiel durch Size)
            'explizit zugewiesen wird. Am vom SetBoundsCore "verlangten" Height
            'ändert sich nur dann was...
            myRequestedHeight = height
        End If

        '...wenn AutoHeight eingeschaltet ist. Dann wird die Höhe des Steuerelementes auf die
        'gemessene Höhe des Textes festgeschrieben.
        If (Me.AutoHeight AndAlso (locRect.Height <> height)) Then
            height = Me.PreferedHeight
        End If

        'Basis aufrufen
        MyBase.SetBoundsCore(x, y, width, height, specified)

    End Sub

    '**************************************************************************************
    '*** Eigenschaften                      ***********************************************
    '**************************************************************************************

    <DefaultValue(GetType(Boolean), "True"), _
     Category("Darstellung"), _
     Description("Ist diese Eigenschaft gesetzt, wird das erste Zeichen, dem ein Kaufmannsund vorangeht, " + _
                 "als Zugriffstaste für das nächste Steuerelement in der TAB-Reihenfolge verwendet."), _
     Browsable(True)> _
    Public Property UseMnemonic() As Boolean
        Get
            Return myUseMnemonic
        End Get
        Set(ByVal Value As Boolean)
            myUseMnemonic = Value
            Me.Invalidate()
        End Set
    End Property

    <DefaultValue(GetType(BorderStyle), "None"), _
     Category("Darstellung"), _
     Description("Bestimmt die Art der Umrahmung des Steuerelementes."), _
     Browsable(True)> _
    Public Property BorderStyle() As BorderStyle
        Get
            Return myBorderstyle
        End Get
        Set(ByVal Value As BorderStyle)
            myBorderstyle = Value
            'Bewirkt, dass die CreateParams mit neuen Einstellungen aufgerufen, und
            'das Steuerelement neu gezeichnet wird.
            UpdateStyles()
            AdjustHeight()
        End Set
    End Property

    <DefaultValue(GetType(ContentAlignment), "TopLeft"), _
     Category("Darstellung"), _
     Description("Bestimmt, wie der Text innerhalb des Steuerelementes ausgerichtet wird."), _
     Browsable(True)> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return myTextAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            myTextAlign = Value
            'Inhalt bei der nächsten Gelegenheit neu zeichnen
            Invalidate()
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False"), _
    Category("Darstellung"), _
    Description("Bestimmt, ob der Text im Uhrzeigersinn um 90 Grad gedreht angezeigt werden soll."), _
    Browsable(True), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property DirectionVertical() As Boolean
        Get
            Return myDirectionVertical
        End Get

        'Die DirectionVertical- und die AutoSize-Eigenschaft können nicht
        'miteinander, und die eine schaltet die andere beim Einschalten aus.
        'Deswegen auch das RefreshProperties-Attribute über dem Funktionsrumpf,
        'damit das Eigenschaftenfenster aktualisiert werden kann.
        Set(ByVal Value As Boolean)
            If Value <> DirectionVertical Then
                If Value Then
                    If AutoHeight Then
                        AutoHeight = False
                    End If
                End If
                myDirectionVertical = Value
                'Inhalt bei der nächsten Gelegenheit neu zeichnen
                Invalidate()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "False"), _
    Category("Darstellung"), _
    Description("Bestimmt, ob die Höhe des Steuerelementes automatisch angepasst werden soll."), _
    Browsable(True), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property AutoHeight() As Boolean
        Get
            Return myAutoHeight
        End Get

        'Die DirectionVertical- und die AutoSize-Eigenschaft können nicht
        'miteinander, und die eine schaltet die andere beim Einschalten aus.
        'Deswegen auch das RefreshProperties-Attribute über dem Funktionsrumpf,
        'damit das Eigenschaftenfenster aktualisiert werden kann.
        Set(ByVal Value As Boolean)
            If Value <> AutoHeight Then
                If Value Then
                    If DirectionVertical Then
                        DirectionVertical = False
                    End If
                End If
                myAutoHeight = Value
                'Größe anpassen
                AdjustHeight()
            End If
        End Set
    End Property

    <DefaultValue(GetType(Boolean), "True"), _
    Category("Darstellung"), _
    Description("Bestimmt, ob der Text am Ende einer Zeile umgebrochen werden soll."), _
    Browsable(True)> _
    Public Property TextWrap() As Boolean
        Get
            Return myTextWrap
        End Get
        Set(ByVal Value As Boolean)
            myTextWrap = Value
            Invalidate()
            'Das Ein- oder Ausschalten des Wrapping beeinflusst natürlich auch die Höhe!
            AdjustHeight()
        End Set
    End Property

    <DefaultValue(GetType(StringTrimming), "None"), _
    Category("Darstellung"), _
    Description("Bestimmt, auf welche Weise nicht mehr darstellbare Zeichen abgeschnitten werden können."), _
    Browsable(True)> _
    Public Property TextTrimming() As StringTrimming
        Get
            Return myTextTrimming
        End Get
        Set(ByVal Value As StringTrimming)
            myTextTrimming = Value
            Invalidate()
        End Set
    End Property

    'Wir müssen Text nicht neu implementieren, es reicht, wenn wir erfahren,
    '*dass* sich die Texteigenschaft geändert hat.
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        AdjustHeight()
        Invalidate()
    End Sub

    '**************************************************************************************
    '*** Flash-Handling                     ***********************************************
    '**************************************************************************************

    Private Shared myFlashState As Boolean
    Private Shared myFlashTimerUseCounter As Integer
    Private myFlashTimerUsed As Boolean
    Private myFlash As Boolean
    Private myFlashBackColor As Color
    Private myFlashForeColor As Color

    Public Shared Event FlashOn(ByVal sender As Object, ByVal e As EventArgs)
    Public Shared Event FlashOff(ByVal sender As Object, ByVal e As EventArgs)

    'Es gibt einen einzigen Timer für alle blinkenden ADLabelEx-Instanzen. Alles andere
    'wäre Verschwendung von Ressourcen.
    'Und auch der eine Timer wird erst dann angeworfen, wenn das erste ADLabelEX
    'blinken will.
    Private Shared Sub StartFlashHandlerOnDemand()
        If myFlashTimerUseCounter = 0 Then
            myFlashTimer = New Timer
            myFlashTimer.Interval = myFlashInterval
            myFlashTimer.Start()
            'Hier wird die Ereignisbehandlungsroutine eingebunden, die beim
            'Ablaufen von myFlashInterval-Millisekunden (also alle 300) aufgerufen wird.
            AddHandler myFlashTimer.Tick, AddressOf FlashTimeHandler
        End If
        'Damit die Steuerelement-Klasse weiß, wieviele Instanzen blinken,
        'gibt es einen Zähler...
        myFlashTimerUseCounter += 1
    End Sub

    Private Shared Sub StopFlashHandlerOnDemand()
        myFlashTimerUseCounter -= 1
        '...damit das Timer-Objekt ordnungsgemäß entladen werden kann,
        'wenn es nicht mehr benötigt wird.
        If myFlashTimerUseCounter = 0 Then
            myFlashTimer.Stop()
            myFlashTimer.Dispose()
        End If
    End Sub

    'Dispose wird benötigt, damit der letzte das Licht (den Timer) ausmachen kann!
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If myFlashTimerUsed Then
                RemoveHandler FlashOn, AddressOf FlashOnHandler
                RemoveHandler FlashOff, AddressOf FlashOffHandler
                StopFlashHandlerOnDemand()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Dieser private Ereignishandler löst zwei neue Ereignisse aus, die öffentlich empfangen werden
    'können. Es gibt jeweils für beginnende An- und Aus-Phase ein Ereignis.
    Private Shared Sub FlashTimeHandler(ByVal sender As Object, ByVal e As EventArgs)
        myFlashState = Not myFlashState
        If myFlashState Then
            RaiseEvent FlashOn("ADLabelEx.FlashHandler", e.Empty)
        Else
            RaiseEvent FlashOff("ADLabelEx.FlashHandler", e.Empty)
        End If
    End Sub

    Protected Overridable Sub FlashOnHandler(ByVal sender As Object, ByVal e As EventArgs)
        'Da die Ereignis-Handler schon im Konstruktor eingebunden werden (war einfacher ;-)
        'treten die Ereignisse auch auf, wenn ein anderen ADLabelEx blinken will.
        'Deswegen muss diese Instanz testen, ob sie blinken darf.
        If Not myFlash Then Return
        'Alles weitere regelt OnPaint...
        Me.Invalidate()
    End Sub

    'Das Selbe in blau/schwarz.
    Protected Overridable Sub FlashOffHandler(ByVal sender As Object, ByVal e As EventArgs)
        If Not myFlash Then Return
        Me.Invalidate()
    End Sub

    <DefaultValue(GetType(Boolean), "False"), _
    Category("Darstellung"), _
    Description("Bestimmt, ob der Label-Text blinked angezeigt werden soll."), _
    Browsable(True)> _
    Public Property Flash() As Boolean
        Get
            Return myFlash
        End Get
        Set(ByVal Value As Boolean)
            myFlash = Value
            'Im Entwurfsmodus wird nicht geblinkt!
            If Not DesignMode Then
                If Value Then
                    'Erst das erste Setzen initialisiert den Blink-Timer
                    'aber nur beim ersten Mal!
                    If Not myFlashTimerUsed Then
                        StartFlashHandlerOnDemand()
                    End If
                    myFlashTimerUsed = True
                Else
                    'Alten Zustand wiederherstellen
                    Invalidate()
                End If
            End If
        End Set
    End Property

    <Category("Darstellung"), _
    Description("Bestimmt die Hintergrundfarbe beim Blinken, wenn sich das Steuerelement in der An-Phase befindet."), _
    Browsable(True)> _
    Public Property FlashBackColor() As Color
        Get
            'Hier läufts anders mit den Standardwerten. Wenn keine Farbe definiert ist,
            '"erbt" diese Eigenschaft von BackColor. Dadurch muss nur BackColor verändert
            'werden, um auch FlashBackColor zu verändern. Allerdings gibt es damit keinen
            'festen Standardwert...
            If myFlashBackColor.Equals(Color.Empty) Then
                Return BackColor
            Else
                Return myFlashBackColor
            End If
        End Get

        Set(ByVal Value As Color)
            If Value.Equals(BackColor) Then
                myFlashBackColor = Color.Empty
            Else
                myFlashBackColor = Value
            End If
        End Set
    End Property

    '...deswegen muss mit einer Funktion ermittelt werden, ob der aktuelle Wert der Standardwert ist.
    'Nur wenn er es nicht ist, wird serialisiert (Code für die Eigenschaft in der sie einbindenden
    'Instanz erzeugt).
    Public Function ShouldSerializeFlashBackColor() As Boolean
        Return Not myFlashBackColor.Equals(Color.Empty)
    End Function

    'Damit wird die Reset-Funktion für diese Eigenschaft im Eigenschaftenfenster
    '(Kontext-Menü über der Eigenschaft) aktiviert.
    Public Sub ResetFlashBackColor()
        myFlashBackColor = Color.Empty
    End Sub

    <Category("Darstellung"), _
    Description("Bestimmt die Vordergrundfarbe beim Blinken, wenn sich das Steuerelement in der An-Phase befindet."), _
    Browsable(True)> _
    Public Property FlashForeColor() As Color
        Get
            If myFlashForeColor.Equals(Color.Empty) Then
                Return BackColor
            Else
                Return myFlashForeColor
            End If
        End Get

        Set(ByVal Value As Color)
            If Value.Equals(BackColor) Then
                myFlashForeColor = Color.Empty
            Else
                myFlashForeColor = Value
            End If
        End Set
    End Property

    Public Function ShouldSerializeFlashForeColor() As Boolean
        Return Not myFlashForeColor.Equals(Color.Empty)
    End Function

    Public Sub ResetFlashForeColor()
        myFlashForeColor = Color.Empty
    End Sub
End Class
