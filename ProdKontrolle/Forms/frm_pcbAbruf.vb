Public Class frm_pcbAbruf
    Private _AuftragsNr As String
    Private _pcb As String
    Public Property AuftragsNr() As String
        Get
            Return _AuftragsNr
        End Get
        Set(ByVal value As String)
            _AuftragsNr = value
        End Set
    End Property
    Public Property pcb() As String
        Get
            Return _pcb
        End Get
        Set(ByVal value As String)
            _pcb = value
        End Set
    End Property
    Public Sub New(AuftragNr As String, LPNummer As String)
        InitializeComponent()

        AuftragsNr = AuftragNr
        pcb = LPNummer


    End Sub

    Private Sub frm_pcbAbruf_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lbl_Auftrag.Text = "Auftrags Nr.: " & AuftragsNr
        lbl_Pcb.Text = "LP Nr.: " & pcb
        pb_Fauf.Image = Code128Rendering.MakeBarcodeImage(AuftragsNr, 2, True)

    End Sub

    Private Sub btn_pcb_ok_Click(sender As Object, e As EventArgs) Handles btn_pcb_ok.Click
        DialogResult = Windows.Forms.DialogResult.Yes
        Close()
    End Sub

    Private Sub btn_pcb_nok_Click(sender As Object, e As EventArgs) Handles btn_pcb_nok.Click
        DialogResult = Windows.Forms.DialogResult.No
        Close()
    End Sub
End Class