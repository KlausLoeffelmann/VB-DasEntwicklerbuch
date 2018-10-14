<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZeiten
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
        Me.HeckTickDataSet = New HeckTick.HeckTickDataSet
        Me.ZeitenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZeitenTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
        Me.BeraterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProjekteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProjekteTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
        Me.BeraterTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeraterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeckTickDataSet
        '
        Me.HeckTickDataSet.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ZeitenBindingSource
        '
        Me.ZeitenBindingSource.DataMember = "Zeiten"
        Me.ZeitenBindingSource.DataSource = Me.HeckTickDataSet
        '
        'ZeitenTableAdapter
        '
        Me.ZeitenTableAdapter.ClearBeforeFill = True
        '
        'BeraterBindingSource
        '
        Me.BeraterBindingSource.DataMember = "Berater"
        Me.BeraterBindingSource.DataSource = Me.HeckTickDataSet
        '
        'ProjekteBindingSource
        '
        Me.ProjekteBindingSource.DataMember = "Projekte"
        Me.ProjekteBindingSource.DataSource = Me.HeckTickDataSet
        '
        'ProjekteTableAdapter
        '
        Me.ProjekteTableAdapter.ClearBeforeFill = True
        '
        'BeraterTableAdapter
        '
        Me.BeraterTableAdapter.ClearBeforeFill = True
        '
        'frmZeiten
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 380)
        Me.Name = "frmZeiten"
        Me.Text = "Zeiterfassung"
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeraterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HeckTickDataSet As HeckTick.HeckTickDataSet
    Friend WithEvents ZeitenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZeitenTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
    Friend WithEvents ProjekteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProjekteTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
    Friend WithEvents BeraterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BeraterTableAdapter As HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
End Class
