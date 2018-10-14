Imports System.Data.SqlClient

Public Class Form1

    Private Sub btnAusf�hren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAusf�hren.Click
        Dim locConnection As SqlConnection

        'Connection-Objekt holen, damit die Datenbankverbindung hergestellt werden kann
        locConnection = New SqlConnection _
                        ("Data Source=.\SQLExpress;Initial Catalog=Hecktick;Integrated Security=True")

        'W�rden Sie den "gemischten Modus" verwenden, w�re Folgendes die richtige Wahl.
        'Aber aufgepasst: Das Passwort steht dann im Quellcode und kann leicht gefunden werden!
        'Eine Verschl�sselung des Passwortes wenigstens mit einfachen Mitteln w�re dann angezeigt.
        'locConnection = New SqlConnection _
        '                ("Data Source=.\SQLExpress;Initial Catalog=Hecktick;User ID=sa; Password=Irgendwas")

        Dim locAdapter As New SqlDataAdapter(txtSelectString.Text, locConnection)
        Dim locTable As New DataTable
        Try
            locAdapter.Fill(locTable)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fehler bei der Befehlsausf�hrung:", _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        'Zur einfachen Darstellung der Daten reicht es auch ohne Hilfe einer 
        'BindungSource aus, die DataTable der DataSource-Eigenschaft der DataGridView
        'zuzuweisen. In diesem Fall wird intern ein CurrencyManager-Objekt
        'f�r die Datenbindung anstelle der BindungSource eingerichtet.
        dgvData.DataSource = locTable
    End Sub

    'Wird ausgel�st, wenn der Anwender auf eine Zelle doppelt klickt.
    Private Sub dgvData_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseDoubleClick

        'Die Datentabelle existiert noch, wir haben sie schlie�lich der
        'DataSource der DataGridView zugeordnet.
        Dim locDataTable As DataTable = DirectCast(dgvData.DataSource, DataTable)

        'Jetzt ermitteln wir die entsprechende DataRow der DataTable
        'Die folgende Methode funktioniert auch, wenn die Tabelle sortiert wurde,
        'da jede Zeile der DataGridView das "Original"-Objekt enth�lt, 
        'aus der sie entstanden ist. In diesem Fall ist das ein DataRowView-Objekt,
        'mit dem die urspr�ngliche Zeile der DataTable abrufbar ist.
        Dim locO As Object = dgvData.Rows(e.RowIndex)
        Dim locDataRowView As DataRowView = TryCast(dgvData.Rows(e.RowIndex).DataBoundItem, DataRowView)

        'War kein DataRowView-Objekt, dann beenden.
        If locDataRowView Is Nothing Then
            Return
        End If

        'Daraus k�nnen wir jetzt die eigentliche DataRow ableiten
        Dim locDataRow As DataRow = locDataRowView.Row

        'Und die Daten, die sich in der DataRow befinden, 
        'geben wir anschlie�end in einer MessageBox aus:
        'Das StringBuilder-Objekt verwenden wir zum Zusammenbauen des Strings.
        Dim locSb As New System.Text.StringBuilder

        'Durch die einzelnen Spalten der Tabelle iterieren:
        For Each locSpalte As DataColumn In locDataRow.Table.Columns
            'String zusammenbauen. Erst den Spaltennamen,
            locSb.Append(locSpalte.ColumnName)
            'dann den Spaltentyp in Klammern, 
            locSb.Append(" (" & locSpalte.DataType.ToString & "): ")
            'dann den eigentlichen Inhalt des Datenfeldes
            locSb.Append(locDataRow(locSpalte.ColumnName).ToString)
            'und schlie�lich einen Zeilenumbruch.
            locSb.Append(vbNewLine)
        Next

        'Alles in einer MessageBox ausgeben.
        MessageBox.Show(locSb.ToString, "Datenzeile enth�lt:", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
