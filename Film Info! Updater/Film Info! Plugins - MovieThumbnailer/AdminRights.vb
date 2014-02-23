Imports System.Security.Principal

Public Class AdminRights
    Public Shared aktuellerBenutzer As WindowsIdentity = WindowsIdentity.GetCurrent
    Public Shared princ As New WindowsPrincipal(aktuellerBenutzer)
    Public Shared Sub hasRight()
        If Not princ.IsInRole(WindowsBuiltInRole.Administrator) Then
            'MsgBox("Sie haben nicht die erforderlichen Rechte!")
            restartElevated()
        End If
    End Sub
    Public Shared Sub restartElevated()
        Dim psi As New System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)

        'Mit dem Verb runas erzwingt man den "Ausführen als..."-Dialog
        psi.Verb = "runas"
        Dim args As String()
        args = Environment.GetCommandLineArgs
        If args.Length > 1 Then
            For i As Integer = 1 To args.Length - 1
                psi.Arguments &= """" & args(i) & """"
            Next
        End If

        Try
            'Versuche den Prozess zu starten
            Process.Start(psi)
        Catch win32Ex As System.ComponentModel.Win32Exception
            'Diese Exception wird geworfen, wenn der Benutzer im UAC-Dialog auf "Abbrechen" geklickt hat.
            MessageBox.Show("Die Anwendung konnte nicht mit erhöhten Rechten gestartet werden!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End Try

        'Wenn wir diesen Punkt erreichen, dann wurde die Anwendung erfolgreich mit erhöhten Rechten neu gestarten,
        'wir können diese Instanz also abschießen
        Environment.Exit(0)

    End Sub
End Class
