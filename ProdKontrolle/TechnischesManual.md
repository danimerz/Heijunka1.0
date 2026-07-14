# Technisches Manual – Digitales Heijunka

## 1. Einleitung

Dieses Dokument beschreibt die technische Architektur, die Datenquellen, die Formulare/Klassen und die bekannten Altlasten der Anwendung "Digitales Heijunka" (VB.NET WinForms, Projektname im Code: `ProdKontrolle`). Es dient zwei Zwecken:

1. **Referenz für den geplanten Blazor-Rewrite** – welche Datenquellen, Abläufe und fachlichen Regeln müssen im Neubau berücksichtigt werden.
2. **Einarbeitungshilfe für Entwickler**, die direkt an diesem VB.NET-Code weiterarbeiten sollen.

Für laufende Performance-Optimierungen und deren Historie siehe separat **`Backlog.md`** im selben Ordner – dort sind alle bisherigen Fixes (WATS-Parallelisierung, XML-Caching, zwei behobene Abstürze) sowie offene Vorschläge dokumentiert. Dieses Manual fokussiert auf die **Gesamtarchitektur**.

Sicherungskopie des Stands vor Beginn der Performance-Arbeiten: `C:\Users\merzd\source\repos\ProdKontrolle_backup_2026-07-02\`.

---

## 2. Architektur-Überblick

- **Typ:** Windows Forms Desktop-Anwendung (.NET Framework 4.7.2), Deployment via **ClickOnce**.
- **Startpunkt:** `ProdKontrolle.My.MyApplication` (VB "Application Framework"), Hauptformular `Form1`.
- **UI-Struktur:** Ein zentrales Dashboard-Formular (`Form1`, ~4200 Zeilen) mit einem `DataGridView` als "Heijunka-Tafel" (eine Kachel/Zeile pro Auftrag+Vorgang), umgeben von ca. 30 Dialog-Formularen für Detailaktionen (Auftrag starten/rückmelden/beenden, Stückliste, Barcode-Etiketten, Support-Anfragen, Einstellungen, etc.).
- **Threading-Modell:** Vier `BackgroundWorker`-Instanzen in `Form1` (`BGW_Hejiunka` für die Dashboard-Aktualisierung, `BGW_HejiunkaImport` für den SAP-Import, `BGW_CloseForm` für die Schliess-Prüfung, `BGW_CheckUpdate` für ClickOnce-Update-Checks). Mehrere Timer steuern periodische Abläufe (siehe Abschnitt 7.4).
- **Datenhaltung:** Kein einheitliches Backend – die Anwendung kombiniert **vier separate SQL-Server-Datenbanken**, **zwei lokale Access-Dateien**, einen **Datei-basierten SAP-Export** (kein direkter SAP-Zugriff, kein SAP-Adapter), die **WATS-REST-API** und diverse **Textdateien als Konfigurations-/Ausnahmelisten-Ersatz**.
- **Bekannter Kernprozess "Aktualisieren":** Der aufwändigste und in dieser Session intensiv optimierte Ablauf ist das Neu-Laden der Heijunka-Tafel (Klick auf "Aktualisieren" oder Timer `T_WatsRefresh`). Siehe Abschnitt 7.3 und `Backlog.md`.

---

## 3. Technologie-Stack

| Bereich | Technologie |
|---|---|
| Sprache/Runtime | VB.NET, .NET Framework 4.7.2 |
| UI | Windows Forms, `System.Windows.Forms.DataVisualization` (Charts, z.B. OEE-Diagramm) |
| Deployment | ClickOnce (`System.Deployment`) – **veraltete, von Microsoft nicht mehr weiterentwickelte Technologie** |
| JSON | Newtonsoft.Json 12.x |
| MQTT | **zwei parallele Implementierungen:** `MQTTnet` 3.1.1 (eigene Klasse `Klassen\mqtt.vb`, allgemeiner Status-Broker) UND `M2Mqtt.Net` 4.3.0 (direkt in `Form1.vb` für den separaten "Incident"-Broker) |
| HTTP | `System.Net.Http` (WATS-API), eigener `HttpClient` |
| Barcode/QR | `zxing` 0.16.6 (Lesen, Kamera-Scan), `DataMatrix.net` (DMC-Code-Erzeugung), eigene `Code128Content.vb`/`Code128Rendering.vb` (Code-128-Erzeugung) |
| Kamera | `AForge`, `AForge.Video`, `AForge.Video.DirectShow` (Webcam-Zugriff für Scanner-Dialoge und Support-Screenshots) |
| PDF | `itextsharp` (Fehlerzettel-Formular ausfüllen/drucken) |
| Datenbankzugriff | Typisierte ADO.NET DataSets (`.xsd` + generierte `TableAdapter`), `System.Data.SqlClient` und `System.Data.OleDb` |
| Custom-Bibliotheken | `FaufAplaXml`, `PrinterDB` (firmeninterne, nicht in diesem Repo enthaltene Assemblies) |

---

## 4. Externe Systeme und Datenquellen

### 4.1 SAP (kein Live-Zugriff – reiner Datei-Import)
Es gibt **keine direkte SAP-Verbindung** (kein RFC/BAPI). Stattdessen:
- **SQ00-Textexport:** Ein tabgetrennter Export (`My.Settings.ExportPfadRemote`, Netzwerkfreigabe) wird periodisch nach lokal kopiert, die ersten Kopfzeilen beim Parsen übersprungen und zeilenweise in das rein In-Memory-gehaltene DataSet `SAP.DT_SQ00_Import_FAUF` eingelesen (`Form1.ImportHeijunkaSQ00`, seit dieser Session robuster gegen fehlerhafte/leere Exportdateien, siehe `Backlog.md`). Ein zweiter, nie erreichbarer Importpfad `ImportHeijunkaDownload` (CSV-Variante, `ExportPfadRemoteDownload`) hing an einem dauerhaft unsichtbaren Button und wurde entfernt.
- **FAUF-/APLA-XML-Dateien:** Pro Auftrag (`FAUF`) und pro Material/Stückliste (`APLA`) liegen einzelne XML-Dateien auf einer Netzwerkfreigabe (`My.Settings.PfadFAUFxml`, Fallback `PfadFAUFxmlAlternativ`). Diese werden über `Klassen\SAP_XML.vb` gelesen und geparst (`ReadXML2DS`). **Seit dieser Session wird das Ergebnis gecacht** (Dateipfad + Änderungsdatum als Schlüssel) – vorher wurde dieselbe Datei pro Auftragszeile bis zu 10× neu geparst (siehe `Backlog.md`, Punkt 2).
- **SSN-ASN-Matchtable:** Eine Access-Datei (`SSN-ASN_MatchTable.mdb`) wird ebenfalls periodisch von einer Netzwerkfreigabe lokal kopiert (`DownloadSsnAsnTable`).

### 4.2 WATS (Testsystem, First-Pass-Yield/Rückmeldedaten)
- REST-API unter `https://fz.sbt.siemens.com/wats/api/...` (`Klassen\Wats.vb`), Authentifizierung über einen statischen Basic-Auth-Header (`My.Settings.WATSAPIKEY`, Base64-kodiert, **kein echtes Secret-Management**).
- Seit dieser Session: gemeinsam genutzter `HttpClient`, `ServicePointManager.DefaultConnectionLimit` erhöht, Abfragen pro Aktualisierung parallelisiert und pro (Auftrag/Station/TestOP/Menge) dedupliziert gecacht (siehe `Backlog.md`).
- Separate Report-XML-Auswertung in `FehlerWATS.vb` (Fehlerdetails je Gerät) – dort **pro fehlgeschlagenem Gerät ein eigener HTTP-Request**, potenzielles weiteres Performance-Thema (nicht Teil der bisherigen Optimierung).

