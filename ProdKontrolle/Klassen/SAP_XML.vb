Imports System.IO
Imports System.Collections.Concurrent

Public Class SAP_XML
    Private Class CachedDataSet
        Public Property Data As DataSet
        Public Property LastWriteTimeUtc As DateTime
    End Class

    ' Gemeinsamer Cache über alle SAP_XML Instanzen im Programm hinweg (mehrere Formulare/Klassen
    ' erzeugen jeweils eigene SAP_XML Instanzen, siehe "Private SAP_XML As New SAP_XML").
    ' Verhindert, dass dieselbe FAUF-/APLA-XML Datei innerhalb einer Aktualisierung (und darüber
    ' hinaus) mehrfach von der Netzwerkfreigabe gelesen und geparst wird. Über den Datei-Zeitstempel
    ' wird sichergestellt, dass ein neuer SAP-Export automatisch neu eingelesen wird (kein veralteter
    ' Datenstand). Wird periodisch geleert, siehe ClearCache().
    Private Shared ReadOnly Cache As New ConcurrentDictionary(Of String, CachedDataSet)

    Public Function ReadXML2DT(File As String, Tabelle As String) As DataTable
        Return ReadXML2DS(File).Tables(Tabelle)
    End Function

    Public Function ReadXML2DS(File As String) As DataSet
        ' PathFAUF_XML/PathAPLA_XML geben "" zurück, wenn die Datei nicht existiert (und zeigen dazu
        ' bereits selbst eine Meldung an) - viele Aufrufer im Projekt reichen dieses Ergebnis jedoch
        ' ungeprüft weiter durch. Ohne diese Prüfung stürzte GetLastWriteTimeUtc("") mit einer
        ' ArgumentException ab. Ein leeres DataSet liefert stattdessen "keine Daten gefunden", was
        ' die meisten Aufrufer bereits über Tables.Contains(...)-Prüfungen abfangen.
        If String.IsNullOrWhiteSpace(File) Then
            Return New DataSet()
        End If

        Dim letzteAenderung As DateTime
        Try
            letzteAenderung = System.IO.File.GetLastWriteTimeUtc(File)
        Catch ex As Exception
            ' Ungültiger Pfad oder Datei kurzzeitig nicht erreichbar (z.B. Netzwerkfreigabe gerade
            ' nicht verfügbar) - nicht abstürzen, sondern wie "keine Datei vorhanden" behandeln.
            LogLesefehler(File, ex)
            Return New DataSet()
        End Try

        Dim cached As CachedDataSet = Nothing
        If Cache.TryGetValue(File, cached) AndAlso cached.LastWriteTimeUtc = letzteAenderung Then
            Return cached.Data
        End If

        Dim DS As New System.Data.DataSet()
        Try
            Using fs As New FileStream(File, FileMode.Open, FileAccess.Read, FileShare.Read)
                Using sr As New StreamReader(fs)
                    DS.ReadXml(sr)
                End Using
            End Using
        Catch ex As Exception
            ' Datei zwischen GetLastWriteTimeUtc und Open verschwunden/gesperrt (z.B. wird gerade vom
            ' SAP-Export überschrieben) oder enthält kein gültiges XML - nicht abstürzen, nicht cachen,
            ' damit ein späterer Versuch die Datei erneut liest statt am Fehler festzuhängen.
            LogLesefehler(File, ex)
            Return New DataSet()
        End Try

        Cache(File) = New CachedDataSet With {.Data = DS, .LastWriteTimeUtc = letzteAenderung}
        Return DS
    End Function

    Private Sub LogLesefehler(File As String, ex As Exception)
        Try
            Dim log As New logging
            log.WriteLog(Date.Now, "", "", "", $"SAP_XML.ReadXML2DS: Datei konnte nicht gelesen werden ('{File}'): {ex.Message}")
        Catch
        End Try
    End Sub

    ' Leert den XML Cache, z.B. beim täglichen Tageswechsel aufzurufen, damit der Speicherbedarf
    ' nicht über Tage/Wochen hinweg unbegrenzt mit jedem neu gesehenen Auftrag weiterwächst.
    Public Shared Sub ClearCache()
        Cache.Clear()
    End Sub

    Public Function PathAPLA_XML(FAUF As String, Mat As String) As String
        Dim DR As DataRow
        Dim DT As DataTable
        Dim PlanNr As String = ""

        DT = ReadXML2DT(PathFAUF_XML(FAUF), "E1AFKOL")
        For Each DR In DT.Rows
            PlanNr = DR("PLNNR")
            'Debug.WriteLine(PlanNr)
        Next

        Dim APLA_Pfad As String = "\\ch021093\data\CommonData\SAP_Download\0020\PC1\APLA\0020_" + Mat.Replace("/", "$") + "_" + PlanNr + ".xml"

        'Prüfen ob APLA XML vorhanden ist
        If My.Computer.FileSystem.FileExists(APLA_Pfad) = False Then
            MsgBox("APLA XML nicht vorhanden, Status des FAUF " & FAUF & " im SAP auf Z1?", vbCritical)
            Return Nothing
            Exit Function
        End If
        Return APLA_Pfad
    End Function


    Public Function PathFAUF_XML(FAUF As String) As String
        Dim Pfad As String = My.Settings.PfadFAUFxml & "0020_" + FAUF + ".xml"
        Dim PfadAlternative As String = My.Settings.PfadFAUFxmlAlternativ & "0020_" + FAUF + ".xml"

        If My.Computer.FileSystem.FileExists(Pfad) = False Then
            If My.Computer.FileSystem.FileExists(PfadAlternative) = True Then
                Pfad = PfadAlternative
            Else
                MsgBox("FAUF XML nicht vorhanden", vbCritical)
                Return ""
                Exit Function
            End If
        End If
        Return Pfad
    End Function
End Class
