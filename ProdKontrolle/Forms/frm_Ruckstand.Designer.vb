<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Ruckstand
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lbl_titel = New System.Windows.Forms.Label()
        Me.DGV_Ruck = New System.Windows.Forms.DataGridView()
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Tbl_ProdKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_ProdKontrolleTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auftrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ablieferort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DGV_Ruck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_titel
        '
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_titel.Location = New System.Drawing.Point(3, 5)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(89, 29)
        Me.lbl_titel.TabIndex = 1
        Me.lbl_titel.Text = "Label1"
        '
        'DGV_Ruck
        '
        Me.DGV_Ruck.AllowUserToAddRows = False
        Me.DGV_Ruck.AllowUserToDeleteRows = False
        Me.DGV_Ruck.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Ruck.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGV_Ruck.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Ruck.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Ruck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Ruck.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Auftrag, Me.Datum, Me.Stk, Me.Ablieferort, Me.Status, Me.Grund})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Ruck.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Ruck.EnableHeadersVisualStyles = False
        Me.DGV_Ruck.GridColor = System.Drawing.SystemColors.Control
        Me.DGV_Ruck.Location = New System.Drawing.Point(0, 60)
        Me.DGV_Ruck.MultiSelect = False
        Me.DGV_Ruck.Name = "DGV_Ruck"
        Me.DGV_Ruck.ReadOnly = True
        Me.DGV_Ruck.RowHeadersVisible = False
        Me.DGV_Ruck.RowTemplate.Height = 35
        Me.DGV_Ruck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_Ruck.Size = New System.Drawing.Size(1143, 489)
        Me.DGV_Ruck.TabIndex = 13
        '
        'DS_ProdKontrolle
        '
        Me.DS_ProdKontrolle.DataSetName = "DS_ProdKontrolle"
        Me.DS_ProdKontrolle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_ProdKontrolleBindingSource
        '
        Me.Tbl_ProdKontrolleBindingSource.DataMember = "tbl_ProdKontrolle"
        Me.Tbl_ProdKontrolleBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'Tbl_ProdKontrolleTableAdapter
        '
        Me.Tbl_ProdKontrolleTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_DashboardDatenTableAdapter = Nothing
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_KommentarTableAdapter = Nothing
        Me.TableAdapterManager.tbl_LinieTableAdapter = Nothing
        Me.TableAdapterManager.tbl_lp_checkTableAdapter = Nothing
        Me.TableAdapterManager.tbl_lp_ruestTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Me.Tbl_ProdKontrolleTableAdapter
        Me.TableAdapterManager.tbl_ProtkollTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_SMT_RuestungTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Material"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Material"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 230
        '
        'Auftrag
        '
        Me.Auftrag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Auftrag.HeaderText = "Auftrag"
        Me.Auftrag.Name = "Auftrag"
        Me.Auftrag.ReadOnly = True
        Me.Auftrag.Width = 107
        '
        'Datum
        '
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        Me.Datum.Width = 160
        '
        'Stk
        '
        Me.Stk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Stk.HeaderText = "Stk"
        Me.Stk.Name = "Stk"
        Me.Stk.ReadOnly = True
        Me.Stk.Width = 69
        '
        'Ablieferort
        '
        Me.Ablieferort.HeaderText = "Ablieferort"
        Me.Ablieferort.Name = "Ablieferort"
        Me.Ablieferort.ReadOnly = True
        Me.Ablieferort.Width = 120
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Grund
        '
        Me.Grund.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Grund.HeaderText = "Grund"
        Me.Grund.Name = "Grund"
        Me.Grund.ReadOnly = True
        '
        'frm_Ruckstand
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 549)
        Me.Controls.Add(Me.DGV_Ruck)
        Me.Controls.Add(Me.lbl_titel)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Ruckstand"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm_Ruckstand"
        CType(Me.DGV_Ruck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_titel As Label
    Public WithEvents DGV_Ruck As DataGridView
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents Tbl_ProdKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_ProdKontrolleTableAdapter As DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter
    Friend WithEvents TableAdapterManager As DS_ProdKontrolleTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_ProdKontrolleBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents Tbl_ProdKontrolleBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Auftrag As DataGridViewTextBoxColumn
    Friend WithEvents Datum As DataGridViewTextBoxColumn
    Friend WithEvents Stk As DataGridViewTextBoxColumn
    Friend WithEvents Ablieferort As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Grund As DataGridViewTextBoxColumn
End Class