### 4.3 SQL-Server-Datenbanken (4 Stück, siehe Tabelle in Abschnitt 6.1)
- **Heijunka** (ch021095) – Kernzustand der Anwendung: Linienkonfiguration, FAUF-Status, Produktionskontrolle-Einträge, Rückmeldestatus, v-Check, Kommentare, Protokoll, Dashboard-Kennzahlen, SMT-Rüstung/LP-Rüstung/-Check, Ausschuss, Incidents.
- **OPM_OEE** (ch021094) – Stillstandszeiten/OEE-Kennzahlen sowie eine "aktueller Auftrag je Linie"-Tabelle; auch PET-Mitarbeiterstammdaten laufen (etwas unerwartet) über diese Verbindung.
- **MatchTables** (ch021094) – SAP-Stammdaten für die SMT-Programmübersicht (`PU_tbl_Stamm`); zusätzlich in einem separaten Dataset ein SSN/ASN-Mapping mit **fehlerhaft zugeordnetem Connection-String** (siehe Abschnitt 5, `MatchTablesDataSet.xsd`).
- **DruckerDB** (Ch021094\SQL01) – Etikettendruck-Konfiguration, angesprochen über die externe `PrinterDB`-Bibliothek.

### 4.4 Access-Datenbanken (Legacy)
- `Stammdaten.accdb` und `SSN-ASN_MatchTable.mdb`, lokal unter `C:\Temp\` erwartet (von Netzwerkfreigaben kopiert). Wirken wie Vorläufer der heutigen SQL-Server-Lösung, teils noch als Fallback/Parallelstruktur vorhanden.

### 4.5 MQTT (zwei getrennte Broker/Bibliotheken)
- **Allgemeiner Status-Broker** (`My.Settings.MQTT_Server_IP`): eigene Klasse `Klassen\mqtt.vb` (MQTTnet), sendet Status/Linie/SAP-Version/Heartbeat. **Ist aktuell in `Form1_Load` auskommentiert** (`mqtt_init()`, `mqtt_Send_Startup()`) – die Telemetrie läuft also im Produktivbetrieb aktuell nicht, obwohl der Code vollständig vorhanden ist.
- **Incident-Broker** (`My.Settings.incidentMqtt`, `iotservervm1.sbt.siemens.com`): direkt in `Form1.vb` über die ältere `M2Mqtt.Net`-Bibliothek, mit **hartcodierten Zugangsdaten** (`"MFZUG"`, `"6300-Zug"`). Dieselben hartcodierten Zugangsdaten finden sich nochmals in `frm_supportAnfrage.vb`.
- Payload-Modell für Incidents unter `Klassen\mqtt_payload\` (`Incident.vb`, `tags.vb`, `fields.vb`, `attachments.vb`) – JSON-Struktur für die MQTT-Übertragung von Störungsmeldungen.

### 4.6 IH-Tool REST-API (Incident Management)
- `https://iotservervm1.sbt.siemens.com:8085/api/rest/ihtool/stations`, Token-Auth über `My.Settings.ihToolApiKey` (JWT). Genutzt in `frm_supportAnfrage.vb` zur Stationsauswahl. **TLS-Zertifikatsprüfung ist dort komplett deaktiviert** (`CustomServerCertificateValidation` gibt immer `True` zurück) – Sicherheitsrisiko.

