Imports System.Windows.Media.Animation

Class Window1

    Private Sub Window1_SizeChanged(ByVal sender As Object, ByVal e As System.Windows.SizeChangedEventArgs) Handles Me.SizeChanged
        'meineLeinwand kommt aus der XAML-Definition
        'dort haben wir das vordefinierte Grid rausgeschmissen,
        'und durch die Leinwand (Canvas) ersetzt.
        meineLeinwand.Children.Clear()

        'tatsächliche Breite der Leinwand ermitteln und merken
        Dim tatsächlicheBreiteGemerkt = meineLeinwand.ActualWidth
        Dim linienZähler = 0

        'Jeden 5. Pixel berücksichtigen
        For x = 0 To tatsächlicheBreiteGemerkt Step 5

            'Neues Linienobjekt anlegen, und Parameter setzen
            Dim eineLinie As New Line()
            'Parameter ensprechend setzen
            eineLinie.Stroke = Brushes.Black
            eineLinie.X1 = 0
            eineLinie.Y1 = 0
            eineLinie.X2 = x
            eineLinie.Y2 = meineLeinwand.ActualHeight
            eineLinie.HorizontalAlignment = HorizontalAlignment.Left
            eineLinie.VerticalAlignment = VerticalAlignment.Center
            eineLinie.StrokeThickness = 1
            'Der Leinwand hinzufügen
            meineLeinwand.Children.Add(eineLinie)

            'Die entgegenlaufende Linie definieren
            eineLinie = New Line()
            'Wieder Parameter entsprechend setzen
            eineLinie.Stroke = Brushes.Black
            eineLinie.X1 = tatsächlicheBreiteGemerkt
            eineLinie.Y1 = 0
            eineLinie.X2 = tatsächlicheBreiteGemerkt - x
            eineLinie.Y2 = meineLeinwand.ActualHeight
            eineLinie.HorizontalAlignment = HorizontalAlignment.Left
            eineLinie.VerticalAlignment = VerticalAlignment.Center
            eineLinie.StrokeThickness = 1
            'Und der Leinwand hinzufügen
            meineLeinwand.Children.Add(eineLinie)

            'Linienzähler aktualisieren
            linienZähler += 2
        Next

        Me.Title = "Anzahl Linien im Fenster: " & linienZähler
    End Sub

    Private Sub Window1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDoubleClick
        Dim count = 0

        'Funktioniert natürlich nur, da sich nur 
        'Linien auf dem Canvas-Objekt befinden.
        For Each lineItem As Line In meineLeinwand.Children
            'Y2-Eigenschaft wird animiert, daher der Name.
            'Die Klasse DoubleAnimation animiert Eigenschaften 
            'vom Typ Double.

            'Animiert wird von der aktuellen Höhe der Linie
            'bis zur halben Höhe der Linie.
            Dim Y2Animation As New DoubleAnimation(lineItem.ActualHeight, lineItem.ActualHeight / 2, TimeSpan.FromSeconds(3))

            'Hier wird festgelegt, dass die Animation automatisch 
            'wenn sie einmal komplett durchlaufen wurde.
            Y2Animation.RepeatBehavior = RepeatBehavior.Forever

            'Bestimmt, dass die DoubleAnimation hoch- und durch
            'AutoReverse=True anschließed wieder runterzählt.
            Y2Animation.AutoReverse = True

            'Die Animation für jede weitere Linie wird um
            '500 Millisekunden verzögert zur vorherigen begonnen,
            Y2Animation.BeginTime = New TimeSpan(500000 * count)

            'Animation starten ...
            lineItem.BeginAnimation(Line.HeightProperty, Y2Animation)
            count += 1
        Next
    End Sub
End Class
