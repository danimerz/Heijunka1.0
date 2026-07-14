<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ProdKontrolle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ProdKontrolle))
        Me.cb_grund = New System.Windows.Forms.ComboBox()
        Me.btn_Eintragen = New System.Windows.Forms.Button()
        Me.LB_stuli = New System.Windows.Forms.ListBox()
        Me.txt_Grund = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Tbl_ProdKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_ProdKontrolleTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cb_grund
        '
        Me.cb_grund.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cb_grund.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.cb_grund.FormattingEnabled = True
        Me.cb_grund.Items.AddRange(New Object() {"MA Kapazität", "Fehlmaterial", "Maschine", "Sonstiges"})
        Me.cb_grund.Location = New System.Drawing.Point(12, 58)
        Me.cb_grund.Name = "cb_grund"
        Me.cb_grund.Size = New System.Drawing.Size(591, 33)
        Me.cb_grund.TabIndex = 1
        '
        'btn_Eintragen
        '
        Me.btn_Eintragen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Eintragen.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!)
        Me.btn_Eintragen.Location = New System.Drawing.Point(12, 251)
        Me.btn_Eintragen.Name = "btn_Eintragen"
        Me.btn_Eintragen.Size = New System.Drawing.Size(591, 36)
        Me.btn_Eintragen.TabIndex = 2
        Me.btn_Eintragen.Text = "Eintragen"
        Me.btn_Eintragen.UseVisualStyleBackColor = True
        '
        'LB_stuli
        '
        Me.LB_stuli.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_stuli.FormattingEnabled = True
        Me.LB_stuli.ItemHeight = 25
        Me.LB_stuli.Location = New System.Drawing.Point(12, 97)
        Me.LB_stuli.Name = "LB_stuli"
        Me.LB_stuli.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.LB_stuli.Size = New System.Drawing.Size(591, 129)
        Me.LB_stuli.TabIndex = 3
        '
        'txt_Grund
        '
        Me.txt_Grund.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!)
        Me.txt_Grund.Location = New System.Drawing.Point(12, 98)
        Me.txt_Grund.Multiline = True
        Me.txt_Grund.Name = "txt_Grund"
        Me.txt_Grund.Size = New System.Drawing.Size(591, 147)
        Me.txt_Grund.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.Label1.Location = New System.Drawing.Point(7, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Produktionskontrolle"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "bitte Grund auswählen:"
        '
        'frm_ProdKontrolle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 296)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_Grund)
        Me.Controls.Add(Me.LB_stuli)
        Me.Controls.Add(Me.btn_Eintragen)
        Me.Controls.Add(Me.cb_grund)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_ProdKontrolle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cb_grund As ComboBox
    Friend WithEvents btn_Eintragen As Button
    Friend WithEvents LB_stuli As ListBox
    Friend WithEvents txt_Grund As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents Tbl_ProdKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_ProdKontrolleTableAdapter As DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter
    Friend WithEvents TableAdapterManager As DS_ProdKontrolleTableAdapters.TableAdapterManager
    Friend WithEvents Label2 As Label
End Class
