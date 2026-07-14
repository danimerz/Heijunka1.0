<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_Stueckliste
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LV_Stuli = New System.Windows.Forms.ListView()
        Me.cms_details = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GrünMarkierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusschussBuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FehlmaterialMeldenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cms_details.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 29)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Label1"
        '
        'LV_Stuli
        '
        Me.LV_Stuli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LV_Stuli.ContextMenuStrip = Me.cms_details
        Me.LV_Stuli.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.LV_Stuli.FullRowSelect = True
        Me.LV_Stuli.HideSelection = False
        Me.LV_Stuli.Location = New System.Drawing.Point(0, 72)
        Me.LV_Stuli.MultiSelect = False
        Me.LV_Stuli.Name = "LV_Stuli"
        Me.LV_Stuli.Size = New System.Drawing.Size(1321, 604)
        Me.LV_Stuli.TabIndex = 15
        Me.LV_Stuli.UseCompatibleStateImageBehavior = False
        '
        'cms_details
        '
        Me.cms_details.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.cms_details.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrünMarkierenToolStripMenuItem, Me.AusschussBuchenToolStripMenuItem, Me.FehlmaterialMeldenToolStripMenuItem})
        Me.cms_details.Name = "cms_details"
        Me.cms_details.Size = New System.Drawing.Size(329, 134)
        '
        'GrünMarkierenToolStripMenuItem
        '
        Me.GrünMarkierenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.erledigt
        Me.GrünMarkierenToolStripMenuItem.Name = "GrünMarkierenToolStripMenuItem"
        Me.GrünMarkierenToolStripMenuItem.Size = New System.Drawing.Size(328, 36)
        Me.GrünMarkierenToolStripMenuItem.Text = "erledigt setzten"
        '
        'AusschussBuchenToolStripMenuItem
        '
        Me.AusschussBuchenToolStripMenuItem.Enabled = False
        Me.AusschussBuchenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.stuli
        Me.AusschussBuchenToolStripMenuItem.Name = "AusschussBuchenToolStripMenuItem"
        Me.AusschussBuchenToolStripMenuItem.Size = New System.Drawing.Size(328, 36)
        Me.AusschussBuchenToolStripMenuItem.Text = "Ausschuss buchen"
        '
        'FehlmaterialMeldenToolStripMenuItem
        '
        Me.FehlmaterialMeldenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.list1
        Me.FehlmaterialMeldenToolStripMenuItem.Name = "FehlmaterialMeldenToolStripMenuItem"
        Me.FehlmaterialMeldenToolStripMenuItem.Size = New System.Drawing.Size(328, 36)
        Me.FehlmaterialMeldenToolStripMenuItem.Text = "Fehlmaterial eintragen"
        '
        'frm_Stueckliste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1321, 688)
        Me.Controls.Add(Me.LV_Stuli)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Stueckliste"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Stückliste aktueller Auftrag"
        Me.TopMost = True
        Me.cms_details.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents LV_Stuli As ListView
    Friend WithEvents cms_details As ContextMenuStrip
    Friend WithEvents AusschussBuchenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FehlmaterialMeldenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GrünMarkierenToolStripMenuItem As ToolStripMenuItem
End Class
