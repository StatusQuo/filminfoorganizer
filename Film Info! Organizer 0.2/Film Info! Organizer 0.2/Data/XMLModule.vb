Imports System.Xml
Imports System.IO
Imports System.Windows
Imports Film_Info__Organizer.MyFunctions
Imports System.Text.RegularExpressions

Public Enum Savemode
    Info
    mymovies
    oldmymovies
    nfo
    DVDInfo
    neu
End Enum


Module MovieCoverConverter
    Sub ConvertImages(ByVal nSav As Savemode, ByVal m As Movie, ByVal Replace As Boolean)
        If nSav = Savemode.nfo Then
            ConvertImagestoXBMC(m, Replace)
        ElseIf nSav = Savemode.mymovies Then

        ElseIf nSav = Savemode.Info Then


        End If


    End Sub
    Sub DeleteImages(ByVal m As Movie)
        If IO.File.Exists(m.Cover) Then
            IO.File.Delete(m.Cover)
        End If
        If m.Backdrops.Length > 0 Then
            For x As Integer = 0 To m.Backdrops.Length - 1
                If IO.File.Exists(m.Backdrops(x)) Then
                    IO.File.Delete(m.Backdrops(x))
                End If
            Next
        End If


    End Sub

    Sub ConvertImagestoXBMC(ByVal m As Movie, ByVal Replace As Boolean)
        'Cover (immer ersetzen)
        If IO.File.Exists(m.Cover) Then
            If IO.File.Exists(IO.Path.Combine(m.Pfad, "movie.tbn")) Then
                IO.File.Delete(IO.Path.Combine(m.Pfad, "movie.tbn"))
            End If
            IO.File.Copy(m.Cover, IO.Path.Combine(m.Pfad, "movie.tbn"))
        End If
        Dim fils() As String = Backdropsarr(m.Pfad, Savemode.nfo)
        Dim backs As New List(Of Bitmap)
        If fils.Length > 0 Then
            For x As Integer = 0 To fils.Length - 1
                Dim i As Bitmap = CType(MyFunctions.ImageFromJpeg(fils(x)), Bitmap)
                If Not IsNothing(i) Then
                    backs.Add(i)
                End If
            Next
        End If

        Dim vergleichen As Boolean = False
        If backs.Count = 0 Then
            vergleichen = False
        End If
        If m.Backdrops.Length > 0 Then
            For x As Integer = 0 To m.Backdrops.Length - 1

                If vergleichen = True Then
                    'Dim img2 As Bitmap = CType(MyFunctions.ImageFromJpeg(d.files(x).Destination), Bitmap)
                    Dim img2 As Bitmap = CType(Image.FromFile(m.Backdrops(x)), Bitmap)
                    If img2 Is Nothing Then
                        MsgBox("img2 ist nichts")
                    End If
                    For y As Integer = 0 To backs.Count - 1

                        'MsgBox(IO.File.Exists(d.files(x).Destination))
                        'If Not IsNothing(img2) Then
                        If MyFunctions.BitmapsEqual(CType(backs(y), Bitmap), CType(img2, Bitmap)) = True Then
                            img2.Dispose()
                            If Replace = True Then
                                IO.File.Delete(m.Backdrops(x))
                            End If

                            GoTo nextr
                        End If
                        'End If

                    Next
                    img2.Dispose()
                    Try
                        Dim s As String = ImageDestinations.Fanart_xbmc(m.Pfad)
                        If Replace = True Then
                            IO.File.Move(m.Backdrops(x), s)
                        Else
                            IO.File.Copy(m.Backdrops(x), s)
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try

                Else

                    Try
                        Dim s As String = ImageDestinations.Fanart_xbmc(m.Pfad)
                        If Replace = True Then
                            IO.File.Move(m.Backdrops(x), s)
                        Else
                            IO.File.Copy(m.Backdrops(x), s)
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical)
                    End Try
                End If
nextr:

            Next
        End If

        For Each s As Bitmap In backs
            s.Dispose()

        Next


    End Sub
    Sub ConvertImagestoMyMovies(ByVal nSav As Savemode, ByVal m As Movie, ByVal Replace As Boolean)



    End Sub
    Sub ConvertImagestoInfo(ByVal nSav As Savemode, ByVal m As Movie, ByVal Replace As Boolean)



    End Sub


End Module



