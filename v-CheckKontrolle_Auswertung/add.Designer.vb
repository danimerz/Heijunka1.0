<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add
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
        Me.ProdKontrolleDataSet = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSet()
        Me.Tbl_vcheckKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vcheckKontrolleTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTableAdapter()
        Me.TableAdapterManager = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.TableAdapterManager()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cb_Ma = New System.Windows.Forms.ComboBox()
        Me.TblvcheckKontrolleOperatorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vcheckKontrolleOperatorTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleOperatorTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cb_Linie = New System.Windows.Forms.ComboBox()
        Me.TblvcheckKontrolleLinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_Team = New System.Windows.Forms.ComboBox()
        Me.TblvcheckKontrolleTeamBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vcheckKontrolleLinieTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleLinieTableAdapter()
        Me.Tbl_vcheckKontrolleTeamTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTeamTableAdapter()
        Me.txt_MatNr = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_Fauf = New System.Windows.Forms.TextBox()
        Me.dtp_Datum = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btn_v_Check = New System.Windows.Forms.Button()
        Me.HJ_GetOperationInfoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HJ_GetOperationInfoTableAdapter = New v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.HJ_GetOperationInfoTableAdapter()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblvcheckKontrolleOperatorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblvcheckKontrolleLinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblvcheckKontrolleTeamBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HJ_GetOperationInfoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableAdapterManager.tbl_vcheckKontrolleLinieTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleOperatorTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Me.Tbl_vcheckKontrolleTableAdapter
        Me.TableAdapterManager.tbl_vcheckKontrolleTeamTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = v_CheckKontrolle_Auswertung.ProdKontrolleDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(33, 257)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Speichern"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cb_Ma
        '
        Me.cb_Ma.DataSource = Me.TblvcheckKontrolleOperatorBindingSource
        Me.cb_Ma.DisplayMember = "Operator"
        Me.cb_Ma.FormattingEnabled = True
        Me.cb_Ma.Location = New System.Drawing.Point(93, 126)
        Me.cb_Ma.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Ma.Name = "cb_Ma"
        Me.cb_Ma.Size = New System.Drawing.Size(243, 24)
        Me.cb_Ma.TabIndex = 1
        Me.cb_Ma.ValueMember = "Operator"
        '
        'TblvcheckKontrolleOperatorBindingSource
        '
        Me.TblvcheckKontrolleOperatorBindingSource.DataMember = "tbl_vcheckKontrolleOperator"
        Me.TblvcheckKontrolleOperatorBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'Tbl_vcheckKontrolleOperatorTableAdapter
        '
        Me.Tbl_vcheckKontrolleOperatorTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 129)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mitarbeiter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 97)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Linie"
        '
        'cb_Linie
        '
        Me.cb_Linie.DataSource = Me.TblvcheckKontrolleLinieBindingSource
        Me.cb_Linie.DisplayMember = "Linie"
        Me.cb_Linie.FormattingEnabled = True
        Me.cb_Linie.Location = New System.Drawing.Point(93, 94)
        Me.cb_Linie.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Linie.Name = "cb_Linie"
        Me.cb_Linie.Size = New System.Drawing.Size(243, 24)
        Me.cb_Linie.TabIndex = 3
        Me.cb_Linie.ValueMember = "Linie"
        '
        'TblvcheckKontrolleLinieBindingSource
        '
        Me.TblvcheckKontrolleLinieBindingSource.DataMember = "tbl_vcheckKontrolleLinie"
        Me.TblvcheckKontrolleLinieBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Team"
        '
        'cb_Team
        '
        Me.cb_Team.DataSource = Me.TblvcheckKontrolleTeamBindingSource
        Me.cb_Team.DisplayMember = "Team"
        Me.cb_Team.FormattingEnabled = True
        Me.cb_Team.Location = New System.Drawing.Point(93, 62)
        Me.cb_Team.Margin = New System.Windows.Forms.Padding(4)
        Me.cb_Team.Name = "cb_Team"
        Me.cb_Team.Size = New System.Drawing.Size(243, 24)
        Me.cb_Team.TabIndex = 5
        Me.cb_Team.ValueMember = "Team"
        '
        'TblvcheckKontrolleTeamBindingSource
        '
        Me.TblvcheckKontrolleTeamBindingSource.DataMember = "tbl_vcheckKontrolleTeam"
        Me.TblvcheckKontrolleTeamBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'Tbl_vcheckKontrolleLinieTableAdapter
        '
        Me.Tbl_vcheckKontrolleLinieTableAdapter.ClearBeforeFill = True
        '
        'Tbl_vcheckKontrolleTeamTableAdapter
        '
        Me.Tbl_vcheckKontrolleTeamTableAdapter.ClearBeforeFill = True
        '
        'txt_MatNr
        '
        Me.txt_MatNr.Location = New System.Drawing.Point(93, 157)
        Me.txt_MatNr.Name = "txt_MatNr"
        Me.txt_MatNr.Size = New System.Drawing.Size(243, 22)
        Me.txt_MatNr.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 160)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Material Nr:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 188)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Auftrags Nr:"
        '
        'txt_Fauf
        '
        Me.txt_Fauf.Location = New System.Drawing.Point(93, 185)
        Me.txt_Fauf.Name = "txt_Fauf"
        Me.txt_Fauf.Size = New System.Drawing.Size(139, 22)
        Me.txt_Fauf.TabIndex = 9
        '
        'dtp_Datum
        '
        Me.dtp_Datum.Location = New System.Drawing.Point(93, 213)
        Me.dtp_Datum.Name = "dtp_Datum"
        Me.dtp_Datum.Size = New System.Drawing.Size(243, 22)
        Me.dtp_Datum.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 218)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 16)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Datum"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(187, 257)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(146, 33)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Beenden"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btn_v_Check
        '
        Me.btn_v_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_v_Check.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btn_v_Check.Location = New System.Drawing.Point(239, 185)
        Me.btn_v_Check.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_v_Check.Name = "btn_v_Check"
        Me.btn_v_Check.Size = New System.Drawing.Size(97, 22)
        Me.btn_v_Check.TabIndex = 14
        Me.btn_v_Check.Text = "v-Check prüfen"
        Me.btn_v_Check.UseVisualStyleBackColor = True
        '
        'HJ_GetOperationInfoBindingSource
        '
        Me.HJ_GetOperationInfoBindingSource.DataMember = "HJ_GetOperationInfo"
        Me.HJ_GetOperationInfoBindingSource.DataSource = Me.ProdKontrolleDataSet
        '
        'HJ_GetOperationInfoTableAdapter
        '
        Me.HJ_GetOperationInfoTableAdapter.ClearBeforeFill = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.Label7.Location = New System.Drawing.Point(13, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(270, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "v-Check Kontrolle Manuel erfassen"
        '
        'add
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(366, 314)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btn_v_Check)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtp_Datum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_Fauf)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_MatNr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cb_Team)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cb_Linie)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cb_Ma)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "add"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.TopMost = True
        CType(Me.ProdKontrolleDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vcheckKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblvcheckKontrolleOperatorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblvcheckKontrolleLinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblvcheckKontrolleTeamBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HJ_GetOperationInfoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProdKontrolleDataSet As ProdKontrolleDataSet
    Friend WithEvents Tbl_vcheckKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTableAdapter
    Friend WithEvents TableAdapterManager As ProdKontrolleDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Button1 As Button
    Friend WithEvents cb_Ma As ComboBox
    Friend WithEvents TblvcheckKontrolleOperatorBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleOperatorTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleOperatorTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cb_Linie As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_Team As ComboBox
    Friend WithEvents TblvcheckKontrolleLinieBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleLinieTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleLinieTableAdapter
    Friend WithEvents TblvcheckKontrolleTeamBindingSource As BindingSource
    Friend WithEvents Tbl_vcheckKontrolleTeamTableAdapter As ProdKontrolleDataSetTableAdapters.tbl_vcheckKontrolleTeamTableAdapter
    Friend WithEvents txt_MatNr As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_Fauf As TextBox
    Friend WithEvents dtp_Datum As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents btn_v_Check As Button
    Friend WithEvents HJ_GetOperationInfoBindingSource As BindingSource
    Friend WithEvents HJ_GetOperationInfoTableAdapter As ProdKontrolleDataSetTableAdapters.HJ_GetOperationInfoTableAdapter
    Friend WithEvents Label7 As Label
End Class
