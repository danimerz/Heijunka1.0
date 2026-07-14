<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_pcbAbruf
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
        Me.lbl_Auftrag = New System.Windows.Forms.Label()
        Me.lbl_Pcb = New System.Windows.Forms.Label()
        Me.pb_Fauf = New System.Windows.Forms.PictureBox()
        Me.btn_pcb_ok = New System.Windows.Forms.Button()
        Me.btn_pcb_nok = New System.Windows.Forms.Button()
        CType(Me.pb_Fauf, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_Auftrag
        '
        Me.lbl_Auftrag.AutoSize = True
        Me.lbl_Auftrag.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_Auftrag.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Auftrag.Name = "lbl_Auftrag"
        Me.lbl_Auftrag.Size = New System.Drawing.Size(89, 29)
        Me.lbl_Auftrag.TabIndex = 0
        Me.lbl_Auftrag.Text = "Label1"
        '
        'lbl_Pcb
        '
        Me.lbl_Pcb.AutoSize = True
        Me.lbl_Pcb.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_Pcb.Location = New System.Drawing.Point(12, 47)
        Me.lbl_Pcb.Name = "lbl_Pcb"
        Me.lbl_Pcb.Size = New System.Drawing.Size(89, 29)
        Me.lbl_Pcb.TabIndex = 1
        Me.lbl_Pcb.Text = "Label2"
        '
        'pb_Fauf
        '
        Me.pb_Fauf.Location = New System.Drawing.Point(17, 120)
        Me.pb_Fauf.Name = "pb_Fauf"
        Me.pb_Fauf.Size = New System.Drawing.Size(364, 68)
        Me.pb_Fauf.TabIndex = 2
        Me.pb_Fauf.TabStop = False
        '
        'btn_pcb_ok
        '
        Me.btn_pcb_ok.BackColor = System.Drawing.Color.Lime
        Me.btn_pcb_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_pcb_ok.Location = New System.Drawing.Point(17, 194)
        Me.btn_pcb_ok.Name = "btn_pcb_ok"
        Me.btn_pcb_ok.Size = New System.Drawing.Size(364, 55)
        Me.btn_pcb_ok.TabIndex = 3
        Me.btn_pcb_ok.Text = "LP verfügbar"
        Me.btn_pcb_ok.UseVisualStyleBackColor = False
        '
        'btn_pcb_nok
        '
        Me.btn_pcb_nok.BackColor = System.Drawing.Color.Red
        Me.btn_pcb_nok.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_pcb_nok.Location = New System.Drawing.Point(17, 255)
        Me.btn_pcb_nok.Name = "btn_pcb_nok"
        Me.btn_pcb_nok.Size = New System.Drawing.Size(364, 55)
        Me.btn_pcb_nok.TabIndex = 4
        Me.btn_pcb_nok.Text = "LP nicht verfügbar"
        Me.btn_pcb_nok.UseVisualStyleBackColor = False
        '
        'frm_pcbAbruf
        '
        Me.AcceptButton = Me.btn_pcb_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btn_pcb_nok
        Me.ClientSize = New System.Drawing.Size(392, 322)
        Me.Controls.Add(Me.btn_pcb_nok)
        Me.Controls.Add(Me.btn_pcb_ok)
        Me.Controls.Add(Me.pb_Fauf)
        Me.Controls.Add(Me.lbl_Pcb)
        Me.Controls.Add(Me.lbl_Auftrag)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_pcbAbruf"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "pcb Abruf"
        CType(Me.pb_Fauf, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_Auftrag As Label
    Friend WithEvents lbl_Pcb As Label
    Friend WithEvents pb_Fauf As PictureBox
    Friend WithEvents btn_pcb_ok As Button
    Friend WithEvents btn_pcb_nok As Button
End Class
