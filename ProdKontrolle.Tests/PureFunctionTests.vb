Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

<TestClass>
Public Class PureFunctionTests

    <TestMethod>
    Public Sub isPP00_SiebenZeichen_ReturnsTrue()
        Dim fn As New GlobaleFunktionen
        Assert.IsTrue(fn.isPP00("1234567"))
    End Sub

    <TestMethod>
    Public Sub isPP00_AchtZeichen_ReturnsFalse()
        Dim fn As New GlobaleFunktionen
        Assert.IsFalse(fn.isPP00("12345678"))
    End Sub

    <TestMethod>
    Public Sub isPP00_LeererString_ReturnsTrue()
        Dim fn As New GlobaleFunktionen
        Assert.IsTrue(fn.isPP00(""))
    End Sub

    <TestMethod>
    Public Sub GetStringValue_Nothing_ReturnsBindestrich()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual("-", fn.GetStringValue(Nothing))
    End Sub

    <TestMethod>
    Public Sub GetStringValue_DBNull_ReturnsBindestrich()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual("-", fn.GetStringValue(DBNull.Value))
    End Sub

    <TestMethod>
    Public Sub GetStringValue_NormalerString_ReturnsUnveraendert()
        Dim fn As New GlobaleFunktionen
        Assert.AreEqual("hallo", fn.GetStringValue("hallo"))
    End Sub

End Class
