Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports System.Xml

Public Class MyFunctions
    Public Class ReplaceItem
        Property Pattern As String = ""
        Property Value As String = ""
        Sub New(ByVal p As String, ByVal v As String)
            Pattern = p
            Value = v
        End Sub
        Sub New()

        End Sub
    End Class
    ''' <param name="Path">Der Pfad der gekürzt zurückgegeben werden soll</param>
    ''' <param name="Length">Die gewünschte Länge die nicht überschritten werden darf</param>
    ''' <param name="TextFont">Die Schriftart die angewendet wird</param>
    Public Shared Function PathShorten(ByVal Path As String, ByVal Length As Integer, ByVal TextFont As Font) As String
        Dim PathParts() As String = Split(Path, "\")
        Dim PathBuild As New System.Text.StringBuilder(Path.Length)
        Dim LastPart As String = PathParts(PathParts.Length - 1)
        Dim PrevPath As String = ""

        'Erst prüfen ob der komplette String evtl. bereits kürzer als die Maximallänge ist
        If TextRenderer.MeasureText(Path, TextFont).Width < Length Then
            Return Path
        End If

        For i As Integer = 0 To PathParts.Length - 1
            PathBuild.Append(PathParts(i) & "\")
            If TextRenderer.MeasureText(PathBuild.ToString & "...\" & LastPart, TextFont).Width >= Length Then
                Return PrevPath
            Else
                PrevPath = PathBuild.ToString & "...\" & LastPart
            End If
        Next
        Return PrevPath
    End Function
    Public Shared Function SetCompactPath( _
        ByVal s As String, _
        ByVal Width As Integer, _
        ByVal fnt As Font, _
        ByVal flags As Windows.Forms.TextFormatFlags _
        ) As String
        If String.IsNullOrEmpty(s) Then
            Return String.Empty
        Else
            Dim CompactPath As String = String.Copy(s)
            TextRenderer.MeasureText(CompactPath, fnt, New Drawing.Size(Width, 0), _
                flags Or TextFormatFlags.ModifyString Or TextFormatFlags.GlyphOverhangPadding
                )

            Return CompactPath
        End If
    End Function


    Shared tboune As String = "%CacheID%,%Pfad%,%Ordner%,%Titel%,%Originaltitel%,%IMDB_ID%,%Darsteller%,%Regisseur%,%Autoren%,%Studios%,%Produktionsjahr%,%Produktionsland%,%Genre%,%FSK%,%Bewertung%,%Spieldauer%,%Datum%,%Kurzbeschreibung%,%Inhalt%,%Position%,%Sort%,%VideoAuflösung%,%VideoSeitenverhältnis%,%VideoBildwiederholungsrate%,%VideoCodec%,%AudioKanäle%,%AudioCodec%,%AudioSprachen%,%VideoHöhe%,%VideoBreite%"
    Shared Sub ExportChoose(Optional ByVal StartFolder As String = "")
        Dim r As String = ""
        If Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialog.IsPlatformSupported = True Then
            Dim m As New CommonOpenFileDialog
            m.IsFolderPicker = True

            Dim plist As New List(Of ReplaceItem)
            'm.InitialDirectoryShellContainer = TryCast(KnownFolders.VideosLibrary, ShellContainer)
            'm.Multiselect = True


            'Dim checkA As New CommonFileDialogCheckBox("chkOptionA", "Online-Suche", Einstellungen.Config_Laden.Laden_Ordner_Suche)
            'Dim checkB As New CommonFileDialogCheckBox("chkOptionB", "MediaInfo", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            'Dim checkC As New CommonFileDialogCheckBox("chkOptionB", "neue Ordner erstellen", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            ''checkA.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_Suche
            'checkB.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_MediaInfo
            'checkC.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner

            'm.Controls.Add(New CommonFileDialogSeparator())

            'm.Controls.Add(New CommonFileDialogSeparator())

            Dim ltext As New List(Of CommonFileDialogTextBox)
            Dim ldrop As New List(Of CommonFileDialogComboBox)

            If IO.Directory.Exists(IO.Path.Combine(StartFolder, "CVals")) Then
                Dim arr() As String = IO.Directory.GetFiles(IO.Path.Combine(StartFolder, "CVals"), "%CVal_*.txt")
                Array.Sort(arr)
                Dim i As Integer = 0



                For Each s In arr
                    Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "%CVal_(.*)_(.*)_(.*)%")
                    If match.Success = True Then
                        i += 1
                        Dim type As String = match.Groups(2).Value
                        If type = "Text" Then
                            Dim groupBox As New CommonFileDialogGroupBox(match.Groups(3).Value)
                            Dim Value1 As New CommonFileDialogTextBox("CVal_" & match.Groups(1).Value, "")
                            Dim readere As IO.StreamReader = New IO.StreamReader(s)
                            Dim text As String = readere.ReadToEnd
                            readere.Close()

                            Value1.Text = text
                            groupBox.Items.Add(Value1)
                            ltext.Add(Value1)
                            m.Controls.Add(groupBox)
                        ElseIf type.StartsWith("DropDown") Then
                            Dim groupBox As New CommonFileDialogGroupBox(match.Groups(3).Value)
                            Dim Value1 As New CommonFileDialogComboBox("CVal_" & match.Groups(1).Value)
                            Dim readere As IO.StreamReader = New IO.StreamReader(s)
                            Dim text As String = readere.ReadToEnd
                            readere.Close()
                            Dim prr() As String = Split(text, vbCrLf)
                            For Each p In prr
                                If p.StartsWith("_") Then
                                    p = p.Remove(0, 1)
                                    Dim item As New CommonFileDialogComboBoxItem(p)
                                    Value1.Items.Add(item)
                                    Value1.SelectedIndex = Value1.Items.Count - 1
                                Else
                                    Dim item As New CommonFileDialogComboBoxItem(p)
                                    Value1.Items.Add(item)
                                End If

                            Next
                            ldrop.Add(Value1)
                            groupBox.Items.Add(Value1)
                            m.Controls.Add(groupBox)
                        ElseIf type.StartsWith("Seperator") Then
                            Dim Value1 As New CommonFileDialogSeparator()
                            m.Controls.Add(Value1)
                            i -= 1
                        Else
                            i -= 1

                        End If
                    End If
                Next






            End If

            If m.ShowDialog = CommonFileDialogResult.OK Then


                For Each s In ldrop
                    If Not s.SelectedIndex = -1 Then
                        plist.Add(New ReplaceItem(s.Name, s.Items(s.SelectedIndex).Text))
                    End If

                Next
                For Each s In ltext
                    plist.Add(New ReplaceItem(s.Name, s.Text))
                Next



                Dim p As New Progress_Export(MainForm.GetselectedMovies)
                p.replace = plist
                p.path = m.FileName
                p.Vorlage = StartFolder
                p.Run()
            End If
        Else
            Dim plist As New List(Of ReplaceItem)
            If IO.Directory.Exists(IO.Path.Combine(StartFolder, "CVals")) Then
                Dim arr() As String = IO.Directory.GetFiles(IO.Path.Combine(StartFolder, "CVals"), "%CVal_*.txt")
                Array.Sort(arr)
                Dim i As Integer = 0
                If arr.Length > 0 Then
                    MsgBox("Die eigenen Variabelen werden von ihrem System noch nicht unterstützt")
                End If
                For Each s In arr
                    Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "%CVal_(.*)_(.*)_(.*)%")
                    If match.Success = True Then
                        i += 1
                        Dim type As String = match.Groups(2).Value
                        If type = "Text" Then
                            Dim readere As IO.StreamReader = New IO.StreamReader(s)
                            Dim text As String = readere.ReadToEnd
                            readere.Close()

                            plist.Add(New ReplaceItem(match.Groups(3).Value, text))

                        ElseIf type.StartsWith("DropDown") Then

                            Dim readere As IO.StreamReader = New IO.StreamReader(s)
                            Dim text As String = readere.ReadToEnd
                            Dim d As String = ""
                            readere.Close()
                            Dim prr() As String = Split(text, vbCrLf)
                            For Each p In prr
                                If p.StartsWith("_") Then
                                    d = p.Remove(0, 1)
                                End If
                            Next
                            plist.Add(New ReplaceItem(match.Groups(3).Value, ""))
                        End If
                    End If
                Next
            End If







            Dim fol As New FolderBrowserDialog


            If fol.ShowDialog = Windows.Forms.DialogResult.OK Then

                If Not fol.SelectedPath = "" Then
                    Dim p As New Progress_Export(MainForm.GetselectedMovies)
                    'p.replace = plist
                    p.path = fol.SelectedPath
                    p.Vorlage = StartFolder
                    p.Run()
                End If

            End If
        End If
    End Sub
    Shared Function ChooseFolder(Optional ByVal StartFolder As String = "") As String
        Dim r As String = ""
        If Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialog.IsPlatformSupported = True Then
            Dim m As New CommonOpenFileDialog
            m.IsFolderPicker = True
            If Not StartFolder = "" Then
                m.InitialDirectory = StartFolder
            End If

            'm.InitialDirectoryShellContainer = TryCast(KnownFolders.VideosLibrary, ShellContainer)
            'm.Multiselect = True

            'Dim groupBox As New CommonFileDialogGroupBox("Bei einem neuen Film")
            'Dim checkA As New CommonFileDialogCheckBox("chkOptionA", "Online-Suche", Einstellungen.Config_Laden.Laden_Ordner_Suche)
            'Dim checkB As New CommonFileDialogCheckBox("chkOptionB", "MediaInfo", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            'Dim checkC As New CommonFileDialogCheckBox("chkOptionB", "neue Ordner erstellen", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            'checkA.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_Suche
            'checkB.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_MediaInfo
            'checkC.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner
            'groupBox.Items.Add(checkA)
            'groupBox.Items.Add(checkB)
            'groupBox.Items.Add(checkC)
            'm.Controls.Add(New CommonFileDialogSeparator())
            'm.Controls.Add(groupBox)
            'm.Controls.Add(New CommonFileDialogSeparator())


            'Dim optBox As New CommonFileDialogGroupBox("Suchmodus")
            'Dim rlist As New CommonFileDialogRadioButtonList

            'Dim radioA As New CommonFileDialogRadioButtonListItem("ausführlich")

            'Dim radioB As New CommonFileDialogRadioButtonListItem("ohne Eingabe")

            'rlist.Items.Add(radioA)
            'rlist.Items.Add(radioB)

            'rlist.SelectedIndex = Einstellungen.Config_Laden.Laden_Ordner_suchmodus

            ''rlist.SelectedIndex = 0
            'optBox.Items.Add(rlist)



            ''Dim Favcheck As New CommonFileDialogCheckBox("chkOptionA", "Zu Favorieten hinzufügen", False)


            'm.Controls.Add(optBox)
            'm.Controls.Add(New CommonFileDialogSeparator())
            'm.Controls.Add(Favcheck)


            MainForm.SuspendLayout()


            If m.ShowDialog = CommonFileDialogResult.OK Then
                'Clear_DG(True)
                'Einstellungen.Config_Laden.Laden_Ordner_Suche = checkA.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = checkB.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = checkC.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_suchmodus = rlist.SelectedIndex
                's(0) = m.FileNames
                r = m.FileName

            End If
            MainForm.PerformAutoScale()
            MainForm.ResumeLayout(True)
        Else
            Dim fol As New FolderBrowserDialog
            If Not StartFolder = "" Then
                fol.SelectedPath = StartFolder
            End If

            If fol.ShowDialog = Windows.Forms.DialogResult.OK Then
                r = fol.SelectedPath
            End If
        End If
        Return r
    End Function
    Shared Function Get_Viewstate(ByVal state As Windows.Forms.View) As String
        Dim r As Integer = -1
        Select Case state
            Case Is = View.Details
                r = 0
            Case Is = View.LargeIcon
                r = 1
            Case Is = View.List
                r = 2
            Case Is = View.SmallIcon
                r = 3
            Case Is = View.Tile
                r = 4
        End Select
        Return CStr(r)
    End Function
    Shared Function Get_Viewstate(ByVal state As String) As Windows.Forms.View
        Dim r As Windows.Forms.View = View.Details
        Select Case state
            Case Is = "0"
                r = View.Details
            Case Is = "1"
                r = View.LargeIcon
            Case Is = "2"
                r = View.List
            Case Is = "3"
                r = View.SmallIcon
            Case Is = "4"
                r = View.Tile
        End Select
        Return r
    End Function
    Private Declare Auto Function GetShortPathName Lib "kernel32.dll" ( _
ByVal lpszLongPath As String, _
ByVal lpszShortPath As String, _
ByVal cchBuffer As Int32 _
) As Int32
    Public Shared Function shortpath(ByVal s As String) As String
        Dim strPath As String = s
        Dim strShortPath As String = Space(100)
        Dim n As Int32 = GetShortPathName(strPath, strShortPath, 100)
        'MsgBox(Strings.Left(strShortPath, n))
        Dim filepath As String = Strings.Left(strShortPath, n)
        Return filepath
    End Function
    Shared Function HttploadText(ByVal q As String, ByVal cPath As String) As String



        Dim f As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache\Info\" & Renamer.CheckInvalid_F(cPath) & ".nfo")
        If Not cPath = "" Then
            If IO.File.Exists(f) Then
                Try
                    Dim t As String = ""
                    Dim readere As IO.StreamReader = New IO.StreamReader(f)
                    t = readere.ReadToEnd
                    readere.Close()
                    Return t
                Catch ex As Exception


                End Try
            End If
        End If

        Try
            Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(New Uri(q)), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
            Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)

            Dim httptext As String = reader.ReadToEnd
            httpResponse.Close()
            My.Computer.FileSystem.WriteAllText(f, httptext, False)
            Return httptext
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function HttploadJsontoXML(ByVal q As String, ByVal cPath As String) As Xml.XmlDocument
        Dim f As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache\Info\" & cPath & ".xml")
        If Not cPath = "" Then
            If IO.File.Exists(f) Then
                Try
                    Dim xml As New Xml.XmlDocument
                    xml.Load(f)

                    Return xml
                Catch ex As Exception

                End Try
            End If
        End If
        Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(New Uri(q)), Net.HttpWebRequest)
        httpRequest.Method = "GET"
        httpRequest.Accept = "*/*"
        Dim httpResponse As Net.HttpWebResponse
        httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
        Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)
        Dim httptext As String = reader.ReadToEnd
        httpResponse.Close()

        Dim json As String = "{'root': " & httptext & "}"

        Dim nxml As XmlDocument = DirectCast(Newtonsoft.Json.JsonConvert.DeserializeXmlNode(json), XmlDocument)
        nxml.Save(f)
        Return nxml
    End Function
    Shared Function HttploadXML(ByVal q As String, ByVal cPath As String) As Xml.XmlDocument
        Dim f As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache\Info\" & cPath & ".xml")
        If Not cPath = "" Then
            If IO.File.Exists(f) Then
                Try
                    Dim xml As New Xml.XmlDocument
                    xml.Load(f)

                    Return xml
                Catch ex As Exception

                End Try
            End If
        End If
        Dim retryed As Boolean = False
retr:   Try

            Dim xml As New Xml.XmlDocument
            Dim httpRequest As Net.HttpWebRequest = CType(Net.HttpWebRequest.Create(New Uri(q)), Net.HttpWebRequest)
            Dim httpResponse As Net.HttpWebResponse
            httpResponse = CType(httpRequest.GetResponse(), Net.HttpWebResponse)
            Dim reader As IO.StreamReader = New IO.StreamReader(httpResponse.GetResponseStream)
            Dim httptext As String = reader.ReadToEnd
            httpResponse.Close()
            xml.LoadXml(httptext)


            If cPath.StartsWith("ofdb") Then
                Dim rcode As String = If(xml.SelectNodes("//rcode").Count > 0, xml.SelectSingleNode("//rcode").InnerText, "")
                If Not rcode = "0" Then
                    If retryed = False Then
                        retryed = True
                        GoTo retr
                    End If
                    Return Nothing
                Else
                    If Not IO.Directory.Exists(GetPathofFile(f)) Then
                        IO.Directory.CreateDirectory(GetPathofFile(f))
                    End If
                    xml.Save(f)
                    Return xml
                End If
            Else
                If Not IO.Directory.Exists(GetPathofFile(f)) Then
                    IO.Directory.CreateDirectory(GetPathofFile(f))
                End If
                xml.Save(f)
                Return xml
            End If

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Shared Function ImageFromWeb(ByVal sURL As String) As Image
        Try
            ' Web-Anfrage mit vorgegebener URL zur Bilddatei
            Dim oRequest As Net.WebRequest = Net.WebRequest.Create(sURL)
            oRequest.Method = "GET"

            ' Antwort unserer Anfrage...
            Dim oResponse As Net.WebResponse = oRequest.GetResponse()
            'Application.DoEvents()

            ' Stream-Objekt mit den Bilddaten erstellen
            Dim oStream As New StreamReader(oResponse.GetResponseStream())

            ' Bild aus dem Stream-Objekt in ein Image-Objekt kopieren
            Dim oImg As Image = Image.FromStream(oStream.BaseStream)

            ' Objekte zerstören
            oStream.Close()
            oResponse.Close()

            ' Image-Objekt zurückgeben
            Return oImg

        Catch ex As Exception
            ' Fehler: Nothing zurückgeben
            Return Nothing
        End Try
    End Function
    Shared Function ImageFromJpeg(ByVal p As String) As Image
        Try
            Dim img As Bitmap
            Dim oStream As New System.IO.FileStream(p, IO.FileMode.Open)
            img = New Bitmap(oStream)
            oStream.Close()
            Return img
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Lifert den Pfad zum Ordner in dem die Datei sich befindet
    ''' (Parent Directory)
    ''' </summary>
    ''' <param name="s">Pfad</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Shared Function GetPathofFile(ByVal s As String) As String
        Dim r As String = ""
        'Debug.WriteLine("Vorher: " & s)
        Try
            r = s.Substring(0, s.LastIndexOf("\"))
        Catch ex As Exception

        End Try
        'Debug.WriteLine("Nachher: " & r)
        Return r
    End Function
    Shared Function IsAviableFile(ByVal Path As String) As Boolean
        Dim r As Boolean = True
        'Dim f As New System.IO.FileInfo(Path)

        'If f.Attributes = FileAttributes.Hidden Or f.Attributes = FileAttributes.System Then

        If Not Trim(Einstellungen.Config_Laden.Laden_Dateien_FilterFoldername) = "" Then
            Dim dir() As String = Split(Einstellungen.Config_Laden.Laden_Dateien_FilterFoldername, "|")
            For x As Integer = 0 To dir.Length - 1
                'MsgBox(dir(x) & "     " & Path)

                If IO.Path.GetFileName(GetPathofFile(Path)) = Trim(dir(x)) Or Path.Contains("\" & Trim(dir(x)) & "\") Then
                    r = False
                    Exit For
                End If
            Next
        End If
        If r = True Then
            If Not Trim(Einstellungen.Config_Laden.Laden_Dateien_FilterDateiEndung) = "" Then
                Dim dir() As String = Split(Einstellungen.Config_Laden.Laden_Dateien_FilterDateiEndung, "|")
                For x As Integer = 0 To dir.Length - 1
                    If IO.Path.GetFileNameWithoutExtension(Path).ToLower.EndsWith(dir(x).ToLower) Then
                        r = False
                        Exit For
                    End If
                Next
            End If
        End If
        If r = True Then
            If Einstellungen.Config_Laden.Laden_Dateien_CB_Minsize = True Then

                Dim size As Long = FolderSize.GetFileSize(Path)
                Dim Mb As Integer = CInt(size / 1048576)
                If Mb < Einstellungen.Config_Laden.Laden_Dateien_Minsize_val Then
                    r = False
                End If
            End If
        End If

        Return r
    End Function
    Shared Function Backdropsarr(ByVal Pfad As String, Optional ByVal oSav As Savemode = Savemode.neu) As String()
        Dim r(-1) As String
        If oSav = Savemode.neu Then
            oSav = Einstellungen.Config_MediaCenter.Default_local_Source
        End If

        If IO.Directory.Exists(Pfad) Then
            If oSav = Savemode.Info Then
                If IO.Directory.Exists(IO.Path.Combine(Pfad, "Fanart")) Then
                    Dim arts() As String = IO.Directory.GetFiles(IO.Path.Combine(Pfad, "Fanart"), "*.jpg")
                    r = arts
                End If
            ElseIf oSav = Savemode.mymovies Then
                Dim arts() As String = IO.Directory.GetFiles(Pfad, "*.jpg")
                For x As Integer = 0 To arts.Length - 1

                    If Path.GetFileName(arts(x)).StartsWith("Backdrop") = True Or Path.GetFileName(arts(x)).StartsWith("backdrop") = True Then
                        'MsgBox(Path.GetFileName(arts(x)))
                        Array.Resize(r, r.Length + 1)
                        r(r.Length - 1) = arts(x)


                    End If
                Next
            ElseIf oSav = Savemode.nfo Then

                If IO.File.Exists(IO.Path.Combine(Pfad, "fanart.jpg")) Then
                    Array.Resize(r, r.Length + 1)
                    r(r.Length - 1) = IO.Path.Combine(Pfad, "fanart.jpg")
                End If
                If IO.Directory.Exists(IO.Path.Combine(Pfad, "extrathumbs")) Then
                    Dim arts() As String = IO.Directory.GetFiles(IO.Path.Combine(Pfad, "extrathumbs"), "*.jpg")
                    For x As Integer = 0 To arts.Length - 1

                        'MsgBox(Path.GetFileName(arts(x)))
                        Array.Resize(r, r.Length + 1)
                        r(r.Length - 1) = arts(x)

                    Next
                End If


            End If



            'If subfolderjpg = True And File.Exists(Path.Combine(Pfad, "folder.jpg")) Then
            'r = arts.Length - 1
            'End If



        End If
        Return r
    End Function
    Shared Function Get_Trailerfile(ByVal Path As String) As String


        For xfile As Integer = 0 To Einstellungen.Config_Laden.Laden_Dateien_List.Count - 1
            If Einstellungen.Config_Laden.Laden_Dateien_List(xfile).ToString.Contains(".") Then
                Dim movies() As String = IO.Directory.GetFiles(Path, Einstellungen.Config_Laden.Laden_Dateien_List(xfile), SearchOption.TopDirectoryOnly)
                Array.Sort(movies)
                If movies.Length > 0 Then
                    For mov As Integer = 0 To movies.Length - 1
                        If IO.Path.GetFileNameWithoutExtension(movies(mov)).ToLower.EndsWith("-trailer") Then
                            Return movies(mov)
                        End If
                    Next
                End If
            End If
        Next
        Return ""

    End Function
    Shared Function Get_InfoTrailerfile(ByVal Path As String) As String


        For xfile As Integer = 0 To Einstellungen.Config_Laden.Laden_Dateien_List.Count - 1
            If Einstellungen.Config_Laden.Laden_Dateien_List(xfile).ToString.Contains(".") Then
                Dim movies() As String = IO.Directory.GetFiles(Path, Einstellungen.Config_Laden.Laden_Dateien_List(xfile))
                Array.Sort(movies)
                If movies.Length > 0 Then
                    Return movies(0)
                End If
            End If
        Next
        Return ""

    End Function
    Shared Function Get_Moviepaths_in_array(ByVal Path As String) As String()
        'Dim str(0) As String

        'Dim cu As Integer = -1


        'For xfile As Integer = 0 To Einstellungen.Config_Laden.Laden_Dateien_List.Count - 1

        '    If Einstellungen.Config_Laden.Laden_Dateien_List(xfile).ToString.Contains(".") Then
        '        Dim movies() As String = IO.Directory.GetFiles(Path, Einstellungen.Config_Laden.Laden_Dateien_List(xfile))
        '        Array.Sort(movies)

        '        If movies.Length > 0 Then
        '            For mov As Integer = 0 To movies.Length - 1
        '                If IsAviableFile(movies(mov)) = True Then
        '                    cu += 1

        '                    Array.Resize(str, cu + 1)

        '                    str(cu) = movies(mov)

        '                End If


        '            Next
        '        End If
        '    Else
        '        If IO.Directory.Exists(Path & "\" & Einstellungen.Config_Laden.Laden_Dateien_List(xfile)) = True Then
        '            cu += 1

        '            Array.Resize(str, cu + 1)

        '            str(cu) = Path & "\" & Einstellungen.Config_Laden.Laden_Dateien_List(xfile)

        '        End If


        '    End If
        '    'Report(CInt(((xfile + 1) / (Dateiformate.Length)) * 100))
        'Next
        'Array.Sort(str)
        'Return str
        Dim str(0) As String

        Dim cu As Integer = -1
        Dim bdmv As String = IO.Path.Combine(Path, "BDMV")
        If IO.Directory.Exists(bdmv) Then
            If IO.Directory.Exists(IO.Path.Combine(bdmv, "Stream")) Then
                Path = IO.Path.Combine(bdmv, "Stream")
            End If
        ElseIf IO.Directory.Exists(IO.Path.Combine(Path, "Stream")) Then
            Path = IO.Path.Combine(Path, "Stream")
        End If

        For xfile As Integer = 0 To Einstellungen.Config_Laden.Laden_Dateien_List.Count - 1

            If Einstellungen.Config_Laden.Laden_Dateien_List(xfile).ToString.Contains(".") Then


                Dim movies() As String = IO.Directory.GetFiles(Path, Einstellungen.Config_Laden.Laden_Dateien_List(xfile))
                Array.Sort(movies)







                If movies.Length > 0 Then
                    For mov As Integer = 0 To movies.Length - 1
                        If IsAviableFile(movies(mov)) = True Then
                            cu += 1

                            Array.Resize(str, cu + 1)

                            str(cu) = movies(mov)

                        End If


                    Next
                End If
            Else
                If IO.Directory.Exists(Path & "\" & Einstellungen.Config_Laden.Laden_Dateien_List(xfile)) = True Then
                    cu += 1

                    Array.Resize(str, cu + 1)

                    str(cu) = Path & "\" & Einstellungen.Config_Laden.Laden_Dateien_List(xfile)

                End If


            End If
            'Report(CInt(((xfile + 1) / (Dateiformate.Length)) * 100))
        Next
        Array.Sort(str)
        Return str

    End Function
    ' Sekunden nach hh:mm:ss umrechnen
    Shared Function FormatSeconds(ByVal nSeconds As Long, _
      Optional ByVal sFormat As String = "HH:mm:ss") As String

        Return Date.FromOADate(CDbl(nSeconds * (1 / 86400))).ToString(sFormat)
    End Function
    ''' <summary>
    ''' Vergleicht zwei Bitmaps miteinader.
    ''' </summary>
    ''' <param name="Bitmap1">Bitmap oder Image</param>
    ''' <param name="Bitmap2">Bitmap oder Image</param>
    ''' <returns>True, wenn die Bitmaps identisch sind, andernfalls False.</returns>
    Shared Function BitmapsEqual(ByVal Bitmap1 As Bitmap, ByVal Bitmap2 As Bitmap) As Boolean
        Dim bResult As Boolean = False

        ' Stimmt die Größe überein...
        If Bitmap1.Size = Bitmap2.Size Then
            ' ... Bitmaps in Byte-Array konvertieren
            With New System.Drawing.ImageConverter()
                Dim Bytes1 As Byte() = New Byte(0) {}
                Bytes1 = CType(.ConvertTo(New Bitmap(Bitmap1), Bytes1.[GetType]()), Byte())
                Dim Bytes2 As Byte() = New Byte(0) {}
                Bytes2 = CType(.ConvertTo(New Bitmap(Bitmap2), Bytes2.[GetType]()), Byte())

                ' Hash-Wert der beiden Bitmaps berechnen ... 
                Dim SHA As New System.Security.Cryptography.SHA256Managed
                Dim Hash1 As Byte() = SHA.ComputeHash(Bytes1)
                Dim Hash2 As Byte() = SHA.ComputeHash(Bytes2)

                ' ... und miteinander vergleichen
                If Hash1.Length = Hash2.Length Then
                    bResult = True
                    For i As Integer = 0 To Hash1.Length - 1
                        If Hash1(i) <> Hash2(i) Then
                            bResult = False
                            Exit For
                        End If
                    Next i
                End If
            End With
        End If

        Return bResult
    End Function
    Shared Function Get_Moviepaths_in_array_depht_old(ByVal p As String) As String()
        'Dim str(-1) As String
        'lstFilesFound.Clear()
        'DirSearch(Path)
        'Dim re As List(Of String) = lstFilesFound

        'Array.Resize(str, lstFilesFound.Count)
        'For Each s In lstFilesFound
        '    str(lstFilesFound.IndexOf(s)) = s
        'Next

        Dim str(-1) As String

        Dim cu As Integer = -1
        Dim ppts As New List(Of String)
        ppts.Add(p)
        ppts.AddRange(IO.Directory.GetDirectories(p))


        For Each Paths In ppts
            Dim f As New System.IO.FileInfo(Paths)
            If f.Attributes = (FileAttributes.System Or f.Attributes) Or f.Attributes = (FileAttributes.Hidden Or f.Attributes) Then

            Else

                Try

                    For xfile As Integer = 0 To Einstellungen.Config_Laden.Laden_Dateien_List.Count - 1


                        If Einstellungen.Config_Laden.Laden_Dateien_List(xfile).ToString.Contains(".") Then
                            Dim movies() As String = IO.Directory.GetFiles(Paths, Einstellungen.Config_Laden.Laden_Dateien_List(xfile), SearchOption.AllDirectories)

                            Array.Sort(movies)

                            If movies.Length > 0 Then

                                For mov As Integer = 0 To movies.Length - 1
                                    Dim pt As String = GetPathofFile(movies(mov))



                                    If str.Length > 0 Then
                                        For x As Integer = 0 To str.Length - 1
                                            If str(x) = pt Then
                                                GoTo nexxt
                                            End If
                                        Next
                                    End If

                                    'Blue-Ray Strucktur asu ORdner
                                    If Einstellungen.Config_Laden.Laden_Dateien_List(xfile) = "*.m2ts" Then
                                        If IO.Path.GetFileName(pt).ToUpper = "STREAM" Then
                                            If IO.Path.GetFileName(GetPathofFile(pt)).ToUpper = "BDMV" Then

                                                If str.Length > 0 Then
                                                    For x As Integer = 0 To str.Length - 1

                                                        If str(x) = GetPathofFile(GetPathofFile(pt)) Then
                                                            GoTo nexxt
                                                        End If
                                                    Next
                                                End If
                                                cu += 1

                                                Array.Resize(str, cu + 1)

                                                str(cu) = GetPathofFile(GetPathofFile(pt))
                                                GoTo nexxt
                                            Else
                                                If str.Length > 0 Then
                                                    For x As Integer = 0 To str.Length - 1

                                                        If str(x) = GetPathofFile(pt) Then
                                                            GoTo nexxt
                                                        End If
                                                    Next
                                                End If
                                                cu += 1

                                                Array.Resize(str, cu + 1)
                                                'MsgBox(GetPathofFile(pt))
                                                str(cu) = GetPathofFile(pt)
                                                GoTo nexxt
                                            End If
                                        End If
                                    End If
                                    '/BD
                                    If IsAviableFile(movies(mov)) = True Then

                                        'Debug.WriteLine(IO.Path.GetFileNameWithoutExtension(movies(mov)) & " - " & Mb & "MB")

                                        cu += 1

                                        Array.Resize(str, cu + 1)

                                        str(cu) = pt
                                    End If


nexxt:
                                Next
                            End If
                        Else
                            Dim dirs() As String = IO.Directory.GetDirectories(Paths, Einstellungen.Config_Laden.Laden_Dateien_List(xfile), SearchOption.AllDirectories)
                            Array.Sort(dirs)
                            If dirs.Length > 0 Then
                                For di As Integer = 0 To dirs.Length - 1
                                    Dim pt As String = GetPathofFile(dirs(di))
                                    If str.Length > 0 Then
                                        For x As Integer = 0 To str.Length - 1
                                            If str(x) = pt Then
                                                GoTo nexxto
                                            End If
                                        Next
                                    End If
                                    cu += 1

                                    Array.Resize(str, cu + 1)

                                    str(cu) = pt
                                Next
                            End If


nexxto:
                        End If
                    Next

                Catch ex As Exception
                    MsgBox("Fehler beim Suchen nach Film-Dateien: " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            End If
        Next
        Return str
    End Function

    Public Structure Fio_FileType
        Dim Name As String
        Dim isBluRay As Boolean
        Dim isDVD As Boolean
        Dim isNormal As Boolean
    End Structure


    Shared Function Get_Moviepaths_in_array_depht(ByVal p As String) As List(Of Fio_FileType)
        'Dim str(-1) As String
        'lstFilesFound.Clear()
        'DirSearch(Path)
        'Dim re As List(Of String) = lstFilesFound

        'Array.Resize(str, lstFilesFound.Count)
        'For Each s In lstFilesFound
        '    str(lstFilesFound.IndexOf(s)) = s
        'Next

        Dim str(-1) As String
        Dim res As New List(Of Fio_FileType)
        Dim cu As Integer = -1
        Dim ppts As New List(Of String)
        ppts.Add(p)
        ppts.AddRange(IO.Directory.GetDirectories(p))


        For Each Paths In ppts
            Dim f As New System.IO.FileInfo(Paths)
            If Not (f.Attributes = (FileAttributes.System Or f.Attributes) Or f.Attributes = (FileAttributes.Hidden Or f.Attributes)) Then



                For Each xfile In Einstellungen.Config_Laden.Laden_Dateien_List
                    If xfile.ToString.Contains(".") Then
                        Dim movies() As String = IO.Directory.GetFiles(Paths, xfile, SearchOption.AllDirectories)
                        Array.Sort(movies)

                        For Each mov In movies
                            Dim nFile As New Fio_FileType

                            Dim pathofFile As String = GetPathofFile(mov)
                            'BluRay
                            If xfile = "*.m2ts" Then
                                If IO.Path.GetFileName(pathofFile).ToUpper = "STREAM" Then
                                    If IO.Path.GetFileName(GetPathofFile(pathofFile)).ToUpper = "BDMV" Then
                                        pathofFile = GetPathofFile(GetPathofFile(pathofFile))
                                        nFile.isBluRay = True
                                    Else
                                        pathofFile = GetPathofFile(pathofFile)
                                        nFile.isBluRay = True
                                    End If
                                ElseIf IO.Path.GetFileName(GetPathofFile(pathofFile)).ToUpper = "BDMV" Then
                                    pathofFile = GetPathofFile(pathofFile)
                                    nFile.isBluRay = True
                                End If
                            End If

                            For Each s In res
                                If s.Name = pathofFile Then
                                    GoTo skip
                                End If
                            Next
                            If IsAviableFile(mov) = True Then
                                nFile.Name = pathofFile
                                res.Add(nFile)
                            End If



skip:


                        Next
                    Else
                        Dim dirs() As String = IO.Directory.GetDirectories(Paths, xfile, SearchOption.AllDirectories)
                        Array.Sort(dirs)

                        For Each di In dirs
                            Dim nFile As New Fio_FileType

                            Dim pathofFile As String = GetPathofFile(di)
                            For Each s In res
                                If s.Name = pathofFile Then
                                    GoTo skip2
                                End If

                            Next
                            nFile.Name = pathofFile
                            res.Add(nFile)
skip2:
                        Next di

                    End If
                Next
            End If
        Next




        Return res
    End Function
    Shared Function Check_Artikel(ByVal s As Search_Result) As Boolean

        Dim rt As String = Check_Artikel(s.Titel, Einstellungen.Config_Save.Save_Artikel_Titel_Vorne)
        Dim ro As String = Check_Artikel(s.Originaltitel, Einstellungen.Config_Save.Save_Artikel_OriginalTitel_Vorne)
        Dim rs As String = Check_Artikel(s.Sort, Einstellungen.Config_Save.Save_Artikel_Sort_Vorne)

        If rt = s.Titel And rs = s.Sort And ro = s.Originaltitel Then
            Return False
        Else
            s.Titel = rt.Trim
            s.Sort = rs.Trim
            s.Originaltitel = ro.Trim
            Return True
        End If
        'Else
        'Main.TB_Titel.Text = Check_Artikel(Main.TB_Titel.Text, Einstellungen.Config_Save.Save_Artikel_Titel_Vorne)
        'Main.TB_Originaltitel.Text = Check_Artikel(Main.TB_Originaltitel.Text, Einstellungen.Config_Save.Save_Artikel_OriginalTitel_Vorne)
        'Main.TB_Sort.Text = Check_Artikel(Main.TB_Sort.Text, Einstellungen.Config_Save.Save_Artikel_Sort_Vorne)
        'End If

    End Function
    Shared Function Check_Artikel(ByVal m As Movie) As Boolean

        Dim rt As String = Check_Artikel(m.Titel, Einstellungen.Config_Save.Save_Artikel_Titel_Vorne)
        Dim ro As String = Check_Artikel(m.Originaltitel, Einstellungen.Config_Save.Save_Artikel_OriginalTitel_Vorne)
        Dim rs As String = Check_Artikel(m.Sort, Einstellungen.Config_Save.Save_Artikel_Sort_Vorne)

        If rt = m.Titel And rs = m.Sort And ro = m.Originaltitel Then
            Return False
        Else
            m.Titel = rt.Trim
            m.Sort = rs.Trim
            m.Originaltitel = ro.Trim
            Return True
        End If
        'Else
        'Main.TB_Titel.Text = Check_Artikel(Main.TB_Titel.Text, Einstellungen.Config_Save.Save_Artikel_Titel_Vorne)
        'Main.TB_Originaltitel.Text = Check_Artikel(Main.TB_Originaltitel.Text, Einstellungen.Config_Save.Save_Artikel_OriginalTitel_Vorne)
        'Main.TB_Sort.Text = Check_Artikel(Main.TB_Sort.Text, Einstellungen.Config_Save.Save_Artikel_Sort_Vorne)
        'End If

    End Function
    Shared Function Check_Artikel(ByVal s As String, ByVal Vorne As Boolean) As String
        Dim a() As String = Einstellungen.Config_Save.Save_Artikel_Erkennung.Split(CChar(";"))
        Dim r As String = ""

        If Not s Is Nothing Then

            r = s
            If a.Length > 0 Then
                For x As Integer = 0 To a.Length - 1
                    a(x) = Trim(a(x))
                    If Not a(x) = "" Then
                        If s.StartsWith(a(x) & " ") Then
                            If Vorne = True Then
                                r = s
                                Exit For
                            Else
                                r = s.Remove(0, a(x).Length)
                                r = r & ", " & a(x)
                                r = Trim(r)
                                Exit For
                            End If
                        End If
                        If s.EndsWith("," & a(x)) Or s.EndsWith(", " & a(x)) Then
                            If Vorne = False Then
                                r = s
                                Exit For
                            Else
                                r = s.Remove(s.LastIndexOf(a(x)), a(x).Length)
                                r = a(x) & " " & r
                                r = Trim(r)
                                If r.EndsWith(",") Then
                                    r = r.Remove(r.Length - 1, 1)
                                    r = Trim(r)
                                End If
                                Exit For
                            End If
                        Else

                        End If
                    End If
                Next
            End If
        End If
        Return r
    End Function
    Shared Sub SetHandCursor()
        SetCursor(LoadCursor(0, 32649))
    End Sub
    <DllImport("user32.dll")> _
    Public Shared Function LoadCursor(ByVal hInstance As Integer, ByVal lpCursorName As Integer) As Integer
    End Function

    <DllImport("user32.dll")> _
    Public Shared Function SetCursor(ByVal hCursor As Integer) As Integer
    End Function
    ''' <summary>
    ''' Gibt die Anzahl der Wörter eines Strings zurücks.
    ''' </summary>
    ''' <param name="Text">Text, dessen Wörter gezählt werden sollen.</param>
    Public Shared Function GetStringWordCount(ByVal Text As String) As Integer
        Return System.Text.RegularExpressions.Regex.Matches(Text, "\w{1,}").Count
    End Function
End Class
'Public Module Renamer
''    Dim invalidPathChars As Char() = Path.GetInvalidFileNameChars()
'Private Function Get_newfile(ByVal i As Integer, ByVal c As Integer, ByVal oldfile As String) As String
'    Dim r As String = ""
'    Dim iarr As Integer = get_iarr(i)
'    Dim ext As String = IO.Path.GetExtension(oldfile)

'    r = Daten.arr(2, iarr)
'    r &= " (" & Daten.arr(9, iarr) & ")"
'    r &= " [" & Daten.arr(21, iarr) & "]"
'    If c = 0 Then

'    Else
'        r &= " Teil " & c
'    End If
'    r &= ext
'    Return r
'End Function
'Private Function Get_newfolder(ByVal i As Integer) As String
'    Dim r As String = ""
'    Dim iarr As Integer = get_iarr(i)
'    r = Daten.arr(2, iarr)
'    r &= " (" & Daten.arr(9, iarr) & ")"
'    r &= " [" & Daten.arr(21, iarr) & "]"
'    Return r
'End Function
'Private Function CheckforInvalidPathChars(ByVal s As String) As String
'    For Each invalidPChar In invalidPathChars
'        s = s.Replace(invalidPChar, "")
'    Next
'    Return s
'End Function
'Function RenameMovie(ByVal i As Integer, ByVal RenameFile As Boolean)

'    Dim pfad As String = Daten.arr(0, get_iarr(i))
'    Dim newpath As String = ""
'    Dim newfolder As String = ""


'    newpath = GetPathofFile(pfad)
'    newfolder = Get_newfolder(i)

'    'Überprüfen auf ungültige zeichen
'    newfolder = CheckforInvalidPathChars(newfolder)



'    If Not Directory.Exists(newpath & "\" & newfolder) Then
'        Rename(pfad, newpath & "\" & newfolder)
'    End If
'    If RenameFile = True Then
'        Dim a() As String = Get_Moviepaths_in_array(newpath & "\" & newfolder)
'        If a.Count = 1 Then
'            Dim newfilpath As String = ""
'            newfilpath = Get_newfile(i, 0, a(0))
'            newfilpath = CheckforInvalidPathChars(newfilpath)
'            IO.File.Move(a(0), newpath & "\" & newfolder & "\" & newfilpath)
'        ElseIf a.Count > 1 Then
'            Dim con As Integer = 1
'            For x As Integer = 0 To a.Length - 1
'                If IO.File.Exists(a(x)) Then
'                    Dim newfilpath As String = ""
'                    newfilpath = Get_newfile(i, con, a(x))
'                    newfilpath = CheckforInvalidPathChars(newfilpath)
'                    IO.File.Move(a(x), newpath & "\" & newfolder & "\" & newfilpath)
'                    con += 1
'                End If
'            Next
'        End If
'        'IO.Directory.Move(pfad, newpath & "\" & newfolder)
'    End If



'End Function
''End Module
