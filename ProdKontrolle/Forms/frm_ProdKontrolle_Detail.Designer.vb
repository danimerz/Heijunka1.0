<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_ProdKontrolle_Detail
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
        Me.dgv_Deatil = New System.Windows.Forms.DataGridView()
        Me.Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAUF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grund = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_titel = New System.Windows.Forms.Label()
        Me.btn_einzeln = New System.Windows.Forms.Button()
        Me.btn_alle = New System.Windows.Forms.Button()
        CType(Me.dgv_Deatil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_Deatil
        '
        Me.dgv_Deatil.AllowUserToAddRows = False
        Me.dgv_Deatil.AllowUserToDeleteRows = False
        Me.dgv_Deatil.AllowUserToResizeColumns = False
        Me.dgv_Deatil.AllowUserToResizeRows = False
        Me.dgv_Deatil.BackgroundColor = System.Drawing.Color.White
        Me.dgv_Deatil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Deatil.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Datum, Me.Linie, Me.Material, Me.FAUF, Me.Soll, Me.Ist, Me.Status, Me.Grund, Me.Detail, Me.ID})
        Me.dgv_Deatil.Location = New System.Drawing.Point(12, 76)
        Me.dgv_Deatil.MultiSelect = False
        Me.dgv_Deatil.Name = "dgv_Deatil"
        Me.dgv_Deatil.ReadOnly = True
        Me.dgv_Deatil.RowHeadersVisible = False
        Me.dgv_Deatil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_Deatil.Size = New System.Drawing.Size(929, 240)
        Me.dgv_Deatil.TabIndex = 0
        '
        'Datum
        '
        Me.Datum.HeaderText = "Datum"
        Me.Datum.Name = "Datum"
        Me.Datum.ReadOnly = True
        Me.Datum.Width = 120
        '
        'Linie
        '
        Me.Linie.HeaderText = "Linie"
        Me.Linie.Name = "Linie"
        Me.Linie.ReadOnly = True
        Me.Linie.Width = 150
        '
        'Material
        '
        Me.Material.HeaderText = "Material"
        Me.Material.Name = "Material"
        Me.Material.ReadOnly = True
        '
        'FAUF
        '
        Me.FAUF.HeaderText = "FAUF"
        Me.FAUF.Name = "FAUF"
        Me.FAUF.ReadOnly = True
        '
        'Soll
        '
        Me.Soll.HeaderText = "Soll"
        Me.Soll.Name = "Soll"
        Me.Soll.ReadOnly = True
        Me.Soll.Width = 30
        '
        'Ist
        '
        Me.Ist.HeaderText = "Ist"
        Me.Ist.Name = "Ist"
        Me.Ist.ReadOnly = True
        Me.Ist.Width = 30
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 80
        '
        'Grund
        '
        Me.Grund.HeaderText = "Grund"
        Me.Grund.Name = "Grund"
        Me.Grund.ReadOnly = True
        '
        'Detail
        '
        Me.Detail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Detail.HeaderText = "Detail"
        Me.Detail.Name = "Detail"
        Me.Detail.ReadOnly = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'lbl_titel
        '
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titel.Location = New System.Drawing.Point(12, 22)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(397, 29)
        Me.lbl_titel.TabIndex = 1
        Me.lbl_titel.Text = "Detailübersicht für Auftrag 31333333"
        '
        'btn_einzeln
        '
        Me.btn_einzeln.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_einzeln.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_einzeln.Location = New System.Drawing.Point(12, 331)
        Me.btn_einzeln.Name = "btn_einzeln"
        Me.btn_einzeln.Size = New System.Drawing.Size(226, 62)
        Me.btn_einzeln.TabIndex = 2
        Me.btn_einzeln.Text = "Ausgewählter Eintrag erledigt setzten"
        Me.btn_einzeln.UseVisualStyleBackColor = True
        '
        'btn_alle
        '
        Me.btn_alle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_alle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_alle.Location = New System.Drawing.Point(244, 331)
        Me.btn_alle.Name = "btn_alle"
        Me.btn_alle.Size = New System.Drawing.Size(226, 62)
        Me.btn_alle.TabIndex = 3
        Me.btn_alle.Text = "Alle erledigt setzten"
        Me.btn_alle.UseVisualStyleBackColor = True
        '
        'frm_ProdKontrolle_Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(953, 405)
        Me.Controls.Add(Me.btn_alle)
        Me.Controls.Add(Me.btn_einzeln)
        Me.Controls.Add(Me.lbl_titel)
        Me.Controls.Add(Me.dgv_Deatil)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_ProdKontrolle_Detail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Produktionskontrolle Detail"
        Me.TopMost = True
        CType(Me.dgv_Deatil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv_Deatil As DataGridView
    Friend WithEvents lbl_titel As Label
    Friend WithEvents btn_einzeln As Button
    Friend WithEvents btn_alle As Button
    Friend WithEvents Datum As DataGridViewTextBoxColumn
    Friend WithEvents Linie As DataGridViewTextBoxColumn
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents FAUF As DataGridViewTextBoxColumn
    Friend WithEvents Soll As DataGridViewTextBoxColumn
    Friend WithEvents Ist As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Grund As DataGridViewTextBoxColumn
    Friend WithEvents Detail As DataGridViewTextBoxColumn
    Friend WithEvents ID As DataGridViewTextBoxColumn
End Class
