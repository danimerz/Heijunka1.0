Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports ProdKontrolle.DS_ProdKontrolleTableAdapters
Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.Data.SqlClient
Imports ZXing
Imports Org.BouncyCastle
Imports MQTTnet
Imports ProdKontrolle.DS_IncidentTableAdapters
Imports Newtonsoft
Imports uPLibrary.Networking.M2Mqtt
Imports uPLibrary.Networking.M2Mqtt.Messages
Imports ProdKontrolle.ProgrammübersichtDataSetTableAdapters
Imports System.Threading

Public Class Form1

#Region "Variablen Deklaration"
    Dim mqClient As MqttClient
    ' Wurde Aktuallisieren Gedrückt?
    Public AktualisierungPressed As Boolean = False
    Public DropdownChange As String = My.Settings.Linie
    Public FirstStart As Boolean = True
    Public WatsCheck As Boolean = True
    Public WatsVerfuegbar As Boolean = True
    'Form Closing überprüfen Wenn True wird daas Form geschlossen
    Private _formclose As Boolean = False
    'Aktive Zeile und Aktive Spalte von DGV Speichern
    Private _column As Integer
    Private _row As Integer
    'Teilrückmeldung Trotz aktiver v-Check Kontrolle
    Private _teilrueckmeldung As Boolean = False
    'MQTT Klasse deklarieren
    Private WithEvents mqtt As New mqtt
    'WATS Klasse deklarieren
    Private Wats As New Wats
    'SAP XML Klasse deklarieren
    Private SAP_XML As New SAP_XML
    'Zeitmessung für eine komplette Aktualisierung (Klick auf "Aktualisieren" bis DGV fertig befüllt)
    Private aktualisierungStopwatch As Stopwatch
    'Update Klasse einbinden
    Private UpdateHandler As New UpdateHandler
    'Ini Klasse einbinden
    Private ini_Autostart As New iniHandling(My.Settings.PfadAutoStartIni)
    Private ini_Station As New iniHandling(My.Settings.PfadStationIni)
    'Globale Funktionen Klasse einbinden
    Private globalFunction As New GlobaleFunktionen
    'Logging Deklarieren
    Private log As New logging
    'Backgroundworker Deklarireren
    Dim WithEvents BGW_HejiunkaImport As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Dim WithEvents BGW_Hejiunka As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Dim WithEvents BGW_CloseForm As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Dim WithEvents BGW_CheckUpdate As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}


    Public Enum DGV_Column
        'Definiert die Spalten des DGV und deren Indexe
        'Wenn eine neue Spalte im DGV eingefügt wird muss sie hier ergänzt werden und
        'die anderen spalten demensprechend hochnummeriert werden. sofern sie nicht am
        'ende angezeigt werden soll
        Material = 0
        Gearbox = 1
        LPNR = 2
        LPOK = 3
        vrgText = 4
        Auftrag = 5
        Linie = 6
        Soll = 7
        Ist = 8
        Ist_SAP = 9
        Zeit = 10
        Vorgabezeit = 11
        EndDatum = 12
        R = 13
        U = 14
        Status = 15
        ProdDatum = 16
        FPY = 17
        TF = 18
        Vrg = 19
        LPBreite = 20
        SAPMAT = 21
        VCheck = 22
        ausnahme = 23
        MatPPStatus = 24
        Fixruestung = 25
        SystemStatus = 26
        SAPAP = 27
        KommentarSpalte = 28
        Lagerort = 29
        AmTagBestücken = 30

    End Enum

    Public Property TeilRueckmeldungen
        Set(value)
            _teilrueckmeldung = value
        End Set
        Get
            Return _teilrueckmeldung
        End Get
    End Property
    Public Property FormClose As Boolean
        Set(value As Boolean)
            _formclose = value
        End Set
        Get
            Return _formclose
        End Get
    End Property
    Public Property Col As Integer
        Set(value As Integer)
            _column = value
        End Set
        Get
            Return _column
        End Get
    End Property
    Public Property Row As Integer
        Set(value As Integer)
            _row = value
        End Set
        Get
            Return _row
        End Get
    End Property

#End Region

#Region "SAP Import"
    Friend Structure SAP_Fields
        Public Property FAUF As String
        Public Property Vorgang As String
        Public Property Material As String
        Public Property FertS As String
        Public Property ArbPlatz As String
        Public Property Vorgangtext As String
        Public Property FSD As String
        Public Property FSZ As String
        Public Property SSD As String
        Public Property SSZ As String
        Public Property VrgMenge As String
        Public Property gutMenge As String
        Public Property Ausschuss As String
        Public Property AnwenderStatus As String
        Public Property SystemStatus As String

    End Structure

    Sub SAP_Import()
        'Timer Wats Refresher Stoppen
        T_WatsRefresh.Stop()
        T_CheckSAPimport.Stop()
        'Status an MQTT senden
        mqtt_Send_Status("SAP Daten laden")
        'Panel1, Ladebildschrm einbleden
        Panel1.Visible = True
        lbl_Laden.Text = "SAP Daten werden geladen..." & vbCrLf & "Bitte warten"
        PB_laden.Image = My.Resources.SAP
        'Controlls ausblenden
        DTP_Datum.Enabled = False
        ComboBox1.Enabled = False
        btn_Anzeigen.Enabled = False
        btn_MenuAuftrag.Enabled = False

        'Datum und Uhrzeit der Download datei in Settings Speichern
        My.Settings.letzerSAPimport = System.IO.File.GetLastWriteTime(My.Settings.ExportPfadRemote)

        'BGW Starten
        If Not BGW_HejiunkaImport.IsBusy Then
            PB_Status.Value = 0
            PB_Status.Maximum = 4
            BGW_HejiunkaImport.RunWorkerAsync()
        End If
    End Sub
    Private Sub DownloadSsnAsnTable()
        If IO.File.Exists("\\ch021093\data\CommonData\MatchTables\SSN-ASN\SSN-ASN_MatchTable.mdb") Then
            'BGW_HejiunkaImport.ReportProgress(2, "ASN SSN Matchtable kopiert")
            If Not IO.File.Exists(My.Settings.ExportPfadLocal) Then
                My.Computer.FileSystem.CreateDirectory("C:\Temp")
            End If
            'Datei kopieren
            IO.File.Copy("\\ch021093\data\CommonData\MatchTables\SSN-ASN\SSN-ASN_MatchTable.mdb", "C:\Temp\SSN-ASN_MatchTable.mdb", True)
        End If
    End Sub
    Private Sub ImportHeijunkaSQ00()
        'Import der Hejunka Daten

        'Prüfen ob Export Datei in Verzeichniss liegt
        If IO.File.Exists(My.Settings.ExportPfadRemote) Then
            'BGW_HejiunkaImport.ReportProgress(3, "SAP Exportdatei wird kopiert")
            'Datei von Remotepfad in das konfigurierte lokale Verzeichnis kopieren (aus dem Zielpfad
            'abgeleitet statt hartcodiert - sonst würde eine Änderung von ExportPfadLocal dazu führen,
            'dass hier ein falsches/nicht existierendes Verzeichnis erwartet wird)
            Dim lokalesVerzeichnis As String = IO.Path.GetDirectoryName(My.Settings.ExportPfadLocal)
            If Not IO.Directory.Exists(lokalesVerzeichnis) Then
                IO.Directory.CreateDirectory(lokalesVerzeichnis)
            End If
            'Datei kopieren
            IO.File.Copy(My.Settings.ExportPfadRemote, My.Settings.ExportPfadLocal, True)

            'Export-Datei einlesen; die ersten 6 Kopfzeilen werden beim Parsen übersprungen, statt die
            'Datei zusätzlich komplett neu zu schreiben (spart einen kompletten Lese- und Schreibvorgang
            'bei grossen Exportdateien)
            'BGW_HejiunkaImport.ReportProgress(4, "Exportdatei wird formatiert")
            Dim sInput() As String = IO.File.ReadAllLines(My.Settings.ExportPfadLocal, Encoding.Default)

            'Zunächst in eine temporäre Tabelle parsen. Erst wenn das Ergebnis plausibel ist (mind. eine
            'Zeile), wird die eigentliche Tabelle geleert und ersetzt - so überschreibt eine leere/
            'unvollständige Exportdatei (z.B. weil SAP sie noch schreibt oder das Kopieren fehlschlägt)
            'nicht die bisherigen, gültigen Daten mit einer leeren Tabelle.
            Dim tempTable As New SAP.DT_SQ00_Import_FAUFDataTable()
            Dim uebersprungeneZeilen As Integer = 0

            For zeilenNr As Integer = 6 To sInput.Length - 1
                Dim sZeile As String = sInput(zeilenNr)
                Try
                    Dim record() As String = sZeile.Split(vbTab)
                    tempTable.AddDT_SQ00_Import_FAUFRow(record(1), record(2), record(3), record(4),
                                                         record(5), record(6), record(7), record(8),
                                                         record(9), record(10), record(11), record(13),
                                                         record(15), record(16), record(17))
                Catch ex As Exception
                    'Einzelne fehlerhafte Zeile (z.B. zu wenige Spalten) überspringen statt den
                    'kompletten Import abzubrechen
                    uebersprungeneZeilen += 1
                    log.WriteLog(Date.Now, "", "", "", $"SAP-Import: Zeile {zeilenNr + 1} übersprungen ({ex.Message}): {sZeile}")
                End Try
            Next

            If uebersprungeneZeilen > 0 Then
                log.WriteLog(Date.Now, "", "", "", $"SAP-Import: {uebersprungeneZeilen} fehlerhafte Zeile(n) übersprungen, {tempTable.Rows.Count} Zeile(n) erfolgreich geparst")
            End If

            If tempTable.Rows.Count > 0 Then
                Try
                    SAP.DT_SQ00_Import_FAUF.Clear()
                Catch ex As Exception
                    log.WriteLog(Date.Now, "", "", "", $"SAP-Import: Leeren der bisherigen Tabelle fehlgeschlagen: {ex.Message}")
                End Try
                SAP.DT_SQ00_Import_FAUF.Merge(tempTable)
            Else
                log.WriteLog(Date.Now, "", "", "", "SAP-Import: 0 Zeilen geparst - bisherige Daten werden NICHT überschrieben")
            End If
        End If
    End Sub
    Private Sub BGW_HejiunkaImport_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_HejiunkaImport.DoWork

        'Download der SSN Match Table DB
        BGW_HejiunkaImport.ReportProgress(2, "ASN SSN Matchtable kopiert")
        DownloadSsnAsnTable()

        'Heijunkja Import
        BGW_HejiunkaImport.ReportProgress(3, "SAP Exportdatei wird Importiert")
        ImportHeijunkaSQ00()
        BGW_HejiunkaImport.ReportProgress(3, "SAP Exportdatei erfolgreich Importiert")

    End Sub
    Private Sub BGW_HejiunkaImport_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_HejiunkaImport.ProgressChanged
        PB_Status.Value = e.ProgressPercentage
        lbl_Status.Text = e.UserState
    End Sub
    Private Sub BGW_HejiunkaImport_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_HejiunkaImport.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            log.WriteLog(Date.Now, "", "", "", $"SAP Import Fehler: {e.Error.Message} | {e.Error.StackTrace}")
            lbl_Status.Text = "SAP Import fehlgeschlagen"
            Panel1.Visible = False
            DTP_Datum.Enabled = True
            ComboBox1.Enabled = True
            btn_Anzeigen.Enabled = True
            Exit Sub
        End If

        'Import der SAP Daten abgeschlossen

        'Status auf Done setzten
        lbl_Status.Text = "Done"
        mqtt_Send_Status("Bereit")
        'Panel1, Ladebildschirm ausblenden
        Panel1.Visible = False
        'Controlls einbleden
        DTP_Datum.Enabled = True
        ComboBox1.Enabled = True
        btn_Anzeigen.Enabled = True
        'Titel Text Schreiben
        Me.Text = globalFunction.GetFormTitle
        'Daten über MQTT senden
        mqtt_Send_SapStatus()
        'Hejunka für ausgewählte Linie laden
        HejiunkaAnzeigen()

    End Sub


#End Region

#Region "MQTT Incident"

    Sub mqttIncidentInit()
        mqClient = New MqttClient(My.Settings.incidentMqtt)
        mqClient.Connect("Testing", "MFZUG", "6300-Zug")
        If mqClient.IsConnected Then
            AddHandler mqClient.MqttMsgPublishReceived, AddressOf MqttMsgReceived
            Dim msgbase(2) As Byte
            Dim Tobic(1) As String
            Tobic(1) = "eq_incident/JSON/v1/Test"
            msgbase(1) = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE
            msgbase(2) = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE
            mqClient.Subscribe(Tobic, msgbase)

        End If
    End Sub

    Private Sub MqttMsgReceived(sender As Object, e As MqttMsgPublishEventArgs)
        Dim Topic As String = e.Topic
        Dim Value As String = Encoding.UTF8.GetString(e.Message)

        Debug.WriteLine(Value)
    End Sub

#End Region

#Region "MQTT"
    Private Sub mqtt_init()
        Try
            Dim Computername As String = System.Environment.MachineName
            mqtt.mmqt_start(Computername, My.Settings.MQTT_Server_IP, "MFZUG", "6300-Zug")
        Catch ex As Exception
        End Try
    End Sub
    Private Async Sub mqtt_Send_Startup()
        If mqtt.ConnectionState = True Then
            Dim Computername As String = System.Environment.MachineName
            Dim Username As String = System.Environment.UserName
            Dim Topic As String = "Heijunka/" & Computername
            Await mqtt.Publish(Topic & "/Computername", Computername)
            Await mqtt.Publish(Topic & "/Username", Username)
            Await mqtt.Publish(Topic & "/SW-Version", globalFunction.GetSwVersion)
            Await mqtt.Publish(Topic & "/Status", "online")
            Await mqtt.Publish(Topic & "/LastSeen", Now.ToString)
        End If
    End Sub
    Private Async Sub mqtt_Send_SapStatus()
        If mqtt.ConnectionState = True Then
            Dim Computername As String = System.Environment.MachineName
            Dim Topic As String = "Heijunka/" & Computername
            Await mqtt.Publish(Topic & "/SAP-Version", globalFunction.GetSAPVersion)
            Await mqtt.Publish(Topic & "/LastSeen", Now.ToString)
        End If
    End Sub
    Private Async Sub mqtt_close()
        If mqtt.ConnectionState = True Then
            Dim Computername As String = System.Environment.MachineName
            Dim Topic As String = "Heijunka/" & Computername
            Await mqtt.Publish(Topic & "/Status", "offline")
            Await mqtt.Publish(Topic & "/LastSeen", Now.ToString)
        End If
    End Sub
    Private Async Sub mqtt_Send_Status(status As String)
        If mqtt.ConnectionState = True Then
            Dim Computername As String = System.Environment.MachineName
            Dim Topic As String = "Heijunka/" & Computername
            Await mqtt.Publish(Topic & "/Status1", status)
            Await mqtt.Publish(Topic & "/LastSeen", Now.ToString)
        End If
    End Sub
    Private Async Sub mqtt_Send_Linie(Linie As String)
        If mqtt.ConnectionState = True Then
            Dim Computername As String = System.Environment.MachineName
            Dim Topic As String = "Heijunka/" & Computername
            Await mqtt.Publish(Topic & "/Linie", Linie)
            Await mqtt.Publish(Topic & "/LastSeen", Now.ToString)
        End If
    End Sub
#End Region

