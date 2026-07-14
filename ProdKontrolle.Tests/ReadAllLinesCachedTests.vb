Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

<TestClass>
Public Class ReadAllLinesCachedTests

    Private tempPath As String

    <TestInitialize>
    Public Sub Setup()
        tempPath = Path.Combine(Path.GetTempPath(), "readlines_" & Guid.NewGuid().ToString("N") & ".txt")
    End Sub

    <TestCleanup>
    Public Sub Teardown()
        Try
            If File.Exists(tempPath) Then File.Delete(tempPath)
        Catch
        End Try
    End Sub

    <TestMethod>
    Public Sub ReadAllLinesCached_LiestZeilenDerDatei()
        File.WriteAllLines(tempPath, {"Zeile1", "Zeile2"})
        Dim fn As New GlobaleFunktionen

        Dim zeilen As String() = fn.ReadAllLinesCached(tempPath)

        CollectionAssert.AreEqual({"Zeile1", "Zeile2"}, zeilen)
    End Sub

    <TestMethod>
    Public Sub ReadAllLinesCached_UnveraenderteDatei_LiefertGecachtenInhalt()
        File.WriteAllLines(tempPath, {"Zeile1"})
        Dim fn As New GlobaleFunktionen

        Dim erste As String() = fn.ReadAllLinesCached(tempPath)
        Dim zweite As String() = fn.ReadAllLinesCached(tempPath)

        Assert.AreSame(erste, zweite)
    End Sub

    <TestMethod>
    Public Sub ReadAllLinesCached_GeaenderteDatei_LiestNeuenInhalt()
        File.WriteAllLines(tempPath, {"Alt"})
        File.SetLastWriteTimeUtc(tempPath, DateTime.UtcNow.AddMinutes(-5))
        Dim fn As New GlobaleFunktionen

        Dim erste As String() = fn.ReadAllLinesCached(tempPath)
        Assert.AreEqual("Alt", erste(0))

        File.WriteAllLines(tempPath, {"Neu"})
        File.SetLastWriteTimeUtc(tempPath, DateTime.UtcNow)

        Dim zweite As String() = fn.ReadAllLinesCached(tempPath)
        Assert.AreEqual("Neu", zweite(0))
    End Sub

End Class
