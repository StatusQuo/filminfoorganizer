Imports System.Xml
Imports System.IO
Imports System.Net
Public Enum Fanartsearchmode
    Dialog
    Automatic
End Enum
Public Enum ImageType
    Fanart
    Cover
    Actor
End Enum
Public Class WebFile
    Public Status As DLState
    Public Source As Uri
    Public Destination As String
    Public Info_Filesize As Long
    Public Info_Filesize_old As Long
    Public Info_Loadedsize As Long = 0
    Public imgType As ImageType
    Public Actorname As String = ""

    ''' <summary>
    ''' Konstruiert ein Webfile
    ''' </summary>
    ''' <param name="s">Source des Files</param>
    ''' <param name="dest">Ziel auf der Platte</param>
    ''' <remarks></remarks>
    Sub New(ByVal s As String, ByVal dest As String)
        Source = New Uri(s)
        Destination = dest
    End Sub
    Sub New(ByVal p As PrevImage)
        Source = New Uri(p.Original)
        Info_Filesize = p.FileSize
        Info_Filesize_old = p.FileSize

        If Info_Filesize > 0 Then

            Status = DLState.Ready
        Else

      
            Info_Filesize = WebFunctions.WebFileSize(p.Original)
            Info_Filesize_old = Info_Filesize
            Status = DLState.Ready
            'MsgBox(Info_Filesize)

        End If
        Destination = WebFunctions.Get_dest(Me)
        imgType = p.Type

    End Sub
    Function Get_Filesize() As Boolean
        Info_Filesize = WebFunctions.WebFileSize(Source.AbsoluteUri)
        If Info_Filesize = -1 Then
            Status = DLState.Failed
            Return False

        Else
            Status = DLState.Ready
            Return True

        End If
    End Function
    Sub New(ByVal s As String, ByVal dest As String, ByVal Filesize As Long)
        Source = New Uri(s)
        Destination = dest
        Info_Filesize = Filesize
        If Not Info_Filesize = -1 Then
            Status = DLState.Ready
        Else
            Status = DLState.Failed
        End If
    End Sub
    Sub New()

    End Sub
End Class

Public Class PrevImage
    Public Image As Image
    Public Control As PreviewCover
    Public CB As CheckBox
    Public Original As String
    Public Large As String
    Public Small As String
    Public Destination As String
    Public Width As Integer = 0
    Public Height As Integer = 0
    Public isGerman As Boolean = False
    Public Lang As String = ""
    Public Type As ImageType
    Public FileSize As Long
    Sub New()

    End Sub
    Function Get_Filesize() As Boolean
        FileSize = WebFunctions.WebFileSize(Original)
        If FileSize = -1 Then
            Return False
        Else
            Return True
        End If


    End Function

    Sub Dispose()
        If Not IsNothing(Image) Then
            Image.Dispose()
        End If

        CB.Dispose()
    End Sub

    Sub check()
        If Type = ImageType.Fanart Then





            If Small.EndsWith(".png") Then
                'Small.Replace(".png", ".jpg")
                Small = Small.Remove(Small.LastIndexOf(".png"), 4)
                Small &= ".jpg"

                'End If
                If Large.EndsWith(".png") Then
                    Large = Large.Remove(Large.LastIndexOf(".png"), 4)
                    Large &= ".jpg"
                End If
                If Original.EndsWith(".png") Then
                    Original = Original.Remove(Original.LastIndexOf(".png"), 4)
                    Original &= ".jpg"
                End If
            End If
        End If
    End Sub

