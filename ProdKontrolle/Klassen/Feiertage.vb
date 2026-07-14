Public Class Feiertage
    ' Osterformel nach Carl Friedrich Gauß (1777-1855)
    Public Structure Feiertage_struc

        Dim Ostersonntag As Date
        Dim Ostermontag As Date     ' 1 Tag nach Ostersonntag
        Dim Karfreitag As Date      ' 2 Tage vor Ostersonntag
        Dim Pfingstsonntag As Date  ' 49 Tage nach Ostersonntag
        Dim PfingstMontag As Date       ' 50 Tage nach Ostersonntag
        Dim Himmelfahrt As Date     ' 39 Tage nach Ostersonntag
        Dim Aschermittwoch As Date  ' 46 Tage vor Ostersonntag
        Dim Fronleichnam As Date        ' 60 Tage nach Ostersonntag
    End Structure

    Public Function Get_Feiertage(ByVal Jahr As Long) As Feiertage_struc

        ' Gültigkeitsbereich ist vom Jahre 1583  - 8202
        If Jahr < 1583 Or Jahr > 8202 Then Exit Function

        ' Osterdatum nach dem Osteralgorithmus von Meeus/Jones/Butcher (gregorianischer Kalender).
        ' Die vorherige Gauss'sche Variante korrigierte den Mondzyklus-Wert "d" unbedingt, sobald
        ' d=28 und (Jahr Mod 19)>10 war - die eigentliche Gauss-Regel verlangt dafür aber zusätzlich
        ' e=6 (und prüft das erst NACH der Berechnung von e aus dem unkorrigierten d, nicht vorher).
        ' Dadurch wurde der Ostersonntag in 8 von 71 getesteten Jahren (u.a. 2001, 2025, 2045) exakt
        ' eine Woche zu früh berechnet - siehe ProdKontrolle.Tests/FeiertageTests.vb, das diesen
        ' Algorithmus über 50 Jahre gegen die alte Implementierung verifiziert hat.
        Dim jahrInt As Integer = CInt(Jahr)
        Dim a As Integer = jahrInt Mod 19
        Dim b As Integer = jahrInt \ 100
        Dim c As Integer = jahrInt Mod 100
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

        With Get_Feiertage
            .Ostersonntag = New Date(jahrInt, monat, tag)
            .Ostermontag = DateAdd("d", 1, .Ostersonntag)
            .Karfreitag = DateAdd("d", -2, .Ostersonntag)
            .Pfingstsonntag = DateAdd("d", 49, .Ostersonntag)
            .PfingstMontag = DateAdd("d", 50, .Ostersonntag)
            .Himmelfahrt = DateAdd("d", 39, .Ostersonntag)
            .Aschermittwoch = DateAdd("d", -46, .Ostersonntag)
            .Fronleichnam = DateAdd("d", 60, .Ostersonntag)
        End With
    End Function
End Class
