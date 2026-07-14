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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ProdKontrolleDataSet = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSet()
        Me.Tbl_vcheckKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vcheckKontrolleTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTableAdapter()
        Me.TableAdapterManager = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.TableAdapterManager()
        Me.dgv_data = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lb_Linie = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtp_DatumBis = New System.Windows.Forms.DateTimePicker()
        Me.dtp_DatumVon = New System.Windows.Forms.DateTimePicker()
        Me.Tbl_LinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_LinieTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_LinieTableAdapter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_clearFilter = New System.Windows.Forms.Button()
        Me.btn_bearbeiten = New System.Windows.Forms.Button()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProdKontrolleDataSet
        '
        Me.ProdKontrolleDataSet.DataSetName = "ProdKontrolleDataSet"
        Me.ProdKontrolleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_vcheckKontrolleBindingSource
        '
        Me.Tbl_vcheckKontrolleBindingSource.DataMember = "tbl_vcheckKontrolle"
        Me.Tbl_vcheckKontrolleBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'Tbl_vcheckKontrolleTableAdapter
        '
        Me.Tbl_vcheckKontrolleTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_LinieTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Me.Tbl_vcheckKontrolleTableAdapter
        Me.TableAdapterManager.UpdateOrder = v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'dgv_data
        '
        Me.dgv_data.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.dgv_data.DataSource = Me.Tbl_vcheckKontrolleBindingSource
        Me.dgv_data.Location = New System.Drawing.Point(9, 137)
        Me.dgv_data.Name = "dgv_data"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_data.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_data.Size = New System.Drawing.Size(977, 425)
        Me.dgv_data.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Linie"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Linie"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Team"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Team"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Materialnummer"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Materialnummer"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Auftragsnummer"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Auftragsnummer"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Datum"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Datum"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Operator"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Operator"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 150
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_new)
        Me.GroupBox2.Controls.Add(Me.btn_Print)
        Me.GroupBox2.Controls.Add(Me.btn_close)
        Me.GroupBox2.Location = New System.Drawing.Point(603, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(383, 69)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Funktionen"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_Version)
        Me.GroupBox3.Controls.Add(Me.lbl_Count)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(603, 87)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(276, 44)
        Me.GroupBox3.TabIndex = 11
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_clearFilter)
        Me.GroupBox1.Controls.Add(Me.lb_Linie)
        Me.GroupBox1.Controls.Add(Me.btn_bearbeiten)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtp_DatumBis)
        Me.GroupBox1.Controls.Add(Me.dtp_DatumVon)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 119)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'lb_Linie
        '
        Me.lb_Linie.FormattingEnabled = True
        Me.lb_Linie.Location = New System.Drawing.Point(222, 15)
        Me.lb_Linie.Name = "lb_Linie"
        Me.lb_Linie.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lb_Linie.Size = New System.Drawing.Size(240, 95)
        Me.lb_Linie.TabIndex = 11
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
        Me.dtp_DatumBis.Size = New System.Drawing.Size(200, 20)
        Me.dtp_DatumBis.TabIndex = 2
        '
        'dtp_DatumVon
        '
        Me.dtp_DatumVon.Location = New System.Drawing.Point(5, 34)
        Me.dtp_DatumVon.Name = "dtp_DatumVon"
        Me.dtp_DatumVon.Size = New System.Drawing.Size(200, 20)
        Me.dtp_DatumVon.TabIndex = 1
        '
        'Tbl_LinieBindingSource
        '
        Me.Tbl_LinieBindingSource.DataSource = Me.ProdKontrolleDataSet
        Me.Tbl_LinieBindingSource.Position = 0
        '
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.v_CheckKontrolle_Auswertung.My.Resources.Resources.kisspng_siemens_organization_company_industry_manufacturin_5b06eafb2a6083_0585722515271800271736
        Me.PictureBox1.Location = New System.Drawing.Point(885, 91)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(101, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'btn_new
        '
        Me.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_new.Image = CType(resources.GetObject("btn_new.Image"), System.Drawing.Image)
        Me.btn_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_new.Location = New System.Drawing.Point(124, 18)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(109, 41)
        Me.btn_new.TabIndex = 7
        Me.btn_new.Text = "man. Eintrag"
        Me.btn_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_Print
        '
        Me.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Print.Image = Global.v_CheckKontrolle_Auswertung.My.Resources.Resources.drucker
        Me.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Print.Location = New System.Drawing.Point(9, 18)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(109, 41)
        Me.btn_Print.TabIndex = 6
        Me.btn_Print.Text = "Drucken"
        Me.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Image = Global.v_CheckKontrolle_Auswertung.My.Resources.Resources.Beenden
        Me.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_close.Location = New System.Drawing.Point(239, 18)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(109, 41)
        Me.btn_close.TabIndex = 5
        Me.btn_close.Text = "Beenden"
        Me.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_clearFilter
        '
        Me.btn_clearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_clearFilter.Image = Global.v_CheckKontrolle_Auswertung.My.Resources.Resources.RotX
        Me.btn_clearFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_clearFilter.Location = New System.Drawing.Point(468, 68)
        Me.btn_clearFilter.Name = "btn_clearFilter"
        Me.btn_clearFilter.Size = New System.Drawing.Size(111, 41)
        Me.btn_clearFilter.TabIndex = 12
        Me.btn_clearFilter.Text = "Filter löschen"
        Me.btn_clearFilter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_clearFilter.UseVisualStyleBackColor = True
        '
        'btn_bearbeiten
        '
        Me.btn_bearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bearbeiten.Image = Global.v_CheckKontrolle_Auswertung.My.Resources.Resources.GrunHacken
        Me.btn_bearbeiten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bearbeiten.Location = New System.Drawing.Point(468, 17)
        Me.btn_bearbeiten.Name = "btn_bearbeiten"
        Me.btn_bearbeiten.Size = New System.Drawing.Size(111, 41)
        Me.btn_bearbeiten.TabIndex = 3
        Me.btn_bearbeiten.Text = "Anwenden"
        Me.btn_bearbeiten.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_bearbeiten.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 574)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgv_data)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "V-Check Kontrolle auswerten"
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProdKontrolleDataSet As ProdKontrolleDataSet
    Friend WithEvents Tbl_vcheckKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTableAdapter
    Friend WithEvents TableAdapterManager As ProdKontrolleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents dgv_data As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_Print As Button
    Friend WithEvents btn_close As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_Version As Label
    Friend WithEvents lbl_Count As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_clearFilter As Button
    Friend WithEvents lb_Linie As ListBox
    Friend WithEvents btn_bearbeiten As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtp_DatumBis As DateTimePicker
    Friend WithEvents dtp_DatumVon As DateTimePicker
    Friend WithEvents Tbl_LinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents btn_new As Button
End Class