End Class
Public Class TMDBImages

    Public Shared Sub Creatbar()


        Dialog_Fanart.FlowLayoutPanel3.Controls.Clear()
        Dialog_Fanart.prevpicboxes.Clear()

        If Dialog_Fanart.Backdrops.Count > 0 Then
            For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                If Dialog_Fanart.Backdrops(x).Checked = True Then
                    If Dialog_Fanart.Backdrops(x)._Result.Image IsNot Nothing Then
                        Dim m As New PictureBox
                        m.Image = Dialog_Fanart.Backdrops(x)._Result.Image
                        m.SizeMode = PictureBoxSizeMode.Zoom
                        m.Size = New Size(CInt(40 * (m.Image.Width / m.Image.Height)), 40)

                        Dialog_Fanart.FlowLayoutPanel3.Controls.Add(m)
                        Dialog_Fanart.prevpicboxes.Add(m)

                    End If
                End If
            Next
        End If

    End Sub


    '    Public Shared Function GetHomepage(ByVal Imdb As String) As String
    '        Dim r As String = ""
    '        Try

    '            Dim xml As XmlDocument ' Unser Document Container

    '            xml = New XmlDocument

    '            '5fe800e9f7891b9131c0059be62a36d0
    '            'Wir könnten jetzt eine xml Datei laden
    '            xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & Imdb)
    '            If IsNothing(xml) Then
    '                r = ""
    '            Else

    '                r = If(xml.SelectNodes("//url").Count > 0, xml.SelectSingleNode("//url").InnerText, "")

    '            End If
    '            'xml.Save("D:\ss.xml")
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    'ende:
    '        Return r

    '    End Function
    Public Shared List As New List(Of Movie)
    Public Links As New List(Of WebFile)
    Private Shared Cover_results As New List(Of PrevImage)
    Private Shared Backdrop_results As New List(Of PrevImage)
    Public Shared Sub Get_ImageLinks(ByVal m As List(Of Movie))
        List = m
        nextmovie()
    End Sub
    ''' <summary>
    ''' Start
    ''' </summary>
    ''' <param name="m"></param>
    ''' <param name="id"></param>
    ''' <param name="mode"></param>
    ''' <remarks></remarks>
    Public Shared Sub Get_ImageLinks(ByVal m As Movie, ByVal id As String, ByVal mode As Fanartsearchmode)
        Cover_results.Clear()
        Backdrop_results.Clear()


        ' Zeitmessung beginnen
        'oTime.Start()

        'Dim p As PrevImage =
        'If MP.GermanPrevImage(IMDB) = True Then
        '    Cover_results.Add(MP.PM)
        'End If
        'MsgBox(m.IMDB_ID)
        '   MoviePilotCover(id)

        If TMDB_Prev(id) = True Then
            If mode = Fanartsearchmode.Automatic Then
                FilterLinks_auto(m)
            Else


                Dialog_Fanart.movie = m
                BuildDialog()
                'Dialog_Fanart.Show()
                'FilterLinks_Dialog()
            End If
        Else
            Dialog_Fanart.movie = m
            BuildDialog()
        End If




    End Sub
    Public Shared Function Get_ImageLinks(ByVal id As String) As Boolean
        Cover_results.Clear()
        Backdrop_results.Clear()


        ' Zeitmessung beginnen
        'oTime.Start()

        'Dim p As PrevImage =
        'If MP.GermanPrevImage(IMDB) = True Then
        '    Cover_results.Add(MP.PM)
        'End If
        'MsgBox(m.IMDB_ID)
        '  MoviePilotCover(id)
        TMDB_Prev(id)
        If Cover_results.Count = 0 And Backdrop_results.Count = 0 Then
            Return False
        Else
            Return True
        End If




    End Function
    Private Shared Function TMDB_Prev(ByVal m As String) As Boolean

        Dim i, j As Integer    ' Hilfsvariablen
        'Dim xml As Xml.XmlDocument
        'xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.getImages/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & m, "tmdb.getImages_en_" & m)
        If m = "" Then
            Return False
        End If


        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "movie/" & m & "/images?api_key=" & Einstellungen.UserAbrufen.tmdbapiKey, "tmdb3.getImages_en_" & m)


        If IsNothing(xml) Then
            Return False
        End If










        'xml.Save("D:\test.xml")
        Dim xpath As String

        xpath = "//posters"
        Dim xmln As XmlNode ' Container für unseren aktiven Knoten
        ' Dim xmln2 As XmlNode
        ' Für den Fall das wir mehrere Knoten haben auf die unser 
        ' XPath zutrifft
        j = xml.SelectNodes(xpath).Count
        If j > 0 Then
            For i = 0 To j - 1 Step 1
                xmln = xml.SelectNodes(xpath).Item(i)
                If xmln.ChildNodes.Count > 0 Then

                    Dim t As New PrevImage
                    t.Type = ImageType.Cover
                    t.Height = If(xmln.SelectNodes("height").Count > 0, Einstellungen.toInt(xmln.SelectSingleNode("height").InnerText, 0), 0)
                    t.Width = If(xmln.SelectNodes("width").Count > 0, Einstellungen.toInt(xmln.SelectSingleNode("width").InnerText, 0), 0)


                    Dim imgur = If(xmln.SelectNodes("file_path").Count > 0, xmln.SelectSingleNode("file_path").InnerText, "")
                    'w92
                    'w500
                    'original
                    t.Small = Einstellungen.UserAbrufen.tmdbapibase_url & "w92" & imgur
                    t.Large = Einstellungen.UserAbrufen.tmdbapibase_url & "w500" & imgur
                    t.Original = Einstellungen.UserAbrufen.tmdbapibase_url & "original" & imgur
                    t.Lang = If(xmln.SelectNodes("iso_639_1").Count > 0, xmln.SelectSingleNode("iso_639_1").InnerText, "")
                    t.check()
                    If t.Get_Filesize = True Then
                        Cover_results.Add(t)
                    Else
                        'MsgBox("konnte Datei nicht finden")
                        'Try
                        '    Process.Start(t.Original)
                        'Catch ex As Exception

                        'End Try
                    End If


                End If
            Next i

        End If

        xpath = "//backdrops"
        j = xml.SelectNodes(xpath).Count
        If j > 0 Then
            For i = 0 To j - 1 Step 1
                xmln = xml.SelectNodes(xpath).Item(i)
                If xmln.ChildNodes.Count > 0 Then



                    Dim t As New PrevImage
                    t.Type = ImageType.Fanart

                    t.Height = If(xmln.SelectNodes("height").Count > 0, Einstellungen.toInt(xmln.SelectSingleNode("height").InnerText, 0), 0)
                    t.Width = If(xmln.SelectNodes("width").Count > 0, Einstellungen.toInt(xmln.SelectSingleNode("width").InnerText, 0), 0)


                    Dim imgur = If(xmln.SelectNodes("file_path").Count > 0, xmln.SelectSingleNode("file_path").InnerText, "")
                    'w300
                    'w780
                    'original
                    t.Small = Einstellungen.UserAbrufen.tmdbapibase_url & "w300" & imgur
                    t.Large = Einstellungen.UserAbrufen.tmdbapibase_url & "w780" & imgur
                    t.Original = Einstellungen.UserAbrufen.tmdbapibase_url & "original" & imgur
                    t.Lang = If(xmln.SelectNodes("iso_639_1").Count > 0, xmln.SelectSingleNode("iso_639_1").InnerText, "")



                    t.check()
                    If t.Get_Filesize = True Then
                        Backdrop_results.Add(t)

                    Else
                        'MsgBox("konnte Datei nicht finden")
                        'Try
                        '    Process.Start(t.Original)
                        'Catch ex As Exception

                        'End Try
                    End If

                End If
            Next i

        End If

        Return True

    End Function
    'Private Sub FilterLinks_Dialog()
    '    If BuildDialog() = DialogResult.OK Then
    '        Able = True


    '        Dim sURL As String = ""




    '        If mcplugin = 1 And _SMode = Fanartsearchmode.Dialog Then
    '            If Dialog_Fanart.Ersetzen.Checked = True Then
    '                Dim barr() As String = Backdropsarr(Pfad, True)
    '                If barr.Length > 0 Then
    '                    If MsgBox("Möchten Sie wirklich die vorhandenen " & barr.Length & " Backdrops löschen?", MsgBoxStyle.YesNo, "Löschen?") Then
    '                        For x As Integer = 0 To barr.Length - 1
    '                            Try
    '                                File.Delete(barr(x))
    '                            Catch ex As Exception
    '                                MsgBox("Die Datei: " & Path.GetFileName(barr(x)) & " konnte nicht gelöscht werden", MsgBoxStyle.Exclamation)
    '                            End Try
    '                        Next
    '                    End If
    '                End If
    '            End If
    '        End If

    '        If Cover_results.Count > 0 Then
    '            For x As Integer = 0 To Cover_results.Count - 1
    '                If Cover_results(x).CB.Checked = True Then
    '                    sURL = Cover_results(x).Original
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '        If sURL <> "" Then
    '            Links.Add(New WebFile(sURL, IO.Path.Combine(Pfad, "folder.jpg")))
    '        End If
    '        If Backdrop_results.Count > 0 Then
    '            For x As Integer = 0 To Backdrop_results.Count - 1
    '                If Backdrop_results(x).CB.Checked = True Then
    '                    Dim local As String = GetDest(Backdrop_results(x))
    '                    If Not local = "" Then
    '                        Dim wb As WebFile = New WebFile(Backdrop_results(x).Original, local)
    '                        Links.Add(wb)

    '                    End If
    '                End If
    '            Next
    '        End If

    '    End If


    'End Sub

    'Private Function GetDest(ByVal p1 As PrevImage) As String
    '    Dim sURL As String = p1.Original
    '    Dim slocalfile As String = ""

    '    If Einstellungen.mcplugin = 0 Then
    '        If Not Directory.Exists(Pfad & "\Fanart") Then
    '            MkDir(Pfad & "\Fanart")
    '        End If

    '        Dim spt() As String = Split(sURL, "/")
    '        Dim filename As String = ""
    '        If spt.Length > 2 Then
    '            filename = spt(spt.Length - 2) & "-" & spt(spt.Length - 1)
    '        Else
    '            filename = "xxx"
    '        End If
    '        'MsgBox(Daten.arr(0, iarr) & "\Fanart\" & filename)
    '        If File.Exists(Pfad & "\Fanart\" & filename) Then

    '        Else
    '            slocalfile = Path.Combine(Pfad & "\Fanart", filename)
    '        End If



    '    ElseIf Einstellungen.mcplugin = 1 Then
    '        Dim filename As String = "zzzz"
    '        Dim b As Boolean = False
    '        Dim count As Integer = 0
    '        'Dim p() As String = Backdropsarr(Pfad)

    '        'If p.Length > 0 Then
    '        '    Dim onlineimg As Image = ImageFromWeb(p1.Original)
    '        '    For x As Integer = 0 To p.Length - 1
    '        '        If BitmapsEqual(AutoSizeImage2(MyFunctions.ImageFromJpeg(p(x)), onlineimg.Width, onlineimg.Height), onlineimg) Then
    '        '            Return ""
    '        '        End If
    '        '    Next
    '        'End If


    '        If File.Exists(Path.Combine(Pfad, "backdrop.jpg")) = False Then
    '            filename = "Backdrop.jpg"
    '        Else
    '            count = 1
    '            Do Until b = True
    '                Dim firtr As String = "Backdrop" & count & ".jpg"
    '                If Not File.Exists(Path.Combine(Pfad, firtr).ToLower) Then
    '                    filename = "Backdrop" & count & ".jpg"
    '                    b = True
    '                Else
    '                    count += 1

    '                End If

    '            Loop

    '        End If
    '        slocalfile = Path.Combine(Pfad, filename)
    '    End If
    '    Return slocalfile
    'End Function

    'Public Shared Sub Automatisch(ByVal l As List(Of Movie), ByVal b As Boolean)
    '    If l.Count > 0 Then
    '        For x As Integer = 0 To l.Count - 1
    '            Automatisch(l(x), l(x).IMDB_ID)
    '        Next
    '    End If
    'End Sub
    Public Shared Function GetActorImage(ByVal m As String) As WebFile

        Dim i, j As Integer    ' Hilfsvariablen
        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Person.search/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & m, "tmdb.person.search_en_" & Renamer.CheckInvalid_F(m))

        If IsNothing(xml) Then
            Return Nothing
        End If
        'xml.Save("D:\test.xml")
        Dim xpath As String

        xpath = "//images"
        Dim xmln As XmlNode ' Co
        ' Für den Fall das wir mehrere Knoten haben auf die unser 
        ' XPath zutrifft
        j = xml.SelectNodes(xpath).Count
        If j > 0 Then
            xmln = xml.SelectNodes(xpath).Item(0)
            If xmln.ChildNodes.Count > 0 Then

                Dim t As New WebFile
                t.Actorname = m
                t.imgType = ImageType.Actor
                For x As Integer = 0 To xmln.ChildNodes.Count - 1
                    Dim att As XmlAttributeCollection = xmln.ChildNodes(x).Attributes
                    Select Case att("size").Value
                        Case Is = "original"
                            t.Source = New Uri(att("url").Value)
                    End Select
                Next

                If t.Get_Filesize = True Then
                    t.Destination = WebFunctions.Get_dest(t)
                    Return t
                Else
                    'MsgBox("konnte Datei nicht finden")
                    'Try
                    '    Process.Start(t.Original)
                    'Catch ex As Exception

                    'End Try
                End If


            End If

        End If
        Return Nothing
    End Function
    Public Shared Sub MoviePilotCover(ByVal id As String)
        Dim pr As PrevImage = CType(ImageSource_Moviepilot.GetPrevImage(id), PrevImage)
        If Not pr Is Nothing Then
            Cover_results.Add(pr)
        End If

    End Sub
    Public Shared Function DarstellerBilder(ByVal m As Movie, ByVal id As String) As DownloadItem
        Dim s() As String = GetActorArray(m.Darsteller, m.Regisseur, m.Autoren)
        Dim item As New DownloadItem
        item.Type = Downloaditemtype.Actors
        item.DestMovie = m
        If s.Length > 0 Then
            For x As Integer = 0 To s.Length - 1
                Dim pi As WebFile = GetActorImage(s(x))
                If Not pi Is Nothing Then
                    item.List.Add(pi)
                End If
            Next
        End If
        If Not item.List.Count = 0 Then
            item.Status = DLState.Ready
            Return item
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetActorArray(ByVal darstellers As String, ByVal regie As String, ByVal autoren As String) As String()
        Dim acm As New List(Of String)

        Dim a As String = autoren
        Dim r As String = regie
        Dim t As String = darstellers
        Dim d() As String = a.Split(CChar(","))
        If d.Length > 0 Then
            For y As Integer = 0 To d.Length - 1
                If Not acm.Contains(d(y).Trim) Then
                    acm.Add(d(y).Trim)
                End If
            Next
        End If
        d = r.Split(CChar(","))
        If d.Length > 0 Then
            For y As Integer = 0 To d.Length - 1
                If Not acm.Contains(d(y).Trim) Then
                    acm.Add(d(y).Trim)
                End If
            Next
        End If
        Dim Darsteller() As String = t.Split(CChar(","))
        If Darsteller.Length > 0 Then
            For y As Integer = 0 To Darsteller.Length - 1
                Dim DSname_S As String = ""
                Dim DSrole_S As String = ""
                If Darsteller(y).Contains("[") Then
                    Dim DSname() As String = Darsteller(y).Split(CChar("["))
                    DSname_S = Trim(DSname(0))
                    DSrole_S = Trim(DSname(1)).Replace("]", "")
                    DSrole_S = DSrole_S.Replace("...", "")
                    DSrole_S = Trim(DSrole_S)
                Else
                    DSname_S = Trim(Darsteller(y))
                End If
                If Not acm.Contains(DSname_S) Then
                    acm.Add(DSname_S)
                End If
            Next
        End If
        Dim arr As String()
        arr = acm.ToArray
        Array.Sort(arr)
        Return arr
    End Function
    Public Shared Function Automatisch(ByVal m As Movie, ByVal id As String) As DownloadItem
        Cover_results.Clear()
        Backdrop_results.Clear()
        '   MoviePilotCover(id)
        If TMDB_Prev(id) = True Then
            Return FilterLinks_auto(m)
        Else
            Return Nothing
        End If
    End Function

    Public Shared Sub nextmoviefast()
        If List.Count > 0 Then
            Get_ImageLinks(List(0), List(0).IMDB_ID, Fanartsearchmode.Automatic)
        End If
    End Sub
    Public Shared Sub nextmovie()
        If List.Count > 0 Then
            Get_ImageLinks(List(0), List(0).IMDB_ID, Fanartsearchmode.Dialog)
        End If
    End Sub
    Public Shared Sub GiveDownloads(ByVal m As Movie)
        Dim fi As New List(Of WebFile)
        'fi.m = m

        If Dialog_Fanart.Covers.Count > 0 Then
            For x As Integer = 0 To Dialog_Fanart.Covers.Count - 1
                If Dialog_Fanart.Covers(x).Checked = True Then
                    fi.Add(CType(New WebFile(Dialog_Fanart.Covers(x)._Result), WebFile))
                    Exit For
                End If
            Next
        End If
        If Dialog_Fanart.Backdrops.Count > 0 Then
            For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                If Dialog_Fanart.Backdrops(x).Checked = True Then

                    fi.Add(CType(New WebFile(Dialog_Fanart.Backdrops(x)._Result), WebFile))

                End If
            Next
        End If

        If fi.Count > 0 Then
            Dim dl As New DownloadItem
            dl.DestMovie = m
            dl.List = fi
            dl.Status = DLState.Ready
            DownloadManager.Add(dl)
            If DownloadManager.isRunning = False Then
                DownloadManager.Run()
            End If

        Else
        End If

    End Sub


    Public Shared Sub BuildDialog()
        Dialog_Fanart.OK_Button.Enabled = False
        Dialog_Fanart.Refresh()
        Dialog_Fanart.Loadimages.CancelAsync()
        Dialog_Fanart.cancelloadimgs = True
        Do Until Dialog_Fanart.Loadimages.IsBusy = False
            Application.DoEvents()
        Loop
        Dialog_Fanart.cancelloadimgs = False
        If Dialog_Fanart.Covers.Count > 0 Then
            For x As Integer = 0 To Dialog_Fanart.Covers.Count - 1
                Dialog_Fanart.Covers(x).Dispose()
            Next
        End If
        If Dialog_Fanart.Backdrops.Count > 0 Then
            For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                Dialog_Fanart.Backdrops(x).Dispose()
            Next
        End If
        Dialog_Fanart.Covers.Clear()
        Dialog_Fanart.Backdrops.Clear()

        Dialog_Fanart.prevpicboxes.Clear()
        Dialog_Fanart.FlowLayoutPanel3.Controls.Clear()









        Dialog_Fanart.OK_Button.Enabled = False
        If Backdrop_results.Count = 0 And Cover_results.Count = 0 Then
            Dialog_Fanart.Panel1.Visible = True
            Dialog_Fanart.Label1.Text = ""
            Dialog_Fanart.Label2.Text = ""
            Dialog_Fanart.OK_Button.Enabled = False
            Dialog_Fanart.ProgressBar2.Visible = False
            GoTo finish
        Else
            Dialog_Fanart.Panel1.Visible = False
            Dialog_Fanart.OK_Button.Enabled = True
        End If

        If Cover_results.Count > 0 Then
            For x As Integer = 0 To Cover_results.Count - 1
                Dim cov As New PreviewCover
                If Not Cover_results(x).isGerman = True Then

                    cov._Provider = CoverProvider.tmdb
                Else
                    cov._Provider = CoverProvider.mp

                End If


                cov._Language = Cover_results(x).Lang

                cov._CoverQuality = 2
                'Cover_results(x).Image = MyFunctions.ImageFromWeb(Cover_results(x).Small)
                cov._Result = Cover_results(x)

                Cover_results(x).Control = cov
                Dialog_Fanart.Covers.Add(cov)

                Dialog_Fanart.FlowLayoutPanel1.Controls.Add(cov)

            Next
        Else
            Dialog_Fanart.FlowLayoutPanel2.Visible = True
            Dialog_Fanart.FlowLayoutPanel1.Visible = False
            Dialog_Fanart.SwitchButton.Enabled = False
            Dialog_Fanart.SwitchButton.Text = "Covers"
            Dialog_Fanart.switcher_logo.Image = Toolbar16.staty_16_fanart
        End If
        If Backdrop_results.Count > 0 Then
            For x As Integer = 0 To Backdrop_results.Count - 1
                Dim cov As New PreviewCover
                cov._Provider = CoverProvider.tmdb
                cov._CoverQuality = 2
                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                    Dim s As String = IO.Path.Combine(IO.Path.Combine(Dialog_Fanart.movie.Pfad, "Fanart"), ImageDestinations.Cache_Destination_File(Backdrop_results(x).Original))
                    If IO.File.Exists(s) Then
                        cov._Provider = CoverProvider.file
                        'cov.Enabled = False
                    End If
                End If
                'Backdrop_results(x).Image = MyFunctions.ImageFromWeb(Backdrop_results(x).Small)
                cov._Result = Backdrop_results(x)
                Backdrop_results(x).Control = cov

                Dialog_Fanart.Backdrops.Add(cov)

                Dialog_Fanart.FlowLayoutPanel2.Controls.Add(cov)

            Next
        Else
            Dialog_Fanart.FlowLayoutPanel1.Visible = True
            Dialog_Fanart.FlowLayoutPanel2.Visible = False
            Dialog_Fanart.SwitchButton.Enabled = False
            Dialog_Fanart.SwitchButton.Text = "Backdrops"
            Dialog_Fanart.switcher_logo.Image = Toolbar16.staty_16_cover_test
        End If
        DoCheck_Backdrops()
        DoCheck_Covers()
        Dialog_Fanart.ProgressBar2.Visible = True
        Dialog_Fanart.Loadimages.RunWorkerAsync()
        Dialog_Fanart.OK_Button.Enabled = True

finish:

        If List.Count = 0 Then
            Dialog_Fanart.ToolStripButton_Liste.Visible = False
        Else
            Dialog_Fanart.ToolStripButton_Liste.Visible = True
            Dialog_Fanart.ToolStripButton_Liste.Text = CStr(List.Count)
            Dialog_Fanart.ToolStripButton_Liste.DropDownItems.Clear()
            For x As Integer = 0 To List.Count - 1
                Dialog_Fanart.ToolStripButton_Liste.DropDownItems.Add(List(x).Titel)
            Next
        End If

        If Dialog_Fanart.Visible = False Then
            If Einstellungen.UserInterFace.Fanartsize_maximized = True Then
                Dialog_Fanart.WindowState = FormWindowState.Maximized
            Else
                If Not Einstellungen.UserInterFace.Fanartsize_w = -1 Then
                    Dialog_Fanart.Size = New Size(Einstellungen.UserInterFace.Fanartsize_w, Einstellungen.UserInterFace.Fanartsize_h)
                End If
            End If

            Dialog_Fanart.vorschau.Tag = Einstellungen.UserInterFace.Fanartsize_previewsize
            Dialog_Fanart.Show()
        End If

        Dialog_Fanart.Text = "Cover - Backdrop """ & Dialog_Fanart.movie.Titel & """"
        If CStr(Dialog_Fanart.vorschau.Tag) = "0" Then
            Dialog_Fanart.SetIMgwith(100)

            Dialog_Fanart.vorschau.Image = Toolbar16.View_klein
        ElseIf CStr(Dialog_Fanart.vorschau.Tag) = "1" Then
            Dialog_Fanart.SetIMgwith(150)

            Dialog_Fanart.vorschau.Image = Toolbar16.View_mittel
        ElseIf CStr(Dialog_Fanart.vorschau.Tag) = "2" Then
            Dialog_Fanart.SetIMgwith(200)

            Dialog_Fanart.vorschau.Image = Toolbar16.View_groß
        ElseIf CStr(Dialog_Fanart.vorschau.Tag) = "3" Then

            Dialog_Fanart.SetIMgwith(300)
            Dialog_Fanart.vorschau.Image = Toolbar16.View_extragroß
        End If


        'Dim dialog = Dialog_Fanart
        'For Each pre As PrevImage In Cover_results

        '    Dim cov As New CheckBox
        '    pre.CB = cov

        '    cov.BackgroundImageLayout = ImageLayout.Tile
        '    cov.AutoSize = False
        '    cov.CheckAlign = ContentAlignment.TopLeft
        '    cov.Size = New System.Drawing.Size(54, 100)
        '    cov.Appearance = Appearance.Button
        '    cov.TextImageRelation = TextImageRelation.TextAboveImage
        '    cov.Text = " "
        '    If pre.isGerman = True Then
        '        cov.Text = "DE"
        '    End If
        '    'AddHandler cov.Click, AddressOf Dialog_Fanart.cover_click
        '    'AddHandler cov.MouseEnter, AddressOf Dialog_Fanart.cover_mouseenter
        '    'AddHandler cov.MouseLeave, AddressOf Dialog_Fanart.Cover_leave
        '    dialog.FlowLayoutPanel1.Controls.Add(cov)
        'Next
        'For Each pre As PrevImage In Backdrop_results
        '    Dim bak As New CheckBox
        '    pre.CB = bak
        '    If GetDest(pre) = "" Then
        '        bak.BackColor = Color.FromArgb(192, 255, 192)
        '        bak.Enabled = False

        '    End If
        '    bak.BackgroundImageLayout = ImageLayout.Stretch
        '    bak.AutoSize = False
        '    bak.CheckAlign = ContentAlignment.TopLeft
        '    bak.Size = New System.Drawing.Size(80, 65)

        '    bak.Appearance = Appearance.Button
        '    bak.TextImageRelation = TextImageRelation.TextAboveImage
        '    bak.Text = " "
        '    'AddHandler bak.Click, AddressOf Dialog_Fanart.Art_click
        '    'AddHandler bak.MouseEnter, AddressOf Dialog_Fanart.fanart_mouseenter
        '    'AddHandler bak.MouseLeave, AddressOf Dialog_Fanart.Art_leave
        '    dialog.FlowLayoutPanel2.Controls.Add(bak)
        'Next
        'If Cover_results.Count > 0 Then
        '    Dialog_Fanart.selectedcover = 0
        '    Cover_results(0).Image = ImageFromWeb(Cover_results(0).Large)
        '    Cover_results(0).CB.Image = AutoSizeImage(Cover_results(0).Image, 49, 80)
        '    dialog.PictureBox1.Image = Cover_results(0).Image
        'End If
        'If Backdrop_results.Count > 0 Then
        '    Dialog_Fanart.selectedart = 0

        '    Backdrop_results(0).Image = ImageFromWeb(Backdrop_results(0).Large)
        '    Backdrop_results(0).CB.Image = AutoSizeImage(Backdrop_results(0).Image, 75, 45)
        '    dialog.PictureBox2.Image = Backdrop_results(0).Image
        'End If
        'dialog.Loadimages.RunWorkerAsync()
        'Dim r As New DialogResult
        ''oTime.Stop()
        ''Debug.WriteLine("Für die neue Version" & oTime.ElapsedMilliseconds)
        'r = dialog.ShowDialog
        'Return r
    End Sub
    '    Public Sub FilterLinks_auto()

    '        Dim sURL As String = ""
    '        'httpClient = New WebClient
    '        If Einstellungen.betterGerman = True And Cover_results(0).isGerman = True Then
    '            sURL = Cover_results(0).Original
    '        ElseIf Cover_results.Count > 0 Then
    '            If Einstellungen.TMDB_Covermodus = 0 Then
    '                Dim oZahl As New System.Random
    '                Dim i As Integer
    '                i = oZahl.Next(0, Cover_results.Count)
    '                sURL = Cover_results(i).Original
    '            ElseIf Einstellungen.TMDB_Covermodus = 1 Then
    '                If Cover_results(0).isGerman = False Then
    '                    sURL = Cover_results(0).Original
    '                Else
    '                    If Cover_results.Count > 1 Then
    '                        sURL = Cover_results(1).Original
    '                    End If

    '                End If


    '            End If

    '        End If

    '        If sURL <> "" Then
    '            Links.Add(New WebFile(sURL, IO.Path.Combine(Pfad, "folder.jpg")))
    '        End If
    '        ' Ziel-Datei (lokal)




    '        If Backdrop_results.Count > 0 Then

    '            If Einstellungen.TMDB_Backdropmodus = 0 Then
    '                'alle
    '                Array.Resize(arrdl, artcount)

    '                For x As Integer = 0 To artcount - 1
    '                    arrdl(x) = Fanartimgsurl(2, x)
    '                Next
    '            ElseIf Einstellungen.TMDB_Backdropmodus = 1 Then
    '                'die ersten x
    '                If artcount - 1 >= Einstellungen.TMDB_Backdropanzahl - 1 Then
    '                    'wenn mehr cover als erlaubt dann nur die ersten x
    '                    Array.Resize(arrdl, Einstellungen.TMDB_Backdropanzahl)
    '                    For x As Integer = 0 To Einstellungen.TMDB_Backdropanzahl - 1
    '                        arrdl(x) = Fanartimgsurl(2, x)
    '                    Next
    '                Else
    '                    Array.Resize(arrdl, artcount)
    '                    For x As Integer = 0 To artcount - 1
    '                        arrdl(x) = Fanartimgsurl(2, x)
    '                    Next
    '                End If
    '            ElseIf Einstellungen.TMDB_Backdropmodus = 2 Then
    '                'Zufall
    '                If artcount - 1 > Einstellungen.TMDB_Backdropanzahl - 1 Then
    '                    'wenn mehr cover als erlaubt dann nur die ersten x
    '                    For x As Integer = 0 To Einstellungen.TMDB_Backdropanzahl - 1
    'random:                 Dim oZahl As New System.Random
    '                        Dim i As Integer
    '                        i = oZahl.Next(0, artcount)
    '                        'MsgBox(i)
    '                        If arrdl.Length > 0 Then
    '                            For y As Integer = 0 To arrdl.Length - 1
    '                                If Fanartimgsurl(2, i) = arrdl(y) Then
    '                                    GoTo random
    '                                End If
    '                            Next
    '                        End If
    '                        Array.Resize(arrdl, Einstellungen.TMDB_Backdropanzahl)
    '                        arrdl(x) = Fanartimgsurl(2, i)
    '                    Next
    '                ElseIf artcount <= Einstellungen.TMDB_Backdropanzahl Then
    '                    Array.Resize(arrdl, artcount)
    '                    For x As Integer = 0 To artcount - 1
    '                        arrdl(x) = Fanartimgsurl(2, x)
    '                    Next
    '                End If
    '            End If






    '            If arrdl.Length > 0 Then


    '                For x As Integer = 0 To arrdl.Length - 1
    '                    If Main.Cancel = True Then
    '                        GoTo ende
    '                    End If
    '                    TMDB.isBusy = True
    '                    sURL = arrdl(x)
    '                    Dim slocalfile As String = ""

    '                    If Einstellungen.mcplugin = 0 Then
    '                        If Not Directory.Exists(Daten.arr(0, iarr) & "\Fanart") Then
    '                            MkDir(Daten.arr(0, iarr) & "\Fanart")
    '                        End If

    '                        Dim spt() As String = Split(sURL, "/")
    '                        Dim filename As String = ""
    '                        If spt.Length > 2 Then
    '                            filename = spt(spt.Length - 2) & "-" & spt(spt.Length - 1)
    '                        Else
    '                            filename = "xxx"
    '                        End If
    '                        'MsgBox(Daten.arr(0, iarr) & "\Fanart\" & filename)
    '                        If File.Exists(Daten.arr(0, iarr) & "\Fanart\" & filename) Then
    '                            isBusy = False
    '                            GoTo nexxt
    '                        Else
    '                            slocalfile = Path.Combine(Daten.arr(0, iarr) & "\Fanart", filename)
    '                        End If



    '                    ElseIf Einstellungen.mcplugin = 1 Then
    '                        Dim filename As String = "zzzz"
    '                        Dim b As Boolean = False
    '                        Dim count As Integer = 0
    '                        If File.Exists(Path.Combine(Daten.arr(0, iarr), "Backdrop.jpg")) = False Then
    '                            filename = "Backdrop.jpg"
    '                        Else
    '                            count = 1
    '                            Do Until b = True
    '                                Dim firtr As String = "Backdrop" & count & ".jpg"
    '                                If Not File.Exists(Path.Combine(Daten.arr(0, iarr), firtr)) Then
    '                                    filename = "Backdrop" & count & ".jpg"
    '                                    b = True
    '                                Else
    '                                    count += 1

    '                                End If

    '                            Loop

    '                        End If
    '                        slocalfile = Path.Combine(Daten.arr(0, iarr), filename)
    '                    End If



    '                    'slocalfile = Daten.arr(0, iarr) & "\Fanart\" & filename

    '                    Artdowload = New WebClient
    '                    Try
    '                        'Download = True

    '                        Artdowload.DownloadFileAsync(New Uri(sURL), slocalfile)
    '                    Catch ex As Exception
    '                        MsgBox("Fehler!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
    '                        isBusy = False

    '                    End Try



    '                    Do Until Artdowload.IsBusy = False And isBusy = False

    '                        Application.DoEvents()

    '                    Loop



    'NEXXT:


    '                Next
    '            End If
    '        End If
    'ende:
    '        If mcplugin = 0 Then

    '            Daten.arr(31, iarr) = Daten.CountBackdrops(Path.Combine(Daten.arr(0, iarr), "Fanart"))

    '        ElseIf mcplugin = 1 Then
    '            Daten.arr(31, iarr) = Daten.CountBackdrops(Daten.arr(0, iarr), True)
    '        End If
    '        Main.DataGridView1.Rows(index_intable).Cells(Main.Column_Backdrops.Index).Value = Daten.arr(31, iarr)
    '        'If artcount = 0 And covercount = 0 Then

    '        'End If
    '        'Do Until TMDB.isBusy = False
    '        'Application.DoEvents()

    '        'Loop
    '        If suchmodus = 0 Then
    '            Laden.Hide()
    '        End If

    '    End Sub
    Public Shared Sub DoCheck_Covers_reihenfolge()
        Dialog_Fanart.Covers(0).Checked = True
        Dialog_Fanart.Covers(0).BackColor = Color.FromArgb(255, 102, 0)
    End Sub
    Public Shared Sub DoCheck_Covers_random()
        Dim oZahl As New System.Random
        Dim i As Integer
        i = oZahl.Next(0, Dialog_Fanart.Covers.Count)
        Dialog_Fanart.Covers(i).Checked = True
        Dialog_Fanart.Covers(i).BackColor = Color.FromArgb(255, 102, 0)
    End Sub
    Public Shared Sub DoCheck_Covers()
        If Dialog_Fanart.Covers.Count > 0 Then
            If Not Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Keine Then
                If Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge Then

                    DoCheck_Covers_reihenfolge()
                ElseIf Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Zufall Then
                    If Einstellungen.Config_Abrufen.Abrufen_MoviePilotCover = True And Dialog_Fanart.Covers(0)._Provider = CoverProvider.mp Then
                        Dialog_Fanart.Covers(0).Checked = True
                        Dialog_Fanart.Covers(0).BackColor = Color.FromArgb(255, 102, 0)
                    Else
                        DoCheck_Covers_random()
                    End If
                End If
            End If
        End If
    End Sub
    Public Shared Sub DoCheck_Backdrops_random()
        If Dialog_Fanart.Backdrops.Count <= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
            For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                Dialog_Fanart.Backdrops(x).Checked = True
                Dialog_Fanart.Backdrops(x).BackColor = Color.FromArgb(255, 102, 0)
            Next
        Else
            For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1

random:         Dim oZahl As New System.Random
                Dim i As Integer
                i = oZahl.Next(0, Dialog_Fanart.Backdrops.Count)
                If Dialog_Fanart.Backdrops(i).Checked = False Then
                    Dialog_Fanart.Backdrops(i).Checked = True
                    Dialog_Fanart.Backdrops(i).BackColor = Color.FromArgb(255, 102, 0)
                Else
                    GoTo random
                End If
            Next
        End If
    End Sub
    Public Shared Sub DoCheck_Backdrops_Reihenfolge()
        If Dialog_Fanart.Backdrops.Count >= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
            For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1
                Dialog_Fanart.Backdrops(x).Checked = True
                Dialog_Fanart.Backdrops(x).BackColor = Color.FromArgb(255, 102, 0)
            Next
        Else
            For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                Dialog_Fanart.Backdrops(x).Checked = True
                Dialog_Fanart.Backdrops(x).BackColor = Color.FromArgb(255, 102, 0)
            Next
        End If
    End Sub
    Public Shared Sub DoCheck_Backdrops_alle()
        For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
            Dialog_Fanart.Backdrops(x).Checked = True
            Dialog_Fanart.Backdrops(x).BackColor = Color.FromArgb(255, 102, 0)
        Next
    End Sub
    Public Shared Sub DoCheck_Backdrops()


        If Dialog_Fanart.Backdrops.Count > 0 Then
            Select Case Einstellungen.Config_Abrufen.Abrufen_Backdrops_Modus
                Case Is = FanartAutoselectMode.Alle
                    DoCheck_Backdrops_alle()

                Case Is = FanartAutoselectMode.Reihenfolge
                    DoCheck_Backdrops_Reihenfolge()
                Case Is = FanartAutoselectMode.Zufall
                    DoCheck_Backdrops_random()

            End Select

        End If
    End Sub

    Private Shared Function FilterLinks_auto(ByVal m As Movie) As DownloadItem
        Dim fi As New List(Of WebFile)


        'If Cover_results.Count > 0 Then
        '    For x As Integer = 0 To Cover_results.Count - 1
        '        Cover_results(0).Get_Filesize()
        '        If Cover_results(0).FileSize = -1 Then
        '            MsgBox("")

        '        End If
        '    Next
        'End If
        'If Backdrop_results.Count > 0 Then
        '    For x As Integer = 0 To Backdrop_results.Count - 1
        '        Backdrop_results(0).Get_Filesize()
        '        If Backdrop_results(0).FileSize = -1 Then
        '            MsgBox("")

        '        End If
        '    Next
        'End If

        If Cover_results.Count > 0 Then
            If Not Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Keine Then
                Dim g As PrevImage

                For Each s In Cover_results
                    If s.Lang = "de" Then
                        g = s
                        Exit For
                    End If
                Next
                If Einstellungen.Config_Abrufen.Abrufen_MoviePilotCover = True And Not g Is Nothing Then

                    fi.Add(TryCast(New WebFile(g), WebFile))
                    GoTo backd
                End If
                If Einstellungen.Config_Abrufen.Abrufen_NurDeutschimAutomodus = True Then
                    GoTo backd
                End If

                If Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge Then



                    fi.Add(TryCast(New WebFile(Cover_results(0)), WebFile))
                    'Dialog_Fanart.Covers(0).Checked = True
                    'Dialog_Fanart.Covers(0).BackColor = Color.FromArgb(255, 102, 0)
                ElseIf Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Zufall Then


                    Dim oZahl As New System.Random
                    Dim i As Integer
                    i = oZahl.Next(0, Cover_results.Count)
                    fi.Add(TryCast(New WebFile(Cover_results(i)), WebFile))




                End If
            End If
        End If

backd:
        If Backdrop_results.Count > 0 Then
            Select Case Einstellungen.Config_Abrufen.Abrufen_Backdrops_Modus
                Case Is = FanartAutoselectMode.Alle
                    For x As Integer = 0 To Backdrop_results.Count - 1
                        fi.Add(TryCast(New WebFile(Backdrop_results(x)), WebFile))
                    Next
                Case Is = FanartAutoselectMode.Reihenfolge
                    If Backdrop_results.Count <= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
                        For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1
                            fi.Add(TryCast(New WebFile(Backdrop_results(x)), WebFile))
                        Next
                    Else
                        For x As Integer = 0 To Backdrop_results.Count - 1
                            fi.Add(TryCast(New WebFile(Backdrop_results(x)), WebFile))
                        Next
                    End If
                Case Is = FanartAutoselectMode.Zufall
                    If Backdrop_results.Count <= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
                        For x As Integer = 0 To Backdrop_results.Count - 1
                            fi.Add(TryCast(New WebFile(Backdrop_results(x)), WebFile))
                        Next
                    Else
                        Dim alreadychecked As New List(Of Integer)
                        For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1


random:                     Dim oZahl As New System.Random
                            Dim i As Integer
                            i = oZahl.Next(0, Backdrop_results.Count)


                            If Not alreadychecked.Contains(i) Then

                                alreadychecked.Add(i)
                                fi.Add(TryCast(New WebFile(Backdrop_results(i)), WebFile))
                            Else
                                GoTo random
                            End If
                        Next
                    End If

            End Select

        End If
        If fi.Count > 0 Then


            Dim dl As New DownloadItem
            dl.DestMovie = m
            dl.List = fi
            dl.Status = DLState.Ready
            Return dl
        Else
            Return Nothing
        End If
    End Function
    '    Private Shared Function FilterLinks_auto(ByVal m As Movie) As CoverDownload
    '        Dim fi As New CoverDownload
    '        fi.m = m

    '        'If Dialog_Fanart.Covers.Count > 0 Then
    '        '    For x As Integer = 0 To Dialog_Fanart.Covers.Count - 1
    '        '        If Dialog_Fanart.Covers(x).Checked = True Then
    '        '            fi.AddCover(Dialog_Fanart.Covers(x)._Result)
    '        '            Exit For
    '        '        End If
    '        '    Next
    '        'End If
    '        'If  Dialog_Fanart.Backdrops.Count > 0 Then
    '        '    For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
    '        '        If Dialog_Fanart.Backdrops(x).Checked = True Then
    '        '            fi.AddBackdrops(Dialog_Fanart.Backdrops(x)._Result)
    '        '        End If
    '        '    Next
    '        'End If

    '        If Cover_results.Count > 0 Then
    '            If Not Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Keine Then
    '                If Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge Then
    '                    fi.AddCover(Cover_results(0))
    '                    'Dialog_Fanart.Covers(0).Checked = True
    '                    'Dialog_Fanart.Covers(0).BackColor = Color.FromArgb(255, 102, 0)
    '                ElseIf Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Zufall Then
    '                    Dim oZahl As New System.Random
    '                    Dim i As Integer
    '                    i = oZahl.Next(0, Cover_results.Count)
    '                    fi.AddCover(Cover_results(i))
    '                End If
    '            End If
    '        End If


    '        If Backdrop_results.Count > 0 Then
    '            Select Case Einstellungen.Config_Abrufen.Abrufen_Backdrops_Modus
    '                Case Is = FanartAutoselectMode.Alle
    '                    For x As Integer = 0 To Backdrop_results.Count - 1
    '                        fi.AddBackdrops(Backdrop_results(x))
    '                    Next
    '                Case Is = FanartAutoselectMode.Reihenfolge
    '                    If Backdrop_results.Count <= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
    '                        For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1
    '                            fi.AddBackdrops(Backdrop_results(x))
    '                        Next
    '                    Else
    '                        For x As Integer = 0 To Backdrop_results.Count - 1
    '                            fi.AddBackdrops(Backdrop_results(x))
    '                        Next
    '                    End If
    '                Case Is = FanartAutoselectMode.Zufall
    '                    If Backdrop_results.Count <= Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count Then
    '                        For x As Integer = 0 To Backdrop_results.Count - 1
    '                            fi.AddBackdrops(Backdrop_results(x))
    '                        Next
    '                    Else
    '                        Dim alreadychecked As New List(Of Integer)
    '                        For x As Integer = 0 To Einstellungen.Config_Abrufen.Abrufen_Backdrops_Count - 1


    'random:                     Dim oZahl As New System.Random
    '                            Dim i As Integer
    '                            i = oZahl.Next(0, Backdrop_results.Count)


    '                            If Not alreadychecked.Contains(i) Then

    '                                alreadychecked.Add(i)
    '                                fi.AddBackdrops(Backdrop_results(i))
    '                            Else
    '                                GoTo random
    '                            End If
    '                        Next
    '                    End If

    '            End Select

    '        End If


    '        Return fi
    '    End Function
End Class


Public Class CoverDownload
    Public files As New List(Of WebFile)
    Public m As Movie

    Property node As TreeNode

    Public Sub AddCover(ByVal s As PrevImage)
        Dim wf As New WebFile
        wf.imgType = ImageType.Cover
        wf.Source = New Uri(s.Original)
        If Not IsNothing(s.Original) Or s.Original = "" Then
            files.Add(wf)
        End If
    End Sub
    Public Sub AddBackdrops(ByVal s As PrevImage)
        Dim wf As New WebFile
        wf.imgType = ImageType.Fanart
        wf.Source = New Uri(s.Original)
        If Not IsNothing(s.Original) Or s.Original = "" Then
            files.Add(wf)
        End If
    End Sub

End Class

'Public Class TMDB
'    Public Links As New List(Of WebFile)
'    Public Pfad As String
'    Public _SMode As Fanartsearchmode
'    Public _SID As String
'    Public Able As Boolean = False
'    'Dim oTime As New System.Diagnostics.Stopwatch

'    Sub New(ByVal ID As String, ByVal dest As String, ByVal mode As Fanartsearchmode)
'        _SID = ID
'        _SMode = mode
'        Pfad = dest
'        GetImageLinks(ID)
'    End Sub
'    Public Cover_results As New List(Of PrevImage)
'    Public Backdrop_results As New List(Of PrevImage)

'    Public Sub Dispose()
'        For Each pre As PrevImage In Cover_results
'            pre.Dispose()
'        Next
'        For Each pre As PrevImage In Backdrop_results
'            pre.Dispose()
'        Next
'    End Sub



'    Public Sub GetImageLinks(ByVal IMDB As String)

'        Cover_results.Clear()
'        Backdrop_results.Clear()

'        ' Zeitmessung beginnen
'        'oTime.Start()

'        'Dim p As PrevImage =
'        'If MP.GermanPrevImage(IMDB) = True Then
'        '    Cover_results.Add(MP.PM)
'        'End If

'        TMDB_Prev()

'        If _SMode = Fanartsearchmode.Automatic Then
'            FilterLinks_auto()
'        Else
'            'FilterLinks_Dialog()
'        End If




'ende:


'    End Sub

'    Private Sub TMDB_Prev()
'        Dim i, j As Integer    ' Hilfsvariablen
'        Dim xml As Xml.XmlDocument
'        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.getImages/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & _SID, "tmdb_persona_en_" & _SID & ".xml")


'        Dim xpath As String

'        xpath = "//poster"
'        Dim xmln As XmlNode ' Container für unseren aktiven Knoten
'        Dim xmln2 As XmlNode
'        ' Für den Fall das wir mehrere Knoten haben auf die unser 
'        ' XPath zutrifft
'        j = xml.SelectNodes(xpath).Count
'        If j > 0 Then
'            For i = 0 To j - 1 Step 1
'                xmln = xml.SelectNodes(xpath).Item(i)
'                If xmln.ChildNodes.Count > 0 Then

'                    Dim t As New PrevImage
'                    t.Type = ImageType.Cover

'                    For x As Integer = 0 To xmln.ChildNodes.Count - 1
'                        Dim att As XmlAttributeCollection = xmln.ChildNodes(x).Attributes
'                        Select Case att("size").Value
'                            Case Is = "cover"
'                                t.Large = att("url").Value
'                            Case Is = "thumb"
'                                t.Small = att("url").Value
'                            Case Is = "original"
'                                t.Original = att("url").Value
'                        End Select
'                    Next
'                    Cover_results.Add(t)

'                End If
'            Next i

'        End If

'        xpath = "//backdrop"
'        j = xml.SelectNodes(xpath).Count
'        If j > 0 Then
'            For i = 0 To j - 1 Step 1
'                xmln2 = xml.SelectNodes(xpath).Item(i)
'                If xmln2.ChildNodes.Count > 0 Then
'                    Dim t As New PrevImage
'                    t.Type = ImageType.Fanart
'                    For x As Integer = 0 To xmln2.ChildNodes.Count - 1
'                        Dim att As XmlAttributeCollection = xmln2.ChildNodes(x).Attributes
'                        Select Case att("size").Value
'                            Case Is = "poster"
'                                t.Large = att("url").Value
'                            Case Is = "thumb"
'                                t.Small = att("url").Value
'                            Case Is = "original"
'                                t.Original = att("url").Value
'                        End Select
'                    Next
'                    Backdrop_results.Add(t)

'                End If
'            Next i

'        End If
'ende:
'    End Sub
'    Public Sub FilterLinks_auto()

'        Dim sURL As String = ""
'        'httpClient = New WebClient
'        If Einstellungen.betterGerman = True And Cover_results(0).isGerman = True Then
'            sURL = Cover_results(0).Original
'        ElseIf Cover_results.Count > 0 Then
'            If Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Zufall Then
'                Dim oZahl As New System.Random
'                Dim i As Integer
'                i = oZahl.Next(0, Cover_results.Count)
'                sURL = Cover_results(i).Original
'            ElseIf Einstellungen.Config_Abrufen.Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge Then
'                If Cover_results(0).isGerman = False Then
'                    sURL = Cover_results(0).Original
'                Else
'                    If Cover_results.Count > 1 Then
'                        sURL = Cover_results(1).Original
'                    End If

'                End If


'            End If

'        End If

'        If sURL <> "" Then
'            Links.Add(New WebFile(sURL, IO.Path.Combine(Pfad, "folder.jpg")))
'        End If
'        ' Ziel-Datei (lokal)




'        '        If Backdrop_results.Count > 0 Then

'        '            If Einstellungen.TMDB_Backdropmodus = 0 Then
'        '                'alle
'        '                Array.Resize(arrdl, artcount)

'        '                For x As Integer = 0 To artcount - 1
'        '                    arrdl(x) = Fanartimgsurl(2, x)
'        '                Next
'        '            ElseIf Einstellungen.TMDB_Backdropmodus = 1 Then
'        '                'die ersten x
'        '                If artcount - 1 >= Einstellungen.TMDB_Backdropanzahl - 1 Then
'        '                    'wenn mehr cover als erlaubt dann nur die ersten x
'        '                    Array.Resize(arrdl, Einstellungen.TMDB_Backdropanzahl)
'        '                    For x As Integer = 0 To Einstellungen.TMDB_Backdropanzahl - 1
'        '                        arrdl(x) = Fanartimgsurl(2, x)
'        '                    Next
'        '                Else
'        '                    Array.Resize(arrdl, artcount)
'        '                    For x As Integer = 0 To artcount - 1
'        '                        arrdl(x) = Fanartimgsurl(2, x)
'        '                    Next
'        '                End If
'        '            ElseIf Einstellungen.TMDB_Backdropmodus = 2 Then
'        '                'Zufall
'        '                If artcount - 1 > Einstellungen.TMDB_Backdropanzahl - 1 Then
'        '                    'wenn mehr cover als erlaubt dann nur die ersten x
'        '                    For x As Integer = 0 To Einstellungen.TMDB_Backdropanzahl - 1
'        'random:                 Dim oZahl As New System.Random
'        '                        Dim i As Integer
'        '                        i = oZahl.Next(0, artcount)
'        '                        'MsgBox(i)
'        '                        If arrdl.Length > 0 Then
'        '                            For y As Integer = 0 To arrdl.Length - 1
'        '                                If Fanartimgsurl(2, i) = arrdl(y) Then
'        '                                    GoTo random
'        '                                End If
'        '                            Next
'        '                        End If
'        '                        Array.Resize(arrdl, Einstellungen.TMDB_Backdropanzahl)
'        '                        arrdl(x) = Fanartimgsurl(2, i)
'        '                    Next
'        '                ElseIf artcount <= Einstellungen.TMDB_Backdropanzahl Then
'        '                    Array.Resize(arrdl, artcount)
'        '                    For x As Integer = 0 To artcount - 1
'        '                        arrdl(x) = Fanartimgsurl(2, x)
'        '                    Next
'        '                End If
'        '            End If






'        '            If arrdl.Length > 0 Then


'        '                For x As Integer = 0 To arrdl.Length - 1
'        '                    If Main.Cancel = True Then
'        '                        GoTo ende
'        '                    End If
'        '                    TMDB.isBusy = True
'        '                    sURL = arrdl(x)
'        '                    Dim slocalfile As String = ""

'        '                    If Einstellungen.mcplugin = 0 Then
'        '                        If Not Directory.Exists(Daten.arr(0, iarr) & "\Fanart") Then
'        '                            MkDir(Daten.arr(0, iarr) & "\Fanart")
'        '                        End If

'        '                        Dim spt() As String = Split(sURL, "/")
'        '                        Dim filename As String = ""
'        '                        If spt.Length > 2 Then
'        '                            filename = spt(spt.Length - 2) & "-" & spt(spt.Length - 1)
'        '                        Else
'        '                            filename = "xxx"
'        '                        End If
'        '                        'MsgBox(Daten.arr(0, iarr) & "\Fanart\" & filename)
'        '                        If File.Exists(Daten.arr(0, iarr) & "\Fanart\" & filename) Then
'        '                            isBusy = False
'        '                            GoTo nexxt
'        '                        Else
'        '                            slocalfile = Path.Combine(Daten.arr(0, iarr) & "\Fanart", filename)
'        '                        End If



'        '                    ElseIf Einstellungen.mcplugin = 1 Then
'        '                        Dim filename As String = "zzzz"
'        '                        Dim b As Boolean = False
'        '                        Dim count As Integer = 0
'        '                        If File.Exists(Path.Combine(Daten.arr(0, iarr), "Backdrop.jpg")) = False Then
'        '                            filename = "Backdrop.jpg"
'        '                        Else
'        '                            count = 1
'        '                            Do Until b = True
'        '                                Dim firtr As String = "Backdrop" & count & ".jpg"
'        '                                If Not File.Exists(Path.Combine(Daten.arr(0, iarr), firtr)) Then
'        '                                    filename = "Backdrop" & count & ".jpg"
'        '                                    b = True
'        '                                Else
'        '                                    count += 1

'        '                                End If

'        '                            Loop

'        '                        End If
'        '                        slocalfile = Path.Combine(Daten.arr(0, iarr), filename)
'        '                    End If



'        '                    'slocalfile = Daten.arr(0, iarr) & "\Fanart\" & filename

'        '                    Artdowload = New WebClient
'        '                    Try
'        '                        'Download = True

'        '                        Artdowload.DownloadFileAsync(New Uri(sURL), slocalfile)
'        '                    Catch ex As Exception
'        '                        MsgBox("Fehler!" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)
'        '                        isBusy = False

'        '                    End Try



'        '                    Do Until Artdowload.IsBusy = False And isBusy = False

'        '                        Application.DoEvents()

'        '                    Loop



'        'NEXXT:


'        '                Next
'        '            End If
'        '        End If
'        'ende:
'        '        If mcplugin = 0 Then

'        '            Daten.arr(31, iarr) = Daten.CountBackdrops(Path.Combine(Daten.arr(0, iarr), "Fanart"))

'        '        ElseIf mcplugin = 1 Then
'        '            Daten.arr(31, iarr) = Daten.CountBackdrops(Daten.arr(0, iarr), True)
'        '        End If
'        '        Main.DataGridView1.Rows(index_intable).Cells(Main.Column_Backdrops.Index).Value = Daten.arr(31, iarr)
'        '        'If artcount = 0 And covercount = 0 Then

'        '        'End If
'        '        'Do Until TMDB.isBusy = False
'        '        'Application.DoEvents()

'        '        'Loop
'        '        If suchmodus = 0 Then
'        '            Laden.Hide()
'        '        End If

'    End Sub
'    'Private Sub FilterLinks_Dialog()
'    '    If BuildDialog() = DialogResult.OK Then
'    '        Able = True


'    '        Dim sURL As String = ""




'    '        If mcplugin = 1 And _SMode = Fanartsearchmode.Dialog Then
'    '            If Dialog_Fanart.Ersetzen.Checked = True Then
'    '                Dim barr() As String = Backdropsarr(Pfad, True)
'    '                If barr.Length > 0 Then
'    '                    If MsgBox("Möchten Sie wirklich die vorhandenen " & barr.Length & " Backdrops löschen?", MsgBoxStyle.YesNo, "Löschen?") Then
'    '                        For x As Integer = 0 To barr.Length - 1
'    '                            Try
'    '                                File.Delete(barr(x))
'    '                            Catch ex As Exception
'    '                                MsgBox("Die Datei: " & Path.GetFileName(barr(x)) & " konnte nicht gelöscht werden", MsgBoxStyle.Exclamation)
'    '                            End Try
'    '                        Next
'    '                    End If
'    '                End If
'    '            End If
'    '        End If

'    '        If Cover_results.Count > 0 Then
'    '            For x As Integer = 0 To Cover_results.Count - 1
'    '                If Cover_results(x).CB.Checked = True Then
'    '                    sURL = Cover_results(x).Original
'    '                    Exit For
'    '                End If
'    '            Next
'    '        End If
'    '        If sURL <> "" Then
'    '            Links.Add(New WebFile(sURL, IO.Path.Combine(Pfad, "folder.jpg")))
'    '        End If
'    '        If Backdrop_results.Count > 0 Then
'    '            For x As Integer = 0 To Backdrop_results.Count - 1
'    '                If Backdrop_results(x).CB.Checked = True Then
'    '                    Dim local As String = GetDest(Backdrop_results(x))
'    '                    If Not local = "" Then
'    '                        Dim wb As WebFile = New WebFile(Backdrop_results(x).Original, local)
'    '                        Links.Add(wb)

'    '                    End If
'    '                End If
'    '            Next
'    '        End If

'    '    End If


'    'End Sub

'    'Private Function GetDest(ByVal p1 As PrevImage) As String
'    '    Dim sURL As String = p1.Original
'    '    Dim slocalfile As String = ""

'    '    If Einstellungen.mcplugin = 0 Then
'    '        If Not Directory.Exists(Pfad & "\Fanart") Then
'    '            MkDir(Pfad & "\Fanart")
'    '        End If

'    '        Dim spt() As String = Split(sURL, "/")
'    '        Dim filename As String = ""
'    '        If spt.Length > 2 Then
'    '            filename = spt(spt.Length - 2) & "-" & spt(spt.Length - 1)
'    '        Else
'    '            filename = "xxx"
'    '        End If
'    '        'MsgBox(Daten.arr(0, iarr) & "\Fanart\" & filename)
'    '        If File.Exists(Pfad & "\Fanart\" & filename) Then

'    '        Else
'    '            slocalfile = Path.Combine(Pfad & "\Fanart", filename)
'    '        End If



'    '    ElseIf Einstellungen.mcplugin = 1 Then
'    '        Dim filename As String = "zzzz"
'    '        Dim b As Boolean = False
'    '        Dim count As Integer = 0
'    '        'Dim p() As String = Backdropsarr(Pfad)

'    '        'If p.Length > 0 Then
'    '        '    Dim onlineimg As Image = ImageFromWeb(p1.Original)
'    '        '    For x As Integer = 0 To p.Length - 1
'    '        '        If BitmapsEqual(AutoSizeImage2(MyFunctions.ImageFromJpeg(p(x)), onlineimg.Width, onlineimg.Height), onlineimg) Then
'    '        '            Return ""
'    '        '        End If
'    '        '    Next
'    '        'End If


'    '        If File.Exists(Path.Combine(Pfad, "backdrop.jpg")) = False Then
'    '            filename = "Backdrop.jpg"
'    '        Else
'    '            count = 1
'    '            Do Until b = True
'    '                Dim firtr As String = "Backdrop" & count & ".jpg"
'    '                If Not File.Exists(Path.Combine(Pfad, firtr).ToLower) Then
'    '                    filename = "Backdrop" & count & ".jpg"
'    '                    b = True
'    '                Else
'    '                    count += 1

'    '                End If

'    '            Loop

'    '        End If
'    '        slocalfile = Path.Combine(Pfad, filename)
'    '    End If
'    '    Return slocalfile
'    'End Function

'    'Private Function BuildDialog() As DialogResult
'    '    Dim dialog = Dialog_Fanart
'    '    For Each pre As PrevImage In Cover_results

'    '        Dim cov As New CheckBox
'    '        pre.CB = cov

'    '        cov.BackgroundImageLayout = ImageLayout.Tile
'    '        cov.AutoSize = False
'    '        cov.CheckAlign = ContentAlignment.TopLeft
'    '        cov.Size = New System.Drawing.Size(54, 100)
'    '        cov.Appearance = Appearance.Button
'    '        cov.TextImageRelation = TextImageRelation.TextAboveImage
'    '        cov.Text = " "
'    '        If pre.isGerman = True Then
'    '            cov.Text = "DE"
'    '        End If
'    '        'AddHandler cov.Click, AddressOf Dialog_Fanart.cover_click
'    '        'AddHandler cov.MouseEnter, AddressOf Dialog_Fanart.cover_mouseenter
'    '        'AddHandler cov.MouseLeave, AddressOf Dialog_Fanart.Cover_leave
'    '        dialog.FlowLayoutPanel1.Controls.Add(cov)
'    '    Next
'    '    For Each pre As PrevImage In Backdrop_results
'    '        Dim bak As New CheckBox
'    '        pre.CB = bak
'    '        If GetDest(pre) = "" Then
'    '            bak.BackColor = Color.FromArgb(192, 255, 192)
'    '            bak.Enabled = False

'    '        End If
'    '        bak.BackgroundImageLayout = ImageLayout.Stretch
'    '        bak.AutoSize = False
'    '        bak.CheckAlign = ContentAlignment.TopLeft
'    '        bak.Size = New System.Drawing.Size(80, 65)

'    '        bak.Appearance = Appearance.Button
'    '        bak.TextImageRelation = TextImageRelation.TextAboveImage
'    '        bak.Text = " "
'    '        'AddHandler bak.Click, AddressOf Dialog_Fanart.Art_click
'    '        'AddHandler bak.MouseEnter, AddressOf Dialog_Fanart.fanart_mouseenter
'    '        'AddHandler bak.MouseLeave, AddressOf Dialog_Fanart.Art_leave
'    '        dialog.FlowLayoutPanel2.Controls.Add(bak)
'    '    Next
'    '    If Cover_results.Count > 0 Then
'    '        Dialog_Fanart.selectedcover = 0
'    '        Cover_results(0).Image = ImageFromWeb(Cover_results(0).Large)
'    '        Cover_results(0).CB.Image = AutoSizeImage(Cover_results(0).Image, 49, 80)
'    '        dialog.PictureBox1.Image = Cover_results(0).Image
'    '    End If
'    '    If Backdrop_results.Count > 0 Then
'    '        Dialog_Fanart.selectedart = 0

'    '        Backdrop_results(0).Image = ImageFromWeb(Backdrop_results(0).Large)
'    '        Backdrop_results(0).CB.Image = AutoSizeImage(Backdrop_results(0).Image, 75, 45)
'    '        dialog.PictureBox2.Image = Backdrop_results(0).Image
'    '    End If
'    '    dialog.Loadimages.RunWorkerAsync()
'    '    Dim r As New DialogResult
'    '    'oTime.Stop()
'    '    'Debug.WriteLine("Für die neue Version" & oTime.ElapsedMilliseconds)
'    '    r = dialog.ShowDialog
'    '    Return r
'    'End Function


'End Class

