'Imports System.Collections.Generic
'Imports System.Xml
'Imports System.Drawing
'Imports System.Net
'Imports System.Reflection
'Imports System.Collections
'Imports System.Diagnostics
'Imports System.IO
'Imports System.Text
'Imports System.Xml.Serialization
'Public Class TheTVDBProvider
'    'Implements ITVMetadataProvider
'    'Public Event Message As MediaScoutMessage.Message

'    Private Const APIKey As [String] = "4AD667B666AA62FA"
'    Private urlSeriesID As [String] = "http://www.thetvdb.com/api/GetSeries.php?seriesname="
'    Private urlMetadata As [String] = "http://www.thetvdb.com/api/" + APIKey + "/series/"
'    Private urlPoster As [String] = "http://thetvdb.com/banners/"
'    Private defaultLanguage As [String] = "en"

'    Public ReadOnly Property name() As String
'        Get
'            Return "TheTVDB"
'        End Get
'    End Property
'    Public ReadOnly Property version() As String
'        Get
'            Return "0.1"
'        End Get
'    End Property
'    Public ReadOnly Property url() As String
'        Get
'            Return "http://www.thetvdb.com"
'        End Get
'    End Property

'    Public defaultCacheDir As [String] = System.Environment.CurrentDirectory & "\Cache\TVCache\"
'    Public dtDefaultCache As DateTime = DateTime.Now.Subtract(New TimeSpan(14, 0, 0, 0))

'    Public Function Search(ByVal SeriesName As [String]) As TVShow()

'        Return Search(SeriesName, defaultLanguage)
'    End Function

'    Public Function Search(ByVal SeriesName As [String], ByVal Language As [String]) As TVShow()
'        'RaiseEvent Message("Querying TV ID for " & SeriesName, MediaScoutMessage.MessageType.ProcessSeries, DateTime.Now)

'        Dim xdoc As New XmlDocument()
'        Dim node As XmlNode
'        Dim tvshows As New List(Of TVShow)()


'        xdoc.Load(urlSeriesID & SeriesName & "&language=" & Language)
'        node = xdoc.DocumentElement

'        Dim xnl As XmlNodeList = node.SelectNodes("/Data/Series")
'        For i As Integer = 0 To xnl.Count - 1
'            Dim t As New TVShow()
'            If xnl(i)("seriesid") IsNot Nothing Then
'                t.SeriesID = xnl(i)("seriesid").InnerText
'            End If

'            If xnl(i)("SeriesName") IsNot Nothing Then
'                t.SeriesName = xnl(i)("SeriesName").InnerText
'            End If

'            If xnl(i)("Overview") IsNot Nothing Then
'                t.Overview = xnl(i)("Overview").InnerText
'            End If

'            If xnl(i)("id") IsNot Nothing Then
'                t.id = xnl(i)("id").InnerText
'            End If

'            If xnl(i)("banner") IsNot Nothing Then
'                t.SeriesBannerUrl = urlPoster & xnl(i)("banner").InnerText
'            End If

'            tvshows.Add(t)
'        Next
'        Return tvshows.ToArray()
'    End Function

'    Public Function GetTVShow(ByVal TVShowID As [String]) As TVShow
'        Return GetTVShow(TVShowID, defaultLanguage, defaultCacheDir, dtDefaultCache)
'    End Function
'    Public Function GetTVShow(ByVal TVShowID As [String], ByVal language As [String]) As TVShow
'        Return GetTVShow(TVShowID, language, defaultCacheDir, dtDefaultCache)
'    End Function

'    Public Function GetTVShow(ByVal TVShowID As [String], ByVal Language As [String], ByVal CacheDirectory As [String], ByVal dtCacheTime As DateTime) As TVShow
'        Dim xdoc As New XmlDocument()
'        Dim node As XmlNode
'        Dim nodeList As XmlNodeList
'        Dim s As TVShow

'        If CacheDirectory Is Nothing Then
'            CacheDirectory = defaultCacheDir
'        End If

'        If dtCacheTime = Nothing Then
'            dtCacheTime = dtDefaultCache
'        End If

'        Try
'            If File.Exists(CacheDirectory & "\" & TVShowID & ".xml") AndAlso (DateTime.Compare(File.GetLastWriteTime(CacheDirectory & "\" & TVShowID & ".xml"), dtCacheTime) > 0) Then
'                'RaiseEvent Message("Loading from cache", MediaScoutMessage.MessageType.ProcessSeries, DateTime.Now)

