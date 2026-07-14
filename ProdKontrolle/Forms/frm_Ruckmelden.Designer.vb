<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Ruckmelden
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
        Me.lbl_FAUF = New System.Windows.Forms.Label()
        Me.lbl_ASN = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.FLP = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Tbl_Rueckmelden_StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_Rueckmelden_StatusTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_Rueckmelden_StatusTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_Rueckmelden_StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_FAUF
        '
        Me.lbl_FAUF.AutoSize = True
        Me.lbl_FAUF.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.75!)
        Me.lbl_FAUF.Location = New System.Drawing.Point(12, 39)
        Me.lbl_FAUF.Name = "lbl_FAUF"
        Me.lbl_FAUF.Size = New System.Drawing.Size(86, 29)
        Me.lbl_FAUF.TabIndex = 10
        Me.lbl_FAUF.Text = "Label1"
        '
        'lbl_ASN
        '
        Me.lbl_ASN.AutoSize = True
        Me.lbl_ASN.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.75!)
        Me.lbl_ASN.Location = New System.Drawing.Point(12, 10)
        Me.lbl_ASN.Name = "lbl_ASN"
        Me.lbl_ASN.Size = New System.Drawing.Size(89, 29)
        Me.lbl_ASN.TabIndex = 6
        Me.lbl_ASN.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox3)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(606, 39)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 170)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(6, 19)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(123, 133)
        Me.PictureBox3.TabIndex = 17
        Me.PictureBox3.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(200, 116)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 36)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(138, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(350, 80)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Label1"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(503, 19)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(136, 133)
        Me.PictureBox2.TabIndex = 12
        Me.PictureBox2.TabStop = False
        '
        'FLP
        '
        Me.FLP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FLP.AutoScroll = True
        Me.FLP.Location = New System.Drawing.Point(10, 76)
        Me.FLP.Name = "FLP"
        Me.FLP.Size = New System.Drawing.Size(552, 170)
        Me.FLP.TabIndex = 13
        '
        'btn_close
        '
        Me.btn_close.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_close.Location = New System.Drawing.Point(10, 252)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(552, 63)
        Me.btn_close.TabIndex = 15
        Me.btn_close.Text = "Schliessen"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'DS_ProdKontrolle
        '
        Me.DS_ProdKontrolle.DataSetName = "DS_ProdKontrolle"
        Me.DS_ProdKontrolle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_Rueckmelden_StatusBindingSource
        '
        Me.Tbl_Rueckmelden_StatusBindingSource.DataMember = "tbl_Rueckmelden_Status"
        Me.Tbl_Rueckmelden_StatusBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'Tbl_Rueckmelden_StatusTableAdapter
        '
        Me.Tbl_Rueckmelden_StatusTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_ausschussTableAdapter = Nothing
        Me.TableAdapterManager.tbl_DashboardDatenTableAdapter = Nothing
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_KommentarTableAdapter = Nothing
        Me.TableAdapterManager.tbl_LinieTableAdapter = Nothing
        Me.TableAdapterManager.tbl_lp_checkTableAdapter = Nothing
        Me.TableAdapterManager.tbl_lp_ruestTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProtkollTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Me.Tbl_Rueckmelden_StatusTableAdapter
        Me.TableAdapterManager.tbl_SMT_RuestungTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'frm_Ruckmelden
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 327)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.FLP)
        Me.Controls.Add(Me.lbl_FAUF)
        Me.Controls.Add(Me.lbl_ASN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Ruckmelden"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SAP Rückmeldecodes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_Rueckmelden_StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_FAUF As Label
    Friend WithEvents lbl_ASN As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents FLP As FlowLayoutPanel
    Friend WithEvents btn_close As Button
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents Tbl_Rueckmelden_StatusBindingSource As BindingSource
    Friend WithEvents Tbl_Rueckmelden_StatusTableAdapter As DS_ProdKontrolleTableAdapters.tbl_Rueckmelden_StatusTableAdapter
    Friend WithEvents TableAdapterManager As DS_ProdKontrolleTableAdapters.TableAdapterManager
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Button3 As Button
End Class
