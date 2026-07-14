Public Class LinieAuswaehlen
    Private Sub LinieAuswaehlen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "DS_ProdKontrolle.tbl_Linie". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_LinieTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_Linie)

    End Sub

    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        My.Settings.Linie = ComboBox1.Text
        Me.Close()
    End Sub
End Class