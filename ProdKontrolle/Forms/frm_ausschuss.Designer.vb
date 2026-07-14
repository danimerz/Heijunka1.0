<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ausschuss
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabAusschuss = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.dgv_ausschuss = New System.Windows.Forms.DataGridView()
        Me.TabAnsicht = New System.Windows.Forms.TabPage()
        Me.dgv_korrektur = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArtikelNummer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArtikelBezeichnung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Menge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gebucht = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_minus = New System.Windows.Forms.Button()
        Me.btn_plus = New System.Windows.Forms.Button()
        Me.txt_Anzahl = New System.Windows.Forms.TextBox()
        Me.lbl_Material = New System.Windows.Forms.Label()
        Me.btn_buchen = New System.Windows.Forms.Button()
        Me.btn_delete = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabAusschuss.SuspendLayout()
        CType(Me.dgv_ausschuss, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAnsicht.SuspendLayout()
        CType(Me.dgv_korrektur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_delete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabAusschuss)
        Me.TabControl1.Controls.Add(Me.TabAnsicht)
        Me.TabControl1.Location = New System.Drawing.Point(2, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1188, 530)
        Me.TabControl1.TabIndex = 8
        '
        'TabAusschuss
        '
        Me.TabAusschuss.Controls.Add(Me.Label1)
        Me.TabAusschuss.Controls.Add(Me.txt_search)
        Me.TabAusschuss.Controls.Add(Me.dgv_ausschuss)
        Me.TabAusschuss.Location = New System.Drawing.Point(4, 34)
        Me.TabAusschuss.Name = "TabAusschuss"
        Me.TabAusschuss.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAusschuss.Size = New System.Drawing.Size(1180, 492)
        Me.TabAusschuss.TabIndex = 0
        Me.TabAusschuss.Text = "Ausschuss Buchen"
        Me.TabAusschuss.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.Label1.Location = New System.Drawing.Point(21, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 47)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Suchen:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_search
        '
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!)
        Me.txt_search.Location = New System.Drawing.Point(176, 14)
        Me.txt_search.Multiline = True
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(987, 47)
        Me.txt_search.TabIndex = 14
        '
        'dgv_ausschuss
        '
        Me.dgv_ausschuss.AllowUserToAddRows = False
        Me.dgv_ausschuss.AllowUserToDeleteRows = False
        Me.dgv_ausschuss.AllowUserToResizeColumns = False
        Me.dgv_ausschuss.AllowUserToResizeRows = False
        Me.dgv_ausschuss.Anchor = System.Windows.Forms.AnchorStyles.Top
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_ausschuss.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_ausschuss.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_ausschuss.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_ausschuss.Location = New System.Drawing.Point(18, 67)
        Me.dgv_ausschuss.Margin = New System.Windows.Forms.Padding(6)
        Me.dgv_ausschuss.MultiSelect = False
        Me.dgv_ausschuss.Name = "dgv_ausschuss"
        Me.dgv_ausschuss.ReadOnly = True
        Me.dgv_ausschuss.RowHeadersVisible = False
        Me.dgv_ausschuss.RowTemplate.Height = 35
        Me.dgv_ausschuss.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_ausschuss.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_ausschuss.Size = New System.Drawing.Size(1144, 420)
        Me.dgv_ausschuss.TabIndex = 8
        '
        'TabAnsicht
        '
        Me.TabAnsicht.Controls.Add(Me.dgv_korrektur)
        Me.TabAnsicht.Location = New System.Drawing.Point(4, 34)
        Me.TabAnsicht.Name = "TabAnsicht"
        Me.TabAnsicht.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAnsicht.Size = New System.Drawing.Size(1180, 492)
        Me.TabAnsicht.TabIndex = 1
        Me.TabAnsicht.Text = "Ausschuss Bearbeiten"
        Me.TabAnsicht.UseVisualStyleBackColor = True
        '
        'dgv_korrektur
        '
        Me.dgv_korrektur.AllowUserToAddRows = False
        Me.dgv_korrektur.AllowUserToDeleteRows = False
        Me.dgv_korrektur.AllowUserToResizeColumns = False
        Me.dgv_korrektur.AllowUserToResizeRows = False
        Me.dgv_korrektur.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_korrektur.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_korrektur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_korrektur.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Datum, Me.Line, Me.ArtikelNummer, Me.ArtikelBezeichnung, Me.plo, Me.Menge, Me.preis, Me.gebucht})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_korrektur.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgv_korrektur.Location = New System.Drawing.Point(18, 70)
        Me.dgv_korrektur.Margin = New System.Windows.Forms.Padding(6)
        Me.dgv_korrektur.MultiSelect = False
        Me.dgv_korrektur.Name = "dgv_korrektur"
        Me.dgv_korrektur.ReadOnly = True
        Me.dgv_korrektur.RowHeadersVisible = False
        Me.dgv_korrektur.RowTemplate.Height = 35
        Me.dgv_korrektur.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgv_korrektur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_korrektur.Size = New System.Drawing.Size(1144, 413)
        Me.dgv_korrektur.TabIndex = 9
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'Datum
        '
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        Me.Datum.Width = 220
        '
        'Line
        '
        Me.Line.HeaderText = "Linie"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.Visible = False
        Me.Line.Width = 200
        '
        'ArtikelNummer
        '
        Me.ArtikelNummer.HeaderText = "ArtikelNummer"
        Me.ArtikelNummer.Name = "ArtikelNummer"
        Me.ArtikelNummer.ReadOnly = True
        Me.ArtikelNummer.Width = 240
        '
        'ArtikelBezeichnung
        '
        Me.ArtikelBezeichnung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ArtikelBezeichnung.HeaderText = "ArtikelBezeichnung"
        Me.ArtikelBezeichnung.Name = "ArtikelBezeichnung"
        Me.ArtikelBezeichnung.ReadOnly = True
        '
        'plo
        '
        Me.plo.HeaderText = "PLO"
        Me.plo.Name = "plo"
        Me.plo.ReadOnly = True
        '
        'Menge
        '
        Me.Menge.HeaderText = "stk"
        Me.Menge.Name = "Menge"
        Me.Menge.ReadOnly = True
        '
        'preis
        '
        Me.preis.HeaderText = "Preis"
        Me.preis.Name = "preis"
        Me.preis.ReadOnly = True
        Me.preis.Visible = False
        '
        'gebucht
        '
        Me.gebucht.HeaderText = "Gebucht"
        Me.gebucht.Name = "gebucht"
        Me.gebucht.ReadOnly = True
        Me.gebucht.Visible = False
        '
        'btn_minus
        '
        Me.btn_minus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_minus.Location = New System.Drawing.Point(693, 550)
        Me.btn_minus.Name = "btn_minus"
        Me.btn_minus.Size = New System.Drawing.Size(61, 54)
        Me.btn_minus.TabIndex = 18
        Me.btn_minus.Text = "-"
        Me.btn_minus.UseVisualStyleBackColor = True
        '
        'btn_plus
        '
        Me.btn_plus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_plus.Location = New System.Drawing.Point(882, 550)
        Me.btn_plus.Name = "btn_plus"
        Me.btn_plus.Size = New System.Drawing.Size(61, 54)
        Me.btn_plus.TabIndex = 17
        Me.btn_plus.Text = "+"
        Me.btn_plus.UseVisualStyleBackColor = True
        '
        'txt_Anzahl
        '
        Me.txt_Anzahl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_Anzahl.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Anzahl.Location = New System.Drawing.Point(763, 550)
        Me.txt_Anzahl.Multiline = True
        Me.txt_Anzahl.Name = "txt_Anzahl"
        Me.txt_Anzahl.Size = New System.Drawing.Size(110, 54)
        Me.txt_Anzahl.TabIndex = 16
        Me.txt_Anzahl.Text = "1"
        Me.txt_Anzahl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbl_Material
        '
        Me.lbl_Material.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Material.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbl_Material.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbl_Material.Location = New System.Drawing.Point(26, 550)
        Me.lbl_Material.Name = "lbl_Material"
        Me.lbl_Material.Size = New System.Drawing.Size(658, 54)
        Me.lbl_Material.TabIndex = 15
        Me.lbl_Material.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_buchen
        '
        Me.btn_buchen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_buchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_buchen.Location = New System.Drawing.Point(952, 550)
        Me.btn_buchen.Name = "btn_buchen"
        Me.btn_buchen.Size = New System.Drawing.Size(217, 54)
        Me.btn_buchen.TabIndex = 14
        Me.btn_buchen.Text = "Buchen"
        Me.btn_buchen.UseVisualStyleBackColor = True
        '
        'btn_delete
        '
        Me.btn_delete.Image = Global.ProdKontrolle.My.Resources.Resources.trashbin
        Me.btn_delete.Location = New System.Drawing.Point(1112, 550)
        Me.btn_delete.Margin = New System.Windows.Forms.Padding(50)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(56, 54)
        Me.btn_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btn_delete.TabIndex = 19
        Me.btn_delete.TabStop = False
        '
        'frm_ausschuss
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1193, 614)
        Me.Controls.Add(Me.btn_buchen)
        Me.Controls.Add(Me.btn_delete)
        Me.Controls.Add(Me.btn_minus)
        Me.Controls.Add(Me.btn_plus)
        Me.Controls.Add(Me.txt_Anzahl)
        Me.Controls.Add(Me.lbl_Material)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ausschuss"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ausschuss"
        Me.TabControl1.ResumeLayout(False)
        Me.TabAusschuss.ResumeLayout(False)
        Me.TabAusschuss.PerformLayout()
        CType(Me.dgv_ausschuss, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAnsicht.ResumeLayout(False)
        CType(Me.dgv_korrektur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_delete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabAusschuss As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_search As TextBox
    Friend WithEvents dgv_ausschuss As DataGridView
    Friend WithEvents TabAnsicht As TabPage
    Friend WithEvents dgv_korrektur As DataGridView
    Friend WithEvents btn_minus As Button
    Friend WithEvents btn_plus As Button
    Friend WithEvents txt_Anzahl As TextBox
    Friend WithEvents lbl_Material As Label
    Friend WithEvents btn_buchen As Button
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents Datum As DataGridViewTextBoxColumn
    Friend WithEvents Line As DataGridViewTextBoxColumn
    Friend WithEvents ArtikelNummer As DataGridViewTextBoxColumn
    Friend WithEvents ArtikelBezeichnung As DataGridViewTextBoxColumn
    Friend WithEvents plo As DataGridViewTextBoxColumn
    Friend WithEvents Menge As DataGridViewTextBoxColumn
    Friend WithEvents preis As DataGridViewTextBoxColumn
    Friend WithEvents gebucht As DataGridViewTextBoxColumn
    Friend WithEvents btn_delete As PictureBox
End Class
