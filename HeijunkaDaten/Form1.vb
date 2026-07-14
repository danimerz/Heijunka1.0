Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Tbl_LinieTableAdapter.Fill(Me.ProdKontrolleDataSet.tbl_Linie)
        Tbl_LinieDataGridView.ReadOnly = True
        lbl_Count.Text = Tbl_LinieDataGridView.Rows.Count
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim version As System.Version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion()
            lbl_Version.Text = "Version: " & version.ToString
        End If
        Tbl_LinieBindingSource.Sort = "Gruppe"
        lbl_bearbeitung.Text = "Bearbeitung: Inaktiv"

    End Sub

    Private Sub txt_Filter_TextChanged(sender As Object, e As EventArgs) Handles txt_Filter.TextChanged
        Tbl_LinieBindingSource.Filter = "[Gruppe] LIKE '%" & txt_Filter.Text & "%' OR [GruppeTeam] Like '%" & txt_Filter.Text & "%'
                                        OR [Linie] Like '%" & txt_Filter.Text & "%' OR [AP] Like '%" & txt_Filter.Text & "%'
                                        OR [station] Like '%" & txt_Filter.Text & "%' OR [LineName] Like '%" & txt_Filter.Text & "%'"
        lbl_Count.Text = Tbl_LinieDataGridView.Rows.Count
    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        Me.Validate()
        Me.Tbl_LinieBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.ProdKontrolleDataSet)
        lbl_bearbeitung.Text = "Bearbeitung: Inaktiv"
        Tbl_LinieDataGridView.ReadOnly = True
        btn_delete.Enabled = False
        btn_Save.Enabled = False
        btn_bearbeiten.Enabled = True

    End Sub

    Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
        Tbl_LinieBindingSource.AddNew()
        lbl_bearbeitung.Text = "Bearbeitung: Aktiv"
        btn_Save.Enabled = True
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If MessageBox.Show("Datensatz wirklich löschen?", "Frage", MessageBoxButtons.YesNo) _
             = Windows.Forms.DialogResult.Yes Then
            Tbl_LinieBindingSource.RemoveCurrent()
        End If
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btn_bearbeiten.Click
        Tbl_LinieDataGridView.ReadOnly = False
        lbl_bearbeitung.Text = "Bearbeitung: Aktiv"
        btn_bearbeiten.Enabled = False
        btn_Save.Enabled = True
        btn_delete.Enabled = True
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Das Programm wird geschlossen, nicht gespeicherte änderungen gehen verlohren!" & vbCrLf & vbCrLf & "Soll der Editor beendet werden?", "Heijunka Editor beenden?", MessageBoxButtons.YesNo) _
             = Windows.Forms.DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub Form1_HelpButtonClicked(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.HelpButtonClicked

        MsgBox("Hilfeeeee...." & vbCrLf & vbCrLf & ".... kommt bald!", vbInformation)
    End Sub


End Class
