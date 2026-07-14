<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PB_Status = New System.Windows.Forms.ProgressBar()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.btn_Anzeigen = New System.Windows.Forms.Button()
        Me.DTSQ00ImportFAUFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SAP = New ProdKontrolle.SAP()
        Me.DGV_FAUF = New System.Windows.Forms.DataGridView()
        Me.Material = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gearbox = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPNR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LP_OK = New System.Windows.Forms.DataGridViewImageColumn()
        Me.VorgangText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Auftrag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Linie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Soll = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ist_SAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Zeit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vorgabezeit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RueckstandFauf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.U = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ProdDatum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FPY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalFail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vrg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPBreite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPMat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vc = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ausnahme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatPPStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FixRuestung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SystemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPAP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kommentar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lagerort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmTagBest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TblLinieBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_ProdKontrolle = New ProdKontrolle.DS_ProdKontrolle()
        Me.DTP_Datum = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbl_Laden = New System.Windows.Forms.Label()
        Me.PB_laden = New System.Windows.Forms.PictureBox()
        Me.T_PB = New System.Windows.Forms.Timer(Me.components)
        Me.T_WatsRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.CMS_DGV_FAUF = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemStart = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragZurücknehmenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemFertig = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemAuftragRückmelden = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragTeilrückmeldenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragSuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LPAbrufenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemStücklisteAnzeigen = New System.Windows.Forms.ToolStripMenuItem()
        Me.DokumentationenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChecklisteAnzeigenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FertigungsdokumenteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LernvideoAbspielenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProduktionskontrolleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PKErldeigtSetztenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TESTLinieInitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_vcheckKont = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeschriftungsetiketteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KommentarLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportAnftrageStellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusschussToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Menu_SAP_Daten_laden = New System.Windows.Forms.ToolStripMenuItem()
        Me.StammdatenNeuLesenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragSuchenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RückstandAnzeigenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuASMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_MenuAuftrag = New System.Windows.Forms.ToolStripDropDownButton()
        Me.btn_Menu_FAUF_Start = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragZurücknehmenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Menu_FAUF_Beenden = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCBAbrufenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Menu_FAUF_Ruck = New System.Windows.Forms.ToolStripMenuItem()
        Me.AuftragTeilrückmeldenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Menu_FAUF_Stuli = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_Menu_FAUF_ProdKont = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheklistenDokumenteVideosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChecklisteAnzeigenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FertigungsdokumenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LernvideoAbspielenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProdKontErledeigtSetztenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VCheckKontrolleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeschriftungsetiketteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SupportAnftrageStellenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusschussToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_Menu_Wochentag = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl_info = New System.Windows.Forms.ToolStripLabel()
        Me.MatchTablesDataSet = New ProdKontrolle.MatchTablesDataSet()
        Me.SSN_ASN_TabBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SSN_ASN_TabTableAdapter = New ProdKontrolle.MatchTablesDataSetTableAdapters.SSN_ASN_TabTableAdapter()
        Me.TableAdapterManager1 = New ProdKontrolle.MatchTablesDataSetTableAdapters.TableAdapterManager()
        Me.T_FW_SAP_import = New System.Windows.Forms.Timer(Me.components)
        Me.FSW_SAP_Export = New System.IO.FileSystemWatcher()
        Me.P_KPI = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_Maschine_vz = New System.Windows.Forms.Label()
        Me.lbl_Pers_vz = New System.Windows.Forms.Label()
        Me.btn_grid_Plus = New System.Windows.Forms.Button()
        Me.btn_grid_Minus = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbl_oee = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbl_RS_BG = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DC = New System.Windows.Forms.Label()
        Me.lbl_RS_DCN = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_FPY = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Soll = New System.Windows.Forms.Label()
        Me.lbl_Ist = New System.Windows.Forms.Label()
        Me.DS_OPM_OEE1 = New ProdKontrolle.DS_OPM_OEE()
        Me.Tbl_StillstandszeitenSummeTableAdapter1 = New ProdKontrolle.DS_OPM_OEETableAdapters.tbl_StillstandszeitenSummeTableAdapter()
        Me.T_neuerTag = New System.Windows.Forms.Timer(Me.components)
        Me.ProgrammübersichtDataSet = New ProdKontrolle.ProgrammübersichtDataSet()
        Me.Tbl_StammBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager2 = New ProdKontrolle.ProgrammübersichtDataSetTableAdapters.TableAdapterManager()
        Me._SSN_ASN_MatchTableDataSet = New ProdKontrolle._SSN_ASN_MatchTableDataSet()
        Me.SSN_ASN_TabBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.SSN_ASN_TabTableAdapter1 = New ProdKontrolle._SSN_ASN_MatchTableDataSetTableAdapters.SSN_ASN_TabTableAdapter()
        Me.TableAdapterManager3 = New ProdKontrolle._SSN_ASN_MatchTableDataSetTableAdapters.TableAdapterManager()
        Me.btn_date_vor = New System.Windows.Forms.Button()
        Me.btn_date_zurueck = New System.Windows.Forms.Button()
        Me.FSW_XML_Change = New System.IO.FileSystemWatcher()
        Me.T_CheckSAPimport = New System.Windows.Forms.Timer(Me.components)
        Me.Tbl_LinieTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager()
        Me.Tbl_FAUF_StatusTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_FAUF_StatusTableAdapter()
        Me.Tbl_ProdKontrolleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_ProdKontrolleTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter()
        Me.Tbl_vcheckKontrolleTableAdapter1 = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_vcheckKontrolleTableAdapter()
        Me.Tbl_SMT_RuestungBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_SMT_RuestungTableAdapter = New ProdKontrolle.DS_ProdKontrolleTableAdapters.tbl_SMT_RuestungTableAdapter()
        Me.dgv_Heijunka1 = New System.Windows.Forms.DataGridView()
        Me.MaterialDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GearboxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPNRDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPOKDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VrgTextDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AuftragDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LinieDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SollDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IstDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IstSAPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZeitDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndDatumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ProdDatumDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FPYDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VrgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LPBreiteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPMATDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VCheckDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AusnahmeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MatPPStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FixruestungDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SystemStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SAPAPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KommentarSpalteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LagerortDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AmTagBestückenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.T_UpdateCheck = New System.Windows.Forms.Timer(Me.components)
        Me.Tbl_StammTableAdapter = New ProdKontrolle.ProgrammübersichtDataSetTableAdapters.PU_tbl_StammTableAdapter()
        CType(Me.DTSQ00ImportFAUFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_FAUF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PB_laden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS_DGV_FAUF.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.MatchTablesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSN_ASN_TabBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FSW_SAP_Export, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_KPI.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DS_OPM_OEE1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgrammübersichtDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_StammBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._SSN_ASN_MatchTableDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSN_ASN_TabBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FSW_XML_Change, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_SMT_RuestungBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv_Heijunka1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PB_Status
        '
        Me.PB_Status.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PB_Status.Location = New System.Drawing.Point(14, 1032)
        Me.PB_Status.Maximum = 1
        Me.PB_Status.Name = "PB_Status"
        Me.PB_Status.Size = New System.Drawing.Size(1863, 25)
        Me.PB_Status.TabIndex = 0
        '
        'lbl_Status
        '
        Me.lbl_Status.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.Location = New System.Drawing.Point(12, 1016)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(37, 13)
        Me.lbl_Status.TabIndex = 4
        Me.lbl_Status.Text = "Status"
        '
        'btn_Anzeigen
        '
        Me.btn_Anzeigen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Anzeigen.BackColor = System.Drawing.SystemColors.Control
        Me.btn_Anzeigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Anzeigen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Anzeigen.Location = New System.Drawing.Point(1685, 53)
        Me.btn_Anzeigen.Name = "btn_Anzeigen"
        Me.btn_Anzeigen.Size = New System.Drawing.Size(192, 39)
        Me.btn_Anzeigen.TabIndex = 10
        Me.btn_Anzeigen.Text = "Aktualisieren"
        Me.btn_Anzeigen.UseVisualStyleBackColor = False
        '
        'DTSQ00ImportFAUFBindingSource
        '
        Me.DTSQ00ImportFAUFBindingSource.DataMember = "DT_SQ00_Import_FAUF"
        Me.DTSQ00ImportFAUFBindingSource.DataSource = Me.SAP
        '
        'SAP
        '
        Me.SAP.DataSetName = "SAP"
        Me.SAP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DGV_FAUF
        '
        Me.DGV_FAUF.AllowUserToAddRows = False
        Me.DGV_FAUF.AllowUserToDeleteRows = False
        Me.DGV_FAUF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_FAUF.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGV_FAUF.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(215, Byte), Integer))
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_FAUF.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.DGV_FAUF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FAUF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Material, Me.Gearbox, Me.LPNR, Me.LP_OK, Me.VorgangText, Me.Auftrag, Me.Linie, Me.Soll, Me.Ist, Me.Ist_SAP, Me.Zeit, Me.Vorgabezeit, Me.EndDatum, Me.RueckstandFauf, Me.U, Me.status, Me.ProdDatum, Me.FPY, Me.TotalFail, Me.Vrg, Me.LPBreite, Me.SAPMat, Me.vc, Me.ausnahme, Me.MatPPStatus, Me.FixRuestung, Me.SystemStatus, Me.SAPAP, Me.Kommentar, Me.Lagerort, Me.AmTagBest})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FAUF.DefaultCellStyle = DataGridViewCellStyle20
        Me.DGV_FAUF.EnableHeadersVisualStyles = False
        Me.DGV_FAUF.GridColor = System.Drawing.SystemColors.Control
        Me.DGV_FAUF.Location = New System.Drawing.Point(10, 97)
        Me.DGV_FAUF.MultiSelect = False
        Me.DGV_FAUF.Name = "DGV_FAUF"
        Me.DGV_FAUF.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_FAUF.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DGV_FAUF.RowHeadersVisible = False
        Me.DGV_FAUF.RowTemplate.Height = 35
        Me.DGV_FAUF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_FAUF.Size = New System.Drawing.Size(1867, 834)
        Me.DGV_FAUF.TabIndex = 12
        '
        'Material
        '
        Me.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Material.DataPropertyName = "Material"
        Me.Material.HeaderText = "Material"
        Me.Material.MinimumWidth = 300
        Me.Material.Name = "Material"
        Me.Material.ReadOnly = True
        Me.Material.ToolTipText = "Materialnummer"
        '
        'Gearbox
        '
        Me.Gearbox.HeaderText = "Gearbox"
        Me.Gearbox.Name = "Gearbox"
        Me.Gearbox.ReadOnly = True
        Me.Gearbox.Visible = False
        Me.Gearbox.Width = 165
        '
        'LPNR
        '
        Me.LPNR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LPNR.HeaderText = "Leiterplatte"
        Me.LPNR.MinimumWidth = 250
        Me.LPNR.Name = "LPNR"
        Me.LPNR.ReadOnly = True
        Me.LPNR.ToolTipText = "Leiterplattennummer"
        Me.LPNR.Visible = False
        '
        'LP_OK
        '
        Me.LP_OK.HeaderText = "LP OK"
        Me.LP_OK.Image = Global.ProdKontrolle.My.Resources.Resources.ausrufezeichen
        Me.LP_OK.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.LP_OK.Name = "LP_OK"
        Me.LP_OK.ReadOnly = True
        Me.LP_OK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LP_OK.ToolTipText = "LP gerüstet"
        Me.LP_OK.Visible = False
        '
        'VorgangText
        '
        Me.VorgangText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.VorgangText.HeaderText = "Vorgangstext"
        Me.VorgangText.Name = "VorgangText"
        Me.VorgangText.ReadOnly = True
        Me.VorgangText.ToolTipText = "Vorgangstext"
        '
        'Auftrag
        '
        Me.Auftrag.HeaderText = "Auftrag"
        Me.Auftrag.Name = "Auftrag"
        Me.Auftrag.ReadOnly = True
        Me.Auftrag.ToolTipText = "Auftragsnummer"
        Me.Auftrag.Width = 165
        '
        'Linie
        '
        Me.Linie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Linie.HeaderText = "Linie"
        Me.Linie.MinimumWidth = 150
        Me.Linie.Name = "Linie"
        Me.Linie.ReadOnly = True
        Me.Linie.ToolTipText = "Linien Name"
        '
        'Soll
        '
        Me.Soll.HeaderText = "Soll"
        Me.Soll.Name = "Soll"
        Me.Soll.ReadOnly = True
        Me.Soll.ToolTipText = "Soll Stückzahl"
        Me.Soll.Width = 95
        '
        'Ist
        '
        Me.Ist.HeaderText = "Ist Wats"
        Me.Ist.Name = "Ist"
        Me.Ist.ReadOnly = True
        Me.Ist.ToolTipText = "Ist Daten von WATS"
        Me.Ist.Width = 115
        '
        'Ist_SAP
        '
        Me.Ist_SAP.HeaderText = "Ist SAP"
        Me.Ist_SAP.Name = "Ist_SAP"
        Me.Ist_SAP.ReadOnly = True
        Me.Ist_SAP.ToolTipText = "Ist Daten von SAP"
        Me.Ist_SAP.Width = 110
        '
        'Zeit
        '
        Me.Zeit.HeaderText = "Zeit"
        Me.Zeit.Name = "Zeit"
        Me.Zeit.ReadOnly = True
        Me.Zeit.ToolTipText = "Frühste Startzeit"
        Me.Zeit.Width = 140
        '
        'Vorgabezeit
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Vorgabezeit.DefaultCellStyle = DataGridViewCellStyle18
        Me.Vorgabezeit.FillWeight = 50.0!
        Me.Vorgabezeit.HeaderText = "Vgz"
        Me.Vorgabezeit.Name = "Vorgabezeit"
        Me.Vorgabezeit.ReadOnly = True
        Me.Vorgabezeit.ToolTipText = "Vorgabezeit"
        Me.Vorgabezeit.Visible = False
        '
        'EndDatum
        '
        Me.EndDatum.HeaderText = "Enddatum"
        Me.EndDatum.Name = "EndDatum"
        Me.EndDatum.ReadOnly = True
        Me.EndDatum.Visible = False
        Me.EndDatum.Width = 160
        '
        'RueckstandFauf
        '
        Me.RueckstandFauf.HeaderText = "R"
        Me.RueckstandFauf.Name = "RueckstandFauf"
        Me.RueckstandFauf.ReadOnly = True
        Me.RueckstandFauf.Width = 40
        '
        'U
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.U.DefaultCellStyle = DataGridViewCellStyle19
        Me.U.HeaderText = "U"
        Me.U.Name = "U"
        Me.U.ReadOnly = True
        Me.U.ToolTipText = "Umterminierungs Kennzeichen"
        Me.U.Width = 40
        '
        'status
        '
        Me.status.HeaderText = "Status"
        Me.status.Image = Global.ProdKontrolle.My.Resources.Resources.leer1
        Me.status.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.ToolTipText = "Status / Vortschritt des Auftrags"
        Me.status.Width = 80
        '
        'ProdDatum
        '
        Me.ProdDatum.HeaderText = "ProdDatum"
        Me.ProdDatum.Name = "ProdDatum"
        Me.ProdDatum.ReadOnly = True
        Me.ProdDatum.ToolTipText = "Produktionsdatum"
        Me.ProdDatum.Visible = False
        '
        'FPY
        '
        Me.FPY.HeaderText = "FPY"
        Me.FPY.Name = "FPY"
        Me.FPY.ReadOnly = True
        Me.FPY.ToolTipText = "First Pass Yield"
        '
        'TotalFail
        '
        Me.TotalFail.HeaderText = "TF"
        Me.TotalFail.Name = "TotalFail"
        Me.TotalFail.ReadOnly = True
        Me.TotalFail.ToolTipText = "Total Fail Geräte"
        Me.TotalFail.Visible = False
        '
        'Vrg
        '
        Me.Vrg.HeaderText = "Vrg"
        Me.Vrg.Name = "Vrg"
        Me.Vrg.ReadOnly = True
        Me.Vrg.ToolTipText = "Vorgangsnummer"
        Me.Vrg.Visible = False
        '
        'LPBreite
        '
        Me.LPBreite.HeaderText = "LP Breite"
        Me.LPBreite.Name = "LPBreite"
        Me.LPBreite.ReadOnly = True
        Me.LPBreite.ToolTipText = "Leiterplattenbreite"
        Me.LPBreite.Visible = False
        Me.LPBreite.Width = 140
        '
        'SAPMat
        '
        Me.SAPMat.HeaderText = "SAPMAT"
        Me.SAPMat.Name = "SAPMat"
        Me.SAPMat.ReadOnly = True
        Me.SAPMat.ToolTipText = "Material aus SAP"
        Me.SAPMat.Visible = False
        '
        'vc
        '
        Me.vc.HeaderText = "v-check"
        Me.vc.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.vc.Name = "vc"
        Me.vc.ReadOnly = True
        Me.vc.ToolTipText = "V-Check Status"
        Me.vc.Visible = False
        '
        'ausnahme
        '
        Me.ausnahme.HeaderText = "ausnahme"
        Me.ausnahme.Name = "ausnahme"
        Me.ausnahme.ReadOnly = True
        Me.ausnahme.Visible = False
        '
        'MatPPStatus
        '
        Me.MatPPStatus.HeaderText = "MatPPStatus"
        Me.MatPPStatus.Name = "MatPPStatus"
        Me.MatPPStatus.ReadOnly = True
        Me.MatPPStatus.ToolTipText = "Material Status aus SAP"
        Me.MatPPStatus.Visible = False
        '
        'FixRuestung
        '
        Me.FixRuestung.HeaderText = "Rüstung"
        Me.FixRuestung.Name = "FixRuestung"
        Me.FixRuestung.ReadOnly = True
        Me.FixRuestung.ToolTipText = "Rüstungsnummer"
        Me.FixRuestung.Visible = False
        Me.FixRuestung.Width = 140
        '
        'SystemStatus
        '
        Me.SystemStatus.HeaderText = "SystemStatus"
        Me.SystemStatus.Name = "SystemStatus"
        Me.SystemStatus.ReadOnly = True
        Me.SystemStatus.ToolTipText = "Sys Status aus SAP"
        Me.SystemStatus.Visible = False
        '
        'SAPAP
        '
        Me.SAPAP.HeaderText = "SAPAP"
        Me.SAPAP.Name = "SAPAP"
        Me.SAPAP.ReadOnly = True
        Me.SAPAP.ToolTipText = "SAP Arbeitsplatz"
        Me.SAPAP.Visible = False
        '
        'Kommentar
        '
        Me.Kommentar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Kommentar.HeaderText = "Kommentar"
        Me.Kommentar.Name = "Kommentar"
        Me.Kommentar.ReadOnly = True
        Me.Kommentar.ToolTipText = "Kommentar"
        Me.Kommentar.Visible = False
        '
        'Lagerort
        '
        Me.Lagerort.HeaderText = "Lagerort"
        Me.Lagerort.Name = "Lagerort"
        Me.Lagerort.ReadOnly = True
        '
        'AmTagBest
        '
        Me.AmTagBest.HeaderText = "AmTagBestücken"
        Me.AmTagBest.Name = "AmTagBest"
        Me.AmTagBest.ReadOnly = True
        Me.AmTagBest.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DataSource = Me.TblLinieBindingSource
        Me.ComboBox1.DisplayMember = "Linie"
        Me.ComboBox1.DropDownHeight = 350
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.5!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.IntegralHeight = False
        Me.ComboBox1.Location = New System.Drawing.Point(284, 53)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(1395, 39)
        Me.ComboBox1.TabIndex = 13
        Me.ComboBox1.ValueMember = "Linie"
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
        'DTP_Datum
        '
        Me.DTP_Datum.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_Datum.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_Datum.Location = New System.Drawing.Point(52, 53)
        Me.DTP_Datum.Name = "DTP_Datum"
        Me.DTP_Datum.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DTP_Datum.Size = New System.Drawing.Size(184, 39)
        Me.DTP_Datum.TabIndex = 15
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lbl_Laden)
        Me.Panel1.Controls.Add(Me.PB_laden)
        Me.Panel1.Location = New System.Drawing.Point(10, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1867, 833)
        Me.Panel1.TabIndex = 16
        '
        'lbl_Laden
        '
        Me.lbl_Laden.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lbl_Laden.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.25!)
        Me.lbl_Laden.Location = New System.Drawing.Point(0, 523)
        Me.lbl_Laden.Name = "lbl_Laden"
        Me.lbl_Laden.Size = New System.Drawing.Size(1867, 310)
        Me.lbl_Laden.TabIndex = 0
        Me.lbl_Laden.Text = "Daten werden geladen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bitte warten"
        Me.lbl_Laden.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PB_laden
        '
        Me.PB_laden.Dock = System.Windows.Forms.DockStyle.Top
        Me.PB_laden.Location = New System.Drawing.Point(0, 0)
        Me.PB_laden.Name = "PB_laden"
        Me.PB_laden.Size = New System.Drawing.Size(1867, 234)
        Me.PB_laden.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PB_laden.TabIndex = 1
        Me.PB_laden.TabStop = False
        '
        'T_PB
        '
        Me.T_PB.Interval = 1500
        '
        'T_WatsRefresh
        '
        Me.T_WatsRefresh.Interval = 60000
        '
        'CMS_DGV_FAUF
        '
        Me.CMS_DGV_FAUF.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMS_DGV_FAUF.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.CMS_DGV_FAUF.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemStart, Me.AuftragZurücknehmenToolStripMenuItem, Me.ToolStripMenuItemFertig, Me.ToolStripMenuItemAuftragRückmelden, Me.AuftragTeilrückmeldenToolStripMenuItem, Me.AuftragSuchenToolStripMenuItem, Me.LPAbrufenToolStripMenuItem, Me.ToolStripMenuItemStücklisteAnzeigen, Me.DokumentationenToolStripMenuItem, Me.ProduktionskontrolleToolStripMenuItem, Me.PKErldeigtSetztenToolStripMenuItem, Me.TESTLinieInitToolStripMenuItem, Me.btn_vcheckKont, Me.BeschriftungsetiketteToolStripMenuItem, Me.KommentarLöschenToolStripMenuItem, Me.SupportAnftrageStellenToolStripMenuItem, Me.AusschussToolStripMenuItem1})
        Me.CMS_DGV_FAUF.Name = "CMS_DGV_FAUF"
        Me.CMS_DGV_FAUF.Size = New System.Drawing.Size(378, 616)
        '
        'ToolStripMenuItemStart
        '
        Me.ToolStripMenuItemStart.Image = Global.ProdKontrolle.My.Resources.Resources.scharz_halb
        Me.ToolStripMenuItemStart.Name = "ToolStripMenuItemStart"
        Me.ToolStripMenuItemStart.Size = New System.Drawing.Size(377, 36)
        Me.ToolStripMenuItemStart.Text = "Auftrag Starten"
        '
        'AuftragZurücknehmenToolStripMenuItem
        '
        Me.AuftragZurücknehmenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.leer1
        Me.AuftragZurücknehmenToolStripMenuItem.Name = "AuftragZurücknehmenToolStripMenuItem"
        Me.AuftragZurücknehmenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.AuftragZurücknehmenToolStripMenuItem.Text = "Auftrag zurücknehmen"
        '
        'ToolStripMenuItemFertig
        '
        Me.ToolStripMenuItemFertig.Image = Global.ProdKontrolle.My.Resources.Resources.scharz_voll
        Me.ToolStripMenuItemFertig.Name = "ToolStripMenuItemFertig"
        Me.ToolStripMenuItemFertig.Size = New System.Drawing.Size(377, 36)
        Me.ToolStripMenuItemFertig.Text = "Auftrag beenden"
        '
        'ToolStripMenuItemAuftragRückmelden
        '
        Me.ToolStripMenuItemAuftragRückmelden.Image = Global.ProdKontrolle.My.Resources.Resources._2DCode
        Me.ToolStripMenuItemAuftragRückmelden.Name = "ToolStripMenuItemAuftragRückmelden"
        Me.ToolStripMenuItemAuftragRückmelden.Size = New System.Drawing.Size(377, 36)
        Me.ToolStripMenuItemAuftragRückmelden.Text = "Auftrag Rückmelden"
        '
        'AuftragTeilrückmeldenToolStripMenuItem
        '
        Me.AuftragTeilrückmeldenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources._2DCode
        Me.AuftragTeilrückmeldenToolStripMenuItem.Name = "AuftragTeilrückmeldenToolStripMenuItem"
        Me.AuftragTeilrückmeldenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.AuftragTeilrückmeldenToolStripMenuItem.Text = "Auftrag Teilrückmelden"
        '
        'AuftragSuchenToolStripMenuItem
        '
        Me.AuftragSuchenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.list
        Me.AuftragSuchenToolStripMenuItem.Name = "AuftragSuchenToolStripMenuItem"
        Me.AuftragSuchenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.AuftragSuchenToolStripMenuItem.Text = "Auftrag Details anzeigen"
        '
        'LPAbrufenToolStripMenuItem
        '
        Me.LPAbrufenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.pcb
        Me.LPAbrufenToolStripMenuItem.Name = "LPAbrufenToolStripMenuItem"
        Me.LPAbrufenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.LPAbrufenToolStripMenuItem.Text = "LP Abrufen"
        '
        'ToolStripMenuItemStücklisteAnzeigen
        '
        Me.ToolStripMenuItemStücklisteAnzeigen.Image = Global.ProdKontrolle.My.Resources.Resources.stuli
        Me.ToolStripMenuItemStücklisteAnzeigen.Name = "ToolStripMenuItemStücklisteAnzeigen"
        Me.ToolStripMenuItemStücklisteAnzeigen.Size = New System.Drawing.Size(377, 36)
        Me.ToolStripMenuItemStücklisteAnzeigen.Text = "Stückliste Anzeigen"
        '
        'DokumentationenToolStripMenuItem
        '
        Me.DokumentationenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChecklisteAnzeigenToolStripMenuItem2, Me.FertigungsdokumenteToolStripMenuItem1, Me.LernvideoAbspielenToolStripMenuItem})
        Me.DokumentationenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.folder
        Me.DokumentationenToolStripMenuItem.Name = "DokumentationenToolStripMenuItem"
        Me.DokumentationenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.DokumentationenToolStripMenuItem.Text = "Dokumentationen"
        '
        'ChecklisteAnzeigenToolStripMenuItem2
        '
        Me.ChecklisteAnzeigenToolStripMenuItem2.Image = Global.ProdKontrolle.My.Resources.Resources.checklist
        Me.ChecklisteAnzeigenToolStripMenuItem2.Name = "ChecklisteAnzeigenToolStripMenuItem2"
        Me.ChecklisteAnzeigenToolStripMenuItem2.Size = New System.Drawing.Size(332, 36)
        Me.ChecklisteAnzeigenToolStripMenuItem2.Text = "Checkliste anzeigen"
        '
        'FertigungsdokumenteToolStripMenuItem1
        '
        Me.FertigungsdokumenteToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.document
        Me.FertigungsdokumenteToolStripMenuItem1.Name = "FertigungsdokumenteToolStripMenuItem1"
        Me.FertigungsdokumenteToolStripMenuItem1.Size = New System.Drawing.Size(332, 36)
        Me.FertigungsdokumenteToolStripMenuItem1.Text = "Fertigungsdokumente"
        '
        'LernvideoAbspielenToolStripMenuItem
        '
        Me.LernvideoAbspielenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.multimedia
        Me.LernvideoAbspielenToolStripMenuItem.Name = "LernvideoAbspielenToolStripMenuItem"
        Me.LernvideoAbspielenToolStripMenuItem.Size = New System.Drawing.Size(332, 36)
        Me.LernvideoAbspielenToolStripMenuItem.Text = "Lernvideo abspielen"
        '
        'ProduktionskontrolleToolStripMenuItem
        '
        Me.ProduktionskontrolleToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.stift
        Me.ProduktionskontrolleToolStripMenuItem.Name = "ProduktionskontrolleToolStripMenuItem"
        Me.ProduktionskontrolleToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.ProduktionskontrolleToolStripMenuItem.Text = "Produktionskontrolle"
        '
        'PKErldeigtSetztenToolStripMenuItem
        '
        Me.PKErldeigtSetztenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.erledigt
        Me.PKErldeigtSetztenToolStripMenuItem.Name = "PKErldeigtSetztenToolStripMenuItem"
        Me.PKErldeigtSetztenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.PKErldeigtSetztenToolStripMenuItem.Text = "Prod.Kont. erledigt setzten"
        '
        'TESTLinieInitToolStripMenuItem
        '
        Me.TESTLinieInitToolStripMenuItem.Enabled = False
        Me.TESTLinieInitToolStripMenuItem.Name = "TESTLinieInitToolStripMenuItem"
        Me.TESTLinieInitToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.TESTLinieInitToolStripMenuItem.Text = "TEST Linie init"
        Me.TESTLinieInitToolStripMenuItem.Visible = False
        '
        'btn_vcheckKont
        '
        Me.btn_vcheckKont.Image = Global.ProdKontrolle.My.Resources.Resources.vc
        Me.btn_vcheckKont.Name = "btn_vcheckKont"
        Me.btn_vcheckKont.Size = New System.Drawing.Size(377, 36)
        Me.btn_vcheckKont.Text = "V-Check Kontrolle"
        '
        'BeschriftungsetiketteToolStripMenuItem
        '
        Me.BeschriftungsetiketteToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.PTP950NW_right
        Me.BeschriftungsetiketteToolStripMenuItem.Name = "BeschriftungsetiketteToolStripMenuItem"
        Me.BeschriftungsetiketteToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.BeschriftungsetiketteToolStripMenuItem.Text = "Beschriftungsetikette"
        '
        'KommentarLöschenToolStripMenuItem
        '
        Me.KommentarLöschenToolStripMenuItem.Name = "KommentarLöschenToolStripMenuItem"
        Me.KommentarLöschenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.KommentarLöschenToolStripMenuItem.Text = "Kommentar löschen"
        '
        'SupportAnftrageStellenToolStripMenuItem
        '
        Me.SupportAnftrageStellenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.support
        Me.SupportAnftrageStellenToolStripMenuItem.Name = "SupportAnftrageStellenToolStripMenuItem"
        Me.SupportAnftrageStellenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.SupportAnftrageStellenToolStripMenuItem.Text = "Support Anfrage"
        '
        'AusschussToolStripMenuItem1
        '
        Me.AusschussToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.trashbin
        Me.AusschussToolStripMenuItem1.Name = "AusschussToolStripMenuItem1"
        Me.AusschussToolStripMenuItem1.Size = New System.Drawing.Size(377, 36)
        Me.AusschussToolStripMenuItem1.Text = "Ausschuss"
        Me.AusschussToolStripMenuItem1.Visible = False
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_SAP_Daten_laden, Me.StammdatenNeuLesenToolStripMenuItem, Me.AuftragSuchenToolStripMenuItem1, Me.EinstellungenToolStripMenuItem, Me.RückstandAnzeigenToolStripMenuItem, Me.ExportToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.HilfeToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(90, 36)
        Me.ToolStripDropDownButton1.Text = "Menu"
        '
        'Menu_SAP_Daten_laden
        '
        Me.Menu_SAP_Daten_laden.Image = Global.ProdKontrolle.My.Resources.Resources.SAP
        Me.Menu_SAP_Daten_laden.Name = "Menu_SAP_Daten_laden"
        Me.Menu_SAP_Daten_laden.Size = New System.Drawing.Size(352, 36)
        Me.Menu_SAP_Daten_laden.Text = "SAP Daten laden"
        '
        'StammdatenNeuLesenToolStripMenuItem
        '
        Me.StammdatenNeuLesenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.robotic_arm
        Me.StammdatenNeuLesenToolStripMenuItem.Name = "StammdatenNeuLesenToolStripMenuItem"
        Me.StammdatenNeuLesenToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.StammdatenNeuLesenToolStripMenuItem.Text = "SMT Stammdaten laden"
        '
        'AuftragSuchenToolStripMenuItem1
        '
        Me.AuftragSuchenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.search
        Me.AuftragSuchenToolStripMenuItem1.Name = "AuftragSuchenToolStripMenuItem1"
        Me.AuftragSuchenToolStripMenuItem1.Size = New System.Drawing.Size(352, 36)
        Me.AuftragSuchenToolStripMenuItem1.Text = "Auftrag suchen"
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.settings
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.EinstellungenToolStripMenuItem.Text = "Einstellungen"
        '
        'RückstandAnzeigenToolStripMenuItem
        '
        Me.RückstandAnzeigenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.backlog
        Me.RückstandAnzeigenToolStripMenuItem.Name = "RückstandAnzeigenToolStripMenuItem"
        Me.RückstandAnzeigenToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.RückstandAnzeigenToolStripMenuItem.Text = "Rückstand Anzeigen"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZuASMToolStripMenuItem, Me.ExcelToolStripMenuItem})
        Me.ExportToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.export
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ZuASMToolStripMenuItem
        '
        Me.ZuASMToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.asm
        Me.ZuASMToolStripMenuItem.Name = "ZuASMToolStripMenuItem"
        Me.ZuASMToolStripMenuItem.Size = New System.Drawing.Size(181, 36)
        Me.ZuASMToolStripMenuItem.Text = "zu ASM"
        '
        'ExcelToolStripMenuItem
        '
        Me.ExcelToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.excel
        Me.ExcelToolStripMenuItem.Name = "ExcelToolStripMenuItem"
        Me.ExcelToolStripMenuItem.Size = New System.Drawing.Size(181, 36)
        Me.ExcelToolStripMenuItem.Text = "zu Excel"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Enabled = False
        Me.UpdateToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.updated
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'HilfeToolStripMenuItem
        '
        Me.HilfeToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.question
        Me.HilfeToolStripMenuItem.Name = "HilfeToolStripMenuItem"
        Me.HilfeToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.HilfeToolStripMenuItem.Text = "Hilfe"
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.remove
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(352, 36)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.btn_MenuAuftrag, Me.lbl_Menu_Wochentag, Me.ToolStripSeparator2, Me.lbl_info})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1887, 39)
        Me.ToolStrip1.TabIndex = 21
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_MenuAuftrag
        '
        Me.btn_MenuAuftrag.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_Menu_FAUF_Start, Me.AuftragZurücknehmenToolStripMenuItem1, Me.btn_Menu_FAUF_Beenden, Me.PCBAbrufenToolStripMenuItem, Me.btn_Menu_FAUF_Ruck, Me.AuftragTeilrückmeldenToolStripMenuItem1, Me.btn_Menu_FAUF_Stuli, Me.btn_Menu_FAUF_ProdKont, Me.CheklistenDokumenteVideosToolStripMenuItem, Me.ProdKontErledeigtSetztenToolStripMenuItem, Me.VCheckKontrolleToolStripMenuItem, Me.BeschriftungsetiketteToolStripMenuItem1, Me.SupportAnftrageStellenToolStripMenuItem1, Me.AusschussToolStripMenuItem})
        Me.btn_MenuAuftrag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_MenuAuftrag.Name = "btn_MenuAuftrag"
        Me.btn_MenuAuftrag.Size = New System.Drawing.Size(106, 36)
        Me.btn_MenuAuftrag.Text = "Auftrag"
        '
        'btn_Menu_FAUF_Start
        '
        Me.btn_Menu_FAUF_Start.Image = Global.ProdKontrolle.My.Resources.Resources.scharz_halb
        Me.btn_Menu_FAUF_Start.Name = "btn_Menu_FAUF_Start"
        Me.btn_Menu_FAUF_Start.Size = New System.Drawing.Size(377, 36)
        Me.btn_Menu_FAUF_Start.Text = "Auftrag Starten"
        '
        'AuftragZurücknehmenToolStripMenuItem1
        '
        Me.AuftragZurücknehmenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.leer1
        Me.AuftragZurücknehmenToolStripMenuItem1.Name = "AuftragZurücknehmenToolStripMenuItem1"
        Me.AuftragZurücknehmenToolStripMenuItem1.Size = New System.Drawing.Size(377, 36)
        Me.AuftragZurücknehmenToolStripMenuItem1.Text = "Auftrag zurücknehmen"
        '
        'btn_Menu_FAUF_Beenden
        '
        Me.btn_Menu_FAUF_Beenden.Image = Global.ProdKontrolle.My.Resources.Resources.scharz_voll
        Me.btn_Menu_FAUF_Beenden.Name = "btn_Menu_FAUF_Beenden"
        Me.btn_Menu_FAUF_Beenden.Size = New System.Drawing.Size(377, 36)
        Me.btn_Menu_FAUF_Beenden.Text = "Auftrag Beenden"
        '
        'PCBAbrufenToolStripMenuItem
        '
        Me.PCBAbrufenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.pcb
        Me.PCBAbrufenToolStripMenuItem.Name = "PCBAbrufenToolStripMenuItem"
        Me.PCBAbrufenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.PCBAbrufenToolStripMenuItem.Text = "LP Abrufen"
        Me.PCBAbrufenToolStripMenuItem.Visible = False
        '
        'btn_Menu_FAUF_Ruck
        '
        Me.btn_Menu_FAUF_Ruck.Image = Global.ProdKontrolle.My.Resources.Resources._2DCode
        Me.btn_Menu_FAUF_Ruck.Name = "btn_Menu_FAUF_Ruck"
        Me.btn_Menu_FAUF_Ruck.Size = New System.Drawing.Size(377, 36)
        Me.btn_Menu_FAUF_Ruck.Text = "Auftrag Rückmelden"
        '
        'AuftragTeilrückmeldenToolStripMenuItem1
        '
        Me.AuftragTeilrückmeldenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources._2DCode
        Me.AuftragTeilrückmeldenToolStripMenuItem1.Name = "AuftragTeilrückmeldenToolStripMenuItem1"
        Me.AuftragTeilrückmeldenToolStripMenuItem1.Size = New System.Drawing.Size(377, 36)
        Me.AuftragTeilrückmeldenToolStripMenuItem1.Text = "Auftrag Teilrückmelden"
        '
        'btn_Menu_FAUF_Stuli
        '
        Me.btn_Menu_FAUF_Stuli.Image = Global.ProdKontrolle.My.Resources.Resources.stuli
        Me.btn_Menu_FAUF_Stuli.Name = "btn_Menu_FAUF_Stuli"
        Me.btn_Menu_FAUF_Stuli.Size = New System.Drawing.Size(377, 36)
        Me.btn_Menu_FAUF_Stuli.Text = "Stückliste"
        '
        'btn_Menu_FAUF_ProdKont
        '
        Me.btn_Menu_FAUF_ProdKont.Image = Global.ProdKontrolle.My.Resources.Resources.stift
        Me.btn_Menu_FAUF_ProdKont.Name = "btn_Menu_FAUF_ProdKont"
        Me.btn_Menu_FAUF_ProdKont.Size = New System.Drawing.Size(377, 36)
        Me.btn_Menu_FAUF_ProdKont.Text = "Produktionskontrolle"
        '
        'CheklistenDokumenteVideosToolStripMenuItem
        '
        Me.CheklistenDokumenteVideosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChecklisteAnzeigenToolStripMenuItem1, Me.FertigungsdokumenteToolStripMenuItem, Me.LernvideoAbspielenToolStripMenuItem1})
        Me.CheklistenDokumenteVideosToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.folder
        Me.CheklistenDokumenteVideosToolStripMenuItem.Name = "CheklistenDokumenteVideosToolStripMenuItem"
        Me.CheklistenDokumenteVideosToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.CheklistenDokumenteVideosToolStripMenuItem.Text = "Dokumentationen"
        '
        'ChecklisteAnzeigenToolStripMenuItem1
        '
        Me.ChecklisteAnzeigenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.checklist
        Me.ChecklisteAnzeigenToolStripMenuItem1.Name = "ChecklisteAnzeigenToolStripMenuItem1"
        Me.ChecklisteAnzeigenToolStripMenuItem1.Size = New System.Drawing.Size(332, 36)
        Me.ChecklisteAnzeigenToolStripMenuItem1.Text = "Checkliste Anzeigen"
        '
        'FertigungsdokumenteToolStripMenuItem
        '
        Me.FertigungsdokumenteToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.document
        Me.FertigungsdokumenteToolStripMenuItem.Name = "FertigungsdokumenteToolStripMenuItem"
        Me.FertigungsdokumenteToolStripMenuItem.Size = New System.Drawing.Size(332, 36)
        Me.FertigungsdokumenteToolStripMenuItem.Text = "Fertigungsdokumente"
        '
        'LernvideoAbspielenToolStripMenuItem1
        '
        Me.LernvideoAbspielenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.multimedia
        Me.LernvideoAbspielenToolStripMenuItem1.Name = "LernvideoAbspielenToolStripMenuItem1"
        Me.LernvideoAbspielenToolStripMenuItem1.Size = New System.Drawing.Size(332, 36)
        Me.LernvideoAbspielenToolStripMenuItem1.Text = "Lernvideo abspielen"
        '
        'ProdKontErledeigtSetztenToolStripMenuItem
        '
        Me.ProdKontErledeigtSetztenToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.erledigt
        Me.ProdKontErledeigtSetztenToolStripMenuItem.Name = "ProdKontErledeigtSetztenToolStripMenuItem"
        Me.ProdKontErledeigtSetztenToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.ProdKontErledeigtSetztenToolStripMenuItem.Text = "Prod.Kont. erledigt setzten"
        '
        'VCheckKontrolleToolStripMenuItem
        '
        Me.VCheckKontrolleToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.vc
        Me.VCheckKontrolleToolStripMenuItem.Name = "VCheckKontrolleToolStripMenuItem"
        Me.VCheckKontrolleToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.VCheckKontrolleToolStripMenuItem.Text = "v-Check Kontrolle"
        Me.VCheckKontrolleToolStripMenuItem.Visible = False
        '
        'BeschriftungsetiketteToolStripMenuItem1
        '
        Me.BeschriftungsetiketteToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.PTP950NW_right
        Me.BeschriftungsetiketteToolStripMenuItem1.Name = "BeschriftungsetiketteToolStripMenuItem1"
        Me.BeschriftungsetiketteToolStripMenuItem1.Size = New System.Drawing.Size(377, 36)
        Me.BeschriftungsetiketteToolStripMenuItem1.Text = "Beschriftungsetikette"
        '
        'SupportAnftrageStellenToolStripMenuItem1
        '
        Me.SupportAnftrageStellenToolStripMenuItem1.Image = Global.ProdKontrolle.My.Resources.Resources.support
        Me.SupportAnftrageStellenToolStripMenuItem1.Name = "SupportAnftrageStellenToolStripMenuItem1"
        Me.SupportAnftrageStellenToolStripMenuItem1.Size = New System.Drawing.Size(377, 36)
        Me.SupportAnftrageStellenToolStripMenuItem1.Text = "Support Anfrage"
        '
        'AusschussToolStripMenuItem
        '
        Me.AusschussToolStripMenuItem.Image = Global.ProdKontrolle.My.Resources.Resources.trashbin
        Me.AusschussToolStripMenuItem.Name = "AusschussToolStripMenuItem"
        Me.AusschussToolStripMenuItem.Size = New System.Drawing.Size(377, 36)
        Me.AusschussToolStripMenuItem.Text = "Ausschuss"
        Me.AusschussToolStripMenuItem.Visible = False
        '
        'lbl_Menu_Wochentag
        '
        Me.lbl_Menu_Wochentag.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbl_Menu_Wochentag.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Menu_Wochentag.Name = "lbl_Menu_Wochentag"
        Me.lbl_Menu_Wochentag.Size = New System.Drawing.Size(258, 36)
        Me.lbl_Menu_Wochentag.Text = "lbl_Menu_Wochentag"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'lbl_info
        '
        Me.lbl_info.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!)
        Me.lbl_info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbl_info.Name = "lbl_info"
        Me.lbl_info.Size = New System.Drawing.Size(0, 36)
        Me.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MatchTablesDataSet
        '
        Me.MatchTablesDataSet.DataSetName = "MatchTablesDataSet"
        Me.MatchTablesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SSN_ASN_TabBindingSource
        '
        Me.SSN_ASN_TabBindingSource.DataMember = "SSN_ASN_Tab"
        Me.SSN_ASN_TabBindingSource.DataSource = Me.MatchTablesDataSet
        '
        'SSN_ASN_TabTableAdapter
        '
        Me.SSN_ASN_TabTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.SSN_ASN_TabTableAdapter = Me.SSN_ASN_TabTableAdapter
        Me.TableAdapterManager1.UpdateOrder = ProdKontrolle.MatchTablesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'T_FW_SAP_import
        '
        Me.T_FW_SAP_import.Interval = 15000
        '
        'FSW_SAP_Export
        '
        Me.FSW_SAP_Export.EnableRaisingEvents = True
        Me.FSW_SAP_Export.Filter = "export.txt"
        Me.FSW_SAP_Export.Path = "\\ch021093\data\Standards\Tools\Produktionskontrolle\SAP_DATA\"
        Me.FSW_SAP_Export.SynchronizingObject = Me
        '
        'P_KPI
        '
        Me.P_KPI.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P_KPI.BackColor = System.Drawing.Color.White
        Me.P_KPI.Controls.Add(Me.GroupBox5)
        Me.P_KPI.Controls.Add(Me.btn_grid_Plus)
        Me.P_KPI.Controls.Add(Me.btn_grid_Minus)
        Me.P_KPI.Controls.Add(Me.GroupBox4)
        Me.P_KPI.Controls.Add(Me.GroupBox3)
        Me.P_KPI.Controls.Add(Me.GroupBox2)
        Me.P_KPI.Controls.Add(Me.GroupBox1)
        Me.P_KPI.Location = New System.Drawing.Point(10, 934)
        Me.P_KPI.Name = "P_KPI"
        Me.P_KPI.Size = New System.Drawing.Size(1867, 82)
        Me.P_KPI.TabIndex = 22
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.lbl_Maschine_vz)
        Me.GroupBox5.Controls.Add(Me.lbl_Pers_vz)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox5.Location = New System.Drawing.Point(837, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(172, 76)
        Me.GroupBox5.TabIndex = 34
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Vorgabezeiten"
        Me.GroupBox5.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label3.Location = New System.Drawing.Point(3, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 20)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "MZ:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.Label2.Location = New System.Drawing.Point(3, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 20)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "VZ:"
        '
        'lbl_Maschine_vz
        '
        Me.lbl_Maschine_vz.AutoSize = True
        Me.lbl_Maschine_vz.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.lbl_Maschine_vz.Location = New System.Drawing.Point(36, 44)
        Me.lbl_Maschine_vz.Name = "lbl_Maschine_vz"
        Me.lbl_Maschine_vz.Size = New System.Drawing.Size(27, 20)
        Me.lbl_Maschine_vz.TabIndex = 32
        Me.lbl_Maschine_vz.Text = "0h"
        '
        'lbl_Pers_vz
        '
        Me.lbl_Pers_vz.AutoSize = True
        Me.lbl_Pers_vz.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!)
        Me.lbl_Pers_vz.Location = New System.Drawing.Point(36, 24)
        Me.lbl_Pers_vz.Name = "lbl_Pers_vz"
        Me.lbl_Pers_vz.Size = New System.Drawing.Size(27, 20)
        Me.lbl_Pers_vz.TabIndex = 31
        Me.lbl_Pers_vz.Text = "0h"
        '
        'btn_grid_Plus
        '
        Me.btn_grid_Plus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_grid_Plus.BackColor = System.Drawing.Color.Transparent
        Me.btn_grid_Plus.BackgroundImage = Global.ProdKontrolle.My.Resources.Resources.lupe_plus
        Me.btn_grid_Plus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_grid_Plus.FlatAppearance.BorderSize = 0
        Me.btn_grid_Plus.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btn_grid_Plus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btn_grid_Plus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_grid_Plus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grid_Plus.Location = New System.Drawing.Point(1756, 27)
        Me.btn_grid_Plus.Name = "btn_grid_Plus"
        Me.btn_grid_Plus.Size = New System.Drawing.Size(40, 38)
        Me.btn_grid_Plus.TabIndex = 35
        Me.btn_grid_Plus.UseVisualStyleBackColor = False
        '
        'btn_grid_Minus
        '
        Me.btn_grid_Minus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_grid_Minus.BackColor = System.Drawing.Color.Transparent
        Me.btn_grid_Minus.BackgroundImage = Global.ProdKontrolle.My.Resources.Resources.lupe_minus
        Me.btn_grid_Minus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btn_grid_Minus.FlatAppearance.BorderSize = 0
        Me.btn_grid_Minus.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.btn_grid_Minus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btn_grid_Minus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btn_grid_Minus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_grid_Minus.Location = New System.Drawing.Point(1811, 27)
        Me.btn_grid_Minus.Name = "btn_grid_Minus"
        Me.btn_grid_Minus.Size = New System.Drawing.Size(40, 38)
        Me.btn_grid_Minus.TabIndex = 34
        Me.btn_grid_Minus.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbl_oee)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox4.Location = New System.Drawing.Point(660, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(172, 76)
        Me.GroupBox4.TabIndex = 33
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "OEE"
        '
        'lbl_oee
        '
        Me.lbl_oee.AutoSize = True
        Me.lbl_oee.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_oee.Location = New System.Drawing.Point(6, 29)
        Me.lbl_oee.Name = "lbl_oee"
        Me.lbl_oee.Size = New System.Drawing.Size(165, 29)
        Me.lbl_oee.TabIndex = 31
        Me.lbl_oee.Text = "OEE: 100.0%"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbl_RS_BG)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.DC)
        Me.GroupBox3.Controls.Add(Me.lbl_RS_DCN)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(482, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(172, 76)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "FAUF Rückstand"
        '
        'lbl_RS_BG
        '
        Me.lbl_RS_BG.AutoSize = True
        Me.lbl_RS_BG.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_RS_BG.Location = New System.Drawing.Point(84, 29)
        Me.lbl_RS_BG.Name = "lbl_RS_BG"
        Me.lbl_RS_BG.Size = New System.Drawing.Size(88, 29)
        Me.lbl_RS_BG.TabIndex = 34
        Me.lbl_RS_BG.Text = "100stk"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(87, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 17)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "BG"
        '
        'DC
        '
        Me.DC.AutoSize = True
        Me.DC.Location = New System.Drawing.Point(9, 15)
        Me.DC.Name = "DC"
        Me.DC.Size = New System.Drawing.Size(27, 17)
        Me.DC.TabIndex = 32
        Me.DC.Text = "DC"
        '
        'lbl_RS_DCN
        '
        Me.lbl_RS_DCN.AutoSize = True
        Me.lbl_RS_DCN.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_RS_DCN.Location = New System.Drawing.Point(6, 29)
        Me.lbl_RS_DCN.Name = "lbl_RS_DCN"
        Me.lbl_RS_DCN.Size = New System.Drawing.Size(88, 29)
        Me.lbl_RS_DCN.TabIndex = 31
        Me.lbl_RS_DCN.Text = "100stk"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_FPY)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(304, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 76)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "First Pass Yield"
        '
        'lbl_FPY
        '
        Me.lbl_FPY.AutoSize = True
        Me.lbl_FPY.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_FPY.Location = New System.Drawing.Point(6, 29)
        Me.lbl_FPY.Name = "lbl_FPY"
        Me.lbl_FPY.Size = New System.Drawing.Size(167, 29)
        Me.lbl_FPY.TabIndex = 30
        Me.lbl_FPY.Text = "FPY: 100.0 %"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbl_Soll)
        Me.GroupBox1.Controls.Add(Me.lbl_Ist)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 76)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Soll/Ist"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.Label1.Location = New System.Drawing.Point(164, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 29)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Ist:"
        '
        'lbl_Soll
        '
        Me.lbl_Soll.AutoSize = True
        Me.lbl_Soll.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_Soll.Location = New System.Drawing.Point(15, 29)
        Me.lbl_Soll.Name = "lbl_Soll"
        Me.lbl_Soll.Size = New System.Drawing.Size(140, 29)
        Me.lbl_Soll.TabIndex = 28
        Me.lbl_Soll.Text = "Soll: 99999"
        '
        'lbl_Ist
        '
        Me.lbl_Ist.AutoSize = True
        Me.lbl_Ist.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.lbl_Ist.Location = New System.Drawing.Point(204, 29)
        Me.lbl_Ist.Name = "lbl_Ist"
        Me.lbl_Ist.Size = New System.Drawing.Size(27, 29)
        Me.lbl_Ist.TabIndex = 29
        Me.lbl_Ist.Text = "0"
        '
        'DS_OPM_OEE1
        '
        Me.DS_OPM_OEE1.DataSetName = "DS_OPM_OEE"
        Me.DS_OPM_OEE1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_StillstandszeitenSummeTableAdapter1
        '
        Me.Tbl_StillstandszeitenSummeTableAdapter1.ClearBeforeFill = True
        '
        'T_neuerTag
        '
        Me.T_neuerTag.Enabled = True
        Me.T_neuerTag.Interval = 900000
        '
        'ProgrammübersichtDataSet
        '
        Me.ProgrammübersichtDataSet.DataSetName = "ProgrammübersichtDataSet"
        Me.ProgrammübersichtDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_StammBindingSource
        '
        Me.Tbl_StammBindingSource.DataMember = "PU_tbl_Stamm"
        Me.Tbl_StammBindingSource.DataSource = Me.ProgrammübersichtDataSet
        '
        'TableAdapterManager2
        '
        Me.TableAdapterManager2.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager2.Connection = Nothing
        Me.TableAdapterManager2.PU_tbl_StammTableAdapter = Nothing
        Me.TableAdapterManager2.UpdateOrder = ProdKontrolle.ProgrammübersichtDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        '_SSN_ASN_MatchTableDataSet
        '
        Me._SSN_ASN_MatchTableDataSet.DataSetName = "_SSN_ASN_MatchTableDataSet"
        Me._SSN_ASN_MatchTableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SSN_ASN_TabBindingSource1
        '
        Me.SSN_ASN_TabBindingSource1.DataMember = "SSN_ASN_Tab"
        Me.SSN_ASN_TabBindingSource1.DataSource = Me._SSN_ASN_MatchTableDataSet
        '
        'SSN_ASN_TabTableAdapter1
        '
        Me.SSN_ASN_TabTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager3
        '
        Me.TableAdapterManager3.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager3.SSN_ASN_TabTableAdapter = Me.SSN_ASN_TabTableAdapter1
        Me.TableAdapterManager3.UpdateOrder = ProdKontrolle._SSN_ASN_MatchTableDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'btn_date_vor
        '
        Me.btn_date_vor.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_date_vor.BackgroundImage = Global.ProdKontrolle.My.Resources.Resources.arrow
        Me.btn_date_vor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_date_vor.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_date_vor.Location = New System.Drawing.Point(239, 53)
        Me.btn_date_vor.Name = "btn_date_vor"
        Me.btn_date_vor.Size = New System.Drawing.Size(40, 39)
        Me.btn_date_vor.TabIndex = 25
        Me.btn_date_vor.UseVisualStyleBackColor = False
        '
        'btn_date_zurueck
        '
        Me.btn_date_zurueck.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btn_date_zurueck.BackgroundImage = Global.ProdKontrolle.My.Resources.Resources.arrow_zurück
        Me.btn_date_zurueck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_date_zurueck.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_date_zurueck.Location = New System.Drawing.Point(9, 53)
        Me.btn_date_zurueck.Name = "btn_date_zurueck"
        Me.btn_date_zurueck.Size = New System.Drawing.Size(40, 39)
        Me.btn_date_zurueck.TabIndex = 26
        Me.btn_date_zurueck.UseVisualStyleBackColor = False
        '
        'FSW_XML_Change
        '
        Me.FSW_XML_Change.EnableRaisingEvents = True
        Me.FSW_XML_Change.Path = "\\ch021093\data\CommonData\SAP_Download\0020\PC1\FAUF"
        Me.FSW_XML_Change.SynchronizingObject = Me
        '
        'T_CheckSAPimport
        '
        Me.T_CheckSAPimport.Interval = 300000
        '
        'Tbl_LinieTableAdapter
        '
        Me.Tbl_LinieTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_ausschussTableAdapter = Nothing
        Me.TableAdapterManager.tbl_DashboardDatenTableAdapter = Nothing
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_KommentarTableAdapter = Nothing
        Me.TableAdapterManager.tbl_LinieTableAdapter = Me.Tbl_LinieTableAdapter
        Me.TableAdapterManager.tbl_lp_checkTableAdapter = Nothing
        Me.TableAdapterManager.tbl_lp_ruestTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProtkollTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_SMT_RuestungTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ProdKontrolle.DS_ProdKontrolleTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_FAUF_StatusTableAdapter
        '
        Me.Tbl_FAUF_StatusTableAdapter.ClearBeforeFill = True
        '
        'Tbl_ProdKontrolleBindingSource
        '
        Me.Tbl_ProdKontrolleBindingSource.DataMember = "tbl_ProdKontrolle"
        Me.Tbl_ProdKontrolleBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'Tbl_ProdKontrolleTableAdapter
        '
        Me.Tbl_ProdKontrolleTableAdapter.ClearBeforeFill = True
        '
        'Tbl_vcheckKontrolleTableAdapter1
        '
        Me.Tbl_vcheckKontrolleTableAdapter1.ClearBeforeFill = True
        '
        'Tbl_SMT_RuestungBindingSource
        '
        Me.Tbl_SMT_RuestungBindingSource.DataMember = "tbl_SMT_Ruestung"
        Me.Tbl_SMT_RuestungBindingSource.DataSource = Me.DS_ProdKontrolle
        '
        'Tbl_SMT_RuestungTableAdapter
        '
        Me.Tbl_SMT_RuestungTableAdapter.ClearBeforeFill = True
        '
        'dgv_Heijunka1
        '
        Me.dgv_Heijunka1.AutoGenerateColumns = False
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Heijunka1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgv_Heijunka1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_Heijunka1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaterialDataGridViewTextBoxColumn, Me.GearboxDataGridViewTextBoxColumn, Me.LPNRDataGridViewTextBoxColumn, Me.LPOKDataGridViewTextBoxColumn, Me.VrgTextDataGridViewTextBoxColumn, Me.AuftragDataGridViewTextBoxColumn, Me.LinieDataGridViewTextBoxColumn, Me.SollDataGridViewTextBoxColumn, Me.IstDataGridViewTextBoxColumn, Me.IstSAPDataGridViewTextBoxColumn, Me.ZeitDataGridViewTextBoxColumn, Me.EndDatumDataGridViewTextBoxColumn, Me.UDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.ProdDatumDataGridViewTextBoxColumn, Me.FPYDataGridViewTextBoxColumn, Me.TFDataGridViewTextBoxColumn, Me.VrgDataGridViewTextBoxColumn, Me.LPBreiteDataGridViewTextBoxColumn, Me.SAPMATDataGridViewTextBoxColumn, Me.VCheckDataGridViewTextBoxColumn, Me.AusnahmeDataGridViewTextBoxColumn, Me.MatPPStatusDataGridViewTextBoxColumn, Me.FixruestungDataGridViewTextBoxColumn, Me.SystemStatusDataGridViewTextBoxColumn, Me.SAPAPDataGridViewTextBoxColumn, Me.KommentarSpalteDataGridViewTextBoxColumn, Me.LagerortDataGridViewTextBoxColumn, Me.AmTagBestückenDataGridViewTextBoxColumn})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_Heijunka1.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgv_Heijunka1.Location = New System.Drawing.Point(926, 41)
        Me.dgv_Heijunka1.Name = "dgv_Heijunka1"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_Heijunka1.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgv_Heijunka1.Size = New System.Drawing.Size(345, 50)
        Me.dgv_Heijunka1.TabIndex = 29
        Me.dgv_Heijunka1.Visible = False
        '
        'MaterialDataGridViewTextBoxColumn
        '
        Me.MaterialDataGridViewTextBoxColumn.DataPropertyName = "Material"
        Me.MaterialDataGridViewTextBoxColumn.HeaderText = "Material"
        Me.MaterialDataGridViewTextBoxColumn.Name = "MaterialDataGridViewTextBoxColumn"
        '
        'GearboxDataGridViewTextBoxColumn
        '
        Me.GearboxDataGridViewTextBoxColumn.DataPropertyName = "Gearbox"
        Me.GearboxDataGridViewTextBoxColumn.HeaderText = "Gearbox"
        Me.GearboxDataGridViewTextBoxColumn.Name = "GearboxDataGridViewTextBoxColumn"
        '
        'LPNRDataGridViewTextBoxColumn
        '
        Me.LPNRDataGridViewTextBoxColumn.DataPropertyName = "LPNR"
        Me.LPNRDataGridViewTextBoxColumn.HeaderText = "LPNR"
        Me.LPNRDataGridViewTextBoxColumn.Name = "LPNRDataGridViewTextBoxColumn"
        '
        'LPOKDataGridViewTextBoxColumn
        '
        Me.LPOKDataGridViewTextBoxColumn.DataPropertyName = "LPOK"
        Me.LPOKDataGridViewTextBoxColumn.HeaderText = "LPOK"
        Me.LPOKDataGridViewTextBoxColumn.Name = "LPOKDataGridViewTextBoxColumn"
        '
        'VrgTextDataGridViewTextBoxColumn
        '
        Me.VrgTextDataGridViewTextBoxColumn.DataPropertyName = "vrgText"
        Me.VrgTextDataGridViewTextBoxColumn.HeaderText = "vrgText"
        Me.VrgTextDataGridViewTextBoxColumn.Name = "VrgTextDataGridViewTextBoxColumn"
        '
        'AuftragDataGridViewTextBoxColumn
        '
        Me.AuftragDataGridViewTextBoxColumn.DataPropertyName = "Auftrag"
        Me.AuftragDataGridViewTextBoxColumn.HeaderText = "Auftrag"
        Me.AuftragDataGridViewTextBoxColumn.Name = "AuftragDataGridViewTextBoxColumn"
        '
        'LinieDataGridViewTextBoxColumn
        '
        Me.LinieDataGridViewTextBoxColumn.DataPropertyName = "Linie"
        Me.LinieDataGridViewTextBoxColumn.HeaderText = "Linie"
        Me.LinieDataGridViewTextBoxColumn.Name = "LinieDataGridViewTextBoxColumn"
        '
        'SollDataGridViewTextBoxColumn
        '
        Me.SollDataGridViewTextBoxColumn.DataPropertyName = "Soll"
        Me.SollDataGridViewTextBoxColumn.HeaderText = "Soll"
        Me.SollDataGridViewTextBoxColumn.Name = "SollDataGridViewTextBoxColumn"
        '
        'IstDataGridViewTextBoxColumn
        '
        Me.IstDataGridViewTextBoxColumn.DataPropertyName = "Ist"
        Me.IstDataGridViewTextBoxColumn.HeaderText = "Ist"
        Me.IstDataGridViewTextBoxColumn.Name = "IstDataGridViewTextBoxColumn"
        '
        'IstSAPDataGridViewTextBoxColumn
        '
        Me.IstSAPDataGridViewTextBoxColumn.DataPropertyName = "Ist_SAP"
        Me.IstSAPDataGridViewTextBoxColumn.HeaderText = "Ist_SAP"
        Me.IstSAPDataGridViewTextBoxColumn.Name = "IstSAPDataGridViewTextBoxColumn"
        '
        'ZeitDataGridViewTextBoxColumn
        '
        Me.ZeitDataGridViewTextBoxColumn.DataPropertyName = "Zeit"
        Me.ZeitDataGridViewTextBoxColumn.HeaderText = "Zeit"
        Me.ZeitDataGridViewTextBoxColumn.Name = "ZeitDataGridViewTextBoxColumn"
        '
        'EndDatumDataGridViewTextBoxColumn
        '
        Me.EndDatumDataGridViewTextBoxColumn.DataPropertyName = "EndDatum"
        Me.EndDatumDataGridViewTextBoxColumn.HeaderText = "EndDatum"
        Me.EndDatumDataGridViewTextBoxColumn.Name = "EndDatumDataGridViewTextBoxColumn"
        '
        'UDataGridViewTextBoxColumn
        '
        Me.UDataGridViewTextBoxColumn.DataPropertyName = "U"
        Me.UDataGridViewTextBoxColumn.HeaderText = "U"
        Me.UDataGridViewTextBoxColumn.Name = "UDataGridViewTextBoxColumn"
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.StatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ProdDatumDataGridViewTextBoxColumn
        '
        Me.ProdDatumDataGridViewTextBoxColumn.DataPropertyName = "ProdDatum"
        Me.ProdDatumDataGridViewTextBoxColumn.HeaderText = "ProdDatum"
        Me.ProdDatumDataGridViewTextBoxColumn.Name = "ProdDatumDataGridViewTextBoxColumn"
        '
        'FPYDataGridViewTextBoxColumn
        '
        Me.FPYDataGridViewTextBoxColumn.DataPropertyName = "FPY"
        Me.FPYDataGridViewTextBoxColumn.HeaderText = "FPY"
        Me.FPYDataGridViewTextBoxColumn.Name = "FPYDataGridViewTextBoxColumn"
        '
        'TFDataGridViewTextBoxColumn
        '
        Me.TFDataGridViewTextBoxColumn.DataPropertyName = "TF"
        Me.TFDataGridViewTextBoxColumn.HeaderText = "TF"
        Me.TFDataGridViewTextBoxColumn.Name = "TFDataGridViewTextBoxColumn"
        '
        'VrgDataGridViewTextBoxColumn
        '
        Me.VrgDataGridViewTextBoxColumn.DataPropertyName = "Vrg"
        Me.VrgDataGridViewTextBoxColumn.HeaderText = "Vrg"
        Me.VrgDataGridViewTextBoxColumn.Name = "VrgDataGridViewTextBoxColumn"
        '
        'LPBreiteDataGridViewTextBoxColumn
        '
        Me.LPBreiteDataGridViewTextBoxColumn.DataPropertyName = "LPBreite"
        Me.LPBreiteDataGridViewTextBoxColumn.HeaderText = "LPBreite"
        Me.LPBreiteDataGridViewTextBoxColumn.Name = "LPBreiteDataGridViewTextBoxColumn"
        '
        'SAPMATDataGridViewTextBoxColumn
        '
        Me.SAPMATDataGridViewTextBoxColumn.DataPropertyName = "SAPMAT"
        Me.SAPMATDataGridViewTextBoxColumn.HeaderText = "SAPMAT"
        Me.SAPMATDataGridViewTextBoxColumn.Name = "SAPMATDataGridViewTextBoxColumn"
        '
        'VCheckDataGridViewTextBoxColumn
        '
        Me.VCheckDataGridViewTextBoxColumn.DataPropertyName = "VCheck"
        Me.VCheckDataGridViewTextBoxColumn.HeaderText = "VCheck"
        Me.VCheckDataGridViewTextBoxColumn.Name = "VCheckDataGridViewTextBoxColumn"
        '
        'AusnahmeDataGridViewTextBoxColumn
        '
        Me.AusnahmeDataGridViewTextBoxColumn.DataPropertyName = "ausnahme"
        Me.AusnahmeDataGridViewTextBoxColumn.HeaderText = "ausnahme"
        Me.AusnahmeDataGridViewTextBoxColumn.Name = "AusnahmeDataGridViewTextBoxColumn"
        '
        'MatPPStatusDataGridViewTextBoxColumn
        '
        Me.MatPPStatusDataGridViewTextBoxColumn.DataPropertyName = "MatPPStatus"
        Me.MatPPStatusDataGridViewTextBoxColumn.HeaderText = "MatPPStatus"
        Me.MatPPStatusDataGridViewTextBoxColumn.Name = "MatPPStatusDataGridViewTextBoxColumn"
        '
        'FixruestungDataGridViewTextBoxColumn
        '
        Me.FixruestungDataGridViewTextBoxColumn.DataPropertyName = "Fixruestung"
        Me.FixruestungDataGridViewTextBoxColumn.HeaderText = "Fixruestung"
        Me.FixruestungDataGridViewTextBoxColumn.Name = "FixruestungDataGridViewTextBoxColumn"
        '
        'SystemStatusDataGridViewTextBoxColumn
        '
        Me.SystemStatusDataGridViewTextBoxColumn.DataPropertyName = "SystemStatus"
        Me.SystemStatusDataGridViewTextBoxColumn.HeaderText = "SystemStatus"
        Me.SystemStatusDataGridViewTextBoxColumn.Name = "SystemStatusDataGridViewTextBoxColumn"
        '
        'SAPAPDataGridViewTextBoxColumn
        '
        Me.SAPAPDataGridViewTextBoxColumn.DataPropertyName = "SAPAP"
        Me.SAPAPDataGridViewTextBoxColumn.HeaderText = "SAPAP"
        Me.SAPAPDataGridViewTextBoxColumn.Name = "SAPAPDataGridViewTextBoxColumn"
        '
        'KommentarSpalteDataGridViewTextBoxColumn
        '
        Me.KommentarSpalteDataGridViewTextBoxColumn.DataPropertyName = "KommentarSpalte"
        Me.KommentarSpalteDataGridViewTextBoxColumn.HeaderText = "KommentarSpalte"
        Me.KommentarSpalteDataGridViewTextBoxColumn.Name = "KommentarSpalteDataGridViewTextBoxColumn"
        '
        'LagerortDataGridViewTextBoxColumn
        '
        Me.LagerortDataGridViewTextBoxColumn.DataPropertyName = "Lagerort"
        Me.LagerortDataGridViewTextBoxColumn.HeaderText = "Lagerort"
        Me.LagerortDataGridViewTextBoxColumn.Name = "LagerortDataGridViewTextBoxColumn"
        '
        'AmTagBestückenDataGridViewTextBoxColumn
        '
        Me.AmTagBestückenDataGridViewTextBoxColumn.DataPropertyName = "AmTagBestücken"
        Me.AmTagBestückenDataGridViewTextBoxColumn.HeaderText = "AmTagBestücken"
        Me.AmTagBestückenDataGridViewTextBoxColumn.Name = "AmTagBestückenDataGridViewTextBoxColumn"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(981, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(29, 27)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Feiertag"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(993, 25)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "MagBesch"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'T_UpdateCheck
        '
        Me.T_UpdateCheck.Interval = 5000
        '
        'Tbl_StammTableAdapter
        '
        Me.Tbl_StammTableAdapter.ClearBeforeFill = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1887, 1061)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgv_Heijunka1)
        Me.Controls.Add(Me.btn_date_zurueck)
        Me.Controls.Add(Me.btn_date_vor)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.P_KPI)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DTP_Datum)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DGV_FAUF)
        Me.Controls.Add(Me.btn_Anzeigen)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.PB_Status)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Heijunka / Produktionskontrolle"
        CType(Me.DTSQ00ImportFAUFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SAP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_FAUF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblLinieBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_ProdKontrolle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PB_laden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS_DGV_FAUF.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.MatchTablesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSN_ASN_TabBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FSW_SAP_Export, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_KPI.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DS_OPM_OEE1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgrammübersichtDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_StammBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._SSN_ASN_MatchTableDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSN_ASN_TabBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FSW_XML_Change, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_ProdKontrolleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_SMT_RuestungBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv_Heijunka1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PB_Status As ProgressBar
    Friend WithEvents lbl_Status As Label
    Friend WithEvents SAP As SAP
    Friend WithEvents DTSQ00ImportFAUFBindingSource As BindingSource
    Friend WithEvents btn_Anzeigen As Button
    Friend WithEvents DS_ProdKontrolle As DS_ProdKontrolle
    Friend WithEvents TblLinieBindingSource As BindingSource
    Friend WithEvents Tbl_LinieTableAdapter As DS_ProdKontrolleTableAdapters.tbl_LinieTableAdapter
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents TableAdapterManager As DS_ProdKontrolleTableAdapters.TableAdapterManager
    Friend WithEvents DTP_Datum As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lbl_Laden As Label
    Friend WithEvents T_PB As Timer
    Friend WithEvents T_WatsRefresh As Timer
    Friend WithEvents PB_laden As PictureBox
    Friend WithEvents CMS_DGV_FAUF As ContextMenuStrip
    Friend WithEvents ToolStripMenuItemStart As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemFertig As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAuftragRückmelden As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemStücklisteAnzeigen As ToolStripMenuItem
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Tbl_FAUF_StatusTableAdapter As DS_ProdKontrolleTableAdapters.tbl_FAUF_StatusTableAdapter
    Friend WithEvents ProduktionskontrolleToolStripMenuItem As ToolStripMenuItem
    Public WithEvents DGV_FAUF As DataGridView
    Friend WithEvents btn_MenuAuftrag As ToolStripDropDownButton
    Friend WithEvents btn_Menu_FAUF_Start As ToolStripMenuItem
    Friend WithEvents btn_Menu_FAUF_Beenden As ToolStripMenuItem
    Friend WithEvents btn_Menu_FAUF_Ruck As ToolStripMenuItem
    Friend WithEvents btn_Menu_FAUF_Stuli As ToolStripMenuItem
    Friend WithEvents btn_Menu_FAUF_ProdKont As ToolStripMenuItem
    Friend WithEvents Menu_SAP_Daten_laden As ToolStripMenuItem
    Friend WithEvents lbl_Menu_Wochentag As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TESTLinieInitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MatchTablesDataSet As MatchTablesDataSet
    Friend WithEvents SSN_ASN_TabBindingSource As BindingSource
    Friend WithEvents SSN_ASN_TabTableAdapter As MatchTablesDataSetTableAdapters.SSN_ASN_TabTableAdapter
    Friend WithEvents TableAdapterManager1 As MatchTablesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents T_FW_SAP_import As Timer
    Friend WithEvents FSW_SAP_Export As IO.FileSystemWatcher
    Friend WithEvents HilfeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RückstandAnzeigenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents P_KPI As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_RS_DCN As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbl_FPY As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lbl_Soll As Label
    Friend WithEvents lbl_Ist As Label
    Friend WithEvents DS_OPM_OEE1 As DS_OPM_OEE
    Friend WithEvents Tbl_StillstandszeitenSummeTableAdapter1 As DS_OPM_OEETableAdapters.tbl_StillstandszeitenSummeTableAdapter
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_oee As Label
    Friend WithEvents Tbl_ProdKontrolleBindingSource As BindingSource
    Friend WithEvents Tbl_ProdKontrolleTableAdapter As DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter
    Friend WithEvents lbl_info As ToolStripLabel
    Friend WithEvents PKErldeigtSetztenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProdKontErledeigtSetztenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents T_neuerTag As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents StammdatenNeuLesenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProgrammübersichtDataSet As ProgrammübersichtDataSet
    Friend WithEvents Tbl_StammBindingSource As BindingSource
    Friend WithEvents TableAdapterManager2 As ProgrammübersichtDataSetTableAdapters.TableAdapterManager
    Friend WithEvents btn_grid_Minus As Button
    Friend WithEvents btn_grid_Plus As Button
    Friend WithEvents _SSN_ASN_MatchTableDataSet As _SSN_ASN_MatchTableDataSet
    Friend WithEvents SSN_ASN_TabBindingSource1 As BindingSource
    Friend WithEvents SSN_ASN_TabTableAdapter1 As _SSN_ASN_MatchTableDataSetTableAdapters.SSN_ASN_TabTableAdapter
    Friend WithEvents TableAdapterManager3 As _SSN_ASN_MatchTableDataSetTableAdapters.TableAdapterManager
    Friend WithEvents btn_date_vor As Button
    Friend WithEvents btn_date_zurueck As Button
    Friend WithEvents btn_vcheckKont As ToolStripMenuItem
    Friend WithEvents Tbl_vcheckKontrolleTableAdapter1 As DS_ProdKontrolleTableAdapters.tbl_vcheckKontrolleTableAdapter
    Friend WithEvents VCheckKontrolleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuftragZurücknehmenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuftragZurücknehmenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents AuftragTeilrückmeldenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuftragTeilrückmeldenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Tbl_SMT_RuestungBindingSource As BindingSource
    Friend WithEvents Tbl_SMT_RuestungTableAdapter As DS_ProdKontrolleTableAdapters.tbl_SMT_RuestungTableAdapter
    Friend WithEvents BeschriftungsetiketteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeschriftungsetiketteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents KommentarLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FSW_XML_Change As IO.FileSystemWatcher
    Friend WithEvents T_CheckSAPimport As Timer
    Friend WithEvents PCBAbrufenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LPAbrufenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgv_Heijunka1 As DataGridView
    Friend WithEvents MaterialDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents GearboxDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LPNRDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LPOKDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VrgTextDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AuftragDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LinieDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SollDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IstDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IstSAPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ZeitDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EndDatumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As DataGridViewImageColumn
    Friend WithEvents ProdDatumDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FPYDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TFDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VrgDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LPBreiteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SAPMATDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VCheckDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AusnahmeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MatPPStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FixruestungDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SystemStatusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SAPAPDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents KommentarSpalteDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LagerortDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AmTagBestückenDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AuftragSuchenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AuftragSuchenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents SupportAnftrageStellenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SupportAnftrageStellenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lbl_Maschine_vz As Label
    Friend WithEvents lbl_Pers_vz As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CheklistenDokumenteVideosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChecklisteAnzeigenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents FertigungsdokumenteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LernvideoAbspielenToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DokumentationenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChecklisteAnzeigenToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents FertigungsdokumenteToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LernvideoAbspielenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents DC As Label
    Friend WithEvents lbl_RS_BG As Label
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ZuASMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExcelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents T_UpdateCheck As Timer
    Friend WithEvents Material As DataGridViewTextBoxColumn
    Friend WithEvents Gearbox As DataGridViewTextBoxColumn
    Friend WithEvents LPNR As DataGridViewTextBoxColumn
    Friend WithEvents LP_OK As DataGridViewImageColumn
    Friend WithEvents VorgangText As DataGridViewTextBoxColumn
    Friend WithEvents Auftrag As DataGridViewTextBoxColumn
    Friend WithEvents Linie As DataGridViewTextBoxColumn
    Friend WithEvents Soll As DataGridViewTextBoxColumn
    Friend WithEvents Ist As DataGridViewTextBoxColumn
    Friend WithEvents Ist_SAP As DataGridViewTextBoxColumn
    Friend WithEvents Zeit As DataGridViewTextBoxColumn
    Friend WithEvents Vorgabezeit As DataGridViewTextBoxColumn
    Friend WithEvents EndDatum As DataGridViewTextBoxColumn
    Friend WithEvents RueckstandFauf As DataGridViewTextBoxColumn
    Friend WithEvents U As DataGridViewTextBoxColumn
    Friend WithEvents status As DataGridViewImageColumn
    Friend WithEvents ProdDatum As DataGridViewTextBoxColumn
    Friend WithEvents FPY As DataGridViewTextBoxColumn
    Friend WithEvents TotalFail As DataGridViewTextBoxColumn
    Friend WithEvents Vrg As DataGridViewTextBoxColumn
    Friend WithEvents LPBreite As DataGridViewTextBoxColumn
    Friend WithEvents SAPMat As DataGridViewTextBoxColumn
    Friend WithEvents vc As DataGridViewImageColumn
    Friend WithEvents ausnahme As DataGridViewTextBoxColumn
    Friend WithEvents MatPPStatus As DataGridViewTextBoxColumn
    Friend WithEvents FixRuestung As DataGridViewTextBoxColumn
    Friend WithEvents SystemStatus As DataGridViewTextBoxColumn
    Friend WithEvents SAPAP As DataGridViewTextBoxColumn
    Friend WithEvents Kommentar As DataGridViewTextBoxColumn
    Friend WithEvents Lagerort As DataGridViewTextBoxColumn
    Friend WithEvents AmTagBest As DataGridViewTextBoxColumn
    Friend WithEvents Tbl_StammTableAdapter As ProgrammübersichtDataSetTableAdapters.PU_tbl_StammTableAdapter
    Friend WithEvents AusschussToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AusschussToolStripMenuItem1 As ToolStripMenuItem
End Class
