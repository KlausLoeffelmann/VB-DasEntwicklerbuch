<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAuswertungProjekteReport
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
        Me.ReportProjektDataTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportProjektDataTableTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ReportProjektDataTableTableAdapter
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportProjektDataTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "HeckTickDataSet_ReportProjektDataTable"
        ReportDataSource1.Value = Me.ReportProjektDataTableBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HeckTick.rptProjekt.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(633, 519)
        Me.ReportViewer1.TabIndex = 0
        '
        'HeckTickDataSet
        '
        Me.HeckTickDataSet.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportProjektDataTableBindingSource
        '
        Me.ReportProjektDataTableBindingSource.DataMember = "ReportProjektDataTable"
        Me.ReportProjektDataTableBindingSource.DataSource = Me.HeckTickDataSet
        '
        'ReportProjektDataTableTableAdapter
        '
        Me.ReportProjektDataTableTableAdapter.ClearBeforeFill = True
        '
        'frmAuswertungProjekteReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 519)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmAuswertungProjekteReport"
        Me.Text = "frmAuswertungProjekte"
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportProjektDataTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ReportProjektDataTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeckTickDataSet As HeckTick.HeckTickDataSet
    Friend WithEvents ReportProjektDataTableTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ReportProjektDataTableTableAdapter
End Class
