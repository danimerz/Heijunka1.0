Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

''' <summary>
''' Prueft die Gauss'sche Osterformel in Feiertage.Get_Feiertage gegen eine unabhaengige zweite
''' Implementierung (Anonymous-Gregorian-Algorithmus nach Meeus/Jones/Butcher) ueber viele Jahre,
''' statt einzelne, aus dem Gedaechtnis zitierte Datumswerte zu hinterlegen.
''' </summary>
<TestClass>
Public Class FeiertageTests

    Private Function BerechneOsterdatumMeeusJonesButcher(jahr As Integer) As Date
        Dim a As Integer = jahr Mod 19
        Dim b As Integer = jahr \ 100
        Dim c As Integer = jahr Mod 100
        Dim d As Integer = b \ 4
        Dim e As Integer = b Mod 4
        Dim f As Integer = (b + 8) \ 25
        Dim g As Integer = (b - f + 1) \ 3
        Dim h As Integer = (19 * a + b - d - g + 15) Mod 30
        Dim i As Integer = c \ 4
        Dim k As Integer = c Mod 4
        Dim l As Integer = (32 + 2 * e + 2 * i - h - k) Mod 7
        Dim m As Integer = (a + 11 * h + 22 * l) \ 451
        Dim monat As Integer = (h + l - 7 * m + 114) \ 31
        Dim tag As Integer = ((h + l - 7 * m + 114) Mod 31) + 1
        Return New Date(jahr, monat, tag)
    End Function

    <TestMethod>
    Public Sub Get_Feiertage_Ostersonntag_StimmtMitUnabhaengigemAlgorithmusUeberein_2000Bis2049()
        Dim f As New Feiertage
        For jahr As Integer = 2000 To 2049
            Dim erwartet As Date = BerechneOsterdatumMeeusJonesButcher(jahr)
            Dim ergebnis = f.Get_Feiertage(jahr)
            Assert.AreEqual(erwartet, ergebnis.Ostersonntag, $"Ostersonntag {jahr} stimmt nicht ueberein")
        Next
    End Sub

    <TestMethod>
    Public Sub Get_Feiertage_AbgeleiteteFeiertage_HabenKorrekteAbstaendeZumOstersonntag()
        Dim f As New Feiertage
        Dim ergebnis = f.Get_Feiertage(2026)

        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(1), ergebnis.Ostermontag)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(-2), ergebnis.Karfreitag)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(49), ergebnis.Pfingstsonntag)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(50), ergebnis.PfingstMontag)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(39), ergebnis.Himmelfahrt)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(-46), ergebnis.Aschermittwoch)
        Assert.AreEqual(ergebnis.Ostersonntag.AddDays(60), ergebnis.Fronleichnam)
    End Sub

    <TestMethod>
    Public Sub Get_Feiertage_Ostersonntag_FaelltImmerAufEinenSonntag()
        Dim f As New Feiertage
        For jahr As Integer = 2020 To 2040
            Dim ergebnis = f.Get_Feiertage(jahr)
            Assert.AreEqual(DayOfWeek.Sunday, ergebnis.Ostersonntag.DayOfWeek, $"Jahr {jahr}")
        Next
    End Sub

End Class
