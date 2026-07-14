<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_AenderungDetail
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
        Me.lbl_titel = New System.Windows.Forms.Label()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.txt_Aenderungstext = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbl_titel
        '
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titel.Location = New System.Drawing.Point(12, 21)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(433, 29)
        Me.lbl_titel.TabIndex = 2
        Me.lbl_titel.Text = "Änderungs Details für Auftrag 31333333"
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_close.Location = New System.Drawing.Point(12, 365)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(226, 62)
        Me.btn_close.TabIndex = 4
        Me.btn_close.Text = "Schliessen"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'txt_Aenderungstext
        '
        Me.txt_Aenderungstext.BackColor = System.Drawing.Color.White
        Me.txt_Aenderungstext.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Aenderungstext.Location = New System.Drawing.Point(12, 67)
        Me.txt_Aenderungstext.Multiline = True
        Me.txt_Aenderungstext.Name = "txt_Aenderungstext"
        Me.txt_Aenderungstext.ReadOnly = True
        Me.txt_Aenderungstext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_Aenderungstext.Size = New System.Drawing.Size(698, 292)
        Me.txt_Aenderungstext.TabIndex = 5
        '
        'frm_AenderungDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(735, 439)
        Me.Controls.Add(Me.txt_Aenderungstext)
        Me.Controls.Add(Me.btn_close)
        Me.Controls.Add(Me.lbl_titel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_AenderungDetail"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Änderung Detail"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_titel As Label
    Friend WithEvents btn_close As Button
    Friend WithEvents txt_Aenderungstext As TextBox
End Class
