Imports Film_Info__Organizer.MyFunctions
Public Class MovieCollection
    Public Movies As New List(Of Movie)
    Dim sPath As String = ""
    Dim sNode As TreeNode
    Public Property Node() As TreeNode
        Get
            Return sNode
        End Get
        Set(ByVal value As TreeNode)
            sNode = value
        End Set
    End Property
    Public Property Pfad() As String
        Get
            Return sPath
        End Get
        Set(ByVal value As String)
            sPath = value

        End Set
    End Property

End Class

Public Class Movie
    '    Private Shared Function Sort(ByVal x As Movie, ByVal y _
    'As Movie) As Integer
    '        Dim c1 As Integer = x.Titel.CompareTo(y.Titel)
    '        If c1 <> 0 Then Return c1
    '        Return x.Titel.CompareTo(y.Titel)
    '    End Function
    Public Row As DataGridViewRow
    ''' <summary>
    ''' 0 = Nichts
    ''' 1 = ?
    ''' 2 = Neu
    ''' 3 = Markiert
    ''' 4 = Cover
    ''' 5 = Fanart
    ''' 6 = Info
    ''' 7 = Download
    ''' 8 = Wichtig
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property flag As Integer = 0
    Public Property DVDChacheID As String = ""

    Public Property TrailerURL As String = ""

#Region "----Status----"
    Public Property State_Ordner As Integer = 0
    Public Property State_Ordner_tip As New List(Of String)
    Public Property State_Ordner_text As String = ""

    Public Property State_Cover As Integer = 0
    Public Property State_Cover_tip As New List(Of String)
    Public Property State_Cover_text As String = ""

    Public Property State_Backdrop As Integer = 0
    Public Property State_Backdrop_tip As New List(Of String)
    Public Property State_Backdrop_text As String = ""

    Public Property State_Info As Integer = 0
    Public Property State_Info_tip As New List(Of String)
    Public Property State_Info_text As String = ""

    Public Property State_MediaInfo As Integer = 0
    Public Property State_MediaInfo_tip As New List(Of String)
    Public Property State_MediaInfo_text As String = ""
#End Region


#Region "----Werte----"
#Region "Ordner"
    Dim sPath As String = ""
    Dim sFolder As String = ""
    Dim sFiles() As String
    Dim sFile_Trailer As String = ""
    Dim sCover As String = ""
    Dim sCover_height As Integer = 0
    Dim sCover_width As Integer = 0
    Dim sBackdrops() As String
    Dim sFoldersize As Double
    Dim sFilesize As Double
    Dim sDate_Created As Date
#End Region
#Region "Informationen XML"
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
#End Region
#Region "Filme Plugin"
    Dim sMediaInfo As String = ""
    Dim sPosition As String = ""
    Dim sDatum As String = ""
    Dim sVideoBreite As String = ""
    Dim sVideoHöhe As String = ""
    Dim sVideoAuflösung As String = ""
    Dim sVideoSeitenverhältnis As String = ""
    Dim sVideoBildwiederholungsrate As String = ""
    Dim sVideoCodec As String = ""
    Dim sAudioKanäle As String = ""
    Dim sAudioCodec As String = ""
    Dim sAudioSprachen As String = ""
#End Region
#Region "Media Browser"
    Dim sMPAARating As String = ""
    Dim sLockData As String = ""
    Dim sTMDBId As String = ""
    Dim sType As String = ""
    Dim sAdded As String = ""
#End Region
#Region "andere Informationen"
    Dim sFortschritt As Integer = 0
#End Region
#Region "XBMC"
    Dim sPlaycount As String = ""
    Dim sGesehen As String = ""
    Dim sSetbox As String = ""
#End Region
#End Region

    'Public Property Searchresult() As Search_Result
