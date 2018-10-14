<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProjekte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProjekte))
        Me.HeckTickDataSet = New HeckTick.HeckTickDataSet
        Me.ProjekteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProjekteTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
        Me.ProjekteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ProjekteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ProjekteDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Startzeitpunkt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Endzeitpunkt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ausführungsort = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProjekteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProjekteBindingNavigator.SuspendLayout()
        CType(Me.ProjekteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HeckTickDataSet
        '
        Me.HeckTickDataSet.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'ProjekteBindingNavigator
        '
        Me.ProjekteBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.ProjekteBindingNavigator.BindingSource = Me.ProjekteBindingSource
        Me.ProjekteBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.ProjekteBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.ProjekteBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.ProjekteBindingNavigatorSaveItem})
        Me.ProjekteBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ProjekteBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.ProjekteBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.ProjekteBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.ProjekteBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.ProjekteBindingNavigator.Name = "ProjekteBindingNavigator"
        Me.ProjekteBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.ProjekteBindingNavigator.Size = New System.Drawing.Size(500, 25)
        Me.ProjekteBindingNavigator.TabIndex = 0
        Me.ProjekteBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Neu hinzufügen"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(44, 22)
        Me.BindingNavigatorCountItem.Text = "von {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente."
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Löschen"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Erste verschieben"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Vorherige verschieben"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Aktuelle Position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Nächste verschieben"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Letzte verschieben"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ProjekteBindingNavigatorSaveItem
        '
        Me.ProjekteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjekteBindingNavigatorSaveItem.Image = CType(resources.GetObject("ProjekteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ProjekteBindingNavigatorSaveItem.Name = "ProjekteBindingNavigatorSaveItem"
        Me.ProjekteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProjekteBindingNavigatorSaveItem.Text = "Daten speichern"
        '
        'ProjekteDataGridView
        '
        Me.ProjekteDataGridView.AllowUserToOrderColumns = True
        Me.ProjekteDataGridView.AutoGenerateColumns = False
        Me.ProjekteDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ProjekteDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.ProjekteDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ProjekteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ProjekteDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Startzeitpunkt, Me.Endzeitpunkt, Me.DataGridViewTextBoxColumn3, Me.Ausführungsort})
        Me.ProjekteDataGridView.DataSource = Me.ProjekteBindingSource
        Me.ProjekteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProjekteDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.ProjekteDataGridView.Name = "ProjekteDataGridView"
        Me.ProjekteDataGridView.Size = New System.Drawing.Size(500, 435)
        Me.ProjekteDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDProjekte"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Projekt ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 79
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Projektname"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Projektname"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 91
        '
        'Startzeitpunkt
        '
        Me.Startzeitpunkt.DataPropertyName = "Startzeitpunkt"
        Me.Startzeitpunkt.HeaderText = "Startzeitpunkt"
        Me.Startzeitpunkt.Name = "Startzeitpunkt"
        Me.Startzeitpunkt.Width = 97
        '
        'Endzeitpunkt
        '
        Me.Endzeitpunkt.DataPropertyName = "Endzeitpunkt"
        Me.Endzeitpunkt.HeaderText = "Endzeitpunkt"
        Me.Endzeitpunkt.Name = "Endzeitpunkt"
        Me.Endzeitpunkt.Width = 94
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Projektbeschreibung"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Projektbeschreibung"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 129
        '
        'Ausführungsort
        '
        Me.Ausführungsort.DataPropertyName = "Ausführungsort"
        Me.Ausführungsort.HeaderText = "Ausführungsort"
        Me.Ausführungsort.Name = "Ausführungsort"
        Me.Ausführungsort.Width = 103
        '
        'frmProjekte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 460)
        Me.Controls.Add(Me.ProjekteDataGridView)
        Me.Controls.Add(Me.ProjekteBindingNavigator)
        Me.Name = "frmProjekte"
        Me.Text = "Projekte"
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProjekteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProjekteBindingNavigator.ResumeLayout(False)
        Me.ProjekteBindingNavigator.PerformLayout()
        CType(Me.ProjekteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeckTickDataSet As HeckTick.HeckTickDataSet
    Friend WithEvents ProjekteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProjekteTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ProjekteTableAdapter
    Friend WithEvents ProjekteBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ProjekteBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProjekteDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Startzeitpunkt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Endzeitpunkt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ausführungsort As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