#Region "FormLoad, Buttons, Dropdowns, usw"
    ''' <summary>
    ''' Form Load, Buttons, usw
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Height = My.Settings.FormHight
        Me.Width = My.Settings.FormWith
        Me.CenterToScreen()
        Me.Text = globalFunction.GetFormTitle
        'mqtt_init()
        'mqtt_Send_Startup()
        Init()
        'mqttIncidentInit()


    End Sub
    Private Sub Init()
        'Me.Tbl_ProdKontrolleTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_ProdKontrolle)

        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        'SQL Verfügbarkeit testen
        Console.WriteLine(globalFunction.sqlAvailable(My.Settings.HeijunkaConnectionString).ToString)
        Console.WriteLine(globalFunction.sqlAvailable(My.Settings.OPM_OEEConnectionString).ToString)

        'DGV Spaltenhöhe bestimmen
        DGV_FAUF.RowTemplate.Height = My.Settings.DGV_Höhe

        'ComboBox füllen
        Me.Tbl_LinieTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_Linie)

        'Linien Voreinstellung abrufen oder setzten
        If My.Settings.Linie = "" Then
            Dim LinieAuswaehlen As New LinieAuswaehlen
            LinieAuswaehlen.ShowDialog()
            ComboBox1.Text = My.Settings.Linie
        Else
            ComboBox1.Text = My.Settings.Linie
        End If
        'Datum setzen
        DTP_Datum.Value = Now.Date

        'Linie an MQTT übergeben
        mqtt_Send_Linie(ComboBox1.Text)

        'Kontext Menu an Datagridview DGV_FAUF zuweisen
        DGV_FAUF.ContextMenuStrip = CMS_DGV_FAUF

        'Farben an Datum zuweisen
        lbl_Menu_Wochentag.Text = Now.ToString("dddd", New CultureInfo("de-DE")) & " " & Now.ToShortDateString
        lbl_Menu_Wochentag.ForeColor = FarbCodeTag(Now).BackColor

        'Show Changelog
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            If My.Application.Deployment.IsFirstRun Then
                Dim ChangeForm As New Changelog
                ChangeForm.ShowDialog()
            End If
        End If

        SAP_Import()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_Anzeigen.Click
        'Ruft Sub Hejiunka Anzeigen auf
        HejiunkaAnzeigen()


    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Datagridview inhalt löschen
        DGV_FAUF.Rows.Clear()
        'WATS Refresher Stoppen
        T_WatsRefresh.Stop()
        'Textfelder leeren Soll/Ist
        lbl_Ist.Text = "0"
        lbl_Soll.Text = "Soll: 0"
        lbl_FPY.Text = "FPY: 0%"
        lbl_oee.Text = "OEE: 0%"
        lbl_RS_DCN.Text = "0stk"
        lbl_RS_BG.Text = "0stk"
        lbl_Maschine_vz.Text = "0h"
        lbl_Pers_vz.Text = "0h"
        'Linie an MQTT übergeben
        If ComboBox1.SelectedIndex = -1 Then
            mqtt_Send_Linie("")
        Else
            mqtt_Send_Linie(ComboBox1.Text)
        End If

    End Sub
    Private Sub DGV_FAUF_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_FAUF.CellDoubleClick
        Dim Auftrag As String = DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.Auftrag).Value

        Select Case Col
            ' Doppelklick auf FPY Spallte öffnet deatilansicht der Fehler
            Case DGV_Column.FPY
                FehlerlabelAuftrag()

            ' Doppelkick auf Rüstung ermöglicht die eingabe einer neuen Rüstung
            Case DGV_Column.Fixruestung
                Dim RüstNr As String = InputBox("Bitte Rüstnummer eingeben:", "Rüstungsnummer eingeben")
                If Not RüstNr = "" Then
                    DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.Fixruestung).Value = RüstNr
                    Tbl_SMT_RuestungTableAdapter.InsertQuery(Auftrag, RüstNr)
                End If

            ' Doppelkick auf Kommentar ermöglicht die eingabe eines neuen Kommentar
            Case DGV_Column.KommentarSpalte
                Dim tbl_KommentarTableAdapter As New tbl_KommentarTableAdapter

                'Kommentare für FAUF suchen - nur die Zeilen dieses Auftrags statt der kompletten Tabelle
                Dim qry = From rw In globalFunction.GetKommentarByFAUF(Auftrag)

                Dim Comment As String = ""
                If qry.Count > 0 Then
                    Dim bestehenderKommentar As String = DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.KommentarSpalte).Value
                    Using dlg As New frm_inputBox("Kommentar eintragen", bestehenderKommentar, "Bitte geben Sie einen Kommentar ein:")
                        If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then
                            Return
                        End If
                        Comment = dlg.TextBox1.Text
                        If Comment = "" Then
                            Return
                        Else
                            tbl_KommentarTableAdapter.UpdateQuery(Comment, Date.Now, Auftrag)
                        End If
                    End Using
                Else
                    Using dlg As New frm_inputBox("Kommentar eintragen", "", "Bitte geben Sie einen Kommentar ein:")
                        If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then
                            Return
                        End If
                        Comment = dlg.TextBox1.Text
                        If Comment = "" Then
                            Return
                        Else
                            tbl_KommentarTableAdapter.Insert(Auftrag, Comment, Date.Now)
                        End If
                    End Using
                End If
                DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.KommentarSpalte).Value = Comment
        End Select
    End Sub
    Private Sub DGV_FAUF_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_FAUF.CellClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        'Col und Row in Public Property Speichern
        Col = e.ColumnIndex
        Row = e.RowIndex
        btn_MenuAuftrag.Enabled = True
        Dim ausnahme As String = DGV_FAUF(DGV_Column.ausnahme, Row).Value

        Dim InfoArray() As String = Nothing

        If ausnahme = "True" Or My.Settings.G_LinieWats = False Then
            ToolStripMenuItemFertig.Visible = True
            btn_Menu_FAUF_Beenden.Visible = True
            AuftragZurücknehmenToolStripMenuItem.Visible = True
            AuftragZurücknehmenToolStripMenuItem1.Visible = True
        Else
            ToolStripMenuItemFertig.Visible = False
            btn_Menu_FAUF_Beenden.Visible = False
            AuftragZurücknehmenToolStripMenuItem.Visible = False
            AuftragZurücknehmenToolStripMenuItem1.Visible = False
        End If

        Select Case DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor
            Case Color.DarkRed
                lbl_info.Text = "ACHTUNG! Änderung geplant! klicken öffnet die Detailansicht!"

                lbl_info.ForeColor = Color.DarkRed
                lbl_info.Font = New Font("Segoe UI", 16)
            Case Color.Red
                'Nur die offenen Einträge dieses Auftrags/Vorgangs laden statt der kompletten Tabelle
                Dim qry = From rw In globalFunction.GetOffeneProdKontrolleByFAUF(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value.ToString, DGV_FAUF.Rows(Row).Cells(DGV_Column.Vrg).Value.ToString)

                If qry.Count > 1 Then
                    lbl_info.Text = "Es sind " & qry.Count & " Einträge vorhanden, klicken öffnet die Detailansicht!"
                    lbl_info.ForeColor = Color.Red
                    lbl_info.Font = New Font("Segoe UI", 16)
                Else
                    For Each r In qry
                        If r.IsZusatzNull = True Or r.Zusatz = "" Then
                            lbl_info.Text = r.Datum.ToShortDateString & " - " & r.Grund
                            lbl_info.ForeColor = Color.Red
                            lbl_info.Font = New Font("Segoe UI", 16)
                        Else
                            lbl_info.Text = r.Datum.ToShortDateString & " - " & r.Grund & vbCrLf & r.Zusatz
                            lbl_info.ForeColor = Color.Red
                            lbl_info.Font = New Font("Segoe UI Semilight", 9)
                        End If
                    Next
                End If

            Case Color.OrangeRed
                Dim Status As String = String.Empty
                Dim IncidentTblAdaper = New tbl_IncidentTableAdapter
                Dim qry = From r In IncidentTblAdaper.GetData
                          Where r.workorder Like DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value

                For Each rw In qry
                    Select Case rw.incident_state
                        Case 0
                            Status = "undefiniert"
                        Case 1
                            Status = "offen"
                        Case 2
                            Status = "warten"
                        Case 3
                            Status = "in Arbeit"
                    End Select

                    lbl_info.Text = "Station: " & rw.sta & " - Fehler: " & rw.incident_title & " - Status: " & Status
                    lbl_info.ForeColor = Color.Red
                    lbl_info.Font = New Font("Segoe UI", 14)
                Next


            Case Color.Violet
                lbl_info.Text = "ACHTUNG! Auftrag hat Fehlmaterial!"
                lbl_info.ForeColor = Color.Red
                lbl_info.Font = New Font("Segoe UI", 16)
            Case Color.Orange
                lbl_info.Text = "ACHTUNG! Musterauftrag, Teamleiter Informieren!"
                lbl_info.ForeColor = Color.Orange
                lbl_info.Font = New Font("Segoe UI", 16)
            Case Color.Blue
                lbl_info.Text = ""
                'Nur die Kommentare dieses Auftrags laden statt der kompletten Tabelle
                Dim qry = From rw In globalFunction.GetKommentarByFAUF(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value.ToString)

                For Each r In qry
                    lbl_info.Text = r.Kommentar
                    lbl_info.ForeColor = Color.Blue
                    lbl_info.Font = New Font("Segoe UI Semilight", 9)
                Next
            Case Color.IndianRed
                lbl_info.Text = "ACHTUNG! Auftrag kann nicht gestartet werden!"
                lbl_info.ForeColor = Color.Red
                lbl_info.Font = New Font("Segoe UI", 16)
            Case Else
                lbl_info.Text = ""
        End Select

        Select Case Col
            Case DGV_Column.KommentarSpalte
                KommentarLöschenToolStripMenuItem.Visible = True
            Case Else
                KommentarLöschenToolStripMenuItem.Visible = False
        End Select

    End Sub
    Private Sub DTP_Datum_ValueChanged(sender As Object, e As EventArgs) Handles DTP_Datum.ValueChanged
        'WATS Refresher Stoppen
        T_WatsRefresh.Stop()
    End Sub
    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        Dim EinstellungenPasswort As New frm_Passwort

        EinstellungenPasswort.ShowDialog()
        If EinstellungenPasswort.DialogResult = DialogResult.OK Then
            'Einstellungen.ShowDialog()
            Using frm As New Einstellungen()
                AddHandler frm.SettingsEvent, AddressOf SettingsEventHandler
                frm.ShowDialog()
            End Using
        End If



    End Sub
    Private Sub AuftragSuchenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AuftragSuchenToolStripMenuItem.Click
        Dim f As New frm_FaufSearch(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
        f.ShowDialog()
    End Sub
    Private Sub ToolStripMenuItemStart_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStart.Click
        FAUF_Start()
    End Sub
    Private Sub ToolStripMenuItemAuftragRückmelden_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAuftragRückmelden.Click
        FAUF_Ruckmelden()
    End Sub
    Private Sub ToolStripMenuItemStücklisteAnzeigen_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStücklisteAnzeigen.Click
        FAUF_Stuli()
    End Sub
    Private Sub ToolStripMenuItemFertig_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemFertig.Click
        FAUF_Beenden()
    End Sub
    Private Sub ProduktionskontrolleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProduktionskontrolleToolStripMenuItem.Click
        FAUF_Prodkontrolle()
    End Sub
    Private Sub btn_Menu_FAUF_Start_Click(sender As Object, e As EventArgs) Handles btn_Menu_FAUF_Start.Click
        FAUF_Start()
    End Sub
    Private Sub btn_Menu_FAUF_Beenden_Click(sender As Object, e As EventArgs) Handles btn_Menu_FAUF_Beenden.Click
        FAUF_Beenden()
    End Sub
    Private Sub btn_Menu_FAUF_Ruck_Click(sender As Object, e As EventArgs) Handles btn_Menu_FAUF_Ruck.Click
        FAUF_Ruckmelden()
    End Sub
    Private Sub btn_Menu_FAUF_Stuli_Click(sender As Object, e As EventArgs) Handles btn_Menu_FAUF_Stuli.Click
        FAUF_Stuli()
    End Sub
    Private Sub btn_Menu_FAUF_ProdKont_Click(sender As Object, e As EventArgs) Handles btn_Menu_FAUF_ProdKont.Click
        FAUF_Prodkontrolle()
    End Sub
    Private Sub Menu_SAP_Daten_laden_Click(sender As Object, e As EventArgs) Handles Menu_SAP_Daten_laden.Click
        SAP.DT_SQ00_Import_FAUF.Clear()
        SAP_Import()
    End Sub
    Private Sub lbl_RS_Click(sender As Object, e As EventArgs) Handles lbl_RS_DCN.DoubleClick
        If RueckstandProLinie.AnzahlDC > 0 Or RueckstandProLinie.AnzahlBG > 0 Then
            Dim frm_ruckstand As New frm_Ruckstand(RueckstandProLinie.Data, RueckstandProLinie.Linie)
            frm_ruckstand.ShowDialog()
        End If
    End Sub
    Private Sub RückstandAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RückstandAnzeigenToolStripMenuItem.Click
        If RueckstandProLinie.AnzahlDC > 0 Or RueckstandProLinie.AnzahlBG > 0 Then
            Dim frm_ruckstand As New frm_Ruckstand(RueckstandProLinie.Data, RueckstandProLinie.Linie)
            frm_ruckstand.ShowDialog()
        End If
    End Sub
    Private Sub btn_chkListeAnzeigen_Click_1(sender As Object, e As EventArgs)
        If Not ZeileNochGueltig("btn_chkListeAnzeigen_Click_1") Then Exit Sub

        If globalFunction.ChkList(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Keine Checkliste gefunden", vbCritical, "Checkliste")
        End If
    End Sub
    Private Sub ChecklisteAnzeigenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If Not ZeileNochGueltig("ChecklisteAnzeigenToolStripMenuItem_Click") Then Exit Sub

        If globalFunction.ChkList(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Keine Checkliste gefunden", vbCritical, "Checkliste")
        End If
    End Sub
    Private Sub PKErldeigtSetztenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PKErldeigtSetztenToolStripMenuItem.Click
        'Produktionskontrolle Eintrag in DB als erledigt setzen
        ProdKontErledigen(False)
        'Heijunka Update starten
        HejiunkaAnzeigen()
    End Sub
    Private Sub ProdKontErledeigtSetztenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProdKontErledeigtSetztenToolStripMenuItem.Click
        'Produktionskontrolle Eintrag in DB als erledigt setzen
        ProdKontErledigen(False)
        'Heijunka Update starten
        HejiunkaAnzeigen()
    End Sub
    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        'Form grösse abspeichern
        My.Settings.FormHight = Me.Height
        My.Settings.FormWith = Me.Width
        'Überprüfen ob Form geschlossen werden kann
        If FormClose = False Then
            Dim anzFAUF As Integer = DGV_FAUF.Rows.Count + 1
            PB_Status.Maximum = anzFAUF
            'Background Worker Starten zur überprüfung der Daten in der Datenbank
            If Not BGW_CloseForm.IsBusy Then
                T_WatsRefresh.Stop()
                BGW_CloseForm.RunWorkerAsync()
            End If
            e.Cancel = True
        End If
        If FormClose = True Then
            mqtt_close()
        End If
    End Sub
    Private Sub lbl_Menu_Wochentag_Click(sender As Object, e As EventArgs) Handles lbl_Menu_Wochentag.Click
        'Variable unabhängig von Status der FAUFs auf True setzten! sol lässt sich das Tool schliessen ohne Taskmanager
        FormClose = True
    End Sub
    Private Sub StammdatenNeuLesenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StammdatenNeuLesenToolStripMenuItem.Click
        SAP.DT_SQ00_Import_FAUF.Clear()
        SAP_Import()
    End Sub
    Private Sub lbl_FPY_DoubleClick(sender As Object, e As EventArgs) Handles lbl_FPY.DoubleClick
        FehlerlabelLinie()
    End Sub
    Private Sub AuftragToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FehlerlabelAuftrag()
    End Sub
    Private Sub LinieToolStripMenuItem_Click(sender As Object, e As EventArgs)
        FehlerlabelLinie()
    End Sub
    Private Sub btn_grid_minus_Click(sender As Object, e As EventArgs) Handles btn_grid_Minus.Click
        For Each row As DataGridViewRow In DGV_FAUF.Rows
            If row.Height >= 35 Then
                row.Height = row.Height - 1
                My.Settings.DGV_Höhe = row.Height
            End If
        Next
    End Sub
    Private Sub btn_grid_Plus_Click_1(sender As Object, e As EventArgs) Handles btn_grid_Plus.Click
        For Each row As DataGridViewRow In DGV_FAUF.Rows
            If row.Height <= 45 Then
                row.Height = row.Height + 1
                My.Settings.DGV_Höhe = row.Height
            End If
        Next
    End Sub
    Private Sub btn_date_vor_Click(sender As Object, e As EventArgs) Handles btn_date_vor.Click
        DTP_Datum.Value = DTP_Datum.Value.AddDays(+1)
    End Sub
    Private Sub btn_date_zurueck_Click(sender As Object, e As EventArgs) Handles btn_date_zurueck.Click
        DTP_Datum.Value = DTP_Datum.Value.AddDays(-1)
    End Sub
    Private Sub lbl_oee_DoubleClick(sender As Object, e As EventArgs) Handles lbl_oee.DoubleClick
        Dim CB = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        Dim dat As Date = DTP_Datum.Value

        Dim f As New OEEDetails(CB.Item("LineName"), dat.ToString("yyyy") & "-" & dat.ToString("MM") & "-" & dat.ToString("dd"), CB.Item("Linie"))
        f.ShowDialog()
    End Sub
    Private Sub btn_vcheckKont_Click(sender As Object, e As EventArgs) Handles btn_vcheckKont.Click
        VCheckKontrolle()
    End Sub
    Private Sub VCheckKontrolleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VCheckKontrolleToolStripMenuItem.Click
        VCheckKontrolle()
    End Sub
    Private Sub AuftragZurücknehmenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuftragZurücknehmenToolStripMenuItem.Click
        StartAbbrechen()
    End Sub
    Private Sub AuftragZurücknehmenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AuftragZurücknehmenToolStripMenuItem1.Click
        StartAbbrechen()
    End Sub
    Private Sub AuftragTeilrückmeldenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AuftragTeilrückmeldenToolStripMenuItem1.Click
        TeilRueckmeldungen = True
        FAUF_Ruckmelden()
        TeilRueckmeldungen = False
    End Sub
    Private Sub AuftragTeilrückmeldenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AuftragTeilrückmeldenToolStripMenuItem.Click
        TeilRueckmeldungen = True
        FAUF_Ruckmelden()
        TeilRueckmeldungen = False
    End Sub
    Private Sub BeschriftungsetiketteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BeschriftungsetiketteToolStripMenuItem1.Click
        PrintNew()
    End Sub
    Private Sub BeschriftungsetiketteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeschriftungsetiketteToolStripMenuItem.Click
        PrintNew()
    End Sub
    Private Sub KommentarLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KommentarLöschenToolStripMenuItem.Click
        If Not ZeileNochGueltig("KommentarLöschenToolStripMenuItem_Click") Then Exit Sub

        If Not DGV_FAUF.Rows(Row).Cells(DGV_Column.KommentarSpalte).Value = "" Then
            Dim tbl_KommentarTableAdapter As New tbl_KommentarTableAdapter
            tbl_KommentarTableAdapter.DeleteQuery(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
            DGV_FAUF.Rows(Row).Cells(DGV_Column.KommentarSpalte).Value = ""
        End If
    End Sub
    Private Sub CMS_DGV_FAUF_Opening(sender As Object, e As CancelEventArgs) Handles CMS_DGV_FAUF.Opening
        If My.Settings.Printer_Aktivieren = True Then
            BeschriftungsetiketteToolStripMenuItem.Visible = True
        Else
            BeschriftungsetiketteToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub ToolStrip1_Click(sender As Object, e As EventArgs) Handles ToolStrip1.Click
        If My.Settings.Printer_Aktivieren = True Then
            BeschriftungsetiketteToolStripMenuItem1.Visible = True
        Else
            BeschriftungsetiketteToolStripMenuItem1.Visible = False
        End If
    End Sub
    Private Sub FertigunsdokumenteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dokumente()
    End Sub
    Private Sub FertigunsdokumenteToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Dokumente()
    End Sub
    Private Sub PCBAbrufenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PCBAbrufenToolStripMenuItem.Click
        LpAbrufen()
    End Sub
    Private Sub LPAbrufenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LPAbrufenToolStripMenuItem.Click
        LpAbrufen()
    End Sub
    Private Sub AuftragSuchenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AuftragSuchenToolStripMenuItem1.Click
        Dim f As New frm_FaufSearch()
        f.ShowDialog()
    End Sub

    Private Sub lbl_info_Click(sender As Object, e As EventArgs) Handles lbl_info.Click
        If Not ZeileNochGueltig("lbl_info_Click") Then Exit Sub

        'es wird nur ausgelöst bei roter schrift (Produktionkontrolle Eintrag)
        If DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.Red Then
            'Nur die Einträge dieses Auftrags/Vorgangs laden statt der kompletten Tabelle
            Dim qry = globalFunction.GetProdKontrolleByFAUF(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value.ToString, DGV_FAUF.Rows(Row).Cells(DGV_Column.Vrg).Value.ToString)

            If qry.Rows.Count > 1 Then
                Dim f As New frm_ProdKontrolle_Detail(qry, DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value, False, False)
                f.ShowDialog()
            End If
        End If
        If DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.DarkRed Then
            Dim f As New frm_AenderungDetail(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
            f.ShowDialog()
        End If
    End Sub

    Private Sub SupportAnftrageStellenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SupportAnftrageStellenToolStripMenuItem1.Click
        If Not ZeileNochGueltig("SupportAnftrageStellenToolStripMenuItem1_Click") Then Exit Sub

        Dim SNP = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        If IsDBNull(SNP.Item("IhToolLineNumber")) Then
            MsgBox("Daten in Datenbank nicht gepflegt", vbCritical, "Supportanfrage")
            Exit Sub
        End If
        Using frm As New frm_supportAnfrage(SNP.Item("IhToolLineNumber"), SNP.Item("Linie"), DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value, Row)
            AddHandler frm.ColoringHeijunkaEvent, AddressOf IncidentColorEventHandler
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub SupportAnftrageStellenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportAnftrageStellenToolStripMenuItem.Click
        If Not ZeileNochGueltig("SupportAnftrageStellenToolStripMenuItem_Click") Then Exit Sub

        Dim SNP = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        If IsDBNull(SNP.Item("IhToolLineNumber")) Then
            MsgBox("Daten in Datenbank nicht gepflegt", vbCritical, "Supportanfrage")
            Exit Sub
        End If

        'If DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.OrangeRed Then
        '    MsgBox("Es ist bereits ein Eintrag vorhanden", vbCritical, "Supportanfrage")
        '    Exit Sub
        'End If

        Using frm As New frm_supportAnfrage(SNP.Item("IhToolLineNumber"), SNP.Item("Linie"), DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value, Row)
            AddHandler frm.ColoringHeijunkaEvent, AddressOf IncidentColorEventHandler
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub ChecklisteAnzeigenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChecklisteAnzeigenToolStripMenuItem1.Click
        If Not ZeileNochGueltig("ChecklisteAnzeigenToolStripMenuItem1_Click") Then Exit Sub

        If globalFunction.ChkList(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Keine Checkliste gefunden", vbCritical, "Checkliste")
        End If
    End Sub

    Private Sub FertigungsdokumenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FertigungsdokumenteToolStripMenuItem.Click
        Dokumente()
    End Sub

    Private Sub ChecklisteAnzeigenToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ChecklisteAnzeigenToolStripMenuItem2.Click
        If Not ZeileNochGueltig("ChecklisteAnzeigenToolStripMenuItem2_Click") Then Exit Sub

        If globalFunction.ChkList(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Keine Checkliste gefunden", vbCritical, "Checkliste")
        End If
    End Sub

    Private Sub FertigungsdokumenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FertigungsdokumenteToolStripMenuItem1.Click
        Dokumente()
    End Sub

    Private Sub LernvideoAbspielenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LernvideoAbspielenToolStripMenuItem1.Click
        If Not ZeileNochGueltig("LernvideoAbspielenToolStripMenuItem1_Click") Then Exit Sub

        If globalFunction.PlayVideo(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Kein Lernvideo gefunden", vbCritical, "Video abspielen")
        End If
    End Sub

    Private Sub LernvideoAbspielenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LernvideoAbspielenToolStripMenuItem.Click
        If Not ZeileNochGueltig("LernvideoAbspielenToolStripMenuItem_Click") Then Exit Sub

        If globalFunction.PlayVideo(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString) = False Then
            MsgBox("Kein Lernvideo gefunden", vbCritical, "Video abspielen")
        End If
    End Sub
#End Region

#Region "Heijunka Anzeigen"
    Public Class HeijunkaArgument
        'Background Worker Übergabe Argumente
        Public Query As Object
        Public WatsVorhanden As Boolean
        Public vcheckVorhanden As Boolean
        Public Station As String
        Public LineName As String
        Public SMT As Boolean
        Public vc_kont As Boolean
        Public Linie As String
        Public Segment As String 'combobox -> Gruppe
        Public Team As String 'combobox -> Gruppe Team
        Public TestOP As String
    End Class
    Public Class HeijunkaResults
        'Linien Daten, Resultate aus BGW
        Public Data As EnumerableRowCollection
        Public FAUFStatusDaten As DataTable
        Public FPY As String
        Public Soll As Integer
        Public Ist As Integer
        Public OEE As String
        Public RuckstandAnzahlDC As Integer
        Public RuckstandAnzahlBG As Integer
        Public FirstPass As Integer
        Public FirstFail As Integer
        Public Gearbox As Boolean = False
        Public VorgabeZeiten As New VorgabeZeiten
    End Class
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

        Dim dat As Date = DTP_Datum.Value
        Dim datGestern As Date = DateAdd("d", -1, DTP_Datum.Value)

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
        'Spalte ist SAP
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Ist_SAP"
        DT.Columns.Add(Column)
        'Spalte ist v-Check
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Ist_vcheck"
        DT.Columns.Add(Column)
        'Spalte U
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "U"
        DT.Columns.Add(Column)
        'Spalte R
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "R"
        DT.Columns.Add(Column)
        'Spalte Zeit
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Zeit"
        DT.Columns.Add(Column)
        'Spalte Vorgabe
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Double")
        Column.ColumnName = "vorgabezeit"
        DT.Columns.Add(Column)
        'Spalte EndDatum
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "EndDatum"
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
        'Spalte FPY v-check
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "fpy_vcheck"
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
        'Spalte Incident --> Anzahl Einträge in DB
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "Incident"
        DT.Columns.Add(Column)
        'Spalte LP gerüstet --> Anzahl Einträge in DB
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "LP_Ruest"
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
        'Spalte Gearbox
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Gearbox"
        DT.Columns.Add(Column)
        'Spalte Lagerort
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Lagerort"
        DT.Columns.Add(Column)
        'Spalte AmTagBestücken SMT
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "AmTagBest"
        DT.Columns.Add(Column)
        'Änderung aktiv?
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.Boolean")
        Column.ColumnName = "AenderungAktiv"
        DT.Columns.Add(Column)
#End Region

        'Loop durch Eingangsquery, SAP Export
        Dim i As Integer = 1
        'Daten aus Prodkontrolle DB in Datatable schreiben, Zugriff auf db wird verringert
        Dim tbl_ProdKont As DataTable = Tbl_ProdKontrolleTableAdapter.GetData
        'Daten aus Incident Tabelle laden
        Dim IncidentTblAdapter = New tbl_IncidentTableAdapter
        Dim tbl_Incident As DataTable = IncidentTblAdapter.GetData
        'Daten aus Prodkontrolle DB in Datatable schreiben, Zugriff auf db wird verringert
        Dim tbl_vcheckKontrolle As DataTable = Tbl_vcheckKontrolleTableAdapter1.GetData
        'Liniendaten laden
        Dim tbl_linie As DataTable = Tbl_LinieTableAdapter.GetData
        'SMT Rüstdaten Laden
        Dim tbl_SMT_Rüst As DataTable = Tbl_SMT_RuestungTableAdapter.GetData
        'Kommentare laden
        Dim tbl_kommentarTableAdapter As New tbl_KommentarTableAdapter
        Dim tbl_Kommentar As DataTable = tbl_kommentarTableAdapter.GetData

        'SMT Progübersicht und Rüstung laden, nur wenn SMT Flag in DB aktiv
        Dim tbl_progübersicht As DataTable = Nothing
        Dim tbl_lp_ruest As DataTable = Nothing
        Dim TA_Ruestung As New tbl_lp_ruestTableAdapter
        If Argument.SMT = True Then
            Dim tbl_StammAdapter As New PU_tbl_StammTableAdapter
            tbl_progübersicht = tbl_StammAdapter.GetData
            tbl_lp_ruest = TA_Ruestung.GetData
        End If
        'vorherige fauf nummer zum rausfiltern der doppelten faufs
        Dim FaufOld As String = ""

        'Wenn V-Chekck Kontrolle benötigt wird, aus Txt File auslesen für welche Materialien
        If Argument.vc_kont = True Then
            'Vcheck TextFile auslesen und in DT speichern
            Dim Pfad As String = My.Settings.vcheckkontrollePfad
            Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)

            'Columns definieren
            DT_vCheck.Columns.Add("Material", Type.GetType("System.String"))
            DT_vCheck.Columns.Add("AP", Type.GetType("System.String"))


            'Text Datei in Datatable schreiben
            Dim dr As DataRow = DT_vCheck.NewRow
            For Each l As String In Lines
                dr = DT_vCheck.NewRow
                Dim split() As String = l.Split(";")
                dr("Material") = split(0)
                dr("AP") = split(1)
                DT_vCheck.Rows.Add(dr)
            Next
        End If

        'WATS Daten für alle Zeilen dieser Aktualisierung vorab parallel (mit Begrenzung) laden und
        'cachen, statt sie weiter unten in der Schleife pro Zeile nacheinander (blockierend) abzufragen.
        'Der Cache-Key entspricht genau den Parametern, die in die WATS-Filterabfrage einfliessen -
        'ändert sich dort nichts, ist der gecachte Wert identisch zum Ergebnis eines Einzelaufrufs.
        'Gleichzeitig werden dadurch mehrfach identische Abfragen (z.B. gleicher Auftrag mit mehreren
        'Vorgangszeilen) automatisch nur noch einmal abgefragt.
        Dim watsCache As New Dictionary(Of String, WatsRueckgabewerte)
        Dim watsPrefetchStopwatch As Stopwatch = Stopwatch.StartNew()
        If Argument.WatsVorhanden = True Then
            Dim watsCacheLock As New Object
            Dim scheduledKeys As New HashSet(Of String)
            Dim pendingWatsTasks As New List(Of Task)
            Dim watsCompletedCount As Integer = 0
            'Begrenzung der gleichzeitigen WATS Abfragen, um den WATS Server nicht zu überlasten
            Using watsThrottle As New SemaphoreSlim(6)
                For Each r As DataRow In Argument.Query
                    Dim watsFauf As String = r("Auftrag").ToString()
                    Dim watsSollStr As String = r("Vorgangsmenge").ToString().Replace(".", "")
                    Dim watsKey As String = watsFauf & "|" & Argument.Station & "|" & Argument.TestOP & "|" & watsSollStr

                    'Bereits für diesen Key eingeplant? (z.B. gleicher Auftrag über mehrere Vorgänge)
                    'scheduledKeys wird auch von den WATS-Callbacks gelesen (siehe unten), daher hier
                    'ebenfalls über watsCacheLock synchronisiert, um gleichzeitigen Zugriff zu vermeiden.
                    Dim istNeuerKey As Boolean
                    SyncLock watsCacheLock
                        istNeuerKey = scheduledKeys.Add(watsKey)
                    End SyncLock
                    If Not istNeuerKey Then Continue For

                    Dim watsSoll As Integer
                    Integer.TryParse(watsSollStr, watsSoll)

                    watsThrottle.Wait()
                    Dim watsTask As Task(Of WatsRueckgabewerte) = WATS_Daten(watsFauf, watsSoll, 0, Argument.TestOP, Argument.Station)
                    Dim followUpTask As Task = watsTask.ContinueWith(
                        Sub(finishedTask As Task(Of WatsRueckgabewerte))
                            Try
                                SyncLock watsCacheLock
                                    watsCache(watsKey) = finishedTask.Result
                                    watsCompletedCount += 1
                                    'Live-Fortschritt, damit die Anzeige während der parallelen WATS Abfragen
                                    'nicht stillsteht (Wert 0 = ProgressBar unverändert, nur der Text wird aktualisiert)
                                    BGW_Hejiunka.ReportProgress(0, $"WATS Daten werden geladen ({watsCompletedCount}/{scheduledKeys.Count})")
                                End SyncLock
                            Finally
                                watsThrottle.Release()
                            End Try
                        End Sub)
                    pendingWatsTasks.Add(followUpTask)
                Next

                'Blockierend auf alle vorab gestarteten WATS Abfragen warten (kein Await, damit der
                'BackgroundWorker-DoWork Handler wie bisher synchron durchläuft)
                Task.WhenAll(pendingWatsTasks).GetAwaiter.GetResult()
            End Using
        End If
        watsPrefetchStopwatch.Stop()
        log.WriteLog(Date.Now, "", "", "", $"WATS Vorab-Ladephase: {watsCache.Count} Abfragen in {watsPrefetchStopwatch.ElapsedMilliseconds} ms")

        Dim restlicheSchleifeStopwatch As Stopwatch = Stopwatch.StartNew()

        'Wird weiter unten gebraucht, um zu entscheiden ob tbl_FAUF_Status (komplette, ungefilterte
        'Tabelle) überhaupt geladen werden muss - siehe Kommentar bei "brauchtFAUFStatus".
        Dim gabEsAusnahme As Boolean = False

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

            'Fauf Pfad des Auftrags
            Dim FaufPfad As String = SAP_XML.PathFAUF_XML(r("Auftrag"))

            'Rückstand von gestern?
            Dim EnddateVorgang As Date = globalFunction.GetEndDateVrg(FaufPfad, r("Vorgang"))
            Dim EnddatumFAUF As Date = globalFunction.GetEndDateFauf(FaufPfad)
            Dim RueckSAPstk As Integer = globalFunction.GetReportedBackQuantityTRUC(FaufPfad, r("ArbPlatz"), r("Vorgang"))
            Dim FaufQty As Integer = globalFunction.GetFaufQty(FaufPfad)
            If EnddateVorgang < dat Then
                row("R") = "R"
                If FaufQty = RueckSAPstk Then
                    'Auftrag in Heinunka nicht anzeigen
                    Continue For
                End If
            End If

            'Ausnahmeliste auslesen ob ASN drinsteht
            Dim Ausnahme As Boolean = globalFunction.MatInAusnahmeliste(r("Material"))
            If Ausnahme Then gabEsAusnahme = True

            'Prüfen ob Änderungsflag aktiv im FAUF
            Dim Aenderung As New Aenderungen
            Aenderung = globalFunction.GetAnwStatusAenderung(r("Auftrag"))

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
            If Argument.WatsVorhanden = False Or Ausnahme = True Then
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
                fpy = System.Math.Round(((TotalCount - TotalFailed) / TotalCount) * 100, 1)
            Else
                'WATS Daten sind vorhanden --> Wats Abfragen
                'Report Progress 
                BGW_Hejiunka.ReportProgress(i, "Daten für FAUF " + r("Auftrag") + " werden geladen")

                'Wats Abfrage - zuerst aus dem oben vorab geladenen Cache versuchen
                Dim watsLookupKey As String = r("Auftrag").ToString() & "|" & Argument.Station & "|" & Argument.TestOP & "|" & r("Vorgangsmenge").ToString().Replace(".", "")
                Dim Wats As WatsRueckgabewerte = Nothing
                If Not watsCache.TryGetValue(watsLookupKey, Wats) OrElse Wats Is Nothing Then
                    'Fallback: sollte im Normalfall nicht vorkommen, falls doch (Cache unvollständig), wie bisher einzeln abfragen
                    log.WriteLog(Date.Now, "", r("Auftrag"), "", $"WATS Cache-Miss (Fallback-Einzelabfrage) für Key {watsLookupKey}")
                    Wats = WATS_Daten(r("Auftrag"), r("Vorgangsmenge").replace(".", ""), 0, Argument.TestOP, Argument.Station).GetAwaiter.GetResult
                End If
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
                fpy = System.Math.Round(((TotalCount - TotalFailed) / TotalCount) * 100, 1)
            End If

            'v-Check Daten vorhanden
            If Argument.vcheckVorhanden = True Then
                'v-Check Daten sind vorhanden
                'Report Progress 
                BGW_Hejiunka.ReportProgress(i, "Daten für FAUF " + r("Auftrag") + " werden aus vCheck geladen")

                Dim tbl_vcTabeleAdapter As New DS_vCheckTableAdapters.HJ_GetOperationInfoTableAdapter
                Dim tbl_vc As DataTable = tbl_vcTabeleAdapter.GetData(r("Auftrag"))

                'Dim qry = From vc_row In tbl_vc
            End If

            'Anzahl Einträge in ProdKontrolle für FAUF x
            Dim qryProdKont = From rw In tbl_ProdKont
                              Where rw("FAUF") Like r("Auftrag") AndAlso rw("Status") Like "offen" AndAlso TotalCount - TotalFailed = rw("Ist") AndAlso r("Vorgang") Like rw("Vrg") 'rw("Linie") = Argument.LineName
                              Order By rw("Datum")

            Dim qryIncident = From rw In tbl_Incident
                              Where rw("Workorder") Like r("Auftrag") AndAlso rw("incident_state") < 4

            'Anzahl Einträge in v-CheckKontrolle für FAUF x
            Dim qryVCKontrolle = From rw In tbl_vcheckKontrolle
                                 Where rw("Auftragsnummer") Like r("Auftrag") And Argument.Linie = rw("Linie")

            'Linien Name anhand des APLA APs raussuchen
            Dim qryLinie = From rw In tbl_linie
                           Where rw("AP") Like "*" + r("ArbPlatz") + "*"

            'Kommentare für FAUf suchen
            Dim qryComment = From rw In tbl_Kommentar
                             Where rw("FAUF") Like r("Auftrag")

            'überprüfen ob ASN oder SSN angezeigt werden soll
            If My.Settings.ASN_Anzeigen = True Then
                'Abfrage ASN aus ASN SSN Matchtable
                Dim ASN As String = SSN_ASN_TabTableAdapter1.qry_getASN(r("Material"))
                If Not ASN = "" Or Not String.IsNullOrEmpty(ASN) Then
                    row("Material") = ASN
                Else
                    row("Material") = r("Material")
                End If
            Else
                row("Material") = r("Material")
            End If
            row("SAP_Material") = r("Material")
            row("FAUF") = r("Auftrag")
            row("Soll") = FaufQty 'bereits oben berechnet (Zeile "Dim FaufQty As Integer = ...") - erneuter Aufruf von GetFaufQty(FaufPfad) lieferte denselben Wert nochmal
            row("Ist") = TotalCount - TotalFailed
            'If r("Anwenderstatus") = "UMTE" Then
            '    row("U") = "U"
            'End If
            row("U") = globalFunction.GetAnwStatusUMTE(r("Auftrag"))
            row("Zeit") = r("FrueStartZeit")
            row("EndDatum") = EnddatumFAUF
            row("VorgangText") = r("VorgangText")
            row("SystemStatus") = r("SystemStatus")
            row("DateViertel") = DateVirtel
            row("DateHalb") = DateHalb
            row("DateDreiViertel") = DateDreiVirtel
            row("DateVoll") = DateVoll
            row("ProdDatum") = ProdDatum
            row("TotalFailed") = TotalFailed
            row("fpy") = fpy
            row("MatStatus") = globalFunction.GetMatStatus(r("Auftrag"), r("Material"))
            row("Prodkontrolle") = qryProdKont.Count
            row("ausnahme") = Ausnahme.ToString
            row("SAPAP") = r("ArbPlatz")
            row("LP_Ruest") = 0
            row("Lagerort") = globalFunction.GetLagerort(r("Auftrag"), r("Material"))
            row("AenderungAktiv") = Aenderung.AenderungAktiv
            row("Incident") = qryIncident.Count
            'Vorgabezeiten laden (vorher wurde GetAuftragZeiten hier für dieselbe Zeile ein zweites Mal
            'aufgerufen und parste dabei nochmal komplett dieselbe FAUF-XML - Vgz wird jetzt wiederverwendet)
            Dim Vgz As VorgabeZeiten = globalFunction.GetAuftragZeiten(r("Auftrag"))
            row("vorgabezeit") = System.Math.Round(Vgz.Personalzeit, 0)
            result.VorgabeZeiten.RuestenPersonal += Vgz.RuestenPersonal
            result.VorgabeZeiten.RuestenMaschine += Vgz.RuestenMaschine
            result.VorgabeZeiten.Personalzeit += Vgz.Personalzeit
            result.VorgabeZeiten.Maschinenzeit += Vgz.Maschinenzeit


            'Ist Wert aus SAP FAUF XML laden
            Dim SAP_Ist As Integer = globalFunction.GetReportedBackQuantity(FaufPfad)
            Dim SAP_Truc As Integer = globalFunction.GetReportedBackQuantityTRUC(FaufPfad, r("ArbPlatz"), r("Vorgang"))

            If SAP_Ist = 0 And SAP_Truc > 0 Then
                row("Ist_SAP") = SAP_Truc
            Else
                row("Ist_SAP") = SAP_Ist
            End If

            'Linienname anhand des AP abfragen
            For Each rw In qryLinie.AsEnumerable
                row("Linie") = rw.Item("Linie")
            Next

            'Kommentar anhand des FAUFs auslesen
            For Each rw In qryComment.AsEnumerable
                row("Kommentar") = rw.Item("Kommentar")
            Next

            row("VC_Kontrolle") = ""
            If Argument.vc_kont = True Then
                'Abfrage temp DT_vCheck ob ASN vcheck kontrolle braucht
                For Each v In DT_vCheck.AsEnumerable
                    If v("Material") = r("Material") And v("AP") = r("ArbPlatz") Then
                        If qryVCKontrolle.Count > 0 Then
                            'wenn ein Eintrag vorhanden ist eine 1 schreiben
                            row("VC_Kontrolle") = "1"
                        Else
                            'wenn kein Eintrag vorhanden ist eine 0 schreiben
                            row("VC_Kontrolle") = "0"
                        End If
                    End If
                Next
            End If
            row("Vrg") = r("Vorgang")

            'Nur wenn es sich um eine SMT Linie handelt, PCBA Breite, Rüstung und LP-Nr aus DB abfragen
            If Argument.SMT = True Then
                Dim Rüstung As String = ""
                Dim MatTemp As String = ""
                'Query Stamm DB SMT
                Dim qrySMTstamm = From rw In tbl_progübersicht
                                  Where r("Material") = globalFunction.GetStringValue(rw("Mat_SAP"))

                Dim qryLpRuest = From rw In tbl_lp_ruest
                                 Where r("Auftrag") = rw("AuftragsNummer")

                If qryLpRuest.Count > 0 Then
                    row("LP_Ruest") = 1
                End If

                For Each stamm In qrySMTstamm
                    'Abfrage ob es da es sich nicht um Prototyp handelt
                    If Not globalFunction.GetStringValue(stamm("ID_Material")) = "-" Then
                        MatTemp = stamm("Material")
                        Rüstung = stamm("Cluster")
                        row("pcba_breite") = stamm("LP_Breite")
                        row("LPNr") = stamm("LP_Nr")
                        If stamm("ATB") = True Then
                            row("AmTagBest") = 1
                        Else
                            row("AmTagBest") = 0
                        End If

                    Else
                        If Len(r("Auftrag")) >= 7 Then
                            'Muster Baugrauppe
                            MatTemp = stamm("Material")
                            Rüstung = stamm("Cluster")
                            row("pcba_breite") = stamm("LP_Breite")
                            'row("LPNr") = stamm("LP_Nr") ' Abfrage v-Check
                            If stamm("ATB") = True Then
                                row("AmTagBest") = 1
                            Else
                                row("AmTagBest") = 0
                            End If
                        End If
                    End If


                Next

                'Info zu Rüstung
                ' Datenbank abfrage ob eine rüstung in der Prodkontrolle DB erfasst wurde
                Dim qryRüstung = From rw In tbl_SMT_Rüst
                                 Where rw("Auftrag") = r("Auftrag")

                'In der Programmübersicht die Rüstung auslesen (FIX oder VARIABEL)
                Select Case Rüstung
                    'VARIABLE RÜSTUNG
                    Case "BLL", "GRL", "YLL"
                        If qryRüstung.Count > 0 Then
                            For Each rüst In qryRüstung
                                row("SMD_Ruestung") = rüst("Rüstung")
                            Next
                        Else
                            row("SMD_Ruestung") = "offen"
                        End If
                    Case Else
                        'FIXE RÜSTUNG, Nur Spliten wegen Platz und in Datatabel übergeben
                        Dim fix() As String = Split(Rüstung, "_")
                        If fix.Count > 1 Then
                            row("SMD_Ruestung") = fix(1)
                        Else
                            row("SMD_Ruestung") = fix(0)
                        End If
                End Select

            End If

            'CEVA GEarboxnummer in Heijunka anzeigen
            If Argument.Team = "CEVA GearBox" Then
                Dim AusTC3 As String = globalFunction.GetCEVA_GearBoxNr_TC3(r("Auftrag"))
                Dim AusDok As String = globalFunction.GetCEVA_GearBoxNr(r("Auftrag"))

                If AusTC3 = "" Then
                    row("Gearbox") = AusDok
                Else
                    row("Gearbox") = AusTC3
                End If

                result.Gearbox = True
            End If

            'Soll und Ist berechnen, nur Zahlen von heute, resultat an Klasse übergeben, aufsummieren

            If dat = globalFunction.GetEndDateVrg(FaufPfad, r("Vorgang")) And row("U") IsNot ("U") Then
                If My.Settings.sollistHalbfabrikate = True Then
                    If row("Lagerort") = "DC20" Then
                        result.Soll = result.Soll + r("Vorgangsmenge").replace(".", "")
                        result.Ist = result.Ist + TotalCount - TotalFailed
                    End If
                Else
                    result.Soll = result.Soll + r("Vorgangsmenge").replace(".", "")
                    result.Ist = result.Ist + TotalCount - TotalFailed
                End If
            End If

            DT.Rows.Add(row)
            i = i + 1
        Next
        restlicheSchleifeStopwatch.Stop()
        log.WriteLog(Date.Now, "", "", "", $"Restliche Zeilen-Schleife (SAP-XML etc.): {restlicheSchleifeStopwatch.ElapsedMilliseconds} ms für {i} Zeilen")

        ' Linien Berechnungen
        Dim kennzahlenStopwatch As Stopwatch = Stopwatch.StartNew()
        Dim teilStopwatch As Stopwatch

        'Rückstäne Berechnen (vorher wurde RueckstandProLinie() hier zweimal aufgerufen - beide Werte
        'werden aber schon in einem einzigen Aufruf berechnet, siehe Function RueckstandProLinie)
        teilStopwatch = Stopwatch.StartNew()
        Dim rueckstaende = RueckstandProLinie()
        result.RuckstandAnzahlDC = rueckstaende.AnzahlDC
        result.RuckstandAnzahlBG = rueckstaende.AnzahlBG
        log.WriteLog(Date.Now, "", "", "", $"  - RueckstandProLinie: {teilStopwatch.ElapsedMilliseconds} ms")


        'FPY
        If Argument.WatsVorhanden = True Then
            'FPY berechnung
            BGW_Hejiunka.ReportProgress(i + 1, "Prozesskennzahlen werden berechnet")

            'Datumstring für Wats aufbauen
            Dim Datevon As String = datGestern.ToString("yyyy") & "-" & datGestern.ToString("MM") & "-" & datGestern.ToString("dd") & "T23:00:00.000Z"
            Dim Datebis As String = dat.ToString("yyyy") & "-" & dat.ToString("MM") & "-" & dat.ToString("dd") & "T22:59:59.999Z"

            'prüfen ob im argument Station, string nicht = ""  ist --> sind Daten in Datenbank erfasst
            'Resultat an Klasse übergeben
            If Not Argument.Station = "" Then
                teilStopwatch = Stopwatch.StartNew()
                Dim FPY As WatsRueckgabewerte = FPY_Aktuell(Datevon, Datebis, Argument.Station, 0, Argument.TestOP).GetAwaiter.GetResult
                log.WriteLog(Date.Now, "", "", "", $"  - FPY_Aktuell (WATS): {teilStopwatch.ElapsedMilliseconds} ms")
                result.FPY = "FPY: " & System.Math.Round((FPY.totalPassed - FPY.failed) / FPY.totalPassed * 100, 1) & "%"

                ' Daten übergeben
                result.FirstPass = FPY.totalPassed
                result.FirstFail = FPY.failed

            Else
                result.FPY = "FPY: "
            End If
        End If

        'tbl_FAUF_Status wird in RunWorkerCompleted nur für Zeilen ohne WATS-Daten bzw. Ausnahmelisten-
        'Materialien ausgewertet (My.Settings.G_LinieWats = False Or r("ausnahme") = "True"). Die
        'komplette, ungefilterte Tabelle (kein WHERE) ist nur dann relevant - auf einer reinen
        'WATS-Linie ohne Ausnahmen wird sie sonst umsonst komplett über das Netzwerk geladen.
        teilStopwatch = Stopwatch.StartNew()
        Dim brauchtFAUFStatus As Boolean = Not Argument.WatsVorhanden OrElse gabEsAusnahme
        If brauchtFAUFStatus Then
            result.FAUFStatusDaten = Tbl_FAUF_StatusTableAdapter.GetData()
        Else
            result.FAUFStatusDaten = New DS_ProdKontrolle.tbl_FAUF_StatusDataTable()
        End If
        log.WriteLog(Date.Now, "", "", "", $"  - Tbl_FAUF_StatusTableAdapter.GetData (gebraucht={brauchtFAUFStatus}): {teilStopwatch.ElapsedMilliseconds} ms")

        'OEE Berechnung
        teilStopwatch = Stopwatch.StartNew()
        Dim OEE As Boolean = True
        If OEE = True Then
            Dim OEE_DAT As String = dat.ToString("yyyy") & "-" & dat.ToString("MM") & "-" & dat.ToString("dd")
            Dim pz As Integer = 0 ' ProzessZeit
            Dim vpz As Integer = 0 ' Verfügbare Prozess Zeit
            Dim ssz As Integer = 0 ' Stillstandszeit
            If Not Argument.LineName = "" Then
                For Each r In Tbl_StillstandszeitenSummeTableAdapter1.GetData(Argument.LineName, OEE_DAT)
                    Select Case r.StatusStufe1
                        Case "Prozesszeit"
                            pz = pz + r.Sum
                        Case Else
                            ssz = ssz + r.Sum
                    End Select
                Next
                vpz = ssz + pz
                result.OEE = "OEE: " & System.Math.Round(((vpz - ssz) / vpz) * 100, 1) & "%"
            Else
                result.OEE = "OEE: NaN"
            End If
        End If
        log.WriteLog(Date.Now, "", "", "", $"  - OEE Berechnung: {teilStopwatch.ElapsedMilliseconds} ms")

        kennzahlenStopwatch.Stop()
        log.WriteLog(Date.Now, "", "", "", $"Prozesskennzahlen (Rückstände/FPY/FAUFStatus/OEE): {kennzahlenStopwatch.ElapsedMilliseconds} ms")

        'Datatable an klasse übergeben
        result.Data = DT.AsEnumerable

        'result klasse übergeben
        e.Result = result
        DT.Dispose()
        DT = Nothing

        'Datenbanken freigeben
        tbl_linie.Dispose()
        tbl_vcheckKontrolle.Dispose()
        tbl_ProdKont.Dispose()
    End Sub
    Private Sub BGW_Hejiunka_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_Hejiunka.ProgressChanged
        PB_Status.Value = e.ProgressPercentage
        lbl_Status.Text = e.UserState
    End Sub
    Private Sub BGW_Hejiunka_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_Hejiunka.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            log.WriteLog(Date.Now, "", "", "", $"Heijunka Ladefehler: {e.Error.Message} | {e.Error.StackTrace}")
            lbl_Status.Text = "Fehler beim Laden"
            Panel1.Visible = False
            T_WatsRefresh.Start()
            T_WatsRefresh.Interval = My.Settings.UpdateInterval
            Exit Sub
        End If

        'DGV füllen
        Dim i As Integer = 0
        'Datenbank "FAUF Status" an lokale Datatable übergeben
        Dim tblFAUFStatus As DataTable = e.Result.FAUFStatusDaten
        Dim EndDatum As Date = Nothing
        lbl_Ist.Text = "0"

        ' Brauchts das da wirklich? Macht es sinn alles zu löschen oder nur aktualisieren???
        Dim dgvFuellenStopwatch As Stopwatch = Stopwatch.StartNew()
        DGV_FAUF.SuspendLayout()
        DGV_FAUF.Rows.Clear()

#Region "Heijunka anzeigen"
        'e.result enhält typisierte Datatable mit Dateninhalt des heijunka
        For Each r As DataRow In e.Result.Data

            'FAUF überspringen wenn komplett Rückgemeldet
            If My.Settings.FaufNichtAnzeigen = True Then
                If r("Ist_SAP") = r("Soll") Then
                    Continue For
                End If
            End If


            DGV_FAUF.Rows.Add(r("Material")) 'Spalte dient nur der Anzeige

            DGV_FAUF.Rows(i).Cells(DGV_Column.Auftrag).Value = r("FAUF")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Soll).Value = r("Soll")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Ist).Value = r("Ist")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Ist_SAP).Value = r("Ist_SAP")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Zeit).Value = r("Zeit")
            DGV_FAUF.Rows(i).Cells(DGV_Column.U).Value = r("U")
            DGV_FAUF.Rows(i).Cells(DGV_Column.R).Value = r("R")
            DGV_FAUF.Rows(i).Cells(DGV_Column.ProdDatum).Value = r("ProdDatum")
            DGV_FAUF.Rows(i).Cells(DGV_Column.TF).Value = r("TotalFailed")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Vrg).Value = r("Vrg")
            DGV_FAUF.Rows(i).Cells(DGV_Column.LPBreite).Value = r("pcba_breite")
            DGV_FAUF.Rows(i).Cells(DGV_Column.SAPMAT).Value = r("SAP_Material") 'Spalte auf die sich bezogen werden muss
            DGV_FAUF.Rows(i).Cells(DGV_Column.ausnahme).Value = r("ausnahme")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Linie).Value = r("Linie")
            DGV_FAUF.Rows(i).Cells(DGV_Column.MatPPStatus).Value = r("MatStatus")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Fixruestung).Value = r("SMD_Ruestung")
            DGV_FAUF.Rows(i).Cells(DGV_Column.vrgText).Value = r("VorgangText")
            DGV_FAUF.Rows(i).Cells(DGV_Column.LPNR).Value = r("LPNr")
            DGV_FAUF.Rows(i).Cells(DGV_Column.SystemStatus).Value = r("SystemStatus")
            DGV_FAUF.Rows(i).Cells(DGV_Column.SAPAP).Value = r("SAPAP")
            DGV_FAUF.Rows(i).Cells(DGV_Column.KommentarSpalte).Value = r("Kommentar")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Lagerort).Value = r("Lagerort")
            DGV_FAUF.Rows(i).Cells(DGV_Column.AmTagBestücken).Value = r("AmTagBest")
            DGV_FAUF.Rows(i).Cells(DGV_Column.Vorgabezeit).Value = r("Vorgabezeit")
            EndDatum = r("EndDatum")
            DGV_FAUF.Rows(i).Cells(DGV_Column.EndDatum).Value = EndDatum.ToShortDateString

            'FPY setzten für FAUF
            If r("fpy") = "NaN" Or r("fpy") = "n.def " Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.FPY).Value = "-----"
            Else
                DGV_FAUF.Rows(i).Cells(DGV_Column.FPY).Value = r("fpy") & "%"
            End If

            'Stückzahlen durch 4 teilen für die kreise
            Dim viertel As Double = System.Math.Round(r("Soll") / 4 * 1, 1)
            Dim halb As Double = System.Math.Round(r("Soll") / 4 * 2, 1)
            Dim dreiviertel As Double = System.Math.Round(r("Soll") / 4 * 3, 1)
            Dim ganz As Double = System.Math.Round(r("Soll") / 4 * 4, 1)

            'Prüfen ob Daten aus WATS kommen oder sich in der Ausnahmetabelle befinden
            If My.Settings.G_LinieWats = False Or r("ausnahme") = "True" Then
                'Keine WATS Daten/Ausnahmetabelle, Daten für den Status aus Access Datenbank "Fauf Status" laden
                Dim qry_FAUFStatus = From row In tblFAUFStatus
                                     Where row("FAUF") = r("FAUF") & "_" & r("Vrg")


                'Prüfen ob ASN in Ausnahmetabelle
                If r("ausnahme") = "True" Then
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.noWats
                End If

                For Each s In qry_FAUFStatus
                    'Prüfen ob sich ein Wert in der Spallt SollStk befindet
                    If Not IsDBNull(s("SollStk")) Then
                        'überprüfen ob halbfabrikate angezeigt werden sollen
                        If My.Settings.sollistHalbfabrikate = True Then
                            If r("Lagerort") = "DC20" Then
                                'Ist Stk aus Tabelle "FAUF Status" lesen und Addieren in Label
                                lbl_Ist.Text = CInt(lbl_Ist.Text) + CInt(s("SollStk"))
                                e.Result.Ist = e.Result.Ist + CInt(s("SollStk"))
                            End If
                        Else
                            'Ist Stk aus Tabelle "FAUF Status" lesen und Addieren in Label
                            lbl_Ist.Text = CInt(lbl_Ist.Text) + CInt(s("SollStk"))
                            e.Result.Ist = e.Result.Ist + CInt(s("SollStk"))
                        End If
                    End If

                    'Farbige kreise setzten Status wird aus Tabelle "FAUF Status" geladen
                    Select Case s("Status")
                        Case 0
                            DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.leer1
                        Case 1
                            DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ResourceManager.GetObject(FarbCodeTag(globalFunction.ParseProdDatum(s("ProdDatum"))).FarbText & "_halb")
                        Case 2
                            DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ResourceManager.GetObject(FarbCodeTag(globalFunction.ParseProdDatum(s("ProdDatum"))).FarbText & "_voll")
                    End Select
                Next
            Else
                'Die 5 Fälle schliessen sich gegenseitig aus (je höher die Ist-Stückzahl, desto mehr
                'Viertel sind eingefärbt) - vorher waren das unabhängige If-Blöcke, die die Zelle bis zu
                '4x hintereinander überschrieben haben, wobei nur das letzte Ergebnis sichtbar blieb.
                'RePaintedCircle/RePaintedFullCircle laden dabei jeweils 4 Bilder von der Netzwerk-
                'freigabe - das mehrfach überschreibende Neuzeichnen war daher pro Zeile bis zu 4x teurer
                'als nötig, ohne den sichtbaren Endzustand zu verändern (ElseIf statt If ändert das
                'Ergebnis nicht, da ohnehin immer der zuletzt zutreffende Fall sichtbar war).
                If r("Ist") >= System.Math.Round(r("Soll") / 4 * 4, 1) Then
                    'ist Stückzahl ist gleich oder grösser als die Soll Stückzahl
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = RePaintedFullCircle(Color.White, FarbCodeTag(r("DateViertel")).BackColor, FarbCodeTag(r("DateHalb")).BackColor, FarbCodeTag(r("DateDreiViertel")).BackColor, FarbCodeTag(r("DateVoll")).BackColor)
                ElseIf r("Ist") >= System.Math.Round(r("Soll") / 4 * 3, 1) Then
                    'ist Stückzahl ist grösser als dreiviertel und kleiner als Fertig
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = RePaintedFullCircle(Color.White, FarbCodeTag(r("DateViertel")).BackColor, FarbCodeTag(r("DateHalb")).BackColor, FarbCodeTag(r("DateDreiViertel")).BackColor, Color.Transparent)
                ElseIf r("Ist") >= System.Math.Round(r("Soll") / 4 * 2, 1) Then
                    'ist Stückzahl ist grösser als die häfte und kleiner als dreiviertel
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = RePaintedFullCircle(Color.White, FarbCodeTag(r("DateViertel")).BackColor, FarbCodeTag(r("DateHalb")).BackColor, Color.Transparent, Color.Transparent)
                ElseIf r("Ist") >= System.Math.Round(r("Soll") / 4 * 1, 1) Then
                    'ist Stückzahl ist grösser als ein Viertel und kleiner als die Hälfte
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = RePaintedFullCircle(Color.White, FarbCodeTag(r("DateViertel")).BackColor, Color.Transparent, Color.Transparent, Color.Transparent)
                Else
                    'Auftrag gestartet = ist stückzahl ist kleiner als ein Viertel. nur Rand wird Temporär eingefärbt
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = RePaintedCircle(Color.Black, FarbCodeTag(r("ProdDatum")).BackColor)
                End If
            End If

            'Zusammenfassen der möglichen Kommentare/Änderungen undProdkontrolle
            Dim zaehler As Integer = 0

            'Prüfen ob es sich um eine CEVA Gearbox Linie handelt
            If e.Result.Gearbox = True Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.Gearbox).Value = r("Gearbox")
            End If


            'Prüfen wenn Kommentar vorhanden und Spalte NICHT eingeblendet ist, Schrift Blau einfärben
            If My.Settings.Kommentar = False And Not IsDBNull(r("Kommentar")) Then
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.Blue
                zaehler += 1
            End If

            'prüfen ob es sich um einen FX oder PP00 FAUF handelt!
            If globalFunction.isPP00(r("FAUF")) = True Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.Orange
                zaehler += 1
            End If

            'Prüfen ob eine Änderung aktiv ist
            'Änderungsflag in Auftrag gesetzt
            If r("AenderungAktiv") = True Then
                Debug.WriteLine("Änderung für Auftrag: " & r("FAUF") & " aktiv.")
                If r("Ist") < 1 Then
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                End If
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.DarkRed
            End If

            'Änderungsprozess ALT --> Kann später gelöscht werden
            'Material status aus Tabelle auslesen und dementsprechend einfärben
            Select Case r("MatStatus")
                Case "UA", "SA", "WA"
                    If r("Ist") < 1 Then
                        DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                    End If
                    DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.DarkRed
                    zaehler += 1
                Case "Z1"
                    If r("Ist") < 1 Then
                        DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                    End If
                    DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.IndianRed
                    zaehler += 1
            End Select


            'Prüfen ob im Systemstaus Fehlmat vorkommt nur wenn in den Êinstellungen nicht auf FREI gefilttert wird
            If InStr(r("Systemstatus"), "FMAT") > 1 And My.Settings.Systemstatus = "" Then
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.Violet
                zaehler += 1
            End If

            'Prüfen ob eintrag in Prodkontrolle
            If r("Prodkontrolle") > 0 Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                zaehler += 1
            End If

            'Prüfen ob eintrag in Incident
            If r("Incident") > 0 Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.help_desk
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.OrangeRed
                zaehler += 1
            End If

            'Wenn mehr als ein Hinweis aktiv, verweis auf das Protokoll
            If zaehler > 1 Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.DarkViolet
            End If

            'HAcken für SMT LP Gerüstet
            If r("LP_Ruest") > 0 Then
                DGV_FAUF.Rows(i).Cells(DGV_Column.LPOK).Value = My.Resources.gruenerhacken
            End If

            'Wenn SMT Am Tagbestücken, eintrag in Prodkontrolle
            If Not IsDBNull(r("AmTagBest")) Then
                If r("AmTagBest") = 1 Then
                    If r("Prodkontrolle") = 0 Then
                        Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, ComboBox1.Text, r("SAP_Material"), r("FAUF"), 0, 0, "offen", "Sonstiges", "ACHTUNG Baugruppe am Tag bestücken", r("Vrg"))
                    End If
                    DGV_FAUF.Rows(i).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                    DGV_FAUF.Rows(i).DefaultCellStyle.ForeColor = Color.Red
                End If
            End If

            'Prüfen ob vcheck kontrolle eintrag vorhanden ist, falls ja, grüner haken anzeigen fals nein Ausrufezeichen
            If Not r("VC_Kontrolle") = "" Then
                If r("VC_Kontrolle") = "1" Then
                    DGV_FAUF.Rows(i).Cells(DGV_Column.VCheck).Value = My.Resources.gruenerhacken
                ElseIf r("VC_Kontrolle") = "0" Then
                    DGV_FAUF.Rows(i).Cells(DGV_Column.VCheck).Value = My.Resources.ausrufezeichen
                End If
            Else
                DGV_FAUF.Rows(i).Cells(DGV_Column.VCheck).Value = My.Resources.platzhalter
            End If
            i = i + 1
        Next

