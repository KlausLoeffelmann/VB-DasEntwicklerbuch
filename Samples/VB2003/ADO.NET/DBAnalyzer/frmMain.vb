Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Reflection

Public Class frmMain
    Inherits System.Windows.Forms.Form

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents lstTabellen As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnProgrammBeenden As System.Windows.Forms.Button
    Friend WithEvents lblDatenbank As System.Windows.Forms.Label
    Friend WithEvents btnAccessDatenbankWählen As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnTabSchemaAnzeigen As System.Windows.Forms.Button
    Friend WithEvents btnDBSchemaAnzeigen As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSELECTCommand As System.Windows.Forms.Label
    Friend WithEvents btnSELECTAusführen As System.Windows.Forms.Button
    Friend WithEvents btnSELECTCommandBearbeiten As System.Windows.Forms.Button
    Friend WithEvents btnDatensatzAnzeigen As System.Windows.Forms.Button
    Friend WithEvents dgSchemaUndDaten As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lstTabellen = New System.Windows.Forms.ListBox
        Me.btnTabSchemaAnzeigen = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnProgrammBeenden = New System.Windows.Forms.Button
        Me.lblDatenbank = New System.Windows.Forms.Label
        Me.btnAccessDatenbankWählen = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgSchemaUndDaten = New System.Windows.Forms.DataGrid
        Me.btnDBSchemaAnzeigen = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSELECTCommandBearbeiten = New System.Windows.Forms.Button
        Me.lblSELECTCommand = New System.Windows.Forms.Label
        Me.btnSELECTAusführen = New System.Windows.Forms.Button
        Me.btnDatensatzAnzeigen = New System.Windows.Forms.Button
        CType(Me.dgSchemaUndDaten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstTabellen
        '
        Me.lstTabellen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTabellen.Location = New System.Drawing.Point(8, 104)
        Me.lstTabellen.Name = "lstTabellen"
        Me.lstTabellen.Size = New System.Drawing.Size(248, 95)
        Me.lstTabellen.TabIndex = 0
        '
        'btnTabSchemaAnzeigen
        '
        Me.btnTabSchemaAnzeigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTabSchemaAnzeigen.Location = New System.Drawing.Point(264, 136)
        Me.btnTabSchemaAnzeigen.Name = "btnTabSchemaAnzeigen"
        Me.btnTabSchemaAnzeigen.Size = New System.Drawing.Size(176, 24)
        Me.btnTabSchemaAnzeigen.TabIndex = 1
        Me.btnTabSchemaAnzeigen.Text = "Tabellenschema anzeigen"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tabellen (D-Klick erzeugt SELECT-Command)"
        '
        'btnProgrammBeenden
        '
        Me.btnProgrammBeenden.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProgrammBeenden.Location = New System.Drawing.Point(448, 104)
        Me.btnProgrammBeenden.Name = "btnProgrammBeenden"
        Me.btnProgrammBeenden.Size = New System.Drawing.Size(128, 56)
        Me.btnProgrammBeenden.TabIndex = 3
        Me.btnProgrammBeenden.Text = "Program beenden"
        '
        'lblDatenbank
        '
        Me.lblDatenbank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDatenbank.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDatenbank.Location = New System.Drawing.Point(8, 24)
        Me.lblDatenbank.Name = "lblDatenbank"
        Me.lblDatenbank.Size = New System.Drawing.Size(536, 16)
        Me.lblDatenbank.TabIndex = 4
        '
        'btnAccessDatenbankWählen
        '
        Me.btnAccessDatenbankWählen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccessDatenbankWählen.Location = New System.Drawing.Point(552, 24)
        Me.btnAccessDatenbankWählen.Name = "btnAccessDatenbankWählen"
        Me.btnAccessDatenbankWählen.Size = New System.Drawing.Size(24, 16)
        Me.btnAccessDatenbankWählen.TabIndex = 5
        Me.btnAccessDatenbankWählen.Text = "..."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Access-Datenbank:"
        '
        'dgSchemaUndDaten
        '
        Me.dgSchemaUndDaten.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSchemaUndDaten.DataMember = ""
        Me.dgSchemaUndDaten.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgSchemaUndDaten.Location = New System.Drawing.Point(8, 216)
        Me.dgSchemaUndDaten.Name = "dgSchemaUndDaten"
        Me.dgSchemaUndDaten.Size = New System.Drawing.Size(576, 296)
        Me.dgSchemaUndDaten.TabIndex = 7
        '
        'btnDBSchemaAnzeigen
        '
        Me.btnDBSchemaAnzeigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDBSchemaAnzeigen.Location = New System.Drawing.Point(264, 104)
        Me.btnDBSchemaAnzeigen.Name = "btnDBSchemaAnzeigen"
        Me.btnDBSchemaAnzeigen.Size = New System.Drawing.Size(176, 24)
        Me.btnDBSchemaAnzeigen.TabIndex = 8
        Me.btnDBSchemaAnzeigen.Text = "Datenbankschema anzeigen"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SELECT-Command:"
        '
        'btnSELECTCommandBearbeiten
        '
        Me.btnSELECTCommandBearbeiten.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSELECTCommandBearbeiten.Location = New System.Drawing.Point(552, 64)
        Me.btnSELECTCommandBearbeiten.Name = "btnSELECTCommandBearbeiten"
        Me.btnSELECTCommandBearbeiten.Size = New System.Drawing.Size(24, 16)
        Me.btnSELECTCommandBearbeiten.TabIndex = 10
        Me.btnSELECTCommandBearbeiten.Text = "..."
        '
        'lblSELECTCommand
        '
        Me.lblSELECTCommand.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSELECTCommand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSELECTCommand.Location = New System.Drawing.Point(8, 64)
        Me.lblSELECTCommand.Name = "lblSELECTCommand"
        Me.lblSELECTCommand.Size = New System.Drawing.Size(536, 16)
        Me.lblSELECTCommand.TabIndex = 9
        '
        'btnSELECTAusführen
        '
        Me.btnSELECTAusführen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSELECTAusführen.Enabled = False
        Me.btnSELECTAusführen.Location = New System.Drawing.Point(264, 168)
        Me.btnSELECTAusführen.Name = "btnSELECTAusführen"
        Me.btnSELECTAusführen.Size = New System.Drawing.Size(176, 32)
        Me.btnSELECTAusführen.TabIndex = 12
        Me.btnSELECTAusführen.Text = "SELECT-Command ausführen und ResultSet anzeigen"
        '
        'btnDatensatzAnzeigen
        '
        Me.btnDatensatzAnzeigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDatensatzAnzeigen.Location = New System.Drawing.Point(448, 168)
        Me.btnDatensatzAnzeigen.Name = "btnDatensatzAnzeigen"
        Me.btnDatensatzAnzeigen.Size = New System.Drawing.Size(128, 32)
        Me.btnDatensatzAnzeigen.TabIndex = 13
        Me.btnDatensatzAnzeigen.Text = "Datensatz anzeigen"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 526)
        Me.Controls.Add(Me.btnDatensatzAnzeigen)
        Me.Controls.Add(Me.btnSELECTAusführen)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSELECTCommandBearbeiten)
        Me.Controls.Add(Me.lblSELECTCommand)
        Me.Controls.Add(Me.btnDBSchemaAnzeigen)
        Me.Controls.Add(Me.dgSchemaUndDaten)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnAccessDatenbankWählen)
        Me.Controls.Add(Me.lblDatenbank)
        Me.Controls.Add(Me.btnProgrammBeenden)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTabSchemaAnzeigen)
        Me.Controls.Add(Me.lstTabellen)
        Me.Name = "frmMain"
        Me.Text = "DBAnalyzer"
        CType(Me.dgSchemaUndDaten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myDatabaseFileInfo As FileInfo
    Private myConnection As OleDbConnection

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Pfad zur Demodatenbank vorgeben
        myDatabaseFileInfo = New FileInfo(GetStartUpPath().Parent.Parent.FullName + "\" + "Testdatenbank.mdb")
        DatenbankeinstellungenAktualisieren()
    End Sub

    Private Sub btnAccessDatenbankWählen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                Handles btnAccessDatenbankWählen.Click
        'Nichts Besonderes hier: Datei-Öffnen-Dialog darstellen und Dateinamen holen.
        Dim locOfd As New OpenFileDialog
        With locOfd
            .Title = "Access-Datenbank öffnen:"
            .Filter = "Access-Datenbanken (*.mdb)|*.mdb|Alle Dateien (*.*)|*.*"
            .CheckFileExists = True
            .CheckPathExists = True
            .DefaultExt = "*.mdb"
            Dim locDr As DialogResult = .ShowDialog()
            If locDr = DialogResult.OK Then
                myDatabaseFileInfo = New FileInfo(.FileName)
                DatenbankeinstellungenAktualisieren()
            End If
        End With
    End Sub

    Private Sub btnProgrammBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnProgrammBeenden.Click
        Me.Dispose()
    End Sub

    'Wenn ein Tabellenname in der Liste ausgewählt wurde, zeigt diese
    'Prozedur die Schema-Informationen der Tabelle an.
    Private Sub btnTabSchemaAnzeigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                            Handles btnTabSchemaAnzeigen.Click
        If Not (lstTabellen.SelectedItem Is Nothing) Then
            'SELECT-Command, um das Schema des ResultSets festzulegen
            Dim locCommand As New OleDbCommand("SELECT * FROM " + lstTabellen.SelectedItem.ToString)
            'Verbindung an Command zuweisen
            locCommand.Connection = myConnection
            'Reader deklarieren
            Dim locReader As OleDbDataReader
            'Verbindung öffnen; Reader benötigt offene Verbindung und öffnet nicht selbst!
            myConnection.Open()
            'Daten (aber nur Schema-Infos) in den Reader laden
            locReader = locCommand.ExecuteReader(CommandBehavior.SchemaOnly)
            'Aus den Schemadaten eine DataTable generieren, die direkt der
            'DataSource-Eigenschaft des DataGrids zugewiesen werden kann.
            dgSchemaUndDaten.DataSource = locReader.GetSchemaTable
            'Verbindung wieder schließen
            myConnection.Close()
            'Beschriftung des DataGrids anpassen:
            dgSchemaUndDaten.CaptionText = "Schema der Tabelle: " + lstTabellen.SelectedItem.ToString
        End If
    End Sub

    'Das Schema der Datenbank anzeigen. Dieses Schema enthält u.A. Infos über
    'die verwendeten Tabellen.
    Private Sub btnDBSchemaAnzeigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBSchemaAnzeigen.Click
        'Bräuchte man nicht unbedingt...
        Dim locTable As New DataTable
        'Verbindung zur Datenbank öffnen
        myConnection.Open()
        'Schema-Tabelle einholen und DataTable-Objekt zuweisen
        locTable = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        'An DataSource vom DataGrid zuweisen; damit wird das Datenbankschema angezeigt
        dgSchemaUndDaten.DataSource = locTable
        'Verbindung wieder schließen.
        myConnection.Close()
        'Beschriftung des DataGrids anpassen:
        dgSchemaUndDaten.CaptionText = "Schema der ausgewählten Datenbank:"

    End Sub

    Private Sub DatenbankeinstellungenAktualisieren()
        'Wenn die Datenbank gewechselt wurde, Anzeige aktualisieren,...
        lblDatenbank.Text = myDatabaseFileInfo.FullName
        '...neues Connection-Objekt erstellen,...
        myConnection = GetConnection(myDatabaseFileInfo)
        '...und die Tabellenliste neu erstellen.
        TabellenlisteAufbauen()
    End Sub

    Sub TabellenlisteAufbauen()
        'DataTable wird verwendet, um nicht-verbundene ResultSets komplett zu speichern.
        'Schema-Informationen einer Tabelle werden ebenfalls als eine Art ResultSet zurückgegeben.
        Dim locTable As New DataTable
        'Verbindung zur Datenbank öffnen.
        myConnection.Open()
        'Mit dieser Funktion können die kompletten Datenbankschemata ermittelt werden
        locTable = myConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        'Alle Daten sind nun da; Verbindung wird nicht mehr benötigt
        myConnection.Close()
        'Vorhandene Einträge in der Liste löschen
        lstTabellen.Items.Clear()
        'Alle Datenzeilen durchlaufen, und die Tabellennamen zur Liste hinzufügen
        For Each locDr As DataRow In locTable.Rows
            If locDr.Item("TABLE_TYPE").ToString = "TABLE" Then
                lstTabellen.Items.Add(locDr.Item("TABLE_NAME").ToString)
            End If
        Next
    End Sub

    'Führt den eingegebenen SELECT-Command aus und zeigt die Daten an
    Private Sub btnSELECTAusführen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                         Handles btnSELECTAusführen.Click
        'Neues Command-Objekt erstellen
        Dim locCommand As New OleDbCommand
        locCommand.Connection = myConnection
        'den SELECT-String zuweisen
        locCommand.CommandText = lblSELECTCommand.Text

        'Neues DataAdapter-Objekt erstellen
        Dim locDataAdapter As New OleDbDataAdapter
        'den jetzt vorhandenen SELECT-Command zuweisen
        locDataAdapter.SelectCommand = locCommand

        'Neues Datatable-Objekt erstellen
        Dim locDataTable As New DataTable
        'Die Daten über DataAdapter, Command und Connection abfragen
        'und in die Tabelle übertragen
        locDataAdapter.Fill(locDataTable)

        'Tabelle anzeigen
        dgSchemaUndDaten.DataSource = locDataTable
        SetDateFormatInDataGrid(dgSchemaUndDaten, "dd.MM.yyyy HH:mm")
    End Sub

    'SELECT-String kann auch von Hand bearbeitet werden
    Private Sub btnSELECTCommandBearbeiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSELECTCommandBearbeiten.Click
        Dim locFrmSqlCommandEditieren As New frmSQLCommandEditieren
        Dim locSELECTCommand As String
        locSELECTCommand = locFrmSqlCommandEditieren. _
                           SELECTCommandEditieren(lblSELECTCommand.Text)
        If locSELECTCommand Is Nothing Then
            lblSELECTCommand.Text = ""
            btnSELECTAusführen.Enabled = False
        Else
            lblSELECTCommand.Text = locSELECTCommand
            btnSELECTAusführen.Enabled = True
        End If
    End Sub

    'Diese Prozedur hat anwendungstechnisch keinen tieferen Sinn,
    'sie demonstriert aber, wie Sie Daten aus einer DataTable abfragen
    'und verwerten können.
    Private Sub btnDatensatzAnzeigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatensatzAnzeigen.Click
        Dim locDataRow As DataRow
        Dim locDataTable As DataTable
        Dim locRowDaten As String
        Dim locDataColumns As DataColumnCollection

        'DataTable-Objekt versteckt sich im DataSource des DataGrids
        locDataTable = DirectCast(dgSchemaUndDaten.DataSource, DataTable)
        'Falls noch keine Daten zugewiesen wurde,
        If locDataTable Is Nothing Then
            'Routine verlassen
            Exit Sub
        End If
        'DataColumns-Collection abrufen; die beinhalten alle Spalteninformationen
        locDataColumns = locDataTable.Columns
        'Die ausgewählte Datenreihe abrufen
        locDataRow = locDataTable.Rows(dgSchemaUndDaten.CurrentCell.RowNumber)

        'Der Einfachheit halber den Datensatz in einer Messagebox anzeigen

        'Dazu: Alle Spalten durchlaufen
        For Each locColumn As DataColumn In locDataColumns
            'Feldinfo steht links,
            locRowDaten += locColumn.Caption + ": "
            'Feld-Dateninhalt steht rechts danaben
            locRowDaten += locDataRow(locColumn.Ordinal).ToString + vbNewLine
        Next

        'MessageBox anzeigen
        MessageBox.Show(locRowDaten, "Datensatzinhalt:", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information)
    End Sub

    'Doppelklick auf Tabelleneintrag generiert SELECT-String 
    Private Sub lstTabellen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
                                        Handles lstTabellen.DoubleClick
        'Nur etwas machen, wenn Eintrag ausgewählt
        If Not (lstTabellen.SelectedItem Is Nothing) Then
            'SELECT-String aus Tabellennamen erstellen
            lblSELECTCommand.Text = "SELECT * FROM [" + _
                                  lstTabellen.SelectedItem.ToString + _
                                  "]"
            'Schaltfläche ist nun frei
            btnSELECTAusführen.Enabled = True
        End If
    End Sub

    'Passt das Datumsformat aller Datumsspalten eines DataGrids an,
    'dessen DataSource bereits durch eine DataTable definiert wurde.
    Private Sub SetDateFormatInDataGrid(ByVal dg As DataGrid, ByVal Format As String)
        Dim cm As System.Windows.Forms.CurrencyManager
        Dim ts As System.Windows.Forms.DataGridTableStyle
        Dim dt As DataTable = DirectCast(dg.DataSource, DataTable)

        'Falls schon ein primärer Tabellenstil vorhanden,...
        If dg.TableStyles.Count > 0 Then
            '...dann alle löschen
            dg.TableStyles.Clear()
        End If
        'Sonst neuen Tabellenstil erstellen
        cm = DirectCast(BindingContext(dt, dt.TableName), CurrencyManager)
        ts = New System.Windows.Forms.DataGridTableStyle(cm)
        dg.TableStyles.Add(ts)

        'Alle Spalten durchlaufen
        For C As Integer = 0 To dt.Columns.Count - 1
            Dim dc As System.Data.DataColumn = dt.Columns(C)
            'Wenn System.DateTime-Datentyp gefunden, dann
            If dc.DataType Is GetType(System.DateTime) Then
                Dim cs As System.Windows.Forms.DataGridColumnStyle = dg.TableStyles(0).GridColumnStyles(C)
                If (Not (cs Is Nothing) And (cs.GetType Is GetType(System.Windows.Forms.DataGridTextBoxColumn))) Then
                    'Das Datumsformat nach der Format-Parameter-Vorgabe anpassen
                    DirectCast(cs, System.Windows.Forms.DataGridTextBoxColumn).Format = Format
                End If
            End If
        Next
    End Sub

    'Same old from here on:
    'Verbindungs-Zeichenkette setzen. Die folgende gilt nur für die Verbindung
    'zu einer Access-Datenbank
    Private Function GetConnection(ByVal AccessDatabaseName As FileInfo) As OleDbConnection

        Dim locConnectionString As String

        locConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;"
        locConnectionString += "Jet OLEDB:Registry Path=;"
        locConnectionString += "Jet OLEDB:Database Locking Mode=1;"
        locConnectionString += "Jet OLEDB:Database Password=;"
        locConnectionString += "Data Source=" + AccessDatabaseName.FullName + ";Password=;"
        locConnectionString += "Jet OLEDB:Engine Type=5;"
        locConnectionString += "Jet OLEDB:Global Bulk Transactions=1;"
        locConnectionString += "Provider=""Microsoft.Jet.OLEDB.4.0"";"
        locConnectionString += "Jet OLEDB:System database=;"
        locConnectionString += "Jet OLEDB:SFP=False;"
        locConnectionString += "Extended Properties=;"
        locConnectionString += "Mode=Share Deny None;"
        locConnectionString += "Jet OLEDB:New Database Password=;"
        locConnectionString += "Jet OLEDB:Create System Database=False;"
        locConnectionString += "Jet OLEDB:Compact Without Replica Repair=False;"
        locConnectionString += "User ID=Admin;"
        locConnectionString += "Jet OLEDB:Encrypt Database=False"
        'Neues Connection-Objekt generieren und zurückliefern
        Return New OleDbConnection(locConnectionString)

    End Function

    'Findet den Pfad, in dem die aktuelle Assembly (DLL, EXE) ausgeführt wird.
    Private Function GetStartUpPath() As DirectoryInfo
        Dim locAss As [Assembly] = [Assembly].GetExecutingAssembly
        Return New DirectoryInfo(Path.GetDirectoryName(locAss.Location))
    End Function
End Class