Module XMLModule



    Sub Load_Series_Info(ByVal nSer As Series, ByVal s As Savemode)
        Select Case s
            Case Is = Savemode.DVDInfo
                'LoadEpisode_DVDinfo(i, p)
            Case Is = Savemode.Info
                LoadSeries_infoxml(nSer)
            Case Is = Savemode.nfo
                'LoadSeries_NFO(i, p)
            Case Is = Savemode.mymovies
                'LoadSeries_mymoviesxml(i, p)
            Case Is = Savemode.neu
                'LoadSeries_neueDatei(i, p)
        End Select
    End Sub

    Public Sub Load_Episode_Info(ByVal i As Episode, ByVal p As String, ByVal s As Savemode)
        Select Case s
            Case Is = Savemode.DVDInfo
                'LoadEpisode_DVDinfo(i, p)
            Case Is = Savemode.Info
                LoadEpisode_infoxml(i, p)
            Case Is = Savemode.nfo
                'LoadEpisode_NFO(i, p)
            Case Is = Savemode.mymovies
                'LoadEpisode_mymoviesxml(i, p)
            Case Is = Savemode.neu
                'LoadEpisode_neueDatei(i, p)
        End Select


    End Sub

    Public Sub LoadSeries(ByVal p As String, ByVal s As Savemode)

    End Sub



    Public Sub Save(ByVal m As Movie, ByVal s As Savemode)
        Select Case s
            Case Is = Savemode.DVDInfo
                SaveASDvdinfo(m)
            Case Is = Savemode.Info
                SaveASInfo(m)
            Case Is = Savemode.nfo
                SaveASnfo(m)
            Case Is = Savemode.mymovies
                SaveASMymovies(m)
        End Select
    End Sub
    Public Sub Load(ByVal m As Movie, ByVal p As String, ByVal s As Savemode)

        Select Case s
            Case Is = Savemode.DVDInfo
                LoadInfos_DVDinfo(m, p)
            Case Is = Savemode.Info
                LoadInfos_infoxml(m, p)
            Case Is = Savemode.nfo
                LoadInfos_NFO(m, p)
            Case Is = Savemode.mymovies
                LoadInfos_mymoviesxml(m, p)
            Case Is = Savemode.neu
                LoadInfos_neueDatei(m, p)
            Case Is = Savemode.oldmymovies
                LoadInfos_mymoviesxml(m, p, False, "\mymovies.xml")
        End Select

    End Sub
    Public Sub PathAnalyse(ByVal m As Movie)
        Select Case Einstellungen.Config_MediaCenter.Default_local_Source
            Case Is = Savemode.DVDInfo
                PathAnalyse_Info(m)
            Case Is = Savemode.Info
                PathAnalyse_Info(m)
            Case Is = Savemode.nfo
                PathAnalyse_NFO(m)
            Case Is = Savemode.mymovies
                PathAnalyse_Mymovies(m)
        End Select
    End Sub
    Public Function Exist(ByVal p As String, ByVal s As Savemode) As Boolean

        Select Case s
            Case Is = Savemode.DVDInfo
                Return IO.File.Exists(p + "\movie.dvdid.xml")
            Case Is = Savemode.Info
                Return IO.File.Exists(p + "\info.xml")
            Case Is = Savemode.nfo
                Return IO.File.Exists(p + "\movie.nfo")
            Case Is = Savemode.mymovies
                Return IO.File.Exists(p + "\movie.xml")
            Case Is = Savemode.oldmymovies
                Return IO.File.Exists(p + "\mymovies.xml")
            Case Else
                Return False
        End Select

    End Function
    Public Function RemoveWriteProtection(ByVal sFile As String) As Boolean
        Dim bResult As Boolean = True

        If Not File.Exists(sFile) Then
            ' Falls Datei nicht existiert...
            bResult = True
        Else
            ' aktuell gesetzte Datei-Attribute ermitteln
            Dim oInfo As New FileInfo(sFile)
            With oInfo
                Try
                    If CBool(.Attributes And FileAttributes.ReadOnly) Then



                        ' Datei ist schreibgeschützt
                        ' Jetzt Schreibschutz-Attribut entfernen
                        'MsgBox("Möchten Sie den Schreibschutz der Datei (" & IO.Path.GetDirectoryName(sFile) & ") aufheben?", MsgBoxStyle.)
                        .Attributes = .Attributes Xor FileAttributes.ReadOnly
                    End If
                Catch
                    ' Fehler beim Lesen/Setzen der Datei-Attribute
                    bResult = False
                End Try
            End With
        End If
        Return bResult
    End Function
    Public Function Converttoabsmin(ByVal MIminuten As String) As String
        Dim du As String = MIminuten
        Dim min As Integer = 0
        'MsgBox(du)
        If du.Contains("h") Then
            Dim hours As Integer = CInt(Int(du.Substring(0, du.IndexOf("h"))))
            If du.Contains("mn") And du.Contains(" ") Then
                min = CInt(Int(du.Substring(du.IndexOf(" "), du.IndexOf("mn") - du.IndexOf(" "))))
            End If
            'MsgBox(hours * 60 + min)
            Return CStr(hours * 60 + min)
        ElseIf du.Contains("mn") And du.Contains(" ") Then
            min = CInt(Int(du.Substring(0, du.IndexOf("mn"))))
            Return CStr(min)
        Else
            Return du

        End If

    End Function
    Private Function GetTMDbid(ByVal imdb As String) As String
        If imdb = "" Then
            Return ""

        End If
        Dim xml As XmlDocument ' Unser Document Container

        xml = New XmlDocument

        Try
            xml.Load(Einstellungen.UserAbrufen.tmdbapiroot & "Movie.imdbLookup/en/xml/5fe800e9f7891b9131c0059be62a36d0/" & imdb)
        Catch ex As Exception
            Return ""
        End Try
        Dim r As String = ""
        r = If(xml.SelectNodes("//id").Count > 0, xml.SelectSingleNode("//id").InnerText, "")
        Return r


    End Function
    Public Sub SaveASMymovies(ByVal m As Movie, Optional ByVal Backup As Boolean = False)
        Dim f As String = "\movie.xml"
        If Backup = True Then
            f = "\movie.bak.xml"
        End If
        Dim path As String = m.Pfad
        If RemoveWriteProtection(path + f) = True Then


            Try

                Dim enc As New System.Text.UTF8Encoding

                ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
                Dim XMLobj As Xml.XmlTextWriter _
                  = New Xml.XmlTextWriter(path + f, enc)

                With XMLobj
                    .Formatting = Xml.Formatting.Indented
                    .Indentation = 4
                    .WriteStartDocument()
                    .WriteStartElement("Title")
                    .WriteStartElement("LocalTitle") ' <Person 
                    .WriteValue(m.Titel)
                    .WriteEndElement()
                    .WriteStartElement("OriginalTitle") ' <Person 
                    .WriteValue(m.Originaltitel)
                    .WriteEndElement()
                    .WriteStartElement("SortTitle") ' <Person 
                    .WriteValue(m.Sort)
                    .WriteEndElement()
                    .WriteStartElement("Added") ' <Person 
                    .WriteValue(m.Added)
                    .WriteEndElement()

                    .WriteStartElement("ProductionYear") ' <Person 
                    .WriteValue(m.Produktionsjahr)
                    .WriteEndElement()
                    .WriteStartElement("ProductionCountry") ' <Person 
                    .WriteValue(m.Produktionsland)
                    .WriteEndElement()
                    .WriteStartElement("RunningTime") ' <Person 
                    .WriteValue(Converttoabsmin(m.Spieldauer))
                    .WriteEndElement()
                    .WriteStartElement("IMDBrating") ' <Person 
                    .WriteValue(m.Bewertung.Replace(",", "."))
                    .WriteEndElement()
                    If (m.PlayCount = "0" Or m.PlayCount = "") And m.Gesehen = "True" Then
                        m.PlayCount = "1"
                    Else
                        m.PlayCount = "0"
                    End If
                    .WriteStartElement("playcount")
                    .WriteValue(m.PlayCount)
                    .WriteEndElement()
                    .WriteStartElement("MPAARating") ' <Person 

                    If Einstellungen.Config_MediaCenter.MediaBrowser_ConvertMPAA = True Then
                        Dim mpaa As String = m.FSK
                        mpaa = mpaa.Replace("16", "R").Replace("0", "G").Replace("6", "PG").Replace("12", "PG-13").Replace("18", "NC-17")
                        .WriteValue(mpaa)
                    Else
                        .WriteValue(m.FSK)
                    End If

                    .WriteEndElement()




                    .WriteStartElement("Description") ' <Person 
                    .WriteValue(m.Inhalt)
                    .WriteEndElement()
                    .WriteStartElement("Type") ' <Person 
                    .WriteValue(m.Typ)
                    .WriteEndElement()
                    .WriteStartElement("AspectRatio") ' <Person 
                    .WriteValue(m.VideoSeitenverhältnis)
                    .WriteEndElement()
                    .WriteStartElement("LockData") ' <Person 
                    .WriteValue(m.LockData)
                    .WriteEndElement()
                    .WriteStartElement("IMDB") ' <Person 
                    .WriteValue(m.IMDB_ID)
                    .WriteEndElement()

                    .WriteStartElement("TMDbId") ' <Person 
                    'If m.TMDBId = "" Then
                    m.TMDBId = GetTMDbid(m.IMDB_ID)
                    'End If
                    .WriteValue(m.TMDBId)
                    .WriteEndElement()
                    .WriteStartElement("Genres")
                    If m.Genre <> "" Then
                        Dim genres() As String = m.Genre.Split(CChar(","))
                        For x As Integer = 0 To genres.Length - 1
                            .WriteStartElement("Genre")
                            .WriteValue(Trim(genres(x)))
                            .WriteEndElement()
                        Next
                    End If
                    .WriteEndElement()
                    .WriteStartElement("Persons")
                    Dim regie() As String = Split(m.Regisseur, ",")
                    If regie.Length > 0 Then
                        For x As Integer = 0 To regie.Length - 1
                            .WriteStartElement("Person")
                            .WriteStartElement("Name")
                            .WriteValue(Trim(regie(x)))
                            .WriteEndElement()
                            .WriteStartElement("Type")
                            .WriteValue("Director")
                            .WriteEndElement()
                            .WriteEndElement()
                        Next
                    End If

                    Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
                    If Darsteller.Length > 0 Then


                        For x As Integer = 0 To Darsteller.Length - 1
                            .WriteStartElement("Person")

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


                            .WriteStartElement("Name")
                            .WriteValue(DSname_S)
                            .WriteEndElement()
                            .WriteStartElement("Type")
                            .WriteValue("Actor")
                            .WriteEndElement()
                            .WriteStartElement("Role")
                            .WriteValue(DSrole_S)
                            .WriteEndElement()
                            .WriteEndElement()


                        Next
                    End If
                    .WriteStartElement("Author")
                    .WriteValue(m.Autoren)
                    .WriteEndElement()
                    .WriteEndElement()

                    .WriteStartElement("Studios")

                    Dim studs() As String = Split(m.Studios, ",")
                    If studs.Length > 0 Then
                        For st As Integer = 0 To studs.Length - 1
                            .WriteStartElement("Studio")
                            .WriteValue(studs(st))
                            .WriteEndElement()
                        Next
                    End If
                    .WriteEndElement()

                    '              <MediaInfo>
                    '  <Audio>
                    '    <Codec>DTS</Codec>
                    '    <Channels>6</Channels>
                    '    <BitRate />
                    '  </Audio>
                    '  <Video>
                    '    <Codec>AVC</Codec>
                    '    <BitRate />
                    '    <Height>1440</Height>
                    '    <Width>1080</Width>
                    '    <FrameRate />
                    '    <Duration />
                    '  </Video>
                    '</MediaInfo>
                    .WriteStartElement("MediaInfo")

                    .WriteStartElement("Audio")
                    .WriteStartElement("Codec")
                    .WriteValue(m.AudioCodec)
                    .WriteEndElement()
                    .WriteStartElement("Channels")
                    .WriteValue(m.AudioKanäle)
                    .WriteEndElement()
                    .WriteEndElement()


                    .WriteStartElement("Video")
                    .WriteStartElement("Framerate")
                    .WriteValue(m.VideoBildwiederholungsrate)
                    .WriteEndElement()
                    .WriteStartElement("Codec")
                    .WriteValue(m.VideoCodec)
                    .WriteEndElement()
                    .WriteStartElement("Height")
                    .WriteValue(m.VideoHöhe)
                    .WriteEndElement()
                    .WriteStartElement("Width")
                    .WriteValue(m.VideoBreite)
                    .WriteEndElement()
                    .WriteEndElement()

                    .WriteEndElement()


                    '.WriteStartElement("MediaInfo")
                    '.WriteValue(m.MediaInfo)
                    '.WriteEndElement()


                    .WriteEndElement()
                    ' ... und schließen das XML-Dokument (und die Datei) 
                    .Close() ' Document 

                End With

            Catch ex As Exception
                If MsgBox("Es ist ein Fehler beim Speichern der mymovies.xml aufgetreten." & vbCrLf & vbCrLf, MsgBoxStyle.Exclamation, "Fehler") = MsgBoxResult.Ok Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If

            End Try
        End If

    End Sub
    Public Sub SaveASInfo(ByVal m As Movie, Optional ByVal Backup As Boolean = False)
        Dim f As String = "\info.xml"
        If Backup = True Then
            f = "\info.bak.xml"
        End If
        Dim path As String = m.Pfad
        If RemoveWriteProtection(path + f) = True Then


            Try

                Dim enc As New System.Text.UTF8Encoding

                ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
                Dim XMLobj As Xml.XmlTextWriter _
                  = New Xml.XmlTextWriter(path + f, enc)

                With XMLobj
                    ' Formatierung: 4er-Einzüge verwenden 
                    .Formatting = Xml.Formatting.Indented
                    .Indentation = 4
                    .WriteStartDocument()
                    .WriteStartElement("FilmInfo ") ' <Person 
                    ' Dann fangen wir mal an: 
                    .WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                    .WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema")

                    .WriteAttributeString("Titel", m.Titel)
                    .WriteAttributeString("Orginaltitel", m.Originaltitel)
                    .WriteAttributeString("IMDB_ID", m.IMDB_ID)
                    .WriteAttributeString("Darsteller", m.Darsteller)
                    .WriteAttributeString("Regisseur", m.Regisseur)
                    .WriteAttributeString("Autoren", m.Autoren)
                    .WriteAttributeString("Studios", m.Studios)
                    .WriteAttributeString("Produktionsjahr", m.Produktionsjahr)
                    .WriteAttributeString("Produktionsland", m.Produktionsland)
                    .WriteAttributeString("Genre", m.Genre)
                    .WriteAttributeString("FSK", m.FSK)
                    .WriteAttributeString("Bewertung", m.Bewertung)
                    .WriteAttributeString("Spieldauer", m.Spieldauer)
                    .WriteAttributeString("Kurzbeschreibung", m.Kurzbeschreibung)
                    .WriteAttributeString("Inhalt", m.Inhalt)
                    .WriteAttributeString("MediaInfo", m.MediaInfo)
                    .WriteAttributeString("Position", m.Position)
                    .WriteAttributeString("Datum", m.Datum)
                    .WriteAttributeString("Sort", m.Sort)
                    .WriteAttributeString("VideoAuflösung", m.VideoAuflösung)
                    .WriteAttributeString("VideoSeitenverhältnis", m.VideoSeitenverhältnis)
                    .WriteAttributeString("VideoBildwiederholungsrate", m.VideoBildwiederholungsrate)
                    .WriteAttributeString("VideoCodec", m.VideoCodec)
                    .WriteAttributeString("VideoHöhe", m.VideoHöhe)
                    .WriteAttributeString("VideoBreite", m.VideoBreite)
                    .WriteAttributeString("AudioKanäle", m.AudioKanäle)
                    .WriteAttributeString("AudioCodec", m.AudioCodec)
                    .WriteAttributeString("AudioSprachen", m.AudioSprachen)


                    .WriteEndElement()
                    .Close() ' Document 
                End With


            Catch ex As Exception
                If MsgBox("Es ist ein Fehler beim speichern der Info.xml aufgetreten." & vbCrLf & "Möchten Sie den Fehlertext zur möglichen Fehlerbehebung anzeigen?", MsgBoxStyle.Exclamation, "Fehler") = MsgBoxResult.Ok Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace.ToString)

                End If

            End Try

        End If


    End Sub
    Public Sub SaveASDvdinfo(ByVal m As Movie)
        If Not m.DVDChacheID = m.IMDB_ID Then
            Try
                IO.File.Delete(IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaCenter_Windows_pfad, Renamer.CheckInvalid_F(m.DVDChacheID) + ".xml"))
            Catch ex As Exception

            End Try
            m.DVDChacheID = m.IMDB_ID
        End If

        If m.DVDChacheID = "" Then