#End Region
        DGV_FAUF.ResumeLayout()
        dgvFuellenStopwatch.Stop()
        log.WriteLog(Date.Now, "", "", "", $"DGV füllen (RunWorkerCompleted, UI-Thread): {dgvFuellenStopwatch.ElapsedMilliseconds} ms für {i} Zeilen")

        'Soll ist setzten
        lbl_Soll.Text = "Soll: " & e.Result.Soll
        ' Ist wert setzten wenn Daten aus WATS kommen
        If My.Settings.G_LinieWats = True Then
            lbl_Ist.Text = e.Result.Ist
        End If


        'Vorgabezeiten setzten
        lbl_Pers_vz.Text = System.Math.Round(e.Result.VorgabeZeiten.Personalzeit / 60, 2) & "h"
        lbl_Maschine_vz.Text = System.Math.Round(e.Result.VorgabeZeiten.Maschinenzeit / 60, 2) & "h"

        'Dim Computername As String = System.Environment.MachineName
        'Dim Topic As String = "Heijunka/" & Computername
        'Dim ComboBox = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        'Dim Topic As String = "Heijunka/" & ComboBox.Item("Gruppe") & "/" & ComboBox.Item("GruppeTeam") & "/" & ComboBox.Item("Linie")
        'mqtt.Publish(Topic & "/Soll", e.Result.Soll).Wait()
        'mqtt.Publish(Topic & "/Ist", e.Result.Ist).Wait()
        '_________________________________________________________________________________________________________________________
        ' Daten in Dashboard DB schreiben
        ' überprüfen ob ein Datensatz für Datum und Linie bereits vorhanden ist, Wenn ja --> aktualisieren mit aktuellen Daten
        ' Wenn kein Datensatz vorhanden ist, neuer anlegen und mit Daten füllen
        'Dim Combo = DirectCast(TblLinieBindingSource.Current, DataRowView).Row

        '' Prüfen ob es sich um eine Zusammenfassung handelt oder um eine CEVA Gearbox
        'Dim firstChar As String = Combo.Item("Linie").Substring(0, 1)
        'If Not firstChar = "_" Then
        '    If Not (Combo.Item("GruppeTeam") = "CEVA GearBox" Or Combo.Item("GruppeTeam") = "Sinteso VM" Or Combo.Item("GruppeTeam") = "TX I/O VM") Then
        '        Dim tbl_DashboardTabelAdapter As New tbl_DashboardDatenTableAdapter
        '        Dim Datum As String = DTP_Datum.Value.ToShortDateString

        '        If tbl_DashboardTabelAdapter.ScalarQuery(Datum, Combo.Item("Linie")) > 0 Then
        '            'MsgBox("Datensatz vorhanden")
        '            Dim ID As Integer = tbl_DashboardTabelAdapter.ScalarQuery(Datum, Combo.Item("Linie"))
        '            tbl_DashboardTabelAdapter.UpdateDashboardDaten(e.Result.Soll, e.Result.Ist, e.Result.FirstPass, e.Result.FirstFail, e.Result.RuckstandAnzahlBG, e.Result.RuckstandAnzahlDC, ID)
        '        Else
        '            'MsgBox("Keine Datensätze vorhanden")
        '            tbl_DashboardTabelAdapter.InsertDasboardDaten(Datum, Combo.Item("Gruppe"), Combo.Item("GruppeTeam"), Combo.Item("Linie"), e.Result.Soll, e.Result.Ist, e.Result.FirstPass, e.Result.FirstFail, e.Result.RuckstandStunden, e.Result.RuckstandAnzahl, Combo.Item("Produktion"))
        '        End If
        '    End If
        'End If
        '_________________________________________________________________________________________________________________________

        'FPY Setzten
        lbl_FPY.Text = e.Result.fpy

        'OEE Setzen
        lbl_oee.Text = e.Result.oee

        'Rückstandanzeigen
        lbl_RS_DCN.Text = e.Result.RuckstandAnzahlDC & "stk"
        lbl_RS_BG.Text = e.Result.RuckstandAnzahlBG & "stk"



        'Panel1, Ladebild ausblenden
        Panel1.Visible = False
        'DGV Zelle nicht markieren (CurrentCell ist Nothing, wenn das Grid keine Zeilen hat)
        If DGV_FAUF.CurrentCell IsNot Nothing Then
            DGV_FAUF.CurrentCell.Selected = False
        End If
        'Status auf Done setzen
        lbl_Status.Text = ""
        mqtt_Send_Status("Bereit")
        'Timer für Ladebalken zurücksetztung starten
        T_PB.Start()
        'WATS Refresher starten
        If My.Settings.autoUpdate = True Then
            T_WatsRefresh.Start()
            T_WatsRefresh.Interval = My.Settings.UpdateInterval
        End If
        'Timer für SAP Ablage überprüfung Straten
        T_CheckSAPimport.Start()

        If aktualisierungStopwatch IsNot Nothing Then
            aktualisierungStopwatch.Stop()
            log.WriteLog(Date.Now, "", "", "", $"Gesamte Aktualisierung (Klick 'Aktualisieren' bis DGV fertig befüllt): {aktualisierungStopwatch.ElapsedMilliseconds} ms")
        End If

    End Sub
    Public Sub HejiunkaAnzeigen()
        'BGW starten der die Heijunka Daten im DGV anzeigt
        aktualisierungStopwatch = Stopwatch.StartNew()

        'mqtt_Send_Status("Heijunkadaten laden")
        'WATS Refresher stoppen
        T_WatsRefresh.Stop()

        'SAP Download Timer Stoppen
        T_CheckSAPimport.Stop()

        'Controlls enablen FALSE
        DTP_Datum.Enabled = False
        ComboBox1.Enabled = False
        btn_Anzeigen.Enabled = False
        btn_MenuAuftrag.Enabled = False
        lbl_info.Text = ""

        'Datagridview Inhalten löschen
        'DGV_FAUF.Rows.Clear()
        'Datagridview Zellenhöhe aus Settings laden
        DGV_FAUF.RowTemplate.Height = My.Settings.DGV_Höhe

        'Wats System Status Abfragen
        'Wats Verfügbarkeit zum TESTEN
        'lbl_Status.Text = "Verbindung zu WATS herstellen, bitte warten...."

        'Dim cw As Boolean = Await CheckWats()

        'Dim cb = DirectCast(TblLinieBindingSource.Current, DataRowView).Row

        'If WatsCheck = True AndAlso cb.Item("WatsDatenVorhanden") = True Then
        '    WatsVerfuegbar = True
        'Else
        '    WatsVerfuegbar = False
        'End If


        'BGW Starten
        If Not BGW_Hejiunka.IsBusy Then
            'Combobox casten
            Dim SNP = DirectCast(TblLinieBindingSource.Current, DataRowView).Row

            'Sind Wats oder V-Check Daten Vorhanden? in Globalen Einstellung Speichern
            My.Settings.G_LinieWats = SNP.Item("WatsDatenVorhanden")
            My.Settings.G_vCheckVorhanden = SNP.Item("vCheckDatenVorhanden")

            'Prüfen ob daten in WATS oder v-check verfügbar sind (ist haken in DB gesetzt)
            Select Case True
                Case SNP.Item("WatsDatenVorhanden")
                    'Panel1, Ladebild einblenden mit Wats
                    Panel1.Visible = True
                    lbl_Laden.Text = "WATS Daten werden geladen..." & vbCrLf & "Bitte warten"
                    PB_laden.Image = My.Resources.wats
                    'FPY Spalte einblenden
                    DGV_FAUF.Columns(DGV_Column.FPY).Visible = True
                    'ist Spalte einblenden
                    DGV_FAUF.Columns(DGV_Column.Ist).Visible = True
                    'FAUF Beenden Button ausblenden
                    ToolStripMenuItemFertig.Visible = False
                    btn_Menu_FAUF_Beenden.Visible = False
                    AuftragZurücknehmenToolStripMenuItem.Visible = False
                    AuftragZurücknehmenToolStripMenuItem1.Visible = False
                Case SNP.Item("vCheckDatenVorhanden")
                    'Panel1, Ladebild einblenden mit Wats
                    Panel1.Visible = True
                    lbl_Laden.Text = "v-Check Daten werden geladen..." & vbCrLf & "Bitte warten"
                    PB_laden.Image = My.Resources.valor
                    'FPY Spalte einblenden
                    DGV_FAUF.Columns(DGV_Column.FPY).Visible = True 'Spalte austausceh
                    'ist Spalte einblenden
                    DGV_FAUF.Columns(DGV_Column.Ist).Visible = True 'Spalte Austauschen
                    'FAUF Beenden Button ausblenden
                    ToolStripMenuItemFertig.Visible = False
                    btn_Menu_FAUF_Beenden.Visible = False
                    AuftragZurücknehmenToolStripMenuItem.Visible = False
                    AuftragZurücknehmenToolStripMenuItem1.Visible = False
                Case Else
                    'Panel1, Ladebild einblenden ohne Wats
                    Panel1.Visible = True
                    lbl_Laden.Text = "Daten werden geladen..." & vbCrLf & "Bitte warten"
                    PB_laden.Image = My.Resources.Datenbank
                    'FPY Spalte ausblenden
                    DGV_FAUF.Columns(DGV_Column.FPY).Visible = False
                    'ist Spalte ausblenden
                    DGV_FAUF.Columns(DGV_Column.Ist).Visible = False
                    'FAUF Beenden Button einblenden
                    ToolStripMenuItemFertig.Visible = True
                    btn_Menu_FAUF_Beenden.Visible = True
                    AuftragZurücknehmenToolStripMenuItem.Visible = True
                    AuftragZurücknehmenToolStripMenuItem1.Visible = True
            End Select

            'Prüfen ob der Vorgangstext eingebeldent werden soll
            If My.Settings.showVrgTxt = True Then
                DGV_FAUF.Columns(DGV_Column.vrgText).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.vrgText).Visible = False
            End If

            'Prüfen ob der Lagerotz eingebeldent werden soll
            If My.Settings.LoAnzeigen = True Then
                DGV_FAUF.Columns(DGV_Column.Lagerort).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.Lagerort).Visible = False
            End If

            'Prüfen ob Gearboxnummer eingeblendet werden soll
            If SNP.Item("GruppeTeam") = "CEVA GearBox" Then
                DGV_FAUF.Columns(DGV_Column.Gearbox).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.Gearbox).Visible = False
            End If

            'Prüfen ob LP Nummer eingeblendet werden soll
            If My.Settings.showLPNr = True Then
                DGV_FAUF.Columns(DGV_Column.LPNR).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.LPNR).Visible = False
            End If

            'Prüfen ob end datum abgezeigt werden soll
            If My.Settings.FaufEndDatum = True Then
                DGV_FAUF.Columns(DGV_Column.EndDatum).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.EndDatum).Visible = False
            End If

            'Prüfen on Vorgabezeiten angezeigt werden soll
            If My.Settings.VorgabezeitAnzeigen = True Then
                GroupBox5.Visible = True
            Else
                GroupBox5.Visible = False
            End If

            'Prüfen ob es sich um eine SMT Linie handelt, Spalten mit LP Länge und Breite einblenden
            If SNP.Item("SMT") = True Then
                PCBAbrufenToolStripMenuItem.Visible = True
                LPAbrufenToolStripMenuItem.Visible = True
                DGV_FAUF.Columns(DGV_Column.LPOK).Visible = True
                DGV_FAUF.Columns(DGV_Column.LPBreite).Visible = True
                DGV_FAUF.Columns(DGV_Column.Fixruestung).Visible = True
            Else
                PCBAbrufenToolStripMenuItem.Visible = False
                LPAbrufenToolStripMenuItem.Visible = False
                DGV_FAUF.Columns(DGV_Column.LPOK).Visible = False
                DGV_FAUF.Columns(DGV_Column.LPBreite).Visible = False
                DGV_FAUF.Columns(DGV_Column.Fixruestung).Visible = False
            End If

            'Prüfen ob Linie im Heijunka angezeigt werden soll
            If My.Settings.showLine = True Then
                DGV_FAUF.Columns(DGV_Column.Linie).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.Linie).Visible = False
            End If

            'Prüfen ob v-Check Kontrolle durchgeführt werden muss, Button einblenden und Spalten mit VCheck kontrolle einblenden
            If SNP.Item("VCheckKontrolle") = True Then
                btn_vcheckKont.Visible = True
                AuftragTeilrückmeldenToolStripMenuItem.Visible = True
                AuftragTeilrückmeldenToolStripMenuItem1.Visible = True
                VCheckKontrolleToolStripMenuItem.Visible = True
                DGV_FAUF.Columns(DGV_Column.VCheck).Visible = True
            Else
                AuftragTeilrückmeldenToolStripMenuItem.Visible = False
                AuftragTeilrückmeldenToolStripMenuItem1.Visible = False
                btn_vcheckKont.Visible = False
                VCheckKontrolleToolStripMenuItem.Visible = False
                DGV_FAUF.Columns(DGV_Column.VCheck).Visible = False
            End If

            'Prüfen ob Kommentarspallte im Heijunka angezeigt werden soll
            If My.Settings.Kommentar = True Then
                DGV_FAUF.Columns(DGV_Column.KommentarSpalte).Visible = True
            Else
                DGV_FAUF.Columns(DGV_Column.KommentarSpalte).Visible = False
            End If

            'Prüfen ob Support Button eingeblendet werden soll
            If My.Settings.SupportAktivieren = True Then
                SupportAnftrageStellenToolStripMenuItem.Visible = True
                SupportAnftrageStellenToolStripMenuItem1.Visible = True
            Else
                SupportAnftrageStellenToolStripMenuItem.Visible = False
                SupportAnftrageStellenToolStripMenuItem1.Visible = False
            End If

            'SAP AP in Array spliten, Wenn mehrere SAP APs mit ; separiert in der DB stehen
            Dim vorbereitungStopwatch As Stopwatch = Stopwatch.StartNew()
            Dim SNPAP() As String = Split(SNP.Item("AP"), ";")
            'Datatable leeren
            SAP.DT_Heijunka.Clear()

            'Datum letzter ArbeitsTag
            Dim DateLetzterAt As Date = globalFunction.GetLastWorkDay(DTP_Datum.Value)

            'wenn merere SAP AP gepflegt sind, Array durchlaufen
            For i = 0 To SNPAP.Count - 1
                'für jeden AP in Array Hejiunka Abfrage aus DS durchführen
                Dim qry1 = From rw In SAP.DT_SQ00_Import_FAUF
                           Where rw.ArbPlatz Like SNPAP(i) AndAlso
                                   (DateTime.ParseExact(rw.SpatStartDat, "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo) <= DTP_Datum.Value And
                                    DateTime.ParseExact(rw.SpatStartDat, "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo) >= DateLetzterAt) AndAlso 'DTP_Datum.Value.AddDays(-1))
                                   rw.SystemStatus.Contains(My.Settings.Systemstatus)
                           Order By rw.FrueStartZeit

                'ergebinise in Datatable speichern
                For Each item In qry1
                    SAP.DT_Heijunka.AddDT_HeijunkaRow(item.Auftrag, item.Vorgang, item.Material, item.FertS,
                                                                      item.ArbPlatz, item.VorgangText, item.FertS, item.FrueStartZeit,
                                                                      item.SpatStartDat, item.SpatStartzeit, item.Vorgangsmenge, item.RueckGutMenge,
                                                                      item.Ausschuss, item.Anwenderstatus, item.SystemStatus)
                Next
            Next
            vorbereitungStopwatch.Stop()
            log.WriteLog(Date.Now, "", "", "", $"Vorbereitung (UI-Thread, GetLastWorkDay + SAP.DT_Heijunka aufbauen): {vorbereitungStopwatch.ElapsedMilliseconds} ms")

            'zusammengefasste daten in LINQ abfrage übergeben, für sortierung oder sonstiges
            Dim qry = From d In SAP.DT_Heijunka
                      Order By d.SpatStartDat 'Order By d.Field(Of String)("SpatStartDat") 'My.Settings.SortHeijunka

            'Checken ob überhaupt Aufträge in der qry vorhanden sind, um zu entscheiden ob der
            'BackgroundWorker gestartet wird bzw. wie hoch der Fortschrittsbalken maximal geht.
            'Vorher wurde hier pro Zeile dieselbe teure SAP-XML Auswertung wie später im DoWork
            'nochmal gemacht (u.a. um exakt zu filtern, welche Zeilen "gestern schon erledigt" sind) -
            'das lief aber auf dem UI-Thread VOR dem Start des BackgroundWorkers und hat die UI für
            'mehrere Sekunden komplett eingefroren. Die genaue Filterung passiert weiterhin (unverändert)
            'innerhalb von DoWork; hier reicht eine grobe, günstige Zählung ohne XML-Zugriffe.
            Dim vorabCountStopwatch As Stopwatch = Stopwatch.StartNew()
            Dim Count As Integer = qry.Count()
            vorabCountStopwatch.Stop()
            log.WriteLog(Date.Now, "", "", "", $"Vorab-Zählung (UI-Thread, vor WATS/DoWork): {vorabCountStopwatch.ElapsedMilliseconds} ms")

            'Sind Datensätze vorhanden? 
            If Count > 0 Then
#Region "Test"
                'Daten schon mal im voraus anzeigen VERSUCH
                'If Not DropdownChange = ComboBox1.Text Or FirstStart = True Then
                '    DropdownChange = ComboBox1.Text
                '    FirstStart = False
                '    DGV_FAUF.Rows.Clear()
                '    Dim y As Integer = 0
                '    For Each r In qry.AsEnumerable
                '        'Fauf Pfad des Auftrags
                '        'Dim FaufPfad As String = SAP_XML.PathFAUF_XML(r("Auftrag"))

                '        DGV_FAUF.Rows.Add(r("Material")) 'Spalte dient nur der Anzeige
                '        'If My.Settings.ASN_Anzeigen = True Then
                '        '    'Abfrage ASN aus ASN SSN Matchtable
                '        '    Dim ASN As String = SSN_ASN_TabTableAdapter1.qry_getASN(r("Material"))
                '        '    If Not ASN = "" Or Not String.IsNullOrEmpty(ASN) Then
                '        '        DGV_FAUF.Rows.Add(ASN)
                '        '    Else
                '        '        DGV_FAUF.Rows.Add(r("Material"))
                '        '    End If
                '        'Else
                '        '    DGV_FAUF.Rows.Add(r("Material"))
                '        'End If
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.SAPMAT).Value = r("Material")
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Auftrag).Value = r("Auftrag")
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Soll).Value = CInt(r("Vorgangsmenge").replace(".", ""))
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Ist).Value = "0"
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Ist_SAP).Value = "0"
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Vrg).Value = r("Vorgang")
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.SAPAP).Value = r("ArbPlatz")
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.Zeit).Value = r("FrueStartZeit")
                '        DGV_FAUF.Rows(y).Cells(DGV_Column.SystemStatus).Value = r("SystemStatus")
                '        If r("Anwenderstatus") = "UMTE" Then
                '            DGV_FAUF.Rows(y).Cells(DGV_Column.U).Value = "U"
                '        End If

                '        'Ist Wert aus SAP FAUF XML laden
                '        'Dim SAP_Ist As Integer = globalFunction.GetReportedBackQuantity(FaufPfad)
                '        'Dim SAP_Truc As Integer = globalFunction.GetReportedBackQuantityTRUC(FaufPfad, r("ArbPlatz"), r("Vorgang"))

                '        'If SAP_Ist = 0 And SAP_Truc > 0 Then
                '        '    DGV_FAUF.Rows(y).Cells(DGV_Column.Ist_SAP).Value = SAP_Truc
                '        'Else
                '        '    DGV_FAUF.Rows(y).Cells(DGV_Column.Ist_SAP).Value = SAP_Ist
                '        'End If

                '        y = y + 1
                '    Next
                'End If

                'Versuch ENDE
                '______________________________________________________________________
