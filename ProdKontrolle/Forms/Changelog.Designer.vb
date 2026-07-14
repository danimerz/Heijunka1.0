<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Changelog
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
        Me.txt_ChangeLog = New System.Windows.Forms.TextBox()
        Me.btn_OK = New System.Windows.Forms.Button()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_Fokus = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_ChangeLog
        '
        Me.txt_ChangeLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_ChangeLog.Location = New System.Drawing.Point(12, 65)
        Me.txt_ChangeLog.Multiline = True
        Me.txt_ChangeLog.Name = "txt_ChangeLog"
        Me.txt_ChangeLog.ReadOnly = True
        Me.txt_ChangeLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txt_ChangeLog.Size = New System.Drawing.Size(468, 305)
        Me.txt_ChangeLog.TabIndex = 0
        '
        'btn_OK
        '
        Me.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OK.Location = New System.Drawing.Point(12, 376)
        Me.btn_OK.Name = "btn_OK"
        Me.btn_OK.Size = New System.Drawing.Size(468, 64)
        Me.btn_OK.TabIndex = 1
        Me.btn_OK.Text = "OK"
        Me.btn_OK.UseVisualStyleBackColor = True
        '
        'lbl_Version
        '
        Me.lbl_Version.AutoSize = True
        Me.lbl_Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.25!)
        Me.lbl_Version.Location = New System.Drawing.Point(7, 21)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(209, 26)
        Me.lbl_Version.TabIndex = 2
        Me.lbl_Version.Text = "Changelog Version: "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProdKontrolle.My.Resources.Resources._1200px_Gtk_dialog_info_svg
        Me.PictureBox1.Location = New System.Drawing.Point(420, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'lbl_Fokus
        '
        Me.lbl_Fokus.AutoSize = True
        Me.lbl_Fokus.Location = New System.Drawing.Point(273, 29)
        Me.lbl_Fokus.Name = "lbl_Fokus"
        Me.lbl_Fokus.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Fokus.TabIndex = 4
        Me.lbl_Fokus.Text = "Label1"
        '
        'Changelog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 453)
        Me.Controls.Add(Me.lbl_Fokus)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_Version)
        Me.Controls.Add(Me.btn_OK)
        Me.Controls.Add(Me.txt_ChangeLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Changelog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Information"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_ChangeLog As TextBox
    Friend WithEvents btn_OK As Button
    Friend WithEvents lbl_Version As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lbl_Fokus As Label
End Class
