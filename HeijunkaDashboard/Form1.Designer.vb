<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.SAP = New HeijunkaDashboard.SAP()
        Me.DT_SQ00_Import_FAUFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgv_FAUF0 = New System.Windows.Forms.DataGridView()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auftrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgv_FAUF1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.flp_heijunka = New System.Windows.Forms.FlowLayoutPanel()
        Me.DS_SQL = New HeijunkaDashboard.DS_SQL()
        Me.Tbl_LinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_LinieTableAdapter = New HeijunkaDashboard.DS_SQLTableAdapters.tbl_LinieTableAdapter()
        Me.TableAdapterManager = New HeijunkaDashboard.DS_SQLTableAdapters.TableAdapterManager()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_SQ00_Import_FAUFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_FAUF0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_FAUF1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_SQL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(12, 793)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Status.TabIndex = 0
        Me.lbl_Status.Text = "Label1"
        '
        'SAP
        '
        Me.SAP.DataSetName = "SAP"
        Me.SAP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DT_SQ00_Import_FAUFBindingSource
        '
        Me.DT_SQ00_Import_FAUFBindingSource.DataMember = "DT_SQ00_Import_FAUF"
        Me.DT_SQ00_Import_FAUFBindingSource.DataSource = Me.SAP
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Import SAP Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(31, 343)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgv_FAUF0
        '
        Me.dgv_FAUF0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FAUF0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material, Me.Auftrag, Me.Soll, Me.Ist})
        Me.dgv_FAUF0.Location = New System.Drawing.Point(31, 372)
        Me.dgv_FAUF0.Name = "dgv_FAUF0"
        Me.dgv_FAUF0.Size = New System.Drawing.Size(463, 266)
        Me.dgv_FAUF0.TabIndex = 4
        '
        'Material
        '
        Me.Material.HeaderText = "Material"
        Me.Material.Name = "Material"
        '
        'Auftrag
        '
        Me.Auftrag.HeaderText = "Auftrag"
        Me.Auftrag.Name = "Auftrag"
        '
        'Soll
        '
        Me.Soll.HeaderText = "Soll"
        Me.Soll.Name = "Soll"
        '
        'Ist
        '
        Me.Ist.HeaderText = "Ist"
        Me.Ist.Name = "Ist"
        '
        'dgv_FAUF1
        '
        Me.dgv_FAUF1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FAUF1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.dgv_FAUF1.Location = New System.Drawing.Point(534, 372)
        Me.dgv_FAUF1.Name = "dgv_FAUF1"
        Me.dgv_FAUF1.Size = New System.Drawing.Size(463, 266)
        Me.dgv_FAUF1.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Material"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Auftrag"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Soll"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ist"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(534, 343)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(133, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(117, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Start Parallel For"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'flp_heijunka
        '
        Me.flp_heijunka.Location = New System.Drawing.Point(15, 57)
        Me.flp_heijunka.Name = "flp_heijunka"
        Me.flp_heijunka.Size = New System.Drawing.Size(1159, 280)
        Me.flp_heijunka.TabIndex = 8
        '
        'DS_SQL
        '
        Me.DS_SQL.DataSetName = "DS_SQL"
        Me.DS_SQL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_LinieBindingSource
        '
        Me.Tbl_LinieBindingSource.DataMember = "tbl_Linie"
        Me.Tbl_LinieBindingSource.DataSource = Me.DS_SQL
        '
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_LinieTableAdapter = Me.Tbl_LinieTableAdapter
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = HeijunkaDashboard.DS_SQLTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.Tbl_LinieBindingSource
        Me.ComboBox1.DisplayMember = "Gruppe"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(276, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(299, 21)
        Me.ComboBox1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 893)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.flp_heijunka)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dgv_FAUF1)
        Me.Controls.Add(Me.dgv_FAUF0)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl_Status)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_SQ00_Import_FAUFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_FAUF0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_FAUF1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_SQL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_LinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SAP As SAP
    Friend WithEvents DT_SQ00_Import_FAUFBindingSource As BindingSource
    Friend WithEvents lbl_Status As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgv_FAUF0 As DataGridView
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Auftrag As DataGridViewTextBoxColumn
    Friend WithEvents Soll As DataGridViewTextBoxColumn
    Friend WithEvents Ist As DataGridViewTextBoxColumn
    Friend WithEvents dgv_FAUF1 As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents flp_heijunka As FlowLayoutPanel
    Friend WithEvents DS_SQL As DS_SQL
    Friend WithEvents Tbl_LinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As DS_SQLTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents TableAdapterManager As DS_SQLTableAdapters.TableAdapterManager
    Friend WithEvents ComboBox1 As ComboBox
End Class