random:     m.DVDChacheID = IO.Path.GetRandomFileName

            If IO.File.Exists(IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaCenter_Windows_pfad, Renamer.CheckInvalid_F(m.DVDChacheID) + ".xml")) Then
                GoTo random
            End If



        End If


        Dim enc As New System.Text.UTF8Encoding
        Dim path As String = m.Pfad
        ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
        Dim XMLobj As Xml.XmlTextWriter _
          = New Xml.XmlTextWriter(path + "\movie.dvdid.xml", enc)

        With XMLobj
            ' Formatierung: 4er-Einzüge verwenden 
            .Formatting = Xml.Formatting.Indented
            .Indentation = 4
            .WriteStartDocument()
            .WriteStartElement("DISC") ' <Person 
            .WriteStartElement("NAME")
            .WriteValue(m.Titel)
            .WriteEndElement()
            .WriteStartElement("ID")
            .WriteValue(m.DVDChacheID)
            .WriteEndElement()
            .WriteEndElement()
            .Close() ' Document 
        End With
        '"C:\Users\Basti\AppData\Roaming\Microsoft\eHome\DvdInfoCache"
        Dim finalpath As String = IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaCenter_Windows_pfad, m.DVDChacheID + ".xml")
        'MsgBox(finalpath)
        If IO.Directory.Exists(Einstellungen.Config_MediaCenter.MediaCenter_Windows_pfad) Then


            XMLobj = New Xml.XmlTextWriter(finalpath, enc)

            With XMLobj
                ' Formatierung: 4er-Einzüge verwenden 
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4
                .WriteStartDocument()
                .WriteStartElement("METADATA") ' <Meta 
                .WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                .WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema")

                .WriteStartElement("MDR-DVD")

                .WriteStartElement("MetadataExpires")
                .WriteValue("0001-01-01T00:00:00")
                .WriteEndElement()
                .WriteStartElement("version")
                .WriteValue("5.0")
                .WriteEndElement()
                .WriteStartElement("dvdTitle")
                .WriteValue(m.Titel)
                .WriteEndElement()
                .WriteStartElement("studio")
                .WriteValue(m.Studios)
                .WriteEndElement()
                .WriteStartElement("leadPerformer")
                .WriteValue(m.Darsteller)
                .WriteEndElement()
                .WriteStartElement("director")
                .WriteValue(m.Regisseur)
                .WriteEndElement()
                .WriteStartElement("MPAARating")
                .WriteValue(m.FSK)
                .WriteEndElement()
                .WriteStartElement("releaseDate")
                .WriteValue(m.Produktionsjahr)
                .WriteEndElement()
                .WriteStartElement("genre")
                .WriteValue(m.Genre)
                .WriteEndElement()
                .WriteStartElement("duration")
                .WriteValue(m.Spieldauer)
                .WriteEndElement()

                .WriteStartElement("title")
                .WriteStartElement("titleNum")
                .WriteValue("1")
                .WriteEndElement()
                .WriteStartElement("titleTitle")
                .WriteValue(m.Titel)
                .WriteEndElement()
                .WriteStartElement("studio")
                .WriteValue(m.Studios)
                .WriteEndElement()
                .WriteStartElement("leadPerformer")
                .WriteValue(m.Darsteller)
                .WriteEndElement()
                .WriteStartElement("director")
                .WriteValue(m.Regisseur)
                .WriteEndElement()
                .WriteStartElement("MPAARating")
                .WriteValue(m.FSK)
                .WriteEndElement()
                .WriteStartElement("releaseDate")
                .WriteValue(m.Produktionsjahr)
                .WriteEndElement()
                .WriteStartElement("genre")
                .WriteValue(m.Genre)
                .WriteEndElement()
                .WriteStartElement("synopsis")
                .WriteValue(m.Inhalt)
                .WriteEndElement()


                .WriteEndElement() '/title

                .WriteEndElement() '/mdr


                .WriteStartElement("NeedsAttribution")
                .WriteValue(True)
                .WriteEndElement()
                .WriteStartElement("DvdId")
                .WriteValue(m.IMDB_ID)
                .WriteEndElement()

                .WriteEndElement() 'meta
                .Close() ' Document 
            End With
        End If
        'Catch ex As Exception
        '    If MsgBox("Es ist ein Fehler beim speichern der Info.xml aufgetreten." & vbCrLf & "Möchten Sie den Fehlertext zur möglichen Fehlerbehebung anzeigen?", MsgBoxStyle.Exclamation, "Fehler") = MsgBoxResult.Ok Then
        '        MsgBox(ex.Message)

        '    End If

        'End Try


    End Sub
    Public Sub SaveASnfo(ByVal m As Movie, Optional ByVal Backup As Boolean = False)
        Dim f As String = "\movie.nfo"
        If Backup = True Then
            f = "\movie.bak.nfo"
        End If
        Dim path As String = m.Pfad
        If RemoveWriteProtection(path + f) = True Then

            Try

                Dim enc As New System.Text.UTF8Encoding

                ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
                Dim XMLobj As Xml.XmlTextWriter _
                  = New Xml.XmlTextWriter(path + f, enc)

                With XMLobj
                    .Formatting = Xml.Formatting.Indented
                    .Indentation = 4

                    .WriteStartDocument()
                    .WriteStartElement("movie")
                    ' Dann fangen wir mal an: 
                    .WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
                    .WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema")

                    .WriteStartElement("title")
                    .WriteValue(m.Titel)
                    .WriteEndElement()

                    .WriteStartElement("originaltitle")
                    .WriteValue(m.Originaltitel)
                    .WriteEndElement()

                    .WriteStartElement("sorttitle")
                    .WriteValue(m.Sort)
                    .WriteEndElement()

                    .WriteStartElement("rating")
                    .WriteValue(m.Bewertung)
                    .WriteEndElement()

                    .WriteStartElement("country")
                    .WriteValue(m.Produktionsland)
                    .WriteEndElement()

                    .WriteStartElement("year")
                    .WriteValue(m.Produktionsjahr)
                    .WriteEndElement()

                    .WriteStartElement("outline")
                    .WriteValue(m.Inhalt)
                    .WriteEndElement()

                    .WriteStartElement("plot")
                    .WriteValue(m.Inhalt)
                    .WriteEndElement()

                    .WriteStartElement("runtime")
                    .WriteValue(m.Spieldauer)
                    .WriteEndElement()
                    .WriteStartElement("mpaa")
                    .WriteValue(m.FSK)
                    .WriteEndElement()
                    .WriteStartElement("id")
                    .WriteValue(m.IMDB_ID)
                    .WriteEndElement()
                    .WriteStartElement("genre")
                    .WriteValue(m.Genre.Replace(",", " /"))
                    .WriteEndElement()
                    If (m.PlayCount = "0" Or m.PlayCount = "") And m.Gesehen = "True" Then
                        m.PlayCount = "1"
                    Else
                        m.PlayCount = "0"
                    End If
                    .WriteStartElement("playcount")
                    .WriteValue(m.PlayCount)
                    .WriteEndElement()
                    .WriteStartElement("watched")
                    .WriteValue(m.Gesehen)
                    .WriteEndElement()
                    .WriteStartElement("set")
                    .WriteValue(m.Setbox)
                    .WriteEndElement()


                    .WriteStartElement("director")
                    .WriteValue(m.Regisseur.Replace(",", " /"))
                    .WriteEndElement()


                    .WriteStartElement("author")
                    .WriteValue(m.Autoren.Replace(",", " /"))
                    .WriteEndElement()
                    Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
                    If Darsteller.Length > 0 Then


                        For x As Integer = 0 To Darsteller.Length - 1
                            .WriteStartElement("actor")

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


                            .WriteStartElement("name")
                            .WriteValue(DSname_S)
                            .WriteEndElement()
                            .WriteStartElement("role")
                            .WriteValue(DSrole_S)
                            .WriteEndElement()
                            .WriteEndElement()
                        Next
                    End If

                    '.WriteStartElement("Author")
                    '.WriteValue(m.Autoren)
                    '.WriteEndElement()
                    '.WriteEndElement()

                    .WriteStartElement("studio")
                    .WriteValue(m.Studios)
                    .WriteEndElement()

                    'http://wiki.xbmc.org/index.php?title=Import_-_Export_Library#Video_nfo_Files

                    .WriteStartElement("fileinfo")
                    .WriteStartElement("streamdetails")
                    .WriteStartElement("video")

                    .WriteStartElement("codec")
                    .WriteValue(m.VideoCodec)
                    .WriteEndElement()
                    .WriteStartElement("framerate")
                    .WriteValue(m.VideoBildwiederholungsrate)
                    .WriteEndElement()
                    .WriteStartElement("aspect")
                    .WriteValue(m.VideoSeitenverhältnis.Replace(",", "."))
                    .WriteEndElement()
                    .WriteStartElement("height")
                    .WriteValue(m.VideoHöhe)
                    .WriteEndElement()
                    .WriteStartElement("width")
                    .WriteValue(m.VideoBreite)
                    .WriteEndElement()

                    .WriteEndElement()

                    .WriteStartElement("audio")

                    .WriteStartElement("codec")
                    .WriteValue(m.AudioCodec)
                    .WriteEndElement()
                    .WriteStartElement("language")
                    .WriteValue(m.AudioSprachen)
                    .WriteEndElement()
                    .WriteStartElement("channels")
                    .WriteValue(m.AudioKanäle)
                    .WriteEndElement()

                    .WriteEndElement()

                    .WriteStartElement("mediainfo")
                    .WriteValue(m.MediaInfo)
                    .WriteEndElement()

                    .WriteEndElement()
                    .WriteEndElement()

                    .WriteEndElement()
                    ' ... und schließen das XML-Dokument (und die Datei) 
                    .Close() ' Document 

                End With

            Catch ex As Exception
                If MsgBox("Es ist ein Fehler beim Speichern der mymovies.xml aufgetreten." & vbCrLf & vbCrLf, MsgBoxStyle.Exclamation, "Fehler") = MsgBoxResult.Ok Then
                    MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                End If

            End Try

        End If

    End Sub
