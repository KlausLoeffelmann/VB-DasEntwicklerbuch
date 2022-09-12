<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuswertungBeraterReport
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.HeckTickDataSet = New HeckTick.HeckTickDataSet
        Me.ReportBeraterDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportBeraterDataTableTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ReportBeraterDataTableTableAdapter
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportBeraterDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HeckTickDataSet_ReportBeraterDataTable"
        ReportDataSource1.Value = Me.ReportBeraterDataTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HeckTick.rptBerater.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(577, 450)
        Me.ReportViewer1.TabIndex = 0
        '
        'HeckTickDataSet
        '
        Me.HeckTickDataSet.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportBeraterDataTableBindingSource
        '
        Me.ReportBeraterDataTableBindingSource.DataMember = "ReportBeraterDataTable"
        Me.ReportBeraterDataTableBindingSource.DataSource = Me.HeckTickDataSet
        '
        'ReportBeraterDataTableTableAdapter
        '
        Me.ReportBeraterDataTableTableAdapter.ClearBeforeFill = True
        '
        'frmAuswertungBeraterReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 450)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmAuswertungBeraterReport"
        Me.Text = "frmAuswertungBeraterReport"
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportBeraterDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportBeraterDataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeckTickDataSet As HeckTick.HeckTickDataSet
    Friend WithEvents ReportBeraterDataTableTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ReportBeraterDataTableTableAdapter
End Class