'                xdoc.Load(CacheDirectory & "\" & TVShowID & ".xml")
'            Else
'                xdoc.Load(urlMetadata & TVShowID & "/all/" & Language & ".xml")
'            End If

'            node = xdoc.DocumentElement

'            'RaiseEvent Message("Metadata retrieved.  Processing...", MediaScoutMessage.MessageType.ProcessSeries, DateTime.Now)

'            'Create Series/Fetch Series Metadata
'            nodeList = node.SelectNodes("/Data/Series")
'            'String tvcomID = nodeList[0].SelectSingleNode("SeriesID").InnerText;
'            Dim SeriesName As [String] = nodeList(0).SelectSingleNode("SeriesName").InnerText
'            Dim SeriesPosterUrl As [String] = nodeList(0).SelectSingleNode("poster").InnerText
'            Dim SeriesBannerUrl As [String] = nodeList(0).SelectSingleNode("banner").InnerText
'            Dim SeriesMetadata As [String] = xdoc.ChildNodes(1).ChildNodes(0).OuterXml

'            s = New TVShow(TVShowID, SeriesName, SeriesPosterUrl, SeriesBannerUrl)

'            s.Network = nodeList(0).SelectSingleNode("Network").InnerText
'            s.Rating = nodeList(0).SelectSingleNode("Rating").InnerText
'            s.Overview = nodeList(0).SelectSingleNode("Overview").InnerText
'            s.Runtime = nodeList(0).SelectSingleNode("Runtime").InnerText
'            s.Genre = nodeList(0).SelectSingleNode("Genre").InnerText
'            s.FirstAired = nodeList(0).SelectSingleNode("FirstAired").InnerText
'            s.Actors = nodeList(0).SelectSingleNode("Actors").InnerText

'            'Deal with the XML for specific episodes
'            nodeList = node.SelectNodes("/Data/Episode")

'            For Each x As XmlNode In nodeList

'                'Extract metadata for episode/seasons
'                Dim EpisodeXML As [String] = "<Item>" & x.InnerXml & "</Item>"
'                Dim EpisodeID As [String] = x("id").InnerText
'                Dim SeasonNumber As Int32 = Int32.Parse(x("SeasonNumber").InnerText)
'                Dim EpisodeNumber As Int32 = Int32.Parse(x("EpisodeNumber").InnerText)
'                Dim EpisodeName As [String] = x("EpisodeName").InnerText
'                Dim EpisodePosterURL As [String] = x("filename").InnerText
'                Dim Overview As [String] = x("Overview").InnerText

'                If Not s.Seasons.ContainsKey(SeasonNumber) Then
'                    s.Seasons.Add(SeasonNumber, New Season(SeasonNumber, TVShowID))
'                End If

'                If Not s.Seasons(SeasonNumber).Episodes.ContainsKey(EpisodeNumber) Then
'                    Dim ep As New Episode(EpisodeNumber, EpisodeName, (If(([String].IsNullOrEmpty(EpisodePosterURL)), [String].Empty, urlPoster & EpisodePosterURL)))
'                    ep.Overview = Overview
'                    ep.EpisodeID = EpisodeID
'                    s.Seasons(SeasonNumber).Episodes.Add(EpisodeNumber, ep)
'                End If
'            Next

'            'Cache metadata
'            Try
'                'RaiseEvent Message("Caching Metadata", MediaScoutMessage.MessageType.ProcessSeries, DateTime.Now)
'                xdoc.Save(CacheDirectory & "\" & TVShowID & ".xml")
'            Catch ex As Exception
'                'RaiseEvent Message("Error caching metadata: " & ex.Message, MediaScoutMessage.MessageType.[Error], DateTime.Now)


'            End Try
'        Catch ex As Exception
'            s = Nothing
'            Throw New Exception(ex.Message & ex.StackTrace)
'        End Try

'        Return s

'    End Function


'    Public Function GetPosters(ByVal TVShowID As [String], ByVal type As TVShowPosterType, ByVal season As [String]) As Posters()
'        Dim xdoc As New XmlDocument()
'        xdoc.Load(urlMetadata & TVShowID & "/banners.xml")
'        Dim xnl As XmlNodeList = xdoc.DocumentElement.SelectNodes("/Banners/Banner")

'        'List<String> posters = new List<string>();
'        Dim posters As New List(Of Posters)()

'        Dim t As [String] = StringEnum.GetStringValue(type)
'        For Each x As XmlNode In xnl
'            Debug.WriteLine(x.InnerXml.ToString())
'            If x.SelectSingleNode("BannerType").InnerText = t Then
'                If type = TVShowPosterType.Season Then
'                    If x.SelectSingleNode("Season").InnerText <> season Then
'                        Continue For
'                    End If
'                End If

