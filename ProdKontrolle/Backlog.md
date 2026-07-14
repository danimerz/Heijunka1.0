# Backlog – Performance-Optimierung "Aktualisieren"

Sicherungskopie des Ausgangszustands (vor allen Änderungen dieser Session):
`C:\Users\merzd\source\repos\ProdKontrolle_backup_2026-07-02\`

## Ergebnis

Gesamtzeit für "Aktualisieren" (Klick bis DGV fertig befüllt):

| Zeitpunkt | Linie mit WATS (~19 Zeilen) | Linie ohne WATS (~5 Zeilen) |
|---|---|---|
| Vor Optimierung | ~41'445 ms | – |
| Nach allen Änderungen | ~7'767 ms | ~8'367 ms |

Faktor ~5x schneller. Restlicher Flaschenhals bei Linien ohne WATS ist bekannt und dokumentiert (siehe unten, Punkt 1 im Ausblick).

## Was umgesetzt wurde

### 1. WATS-Abfragen parallelisiert (`Klassen/Wats.vb`, `Forms/Form1.vb`)
- `HttpClient`/`HttpClientHandler` werden einmalig erzeugt und wiederverwendet statt pro Aufruf neu (Voraussetzung für Parallelität, vermeidet Socket-Erschöpfung).
- `ServicePointManager.DefaultConnectionLimit` von Standard 2 auf 20 erhöht – ohne das war die Parallelisierung wirkungslos, da .NET Framework sonst intern auf 2 gleichzeitige Verbindungen pro Server drosselt.
- Alle WATS-Abfragen einer Aktualisierung werden vorab gesammelt, doppelte (gleicher Auftrag/Station/TestOP/Menge) dedupliziert, und mit maximal 6 gleichzeitigen Requests (`SemaphoreSlim`) parallel geladen und gecacht, statt einzeln nacheinander blockierend abgefragt zu werden.
- Live-Fortschrittsanzeige während der WATS-Phase (vorher stand die Anzeige während dieser Phase still).
- Fallback auf Einzelabfrage bei Cache-Miss bleibt erhalten (inkl. Log-Meldung, falls das je auftritt – bisher nie beobachtet).

### 2. SAP-XML-Dateien gecacht (`Klassen/SAP_XML.vb`)
- `ReadXML2DS` cached geparste XML-Dateien (Schlüssel: Dateipfad, validiert über Datei-Zeitstempel `LastWriteTimeUtc`) – Cache ist statisch/geteilt über alle Formulare hinweg.
- Vorher wurde dieselbe FAUF-/APLA-XML-Datei pro Auftragszeile ca. 9-10x unabhängig voneinander neu von der Netzwerkfreigabe gelesen und geparst (jede der ~15 `Get*`-Funktionen in `GlobaleFunktionen.vb` einzeln).
- `ReadXML2DT` delegiert jetzt an `ReadXML2DS` (vorher eigener, unabhängiger Lesevorgang).
- `SAP_XML.ClearCache()` wird beim täglichen Tageswechsel (`T_neuerTag_Tick`) aufgerufen, damit der Cache nicht unbegrenzt wächst.
- **Wirkung:** "Restliche Zeilen-Schleife" ging von ~128s auf ~2.7-3.9s für ~19 Zeilen zurück (zusammen mit Punkt 4).

### 3. Redundante Aufrufe entfernt
- `GetFaufQty(FaufPfad)` wurde 3-4x pro Zeile mit identischem Ergebnis aufgerufen → auf 1x reduziert (Variable wiederverwendet).
- `GetAuftragZeiten(r("Auftrag"))` wurde 2x hintereinander identisch aufgerufen → auf 1x reduziert.
- `RueckstandProLinie()` wurde 2x aufgerufen (für `AnzahlDC` und `AnzahlBG` getrennt), obwohl beide Werte schon in einem Aufruf berechnet werden → auf 1x reduziert.

### 4. UI-Freeze behoben: Vorab-Zählung auf UI-Thread (`Forms/Form1.vb`, `HejiunkaAnzeigen`)
- Vor dem Start des BackgroundWorkers lief auf dem UI-Thread eine Schleife, die pro Zeile dieselbe teure SAP-XML-Auswertung nochmal machte, nur um zu zählen ob Daten vorhanden sind → fror die UI für mehrere Sekunden ein.
- Ersetzt durch eine günstige `qry.Count()` (keine XML-Zugriffe mehr). Die exakte Filterung passiert weiterhin unverändert innerhalb des BackgroundWorkers.
- **Trade-off:** im (seltenen) Grenzfall, dass wirklich alle Zeilen durch den "gestern schon komplett rückgemeldet"-Filter rausfallen würden, zeigt die App jetzt kurz ein leeres Grid statt der Meldung "Keine Daten für X vorhanden". Bewusst in Kauf genommen gegen den garantierten UI-Freeze.
- **Wirkung:** ging von ~7'288 ms auf 0 ms.

### 5. Zweiter UI-Freeze behoben: Statuskreis-Symbole (`Forms/Form1.vb`, `BGW_Hejiunka_RunWorkerCompleted`)
- `RePaintedCircle`/`RePaintedFullCircle` laden je 4 PNG-Bilder von der Netzwerkfreigabe. Die 5 Bedingungen, die das Status-Symbol pro Zeile bestimmen, waren unabhängige `If`-Blöcke statt `ElseIf` → bei einem fast fertigen Auftrag wurde bis zu 4x hintereinander neu gezeichnet (überschreibend, nur das letzte Ergebnis zählte).
- Auf `ElseIf`-Kette umgestellt (identisches sichtbares Ergebnis, nur noch 1 Aufruf statt bis zu 4).
- Die 4 Quellbilder werden jetzt einmalig geladen und im Speicher wiederverwendet (`GetQuellBild`-Cache) statt bei jedem Aufruf erneut von der Freigabe gelesen.
- `DGV_FAUF.SuspendLayout()`/`.ResumeLayout()` um die Befüllschleife ergänzt.
- **Wirkung:** "DGV füllen" ging von ~15'017 ms auf ~13-16 ms.

### 6. Weitere gecachte Textdatei-Lesevorgänge (`Klassen/GlobaleFunktionen.vb`)
- Neuer `ReadAllLinesCached`-Helper (gleiches Cache-Prinzip wie bei den XML-Dateien: Pfad + Datei-Zeitstempel).
- Angewendet auf: `GetWerkskalender` (wurde in `GetLastWorkDay` pro Tag-Iteration rückwärts neu gelesen – Hauptursache für ~2-3s gefühlte Wartezeit ganz am Anfang), `MatInAusnahmeliste`, `GetLagerort`-Ausnahmeliste.
- **Wirkung:** "Vorbereitung"-Phase ging von ~2-3s (gefühlt, ungemessen) auf ~43-60 ms.

### 7. Unnötiger voller Tabellendownload vermieden (`Forms/Form1.vb`)
- `Tbl_FAUF_StatusTableAdapter.GetData()` lädt die komplette `dbo.tbl_FAUF_Status`-Tabelle ohne WHERE-Klausel – wird aber nur gebraucht für Zeilen ohne WATS-Daten bzw. mit Ausnahmelisten-Material.
- Wird jetzt nur noch geladen, wenn `Argument.WatsVorhanden = False` oder mindestens eine Ausnahme in der aktuellen Aktualisierung vorkam; sonst leere (aber korrekt typisierte) Tabelle.
- **Wirkung:** auf reinen WATS-Linien ohne Ausnahmen: 3'674-3'768 ms → 0 ms. Auf Linien ohne WATS (oder mit Ausnahmen) bleibt der volle Download bestehen (siehe Ausblick Punkt 1).

### 8. Zeitmessung/Logging (dauerhaft im Code, für zukünftige Diagnose)
Neue Log-Zeilen in `C:\LocalData\HeijunkaLog.txt` bei jeder Aktualisierung:
- Vorbereitung (UI-Thread, GetLastWorkDay + SAP.DT_Heijunka aufbauen)
- Vorab-Zählung (UI-Thread, vor WATS/DoWork)
- WATS Vorab-Ladephase
- Restliche Zeilen-Schleife (SAP-XML etc.)
- Prozesskennzahlen (mit Teilmessungen: RueckstandProLinie, FPY_Aktuell, FAUFStatus GetData, OEE)
- DGV füllen (RunWorkerCompleted, UI-Thread)
- Gesamte Aktualisierung (Klick bis DGV fertig befüllt)

### 9. Absturz-Diagnose für "App schliesst sofort ohne Meldung" (`ApplicationEvents.vb`)
- Beobachtung: auf manchen Rechnern (nicht bei allen) schliesst sich die App während der "Restlichen Zeilen-Schleife" sofort, ohne Fehlerdialog – das läuft also an der normalen `BackgroundWorker`-Fehlerbehandlung (`e.Error`) vorbei.
- Hauptverdacht: eine "unobserved" Exception aus einem der neuen `Task`/`Task.ContinueWith`-Aufrufe (WATS-Parallelisierung), die .NET Framework sonst irgendwann auf dem Finalizer-Thread erneut wirft – das beendet den Prozess sofort ohne jede Meldung. Auf Rechnern mit schlechterer/langsamerer Netzwerkverbindung zum WATS-Server (Timeout) wahrscheinlicher als bei anderen.
- Eingebaut:
  - `TaskScheduler.UnobservedTaskException`-Handler mit `e.SetObserved()` – verhindert diesen speziellen Absturz-Typ aktiv (falls das die Ursache ist), nicht nur Diagnose.
  - `AppDomain.UnhandledException` und `My.Application.UnhandledException` als Sicherheitsnetz für alle anderen Absturzarten, schreiben vollen Exception-Text **synchron** (nicht über die normale asynchrone `logging`-Klasse, die bei einem Absturz evtl. nicht mehr fertig schreiben würde) nach `C:\LocalData\HeijunkaLog.txt`.
- **Bestätigt und behoben** – dank der neuen Log-Handler kam beim nächsten Auftreten der volle Stacktrace, siehe Punkt 10.

### 10. Ursache des rechnerabhängigen Absturzes gefunden und behoben (`Forms/Form1.vb`)
Über das neue Absturz-Log (Punkt 9) kam die vollständige Ursachenkette zutage:

1. **Auslöser:** `RueckstandProLinie()` (Zeile 3433) verglich `item.SpatStartDat < Date.Today` – ein impliziter String→Date-Vergleich ohne festes Format. VBs `Conversions.ToDate` nutzt dabei die **Windows-Regionseinstellungen des jeweiligen Rechners**. Bei Datums-Strings im Format "dd.MM.yyyy" (z.B. "13.07.2026") funktioniert das nur auf Rechnern mit passender Kultur (z.B. Schweiz/Deutschland) – auf Rechnern mit anderen Regionseinstellungen (z.B. US-Format, kennt keinen 13. Monat) crasht die Konvertierung mit `InvalidCastException`. **Das erklärt die Rechnerabhängigkeit.** Fix: explizites `DateTime.ParseExact(item.SpatStartDat, "dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo)`, konsistent mit den anderen Stellen im selben File, die das schon richtig gemacht haben.
2. **Eigentlicher Grund für den kompletten App-Absturz (statt "Fehler beim Laden"):** `BGW_Hejiunka_DoWork` war als `Async Sub` deklariert, obwohl der Methodenkörper kein einziges `Await` enthält (bestehende Compiler-Warnung seit Session-Beginn, unabhängig von den WATS-Änderungen). Bei `Async Sub` werden unbehandelte Exceptions **nicht** normal an den `BackgroundWorker` zurückgegeben, sondern von .NET auf einem beliebigen Thread erneut geworfen – das umgeht die normale `BackgroundWorker`-Fehlerbehandlung (`e.Error`) komplett und lässt zusätzlich `RunWorkerCompleted` mit einem leeren `e.Result` weiterlaufen (führte zu einer zweiten Exception, `NullReferenceException` beim Zugriff auf `e.Result.FAUFStatusDaten`). Fix: `Async`-Modifikator entfernt → normale, synchrone Fehlerbehandlung über `BackgroundWorker` funktioniert jetzt wie vorgesehen. **Das schützt vor jeder zukünftigen Exception in dieser Methode**, nicht nur vor dem einen Datums-Bug.
- **Noch offen:** `HejiunkaAnzeigen()` (UI-Thread, Button-Click-Handler) hat denselben Async-Sub-ohne-Await Anti-Pattern (Compiler-Warnung BC42356 weiterhin vorhanden). Dort ist das Risiko kleiner (Exception würde über den UI-Thread laufen und vom neuen `My.Application.UnhandledException`-Handler zumindest geloggt), aber strukturell sauberer wäre es, auch dort `Async` zu entfernen, falls tatsächlich kein `Await` gebraucht wird.

### 11. Zweiter Absturz durch 0-Zeilen-Grid gefunden und behoben (`Forms/Form1.vb:2127`)
- Neuer Absturz nach Fix von Punkt 10, wieder dank der Log-Handler mit vollem Stacktrace sichtbar: `DGV_FAUF.CurrentCell.Selected = False` in `BGW_Hejiunka_RunWorkerCompleted` wirft `NullReferenceException`, wenn das Grid **0 Zeilen** hat (`CurrentCell` ist dann `Nothing`).
- **Zusammenhang mit Punkt 4:** Das ist ein direkter Nebeneffekt der entfernten "Vorab-Zählung" (Punkt 4) – früher wurde bei 0 tatsächlich anzuzeigenden Zeilen "Keine Daten vorhanden" angezeigt und der BackgroundWorker gar nicht gestartet; jetzt startet er auch bei 0 Zeilen, wodurch dieser vorbestehende, bisher nie erreichte Bug erstmals ausgelöst wurde.
- Fix: `If DGV_FAUF.CurrentCell IsNot Nothing Then ... End If` um die Zeile ergänzt.
- **Nicht angefasst (geringeres Risiko, da nur bei existierender Zeile erreichbar):** zwei weitere Vorkommen derselben Zeile in `ProdKontErledigen` (Zeilen ~2828, ~2845) – dort wird immer auf einer konkret ausgewählten, existierenden Zeile operiert, daher deutlich unwahrscheinlicher betroffen.

### 12. SAP-Textimport robuster gemacht (`Forms/Form1.vb`, `ImportHeijunkaSQ00`)
Auf Nachfrage nach weiterem Optimierungspotential (unabhängig von der "Aktualisieren"-Performance) wurden vier Probleme im SAP-SQ00-Textimport gefunden und behoben:
1. **Unnötiger doppelter Datei-Durchlauf:** die Datei wurde komplett gelesen, dann ohne die ersten 6 Kopfzeilen komplett neu geschrieben, dann nochmal komplett gelesen. Jetzt: einmal lesen, die ersten 6 Zeilen beim Parsen überspringen (`For zeilenNr As Integer = 6 To sInput.Length - 1`) – kein Rewrite mehr nötig.
2. **Hartcodierter Pfad `"C:\Temp\export.txt"`** statt der Einstellung `My.Settings.ExportPfadLocal` – hätte bei Änderung der Einstellung zu einem stillen Fehlimport geführt. Jetzt konsistent über die Einstellung, das lokale Zielverzeichnis wird zudem aus dem Pfad abgeleitet (`IO.Path.GetDirectoryName(...)`) statt hartcodiert `C:\Temp` anzunehmen.
3. **Eine fehlerhafte Zeile brach den kompletten Import ab** (z.B. zu wenige Tab-getrennte Spalten → `IndexOutOfRangeException` für die gesamte Query). Jetzt wird pro Zeile in einem Try/Catch geparst; fehlerhafte Zeilen werden übersprungen und mit Zeilennummer + Inhalt geloggt, der Rest des Imports läuft normal weiter.
4. **Kein Schutz gegen leeren/unvollständigen Import:** die Zieltabelle wurde vor dem Neuaufbau geleert – bei einer leeren oder unvollständig kopierten Exportdatei (SAP schreibt noch, Netzwerk-Hänger) wäre die komplette Heijunka-Tafel plötzlich leer gewesen. Jetzt wird zuerst in eine temporäre Tabelle geparst; nur bei mindestens einer erfolgreich geparsten Zeile wird die echte Tabelle geleert und per `.Merge(tempTable)` neu befüllt. Bei 0 Zeilen bleiben die bisherigen Daten erhalten (mit Log-Eintrag).
- **Verifiziert und entfernt:** `ImportHeijunkaDownload()` (CSV-Variante des Imports) wurde tatsächlich noch aufgerufen – aber nur von `Button3_Click`, und `Button3` stand im Designer dauerhaft auf `Visible = False` (nirgends im Code wieder auf `True` gesetzt) und war damit im laufenden Betrieb nie erreichbar. `ImportHeijunkaDownload()`, `Button3_Click` sowie der versteckte `Button3`-Control (Designer- und Feld-Deklaration) wurden komplett entfernt.
- **Noch offen:** keine Absicherung gegen gleichzeitigen SAP-Import und laufende Dashboard-Aktualisierung (beide greifen unsynchronisiert auf dieselben `SAP.DT_*`-DataTables zu) – seltener Grenzfall, noch nicht behoben.

### 13. Rückmelden-Dialog beschleunigt (`Forms/frm_Ruckmelden.vb`, `Klassen/GlobaleFunktionen.vb`)
Auf Hinweis, dass das Rückmelden-Fenster teilweise sehr lange zum Öffnen braucht und dabei die UI einfriert: derselbe Fund wie bei `tbl_FAUF_Status` (Punkt 7), nur an anderer Stelle, plus ein zusätzlicher Verstärker:
- **`Tbl_Rueckmelden_StatusTableAdapter.GetData` lud ungefiltert die komplette `tbl_Rueckmelden_Status`-Tabelle** (alle je gebuchten Behälter, aller Aufträge) – synchron im UI-Thread direkt im Konstruktor von `frm_Ruckmelden`, ohne BackgroundWorker. Erklärt sowohl die variable Ladezeit (abhängig von Tabellengrösse/Netzwerklatenz) als auch das UI-Einfrieren.
- **Verschärfung:** bei Vorgängen mit Steuerschlüssel A003 wurde diese komplette Tabelle zusätzlich **pro Behälter** nochmal per LINQ durchsucht (`For j = 1 To AnzBehaelter`).
- Fix: neue Methode `GlobaleFunktionen.GetRueckmeldenStatusByFAUF(FAUF)` – parametrisierte SQL-Abfrage (`WHERE FAUF = @FAUF`, raw ADO.NET analog zu `WriteFaufInitToDb`, keine Änderung am generierten TableAdapter-Code nötig), lädt nur die Zeilen des aktuellen Auftrags. Die bereits gebuchten Rückmeldecodes werden einmalig in ein `HashSet(Of String)` geladen; die Pro-Behälter-Prüfung ist jetzt ein O(1)-Lookup (`gebuchteRuckCodes.Contains(...)`) statt eines wiederholten Tabellen-Scans.
- **Nebenbei bemerkt (Verhaltensänderung, bewusst in Kauf genommen):** die alte Abfrage nutzte den VB-`Like`-Operator, bei dem `_` ein Platzhalter für "ein beliebiges Zeichen" ist – `rw("RuckCode") Like vrg.Rueck & "_" & y` hätte also theoretisch auch RuckCodes mit einem anderen Zeichen an der Unterstrich-Position fälschlich als Treffer gewertet. Der neue `HashSet.Contains`-Vergleich ist ein exakter String-Vergleich – das ist strenger/korrekter, aber technisch eine Verhaltensänderung gegenüber vorher.

### 14. Support-Dialog: Kamera-Handling robuster gemacht (`Forms/frm_supportAnfrage.vb`)
Auf Hinweis, dass die Kamera im Support-Dialog fragil wirkt:
- **Hauptursache vermutet und behoben:** `VideoCaptureDevice.VideoResolution = VideoCaptureDevice.VideoCapabilities(3)` griff fest auf Index 3 der von der Kamera gemeldeten Auflösungsliste zu. Kameras/Treiber, die weniger als 4 Auflösungsmodi melden, warfen dadurch eine `IndexOutOfRangeException` direkt beim Kamera-Start (auch schon beim Öffnen des Dialogs, da `cb_cam.SelectedIndex = 0` beim Laden gesetzt wird). Jetzt: `Math.Min(3, VideoCaptureDevice.VideoCapabilities.Length - 1)`, mit Prüfung ob überhaupt Auflösungen gemeldet werden.
- **Fehlendes Error-Handling ergänzt:** `cb_cam_SelectedIndexChanged` (Kamera-Erzeugung/-Start) ist jetzt in Try/Catch, loggt den Fehler und zeigt eine verständliche Meldung statt abzustürzen; `btn_TakePicture` wird bei Fehlschlag deaktiviert.
- **Fehlende Null-Checks ergänzt:** `PictureBox1_Click` und `btn_cancel_Click` riefen `VideoCaptureDevice.Stop()`/`.Start()` ohne Prüfung auf, ob überhaupt eine Kamera initialisiert wurde (`NullReferenceException` möglich, falls keine Kamera gefunden wurde).
- **Zusätzlich behoben:** `frm_supportAnfrage_Load` ist selbst ein `Async Sub` mit echtem `Await` auf die IH-Tool-Stations-API (`GetStationsIhTool`). Schlägt dieser API-Call fehl (Netzwerk/VPN-Aussetzer), gab die Funktion `Nothing` zurück, was ungeprüft in die `Stationen`-Liste übernommen wurde – der nachfolgende `For Each i In Stat.v_Hierarchie`-Zugriff hätte dann eine `NullReferenceException` **innerhalb eines Async Sub** geworfen, dieselbe Fehlerklasse wie der in dieser Session behobene `BGW_Hejiunka_DoWork`-Absturz (Punkt 10) – d.h. die App wäre komplett und ohne Meldung abgestürzt, wenn die IH-Tool-API mal nicht erreichbar ist. Fix: fehlgeschlagene Stationsabfragen werden jetzt übersprungen (nicht in die Liste übernommen) und einmalig geloggt, statt die App abstürzen zu lassen.

### 15. Auftragsstart (`Forms/Form1.vb`, `FAUF_Start`/`ProdKontErledigen`, `Klassen/GlobaleFunktionen.vb`)
Fünf Funde auf Nachfrage, was sich beim Auftragsstart noch verbessern lässt - alle umgesetzt:
1. **Dritter Fund derselben Problemklasse wie `tbl_FAUF_Status`/`tbl_Rueckmelden_Status`:** `ProdKontErledigen` (von `FAUF_Start` bei jedem Auftragsstart aufgerufen) lud die komplette, ungefilterte `tbl_ProdKontrolle`-Tabelle und filterte erst clientseitig per LINQ auf FAUF/Status/Vorgang. Fix: neue Methode `GlobaleFunktionen.GetOffeneProdKontrolleByFAUF(FAUF, Vrg)` – parametrisierte SQL-Abfrage, liefert eine typisierte `tbl_ProdKontrolleDataTable`, damit `frm_ProdKontrolle_Detail` (das die Zeilen per Spaltenname ausliest) unverändert weiterfunktioniert.
2. **Textdatei-Ausnahmeliste ohne Cache:** `My.Settings.PfadFaufInfo` (Materialinfos beim Start) wurde bei jedem Auftragsstart neu von der Netzwerkfreigabe gelesen. `GlobaleFunktionen.ReadAllLinesCached` (bisher `Private`, jetzt `Friend`) wird jetzt auch hier verwendet.
3. **Fragiles Zeilen-Parsing:** `split(1)` ohne Prüfung der Spaltenanzahl hätte bei einer kaputten Zeile in der Info-Datei den kompletten Auftragsstart mit einer Exception abgebrochen, noch bevor der eigentliche Start passiert. Jetzt Try/Catch pro Zeile (überspringen + loggen) sowie um den gesamten Dateizugriff (loggen statt abbrechen, falls die Datei nicht lesbar ist).
4. **Code-Duplikation aufgelöst:** die beiden fast wortgleichen Blöcke (Normalfall / "Ja, trotzdem starten obwohl bereits rückgemeldet") sind jetzt in einer gemeinsamen Methode `AuftragStartAusfuehren(auftrag, ASN, soll, AblieferOrt)` zusammengefasst (Ini schreiben, `WriteFaufInitToDb`, Barcode-Formular, `ProdKontErledigen`, Checkliste).
5. **Doppelte Fehlermeldung entfernt:** `PathAPLA_XML` zeigt bei fehlender APLA-XML bereits eine eigene Meldung; die zusätzliche, fast identische Meldung in `FAUF_Start` wurde entfernt (nur noch `Exit Sub`). Bewusst nicht in `PathAPLA_XML` selbst geändert, um andere Aufrufer (die z.B. bewusst keine eigene Meldung zeigen) nicht zu beeinflussen.

### 16. Projektweite Durchsicht auf "Leichen" und Potential (Robustheit/Geschwindigkeit)
Auf die Bitte, das ganze Projekt nochmal durchzusehen, wurden folgende Funde alle umgesetzt:

**Vierter/fünfter/sechster/siebter Fund derselben Problemklasse (volle Tabellendownloads bei Einzel-Zeilen-Aktionen):**
- `DGV_FAUF_CellDoubleClick` (Kommentar-Spalte, Doppelklick), `DGV_FAUF_CellClick` (Klick auf rot markierte Zeile → ProdKontrolle, Klick auf blau markierte Zeile → Kommentar) und `lbl_info_Click` (Detailansicht) luden bei **jedem normalen Klick auf eine markierte Zeile** in der Haupttafel die komplette `tbl_Kommentar`- bzw. `tbl_ProdKontrolle`-Tabelle. Das dürfte in der Praxis häufiger auftreten als die bisher behobenen Fälle (Rückmelden-Dialog, Auftragsstart), da es bei ganz normaler Navigation in der Tafel greift.
- Fix: zwei neue Methoden in `GlobaleFunktionen.vb` – `GetKommentarByFAUF(FAUF)` (typisierte `tbl_KommentarDataTable`) und `GetProdKontrolleByFAUF(FAUF, Vrg)` (wie `GetOffeneProdKontrolleByFAUF`, aber ohne Status-Filter, für die Detailansicht die auch erledigte Einträge zeigen soll). Alle vier Stellen laden jetzt nur noch die Zeilen des jeweils angeklickten Auftrags.
- **Bewusst nicht angefasst:** `BGW_CloseForm_DoWork` (voller `tbl_ProdKontrolle`-Load beim Schliessen der App) und die Preamble von `BGW_Hejiunka_DoWork` (tbl_ProdKont/tbl_linie/tbl_SMT_Rüst/tbl_Kommentar) - dort werden die Daten für **viele** Zeilen auf einmal gebraucht, das "einmal komplett laden, dann im Speicher filtern" ist dort das richtige Muster (Umkehrung würde N Einzelabfragen statt einer statt machen). Ebenso `frm_Ruckstand`s Konstruktor-Load (braucht Daten für die ganze Rückstandsliste, nicht nur einen Auftrag).

**`HejiunkaAnzeigen()` – zweiter Fall desselben Async-Sub-Absturzrisikos behoben:** wie schon bei `BGW_Hejiunka_DoWork` (Punkt 10) war auch diese Methode als `Async Sub` ohne ein einziges echtes `Await` deklariert. `Async` entfernt – stellt die normale Fehlerbehandlung wieder her, jede Exception darin würde sonst am `My.Application.UnhandledException`-Handler vorbei die App zum Absturz bringen können.

**Totes/unerreichbares Zeug entfernt:**
- `GetMaterialSpezInfos` (Form1.vb) – nie aufgerufen, entfernt.
- Komplette Regionen `"Testing"` und `"HeijunkaAysinc"` in `Form1.vb` entfernt (`Button1_Click_1/_3/_4/_5/_6`, `btn_asyncWats_Click`, `btn_WatsAbfrage_Click`, `Abfrage`, `HejiunkaAnzeigenAsync`, `HeijunkaDoWorkAsync`, Klasse `heijunkaResult1`, Feld `list`) – alles hing an Buttons (`Button1`, `Button3`, `Button5`, `btn_asyncWats`, `btn_WatsAbfrage`), die im Designer fest auf `Visible = False` stehen, oder war komplett unangebunden (kein `Handles`, kein Aufruf von irgendwo). Zugehörige tote Designer-Komponenten (`Button1`, `Button5`, `btn_asyncWats`, `btn_WatsAbfrage`, `HeijunkaResult1BindingSource`) ebenfalls entfernt. `dgv_Heijunka1` (das nie befüllte Grid dieser toten Funktion) bewusst nicht entfernt – reine UI-Layout-Chirurgie ohne Verhaltensnutzen, zu hohes Risiko/Aufwand-Verhältnis.
- `v-checkKontrolle.vb`: doppelter `HJ_GetOperationInfoTableAdapter.GetData(FAUF)`-Aufruf (Ergebnis der ersten, unbenutzten Abfrage `tbl_vc` entfernt).
- Unbenutztes Feld `Private feiertage As New Feiertage` in `Form1.vb` entfernt (die `Feiertage`-Klasse wird im ganzen Projekt nirgends tatsächlich aufgerufen – der darin enthaltene, kultur-abhängige Datums-Bug ist dadurch aktuell nicht erreichbar; die Klassendatei selbst bleibt unangetastet liegen, da das Entfernen ganzer Klassen ohne Verhaltensnutzen ist).
- `frm_Ruckstand.vb`: toter zweiter `Tbl_ProdKontrolleTableAdapter.Fill(...)`-Aufruf im Load-Event entfernt (Ergebnis wurde nirgends gelesen), sowie der nie gestartete `BGW_RS_Load` BackgroundWorker (alle drei Handler waren leer). Dabei auch gleich denselben `CurrentCell`-Nullref-Schutz wie in Punkt 11 ergänzt.
- Zwei komplett tote, nie instanzierte Formulare gelöscht: **`frm_Wochenansicht`** (war nicht mal im `.vbproj` eingebunden, wurde also gar nicht mitkompiliert) und **`frm_ProductSearch`** (kompiliert, aber nirgends per `New` erzeugt) – jeweils `.vb`/`.Designer.vb`/`.resx` plus die `.vbproj`-Einträge entfernt.
- Doppelte, komplett leere `Klassen\ApplicationEvents.vb` (Partial-Class-Duplikat ohne Inhalt) gelöscht – die eigentliche Absturz-Diagnose-Logik (Punkt 9) liegt in der Root-Datei `ApplicationEvents.vb` und war davon nicht betroffen.

**Gefunden, aber bewusst nicht angefasst (kein sicherer/lohnender Fix ohne grössere Eingriffe):**
- `MatchTablesDataSet` (Dataset): der generierte Code weist der `SqlConnection` einen Connection-String zu, der eigentlich ein Access/OleDb-Format ist (`SSN_ASN_MatchTableConnectionString`) – ein Wizard-Kopierfehler. Geprüft: der zugehörige `SSN_ASN_TabTableAdapter` (ohne "1"-Suffix) wird im ganzen Code **nirgends tatsächlich für eine Abfrage aufgerufen** (nur im Designer instanziiert) – der eigentlich verwendete Adapter ist `SSN_ASN_TabTableAdapter1` aus `_SSN_ASN_MatchTableDataSet` (korrekt als OleDb konfiguriert). Der Bug ist also aktuell inert/unerreichbar; eine Korrektur würde Eingriffe in generierten Designer-Code ohne aktuellen Verhaltensnutzen bedeuten.

### 17. v-Check-Kontrolle: Absturz im Scanner-Modus behoben (`Forms/v-checkKontrolle.vb`)
Meldung aus einer produktiven (unveränderten) Version, über die neue Absturz-Diagnose (Punkt 9) sichtbar gemacht:
```
UI-THREAD UNHANDLED EXCEPTION: System.NullReferenceException
   bei ProdKontrolle.v_checkKontrolle.VideoStart()
   bei ProdKontrolle.v_checkKontrolle.BGW_Load_vcheckData_RunWorkerCompleted(...)
```
**Ursache:** `VideoCaptureDevice` wird nur initialisiert, wenn `My.Settings.vcheck_scanner = False` ist (Kamera-Modus, `Form1_Load`). Bei `vcheck_scanner = True` (physischer Scanner statt Kamera konfiguriert) bleibt `VideoCaptureDevice = Nothing`. `VideoStart()` (aufgerufen aus `BGW_Load_vcheckData_RunWorkerCompleted`, sobald die v-Check-Daten als "OK" validiert wurden) rief `VideoCaptureDevice.Start()` aber **unabhängig** vom konfigurierten Modus auf → `NullReferenceException` im Scanner-Modus. An anderer Stelle im selben File (`v_checkKontrolle_Closing`) wird dieselbe Bedingung bereits korrekt geprüft, nur in `VideoStart()` fehlte die Absicherung.
**Fix:** `VideoStart()` prüft jetzt zusätzlich `My.Settings.vcheck_scanner = False`, bevor die Kamera gestartet wird. Unabhängig von den heutigen Performance-/Aufräumarbeiten – ein vorbestehender Bug, der nur durch die neue Absturz-Diagnose (Punkt 9) sichtbar wurde.

### 18. Veraltete Zeilen-Auswahl (`Row`) konnte zum Absturz führen (`Forms/Form1.vb`)
Gemeldeter Fehler:
```
UI-THREAD UNHANDLED EXCEPTION: System.ArgumentOutOfRangeException
   bei System.Windows.Forms.DataGridView.get_Item(Int32 columnIndex, Int32 rowIndex)
   bei ProdKontrolle.Form1.ProdKontErledigen(Boolean AuftragsStartAktiv)
   bei ProdKontrolle.Form1.AuftragStartAusfuehren(...)
   bei ProdKontrolle.Form1.FAUF_Start()
   bei ProdKontrolle.Form1.ToolStripMenuItemStart_Click(...)
```
**Ursache:** Die zuletzt angeklickte Grid-Zeile wird in der klasseneiten Property `Row` gemerkt (gesetzt einzig in `DGV_FAUF_CellClick`). `FAUF_Start()`, `ProdKontErledigen()` und die anderen Auftragsaktionen lesen `DGV_FAUF(Spalte, Row)`, ohne je zu prüfen, ob `Row` noch innerhalb der aktuellen Zeilenanzahl liegt. Mechanismus des konkreten Absturzes: `FAUF_Start()` öffnet mit `Frm_Barcodevb.ShowDialog()` einen **modalen Dialog** – während dieser offen ist, verarbeitet Windows weiterhin Nachrichten, wodurch im Hintergrund der `T_WatsRefresh`-Timer feuern und eine komplette Grid-Aktualisierung (`DGV_FAUF.Rows.Clear()` + Neuaufbau, ggf. mit weniger Zeilen) durchlaufen kann. Schliesst sich der Dialog und geht es weiter zu `ProdKontErledigen`, zeigt `Row` dann ins Leere.
**Fix:** neue Hilfsfunktion `ZeileNochGueltig(methodenName)` prüft `Row` gegen die aktuelle `DGV_FAUF.Rows.Count`; bei ungültigem Wert wird die Aktion sauber abgebrochen (mit Log-Eintrag statt Absturz) statt eine Exception zu werfen. Ergänzt in allen betroffenen Methoden mit demselben Muster: `FAUF_Start`, `ProdKontErledigen`, `FAUF_Ruckmelden`, `FAUF_Stuli`, `FAUF_Beenden`, `FAUF_Prodkontrolle`, `VCheckKontrolle`.
- **Nicht behoben (bewusst kein UX-Ersatz):** aktuell bricht die Aktion bei ungültiger Zeile einfach kommentarlos ab (nur Log-Eintrag). Falls das zu Verwirrung führt ("ich klicke auf Start und nichts passiert"), könnte man stattdessen eine kurze Meldung ("Bitte Auftrag neu auswählen") anzeigen – aktuell bewusst minimal gehalten, um keine zusätzlichen Dialoge im Normalbetrieb einzuführen.

## Ausblick / offene Vorschläge (noch nicht umgesetzt)

1. **`dbo.tbl_FAUF_Status` verkleinern** – auf Linien ohne WATS-Daten (oder mit Ausnahmematerial) dauert der volle Tabellendownload weiterhin ~3.7s, weil die Abfrage keine WHERE-Klausel hat und daher mit der Zeilenanzahl der Tabelle skaliert. Besprochen, aber bewusst zurückgestellt:
   - Alte Aufträge (2021-2025) aus der Tabelle löschen/archivieren – **auf Wunsch aktuell nicht umgesetzt**, da destruktiv und Rücksprache mit anderen evtl. abhängigen Auswertungen sinnvoll.
   - Alternative ohne Datenverlust: eine gefilterte/parametrisierte Abfrage (z.B. nur die aktuell benötigten `FAUF`-Werte oder ein Datumsfenster) statt `SELECT * FROM tbl_FAUF_Status` – erfordert Änderung am TypedDataSet-Schema (`Dataset/DS_ProdKontrolle.xsd`), etwas aufwändiger als reine Code-Änderungen.
2. **Sicherheitsthemen aus der ursprünglichen Code-Analyse** (unabhängig von Performance, siehe frühere Analyse in diesem Chat):
   - Hardcodierte SQL-/E-Mail-Passwörter im Klartext (`My Project/Settings.Designer.vb`, `Klassen/GlobaleFunktionen.vb`) – wird durch den geplanten Blazor-Rewrite mit Windows-Auth ohnehin adressiert.
   - MQTT: `UseTls = False` bei gleichzeitig gesetzten (aber wirkungslosen) Zertifikats-Bypass-Optionen – unklarer/toter Code, sollte bereinigt werden.
3. **Leere Catch-Blöcke** – ca. 37 Stellen im Code verschlucken Exceptions ohne Logging (siehe ursprüngliche Analyse). Nicht in dieser Session angefasst.
4. **Kleinere, nicht performance-kritische Funde aus dieser Session:**
   - `GetStuecklisteFromSAPXML` gibt nicht auf allen Codepfaden einen Wert zurück (Compiler-Warnung BC42105, vorbestehend).
   - `RePaintedCircle`/`RePaintedFullCircle`/`PixelRePaint`: `Graphics`-Objekte werden nicht über `Using` entsorgt (kleines GDI-Resource-Leak, vorbestehend, durch den neuen Bild-Cache aber weniger relevant da die Quellbilder nicht mehr wiederholt neu geladen werden).
   - Weitere `TableAdapter.GetData()`-Aufrufe ohne Filter zu Beginn von `BGW_Hejiunka_DoWork` (`tbl_ProdKont`, `tbl_Incident`, `tbl_vcheckKontrolle`, `tbl_linie`, `tbl_SMT_Rüst`, `tbl_Kommentar`) wurden nicht einzeln geprüft, ob sie ähnlich wie `tbl_FAUF_Status` unnötig groß sind – falls nach den bisherigen Fixes noch Bedarf besteht, wäre das der nächste Ansatzpunkt.
5. **Log-Datei (`C:\LocalData\HeijunkaLog.txt`) wächst unbegrenzt.** Seit dieser Session deutlich verstärkt: allein ~11 `WriteLog`-Aufrufe pro einzelner "Aktualisieren"-Ausführung (die neue Zeitmessungs-Kette), macht bei Standard-Update-Intervall (10 Min.) und normalem Betrieb über Wochen/Monate spürbares Wachstum ohne jede Bereinigung (kein Rotations-/Grössenlimit vorhanden).
   - **Kein akutes Problem** – Anhängen an eine grosse Datei wird nicht langsamer, nur der Speicherplatz auf dem Linien-PC und die Lesbarkeit für Menschen leiden mit der Zeit.
   - **Log beim Software-Start löschen (ursprüngliche Idee) – bewusst nicht empfohlen:** ein Absturz führt oft zu einem (automatischen oder manuellen) Neustart der App; ein Löschen beim Start würde genau die Diagnose-Info vernichten, für die die Absturz-Handler (Punkt 9) überhaupt eingebaut wurden – kontraproduktiv direkt im wichtigsten Moment.
   - **Empfehlung stattdessen: Log-Rotation nach Grösse.** Beim Start (oder periodisch) prüfen, ob die Datei eine Grenze überschreitet (z.B. 5 MB); wenn ja, umbenennen/archivieren (z.B. mit Zeitstempel-Suffix) statt löschen, und mit einer frischen Datei weitermachen. Optional zusätzlich alte archivierte Logs (z.B. älter als 30 Tage) automatisch aufräumen, um den Gesamtplatzverbrauch langfristig zu begrenzen.
   - **Alternative/Ergänzung:** die neue Zeitmessungs-Kette (Punkt 8) ist inzwischen sehr fein granular (11 Zeilen pro Aktualisierung) – jetzt, wo die grossen Performance-Probleme behoben und bestätigt sind, könnte man auf nur noch die Gesamtzeit als Übersichtszeile reduzieren und die Detail-Zeilen z.B. hinter ein Debug-/Settings-Flag legen, das im Normalbetrieb aus ist.
   - **Noch nicht entschieden/umgesetzt** – wartet auf Priorisierung.
