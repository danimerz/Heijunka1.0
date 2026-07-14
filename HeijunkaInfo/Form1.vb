Imports MQTTnet
Imports MQTTnet.Client
Imports HeijunkaInfo.HeijunkaInfo.DS_Info

Public Class Form1
    Dim mqClient As MqttClient
    Dim mqFactory As New MqttFactory
    Dim DS As New HeijunkaInfo.DS_Info

    Private _ConnectionChanged As Boolean
    Public Property ConnectionChanged() As String
        Get
            Return _ConnectionChanged
        End Get
        Set(ByVal value As String)
            _ConnectionChanged = value
            ConnectionChange()
        End Set
    End Property

    Public Sub ConnectionChange()
        If ConnectionChanged = True Then
            pb_Connect.Image = My.Resources.accept
        Else
            pb_Connect.Image = My.Resources.multiply
        End If
    End Sub

    Sub mmqt_start()
        Connect("HeijunkaInfo", "139.16.65.183", "MFZUG", "6300-Zug").Wait()
        'Publish("Heijunka/Info", "").Wait()
        Subscribe("Heijunka/#").Wait()
    End Sub

    Async Function Connect(Client As String, Server As String, User As String, Password As String) As Task
        mqClient = CType(mqFactory.CreateMqttClient(), MqttClient)
        mqClient.UseApplicationMessageReceivedHandler(AddressOf MessageRecieved)
        mqClient.UseDisconnectedHandler(AddressOf ConnectionClosed)
        mqClient.UseConnectedHandler(AddressOf ConnectionOpened)

        Dim Options As New Options.MqttClientOptionsBuilder
        Options.WithClientId(Client).WithTcpServer(Server, 1883).WithCredentials(User, Password)
        Await mqClient.ConnectAsync(Options.Build).ConfigureAwait(False)
    End Function

    Async Function Publish(Topic As String, Payload As String) As Task
        Await mqClient.PublishAsync(Topic, Payload).ConfigureAwait(False)
    End Function

    Async Function Subscribe(Topic As String) As Task
        Await mqClient.SubscribeAsync(Topic).ConfigureAwait(False)
    End Function

    Private Sub MessageRecieved(e As MqttApplicationMessageReceivedEventArgs)
        Dim Topic As String = e.ApplicationMessage.Topic
        Dim str() As String = Split(Topic, "/")

        If (str.Length < 2) Then
            Return
        End If

        Dim Computername As String = str(1)

        Dim HeijunkaInfoRow As HeijunkaInfoRow
        HeijunkaInfoRow = DS.HeijunkaInfo.FindByComputername(Computername)

        If IsNothing(HeijunkaInfoRow) Then
            HeijunkaInfoRow = DS.HeijunkaInfo.NewHeijunkaInfoRow
            HeijunkaInfoRow.Computername = Computername
            Select Case str(2)
                Case "Status"
                    HeijunkaInfoRow.Status = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "SAP-Version"
                    HeijunkaInfoRow._SAP_Version = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "SW-Version"
                    HeijunkaInfoRow._SW_Version = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Username"
                    HeijunkaInfoRow.Username = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "LastSeen"
                    HeijunkaInfoRow.LastSeen = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Status1"
                    HeijunkaInfoRow.Status1 = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Linie"
                    HeijunkaInfoRow.Linie = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
            End Select
            DS.HeijunkaInfo.Rows.Add(HeijunkaInfoRow)
        Else
            Select Case str(2)
                Case "Status"
                    HeijunkaInfoRow.Status = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "SAP-Version"
                    HeijunkaInfoRow._SAP_Version = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "SW-Version"
                    HeijunkaInfoRow._SW_Version = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Username"
                    HeijunkaInfoRow.Username = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "LastSeen"
                    HeijunkaInfoRow.LastSeen = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Status1"
                    HeijunkaInfoRow.Status1 = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                Case "Linie"
                    Try
                        HeijunkaInfoRow.Linie = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.Payload)
                    Catch ex As Exception
                    End Try
            End Select
        End If

        Me.InvokeIfRequired(Sub() lbl_anzdatensätze.Text = "Anzahl Datensätze: " & DS.HeijunkaInfo.Rows.Count.ToString())
        Me.InvokeIfRequired(Sub() lbl_Update.Text = "letztes Update: " & Now.TimeOfDay.ToString)
    End Sub

    Private Sub ConnectionClosed(e As Disconnecting.MqttClientDisconnectedEventArgs)
        Debug.WriteLine("Connection closed.")
        ConnectionChanged = False
    End Sub

    Private Sub ConnectionOpened(e As Connecting.MqttClientConnectedEventArgs)
        Debug.WriteLine("Connection opened.")
        ConnectionChanged = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mmqt_start()
        'BS_HeijunkaInfo.DataSource = DS.HeijunkaInfo
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        mmqt_start()
    End Sub

    Private Sub CellFormat()
        For i = 1 To DataGridView1.Rows.Count - 1
            If DataGridView1.Item(1, i).Value = "offline" Then
                DataGridView1.Rows(i).Cells(1).Style.BackColor = Color.Red
            End If
            If DataGridView1.Item(1, i).Value = "online" Then
                DataGridView1.Rows(i).Cells(1).Style.BackColor = Color.LightGreen
            End If
        Next i
    End Sub

    Private Sub DataGridView1_BindingContextChanged(sender As Object, e As EventArgs) Handles DataGridView1.BindingContextChanged
        'Me.InvokeIfRequired(Sub() BS_HeijunkaInfo.DataSource = DS.HeijunkaInfo)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        BS_HeijunkaInfo.DataSource = DS.HeijunkaInfo
    End Sub

End Class
