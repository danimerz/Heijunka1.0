<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Dok
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
        Me.dgv_Dok = New System.Windows.Forms.DataGridView()
        Me.DokNr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DokVr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DokText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Link = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_titel = New System.Windows.Forms.Label()
        CType(Me.dgv_Dok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Dok
        '
        Me.dgv_Dok.AllowUserToAddRows = False
        Me.dgv_Dok.AllowUserToDeleteRows = False
        Me.dgv_Dok.AllowUserToResizeColumns = False
        Me.dgv_Dok.AllowUserToResizeRows = False
        Me.dgv_Dok.BackgroundColor = System.Drawing.Color.White
        Me.dgv_Dok.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv_Dok.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Dok.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_Dok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Dok.ColumnHeadersVisible = False
        Me.dgv_Dok.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DokNr, Me.DokVr, Me.DokText, Me.Link})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Dok.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_Dok.EnableHeadersVisualStyles = False
        Me.dgv_Dok.GridColor = System.Drawing.Color.White
        Me.dgv_Dok.Location = New System.Drawing.Point(12, 61)
        Me.dgv_Dok.MultiSelect = False
        Me.dgv_Dok.Name = "dgv_Dok"
        Me.dgv_Dok.ReadOnly = True
        Me.dgv_Dok.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Dok.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_Dok.RowHeadersVisible = False
        Me.dgv_Dok.RowTemplate.Height = 50
        Me.dgv_Dok.RowTemplate.ReadOnly = True
        Me.dgv_Dok.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Dok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Dok.Size = New System.Drawing.Size(902, 395)
        Me.dgv_Dok.TabIndex = 0
        '
        'DokNr
        '
        Me.DokNr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DokNr.HeaderText = "DokNr"
        Me.DokNr.Name = "DokNr"
        Me.DokNr.ReadOnly = True
        '
        'DokVr
        '
        Me.DokVr.HeaderText = "Index"
        Me.DokVr.Name = "DokVr"
        Me.DokVr.ReadOnly = True
        Me.DokVr.Width = 80
        '
        'DokText
        '
        Me.DokText.HeaderText = "Text"
        Me.DokText.Name = "DokText"
        Me.DokText.ReadOnly = True
        Me.DokText.Width = 300
        '
        'Link
        '
        Me.Link.HeaderText = "Link"
        Me.Link.Name = "Link"
        Me.Link.ReadOnly = True
        Me.Link.Visible = False
        '
        'lbl_titel
        '
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_titel.Location = New System.Drawing.Point(7, 9)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(287, 29)
        Me.lbl_titel.TabIndex = 1
        Me.lbl_titel.Text = "Dokumente zum Auftrag"
        '
        'frm_Dok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(926, 468)
        Me.Controls.Add(Me.lbl_titel)
        Me.Controls.Add(Me.dgv_Dok)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Dok"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dokumente zum akutellen Auftrag"
        Me.TopMost = True
        CType(Me.dgv_Dok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_Dok As DataGridView
    Friend WithEvents DokNr As DataGridViewTextBoxColumn
    Friend WithEvents DokVr As DataGridViewTextBoxColumn
    Friend WithEvents DokText As DataGridViewTextBoxColumn
    Friend WithEvents Link As DataGridViewTextBoxColumn
    Friend WithEvents lbl_titel As Label
End Class
