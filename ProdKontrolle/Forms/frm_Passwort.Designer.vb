<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Passwort
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_passwort = New System.Windows.Forms.TextBox()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(293, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bitte Passwort eingeben:"
        '
        'txt_passwort
        '
        Me.txt_passwort.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.txt_passwort.Location = New System.Drawing.Point(17, 63)
        Me.txt_passwort.Name = "txt_passwort"
        Me.txt_passwort.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_passwort.ShortcutsEnabled = False
        Me.txt_passwort.Size = New System.Drawing.Size(349, 35)
        Me.txt_passwort.TabIndex = 1
        '
        'btn_ok
        '
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_ok.Location = New System.Drawing.Point(372, 19)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(99, 80)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "OK"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'frm_Passwort
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 112)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.txt_passwort)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Passwort"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Passwort"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txt_passwort As TextBox
    Friend WithEvents btn_ok As Button
End Class
