<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinieAuswaehlen
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TblLinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Tbl_LinieTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_OK = New System.Windows.Forms.Button()
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.TblLinieBindingSource
        Me.ComboBox1.DisplayMember = "Linie"
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 42)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(501, 37)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.ValueMember = "ID"
        '
        'TblLinieBindingSource
        '
        Me.TblLinieBindingSource.DataMember = "tbl_Linie"
        Me.TblLinieBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'DS_ProdKontrolle
        '
        Me.DS_ProdKontrolle.DataSetName = "DS_ProdKontrolle"
        Me.DS_ProdKontrolle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "bitte Linie auswählen:"
        '
        'btn_OK
        '
        Me.btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_OK.Location = New System.Drawing.Point(12, 85)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(501, 50)
        Me.btn_OK.TabIndex = 2
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'LinieAuswaehlen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 147)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "LinieAuswaehlen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LinieAuswaehlen"
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents TblLinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_OK As Button
End Class
