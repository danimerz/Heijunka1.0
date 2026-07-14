Imports System.ComponentModel
Imports ProdKontrolle.ProgrammübersichtDataSetTableAdapters

Public Class Frm_Barcodevb
    Public Material As String
    Public FAUF As String
    Public stk As Double
    Public AblieferOrt As String
    Public start As String
    Public PCB As String

    Private SAP_XML As New SAP_XML
    Private f As New GlobaleFunktionen

    Dim WithEvents BGW_SMT As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Dim WithEvents BGW_Kopf As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}
    Private Class ReturnValuesSMT
        Public BC_FAUF As Image
        Public BC_LP As Image
        Public BC_Mat As Image
        Public BC_stk As Image
        Public BC_OfenVG1 As Image
        Public BC_OfenVG2 As Image
        Public LP_Nr As String
        Public SchabVG1 As String
        Public SchabVG2 As String
        Public HubVG1 As String
        Public HubVG2 As String
        Public MediumVG1 As String
        Public MediumVG2 As String
        Public LP_Breite As String
        Public LP_Laenge As String
        Public Fixruestung As String
        Public Profil_VG1 As String
        Public Profil_VG2 As String
        Public Ablieferort As String
        Public Bemerkungen_VG1 As String
        Public Bemerkungen_VG2 As String
        Public LP_Index As String
        Public MatNr_Index As String
        Public RawData As DataTable
    End Class
    Private Class ReturnValuesKopfdaten
        Public BC_FAUF As Image
        Public BC_mbom As Image
        Public BC_Mat As Image
        Public BC_stk As Image
        Public BC_RS As Image
        Public BC_FS As Image
        Public Material As String
        Public FAUF As String
        Public stk As String
        Public mbom As String
        Public RS As String
        Public FS As String
        Public matkurztext As String
        Public FertSteurer As String
        Public Disponent As String
        Public FertLinie As String
        Public PE As String
        Public LangtextKopf As String
        Public Lagerort As String
        Public Behälterdaten As String
    End Class
    Public Sub New(Material1 As String, FAUF1 As String, Stk1 As Double, FormName As String, AblieferOrt1 As String, start1 As String)
        InitializeComponent()
        'Formname setzten
        Me.Text = FormName

        'Public Variablen befüllen
        Material = Material1
        FAUF = FAUF1
        stk = Stk1
        AblieferOrt = AblieferOrt1
        start = start1

    End Sub

    Private Sub Frm_Barcodevb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Select Case start
            Case "nur FAUF"
                Size = New Drawing.Size(523, 363)
                p_Montage.Visible = True
                P_SMT.Visible = False
                P_Auftragskopf.Visible = False
                'Baugruppe/ASN und FAUFnr Setzten
                lbl_ASN.Text = "ASN / SSN: " + Material
                lbl_FAUF.Text = "Auftrag: " + FAUF
                Anzeige_Endmontage()
            Case "SMT"
                Size = New Drawing.Size(1000, 680)
                p_Montage.Visible = False
                P_SMT.Visible = True
                P_Auftragskopf.Visible = False
                ProBar_Laden.Maximum = 8
                ProBar_Laden.Value = 0
                'Baugruppe/ASN und FAUFnr Setzten
                lbl_ASN.Text = "Baugruppe: " + Material
                lbl_FAUF.Text = "Auftrag: " + FAUF
                If Not BGW_SMT.IsBusy Then
                    BGW_SMT.RunWorkerAsync(Material)
                End If

            Case "Auftragskopf"
                Size = New Drawing.Size(920, 750)
                p_Montage.Visible = False
                P_SMT.Visible = False
                P_Auftragskopf.Visible = True

                If Not BGW_Kopf.IsBusy Then
                    BGW_Kopf.RunWorkerAsync()
                End If
            Case Else
                Me.Close()
        End Select

        Me.CenterToScreen()
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub Anzeige_Endmontage()
        'Als DMC oder als Barcode Darstellen abhänging von einstellungen

        If My.Settings.showDMC = False Then
            PB_Barcode_FAUF.SizeMode = PictureBoxSizeMode.Zoom
            PB_Barcode_FAUF.Image = Code128Rendering.MakeBarcodeImage(FAUF, 3, True)
        Else
            PB_Barcode_FAUF.SizeMode = PictureBoxSizeMode.CenterImage
            PB_Barcode_FAUF.Image = f.GenerateDMC(FAUF, 5, 10)
        End If
    End Sub

