Imports ProdKontrolle.DS_ProdKontrolleTableAdapters
Imports ProdKontrolle.Form1
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frm_ausschuss
    Public AuftragsNummer As String = String.Empty
    Public MaterialNummer As String = String.Empty
    Public Linie As String = String.Empty
    Public DT As New DataTable

    Private Row As Integer = 0
    Private tblAdapter As New tbl_ausschussTableAdapter
    Private globalFunction As New GlobaleFunktionen
    Private log As New logging
    Private Ausschuss As New DS_ProdKontrolle.tbl_ausschussDataTable

    Public Sub New(Fauf As String, MatNr As String, Line As String)

        InitializeComponent()
        AuftragsNummer = Fauf
        MaterialNummer = MatNr
        Linie = Line

        DT.Columns.Add("Material", GetType(String))
        DT.Columns.Add("Kurztext", GetType(String))
        DT.Columns.Add("PLO", GetType(String))

    End Sub

    Private Sub frm_ausschuss_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim stueli As IEnumerable = globalFunction.GetStuecklisteFromSAPXML(MaterialNummer, AuftragsNummer)
        If Not IsNothing(stueli) Then
            For Each r In stueli
                If Not r.PLO = "1027" Or r.PLO = "1028" Then
                    DT.Rows.Add(r.Material, r.KT, r.PLO)
                End If
            Next
            dgv_ausschuss.DataSource = DT
            dgv_ausschuss.CurrentCell.Selected = False

            'Spaltenbreite im dgv 
            dgv_ausschuss.Columns(0).Width = 280
            dgv_ausschuss.Columns(1).Width = 767
            dgv_ausschuss.Columns(2).Width = 80
        Else
            MsgBox("Fehler beim lesen der Stückliste", vbCritical, "Fehler")
            log.WriteLog(Date.Now, Linie, MaterialNummer, AuftragsNummer, "Fehler beim lesen der Stückliste")
            Me.Close()
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                dgv_korrektur.Rows.Clear()
                dgv_ausschuss.CurrentCell.Selected = False
                lbl_Material.Text = ""
                txt_Anzahl.Text = "1"
                btn_buchen.Text = "Buchen"
                btn_buchen.Width = 217
                btn_delete.Visible = False
            Case 1
                btn_buchen.Width = 154
                btn_delete.Visible = True
                btn_buchen.Text = "Ändern"
                lbl_Material.Text = ""
                txt_Anzahl.Text = ""

                getDataFromDB()
        End Select
    End Sub

    Private Sub getDataFromDB()
        If dgv_korrektur.Rows.Count > 0 Then
            dgv_korrektur.Rows.Clear()
        End If

        Dim Format As String = "dd.MM.yyyy HH:mm"
        Dim FromTimeString = "00:00"
        Dim ToTimeString = "23:59"
        Dim Now As DateTime = DateTime.Now
        Dim combinedFromDateTimeString As String = Now.ToShortDateString() & " " & FromTimeString
        Dim combinedToDateTimeString As String = Now.ToShortDateString() & " " & ToTimeString

        Dim von As DateTime = DateTime.ParseExact(combinedFromDateTimeString, Format, CultureInfo.InvariantCulture)
        Dim bis As DateTime = DateTime.ParseExact(combinedToDateTimeString, Format, CultureInfo.InvariantCulture)

        Ausschuss = tblAdapter.GetDataByDateLine(von, bis, Linie, False)

        For Each item As DS_ProdKontrolle.tbl_ausschussRow In Ausschuss
            dgv_korrektur.Rows.Add(item.id, item.Datum, item.Linie, item.ArtikelNummer, item.ArtikelBezeichnung, item.plo, item.Menge, item.Preis, item.gebucht)
        Next
        If dgv_korrektur.Rows.Count > 0 Then
            dgv_korrektur.CurrentCell.Selected = False
        End If
    End Sub