#Region "----Propertys----"
    Public Property Pfad() As String
        Get
            Return sPath
        End Get
        Set(ByVal value As String)
            sPath = value
        End Set
    End Property
    Public Property Ordner() As String
        Get
            Return sFolder
        End Get
        Set(ByVal value As String)
            sFolder = value
        End Set
    End Property
    Public Property Dateien() As String()
        Get
            Return sFiles
        End Get
        Set(ByVal value As String())
            sFiles = value
        End Set
    End Property
    Public Property Cover() As String
        Get
            Return sCover
        End Get
        Set(ByVal value As String)
            sCover = value
        End Set
    End Property
    Public Property Cover_height() As Integer
        Get
            Return sCover_height
        End Get
        Set(ByVal value As Integer)
            sCover_height = value
        End Set
    End Property
    Public Property Cover_width() As Integer
        Get
            Return sCover_width
        End Get
        Set(ByVal value As Integer)
            sCover_width = value
        End Set
    End Property
    Public Property Backdrops() As String()
        Get
            Return sBackdrops
        End Get
        Set(ByVal value As String())
            sBackdrops = value
        End Set
    End Property
    Public Property Foldersize() As Double
        Get
            Return sFoldersize
        End Get
        Set(ByVal value As Double)
            sFoldersize = value
        End Set
    End Property
    Public Property Filesize() As Double
        Get
            Return sFilesize
        End Get
        Set(ByVal value As Double)
            sFilesize = value
        End Set
    End Property
    Public Property Erstelldatum() As Date
        Get
            Return sDate_Created
        End Get
        Set(ByVal value As Date)
            sDate_Created = value
        End Set
    End Property

    Public Property Titel() As String
        Get
            Return If(sTitel Is Nothing, "", sTitel)
        End Get
        Set(ByVal value As String)
            sTitel = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Originaltitel() As String
        Get
            Return If(sOriginaltitel Is Nothing, "", sOriginaltitel)
        End Get
        Set(ByVal value As String)
            sOriginaltitel = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property IMDB_ID() As String
        Get
            Return If(sIMDB_ID Is Nothing, "", sIMDB_ID)
        End Get
        Set(ByVal value As String)
            sIMDB_ID = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Darsteller() As String
        Get
            Return If(sDarsteller Is Nothing, "", sDarsteller)
        End Get
        Set(ByVal value As String)
            sDarsteller = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Regisseur() As String
        Get
            Return If(sRegisseur Is Nothing, "", sRegisseur)
        End Get
        Set(ByVal value As String)
            sRegisseur = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Autoren() As String
        Get
            Return If(sAutoren Is Nothing, "", sAutoren)
        End Get
        Set(ByVal value As String)
            sAutoren = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Studios() As String
        Get
            Return If(sStudios Is Nothing, "", sStudios)
        End Get
        Set(ByVal value As String)
            sStudios = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Produktionsjahr() As String
        Get
            Return If(sProduktionsjahr Is Nothing, "", sProduktionsjahr)
        End Get
        Set(ByVal value As String)
            sProduktionsjahr = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Produktionsland() As String
        Get
            Return If(sProduktionsland Is Nothing, "", sProduktionsland)
        End Get
        Set(ByVal value As String)
            sProduktionsland = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Genre() As String
        Get
            Return If(sGenre Is Nothing, "", sGenre)
        End Get
        Set(ByVal value As String)
            sGenre = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property FSK() As String
        Get
            Return If(sFSK Is Nothing, "", sFSK)
        End Get
        Set(ByVal value As String)
            sFSK = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Bewertung() As String
        Get
            Return If(sBewertung Is Nothing, "", sBewertung)
        End Get
        Set(ByVal value As String)
            sBewertung = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Spieldauer() As String
        Get
            Return If(sSpieldauer Is Nothing, "", sSpieldauer)
        End Get
        Set(ByVal value As String)
            sSpieldauer = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Datum() As String
        Get
            Return If(sDatum Is Nothing, "", sDatum)
        End Get
        Set(ByVal value As String)
            sDatum = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Kurzbeschreibung() As String
        Get
            Return If(sKurzbeschreibung Is Nothing, "", sKurzbeschreibung)
        End Get
        Set(ByVal value As String)
            sKurzbeschreibung = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Inhalt() As String
        Get
            Return If(sInhalt Is Nothing, "", sInhalt)
        End Get
        Set(ByVal value As String)
            sInhalt = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Position() As String
        Get
            Return If(sPosition Is Nothing, "", sPosition)
        End Get
        Set(ByVal value As String)
            sPosition = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Sort() As String
        Get
            Return If(sSort Is Nothing, "", sSort)
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                sSort = ""
            Else
                SammlungFunctions.AddtoList_i(value)
                sSort = If(value Is Nothing, "", value)
            End If
        End Set
    End Property
    Public Property VideoAuflösung() As String
        Get
            Return If(sVideoAuflösung Is Nothing, "", sVideoAuflösung)
        End Get
        Set(ByVal value As String)
            sVideoAuflösung = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property VideoSeitenverhältnis() As String
        Get
            Return If(sVideoSeitenverhältnis Is Nothing, "", sVideoSeitenverhältnis)
        End Get
        Set(ByVal value As String)
            sVideoSeitenverhältnis = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property VideoBildwiederholungsrate() As String
        Get
            Return If(sVideoBildwiederholungsrate Is Nothing, "", sVideoBildwiederholungsrate)
        End Get
        Set(ByVal value As String)
            sVideoBildwiederholungsrate = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property VideoCodec() As String
        Get
            Return If(sVideoCodec Is Nothing, "", sVideoCodec)
        End Get
        Set(ByVal value As String)
            sVideoCodec = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property AudioKanäle() As String
        Get
            Return If(sAudioKanäle Is Nothing, "", sAudioKanäle)
        End Get
        Set(ByVal value As String)
            sAudioKanäle = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property AudioCodec() As String
        Get
            Return If(sAudioCodec Is Nothing, "", sAudioCodec)
        End Get
        Set(ByVal value As String)
            sAudioCodec = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property AudioSprachen() As String
        Get
            Return If(sAudioSprachen Is Nothing, "", sAudioSprachen)
        End Get
        Set(ByVal value As String)
            sAudioSprachen = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property VideoHöhe() As String
        Get
            Return If(sVideoHöhe Is Nothing, "", sVideoHöhe)
        End Get
        Set(ByVal value As String)
            sVideoHöhe = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property VideoBreite() As String
        Get
            Return If(sVideoBreite Is Nothing, "", sVideoBreite)
        End Get
        Set(ByVal value As String)
            sVideoBreite = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property MediaInfo() As String
        Get
            Return If(sMediaInfo Is Nothing, "", sMediaInfo)
        End Get
        Set(ByVal value As String)
            sMediaInfo = If(value Is Nothing, "", value)
        End Set
    End Property

    Public Property LockData() As String
        Get
            Return If(sLockData Is Nothing, "", sLockData)
        End Get
        Set(ByVal value As String)
            sLockData = If(value Is Nothing, "", value)
        End Set
    End Property

    Public Property TMDBId() As String
        Get
            Return If(sTMDBId Is Nothing, "", sTMDBId)
        End Get
        Set(ByVal value As String)
            sTMDBId = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Typ() As String
        Get
            Return If(sType Is Nothing, "", sType)
        End Get
        Set(ByVal value As String)
            sType = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Added() As String
        Get
            Return If(sAdded Is Nothing, "", sAdded)
        End Get
        Set(ByVal value As String)
            sAdded = If(value Is Nothing, "", value)
        End Set
    End Property
    'Public Property Trailer() As String
    '    Get
    '        Return If(sTrailer Is Nothing, "", sTrailer)
    '    End Get
    '    Set(ByVal value As String)
    '        sTrailer = If(value Is Nothing, "", value)
    '    End Set
    'End Property
    Public Property PlayCount() As String
        Get
            Return If(sPlaycount Is Nothing, "", sPlaycount)
        End Get
        Set(ByVal value As String)
            sPlaycount = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Gesehen() As String
        Get
            Return If(sGesehen Is Nothing, "", sGesehen)
        End Get
        Set(ByVal value As String)
            sGesehen = If(value Is Nothing, "", value)
        End Set
    End Property
    Public Property Setbox() As String
        Get
            Return If(sSetbox Is Nothing, "", sSetbox)
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                sSetbox = ""
            Else
                SammlungFunctions.AddtoList_n(value)
                sSetbox = If(value Is Nothing, "", value)
            End If
        End Set
    End Property






    Public Property Fortschritt() As Integer
        Get
            Return sFortschritt
        End Get
        Set(ByVal value As Integer)
            sFortschritt = value
        End Set
    End Property
    Public Property Files() As String()
        Get
            Return sFiles
        End Get
        Set(ByVal value As String())
            sFiles = value
        End Set
    End Property


