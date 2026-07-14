Imports System.ComponentModel
Imports Newtonsoft.Json
Public Class Linie

    Public AP As String
    Public Stat As String
    Private Wats As New Wats
    Dim WithEvents BGW_Hejiunka As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}


#Region "Heijunka Anzeigen"
    Public Class HeijunkaArgument
        'Background Worker Übergabe Argumente
        Public Query As Object
        Public WatsVorhanden As Boolean
        Public Station As String
        Public LineName As String
        Public SMT As Boolean
        Public vc_kont As Boolean


    End Class
    Public Class HeijunkaResults
        'Linien Daten, Resultate aus BGW
        Public Data As EnumerableRowCollection
        Public FAUFStatusDaten As DataTable
        Public FPY As String
        Public Soll As Integer
        Public Ist As Integer
        Public OEE As String
    End Class

    Public Sub New(Linie As String, Station As String)
        AP = Linie
        Stat = Station

    End Sub
    Private Sub BGW_Hejiunka_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_Hejiunka.DoWork
        'Argumente übernehmen und in VAriable Argument Casten
        Dim Argument As HeijunkaArgument = DirectCast(e.Argument, HeijunkaArgument)

        'Linien Resultate, klasse
        Dim result As New HeijunkaResults

        'Soll und ist Variablen initialisieren
        result.Soll = 0
        result.Ist = 0

        'Heijunka Daten in datatable Schreiben
        'Variablen Definieren
        Dim DT As New DataTable
        Dim Column As DataColumn
        Dim row As DataRow

        Dim dat As Date = Now
        Dim datGestern As Date = DateAdd("d", -1, Now)

        'DT für Vcheck Kontrolle
        Dim DT_vCheck As New DataTable

        'Datentable Spalten definieren
#Region "DT Spalten"
        'Spalte Material
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Material"
        DT.Columns.Add(Column)
        'Spalte SAP_Material
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "SAP_Material"
        DT.Columns.Add(Column)
        'Spalte auftragsnummer
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "FAUF"
        DT.Columns.Add(Column)
        'Spalte LinienName
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Linie"
        DT.Columns.Add(Column)
        'Spalte Soll
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Soll"
        DT.Columns.Add(Column)
        'Spalte ist
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Ist"
        DT.Columns.Add(Column)
        'Spalte U
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "U"
        DT.Columns.Add(Column)
        'Spalte Zeit
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Zeit"
        DT.Columns.Add(Column)
        'Spalte Proddatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "ProdDatum"
        DT.Columns.Add(Column)
        'Spalte Proddatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "DateViertel"
        DT.Columns.Add(Column)
        'Spalte Proddatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "DateHalb"
        DT.Columns.Add(Column)
        'Spalte Proddatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "DateDreiViertel"
        DT.Columns.Add(Column)
        'Spalte Proddatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "DateVoll"
        DT.Columns.Add(Column)
        'Spalte FPY
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "fpy"
        DT.Columns.Add(Column)
        'Spalte TotalFail
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "TotalFailed"
        DT.Columns.Add(Column)
        'Spalte Matstatus
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "MatStatus"
        DT.Columns.Add(Column)
        'Spalte ProdKontrolle --> Anzahl Einträge in DB
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Prodkontrolle"
        DT.Columns.Add(Column)
        'Spalte Vorgangsnummer
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Vrg"
        DT.Columns.Add(Column)
        'Spalte PCBA Breite
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "pcba_breite"
        DT.Columns.Add(Column)
        'Spalte Rüstung SMD
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "SMD_Ruestung"
        DT.Columns.Add(Column)
        'Spalte V-Check Kontrolle --> Einträge in DB
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "VC_Kontrolle"
        DT.Columns.Add(Column)
        'Spalte Material in Ausnhameliste
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ausnahme"
        DT.Columns.Add(Column)
        'Spalte Vorgangstext
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "VorgangText"
        DT.Columns.Add(Column)
        'Spalte SMT LP-Nr
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "LPNr"
        DT.Columns.Add(Column)
        'Spalte SAP Systemstatus
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "SystemStatus"
        DT.Columns.Add(Column)
        'Spalte SAP AP
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "SAPAP"
        DT.Columns.Add(Column)
        'Spalte Kommentare
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Kommentar"
        DT.Columns.Add(Column)