### 4.7 E-Mail (SMTP)
- `GlobaleFunktionen.sendMail` über `smtp.siemens.com`, Zugangsdaten aus `My.Settings.emailUsername`/`emailPassword` (Klartext-Passwort im Settings-File).

### 4.8 Dateibasierte "Konfiguration" (Textdateien statt Datenbank/echter Konfiguration)
Ein wiederkehrendes Architekturmuster: viele fachliche Ausnahmelisten liegen als einfache Text-/INI-Dateien auf Netzwerkfreigaben statt in einer Datenbank oder Anwendungskonfiguration:
- Werkskalender, WATS-Ausnahmeliste, v-Check-Kontrollliste, Lagerort-Ausnahmen, FAUF-Start-Infotexte, ASM/SAP-Abgleichliste, Autostart-/Stations-INI-Dateien.
- Seit dieser Session werden die am häufigsten in Schleifen gelesenen davon gecacht (`GlobaleFunktionen.ReadAllLinesCached`, siehe `Backlog.md`).

---

## 5. Datenmodell (typisierte DataSets)

| DataSet (.xsd) | Tabellen | Connection-String-Setting | Verbindungstyp | Bemerkung |
|---|---|---|---|---|
| `DS_ProdKontrolle` | tbl_Linie, tbl_FAUF_Status, tbl_ProdKontrolle, tbl_SMT_Ruestung, tbl_Rueckmelden_Status, tbl_vcheckKontrolle, tbl_Kommentar, tbl_Protkoll, tbl_DashboardDaten, tbl_lp_ruest, tbl_lp_check, tbl_ausschuss | `HeijunkaConnectionString` | SQL Server | Größtes/zentrales DataSet der Anwendung |
| `DS_OPM_OEE` | tbl_StillstandszeitenSumme, T_LinieAuftragAktuell, DataTable1 | `OPM_OEEConnectionString` bzw. `...1` (uneinheitlich je TableAdapter) | SQL Server | |
| `DS_Incident` | tbl_IncidentState, tbl_IncidentPrio, tbl_Incident | `HeijunkaConnectionString1` | SQL Server | Eigene, redundante Verbindungszeichenfolge zur selben DB wie `DS_ProdKontrolle` |
| `DS_vCheck` | HJ_GetOperationInfo | `HeijunkaConnectionString` | SQL Server | |
| `DS_PET_Mitarbeiter` | T_PET_Mitarbeiter, T_PET_VorNachname | `OPM_OEEConnectionString1` | SQL Server | Nutzt trotz Namens die OEE-Verbindung |
| `MatchTablesDataSet` | SSN_ASN_Tab | `SSN_ASN_MatchTableConnectionString` | **Bug:** Code nutzt `SqlConnection`, der referenzierte Connection-String ist aber ein Access/OleDb-String → würde zur Laufzeit vermutlich fehlschlagen | Vermutlich toter/nie erfolgreich getesteter Pfad |
| `ProgrammübersichtDataSet` | PU_tbl_Stamm | `SMTConnectionString1` | SQL Server | Schema verweist zusätzlich auf 3 weitere, ungenutzte Connection-Strings |
| `_SSN_ASN_MatchTableDataSet` | SSN_ASN_Tab | `SSN_ASN_MatchTableConnectionString` | OleDb/Access (korrekt verwendet) | Vermutlich das "echte" Gegenstück zu `MatchTablesDataSet` |
| `DS_Ausschuss` | – (leer) | – | – | Leeres Skeleton-DataSet, nie befüllt; echte Ausschuss-Tabelle liegt in `DS_ProdKontrolle.tbl_ausschuss` |
| `SAP` | DT_SQ00_Import_FAUF, DT_Heijunka, DT_RS | – (kein DB-Zugriff) | reines In-Memory-DataSet | Wird ausschliesslich per Datei-Import befüllt (siehe Abschnitt 4.1) |

