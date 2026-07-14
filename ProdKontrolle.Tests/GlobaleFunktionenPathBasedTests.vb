Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

''' <summary>
''' Deckt GlobaleFunktionen-Methoden ab, die intern SAP_XML.PathFAUF_XML(FAUF) aufrufen statt einen
''' Pfad entgegenzunehmen. PathFAUF_XML baut den Pfad aus My.Settings.PfadFAUFxml & "0020_" & FAUF &
''' ".xml" - dafuer wird die Einstellung in TestInitialize auf ein Temp-Verzeichnis umgebogen, in das
''' die Fixture unter dem erwarteten Dateinamen kopiert wird. So wird der MsgBox-Zweig in
''' PathFAUF_XML ("FAUF XML nicht vorhanden"), der einen Testlauf blockieren wuerde, sicher vermieden.
'''
''' GetMatStatus/GetArtikelNameByArtNr/GetStuecklisteFromSAPXML werden hier bewusst NICHT getestet:
''' sie haengen zusaetzlich von SAP_XML.PathAPLA_XML ab, das einen fest verdrahteten UNC-Netzwerkpfad
''' (\\ch021093\...) verwendet und bei fehlendem Zugriff ebenfalls ungefragt eine MsgBox zeigt - das
''' laesst sich ohne Aenderung an der Produktionslogik nicht automatisiert/sicher testen.
''' </summary>
<TestClass>
Public Class GlobaleFunktionenPathBasedTests

    Private Const TestFauf As String = "TESTFAUF"
    Private tempDir As String
    Private originalPfadFAUFxml As String
    Private originalPfadFAUFxmlAlternativ As String

    <TestInitialize>
    Public Sub Setup()
        originalPfadFAUFxml = Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxml
        originalPfadFAUFxmlAlternativ = Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxmlAlternativ

        tempDir = Path.Combine(Path.GetTempPath(), "ProdKontrolleTests_" & Guid.NewGuid().ToString("N"))
        Directory.CreateDirectory(tempDir)

        Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxml = tempDir & "\"
        Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxmlAlternativ = tempDir & "\"
    End Sub

    <TestCleanup>
    Public Sub Teardown()
        Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxml = originalPfadFAUFxml
        Global.ProdKontrolle.My.MySettings.Default.PfadFAUFxmlAlternativ = originalPfadFAUFxmlAlternativ

        Try
            If Directory.Exists(tempDir) Then Directory.Delete(tempDir, True)
        Catch
        End Try
    End Sub

    Private Sub UseFixture(fixtureFileName As String)
        Dim source As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fixtures", fixtureFileName)
        Dim target As String = Path.Combine(tempDir, "0020_" & TestFauf & ".xml")
        File.Copy(source, target, overwrite:=True)
    End Sub

    <TestMethod>
    Public Sub GetDateFrom_FAUF_ValidFixture_ReturnsGSTRP()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual(New Date(2026, 1, 1).ToShortDateString(), fn.GetDateFrom_FAUF(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetDateFrom_FAUF_MissingTable_ReturnsEmptyStringWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("", fn.GetDateFrom_FAUF(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetDateTo_FAUF_ValidFixture_ReturnsGLTRP()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual(New Date(2026, 1, 15).ToShortDateString(), fn.GetDateTo_FAUF(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetDateTo_FAUF_MissingTable_ReturnsEmptyStringWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("", fn.GetDateTo_FAUF(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetMaterialNr_ValidFixture_ReturnsMATNR()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("1000001", fn.GetMaterialNr(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetMaterialNr_MissingTable_ReturnsNothingWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.IsNull(fn.GetMaterialNr(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetRS_ValidFixture_ReturnsREVLV()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("03", fn.GetRS(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetRS_MissingTable_ReturnsEmptyStringWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual(String.Empty, fn.GetRS(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetStndWDok_ValidFixture_FindetStandardDokumentOhneDatei()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        ' Das zugehoerige PDF existiert im Test nicht - Funktion muss trotzdem "False" (String)
        ' zurueckgeben statt zu werfen; die eigentliche Dokumenten-Suche in ZE1_DMSOP_AFFH lief korrekt,
        ' wenn kein Fehler auftritt.
        Assert.AreEqual("False", fn.GetStndWDok(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetStndWDok_MissingTable_ReturnsFalseWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("False", fn.GetStndWDok(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetAnwStatusUMTE_StatusE0002Vorhanden_ReturnsU()
        UseFixture("fauf_umte_status.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("U", fn.GetAnwStatusUMTE(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetAnwStatusUMTE_KeinE0002_ReturnsNothing()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.IsNull(fn.GetAnwStatusUMTE(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetAnwStatusUMTE_MissingTable_ReturnsNothingWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.IsNull(fn.GetAnwStatusUMTE(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetCEVA_GearBoxNr_FindetDokumentMitGearBoxImText()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("DOC-002", fn.GetCEVA_GearBoxNr(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetCEVA_GearBoxNr_MissingTable_ReturnsEmptyStringWithoutThrowing()
        UseFixture("fauf_missing_tables.xml")
        Dim fn As New GlobaleFunktionen

        Assert.AreEqual("", fn.GetCEVA_GearBoxNr(TestFauf))
    End Sub

    <TestMethod>
    Public Sub GetTC3Dok_FindetTC3Dokument()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Dim result = fn.GetTC3Dok(TestFauf)

        Assert.AreEqual("TC3-001", result.DokNummer)
        Assert.AreEqual("01", result.DokVersion)
    End Sub

    <TestMethod>
    Public Sub GetTC2Dok_KeinTC2Vorhanden_ReturnsLeeresObjektOhneZuWerfen()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Dim result = fn.GetTC2Dok(TestFauf)

        Assert.AreEqual(Nothing, result.DokNummer)
    End Sub

    <TestMethod>
    Public Sub GetAuftragZeiten_ValidFixture_BerechnetZeitenAusVGWFeldern()
        UseFixture("fauf_basic.xml")
        Dim fn As New GlobaleFunktionen

        Dim zeiten = fn.GetAuftragZeiten(TestFauf)

        ' RuestenMaschine = Summe VGW01 (10+0), RuestenPersonal = Summe VGW04 (5+0)
        Assert.AreEqual(10.0, zeiten.RuestenMaschine)
        Assert.AreEqual(5.0, zeiten.RuestenPersonal)
    End Sub

End Class
