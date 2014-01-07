Public Class InfoPanel_Movie
    Public Labels() As TextBox
    Property isLoaded As Boolean

    Property SelectedMovie As Movie
        Get
            Return MainForm.SelectedMovie
        End Get
        Set(ByVal value As Movie)
            MainForm.SelectedMovie = SelectedMovie
        End Set
    End Property

    Property SelectedResult As Search_Result


    Property ShowLinkBar As Boolean
        Get
            Return Vert_Links.Visible
        End Get
        Set(ByVal value As Boolean)
            Vert_Links.Visible = value
            If value = True Then
                ToolStripButton17.Image = Toolbar16.lightbutton1
            Else
                ToolStripButton17.Image = Toolbar16.lightbutton2
            End If
        End Set
    End Property


    Private Sub MoviemazeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            OpenWebLink("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)

            'Process.Start("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)

        Catch ex As Exception

        End Try
    End Sub

#Region "TabControl"
    Private Sub InfoTabs3_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InfoTabs3.DragOver
        Dim p As Point = InfoTabs3.PointToClient(MousePosition)
        e.Effect = DragDropEffects.Link
        For n As Integer = 0 To InfoTabs3.TabCount - 1
            Dim rc As Rectangle = InfoTabs3.GetTabRect(n)
            If rc.Contains(p) Then
                If Not n = 4 Then
                    InfoTabs3.SelectedIndex = n
                Else
                    MyFunctions.SetHandCursor()

                End If

                Exit For
            End If
        Next
    End Sub

    Private Sub InfoTabs3_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles InfoTabs3.Selecting
        If e.TabPageIndex = 4 Then
            blättern = Not blättern
            If blättern = True Then
                TabPage1.Text = "An"
            Else
                TabPage1.Text = "Aus"
            End If
            e.Cancel = True
        End If
    End Sub
    Dim blättern As Boolean = False
    Private Sub InfoTabs3_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoTabs3.MouseMove
        If blättern = True Or e.Button = Windows.Forms.MouseButtons.Left Then
            Dim p As Point = InfoTabs3.PointToClient(MousePosition)

            For n As Integer = 0 To InfoTabs3.TabCount - 1
                Dim rc As Rectangle = InfoTabs3.GetTabRect(n)
                If rc.Contains(p) Then
                    If Not n = 4 Then
                        InfoTabs3.SelectedIndex = n
                    Else
                        MyFunctions.SetHandCursor()

                    End If

                    Exit For
                End If
            Next
        Else
            Dim p As Point = InfoTabs3.PointToClient(MousePosition)
            Dim rc As Rectangle = InfoTabs3.GetTabRect(4)
            If rc.Contains(p) Then
                'If Me.Cursor = 

                MyFunctions.SetHandCursor()
            End If
            'For n As Integer = 0 To InfoTabs3.TabCount - 1
            '    Dim rc As Rectangle = InfoTabs3.GetTabRect(n)
            '    If rc.Contains(p) Then
            '        If Not n = 4 Then
            '            'InfoTabs3.SelectedIndex = n
            '        Else


            '        End If

            '        Exit For
            '    End If
            'Next
        End If
    End Sub

#End Region

#Region "Text_Change"
    Private Sub TB_Set_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_set.TextChanged
        If Not IsNothing(TB_set.Tag) Then
            If TB_set.Text = "" Then
                Table_Set.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_set.Text = TB_set.Tag.ToString Then
                Table_Set.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Set.BackgroundImage = Nothing
            End If
        End If
        'exp_speichern.Visible = Panel_info_changed()
    End Sub
    Private Sub TB_Titel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Titel.TextChanged
        If Not IsNothing(TB_Titel.Tag) Then
            If TB_Titel.Text = "" Then
                Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Titel.Text = TB_Titel.Tag.ToString Then
                Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Titel.BackgroundImage = Nothing
            End If
        End If
        'exp_speichern.Visible = Panel_info_changed()
    End Sub
    Private Sub TB_Originaltitel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Originaltitel.TextChanged
        If Not IsNothing(TB_Originaltitel.Tag) Then
            If TB_Originaltitel.Text = "" Then
                Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Originaltitel.Text = TB_Originaltitel.Tag.ToString Then
                Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Originaltitel.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_IMDB_ID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_IMDB_ID.TextChanged
        If Not IsNothing(TB_IMDB_ID.Tag) Then
            If TB_IMDB_ID.Text = "" Then
                Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_IMDB_ID.Text = TB_IMDB_ID.Tag.ToString Then
                Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_IMDB_ID.BackgroundImage = Nothing
            End If
        End If
    End Sub
    'Private Sub TB_Darsteller_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Darsteller.TextChanged
    '    If Not IsNothing(TB_Darsteller.Tag) Then
    '        If TB_Darsteller.Text = "" Then
    '            Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        ElseIf Not TB_Darsteller.Text = TB_Darsteller.Tag.ToString Then
    '            Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
    '        Else
    '            Table_Darsteller.BackgroundImage = Nothing
    '        End If
    '    End If
    'End Sub
    Private Sub TB_Regisseur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Regisseur.TextChanged
        If Not IsNothing(TB_Regisseur.Tag) Then
            If TB_Regisseur.Text = "" Then
                Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Regisseur.Text = TB_Regisseur.Tag.ToString Then
                Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Regisseur.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Autoren_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Autoren.TextChanged
        If Not IsNothing(TB_Autoren.Tag) Then
            If TB_Autoren.Text = "" Then
                Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Autoren.Text = TB_Autoren.Tag.ToString Then
                Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Autoren.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Studios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Studios.TextChanged
        If Not IsNothing(TB_Studios.Tag) Then
            If TB_Studios.Text = "" Then
                Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Studios.Text = TB_Studios.Tag.ToString Then
                Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Studios.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Produktionsjahr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produktionsjahr.TextChanged
        If Not IsNothing(TB_Produktionsjahr.Tag) Then
            If TB_Produktionsjahr.Text = "" Then
                Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Produktionsjahr.Text = TB_Produktionsjahr.Tag.ToString Then
                Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Produktionsjahr.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Produktionsland_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produktionsland.TextChanged
        If Not IsNothing(TB_Produktionsland.Tag) Then
            If TB_Produktionsland.Text = "" Then
                Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Produktionsland.Text = TB_Produktionsland.Tag.ToString Then
                Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Produktionsland.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Genre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Genre.TextChanged
        If Not IsNothing(TB_Genre.Tag) Then
            If TB_Genre.Text = "" Then
                Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Genre.Text = TB_Genre.Tag.ToString Then
                Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Genre.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_FSK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSK_Combobox.SelectedIndexChanged
        If Not IsNothing(FSK_Combobox.Tag) Then
            If FSK_Combobox.Text = "" Then
                Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not FSK_Combobox.Text = FSK_Combobox.Tag.ToString Then
                Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_FSK.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Bewertung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Bewertung.TextChanged
        If Not IsNothing(TB_Bewertung.Tag) Then
            If TB_Bewertung.Text = "" Then
                Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Bewertung.Text = TB_Bewertung.Tag.ToString Then
                Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Bewertung.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Spieldauer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Spieldauer.TextChanged
        If Not IsNothing(TB_Spieldauer.Tag) Then
            If TB_Spieldauer.Text = "" Then
                Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Spieldauer.Text = TB_Spieldauer.Tag.ToString Then
                Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Spieldauer.BackgroundImage = Nothing
            End If
        End If
    End Sub
    'Private Sub TB_Kurzbeschreibung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Kurzbeschreibung.TextChanged
    '    If Not IsNothing(TB_Kurzbeschreibung.Tag) Then
    '        If TB_Kurzbeschreibung.Text = "" Then
    '            Table_Kurzbeschreibung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        ElseIf Not TB_Kurzbeschreibung.Text = TB_Kurzbeschreibung.Tag.ToString Then
    '            Table_Kurzbeschreibung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
    '        Else
    '            Table_Kurzbeschreibung.BackgroundImage = Nothing
    '        End If
    '    End If
    'End Sub
    'Private Sub TB_Inhalt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Inhalt.TextChanged
    '    If Not IsNothing(TB_Inhalt.Tag) Then
    '        If TB_Inhalt.Text = "" Then
    '            Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        ElseIf Not TB_Inhalt.Text = TB_Inhalt.Tag.ToString Then
    '            Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
    '        Else
    '            Table_Inhalt.BackgroundImage = Nothing
    '        End If
    '    End If
    'End Sub
    Private Sub TB_Sort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Sort.TextChanged
        If Not IsNothing(TB_Sort.Tag) Then
            If TB_Sort.Text = "" Then
                Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Sort.Text = TB_Sort.Tag.ToString Then
                Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Sort.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoAuflösung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoAuflösung.TextChanged
        If Not IsNothing(TB_VideoAuflösung.Tag) Then
            If TB_VideoAuflösung.Text = "" Then
                Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoAuflösung.Text = TB_VideoAuflösung.Tag.ToString Then
                Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoAuflösung.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoSeitenverhältnis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoSeitenverhältnis.TextChanged
        If Not IsNothing(TB_VideoSeitenverhältnis.Tag) Then
            If TB_VideoSeitenverhältnis.Text = "" Then
                Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoSeitenverhältnis.Text = TB_VideoSeitenverhältnis.Tag.ToString Then
                Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoSeitenverhältnis.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoBildwiederholungsrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoBildwiederholungsrate.TextChanged
        If Not IsNothing(TB_VideoBildwiederholungsrate.Tag) Then
            If TB_VideoBildwiederholungsrate.Text = "" Then
                Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoBildwiederholungsrate.Text = TB_VideoBildwiederholungsrate.Tag.ToString Then
                Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoBildwiederholungsrate.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoCodec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoCodec.TextChanged
        If Not IsNothing(TB_VideoCodec.Tag) Then
            If TB_VideoCodec.Text = "" Then
                Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoCodec.Text = TB_VideoCodec.Tag.ToString Then
                Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoCodec.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioKanäle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioKanäle.TextChanged
        If Not IsNothing(TB_AudioKanäle.Tag) Then
            If TB_AudioKanäle.Text = "" Then
                Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioKanäle.Text = TB_AudioKanäle.Tag.ToString Then
                Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioKanäle.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioCodec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioCodec.TextChanged
        If Not IsNothing(TB_AudioCodec.Tag) Then
            If TB_AudioCodec.Text = "" Then
                Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioCodec.Text = TB_AudioCodec.Tag.ToString Then
                Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioCodec.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioSprachen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioSprachen.TextChanged
        If Not IsNothing(TB_AudioSprachen.Tag) Then
            If TB_AudioSprachen.Text = "" Then
                Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioSprachen.Text = TB_AudioSprachen.Tag.ToString Then
                Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioSprachen.BackgroundImage = Nothing
            End If
        End If
    End Sub

#End Region

#Region "Drag&Drop Textbox"
    Private Sub Textboxes_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragEnter, TB_Studios.DragEnter, TB_Spieldauer.DragEnter, TB_Sort.DragEnter, TB_Regisseur.DragEnter, TB_Originaltitel.DragEnter, TB_Produktionsland.DragEnter, TB_Produktionsjahr.DragEnter, TB_IMDB_ID.DragEnter, TB_Genre.DragEnter, TB_Bewertung.DragEnter, TB_Autoren.DragEnter, TB_VideoCodec.DragEnter, TB_AudioSprachen.DragEnter, TB_VideoSeitenverhältnis.DragEnter, TB_Inhalt.DragEnter, TB_VideoBildwiederholungsrate.DragEnter, TB_VideoAuflösung.DragEnter, TB_AudioCodec.DragEnter, TB_AudioKanäle.DragEnter, InfoTabs3.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Textboxes_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragOver, TB_Studios.DragOver, TB_Spieldauer.DragOver, TB_Sort.DragOver, TB_Regisseur.DragOver, TB_Originaltitel.DragOver, TB_Produktionsland.DragOver, TB_Produktionsjahr.DragOver, TB_IMDB_ID.DragOver, TB_Genre.DragOver, TB_Bewertung.DragOver, TB_Autoren.DragOver, TB_VideoCodec.DragOver, TB_AudioSprachen.DragOver, TB_VideoSeitenverhältnis.DragOver, TB_Inhalt.DragOver, TB_VideoBildwiederholungsrate.DragOver, TB_VideoAuflösung.DragOver, TB_AudioCodec.DragOver, TB_AudioKanäle.DragOver, InfoTabs3.DragOver
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub TB_Titel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragDrop
        If isLoaded Then
            TB_Titel.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Originaltitel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Originaltitel.DragDrop
        If isLoaded Then
            TB_Originaltitel.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_IMDB_ID_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_IMDB_ID.DragDrop
        If isLoaded Then
            TB_IMDB_ID.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Regisseur_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Regisseur.DragDrop
        If isLoaded Then
            TB_Regisseur.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Autoren_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Autoren.DragDrop
        If isLoaded Then
            TB_Autoren.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Studios_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Studios.DragDrop
        If isLoaded Then
            TB_Studios.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Produktionsjahr_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Produktionsjahr.DragDrop
        If isLoaded Then
            TB_Produktionsjahr.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Produktionsland_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Produktionsland.DragDrop
        If isLoaded Then
            TB_Produktionsland.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Genre_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Genre.DragDrop
        If isLoaded Then
            TB_Genre.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Bewertung_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Bewertung.DragDrop
        If isLoaded Then
            TB_Bewertung.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Spieldauer_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Spieldauer.DragDrop
        If isLoaded Then
            TB_Spieldauer.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Inhalt_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Inhalt.DragDrop
        If isLoaded Then
            TB_Inhalt.Text = CStr(e.Data.GetData(DataFormats.Text).ToString)
        End If
    End Sub
    Private Sub TB_Sort_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Sort.DragDrop
        If isLoaded Then
            TB_Sort.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoAuflösung_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoAuflösung.DragDrop
        If isLoaded Then
            TB_VideoAuflösung.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoSeitenverhältnis_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoSeitenverhältnis.DragDrop
        If isLoaded Then
            TB_VideoSeitenverhältnis.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoBildwiederholungsrate_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoBildwiederholungsrate.DragDrop
        If isLoaded Then
            TB_VideoBildwiederholungsrate.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoCodec_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoCodec.DragDrop
        If isLoaded Then
            TB_VideoCodec.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioKanäle_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioKanäle.DragDrop
        If isLoaded Then
            TB_AudioKanäle.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioCodec_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioCodec.DragDrop
        If isLoaded Then
            TB_AudioCodec.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioSprachen_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioSprachen.DragDrop
        If isLoaded Then
            TB_AudioSprachen.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub


#End Region

#Region "ContextMenu Textbox"



    Private Sub TB_Titel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Titel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Titel
        End If
    End Sub
    Private Sub TB_Originaltitel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Originaltitel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Originaltitel
        End If
    End Sub
    Private Sub TB_IMDB_ID_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_IMDB_ID.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_IMDB_ID
        End If
    End Sub
    'Private Sub TB_Darsteller_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Darsteller.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        ContextMenu_TextBox.Tag = TB_Darsteller
    '    End If
    'End Sub
    Private Sub TB_Regisseur_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Regisseur.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Regisseur
        End If
    End Sub
    Private Sub TB_Autoren_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Autoren.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Autoren
        End If
    End Sub
    Private Sub TB_Studios_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Studios.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Studios
        End If
    End Sub
    Private Sub TB_Produktionsjahr_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Produktionsjahr.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Produktionsjahr
        End If
    End Sub
    Private Sub TB_Produktionsland_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Produktionsland.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Produktionsland
        End If
    End Sub
    Private Sub TB_Genre_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Genre.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Genre
        End If
    End Sub
    'Private Sub TB_FSK_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_FSK.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        ContextMenu_TextBox.Tag = TB_FSK
    '    End If
    'End Sub
    Private Sub TB_Bewertung_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Bewertung.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Bewertung
        End If
    End Sub
    Private Sub TB_Spieldauer_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Spieldauer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Spieldauer
        End If
    End Sub
    Private Sub TB_Inhalt_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Inhalt.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Inhalt
        End If
    End Sub
    Private Sub TB_Sort_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Sort.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Sort
        End If
    End Sub


    Private Sub RückgäningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RückgäningToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Undo()
        End If
    End Sub

    Private Sub KopierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Copy()
        End If
    End Sub
    Private Sub EinfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinfügenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Paste()
        End If
    End Sub
    Private Sub AusschneidenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusschneidenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Cut()
        End If
    End Sub

    Private Sub FSKHomepageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSKHomepageToolStripMenuItem.Click
        If isLoaded Then

            '    '  myBrowser.Navigate("http://www.spio.de/index.asp?SeitID=70&txtFilmtitel=" & TB_Titel.Text & "&selFilmart=ALLE&Sort=az&pagenum=1&pnum=11573a%28VV%29&lineindex=1&VVID=101468")
            OpenWebLink(" http://www.spio.de/index.asp?SeitID=491&TID=70&search=search&txtFilmtitel=" & TB_Titel.Text)
        End If
    End Sub
    Private Sub SuchenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuchenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then

            '    '  myBrowser.Navigate("http://www.spio.de/index.asp?SeitID=70&txtFilmtitel=" & TB_Titel.Text & "&selFilmart=ALLE&Sort=az&pagenum=1&pnum=11573a%28VV%29&lineindex=1&VVID=101468")
            OpenWebLink("http://www.google.de/#hl=de&source=hp&q=" & TB_Titel.Text & " " & m.Name.Replace("TB_", "") & "&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=&fp=ebbd8e4827c4c9bc")
        End If
    End Sub
    Private Sub GoogleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleToolStripMenuItem1.Click

        Try

            OpenWebLink("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Produktionsjahr.Text & "&btnG=Suche&aq=f&oq=&start=0")
            'Process.Start("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Jahr.Text & "&btnG=Suche&aq=f&oq=&start=0")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SuchenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuchenToolStripMenuItem1.Click

        Try

            OpenWebLink("http://www.google.de/#hl=de&source=hp&q=" & TB_Titel.Text & " " & "FSK" & "&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=&fp=ebbd8e4827c4c9bc")
            'Process.Start("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Jahr.Text & "&btnG=Suche&aq=f&oq=&start=0")

        Catch ex As Exception

        End Try
    End Sub
#End Region
    ''' <summary>
    ''' Zeichnen eines Rechtecks um die selektierte Zeile eines Datagridview
    ''' </summary>
    ''' <param name="theDGV">das DatagridView</param>
    ''' <param name="lineWidth">die Linienstärke</param>
    ''' <param name="lineColor">die Linienfarbe</param>
    ''' <param name="e">DataGridViewRowPostPaintEventArgs des RowPostPaint-Ereignisses</param>
    Public Sub drawRectOnDGV(ByVal theDGV As DataGridView, _
      ByVal lineWidth As Short, _
      ByVal lineColor As Color, _
      ByVal e As DataGridViewRowPostPaintEventArgs)

        ' Anwenden im RowPostPaint-Ereignis des betreffenden Datagridview
        Dim rect As Rectangle
        With theDGV
            If .Rows(e.RowIndex).Selected Then  ' ist die Zeile selektiert?
                rect = .GetRowDisplayRectangle(e.RowIndex, False) ' das Rechteck der aktuellen Zeile
                ' Rechteck für den Rahmen erzeugen
                Dim rec As Rectangle = New Rectangle(rect.X, rect.Y, _
                calcDGVWidth(theDGV) - 1, rect.Height)
                ' Zeichnen des Rahmens
                ControlPaint.DrawBorder(e.Graphics, rec, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid)
            End If
        End With
    End Sub
    ''' <summary>
    ''' Berechnen der aktuellen Breite eines Datagridview 
    ''' </summary>
    ''' <param name="theDGV">das DatagridView</param>
    ''' <returns>Breite des DatagridView</returns>
    Public Function calcDGVWidth(ByVal theDGV As DataGridView) As Integer
        Dim theWidth As Integer
        With theDGV
            For Each c As DataGridViewColumn In .Columns
                If c.Visible = True Then theWidth += c.Width ' nur sichtbare Spaltenbreiten addieren
            Next
            If .RowHeadersVisible Then theWidth += .RowHeadersWidth
            If .Controls(1).Visible Then    ' ist die vertikale Scrollbar aktuell sichtbar?
                'theWidth -= SystemInformation.VerticalScrollBarWidth  ' Breite der Scrollbar
            End If
        End With
        Return theWidth
    End Function


    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, _
ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DarstellerView.RowPostPaint

        drawRectOnDGV(DarstellerView, 1, Color.FromArgb(2, 135, 197), e)
    End Sub
    Private Sub LöschenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem1.Click
        If Not IsNothing(SelectedMovie) Then


            If MsgBox("Möchten Sie das ausgewählte Bild wirklich löschen?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                If BackdropSB.Value = 0 Then
                    If IO.File.Exists(SelectedMovie.Cover) Then
                        Try
                            IO.File.Delete(SelectedMovie.Cover)
                            SelectedMovie.Cover = ""
                            SelectedMovie.Cover_height = 0
                            SelectedMovie.Cover_width = 0
                            PictureBox1.Image = My.Resources.no_cover_bg
                            SelectedMovie.Refresh()

                        Catch ex As Exception

                        End Try
                    End If
                Else
                    IO.File.Exists(SelectedMovie.Backdrops(BackdropSB.Value - 1))
                    Try
                        IO.File.Delete(SelectedMovie.Backdrops(BackdropSB.Value - 1))
                    Catch ex As Exception

                    End Try


                    SelectedMovie.Backdrops = MyFunctions.Backdropsarr(SelectedMovie.Pfad)
                    If SelectedMovie.Backdrops.Length > 0 Then
                        BackdropSB.Value = 0

                        BackdropSB.Visible = True
                        BackdropSB.Maximum = SelectedMovie.Backdrops.Length
                    Else
                        BackdropSB.Visible = False
                    End If

                    If IO.File.Exists(SelectedMovie.Cover) Then
                        Try

                            Dim oStream As New System.IO.FileStream(SelectedMovie.Cover, IO.FileMode.Open)
                            PictureBox1.Image = New Bitmap(oStream)


                            oStream.Close()

                            SelectedMovie.Cover_height = PictureBox1.Image.Size.Height
                            SelectedMovie.Cover_width = PictureBox1.Image.Size.Width
                            Cover_Size.Text = PictureBox1.Image.Size.Height & "x" & PictureBox1.Image.Size.Width
                            Cover_Size.Tag = PictureBox1.Image.Size.Height & "x" & PictureBox1.Image.Size.Width
                            Cover_Name.Text = "Cover"

                        Catch ex As Exception

                        End Try
                    Else
                        PictureBox1.Image = My.Resources.no_cover_bg
                    End If
                    SelectedMovie.Refresh()
                End If
            End If
        End If
    End Sub

#Region "Filelist"
    Private Sub ÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Try
            Process.Start(CStr(File_Listview.SelectedItems(0).Tag))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem.Click
        If File_Listview.SelectedItems.Count > 0 Then
            If MsgBox("Möchten Sie die ausgewählten Dateien wirklich löschen?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                For x As Integer = 0 To File_Listview.SelectedItems.Count - 1
                    Try
                        IO.File.Delete(CStr(File_Listview.SelectedItems(x).Tag))
                    Catch ex As Exception

                    End Try
                Next
                RefreshFolderPrev(TB_Pfad.Text)
            End If

        End If
    End Sub
    Private Sub File_Listview_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles File_Listview.DragEnter
        Me.Focus()

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim p As Point = File_Listview.PointToClient(MousePosition)
            Dim m As ListViewHitTestInfo = File_Listview.HitTest(p.X, p.Y)
            If Not m.Item Is Nothing Then
                If IO.Directory.Exists(CStr(m.Item.Tag)) Then
                    For Each it As ListViewItem In File_Listview.SelectedItems
                        it.Selected = False
                    Next
                    m.Item.Selected = True
                End If
            End If

            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())

            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.Copy
            End If


        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub File_Listview_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles File_Listview.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim p As Point = File_Listview.PointToClient(MousePosition)
            Dim m As ListViewHitTestInfo = File_Listview.HitTest(p.X, p.Y)

            If Not m.Item Is Nothing Then
                If IO.Directory.Exists(CStr(m.Item.Tag)) Then

                    m.Item.Selected = True
                    For Each it As ListViewItem In File_Listview.SelectedItems
                        If Not it Is m.Item Then
                            it.Selected = False
                        End If

                    Next
                End If
            Else
                For Each it As ListViewItem In File_Listview.SelectedItems
                    it.Selected = False
                Next
            End If

            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If e.KeyState = 9 Then
                e.Effect = DragDropEffects.Move
            Else
                e.Effect = DragDropEffects.Copy
            End If
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub File_Listview_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles File_Listview.DragDrop
        If Not SelectedMovie Is Nothing Then
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                Dim filePaths() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

                Dim des As String = SelectedMovie.Pfad
                Dim p As Point = File_Listview.PointToClient(MousePosition)
                Dim m As ListViewHitTestInfo = File_Listview.HitTest(p.X, p.Y)
                If Not m.Item Is Nothing Then
                    If IO.Directory.Exists(CStr(m.Item.Tag)) Then
                        des = CStr(m.Item.Tag)
                    End If
                End If

                If e.KeyState <> 8 Then
                    Dim myp As New Progress_FileCopy(filePaths, des)
                    myp.Run()
                Else
                    Dim myp As New Progress_FileMove(filePaths, des)
                    myp.Run()
                End If
                RefreshFolderPrev(SelectedMovie.Pfad)
            End If
        End If

    End Sub

    Private Sub ListViewVista1_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles File_Listview.ItemActivate
        Try
            Process.Start(CStr(File_Listview.SelectedItems(0).Tag))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InfoTabs3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles File_Listview.MouseDown
        If Not SelectedMovie Is Nothing Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Dim p As Point = File_Listview.PointToClient(MousePosition)
                Dim m As ListViewHitTestInfo = File_Listview.HitTest(p.X, p.Y)

                If Not m.Item Is Nothing Then
                    If m.Item.Selected = False Then
                        For Each it As ListViewItem In File_Listview.SelectedItems
                            it.Selected = False
                        Next
                        m.Item.Selected = True
                    End If
                    Dim ctxMnu As New Peter.ShellContextMenu()
                    Dim liFI As New List(Of IO.FileInfo)
                    'Dim arrFI As IO.FileInfo() = New IO.FileInfo(File_Listview.SelectedItems.Count) {}
                    For Each it As ListViewItem In File_Listview.SelectedItems
                        liFI.Add(New IO.FileInfo(CStr(it.Tag)))
                    Next
                    'arrFI(0) = New IO.FileInfo(CStr(m.Item.Tag))
                    Try
                        ctxMnu.ShowContextMenu(liFI.ToArray, MousePosition)
                    Catch ex As Exception

                    End Try

                Else
                    Dim ctxMnu As New Peter.ShellContextMenu()
                    Dim arrFI As IO.FileInfo() = New IO.FileInfo(0) {}

                    arrFI(0) = New IO.FileInfo(CStr(SelectedMovie.Pfad))
                    Try
                        ctxMnu.ShowContextMenu(arrFI, MousePosition)
                    Catch ex As Exception

                    End Try


                End If
                RefreshFolderPrev(SelectedMovie.Pfad)
            End If
        Else
            File_Listview.Items.Clear()
        End If



    End Sub
    Private Sub File_Listview_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles File_Listview.ItemDrag
        If Not SelectedMovie Is Nothing Then
            Dim DTO = New DataObject

            Dim l As New System.Collections.Specialized.StringCollection
            For Each it As ListViewItem In File_Listview.SelectedItems
                l.Add(CStr(it.Tag))
            Next
            DTO.SetFileDropList(l)
            DoDragDrop(DTO, DragDropEffects.All)
            RefreshFolderPrev(SelectedMovie.Pfad)
        Else
            File_Listview.Items.Clear()
        End If
    End Sub


#End Region

#Region "Toolbar"
    Private Sub ToolStripButton3_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.DropDownOpening
        ToolStripButton3.DropDownItems.Clear()

        Dim l As ToolStripLabel
        Dim r As ToolStripMenuItem
        If Not SelectedMovie Is Nothing Then
            If Not SelectedMovie.State_Cover = 2 Then
                r = New ToolStripMenuItem
                r.Text = SelectedMovie.State_Cover_text
                r.Image = Toolbar16.staty_16_cover_test
                ToolStripButton3.DropDownItems.Add(r)
                For Each x In SelectedMovie.State_Cover_tip
                    l = New ToolStripLabel
                    l.Text = x
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton3.DropDownItems.Add(l)
                Next
            End If
            If Not SelectedMovie.State_Backdrop = 2 Then
                r = New ToolStripMenuItem
                r.Text = SelectedMovie.State_Backdrop_text
                r.Image = Toolbar16.staty_16_fanart
                ToolStripButton3.DropDownItems.Add(r)
                For Each x In SelectedMovie.State_Backdrop_tip
                    l = New ToolStripLabel
                    l.Text = x
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton3.DropDownItems.Add(l)
                Next
            End If
            If Not SelectedMovie.State_Info = 2 Then
                r = New ToolStripMenuItem
                r.Text = SelectedMovie.State_Info_text
                r.Image = Toolbar16.staty_16_info
                ToolStripButton3.DropDownItems.Add(r)
                For Each x In SelectedMovie.State_Info_tip
                    l = New ToolStripLabel
                    l.Text = x
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton3.DropDownItems.Add(l)
                Next
            End If
            If Not SelectedMovie.State_MediaInfo = 2 Then
                r = New ToolStripMenuItem
                r.Text = SelectedMovie.State_MediaInfo_text
                r.Image = Toolbar16.staty_16_mediainfo
                ToolStripButton3.DropDownItems.Add(r)
                For Each x In SelectedMovie.State_MediaInfo_tip
                    l = New ToolStripLabel
                    l.Text = x
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton3.DropDownItems.Add(l)
                Next
            End If
            If Not SelectedMovie.State_Ordner = 2 Then
                r = New ToolStripMenuItem
                r.Text = SelectedMovie.State_Ordner_text
                r.Image = Toolbar16.Normal_hinzufuegen
                ToolStripButton3.DropDownItems.Add(r)
                For Each x In SelectedMovie.State_Ordner_tip
                    l = New ToolStripLabel
                    l.Text = x
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton3.DropDownItems.Add(l)
                Next
            End If
        End If



    End Sub



    Private Sub ToolStripButton_Rückgängig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Rückgängig.Click
        Load_item(SelectedMovie)
    End Sub
    Private Sub InfoslöschenToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoslöschenToolStripButton3.Click
        If MainForm.cancel_DG_selection = False Then
            'BackdropSB.Visible = False
            'SelectedMovie = Nothing
            'SelectedResult = Nothing
            'PictureBox1.Image.Dispose()
            'PictureBox1.Image = My.Resources.no_cover_bg
            DarstellerView.Rows.Clear()
            'lbl_selectedmovie.Text = 
            FSK_Combobox.Text = ""

            For x As Integer = 0 To 23
                Labels(x).Text = ""
                Labels(x).Tag = ""
            Next
            TB_Produktionsjahr.Text = FileNameFilter.GetYearinFolderName(SelectedMovie.Ordner)
            TB_Titel.Text = FileNameFilter.ReplaceFolderName(SelectedMovie.Ordner)
            TB_Ordner.Text = SelectedMovie.Ordner
            TB_Originaltitel.Text = TB_Titel.Text
            TB_Sort.Text = TB_Titel.Text
            TB_Pfad.Text = SelectedMovie.Pfad
            TB_Videoheightwidth.Text = ""
            'Reset_tableColors()
            Count_Darsteller.Text = ""
            MainForm.Panel_flagquestion.Visible = False
            MainForm.MyBrowserHelpbar.Visible = False
        End If
    End Sub
    Private Sub ToolStripButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton18.Click

        If ToolStripButton18.Tag.ToString = "0" Then
            ToolStripButton18.Image = Toolbar16.watched_yes
            ToolStripButton18.Tag = 1
            For Each i In MainForm.GetselectedMovies()
                i.Gesehen = "True"
                i.Datum = CStr(Today.Date)
                i.Refresh()
            Next


        Else
            ToolStripButton18.Image = Toolbar16.watched_no
            ToolStripButton18.Tag = 0
            For Each i In MainForm.GetselectedMovies()
                i.Gesehen = "False"
                i.Datum = ""
                i.Refresh()
            Next
        End If

    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Ergebnisbearbeiten.Click
        If Not IsNothing(MainForm.SelectedResult) And Not IsNothing(SelectedMovie) Then
            Dim d As New Dialog_Online_Save
            d.m = SelectedMovie
            d.r = MainForm.SelectedResult
            If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                With d
                    If .Offline_Titel.Checked = True Then
                        TB_Titel.Text = .Offline_Titel.t
                    Else
                        TB_Titel.Text = .Online_Titel.t
                    End If
                    If .Offline_Originaltitel.Checked = True Then
                        TB_Originaltitel.Text = .Offline_Originaltitel.t
                    Else
                        TB_Originaltitel.Text = .Online_Originaltitel.t
                    End If
                    If .Offline_IMDB_ID.Checked = True Then
                        TB_IMDB_ID.Text = .Offline_IMDB_ID.t
                    Else
                        TB_IMDB_ID.Text = .Online_IMDB_ID.t
                    End If

                    If .Offline_Regisseur.Checked = True Then
                        TB_Regisseur.Text = .Offline_Regisseur.t
                    Else
                        TB_Regisseur.Text = .Online_Regisseur.t
                    End If
                    If .Offline_Autoren.Checked = True Then
                        TB_Autoren.Text = .Offline_Autoren.t
                    Else
                        TB_Autoren.Text = .Online_Autoren.t
                    End If
                    If .Offline_Studios.Checked = True Then
                        TB_Studios.Text = .Offline_Studios.t
                    Else
                        TB_Studios.Text = .Online_Studios.t
                    End If
                    If .Offline_Produktionsjahr.Checked = True Then
                        TB_Produktionsjahr.Text = .Offline_Produktionsjahr.t
                    Else
                        TB_Produktionsjahr.Text = .Online_Produktionsjahr.t
                    End If
                    If .Offline_Produktionsland.Checked = True Then
                        TB_Produktionsland.Text = .Offline_Produktionsland.t
                    Else
                        TB_Produktionsland.Text = .Online_Produktionsland.t
                    End If
                    If .Offline_Genre.Checked = True Then
                        TB_Genre.Text = .Offline_Genre.t
                    Else
                        TB_Genre.Text = .Online_Genre.t
                    End If

                    If .Offline_Bewertung.Checked = True Then
                        TB_Bewertung.Text = .Offline_Bewertung.t
                    Else
                        TB_Bewertung.Text = .Online_Bewertung.t
                    End If
                    If .Offline_Inhalt.Checked = True Then
                        TB_Inhalt.Text = .Offline_Inhalt.t
                    Else
                        TB_Inhalt.Text = .Online_Inhalt.t
                    End If
                    If .Offline_Sort.Checked = True Then
                        TB_Sort.Text = .Offline_Sort.t
                    Else
                        TB_Sort.Text = .Online_Sort.t
                    End If


                    Dim fsk As String = ""
                    If .Offline_FSK.Checked = True Then
                        fsk = .Offline_FSK.t
                    Else
                        fsk = .Online_FSK.t
                    End If
                    If Not fsk = "" Then
                        With fsk.ToString
                            If .Contains("18") Then
                                FSK_Combobox.Text = "18"

                            ElseIf .Contains("16") Then
                                FSK_Combobox.Text = "16"

                            ElseIf .Contains("12") Then
                                FSK_Combobox.Text = "12"

                            ElseIf .Contains("6") Then
                                FSK_Combobox.Text = "6"

                            ElseIf .Contains("0") Then
                                FSK_Combobox.Text = "0"

                            Else
                                FSK_Combobox.Text = ""


                            End If

                        End With
                    Else
                        FSK_Combobox.Text = ""

                    End If

                    Dim Darstellers As String = ""
                    If .Offline_Darsteller.Checked = True Then
                        Darstellers = .Offline_Darsteller.t
                    Else
                        Darstellers = .Online_Darsteller.t
                    End If
                    DarstellerView.Rows.Clear()
                    'TB_Darsteller.Text = Daten.arr(5, iarr)
                    If Not Darstellers = "" Then
                        Dim Darsteller() As String = Darstellers.Split(CChar(","))
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
                                DarstellerView.Rows.Add(DSname_S, DSrole_S)
                            Next
                        End If
                    End If




                End With




            End If


        End If
    End Sub

    Private Sub SicherungErstellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SicherungErstellenToolStripMenuItem.Click
        If isLoaded Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(True)
            Load_item(SelectedMovie)
            XMLModule.Backup_Save(SelectedMovie)
            SicherungLöschenToolStripMenuItem.Enabled = True
            WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & XMLModule.Backup_Date(SelectedMovie.Pfad).ToShortDateString & ")"
            WiederherstellenToolStripMenuItem.Enabled = True
            ToolStripButton22.Image = Toolbar16.securenormal
        End If


    End Sub

    Private Sub WiederherstellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WiederherstellenToolStripMenuItem.Click
        If isLoaded Then
            Dim m As New Movie With {.Pfad = SelectedMovie.Pfad}

            XMLModule.Backup_Load(m)
            SelectedMovie.flag = 0
            'SelectedMovie.Save(True)
            backup_to_Panel(m)
            ToolStripButton22.Image = Toolbar16.securenormal
        End If
    End Sub

    Private Sub SicherungLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SicherungLöschenToolStripMenuItem.Click
        If isLoaded Then
            If MsgBox("Möchten Sie die gesicherten Daten wirklich (endgültig) entfernen?", MsgBoxStyle.YesNoCancel, "Sicherung löschen?") = MsgBoxResult.Yes Then
                XMLModule.Backup_Delet(SelectedMovie.Pfad)
                SicherungLöschenToolStripMenuItem.Enabled = False
                WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
                WiederherstellenToolStripMenuItem.Enabled = False
                ToolStripButton22.Image = Toolbar16.securegray
            End If

        End If
    End Sub
    Private Sub Cover_Size_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cover_Size.Click
        If Not SelectedMovie Is Nothing Then


            If CStr(Cover_Size.Tag) = "Size" Then
                If BackdropSB.Value = 0 Then
                    If IO.File.Exists(SelectedMovie.Cover) Then
                        Cover_Size.Text = WebFunctions.FormatBytes(SelectedMovie.Coversize)
                    Else
                        Cover_Size.Text = ""

                    End If
                Else
                    Cover_Size.Text = WebFunctions.FormatBytes(FileLen(SelectedMovie.Backdrops(BackdropSB.Value - 1).ToString))
                End If
                Cover_Size.Tag = "Lenght"
            Else
                Cover_Size.Text = PictureBox1.Image.Size.Height & "x" & PictureBox1.Image.Size.Width
                Cover_Size.Tag = "Size"
            End If
        End If
    End Sub
    Private Sub ToolStripButton17_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton17.Click
        Vert_Links.Visible = Not Vert_Links.Visible
        If Vert_Links.Visible = True Then
            ToolStripButton17.Image = Toolbar16.lightbutton1
        Else
            ToolStripButton17.Image = Toolbar16.lightbutton2
        End If
    End Sub
#End Region
#Region "Websuche"
    Private Sub Suche_Google(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleToolStripMenuItem.Click, ToolStripMenuItem8.Click
        If isLoaded Then

            OpenWebLink("http://www.google.de/#hl=de&source=hp&q=" & TB_Titel.Text & "&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=&fp=ebbd8e4827c4c9bc")
        Else
            OpenWebLink("http://www.google.de")
        End If
    End Sub
    Private Sub Suche_Amazon(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmazonToolStripMenuItem.Click, ToolStripButton9.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.amazon.de/s/url=search-alias%3Ddvd&field-keywords=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.amazon.de/s/url=search-alias%3Ddvd&field-keywords=" & TB_Titel.Text)
                End If
            Else

                OpenWebLink("http://www.amazon.de")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Suche_Moviemaze(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovieMazeToolStripMenuItem1.Click, ToolStripMenuItem18.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)
                End If
            Else

                OpenWebLink("http://www.moviemaze.de")
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Tool_Overwrite_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Overwrite.MouseLeave
        MainForm.ContextMenu_Overwrite.AutoClose = True

    End Sub

    Private Sub Suche_xRel(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XRelToolStripMenuItem.Click, ToolStripMenuItem17.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.xrel.to/search.html?xrel_search_query=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.xrel.to/search.html?xrel_search_query=" & TB_IMDB_ID.Text)
                End If
            Else

                OpenWebLink("http://www.xrel.to/home.html")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Suche_Movieposterdb(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMDb_link.Click, ToolStripButton20.Click, ToolStripButton21.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.movieposterdb.com/browse/search?type=movies&query=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.movieposterdb.com/movie/" & TB_IMDB_ID.Text.Replace("tt", ""))
                End If
            Else

                OpenWebLink("http://www.movieposterdb.com/")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Suche_IMDB(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMDb_link.Click, ToolStripMenuItem16.Click
        Try
            Dim s As String = "de"
            If Einstellungen.Config_BrowserSuche.BrowserSuche_Use_IMDB_COM = True Then
                s = "com"
            End If


            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.imdb." & s & "/find?s=all&q=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.imdb." & s & "/title/" & TB_IMDB_ID.Text)
                End If
            Else

                OpenWebLink("http://www.imdb." & s & "/")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Suche_Moviepilot(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoviepilotdeToolStripMenuItem.Click, ToolStripMenuItem13.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then

                    OpenWebLink("http://www.moviepilot.de/searches?q=" & TB_Titel.Text & "&type=movies")
                Else

                    OpenWebLink("http://www.moviepilot.de/searches?q=" & TB_Titel.Text & "&type=movies")
                End If
            Else
                OpenWebLink("http://www.moviepilot.de")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Suche_OFDB(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFDB_link.Click, ToolStripMenuItem15.Click

        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then
                    OpenWebLink("http://www.ofdb.de/view.php?page=suchergebnis&SText=" & TB_Titel.Text)
                Else

                    OpenWebLink("http://www.ofdb.de/view.php?page=suchergebnis&Kat=IMDb&SText=" & TB_IMDB_ID.Text)
                End If
            Else

                OpenWebLink("http://www.ofdb.de/")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Suche_YouTube(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton24.Click
        Try
            If isLoaded Then

                OpenWebLink("http://www.youtube.com/results?search_query=" & TB_Titel.Text & " Trailer german hd")

            Else

                OpenWebLink("http://www.youtube.com/")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Suche_TMDB(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThemoviedbcomToolStripMenuItem.Click, ToolStripMenuItem14.Click
        Try
            If isLoaded Then
                If TB_IMDB_ID.Text = "" Then
                    OpenWebLink("http://www.themoviedb.org/")
                Else

                    Dim t As New TMDB_Scrapper
                    t.ConvertID(TB_IMDB_ID.Text)
                    OpenWebLink("http://www.themoviedb.org/movie/" & t.ConvertID(TB_IMDB_ID.Text))
                End If
            Else

                OpenWebLink("http://www.themoviedb.org/")
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region
    Private Sub DarstellerView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DarstellerView.SelectionChanged




        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies And Not Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName = "" Then

            If DarstellerView.SelectedRows.Count = 1 Then
                If Not DarstellerView.SelectedRows(0).Cells(0).Value Is Nothing Then
                    Dim actor_pfad As String = IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName, Renamer.CheckInvalid_F(CStr(DarstellerView.SelectedRows(0).Cells(0).Value)))
                    If IO.Directory.Exists(actor_pfad) Then
                        If IO.File.Exists(IO.Path.Combine(actor_pfad, "folder.jpg")) Then
                            PictureBox4.Image = MyFunctions.ImageFromJpeg(IO.Path.Combine(actor_pfad, "folder.jpg"))
                            PictureBox4.Visible = True
                        Else
                            PictureBox4.Image = Nothing
                            PictureBox4.Visible = False
                        End If
                    Else
                        PictureBox4.Image = Nothing
                        PictureBox4.Visible = False
                    End If
                Else
                    PictureBox4.Image = Nothing
                    PictureBox4.Visible = False
                End If
            Else
                PictureBox4.Image = Nothing
                PictureBox4.Visible = False
            End If
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            If DarstellerView.SelectedRows.Count = 1 Then


                If Not DarstellerView.SelectedRows(0).Cells(0).Value Is Nothing Then

                    Dim s As String = Renamer.CheckInvalid_F(CStr(DarstellerView.SelectedRows(0).Cells(0).Value))
                    If IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & "\folder.jpg") Then
                        PictureBox4.Image = MyFunctions.ImageFromJpeg(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & "\folder.jpg")
                        PictureBox4.Visible = True
                    ElseIf IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & ".jpg") Then
                        PictureBox4.Image = MyFunctions.ImageFromJpeg(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & ".jpg")
                        PictureBox4.Visible = True
                    Else
                        PictureBox4.Image = Nothing
                        PictureBox4.Visible = False
                    End If

                Else
                    PictureBox4.Image = Nothing
                    PictureBox4.Visible = False
                End If
            Else
                PictureBox4.Image = Nothing
                PictureBox4.Visible = False
            End If
        Else
            PictureBox4.Image = Nothing
            PictureBox4.Visible = False
        End If

    End Sub

    Private Sub ContextMenu_TextBox_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_TextBox.Opening
        If ContextMenu_TextBox.Items.Count > 7 Then
            Do Until ContextMenu_TextBox.Items.Count = 7
                ContextMenu_TextBox.Items.Remove(ContextMenu_TextBox.Items(7))
            Loop
        End If
        If ContextMenu_TextBox.Tag Is TB_Genre Then

            ContextMenu_TextBox.Items.Insert(0, ContextMenu_TextBox.Items.Add("Genre bearbeiten", Nothing, AddressOf Edit_Genre))
        End If
        If ContextMenu_TextBox.Tag Is TB_Regisseur Or ContextMenu_TextBox.Tag Is TB_Autoren Then
            Dim tb As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)

            If tb.Text = "" Then

            Else
                Dim tr As New ToolStripSeparator
                ContextMenu_TextBox.Items.Add(tr)
                Dim s() As String = tb.Text.Split(CChar(","))
                If s.Length > 0 Then
                    For x As Integer = 0 To s.Length - 1
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)

                    Next
                Else
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)
                End If
            End If
        End If
    End Sub
    Private Sub WIKI_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)



            OpenWebLink("http://de.wikipedia.org/w/index.php?search=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IMDB_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)
            Dim s As String = "de"
            If Einstellungen.Config_BrowserSuche.BrowserSuche_Use_IMDB_COM = True Then
                s = "com"
            End If


            OpenWebLink("http://www.imdb." & s & "/find?s=nm&q=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub tmdb_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)



            OpenWebLink("http://www.themoviedb.org/search?search=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DarstellerView_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DarstellerView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim hti As DataGridView.HitTestInfo = DarstellerView.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then
                If DarstellerView.Rows(hti.RowIndex).Selected = False Then
                    DarstellerView.ClearSelection()
                    DarstellerView.Rows(hti.RowIndex).Selected = True
                End If
                ContextMenu_Darsteller.Items.Clear()
                If Not DarstellerView.Rows(hti.RowIndex).Cells(0).Value Is Nothing Then
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)

                    ContextMenu_Darsteller.Show(DarstellerView.PointToScreen(e.Location))
                End If


            End If


        End If
    End Sub

    Private Sub Nav_Statybar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nav_Statybar.SizeChanged
        If Nav_Statybar.Size.Width > 400 Then
            Tool_Overwrite.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        Else

            Tool_Overwrite.DisplayStyle = ToolStripItemDisplayStyle.Image
        End If
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        'Vert_Links.Renderer = New MyNativRenderer
        'Nav_Statybar.Renderer = New MyNativRenderer
        'ContextMenu_FSK.Renderer = New MyNativRenderer
        'ContextMenu_Folder.Renderer = New MyNativRenderer
        'ContextMenu_Cover.Renderer = New MyNativRenderer
        'ContextMenu_TextBox.Renderer = New MyNativRenderer

        TabImages.Images.Clear()
        TabImages.Images.Add(InfoTabIcons._2)
        TabImages.Images.Add(InfoTabIcons._2grey)
        TabImages.Images.Add(InfoTabIcons._3)
        TabImages.Images.Add(InfoTabIcons._3grey)
        TabImages.Images.Add(InfoTabIcons._1)
        TabImages.Images.Add(InfoTabIcons._1grey)
        TabImages.Images.Add(InfoTabIcons._4)
        TabImages.Images.Add(InfoTabIcons._4grey)
        TabImages.Images.Add(InfoTabIcons._5)
        TabImages.Images.Add(InfoTabIcons._5grey)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
         ReDim Labels(23)


        Labels(0) = TB_Pfad
        Labels(1) = TB_Ordner
        'jatz die xml werte:
        Labels(2) = TB_Titel
        Labels(3) = TB_Originaltitel
        Labels(4) = TB_IMDB_ID
        'Labels(5) = TB_Darsteller
        Labels(5) = TB_Regisseur
        Labels(6) = TB_Autoren
        Labels(7) = TB_Studios
        Labels(8) = TB_Produktionsjahr
        Labels(9) = TB_Produktionsland
        Labels(10) = TB_Genre
        Labels(11) = TB_Produktionsland
        Labels(12) = TB_Bewertung
        Labels(13) = TB_Spieldauer
        'Labels(15) = TB_Kurzbeschreibung
        Labels(14) = TB_Inhalt
        'Labels(17) = 'media info hat keine textbax ;)
        Labels(15) = TB_Sort


        Labels(16) = TB_VideoAuflösung
        Labels(17) = TB_VideoSeitenverhältnis
        Labels(18) = TB_VideoBildwiederholungsrate
        Labels(19) = TB_VideoCodec
        Labels(20) = TB_AudioKanäle
        Labels(21) = TB_AudioCodec
        Labels(22) = TB_AudioSprachen
        Labels(23) = TB_set
    End Sub

    Public Sub refresh_UI_byPlugin()
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then

            ToolStripDropDownButton2.Visible = True
            Table_Set.Visible = False
            TableLayoutPanel3.Controls.Remove(Table_Set)
            TableLayoutPanel3.SetColumnSpan(Table_Pfad, 2)
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then

            ToolStripDropDownButton2.Visible = True


            TableLayoutPanel3.SetColumnSpan(Table_Pfad, 1)
            TableLayoutPanel3.Controls.Add(Table_Set)
            Table_Set.Visible = True
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then

            ToolStripDropDownButton2.Visible = False

            Table_Set.Visible = False
            TableLayoutPanel3.Controls.Remove(Table_Set)
            TableLayoutPanel3.SetColumnSpan(Table_Pfad, 2)
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.DVDInfo Then

            ToolStripDropDownButton2.Visible = False


            Table_Set.Visible = False
            TableLayoutPanel3.Controls.Remove(Table_Set)
            TableLayoutPanel3.SetColumnSpan(Table_Pfad, 2)
        End If
    End Sub


    Public Function Panel_info_changed() As Boolean
        If isLoaded = False Then
            Return False
        End If
        Dim r As Boolean = False
        For x As Integer = 2 To 23
            If Not CStr(Labels(x).Tag) = Labels(x).Text Then
                r = True
                GoTo re
            End If
        Next
        If Not FSK_Combobox.Text = FSK_Combobox.Tag.ToString Then
            r = True
            GoTo re
        End If
        Dim darsteller As String = ""
        If DarstellerView.RowCount - 1 > 0 Then
            For x As Integer = 0 To DarstellerView.RowCount - 1
                If Not IsNothing(DarstellerView.Rows(x).Cells(0).Value) Then
                    If darsteller = "" Then
                        darsteller = CStr(DarstellerView.Rows(x).Cells(0).Value)
                    Else
                        darsteller &= ", " & DarstellerView.Rows(x).Cells(0).Value.ToString
                    End If
                    If Not IsNothing(DarstellerView.Rows(x).Cells(1).Value) Then
                        If Not DarstellerView.Rows(x).Cells(1).Value.ToString = "" Then
                            darsteller &= " [" & DarstellerView.Rows(x).Cells(1).Value.ToString & "]"
                        End If
                    End If

                End If
            Next
        End If
        If Not CStr(DarstellerView.Tag) = darsteller Then

            r = True
        End If


re:
        Return r
    End Function


    Private Sub OpenWebLink(ByVal p1 As String)
        MainForm.OpenWebLink(p1)
    End Sub
    Public Sub Panel_Clear()
        If MainForm.cancel_DG_selection = False Then
            SicherungLöschenToolStripMenuItem.Enabled = False
            WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
            WiederherstellenToolStripMenuItem.Enabled = False
            ToolStripButton22.Image = Toolbar16.securegray
            BackdropSB.Visible = False
            SelectedMovie = Nothing
            SelectedResult = Nothing
            PictureBox1.Image.Dispose()
            PictureBox1.Image = My.Resources.no_cover_bg
            DarstellerView.Rows.Clear()
            lbl_selectedmovie.Text = ""
            FSK_Combobox.Text = ""

            For x As Integer = 0 To 23
                Labels(x).Text = ""
                Labels(x).Tag = ""
            Next
            Cover_Name.Text = ""
            Cover_Size.Text = ""
            MainForm.StatusLabel_Browser.Text = ""
            TB_Videoheightwidth.Text = ""
            Reset_tableColors()
            Count_Darsteller.Text = ""
            MainForm.Panel_flagquestion.Visible = False
            MainForm.MyBrowserHelpbar.Visible = False
            isLoaded = False
        End If
    End Sub
    Public Sub Reset_tableColors()
        Table_Titel.BackgroundImage = Nothing
        Table_Originaltitel.BackgroundImage = Nothing
        Table_IMDB_ID.BackgroundImage = Nothing

        Table_Regisseur.BackgroundImage = Nothing
        Table_Autoren.BackgroundImage = Nothing
        Table_Studios.BackgroundImage = Nothing
        Table_Produktionsjahr.BackgroundImage = Nothing
        Table_Produktionsland.BackgroundImage = Nothing
        Table_Genre.BackgroundImage = Nothing
        Table_FSK.BackgroundImage = Nothing
        Table_Bewertung.BackgroundImage = Nothing
        Table_Spieldauer.BackgroundImage = Nothing

        Table_Sort.BackgroundImage = Nothing
        Table_VideoAuflösung.BackgroundImage = Nothing
        Table_VideoSeitenverhältnis.BackgroundImage = Nothing
        Table_VideoBildwiederholungsrate.BackgroundImage = Nothing
        Table_VideoCodec.BackgroundImage = Nothing
        Table_AudioKanäle.BackgroundImage = Nothing
        Table_AudioCodec.BackgroundImage = Nothing
        Table_AudioSprachen.BackgroundImage = Nothing

        Table_Set.BackgroundImage = Nothing


    End Sub

    Private Sub BackdropSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles BackdropSB.Scroll
        If Not IsNothing(SelectedMovie) Then

            Dim v As Integer = BackdropSB.Value

            If v = 0 Then
                If IO.File.Exists(SelectedMovie.Cover) Then

                    PictureBox1.Image = MyFunctions.ImageFromJpeg(SelectedMovie.Cover)
                    If CStr(Cover_Size.Tag) = "Size" Then
                        Cover_Size.Text = PictureBox1.Image.Size.Height & "x" & PictureBox1.Image.Size.Width
                    Else
                        Cover_Size.Text = WebFunctions.FormatBytes(SelectedMovie.Coversize)
                    End If

                    Cover_Name.Text = "Cover"

                Else
                    PictureBox1.Image = My.Resources.no_cover_bg
                    Cover_Name.Text = "kein Cover"
                    Cover_Size.Text = ""
                End If

            Else
                If IO.File.Exists(SelectedMovie.Backdrops(v - 1).ToString) Then
                    Try

                        PictureBox1.Image = MyFunctions.ImageFromJpeg(SelectedMovie.Backdrops(v - 1).ToString)

                        If CStr(Cover_Size.Tag) = "Size" Then
                            Cover_Size.Text = PictureBox1.Image.Size.Height & "x" & PictureBox1.Image.Size.Width
                        Else
                            Cover_Size.Text = WebFunctions.FormatBytes(FileLen(SelectedMovie.Backdrops(v - 1).ToString))
                        End If
                        Cover_Name.Text = "Backdrop " & v
                    Catch ex As Exception
                        MsgBox("Fehler beim Laden des Fanarts" & vbCrLf & ex.Message, MsgBoxStyle.Exclamation)

                    End Try


                End If

                'PictureBox1.Image = Backdrops(v - 1)
            End If

        End If
    End Sub

#Region "Loading"
    Sub Load_item(ByVal m As Movie)
        With Me


            If Not IsNothing(.PictureBox1.Image) Then
                .PictureBox1.Image.Dispose()
                .PictureBox1.Image = My.Resources.no_cover_bg

            End If
            'If iarr = Daten.arr(19, iarr) Then

            m.Files = MyFunctions.Get_Moviepaths_in_array(m.Pfad)
            .lbl_selectedmovie.Text = m.Titel

            .TB_AudioKanäle.Text = m.AudioKanäle

            .TB_AudioCodec.Text = m.AudioCodec
            .TB_VideoAuflösung.Text = m.VideoAuflösung
            .TB_Autoren.Text = m.Autoren
            .TB_Bewertung.Text = m.Bewertung
            .TB_VideoBildwiederholungsrate.Text = m.VideoBildwiederholungsrate
            .TB_Genre.Text = m.Genre
            .TB_IMDB_ID.Text = m.IMDB_ID
            .TB_Inhalt.Text = m.Inhalt
            .TB_Produktionsjahr.Text = m.Produktionsjahr
            '.TB_Kurzbeschreibung.Text = m.Kurzbeschreibung
            .TB_Produktionsland.Text = m.Produktionsland
            .TB_Ordner.Text = m.Ordner
            .TB_Originaltitel.Text = m.Originaltitel
            .TB_Pfad.Text = m.Pfad
            .TB_VideoSeitenverhältnis.Text = m.VideoSeitenverhältnis
            .TB_Regisseur.Text = m.Regisseur
            .TB_Sort.Text = m.Sort
            .TB_set.Text = m.Setbox
            .TB_Spieldauer.Text = m.Spieldauer
            .TB_AudioSprachen.Text = m.AudioSprachen
            .TB_Studios.Text = m.Studios
            .TB_Titel.Text = m.Titel
            .TB_VideoCodec.Text = m.VideoCodec

            .TB_Videoheightwidth.Text = m.VideoBreite & "x" & m.VideoHöhe



            'MainForm.StatusLabel_Browser.Text = MyFunctions.SetCompactPath(m.Pfad, MainForm.StatusLabel_Browser.Width - 40, MainForm.StatusLabel_Browser.Font, TextFormatFlags.PathEllipsis)



            .lbl_selectedmovie.Tag = m.Titel


            .TB_set.Tag = m.Setbox
            .TB_AudioKanäle.Tag = m.AudioKanäle
            .TB_AudioCodec.Tag = m.AudioCodec
            .TB_VideoAuflösung.Tag = m.VideoAuflösung
            .TB_Autoren.Tag = m.Autoren
            .TB_Bewertung.Tag = m.Bewertung
            .TB_VideoBildwiederholungsrate.Tag = m.VideoBildwiederholungsrate
            .TB_Genre.Tag = m.Genre
            .TB_IMDB_ID.Tag = m.IMDB_ID
            .TB_Inhalt.Tag = m.Inhalt
            .TB_Produktionsjahr.Tag = m.Produktionsjahr
            '.TB_Kurzbeschreibung.Tag = m.Kurzbeschreibung
            .TB_Produktionsland.Tag = m.Produktionsland
            .TB_Ordner.Tag = m.Ordner
            .TB_Originaltitel.Tag = m.Originaltitel
            .TB_Pfad.Tag = m.Pfad
            .TB_VideoSeitenverhältnis.Tag = m.VideoSeitenverhältnis
            .TB_Regisseur.Tag = m.Regisseur
            .TB_Sort.Tag = m.Sort
            .TB_Spieldauer.Tag = m.Spieldauer
            .TB_AudioSprachen.Tag = m.AudioSprachen
            .TB_Studios.Tag = m.Studios
            .TB_Titel.Tag = m.Titel
            .TB_VideoCodec.Tag = m.VideoCodec



            If m.Gesehen = "True" Then
                .ToolStripButton18.Image = Toolbar16.watched_yes
                .ToolStripButton18.Tag = 1
            Else
                If m.Gesehen = "" Or m.Gesehen = "False" Then
                    .ToolStripButton18.Image = Toolbar16.watched_no
                    .ToolStripButton18.Tag = 0
                Else
                    m.Gesehen = "True"
                    .ToolStripButton18.Image = Toolbar16.watched_yes
                    .ToolStripButton18.Tag = 1
                End If
            End If




            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then

                If m.Sort.Contains("{") Then
                    .ToolStripDropDownButton2.Image = Toolbar16.Papergrp
                Else
                    .ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
                End If
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                If Not m.Setbox = "" Then
                    .ToolStripDropDownButton2.Image = Toolbar16.Papergrp
                Else
                    .ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
                End If
            End If
            If Not m.FSK = "" Then
                With m.FSK.ToString
                    If .Contains("18") Then
                        FSK_Combobox.Text = "18"
                        FSK_Combobox.Tag = "18"
                    ElseIf .Contains("16") Then
                        FSK_Combobox.Text = "16"
                        FSK_Combobox.Tag = "16"
                    ElseIf .Contains("12") Then
                        FSK_Combobox.Text = "12"
                        FSK_Combobox.Tag = "12"
                    ElseIf .Contains("6") Then
                        FSK_Combobox.Text = "6"
                        FSK_Combobox.Tag = "6"
                    ElseIf .Contains("0") Then
                        FSK_Combobox.Text = "0"
                        FSK_Combobox.Tag = "0"
                    Else
                        FSK_Combobox.Text = ""
                        FSK_Combobox.Tag = ""

                    End If

                End With
            Else
                FSK_Combobox.Text = ""
                FSK_Combobox.Tag = ""
            End If


            .DarstellerView.Rows.Clear()
            .DarstellerView.Tag = m.Darsteller
            'TB_Darsteller.Text = Daten.arr(5, iarr)
            If Not m.Darsteller = "" Then
                Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
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
                        DarstellerView.Rows.Add(DSname_S, DSrole_S)
                    Next
                End If
            End If
            .Count_Darsteller.Text = CStr(DarstellerView.Rows.Count - 1) & " Darsteller"
            .Count_words.Text = CStr(MyFunctions.GetStringWordCount(.TB_Inhalt.Text)) & " Wörter"






            If .DarstellerView.Rows.Count - 1 = 0 Then
                .Darstellertab.ImageIndex = 1
            Else
                .Darstellertab.ImageIndex = 0
            End If

            If .TB_Inhalt.Text = "" Then
                .Inhalttap.ImageIndex = 3
            Else
                .Inhalttap.ImageIndex = 2
            End If
            .MediaInfotab.ImageIndex = 4
            For x As Integer = 16 To 22
                If .Labels(x).Text = "" Then
                    .MediaInfotab.ImageIndex = 5
                End If
            Next


            '//////////////////////





            .Reset_tableColors()


            If .TB_Titel.Text = "" Then
                .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Originaltitel.Text = "" Then
                .Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_IMDB_ID.Text = "" Then
                .Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            'If .TB_Darsteller.Text = "" Then
            '    .Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            'End If
            If .TB_Regisseur.Text = "" Then
                .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Autoren.Text = "" Then
                .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Studios.Text = "" Then
                .Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Produktionsjahr.Text = "" Then
                .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Produktionsland.Text = "" Then
                .Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Genre.Text = "" Then
                .Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .FSK_Combobox.Text = "" Then
                .Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Bewertung.Text = "" Then
                .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Spieldauer.Text = "" Then
                .Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If

            'If .TB_Inhalt.Text = "" Then
            '    .Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            'End If
            If .TB_Sort.Text = "" Then
                .Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoAuflösung.Text = "" Then
                .Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoSeitenverhältnis.Text = "" Then
                .Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoBildwiederholungsrate.Text = "" Then
                .Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoCodec.Text = "" Then
                .Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioKanäle.Text = "" Then
                .Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioCodec.Text = "" Then
                .Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioSprachen.Text = "" Then
                .Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If m.flag = 1 Then
                Dim x As Integer = CInt((MainForm.Movie_GridView.Width / 2) - (MainForm.Panel_flagquestion.Width / 2))
                Dim y As Integer = 0
                'Dim x As Integer = CInt((.DataGridView1.Width / 2) - (.Panel_flagquestion.Width / 2))
                'Dim y As Integer = CInt((.DataGridView1.Height / 2) - (.Panel_flagquestion.Height / 2))
                'If x > 0 And y >= 0 Then
                '    .Panel_flagquestion.Location = New Point(x, y)
                'Else
                '    .Panel_flagquestion.Location = New Point(0, 0)
                'End If

                MainForm.Panel_flagquestion.Visible = True
            Else

                MainForm.Panel_flagquestion.Visible = False
            End If


            '///////////////////////////


            If XMLModule.Backup_Exists(m.Pfad) Then
                Dim d As Date = XMLModule.Backup_Date(m.Pfad)
                .SicherungLöschenToolStripMenuItem.Enabled = True
                .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & d.ToShortDateString & ")"
                .WiederherstellenToolStripMenuItem.Enabled = True
                .ToolStripButton22.Image = Toolbar16.securenormal
            Else
                .SicherungLöschenToolStripMenuItem.Enabled = False
                .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
                .WiederherstellenToolStripMenuItem.Enabled = False
                .ToolStripButton22.Image = Toolbar16.securegray
            End If

            arr_to_Panel_Cover(m)

            arr_to_Panel_Backdrops(m)

            arr_to_Panel_Refresh(m)
            isLoaded = True

        End With
        RefreshFolderPrev(m.Pfad)
    End Sub


    Public Sub backup_to_Panel(ByVal m As Movie)
        With Me
            .lbl_selectedmovie.Text = m.Titel

            .TB_AudioKanäle.Text = m.AudioKanäle

            .TB_AudioCodec.Text = m.AudioCodec
            .TB_VideoAuflösung.Text = m.VideoAuflösung
            .TB_Autoren.Text = m.Autoren
            .TB_Bewertung.Text = m.Bewertung
            .TB_VideoBildwiederholungsrate.Text = m.VideoBildwiederholungsrate
            .TB_Genre.Text = m.Genre
            .TB_IMDB_ID.Text = m.IMDB_ID
            .TB_Inhalt.Text = m.Inhalt
            .TB_Produktionsjahr.Text = m.Produktionsjahr
            '.TB_Kurzbeschreibung.Text = m.Kurzbeschreibung
            .TB_Produktionsland.Text = m.Produktionsland
            .TB_Ordner.Text = m.Ordner
            .TB_Originaltitel.Text = m.Originaltitel
            .TB_Pfad.Text = m.Pfad
            .TB_VideoSeitenverhältnis.Text = m.VideoSeitenverhältnis
            .TB_Regisseur.Text = m.Regisseur
            .TB_Sort.Text = m.Sort
            .TB_Spieldauer.Text = m.Spieldauer
            .TB_AudioSprachen.Text = m.AudioSprachen
            .TB_Studios.Text = m.Studios
            .TB_Titel.Text = m.Titel
            .TB_VideoCodec.Text = m.VideoCodec


            If m.Gesehen = "True" Then
                .ToolStripButton18.Image = Toolbar16.watched_yes
                .ToolStripButton18.Tag = 1
            Else
                If m.Gesehen = "" Then
                    .ToolStripButton18.Image = Toolbar16.watched_no
                    .ToolStripButton18.Tag = 0
                Else
                    m.Gesehen = "True"
                    .ToolStripButton18.Image = Toolbar16.watched_yes
                    .ToolStripButton18.Tag = 1
                End If

            End If

            If Not m.FSK = "" Then
                With m.FSK.ToString
                    If .Contains("18") Then
                        FSK_Combobox.Text = "18"
                        FSK_Combobox.Tag = "18"
                    ElseIf .Contains("16") Then
                        FSK_Combobox.Text = "16"
                        FSK_Combobox.Tag = "16"
                    ElseIf .Contains("12") Then
                        FSK_Combobox.Text = "12"
                        FSK_Combobox.Tag = "12"
                    ElseIf .Contains("6") Then
                        FSK_Combobox.Text = "6"
                        FSK_Combobox.Tag = "6"
                    ElseIf .Contains("0") Then
                        FSK_Combobox.Text = "0"
                        FSK_Combobox.Tag = "0"
                    Else
                        FSK_Combobox.Text = ""
                        FSK_Combobox.Tag = ""

                    End If

                End With
            Else
                FSK_Combobox.Text = ""
                FSK_Combobox.Tag = ""
            End If


            .DarstellerView.Rows.Clear()
            .DarstellerView.Tag = m.Darsteller
            'TB_Darsteller.Text = Daten.arr(5, iarr)
            If Not m.Darsteller = "" Then
                Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
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
                        DarstellerView.Rows.Add(DSname_S, DSrole_S)
                    Next
                End If
            End If
            .Count_Darsteller.Text = CStr(DarstellerView.Rows.Count - 1) & " Darsteller"
            .Count_words.Text = CStr(MyFunctions.GetStringWordCount(.TB_Inhalt.Text)) & " Wörter"



        End With
    End Sub
    Public Sub arr_to_Panel_Backdrops(ByVal m As Movie)
        With Me


            m.Backdrops = MyFunctions.Backdropsarr(m.Pfad)
            If m.Backdrops.Length > 0 Then
                .BackdropSB.Value = 0

                .BackdropSB.Visible = True
                .BackdropSB.Maximum = m.Backdrops.Length
            Else
                .BackdropSB.Visible = False
            End If
        End With
    End Sub

    Public Sub arr_to_Panel_Refresh(ByVal m As Movie)


        m.Refresh()

        If m.State_MediaInfo = 2 And m.State_Info = 2 And m.State_Cover = 2 And m.State_Backdrop = 2 And m.State_Ordner = 2 Then
            ToolStripButton3.Visible = False
        Else
            ToolStripButton3.Visible = True
        End If
    End Sub

    Public Sub arr_to_Panel_Cover(ByVal m As Movie)



        With Me
            If IO.File.Exists(m.Cover) Then
                Try

                    Dim oStream As New System.IO.FileStream(m.Cover, IO.FileMode.Open)
                    .PictureBox1.Image = New Bitmap(oStream)


                    oStream.Close()

                    m.Cover_height = .PictureBox1.Image.Size.Height
                    m.Cover_width = .PictureBox1.Image.Size.Width
                    m.Coversize = FileLen(m.Cover)
                    If CStr(.Cover_Size.Tag) = "Size" Then
                        .Cover_Size.Text = .PictureBox1.Image.Size.Height & "x" & .PictureBox1.Image.Size.Width
                    Else
                        .Cover_Size.Text = WebFunctions.FormatBytes(m.Coversize)
                    End If
                    .Cover_Name.Text = "Cover"

                Catch ex As Exception

                End Try
            Else
                .Cover_Name.Text = "kein Cover"
                .Cover_Size.Text = ""
            End If
        End With

    End Sub

    Public Sub RefreshFolderPrev(ByVal p As String)
        Try


            With Me


                .FolderListImages.Images.Clear()
                .File_Listview.Items.Clear()
                Dim fils() As String = IO.Directory.GetFiles(p)
                If fils.Count > 0 Then
                    For x As Integer = 0 To fils.Count - 1
                        Dim t As New ListViewItem
                        t.Text = IO.Path.GetFileNameWithoutExtension(fils(x))
                        t.Tag = fils(x)
                        Dim img As Icon = clsFileIcon.GetDefaultIcon(fils(x))
                        If Not IsNothing(img) Then
                            .FolderListImages.Images.Add(img)
                        End If

                        t.ImageIndex = .FolderListImages.Images.Count - 1
                        .File_Listview.Items.Add(t)
                    Next
                End If
                Dim fols() As String = IO.Directory.GetDirectories(p)
                If fols.Count > 0 Then
                    For x As Integer = 0 To fols.Count - 1
                        Dim t As New ListViewItem
                        t.Text = IO.Path.GetFileName(fols(x))
                        t.Tag = fols(x)
                        .FolderListImages.Images.Add(clsFileIcon.GetDefaultIcon(fols(x)))
                        t.ImageIndex = .FolderListImages.Images.Count - 1
                        .File_Listview.Items.Add(t)
                    Next
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Sub AfterINI()
        Me.Tool_Overwrite.DropDown = MainForm.ContextMenu_Overwrite
        Me.ToolStripDropDownButton2.DropDown = MainForm.ContextMenu_Sammlung
        Vert_Links.Renderer = New MyNativRenderer
        Nav_Statybar.Renderer = New MyNativRenderer
        ContextMenu_FSK.Renderer = New MyNativRenderer
        ContextMenu_Folder.Renderer = New MyNativRenderer
        ContextMenu_Cover.Renderer = New MyNativRenderer
        ContextMenu_TextBox.Renderer = New MyNativRenderer
    End Sub




    Private Sub EinfügenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinfügenToolStripMenuItem1.Click
        If Not SelectedMovie Is Nothing Then

            Dim des As String = ""
            des = ImageDestinations.Cover(SelectedMovie.Pfad)
            Dim img As Image = Clipboard.GetImage()
            Try
                img.Save(des, System.Drawing.Imaging.ImageFormat.Jpeg)
            Catch ex As Exception

            End Try
            SelectedMovie.RefreshCover()
            SelectedMovie.Refresh()
        End If
    End Sub


    Private Sub BackdropAusZwischenablageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackdropAusZwischenablageToolStripMenuItem.Click
        If Not SelectedMovie Is Nothing Then

            Dim des As String = ""
            des = ImageDestinations.Fanart(SelectedMovie.Pfad)
            Dim img As Image = Clipboard.GetImage()
            Try
                img.Save(des, System.Drawing.Imaging.ImageFormat.Jpeg)
            Catch ex As Exception

            End Try
            SelectedMovie.RefreshCover()
            SelectedMovie.Refresh()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        BackdropSB.Select()

    End Sub

    Private Sub Edit_Genre(ByVal sender As Object, ByVal e As EventArgs)
        If MainForm.Movie_GridView.SelectedRows.Count = 1 Then
            Dim d As New Dialog_GenreSelect
            d.Fill(Me.TB_Genre.Text)
            d.RadioButton_Rep.Visible = False
            d.RadioButton_Add.Visible = False
            If d.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As New List(Of String)
                For Each t As TreeNode In d.TreeViewVista1.Nodes
                    s.Add(CStr(t.Text))
                Next

                TB_Genre.Text = ""
                For Each g In s
                    If TB_Genre.Text = "" Then
                        TB_Genre.Text = g
                    Else
                        TB_Genre.Text &= ", " & g
                    End If
                Next
                'If Not d.ListBox1.SelectedItem.ToString() = "" Then


                'End If

            End If
        ElseIf MainForm.Movie_GridView.SelectedRows.Count > 1 Then
            Dim d As New Dialog_GenreSelect
            d.list = MainForm.GetselectedMovies()
            d.Fill()
            If d.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As New List(Of String)
                For Each t As TreeNode In d.TreeViewVista1.Nodes
                    s.Add(CStr(t.Text))
                Next
                Dim p As New Progress_Add_Genre(d.list)
                p.gen = s
                p.removeold = d.RadioButton_Rep.Checked
                p.Run()
                'If Not d.ListBox1.SelectedItem.ToString() = "" Then


                'End If

            End If

        End If
    End Sub

End Class