**Für den Rewrite wichtig:** Mehrere Connection-String-Settings sind Duplikate/Varianten derselben Zieldatenbank (`HeijunkaConnectionString` vs. `...1`, `OPM_OEEConnectionString` vs. `...1`) – das ist historisch durch wiederholte TableAdapter-Assistenten-Läufe entstanden, kein bewusstes Design. Im Blazor-Rewrite (siehe Memory: 3 EF-Core-DbContexts für ch021095/ch021094) sollte das konsolidiert werden.

---

## 6. Konfiguration (`My.Settings` / `app.config`)

### 6.1 Connection-Strings

| Setting | Zieldatenbank/-datei | Provider | Passwort im Klartext |
|---|---|---|---|
| `HeijunkaConnectionString` / `...1` | Heijunka (ch021095) | SqlClient | ja |
| `OPM_OEEConnectionString` / `...1` | OPM_OEE (ch021094) | SqlClient | ja |
| `MatchTablesConnectionString` / `...1` | MatchTables (ch021094) | SqlClient | ja (unbenutzte Settings) |
| `SMTConnectionString` | C:\Temp\Stammdaten.accdb | OleDb/Access | nein |
| `SMTConnectionString1` | MatchTables (ch021094) | SqlClient | ja |
| `SSN_ASN_MatchTableConnectionString` | C:\Temp\SSN-ASN_MatchTable.mdb | OleDb/Access | nein |
| `ProdKontrolleConnectionString` | nicht befüllt/unbenutzt | – | – |
| `PrinterDBConnectionString` | DruckerDB (Ch021094\SQL01) | SQLOLEDB | ja |

**Alle SQL-Server- und E-Mail-Zugangsdaten sowie der WATS-API-Key liegen im Klartext (bzw. nur Base64, keine echte Verschlüsselung) in `Settings.settings`/`Settings.Designer.vb` bzw. `app.config`.** Das ist der zentrale Treiber für die geplante Windows-Auth-Umstellung im Blazor-Rewrite.

### 6.2 Wichtigste Settings nach Themenbereich

- **SAP-Import:** `ExportPfadRemote`, `ExportPfadLocal`, `ExportPfadRemoteDownload`, `PfadFAUFxml`, `PfadFAUFxmlAlternativ`, `letzerSAPimport`, `PfadTCAblage`
- **Ausnahmelisten/Konfigurationsdateien:** `LagerOrt_Ausnahmen`, `PfadLagerortAusnhamen`, `vcheckkontrollePfad`, `ausnahmelistePfad`, `AsmSapListe`, `PfadWerkskalender`, `PfadFaufInfo`, `PfadAutoStartIni`, `PfadStationIni`, `ChecklistePfad`, `Pfad_StndW`, `Pfad_V4`, `Pfad_PA`, `LernVideoPfad`, `ChangeLogFile`
- **WATS:** `WatsReportXmlPath`, `WatsUutReportPath`, `WatsHighVolumePath`, `WatsVersionPath`, `WATSAPIKEY`, `G_LinieWats`
- **Incident-Management:** `incidentMqtt`, `ihToolApiKey`
- **MQTT (allgemein):** `MQTT_Server_IP`
- **E-Mail:** `SupportEmail`, `SupportAktivieren`, `emailUsername`, `emailPassword`
- **Drucker/Label:** `Printer_Anlage`, `Printer_Station`, `Printer_LabelArt`, `Printer_Referenz`, `Printer_Aktivieren`, `Priter_Z1..Z6`, `PrinterBC_Z1..Z6`, `PrinterDBConnectionString`
- **Allgemeine Anzeige-/Verhaltens-Flags:** `Linie`, `UpdateInterval`, `autoUpdate`, `Systemstatus`, `FormWith`, `FormHight`, `DGV_Höhe`, `SortHeijunka`, `FAUF_Start`, `FaufNichtAnzeigen`, `FaufEndDatum`, `showDMC`, `showLine`, `showVrgTxt`, `showLPNr`, `ASN_Anzeigen`, `LoAnzeigen`, `VorgabezeitAnzeigen`, `sollistHalbfabrikate`, `MultiFmProdKont`, `Logging`, `Kommentar`, `Fehlerzettel`, `Checkliste`, `vcheck_scanner`, `G_vCheckVorhanden`, `SoftwareVersion`

---

## 7. Programmablauf / Kernprozesse

### 7.1 Startsequenz
1. `MyApplication` (ApplicationEvents.vb) – Startup-Event registriert seit dieser Session globale Crash-Diagnose-Handler (siehe Abschnitt 9.3).
2. `Form1_Load` → Fenstergrösse aus Settings, Titel setzen, `Init()` aufrufen. MQTT-Initialisierung ist **auskommentiert** (nicht aktiv).
3. `Init()`: SQL-Verfügbarkeit testen (nur Konsolen-Log), Linien-ComboBox aus DB füllen, falls keine Linie konfiguriert → `LinieAuswaehlen`-Dialog, Datum auf heute setzen, ggf. Changelog-Dialog bei ClickOnce-Erstinstallation, abschliessend `SAP_Import()`.

