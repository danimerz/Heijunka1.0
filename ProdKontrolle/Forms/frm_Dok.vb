Public Class frm_Dok
    Private _DataTable As DataTable
    Private _ASN As String
    Private _Fauf As String

    Public Sub New(DT As DataTable, Material As String, Auftrag As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        DataTable = DT
        ASN = Material
        FAUF = Auftrag
    End Sub

    Public Property DataTable As DataTable
        Set(value As DataTable)
            _DataTable = value
        End Set
        Get
            Return _DataTable
        End Get
    End Property
    Public Property ASN As String
        Set(value As String)
            _ASN = value
        End Set
        Get
            Return _ASN
        End Get
    End Property
    Public Property FAUF As String
        Set(value As String)
            _Fauf = value
        End Set
        Get
            Return _Fauf
        End Get
    End Property

    Private Enum DGV_Column
        DokNr = 0
        DokIndex = 1
        DokText = 2
        Link = 3
    End Enum

    Private Sub frm_Dok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        lbl_titel.Text = "Dokumente zum Auftrag: " & FAUF & " / " & ASN

        For Each r As DataRow In DataTable.AsEnumerable
            If Not r("Link") = "nothing" Then
                dgv_Dok.Rows.Add(r("DokNr")) 'Spalte dient nur der Anzeige
                dgv_Dok.Rows(i).Cells(DGV_Column.DokIndex).Value = r("DokVersion")
                dgv_Dok.Rows(i).Cells(DGV_Column.DokText).Value = r("DokText")
                dgv_Dok.Rows(i).Cells(DGV_Column.Link).Value = r("Link")
                i = i + 1
            End If
        Next
        dgv_Dok.ClearSelection()
    End Sub

    Private Sub dgv_Dok_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_Dok.CellDoubleClick
        Process.Start(dgv_Dok(DGV_Column.Link, e.RowIndex).Value.ToString)
        Me.Close()
    End Sub
End Class