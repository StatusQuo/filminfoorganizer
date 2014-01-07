﻿Imports Shell32
Imports System
Imports System.IO
Public Class ClassUnzip

    Private _file As String
    Private _folder As String
    Private _towhere As String
    Private _shell As Shell32.IShellDispatch2

    ''' <summary>Event welches vor dem Entpacken (Unzip) ausgeführt wird.</summary>
    ''' <remarks></remarks>
    Public Event Unzipstart()
    ''' <summary>Event welches nach dem Entpacken (Unzip) ausgeführt wird.</summary>
    ''' <remarks></remarks>
    Public Event UnzipFinishd()

    ''' <summary>Neue Instanz der ClassUnzip Klasse.</summary>
    ''' <param name="file">Datei welche entpackt werden soll.</param>
    ''' <param name="towhere">Zielordner.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal file As String, ByVal towhere As String)
        _file = file
        _towhere = towhere
        _folder = Path.Combine(Path.GetDirectoryName(_file), _towhere)
        _shell = CType(CreateObject("Shell.Application"), IShellDispatch2)
    End Sub
    Sub New()
    End Sub

    ''' <summary>Das Entpacken (Unzip) wird ausgeführt.</summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UnzipNow() As Boolean
        'prüfen ob der ordner existiert
        If Directory.Exists(_folder) = False Then
            Directory.CreateDirectory(_folder)
        End If
        'event für start feuern
        RaiseEvent Unzipstart()
        'entpacken
        Dim temp As Shell32.Folder = _shell.NameSpace((_folder))
        If temp IsNot Nothing Then
            temp.CopyHere(_shell.NameSpace((_file)).Items)
        End If
        'event für ende feuern
        RaiseEvent UnzipFinishd()
        'rückgabe wert setzen
        Return True
    End Function

    ''' <summary>Gibt den Namen der gepackten Datei zurück, oder setzt diesen.</summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UnZipFile() As String
        Get
            Return _file
        End Get
        Set(ByVal value As String)
            _file = value
        End Set
    End Property

    ''' <summary>Gibt den Zielort (entpacken) zurück, oder setzt diesen.</summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UnzipTo() As String
        Get
            Return _towhere
        End Get
        Set(ByVal value As String)
            _towhere = value
        End Set
    End Property
    Function CreateShortcut(ByVal sLinkFile As String, _
ByVal sTargetFile As String, _
Optional ByVal sArguments As String = "", _
Optional ByVal sDescription As String = "", _
Optional ByVal sWorkingDir As String = "") As Boolean

        Try
            Dim oShell As New Shell32.Shell
            Dim oFolder As Shell32.Folder
            Dim oLink As Shell32.ShellLinkObject

            ' Ordner und Dateinamen extrahieren
            Dim sPath As String = sLinkFile.Substring(0, sLinkFile.LastIndexOf("\"))
            Dim sFile As String = sLinkFile.Substring(sLinkFile.LastIndexOf("\") + 1)

            ' Wichtig! Link-Datei erstellen (0 Bytes)
            Dim F As Short = CShort(FreeFile())
            FileOpen(F, sLinkFile, OpenMode.Output)
            FileClose(F)

            oFolder = oShell.NameSpace(sPath)
            oLink = CType(oFolder.Items.Item(sFile).GetLink, Shell32.ShellLinkObject)

            ' Eigenschaften der Verknüpfung
            With oLink
                If sArguments.Length > 0 Then .Arguments = sArguments
                If sDescription.Length > 0 Then .Description = sDescription
                If sWorkingDir.Length > 0 Then .WorkingDirectory = sWorkingDir
                .Path = sTargetFile

                ' Verknüpfung speichern
                .Save()
            End With

            ' Objekte zerstören
            oLink = Nothing
            oFolder = Nothing
            oShell = Nothing

            Return True

        Catch ex As Exception
            ' Fehler! ggf. Link-Datei löschen, falls bereit erstellt
            If System.IO.File.Exists(sLinkFile) Then Kill(sLinkFile)
            Return False
        End Try
    End Function

End Class