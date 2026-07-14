<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_scanPcb
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
        Me.lbl_pcb = New System.Windows.Forms.Label()
        Me.txt_scan = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_pcb
        '
        Me.lbl_pcb.AutoSize = True
        Me.lbl_pcb.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_pcb.Location = New System.Drawing.Point(97, 9)
        Me.lbl_pcb.Name = "lbl_pcb"
        Me.lbl_pcb.Size = New System.Drawing.Size(89, 29)
        Me.lbl_pcb.TabIndex = 0
        Me.lbl_pcb.Text = "Label1"
        '
        'txt_scan
        '
        Me.txt_scan.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.txt_scan.Location = New System.Drawing.Point(17, 51)
        Me.txt_scan.Name = "txt_scan"
        Me.txt_scan.Size = New System.Drawing.Size(377, 35)
        Me.txt_scan.TabIndex = 1
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_ok.Location = New System.Drawing.Point(17, 92)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(377, 39)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "Eingabe"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 29)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "LP Nr.:"
        '
        'frm_scanPcb
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(405, 142)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.txt_scan)
        Me.Controls.Add(Me.lbl_pcb)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frm_scanPcb"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Leiterplatte Scannen"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_pcb As Label
    Friend WithEvents txt_scan As TextBox
    Friend WithEvents btn_ok As Button
    Friend WithEvents Label1 As Label
End Class
