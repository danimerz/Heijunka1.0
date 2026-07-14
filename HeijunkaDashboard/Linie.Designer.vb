<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Linie
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.lbl_Titel = New System.Windows.Forms.Label()
        Me.SAP = New HeijunkaDashboard.SAP()
        Me.DT_SQ00_Import_FAUFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgv_FAUF = New System.Windows.Forms.DataGridView()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auftrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.DT_HeijunkaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DT_RSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager1 = New HeijunkaDashboard.DS_SQLTableAdapters.TableAdapterManager()
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_SQ00_Import_FAUFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_FAUF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_HeijunkaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DT_RSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Titel
        '
        Me.lbl_Titel.AutoSize = True
        Me.lbl_Titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Titel.Location = New System.Drawing.Point(3, 0)
        Me.lbl_Titel.Name = "lbl_Titel"
        Me.lbl_Titel.Size = New System.Drawing.Size(107, 20)
        Me.lbl_Titel.TabIndex = 0
        Me.lbl_Titel.Text = "Titel Blablabla"
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
        'dgv_FAUF
        '
        Me.dgv_FAUF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_FAUF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material, Me.Auftrag, Me.Soll, Me.Ist})
        Me.dgv_FAUF.Location = New System.Drawing.Point(7, 54)
        Me.dgv_FAUF.Name = "dgv_FAUF"
        Me.dgv_FAUF.Size = New System.Drawing.Size(589, 266)
        Me.dgv_FAUF.TabIndex = 1
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
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(177, 5)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Status.TabIndex = 2
        Me.lbl_Status.Text = "Label1"
        '
        'DT_HeijunkaBindingSource
        '
        Me.DT_HeijunkaBindingSource.DataMember = "DT_Heijunka"
        Me.DT_HeijunkaBindingSource.DataSource = Me.SAP
        '
        'DT_RSBindingSource
        '
        Me.DT_RSBindingSource.DataMember = "DT_RS"
        Me.DT_RSBindingSource.DataSource = Me.SAP
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Connection = Nothing
        Me.TableAdapterManager1.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager1.tbl_LinieTableAdapter = Nothing
        Me.TableAdapterManager1.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager1.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager1.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager1.UpdateOrder = HeijunkaDashboard.DS_SQLTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Linie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.dgv_FAUF)
        Me.Controls.Add(Me.lbl_Titel)
        Me.Name = "Linie"
        Me.Size = New System.Drawing.Size(741, 450)
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_SQ00_Import_FAUFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_FAUF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_HeijunkaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DT_RSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Titel As Label
    Friend WithEvents SAP As SAP
    Friend WithEvents DT_SQ00_Import_FAUFBindingSource As BindingSource
    Friend WithEvents dgv_FAUF As DataGridView
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Auftrag As DataGridViewTextBoxColumn
    Friend WithEvents Soll As DataGridViewTextBoxColumn
    Friend WithEvents Ist As DataGridViewTextBoxColumn
    Friend WithEvents lbl_Status As Label
    Friend WithEvents DT_HeijunkaBindingSource As BindingSource
    Friend WithEvents DT_RSBindingSource As BindingSource
    Friend WithEvents TableAdapterManager1 As DS_SQLTableAdapters.TableAdapterManager
End Class
