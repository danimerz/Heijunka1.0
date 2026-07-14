Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Tbl_FAUF_StatusTableAdapter.ClearBeforeFill = True
        Dim DT As DataTable = Tbl_FAUF_Status1TableAdapter.GetData

        For Each row In DT.AsEnumerable

            Tbl_FAUF_StatusTableAdapter.InsertQuery(row.Field(Of String)("FAUF"), row.Field(Of String)("ProdDatum"), row.Field(Of Integer)("SollStk"), row.Field(Of String)("Status"))

        Next

        MsgBox("Done")
    End Sub


End Class
