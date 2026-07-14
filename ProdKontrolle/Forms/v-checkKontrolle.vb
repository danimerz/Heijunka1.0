
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.ComponentModel
Imports ZXing
Imports ZXing.Common
Public Class v_checkKontrolle

    Dim FilterInfoCollection As FilterInfoCollection
    Dim VideoCaptureDevice As VideoCaptureDevice
    Dim BMP As Bitmap
    Public WithEvents Worker As New BackgroundWorker
    Private globaleFunktionen As New GlobaleFunktionen
    Dim WithEvents BGW_Load_vcheckData As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}


    Private _GoodDecode As Boolean
    Private _Material As String
    Private _FAUF As String
    Private _Linie As String
    Private _Team As String
    Private _Arbeitsplatz As String
    Private _OK As Boolean

    Public Property QRDecode As Boolean
        Set(value As Boolean)
            _GoodDecode = value
        End Set
        Get
            Return _GoodDecode
        End Get
    End Property
    Public Property Material As String
        Set(value As String)
            _Material = value
        End Set
        Get
            Return _Material
        End Get
    End Property
    Public Property FAUF As String
        Set(value As String)
            _FAUF = value
        End Set
        Get
            Return _FAUF
        End Get
    End Property
    Public Property Linie As String
        Set(value As String)
            _Linie = value
        End Set
        Get
            Return _Linie
        End Get
    End Property
    Public Property Team As String
        Set(value As String)
            _Team = value
        End Set
        Get
            Return _Team
        End Get
    End Property
    Public Property Arbeitsplatz As String
        Set(value As String)
            _Arbeitsplatz = value
        End Set
        Get
            Return _Arbeitsplatz
        End Get
    End Property
    Public Property Ok As Boolean
        Set(value As Boolean)
            _OK = value
        End Set
        Get
            Return _OK
        End Get
    End Property
    Public Sub New(mat, auftrag, z, Line, Group, AP)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Material = mat
        FAUF = auftrag
        Linie = Line
        Team = Group
        Arbeitsplatz = AP
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "DS_ProdKontrolle.tbl_vcheckKontrolle". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_vcheckKontrolle)

        'bgw starten
        If Not BGW_Load_vcheckData.IsBusy Then
            lbl_info.Text = " v-Check Daten werden geladen, bitte warten.."
            BGW_Load_vcheckData.RunWorkerAsync()
        End If

        If My.Settings.vcheck_scanner = False Then
            txt_scannerinput.Visible = False
            lbl_beschrib.Visible = False
            btn_ok.Visible = False
            PictureBox1.Visible = True

            AddHandler Worker.DoWork, AddressOf Worker_DoWork
            Dim Cam As Integer = 0 'erste cam nehmen

            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

            FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)

            'Ohne angeschlossene/erkannte Kamera ist FilterInfoCollection leer - FilterInfoCollection(Cam)
            'warf dann eine ArgumentOutOfRangeException und riss das ganze Formular schon beim Laden ab.
            'VideoCaptureDevice bleibt in diesem Fall Nothing (wie sonst nur im Scanner-Modus) - VideoStart(),
            'Worker_RunWorkerCompleted und v_checkKontrolle_Closing prüfen das entsprechend ab.
            If FilterInfoCollection.Count = 0 Then
                Dim log As New logging
                log.WriteLog(Date.Now, "", "", "", "v_checkKontrolle: Keine Kamera gefunden - v-Check Kontrolle per Kamera nicht möglich.")
                lbl_info.Text = "Keine Kamera gefunden - v-Check Kontrolle per Kamera nicht möglich."
                MsgBox("Es wurde keine Kamera gefunden." & vbCrLf & "v-Check Kontrolle per Kamera ist nicht möglich.", vbCritical, "Keine Kamera gefunden")
            Else
                VideoCaptureDevice = New VideoCaptureDevice(FilterInfoCollection(Cam).MonikerString)
                Try
                    VideoCaptureDevice.VideoResolution = VideoCaptureDevice.VideoCapabilities(3)
                Catch ex As Exception

                End Try

                AddHandler VideoCaptureDevice.NewFrame, New NewFrameEventHandler(AddressOf videoCapture)
            End If

        Else
            txt_scannerinput.Visible = True
            lbl_beschrib.Visible = True
            btn_ok.Visible = True
            PictureBox1.Visible = False
        End If
    End Sub

    Private Sub VideoStart()
        'VideoCaptureDevice wird nur im Kamera-Modus initialisiert (My.Settings.vcheck_scanner =
        'False, siehe Form1_Load). Im Scanner-Modus blieb VideoCaptureDevice = Nothing, wodurch
        '.Start() hier eine NullReferenceException warf, sobald die v-Check-Daten als "OK" geladen
        'wurden - unabhängig vom konfigurierten Modus. Bleibt auch Nothing, wenn im Kamera-Modus
        'keine Kamera gefunden wurde (siehe Form1_Load).
        If Ok = True AndAlso My.Settings.vcheck_scanner = False AndAlso VideoCaptureDevice IsNot Nothing Then
            VideoCaptureDevice.Start()
            Timer1.Start()
        End If
    End Sub
    Private Sub Worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles Worker.DoWork
        e.Result = ExtractQRCodeMessageFromImage(BMP)
    End Sub
    Private Sub videoCapture(sender As Object, eventArgs As NewFrameEventArgs)
        Try
            BMP = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If BMP IsNot Nothing AndAlso Not Worker.IsBusy AndAlso QRDecode = False Then
            Worker.RunWorkerAsync()
        End If
    End Sub
    Private Function ExtractQRCodeMessageFromImage(ByVal bitmap As Bitmap) As String
        Try
            Dim reader As BarcodeReader = New BarcodeReader(Nothing, Function(newbitmap) New BitmapLuminanceSource(bitmap), Function(luminance) New GlobalHistogramBinarizer(luminance))
            reader.AutoRotate = False
            reader.TryInverted = True
            reader.Options.PossibleFormats = New List(Of BarcodeFormat)
            reader.Options.PossibleFormats.Add(BarcodeFormat.QR_CODE)
            reader.Options = New DecodingOptions With {
                .TryHarder = False
            }

            Dim result = reader.Decode(bitmap)
            If result IsNot Nothing Then
                Return CodeCheck(result.Text)
            Else
                QRDecode = False
                Return "Bereit..."
            End If

        Catch ex As Exception
            QRDecode = False
            Return ex.ToString
        End Try
    End Function
    Private Sub Worker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        lbl_info.Text = "Bereit"
        lbl_info.Text = e.Result
        If QRDecode = True Then
            If VideoCaptureDevice IsNot Nothing Then
                VideoCaptureDevice.Stop()
            End If
            'Write to DB
            Tbl_vcheckKontrolleTableAdapter.InsertQuery(Material, FAUF, Now, e.Result, Team, Linie)
            'in Protokoll schreiben
            'globaleFunktionen.SetProtocol(FAUF, Arbeitsplatz, "vCheck", "vCheck Kontrolle von " & e.Result & " erfasst.")
            Me.Close()
        End If
    End Sub
    Private Sub v_checkKontrolle_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If QRDecode = True Then
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            If My.Settings.vcheck_scanner = False AndAlso VideoCaptureDevice IsNot Nothing Then
                VideoCaptureDevice.Stop()
            End If
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
    Private Function CodeCheck(Result As String) As String
        'überprüfen ob qr-code richtiges format hat
        If InStr(Result, ";") Then
            Dim a As String() = Split(Result, ";")
            'Prüfen das Personalnummer nur aus Zahlen besteht
            If IsNumeric(a(1)) = True Then
                QRDecode = True
                Return Result
            Else
                QRDecode = False
                'lbl_info.Text = "Die Personalnummer muss eine Zahl sein" & vbCrLf & "Inhalt: " & a(1)
                Return "Die Personalnummer muss eine Zahl sein" & vbCrLf & "Inhalt: " & a(1)
            End If
        Else
            QRDecode = False
            'lbl_info.Text = "Es wurde ein falscher Code Eingelesen" & vbCrLf & "Inhalt: " & result.Text
            Return "Es wurde ein falscher Code Eingelesen" & vbCrLf & "Inhalt: " & Result
        End If
    End Function
    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click


        lbl_info.Text = CodeCheck(txt_scannerinput.Text)
        If QRDecode = True Then
            'Write to DB
            Tbl_vcheckKontrolleTableAdapter.InsertQuery(Material, FAUF, Now, txt_scannerinput.Text, Team, Linie)
            Me.Close()
        End If
    End Sub
    Private Sub BGW_Load_vcheckData_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_Load_vcheckData.DoWork
        'vcheck Daten laden - vorher wurde dieselbe, schon nach FAUF gefilterte Abfrage hier
        'versehentlich zweimal hintereinander ausgeführt (das erste Ergebnis wurde nie verwendet)
        Dim qry = From r In HJ_GetOperationInfoTableAdapter.GetData(FAUF)
                  Where r.ProcessNumber = Arbeitsplatz

        e.Result = qry
    End Sub
    Private Sub BGW_Load_vcheckData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_Load_vcheckData.RunWorkerCompleted
        For Each row In e.Result
            lbl_offen.Text = (row.Item("SN") - row.item("OperationPass")).ToString
            lbl_OperationPass.Text = row.Item("OperationPass").ToString
            lbl_Soll.Text = row.Item("ExpectedSN").ToString
            lbl_oFPY.Text = Math.Round(row.Item("OperationFirstPASS") / row.Item("OperationPass") * 100, 2) & "%"
            lbl_trash.Text = row.item("TRASH").ToString

            If (row.Item("OperationPass") + row.Item("TRASH")) >= row.Item("ExpectedSN") Then
                lbl_Result.Text = "OK"
                lbl_Result.BackColor = Color.Green
                Ok = True
                VideoStart()
                lbl_info.Text = "v-Check Daten geladen, Kamera wird gestartet..."
            Else
                lbl_Result.Text = "nicht IO"
                lbl_Result.BackColor = Color.Red
                Ok = False
                lbl_info.Text = "v-Check Daten stimmen nicht."
                PictureBox1.Image = My.Resources.weis
            End If
        Next

        PictureBox2.Visible = False

    End Sub
End Class