#End Region

        'Loop durch Eingangsquery, SAP Export
        Dim i As Integer = 1

        'vorherige fauf nummer zum rausfiltern der doppelten faufs
        Dim FaufOld As String = ""

        'Für jede Zeile in der als Argument übergebenen Query
        For Each r As DataRow In Argument.Query
            row = DT.NewRow()

            Dim DateVirtel As Date
            Dim DateHalb As Date
            Dim DateDreiVirtel As Date
            Dim DateVoll As Date
            Dim ProdDatum As Date

            Dim TotalCount As Integer
            Dim TotalFailed As Integer
            Dim fpy As Double

            'doppelte FAUF rausfiltern.... nur für CEVA Gearbox da im APLA zwei mal der AP vorkommt.....
            If FaufOld = r("Auftrag") Then
                If r("ArbPlatz") = "2276-E10" Or r("ArbPlatz") = "2276-B10" Then
                    Continue For
                Else
                    FaufOld = r("Auftrag")
                End If
            Else
                FaufOld = r("Auftrag")
            End If

            'Wats Daten vorhanden?
            If Argument.WatsVorhanden = False Then
                'Keine WATS Daten vorhanden --> WATS abfrage wird überspungen
                'Report Progress 
                BGW_Hejiunka.ReportProgress(i, "Daten für FAUF " + r("Auftrag") + " werden geladen")
                'Variablen Init
                TotalCount = 0
                DateVirtel = Now
                DateHalb = Now
                DateDreiVirtel = Now
                DateVoll = Now
                ProdDatum = Now
                TotalFailed = 0
                fpy = Math.Round(((TotalCount - TotalFailed) / TotalCount) * 100, 1)
            Else
                'WATS Daten sind vorhanden --> Wats Abfragen
                'Report Progress 
                BGW_Hejiunka.ReportProgress(i, "Daten für FAUF " + r("Auftrag") + " werden aus WATS geladen")

                'Wats Abfrage
                Dim Wats As WatsRueckgabewerte = WATS_Daten(r("Auftrag"), r("Vorgangsmenge").replace(".", ""), 0)
                'Totalstückzahl aus WATS lesen
                TotalCount = Wats.totalPassed
                'Produktionsdatum aus Wats lesen
                DateVirtel = Wats.DateViertel
                'halb erledigt
                DateHalb = Wats.DateHalb
                'dreiviertel erledigt
                DateDreiVirtel = Wats.DateDreivirtel
                'Letztes Gerät
                DateVoll = Wats.DateVoll
                'erstes Gerät
                ProdDatum = Wats.ProdDatum
                'Anzajl Failed aus Wats lesen
                TotalFailed = Wats.failed
                'FPY errechnen für ASN
                fpy = Math.Round(((TotalCount - TotalFailed) / TotalCount) * 100, 1)
            End If



            'überprüfen ob ASN oder SSN angezeigt werden soll

            row("Material") = r("Material")
            row("FAUF") = r("Auftrag")
            row("Soll") = r("Vorgangsmenge").replace(".", "")
            row("Ist") = TotalCount - TotalFailed
            If r("Anwenderstatus") = "UMTE" Then
                row("U") = "U"
            End If
            row("Zeit") = r("FrueStartZeit")
            row("VorgangText") = r("VorgangText")
            row("SystemStatus") = r("SystemStatus")
            row("DateViertel") = DateVirtel
            row("DateHalb") = DateHalb
            row("DateDreiViertel") = DateDreiVirtel
            row("DateVoll") = DateVoll
            row("ProdDatum") = ProdDatum
            row("TotalFailed") = TotalFailed
            row("fpy") = fpy
            row("SAPAP") = r("ArbPlatz")
            row("Vrg") = r("Vorgang")
            DT.Rows.Add(row)

            'Soll und Ist berechnen, resultat an Klasse übergeben, aufsummieren
            result.Soll = result.Soll + r("Vorgangsmenge").replace(".", "")
            result.Ist = result.Ist + TotalCount - TotalFailed

            i = i + 1
        Next
        'Datatable an klasse übergeben
        result.Data = DT.AsEnumerable

        'result klasse übergeben
        e.Result = result
        DT.Dispose()
        DT = Nothing
    End Sub
    Private Sub BGW_Hejiunka_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_Hejiunka.ProgressChanged
        'PB_Status.Value = e.ProgressPercentage
        lbl_Status.Text = e.UserState
    End Sub
    Private Sub BGW_Hejiunka_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_Hejiunka.RunWorkerCompleted
        'DGV füllen
        Dim i As Integer = 0
        'Datenbank "FAUF Status" an lokale Datatable übergeben
        Dim tblFAUFStatus As DataTable = e.Result.FAUFStatusDaten



#Region "Heijunka anzeigen"
        'e.result enhält typisierte Datatable mit Dateninhalt des heijunka 
        For Each r As DataRow In e.Result.Data
            DGV_FAUF.Rows.Add(r("Material")) 'Spalte dient nur der Anzeige

            dgv_FAUF.Rows(i).Cells(1).Value = r("FAUF")
            dgv_FAUF.Rows(i).Cells(2).Value = r("Soll")
            dgv_FAUF.Rows(i).Cells(3).Value = r("Ist")

            i = i + 1
        Next

