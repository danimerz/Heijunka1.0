Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

''' <summary>
''' Deckt SAP_XML.ReadXML2DS ab - die zentrale Stelle, die am 2026-07-09 gehärtet wurde, nachdem ein
''' leerer/nicht existierender Dateipfad (PathFAUF_XML gibt "" zurück, wenn die Datei fehlt) eine
''' ArgumentException aus File.GetLastWriteTimeUtc("") auslöste und die App zum Absturz brachte
''' (Form1.FSW_XML_Change_Renamed -> GlobaleFunktionen.GetReportedBackQuantity -> ReadXML2DS).
''' </summary>
<TestClass>
Public Class SapXmlReadTests

    Private ReadOnly Property FixturesDir As String
        Get
            Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fixtures")
        End Get
    End Property

    Private ReadOnly Property BasicFixturePath As String
        Get
            Return Path.Combine(FixturesDir, "fauf_basic.xml")
        End Get
    End Property

    <TestMethod>
    Public Sub ReadXML2DS_EmptyPath_ReturnsEmptyDataSetWithoutThrowing()
        Dim sapXml As New SAP_XML

        Dim ds As DataSet = sapXml.ReadXML2DS("")

        Assert.IsNotNull(ds)
        Assert.AreEqual(0, ds.Tables.Count)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_NothingPath_ReturnsEmptyDataSetWithoutThrowing()
        Dim sapXml As New SAP_XML

        Dim ds As DataSet = sapXml.ReadXML2DS(Nothing)

        Assert.IsNotNull(ds)
        Assert.AreEqual(0, ds.Tables.Count)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_NonexistentPath_ReturnsEmptyDataSetWithoutThrowing()
        ' Regressionstest für genau den gemeldeten Absturz: FileSystemWatcher liefert einen Pfad zu
        ' einer Datei, die (noch) nicht existiert.
        Dim sapXml As New SAP_XML
        Dim missingPath As String = Path.Combine(FixturesDir, "datei_die_es_nicht_gibt_" & Guid.NewGuid().ToString("N") & ".xml")

        Dim ds As DataSet = sapXml.ReadXML2DS(missingPath)

        Assert.IsNotNull(ds)
        Assert.AreEqual(0, ds.Tables.Count)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_MalformedPath_ReturnsEmptyDataSetWithoutThrowing()
        ' Ungueltige Pfadzeichen fuehren in File.GetLastWriteTimeUtc zu einer ArgumentException -
        ' auch das darf nicht mehr nach aussen dringen.
        Dim sapXml As New SAP_XML

        Dim ds As DataSet = sapXml.ReadXML2DS("::/\|<>ungueltig")

        Assert.IsNotNull(ds)
        Assert.AreEqual(0, ds.Tables.Count)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_ValidFixture_ParsesAllExpectedTables()
        Dim sapXml As New SAP_XML

        Dim ds As DataSet = sapXml.ReadXML2DS(BasicFixturePath)

        Assert.AreEqual(7, ds.Tables.Count)
        Assert.IsTrue(ds.Tables.Contains("E1AFKOL"))
        Assert.IsTrue(ds.Tables.Contains("E1AFVOL"))
        Assert.IsTrue(ds.Tables.Contains("ZE1_DMSOP_MARX"))
        Assert.IsTrue(ds.Tables.Contains("ZE1_DMSOP_AFFH"))
        Assert.IsTrue(ds.Tables.Contains("E1JSTKL"))
        Assert.IsTrue(ds.Tables.Contains("ZE1_DMSOP_DOKV"))
        Assert.IsTrue(ds.Tables.Contains("ZE1_DMSOP_TEXT"))

        Assert.AreEqual(1, ds.Tables("E1AFKOL").Rows.Count)
        Assert.AreEqual("1000001", ds.Tables("E1AFKOL").Rows(0)("MATNR").ToString())
        Assert.AreEqual(2, ds.Tables("E1AFVOL").Rows.Count)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_MissingTablesFixture_ReturnsDataSetWithoutExpectedTables()
        Dim sapXml As New SAP_XML
        Dim fixturePath As String = Path.Combine(FixturesDir, "fauf_missing_tables.xml")

        Dim ds As DataSet = sapXml.ReadXML2DS(fixturePath)

        Assert.IsFalse(ds.Tables.Contains("E1AFKOL"))
        Assert.IsFalse(ds.Tables.Contains("ZE1_DMSOP_MARX"))
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_SameFileReadTwice_ReturnsSameCachedInstance()
        ' Der Cache in SAP_XML ist global (Shared) ueber alle Instanzen - eine zweite, unveraenderte
        ' Datei mit demselben Pfad + Zeitstempel muss dasselbe DataSet-Objekt liefern statt neu zu parsen.
        Dim sapXml As New SAP_XML

        Dim first As DataSet = sapXml.ReadXML2DS(BasicFixturePath)
        Dim second As DataSet = sapXml.ReadXML2DS(BasicFixturePath)

        Assert.AreSame(first, second)
    End Sub

    <TestMethod>
    Public Sub ReadXML2DS_FileChangedSincePreviousRead_ReReadsFile()
        Dim sapXml As New SAP_XML
        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "sapxml_test_" & Guid.NewGuid().ToString("N") & ".xml")
        Try
            File.WriteAllText(tempPath, "<ZFAUF><E1AFKOL><MATNR>111</MATNR></E1AFKOL></ZFAUF>")
            File.SetLastWriteTimeUtc(tempPath, DateTime.UtcNow.AddMinutes(-5))

            Dim first As DataSet = sapXml.ReadXML2DS(tempPath)
            Assert.AreEqual("111", first.Tables("E1AFKOL").Rows(0)("MATNR").ToString())

            ' Datei aendern und mit einem klar neueren Zeitstempel versehen, damit der Cache
            ' zuverlaessig (unabhaengig von der Dateisystem-Aufloesung) als veraltet erkannt wird.
            File.WriteAllText(tempPath, "<ZFAUF><E1AFKOL><MATNR>222</MATNR></E1AFKOL></ZFAUF>")
            File.SetLastWriteTimeUtc(tempPath, DateTime.UtcNow)

            Dim second As DataSet = sapXml.ReadXML2DS(tempPath)
            Assert.AreEqual("222", second.Tables("E1AFKOL").Rows(0)("MATNR").ToString())
        Finally
            If File.Exists(tempPath) Then File.Delete(tempPath)
        End Try
    End Sub

    <TestMethod>
    Public Sub ReadXML2DT_ReturnsRequestedTableOnly()
        Dim sapXml As New SAP_XML

        Dim dt As DataTable = sapXml.ReadXML2DT(BasicFixturePath, "ZE1_DMSOP_MARX")

        Assert.IsNotNull(dt)
        Assert.AreEqual("Testartikel", dt.Rows(0)("MAKTX").ToString())
    End Sub

End Class
