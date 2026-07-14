<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_supportAnfrage
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cb_Name = New System.Windows.Forms.ComboBox()
        Me.TPETVorNachnameBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_PET_Mitarbeiter = New ProdKontrolle.DS_PET_Mitarbeiter()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cb_station = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_line = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txt_title = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_notes = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cb_Type = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cb_status = New System.Windows.Forms.ComboBox()
        Me.TblIncidentStateBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_Incident = New ProdKontrolle.DS_Incident()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cb_prio = New System.Windows.Forms.ComboBox()
        Me.TblIncidentPrioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btn_close = New System.Windows.Forms.Button()
        Me.btn_update = New System.Windows.Forms.Button()
        Me.lbl_beschrib = New System.Windows.Forms.Label()
        Me.lbl_titel = New System.Windows.Forms.Label()
        Me.lbl_Name = New System.Windows.Forms.Label()
        Me.lbl_Linie = New System.Windows.Forms.Label()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.cb_cam = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_TakePicture = New System.Windows.Forms.Button()
        Me.btn_Save = New System.Windows.Forms.Button()
        Me.TPETMitarbeiterBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_PET_VorNachnameTableAdapter = New ProdKontrolle.DS_PET_MitarbeiterTableAdapters.T_PET_VorNachnameTableAdapter()
        Me.T_PET_MitarbeiterTableAdapter = New ProdKontrolle.DS_PET_MitarbeiterTableAdapters.T_PET_MitarbeiterTableAdapter()
        Me.btn_screenshot = New System.Windows.Forms.Button()
        Me.Tbl_IncidentPrioTableAdapter = New ProdKontrolle.DS_IncidentTableAdapters.tbl_IncidentPrioTableAdapter()
        Me.Tbl_IncidentStateTableAdapter = New ProdKontrolle.DS_IncidentTableAdapters.tbl_IncidentStateTableAdapter()
        Me.Tbl_IncidentTableAdapter = New ProdKontrolle.DS_IncidentTableAdapters.tbl_IncidentTableAdapter()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TPETVorNachnameBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_PET_Mitarbeiter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TblIncidentStateBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_Incident, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblIncidentPrioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TPETMitarbeiterBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cb_Name)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cb_station)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lbl_line)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 143)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Allgemeine Infos"
        '
        'cb_Name
        '
        Me.cb_Name.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TPETVorNachnameBindingSource, "VorUndNachname", True))
        Me.cb_Name.DataSource = Me.TPETVorNachnameBindingSource
        Me.cb_Name.DisplayMember = "VorUndNachname"
        Me.cb_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb_Name.FormattingEnabled = True
        Me.cb_Name.Location = New System.Drawing.Point(103, 93)
        Me.cb_Name.Name = "cb_Name"
        Me.cb_Name.Size = New System.Drawing.Size(270, 31)
        Me.cb_Name.TabIndex = 5
        Me.cb_Name.ValueMember = "VorUndNachname"
        '
        'TPETVorNachnameBindingSource
        '
        Me.TPETVorNachnameBindingSource.DataMember = "T_PET_VorNachname"
        Me.TPETVorNachnameBindingSource.DataSource = Me.DS_PET_Mitarbeiter
        '
        'DS_PET_Mitarbeiter
        '
        Me.DS_PET_Mitarbeiter.DataSetName = "DS_PET_Mitarbeiter"
        Me.DS_PET_Mitarbeiter.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 23)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Name:"
        '
        'cb_station
        '
        Me.cb_station.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.TPETVorNachnameBindingSource, "VorUndNachname", True))
        Me.cb_station.FormattingEnabled = True
        Me.cb_station.Location = New System.Drawing.Point(103, 56)
        Me.cb_station.Name = "cb_station"
        Me.cb_station.Size = New System.Drawing.Size(270, 31)
        Me.cb_station.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Station:"
        '
        'lbl_line
        '
        Me.lbl_line.AutoSize = True
        Me.lbl_line.Location = New System.Drawing.Point(99, 27)
        Me.lbl_line.Name = "lbl_line"
        Me.lbl_line.Size = New System.Drawing.Size(226, 23)
        Me.lbl_line.TabIndex = 1
        Me.lbl_line.Text = "Gap Baby MK3 U1 / Lin0000"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Linie:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_title)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txt_notes)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cb_Type)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cb_status)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cb_prio)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 161)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(403, 272)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fehler / Problem"
        '
        'txt_title
        '
        Me.txt_title.Enabled = False
        Me.txt_title.Location = New System.Drawing.Point(103, 141)
        Me.txt_title.Name = "txt_title"
        Me.txt_title.Size = New System.Drawing.Size(270, 31)
        Me.txt_title.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(5, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 23)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Titel:"
        '
        'txt_notes
        '
        Me.txt_notes.Location = New System.Drawing.Point(102, 180)
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.Size = New System.Drawing.Size(271, 80)
        Me.txt_notes.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 23)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Beschrieb:"
        '
        'cb_Type
        '
        Me.cb_Type.Enabled = False
        Me.cb_Type.FormattingEnabled = True
        Me.cb_Type.Location = New System.Drawing.Point(103, 104)
        Me.cb_Type.Name = "cb_Type"
        Me.cb_Type.Size = New System.Drawing.Size(270, 31)
        Me.cb_Type.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Location = New System.Drawing.Point(6, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 23)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Type:"
        '
        'cb_status
        '
        Me.cb_status.DataSource = Me.TblIncidentStateBindingSource
        Me.cb_status.DisplayMember = "state"
        Me.cb_status.Enabled = False
        Me.cb_status.FormattingEnabled = True
        Me.cb_status.Location = New System.Drawing.Point(103, 67)
        Me.cb_status.Name = "cb_status"
        Me.cb_status.Size = New System.Drawing.Size(270, 31)
        Me.cb_status.TabIndex = 9
        Me.cb_status.ValueMember = "id"
        '
        'TblIncidentStateBindingSource
        '
        Me.TblIncidentStateBindingSource.DataMember = "tbl_IncidentState"
        Me.TblIncidentStateBindingSource.DataSource = Me.DS_Incident
        '
        'DS_Incident
        '
        Me.DS_Incident.DataSetName = "DS_Incident"
        Me.DS_Incident.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Status:"
        '
        'cb_prio
        '
        Me.cb_prio.DataSource = Me.TblIncidentPrioBindingSource
        Me.cb_prio.DisplayMember = "prio"
        Me.cb_prio.FormattingEnabled = True
        Me.cb_prio.Location = New System.Drawing.Point(103, 30)
        Me.cb_prio.Name = "cb_prio"
        Me.cb_prio.Size = New System.Drawing.Size(270, 31)
        Me.cb_prio.TabIndex = 7
        Me.cb_prio.ValueMember = "id"
        '
        'TblIncidentPrioBindingSource
        '
        Me.TblIncidentPrioBindingSource.DataMember = "tbl_IncidentPrio"
        Me.TblIncidentPrioBindingSource.DataSource = Me.DS_Incident
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Prio:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btn_cancel)
        Me.GroupBox3.Controls.Add(Me.cb_cam)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.PictureBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(433, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(465, 421)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Foto"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btn_close)
        Me.GroupBox4.Controls.Add(Me.btn_update)
        Me.GroupBox4.Controls.Add(Me.lbl_beschrib)
        Me.GroupBox4.Controls.Add(Me.lbl_titel)
        Me.GroupBox4.Controls.Add(Me.lbl_Name)
        Me.GroupBox4.Controls.Add(Me.lbl_Linie)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 14)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(403, 288)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Abschliessen"
        '
        'btn_close
        '
        Me.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_close.Location = New System.Drawing.Point(9, 238)
        Me.btn_close.Name = "btn_close"
        Me.btn_close.Size = New System.Drawing.Size(162, 43)
        Me.btn_close.TabIndex = 8
        Me.btn_close.Text = "Schliessen"
        Me.btn_close.UseVisualStyleBackColor = True
        '
        'btn_update
        '
        Me.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_update.Location = New System.Drawing.Point(220, 238)
        Me.btn_update.Name = "btn_update"
        Me.btn_update.Size = New System.Drawing.Size(152, 43)
        Me.btn_update.TabIndex = 7
        Me.btn_update.Text = "Abschliessen"
        Me.btn_update.UseVisualStyleBackColor = True
        '
        'lbl_beschrib
        '
        Me.lbl_beschrib.Location = New System.Drawing.Point(25, 136)
        Me.lbl_beschrib.Name = "lbl_beschrib"
        Me.lbl_beschrib.Size = New System.Drawing.Size(347, 99)
        Me.lbl_beschrib.TabIndex = 3
        Me.lbl_beschrib.Text = "Label10"
        '
        'lbl_titel
        '
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Location = New System.Drawing.Point(23, 104)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(70, 23)
        Me.lbl_titel.TabIndex = 2
        Me.lbl_titel.Text = "Label10"
        '
        'lbl_Name
        '
        Me.lbl_Name.AutoSize = True
        Me.lbl_Name.Location = New System.Drawing.Point(23, 69)
        Me.lbl_Name.Name = "lbl_Name"
        Me.lbl_Name.Size = New System.Drawing.Size(70, 23)
        Me.lbl_Name.TabIndex = 1
        Me.lbl_Name.Text = "Label10"
        '
        'lbl_Linie
        '
        Me.lbl_Linie.AutoSize = True
        Me.lbl_Linie.Location = New System.Drawing.Point(23, 34)
        Me.lbl_Linie.Name = "lbl_Linie"
        Me.lbl_Linie.Size = New System.Drawing.Size(70, 23)
        Me.lbl_Linie.TabIndex = 0
        Me.lbl_Linie.Text = "Label10"
        '
        'btn_cancel
        '
        Me.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_cancel.Location = New System.Drawing.Point(158, 366)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(143, 43)
        Me.btn_cancel.TabIndex = 7
        Me.btn_cancel.Text = "Verwerfen"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'cb_cam
        '
        Me.cb_cam.FormattingEnabled = True
        Me.cb_cam.Location = New System.Drawing.Point(6, 30)
        Me.cb_cam.Name = "cb_cam"
        Me.cb_cam.Size = New System.Drawing.Size(453, 31)
        Me.cb_cam.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 76)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(156, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "klick auf Bild für Aufnahme"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(453, 341)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btn_TakePicture
        '
        Me.btn_TakePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_TakePicture.Location = New System.Drawing.Point(301, 449)
        Me.btn_TakePicture.Name = "btn_TakePicture"
        Me.btn_TakePicture.Size = New System.Drawing.Size(114, 43)
        Me.btn_TakePicture.TabIndex = 4
        Me.btn_TakePicture.Text = "Foto"
        Me.btn_TakePicture.UseVisualStyleBackColor = True
        '
        'btn_Save
        '
        Me.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Save.Location = New System.Drawing.Point(12, 449)
        Me.btn_Save.Name = "btn_Save"
        Me.btn_Save.Size = New System.Drawing.Size(109, 43)
        Me.btn_Save.TabIndex = 5
        Me.btn_Save.Text = "Speichern"
        Me.btn_Save.UseVisualStyleBackColor = True
        '
        'TPETMitarbeiterBindingSource
        '
        Me.TPETMitarbeiterBindingSource.DataMember = "T_PET_Mitarbeiter"
        Me.TPETMitarbeiterBindingSource.DataSource = Me.DS_PET_Mitarbeiter
        '
        'T_PET_VorNachnameTableAdapter
        '
        Me.T_PET_VorNachnameTableAdapter.ClearBeforeFill = True
        '
        'T_PET_MitarbeiterTableAdapter
        '
        Me.T_PET_MitarbeiterTableAdapter.ClearBeforeFill = True
        '
        'btn_screenshot
        '
        Me.btn_screenshot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_screenshot.Location = New System.Drawing.Point(187, 449)
        Me.btn_screenshot.Name = "btn_screenshot"
        Me.btn_screenshot.Size = New System.Drawing.Size(108, 43)
        Me.btn_screenshot.TabIndex = 6
        Me.btn_screenshot.Text = "Screenshot"
        Me.btn_screenshot.UseVisualStyleBackColor = True
        '
        'Tbl_IncidentPrioTableAdapter
        '
        Me.Tbl_IncidentPrioTableAdapter.ClearBeforeFill = True
        '
        'Tbl_IncidentStateTableAdapter
        '
        Me.Tbl_IncidentStateTableAdapter.ClearBeforeFill = True
        '
        'Tbl_IncidentTableAdapter
        '
        Me.Tbl_IncidentTableAdapter.ClearBeforeFill = True
        '
        'frm_supportAnfrage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(910, 500)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_screenshot)
        Me.Controls.Add(Me.btn_Save)
        Me.Controls.Add(Me.btn_TakePicture)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_supportAnfrage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Support Anfrage"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TPETVorNachnameBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_PET_Mitarbeiter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TblIncidentStateBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_Incident, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblIncidentPrioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TPETMitarbeiterBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cb_Name As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cb_station As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbl_line As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txt_title As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_notes As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cb_Type As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cb_status As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cb_prio As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_TakePicture As Button
    Friend WithEvents btn_Save As Button
    Friend WithEvents btn_cancel As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents DS_PET_Mitarbeiter As DS_PET_Mitarbeiter
    Friend WithEvents TPETVorNachnameBindingSource As BindingSource
    Friend WithEvents T_PET_VorNachnameTableAdapter As DS_PET_MitarbeiterTableAdapters.T_PET_VorNachnameTableAdapter
    Friend WithEvents TPETMitarbeiterBindingSource As BindingSource
    Friend WithEvents T_PET_MitarbeiterTableAdapter As DS_PET_MitarbeiterTableAdapters.T_PET_MitarbeiterTableAdapter
    Friend WithEvents DS_Incident As DS_Incident
    Friend WithEvents TblIncidentPrioBindingSource As BindingSource
    Friend WithEvents Tbl_IncidentPrioTableAdapter As DS_IncidentTableAdapters.tbl_IncidentPrioTableAdapter
    Friend WithEvents TblIncidentStateBindingSource As BindingSource
    Friend WithEvents Tbl_IncidentStateTableAdapter As DS_IncidentTableAdapters.tbl_IncidentStateTableAdapter
    Friend WithEvents btn_screenshot As Button
    Friend WithEvents cb_cam As ComboBox
    Friend WithEvents Tbl_IncidentTableAdapter As DS_IncidentTableAdapters.tbl_IncidentTableAdapter
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lbl_beschrib As Label
    Friend WithEvents lbl_titel As Label
    Friend WithEvents lbl_Name As Label
    Friend WithEvents lbl_Linie As Label
    Friend WithEvents btn_close As Button
    Friend WithEvents btn_update As Button
End Class
