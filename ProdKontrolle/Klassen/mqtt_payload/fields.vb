Imports Newtonsoft.Json

Public Class fields
    Public Property incident_priority As Integer = 0
    Public Property incident_state As Integer = 0
    Public Property incident_type As Integer = 0
    Public Property incident_creator As String = String.Empty
    Public Property incident_title As String = String.Empty
    Public Property incident_description As String = String.Empty
    Public Property workorder As String = String.Empty
    <JsonProperty("material", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property material As String = String.Empty
    <JsonProperty("rs", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property rs As String = String.Empty
    <JsonProperty("fs", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property fs As String = String.Empty
    <JsonProperty("rev", NullValueHandling:=NullValueHandling.Ignore)>
    Public Property rev As String = String.Empty

End Class
