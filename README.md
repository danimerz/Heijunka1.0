# Heijunka 1.0 – Digitales Heijunka

Sammlung von VB.NET-Anwendungen rund um die digitale Heijunka-Tafel (Produktionsnivellierung) in der
Fertigung. Kern ist die WinForms-Anwendung **Digitales Heijunka** (`ProdKontrolle`), die Fertigungsaufträge
aus SAP-Exporten, Testdaten aus WATS und Rückmeldungen aus mehreren SQL-Server-Datenbanken zu einer
Auftrags-Tafel pro Linie zusammenführt.

## Projekte

| Ordner | Projekt | Typ | Zweck |
|---|---|---|---|
| `ProdKontrolle/` | `DigitalesHeijunka.vbproj` | WinForms, .NET Framework 4.7.2 | Hauptanwendung: Heijunka-Tafel, Auftrag starten/rückmelden/beenden, Stückliste, Barcode-Etiketten, Ausschuss, OEE, v-Check, Support-Anfragen |
| `ProdKontrolle.Tests/` | `ProdKontrolle.Tests.vbproj` | MSTest, net472 | Unit-Tests für die Hauptanwendung (siehe [`ProdKontrolle.Tests/README.md`](ProdKontrolle.Tests/README.md)) |
| `HeijunkaDashboard/` | `HeijunkaDashboard.vbproj` | WinForms, .NET Framework 4.7.2 | Dashboard mit SAP-/SMT-Stammdatenimport und WATS-Abfrage |
| `HeijunkaDaten/` | `HeijunkaEditor.vbproj` | WinForms, .NET Framework 4.7.2 | Editor für die Linien-Stammdaten (`tbl_Linie`) |
| `HeijunkaInfo/` | `HeijunkaInfo.vbproj` | WinForms, .NET 5 (`net5.0-windows`) | Info-/Statusanzeige über MQTT (MQTTnet) |
| `Produktionskontrolle/` | `Produktionskontrolle.vbproj` | WinForms, .NET Framework 4.7.2 | Auswertung der Produktionskontrollen nach Linie und Zeitraum, Rückstandsbericht (ReportViewer, `Rückstand.rdlc`) |
| `v-CheckKontrolle_Auswertung/` | `v-CheckKontrolle_Auswertung.vbproj` | WinForms, .NET Framework 4.7.2 | Auswertung der v-Check-Kontrollen nach Linie und Zeitraum |
| `StüliDaten/` | `StüliDaten.vbproj` | ASP.NET WebForms, .NET Framework 4.7.2 | Web-Projekt für Stücklistendaten (nicht in der Solution) |
| `AccessToSQL/` | `AccessToSQL.vbproj` | WinForms, .NET Framework 4.7.2 | Einmaliges Migrationstool: überträgt `tbl_FAUF_Status` aus Access nach SQL Server (nicht in der Solution) |
| `FiFo_Bahn/` | `FiFo_Bahn.vbproj` | WinForms, .NET Framework 4.7.2 | Prototyp/Simulation einer FiFo-Bahn (nicht in der Solution) |

`v-CheckAbfrage.sql` ist eine Beispielabfrage der Stored Procedure `dbo.HJ_GetOperationInfo` in der
Datenbank `Heijunka`.

## Voraussetzungen

- Windows
- Visual Studio 2022 mit den Workloads „.NET-Desktopentwicklung“ und „ASP.NET und Webentwicklung“ (für `StüliDaten`)
- .NET Framework 4.7.2 Developer Pack, für `HeijunkaInfo` zusätzlich das .NET 5 SDK
- Microsoft RDLC Report Designer (für `Produktionskontrolle`)
- Zur Laufzeit: Zugriff auf die SQL-Server-Datenbanken, die SAP-Export-Freigabe (`\\ch021093\...`), die
  WATS-API und die MQTT-Broker des Firmennetzes

## Build

Die Solution `ProdKontrolle.sln` in Visual Studio öffnen. NuGet-Pakete werden beim ersten Build
wiederhergestellt.

Weil das Hauptprojekt COM-Referenzen enthält, funktionieren `dotnet build` und `dotnet test` **nicht**
(Fehler `MSB4803`). Auf der Kommandozeile muss das MSBuild von Visual Studio verwendet werden:

```bat
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" ProdKontrolle.sln -t:Build -p:Configuration=Release
```

## Tests

In Visual Studio über den Test-Explorer oder per VSTest:

```bat
"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" ProdKontrolle.Tests\bin\Debug\net472\ProdKontrolle.Tests.dll
```

Was abgedeckt ist und was bewusst nicht, steht in [`ProdKontrolle.Tests/README.md`](ProdKontrolle.Tests/README.md).

## Deployment

Die Hauptanwendung wird per **ClickOnce** verteilt. Veröffentlichungs- und Installationspfad ist
`\\ch021093\data\Standards\Tools\Produktionskontrolle\Install\`. Die Anwendung prüft beim Start und
periodisch auf Updates (`Klassen/UpdateHandler.vb`). Das lokale Log liegt unter `C:\LocalData\HeijunkaLog.txt`.

## Dokumentation

- [`ProdKontrolle/TechnischesManual.md`](ProdKontrolle/TechnischesManual.md) – Architektur, Datenquellen
  (SAP-XML, WATS, SQL Server, Access, MQTT, IH-Tool, SMTP), Konfiguration, Programmabläufe, Formulare und
  Klassen, bekannte Probleme sowie Hinweise für den geplanten Blazor-Rewrite
- [`ProdKontrolle/Backlog.md`](ProdKontrolle/Backlog.md) – umgesetzte Performance-Optimierungen und offene Punkte
- [`ProdKontrolle.Tests/README.md`](ProdKontrolle.Tests/README.md) – Testabdeckung

## Sicherheitshinweis

Im Code und in den `app.config`-Dateien stehen Zugangsdaten im Klartext (SQL-Server, E-Mail, MQTT,
WATS-API-Key, Anwendungspasswort), und an einigen Stellen ist die TLS-Zertifikatsprüfung deaktiviert.
Details stehen in Abschnitt 10.1 des technischen Manuals. Das Repository sollte deshalb nicht öffentlich
gemacht werden, und die betroffenen Zugangsdaten sollten rotiert und in eine sichere Konfiguration
ausgelagert werden.