#End Region
                'Ladebalken auf 1 setzten
                PB_Status.Value = 0
                'Anzahl Aufträge Heijunka als Maximum für Ladebalken setzen + 2 für FPY berechnung
                PB_Status.Maximum = Count + 2
                'BGW Starten (LINQ Abfrage und WatsdatenVorhanden? übergeben)
                'prüfen ob Station und LineName in Datenbank angegeben wurde
                If Not IsDBNull(SNP.Item("station")) And Not IsDBNull(SNP.Item("LineName")) Then
                    BGW_Hejiunka.RunWorkerAsync(New HeijunkaArgument With {.Query = qry, .WatsVorhanden = SNP.Item("WatsDatenVorhanden"), .vcheckVorhanden = SNP.Item("vCheckDatenVorhanden"), .Station = SNP.Item("station"), .LineName = SNP.Item("LineName"), .SMT = SNP.Item("SMT"), .vc_kont = SNP.Item("VCheckKontrolle"), .Linie = SNP.Item("Linie"), .Segment = SNP.Item("Gruppe"), .Team = SNP.Item("GruppeTeam"), .TestOP = SNP.Item("testOP")})
                Else
                    'prüfen ob LineName in Datenbank angegeben wurde
                    If Not IsDBNull(SNP.Item("LineName")) Then
                        BGW_Hejiunka.RunWorkerAsync(New HeijunkaArgument With {.Query = qry, .WatsVorhanden = SNP.Item("WatsDatenVorhanden"), .vcheckVorhanden = SNP.Item("vCheckDatenVorhanden"), .Station = "", .LineName = SNP.Item("LineName"), .SMT = SNP.Item("SMT"), .vc_kont = SNP.Item("VCheckKontrolle"), .Linie = SNP.Item("Linie"), .Segment = SNP.Item("Gruppe"), .Team = SNP.Item("GruppeTeam"), .TestOP = SNP.Item("testOP")})
                    Else
                        BGW_Hejiunka.RunWorkerAsync(New HeijunkaArgument With {.Query = qry, .WatsVorhanden = SNP.Item("WatsDatenVorhanden"), .vcheckVorhanden = SNP.Item("vCheckDatenVorhanden"), .Station = "", .LineName = "", .SMT = SNP.Item("SMT"), .vc_kont = SNP.Item("VCheckKontrolle"), .Linie = SNP.Item("Linie"), .Segment = SNP.Item("Gruppe"), .Team = SNP.Item("GruppeTeam"), .TestOP = SNP.Item("testOP")})
                    End If
                End If

            Else
                'es sind keine Daten vorhanden
                mqtt_Send_Status("Bereit")

                Panel1.Visible = True
                PB_laden.Image = Nothing
                lbl_Laden.Text = "Keine Daten für " & ComboBox1.Text & " vorhanden"
            End If

        End If

        'Controlls enable = TRUE
        DTP_Datum.Enabled = True
        ComboBox1.Enabled = True
        btn_Anzeigen.Enabled = True

    End Sub


