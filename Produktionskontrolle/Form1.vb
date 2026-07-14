Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Daten abfüllen
        Me.Qry_LinieTableAdapter.Fill(Me.ProdKontrolleDataSet.qry_Linie)
        Me.Tbl_ProdKontrolleTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_ProdKontrolle)

        'Anzeige setzten
        dgv_Data.ReadOnly = True
        lbl_Count.Text = dgv_Data.Rows.Count - 1
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim version As System.Version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion()
            lbl_Version.Text = "Version: " & version.ToString
        End If
        TblProdKontrolleBindingSource.Sort = "Datum"

        'Datum von heute setzten
        dtp_DatumVon.Value = Now
        dtp_DatumBis.Value = Now

        'ListBox füllen
        Dim DT As DataTable = Qry_LinieTableAdapter.GetData
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
        TblProdKontrolleBindingSource.Filter = String.Format("[Datum] >= #{0}# AND [Datum] < #{1}# AND ({2})",
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

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        WriteXmlToFile(ProdKontrolleDataSet)
        MsgBox("Daten wurden Exportiert", vbInformation, "Export")
    End Sub

    Private Sub WriteXmlToFile(DS As DataSet)
        If DS Is Nothing Then
            Return
        End If
        SaveFileDialog1.Filter = "XML FIles (*.xml)|*.xml"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim filename As String = "temp.xml"
            Dim stream As New System.IO.FileStream(filename, System.IO.FileMode.Create)
            Dim xmlWriter As New System.Xml.XmlTextWriter(stream, System.Text.Encoding.Unicode)
            DS.WriteXml(SaveFileDialog1.FileName)
            xmlWriter.Close()
        End If
    End Sub

    Private Sub btn_clearFilter_Click(sender As Object, e As EventArgs) Handles btn_clearFilter.Click
        dtp_DatumVon.Value = Now
        dtp_DatumBis.Value = Now
        lb_Linie.SelectedItems.Clear()
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click

    End Sub
End Class