#Region "Laden"
    Public Sub LoadInfos_NFO(ByVal i As Movie, ByVal path As String, Optional ByVal Backup As Boolean = False)
        Dim f As String = "\movie.nfo"
        If Backup = True Then
            f = "\movie.bak.nfo"
        End If
        With i

            .Pfad = path
            PathAnalyse_NFO(i)

            'XML laden
            Dim xml As New Xml.XmlDocument
            xml.Load(path + f)
            Dim xpath As String 'variabele

            'Die Felder füllen (eines nach dem anderen)

            .Titel = If(xml.SelectNodes("//title").Count > 0, xml.SelectSingleNode("//title").InnerText, "")
            .Originaltitel = If(xml.SelectNodes("//originaltitle").Count > 0, xml.SelectSingleNode("//originaltitle").InnerText, "")
            .IMDB_ID = If(xml.SelectNodes("//id").Count > 0, xml.SelectSingleNode("//id").InnerText, "")

            .Produktionsjahr = If(xml.SelectNodes("//year").Count > 0, xml.SelectSingleNode("//year").InnerText, "")
            .Produktionsland = If(xml.SelectNodes("//country").Count > 0, xml.SelectSingleNode("//country").InnerText, "")
            .PlayCount = If(xml.SelectNodes("//playcount").Count > 0, xml.SelectSingleNode("//playcount").InnerText, "")
            .FSK = If(xml.SelectNodes("//mpaa").Count > 0, xml.SelectSingleNode("//mpaa").InnerText, "")
            .Bewertung = If(xml.SelectNodes("//rating").Count > 0, xml.SelectSingleNode("//rating").InnerText, "")



            .Spieldauer = If(xml.SelectNodes("//runtime").Count > 0, xml.SelectSingleNode("//runtime").InnerText, "")
            .Inhalt = If(xml.SelectNodes("//outline").Count > 0, xml.SelectSingleNode("//outline").InnerText, "")
            .Kurzbeschreibung = If(xml.SelectNodes("//plot").Count > 0, xml.SelectSingleNode("//plot").InnerText, "")
            .MediaInfo = If(xml.SelectNodes("//mediainfo").Count > 0, xml.SelectSingleNode("//mediainfo").InnerText, "")
            .Sort = If(xml.SelectNodes("//sorttitle").Count > 0, xml.SelectSingleNode("//sorttitle").InnerText, "")
            .Gesehen = "False"
            .Regisseur = If(xml.SelectNodes("//director").Count > 0, xml.SelectSingleNode("//director").InnerText.Replace(" /", ",").Replace("/", ","), "")
            .Autoren = If(xml.SelectNodes("//author").Count > 0, xml.SelectSingleNode("//author").InnerText.Replace(" /", ",").Replace("/", ","), "")
            .Gesehen = If(xml.SelectNodes("//watched").Count > 0, xml.SelectSingleNode("//watched").InnerText, "")
            .Setbox = If(xml.SelectNodes("//set").Count > 0, xml.SelectSingleNode("//set").InnerText, "")


            If (.PlayCount = "0" Or .PlayCount = "") Then
            Else
                .Gesehen = "True"
            End If

            '.VideoAuflösung = If(xml.SelectNodes("//Videoresolution").Count > 0, xml.SelectSingleNode("//Videoresolution").InnerText, "")
            '.VideoSeitenverhältnis = If(xml.SelectNodes("//AspectRatio").Count > 0, xml.SelectSingleNode("//AspectRatio").InnerText, "")
            '.VideoBildwiederholungsrate = If(xml.SelectNodes("//VideoFramerate").Count > 0, xml.SelectSingleNode("//VideoFramerate").InnerText, "")
            '.VideoCodec = If(xml.SelectNodes("//VideoCodec").Count > 0, xml.SelectSingleNode("//VideoCodec").InnerText, "")
            '.AudioKanäle = If(xml.SelectNodes("//AudioChannel").Count > 0, xml.SelectSingleNode("//AudioChannel").InnerText, "")
            '.AudioCodec = If(xml.SelectNodes("//AudioCodec").Count > 0, xml.SelectSingleNode("//AudioCodec").InnerText, "")
            '.AudioSprachen = If(xml.SelectNodes("//AudioLanguage").Count > 0, xml.SelectSingleNode("//AudioLanguage").InnerText, "")




            'i.LockData = If(xml.SelectNodes("//LockData").Count > 0, xml.SelectSingleNode("//LockData").InnerText, "")
            'i.TMDBId = If(xml.SelectNodes("//TMDBId").Count > 0, xml.SelectSingleNode("//TMDBId").InnerText, "")
            'i.Type = If(xml.SelectNodes("//Type").Count > 0, xml.SelectSingleNode("//Type").InnerText, "")
            'i.Added = If(xml.SelectNodes("//Added").Count > 0, xml.SelectSingleNode("//Added").InnerText, "")

            .Genre = If(xml.SelectNodes("//genre").Count > 0, xml.SelectSingleNode("//genre").InnerText.Replace(" /", ",").Replace("/", ","), "")
            .Studios = If(xml.SelectNodes("//studio").Count > 0, xml.SelectSingleNode("//studio").InnerText, "")



            xpath = "//actor"
            Dim darsteller As String = ""
            Dim mx As Integer = xml.SelectNodes(xpath).Count
            Dim xmln As XmlNode
            If mx > 0 Then
                For x As Integer = 0 To mx - 1
                    xmln = xml.SelectNodes(xpath).Item(x)
                    Dim name As String = ""
                    Dim Typ As String = ""
                    Dim Role As String = ""
                    If xmln.ChildNodes.Count > 0 Then
                        For i2 As Integer = 0 To xmln.ChildNodes.Count - 1
                            Select Case xmln.ChildNodes(i2).Name
                                Case Is = "name"
                                    name = xmln.ChildNodes(i2).InnerText
                                Case Is = "role"
                                    Role = xmln.ChildNodes(i2).InnerText
                            End Select
                        Next
                        If darsteller = "" Then
                            darsteller = name
                        Else
                            darsteller &= ", " & name
                        End If
                        If Role = "" Or Role = " " Then
                        Else
                            darsteller &= " [" & Role & "]"
                        End If

                    End If
                Next
            End If

            .Darsteller = darsteller





            xpath = "//video"
            Dim nNode As XmlNode

            mx = xml.SelectNodes(xpath).Count
            If mx > 0 Then
                nNode = xml.SelectSingleNode(xpath)
                If nNode.HasChildNodes Then
                    For x As Integer = 0 To nNode.ChildNodes.Count - 1
                        Select Case nNode.ChildNodes(x).Name
                            Case Is = "aspect"
                                .VideoSeitenverhältnis = nNode.ChildNodes(x).InnerText
                            Case Is = "codec"
                                .VideoCodec = nNode.ChildNodes(x).InnerText
                            Case Is = "framerate"
                                .VideoBildwiederholungsrate = nNode.ChildNodes(x).InnerText
                            Case Is = "height"
                                .VideoHöhe = nNode.ChildNodes(x).InnerText
                            Case Is = "width"
                                .VideoBreite = nNode.ChildNodes(x).InnerText
                        End Select
                    Next
                End If
            End If
            .VideoAuflösung = MediaInfoFunctions.GetVAuflösung(.VideoHöhe, .VideoBreite)

            xpath = "//audio"

            mx = xml.SelectNodes(xpath).Count

            If mx > 0 Then
                nNode = xml.SelectSingleNode(xpath)
                If nNode.HasChildNodes Then
                    For x As Integer = 0 To nNode.ChildNodes.Count - 1
                        Select Case nNode.ChildNodes(x).Name
                            Case Is = "codec"
                                .AudioCodec = nNode.ChildNodes(x).InnerText
                            Case Is = "language"
                                .AudioSprachen = nNode.ChildNodes(x).InnerText
                            Case Is = "channels"
                                .AudioKanäle = nNode.ChildNodes(x).InnerText
                        End Select
                    Next
                End If
            End If

        End With
    End Sub
    Public Sub LoadInfos_infoxml(ByVal i As Movie, ByVal path As String, Optional ByVal Backup As Boolean = False)
        Dim f As String = "\info.xml"
        If Backup = True Then
            f = "\info.bak.xml"
        End If
        i.Pfad = path
        PathAnalyse_Info(i)
        Dim XMLReader As Xml.XmlReader _
             = New Xml.XmlTextReader(path + f)
        With XMLReader
            .ReadToFollowing("FilmInfo")

            'Beginn zu laden
            i.Titel = .GetAttribute("Titel")
            i.Originaltitel = .GetAttribute("Orginaltitel")
            i.IMDB_ID = .GetAttribute("IMDB_ID")
            i.Darsteller = .GetAttribute("Darsteller")
            i.Regisseur = .GetAttribute("Regisseur")
            i.Autoren = .GetAttribute("Autoren")
            i.Studios = .GetAttribute("Studios")
            i.Produktionsjahr = .GetAttribute("Produktionsjahr")
            i.Produktionsland = .GetAttribute("Produktionsland")
            i.Genre = .GetAttribute("Genre")
            i.FSK = .GetAttribute("FSK")
            i.Bewertung = .GetAttribute("Bewertung")
            i.Spieldauer = .GetAttribute("Spieldauer")
            i.Kurzbeschreibung = .GetAttribute("Kurzbeschreibung")
            i.Inhalt = .GetAttribute("Inhalt")
            i.MediaInfo = .GetAttribute("MediaInfo")
            i.Position = .GetAttribute("Position")
            i.Datum = .GetAttribute("Datum")
            If i.Datum = "" Then
                i.Gesehen = "False"
            Else
                i.Gesehen = "True"
            End If
            i.Sort = .GetAttribute("Sort")
            i.VideoAuflösung = .GetAttribute("VideoAuflösung")
            i.VideoSeitenverhältnis = .GetAttribute("VideoSeitenverhältnis")
            i.VideoBreite = .GetAttribute("VideoBreite")
            i.VideoHöhe = .GetAttribute("VideoHöhe")
            i.VideoBildwiederholungsrate = .GetAttribute("VideoBildwiederholungsrate")
            i.VideoCodec = .GetAttribute("VideoCodec")
            i.AudioKanäle = .GetAttribute("AudioKanäle")
            i.AudioCodec = .GetAttribute("AudioCodec")
            i.AudioSprachen = .GetAttribute("AudioSprachen")
            .Close()
        End With







    End Sub
    Public Sub LoadInfos_mymoviesxml(ByVal i As Movie, ByVal path As String, Optional ByVal Backup As Boolean = False, Optional ByVal f As String = "\movie.xml")

        If Backup = True Then
            f = "\movie.bak.xml"
        End If
        Try


            With i
                .Pfad = path
                PathAnalyse_Mymovies(i)


                'XML laden
                Dim xml As New Xml.XmlDocument
                xml.Load(path + f)
                Dim xpath As String 'variabele

                'Die Felder füllen (eines nach dem anderen)

                .Titel = If(xml.SelectNodes("//LocalTitle").Count > 0, xml.SelectSingleNode("//LocalTitle").InnerText, "")
                .Originaltitel = If(xml.SelectNodes("//OriginalTitle").Count > 0, xml.SelectSingleNode("//OriginalTitle").InnerText, "")
                .IMDB_ID = If(xml.SelectNodes("//IMDB").Count > 0, xml.SelectSingleNode("//IMDB").InnerText, "")
                .Gesehen = "False"
                .Gesehen = If(xml.SelectNodes("//watched").Count > 0, xml.SelectSingleNode("//watched").InnerText, "")
                .PlayCount = If(xml.SelectNodes("//playcount").Count > 0, xml.SelectSingleNode("//playcount").InnerText, "")

                If (.PlayCount = "0" Or .PlayCount = "") Then
                Else
                    .Gesehen = "True"
                End If


                xpath = "//Person"
                Dim darsteller As String = ""
                Dim regie As String = ""
                Dim mx As Integer = xml.SelectNodes(xpath).Count
                Dim xmln As XmlNode
                If mx > 0 Then
                    For x As Integer = 0 To mx - 1
                        xmln = xml.SelectNodes(xpath).Item(x)
                        Dim name As String = ""
                        Dim Typ As String = ""
                        Dim Role As String = ""
                        If xmln.ChildNodes.Count > 0 Then
                            For i2 As Integer = 0 To xmln.ChildNodes.Count - 1
                                Select Case xmln.ChildNodes(i2).Name
                                    Case Is = "Name"
                                        name = xmln.ChildNodes(i2).InnerText
                                    Case Is = "Type"
                                        Typ = xmln.ChildNodes(i2).InnerText
                                    Case Is = "Role"
                                        Role = xmln.ChildNodes(i2).InnerText
                                End Select
                            Next
                            Select Case Typ
                                Case Is = "Actor"
                                    If darsteller = "" Then
                                        darsteller = name
                                    Else
                                        darsteller &= ", " & name
                                    End If
                                    If Role = "" Or Role = " " Then
                                    Else
                                        darsteller &= " [" & Role & "]"
                                    End If
                                Case Is = "Director"
                                    If regie = "" Then
                                        regie = name
                                    Else
                                        regie &= ", " & name
                                    End If
                            End Select
                        End If
                    Next
                End If

                .Darsteller = darsteller
                .Regisseur = regie

                .Autoren = If(xml.SelectNodes("//Author").Count > 0, xml.SelectSingleNode("//Author").InnerText, "")

                xpath = "//Studio"
                mx = xml.SelectNodes(xpath).Count
                Dim studios As String = ""
                If mx > 0 Then
                    For x As Integer = 0 To mx - 1
                        xmln = xml.SelectNodes(xpath).Item(x)
                        If studios = "" Then
                            studios = xmln.InnerText
                        Else
                            studios &= ", " & xmln.InnerText
                        End If

                    Next
                End If

                .Studios = studios



                .Produktionsjahr = If(xml.SelectNodes("//ProductionYear").Count > 0, xml.SelectSingleNode("//ProductionYear").InnerText, "")
                .Produktionsland = If(xml.SelectNodes("//ProductionCountry").Count > 0, xml.SelectSingleNode("//ProductionCountry").InnerText, "")

                xpath = "//Genre"
                mx = xml.SelectNodes(xpath).Count
                Dim genre As String = ""
                If mx > 0 Then
                    For x As Integer = 0 To mx - 1
                        xmln = xml.SelectNodes(xpath).Item(x)
                        If genre = "" Then
                            genre = xmln.InnerText
                        Else
                            genre &= ", " & xmln.InnerText
                        End If

                    Next
                End If
                .Genre = genre

                .FSK = If(xml.SelectNodes("//MPAARating").Count > 0, xml.SelectSingleNode("//MPAARating").InnerText, "")
                If .FSK = "" Then
                    .FSK = If(xml.SelectNodes("//FSK").Count > 0, xml.SelectSingleNode("//FSK").InnerText, "")
                End If
                If Einstellungen.Config_MediaCenter.MediaBrowser_ConvertMPAA = True Then
                    .FSK = .FSK.Replace("PG-13", "12").Replace("PG", "6").Replace("R", "16").Replace("NC-17", "18").Replace("G", "0")
                End If

                .Bewertung = If(xml.SelectNodes("//IMDBrating").Count > 0, xml.SelectSingleNode("//IMDBrating").InnerText, "")

                .Spieldauer = If(xml.SelectNodes("//RunningTime").Count > 0, xml.SelectSingleNode("//RunningTime").InnerText, "")
                .Inhalt = If(xml.SelectNodes("//Description").Count > 0, xml.SelectSingleNode("//Description").InnerText, "")
                .Kurzbeschreibung = If(xml.SelectNodes("//Description").Count > 0, xml.SelectSingleNode("//Description").InnerText, "")
                .MediaInfo = If(xml.SelectNodes("//MediaInfo").Count > 0, xml.SelectSingleNode("//MediaInfo").InnerText, "")
                .Sort = If(xml.SelectNodes("//SortTitle").Count > 0, xml.SelectSingleNode("//SortTitle").InnerText, "")

                '              <MediaInfo>
                '  <Audio>
                '    <Codec>DTS</Codec>
                '    <Channels>6</Channels>
                '    <BitRate />
                '  </Audio>
                '  <Video>
                '    <Codec>AVC</Codec>
                '    <BitRate />
                '    <Height>1440</Height>
                '    <Width>1080</Width>
                '    <FrameRate />
                '    <Duration />
                '  </Video>
                '</MediaInfo>
                Dim vxml As XmlNode
                If xml.SelectNodes("//Codec").Count > 0 Then
                    For x As Integer = 0 To xml.SelectNodes("//Codec").Count - 1
                        vxml = xml.SelectNodes("//Codec").Item(x)
                        If vxml.ParentNode.Name = "Video" Then
                            .VideoCodec = vxml.InnerText
                        ElseIf vxml.ParentNode.Name = "Audio" Then
                            .AudioCodec = vxml.InnerText
                        End If
                    Next

                End If
                'If xml.SelectNodes("//Audio").Count > 0 Then
                '    vxml = xml.SelectNodes("//Audio").Item(0)
                '    .AudioCodec = If(vxml.SelectNodes("//Codec").Count > 0, vxml.SelectSingleNode("//Codec").InnerText, "")

                '    '.VideoWidth = If(xml.SelectNodes("//Width").Count > 0, xml.SelectSingleNode("//Width").InnerText, "")


                'End If
                .VideoBildwiederholungsrate = If(xml.SelectNodes("//Framerate").Count > 0, xml.SelectSingleNode("//Framerate").InnerText, "")
                .VideoHöhe = If(xml.SelectNodes("//Height").Count > 0, xml.SelectSingleNode("//Height").InnerText, "")
                .VideoBreite = If(xml.SelectNodes("//Width").Count > 0, xml.SelectSingleNode("//Width").InnerText, "")
                .AudioKanäle = If(xml.SelectNodes("//Channels").Count > 0, xml.SelectSingleNode("//Channels").InnerText, "")
                .AudioSprachen = Einstellungen.Config_Abrufen.Abrufen_MediaInfo_StandardSprache
                '.VideoAuflösung = If(xml.SelectNodes("//Videoresolution").Count > 0, xml.SelectSingleNode("//Videoresolution").InnerText, "")
                .VideoSeitenverhältnis = If(xml.SelectNodes("//AspectRatio").Count > 0, xml.SelectSingleNode("//AspectRatio").InnerText, "")
                '.VideoBildwiederholungsrate = If(xml.SelectNodes("//VideoFramerate").Count > 0, xml.SelectSingleNode("//VideoFramerate").InnerText, "")
                '.VideoCodec = If(xml.SelectNodes("//VideoCodec").Count > 0, xml.SelectSingleNode("//VideoCodec").InnerText, "")
                '.AudioKanäle = If(xml.SelectNodes("//AudioChannel").Count > 0, xml.SelectSingleNode("//AudioChannel").InnerText, "")
                '.AudioCodec = If(xml.SelectNodes("//AudioCodec").Count > 0, xml.SelectSingleNode("//AudioCodec").InnerText, "")
                '.AudioSprachen = If(xml.SelectNodes("//AudioLanguage").Count > 0, xml.SelectSingleNode("//AudioLanguage").InnerText, "")
                .VideoAuflösung = MediaInfoFunctions.GetVAuflösung(.VideoHöhe, .VideoBreite)



                i.LockData = If(xml.SelectNodes("//LockData").Count > 0, xml.SelectSingleNode("//LockData").InnerText, "")
                i.TMDBId = If(xml.SelectNodes("//TMDBId").Count > 0, xml.SelectSingleNode("//TMDBId").InnerText, "")
                i.Typ = If(xml.SelectNodes("//Type").Count > 0, xml.SelectSingleNode("//Type").InnerText, "")
                i.Added = If(xml.SelectNodes("//Added").Count > 0, xml.SelectSingleNode("//Added").InnerText, "")


            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            LoadInfos_neueDatei(i, path)
        End Try
    End Sub
    Public Sub LoadInfos_DVDinfo(ByVal i As Movie, ByVal Path As String)
        With i
            .Pfad = Path
            PathAnalyse_Info(i)
            GetDVDInfoID(i)
            '.DVDChacheID = id
            'MsgBox(id)
            If Not .DVDChacheID = "" Then


                Dim finalpath As String = IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaCenter_Windows_pfad, .DVDChacheID + ".xml")
                If IO.File.Exists(finalpath) Then
                    Dim xml As New Xml.XmlDocument
                    xml.Load(finalpath)

                    'Die Felder füllen (eines nach dem anderen)

                    .Titel = If(xml.SelectNodes("//dvdTitle").Count > 0, xml.SelectSingleNode("//dvdTitle").InnerText, "")
                    .Studios = If(xml.SelectNodes("//studio").Count > 0, xml.SelectSingleNode("//studio").InnerText, "")
                    .Darsteller = If(xml.SelectNodes("//leadPerformer").Count > 0, xml.SelectSingleNode("//leadPerformer").InnerText, "")
                    .Regisseur = If(xml.SelectNodes("//director").Count > 0, xml.SelectSingleNode("//director").InnerText, "")
                    .FSK = If(xml.SelectNodes("//MPAARating").Count > 0, xml.SelectSingleNode("//MPAARating").InnerText, "")
                    .Produktionsjahr = If(xml.SelectNodes("//releaseDate").Count > 0, xml.SelectSingleNode("//releaseDate").InnerText, "")
                    .Genre = If(xml.SelectNodes("//genre").Count > 0, xml.SelectSingleNode("//genre").InnerText, "")
                    .Spieldauer = If(xml.SelectNodes("//duration").Count > 0, xml.SelectSingleNode("//duration").InnerText, "")
                    .Originaltitel = If(xml.SelectNodes("//titleTitle").Count > 0, xml.SelectSingleNode("//titleTitle").InnerText, "")
                    .Inhalt = If(xml.SelectNodes("//synopsis").Count > 0, xml.SelectSingleNode("//synopsis").InnerText, "")
                    .IMDB_ID = If(xml.SelectNodes("//DvdId").Count > 0, xml.SelectSingleNode("//DvdId").InnerText, "")
                    .Kurzbeschreibung = .Inhalt
                End If
            End If
        End With

    End Sub
    Private Sub LoadInfos_neueDatei(ByVal i As Movie, ByVal path As String)
        With i
            .Pfad = path
            .Ordner = IO.Path.GetFileName(path)
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                If IO.File.Exists(IO.Path.Combine(path, "movie.tbn")) Then
                    .Cover = IO.Path.Combine(path, "movie.tbn")
                End If
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
                If IO.File.Exists(IO.Path.Combine(path, "folder.jpg")) Then
                    .Cover = IO.Path.Combine(path, "folder.jpg")
                ElseIf IO.File.Exists(IO.Path.Combine(path, "folder.png")) Then
                    .Cover = IO.Path.Combine(path, "folder.png")
                End If
            Else
                If IO.File.Exists(IO.Path.Combine(path, "folder.jpg")) Then
                    .Cover = IO.Path.Combine(path, "folder.jpg")
                End If
            End If
            .Erstelldatum = IO.Directory.GetLastWriteTime(path)
            .Foldersize = FolderSize.GetFolderSize(path)
            .Files = Get_Moviepaths_in_array(path)

            'Ersetzen zeug
            .Titel = .Ordner
            If .Titel.Contains("(") And Not .Titel.IndexOf("(") = 0 Then
                .Titel = .Titel.Substring(0, .Titel.IndexOf("("))
            End If
            If .Titel.Contains("[") And Not .Titel.IndexOf("[") = 0 Then
                .Titel = .Titel.Substring(0, .Titel.IndexOf("["))
            End If
            .Produktionsjahr = FileNameFilter.GetYearinFolderName(.Ordner)
            .Titel = FileNameFilter.ReplaceFolderName(.Titel)
            .Titel = .Titel.Replace(".", " ").Replace("_", " ")
            .flag = 2
            .Originaltitel = .Titel
            .Sort = .Titel
        End With


        '-----------------------
        ''Media Info überprüfen:
        '-----------------------

        'If i.Darsteller.ToString.Contains("...") Then
        '    i.Darsteller = i.Darsteller.ToString.Replace("... ", "")
        '    i.Darsteller = i.Darsteller.ToString.Replace("...", "")
        '    XMLModule.SaveASInfo(i)
        'End If





    End Sub
    Private Sub GetDVDInfoID(ByVal m As Movie)
        Dim f() As String = IO.Directory.GetFiles(m.Pfad, "*.dvdid.xml")
        Dim r As String = ""
        If f.Length > 0 Then
            Dim xml As New Xml.XmlDocument
            xml.Load(f(0))

            m.DVDChacheID = If(xml.SelectNodes("//ID").Count > 0, xml.SelectSingleNode("//ID").InnerText, "")
            m.Titel = If(xml.SelectNodes("//NAME").Count > 0, xml.SelectSingleNode("//NAME").InnerText, "")
            If m.Titel = "" Then
                m.Titel = m.Ordner.Replace(".", " ").Replace("_", " ")
            End If

            m.Originaltitel = m.Titel
            m.Sort = m.Titel

        End If
    End Sub
