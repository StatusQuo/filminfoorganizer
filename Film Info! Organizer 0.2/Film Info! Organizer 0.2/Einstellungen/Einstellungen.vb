Imports System.Xml

Public Class Einstellungen
    Shared Property ChachePath As String
    Shared Property SettingsPath As String

    'Shared Settings As New Settings
    Public Class gFilter
        Property Name_DE As String
        Property Name_EN As String
        Property id As String
        Property Filter As String
        Sub New()
            Name_DE = ""
            Name_EN = ""
            id = ""
            Filter = ""
        End Sub
        Property Name As String
            Get
                If Einstellungen.Config_Genre.Genre_language = 1 Then
                    Return Name_EN
                Else
                    Return Name_DE
                End If
            End Get
            Set(ByVal value As String)
                If Einstellungen.Config_Genre.Genre_language = 1 Then
                    Name_EN = value
                Else
                    Name_DE = value
                End If
            End Set
        End Property
        Property altName As String
            Get
                If Einstellungen.Config_Genre.Genre_language = 1 Then
                    Return Name_DE
                Else
                    Return Name_EN
                End If
            End Get
            Set(ByVal value As String)
                If Einstellungen.Config_Genre.Genre_language = 1 Then
                    Name_DE = value
                Else
                    Name_EN = value

                End If
            End Set
        End Property
    End Class
    Public Class GenreFilter

        Shared Property FilterList As New List(Of gFilter)
        Shared Function ChangeGenre(ByVal t As String) As String
            If Einstellungen.Config_Genre.Genre_AutoReplace = False Then
                Return t
            End If
            Dim r As String = t
            If Not t = "" Then


                Dim lgen As List(Of String)

                If t.Contains(",") Then
                    Dim gen() As String = t.Split(CChar(","))

                    lgen = gen.ToList

                Else
                    lgen = New List(Of String)
                    lgen.Add(t.Trim)
                End If
                Dim rgen As New List(Of String)
                For Each y In lgen
                    Dim repla As Boolean = True
                    For Each s In FilterList
                        y = y.Trim
                        If y = s.altName Then
                            '//Alternative Name
                            y = s.Name
                        Else
                            '//Filter anwenden
                            If Not s.Filter = "" Then
                                If s.Filter.Contains(";") Then
                                    Dim gen() As String = s.Filter.Split(CChar(";"))
                                    If gen.Length > 0 Then
                                        For x As Integer = 0 To gen.Length - 1
                                            If y = gen(x).Trim Then
                                                y = s.Name
                                            End If
                                        Next
                                    End If
                                Else
                                    If y = s.Filter.Trim Then
                                        y = s.Name
                                    End If
                                End If
                            End If
                        End If
                        '//ggf. Löschen
                        If Einstellungen.Config_Genre.Genre_AutoDontAccept = True Then
                            If s.Name = y Then
                                repla = False

                            End If
                        Else
                            repla = False
                        End If

                    Next
                    If repla = True Then
                    Else
                        If Not rgen.Contains(y) Then
                            rgen.Add(y)
                        End If

                    End If
                    'If r = "" Then
                    '    r = y
                    'Else
                    '    r &= ", " & y
                    'End If
                Next
                r = ""

                Dim l() As String = rgen.ToArray
                Array.Sort(l)
                If l.Length > 0 Then
                    For x As Integer = 0 To l.Length - 1

                        If r = "" Then
                            r = l(x)
                        Else
                            r &= ", " & l(x)
                        End If
                    Next
                Else
                    r = ""
                End If
            End If

            Return r
        End Function
        Public Shared Function Load_standard() As List(Of gFilter)
            Dim xml As New XmlDocument
            xml.LoadXml(My.Resources.setGenre.ToString())
            Dim l As New List(Of gFilter)



            Dim j As Integer
            Dim xmln As XmlNode

            j = xml.SelectNodes("//Genre").Count

            If j > 0 Then
                For x As Integer = 0 To j - 1
                    xmln = xml.SelectNodes("//Genre").Item(x)
                    Dim cn As XmlNodeList = xmln.ChildNodes
                    If cn.Count > 0 Then
                        Dim gF As New gFilter



                        For y As Integer = 0 To cn.Count - 1
                            Select Case cn(y).Name
                                Case Is = "id"
                                    gF.id = cn(y).InnerText
                                Case Is = "Name-EN"
                                    gF.Name_EN = cn(y).InnerText
                                Case Is = "Name-DE"
                                    gF.Name_DE = cn(y).InnerText
                                Case Is = "Filter"
                                    gF.Filter = cn(y).InnerText

                            End Select
                        Next
                        l.Add(gF)
                    End If
                    '.Visible = cn("Zeigen").InnerText
                    '.Width = cn("Breite").InnerText
                    '.DisplayIndex = cn("Position").InnerText
                    '.HeaderText = cn("Name").InnerText



                Next
            End If
            Return l
            'Sets()
            'cs = Main.DataGridView1.Columns
        End Function
        Public Shared Sub Save()
            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(IO.Path.Combine(SettingsPath, "Genre.xml"), enc)
            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4

                .WriteStartDocument()
                .WriteStartElement("Genres") ' <Person 

                If FilterList.Count > 0 Then
                    For i As Integer = 0 To FilterList.Count - 1
                        .WriteStartElement("Genre") ' <Person 
                        .WriteStartElement("id") ' <Person 
                        .WriteValue(FilterList(i).id)
                        .WriteEndElement() 'end nam
                        .WriteStartElement("Name-DE") ' <Person 
                        .WriteValue(FilterList(i).Name_DE)
                        .WriteEndElement()
                        .WriteStartElement("Name-EN") ' <Person 
                        .WriteValue(FilterList(i).Name_EN)
                        .WriteEndElement()
                        .WriteStartElement("Filter") ' <Person 
                        .WriteValue(FilterList(i).Filter)
                        .WriteEndElement() 'end nam
                        .WriteEndElement() 'end nam
                    Next
                End If
                .WriteEndElement() 'end nam
                .Close()
            End With


        End Sub
        Public Shared Sub Load()
            If Not IO.File.Exists(IO.Path.Combine(SettingsPath, "Genre.xml")) Then
                'My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Einstellungen.SettingsPath, "Genre.xml"), My.Resources.setGenre.ToString(), False)
                Dim xmlg As New XmlDocument
                xmlg.LoadXml(My.Resources.setGenre.ToString())
                xmlg.Save(IO.Path.Combine(Einstellungen.SettingsPath, "Genre.xml"))

            End If


            Dim xml As XmlDocument ' Unser Document Container

            xml = New XmlDocument

            xml.Load(IO.Path.Combine(SettingsPath, "Genre.xml"))
            Dim XMLReader As Xml.XmlReader _
            = New Xml.XmlNodeReader(xml)

            Dim j As Integer
            Dim xmln As XmlNode

            j = xml.SelectNodes("//Genre").Count

            If j > 0 Then
                For x As Integer = 0 To j - 1
                    xmln = xml.SelectNodes("//Genre").Item(x)
                    Dim cn As XmlNodeList = xmln.ChildNodes
                    If cn.Count > 0 Then
                        Dim gF As New gFilter



                        For y As Integer = 0 To cn.Count - 1
                            Select Case cn(y).Name
                                Case Is = "id"
                                    gF.id = cn(y).InnerText
                                Case Is = "Name-EN"
                                    gF.Name_EN = cn(y).InnerText
                                Case Is = "Name-DE"
                                    gF.Name_DE = cn(y).InnerText
                                Case Is = "Filter"
                                    gF.Filter = cn(y).InnerText

                            End Select
                        Next
                        FilterList.Add(gF)
                    End If
                    '.Visible = cn("Zeigen").InnerText
                    '.Width = cn("Breite").InnerText
                    '.DisplayIndex = cn("Position").InnerText
                    '.HeaderText = cn("Name").InnerText



                Next
            End If

            'Sets()
            'cs = Main.DataGridView1.Columns
        End Sub

    End Class
    Public Class CostumFilter

        Shared Property List As New List(Of String)

        Public Shared Sub Save()
            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(IO.Path.Combine(SettingsPath, "Filter.xml"), enc)
            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4

                .WriteStartDocument()
                .WriteStartElement("Filter") ' <Person 

                If List.Count > 0 Then
                    For i As Integer = 0 To List.Count - 1
                        .WriteStartElement("cFilter") ' <Person 

                        .WriteValue(List(i))

                        .WriteEndElement() 'end nam
                    Next
                End If
                .WriteEndElement() 'end nam
                .Close()
            End With


        End Sub
        Public Shared Sub Load()
            If Not IO.File.Exists(IO.Path.Combine(SettingsPath, "Filter.xml")) Then
                'My.Computer.FileSystem.WriteAllText(IO.Path.Combine(Einstellungen.SettingsPath, "Genre.xml"), My.Resources.setGenre.ToString(), False)
                Dim xmlg As New XmlDocument
                xmlg.LoadXml(My.Resources.CostumFilter.ToString())
                xmlg.Save(IO.Path.Combine(Einstellungen.SettingsPath, "Filter.xml"))

            End If


            Dim xml As XmlDocument ' Unser Document Container

            xml = New XmlDocument

            xml.Load(IO.Path.Combine(SettingsPath, "Filter.xml"))
            'Dim XMLReader As Xml.XmlReader _
            '= New Xml.XmlNodeReader(xml)

            Dim j As Integer
            Dim xmln As XmlNode

            j = xml.SelectNodes("//cFilter").Count

            If j > 0 Then
                For x As Integer = 0 To j - 1
                    xmln = xml.SelectNodes("//cFilter").Item(x)
                    List.Add(xmln.InnerText.ToString)
                Next
            End If
        End Sub

    End Class


    Public Shared Sub Show()
        Load()
        Settings.Show()

    End Sub


    Public Class Columns
        'Public Shared Property start As opt_ColumnCollection
        'Public Shared Property standard As opt_ColumnCollection
        'Public Shared Sub Sets()
        '    'cs = New DataGridViewColumnCollection
        '    Dim m As New opt_ColumnCollection
        '    m.Name = "Start"

        '    For x As Integer = 0 To Main.DataGridView1.Columns.Count - 1
        '        Dim s As New opt_column
        '        s.Visible = Main.DataGridView1.Columns(x).Visible
        '        s.Width = Main.DataGridView1.Columns(x).Width
        '        s.DisplayIndex = Main.DataGridView1.Columns(x).DisplayIndex
        '        m.Columns.Add(s)
        '    Next
        '    start = m

        '    Dim mo As New opt_ColumnCollection
        '    mo.Name = "Standard"

        '    For x As Integer = 0 To Main.DataGridView1.Columns.Count - 1
        '        Dim s As New opt_column
        '        s.Visible = False
        '        s.Width = Main.DataGridView1.Columns(x).Width
        '        s.DisplayIndex = Main.DataGridView1.Columns(x).DisplayIndex
        '        mo.Columns.Add(s)
        '    Next
        '    mo.Columns(Main.Column_Fortschritt.Index).Visible = True
        '    mo.Columns(Main.Column_Rate_Backdrops.Index).Visible = True
        '    mo.Columns(Main.Column_Rate_Cover.Index).Visible = True
        '    mo.Columns(Main.Column_Rate_Info.Index).Visible = True
        '    mo.Columns(Main.Column_Rate_MediaInfo.Index).Visible = True
        '    mo.Columns(Main.Column_Titel.Index).Visible = True
        '    mo.Columns(Main.Column_Fortschritt.Index).DisplayIndex = 0
        '    mo.Columns(Main.Column_Rate_Backdrops.Index).DisplayIndex = 1
        '    mo.Columns(Main.Column_Rate_Cover.Index).DisplayIndex = 2
        '    mo.Columns(Main.Column_Rate_Info.Index).DisplayIndex = 3
        '    mo.Columns(Main.Column_Rate_MediaInfo.Index).DisplayIndex = 4
        '    mo.Columns(Main.Column_Titel.Index).DisplayIndex = 5
        '    standard = mo

        'End Sub
        'Public Shared Sub Gets(ByVal cs As opt_ColumnCollection)
        '    For x As Integer = 0 To cs.Columns.Count - 1
        '        Main.DataGridView1.Columns(x).Visible = cs.Columns(x).Visible
        '        Main.DataGridView1.Columns(x).Width = cs.Columns(x).Width
        '        Main.DataGridView1.Columns(x).DisplayIndex = cs.Columns(x).DisplayIndex

        '    Next
        'End Sub
        Public Shared Sub Save()
            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(IO.Path.Combine(SettingsPath, "Columns.xml"), enc)
            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4

                .WriteStartDocument()
                .WriteStartElement("Spalten") ' <Person 


                For i As Integer = 0 To MainForm.Movie_GridView.Columns.Count - 1
                    .WriteStartElement("Spalte") ' <Person 
                    .WriteStartElement("Index") ' <Person 
                    .WriteValue(MainForm.Movie_GridView.Columns(i).Index)
                    .WriteEndElement() 'end nam
                    .WriteStartElement("Name") ' <Person 
                    .WriteValue(MainForm.Movie_GridView.Columns(i).HeaderText)
                    .WriteEndElement()
                    .WriteStartElement("Zeigen") ' <Person 
                    .WriteValue(MainForm.Movie_GridView.Columns(i).Visible)
                    .WriteEndElement() 'end nam
                    .WriteStartElement("Breite") ' <Person 
                    .WriteValue(MainForm.Movie_GridView.Columns(i).Width)
                    .WriteEndElement() 'end nam
                    .WriteStartElement("Position") ' <Person 
                    .WriteValue(MainForm.Movie_GridView.Columns(i).DisplayIndex)
                    .WriteEndElement()

                    .WriteEndElement() 'end nam
                Next
                .WriteEndElement() 'end nam
                .Close()
            End With


        End Sub


        Public Shared Sub Load()
            If IO.File.Exists(IO.Path.Combine(SettingsPath, "Columns.xml")) Then

                Dim xml As XmlDocument ' Unser Document Container

                xml = New XmlDocument

                xml.Load(IO.Path.Combine(SettingsPath, "Columns.xml"))
                'xml.Load(IO.Path.Combine(SettingsPath, "Columns.xml"))
                'Dim XMLReader As Xml.XmlReader _
                '= New Xml.XmlNodeReader(xml)

                Dim j As Integer
                Dim xmln As XmlNode

                j = xml.SelectNodes("//Spalte").Count
                If j >= MainForm.Movie_GridView.Columns.Count Then

                    If j > 0 Then
                        For x As Integer = 0 To j - 1
                            xmln = xml.SelectNodes("//Spalte").Item(x)
                            Dim cn As XmlNodeList = xmln.ChildNodes
                            If cn.Count > 0 Then
                                Dim i As Integer = CInt(cn(0).InnerText)

                                If i > -1 Then
                                    With MainForm.Movie_GridView.Columns(i)
                                        For y As Integer = 0 To cn.Count - 1
                                            Select Case cn(y).Name
                                                Case Is = "Zeigen"
                                                    .Visible = CBool(cn(y).InnerText)
                                                Case Is = "Breite"
                                                    .Width = CInt(cn(y).InnerText)
                                                Case Is = "Position"
                                                    .DisplayIndex = CInt(cn(y).InnerText)

                                            End Select
                                        Next
                                        '.Visible = cn("Zeigen").InnerText
                                        '.Width = cn("Breite").InnerText
                                        '.DisplayIndex = cn("Position").InnerText
                                        '.HeaderText = cn("Name").InnerText

                                    End With
                                End If
                            End If



                        Next
                    End If

                End If
            End If
            'Sets()
            'cs = Main.DataGridView1.Columns
        End Sub
    End Class

    Public Class UserInterFace
        Shared Property win_h As Integer
        Shared Property win_w As Integer
        Shared Property win_x As Integer
        Shared Property win_y As Integer
        Shared Property Fanartsize_w As Integer
        Shared Property Fanartsize_h As Integer
        Shared Property Fanartsize_maximized As Boolean = False
        Shared Property Fanartsize_previewsize As Integer
        Shared Property myBrowser_Plugins_show As Boolean = True






        Public Shared Sub Load()
            If IO.File.Exists(IO.Path.Combine(SettingsPath, "Interface.xml")) Then



                Dim xml As XmlDocument ' Unser Document Container

                xml = New XmlDocument

                xml.Load(IO.Path.Combine(SettingsPath, "Interface.xml"))
                'xml.Load(IO.Path.Combine(SettingsPath, "Interface.xml"))
                'Dim XMLReader As Xml.XmlReader _
                '= New Xml.XmlNodeReader(xml)
                Dim xmln As XmlNode




                Fanartsize_w = If(xml.SelectNodes("//Fanartsize_w").Count > 0, toInt(xml.SelectSingleNode("//Fanartsize_w").InnerText, -1), -1)
                Fanartsize_h = If(xml.SelectNodes("//Fanartsize_h").Count > 0, toInt(xml.SelectSingleNode("//Fanartsize_h").InnerText, -1), -1)
                Fanartsize_previewsize = If(xml.SelectNodes("//Fanartsize_previewsize").Count > 0, toInt(xml.SelectSingleNode("//Fanartsize_previewsize").InnerText, 0), 0)
                Fanartsize_maximized = If(xml.SelectNodes("//Fanartsize_maximized").Count > 0, toBool(xml.SelectSingleNode("//Fanartsize_maximized").InnerText, True), True)
                Dim s As Boolean = False
                If xml.SelectNodes("//Fenster").Count > 0 Then
                    xmln = xml.SelectNodes("//Fenster").Item(0)


                    s = toBool(xmln.Item("Maximiert").InnerText)
                    If s = True Then
                        MainForm.WindowState = FormWindowState.Maximized
                    Else
                        MainForm.WindowState = FormWindowState.Normal
                    End If


                    MainForm.Size = New System.Drawing.Size(toInt(xmln.Item("Größe").Attributes("width").Value, MainForm.Size.Width), _
                                                   toInt(xmln.Item("Größe").Attributes("height").Value, MainForm.Size.Height))
                    MainForm.Location = New System.Drawing.Point(toInt(xmln.Item("Position").Attributes("X").Value, MainForm.Location.X), _
                                         toInt(xmln.Item("Position").Attributes("Y").Value, MainForm.Location.Y))

                End If
                If xml.SelectNodes("//Panel").Count > 0 Then
                    xmln = xml.SelectNodes("//Panel").Item(0)

                    MainForm.SplitContainer_Infopanel.Panel2Collapsed = toBool(xmln.Item("Panel_Info").Attributes("visible").Value)
                    ' MsgBox(Main.SplitContainer_Infopanel.SplitterDistance)
                    MainForm.SplitContainer_treepanel.Panel1Collapsed = toBool(xmln.Item("Panel_Tree").Attributes("visible").Value)
                    Dim wi As Integer = toInt(xmln.Item("Panel_Info").Attributes("width").Value, MainForm.SplitContainer_Infopanel.SplitterDistance)
                    'If s = True Then
                    '    If i > 80 Then
                    '        i -= 80
                    '    End If
                    'Else
                    '    'i += 80
                    'End If

                    MainForm.SplitContainer_Infopanel.SplitterDistance = wi
                    '  MsgBox(Main.SplitContainer_Infopanel.SplitterDistance)

                    MainForm.SplitContainer_treepanel.SplitterDistance = toInt(xmln.Item("Panel_Tree").Attributes("width").Value, MainForm.SplitContainer_treepanel.SplitterDistance)
                    If MainForm.SplitContainer_treepanel.Panel1Collapsed = True Then
                        MainForm.ToolStripButton11.Image = Toolbar16.Tree_in
                    Else
                        MainForm.ToolStripButton11.Image = Toolbar16.Tree_out
                    End If
                    If MainForm.SplitContainer_Infopanel.Panel2Collapsed = True Then
                        MainForm.Infobaranzeigen_tool.Image = Toolbar16.Panel_in
                    Else
                        MainForm.Infobaranzeigen_tool.Image = Toolbar16.Panel_out

                    End If

                End If
                If xml.SelectNodes("//Toolbar").Count > 0 Then
                    xmln = xml.SelectNodes("//Toolbar").Item(0)

                    UserAbrufen.useImdb = toBool(xmln.Item("DatenbankSuche").Attributes("imdb").Value)

                    Dim mo As Integer = toInt(xmln.Item("DatenbankSuche").Attributes("modus").Value, 1)

                    Select Case mo
                        Case Is = 0
                            UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch
                            MainForm.ToolStrip_Suche.Image = Toolbar16.search_schnell1
                            MainForm.Exp_Suche.Image = Toolbar16.search_schnell1
                        Case Is = 1
                            UserAbrufen.Suche_Mode = OnlineSearchmode.Normal
                            MainForm.ToolStrip_Suche.Image = Toolbar16.Suche_datenbank
                            MainForm.Exp_Suche.Image = Toolbar16.Suche_datenbank
                        Case Is = 2
                            UserAbrufen.Suche_Mode = OnlineSearchmode.Exact
                            MainForm.ToolStrip_Suche.Image = Toolbar16.search_exact1
                            MainForm.Exp_Suche.Image = Toolbar16.search_exact1
                        Case Else
                            UserAbrufen.Suche_Mode = OnlineSearchmode.Normal
                            MainForm.ToolStrip_Suche.Image = Toolbar16.Suche_datenbank
                            MainForm.Exp_Suche.Image = Toolbar16.Suche_datenbank
                    End Select

                    Try
                        mo = toInt(xmln.Item("FanartSuche").Attributes("modus").Value, 1)
                    Catch ex As Exception
                        mo = 1
                    End Try


                    Select Case mo
                        Case Is = 0
                            UserAbrufen.Download_Mode = OnlineSearchmode.Automatisch
                            MainForm.exp_Download.Image = Toolbar16.Fanart_search_fast
                            MainForm.Cover_Tool.Image = Toolbar16.Fanart_search_fast
                        Case Is = 1
                            UserAbrufen.Download_Mode = OnlineSearchmode.Normal
                            MainForm.exp_Download.Image = Toolbar16.View_extragroß
                            MainForm.Cover_Tool.Image = Toolbar16.View_extragroß

                        Case Else
                            UserAbrufen.Suche_Mode = OnlineSearchmode.Normal
                            MainForm.exp_Download.Image = Toolbar16.View_extragroß
                            MainForm.Cover_Tool.Image = Toolbar16.View_extragroß
                    End Select




                End If
                If xml.SelectNodes("//Symbolleisten").Count > 0 Then
                    xmln = xml.SelectNodes("//Symbolleisten").Item(0)

                    'Main.Nov_Main.Visible = If(xml.SelectNodes("//Toolbar").Count > 0, toBool(xml.SelectSingleNode("//Toolbar").InnerText, True), True)
                    MainForm.MyStatusStrip.Visible = If(xml.SelectNodes("//Status").Count > 0, toBool(xml.SelectSingleNode("//Status").InnerText, True), True)
                    MainForm.Nav_Menu.Visible = If(xml.SelectNodes("//Menu").Count > 0, toBool(xml.SelectSingleNode("//Menu").InnerText, True), True)
                    MainForm.InfoPanel_Movie1.ShowLinkBar = If(xml.SelectNodes("//LinksBar").Count > 0, toBool(xml.SelectSingleNode("//LinksBar").InnerText, True), True)

                End If

                MainForm.Filter_Dropdown_OPT.Text = If(xml.SelectNodes("//RowFilter_Mode").Count > 0, xml.SelectSingleNode("//RowFilter_Mode").InnerText, "Titel")
                MainForm.ToolStripTextBox1.Text = If(xml.SelectNodes("//RowFilter_Text").Count > 0, xml.SelectSingleNode("//RowFilter_Text").InnerText, "")

                Dim m As Boolean = True
                m = If(xml.SelectNodes("//Dynamische_Toolbar").Count > 0, toBool(xml.SelectSingleNode("//Dynamische_Toolbar").InnerText, False), False)

                MainForm.Nov_Main.Visible = Not m
                MainForm.Nov_Main_alt.Visible = m
                MainForm.Refresh_Toolbar_States()
                m = If(xml.SelectNodes("//Toolbar_Rand_hervorheben").Count > 0, toBool(xml.SelectSingleNode("//Toolbar_Rand_hervorheben").InnerText, True), True)

                Config_Design.alwaysExplore = If(xml.SelectNodes("//alwaysExplore").Count > 0, toBool(xml.SelectSingleNode("//alwaysExplore").InnerText, False), False)
                MainForm.ToolStripSeparator2.Visible = m
                MainForm.ToolStripSeparator43.Visible = m
                MainForm.ToolStripSeparator48.Visible = m
                MainForm.ToolStripSeparator49.Visible = m
                m = True
                m = If(xml.SelectNodes("//Organize_button_text").Count > 0, toBool(xml.SelectSingleNode("//Organize_button_text").InnerText, True), True)
                If m = True Then
                    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Text
                Else
                    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
                Dim i As Integer = If(xml.SelectNodes("//info_panel_color").Count > 0, toInt(xml.SelectSingleNode("//info_panel_color").InnerText, 1), 1)
                If i = 0 Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.FromArgb(241, 245, 251)
                ElseIf i = 1 Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = SystemColors.Control
                ElseIf i = 2 Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.White
                End If
            End If
        End Sub
        Public Shared Sub Save()
            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(IO.Path.Combine(SettingsPath, "Interface.xml"), enc)
            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4

                .WriteStartDocument()
                .WriteStartElement("Interface")

                .WriteStartElement("Fanart")

                .WriteStartElement("Fanartsize_w")
                .WriteValue(Fanartsize_w)
                .WriteEndElement()

                .WriteStartElement("Fanartsize_h")
                .WriteValue(Fanartsize_h)
                .WriteEndElement()

                .WriteStartElement("Fanartsize_previewsize")
                .WriteValue(Fanartsize_previewsize)
                .WriteEndElement()
                .WriteStartElement("Fanartsize_maximized")
                .WriteValue(Fanartsize_maximized)
                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("Panel")
                .WriteStartElement("Panel_Info")
                .WriteAttributeString("visible", CStr(MainForm.SplitContainer_Infopanel.Panel2Collapsed))
                .WriteAttributeString("width", CStr(MainForm.SplitContainer_Infopanel.SplitterDistance))
                .WriteEndElement()
                .WriteStartElement("Panel_Tree")
                .WriteAttributeString("visible", CStr(MainForm.SplitContainer_treepanel.Panel1Collapsed))
                .WriteAttributeString("width", CStr(MainForm.SplitContainer_treepanel.SplitterDistance))
                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("Toolbar")
                .WriteStartElement("DatenbankSuche")
                Dim i As Integer = 1
                Select Case Einstellungen.UserAbrufen.Suche_Mode
                    Case Is = OnlineSearchmode.Automatisch
                        i = 0
                    Case Is = OnlineSearchmode.Normal
                        i = 1
                    Case Is = OnlineSearchmode.Exact
                        i = 2
                End Select
                .WriteAttributeString("modus", CStr(i))
                .WriteAttributeString("imdb", CStr(Einstellungen.UserAbrufen.useImdb))
                .WriteStartElement("FanartSuche")
                i = 1
                Select Case Einstellungen.UserAbrufen.Download_Mode
                    Case Is = OnlineSearchmode.Automatisch
                        i = 0
                    Case Is = OnlineSearchmode.Normal
                        i = 1
                End Select
                .WriteAttributeString("modus", CStr(i))


                .WriteEndElement()
                .WriteEndElement()

                .WriteStartElement("Fenster")

                .WriteStartElement("Maximiert")
                If MainForm.WindowState = FormWindowState.Maximized Then
                    .WriteValue(True)
                Else
                    .WriteValue(False)
                End If
                .WriteEndElement() 'end nam

                .WriteStartElement("Größe") ' <Perso
                If MainForm.WindowState = FormWindowState.Normal Then
                    .WriteAttributeString("height", CStr(MainForm.Size.Height))
                    .WriteAttributeString("width", CStr(MainForm.Size.Width))
                Else
                    .WriteAttributeString("height", CStr(win_h))
                    .WriteAttributeString("width", CStr(win_w))
                End If
                .WriteEndElement() 'end nam

                .WriteStartElement("Position") ' <Perso
                If MainForm.WindowState = FormWindowState.Normal Then
                    .WriteAttributeString("X", CStr(MainForm.Location.X))
                    .WriteAttributeString("Y", CStr(MainForm.Location.Y))
                Else
                    .WriteAttributeString("X", CStr(win_x))
                    .WriteAttributeString("Y", CStr(win_y))
                End If
                .WriteEndElement()

                .WriteEndElement()

                .WriteStartElement("Symbolleisten") ' <Person 
                .WriteStartElement("Menu") ' <Person 
                .WriteValue(MainForm.Nav_Menu.Visible)
                .WriteEndElement()
                .WriteStartElement("Status") ' <Person 
                .WriteValue(MainForm.MyStatusStrip.Visible)
                .WriteEndElement()
                .WriteStartElement("Toolbar") ' <Person 
                Dim b As Boolean = True
                If MainForm.Nov_Main.Visible = False And MainForm.Nov_Main_alt.Visible = False Then
                    b = False
                End If
                .WriteValue(b)
                .WriteEndElement()
                .WriteStartElement("LinksBar") ' <Person 
                .WriteValue(MainForm.InfoPanel_Movie1.ShowLinkBar)
                .WriteEndElement()
                .WriteEndElement()
                .WriteStartElement("RowFilter_Mode")
                .WriteValue(MainForm.Filter_Dropdown_OPT.Text)
                .WriteEndElement()
                .WriteStartElement("RowFilter_Text")
                .WriteValue(MainForm.ToolStripTextBox1.Text)
                .WriteEndElement()

                .WriteStartElement("Toolbar_Rand_hervorheben")
                If MainForm.ToolStripSeparator2.Visible = True Or MainForm.ToolStripSeparator49.Visible = True Then
                    .WriteValue(True)
                Else
                    .WriteValue(False)
                End If
                .WriteEndElement()
                .WriteStartElement("Dynamische_Toolbar")
                If b = False Then
                    .WriteValue(False)
                Else
                    .WriteValue(MainForm.Nov_Main_alt.Visible)
                End If
                .WriteEndElement()


                .WriteStartElement("Organize_button_text")
                If MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Text Then
                    .WriteValue(True)
                Else
                    .WriteValue(False)
                End If
                .WriteEndElement()



                .WriteStartElement("info_panel_color")
                If MainForm.SplitContainer_Infopanel.Panel2.BackColor = SystemColors.Control Then
                    .WriteValue(1)
                ElseIf MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.White Then
                    .WriteValue(2)
                ElseIf MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.FromArgb(241, 245, 251) Then
                    .WriteValue(0)
                End If
                .WriteEndElement()


                .WriteStartElement("alwaysExplore")
                .WriteValue(Config_Design.alwaysExplore)
                .WriteEndElement()

                .WriteEndElement()
                .Close()

            End With

        End Sub
    End Class
    Public Class UserAbrufen
        Public Shared Property Suche_Mode As OnlineSearchmode
        Public Shared Property useImdb As Boolean
        'Shared Property ofdbgwroot As String = "http://ofdbgw.home-of-root.de/"
        'Dim root As String = "http://ofdbgw.org/"
        'Dim root As String = "http://ofdbgw.w-root.de/"
        'Dim root As String = "http://ofdbgw.home-of-root.de/"
        'Dim root As String = "http://ofdbgw.scheeper.net/"
        Shared Property ofdbgwroot As String = "http://ofdbgw.org/"
        Shared Property tmdbapibase_url As String = "http://d3gtl9l2a4fn1j.cloudfront.net/t/p/"
        Shared Property tmdbapiroot As String = "http://api.themoviedb.org/2.1/"
        Shared Property tmdbapi3root As String = "http://api.themoviedb.org/3/"
        Shared Property tmdbapiKey As String = "5fe800e9f7891b9131c0059be62a36d0"
        Shared Property Download_Mode As OnlineSearchmode

        Shared Property tmdbapilanguage As String = "de"
        Shared Sub Loadtmdbbaseurl(ByVal ForcetoLoad As Boolean)
            Dim s As String = IO.Path.Combine(SettingsPath, "tmdb_config.xml")
            Dim xml As Xml.XmlDocument
          
            If IO.File.Exists(s) And ForcetoLoad = False Then
                xml = New XmlDocument
                xml.Load(s)
            Else
                xml = MyFunctions.HttploadJsontoXML(Einstellungen.UserAbrufen.tmdbapi3root & "configuration?api_key=" & Einstellungen.UserAbrufen.tmdbapiKey, "tmdb3.config")
                xml.Save(s)
            End If
            If IsNothing(xml) Then
                Return
            End If
            tmdbapibase_url = If(xml.SelectNodes("//base_url").Count > 0, xml.SelectSingleNode("//base_url").InnerText, "")

        End Sub
    End Class

    Public Class UserUpdate
        Shared Property Changes As String = ""
        Shared Property NewVersion As String = ""
        Shared Property OldVersion As String = ""

        Shared Property Aktueller As Boolean = False

        Shared Property Updateready As Boolean = False


    End Class


    Public Class Config_Design
        Shared Property alwaysExplore As Boolean = False
        Shared Property Dynamische As Boolean = False
        Shared Sub Standard()
            With Settings
                .Config_Design_rand_hervorheben.Checked = True
                .RadioButton1.Checked = True
                .RadioButton7.Checked = True
                .RadioButton10.Checked = True
                .alwaysExplore.Checked = False
            End With
        End Sub

        Shared Sub Load()
            With Settings
                .alwaysExplore.Checked = alwaysExplore
                If MainForm.SplitContainer_Infopanel.Panel2.BackColor = SystemColors.Control Then
                    .RadioButton7.Checked = True
                ElseIf MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.White Then
                    .RadioButton5.Checked = True
                ElseIf MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.FromArgb(241, 245, 251) Then
                    .RadioButton6.Checked = True
                End If
                .RadioButton2.Checked = MainForm.Nov_Main.Visible
                If MainForm.ToolStripSeparator2.Visible = True Or MainForm.ToolStripSeparator49.Visible = True Then
                    .Config_Design_rand_hervorheben.Checked = True
                Else
                    .Config_Design_rand_hervorheben.Checked = False
                End If
                If MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Text Then
                    .RadioButton10.Checked = True
                Else
                    .RadioButton10.Checked = False
                End If
            End With
        End Sub
        Shared Sub Save()
            With Settings
                alwaysExplore = .alwaysExplore.Checked
                If .RadioButton7.Checked = True Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = SystemColors.Control
                ElseIf .RadioButton5.Checked = True Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.White
                ElseIf .RadioButton6.Checked = True Then
                    MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.FromArgb(241, 245, 251)
                End If
                If Settings.RadioButton2.Checked = False Then
                    MainForm.Nov_Main.Visible = False
                    MainForm.Nov_Main_alt.Visible = True
                    MainForm.Refresh_Toolbar_States()
                Else
                    MainForm.Nov_Main.Visible = True
                    MainForm.Nov_Main_alt.Visible = False
                    MainForm.Refresh_Toolbar_States()
                End If
                If .RadioButton10.Checked Then
                    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Text
                Else
                    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Image
                End If
                MainForm.ToolStripSeparator2.Visible = .Config_Design_rand_hervorheben.Checked
                MainForm.ToolStripSeparator43.Visible = .Config_Design_rand_hervorheben.Checked
                MainForm.ToolStripSeparator48.Visible = .Config_Design_rand_hervorheben.Checked
                MainForm.ToolStripSeparator49.Visible = .Config_Design_rand_hervorheben.Checked
            End With
        End Sub







    End Class
    Public Class Config_Scrapper


        Shared Property Scrapper_IMDB_dominant_ScrapperValues As New List(Of Scrapper_Valuetype) From {CType("1", Scrapper_Valuetype)}
        Shared Property Scrapper_MoPi_dominant_ScrapperValues As New List(Of Scrapper_Valuetype) '2
        Shared Property Scrapper_OFDb_dominant_ScrapperValues As New List(Of Scrapper_Valuetype) '2
        Shared Property Scrapper_TMDB_dominant_ScrapperValues As New List(Of Scrapper_Valuetype) '2
        Shared Property Scrapper_TMDB_OneHit As Boolean = True
        Shared Property Scrapper_OFDB_OneHit As Boolean = True
        Shared Property Scrapper_Search_with_Year As Boolean = True

        Shared Sub Load()
            With Settings

            End With
        End Sub
        Shared Sub Save()
            With Settings

            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Laden").Count > 0 Then
                xml = xmln.SelectNodes("//Laden").Item(0)

                'Abrufen_MediaInfo_StandardSprache = If(xml.SelectNodes("//Abrufen_MediaInfo_StandardSprache").Count > 0, xml.SelectSingleNode("//Abrufen_MediaInfo_StandardSprache").InnerText, "")
                'Abrufen_MediaInfo_Dauer_AKT = If(xml.SelectNodes("//Abrufen_MediaInfo_Dauer_AKT").Count > 0, toBool(xml.SelectSingleNode("//Abrufen_MediaInfo_Dauer_AKT").InnerText, True), True)
                'Abrufen_MediaInfo_Dauer_Format = If(xml.SelectNodes("//Abrufen_MediaInfo_Dauer_Format").Count > 0, toInt(xml.SelectSingleNode("//Abrufen_MediaInfo_Dauer_Format").InnerText, 0), 0)
                'Abrufen_Backdrops_Count = If(xml.SelectNodes("//Abrufen_Backdrops_Count").Count > 0, toInt(xml.SelectSingleNode("//Abrufen_Backdrops_Count").InnerText, 0), 0)
                'Abrufen_MoviePilotCover = If(xml.SelectNodes("//Abrufen_MoviePilotCover").Count > 0, toBool(xml.SelectSingleNode("//Abrufen_MoviePilotCover").InnerText, True), True)

                'Dim s As String = If(xml.SelectNodes("//Abrufen_Backdrops_Modus").Count > 0, xml.SelectSingleNode("//Abrufen_Backdrops_Modus").InnerText, "")

                'Select Case s
                '    Case Is = "3"
                '        Abrufen_Backdrops_Modus = FanartAutoselectMode.Zufall
                '    Case Is = "0"
                '        Abrufen_Backdrops_Modus = FanartAutoselectMode.Alle
                '    Case Is = "2"
                '        Abrufen_Backdrops_Modus = FanartAutoselectMode.Reihenfolge
                '    Case Else
                '        Abrufen_Backdrops_Modus = FanartAutoselectMode.Zufall
                'End Select
                's = If(xml.SelectNodes("//Abrufen_Cover_Modus").Count > 0, xml.SelectSingleNode("//Abrufen_Cover_Modus").InnerText, "")

                'Select Case s
                '    Case Is = "3"
                '        Abrufen_Cover_Modus = FanartAutoselectMode.Zufall
                '    Case Is = "1"
                '        Abrufen_Cover_Modus = FanartAutoselectMode.Keine
                '    Case Is = "2"
                '        Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge
                '    Case Else
                '        Abrufen_Cover_Modus = FanartAutoselectMode.Zufall
                'End Select
            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                '.WriteStartElement("Abrufen")

                '.WriteStartElement("Abrufen_MediaInfo_StandardSprache")
                '.WriteValue(Abrufen_MediaInfo_StandardSprache)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_MoviePilotCover")
                '.WriteValue(Abrufen_MoviePilotCover)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_MediaInfo_Dauer_AKT")
                '.WriteValue(Abrufen_MediaInfo_Dauer_AKT)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_MediaInfo_Dauer_Format")
                '.WriteValue(Abrufen_MediaInfo_Dauer_Format)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_Backdrops_Count")
                '.WriteValue(Abrufen_Backdrops_Count)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_Backdrops_Modus")
                'Dim r As String = "0"
                'Select Case Abrufen_Backdrops_Modus
                '    Case Is = FanartAutoselectMode.Alle
                '        r = "0"
                '    Case Is = FanartAutoselectMode.Reihenfolge
                '        r = "2"
                '    Case Is = FanartAutoselectMode.Zufall
                '        r = "3"
                'End Select
                '.WriteValue(r)
                '.WriteEndElement()

                '.WriteStartElement("Abrufen_Cover_Modus")
                'r = "0"
                'Select Case Abrufen_Cover_Modus
                '    Case Is = FanartAutoselectMode.Keine
                '        r = "1"
                '    Case Is = FanartAutoselectMode.Reihenfolge
                '        r = "2"
                '    Case Is = FanartAutoselectMode.Zufall
                '        r = "3"
                'End Select
                '.WriteValue(r)
                '.WriteEndElement()

                '.WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Filter
        Shared Sub StandardVar()
            Dim xml As New XmlDocument
            xml.LoadXml(My.Resources.CostumFilter.ToString())
            Dim j As Integer
            Dim xmln As XmlNode
            Dim List As New List(Of String)
            j = xml.SelectNodes("//cFilter").Count

            If j > 0 Then
                For x As Integer = 0 To j - 1
                    xmln = xml.SelectNodes("//cFilter").Item(x)
                    CostumFilter.List.Add(xmln.InnerText.ToString)
                Next
            End If
        End Sub
        Shared Sub Standard()
            Dim xml As New XmlDocument
            xml.LoadXml(My.Resources.CostumFilter.ToString())
            Dim j As Integer
            Dim xmln As XmlNode
            Dim List As New List(Of String)
            j = xml.SelectNodes("//cFilter").Count

            If j > 0 Then
                For x As Integer = 0 To j - 1
                    xmln = xml.SelectNodes("//cFilter").Item(x)
                    List.Add(xmln.InnerText.ToString)
                Next
            End If


            With Settings
                .TreeView_filter.Nodes.Clear()
                For Each i In List
                    .TreeView_filter.Nodes.Add(i.ToString)
                Next
            End With
        End Sub
        Shared Sub Load()
            With Settings
                .TreeView_filter.Nodes.Clear()
                For Each i In CostumFilter.List
                    .TreeView_filter.Nodes.Add(i.ToString)
                Next
            End With
        End Sub
        Shared Sub Save()
            With Settings
                CostumFilter.List.Clear()
                For Each i As TreeNode In .TreeView_filter.Nodes
                    If Not i.Text = "" Then
                        CostumFilter.List.Add(i.Text)
                    End If
                Next
            End With
        End Sub

    End Class

    Public Class Config_Fortschritt