#End Region

#Region "WATS Funktionen"

    ''' <summary>
    ''' WATS DATEN 
    ''' </summary>
    Private Async Function WATS_Daten(FAUF As String, Soll As Integer, Durchgang As Integer, testOP As String, station As String) As Task(Of WatsRueckgabewerte)
        Dim w As New WatsRueckgabewerte
        Try
            Dim json As String = Await Wats.Wats_PostAsync(My.Settings.WatsUutReportPath, FAUF, Nothing, Nothing, station, Durchgang, testOP)
            If String.IsNullOrEmpty(json) Then Return w

            Dim WatsInhalt = JsonConvert.DeserializeObject(Of List(Of JSON_data))(json)
            If WatsInhalt Is Nothing Then Return w

            'LINQ Query Sortierung nach Datum!!!
            Dim query =
            From WatsData In WatsInhalt
            Order By WatsData.dateTimeUtc

            Dim Fails As Integer = 0
            w.totalPassed = 0

            Dim i As Integer = 0
            'Stückzahlen für Datumsbestimmung
            Dim viertel As Integer = CInt(Soll / 4 * 1)
            Dim halb As Integer = CInt(Soll / 4 * 2)
            Dim dreiviertel As Integer = CInt(Soll / 4 * 3)
            Dim voll As Integer = CInt(Soll / 4 * 4)

            For Each WatsData In query
                i = i + 1
                w.totalPassed = w.totalPassed + 1
                If WatsData.status = "Failed" Then
                    Fails = Fails + 1
                End If
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

            w.failed = Fails
        Catch ex As Exception
            log.WriteLog(Date.Now, "", "", "", $"WATS_Daten Fehler FAUF {FAUF}: {ex.Message}")
        End Try
        Return w
    End Function
    Private Async Function FPY_Aktuell(DateFrom As String, DateTo As String, Station As String, Durchgang As Integer, testOP As String) As Task(Of WatsRueckgabewerte)
        Dim w As New WatsRueckgabewerte
        Try
            Dim json As String = Await Wats.Wats_PostAsync(My.Settings.WatsUutReportPath, "", DateFrom, DateTo, Station, Durchgang, testOP)
            If String.IsNullOrEmpty(json) Then Return w

            Dim WatsInhalt = JsonConvert.DeserializeObject(Of List(Of JSON_data))(json)
            If WatsInhalt Is Nothing Then Return w

            'LINQ Query Sortierung nach Datum!!!
            Dim query =
            From WatsData In WatsInhalt
            Order By WatsData.dateTimeUtc

            w.totalPassed = 0
            w.failed = 0

            For Each WatsData In query
                w.totalPassed = w.totalPassed + 1
                If WatsData.status = "Failed" Then
                    w.failed = w.failed + 1
                End If
            Next
        Catch ex As Exception
            log.WriteLog(Date.Now, "", "", "", $"FPY_Aktuell Fehler Station {Station}: {ex.Message}")
        End Try
        Return w
    End Function

    Private Async Function CheckWats() As Task(Of Boolean)
        Dim WatsRespose As String = Await Wats.WATS_GetAsync(My.Settings.WatsVersionPath)
        If WatsRespose = Nothing Then
            Console.WriteLine("Wats Reagiert nicht!")
            Dim log As New logging
            log.WriteLog(Date.Now, "", "", "", "WATS reagiert nicht")
            Return False
        Else
            Console.WriteLine("Wats Version" & WatsRespose.ToString)
            Return True
        End If
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
#End Region

#Region "Wochentag Funktion"
    ''' <summary>
    ''' Farben bestimmen
    ''' </summary>
    Friend Structure HeijunkaFarben
        Public BackColor As Color
        Public FrontColor As Color
        Public FarbText As String
    End Structure

    Private Function FarbCodeTag(datum As Date) As HeijunkaFarben
        Dim farben As HeijunkaFarben

        Select Case datum.DayOfWeek
            Case DayOfWeek.Monday
                farben.BackColor = Color.Black
                farben.FrontColor = Color.White
                farben.FarbText = "scharz"
            Case DayOfWeek.Tuesday
                farben.BackColor = Color.Green
                farben.FrontColor = Color.Black
                farben.FarbText = "gruen"
            Case DayOfWeek.Wednesday
                farben.BackColor = Color.Red
                farben.FrontColor = Color.Black
                farben.FarbText = "rot"
            Case DayOfWeek.Thursday
                farben.BackColor = Color.Blue
                farben.FrontColor = Color.White
                farben.FarbText = "blau"
            Case DayOfWeek.Friday
                farben.BackColor = Color.Orange
                farben.FrontColor = Color.White
                farben.FarbText = "braun"
            Case Else
                farben.BackColor = Color.Black
                farben.FrontColor = Color.White
                farben.FarbText = "scharz"
        End Select
        Return farben
    End Function

