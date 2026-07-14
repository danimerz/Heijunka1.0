Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' Allgemeine Informationen über eine Assembly werden über die folgenden
' Attribute gesteuert. Ändern Sie diese Attributwerte, um die Informationen zu ändern,
' die einer Assembly zugeordnet sind.

' Werte der Assemblyattribute überprüfen

<Assembly: AssemblyTitle("ProdKontrolle")>
<Assembly: AssemblyDescription("")>
<Assembly: AssemblyCompany("")>
<Assembly: AssemblyProduct("ProdKontrolle")>
<Assembly: AssemblyCopyright("Copyright ©  2020")>
<Assembly: AssemblyTrademark("")>

<Assembly: ComVisible(False)>

' Erlaubt dem Testprojekt Zugriff auf "Friend"-Member (z.B. in GlobaleFunktionen), damit die dortige
' Geschäftslogik (SAP-XML-Auswertung etc.) ohne öffentliche API-Erweiterung testbar ist.
<Assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ProdKontrolle.Tests")>

'Die folgende GUID wird für die typelib-ID verwendet, wenn dieses Projekt für COM verfügbar gemacht wird.
<Assembly: Guid("99d580d2-8a1c-4d3b-b530-c469d25d87c0")>

' Versionsinformationen für eine Assembly bestehen aus den folgenden vier Werten:
'
'      Hauptversion
'      Nebenversion
'      Buildnummer
'      Revision
'
' Sie können alle Werte angeben oder Standardwerte für die Build- und Revisionsnummern verwenden,
' indem Sie "*" wie unten gezeigt eingeben:
' <Assembly: AssemblyVersion("1.0.*")>

<Assembly: AssemblyVersion("1.0.0.0")>
<Assembly: AssemblyFileVersion("1.0.0.0")>
