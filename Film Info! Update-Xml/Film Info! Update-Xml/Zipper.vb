Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports ICSharpCode.SharpZipLib.Core
Public Class Zipper
    Public Shared Sub Zip()
        Dim sourceDir As String = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\"
        Dim path As String
        path = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Updater\Film Info! Updater\Resources\Film Info! Organizer.zip"

        'If sourceDir.Length = 0 Then
        '    MsgBox("Bitte einen Ordner auswählen", MsgBoxStyle.Critical)
        '    Return
        'Else
        '    If Not Directory.Exists(sourceDir) Then
        '        MsgBox("Das ausgewählte Verzeichnis exsistiert nicht", MsgBoxStyle.Critical)
        '        Return
        '    End If
        'End If



        'Dim astrFileNames() As String = Directory.GetFiles(sourceDir)
        Dim astrFileNames(5) As String
        astrFileNames(0) = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\Film Info! Organizer.exe"
        astrFileNames(1) = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\Microsoft.WindowsAPICodePack.dll"
        astrFileNames(2) = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\Microsoft.WindowsAPICodePack.Shell.dll"
        astrFileNames(3) = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\ExpandableGridView.dll"
        astrFileNames(4) = "D:\Eigene Dokumente\Visual Studio 2010\Projects\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\Newtonsoft.Json.dll"

        Dim strmZipOutputStream As ZipOutputStream

        strmZipOutputStream = New ZipOutputStream(File.Create(path))

        Try

            ' Krompimierungslevel Level: 0-9
            ' 0: keine Komprimierung
            ' 9: Maximale Komprimierung

            strmZipOutputStream.SetLevel(9)

            Dim strFile As String
            Dim abyBuffer(4096) As Byte

            For Each strFile In astrFileNames
                Dim strmFile As FileStream = File.OpenRead(strFile)

                Try

                    Dim objZipEntry As ZipEntry = New ZipEntry(IO.Path.GetFileName(strFile))

                    objZipEntry.DateTime = DateTime.Now
                    objZipEntry.Size = strmFile.Length

                    strmZipOutputStream.PutNextEntry(objZipEntry)
                    StreamUtils.Copy(strmFile, strmZipOutputStream, abyBuffer)
                Finally
                    strmFile.Close()
                End Try
            Next
            strmZipOutputStream.Finish()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            strmZipOutputStream.Close()
        End Try
    End Sub

End Class