#End Region

#Region "Timer Funktionen"

    ''' <summary>
    ''' Timer Funktionen
    ''' </summary>
    Private Sub T_PB_Tick(sender As Object, e As EventArgs) Handles T_PB.Tick
        'Ladebalken und label zurücksetzten
        PB_Status.Value = 0
        lbl_Status.Text = "Bereit"
        T_PB.Stop()
    End Sub

    ''' <summary>
    ''' Verhindert, dass Hintergrund-Timer während eines offenen modalen Dialogs (Barcode-Scan,
    ''' Rückmeldung, Stückliste, v-Check, Info-Popup etc.) das DGV_FAUF neu befüllen und dadurch
    ''' die aktuell selektierte Row ungültig oder falsch machen. In Form1.vb wird jeder Dialog nur
    ''' per ShowDialog() (modal) geöffnet, nie per Show() - daher zeigt mehr als ein offenes Form
    ''' zuverlässig einen aktiven Dialog an.
    ''' </summary>
    Private Function IstModalerDialogOffen() As Boolean
        Return Application.OpenForms.Count > 1
    End Function

    Private Sub T_WatsRefresh_Tick(sender As Object, e As EventArgs) Handles T_WatsRefresh.Tick
        If IstModalerDialogOffen() Then Exit Sub

        'Ruft Sub Hejiunka Anzeigen auf
        'Debug.WriteLine("Timer Tick")
        HejiunkaAnzeigen()
    End Sub

    Private Sub T_FW_SAP_import_Tick(sender As Object, e As EventArgs) Handles T_FW_SAP_import.Tick
        SAP_Import()
        T_FW_SAP_import.Stop()
        T_WatsRefresh.Start()
    End Sub

    Private Sub T_neuerTag_Tick(sender As Object, e As EventArgs) Handles T_neuerTag.Tick
        'Init() setzt u.a. ComboBox1 und DTP_Datum zurück und würde bei offenem Dialog dieselbe
        'Row-Invalidierung auslösen wie HejiunkaAnzeigen - daher hier ebenfalls zurückstellen.
        If IstModalerDialogOffen() Then Exit Sub

        'Überprüft alle 15min das Datum fals sich der Tag geändert hat
        If lbl_Menu_Wochentag.Text <> Now.ToString("dddd", New CultureInfo("de-DE")) & " " & Now.ToShortDateString Then
            'SAP-XML Cache leeren, damit er nicht unbegrenzt über die Tage/Wochen weiterwächst
            SAP_XML.ClearCache()
            Init()
        End If
    End Sub

    Private Sub T_CheckSAPimport_Tick(sender As Object, e As EventArgs) Handles T_CheckSAPimport.Tick
        ' Timer für die erkennung ob sich das SAP File geändert hat das jedoch nicht durch den FileWatcher erkennt wurde
        ' Lesen des erstellungsdatum und vergleichen mit dem letzten Datum in den Settings
        'Try Catch für das abfagen des Fehlers bei einer Netzwerkunterbrechung
        Try
            Dim DatumLetzterExport As Date = System.IO.File.GetLastWriteTime(My.Settings.ExportPfadRemote)
            If DatumLetzterExport > My.Settings.letzerSAPimport Then
                'SAP daten neu Laden
                SAP.DT_SQ00_Import_FAUF.Clear()
                SAP_Import()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "ReColoring"
    Public Function PixelRePaint(ByVal SourceImage As Image, ByVal OldColor As Color, ByVal NewColor As Color) As Bitmap
        Dim NewBitmap As New Bitmap(SourceImage.Width, SourceImage.Height)
        Dim CMap(0) As ColorMap

        CMap(0) = New ColorMap
        CMap(0).OldColor = OldColor
        CMap(0).NewColor = NewColor

        Dim ImgAttr As New ImageAttributes
        ImgAttr.SetRemapTable(CMap)

        Using G As Graphics = Graphics.FromImage(NewBitmap)
            G.DrawImage(SourceImage,
                New Rectangle(0, 0, SourceImage.Width, SourceImage.Height), 0, 0,
                SourceImage.Width,
                SourceImage.Height,
                GraphicsUnit.Pixel,
                ImgAttr)
        End Using

        Return NewBitmap
    End Function

    ' Die 4 Quellbilder ändern sich zur Laufzeit nie - werden daher einmalig von der Netzwerkfreigabe
    ' geladen und danach wiederverwendet, statt bei jedem RePaintedCircle/RePaintedFullCircle Aufruf
    ' (mehrfach pro Zeile im DataGridView) erneut von dort gelesen zu werden.
    Private Shared ReadOnly QuellBilderCache As New Dictionary(Of String, Bitmap)

    Private Function GetQuellBild(pfad As String) As Bitmap
        Dim bmp As Bitmap = Nothing
        If Not QuellBilderCache.TryGetValue(pfad, bmp) Then
            bmp = New Bitmap(pfad)
            QuellBilderCache(pfad) = bmp
        End If
        Return bmp
    End Function

    Public Function RePaintedCircle(oldColor As Color, newColor As Color) As Bitmap
        Dim bmp1 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\1.png"), oldColor, newColor)
        Dim bmp2 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\2.png"), oldColor, newColor)
        Dim bmp3 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\3.png"), oldColor, newColor)
        Dim bmp4 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\4.png"), oldColor, newColor)

        Dim final As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(final)
        g.DrawImage(bmp1, New Point(25, 0))
        g.DrawImage(bmp2, New Point(25, 25))
        g.DrawImage(bmp3, New Point(0, 25))
        g.DrawImage(bmp4, New Point(0, 0))

        Return final
    End Function

    Public Function RePaintedFullCircle(oldColor As Color, _1 As Color, _2 As Color, _3 As Color, _4 As Color) As Bitmap
        Dim bmp1 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\1.png"), oldColor, _1)
        Dim bmp2 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\2.png"), oldColor, _2)
        Dim bmp3 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\3.png"), oldColor, _3)
        Dim bmp4 As Bitmap = PixelRePaint(GetQuellBild("\\ch021093\data\Standards\Tools\Produktionskontrolle\misc\Bilder\4.png"), oldColor, _4)

        Dim final As New Bitmap(50, 50)
        Dim g As Graphics = Graphics.FromImage(final)
        g.DrawImage(bmp1, New Point(25, 0))
        g.DrawImage(bmp2, New Point(25, 25))
        g.DrawImage(bmp3, New Point(0, 25))
        g.DrawImage(bmp4, New Point(0, 0))

        Return final
    End Function
#End Region

#Region "EventHandler und EventArgs Klassen"
    Private Sub ProdKontColorEventHandler(sender As Object, e As ColoringHeijunkaEventArgs)
        DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
        DGV_FAUF.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
    End Sub

    Private Sub IncidentColorEventHandler(sender As Object, e As ColoringHeijunkaIncidentEventArgs)
        Select Case e.ColorSet
            Case 0
                DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.Status).Value = My.Resources.help_desk
                DGV_FAUF.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.OrangeRed
            Case 1
                DGV_FAUF.Rows(e.RowIndex).Cells(DGV_Column.Status).Value = Nothing
                lbl_info.Text = ""
                DGV_FAUF.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Black

        End Select

    End Sub
    Private Sub SettingsEventHandler(sender As Object, e As SettingsHeijunkaEventArgs)

        Select Case e.ObjektName
            Case "Linie"
                DGV_FAUF.Columns(DGV_Column.Linie).Visible = e.Visible
            Case "EndDatum"
                DGV_FAUF.Columns(DGV_Column.EndDatum).Visible = e.Visible
            Case "Vorgangstext"
                DGV_FAUF.Columns(DGV_Column.vrgText).Visible = e.Visible
            Case "LpNummer"
                DGV_FAUF.Columns(DGV_Column.LPNR).Visible = e.Visible
            Case "Kommentare"
                DGV_FAUF.Columns(DGV_Column.KommentarSpalte).Visible = e.Visible
            Case "Lagerort"
                DGV_FAUF.Columns(DGV_Column.Lagerort).Visible = e.Visible
            Case "Vorgabezeit"
                GroupBox5.Visible = e.Visible
        End Select




    End Sub
    Public Class ColoringHeijunkaEventArgs
        Public Property RowIndex As Integer
    End Class
    Public Class ColoringHeijunkaIncidentEventArgs
        Public Property RowIndex As Integer
        Public Property ColorSet As Integer
    End Class
    Public Class SettingsHeijunkaEventArgs
        Public Property ObjektName As String
        Public Property Visible As Boolean
    End Class
#End Region

#Region "Button Funktionen"
    ''' <summary>
    ''' Prüft, ob die zuletzt in DGV_FAUF angeklickte Zeile (Row) noch existiert. Row kann ungültig
    ''' werden, wenn zwischen Auswahl der Zeile und einer Auftragsaktion ein modaler Dialog offen war
    ''' (z.B. das Barcode-Formular in FAUF_Start) und währenddessen im Hintergrund eine Aktualisierung
    ''' durchgelaufen ist, die das Grid mit weniger Zeilen neu aufgebaut hat - ohne diese Prüfung
    ''' führte das zu einer ArgumentOutOfRangeException.
    ''' </summary>
    Private Function ZeileNochGueltig(methodenName As String) As Boolean
        If Row < 0 OrElse Row >= DGV_FAUF.Rows.Count Then
            log.WriteLog(Date.Now, "", "", "", $"{methodenName}: Zeile {Row} nicht mehr gültig (Grid hat aktuell {DGV_FAUF.Rows.Count} Zeilen) - abgebrochen")
            Return False
        End If
        Return True
    End Function

    Sub ProdKontErledigen(AuftragsStartAktiv As Boolean)
        If Not ZeileNochGueltig("ProdKontErledigen") Then Exit Sub

        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString
        Dim Auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim Vrg As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString

        'Prod Kontrolle eintrag auslesen - nur die Zeilen dieses Auftrags/Vorgangs laden statt der
        'kompletten (über die Zeit wachsenden) Tabelle
        Dim qry = globalFunction.GetOffeneProdKontrolleByFAUF(Auftrag, Vrg)
        If qry.Rows.Count > 0 Then
            If qry.Rows.Count = 1 Then
                Tbl_ProdKontrolleTableAdapter.UpdateStatus("erledigt", Auftrag, Vrg)
                DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.Black
                DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.leer1
                'DGV Zelle nicht markieren
                DGV_FAUF.CurrentCell.Selected = False
                'info löschen
                lbl_info.Text = ""

                'Protokoll schreiben
                'globalFunction.SetProtocol(Auftrag, AP, "ProdKont", "ProdKontrolle abgeschlossen")
            Else
                Dim f As New frm_ProdKontrolle_Detail(qry, Auftrag, True, AuftragsStartAktiv)
                f.ShowDialog()
                qry = globalFunction.GetOffeneProdKontrolleByFAUF(Auftrag, Vrg)

                If qry.Rows.Count = 0 Then
                    DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.Black
                    DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.leer1
                    'DGV Zelle nicht markieren
                    DGV_FAUF.CurrentCell.Selected = False
                    'info löschen
                    lbl_info.Text = ""
                End If
            End If
        End If
    End Sub
    Sub FAUF_Start()
        If Not ZeileNochGueltig("FAUF_Start") Then Exit Sub

        'FAUF Nummer Aus selektierter Row auslesen
        Dim auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim vorgang As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString
        Dim istSMT As Boolean = False
        Dim ASN As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim soll As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ist As Integer = DGV_FAUF(DGV_Column.Ist, Row).Value
        Dim ausnahme As String = DGV_FAUF(DGV_Column.ausnahme, Row).Value
        Dim CB = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        Dim AblieferOrt As String = ""
        Dim SysStatus As String = DGV_FAUF(DGV_Column.SystemStatus, Row).Value.ToString
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString
        Dim MatStatus As String = DGV_FAUF(DGV_Column.MatPPStatus, Row).Value.ToString

        'Prüfen ob APLA XML vorhanden, ansonsten evtl Z1 im SAP
        Dim APLA_Pfad As String = SAP_XML.PathAPLA_XML(auftrag, ASN)
        If APLA_Pfad = Nothing Then
            'PathAPLA_XML zeigt bei fehlender Datei bereits eine eigene Fehlermeldung an - hier nur
            'noch den Auftragsstart abbrechen, ohne ein zweites, fast identisches Dialogfenster
            Exit Sub
        End If

        'Spez Info beim Auftragsstart anzeigen
        Try
            Dim Lines() As String = globalFunction.ReadAllLinesCached(My.Settings.PfadFaufInfo)
            For Each l As String In Lines
                Try
                    Dim split() As String = l.Split(";")
                    If split.Length >= 2 AndAlso ASN = split(0) Then
                        'Form öffnen und split(1) anzeigen
                        Dim f As New frm_Info("Information für Material: " & split(0), split(1))
                        f.ShowDialog()
                    End If
                Catch ex As Exception
                    log.WriteLog(Date.Now, "", "", "", $"FAUF-Start: fehlerhafte Zeile in FaufInfo-Datei übersprungen: {l}")
                End Try
            Next
        Catch ex As Exception
            log.WriteLog(Date.Now, "", "", "", $"FAUF-Start: FaufInfo-Datei konnte nicht gelesen werden: {ex.Message}")
        End Try

        'Row kann während der offenen Info-Dialoge durch eine Hintergrund-Aktualisierung ungültig geworden sein
        If Not ZeileNochGueltig("FAUF_Start") Then Exit Sub

        If My.Settings.G_LinieWats = False Or ausnahme = "True" Then
            'Es sind keine WATS Daten vorhanden, Eintrag in DB wird erstellt
            'Überprüfen ob Auftrag bereits in DB ist
            Dim AuftragVorhanden As Integer = CInt(Tbl_FAUF_StatusTableAdapter.GetStatus(auftrag & "_" & vorgang))
            If AuftragVorhanden = 0 Then
                'Auftragsnummer, Status und Datum in DB schreiben
                'ProdDatum wird als VARCHAR gespeichert - ISO-Format (kulturunabhängig) verwenden, damit
                'das Datum unabhängig von der Kultur des lesenden Clients wieder eingelesen werden kann
                Tbl_FAUF_StatusTableAdapter.InsertQuery(auftrag & "_" & vorgang, Now.ToString("yyyy-MM-dd"), 0, "1")
                'Richtige Farbe anhand des heutigen Datums in DGV anzeigen
                DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.ResourceManager.GetObject(FarbCodeTag(Now).FarbText & "_halb")

                'Auftrag Start in Protokoll schreiben
                'globalFunction.SetProtocol(auftrag, AP, "Auftrag", "Auftrag gestartet")
            End If
        End If

        'Abfrage SMT (Ablieferort raussuchen)
        If My.Settings.FAUF_Start = "SMT" Then
            Dim DS_APLA As New DataSet()

            'Formular für die Abfrage der PCB öffnen und gescannte PCB vergleichen mit benötigter PCB
            If CB.Item("SMT") = True Then
                Dim tbl_Adapter As New tbl_lp_checkTableAdapter
                Dim Count As Integer = tbl_Adapter.GetAuftrag(auftrag)
                'Abfrage aus DB, Wurde die PCB schon mal gescannt?
                If Count = 0 Then
                    Dim f As New frm_scanPcb(DGV_FAUF.Rows(Row).Cells(DGV_Column.LPNR).Value.ToString, auftrag)
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.No Then
                        MsgBox("Es wurde die Falsche Leiterplatte eingescannt!", vbCritical, "Fehler")
                        Exit Sub
                    End If
                End If
            End If

            istSMT = True
            DS_APLA = SAP_XML.ReadXML2DS(APLA_Pfad)

            Dim MARX As DataTable = DS_APLA.Tables("ZE1_DMSOP_MARX")

            'Falls die Tabelle in der APLA-XML fehlt (z.B. unvollständiger Export) überspringen
            If Not IsNothing(MARX) Then
                Dim qryLO =
                    From M In MARX.AsEnumerable()
                    Select New With
                        {
                        .LO = M.Field(Of String)("LGPRO")
                        }
                For Each item In qryLO
                    AblieferOrt = item.LO
                Next
            End If
        End If
        'Prüfen ob Material den Status U1 gesperrt hat
        If InStr(MatStatus, "U1") = True Then
            MsgBox("Auftrag kann nicht gestartet werden MaterialStatus U1 gesperrt. Bitte Teamleiter Informieren", vbCritical, "!!!Material Gesperrt!!!")
            Exit Sub
        End If

        ' Hier Sinteso Logik für Start von Band 1 und Band 2 mit DMC Code Scanner für Verpackungssack. Wenn Code OK (Materialnummer stimmt überein) kann initalisiert werden.




        'Prüfen ob Status GLFT im Systemstatus gelesen wurde = FAUF Rückgemeldet!!
        If InStr(SysStatus, "GLFT") = False Then
            AuftragStartAusfuehren(auftrag, ASN, soll, AblieferOrt)
        Else
            Select Case MessageBox.Show("Der Auftrag wurde bereits Rückgemeldet!" & vbCrLf & "Wollen Sie den Auftrag starten?", "ACHTUNG", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes
                    AuftragStartAusfuehren(auftrag, ASN, soll, AblieferOrt)
                    'Auftrag Start in Protokoll schreiben
                    'globalFunction.SetProtocol(auftrag, AP, "Auftrag", "Auftrag wurde gestartet obwohl er bereits Rückgemeldet ist")
                Case Windows.Forms.DialogResult.No
                    Exit Sub
            End Select
        End If

        'Auftrag Start in Protokoll schreiben
        If My.Settings.Logging = True Then
            log.WriteLog(Date.Now, My.Settings.Linie, auftrag, ASN, "Auftrag gestartet")
        End If
    End Sub

    ''' <summary>
    ''' Gemeinsamer Ablauf für den Auftragsstart, egal ob der Auftrag noch nicht rückgemeldet ist
    ''' oder der Benutzer den Start trotz bereits erfolgter Rückmeldung bestätigt hat - vorher waren
    ''' das zwei fast wortgleiche, unabhängig gepflegte Codeblöcke in FAUF_Start.
    ''' </summary>
    Private Sub AuftragStartAusfuehren(auftrag As String, ASN As String, soll As Integer, AblieferOrt As String)
        'Daten in Ini File Schreiben für Linien Initialisierung über Digital Heijunka
        Dim uTime As Double
        uTime = (DateTime.UtcNow - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
        ini_Autostart.WertSchreiben(My.Settings.Linie, "FAUF", auftrag)
        ini_Autostart.WertSchreiben(My.Settings.Linie, "Date", uTime)
        globalFunction.WriteFaufInitToDb(My.Settings.Linie, auftrag)

        'Barcode Form anzeigen
        'Prüfen ob FAUF noch nicht abgeschlossen
        'If ist < soll Then
        'Form instanzieren
        Dim frm_barcode As New Frm_Barcodevb(ASN, auftrag, soll, "Auftrag Starten", AblieferOrt, My.Settings.FAUF_Start)
        'Form öffen
        If Not My.Settings.FAUF_Start = "nichts" Then
            frm_barcode.ShowDialog()
        End If

        'Prod Kontrolle eintrag auslesen und abschliessen, True wird für die Anzeige bei mehrfach
        'eingetragenen Produktionskontrollen mitgegeben, damit diese auch erledigt werden.
        ProdKontErledigen(True)

        'Checkliste Anzeigen?
        'Row kann hier ungültig sein, wenn während des offenen Barcode-Dialogs im Hintergrund
        'eine Aktualisierung durchgelaufen ist, die das Grid mit weniger Zeilen neu aufgebaut hat.
        If My.Settings.Checkliste = True AndAlso ZeileNochGueltig("AuftragStartAusfuehren") Then
            globalFunction.ChkList(DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString)
        End If
    End Sub

    Sub FAUF_Ruckmelden()
        If Not ZeileNochGueltig("FAUF_Ruckmelden") Then Exit Sub

        'Variablen füllen aus selektierter Row
        Dim FAUF As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim ASN As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim SollStk As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim MatPPStatus As String = DGV_FAUF(DGV_Column.MatPPStatus, Row).Value.ToString

        'Variable für Behälter inhalt
        Dim BehMenge As Integer = 0
        'DS fürRückmeldecode
        Dim DS As New System.Data.DataSet()
        'DT fürBehältermenge
        Dim DS_APLA As New DataSet()
        Dim qryBeh As Object = Nothing
        'DS für FAUF
        Dim DS_FAUF As New DataSet()

        'Combi Casten
        Dim cmb = DirectCast(TblLinieBindingSource.Current, DataRowView).Row

        'Für v-Check Kontrolle, überprüfen ob v-check kontrolle erledigt wurde, wenn ja kann auftrag
        'rückgemeldet werden, wenn nein, kommt eine Meldung und der Sub wird abgebrochen
        If cmb.Item("VCheckKontrolle") = True Then
            If TeilRueckmeldungen = False Then
                'Vcheck TextFile auslesen und durchsuchen
                Dim Pfad As String = My.Settings.vcheckkontrollePfad
                Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)
                'Text Datei in Datatable schreiben
                For Each l As String In Lines
                    Dim split() As String = l.Split(";")
                    'prüfen ob v-Check kontrolle gemacht werden muss
                    If split(0) = ASN And split(1) = DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPAP).Value Then
                        If IsNothing(Tbl_vcheckKontrolleTableAdapter1.getAuftragsnummer(FAUF, cmb.Item("Linie"))) Then
                            MsgBox("v-Check Kontrolle wurde noch nicht erledigt!", vbCritical, "v-Check Kontrolle")
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If

        'Prüfen ob eine Änderung Aktiv ist, wenn ja Meldung anzeigen, nur bei endrückmeldung!
        If MatPPStatus = "UA" Then
            MsgBox("Änderung muss abgeschlossen werden!" & vbCrLf & "Bitte Meldung an Teamleiter machen.", vbInformation, "Änderung Aktiv")
        End If