### 7.2 SAP-Import-Zyklus
- Ausgelöst durch: App-Start (`Init()`), Menüpunkt "SAP Daten laden", `FileSystemWatcher FSW_SAP_Export` (Export-Datei geändert → verzögerter Reimport mit 15-31s Zufalls-Jitter), Timer `T_CheckSAPimport` (Polling-Fallback, falls FileSystemWatcher das Netzlaufwerk-Event verpasst).
- Läuft in `BGW_HejiunkaImport`: SSN-ASN-Matchtable kopieren, SQ00-Export kopieren/parsen, `SAP.DT_SQ00_Import_FAUF` neu befüllen.
- Nach Abschluss: `HejiunkaAnzeigen()` wird automatisch angestossen.

### 7.3 Aktualisierungs-Zyklus "Heijunka Anzeigen" (zentraler, meistoptimierter Ablauf)
Ausführliche Performance-Historie in `Backlog.md`. Kurzfassung des heutigen Ablaufs:
1. **`HejiunkaAnzeigen()`** (UI-Thread): Timer stoppen, UI sperren, `SAP.DT_Heijunka` aus `SAP.DT_SQ00_Import_FAUF` neu zusammenstellen (inkl. `GetLastWorkDay`, jetzt textdatei-gecacht), grobe Zeilenzählung, `BGW_Hejiunka.RunWorkerAsync(...)` starten.
2. **`BGW_Hejiunka_DoWork`** (Hintergrund-Thread, bewusst **kein** `Async Sub` mehr, siehe Abschnitt 9.2): WATS-Daten für alle benötigten Aufträge vorab parallel + gecacht laden, dann pro Zeile SAP-XML-Werte (gecacht), DB-Abgleiche (ProdKontrolle/Incident/v-Check/Kommentar), Statuskennzahlen berechnen (Rückstände/FPY/FAUF-Status/OEE, `FAUF_Status`-Volltabelle nur bei Bedarf geladen).
3. **`BGW_Hejiunka_RunWorkerCompleted`** (UI-Thread): `DataGridView` befüllen (inkl. Status-Kreis-Symbole, seit dieser Session mit Bild-Cache statt Netzwerk-Neuladen pro Zelle), Kennzahlen-Labels setzen.

### 7.4 Timer-Übersicht

| Timer | Zweck |
|---|---|
| `T_PB` | Setzt Fortschrittsbalken nach Abschluss zurück |
| `T_WatsRefresh` | Periodisches Neuladen der Heijunka-Tafel (`My.Settings.UpdateInterval`) |
| `T_FW_SAP_import` | Verzögerter SAP-Reimport nach FileSystemWatcher-Ereignis |
| `T_neuerTag` | Prüft alle 15 Min. auf Tageswechsel; löst `Init()` aus und leert seit dieser Session den SAP-XML-Cache |
| `T_CheckSAPimport` | Polling-Fallback für SAP-Export-Änderungen |
| `T_UpdateCheck` | ClickOnce-Update-Prüfung |

### 7.5 Auftrags-Workflow (wichtigste Button-Funktionen in `Form1.vb`)
`FAUF_Start` (Auftrag starten, inkl. SMT-PCB-Scan-Verifikation), `FAUF_Ruckmelden`, `FAUF_Beenden` (nur ohne WATS/Ausnahmeliste relevant), `FAUF_Prodkontrolle`, `FAUF_Stuli` (Stückliste anzeigen), `VCheckKontrolle`, `Dokumente`, `LpAbrufen`, `ProdKontErledigen`.

---

## 8. Formulare (Referenz)

### 8.1 Form1.vb – Hauptdashboard
Zentrales Formular mit der Heijunka-Tafel (`DataGridView DGV_FAUF`), Linienauswahl, Datumsnavigation, Kennzahlen-Anzeige (Soll/Ist/FPY/OEE/Rückstände) und Menü für alle Auftragsaktionen. Enthält die vier BackgroundWorker (Abschnitt 2), sämtliche Timer, zwei FileSystemWatcher und die komplette Statuskreis-Rendering-Logik. **Größte Datei des Projekts (~4200 Zeilen).** Enthält mehrere offensichtlich nicht mehr genutzte Testbereiche (`#Region "Testing"`, `"HeijunkaAysinc"`, `"TEST"` mit `Button1_Click_1` bis `_6`) – Aufräumkandidaten für den Rewrite, keine produktive Funktion erkennbar.

### 8.2 v-checkKontrolle.vb
QR-Code-Scan-Dialog (Kamera via AForge, Dekodierung via zxing) zur v-Check-Materialkontrolle. Nutzt `BackgroundWorker` für die QR-Dekodierung parallel zum Live-Kamerabild.

### 8.3 Weitere Formulare (alphabetisch)

