Imports System.Deployment.Application

Public Class UpdateHandler


    Public Sub InstallUpdateSyncWithInfo()
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                Return
            Catch ioe As InvalidOperationException
                MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                Return
            End Try

            If (info.UpdateAvailable) Then
                Dim doUpdate As Boolean = True

                If (Not info.IsUpdateRequired) Then
                    Dim dr As DialogResult = MessageBox.Show("Es ist ein Update verfügbar. Möchten Sie das Update starten?", "Update verfügbar", MessageBoxButtons.OKCancel)
                    If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        doUpdate = False
                    End If
                Else
                    ' Display a message that the app MUST reboot. Display the minimum required version.
                    MessageBox.Show("This application has detected a mandatory update from your current " &
                        "version to version " & info.MinimumRequiredVersion.ToString() &
                        ". The application will now install the update and restart.",
                        "Update Available", MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
                End If

                If (doUpdate) Then
                    Try
                        AD.Update()
                        MessageBox.Show("Das Update wurde durchgeführt, die App startet neu.")
                        Application.Restart()
                    Catch dde As DeploymentDownloadException
                        MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                        Return
                    End Try
                End If
            End If
        End If
    End Sub

    Public Sub InstallUpdate()
        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment
            Try
                AD.Update()
                MessageBox.Show("Update erfolgreich. Digitales Heijunka wird neugestartet, bitte warten.")
                Application.Restart()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("Update konte nicht Installiert werden. " & ControlChars.Lf & ControlChars.Lf & "Prüfen Sie die Netzwerkverbindung, oder probieren Sie es später nochmals.")
                Return
            End Try
        End If
    End Sub

    Public Function CheckForUpdate() As Boolean
        Dim info As UpdateCheckInfo = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim AD As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            Try
                info = AD.CheckForDetailedUpdate()
            Catch dde As DeploymentDownloadException
                'MessageBox.Show("The new version of the application cannot be downloaded at this time. " + ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later. Error: " + dde.Message)
                CheckForUpdate = False
            Catch ioe As InvalidOperationException
                'MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " & ioe.Message)
                CheckForUpdate = False
            End Try
            If (info.UpdateAvailable) Then
                CheckForUpdate = True
            Else
                CheckForUpdate = False
            End If
        Else
            CheckForUpdate = False
        End If
    End Function
End Class
