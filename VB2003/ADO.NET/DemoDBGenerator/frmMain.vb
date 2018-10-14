Imports ActiveDev
Imports System.IO
Imports System.Data.OleDb

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private Const myDatenbankName As String = "Testdatenbank.mdb"
    Private myDatabaseFileinfo As FileInfo
    Private myProgress As frmProgress

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Friend WithEvents dgData As System.Windows.Forms.DataGrid
    Friend WithEvents btnNeueZufallsdatenErstellen As System.Windows.Forms.Button
    Friend WithEvents btnProgrammBeenden As System.Windows.Forms.Button
    Friend WithEvents OleDbDAMitarbeiter As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbSelectCMitarbeiter As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCMitarbeiter As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCMitarbeiter As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCMitarbeiter As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbSelectCMaschinen As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCMaschinen As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCMaschinen As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCMaschinen As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDAMaschinen As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents OleDbDAZeiten As System.Data.OleDb.OleDbDataAdapter
    Friend WithEvents myConnection As System.Data.OleDb.OleDbConnection
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents optMaschinen As System.Windows.Forms.RadioButton
    Friend WithEvents optZeiten As System.Windows.Forms.RadioButton
    Friend WithEvents optMitarbeiter As System.Windows.Forms.RadioButton
    Friend WithEvents dtpBis As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpVon As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkSamstage As System.Windows.Forms.CheckBox
    Friend WithEvents chkSonntage As System.Windows.Forms.CheckBox
    Friend WithEvents OleDbSelectCZeiten As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbInsertCZeiten As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbUpdateCZeiten As System.Data.OleDb.OleDbCommand
    Friend WithEvents OleDbDeleteCZeiten As System.Data.OleDb.OleDbCommand
    Friend WithEvents btnAnzeigen As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dgData = New System.Windows.Forms.DataGrid
        Me.btnNeueZufallsdatenErstellen = New System.Windows.Forms.Button
        Me.btnProgrammBeenden = New System.Windows.Forms.Button
        Me.OleDbDAMitarbeiter = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCMitarbeiter = New System.Data.OleDb.OleDbCommand
        Me.myConnection = New System.Data.OleDb.OleDbConnection
        Me.OleDbInsertCMitarbeiter = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCMitarbeiter = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCMitarbeiter = New System.Data.OleDb.OleDbCommand
        Me.OleDbDAMaschinen = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCMaschinen = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCMaschinen = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCMaschinen = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCMaschinen = New System.Data.OleDb.OleDbCommand
        Me.OleDbDAZeiten = New System.Data.OleDb.OleDbDataAdapter
        Me.OleDbDeleteCZeiten = New System.Data.OleDb.OleDbCommand
        Me.OleDbInsertCZeiten = New System.Data.OleDb.OleDbCommand
        Me.OleDbSelectCZeiten = New System.Data.OleDb.OleDbCommand
        Me.OleDbUpdateCZeiten = New System.Data.OleDb.OleDbCommand
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkSonntage = New System.Windows.Forms.CheckBox
        Me.chkSamstage = New System.Windows.Forms.CheckBox
        Me.dtpBis = New System.Windows.Forms.DateTimePicker
        Me.dtpVon = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.optMaschinen = New System.Windows.Forms.RadioButton
        Me.optZeiten = New System.Windows.Forms.RadioButton
        Me.optMitarbeiter = New System.Windows.Forms.RadioButton
        Me.btnAnzeigen = New System.Windows.Forms.Button
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgData
        '
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.DataMember = ""
        Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgData.Location = New System.Drawing.Point(32, 144)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(632, 320)
        Me.dgData.TabIndex = 1
        '
        'btnNeueZufallsdatenErstellen
        '
        Me.btnNeueZufallsdatenErstellen.Location = New System.Drawing.Point(272, 16)
        Me.btnNeueZufallsdatenErstellen.Name = "btnNeueZufallsdatenErstellen"
        Me.btnNeueZufallsdatenErstellen.Size = New System.Drawing.Size(176, 32)
        Me.btnNeueZufallsdatenErstellen.TabIndex = 4
        Me.btnNeueZufallsdatenErstellen.Text = "Neue Zufallsdaten erstellen"
        '
        'btnProgrammBeenden
        '
        Me.btnProgrammBeenden.Location = New System.Drawing.Point(488, 16)
        Me.btnProgrammBeenden.Name = "btnProgrammBeenden"
        Me.btnProgrammBeenden.Size = New System.Drawing.Size(176, 32)
        Me.btnProgrammBeenden.TabIndex = 5
        Me.btnProgrammBeenden.Text = "Programm beenden"
        '
        'OleDbDAMitarbeiter
        '
        Me.OleDbDAMitarbeiter.DeleteCommand = Me.OleDbDeleteCMitarbeiter
        Me.OleDbDAMitarbeiter.InsertCommand = Me.OleDbInsertCMitarbeiter
        Me.OleDbDAMitarbeiter.SelectCommand = Me.OleDbSelectCMitarbeiter
        Me.OleDbDAMitarbeiter.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Mitarbeiter", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("IDMitarbeiter", "IDMitarbeiter"), New System.Data.Common.DataColumnMapping("Nachname", "Nachname"), New System.Data.Common.DataColumnMapping("Ort", "Ort"), New System.Data.Common.DataColumnMapping("PersonalNr", "PersonalNr"), New System.Data.Common.DataColumnMapping("PLZ", "PLZ"), New System.Data.Common.DataColumnMapping("Straße", "Straße"), New System.Data.Common.DataColumnMapping("Vorname", "Vorname")})})
        Me.OleDbDAMitarbeiter.UpdateCommand = Me.OleDbUpdateCMitarbeiter
        '
        'OleDbDeleteCMitarbeiter
        '
        Me.OleDbDeleteCMitarbeiter.CommandText = "DELETE FROM Mitarbeiter WHERE (IDMitarbeiter = ?) AND (Nachname = ? OR ? IS NULL " & _
        "AND Nachname IS NULL) AND (Ort = ? OR ? IS NULL AND Ort IS NULL) AND (PLZ = ? OR" & _
        " ? IS NULL AND PLZ IS NULL) AND (PersonalNr = ? OR ? IS NULL AND PersonalNr IS N" & _
        "ULL) AND (Straße = ? OR ? IS NULL AND Straße IS NULL) AND (Vorname = ? OR ? IS N" & _
        "ULL AND Vorname IS NULL)"
        Me.OleDbDeleteCMitarbeiter.Connection = Me.myConnection
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nachname", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nachname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nachname1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nachname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ort", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ort1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PLZ", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PLZ", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PLZ1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PLZ", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PersonalNr", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PersonalNr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PersonalNr1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PersonalNr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Straße", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Straße", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Straße1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Straße", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vorname", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vorname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vorname1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vorname", System.Data.DataRowVersion.Original, Nothing))
        '
        'myConnection
        '
        'Me.myConnection.ConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database L" & _
        '"ocking Mode=1;Jet OLEDB:Database Password=;Data Source=""D:\Writing\CurrProj\Micr" & _
        '"osoft\VB.NET\Prgs\ADO.NET\DemoDBGenerator\bin\Testdatenbank.mdb"";Password=;Jet O" & _
        '"LEDB:Engine Type=5;Jet OLEDB:Global Bulk Transactions=1;Provider=""Microsoft.Jet." & _
        '"OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;Extended Properties=;M" & _
        '"ode=Share Deny None;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Dat" & _
        '"abase=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Witho" & _
        '"ut Replica Repair=False;User ID=Admin;Jet OLEDB:Encrypt Database=False"
        '
        'OleDbInsertCMitarbeiter
        '
        Me.OleDbInsertCMitarbeiter.CommandText = "INSERT INTO Mitarbeiter(Nachname, Ort, PersonalNr, PLZ, Straße, Vorname) VALUES (" & _
        "?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCMitarbeiter.Connection = Me.myConnection
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarWChar, 255, "Nachname"))
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarWChar, 255, "Ort"))
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("PersonalNr", System.Data.OleDb.OleDbType.Integer, 0, "PersonalNr"))
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("PLZ", System.Data.OleDb.OleDbType.VarWChar, 20, "PLZ"))
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Straße", System.Data.OleDb.OleDbType.VarWChar, 255, "Straße"))
        Me.OleDbInsertCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarWChar, 255, "Vorname"))
        '
        'OleDbSelectCMitarbeiter
        '
        Me.OleDbSelectCMitarbeiter.CommandText = "SELECT IDMitarbeiter, Nachname, Ort, PersonalNr, PLZ, Straße, Vorname FROM Mitarb" & _
        "eiter"
        Me.OleDbSelectCMitarbeiter.Connection = Me.myConnection
        '
        'OleDbUpdateCMitarbeiter
        '
        Me.OleDbUpdateCMitarbeiter.CommandText = "UPDATE Mitarbeiter SET Nachname = ?, Ort = ?, PersonalNr = ?, PLZ = ?, Straße = ?" & _
        ", Vorname = ? WHERE (IDMitarbeiter = ?) AND (Nachname = ? OR ? IS NULL AND Nachn" & _
        "ame IS NULL) AND (Ort = ? OR ? IS NULL AND Ort IS NULL) AND (PLZ = ? OR ? IS NUL" & _
        "L AND PLZ IS NULL) AND (PersonalNr = ? OR ? IS NULL AND PersonalNr IS NULL) AND " & _
        "(Straße = ? OR ? IS NULL AND Straße IS NULL) AND (Vorname = ? OR ? IS NULL AND V" & _
        "orname IS NULL)"
        Me.OleDbUpdateCMitarbeiter.Connection = Me.myConnection
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Nachname", System.Data.OleDb.OleDbType.VarWChar, 255, "Nachname"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Ort", System.Data.OleDb.OleDbType.VarWChar, 255, "Ort"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("PersonalNr", System.Data.OleDb.OleDbType.Integer, 0, "PersonalNr"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("PLZ", System.Data.OleDb.OleDbType.VarWChar, 20, "PLZ"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Straße", System.Data.OleDb.OleDbType.VarWChar, 255, "Straße"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Vorname", System.Data.OleDb.OleDbType.VarWChar, 255, "Vorname"))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nachname", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nachname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Nachname1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Nachname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ort", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Ort1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Ort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PLZ", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PLZ", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PLZ1", System.Data.OleDb.OleDbType.VarWChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PLZ", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PersonalNr", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PersonalNr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PersonalNr1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PersonalNr", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Straße", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Straße", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Straße1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Straße", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vorname", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vorname", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMitarbeiter.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Vorname1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Vorname", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDAMaschinen
        '
        Me.OleDbDAMaschinen.DeleteCommand = Me.OleDbDeleteCMaschinen
        Me.OleDbDAMaschinen.InsertCommand = Me.OleDbInsertCMaschinen
        Me.OleDbDAMaschinen.SelectCommand = Me.OleDbSelectCMaschinen
        Me.OleDbDAMaschinen.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Maschinen", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Beschreibung", "Beschreibung"), New System.Data.Common.DataColumnMapping("IDMaschinen", "IDMaschinen"), New System.Data.Common.DataColumnMapping("Standort", "Standort"), New System.Data.Common.DataColumnMapping("Typbezeichnung", "Typbezeichnung"), New System.Data.Common.DataColumnMapping("WartungNötig", "WartungNötig")})})
        Me.OleDbDAMaschinen.UpdateCommand = Me.OleDbUpdateCMaschinen
        '
        'OleDbDeleteCMaschinen
        '
        Me.OleDbDeleteCMaschinen.CommandText = "DELETE FROM Maschinen WHERE (IDMaschinen = ?) AND (Standort = ? OR ? IS NULL AND " & _
        "Standort IS NULL) AND (Typbezeichnung = ? OR ? IS NULL AND Typbezeichnung IS NUL" & _
        "L) AND (WartungNötig = ?)"
        Me.OleDbDeleteCMaschinen.Connection = Me.myConnection
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Standort", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Standort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Standort1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Standort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Typbezeichnung", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Typbezeichnung", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Typbezeichnung1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Typbezeichnung", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_WartungNötig", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WartungNötig", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCMaschinen
        '
        Me.OleDbInsertCMaschinen.CommandText = "INSERT INTO Maschinen(Beschreibung, Standort, Typbezeichnung, WartungNötig) VALUE" & _
        "S (?, ?, ?, ?)"
        Me.OleDbInsertCMaschinen.Connection = Me.myConnection
        Me.OleDbInsertCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, "Beschreibung"))
        Me.OleDbInsertCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Standort", System.Data.OleDb.OleDbType.VarWChar, 50, "Standort"))
        Me.OleDbInsertCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Typbezeichnung", System.Data.OleDb.OleDbType.VarWChar, 50, "Typbezeichnung"))
        Me.OleDbInsertCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("WartungNötig", System.Data.OleDb.OleDbType.Boolean, 2, "WartungNötig"))
        '
        'OleDbSelectCMaschinen
        '
        Me.OleDbSelectCMaschinen.CommandText = "SELECT Beschreibung, IDMaschinen, Standort, Typbezeichnung, WartungNötig FROM Mas" & _
        "chinen"
        Me.OleDbSelectCMaschinen.Connection = Me.myConnection
        '
        'OleDbUpdateCMaschinen
        '
        Me.OleDbUpdateCMaschinen.CommandText = "UPDATE Maschinen SET Beschreibung = ?, Standort = ?, Typbezeichnung = ?, WartungN" & _
        "ötig = ? WHERE (IDMaschinen = ?) AND (Standort = ? OR ? IS NULL AND Standort IS " & _
        "NULL) AND (Typbezeichnung = ? OR ? IS NULL AND Typbezeichnung IS NULL) AND (Wart" & _
        "ungNötig = ?)"
        Me.OleDbUpdateCMaschinen.Connection = Me.myConnection
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Beschreibung", System.Data.OleDb.OleDbType.VarWChar, 0, "Beschreibung"))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Standort", System.Data.OleDb.OleDbType.VarWChar, 50, "Standort"))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Typbezeichnung", System.Data.OleDb.OleDbType.VarWChar, 50, "Typbezeichnung"))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("WartungNötig", System.Data.OleDb.OleDbType.Boolean, 2, "WartungNötig"))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Standort", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Standort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Standort1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Standort", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Typbezeichnung", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Typbezeichnung", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Typbezeichnung1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Typbezeichnung", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCMaschinen.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_WartungNötig", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "WartungNötig", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbDAZeiten
        '
        Me.OleDbDAZeiten.DeleteCommand = Me.OleDbDeleteCZeiten
        Me.OleDbDAZeiten.InsertCommand = Me.OleDbInsertCZeiten
        Me.OleDbDAZeiten.SelectCommand = Me.OleDbSelectCZeiten
        Me.OleDbDAZeiten.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Zeiten", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("Buchungsdatum", "Buchungsdatum"), New System.Data.Common.DataColumnMapping("Dauer", "Dauer"), New System.Data.Common.DataColumnMapping("EndZeit", "EndZeit"), New System.Data.Common.DataColumnMapping("IDMaschinen", "IDMaschinen"), New System.Data.Common.DataColumnMapping("IDMitarbeiter", "IDMitarbeiter"), New System.Data.Common.DataColumnMapping("IDZeiten", "IDZeiten"), New System.Data.Common.DataColumnMapping("StartZeit", "StartZeit")})})
        Me.OleDbDAZeiten.UpdateCommand = Me.OleDbUpdateCZeiten
        '
        'OleDbDeleteCZeiten
        '
        Me.OleDbDeleteCZeiten.CommandText = "DELETE FROM Zeiten WHERE (IDZeiten = ?) AND (Buchungsdatum = ? OR ? IS NULL AND B" & _
        "uchungsdatum IS NULL) AND (Dauer = ? OR ? IS NULL AND Dauer IS NULL) AND (EndZei" & _
        "t = ? OR ? IS NULL AND EndZeit IS NULL) AND (IDMaschinen = ? OR ? IS NULL AND ID" & _
        "Maschinen IS NULL) AND (IDMitarbeiter = ? OR ? IS NULL AND IDMitarbeiter IS NULL" & _
        ") AND (StartZeit = ? OR ? IS NULL AND StartZeit IS NULL)"
        Me.OleDbDeleteCZeiten.Connection = Me.myConnection
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDZeiten", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDZeiten", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Buchungsdatum", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Buchungsdatum", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Buchungsdatum1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Buchungsdatum", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dauer", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dauer1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dauer", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EndZeit", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EndZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EndZeit1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EndZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StartZeit", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbDeleteCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StartZeit1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartZeit", System.Data.DataRowVersion.Original, Nothing))
        '
        'OleDbInsertCZeiten
        '
        Me.OleDbInsertCZeiten.CommandText = "INSERT INTO Zeiten(Buchungsdatum, Dauer, EndZeit, IDMaschinen, IDMitarbeiter, Sta" & _
        "rtZeit) VALUES (?, ?, ?, ?, ?, ?)"
        Me.OleDbInsertCZeiten.Connection = Me.myConnection
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 0, "Buchungsdatum"))
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"))
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndZeit", System.Data.OleDb.OleDbType.Date, 0, "EndZeit"))
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, "IDMaschinen"))
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, "IDMitarbeiter"))
        Me.OleDbInsertCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartZeit", System.Data.OleDb.OleDbType.Date, 0, "StartZeit"))
        '
        'OleDbSelectCZeiten
        '
        Me.OleDbSelectCZeiten.CommandText = "SELECT Buchungsdatum, Dauer, EndZeit, IDMaschinen, IDMitarbeiter, IDZeiten, Start" & _
        "Zeit FROM Zeiten"
        Me.OleDbSelectCZeiten.Connection = Me.myConnection
        '
        'OleDbUpdateCZeiten
        '
        Me.OleDbUpdateCZeiten.CommandText = "UPDATE Zeiten SET Buchungsdatum = ?, Dauer = ?, EndZeit = ?, IDMaschinen = ?, IDM" & _
        "itarbeiter = ?, StartZeit = ? WHERE (IDZeiten = ?) AND (Buchungsdatum = ? OR ? I" & _
        "S NULL AND Buchungsdatum IS NULL) AND (Dauer = ? OR ? IS NULL AND Dauer IS NULL)" & _
        " AND (EndZeit = ? OR ? IS NULL AND EndZeit IS NULL) AND (IDMaschinen = ? OR ? IS" & _
        " NULL AND IDMaschinen IS NULL) AND (IDMitarbeiter = ? OR ? IS NULL AND IDMitarbe" & _
        "iter IS NULL) AND (StartZeit = ? OR ? IS NULL AND StartZeit IS NULL)"
        Me.OleDbUpdateCZeiten.Connection = Me.myConnection
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Buchungsdatum", System.Data.OleDb.OleDbType.Date, 0, "Buchungsdatum"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Dauer", System.Data.OleDb.OleDbType.Integer, 0, "Dauer"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("EndZeit", System.Data.OleDb.OleDbType.Date, 0, "EndZeit"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, "IDMaschinen"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, "IDMitarbeiter"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("StartZeit", System.Data.OleDb.OleDbType.Date, 0, "StartZeit"))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDZeiten", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDZeiten", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Buchungsdatum", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Buchungsdatum", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Buchungsdatum1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Buchungsdatum", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dauer", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dauer", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Dauer1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Dauer", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EndZeit", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EndZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EndZeit1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EndZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMaschinen1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMaschinen", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_IDMitarbeiter1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "IDMitarbeiter", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StartZeit", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartZeit", System.Data.DataRowVersion.Original, Nothing))
        Me.OleDbUpdateCZeiten.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_StartZeit1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "StartZeit", System.Data.DataRowVersion.Original, Nothing))
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkSonntage)
        Me.GroupBox1.Controls.Add(Me.chkSamstage)
        Me.GroupBox1.Controls.Add(Me.dtpBis)
        Me.GroupBox1.Controls.Add(Me.dtpVon)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(264, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 80)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Zeitdaten erstellen von/bis:"
        '
        'chkSonntage
        '
        Me.chkSonntage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSonntage.Location = New System.Drawing.Point(208, 56)
        Me.chkSonntage.Name = "chkSonntage"
        Me.chkSonntage.Size = New System.Drawing.Size(184, 16)
        Me.chkSonntage.TabIndex = 3
        Me.chkSonntage.Text = "Sonntage mit einbeziehen"
        '
        'chkSamstage
        '
        Me.chkSamstage.Checked = True
        Me.chkSamstage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSamstage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSamstage.Location = New System.Drawing.Point(8, 56)
        Me.chkSamstage.Name = "chkSamstage"
        Me.chkSamstage.Size = New System.Drawing.Size(184, 16)
        Me.chkSamstage.TabIndex = 2
        Me.chkSamstage.Text = "Samstage mit einbeziehen"
        '
        'dtpBis
        '
        Me.dtpBis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpBis.Location = New System.Drawing.Point(208, 24)
        Me.dtpBis.Name = "dtpBis"
        Me.dtpBis.Size = New System.Drawing.Size(184, 20)
        Me.dtpBis.TabIndex = 1
        '
        'dtpVon
        '
        Me.dtpVon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpVon.Location = New System.Drawing.Point(8, 24)
        Me.dtpVon.Name = "dtpVon"
        Me.dtpVon.Size = New System.Drawing.Size(184, 20)
        Me.dtpVon.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAnzeigen)
        Me.GroupBox2.Controls.Add(Me.optMaschinen)
        Me.GroupBox2.Controls.Add(Me.optZeiten)
        Me.GroupBox2.Controls.Add(Me.optMitarbeiter)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(32, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(224, 128)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datentabellen:"
        '
        'optMaschinen
        '
        Me.optMaschinen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMaschinen.Location = New System.Drawing.Point(16, 72)
        Me.optMaschinen.Name = "optMaschinen"
        Me.optMaschinen.Size = New System.Drawing.Size(112, 16)
        Me.optMaschinen.TabIndex = 11
        Me.optMaschinen.Text = "Maschinendaten"
        '
        'optZeiten
        '
        Me.optZeiten.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optZeiten.Location = New System.Drawing.Point(16, 48)
        Me.optZeiten.Name = "optZeiten"
        Me.optZeiten.Size = New System.Drawing.Size(168, 16)
        Me.optZeiten.TabIndex = 10
        Me.optZeiten.Text = "Arbeitszeiten der Mitarbeiter"
        '
        'optMitarbeiter
        '
        Me.optMitarbeiter.Checked = True
        Me.optMitarbeiter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMitarbeiter.Location = New System.Drawing.Point(16, 24)
        Me.optMitarbeiter.Name = "optMitarbeiter"
        Me.optMitarbeiter.Size = New System.Drawing.Size(104, 16)
        Me.optMitarbeiter.TabIndex = 9
        Me.optMitarbeiter.TabStop = True
        Me.optMitarbeiter.Text = "Mitarbeiterdaten"
        '
        'btnAnzeigen
        '
        Me.btnAnzeigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnzeigen.Location = New System.Drawing.Point(40, 96)
        Me.btnAnzeigen.Name = "btnAnzeigen"
        Me.btnAnzeigen.Size = New System.Drawing.Size(160, 24)
        Me.btnAnzeigen.TabIndex = 12
        Me.btnAnzeigen.Text = "Daten anzeigen"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(688, 478)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnProgrammBeenden)
        Me.Controls.Add(Me.btnNeueZufallsdatenErstellen)
        Me.Controls.Add(Me.dgData)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Demo-Datenbank-Generator (für: Visual Basic: Das Entwicklerbuch; MSPress 2004)"
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (myConnection Is Nothing) Then
                myConnection.Close()
            End If
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        'Feststellen, ob die Datenbank überhaupt existiert
        Me.Visible = True
        'Datumsbereich vom 1. des Vor-Vorherigen Monats,
        dtpVon.Value = New Date(Now.Year, Now.Month, 1).AddMonths(-2)
        'Bis zum letzten des Vormonats
        dtpBis.Value = New Date(Now.Year, Now.Month, 1).Subtract(New TimeSpan(1, 0, 0, 0, 0))

        Dim locDI As New DirectoryInfo(Application.StartupPath)
        locDI = locDI.Parent.Parent
        myDatabaseFileinfo = New FileInfo(locDI.FullName + "\" + myDatenbankName)
        SetConnectionString(myDatabaseFileinfo)
        If Not myDatabaseFileinfo.Exists Then
            Dim locDR As DialogResult = MessageBox.Show("Die Demo-Datenbank existiert noch nicht." + vbNewLine + _
                                      "Soll die Datenbank neu erstellt werden?", _
                                      "Datenbank neu erstellen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If locDR = DialogResult.Yes Then
                ErstelleDemoDB(myDatabaseFileinfo, True)
            Else
                Me.Dispose()
            End If
        End If
    End Sub

    Private Sub ErstelleDemoDB(ByVal fileinfo As FileInfo, ByVal CreateDatabase As Boolean)
        'Statusdialog erstellen
        myProgress = New frmProgress
        myProgress.Show()
        myProgress.Refresh()
        If CreateDatabase Then
            myProgress.lblStatustext.Text = "Datenbank wird erstellt..."
            myProgress.lblStatustext.Refresh()
            ADAdoJet.CreateDatabase(fileinfo)
            SetConnectionString(myDatabaseFileinfo)
            myConnection.Open()
            myProgress.lblStatustext.Text = "Mitarbeitertabelle wird angelegt..."
            myProgress.lblStatustext.Refresh()
            ADAdoJet.CreateTable(myConnection, "Mitarbeiter", "IDMitarbeiter")
            ErstelleMitarbeiterTabelle()
            myProgress.lblStatustext.Text = "Maschinentabelle wird angelegt..."
            myProgress.lblStatustext.Refresh()
            ADAdoJet.CreateTable(myConnection, "Maschinen", "IDMaschinen")
            ErstelleMaschinenTabelle()
            myProgress.lblStatustext.Text = "Zeitentabelle wird angelegt..."
            myProgress.lblStatustext.Refresh()
            ADAdoJet.CreateTable(myConnection, "Zeiten", "IDZeiten")
            ErstelleZeitenTabelle()
            myConnection.Close()
        End If

        MaschinendatenErstellen()
        MitarbeiterdatenErstellen(100)
        ZeitdatenErstellen(dtpVon.Value, dtpBis.Value, chkSamstage.Checked, chkSonntage.Checked)
        myProgress.Close()

    End Sub

    Private Sub SetConnectionString(ByVal fileinfo As FileInfo)

        Dim locConnectionString As String

        locConnectionString = "Jet OLEDB:Global Partial Bulk Ops=2;"
        locConnectionString += "Jet OLEDB:Registry Path=;"
        locConnectionString += "Jet OLEDB:Database Locking Mode=1;"
        locConnectionString += "Jet OLEDB:Database Password=;"
        locConnectionString += "Data Source=" + fileinfo.FullName + ";Password=;"
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
        Me.myConnection.ConnectionString = locConnectionString

    End Sub

    Private Sub ErstelleMitarbeiterTabelle()
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("PersonalNr", OleDbType.Integer, 0, ADCreateIndexEnum.CreateUnique))
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("Nachname", OleDbType.WChar, 255, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("Vorname", OleDbType.WChar, 255))
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("Straße", OleDbType.WChar, 255))
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("PLZ", OleDbType.WChar, 20, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Mitarbeiter", New ADFieldInfo("Ort", OleDbType.WChar, 255))
    End Sub

    Private Sub ErstelleZeitenTabelle()
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("IDMitarbeiter", OleDbType.Integer, 0, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("IDMaschinen", OleDbType.Integer, 0, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("Buchungsdatum", OleDbType.Date, 0, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("StartZeit", OleDbType.Date, 0, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("EndZeit", OleDbType.Date, 0, ADCreateIndexEnum.CreateAmbiguous))
        ADAdoJet.CreateField(myConnection, "Zeiten", New ADFieldInfo("Dauer", OleDbType.Integer, 0, ADCreateIndexEnum.CreateAmbiguous))
    End Sub

    Private Sub ErstelleMaschinenTabelle()
        ADAdoJet.CreateField(myConnection, "Maschinen", New ADFieldInfo("Typbezeichnung", OleDbType.WChar, 50))
        ADAdoJet.CreateField(myConnection, "Maschinen", New ADFieldInfo("Beschreibung", OleDbType.VarWChar))
        ADAdoJet.CreateField(myConnection, "Maschinen", New ADFieldInfo("Standort", OleDbType.WChar, 50))
        ADAdoJet.CreateField(myConnection, "Maschinen", New ADFieldInfo("WartungNötig", OleDbType.Boolean))
    End Sub

    Private Sub btnNeueZufallsdatenErstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNeueZufallsdatenErstellen.Click
        ErstelleDemoDB(myDatabaseFileinfo, False)
    End Sub

    Private Sub MaschinendatenErstellen()

        Dim locMaschinen As New DSMaschinen

        myProgress.lblStatustext.Text = "Vorhandene Maschinendaten löschen..."
        myProgress.lblStatustext.Refresh()
        'Alle Vorhandenen Daten löschen
        Dim locCommand As New OleDbCommand("DELETE * From Maschinen", myConnection)
        If Not (myConnection.State = ConnectionState.Open) Then
            myConnection.Open()
        End If
        locCommand.ExecuteNonQuery()
        myProgress.lblStatustext.Text = "Maschinendaten anlegen..."
        myProgress.lblStatustext.Refresh()

        locMaschinen.Maschinen.AddMaschinenRow("Presse 1", "Halle 4", "Siemens Xgh4", False)
        locMaschinen.Maschinen.AddMaschinenRow("Presse 2", "Halle 4", "Siemens Xgh4", False)
        locMaschinen.Maschinen.AddMaschinenRow("Presse 3", "Halle 5", "Siemens Xgh4", False)
        locMaschinen.Maschinen.AddMaschinenRow("Walze 1", "Halle 1", "Krupp Wa1", False)
        locMaschinen.Maschinen.AddMaschinenRow("Walze 2", "Halle 2", "Krupp Wa2", False)
        locMaschinen.Maschinen.AddMaschinenRow("Walze 3", "Halle 6", "Krupp Wa3", False)
        locMaschinen.Maschinen.AddMaschinenRow("Sakomat 1", "Halle 3", "Sakomat A3", False)
        locMaschinen.Maschinen.AddMaschinenRow("Sakomat 2", "Halle 3", "Sakomat A3", False)
        locMaschinen.Maschinen.AddMaschinenRow("Sakomat 3", "Halle 3", "Sakomat A3", False)
        locMaschinen.Maschinen.AddMaschinenRow("Mischstation 1", "Halle 7", "- - - -", False)
        locMaschinen.Maschinen.AddMaschinenRow("Mischstation 2", "Halle 7", "- - - -", False)
        locMaschinen.Maschinen.AddMaschinenRow("Fertigungsstraße A", "Halle 8", "- - - -", False)
        locMaschinen.Maschinen.AddMaschinenRow("Fertigungsstraße B", "Halle 9", "- - - -", False)
        OleDbDAMaschinen.Update(locMaschinen)

    End Sub

    Private Sub MitarbeiterdatenErstellen(ByVal Anzahl As Integer)

        Dim locMitarbeiter As New DSMitarbeiter
        Dim locRandom As New Random(Now.Millisecond)

        Dim locNachnamen As String() = {"Heckhuis", "Löffelmann", "Thiemann", "Müller", _
                    "Meier", "Tiemann", "Sonntag", "Ademmer", "Westermann", "Vüllers", _
                    "Hollmann", "Vielstedde", "Weigel", "Weichel", "Weichelt", "Hoffmann", _
                    "Rode", "Trouw", "Schindler", "Neumann", "Jungemann", "Hörstmann", _
                    "Tinoco", "Albrecht", "Langenbach", "Braun", "Plenge", "Englisch", _
                    "Clarke"}

        Dim locVornamen As String() = {"Jürgen", "Gabriele", "Uwe", "Katrin", "Hans", _
                    "Rainer", "Christian", "Uta", "Michaela", "Franz", "Anne", "Anja", _
                    "Theo", "Momo", "Katrin", "Guido", "Barbara", "Bernhard", "Margarete", _
                    "Alfred", "Melanie", "Britta", "José", "Thomas", "Daja", "Klaus", "Axel", _
                    "Lothar", "Gareth"}

        Dim locStraßen As String() = {"Kurgartenweg", "Parkstraße", "Alter Postweg", "Stadtstraße", "Aue", _
                    "Windpockenallee", "Hauptstraße", "Südring", "Nordring", "Himmelspforte", _
                    "Thiemannweg", "Ausfallstraße", "Absturzpfad", "Crash Ave", "Main Road", "Am Tor", _
                    "Am Brunnen", "Dorfplatz", "Dorfgasse", "Gassenstraße", "Reiterweg", "Kleine Gasse", _
                    "Lange Straße", "Altstadtplatz"}

        Dim locStädte As String() = {"Wuppertal", "Dortmund", "Lippstadt", "Soest", _
                    "Liebenburg", "Hildesheim", "München", "Berlin", "Rheda", "Bielefeld", _
                    "Braunschweig", "Unterschleißheim", "Wiesbaden", "Straubing", _
                    "Bad Waldliesborn", "Lippetal", "Stirpe", "Erwitte"}

        'Alle Vorhandenen Daten löschen
        myProgress.lblStatustext.Text = "Vorhandene Mitarbeiterdaten löschen..."
        myProgress.lblStatustext.Refresh()
        Dim locCommand As New OleDbCommand("DELETE * From Mitarbeiter", myConnection)
        If Not (myConnection.State = ConnectionState.Open) Then
            myConnection.Open()
        End If
        locCommand.ExecuteNonQuery()

        myProgress.lblStatustext.Text = "Mitarbeiterdaten generieren..."
        myProgress.lblStatustext.Refresh()
        myProgress.ProgressBar.Maximum = Anzahl
        For i As Integer = 1 To Anzahl
            Dim locName, locVorname As String
            locName = locNachnamen(locRandom.Next(locNachnamen.Length - 1))
            locVorname = locVornamen(locRandom.Next(locNachnamen.Length - 1))
            locMitarbeiter.Mitarbeiter.AddMitarbeiterRow(locName, _
                                                        locStädte(locRandom.Next(locStädte.Length - 1)), _
                                                        i, _
                                                        locRandom.Next(99999).ToString("00000"), _
                                                        locStraßen(locRandom.Next(locStraßen.Length - 1)), _
                                                        locVorname)
            myProgress.ProgressBar.Value = i
            myProgress.ProgressBar.Refresh()
        Next
        OleDbDAMitarbeiter.UpdateCommand.Connection = myConnection
        OleDbDAMitarbeiter.Update(locMitarbeiter)
    End Sub

    Private Sub ZeitdatenErstellen(ByVal VonDatum As Date, ByVal BisDatum As Date, _
                                    ByVal SamstagsArbeiten As Boolean, ByVal SonntagsArbeiten As Boolean)

        Dim locArbeitsbegin As Date = #7:00:00 AM#
        Dim locMitarbeiter As New DSMitarbeiter
        Dim locZeiten As New DSZeiten
        Dim locMaschinen As New DSMaschinen
        Dim locRandom As New Random(Now.Millisecond)
        Dim locStartZeit, locEndzeit As Date
        Dim locDauer As Integer
        Dim locProgressZähler As Integer

        'Alle Vorhandenen Zeiten löschen
        myProgress.lblStatustext.Text = "Vorhandene Zeitdaten löschen..."
        myProgress.lblStatustext.Refresh()
        Dim locCommand As New OleDbCommand("DELETE * From Zeiten", myConnection)
        If Not (myConnection.State = ConnectionState.Open) Then
            myConnection.Open()
        End If
        locCommand.ExecuteNonQuery()

        OleDbDAMitarbeiter.Fill(locMitarbeiter)
        OleDbDAMaschinen.Fill(locMaschinen)

        Dim locTagezähler As Date = VonDatum
        myProgress.ProgressBar.Maximum = CInt(BisDatum.Subtract(VonDatum).TotalDays)

        Do While locTagezähler < BisDatum


            myProgress.lblStatustext.Text = "Zeitdaten generieren für:" + vbNewLine + _
                                            locTagezähler.ToString("dddd, dd.MM.yyyy")
            myProgress.lblStatustext.Refresh()
            myProgress.ProgressBar.Value = locProgressZähler
            myProgress.ProgressBar.Refresh()
            locProgressZähler += 1

            If (Not SamstagsArbeiten) And Weekday(locTagezähler) = 7 Then
                locTagezähler = locTagezähler.AddDays(1)
                'Ich bin gerne zu Diskussionen bereit!
                '(In Whidbey steht hier einfach nur ein 'Continue', um diesen Durchlauf zu überspringen)
                GoTo doContinue
            End If

            If (Not SonntagsArbeiten) And Weekday(locTagezähler) = 1 Then
                locTagezähler = locTagezähler.AddDays(1)
                'Ich bin gerne zu Diskussionen bereit!
                '(In Whidbey steht hier einfach nur ein 'Continue', um diesen Durchlauf zu überspringen)
                GoTo doContinue
            End If


            'Alle Mitarbeiter durchlaufen
            For Each ma As DSMitarbeiter.MitarbeiterRow In locMitarbeiter.Mitarbeiter
                '10% Krankheitsstand/Urlaub sind realistisch
                If locRandom.Next(100) < 90 Then
                    Dim locMaschine As Integer = locRandom.Next(0, locMaschinen.Maschinen.Count - 1)
                    'Morgens zwei Buchungen? (Wahrscheinlich dafür ist 1:4)
                    If locRandom.Next(0, 3) = 2 Then
                        'Gleitzeit: Bis zu 120 Minuten später anfangen
                        locStartZeit = locArbeitsbegin.AddMinutes(locRandom.Next(-10, 120))
                        locDauer = 100 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                        locStartZeit = locEndzeit
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locMaschine = locRandom.Next(0, locMaschinen.Maschinen.Count - 1)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                    Else
                        'Gleitzeit: Bis zu 120 Minuten später anfangen
                        locStartZeit = locArbeitsbegin.AddMinutes(locRandom.Next(-10, 120))
                        locDauer = 200 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                    End If

                    'Pause buchen
                    locStartZeit = locEndzeit
                    locDauer = 30 + locRandom.Next(-5, 5)
                    locEndzeit = locStartZeit.AddMinutes(locDauer)
                    locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, 0, ma.IDMitarbeiter, locStartZeit)

                    'Nachmittags zwei Buchungen? (Wahrscheinlich dafür ist ebenfalls 1:4)
                    If locRandom.Next(0, 3) = 2 Then
                        locStartZeit = locEndzeit
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                        locStartZeit = locEndzeit
                        locDauer = 100 + locRandom.Next(-10, 10)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locMaschine = locRandom.Next(0, locMaschinen.Maschinen.Count - 1)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                    Else
                        locStartZeit = locEndzeit
                        locDauer = 200 + locRandom.Next(-10, 20)
                        locEndzeit = locStartZeit.AddMinutes(locDauer)
                        locZeiten.Zeiten.AddZeitenRow(locTagezähler, locDauer, locEndzeit, locMaschine, ma.IDMitarbeiter, locStartZeit)
                    End If
                End If

            Next
            locTagezähler = locTagezähler.AddDays(1)
            'Tageweise in die Datenbank schreiben

            OleDbDAZeiten.Update(locZeiten)
            locZeiten.Zeiten.Clear()
            Application.DoEvents()
doContinue:
        Loop

    End Sub

    Private Sub btnProgrammBeenden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgrammBeenden.Click
        Me.Dispose()
    End Sub

    Private Sub MitarbeiterdatenAnzeigen()
        Dim locMitarbeiter As New DSMitarbeiter
        OleDbDAMitarbeiter.Fill(locMitarbeiter)
        dgData.DataSource = locMitarbeiter.Mitarbeiter
    End Sub

    Private Sub MaschinendatenAnzeigen()
        Dim locMaschinen As New DSMaschinen
        OleDbDAMaschinen.Fill(locMaschinen)
        dgData.DataSource = locMaschinen.Maschinen
    End Sub

    Private Sub BuchungsdatenAnzeigen()
        Dim locZeiten As New DSZeiten
        OleDbDAZeiten.SelectCommand = New OleDbCommand("SELECT TOP 100 * FROM Zeiten", myConnection)
        OleDbDAZeiten.Fill(locZeiten)
        dgData.DataSource = locZeiten.Zeiten
    End Sub

    Private Sub btnAnzeigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnzeigen.Click
        If optMaschinen.Checked Then
            MaschinendatenAnzeigen()
        ElseIf optMitarbeiter.Checked Then
            MitarbeiterdatenAnzeigen()
        Else
            BuchungsdatenAnzeigen()
        End If
    End Sub
End Class