| Formular | Zweck | Datenquellen | Wichtigste Auffälligkeit |
|---|---|---|---|
| `Changelog.vb` | Zeigt Änderungsprotokoll + Versionsnummer | Textdatei (`ChangeLogFile`), ClickOnce-API | Keine Fehlerbehandlung bei fehlender Datei |
| `Einstellungen.vb` | Zentrales Einstellungsformular (fast alle `My.Settings`) | `My.Settings`, `Tbl_LinieTableAdapter`, `UpdateHandler` | WATS-API-Key-Änderung wird geladen aber **nie gespeichert** (auskommentierte Zeile); Debug-Ausgabe potenziell sensibler Werte |
| `FehlerWATS.vb` | Fehlgeschlagene Prüfschritte eines Auftrags aus WATS | WATS-API (Report-XML) | Pro fehlgeschlagenem Gerät ein eigener HTTP-Request in Schleife |
| `Frm_Barcodevb.vb` | Zentrales Barcode/Etiketten-Formular (FAUF/SMT/Auftragskopf-Modus) | SQL (SMT-Rüstdaten), SAP-XML, Textdatei Lagerort-Ausnahmen | Sehr grosse monolithische Klasse, kein Try/Catch beim Textdatei-Zugriff |
| `frm_AenderungDetail.vb` | Zeigt SAP-Änderungstext eines Auftrags | `GlobaleFunktionen.GetAnwStatusAenderung` | Ungenutzter iTextSharp-Import; fragiles Marker-basiertes Text-Parsing |
| `frm_ausschuss.vb` | Ausschussmengen buchen/korrigieren | SQL (`tbl_ausschuss`), SAP-Stückliste | **Logikbug:** PLO-Filter durch Operatorpriorität wirkungslos (`Not "1027" Or "1028"`) |
| `frm_Dok.vb` | Dokumentenliste zu Auftrag/Material | Übergebene DataTable (Quelle: SAP-XML) | `Process.Start` auf Link ohne Validierung |
| `frm_Info.vb` | Generischer Info-Dialog | – | Unauffällig |
| `frm_inputBox.vb` | Generischer Eingabedialog | – | Unauffällig |
| `frm_FaufSearch.vb` | SAP-Auftragskopf-/Vorgangssuche | SAP-XML (mehrere Tabellen) | Totes `Auftragshandler`-Feature (auskommentiert) |
| `frm_Passwort.vb` | Passwortschutz (z.B. für Einstellungen) | – | **Sicherheitsproblem:** Passwort `"Heijunka2020"` hartcodiert im Klartext |
| `frm_pcbAbruf.vb` | Bestätigung/Anzeige LP-Nummer | – | Unauffällig |
| `frm_print.vb` | Etikettendruck (P-Touch/QL) | `PrinterDB`-Bibliothek | Minimales UI-Feedback während Druck |
| `frm_ProdKontrolle.vb` | Kontrolleintrag/Fehlergrund erfassen, PDF-Fehlerzettel drucken | SQL, SAP-Stückliste, PDF (iTextSharp) | Schleifen-Insert bei `MultiFmProdKont`, PDF-Druck-Heuristik fragil |
| `frm_ProdKontrolle_Detail.vb` | Offene Kontrolleinträge, Einzel-/Sammel-Erledigung | SQL | **Bug:** `rowIndex` nur bei Zell-Klick gesetzt, sonst evtl. falsche Zeile |
| `frm_ProductSearch.vb` | (laut Name Produktsuche) | – | Praktisch leer/unfertig, keine Such-Logik implementiert |
| `frm_Ruckmelden.vb` | Rückmeldung je Behälter (dynamische Symbole+Barcode) | SQL (`tbl_Rueckmelden_Status`) | Komplett dynamischer UI-Aufbau zur Laufzeit, viele Magic Numbers |
| `frm_Ruckstand.vb` | Rückstandsliste je Linie | SQL (`tbl_ProdKontrolle`) | `BackgroundWorker` deklariert aber alle Handler leer, nie gestartet |
| `frm_scanPcb.vb` | PCB-Scan-Verifikation | SQL (`tbl_lp_check`) | Kein Trim/Case-Insensitive-Vergleich beim Scan-Abgleich |
| `frm_Stueckliste.vb` | Stückliste anzeigen, Positionen abhaken/Fehlmaterial melden | SAP-XML, Textdatei Lagerort-Ausnahmen, SQL | Kein Fehler-Handling beim Textdatei-Parsing (IndexOutOfRange möglich) |
| `frm_supportAnfrage.vb` | Support-/Störungsmeldung mit Foto, MQTT+SQL-Versand | SQL (Incident-Tabellen), IH-Tool-REST-API, MQTT, Kamera | **Sicherheitsproblem:** TLS-Zertifikatsprüfung deaktiviert; hartcodierte MQTT-Zugangsdaten |
| `frm_Wochenansicht.vb` | Wochenansicht FPY (WATS+SAP) | WATS-API, SAP-DataSet | Kernlogik nie aufgerufen, Button-Code auskommentiert, hartcodierter Arbeitsplatz |
| `LinieAuswaehlen.vb` | Linienauswahl beim Erststart | SQL (`tbl_Linie`) | Unaufgeräumter Standard-VS-Kommentar |
| `OEEDetails.vb` | OEE-Detaildaten als Diagramm | SQL (`tbl_StillstandszeitenSumme`) | Farbzuordnung über hartcodierte deutsche Textlabels |
| `Splash.vb` | Splash-Screen | – | Keine eigene Logik (nur Designer) |
| `Toggle.vb` | Custom-UserControl (Toggle-Switch) | – | Reine UI-Komponente, unauffällig |

