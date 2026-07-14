<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_print
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
        Me.pb_laden = New System.Windows.Forms.ProgressBar()
        Me.lbl_info = New System.Windows.Forms.Label()
        Me.btn_print = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_Minus = New System.Windows.Forms.Button()
        Me.btn_plus = New System.Windows.Forms.Button()
        Me.lbl_Anzahl = New System.Windows.Forms.Label()
        Me.T_beenden = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'pb_laden
        '
        Me.pb_laden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pb_laden.Location = New System.Drawing.Point(1, 126)
        Me.pb_laden.Name = "pb_laden"
        Me.pb_laden.Size = New System.Drawing.Size(380, 14)
        Me.pb_laden.TabIndex = 0
        '
        'lbl_info
        '
        Me.lbl_info.AutoSize = True
        Me.lbl_info.Location = New System.Drawing.Point(-2, 107)
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(39, 13)
        Me.lbl_info.TabIndex = 1
        Me.lbl_info.Text = "Label1"
        '
        'btn_print
        '
        Me.btn_print.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_print.Location = New System.Drawing.Point(1, 55)
        Me.btn_print.Name = "btn_print"
        Me.btn_print.Size = New System.Drawing.Size(380, 40)
        Me.btn_print.TabIndex = 2
        Me.btn_print.Text = "Drucken"
        Me.btn_print.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Anzahl Etiketten:"
        '
        'btn_Minus
        '
        Me.btn_Minus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_Minus.Location = New System.Drawing.Point(199, 6)
        Me.btn_Minus.Name = "btn_Minus"
        Me.btn_Minus.Size = New System.Drawing.Size(40, 35)
        Me.btn_Minus.TabIndex = 5
        Me.btn_Minus.Text = "-"
        Me.btn_Minus.UseVisualStyleBackColor = True
        '
        'btn_plus
        '
        Me.btn_plus.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_plus.Location = New System.Drawing.Point(337, 6)
        Me.btn_plus.Name = "btn_plus"
        Me.btn_plus.Size = New System.Drawing.Size(41, 35)
        Me.btn_plus.TabIndex = 6
        Me.btn_plus.Text = "+"
        Me.btn_plus.UseVisualStyleBackColor = True
        '
        'lbl_Anzahl
        '
        Me.lbl_Anzahl.BackColor = System.Drawing.Color.White
        Me.lbl_Anzahl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_Anzahl.Location = New System.Drawing.Point(245, 6)
        Me.lbl_Anzahl.Name = "lbl_Anzahl"
        Me.lbl_Anzahl.Size = New System.Drawing.Size(86, 35)
        Me.lbl_Anzahl.TabIndex = 7
        Me.lbl_Anzahl.Text = "1"
        Me.lbl_Anzahl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'T_beenden
        '
        Me.T_beenden.Interval = 2000
        '
        'frm_print
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 144)
        Me.Controls.Add(Me.lbl_Anzahl)
        Me.Controls.Add(Me.btn_plus)
        Me.Controls.Add(Me.btn_Minus)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_print)
        Me.Controls.Add(Me.lbl_info)
        Me.Controls.Add(Me.pb_laden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_print"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Etiketten Drucken"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pb_laden As ProgressBar
    Friend WithEvents lbl_info As Label
    Friend WithEvents btn_print As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_Minus As Button
    Friend WithEvents btn_plus As Button
    Friend WithEvents lbl_Anzahl As Label
    Friend WithEvents T_beenden As Timer
End Class
