<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OEEDetails
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.Chart_OEE = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Tbl_StillstandszeitenSummeTableAdapter1 = New ProdKontrolle.DS_OPM_OEETableAdapters.tbl_StillstandszeitenSummeTableAdapter()
        CType(Me.Chart_OEE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart_OEE
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart_OEE.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart_OEE.Legends.Add(Legend1)
        Me.Chart_OEE.Location = New System.Drawing.Point(12, 12)
        Me.Chart_OEE.Name = "Chart_OEE"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart_OEE.Series.Add(Series1)
        Me.Chart_OEE.Size = New System.Drawing.Size(843, 414)
        Me.Chart_OEE.TabIndex = 0
        Me.Chart_OEE.Text = "Chart1"
        Title1.Name = "Title0"
        Me.Chart_OEE.Titles.Add(Title1)
        '
        'Tbl_StillstandszeitenSummeTableAdapter1
        '
        Me.Tbl_StillstandszeitenSummeTableAdapter1.ClearBeforeFill = True
        '
        'OEEDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(867, 438)
        Me.Controls.Add(Me.Chart_OEE)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OEEDetails"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OEE Analyse"
        CType(Me.Chart_OEE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Chart_OEE As DataVisualization.Charting.Chart
    Friend WithEvents Tbl_StillstandszeitenSummeTableAdapter1 As DS_OPM_OEETableAdapters.tbl_StillstandszeitenSummeTableAdapter
End Class
