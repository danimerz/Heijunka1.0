# ProdKontrolle.Tests

Automatisiertes MSTest-Testprojekt (VB.NET, .NET Framework 4.7.2) für die `DigitalesHeijunka`-Anwendung
(`ProdKontrolle`). Referenziert `ProdKontrolle/DigitalesHeijunka.vbproj` per `ProjectReference` und nutzt
`InternalsVisibleTo` (siehe `ProdKontrolle/My Project/AssemblyInfo.vb`), um auch `Friend`-Member wie in
`GlobaleFunktionen` zu testen.

## Ausführen

Da das Hauptprojekt COM-Referenzen enthält, funktioniert `dotnet build`/`dotnet test` **nicht**
(Fehler `MSB4803`). Volle Visual-Studio-MSBuild und VSTest verwenden:

```
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ProdKontrolle.Tests.vbproj -t:Build -p:Configuration=Debug

"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" bin\Debug\net472\ProdKontrolle.Tests.dll
```

Oder einfach in Visual Studio über den Test Explorer (Projekt ist der Solution hinzugefügt).

## Was ist abgedeckt

- **`SapXmlReadTests`** – `SAP_XML.ReadXML2DS`, inkl. Regressionstests für den Absturz vom 2026-07-09
  (leerer/nicht existierender/ungültiger Pfad durfte nicht mehr crashen) und für das Caching-Verhalten.
- **`GlobaleFunktionenSapXmlTests`** – Funktionen, die einen fertigen `FAUFPath` entgegennehmen
  (`GetFaufQty`, `GetReportedBackQuantity`, `GetReportedFailQuantity`, `GetReportedBackQuantityTRUC`,
  `GetEndDateFauf`, `GetEndDateVrg`), inkl. der „Tabelle fehlt“-Guards.
- **`GlobaleFunktionenPathBasedTests`** – Funktionen, die intern `SAP_XML.PathFAUF_XML(FAUF)` aufrufen
  (`GetDateFrom_FAUF`, `GetDateTo_FAUF`, `GetMaterialNr`, `GetRS`, `GetStndWDok`, `GetAnwStatusUMTE`,
  `GetCEVA_GearBoxNr`, `GetTC3Dok`, `GetTC2Dok`, `GetAuftragZeiten`). Nutzt `My.Settings.PfadFAUFxml`
  umgebogen auf ein Temp-Verzeichnis, damit `PathFAUF_XML` die Test-Fixture findet, ohne die eingebaute
  `MsgBox("FAUF XML nicht vorhanden")` auszulösen (siehe unten).
- **`FeiertageTests`** – Osterdatum gegen eine unabhängige zweite Implementierung
  (Meeus/Jones/Butcher) über 50 Jahre geprüft. Deckte am 2026-07-10 einen echten Bug in der
  vorherigen Gauss'schen Implementierung auf (siehe unten) - inzwischen behoben, `Feiertage.vb`
  nutzt seitdem selbst den Meeus/Jones/Butcher-Algorithmus.
- **`PureFunctionTests`** – `isPP00`, `GetStringValue`.
- **`Code128RenderingTests`** – Barcode-Bildgenerierung (Bildgröße/-breite).
- **`IniHandlingTests`** – `iniHandling` Lesen/Schreiben/Löschen, Roundtrip.
- **`ReadAllLinesCachedTests`** – Datei-Cache inkl. Invalidierung bei geändertem Zeitstempel.

Fixtures liegen unter `Fixtures/*.xml` und bilden vereinfachte SAP-FAUF-XML-Exports nach (Segmentnamen
wie `E1AFKOL`, `E1AFVOL`, `ZE1_DMSOP_MARX` etc., wie sie `ReadXML2DS`/`DataSet.ReadXml` real erwartet).

## Behobener Fund: Osterformel-Bug (2026-07-10)

`FeiertageTests.Get_Feiertage_Ostersonntag_StimmtMitUnabhaengigemAlgorithmusUeberein_2000Bis2049`
deckte beim ersten Testlauf einen echten Bug in `Klassen/Feiertage.vb` auf (inzwischen behoben, alle
Tests grün). Ursache: die Gauss'sche Korrektur des Mondzyklus-Werts "d" (29→28, ggf. →27) wurde
*bevor* der eigentlich dafür nötige Wert `e=6` bekannt war unbedingt angewendet, statt wie im
Originalalgorithmus erst nachträglich als Sonderfall auf das fertige Datum. Für 8 von 71 geprüften
Jahren (1990–2060) berechnete `Get_Feiertage` den Ostersonntag dadurch exakt eine Woche zu früh:

