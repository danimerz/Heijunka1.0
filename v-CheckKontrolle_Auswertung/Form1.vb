Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_Linie". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_LinieTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_Linie)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_vcheckKontrolle". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolle)

        'Anzeige setzten
        dgv_data.ReadOnly = True
        lbl_Count.Text = dgv_data.Rows.Count - 1
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim version As System.Version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion()
            lbl_Version.Text = "Version: " & version.ToString
        End If
        Tbl_vcheckKontrolleBindingSource.Sort = "Datum"

        'Datum von heute setzten
        dtp_DatumVon.Value = Now
        dtp_DatumBis.Value = Now

        'ListBox füllen
        Dim DT As DataTable = Tbl_LinieTableAdapter.GetData
        For Each Item In DT.AsEnumerable
            lb_Linie.Items.Add(Item("Linie"))
        Next
    End Sub


    Sub SetFilter(startDate As DateTime, endDate As DateTime)
        Dim LinienFilter As String = ""
        For i = 0 To lb_Linie.SelectedItems.Count - 1
            LinienFilter += "[Linie] = '" & lb_Linie.SelectedItems(i).ToString & "'"
            If i <> lb_Linie.SelectedItems.Count - 1 Then
                LinienFilter += " OR "
            End If
        Next
        Tbl_vcheckKontrolleBindingSource.Filter = String.Format("[Datum] >= #{0}# AND [Datum] < #{1}# AND ({2})",
                                                             startDate.ToString("MM/dd/yyyy"),
                                                             endDate.ToString("MM/dd/yyyy"),
                                                             LinienFilter)
    End Sub

    Private Sub btn_bearbeiten_Click(sender As Object, e As EventArgs) Handles btn_bearbeiten.Click
        If lb_Linie.SelectedIndex <> -1 Then
            SetFilter(dtp_DatumVon.Value, dtp_DatumBis.Value.AddDays(1))
            lbl_Count.Text = dgv_Data.Rows.Count - 1
        Else
            MsgBox("Bitte eine Linie auswählen", vbCritical, "Fehler")
        End If
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub btn_clearFilter_Click(sender As Object, e As EventArgs) Handles btn_clearFilter.Click
        dtp_DatumVon.Value = Now
        dtp_DatumBis.Value = Now
        lb_Linie.SelectedItems.Clear()
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        MsgBox("Hier kann irgendwann gedruckt werden :)")
    End Sub

    Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        Dim f As New add
        f.ShowDialog()
        Me.Tbl_vcheckKontrolleTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolle)

    End Sub
End Class
