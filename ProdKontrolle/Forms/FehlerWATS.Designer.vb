<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FehlerWATS
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PB_Loading = New System.Windows.Forms.PictureBox()
        Me.lbl_Status = New System.Windows.Forms.Label()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Loading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Location = New System.Drawing.Point(12, 12)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Name = "Fehler"
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(485, 266)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        Title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Title1.Name = "Title1"
        Title1.Text = "Anzahl Fehler"
        Title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Title2.Name = "Title2"
        Title2.Text = "Fehlerlabel"
        Me.Chart1.Titles.Add(Title1)
        Me.Chart1.Titles.Add(Title2)
        '
        'PB_Loading
        '
        Me.PB_Loading.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PB_Loading.Location = New System.Drawing.Point(21, 12)
        Me.PB_Loading.Name = "PB_Loading"
        Me.PB_Loading.Size = New System.Drawing.Size(476, 266)
        Me.PB_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PB_Loading.TabIndex = 1
        Me.PB_Loading.TabStop = False
        '
        'lbl_Status
        '
        Me.lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.lbl_Status.Location = New System.Drawing.Point(21, 165)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(476, 25)
        Me.lbl_Status.TabIndex = 2
        Me.lbl_Status.Text = "Status Text"
        Me.lbl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FehlerWATS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(509, 290)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.PB_Loading)
        Me.Controls.Add(Me.Chart1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FehlerWATS"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Loading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents PB_Loading As PictureBox
    Friend WithEvents lbl_Status As Label
End Class
