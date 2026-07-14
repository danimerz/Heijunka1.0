Public Class frm_Passwort
    Private Maxversuche As Integer = 3
    Private Versuch As Integer = 0
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click

        If txt_passwort.Text = "Heijunka2020" Then
            DialogResult = DialogResult.OK
        Else
            Versuch = Versuch + 1
            MsgBox("Falsches Passwort!" & vbCrLf & "Noch " & Maxversuche - Versuch & " Versuche.", vbCritical, "Fehler")
            txt_passwort.Text = ""
            If Versuch = Maxversuche Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frm_Passwort_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub
End Class