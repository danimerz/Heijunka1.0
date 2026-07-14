Imports System.Linq
Imports System.Security
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.IO

Public Class GlobaleFunktionen
    Private SAP_XML As New SAP_XML

    ' Cache für Textdateien (Werkskalender, Ausnahmelisten), die an mehreren Stellen wiederholt
    ' (teils pro Zeile in einer Schleife) komplett neu von der Netzwerkfreigabe gelesen wurden.
    ' Über den Datei-Zeitstempel validiert, damit eine geänderte Datei automatisch neu gelesen wird.
    Private Class CachedLines
        Public Property Zeilen As String()
        Public Property LastWriteTimeUtc As DateTime
    End Class
    Private Shared ReadOnly ZeilenCache As New System.Collections.Concurrent.ConcurrentDictionary(Of String, CachedLines)
    Friend Function ReadAllLinesCached(Pfad As String) As String()
        Dim letzteAenderung As DateTime = System.IO.File.GetLastWriteTimeUtc(Pfad)
        Dim cached As CachedLines = Nothing
        If ZeilenCache.TryGetValue(Pfad, cached) AndAlso cached.LastWriteTimeUtc = letzteAenderung Then
            Return cached.Zeilen
        End If
        Dim zeilen As String() = System.IO.File.ReadAllLines(Pfad)
        ZeilenCache(Pfad) = New CachedLines With {.Zeilen = zeilen, .LastWriteTimeUtc = letzteAenderung}
        Return zeilen
    End Function

    Friend Function sqlAvailable(ConStr As String) As Boolean
        Dim con As New SqlClient.SqlConnection(ConStr)
        Try
            con.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            con.Close()
        End Try
    End Function
    Friend Function GenerateDMC(inhalt As String, ModuleSize As Integer, MarginSize As Integer) As Bitmap
        Dim Encoder As New DataMatrix.net.DmtxImageEncoder
        Dim Options As New DataMatrix.net.DmtxImageEncoderOptions
        Options.ModuleSize = ModuleSize ' 5
        Options.MarginSize = MarginSize ' 10
        Options.BackColor = Color.White
        Options.ForeColor = Color.Black
        Options.Scheme = DataMatrix.net.DmtxScheme.DmtxSchemeAsciiGS1
        Dim b As Bitmap = Encoder.EncodeImage(inhalt, Options)
        Return b
    End Function

    Friend Function GetWorkingOrderHours(FAUF As String, AP As String) As Double
        Dim std As Double = 0

        Dim DS_FAUF As New DataSet()
        'FAUf XML in DS lesen
        DS_FAUF = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))

        If DS_FAUF.Tables.Contains("E1AFVOL") Then
            Dim T_DOK As DataTable = DS_FAUF.Tables("E1AFVOL")
            For Each r In T_DOK.AsEnumerable
                If Not IsDBNull(r.Item("ARBPL")) Then
                    If r.Item("ARBPL") = AP Then
                        std = r.Item("BEARZ") / 60
                    End If
                End If
            Next
        End If
        Return std
    End Function

    Friend Function GetFaufQty(FAUFPath As String) As Integer
        Dim qty As Integer = 0
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUFPath)

        If DS_Fauf.Tables.Contains("E1AFKOL") Then
            Dim Daten As DataTable = DS_Fauf.Tables("E1AFKOL")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("BMENGE")) Then
                    qty = r.Item("BMENGE")
                End If
            Next
        End If
        Return qty
    End Function

    Friend Function GetEndDateFauf(FAUFPath As String) As Date
        Dim EndDate As Date
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUFPath)

        If DS_Fauf.Tables.Contains("E1AFKOL") Then
            Dim Daten As DataTable = DS_Fauf.Tables("E1AFKOL")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("GLTRP")) Then
                    EndDate = DateTime.ParseExact(r.Item("GLTRP"), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                End If
            Next
        End If
        Return EndDate
    End Function

    Friend Function GetEndDateVrg(FAUFPath As String, Vorgang As String) As Date
        Dim EndDate As Date
        Dim DS_FAUF As New DataSet

        DS_FAUF = SAP_XML.ReadXML2DS(FAUFPath)
        If DS_FAUF.Tables.Contains("E1AFVOL") Then
            Dim Daten As DataTable = DS_FAUF.Tables("E1AFVOL")
            For Each r In Daten.AsEnumerable
                If r.Item("Vornr") = Vorgang Then
                    EndDate = DateTime.ParseExact(r.Item("SSAVD"), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo)
                    Exit For
                End If
            Next
        End If


        Return EndDate
    End Function

    ''' <summary>
    ''' tbl_FAUF_Status.ProdDatum ist in der Datenbank als VARCHAR gespeichert (nicht als Date) und
    ''' wird beim Schreiben teils kulturabhängig formatiert (z.B. Now.ToShortDateString). Auf Clients
    ''' mit anderer Kultur als die schreibende Instanz (z.B. en-US "7/13/2026" statt de-DE "13.07.2026")
    ''' wirft eine direkte CDate-Konvertierung eine InvalidCastException und reisst den kompletten
    ''' UI-Thread ab (BGW_Hejiunka_RunWorkerCompleted). Deshalb hier tolerant mit mehreren Formaten/
    ''' Kulturen parsen statt eine implizite VB-Konvertierung zu verwenden.
    ''' </summary>
    Friend Function ParseProdDatum(Wert As Object) As Date
        If Wert Is Nothing OrElse IsDBNull(Wert) Then
            Return Date.Now
        End If

        If TypeOf Wert Is Date Then
            Return DirectCast(Wert, Date)
        End If

        Dim Text As String = Wert.ToString().Trim()
        If Text = "" Then
            Return Date.Now
        End If

        Dim Ergebnis As Date
        If Date.TryParse(Text, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, Ergebnis) Then
            Return Ergebnis
        End If
        If Date.TryParse(Text, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, Ergebnis) Then
            Return Ergebnis
        End If

        Dim BekannteFormate() As String = {"yyyy-MM-dd", "M/d/yyyy", "d.M.yyyy", "dd.MM.yyyy"}
        If Date.TryParseExact(Text, BekannteFormate, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, Ergebnis) Then
            Return Ergebnis
        End If

        Dim log As New logging
        log.WriteLog(Date.Now, "", "", "", $"ParseProdDatum: Konnte '{Text}' nicht in Date konvertieren, verwende Now als Fallback")
        Return Date.Now
    End Function

    Friend Function GetReportedBackQuantity(FAUFPath As String) As Integer
        Dim gutmenge As Integer = 0
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUFPath)

        If DS_Fauf.Tables.Contains("E1AFKOL") Then
            Dim Daten As DataTable = DS_Fauf.Tables("E1AFKOL")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("IGMNG")) Then
                    gutmenge = r.Item("IGMNG")
                End If
            Next
        End If

        Return gutmenge
    End Function

    Friend Function GetReportedFailQuantity(FAUFPath As String) As Integer
        Dim failmenge As Integer = 0
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUFPath)

        If DS_Fauf.Tables.Contains("E1AFKOL") Then
            Dim Daten As DataTable = DS_Fauf.Tables("E1AFKOL")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("IASMG")) Then
                    failmenge = r.Item("IASMG")
                End If
            Next
        End If

        Return failmenge
    End Function

    Friend Function GetReportedBackQuantityTRUC(FAUFPath As String, Arbeitsplatz As String, vorgang As String) As Integer
        Dim gutmenge As Integer = 0
        Dim schlechtmenge As Integer = 0
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUFPath)
        If DS_Fauf.Tables.Contains("E1AFVOL") Then
            Dim Daten As DataTable = DS_Fauf.Tables("E1AFVOL")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("ARBPL")) Then
                    If r.Item("ARBPL") = Arbeitsplatz And r.Item("VORNR") = vorgang Then
                        gutmenge = r.Item("LMNGA")
                        schlechtmenge = 0 'FELD für Mindermenge finden
                    End If
                End If
            Next
        End If

        Return gutmenge + schlechtmenge
    End Function

    Friend Function GetMatStatus(ByVal FAUF As String, ByVal Mat As String) As String
        Dim DS As New System.Data.DataSet()
        Dim MatStatus As String = ""
        Dim APLA_Pfad As String = SAP_XML.PathAPLA_XML(FAUF, Mat)
        'Gibt die Funktion PathAPLA_XML Nothing zurück? Status im SAP evtl. auf Z1
        If APLA_Pfad = Nothing Then
            MatStatus = "Z1"
            Return MatStatus
        End If

        DS = SAP_XML.ReadXML2DS(APLA_Pfad)
        Dim MARX As DataTable = DS.Tables("ZE1_DMSOP_MARX")

        'MARX kann fehlen, wenn die APLA-XML gerade nicht lesbar war (ReadXML2DS liefert dann ein
        'leeres DataSet) oder die Tabelle in einer sonst gültigen XML einfach nicht enthalten ist.
        If Not IsNothing(MARX) Then
            For Each Row As DataRow In MARX.AsEnumerable
                MatStatus = (Row("MMSTA"))
            Next
        End If
        Return MatStatus
    End Function

    Friend Function GetArtikelNameByArtNr(ByVal FAUF As String, ByVal Mat As String, ByVal Artikelnummer As String) As String
        Dim DS As New System.Data.DataSet()
        Dim ArtikelName As String = ""
        Dim APLA_Pfad As String = SAP_XML.PathAPLA_XML(FAUF, Mat)
        If APLA_Pfad = Nothing Then
            Return ArtikelName
        End If

        DS = SAP_XML.ReadXML2DS(APLA_Pfad)
        Dim StuliPos As DataTable = DS.Tables("ZE1_DMSOP_STPO")

        If Not IsNothing(StuliPos) Then
            For Each Row As DataRow In StuliPos.AsEnumerable
                If Not IsDBNull(Row("IDNRK")) Then
                    If Row("IDNRK") = Artikelnummer Then
                        ArtikelName = (Row("KTEXT"))
                        Exit For
                    End If
                End If
            Next
        End If
        Return ArtikelName
    End Function

    Friend Function ChkList(ByVal Material As String) As Boolean
        Dim Mat = Material.Replace("/", "_")
        Dim Pfad As String = My.Settings.ChecklistePfad & Mat & "\"

        If IO.Directory.Exists(Pfad) Then
            For Each items As String In IO.Directory.GetFiles(Pfad)
                If IO.Path.GetExtension(items) = ".pdf" Then
                    If InStr(items, Mat) Then
                        Pfad = items
                    End If
                End If
            Next
        End If

        If My.Computer.FileSystem.FileExists(Pfad) Then
            Process.Start(Pfad)
            Return True
        Else
            Return False
        End If
    End Function

    Friend Function PlayVideo(Material As String) As Boolean
        Dim Pfad As String = My.Settings.LernVideoPfad & Material & ".mp4"

        If IO.File.Exists(Pfad) Then
            Process.Start(Pfad)
            Return True
        Else
            Return False
        End If
    End Function

    Friend Sub GetPcbPicture(lpnr As String)
        Dim Pfad As String = "\\ch021093\Data\Standards\Laser_SMD\AsysLaser_Prog\ALS_Programmablage\ASYS_Neu\NewAsysXMLBase\Global\Images\"

        If Directory.Exists(Pfad) Then
            Dim files As String() = Directory.GetFiles(Pfad, "*.png", SearchOption.AllDirectories)

            For Each file In files
                Dim fileName As String = Path.GetFileName(file)
                If fileName.Contains(lpnr) AndAlso fileName.Contains("_1_LD") Then
                    'Return file
                    Process.Start(file)
                End If
            Next
        End If

    End Sub

    Friend Function GetStringValue(value As Object) As String
        If value Is Nothing Or IsDBNull(value) Then
            Return "-"
        End If
        Return DirectCast(value, String)
    End Function

    Friend Function MatInAusnahmeliste(ByVal Material As String) As Boolean
        'Vcheck TextFile auslesen und durchsuchen
        Dim Pfad As String = My.Settings.ausnahmelistePfad
        Dim Lines() As String = ReadAllLinesCached(Pfad)
        Dim MaterialIstVorhanden As Boolean = False
        'Text Datei nach Materialnummer durchsuchen
        For Each l As String In Lines
            If l = Material Then
                MaterialIstVorhanden = True
            End If
        Next
        Return MaterialIstVorhanden
    End Function

    Friend Function GetSAPVersion() As String
        Return System.IO.File.GetLastWriteTime(My.Settings.ExportPfadRemote)
    End Function

    Friend Function GetFormTitle(Optional zusatz As String = "") As String
        'Titel Text zurückgeben
        Return "Digitales Heijunka - " & My.Settings.Linie & " - " & GetSwVersion() & " - SAP Daten: " & GetSAPVersion() & " " & zusatz
    End Function

    Friend Function GetSwVersion() As String
        If Deployment.Application.ApplicationDeployment.IsNetworkDeployed Then
            Dim version As System.Version = Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion()
            Return version.ToString
        Else
            Return My.Settings.SoftwareVersion
        End If
    End Function

    Friend Function GetStuecklisteFromSAPXML(Material As String, FAUF As String) As IEnumerable
        ' / zeichen durch $ zeichen ersetzten, APLA XML!
        Try
            Dim Mat As String = Material.Replace("/", "$")

            Dim DS_APLA As New System.Data.DataSet()
            Dim DS_FAUF As New System.Data.DataSet()

            Dim APLA_Pfad As String = SAP_XML.PathAPLA_XML(FAUF, Mat)
            Dim FAUF_Pfad As String = SAP_XML.PathFAUF_XML(FAUF)

            DS_APLA = SAP_XML.ReadXML2DS(APLA_Pfad)
            DS_FAUF = SAP_XML.ReadXML2DS(FAUF_Pfad)

            'Wie Weiter??? Stüli aus FAUF 
            Dim stuliFAUF As DataTable = DS_FAUF.Tables("E1RESBL")
            Dim stuli As DataTable = DS_APLA.Tables("E1PLMZL")
            Dim stulidetail As DataTable = DS_APLA.Tables("ZE1_DMSOP_STPO")
            Dim APLA_Vrg As DataTable = DS_APLA.Tables("E1PLPOL")
            Dim APLA_Vrg_Text As DataTable = DS_APLA.Tables("ZE1_DMSOP_PLPO")
            Dim Pos_Text As String = ""

            'Fehlt eine dieser Tabellen (z.B. XML gerade nicht lesbar), würde der Join weiter unten
            'mit einer NullReferenceException abstürzen - und zwar erst beim Aufrufer (GetMatNrByText
            'iteriert über das Ergebnis), da diese Funktion sonst stillschweigend Nothing zurückgäbe.
            If IsNothing(stuliFAUF) OrElse IsNothing(stuli) OrElse IsNothing(stulidetail) OrElse
               IsNothing(APLA_Vrg) OrElse IsNothing(APLA_Vrg_Text) Then
                Return Enumerable.Empty(Of Object)()
            End If

            Dim query =
            From stulisFaufs In stuliFAUF.AsEnumerable()
            Join stulis In stuli.AsEnumerable()
            On stulisFaufs.Field(Of String)("MATNR") Equals
                    If(IsNumeric(stulis.Field(Of String)("IDNRK")), FormatNumber(stulis.Field(Of String)("IDNRK"), 0, 0, , 0), stulis.Field(Of String)("IDNRK"))
            Join stulidetails In stulidetail.AsEnumerable()
            On stulis.Field(Of Integer)("E1PLMZL_id") Equals
                    stulidetails.Field(Of Integer)("E1PLMZL_id")
            Join A_vrg In APLA_Vrg.AsEnumerable()
            On stulis.Field(Of Integer)("E1PLPOL_Id") Equals
                    A_vrg.Field(Of Integer)("E1PLPOL_Id")
            Join A_vrg_text In APLA_Vrg_Text.AsEnumerable()
            On A_vrg.Field(Of Integer)("E1PLPOL_Id") Equals
                    A_vrg_text.Field(Of Integer)("E1PLPOL_Id")
            Where stulidetails.Field(Of String)("DATUB") >= Now.ToString("yyyyMMdd") And stulidetails.Field(Of String)("DATUV") <= Now.ToString("yyyyMMdd") And stulidetails.Field(Of String)("SANFE") = "X"
            Order By A_vrg.Field(Of String)("VORNR"), stulis.Field(Of String)("IDNRK")
            Select New With
            {
                .Material = stulisFaufs.Field(Of String)("MATNR"),
                .KT = stulidetails.Field(Of String)("KTEXT"),
                .LO = If(stulidetail.Columns.Contains("LGPBE"), stulidetails.Field(Of String)("LGPBE"), "n/a"), 'Prüfen ob das Feld LGPBE vorkommt
                .PLO = stulidetails.Field(Of String)("LGORT"),
                .STK = stulidetails.Field(Of String)("MENGE"),
                .einheit = stulidetails.Field(Of String)("MEINS"),
                .vrg = A_vrg.Field(Of String)("VORNR"),
                .vrg_text = A_vrg_text.Field(Of String)("KTEXT"),
                .pos = stulidetails.Field(Of String)("POSTP"),
                .Pos_Text = If(stulidetails.Field(Of String)("POSTP") = "T", stulidetails.Field(Of String)("POTX1"), stulidetails.Field(Of String)("KTEXT")) 'Prüfen ob eine Text position in der Stückliste vorhanden ist, Wenn ja, Wird der Text aus dem feld POTX1 gezogen, ansonsten aus dem Feld KTEXT
            }

            Return query
        Catch ex As Exception
            'MsgBox("Es ist ein Fehler beim laden der Stückliste aufgetreten!" & vbCrLf & vbCrLf & ex.Message, "Fehler", vbCritical)
            Return Enumerable.Empty(Of Object)()
        End Try
    End Function

    Friend Function GetMatNrByText(Material As String, FAUF As String, MatText As String) As String
        Dim MatNr As String = ""
        For Each item In GetStuecklisteFromSAPXML(Material, FAUF)
            If CStr(InStr(item.Pos_Text, MatText, vbTextCompare)) Then
                If item.pos = "T" Then
                    If CStr(InStr(item.Pos_Text, "GearBox", vbTextCompare)) Then ' Für CEVA Gearbox die als Text Pos in Stüli ist
                        Dim text() As String = Split(item.pos_Text, "/")
                        MatNr = text(0)
                        Exit For
                    End If
                Else
                    MatNr = item.Material
                    Exit For
                End If
            End If
        Next
        Return MatNr
    End Function

    Friend Function GetCEVA_GearBoxNr(FAUF As String) As String
        'Funktion sucht aus dem FAUF XML in den Dokumenten nach dem Text Gearbox und gibt eine formatierte Artikelnummer zurück
        Dim ArtNr As String = ""
        Dim DS_FAUF As New System.Data.DataSet()
        Dim FAUF_Pfad As String = SAP_XML.PathFAUF_XML(FAUF)
        DS_FAUF = SAP_XML.ReadXML2DS(FAUF_Pfad)

        Dim dt_dok As DataTable = DS_FAUF.Tables("ZE1_DMSOP_AFFH")

        If Not IsNothing(dt_dok) Then
            Dim query = From dok In dt_dok.AsEnumerable
                        Where dok.Field(Of String)("TEXT").Contains("GearBox")

            For Each item In query
                ArtNr = item.Field(Of String)("DOKNR")
            Next
        End If

        If ArtNr = "" Or IsNothing(ArtNr) Then
            ArtNr = ""
        Else
            If ArtNr Like "*[a-zA-Z]*" Then
                ArtNr = ArtNr
            Else
                ArtNr = FormatNumber(ArtNr, 0, 0, , 0)
            End If
        End If


        Return ArtNr
    End Function

    Friend Function GetCEVA_GearBoxNr_TC3(FAUF As String) As String
        Dim tcDok As TC3Dok
        Dim ArtikelNummer As String = ""
        tcDok = GetTC3Dok(FAUF)
        If tcDok.DokNummer = Nothing Then
            'MsgBox("Kein TC3 Dok vorhanden", vbCritical, "Fehler")
            Return ArtikelNummer
            Exit Function
        End If

        Dim Dokversion As String = ""
        If Len(tcDok.DokVersion) = 2 Then
            Dokversion = "0" & tcDok.DokVersion
        Else
            Dokversion = tcDok.DokVersion
        End If

        Dim Pfad As String = My.Settings.PfadTCAblage & tcDok.DokNummer & "\" & Dokversion

        For Each Item As String In IO.Directory.GetDirectories(Pfad)
            Dim OrdnerPfad As New IO.DirectoryInfo(Item)
            Dim OrdnerName As String = OrdnerPfad.Name
            If InStr(OrdnerName, "GearBox") Then
                Dim ArtNr() As String = Split(OrdnerName, "_")
                ArtikelNummer = ArtNr(0)
            End If
        Next
        Return ArtikelNummer
    End Function

    Friend Function GetTC3Dok(FAUF As String) As TC3Dok
        Dim TC3 As New TC3Dok
        Try
            Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
            Dim DT As DataTable = DS_FAUF.Tables("ZE1_DMSOP_DOKV")

            For Each item In DT.AsEnumerable
                If item.Field(Of String)("DOKAR") = "TC3" Then
                    TC3.DokNummer = item.Field(Of String)("DOKNR")
                    TC3.DokVersion = item.Field(Of String)("DOKVR")
                    TC3.DokArt = item.Field(Of String)("DOKAR")
                End If
            Next
        Catch ex As Exception
        End Try

        Return TC3

    End Function

    Friend Function GetTC2Dok(FAUF As String) As TC2Dok
        Dim TC2 As New TC2Dok
        Try
            Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
            Dim DT As DataTable = DS_FAUF.Tables("ZE1_DMSOP_DOKV")

            For Each item In DT.AsEnumerable
                If item.Field(Of String)("DOKAR") = "TC2" Then
                    TC2.DokNummer = item.Field(Of String)("DOKNR")
                    TC2.DokVersion = item.Field(Of String)("DOKVR")
                    TC2.DokArt = item.Field(Of String)("DOKAR")
                End If
            Next
        Catch ex As Exception
        End Try

        Return TC2

    End Function

    Friend Function GetFS(FAUF As String) As String
        Dim tcDok As TC2Dok
        tcDok = GetTC2Dok(FAUF)
        If tcDok.DokNummer = Nothing Then
            'MsgBox("Kein TC2 Dok vorhanden", vbCritical, "Fehler")
            Return ""
            Exit Function
        End If
        Return tcDok.DokVersion
    End Function

    Friend Function GetDateFrom_FAUF(FAUF As String) As String
        Dim DateFrom As String = ""
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("E1AFKOL")
        If Not IsNothing(DT) Then
            For Each row In DT.AsEnumerable
                DateFrom = DateTime.ParseExact(row.Field(Of String)("GSTRP"), "yyyyMMdd", Nothing).ToShortDateString
            Next
        End If
        Return DateFrom
    End Function

    Friend Function GetDateTo_FAUF(FAUF As String) As String
        Dim DateTo As String = ""
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("E1AFKOL")
        If Not IsNothing(DT) Then
            For Each row In DT.AsEnumerable
                DateTo = DateTime.ParseExact(row.Field(Of String)("GLTRP"), "yyyyMMdd", Nothing).ToShortDateString
            Next
        End If
        Return DateTo
    End Function

    Friend Sub SetProtocol(Auftrag As String, Arbeitspaltz As String, Kategorie As String, Ereignis As String)
        Dim tbl_Adapter As New DS_ProdKontrolleTableAdapters.tbl_ProtkollTableAdapter
        tbl_Adapter.Insert(Date.Now, Date.Now.TimeOfDay, Auftrag, Arbeitspaltz, Ereignis, Kategorie)
    End Sub

    Friend Function GetStndWDok(FAUF As String) As String
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("ZE1_DMSOP_AFFH")
        Dim StndWNr As String = ""

        If Not IsNothing(DT) Then
            For Each item In DT.AsEnumerable
                If InStr(item.Field(Of String)("TEXT"), "Standard") Then
                    StndWNr = item.Field(Of String)("DOKNR")
                End If
            Next
        End If

        Dim Pfad As String = My.Settings.Pfad_StndW & StndWNr & "\" & StndWNr & ".pdf"

        If My.Computer.FileSystem.FileExists(Pfad) Then
            Return Pfad
        Else
            Return "False"
        End If
    End Function

    Friend Function GetDokumente(FAUF As String) As DataTable
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT_FAUF As DataTable = DS_FAUF.Tables("ZE1_DMSOP_AFFH")
        Dim List As New List(Of String)

        'Übergabe Datatable Definieren
        Dim DT_Dok As New DataTable
        Dim Column As DataColumn
        Dim row As DataRow

