Imports Microsoft.Win32

Public Class Reg
    Public Shared Sub Updatevernum()
        'Dim readere As IO.StreamReader = New
        Dim readere As IO.StringReader = New IO.StringReader(My.Resources.ver)
        Dim p As String = readere.ReadToEnd
        readere.Close()
        If Not p = "" Then
            ChangeVersion(p)
        End If
    End Sub
    Public Shared Sub ChangeVersion(ByVal p As String)
        Try
            Dim MeinKey As RegistryKey
            MeinKey = Registry.LocalMachine.OpenSubKey( _
                   "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Film Info! Organizer_is1", True)
            If Not MeinKey Is Nothing Then
                MeinKey = Registry.LocalMachine.OpenSubKey( _
                   "SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Film Info! Organizer_is1", True)
            End If
            If Not MeinKey Is Nothing Then
                MeinKey.SetValue("DisplayVersion", p)
            End If
            MeinKey.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class
