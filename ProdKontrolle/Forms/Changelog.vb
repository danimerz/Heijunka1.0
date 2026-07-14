Public Class Changelog
    Private Sub btn_OK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        Me.Close()
    End Sub

    Private Sub Changelog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Version auslesen
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim version As System.Version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion()
            lbl_Version.Text = "Changelog Version: " & version.ToString
        End If

        'Textdatei auslesen
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText(My.Settings.ChangeLogFile)
        txt_ChangeLog.Text = fileReader
        'Fokus setzten
        lbl_Fokus.Text = ""
    End Sub
End Class