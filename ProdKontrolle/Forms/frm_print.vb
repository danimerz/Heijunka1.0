Imports System.ComponentModel

Public Class frm_print
    Private _UutStr1 As String
    Private _UutStr2 As String
    Private _UutStr3 As String
    Private _UutStr4 As String
    Private _UutStr5 As String
    Private _UutStr6 As String
    Private _UutStr7 As String
    Private _UutStr8 As String
    Private _UutStr9 As String
    Private _UutStr10 As String
    Private _UutStr11 As String
    Private _UutStr12 As String
    Private _AnzEtiketten As Integer

    Dim WithEvents BGW_Print As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}

#Region "Propertys"
    Public Property UutStr1 As String
        Set(value As String)
            _UutStr1 = value
        End Set
        Get
            Return _UutStr1
        End Get
    End Property
    Public Property UutStr2 As String
        Set(value As String)
            _UutStr2 = value
        End Set
        Get
            Return _UutStr2
        End Get
    End Property
    Public Property UutStr3 As String
        Set(value As String)
            _UutStr3 = value
        End Set
        Get
            Return _UutStr3
        End Get
    End Property
    Public Property UutStr4 As String
        Set(value As String)
            _UutStr4 = value
        End Set
        Get
            Return _UutStr4
        End Get
    End Property
    Public Property UutStr5 As String
        Set(value As String)
            _UutStr5 = value
        End Set
        Get
            Return _UutStr5
        End Get
    End Property
    Public Property UutStr6 As String
        Set(value As String)
            _UutStr6 = value
        End Set
        Get
            Return _UutStr6
        End Get
    End Property
    Public Property AnzEtiketten As Integer
        Set(value As Integer)
            _AnzEtiketten = value
        End Set
        Get
            Return _AnzEtiketten
        End Get
    End Property
    Public Property UutStr7() As String
        Get
            Return _UutStr7
        End Get
        Set(ByVal value As String)
            _UutStr7 = value
        End Set
    End Property
    Public Property UutStr8() As String
        Get
            Return _UutStr8
        End Get
        Set(ByVal value As String)
            _UutStr8 = value
        End Set
    End Property
    Public Property UutStr9() As String
        Get
            Return _UutStr9
        End Get
        Set(ByVal value As String)
            _UutStr9 = value
        End Set
    End Property
    Public Property UutStr10() As String
        Get
            Return _UutStr10
        End Get
        Set(ByVal value As String)
            _UutStr10 = value
        End Set
    End Property
    Public Property UutStr11() As String
        Get
            Return _UutStr11
        End Get
        Set(ByVal value As String)
            _UutStr11 = value
        End Set
    End Property
    Public Property UutStr12() As String
        Get
            Return _UutStr12
        End Get
        Set(ByVal value As String)
            _UutStr12 = value
        End Set
    End Property
#End Region

    Public Sub New(Text1 As String, Text2 As String, Text3 As String, Text4 As String, Text5 As String, Text6 As String, BC1 As String, BC2 As String, BC3 As String, BC4 As String, BC5 As String, BC6 As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        UutStr1 = Text1
        UutStr2 = Text2
        UutStr3 = Text3
        UutStr4 = Text4
        UutStr5 = Text5
        UutStr6 = Text6
        UutStr7 = BC1
        UutStr8 = BC2
        UutStr9 = BC3
        UutStr10 = BC4
        UutStr11 = BC5
        UutStr12 = BC6

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
    End Sub

    Private Sub btn_Minus_Click(sender As Object, e As EventArgs) Handles btn_Minus.Click
        If CInt(lbl_Anzahl.Text) > 1 Then
            lbl_Anzahl.Text = CInt(lbl_Anzahl.Text) - 1
        End If
    End Sub
    Private Sub btn_plus_Click(sender As Object, e As EventArgs) Handles btn_plus.Click
        If CInt(lbl_Anzahl.Text) < 99 Then
            lbl_Anzahl.Text = CInt(lbl_Anzahl.Text) + 1
        End If
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        pb_laden.Maximum = 3
        If Not BGW_Print.IsBusy Then
            pb_laden.Value = 1
            BGW_Print.RunWorkerAsync()
        End If
    End Sub

    Private Sub BGW_Print_DoWork(sender As Object, e As DoWorkEventArgs) Handles BGW_Print.DoWork
        BGW_Print.ReportProgress(2, "Daten Sammeln")

        Dim Anlage As String = My.Settings.Printer_Anlage
        Dim Station As String = My.Settings.Printer_Station
        Dim LabelArt As String = My.Settings.Printer_LabelArt
        Dim EtikettenArt As String = My.Settings.Printer_Referenz
        Dim Referenz As String = ""

        Select Case EtikettenArt
            Case "P-Touch Etikette 36mm"
                Referenz = "Halbfabrikat_PT_BC"
            Case "QL-Etikette 56mm"
                Referenz = "Halbfabrikat_QL_BC"
        End Select

        AnzEtiketten = CInt(lbl_Anzahl.Text)

        BGW_Print.ReportProgress(3, AnzEtiketten & " Etiketten werden gedruckt")
        PrinterDB.clsPrintLabel.DBConnStr = My.Settings.PrinterDBConnectionString
        PrinterDB.clsPrintLabel.PrintLabel(Referenz, Anlage, LabelArt, Station, "", "", UutStr1, UutStr2, UutStr3, UutStr4, UutStr5, UutStr6, UutStr7, UutStr8, UutStr9, UutStr10, UutStr11, UutStr12, AnzEtiketten)
    End Sub

    Private Sub BGW_Print_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BGW_Print.ProgressChanged
        pb_laden.Value = e.ProgressPercentage
        lbl_info.Text = e.UserState
    End Sub

    Private Sub BGW_Print_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BGW_Print.RunWorkerCompleted
        lbl_info.Text = "Dialog wird geschlossen"
        T_beenden.Start()
    End Sub

    Private Sub T_beenden_Tick(sender As Object, e As EventArgs) Handles T_beenden.Tick
        T_beenden.Stop()
        Me.Close()
    End Sub

    Private Sub frm_print_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_info.Text = "Bereit"
    End Sub
End Class