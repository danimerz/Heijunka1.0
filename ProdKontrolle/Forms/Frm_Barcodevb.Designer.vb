<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Barcodevb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Barcodevb))
        Me.lbl_ASN = New System.Windows.Forms.Label()
        Me.lbl_FAUF = New System.Windows.Forms.Label()
        Me.ProBar_Laden = New System.Windows.Forms.ProgressBar()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.p_Montage = New System.Windows.Forms.Panel()
        Me.PB_Barcode_FAUF = New System.Windows.Forms.PictureBox()
        Me.PB_Scanner = New System.Windows.Forms.PictureBox()
        Me.P_SMT = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.txt_info = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.lbl_LO = New System.Windows.Forms.Label()
        Me.lbl_fortschritt = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.lbl_fixruestung = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.lbl_lp_laenge = New System.Windows.Forms.Label()
        Me.lbl_lp_breite = New System.Windows.Forms.Label()
        Me.lbl_hub_vg1 = New System.Windows.Forms.Label()
        Me.lbl_hub_vg2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.lbl_Medium_VG1 = New System.Windows.Forms.Label()
        Me.lbl_Medium_VG2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.lbl_SchabVG1 = New System.Windows.Forms.Label()
        Me.lbl_SchabVG2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gb_ofenVG2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_ofenVG2 = New System.Windows.Forms.PictureBox()
        Me.gb_ofenVG1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_ofenVG1 = New System.Windows.Forms.PictureBox()
        Me.gb_lp = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_LpNr = New System.Windows.Forms.PictureBox()
        Me.gb_FAUF = New System.Windows.Forms.GroupBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_FAUF = New System.Windows.Forms.PictureBox()
        Me.gb_stuckzahl = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_Stk = New System.Windows.Forms.PictureBox()
        Me.GB_Material = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PB_BC_Mat = New System.Windows.Forms.PictureBox()
        Me.ProgrammübersichtDataSet = New ProdKontrolle.ProgrammübersichtDataSet()
        Me.Tbl_StammBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_StammTableAdapter = New ProdKontrolle.ProgrammübersichtDataSetTableAdapters.PU_tbl_StammTableAdapter()
        Me.TableAdapterManager = New ProdKontrolle.ProgrammübersichtDataSetTableAdapters.TableAdapterManager()
        Me.P_Auftragskopf = New System.Windows.Forms.Panel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbl_Farbe = New System.Windows.Forms.Label()
        Me.lbl_BehälterText = New System.Windows.Forms.Label()
        Me.lbl_behaelter = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_lagerort = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_langtext = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_pe = New System.Windows.Forms.Label()
        Me.lbl_disponent = New System.Windows.Forms.Label()
        Me.lbl_FertL = New System.Windows.Forms.Label()
        Me.lbl_fertS = New System.Windows.Forms.Label()
        Me.lbl_matkurztext = New System.Windows.Forms.Label()
        Me.gb_fs = New System.Windows.Forms.GroupBox()
        Me.pb_fs = New System.Windows.Forms.PictureBox()
        Me.gb_rs = New System.Windows.Forms.GroupBox()
        Me.pb_rs = New System.Windows.Forms.PictureBox()
        Me.gb_menge = New System.Windows.Forms.GroupBox()
        Me.pb_menge = New System.Windows.Forms.PictureBox()
        Me.gb_mbom = New System.Windows.Forms.GroupBox()
        Me.pb_mbom = New System.Windows.Forms.PictureBox()
        Me.gb_auftrag = New System.Windows.Forms.GroupBox()
        Me.pb_auftrag = New System.Windows.Forms.PictureBox()
        Me.bg_material = New System.Windows.Forms.GroupBox()
        Me.pb_material = New System.Windows.Forms.PictureBox()
        Me.p_Montage.SuspendLayout()
        CType(Me.PB_Barcode_FAUF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Scanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_SMT.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gb_ofenVG2.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_ofenVG2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_ofenVG1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_ofenVG1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_lp.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_LpNr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_FAUF.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_FAUF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_stuckzahl.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_Stk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GB_Material.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_BC_Mat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProgrammübersichtDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_StammBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.P_Auftragskopf.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.gb_fs.SuspendLayout()
        CType(Me.pb_fs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_rs.SuspendLayout()
        CType(Me.pb_rs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_menge.SuspendLayout()
        CType(Me.pb_menge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_mbom.SuspendLayout()
        CType(Me.pb_mbom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gb_auftrag.SuspendLayout()
        CType(Me.pb_auftrag, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bg_material.SuspendLayout()
        CType(Me.pb_material, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_ASN
        '
        Me.lbl_ASN.AutoSize = True
        Me.lbl_ASN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ASN.Location = New System.Drawing.Point(3, 2)
        Me.lbl_ASN.Name = "lbl_ASN"
        Me.lbl_ASN.Size = New System.Drawing.Size(66, 24)
        Me.lbl_ASN.TabIndex = 1
        Me.lbl_ASN.Text = "Label1"
        '
        'lbl_FAUF
        '
        Me.lbl_FAUF.AutoSize = True
        Me.lbl_FAUF.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_FAUF.Location = New System.Drawing.Point(4, 28)
        Me.lbl_FAUF.Name = "lbl_FAUF"
        Me.lbl_FAUF.Size = New System.Drawing.Size(66, 24)
        Me.lbl_FAUF.TabIndex = 5
        Me.lbl_FAUF.Text = "Label1"
        '
        'ProBar_Laden
        '
        Me.ProBar_Laden.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProBar_Laden.Location = New System.Drawing.Point(1, 814)
        Me.ProBar_Laden.Name = "ProBar_Laden"
        Me.ProBar_Laden.Size = New System.Drawing.Size(999, 16)
        Me.ProBar_Laden.TabIndex = 8
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.25!)
        Me.btn_close.Location = New System.Drawing.Point(8, 193)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(485, 63)
        Me.btn_close.TabIndex = 2
        Me.btn_close.Text = "Schliessen"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'p_Montage
        '
        Me.p_Montage.Controls.Add(Me.PB_Barcode_FAUF)
        Me.p_Montage.Controls.Add(Me.PB_Scanner)
        Me.p_Montage.Controls.Add(Me.lbl_ASN)
        Me.p_Montage.Controls.Add(Me.lbl_FAUF)
        Me.p_Montage.Controls.Add(Me.btn_close)
        Me.p_Montage.Location = New System.Drawing.Point(4, 12)
        Me.p_Montage.Name = "p_Montage"
        Me.p_Montage.Size = New System.Drawing.Size(504, 265)
        Me.p_Montage.TabIndex = 9
        '
        'PB_Barcode_FAUF
        '
        Me.PB_Barcode_FAUF.Location = New System.Drawing.Point(7, 57)
        Me.PB_Barcode_FAUF.Name = "PB_Barcode_FAUF"
        Me.PB_Barcode_FAUF.Size = New System.Drawing.Size(357, 120)
        Me.PB_Barcode_FAUF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_Barcode_FAUF.TabIndex = 7
        Me.PB_Barcode_FAUF.TabStop = False
        '
        'PB_Scanner
        '
        Me.PB_Scanner.Image = CType(resources.GetObject("PB_Scanner.Image"), System.Drawing.Image)
        Me.PB_Scanner.Location = New System.Drawing.Point(371, 57)
        Me.PB_Scanner.Name = "PB_Scanner"
        Me.PB_Scanner.Size = New System.Drawing.Size(122, 120)
        Me.PB_Scanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PB_Scanner.TabIndex = 3
        Me.PB_Scanner.TabStop = False
        '
        'P_SMT
        '
        Me.P_SMT.Controls.Add(Me.GroupBox7)
        Me.P_SMT.Controls.Add(Me.GroupBox6)
        Me.P_SMT.Controls.Add(Me.lbl_fortschritt)
        Me.P_SMT.Controls.Add(Me.GroupBox5)
        Me.P_SMT.Controls.Add(Me.GroupBox4)
        Me.P_SMT.Controls.Add(Me.GroupBox3)
        Me.P_SMT.Controls.Add(Me.GroupBox2)
        Me.P_SMT.Controls.Add(Me.GroupBox1)
        Me.P_SMT.Location = New System.Drawing.Point(1, 3)
        Me.P_SMT.Name = "P_SMT"
        Me.P_SMT.Size = New System.Drawing.Size(982, 608)
        Me.P_SMT.TabIndex = 10
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.PictureBox13)
        Me.GroupBox7.Controls.Add(Me.txt_info)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(407, 530)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(556, 69)
        Me.GroupBox7.TabIndex = 34
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Info"
        '
        'PictureBox13
        '
        Me.PictureBox13.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox13.Location = New System.Drawing.Point(9, 17)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(541, 46)
        Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox13.TabIndex = 10
        Me.PictureBox13.TabStop = False
        '
        'txt_info
        '
        Me.txt_info.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_info.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txt_info.Location = New System.Drawing.Point(10, 24)
        Me.txt_info.Multiline = True
        Me.txt_info.Name = "txt_info"
        Me.txt_info.Size = New System.Drawing.Size(541, 39)
        Me.txt_info.TabIndex = 0
        Me.txt_info.Text = "Info:"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PictureBox12)
        Me.GroupBox6.Controls.Add(Me.lbl_LO)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(215, 530)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(186, 69)
        Me.GroupBox6.TabIndex = 33
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Ablieferort"
        '
        'PictureBox12
        '
        Me.PictureBox12.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox12.Location = New System.Drawing.Point(102, 17)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(75, 46)
        Me.PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox12.TabIndex = 10
        Me.PictureBox12.TabStop = False
        '
        'lbl_LO
        '
        Me.lbl_LO.AutoSize = True
        Me.lbl_LO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_LO.Location = New System.Drawing.Point(6, 30)
        Me.lbl_LO.Name = "lbl_LO"
        Me.lbl_LO.Size = New System.Drawing.Size(90, 20)
        Me.lbl_LO.TabIndex = 32
        Me.lbl_LO.Text = "Ablieferort: "
        '
        'lbl_fortschritt
        '
        Me.lbl_fortschritt.AutoSize = True
        Me.lbl_fortschritt.Location = New System.Drawing.Point(3, 595)
        Me.lbl_fortschritt.Name = "lbl_fortschritt"
        Me.lbl_fortschritt.Size = New System.Drawing.Size(39, 13)
        Me.lbl_fortschritt.TabIndex = 33
        Me.lbl_fortschritt.Text = "Label1"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.PictureBox11)
        Me.GroupBox5.Controls.Add(Me.lbl_fixruestung)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(25, 530)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(186, 69)
        Me.GroupBox5.TabIndex = 25
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Rüstung"
        '
        'PictureBox11
        '
        Me.PictureBox11.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox11.Location = New System.Drawing.Point(103, 17)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(72, 46)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox11.TabIndex = 10
        Me.PictureBox11.TabStop = False
        '
        'lbl_fixruestung
        '
        Me.lbl_fixruestung.AutoSize = True
        Me.lbl_fixruestung.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_fixruestung.Location = New System.Drawing.Point(6, 30)
        Me.lbl_fixruestung.Name = "lbl_fixruestung"
        Me.lbl_fixruestung.Size = New System.Drawing.Size(91, 20)
        Me.lbl_fixruestung.TabIndex = 32
        Me.lbl_fixruestung.Text = "Fixrüstung: "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.PictureBox10)
        Me.GroupBox4.Controls.Add(Me.PictureBox9)
        Me.GroupBox4.Controls.Add(Me.lbl_lp_laenge)
        Me.GroupBox4.Controls.Add(Me.lbl_lp_breite)
        Me.GroupBox4.Controls.Add(Me.lbl_hub_vg1)
        Me.GroupBox4.Controls.Add(Me.lbl_hub_vg2)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(661, 421)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(302, 108)
        Me.GroupBox4.TabIndex = 27
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "LP Informationen"
        '
        'PictureBox10
        '
        Me.PictureBox10.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox10.Location = New System.Drawing.Point(237, 30)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(60, 48)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox10.TabIndex = 31
        Me.PictureBox10.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox9.Location = New System.Drawing.Point(89, 31)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(58, 47)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox9.TabIndex = 27
        Me.PictureBox9.TabStop = False
        '
        'lbl_lp_laenge
        '
        Me.lbl_lp_laenge.AutoSize = True
        Me.lbl_lp_laenge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lp_laenge.Location = New System.Drawing.Point(6, 30)
        Me.lbl_lp_laenge.Name = "lbl_lp_laenge"
        Me.lbl_lp_laenge.Size = New System.Drawing.Size(81, 20)
        Me.lbl_lp_laenge.TabIndex = 27
        Me.lbl_lp_laenge.Text = "LP Länge:"
        '
        'lbl_lp_breite
        '
        Me.lbl_lp_breite.AutoSize = True
        Me.lbl_lp_breite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_lp_breite.Location = New System.Drawing.Point(6, 62)
        Me.lbl_lp_breite.Name = "lbl_lp_breite"
        Me.lbl_lp_breite.Size = New System.Drawing.Size(78, 20)
        Me.lbl_lp_breite.TabIndex = 28
        Me.lbl_lp_breite.Text = "LP Breite:"
        '
        'lbl_hub_vg1
        '
        Me.lbl_hub_vg1.AutoSize = True
        Me.lbl_hub_vg1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hub_vg1.Location = New System.Drawing.Point(154, 30)
        Me.lbl_hub_vg1.Name = "lbl_hub_vg1"
        Me.lbl_hub_vg1.Size = New System.Drawing.Size(80, 20)
        Me.lbl_hub_vg1.TabIndex = 29
        Me.lbl_hub_vg1.Text = "Hub VG1:"
        '
        'lbl_hub_vg2
        '
        Me.lbl_hub_vg2.AutoSize = True
        Me.lbl_hub_vg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_hub_vg2.Location = New System.Drawing.Point(154, 62)
        Me.lbl_hub_vg2.Name = "lbl_hub_vg2"
        Me.lbl_hub_vg2.Size = New System.Drawing.Size(80, 20)
        Me.lbl_hub_vg2.TabIndex = 30
        Me.lbl_hub_vg2.Text = "Hub VG2:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.PictureBox8)
        Me.GroupBox3.Controls.Add(Me.lbl_Medium_VG1)
        Me.GroupBox3.Controls.Add(Me.lbl_Medium_VG2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(309, 421)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(346, 108)
        Me.GroupBox3.TabIndex = 25
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Medium"
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox8.Location = New System.Drawing.Point(145, 31)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(118, 48)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox8.TabIndex = 25
        Me.PictureBox8.TabStop = False
        '
        'lbl_Medium_VG1
        '
        Me.lbl_Medium_VG1.AutoSize = True
        Me.lbl_Medium_VG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Medium_VG1.Location = New System.Drawing.Point(6, 30)
        Me.lbl_Medium_VG1.Name = "lbl_Medium_VG1"
        Me.lbl_Medium_VG1.Size = New System.Drawing.Size(110, 20)
        Me.lbl_Medium_VG1.TabIndex = 25
        Me.lbl_Medium_VG1.Text = "Medium VG 1:"
        '
        'lbl_Medium_VG2
        '
        Me.lbl_Medium_VG2.AutoSize = True
        Me.lbl_Medium_VG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Medium_VG2.Location = New System.Drawing.Point(6, 63)
        Me.lbl_Medium_VG2.Name = "lbl_Medium_VG2"
        Me.lbl_Medium_VG2.Size = New System.Drawing.Size(110, 20)
        Me.lbl_Medium_VG2.TabIndex = 26
        Me.lbl_Medium_VG2.Text = "Medium VG 2:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox7)
        Me.GroupBox2.Controls.Add(Me.lbl_SchabVG1)
        Me.GroupBox2.Controls.Add(Me.lbl_SchabVG2)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(25, 421)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(278, 108)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Schablonen"
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox7.Location = New System.Drawing.Point(144, 31)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(118, 47)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox7.TabIndex = 10
        Me.PictureBox7.TabStop = False
        '
        'lbl_SchabVG1
        '
        Me.lbl_SchabVG1.AutoSize = True
        Me.lbl_SchabVG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SchabVG1.Location = New System.Drawing.Point(8, 29)
        Me.lbl_SchabVG1.Name = "lbl_SchabVG1"
        Me.lbl_SchabVG1.Size = New System.Drawing.Size(130, 20)
        Me.lbl_SchabVG1.TabIndex = 23
        Me.lbl_SchabVG1.Text = "Schablone VG 1:"
        '
        'lbl_SchabVG2
        '
        Me.lbl_SchabVG2.AutoSize = True
        Me.lbl_SchabVG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SchabVG2.Location = New System.Drawing.Point(8, 61)
        Me.lbl_SchabVG2.Name = "lbl_SchabVG2"
        Me.lbl_SchabVG2.Size = New System.Drawing.Size(130, 20)
        Me.lbl_SchabVG2.TabIndex = 24
        Me.lbl_SchabVG2.Text = "Schablone VG 2:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gb_ofenVG2)
        Me.GroupBox1.Controls.Add(Me.gb_ofenVG1)
        Me.GroupBox1.Controls.Add(Me.gb_lp)
        Me.GroupBox1.Controls.Add(Me.gb_FAUF)
        Me.GroupBox1.Controls.Add(Me.gb_stuckzahl)
        Me.GroupBox1.Controls.Add(Me.GB_Material)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(25, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(938, 412)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Auftragsdaten"
        '
        'gb_ofenVG2
        '
        Me.gb_ofenVG2.Controls.Add(Me.PictureBox6)
        Me.gb_ofenVG2.Controls.Add(Me.PB_BC_ofenVG2)
        Me.gb_ofenVG2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_ofenVG2.Location = New System.Drawing.Point(496, 279)
        Me.gb_ofenVG2.Name = "gb_ofenVG2"
        Me.gb_ofenVG2.Size = New System.Drawing.Size(430, 117)
        Me.gb_ofenVG2.TabIndex = 23
        Me.gb_ofenVG2.TabStop = False
        Me.gb_ofenVG2.Text = "Ofen Vorgang 2"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox6.Location = New System.Drawing.Point(161, 25)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 9
        Me.PictureBox6.TabStop = False
        '
        'PB_BC_ofenVG2
        '
        Me.PB_BC_ofenVG2.Location = New System.Drawing.Point(10, 25)
        Me.PB_BC_ofenVG2.Name = "PB_BC_ofenVG2"
        Me.PB_BC_ofenVG2.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_ofenVG2.TabIndex = 3
        Me.PB_BC_ofenVG2.TabStop = False
        '
        'gb_ofenVG1
        '
        Me.gb_ofenVG1.Controls.Add(Me.PictureBox3)
        Me.gb_ofenVG1.Controls.Add(Me.PB_BC_ofenVG1)
        Me.gb_ofenVG1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_ofenVG1.Location = New System.Drawing.Point(15, 279)
        Me.gb_ofenVG1.Name = "gb_ofenVG1"
        Me.gb_ofenVG1.Size = New System.Drawing.Size(430, 117)
        Me.gb_ofenVG1.TabIndex = 22
        Me.gb_ofenVG1.TabStop = False
        Me.gb_ofenVG1.Text = "Ofen Vorgang 1"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox3.Location = New System.Drawing.Point(145, 25)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PB_BC_ofenVG1
        '
        Me.PB_BC_ofenVG1.Location = New System.Drawing.Point(10, 25)
        Me.PB_BC_ofenVG1.Name = "PB_BC_ofenVG1"
        Me.PB_BC_ofenVG1.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_ofenVG1.TabIndex = 3
        Me.PB_BC_ofenVG1.TabStop = False
        '
        'gb_lp
        '
        Me.gb_lp.Controls.Add(Me.PictureBox5)
        Me.gb_lp.Controls.Add(Me.PB_BC_LpNr)
        Me.gb_lp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_lp.Location = New System.Drawing.Point(496, 156)
        Me.gb_lp.Name = "gb_lp"
        Me.gb_lp.Size = New System.Drawing.Size(430, 117)
        Me.gb_lp.TabIndex = 22
        Me.gb_lp.TabStop = False
        Me.gb_lp.Text = "Leiterplatten:"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox5.Location = New System.Drawing.Point(161, 25)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox5.TabIndex = 8
        Me.PictureBox5.TabStop = False
        '
        'PB_BC_LpNr
        '
        Me.PB_BC_LpNr.Location = New System.Drawing.Point(10, 25)
        Me.PB_BC_LpNr.Name = "PB_BC_LpNr"
        Me.PB_BC_LpNr.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_LpNr.TabIndex = 3
        Me.PB_BC_LpNr.TabStop = False
        '
        'gb_FAUF
        '
        Me.gb_FAUF.Controls.Add(Me.PictureBox4)
        Me.gb_FAUF.Controls.Add(Me.PB_BC_FAUF)
        Me.gb_FAUF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_FAUF.Location = New System.Drawing.Point(496, 33)
        Me.gb_FAUF.Name = "gb_FAUF"
        Me.gb_FAUF.Size = New System.Drawing.Size(430, 117)
        Me.gb_FAUF.TabIndex = 21
        Me.gb_FAUF.TabStop = False
        Me.gb_FAUF.Text = "Auftragsnummer:"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox4.Location = New System.Drawing.Point(161, 25)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'PB_BC_FAUF
        '
        Me.PB_BC_FAUF.Location = New System.Drawing.Point(9, 26)
        Me.PB_BC_FAUF.Name = "PB_BC_FAUF"
        Me.PB_BC_FAUF.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_FAUF.TabIndex = 3
        Me.PB_BC_FAUF.TabStop = False
        '
        'gb_stuckzahl
        '
        Me.gb_stuckzahl.Controls.Add(Me.PictureBox2)
        Me.gb_stuckzahl.Controls.Add(Me.PB_BC_Stk)
        Me.gb_stuckzahl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_stuckzahl.Location = New System.Drawing.Point(15, 156)
        Me.gb_stuckzahl.Name = "gb_stuckzahl"
        Me.gb_stuckzahl.Size = New System.Drawing.Size(430, 117)
        Me.gb_stuckzahl.TabIndex = 21
        Me.gb_stuckzahl.TabStop = False
        Me.gb_stuckzahl.Text = "Stückzahl:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox2.Location = New System.Drawing.Point(145, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PB_BC_Stk
        '
        Me.PB_BC_Stk.Location = New System.Drawing.Point(10, 25)
        Me.PB_BC_Stk.Name = "PB_BC_Stk"
        Me.PB_BC_Stk.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_Stk.TabIndex = 3
        Me.PB_BC_Stk.TabStop = False
        '
        'GB_Material
        '
        Me.GB_Material.Controls.Add(Me.PictureBox1)
        Me.GB_Material.Controls.Add(Me.PB_BC_Mat)
        Me.GB_Material.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GB_Material.Location = New System.Drawing.Point(15, 33)
        Me.GB_Material.Name = "GB_Material"
        Me.GB_Material.Size = New System.Drawing.Size(430, 117)
        Me.GB_Material.TabIndex = 20
        Me.GB_Material.TabStop = False
        Me.GB_Material.Text = "MaterialNr.:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProdKontrolle.My.Resources.Resources.tenor
        Me.PictureBox1.Location = New System.Drawing.Point(145, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(118, 81)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PB_BC_Mat
        '
        Me.PB_BC_Mat.Location = New System.Drawing.Point(9, 26)
        Me.PB_BC_Mat.Name = "PB_BC_Mat"
        Me.PB_BC_Mat.Size = New System.Drawing.Size(413, 81)
        Me.PB_BC_Mat.TabIndex = 3
        Me.PB_BC_Mat.TabStop = False
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
        'Tbl_StammTableAdapter
        '
        Me.Tbl_StammTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.PU_tbl_StammTableAdapter = Me.Tbl_StammTableAdapter
        Me.TableAdapterManager.UpdateOrder = ProdKontrolle.ProgrammübersichtDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'P_Auftragskopf
        '
        Me.P_Auftragskopf.Controls.Add(Me.GroupBox8)
        Me.P_Auftragskopf.Controls.Add(Me.gb_fs)
        Me.P_Auftragskopf.Controls.Add(Me.gb_rs)
        Me.P_Auftragskopf.Controls.Add(Me.gb_menge)
        Me.P_Auftragskopf.Controls.Add(Me.gb_mbom)
        Me.P_Auftragskopf.Controls.Add(Me.gb_auftrag)
        Me.P_Auftragskopf.Controls.Add(Me.bg_material)
        Me.P_Auftragskopf.Location = New System.Drawing.Point(4, 6)
        Me.P_Auftragskopf.Name = "P_Auftragskopf"
        Me.P_Auftragskopf.Size = New System.Drawing.Size(893, 663)
        Me.P_Auftragskopf.TabIndex = 11
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.lbl_Farbe)
        Me.GroupBox8.Controls.Add(Me.lbl_BehälterText)
        Me.GroupBox8.Controls.Add(Me.lbl_behaelter)
        Me.GroupBox8.Controls.Add(Me.Label7)
        Me.GroupBox8.Controls.Add(Me.lbl_lagerort)
        Me.GroupBox8.Controls.Add(Me.Label6)
        Me.GroupBox8.Controls.Add(Me.Label5)
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.Label2)
        Me.GroupBox8.Controls.Add(Me.lbl_langtext)
        Me.GroupBox8.Controls.Add(Me.Label1)
        Me.GroupBox8.Controls.Add(Me.lbl_pe)
        Me.GroupBox8.Controls.Add(Me.lbl_disponent)
        Me.GroupBox8.Controls.Add(Me.lbl_FertL)
        Me.GroupBox8.Controls.Add(Me.lbl_fertS)
        Me.GroupBox8.Controls.Add(Me.lbl_matkurztext)
        Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(8, 391)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(876, 269)
        Me.GroupBox8.TabIndex = 24
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Kopfdaten:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 162)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Farbe:"
        '
        'lbl_Farbe
        '
        Me.lbl_Farbe.AutoSize = True
        Me.lbl_Farbe.Location = New System.Drawing.Point(142, 162)
        Me.lbl_Farbe.Name = "lbl_Farbe"
        Me.lbl_Farbe.Size = New System.Drawing.Size(51, 20)
        Me.lbl_Farbe.TabIndex = 16
        Me.lbl_Farbe.Text = "Farbe"
        '
        'lbl_BehälterText
        '
        Me.lbl_BehälterText.AutoSize = True
        Me.lbl_BehälterText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_BehälterText.Location = New System.Drawing.Point(5, 142)
        Me.lbl_BehälterText.Name = "lbl_BehälterText"
        Me.lbl_BehälterText.Size = New System.Drawing.Size(82, 20)
        Me.lbl_BehälterText.TabIndex = 15
        Me.lbl_BehälterText.Text = "Behälter:"
        '
        'lbl_behaelter
        '
        Me.lbl_behaelter.AutoSize = True
        Me.lbl_behaelter.Location = New System.Drawing.Point(142, 142)
        Me.lbl_behaelter.Name = "lbl_behaelter"
        Me.lbl_behaelter.Size = New System.Drawing.Size(69, 20)
        Me.lbl_behaelter.TabIndex = 14
        Me.lbl_behaelter.Text = "Behälter"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Lagerort:"
        '
        'lbl_lagerort
        '
        Me.lbl_lagerort.AutoSize = True
        Me.lbl_lagerort.Location = New System.Drawing.Point(142, 122)
        Me.lbl_lagerort.Name = "lbl_lagerort"
        Me.lbl_lagerort.Size = New System.Drawing.Size(69, 20)
        Me.lbl_lagerort.TabIndex = 12
        Me.lbl_lagerort.Text = "Lagerort"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(114, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "PE-Verantw.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Disponent:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fert.linie:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Fert.steurer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Materialkurztext:"
        '
        'lbl_langtext
        '
        Me.lbl_langtext.AutoSize = True
        Me.lbl_langtext.Location = New System.Drawing.Point(431, 47)
        Me.lbl_langtext.Name = "lbl_langtext"
        Me.lbl_langtext.Size = New System.Drawing.Size(14, 20)
        Me.lbl_langtext.TabIndex = 6
        Me.lbl_langtext.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(431, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Langtext Kopf:"
        '
        'lbl_pe
        '
        Me.lbl_pe.AutoSize = True
        Me.lbl_pe.Location = New System.Drawing.Point(142, 102)
        Me.lbl_pe.Name = "lbl_pe"
        Me.lbl_pe.Size = New System.Drawing.Size(102, 20)
        Me.lbl_pe.TabIndex = 4
        Me.lbl_pe.Text = "PE-Verantw.:"
        '
        'lbl_disponent
        '
        Me.lbl_disponent.AutoSize = True
        Me.lbl_disponent.Location = New System.Drawing.Point(142, 82)
        Me.lbl_disponent.Name = "lbl_disponent"
        Me.lbl_disponent.Size = New System.Drawing.Size(86, 20)
        Me.lbl_disponent.TabIndex = 3
        Me.lbl_disponent.Text = "Disponent:"
        '
        'lbl_FertL
        '
        Me.lbl_FertL.AutoSize = True
        Me.lbl_FertL.Location = New System.Drawing.Point(143, 62)
        Me.lbl_FertL.Name = "lbl_FertL"
        Me.lbl_FertL.Size = New System.Drawing.Size(73, 20)
        Me.lbl_FertL.TabIndex = 2
        Me.lbl_FertL.Text = "Fert.linie:"
        '
        'lbl_fertS
        '
        Me.lbl_fertS.AutoSize = True
        Me.lbl_fertS.Location = New System.Drawing.Point(143, 42)
        Me.lbl_fertS.Name = "lbl_fertS"
        Me.lbl_fertS.Size = New System.Drawing.Size(96, 20)
        Me.lbl_fertS.TabIndex = 1
        Me.lbl_fertS.Text = "Fert.steurer:"
        '
        'lbl_matkurztext
        '
        Me.lbl_matkurztext.AutoSize = True
        Me.lbl_matkurztext.Location = New System.Drawing.Point(143, 22)
        Me.lbl_matkurztext.Name = "lbl_matkurztext"
        Me.lbl_matkurztext.Size = New System.Drawing.Size(125, 20)
        Me.lbl_matkurztext.TabIndex = 0
        Me.lbl_matkurztext.Text = "Materialkurztext:"
        '
        'gb_fs
        '
        Me.gb_fs.Controls.Add(Me.pb_fs)
        Me.gb_fs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_fs.Location = New System.Drawing.Point(454, 268)
        Me.gb_fs.Name = "gb_fs"
        Me.gb_fs.Size = New System.Drawing.Size(430, 117)
        Me.gb_fs.TabIndex = 24
        Me.gb_fs.TabStop = False
        Me.gb_fs.Text = "FS:"
        '
        'pb_fs
        '
        Me.pb_fs.Location = New System.Drawing.Point(9, 26)
        Me.pb_fs.Name = "pb_fs"
        Me.pb_fs.Size = New System.Drawing.Size(413, 81)
        Me.pb_fs.TabIndex = 3
        Me.pb_fs.TabStop = False
        '
        'gb_rs
        '
        Me.gb_rs.Controls.Add(Me.pb_rs)
        Me.gb_rs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_rs.Location = New System.Drawing.Point(8, 268)
        Me.gb_rs.Name = "gb_rs"
        Me.gb_rs.Size = New System.Drawing.Size(430, 117)
        Me.gb_rs.TabIndex = 23
        Me.gb_rs.TabStop = False
        Me.gb_rs.Text = "RS:"
        '
        'pb_rs
        '
        Me.pb_rs.Location = New System.Drawing.Point(9, 26)
        Me.pb_rs.Name = "pb_rs"
        Me.pb_rs.Size = New System.Drawing.Size(413, 81)
        Me.pb_rs.TabIndex = 3
        Me.pb_rs.TabStop = False
        '
        'gb_menge
        '
        Me.gb_menge.Controls.Add(Me.pb_menge)
        Me.gb_menge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_menge.Location = New System.Drawing.Point(454, 145)
        Me.gb_menge.Name = "gb_menge"
        Me.gb_menge.Size = New System.Drawing.Size(430, 117)
        Me.gb_menge.TabIndex = 23
        Me.gb_menge.TabStop = False
        Me.gb_menge.Text = "Menge:"
        '
        'pb_menge
        '
        Me.pb_menge.Location = New System.Drawing.Point(9, 26)
        Me.pb_menge.Name = "pb_menge"
        Me.pb_menge.Size = New System.Drawing.Size(413, 81)
        Me.pb_menge.TabIndex = 3
        Me.pb_menge.TabStop = False
        '
        'gb_mbom
        '
        Me.gb_mbom.Controls.Add(Me.pb_mbom)
        Me.gb_mbom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_mbom.Location = New System.Drawing.Point(8, 145)
        Me.gb_mbom.Name = "gb_mbom"
        Me.gb_mbom.Size = New System.Drawing.Size(430, 117)
        Me.gb_mbom.TabIndex = 22
        Me.gb_mbom.TabStop = False
        Me.gb_mbom.Text = "mBOM:"
        '
        'pb_mbom
        '
        Me.pb_mbom.Location = New System.Drawing.Point(9, 26)
        Me.pb_mbom.Name = "pb_mbom"
        Me.pb_mbom.Size = New System.Drawing.Size(413, 81)
        Me.pb_mbom.TabIndex = 3
        Me.pb_mbom.TabStop = False
        '
        'gb_auftrag
        '
        Me.gb_auftrag.Controls.Add(Me.pb_auftrag)
        Me.gb_auftrag.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb_auftrag.Location = New System.Drawing.Point(454, 19)
        Me.gb_auftrag.Name = "gb_auftrag"
        Me.gb_auftrag.Size = New System.Drawing.Size(430, 117)
        Me.gb_auftrag.TabIndex = 22
        Me.gb_auftrag.TabStop = False
        Me.gb_auftrag.Text = "Auftrags-Nr.:"
        '
        'pb_auftrag
        '
        Me.pb_auftrag.Location = New System.Drawing.Point(9, 26)
        Me.pb_auftrag.Name = "pb_auftrag"
        Me.pb_auftrag.Size = New System.Drawing.Size(413, 81)
        Me.pb_auftrag.TabIndex = 3
        Me.pb_auftrag.TabStop = False
        '
        'bg_material
        '
        Me.bg_material.Controls.Add(Me.pb_material)
        Me.bg_material.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bg_material.Location = New System.Drawing.Point(8, 19)
        Me.bg_material.Name = "bg_material"
        Me.bg_material.Size = New System.Drawing.Size(430, 117)
        Me.bg_material.TabIndex = 21
        Me.bg_material.TabStop = False
        Me.bg_material.Text = "Material:"
        '
        'pb_material
        '
        Me.pb_material.Location = New System.Drawing.Point(9, 26)
        Me.pb_material.Name = "pb_material"
        Me.pb_material.Size = New System.Drawing.Size(413, 81)
        Me.pb_material.TabIndex = 3
        Me.pb_material.TabStop = False
        '
        'Frm_Barcodevb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1001, 832)
        Me.Controls.Add(Me.P_Auftragskopf)
        Me.Controls.Add(Me.P_SMT)
        Me.Controls.Add(Me.p_Montage)
        Me.Controls.Add(Me.ProBar_Laden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Barcodevb"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Barcode"
        Me.p_Montage.ResumeLayout(False)
        Me.p_Montage.PerformLayout()
        CType(Me.PB_Barcode_FAUF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Scanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_SMT.ResumeLayout(False)
        Me.P_SMT.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.gb_ofenVG2.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_ofenVG2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_ofenVG1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_ofenVG1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_lp.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_LpNr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_FAUF.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_FAUF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_stuckzahl.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_Stk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GB_Material.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_BC_Mat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProgrammübersichtDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_StammBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.P_Auftragskopf.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.gb_fs.ResumeLayout(False)
        CType(Me.pb_fs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_rs.ResumeLayout(False)
        CType(Me.pb_rs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_menge.ResumeLayout(False)
        CType(Me.pb_menge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_mbom.ResumeLayout(False)
        CType(Me.pb_mbom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gb_auftrag.ResumeLayout(False)
        CType(Me.pb_auftrag, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bg_material.ResumeLayout(False)
        CType(Me.pb_material, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_ASN As Label
    Friend WithEvents lbl_FAUF As Label
    Friend WithEvents ProgrammübersichtDataSet As ProgrammübersichtDataSet
    Friend WithEvents Tbl_StammBindingSource As BindingSource
    Friend WithEvents Tbl_StammTableAdapter As ProgrammübersichtDataSetTableAdapters.PU_tbl_StammTableAdapter
    Friend WithEvents TableAdapterManager As ProgrammübersichtDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ProBar_Laden As ProgressBar
    Friend WithEvents btn_close As Button
    Friend WithEvents PB_Scanner As PictureBox
    Friend WithEvents p_Montage As Panel
    Friend WithEvents P_SMT As Panel
    Friend WithEvents PB_BC_Mat As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_lp_laenge As Label
    Friend WithEvents lbl_lp_breite As Label
    Friend WithEvents lbl_hub_vg1 As Label
    Friend WithEvents lbl_hub_vg2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_Medium_VG1 As Label
    Friend WithEvents lbl_Medium_VG2 As Label
    Friend WithEvents lbl_SchabVG1 As Label
    Friend WithEvents lbl_SchabVG2 As Label
    Friend WithEvents GB_Material As GroupBox
    Friend WithEvents gb_stuckzahl As GroupBox
    Friend WithEvents PB_BC_Stk As PictureBox
    Friend WithEvents gb_FAUF As GroupBox
    Friend WithEvents PB_BC_FAUF As PictureBox
    Friend WithEvents gb_lp As GroupBox
    Friend WithEvents PB_BC_LpNr As PictureBox
    Friend WithEvents gb_ofenVG2 As GroupBox
    Friend WithEvents PB_BC_ofenVG2 As PictureBox
    Friend WithEvents gb_ofenVG1 As GroupBox
    Friend WithEvents PB_BC_ofenVG1 As PictureBox
    Friend WithEvents lbl_fixruestung As Label
    Friend WithEvents lbl_fortschritt As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents lbl_LO As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents txt_info As TextBox
    Friend WithEvents PB_Barcode_FAUF As PictureBox
    Friend WithEvents P_Auftragskopf As Panel
    Friend WithEvents gb_fs As GroupBox
    Friend WithEvents pb_fs As PictureBox
    Friend WithEvents gb_rs As GroupBox
    Friend WithEvents pb_rs As PictureBox
    Friend WithEvents gb_menge As GroupBox
    Friend WithEvents pb_menge As PictureBox
    Friend WithEvents gb_mbom As GroupBox
    Friend WithEvents pb_mbom As PictureBox
    Friend WithEvents gb_auftrag As GroupBox
    Friend WithEvents pb_auftrag As PictureBox
    Friend WithEvents bg_material As GroupBox
    Friend WithEvents pb_material As PictureBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents lbl_pe As Label
    Friend WithEvents lbl_disponent As Label
    Friend WithEvents lbl_FertL As Label
    Friend WithEvents lbl_fertS As Label
    Friend WithEvents lbl_matkurztext As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_langtext As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lbl_lagerort As Label
    Friend WithEvents lbl_BehälterText As Label
    Friend WithEvents lbl_behaelter As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lbl_Farbe As Label
End Class
