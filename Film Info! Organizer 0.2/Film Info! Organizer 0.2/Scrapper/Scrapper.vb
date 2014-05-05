Imports System.Xml
Imports System.Security.Cryptography


Public Enum Scrapper_Valuetype
    Titel
    Originaltitel
    IMDB_ID
    Darsteller
    Regisseur
    Autoren
    Studios
    Produktionsjahr
    Produktionsland
    Genre
    FSK
    Bewertung
    Spieldauer
    Inhalt
End Enum


Public Class Search_Result
#Region "Werte"
    Dim sTitel As String = ""
    Dim sOriginaltitel As String = ""
    Dim sIMDB_ID As String = ""
    Dim sDarsteller As String = ""
    Dim sRegisseur As String = ""
    Dim sAutoren As String = ""
    Dim sStudios As String = ""
    Dim sProduktionsjahr As String = ""
    Dim sProduktionsland As String = ""
    Dim sGenre As String = ""
    Dim sFSK As String = ""
    Dim sBewertung As String = ""
    Dim sSpieldauer As String = ""
    Dim sKurzbeschreibung As String = ""
    Dim sInhalt As String = ""
    Dim sSort As String = ""
    Public Property trailer As String = ""
    Public Property Titel() As String
        Get
            Return sTitel
        End Get
        Set(ByVal value As String)
            sTitel = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Titel)
            End If
        End Set
    End Property
    Public Property Originaltitel() As String
        Get
            Return sOriginaltitel
        End Get
        Set(ByVal value As String)
            sOriginaltitel = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Originaltitel)
            End If
        End Set
    End Property
    Public Property IMDB_ID() As String
        Get
            Return sIMDB_ID
        End Get
        Set(ByVal value As String)
            sIMDB_ID = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.IMDB_ID)
            End If
        End Set
    End Property
    Public Property Darsteller() As String
        Get
            Return sDarsteller
        End Get
        Set(ByVal value As String)
            sDarsteller = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Darsteller)
            End If
        End Set
    End Property
    Public Property Regisseur() As String
        Get
            Return sRegisseur
        End Get
        Set(ByVal value As String)
            sRegisseur = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Regisseur)
            End If
        End Set
    End Property
    Public Property Autoren() As String
        Get
            Return sAutoren
        End Get
        Set(ByVal value As String)
            sAutoren = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Autoren)
            End If
        End Set
    End Property
    Public Property Studios() As String
        Get
            Return sStudios
        End Get
        Set(ByVal value As String)
            sStudios = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Studios)
            End If
        End Set
    End Property
    Public Property Produktionsjahr() As String
        Get
            Return sProduktionsjahr
        End Get
        Set(ByVal value As String)
            sProduktionsjahr = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Produktionsjahr)
            End If
        End Set
    End Property
    Public Property Produktionsland() As String
        Get
            Return sProduktionsland
        End Get
        Set(ByVal value As String)
            sProduktionsland = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Produktionsland)
            End If
        End Set
    End Property
    Public Property Genre() As String
        Get
            Return sGenre
        End Get
        Set(ByVal value As String)
            sGenre = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Genre)
            End If
        End Set
    End Property
    Public Property FSK() As String
        Get
            Return sFSK
        End Get
        Set(ByVal value As String)
            sFSK = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.FSK)
            End If
        End Set
    End Property
    Public Property Bewertung() As String
        Get
            Return sBewertung
        End Get
        Set(ByVal value As String)
            If Not value = "" And Not value = "0.0" Then
                sBewertung = value
                MissingValues.Remove(Scrapper_Valuetype.Bewertung)
            End If
        End Set
    End Property
    Public Property Spieldauer() As String
        Get
            Return sSpieldauer
        End Get
        Set(ByVal value As String)
            sSpieldauer = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Spieldauer)
            End If
        End Set
    End Property
    Public Property Kurzbeschreibung() As String
        Get
            Return sKurzbeschreibung
        End Get
        Set(ByVal value As String)
            sKurzbeschreibung = value
        End Set
    End Property
    Public Property Inhalt() As String
        Get
            Return sInhalt
        End Get
        Set(ByVal value As String)
            sInhalt = value
            If Not value = "" Then
                MissingValues.Remove(Scrapper_Valuetype.Inhalt)
            End If
        End Set
    End Property
    Public Property Sort() As String
        Get
            Return sSort
        End Get
        Set(ByVal value As String)
            sSort = value
        End Set
    End Property
#End Region




    Property MissingValues As New List(Of Scrapper_Valuetype)

    Property tmdb_id As String = ""
    Property ofdb_id As String = ""
    Property modified As Boolean = False
    Property g_index As Integer = 0
    Property type As MetaProvider
    Public meta_loaded As Boolean = False
    Public id As String = ""
    Property tmdb_loaded As Boolean = False
    Property ofdb_loaded As Boolean = False
    Property imdb_loaded As Boolean = False
    Public litem As ListViewItem
    Public pic As Image
    Public imagelink As String = ""

    Property zell_id As String
    Property xRel_link As String
    Sub Ini()
        MissingValues.Add(Scrapper_Valuetype.Titel)
        MissingValues.Add(Scrapper_Valuetype.Originaltitel)
        MissingValues.Add(Scrapper_Valuetype.IMDB_ID)
        MissingValues.Add(Scrapper_Valuetype.Darsteller)
        MissingValues.Add(Scrapper_Valuetype.Regisseur)
        MissingValues.Add(Scrapper_Valuetype.Autoren)
        MissingValues.Add(Scrapper_Valuetype.Studios)
        MissingValues.Add(Scrapper_Valuetype.Produktionsjahr)
        MissingValues.Add(Scrapper_Valuetype.Produktionsland)
        MissingValues.Add(Scrapper_Valuetype.Genre)
        MissingValues.Add(Scrapper_Valuetype.FSK)
        MissingValues.Add(Scrapper_Valuetype.Bewertung)
        MissingValues.Add(Scrapper_Valuetype.Spieldauer)
        MissingValues.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Sub New()
        Ini()
    End Sub
    Sub New(ByVal ntitel As String, ByVal nOrigrinaltitel As String, ByVal nid As String, ByVal nJahr As String, ByVal t As MetaProvider)
        Ini()

        Titel = ntitel
        Originaltitel = nOrigrinaltitel
        id = nid
        Produktionsjahr = nJahr
        type = t
    End Sub
    Sub New(ByVal nid As String)
        Ini()
        id = nid

    End Sub
    Sub New(ByVal s As Search_Result)
        Ini()
        Titel = s.Titel
        Originaltitel = s.Originaltitel
        IMDB_ID = s.IMDB_ID
        Darsteller = s.Darsteller
        Regisseur = s.Regisseur
        Autoren = s.Autoren
        Studios = s.Studios
        Produktionsjahr = s.Produktionsjahr
        Produktionsland = s.Produktionsland
        Genre = s.Genre
        FSK = s.FSK
        Bewertung = s.Bewertung
        Inhalt = s.Inhalt
        Sort = s.Sort
        imdb_loaded = s.imdb_loaded
        modified = s.modified
        id = s.id
        'pic = s.pic
        imagelink = s.imagelink
    End Sub




    Sub AddtoList()
        Dim nItem As New ListViewItem
        nItem.Text = Titel
        nItem.Tag = Me
        nItem.SubItems.Add(Produktionsjahr)

        If type = MetaProvider.Exact Then
            g_index = 0
        ElseIf type = MetaProvider.OFDB Then
            g_index = 2
        ElseIf type = MetaProvider.tmdb Then
            g_index = 1
        ElseIf type = MetaProvider.IMDb Then
            g_index = 3
        End If


        nItem.Group = Dialog_OnlineSuche.ListViewVista1.Groups(g_index)
        litem = nItem
        Dialog_OnlineSuche.ListViewVista1.Items.Add(litem)
    End Sub


    Protected Overrides Sub Finalize()
        If Not pic Is Nothing Then
            pic.Dispose()
        End If


        MyBase.Finalize()
    End Sub
End Class


