Imports System.Net
Public Enum Downloaditemtype
    Images
    Actors
    Trailer
End Enum

Public Class DownloadManager
    Public Shared Items As New List(Of DownloadItem)
    Public Shared Event ItemCompleted(ByVal item As DownloadItem)
    Public Shared Event Completed()
    Public Shared Event Started()
    Public Shared Event ItemAdded(ByVal row As DataGridViewRow)
    Public Shared Event ItemProgress(ByVal item As DownloadItem)
    Public Shared Event TimerChanged()

    Public Shared WithEvents TimerCounter As New Timer
    Public Shared _Count_Waitingfiles As Integer
    Public Shared _Count_Failedfiles As Integer
    Public Shared _Count_Finishedfiles As Integer
    Public Shared _Count_Allfiles As Integer
    Public Shared isRunning As Boolean = False

    Public Shared Sub CountFileTypes()
        _Count_Waitingfiles = 0
        _Count_Failedfiles = 0
        _Count_Finishedfiles = 0
        _Count_Allfiles = 0
        For Each a In Items
            _Count_Allfiles += a.List.Count
            For Each b In a.List
                Select Case b.Status
                    Case Is = DLState.Finished
                        _Count_Finishedfiles += 1
                    Case Is = DLState.Ready
                        _Count_Waitingfiles += 1
                    Case Is = DLState.Failed
                        _Count_Failedfiles += 1
                End Select
            Next
        Next
    End Sub

    Public Shared ReadOnly Property Count_TotalBytesToReceive As Long
        Get
            Dim i As Long = 0
            For Each s In Items
                i += s._Info_Filesize
            Next
            Return i
        End Get
    End Property
    Public Shared ReadOnly Property Count_BytesReceived As Long
        Get
            Dim i As Long = 0
            For Each s In Items
                i += s._Info_Loadedsize
            Next
            Return i
        End Get
    End Property


    Public Shared Function ChacheDir() As String
        Dim r As String = IO.Path.Combine(Einstellungen.ChachePath, "Downloads")
        If IO.Directory.Exists(r) = False Then
            IO.Directory.CreateDirectory(r)
        End If
        Return r
    End Function



    Sub New()
        TimerCounter.Interval = 1000
        AddHandler TimerCounter.Tick, AddressOf TimerCounter_Tick
    End Sub
    Public Shared Sub Add(ByVal LM As DownloadItem)

        AddHandler LM.ItemCompleted, AddressOf Item_Completed
        AddHandler LM.ItemDownloadProgressChanged, AddressOf Item_Progress
        'm.WC = DownloadClient
        Dim r As New DataGridViewRow
        r.CreateCells(Dialog_Download.MainList)
        r.Cells(Dialog_Download.MainColumn_Name.Index).Value = LM.Titel
        r.Cells(Dialog_Download.MainColumn_Gesamt.Index).Value = LM._Info_Filesize
        r.Cells(Dialog_Download.MainColumn_Geladen.Index).Value = 0

        r.Tag = LM
        LM.Row = r

        Items.Add(LM)
        RaiseEvent ItemAdded(LM.Row)
    End Sub

    Public Shared Sub Add(ByVal LM As List(Of WebFile))
        Dim m As New DownloadItem
        AddHandler m.ItemCompleted, AddressOf Item_Completed
        'm.WC = DownloadClient
        m.List = LM
        Items.Add(m)

    End Sub
    Public Shared Sub Run()

        For Each f In Items
            If f.Status = DLState.Ready Then
                '_aktive_File = f
                RaiseEvent Started()
                isRunning = True
                TimerCounter.Start()
                f.Status = DLState.Loading
                f.Run()
                Exit Sub

                'Try

                '    WC.DownloadFileAsync(f.Source, f.Destination)
                'Catch ex As Exception
                '    f.Status = DLState.Failed
                'End Try
                Exit Sub
            End If
        Next

        isRunning = False
        RaiseEvent Completed()

    End Sub
#Region "Events"

    Public Shared Sub Item_Completed(ByVal item As DownloadItem)
        RaiseEvent ItemCompleted(item)
        'MsgBox("Fertig")
        isRunning = False
        Run()
    End Sub


    '  Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
    '   ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles DownloadClient.DownloadProgressChanged
    '      'form1.ProgressBar2.Value = e.ProgressPercentage
    '      'Dim TotalBytes As Long = e.TotalBytesToReceive / 1024
    '      'Dim Bytes As Long = e.BytesReceived / 1024
    '      'If TotalBytes < 1 Then TotalBytes = 1
    '      'If Bytes < 1 Then Bytes = 1
    '      '_aktive_File.Info_Loadedsize = Bytes
    '  End Sub
    '  Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
    'ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles DownloadClient.DownloadFileCompleted

    '      'C:\Windows\Media\Windows-Benachrichtigung.wav
    '      'If canceld = True Then
    '      '    _aktive_File.Status = DLState.Canaceld
    '      '    _Subnode.Text = "Bilder Abgebrochen"
    '      '    _Subnode.BackColor = Color.Silver
    '      '    Status = DLState.Canaceld
    '      '    form1.wbl._act_downloads = -1
    '      '    form1.wbl.RunDownload()
    '      '    canceld = False
    '      'Else
    '      '    _aktive_File.Status = DLState.Finished
    '      '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
    '      '    Dim p As Integer = m / Files.Count * 100
    '      '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
    '      '    Dim ps As String = p
    '      '    If ps.Length = 1 Then
    '      '        ps = "00" & p
    '      '    End If
    '      '    If ps.Length = 2 Then
    '      '        ps = "0" & p
    '      '    End If
    '      '    _Node.Text = "| " & ps & " | " & _Node.Tag

    '      '    If m = Files.Count Then
    '      '        dlclient.Dispose()
    '      '        Status = DLState.Finished
    '      '        form1.wbl._act_downloads = -1
    '      '        form1.wbl.RunDownload()
    '      '        _Node.Text = _Node.Tag
    '      '        _Node.BackColor = Color.FromArgb(192, 255, 192)
    '      '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
    '      '        _Node.Collapse()
    '      '    Else
    '      '        Run() 'Nächsten Download starten"
    '      '    End If
    '      'End If

    '      'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
    '      'form1.Refresh()



    '      'dls(x).Dispose()
    '      'actDLs -= 1
    '      'Timer1.Stop()
    '      'If actDLs = 0 Then
    '      '    'Warteschlage()
    '      'End If

    '      'NextDownloadStart()
    '      'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    '  End Sub
#End Region

    Private Shared Sub Item_Progress(ByVal item As DownloadItem)
        RaiseEvent ItemProgress(item)
    End Sub