#Region "Behältergrösse raussuchen"
        DS_APLA = SAP_XML.ReadXML2DS(SAP_XML.PathAPLA_XML(FAUF, ASN))
        Dim BehaelterDaten As DataTable = DS_APLA.Tables("ZE1_DMSOP_MATBEH")
        'Falls keine Behälterdaten gepflegt sind überspringen
        If Not IsNothing(BehaelterDaten) Then
            qryBeh =
            From b In BehaelterDaten.AsEnumerable()
            Select New With
                {
                .BH_Typ = b.Field(Of String)("DCBEH"),
                .BH_Stk = b.Field(Of String)("DCBMG")
                }

        End If

#End Region

#Region "Rückmeldenummer raussuchen"
        DS = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))

        Dim Vorgaenge As DataTable = DS.Tables("E1AFVOL")
        Dim VorgDetail As DataTable = DS.Tables("ZE1_DMSOP_AFVX")

        'Ohne diese Tabellen kann keine Rückmeldenummer ermittelt werden (unvollständige FAUF-XML)
        If IsNothing(Vorgaenge) OrElse IsNothing(VorgDetail) Then
            MsgBox("Rückmeldedaten (Vorgänge) konnten nicht aus der FAUF-XML gelesen werden.", vbCritical, "Fehler")
            Exit Sub
        End If

        Dim qryvrg =
        From vrg In Vorgaenge.AsEnumerable()
        Join det In VorgDetail.AsEnumerable()
        On vrg.Field(Of Integer)("E1AFVOL_Id") Equals
                det.Field(Of Integer)("E1AFVOL_Id")
        Order By vrg.Field(Of String)("VORNR")
        Select New With
        {
            .VrgNr = vrg.Field(Of String)("VORNR"), 'Vorgangsnummer
            .LT = vrg.Field(Of String)("LTXA1"), 'Langtext
            .StrSchl = vrg.Field(Of String)("STEUS"),'Steuerschlüssel
            .Rueck = det.Field(Of String)("RUECK") 'Rückmeldecode
        }
#End Region

#Region "Farbige Melder"
        Dim FarbigeMelder As New FarbigeMelder
        FarbigeMelder = globalFunction.GetFarbigeMelderData(FAUF)


