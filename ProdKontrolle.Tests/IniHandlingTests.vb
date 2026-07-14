Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

''' <summary>
''' WertLesen/WertSchreiben/SchluesselLoeschen zeigen bei fehlendem Pfad/fehlender Datei eine MsgBox
''' an, die einen Testlauf blockieren wuerde - die Tests hier stellen daher immer sicher, dass Pfad
''' und Datei vorher existieren, um ausschliesslich die Erfolgspfade abzudecken.
''' </summary>
<TestClass>
Public Class IniHandlingTests

    Private tempIniPath As String

    <TestInitialize>
    Public Sub Setup()
        tempIniPath = Path.Combine(Path.GetTempPath(), "test_" & Guid.NewGuid().ToString("N") & ".ini")
        File.WriteAllText(tempIniPath, "")
    End Sub

    <TestCleanup>
    Public Sub Teardown()
        Try
            If File.Exists(tempIniPath) Then File.Delete(tempIniPath)
        Catch
        End Try
    End Sub

    <TestMethod>
    Public Sub WertSchreibenUndLesen_Roundtrip_LiefertGeschriebenenWert()
        Dim ini As New iniHandling(tempIniPath)

        ini.WertSchreiben("Sektion1", "Schluessel1", "Wert1")
        Dim gelesen As String = ini.WertLesen("Sektion1", "Schluessel1")

        Assert.AreEqual("Wert1", gelesen)
    End Sub

    <TestMethod>
    Public Sub WertLesen_NichtVorhandenerSchluessel_LiefertStandardwert()
        Dim ini As New iniHandling(tempIniPath)

        Dim gelesen As String = ini.WertLesen("Sektion1", "GibtEsNicht", "StandardX")

        Assert.AreEqual("StandardX", gelesen)
    End Sub

    <TestMethod>
    Public Sub SchluesselLoeschen_EntferntZuvorGeschriebenenWert()
        Dim ini As New iniHandling(tempIniPath)
        ini.WertSchreiben("Sektion1", "Schluessel1", "Wert1")

        ini.SchlüsselLöschen("Sektion1", "Schluessel1")
        Dim gelesen As String = ini.WertLesen("Sektion1", "Schluessel1", "weg")

        Assert.AreEqual("weg", gelesen)
    End Sub

    <TestMethod>
    Public Sub WertSchreiben_UeberschreibtVorhandenenWert()
        Dim ini As New iniHandling(tempIniPath)
        ini.WertSchreiben("Sektion1", "Schluessel1", "Alt")

        ini.WertSchreiben("Sektion1", "Schluessel1", "Neu")
        Dim gelesen As String = ini.WertLesen("Sektion1", "Schluessel1")

        Assert.AreEqual("Neu", gelesen)
    End Sub

End Class
