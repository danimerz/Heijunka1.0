<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Einstellungen
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
        Me.txt_SAP_Daten = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_UpdateIntervall = New System.Windows.Forms.TextBox()
        Me.chk_Autoupdate = New System.Windows.Forms.CheckBox()
        Me.CB_Linie = New System.Windows.Forms.ComboBox()
        Me.TblLinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Tbl_LinieTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_Checkliste = New System.Windows.Forms.TextBox()
        Me.CB_Checkliste = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_startuppfad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_Systemstatus = New System.Windows.Forms.TextBox()
        Me.TabIncident = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cb_MultiFM = New System.Windows.Forms.CheckBox()
        Me.cb_log = New System.Windows.Forms.CheckBox()
        Me.cb_vorgabezeit = New System.Windows.Forms.CheckBox()
        Me.cb_Support = New System.Windows.Forms.CheckBox()
        Me.cb_fauf_nicht_anzeigen = New System.Windows.Forms.CheckBox()
        Me.cb_enddatum = New System.Windows.Forms.CheckBox()
        Me.cb_lagerort = New System.Windows.Forms.CheckBox()
        Me.cb_sollist = New System.Windows.Forms.CheckBox()
        Me.cb_Kommentar = New System.Windows.Forms.CheckBox()
        Me.cb_vcheck_scanner = New System.Windows.Forms.CheckBox()
        Me.cb_show_Lpnr = New System.Windows.Forms.CheckBox()
        Me.cb_ShowVrgText = New System.Windows.Forms.CheckBox()
        Me.cb_ShowLine = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbx_Sortierung = New System.Windows.Forms.ComboBox()
        Me.cbx_fauf_start = New System.Windows.Forms.ComboBox()
        Me.CB_DMC = New System.Windows.Forms.CheckBox()
        Me.lbl_Status_CheckUpdate = New System.Windows.Forms.Label()
        Me.CB_ASN = New System.Windows.Forms.CheckBox()
        Me.btn_checkUpdate = New System.Windows.Forms.Button()
        Me.lbl_SAP_Daten = New System.Windows.Forms.Label()
        Me.lbl_Version = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt_ihTool = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_incident_Mqtt = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_WATS_API_Key = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cb_bc_z6 = New System.Windows.Forms.CheckBox()
        Me.cb_bc_z4 = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cb_bc_z2 = New System.Windows.Forms.CheckBox()
        Me.cb_bc_z5 = New System.Windows.Forms.CheckBox()
        Me.cb_bc_z3 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cb_bc_z1 = New System.Windows.Forms.CheckBox()
        Me.lbl_help = New System.Windows.Forms.Label()
        Me.cb_Referenz = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cb_Zeile6 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cb_Zeile5 = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cb_Zeile4 = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cb_Zeile3 = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cb_Zeile2 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cb_Zeile1 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cb_PrinterAktiv = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_Printer_LabelArt = New System.Windows.Forms.TextBox()
        Me.txt_Printer_Station = New System.Windows.Forms.TextBox()
        Me.txt_Printer_Anlage = New System.Windows.Forms.TextBox()
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabIncident.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_SAP_Daten
        '
        Me.txt_SAP_Daten.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_SAP_Daten.Location = New System.Drawing.Point(7, 30)
        Me.txt_SAP_Daten.Name = "txt_SAP_Daten"
        Me.txt_SAP_Daten.Size = New System.Drawing.Size(367, 26)
        Me.txt_SAP_Daten.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SAP Daten [Download]"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(415, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Update Intervall [min]"
        '
        'txt_UpdateIntervall
        '
        Me.txt_UpdateIntervall.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_UpdateIntervall.Location = New System.Drawing.Point(415, 22)
        Me.txt_UpdateIntervall.Name = "txt_UpdateIntervall"
        Me.txt_UpdateIntervall.Size = New System.Drawing.Size(122, 26)
        Me.txt_UpdateIntervall.TabIndex = 4
        '
        'chk_Autoupdate
        '
        Me.chk_Autoupdate.AutoSize = True
        Me.chk_Autoupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chk_Autoupdate.Location = New System.Drawing.Point(310, 27)
        Me.chk_Autoupdate.Name = "chk_Autoupdate"
        Me.chk_Autoupdate.Size = New System.Drawing.Size(86, 17)
        Me.chk_Autoupdate.TabIndex = 6
        Me.chk_Autoupdate.Text = "Auto Update"
        Me.chk_Autoupdate.UseVisualStyleBackColor = True
        '
        'CB_Linie
        '
        Me.CB_Linie.DataSource = Me.TblLinieBindingSource
        Me.CB_Linie.DisplayMember = "Linie"
        Me.CB_Linie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.CB_Linie.FormattingEnabled = True
        Me.CB_Linie.Location = New System.Drawing.Point(6, 32)
        Me.CB_Linie.Name = "CB_Linie"
        Me.CB_Linie.Size = New System.Drawing.Size(282, 28)
        Me.CB_Linie.TabIndex = 7
        Me.CB_Linie.ValueMember = "ID"
        '
        'TblLinieBindingSource
        '
        Me.TblLinieBindingSource.DataMember = "tbl_Linie"
        Me.TblLinieBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'DS_ProdKontrolle
        '
        Me.DS_ProdKontrolle.DataSetName = "DS_ProdKontrolle"
        Me.DS_ProdKontrolle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Standard Linie"
        '
        'btn_save
        '
        Me.btn_save.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.btn_save.Location = New System.Drawing.Point(8, 375)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(900, 41)
        Me.btn_save.TabIndex = 9
        Me.btn_save.Text = "Speichern und schliessen"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Checklistenpfad"
        '
        'txt_Checkliste
        '
        Me.txt_Checkliste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_Checkliste.Location = New System.Drawing.Point(7, 81)
        Me.txt_Checkliste.Name = "txt_Checkliste"
        Me.txt_Checkliste.Size = New System.Drawing.Size(367, 26)
        Me.txt_Checkliste.TabIndex = 11
        '
        'CB_Checkliste
        '
        Me.CB_Checkliste.AutoSize = True
        Me.CB_Checkliste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CB_Checkliste.Location = New System.Drawing.Point(310, 54)
        Me.CB_Checkliste.Name = "CB_Checkliste"
        Me.CB_Checkliste.Size = New System.Drawing.Size(122, 17)
        Me.CB_Checkliste.TabIndex = 14
        Me.CB_Checkliste.Text = "Checkliste Anzeigen"
        Me.CB_Checkliste.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Startup Pfad"
        '
        'txt_startuppfad
        '
        Me.txt_startuppfad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_startuppfad.Location = New System.Drawing.Point(7, 137)
        Me.txt_startuppfad.Name = "txt_startuppfad"
        Me.txt_startuppfad.ReadOnly = True
        Me.txt_startuppfad.Size = New System.Drawing.Size(367, 26)
        Me.txt_startuppfad.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "SAP System Status"
        '
        'txt_Systemstatus
        '
        Me.txt_Systemstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_Systemstatus.Location = New System.Drawing.Point(7, 189)
        Me.txt_Systemstatus.Name = "txt_Systemstatus"
        Me.txt_Systemstatus.Size = New System.Drawing.Size(367, 26)
        Me.txt_Systemstatus.TabIndex = 17
        '
        'TabIncident
        '
        Me.TabIncident.Controls.Add(Me.TabPage1)
        Me.TabIncident.Controls.Add(Me.TabPage2)
        Me.TabIncident.Controls.Add(Me.TabPage3)
        Me.TabIncident.Location = New System.Drawing.Point(12, 12)
        Me.TabIncident.Name = "TabIncident"
        Me.TabIncident.SelectedIndex = 0
        Me.TabIncident.Size = New System.Drawing.Size(896, 342)
        Me.TabIncident.TabIndex = 19
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cb_MultiFM)
        Me.TabPage1.Controls.Add(Me.cb_log)
        Me.TabPage1.Controls.Add(Me.cb_vorgabezeit)
        Me.TabPage1.Controls.Add(Me.cb_Support)
        Me.TabPage1.Controls.Add(Me.cb_fauf_nicht_anzeigen)
        Me.TabPage1.Controls.Add(Me.cb_enddatum)
        Me.TabPage1.Controls.Add(Me.cb_lagerort)
        Me.TabPage1.Controls.Add(Me.cb_sollist)
        Me.TabPage1.Controls.Add(Me.cb_Kommentar)
        Me.TabPage1.Controls.Add(Me.cb_vcheck_scanner)
        Me.TabPage1.Controls.Add(Me.cb_show_Lpnr)
        Me.TabPage1.Controls.Add(Me.cb_ShowVrgText)
        Me.TabPage1.Controls.Add(Me.cb_ShowLine)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.cbx_Sortierung)
        Me.TabPage1.Controls.Add(Me.cbx_fauf_start)
        Me.TabPage1.Controls.Add(Me.CB_DMC)
        Me.TabPage1.Controls.Add(Me.lbl_Status_CheckUpdate)
        Me.TabPage1.Controls.Add(Me.CB_ASN)
        Me.TabPage1.Controls.Add(Me.btn_checkUpdate)
        Me.TabPage1.Controls.Add(Me.lbl_SAP_Daten)
        Me.TabPage1.Controls.Add(Me.lbl_Version)
        Me.TabPage1.Controls.Add(Me.CB_Linie)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txt_UpdateIntervall)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.chk_Autoupdate)
        Me.TabPage1.Controls.Add(Me.CB_Checkliste)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(888, 316)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Allgemein"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cb_MultiFM
        '
        Me.cb_MultiFM.AutoSize = True
        Me.cb_MultiFM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_MultiFM.Location = New System.Drawing.Point(584, 144)
        Me.cb_MultiFM.Name = "cb_MultiFM"
        Me.cb_MultiFM.Size = New System.Drawing.Size(196, 17)
        Me.cb_MultiFM.TabIndex = 38
        Me.cb_MultiFM.Text = "Multi FM in Prod. Kontrolle eintargen"
        Me.cb_MultiFM.UseVisualStyleBackColor = True
        '
        'cb_log
        '
        Me.cb_log.AutoSize = True
        Me.cb_log.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_log.Location = New System.Drawing.Point(584, 121)
        Me.cb_log.Name = "cb_log"
        Me.cb_log.Size = New System.Drawing.Size(114, 17)
        Me.cb_log.TabIndex = 37
        Me.cb_log.Text = "Logging Aktivieren"
        Me.cb_log.UseVisualStyleBackColor = True
        '
        'cb_vorgabezeit
        '
        Me.cb_vorgabezeit.AutoSize = True
        Me.cb_vorgabezeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_vorgabezeit.Location = New System.Drawing.Point(584, 98)
        Me.cb_vorgabezeit.Name = "cb_vorgabezeit"
        Me.cb_vorgabezeit.Size = New System.Drawing.Size(140, 17)
        Me.cb_vorgabezeit.TabIndex = 36
        Me.cb_vorgabezeit.Text = "Vorgabezeiten anzeigen"
        Me.cb_vorgabezeit.UseVisualStyleBackColor = True
        '
        'cb_Support
        '
        Me.cb_Support.AutoSize = True
        Me.cb_Support.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_Support.Location = New System.Drawing.Point(584, 75)
        Me.cb_Support.Name = "cb_Support"
        Me.cb_Support.Size = New System.Drawing.Size(130, 17)
        Me.cb_Support.TabIndex = 34
        Me.cb_Support.Text = "TS Support Aktivieren"
        Me.cb_Support.UseVisualStyleBackColor = True
        '
        'cb_fauf_nicht_anzeigen
        '
        Me.cb_fauf_nicht_anzeigen.AutoSize = True
        Me.cb_fauf_nicht_anzeigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_fauf_nicht_anzeigen.Location = New System.Drawing.Point(584, 54)
        Me.cb_fauf_nicht_anzeigen.Name = "cb_fauf_nicht_anzeigen"
        Me.cb_fauf_nicht_anzeigen.Size = New System.Drawing.Size(241, 17)
        Me.cb_fauf_nicht_anzeigen.TabIndex = 33
        Me.cb_fauf_nicht_anzeigen.Text = "FAUF nach Rückmelden nicht mehr anzeigen"
        Me.cb_fauf_nicht_anzeigen.UseVisualStyleBackColor = True
        '
        'cb_enddatum
        '
        Me.cb_enddatum.AutoSize = True
        Me.cb_enddatum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_enddatum.Location = New System.Drawing.Point(584, 27)
        Me.cb_enddatum.Name = "cb_enddatum"
        Me.cb_enddatum.Size = New System.Drawing.Size(150, 17)
        Me.cb_enddatum.TabIndex = 32
        Me.cb_enddatum.Text = "FAUF Enddatum anzeigen"
        Me.cb_enddatum.UseVisualStyleBackColor = True
        '
        'cb_lagerort
        '
        Me.cb_lagerort.AutoSize = True
        Me.cb_lagerort.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_lagerort.Location = New System.Drawing.Point(310, 256)
        Me.cb_lagerort.Name = "cb_lagerort"
        Me.cb_lagerort.Size = New System.Drawing.Size(111, 17)
        Me.cb_lagerort.TabIndex = 31
        Me.cb_lagerort.Text = "Lagerort anzeigen"
        Me.cb_lagerort.UseVisualStyleBackColor = True
        '
        'cb_sollist
        '
        Me.cb_sollist.AutoSize = True
        Me.cb_sollist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_sollist.Location = New System.Drawing.Point(310, 234)
        Me.cb_sollist.Name = "cb_sollist"
        Me.cb_sollist.Size = New System.Drawing.Size(152, 17)
        Me.cb_sollist.TabIndex = 30
        Me.cb_sollist.Text = "Soll/Ist ohne Halbfabrikate"
        Me.cb_sollist.UseVisualStyleBackColor = True
        '
        'cb_Kommentar
        '
        Me.cb_Kommentar.AutoSize = True
        Me.cb_Kommentar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_Kommentar.Location = New System.Drawing.Point(310, 213)
        Me.cb_Kommentar.Name = "cb_Kommentar"
        Me.cb_Kommentar.Size = New System.Drawing.Size(131, 17)
        Me.cb_Kommentar.TabIndex = 29
        Me.cb_Kommentar.Text = "Kommentare anzeigen"
        Me.cb_Kommentar.UseVisualStyleBackColor = True
        '
        'cb_vcheck_scanner
        '
        Me.cb_vcheck_scanner.AutoSize = True
        Me.cb_vcheck_scanner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_vcheck_scanner.Location = New System.Drawing.Point(310, 190)
        Me.cb_vcheck_scanner.Name = "cb_vcheck_scanner"
        Me.cb_vcheck_scanner.Size = New System.Drawing.Size(216, 17)
        Me.cb_vcheck_scanner.TabIndex = 28
        Me.cb_vcheck_scanner.Text = "V-Check Kontrolle (Scanner verwenden)"
        Me.cb_vcheck_scanner.UseVisualStyleBackColor = True
        '
        'cb_show_Lpnr
        '
        Me.cb_show_Lpnr.AutoSize = True
        Me.cb_show_Lpnr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_show_Lpnr.Location = New System.Drawing.Point(310, 167)
        Me.cb_show_Lpnr.Name = "cb_show_Lpnr"
        Me.cb_show_Lpnr.Size = New System.Drawing.Size(147, 17)
        Me.cb_show_Lpnr.TabIndex = 27
        Me.cb_show_Lpnr.Text = "Leiterplatten Nr. anzeigen"
        Me.cb_show_Lpnr.UseVisualStyleBackColor = True
        '
        'cb_ShowVrgText
        '
        Me.cb_ShowVrgText.AutoSize = True
        Me.cb_ShowVrgText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_ShowVrgText.Location = New System.Drawing.Point(310, 144)
        Me.cb_ShowVrgText.Name = "cb_ShowVrgText"
        Me.cb_ShowVrgText.Size = New System.Drawing.Size(134, 17)
        Me.cb_ShowVrgText.TabIndex = 26
        Me.cb_ShowVrgText.Text = "Vorgangstext anzeigen"
        Me.cb_ShowVrgText.UseVisualStyleBackColor = True
        '
        'cb_ShowLine
        '
        Me.cb_ShowLine.AutoSize = True
        Me.cb_ShowLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cb_ShowLine.Location = New System.Drawing.Point(310, 121)
        Me.cb_ShowLine.Name = "cb_ShowLine"
        Me.cb_ShowLine.Size = New System.Drawing.Size(94, 17)
        Me.cb_ShowLine.TabIndex = 25
        Me.cb_ShowLine.Text = "Linie anzeigen"
        Me.cb_ShowLine.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Sortierung Heijunka"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Anzeige FAUF Starten"
        '
        'cbx_Sortierung
        '
        Me.cbx_Sortierung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cbx_Sortierung.FormattingEnabled = True
        Me.cbx_Sortierung.Items.AddRange(New Object() {"FrueStartZeit", "ArbPlatz"})
        Me.cbx_Sortierung.Location = New System.Drawing.Point(6, 126)
        Me.cbx_Sortierung.Name = "cbx_Sortierung"
        Me.cbx_Sortierung.Size = New System.Drawing.Size(282, 28)
        Me.cbx_Sortierung.TabIndex = 22
        '
        'cbx_fauf_start
        '
        Me.cbx_fauf_start.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cbx_fauf_start.FormattingEnabled = True
        Me.cbx_fauf_start.Items.AddRange(New Object() {"nichts", "nur FAUF", "Auftragskopf", "SMT"})
        Me.cbx_fauf_start.Location = New System.Drawing.Point(6, 79)
        Me.cbx_fauf_start.Name = "cbx_fauf_start"
        Me.cbx_fauf_start.Size = New System.Drawing.Size(282, 28)
        Me.cbx_fauf_start.TabIndex = 21
        '
        'CB_DMC
        '
        Me.CB_DMC.AutoSize = True
        Me.CB_DMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CB_DMC.Location = New System.Drawing.Point(310, 100)
        Me.CB_DMC.Name = "CB_DMC"
        Me.CB_DMC.Size = New System.Drawing.Size(153, 17)
        Me.CB_DMC.TabIndex = 20
        Me.CB_DMC.Text = "DMC anstelle von Barcode"
        Me.CB_DMC.UseVisualStyleBackColor = True
        '
        'lbl_Status_CheckUpdate
        '
        Me.lbl_Status_CheckUpdate.AutoSize = True
        Me.lbl_Status_CheckUpdate.Location = New System.Drawing.Point(6, 263)
        Me.lbl_Status_CheckUpdate.Name = "lbl_Status_CheckUpdate"
        Me.lbl_Status_CheckUpdate.Size = New System.Drawing.Size(285, 13)
        Me.lbl_Status_CheckUpdate.TabIndex = 19
        Me.lbl_Status_CheckUpdate.Text = "Es wird geprüft ob Updates vorhanden sind. Bitte Warten..."
        '
        'CB_ASN
        '
        Me.CB_ASN.AutoSize = True
        Me.CB_ASN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CB_ASN.Location = New System.Drawing.Point(310, 77)
        Me.CB_ASN.Name = "CB_ASN"
        Me.CB_ASN.Size = New System.Drawing.Size(237, 17)
        Me.CB_ASN.TabIndex = 18
        Me.CB_ASN.Text = "ASN anstelle von SSN im Heijunka anzeigen"
        Me.CB_ASN.UseVisualStyleBackColor = True
        '
        'btn_checkUpdate
        '
        Me.btn_checkUpdate.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_checkUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_checkUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_checkUpdate.Location = New System.Drawing.Point(6, 282)
        Me.btn_checkUpdate.Name = "btn_checkUpdate"
        Me.btn_checkUpdate.Size = New System.Drawing.Size(876, 28)
        Me.btn_checkUpdate.TabIndex = 17
        Me.btn_checkUpdate.Text = "Update verfügbar"
        Me.btn_checkUpdate.UseVisualStyleBackColor = False
        '
        'lbl_SAP_Daten
        '
        Me.lbl_SAP_Daten.AutoSize = True
        Me.lbl_SAP_Daten.Location = New System.Drawing.Point(6, 242)
        Me.lbl_SAP_Daten.Name = "lbl_SAP_Daten"
        Me.lbl_SAP_Daten.Size = New System.Drawing.Size(89, 13)
        Me.lbl_SAP_Daten.TabIndex = 16
        Me.lbl_SAP_Daten.Text = "SAP Daten vom: "
        '
        'lbl_Version
        '
        Me.lbl_Version.AutoSize = True
        Me.lbl_Version.Location = New System.Drawing.Point(6, 222)
        Me.lbl_Version.Name = "lbl_Version"
        Me.lbl_Version.Size = New System.Drawing.Size(48, 13)
        Me.lbl_Version.TabIndex = 15
        Me.lbl_Version.Text = "Version: "
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txt_ihTool)
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.txt_incident_Mqtt)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txt_WATS_API_Key)
        Me.TabPage2.Controls.Add(Me.txt_SAP_Daten)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txt_Systemstatus)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txt_Checkliste)
        Me.TabPage2.Controls.Add(Me.txt_startuppfad)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(888, 316)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Erweitert"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(438, 65)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(80, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "ih-Tool API Key"
        '
        'txt_ihTool
        '
        Me.txt_ihTool.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_ihTool.Location = New System.Drawing.Point(438, 81)
        Me.txt_ihTool.Name = "txt_ihTool"
        Me.txt_ihTool.Size = New System.Drawing.Size(367, 26)
        Me.txt_ihTool.TabIndex = 24
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(438, 14)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 13)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "incident MQTT Server"
        '
        'txt_incident_Mqtt
        '
        Me.txt_incident_Mqtt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_incident_Mqtt.Location = New System.Drawing.Point(438, 30)
        Me.txt_incident_Mqtt.Name = "txt_incident_Mqtt"
        Me.txt_incident_Mqtt.Size = New System.Drawing.Size(367, 26)
        Me.txt_incident_Mqtt.TabIndex = 22
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(20, 276)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(294, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Alle String einstellungen in Debug Schreiben"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 228)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "WATS API Key"
        '
        'txt_WATS_API_Key
        '
        Me.txt_WATS_API_Key.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_WATS_API_Key.Location = New System.Drawing.Point(7, 244)
        Me.txt_WATS_API_Key.Name = "txt_WATS_API_Key"
        Me.txt_WATS_API_Key.Size = New System.Drawing.Size(367, 26)
        Me.txt_WATS_API_Key.TabIndex = 19
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cb_bc_z6)
        Me.TabPage3.Controls.Add(Me.cb_bc_z4)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.cb_bc_z2)
        Me.TabPage3.Controls.Add(Me.cb_bc_z5)
        Me.TabPage3.Controls.Add(Me.cb_bc_z3)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.cb_bc_z1)
        Me.TabPage3.Controls.Add(Me.lbl_help)
        Me.TabPage3.Controls.Add(Me.cb_Referenz)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.cb_Zeile6)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.cb_Zeile5)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.cb_Zeile4)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.cb_Zeile3)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.cb_Zeile2)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.cb_Zeile1)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.cb_PrinterAktiv)
        Me.TabPage3.Controls.Add(Me.PictureBox1)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.txt_Printer_LabelArt)
        Me.TabPage3.Controls.Add(Me.txt_Printer_Station)
        Me.TabPage3.Controls.Add(Me.txt_Printer_Anlage)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(888, 316)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Drucker"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cb_bc_z6
        '
        Me.cb_bc_z6.AutoSize = True
        Me.cb_bc_z6.Location = New System.Drawing.Point(519, 266)
        Me.cb_bc_z6.Name = "cb_bc_z6"
        Me.cb_bc_z6.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z6.TabIndex = 37
        Me.cb_bc_z6.UseVisualStyleBackColor = True
        '
        'cb_bc_z4
        '
        Me.cb_bc_z4.AutoSize = True
        Me.cb_bc_z4.Location = New System.Drawing.Point(519, 222)
        Me.cb_bc_z4.Name = "cb_bc_z4"
        Me.cb_bc_z4.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z4.TabIndex = 36
        Me.cb_bc_z4.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(516, 151)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 13)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Barcode?"
        '
        'cb_bc_z2
        '
        Me.cb_bc_z2.AutoSize = True
        Me.cb_bc_z2.Location = New System.Drawing.Point(519, 175)
        Me.cb_bc_z2.Name = "cb_bc_z2"
        Me.cb_bc_z2.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z2.TabIndex = 34
        Me.cb_bc_z2.UseVisualStyleBackColor = True
        '
        'cb_bc_z5
        '
        Me.cb_bc_z5.AutoSize = True
        Me.cb_bc_z5.Location = New System.Drawing.Point(231, 266)
        Me.cb_bc_z5.Name = "cb_bc_z5"
        Me.cb_bc_z5.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z5.TabIndex = 33
        Me.cb_bc_z5.UseVisualStyleBackColor = True
        '
        'cb_bc_z3
        '
        Me.cb_bc_z3.AutoSize = True
        Me.cb_bc_z3.Location = New System.Drawing.Point(231, 222)
        Me.cb_bc_z3.Name = "cb_bc_z3"
        Me.cb_bc_z3.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z3.TabIndex = 32
        Me.cb_bc_z3.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(228, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 31
        Me.Label12.Text = "Barcode?"
        '
        'cb_bc_z1
        '
        Me.cb_bc_z1.AutoSize = True
        Me.cb_bc_z1.Location = New System.Drawing.Point(231, 175)
        Me.cb_bc_z1.Name = "cb_bc_z1"
        Me.cb_bc_z1.Size = New System.Drawing.Size(15, 14)
        Me.cb_bc_z1.TabIndex = 30
        Me.cb_bc_z1.UseVisualStyleBackColor = True
        '
        'lbl_help
        '
        Me.lbl_help.AutoSize = True
        Me.lbl_help.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_help.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_help.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lbl_help.Location = New System.Drawing.Point(330, 33)
        Me.lbl_help.Name = "lbl_help"
        Me.lbl_help.Size = New System.Drawing.Size(65, 13)
        Me.lbl_help.TabIndex = 29
        Me.lbl_help.Text = "was ist das?"
        '
        'cb_Referenz
        '
        Me.cb_Referenz.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Referenz.FormattingEnabled = True
        Me.cb_Referenz.Items.AddRange(New Object() {"P-Touch Etikette 36mm", "QL-Etikette 56mm"})
        Me.cb_Referenz.Location = New System.Drawing.Point(6, 96)
        Me.cb_Referenz.Name = "cb_Referenz"
        Me.cb_Referenz.Size = New System.Drawing.Size(219, 28)
        Me.cb_Referenz.TabIndex = 28
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 80)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 13)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Etiketten Art"
        '
        'cb_Zeile6
        '
        Me.cb_Zeile6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile6.FormattingEnabled = True
        Me.cb_Zeile6.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile6.Location = New System.Drawing.Point(294, 258)
        Me.cb_Zeile6.Name = "cb_Zeile6"
        Me.cb_Zeile6.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile6.TabIndex = 26
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(294, 242)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Zeile 6"
        '
        'cb_Zeile5
        '
        Me.cb_Zeile5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile5.FormattingEnabled = True
        Me.cb_Zeile5.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile5.Location = New System.Drawing.Point(6, 258)
        Me.cb_Zeile5.Name = "cb_Zeile5"
        Me.cb_Zeile5.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile5.TabIndex = 24
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 242)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 13)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Zeile 5"
        '
        'cb_Zeile4
        '
        Me.cb_Zeile4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile4.FormattingEnabled = True
        Me.cb_Zeile4.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile4.Location = New System.Drawing.Point(294, 214)
        Me.cb_Zeile4.Name = "cb_Zeile4"
        Me.cb_Zeile4.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile4.TabIndex = 22
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(294, 198)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 13)
        Me.Label17.TabIndex = 21
        Me.Label17.Text = "Zeile 4"
        '
        'cb_Zeile3
        '
        Me.cb_Zeile3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile3.FormattingEnabled = True
        Me.cb_Zeile3.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile3.Location = New System.Drawing.Point(6, 214)
        Me.cb_Zeile3.Name = "cb_Zeile3"
        Me.cb_Zeile3.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile3.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 198)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Zeile 3"
        '
        'cb_Zeile2
        '
        Me.cb_Zeile2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile2.FormattingEnabled = True
        Me.cb_Zeile2.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile2.Location = New System.Drawing.Point(294, 167)
        Me.cb_Zeile2.Name = "cb_Zeile2"
        Me.cb_Zeile2.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile2.TabIndex = 18
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(294, 151)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Zeile 2"
        '
        'cb_Zeile1
        '
        Me.cb_Zeile1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.cb_Zeile1.FormattingEnabled = True
        Me.cb_Zeile1.Items.AddRange(New Object() {"Linien Name", "Arbeitsplatz", "Material Nr.", "Auftrags Nr.", "Stückzahl", "Stückzahl leer", "Druck Datum", "Datum von", "Datum bis", "CEVA GearBox", "CEVA PCBA", "FS", "Ablieferort", "Visum", "leere Zeile"})
        Me.cb_Zeile1.Location = New System.Drawing.Point(6, 167)
        Me.cb_Zeile1.Name = "cb_Zeile1"
        Me.cb_Zeile1.Size = New System.Drawing.Size(219, 28)
        Me.cb_Zeile1.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 151)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Zeile 1"
        '
        'cb_PrinterAktiv
        '
        Me.cb_PrinterAktiv.AutoSize = True
        Me.cb_PrinterAktiv.Location = New System.Drawing.Point(6, 11)
        Me.cb_PrinterAktiv.Name = "cb_PrinterAktiv"
        Me.cb_PrinterAktiv.Size = New System.Drawing.Size(117, 17)
        Me.cb_PrinterAktiv.TabIndex = 14
        Me.cb_PrinterAktiv.Text = "Drucken Aktivieren"
        Me.cb_PrinterAktiv.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProdKontrolle.My.Resources.Resources.PTP950NW_right
        Me.PictureBox1.Location = New System.Drawing.Point(596, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(242, 236)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(291, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Label Art"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(291, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Station"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Anlage"
        '
        'txt_Printer_LabelArt
        '
        Me.txt_Printer_LabelArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_Printer_LabelArt.Location = New System.Drawing.Point(291, 97)
        Me.txt_Printer_LabelArt.Name = "txt_Printer_LabelArt"
        Me.txt_Printer_LabelArt.Size = New System.Drawing.Size(219, 26)
        Me.txt_Printer_LabelArt.TabIndex = 7
        '
        'txt_Printer_Station
        '
        Me.txt_Printer_Station.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_Printer_Station.Location = New System.Drawing.Point(291, 49)
        Me.txt_Printer_Station.Name = "txt_Printer_Station"
        Me.txt_Printer_Station.Size = New System.Drawing.Size(219, 26)
        Me.txt_Printer_Station.TabIndex = 6
        '
        'txt_Printer_Anlage
        '
        Me.txt_Printer_Anlage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.txt_Printer_Anlage.Location = New System.Drawing.Point(6, 49)
        Me.txt_Printer_Anlage.Name = "txt_Printer_Anlage"
        Me.txt_Printer_Anlage.Size = New System.Drawing.Size(219, 26)
        Me.txt_Printer_Anlage.TabIndex = 5
        '
        'Einstellungen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabIncident)
        Me.Controls.Add(Me.btn_save)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Einstellungen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Einstellungen"
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabIncident.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_SAP_Daten As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_UpdateIntervall As TextBox
    Friend WithEvents chk_Autoupdate As CheckBox
    Friend WithEvents CB_Linie As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_save As Button
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents TblLinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_Checkliste As TextBox
    Friend WithEvents CB_Checkliste As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_startuppfad As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_Systemstatus As TextBox
    Friend WithEvents TabIncident As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_WATS_API_Key As TextBox
    Friend WithEvents lbl_Version As Label
    Friend WithEvents lbl_SAP_Daten As Label
    Friend WithEvents btn_checkUpdate As Button
    Friend WithEvents CB_ASN As CheckBox
    Friend WithEvents lbl_Status_CheckUpdate As Label
    Friend WithEvents CB_DMC As CheckBox
    Friend WithEvents cbx_fauf_start As ComboBox
    Friend WithEvents cbx_Sortierung As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cb_ShowLine As CheckBox
    Friend WithEvents cb_ShowVrgText As CheckBox
    Friend WithEvents cb_show_Lpnr As CheckBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents txt_Printer_Anlage As TextBox
    Friend WithEvents txt_Printer_LabelArt As TextBox
    Friend WithEvents txt_Printer_Station As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cb_vcheck_scanner As CheckBox
    Friend WithEvents cb_Kommentar As CheckBox
    Friend WithEvents cb_Referenz As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents cb_Zeile6 As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cb_Zeile5 As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cb_Zeile4 As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents cb_Zeile3 As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cb_Zeile2 As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cb_Zeile1 As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cb_PrinterAktiv As CheckBox
    Friend WithEvents lbl_help As Label
    Friend WithEvents cb_sollist As CheckBox
    Friend WithEvents cb_lagerort As CheckBox
    Friend WithEvents cb_enddatum As CheckBox
    Friend WithEvents cb_fauf_nicht_anzeigen As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents cb_bc_z6 As CheckBox
    Friend WithEvents cb_bc_z4 As CheckBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cb_bc_z2 As CheckBox
    Friend WithEvents cb_bc_z5 As CheckBox
    Friend WithEvents cb_bc_z3 As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cb_bc_z1 As CheckBox
    Friend WithEvents cb_Support As CheckBox
    Friend WithEvents cb_vorgabezeit As CheckBox
    Friend WithEvents cb_log As CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txt_ihTool As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txt_incident_Mqtt As TextBox
    Friend WithEvents cb_MultiFM As CheckBox
End Class
