Public Class frmMain

    Private Sub btnCreateWithTestControl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                Handles btnCreateWithTestControl.Click
        Dim locfrmTest As frmTest
        Dim locTestControl As TestControl
        Dim locButton As Button

        'Einstellungen gelten für das Formular...
        If chkFormular.Checked Then
            locfrmTest = New frmTest( _
                        chkCreateDestroy.Checked, chkMouse.Checked, chkKeyboard.Checked, _
                     chkPositioning.Checked, chkRepaintLayout.Checked, chkFocussing.Checked, _
                     chkPreProcessing.Checked, chkWndProcMessages.Checked)
        Else
            locfrmTest = New frmTest
        End If

        '...und/oder für die TestButton-Komponente
        If chkSchaltfläche.Checked Then
            locTestControl = New TestControl( _
                        chkCreateDestroy.Checked, chkMouse.Checked, chkKeyboard.Checked, _
                     chkPositioning.Checked, chkRepaintLayout.Checked, chkFocussing.Checked, _
                     chkPreProcessing.Checked)
        Else
            locTestControl = New TestControl
        End If

        'Einstellungen für das Formular durchführen

        'Das Formular hat ein Viertel der Bildschirmgröße
        'und soll in der Bildschirmmitte des primären Bildschirms erscheinen
        Dim locBounds As Rectangle = Screen.PrimaryScreen.Bounds
        locfrmTest.Width = locBounds.Width \ 4
        locfrmTest.Height = locBounds.Height \ 4
        locfrmTest.StartPosition = FormStartPosition.CenterScreen
        locfrmTest.Text = txtFormText.Text

        'Einstellungen entsprechend der CheckBox-Controls im Formular
        locfrmTest.ControlBox = chkControlBox.Checked
        locfrmTest.MinimizeBox = chkMinMax.Checked
        locfrmTest.MaximizeBox = chkMinMax.Checked
        locfrmTest.HelpButton = chkHelpButton.Checked
        locfrmTest.ShowInTaskbar = chkShowInTaskbar.Checked
        locfrmTest.TopMost = chkTopMost.Checked
        locfrmTest.KeyPreview = chkKeyPreview.Checked
        locfrmTest.AutoScroll = chkScrollBars.Checked

        'TestControl mittig und im obeneren Drittel Formular platzieren 
        '- nicht zu klein oder zu groß
        locTestControl.Width = CInt(locfrmTest.ClientSize.Width / 2)
        locTestControl.Height = CInt(locfrmTest.ClientSize.Height / 3)
        locTestControl.Location = _
                New Point(CInt(locfrmTest.ClientSize.Width / 2 - locTestControl.Width / 2), _
                          CInt(locfrmTest.ClientSize.Height / 3 - locTestControl.Height / 2))

        'TestControl verankern, wenn die AutoScroll-Funktion des Formulars nicht gewünscht wird
        If Not chkScrollBars.Checked Then
            locTestControl.Anchor = AnchorStyles.Bottom Or AnchorStyles.Top Or _
                                     AnchorStyles.Left Or AnchorStyles.Right
        End If

        'Schließschaltfläche im unteren Drittel positionieren
        locButton = New Button
        locButton.Width = CInt(locfrmTest.ClientSize.Width / 3)
        locButton.Height = CInt(locfrmTest.Height / 6)
        locButton.Location = _
                New Point(CInt(locfrmTest.ClientSize.Width / 2 - locButton.Width / 2), _
                          CInt(locfrmTest.ClientSize.Height / 4 * 3 - locButton.Height / 2))

        locButton.Text = "Formular &schließen"
        'Schließschaltfläche verankern, wenn die AutoScroll-Funktion des Formulars nicht gewünscht wird
        If Not chkScrollBars.Checked Then
            locButton.Anchor = AnchorStyles.Bottom Or _
                                     AnchorStyles.Left Or AnchorStyles.Right
        End If

        'Return und Escape lösen Click-Ereignis des Buttons aus
        Me.AcceptButton = locButton
        Me.CancelButton = locButton

        'Zur Laufzeit einstellen, dass das Click-Ereignis der Schließschaltfläche 
        'von TestButton-Click behandelt wird
        AddHandler locButton.Click, AddressOf TestButton_Click

        'Beide Controls der Formular-ControlCollection hinzufügen;
        'damit werden die beiden Komponenten windowstechnisch angelegt und dargestellt
        locfrmTest.Controls.Add(locTestControl)
        locfrmTest.Controls.Add(locButton)

        locfrmTest.Show()
    End Sub

    'Ereignis-Routine des Buttons; wird zur Laufzeit eingebunden (s.o.)
    Sub TestButton_Click(ByVal Sender As Object, ByVal e As EventArgs)

        Dim locButton As Button

        'Könnte schief gehen, wenn Sender nicht die Schaltfläche ist,
        'deswegen sichergehen durch Try/Catch
        Try
            'Das sendende Objekt herausfinden
            locButton = DirectCast(Sender, Button)
        Catch ex As Exception
            Return
        End Try
        'Sendende Objekt war der Button selbst, dann dessen Parent (das Formular) entsorgen.
        'Damit wird das Formular, das den Button enthält, geschlossen.
        locButton.Parent.Dispose()
    End Sub
End Class
