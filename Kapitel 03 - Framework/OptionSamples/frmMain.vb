Option Explicit On
Option Strict On

Public Class frmMain

    Private Sub btnShowWeekday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowWeekday.Click

        Dim locDateVariable
        Dim locWeekday As String

        'Datumseingabe auslesen
        locDateVaraible = txtDate.Text

        'In Wochentag umwandeln
        locWeekday = Weekday(locDateVariable)

        '"Nullen" vermeiden
        locWeekday += 1

        'Wochentagsnummer ausgeben
        txtWeekday.Text = locWeekday

    End Sub

    Private Sub btnQuitProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitProgram.Click
        Me.Close()
    End Sub
End Class
