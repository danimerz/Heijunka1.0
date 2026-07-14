<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_inputBox
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
        Me.btn_Abbruch = New System.Windows.Forms.Button()
        Me.btn_ok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_Abbruch
        '
        Me.btn_Abbruch.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_Abbruch.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Abbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Abbruch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Abbruch.Location = New System.Drawing.Point(215, 88)
        Me.btn_Abbruch.Name = "btn_Abbruch"
        Me.btn_Abbruch.Size = New System.Drawing.Size(111, 31)
        Me.btn_Abbruch.TabIndex = 1
        Me.btn_Abbruch.Text = "Abbrechen"
        Me.btn_Abbruch.UseVisualStyleBackColor = True
        '
        'btn_ok
        '
        Me.btn_ok.Cursor = System.Windows.Forms.Cursors.Default
        Me.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ok.Location = New System.Drawing.Point(332, 88)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(111, 31)
        Me.btn_ok.TabIndex = 2
        Me.btn_ok.Text = "Ok"
        Me.btn_ok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 32)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(431, 50)
        Me.TextBox1.TabIndex = 0
        '
        'frm_inputBox
        '
        Me.AcceptButton = Me.btn_ok
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btn_Abbruch
        Me.ClientSize = New System.Drawing.Size(455, 130)
        Me.ControlBox = False
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_ok)
        Me.Controls.Add(Me.btn_Abbruch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frm_inputBox"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm_inputBox"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_Abbruch As Button
    Friend WithEvents btn_ok As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
End Class