#Region "Spalten"
        'Spalte DokNr
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "DokNr"
        DT_Dok.Columns.Add(Column)

        'Spalte DokText
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "DokText"
        DT_Dok.Columns.Add(Column)

        'Spalte DokVersion
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "DokVersion"
        DT_Dok.Columns.Add(Column)

        'Spalte FHMArt
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "FHMArt"
        DT_Dok.Columns.Add(Column)

        'Spalte DokArt
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "DokArt"
        DT_Dok.Columns.Add(Column)

        'Spalte Link
        Column = New DataColumn()
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Link"
        DT_Dok.Columns.Add(Column)
#End Region

        If Not IsNothing(DT_FAUF) Then
            For Each item In DT_FAUF.AsEnumerable
                If item.Field(Of String)("FHMAR") = "D" Then
                    row = DT_Dok.NewRow()
                    row("DokNr") = item.Field(Of String)("DOKNR")
                    row("DokText") = item.Field(Of String)("TEXT")
                    row("DokVersion") = item.Field(Of String)("DOKVR")
                    row("FHMArt") = item.Field(Of String)("FHMAR")
                    row("DokArt") = item.Field(Of String)("DOKAR")


                    'Pfade suchen

                    Dim Pfad As String = ""
                    Select Case True
                        Case InStr(item.Field(Of String)("TEXT"), "Standard")
                            Pfad = My.Settings.Pfad_StndW & item.Field(Of String)("DOKNR") & "\" & item.Field(Of String)("DOKNR") & ".pdf"
                        Case InStr(item.Field(Of String)("TEXT"), "PA")
                            Pfad = My.Settings.Pfad_PA & item.Field(Of String)("TEXT") & "\" & item.Field(Of String)("TEXT") & ".pdf"
                        Case InStr(item.Field(Of String)("DOKNR"), "V4")
                            Pfad = My.Settings.Pfad_V4 & item.Field(Of String)("DOKNR") & "\" & item.Field(Of String)("DOKNR") & ".pdf"
                    End Select


                    If My.Computer.FileSystem.FileExists(Pfad) Then
                        row("Link") = Pfad
                    Else
                        row("Link") = "nothing"
                    End If
                    DT_Dok.Rows.Add(row)
                End If
            Next
        End If
        Return DT_Dok
    End Function

    Friend Function GetLagerort(FAUF As String, Material As String) As String
        Dim DS_FAUF As New DataSet
        Dim Lagerort As String = ""
        Dim FAUF_Pfad As String = SAP_XML.PathFAUF_XML(FAUF)


        Dim Pfad As String = My.Settings.LagerOrt_Ausnahmen
        Dim Lines() As String = ReadAllLinesCached(Pfad)
        'Text Datei nach Materialnummer durchsuchen
        For Each l As String In Lines
            Dim split() As String = l.Split("=")
            If split(0) = Material Then
                Return split(1)
                Exit For
            End If
        Next

        If FAUF_Pfad = Nothing Then
            Lagerort = "Z1"
            Return Lagerort
        End If

        DS_FAUF = SAP_XML.ReadXML2DS(FAUF_Pfad)

        If DS_FAUF.Tables.Contains("E1AFPOL") Then
            Dim T_DOK As DataTable = DS_FAUF.Tables("E1AFPOL")
            If T_DOK.Columns.Contains("LGORT") Then
                For Each d In T_DOK.AsEnumerable
                    Lagerort = d.Item("LGORT")
                Next
            End If
        End If
        Return Lagerort
    End Function

    ''' <summary>
    ''' Liefert nur die Rückmelde-Status-Zeilen des angegebenen Auftrags statt (wie
    ''' Tbl_Rueckmelden_StatusTableAdapter.GetData) der kompletten, ungefilterten Tabelle - die
    ''' wächst über die Zeit mit jedem je gebuchten Behälter aller Aufträge und macht den
    ''' Rückmelden-Dialog dadurch langsam, weil sie synchron im UI-Thread geladen wird.
    ''' </summary>
    Friend Function GetRueckmeldenStatusByFAUF(FAUF As String) As DataTable
        Dim query As String = "SELECT RuckCode, Status FROM dbo.tbl_Rueckmelden_Status WHERE FAUF = @FAUF"
        Dim result As New DataTable()

        Using connection As New SqlConnection(My.Settings.HeijunkaConnectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@FAUF", FAUF)
                Using adapter As New SqlClient.SqlDataAdapter(command)
                    adapter.Fill(result)
                End Using
            End Using
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Liefert nur die offenen Produktionskontrolle-Einträge des angegebenen Auftrags/Vorgangs statt
    ''' (wie Tbl_ProdKontrolleTableAdapter.GetData) der kompletten, ungefilterten Tabelle, die erst
    ''' clientseitig gefiltert wurde - dieselbe Problemklasse wie bei tbl_FAUF_Status/
    ''' tbl_Rueckmelden_Status, hier beim Auftragsstart/Abschliessen einer Produktionskontrolle.
    ''' Liefert eine typisierte tbl_ProdKontrolleDataTable, damit die Zeilen wie bisher als
    ''' tbl_ProdKontrolleRow verwendet werden können.
    ''' </summary>
    Friend Function GetOffeneProdKontrolleByFAUF(FAUF As String, Vrg As String) As DS_ProdKontrolle.tbl_ProdKontrolleDataTable
        Dim query As String = "SELECT ID, Datum, Linie, Material, FAUF, Soll, Ist, Status, Grund, Zusatz, Vrg FROM dbo.tbl_ProdKontrolle WHERE FAUF = @FAUF AND Vrg = @Vrg AND Status = 'offen' ORDER BY Datum"
        Dim result As New DS_ProdKontrolle.tbl_ProdKontrolleDataTable()

        Using connection As New SqlConnection(My.Settings.HeijunkaConnectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@FAUF", FAUF)
                command.Parameters.AddWithValue("@Vrg", Vrg)
                Using adapter As New SqlClient.SqlDataAdapter(command)
                    adapter.Fill(result)
                End Using
            End Using
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Wie GetOffeneProdKontrolleByFAUF, aber ohne Status-Filter (für die Detailansicht, die auch
    ''' bereits erledigte Einträge zu einem Auftrag/Vorgang anzeigen soll).
    ''' </summary>
    Friend Function GetProdKontrolleByFAUF(FAUF As String, Vrg As String) As DS_ProdKontrolle.tbl_ProdKontrolleDataTable
        Dim query As String = "SELECT ID, Datum, Linie, Material, FAUF, Soll, Ist, Status, Grund, Zusatz, Vrg FROM dbo.tbl_ProdKontrolle WHERE FAUF = @FAUF AND Vrg = @Vrg ORDER BY Datum"
        Dim result As New DS_ProdKontrolle.tbl_ProdKontrolleDataTable()

        Using connection As New SqlConnection(My.Settings.HeijunkaConnectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@FAUF", FAUF)
                command.Parameters.AddWithValue("@Vrg", Vrg)
                Using adapter As New SqlClient.SqlDataAdapter(command)
                    adapter.Fill(result)
                End Using
            End Using
        End Using

        Return result
    End Function

    ''' <summary>
    ''' Liefert nur die Kommentar-Zeilen des angegebenen Auftrags statt (wie
    ''' tbl_KommentarTableAdapter.GetData) der kompletten, ungefilterten Tabelle - wird u.a. bei
    ''' jedem Klick auf eine farblich markierte Zeile im Heijunka-Grid aufgerufen.
    ''' </summary>
    Friend Function GetKommentarByFAUF(FAUF As String) As DS_ProdKontrolle.tbl_KommentarDataTable
        Dim query As String = "SELECT ID, FAUF, Kommentar, Datum FROM dbo.tbl_Kommentar WHERE FAUF = @FAUF"
        Dim result As New DS_ProdKontrolle.tbl_KommentarDataTable()

        Using connection As New SqlConnection(My.Settings.HeijunkaConnectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@FAUF", FAUF)
                Using adapter As New SqlClient.SqlDataAdapter(command)
                    adapter.Fill(result)
                End Using
            End Using
        End Using

        Return result
    End Function

    Friend Sub WriteFaufInitToDb(Linie As String, CurrentOrder As String)
        Dim connectionString As String = "Data Source=ch021094.ad001.siemens.net;Initial Catalog=OPM_OEE;User ID=OPM_OEE_User;Password=Montage@6301"
        Dim queryCheckExistence As String = "SELECT COUNT(*) FROM T_LinieAuftragAktuell WHERE Line = @Linie"
        Dim queryInsert As String = "INSERT INTO T_LinieAuftragAktuell (Line, CurrentOrder, StartDT) VALUES (@Linie, @CurrentOrder, @StartDT)"
        Dim queryUpdate As String = "UPDATE T_LinieAuftragAktuell SET CurrentOrder = @CurrentOrder, StartDT = @StartDT WHERE Line = @Linie"

        Using connection As New SqlConnection(connectionString)
            Using commandCheckExistence As New SqlCommand(queryCheckExistence, connection)
                commandCheckExistence.Parameters.AddWithValue("@Linie", Linie)
                connection.Open()
                Dim count As Integer = CInt(commandCheckExistence.ExecuteScalar())

                If count > 0 Then ' Datensatz vorhanden, aktualisieren
                    Using commandUpdate As New SqlCommand(queryUpdate, connection)
                        commandUpdate.Parameters.AddWithValue("@Linie", Linie)
                        commandUpdate.Parameters.AddWithValue("@CurrentOrder", CurrentOrder)
                        commandUpdate.Parameters.AddWithValue("@StartDT", Date.Now)
                        commandUpdate.ExecuteNonQuery()
                    End Using
                Else ' Datensatz nicht vorhanden, neu erstellen
                    Using commandInsert As New SqlCommand(queryInsert, connection)
                        commandInsert.Parameters.AddWithValue("@Linie", Linie)
                        commandInsert.Parameters.AddWithValue("@CurrentOrder", CurrentOrder)
                        commandInsert.Parameters.AddWithValue("@StartDT", Date.Now)
                        commandInsert.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using
    End Sub

    'Friend Function GetSmtMagStk(Material As String, Auftrag As String) As String
    '    ' Constante & Variablen
    '    Const hub10 As Integer = 50
    '    Const hub20 As Integer = 25
    '    Const hub30 As Integer = 17
    '    Dim AnzMagazine As Integer = 0 ' equal to Anzahl Etiketten

    '    ' Auftragsstückzahl lesen
    '    Dim FaufPfad As String = SAP_XML.PathFAUF_XML(Auftrag)
    '    Dim AuftragsStückzahl As Integer = GetFaufQty(FaufPfad)

    '    'SMT Hub und Nutzen lesen
    '    Dim SmtTablAdapter As New ProgrammübersichtDataSetTableAdapters.tbl_StammTableAdapter

    '    Dim qrySMTstamm = From rw In SmtTablAdapter.GetData
    '                      Where Material = GetStringValue(rw("Mat_SAP"))

    '    Dim pcbaProNutzen As Integer
    '    Dim Hub As Integer

    '    For Each stamm In qrySMTstamm
    '        'Abfrage ob es da es sich nicht um Prototyp handelt
    '        If Not GetStringValue(stamm("ID_Material")) = "-" Then
    '            pcbaProNutzen = Convert.ToInt64(stamm("Anz LP/NU"))
    '            If IsDBNull(stamm("Hub_VG2")) Or stamm("Hub_VG2") = "" Then
    '                Hub = Convert.ToInt64(stamm("Hub_VG1"))
    '            Else
    '                Hub = Convert.ToInt64(stamm("Hub_VG2"))
    '            End If
    '        End If
    '    Next


    '    Select Case Hub
    '        Case 10
    '            AnzMagazine = AuftragsStückzahl / pcbaProNutzen / hub10
    '        Case 20
    '            AnzMagazine = AuftragsStückzahl / pcbaProNutzen / hub20
    '        Case 30
    '            AnzMagazine = AuftragsStückzahl / pcbaProNutzen / hub30
    '    End Select


    '    Return "Nutzen: " & pcbaProNutzen & " Hub: " & Hub & " Anzahl Magazine: " & AnzMagazine
    'End Function

    Friend Function GetAuftragZeiten(Auftrag As String) As VorgabeZeiten
        Dim DS_FAUF As New DataSet
        Dim vorgabeZeiten As New VorgabeZeiten
        Dim FAUF_Pfad As String = SAP_XML.PathFAUF_XML(Auftrag)

        Dim Personalzeit As Double = 0
        Dim RuestenPersonal As Double = 0
        Dim Maschinenzeit As Double = 0
        Dim RuestenMaschine As Double = 0

        Dim SNP As Boolean = False

        DS_FAUF = SAP_XML.ReadXML2DS(FAUF_Pfad)

        If DS_FAUF.Tables.Contains("E1AFVOL") Then
            Dim Vrg As DataTable = DS_FAUF.Tables("E1AFVOL")

            For Each vorgang In Vrg.AsEnumerable
                If Vrg.Columns.Contains("VGW01") Then
                    RuestenMaschine += Convert.ToDouble(vorgang.Item("VGW01"))
                End If
                If Vrg.Columns.Contains("VGW02") Then
                    If Vrg.Columns.Contains("LTXA1") Then
                        If Not IsDBNull(vorgang.Item("LTXA1")) Then
                            If vorgang.Item("LTXA1").ToString.ToLower.Contains("snp") OrElse vorgang.Item("LTXA1").ToString.ToLower.Contains("engpas") Then
                                SNP = True
                            End If
                        End If
                    End If
                    If SNP = True Then
                        Maschinenzeit += 0
                    Else
                        Maschinenzeit += Convert.ToDouble(vorgang.Item("VGW02"))
                    End If
                End If
                If Vrg.Columns.Contains("VGW03") Then
                    Personalzeit += Convert.ToDouble(vorgang.Item("VGW03"))
                End If
                If Vrg.Columns.Contains("VGW04") Then
                    RuestenPersonal += Convert.ToDouble(vorgang.Item("VGW04"))
                End If
            Next
        End If

        Dim losgroesse As Integer = GetFaufQty(FAUF_Pfad)

        vorgabeZeiten.Personalzeit = Personalzeit / 100 * losgroesse
        vorgabeZeiten.RuestenPersonal = RuestenPersonal
        vorgabeZeiten.Maschinenzeit = Maschinenzeit / 100 * losgroesse
        vorgabeZeiten.RuestenMaschine = RuestenMaschine

        Return vorgabeZeiten

    End Function

    Friend Sub sendMail(Betreff As String, Text As String)

        Dim client As New SmtpClient
        Dim FromMailAdesse As String = "technicalservices-fz.ch@siemens.com"
        client.Port = 25
        client.Host = "smtp.siemens.com"
        client.UseDefaultCredentials = False
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12

        Dim creds As New System.Net.NetworkCredential
        creds.UserName = My.Settings.emailUsername
        creds.SecurePassword = CredentialsPassword(My.Settings.emailPassword)
        client.Credentials = creds
        client.EnableSsl = True

        Dim Mail As New MailMessage
        Dim fromMailAdr As New MailAddress(FromMailAdesse)

        Mail.From = fromMailAdr

        Mail.Subject = Betreff
        Mail.Body = Text
        Mail.To.Add(My.Settings.SupportEmail)

        client.Send(Mail)


    End Sub

    Private Function CredentialsPassword(pwd As String) As SecureString
        Dim Passwort As New SecureString
        For Each c As Char In pwd
            Passwort.AppendChar(c)
        Next
        Passwort.MakeReadOnly()
        Return Passwort
    End Function

    Friend Function GetIctAdapter(FAUF As String) As String
        Dim FAUF_Pfad As String = SAP_XML.PathFAUF_XML(FAUF)
        Dim Adapternummer As String = String.Empty
        Dim DS_Fauf As New DataSet
        'FAUf XML in DS lesen
        DS_Fauf = SAP_XML.ReadXML2DS(FAUF_Pfad)

        If DS_Fauf.Tables.Contains("ZE1_DMSOP_TEXT") Then
            Dim Daten As DataTable = DS_Fauf.Tables("ZE1_DMSOP_TEXT")
            For Each r In Daten.AsEnumerable
                If Not IsDBNull(r.Item("AVTXT")) Then
                    Select Case True
                        Case InStr(r.Item("AVTXT"), "Adapter:")
                            Adapternummer = r.Item("AVTXT")
                            Exit For
                        Case InStr(r.Item("AVTXT"), "Nr")
                            Adapternummer = r.Item("AVTXT")
                            Exit For
                        Case Else
                            Adapternummer = "empty"
                    End Select
                End If
            Next
        End If

        Return Adapternummer
    End Function

    Friend Function GetAnwStatusUMTE(FAUF As String) As String
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("E1JSTKL")
        If Not IsNothing(DT) Then
            For Each row In DT.AsEnumerable
                If row("STAT") = "E0002" Then
                    Return "U"
                End If
            Next
        End If

        Return Nothing
    End Function

    Friend Function GetAnwStatusAenderung(FAUF As String) As Aenderungen
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim Aenderung As New Aenderungen
        Dim DT As DataTable = DS_FAUF.Tables("E1JSTKL")
        Dim temp As String = String.Empty
        Dim Regex As Regex = New Regex("(?<=INFO_AEND:)(.*)(?=INFO_AEND_END)")
        Dim Match As Match
        Dim tempList As New List(Of String)


        Aenderung.AenderungAktiv = False
        If DT Is Nothing Then Return Aenderung
        For Each row In DT.AsEnumerable
            If row("STAT") = "E0004" Then
                Aenderung.AenderungAktiv = True
                'Aenderungstextlesen
                Dim Dt_Text As DataTable = DS_FAUF.Tables("ZE1_DMSOP_KTXT")
                Try
                    For Each r In Dt_Text.AsEnumerable
                        If IsDBNull(r("KOTXT")) Then
                            tempList.Add("newLine")
                        Else
                            tempList.Add(r("KOTXT"))
                        End If
                        temp = temp & r("KOTXT") & " "
                    Next
                Catch ex As Exception

                End Try

            End If
        Next
        Match = Regex.Match(temp)
        Aenderung.AenderungsText = Match.Value
        Aenderung.AenderungsTextList = tempList

        Return Aenderung
    End Function

    Friend Function GetWerkskalender(Datum As String) As Boolean
        Dim Pfad As String = My.Settings.PfadWerkskalender
        Dim Lines() As String = ReadAllLinesCached(Pfad)
        Dim TagInAusnahmeliste As Boolean = False
        'Text Datei nach Materialnummer durchsuchen
        For Each l As String In Lines
            If l.Equals(Datum) Then
                TagInAusnahmeliste = True
                Exit For
            End If
        Next
        Return TagInAusnahmeliste
    End Function

    Friend Function GetLastWorkDay(Datum As Date) As Date

        Dim DateLetzterAt As Date
        Dim tempDate As Date = Datum.AddDays(-1)
        Dim DateFound As Boolean = False

        Do
            If GetWerkskalender(tempDate.ToShortDateString) = True Then
                tempDate = tempDate.AddDays(-1)
            ElseIf tempDate.DayOfWeek = DayOfWeek.Sunday Then
                tempDate = tempDate.AddDays(-2)
            ElseIf tempDate.DayOfWeek = DayOfWeek.Saturday Then
                tempDate = tempDate.AddDays(-1)
            Else
                DateFound = True
                DateLetzterAt = tempDate
            End If
        Loop Until DateFound = True

        Debug.WriteLine(DateLetzterAt)
        Return DateLetzterAt
    End Function

    Friend Function GetMaterialNr(FAUF As String) As String
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("E1AFKOL")
        If Not IsNothing(DT) Then
            For Each r In DT.AsEnumerable
                If Not IsDBNull(r.Item("MATNR")) Then
                    Return r.Item("MATNR")
                End If
            Next
        End If

        Return Nothing
    End Function

    Friend Function GetRS(FAUF As String) As String
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(FAUF))
        Dim DT As DataTable = DS_FAUF.Tables("ZE1_DMSOP_MARX")

        If Not IsNothing(DT) Then
            For Each r In DT.AsEnumerable
                Try
                    If Not IsDBNull(r.Item("REVLV")) Then
                        Return r.Item("REVLV")
                    End If
                Catch ex As Exception
                    Return String.Empty
                End Try
            Next
        End If
        Return String.Empty
    End Function

    Friend Function GetFarbigeMelderData(Fauf As String) As FarbigeMelder
        Dim DS_FAUF As DataSet = SAP_XML.ReadXML2DS(SAP_XML.PathFAUF_XML(Fauf))
        Dim DT_Kundennummer As DataTable = DS_FAUF.Tables("ZE1_DMSOP_AFKO")
        Dim DT_Farbe As DataTable = DS_FAUF.Tables("ZE1_DMSOP_HEADER_TEXTS")
        Dim FarbigeMelder As New FarbigeMelder

        Try
            For Each r In DT_Kundennummer.AsEnumerable
                If Not IsDBNull(r.Item("ZZVBELN")) Or Not IsDBNull(r.Item("ZZPOSNR")) Then
                    FarbigeMelder.Kundenauftragsnummer = r.Item("ZZVBELN")
                    FarbigeMelder.PositionsText = r.Item("ZZPOSNR")
                    FarbigeMelder.FarbigerMelder = True
                End If
            Next
            For Each r In DT_Farbe.AsEnumerable
                If Not IsDBNull(r.Item("TEXT")) Then
                    FarbigeMelder.Farbe = r.Item("TEXT")
                    FarbigeMelder.FarbigerMelder = True
                End If
            Next

        Catch ex As Exception
            'FarbigeMelder.FarbigerMelder = False
        End Try

        Return FarbigeMelder
    End Function

    Friend Function isPP00(Fauf As String) As Boolean
        Dim l As Integer = Len(Fauf)
        If l < 8 Then
            Return True
        Else
            Return False
        End If

    End Function

End Class

Class TC3Dok
    Public DokArt As String
    Public DokNummer As String
    Public DokVersion As String
End Class
Class TC2Dok 'FS
    Public DokArt As String
    Public DokNummer As String
    Public DokVersion As String
End Class

Public Class VorgabeZeiten
    Public RuestenMaschine As Double
    Public RuestenPersonal As Double
    Public Maschinenzeit As Double
    Public Personalzeit As Double
End Class

Public Class Aenderungen
    Public AenderungAktiv As Boolean
    Public AenderungsText As String
    Public AenderungsTextList As List(Of String)
End Class

Public Class FarbigeMelder
    Public FarbigerMelder As Boolean = False
    Public Kundenauftragsnummer As String
    Public PositionsText As String
    Public Farbe As String
End Class
