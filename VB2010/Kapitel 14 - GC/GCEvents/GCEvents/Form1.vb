Public Class Form1

    Private mykontakt As Kontakt


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Bleibt erhalten.
        Dim kontakt1 As New Kontakt With {.Nachname = "Wördehoff",
                                          .Vorname = "Angela",
                                          .PLZ = "99999",
                                          .Ort = "Weißichabersagsnicht"}

        'Wird gleich entsorgt.
        Dim kontakt2 As New Kontakt With {.Nachname = "Löffelmann",
                                          .Vorname = "Klaus",
                                          .PLZ = "59555",
                                          .Ort = "Lippstadt"}

        mykontakt = kontakt1


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Nur zum Testen, sonst nicht machen!
        GC.Collect()
    End Sub
End Class

Public Class Kontakt
    Public Property Nachname As String
    Public Property Vorname As String
    Public Property PLZ As String
    Public Property Ort As String

    Protected Overrides Sub Finalize()
        Debug.Print("Finalizing:" & Nachname)
    End Sub

End Class
