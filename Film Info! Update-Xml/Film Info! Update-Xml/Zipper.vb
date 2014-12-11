Imports ICSharpCode.SharpZipLib.Zip
Imports System.IO
Imports ICSharpCode.SharpZipLib.Core
Public Class Zipper
    Public Shared Sub Zip(ByVal dest As String)



        Dim sourceDir As String = "D:\Eigene Dokumente\GitHub\filminfoorganizer\Film Info! Organizer 0.2\Film Info! Organizer 0.2\bin\Debug\"
        Dim path As String
        path = dest & "\Resources\Film Info! Organizer.zip"

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
        astrFileNames(0) = sourceDir & "Film Info! Organizer.exe"
        astrFileNames(1) = sourceDir & "Microsoft.WindowsAPICodePack.dll"
        astrFileNames(2) = sourceDir & "Microsoft.WindowsAPICodePack.Shell.dll"
        astrFileNames(3) = sourceDir & "ExpandableGridView.dll"
        astrFileNames(4) = sourceDir & "Newtonsoft.Json.dll"

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
