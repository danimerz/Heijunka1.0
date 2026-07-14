Imports Newtonsoft.Json
Imports System.IO, System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Net.Security
Imports Org.BouncyCastle.Asn1.Ocsp
Imports System.Net.Cache
Imports Newtonsoft
Imports System.Net.Mime
Imports System.Net.Http
Imports System.Net.Http.Headers


Public Class Wats
    ' Ein gemeinsamer HttpClient/Handler für alle Aufrufe (statt pro Aufruf neu erzeugt).
    ' HttpClient ist für gleichzeitige Aufrufe von mehreren Threads/Tasks aus sicher nutzbar
    ' (siehe .NET-Doku) und muss für parallele WATS-Abfragen wiederverwendet werden, sonst
    ' droht Socket-/Port-Erschöpfung bei vielen gleichzeitigen Requests.
    Private Shared ReadOnly SharedHandler As HttpClientHandler
    Private Shared ReadOnly SharedHttpClient As HttpClient

    Shared Sub New()
        ' .NET Framework erlaubt standardmässig nur 2 gleichzeitige Verbindungen pro Zielserver
        ' (ServicePointManager.DefaultConnectionLimit). Ohne diese Anhebung bringt eine
        ' Parallelisierung der WATS-Abfragen praktisch nichts, da die Requests intern trotzdem
        ' auf 2 gleichzeitige Verbindungen gedrosselt würden.
        ServicePointManager.DefaultConnectionLimit = 20

        SharedHandler = New HttpClientHandler() With {
            .ServerCertificateCustomValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True
        }
        SharedHttpClient = New HttpClient(SharedHandler) With {
            .Timeout = TimeSpan.FromSeconds(15)
        }
    End Sub

    Public Async Function WATS_GetAsync(Url As String) As Task(Of String)
        Using request As New HttpRequestMessage(HttpMethod.Get, Url)
            request.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
            request.Headers.Accept.Add(New Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Try
                Dim response As HttpResponseMessage = Await SharedHttpClient.SendAsync(request)

                ' Überprüfen, ob der Aufruf erfolgreich war
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                    Return responseContent ' Die API-Antwort als Zeichenfolge zurückgeben
                Else
                    ' Bei einem Fehler den Statuscode und die Fehlermeldung ausgeben
                    Debug.WriteLine($"Fehler: {response.StatusCode} - {response.ReasonPhrase}")
                    Dim log As New logging
                    log.WriteLog(Date.Now, "", "", "", $"Fehler: {response.StatusCode} - {response.ReasonPhrase}")
                    Return Nothing
                End If

            Catch ex As HttpRequestException
                ' Fehler bei der HTTP-Anforderung
                Debug.WriteLine($"HTTP-Fehler: {ex.Message}")
                Dim log As New logging
                log.WriteLog(Date.Now, "", "", "", $"HTTP-Fehler: {ex.Message} - {ex.InnerException}")
                Return Nothing
            End Try
        End Using
    End Function

    Public Async Function Wats_PostAsync(Url As String, FAUF As String, DateFrom As String, DateTo As String, station As String, Durchgang As Integer, Optional TestOp As String = "600;602;603") As Task(Of Object)
        'Filter für WATS abfrage deklarieren
        Dim Filter As New Filter
        Filter.productGroup = ""
        Filter.level = "0"
        Filter.testOperation = TestOp
        Filter.batchNumber = FAUF
        Filter.MaxCount = 100000
        Filter.TopCount = 100000
        Filter.dateFrom = DateFrom
        Filter.dateTo = DateTo
        Filter.stationName = station
        Filter.yield = Durchgang

        'Filter in JSON String Konvertieren
        Dim jsonTxt As String = JsonConvert.SerializeObject(Filter)

        Using request As New HttpRequestMessage(HttpMethod.Post, Url)
            request.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
            request.Headers.Accept.Add(New Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))
            request.Content = New StringContent(jsonTxt, Encoding.UTF8, "application/json")

            Try
                Dim response As HttpResponseMessage = Await SharedHttpClient.SendAsync(request)

                ' Überprüfen, ob der Aufruf erfolgreich war
                If response.IsSuccessStatusCode Then
                    Dim responseContent As String = Await response.Content.ReadAsStringAsync()
                    Return responseContent ' Die API-Antwort als Zeichenfolge zurückgeben
                Else
                    ' Bei einem Fehler den Statuscode und die Fehlermeldung ausgeben
                    Debug.WriteLine($"Fehler: {response.StatusCode} - {response.ReasonPhrase}")
                    Return Nothing
                End If

            Catch ex As HttpRequestException
                ' Fehler bei der HTTP-Anforderung
                Debug.WriteLine($"HTTP-Fehler: {ex.Message}")
                Return Nothing
            End Try
        End Using
    End Function

End Class

''' <summary>
''' Filter propertys
''' </summary>
Public Class Filter
    Public Property batchNumber() As String
        Get
            Return m_batch
        End Get
        Set
            m_batch = Value
        End Set
    End Property
    Private m_batch As String
    Public Property productGroup() As String
        Get
            Return m_group
        End Get
        Set
            m_group = Value
        End Set
    End Property
    Private m_group As String
    Public Property testOperation() As String
        Get
            Return m_testop
        End Get
        Set
            m_testop = Value
        End Set
    End Property
    Private m_testop As String
    Public Property level() As String
        Get
            Return m_level
        End Get
        Set
            m_level = Value
        End Set
    End Property
    Private m_level As String
    Public Property dateFrom() As String
        Get
            Return m_datestart
        End Get
        Set
            m_datestart = Value
        End Set
    End Property
    Private m_datestart As String
    Public Property dateTo() As String
        Get
            Return m_dateend
        End Get
        Set
            m_dateend = Value
        End Set
    End Property
    Private m_dateend As String
    Public Property stationName() As String
        Get
            Return m_stationname
        End Get
        Set
            m_stationname = Value
        End Set
    End Property
    Private m_stationname As String

    Public Property MaxCount() As String
        Get
            Return m_MaxCount
        End Get
        Set
            m_MaxCount = Value
        End Set
    End Property
    Private m_MaxCount As String
    Public Property dateTimeUtc() As String
        Get
            Return m_Date
        End Get
        Set
            m_Date = Value
        End Set
    End Property
    Private m_Date As String
    Public Property yield() As String
        Get
            Return m_yield
        End Get
        Set
            m_yield = Value
        End Set
    End Property
    Private m_yield As String
    Public Property TopCount() As String
        Get
            Return m_TopCount
        End Get
        Set
            m_TopCount = Value
        End Set
    End Property
    Private m_TopCount As String
End Class