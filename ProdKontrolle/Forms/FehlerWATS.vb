Imports System.ComponentModel
Imports Newtonsoft.Json
Imports <xmlns="http://wats.virinco.com/schemas/WATS/Report/wsxf">

Public Class FehlerWATS
    'Auftragsnummer übernehmen
    Public Auftragsnummer As String
    'Wats Klasse deklarieren
    Private WATS As New Wats
    'Backgroundworker deklarieren
    Dim WithEvents BGW As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}

    Public Class JSON_data
        'Daten aus WATS
        Public status As String
        Public id As String
        Public serialNumber As String
        Public revision As String
        Public stationName As String
        Public partNumber As String
        Public batchNumber As String
        Public dateTimeUtc As Date
    End Class
    Public Sub New(FAUF As String, Formname As String)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Auftragsnummer = FAUF
        Me.Text = Formname
    End Sub
    Private Sub FehlerWATS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not BGW.IsBusy Then
            BGW.RunWorkerAsync(Auftragsnummer)
        End If
    End Sub
    Private Sub BGW_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW.DoWork
        'API Abfrage, Watsdaten enthält json object
        BGW.ReportProgress(1, "WATS Daten abfragen")
        Dim WatsInhalt = JsonConvert.DeserializeObject(Of List(Of JSON_data))(WATS.Wats_PostAsync(My.Settings.WatsUutReportPath, e.Argument, Nothing, Nothing, "", 1).GetAwaiter.GetResult)
        'LINQ Query Sortierung nach Datum!!!
        Dim query =
        From WatsData In WatsInhalt
        Order By WatsData.dateTimeUtc

        Dim DT As New DataTable
        Dim OutputTable As New DataTable
        Dim row As DataRow

        'Definiert Temporäre Datentable
        DT.Columns.Add(New DataColumn("Fehler", System.Type.GetType("System.String")))
        DT.Columns.Add(New DataColumn("Text", System.Type.GetType("System.String")))
        DT.Columns.Add(New DataColumn("Anzahl", System.Type.GetType("System.Int16")))

        'Definiert Output für Chart(Fehler werden zusammengefasst)
        OutputTable.Columns.Add(New DataColumn("Fehler", System.Type.GetType("System.String")))
        OutputTable.Columns.Add(New DataColumn("Text", System.Type.GetType("System.String")))
        OutputTable.Columns.Add(New DataColumn("Anzahl", System.Type.GetType("System.Int16")))


        'Zähler Variable
        Dim i As Integer = 0

        'Nach Failed Geräte suchen und Feheler aus Report auslesen
        For Each WatsData In query
            BGW.ReportProgress(1, "Schlechte Geräte suchen, Seriennummer: " & WatsData.serialNumber & " wird durchsucht")
            If WatsData.status = "Failed" Then
                Dim XML_Doc = System.Xml.Linq.XDocument.Parse(WATS.WATS_GetAsync(My.Settings.WatsReportXmlPath & WatsData.id).GetAwaiter.GetResult.ToString)
                Dim Steps = From Reports In XML_Doc...<Step>
                            Select Reports

                For Each S In Steps
                    If (S.Attribute("Status").Value = "Failed" Or S.Attribute("Status").Value = "Error") And S.Attribute("Name").Value <> "MainSequence Callback" Then
                        row = DT.NewRow
                        row("Fehler") = S.Attribute("Name").Value.ToString
                        row("Text") = S.<ReportText>.Value.ToString
                        row("Anzahl") = 1
                        DT.Rows.Add(row)
                    End If
                Next
            End If
        Next


        ' Fehler zusammenfassen (Anzahl)
        BGW.ReportProgress(1, "Fehler zusammentragen")
        Dim gruppe = From r In DT.AsEnumerable
                     Group r By Label = r.Field(Of String)("Fehler") Into Group
                     Select Label = New With {.Name = Label, .Count = Group.Count(), .Text = Text}
                     Order By Label.Count Descending
        For Each r In gruppe
            row = OutputTable.NewRow
            row("Fehler") = r.Name
            row("Anzahl") = r.Count
            row("Text") = r.Text
            OutputTable.Rows.Add(row)
        Next
        BGW.ReportProgress(1, "Fertig")
        e.Result = OutputTable
    End Sub
    Private Sub BGW_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW.RunWorkerCompleted
        lbl_Status.Visible = False
        Chart1.Series("Fehler").XValueMember = "Fehler"
        Chart1.Series("Fehler").YValueMembers = "Anzahl"
        Chart1.DataSource = Nothing
        Chart1.DataSource = e.Result
        Chart1.Invalidate()
        PB_Loading.Visible = False
    End Sub
    Private Sub BGW_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW.ProgressChanged
        lbl_Status.Text = e.UserState
    End Sub
End Class