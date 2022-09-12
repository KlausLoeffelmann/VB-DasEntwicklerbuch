Public Class frmMain

    Private Sub HinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmBerater As New frmBerater

        frmBerater.Show()

        'Diese Code-Zeile fügt einen leeren Datensatz an, der vom Benutzer ausgefüllt werden kann
        frmBerater.BeraterBindingSource.AddNew()
        'Status im Hauptformular setzen
        Me.StatusStripStatus.Text = "Berater Formular geladen"

    End Sub

    Private Sub HToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmProjekte As New frmProjekte
        frmProjekte.MdiParent = Me
        frmProjekte.Show()

        'Diese Code-Zeile fügt einen leeren Datensatz an, der vom Benutzer ausgefüllt werden kann
        frmProjekte.ProjekteBindingSource.AddNew()
        Me.StatusStripStatus.Text = "Projekte Formular geladen"
    End Sub



    Private Sub ZeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Show()
    End Sub



    Private Sub BeraterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeraterToolStripMenuItem1.Click
        Dim frmBerater As New frmBerater

        frmBerater.Show()
        Me.StatusStripStatus.Text = "Berater Formular geladen"
    End Sub

    Private Sub ProjekteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjekteToolStripMenuItem.Click
        Dim frmProjekte As New frmProjekte
        'Dieze Zeile sorgt dafür, dass bei Eingabe sofort ein neuer DS angelegt wird
        frmProjekte.ProjekteBindingSource.AddNew()

        frmProjekte.Show()
        Me.StatusStripStatus.Text = "Projekte Formular geladen"
    End Sub

    Private Sub NeueZeiterfassungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeueZeiterfassungToolStripMenuItem.Click
        Dim frmZeitErfassen As New frmZeitErfassen

        frmZeitErfassen.Show()
        Me.StatusStripStatus.Text = "Zeiterfassungs Formular geladen"
    End Sub

    Private Sub BeraterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeraterToolStripMenuItem2.Click
        Dim frmAuswertungBerater As New frmAuswertungBerater
        frmAuswertungBerater.MdiParent = Me
        frmAuswertungBerater.Show()

    End Sub

    Private Sub ProjekteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjekteToolStripMenuItem1.Click
        Dim frmAuswertungProjekte As New frmAuswertungProjekte
        frmAuswertungProjekte.MdiParent = Me
        frmAuswertungProjekte.Show()

    End Sub

    Private Sub BeendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
