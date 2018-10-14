Public Class frmBeraterSuchen

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuchen.Click

        'Wichtig: TableAdapter mit dem Inhalt aus dem DataSet füllen
        Me.BeraterTableAdapter1.Fill(Me.HeckTickDataSet1.Berater)


        'Das DataView-Objekt initalisieren und mit dem Inhalt aus dem DataSet füllen
        Dim dvBerater As DataView = HeckTickDataSet1.Tables("Berater").DefaultView

        'Spalte festlegen, in der gesucht werden soll
        'dvBerater.Sort = "Nachname"

        'Dim intID As Integer
        'intID = dvBerater.Find(Me.txtNachname.Text)
        dvBerater.RowFilter = "Nachname = " & Me.txtNachname.Text

        frmBerater.BeraterBindingSource.DataSource = dvBerater


       
        '  MessageBox.Show(CStr(dvBerater(intID).Item("Vorname")))

        ' dv.Table = HeckTickDataSet1.Berater
        ' dvBerater.Sort = "Nachname"

        'Dim find As DataSourc
        'find = dvBerater.FindRows("a")
        '   Me.DataGridView1.DataSource = dvBerater.FindRows("a")



        '   Me.DataGridView1.DataSource = dv(dv.Find("2")).Item("IDBerater")


    End Sub

End Class