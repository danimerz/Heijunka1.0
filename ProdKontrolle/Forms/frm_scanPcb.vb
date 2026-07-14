Imports ProdKontrolle.DS_ProdKontrolleTableAdapters

Public Class frm_scanPcb

    Private _pcb As String
    Private _fauf As String
    Public Property FAUF() As String
        Get
            Return _fauf
        End Get
        Set(ByVal value As String)
            _fauf = value
        End Set
    End Property
    Public Property PCB() As String
        Get
            Return _pcb
        End Get
        Set(ByVal value As String)
            _pcb = value
        End Set
    End Property
    Public Sub New(LPNummer As String, FaufNummer As String)
        InitializeComponent()
        PCB = LPNummer
        FAUF = FaufNummer
    End Sub

    Private Sub frm_scanPcb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_pcb.Text = PCB
    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        If txt_scan.Text = PCB Then
            'Eintrag in DB
            Dim tbl_Adapter As New tbl_lp_checkTableAdapter
            tbl_Adapter.InsertQuery(FAUF, PCB, True)
            DialogResult = Windows.Forms.DialogResult.Yes
        Else
            DialogResult = Windows.Forms.DialogResult.No
        End If
    End Sub
End Class