#Region "AusschussBuchen"
    Private Sub dgv_ausschuss_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_ausschuss.CellClick, dgv_korrektur.CellClick
        Select Case TabControl1.SelectedIndex
            Case 0 'Ausschuss Buchen
                If e.RowIndex >= 0 Then
                    Row = e.RowIndex
                    lbl_Material.Text = dgv_ausschuss.Rows(e.RowIndex).Cells(0).Value & " - " & dgv_ausschuss.Rows(e.RowIndex).Cells(1).Value
                End If
            Case 1 'Ausschuss Korrigieren
                If e.RowIndex >= 0 Then
                    Row = e.RowIndex
                    lbl_Material.Text = dgv_korrektur.Rows(e.RowIndex).Cells(3).Value & " - " & dgv_korrektur.Rows(e.RowIndex).Cells(4).Value
                    txt_Anzahl.Text = dgv_korrektur.Rows(e.RowIndex).Cells(6).Value
                End If
        End Select
    End Sub
    Private Sub txt_Anzahl_Leave(sender As Object, e As EventArgs) Handles txt_Anzahl.Leave
        If Not IsNumeric(txt_Anzahl.Text) Then
            txt_Anzahl.Text = "1"
        End If
    End Sub
    Private Sub btn_plus_Click(sender As Object, e As EventArgs) Handles btn_plus.Click
        Try
            Dim inhalt As Integer = CInt(txt_Anzahl.Text)
            txt_Anzahl.Text = (inhalt + 1).ToString
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_minus_Click(sender As Object, e As EventArgs) Handles btn_minus.Click
        Try
            Dim inhalt As Integer = CInt(txt_Anzahl.Text)
            If inhalt > 1 Then
                txt_Anzahl.Text = (inhalt - 1).ToString
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_buchen_Click(sender As Object, e As EventArgs) Handles btn_buchen.Click
        Select Case TabControl1.SelectedIndex
            Case 0
                Try
                    If dgv_ausschuss.CurrentCell.Selected Then
                        tblAdapter.InsertQuery(DateTime.Now, ' Aktuelles Datum
                                               Linie, ' Linie
                                               dgv_ausschuss.Rows(Row).Cells(0).Value, ' Material
                                               dgv_ausschuss.Rows(Row).Cells(1).Value, ' Kurztext
                                               dgv_ausschuss.Rows(Row).Cells(2).Value, ' PLO
                                               CInt(txt_Anzahl.Text), ' Anzahl
                                               0, ' Preis
                                               False) ' Gebucht
                        MsgBox("Material erfolgreich gebucht", vbInformation, "Information")
                        lbl_Material.Text = ""
                        txt_Anzahl.Text = "1"
                        txt_search.Text = ""
                        dgv_ausschuss.CurrentCell.Selected = False
                        dgv_ausschuss.DataSource = DT

                    Else
                        MsgBox("Bitte eine Zeile markieren", vbInformation, "Information")
                    End If
                Catch ex As Exception
                    MsgBox("Fehler beim schreiben in die Datenbank", vbCritical, "Fehler")
                    log.WriteLog(Date.Now, Linie, MaterialNummer, AuftragsNummer, ex.Message)
                End Try
            Case 1
                'Daten ändern und neuaufbau des DGV
                Try
                    If dgv_korrektur.CurrentCell.Selected Then
                        tblAdapter.UpdateQuery(DateTime.Now, CInt(txt_Anzahl.Text), CInt(dgv_korrektur.Rows(Row).Cells(0).Value))
                        MsgBox("Material erfolgreich geändert", vbInformation, "Information")
                        lbl_Material.Text = ""
                        txt_Anzahl.Text = "0"
                        dgv_korrektur.CurrentCell.Selected = False
                        getDataFromDB()
                    Else
                        MsgBox("Bitte eine Zeile markieren", vbInformation, "Information")
                    End If
                Catch ex As Exception
                    MsgBox("Fehler beim Updaten der Datenbank", vbCritical, "Fehler")
                    log.WriteLog(Date.Now, Linie, MaterialNummer, AuftragsNummer, ex.Message)
                End Try
        End Select


    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click

        Select Case MessageBox.Show("Soll der Eintrag gelöscht werden?", "Frage", MessageBoxButtons.YesNo)
            Case Windows.Forms.DialogResult.Yes
                Try
                    If dgv_korrektur.CurrentCell.Selected Then
                        tblAdapter.DeleteQuery(CInt(dgv_korrektur.Rows(Row).Cells(0).Value))
                        MsgBox("Material erfolgreich gelöscht", vbInformation, "Information")
                        lbl_Material.Text = ""
                        txt_Anzahl.Text = "0"
                        dgv_korrektur.CurrentCell.Selected = False
                        getDataFromDB()
                    Else
                        MsgBox("Bitte eine Zeile markieren", vbInformation, "Information")
                    End If
                Catch ex As Exception
                    MsgBox("Fehler beim löschen aus der Datenbank", vbCritical, "Fehler")
                    log.WriteLog(Date.Now, Linie, MaterialNummer, AuftragsNummer, ex.Message)
                End Try
            Case Windows.Forms.DialogResult.No
                Exit Sub
        End Select

    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged

    End Sub


#End Region


End Class

Public Class Ausschuss
    Public Material As String
    Public PLO As String
    Public STK As Double
    Public Kurztext As String
End Class