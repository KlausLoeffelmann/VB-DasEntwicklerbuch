Public Class Form1

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click

        'Die Definitionen für typisierte Tabellen befinden sich in der DataSet-Klasse
        Dim locProjekteTable As New HecktickDataSet.ProjekteDataTable

        'Die Definitionen für typisierte Adapter für Tabellen befinden sich in
        'in einem separaten Namespace
        Dim locProjekteAdapter As New HecktickDataSetTableAdapters.ProjekteTableAdapter

        'Eine neue Datenzeile hinzufügen. Intellisense hilft Ihnen hier beim
        'Finden der richtigen Parameter, weil diese Datenzeile jetzt typisiert ist.
        locProjekteTable.AddProjekteRow("Orcas", " (VS 2007) Schreiben des Entwicklerbuchs", _
                     #2/1/2007#, #12/31/2007#, "Büro")


        'Eine typisierte Datenzeile deklarieren.
        Dim locProjektRow As HecktickDataSet.ProjekteRow

        'Vorteil: AddProjektRow liefert die hinzugefügte Zeile als typisierte Row zurück.
        locProjektRow = locProjekteTable.AddProjekteRow("Katmai", _
                            "(SQL Server 2005) Schreiben des Crash-Kurs", _
                            #3/1/2007#, #1/31/2008#, "Büro")

        'Aktualisieren funktioniert mit dem Projekte-TableAdapter.
        locProjekteAdapter.Update(locProjekteTable)

        'Bei AutoIncrement-Feldern wird automatisch dafür gesorgt,
        'dass das Feld aktualisiert wird.
        Dim locIDProjekte As Integer = locProjektRow.IDProjekte

        MessageBox.Show("Datensätze wurden hinzugefügt. Sie können Sie im Server-Explorer betrachten!")

        'Daten komplett neu einlesen
        locProjekteTable.Clear()

        'Funktioniert wie beim Adapter.
        locProjekteAdapter.Fill(locProjekteTable)

        'Die Zeile mit der entsprechenden ID finden
        locProjektRow = locProjekteTable.FindByIDProjekte(locIDProjekte)

        'Jetzt können wir die Datenfelder direkt per Eigenschaftennamen ändern,
        'die genau so heißen, wie die Datenfelder in der Datenbank.
        locProjektRow.Projektbeschreibung = "(SQL Server 2007) Schreiben des Crash-Kurses"
        locProjektRow.Startzeitpunkt = #2/1/2007#
        locProjektRow.Endzeitpunkt = #10/31/2007#
        locProjektRow.Ausführungsort = "Ruprechts Büro"

        'Tabelle aktualisieren.
        locProjekteAdapter.Update(locProjekteTable)


    End Sub

    Private Sub btnTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest2.Click

        'Wird benötigen alle Adapter, um an die Daten heranzukommen.
        Dim locZeitenAdapter As New HecktickDataSetTableAdapters.ZeitenTableAdapter
        Dim locProjekteAdapter As New HecktickDataSetTableAdapters.ProjekteTableAdapter
        Dim locBeraterAdapter As New HecktickDataSetTableAdapters.BeraterTableAdapter

        'Dieses Mal verwenden wir wegen der Relation ein DataSet
        Dim locHeckTickDataSet As New HecktickDataSet()
        locProjekteAdapter.Fill(locHeckTickDataSet.Projekte)
        locBeraterAdapter.Fill(locHeckTickDataSet.Berater)

        'TODO: Passen Sie den Zeitbereich Ihrer Beispieldatenbank an.
        locZeitenAdapter.FillByIDProjektUndZeitbereich(locHeckTickDataSet.Zeiten, _
                            locHeckTickDataSet.Projekte(0).IDProjekte, _
                            #3/15/2006#, #3/15/2006 11:59:59 PM#)

        'Alle Datensätze mit Nachnamen ausgeben; die Relation zwischen Zeiten und
        'Berater wurde einerseits durch die Verwendung eines typisierten DataSets 
        'und andererseits durch die Erstellung der Relationen der Tabellen im SQL Server 
        'automatisch hergestellt.
        For Each locZeitenRow As HecktickDataSet.ZeitenRow In locHeckTickDataSet.Zeiten.Rows
            Debug.Print(locZeitenRow.BeraterRow.Nachname & ": " & _
                        locZeitenRow.Startzeit.ToShortDateString & " - " & _
                        locZeitenRow.Startzeit.ToShortDateString)
        Next

    End Sub

    Private Sub ProjekteBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjekteBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProjekteBindingSource.EndEdit()
        Me.ProjekteTableAdapter.Update(Me.HecktickDataSet.Projekte)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HecktickDataSet.Zeiten". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ZeitenTableAdapter.Fill(Me.HecktickDataSet.Zeiten)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "HecktickDataSet.Projekte". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.ProjekteTableAdapter.Fill(Me.HecktickDataSet.Projekte)

    End Sub
End Class
