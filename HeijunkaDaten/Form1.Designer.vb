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
        Me.Tbl_LinieDataGridView = New System.Windows.Forms.DataGridView()
        Me.Tbl_LinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProdKontrolleDataSet = New HeijunkaDaten.ProdKontrolleDataSet()
        Me.txt_Filter = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.btn_bearbeiten = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.btn_new = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_bearbeitung = New System.Windows.Forms.Label()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.lbl_Count = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tbl_LinieTableAdapter = New HeijunkaDaten.ProdKontrolleDataSetTableAdapters.tbl_LinieTableAdapter()
        Me.TableAdapterManager = New HeijunkaDaten.ProdKontrolleDataSetTableAdapters.TableAdapterManager()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Produktion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SMT = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VCheckKontrolle = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.Tbl_LinieDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tbl_LinieDataGridView
        '
        Me.Tbl_LinieDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_LinieDataGridView.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tbl_LinieDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Tbl_LinieDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_LinieDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Produktion, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewCheckBoxColumn3, Me.SMT, Me.VCheckKontrolle})
        Me.Tbl_LinieDataGridView.DataSource = Me.Tbl_LinieBindingSource
        Me.Tbl_LinieDataGridView.Location = New System.Drawing.Point(12, 95)
        Me.Tbl_LinieDataGridView.Name = "Tbl_LinieDataGridView"
        Me.Tbl_LinieDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Tbl_LinieDataGridView.Size = New System.Drawing.Size(1279, 390)
        Me.Tbl_LinieDataGridView.TabIndex = 1
        '
        'Tbl_LinieBindingSource
        '
        Me.Tbl_LinieBindingSource.DataMember = "tbl_Linie"
        Me.Tbl_LinieBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'ProdKontrolleDataSet
        '
        Me.ProdKontrolleDataSet.DataSetName = "ProdKontrolleDataSet"
        Me.ProdKontrolleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txt_Filter
        '
        Me.txt_Filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_Filter.Location = New System.Drawing.Point(6, 45)
        Me.txt_Filter.Name = "txt_Filter"
        Me.txt_Filter.Size = New System.Drawing.Size(198, 20)
        Me.txt_Filter.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txt_Filter)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 83)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filter"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Text suche:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_Close)
        Me.GroupBox2.Controls.Add(Me.btn_bearbeiten)
        Me.GroupBox2.Controls.Add(Me.btn_Save)
        Me.GroupBox2.Controls.Add(Me.btn_new)
        Me.GroupBox2.Controls.Add(Me.btn_delete)
        Me.GroupBox2.Location = New System.Drawing.Point(481, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(560, 83)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bearbeiten"
        '
        'btn_Close
        '
        Me.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Close.Image = Global.HeijunkaDaten.My.Resources.Resources.Beenden
        Me.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Close.Location = New System.Drawing.Point(446, 25)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(104, 40)
        Me.btn_Close.TabIndex = 8
        Me.btn_Close.Text = "Beenden"
        Me.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'btn_bearbeiten
        '
        Me.btn_bearbeiten.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_bearbeiten.Image = Global.HeijunkaDaten.My.Resources.Resources.DatenAktuall
        Me.btn_bearbeiten.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_bearbeiten.Location = New System.Drawing.Point(116, 25)
        Me.btn_bearbeiten.Name = "btn_bearbeiten"
        Me.btn_bearbeiten.Size = New System.Drawing.Size(104, 40)
        Me.btn_bearbeiten.TabIndex = 9
        Me.btn_bearbeiten.Text = "Bearbeiten"
        Me.btn_bearbeiten.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_bearbeiten.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.Enabled = False
        Me.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Save.Image = Global.HeijunkaDaten.My.Resources.Resources.speichern
        Me.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Save.Location = New System.Drawing.Point(336, 25)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(104, 40)
        Me.btn_Save.TabIndex = 4
        Me.btn_Save.Text = "Speichern"
        Me.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'btn_new
        '
        Me.btn_new.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_new.Image = Global.HeijunkaDaten.My.Resources.Resources.Neu
        Me.btn_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_new.Location = New System.Drawing.Point(6, 25)
        Me.btn_new.Name = "btn_new"
        Me.btn_new.Size = New System.Drawing.Size(104, 40)
        Me.btn_new.TabIndex = 6
        Me.btn_new.Text = "Neu"
        Me.btn_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_new.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Enabled = False
        Me.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_delete.Image = Global.HeijunkaDaten.My.Resources.Resources.löschen1
        Me.btn_delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_delete.Location = New System.Drawing.Point(226, 25)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(104, 40)
        Me.btn_delete.TabIndex = 7
        Me.btn_delete.Text = "Löschen"
        Me.btn_delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btn_delete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_bearbeitung)
        Me.GroupBox3.Controls.Add(Me.lbl_Version)
        Me.GroupBox3.Controls.Add(Me.lbl_Count)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(231, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(244, 83)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Informationen"
        '
        'lbl_bearbeitung
        '
        Me.lbl_bearbeitung.AutoSize = True
        Me.lbl_bearbeitung.Location = New System.Drawing.Point(6, 63)
        Me.lbl_bearbeitung.Name = "lbl_bearbeitung"
        Me.lbl_bearbeitung.Size = New System.Drawing.Size(67, 13)
        Me.lbl_bearbeitung.TabIndex = 7
        Me.lbl_bearbeitung.Text = "Bearbeitung:"
        '
        'lbl_Version
        '
        Me.lbl_Version.AutoSize = True
        Me.lbl_Version.Location = New System.Drawing.Point(6, 41)
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
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_LinieTableAdapter = Me.Tbl_LinieTableAdapter
        Me.TableAdapterManager.UpdateOrder = HeijunkaDaten.ProdKontrolleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'Produktion
        '
        Me.Produktion.DataPropertyName = "Produktion"
        Me.Produktion.HeaderText = "Produktion"
        Me.Produktion.Name = "Produktion"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Gruppe"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Segment"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ToolTipText = "Segment z.B. Actuator, CPPS, HVL usw.."
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "GruppeTeam"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Team"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ToolTipText = "erste Stufe unter dem Segment, z.B. GAP1, GAP2, Mix1 usw.."
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Linie"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Linie Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ToolTipText = "Name der Linie"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "AP"
        Me.DataGridViewTextBoxColumn4.HeaderText = "AP im APLA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ToolTipText = "Arbeitsplatz im AP nachdem das Heijunka erstellt wird. Muss eindeutig für die bet" &
    "roffene Linie sein!"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "station"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Station Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ToolTipText = "Stationsname aus WATS"
        Me.DataGridViewTextBoxColumn7.Width = 150
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "LineName"
        Me.DataGridViewTextBoxColumn8.HeaderText = "OEE Name"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ToolTipText = "OEE Name"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "StartTermin"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Starttermin?"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.ToolTipText = "Soll der Starttermin verwendet werden?"
        Me.DataGridViewCheckBoxColumn1.Width = 70
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "AnwStatus"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "AnwStatus"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Visible = False
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "WatsDatenVorhanden"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "WATS?"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.ToolTipText = "Speichert die Station daten im WATS?"
        Me.DataGridViewCheckBoxColumn3.Width = 70
        '
        'SMT
        '
        Me.SMT.DataPropertyName = "SMT"
        Me.SMT.HeaderText = "SMT?"
        Me.SMT.Name = "SMT"
        Me.SMT.ToolTipText = "Handelt es sich um eine SMT Linie?"
        Me.SMT.Width = 70
        '
        'VCheckKontrolle
        '
        Me.VCheckKontrolle.DataPropertyName = "VCheckKontrolle"
        Me.VCheckKontrolle.HeaderText = "VCheck?"
        Me.VCheckKontrolle.Name = "VCheckKontrolle"
        Me.VCheckKontrolle.ToolTipText = "Ist eine V-Check Kontrolle nötig?"
        Me.VCheckKontrolle.Width = 70
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 497)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Tbl_LinieDataGridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Heijunka Editor"
        CType(Me.Tbl_LinieDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProdKontrolleDataSet As ProdKontrolleDataSet
    Friend WithEvents Tbl_LinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents TableAdapterManager As ProdKontrolleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_LinieDataGridView As DataGridView
    Friend WithEvents txt_Filter As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Save As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btn_new As Button
    Friend WithEvents btn_delete As Button
    Friend WithEvents btn_Close As Button
    Friend WithEvents btn_bearbeiten As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_Count As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_Version As Label
    Friend WithEvents lbl_bearbeitung As Label
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Produktion As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As DataGridViewCheckBoxColumn
    Friend WithEvents SMT As DataGridViewCheckBoxColumn
    Friend WithEvents VCheckKontrolle As DataGridViewCheckBoxColumn
End Class
