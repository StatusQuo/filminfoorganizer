Imports System.Xml
Public Class FolderSize
    Private Shared FolderSize As Long = 0
    ''' <summary>
    ''' Diese Funktion ermittelt die Größe eines Ordners und gibt diese in Byte zurück
    '''</summary>
    '''<param name="Root">Der Ordner dessen Größe ausgelesen werden soll</param>
    Public Shared Function GetFolderSize(ByVal Root As String) As Long
        FolderSize = 0
        SeekFiles(Root)
        Return FolderSize
    End Function

    ''' <summary>
    ''' Diese Funktion ermittelt die Größe eines Ordners und gibt diese in Byte zurück
    ''' </summary>
    ''' <param name="Root">Der Ordner dessen Größe ausgelesen werden soll</param>
    Public Shared Function GetFileSize(ByVal Root As String) As Long
        FolderSize = 0
        FolderSize = FileLen(Root)
        Return FolderSize
    End Function
    Private Shared Sub SeekFiles(ByVal Root As String)
        Dim Files() As String = System.IO.Directory.GetFiles(Root)
        Dim Folders() As String = System.IO.Directory.GetDirectories(Root)

        For i As Integer = 0 To Files.Length - 1
            FolderSize += FileLen(Files(i))
        Next

        For i As Integer = 0 To Folders.Length - 1
            SeekFiles(Folders(i))
        Next
    End Sub
End Class




