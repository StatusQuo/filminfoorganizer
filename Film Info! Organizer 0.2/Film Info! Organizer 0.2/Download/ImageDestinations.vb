Public Class ImageDestinations
    Public Shared ReadOnly Property Fanart(ByVal p As String) As String
        Get
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                Return Fanart_info(p)
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                Return Fanart_xbmc(p)
            Else
                Return Fanart_mymovies(p)
            End If
        End Get
    End Property
    Public Shared Function Fanart_mymovies(ByVal p As String) As String
        Dim i As Boolean = False
        Dim s As String = ""
        Dim c As Integer = 0
        Do Until i = True
            If c = 0 Then
                If IO.File.Exists(IO.Path.Combine(p, "Backdrop.jpg")) Then
                    c += 1
                Else
                    i = True
                    Return IO.Path.Combine(p, "Backdrop.jpg")
                End If
            Else
                If IO.File.Exists(IO.Path.Combine(p, "Backdrop" & c & ".jpg")) Then
                    c += 1
                Else
                    i = True
                    Return IO.Path.Combine(p, "Backdrop" & c & ".jpg")

                End If
            End If
        Loop
        Return s
    End Function
    Public Shared Function Fanart_xbmc(ByVal p As String) As String
        Dim i As Boolean = False
        Dim s As String = ""
        Dim c As Integer = 0
        Do Until i = True
            If c = 0 Then
                If IO.File.Exists(IO.Path.Combine(p, "fanart.jpg")) Then
                    c += 1
                Else
                    i = True
                    Return IO.Path.Combine(p, "fanart.jpg")
                End If
            Else
                Dim p2 As String = IO.Path.Combine(p, "extrathumbs")

                If Not IO.Directory.Exists(p2) Then
                    IO.Directory.CreateDirectory(p2)
                End If
                Do Until i = True


                    If IO.File.Exists(IO.Path.Combine(p2, "thumb" & c & ".jpg")) Then
                        c += 1
                    Else
                        i = True
                        Return IO.Path.Combine(p2, "thumb" & c & ".jpg")
                    End If
                Loop
            End If
        Loop
        Return s
    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="p">OHNE FANART</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Fanart_info(ByVal p As String) As String
        p = IO.Path.Combine(p, "Fanart")
        If Not IO.Directory.Exists(p) Then
            IO.Directory.CreateDirectory(p)
        End If

        Dim i As Boolean = False
        Dim s As String = ""
        Dim c As Integer = 0
        Do Until i = True
            If c = 0 Then
                If IO.File.Exists(IO.Path.Combine(p, "Backdrop.jpg")) Then
                    c += 1
                Else
                    i = True
                    Return IO.Path.Combine(p, "Backdrop.jpg")
                End If
            Else
                If IO.File.Exists(IO.Path.Combine(p, "Backdrop" & c & ".jpg")) Then
                    c += 1
                Else
                    i = True
                    Return IO.Path.Combine(p, "Backdrop" & c & ".jpg")

                End If
            End If
        Loop
        Return s
    End Function


    Public Shared ReadOnly Property Cover(ByVal p As String) As String
        Get
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                Return Cover_info(p)
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                Return Cover_xbmc(p)
            Else
                Return Cover_mymovies(p)
            End If
        End Get
    End Property

    Public Shared Function Cover_dvd(ByVal p As String) As String
        Return IO.Path.Combine(p, "folder.jpg")
    End Function
    Public Shared Function Cover_mymovies(ByVal p As String) As String
        Return IO.Path.Combine(p, "folder.jpg")
    End Function
    Public Shared Function Cover_info(ByVal p As String) As String
        Return IO.Path.Combine(p, "folder.jpg")
    End Function
    Public Shared Function Cover_xbmc(ByVal p As String) As String
        Return IO.Path.Combine(p, "movie.tbn")
    End Function

    Public Shared Function Cache_Destination_File(ByVal p As String) As String
        Dim spt() As String = Split(p, "/")
        Dim filename As String = ""
        If spt.Length > 2 Then
            filename = spt(spt.Length - 2) & "-" & spt(spt.Length - 1)
        Else
            filename = ""
        End If
        Return filename
    End Function

    Shared Function Cache_Destination_Actor(ByVal p1 As String) As String
        Return IO.Path.GetRandomFileName
    End Function

End Class
