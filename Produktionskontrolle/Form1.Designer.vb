<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.dgv_Data = New System.Windows.Forms.DataGridView()
        Me.TblProdKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProdKontrolleDataSet = New Produktionskontrolle.ProdKontrolleDataSet()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_clearFilter = New System.Windows.Forms.Button()
        Me.lb_Linie = New System.Windows.Forms.ListBox()
        Me.QryLinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btn_bearbeiten = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_DatumBis = New System.Windows.Forms.DateTimePicker()
        Me.dtp_DatumVon = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_export = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Tbl_ProdKontrolleTableAdapter = New Produktionskontrolle.ProdKontrolleDataSetTableAdapters.tbl_ProdKontrolleTableAdapter()
        Me.Qry_LinieTableAdapter = New Produktionskontrolle.ProdKontrolleDataSetTableAdapters.qry_LinieTableAdapter()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DatumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vrg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaterialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAUFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SollDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IstDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrundDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZusatzDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgv_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.QryLinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Data
        '
        Me.dgv_Data.AutoGenerateColumns = False
        Me.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.DatumDataGridViewTextBoxColumn, Me.LinieDataGridViewTextBoxColumn, Me.Vrg, Me.MaterialDataGridViewTextBoxColumn, Me.FAUFDataGridViewTextBoxColumn, Me.SollDataGridViewTextBoxColumn, Me.IstDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.GrundDataGridViewTextBoxColumn, Me.ZusatzDataGridViewTextBoxColumn})
        Me.dgv_Data.DataSource = Me.TblProdKontrolleBindingSource
        Me.dgv_Data.Location = New System.Drawing.Point(12, 145)
        Me.dgv_Data.Name = "dgv_Data"
        Me.dgv_Data.Size = New System.Drawing.Size(1178, 412)
        Me.dgv_Data.TabIndex = 0
        '
        'TblProdKontrolleBindingSource
        '
        Me.TblProdKontrolleBindingSource.DataMember = "tbl_ProdKontrolle"
        Me.TblProdKontrolleBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'ProdKontrolleDataSet
        '
        Me.ProdKontrolleDataSet.DataSetName = "ProdKontrolleDataSet"
        Me.ProdKontrolleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_clearFilter)
        Me.GroupBox1.Controls.Add(Me.lb_Linie)
        Me.GroupBox1.Controls.Add(Me.btn_bearbeiten)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtp_DatumBis)
        Me.GroupBox1.Controls.Add(Me.dtp_DatumVon)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(761, 119)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'btn_clearFilter
        '
        Me.btn_clearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clearFilter.Image = Global.Produktionskontrolle.My.Resources.Resources.RotX
        Me.btn_clearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clearFilter.Location = New System.Drawing.Point(609, 68)
        Me.btn_clearFilter.Name = "btn_clearFilter"
        Me.btn_clearFilter.Size = New System.Drawing.Size(146, 41)
        Me.btn_clearFilter.TabIndex = 12
        Me.btn_clearFilter.Text = "Filter löschen"
        Me.btn_clearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_clearFilter.UseVisualStyleBackColor = True
        '
        'lb_Linie
        '
        Me.lb_Linie.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.QryLinieBindingSource, "Linie", True))
        Me.lb_Linie.FormattingEnabled = True
        Me.lb_Linie.Location = New System.Drawing.Point(243, 17)
        Me.lb_Linie.Name = "lb_Linie"
        Me.lb_Linie.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_Linie.Size = New System.Drawing.Size(360, 95)
        Me.lb_Linie.TabIndex = 11
        '
        'QryLinieBindingSource
        '
        Me.QryLinieBindingSource.DataMember = "qry_Linie"
        Me.QryLinieBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'btn_bearbeiten
        '
        Me.btn_bearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bearbeiten.Image = Global.Produktionskontrolle.My.Resources.Resources.GrunHacken
        Me.btn_bearbeiten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bearbeiten.Location = New System.Drawing.Point(609, 17)
        Me.btn_bearbeiten.Name = "btn_bearbeiten"
        Me.btn_bearbeiten.Size = New System.Drawing.Size(146, 41)
        Me.btn_bearbeiten.TabIndex = 3
        Me.btn_bearbeiten.Text = "Anwenden"
        Me.btn_bearbeiten.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_bearbeiten.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Datum bis:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Datum von:"
        '
        'dtp_DatumBis
        '
        Me.dtp_DatumBis.Location = New System.Drawing.Point(7, 79)
        Me.dtp_DatumBis.Name = "dtp_DatumBis"
        Me.dtp_DatumBis.Size = New System.Drawing.Size(219, 20)
        Me.dtp_DatumBis.TabIndex = 2
        '
        'dtp_DatumVon
        '
        Me.dtp_DatumVon.Location = New System.Drawing.Point(5, 34)
        Me.dtp_DatumVon.Name = "dtp_DatumVon"
        Me.dtp_DatumVon.Size = New System.Drawing.Size(221, 20)
        Me.dtp_DatumVon.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_Version)
        Me.GroupBox3.Controls.Add(Me.lbl_Count)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(779, 89)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 44)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informationen"
        '
        'lbl_Version
        '
        Me.lbl_Version.AutoSize = True
        Me.lbl_Version.Location = New System.Drawing.Point(154, 21)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(45, 13)
        Me.lbl_Version.TabIndex = 6
        Me.lbl_Version.Text = "Version:"
        '
        'lbl_Count
        '
        Me.lbl_Count.AutoSize = True
        Me.lbl_Count.Location = New System.Drawing.Point(105, 21)
        Me.lbl_Count.Name = "lbl_Count"
        Me.lbl_Count.Size = New System.Drawing.Size(13, 13)
        Me.lbl_Count.TabIndex = 5
        Me.lbl_Count.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Anzahl Datensätze:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Print)
        Me.GroupBox2.Controls.Add(Me.btn_close)
        Me.GroupBox2.Controls.Add(Me.btn_export)
        Me.GroupBox2.Location = New System.Drawing.Point(779, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(411, 69)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funktionen"
        '
        'btn_Print
        '
        Me.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Print.Image = Global.Produktionskontrolle.My.Resources.Resources.drucker
        Me.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Print.Location = New System.Drawing.Point(144, 17)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(124, 41)
        Me.btn_Print.TabIndex = 6
        Me.btn_Print.Text = "Drucken"
        Me.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Image = Global.Produktionskontrolle.My.Resources.Resources.Beenden
        Me.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_close.Location = New System.Drawing.Point(274, 17)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(124, 41)
        Me.btn_close.TabIndex = 5
        Me.btn_close.Text = "Beenden"
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_export
        '
        Me.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_export.Image = Global.Produktionskontrolle.My.Resources.Resources.speichern
        Me.btn_export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_export.Location = New System.Drawing.Point(14, 17)
        Me.btn_export.Name = "btn_export"
        Me.btn_export.Size = New System.Drawing.Size(124, 41)
        Me.btn_export.TabIndex = 4
        Me.btn_export.Text = "Export zu XML"
        Me.btn_export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_export.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Produktionskontrolle.My.Resources.Resources.kisspng_siemens_organization_company_industry_manufacturin_5b06eafb2a6083_0585722515271800271736
        Me.PictureBox1.Location = New System.Drawing.Point(1074, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(116, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Tbl_ProdKontrolleTableAdapter
        '
        Me.Tbl_ProdKontrolleTableAdapter.ClearBeforeFill = True
        '
        'Qry_LinieTableAdapter
        '
        Me.Qry_LinieTableAdapter.ClearBeforeFill = True
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'DatumDataGridViewTextBoxColumn
        '
        Me.DatumDataGridViewTextBoxColumn.DataPropertyName = "Datum"
        Me.DatumDataGridViewTextBoxColumn.HeaderText = "Datum"
        Me.DatumDataGridViewTextBoxColumn.Name = "DatumDataGridViewTextBoxColumn"
        '
        'LinieDataGridViewTextBoxColumn
        '
        Me.LinieDataGridViewTextBoxColumn.DataPropertyName = "Linie"
        Me.LinieDataGridViewTextBoxColumn.HeaderText = "Linie"
        Me.LinieDataGridViewTextBoxColumn.Name = "LinieDataGridViewTextBoxColumn"
        Me.LinieDataGridViewTextBoxColumn.Width = 120
        '
        'Vrg
        '
        Me.Vrg.DataPropertyName = "Vrg"
        Me.Vrg.HeaderText = "Vorgang"
        Me.Vrg.Name = "Vrg"
        Me.Vrg.Width = 75
        '
        'MaterialDataGridViewTextBoxColumn
        '
        Me.MaterialDataGridViewTextBoxColumn.DataPropertyName = "Material"
        Me.MaterialDataGridViewTextBoxColumn.FillWeight = 120.0!
        Me.MaterialDataGridViewTextBoxColumn.HeaderText = "Material"
        Me.MaterialDataGridViewTextBoxColumn.Name = "MaterialDataGridViewTextBoxColumn"
        '
        'FAUFDataGridViewTextBoxColumn
        '
        Me.FAUFDataGridViewTextBoxColumn.DataPropertyName = "FAUF"
        Me.FAUFDataGridViewTextBoxColumn.HeaderText = "FAUF"
        Me.FAUFDataGridViewTextBoxColumn.Name = "FAUFDataGridViewTextBoxColumn"
        '
        'SollDataGridViewTextBoxColumn
        '
        Me.SollDataGridViewTextBoxColumn.DataPropertyName = "Soll"
        Me.SollDataGridViewTextBoxColumn.HeaderText = "Soll"
        Me.SollDataGridViewTextBoxColumn.Name = "SollDataGridViewTextBoxColumn"
        Me.SollDataGridViewTextBoxColumn.Width = 50
        '
        'IstDataGridViewTextBoxColumn
        '
        Me.IstDataGridViewTextBoxColumn.DataPropertyName = "Ist"
        Me.IstDataGridViewTextBoxColumn.HeaderText = "Ist"
        Me.IstDataGridViewTextBoxColumn.Name = "IstDataGridViewTextBoxColumn"
        Me.IstDataGridViewTextBoxColumn.Width = 50
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        '
        'GrundDataGridViewTextBoxColumn
        '
        Me.GrundDataGridViewTextBoxColumn.DataPropertyName = "Grund"
        Me.GrundDataGridViewTextBoxColumn.HeaderText = "Grund"
        Me.GrundDataGridViewTextBoxColumn.Name = "GrundDataGridViewTextBoxColumn"
        '
        'ZusatzDataGridViewTextBoxColumn
        '
        Me.ZusatzDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ZusatzDataGridViewTextBoxColumn.DataPropertyName = "Zusatz"
        Me.ZusatzDataGridViewTextBoxColumn.HeaderText = "Zusatz"
        Me.ZusatzDataGridViewTextBoxColumn.Name = "ZusatzDataGridViewTextBoxColumn"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1202, 580)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_Data)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Produktionskontrolle Auswerten"
        CType(Me.dgv_Data, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.QryLinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_Data As DataGridView
    Friend WithEvents ProdKontrolleDataSet As ProdKontrolleDataSet
    Friend WithEvents TblProdKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_ProdKontrolleTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_ProdKontrolleTableAdapter
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_Version As Label
    Friend WithEvents lbl_Count As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtp_DatumVon As DateTimePicker
    Friend WithEvents dtp_DatumBis As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_bearbeiten As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_export As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents QryLinieBindingSource As BindingSource
    Friend WithEvents Qry_LinieTableAdapter As ProdKontrolleDataSetTableAdapters.qry_LinieTableAdapter
    Friend WithEvents lb_Linie As ListBox
    Friend WithEvents btn_clearFilter As Button
    Friend WithEvents btn_Print As Button
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DatumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LinieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Vrg As DataGridViewTextBoxColumn
    Friend WithEvents MaterialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FAUFDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SollDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IstDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GrundDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ZusatzDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