#Region "Timer"

    Public Shared tm_active_Downloads As String = ""
    Public Shared tm_all_Downloads As String = ""
    Public Shared tm_fail_Downloads As String = ""
    Public Shared tm_TotalBytes As String = ""
    Public Shared tm_RecievedBytes As String = ""
    Public Shared tm_BytesRemains As String = ""
    Public Shared tm_KBytesPerSecound As String = ""
    Public Shared tm_TimeLeft As String = ""
    Public Shared tm_Precentage As String = ""

    Public Shared backup_RecievedBytes As Long = 0
    Public Shared backup_Precentage As Integer = 0

    Public Sub TimerCounter_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim absolutkb As Long = DownloadManager.Count_TotalBytesToReceive
        Dim absolutkb_geladen As Long = DownloadManager.Count_BytesReceived
        Dim prcs As Integer = 0

        'Fortschritt
        If absolutkb_geladen = 0 Or absolutkb = 0 Then
        Else
            'Debug.WriteLine((absolutkb_geladen / absolutkb) * 100)
            prcs = CInt((absolutkb_geladen / absolutkb) * 100)
        End If



        If prcs = 100 Then
            'Dateien
            DownloadManager.CountFileTypes()
            tm_active_Downloads = CStr(DownloadManager._Count_Allfiles)
            tm_all_Downloads = "von " & CStr(DownloadManager._Count_Allfiles) & " Dateien"
            If DownloadManager._Count_Failedfiles = 0 Then
                tm_fail_Downloads = ""
            Else
                tm_fail_Downloads = CStr(DownloadManager._Count_Failedfiles) & " Fehler"
            End If
            'Kilobyte
            tm_TotalBytes = "/" & WebFunctions.FormatKiloBytes(absolutkb)
            tm_RecievedBytes = WebFunctions.FormatKiloBytes(absolutkb)
            tm_BytesRemains = "0 KB"
            tm_KBytesPerSecound = "0 KB"
            tm_TimeLeft = "0 Sekunden"
            tm_Precentage = "100"
            RaiseEvent TimerChanged()
            TimerCounter.Stop()
        Else
            'Dateien
            DownloadManager.CountFileTypes()
            tm_active_Downloads = CStr(DownloadManager._Count_Finishedfiles)
            tm_all_Downloads = "von " & CStr(DownloadManager._Count_Allfiles) & " Dateien"
            If DownloadManager._Count_Failedfiles = 0 Then
                tm_fail_Downloads = ""
            Else
                tm_fail_Downloads = CStr(DownloadManager._Count_Failedfiles) & " Fehler"
            End If

            'Kilobyte
            tm_TotalBytes = "/" & WebFunctions.FormatKiloBytes(absolutkb)
            tm_RecievedBytes = WebFunctions.FormatKiloBytes(absolutkb_geladen)
            tm_BytesRemains = WebFunctions.FormatKiloBytes(absolutkb - absolutkb_geladen)
            Dim old As Long = backup_RecievedBytes

            Dim ans As Integer = CInt((absolutkb_geladen - old))
            If ans > 0 Then
                ' MsgBox("")

                'Speed
                tm_KBytesPerSecound = ans & "KB"

            Else
                tm_KBytesPerSecound = "0 KB"
            End If






            'If Not prcs * 10 - 10 < 0 And Not ProgressBar1.Value = prcs * 10 Then
            '    ProgressBar1.Value = prcs * 10 - 10
            '    ProgressBar1.Value = prcs * 10 - 8
            '    ProgressBar1.Value = prcs * 10 - 6
            '    ProgressBar1.Value = prcs * 10 - 4
            '    ProgressBar1.Value = prcs * 10 - 2
            'End If
            'Label1.Text = prcs
            'ProgressBar1.Value = prcs * 10

            tm_Precentage = CStr(prcs)
            'Akt_DLs.Text = wbl.Count(DLState.Finished)
            'all_dls.Text = wbl.Count(DLState.Ready) & " in der Warteschlange"

            Dim oldprc As Integer = backup_Precentage
            backup_Precentage = prcs

            'Dim difprc As Integer = CInt((prcs - oldprc))
            Dim difprc As Integer = 0
            If Not ans = 0 Then
                difprc = CInt((absolutkb - absolutkb_geladen) / ans)
            End If




            If difprc > 0 Then


                tm_TimeLeft = BuildReststring(difprc)

            Else

            End If

            backup_RecievedBytes = absolutkb_geladen

            'Me.Refresh()
            RaiseEvent TimerChanged()
        End If
    End Sub
    Private Function remnull(ByVal s As String) As String
        Dim r As String = "s"
        If s.StartsWith("0") Then
            r = s.Remove(0, 1)
        End If
        Return r
    End Function
    Private Function BuildReststring(ByVal restdauer As Integer) As String
        'If times.Count = 0 Then
        '    Return ""
        'End If
        Dim r As String = "Noch "
        Dim h As String = MyFunctions.FormatSeconds(restdauer, "HH")
        Dim m As String = MyFunctions.FormatSeconds(restdauer, "mm")
        Dim s As String = MyFunctions.FormatSeconds(restdauer, "ss")
        If Not h = "00" Then
            r &= remnull(h)
            If h = "01" Then
                r &= " Stunde"
            Else
                r &= " Stunden"
            End If
        ElseIf Not m = "00" Then
            r &= "einige Minuten"
            'r &= remnull(m)

            'If m = "01" Then
            '    r &= " Minute"
            'Else
            '    r &= " Minuten"
            'End If
        Else
            'r &= remnull(s)
            'If s = "01" Then
            '    r &= " Sekunde"
            'Else
            '    r &= " Sekunden"
            'End If
            r &= "wenige Sekunden"
        End If
        Return r
    End Function
    Public Function FormatSeconds(ByVal nSeconds As Long, _
  Optional ByVal sFormat As String = "HH:mm:ss") As String

        Return CDate("00:00:00").AddSeconds(nSeconds).ToString(sFormat)
    End Function
#End Region
End Class
Public Class DownloadItem
    Property DestMovie As Movie
    Property Row As DataGridViewRow
    Property Type As Downloaditemtype
    Property List As New List(Of WebFile)
    Public Event ItemCompleted(ByVal item As DownloadItem)
    Public Event ItemDownloadProgressChanged(ByVal item As DownloadItem)
    Public WithEvents BW_Downloader As New System.ComponentModel.BackgroundWorker
    Property Precantage As Integer = 0
    Property Status As DLState = DLState.Ready
    Public WithEvents WC As New WebClient
    Private _aktive_File As WebFile
    Sub New()
        BW_Downloader.WorkerReportsProgress = True
        BW_Downloader.WorkerSupportsCancellation = True
    End Sub
    ReadOnly Property _Info_Filesize As Long
        Get
            Dim i As Long = 0
            For Each s In List
                i += s.Info_Filesize
            Next
            Return i
        End Get
    End Property
    ReadOnly Property _Info_Loadedsize As Long
        Get
            Dim i As Long = 0
            For Each s In List
                i += s.Info_Loadedsize
            Next
            Return i
        End Get
    End Property
    Dim stitel As String = ""
    Property Titel As String
        Get
            If stitel = "" Then
                Return DestMovie.Titel
            Else
                Return stitel
            End If
        End Get
        Set(ByVal value As String)
            stitel = value
        End Set
    End Property

    Private Sub Downloader_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BW_Downloader.DoWork
        MoveImages()

    End Sub

    Private Sub BW_Downloader_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BW_Downloader.ProgressChanged
        Precantage = e.ProgressPercentage
        RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub BW_Downloader_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BW_Downloader.RunWorkerCompleted

        Status = DLState.Finished

        RaiseEvent ItemCompleted(Me)


    End Sub

    Public Sub Run()

        For Each f In List
            If f.Status = DLState.Ready Then
                _aktive_File = f
                f.Status = DLState.Loading
                Try
                    WC.DownloadFileAsync(f.Source, f.Destination)
                Catch ex As Exception
                    MsgBox(ex.Message)
                    f.Status = DLState.Failed
                    _aktive_File.Status = DLState.Failed
                End Try
                Exit Sub
            End If
        Next
        'RaiseEvent ItemCompleted(Me)
        Status = DLState.Moving
        RaiseEvent ItemDownloadProgressChanged(Me)
        BW_Downloader.RunWorkerAsync()


    End Sub

    Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
   ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        'form1.ProgressBar2.Value = e.ProgressPercentage
        Dim TotalBytes As Long = CLng(e.TotalBytesToReceive / 1024)
        'Dim TotalBytes2 As Long = WebFunctions.WebFileSize(_aktive_File.Source.AbsolutePath)
        'MsgBox(TotalBytes & vbCrLf & TotalBytes2)
        Dim Bytes As Long = CLng(e.BytesReceived / 1024)
        If TotalBytes < 1 Then TotalBytes = 1
        If Bytes < 1 Then Bytes = 1
        _aktive_File.Info_Loadedsize = Bytes
        _aktive_File.Info_Filesize = TotalBytes
        'If Not TotalBytes = _aktive_File.Info_Filesize_old Then
        '    MsgBox(TotalBytes & vbCrLf & _aktive_File.Info_Filesize_old)
        'End If

        RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
  ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        If Not e.Error Is Nothing Then
            RaiseEvent ItemDownloadProgressChanged(Me)
        Else
            If IO.File.Exists(_aktive_File.Destination) Then
                _aktive_File.Status = DLState.Loaded
                _aktive_File.Info_Loadedsize = _aktive_File.Info_Filesize
            Else
                _aktive_File.Status = DLState.Failed
                _aktive_File.Info_Loadedsize = 0
            End If
            Run()
        End If



        'C:\Windows\Media\Windows-Benachrichtigung.wav
        'If canceld = True Then
        '    _aktive_File.Status = DLState.Canaceld
        '    _Subnode.Text = "Bilder Abgebrochen"
        '    _Subnode.BackColor = Color.Silver
        '    Status = DLState.Canaceld
        '    form1.wbl._act_downloads = -1
        '    form1.wbl.RunDownload()
        '    canceld = False
        'Else
        '    _aktive_File.Status = DLState.Finished
        '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
        '    Dim p As Integer = m / Files.Count * 100
        '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
        '    Dim ps As String = p
        '    If ps.Length = 1 Then
        '        ps = "00" & p
        '    End If
        '    If ps.Length = 2 Then
        '        ps = "0" & p
        '    End If
        '    _Node.Text = "| " & ps & " | " & _Node.Tag

        '    If m = Files.Count Then
        '        dlclient.Dispose()
        '        Status = DLState.Finished
        '        form1.wbl._act_downloads = -1
        '        form1.wbl.RunDownload()
        '        _Node.Text = _Node.Tag
        '        _Node.BackColor = Color.FromArgb(192, 255, 192)
        '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
        '        _Node.Collapse()
        '    Else
        '        Run() 'Nächsten Download starten"
        '    End If
        'End If

        'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
        'form1.Refresh()



        'dls(x).Dispose()
        'actDLs -= 1
        'Timer1.Stop()
        'If actDLs = 0 Then
        '    'Warteschlage()
        'End If

        'NextDownloadStart()
        'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    End Sub
