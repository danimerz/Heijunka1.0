Imports System.ComponentModel
Imports System.Data.SqlClient
Imports ProdKontrolle.Form1

Public Class Einstellungen
    Private UpdateHandler As New UpdateHandler
    Private GlobalFunction As New GlobaleFunktionen
    Dim WithEvents BGWCheckUpdate As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Event SettingsEvent(sender As Object, e As Form1.SettingsHeijunkaEventArgs)


    Private Sub Einstellungen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Kontrolls ausblenden
        btn_checkUpdate.Visible = False

        'Wenn drucker aktiv ein bzw ausblenden
        If cb_PrinterAktiv.Checked = True Then
            txt_Printer_Anlage.Enabled = True
            txt_Printer_Station.Enabled = True
            cb_Referenz.Enabled = True
            txt_Printer_LabelArt.Enabled = True
            cb_Zeile1.Enabled = True
            cb_Zeile2.Enabled = True
            cb_Zeile3.Enabled = True
            cb_Zeile4.Enabled = True
            cb_Zeile5.Enabled = True
            cb_Zeile6.Enabled = True
            cb_bc_z1.Enabled = True
            cb_bc_z2.Enabled = True
            cb_bc_z3.Enabled = True
            cb_bc_z4.Enabled = True
            cb_bc_z5.Enabled = True
            cb_bc_z6.Enabled = True
        Else
            txt_Printer_Anlage.Enabled = False
            txt_Printer_Station.Enabled = False
            cb_Referenz.Enabled = False
            txt_Printer_LabelArt.Enabled = False
            cb_Zeile1.Enabled = False
            cb_Zeile2.Enabled = False
            cb_Zeile3.Enabled = False
            cb_Zeile4.Enabled = False
            cb_Zeile5.Enabled = False
            cb_Zeile6.Enabled = False
            cb_bc_z1.Enabled = False
            cb_bc_z2.Enabled = False
            cb_bc_z3.Enabled = False
            cb_bc_z4.Enabled = False
            cb_bc_z5.Enabled = False
            cb_bc_z6.Enabled = False
        End If

        'Kombi füllen
        Me.Tbl_LinieTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_Linie)
        'daten aus Settings abrufen
        txt_Printer_Anlage.Text = My.Settings.Printer_Anlage
        txt_Printer_LabelArt.Text = My.Settings.Printer_LabelArt
        txt_Printer_Station.Text = My.Settings.Printer_Station
        cb_Referenz.Text = My.Settings.Printer_Referenz
        cb_Zeile1.Text = My.Settings.Priter_Z1
        cb_Zeile2.Text = My.Settings.Priter_Z2
        cb_Zeile3.Text = My.Settings.Priter_Z3
        cb_Zeile4.Text = My.Settings.Priter_Z4
        cb_Zeile5.Text = My.Settings.Priter_Z5
        cb_Zeile6.Text = My.Settings.Priter_Z6
        cb_bc_z1.Checked = My.Settings.PrinterBC_Z1
        cb_bc_z2.Checked = My.Settings.PrinterBC_Z2
        cb_bc_z3.Checked = My.Settings.PrinterBC_Z3
        cb_bc_z4.Checked = My.Settings.PrinterBC_Z4
        cb_bc_z5.Checked = My.Settings.PrinterBC_Z5
        cb_bc_z6.Checked = My.Settings.PrinterBC_Z6
        cb_Support.Checked = My.Settings.SupportAktivieren
        cb_vorgabezeit.Checked = My.Settings.VorgabezeitAnzeigen
        cb_enddatum.Checked = My.Settings.FaufEndDatum
        cb_fauf_nicht_anzeigen.Checked = My.Settings.FaufNichtAnzeigen
        cb_sollist.Checked = My.Settings.sollistHalbfabrikate
        cb_lagerort.Checked = My.Settings.LoAnzeigen
        cb_PrinterAktiv.Checked = My.Settings.Printer_Aktivieren
        txt_SAP_Daten.Text = My.Settings.ExportPfadRemote
        txt_UpdateIntervall.Text = My.Settings.UpdateInterval / 60000
        chk_Autoupdate.Checked = My.Settings.autoUpdate
        CB_Linie.Text = My.Settings.Linie
        cb_ShowLine.Checked = My.Settings.showLine
        cb_vcheck_scanner.Checked = My.Settings.vcheck_scanner
        cb_Kommentar.Checked = My.Settings.Kommentar
        cb_show_Lpnr.Checked = My.Settings.showLPNr
        cb_ShowVrgText.Checked = My.Settings.showVrgTxt
        CB_Checkliste.Checked = My.Settings.Checkliste
        CB_ASN.Checked = My.Settings.ASN_Anzeigen
        CB_DMC.Checked = My.Settings.showDMC
        cb_log.Checked = My.Settings.Logging
        cbx_fauf_start.Text = My.Settings.FAUF_Start
        cbx_Sortierung.Text = My.Settings.SortHeijunka
        txt_Checkliste.Text = My.Settings.ChecklistePfad
        txt_startuppfad.Text = System.AppDomain.CurrentDomain.BaseDirectory
        txt_Systemstatus.Text = My.Settings.Systemstatus
        txt_WATS_API_Key.Text = My.Settings.WATSAPIKEY
        txt_incident_Mqtt.Text = My.Settings.incidentMqtt
        txt_ihTool.Text = My.Settings.ihToolApiKey
        cb_MultiFM.Checked = My.Settings.MultiFmProdKont
        lbl_Version.Text = "Version: " & GlobalFunction.GetSwVersion
        lbl_SAP_Daten.Text = "SAP Daten vom: " & System.IO.File.GetLastWriteTime(My.Settings.ExportPfadRemote)
        If Not BGWCheckUpdate.IsBusy Then
            lbl_Status_CheckUpdate.Text = "Es wird geprüft ob Updates vorhanden sind. Bitte Warten..."
            BGWCheckUpdate.RunWorkerAsync()
        End If

    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        'Prüfen ob felder nicht leer sind
        If Not txt_SAP_Daten.Text = "" AndAlso Not txt_UpdateIntervall.Text = "" Then
            'prüfen ob Pfad Korrekt
            If My.Computer.FileSystem.FileExists(txt_SAP_Daten.Text) = True Then
                ' Prüfen ob Updateintervall eine Zahl ist
                If NurZahlen(txt_UpdateIntervall.Text) = True Then
                    'Daten in Settings schreiben
                    My.Settings.ExportPfadRemote = txt_SAP_Daten.Text
                    My.Settings.UpdateInterval = CInt(txt_UpdateIntervall.Text) * 60000
                    My.Settings.autoUpdate = chk_Autoupdate.Checked
                    My.Settings.showDMC = CB_DMC.Checked
                    My.Settings.showLine = cb_ShowLine.Checked
                    My.Settings.showLPNr = cb_show_Lpnr.Checked
                    My.Settings.showVrgTxt = cb_ShowVrgText.Checked
                    My.Settings.Linie = CB_Linie.Text
                    My.Settings.vcheck_scanner = cb_vcheck_scanner.Checked
                    My.Settings.FaufEndDatum = cb_enddatum.Checked
                    My.Settings.FaufNichtAnzeigen = cb_fauf_nicht_anzeigen.Checked
                    My.Settings.Kommentar = cb_Kommentar.Checked
                    My.Settings.FAUF_Start = cbx_fauf_start.Text
                    My.Settings.SortHeijunka = cbx_Sortierung.Text
                    My.Settings.ChecklistePfad = txt_Checkliste.Text
                    My.Settings.Checkliste = CB_Checkliste.Checked
                    My.Settings.ASN_Anzeigen = CB_ASN.Checked
                    My.Settings.Systemstatus = txt_Systemstatus.Text
                    'My.Settings.WATSAPIKEY = txt_WATS_API_Key.Text
                    My.Settings.Printer_Anlage = txt_Printer_Anlage.Text
                    My.Settings.Printer_LabelArt = txt_Printer_LabelArt.Text
                    My.Settings.Printer_Station = txt_Printer_Station.Text
                    My.Settings.Printer_Referenz = cb_Referenz.Text
                    My.Settings.Priter_Z1 = cb_Zeile1.Text
                    My.Settings.Priter_Z2 = cb_Zeile2.Text
                    My.Settings.Priter_Z3 = cb_Zeile3.Text
                    My.Settings.Priter_Z4 = cb_Zeile4.Text
                    My.Settings.Priter_Z5 = cb_Zeile5.Text
                    My.Settings.Priter_Z6 = cb_Zeile6.Text
                    My.Settings.PrinterBC_Z1 = cb_bc_z1.Checked
                    My.Settings.PrinterBC_Z2 = cb_bc_z2.Checked
                    My.Settings.PrinterBC_Z3 = cb_bc_z3.Checked
                    My.Settings.PrinterBC_Z4 = cb_bc_z4.Checked
                    My.Settings.PrinterBC_Z5 = cb_bc_z5.Checked
                    My.Settings.PrinterBC_Z6 = cb_bc_z6.Checked
                    My.Settings.Printer_Aktivieren = cb_PrinterAktiv.Checked
                    My.Settings.sollistHalbfabrikate = cb_sollist.Checked
                    My.Settings.LoAnzeigen = cb_lagerort.Checked
                    My.Settings.SupportAktivieren = cb_Support.Checked
                    My.Settings.VorgabezeitAnzeigen = cb_vorgabezeit.Checked
                    My.Settings.Logging = cb_log.Checked
                    My.Settings.ihToolApiKey = txt_ihTool.Text
                    My.Settings.incidentMqtt = txt_incident_Mqtt.Text
                    My.Settings.MultiFmProdKont = cb_MultiFM.Checked
                    My.Settings.Save()
                    Me.Close()
                Else
                    MsgBox("Update Intervall darf nur Zahlen enhalten", vbCritical, "Fehler")
                End If
            Else
                MsgBox("Exportdatei Existiert nicht", vbCritical, "Fehler")
            End If
        Else
            MsgBox("Felder dürfen nicht leer sein", vbCritical, "Fehler")
        End If
    End Sub


    Public Function NurZahlen(ByVal Text As String) As Boolean
        If Text.Length = 0 Then Return False
        If Not IsNumeric(Text) Then Return False

        For i As Integer = 0 To Text.Length - 1
            If Not "0123456789".Contains(Text.Chars(i)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btn_checkUpdate_Click(sender As Object, e As EventArgs) Handles btn_checkUpdate.Click
        UpdateHandler.InstallUpdate()
    End Sub

    Private Sub lbl_Version_Click(sender As Object, e As EventArgs) Handles lbl_Version.Click
        Dim ChangeForm As New Changelog
        ChangeForm.ShowDialog()
    End Sub

    Private Sub BGWCheckUpdate_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGWCheckUpdate.DoWork
        Dim UpdateVorhanden As Boolean = False
        'Prüfen ob Update vorhanden ist
        If UpdateHandler.CheckForUpdate = True Then
            UpdateVorhanden = True
        Else
            UpdateVorhanden = False
        End If
        e.Result = UpdateVorhanden
    End Sub


    Private Sub BGWCheckUpdate_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGWCheckUpdate.RunWorkerCompleted
        If e.Result = True Then
            btn_checkUpdate.Visible = True
            lbl_Status_CheckUpdate.Text = "Update Vefügbar..."
        Else
            btn_checkUpdate.Visible = False
            lbl_Status_CheckUpdate.Text = "Digitales Heijunka ist aktuell..."
        End If
    End Sub

    Private Sub cb_PrinterAktiv_CheckedChanged(sender As Object, e As EventArgs) Handles cb_PrinterAktiv.CheckedChanged
        If cb_PrinterAktiv.Checked = True Then
            txt_Printer_Anlage.Enabled = True
            txt_Printer_Station.Enabled = True
            cb_Referenz.Enabled = True
            txt_Printer_LabelArt.Enabled = True
            cb_Zeile1.Enabled = True
            cb_Zeile2.Enabled = True
            cb_Zeile3.Enabled = True
            cb_Zeile4.Enabled = True
            cb_Zeile5.Enabled = True
            cb_Zeile6.Enabled = True
            cb_bc_z1.Enabled = True
            cb_bc_z2.Enabled = True
            cb_bc_z3.Enabled = True
            cb_bc_z4.Enabled = True
            cb_bc_z5.Enabled = True
            cb_bc_z6.Enabled = True
        Else
            txt_Printer_Anlage.Enabled = False
            txt_Printer_Station.Enabled = False
            cb_Referenz.Enabled = False
            txt_Printer_LabelArt.Enabled = False
            cb_Zeile1.Enabled = False
            cb_Zeile2.Enabled = False
            cb_Zeile3.Enabled = False
            cb_Zeile4.Enabled = False
            cb_Zeile5.Enabled = False
            cb_Zeile6.Enabled = False
            cb_bc_z1.Enabled = False
            cb_bc_z2.Enabled = False
            cb_bc_z3.Enabled = False
            cb_bc_z4.Enabled = False
            cb_bc_z5.Enabled = False
            cb_bc_z6.Enabled = False
        End If
    End Sub

    Private Sub lbl_help_Click(sender As Object, e As EventArgs) Handles lbl_help.Click
        Process.Start("\\ch021093\data\Standards\Tools\Produktionskontrolle\Anleitungen\ListeDerDruckStationen.txt")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For Each value As System.Configuration.SettingsPropertyValue In My.Settings.PropertyValues
            If value.Property.PropertyType Is GetType(System.String) Then
                Debug.WriteLine(value.Name & ": " & value.PropertyValue)
            End If
        Next
    End Sub

    Private Sub cb_enddatum_CheckedChanged(sender As Object, e As EventArgs) Handles cb_enddatum.CheckedChanged
        CallVisibleColumnEvent(cb_enddatum, "EndDatum")
    End Sub

    Private Sub cb_ShowLine_CheckedChanged(sender As Object, e As EventArgs) Handles cb_ShowLine.CheckedChanged
        CallVisibleColumnEvent(cb_ShowLine, "Linie")
    End Sub

    Private Sub cb_ShowVrgText_CheckedChanged(sender As Object, e As EventArgs) Handles cb_ShowVrgText.CheckedChanged
        CallVisibleColumnEvent(cb_ShowVrgText, "Vorgangstext")
    End Sub
    Private Sub cb_show_Lpnr_CheckedChanged(sender As Object, e As EventArgs) Handles cb_show_Lpnr.CheckedChanged
        CallVisibleColumnEvent(cb_show_Lpnr, "LpNummer")
    End Sub
    Private Sub cb_Kommentar_CheckedChanged(sender As Object, e As EventArgs) Handles cb_Kommentar.CheckedChanged
        CallVisibleColumnEvent(cb_Kommentar, "Kommentare")
    End Sub
    Private Sub cb_lagerort_CheckedChanged(sender As Object, e As EventArgs) Handles cb_lagerort.CheckedChanged
        CallVisibleColumnEvent(cb_lagerort, "Lagerort")
    End Sub
    Private Sub cb_vorgabezeit_CheckedChanged(sender As Object, e As EventArgs) Handles cb_vorgabezeit.CheckedChanged
        CallVisibleColumnEvent(cb_vorgabezeit, "Vorgabezeit")
    End Sub
    Public Sub CallVisibleColumnEvent(ctrl As System.Windows.Forms.CheckBox, ObjektName As String)
        Dim args = New SettingsHeijunkaEventArgs


        If ctrl.Checked = True Then
            args.Visible = True
        Else
            args.Visible = False
        End If

        args.ObjektName = ObjektName
        RaiseEvent SettingsEvent(Me, args)
    End Sub


End Class