#End Region
#Region "Ordner"



    Public Sub PathAnalyse_Info(ByVal i As Movie)
        Dim path As String = i.Pfad
        With i
            .Pfad = path
            .Ordner = IO.Path.GetFileName(path)
            If IO.File.Exists(IO.Path.Combine(path, "folder.jpg")) Then
                .Cover = IO.Path.Combine(path, "folder.jpg")
                .Coversize = FileLen(.Cover)

                'If Einstellungen.Config_Fortschritt.Fortschritt_cover = True Then
                '    Dim c As Image = MyFunctions.ImageFromJpeg(.Cover)
                '    'MsgBox(.Titel & "#" & c.Height)
                '    If Not IsNothing(c) Then
                '        .Cover_height = c.Height
                '        .Cover_width = c.Width
                '        c.Dispose()
                '    End If
                'End If
            ElseIf IO.File.Exists(IO.Path.Combine(path, "folder.png")) Then
                .Cover = IO.Path.Combine(path, "folder.png")
                .Coversize = FileLen(.Cover)
            Else
                .Cover = ""
            End If

            .Erstelldatum = IO.Directory.GetLastWriteTime(path)
            .Foldersize = FolderSize.GetFolderSize(path)
            .Files = Get_Moviepaths_in_array(path)
            If IO.Directory.Exists(IO.Path.Combine(path, "Trailer")) Then
                .File_Trailer = Get_InfoTrailerfile(IO.Path.Combine(path, "Trailer"))
            Else
                .File_Trailer = ""
            End If



            .Backdrops = Backdropsarr(path)
        End With
    End Sub
    Public Sub PathAnalyse_Mymovies(ByVal i As Movie)
        Dim path As String = i.Pfad
        With i
            .Pfad = path
            .Ordner = IO.Path.GetFileName(path)
            If IO.File.Exists(IO.Path.Combine(path, "folder.jpg")) Then
                .Cover = IO.Path.Combine(path, "folder.jpg")
                .Coversize = FileLen(.Cover)
            ElseIf IO.File.Exists(IO.Path.Combine(path, "folder.png")) Then
                .Cover = IO.Path.Combine(path, "folder.png")
                .Coversize = FileLen(.Cover)
            Else
                .Cover = ""
            End If
            .File_Trailer = Get_Trailerfile(path)
            .Erstelldatum = IO.Directory.GetLastWriteTime(path)
            .Foldersize = FolderSize.GetFolderSize(path)
            .Files = Get_Moviepaths_in_array(path)
            .Backdrops = Backdropsarr(path)
        End With
    End Sub
    Private Sub PathAnalyse_NFO(ByVal i As Movie)
        Dim path As String = i.Pfad
        With i
            .Pfad = path
            .Ordner = IO.Path.GetFileName(path)
            If IO.File.Exists(IO.Path.Combine(path, "movie.tbn")) Then
                .Cover = IO.Path.Combine(path, "movie.tbn")

                .Coversize = FileLen(.Cover)

            Else
                .Cover = ""
            End If
            .File_Trailer = Get_Trailerfile(path)
            .Erstelldatum = IO.Directory.GetLastWriteTime(path)
            .Foldersize = FolderSize.GetFolderSize(path)
            .Files = Get_Moviepaths_in_array(path)
            .Backdrops = Backdropsarr(path)
        End With
    End Sub
