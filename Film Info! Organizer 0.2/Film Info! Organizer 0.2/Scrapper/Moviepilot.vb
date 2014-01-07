Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO

Public Class Scrapper_Moviepilot
    Const apiKey As String = "0c31f8afe1f218698a4c1ebb6b921c"
    Dim httptext As String = ""
    Public Function GetJson(Optional ByVal imdb As String = "") As Boolean
        If imdb = "" Then
            Return False
        End If
        If imdb.StartsWith("tt") Then
            imdb = imdb.Remove(0, 2)
        End If
        Do Until imdb.StartsWith("0") = False
            If imdb.Length > 0 Then
                imdb = imdb.Remove(0, 1)
            Else
                Exit Do
            End If

        Loop
        Dim url As String = "http://www.moviepilot.de/movies/imdb-id-" & imdb & ".json?api_key=" & apiKey

        'Dim httpRequest As HttpWebRequest = CType(HttpWebRequest.Create(url), HttpWebRequest)
        'Dim httpResponse As HttpWebResponse
        'Try
        '    httpResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
        'Catch ex As Exception
        '    Return False
        'End Try
        'Dim reader As StreamReader = New StreamReader(httpResponse.GetResponseStream, System.Text.Encoding.UTF8)

        'httptext = reader.ReadToEnd

        httptext = MyFunctions.HttploadText(url, "mopi.getInfo_de_" & imdb)
        If httptext Is Nothing Then httptext = ""
        gemoveHTMLChars()
        Try
            httptext = httptext.Remove(0, 1)
            httptext = httptext.Remove(httptext.Length - 1)
        Catch ex As Exception

        End Try

        Return True

    End Function
    Public Function Inhalt() As String
        If Not httptext = "" Then
            Return getValue("long_description")
        Else
            Return ""
        End If
    End Function
    Public Function Zelluloid() As String
        If Not httptext = "" Then
            Return getValue("zelluloid")
        Else
            Return ""
        End If
    End Function
    Public Function Jahr() As String
        If Not httptext = "" Then
            Return getValue("production_year")
        Else
            Return Nothing
        End If
    End Function
    Public Function Images_width() As Integer
        If Not httptext = "" Then
            Return getInt("width")
        Else
            Return -1
        End If
    End Function
    Public Function Images_height() As Integer
        If Not httptext = "" Then
            Return getInt("height")
        Else
            Return -1
        End If
    End Function
    Public Function photo_name_base() As String

        Dim base_url As String = ""
        Dim photo_id As String = ""
        Dim file_name_base As String = ""

        'extension = getValue(httptext, "extension", "poster")
        'base_url = getValue(httptext, "base_url", "poster")
        'file_name_base = getValue(httptext, "file_name_base", "poster")
        'photo_id = getValue(httptext, "photo_id", "poster")

        base_url = getValue("base_url")
        file_name_base = getValue("file_name_base")
        photo_id = getValue("photo_id")
        'p.Small = base_url & photo_id & "/" & file_name_base & "_poster." & extension
        'p.Large = base_url & photo_id & "/" & file_name_base & "_normal." & extension
        If base_url = "" Or file_name_base = "" Or photo_id = "" Then
            Return ""
        Else
            Return base_url & photo_id & "/" & file_name_base
        End If




    End Function
    Public Function photo_extension() As String
        If Not httptext = "" Then
            Dim ext As String = ""
            ext = getValue("extension")
            If ext = "" Then
                Return ""
            Else
                Return "." & ext
            End If

        Else
            Return Nothing
        End If
    End Function

    Private Function getValue(ByVal Name As String) As String
        Dim S As String = httptext


        S = S.Replace("\""", "&#34;")

        Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""([^""]*)""")
            'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
        If match.Success = True Then
            S = replaceJson(match.Groups(1).Value)
        Else
            Return ""
        End If


        Return S

    End Function
    Private Function getInt(ByVal Name As String) As Integer
        Dim S As String = httptext


        S = S.Replace("\""", "&#34;")

        Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:([0-9]*)")
        'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
        If match.Success = True Then
            S = replaceJson(match.Groups(1).Value).Trim
        End If
        Dim i As Integer = -1
        Try
            i = CInt(S)
        Catch ex As Exception

        End Try

        Return i

    End Function

    'Private Function getValue(ByVal s As String, ByVal Name As String, Optional ByVal subelement As String = "") As String
    '    If Not subelement = "" Then
    '        If s.Contains(subelement) Then
    '            Dim subel() As String = Split(s, subelement & """:{")
    '            If subel.Length > 1 Then
    '                Dim value2() As String = Split(subel(1), "}")
    '                s = value2(0)
    '            End If
    '        End If
    '    Else
    '        Dim TestString As String = "Ich  weiß   nicht, was  soll das " & vbTab & " bedeuten?"
    '        s = _
    '            New Regex( _
    '                ",?""\w*"":\{.*\},?", _
    '                RegexOptions.IgnoreCase Or RegexOptions.Multiline _
    '            ).Replace(s, "")

    '    End If
    '    Dim r As String = ""
    '    Dim value() As String = Split(s, Name)
    '    If value.Length > 1 Then
    '        Dim lim As String = ""

    '        If value(1).Contains(""",""") And value(1).Contains("""}""") Then
    '            If value(1).IndexOf(""",""") > value(1).IndexOf("""}""") Then
    '                lim = """}"
    '            Else
    '                lim = ""","
    '            End If
    '        ElseIf value(1).Contains(""",") Then
    '            lim = ","
    '        ElseIf value(1).Contains("""}") Then
    '            lim = "}"
    '        End If
    '        Dim value2() As String = Split(value(1), lim)
    '        Dim photo_idlex As New System.Text.RegularExpressions.Regex(""":\s?""(?<value>(.*))"".?$")
    '        If photo_idlex.IsMatch(value2(0)) Then
    '            r = photo_idlex.Match(value2(0)).Groups("value").Value
    '        End If
    '    End If
    '    Return r

    'End Function

    Private Sub gemoveHTMLChars()
        httptext = httptext.Replace("&amp;", "&") _
            .Replace("&#338;", "Œ") _
            .Replace("&#339;", "œ") _
            .Replace("&#352;", "Š") _
            .Replace("&#353;", "š") _
            .Replace("&#376;", "Ÿ") _
            .Replace("&#402;", "ƒ") _
            .Replace("&#8211;", "–") _
            .Replace("&#8212;", "—") _
            .Replace("&#8216;", "‘") _
            .Replace("&#8217;", "’") _
           .Replace("&#8218;", "‚") _
           .Replace("&#8222;", "„") _
           .Replace("&#8224;", "†") _
           .Replace("&#8225;", "‡") _
            .Replace("&#8226;", "•") _
           .Replace("&#8230;", "…") _
           .Replace("&#8240;", "‰") _
           .Replace("&#8364;", "€") _
           .Replace("&#8482;", "™") _
           .Replace("&#8220;", "&#34;") _
           .Replace("&#8221;", "&#34;")



    End Sub
    Private Function replaceJson(ByVal s As String) As String
        s = s.Replace("&#34;", """") _
            .Replace("\\", "\") _
            .Replace("\/", "/") _
            .Replace("\b", vbBack) _
            .Replace("\f", vbFormFeed) _
            .Replace("\n", vbCrLf) _
            .Replace("\r", "") _
            .Replace("\t", vbTab)
        Return s
    End Function
End Class
Friend Class ImageSource_Moviepilot
    Public Shared Function GetPrevImage(ByVal imdb As String) As PrevImage
        Dim js As New Scrapper_Moviepilot
        If js.GetJson(imdb) = True Then

            'r.Large = 
            Dim base_url As String = ""
            Dim extension As String = ""
            extension = js.photo_extension
            base_url = js.photo_name_base


            If Not base_url = "" And Not extension = "" Then

                Dim r As New PrevImage
                r.Type = ImageType.Cover
                r.isGerman = True
                r.Small = base_url & "_poster" & extension
                r.Large = base_url & "_normal" & extension
                r.Original = base_url & extension
                r.Width = js.Images_width
                r.Height = js.Images_height
                If r.Get_Filesize() Then
                    If r.Width > 300 Then
                        Return r
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
End Class
Friend Class MetaSource_Moviepilot
    Public Shared Function GetPlot(ByVal imdb As String) As String
        Dim js As New Scrapper_Moviepilot
        If js.GetJson(imdb) = True Then
            Return js.Inhalt
        Else
            Return ""
        End If

    End Function

    Shared Function GetZID(ByVal imdb As String) As String
        Dim js As New Scrapper_Moviepilot
        If js.GetJson(imdb) = True Then
            Return js.Zelluloid
        Else
            Return ""
        End If

    End Function

End Class



'Public Module MP
'    Public PM As PrevImage
'    Private Sub hqcover()


'Ende:
'    End Sub
'    ''' <summary>
'    ''' Liefert den Wert Von Name in einem Json basierten String
'    ''' </summary>
'    ''' <param name="s">Json-Text String</param>
'    ''' <param name="Name">Name des Feldes</param>
'    ''' <param name="subelement">Wenn sich der Name in einem Unterelement berfindet sollte dieser hier eingetragen werden</param>
'    ''' <returns>Liefert den Wert Von Name in einem Json basierten String</returns>
'    ''' <remarks></remarks>

'    Public Function GermanPrevImage(ByVal imdb As String, Optional ByVal writearr As Boolean = False) As Boolean
'        Dim url As String = ""
'        If imdb.StartsWith("tt") Then
'            imdb = imdb.Remove(0, 2)
'        End If
'        Do Until imdb.StartsWith("0") = False
'            imdb = imdb.Remove(0, 1)
'        Loop
'        Dim p As New PrevImage
'        p.isGerman = True
'        p.Type = ImageType.Cover


'        Dim httpRequest As HttpWebRequest = HttpWebRequest.Create("http://www.moviepilot.de//movies/imdb-id-" & imdb & ".json?api_key=0c31f8afe1f218698a4c1ebb6b921c")
'        Dim httpResponse As HttpWebResponse
'        Try
'            httpResponse = httpRequest.GetResponse()
'        Catch ex As Exception
'            'MsgBox("Keine Verbindung (404)")
'            Return False
'        End Try
'        Dim reader As StreamReader = New StreamReader(httpResponse.GetResponseStream)
'        Dim httptext As String = reader.ReadToEnd
'        httptext = httptext.Remove(0, 1)
'        httptext = httptext.Remove(httptext.Length - 1)
'        'MsgBox(httptext)

'        Dim base_url As String = ""
'        Dim photo_id As String = ""
'        Dim file_name_base As String = ""
'        Dim extension As String = ""

'        extension = getValue(httptext, "extension", "poster")
'        base_url = getValue(httptext, "base_url", "poster")
'        file_name_base = getValue(httptext, "file_name_base", "poster")
'        photo_id = getValue(httptext, "photo_id", "poster")

'        p.Small = base_url & photo_id & "/" & file_name_base & "_poster." & extension
'        p.Large = base_url & photo_id & "/" & file_name_base & "_normal." & extension
'        p.Original = base_url & photo_id & "/" & file_name_base & "_article." & extension

'        PM = p


'        Return True

'    End Function
'    Public Function GermanCover(ByVal imdb As String, Optional ByVal writearr As Boolean = False) As String
'        Dim url As String = ""
'        If imdb.StartsWith("tt") Then
'            imdb = imdb.Remove(0, 2)
'        End If
'        Do Until imdb.StartsWith("0") = False
'            imdb = imdb.Remove(0, 1)
'        Loop


'        Dim httpRequest As HttpWebRequest = HttpWebRequest.Create("http://www.moviepilot.de//movies/imdb-id-" & imdb & ".json?api_key=0c31f8afe1f218698a4c1ebb6b921c")
'        Dim httpResponse As HttpWebResponse
'        Try
'            httpResponse = httpRequest.GetResponse()
'        Catch ex As Exception
'            'MsgBox("Keine Verbindung (404)")
'            GoTo ende
'        End Try
'        Dim reader As StreamReader = New StreamReader(httpResponse.GetResponseStream)
'        Dim httptext As String = reader.ReadToEnd
'        httptext = httptext.Remove(0, 1)
'        httptext = httptext.Remove(httptext.Length - 1)
'        'MsgBox(httptext)

'        Dim base_url As String = ""
'        Dim photo_id As String = ""
'        Dim file_name_base As String = ""
'        Dim extension As String = ""

'        extension = getValue(httptext, "extension", "poster")
'        base_url = getValue(httptext, "base_url", "poster")
'        file_name_base = getValue(httptext, "file_name_base", "poster")
'        photo_id = getValue(httptext, "photo_id", "poster")
'        'MsgBox(getValue(httptext, "restful_url"))

'        'Process.Start(getValue(httptext, "restful_url"))
'        'MsgBox(getValue(httptext, "display_title"))

'        'MsgBox(getValue(httptext, "extension"))
'        'MsgBox(base_url & photo_id & "/" & file_name_base & "_article." & extension)
'        url = base_url & photo_id & "/" & file_name_base & "_article." & extension







'        If writearr = True Then

'            ReDim Preserve TMDB.coverimgsurl(2, TMDB.covercount - 1)

'            TMDB.coverimgsurl(1, TMDB.covercount - 1) = base_url & photo_id & "/" & file_name_base & "_normal." & extension

'            TMDB.coverimgsurl(0, TMDB.covercount - 1) = base_url & photo_id & "/" & file_name_base & "_poster." & extension

'            TMDB.coverimgsurl(2, TMDB.covercount - 1) = base_url & photo_id & "/" & file_name_base & "_article." & extension

'        End If
'Ende:
'        Return url

'    End Function
'    Public Sub addInCoverFanart(ByVal iarr As Integer)


'        TMDB.covercount += 1
'        If Not MP.GermanCover(Daten.arr(4, iarr), True) = "" Then

'            Array.Resize(TMDB.Cover, TMDB.covercount)
'            Dim cov As New CheckBox
'            TMDB.Cover(TMDB.covercount - 1) = cov
'            Array.Resize(Coverimgs, TMDB.covercount)
'            cov.BackgroundImageLayout = ImageLayout.Tile

'            cov.AutoSize = False
'            cov.CheckAlign = ContentAlignment.TopLeft
'            cov.Size = New System.Drawing.Size(54, 100)
'            cov.Appearance = Appearance.Button
'            cov.TextImageRelation = TextImageRelation.TextAboveImage
'            cov.Text = "DE"
'            AddHandler TMDB.Cover(TMDB.covercount - 1).Click, AddressOf Dialog_Fanart.cover_click
'            AddHandler TMDB.Cover(TMDB.covercount - 1).MouseEnter, AddressOf Dialog_Fanart.cover_mouseenter
'            AddHandler TMDB.Cover(TMDB.covercount - 1).MouseLeave, AddressOf Dialog_Fanart.Cover_leave
'            Dialog_Fanart.FlowLayoutPanel1.Controls.Add(TMDB.Cover(TMDB.covercount - 1))
'        Else
'            TMDB.covercount -= 1
'        End If





'    End Sub

'End Module