'                Dim p As New Posters With { _
'                    .Poster = urlPoster & x.SelectSingleNode("BannerPath").InnerText, _
'                 .Thumb = If((x.SelectSingleNode("ThumbnailPath") IsNot Nothing), urlPoster & x.SelectSingleNode("ThumbnailPath").InnerText, Nothing), _
'                 .Resolution = If((x.SelectSingleNode("BannerType2") IsNot Nothing), x.SelectSingleNode("BannerType2").InnerText, Nothing) _
'                }

'                posters.Add(p)
'            End If
'        Next

'        Return posters.ToArray()
'    End Function

'#Region "ITVMetadataProvider Members"


'    Public Function GetSeason(ByVal SeasonID As String) As Season
'        Throw New NotImplementedException()
'    End Function

'    Public Function GetEpisode(ByVal EpisodeID As String) As Episode
'        Throw New NotImplementedException()
'    End Function

'#End Region


'End Class

'Public Class StringValueAttribute
'    Inherits System.Attribute
'    Private _value As String

'    Public Sub New(ByVal value As String)
'        _value = value
'    End Sub

'    Public ReadOnly Property Value() As String
'        Get
'            Return _value
'        End Get
'    End Property
'End Class

'Public Enum TVShowPosterType
'    <StringValue("poster")> _
'    Poster

'    <StringValue("fanart")> _
'    Backdrop

'    <StringValue("series")> _
'    Banner

'    <StringValue("season")> _
'    Season
'End Enum

'Public NotInheritable Class StringEnum
'    Private Sub New()
'    End Sub
'    Private Shared _stringValues As New Hashtable()

'    Public Shared Function GetStringValue(ByVal value As [Enum]) As String
'        Dim output As String = Nothing
'        Dim type As Type = value.[GetType]()

'        'Check first in our cached results...

'        If _stringValues.ContainsKey(value) Then
'            output = TryCast(_stringValues(value), StringValueAttribute).Value
'        Else
'            'Look for our 'StringValueAttribute' 

'            'in the field's custom attributes

'            Dim fi As FieldInfo = type.GetField(value.ToString())
'            Dim attrs As StringValueAttribute() = TryCast(fi.GetCustomAttributes(GetType(StringValueAttribute), False), StringValueAttribute())
'            If attrs.Length > 0 Then
'                _stringValues.Add(value, attrs(0))
'                output = attrs(0).Value
'            End If
'        End If

'        Return output
'    End Function
'End Class



'<XmlRoot("Item")> _
'Public Class Episode

'    Public ID As Int32
'    Public Director As [String]
'    Public EpisodeID As [String]
'    Public EpisodeName As [String]
'    Public EpisodeNumber As [String]
'    Public FirstAired As [String]
'    Public GuestStars As [String]
'    Public Language As [String]
'    Public Overview As [String]
'    Public ProductionCode As [String]
'    Public Writer As [String]
'    Public SeasonNumber As [String]
'    Public SeasonID As [String]
'    Public SeriesID As [String]
'    Public LastUpdated As [String]

'    <XmlIgnore()> _
'    Public PosterUrl As [String]

'    <XmlElement("filename")> _
'    Public PosterName As [String]

'    <XmlIgnore()> _
'    Public Poster As System.Drawing.Image

'    <XmlIgnore()> _
'    Public BannerUrl As [String]

'    <XmlIgnore()> _
'    Public Banner As System.Drawing.Image

'    Public Sub New(ByVal episodeNumber__1 As Int32, ByVal name As [String], ByVal posterUrl__2 As [String])
'        ID = episodeNumber__1
'        EpisodeNumber = episodeNumber__1.ToString()
'        EpisodeName = name

'        If Not [String].IsNullOrEmpty(posterUrl__2) Then
'            PosterName = posterUrl__2.Substring(posterUrl__2.LastIndexOf("/"))
'            PosterUrl = posterUrl__2
'        Else
'            PosterUrl = ""
'        End If
'    End Sub


'    Public Sub New()
'    End Sub


'End Class


'Public Class Season
'    Public Episodes As SortedList(Of Int32, Episode) = New SortedList(Of Integer, Episode)()
'    Public ID As Int32
'    Public TVShowID As [String]

'    Public Sub New(ByVal seasonNumber As Int32, ByVal TVShowID As [String])
'        ID = seasonNumber
'        Me.TVShowID = TVShowID
'    End Sub