#End Region
        'Form definieren und Variablen an Form übergeben
        'Prüfen ob Status GLFT im Systemstatus gelesen wurde.
        'Prüfen ob Behälterdaten vorhanden sind, ansonsten anstelle von qryBeh ein Nothing übergeben
        If Not IsNothing(BehaelterDaten) Then
            Dim RuckmeldeForm As New frm_Ruckmelden(ASN, FAUF, qryvrg, qryBeh, SollStk, FarbigeMelder)
            RuckmeldeForm.ShowDialog()
        Else
            Dim RuckmeldeForm As New frm_Ruckmelden(ASN, FAUF, qryvrg, Nothing, SollStk, FarbigeMelder)
            RuckmeldeForm.ShowDialog()
        End If
    End Sub
    Sub FAUF_Stuli()
        If Not ZeileNochGueltig("FAUF_Stuli") Then Exit Sub

        'Variablen füllen aus selektierter Row
        Dim FAUF As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim ASN As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim Soll As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ist As Integer = DGV_FAUF(DGV_Column.Ist, Row).Value
        Dim vrg As String = DGV_FAUF(DGV_Column.Vrg, Row).Value
        Dim combiBox = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        Dim Gruppe As String = combiBox.Item("Gruppe")

        'Form definieren und Variablen an Form übergeben
        Dim StuliForm As New frm_Stueckliste(FAUF, ASN, Soll, Gruppe, ist, ComboBox1.Text, vrg)
        'Row kann während des offenen Dialogs durch eine Hintergrund-Aktualisierung ungültig geworden sein
        If StuliForm.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK AndAlso ZeileNochGueltig("FAUF_Stuli") Then
            DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
            DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.Red
        End If
        'StuliForm.ShowDialog()

    End Sub
    Sub FAUF_Beenden() ' Nur für Geräte ohne WATS, oder in Ausnahmeliste
        If Not ZeileNochGueltig("FAUF_Beenden") Then Exit Sub

        'FAUF Nummer Aus selektierter Row auslesen
        Dim material As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim vorgang As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString
        Dim SollStk As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ausnahme As String = DGV_FAUF(DGV_Column.ausnahme, Row).Value
        Dim IstSAP As Integer = DGV_FAUF(DGV_Column.Ist_SAP, Row).Value
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString
        Dim Lagerort As String = DGV_FAUF(DGV_Column.Lagerort, Row).Value.ToString


        'Prüfen ob Auftrag bereits Rückgemeldet ist, ansonsten kein Beenden möglich
        'If IstSAP = SollStk Then

        'Kein Wats oder Materialnummer ist in Ausnahmeliste und kann Manuell beendet werden
        If My.Settings.G_LinieWats = False Or ausnahme = True Then
            'Es sind keine WATS Daten vorhanden, Eintrag in DB wird erstellt
            'prüfen ob Auftrag bereits gestartet wurde
            If Tbl_FAUF_StatusTableAdapter.GetStatus(auftrag & "_" & vorgang) = 1 Then
                'Status 2 "Erledigt" und sollstk in DB Schreiben
                Tbl_FAUF_StatusTableAdapter.UpdateQueryStatus("2", SollStk, auftrag & "_" & vorgang)
                'Richtige Farbe anhand des Startdatums aus DB in DGV anzeigen
                DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.ResourceManager.GetObject(FarbCodeTag(globalFunction.ParseProdDatum(Tbl_FAUF_StatusTableAdapter.GetProdDatum(auftrag & "_" & vorgang))).FarbText & "_voll")
                'Ist erhöhen, für Linien ohne WATS
                If My.Settings.sollistHalbfabrikate = True Then
                    If Lagerort = "DC20" Then
                        lbl_Ist.Text = (CInt(lbl_Ist.Text) + SollStk)
                    End If
                Else
                    lbl_Ist.Text = (CInt(lbl_Ist.Text) + SollStk)
                End If
            End If
        End If

        'Log schreiben
        If My.Settings.Logging = True Then
            log.WriteLog(Date.Now, My.Settings.Linie, auftrag, material, "Auftrag beendet")
        End If
    End Sub
    Sub FAUF_Prodkontrolle()
        If Not ZeileNochGueltig("FAUF_Prodkontrolle") Then Exit Sub

        'Form "Produktionskontrolle"öffnen
        'Variablen füllen aus selektierter Row
        Dim auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim ASN As String = DGV_FAUF(DGV_Column.Material, Row).Value.ToString
        Dim soll As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ist As Integer = DGV_FAUF(DGV_Column.Ist, Row).Value
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString
        Dim vrg As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString

        'Alle Aufträge von ausgewähltem Heijunka in einer Liste sammeln
        Dim ArbeitsvorratList As New List(Of Arbeitsvorrat)
        For Each item As DataGridViewRow In DGV_FAUF.Rows
            Dim AV As New Arbeitsvorrat
            AV.RowIndex = item.Index
            AV.Material = item.Cells(DGV_Column.Material).Value
            AV.Soll = item.Cells(DGV_Column.Soll).Value
            AV.ist = item.Cells(DGV_Column.Ist).Value
            AV.AP = item.Cells(DGV_Column.SAPAP).Value
            AV.Fauf = item.Cells(DGV_Column.Auftrag).Value
            AV.vrg = item.Cells(DGV_Column.Vrg).Value
            ArbeitsvorratList.Add(AV)
        Next

        Using frm As New frm_ProdKontrolle(ASN, auftrag, soll, ist, ComboBox1.Text, AP, vrg, ArbeitsvorratList, Row)
            AddHandler frm.ColoringHeijunkaEvent, AddressOf ProdKontColorEventHandler
            frm.ShowDialog()
        End Using

    End Sub
    Sub FehlerlabelAuftrag()
        If Not ZeileNochGueltig("FehlerlabelAuftrag") Then Exit Sub

        Dim Auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim f As New FehlerWATS(Auftrag, "Fehlerlabels für Auftrag: " & Auftrag)
        f.ShowDialog()
    End Sub
    Sub FehlerlabelLinie()
        Dim multiFAUF As String = ""
        For i = 0 To DGV_FAUF.Rows.Count - 1
            multiFAUF = multiFAUF & DGV_FAUF.Rows(i).Cells(DGV_Column.Auftrag).Value & ";"
        Next

        Dim f As New FehlerWATS(multiFAUF, "Fehlerlabels pro Linie")
        f.ShowDialog()
    End Sub
    Sub VCheckKontrolle()
        If Not ZeileNochGueltig("VCheckKontrolle") Then Exit Sub

        Dim Auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim ASN As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim cmb = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString

        'Vcheck TextFile auslesen und durchsuchen
        Dim Pfad As String = My.Settings.vcheckkontrollePfad
        Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)
        'Text Datei in Datatable schreiben
        For Each l As String In Lines
            Dim split() As String = l.Split(";")
            If split(0) = ASN Then 'And split(1).Contains(cmb.Item("AP")) Then
                'Abfrage ob eintrag bereits vorhanden ist
                If IsNothing(Tbl_vcheckKontrolleTableAdapter1.getAuftragsnummer(Auftrag, cmb.Item("Linie"))) Then
                    Dim f As New v_checkKontrolle(ASN, Auftrag, Row, cmb.Item("Linie"), cmb.Item("GruppeTeam"), split(2))
                    f.ShowDialog() ' Dialog Result abfragen?
                    'Row kann während des offenen Dialogs durch eine Hintergrund-Aktualisierung ungültig geworden sein
                    If f.DialogResult = DialogResult.OK AndAlso ZeileNochGueltig("VCheckKontrolle") Then
                        DGV_FAUF.Rows(Row).Cells(DGV_Column.VCheck).Value = My.Resources.gruenerhacken
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub StartAbbrechen()
        If Not ZeileNochGueltig("StartAbbrechen") Then Exit Sub

        Dim auftrag As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim vorgang As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString
        Dim istSMT As Boolean = False
        Dim ASN As String = DGV_FAUF(DGV_Column.SAPMAT, Row).Value.ToString
        Dim soll As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ist As Integer = DGV_FAUF(DGV_Column.Ist, Row).Value
        Dim ausnahme As String = DGV_FAUF(DGV_Column.ausnahme, Row).Value
        Dim CB = DirectCast(TblLinieBindingSource.Current, DataRowView).Row
        Dim AblieferOrt As String = ""
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString

        'Zurücksetzten des Status im Heijunka ohne Wats
        If My.Settings.G_LinieWats = False Or ausnahme = "True" Then
            'Es sind keine WATS Daten vorhanden, Eintrag in DB wird erstellt
            'Überprüfen ob Auftrag bereits in DB ist
            Dim AuftragVorhanden As Integer = CInt(Tbl_FAUF_StatusTableAdapter.GetStatus(auftrag & "_" & vorgang))
            If AuftragVorhanden > 0 Then
                'eintrag löschen
                Tbl_FAUF_StatusTableAdapter.DeleteQuery(auftrag & "_" & vorgang)
                'Tbl_FAUF_StatusTableAdapter.InsertQuery(auftrag & "_" & vorgang, "1", Now.ToShortDateString)
                'Zurücksetzten des Kreises im Heijunka
                DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.leer1
                If AuftragVorhanden = 2 Then
                    lbl_Ist.Text = CInt(lbl_Ist.Text) - soll
                End If
            End If
        End If

        'Protokoll schreiben
        log.WriteLog(Date.Now, My.Settings.Linie, auftrag, ASN, "Auftrag wurde abgebrochen")
    End Sub
    Sub Dokumente()
        If Not ZeileNochGueltig("Dokumente") Then Exit Sub

        Dim DataTable As DataTable = globalFunction.GetDokumente(DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString)
        Dim FormOpen As Boolean = False
        Dim Auftrag As String = DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value
        Dim MaterialNr As String = DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value

        For Each r As DataRow In DataTable.AsEnumerable
            If r("Link") <> "nothing" Then
                FormOpen = True
                Exit For
            End If
        Next

        If FormOpen = True Then
            Dim frm_Dok As New frm_Dok(DataTable, MaterialNr, Auftrag)
            frm_Dok.ShowDialog()
        Else
            MsgBox("Im SAP wurden " & DataTable.Rows.Count & " Dokumente gefunden." & vbCrLf & "Die zuordnung auf die Ablage konnte jedoch nicht hergestellt werden (Dateinamen falsch?).", vbCritical, "Fehler")
        End If
    End Sub
    Private Sub LpAbrufen()
        If Not ZeileNochGueltig("LpAbrufen") Then Exit Sub

        Dim lp As String = DGV_FAUF(DGV_Column.LPNR, Row).Value.ToString
        Dim fauf As String = DGV_FAUF(DGV_Column.Auftrag, Row).Value.ToString
        Dim ASN As String = DGV_FAUF(DGV_Column.Material, Row).Value.ToString
        Dim soll As Integer = DGV_FAUF(DGV_Column.Soll, Row).Value
        Dim ist As Integer = DGV_FAUF(DGV_Column.Ist, Row).Value
        Dim AP As String = DGV_FAUF(DGV_Column.SAPAP, Row).Value.ToString
        Dim vrg As String = DGV_FAUF(DGV_Column.Vrg, Row).Value.ToString
        Dim f As New frm_pcbAbruf(fauf, lp)
        Dim tbl_Adapter As New tbl_lp_ruestTableAdapter

        f.ShowDialog()
        'Row kann während des offenen Dialogs durch eine Hintergrund-Aktualisierung ungültig geworden sein
        If Not ZeileNochGueltig("LpAbrufen") Then Exit Sub

        Select Case f.DialogResult
            Case DialogResult.Yes
                If Not IsDBNull(tbl_Adapter.GetAuftrag(fauf)) Then
                    If IsNothing(tbl_Adapter.GetAuftrag(fauf)) Then
                        tbl_Adapter.InsertQuery(fauf, lp, True)
                        DGV_FAUF.Rows(Row).Cells(DGV_Column.LPOK).Value = My.Resources.gruenerhacken
                    End If
                End If
            Case DialogResult.No
                'Mitarbeiter hat auf "LP nicht verfügbar gecklickt" erzeugt einen Eintrag in der Produktionskontrolle!
                If Not IsDBNull(tbl_Adapter.GetAuftrag(fauf)) Then
                    tbl_Adapter.DeleteQuery(fauf)
                    DGV_FAUF.Rows(Row).Cells(DGV_Column.LPOK).Value = My.Resources.ausrufezeichen
                End If

                Dim FehlmaterialText As String = lp & " - " & globalFunction.GetArtikelNameByArtNr(fauf, ASN, lp)
                Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, ComboBox1.Text, ASN, fauf, soll, ist, "offen", "Fehlmaterial", FehlmaterialText, vrg)
                DGV_FAUF.Rows(Row).Cells(DGV_Column.Status).Value = My.Resources.ausrufezeichen
                DGV_FAUF.Rows(Row).DefaultCellStyle.ForeColor = Color.Red
        End Select
    End Sub

    Private Sub ZuASMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZuASMToolStripMenuItem.Click
        Dim Pfad As String = My.Settings.AsmSapListe
        Dim headers = "Leiterplatte ASM;Roh LP;Auftragsnummer;Menge;Fälligkeitsdatum"
        Dim SapMaterial As String = String.Empty
        Dim Auftrag As String = String.Empty
        Dim Menge As Integer = 0
        Dim EndDatum As DateTime
        Dim AsmMaterial As String = String.Empty
        Dim Linie As String = ComboBox1.Text.Replace(" ", "_")
        Dim Datum As String = Date.Now.ToShortDateString
        Dim RS As Object
        Dim PCB As String = String.Empty

        If Not IO.Directory.Exists("C:\Planung\") Then
            My.Computer.FileSystem.CreateDirectory("C:\Planung\")
        End If

        If File.Exists("C:\Planung\" & Linie & "_" & Datum & ".csv") Then
            File.Delete("C:\Planung\" & Linie & "_" & Datum & ".csv")
        End If

        Using sw As New IO.StreamWriter("C:\Planung\" & Linie & "_" & Datum & ".csv", True, System.Text.Encoding.Unicode)
            sw.WriteLine(headers)

            For Each row As DataGridViewRow In DGV_FAUF.Rows
                Auftrag = row.Cells(DGV_Column.Auftrag).Value
                If globalFunction.isPP00(Auftrag) = True Then
                    Continue For
                End If
                PCB = Convert.ToString(row.Cells(DGV_Column.LPNR).Value)
                'PCB = row.Cells(DGV_Column.LPNR).Value
                SapMaterial = row.Cells(DGV_Column.SAPMAT).Value
                Menge = row.Cells(DGV_Column.Soll).Value
                EndDatum = row.Cells(DGV_Column.EndDatum).Value
                RS = row.Cells(DGV_Column.R).Value
                If Not Convert.IsDBNull(RS) Then
                    If row.Cells(DGV_Column.R).Value = "R" Then
                        Continue For
                    End If
                End If

                Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)
                'Text Datei nach Materialnummer durchsuchen
                For Each l As String In Lines
                    Dim split() As String = l.Split(";")
                    If split(0) = SapMaterial Then
                        sw.WriteLine(split(3) & ";" & PCB & ";" & Auftrag & ";" & Menge.ToString & ";" & EndDatum.ToShortDateString)
                    End If
                Next
            Next

        End Using

        Process.Start("C:\Planung\")
    End Sub

    Private Sub ExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExcelToolStripMenuItem.Click
        Dim headers = (From header As DataGridViewColumn In DGV_FAUF.Columns.Cast(Of DataGridViewColumn)()
                       Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In DGV_FAUF.Rows.Cast(Of DataGridViewRow)()
                   Where Not row.IsNewRow
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))

        If File.Exists("export.xls") Then
            File.Delete("export.xls")
        End If

        Using sw As New IO.StreamWriter("export.xls", True, System.Text.Encoding.Unicode)
            sw.WriteLine(String.Join(";", headers))
            For Each r In rows
                sw.WriteLine(String.Join(";", r))
            Next
        End Using
        Process.Start("export.xls")
    End Sub

#End Region

#Region "Rückstand Funktionen"
    Public Structure Rueckstaende
        Public AnzahlDC As Integer
        Public AnzahlBG As Integer
        'Public Stunden As Double
        Public Data As DataTable
        Public Linie As String
    End Structure

    Function RueckstandProLinie() As Rueckstaende
        Dim Rueckstaende As Rueckstaende

        Dim AuftragAlt As String = String.Empty

        'Combobox casten
        Dim SNP = DirectCast(TblLinieBindingSource.Current, DataRowView).Row

        'SAP AP in Array spliten, Wenn mehrere SAP APs mit ; separiert in der DB stehen
        Dim SNPAP() As String = Split(SNP.Item("AP"), ";")
        'Datatable leeren
        SAP.DT_RS.Clear()

        'wenn merere SAP AP gepflegt sind, Array durchlaufen
        For i = 0 To SNPAP.Count - 1
            'Rückstände nicht Umterminiert und Umterminierte Aufträge ausschliesslich FX
            Dim Query = From item In SAP.DT_SQ00_Import_FAUF
                        Where item.ArbPlatz Like SNPAP(i) AndAlso
                            CInt(item.RueckGutMenge) < CInt(item.Vorgangsmenge - (CInt(item.Vorgangsmenge) / 100 * 10)) AndAlso
                            (DateTime.ParseExact(item.SpatStartDat, "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo) < Date.Today Or item.Anwenderstatus Like "UMTE") AndAlso
                            Len(item.Auftrag) = 8 AndAlso
                            item.SystemStatus.Contains(My.Settings.Systemstatus) = True
                        Order By item.Auftrag


            For Each item In Query

                If Not AuftragAlt.Equals(item.Auftrag) Then
                    Dim lagerOrt As String = globalFunction.GetLagerort(item.Auftrag, item.Material)

                    If lagerOrt.Equals("DC20") Then
                        Rueckstaende.AnzahlDC = Rueckstaende.AnzahlDC + 1
                    Else
                        Rueckstaende.AnzahlBG = Rueckstaende.AnzahlBG + 1
                    End If

                    SAP.DT_RS.AddDT_RSRow(item.Auftrag, item.Vorgang, item.Material, item.FertS,
                                      item.ArbPlatz, item.VorgangText, item.FertS, item.FrueStartZeit,
                                      item.SpatStartDat, item.SpatStartzeit, item.Vorgangsmenge, item.RueckGutMenge,
                                      item.Ausschuss, item.Anwenderstatus, item.SystemStatus, lagerOrt)
                    AuftragAlt = item.Auftrag
                End If
            Next
        Next

        Dim qry = From d In SAP.DT_RS

        'Resultate an Structure übergeben
        If qry.Count > 0 Then
            Rueckstaende.Data = qry.CopyToDataTable

            ''Arbeitsvorrat in Stunden:
            'For Each r As SAP.DT_RSRow In SAP.DT_RS
            '    Rueckstaende.Stunden += globalFunction.GetWorkingOrderHours(r.Auftrag, r.ArbPlatz)
            'Next
        Else
            Rueckstaende.Data = Nothing
            'Rueckstaende.Stunden = 0
        End If




        'Rueckstaende.AnzahlDC = qry.Count
        Rueckstaende.Linie = SNP.Item("Linie")

        Return Rueckstaende

    End Function


#End Region

#Region "Form Closeing"
    Private Sub BGW_CloseForm_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_CloseForm.DoWork
        Dim AnzOffeneFAUF As Integer = 0
        Dim i As Integer = 0
        'Produktionkontrolle in Datatable laden, schnellers überprüfen möglich
        Dim tbl_ProdKont As DataTable = Tbl_ProdKontrolleTableAdapter.GetData()

        For Each row As DataGridViewRow In DGV_FAUF.Rows
            ' 2 = Soll
            ' 3 = Ist
            BGW_CloseForm.ReportProgress(i + 1, "Aufträge werden überprüft, bitte warten...")

            'Wenn "ist" kleiner ist als "Soll" 
            If row.Cells(DGV_Column.Ist).Value < row.Cells(DGV_Column.Soll).Value Then
                'Wenn die Abweichung kleiner als 10% ist dann nicht nachfragen
                If row.Cells(DGV_Column.Soll).Value - row.Cells(DGV_Column.Ist).Value <= (System.Math.Round(row.Cells(DGV_Column.Soll).Value / 100 * 10)) Then
                Else
                    ' Abweichung ist grösser 10% = nachfragen
                    'prüfen ob watsdaten vorhanden sind
                    If My.Settings.G_LinieWats = True Then
                        'Abfrage ob eintrag in DB vorhanden
                        Dim qryProdKont = From rw In tbl_ProdKont
                                          Where rw("FAUF") Like row.Cells(DGV_Column.Auftrag).Value AndAlso rw("Status") Like "offen"
                                          Order By rw("Datum")

                        Dim Faufeingetragen As Integer = qryProdKont.Count
                        If Faufeingetragen = 0 Then
                            AnzOffeneFAUF = AnzOffeneFAUF + 1
                        End If
                    Else
                        AnzOffeneFAUF = AnzOffeneFAUF + 1
                    End If
                End If
            End If
            i = i + 1
        Next
        If AnzOffeneFAUF > 0 Then
            If My.Settings.G_LinieWats = True Then
                MsgBox("Es wurden " & AnzOffeneFAUF & " Aufträge noch nicht in der Produktionskontrolle erfasst!" & vbCrLf & vbCrLf &
                   "Bitte erfassen Sie die Aufträge in der Produktionskontrolle!", vbCritical, "produktionskontrolle nicht erfasst!")
                'Cancel Form closing = True
                BGW_CloseForm.ReportProgress(i + 1, "Produktionskontrolle nicht erfasst")
                e.Result = True
            Else
                If MessageBox.Show("Es sind " & AnzOffeneFAUF & " offene FAUFs vorhanden!" & vbCrLf & "Wurde die Produktionskontrolle erfasst?", "Digitales Heijunka beenden", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
                    'Cancel Form closing = True
                    BGW_CloseForm.ReportProgress(i + 1, "Produktionskontrolle nicht erfasst")
                    e.Result = True
                End If
            End If
        Else
            'Cancel Form closing = False = Form wird geschlossen
            BGW_CloseForm.ReportProgress(i + 1, "Programm wird beendet.")
            e.Result = False
        End If
    End Sub

    Private Sub BGW_CloseForm_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_CloseForm.ProgressChanged
        PB_Status.Value = e.ProgressPercentage
        lbl_Status.Text = e.UserState
    End Sub

    Private Sub BGW_CloseForm_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_CloseForm.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            log.WriteLog(Date.Now, "", "", "", $"CloseForm Fehler: {e.Error.Message}")
            FormClose = True
            Close()
            Exit Sub
        End If
        If e.Result = False Then
            'Form kann geschlossen werden
            FormClose = True
            Close()
        Else
            'Form wird nicht geschlossen
            T_PB.Start()
            T_WatsRefresh.Start()
        End If
    End Sub
#End Region

#Region "Print"
    Private Sub PrintNew()
        Dim uut1 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z1) & GetPrinterInhaltData(My.Settings.Priter_Z1)
        Dim uut2 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z2) & GetPrinterInhaltData(My.Settings.Priter_Z2)
        Dim uut3 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z3) & GetPrinterInhaltData(My.Settings.Priter_Z3)
        Dim uut4 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z4) & GetPrinterInhaltData(My.Settings.Priter_Z4)
        Dim uut5 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z5) & GetPrinterInhaltData(My.Settings.Priter_Z5)
        Dim uut6 As String = GetPrinterInhaltTitle(My.Settings.Priter_Z6) & GetPrinterInhaltData(My.Settings.Priter_Z6)
        Dim uut7 As String = String.Empty 'BarcodeStrings
        Dim uut8 As String = String.Empty 'BarcodeStrings
        Dim uut9 As String = String.Empty 'BarcodeStrings
        Dim uut10 As String = String.Empty 'BarcodeStrings
        Dim uut11 As String = String.Empty 'BarcodeStrings
        Dim uut12 As String = String.Empty 'BarcodeStrings


        If My.Settings.PrinterBC_Z1 = True Then
            uut7 = GetPrinterInhaltData(My.Settings.Priter_Z1)
        End If
        If My.Settings.PrinterBC_Z2 = True Then
            uut8 = GetPrinterInhaltData(My.Settings.Priter_Z2)
        End If
        If My.Settings.PrinterBC_Z3 = True Then
            uut9 = GetPrinterInhaltData(My.Settings.Priter_Z3)
        End If
        If My.Settings.PrinterBC_Z4 = True Then
            uut10 = GetPrinterInhaltData(My.Settings.Priter_Z4)
        End If
        If My.Settings.PrinterBC_Z5 = True Then
            uut11 = GetPrinterInhaltData(My.Settings.Priter_Z5)
        End If
        If My.Settings.PrinterBC_Z6 = True Then
            uut12 = GetPrinterInhaltData(My.Settings.Priter_Z6)
        End If

        Dim frm_Print As New frm_print(uut1, uut2, uut3, uut4, uut5, uut6, uut7, uut8, uut9, uut10, uut11, uut12)
        frm_Print.ShowDialog()

    End Sub

    Friend Function GetPrinterInhaltData(inhalt As String) As String
        Select Case inhalt
            Case "Linien Name"
                Return DGV_FAUF.Rows(Row).Cells(DGV_Column.Linie).Value
            Case "Arbeitsplatz"
                Return DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPAP).Value
            Case "Material Nr."
                Return DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value
            Case "Auftrags Nr."
                Return DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value
            Case "Stückzahl"
                Return DGV_FAUF.Rows(Row).Cells(DGV_Column.Soll).Value
            Case "Druck Datum"
                Return Date.Now.ToShortDateString
            Case "Datum von"
                Return globalFunction.GetDateFrom_FAUF(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
            Case "Datum bis"
                Return globalFunction.GetDateTo_FAUF(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
            Case "CEVA GearBox"
                Dim Getriebe As String = ""
                Dim AusTC3 As String = globalFunction.GetCEVA_GearBoxNr_TC3(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
                Dim AusDok As String = globalFunction.GetCEVA_GearBoxNr(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)

                If AusTC3 = "" Then
                    Getriebe = AusDok
                Else
                    Getriebe = AusTC3
                End If
                Return Getriebe
            Case "CEVA PCBA"
                Return globalFunction.GetMatNrByText(DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value, DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value, "lp-best")
            Case "FS"
                Return globalFunction.GetFS(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value)
            Case "Stückzahl leer"
                Return " ______________"
            Case "Visum"
                Return "Visum: _________  Visum: _________"
            Case "Ablieferort"
                Return globalFunction.GetLagerort(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value, DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value)
            Case Else
                Return ""
        End Select
    End Function
    Friend Function GetPrinterInhaltTitle(inhalt As String) As String
        Select Case inhalt
            Case "Linien Name"
                Return "Linie: "
            Case "Arbeitsplatz"
                Return "Arbeitsplatz: "
            Case "Material Nr."
                Return "Mat. Nr.: "
            Case "Auftrags Nr."
                Return "FAUF Nr.: "
            Case "Stückzahl"
                Return "Stk.: "
            Case "Druck Datum"
                Return "Druck Datum: "
            Case "Datum von"
                Return "Eckstarttermin: "
            Case "Datum bis"
                Return "Eckendtermin: "
            Case "CEVA GearBox"
                Return "Getriebe Nr.: "
            Case "CEVA PCBA"
                Return "PCBA Nr.: "
            Case "FS"
                Return "FS: "
            Case "Stückzahl leer"
                Return "Stk.: "
            Case "Ablieferort"
                Return "Abl.Ort.: "
            Case Else
                Return ""
        End Select
    End Function


#End Region

#Region "FileSystemWatcher"
    'File System Watcher für "Ist SAP" Anzeige in Heijunka
    Private Sub FSW_XML_Change_Renamed(sender As Object, e As RenamedEventArgs) Handles FSW_XML_Change.Renamed

        For Each item As DataGridViewRow In DGV_FAUF.Rows
            Dim AuftragNr As String = item.Cells(DGV_Column.Auftrag).Value
            Dim Arbeitsplatz As String = item.Cells(DGV_Column.SAPAP).Value
            Dim VorgangsNr As String = item.Cells(DGV_Column.Vrg).Value.ToString
            Dim Vorgangsmenege As Integer = CInt(item.Cells(DGV_Column.Soll).Value.ToString)

            If InStr(e.Name, AuftragNr) Then
                Dim FaufPfad As String = SAP_XML.PathFAUF_XML(AuftragNr)
                'PathFAUF_XML gibt "" zurück, wenn die Datei (noch) nicht existiert (z.B. FSW-Event
                'während die Datei gerade erst geschrieben/umbenannt wird) - ohne diese Prüfung
                'führte das in ReadXML2DS zu einer ArgumentException beim Lesen von "".
                If String.IsNullOrEmpty(FaufPfad) Then
                    Continue For
                End If
                Dim SAP_Ist As Integer = globalFunction.GetReportedBackQuantity(FaufPfad)
                Dim SAP_Truc As Integer = globalFunction.GetReportedBackQuantityTRUC(FaufPfad, Arbeitsplatz, VorgangsNr)
                Dim SAP_Qty As Integer = globalFunction.GetFaufQty(FaufPfad)

                If SAP_Ist = 0 And SAP_Truc > 0 Then
                    item.Cells(DGV_Column.Ist_SAP).Value = SAP_Truc
                    'in Protokoll schreiben
                    'globalFunction.SetProtocol(AuftragNr, Arbeitsplatz, "Auftrag", "Es wurden " & SAP_Truc & " stk. zurückgemeldet")
                Else
                    item.Cells(DGV_Column.Ist_SAP).Value = SAP_Ist
                    'in Protokoll schreiben
                    'globalFunction.SetProtocol(AuftragNr, Arbeitsplatz, "Auftrag", "Es wurden " & SAP_Ist & " stk. zurückgemeldet")
                End If

                If Not SAP_Qty = Vorgangsmenege Then
                    item.Cells(DGV_Column.Soll).Value = SAP_Qty
                End If

            End If
        Next
    End Sub

    'File System Watcher für Reload der SAP Daten wenn geändert
    Private Sub FSW_SAP_Export_Changed(sender As Object, e As FileSystemEventArgs) Handles FSW_SAP_Export.Created, FSW_SAP_Export.Changed
        If Not BGW_Hejiunka.IsBusy And Not BGW_HejiunkaImport.IsBusy Then
            Dim random As New Random()
            Dim z As Integer = CInt(random.Next(15, 31))

            lbl_Status.Text = "SAP Daten wurden geändert, Update wird in " & z & " Sekunden gestart!"
            T_FW_SAP_import.Interval = z * 1000
            T_FW_SAP_import.Start()
        End If
    End Sub
#End Region

' Die Regionen "Testing" und "HeijunkaAysinc" (experimentelle/nie fertiggestellte Parallel-
' Implementierung der Heijunka-Anzeige) wurden entfernt: alle enthaltenen Methoden hingen an
' Buttons (Button1, Button3, Button5, btn_asyncWats, btn_WatsAbfrage), die im Designer fest auf
' Visible = False stehen, oder waren komplett unangebunden (kein Handles, kein Aufruf von
' irgendwo) - im laufenden Betrieb nie erreichbar.

#Region "TEST"
    Private Sub BGW_CheckUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_CheckUpdate.DoWork
        Dim UpdateVorhanden As Boolean = False
        'Prüfen ob Update vorhanden ist
        If UpdateHandler.CheckForUpdate = True Then
            UpdateVorhanden = True
        Else
            UpdateVorhanden = False
        End If
        e.Result = UpdateVorhanden
    End Sub

    Private Sub BGW_CheckUpdate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_CheckUpdate.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            log.WriteLog(Date.Now, "", "", "", $"Update Check Fehler: {e.Error.Message}")
            Exit Sub
        End If
        If e.Result = True Then
            UpdateToolStripMenuItem.Enabled = True
            Me.Text = globalFunction.GetFormTitle("*** UPDATE VERFÜGBAR! ***")
        Else
            UpdateToolStripMenuItem.Enabled = False
            Me.Text = globalFunction.GetFormTitle()
        End If
    End Sub

    Private Sub T_UpdateCheck_Tick(sender As Object, e As EventArgs) Handles T_UpdateCheck.Tick
        If Not BGW_CheckUpdate.IsBusy Then
            BGW_CheckUpdate.RunWorkerAsync()
        End If
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        UpdateHandler.InstallUpdate()
    End Sub

    Private Sub AusschussToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AusschussToolStripMenuItem.Click
        Dim frm As New frm_ausschuss(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value,
                                     DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value,
                                     ComboBox1.Text)
        frm.ShowDialog()
    End Sub

    Private Sub AusschussToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AusschussToolStripMenuItem1.Click
        Dim frm As New frm_ausschuss(DGV_FAUF.Rows(Row).Cells(DGV_Column.Auftrag).Value,
                                     DGV_FAUF.Rows(Row).Cells(DGV_Column.SAPMAT).Value,
                                     ComboBox1.Text)
        frm.ShowDialog()
    End Sub
#End Region

End Class
