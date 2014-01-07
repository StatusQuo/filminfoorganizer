Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Public Class MediaInfoProvider
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
    Sub New()

    End Sub




    Public Sub Inform(ByVal m As Movie, Optional ByVal writetoPanel As Boolean = False)



        Dim mi As MediaInfo
        mi = New MediaInfo


        Dim s As String = MediaInfoFunctions.CheckFile(m)
        If s = "" Then
            Exit Sub
        End If
        mi.Open(s)

        'Dim r_complete As String = ""
        'Dim r_VideoAuflösung As String = ""
        'Dim r_VideoSeitenverhältnis As String = ""
        'Dim r_VideoBildwiederholungsrate As String = ""
        'Dim r_width As String = ""
        'Dim r_height As String = ""
        'Dim r_VideoCodec As String = ""
        'Dim r_AudioKanäle As String = ""
        'Dim r_AudioCodec As String = ""
        'Dim r_AudioSprachen As String = ""
        'Dim r_Dauer As String = ""

        Dim sFormat As String = mi.Get_(StreamKind.Audio, 0, "Format")
        Dim sFormat_Profile As String = mi.Get_(StreamKind.Audio, 0, "Format_Profile")
        Dim sCodec As String = mi.Get_(StreamKind.Audio, 0, "CodecID/Hint")
        If sCodec = "" Then
            r_AudioCodec = sFormat '& " " & sFormat_Profile
        Else
            r_AudioCodec = sCodec
        End If


        'auflösung
        Dim sheight As String = mi.Get_(StreamKind.Visual, 0, "Height")
        Dim swidth As String = mi.Get_(StreamKind.Visual, 0, "Width")

        r_width = swidth
        r_height = sheight

        r_VideoAuflösung = GetVAuflösung(r_height, r_width)

        Dim sframerate As String = mi.Get_(StreamKind.Visual, 0, "FrameRate")
        Try

            Dim nVal As Double = CDbl(sframerate.Replace(".", ","))
            r_VideoBildwiederholungsrate = CStr(Math.Round(nVal))

        Catch ex As Exception

        End Try
        r_AudioKanäle = mi.Get_(StreamKind.Audio, 0, "Channel(s)")
        r_AudioSprachen = mi.Get_(StreamKind.Audio, 0, "Language/String")

        Dim vFormat As String = mi.Get_(StreamKind.Visual, 0, "Format")
        Dim vFormat_Profile As String = mi.Get_(StreamKind.Visual, 0, "Format_Profile")
        Dim vCodec As String = mi.Get_(StreamKind.Visual, 0, "CodecID/Hint")

        If vCodec = "" Or vCodec = "V_MPEG4/ISO/AVC" Then
            r_VideoCodec = vFormat '& " " & vFormat_Profile
        Else
            r_VideoCodec = vCodec
        End If
        'MsgBox(mi.Get_(StreamKind.General, 0, "Format"))
        'MsgBox(mi.Get_(StreamKind.Visual, 0, "CodecID/Hint"))
        'MsgBox(mi.Get_(StreamKind.Visual, 0, "Format_Commercial"))
        'MsgBox(mi.Get_(StreamKind.Visual, 0, "Codec/String"))
        'r_VideoCodec = mi.Get_(StreamKind.Visual, 0, "CodecID")
        r_VideoSeitenverhältnis = mi.Get_(StreamKind.Visual, 0, "DisplayAspectRatio/String")

        Dim sdauer As String = mi.Get_(StreamKind.Visual, 0, "Duration")

        r_Dauer = GetDauerFormat(m, sdauer)
 

        mi.Close()




        If r_VideoBildwiederholungsrate = "" Then
            r_VideoBildwiederholungsrate = Einstellungen.Config_Abrufen.Abrufen_MediaInfo_StandardFramerate
        End If
        If r_AudioSprachen = "" Then
            r_AudioSprachen = Einstellungen.Config_Abrufen.Abrufen_MediaInfo_StandardSprache
        End If
        If writetoPanel = False Then
            WritetoMovie(m)
        End If



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
Module MediaInfoFunctions
    Function CheckFile(m As Movie) As String
        If m.Files.Length > 0 Then
            If m.Files(0).ToLower.EndsWith("video_ts") Then
                Dim movies() As String = IO.Directory.GetFiles(m.Files(0), "*.ifo")
                Array.Sort(movies)

                If movies.Length > 0 Then
                    Dim s As String = ""
                    Dim d As Long = 0
                    For x As Integer = 0 To movies.Length - 1
                        If Not IO.Path.GetFileName(movies(x)).ToLower = "video_ts.ifo" Then
                            Dim fa As Long = FileLen(movies(x))
                            If fa > d Then
                                s = movies(x)
                                d = fa
                            End If
                        End If
                    Next
                    If s = "" Then
                        Return ""
                    End If
                    Return s
                End If
                'If IO.File.Exists(IO.Path.Combine(m.Files(0), "VTS_01_0.IFO")) Then
                '    mi.Open(CStr(IO.Path.Combine(m.Files(0), "VTS_01_0.IFO")))
                'End If
                'If IO.File.Exists(IO.Path.Combine(m.Files(0), "VTS_02_0.IFO")) Then
                '    mi.Open(CStr(IO.Path.Combine(m.Files(0), "VTS_02_0.IFO")))
                'End If
            Else
                Return m.Files(0)
            End If
        Else
            m.Files = MyFunctions.Get_Moviepaths_in_array(m.Pfad)
            If m.Files.Length > 0 Then
                If m.Files(0).ToLower.EndsWith("video_ts") Then
                    Dim movies() As String = IO.Directory.GetFiles(m.Files(0), "*.ifo")
                    Array.Sort(movies)

                    If movies.Length > 0 Then
                        Dim s As String = ""
                        Dim d As Long = 0
                        For x As Integer = 0 To movies.Length - 1
                            If Not IO.Path.GetFileName(movies(x)).ToLower = "video_ts.ifo" Then
                                Dim fa As Long = FileLen(movies(x))
                                If fa > d Then
                                    s = movies(x)
                                    d = fa
                                End If
                            End If
                        Next
                        If s = "" Then
                            Exit Function
                        End If
                        Return s
                    End If
                Else
                    Return m.Files(0)
                End If
            Else
                Return ""
            End If
        End If
    End Function
    Function GetVAuflösung(ByVal h As String, ByVal w As String) As String
        Dim heightx As Integer = Einstellungen.toInt(h)
        Dim widthx As Integer = Einstellungen.toInt(w)

        Dim r As String = ""

        If Not heightx = -1 Then
            If heightx > 760 Then
                r = "1080"
            ElseIf heightx <= 760 And (heightx > 576 Or widthx > 1000) Then
                r = "720"
            ElseIf heightx = 540 And widthx > 900 Then
                r = "540"
            ElseIf heightx <= 576 And (heightx > 360 Or widthx > 1000) Then
                r = "576"
            ElseIf heightx <= 360 And (heightx > 240 Or widthx > 1000) Then
                r = "360"
            ElseIf heightx <= 240 And (heightx > 0 Or widthx > 1000) Then
                r = "240"
            Else
                r = "SD"
            End If
        End If

        Return r
    End Function
    Function GetVAspect(ByVal h As String, ByVal w As String) As String
        Dim heightx As Integer = Einstellungen.toInt(h)
        Dim widthx As Integer = Einstellungen.toInt(w)

        Dim r As String = ""
        Dim a As Double = Math.Round(CDbl(w) / CDbl(h), 2)
        If Not (a = 1.33 Or a = 1.66 Or a = 1.78 Or a = 1.85 Or a = 2.2 Or a = 2.35) Then
            Select Case a
                Case Is <= 1.5
                    r = "1.33"
                Case Is <= 1.7
                    r = "1.66"
                Case Is <= 1.8
                    r = "1.78"
                Case Is <= 1.95
                    r = "1.85"
                Case Is <= 2.2
                    r = "2.20"
                Case Else
                    r = "2.35"
            End Select
          

        Else
            If a = 2.2 Then Return "2.20"
            Return CStr(a)
        End If



        Return r
    End Function
    Function GetDauerFormat(ByRef m As Movie, ByVal sdauer As String) As String
        Dim r_Dauer As String = ""
        If Einstellungen.Config_Abrufen.Abrufen_MediaInfo_Dauer_AKT = True Then

            Dim ldauer As Long = 0
            Try
                ldauer = CLng(sdauer)
            Catch ex As Exception

            End Try
            If m.Files.Length > 1 Then
                For x As Integer = 1 To m.Files.Length - 1
                    If IO.File.Exists(m.Files(x)) Then
                        ldauer += GetTime(m.Files(x))
                    End If
                Next
            End If





            Dim I As Integer = CInt(ldauer / 1000 / 60)

            If Einstellungen.Config_Abrufen.Abrufen_MediaInfo_Dauer_Format = 1 Then
                r_Dauer = CStr(I)
            ElseIf Einstellungen.Config_Abrufen.Abrufen_MediaInfo_Dauer_Format = 2 Then
                If I >= 60 Then
                    r_Dauer = MyFunctions.FormatSeconds(CLng(ldauer / 1000), "hh:mm")
                Else
                    r_Dauer = "00:" & CStr(I)
                End If
            Else
                If I >= 60 Then
                    r_Dauer = MyFunctions.FormatSeconds(CLng(ldauer / 1000), "hh:mm")
                    r_Dauer = r_Dauer.Replace(":", "h ") & "mn"
                Else
                    r_Dauer = CStr(I) & "mn"
                End If
            End If
        End If

        Return r_Dauer

    End Function
    Function GetTime(ByVal file As String) As Long
        Dim mi As MediaInfo
        mi = New MediaInfo
        mi.Open(file)
        Dim sdauer As String = mi.Get_(StreamKind.Visual, 0, "Duration")
        Dim ldauer As Long = 0
        Try
            ldauer = CLng(sdauer)
        Catch ex As Exception

        End Try
        mi.Close()
        Return ldauer

    End Function
End Module