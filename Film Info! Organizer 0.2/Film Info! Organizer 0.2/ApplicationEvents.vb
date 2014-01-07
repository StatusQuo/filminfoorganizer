Namespace My

    ' Für MyApplication sind folgende Ereignisse verfügbar:
    ' 
    ' Startup: Wird beim Starten der Anwendung noch vor dem Erstellen des Startformulars ausgelöst.
    ' Shutdown: Wird nach dem Schließen aller Anwendungsformulare ausgelöst. Dieses Ereignis wird nicht ausgelöst, wenn die Anwendung nicht normal beendet wird.
    ' UnhandledException: Wird ausgelöst, wenn in der Anwendung eine unbehandelte Ausnahme auftritt.
    ' StartupNextInstance: Wird beim Starten einer Einzelinstanzanwendung ausgelöst, wenn diese bereits aktiv ist. 
    ' NetworkAvailabilityChanged: Wird beim Herstellen oder Trennen der Netzwerkverbindung ausgelöst.
    Partial Friend Class MyApplication
        Private WithEvents MyDomain As AppDomain = AppDomain.CurrentDomain

        Public Function MyDomain_AssemblyResolve(ByVal sender As Object, ByVal args As System.ResolveEventArgs) As System.Reflection.Assembly Handles MyDomain.AssemblyResolve

            'Überprüfen ob nach der richtigen Assembly gesucht wird:  
            If args.Name.Contains("Interop.Shell32") Then
                'Assembly aus den Resourcen laden  
                Return (System.Reflection.Assembly.Load(My.Resources.Interop_Shell32))
            Else
                'Wenn der Name nicht stimmt, geben wir 'Nothing' zurück, so wird noch an  
                'anderen Orten wie z.B. im GAC nach der richtigen Assembly gesucht  
                Return Nothing
            End If
        End Function

    End Class

End Namespace