#Region "Verschieben"
    Private Sub MoveImages()
        If Me.Type = Downloaditemtype.Images Then
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                MoveImages_Info()
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
                MoveImagesmymovies()
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                MoveImages_xbmc()
            End If
        ElseIf Me.Type = Downloaditemtype.Actors Then
            MoveImages_Darsteller()
        ElseIf Me.Type = Downloaditemtype.Trailer Then
            MoveTrailer()
        End If


        BW_Downloader.ReportProgress(100)
    End Sub
    Private Sub MoveImages_Darsteller()
        Dim pfad As String = Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName

        Try




            For Each i In List
                BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))


                If Not i.Status = DLState.Failed Then


                    i.Status = DLState.Moving
                    If Not i.Actorname = "" Then
                        Dim actor_pfad As String = IO.Path.Combine(pfad, Renamer.CheckInvalid_F(i.Actorname))
                        If IO.Directory.Exists(actor_pfad) = False Then
                            IO.Directory.CreateDirectory(actor_pfad)
                        End If
                        If i.imgType = ImageType.Actor Then
                            Try

                                If Not IO.File.Exists(IO.Path.Combine(actor_pfad, "folder.jpg")) Then
                                    IO.File.Move(i.Destination, IO.Path.Combine(actor_pfad, "folder.jpg"))
                                    'IO.File.Delete(IO.Path.Combine(actor_pfad, "folder.jpg"))

                                End If



                                'DestMovie.Cover = IO.Path.Combine(actor_pfad, "folder.jpg")
                                'MsgBox(9)
                                'If d.m.focused = True Then
                                '    MsgBox(10)
                                '    d.m.RefreshCover()
                                '    MsgBox(11)
                                'End If
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                            i.Status = DLState.Finished
                        End If
                    End If
                End If
            Next



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub MoveImages_Info()
        Dim pfad As String = DestMovie.Pfad
        Try


            If IO.Directory.Exists(IO.Path.Combine(pfad, "Fanart")) = False Then
                IO.Directory.CreateDirectory(IO.Path.Combine(pfad, "Fanart"))
            End If

            For Each i In List
                BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))
                If Not i.Status = DLState.Failed Then
                    i.Status = DLState.Moving

                    If i.imgType = ImageType.Cover Then
                        Try

                            If IO.File.Exists(IO.Path.Combine(pfad, "folder.jpg")) Then

                                IO.File.Delete(IO.Path.Combine(pfad, "folder.jpg"))

                            End If

                            IO.File.Move(i.Destination, IO.Path.Combine(pfad, "folder.jpg"))

                            DestMovie.Cover = IO.Path.Combine(pfad, "folder.jpg")
                            'MsgBox(9)
                            'If d.m.focused = True Then
                            '    MsgBox(10)
                            '    d.m.RefreshCover()
                            '    MsgBox(11)
                            'End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    Else
                        If Not IO.File.Exists(IO.Path.Combine(IO.Path.Combine(pfad, "Fanart"), IO.Path.GetFileName(i.Destination))) Then
                            Try
                                IO.File.Move(i.Destination, IO.Path.Combine(IO.Path.Combine(pfad, "Fanart"), IO.Path.GetFileName(i.Destination)))
                            Catch ex As Exception
                                MsgBox(ex.Message, MsgBoxStyle.Critical)
                            End Try
                        End If
                    End If
                    i.Status = DLState.Finished
                End If
            Next



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
        Try
            DestMovie.Backdrops = MyFunctions.Backdropsarr(pfad)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub MoveImagesmymovies()
        Dim pfad As String = DestMovie.Pfad
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
        For Each i In List
            BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))
            If Not i.Status = DLState.Failed Then
                i.Status = DLState.Moving
                If i.imgType = ImageType.Cover Then

                    Try
                        If IO.File.Exists(IO.Path.Combine(pfad, "folder.jpg")) Then
                            IO.File.Delete(IO.Path.Combine(pfad, "folder.jpg"))
                        End If

                        IO.File.Move(i.Destination, IO.Path.Combine(pfad, "folder.jpg"))
                        DestMovie.Cover = IO.Path.Combine(pfad, "folder.jpg")

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                Else
                    If vergleichen = True Then
                        'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                        Dim img2 As Bitmap = CType(Image.FromFile(i.Destination), Bitmap)
                        If img2 Is Nothing Then
                            MsgBox("img2 ist nichts")
                        End If
                        For y As Integer = 0 To backs.Count - 1

                            'MsgBox(IO.File.Exists(d.files(x).Destination))
                            'If Not IsNothing(img2) Then
                            If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                                img2.Dispose()
                                IO.File.Delete(i.Destination)
                                GoTo nextr
                            End If
                            'End If

                        Next
                        img2.Dispose()
                        Try
                            Dim s As String = ImageDestinations.Fanart_mymovies(pfad)

                            IO.File.Move(i.Destination, IO.Path.Combine(pfad, ImageDestinations.Fanart_mymovies(pfad)))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try

                    Else
                        Try
                            Dim s As String = ImageDestinations.Fanart_mymovies(pfad)
                            IO.File.Move(i.Destination, IO.Path.Combine(pfad, ImageDestinations.Fanart_mymovies(pfad)))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If


                End If

            End If