#Region "BGW SMT"
    Private Sub BGW_SMT_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_SMT.DoWork
        Dim ReturnData As New ReturnValuesSMT
        BGW_SMT.ReportProgress(1, "Datenbank wird geladen")
        ReturnData.RawData = Tbl_StammTableAdapter.GetDataBySAPMat(e.Argument)
        If ReturnData.RawData.Rows.Count = 1 Then
            For Each r In ReturnData.RawData.AsEnumerable
                BGW_SMT.ReportProgress(2, "Barcode LP erstellen")
                ReturnData.BC_LP = Code128Rendering.MakeBarcodeImage(r("LP_Nr"), 2, True)
                BGW_SMT.ReportProgress(3, "Barcode FAUF erstellen")
                ReturnData.BC_FAUF = Code128Rendering.MakeBarcodeImage(FAUF, 2, True)
                BGW_SMT.ReportProgress(4, "Barcode Material erstellen")
                If Material.Length > 11 Then
                    ReturnData.BC_Mat = Code128Rendering.MakeBarcodeImage(Material, 1, True)
                Else
                    ReturnData.BC_Mat = Code128Rendering.MakeBarcodeImage(Material, 2, True)
                End If
                BGW_SMT.ReportProgress(5, "Barcode Stückzahl erstellen")
                ReturnData.BC_stk = Code128Rendering.MakeBarcodeImage(stk, 2, True)
                BGW_SMT.ReportProgress(6, "Barcode Ofen erstellen")
                ReturnData.BC_OfenVG1 = Code128Rendering.MakeBarcodeImage(r("LP_Nr") & "-V1-" & r("Profil_VG1"), 2, True)
                ReturnData.BC_OfenVG2 = Code128Rendering.MakeBarcodeImage(r("LP_Nr") & "-V2-" & r("Profil_VG2"), 2, True)
                BGW_SMT.ReportProgress(7, "Text Daten laden")
                ReturnData.LP_Nr = r("LP_Nr")
                ReturnData.SchabVG1 = GetStringValue(r("Vorgang1"))
                ReturnData.SchabVG2 = GetStringValue(r("Vorgang2"))
                ReturnData.HubVG1 = GetStringValue(r("Hub_VG1"))
                ReturnData.HubVG2 = GetStringValue(r("Hub_VG2"))
                If GetStringValue(r("KZ_VG1")) = "-" Then
                    ReturnData.MediumVG1 = "-"
                Else
                    ReturnData.MediumVG1 = LotMedium(r("KZ_VG1")) 'GetStringValue(r("Medium_VG1"))
                End If
                If GetStringValue(r("KZ_VG2")) = "-" Then
                    ReturnData.MediumVG2 = "-"
                Else
                    ReturnData.MediumVG2 = LotMedium(r("KZ_VG2")) 'GetStringValue(r("Medium_VG2"))
                End If
                ReturnData.LP_Breite = GetStringValue(r("LP_Breite"))
                ReturnData.LP_Laenge = GetStringValue(r("LP_Länge"))
                ReturnData.Fixruestung = GetStringValue(r("Cluster"))
                ReturnData.Profil_VG1 = GetStringValue(r("Profil_VG1"))
                ReturnData.Profil_VG2 = GetStringValue(r("Profil_VG2"))
                ReturnData.Bemerkungen_VG1 = GetStringValue(r("Bemerkungen_VG1"))
                ReturnData.Bemerkungen_VG2 = GetStringValue(r("Bemerkungen_VG2"))
                ReturnData.MatNr_Index = GetStringValue(r("ID_Material"))
                ReturnData.LP_Index = GetStringValue(r("ID_LP"))
                Dim SpezAblieferOrt As String = LO_Ausnahmen(Material)
                If SpezAblieferOrt = "" Then
                    ReturnData.Ablieferort = AblieferOrt
                Else
                    ReturnData.Ablieferort = SpezAblieferOrt
                End If

            Next
        End If

        BGW_SMT.ReportProgress(8, "Done")
        e.Result = ReturnData

    End Sub

    Private Sub BGW_SMT_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_SMT.ProgressChanged
        ProBar_Laden.Value = e.ProgressPercentage
        lbl_fortschritt.Text = e.UserState
    End Sub

    Private Sub BGW_SMT_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_SMT.RunWorkerCompleted
        Dim ReturnValues As ReturnValuesSMT = e.Result

        'Ladebilder ausblenden
        PictureBox1.Visible = False
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        PictureBox6.Visible = False
        PictureBox7.Visible = False
        PictureBox8.Visible = False
        PictureBox9.Visible = False
        PictureBox10.Visible = False
        PictureBox11.Visible = False
        PictureBox12.Visible = False
        PictureBox13.Visible = False


        'Textfelder und Barcodes abfüllen
        PB_BC_LpNr.SizeMode = PictureBoxSizeMode.CenterImage
        PB_BC_FAUF.SizeMode = PictureBoxSizeMode.CenterImage
        PB_BC_Mat.SizeMode = PictureBoxSizeMode.CenterImage
        PB_BC_Stk.SizeMode = PictureBoxSizeMode.CenterImage
        PB_BC_ofenVG1.SizeMode = PictureBoxSizeMode.Zoom
        PB_BC_ofenVG2.SizeMode = PictureBoxSizeMode.Zoom

        PB_BC_LpNr.Image = ReturnValues.BC_LP
        PB_BC_FAUF.Image = ReturnValues.BC_FAUF
        PB_BC_Mat.Image = ReturnValues.BC_Mat
        If ReturnValues.Profil_VG1 <> "-" Then
            PB_BC_ofenVG1.Image = ReturnValues.BC_OfenVG1
        End If
        If ReturnValues.Profil_VG2 <> "-" Then
            PB_BC_ofenVG2.Image = ReturnValues.BC_OfenVG2
        End If
        PB_BC_Stk.Image = ReturnValues.BC_stk

        GB_Material.Text = "MaterialNr.: " & Material & "_" & ReturnValues.MatNr_Index
        gb_stuckzahl.Text = "Stückzahl: " & stk
        gb_FAUF.Text = "Auftragsnummer: " & FAUF
        gb_lp.Text = "Leiterplatte: " & (ReturnValues.LP_Nr) & "_" & ReturnValues.LP_Index
        PCB = ReturnValues.LP_Nr
        f.GetPcbPicture(ReturnValues.LP_Nr)
        lbl_SchabVG1.Text = "Schablone VG 1: " & (ReturnValues.SchabVG1)
        lbl_SchabVG2.Text = "Schablone VG 2: " & (ReturnValues.SchabVG2)
        lbl_hub_vg1.Text = "Hub VG1: " & (ReturnValues.HubVG1)
        lbl_hub_vg2.Text = "Hub VG2: " & (ReturnValues.HubVG2)
        lbl_Medium_VG1.Text = "Medium VG 1: " & (ReturnValues.MediumVG1)
        lbl_Medium_VG2.Text = "Medium VG 2: " & (ReturnValues.MediumVG2)
        lbl_lp_breite.Text = "LP Breite: " & (ReturnValues.LP_Breite)
        lbl_lp_laenge.Text = "LP Länge: " & (ReturnValues.LP_Laenge)
        lbl_fixruestung.Text = "Fixrüstung: " & (ReturnValues.Fixruestung)
        lbl_LO.Text = "Ablieferort: " & ReturnValues.Ablieferort
        txt_info.Text = "VG1: " & ReturnValues.Bemerkungen_VG1 & vbCrLf & "VG2: " & ReturnValues.Bemerkungen_VG2

    End Sub
