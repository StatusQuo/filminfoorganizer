Imports System.Windows.Forms

Public Class Dialog_Sheet
    Public Sheetresults As New List(Of Sheet_Result)
    Public Selected As PreviewSheet

    'Public List As New List(Of Movie)
    Public movie As Movie

    Public prevpicboxes As New List(Of PictureBox)


    Public Sheets As New List(Of PreviewSheet)


    Public selectedcover As Integer = 0
    Public selectedart As Integer = 0
    Public cancelloadimgs As Boolean = False
    Public nostatus As Boolean = False
    Dim noprev As Boolean = False
    Dim oldtpage As Integer = 0

    Private Sub RemoveExsistingBD(ByVal m As Movie)
        m.Backdrops = MyFunctions.Backdropsarr(m.Pfad)
        If m.Backdrops.Length > 0 Then
            For x As Integer = 0 To m.Backdrops.Length - 1
                Try
                    IO.File.Delete(m.Backdrops(x))
                Catch ex As Exception

                End Try
            Next
        End If
        m.Backdrops = MyFunctions.Backdropsarr(m.Pfad)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Dim p As New Progress_SheetMove(Sheetresults)
        p.Run()
        Me.Close()









    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        cancelloadimgs = True

        'If Loadimages.IsBusy Then
        Do Until Loadimages.IsBusy = False
            Application.DoEvents()

        Loop
        'End If
        TMDBImages.List.Remove(movie)
        TMDBImages.nextmovie()
        If TMDBImages.List.Count = 0 Then
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            TMDBImages.nextmovie()
        End If
    End Sub

    Private Sub Dialog_Fanart_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Einstellungen.UserInterFace.Fanartsize_w = Me.Size.Width
        Einstellungen.UserInterFace.Fanartsize_h = Me.Size.Height
        Einstellungen.UserInterFace.Fanartsize_previewsize = CInt(vorschau.Tag)
        Einstellungen.UserInterFace.Fanartsize_maximized = If(Me.WindowState = FormWindowState.Maximized, True, False)
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = Toolbar16.exiticon

    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = Toolbar16.exit_normal
    End Sub
    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Size(Einstellungen.UserInterFace.Fanartsize_w, Einstellungen.UserInterFace.Fanartsize_h)
        Tools_1.Renderer = New MyNativRenderer
        'Font = SystemFonts.MessageBoxFont
        'If TabControl1.SelectedIndex = 0 Then
        '    alle.Visible = False
        '    keine.Visible = False
        '    random.Visible = True
        'Else
        '    alle.Visible = True
        '    keine.Visible = True
        '    random.Visible = False
        'End If
    End Sub
    '    Public Sub cover_mouseenter(ByVal sender As Object, _
    '    ByVal e As System.EventArgs)
    '        Dim itemClicked As CheckBox = CType(sender, CheckBox)
    '        'Dim index As Integer = -1I
    '        ' Das betroffene Element im Array suchen (allgemein); 
    '        ' Möglich wäre etwa auch das Vorgehen über die eigens 
    '        ' zugewiesene Name-Eigenschaft des Buttons.
    '        Dim index As Integer = -1
    '        For i As Integer = 0 To TMDB.covercount - 1
    '            If TMDB.Cover(i) Is itemClicked Then
    '                index = i


    '                Exit For
    '            End If
    '        Next


    '        If index > -1 Then
    '            PictureBox1.Image = TMDB.Coverimgs(index)

    '        End If
    '        Me.Refresh()

    '    End Sub
    '    Public Sub cover_click(ByVal sender As Object, _
    '   ByVal e As System.EventArgs)
    '        Dim itemClicked As CheckBox = CType(sender, CheckBox)
    '        'Dim index As Integer = -1I
    '        ' Das betroffene Element im Array suchen (allgemein); 
    '        ' Möglich wäre etwa auch das Vorgehen über die eigens 
    '        ' zugewiesene Name-Eigenschaft des Buttons.
    '        Dim index As Integer = -1
    '        For i As Integer = 0 To TMDB.covercount - 1
    '            If TMDB.Cover(i) Is itemClicked Then
    '                index = i


    '                Exit For
    '            End If
    '        Next


    '        If TMDB.Cover(index).Checked = True Then
    '            TMDB.Cover(index).BackColor = Color.DarkOrange
    '            'TMDB.Cover(index).BackgroundImage = Global.Film_Info__Organizer.My.Resources.Resources.selected
    '            'TMDB.Cover(index).BackgroundImageLayout = ImageLayout.Tile

    '            If index > -1 Then
    '                selectedcover = index
    '                If TMDB.covercount > 0 Then
    '                    For x As Integer = 0 To TMDB.covercount - 1
    '                        If Not x = index Then
    '                            TMDB.Cover(x).Checked = False
    '                            TMDB.Cover(x).BackColor = Color.Transparent
    '                            TMDB.Cover(x).BackgroundImage = Nothing
    '                        End If

    '                    Next
    '                End If
    '            End If
    '        Else
    '            TMDB.Cover(index).BackColor = Color.Transparent
    '        End If
    '        Me.Refresh()

    '    End Sub
    '    Public Sub Art_leave(ByVal sender As Object, _
    'ByVal e As System.EventArgs)
    '        If selectedart > -1 Then
    '            PictureBox2.Image = Graphic_Module.AutoSizeImage(Fanartimgs(selectedart), PictureBox2.Width, PictureBox2.Height)
    '        End If


    '    End Sub
    '    Public Sub Cover_leave(ByVal sender As Object, _
    'ByVal e As System.EventArgs)
    '        If selectedcover > -1 Then
    '            PictureBox1.Image = Graphic_Module.AutoSizeImage(Coverimgs(selectedcover), PictureBox1.Width, PictureBox1.Height)

    '        End If


    '    End Sub
    '    Public Sub Art_click(ByVal sender As Object, _
    '  ByVal e As System.EventArgs)
    '        Dim itemClicked As CheckBox = CType(sender, CheckBox)
    '        'Dim index As Integer = -1I
    '        ' Das betroffene Element im Array suchen (allgemein); 
    '        ' Möglich wäre etwa auch das Vorgehen über die eigens 
    '        ' zugewiesene Name-Eigenschaft des Buttons.
    '        Dim index As Integer = -1
    '        For i As Integer = 0 To TMDB.artcount - 1
    '            If TMDB.Fanart(i) Is itemClicked Then
    '                index = i


    '                Exit For
    '            End If
    '        Next

    '        selectedart = index
    '        If TMDB.Fanart(index).Checked = True Then
    '            TMDB.Fanart(index).BackColor = Color.DarkOrange
    '            'TMDB.Fanart(index).BackgroundImage = Global.Film_Info__Organizer.My.Resources.Resources.select_o
    '            TMDB.Fanart(index).BackgroundImageLayout = ImageLayout.Tile
    '        Else
    '            TMDB.Fanart(index).BackColor = Color.Transparent
    '            TMDB.Fanart(index).BackgroundImage = Nothing
    '        End If
    '        Me.Refresh()

    '    End Sub
    '    Public Sub fanart_mouseenter(ByVal sender As Object, _
    '    ByVal e As System.EventArgs)
    '        Dim itemClicked As CheckBox = CType(sender, CheckBox)
    '        'Dim index As Integer = -1I
    '        ' Das betroffene Element im Array suchen (allgemein); 
    '        ' Möglich wäre etwa auch das Vorgehen über die eigens 
    '        ' zugewiesene Name-Eigenschaft des Buttons.
    '        Dim index As Integer = -1
    '        For i As Integer = 0 To TMDB.artcount - 1
    '            If TMDB.Fanart(i) Is itemClicked Then
    '                index = i


    '                Exit For
    '            End If
    '        Next

    '        If index > -1 Then
    '            PictureBox2.Image = TMDB.Fanartimgs(index)

    '        End If
    '        Me.Refresh()

    '    End Sub


    '    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles keine.Click
    '        If TMDB.artcount > 0 Then
    '            For x As Integer = 0 To artcount - 1
    '                Fanart(x).Checked = False
    '                Fanart(x).BackColor = Color.Transparent
    '                'TMDB.Fanart(x).BackgroundImage = Nothing
    '            Next
    '        End If
    '    End Sub

    '    Private Sub GroßeSymboleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroßeSymboleToolStripMenuItem.Click
    '        If TMDB.artcount > 0 Then
    '            For x As Integer = 0 To TMDB.artcount - 1
    '                TMDB.Fanart(x).Size = New System.Drawing.Size(160, 110)
    '                TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 155, 90)
    '            Next
    '        End If
    '        If TMDB.covercount > 0 Then
    '            For x As Integer = 0 To TMDB.covercount - 1
    '                TMDB.Cover(x).Size = New System.Drawing.Size(92, 156)
    '                TMDB.Cover(x).Image = AutoSizeImage(Coverimgs(x), 87, 136)
    '            Next
    '        End If
    '        vorschau.Image = Global.Film_Info__Organizer.My.Resources.Cover_dl_16
    '        vorschau.Tag = "Groß"
    '    End Sub

    '    Private Sub KleineSymboleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KleineSymboleToolStripMenuItem.Click
    '        If TMDB.artcount > 0 Then
    '            For x As Integer = 0 To TMDB.artcount - 1
    '                TMDB.Fanart(x).Size = New System.Drawing.Size(80, 65)
    '                TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 75, 45)
    '            Next
    '        End If
    '        If TMDB.covercount > 0 Then
    '            For x As Integer = 0 To TMDB.covercount - 1
    '                TMDB.Cover(x).Size = New System.Drawing.Size(54, 100)
    '                TMDB.Cover(x).Image = AutoSizeImage(Coverimgs(x), 49, 80)
    '            Next
    '        End If
    '        vorschau.Image = Global.Film_Info__Organizer.My.Resources.Cover_dl3_16
    '        vorschau.Tag = "Klein"
    '    End Sub

    '    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles alle.Click
    '        If TMDB.artcount > 0 Then
    '            For x As Integer = 0 To artcount - 1
    '                Fanart(x).Checked = True
    '                Fanart(x).BackColor = Color.DarkOrange
    '                'TMDB.Fanart(x).BackgroundImage = Global.Film_Info__Organizer.My.Resources.Resources.select_o
    '                'TMDB.Fanart(x).BackgroundImageLayout = ImageLayout.Tile
    '            Next
    '        End If
    '    End Sub

    '    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
    '        If TabControl1.SelectedIndex = 0 Then
    '            alle.Visible = False
    '            keine.Visible = False
    '            random.Visible = True
    '        ElseIf TabControl1.SelectedIndex = 1 Then

    '            alle.Visible = True
    '            keine.Visible = True
    '            random.Visible = False
    '        ElseIf TabControl1.SelectedIndex = 2 Then
    '            If nostatus = False Then
    '                alle.Visible = False
    '                keine.Visible = False
    '                random.Visible = False
    '            Else
    '                'TabControl1.SelectedIndex = 1
    '            End If

    '        End If
    '    End Sub

    '    Private Sub random_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles random.Click
    '        If TMDB.covercount > 0 Then
    '            Randomize()

    '            Dim oZahl As New System.Random
    '            Dim i As Integer
    '            i = oZahl.Next(0, covercount)
    '            For x As Integer = 0 To TMDB.covercount - 1
    '                If Not x = i Then
    '                    TMDB.Cover(x).Checked = False
    '                    TMDB.Cover(x).BackColor = Color.Transparent
    '                    TMDB.Cover(x).BackgroundImage = Nothing
    '                End If

    '            Next
    '            'TMDB.Cover(i).BackgroundImage = Global.Film_Info__Organizer.My.Resources.Resources.selected
    '            'TMDB.Cover(i).BackgroundImageLayout = ImageLayout.Zoom
    '            Cover(i).Checked = True
    '            Cover(i).BackColor = Color.DarkOrange

    '        End If
    '    End Sub



    '    Private Sub vorschau_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vorschau.ButtonClick
    '        If vorschau.Tag = "Groß" Then
    '            KleineSymboleToolStripMenuItem_Click(KleineSymboleToolStripMenuItem, New EventArgs)

    '        ElseIf vorschau.Tag = "Klein" Then
    '            GroßeSymboleToolStripMenuItem_Click(GroßeSymboleToolStripMenuItem, New EventArgs)

    '        End If

    '    End Sub



    '    Private Sub Loadimages_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Loadimages.DoWork


    '        If covercount > 1 Then
    '            For x As Integer = 1 To covercount - 1
    '                If cancelloadimgs = True Then
    '                    GoTo ends
    '                Else
    '                    Loadimages.ReportProgress(((x + 1) / covercount) * 100)
    '                    Dim a As String = coverimgsurl(0, x)
    '                    Coverimgs(x) = ImageFromWeb(a)
    '                    Cover(x).Image = AutoSizeImage(Coverimgs(x), 49, 80)
    '                End If
    '            Next
    '        End If
    '        PG1 = 25

    '        If artcount > 1 Then
    '            For x As Integer = 1 To artcount - 1
    '                If cancelloadimgs = True Then
    '                    GoTo ends
    '                Else
    '                    Loadimages.ReportProgress(((x + 1) / artcount) * 100)
    '                    Dim a As String = Fanartimgsurl(0, x)
    '                    Fanartimgs(x) = ImageFromWeb(a)
    '                    If vorschau.Tag = "Groß" Then
    '                        TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 155, 90)
    '                    Else
    '                        TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 75, 45)
    '                    End If


    '                End If

    '            Next
    '        End If
    '        PG1 = 50
    '        Loadimages.ReportProgress(50)

    '        If covercount > 0 Then
    '            For x As Integer = 0 To covercount - 2

    '                If cancelloadimgs = False Then

    '                    Loadimages.ReportProgress(((x + 1) / covercount) * 100)
    '                    Dim a As String = coverimgsurl(1, x)
    '                    'Cover(x).Image = Global.Film_Info__Organizer.My.Resources.ajaxloader
    '                    'Coverimgs(x) = Global.Film_Info__Organizer.My.Resources.no_cover_bg
    '                    Coverimgs(x) = ImageFromWeb(a)

    '                    If vorschau.Tag = "Groß" Then
    '                        Cover(x).Image = AutoSizeImage(Coverimgs(x), 87, 136)
    '                    Else
    '                        Cover(x).Image = AutoSizeImage(Coverimgs(x), 49, 80)
    '                    End If
    '                Else


    '                End If
    '            Next
    '        End If
    '        PG1 = 75
    '        If artcount > 0 Then
    '            For x As Integer = 0 To artcount - 1
    '                If cancelloadimgs = True Then
    '                    GoTo ends
    '                Else

    '                    Loadimages.ReportProgress(((x + 1) / artcount) * 100)
    '                    Dim a As String = Fanartimgsurl(1, x)
    '                    'Fanart(x).Image = Global.Film_Info__Organizer.My.Resources.ajaxloader
    '                    'Fanartimgs(x) = Global.Film_Info__Organizer.My.Resources.no_cover_bg
    '                    Fanartimgs(x) = ImageFromWeb(a)
    '                    If vorschau.Tag = "Groß" Then
    '                        TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 155, 90)
    '                    Else
    '                        TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 75, 45)
    '                    End If
    '                End If
    '            Next
    '        End If
    '        PG1 = 100
    '        Loadimages.ReportProgress(100)
    'Ends:

    '    End Sub



    'Private Sub Dialog1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    PictureBox1.Image = Nothing
    '    PictureBox2.Image = Nothing

    '    If Loadimages.IsBusy Then
    '        cancelloadimgs = True


    '    End If


    '    If covercount > 0 Then
    '        For x As Integer = 0 To covercount - 1

    '            Try
    '                Cover(x).Dispose()
    '                Coverimgs(x).Dispose()
    '            Catch ex As Exception


    '            End Try
    '        Next
    '    End If
    '    If artcount > 0 Then
    '        For x As Integer = 0 To artcount - 1
    '            Try
    '                Fanart(x).Dispose()
    '                Fanartimgs(x).Dispose()
    '            Catch ex As Exception

    '            End Try

    '        Next
    '    End If
    '    If Me.WindowState = FormWindowState.Maximized Then
    '        Dialog_Fanart_size_maximized = True
    '        Dialog_Fanart_size_height = 0
    '        Dialog_Fanart_size_width = 0

    '    Else
    '        Dialog_Fanart_size_maximized = False
    '        Dialog_Fanart_size_height = Me.Size.Height
    '        Dialog_Fanart_size_width = Me.Size.Width
    '    End If

    'End Sub

    Private Sub Loadimages_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Loadimages.RunWorkerCompleted
        OK_Button.Enabled = True
        ProgressBar2.Visible = False
        '""   If TabControl1.SelectedIndex = 2 Then
        '   TabControl1.SelectedIndex = 0
        '   End If

        '   Me.TabPage3.Text =
        nostatus = True
    End Sub

    Private Sub Loading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'oldtpage = 2
        'TabControl1.SelectedIndex = 2

    End Sub

    Private Sub Loading_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProgressBar2.Visible = True

    End Sub

    Private Sub Loading_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProgressBar2.Visible = False

    End Sub


    'Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
    '    If nostatus = True Then
    '        If e.TabPageIndex = 2 Then
    '            e.Cancel = True
    '        End If

    '    End If
    '    If noprev = True Then
    '        If e.TabPageIndex = 0 Or 1 Then
    '            e.Cancel = True
    '        End If
    '    End If
    'End Sub


    'Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover

    '    Try
    '        If Not artcount = 0 Then
    '            Fanartprev.Size = Fanartimgs(selectedart).Size
    '            Fanartprev.PictureBox1.Image = Fanartimgs(selectedart)
    '            Darkoverlay.WindowState = FormWindowState.Maximized
    '            Darkoverlay.Show()
    '            Fanartprev.Show()
    '        End If
    '    Catch ex As Exception

    '    End Try


    'End Sub


    'Private Sub Dialog1_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.VisibleChanged
    '    If Me.Visible = True Then
    '        If mcplugin = 0 Then
    '            Ersetzen.Visible = False
    '        Else
    '            Ersetzen.Visible = True

    '        End If
    '    End If
    'End Sub

    'Private Sub ExtragroßrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtragroßrToolStripMenuItem.Click
    '    If TMDB.artcount > 0 Then
    '        For x As Integer = 0 To TMDB.artcount - 1
    '            TMDB.Fanart(x).Size = New System.Drawing.Size(240, 170)
    '            TMDB.Fanart(x).Image = AutoSizeImage(Fanartimgs(x), 235, 150)
    '        Next
    '    End If
    '    If TMDB.covercount > 0 Then
    '        For x As Integer = 0 To TMDB.covercount - 1
    '            TMDB.Cover(x).Size = New System.Drawing.Size(135, 240)
    '            TMDB.Cover(x).Image = AutoSizeImage(Coverimgs(x), 130, 220)
    '        Next
    '    End If
    '    vorschau.Image = Global.Film_Info__Organizer.My.Resources.Cover_dl_16
    '    vorschau.Tag = "Groß"
    'End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    'Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Covers.Count > 0 Then
    '        FlowLayoutPanel1.Visible = False
    '        For x As Integer = 0 To Covers.Count - 1



    '            Covers(x).Imagewith = TrackBar1.Value * 10
    '        Next
    '        FlowLayoutPanel1.Visible = True
    '    End If
    '    If Backdrops.Count > 0 Then
    '        FlowLayoutPanel2.Visible = False
    '        For x As Integer = 0 To Backdrops.Count - 1

    '            Backdrops(x).Imagewith = CInt(TrackBar1.Value * 10 * 1.5)

    '        Next
    '        FlowLayoutPanel2.Visible = True
    '    End If

    'End Sub




    Private Sub FlowLayoutPanel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel1.Click
        FlowLayoutPanel1.Focus()
    End Sub



    Sub SetIMgwith(ByVal v As Integer)
        Dim r As Boolean
        If Sheets.Count > 0 Then
            r = FlowLayoutPanel1.Visible
            FlowLayoutPanel1.Visible = False
            For x As Integer = 0 To Sheets.Count - 1
                Sheets(x).Imagewith = CInt(v * 1.5)
            Next
            FlowLayoutPanel1.Visible = True
        End If
    End Sub
    Private Sub ExtragroßrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtragroßrToolStripMenuItem.Click
        vorschau.Tag = 3
        SetIMgwith(300)
        vorschau.Image = Toolbar16.View_extragroß
    End Sub

    Private Sub KleineSymboleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KleineSymboleToolStripMenuItem.Click
        vorschau.Tag = 1
        SetIMgwith(100)
        vorschau.Image = Toolbar16.View_klein
    End Sub

    Private Sub GroßeSymboleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroßeSymboleToolStripMenuItem.Click
        vorschau.Tag = 2
        SetIMgwith(200)
        vorschau.Image = Toolbar16.View_groß
    End Sub
    Private Sub MittelgroßeSymboleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MittelgroßeSymboleToolStripMenuItem.Click
        vorschau.Tag = 1
        SetIMgwith(150)
        vorschau.Image = Toolbar16.View_mittel
    End Sub


    Private Sub vorschau_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vorschau.ButtonClick
        If CStr(vorschau.Tag) = "0" Then
            vorschau.Tag = 1
            SetIMgwith(150)
            vorschau.Image = Toolbar16.View_mittel
        ElseIf CStr(vorschau.Tag) = "1" Then
            vorschau.Tag = 2
            SetIMgwith(200)
            vorschau.Image = Toolbar16.View_groß
        ElseIf CStr(vorschau.Tag) = "2" Then
            vorschau.Tag = 3
            SetIMgwith(300)
            vorschau.Image = Toolbar16.View_extragroß
        ElseIf CStr(vorschau.Tag) = "3" Then
            vorschau.Tag = 0
            SetIMgwith(100)
            vorschau.Image = Toolbar16.View_klein
        End If
    End Sub



   
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Panel1.Visible = False
        'If Not PictureBox2.Image Is Nothing Then
        '    PictureBox2.Image.Dispose()

        'End If

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Panel1.Visible = False
    End Sub
End Class