nextr:
            i.Status = DLState.Finished
        Next




    End Sub
    Private Sub MoveImages_xbmc()
        Dim pfad As String = DestMovie.Pfad
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

        For Each i In List
            BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))
            If Not i.Status = DLState.Failed Then
                i.Status = DLState.Moving
                If i.imgType = ImageType.Cover Then

                    Try
                        If IO.File.Exists(IO.Path.Combine(pfad, "movie.tbn")) Then
                            IO.File.Delete(IO.Path.Combine(pfad, "movie.tbn"))
                        End If
                        If IO.File.Exists(IO.Path.Combine(pfad, "folder.jpg")) Then
                            IO.File.Delete(IO.Path.Combine(pfad, "folder.jpg"))
                        End If
                        IO.File.Copy(i.Destination, IO.Path.Combine(pfad, "folder.jpg"))
                        IO.File.Move(i.Destination, IO.Path.Combine(pfad, "movie.tbn"))

                        DestMovie.Cover = IO.Path.Combine(pfad, "movie.tbn")

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                Else


                    If vergleichen = True Then
                        'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                        Dim img2 As Bitmap = CType(Image.FromFile(i.Destination), Bitmap)
                        If img2 Is Nothing Then
                            MsgBox("img2 ist nichts")
                        End If
                        For y As Integer = 0 To backs.Count - 1

                            'MsgBox(IO.File.Exists(d.files(x).Destination))
                            'If Not IsNothing(img2) Then
                            If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                                img2.Dispose()
                                IO.File.Delete(i.Destination)
                                GoTo nextr
                            End If
                            'End If

                        Next
                        img2.Dispose()
                        Try
                            Dim s As String = ImageDestinations.Fanart_xbmc(pfad)

                            IO.File.Move(i.Destination, s)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try

                    Else

                        Try
                            Dim s As String = ImageDestinations.Fanart_xbmc(pfad)
                            IO.File.Move(i.Destination, s)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Critical)
                        End Try
                    End If


                End If

nextr:
                i.Status = DLState.Finished
            End If
        Next
    End Sub

    Private Sub MoveTrailer()
        Dim pfad As String = DestMovie.Pfad
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Or _
            Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.DVDInfo Or _
            Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
            Dim destFolder As String = "Trailer"

            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
                destFolder = "Trailers"
            End If
            Try
                If IO.Directory.Exists(IO.Path.Combine(pfad, destFolder)) = False Then
                    IO.Directory.CreateDirectory(IO.Path.Combine(pfad, destFolder))
                End If

                For Each i In List
                    BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))
                    If Not i.Status = DLState.Failed Then
                        i.Status = DLState.Moving

                        IO.File.Move(i.Destination, IO.Path.Combine(IO.Path.Combine(pfad, destFolder), IO.Path.GetFileName(i.Destination)))
                        i.Status = DLState.Finished
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            Try
                For Each i In List
                    BW_Downloader.ReportProgress(CInt((List.IndexOf(i) / List.Count) * 100))
                    If Not i.Status = DLState.Failed Then
                        i.Status = DLState.Moving
                        Dim d As String = IO.Path.Combine(pfad, "movie-trailer" & IO.Path.GetExtension(i.Destination))
                        For Each s In DestMovie.Files
                            If IO.File.Exists(s) Then
                                d = IO.Path.Combine(pfad, IO.Path.GetFileNameWithoutExtension(s) & "-trailer" & IO.Path.GetExtension(i.Destination))
                                Exit For
                            End If
                        Next
                        IO.File.Move(i.Destination, d)
                        i.Status = DLState.Finished
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try

        End If

    End Sub
#End Region



End Class
Public Enum DLState
    Failed
    Ready
    Loading
    Finished
    Canaceld
    Moving
    Loaded
