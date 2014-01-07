Public Class Prev_Sheet
    Property movie As Movie
    Property path As String
    Property image As Image
    Sub New(ByVal p As String, ByVal m As Movie)
        path = p
        movie = m
        image = MyFunctions.ImageFromJpeg(path)
    End Sub
    Sub Dispose()
        If Not image Is Nothing Then
            image.Dispose()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Me.Dispose()
        MyBase.Finalize()
    End Sub

    Sub add()
        Dim ps As New PreviewSheet
        ps._Result = Me
        Dialog_Sheet.Sheets.Add(ps)
        Dialog_Sheet.FlowLayoutPanel1.Controls.Add(ps)
    End Sub

End Class
Public Class Sheet_Result
    Property movie As Movie
    Property Results As New List(Of Prev_Sheet)
    Sub New()

    End Sub

    Protected Overrides Sub Finalize()

    End Sub
End Class


Public Class MoviesheetCreator



    'Property path As String
    'Property spath As String
    Property dupath As String = IO.Path.Combine(Einstellungen.ChachePath, "MovieSheet")
    Property exe As String = Application.StartupPath & "\Plugins\moviesheet\mtn.exe"
    'Sub New(ByVal p As String)
    '    path = p
    '    spath = shortpath(path)
    'End Sub
    Public Results As New List(Of Sheet_Result)

    Function Getdpath() As String
        Dim r As String = ""
        r = dupath
        Dim f As String = IO.Path.GetRandomFileName
        Do Until IO.Directory.Exists(IO.Path.Combine(dupath, f)) = False
            f = IO.Path.GetRandomFileName
        Loop
        r = IO.Path.Combine(dupath, f)
        IO.Directory.CreateDirectory(r)
        Return r
    End Function
    Sub Creat(ByVal m As Movie)
        If m.Files.Length > 0 Then
            If IO.File.Exists(m.Files(0)) Then

            Else
                m.Files = MyFunctions.Get_Moviepaths_in_array(m.Pfad)
                If m.Files.Length > 0 Then

                End If
            End If
        Else
            m.Files = MyFunctions.Get_Moviepaths_in_array(m.Pfad)
            If m.Files.Length > 0 Then

            End If
        End If





        If Not m.Files.Length = 0 Then
            Dim path As String = m.Files(0)
            If m.Files(0).ToLower.EndsWith("video_ts") Then
                Dim movies() As String = IO.Directory.GetFiles(m.Files(0), "*.vob")
                Array.Sort(movies)

                If movies.Length > 0 Then
                    Dim s As String = ""
                    Dim d As Long = 0
                    For x As Integer = 0 To movies.Length - 1
                        If Not IO.Path.GetFileName(movies(x)).ToLower = "video_ts.vob" Then
                            Dim fa As Long = FileLen(movies(x))
                            If fa > d Then
                                s = movies(x)
                                d = fa
                            End If
                        End If
                    Next
                    If s = "" Then
                        Exit Sub
                    End If
                    path = s
                End If
            End If
            If IO.File.Exists(path) Then






                If IO.File.Exists(exe) Then
                    Dim sheet As New Process
                    sheet.StartInfo.FileName = shortpath(exe)
                    Dim dpath As String = Getdpath()
                    If Not IO.Directory.Exists(dpath) Then
                        IO.Directory.CreateDirectory(dpath)
                    End If
                    For Each f In IO.Directory.GetFiles(dpath)
                        Try
                            IO.File.Delete(f)

                        Catch ex As Exception

                        End Try

                    Next
                    'D:\Downloads\mtn-200808a-win32\mtn-200808a-win32\mtn.exe -s 65 -c 1 -r 1 -i -t "D:\123.avi"
                    'sheet.StartInfo.Arguments = "-c 1 -r 1 -w 0 -i -t " + shortpath(path)

                    'MsgBox(dpath)
                    'MsgBox(shortpath(path))
                    sheet.StartInfo.Arguments = "-O """ & dpath & """ -I -c 1 -r " & Einstellungen.Config_Abrufen.Abrufen_Thumbnails_Count & " -i -t -P " & """" & path & """"
                    'Process.Start(dpath)
                    sheet.StartInfo.UseShellExecute = False

                    sheet.StartInfo.RedirectStandardOutput = True

                    sheet.StartInfo.CreateNoWindow = True


                    sheet.Start()





                    sheet.WaitForExit()

                    'Dim Infooutput As String = sheet.StandardOutput.ReadLine(0)
                    ''Dim Audiooutput As String = Audio.StandardOutput.ReadToEnd
                    ''Dim Videooutput As String = Video.StandardOutput.ReadToEnd
                    'MsgBox(Infooutput)
                    sheet.Close()
                    sheet.Dispose()


                    Dim arr() As String = GetFileArry(dpath)
                    If arr.Length > 0 Then

                        Dim hu As New Sheet_Result
                        hu.movie = m
                        For x As Integer = 0 To arr.Length - 1
                            Dim ps As New Prev_Sheet(arr(x), m)
                            hu.Results.Add(ps)
                        Next
                        Results.Add(hu)


                    End If




                    'CopySheet()
                    'Dim p As New Sheet_Result
                    'p.movie = m




                Else
                    MsgBox("Plugin nicht gefunden")
                End If
            End If
        End If
    End Sub



    Private Declare Auto Function GetShortPathName Lib "kernel32.dll" ( _
ByVal lpszLongPath As String, _
ByVal lpszShortPath As String, _
ByVal cchBuffer As Int32 _
) As Int32
    Private Function shortpath(ByVal s As String) As String
        Dim strPath As String = s
        Dim strShortPath As String = Space(100)
        Dim n As Int32 = GetShortPathName(strPath, strShortPath, 100)
        'MsgBox(Strings.Left(strShortPath, n))
        Dim filepath As String = Strings.Left(strShortPath, n)
        Return filepath
    End Function
    Private Sub CopySheet()
        'MsgBox(DatenLaden.GetPathofFile(path))

        'Dim files() As String = GetFileArry()
        'If files.Length > 1 Then
        '    For x As Integer = 0 To files.Length - 2
        '        'Process.Start(files(x))
        '        If Not files(x).EndsWith("_s.jpg") Then
        '            IO.File.Move(files(x), ImageDestinations.Fanart(MyFunctions.GetPathofFile(path)))
        '        End If
        '    Next
        'End If


        'Dim f As String = IO.Path.Combine(MyFunctions.GetPathofFile(path), IO.Path.GetFileNameWithoutExtension(shortpath(path)) & "_s.jpg")
        ''MsgBox(f)
        'If IO.File.Exists(f) Then
        '    'If IO.File.Exists(IO.Path.Combine(DatenLaden.GetPathofFile(path), "backdrop.jpg")) Then
        '    '    IO.File.Delete(IO.Path.Combine(DatenLaden.GetPathofFile(path), "backdrop.jpg"))
        '    'End If
        '    Dim s As String = ImageDestinations.Fanart(MyFunctions.GetPathofFile(path))
        '    IO.File.Move(f, s)
        '    MsgBox("Sheet erfolgreich erstellt")
        '    Process.Start(s)
        'End If

    End Sub
    Private Function GetNextAviablePath(ByVal p As String) As String
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            Dim i As Boolean = False
            Dim s As String = ""
            Dim c As Integer = 0
            Dim ps As String = IO.Path.Combine(p, "Fanart")
            If IO.Directory.Exists(ps) = False Then
                IO.Directory.CreateDirectory(ps)
            End If
            Do Until i = True
                If c = 0 Then
                    If IO.File.Exists(IO.Path.Combine(ps, "Backdrop.jpg")) Then
                        c += 1
                    Else
                        i = True
                        Return IO.Path.Combine(ps, "Backdrop.jpg")
                    End If
                Else
                    If IO.File.Exists(IO.Path.Combine(ps, "Backdrop" & c & ".jpg")) Then
                        c += 1
                    Else
                        i = True
                        Return IO.Path.Combine(ps, "Backdrop" & c & ".jpg")

                    End If
                End If
            Loop
            Return s
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
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
        Else
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
        End If
    End Function


    Private Function GetFileArry(ByVal dpath As String) As String()
        Dim arr() As String = IO.Directory.GetFiles(dpath, "*.jpg")
        Dim r As New List(Of String)
        If arr.Length > 0 Then
            For x As Integer = 0 To arr.Length - 1
                If Not arr(x).EndsWith("_s.jpg") Then
                    r.Add(arr(x))
                End If
            Next
        End If
        Dim rr() As String
        rr = r.ToArray
        Array.Sort(rr)
        Return rr
    End Function

    Private Sub Builddialog(ByVal m As Movie)


    End Sub

    Sub Builddialog()
        If Results.Count > 0 Then
            For Each r In Results
                For Each s In r.Results
                    s.add()
                Next
            Next
        End If
        Dialog_Sheet.vorschau.Tag = Einstellungen.UserInterFace.Fanartsize_previewsize
        Dialog_Sheet.Sheetresults = Results
        If Einstellungen.UserInterFace.Fanartsize_maximized = True Then
            Dialog_Sheet.WindowState = FormWindowState.Maximized
        Else
            If Not Einstellungen.UserInterFace.Fanartsize_w = -1 Then
                Dialog_Sheet.Size = New Size(Einstellungen.UserInterFace.Fanartsize_w, Einstellungen.UserInterFace.Fanartsize_h)
            End If
        End If



        If CStr(Dialog_Sheet.vorschau.Tag) = "0" Then
            Dialog_Sheet.SetIMgwith(100)

            Dialog_Sheet.vorschau.Image = Toolbar16.View_klein
        ElseIf CStr(Dialog_Sheet.vorschau.Tag) = "1" Then
            Dialog_Sheet.SetIMgwith(150)

            Dialog_Sheet.vorschau.Image = Toolbar16.View_mittel
        ElseIf CStr(Dialog_Sheet.vorschau.Tag) = "2" Then
            Dialog_Sheet.SetIMgwith(200)

            Dialog_Sheet.vorschau.Image = Toolbar16.View_groß
        ElseIf CStr(Dialog_Sheet.vorschau.Tag) = "3" Then

            Dialog_Sheet.SetIMgwith(300)
            Dialog_Sheet.vorschau.Image = Toolbar16.View_extragroß
        End If


        Dialog_Sheet.Show()
    End Sub

    Sub MoveImages(ByVal sheet_Result As Sheet_Result)
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            MoveImages_Info(sheet_Result)
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
            MoveImagesmymovies(sheet_Result)

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
            MoveImages_xbmc(sheet_Result)
        End If

        Try
            sheet_Result.movie.Backdrops = MyFunctions.Backdropsarr(sheet_Result.movie.Pfad)
        Catch ex As Exception

        End Try



    End Sub


  
    Private Sub MoveImages_Info(ByVal sheet_Result As Sheet_Result)
        Dim pfad As String = sheet_Result.movie.Pfad
        Dim fils() As String = MyFunctions.Backdropsarr(pfad)
        Dim backs As New List(Of Bitmap)

        If fils.Length > 0 Then
            For x As Integer = 0 To fils.Length - 1
                Dim i As Bitmap = CType(MyFunctions.ImageFromJpeg(fils(x)), Bitmap)
                If Not IsNothing(i) Then
                    backs.Add(i)
                End If
            Next
        End If
        Dim vergleichen As Boolean = True
        If backs.Count = 0 Then
            vergleichen = False
        End If

        If IO.Directory.Exists(IO.Path.Combine(pfad, "Fanart")) = False Then
            IO.Directory.CreateDirectory(IO.Path.Combine(pfad, "Fanart"))
            vergleichen = False
        End If
        Try






            For Each i In sheet_Result.Results

                If vergleichen = True Then
                    'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                    Dim img2 As Bitmap = CType(Image.FromFile(i.path), Bitmap)
                    If img2 Is Nothing Then
                        MsgBox("img2 ist nichts")
                    End If
                    For y As Integer = 0 To backs.Count - 1

                        'MsgBox(IO.File.Exists(d.files(x).Destination))
                        'If Not IsNothing(img2) Then
                        If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                            img2.Dispose()
                            IO.File.Delete(i.path)
                            GoTo nextr
                        End If
                        'End If

                    Next
                    img2.Dispose()
                    Try
                        Dim s As String = ImageDestinations.Fanart_info(pfad)

                        IO.File.Move(i.path, s)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                Else

                    Try
                        Dim s As String = ImageDestinations.Fanart_info(pfad)
                        IO.File.Move(i.path, s)
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If

nextr:
            Next



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
    Private Sub MoveImagesmymovies(ByVal sheet_Result As Sheet_Result)
        Dim pfad As String = sheet_Result.movie.Pfad
        Dim fils() As String = MyFunctions.Backdropsarr(pfad)
        Dim backs As New List(Of Bitmap)


        If fils.Length > 0 Then
            For x As Integer = 0 To fils.Length - 1
                Dim i As Bitmap = CType(MyFunctions.ImageFromJpeg(fils(x)), Bitmap)
                If Not IsNothing(i) Then
                    backs.Add(i)
                End If
            Next
        End If

        Dim vergleichen As Boolean = True
        If backs.Count = 0 Then
            vergleichen = False
        End If
        For Each i In sheet_Result.Results
            'BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))

            If vergleichen = True Then
                'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                Dim img2 As Bitmap = CType(Image.FromFile(i.path), Bitmap)
                If img2 Is Nothing Then
                    MsgBox("img2 ist nichts")
                End If
                For y As Integer = 0 To backs.Count - 1

                    'MsgBox(IO.File.Exists(d.files(x).Destination))
                    'If Not IsNothing(img2) Then
                    If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                        img2.Dispose()
                        IO.File.Delete(i.path)
                        GoTo nextr
                    End If
                    'End If

                Next
                img2.Dispose()
                Try
                    Dim s As String = ImageDestinations.Fanart_mymovies(pfad)

                    IO.File.Move(i.path, IO.Path.Combine(pfad, ImageDestinations.Fanart_mymovies(pfad)))
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

            Else
                Try
                    Dim s As String = ImageDestinations.Fanart_mymovies(pfad)
                    IO.File.Move(i.path, IO.Path.Combine(pfad, ImageDestinations.Fanart_mymovies(pfad)))
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If


nextr:
        Next




    End Sub
    Private Sub MoveImages_xbmc(ByVal sheet_Result As Sheet_Result)
        Dim pfad As String = sheet_Result.movie.Pfad
        Dim fils() As String = MyFunctions.Backdropsarr(pfad)
        Dim backs As New List(Of Bitmap)

        If fils.Length > 0 Then
            For x As Integer = 0 To fils.Length - 1
                Dim i As Bitmap = CType(MyFunctions.ImageFromJpeg(fils(x)), Bitmap)
                If Not IsNothing(i) Then
                    backs.Add(i)
                End If
            Next
        End If

        Dim vergleichen As Boolean = True
        If backs.Count = 0 Then
            vergleichen = False
        End If

        For Each i In sheet_Result.Results
            'BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))



            If vergleichen = True Then
                'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                Dim img2 As Bitmap = CType(Image.FromFile(i.path), Bitmap)
                If img2 Is Nothing Then
                    MsgBox("img2 ist nichts")
                End If
                For y As Integer = 0 To backs.Count - 1

                    'MsgBox(IO.File.Exists(d.files(x).Destination))
                    'If Not IsNothing(img2) Then
                    If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                        img2.Dispose()
                        IO.File.Delete(i.path)
                        GoTo nextr
                    End If
                    'End If

                Next
                img2.Dispose()
                Try
                    Dim s As String = ImageDestinations.Fanart_xbmc(pfad)

                    IO.File.Move(i.path, s)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try

            Else

                Try
                    Dim s As String = ImageDestinations.Fanart_xbmc(pfad)
                    IO.File.Move(i.path, s)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
nextr:
        Next
    End Sub

End Class
