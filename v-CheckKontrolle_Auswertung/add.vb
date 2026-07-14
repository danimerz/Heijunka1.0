Public Class add


    Private Sub add_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_vcheckKontrolleTeam". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleTeamTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolleTeam)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_vcheckKontrolleLinie". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleLinieTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolleLinie)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_vcheckKontrolleOperator". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleOperatorTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolleOperator)
        'TODO: Diese Codezeile lädt Daten in die Tabelle "ProdKontrolleDataSet.tbl_vcheckKontrolle". Sie können sie bei Bedarf verschieben oder entfernen.
        Me.Tbl_vcheckKontrolleTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_vcheckKontrolle)

        dtp_Datum.Value = Now

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txt_Fauf.Text = String.Empty And txt_MatNr.Text = String.Empty Then
            MsgBox("Bitte alle Felder ausfüllen")
        Else
            'Speichern der Daten in der Datenbank

            'ist FAUF Nummer nummerisch?
            If IsNumeric(txt_Fauf.Text) Then
                Tbl_vcheckKontrolleTableAdapter.InsertQuery(txt_MatNr.Text, txt_Fauf.Text, dtp_Datum.Value, cb_Ma.Text, cb_Team.Text, cb_Linie.Text)
                Me.Close()
            Else
                MsgBox("Auftragsnummer nicht korrekt")
            End If

        End If
    End Sub

    Private Sub btn_v_Check_Click(sender As Object, e As EventArgs) Handles btn_v_Check.Click
        Dim str As String = String.Empty
        'ist FAUF Nummer nummerisch und mind. 7 zeichen lang?
        If IsNumeric(txt_Fauf.Text) And Len(txt_Fauf.Text) >= 7 And Len(txt_Fauf.Text) <= 8 Then
            Dim qry = From r In HJ_GetOperationInfoTableAdapter.GetData(txt_Fauf.Text)
                      Where r.SN <> 0


            If qry.Count < 1 Then
                MsgBox("Es sind keine Daten im v-Check hinterlegt." & vbCrLf & "Auftragsnummer korrekt?", vbInformation, "v-Check Daten")
            Else
                For Each row In qry
                    str = "Soll: " & row.Item("ExpectedSN").ToString & "stk." & vbCrLf &
                    "Pass: " & row.Item("OperationPass").ToString & "stk." & vbCrLf &
                    "Offen: " & (row.Item("SN") - row.Item("OperationPass")).ToString & "stk." & vbCrLf &
                    "Trash: " & row.Item("TRASH").ToString & "stk." & vbCrLf &
                    "FPY: " & Math.Round(row.Item("OperationFirstPASS") / row.Item("OperationPass") * 100, 2) & "%"
                Next

                MsgBox("Folgende Daten sind im V-Check hinterlegt: " & vbCrLf & vbCrLf & str, vbInformation, "v-Check Daten")
            End If
        Else
            MsgBox("Auftragsnummer nicht korrekt")
        End If
    End Sub

End Class