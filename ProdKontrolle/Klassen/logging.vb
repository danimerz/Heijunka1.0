Public Class logging
    Public Async Sub WriteLog(Datum As DateTime, Linie As String, Auftrag As String, Material As String, Text As String)
        Try
            Dim Pfad As String = "C:\LocalData\HeijunkaLog.txt"
            If Not IO.Directory.Exists("C:\LocalData") Then
                My.Computer.FileSystem.CreateDirectory("C:\LocalData")
            End If
            Using fs = New IO.StreamWriter(Pfad, True)
                Await fs.WriteLineAsync(Datum.ToShortDateString & vbTab & Datum.ToLongTimeString & vbTab & Linie & vbTab & Auftrag & vbTab & Material & vbTab & Text)
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
