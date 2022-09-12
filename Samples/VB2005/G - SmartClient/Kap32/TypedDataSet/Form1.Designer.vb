<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim IDProjekteLabel As System.Windows.Forms.Label
        Dim ProjektnameLabel As System.Windows.Forms.Label
        Dim ProjektbeschreibungLabel As System.Windows.Forms.Label
        Me.btnTest = New System.Windows.Forms.Button
        Me.btnTest2 = New System.Windows.Forms.Button
        Me.HecktickDataSet = New TypedDataSet.HecktickDataSet
        Me.ProjekteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProjekteTableAdapter = New TypedDataSet.HecktickDataSetTableAdapters.ProjekteTableAdapter
        Me.ProjekteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.ProjekteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.IDProjekteLabel1 = New System.Windows.Forms.Label
        Me.ProjektnameLabel1 = New System.Windows.Forms.Label
        Me.ProjektbeschreibungLabel1 = New System.Windows.Forms.Label
        Me.ZeitenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZeitenTableAdapter = New TypedDataSet.HecktickDataSetTableAdapters.ZeitenTableAdapter
        Me.ZeitenDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        IDProjekteLabel = New System.Windows.Forms.Label
        ProjektnameLabel = New System.Windows.Forms.Label
        ProjektbeschreibungLabel = New System.Windows.Forms.Label
        CType(Me.HecktickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProjekteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProjekteBindingNavigator.SuspendLayout()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZeitenDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTest
        '
        Me.btnTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest.Location = New System.Drawing.Point(385, 40)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(101, 32)
        Me.btnTest.TabIndex = 0
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'btnTest2
        '
        Me.btnTest2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTest2.Location = New System.Drawing.Point(385, 78)
        Me.btnTest2.Name = "btnTest2"
        Me.btnTest2.Size = New System.Drawing.Size(101, 32)
        Me.btnTest2.TabIndex = 1
        Me.btnTest2.Text = "Test2"
        Me.btnTest2.UseVisualStyleBackColor = True
        '
        'HecktickDataSet
        '
        Me.HecktickDataSet.DataSetName = "HecktickDataSet"
        Me.HecktickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProjekteBindingSource
        '
        Me.ProjekteBindingSource.DataMember = "Projekte"
        Me.ProjekteBindingSource.DataSource = Me.HecktickDataSet
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
        Me.ProjekteBindingNavigator.Size = New System.Drawing.Size(506, 25)
        Me.ProjekteBindingNavigator.TabIndex = 2
        Me.ProjekteBindingNavigator.Text = "BindingNavigator1"
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(44, 22)
        Me.BindingNavigatorCountItem.Text = "von {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Die Gesamtanzahl der Elemente."
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
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
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Löschen"
        '
        'ProjekteBindingNavigatorSaveItem
        '
        Me.ProjekteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ProjekteBindingNavigatorSaveItem.Image = CType(resources.GetObject("ProjekteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.ProjekteBindingNavigatorSaveItem.Name = "ProjekteBindingNavigatorSaveItem"
        Me.ProjekteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.ProjekteBindingNavigatorSaveItem.Text = "Daten speichern"
        '
        'IDProjekteLabel
        '
        IDProjekteLabel.AutoSize = True
        IDProjekteLabel.Location = New System.Drawing.Point(12, 40)
        IDProjekteLabel.Name = "IDProjekteLabel"
        IDProjekteLabel.Size = New System.Drawing.Size(60, 13)
        IDProjekteLabel.TabIndex = 3
        IDProjekteLabel.Text = "IDProjekte:"
        '
        'IDProjekteLabel1
        '
        Me.IDProjekteLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProjekteBindingSource, "IDProjekte", True))
        Me.IDProjekteLabel1.Location = New System.Drawing.Point(125, 40)
        Me.IDProjekteLabel1.Name = "IDProjekteLabel1"
        Me.IDProjekteLabel1.Size = New System.Drawing.Size(233, 23)
        Me.IDProjekteLabel1.TabIndex = 4
        '
        'ProjektnameLabel
        '
        ProjektnameLabel.AutoSize = True
        ProjektnameLabel.Location = New System.Drawing.Point(12, 63)
        ProjektnameLabel.Name = "ProjektnameLabel"
        ProjektnameLabel.Size = New System.Drawing.Size(69, 13)
        ProjektnameLabel.TabIndex = 5
        ProjektnameLabel.Text = "Projektname:"
        '
        'ProjektnameLabel1
        '
        Me.ProjektnameLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProjekteBindingSource, "Projektname", True))
        Me.ProjektnameLabel1.Location = New System.Drawing.Point(125, 63)
        Me.ProjektnameLabel1.Name = "ProjektnameLabel1"
        Me.ProjektnameLabel1.Size = New System.Drawing.Size(233, 22)
        Me.ProjektnameLabel1.TabIndex = 6
        '
        'ProjektbeschreibungLabel
        '
        ProjektbeschreibungLabel.AutoSize = True
        ProjektbeschreibungLabel.Location = New System.Drawing.Point(12, 97)
        ProjektbeschreibungLabel.Name = "ProjektbeschreibungLabel"
        ProjektbeschreibungLabel.Size = New System.Drawing.Size(107, 13)
        ProjektbeschreibungLabel.TabIndex = 7
        ProjektbeschreibungLabel.Text = "Projektbeschreibung:"
        '
        'ProjektbeschreibungLabel1
        '
        Me.ProjektbeschreibungLabel1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ProjekteBindingSource, "Projektbeschreibung", True))
        Me.ProjektbeschreibungLabel1.Location = New System.Drawing.Point(125, 97)
        Me.ProjektbeschreibungLabel1.Name = "ProjektbeschreibungLabel1"
        Me.ProjektbeschreibungLabel1.Size = New System.Drawing.Size(233, 34)
        Me.ProjektbeschreibungLabel1.TabIndex = 8
        '
        'ZeitenBindingSource
        '
        Me.ZeitenBindingSource.DataMember = "FK_Zeiten_Projekte"
        Me.ZeitenBindingSource.DataSource = Me.ProjekteBindingSource
        '
        'ZeitenTableAdapter
        '
        Me.ZeitenTableAdapter.ClearBeforeFill = True
        '
        'ZeitenDataGridView
        '
        Me.ZeitenDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ZeitenDataGridView.AutoGenerateColumns = False
        Me.ZeitenDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.ZeitenDataGridView.DataSource = Me.ZeitenBindingSource
        Me.ZeitenDataGridView.Location = New System.Drawing.Point(12, 134)
        Me.ZeitenDataGridView.Name = "ZeitenDataGridView"
        Me.ZeitenDataGridView.Size = New System.Drawing.Size(474, 273)
        Me.ZeitenDataGridView.TabIndex = 9
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "IDZeiten"
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDZeiten"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IDProjekt"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IDProjekt"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "IDBerater"
        Me.DataGridViewTextBoxColumn3.HeaderText = "IDBerater"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Startzeit"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Startzeit"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Endzeit"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Endzeit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ArbBeschreibung"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ArbBeschreibung"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 438)
        Me.Controls.Add(Me.ZeitenDataGridView)
        Me.Controls.Add(ProjektbeschreibungLabel)
        Me.Controls.Add(Me.ProjektbeschreibungLabel1)
        Me.Controls.Add(ProjektnameLabel)
        Me.Controls.Add(Me.ProjektnameLabel1)
        Me.Controls.Add(IDProjekteLabel)
        Me.Controls.Add(Me.IDProjekteLabel1)
        Me.Controls.Add(Me.ProjekteBindingNavigator)
        Me.Controls.Add(Me.btnTest2)
        Me.Controls.Add(Me.btnTest)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.HecktickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProjekteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProjekteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProjekteBindingNavigator.ResumeLayout(False)
        Me.ProjekteBindingNavigator.PerformLayout()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZeitenDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents btnTest2 As System.Windows.Forms.Button
    Friend WithEvents HecktickDataSet As TypedDataSet.HecktickDataSet
    Friend WithEvents ProjekteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProjekteTableAdapter As TypedDataSet.HecktickDataSetTableAdapters.ProjekteTableAdapter
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
    Friend WithEvents IDProjekteLabel1 As System.Windows.Forms.Label
    Friend WithEvents ProjektnameLabel1 As System.Windows.Forms.Label
    Friend WithEvents ProjektbeschreibungLabel1 As System.Windows.Forms.Label
    Friend WithEvents ZeitenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZeitenTableAdapter As TypedDataSet.HecktickDataSetTableAdapters.ZeitenTableAdapter
    Friend WithEvents ZeitenDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
