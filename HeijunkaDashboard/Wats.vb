Imports Newtonsoft.Json
Imports System.IO, System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Net.Security
Public Class Wats

    Public Function GetFPY(Station As String, DateFrom As String, DateTo As String) As Object
        'Filter für WATS abfrage deklarieren
        Dim Filter As New Filter
        Filter.productGroup = ""
        Filter.level = "0"
        Filter.testOperation = "600;602;603"
        Filter.dateFrom = DateFrom
        Filter.dateTo = DateTo
        Filter.stationName = Station

        'Filter in JSON String Konvertieren
        Dim jsonTxt As String = JsonConvert.SerializeObject(Filter)

        'Web API Abfrage
        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse
        Dim myReader As StreamReader
        Dim URL As String = "http://fit.sbt.siemens.com/wats/api/app/HighVolume"
        myReq = HttpWebRequest.Create(URL)
        myReq.Method = "POST"
        myReq.ContentType = "application/json"
        myReq.MediaType = "jsonp"
        myReq.Accept = "application/json"
        myReq.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
        myReq.GetRequestStream.Write(Encoding.UTF8.GetBytes(jsonTxt), 0, Encoding.UTF8.GetBytes(jsonTxt).Count)
        myResp = myReq.GetResponse
        myReader = New System.IO.StreamReader(myResp.GetResponseStream)
        Dim raw As String = myReader.ReadToEnd
        Dim respond As Object = JsonConvert.DeserializeObject(raw)
        myResp.Close()
        myReader.Close()
        Return respond
    End Function

    Public Function WATS_GET(Url As String) As Object
        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse
        Dim myReader As StreamReader
        myReq = HttpWebRequest.Create(Url)
        myReq.Method = "GET"
        myReq.ContentType = "application/json"
        myReq.Accept = "application/json"
        myReq.ContentType = "{}"
        myReq.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
        myResp = myReq.GetResponse
        myReader = New System.IO.StreamReader(myResp.GetResponseStream)
        Dim raw As String = myReader.ReadToEnd
        Dim respond As Object = JsonConvert.DeserializeObject(raw)
        Return respond
    End Function

    Public Function GetSTK(FAUF As String, DateFrom As String, DateTo As String, station As String, Durchgang As Integer) As Object

        'Filter für WATS abfrage deklarieren
        Dim Filter As New Filter
        Filter.productGroup = ""
        Filter.level = "0"
        Filter.testOperation = "600;602;603"
        Filter.batchNumber = FAUF
        Filter.MaxCount = 100000
        Filter.dateFrom = DateFrom
        Filter.dateTo = DateTo
        Filter.stationName = station
        Filter.yield = Durchgang

        'Filter in JSON String Konvertieren
        Dim jsonTxt As String = JsonConvert.SerializeObject(Filter)

        'Web API Abfrage
        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse
        Dim myReader As StreamReader
        Dim URL As String = "http://fit.sbt.siemens.com/wats/api/app/UutReport"
        myReq = HttpWebRequest.Create(URL)
        myReq.Method = "POST"
        myReq.ContentType = "application/json"
        myReq.MediaType = "jsonp"
        myReq.Accept = "application/json"
        myReq.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
        myReq.GetRequestStream.Write(Encoding.UTF8.GetBytes(jsonTxt), 0, Encoding.UTF8.GetBytes(jsonTxt).Count)
        myResp = myReq.GetResponse
        myReader = New System.IO.StreamReader(myResp.GetResponseStream)
        Dim raw As String = myReader.ReadToEnd
        'Dim respond As Object = JsonConvert.DeserializeObject(raw)
        myResp.Close()
        myReader.Close()
        'Roher Json String zurück geben
        Return raw
    End Function

    Public Function GetReportXML(ID As String) As Object
        'Web API Abfrage
        Dim myReq As HttpWebRequest
        Dim myResp As HttpWebResponse
        Dim myReader As StreamReader
        Dim URL As String = "http://fit.sbt.siemens.com/wats/api/Report/Wsxf/" & ID
        myReq = HttpWebRequest.Create(URL)
        myReq.Method = "GET"
        myReq.ContentType = "application/json"
        myReq.MediaType = "jsonp"
        myReq.Accept = "application/json"
        myReq.Headers.Add("Authorization", My.Settings.WATSAPIKEY)
        myResp = myReq.GetResponse
        myReader = New System.IO.StreamReader(myResp.GetResponseStream)
        Dim raw As String = myReader.ReadToEnd
        myResp.Close()
        myReader.Close()
        'Roher XML String zurück geben
        Return raw
    End Function

    Public Function WATS_GetSystemStatus() As Boolean
        'Dim obj As Object = WATS_GET("http://fit.sbt.siemens.com/wats/api/app/version")


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
End Class