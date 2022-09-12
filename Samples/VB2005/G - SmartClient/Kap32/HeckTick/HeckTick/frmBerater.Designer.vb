<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBerater
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
        Dim IDBeraterLabel As System.Windows.Forms.Label
        Dim NachnameLabel As System.Windows.Forms.Label
        Dim VornameLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBerater))
        Dim StraßeLabel As System.Windows.Forms.Label
        Dim OrtLabel As System.Windows.Forms.Label
        Dim PlzLabel As System.Windows.Forms.Label
        Me.HeckTickDataSet = New HeckTick.HeckTickDataSet
        Me.BeraterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BeraterTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
        Me.BeraterBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.BeraterBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.IDBeraterTextBox = New System.Windows.Forms.TextBox
        Me.NachnameTextBox = New System.Windows.Forms.TextBox
        Me.VornameTextBox = New System.Windows.Forms.TextBox
        Me.StraßeTextBox = New System.Windows.Forms.TextBox
        Me.OrtTextBox = New System.Windows.Forms.TextBox
        Me.PlzTextBox = New System.Windows.Forms.TextBox
        Me.ZeitenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ZeitenTableAdapter = New HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
        Me.ZeitenDataGridView = New System.Windows.Forms.DataGridView
        Me.IDProjekt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        IDBeraterLabel = New System.Windows.Forms.Label
        NachnameLabel = New System.Windows.Forms.Label
        VornameLabel = New System.Windows.Forms.Label
        StraßeLabel = New System.Windows.Forms.Label
        OrtLabel = New System.Windows.Forms.Label
        PlzLabel = New System.Windows.Forms.Label
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeraterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BeraterBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BeraterBindingNavigator.SuspendLayout()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZeitenDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IDBeraterLabel
        '
        IDBeraterLabel.AutoSize = True
        IDBeraterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        IDBeraterLabel.Location = New System.Drawing.Point(19, 64)
        IDBeraterLabel.Name = "IDBeraterLabel"
        IDBeraterLabel.Size = New System.Drawing.Size(44, 13)
        IDBeraterLabel.TabIndex = 0
        IDBeraterLabel.Text = "Berater:"
        '
        'NachnameLabel
        '
        NachnameLabel.AutoSize = True
        NachnameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NachnameLabel.Location = New System.Drawing.Point(19, 90)
        NachnameLabel.Name = "NachnameLabel"
        NachnameLabel.Size = New System.Drawing.Size(62, 13)
        NachnameLabel.TabIndex = 2
        NachnameLabel.Text = "Nachname:"
        '
        'VornameLabel
        '
        VornameLabel.AutoSize = True
        VornameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        VornameLabel.Location = New System.Drawing.Point(19, 116)
        VornameLabel.Name = "VornameLabel"
        VornameLabel.Size = New System.Drawing.Size(52, 13)
        VornameLabel.TabIndex = 4
        VornameLabel.Text = "Vorname:"
        '
        'HeckTickDataSet
        '
        Me.HeckTickDataSet.DataSetName = "HeckTickDataSet"
        Me.HeckTickDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BeraterBindingSource
        '
        Me.BeraterBindingSource.DataMember = "Berater"
        Me.BeraterBindingSource.DataSource = Me.HeckTickDataSet
        '
        'BeraterTableAdapter
        '
        Me.BeraterTableAdapter.ClearBeforeFill = True
        '
        'BeraterBindingNavigator
        '
        Me.BeraterBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.BeraterBindingNavigator.BindingSource = Me.BeraterBindingSource
        Me.BeraterBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.BeraterBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.BeraterBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.BeraterBindingNavigatorSaveItem, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.BeraterBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.BeraterBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BeraterBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BeraterBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BeraterBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BeraterBindingNavigator.Name = "BeraterBindingNavigator"
        Me.BeraterBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.BeraterBindingNavigator.Size = New System.Drawing.Size(590, 25)
        Me.BeraterBindingNavigator.TabIndex = 0
        Me.BeraterBindingNavigator.Text = "BindingNavigator1"
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
        'BeraterBindingNavigatorSaveItem
        '
        Me.BeraterBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BeraterBindingNavigatorSaveItem.Image = CType(resources.GetObject("BeraterBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.BeraterBindingNavigatorSaveItem.Name = "BeraterBindingNavigatorSaveItem"
        Me.BeraterBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.BeraterBindingNavigatorSaveItem.Text = "Daten speichern"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton1.Text = "Suchen"
        '
        'IDBeraterTextBox
        '
        Me.IDBeraterTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "IDBerater", True))
        Me.IDBeraterTextBox.Location = New System.Drawing.Point(113, 64)
        Me.IDBeraterTextBox.Name = "IDBeraterTextBox"
        Me.IDBeraterTextBox.Size = New System.Drawing.Size(146, 20)
        Me.IDBeraterTextBox.TabIndex = 1
        '
        'NachnameTextBox
        '
        Me.NachnameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "Nachname", True))
        Me.NachnameTextBox.Location = New System.Drawing.Point(113, 90)
        Me.NachnameTextBox.Name = "NachnameTextBox"
        Me.NachnameTextBox.Size = New System.Drawing.Size(146, 20)
        Me.NachnameTextBox.TabIndex = 3
        '
        'VornameTextBox
        '
        Me.VornameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "Vorname", True))
        Me.VornameTextBox.Location = New System.Drawing.Point(113, 116)
        Me.VornameTextBox.Name = "VornameTextBox"
        Me.VornameTextBox.Size = New System.Drawing.Size(146, 20)
        Me.VornameTextBox.TabIndex = 5
        '
        'StraßeLabel
        '
        StraßeLabel.AutoSize = True
        StraßeLabel.Location = New System.Drawing.Point(339, 64)
        StraßeLabel.Name = "StraßeLabel"
        StraßeLabel.Size = New System.Drawing.Size(41, 13)
        StraßeLabel.TabIndex = 6
        StraßeLabel.Text = "Straße:"
        '
        'StraßeTextBox
        '
        Me.StraßeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "Straße", True))
        Me.StraßeTextBox.Location = New System.Drawing.Point(417, 64)
        Me.StraßeTextBox.Name = "StraßeTextBox"
        Me.StraßeTextBox.Size = New System.Drawing.Size(146, 20)
        Me.StraßeTextBox.TabIndex = 7
        '
        'OrtLabel
        '
        OrtLabel.AutoSize = True
        OrtLabel.Location = New System.Drawing.Point(339, 93)
        OrtLabel.Name = "OrtLabel"
        OrtLabel.Size = New System.Drawing.Size(24, 13)
        OrtLabel.TabIndex = 8
        OrtLabel.Text = "Ort:"
        '
        'OrtTextBox
        '
        Me.OrtTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "Ort", True))
        Me.OrtTextBox.Location = New System.Drawing.Point(417, 90)
        Me.OrtTextBox.Name = "OrtTextBox"
        Me.OrtTextBox.Size = New System.Drawing.Size(146, 20)
        Me.OrtTextBox.TabIndex = 9
        '
        'PlzLabel
        '
        PlzLabel.AutoSize = True
        PlzLabel.Location = New System.Drawing.Point(339, 118)
        PlzLabel.Name = "PlzLabel"
        PlzLabel.Size = New System.Drawing.Size(24, 13)
        PlzLabel.TabIndex = 10
        PlzLabel.Text = "Plz:"
        '
        'PlzTextBox
        '
        Me.PlzTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BeraterBindingSource, "Plz", True))
        Me.PlzTextBox.Location = New System.Drawing.Point(417, 118)
        Me.PlzTextBox.Name = "PlzTextBox"
        Me.PlzTextBox.Size = New System.Drawing.Size(146, 20)
        Me.PlzTextBox.TabIndex = 11
        '
        'ZeitenBindingSource
        '
        Me.ZeitenBindingSource.DataMember = "FK_Zeiten_Berater"
        Me.ZeitenBindingSource.DataSource = Me.BeraterBindingSource
        '
        'ZeitenTableAdapter
        '
        Me.ZeitenTableAdapter.ClearBeforeFill = True
        '
        'ZeitenDataGridView
        '
        Me.ZeitenDataGridView.AutoGenerateColumns = False
        Me.ZeitenDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDProjekt, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.ZeitenDataGridView.DataSource = Me.ZeitenBindingSource
        Me.ZeitenDataGridView.Location = New System.Drawing.Point(22, 163)
        Me.ZeitenDataGridView.Name = "ZeitenDataGridView"
        Me.ZeitenDataGridView.Size = New System.Drawing.Size(541, 265)
        Me.ZeitenDataGridView.TabIndex = 12
        '
        'IDProjekt
        '
        Me.IDProjekt.DataPropertyName = "IDProjekt"
        Me.IDProjekt.HeaderText = "IDProjekt"
        Me.IDProjekt.Name = "IDProjekt"
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
        Me.DataGridViewTextBoxColumn6.Width = 300
        '
        'frmBerater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 447)
        Me.Controls.Add(Me.ZeitenDataGridView)
        Me.Controls.Add(PlzLabel)
        Me.Controls.Add(Me.PlzTextBox)
        Me.Controls.Add(OrtLabel)
        Me.Controls.Add(Me.OrtTextBox)
        Me.Controls.Add(StraßeLabel)
        Me.Controls.Add(Me.StraßeTextBox)
        Me.Controls.Add(IDBeraterLabel)
        Me.Controls.Add(Me.IDBeraterTextBox)
        Me.Controls.Add(NachnameLabel)
        Me.Controls.Add(Me.NachnameTextBox)
        Me.Controls.Add(VornameLabel)
        Me.Controls.Add(Me.VornameTextBox)
        Me.Controls.Add(Me.BeraterBindingNavigator)
        Me.Name = "frmBerater"
        Me.Text = "Berater"
        CType(Me.HeckTickDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeraterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BeraterBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BeraterBindingNavigator.ResumeLayout(False)
        Me.BeraterBindingNavigator.PerformLayout()
        CType(Me.ZeitenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZeitenDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HeckTickDataSet As HeckTick.HeckTickDataSet
    Friend WithEvents BeraterBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BeraterTableAdapter As HeckTick.HeckTickDataSetTableAdapters.BeraterTableAdapter
    Friend WithEvents BeraterBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents BeraterBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents IDBeraterTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NachnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VornameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StraßeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OrtTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PlzTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ZeitenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZeitenTableAdapter As HeckTick.HeckTickDataSetTableAdapters.ZeitenTableAdapter
    Friend WithEvents ZeitenDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents IDProjekt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
