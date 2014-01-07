Imports Microsoft.Win32
Public Class ExplorerContextMenu

    ''' <summary>
    ''' Fügt dem Kontextmenü des Windows Explorers einen Eintrag für einen Dateityp hinzu.
    ''' Bei Erfolg wird True zurückgegeben, sonst False.
    ''' </summary>
    ''' <param name="extension">Der Dateityp. Beispiel: .txt</param>
    ''' <param name="text">Der Text des Eintrags. Beispiel: In JSEdit öffnen</param>
    ''' <param name="command">Der aufzurufende Befehl. Beispiel: C:\jsedit.exe "%1"</param>
    Public Shared Function AddToExplorerContextMenu(ByVal extension As String, _
      ByVal text As String, ByVal command As String) As Boolean
        ' Beispiel der Kommentare: 
        '   extension=.js 
        '   text=In JSEdit öffnen 
        '   command= C:\jsedit.exe "%1"
        Try
            ' Öffnen: HKEY_CLASSES_ROOT\.js
            Dim Extensionkey As RegistryKey = Registry.ClassesRoot.CreateSubKey(extension)
            ' Öffnen: HKEY_CLASSES_ROOT\.js\Shell
            Dim Shellkey As RegistryKey = Extensionkey.CreateSubKey("Shell")
            ' Öffnen: HKEY_CLASSES_ROOT\.js\Shell\In JSEdit bearbeiten
            Dim Entrykey As RegistryKey = Shellkey.CreateSubKey(text)
            ' Öffnen: HKEY_CLASSES_ROOT\.js\Shell\In JSEdit bearbeiten\command
            Dim Commandkey As RegistryKey = Entrykey.CreateSubKey("command")
            Commandkey.SetValue("", command)
            Commandkey.Close()
            Entrykey.Close()
            Shellkey.Close()
            Extensionkey.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Entfernt einen Eintrag eines Dateityüs aus dem Kontextmenü des Windows Explorers.
    ''' </summary>
    ''' <param name="extension">Siehe AddToExplorerContextMenu()</param>
    ''' <param name="text">Siehe AddToExplorerContextMenu()</param>
    Public Shared Function RemoveFromExplorerContextMenu(ByVal extension As String, _
      ByVal text As String) As Boolean
        Try
            ' Öffnen: HKEY_CLASSES_ROOT\.js
            Dim Extensionkey As RegistryKey = Registry.ClassesRoot.OpenSubKey(extension, True)
            ' Öffnen: HKEY_CLASSES_ROOT\.js\Shell
            Dim Shellkey As RegistryKey = Extensionkey.OpenSubKey("Shell", True)
            ' Entfernen: HKEY_CLASSES_ROOT\.js\Shell\In JSEdit bearbeiten
            Shellkey.DeleteSubKeyTree(text)
            Shellkey.Close()
            Extensionkey.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Function isRegisterd(ByVal extension As String, _
     ByVal text As String) As Boolean
        Try
            ' Öffnen: HKEY_CLASSES_ROOT\.js
            Dim Extensionkey As RegistryKey = Registry.ClassesRoot.OpenSubKey(extension, True)
            ' Öffnen: HKEY_CLASSES_ROOT\.js\Shell
            Dim Shellkey As RegistryKey = Extensionkey.OpenSubKey("Shell", True)
            ' Entfernen: HKEY_CLASSES_ROOT\.js\Shell\In JSEdit bearbeiten
            Dim SubShellkey As RegistryKey = Shellkey.OpenSubKey(text)

            If SubShellkey Is Nothing Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
