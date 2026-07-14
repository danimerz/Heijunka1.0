<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbl_Update = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ComputernameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SWVersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPVersionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsernameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastSeen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Update = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Message = New System.Windows.Forms.DataGridViewImageColumn()
        Me.BS_HeijunkaInfo = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_Info1 = New HeijunkaInfo.DS_Info()
        Me.lbl_anzdatensätze = New System.Windows.Forms.Label()
        Me.pb_Connect = New System.Windows.Forms.PictureBox()
        Me.Computername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BS_HeijunkaInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_Info1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pb_Connect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1389, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Reconnect"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbl_Update
        '
        Me.lbl_Update.AutoSize = True
        Me.lbl_Update.Location = New System.Drawing.Point(121, 9)
        Me.lbl_Update.Name = "lbl_Update"
        Me.lbl_Update.Size = New System.Drawing.Size(41, 15)
        Me.lbl_Update.TabIndex = 4
        Me.lbl_Update.Text = "Label1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ComputernameDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.Status1, Me.Linie, Me.SWVersionDataGridViewTextBoxColumn, Me.SAPVersionDataGridViewTextBoxColumn, Me.UsernameDataGridViewTextBoxColumn, Me.LastSeen, Me.Update, Me.Message})
        Me.DataGridView1.DataSource = Me.BS_HeijunkaInfo
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.GridColor = System.Drawing.Color.DarkGray
        Me.DataGridView1.Location = New System.Drawing.Point(12, 54)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 25
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(1469, 931)
        Me.DataGridView1.TabIndex = 6
        '
        'ComputernameDataGridViewTextBoxColumn
        '
        Me.ComputernameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ComputernameDataGridViewTextBoxColumn.DataPropertyName = "Computername"
        Me.ComputernameDataGridViewTextBoxColumn.HeaderText = "Computername"
        Me.ComputernameDataGridViewTextBoxColumn.Name = "ComputernameDataGridViewTextBoxColumn"
        Me.ComputernameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Status1
        '
        Me.Status1.DataPropertyName = "Status1"
        Me.Status1.HeaderText = "Status1"
        Me.Status1.Name = "Status1"
        Me.Status1.ReadOnly = True
        Me.Status1.Width = 200
        '
        'Linie
        '
        Me.Linie.DataPropertyName = "Linie"
        Me.Linie.HeaderText = "Linie"
        Me.Linie.Name = "Linie"
        Me.Linie.ReadOnly = True
        Me.Linie.Width = 200
        '
        'SWVersionDataGridViewTextBoxColumn
        '
        Me.SWVersionDataGridViewTextBoxColumn.DataPropertyName = "SW-Version"
        Me.SWVersionDataGridViewTextBoxColumn.HeaderText = "SW-Version"
        Me.SWVersionDataGridViewTextBoxColumn.Name = "SWVersionDataGridViewTextBoxColumn"
        Me.SWVersionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SAPVersionDataGridViewTextBoxColumn
        '
        Me.SAPVersionDataGridViewTextBoxColumn.DataPropertyName = "SAP-Version"
        Me.SAPVersionDataGridViewTextBoxColumn.HeaderText = "SAP-Version"
        Me.SAPVersionDataGridViewTextBoxColumn.Name = "SAPVersionDataGridViewTextBoxColumn"
        Me.SAPVersionDataGridViewTextBoxColumn.ReadOnly = True
        Me.SAPVersionDataGridViewTextBoxColumn.Width = 150
        '
        'UsernameDataGridViewTextBoxColumn
        '
        Me.UsernameDataGridViewTextBoxColumn.DataPropertyName = "Username"
        Me.UsernameDataGridViewTextBoxColumn.HeaderText = "Username"
        Me.UsernameDataGridViewTextBoxColumn.Name = "UsernameDataGridViewTextBoxColumn"
        Me.UsernameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LastSeen
        '
        Me.LastSeen.DataPropertyName = "LastSeen"
        Me.LastSeen.HeaderText = "LastSeen"
        Me.LastSeen.Name = "LastSeen"
        Me.LastSeen.ReadOnly = True
        Me.LastSeen.Width = 150
        '
        'Update
        '
        Me.Update.HeaderText = "Update"
        Me.Update.Image = Global.HeijunkaInfo.My.Resources.Resources.update__1_
        Me.Update.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Update.Name = "Update"
        Me.Update.ReadOnly = True
        Me.Update.Width = 60
        '
        'Message
        '
        Me.Message.HeaderText = "Message"
        Me.Message.Image = Global.HeijunkaInfo.My.Resources.Resources.email
        Me.Message.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Message.Name = "Message"
        Me.Message.ReadOnly = True
        Me.Message.Width = 60
        '
        'BS_HeijunkaInfo
        '
        Me.BS_HeijunkaInfo.DataMember = "HeijunkaInfo"
        Me.BS_HeijunkaInfo.DataSource = Me.DS_Info1
        '
        'DS_Info1
        '
        Me.DS_Info1.DataSetName = "DS_Info"
        Me.DS_Info1.Namespace = "http://tempuri.org/DS_Info.xsd"
        Me.DS_Info1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbl_anzdatensätze
        '
        Me.lbl_anzdatensätze.AutoSize = True
        Me.lbl_anzdatensätze.Location = New System.Drawing.Point(121, 28)
        Me.lbl_anzdatensätze.Name = "lbl_anzdatensätze"
        Me.lbl_anzdatensätze.Size = New System.Drawing.Size(27, 15)
        Me.lbl_anzdatensätze.TabIndex = 7
        Me.lbl_anzdatensätze.Text = "text"
        '
        'pb_Connect
        '
        Me.pb_Connect.Location = New System.Drawing.Point(82, 20)
        Me.pb_Connect.Name = "pb_Connect"
        Me.pb_Connect.Size = New System.Drawing.Size(15, 15)
        Me.pb_Connect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb_Connect.TabIndex = 8
        Me.pb_Connect.TabStop = False
        '
        'Computername
        '
        Me.Computername.HeaderText = "Computername"
        Me.Computername.Name = "Computername"
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Verbunden"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(1291, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 23)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Fill Datagrid"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1493, 997)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pb_Connect)
        Me.Controls.Add(Me.lbl_anzdatensätze)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lbl_Update)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Heijunka Admin Dashboard"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BS_HeijunkaInfo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_Info1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pb_Connect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents lbl_Update As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BS_HeijunkaInfo As BindingSource
    Friend WithEvents DS_Info1 As HeijunkaInfo.DS_Info
    Friend WithEvents lbl_anzdatensätze As Label
    Friend WithEvents pb_Connect As PictureBox
    Friend WithEvents Computername As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents ComputernameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents Status1 As DataGridViewTextBoxColumn
    Friend WithEvents Linie As DataGridViewTextBoxColumn
    Friend WithEvents SWVersionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SAPVersionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsernameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LastSeen As DataGridViewTextBoxColumn
    Friend WithEvents Update As DataGridViewImageColumn
    Friend WithEvents Message As DataGridViewImageColumn
    Friend WithEvents Button2 As Button
End Class
