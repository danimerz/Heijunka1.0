Namespace My
    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst.  Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung mit einem Fehler beendet wird.
    ' UnhandledException: Wird bei einem Ausnahmefehler ausgelöst.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn die Anwendung bereits aktiv ist.
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
            ' Diagnose für Abstürze, die an der normalen Fehlerbehandlung (BackgroundWorker e.Error,
            ' Try/Catch) komplett vorbeigehen und die App ohne jede Meldung sofort beenden - z.B. eine
            ' "unobserved" Exception aus einem Task/Async-Aufruf, die .NET Framework sonst irgendwann
            ' auf dem Finalizer-Thread erneut wirft. Schreibt vor einem solchen Absturz die Details
            ' SYNCHRON (nicht über die normale, asynchrone Log-Klasse) ins Log, damit der Eintrag auch
            ' dann noch geschrieben wird, wenn der Prozess unmittelbar danach beendet wird.
            AddHandler System.Threading.Tasks.TaskScheduler.UnobservedTaskException, AddressOf OnUnobservedTaskException
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf OnAppDomainUnhandledException
        End Sub

        Private Sub OnUnobservedTaskException(sender As Object, e As System.Threading.Tasks.UnobservedTaskExceptionEventArgs)
            LogKritisch($"UNOBSERVED TASK EXCEPTION: {e.Exception?.Flatten()?.ToString()}")
            ' Markiert die Exception als "beobachtet" - verhindert, dass .NET Framework sie später auf
            ' dem Finalizer-Thread erneut wirft, was den Prozess sonst ohne jede Meldung beenden würde.
            e.SetObserved()
        End Sub

        Private Sub OnAppDomainUnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
            Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
            LogKritisch($"UNHANDLED EXCEPTION (IsTerminating={e.IsTerminating}): {If(ex?.ToString(), e.ExceptionObject?.ToString())}")
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            LogKritisch($"UI-THREAD UNHANDLED EXCEPTION: {e.Exception?.ToString()}")
            ' Bisheriges Verhalten (Standardverhalten von My.Application, App wird i.d.R. beendet)
            ' bewusst nicht verändert - nur die Sichtbarkeit über das Log ergänzt.
        End Sub

        Private Sub LogKritisch(Text As String)
            Try
                Dim Pfad As String = "C:\LocalData\HeijunkaLog.txt"
                If Not IO.Directory.Exists("C:\LocalData") Then
                    IO.Directory.CreateDirectory("C:\LocalData")
                End If
                IO.File.AppendAllText(Pfad, Date.Now.ToShortDateString & vbTab & Date.Now.ToLongTimeString & vbTab & Text & Environment.NewLine)
            Catch
            End Try
        End Sub

    End Class
End Namespace
