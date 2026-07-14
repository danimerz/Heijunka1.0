Public Class frm_ProdKontrolle_Detail
    Private _Data As Object
    Private _Auftrag As String
    Private _ErledigenAktiv As Boolean
    Private rowIndex As Integer
    Private tblAdapter As New DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter
    Private _AuftrStartAktiv As Boolean
    Public Property AuftragsStartAktiv() As Boolean
        Get
            Return _AuftrStartAktiv
        End Get
        Set(ByVal value As Boolean)
            _AuftrStartAktiv = value
        End Set
    End Property
    Public Property ErledigenAktivieren() As Boolean
        Get
            Return _ErledigenAktiv
        End Get
        Set(ByVal value As Boolean)
            _ErledigenAktiv = value
        End Set
    End Property
    Public Property QeryData() As Object
        Get
            Return _Data
        End Get
        Set(ByVal value As Object)
            _Data = value
        End Set
    End Property
    Public Property FAUFNr() As String
        Get
            Return _Auftrag
        End Get
        Set(ByVal value As String)
            _Auftrag = value
        End Set
    End Property
    Public Sub New(Data As Object, FAUF As String, ErledigenAktiv As Boolean, auftragStartAktiv As Boolean)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        QeryData = Data
        FAUFNr = FAUF
        ErledigenAktivieren = ErledigenAktiv
        AuftragsStartAktiv = auftragStartAktiv

    End Sub

    Private Sub frm_ProdKontrolle_Detail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_titel.Text = "Detailübersicht für Auftrag " & FAUFNr
        If AuftragsStartAktiv = True Then
            Me.ControlBox = False
        End If
        If ErledigenAktivieren = False Then
            btn_alle.Visible = False
            btn_einzeln.Visible = False
        End If

        Dim i As Integer = 0
        For Each row In QeryData
            dgv_Deatil.Rows.Add(row("Datum"))
            dgv_Deatil.Rows(i).Cells(1).Value = row("Linie")
            dgv_Deatil.Rows(i).Cells(2).Value = row("Material")
            dgv_Deatil.Rows(i).Cells(3).Value = row("FAUF")
            dgv_Deatil.Rows(i).Cells(4).Value = row("Soll")
            dgv_Deatil.Rows(i).Cells(5).Value = row("Ist")
            dgv_Deatil.Rows(i).Cells(6).Value = row("Status")
            dgv_Deatil.Rows(i).Cells(7).Value = row("Grund")
            dgv_Deatil.Rows(i).Cells(8).Value = row("Zusatz")
            dgv_Deatil.Rows(i).Cells(9).Value = row("id")
            i = i + 1
        Next
        dgv_Deatil.CurrentCell.Selected = False
    End Sub

    Private Sub btn_einzeln_Click(sender As Object, e As EventArgs) Handles btn_einzeln.Click
        If dgv_Deatil.SelectedRows.Count > 0 Then
            Try
                Dim Id As Integer = CInt(dgv_Deatil(9, rowIndex).Value)
                tblAdapter.UpdateStatusById("erledigt", Id)
                dgv_Deatil.Rows.RemoveAt(rowIndex)
                If dgv_Deatil.Rows.Count > 0 Then
                    dgv_Deatil.CurrentCell.Selected = False
                End If
            Catch ex As Exception
                MsgBox("Bitte Zeile markieren.", vbInformation, "Information")
            End Try
        Else
            MsgBox("Bitte Zeile markieren.", vbInformation, "Information")
        End If
        If dgv_Deatil.Rows.Count = 0 Then
            Close()
        End If

    End Sub

    Private Sub btn_alle_Click(sender As Object, e As EventArgs) Handles btn_alle.Click
        'Durchlaufe ganzes Datagridview und 
        For Each item As DataGridViewRow In dgv_Deatil.Rows
            Dim ID As Integer = CInt(item.Cells(9).Value)
            tblAdapter.UpdateStatusById("erledigt", ID)
        Next
        Close()
    End Sub

    Private Sub dgv_Deatil_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Deatil.CellContentClick
        'Rowindex der Selektierten Zeile in Variable Speichern
        rowIndex = e.RowIndex
    End Sub

    Private Sub lbl_titel_DoubleClick(sender As Object, e As EventArgs) Handles lbl_titel.DoubleClick
        Me.ControlBox = True
    End Sub
End Class