#End Region
#Region "Backup"
    Public Sub Backup_Save(ByVal m As Movie)

        Backup_Save(m, Einstellungen.Config_MediaCenter.Default_local_Source)

    End Sub
    Public Sub Backup_Load(ByVal m As Movie)
        If XMLModule.Backup_Exists(m.Pfad, Einstellungen.Config_MediaCenter.Default_local_Source) Then
            Backup_Load(m, m.Pfad, Einstellungen.Config_MediaCenter.Default_local_Source)
        Else
            If XMLModule.Backup_Exists(m.Pfad, Savemode.Info) Then
                Backup_Load(m, m.Pfad, Savemode.Info)
            ElseIf XMLModule.Backup_Exists(m.Pfad, Savemode.mymovies) Then
                Backup_Load(m, m.Pfad, Savemode.mymovies)
            ElseIf XMLModule.Backup_Exists(m.Pfad, Savemode.nfo) Then
                Backup_Load(m, m.Pfad, Savemode.Info)
            Else
            End If
        End If
    End Sub
    Public Sub Backup_Save(ByVal m As Movie, ByVal s As Savemode)
        Select Case s
            Case Is = Savemode.DVDInfo
                SaveASInfo(m, True)
            Case Is = Savemode.Info
                SaveASInfo(m, True)
            Case Is = Savemode.nfo
                SaveASnfo(m, True)
            Case Is = Savemode.mymovies
                SaveASMymovies(m, True)
        End Select
    End Sub
    Public Sub Backup_Load(ByVal m As Movie, ByVal p As String, ByVal s As Savemode)

        Select Case s
            Case Is = Savemode.DVDInfo
                LoadInfos_infoxml(m, p, True)
            Case Is = Savemode.Info
                LoadInfos_infoxml(m, p, True)
            Case Is = Savemode.nfo
                LoadInfos_NFO(m, p, True)
            Case Is = Savemode.mymovies
                LoadInfos_mymoviesxml(m, p, True)
        End Select

    End Sub
    Public Sub Backup_Delet(ByVal Folderpath As String)
        If XMLModule.Backup_Exists(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source) Then
            Backup_Delet(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source)
        Else
            If XMLModule.Backup_Exists(Folderpath, Savemode.Info) Then
                Backup_Delet(Folderpath, Savemode.Info)
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.mymovies) Then
                Backup_Delet(Folderpath, Savemode.mymovies)
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.nfo) Then
                Backup_Delet(Folderpath, Savemode.nfo)
            End If
        End If
    End Sub

    Public Function Backup_Date(ByVal Folderpath As String) As Date
        If XMLModule.Backup_Exists(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source) Then
            Return XMLModule.Backup_Date(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source)
        Else
            If XMLModule.Backup_Exists(Folderpath, Savemode.Info) Then
                Return XMLModule.Backup_Date(Folderpath, Savemode.Info)
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.mymovies) Then
                Return XMLModule.Backup_Date(Folderpath, Savemode.mymovies)
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.nfo) Then
                Return XMLModule.Backup_Date(Folderpath, Savemode.nfo)
            Else
                Return New Date(0)
            End If
        End If
    End Function
    Public Sub Backup_Delet(ByVal p As String, ByVal s As Savemode)
        Select Case s
            Case Is = Savemode.DVDInfo
                IO.File.Delete(p + "\info.bak.xml")
            Case Is = Savemode.Info
                IO.File.Delete(p + "\info.bak.xml")
            Case Is = Savemode.nfo
                IO.File.Delete(p + "\movie.bak.nfo")
            Case Is = Savemode.mymovies
                IO.File.Delete(p + "\mymovies.bak.xml")
        End Select

    End Sub
    Public Function Backup_Date(ByVal p As String, ByVal s As Savemode) As Date
        Select Case s
            Case Is = Savemode.DVDInfo
                Return IO.File.GetLastWriteTime(p + "\info.bak.xml")
            Case Is = Savemode.Info
                Return IO.File.GetLastWriteTime(p + "\info.bak.xml")
            Case Is = Savemode.nfo
                Return IO.File.GetLastWriteTime(p + "\movie.bak.nfo")
            Case Is = Savemode.mymovies
                Return IO.File.GetLastWriteTime(p + "\mymovies.bak.xml")
            Case Else
                Return New Date(0)
        End Select

    End Function
    Public Function Backup_Exists(ByVal Folderpath As String) As Boolean
        If XMLModule.Backup_Exists(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source) Then
            Return True
        Else
            If XMLModule.Backup_Exists(Folderpath, Savemode.Info) Then
                Return True
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.mymovies) Then
                Return True
            ElseIf XMLModule.Backup_Exists(Folderpath, Savemode.nfo) Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Public Function Backup_Exists(ByVal p As String, ByVal s As Savemode) As Boolean
        Select Case s
            Case Is = Savemode.DVDInfo
                Return IO.File.Exists(p + "\info.bak.xml")
            Case Is = Savemode.Info
                Return IO.File.Exists(p + "\info.bak.xml")
            Case Is = Savemode.nfo
                Return IO.File.Exists(p + "\movie.bak.nfo")
            Case Is = Savemode.mymovies
                Return IO.File.Exists(p + "\mymovies.bak.xml")
            Case Else
                Return False
        End Select

    End Function
