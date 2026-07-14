Imports ProdKontrolle.Form1
Imports FaufAplaXml
Public Class frm_FaufSearch
    Private globalFunction As New GlobaleFunktionen
    Private SAP_XML As New SAP_XML

    Private _Auftragsnummer As String
    Public Handler As AuftragsHandler
    Public Property Auftragsnummer
        Set(value)
            _Auftragsnummer = value
        End Set
        Get
            Return _Auftragsnummer
        End Get
    End Property
    Public Sub New(Optional ByVal FAUF As String = "Default")

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        Auftragsnummer = FAUF


    End Sub

    Private Sub frm_FaufSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Auftragsnummer = "Default" Then
            SearchFauf()
        End If
    End Sub
    Private Sub SearchFauf()
        Dim DS_FAUF As DataSet = GetFaufDataset(Auftragsnummer)

        txt_Auftragsnummer.Text = Auftragsnummer
        dgv_Auftrag.DataSource = GetAllVrg(DS_FAUF)
        txt_Langtext.Text = GetLangtext(DS_FAUF)
        lbl_MatNr.Text = GetMaterialNummer(DS_FAUF)
        lbl_losgrösse.Text = GetAuftragsStk(DS_FAUF).ToString & "stk."
        lbl_kurztext.Text = GetMatKurztext(DS_FAUF)

        ' AuftragsHandler Initalisieren
        'Handler = New AuftragsHandler(txt_Auftragsnummer.Text)

    End Sub
    Private Function GetFaufDataset(FAUF As String) As DataSet
        Return SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
    End Function
    Private Function GetAllVrg(FAUFDS As DataSet) As List(Of Vorgangsuebersicht)
        Dim DT As DataTable = FAUFDS.Tables("E1AFVOL")
        Dim ListResult As New List(Of Vorgangsuebersicht)

        If Not IsNothing(DT) Then
            For Each item In DT.AsEnumerable
                Dim vorgangsuebersicht As New Vorgangsuebersicht
                vorgangsuebersicht.VorgansNr = item.Field(Of String)("VORNR")
                vorgangsuebersicht.Startdatum = DateTime.ParseExact(item.Field(Of String)("SSAVD"), "yyyyMMdd", Nothing)
                vorgangsuebersicht.Enddatum = DateTime.ParseExact(item.Field(Of String)("SSEVD"), "yyyyMMdd", Nothing)
                vorgangsuebersicht.Arbeitsplatz = item.Field(Of String)("ARBPL")
                vorgangsuebersicht.Steuerschlüssel = item.Field(Of String)("STEUS")
                vorgangsuebersicht.KurztextVorgang = item.Field(Of String)("LTXA1")
                vorgangsuebersicht.VorgangsMenge = CInt(item.Field(Of String)("MGVRG"))
                vorgangsuebersicht.RückgemeldeteMenge = CInt(item.Field(Of String)("LMNGA"))
                ListResult.Add(vorgangsuebersicht)
            Next
        End If

        Return ListResult
    End Function
    Private Function GetLangtext(FAUFDS As DataSet) As String
        Dim Langtext As String = String.Empty

        'LangtextKopf auslesen
        If FAUFDS.Tables.Contains("ZE1_DMSOP_KTXT") Then
            Dim T_DOK As DataTable = FAUFDS.Tables("ZE1_DMSOP_KTXT")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("KOTXT") Then
                    Langtext += d.Item("KOTXT") & vbCrLf
                End If
            Next
        End If
        Return Langtext
    End Function
    Private Function GetMaterialNummer(FAUFDS As DataSet) As String
        Dim Materialnummer As String = String.Empty

        'LangtextKopf auslesen
        If FAUFDS.Tables.Contains("E1AFKOL") Then
            Dim T_DOK As DataTable = FAUFDS.Tables("E1AFKOL")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("MATNR") Then
                    Materialnummer += d.Item("MATNR") & vbCrLf
                End If
            Next
        End If
        Return Materialnummer
    End Function
    Private Function GetAuftragsStk(FAUFDS As DataSet) As Integer
        Dim AuftragsStk As String = String.Empty

        'LangtextKopf auslesen
        If FAUFDS.Tables.Contains("E1AFKOL") Then
            Dim T_DOK As DataTable = FAUFDS.Tables("E1AFKOL")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("GAMNG") Then
                    AuftragsStk += d.Item("GAMNG") & vbCrLf
                End If
            Next
        End If
        Return CInt(AuftragsStk)
    End Function
    Private Function GetMatKurztext(FAUFDS As DataSet) As String
        Dim MatKurztext As String = String.Empty

        'LangtextKopf auslesen
        If FAUFDS.Tables.Contains("ZE1_DMSOP_MARX") Then
            Dim T_DOK As DataTable = FAUFDS.Tables("ZE1_DMSOP_MARX")
            For Each d In T_DOK.AsEnumerable
                If T_DOK.Columns.Contains("MAKTX") Then
                    MatKurztext += d.Item("MAKTX") & vbCrLf
                End If
            Next
        End If
        Return MatKurztext
    End Function
    Private Sub btn_suchen_Click(sender As Object, e As EventArgs) Handles btn_suchen.Click

        Auftragsnummer = txt_Auftragsnummer.Text
        SearchFauf()

    End Sub

    Private Sub VorgangsuebersichtBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles VorgangsuebersichtBindingSource.CurrentChanged

    End Sub

    Private Sub dgv_Auftrag_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Auftrag.CellContentClick
        If e.RowIndex = -1 Then
            Exit Sub
        End If
        'txt_Langtext.Text = Handler.GetLangtextVorgänge(dgv_Auftrag(0, e.RowIndex).Value)
        'MsgBox(dgv_Auftrag(0, e.RowIndex).Value)
    End Sub
End Class

Public Class Vorgangsuebersicht
    Public Property VorgansNr As String
    Public Property Startdatum As DateTime
    Public Property Enddatum As DateTime
    Public Property Arbeitsplatz As String
    Public Property Steuerschlüssel As String
    Public Property KurztextVorgang As String
    Public Property VorgangsMenge As Integer
    Public Property RückgemeldeteMenge As Integer

End Class