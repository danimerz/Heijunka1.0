Imports MQTTnet
Imports MQTTnet.Client
Imports MQTTnet.Client.Options

Public Class mqtt
    Dim mqClient As MqttClient
    Dim mqFactory As New MqttFactory
    Private UpdateHandler As New UpdateHandler
    Public _ConnectionState As Boolean = False
    Public Property ConnectionState() As Boolean
        Get
            Return _ConnectionState
        End Get
        Set(ByVal value As Boolean)
            _ConnectionState = value
        End Set
    End Property

    Sub mmqt_start(ClientName As String, Adress As String, User As String, pwd As String)
        Connect(ClientName, Adress, User, pwd).Wait()
        'Publish("topic/volume", "20").Wait()
        'Subscribe("Heijunka/" & Environment.MachineName & "/Info").Wait()
        'Subscribe("Heijunka/" & Environment.MachineName & "/Update").Wait()
    End Sub

    Async Function Connect(Client As String, Server As String, User As String, Password As String) As Task
        mqClient = CType(mqFactory.CreateMqttClient(), MqttClient)
        mqClient.UseApplicationMessageReceivedHandler(AddressOf MessageRecieved)
        mqClient.UseDisconnectedHandler(AddressOf ConnectionClosed)
        mqClient.UseConnectedHandler(AddressOf ConnectionOpened)

        'Dim Options As New Options.MqttClientOptionsBuilder
        'Options.WithClientId(Client).WithTcpServer(Server, 1883).WithCredentials(User, Password)
        Dim Options As New MqttClientOptionsBuilder()

        Dim mqttOptions = Options _
            .WithClientId(Client) _
            .WithTcpServer(Server, 1883) _
            .WithCredentials(User, Password) _
            .WithTls(Function(tls)
                         tls.UseTls = False
                         tls.AllowUntrustedCertificates = True
                         tls.IgnoreCertificateChainErrors = True
                         tls.IgnoreCertificateRevocationErrors = True
                         tls.SslProtocol = Security.Authentication.SslProtocols.Tls12
                         Return tls
                     End Function) _
            .WithCleanSession() _
            .Build()

        Try
            Await mqClient.ConnectAsync(mqttOptions).ConfigureAwait(False)
        Catch ex As Exception
            Console.WriteLine("Fehler beim Verbinden: " & ex.Message)
        End Try

    End Function

    Async Function Disconnect(Client As String, Server As String, User As String, Password As String) As Task

    End Function

    Async Function Publish(Topic As String, Payload As String) As Task
        Dim message As New MqttApplicationMessageBuilder
        message.WithTopic(Topic)
        message.WithPayload(Payload)
        'message.WithRetainFlag()

        Await mqClient.PublishAsync(message.Build).ConfigureAwait(False)
    End Function

    Async Function Subscribe(Topic As String) As Task
        Await mqClient.SubscribeAsync(Topic).ConfigureAwait(False)
    End Function

    Private Sub MessageRecieved(e As MqttApplicationMessageReceivedEventArgs)
        'txt_recv.InvokeIfRequired(Sub() txt_recv.Text = "Topic: " & e.ApplicationMessage.Topic & vbCrLf & "Payload: " & System.Text.UTF8Encoding.UTF8.GetString(e.ApplicationMessage.Payload))
        Dim Topic As String = e.ApplicationMessage.Topic
        Dim str() As String = Split(Topic, "/")
        Dim Computername As String = str(1)
        Dim SubTopic As String = str(2)
        Dim Payload As String = System.Text.UTF8Encoding.UTF8.GetString(e.ApplicationMessage.Payload)

        Select Case SubTopic
            Case "Update"
                If Payload = "Start" Then
                    If UpdateHandler.CheckForUpdate = True Then
                        UpdateHandler.InstallUpdate()
                        Publish("Heijunka/" & Computername & "/Update", "update done").Wait()
                    Else
                        Publish("Heijunka/" & Computername & "/Update", "no update needed").Wait()
                    End If
                End If
            Case "Info"
                Dim frm As New frm_Info("Wichtige Information", Payload, Color.Red)
                frm.ShowDialog()
        End Select

    End Sub

    Private Sub ConnectionClosed(e As Disconnecting.MqttClientDisconnectedEventArgs)
        'MessageBox.Show("Connection closed.")
        Debug.WriteLine("MQTT getrennt: " & If(e.Exception?.Message, "Kein Fehler"))
        ConnectionState = False
    End Sub

    Private Sub ConnectionOpened(e As Connecting.MqttClientConnectedEventArgs)
        'MessageBox.Show("Connection opened.")
        ConnectionState = True
    End Sub

End Class
