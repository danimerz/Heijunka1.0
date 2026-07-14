Public Class OEEDetails
    Public OEE_Linie As String
    Public OEE_Name As String
    Public OEE_Datum As String
    Sub New(LineName As String, Datum As String, Linie As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        OEE_Name = LineName
        OEE_Datum = Datum
        OEE_Linie = Linie
    End Sub
    Private Sub OEEDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Daten abrufen und zuweisen
        For Each row As DataRow In Tbl_StillstandszeitenSummeTableAdapter1.GetData(OEE_Name, OEE_Datum).Rows
            Chart_OEE.Series(0).Points.AddXY(row.Item("StatusStufe1"), row.Item("Sum").ToString)
        Next

        'Formtieren
        With Chart_OEE
            .ChartAreas(0).Area3DStyle.Enable3D = True
            .Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie
            .Series(0)("PieLabelStyle") = "outside"
            .Series(0).LegendText = "#VALX (#PERCENT)"
            .Series(0).IsValueShownAsLabel = False
            .Series(0).Label = "#VALX (#VALY sek.)"

            .Titles(0).Text = "OEE Details Linie " & OEE_Linie
            .Titles(0).Font = New Font("Microsoft Sans Serif", 16, FontStyle.Bold)

            .Legends(0).Title = "Legende:"
            .Legends(0).TitleFont = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
            .Legends(0).TitleAlignment = StringAlignment.Near
            .Legends(0).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        End With

        'Farben zuweisen
        For Each dp In Chart_OEE.Series(0).Points
            Select Case dp.AxisLabel
                Case "Prozesszeit"
                    dp.Color = Color.Green
                Case "Kurzstillstand"
                    dp.Color = Color.Black
                Case "Anlagenstörung"
                    dp.Color = Color.Red
                Case "Rüsten"
                    dp.Color = Color.Orange
                Case "Reparatur innerhalb der Linie"
                    dp.Color = Color.OrangeRed
                Case "Pause, Verteilzeit"
                    dp.Color = Color.LightBlue
            End Select
        Next

    End Sub
End Class