#End Region

#Region "Funktionen"
    Function GetStringValue(value As Object) As String
        If value Is Nothing Or IsDBNull(value) Then
            Return "-"
        End If
        Return DirectCast(value, String)
    End Function

    Private Function LO_Ausnahmen(ByVal Material As String) As String
        'Funktion zum auslesen der Lagerort ausnahmen für SMT Ablieferorte
        Dim Pfad As String = My.Settings.LagerOrt_Ausnahmen
        Dim DT As New DataTable
        Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)
        Dim LO As String = ""

        'Columns definieren
        DT.Columns.Add("Material")
        DT.Columns.Add("LO")

        'Text Datei in Datatable schreiben
        'Dim Zeile As Integer = 0
        For Each l As String In Lines
            If Not l = "" Then
                Dim p() As String = l.Split("="c)
                DT.Rows.Add(p(0), p(1))
                'Zeile += 1
            End If
        Next

        'Loop durch datatable
        For Each item In DT.AsEnumerable
            If Material = item("Material") Then
                LO = item("LO")
            End If
        Next
        Return LO
        DT = Nothing
    End Function

    Private Function LotMedium(Art As String) As String
        'SMT Funktion zum bestimmen des Mediums
        Dim text As String = ""
        Select Case Art
            Case "R"
                text = "RoHS Bleifrei/ Reflow"
            Case "G"
                text = "Glue / Kleber"
            Case "N2P"
                text = "Verbleit, Stickstoff / Reflow"
            Case "N2R"
                text = "Bleifrei, Stickstoff / Reflow"
            Case "P"
                text = "Pb Verbleit / Reflow"
        End Select
        Return text
    End Function


