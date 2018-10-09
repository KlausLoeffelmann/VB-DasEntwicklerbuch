'Definiert einen neuen Variablentyp für das Speichern von Methoden,
'die diese Signatur erfüllen:
Delegate Function RechteckMalDelegate(ByVal xLinks As Double, ByVal yOben As Double,
                                      ByVal xRechts As Double, ByVal yUnten As Double) As Rectangle

Class MainWindow

    'Delegate-Variable deklarieren und mit der Funktion zum Ermitteln
    'eines "kantigen" Rechtecks definieren
    Private RechteckGetter As RechteckMalDelegate = AddressOf KantigeEcken

    'Klickt zeichnet die Figur aus Rechtecken.
    Private Sub DrawButton_Click(ByVal sender As System.Object,
                                 ByVal e As System.Windows.RoutedEventArgs) Handles DrawButton.Click
        Neumalen()
    End Sub

    'Per CheckBox umschalten zwischen abgerundeten und normalen Ecken.
    Private Sub AbgerundeteEckenCheckBox_ToggleCheck(ByVal sender As System.Object,
                            ByVal e As System.Windows.RoutedEventArgs) _
            Handles AbgerundeteEckenCheckBox.Checked, AbgerundeteEckenCheckBox.Unchecked

        If AbgerundeteEckenCheckBox.IsChecked Then
            RechteckGetter = AddressOf AbgerundeteEcken
        Else
            RechteckGetter = AddressOf KantigeEcken
        End If
        Neumalen()
    End Sub

    'Malt die Figur neu.
    Private Sub Neumalen()
        Dim s As New Rectangle()
        MalbereichCanvas.Children.Clear()

        'Wir fächern ein paar Rechtecke auf, drehen sie also beim Zeichnen...
        For c = 0 To 120 Step 3

            '...und verschieben jedes einzelne zusätzlich ein bisschen
            'nach rechts und nach unten.
            Dim x1, y1 As Double
            x1 = 10 + c * 3
            y1 = c \ 2

            'Hier ermitteln wir das Rechteck-Objekt über den Delegaten,
            'der jeweils eine andere "Adresse" enthält, je nachdem, 
            'ob die CheckBox angeklickt ist oder nicht.
            Dim recToDraw = RechteckGetter(x1, y1, x1 + 300, y1 + 200)

            'Positionsbestimmung in WPF auf dem Canvas funktioniert nur 
            'auf diese Weise über Attached Properties.
            Canvas.SetLeft(recToDraw, DirectCast(recToDraw.Tag, Point).X)
            Canvas.SetTop(recToDraw, DirectCast(recToDraw.Tag, Point).Y)

            'Wir drehen das Rechteck um c Grad; der Drehpunkt ist ein
            'wenig nach links und nach oben geschoben.
            recToDraw.LayoutTransform = New RotateTransform(c, -100, -50)

            'Das Hinzufügen zur Children-Auflistung des Canvas sorgt für
            'das Erscheinen auf dem Bildschirm.
            MalbereichCanvas.Children.Add(recToDraw)
        Next
    End Sub

    'Liefert ein WPF-Rechtecke-Objekt in den angegebenen Koordianten mit normalen Ecken...
    Private Function KantigeEcken(ByVal x1 As Double, ByVal y1 As Double,
                                  ByVal x2 As Double, ByVal y2 As Double) As Rectangle

        Return New Rectangle() With {.Tag = New Point(x1, y1),
                                     .Width = x2 - x1,
                                     .Height = y2 - y1,
                                     .Stroke = New SolidColorBrush(Colors.Black)}
    End Function

    '...und diese Methode ebenfalls eines, aber mit abgerundeten Ecken.
    Private Function AbgerundeteEcken(ByVal x1 As Double, ByVal y1 As Double,
                                      ByVal x2 As Double, ByVal y2 As Double) As Rectangle

        Return New Rectangle() With {.Tag = New Point(x1, y1),
                                     .Width = x2 - x1,
                                     .Height = y2 - y1,
                                     .RadiusX = 30,
                                     .RadiusY = 30,
                                     .Stroke = New SolidColorBrush(Colors.Black)}
    End Function

End Class