Public Class MetaScrapper


    Public Shared Property Searching_Background As Boolean = False
    ''' <summary>
    ''' Der Film für den aktuell eine Suche ausgeführt wird.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared movie As Movie
    ''' <summary>
    ''' Liste mit Filmen, die gesucht werden sollen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared List As New List(Of Movie)
    Public Shared _TMDB As New TMDB_Scrapper
    Public Shared _OFDB As New OFDb_Scrapper
    Public Shared _IMDB As New IMDB_Scrapper
    Public Shared _MoPi As New MoviePilot_Scrapper
    Public Shared _Zell As New Zell_Scrapper
    Public Shared _xRel As New xRel_Scrapper
    Public Shared _sIMDB As New IMDb_Scrapper_Search
    Public Shared ScrapperList As IEnumerable(Of Scrapper) = {_TMDB, _OFDB, _sIMDB}
    Public Shared AddScrapperList As IEnumerable(Of Scrapper) = {_IMDB, _xRel}
    Public Shared Results As List(Of Search_Result)



    Public Shared Sub NextMovie()
        If List.Count > 0 Then
            Dim s As Search_Result = Nothing
            s = Suche(List(0), List(0).Titel, List(0).IMDB_ID, List(0).Produktionsjahr)
            If s Is Nothing Then
                BuildDialog(List(0).Titel)
            Else
                BackgroundComplete(List(0), s)
            End If
        Else
            Dialog_OnlineSuche.Close()
        End If
    End Sub
    Public Shared Sub Suche(ByVal l As List(Of Movie))
        List = l
        If List.Count > 0 Then
            Dim s As Search_Result = Nothing
            s = Suche(List(0), List(0).Titel, List(0).IMDB_ID, List(0).Produktionsjahr)
            If s Is Nothing Then
                BuildDialog(List(0).Titel)
            Else
                BackgroundComplete(List(0), s)
            End If
        End If
    End Sub


    ''' <summary>
    ''' Erstellt eine neue Suche automatisch mit imdb und searchmode) 
    ''' </summary>
    ''' <param name="m"></param>
    ''' <param name="Suchtext"></param>
    ''' <param name="imdbid"></param>
    ''' <remarks></remarks>
    Public Shared Function Suche(ByVal m As Movie, ByVal Suchtext As String, Optional ByVal imdbid As String = "", Optional ByVal Years As String = "") As Search_Result
        Results = New List(Of Search_Result)
        movie = m
        Dim s As Search_Result = Nothing
        Dim i As Search_Result = Nothing
        For Each sr In ScrapperList
            If i Is Nothing Then
                If Not imdbid = "" Then
                    i = sr.fromIMDB(imdbid)
                End If
            End If
        Next
        If Not i Is Nothing Then
            Results.Add(i)
        End If

        '' Normale-Suche-> automatische Auswahl
        If Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal And Not i Is Nothing And Einstellungen.UserAbrufen.useImdb = True Then
            Return i
            'm.flag = 1
            'BackgroundComplete(m, i)
            ''NextMovie()
            'Exit Function
        End If


        Dim ofdb_res As New List(Of Search_Result)
        Dim tmdb_res As New List(Of Search_Result)
        Dim imdb_res As New List(Of Search_Result)
        ofdb_res = _OFDB.Search(Suchtext)
        tmdb_res = _TMDB.Search(Suchtext)
        imdb_res = _sIMDB.Search(Suchtext)


        If Not tmdb_res Is Nothing Then
            Results.AddRange(tmdb_res)
        End If

        If Not ofdb_res Is Nothing Then

            Results.AddRange(ofdb_res)
        End If
        If Not imdb_res Is Nothing Then

            Results.AddRange(imdb_res)
        End If

        'Jahr analysieren

        If Einstellungen.Config_Scrapper.Scrapper_Search_with_Year = True And Not Years = "" And Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
            Dim sr As Search_Result = Nothing


            If Not tmdb_res Is Nothing Then
                For Each u In tmdb_res
                    If Not u.Produktionsjahr = "" Then
                        If u.Produktionsjahr = Years Then
                            If sr Is Nothing Then
                                sr = u
                            Else
                                sr = Nothing
                            End If
                        End If
                    End If
                Next
                If Not sr Is Nothing Then
                    m.flag = 1
                    Return sr
                End If
            End If
            If Not ofdb_res Is Nothing Then
                For Each u In ofdb_res
                    If Not u.Produktionsjahr = "" Then
                        If u.Produktionsjahr = Years Then
                            If sr Is Nothing Then
                                sr = u
                            Else
                                sr = Nothing
                            End If
                        End If
                    End If
                Next
                If Not sr Is Nothing Then
                    m.flag = 1
                    Return sr
                    'Exit Function
                End If

            End If

        End If


        'Ergebnis analysieren
        If Not tmdb_res Is Nothing Then
            If tmdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_TMDB_OneHit = True And Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
                m.flag = 1
                Return tmdb_res(0)
                'Exit Function
            End If
        End If

        If Not ofdb_res Is Nothing Then
            If ofdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_OFDB_OneHit = True And Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
                m.flag = 1
                Return ofdb_res(0)
                'BackgroundComplete(m, ofdb_res(0))
                'Exit Function
            End If
        End If



        Return s
        'BuildDialog(Suchtext)





    End Function
    Shared Function Suche_Progress(ByVal m As Film_Info__Organizer.Movie, ByVal l As Laden_Dialog, ByVal backgroundWorker As System.ComponentModel.BackgroundWorker, ByVal p4 As Integer) As Search_Result

        l.advLabelstring = "Suche..."
        'l.advAktuell = 1
        backgroundWorker.ReportProgress(p4)



        Return Suche(m, m.Titel, m.IMDB_ID, m.Produktionsjahr)

        'Results = New List(Of Search_Result)
        'movie = m
        'Dim i As Search_Result = Nothing
        'For Each sr In ScrapperList
        '    If i Is Nothing Then
        '        If Not m.IMDB_ID = "" Then
        '            i = sr.fromIMDB(m.IMDB_ID)
        '        End If
        '    End If
        'Next
        ''If Not i Is Nothing Then
        ''    Results.Add(i)
        ''End If

        ' '' Normale-Suche-> automatische Auswahl
        'If Not i Is Nothing And Einstellungen.UserAbrufen.useImdb = True Then
        '    'm.flag = 1


        '    'NextMovie()
        '    Return i
        'End If


        'Dim ofdb_res As List(Of Search_Result)
        'Dim tmdb_res As List(Of Search_Result)

        'ofdb_res = _OFDB.Search(m.Titel)
        'tmdb_res = _TMDB.Search(m.Titel)
        'If Not ofdb_res Is Nothing Then

        '    Results.AddRange(ofdb_res)
        'End If
        'If Not tmdb_res Is Nothing Then
        '    Results.AddRange(tmdb_res)
        'End If


        'If Einstellungen.Config_Scrapper.Scrapper_Search_with_Year = True And Not m.Produktionsjahr = "" Then
        '    Dim sr As Search_Result = Nothing
        '    If Not ofdb_res Is Nothing Then
        '        For Each u In ofdb_res
        '            If Not u.Produktionsjahr = "" Then
        '                If u.Produktionsjahr = m.Produktionsjahr Then
        '                    If sr Is Nothing Then
        '                        sr = u
        '                    Else
        '                        sr = Nothing
        '                    End If
        '                End If
        '            End If
        '        Next
        '        If Not sr Is Nothing Then
        '            m.flag = 1
        '            Return sr
        '            'Exit Function
        '        End If

        '    End If

        '    If Not tmdb_res Is Nothing Then
        '        For Each u In tmdb_res
        '            If Not u.Produktionsjahr = "" Then
        '                If u.Produktionsjahr = m.Produktionsjahr Then
        '                    If sr Is Nothing Then
        '                        sr = u
        '                    Else
        '                        sr = Nothing
        '                    End If
        '                End If
        '            End If
        '        Next
        '        If Not sr Is Nothing Then
        '            m.flag = 1
        '            Return sr
        '        End If
        '    End If
        'End If


        ''Ergebnis analysieren
        'If Not ofdb_res Is Nothing Then
        '    If ofdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_OFDB_OneHit = True Then
        '        m.flag = 1
        '        Return ofdb_res(0)
        '        'BackgroundComplete(m, ofdb_res(0))
        '        'Exit Function
        '    End If
        'End If
        'If Not tmdb_res Is Nothing Then
        '    If tmdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_TMDB_OneHit = True Then
        '        m.flag = 1
        '        Return tmdb_res(0)
        '        'Exit Function
        '    End If
        'End If



        ''BuildDialog(Suchtext)

        'Return Nothing


    End Function



    Public Shared Function Complete_Progress(ByVal s As Search_Result, ByVal l As Laden_Dialog, ByVal backgroundWorker As System.ComponentModel.BackgroundWorker, ByVal p4 As Integer) As Search_Result
        Dim c As Integer = 0

        For Each h In ScrapperList
            l.advLabelstring = "Abrufen..."
            'l.advAktuell += 1
            backgroundWorker.ReportProgress(p4)
            If Not h.isLoaded(s) Then
                h.Combine(s, h.Additional(s))
            End If
        Next
        For Each h In AddScrapperList
            l.advLabelstring = "Abrufen..."
            'l.advAktuell += 1
            backgroundWorker.ReportProgress(p4)
            If h.Helps(s.MissingValues) And Not h.isLoaded(s) Then
                h.Combine(s, h.Additional(s))
            End If
        Next
        s.meta_loaded = True
        s.Sort = s.Titel
        s.Kurzbeschreibung = s.Inhalt
        If s.Autoren = "" Then
            s.Autoren = s.Regisseur
        End If
        MyFunctions.Check_Artikel(s)
        s.Genre = Einstellungen.GenreFilter.ChangeGenre(s.Genre)
        l.advLabelstring = "Speichern..."
        'l.advAktuell += 1
        backgroundWorker.ReportProgress(p4)
        If s.pic Is Nothing Then
            If Not IsNothing(s.imagelink) Then
                If Not s.imagelink = "http://img.ofdb.de/film/na.gif" Then
                    Dim oImg As Image = MyFunctions.ImageFromWeb(s.imagelink)
                    If oImg Is Nothing Then
                        ' Falls Nothing zurückgegeben wurde...
                        'MsgBox("Bild nicht vorhanden oder Server nicht erreichbar!")
                    Else
                        ' ... andernfalls Bild im PictureBox-Control anzeigen

                        s.pic = oImg
                    End If
                End If
            End If
        End If


        Return s
        'Dim ms As New MetaSaver(s, m)
        'ms.Save()
        'CovertoMovie(m, s)
        'm.SaveFile()
        'If List.Contains(m) Then
        '    List.Remove(m)
        'End If
        'm.Refresh()


    End Function



    'Public Shared Function Suche_Progress(ByVal m As Movie) As Boolean
    '    Results = New List(Of Search_Result)
    '    movie = m
    '    Dim i As Search_Result = Nothing
    '    For Each sr In ScrapperList
    '        If i Is Nothing Then
    '            If Not m.IMDB_ID = "" Then
    '                i = sr.fromIMDB(m.IMDB_ID)
    '            End If
    '        End If
    '    Next
    '    If Not i Is Nothing Then
    '        Results.Add(i)
    '    End If

    '    '' Normale-Suche-> automatische Auswahl
    '    If Einstellungen.UserAbrufen.sMode = OnlineSearchmode.Normal And Not i Is Nothing And Einstellungen.UserAbrufen.useImdb = True Then
    '        'm.flag = 1
    '        Complete_Progress(m, i)

    '        'NextMovie()
    '        Return True
    '    End If


    '    Dim ofdb_res As List(Of Search_Result)
    '    Dim tmdb_res As List(Of Search_Result)

    '    ofdb_res = _OFDB.Search(m.Titel)
    '    tmdb_res = _TMDB.Search(m.Titel)
    '    If Not ofdb_res Is Nothing Then

    '        Results.AddRange(ofdb_res)
    '    End If
    '    If Not tmdb_res Is Nothing Then
    '        Results.AddRange(tmdb_res)
    '    End If


    '    'Ergebnis analysieren
    '    If ofdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_OFDB_OneHit = True And Einstellungen.UserAbrufen.sMode = OnlineSearchmode.Normal Then
    '        m.flag = 1
    '        Complete_Progress(m, ofdb_res(0))

    '        Return True
    '    End If
    '    If tmdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_TMDB_OneHit = True And Einstellungen.UserAbrufen.sMode = OnlineSearchmode.Normal Then
    '        m.flag = 1
    '        Complete_Progress(m, tmdb_res(0))


    '        Return True
    '    End If
    '    'Jahr analysieren

    '    If Einstellungen.Config_Scrapper.Scrapper_Search_with_Year = True And Not m.Produktionsjahr = "" And Einstellungen.UserAbrufen.sMode = OnlineSearchmode.Normal Then
    '        Dim sr As Search_Result = Nothing

    '        For Each u In ofdb_res
    '            If Not u.Produktionsjahr = "" Then
    '                If u.Produktionsjahr = m.Produktionsjahr Then
    '                    If sr Is Nothing Then
    '                        sr = u
    '                    Else
    '                        sr = Nothing
    '                    End If
    '                End If
    '            End If
    '        Next
    '        If Not sr Is Nothing Then
    '            m.flag = 1
    '            Complete_Progress(m, sr)

    '            Return True
    '        End If
    '        For Each u In tmdb_res
    '            If Not u.Produktionsjahr = "" Then
    '                If u.Produktionsjahr = m.Produktionsjahr Then
    '                    If sr Is Nothing Then
    '                        sr = u
    '                    Else
    '                        sr = Nothing
    '                    End If
    '                End If
    '            End If
    '        Next
    '        If Not sr Is Nothing Then
    '            m.flag = 1
    '            Complete_Progress(m, sr)
    '            Return True
    '        End If
    '    End If


    '    'BuildDialog(Suchtext)

    '    Return False



    'End Function

    Public Shared Sub Display_Searchresult(ByVal s As String, Optional ByVal IMDB As String = "")
        Results = New List(Of Search_Result)



        For Each sr In ScrapperList
            Dim r As List(Of Search_Result) = sr.Search(s)
            Dim i As Search_Result
            If Not IMDB = "" Then
                i = sr.fromIMDB(IMDB)
            End If
            If Not r Is Nothing Then
                Results.AddRange(r)
            End If
            If Not i Is Nothing Then
                Results.Add(i)
            End If
        Next




    End Sub
    Public Shared Sub Search_Single(ByVal m As Movie, ByVal s As String, Optional ByVal IMDB As String = "")
        Results = New List(Of Search_Result)
        movie = m
        Dim i As Search_Result = Nothing
        For Each sr In ScrapperList
            Dim r As List(Of Search_Result) = sr.Search(s)
            If i Is Nothing Then
                If Not IMDB = "" Then
                    i = sr.fromIMDB(IMDB)
                End If
            End If
            If Not r Is Nothing Then
                Results.AddRange(r)
            End If
        Next
        If Not i Is Nothing Then
            Results.Add(i)
        End If


        BuildDialog()




    End Sub
    Public Shared Sub Search_ausfuerlich(ByVal m As Movie)
        Results = New List(Of Search_Result)
        movie = m

        Dialog_OnlineSuche.Show()
        Dialog_OnlineSuche.Focus()

        BackgroundSearching(m.Titel, m.IMDB_ID)
        'For Each sr In ScrapperList
        '    Dim r As List(Of Search_Result) = sr.Search(s)
        '    Dim i As Search_Result
        '    If Not IMDB = "" Then
        '        i = sr.fromIMDB(IMDB)
        '    End If
        '    If Not r Is Nothing Then
        '        Results.AddRange(r)
        '    End If
        '    If Not i Is Nothing Then
        '        Results.Add(i)
        '    End If
        'Next



        BuildDialog()




    End Sub
    Public Shared Sub Save(ByVal s As Search_Result)

        For Each ui In AddScrapperList
            If Not ui.isLoaded(s) Then
                ui.LoadInformations(s)
            End If
        Next



        '        If loading = False Then
        '            Main.Cursor = Cursors.WaitCursor
        '            Dialog_OnlineSuche.Cursor = Cursors.WaitCursor
        '        Else
        '            GoTo loadi
        '        End If
        '        If Not IsNothing(Main.SelectedMovie) Then
        '            If Main.SelectedMovie.Equals(m) Then
        '                If s.meta_loaded = False Then
        '                    LoadInformations(s)
        '                End If
        '                If s.imdb_loaded = False Then
        '                    IMDB_Info(s)
        '                End If
        '                CovertoPanel(m, s)
        '                SavetoPanel(s)

        '                If s.modified = False Then
        '                    Main.SelectedResult = New Search_Result(s)
        '                    Main.ToolStripButton_Ergebnisbearbeiten.Visible = True
        '                End If
        '                MyFunctions.Check_Artikel(m)
        '            Else
        '                If s.meta_loaded = False Then
        '                    LoadInformations(s)
        '                End If
        '                If s.imdb_loaded = False Then
        '                    IMDB_Info(s)
        '                End If
        '                CovertoMovie(m, s)
        '                SavetoMovie(m, s, loading)


        '            End If
        '        Else
        'loadi:      If s.meta_loaded = False Then
        '                LoadInformations(s)
        '            End If
        '            If s.imdb_loaded = False Then
        '                IMDB_Info(s)
        '            End If
        '            CovertoMovie(m, s)
        '            SavetoMovie(m, s, loading)

        '            MyFunctions.Check_Artikel(m)
        '        End If
        '        If loading = False Then
        '            Main.Cursor = Cursors.Default
        '            Dialog_OnlineSuche.Cursor = Cursors.Default
        '        End If
    End Sub
    Public Shared Sub BuildDialog(Optional ByVal Suchtext As String = "")

        If Not Suchtext = "" Then
            Vorschläge(Suchtext)
            Dialog_OnlineSuche.ToolStripTextBox_Suche.Text = Suchtext
        End If


        Dialog_OnlineSuche.ListViewVista1.Items.Clear()
        If Results.Count > 0 Then
            For x As Integer = 0 To Results.Count - 1
                Results(x).AddtoList()
            Next
        End If



        'TMDB_Vorschau(suchtitel)
        Dialog_OnlineSuche.lbl_Genre.Text = ""
        Dialog_OnlineSuche.lbl_Inhalt.Text = ""
        Dialog_OnlineSuche.lbl_jahr.Text = ""
        Dialog_OnlineSuche.lbl_titel.Text = ""
        Dialog_OnlineSuche.lbl_Ordner.Text = movie.Ordner
        Dialog_OnlineSuche.ToolStripButton_Abbrechen.DropDownItems.Clear()
        If List.Count > 0 Then
            For x As Integer = 0 To List.Count - 1
                Dialog_OnlineSuche.ToolStripButton_Abbrechen.DropDownItems.Add(List(x).Titel)
            Next
        End If
        Dialog_OnlineSuche.ToolStripButton_Abbrechen.Text = CStr(List.Count)
        Dialog_OnlineSuche.PictureBox1.Image = My.Resources.no_cover_bg
        If Dialog_OnlineSuche.ListViewVista1.Items.Count > 0 Then
            Dialog_OnlineSuche.ListViewVista1.Items(0).Selected = True
        End If
        If Dialog_OnlineSuche.Visible = False Then
            Dialog_OnlineSuche.Show()
        End If

    End Sub
    Private Shared Sub Vorschläge(ByVal suchtitel As String)


        With Dialog_OnlineSuche.ToolStripTextBox_Suche

            .Items.Clear()

            If suchtitel.ToLower.Contains("ae") Or suchtitel.Contains("oe") Or suchtitel.Contains("ue") Then
                .Items.Add(suchtitel.Replace("ae", "ä").Replace("oe", "ö").Replace("ue", "ü"))
            End If
            If suchtitel.Contains(" - ") And Not suchtitel.IndexOf(" - ") = 0 Then
                .Items.Add(suchtitel.Substring(0, suchtitel.IndexOf(" - ")))
            End If
            Dim m As String = suchtitel
            .Items.Add(m)
            Do Until Not m.Contains(" ")
                If m.Contains(" ") Then
                    m = m.Substring(0, m.LastIndexOf(" "))
                    .Items.Add(m)
                End If
            Loop
        End With

        'Dialog_OnlineSuche.ListBox1.Items.Clear()
        'If suchtitel.ToLower.Contains("ae") Or suchtitel.Contains("oe") Or suchtitel.Contains("ue") Then
        '    Dialog_OnlineSuche.ListBox1.Items.Add(suchtitel.Replace("ae", "ä").Replace("oe", "ö").Replace("ue", "ü"))
        'End If
        'If suchtitel.Contains(" - ") And Not suchtitel.IndexOf(" - ") = 0 Then
        '    Dialog_OnlineSuche.ListBox1.Items.Add(suchtitel.Substring(0, suchtitel.IndexOf(" - ")))
        'End If
        'Dim m As String = suchtitel
        'Dialog_OnlineSuche.ListBox1.Items.Add(m)
        'Do Until Not m.Contains(" ") And Not m.LastIndexOf(" ") = 0
        '    If m.Contains(" ") And Not m.LastIndexOf(" ") = 0 Then
        '        m = m.Substring(0, m.LastIndexOf(" "))
        '        Dialog_OnlineSuche.ListBox1.Items.Add(m)
        '    End If
        'Loop
    End Sub

    Shared Sub BackgroundSearching(ByVal s As String, Optional ByVal imdb_id As String = "")
        If Searching_Background = False Then
            Dialog_OnlineSuche.Cursor = Cursors.AppStarting
            Searching_Background = True

            'Ae, Oe, Ue umwandeln
            s = s.Replace("ae", "ä").Replace("oe", "ö").Replace("ue", "ü").Replace("Ae", "Ä").Replace("Oe", "Ö").Replace("Ue", "Ü")

            Dim bgw As New Search_Background
            bgw.s = s
            bgw.imdb = imdb_id

            bgw.Worker.RunWorkerAsync()
        End If
    End Sub
    Shared Sub BackgroundLoading(ByVal s As Search_Result)
        Dim bgw As New Meta_BackgroundWorker
        bgw.s = s
        bgw.Worker.RunWorkerAsync()
    End Sub
    Shared Sub BackgroundComplete(ByVal m As Movie, ByVal s As Search_Result)
        Dim bgw As New Meta_Finalizer
        bgw.s = s
        bgw.m = m
        bgw.Worker.RunWorkerAsync()
    End Sub
    Shared Sub LoadAll(ByVal s As Search_Result)
        For Each h In ScrapperList
            If Not h.isLoaded(s) Then
                h.Combine(s, h.Additional(s))
            End If
        Next
        For Each h In AddScrapperList
            If h.Helps(s.MissingValues) And Not h.isLoaded(s) Then
                h.Combine(s, h.Additional(s))
            End If
        Next
        s.meta_loaded = True
        s.Sort = s.Titel
        s.Kurzbeschreibung = s.Inhalt
        If s.Autoren = "" Then
            s.Autoren = s.Regisseur
        End If
        MyFunctions.Check_Artikel(s)
    End Sub
    Public Shared Sub GetGenres(ByVal s As Search_Result)
        If s.IMDB_ID = "" Or Einstellungen.Config_Genre.Genre_tmdbdownload = False Then
            s.Genre = Einstellungen.GenreFilter.ChangeGenre(s.Genre)
            Exit Sub

        End If
        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/de/xml/5fe800e9f7891b9131c0059be62a36d0/" & s.IMDB_ID, "tmdb.imdbLookup_de_" & s.IMDB_ID)

        If Not xml Is Nothing Then

            Dim g As String = ""
            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            xpath = "//category"

            ' Dokumentgruppe,Dokument,Datei,Pfad
            ' Container für unseren aktiven Knoten

            ' Für den Fall das wir mehrere Knoten haben auf die unser 
            ' XPath zutrifft
            j = xml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode

                    xmln = xml.SelectNodes(xpath).Item(i)
                    If xmln.Attributes("type").Value = "genre" Then
                        If g = "" Then
                            g = xmln.Attributes("name").Value
                        Else
                            g &= ", " & xmln.Attributes("name").Value
                        End If
                    End If
                    'Dim stitel As String = If(xmln.SelectNodes("//titel").Count > 0, xmln.SelectSingleNode("//titel").InnerText, "")
                    'Dim sotitel As String = If(xmln.SelectNodes("//titel_orig").Count > 0, xmln.SelectSingleNode("//titel_orig").InnerText, "")
                    'Dim sid As String = If(xmln.SelectNodes("//id").Count > 0, xmln.SelectSingleNode("//id").InnerText, "")
                    'Dim sjahr As String = If(xmln.SelectNodes("//jahr").Count > 0, xmln.SelectSingleNode("//jahr").InnerText, "")

                    'Dim sr As Search_Result = New Search_Result(stitel, sotitel, sid, sjahr, 0)

                    ''sr.IMDB_ID = If(xmln.SelectNodes("//imdb_id").Count > 0, xmln.SelectSingleNode("//imdb_id").InnerText, "")
                    'sr.Kurzbeschreibung = If(xmln.SelectNodes("//overview").Count > 0, xmln.SelectSingleNode("//overview").InnerText, "")
                    'sr.meta_loaded = True

                    'Dialog_OnlineSuche.results.Add(sr)


                Next
            End If
            If Not g = "" Then
                s.Genre = g
            End If
            s.Genre = Einstellungen.GenreFilter.ChangeGenre(s.Genre)
        Else
            Exit Sub
        End If
    End Sub
    Public Shared Function GetGenres(ByVal id As String) As String
        If id = "" Then
            Return ""

        End If
        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/de/xml/5fe800e9f7891b9131c0059be62a36d0/" & id, "tmdb.imdbLookup_de_" & id)

        If Not xml Is Nothing Then

            Dim g As String = ""
            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            xpath = "//category"

            ' Dokumentgruppe,Dokument,Datei,Pfad
            ' Container für unseren aktiven Knoten

            ' Für den Fall das wir mehrere Knoten haben auf die unser 
            ' XPath zutrifft
            j = xml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode

                    xmln = xml.SelectNodes(xpath).Item(i)
                    If xmln.Attributes("type").Value = "genre" Then
                        If g = "" Then
                            g = xmln.Attributes("name").Value
                        Else
                            g &= ", " & xmln.Attributes("name").Value
                        End If
                    End If
                    'Dim stitel As String = If(xmln.SelectNodes("//titel").Count > 0, xmln.SelectSingleNode("//titel").InnerText, "")
                    'Dim sotitel As String = If(xmln.SelectNodes("//titel_orig").Count > 0, xmln.SelectSingleNode("//titel_orig").InnerText, "")
                    'Dim sid As String = If(xmln.SelectNodes("//id").Count > 0, xmln.SelectSingleNode("//id").InnerText, "")
                    'Dim sjahr As String = If(xmln.SelectNodes("//jahr").Count > 0, xmln.SelectSingleNode("//jahr").InnerText, "")

                    'Dim sr As Search_Result = New Search_Result(stitel, sotitel, sid, sjahr, 0)

                    ''sr.IMDB_ID = If(xmln.SelectNodes("//imdb_id").Count > 0, xmln.SelectSingleNode("//imdb_id").InnerText, "")
                    'sr.Kurzbeschreibung = If(xmln.SelectNodes("//overview").Count > 0, xmln.SelectSingleNode("//overview").InnerText, "")
                    'sr.meta_loaded = True

                    'Dialog_OnlineSuche.results.Add(sr)


                Next
            End If
            'If Not g = "" Then
            '    s.Genre = g
            'End If
            Return g
        Else
            Return ""
        End If
    End Function
    Public Class Search_Background
        Public s As String = ""
        Public imdb As String = ""
        Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Sub New()
            Worker.WorkerSupportsCancellation = True
        End Sub
        Private Sub Worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
            Results = New List(Of Search_Result)
            'movie = m

            For Each sr In ScrapperList
                Dim r As List(Of Search_Result) = sr.Search(s)
                Dim i As Search_Result = Nothing
                If Not imdb = "" Then
                    i = sr.fromIMDB(imdb)
                End If
                If Not r Is Nothing Then
                    Results.AddRange(r)
                End If
                If Not i Is Nothing Then
                    Results.Add(i)
                End If
            Next
        End Sub
        Private Sub Load_Dir_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
            Dialog_OnlineSuche.ToolStripTextBox_Suche.Enabled = True
            Dialog_OnlineSuche.Cursor = Cursors.Default
            Searching_Background = False
            BuildDialog()
        End Sub
    End Class
    Public Class Meta_BackgroundWorker
        Public s As Search_Result
        Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Sub New()
            Worker.WorkerSupportsCancellation = True
        End Sub
        Private Sub Worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
            If s.type = MetaProvider.OFDB Then
                Dim ff As New OFDb_Scrapper
                ff.LoadInformations(s)
            ElseIf s.type = MetaProvider.tmdb Then
                Dim tt As New TMDB_Scrapper
                tt.LoadInformations(s)
            ElseIf s.type = MetaProvider.IMDb Then
                Dim tt As New IMDb_Scrapper_Search
                tt.LoadInformations(s)
            ElseIf s.type = MetaProvider.Exact Then
                If Not s.ofdb_id = "" Then
                    _OFDB.LoadInformations(s)
                ElseIf Not s.tmdb_id = "" Then
                    _TMDB.LoadInformations(s)
                End If
            End If

            If Not IsNothing(s.imagelink) Then


                If Not s.imagelink = "http://img.ofdb.de/film/na.gif" Then
                    Dim oImg As Image = MyFunctions.ImageFromWeb(s.imagelink)


                    If oImg Is Nothing Then
                        ' Falls Nothing zurückgegeben wurde...
                        'MsgBox("Bild nicht vorhanden oder Server nicht erreichbar!")
                    Else
                        ' ... andernfalls Bild im PictureBox-Control anzeigen
                        'Dialog_OnlineSuche.PictureBox1.Image = oImg
                        s.pic = oImg
                    End If
                End If
            End If
            'Meta.LoadInformations(s)
        End Sub
        Private Sub Load_Dir_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
            With Dialog_OnlineSuche
                s.litem.ImageIndex = 0
                If .ListViewVista1.SelectedItems.Count = 1 Then
                    If .ListViewVista1.SelectedItems(0).Tag.Equals(s) Then
                        Dialog_OnlineSuche.ListViewVista1_SelectedIndexChanged(Me, New EventArgs)
                    End If
                End If
            End With
        End Sub
    End Class
    Public Class Meta_Finalizer
        Public s As Search_Result
        Public m As Movie
        Public l As New Laden_Dialog
        Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Sub New()
            Worker.WorkerSupportsCancellation = True
            Worker.WorkerReportsProgress = True
            l.Text = "Informationen abrufen"
            l.Labelstring = "Rufe Informationen ab"
            l.aDetails = False
            l.aCancel = True
            l.Gesamtzahl = ScrapperList.Count + AddScrapperList.Count + 1
            'laden = l
            l.Refresh()
            l.Show()
        End Sub
        Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
            l.Aktualisieren(e.ProgressPercentage)

            'pushlist.Clear()
        End Sub
        Private Sub Worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
            Dim c As Integer = 0

            For Each h In ScrapperList
                If l.Cancel = True Then GoTo Canceled
                If Not h.isLoaded(s) Then
                    h.Combine(s, h.Additional(s))
                End If
                c += 1
                l.Nächster()
                Worker.ReportProgress(CInt((c / l.Gesamtzahl) * 100))
            Next
            For Each h In AddScrapperList
                If l.Cancel = True Then GoTo Canceled
                If h.Helps(s.MissingValues) And Not h.isLoaded(s) Then
                    h.Combine(s, h.Additional(s))
                End If
                c += 1
                l.Nächster()
                Worker.ReportProgress(CInt((c / l.Gesamtzahl) * 100))
            Next
            Dim zd As New Zell_Scrapper
            zd.Additional(s)

            s.meta_loaded = True
            s.Sort = s.Titel
            s.Kurzbeschreibung = s.Inhalt
            If s.Autoren = "" Then
                s.Autoren = s.Regisseur
            End If
            MyFunctions.Check_Artikel(s)
            s.Genre = Einstellungen.GenreFilter.ChangeGenre(s.Genre)
            If l.Cancel = True Then GoTo Canceled
            If s.pic Is Nothing Then
                If Not IsNothing(s.imagelink) Then


                    If Not s.imagelink = "http://img.ofdb.de/film/na.gif" Then
                        Dim oImg As Image = MyFunctions.ImageFromWeb(s.imagelink)


                        If oImg Is Nothing Then
                            ' Falls Nothing zurückgegeben wurde...
                            'MsgBox("Bild nicht vorhanden oder Server nicht erreichbar!")
                        Else
                            ' ... andernfalls Bild im PictureBox-Control anzeigen

                            s.pic = oImg
                        End If
                    End If
                End If
            End If

            'LoadInformations(Results(0))
            'm.flag = 1 'Kennzeichnen als nicht gesichert
            c += 1
            l.Nächster()
            Worker.ReportProgress(CInt((c / l.Gesamtzahl) * 100))
Canceled:
        End Sub
        Private Sub Load_Dir_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
            'laden.Close()
            If l.Cancel = False Then
                MetaScrapper.Save(m, s)
            End If

            If List.Contains(m) Then
                List.Remove(m)
            End If
            m.Refresh()

            Dialog_OnlineSuche.Enabled = True
            l.closallowed = True
            l.Close()
            l.Dispose()
            MetaScrapper.NextMovie()

            Worker.Dispose()

        End Sub
    End Class
    Public Shared Function Suche_Schnell_Progress(ByVal m As Film_Info__Organizer.Movie, ByVal l As Laden_Dialog, ByVal backgroundWorker As System.ComponentModel.BackgroundWorker, ByVal p4 As Integer) As Search_Result
        l.advLabelstring = "Suche..."
        'l.advAktuell = 1
        backgroundWorker.ReportProgress(p4)
        Results = New List(Of Search_Result)
        'movie = m
        Dim i As Search_Result = Nothing
        For Each sr In ScrapperList
            If i Is Nothing Then
                If Not m.IMDB_ID = "" Then
                    i = sr.fromIMDB(m.IMDB_ID)
                End If
            End If
        Next

        '' Normale-Suche-> automatische Auswahl
        If Not i Is Nothing And Einstellungen.UserAbrufen.useImdb = True Then
            'm.flag = 1

            Return i
            'NextMovie()

        End If
        Dim id As String = Imdb_getid(m.Titel)

        For Each sr In ScrapperList
            If i Is Nothing Then
                If Not id = "" Then
                    i = sr.fromIMDB(id)
                End If
            End If
        Next


        If Not i Is Nothing Then
            m.flag = 1
            Return i
        End If



        Dim ofdb_res As List(Of Search_Result)
        Dim tmdb_res As List(Of Search_Result)

        ofdb_res = _OFDB.Search(m.Titel)
        tmdb_res = _TMDB.Search(m.Titel)
        If Not ofdb_res Is Nothing Then

            Results.AddRange(ofdb_res)
        End If
        If Not tmdb_res Is Nothing Then
            Results.AddRange(tmdb_res)
        End If


        'Ergebnis analysieren
        If ofdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_OFDB_OneHit = True And Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
            m.flag = 1


            Return ofdb_res(0)
        End If
        If tmdb_res.Count = 1 And Einstellungen.Config_Scrapper.Scrapper_TMDB_OneHit = True And Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
            m.flag = 1
            Return tmdb_res(0)


        End If
        'Jahr analysieren

        If Einstellungen.Config_Scrapper.Scrapper_Search_with_Year = True And Not m.Produktionsjahr = "" Then
            Dim sr As Search_Result = Nothing

            For Each u In ofdb_res
                If Not u.Produktionsjahr = "" Then
                    If u.Produktionsjahr = m.Produktionsjahr Then
                        If sr Is Nothing Then
                            sr = u
                        Else
                            sr = Nothing
                        End If
                    End If
                End If
            Next
            If Not sr Is Nothing Then
                m.flag = 1

                Return sr
            End If
            For Each u In tmdb_res
                If Not u.Produktionsjahr = "" Then
                    If u.Produktionsjahr = m.Produktionsjahr Then
                        If sr Is Nothing Then
                            sr = u
                        Else
                            sr = Nothing
                        End If
                    End If
                End If
            Next
            If Not sr Is Nothing Then
                m.flag = 1

                Return sr
            End If
        End If


        'BuildDialog(Suchtext)

        Return Nothing

    End Function
    Public Shared Function Suche_Schnell(ByVal m As Film_Info__Organizer.Movie, ByVal t As String) As Search_Result

        'movie = m
        Dim i As Search_Result = Nothing
        For Each sr In ScrapperList
            If i Is Nothing Then
                If Not m.IMDB_ID = "" Then
                    i = sr.fromIMDB(m.IMDB_ID)
                End If
            End If
        Next

        '' Normale-Suche-> automatische Auswahl
        If Not i Is Nothing And Einstellungen.UserAbrufen.useImdb = True Then
            'm.flag = 1

            Return i
            'NextMovie()

        End If
        Dim id As String = Imdb_getid(t)

        For Each sr In ScrapperList
            If i Is Nothing Then
                If Not id = "" Then
                    i = sr.fromIMDB(id)
                End If
            End If
        Next


        If Not i Is Nothing Then
            Return i
            'BackgroundComplete(m, i)
        End If

        Return i


    End Function







    Public Shared Function Imdb_getid(ByVal suchtext As String) As String
        Try

            Dim httpUri As String
            Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create("http://www.google.de/search?q=" + suchtext.Replace(" ", "+") + "+site%3Aimdb.com&btnI=Auf+gut+Gl%C3%BCck%21&meta=&aq=f&oq="), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            '&meta=&aq=f&oq=
            httpResponse = CType(httpRequest.GetResponse, Net.HttpWebResponse)


            'MsgBox(httpRequest.Timeout)
            httpRequest.Timeout = 10000
            httpUri = httpResponse.ResponseUri.ToString
            ' Process.Start(httpUri)
            'httpUri = httpRequest.GetResponse.ResponseUri.ToString
            httpResponse.Close()
            'httpRequest.cl()

            'httpUri = httpResponse.ResponseUri.ToString
            'Dim reader As StreamReader = New StreamReader(httpResponse.GetResponseStream)
            Dim myresultlink As String = ""

            Dim myResultmovEx As New System.Text.RegularExpressions.Regex("http://www.imdb.com/title/(?<titel>(.*))/")
            If Not httpUri = vbNullString Then
                If myResultmovEx.IsMatch(httpUri) Then
                    myresultlink = myResultmovEx.Match(httpUri).Groups("titel").ToString()
                End If
                Return myresultlink
            Else
                Return ""
            End If



        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return ""
        End Try
    End Function

    Public Shared Sub CompleteMovie(ByVal m As Film_Info__Organizer.Movie, ByVal s As Search_Result)

        _OFDB.Combine(s, _OFDB.Additional(s))
        _TMDB.Combine(s, _TMDB.Additional(s))
        _MoPi.Combine(s, _MoPi.Additional(s))
        _IMDB.Combine(s, _IMDB.Additional(s))
        MyFunctions.Check_Artikel(s)

        If Not s.pic Is Nothing Then
            If Not IsNothing(s.imagelink) Then


                If Not s.imagelink = "http://img.ofdb.de/film/na.gif" Then
                    Dim oImg As Image = MyFunctions.ImageFromWeb(s.imagelink)


                    If oImg Is Nothing Then
                        ' Falls Nothing zurückgegeben wurde...
                        'MsgBox("Bild nicht vorhanden oder Server nicht erreichbar!")
                    Else
                        ' ... andernfalls Bild im PictureBox-Control anzeigen

                        s.pic = oImg
                    End If
                End If
            End If
        End If



        'LoadInformations(Results(0))
        'm.flag = 1 'Kennzeichnen als nicht gesichert
        Save(m, s)
        If List.Contains(m) Then
            List.Remove(m)
        End If
    End Sub
    Private Shared Sub CovertoPanel(ByVal m As Movie, ByVal s As Search_Result)


        If Not IsNothing(s.pic) Then
            If IO.File.Exists(m.Cover) Then
                If MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = "" Or MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = s.IMDB_ID Then
                    If m.Cover_height = 0 Then
                        Dim img As Image = MyFunctions.ImageFromJpeg(m.Cover)
                        If Not img Is Nothing Then
                            m.Cover_height = img.Height
                            m.Cover_width = img.Width
                        End If

                    End If
                    If m.Cover_height >= s.pic.Height Then

                    Else
                        Try


                            s.pic.Save(ImageDestinations.Cover(m.Pfad), System.Drawing.Imaging.ImageFormat.Jpeg)
                            m.Cover = ImageDestinations.Cover(m.Pfad)
                            m.Cover_height = s.pic.Height
                            m.Cover_width = s.pic.Width
                            MainForm.InfoPanel_Movie1.PictureBox1.Image = MyFunctions.ImageFromJpeg(m.Cover)
                        Catch ex As Exception

                        End Try
                    End If
                Else
                    Try
                        IO.File.Delete(m.Cover)

                        s.pic.Save(ImageDestinations.Cover(m.Pfad), System.Drawing.Imaging.ImageFormat.Jpeg)
                        m.Cover = ImageDestinations.Cover(m.Pfad)
                        m.Cover_height = s.pic.Height
                        m.Cover_width = s.pic.Width
                        MainForm.InfoPanel_Movie1.PictureBox1.Image = MyFunctions.ImageFromJpeg(m.Cover)
                    Catch ex As Exception

                    End Try
                End If
            Else
                Try


                    s.pic.Save(ImageDestinations.Cover(m.Pfad), System.Drawing.Imaging.ImageFormat.Jpeg)
                    m.Cover = ImageDestinations.Cover(m.Pfad)
                    m.Cover_height = s.pic.Height
                    m.Cover_width = s.pic.Width
                    MainForm.InfoPanel_Movie1.PictureBox1.Image = MyFunctions.ImageFromJpeg(m.Cover)
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    Private Shared Sub CovertoMovie(ByVal m As Movie, ByVal s As Search_Result)
        If Not IsNothing(s.pic) Then


            If IO.File.Exists(m.Cover) Then
                If m.IMDB_ID = "" Or m.IMDB_ID = s.IMDB_ID Then

                    If m.Cover_height = 0 Then
                        Dim img As Image = MyFunctions.ImageFromJpeg(m.Cover)
                        If Not img Is Nothing Then
                            m.Cover_height = img.Height
                            m.Cover_width = img.Width
                        End If

                    End If
                    If m.Cover_height <= s.pic.Height Then



                        Try
                            IO.File.Delete(m.Cover)
                            s.pic.Save(IO.Path.Combine(m.Pfad, "folder.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg)
                            m.Cover = IO.Path.Combine(m.Pfad, "folder.jpg")
                            m.Cover_height = s.pic.Height
                            m.Cover_width = s.pic.Width
                        Catch ex As Exception

                        End Try
                    End If
                Else

                    Try
                        IO.File.Delete(m.Cover)
                        s.pic.Save(IO.Path.Combine(m.Pfad, "folder.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg)
                        m.Cover = IO.Path.Combine(m.Pfad, "folder.jpg")
                        m.Cover_height = s.pic.Height
                        m.Cover_width = s.pic.Width
                    Catch ex As Exception

                    End Try
                End If


            Else
                s.pic.Save(IO.Path.Combine(m.Pfad, "folder.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg)
                m.Cover = IO.Path.Combine(m.Pfad, "folder.jpg")
                m.Cover_height = s.pic.Height
                m.Cover_width = s.pic.Width

            End If
        End If
    End Sub

    Public Shared Sub Save(ByVal m As Movie, ByVal s As Search_Result)

        If m.focused Then
            Dim mSaver As New MetaSaver(s)
            mSaver.Save()
            CovertoPanel(m, s)
            If s.modified = False Then
                MainForm.InfoPanel_Movie1.SelectedResult = New Search_Result(s)
                MainForm.InfoPanel_Movie1.ToolStripButton_Ergebnisbearbeiten.Visible = True
            End If
        Else
            Dim ms As New MetaSaver(s, m)
            ms.Save()
            CovertoMovie(m, s)
            m.SaveFile()
            'If Load() = False Then
            '    m.Refresh()
            'End If
        End If



    End Sub

    Public Class MetaSaver

        Property toPanel As Boolean
        Property s As Search_Result
        Property m As Movie
        Private Sub Ersetzen()
            If toPanel = True Then
                With MainForm.InfoPanel_Movie1
                    .TB_Titel.Text = s.Titel
                    .TB_Originaltitel.Text = s.Originaltitel
                    .TB_IMDB_ID.Text = s.IMDB_ID
                    .DarstellerView.Rows.Clear()
                    Dim Darsteller() As String = s.Darsteller.Split(CChar(","))
                    If Darsteller.Length > 0 Then
                        For x As Integer = 0 To Darsteller.Length - 1
                            Dim DSname_S As String = ""
                            Dim DSrole_S As String = ""
                            If Darsteller(x).Contains("[") Then
                                Dim DSname() As String = Darsteller(x).Split(CChar("["))
                                DSname_S = Trim(DSname(0))
                                DSrole_S = Trim(DSname(1)).Replace("]", "")
                                DSrole_S = DSrole_S.Replace("...", "")
                                DSrole_S = Trim(DSrole_S)
                            Else
                                DSname_S = Trim(Darsteller(x))
                            End If
                            .DarstellerView.Rows.Add(DSname_S, DSrole_S)
                        Next
                    End If
                    .TB_Regisseur.Text = s.Regisseur
                    .TB_Autoren.Text = s.Autoren
                    .TB_Studios.Text = s.Studios
                    .TB_Produktionsjahr.Text = s.Produktionsjahr
                    .TB_Produktionsland.Text = s.Produktionsland
                    .TB_Genre.Text = s.Genre

                    If Not s.FSK = "" Then
                        With s.FSK.ToString
                            If .Contains("18") Then
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "18"
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "18"
                            ElseIf .Contains("16") Then
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "16"
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "16"
                            ElseIf .Contains("12") Then
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "12"
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "12"
                            ElseIf .Contains("6") Then
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "6"
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "6"
                            ElseIf .Contains("0") Then
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "0"
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "0"
                            Else
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                                MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                            End If

                        End With
                    Else
                        MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                        MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                    End If
                    .TB_Bewertung.Text = s.Bewertung
                    '.TB_Spieldauer.Text = s.Spieldauer
                    '.TB_Kurzbeschreibung.Text = s.Kurzbeschreibung
                    .TB_Inhalt.Text = s.Inhalt
                    .TB_Sort.Text = s.Sort
                    .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    '.Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    '.Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    '.Table_Kurzbeschreibung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    '.Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    .Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green


                End With
            Else
                m.Titel = s.Titel
                m.Originaltitel = s.Originaltitel
                m.IMDB_ID = s.IMDB_ID
                m.Darsteller = s.Darsteller
                m.Regisseur = s.Regisseur
                m.Autoren = s.Autoren
                m.Studios = s.Studios
                m.Produktionsjahr = s.Produktionsjahr
                m.Produktionsland = s.Produktionsland
                m.Genre = s.Genre
                m.FSK = s.FSK
                m.Bewertung = s.Bewertung
                'm.Spieldauer = s.Spieldauer

                m.Kurzbeschreibung = s.Kurzbeschreibung
                m.Inhalt = s.Inhalt
                m.Sort = s.Sort



            End If

        End Sub
        Private Sub Ergänzen()
            If toPanel = True Then
                With MainForm.InfoPanel_Movie1

                    If .TB_Titel.Text = "" And Not s.Titel = "" Then
                        .TB_Titel.Text = s.Titel
                        .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Originaltitel.Text = "" And Not s.Originaltitel = "" Then
                        .TB_Originaltitel.Text = s.Originaltitel
                        .Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_IMDB_ID.Text = "" And Not s.IMDB_ID = "" Then
                        .TB_IMDB_ID.Text = s.IMDB_ID
                        .Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Regisseur.Text = "" And Not s.Regisseur = "" Then
                        .TB_Regisseur.Text = s.Regisseur
                        .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Autoren.Text = "" And Not s.Autoren = "" Then
                        .TB_Autoren.Text = s.Autoren
                        .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Studios.Text = "" And Not s.Studios = "" Then
                        .TB_Studios.Text = s.Studios
                        .Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Produktionsjahr.Text = "" And Not s.Produktionsjahr = "" Then
                        .TB_Produktionsjahr.Text = s.Produktionsjahr
                        .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Produktionsland.Text = "" And Not s.Produktionsland = "" Then
                        .TB_Produktionsland.Text = s.Produktionsland
                        .Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Genre.Text = "" And Not s.Genre = "" Then
                        .TB_Genre.Text = s.Genre
                        .Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .FSK_Combobox.Text = "" And Not s.FSK = "" Then

                        If Not s.FSK = "" Then
                            With s.FSK.ToString
                                If .Contains("18") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "18"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "18"
                                ElseIf .Contains("16") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "16"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "16"
                                ElseIf .Contains("12") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "12"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "12"
                                ElseIf .Contains("6") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "6"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "6"
                                ElseIf .Contains("0") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "0"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "0"
                                Else
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                                End If

                            End With
                        Else
                            MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                            MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                        End If
                        .Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Bewertung.Text = "" And Not s.Bewertung = "" Then
                        .TB_Bewertung.Text = s.Bewertung
                        .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Inhalt.Text = "" And Not s.Inhalt = "" Then
                        .TB_Inhalt.Text = s.Inhalt
                        '.Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If .TB_Sort.Text = "" And Not s.Sort = "" Then
                        .TB_Sort.Text = s.Sort
                        .Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If


                    If .DarstellerView.Rows.Count = 1 And Not s.Darsteller = "" Then
                        .DarstellerView.Rows.Clear()
                        Dim Darsteller() As String = s.Darsteller.Split(CChar(","))
                        If Darsteller.Length > 0 Then
                            For x As Integer = 0 To Darsteller.Length - 1
                                Dim DSname_S As String = ""
                                Dim DSrole_S As String = ""
                                If Darsteller(x).Contains("[") Then
                                    Dim DSname() As String = Darsteller(x).Split(CChar("["))
                                    DSname_S = Trim(DSname(0))
                                    DSrole_S = Trim(DSname(1)).Replace("]", "")
                                    DSrole_S = DSrole_S.Replace("...", "")
                                    DSrole_S = Trim(DSrole_S)
                                Else
                                    DSname_S = Trim(Darsteller(x))
                                End If
                                .DarstellerView.Rows.Add(DSname_S, DSrole_S)
                            Next
                        End If
                    End If


                End With
            Else
                If m.Titel = "" And Not s.Titel = "" Then
                    m.Titel = s.Titel
                End If
                If m.Originaltitel = "" And Not s.Originaltitel = "" Then
                    m.Originaltitel = s.Originaltitel
                End If
                If m.IMDB_ID = "" And Not s.IMDB_ID = "" Then
                    m.IMDB_ID = s.IMDB_ID
                End If
                If m.Darsteller = "" And Not s.Darsteller = "" Then
                    m.Darsteller = s.Darsteller
                End If
                If m.Regisseur = "" And Not s.Regisseur = "" Then
                    m.Regisseur = s.Regisseur
                End If
                If m.Autoren = "" And Not s.Autoren = "" Then
                    m.Autoren = s.Autoren
                End If
                If m.Studios = "" And Not s.Studios = "" Then
                    m.Studios = s.Studios
                End If
                If m.Produktionsjahr = "" And Not s.Produktionsjahr = "" Then
                    m.Produktionsjahr = s.Produktionsjahr
                End If
                If m.Produktionsland = "" And Not s.Produktionsland = "" Then
                    m.Produktionsland = s.Produktionsland
                End If
                If m.Genre = "" And Not s.Genre = "" Then
                    m.Genre = s.Genre
                End If
                If m.FSK = "" And Not s.FSK = "" Then
                    m.FSK = s.FSK
                End If
                If m.Bewertung = "" And Not s.Bewertung = "" Then
                    m.Bewertung = s.Bewertung
                End If
                If m.Inhalt = "" And Not s.Inhalt = "" Then
                    m.Inhalt = s.Inhalt
                End If
                If m.Sort = "" And Not s.Sort = "" Then
                    m.Sort = s.Sort
                End If

            End If
        End Sub
        Private Sub Benutzerdefiniert()
            If toPanel = True Then
                With MainForm.InfoPanel_Movie1
                    If (Einstellungen.Config_Overwrite.Titel = True Or .TB_Titel.Text = "") And Not s.Titel = "" Then
                        .TB_Titel.Text = s.Titel
                        .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Originaltitel = True Or .TB_Originaltitel.Text = "") And Not s.Originaltitel = "" Then
                        .TB_Originaltitel.Text = s.Originaltitel
                        .Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.IMDB_ID = True Or .TB_IMDB_ID.Text = "") And Not s.IMDB_ID = "" Then
                        .TB_IMDB_ID.Text = s.IMDB_ID
                        .Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Darsteller = True Or .DarstellerView.RowCount = 1) And Not s.Darsteller = "" Then
                        .DarstellerView.Rows.Clear()
                        Dim Darsteller() As String = s.Darsteller.Split(CChar(","))
                        If Darsteller.Length > 0 Then
                            For x As Integer = 0 To Darsteller.Length - 1
                                Dim DSname_S As String = ""
                                Dim DSrole_S As String = ""
                                If Darsteller(x).Contains("[") Then
                                    Dim DSname() As String = Darsteller(x).Split(CChar("["))
                                    DSname_S = Trim(DSname(0))
                                    DSrole_S = Trim(DSname(1)).Replace("]", "")
                                    DSrole_S = DSrole_S.Replace("...", "")
                                    DSrole_S = Trim(DSrole_S)
                                Else
                                    DSname_S = Trim(Darsteller(x))
                                End If
                                MainForm.InfoPanel_Movie1.DarstellerView.Rows.Add(DSname_S, DSrole_S)
                            Next
                        End If
                        '.Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Regisseur = True Or .TB_Regisseur.Text = "") And Not s.Regisseur = "" Then
                        .TB_Regisseur.Text = s.Regisseur
                        .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Autoren = True Or .TB_Autoren.Text = "") And Not s.Autoren = "" Then
                        .TB_Autoren.Text = s.Autoren
                        .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Studios = True Or .TB_Studios.Text = "") And Not s.Studios = "" Then
                        .TB_Studios.Text = s.Studios
                        .Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Produktionsjahr = True Or .TB_Produktionsjahr.Text = "") And Not s.Produktionsjahr = "" Then
                        .TB_Produktionsjahr.Text = s.Produktionsjahr
                        .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Produktionsland = True Or .TB_Produktionsland.Text = "") And Not s.Produktionsland = "" Then
                        .TB_Produktionsland.Text = s.Produktionsland
                        .Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Genre = True Or .TB_Genre.Text = "") And Not s.Genre = "" Then
                        .TB_Genre.Text = s.Genre
                        .Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.FSK = True Or .FSK_Combobox.Text = "") And Not s.FSK = "" Then

                        If Not s.FSK = "" Then
                            With s.FSK.ToString
                                If .Contains("18") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "18"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "18"
                                ElseIf .Contains("16") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "16"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "16"
                                ElseIf .Contains("12") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "12"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "12"
                                ElseIf .Contains("6") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "6"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "6"
                                ElseIf .Contains("0") Then
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = "0"
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = "0"
                                Else
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                                    MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                                End If

                            End With
                        Else
                            MainForm.InfoPanel_Movie1.FSK_Combobox.Text = ""
                            MainForm.InfoPanel_Movie1.FSK_Combobox.Tag = ""
                        End If
                        .Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Bewertung = True Or .TB_Bewertung.Text = "") And Not s.Bewertung = "" Then
                        .TB_Bewertung.Text = s.Bewertung
                        .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Inhalt = True Or .TB_Inhalt.Text = "") And Not s.Inhalt = "" Then
                        .TB_Inhalt.Text = s.Inhalt
                        '.Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If
                    If (Einstellungen.Config_Overwrite.Sort = True Or .TB_Sort.Text = "") And Not s.Sort = "" Then
                        .TB_Sort.Text = s.Sort
                        .Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_green
                    End If



                End With
            Else
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Titel = "") And Not s.Titel = "" Then
                    m.Titel = s.Titel
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Originaltitel = "") And Not s.Originaltitel = "" Then
                    m.Originaltitel = s.Originaltitel
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.IMDB_ID = "") And Not s.IMDB_ID = "" Then
                    m.IMDB_ID = s.IMDB_ID
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Darsteller = "") And Not s.Darsteller = "" Then
                    m.Darsteller = s.Darsteller
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Regisseur = "") And Not s.Regisseur = "" Then
                    m.Regisseur = s.Regisseur
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Autoren = "") And Not s.Autoren = "" Then
                    m.Autoren = s.Autoren
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Studios = "") And Not s.Studios = "" Then
                    m.Studios = s.Studios
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Produktionsjahr = "") And Not s.Produktionsjahr = "" Then
                    m.Produktionsjahr = s.Produktionsjahr
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Produktionsland = "") And Not s.Produktionsland = "" Then
                    m.Produktionsland = s.Produktionsland
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Genre = "") And Not s.Genre = "" Then
                    m.Genre = s.Genre
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.FSK = "") And Not s.FSK = "" Then
                    m.FSK = s.FSK
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Bewertung = "") And Not s.Bewertung = "" Then
                    m.Bewertung = s.Bewertung
                End If
                'If (Einstellungen.Config_Overwrite.Titel = True Or m.Spieldauer = "") And Not s.Spieldauer = "" Then
                '    m.Spieldauer = s.Spieldauer
                'End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Kurzbeschreibung = "") And Not s.Kurzbeschreibung = "" Then
                    m.Kurzbeschreibung = s.Kurzbeschreibung
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Inhalt = "") And Not s.Inhalt = "" Then
                    m.Inhalt = s.Inhalt
                End If
                If (Einstellungen.Config_Overwrite.Titel = True Or m.Sort = "") And Not s.Sort = "" Then
                    m.Sort = s.Sort
                End If


            End If

        End Sub

        Sub New(ByVal sr As Search_Result)
            s = sr
            toPanel = True
        End Sub
        Sub New(ByVal sr As Search_Result, ByVal Mov As Movie)
            m = Mov
            s = sr
            toPanel = False
        End Sub
        Sub Save()
            If s.modified = True Then
                Ersetzen()
            Else
                Select Case Einstellungen.Config_Overwrite.Mode
                    Case Is = Overwritemode.Automatisch
                        If toPanel = True Then
                            If MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = "" Then
                                Ersetzen()
                            ElseIf MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = s.IMDB_ID Then
                                Ergänzen()
                            Else
                                Ersetzen()
                            End If
                        Else
                            If m.IMDB_ID = "" Then
                                Ersetzen()
                            ElseIf m.IMDB_ID = s.IMDB_ID Then
                                Ergänzen()
                            Else
                                Ersetzen()
                            End If
                        End If
                    Case Is = Overwritemode.Benutzerdefiniert
                        Benutzerdefiniert()
                    Case Is = Overwritemode.Ergänzen
                        Ergänzen()
                    Case Is = Overwritemode.Ersetzen
                        Ersetzen()
                    Case Else
                        If toPanel = True Then
                            If MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = "" Then
                                Ersetzen()
                            ElseIf MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text = s.IMDB_ID Then
                                Ergänzen()
                            Else
                                Ersetzen()
                            End If
                        Else
                            If m.IMDB_ID = "" Then
                                Ersetzen()
                            ElseIf m.IMDB_ID = s.IMDB_ID Then
                                Ergänzen()
                            Else
                                Ersetzen()
                            End If
                        End If
                End Select

            End If

        End Sub


    End Class


End Class
Public MustInherit Class Scrapper
    Property Searchpossibility As Boolean
    Property Values As New List(Of Scrapper_Valuetype)
    Overridable Sub LoadInformations(ByVal s As Search_Result)
    End Sub
    Overridable Function Search(ByVal s As String) As List(Of Search_Result)
        Return Nothing
    End Function
    Overridable Function isLoaded(ByVal s As Search_Result) As Boolean
        Return Nothing
    End Function
    Overridable Function Helps(ByVal s As List(Of Scrapper_Valuetype)) As Boolean
        For Each x In s
            If Values.Contains(x) Then
                Return True
            End If
        Next
        Return False
    End Function
    Overridable Function fromIMDB(ByVal i As String) As Search_Result
        Return Nothing
    End Function
    Overridable Function Additional(ByVal i As Search_Result) As Search_Result
        Return Nothing
    End Function
    Overridable Function ConvertID(ByVal i As String) As String
        Return Nothing
    End Function
    Overridable Sub fromIMDB(ByVal i As Search_Result)

    End Sub



    Overridable Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As List(Of Scrapper_Valuetype) = Nothing) As Search_Result


        If additional Is Nothing Then Return source
        If Not additional.Titel = "" Then
            If source.Titel = "" Or master.Contains(Scrapper_Valuetype.Titel) Then
                source.Titel = additional.Titel
            End If
        End If
        If Not additional.imagelink = "" Then
            If source.imagelink = "" Then
                source.imagelink = additional.imagelink
            End If
        End If
        If Not additional.Originaltitel = "" Then
            If source.Originaltitel = "" Or master.Contains(Scrapper_Valuetype.Originaltitel) Then
                source.Originaltitel = additional.Originaltitel
            End If
        End If
        If Not additional.IMDB_ID = "" Then
            If source.IMDB_ID = "" Or master.Contains(Scrapper_Valuetype.IMDB_ID) Then
                source.IMDB_ID = additional.IMDB_ID
            End If
        End If
        If Not additional.Darsteller = "" Then
            If source.Darsteller = "" Or master.Contains(Scrapper_Valuetype.Darsteller) Then
                source.Darsteller = additional.Darsteller
            End If
        End If
        If Not additional.Regisseur = "" Then
            If source.Regisseur = "" Or master.Contains(Scrapper_Valuetype.Regisseur) Then
                source.Regisseur = additional.Regisseur
            End If
        End If
        If Not additional.Autoren = "" Then
            If source.Autoren = "" Or master.Contains(Scrapper_Valuetype.Autoren) Then
                source.Autoren = additional.Autoren
            End If
        End If
        If Not additional.Studios = "" Then
            If source.Studios = "" Or master.Contains(Scrapper_Valuetype.Studios) Then
                source.Studios = additional.Studios
            End If
        End If
        If Not additional.Produktionsjahr = "" Then
            If source.Produktionsjahr = "" Or master.Contains(Scrapper_Valuetype.Produktionsjahr) Then
                source.Produktionsjahr = additional.Produktionsjahr
            End If
        End If
        If Not additional.Produktionsland = "" Then
            If source.Produktionsland = "" Or master.Contains(Scrapper_Valuetype.Produktionsland) Then
                source.Produktionsland = additional.Produktionsland
            End If
        End If
        If Not additional.Genre = "" Then
            If source.Genre = "" Or master.Contains(Scrapper_Valuetype.Genre) Then
                source.Genre = additional.Genre
            End If
        End If
        If Not additional.FSK = "" Then
            If source.FSK = "" Or master.Contains(Scrapper_Valuetype.FSK) Then
                source.FSK = additional.FSK
            End If
        End If
        If Not additional.Bewertung = "" Then
            If source.Bewertung = "" Or master.Contains(Scrapper_Valuetype.Bewertung) Then
                source.Bewertung = additional.Bewertung
            End If
        End If
        If Not additional.Spieldauer = "" Then
            If source.Spieldauer = "" Or master.Contains(Scrapper_Valuetype.Spieldauer) Then
                source.Spieldauer = additional.Spieldauer
            End If
        End If
        If Not additional.Inhalt = "" Then
            If source.Inhalt = "" Or master.Contains(Scrapper_Valuetype.Inhalt) Then
                source.Inhalt = additional.Inhalt
            End If
        End If

        If Not additional.trailer = "" Then
            If source.trailer = "" Then
                source.trailer = additional.trailer
            End If
        End If
        Return source
    End Function
End Class
Public Class TMDB_Scrapper
    Inherits Scrapper
    Const apiKey As String = "5fe800e9f7891b9131c0059be62a36d0"
    Sub New()
        Values.Add(Scrapper_Valuetype.Titel)
        Values.Add(Scrapper_Valuetype.Originaltitel)
        Values.Add(Scrapper_Valuetype.IMDB_ID)
        Values.Add(Scrapper_Valuetype.Darsteller)
        Values.Add(Scrapper_Valuetype.Regisseur)
        Values.Add(Scrapper_Valuetype.Autoren)
        Values.Add(Scrapper_Valuetype.Studios)
        Values.Add(Scrapper_Valuetype.Produktionsjahr)
        Values.Add(Scrapper_Valuetype.Produktionsland)
        Values.Add(Scrapper_Valuetype.Genre)
        'Values.Add(Scrapper_Valuetype.FSK)
        Values.Add(Scrapper_Valuetype.Bewertung)
        Values.Add(Scrapper_Valuetype.Spieldauer)
        Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.tmdb_loaded
    End Function
    Public Function GetTMDbid(ByVal imdb As String) As String
        If imdb = "" Then
            Return ""

        End If
        Dim xml As XmlDocument ' Unser Document Container

        xml = New XmlDocument

        Try
            ' 'https://api.themoviedb.org/3/find/tt0903624?api_key=5fe800e9f7891b9131c0059be62a36d0&external_source=imdb_id
            xml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "find/" & imdb & "?api_key=" & apiKey & "&external_source=imdb_id", "tmdb3.find_de_" & imdb)
            ' xml.Load(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & imdb)
        Catch ex As Exception
            Return ""
        End Try
        Dim r As String = ""
        r = If(xml.SelectNodes("//id").Count > 0, xml.SelectSingleNode("//id").InnerText, "")
        Debug.WriteLine("TMDB_Convertiere ID " & imdb & "->" & r)
        Return r


    End Function
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.tmdb_id = "" Then
            r.tmdb_id = s.tmdb_id
            LoadInformations(r)
        ElseIf Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If
            Dim itm As String = GetTMDbid(s.IMDB_ID)
            If Not itm = "" Then
                r.tmdb_id = itm
                LoadInformations(r)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        Return r
    End Function
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        Try
            s.meta_loaded = True

            'Dim darstellercount As Integer = 0
            Dim nxml As Xml.XmlDocument
            nxml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "movie/" & s.tmdb_id & "?language=" & Einstellungen.UserAbrufen.tmdbapilanguage & "&api_key=" & Einstellungen.UserAbrufen.tmdbapiKey, "tmdb3.getinfo_de_" & s.tmdb_id)
            'nxml = MyFunctions.HttploadXML("http://ofdbgw.home-of-root.de/movie/" & s.id)
            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor

            s.Titel = If(nxml.SelectNodes("//title").Count > 0, nxml.SelectSingleNode("//title").InnerText, "")
            s.Sort = s.Titel
            's.FSK = If(nxml.SelectNodes("//certification").Count > 0, nxml.SelectSingleNode("//certification").InnerText, "")
            s.Originaltitel = If(nxml.SelectNodes("//original_title").Count > 0, nxml.SelectSingleNode("//original_title").InnerText, "")
            s.IMDB_ID = If(nxml.SelectNodes("//imdb_id").Count > 0, nxml.SelectSingleNode("//imdb_id").InnerText, "")
            s.Bewertung = If(nxml.SelectNodes("//vote_average").Count > 0, nxml.SelectSingleNode("//vote_average").InnerText, "")
            s.trailer = If(nxml.SelectNodes("//trailer").Count > 0, nxml.SelectSingleNode("//trailer").InnerText, "")

            s.Inhalt = If(nxml.SelectNodes("//overview").Count > 0, nxml.SelectSingleNode("//overview").InnerText, "")
            s.Kurzbeschreibung = s.Inhalt
            s.Produktionsjahr = If(nxml.SelectNodes("//release_date").Count > 0, nxml.SelectSingleNode("//release_date").InnerText, "")

            If s.Produktionsjahr.Length > 4 Then
                s.Produktionsjahr = s.Produktionsjahr.Substring(0, 4)
            End If
            xpath = "//genres"
            'GENRE
            Dim g As String = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)


                    If Not xmln.LastChild.InnerText = "" Then

                        If g = "" Then
                            g = xmln.LastChild.InnerText
                        Else
                            g &= ", " & xmln.LastChild.InnerText
                        End If
                    End If

                Next
            End If
            s.Genre = g

            xpath = "//production_countries"
            'LAND
            g = ""
            j = nxml.SelectNodes(xpath).Count

            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)


                    If Not xmln.FirstChild.InnerText = "" Then
                        Dim myRI1 As New Globalization.RegionInfo(xmln.FirstChild.InnerText)
                        If g = "" Then
                            g = myRI1.DisplayName
                        Else
                            g &= ", " & myRI1.DisplayName
                        End If
                    End If

                Next
            End If


            s.Produktionsland = g


            nxml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "movie/" & s.tmdb_id & "/credits?language=" & Einstellungen.UserAbrufen.tmdbapilanguage & "&api_key=" & Einstellungen.UserAbrufen.tmdbapiKey, "tmdb3.getcast_de_" & s.tmdb_id)
            xpath = "//cast"
            'LAND
            Dim author As String = ""
            Dim darsteller As String = ""
            Dim regisseur As String = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.ChildNodes.Count > 5 Then

                        If darsteller = "" Then
                            darsteller = xmln.SelectSingleNode("name").InnerText



                            '  darsteller = xmln.ChildNodes(1).InnerText
                        Else
                            darsteller &= ", " & xmln.SelectSingleNode("name").InnerText
                        End If
                        If Not xmln.ChildNodes(2).InnerText = "" Then
                            darsteller &= " [" & xmln.SelectSingleNode("character").InnerText.Replace(", ", " | ") & "]"
                        End If
                    End If


                Next
            End If


            xpath = "//crew"
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.ChildNodes.Count > 4 Then
                        If xmln.ChildNodes(3).InnerText = "Director" Then
                            If regisseur = "" Then
                                regisseur = xmln.ChildNodes(1).InnerText
                            Else
                                regisseur &= ", " & xmln.ChildNodes(1).InnerText
                            End If
                        ElseIf xmln.ChildNodes(3).InnerText = "Author" Then
                            If author = "" Then
                                author = xmln.ChildNodes(1).InnerText
                            Else
                                author &= ", " & xmln.ChildNodes(1).InnerText
                            End If
                        ElseIf xmln.ChildNodes(3).InnerText = "Editor" Then
                            If author = "" Then
                                author = xmln.ChildNodes(1).InnerText
                            Else
                                author &= ", " & xmln.ChildNodes(1).InnerText
                            End If
                        End If

                    End If


                Next
            End If



            s.Regisseur = regisseur
            s.Autoren = author
            s.Darsteller = darsteller
            ' Dokumentgruppe,Dokument,Datei,Pfad
            ' Container für unseren aktiven Knoten

            ' Für den Fall das wir mehrere Knoten haben auf die unser 


            'IMDb.GetInfos("tt" & result_IMDBID)

            s.tmdb_loaded = True
        Catch ex As Exception
            MsgBox("Fehler:" & vbCrLf & ex.Message & vbCrLf & "ID:", MsgBoxStyle.Exclamation)
            'isAbel = False

        End Try
    End Sub

    Public Function GetActorImages(ByVal i As String) As List(Of Search_Result)

    End Function


    Public Overrides Function Search(ByVal s As String) As List(Of Search_Result)
        Dim nxml As Xml.XmlDocument

        'http://api.themoviedb.org/3/search/movie?api_key=5fe800e9f7891b9131c0059be62a36d0&query=v%C3%B6g&search_type=ngram&language=de
        nxml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "search/movie?api_key=" & apiKey & "&search_type=ngram&language=de&" & "query=" & s, "tmdb3.search_de_" & s)

        ' nxml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.search/de/xml/" & apiKey & "/" & s, "tmdb.search_de_" & Renamer.CheckInvalid_F(s))
        If IsNothing(nxml) Then Return Nothing
        Dim xpath As String
        Dim j As Integer

        xpath = "//results"

        ' Dokumentgruppe,Dokument,Datei,Pfad
        ' Container für unseren aktiven Knoten

        ' Für den Fall das wir mehrere Knoten haben auf die unser 
        ' XPath zutrifft
        Dim results As New List(Of Search_Result)
        j = nxml.SelectNodes(xpath).Count
        If j > 0 Then
            For i As Integer = 0 To j - 1
                Dim xmln As Xml.XmlNode
                xmln = nxml.SelectNodes(xpath).Item(i)
                Dim cn As XmlNodeList = xmln.ChildNodes
                If cn.Count > 0 Then

                    Dim sr As New Search_Result


                    For y As Integer = 0 To cn.Count - 1
                        Select Case cn(y).Name
                            Case Is = "original_title"
                                sr.Originaltitel = cn(y).InnerText
                            Case Is = "title"
                                sr.Titel = cn(y).InnerText
                            Case Is = "release_date"
                                sr.Produktionsjahr = cn(y).InnerText
                                If sr.Produktionsjahr.Length > 4 Then
                                    sr.Produktionsjahr = sr.Produktionsjahr.Substring(0, 4)
                                End If
                            Case Is = "id"
                                sr.tmdb_id = cn(y).InnerText
                            Case Is = "poster_path"

                                sr.imagelink = Einstellungen.UserAbrufen.tmdbapibase_url & "w300" & cn(y).InnerText
                                If cn(y).HasChildNodes Then
                                    '  sr.imagelink = cn(y).FirstChild.Attributes("url").Value
                                End If


                        End Select
                    Next
                    sr.type = MetaProvider.tmdb
                    If Not sr.Titel = "" Then
                        results.Add(sr)
                    End If
                End If
            Next
        End If
        Return results
    End Function
    Public Overrides Function fromIMDB(ByVal i As String) As Search_Result

        If Not i = "" Then
            If Not i.Substring(0, 2) = "tt" Then
                i = "tt" & i

            End If
        Else
            Return Nothing
        End If
        Try

            Dim nxml As Xml.XmlDocument
            nxml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/de/xml/" & apiKey & "/" & i, "tmdb.imdbLookup_de_" & i)
            If IsNothing(nxml) Then Return Nothing
            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            xpath = "//movie"

            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                Dim xmln As Xml.XmlNode
                xmln = nxml.SelectSingleNode(xpath)
                Dim cn As XmlNodeList = xmln.ChildNodes
                If cn.Count > 0 Then
                    Dim sr As New Search_Result
                    For y As Integer = 0 To cn.Count - 1
                        Select Case cn(y).Name
                            Case Is = "original_name"
                                sr.Originaltitel = cn(y).InnerText
                            Case Is = "name"
                                sr.Titel = cn(y).InnerText
                            Case Is = "released"
                                sr.Produktionsjahr = cn(y).InnerText
                                If sr.Produktionsjahr.Length > 4 Then
                                    sr.Produktionsjahr = sr.Produktionsjahr.Substring(0, 4)
                                End If
                            Case Is = "id"
                                sr.tmdb_id = cn(y).InnerText
                            Case Is = "images"
                                If cn(y).HasChildNodes Then
                                    sr.imagelink = cn(y).FirstChild.Attributes("url").Value
                                End If
                        End Select
                    Next
                    sr.type = MetaProvider.Exact
                    sr.IMDB_ID = i
                    If Not sr.Titel = "" Then
                        Return sr
                    Else
                        Return Nothing
                    End If
                    '.Visible = cn("Zeigen").InnerText
                    '.Width = cn("Breite").InnerText
                    '.DisplayIndex = cn("Position").InnerText
                    '.HeaderText = cn("Name").InnerText
                Else
                    Return Nothing

                End If
                'xmln = nxml.SelectNodes(xpath).Item(i)
                'Dim stitel As String = If(xmln.SelectNodes("//titel").Count > 0, xmln.SelectSingleNode("//titel").InnerText, "")
                'Dim sotitel As String = If(xmln.SelectNodes("//original_name").Count > 0, xmln.SelectSingleNode("//original_name").InnerText, "")
                'Dim sid As String = If(xmln.SelectNodes("//id").Count > 0, xmln.SelectSingleNode("//id").InnerText, "")
                'Dim sjahr As String = If(xmln.SelectNodes("//jahr").Count > 0, xmln.SelectSingleNode("//jahr").InnerText, "")

                'Dim sr As Search_Result = New Search_Result(stitel, sotitel, sid, sjahr, 0)

                'sr.IMDB_ID = If(xmln.SelectNodes("//imdb_id").Count > 0, xmln.SelectSingleNode("//imdb_id").InnerText, "")
                'sr.Kurzbeschreibung = If(xmln.SelectNodes("//overview").Count > 0, xmln.SelectSingleNode("//overview").InnerText, "")
                'sr.meta_loaded = True

                'Dialog_OnlineSuche.results.Add(sr)
            Else
                Return Nothing

            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Overrides Sub fromIMDB(ByVal s As Search_Result)
        If Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If
            Dim itm As String = GetTMDbid(s.IMDB_ID)
            If Not itm = "" Then
                s.tmdb_id = itm
                LoadInformations(s)
            End If
        Else
            Exit Sub
        End If

    End Sub
    Public Overrides Function ConvertID(ByVal imdb As String) As String
        If imdb = "" Then
            Return ""
        End If
        Dim xml As XmlDocument ' Unser Document Container

        xml = New XmlDocument

        Try
            xml.Load(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/en/xml/" & apiKey & "/" & imdb)
        Catch ex As Exception
            Return ""
        End Try
        Dim r As String = ""
        r = If(xml.SelectNodes("//id").Count > 0, xml.SelectSingleNode("//id").InnerText, "")
        Return r


    End Function
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_TMDB_dominant_ScrapperValues
        master.Clear()
        If Einstellungen.Config_Genre.Genre_tmdbdownload = True Then
            master.Add(Scrapper_Valuetype.Genre)
        End If
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class OFDb_Scrapper
    Inherits Scrapper

    Dim root As String = Einstellungen.UserAbrufen.ofdbgwroot

    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.ofdb_loaded
    End Function
    Sub New()
        Values.Add(Scrapper_Valuetype.Titel)
        Values.Add(Scrapper_Valuetype.Originaltitel)
        Values.Add(Scrapper_Valuetype.IMDB_ID)
        Values.Add(Scrapper_Valuetype.Darsteller)
        Values.Add(Scrapper_Valuetype.Regisseur)
        'Values.Add(Scrapper_Valuetype.Autoren)
        'Values.Add(Scrapper_Valuetype.Studios)
        Values.Add(Scrapper_Valuetype.Produktionsjahr)
        Values.Add(Scrapper_Valuetype.Produktionsland)
        Values.Add(Scrapper_Valuetype.Genre)
        'Values.Add(Scrapper_Valuetype.FSK)
        Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Public Overrides Sub fromIMDB(ByVal s As Search_Result)
        If Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If
            Dim itm As String = GetIMDB(s.IMDB_ID)
            If Not itm = "" Then
                s.ofdb_id = itm
                LoadInformations(s)
            End If
        Else
            Exit Sub
        End If

    End Sub
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.ofdb_id = "" Then
            r.ofdb_id = s.ofdb_id
            LoadInformations(r)
        ElseIf Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If
            Dim itm As String = GetIMDB(s.IMDB_ID)
            If Not itm = "" Then
                r.ofdb_id = itm
                LoadInformations(r)
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
        Return r
    End Function
    Public Function GetIMDB(ByVal i As String) As String
        If Not i = "" Then
            If Not i.Substring(0, 2) = "tt" Then
                i = "tt" & i
            End If
        Else
            Return Nothing
        End If

        Try
            Dim nxml As Xml.XmlDocument
            nxml = MyFunctions.HttploadXML(root & "imdb2ofdb/" & i, "ofdb.imdbLookup_de_" & i)
            If nxml Is Nothing Then Return Nothing
            Dim id As String = If(nxml.SelectNodes("//ofdbid").Count > 0, nxml.SelectSingleNode("//ofdbid").InnerText, "")


            Return id

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Overrides Function ConvertID(ByVal i As String) As String
        If Not i = "" Then
            If Not i.Substring(0, 2) = "tt" Then
                i = "tt" & i
            End If
        Else
            Return Nothing
        End If
        Try
            Dim nxml As Xml.XmlDocument
            nxml = MyFunctions.HttploadXML(root & "imdb2ofdb/" & i, "ofdb.imdbLookup_de_" & i)
            If nxml Is Nothing Then Return Nothing
            Return If(nxml.SelectNodes("//ofdbid").Count > 0, nxml.SelectSingleNode("//ofdbid").InnerText, "")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Overrides Function fromIMDB(ByVal i As String) As Search_Result
        If Not i = "" Then
            If Not i.Substring(0, 2) = "tt" Then
                i = "tt" & i
            End If
        Else
            Return Nothing
        End If

        Try
            Dim nxml As Xml.XmlDocument
            nxml = MyFunctions.HttploadXML(root & "imdb2ofdb/" & i, "ofdb.imdbLookup_de_" & i)
            If nxml Is Nothing Then Return Nothing
            Dim result As New Search_Result
            result.Titel = If(nxml.SelectNodes("//titel").Count > 0, nxml.SelectSingleNode("//titel").InnerText, "")
            'result.Originaltitel = result.Titel
            'result.Sort = result.Titel
            If result.Titel.Contains("(") Then
                Dim ink As Integer = result.Titel.Length
                If result.Titel.IndexOf("(") + 1 + 4 <= ink Then
                    result.Produktionsjahr = result.Titel.Substring(result.Titel.IndexOf("(") + 1, 4)
                End If
            End If
            result.Titel = result.Titel.Substring(0, result.Titel.IndexOf("/")).Trim
            result.ofdb_id = If(nxml.SelectNodes("//ofdbid").Count > 0, nxml.SelectSingleNode("//ofdbid").InnerText, "")
            result.IMDB_ID = i
            result.type = MetaProvider.Exact
            Return result

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        Try
            If s.ofdb_id = "" Then
                Return
            End If




            s.meta_loaded = True

            'Dim darstellercount As Integer = 0
            Dim nxml As Xml.XmlDocument
            'nxml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.getInfo/de/xml/5fe800e9f7891b9131c0059be62a36d0/" & s.id)
            nxml = MyFunctions.HttploadXML(root & "movie/" & s.ofdb_id, "ofdb.getInfo_de_" & s.ofdb_id)
            If nxml Is Nothing Then
                s.meta_loaded = False
                Return
            End If
            'nxml.Save("D:\test.xml")

            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            'Dim trans As Boolean = Einstellungen.toBool(If(nxml.SelectNodes("//translated").Count > 0, nxml.SelectSingleNode("//translated").InnerText, ""), True)

            s.Titel = If(nxml.SelectNodes("//titel").Count > 0, nxml.SelectSingleNode("//titel").InnerText, "")
            s.Sort = s.Titel
            s.Originaltitel = If(nxml.SelectNodes("//alternativ").Count > 0, nxml.SelectSingleNode("//alternativ").InnerText, "")
            s.IMDB_ID = If(nxml.SelectNodes("//imdbid").Count > 0, nxml.SelectSingleNode("//imdbid").InnerText, "")
            If Not s.IMDB_ID = "" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If
            s.Bewertung = If(nxml.SelectNodes("//note").Count > 0, nxml.SelectSingleNode("//note").InnerText, "")
            s.Inhalt = If(nxml.SelectNodes("//beschreibung").Count > 0, nxml.SelectSingleNode("//beschreibung").InnerText, "")
            s.Kurzbeschreibung = s.Inhalt
            s.imagelink = If(nxml.SelectNodes("//bild").Count > 0, nxml.SelectSingleNode("//bild").InnerText, "")


            xpath = "//genre"
            'GENRE
            Dim g As String = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.HasChildNodes Then
                        For y As Integer = 0 To xmln.ChildNodes.Count - 1
                            If g = "" Then
                                g = xmln.ChildNodes(y).InnerText
                            Else
                                g &= ", " & xmln.ChildNodes(y).InnerText
                            End If
                        Next
                    End If
                Next
            End If
            s.Genre = g

            xpath = "//produktionsland"
            'LAND
            g = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.HasChildNodes Then
                        For y As Integer = 0 To xmln.ChildNodes.Count - 1
                            If g = "" Then
                                g = xmln.ChildNodes(y).InnerText
                            Else
                                g &= ", " & xmln.ChildNodes(y).InnerText
                            End If
                        Next
                    End If
                Next
            End If
            s.Produktionsland = g


            xpath = "//regie"
            g = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.HasChildNodes Then
                        For y As Integer = 0 To xmln.ChildNodes.Count - 1
                            If xmln.ChildNodes(y).HasChildNodes Then
                                For yz As Integer = 0 To xmln.ChildNodes(y).ChildNodes.Count - 1
                                    If xmln.ChildNodes(y).ChildNodes(yz).Name = "name" Then
                                        If g = "" Then
                                            g = xmln.ChildNodes(y).ChildNodes(yz).InnerText
                                        Else
                                            g &= ", " & xmln.ChildNodes(y).ChildNodes(yz).InnerText
                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
            s.Regisseur = g
            's.Autoren = g

            'LAND

            xpath = "//besetzung"
            g = ""
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.HasChildNodes Then
                        For y As Integer = 0 To xmln.ChildNodes.Count - 1
                            If xmln.ChildNodes(y).HasChildNodes Then
                                For yz As Integer = 0 To xmln.ChildNodes(y).ChildNodes.Count - 1
                                    If xmln.ChildNodes(y).ChildNodes(yz).Name = "name" Then
                                        If g = "" Then
                                            g = xmln.ChildNodes(y).ChildNodes(yz).InnerText
                                        Else
                                            g &= ", " & xmln.ChildNodes(y).ChildNodes(yz).InnerText
                                        End If
                                    ElseIf xmln.ChildNodes(y).ChildNodes(yz).Name = "rolle" Then
                                        Dim var As String = Trim(xmln.ChildNodes(y).ChildNodes(yz).InnerText)
                                        If Not var = "" And Not var = " " And Not var = "..." Then
                                            g &= " [" & var.Replace(",", " |").Replace("...", "") & "]"

                                        End If
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If

            s.ofdb_loaded = True
            s.Darsteller = g
        Catch ex As Exception
            MsgBox("Fehler:" & vbCrLf & ex.Message & vbCrLf & "ID:" & s.ofdb_id, MsgBoxStyle.Exclamation)
            '  isAbel = False

        End Try

    End Sub
    Public Overrides Function Search(ByVal s As String) As List(Of Search_Result)
        Dim nxml As Xml.XmlDocument
        's = WebFunctions.DecodeHTML(s)

        nxml = MyFunctions.HttploadXML(root & "search/" & s, "ofdb.search_de_" & Renamer.CheckInvalid_F(s))
        If IsNothing(nxml) Then Return Nothing
        Dim xpath As String
        Dim j As Integer



        xpath = "//eintrag"


        Dim results As New List(Of Search_Result)
        j = nxml.SelectNodes(xpath).Count
        If j > 0 Then
            For i As Integer = 0 To j - 1
                Dim xmln As Xml.XmlNode
                xmln = nxml.SelectNodes(xpath).Item(i)
                Dim cn As XmlNodeList = xmln.ChildNodes
                If cn.Count > 0 Then

                    Dim sr As New Search_Result


                    For y As Integer = 0 To cn.Count - 1
                        Select Case cn(y).Name
                            Case Is = "titel_orig"
                                sr.Originaltitel = cn(y).InnerText
                            Case Is = "titel"
                                sr.Titel = cn(y).InnerText
                            Case Is = "jahr"
                                sr.Produktionsjahr = cn(y).InnerText
                            Case Is = "id"
                                sr.ofdb_id = cn(y).InnerText
                        End Select
                    Next
                    sr.type = MetaProvider.OFDB
                    If Not sr.Titel = "" Then
                        results.Add(sr)
                    End If
                End If
            Next
        End If
        Return results
    End Function
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_OFDb_dominant_ScrapperValues
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class IMDb_Scrapper_Search
    Inherits Scrapper



    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.ofdb_loaded
    End Function
    Sub New()
        Values.Add(Scrapper_Valuetype.Titel)
        'Values.Add(Scrapper_Valuetype.Originaltitel)
        Values.Add(Scrapper_Valuetype.IMDB_ID)
        'Values.Add(Scrapper_Valuetype.Darsteller)
        Values.Add(Scrapper_Valuetype.Regisseur)
        'Values.Add(Scrapper_Valuetype.Autoren)
        'Values.Add(Scrapper_Valuetype.Studios)
        Values.Add(Scrapper_Valuetype.Produktionsjahr)
        ' Values.Add(Scrapper_Valuetype.Produktionsland)
        Values.Add(Scrapper_Valuetype.Genre)
        'Values.Add(Scrapper_Valuetype.FSK)
        Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        'Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Public Overrides Sub fromIMDB(ByVal s As Search_Result)
        If Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If


            LoadInformations(s)
        End If

        Exit Sub


    End Sub
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.ofdb_id = "" Then
            r.ofdb_id = s.ofdb_id
            LoadInformations(r)
        ElseIf Not s.IMDB_ID = "" Then
            If Not s.IMDB_ID.Substring(0, 2) = "tt" Then
                s.IMDB_ID = "tt" & s.IMDB_ID
            End If

            r.IMDB_ID = s.IMDB_ID
            LoadInformations(r)
        Else
            Return Nothing
        End If

        Return r
    End Function


    'Public Overrides Function fromIMDB(ByVal i As String) As Search_Result
    '    If Not i = "" Then
    '        If Not i.Substring(0, 2) = "tt" Then
    '            i = "tt" & i
    '        End If
    '    Else
    '        Return Nothing
    '    End If

    '    Try
    '        Dim nxml As Xml.XmlDocument
    '        nxml = MyFunctions.HttploadXML(root & "imdb2ofdb/" & i, "ofdb.imdbLookup_de_" & i)
    '        If nxml Is Nothing Then Return Nothing
    '        Dim result As New Search_Result
    '        result.Titel = If(nxml.SelectNodes("//titel").Count > 0, nxml.SelectSingleNode("//titel").InnerText, "")
    '        'result.Originaltitel = result.Titel
    '        'result.Sort = result.Titel
    '        If result.Titel.Contains("(") Then
    '            Dim ink As Integer = result.Titel.Length
    '            If result.Titel.IndexOf("(") + 1 + 4 <= ink Then
    '                result.Produktionsjahr = result.Titel.Substring(result.Titel.IndexOf("(") + 1, 4)
    '            End If
    '        End If
    '        result.Titel = result.Titel.Substring(0, result.Titel.IndexOf("/")).Trim
    '        result.ofdb_id = If(nxml.SelectNodes("//ofdbid").Count > 0, nxml.SelectSingleNode("//ofdbid").InnerText, "")
    '        result.IMDB_ID = i
    '        result.type = MetaProvider.Exact
    '        Return result

    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    'End Function
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        Try

            If s.IMDB_ID = "" Then
                Return
            End If


            s.meta_loaded = True

            'Dim darstellercount As Integer = 0
            Dim nxml As Xml.XmlDocument
            'nxml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.getInfo/de/xml/5fe800e9f7891b9131c0059be62a36d0/" & s.id)
            nxml = MyFunctions.HttploadXML("http://www.omdbapi.com/?i=" & s.IMDB_ID & "&r=XML", "imdb.getInfo_en_" & s.IMDB_ID)
            If nxml Is Nothing Then
                s.meta_loaded = False
                Return
            End If
            'nxml.Save("D:\test.xml")

            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            'Dim trans As Boolean = Einstellungen.toBool(If(nxml.SelectNodes("//translated").Count > 0, nxml.SelectSingleNode("//translated").InnerText, ""), True)

            Dim n As XmlNode = nxml.SelectSingleNode("//movie")
            s.Titel = n.Attributes("title").Value
            s.Sort = s.Titel
            s.Produktionsjahr = n.Attributes("year").Value
            s.Bewertung = n.Attributes("imdbRating").Value
            s.imagelink = n.Attributes("poster").Value
            s.Regisseur = n.Attributes("director").Value
            s.Autoren = n.Attributes("writer").Value
            s.Genre = n.Attributes("genre").Value



        Catch ex As Exception
            MsgBox("Fehler:" & vbCrLf & ex.Message & vbCrLf & "ID:" & s.ofdb_id, MsgBoxStyle.Exclamation)
            '  isAbel = False

        End Try

    End Sub
    Public Overrides Function Search(ByVal s As String) As List(Of Search_Result)
        Dim nxml As Xml.XmlDocument
        's = WebFunctions.DecodeHTML(s)

        nxml = MyFunctions.HttploadXML("http://www.omdbapi.com/?s=" & s & "&r=XML", "imdb.search_en_" & Renamer.CheckInvalid_F(s))
        If IsNothing(nxml) Then Return Nothing
        Dim xpath As String
        Dim j As Integer



        xpath = "//Movie"


        Dim results As New List(Of Search_Result)
        j = nxml.SelectNodes(xpath).Count
        If j > 0 Then
            For i As Integer = 0 To j - 1
                Dim xmln As Xml.XmlNode
                xmln = nxml.SelectNodes(xpath).Item(i)
                If xmln.Attributes("Type").Value = "movie" Then



                    Dim sr As New Search_Result

                    sr.Titel = xmln.Attributes("Title").Value
                    sr.Produktionsjahr = xmln.Attributes("Year").Value
                    sr.IMDB_ID = xmln.Attributes("imdbID").Value
                    sr.type = MetaProvider.IMDb


                    If Not sr.Titel = "" Then
                        results.Add(sr)
                    End If
                End If
            Next
        End If
        Return results
    End Function
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_OFDb_dominant_ScrapperValues
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class MoviePilot_Scrapper
    Inherits Scrapper
    Const apiKey As String = "0c31f8afe1f218698a4c1ebb6b921c"
    Shadows Searchpossibility As Boolean = False
    Sub New()
        'Values.Add(Scrapper_Valuetype.Titel)
        'Values.Add(Scrapper_Valuetype.Originaltitel)
        'Values.Add(Scrapper_Valuetype.IMDB_ID)
        'Values.Add(Scrapper_Valuetype.Darsteller)
        'Values.Add(Scrapper_Valuetype.Regisseur)
        ''Values.Add(Scrapper_Valuetype.Autoren)
        ''Values.Add(Scrapper_Valuetype.Studios)
        'Values.Add(Scrapper_Valuetype.Produktionsjahr)
        'Values.Add(Scrapper_Valuetype.Produktionsland)
        'Values.Add(Scrapper_Valuetype.Genre)
        ''Values.Add(Scrapper_Valuetype.FSK)
        'Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        If s.Inhalt = "" Then
            s.Inhalt = MetaSource_Moviepilot.GetPlot(s.IMDB_ID)

        End If
    End Sub
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.IMDB_ID = "" Then
            r.IMDB_ID = s.IMDB_ID
            LoadInformations(r)
        Else
            Return Nothing
        End If
        Return r
    End Function
    'Public Overrides Function Search(ByVal s As String) As List(Of Search_Result)
    '    Dim nxml As Xml.XmlDocument
    '    nxml = MyFunctions.HttploadXML("http://ofdbgw.home-of-root.de/search/" & s)
    '    If IsNothing(nxml) Then Return Nothing
    '    Dim xpath As String
    '    Dim j As Integer

    '    xpath = "//eintrag"

    '    ' Dokumentgruppe,Dokument,Datei,Pfad
    '    ' Container für unseren aktiven Knoten

    '    ' Für den Fall das wir mehrere Knoten haben auf die unser 
    '    ' XPath zutrifft
    '    Dim results As New List(Of Search_Result)
    '    j = nxml.SelectNodes(xpath).Count
    '    If j > 0 Then
    '        For i As Integer = 0 To j - 1
    '            Dim xmln As Xml.XmlNode
    '            xmln = nxml.SelectNodes(xpath).Item(i)
    '            Dim cn As XmlNodeList = xmln.ChildNodes
    '            If cn.Count > 0 Then

    '                Dim sr As New Search_Result


    '                For y As Integer = 0 To cn.Count - 1
    '                    Select Case cn(y).Name
    '                        Case Is = "titel_orig"
    '                            sr.Originaltitel = cn(y).InnerText
    '                        Case Is = "titel"
    '                            sr.Titel = cn(y).InnerText
    '                        Case Is = "jahr"
    '                            sr.Produktionsjahr = cn(y).InnerText
    '                        Case Is = "id"
    '                            sr.id = cn(y).InnerText
    '                    End Select
    '                Next
    '                sr.type = MetaProvider.OFDB
    '                If Not sr.Titel = "" Then
    '                    results.Add(sr)
    '                End If
    '            End If
    '        Next
    '    End If
    '    Return results
    'End Function
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_MoPi_dominant_ScrapperValues
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class IMDB_Scrapper
    Inherits Scrapper
    Sub New()
        'Values.Add(Scrapper_Valuetype.Titel)
        'Values.Add(Scrapper_Valuetype.Originaltitel)
        'Values.Add(Scrapper_Valuetype.IMDB_ID)
        'Values.Add(Scrapper_Valuetype.Darsteller)
        'Values.Add(Scrapper_Valuetype.Regisseur)
        Values.Add(Scrapper_Valuetype.Autoren)
        Values.Add(Scrapper_Valuetype.Studios)
        'Values.Add(Scrapper_Valuetype.Produktionsjahr)
        'Values.Add(Scrapper_Valuetype.Produktionsland)
        'Values.Add(Scrapper_Valuetype.Genre)
        '   Values.Add(Scrapper_Valuetype.FSK)
        '  Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        'Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Shadows Searchpossibility As Boolean = False
    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.imdb_loaded
    End Function
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.IMDB_ID = "" Then
            r.IMDB_ID = s.IMDB_ID
            LoadInformations(r)
        Else
            Return Nothing
        End If
        Return r
    End Function
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        s.imdb_loaded = True
        Try
            If s.IMDB_ID = "" Or s.IMDB_ID = "tt" Then
            Else
                If Not s.IMDB_ID.ToString.StartsWith("tt") Then
                    s.IMDB_ID = "tt" & s.IMDB_ID
                End If



                'Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create("http://www.imdb.de/title/" & s.IMDB_ID & "/"), Net.HttpWebRequest)
                'Dim httpResponse As Net.HttpWebResponse
                'httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
                'Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)
                Dim httptext As String = ""
                httptext = MyFunctions.HttploadText("http://www.imdb.com/title/" & s.IMDB_ID & "/", "imdb.getInfo_de_" & s.IMDB_ID)
                If httptext Is Nothing Then httptext = ""
                Dim Autor As String = ""
                Dim Firma As String = ""
                Dim FSK As String = ""
                Dim Bewertung As String = ""
                httptext = httptext.Replace(vbCrLf, "").Replace(vbLf, "")
                ' httptext = WebFunctions.EncodeUTF(httptext)
                'Dann mal los mit FSK





                'autor
                Dim wirtermatch1 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "Writers:</h4>(.*?)(?=</div>)", System.Text.RegularExpressions.RegexOptions.Multiline)
                If wirtermatch1.Success = True Then
                    ' Dim match2 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(match.Groups(1).Value, "<a href=""[^""]*"">([^<]*)</a>")
                    Dim match2 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(wirtermatch1.Groups(1).Value, "<span class=""itemprop"" itemprop=""name"">(.*?)(?=</span>)")
                    If match2.Success Then
                        Autor = Trim(match2.Groups(1).Value)
                    End If
                End If

                'Produktionsfirma:  (Funktioniert Stand: 24.02.13)


                Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "Production Co:</h4>(.*?)(?=</div>)", System.Text.RegularExpressions.RegexOptions.Multiline)
                If match.Success = True Then
                    ' Dim match2 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(match.Groups(1).Value, "<a href=""[^""]*"">([^<]*)</a>")
                    Dim match2 As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(match.Groups(1).Value, "<span class=""itemprop"" itemprop=""name"">(.*?)(?=</span>)")
                    If match2.Success Then
                        Firma = Trim(match2.Groups(1).Value)
                    End If
                End If



                'Rating fixed
                Dim pat As String = "<span itemprop=""ratingValue"">(.*?)(?=</span>)"
                Dim Ratingmatch As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext.Replace(vbCrLf, "").Replace(vbLf, ""), pat, System.Text.RegularExpressions.RegexOptions.Multiline)
                If Ratingmatch.Success = True Then
                    Bewertung = Trim(Ratingmatch.Groups(1).Value)
                End If



                If s.Bewertung = "" Then
                    s.Bewertung = Bewertung.Replace(",", ".")
                End If



     
                'Daten.arr(12, iarr) = FSK


                If s.Studios = "" Then
                    s.Studios = Firma
                End If

                'Daten.arr(8, iarr) = Firma

                If s.Autoren = "" Then
                    s.Autoren = Autor.Replace(", Mehr ansehen", "")
                    If s.Autoren = "" Then
                        s.Autoren = s.Regisseur
                    End If
                End If

                'Daten.arr(7, iarr) = Autor



            End If
        Catch ex As Exception
            MsgBox("Es ist ein Fehler aufgetreten beim Laden der Informationen von IMDb.de" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Fehler")

        End Try
    End Sub
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_IMDB_dominant_ScrapperValues
        master.Clear()
        master.Add(Scrapper_Valuetype.Bewertung)
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class Zell_Scrapper
    Inherits Scrapper
    Sub New()
        'Values.Add(Scrapper_Valuetype.Titel)
        'Values.Add(Scrapper_Valuetype.Originaltitel)
        'Values.Add(Scrapper_Valuetype.IMDB_ID)
        'Values.Add(Scrapper_Valuetype.Darsteller)
        'Values.Add(Scrapper_Valuetype.Regisseur)
        'Values.Add(Scrapper_Valuetype.Autoren)
        'Values.Add(Scrapper_Valuetype.Studios)
        'Values.Add(Scrapper_Valuetype.Produktionsjahr)
        'Values.Add(Scrapper_Valuetype.Produktionsland)
        'Values.Add(Scrapper_Valuetype.Genre)
        Values.Add(Scrapper_Valuetype.FSK)
        'Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        'Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Shadows Searchpossibility As Boolean = False
    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.imdb_loaded
    End Function
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.IMDB_ID = "" Then
            Dim id As String = MetaSource_Moviepilot.GetZID(s.IMDB_ID)
            If Not id = "" Then
                r.zell_id = id
                LoadInformations(r)
            End If
            'r.IMDB_ID = s.IMDB_ID
            '
        Else
            Return Nothing
        End If
        Return r
    End Function
    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        s.imdb_loaded = True
        Try
            If Not s.zell_id = "" Then

                Dim httptext As String = ""
                httptext = MyFunctions.HttploadText("http://www.zelluloid.de/filme/index.php3?id=" & s.zell_id, "zell.getInfo_de_" & s.zell_id)
                If httptext Is Nothing Then httptext = ""

                Dim Autor As String = ""
                Dim Firma As String = ""
                Dim FSK As String = ""

                ''Finden!
                Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "<BR>FSK:([^<]*)")
                'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                If match.Success = True Then
                    FSK = match.Groups(1).Value

                End If



                With FSK
                    Select Case True
                        Case .Contains("18")
                            FSK = CStr(18)
                        Case .Contains("16")
                            FSK = CStr(16)
                        Case .Contains("12")
                            FSK = CStr(12)
                        Case .Contains("6")
                            FSK = CStr(6)
                        Case .Contains("0")
                            FSK = CStr(0)
                        Case .Contains("ohne")
                            FSK = CStr(0)
                    End Select
                End With



                'Dann mal los mit FSK


                If s.FSK = "" Then
                    s.FSK = FSK
                End If

                'Daten.arr(12, iarr) = FSK


                'If s.Studios = "" Then
                '    s.Studios = Firma
                'End If

                ''Daten.arr(8, iarr) = Firma

                'If s.Autoren = "" Then
                '    s.Autoren = Autor.Replace(", Mehr ansehen", "")
                '    If s.Autoren = "" Then
                '        s.Autoren = s.Regisseur
                '    End If
                'End If

                'Daten.arr(7, iarr) = Autor



            End If
        Catch ex As Exception
            MsgBox("Es ist ein Fehler aufgetreten beim Laden der Informationen von IMDb.de" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Fehler")

        End Try
    End Sub
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_TMDB_dominant_ScrapperValues
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class xRel_Scrapper
    Inherits Scrapper
    Sub New()
        'Values.Add(Scrapper_Valuetype.Titel)
        'Values.Add(Scrapper_Valuetype.Originaltitel)
        'Values.Add(Scrapper_Valuetype.IMDB_ID)
        'Values.Add(Scrapper_Valuetype.Darsteller)
        'Values.Add(Scrapper_Valuetype.Regisseur)
        'Values.Add(Scrapper_Valuetype.Autoren)
        'Values.Add(Scrapper_Valuetype.Studios)
        Values.Add(Scrapper_Valuetype.Produktionsjahr)
        Values.Add(Scrapper_Valuetype.Produktionsland)
        'Values.Add(Scrapper_Valuetype.Genre)
        Values.Add(Scrapper_Valuetype.FSK)
        'Values.Add(Scrapper_Valuetype.Bewertung)
        'Values.Add(Scrapper_Valuetype.Spieldauer)
        Values.Add(Scrapper_Valuetype.Inhalt)
    End Sub
    Shadows Searchpossibility As Boolean = False
    Public Overrides Function isLoaded(ByVal s As Search_Result) As Boolean
        Return s.imdb_loaded
    End Function
    Public Overrides Function Additional(ByVal s As Search_Result) As Search_Result
        Dim r As New Search_Result
        If Not s.IMDB_ID = "" Then
            Dim id As String = xRelIDProvider.GetxRelLink(s.IMDB_ID)

            If Not id = "" Then
                r.IMDB_ID = s.IMDB_ID
                r.xRel_link = id
                LoadInformations(r)
            End If

        Else
            Return Nothing
        End If
        Return r
    End Function

    Public Overrides Sub LoadInformations(ByVal s As Search_Result)
        s.imdb_loaded = True
        Try
            If Not s.xRel_link = "" Then

                Dim httptext As String = ""
                httptext = MyFunctions.HttploadText(s.xRel_link, "xRel.getInfo_de_" & s.IMDB_ID)
                If httptext Is Nothing Then httptext = ""
                httptext = httptext.Replace(vbCrLf, "").Replace(vbLf, "")

                Dim FSK As String = ""
                Dim Land As String = ""
                Dim Jahr As String = ""
                Dim Inhalt As String = ""
                'FSK
                Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "Freigegeben ab \(Jahre\):</div> <div class=""l_right"">(.*?)(?=</div>)")
                'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                If match.Success = True Then
                    FSK = match.Groups(1).Value
                    With FSK
                        Select Case True
                            Case .Contains("18")
                                FSK = CStr(18)
                            Case .Contains("16")
                                FSK = CStr(16)
                            Case .Contains("12")
                                FSK = CStr(12)
                            Case .Contains("6")
                                FSK = CStr(6)
                            Case .Contains("0")
                                FSK = CStr(0)
                            Case .Contains("ohne")
                                FSK = CStr(0)
                        End Select
                    End With
                End If


                'Land

                match = System.Text.RegularExpressions.Regex.Match(httptext, "Produktion:</div> <div class=""l_right"">(.*?)(?=\d)")
                'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                If match.Success = True Then
                    Land = match.Groups(1).Value
                End If


                'Jahr

                match = System.Text.RegularExpressions.Regex.Match(httptext, "Produktion:</div> <div class=""l_right"">.*?(\d*?)(?=</div>)")
                'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                If match.Success = True Then
                    Jahr = match.Groups(1).Value
                End If



                'Inhalt
                match = System.Text.RegularExpressions.Regex.Match(httptext, "<div class=""article_text"".[^<]*>\s(.*?)(?=</div>)", System.Text.RegularExpressions.RegexOptions.Multiline)
                'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                If match.Success = True Then
                    Inhalt = match.Groups(1).Value
                End If
                Dim m As New System.Text.RegularExpressions.Regex("<a href=""[^""]*?"">(.*?)</a>")
                Inhalt = m.Replace(Inhalt, "$1")
                Inhalt = WebFunctions.EncodeUTF(Inhalt)
                Inhalt = Inhalt.Replace("<br>", "")




                If s.FSK = "" Then
                    s.FSK = FSK
                End If
                If s.Produktionsland = "" Then
                    s.Produktionsland = Land
                End If
                If s.Produktionsjahr = "" Then
                    s.Produktionsjahr = Jahr
                End If
                If s.Inhalt = "" Then
                    s.Inhalt = Inhalt
                End If

            End If
        Catch ex As Exception
            MsgBox("Es ist ein Fehler aufgetreten beim Laden der Informationen von IMDb.de" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, MsgBoxStyle.Exclamation, "Fehler")

        End Try
    End Sub
    Public Overrides Function Combine(ByVal source As Search_Result, ByVal additional As Search_Result, Optional ByVal master As System.Collections.Generic.List(Of Scrapper_Valuetype) = Nothing) As Search_Result
        master = Einstellungen.Config_Scrapper.Scrapper_TMDB_dominant_ScrapperValues
        Return MyBase.Combine(source, additional, master)
    End Function
End Class
Public Class TrailerLoader

    Class TrailerResult
        Property displayTitle As String
        Property Title As String
        Property lng As String = ""
        Property Files As New List(Of TrailerFile)

    End Class

    Class TrailerFile
        Property URL As String
        Property Qualityi As Integer
        Property Quality As TrailerQuality
        Sub New(ByVal q As TrailerQuality, ByVal u As String, Optional ByVal i As Integer = 0)
            URL = u
            Quality = q
            Qualityi = i
        End Sub
    End Class
    Enum TrailerQuality
        NoQ
        SD240
        SD360
        HD720
        HD1080
    End Enum
    Enum TrailerSource
        Youtube
        MovieMaze
    End Enum
    Property Type As TrailerSource
''' <summary>
''' Ergebnis der URL analyse einzelne TrailerFiles mit unterschiedlichen Qualis
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    Property Result() As New List(Of TrailerResult)
Property URL As String = ""
    Public hptext As String = ""
    Public mid As String = ""
''' <summary>
''' Ein neuen Trailer suchen für die gegebene URL (Youtube) MM folgt
''' Analysiert automatisch
''' </summary>
''' <param name="u">URL mit "http:// und /watch keine Playlisten glab ich :D</param>
''' <remarks>Gibt keinen Fehler sondern Nothing zurückt</remarks>
    Sub New(ByVal u As String, Optional ByVal ID As String = "")
        URL = u
        mid = ID
        If URL.StartsWith("http://www.youtube.com/") Then
            Type = TrailerSource.Youtube
            AnalyseYT()
        ElseIf URL.StartsWith("http://www.moviemaze.de/") Then
            Type = TrailerSource.MovieMaze
            AnalyseMM()
        End If
    End Sub


Private Sub AnalyseYT()
        'Dim httptext As String = ""



        'If httptext = "" Then

        '    Try


        '        Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(URL), Net.HttpWebRequest)
        '        Dim httpResponse As Net.HttpWebResponse
        '        httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
        '        Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)

        '        httptext = reader.ReadToEnd
        '        httpResponse.Close()
        '    Catch ex As Exception

        '    End Try
        'End If
        'If httptext = "" Then
        '    Exit Sub
        'End If



        'Dim text As String = ""


        'Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "url_encoded_fmt_stream_map=([^&]*)&amp")
        'If match.Success = True Then
        '    text = match.Groups(1).Value
        'End If

        'text = WebFunctions.URLDecode(text)
        'Dim arr() As String = Split(text, ",")
        'Dim fi As New TrailerResult
        'fi.Title = "Youtube Trailer"
        'For Each s In arr




        '    Dim q As TrailerQuality = TrailerQuality.NoQ
        '    If s.StartsWith("18") Then
        '        q = TrailerQuality.SD360
        '    ElseIf s.StartsWith("22") Then
        '        q = TrailerQuality.HD720
        '    ElseIf s.StartsWith("37") Then
        '        q = TrailerQuality.HD1080
        '    End If
        '    If Not q = TrailerQuality.NoQ Then
        '        Dim uri As String = ""
        '        'Dim urimatch As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "\d*\|(.*)")
        '        'If urimatch.Success = True Then
        '        '    uri = urimatch.Groups(1).Value
        '        'End If
        '        uri = s.Remove(0, 3)
        '        If Not uri = "" Then

        '        End If
        '    End If
        'Next


        Dim fi As New TrailerResult
        fi.Title = "Youtube Trailer"
        Dim dl As String = ""
        dl = GetYTDownloadLink(URL, "37")
        If Not dl = "" Then
            fi.Files.Add(New TrailerFile(TrailerQuality.HD1080, dl))
            dl = ""
        End If
        dl = GetYTDownloadLink(URL, "22")
        If Not dl = "" Then
            fi.Files.Add(New TrailerFile(TrailerQuality.HD720, dl))
            dl = ""
        End If
        dl = GetYTDownloadLink(URL, "18")
        If Not dl = "" Then
            fi.Files.Add(New TrailerFile(TrailerQuality.SD360, dl))
            dl = ""
        End If




        Result.Add(fi)
End Sub
    Private Function GetYTDownloadLink(ByVal id As String, ByVal s As String) As String
        Try

            Dim webClient1 As New Net.WebClient
            id = id.Replace("http://www.youtube.com/watch?v=", "")
            Dim link1 As String
            link1 = "http://www.youtube.com/get_video_info?video_id=" & id & "&fmt=" & s
            Dim inhalt As String
            inhalt = webClient1.DownloadString(link1)
            Dim pos As Integer = inhalt.IndexOf("url_encoded_fmt_stream_map=")
            Dim Part1 As String = inhalt.Substring(pos).Replace("%3F", "?").Replace("%3D", "=").Replace("%26", "&").Replace("%25", "%").Replace("%2C", ",").Replace("%25", "%").Replace("%3A", ":").Replace("%2F", "/").Substring(31)
            Dim Part2 As String = Part1.Substring(0, Part1.IndexOf("&fallback_host"))
            Dim Downloadlink As String
            Downloadlink = Part2.Replace("%3F", "?").Replace("%3D", "=").Replace("%26", "&").Replace("%25", "%").Replace("%2C", ",").Replace("%25", "%").Replace("%3A", ":").Replace("%2F", "/")
            Return Downloadlink
        Catch ex As Exception
            Return ""
        End Try

    End Function




Private Sub AnalyseMM()
    Dim httptext As String = ""



    If httptext = "" Then

        Try


            Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(URL), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
            Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)

            httptext = reader.ReadToEnd
            httpResponse.Close()
        Catch ex As Exception

        End Try
    End If
    If httptext = "" Then
        Exit Sub
    End If
        Dim matchurl As New System.Text.RegularExpressions.Regex("/media/trailer/(\d{4})")
        If matchurl.IsMatch(URL) Then
            mid = matchurl.Match(URL).Groups(1).Value
        End If

        Dim text As String = ""
        'Dim match As New System.Text.RegularExpressions.Regex("href=\""([^\.]*.mov)\?down=1\""")

        Dim match As New System.Text.RegularExpressions.Regex("<a href=""/media/trailer/\d{4},15,(\d{4})")
        'Dim match As New System.Text.RegularExpressions.Regex("\(""([^\.]*.mov)\?down=1""")
        If match.IsMatch(httptext) Then

            'Dim tr As New TrailerResult
            'tr.Title = ""


            For Each m As System.Text.RegularExpressions.Match In match.Matches(httptext)
                Dim cID As String = ""
                cID = m.Groups(1).Value
                If cID.Contains(",") Then
                    cID = cID.Substring(0, cID.IndexOf(","))
                End If



                GetMMFiles(cID, mid)


                'Dim Ui As String = m.Groups(1).Value
                'Dim ti As String = ""
                'Dim qu As String = ""
                'Dim st As String = ""
                'Dim q As TrailerQuality = TrailerQuality.NoQ
                'Dim tags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(Ui, "(\d*)_([^_]*)_(\d*).mov")
                'If tags.Success = True Then
                '    ti = tags.Groups(1).Value & "_" & tags.Groups(2).Value
                '    qu = tags.Groups(3).Value
                '    st = tags.Groups(2).Value
                'End If

                'If tr.Title = "" Then
                '    tr.Title = ti
                '    If ti.Contains("-de") Then
                '        tr.lng = "de"
                '    ElseIf ti.Contains("-en") Then
                '        tr.lng = "en"
                '    End If



                '    tr.displayTitle = st.Substring(0, 1).ToUpper & st.Remove(0, 1)
                '    tr.displayTitle = tr.displayTitle.Replace("-de", "").Replace("-en", "")
                '    Dim stags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(tr.displayTitle, "([^\d]*)0?(\d*).*")
                '    If stags.Success = True Then
                '        tr.displayTitle = stags.Groups(1).Value & " " & stags.Groups(2).Value
                '    End If



                'End If
                'Dim qi As Integer = Einstellungen.toInt(qu)
                'If qi <= 600 Then
                '    q = TrailerQuality.SD240
                'ElseIf qi <= 1100 Then
                '    q = TrailerQuality.SD360
                'ElseIf qi <= 1800 Then
                '    q = TrailerQuality.HD720
                'Else
                '    q = TrailerQuality.HD1080
                'End If



                'If tr.Title = ti Then
                '    tr.Files.Add(New TrailerFile(q, "http://www.moviemaze.de" & Ui, qi))
                'Else
                '    If tr.Files.Count > 0 Then
                '        Result.Add(tr)
                '    End If
                '    tr = New TrailerResult
                '    tr.Title = ti
                '    tr.Files.Add(New TrailerFile(q, "http://www.moviemaze.de" & Ui, qi))
                '    If ti.Contains("-de") Then
                '        tr.lng = "de"
                '    ElseIf ti.Contains("-en") Then
                '        tr.lng = "en"
                '    End If

                '    tr.displayTitle = st.Substring(0, 1).ToUpper & st.Remove(0, 1)
                '    tr.displayTitle = tr.displayTitle.Replace("-de", "").Replace("-en", "")
                '    Dim stags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(tr.displayTitle, "([^\d]*)0?(\d*).*")
                '    If stags.Success = True Then
                '        tr.displayTitle = stags.Groups(1).Value & " " & stags.Groups(2).Value
                '    End If

                'End If




            Next




        End If


    End Sub

    Private Sub GetMMFiles(ByVal cID As String, ByVal mid As String)
        Try


            'Dim darstellercount As Integer = 0
            Dim nxml As Xml.XmlDocument
            'nxml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.getInfo/de/xml/5fe800e9f7891b9131c0059be62a36d0/" & s.id)
            nxml = MyFunctions.HttploadXML("http://www.moviemaze.de/media/trailer/data.phtml?id=" & mid & "&clip=" & cID, "movm.getFiles_" & cID & "_" & mid)

            'nxml.Save("D:\test.xml")

            Dim xpath As String
            Dim j As Integer
            ' Jeder Knoten der Irgendwo im Dokument vorhanden ist 
            ' und "Pfad heisst"
            ' In diesem Beispiel liegt nur ein solcher Knoten vor
            'Dim trans As Boolean = Einstellungen.toBool(If(nxml.SelectNodes("//translated").Count > 0, nxml.SelectSingleNode("//translated").InnerText, ""), True)


            xpath = "//clip"
            'GENRE
            j = nxml.SelectNodes(xpath).Count
            If j > 0 Then
                For i As Integer = 0 To j - 1
                    Dim tr As New TrailerResult



                    Dim xmln As Xml.XmlNode
                    xmln = nxml.SelectNodes(xpath).Item(i)
                    If xmln.HasChildNodes Then
                        For Each s As XmlNode In xmln.ChildNodes
                            If s.Name = "downloadurl" Then
                                Dim tf As New TrailerFile(TrailerQuality.NoQ, s.InnerText, 200)
                                tr.Files.Add(tf)
                            ElseIf s.Name = "title" Then
                                tr.Title = s.InnerText
                            ElseIf s.Name = "overlayicon" Then
                                If s.InnerText = "lang-en" Then
                                    tr.lng = "en"
                                ElseIf s.InnerText = "lang-de" Then
                                    tr.lng = "de"
                                End If
                            End If
                        Next
                    End If
                    tr.displayTitle = tr.Title
                    If tr.Files.Count > 0 Then
                        Result.Add(tr)
                    End If
                Next
            End If
            's.Genre = g

            'xpath = "//produktionsland"
            ''LAND
            'g = ""
            'j = nxml.SelectNodes(xpath).Count
            'If j > 0 Then
            '    For i As Integer = 0 To j - 1
            '        Dim xmln As Xml.XmlNode
            '        xmln = nxml.SelectNodes(xpath).Item(i)
            '        If xmln.HasChildNodes Then
            '            For y As Integer = 0 To xmln.ChildNodes.Count - 1
            '                If g = "" Then
            '                    g = xmln.ChildNodes(y).InnerText
            '                Else
            '                    g &= ", " & xmln.ChildNodes(y).InnerText
            '                End If
            '            Next
            '        End If
            '    Next
            'End If
            's.Produktionsland = g


            'xpath = "//regie"
            'g = ""
            'j = nxml.SelectNodes(xpath).Count
            'If j > 0 Then
            '    For i As Integer = 0 To j - 1
            '        Dim xmln As Xml.XmlNode
            '        xmln = nxml.SelectNodes(xpath).Item(i)
            '        If xmln.HasChildNodes Then
            '            For y As Integer = 0 To xmln.ChildNodes.Count - 1
            '                If xmln.ChildNodes(y).HasChildNodes Then
            '                    For yz As Integer = 0 To xmln.ChildNodes(y).ChildNodes.Count - 1
            '                        If xmln.ChildNodes(y).ChildNodes(yz).Name = "name" Then
            '                            If g = "" Then
            '                                g = xmln.ChildNodes(y).ChildNodes(yz).InnerText
            '                            Else
            '                                g &= ", " & xmln.ChildNodes(y).ChildNodes(yz).InnerText
            '                            End If
            '                        End If
            '                    Next
            '                End If
            '            Next
            '        End If
            '    Next
            'End If
            's.Regisseur = g
            ''s.Autoren = g

            ''LAND

            'xpath = "//besetzung"
            'g = ""
            'j = nxml.SelectNodes(xpath).Count
            'If j > 0 Then
            '    For i As Integer = 0 To j - 1
            '        Dim xmln As Xml.XmlNode
            '        xmln = nxml.SelectNodes(xpath).Item(i)
            '        If xmln.HasChildNodes Then
            '            For y As Integer = 0 To xmln.ChildNodes.Count - 1
            '                If xmln.ChildNodes(y).HasChildNodes Then
            '                    For yz As Integer = 0 To xmln.ChildNodes(y).ChildNodes.Count - 1
            '                        If xmln.ChildNodes(y).ChildNodes(yz).Name = "name" Then
            '                            If g = "" Then
            '                                g = xmln.ChildNodes(y).ChildNodes(yz).InnerText
            '                            Else
            '                                g &= ", " & xmln.ChildNodes(y).ChildNodes(yz).InnerText
            '                            End If
            '                        ElseIf xmln.ChildNodes(y).ChildNodes(yz).Name = "rolle" Then
            '                            Dim var As String = Trim(xmln.ChildNodes(y).ChildNodes(yz).InnerText)
            '                            If Not var = "" And Not var = " " And Not var = "..." Then
            '                                g &= " [" & var.Replace(",", " |").Replace("...", "") & "]"

            '                            End If
            '                        End If
            '                    Next
            '                End If
            '            Next
            '        End If
            '    Next
            'End If
            's.ofdb_loaded = True
            's.Darsteller = g
        Catch ex As Exception
            MsgBox("Fehler:" & vbCrLf & ex.Message & vbCrLf & "ID:", MsgBoxStyle.Exclamation)
        End Try






    End Sub



End Class

Public Class xRelIDProvider
    Public Shared Function GetxRelLink(ByVal id As String) As String
        If id = "" Then Return ""

        Dim httptext As String = ""
        httptext = MyFunctions.HttploadText("http://www.xrel.to/search.html?xrel_search_query=" & id, "xRel.getID_de_" & id)
        If httptext Is Nothing Then httptext = ""



        Dim idmatch As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(httptext, "<a href=""/movie/(.*?)(?="")", System.Text.RegularExpressions.RegexOptions.Multiline)
        If idmatch.Success = True Then
            If idmatch.Groups(1).Value() = "" Then Return ""

            Return "http://www.xrel.to/movie/" & idmatch.Groups(1).Value()

        End If
        Return ""

    End Function

End Class
Public Class MoviemazeSearchProvider
    Class mm_Result
        Public sTitel As String
        Public sTrailerURI As String
        Public sMovieID As String
        Public sGenauigkeit As Integer
        ReadOnly Property Genauigkeit As Integer
            Get
                Return sGenauigkeit
            End Get
        End Property
        ReadOnly Property Titel As String
            Get
                Return sTitel
            End Get
        End Property
        ReadOnly Property TrailerURI As String
            Get
                Return sTrailerURI
            End Get
        End Property
    End Class


    Public AllResults As New List(Of mm_Result)
    Sub New()
        Getalltrailer()
    End Sub

    Private Sub Getalltrailer()
        Dim httptext As String = ""
        AllResults.Clear()
        Try
            Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(New Uri("http://www.moviemaze.de/media/trailer/archiv.phtml")), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
            Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream, System.Text.Encoding.GetEncoding("ISO-8859-1"))

            httptext = reader.ReadToEnd
            httpResponse.Close()
        Catch ex As Exception

        End Try

        If Not httptext = "" Then


            Dim match As New System.Text.RegularExpressions.Regex("<a href=""/media/trailer/([^""]*)"">([^\<]*)")
            If match.IsMatch(httptext) Then
                For Each m As System.Text.RegularExpressions.Match In match.Matches(httptext)

                    Dim nui As String = "http://www.moviemaze.de/media/trailer/" & m.Groups(1).Value
                    Dim tags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(m.Groups(1).Value, "(\d*),([^\.]*)\.html")
                    Dim r As New mm_Result
                    If tags.Success = True Then
                        r.sMovieID = tags.Groups(1).Value

                    End If





                    r.sTitel = m.Groups(2).Value
                    r.sTrailerURI = nui
                    AllResults.Add(r)
                Next
            End If

        End If
    End Sub
    Class MoviemazeSearchResult
        Property Li As New List(Of mm_Result)
        Public Exact As mm_Result
    End Class
    Function Search(ByVal q As String) As MoviemazeSearchResult
        'neues ergbnis stack ding
        Dim mm As New MoviemazeSearchResult
        Dim exact As New List(Of mm_Result)
        Dim sim As New SimilarityTool

        For Each re In AllResults

            Dim d As Double = sim.CompareStrings(re.Titel, q)
            If d >= 0.9 Then
                re.sGenauigkeit = 0
                mm.Li.Add(re)
                exact.Add(re)

            ElseIf d >= 0.7 Then
                re.sGenauigkeit = 1
                mm.Li.Add(re)


            ElseIf d >= 0.5 Then
                re.sGenauigkeit = 2
                mm.Li.Add(re)

            End If


        Next

        If exact.Count = 1 Then
            mm.Exact = exact(0)
        Else
            mm.Exact = Nothing
        End If


        Return mm


    End Function





End Class