#End Region

    Property Coversize As Long = 0

    Property File_Trailer As String
        Get
            Return sFile_Trailer
        End Get
        Set(ByVal value As String)
            sFile_Trailer = value
        End Set
    End Property

    Property Favname As String

    Property Favpath As String




    Sub Refresh()
        'If Me.focused = True Then
        '    RefreshCover()
        'End If
        If MainForm.InvokeRequired = False Then
            refreshDatagrid()
        Else
            Dim s As String = ""

        End If

    End Sub




    ''' <summary>
    ''' Normales übertragen aller werte vom Info! Panel zur movie-Classe
    ''' </summary>
    ''' <param name="SaveintoFile">ob die Informationen auch als datei abgespeichert werden sollen</param>
    ''' <remarks></remarks>
    ''' 
    Sub Save(Optional ByVal SaveintoFile As Boolean = False)
        infopanelsave()
        refreshDatagrid()


        XMLModule.Save(Me, Einstellungen.Config_MediaCenter.Default_local_Source)
        If Einstellungen.Config_MediaCenter.MediaCenter_Windows_Immerschreiben = True Then
            XMLModule.Save(Me, Savemode.DVDInfo)
        End If
        If Not flag = 1 Then
            If Einstellungen.Config_Save.Save_Rename_File = True Then
                Renamer.ChangeFileName(Me)

            End If
            If Einstellungen.Config_Save.Save_Rename_Folder = True Then
                Renamer.ChangeFolderName(Me)

            End If

        End If
        'Settings abfrage, ob sofort oder später gespeichert werden soll



    End Sub
    Sub Save(ByVal mode As Savemode, Optional ByVal SaveintoFile As Boolean = False)
        infopanelsave()
        refreshDatagrid()

        XMLModule.Save(Me, mode)
        If Einstellungen.Config_MediaCenter.MediaCenter_Windows_Immerschreiben = True Then
            XMLModule.Save(Me, Savemode.DVDInfo)
        End If
        'Settings abfrage, ob sofort oder später gespeichert werden soll

        If Not flag = 1 Then
            If Einstellungen.Config_Save.Save_Rename_File = True Then
                Renamer.ChangeFileName(Me)

            End If
            If Einstellungen.Config_Save.Save_Rename_Folder = True Then
                Renamer.ChangeFolderName(Me)

            End If

        End If

    End Sub
    Sub SaveFile(ByVal mode As Savemode)
        XMLModule.Save(Me, mode)
        'Settings abfrage, ob sofort oder später gespeichert werden soll

        If Einstellungen.Config_MediaCenter.MediaCenter_Windows_Immerschreiben = True Then
            XMLModule.Save(Me, Savemode.DVDInfo)
        End If
        If Not flag = 1 Then
            If Einstellungen.Config_Save.Save_Rename_File = True Then
                Renamer.ChangeFileName(Me)

            End If
            If Einstellungen.Config_Save.Save_Rename_Folder = True Then
                Renamer.ChangeFolderName(Me)

            End If

        End If
    End Sub
    Sub SaveFile()

        XMLModule.Save(Me, Einstellungen.Config_MediaCenter.Default_local_Source)
        'Settings abfrage, ob sofort oder später gespeichert werden soll


        If Einstellungen.Config_MediaCenter.MediaCenter_Windows_Immerschreiben = True Then
            XMLModule.Save(Me, Savemode.DVDInfo)
        End If
        If Not flag = 1 Then
            If Einstellungen.Config_Save.Save_Rename_File = True Then
                Renamer.ChangeFileName(Me)

            End If
            If Einstellungen.Config_Save.Save_Rename_Folder = True Then
                Renamer.ChangeFolderName(Me)

            End If

        End If
    End Sub
    Private Sub infopanelsave()


        AudioKanäle = MainForm.InfoPanel_Movie1.TB_AudioKanäle.Text
        AudioCodec = MainForm.InfoPanel_Movie1.TB_AudioCodec.Text
        VideoAuflösung = MainForm.InfoPanel_Movie1.TB_VideoAuflösung.Text
        Autoren = MainForm.InfoPanel_Movie1.TB_Autoren.Text
        Bewertung = MainForm.InfoPanel_Movie1.TB_Bewertung.Text
        VideoBildwiederholungsrate = MainForm.InfoPanel_Movie1.TB_VideoBildwiederholungsrate.Text
        Genre = MainForm.InfoPanel_Movie1.TB_Genre.Text
        IMDB_ID = MainForm.InfoPanel_Movie1.TB_IMDB_ID.Text
        Inhalt = MainForm.InfoPanel_Movie1.TB_Inhalt.Text
        Produktionsjahr = MainForm.InfoPanel_Movie1.TB_Produktionsjahr.Text
        Kurzbeschreibung = MainForm.InfoPanel_Movie1.TB_Inhalt.Text
        Setbox = MainForm.InfoPanel_Movie1.TB_set.Text
        Produktionsland = MainForm.InfoPanel_Movie1.TB_Produktionsland.Text
        Ordner = MainForm.InfoPanel_Movie1.TB_Ordner.Text
        Originaltitel = MainForm.InfoPanel_Movie1.TB_Originaltitel.Text
        Pfad = MainForm.InfoPanel_Movie1.TB_Pfad.Text
        VideoSeitenverhältnis = MainForm.InfoPanel_Movie1.TB_VideoSeitenverhältnis.Text
        Regisseur = MainForm.InfoPanel_Movie1.TB_Regisseur.Text
        Sort = MainForm.InfoPanel_Movie1.TB_Sort.Text
        Spieldauer = MainForm.InfoPanel_Movie1.TB_Spieldauer.Text
        AudioSprachen = MainForm.InfoPanel_Movie1.TB_AudioSprachen.Text
        Studios = MainForm.InfoPanel_Movie1.TB_Studios.Text
        Titel = MainForm.InfoPanel_Movie1.TB_Titel.Text
        VideoCodec = MainForm.InfoPanel_Movie1.TB_VideoCodec.Text
        FSK = MainForm.InfoPanel_Movie1.FSK_Combobox.Text
        MainForm.InfoPanel_Movie1.lbl_selectedmovie.Text = Titel
        Dim dar As String = ""
        If MainForm.InfoPanel_Movie1.DarstellerView.RowCount - 1 > 0 Then
            For x As Integer = 0 To MainForm.InfoPanel_Movie1.DarstellerView.RowCount - 1
                If Not MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(0).Value Is Nothing Then
                    If dar = "" Then
                        dar = CStr(MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(0).Value)
                    Else
                        dar &= ", " & MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(0).Value.ToString
                    End If
                    If Not IsNothing(MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(1).Value) Then
                        If Not CStr(MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(1).Value) = "" Then
                            dar &= " [" & MainForm.InfoPanel_Movie1.DarstellerView.Rows(x).Cells(1).Value.ToString & "]"
                        End If
                    End If
                End If
            Next
        End If
        Darsteller = dar
        MyFunctions.Check_Artikel(Me)
        Genre = Einstellungen.GenreFilter.ChangeGenre(Genre)
    End Sub



    Private Sub refreshDatagrid()
        If Not IsNothing(Row) Then

            Row.Cells(MainForm.Column_Flags.Index).Value = flag

            Row.Cells(MainForm.Column_AudioCodec.Index).Value = AudioCodec
            Row.Cells(MainForm.Column_AudioKanäle.Index).Value = AudioKanäle
            Row.Cells(MainForm.Column_Auflösung.Index).Value = VideoAuflösung
            Row.Cells(MainForm.Column_Autoren.Index).Value = Autoren

            Row.Cells(MainForm.Column_Bewertung.Index).Value = Bewertung

            Row.Cells(MainForm.Column_Darsteller.Index).Value = Darsteller
            Row.Cells(MainForm.Column_Datum.Index).Value = Datum

            Row.Cells(MainForm.Column_FSK.Index).Value = FSK

            Row.Cells(MainForm.Column_Genre.Index).Value = Genre

            Row.Cells(MainForm.Column_IMDB_ID.Index).Value = IMDB_ID

            Row.Cells(MainForm.Column_Inhalt.Index).Value = Inhalt

            Row.Cells(MainForm.Column_Kurzbeschreibung.Index).Value = Kurzbeschreibung

            Row.Cells(MainForm.Column_MediaInfo.Index).Value = MediaInfo

            Row.Cells(MainForm.Column_Ordner.Index).Value = Ordner
            Row.Cells(MainForm.Column_Originaltitel.Index).Value = Originaltitel

            Row.Cells(MainForm.Column_Pfad.Index).Value = Pfad
            Row.Cells(MainForm.Column_Depth.Index).Value = Pfad.Split(CChar("\")).Length - 1
            Row.Cells(MainForm.Column_Position.Index).Value = Position

            Row.Cells(MainForm.Column_Produktionsjahr.Index).Value = Produktionsjahr
            Row.Cells(MainForm.Column_Produktionsland.Index).Value = Produktionsland
            Row.Cells(MainForm.Column_Regie.Index).Value = Regisseur
            Row.Cells(MainForm.Column_Seitenverhältnis.Index).Value = VideoSeitenverhältnis
            Row.Cells(MainForm.Column_Sort.Index).Value = Sort()
            Row.Cells(MainForm.Column_Spieldauer.Index).Value = Spieldauer
            Row.Cells(MainForm.Column_Sprachen.Index).Value = AudioSprachen
            Row.Cells(MainForm.Column_Studios.Index).Value = Studios
            Row.Cells(MainForm.Column_Titel.Index).Value = Titel
            Row.Cells(MainForm.Column_VideoBildwiederholungsrate.Index).Value = VideoBildwiederholungsrate
            Row.Cells(MainForm.Column_VideoCodec.Index).Value = VideoCodec

            Row.Cells(MainForm.Column_FilesCount.Index).Value = Files.Length


            Row.Cells(MainForm.Column_Trailer.Index).Value = Not File_Trailer = ""


            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                Row.Cells(MainForm.Column_Set.Index).Value = SammlungFunctions.List_i(Sort)

            Else
                Row.Cells(MainForm.Column_Set.Index).Value = Setbox
            End If



            Dim d As Boolean = False
            If Gesehen = "True" Then
                d = True
            ElseIf Gesehen = "False" Then
                d = False
            Else
                If Not Datum = "" Or (Not PlayCount = "0" And Not PlayCount = "") Then
                    Gesehen = "True"
                    d = True
                End If
            End If
            Row.Cells(MainForm.Column_watched.Index).Value = d


            Row.Cells(MainForm.Column_SizeFolder.Index).Value = CLng(Foldersize / 1024)




            Einstellungen.Config_Fortschritt.getFortschritt(Me)

            Row.Cells(MainForm.Column_Rate_Cover.Index).Value = State_Cover
            Row.Cells(MainForm.Column_Rate_Backdrops.Index).Value = State_Backdrop
            Row.Cells(MainForm.Column_Rate_Info.Index).Value = State_Info
            Row.Cells(MainForm.Column_Rate_MediaInfo.Index).Value = State_MediaInfo
            Row.Cells(MainForm.Column_Rate_Ordner.Index).Value = State_Ordner


            Row.Cells(MainForm.Column_Fortschritt.Index).Value = Fortschritt
            If Not MainForm.ToolStripTextBox1.Text = "" And Not MainForm.ToolStripTextBox1.Text = "Suchen" Then
                Dim rw As New RowFilter
                rw.run(Me.Row, MainForm.Filter_Dropdown_OPT.Text, MainForm.ToolStripTextBox1.Text)
            End If

            'If Fortschritt > 100 Then
            '    Do Until Fortschritt < 101
            '        Fortschritt -= 100
            '    Loop
            'End If

            'Dim c As Color
            'c = Color.FromArgb(51, 153, 51)
            'If Fortschritt < 30 Then
            '    c = Color.FromArgb(255, 66, 0)
            'ElseIf Fortschritt < 50 Then
            '    c = Color.FromArgb(255, 204, 51)
            'ElseIf Fortschritt < 70 Then
            '    c = Color.FromArgb(255, 255, 0)
            'ElseIf Fortschritt < 90 Then
            '    c = Color.FromArgb(153, 204, 0)
            'End If
            'Row.DefaultCellStyle.BackColor = c


        End If
    End Sub

    Function focused() As Boolean
        If Not IsNothing(MainForm.SelectedMovie) Then
            If Me.Equals(MainForm.SelectedMovie) Then
                Return True

            Else
                Return False
            End If
        Else

            Return False
        End If
    End Function

    Sub RefreshCover()
        If Me.focused = True Then
            PathAnalyse(Me)
            MainForm.InfoPanel_Movie1.arr_to_Panel_Backdrops(Me)
            MainForm.InfoPanel_Movie1.arr_to_Panel_Cover(Me)
            MainForm.InfoPanel_Movie1.PictureBox1.Image.Dispose()
            MainForm.InfoPanel_Movie1.PictureBox1.Image = MyFunctions.ImageFromJpeg(Me.Cover)
            If Not IsNothing(MainForm.InfoPanel_Movie1.PictureBox1.Image) Then
                Cover_height = MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Height
                Cover_width = MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Width
                MainForm.InfoPanel_Movie1.Cover_Size.Text = MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Height & "x" & MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Width
                MainForm.InfoPanel_Movie1.Cover_Size.Tag = MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Height & "x" & MainForm.InfoPanel_Movie1.PictureBox1.Image.Size.Width

            End If
            MainForm.InfoPanel_Movie1.Cover_Name.Text = "Cover"


        Else
            PathAnalyse(Me)
            'If IO.File.Exists(Me.Cover) Then
            '    Dim mi As Image = MyFunctions.ImageFromJpeg(Me.Cover)
            '    Cover_height = mi.Height
            '    Cover_width = mi.Width
            '    mi.Dispose()
            'End If


        End If

    End Sub
    Sub Check_Artikel_Genre()
        Dim b As Boolean = False
        If MyFunctions.Check_Artikel(Me) = True Then
            b = True
        End If
        Dim g As String = Einstellungen.GenreFilter.ChangeGenre(Genre)
        If Not Genre = g Then
            Genre = g
            b = True
        End If
        If b = True Then
            SaveFile()
        End If



    End Sub

End Class