| Jahr | berechnet (Bug) | korrekt |
|------|------------------|---------|
| 1994 | 27.03. | 03.04. |
| 1997 | 23.03. | 30.03. |
| 2001 | 08.04. | 15.04. |
| 2021 | 28.03. | 04.04. |
| 2025 | 13.04. | 20.04. |
| 2045 | 02.04. | 09.04. |
| 2052 | 14.04. | 21.04. |
| 2055 | 11.04. | 18.04. |

Da alle abgeleiteten Feiertage (Ostermontag, Karfreitag, Pfingsten, Fronleichnam, Christi Himmelfahrt,
Aschermittwoch) relativ zum Ostersonntag berechnet werden, sind in diesen Jahren vermutlich auch diese
falsch. Betrifft u.a. Werkskalender-Logik (`GetWerkskalender`, `GetLastWorkDay`), sofern die
Feiertage-Klasse dafür verwendet wird. Nicht im Rahmen dieser Test-Routine behoben – noch nicht mit dem
Anwender abgestimmt, da es eine Änderung an produktiver Kalenderlogik ist.

## Bewusst NICHT automatisiert getestet

- **`GetMatStatus`, `GetArtikelNameByArtNr`, `GetStuecklisteFromSAPXML`, `GetCEVA_GearBoxNr_TC3`** –
  hängen von `SAP_XML.PathAPLA_XML` ab, das einen fest verdrahteten UNC-Pfad (`\\ch021093\...`)
  verwendet und bei Nichterreichbarkeit ungefragt eine blockierende `MsgBox` zeigt. Auf einer Maschine
  ohne Zugriff auf diese Freigabe würde ein Testlauf dort hängen bleiben.
- **Alles SQL-basierte** (`GetRueckmeldenStatusByFAUF`, `GetOffeneProdKontrolleByFAUF`,
  `GetProdKontrolleByFAUF`, `GetKommentarByFAUF`, `WriteFaufInitToDb`, `sqlAvailable`, `SetProtocol`) –
  würde echte Verbindungen zu den produktiven SQL-Servern aufbauen. **Nebenbefund:** Die
  Connection-Strings inkl. Klartext-Passwort (`WriteFaufInitToDb`, `GlobaleFunktionen.vb`) sind direkt im
  Quellcode hinterlegt, nicht nur ein Testbarkeits-, sondern auch ein Security-Thema.
- **`sendMail`** (verschickt echte E-Mails), **`ChkList`/`PlayVideo`/`GetPcbPicture`**
  (`Process.Start` öffnet echte Dateien/Programme), **`GetSAPVersion`** (Netzwerkpfad-Zugriff).
- **Alle Forms** (`Form1.vb` und die übrigen `.vb`-Dateien unter `Forms/`) – WinForms-Code-Behind mit
  Designer-generierten, DB-gebundenen `TableAdapter`s und der in dieser Session mehrfach behandelten
  gemeinsamen `Row`/`Col`-Zustandsproblematik. Ohne Extraktion der Geschäftslogik aus den Event-Handlern
  nicht sinnvoll unit-testbar; siehe Memory-Notiz `project_prodkontrolle_row_state`.
- **`Klassen/copyToDatatable.vb`** (`EnumerableExtensions.ToDataTable`) – **ist gar nicht Teil des
  Builds.** Die Datei fehlt im `<Compile Include>`-Abschnitt von `DigitalesHeijunka.vbproj` und wird
  daher nie kompiliert/verwendet. Toter Code, nicht extra behoben, aber erwähnenswert.
- **`mqtt.vb`, `Wats.vb`, `UpdateHandler.vb`, `HeijunkaAnzeige.vb`** – Netzwerk-/MQTT-/ClickOnce-lastig,
  nicht ohne echte Infrastruktur sinnvoll automatisiert testbar.

Für die oben genannten, nicht automatisiert testbaren Bereiche (v.a. die Forms) wäre eine manuelle
Testcheckliste die realistischere Ergänzung.