#End Region
#Region "Serien"


    Private Sub LoadEpisode_infoxml(ByVal i As Episode, ByVal p2 As String)
        Dim dp As String = IO.Path.Combine(i.Pfad, "info.xml")
        If IO.File.Exists(dp) Then
            PathAnalyse_Episode_Info(i)
            Dim XMLReader As Xml.XmlReader _
                 = New Xml.XmlTextReader(dp)
            With XMLReader
                .ReadToFollowing("FilmInfo")
                'Beginn zu laden
                i.Titel = If(.GetAttribute("Titel") Is Nothing, "", .GetAttribute("Titel"))

                i.Jahr = If(.GetAttribute("Produktionsjahr") Is Nothing, "", .GetAttribute("Produktionsjahr"))

                i.Darsteller = If(.GetAttribute("Darsteller") Is Nothing, "", .GetAttribute("Darsteller"))
                i.Regisseur = If(.GetAttribute("Regisseur") Is Nothing, "", .GetAttribute("Regisseur"))

                i.Autoren = If(.GetAttribute("Autoren") Is Nothing, "", .GetAttribute("Autoren"))
                i.Bewertung = If(.GetAttribute("Bewertung") Is Nothing, "", .GetAttribute("Bewertung"))
                i.Spieldauer = If(.GetAttribute("Spieldauer") Is Nothing, "", .GetAttribute("Spieldauer"))
                i.Inhalt = If(.GetAttribute("Inhalt") Is Nothing, "", .GetAttribute("Inhalt"))
                i.MediaInfo = If(.GetAttribute("MediaInfo") Is Nothing, "", .GetAttribute("MediaInfo"))
                i.Datum = If(.GetAttribute("Datum") Is Nothing, "", .GetAttribute("Datum"))
                If i.Datum = "" Then
                    i.Gesehen = "False"
                Else
                    i.Gesehen = "True"
                End If

                i.VideoAuflösung = If(.GetAttribute("VideoAuflösung") Is Nothing, "", .GetAttribute("VideoAuflösung"))
                i.VideoSeitenverhältnis = If(.GetAttribute("VideoSeitenverhältnis") Is Nothing, "", .GetAttribute("VideoSeitenverhältnis"))
                i.VideoBreite = If(.GetAttribute("VideoBreite") Is Nothing, "", .GetAttribute("VideoBreite"))
                i.VideoHöhe = If(.GetAttribute("VideoHöhe") Is Nothing, "", .GetAttribute("VideoHöhe"))
                i.VideoBildwiederholungsrate = If(.GetAttribute("VideoBildwiederholungsrate") Is Nothing, "", .GetAttribute("VideoBildwiederholungsrate"))
                i.VideoCodec = If(.GetAttribute("VideoCodec") Is Nothing, "", .GetAttribute("VideoCodec"))
                i.AudioKanäle = If(.GetAttribute("AudioKanäle") Is Nothing, "", .GetAttribute("AudioKanäle"))
                i.AudioCodec = If(.GetAttribute("AudioCodec") Is Nothing, "", .GetAttribute("AudioCodec"))
                i.AudioSprachen = If(.GetAttribute("AudioSprachen") Is Nothing, "", .GetAttribute("AudioSprachen"))
                .Close()

            End With

        End If
    End Sub