---

## 9. Klassen (Referenz, Ordner `Klassen\`)

### 9.1 Bereits im Rahmen der Performance-Arbeit im Detail behandelt (siehe `Backlog.md`)
- **`GlobaleFunktionen.vb`** – Sammlung fachlicher Hilfsfunktionen (SAP-XML-Auswertung, Lagerort, Werkskalender, E-Mail-Versand, etc.). Enthält seit dieser Session `ReadAllLinesCached`.
- **`SAP_XML.vb`** – Liest/parsed FAUF-/APLA-XML-Dateien; seit dieser Session mit statischem, dateizeitstempel-validiertem Cache.
- **`Wats.vb`** – WATS-REST-API-Client; seit dieser Session mit wiederverwendetem `HttpClient`.
- **`mqtt.vb`** – MQTTnet-basierter Client für den allgemeinen Status-Broker (aktuell nicht aktiv genutzt, siehe 4.5).
- **`logging.vb`** – Einfaches Text-Datei-Logging (`C:\LocalData\HeijunkaLog.txt`), asynchron (Fire-and-Forget).

### 9.2 Weitere Klassen

| Klasse | Zweck | Auffälligkeiten |
|---|---|---|
| `Code128Content.vb` / `Code128Rendering.vb` | Code-128-Barcode-Erzeugung (Encoding + Bild-Rendering) | Riesige, unübersichtlich formatierte Lookup-Tabelle in Rendering; ansonsten sauber |
| `copyToDatatable.vb` | Extension-Methode `ToDataTable(Of T)` via Reflection | Kein Caching der `PropertyInfo` – Performance-Thema bei häufigem Aufruf mit grossen Listen |
| `Feiertage.vb` | Berechnung beweglicher Feiertage (Gaußsche Osterformel) | **Locale-abhängiges Datums-Parsing** (`DateAdd` mit String-Datum) – dieselbe Fehlerklasse wie der in dieser Session behobene Rechnerabhängigkeits-Bug in `RueckstandProLinie` |
| `HeijunkaAnzeige.vb` | Minimales DTO (nur `Material`-Property) | Public Backing-Field, kaum Mehrwert |
| `iniHandling.vb` | INI-Dateizugriff über `kernel32.dll` P/Invoke | Fragile Interop-Deklaration bei `DeletePrivateProfileSection`; `MsgBox` statt Exceptions; TOCTOU-Risiko beim Schreiben |
| `UpdateHandler.vb` | ClickOnce-Update-Prüfung/-Installation | Nutzt veraltete `System.Deployment`-API; Fehler beim Update-Check werden stumm verschluckt |
| `mqtt_payload\Incident.vb`, `tags.vb`, `fields.vb`, `attachments.vb` | JSON-DTOs für MQTT-Incident-Übertragung | Uneinheitliche `JsonProperty`-Attributnutzung; `attachments` unterstützt nur ein Einzelobjekt, kein Array |
| `ApplicationEvents.vb` (Projekt-Root) | **Seit dieser Session:** globale Crash-Diagnose (`TaskScheduler.UnobservedTaskException`, `AppDomain.UnhandledException`, `My.Application.UnhandledException`), synchrones Notfall-Logging | Siehe Abschnitt 9.3 |
| `Klassen\ApplicationEvents.vb` | Zweite, inhaltsgleiche aber **leere** Partial-Class-Datei (Duplikat) | Aufräumkandidat – die eigentliche Logik liegt in der Root-Datei, dieses Duplikat sollte entfernt oder zusammengeführt werden, um Verwirrung zu vermeiden |

### 9.3 Absturz-Diagnose (Ergänzung dieser Session)
`ApplicationEvents.vb` (Projekt-Root) registriert beim Start drei Handler:
- `TaskScheduler.UnobservedTaskException` mit `e.SetObserved()` – verhindert den in .NET Framework typischen Absturz durch "unobserved" Task-Exceptions (Rethrow auf dem Finalizer-Thread ohne jede Meldung).
- `AppDomain.CurrentDomain.UnhandledException` und `My.Application.UnhandledException` – protokollieren **synchron** (nicht über die asynchrone `logging`-Klasse, die bei einem Absturz evtl. nicht mehr fertig schreibt) den vollen Exception-Text nach `C:\LocalData\HeijunkaLog.txt`.

Damit wurden zwei konkrete, vorbestehende Bugs gefunden und behoben (Details in `Backlog.md`, Punkte 10-11): ein kultur-abhängiger Datumsvergleich in `RueckstandProLinie` sowie ein `NullReferenceException` bei leerem DataGridView.

---

## 10. Bekannte Probleme, technische Schulden und Sicherheit