#End Region

#Region " BGW Kopfdaten"
    Private Sub BGW_Kopf_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_Kopf.DoWork
        Dim ReturnData As New ReturnValuesKopfdaten

        'Barcode erstellen für Material, FAUF, Menge
        ReturnData.BC_Mat = Code128Rendering.MakeBarcodeImage(Material, 1, True)
        ReturnData.BC_FAUF = Code128Rendering.MakeBarcodeImage(FAUF, 2, True)
        ReturnData.BC_stk = Code128Rendering.MakeBarcodeImage(stk, 2, True)
        'Text erstellen für Material, FAUF, Menge
        ReturnData.Material = Material
        ReturnData.FAUF = FAUF
        ReturnData.stk = stk

        Dim DS_FAUF As New DataSet()
        Dim DS_APLA As New DataSet
        'FAUf XML in DS lesen
        DS_FAUF = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        DS_APLA = SAP_XML.ReadXML2DS(SAP_XML.PathAPLA_XML(FAUF, Material))

        'Matkurztext und RS auslesen
        If DS_FAUF.Tables.Contains("ZE1_DMSOP_MARX") Then
            Dim T_DOK As DataTable = DS_FAUF.Tables("ZE1_DMSOP_MARX")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("REVLV") Then
                    ReturnData.RS = GetStringValue(d.Item("REVLV"))
                    ReturnData.BC_RS = Code128Rendering.MakeBarcodeImage(d.Item("REVLV"), 2, True)
                End If
                If T_DOK.Columns.Contains("MAKTX") Then
                    ReturnData.matkurztext = d.Item("MAKTX")
                End If
            Next
        End If

        'Details auslesen Dispo, Fertigungssteuerer, Lagerort
        If DS_APLA.Tables.Contains("ZE1_DMSOP_MARX") Then
            Dim T_DOK As DataTable = DS_APLA.Tables("ZE1_DMSOP_MARX")
            For Each d In T_DOK.AsEnumerable
                ReturnData.FertSteurer = d.Item("FEVOR")
                ReturnData.Disponent = d.Item("DISPO") & ", " & d.Item("DSNAM")
                ReturnData.Lagerort = d.Item("LGPRO")
            Next
        End If

        'Details auslesen Behälterdaten
        If DS_APLA.Tables.Contains("ZE1_DMSOP_MATBEH") Then
            Dim T_DOK As DataTable = DS_APLA.Tables("ZE1_DMSOP_MATBEH")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.AsEnumerable.Count > 1 Then
                    ReturnData.Behälterdaten = ReturnData.Behälterdaten & d.Item("DCBEH") & " Box, " & CInt(d.Item("DCBMG")) & " Stk." & vbCrLf
                Else
                    ReturnData.Behälterdaten = d.Item("DCBEH") & " Box, " & CInt(d.Item("DCBMG")) & " Stk."
                End If
            Next
        End If

        'Details auslesen PE
        If DS_APLA.Tables.Contains("ZE1_DMSOP_PLKO") Then
            Dim T_DOK As DataTable = DS_APLA.Tables("ZE1_DMSOP_PLKO")
            For Each d In T_DOK.AsEnumerable
                ReturnData.PE = d.Item("VAGRP") & ", " & d.Item("TXT")
            Next
        End If

        'LangtextKopf auslesen
        If DS_FAUF.Tables.Contains("ZE1_DMSOP_KTXT") Then
            Dim T_DOK As DataTable = DS_FAUF.Tables("ZE1_DMSOP_KTXT")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("KOTXT") Then
                    ReturnData.LangtextKopf += d.Item("KOTXT") & vbCrLf
                End If
            Next
        End If

        'TC Doks auslesen
        If DS_FAUF.Tables.Contains("ZE1_DMSOP_DOKV") Then
            Dim T_DOK As DataTable = DS_FAUF.Tables("ZE1_DMSOP_DOKV")
            For Each d In T_DOK.AsEnumerable
                Select Case d.Item("DOKAR")
                    Case "TC2"
                        ReturnData.BC_FS = Code128Rendering.MakeBarcodeImage(d.Item("DOKVR"), 2, True)
                        ReturnData.FS = d.Item("DOKVR")
                    Case "TC3" 'mBOM
                        Dim mBomOrginal() As String = Split(d.Item("DOKNR"), "-")
                        Dim c As Integer = mBomOrginal.Count - 1
                        Dim mbom As String = Material & "_" & mBomOrginal(c) & "_" & ReturnData.RS & "_" & d.Item("DOKVR")

                        ReturnData.BC_mbom = Code128Rendering.MakeBarcodeImage(mbom, 1, True)
                        ReturnData.mbom = mbom
                End Select
            Next
        End If

        e.Result = ReturnData
    End Sub

    Private Sub BGW_Kopf_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_Kopf.RunWorkerCompleted
        'Abfrage für Farbige Melder
        Dim FarbigeMelder As New FarbigeMelder
        FarbigeMelder = f.GetFarbigeMelderData(FAUF)
        If FarbigeMelder.FarbigerMelder = True Then
            lbl_Farbe.Visible = True
            Label8.Visible = True
            lbl_Farbe.Text = FarbigeMelder.Farbe
        Else
            lbl_Farbe.Visible = False
            Label8.Visible = False
        End If

        Dim ReturnValues As ReturnValuesKopfdaten = e.Result
        pb_auftrag.SizeMode = PictureBoxSizeMode.CenterImage
        pb_fs.SizeMode = PictureBoxSizeMode.CenterImage
        pb_material.SizeMode = PictureBoxSizeMode.CenterImage
        pb_menge.SizeMode = PictureBoxSizeMode.CenterImage
        pb_mbom.SizeMode = PictureBoxSizeMode.CenterImage
        pb_rs.SizeMode = PictureBoxSizeMode.CenterImage

        bg_material.Text = "Material: " & ReturnValues.Material
        pb_material.Image = ReturnValues.BC_Mat
        gb_auftrag.Text = "Auftrags-Nr.: " & ReturnValues.FAUF
        pb_auftrag.Image = ReturnValues.BC_FAUF
        gb_menge.Text = "Menge: " & ReturnValues.stk
        pb_menge.Image = ReturnValues.BC_stk
        gb_mbom.Text = "mBOM: " & ReturnValues.mbom
        pb_mbom.Image = ReturnValues.BC_mbom
        gb_rs.Text = "RS: " & ReturnValues.RS
        pb_rs.Image = ReturnValues.BC_RS
        gb_fs.Text = "FS: " & ReturnValues.FS
        pb_fs.Image = ReturnValues.BC_FS
        lbl_matkurztext.Text = ReturnValues.matkurztext
        lbl_disponent.Text = ReturnValues.Disponent
        lbl_fertS.Text = ReturnValues.FertSteurer
        lbl_FertL.Text = ReturnValues.FertLinie
        lbl_pe.Text = ReturnValues.PE
        lbl_lagerort.Text = ReturnValues.Lagerort
        lbl_langtext.Text = ReturnValues.LangtextKopf
        lbl_behaelter.Text = ReturnValues.Behälterdaten
    End Sub
#End Region
End Class