#End Region
    End Sub
    Public Sub HejiunkaAnzeigen()
        'BGW starten der die Heijunka Daten im DGV anzeigt

        'Datagridview Inhalten löschen
        'DGV_FAUF.Rows.Clear()

        'BGW Starten
        If Not BGW_Hejiunka.IsBusy Then

            'Datatable leeren
            'SAP.DT_Heijunka.Clear()

            'für jeden AP in Array Hejiunka Abfrage aus DS durchführen
            Dim qry = From rw In SAP.DT_SQ00_Import_FAUF
                      Where rw.ArbPlatz Like AP AndAlso
                                   rw.SpatStartDat Like Now
                      Order By rw.FrueStartZeit

            'ergebinise in Datatable speichern
            For Each item In qry
                SAP.DT_Heijunka.AddDT_HeijunkaRow(item.Auftrag, item.Vorgang, item.Material, item.FertS,
                                                                      item.ArbPlatz, item.VorgangText, item.FertS, item.FrueStartZeit,
                                                                      item.SpatStartDat, item.SpatStartzeit, item.Vorgangsmenge, item.RueckGutMenge,
                                                                      item.Ausschuss, item.Anwenderstatus, item.SystemStatus)
            Next

            'Sind Datensätze vorhanden? 
            If qry.Count > 0 Then
                'BGW Starten (LINQ Abfrage und WatsdatenVorhanden? übergeben)
                BGW_Hejiunka.RunWorkerAsync(New HeijunkaArgument With {.Query = qry, .WatsVorhanden = True, .Station = Stat, .LineName = "Dummy", .SMT = False, .vc_kont = False})
            Else
                'es sind keine Daten vorhanden

            End If

        End If

    End Sub
#End Region


#Region "WATS Funktionen"

    ''' <summary>
    ''' WATS DATEN 
    ''' </summary>
    Private Function WATS_Daten(FAUF As String, Soll As Integer, Durchgang As Integer) As WatsRueckgabewerte
        'Wats Daten in Klasse übergeben
        Dim w As New WatsRueckgabewerte
        'API Abfrage, Watsdaten enthält json object
        Dim WatsInhalt = JsonConvert.DeserializeObject(Of List(Of JSON_data))(Wats.GetSTK(FAUF, Nothing, Nothing, "", Durchgang))
        'LINQ Query Sortierung nach Datum!!!
        Dim query =
        From WatsData In WatsInhalt
        Order By WatsData.dateTimeUtc

        Dim Fails As Integer = 0

        'Schlaufe für ist Stückzahl
        w.totalPassed = 0

        'Zähler Variable
        Dim i As Integer = 0
        'Stückzahlen für Datumsbestimmung
        Dim viertel As Integer = CInt(Soll / 4 * 1)
        Dim halb As Integer = CInt(Soll / 4 * 2)
        Dim dreiviertel As Integer = CInt(Soll / 4 * 3)
        Dim voll As Integer = CInt(Soll / 4 * 4)

        For Each WatsData In query

            i = i + 1
            'Stückzahl berechnen
            w.totalPassed = w.totalPassed + 1
            If WatsData.status = "Failed" Then
                'w.totalPassed = w.totalPassed - 1
                Fails = Fails + 1
            End If
            'Datum Produktion (in der schlaufe, da erstes gerät an letzter stelle im Object "Watsdaten" ist)
            'Wird für die Farbbestimmung im Hejiunka benötigt
            Select Case i
                Case viertel
                    w.DateViertel = WatsData.dateTimeUtc
                Case halb
                    w.DateHalb = WatsData.dateTimeUtc
                Case dreiviertel
                    w.DateDreivirtel = WatsData.dateTimeUtc
                Case voll
                    w.DateVoll = WatsData.dateTimeUtc
            End Select
            w.ProdDatum = WatsData.dateTimeUtc
        Next

        'FPY rechnen und Runden
        w.failed = Fails
        Return w
    End Function
    Private Function FPY_Aktuell(DateFrom As String, DateTo As String, Station As String, Durchgang As Integer) As WatsRueckgabewerte
        'Wats Daten in Klasse übergeben
        Dim w As New WatsRueckgabewerte
        'API Abfrage, Watsdaten enthält json object
        Dim WatsInhalt = JsonConvert.DeserializeObject(Of List(Of JSON_data))(Wats.GetSTK("", DateFrom, DateTo, Station, Durchgang))
        'LINQ Query Sortierung nach Datum!!!
        Dim query =
        From WatsData In WatsInhalt
        Order By WatsData.dateTimeUtc

        'Schlaufe für Anzahl Passed und Anzahl Failed
        w.totalPassed = 0
        w.failed = 0


        For Each WatsData In query
            'Stückzahl berechnen
            w.totalPassed = w.totalPassed + 1
            If WatsData.status = "Failed" Then
                'w.totalPassed = w.totalPassed - 1
                w.failed = w.failed + 1
            End If
        Next
        Return w
    End Function
    Public Class JSON_data
        Public status As String
        Public id As String
        Public serialNumber As String
        Public revision As String
        Public stationName As String
        Public partNumber As String
        Public batchNumber As String
        Public dateTimeUtc As Date
    End Class
    Private Class WatsRueckgabewerte
        'Rückgabe Klasse für werte aus WATS
        Public totalPassed As Integer
        Public DateViertel As Date
        Public DateHalb As Date
        Public DateDreivirtel As Date
        Public DateVoll As Date
        Public failed As Double
        Public ProdDatum As Date
    End Class

    Private Sub Linie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HejiunkaAnzeigen()
    End Sub
#End Region
End Class