#End Region

    Private Sub LoadSeries_infoxml(ByVal i As Series)
        Dim dp As String = IO.Path.Combine(i.Pfad, "info.xml")
        If IO.File.Exists(dp) Then
            'PathAnalyse_Episode_Info(i)
            Dim XMLReader As Xml.XmlReader _
                 = New Xml.XmlTextReader(dp)
            With XMLReader
                .ReadToFollowing("FilmInfo")
                'Beginn zu laden
                i.Titel = .GetAttribute("Titel")
                i.ID = .GetAttribute("Kurzbeschreibung")
                i.Bewertung = .GetAttribute("Bewertung")
                i.Studio = .GetAttribute("Studios")
                i.Jahr = .GetAttribute("Produktionsjahr")
                i.Darsteller = .GetAttribute("Darsteller")
                i.Genre = .GetAttribute("Genre")
                i.IMDB_ID = .GetAttribute("IMDB_ID")
                i.Inhalt = .GetAttribute("Inhalt")


                .Close()

            End With

        End If
    End Sub

    Private Sub PathAnalyse_Episode_Info(ByVal i As Episode)
        If IO.File.Exists(IO.Path.Combine(i.Pfad, "folder.jpg")) Then
            i.bild = IO.Path.Combine(i.Pfad, "folder.jpg")
            i.files = Get_Moviepaths_in_array(i.Pfad)
        End If
    End Sub


End Module
Class SammlungFunctions

    Public Shared SammlungenListe As New List(Of String)
    Public Shared SetListe As New List(Of String)



    Public Shared Function SetSammlung(ByVal input As String, ByVal toSet As String) As String
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            'Info
            input = ClearSammlung(input)
            For Each s In toSet.Split(CChar(","))
                input &= " {" & s & "}"
            Next
            Return input
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
            Return toSet
        Else
            Return input
        End If
    End Function
    Public Shared Function AddSammlung(ByVal input As String, ByVal toSet As String) As String
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            'Info
            input = input.Trim
            For Each s In toSet.Split(CChar(","))
                If Not input.Contains("{" & s & "}") Then
                    input &= " {" & s & "}"
                End If
            Next
            Return input
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
            Return toSet
        Else
            Return input
        End If
    End Function
    Public Shared Function ClearSammlung(ByVal input As String) As String
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            'Info
            input = Regex.Replace(input, "\s?\{.*", "", RegexOptions.IgnoreCase)
            input = input.Trim
            Return input
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
            Return ""
        Else
            Return input
        End If
    End Function

    Shared Sub AddtoList_i(ByVal value As String)
        Dim Repex As System.Text.RegularExpressions.Regex = New Regex("\s?\{([^\{]*)\}")
        For Each m As Match In Repex.Matches(value)
            If Not SammlungenListe.Contains(m.Groups(1).Value) And Not m.Groups(1).Value = "" Then
                SammlungenListe.Add(m.Groups(1).Value)
            End If

        Next
    End Sub

    Shared Sub AddtoList_n(ByVal value As String)
        If Not SetListe.Contains(value) And Not value = "" Then
            SetListe.Add(value)
        End If
    End Sub

    Shared Function List_i(ByVal p1 As String) As String
        Dim r As String = ""
        Dim Repex As System.Text.RegularExpressions.Regex = New Regex("\s?\{([^\{]*)\}")
        For Each m As Match In Repex.Matches(p1)
            If r = "" Then
                r = m.Groups(1).Value
            Else

                r &= ", " & m.Groups(1).Value
            End If
        Next
        Return r
    End Function


End Class
