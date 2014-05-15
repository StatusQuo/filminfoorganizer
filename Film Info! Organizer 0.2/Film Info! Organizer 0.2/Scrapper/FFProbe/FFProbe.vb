Public Class FFProbe
    Property exe As String = Application.StartupPath & "\Plugins\ffprobe\ffprobe.exe"



    Property r_complete As String = ""
    Property r_VideoAuflösung As String = ""
    Property r_VideoSeitenverhältnis As String = ""
    Property r_VideoBildwiederholungsrate As String = ""
    Property r_width As String = ""
    Property r_height As String = ""
    Property r_VideoCodec As String = ""
    Property r_AudioKanäle As String = ""
    Property r_AudioCodec As String = ""
    Property r_AudioSprachen As String = ""
    Property r_Dauer As String = ""
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





    Public Sub Inform(ByVal m As Movie, Optional ByVal writeToPanel As Boolean = False)
        Dim exe As String = Application.StartupPath & "\Plugins\ffprobe\ffprobe.exe"
        If IO.File.Exists(exe) Then
            Dim sheet As New Process
            sheet.StartInfo.FileName = shortpath(exe)


            Dim input As String = MediaInfoFunctions.CheckFile(m)

            If input = "" Then Exit Sub
            sheet.StartInfo.Arguments = "-show_streams -print_format xml " & """" & input & """"
            'Process.Start(dpath)
            sheet.StartInfo.UseShellExecute = False

            sheet.StartInfo.RedirectStandardOutput = True

            sheet.StartInfo.CreateNoWindow = True


            sheet.Start()





            sheet.WaitForExit()

            Dim Infooutput As String = sheet.StandardOutput.ReadToEnd
            ''Dim Audiooutput As String = Audio.StandardOutput.ReadToEnd
            ''Dim Videooutput As String = Video.StandardOutput.ReadToEnd
            ' MsgBox(Infooutput)
            sheet.Close()
            sheet.Dispose()

            Dim xml As New Xml.XmlDocument
            xml.LoadXml(Infooutput)

            xml.Save("D:\x.xml")


            'Dim r_VideoAuflösung As String = ""
            'Dim r_VideoSeitenverhältnis As String = ""
            'Dim r_VideoBildwiederholungsrate As String = ""
            'Dim r_width As String = ""
            'Dim r_height As String = ""
            'Dim r_VideoCodec As String = ""

            'Dim r_AudioKanäle As String = ""
            'Dim r_AudioCodec As String = ""
            'Dim r_AudioSprachen As String = ""

            Dim r_sec As Integer = 0
            Dim AudioLogged As Boolean = False
            Dim VideoLogged As Boolean = False


            Dim n As Xml.XmlNodeList = xml.SelectNodes("//stream")
            For Each i As Xml.XmlNode In n
                If i.Attributes("codec_type").Value = "audio" And AudioLogged = False Then
                    'Dann audio
                    r_AudioKanäle = i.Attributes("channels").Value
                    r_AudioCodec = i.Attributes("codec_name").Value
                ElseIf i.Attributes("codec_type").Value = "video" And VideoLogged = False Then
                    'Dann Video
                    r_width = i.Attributes("width").Value
                    r_height = i.Attributes("height").Value
                    r_VideoCodec = i.Attributes("codec_name").Value

                    Dim f As String = i.Attributes("r_frame_rate").Value
                    If f.Contains("/") Then
                        f = f.Substring(0, f.IndexOf("/"))
                    End If
                    r_VideoBildwiederholungsrate = f
                    If Not i.Attributes("duration") Is Nothing Then
                        f = i.Attributes("duration").Value
                        If f.Contains(".") Then
                            f = f.Substring(0, f.IndexOf("."))
                        End If
                        r_sec = Einstellungen.toInt(f, 0)
                    End If



                End If



            Next
            If r_sec = 0 Then
                r_Dauer = GetDauerFormat(m, CStr(MediaInfoFunctions.GetTime(input)))
            Else

                r_Dauer = GetDauerFormat(m, CStr(r_sec * 1000))
            End If

            r_VideoAuflösung = MediaInfoFunctions.GetVAuflösung(r_height, r_width)
            r_VideoSeitenverhältnis = MediaInfoFunctions.GetVaspect(r_height, r_width)
            If r_VideoBildwiederholungsrate = "" Then
                r_VideoBildwiederholungsrate = Einstellungen.Config_Abrufen.Abrufen_MediaInfo_StandardFramerate
            End If
            If r_AudioSprachen = "" Then
                r_AudioSprachen = Einstellungen.Config_Abrufen.Abrufen_MediaInfo_StandardSprache
            End If
            If writeToPanel = False Then
                WritetoMovie(m)
            End If



        Else
            MsgBox("Plugin nicht gefunden")
        End If

    End Sub
    Public Sub Get_Info(ByVal list As List(Of Movie))
        Try
            If list.Count > 0 Then
                For x As Integer = 0 To list.Count - 1
                    'If L Is Not Nothing Then
                    '    'Laden.Label1.Text = "Rufe Media Info ab... " & x + 1 & "/" & list.Count
                    '    'Laden.ProgressBar1.Value = CInt(((x + 1) / list.Count) * 100)
                    '    'Laden.Refresh()
                    'End If
                    Inform(list(x))
                    list(x).Refresh()
                    list(x).SaveFile()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Sub Get_Info(ByVal m As Movie, Optional ByVal writetoPanel As Boolean = False)
        'If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
        Try
            Inform(m, writetoPanel)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Else
        '    NichtVorhanden()
        'End If
    End Sub
    Public Sub WritetoMovie(ByVal m As Movie)
        m.VideoHöhe = r_height
        m.VideoBreite = r_width
        m.AudioCodec = r_AudioCodec.Trim
        m.AudioKanäle = r_AudioKanäle.Trim
        m.AudioSprachen = r_AudioSprachen.Trim
        m.VideoAuflösung = r_VideoAuflösung.Trim
        m.VideoBildwiederholungsrate = r_VideoBildwiederholungsrate.Trim
        m.VideoCodec = r_VideoCodec.Trim
        m.VideoSeitenverhältnis = r_VideoSeitenverhältnis.Trim
        If Einstellungen.Config_Abrufen.Abrufen_MediaInfo_Dauer_AKT = True Then
            m.Spieldauer = r_Dauer.Trim
        End If
    End Sub
    Public Sub WritetoPanel()
        With MainForm.InfoPanel_Movie1
            .TB_AudioCodec.Text = r_AudioCodec.Trim
            .TB_AudioKanäle.Text = r_AudioKanäle.Trim
            .TB_AudioSprachen.Text = r_AudioSprachen.Trim
            .TB_VideoAuflösung.Text = r_VideoAuflösung.Trim
            .TB_VideoBildwiederholungsrate.Text = r_VideoBildwiederholungsrate.Trim
            .TB_VideoCodec.Text = r_VideoCodec.Trim
            .TB_VideoSeitenverhältnis.Text = r_VideoSeitenverhältnis.Trim
            If Einstellungen.Config_Abrufen.Abrufen_MediaInfo_Dauer_AKT = True Then
                .TB_Spieldauer.Text = r_Dauer.Trim
            End If
            .TB_Videoheightwidth.Text = r_width & "x" & r_height
            .SelectedMovie.VideoBreite = r_width
            .SelectedMovie.VideoHöhe = r_height
        End With
    End Sub
End Class
