<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_FaufSearch
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
        Me.txt_Auftragsnummer = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv_Auftrag = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btn_suchen = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txt_Langtext = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbl_losgrösse = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_kurztext = New System.Windows.Forms.Label()
        Me.lbl_MatNr = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.VorgangsuebersichtBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VorgangsNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartdatumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnddatumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArbeitsplatzDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SteuerschlüsselDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KurztextVorgangDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VorgangsMengeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgv_Auftrag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.VorgangsuebersichtBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_Auftragsnummer
        '
        Me.txt_Auftragsnummer.Location = New System.Drawing.Point(140, 25)
        Me.txt_Auftragsnummer.Name = "txt_Auftragsnummer"
        Me.txt_Auftragsnummer.Size = New System.Drawing.Size(208, 26)
        Me.txt_Auftragsnummer.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv_Auftrag)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 177)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(731, 322)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auftragsübersicht"
        '
        'dgv_Auftrag
        '
        Me.dgv_Auftrag.AllowUserToAddRows = False
        Me.dgv_Auftrag.AllowUserToDeleteRows = False
        Me.dgv_Auftrag.AutoGenerateColumns = False
        Me.dgv_Auftrag.BackgroundColor = System.Drawing.Color.White
        Me.dgv_Auftrag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Auftrag.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VorgangsNr, Me.StartdatumDataGridViewTextBoxColumn, Me.EnddatumDataGridViewTextBoxColumn, Me.ArbeitsplatzDataGridViewTextBoxColumn, Me.SteuerschlüsselDataGridViewTextBoxColumn, Me.KurztextVorgangDataGridViewTextBoxColumn, Me.VorgangsMengeDataGridViewTextBoxColumn, Me.RückgemeldeteMengeDataGridViewTextBoxColumn})
        Me.dgv_Auftrag.DataSource = Me.VorgangsuebersichtBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Auftrag.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Auftrag.Location = New System.Drawing.Point(10, 34)
        Me.dgv_Auftrag.Name = "dgv_Auftrag"
        Me.dgv_Auftrag.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Auftrag.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Auftrag.RowHeadersVisible = False
        Me.dgv_Auftrag.RowTemplate.Height = 26
        Me.dgv_Auftrag.RowTemplate.ReadOnly = True
        Me.dgv_Auftrag.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Auftrag.Size = New System.Drawing.Size(715, 276)
        Me.dgv_Auftrag.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.btn_suchen)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_Auftragsnummer)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(731, 73)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Auftrag suchen"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(507, 28)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(175, 24)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "nur Relevante Daten"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btn_suchen
        '
        Me.btn_suchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_suchen.Location = New System.Drawing.Point(356, 22)
        Me.btn_suchen.Name = "btn_suchen"
        Me.btn_suchen.Size = New System.Drawing.Size(89, 33)
        Me.btn_suchen.TabIndex = 3
        Me.btn_suchen.Text = "suchen"
        Me.btn_suchen.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Auftragsnummer:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txt_Langtext)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 504)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(731, 201)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Langtext"
        '
        'txt_Langtext
        '
        Me.txt_Langtext.Location = New System.Drawing.Point(10, 25)
        Me.txt_Langtext.Multiline = True
        Me.txt_Langtext.Name = "txt_Langtext"
        Me.txt_Langtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Langtext.Size = New System.Drawing.Size(715, 170)
        Me.txt_Langtext.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_losgrösse)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.lbl_kurztext)
        Me.GroupBox4.Controls.Add(Me.lbl_MatNr)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 91)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(731, 80)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Kopfdaten"
        '
        'lbl_losgrösse
        '
        Me.lbl_losgrösse.AutoSize = True
        Me.lbl_losgrösse.Location = New System.Drawing.Point(485, 26)
        Me.lbl_losgrösse.Name = "lbl_losgrösse"
        Me.lbl_losgrösse.Size = New System.Drawing.Size(0, 20)
        Me.lbl_losgrösse.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(352, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Losgrösse:"
        '
        'lbl_kurztext
        '
        Me.lbl_kurztext.AutoSize = True
        Me.lbl_kurztext.Location = New System.Drawing.Point(139, 50)
        Me.lbl_kurztext.Name = "lbl_kurztext"
        Me.lbl_kurztext.Size = New System.Drawing.Size(0, 20)
        Me.lbl_kurztext.TabIndex = 3
        '
        'lbl_MatNr
        '
        Me.lbl_MatNr.AutoSize = True
        Me.lbl_MatNr.Location = New System.Drawing.Point(139, 26)
        Me.lbl_MatNr.Name = "lbl_MatNr"
        Me.lbl_MatNr.Size = New System.Drawing.Size(0, 20)
        Me.lbl_MatNr.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Kurztext:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Materialnummer:"
        '
        'VorgangsuebersichtBindingSource
        '
        Me.VorgangsuebersichtBindingSource.DataSource = GetType(ProdKontrolle.Vorgangsuebersicht)
        '
        'VorgangsNr
        '
        Me.VorgangsNr.DataPropertyName = "VorgansNr"
        Me.VorgangsNr.HeaderText = "VorgangsNummer"
        Me.VorgangsNr.Name = "VorgangsNr"
        Me.VorgangsNr.ReadOnly = True
        Me.VorgangsNr.Visible = False
        '
        'StartdatumDataGridViewTextBoxColumn
        '
        Me.StartdatumDataGridViewTextBoxColumn.DataPropertyName = "Startdatum"
        Me.StartdatumDataGridViewTextBoxColumn.HeaderText = "Start"
        Me.StartdatumDataGridViewTextBoxColumn.Name = "StartdatumDataGridViewTextBoxColumn"
        Me.StartdatumDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EnddatumDataGridViewTextBoxColumn
        '
        Me.EnddatumDataGridViewTextBoxColumn.DataPropertyName = "Enddatum"
        Me.EnddatumDataGridViewTextBoxColumn.HeaderText = "Ende"
        Me.EnddatumDataGridViewTextBoxColumn.Name = "EnddatumDataGridViewTextBoxColumn"
        Me.EnddatumDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ArbeitsplatzDataGridViewTextBoxColumn
        '
        Me.ArbeitsplatzDataGridViewTextBoxColumn.DataPropertyName = "Arbeitsplatz"
        Me.ArbeitsplatzDataGridViewTextBoxColumn.HeaderText = "AP"
        Me.ArbeitsplatzDataGridViewTextBoxColumn.Name = "ArbeitsplatzDataGridViewTextBoxColumn"
        Me.ArbeitsplatzDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SteuerschlüsselDataGridViewTextBoxColumn
        '
        Me.SteuerschlüsselDataGridViewTextBoxColumn.DataPropertyName = "Steuerschlüssel"
        Me.SteuerschlüsselDataGridViewTextBoxColumn.HeaderText = "strsch"
        Me.SteuerschlüsselDataGridViewTextBoxColumn.Name = "SteuerschlüsselDataGridViewTextBoxColumn"
        Me.SteuerschlüsselDataGridViewTextBoxColumn.ReadOnly = True
        Me.SteuerschlüsselDataGridViewTextBoxColumn.Visible = False
        '
        'KurztextVorgangDataGridViewTextBoxColumn
        '
        Me.KurztextVorgangDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.KurztextVorgangDataGridViewTextBoxColumn.DataPropertyName = "KurztextVorgang"
        Me.KurztextVorgangDataGridViewTextBoxColumn.HeaderText = "Kurztext"
        Me.KurztextVorgangDataGridViewTextBoxColumn.Name = "KurztextVorgangDataGridViewTextBoxColumn"
        Me.KurztextVorgangDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VorgangsMengeDataGridViewTextBoxColumn
        '
        Me.VorgangsMengeDataGridViewTextBoxColumn.DataPropertyName = "VorgangsMenge"
        Me.VorgangsMengeDataGridViewTextBoxColumn.HeaderText = "Soll"
        Me.VorgangsMengeDataGridViewTextBoxColumn.Name = "VorgangsMengeDataGridViewTextBoxColumn"
        Me.VorgangsMengeDataGridViewTextBoxColumn.ReadOnly = True
        Me.VorgangsMengeDataGridViewTextBoxColumn.Width = 60
        '
        'RückgemeldeteMengeDataGridViewTextBoxColumn
        '
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn.DataPropertyName = "RückgemeldeteMenge"
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn.HeaderText = "Ist"
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn.Name = "RückgemeldeteMengeDataGridViewTextBoxColumn"
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn.ReadOnly = True
        Me.RückgemeldeteMengeDataGridViewTextBoxColumn.Width = 60
        '
        'frm_FaufSearch
        '
        Me.AcceptButton = Me.btn_suchen
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(760, 715)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_FaufSearch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Auftrags Übersicht"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgv_Auftrag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.VorgangsuebersichtBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_Auftragsnummer As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv_Auftrag As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_suchen As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents VorgangsuebersichtBindingSource As BindingSource
    Friend WithEvents txt_Langtext As TextBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_losgrösse As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_kurztext As Label
    Friend WithEvents lbl_MatNr As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents VorgangsNr As DataGridViewTextBoxColumn
    Friend WithEvents StartdatumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EnddatumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ArbeitsplatzDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SteuerschlüsselDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KurztextVorgangDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VorgangsMengeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RückgemeldeteMengeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
