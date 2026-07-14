Imports AForge
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports Newtonsoft.Json
Imports ProdKontrolle.DS_IncidentTableAdapters
Imports ProdKontrolle.Form1
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Runtime.CompilerServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports ZXing.Aztec.Internal

Public Class frm_supportAnfrage
    Public BMP As Bitmap
    Public FilterInfoCollection As FilterInfoCollection
    Public VideoCaptureDevice As VideoCaptureDevice
    Public pic_base64 As String
    Private globaleFunktionen As New GlobaleFunktionen
    Event ColoringHeijunkaEvent(sender As Object, e As Form1.ColoringHeijunkaIncidentEventArgs)

    'MQTT Klasse deklarieren
    Private WithEvents mqtt As New mqtt
    Public Property LineNr As String = String.Empty
    Public Property LineName As String = String.Empty
    Public Property WorkOrder As String = String.Empty
    Public Property RowIndex As Integer = 0


    Public Sub New(Linie As String, LinienName As String, Auftrag As String, Row As Integer)
        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        LineNr = Linie
        LineName = LinienName
        WorkOrder = Auftrag
        RowIndex = Row

    End Sub

    Private Async Sub frm_supportAnfrage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Tbl_IncidentStateTableAdapter.Fill(Me.DS_Incident.tbl_IncidentState)
        Me.Tbl_IncidentPrioTableAdapter.Fill(Me.DS_Incident.tbl_IncidentPrio)
        Me.T_PET_VorNachnameTableAdapter.Fill(Me.DS_PET_Mitarbeiter.T_PET_VorNachname)

        Me.Tbl_IncidentTableAdapter.Fill(Me.DS_Incident.tbl_Incident)

        Dim Data As DS_Incident.tbl_IncidentDataTable = Tbl_IncidentTableAdapter.GetDataByOrder(WorkOrder)
        If Data.Count > 0 Then
            'Auswahl, soll ein neuer Incident angelegt werden, oder einer Abgschlossen

            For Each row As DS_Incident.tbl_IncidentRow In Data
                If row.incident_state < 4 Then
                    lbl_Linie.Text = "Linie: " & LineName
                    lbl_Name.Text = "Mitarbeiter: " & row.incident_creator
                    lbl_titel.Text = "Titel: " & row.incident_title
                    lbl_beschrib.Text = "Beschreibung: " & row.incident_description

                End If
            Next
            'GroupBox1.Visible = False
            'GroupBox2.Visible = False
            'GroupBox4.Visible = True
            Me.Height = 344
            Me.Width = 443


        Else
            GroupBox1.Visible = True
            GroupBox2.Visible = True
            GroupBox4.Visible = False
        End If

        Me.Width = 443
        btn_cancel.Visible = False

        lbl_line.Text = LineName ' & " / " & LineNr

        cb_station.Items.Add("bitte Warten...")
        cb_station.SelectedIndex = 0
        'Stationsabfrage via API
        'Schalufe für Linien die mehere Linien im IH-Tool haben
        Dim splitStation() As String = Split(LineNr, ";")
        Dim Stationen As List(Of Root) = New List(Of Root)
        Dim StationsabfrageFehlgeschlagen As Boolean = False
        For Each item As String In splitStation
            'GetStationsIhTool gibt bei einem API-/Netzwerkfehler Nothing zurück - ungeprüft in die
            'Liste übernommen hätte das weiter unten (Stat.v_Hierarchie) eine NullReferenceException
            'innerhalb dieses Async Sub ausgelöst, die die App komplett ohne Meldung abstürzen lässt
            '(dieselbe Fehlerklasse wie der behobene BGW_Hejiunka_DoWork-Absturz).
            Dim station As Root = Await GetStationsIhTool(item)
            If station Is Nothing Then
                StationsabfrageFehlgeschlagen = True
            Else
                Stationen.Add(station)
            End If
        Next

        If StationsabfrageFehlgeschlagen Then
            Dim log As New logging
            log.WriteLog(Date.Now, "", "", "", "Support-Anfrage: IH-Tool Stationsabfrage für mind. eine Linie fehlgeschlagen, Stationsliste evtl. unvollständig")
        End If

        'Füllen der ComboBox
        cb_status.SelectedIndex = 1
        cb_prio.SelectedIndex = 1

        cb_station.Items.Clear()
        For Each Stat As Root In Stationen
            For Each i As VHierarchie In Stat.v_Hierarchie
                cb_station.Items.Add(i.STA & " " & i.StaName)
            Next
        Next
        cb_station.SelectedIndex = 0

        Dim FilterInfoCollection As New FilterInfoCollection(FilterCategory.VideoInputDevice)

        For Each camera As FilterInfo In FilterInfoCollection
            cb_cam.Items.Add(camera.Name)
        Next

        If FilterInfoCollection.Count = 0 Then
            btn_TakePicture.Enabled = False
        Else
            btn_TakePicture.Enabled = True
            cb_cam.SelectedIndex = 0
        End If


        FilterInfoCollection = Nothing

    End Sub

    Private Sub cb_cam_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_cam.SelectedIndexChanged
        If Not IsNothing(VideoCaptureDevice) Then
            Try
                VideoCaptureDevice.Stop()
            Catch ex As Exception
            End Try
        End If

        Dim Cam As Integer = cb_cam.SelectedIndex

        Try
            FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            VideoCaptureDevice = New VideoCaptureDevice(FilterInfoCollection(Cam).MonikerString)

            If VideoCaptureDevice.VideoCapabilities IsNot Nothing AndAlso VideoCaptureDevice.VideoCapabilities.Length > 0 Then
                'Index 3 war fest angenommen (meist eine brauchbare mittlere Auflösung), fällt aber
                'auf die höchste tatsächlich von der Kamera gemeldete Auflösung zurück, falls sie
                'weniger Modi unterstützt - sonst warf das bei manchen Kameras/Treibern eine
                'IndexOutOfRangeException und der komplette Kamera-Start schlug fehl.
                Dim aufloesungsIndex As Integer = Math.Min(3, VideoCaptureDevice.VideoCapabilities.Length - 1)
                VideoCaptureDevice.VideoResolution = VideoCaptureDevice.VideoCapabilities(aufloesungsIndex)
            End If

            AddHandler VideoCaptureDevice.NewFrame, New NewFrameEventHandler(AddressOf videoCapture)
            VideoCaptureDevice.Start()
        Catch ex As Exception
            Dim log As New logging
            log.WriteLog(Date.Now, "", "", "", $"Kamera-Fehler beim Start ({cb_cam.Text}): {ex.Message}")
            MsgBox("Die Kamera konnte nicht gestartet werden." & vbCrLf & "Ein Foto kann evtl. nicht aufgenommen werden.", vbExclamation, "Kamera-Fehler")
            VideoCaptureDevice = Nothing
            btn_TakePicture.Enabled = False
        End Try
    End Sub

    Private Sub btn_TakePicture_Click(sender As Object, e As EventArgs) Handles btn_TakePicture.Click
        If Me.Width > 500 Then
            Me.Width = 443
            If Not IsNothing(VideoCaptureDevice) Then
                VideoCaptureDevice.Stop()
            End If
            pic_base64 = Nothing
        Else
            Me.Width = 926
            If Not IsNothing(VideoCaptureDevice) Then
                VideoCaptureDevice.Start()
            End If
            btn_cancel.Visible = False
        End If
    End Sub

    Private Sub videoCapture(sender As Object, eventArgs As NewFrameEventArgs)
        Try
            BMP = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'Foto aufnehmen und als Base64 String speichern
        Dim varBmp As Bitmap = New Bitmap(PictureBox1.Image)
        Dim newPic As Bitmap = New Bitmap(varBmp)
        Dim ms As New MemoryStream

        PictureBox1.Image = newPic
        varBmp.Save(ms, ImageFormat.Png)
        Dim byteArray As Byte() = ms.ToArray
        pic_base64 = Convert.ToBase64String(byteArray)
        'Console.WriteLine(pic_base64)
        varBmp.Dispose()
        varBmp = Nothing
        If Not IsNothing(VideoCaptureDevice) Then
            VideoCaptureDevice.Stop()
        End If
        btn_cancel.Visible = True
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        If Not IsNothing(VideoCaptureDevice) Then
            VideoCaptureDevice.Start()
        End If
        btn_cancel.Visible = False
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Dim prio = DirectCast(TblIncidentPrioBindingSource.Current, DataRowView).Row
        Dim status = DirectCast(TblIncidentStateBindingSource.Current, DataRowView).Row
        Dim sta() As String = Split(cb_station.SelectedItem, " ")
        Dim incident As New Incident
        Dim args = New ColoringHeijunkaIncidentEventArgs
        args.RowIndex = RowIndex
        args.ColorSet = 0

        incident.timestamp = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz", DateTimeFormatInfo.InvariantInfo)
        incident.tags.lin = LineNr.ToUpper()
        incident.tags.sta = sta(0).ToUpper()
        incident.tags.incident_id = Guid.NewGuid.ToString
        incident.fields.incident_creator = cb_Name.Text
        incident.fields.incident_title = txt_title.Text
        incident.fields.incident_description = txt_notes.Text
        incident.fields.incident_priority = prio.Item("id")
        incident.fields.incident_state = status.Item("id")
        incident.fields.incident_type = 0
        incident.fields.workorder = WorkOrder
        incident.fields.material = globaleFunktionen.GetMaterialNr(WorkOrder)
        incident.fields.rev = globaleFunktionen.GetTC3Dok(WorkOrder).DokVersion 'Rev.DokVersion
        incident.fields.fs = globaleFunktionen.GetTC2Dok(WorkOrder).DokVersion 'Fs.DokVersion
        Dim rs As String = globaleFunktionen.GetRS(WorkOrder)
        If Not String.IsNullOrEmpty(rs) Then
            incident.fields.rs = rs
        Else
            incident.fields.rs = Nothing
        End If

        If Not IsNothing(pic_base64) Then
            incident.attachments.filename = "Picture"
            incident.attachments.datatype = "png"
            incident.attachments.payload = pic_base64
        End If

        Dim jsonString As String = JsonConvert.SerializeObject(incident)
        Console.WriteLine(jsonString)

        If txt_title.Text = "" Or txt_notes.Text = "" Or cb_station.SelectedItem = Nothing Then
            MsgBox("Bitte alle Felder ausfüllen!", MsgBoxStyle.Critical, "Eingaben prüfen")
        Else
            mqtt_init()
            mqtt_Send_Incident(incident.tags.lin, incident.tags.sta, jsonString)

            'Daten in Tabelle schreiben
            Tbl_IncidentTableAdapter.InsertQuery1(incident.tags.incident_id,
                                                  incident.tags.sta,
                                                  incident.tags.lin,
                                                  incident.fields.incident_priority,
                                                  incident.fields.incident_state,
                                                  incident.fields.incident_type,
                                                  incident.fields.incident_creator,
                                                  incident.fields.incident_title,
                                                  incident.fields.incident_description,
                                                  incident.fields.workorder,
                                                  incident.fields.material,
                                                  incident.fields.rev,
                                                  incident.fields.rs,
                                                  incident.fields.fs)
            incident = Nothing
            VideoCaptureDevice = Nothing
            FilterInfoCollection = Nothing
            RaiseEvent ColoringHeijunkaEvent(Me, args)
            Me.Close()
        End If

    End Sub

    Private Sub mqtt_init()
        Try
            Dim Computername As String = System.Environment.MachineName
            mqtt.mmqt_start(Computername, "iotservervm1.sbt.siemens.com", "MFZUG", "6300-Zug")
        Catch ex As Exception
        End Try
    End Sub
    Private Async Sub mqtt_Send_Incident(Line As String, station As String, payload As String)
        If mqtt.ConnectionState = True Then
            Dim Topic As String = "eq_incident/JSON/v1/" & Line & "/" & station
            Await mqtt.Publish(Topic, payload)
        End If
    End Sub

    Public Async Function GetStationsIhTool(Lin As String) As Task(Of Root)
        Dim handler As New HttpClientHandler()
        handler.ServerCertificateCustomValidationCallback = AddressOf CustomServerCertificateValidation ' Function(sender, certificate, chain, sslPolicyErrors) True

        Using httpClient As New HttpClient(handler)
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {My.Settings.ihToolApiKey}")
            Try
                Dim response As HttpResponseMessage = Await httpClient.GetAsync("https://iotservervm1.sbt.siemens.com:8085/api/rest/ihtool/stations?linid=" & Lin)

                ' Überprüfen, ob der Aufruf erfolgreich war
                If response.IsSuccessStatusCode Then
                    Dim raw As String = Await response.Content.ReadAsStringAsync()
                    Dim resp = JsonConvert.DeserializeObject(Of Root)(raw)
                    Return resp ' Die API-Antwort als Zeichenfolge zurückgeben
                Else
                    ' Bei einem Fehler den Statuscode und die Fehlermeldung ausgeben
                    Debug.WriteLine($"Fehler: {response.StatusCode} - {response.ReasonPhrase}")
                    Dim log As New logging
                    log.WriteLog(Date.Now, "", "", "", $"Fehler: {response.StatusCode} - {response.ReasonPhrase}")
                    Return Nothing
                End If

            Catch ex As HttpRequestException
                ' Fehler bei der HTTP-Anforderung
                Debug.WriteLine($"HTTP-Fehler: {ex.Message}")
                Dim log As New logging
                log.WriteLog(Date.Now, "", "", "", $"HTTP-Fehler: {ex.Message} - {ex.InnerException}")
                Return Nothing
            End Try

        End Using
    End Function
    Private Shared Function CustomServerCertificateValidation(sender As HttpRequestMessage, cert As X509Certificate2, chain As X509Chain, sslPolicyErrors As SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Sub btn_screenshot_Click(sender As Object, e As EventArgs) Handles btn_screenshot.Click
        'minimize Heijunka
        'Me.Owner.Visible = False
        Me.Visible = False

        Threading.Thread.Sleep(500)

        'take Snapshot
        Dim varBmp As Bitmap = New Bitmap(TakeScreenShot())
        Dim ms As New MemoryStream
        varBmp.Save(ms, ImageFormat.Png)
        Dim byteArray As Byte() = ms.ToArray
        pic_base64 = Convert.ToBase64String(byteArray)
        Console.WriteLine(pic_base64)
        varBmp.Dispose()
        varBmp = Nothing

        'minimize Heijunka
        'Me.Owner.Visible = True
        Me.Visible = True

    End Sub

    Private Function TakeScreenShot() As Bitmap
        Dim screenSize As Size = New Size(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim screenGrab As New Bitmap(My.Computer.Screen.Bounds.Width, My.Computer.Screen.Bounds.Height)
        Dim g As Graphics = Graphics.FromImage(screenGrab)
        g.CopyFromScreen(New Drawing.Point(0, 0), New Drawing.Point(0, 0), screenSize)
        Return screenGrab
    End Function

    Private Sub frm_supportAnfrage_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Not IsNothing(VideoCaptureDevice) Then
            VideoCaptureDevice.Stop()
        End If
        FilterInfoCollection = Nothing
    End Sub

    Private Sub cb_station_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_station.SelectedIndexChanged
        txt_title.Text = cb_station.Text
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim args = New ColoringHeijunkaIncidentEventArgs
        args.RowIndex = RowIndex
        args.ColorSet = 1
        Try
            '4 = Done
            Tbl_IncidentTableAdapter.UpdateQuery(4, WorkOrder)
            RaiseEvent ColoringHeijunkaEvent(Me, args)

            Me.Close()
        Catch ex As Exception
            MsgBox("Daten konnten nicht aktualisiert werden!")
        End Try
    End Sub

End Class

Public Class Root
    Public Property v_Hierarchie As New List(Of VHierarchie)
End Class

Public Class VHierarchie
    Public Property id As Integer = 0
    Public Property SEG As String = String.Empty
    Public Property SegName As String = String.Empty
    Public Property LIN As String = String.Empty
    Public Property LinName As String = String.Empty
    Public Property STA As String = String.Empty
    Public Property StaName As String = String.Empty
End Class