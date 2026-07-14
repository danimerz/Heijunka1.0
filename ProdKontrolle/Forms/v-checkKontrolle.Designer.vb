<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class v_checkKontrolle
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Tbl_vcheckKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vcheckKontrolleTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_vcheckKontrolleTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.txt_scannerinput = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.lbl_beschrib = New System.Windows.Forms.Label()
        Me.lbl_Soll = New System.Windows.Forms.Label()
        Me.lbl_OperationPass = New System.Windows.Forms.Label()
        Me.lbl_offen = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lbl_trash = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Result = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_oFPY = New System.Windows.Forms.Label()
        Me.DS_vCheck = New ProdKontrolle.DS_vCheck()
        Me.HJ_GetOperationInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HJ_GetOperationInfoTableAdapter = New ProdKontrolle.DS_vCheckTableAdapters.HJ_GetOperationInfoTableAdapter()
        Me.TableAdapterManager1 = New ProdKontrolle.DS_vCheckTableAdapters.TableAdapterManager()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_vCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HJ_GetOperationInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'DS_ProdKontrolle
        '
        Me.DS_ProdKontrolle.DataSetName = "DS_ProdKontrolle"
        Me.DS_ProdKontrolle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_vcheckKontrolleBindingSource
        '
        Me.Tbl_vcheckKontrolleBindingSource.DataMember = "tbl_vcheckKontrolle"
        Me.Tbl_vcheckKontrolleBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'Tbl_vcheckKontrolleTableAdapter
        '
        Me.Tbl_vcheckKontrolleTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_KommentarTableAdapter = Nothing
        Me.TableAdapterManager.tbl_LinieTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProtkollTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_SMT_RuestungTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Me.Tbl_vcheckKontrolleTableAdapter
        Me.TableAdapterManager.UpdateOrder = ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'lbl_info
        '
        Me.lbl_info.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_info.Location = New System.Drawing.Point(0, 225)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(543, 24)
        Me.lbl_info.TabIndex = 1
        Me.lbl_info.Text = "Label1"
        '
        'txt_scannerinput
        '
        Me.txt_scannerinput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_scannerinput.Location = New System.Drawing.Point(11, 122)
        Me.txt_scannerinput.Name = "txt_scannerinput"
        Me.txt_scannerinput.Size = New System.Drawing.Size(261, 26)
        Me.txt_scannerinput.TabIndex = 2
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Location = New System.Drawing.Point(11, 154)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(261, 28)
        Me.btn_ok.TabIndex = 3
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'lbl_beschrib
        '
        Me.lbl_beschrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_beschrib.Location = New System.Drawing.Point(11, 74)
        Me.lbl_beschrib.Name = "lbl_beschrib"
        Me.lbl_beschrib.Size = New System.Drawing.Size(261, 43)
        Me.lbl_beschrib.TabIndex = 4
        Me.lbl_beschrib.Text = "Scannen Sie Ihren persöndlichen QR-Code ein:"
        '
        'lbl_Soll
        '
        Me.lbl_Soll.AutoSize = True
        Me.lbl_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Soll.Location = New System.Drawing.Point(61, 29)
        Me.lbl_Soll.Name = "lbl_Soll"
        Me.lbl_Soll.Size = New System.Drawing.Size(39, 20)
        Me.lbl_Soll.TabIndex = 5
        Me.lbl_Soll.Text = "Soll:"
        '
        'lbl_OperationPass
        '
        Me.lbl_OperationPass.AutoSize = True
        Me.lbl_OperationPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_OperationPass.Location = New System.Drawing.Point(61, 51)
        Me.lbl_OperationPass.Name = "lbl_OperationPass"
        Me.lbl_OperationPass.Size = New System.Drawing.Size(48, 20)
        Me.lbl_OperationPass.TabIndex = 6
        Me.lbl_OperationPass.Text = "Pass:"
        '
        'lbl_offen
        '
        Me.lbl_offen.AutoSize = True
        Me.lbl_offen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_offen.Location = New System.Drawing.Point(62, 73)
        Me.lbl_offen.Name = "lbl_offen"
        Me.lbl_offen.Size = New System.Drawing.Size(46, 20)
        Me.lbl_offen.TabIndex = 7
        Me.lbl_offen.Text = "offen"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.Controls.Add(Me.lbl_trash)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbl_Result)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_oFPY)
        Me.GroupBox1.Controls.Add(Me.lbl_offen)
        Me.GroupBox1.Controls.Add(Me.lbl_OperationPass)
        Me.GroupBox1.Controls.Add(Me.lbl_Soll)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(304, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 218)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "v-Check Daten"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox2.Location = New System.Drawing.Point(12, 17)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(207, 169)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 14
        Me.PictureBox2.TabStop = False
        '
        'lbl_trash
        '
        Me.lbl_trash.AutoSize = True
        Me.lbl_trash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_trash.Location = New System.Drawing.Point(61, 94)
        Me.lbl_trash.Name = "lbl_trash"
        Me.lbl_trash.Size = New System.Drawing.Size(49, 20)
        Me.lbl_trash.TabIndex = 15
        Me.lbl_trash.Text = "Trash"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Trash:"
        '
        'lbl_Result
        '
        Me.lbl_Result.Location = New System.Drawing.Point(6, 140)
        Me.lbl_Result.Name = "lbl_Result"
        Me.lbl_Result.Size = New System.Drawing.Size(213, 37)
        Me.lbl_Result.TabIndex = 13
        Me.lbl_Result.Text = "Resultat: "
        Me.lbl_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "FPY: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Offen:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Pass:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Soll:"
        '
        'lbl_oFPY
        '
        Me.lbl_oFPY.AutoSize = True
        Me.lbl_oFPY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_oFPY.Location = New System.Drawing.Point(62, 116)
        Me.lbl_oFPY.Name = "lbl_oFPY"
        Me.lbl_oFPY.Size = New System.Drawing.Size(48, 20)
        Me.lbl_oFPY.TabIndex = 8
        Me.lbl_oFPY.Text = "FPY: "
        '
        'DS_vCheck
        '
        Me.DS_vCheck.DataSetName = "DS_vCheck"
        Me.DS_vCheck.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HJ_GetOperationInfoBindingSource
        '
        Me.HJ_GetOperationInfoBindingSource.DataMember = "HJ_GetOperationInfo"
        Me.HJ_GetOperationInfoBindingSource.DataSource = Me.DS_vCheck
        '
        'HJ_GetOperationInfoTableAdapter
        '
        Me.HJ_GetOperationInfoTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Connection = Nothing
        Me.TableAdapterManager1.UpdateOrder = ProdKontrolle.DS_vCheckTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox1.Location = New System.Drawing.Point(6, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(285, 195)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_beschrib)
        Me.GroupBox2.Controls.Add(Me.btn_ok)
        Me.GroupBox2.Controls.Add(Me.txt_scannerinput)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(297, 218)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kamera"
        '
        'v_checkKontrolle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(543, 249)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "v_checkKontrolle"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "v_check Kontrolle"
        Me.TopMost = True
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_vCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HJ_GetOperationInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents Tbl_vcheckKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleTableAdapter As DS_ProdKontrolleTableAdapters.tbl_vcheckKontrolleTableAdapter
    Friend WithEvents TableAdapterManager As DS_ProdKontrolleTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_vcheckKontrolleBindingNavigator As BindingNavigator
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
    Friend WithEvents Tbl_vcheckKontrolleBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents lbl_info As Label
    Friend WithEvents txt_scannerinput As TextBox
    Friend WithEvents btn_ok As Button
    Friend WithEvents lbl_beschrib As Label
    Friend WithEvents lbl_Soll As Label
    Friend WithEvents lbl_OperationPass As Label
    Friend WithEvents lbl_offen As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DS_vCheck As DS_vCheck
    Friend WithEvents HJ_GetOperationInfoBindingSource As BindingSource
    Friend WithEvents HJ_GetOperationInfoTableAdapter As DS_vCheckTableAdapters.HJ_GetOperationInfoTableAdapter
    Friend WithEvents TableAdapterManager1 As DS_vCheckTableAdapters.TableAdapterManager
    Friend WithEvents lbl_oFPY As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_Result As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbl_trash As Label
    Friend WithEvents Label5 As Label
End Class
