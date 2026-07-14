<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.PB_Grundbild = New System.Windows.Forms.PictureBox()
        Me.p_ap3_1 = New System.Windows.Forms.Panel()
        Me.p_ap3_2 = New System.Windows.Forms.Panel()
        Me.p_ap3_3 = New System.Windows.Forms.Panel()
        Me.p_ap3_4 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.PB_Grundbild, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PB_Grundbild
        '
        Me.PB_Grundbild.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PB_Grundbild.Image = Global.FiFo_Bahn.My.Resources.Resources.FIFO_CEVA_Small1
        Me.PB_Grundbild.Location = New System.Drawing.Point(0, 0)
        Me.PB_Grundbild.Name = "PB_Grundbild"
        Me.PB_Grundbild.Size = New System.Drawing.Size(1069, 624)
        Me.PB_Grundbild.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_Grundbild.TabIndex = 0
        Me.PB_Grundbild.TabStop = False
        '
        'p_ap3_1
        '
        Me.p_ap3_1.Location = New System.Drawing.Point(120, 127)
        Me.p_ap3_1.Name = "p_ap3_1"
        Me.p_ap3_1.Size = New System.Drawing.Size(181, 129)
        Me.p_ap3_1.TabIndex = 1
        '
        'p_ap3_2
        '
        Me.p_ap3_2.Location = New System.Drawing.Point(328, 127)
        Me.p_ap3_2.Name = "p_ap3_2"
        Me.p_ap3_2.Size = New System.Drawing.Size(181, 129)
        Me.p_ap3_2.TabIndex = 2
        '
        'p_ap3_3
        '
        Me.p_ap3_3.Location = New System.Drawing.Point(554, 127)
        Me.p_ap3_3.Name = "p_ap3_3"
        Me.p_ap3_3.Size = New System.Drawing.Size(181, 129)
        Me.p_ap3_3.TabIndex = 3
        '
        'p_ap3_4
        '
        Me.p_ap3_4.Location = New System.Drawing.Point(779, 127)
        Me.p_ap3_4.Name = "p_ap3_4"
        Me.p_ap3_4.Size = New System.Drawing.Size(181, 129)
        Me.p_ap3_4.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(615, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(615, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(718, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(718, 36)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(841, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(119, 23)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Array Default setzen"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(316, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(141, 78)
        Me.TextBox1.TabIndex = 11
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(463, 36)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(93, 23)
        Me.Button6.TabIndex = 12
        Me.Button6.Text = "Array Anzeigen"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1069, 624)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.p_ap3_4)
        Me.Controls.Add(Me.p_ap3_3)
        Me.Controls.Add(Me.p_ap3_2)
        Me.Controls.Add(Me.p_ap3_1)
        Me.Controls.Add(Me.PB_Grundbild)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PB_Grundbild, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PB_Grundbild As PictureBox
    Friend WithEvents p_ap3_1 As Panel
    Friend WithEvents p_ap3_2 As Panel
    Friend WithEvents p_ap3_3 As Panel
    Friend WithEvents p_ap3_4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Timer1 As Timer
End Class