#Region "----Werte----"
#Region "Ordner"
        Public Shared Cover As Integer = 1
        Public Shared Cover_better As Integer = 1
        Public Shared Backdrops As Integer = 1
        Public Shared Backdrops_more As Integer = 1
        Public Shared Ordnername As Integer = 1
        Public Shared Dateiname As Integer = 1
        Public Shared Trailer As Integer = 1
#End Region
#Region "Informationen XML"
        Public Shared Titel As Integer = 1
        Public Shared Originaltitel As Integer = 1
        Public Shared IMDB_ID As Integer = 1
        Public Shared Darsteller As Integer = 1
        Public Shared Regisseur As Integer = 1
        Public Shared Autoren As Integer = 1
        Public Shared Studios As Integer = 1
        Public Shared Produktionsjahr As Integer = 1
        Public Shared Produktionsland As Integer = 1
        Public Shared Genre As Integer = 1
        Public Shared FSK As Integer = 1
        Public Shared Bewertung As Integer = 1
        Public Shared Spieldauer As Integer = 1
        'Public Shared Kurzbeschreibung As Integer = 1
        Public Shared Inhalt As Integer = 1
        Public Shared Sort As Integer = 1

#End Region
#Region "Filme Plugin"
        'Public Shared MediaInfo As Integer = 1
        'Public Shared Position As Integer = 1
        'Public Shared Datum As Integer = 1
        Public Shared VideoAuflösung As Integer = 1
        Public Shared VideoSeitenverhältnis As Integer = 1
        Public Shared VideoBildwiederholungsrate As Integer = 1
        Public Shared VideoCodec As Integer = 1
        Public Shared AudioKanäle As Integer = 1
        Public Shared AudioCodec As Integer = 1
        Public Shared AudioSprachen As Integer = 1