### 10.1 Sicherheit
- Hartcodierte/Klartext-Zugangsdaten: SQL-Server-Passwörter (`app.config`/Settings), E-Mail-Passwort, MQTT-Zugangsdaten (`frm_supportAnfrage.vb`, `Form1.vb`), Anwendungspasswort `"Heijunka2020"` (`frm_Passwort.vb`), WATS-API-Key (nur Base64, kein echtes Secret-Management).
- Deaktivierte TLS-Zertifikatsprüfung in `frm_supportAnfrage.vb` (IH-Tool-API) und in `Wats.vb` (`ServerCertificateCustomValidationCallback` gibt immer `True` zurück).
- Debug-Ausgabe potenziell sensibler Settings-Werte in `Einstellungen.vb`.

### 10.2 Bekannte Logikbugs
- `frm_ausschuss.vb`: PLO-Ausschlussfilter durch Operatorpriorität wirkungslos.
- `frm_ProdKontrolle_Detail.vb`: `rowIndex` nicht zuverlässig gesetzt.
- `MatchTablesDataSet`: SqlConnection mit Access/OleDb-Connection-String kombiniert (vermutlich nie erfolgreich lauffähig).
- Zwei per Session behobene Bugs: kulturabhängiges Datums-Parsing in `RueckstandProLinie`, `NullReferenceException` bei leerem Dashboard-Grid (siehe `Backlog.md`).

### 10.3 Toter/unfertiger Code
- `Form1.vb`: Regionen "Testing", "HeijunkaAysinc", "TEST" mit mehreren nicht mehr referenzierten `Button1_Click_*`-Handlern.
- `frm_Wochenansicht.vb`, `frm_Ruckstand.vb`, `frm_ProductSearch.vb`, `frm_FaufSearch.vb` (Auftragshandler-Feature): jeweils auskommentierte oder nie ausgelöste Kernlogik.
- `Splash.vb`: keine eigene Logik.
- Zweites, leeres `Klassen\ApplicationEvents.vb`.
- MQTT-Statustelemetrie (`mqtt_init`, `mqtt_Send_Startup`) aktuell auskommentiert/inaktiv.

### 10.4 Performance
Vollständig in `Backlog.md` dokumentiert (WATS-Parallelisierung, SAP-XML-Caching, Duplikat-Aufrufe entfernt, zwei UI-Freezes behoben, unnötiger voller Tabellendownload vermieden). Ergebnis: Aktualisierungszeit von ~41s auf ~7-8s reduziert. Noch offen: Verkleinerung/Filterung von `dbo.tbl_FAUF_Status`, gleiche Behandlung des `HejiunkaAnzeigen`-Async-Sub-Musters wie bei `BGW_Hejiunka_DoWork`.

---

## 11. Build & Deployment

- **Build:** MSBuild (`DigitalesHeijunka.vbproj`), Konfigurationen Debug/Release.
- **Startobjekt:** `ProdKontrolle.My.MyApplication` (`<StartupObject>` im vbproj).
- **Deployment:** ClickOnce – Update-Prüfung über `UpdateHandler.vb` und Timer `T_UpdateCheck`, Versionsnummer in `My.Settings.SoftwareVersion` bzw. über `ApplicationDeployment.CurrentDeployment.CurrentVersion` bei Netzwerk-Deployment.
- **Lokales Log:** `C:\LocalData\HeijunkaLog.txt` (fachliches Logging + seit dieser Session Absturz-Diagnose).

---

## 12. Hinweise für den Blazor-Rewrite

- **Zu übernehmende fachliche Verträge:** SAP-XML-Dateiformat (FAUF/APLA-Tabellenstruktur, siehe `SAP_XML.vb`/`GlobaleFunktionen.vb`), SQ00-Textexport-Spaltenreihenfolge (`Form1.SAP_Fields`), WATS-REST-API-Vertrag (`Wats.vb`, `Filter`-Klasse), DB-Schema der 4 SQL-Server-Datenbanken (Abschnitt 5).
- **Bewusst zu entscheiden, nicht blind zu kopieren:** die zwei parallelen MQTT-Implementierungen (nur eine im Rewrite nötig), die mehrfachen redundanten Connection-Strings, die dateibasierten Ausnahmelisten (Kandidat für echte DB-Tabellen im Rewrite), das Access-DB-Fallback (soll laut Plan nur "temporär via IAccessLegacyService" übernommen werden).
- **Sicherheitslücken NICHT übernehmen:** hartcodierte Zugangsdaten, deaktivierte TLS-Prüfung, Klartext-Anwendungspasswort – im Rewrite ohnehin durch Windows-Auth/Secret-Management ersetzt (siehe Projekt-Memory).
- **Als Referenz für Kernlogik gut geeignet:** die in `Backlog.md` dokumentierten, jetzt bereinigten und mit Zeitmessung versehenen Kernabläufe (`BGW_Hejiunka_DoWork`, `RueckstandProLinie`, WATS-Abfragelogik) – dort ist die fachliche Absicht durch die Aufräumarbeit klarer erkennbar als im ursprünglichen Code.
