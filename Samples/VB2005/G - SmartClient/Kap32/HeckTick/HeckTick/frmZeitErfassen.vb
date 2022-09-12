Public Class frmZeitErfassen
    Dim strStartzeit, strEndzeit As Date
    Dim intIDProjekt, intIDBerater As Integer

    Private Sub frmZeitErfassen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.Berater". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.BeraterTableAdapter1.Fill(Me.HeckTickDataSet1.Berater)

        'TODO: Diese Codezeile lädt Daten in die Tabelle "HeckTickDataSet.Projekte". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ProjekteTableAdapter1.Fill(Me.HeckTickDataSet1.Projekte)

        'Berater ComboBox binden
        Me.cbName.DataSource = HeckTickDataSet1.Berater

        cbName.DisplayMember = "Nachname"
        cbName.ValueMember = "IDBerater"
        AddHandler cbName.SelectedIndexChanged, AddressOf cbName_SelectedIndexChanged

        'Projekte ComboBox binden
        Me.cbProjekt.DataSource = HeckTickDataSet1.Projekte

        cbProjekt.DisplayMember = "Projektname"
        cbProjekt.ValueMember = "IDProjekte"
        AddHandler cbProjekt.SelectedIndexChanged, AddressOf cbProjekt_SelectedIndexChanged

        'Steuerelemente zur Erfassung der Zeit vorbereiten
        Me.txtUhrStartzeit.Mask = "##:##"

        Me.txtUhrEndzeit.Mask = "##:##"
        Me.txtUhrEndzeit.Text = Now.ToShortTimeString
    End Sub
    Private Sub cbName_SelectedIndexChanged _
        (ByVal sender As System.Object, _
         ByVal e As System.EventArgs)

        Dim dr As DataRowView = CType(cbName.SelectedItem, _
            DataRowView)

        intIDBerater = CInt(dr("IDBerater"))
    End Sub

    Private Sub cbProjekt_SelectedIndexChanged _
    (ByVal sender As System.Object, _
     ByVal e As System.EventArgs)

        Dim dr As DataRowView = CType(cbProjekt.SelectedItem, DataRowView)

        intIDProjekt = CInt(dr("IDProjekte"))
    End Sub

    Private Sub btnSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If intIDProjekt = 0 And intIDBerater = 0 Then
            MessageBox.Show("Bitte wählen Sie zunächst einen Berater und ein Projekt aus")
        Else
            Try
                strStartzeit = CDate(Me.dtpDateStartzeit.Value.ToShortDateString & " " & Me.txtUhrStartzeit.Text)
                strEndzeit = CDate(Me.dtpDateEndzeit.Value.ToShortDateString & " " & Me.txtUhrEndzeit.Text)

                Dim dt As New DataTable
                Dim dr As DataRow
                dr = Me.HeckTickDataSet1.Zeiten.NewRow

                dr.Item("IDProjekt") = intIDProjekt
                dr.Item("IDBerater") = intIDBerater
                dr.Item("Startzeit") = strStartzeit
                dr.Item("Endzeit") = strEndzeit
                dr.Item("ArbBeschreibung") = Me.txtArbBeschreibung.Text
                Me.HeckTickDataSet1.Zeiten.Rows.Add(dr)

                Me.ZeitenTableAdapter1.Update(Me.HeckTickDataSet1.Zeiten)
                MessageBox.Show("Daten erfolgreich eingefügt")
                frmMain.StatusStripStatus.Text = "Daten erfolgreich eingefügt"

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ein Fehler ist aufgetreten", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class