'    Public poster As Image
'    Public banner As Image
'    Public PosterUrl As [String]
'    Public tvid As [String]
'    'FreQi - Work item #2394
'    Public Sub FetchPoster()
'        Try
'            ' Create the requests.
'            Dim requestPic As WebRequest = WebRequest.Create(PosterUrl)
'            Dim responsePic As WebResponse = requestPic.GetResponse()
'            poster = System.Drawing.Image.FromStream(responsePic.GetResponseStream())

'        Catch
'        End Try
'    End Sub
'End Class




'<XmlRoot("Series")> _
'Public Class TVShow
'    Public id As [String]
'    Public Actors As [String]
'    Public ContentRating As [String]
'    Public FirstAired As [String]
'    Public Genre As [String]
'    Public IMDB_ID As [String]
'    Public Language As [String]
'    Public Network As [String]
'    Public Rating As [String]
'    Public Runtime As [String]
'    Public SeriesID As [String]
'    Public Status As [String]

'    <XmlIgnore()> _
'    Private m_overview As [String]

'    <XmlIgnore()> _
'    Private m_seriesName As [String]

'    <XmlIgnore()> _
'    Public Seasons As New SortedList(Of Int32, Season)()

'    <XmlIgnore()> _
'    Public SeriesPosterUrl As [String]

'    <XmlIgnore()> _
'    Public m_seriesBannerUrl As [String]


'    Public Sub New(ByVal SeriesID As [String], ByVal SeriesName As [String], ByVal SeriesPosterUrl As [String], ByVal SeriesBannerUrl As [String])
'        Me.SeriesID = InlineAssignHelper(id, SeriesID)
'        Me.SeriesBannerUrl = SeriesBannerUrl
'        Me.SeriesPosterUrl = SeriesPosterUrl
'        Me.SeriesName = SeriesName
'    End Sub


'    Public Sub New()
'    End Sub

'    <XmlIgnore()> _
'    Public Property SeriesBannerUrl() As [String]
'        Get
'            Return m_seriesBannerUrl
'        End Get
'        Set(ByVal value As [String])
'            m_seriesBannerUrl = value
'        End Set
'    End Property

'    Public Property Overview() As [String]
'        Get
'            Return m_overview
'        End Get
'        Set(ByVal value As [String])
'            m_overview = value
'        End Set
'    End Property

'    Public Property SeriesName() As [String]
'        Get
'            Return m_seriesName
'        End Get
'        Set(ByVal value As [String])
'            m_seriesName = value
'        End Set
'    End Property

'    Public Sub Save(ByVal filename As [String])
'        Dim s As New XmlSerializer(GetType(TVShow))
'        Dim w As TextWriter = New StreamWriter(filename)
'        s.Serialize(w, Me)
'        w.Close()
'    End Sub
'    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
'        target = value
'        Return value
'    End Function
'End Class

'Public Class Posters
'    Private m_poster As [String]
'    Private m_thumb As [String]
'    Private res As [String]

'    Public Property Poster() As [String]
'        Get
'            Return m_poster
'        End Get
'        Set(ByVal value As [String])
'            m_poster = value
'        End Set
'    End Property

'    Public Property Thumb() As [String]
'        Get
'            Return m_thumb
'        End Get
'        Set(ByVal value As [String])
'            m_thumb = value
'        End Set
'    End Property

'    Public Property Resolution() As [String]
'        Get
'            Return res
'        End Get
'        Set(ByVal value As [String])
'            res = value
'        End Set
'    End Property

'    ''' <summary>
'    ''' Saves the poster to a specified file
'    ''' </summary>
'    ''' <param name="filepath"></param>
'    Public Sub SavePoster(ByVal filepath As [String])
'        savegraphic(Me.m_poster, filepath)
'    End Sub

'    ''' <summary>
'    ''' Saves the thumbnail to a specified file
'    ''' </summary>
'    ''' <param name="filepath"></param>
'    Public Sub SaveThumb(ByVal filepath As [String])
'        savegraphic(Me.m_thumb, filepath)
'    End Sub

'    Private Sub savegraphic(ByVal fileIn As [String], ByVal fileOut As [String])
'        Dim requestPic As WebRequest = WebRequest.Create(fileIn)
'        Dim responsePic As WebResponse = requestPic.GetResponse()
'        Dim temp As System.Drawing.Image = System.Drawing.Image.FromStream(responsePic.GetResponseStream())

'        temp.Save(fileOut, System.Drawing.Imaging.ImageFormat.Jpeg)
'    End Sub
'End Class