#End Region
#Region "Episode"
        Public Shared Episode_Inhalt As Integer = 1
        Public Shared Episode_Titel As Integer = 1
        Public Shared Episode_Jahr As Integer = 0
        Public Shared Episode_Darsteller As Integer = 0
        Public Shared Episode_Regisseur As Integer = 0
        Public Shared Episode_Autoren As Integer = 0
        Public Shared Episode_Bewertung As Integer = 0
        Public Shared Episode_Bild As Integer = 1
        Public Shared Episode_Spieldauer As Integer = 1
        Public Shared Episode_VideoAuflösung As Integer = 1
        Public Shared Episode_VideoSeitenverhältnis As Integer = 1
        Public Shared Episode_VideoBildwiederholungsrate As Integer = 1
        Public Shared Episode_VideoCodec As Integer = 1
        Public Shared Episode_AudioKanäle As Integer = 1
        Public Shared Episode_AudioCodec As Integer = 1
        Public Shared Episode_AudioSprachen As Integer = 1
#End Region
#End Region
        Shared Property Fortschritt_cover As Boolean = True

        Shared Property Fortschritt_Cover_Quali As Integer = 1
        Shared Property Fortschritt_Genre As String = "Animation, Zeichentrick, Dokumentation, Dokumentarfilm, Documentation, Musik, Music"

        '''<summary>
        ''' 0 = Normal
        ''' 1 = Plugin
        ''' 2 = Eigene
        ''' </summary>
        ''' <value>0 = Normal; 1= Plugin 2=Eigene</value>
        ''' <returns>0 = Normal; 1= Plugin 2=Eigene</returns>
        ''' <remarks>0 = Normal; 1= Plugin 2=Eigene</remarks>
        Shared Property Fortschritt_Modus As Integer = 1


        Public Shared Sub Standard()
            With Settings
                .Fortschritt_Genre.Text = "Animation, Zeichentrick, Dokumentation, Dokumentarfilm, Documentation, Musik, Music"
                .Fortschritt_Cover.Checked = True
                .Fortschritt_Cover_Quali.Value = 50
                .Fortschritt_modus_Eigene.Checked = False
                .Fortschritt_modus_Normal.Checked = False
                .Fortschritt_modus_Plugin.Checked = True
                .Fortschritt_Ordner.Checked = True
            End With

        End Sub
        Private Shared Function Summeofall_Episoden() As Integer
            Return Episode_Inhalt + _
         Episode_Titel + _
         Episode_Jahr + _
         Episode_Darsteller + _
         Episode_Autoren + _
         Episode_Regisseur + _
         Episode_Bewertung + _
         Episode_Bild + _
         Episode_Spieldauer + _
         Episode_VideoAuflösung + _
         Episode_VideoSeitenverhältnis + _
         Episode_VideoBildwiederholungsrate + _
         Episode_VideoCodec + _
         Episode_AudioKanäle + _
         Episode_AudioCodec + _
         Episode_AudioSprachen
        End Function
        Public Shared Function Summeofall() As Integer
            Return Cover + _
            Cover_better + _
            Backdrops + _
            Backdrops_more + _
            Titel + _
            Originaltitel + _
            IMDB_ID + _
            Darsteller + _
            Regisseur + _
            Autoren + _
            Studios + _
            Produktionsjahr + _
            Produktionsland + _
            Genre + _
            FSK + _
            Bewertung + _
            Spieldauer + _
            Inhalt + _
            Sort + _
            VideoAuflösung + _
            VideoSeitenverhältnis + _
            VideoBildwiederholungsrate + _
            VideoCodec + _
            AudioKanäle + _
            AudioCodec + _
            AudioSprachen + _
            Ordnername + _
            Dateiname + _
            Trailer
        End Function
        Shared ReadOnly Property Summe_Ordner() As Integer
            Get
                Return Ordnername + Dateiname
            End Get
        End Property
        Shared ReadOnly Property Summe_Cover() As Integer
            Get
                Return Cover + Cover_better
            End Get
        End Property
        Shared ReadOnly Property Summe_Backdrop() As Integer
            Get
                Return Backdrops + Backdrops_more
            End Get
        End Property
        Shared ReadOnly Property Summe_Episode_Info() As Integer
            Get
                Return Episode_Inhalt + _
         Episode_Titel + _
         Episode_Jahr + _
         Episode_Darsteller + _
         Episode_Autoren + _
         Episode_Regisseur + _
         Episode_Bewertung

            End Get
        End Property
        Shared ReadOnly Property Summe_Info() As Integer
            Get
                Return Titel + Originaltitel + IMDB_ID + Darsteller + Regisseur + Autoren + Studios + Produktionsjahr + Produktionsland + Genre + FSK + Bewertung + Inhalt + Sort
            End Get
        End Property
        Shared ReadOnly Property Summe_Episode_MediaInfo() As Integer
            Get
                Return Episode_VideoAuflösung + Episode_VideoSeitenverhältnis + Episode_VideoBildwiederholungsrate + Episode_VideoCodec + Episode_AudioKanäle + Episode_AudioCodec + Episode_AudioSprachen + Episode_Spieldauer
            End Get
        End Property
        Shared ReadOnly Property Summe_MediaInfo() As Integer
            Get
                Return VideoAuflösung + VideoSeitenverhältnis + VideoBildwiederholungsrate + VideoCodec + AudioKanäle + AudioCodec + AudioSprachen + Spieldauer
            End Get
        End Property
        Public Shared Sub getFortschritt(ByVal m As Season)
            Dim i As Integer = 0
            Dim cC As Integer = 0 'Cover
            Dim cO As Integer = 0 'Cover
            Dim cM As Integer = 0 'MediaInfo
            Dim cI As Integer = 0 'Info
            For Each s In m.Episodes
                i += s.Fortschritt
                cC += s.Rate_Cover
                cO += s.Rate_Filename
                cI += s.Rate_Info
                cM += s.Rate_MediaInfo
            Next
            m.Fortschritt = CInt(i / (100 * m.Episodes.Count) * 100)
            m.Rate_Cover = CInt(cC / (m.Episodes.Count))
            m.Rate_Filename = CInt(cO / (m.Episodes.Count))
            m.Rate_Info = CInt(cI / (m.Episodes.Count))
            m.Rate_MediaInfo = CInt(cM / (m.Episodes.Count))
        End Sub
        Public Shared Sub getFortschritt(ByVal m As Episode)
            Dim cC As Integer = 0 'Cover
            Dim cO As Integer = 0 'Cover
            Dim cM As Integer = 0 'MediaInfo
            Dim cI As Integer = 0 'Info
            Dim max As Integer = Summeofall_Episoden()
            m.State_Info_tip = New List(Of String)
            m.State_MediaInfo_tip = New List(Of String)
            If Not m.Titel.Trim = "" Then
                cI += Episode_Titel
            Else
                m.State_Info_tip.Add("Titel")
            End If
            If Not m.Darsteller.Trim = "" Then
                cI += Episode_Darsteller
            Else
                m.State_Info_tip.Add("Darsteller")
            End If
            If Not m.Regisseur.Trim = "" Then
                cI += Episode_Regisseur
            Else
                m.State_Info_tip.Add("Regisseur")
            End If
            If Not m.Autoren.Trim = "" Then
                cI += Episode_Autoren
            Else
                m.State_Info_tip.Add("Autoren")
            End If
            If Not m.Jahr.Trim = "" Then
                cI += Episode_Jahr
            Else
                m.State_Info_tip.Add("Produktionsjahr")
            End If
            If Not m.Bewertung.Trim = "" Then
                cI += Episode_Bewertung
            Else
                m.State_Info_tip.Add("Bewertung")
            End If
            If Not m.Inhalt.Trim = "" Then
                cI += Episode_Inhalt
            Else
                m.State_Info_tip.Add("Inhalt")
            End If
            If cI = Summe_Episode_Info Then
                m.Rate_Info = 2
                m.State_Info_text = "Info: OK"
            Else
                m.State_Info_text = "Folgende Felder sind leer: "
                If cI >= CInt(Summe_Episode_Info / 2) Then
                    m.Rate_Info = 1
                Else
                    m.Rate_Info = 0
                End If
            End If
            m.State_Info_text = CInt((((Summe_Episode_Info - cI) / max) * 100)) & "% - " & m.State_Info_text
            If Not m.bild = "" Then
                m.Rate_Cover = 2
            Else
                m.Rate_Cover = 0
            End If






            If Not m.Spieldauer.Trim = "" Then
                cM += Spieldauer
            Else
                m.State_MediaInfo_tip.Add("Spieldauer")
            End If
            If Not m.VideoAuflösung.Trim = "" Then
                cM += Episode_VideoAuflösung
            Else
                m.State_MediaInfo_tip.Add("VideoAuflösung")
            End If
            If Not m.VideoSeitenverhältnis.Trim = "" Then
                cM += Episode_VideoSeitenverhältnis
            Else
                m.State_MediaInfo_tip.Add("VideoSeitenverhältnis")
            End If
            If Not m.VideoBildwiederholungsrate.Trim = "" Then
                cM += Episode_VideoBildwiederholungsrate
            Else
                m.State_MediaInfo_tip.Add("VideoBildwiederholungsrate")
            End If
            If Not m.VideoCodec.Trim = "" Then
                cM += Episode_VideoCodec
            Else
                m.State_MediaInfo_tip.Add("VideoCodec")
            End If
            If Not m.AudioKanäle.Trim = "" Then
                cM += Episode_AudioKanäle
            Else
                m.State_MediaInfo_tip.Add("AudioKanäle")
            End If
            If Not m.AudioCodec.Trim = "" Then
                cM += Episode_AudioCodec
            Else
                m.State_MediaInfo_tip.Add("AudioCodec")
            End If
            If Not m.AudioSprachen.Trim = "" Then
                cM += Episode_AudioSprachen
            Else
                m.State_MediaInfo_tip.Add("AudioSprachen")
            End If



            If cM = Summe_Episode_MediaInfo Then
                m.Rate_MediaInfo = 2
                m.State_MediaInfo_text = "MediaInfo: OK"
            Else
                m.State_MediaInfo_text = "Folgende Felder sind leer: "
                If cM >= CInt(Summe_MediaInfo / 2) Then
                    m.Rate_MediaInfo = 1
                Else
                    m.Rate_MediaInfo = 0
                End If
            End If
            m.State_MediaInfo_text = CInt((((Summe_Episode_MediaInfo - cM) / max) * 100)) & "% - " & m.State_MediaInfo_text


            Dim i As Integer = CInt(cI + cM + cC + cO)


            If Not max = 0 Then
                m.Fortschritt = CInt(i / max * 100)
            Else
                m.Fortschritt = 0
            End If

        End Sub
        Public Shared Sub getFortschritt(ByVal m As Movie)
            Dim cC As Integer = 0 'Cover
            Dim cB As Integer = 0 'Backdrop
            Dim cI As Integer = 0 'Info
            Dim cM As Integer = 0 'MediaInfo
            Dim cO As Integer = 0 'Ordner
            Dim max As Integer = Summeofall()

            m.State_Cover_text = ""
            m.State_Backdrop_text = ""
            m.State_Info_text = ""
            m.State_MediaInfo_text = ""
            m.State_Ordner_text = ""

            m.State_Cover_tip.Clear()
            m.State_Backdrop_tip.Clear()
            m.State_Info_tip.Clear()
            m.State_MediaInfo_tip.Clear()
            m.State_Ordner_tip.Clear()
            '//State Cover

            If Not m.Cover = "" Then
                cC += Cover
                m.State_Cover = 1
                m.State_Cover_tip.Add("Schlechte Qualität des Covers")
                If m.Coversize > Einstellungen.Config_Fortschritt.Fortschritt_Cover_Quali * 1000 Or Cover_better = 0 Then
                    cC += Cover_better
                    m.State_Cover = 2
                    m.State_Cover_tip.Add("Cover: OK")
                End If
            Else
                m.State_Cover = 0
                m.State_Cover_tip.Add("Kein Cover vorhanden")
            End If

            m.State_Cover_text = CInt((((Summe_Cover - cC) / max) * 100)) & "% - Cover"

            '//State Backdrop


            If Not IsNothing(m.Backdrops) Then
                If m.Backdrops.Length > 0 Then
                    cB += Backdrops
                    m.State_Backdrop = 1
                    m.State_Backdrop_tip.Add("Es wurde nur ein Backdrop gefunden")
                    If m.Backdrops.Length > 1 Or Backdrops_more = 0 Then
                        cB += Backdrops_more
                        m.State_Backdrop = 2
                        m.State_Backdrop_tip.Add("Backdrop: OK")

                    End If
                Else
                    m.State_Backdrop = 0
                    m.State_Backdrop_tip.Add("Keine Backdrops")
                End If
            Else
                m.State_Backdrop = 0
                m.State_Backdrop_tip.Add("Keine Backdrops")
            End If
            m.State_Backdrop_text = CInt((((Summe_Backdrop - cB) / max) * 100)) & "% - Backdrops"


            '// State Ordner
            m.State_Ordner = 0
            If m.Ordner = Renamer.Formatof(m, True) Then
                m.State_Ordner += 1
                cO += Ordnername
            Else
                m.State_Ordner_tip.Add("Ordnername")
            End If
            If m.Files.Length > 0 Then
                Dim f As String = Renamer.Formatof(m, False)
                If IO.Directory.Exists(IO.Path.Combine(m.Pfad, "Video_ts")) Or IO.Directory.Exists(IO.Path.Combine(m.Pfad, "BDVM")) Or IO.Directory.Exists(IO.Path.Combine(m.Pfad, "STREAM")) Then
                    m.State_Ordner += 1
                    cO += Dateiname
                Else
                    If Not f = "" Then
                        If IO.Path.GetFileNameWithoutExtension(m.Files(0)).StartsWith(f) Then
                            m.State_Ordner += 1
                            cO += Dateiname
                        Else
                            m.State_Ordner_tip.Add("Dateiname")
                        End If
                    End If
                End If
            End If

            m.State_Ordner_text = CInt((((Summe_Ordner - cO) / max) * 100)) & "% - Falsche Beschriftung:"

            '//State Info

            If Not m.Titel.Trim = "" Then
                cI += Titel
            Else
                m.State_Info_tip.Add("Titel")
            End If
            If Not m.Originaltitel.Trim = "" Then
                cI += Originaltitel
            Else
                m.State_Info_tip.Add("Originaltitel")
            End If
            If Not m.IMDB_ID.Trim = "" Then
                cI += IMDB_ID
            Else
                m.State_Info_tip.Add("IMDB_ID")
            End If
            If Not m.Darsteller.Trim = "" Then
                cI += Darsteller
            Else
                Dim s() As String = Fortschritt_Genre.Split(CChar(","))
                If s.Length > 0 Then
                    Dim bol As Boolean = False
                    For x As Integer = 0 To s.Length - 1
                        If m.Genre.Contains(s(x).Trim) Then
                            cI += Darsteller
                            bol = True
                            Exit For
                        Else

                        End If
                    Next
                    If bol = False Then
                        m.State_Info_tip.Add("Darsteller")
                    End If

                End If

            End If
            If Not m.Regisseur.Trim = "" Then
                cI += Regisseur
            Else
                m.State_Info_tip.Add("Regisseur")
            End If
            If Not m.Autoren.Trim = "" Then
                cI += Autoren
            Else
                m.State_Info_tip.Add("Autoren")
            End If
            If Not m.Studios.Trim = "" Then
                cI += Studios
            Else
                m.State_Info_tip.Add("Studios")
            End If
            If Not m.Produktionsjahr.Trim = "" Then
                cI += Produktionsjahr
            Else
                m.State_Info_tip.Add("Produktionsjahr")
            End If
            If Not m.Produktionsland.Trim = "" Then
                cI += Produktionsland
            Else
                m.State_Info_tip.Add("Produktionsland")
            End If
            If Not m.Genre.Trim = "" Then
                cI += Genre
            Else
                m.State_Info_tip.Add("Genre")
            End If
            If Not m.FSK.Trim = "" Then
                cI += FSK
            Else
                m.State_Info_tip.Add("FSK")
            End If
            If Not m.Bewertung.Trim = "" Then
                cI += Bewertung
            Else
                m.State_Info_tip.Add("Bewertung")
            End If

            If Not m.Inhalt.Trim = "" Then
                cI += Inhalt
            Else
                m.State_Info_tip.Add("Inhalt")
            End If
            If Not m.Sort.Trim = "" Then
                cI += Sort
            Else
                m.State_Info_tip.Add("Sort")
            End If

            If cI = Summe_Info Then
                m.State_Info = 2
                m.State_Info_text = "Info: OK"
            Else
                m.State_Info_text = "Folgende Felder sind leer: "
                If cI >= CInt(Summe_Info / 2) Then
                    m.State_Info = 1
                Else
                    m.State_Info = 0
                End If
            End If
            m.State_Info_text = CInt((((Summe_Info - cI) / max) * 100)) & "% - " & m.State_Info_text


            '//State MediaInfo

            'tip = ""
            If Not m.Spieldauer.Trim = "" Then
                cM += Spieldauer
            Else
                m.State_MediaInfo_tip.Add("Spieldauer")
            End If
            If Not m.VideoAuflösung.Trim = "" Then
                cM += VideoAuflösung
            Else
                m.State_MediaInfo_tip.Add("VideoAuflösung")
            End If
            If Not m.VideoSeitenverhältnis.Trim = "" Then
                cM += VideoSeitenverhältnis
            Else
                m.State_MediaInfo_tip.Add("VideoSeitenverhältnis")
            End If
            If Not m.VideoBildwiederholungsrate.Trim = "" Then
                cM += VideoBildwiederholungsrate
            Else
                m.State_MediaInfo_tip.Add("VideoBildwiederholungsrate")
            End If
            If Not m.VideoCodec.Trim = "" Then
                cM += VideoCodec
            Else
                m.State_MediaInfo_tip.Add("VideoCodec")
            End If
            If Not m.AudioKanäle.Trim = "" Then
                cM += AudioKanäle
            Else
                m.State_MediaInfo_tip.Add("AudioKanäle")
            End If
            If Not m.AudioCodec.Trim = "" Then
                cM += AudioCodec
            Else
                m.State_MediaInfo_tip.Add("AudioCodec")
            End If
            If Not m.AudioSprachen.Trim = "" Then
                cM += AudioSprachen
            Else
                m.State_MediaInfo_tip.Add("AudioSprachen")
            End If



            If cM = Summe_MediaInfo Then
                m.State_MediaInfo = 2
                m.State_MediaInfo_text = "MediaInfo: OK"
            Else
                m.State_MediaInfo_text = "Folgende Felder sind leer: "
                If cM >= CInt(Summe_MediaInfo / 2) Then
                    m.State_MediaInfo = 1
                Else
                    m.State_MediaInfo = 0
                End If
            End If
            m.State_MediaInfo_text = CInt((((Summe_MediaInfo - cM) / max) * 100)) & "% - " & m.State_MediaInfo_text





            Dim i As Integer = CInt(cI + cM + cB + cC + cO + Trailer)


            If Not max = 0 Then
                m.Fortschritt = CInt(i / max * 100)
            Else
                m.Fortschritt = 0
            End If


        End Sub
        Public Shared Function getFortschritt_Backdrops(ByVal i As Integer) As Integer
            Dim i2 As Integer = Einstellungen.Config_Fortschritt.Backdrops_more
            If i = 0 Then
                i2 += Einstellungen.Config_Fortschritt.Backdrops
            End If
            Return CInt(i2 / Einstellungen.Config_Fortschritt.Summeofall * 100)
        End Function
        Public Shared Function getFortschritt_Cover(ByVal i As Integer) As Integer
            Dim i2 As Integer = Einstellungen.Config_Fortschritt.Cover_better
            If i = 0 Then
                i2 += Einstellungen.Config_Fortschritt.Cover
            End If

            Return CInt(i / Einstellungen.Config_Fortschritt.Summeofall * 100)
        End Function
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s

                '.Formatting = Xml.Formatting.Indented
                '.Indentation = 4

                '.WriteStartDocument()
                .WriteStartElement("Fortschritt")


                .WriteStartElement("Fortschritt_cover")
                .WriteValue(Fortschritt_cover)
                .WriteEndElement()

                .WriteStartElement("Fortschritt_Cover_Quali")
                .WriteValue(Fortschritt_Cover_Quali)
                .WriteEndElement()

                .WriteStartElement("Fortschritt_Genre")
                .WriteValue(Fortschritt_Genre)
                .WriteEndElement()

                .WriteStartElement("Fortschritt_Modus")
                .WriteValue(Fortschritt_Modus)
                .WriteEndElement()


                .WriteStartElement("Cover")
                .WriteValue(Cover)
                .WriteEndElement()

                .WriteStartElement("Cover_better")
                .WriteValue(Cover_better)
                .WriteEndElement()

                .WriteStartElement("Backdrops")
                .WriteValue(Backdrops)
                .WriteEndElement()

                .WriteStartElement("Backdrops_more")
                .WriteValue(Backdrops_more)
                .WriteEndElement()

                .WriteStartElement("Ordnername")
                .WriteValue(Ordnername)
                .WriteEndElement()

                .WriteStartElement("Dateiname")
                .WriteValue(Dateiname)
                .WriteEndElement()


                .WriteStartElement("Trailer")
                .WriteValue(Dateiname)
                .WriteEndElement()

                .WriteStartElement("Titel")
                .WriteValue(Titel)
                .WriteEndElement()

                .WriteStartElement("Originaltitel")
                .WriteValue(Originaltitel)
                .WriteEndElement()

                .WriteStartElement("IMDB_ID")
                .WriteValue(IMDB_ID)
                .WriteEndElement()

                .WriteStartElement("Darsteller")
                .WriteValue(Darsteller)
                .WriteEndElement()

                .WriteStartElement("Regisseur")
                .WriteValue(Regisseur)
                .WriteEndElement()

                .WriteStartElement("Autoren")
                .WriteValue(Autoren)
                .WriteEndElement()

                .WriteStartElement("Studios")
                .WriteValue(Studios)
                .WriteEndElement()

                .WriteStartElement("Produktionsjahr")
                .WriteValue(Produktionsjahr)
                .WriteEndElement()

                .WriteStartElement("Produktionsland")
                .WriteValue(Produktionsland)
                .WriteEndElement()

                .WriteStartElement("Genre")
                .WriteValue(Genre)
                .WriteEndElement()

                .WriteStartElement("FSK")
                .WriteValue(FSK)
                .WriteEndElement()

                .WriteStartElement("Bewertung")
                .WriteValue(Bewertung)
                .WriteEndElement()

                .WriteStartElement("Spieldauer")
                .WriteValue(Spieldauer)
                .WriteEndElement()

                '.WriteStartElement("Kurzbeschreibung")
                '.WriteValue(Kurzbeschreibung)
                '.WriteEndElement()

                .WriteStartElement("Inhalt")
                .WriteValue(Inhalt)
                .WriteEndElement()

                .WriteStartElement("Sort")
                .WriteValue(Sort)
                .WriteEndElement()

                '.WriteStartElement("MediaInfo")
                '.WriteValue(MediaInfo)
                '.WriteEndElement()

                '.WriteStartElement("Position")
                '.WriteValue(Position)
                '.WriteEndElement()

                '.WriteStartElement("Datum")
                '.WriteValue(Datum)
                '.WriteEndElement()

                .WriteStartElement("VideoAuflösung")
                .WriteValue(VideoAuflösung)
                .WriteEndElement()

                .WriteStartElement("VideoSeitenverhältnis")
                .WriteValue(VideoSeitenverhältnis)
                .WriteEndElement()

                .WriteStartElement("VideoBildwiederholungsrate")
                .WriteValue(VideoBildwiederholungsrate)
                .WriteEndElement()

                .WriteStartElement("VideoCodec")
                .WriteValue(VideoCodec)
                .WriteEndElement()

                .WriteStartElement("AudioKanäle")
                .WriteValue(AudioKanäle)
                .WriteEndElement()

                .WriteStartElement("AudioCodec")
                .WriteValue(AudioCodec)
                .WriteEndElement()

                .WriteStartElement("AudioSprachen")
                .WriteValue(AudioSprachen)
                .WriteEndElement()



                .WriteEndElement()
                '.Close()
            End With
        End Sub
        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Fortschritt").Count > 0 Then
                xml = xmln.SelectNodes("//Fortschritt").Item(0)
                Fortschritt_Cover_Quali = If(xml.SelectNodes("//Fortschritt_Cover_Quali").Count > 0, toInt(xml.SelectSingleNode("//Fortschritt_Cover_Quali").InnerText, 50), 50)

                Fortschritt_cover = If(xml.SelectNodes("//Fortschritt_cover").Count > 0, toBool(xml.SelectSingleNode("//Fortschritt_cover").InnerText, True), True)
                Fortschritt_Modus = If(xml.SelectNodes("//Fortschritt_Modus").Count > 0, toInt(xml.SelectSingleNode("//Fortschritt_Modus").InnerText, 1), 1)
                Fortschritt_Genre = If(xml.SelectNodes("//Fortschritt_Genre").Count > 0, xml.SelectSingleNode("//Fortschritt_Genre").InnerText, "Animation, Zeichentrick, Dokumentation, Dokumentarfilm, Documentation, Musik, Music")
                Cover = If(xml.SelectNodes("//Cover").Count > 0, toInt(xml.SelectSingleNode("//Cover").InnerText, 1), 1)
                Cover_better = If(xml.SelectNodes("//Cover_better").Count > 0, toInt(xml.SelectSingleNode("//Cover_better").InnerText, 1), 1)
                Backdrops = If(xml.SelectNodes("//Backdrops").Count > 0, toInt(xml.SelectSingleNode("//Backdrops").InnerText, 1), 1)
                Backdrops_more = If(xml.SelectNodes("//Backdrops_more").Count > 0, toInt(xml.SelectSingleNode("//Backdrops_more").InnerText, 1), 1)
                Ordnername = If(xml.SelectNodes("//Ordnername").Count > 0, toInt(xml.SelectSingleNode("//Ordnername").InnerText, 1), 1)
                Dateiname = If(xml.SelectNodes("//Dateiname").Count > 0, toInt(xml.SelectSingleNode("//Dateiname").InnerText, 1), 1)
                Trailer = If(xml.SelectNodes("//Trailer").Count > 0, toInt(xml.SelectSingleNode("//Trailer").InnerText, 0), 0)
                Titel = If(xml.SelectNodes("//Titel").Count > 0, toInt(xml.SelectSingleNode("//Titel").InnerText, 1), 1)
                Originaltitel = If(xml.SelectNodes("//Originaltitel").Count > 0, toInt(xml.SelectSingleNode("//Originaltitel").InnerText, 1), 1)
                IMDB_ID = If(xml.SelectNodes("//IMDB_ID").Count > 0, toInt(xml.SelectSingleNode("//IMDB_ID").InnerText, 1), 1)
                Darsteller = If(xml.SelectNodes("//Darsteller").Count > 0, toInt(xml.SelectSingleNode("//Darsteller").InnerText, 1), 1)
                Regisseur = If(xml.SelectNodes("//Regisseur").Count > 0, toInt(xml.SelectSingleNode("//Regisseur").InnerText, 1), 1)
                Autoren = If(xml.SelectNodes("//Autoren").Count > 0, toInt(xml.SelectSingleNode("//Autoren").InnerText, 1), 1)
                Studios = If(xml.SelectNodes("//Studios").Count > 0, toInt(xml.SelectSingleNode("//Studios").InnerText, 1), 1)
                Produktionsjahr = If(xml.SelectNodes("//Produktionsjahr").Count > 0, toInt(xml.SelectSingleNode("//Produktionsjahr").InnerText, 1), 1)
                Produktionsland = If(xml.SelectNodes("//Produktionsland").Count > 0, toInt(xml.SelectSingleNode("//Produktionsland").InnerText, 1), 1)
                Genre = If(xml.SelectNodes("//Genre").Count > 0, toInt(xml.SelectSingleNode("//Genre").InnerText, 1), 1)
                FSK = If(xml.SelectNodes("//FSK").Count > 0, toInt(xml.SelectSingleNode("//FSK").InnerText, 1), 1)
                Bewertung = If(xml.SelectNodes("//Bewertung").Count > 0, toInt(xml.SelectSingleNode("//Bewertung").InnerText, 1), 1)
                Spieldauer = If(xml.SelectNodes("//Spieldauer").Count > 0, toInt(xml.SelectSingleNode("//Spieldauer").InnerText, 1), 1)
                'Kurzbeschreibung = If(xml.SelectNodes("//Kurzbeschreibung").Count > 0, toInt(xml.SelectSingleNode("//Kurzbeschreibung").InnerText, 1), 1)
                Inhalt = If(xml.SelectNodes("//Inhalt").Count > 0, toInt(xml.SelectSingleNode("//Inhalt").InnerText, 1), 1)
                Sort = If(xml.SelectNodes("//Sort").Count > 0, toInt(xml.SelectSingleNode("//Sort").InnerText, 1), 1)
                'MediaInfo = If(xml.SelectNodes("//MediaInfo").Count > 0, toInt(xml.SelectSingleNode("//MediaInfo").InnerText, 1), 1)
                'Position = If(xml.SelectNodes("//Position").Count > 0, toInt(xml.SelectSingleNode("//Position").InnerText, 1), 1)
                'Datum = If(xml.SelectNodes("//Datum").Count > 0, toInt(xml.SelectSingleNode("//Datum").InnerText, 1), 1)
                VideoAuflösung = If(xml.SelectNodes("//VideoAuflösung").Count > 0, toInt(xml.SelectSingleNode("//VideoAuflösung").InnerText, 1), 1)
                VideoSeitenverhältnis = If(xml.SelectNodes("//VideoSeitenverhältnis").Count > 0, toInt(xml.SelectSingleNode("//VideoSeitenverhältnis").InnerText, 1), 1)
                VideoBildwiederholungsrate = If(xml.SelectNodes("//VideoBildwiederholungsrate").Count > 0, toInt(xml.SelectSingleNode("//VideoBildwiederholungsrate").InnerText, 1), 1)
                VideoCodec = If(xml.SelectNodes("//VideoCodec").Count > 0, toInt(xml.SelectSingleNode("//VideoCodec").InnerText, 1), 1)
                AudioKanäle = If(xml.SelectNodes("//AudioKanäle").Count > 0, toInt(xml.SelectSingleNode("//AudioKanäle").InnerText, 1), 1)
                AudioCodec = If(xml.SelectNodes("//AudioCodec").Count > 0, toInt(xml.SelectSingleNode("//AudioCodec").InnerText, 1), 1)
                AudioSprachen = If(xml.SelectNodes("//AudioSprachen").Count > 0, toInt(xml.SelectSingleNode("//AudioSprachen").InnerText, 1), 1)



                'If IO.File.Exists(Application.StartupPath & "\User\Rate.xml") Then

                '    Dim xml As XmlDocument ' Unser Document Container

                '    xml = New XmlDocument

                '    xml.Load(Application.StartupPath & "\User\Rate.xml")
                '    Dim XMLReader As Xml.XmlReader _
                '    = New Xml.XmlNodeReader(xml)


            End If
        End Sub
        Public Shared Sub LoadtoDialog()
            With Bewertungsmuster

                .Num_Titel.Value = Config_Fortschritt.Titel
                .Num_Originaltitel.Value = Config_Fortschritt.Originaltitel
                .Num_IMDB_ID.Value = Config_Fortschritt.IMDB_ID
                .Num_Darsteller.Value = Config_Fortschritt.Darsteller
                .Num_Regisseur.Value = Config_Fortschritt.Regisseur
                .Num_Autoren.Value = Config_Fortschritt.Autoren
                .Num_Studio.Value = Config_Fortschritt.Studios
                .Num_Produktionsjahr.Value = Config_Fortschritt.Produktionsjahr
                .Num_Produktionsland.Value = Config_Fortschritt.Produktionsland
                .Num_Genre.Value = Config_Fortschritt.Genre
                .Num_FSK.Value = Config_Fortschritt.FSK
                .Num_Bewertung.Value = Config_Fortschritt.Bewertung
                .Num_Spieldauer.Value = Config_Fortschritt.Spieldauer
                '.Num_Kurzbeschreibung.Value = Config_Fortschritt.Kurzbeschreibung
                .Num_Inhalt.Value = Config_Fortschritt.Inhalt
                .Num_Sort.Value = Config_Fortschritt.Sort
                .Num_VideoAuflösung.Value = Config_Fortschritt.VideoAuflösung
                .Num_VideoSeitenverhältnis.Value = Config_Fortschritt.VideoSeitenverhältnis
                .Num_VideoBildwiederholungsrate.Value = Config_Fortschritt.VideoBildwiederholungsrate
                .Num_VideoCodec.Value = Config_Fortschritt.VideoCodec
                .Num_AudioKanäle.Value = Config_Fortschritt.AudioKanäle
                .Num_AudioCodec.Value = Config_Fortschritt.AudioCodec
                .Num_AudioSprachen.Value = Config_Fortschritt.AudioSprachen
                .Num_Cover.Value = Config_Fortschritt.Cover
                .Num_Cover_better.Value = Config_Fortschritt.Cover_better
                .Num_Backdrops.Value = Config_Fortschritt.Backdrops
                .Num_Backdrops_more.Value = Config_Fortschritt.Backdrops_more
                .Num_Trailer.Value = Config_Fortschritt.Trailer
                .Num_FileName.Value = Config_Fortschritt.Dateiname
                .Num_Foldername.Value = Config_Fortschritt.Ordnername
            End With
        End Sub
        Public Shared Sub SavefromDialog()
            With Bewertungsmuster
                Config_Fortschritt.Cover = CInt(.Num_Cover.Value)
                Config_Fortschritt.Backdrops_more = CInt(.Num_Backdrops_more.Value)
                Config_Fortschritt.Cover_better = CInt(.Num_Cover_better.Value)
                Config_Fortschritt.Backdrops = CInt(.Num_Backdrops.Value)

                Config_Fortschritt.Titel = CInt(.Num_Titel.Value)
                Config_Fortschritt.Originaltitel = CInt(.Num_Originaltitel.Value)
                Config_Fortschritt.IMDB_ID = CInt(.Num_IMDB_ID.Value)
                Config_Fortschritt.Darsteller = CInt(.Num_Darsteller.Value)
                Config_Fortschritt.Regisseur = CInt(.Num_Regisseur.Value)
                Config_Fortschritt.Autoren = CInt(.Num_Autoren.Value)
                Config_Fortschritt.Studios = CInt(.Num_Studio.Value)
                Config_Fortschritt.Produktionsjahr = CInt(.Num_Produktionsjahr.Value)
                Config_Fortschritt.Produktionsland = CInt(.Num_Produktionsland.Value)
                Config_Fortschritt.Genre = CInt(.Num_Genre.Value)
                Config_Fortschritt.FSK = CInt(.Num_FSK.Value)
                Config_Fortschritt.Bewertung = CInt(.Num_Bewertung.Value)
                Config_Fortschritt.Spieldauer = CInt(.Num_Spieldauer.Value)
                'Config_Fortschritt.Kurzbeschreibung = CInt(.Num_Kurzbeschreibung.Value)
                Config_Fortschritt.Inhalt = CInt(.Num_Inhalt.Value)
                Config_Fortschritt.Sort = CInt(.Num_Sort.Value)
                Config_Fortschritt.VideoAuflösung = CInt(.Num_VideoAuflösung.Value)
                Config_Fortschritt.VideoSeitenverhältnis = CInt(.Num_VideoSeitenverhältnis.Value)
                Config_Fortschritt.VideoBildwiederholungsrate = CInt(.Num_VideoBildwiederholungsrate.Value)
                Config_Fortschritt.VideoCodec = CInt(.Num_VideoCodec.Value)
                Config_Fortschritt.AudioKanäle = CInt(.Num_AudioKanäle.Value)
                Config_Fortschritt.AudioCodec = CInt(.Num_AudioCodec.Value)
                Config_Fortschritt.AudioSprachen = CInt(.Num_AudioSprachen.Value)
                Config_Fortschritt.Trailer = CInt(.Num_Trailer.Value)
                Config_Fortschritt.Dateiname = CInt(.Num_FileName.Value)
                Config_Fortschritt.Ordnername = CInt(.Num_Foldername.Value)

            End With
        End Sub

        Public Shared Sub Load()
            With Settings
                .Fortschritt_Genre.Text = Fortschritt_Genre
                .Fortschritt_Cover.Checked = Fortschritt_cover
                .Fortschritt_Cover_Quali.Value = Fortschritt_Cover_Quali
                .Fortschritt_modus_Eigene.Checked = False
                .Fortschritt_modus_Normal.Checked = False
                .Fortschritt_modus_Plugin.Checked = False
                If Fortschritt_Modus = 0 Then
                    .Fortschritt_modus_Normal.Checked = True
                ElseIf Fortschritt_Modus = 1 Then
                    .Fortschritt_modus_Plugin.Checked = True
                ElseIf Fortschritt_Modus = 2 Then
                    .Fortschritt_modus_Eigene.Checked = True
                Else
                    Fortschritt_Modus = 0
                    .Fortschritt_modus_Normal.Checked = True
                End If
                If Ordnername + Dateiname > 0 Then
                    .Fortschritt_Ordner.Checked = True
                Else
                    .Fortschritt_Ordner.Checked = False
                End If
            End With

        End Sub
        Public Shared Sub Save()
            With Settings
                Fortschritt_Genre = .Fortschritt_Genre.Text
                Fortschritt_cover = .Fortschritt_Cover.Checked
                Fortschritt_Cover_Quali = CInt(.Fortschritt_Cover_Quali.Value)
                If .Fortschritt_modus_Normal.Checked = True Then
                    Fortschritt_Modus = 0
                    SetRating_Normal()
                    If .Fortschritt_Ordner.Checked = True Then
                        If Ordnername = 0 Then
                            Ordnername = 1
                        End If
                        If Dateiname = 0 Then
                            Dateiname = 1
                        End If
                    Else
                        Ordnername = 0
                        Dateiname = 0
                    End If
                ElseIf .Fortschritt_modus_Plugin.Checked = True Then
                    Fortschritt_Modus = 1
                    SetRating_Plugin()
                    If .Fortschritt_Ordner.Checked = True Then
                        If Ordnername = 0 Then
                            Ordnername = 1
                        End If
                        If Dateiname = 0 Then
                            Dateiname = 1
                        End If
                    Else
                        Ordnername = 0
                        Dateiname = 0
                    End If
                ElseIf .Fortschritt_modus_Eigene.Checked = True Then
                    Fortschritt_Modus = 2
                End If



            End With
        End Sub
        Public Shared Sub SetRating_Plugin()
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                Config_Fortschritt.Titel = 1
                Config_Fortschritt.Originaltitel = 1
                Config_Fortschritt.IMDB_ID = 1
                Config_Fortschritt.Darsteller = 1
                Config_Fortschritt.Regisseur = 1
                Config_Fortschritt.Autoren = 1
                Config_Fortschritt.Studios = 1
                Config_Fortschritt.Produktionsjahr = 1
                Config_Fortschritt.Produktionsland = 1
                Config_Fortschritt.Genre = 1
                Config_Fortschritt.FSK = 1
                Config_Fortschritt.Bewertung = 1
                Config_Fortschritt.Spieldauer = 1
                Config_Fortschritt.Inhalt = 1
                Config_Fortschritt.Sort = 1
                Config_Fortschritt.VideoAuflösung = 1
                Config_Fortschritt.VideoSeitenverhältnis = 1
                Config_Fortschritt.VideoBildwiederholungsrate = 1
                Config_Fortschritt.VideoCodec = 1
                Config_Fortschritt.AudioKanäle = 1
                Config_Fortschritt.AudioCodec = 1
                Config_Fortschritt.AudioSprachen = 1
                Config_Fortschritt.Cover = 1
                Config_Fortschritt.Cover_better = 1
                Config_Fortschritt.Backdrops = 1
                Config_Fortschritt.Backdrops_more = 1

                Config_Fortschritt.Trailer = 0


            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
                Config_Fortschritt.Titel = 1
                Config_Fortschritt.Originaltitel = 1
                Config_Fortschritt.IMDB_ID = 1
                Config_Fortschritt.Darsteller = 1
                Config_Fortschritt.Regisseur = 1
                Config_Fortschritt.Autoren = 0
                Config_Fortschritt.Studios = 1
                Config_Fortschritt.Produktionsjahr = 1
                Config_Fortschritt.Produktionsland = 0
                Config_Fortschritt.Genre = 1
                Config_Fortschritt.FSK = 1
                Config_Fortschritt.Bewertung = 1
                Config_Fortschritt.Spieldauer = 1
                Config_Fortschritt.Inhalt = 1
                Config_Fortschritt.Sort = 1
                Config_Fortschritt.VideoAuflösung = 1
                Config_Fortschritt.VideoSeitenverhältnis = 1
                Config_Fortschritt.VideoBildwiederholungsrate = 1
                Config_Fortschritt.VideoCodec = 0
                Config_Fortschritt.AudioKanäle = 0
                Config_Fortschritt.AudioCodec = 0
                Config_Fortschritt.AudioSprachen = 0
                Config_Fortschritt.Cover = 1
                Config_Fortschritt.Cover_better = 1
                Config_Fortschritt.Backdrops = 1
                Config_Fortschritt.Backdrops_more = 1
                Config_Fortschritt.Trailer = 0
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                Config_Fortschritt.Titel = 1
                Config_Fortschritt.Originaltitel = 1
                Config_Fortschritt.IMDB_ID = 1
                Config_Fortschritt.Darsteller = 1
                Config_Fortschritt.Regisseur = 1
                Config_Fortschritt.Autoren = 1
                Config_Fortschritt.Studios = 1
                Config_Fortschritt.Produktionsjahr = 1
                Config_Fortschritt.Produktionsland = 0
                Config_Fortschritt.Genre = 1
                Config_Fortschritt.FSK = 1
                Config_Fortschritt.Bewertung = 1
                Config_Fortschritt.Spieldauer = 1
                Config_Fortschritt.Inhalt = 1
                Config_Fortschritt.Sort = 1
                Config_Fortschritt.VideoAuflösung = 1
                Config_Fortschritt.VideoSeitenverhältnis = 1
                Config_Fortschritt.VideoBildwiederholungsrate = 1
                Config_Fortschritt.VideoCodec = 1
                Config_Fortschritt.AudioKanäle = 1
                Config_Fortschritt.AudioCodec = 1
                Config_Fortschritt.AudioSprachen = 1
                Config_Fortschritt.Cover = 1
                Config_Fortschritt.Cover_better = 1
                Config_Fortschritt.Backdrops = 1
                Config_Fortschritt.Backdrops_more = 1
                Config_Fortschritt.Trailer = 0
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.DVDInfo Then
                Config_Fortschritt.Titel = 1
                Config_Fortschritt.Originaltitel = 1
                Config_Fortschritt.IMDB_ID = 1
                Config_Fortschritt.Darsteller = 1
                Config_Fortschritt.Regisseur = 1
                Config_Fortschritt.Autoren = 0
                Config_Fortschritt.Studios = 0
                Config_Fortschritt.Produktionsjahr = 1
                Config_Fortschritt.Produktionsland = 0
                Config_Fortschritt.Genre = 1
                Config_Fortschritt.FSK = 1
                Config_Fortschritt.Bewertung = 0
                Config_Fortschritt.Spieldauer = 1
                Config_Fortschritt.Inhalt = 1
                Config_Fortschritt.Sort = 1
                Config_Fortschritt.VideoAuflösung = 0
                Config_Fortschritt.VideoSeitenverhältnis = 0
                Config_Fortschritt.VideoBildwiederholungsrate = 0
                Config_Fortschritt.VideoCodec = 0
                Config_Fortschritt.AudioKanäle = 0
                Config_Fortschritt.AudioCodec = 0
                Config_Fortschritt.AudioSprachen = 0
                Config_Fortschritt.Cover = 1
                Config_Fortschritt.Cover_better = 1
                Config_Fortschritt.Backdrops = 0
                Config_Fortschritt.Backdrops_more = 0
                Config_Fortschritt.Trailer = 0

            End If


        End Sub
        Public Shared Sub SetRating_Normal()
            Config_Fortschritt.Titel = 1
            Config_Fortschritt.Originaltitel = 1
            Config_Fortschritt.IMDB_ID = 1
            Config_Fortschritt.Darsteller = 1
            Config_Fortschritt.Regisseur = 1
            Config_Fortschritt.Autoren = 1
            Config_Fortschritt.Studios = 1
            Config_Fortschritt.Produktionsjahr = 1
            Config_Fortschritt.Produktionsland = 1
            Config_Fortschritt.Genre = 1
            Config_Fortschritt.FSK = 1
            Config_Fortschritt.Bewertung = 1
            Config_Fortschritt.Spieldauer = 1
            Config_Fortschritt.Inhalt = 1
            Config_Fortschritt.Sort = 1
            Config_Fortschritt.VideoAuflösung = 1
            Config_Fortschritt.VideoSeitenverhältnis = 1
            Config_Fortschritt.VideoBildwiederholungsrate = 1
            Config_Fortschritt.VideoCodec = 1
            Config_Fortschritt.AudioKanäle = 1
            Config_Fortschritt.AudioCodec = 1
            Config_Fortschritt.AudioSprachen = 1
            Config_Fortschritt.Cover = 1
            Config_Fortschritt.Cover_better = 1
            Config_Fortschritt.Backdrops = 1
            Config_Fortschritt.Backdrops_more = 1
        End Sub



    End Class
    Public Class Config_Laden
        Shared Property Laden_Ordner_Einstellungenimmerneu As Boolean = True
        Shared Property Laden_Ordner_MediaInfo As Boolean = False
        Shared Property Laden_Ordner_Suche As Boolean = False
        Shared Property Laden_Ordner_suchmodus As Integer = 1
        'immer = 0/nachfragen= 1/nie= 2
        ''' <summary>
        ''' 0 = Immer
        ''' 1 = Fragen
        ''' 2 = Nie
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Property Laden_Ordner_neuerOrdner As Boolean = False

        Shared Property Laden_Dateien_List As New List(Of String) From {"*.asx", "*.avi", "*.dvr-ms", "*.m2ts", "*.mkv", "*.mov", "*.mp4", "*.mpeg", "*.mpg", "*.wmv", "*.wpl", "*.wtv", "*.xvid", "*.ts", "*.iso", "video_ts"}


        Shared Property Laden_Dateien_CB_Minsize As Boolean = False
        Shared Property Laden_Dateien_Minsize_val As Integer = 200
        Shared Property Laden_Dateien_FilterFoldername As String = "Trailer"
        Shared Property Laden_Dateien_FilterDateiEndung As String = "-trailer|-sample"
        Shared Property Laden_Favs_Autostart As Boolean = True
        Shared Property Laden_Favs_MediaInfo As Boolean = False
        Shared Property Laden_Favs_Suche As Boolean = False
        Shared Property Laden_Favs_Suchmodus As Integer = 1
        Shared Sub Standard_Dateien()
            With Settings
                .Laden_Dateien_CB_Minsize.Checked = False
                .Laden_Dateien_FilterDateiEndung.Text = "-trailer|-sample"
                .Laden_Dateien_FilterFoldername.Text = "Trailer"
                .Laden_Dateien_List.Items.Clear()
                Dim List() As String = {"*.asx", "*.avi", "*.dvr-ms", "*.m2ts", "*.mkv", "*.mov", "*.mp4", "*.mpeg", "*.mpg", "*.wmv", "*.wpl", "*.wtv", "*.xvid", "*.ts", "*.iso", "video_ts"}

                If List.Length > 0 Then
                    For x As Integer = 0 To List.Length - 1
                        .Laden_Dateien_List.Items.Add(List(x))
                    Next
                End If
                .Laden_Dateien_Minsize_val.Value = 200


            End With
        End Sub
        Shared Sub Standard_Favs()
            With Settings


                .Laden_Favs_MediaInfo.Checked = False
                .Laden_Favs_Suche.Checked = False
                .Laden_Favs_Suchmodus.SelectedIndex = 1
                .Laden_favs_Autostart.Checked = True



            End With
        End Sub
        Shared Sub Standard_Ordner()
            With Settings

                .Laden_Ordner_MediaInfo.Checked = False
                .Laden_Ordner_Suche.Checked = False
                .Laden_Ordner_suchmodus.SelectedIndex = 1
                .Laden_Ordner_Einstellungenimmerneu.Checked = True
                .Laden_Ordner_NeuerOrdner.Checked = True



            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Laden_Dateien_CB_Minsize.Checked = Laden_Dateien_CB_Minsize
                .Laden_Dateien_FilterDateiEndung.Text = Laden_Dateien_FilterDateiEndung
                .Laden_Dateien_FilterFoldername.Text = Laden_Dateien_FilterFoldername
                .Laden_Dateien_List.Items.Clear()
                If Laden_Dateien_List.Count > 0 Then
                    For x As Integer = 0 To Laden_Dateien_List.Count - 1
                        .Laden_Dateien_List.Items.Add(Laden_Dateien_List(x))
                    Next
                End If
                .Laden_Dateien_Minsize_val.Value = Laden_Dateien_Minsize_val

                .Laden_Favs_MediaInfo.Checked = Laden_Favs_MediaInfo
                .Laden_Favs_Suche.Checked = Laden_Favs_Suche
                .Laden_Favs_Suchmodus.SelectedIndex = Laden_Favs_Suchmodus
                .Laden_favs_Autostart.Checked = Laden_Favs_Autostart

                .Laden_Ordner_MediaInfo.Checked = Laden_Ordner_MediaInfo
                .Laden_Ordner_Suche.Checked = Laden_Ordner_Suche
                .Laden_Ordner_suchmodus.SelectedIndex = Laden_Ordner_suchmodus
                .Laden_Ordner_Einstellungenimmerneu.Checked = Laden_Ordner_Einstellungenimmerneu
                .Laden_Ordner_NeuerOrdner.Checked = Laden_Ordner_neuerOrdner



            End With
        End Sub
        Shared Sub Save()
            With Settings
                Laden_Dateien_CB_Minsize = .Laden_Dateien_CB_Minsize.Checked
                Laden_Dateien_FilterDateiEndung = .Laden_Dateien_FilterDateiEndung.Text
                Laden_Dateien_FilterFoldername = .Laden_Dateien_FilterFoldername.Text
                Laden_Dateien_List.Clear()
                If .Laden_Dateien_List.Items.Count > 0 Then
                    For x As Integer = 0 To .Laden_Dateien_List.Items.Count - 1
                        Laden_Dateien_List.Add(CStr(.Laden_Dateien_List.Items(x)))
                    Next
                End If

                Laden_Dateien_Minsize_val = CInt(.Laden_Dateien_Minsize_val.Value)
                Laden_Favs_MediaInfo = .Laden_Favs_MediaInfo.Checked
                Laden_Favs_Suche = .Laden_Favs_Suche.Checked

                Laden_Favs_Autostart = .Laden_favs_Autostart.Checked
                Laden_Ordner_MediaInfo = .Laden_Ordner_MediaInfo.Checked
                Laden_Ordner_Suche = .Laden_Ordner_Suche.Checked
                If .Laden_Ordner_suchmodus.SelectedIndex = -1 Then
                    Laden_Ordner_suchmodus = 1
                Else
                    Laden_Ordner_suchmodus = .Laden_Ordner_suchmodus.SelectedIndex
                End If

                If .Laden_Favs_Suchmodus.SelectedIndex = -1 Then
                    Laden_Favs_Suchmodus = 1
                Else
                    Laden_Favs_Suchmodus = .Laden_Favs_Suchmodus.SelectedIndex
                End If

                Laden_Ordner_Einstellungenimmerneu = .Laden_Ordner_Einstellungenimmerneu.Checked
                Laden_Ordner_neuerOrdner = .Laden_Ordner_NeuerOrdner.Checked

            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Laden").Count > 0 Then
                xml = xmln.SelectNodes("//Laden").Item(0)


                Laden_Ordner_Einstellungenimmerneu = If(xml.SelectNodes("//Laden_Ordner_Einstellungenimmerneu").Count > 0, toBool(xml.SelectSingleNode("//Laden_Ordner_Einstellungenimmerneu").InnerText, True), True)
                Laden_Ordner_MediaInfo = If(xml.SelectNodes("//Laden_Ordner_MediaInfo").Count > 0, toBool(xml.SelectSingleNode("//Laden_Ordner_MediaInfo").InnerText, True), True)
                Laden_Ordner_Suche = If(xml.SelectNodes("//Laden_Ordner_Suche").Count > 0, toBool(xml.SelectSingleNode("//Laden_Ordner_Suche").InnerText, True), True)
                Laden_Ordner_suchmodus = If(xml.SelectNodes("//Laden_Ordner_suchmodus").Count > 0, toInt(xml.SelectSingleNode("//Laden_Ordner_suchmodus").InnerText, 1), 1)
                Laden_Ordner_neuerOrdner = If(xml.SelectNodes("//Laden_Ordner_neuerOrdner").Count > 0, toBool(xml.SelectSingleNode("//Laden_Ordner_neuerOrdner").InnerText, True), True)


                Dim xml2 As XmlNode = xml.SelectNodes("//Laden_Dateien_List").Item(0)
                Laden_Dateien_List.Clear()
                If xml2.Attributes.Count > 0 Then
                    For i As Integer = 0 To xml2.Attributes.Count - 1
                        Laden_Dateien_List.Add(xml2.Attributes(i).Value)
                    Next
                End If

                Laden_Dateien_CB_Minsize = If(xml.SelectNodes("//Laden_Dateien_CB_Minsize").Count > 0, toBool(xml.SelectSingleNode("//Laden_Dateien_CB_Minsize").InnerText, False), False)
                Laden_Dateien_Minsize_val = If(xml.SelectNodes("//Laden_Dateien_Minsize_val").Count > 0, toInt(xml.SelectSingleNode("//Laden_Dateien_Minsize_val").InnerText, 1), 1)
                Laden_Dateien_FilterFoldername = If(xml.SelectNodes("//Laden_Dateien_FilterFoldername").Count > 0, xml.SelectSingleNode("//Laden_Dateien_FilterFoldername").InnerText, Settings.Laden_Dateien_FilterFoldername.Text)
                Laden_Dateien_FilterDateiEndung = If(xml.SelectNodes("//Laden_Dateien_FilterDateiEndung").Count > 0, xml.SelectSingleNode("//Laden_Dateien_FilterDateiEndung").InnerText, Settings.Laden_Dateien_FilterDateiEndung.Text)

                Laden_Favs_MediaInfo = If(xml.SelectNodes("//Laden_Favs_MediaInfo").Count > 0, toBool(xml.SelectSingleNode("//Laden_Favs_MediaInfo").InnerText, True), True)
                Laden_Favs_Suche = If(xml.SelectNodes("//Laden_Favs_Suche").Count > 0, toBool(xml.SelectSingleNode("//Laden_Favs_Suche").InnerText, True), True)
                Laden_Favs_Suchmodus = If(xml.SelectNodes("//Laden_Favs_Suchmodus").Count > 0, toInt(xml.SelectSingleNode("//Laden_Favs_Suchmodus").InnerText, 1), 1)
                Laden_Favs_Autostart = If(xml.SelectNodes("//Laden_Favs_Autostart").Count > 0, toBool(xml.SelectSingleNode("//Laden_Favs_Autostart").InnerText, True), True)

            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Laden")

                .WriteStartElement("Laden_Ordner_Einstellungenimmerneu")
                .WriteValue(Laden_Ordner_Einstellungenimmerneu)
                .WriteEndElement()
                .WriteStartElement("Laden_Ordner_MediaInfo")
                .WriteValue(Laden_Ordner_MediaInfo)
                .WriteEndElement()
                .WriteStartElement("Laden_Ordner_Suche")
                .WriteValue(Laden_Ordner_Suche)
                .WriteEndElement()
                .WriteStartElement("Laden_Ordner_suchmodus")
                .WriteValue(Laden_Ordner_suchmodus)
                .WriteEndElement()
                .WriteStartElement("Laden_Ordner_neuerOrdner")
                .WriteValue(Laden_Ordner_neuerOrdner)
                .WriteEndElement()

                .WriteStartElement("Laden_Favs_MediaInfo")
                .WriteValue(Laden_Favs_MediaInfo)
                .WriteEndElement()
                .WriteStartElement("Laden_Favs_Suche")
                .WriteValue(Laden_Favs_Suche)
                .WriteEndElement()
                .WriteStartElement("Laden_Favs_Autostart")
                .WriteValue(Laden_Favs_Autostart)
                .WriteEndElement()
                .WriteStartElement("Laden_Favs_Suchmodus")
                .WriteValue(Laden_Favs_Suchmodus)
                .WriteEndElement()

                .WriteStartElement("Laden_Dateien_CB_Minsize")
                .WriteValue(Laden_Dateien_CB_Minsize)
                .WriteEndElement()
                .WriteStartElement("Laden_Dateien_Minsize_val")
                .WriteValue(Laden_Dateien_Minsize_val)
                .WriteEndElement()
                .WriteStartElement("Laden_Dateien_FilterFoldername")
                .WriteValue(Laden_Dateien_FilterFoldername)
                .WriteEndElement()
                .WriteStartElement("Laden_Dateien_FilterDateiEndung")
                .WriteValue(Laden_Dateien_FilterDateiEndung)
                .WriteEndElement()

                .WriteStartElement("Laden_Dateien_List")
                If Laden_Dateien_List.Count > 0 Then
                    For x As Integer = 0 To Laden_Dateien_List.Count - 1
                        .WriteAttributeString("i" & x, Laden_Dateien_List(x))
                    Next
                End If
                .WriteEndElement()


                .WriteEndElement()



                '.WriteEndElement() 'end name

            End With
        End Sub
    End Class
    Public Class Config_MediaCenter
        Shared Property Default_local_Source As Savemode = Savemode.Info

        Shared Property MediaCenter_Windows_Immerschreiben As Boolean = False
        Shared Property MediaCenter_Windows_pfad As String = "C:\Users\Administrator\AppData\Roaming\Microsoft\eHome\DvdInfoCache"

        Shared Property MediaBrowser_ImagesByName As String = ""
        Shared Property MediaBrowser_ConvertMPAA As Boolean = False
        Shared Sub Standard_Windows()
            With Settings
                .MediaCenter_Windows_Immerschreiben.Checked = False
                .MediaCenter_Windows_pfad.Text = "C:\Users\Administrator\AppData\Roaming\Microsoft\eHome\DvdInfoCache"


            End With


        End Sub

        Shared Sub Standard_MediaBrwoser()
            With Settings

                .MediaBrowser_ImagesByName.Text = ""
                .MediaBrowser_ConvertMPAA.Checked = False
            End With
        End Sub
        Shared Sub Standard_MediaCenter()
            With Settings

                .Kon_plugin_Filme.Checked = True

            End With
        End Sub
        Shared Sub Load()
            With Settings
                .MediaCenter_Windows_Immerschreiben.Checked = MediaCenter_Windows_Immerschreiben
                .MediaCenter_Windows_pfad.Text = MediaCenter_Windows_pfad
                .MediaBrowser_ImagesByName.Text = MediaBrowser_ImagesByName
                .MediaBrowser_ConvertMPAA.Checked = MediaBrowser_ConvertMPAA
                Select Case Default_local_Source
                    Case Is = Savemode.DVDInfo
                        .Kon_plugin_WindowsFilme.Checked = True
                    Case Is = Savemode.Info
                        .Kon_plugin_Filme.Checked = True
                    Case Is = Savemode.mymovies
                        .Kon_plugin_Mediabrowser.Checked = True
                    Case Is = Savemode.nfo
                        .Kon_plugin_XBMC.Checked = True
                End Select

            End With
        End Sub
        Shared Sub Save()
            With Settings
                MediaCenter_Windows_Immerschreiben = .MediaCenter_Windows_Immerschreiben.Checked
                MediaCenter_Windows_pfad = .MediaCenter_Windows_pfad.Text
                MediaBrowser_ImagesByName = .MediaBrowser_ImagesByName.Text
                MediaBrowser_ConvertMPAA = .MediaBrowser_ConvertMPAA.Checked
                Select Case True
                    Case Is = .Kon_plugin_WindowsFilme.Checked
                        Default_local_Source = Savemode.DVDInfo
                    Case Is = .Kon_plugin_Mediabrowser.Checked
                        Default_local_Source = Savemode.mymovies
                    Case Is = .Kon_plugin_Filme.Checked
                        Default_local_Source = Savemode.Info
                    Case Is = .Kon_plugin_XBMC.Checked
                        Default_local_Source = Savemode.nfo
                End Select

            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//MediaCenter").Count > 0 Then
                xml = xmln.SelectNodes("//MediaCenter").Item(0)

                MediaCenter_Windows_Immerschreiben = If(xml.SelectNodes("//MediaCenter_Windows_Immerschreiben").Count > 0, toBool(xml.SelectSingleNode("//MediaCenter_Windows_Immerschreiben").InnerText, False), False)

                MediaCenter_Windows_pfad = If(xml.SelectNodes("//MediaCenter_Windows_pfad").Count > 0, xml.SelectSingleNode("//MediaCenter_Windows_pfad").InnerText, "C:\Users\Administrator\AppData\Roaming\Microsoft\eHome\DvdInfoCache")
                MediaBrowser_ImagesByName = If(xml.SelectNodes("//MediaBrowser_ImagesByName").Count > 0, xml.SelectSingleNode("//MediaBrowser_ImagesByName").InnerText, "")
                MediaBrowser_ConvertMPAA = If(xml.SelectNodes("//MediaBrowser_ConvertMPAA").Count > 0, toBool(xml.SelectSingleNode("//MediaBrowser_ConvertMPAA").InnerText, False), False)

                Dim s As String = If(xml.SelectNodes("//Default_local_Source").Count > 0, xml.SelectSingleNode("//Default_local_Source").InnerText, Savemode.Info.ToString)

                Select Case s
                    Case Is = "3"
                        Default_local_Source = Savemode.DVDInfo
                    Case Is = "0"
                        Default_local_Source = Savemode.Info
                    Case Is = "1"
                        Default_local_Source = Savemode.mymovies
                    Case Is = "2"
                        Default_local_Source = Savemode.nfo
                    Case Else
                        Default_local_Source = Savemode.Info
                End Select
            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("MediaCenter")

                .WriteStartElement("Default_local_Source")
                Dim r As String = "0"
                Select Case Default_local_Source
                    Case Is = Savemode.Info
                        r = "0"
                    Case Is = Savemode.mymovies
                        r = "1"
                    Case Is = Savemode.nfo
                        r = "2"
                    Case Is = Savemode.DVDInfo
                        r = "3"
                    Case Else
                        r = "0"
                End Select
                .WriteValue(r)
                .WriteEndElement()
                .WriteStartElement("MediaCenter_Windows_Immerschreiben")
                .WriteValue(MediaCenter_Windows_Immerschreiben)
                .WriteEndElement()
                .WriteStartElement("MediaCenter_Windows_pfad")
                .WriteValue(MediaCenter_Windows_pfad)
                .WriteEndElement()
                .WriteStartElement("MediaBrowser_ImagesByName")
                .WriteValue(MediaBrowser_ImagesByName)
                .WriteEndElement()
                .WriteStartElement("MediaBrowser_ConvertMPAA")
                .WriteValue(MediaBrowser_ConvertMPAA)
                .WriteEndElement()
                .WriteEndElement()

            End With
        End Sub
    End Class
    Public Class Config_Abrufen
        Shared Property Abrufen_MediaInfo_Dauer_AKT As Boolean = True
        Shared Property Abrufen_MediaInfo_StandardSprache As String = "German"
        Shared Property Abrufen_MediaInfo_StandardFramerate As String = ""

        ''' <summary>
        ''' 0=HHh MMmn 1=Minuten 2=hh:mm
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Property Abrufen_MediaInfo_Dauer_Format As Integer = 0

        'immer = 0/nachfragen= 1/nie= 2
        Shared Property Abrufen_Cover_Modus As FanartAutoselectMode = FanartAutoselectMode.Zufall
        Shared Property Abrufen_Backdrops_Modus As FanartAutoselectMode = FanartAutoselectMode.Zufall
        Shared Property Abrufen_Backdrops_Count As Integer = 3
        Shared Property Abrufen_Thumbnails_Count As Integer = 3
        Shared Property Abrufen_MoviePilotCover As Boolean = True
        Shared Property Abrufen_NurDeutschimAutomodus As Boolean = False
        Shared Sub Standard_Moviesheet()
            With Settings
                .Abrufen_Thumbnails_Count.Value = 3
            End With
        End Sub
        Shared Sub Standard_MediaInfo()
            With Settings
                .Abrufen_MediaInfo_Dauer_AKT.Checked = True
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad
                .Abrufen_MediaInfo_StandardFramerate.Text = ""

                .Abrufen_MediaInfo_StandardSprache.Text = "German"
                .Abrufen_MediaInfo_Dauer_Format_Standard.Checked = True

            End With
        End Sub
        Shared Sub Standard_Backdrops()
            With Settings

                .Abrufen_NurDeutschimAutomodus.Checked = False
                .Abrufen_MoviePilotCover.Checked = True
                .Abrufen_Backdrops_Count.Value = 3
                '.Abrufen_Cover_Kein.AutoCheck = False
                '.Abrufen_Cover_DasErste.AutoCheck = False
                '.Abrufen_Cover_Random.AutoCheck = False
                '.Abrufen_Backdrops_Alle.AutoCheck = False
                '.Abrufen_Backdrops_dieerstenx.AutoCheck = False
                '.Abrufen_Backdrops_Zufall.AutoCheck = False
                '.Abrufen_Cover_Kein.Checked = False
                '.Abrufen_Cover_DasErste.Checked = False
                .Abrufen_Cover_Random.Checked = True
                .Abrufen_Backdrops_Zufall.Checked = True

                '.Abrufen_Cover_Kein.AutoCheck = True
                '.Abrufen_Cover_DasErste.AutoCheck = True
                '.Abrufen_Cover_Random.AutoCheck = True
            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Abrufen_MediaInfo_Dauer_AKT.Checked = Abrufen_MediaInfo_Dauer_AKT
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad
                .Abrufen_Thumbnails_Count.Value = Abrufen_Thumbnails_Count
                .Abrufen_MediaInfo_StandardFramerate.Text = Abrufen_MediaInfo_StandardFramerate
                .Abrufen_Backdrops_Count.Value = Abrufen_Backdrops_Count
                .Abrufen_MediaInfo_StandardSprache.Text = Abrufen_MediaInfo_StandardSprache
                Select Case Abrufen_MediaInfo_Dauer_Format
                    Case Is = 0
                        .Abrufen_MediaInfo_Dauer_Format_Standard.Checked = True
                    Case Is = 1
                        .Abrufen_MediaInfo_Dauer_Format_Minuten.Checked = True
                    Case Is = 2
                        .Abrufen_MediaInfo_Dauer_Format_Alternativ.Checked = True
                End Select

                .Abrufen_MoviePilotCover.Checked = Abrufen_MoviePilotCover
                .Abrufen_NurDeutschimAutomodus.Checked = Abrufen_NurDeutschimAutomodus
                '.Abrufen_Cover_Kein.AutoCheck = False
                '.Abrufen_Cover_DasErste.AutoCheck = False
                '.Abrufen_Cover_Random.AutoCheck = False
                '.Abrufen_Backdrops_Alle.AutoCheck = False
                '.Abrufen_Backdrops_dieerstenx.AutoCheck = False
                '.Abrufen_Backdrops_Zufall.AutoCheck = False
                Select Case Abrufen_Cover_Modus
                    Case Is = FanartAutoselectMode.Keine
                        .Abrufen_Cover_DasErste.Checked = False
                        .Abrufen_Cover_Random.Checked = False
                        .Abrufen_Cover_Kein.Checked = True
                    Case Is = FanartAutoselectMode.Reihenfolge
                        .Abrufen_Cover_Kein.Checked = False
                        .Abrufen_Cover_Random.Checked = False
                        .Abrufen_Cover_DasErste.Checked = True
                    Case Is = FanartAutoselectMode.Zufall
                        .Abrufen_Cover_Kein.Checked = False
                        .Abrufen_Cover_DasErste.Checked = False
                        .Abrufen_Cover_Random.Checked = True
                End Select
                Select Case Abrufen_Backdrops_Modus
                    Case Is = FanartAutoselectMode.Alle
                        .Abrufen_Backdrops_Alle.Checked = True
                    Case Is = FanartAutoselectMode.Reihenfolge
                        .Abrufen_Backdrops_dieerstenx.Checked = True
                    Case Is = FanartAutoselectMode.Zufall
                        .Abrufen_Backdrops_Zufall.Checked = True
                End Select
                '.Abrufen_Cover_Kein.AutoCheck = True
                '.Abrufen_Cover_DasErste.AutoCheck = True
                '.Abrufen_Cover_Random.AutoCheck = True
            End With
        End Sub
        Shared Sub Save()
            With Settings
                Abrufen_MediaInfo_StandardSprache = .Abrufen_MediaInfo_StandardSprache.Text
                Abrufen_MediaInfo_Dauer_AKT = .Abrufen_MediaInfo_Dauer_AKT.Checked
                'Abrufen_MediaInfo_Pfad = .Abrufen_MediaInfo_Pfad.Text
                Abrufen_Thumbnails_Count = CInt(.Abrufen_Thumbnails_Count.Value)
                Abrufen_MediaInfo_StandardFramerate = .Abrufen_MediaInfo_StandardFramerate.Text
                Abrufen_Backdrops_Count = CInt(.Abrufen_Backdrops_Count.Value)
                Abrufen_MoviePilotCover = .Abrufen_MoviePilotCover.Checked
                Abrufen_NurDeutschimAutomodus = .Abrufen_NurDeutschimAutomodus.Checked
                Select Case True
                    Case Is = .Abrufen_MediaInfo_Dauer_Format_Standard.Checked
                        Abrufen_MediaInfo_Dauer_Format = 0
                    Case Is = .Abrufen_MediaInfo_Dauer_Format_Minuten.Checked
                        Abrufen_MediaInfo_Dauer_Format = 1
                    Case Is = .Abrufen_MediaInfo_Dauer_Format_Alternativ.Checked
                        Abrufen_MediaInfo_Dauer_Format = 2
                End Select

                Select Case True
                    Case Is = .Abrufen_Cover_Kein.Checked
                        Abrufen_Cover_Modus = FanartAutoselectMode.Keine
                    Case Is = .Abrufen_Cover_DasErste.Checked
                        Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge
                    Case Is = .Abrufen_Cover_Random.Checked
                        Abrufen_Cover_Modus = FanartAutoselectMode.Zufall
                End Select
                Select Case True
                    Case Is = .Abrufen_Backdrops_Alle.Checked
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Alle
                    Case Is = .Abrufen_Backdrops_dieerstenx.Checked
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Reihenfolge
                    Case Is = .Abrufen_Backdrops_Zufall.Checked
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Zufall
                End Select
            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Laden").Count > 0 Then
                xml = xmln.SelectNodes("//Laden").Item(0)
                Abrufen_MediaInfo_StandardFramerate = If(xml.SelectNodes("//Abrufen_MediaInfo_StandardFramerate").Count > 0, xml.SelectSingleNode("//Abrufen_MediaInfo_StandardFramerate").InnerText, "")

                Abrufen_MediaInfo_StandardSprache = If(xml.SelectNodes("//Abrufen_MediaInfo_StandardSprache").Count > 0, xml.SelectSingleNode("//Abrufen_MediaInfo_StandardSprache").InnerText, "")
                Abrufen_MediaInfo_Dauer_AKT = If(xml.SelectNodes("//Abrufen_MediaInfo_Dauer_AKT").Count > 0, toBool(xml.SelectSingleNode("//Abrufen_MediaInfo_Dauer_AKT").InnerText, True), True)
                Abrufen_MediaInfo_Dauer_Format = If(xml.SelectNodes("//Abrufen_MediaInfo_Dauer_Format").Count > 0, toInt(xml.SelectSingleNode("//Abrufen_MediaInfo_Dauer_Format").InnerText, 0), 0)
                Abrufen_Backdrops_Count = If(xml.SelectNodes("//Abrufen_Backdrops_Count").Count > 0, toInt(xml.SelectSingleNode("//Abrufen_Backdrops_Count").InnerText, 0), 0)
                Abrufen_MoviePilotCover = If(xml.SelectNodes("//Abrufen_MoviePilotCover").Count > 0, toBool(xml.SelectSingleNode("//Abrufen_MoviePilotCover").InnerText, True), True)
                Abrufen_Thumbnails_Count = If(xml.SelectNodes("//Abrufen_Thumbnails_Count").Count > 0, toInt(xml.SelectSingleNode("//Abrufen_Thumbnails_Count").InnerText, 3), 3)
                Abrufen_NurDeutschimAutomodus = If(xml.SelectNodes("//Abrufen_NurDeutschimAutomodus").Count > 0, toBool(xml.SelectSingleNode("//Abrufen_NurDeutschimAutomodus").InnerText, False), False)

                Dim s As String = If(xml.SelectNodes("//Abrufen_Backdrops_Modus").Count > 0, xml.SelectSingleNode("//Abrufen_Backdrops_Modus").InnerText, "")

                Select Case s
                    Case Is = "3"
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Zufall
                    Case Is = "0"
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Alle
                    Case Is = "2"
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Reihenfolge
                    Case Else
                        Abrufen_Backdrops_Modus = FanartAutoselectMode.Zufall
                End Select
                s = If(xml.SelectNodes("//Abrufen_Cover_Modus").Count > 0, xml.SelectSingleNode("//Abrufen_Cover_Modus").InnerText, "")

                Select Case s
                    Case Is = "3"
                        Abrufen_Cover_Modus = FanartAutoselectMode.Zufall
                    Case Is = "1"
                        Abrufen_Cover_Modus = FanartAutoselectMode.Keine
                    Case Is = "2"
                        Abrufen_Cover_Modus = FanartAutoselectMode.Reihenfolge
                    Case Else
                        Abrufen_Cover_Modus = FanartAutoselectMode.Zufall
                End Select
            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Abrufen")

                .WriteStartElement("Abrufen_MediaInfo_StandardSprache")
                .WriteValue(Abrufen_MediaInfo_StandardSprache)
                .WriteEndElement()
                .WriteStartElement("Abrufen_MediaInfo_StandardFramerate")
                .WriteValue(Abrufen_MediaInfo_StandardFramerate)
                .WriteEndElement()
                .WriteStartElement("Abrufen_MoviePilotCover")
                .WriteValue(Abrufen_MoviePilotCover)
                .WriteEndElement()
                .WriteStartElement("Abrufen_NurDeutschimAutomodus")
                .WriteValue(Abrufen_NurDeutschimAutomodus)
                .WriteEndElement()
                .WriteStartElement("Abrufen_Thumbnails_Count")
                .WriteValue(Abrufen_Thumbnails_Count)
                .WriteEndElement()

                .WriteStartElement("Abrufen_MediaInfo_Dauer_AKT")
                .WriteValue(Abrufen_MediaInfo_Dauer_AKT)
                .WriteEndElement()

                .WriteStartElement("Abrufen_MediaInfo_Dauer_Format")
                .WriteValue(Abrufen_MediaInfo_Dauer_Format)
                .WriteEndElement()

                .WriteStartElement("Abrufen_Backdrops_Count")
                .WriteValue(Abrufen_Backdrops_Count)
                .WriteEndElement()

                .WriteStartElement("Abrufen_Backdrops_Modus")
                Dim r As String = "0"
                Select Case Abrufen_Backdrops_Modus
                    Case Is = FanartAutoselectMode.Alle
                        r = "0"
                    Case Is = FanartAutoselectMode.Reihenfolge
                        r = "2"
                    Case Is = FanartAutoselectMode.Zufall
                        r = "3"
                End Select
                .WriteValue(r)
                .WriteEndElement()

                .WriteStartElement("Abrufen_Cover_Modus")
                r = "0"
                Select Case Abrufen_Cover_Modus
                    Case Is = FanartAutoselectMode.Keine
                        r = "1"
                    Case Is = FanartAutoselectMode.Reihenfolge
                        r = "2"
                    Case Is = FanartAutoselectMode.Zufall
                        r = "3"
                End Select
                .WriteValue(r)
                .WriteEndElement()

                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Cache
        Shared Property Cache_Automatisch As Boolean = True
        Shared Property Cache_MaxSize As Integer = 200

        Shared Sub Standard()
            With Settings
                .Cache_MaxSize.Value = 200
                .Cache_Automatisch.Checked = True
            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Cache_Automatisch.Checked = Cache_Automatisch
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad
                .Cache_MaxSize.Value = Cache_MaxSize

            End With
        End Sub
        Shared Sub Save()
            With Settings

                Cache_Automatisch = .Cache_Automatisch.Checked
                'Abrufen_MediaInfo_Pfad = .Abrufen_MediaInfo_Pfad.Text
                Cache_MaxSize = CInt(.Cache_MaxSize.Value)
             
            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Cache").Count > 0 Then
                xml = xmln.SelectNodes("//Cache").Item(0)
                Cache_Automatisch = If(xml.SelectNodes("//Cache_Automatisch").Count > 0, toBool(xml.SelectSingleNode("//Cache_Automatisch").InnerText, True), True)
                Cache_MaxSize = If(xml.SelectNodes("//Cache_MaxSize").Count > 0, toInt(xml.SelectSingleNode("//Cache_MaxSize").InnerText, 200), 200)

            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Cache")

                .WriteStartElement("Cache_Automatisch")
                .WriteValue(Cache_Automatisch)
                .WriteEndElement()
                .WriteStartElement("Cache_MaxSize")
                .WriteValue(Cache_MaxSize)
                .WriteEndElement()


                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Update
        Shared Property Update_Auto As Boolean = True
        Shared Property Update_last As Date = Now
        Shared Sub Standard()
            With Settings
                .Update_Auto.Checked = True
            End With

        End Sub

        Shared Sub Load()
            With Settings
                .Update_Auto.Checked = Update_Auto
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad

                .Update_Last.Text = Update_last.ToString
            End With

        End Sub
        Shared Sub Save()
            With Settings
                Update_Auto = .Update_Auto.Checked

            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Update").Count > 0 Then
                xml = xmln.SelectNodes("//Update").Item(0)

                Update_last = If(xml.SelectNodes("//Update_last").Count > 0, toDate(xml.SelectSingleNode("//Update_last").InnerText, Now), Now)
                Update_Auto = If(xml.SelectNodes("//Update_Auto").Count > 0, toBool(xml.SelectSingleNode("//Update_Auto").InnerText, True), True)

            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Update")

                .WriteStartElement("Update_last")
                .WriteValue(Update_last)
                .WriteEndElement()

                .WriteStartElement("Update_Auto")
                .WriteValue(Update_Auto)
                .WriteEndElement()

                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Trailer
        Shared Property Trailer_lng As String = "de"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value>0: nur/ausschließlich
        ''' 1: bevorzugt</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Property Trailer_lng_modi As Integer = 0
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value>0:SD  1:HQ   2:HD</value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Property Trailer_quali As Integer = 2
        Shared Sub Standard()
            With Settings
                .Trailer_lng_german.Checked = True
                .Trailer_quali_hd.Checked = True
                .Trailer_lng_modi.SelectedIndex = 0
            End With
        End Sub
      
        Shared Sub Load()
            With Settings
                If Trailer_quali = 0 Then
                    .Trailer_quali_sd.Checked = True
                ElseIf Trailer_quali = 1 Then
                    .Trailer_quali_hq.Checked = True
                Else
                    .Trailer_quali_hd.Checked = True
                End If

                .Trailer_lng_modi.SelectedIndex = Trailer_lng_modi
                If Trailer_lng = "de" Then
                    .Trailer_lng_german.Checked = True
                Else
                    .Trailer_lng_english.Checked = True
                End If

            End With
        End Sub
        Shared Sub Save()
            With Settings
                If .Trailer_quali_sd.Checked = True Then
                    Trailer_quali = 0
                ElseIf .Trailer_quali_hq.Checked = True Then
                    Trailer_quali = 1
                Else
                    Trailer_quali = 2
                End If
                Trailer_lng_modi = .Trailer_lng_modi.SelectedIndex

                If .Trailer_lng_german.Checked = True Then
                    Trailer_lng = "de"
                Else
                    Trailer_lng = "en"
                End If


            End With
        End Sub


        Public Shared Sub Load(ByVal xml As Xml.XmlDocument)

            If xml.SelectNodes("//Trailer").Count > 0 Then

                Trailer_lng_modi = If(xml.SelectNodes("//Trailer/Trailer_lng_modi").Count > 0, toInt(xml.SelectSingleNode("//Trailer/Trailer_lng_modi").InnerText, 0), 0)
                Trailer_lng = If(xml.SelectNodes("//Trailer/Trailer_lng").Count > 0, xml.SelectSingleNode("//Trailer/Trailer_lng").InnerText, "de")
                Trailer_quali = If(xml.SelectNodes("//Trailer/Trailer_quali").Count > 0, toInt(xml.SelectSingleNode("//Trailer/Trailer_quali").InnerText, 2), 2)


            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Trailer")

                .WriteStartElement("Trailer_lng_modi")
                .WriteValue(Trailer_lng_modi)
                .WriteEndElement()

                .WriteStartElement("Trailer_lng")
                .WriteValue(Trailer_lng)
                .WriteEndElement()

                .WriteStartElement("Trailer_quali")
                .WriteValue(Trailer_quali)
                .WriteEndElement()

                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Save
        Shared Property Save_Artikel_Titel_Vorne As Boolean = True
        Shared Property Save_Artikel_OriginalTitel_Vorne As Boolean = False
        Shared Property Save_Artikel_Sort_Vorne As Boolean = False
        Shared Property Save_Artikel_Erkennung As String = "der;die;das;Der;Die;Das;the;The;a;A"
        Shared Property Save_Rename_Sub_Files As Boolean = False
        Shared Property Save_Rename_File As Boolean = False
        Shared Property Save_Rename_Folder As Boolean = False
        Shared Property Save_Rename_moreFiles As Boolean = False
        Shared Property Save_Rename_Filepat As String = ""
        Shared Property Save_Rename_Filespat As String = ""
        Shared Property Save_Rename_Folderpat As String = ""
        Shared Sub Standard_Rename()
            With Settings
                .Save_rename_Filespat.Text = ""
                .Save_Rename_moreFiles.Checked = False
                .Save_rename_Filepat.Text = ""
                .Save_rename_Folderpat.Text = ""
                .Save_Rename_File.Checked = False
                .Save_rename_Folder.Checked = False
                .Save_Rename_Sub_Files.Checked = False
            End With
        End Sub
        Shared Sub Standard_Artikel()
            With Settings
                .Save_Artikel_Titel_Vorne.Checked = True
                .Save_Artikel_OriginalTitel_Vorne.Checked = False
                .Save_Artikel_Sort_Vorne.Checked = False

                .Save_Artikel_Titel_Hinten.Checked = False
                .Save_Artikel_OriginalTitel_Hinten.Checked = True
                .Save_Artikel_Sort_Hinten.Checked = True
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad
                .Save_Artikel_Valid.Text = "der;die;das;Der;Die;Das;the;The;a;A"


            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Save_Artikel_Titel_Vorne.Checked = Save_Artikel_Titel_Vorne
                .Save_Artikel_OriginalTitel_Vorne.Checked = Save_Artikel_OriginalTitel_Vorne
                .Save_Artikel_Sort_Vorne.Checked = Save_Artikel_Sort_Vorne

                .Save_Artikel_Titel_Hinten.Checked = Not Save_Artikel_Titel_Vorne
                .Save_Artikel_OriginalTitel_Hinten.Checked = Not Save_Artikel_OriginalTitel_Vorne
                .Save_Artikel_Sort_Hinten.Checked = Not Save_Artikel_Sort_Vorne
                '.Abrufen_MediaInfo_Pfad.Text = Abrufen_MediaInfo_Pfad
                .Save_Artikel_Valid.Text = Save_Artikel_Erkennung
                .Save_rename_Filespat.Text = Save_Rename_Filespat
                .Save_Rename_moreFiles.Checked = Save_Rename_moreFiles
                .Save_rename_Filepat.Text = Save_Rename_Filepat
                .Save_rename_Folderpat.Text = Save_Rename_Folderpat
                .Save_Rename_File.Checked = Save_Rename_File
                .Save_rename_Folder.Checked = Save_Rename_Folder
                .Save_Rename_Sub_Files.Checked = Save_Rename_Sub_Files
            End With
        End Sub
        Shared Sub Save()
            With Settings
                Save_Artikel_Titel_Vorne = .Save_Artikel_Titel_Vorne.Checked
                Save_Artikel_OriginalTitel_Vorne = .Save_Artikel_OriginalTitel_Vorne.Checked
                Save_Artikel_Sort_Vorne = .Save_Artikel_Sort_Vorne.Checked
                Save_Rename_Sub_Files = .Save_Rename_Sub_Files.Checked
                Save_Artikel_Erkennung = .Save_Artikel_Valid.Text
                Save_Rename_Filespat = .Save_rename_Filespat.Text
                Save_Rename_moreFiles = .Save_Rename_moreFiles.Checked
                Save_Rename_Filepat = .Save_rename_Filepat.Text
                Save_Rename_Folderpat = .Save_rename_Folderpat.Text
                Save_Rename_File = .Save_Rename_File.Checked
                Save_Rename_Folder = .Save_rename_Folder.Checked
                If Save_Rename_moreFiles = False Then
                    If Save_Rename_Filepat = "" Then
                        Save_Rename_Filespat = ""
                    Else
                        Save_Rename_Filespat = Save_Rename_Filepat & " Teil {n}"
                    End If
                End If
            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Speichern").Count > 0 Then
                xml = xmln.SelectNodes("//Speichern").Item(0)

                Save_Rename_Sub_Files = If(xml.SelectNodes("//Speichern/Save_Rename_Sub_Files").Count > 0, toBool(xml.SelectSingleNode("//Speichern/Save_Rename_Sub_Files").InnerText, False), False)

                Save_Artikel_Titel_Vorne = If(xml.SelectNodes("//Save_Artikel_Titel_Vorne").Count > 0, toBool(xml.SelectSingleNode("//Save_Artikel_Titel_Vorne").InnerText, True), True)
                Save_Artikel_OriginalTitel_Vorne = If(xml.SelectNodes("//Save_Artikel_OriginalTitel_Vorne").Count > 0, toBool(xml.SelectSingleNode("//Save_Artikel_OriginalTitel_Vorne").InnerText, True), True)
                Save_Artikel_Sort_Vorne = If(xml.SelectNodes("//Save_Artikel_Sort_Vorne").Count > 0, toBool(xml.SelectSingleNode("//Save_Artikel_Sort_Vorne").InnerText, False), False)
                Save_Artikel_Erkennung = If(xml.SelectNodes("//Save_Artikel_Erkennung").Count > 0, xml.SelectSingleNode("//Save_Artikel_Erkennung").InnerText, "")

                Save_Rename_File = If(xml.SelectNodes("//Save_Rename_File").Count > 0, toBool(xml.SelectSingleNode("//Save_Rename_File").InnerText, False), False)
                Save_Rename_Folder = If(xml.SelectNodes("//Save_Rename_Folder").Count > 0, toBool(xml.SelectSingleNode("//Save_Rename_Folder").InnerText, False), False)
                Save_Rename_Filepat = If(xml.SelectNodes("//Save_Rename_Filepat").Count > 0, xml.SelectSingleNode("//Save_Rename_Filepat").InnerText, "")
                Save_Rename_Filespat = If(xml.SelectNodes("//Save_Rename_Filespat").Count > 0, xml.SelectSingleNode("//Save_Rename_Filespat").InnerText, "")
                Save_Rename_Folderpat = If(xml.SelectNodes("//Save_Rename_Folderpat").Count > 0, xml.SelectSingleNode("//Save_Rename_Folderpat").InnerText, "")
                Save_Rename_moreFiles = If(xml.SelectNodes("//Save_Rename_moreFiles").Count > 0, toBool(xml.SelectSingleNode("//Save_Rename_moreFiles").InnerText, False), False)
                If Save_Rename_moreFiles = False Then
                    If Save_Rename_Filepat = "" Then
                        Save_Rename_Filespat = ""
                    Else
                        Save_Rename_Filespat = Save_Rename_Filepat & " Teil {n}"
                    End If
                End If
            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Speichern")

                .WriteStartElement("Save_Artikel_Titel_Vorne")
                .WriteValue(Save_Artikel_Titel_Vorne)
                .WriteEndElement()

                .WriteStartElement("Save_Artikel_OriginalTitel_Vorne")
                .WriteValue(Save_Artikel_OriginalTitel_Vorne)
                .WriteEndElement()

                .WriteStartElement("Save_Artikel_Sort_Vorne")
                .WriteValue(Save_Artikel_Sort_Vorne)
                .WriteEndElement()

                .WriteStartElement("Save_Artikel_Erkennung")
                .WriteValue(Save_Artikel_Erkennung)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_File")
                .WriteValue(Save_Rename_File)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_moreFiles")
                .WriteValue(Save_Rename_moreFiles)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_Folder")
                .WriteValue(Save_Rename_Folder)
                .WriteEndElement()


                .WriteStartElement("Save_Rename_Filepat")
                .WriteValue(Save_Rename_Filepat)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_Filespat")
                .WriteValue(Save_Rename_Filespat)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_Folderpat")
                .WriteValue(Save_Rename_Folderpat)
                .WriteEndElement()

                .WriteStartElement("Save_Rename_Sub_Files")
                .WriteValue(Save_Rename_Sub_Files)
                .WriteEndElement()


                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_BrowserSuche

        Shared Property BrowserSuche_Use_IMDB_COM As Boolean = False
        Shared Property BrowserSuche_external_Browsing As Boolean = False

        Shared Sub Standard()
            With Settings
                .BrowserSuche_external_Browsing.Checked = False
                .BrowserSuche_Use_IMDB_COM.Checked = False
            End With
        End Sub


        Shared Sub Load()
            With Settings
                .BrowserSuche_external_Browsing.Checked = BrowserSuche_external_Browsing
                .BrowserSuche_Use_IMDB_COM.Checked = BrowserSuche_Use_IMDB_COM

            End With
        End Sub
        Shared Sub Save()
            With Settings
                BrowserSuche_external_Browsing = .BrowserSuche_external_Browsing.Checked
                BrowserSuche_Use_IMDB_COM = .BrowserSuche_Use_IMDB_COM.Checked

            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)

            BrowserSuche_Use_IMDB_COM = If(xmln.SelectNodes("//BrowserSuche/BrowserSuche_Use_IMDB_COM").Count > 0, toBool( _
                                           xmln.SelectSingleNode("//BrowserSuche/BrowserSuche_Use_IMDB_COM").InnerText, False), False)

            BrowserSuche_external_Browsing = If(xmln.SelectNodes("//BrowserSuche/BrowserSuche_external_Browsing").Count > 0, toBool( _
                                                xmln.SelectSingleNode("//BrowserSuche/BrowserSuche_external_Browsing").InnerText, False), False)



        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("BrowserSuche")

                .WriteStartElement("BrowserSuche_external_Browsing")
                .WriteValue(BrowserSuche_external_Browsing)
                .WriteEndElement()

                .WriteStartElement("BrowserSuche_Use_IMDB_COM")
                .WriteValue(BrowserSuche_Use_IMDB_COM)
                .WriteEndElement()


                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Genre
        ''' <summary>
        ''' 0 = Deutsch ; 1= Eng
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Shared Property Genre_language As Integer = 0  '1
        Shared Property Genre_AutoReplace As Boolean = True
        Shared Property Genre_AutoDontAccept As Boolean = False
        Shared Property Genre_tmdbdownload As Boolean = True
        Shared Sub Standard()
            With Settings
                .Genre_AutoReplace.Checked = True
                .Genre_AutoDontAccept.Checked = False
                .Genre_tmdbdownload.Checked = True
                .Genre_language.SelectedIndex = 0
            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Genre_AutoReplace.Checked = Genre_AutoReplace
                .Genre_AutoDontAccept.Checked = Genre_AutoDontAccept
                .Genre_tmdbdownload.Checked = Genre_tmdbdownload

                .Genre_language.SelectedIndex = Genre_language
            End With
        End Sub
        Shared Sub Save()
            With Settings
                Genre_AutoReplace = .Genre_AutoReplace.Checked
                Genre_AutoDontAccept = .Genre_AutoDontAccept.Checked
                Genre_tmdbdownload = .Genre_tmdbdownload.Checked

                If .Genre_language.SelectedIndex = -1 Then
                    Genre_language = 0
                Else
                    Genre_language = .Genre_language.SelectedIndex
                End If
            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNode
            If xmln.SelectNodes("//Genre").Count > 0 Then
                xml = xmln.SelectNodes("//Genre").Item(0)


                Genre_language = If(xml.SelectNodes("//Genre_language").Count > 0, toInt(xml.SelectSingleNode("//Genre_language").InnerText, 0), 0)
                Genre_AutoReplace = If(xml.SelectNodes("//Genre_AutoReplace").Count > 0, toBool(xml.SelectSingleNode("//Genre_AutoReplace").InnerText, True), True)
                Genre_AutoDontAccept = If(xml.SelectNodes("//Genre_AutoDontAccept").Count > 0, toBool(xml.SelectSingleNode("//Genre_AutoDontAccept").InnerText, False), False)
                Genre_tmdbdownload = If(xml.SelectNodes("//Genre_tmdbdownload").Count > 0, toBool(xml.SelectSingleNode("//Genre_tmdbdownload").InnerText, True), True)


            End If
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("Genre")

                .WriteStartElement("Genre_language")
                .WriteValue(Genre_language)
                .WriteEndElement()

                .WriteStartElement("Genre_AutoReplace")
                .WriteValue(Genre_AutoReplace)
                .WriteEndElement()

                .WriteStartElement("Genre_AutoDontAccept")
                .WriteValue(Genre_AutoDontAccept)
                .WriteEndElement()

                .WriteStartElement("Genre_tmdbdownload")
                .WriteValue(Genre_tmdbdownload)
                .WriteEndElement()

                .WriteEndElement()


            End With
        End Sub
    End Class
    Public Class Config_Overwrite
        Public Shared Mode As Overwritemode = Overwritemode.Automatisch
        Public Shared Titel As Boolean = True
        Public Shared Originaltitel As Boolean = True
        Public Shared IMDB_ID As Boolean = True
        Public Shared Darsteller As Boolean = True
        Public Shared Regisseur As Boolean = True
        Public Shared Autoren As Boolean = True
        Public Shared Studios As Boolean = True
        Public Shared Produktionsjahr As Boolean = True
        Public Shared Produktionsland As Boolean = True
        Public Shared Genre As Boolean = True
        Public Shared FSK As Boolean = True
        Public Shared Bewertung As Boolean = True
        Public Shared Spieldauer As Boolean = True
        Public Shared Kurzbeschreibung As Boolean = True
        Public Shared Inhalt As Boolean = True
        Public Shared Sort As Boolean = True

        Shared Sub Load()
            With MainForm
                .OverwriteMenuItem_Titel.Checked = Titel
                .OverwriteMenuItem_Originaltitel.Checked = Originaltitel
                .OverwriteMenuItem_IMDB_ID.Checked = IMDB_ID
                .OverwriteMenuItem_Darsteller.Checked = Darsteller
                .OverwriteMenuItem_Regisseur.Checked = Regisseur
                .OverwriteMenuItem_Autoren.Checked = Autoren
                .OverwriteMenuItem_Studios.Checked = Studios
                .OverwriteMenuItem_Produktionsjahr.Checked = Produktionsjahr
                .OverwriteMenuItem_Produktionsland.Checked = Produktionsland
                .OverwriteMenuItem_Genre.Checked = Genre
                .OverwriteMenuItem_FSK.Checked = FSK
                .OverwriteMenuItem_Bewertung.Checked = Bewertung
                .OverwriteMenuItem_Inhalt.Checked = Inhalt
                .OverwriteMenuItem_Sort.Checked = Sort
            End With
        End Sub
        Shared Sub Save()
            With MainForm
                Titel = .OverwriteMenuItem_Titel.Checked
                Originaltitel = .OverwriteMenuItem_Originaltitel.Checked
                IMDB_ID = .OverwriteMenuItem_IMDB_ID.Checked
                Darsteller = .OverwriteMenuItem_Darsteller.Checked
                Regisseur = .OverwriteMenuItem_Regisseur.Checked
                Autoren = .OverwriteMenuItem_Autoren.Checked
                Studios = .OverwriteMenuItem_Studios.Checked
                Produktionsjahr = .OverwriteMenuItem_Produktionsjahr.Checked
                Produktionsland = .OverwriteMenuItem_Produktionsland.Checked
                Genre = .OverwriteMenuItem_Genre.Checked
                FSK = .OverwriteMenuItem_FSK.Checked
                Bewertung = .OverwriteMenuItem_Bewertung.Checked
                Inhalt = .OverwriteMenuItem_Inhalt.Checked
                Sort = .OverwriteMenuItem_Sort.Checked

            End With
        End Sub

        Public Shared Sub Save(ByVal s As XmlWriter)

            With s

                '.Formatting = Xml.Formatting.Indented
                '.Indentation = 4

                '.WriteStartDocument()
                .WriteStartElement("Überschreiben")




                .WriteStartElement("Titel")
                .WriteValue(Titel)
                .WriteEndElement()

                .WriteStartElement("Originaltitel")
                .WriteValue(Originaltitel)
                .WriteEndElement()

                .WriteStartElement("IMDB_ID")
                .WriteValue(IMDB_ID)
                .WriteEndElement()

                .WriteStartElement("Darsteller")
                .WriteValue(Darsteller)
                .WriteEndElement()

                .WriteStartElement("Regisseur")
                .WriteValue(Regisseur)
                .WriteEndElement()

                .WriteStartElement("Autoren")
                .WriteValue(Autoren)
                .WriteEndElement()

                .WriteStartElement("Studios")
                .WriteValue(Studios)
                .WriteEndElement()

                .WriteStartElement("Produktionsjahr")
                .WriteValue(Produktionsjahr)
                .WriteEndElement()

                .WriteStartElement("Produktionsland")
                .WriteValue(Produktionsland)
                .WriteEndElement()

                .WriteStartElement("Genre")
                .WriteValue(Genre)
                .WriteEndElement()

                .WriteStartElement("FSK")
                .WriteValue(FSK)
                .WriteEndElement()

                .WriteStartElement("Bewertung")
                .WriteValue(Bewertung)
                .WriteEndElement()

                .WriteStartElement("Spieldauer")
                .WriteValue(Spieldauer)
                .WriteEndElement()

                '.WriteStartElement("Kurzbeschreibung")
                '.WriteValue(Kurzbeschreibung)
                '.WriteEndElement()

                .WriteStartElement("Inhalt")
                .WriteValue(Inhalt)
                .WriteEndElement()

                .WriteStartElement("Sort")
                .WriteValue(Sort)
                .WriteEndElement()

                Dim i As Integer = 0
                If Mode = Overwritemode.Automatisch Then
                    i = 0
                ElseIf Mode = Overwritemode.Benutzerdefiniert Then
                    i = 1
                ElseIf Mode = Overwritemode.Ergänzen Then
                    i = 2
                ElseIf Mode = Overwritemode.Ersetzen Then
                    i = 3
                End If

                .WriteStartElement("Mode")
                .WriteValue(i)
                .WriteEndElement()
                '.WriteStartElement("MediaInfo")
                '.WriteValue(MediaInfo)
                '.WriteEndElement()

                '.WriteStartElement("Position")
                '.WriteValue(Position)
                '.WriteEndElement()

                '.WriteStartElement("Datum")
                '.WriteValue(Datum)
                '.WriteEndElement()





                .WriteEndElement()
                '.Close()
            End With
        End Sub
        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)
            Dim xml As XmlNodeList

            If xmln.SelectNodes("//Überschreiben").Count > 0 Then
                xml = xmln.SelectNodes("//Überschreiben").Item(0).ChildNodes

                If xml.Count = 16 Then
                    Dim i As Integer = toInt(xml(15).InnerText, 0)

                    If i = 0 Then
                        Mode = Overwritemode.Automatisch
                        MainForm.InfoPanel_Movie1.Tool_Overwrite.Text = "Automatisch"
                    ElseIf i = 1 Then
                        Mode = Overwritemode.Benutzerdefiniert
                        MainForm.InfoPanel_Movie1.Tool_Overwrite.Text = "Benutzerdefiniert"
                    ElseIf i = 2 Then
                        Mode = Overwritemode.Ergänzen
                        MainForm.InfoPanel_Movie1.Tool_Overwrite.Text = "Ergänzen"
                    ElseIf i = 3 Then
                        Mode = Overwritemode.Ersetzen
                        MainForm.InfoPanel_Movie1.Tool_Overwrite.Text = "Ersetzen"
                    End If

                    Titel = toBool(xml(0).InnerText, False)
                    Originaltitel = toBool(xml(1).InnerText, False)
                    IMDB_ID = toBool(xml(2).InnerText, False)
                    Darsteller = toBool(xml(3).InnerText, False)
                    Regisseur = toBool(xml(4).InnerText, False)
                    Autoren = toBool(xml(5).InnerText, False)
                    Studios = toBool(xml(6).InnerText, False)
                    Produktionsjahr = toBool(xml(7).InnerText, False)
                    Produktionsland = toBool(xml(8).InnerText, False)
                    Genre = toBool(xml(9).InnerText, False)
                    FSK = toBool(xml(10).InnerText, False)
                    Bewertung = toBool(xml(11).InnerText, False)
                    Spieldauer = toBool(xml(12).InnerText, False)
                    'Kurzbeschreibung = toBool(xml(13).InnerText, False)
                    Inhalt = toBool(xml(13).InnerText, False)
                    Sort = toBool(xml(14).InnerText, False)
                End If

            End If
        End Sub
    End Class
    Public Class Config_Favoriten
        Shared Property paths As New List(Of String)

        Public Shared Sub Save()
            Dim enc As New System.Text.UTF8Encoding

            ' XmlTextWriter-Objekt für unsere Ausgabedatei erzeugen: 
            Dim XMLobj As Xml.XmlTextWriter _
              = New Xml.XmlTextWriter(IO.Path.Combine(SettingsPath, "Favoriten.xml"), enc)
            With XMLobj
                .Formatting = Xml.Formatting.Indented
                .Indentation = 4

                .WriteStartDocument()
                .WriteStartElement("Favoriten") ' <Person 


                For i As Integer = 0 To MainForm.FavMoviesColl.Count - 1
                    .WriteStartElement("Ordner") ' <Person 
                    .WriteStartElement("Pfad") ' <Person 
                    .WriteValue(MainForm.FavMoviesColl(i).Pfad)
                    .WriteEndElement()
                    .WriteEndElement() 'end nam
                Next
                .WriteEndElement() 'end nam
                .Close()
            End With


        End Sub
        Public Shared Sub Load()
            If IO.File.Exists(IO.Path.Combine(SettingsPath, "Favoriten.xml")) Then

                Dim xml As XmlDocument ' Unser Document Container

                xml = New XmlDocument

                xml.Load(IO.Path.Combine(SettingsPath, "Favoriten.xml"))
                Dim XMLReader As Xml.XmlReader _
                = New Xml.XmlNodeReader(xml)

                Dim j As Integer
                Dim xmln As XmlNode

                j = xml.SelectNodes("//Ordner").Count

                If j > 0 Then
                    For x As Integer = 0 To j - 1
                        xmln = xml.SelectNodes("//Ordner").Item(x)
                        Dim cn As XmlNodeList = xmln.ChildNodes
                        If cn.Count > 0 Then
                            For y As Integer = 0 To cn.Count - 1
                                Select Case cn(y).Name
                                    Case Is = "Pfad"
                                        paths.Add(cn(y).InnerText)


                                End Select
                            Next

                        End If

                    Next
                End If

            End If
        End Sub
    End Class
    Public Class Config_Avimux
        Shared Property Avimux_pfad As String = ""

        Shared Sub Standard()
            With Settings
                .Avimux_pfad.Text = ""
            End With
        End Sub

        Shared Sub Load()
            With Settings
                .Avimux_pfad.Text = Avimux_pfad
            End With
        End Sub
        Shared Sub Save()
            With Settings
                Avimux_pfad = .Avimux_pfad.Text


            End With
        End Sub


        Public Shared Sub Load(ByVal xmln As Xml.XmlDocument)


            Avimux_pfad = If(xmln.SelectNodes("//AviMux/Pfad").Count > 0, xmln.SelectSingleNode("//AviMux/Pfad").InnerText, "")
            
        End Sub
        Public Shared Sub Save(ByVal s As XmlWriter)

            With s



                .WriteStartElement("AviMux")

                .WriteStartElement("Pfad")
                .WriteValue(Avimux_pfad)
                .WriteEndElement()

                .WriteEndElement()


            End With
        End Sub
    End Class


    'Public Shared Standard_local_Source As Savemode = Savemode.Info




    Public Shared ListViewPreview As Integer = 0





    'Public Shared TMDB_Covermodus As Integer = 1
    'Public Shared TMDB_Backdropanzahl As Integer = 5
    'Public Shared TMDB_Backdropmodus As Integer = 2
    'Public Shared mediainfo_path As String

    Dim akt_Edition As Integer = 3

    Public Shared FeldTitel, FeldOTitel, FeldSort, FeldJahr, FeldGenre As Boolean


    Public Shared noCoverOFDB As Boolean = False
    Public Shared betterGerman As Boolean = False

    Shared Property Settings_dialog_selectednode As TreeNode





    Public Shared Function toInt(ByVal Value As String, Optional ByVal def As Integer = -1) As Integer
        Dim r As Integer = def
        If Not Value = "" Then
            Try
                r = CInt(Value)

            Catch ex As Exception

            End Try
        End If
        Return r
    End Function
    Public Shared Function toBool(ByVal Value As String, Optional ByVal def As Boolean = False) As Boolean
        Dim r As Boolean = def
        If Not Value = vbNullString And Not Value = "" Then
            Try
                r = CBool(Value)

            Catch ex As Exception

            End Try
        End If
        Return r
    End Function
    Public Shared Function toDate(ByVal Value As String, ByVal def As Date) As Date
        Dim r As Date = def
        If Not Value = "" Then
            Try
                r = CDate(Value)

            Catch ex As Exception

            End Try
        End If
        Return r
    End Function

 
    Public Shared Sub LoadfromFile()
        Dim s As String = SettingsPath
        If IO.Directory.Exists(s) Then
            UserInterFace.Load()
            UserAbrufen.Loadtmdbbaseurl(False)
            Columns.Load()
            Config_Favoriten.Load()
            GenreFilter.Load()
            CostumFilter.Load()
            If IO.File.Exists(IO.Path.Combine(s, "Config.xml")) Then
                Dim xml As XmlDocument
                xml = New XmlDocument
                xml.Load(IO.Path.Combine(s, "Config.xml"))
                Config_Genre.Load(xml)
                Config_MediaCenter.Load(xml)
                Config_Laden.Load(xml)
                Config_Abrufen.Load(xml)
                Config_Update.Load(xml)
                Config_Save.Load(xml)
                Config_Fortschritt.Load(xml)
                Config_BrowserSuche.Load(xml)
                Config_Cache.Load(xml)
                Config_Avimux.Load(xml)
                Config_Trailer.Load(xml)
            Else

                'Save()
                If MsgBox("Es wird empfohlen, dass Programm vor der ersten Nutzung zu Konfigurieren.", MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                    'Settings.Laden_Ordner_suchmodus.SelectedIndex = 0
                    GenreFilter.Load()
                    CostumFilter.Load()
                    'Settings.ShowDialog()
                    'Settings.Show()
                End If
            End If
        Else

            'Save()

            If MsgBox("Es wird empfohlen, dass Programm vor der ersten Nutzung zu Konfigurieren.", MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                IO.Directory.CreateDirectory(s)
                CostumFilter.Load()
                GenreFilter.Load()
                'Settings.Show()

            End If
        End If
    End Sub
    Public Shared Sub SavetoFile()
        Dim s As String = SettingsPath
        If Not IO.Directory.Exists(s) Then
            IO.Directory.CreateDirectory(s)
        End If
        UserInterFace.Save()
        CostumFilter.Save()
        Columns.Save()
        Config_Favoriten.Save()
        GenreFilter.Save()
        Dim enc As New System.Text.UTF8Encoding
        Dim XMLobj As Xml.XmlTextWriter _
          = New Xml.XmlTextWriter(IO.Path.Combine(s, "Config.xml"), enc)
        With XMLobj
            .Formatting = Xml.Formatting.Indented
            .Indentation = 4

            .WriteStartDocument()
            .WriteStartElement("Einstellungen")
            Try
                Config_Genre.Save(XMLobj)
                Config_MediaCenter.Save(XMLobj)
                Config_Laden.Save(XMLobj)
                Config_Abrufen.Save(XMLobj)
                Config_Update.Save(XMLobj)
                Config_Save.Save(XMLobj)
                Config_Fortschritt.Save(XMLobj)
                Config_Overwrite.Save(XMLobj)
                Config_BrowserSuche.Save(XMLobj)
                Config_Cache.Save(XMLobj)
                Config_Avimux.Save(XMLobj)
                Config_Trailer.Save(XMLobj)
                .WriteEndElement() 'end name
                .Close()
            Catch ex As Exception
                .Close()
                MsgBox(ex.Message & vbCrLf & ex.StackTrace)
                IO.File.Delete(IO.Path.Combine(s, "Config.xml"))
            End Try

 


        End With
    End Sub


    Public Shared Sub Load()





        Config_Laden.Load()
        Config_MediaCenter.Load()
        Config_Abrufen.Load()
        Config_Update.Load()
        Config_Save.Load()
        Config_Fortschritt.Load()
        Config_Genre.Load()
        Config_Filter.Load()
        Config_BrowserSuche.Load()
        Config_Design.Load()
        Config_Cache.Load()
        Config_Avimux.Load()
        Config_Trailer.Load()
    End Sub
    Public Shared Sub Save()
        Config_Laden.Save()
        Config_MediaCenter.Save()
        Config_Abrufen.Save()
        Config_Update.Save()
        Config_Save.Save()
        Config_Fortschritt.Save()
        Config_Genre.Save()
        Config_Filter.Save()
        Config_BrowserSuche.Save()
        Config_Design.Save()
        Config_Cache.Save()
        Config_Avimux.Save()
        Config_Trailer.Save()
        MainForm.refresh_UI_byPlugin()
    End Sub




End Class
