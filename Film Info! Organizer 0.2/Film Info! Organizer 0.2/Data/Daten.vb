
Imports Film_Info__Organizer.Einstellungen
Imports Film_Info__Organizer.MyFunctions

Public Module Daten







    'Public Sub arr_to_Panel(ByVal m As Movie)
    '    With MainForm


    '        If Not IsNothing(.PictureBox1.Image) Then
    '            .PictureBox1.Image.Dispose()
    '            .PictureBox1.Image = My.Resources.no_cover_bg

    '        End If
    '        'If iarr = Daten.arr(19, iarr) Then

    '        m.Files = Get_Moviepaths_in_array(m.Pfad)
    '        .lbl_selectedmovie.Text = m.Titel

    '        .TB_AudioKanäle.Text = m.AudioKanäle

    '        .TB_AudioCodec.Text = m.AudioCodec
    '        .TB_VideoAuflösung.Text = m.VideoAuflösung
    '        .TB_Autoren.Text = m.Autoren
    '        .TB_Bewertung.Text = m.Bewertung
    '        .TB_VideoBildwiederholungsrate.Text = m.VideoBildwiederholungsrate
    '        .TB_Genre.Text = m.Genre
    '        .TB_IMDB_ID.Text = m.IMDB_ID
    '        .TB_Inhalt.Text = m.Inhalt
    '        .TB_Produktionsjahr.Text = m.Produktionsjahr
    '        '.TB_Kurzbeschreibung.Text = m.Kurzbeschreibung
    '        .TB_Produktionsland.Text = m.Produktionsland
    '        .TB_Ordner.Text = m.Ordner
    '        .TB_Originaltitel.Text = m.Originaltitel
    '        .TB_Pfad.Text = m.Pfad
    '        .TB_VideoSeitenverhältnis.Text = m.VideoSeitenverhältnis
    '        .TB_Regisseur.Text = m.Regisseur
    '        .TB_Sort.Text = m.Sort
    '        .TB_set.Text = m.Setbox
    '        .TB_Spieldauer.Text = m.Spieldauer
    '        .TB_AudioSprachen.Text = m.AudioSprachen
    '        .TB_Studios.Text = m.Studios
    '        .TB_Titel.Text = m.Titel
    '        .TB_VideoCodec.Text = m.VideoCodec

    '        .TB_Videoheightwidth.Text = m.VideoBreite & "x" & m.VideoHöhe





    '        .lbl_selectedmovie.Tag = m.Titel


    '        .TB_set.Tag = m.Setbox
    '        .TB_AudioKanäle.Tag = m.AudioKanäle
    '        .TB_AudioCodec.Tag = m.AudioCodec
    '        .TB_VideoAuflösung.Tag = m.VideoAuflösung
    '        .TB_Autoren.Tag = m.Autoren
    '        .TB_Bewertung.Tag = m.Bewertung
    '        .TB_VideoBildwiederholungsrate.Tag = m.VideoBildwiederholungsrate
    '        .TB_Genre.Tag = m.Genre
    '        .TB_IMDB_ID.Tag = m.IMDB_ID
    '        .TB_Inhalt.Tag = m.Inhalt
    '        .TB_Produktionsjahr.Tag = m.Produktionsjahr
    '        '.TB_Kurzbeschreibung.Tag = m.Kurzbeschreibung
    '        .TB_Produktionsland.Tag = m.Produktionsland
    '        .TB_Ordner.Tag = m.Ordner
    '        .TB_Originaltitel.Tag = m.Originaltitel
    '        .TB_Pfad.Tag = m.Pfad
    '        .TB_VideoSeitenverhältnis.Tag = m.VideoSeitenverhältnis
    '        .TB_Regisseur.Tag = m.Regisseur
    '        .TB_Sort.Tag = m.Sort
    '        .TB_Spieldauer.Tag = m.Spieldauer
    '        .TB_AudioSprachen.Tag = m.AudioSprachen
    '        .TB_Studios.Tag = m.Studios
    '        .TB_Titel.Tag = m.Titel
    '        .TB_VideoCodec.Tag = m.VideoCodec



    '        If m.Gesehen = "True" Then
    '            .ToolStripButton18.Image = Toolbar16.watched_yes
    '            .ToolStripButton18.Tag = 1
    '        Else
    '            If m.Gesehen = "" Or m.Gesehen = "False" Then
    '                .ToolStripButton18.Image = Toolbar16.watched_no
    '                .ToolStripButton18.Tag = 0
    '            Else
    '                m.Gesehen = "True"
    '                .ToolStripButton18.Image = Toolbar16.watched_yes
    '                .ToolStripButton18.Tag = 1
    '            End If
    '        End If




    '        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then

    '            If m.Sort.Contains("{") Then
    '                .ToolStripDropDownButton2.Image = Toolbar16.Papergrp
    '            Else
    '                .ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
    '            End If
    '        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
    '            If Not m.Setbox = "" Then
    '                .ToolStripDropDownButton2.Image = Toolbar16.Papergrp
    '            Else
    '                .ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
    '            End If
    '        End If
    '        If Not m.FSK = "" Then
    '            With m.FSK.ToString
    '                If .Contains("18") Then
    '                    MainForm.FSK_Combobox.Text = "18"
    '                    MainForm.FSK_Combobox.Tag = "18"
    '                ElseIf .Contains("16") Then
    '                    MainForm.FSK_Combobox.Text = "16"
    '                    MainForm.FSK_Combobox.Tag = "16"
    '                ElseIf .Contains("12") Then
    '                    MainForm.FSK_Combobox.Text = "12"
    '                    MainForm.FSK_Combobox.Tag = "12"
    '                ElseIf .Contains("6") Then
    '                    MainForm.FSK_Combobox.Text = "6"
    '                    MainForm.FSK_Combobox.Tag = "6"
    '                ElseIf .Contains("0") Then
    '                    MainForm.FSK_Combobox.Text = "0"
    '                    MainForm.FSK_Combobox.Tag = "0"
    '                Else
    '                    MainForm.FSK_Combobox.Text = ""
    '                    MainForm.FSK_Combobox.Tag = ""

    '                End If

    '            End With
    '        Else
    '            MainForm.FSK_Combobox.Text = ""
    '            MainForm.FSK_Combobox.Tag = ""
    '        End If


    '        .DarstellerView.Rows.Clear()
    '        .DarstellerView.Tag = m.Darsteller
    '        'TB_Darsteller.Text = Daten.arr(5, iarr)
    '        If Not m.Darsteller = "" Then
    '            Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
    '            If Darsteller.Length > 0 Then
    '                For x As Integer = 0 To Darsteller.Length - 1
    '                    Dim DSname_S As String = ""
    '                    Dim DSrole_S As String = ""
    '                    If Darsteller(x).Contains("[") Then
    '                        Dim DSname() As String = Darsteller(x).Split(CChar("["))
    '                        DSname_S = Trim(DSname(0))
    '                        DSrole_S = Trim(DSname(1)).Replace("]", "")
    '                        DSrole_S = DSrole_S.Replace("...", "")
    '                        DSrole_S = Trim(DSrole_S)
    '                    Else
    '                        DSname_S = Trim(Darsteller(x))
    '                    End If
    '                    MainForm.DarstellerView.Rows.Add(DSname_S, DSrole_S)
    '                Next
    '            End If
    '        End If
    '        .Count_Darsteller.Text = CStr(MainForm.DarstellerView.Rows.Count - 1) & " Darsteller"
    '        .Count_words.Text = CStr(MyFunctions.GetStringWordCount(.TB_Inhalt.Text)) & " Wörter"






    '        If .DarstellerView.Rows.Count - 1 = 0 Then
    '            .Darstellertab.ImageIndex = 1
    '        Else
    '            .Darstellertab.ImageIndex = 0
    '        End If

    '        If .TB_Inhalt.Text = "" Then
    '            .Inhalttap.ImageIndex = 3
    '        Else
    '            .Inhalttap.ImageIndex = 2
    '        End If
    '        .MediaInfotab.ImageIndex = 4
    '        For x As Integer = 16 To 22
    '            If .Labels(x).Text = "" Then
    '                .MediaInfotab.ImageIndex = 5
    '            End If
    '        Next


    '        '//////////////////////





    '        .Reset_tableColors()


    '        If .TB_Titel.Text = "" Then
    '            .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Originaltitel.Text = "" Then
    '            .Table_Originaltitel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_IMDB_ID.Text = "" Then
    '            .Table_IMDB_ID.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        'If .TB_Darsteller.Text = "" Then
    '        '    .Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        'End If
    '        If .TB_Regisseur.Text = "" Then
    '            .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Autoren.Text = "" Then
    '            .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Studios.Text = "" Then
    '            .Table_Studios.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Produktionsjahr.Text = "" Then
    '            .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Produktionsland.Text = "" Then
    '            .Table_Produktionsland.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Genre.Text = "" Then
    '            .Table_Genre.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .FSK_Combobox.Text = "" Then
    '            .Table_FSK.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Bewertung.Text = "" Then
    '            .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_Spieldauer.Text = "" Then
    '            .Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If

    '        'If .TB_Inhalt.Text = "" Then
    '        '    .Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        'End If
    '        If .TB_Sort.Text = "" Then
    '            .Table_Sort.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_VideoAuflösung.Text = "" Then
    '            .Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_VideoSeitenverhältnis.Text = "" Then
    '            .Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_VideoBildwiederholungsrate.Text = "" Then
    '            .Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_VideoCodec.Text = "" Then
    '            .Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_AudioKanäle.Text = "" Then
    '            .Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_AudioCodec.Text = "" Then
    '            .Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If .TB_AudioSprachen.Text = "" Then
    '            .Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
    '        End If
    '        If m.flag = 1 Then
    '            Dim x As Integer = CInt((.Movie_GridView.Width / 2) - (.Panel_flagquestion.Width / 2))
    '            Dim y As Integer = 0
    '            'Dim x As Integer = CInt((.DataGridView1.Width / 2) - (.Panel_flagquestion.Width / 2))
    '            'Dim y As Integer = CInt((.DataGridView1.Height / 2) - (.Panel_flagquestion.Height / 2))
    '            'If x > 0 And y >= 0 Then
    '            '    .Panel_flagquestion.Location = New Point(x, y)
    '            'Else
    '            '    .Panel_flagquestion.Location = New Point(0, 0)
    '            'End If

    '            .Panel_flagquestion.Visible = True



    '        Else

    '            .Panel_flagquestion.Visible = False
    '            '.Panel4.Visible = False
    '        End If


    '        '///////////////////////////


    '        If XMLModule.Backup_Exists(m.Pfad) Then
    '            Dim d As Date = XMLModule.Backup_Date(m.Pfad)
    '            .SicherungLöschenToolStripMenuItem.Enabled = True
    '            .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & d.ToShortDateString & ")"
    '            .WiederherstellenToolStripMenuItem.Enabled = True
    '            .ToolStripButton22.Image = Toolbar16.securenormal
    '        Else
    '            .SicherungLöschenToolStripMenuItem.Enabled = False
    '            .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
    '            .WiederherstellenToolStripMenuItem.Enabled = False
    '            .ToolStripButton22.Image = Toolbar16.securegray
    '        End If

    '        arr_to_Panel_Cover(m)



    '        arr_to_Panel_Backdrops(m)





    '        arr_to_Panel_Refresh(m)




    '        'Try
    '        '    If IsNothing(img(iarr)) Then
    '        '        If IO.File.Exists(IO.Path.Combine(Daten.arr(0, iarr), "folder.jpg")) Then

    '        '        ElseIf IO.File.Exists(IO.Path.Combine(Daten.arr(0, iarr), "folder.png")) Then
    '        '            Dim oStream As New System.IO.FileStream(IO.Path.Combine(Daten.arr(0, iarr), "folder.png"), IO.FileMode.Open)
    '        '            img(iarr) = New Bitmap(oStream)
    '        '            oStream.Close()

    '        '        End If
    '        '    End If


    '        'Catch ex As Exception
    '        '    'MsgBox(ex.Message)
    '        'End Try
    '        'Try
    '        '    arr(37, iarr) = GetStatus(iarr, arr, Daten.arr(0, iarr), img(iarr).Height, True)

    '        'Catch ex As Exception

    '        'End Try
    '        'Try

    '        'Catch ex As Exception

    '        'End Try

    '        RefreshFolderPrev(m.Pfad)



    '    End With

    'End Sub



End Module