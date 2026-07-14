Public Class frm_Info

    Public Sub New(Titel As String, Info As String, Optional Color As Color = Nothing)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        If Color = Nothing Then
            Color = Color.Black
        End If

        lbl_Titel.Text = Titel
        lbl_Titel.ForeColor = Color
        lbl_info.Text = Info
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub
End Class