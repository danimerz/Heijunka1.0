<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Info
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
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.lbl_Titel = New System.Windows.Forms.Label()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_ok
        '
        Me.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ok.Location = New System.Drawing.Point(12, 238)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(471, 40)
        Me.btn_ok.TabIndex = 0
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'lbl_Titel
        '
        Me.lbl_Titel.AutoSize = True
        Me.lbl_Titel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Titel.Location = New System.Drawing.Point(8, 9)
        Me.lbl_Titel.Name = "lbl_Titel"
        Me.lbl_Titel.Size = New System.Drawing.Size(53, 25)
        Me.lbl_Titel.TabIndex = 1
        Me.lbl_Titel.Text = "Titel"
        '
        'lbl_info
        '
        Me.lbl_info.Location = New System.Drawing.Point(12, 43)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(471, 183)
        Me.lbl_info.TabIndex = 2
        Me.lbl_info.Text = "Label2"
        '
        'frm_Info
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(495, 290)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_info)
        Me.Controls.Add(Me.lbl_Titel)
        Me.Controls.Add(Me.btn_ok)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frm_Info"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Information"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_ok As Button
    Friend WithEvents lbl_Titel As Label
    Friend WithEvents lbl_info As Label
End Class