End Enum
Public Class WebFunctions

    ''' <summary>
    ''' IN KB
    ''' </summary>
    ''' <param name="sURL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function WebFileSize(ByVal sURL As String) As Long
        Dim nSize As Long = -1

        Try

            Dim oRequest As WebRequest = WebRequest.Create(sURL)
            oRequest.Method = "HEAD"
            Dim oResponse As WebResponse = oRequest.GetResponse

            nSize = CLng(oResponse.ContentLength / 1024)
            oResponse.Close()
        Catch ex As Exception
            'MsgBox("Könnte die Größe des Webfiles nicht bestimmen")
        End Try

        Return (nSize)
    End Function
    Public Shared Function FormatBytes(ByVal numberBytes As Double, Optional ByVal digits As Integer = 1) As String
        If numberBytes = 0 Then
            Return "0 KB"
        End If
        Dim value As Double = Math.Log(numberBytes, 1024.0#)
        Dim units() As String
        Dim index As Integer
        If value < 0.0# Then
            units = New String() {"B", "mB", "µB", "nB", "pB", "fB", "aB", "zB", "yB"}
        Else
            units = New String() {"B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}
        End If
        index = Math.Min(units.Length, CInt(Math.Floor(value)))
        Return Math.Round(numberBytes / 1024.0# ^ index, digits).ToString & " " & units(Math.Abs(index))
    End Function
    Public Shared Function FormatKiloBytes(ByVal numberBytes As Double, Optional ByVal digits As Integer = 1) As String
        If numberBytes = 0 Then
            Return "0 KB"
        End If
        Dim value As Double = Math.Log(numberBytes, 1024.0#)
        Dim units() As String
        Dim index As Integer
        If value < 0.0# Then
            units = New String() {"mB", "µB", "nB", "pB", "fB", "aB", "zB", "yB"}
        Else
            units = New String() {"KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"}
        End If
        index = Math.Min(units.Length, CInt(Math.Floor(value)))
        Return Math.Round(numberBytes / 1024.0# ^ index, digits).ToString & " " & units(Math.Abs(index))
    End Function
    'Public Shared Function FormatBytes(ByVal Bytes As Long) As String
    '    Dim s As String
    '    s = "KB"
    '    Dim t As Double = Bytes
    '    If Bytes > 1024 Then
    '        Bytes = CLng(Bytes / 102.4)

    '        s = "MB"
    '        t = Bytes / 10
    '        Bytes = CLng(Bytes / 10)
    '    End If
    '    If Bytes > 1024 Then
    '        Bytes = CLng(Bytes / 102.4)
    '        s = "GB"
    '        t = Bytes / 10
    '        Bytes = CLng(Bytes / 10)
    '    End If

    '    Dim r As String = t.ToString & " " & s
    '    Return r
    'End Function
    Public Shared Function FormatBytes2(ByVal Bytes As Long) As String
        Dim s As String
        s = "KB"
        Dim t As Double = Bytes
        If Bytes > 1024 Then
            Bytes = CLng(Bytes / 102.4)

            s = "MB"
            t = Bytes / 10
            Bytes = CLng(Bytes / 10)
        End If
        If Bytes > 1024 Then
            Bytes = CLng(Bytes / 102.4)
            s = "GB"
            t = Bytes / 10
            Bytes = CLng(Bytes / 10)
        End If

        Dim r As String = s & " " & t.ToString
        Return r
    End Function
    Public Shared Function ChacheDir() As String
        Dim r As String = IO.Path.Combine(Einstellungen.ChachePath, "Downloads")
        If IO.Directory.Exists(r) = False Then
            IO.Directory.CreateDirectory(r)
        End If
        Return r
    End Function
    Public Shared Function Get_dest(ByVal Sou As WebFile) As String
        If Sou.imgType = ImageType.Actor Then
            Return IO.Path.Combine(ChacheDir, ImageDestinations.Cache_Destination_Actor(ChacheDir))
        Else
            Return IO.Path.Combine(ChacheDir, ImageDestinations.Cache_Destination_File(Sou.Source.AbsolutePath))
        End If
    End Function
    Public Shared Function Get_TrailerDes(ByVal Sou As WebFile, ByVal isMMTrailer As Boolean) As String
        If isMMTrailer Then
            Return IO.Path.Combine(ChacheDir, IO.Path.GetFileName(Sou.Source.AbsoluteUri))
        Else
            Return IO.Path.Combine(ChacheDir, IO.Path.GetRandomFileName & ".mp4")
        End If
    End Function
    Shared Function EncodeUTF(ByVal s As String) As String
        s = s.Replace("&#x21;", "!") _
        .Replace("&#x22;", """") _
        .Replace("&#x23;", "#") _
        .Replace("&#x24;", "$") _
        .Replace("&#x25;", "%") _
        .Replace("&#x26;", "&") _
        .Replace("&#x27;", "'") _
        .Replace("&#x28;", "(") _
        .Replace("&#x29;", ")") _
        .Replace("&#x2A;", "*") _
        .Replace("&#x2B;", "+") _
        .Replace("&#x2C;", ",") _
        .Replace("&#x2D;", "-") _
        .Replace("&#x2E;", ".") _
        .Replace("&#x2F;", "/") _
        .Replace("&#x30;", "0") _
        .Replace("&#x31;", "1") _
        .Replace("&#x32;", "2") _
        .Replace("&#x33;", "3") _
        .Replace("&#x34;", "4") _
        .Replace("&#x35;", "5") _
        .Replace("&#x36;", "6") _
        .Replace("&#x37;", "7") _
        .Replace("&#x38;", "8") _
        .Replace("&#x39;", "9") _
        .Replace("&#x3A;", ":") _
        .Replace("&#x3B;", ";") _
        .Replace("&#x3C;", "<") _
        .Replace("&#x3D;", "=") _
        .Replace("&#x3E;", ">") _
        .Replace("&#x3F;", "?") _
        .Replace("&#x40;", "@") _
        .Replace("&#x41;", "A") _
        .Replace("&#x42;", "B") _
        .Replace("&#x43;", "C") _
        .Replace("&#x44;", "D") _
        .Replace("&#x45;", "E") _
        .Replace("&#x46;", "F") _
        .Replace("&#x47;", "G") _
        .Replace("&#x48;", "H") _
        .Replace("&#x49;", "I") _
        .Replace("&#x4A;", "J") _
        .Replace("&#x4B;", "K") _
        .Replace("&#x4C;", "L") _
        .Replace("&#x4D;", "M") _
        .Replace("&#x4E;", "N") _
        .Replace("&#x4F;", "O") _
        .Replace("&#x50;", "P") _
        .Replace("&#x51;", "Q") _
        .Replace("&#x52;", "R") _
        .Replace("&#x53;", "S") _
        .Replace("&#x54;", "T") _
        .Replace("&#x55;", "U") _
        .Replace("&#x56;", "V") _
        .Replace("&#x57;", "W") _
        .Replace("&#x58;", "X") _
        .Replace("&#x59;", "Y") _
        .Replace("&#x5A;", "Z") _
        .Replace("&#x5B;", "[") _
        .Replace("&#x5C;", "\") _
        .Replace("&#x5D;", "]") _
        .Replace("&#x5E;", "^") _
        .Replace("&#x5F;", "_") _
        .Replace("&#x60;", "`") _
        .Replace("&#x61;", "a") _
        .Replace("&#x62;", "b") _
        .Replace("&#x63;", "c") _
        .Replace("&#x64;", "d") _
        .Replace("&#x65;", "e") _
        .Replace("&#x66;", "f") _
        .Replace("&#x67;", "g") _
        .Replace("&#x68;", "h") _
        .Replace("&#x69;", "i") _
        .Replace("&#x6A;", "j") _
        .Replace("&#x6B;", "k") _
        .Replace("&#x6C;", "l") _
        .Replace("&#x6D;", "m") _
        .Replace("&#x6E;", "n") _
        .Replace("&#x6F;", "o") _
        .Replace("&#x70;", "p") _
        .Replace("&#x71;", "q") _
        .Replace("&#x72;", "r") _
        .Replace("&#x73;", "s") _
        .Replace("&#x74;", "t") _
        .Replace("&#x75;", "u") _
        .Replace("&#x76;", "v") _
        .Replace("&#x77;", "w") _
        .Replace("&#x78;", "x") _
        .Replace("&#x79;", "y") _
        .Replace("&#x7A;", "z") _
        .Replace("&#x7B;", "{") _
        .Replace("&#x7C;", "|") _
        .Replace("&#x7D;", "}") _
        .Replace("&#x7E;", "~") _
        .Replace("&#x7F;", "") _
        .Replace("&#x80;", "") _
        .Replace("&#x81;", "") _
        .Replace("&#x82;", "") _
        .Replace("&#x83;", "") _
        .Replace("&#x84;", "") _
        .Replace("&#x85;", "") _
        .Replace("&#x86;", "") _
        .Replace("&#x87;", "") _
        .Replace("&#x88;", "") _
        .Replace("&#x89;", "") _
        .Replace("&#x8A;", "") _
        .Replace("&#x8B;", "") _
        .Replace("&#x8C;", "") _
        .Replace("&#x8D;", "") _
        .Replace("&#x8E;", "") _
        .Replace("&#x8F;", "") _
        .Replace("&#x90;", "") _
        .Replace("&#x91;", "") _
        .Replace("&#x92;", "") _
        .Replace("&#x93;", "") _
        .Replace("&#x94;", "") _
        .Replace("&#x95;", "") _
        .Replace("&#x96;", "") _
        .Replace("&#x97;", "") _
        .Replace("&#x98;", "") _
        .Replace("&#x99;", "") _
        .Replace("&#x9A;", "") _
        .Replace("&#x9B;", "") _
        .Replace("&#x9C;", "") _
        .Replace("&#x9D;", "") _
        .Replace("&#x9E;", "") _
        .Replace("&#x9F;", "") _
        .Replace("&#xA0;", "") _
        .Replace("&#xA1;", "¡") _
        .Replace("&#xA2;", "¢") _
        .Replace("&#xA3;", "£") _
        .Replace("&#xA4;", "¤") _
        .Replace("&#xA5;", "¥") _
        .Replace("&#xA6;", "¦") _
        .Replace("&#xA7;", "§") _
        .Replace("&#xA8;", "¨") _
        .Replace("&#xA9;", "©") _
        .Replace("&#xAA;", "ª") _
        .Replace("&#xAB;", "«") _
        .Replace("&#xAC;", "¬") _
        .Replace("&#xAD;", "") _
        .Replace("&#xAE;", "®") _
        .Replace("&#xAF;", "¯") _
        .Replace("&#xB0;", "°") _
        .Replace("&#xB1;", "±") _
        .Replace("&#xB2;", "²") _
        .Replace("&#xB3;", "³") _
        .Replace("&#xB4;", "´") _
        .Replace("&#xB5;", "µ") _
        .Replace("&#xB6;", "¶") _
        .Replace("&#xB7;", "·") _
        .Replace("&#xB8;", "¸") _
        .Replace("&#xB9;", "¹") _
        .Replace("&#xBA;", "º") _
        .Replace("&#xBB;", "»") _
        .Replace("&#xBC;", "¼") _
        .Replace("&#xBD;", "½") _
        .Replace("&#xBE;", "¾") _
        .Replace("&#xBF;", "¿") _
        .Replace("&#xC0;", "À") _
        .Replace("&#xC1;", "Á") _
        .Replace("&#xC2;", "Â") _
        .Replace("&#xC3;", "Ã") _
        .Replace("&#xC4;", "Ä") _
        .Replace("&#xC5;", "Å") _
        .Replace("&#xC6;", "Æ") _
        .Replace("&#xC7;", "Ç") _
        .Replace("&#xC8;", "È") _
        .Replace("&#xC9;", "É") _
        .Replace("&#xCA;", "Ê") _
        .Replace("&#xCB;", "Ë") _
        .Replace("&#xCC;", "Ì") _
        .Replace("&#xCD;", "Í") _
        .Replace("&#xCE;", "Î") _
        .Replace("&#xCF;", "Ï") _
        .Replace("&#xD0;", "Ð") _
        .Replace("&#xD1;", "Ñ") _
        .Replace("&#xD2;", "Ò") _
        .Replace("&#xD3;", "Ó") _
        .Replace("&#xD4;", "Ô") _
        .Replace("&#xD5;", "Õ") _
        .Replace("&#xD6;", "Ö") _
        .Replace("&#xD7;", "×") _
        .Replace("&#xD8;", "Ø") _
        .Replace("&#xD9;", "Ù") _
        .Replace("&#xDA;", "Ú") _
        .Replace("&#xDB;", "Û") _
        .Replace("&#xDC;", "Ü") _
        .Replace("&#xDD;", "Ý") _
        .Replace("&#xDE;", "Þ") _
        .Replace("&#xDF;", "ß") _
        .Replace("&#xE0;", "à") _
        .Replace("&#xE1;", "á") _
        .Replace("&#xE2;", "â") _
        .Replace("&#xE3;", "ã") _
        .Replace("&#xE4;", "ä") _
        .Replace("&#xE5;", "å") _
        .Replace("&#xE6;", "æ") _
        .Replace("&#xE7;", "ç") _
        .Replace("&#xE8;", "è") _
        .Replace("&#xE9;", "é") _
        .Replace("&#xEA;", "ê") _
        .Replace("&#xEB;", "ë") _
        .Replace("&#xEC;", "ì") _
        .Replace("&#xED;", "í") _
        .Replace("&#xEE;", "î") _
        .Replace("&#xEF;", "ï") _
        .Replace("&#xF0;", "ð") _
        .Replace("&#xF1;", "ñ") _
        .Replace("&#xF2;", "ò") _
        .Replace("&#xF3;", "ó") _
        .Replace("&#xF4;", "ô") _
        .Replace("&#xF5;", "õ") _
        .Replace("&#xF6;", "ö") _
        .Replace("&#xF7;", "÷") _
        .Replace("&#xF8;", "ø") _
        .Replace("&#xF9;", "ù") _
        .Replace("&#xFA;", "ú") _
        .Replace("&#xFB;", "û") _
        .Replace("&#xFC;", "ü") _
        .Replace("&#xFD;", "ý") _
        .Replace("&#xFE;", "þ") _
        .Replace("&#xFF;", "ÿ") _
        .Replace("&quot;", """")

        Return s
        '.Replace("&#8220;", "“") _
        '.Replace("&#8221;", "”") _
    End Function
    Shared Function DecodeHTML(ByVal s As String) As String
        s = s.Replace("!", "&#33;")
        s = s.Replace("""", "&#34;")
        s = s.Replace("#", "&#35;")
        s = s.Replace("$", "&#36;")
        s = s.Replace("%", "&#37;")
        s = s.Replace("&", "&#38;")
        s = s.Replace("'", "&#39;")
        s = s.Replace("(", "&#40;")
        s = s.Replace(")", "&#41;")
        s = s.Replace("*", "&#42;")
        s = s.Replace("+", "&#43;")
        s = s.Replace(",", "&#44;")
        s = s.Replace("-", "&#45;")
        s = s.Replace(".", "&#46;")
        s = s.Replace("/", "&#47;")
        s = s.Replace("0", "&#48;")
        s = s.Replace("1", "&#49;")
        s = s.Replace("2", "&#50;")
        s = s.Replace("3", "&#51;")
        s = s.Replace("4", "&#52;")
        s = s.Replace("5", "&#53;")
        s = s.Replace("6", "&#54;")
        s = s.Replace("7", "&#55;")
        s = s.Replace("8", "&#56;")
        s = s.Replace("9", "&#57;")
        s = s.Replace(":", "&#58;")
        s = s.Replace(";", "&#59;")
        s = s.Replace("<", "&#60;")
        s = s.Replace("=", "&#61;")
        s = s.Replace(">", "&#62;")
        s = s.Replace("?", "&#63;")
        s = s.Replace("@", "&#64;")
        's = s.Replace("A", "&#65;")
        's = s.Replace("B", "&#66;")
        's = s.Replace("C", "&#67;")
        's = s.Replace("D", "&#68;")
        's = s.Replace("E", "&#69;")
        's = s.Replace("F", "&#70;")
        's = s.Replace("G", "&#71;")
        's = s.Replace("H", "&#72;")
        's = s.Replace("I", "&#73;")
        's = s.Replace("J", "&#74;")
        's = s.Replace("K", "&#75;")
        's = s.Replace("L", "&#76;")
        's = s.Replace("M", "&#77;")
        's = s.Replace("N", "&#78;")
        's = s.Replace("O", "&#79;")
        's = s.Replace("P", "&#80;")
        's = s.Replace("Q", "&#81;")
        's = s.Replace("R", "&#82;")
        's = s.Replace("S", "&#83;")
        's = s.Replace("T", "&#84;")
        's = s.Replace("U", "&#85;")
        's = s.Replace("V", "&#86;")
        's = s.Replace("W", "&#87;")
        's = s.Replace("X", "&#88;")
        's = s.Replace("Y", "&#89;")
        's = s.Replace("Z", "&#90;")
        s = s.Replace("[", "&#91;")
        s = s.Replace("\", "&#92;")
        s = s.Replace("]", "&#93;")
        s = s.Replace("^", "&#94;")
        s = s.Replace("_", "&#95;")
        s = s.Replace("`", "&#96;")
        's = s.Replace("a", "&#97;")
        's = s.Replace("b", "&#98;")
        's = s.Replace("c", "&#99;")
        's = s.Replace("d", "&#100;")
        's = s.Replace("e", "&#101;")
        's = s.Replace("f", "&#102;")
        's = s.Replace("g", "&#103;")
        's = s.Replace("h", "&#104;")
        's = s.Replace("i", "&#105;")
        's = s.Replace("j", "&#106;")
        's = s.Replace("k", "&#107;")
        's = s.Replace("l", "&#108;")
        's = s.Replace("m", "&#109;")
        's = s.Replace("n", "&#110;")
        's = s.Replace("o", "&#111;")
        's = s.Replace("p", "&#112;")
        's = s.Replace("q", "&#113;")
        's = s.Replace("r", "&#114;")
        's = s.Replace("s", "&#115;")
        's = s.Replace("t", "&#116;")
        's = s.Replace("u", "&#117;")
        's = s.Replace("v", "&#118;")
        's = s.Replace("w", "&#119;")
        's = s.Replace("x", "&#120;")
        's = s.Replace("y", "&#121;")
        's = s.Replace("z", "&#122;")
        s = s.Replace("{", "&#123;")
        s = s.Replace("|", "&#124;")
        s = s.Replace("}", "&#125;")
        s = s.Replace("~", "&#126;")
        's = s.Replace(" ", "&#160;")
        s = s.Replace("¡", "&#161;")
        s = s.Replace("¢", "&#162;")
        s = s.Replace("£", "&#163;")
        s = s.Replace("¤", "&#164;")
        s = s.Replace("¥", "&#165;")
        s = s.Replace("¦", "&#166;")
        s = s.Replace("§", "&#167;")
        s = s.Replace("¨", "&#168;")
        s = s.Replace("©", "&#169;")
        s = s.Replace("ª", "&#170;")
        s = s.Replace("«", "&#171;")
        s = s.Replace("¬", "&#172;")
        s = s.Replace("®", "&#174;")
        s = s.Replace("¯", "&#175;")
        s = s.Replace("°", "&#176;")
        s = s.Replace("±", "&#177;")
        s = s.Replace("²", "&#178;")
        s = s.Replace("³", "&#179;")
        s = s.Replace("´", "&#180;")
        s = s.Replace("µ", "&#181;")
        s = s.Replace("¶", "&#182;")
        s = s.Replace("·", "&#183;")
        s = s.Replace("¸", "&#184;")
        s = s.Replace("¹", "&#185;")
        s = s.Replace("º", "&#186;")
        s = s.Replace("»", "&#187;")
        s = s.Replace("¼", "&#188;")
        s = s.Replace("½", "&#189;")
        s = s.Replace("¾", "&#190;")
        s = s.Replace("¿", "&#191;")
        s = s.Replace("À", "&#192;")
        s = s.Replace("Á", "&#193;")
        s = s.Replace("Â", "&#194;")
        s = s.Replace("Ã", "&#195;")
        s = s.Replace("Ä", "&#196;")
        s = s.Replace("Å", "&#197;")
        s = s.Replace("Æ", "&#198;")
        s = s.Replace("Ç", "&#199;")
        s = s.Replace("È", "&#200;")
        s = s.Replace("É", "&#201;")
        s = s.Replace("Ê", "&#202;")
        s = s.Replace("Ë", "&#203;")
        s = s.Replace("Ì", "&#204;")
        s = s.Replace("Í", "&#205;")
        s = s.Replace("Î", "&#206;")
        s = s.Replace("Ï", "&#207;")
        s = s.Replace("Ð", "&#208;")
        s = s.Replace("Ñ", "&#209;")
        s = s.Replace("Ò", "&#210;")
        s = s.Replace("Ó", "&#211;")
        s = s.Replace("Ô", "&#212;")
        s = s.Replace("Õ", "&#213;")
        s = s.Replace("Ö", "&#214;")
        s = s.Replace("×", "&#215;")
        s = s.Replace("Ø", "&#216;")
        s = s.Replace("Ù", "&#217;")
        s = s.Replace("Ú", "&#218;")
        s = s.Replace("Û", "&#219;")
        s = s.Replace("Ü", "&#220;")
        s = s.Replace("Ý", "&#221;")
        s = s.Replace("Þ", "&#222;")
        s = s.Replace("ß", "&#223;")
        s = s.Replace("à", "&#224;")
        s = s.Replace("á", "&#225;")
        s = s.Replace("â", "&#226;")
        s = s.Replace("ã", "&#227;")
        s = s.Replace("ä", "&#228;")
        s = s.Replace("å", "&#229;")
        s = s.Replace("æ", "&#230;")
        s = s.Replace("ç", "&#231;")
        s = s.Replace("è", "&#232;")
        s = s.Replace("é", "&#233;")
        s = s.Replace("ê", "&#234;")
        s = s.Replace("ë", "&#235;")
        s = s.Replace("ì", "&#236;")
        s = s.Replace("í", "&#237;")
        s = s.Replace("î", "&#238;")
        s = s.Replace("ï", "&#239;")
        s = s.Replace("ð", "&#240;")
        s = s.Replace("ñ", "&#241;")
        s = s.Replace("ò", "&#242;")
        s = s.Replace("ó", "&#243;")
        s = s.Replace("ô", "&#244;")
        s = s.Replace("õ", "&#245;")
        s = s.Replace("ö", "&#246;")
        s = s.Replace("÷", "&#247;")
        s = s.Replace("ø", "&#248;")
        s = s.Replace("ù", "&#249;")
        s = s.Replace("ú", "&#250;")
        s = s.Replace("û", "&#251;")
        s = s.Replace("ü", "&#252;")
        s = s.Replace("ý", "&#253;")
        s = s.Replace("þ", "&#254;")
        s = s.Replace("ÿ", "&#255;")
        s = s.Replace("Œ", "&#338;")
        s = s.Replace("œ", "&#339;")
        s = s.Replace("Š", "&#352;")
        s = s.Replace("š", "&#353;")
        s = s.Replace("Ÿ", "&#376;")
        s = s.Replace("ƒ", "&#402;")
        s = s.Replace("–", "&#8211;")
        s = s.Replace("—", "&#8212;")
        s = s.Replace("‘", "&#8216;")
        s = s.Replace("’", "&#8217;")
        s = s.Replace("‚", "&#8218;")
        s = s.Replace("„", "&#8222;")
        s = s.Replace("†", "&#8224;")
        s = s.Replace("‡", "&#8225;")
        s = s.Replace("•", "&#8226;")
        s = s.Replace("…", "&#8230;")
        s = s.Replace("‰", "&#8240;")
        s = s.Replace("€", "&#8364;")

        Return s
        '.Replace("&#8220;", "“") _
        '.Replace("&#8221;", "”") _
    End Function

    ''' <summary>
    '''  Umlaute und Sonderzeichen verschlüsseln
    ''' </summary>
    ''' <param name="StringToEncode"></param>
    ''' <param name="UsePlusRatherThanHexForSpace">
    ''' False : Leerzeichen als %32 verschlüsseln
    ''' True  : Leerzeichen als + verschlüsseln
    ''' </param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function URLEncode(ByVal StringToEncode As String, Optional ByVal _
      UsePlusRatherThanHexForSpace As Boolean = False) As String

        Dim TempAns As String = ""
        Dim CurChr As Integer

        CurChr = 1
        Do Until CurChr - 1 = Len(StringToEncode)
            Select Case Asc(Mid$(StringToEncode, CurChr, 1))
                Case 48 To 57, 65 To 90, 97 To 122
                    TempAns = TempAns & Mid$(StringToEncode, CurChr, 1)
                Case 32
                    If UsePlusRatherThanHexForSpace = True Then
                        TempAns = TempAns & "+"
                    Else
                        TempAns = TempAns & "%" & Hex(32)
                    End If
                Case Else
                    TempAns = TempAns & "%" & Hex(Asc(Mid$(StringToEncode, _
                      CurChr, 1)))
            End Select
            CurChr = CurChr + 1
        Loop
        URLEncode = TempAns
    End Function

    Public Shared Function GetResponseURI(ByVal s As String) As String
        Dim httpUri As String = s
        Try
            Dim httpRequest As Net.HttpWebRequest '= CType(Net.HttpWebRequest.Create(s), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            ''&meta=&aq=f&oq=
            ''httpRequest.Method = "GET"
            'httpResponse = CType(httpRequest.GetResponse, Net.HttpWebResponse)
            'Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)

            'Dim d As String = reader.ReadToEnd

            'Dim tags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(d, "<PARAM NAME=""src"" VALUE=""([^""]*)"">")
            'If tags.Success = True Then
            '    httpUri = tags.Groups(1).Value
            '    httpUri = "http://moviemaze.de" & httpUri
            'End If
            'httpResponse.Close()
            ''If httpUri = s Then

            'httpRequest = CType(Net.HttpWebRequest.Create(httpUri), Net.HttpWebRequest)
            ''httpRequest.Method = "HEAD"
            'httpResponse = CType(httpRequest.GetResponse, Net.HttpWebResponse)

            'httpUri = httpRequest.GetResponse.ResponseUri.ToString
            'httpResponse.Close()
            'End If

            'MsgBox(httpRequest.Timeout)
            'Process.Start(httpUri)


        Catch ex As Exception

        End Try

        Return httpUri
    End Function



    ''' Entschlüsseln von mit URLEncode
    ''' verschlüsselten Zeichenketten
    Public Shared Function URLDecode(ByVal StringToDecode As String) As String
        Dim TempAns As String = ""
        Dim CurChr As Integer

        CurChr = 1
        Do Until CurChr - 1 = Len(StringToDecode)
            Select Case Mid$(StringToDecode, CurChr, 1)
                Case "+"
                    TempAns = TempAns & " "
                Case "%"
                    TempAns = TempAns & Chr(CInt(Val("&h" & _
                      Mid$(StringToDecode, CurChr + 1, 2))))
                    CurChr = CurChr + 2
                Case Else
                    TempAns = TempAns & Mid$(StringToDecode, CurChr, 1)
            End Select
            CurChr = CurChr + 1
        Loop
        URLDecode = TempAns
    End Function
    '    Shared Function DecodeHTML(ByVal s As String) As String
    '        s = s.Replace("!", "&#33;") _
    '.Replace("""", "&#34;") _
    '.Replace("#", "&#35;") _
    '.Replace("$", "&#36;") _
    '.Replace("%", "&#37;") _
    '.Replace("&", "&#38;") _
    '.Replace("'", "&#39;") _
    '.Replace("(", "&#40;") _
    '.Replace(")", "&#41;") _
    '.Replace("*", "&#42;") _
    '.Replace("+", "&#43;") _
    '.Replace(",", "&#44;") _
    '.Replace("-", "&#45;") _
    '.Replace(".", "&#46;") _
    '.Replace("/", "&#47;") _
    '.Replace("0", "&#48;") _
    '.Replace("1", "&#49;") _
    '.Replace("2", "&#50;") _
    '.Replace("3", "&#51;") _
    '.Replace("4", "&#52;") _
    '.Replace("5", "&#53;") _
    '.Replace("6", "&#54;") _
    '.Replace("7", "&#55;") _
    '.Replace("8", "&#56;") _
    '.Replace("9", "&#57;") _
    '.Replace(":", "&#58;") _
    '.Replace(";", "&#59;") _
    '.Replace("<", "&#60;") _
    '.Replace("=", "&#61;") _
    '.Replace(">", "&#62;") _
    '.Replace("?", "&#63;") _
    '.Replace("@", "&#64;") _
    '.Replace("A", "&#65;") _
    '.Replace("B", "&#66;") _
    '.Replace("C", "&#67;") _
    '.Replace("D", "&#68;") _
    '.Replace("E", "&#69;") _
    '.Replace("F", "&#70;") _
    '.Replace("G", "&#71;") _
    '.Replace("H", "&#72;") _
    '.Replace("I", "&#73;") _
    '.Replace("J", "&#74;") _
    '.Replace("K", "&#75;") _
    '.Replace("L", "&#76;") _
    '.Replace("M", "&#77;") _
    '.Replace("N", "&#78;") _
    '.Replace("O", "&#79;") _
    '.Replace("P", "&#80;") _
    '.Replace("Q", "&#81;") _
    '.Replace("R", "&#82;") _
    '.Replace("S", "&#83;") _
    '.Replace("T", "&#84;") _
    '.Replace("U", "&#85;") _
    '.Replace("V", "&#86;") _
    '.Replace("W", "&#87;") _
    '.Replace("X", "&#88;") _
    '.Replace("Y", "&#89;") _
    '.Replace("Z", "&#90;") _
    '.Replace("[", "&#91;") _
    '.Replace("\", "&#92;") _
    '.Replace("]", "&#93;") _
    '.Replace("^", "&#94;") _
    '.Replace("_", "&#95;") _
    '.Replace("`", "&#96;") _
    '.Replace("a", "&#97;") _
    '.Replace("b", "&#98;") _
    '.Replace("c", "&#99;") _
    '.Replace("d", "&#100;") _
    '.Replace("e", "&#101;") _
    '.Replace("f", "&#102;") _
    '.Replace("g", "&#103;") _
    '.Replace("h", "&#104;") _
    '.Replace("i", "&#105;") _
    '.Replace("j", "&#106;") _
    '.Replace("k", "&#107;") _
    '.Replace("l", "&#108;") _
    '.Replace("m", "&#109;") _
    '.Replace("n", "&#110;") _
    '.Replace("o", "&#111;") _
    '.Replace("p", "&#112;") _
    '.Replace("q", "&#113;") _
    '.Replace("r", "&#114;") _
    '.Replace("s", "&#115;") _
    '.Replace("t", "&#116;") _
    '.Replace("u", "&#117;") _
    '.Replace("v", "&#118;") _
    '.Replace("w", "&#119;") _
    '.Replace("x", "&#120;") _
    '.Replace("y", "&#121;") _
    '.Replace("z", "&#122;") _
    '.Replace("{", "&#123;") _
    '.Replace("|", "&#124;") _
    '.Replace("}", "&#125;") _
    '.Replace("~", "&#126;") _
    '.Replace(" ", "&#160;") _
    '.Replace("¡", "&#161;") _
    '.Replace("¢", "&#162;") _
    '.Replace("£", "&#163;") _
    '.Replace("¤", "&#164;") _
    '.Replace("¥", "&#165;") _
    '.Replace("¦", "&#166;") _
    '.Replace("§", "&#167;") _
    '.Replace("¨", "&#168;") _
    '.Replace("©", "&#169;") _
    '.Replace("ª", "&#170;") _
    '.Replace("«", "&#171;") _
    '.Replace("¬", "&#172;") _
    '.Replace("", "&#173;") _
    '.Replace("®", "&#174;") _
    '.Replace("¯", "&#175;") _
    '.Replace("°", "&#176;") _
    '.Replace("±", "&#177;") _
    '.Replace("²", "&#178;") _
    '.Replace("³", "&#179;") _
    '.Replace("´", "&#180;") _
    '.Replace("µ", "&#181;") _
    '.Replace("¶", "&#182;") _
    '.Replace("·", "&#183;") _
    '.Replace("¸", "&#184;") _
    '.Replace("¹", "&#185;") _
    '.Replace("º", "&#186;") _
    '.Replace("»", "&#187;") _
    '.Replace("¼", "&#188;") _
    '.Replace("½", "&#189;") _
    '.Replace("¾", "&#190;") _
    '.Replace("¿", "&#191;") _
    '.Replace("À", "&#192;") _
    '.Replace("Á", "&#193;") _
    '.Replace("Â", "&#194;") _
    '.Replace("Ã", "&#195;") _
    '.Replace("Ä", "&#196;") _
    '.Replace("Å", "&#197;") _
    '.Replace("Æ", "&#198;") _
    '.Replace("Ç", "&#199;") _
    '.Replace("È", "&#200;") _
    '.Replace("É", "&#201;") _
    '.Replace("Ê", "&#202;") _
    '.Replace("Ë", "&#203;") _
    '.Replace("Ì", "&#204;") _
    '.Replace("Í", "&#205;") _
    '.Replace("Î", "&#206;") _
    '.Replace("Ï", "&#207;") _
    '.Replace("Ð", "&#208;") _
    '.Replace("Ñ", "&#209;") _
    '.Replace("Ò", "&#210;") _
    '.Replace("Ó", "&#211;") _
    '.Replace("Ô", "&#212;") _
    '.Replace("Õ", "&#213;") _
    '.Replace("Ö", "&#214;") _
    '.Replace("×", "&#215;") _
    '.Replace("Ø", "&#216;") _
    '.Replace("Ù", "&#217;") _
    '.Replace("Ú", "&#218;") _
    '.Replace("Û", "&#219;") _
    '.Replace("Ü", "&#220;") _
    '.Replace("Ý", "&#221;") _
    '.Replace("Þ", "&#222;") _
    '.Replace("ß", "&#223;") _
    '.Replace("à", "&#224;") _
    '.Replace("á", "&#225;") _
    '.Replace("â", "&#226;") _
    '.Replace("ã", "&#227;") _
    '.Replace("ä", "&#228;") _
    '.Replace("å", "&#229;") _
    '.Replace("æ", "&#230;") _
    '.Replace("ç", "&#231;") _
    '.Replace("è", "&#232;") _
    '.Replace("é", "&#233;") _
    '.Replace("ê", "&#234;") _
    '.Replace("ë", "&#235;") _
    '.Replace("ì", "&#236;") _
    '.Replace("í", "&#237;") _
    '.Replace("î", "&#238;") _
    '.Replace("ï", "&#239;") _
    '.Replace("ð", "&#240;") _
    '.Replace("ñ", "&#241;") _
    '.Replace("ò", "&#242;") _
    '.Replace("ó", "&#243;") _
    '.Replace("ô", "&#244;") _
    '.Replace("õ", "&#245;") _
    '.Replace("ö", "&#246;") _
    '.Replace("÷", "&#247;") _
    '.Replace("ø", "&#248;") _
    '.Replace("ù", "&#249;") _
    '.Replace("ú", "&#250;") _
    '.Replace("û", "&#251;") _
    '.Replace("ü", "&#252;") _
    '.Replace("ý", "&#253;") _
    '.Replace("þ", "&#254;") _
    '.Replace("ÿ", "&#255;") _
    '.Replace("Œ", "&#338;") _
    '.Replace("œ", "&#339;") _
    '.Replace("Š", "&#352;") _
    '.Replace("š", "&#353;") _
    '.Replace("Ÿ", "&#376;") _
    '.Replace("ƒ", "&#402;") _
    '.Replace("–", "&#8211;") _
    '.Replace("—", "&#8212;") _
    '.Replace("‘", "&#8216;") _
    '.Replace("’", "&#8217;") _
    '.Replace("‚", "&#8218;") _
    '.Replace("„", "&#8222;") _
    '.Replace("†", "&#8224;") _
    '.Replace("‡", "&#8225;") _
    '.Replace("•", "&#8226;") _
    '.Replace("…", "&#8230;") _
    '.Replace("‰", "&#8240;") _
    '.Replace("€", "&#8364;")

    '        Return s
    '        '.Replace("&#8220;", "“") _
    '        '.Replace("&#8221;", "”") _
    '    End Function
End Class


