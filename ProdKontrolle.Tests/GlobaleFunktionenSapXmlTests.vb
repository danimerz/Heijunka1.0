Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

''' <summary>
''' Deckt die GlobaleFunktionen-Methoden ab, die einen fertigen FAUFPath als Parameter entgegennehmen
''' (kein interner Aufruf von SAP_XML.PathFAUF_XML noetig, daher ohne My.Settings-Umbiegung testbar).
''' </summary>
<TestClass>
Public Class GlobaleFunktionenSapXmlTests

    Private ReadOnly Property BasicFixturePath As String
        Get
            Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fixtures", "fauf_basic.xml")
        End Get
    End Property

    Private ReadOnly Property MissingTablesFixturePath As String
        Get
            Return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Fixtures", "fauf_missing_tables.xml")
        End Get
    End Property

    <TestMethod>
    Public Sub GetFaufQty_ValidFixture_ReturnsBMENGE()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(500, fn.GetFaufQty(BasicFixturePath))
    End Sub

    <TestMethod>
    Public Sub GetFaufQty_MissingTable_ReturnsZeroWithoutThrowing()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(0, fn.GetFaufQty(MissingTablesFixturePath))
    End Sub

    <TestMethod>
    Public Sub GetFaufQty_NonexistentPath_ReturnsZeroWithoutThrowing()
        Dim fn As New GlobaleFunktionen
        Dim missingPath As String = Path.Combine(Path.GetTempPath(), "nope_" & Guid.NewGuid().ToString("N") & ".xml")
        Assert.AreEqual(0, fn.GetFaufQty(missingPath))
    End Sub

    <TestMethod>
    Public Sub GetReportedBackQuantity_ValidFixture_ReturnsIGMNG()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(480, fn.GetReportedBackQuantity(BasicFixturePath))
    End Sub

    <TestMethod>
    Public Sub GetReportedFailQuantity_ValidFixture_ReturnsIASMG()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(5, fn.GetReportedFailQuantity(BasicFixturePath))
    End Sub

    <TestMethod>
    Public Sub GetReportedBackQuantityTRUC_MatchingArbeitsplatzUndVorgang_ReturnsLMNGA()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(480, fn.GetReportedBackQuantityTRUC(BasicFixturePath, "AP01", "0010"))
    End Sub

    <TestMethod>
    Public Sub GetReportedBackQuantityTRUC_NichtPassenderArbeitsplatz_ReturnsZero()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(0, fn.GetReportedBackQuantityTRUC(BasicFixturePath, "UNBEKANNT", "9999"))
    End Sub

    <TestMethod>
    Public Sub GetEndDateFauf_ValidFixture_ReturnsGLTRP()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(New Date(2026, 1, 15), fn.GetEndDateFauf(BasicFixturePath))
    End Sub

    <TestMethod>
    Public Sub GetEndDateVrg_MatchingVorgang_ReturnsSSAVD()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual(New Date(2026, 1, 4), fn.GetEndDateVrg(BasicFixturePath, "0020"))
    End Sub

End Class
