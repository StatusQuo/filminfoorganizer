
Imports Microsoft.WindowsAPICodePack.Shell
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports Microsoft.WindowsAPICodePack.Dialogs.Controls
Imports Microsoft.WindowsAPICodePack.Shell.PropertySystem
Imports System.Text.RegularExpressions
Imports Film_Info__Organizer.MyFunctions
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports System.Deployment
Imports System.Drawing
Imports AdvancedDataGridView

Public Class MForm

    Public treeNode_Serien As TreeNode


    'Public GlassEnabeld As Boolean = True
    'Property TaskDialogPlattFormSupport As Boolean
    Public MoviesColl As New List(Of MovieCollection)
    Public FavMoviesColl As New List(Of MovieCollection)
    Public SeriesColl As New List(Of SeriesCollection)

    Dim Is_Taskbar_progress_supported As Boolean = False
    Dim Is_New_OpenDialog_supported As Boolean = False

    Private windowsTaskbar As TaskbarManager ' = TaskbarManager.Instance
    'Private jumpList As JumpList
    Public actRows As New List(Of DataGridViewRow)
    Public DownloadManager As DownloadManager = New DownloadManager
    Public RowFilter As RowFilter = New RowFilter
    Public MetaScrapper As MetaScrapper = New MetaScrapper

    Public SelectedResult As Search_Result
    Public Cancel As Boolean = False
    Public Labels() As TextBox
    Public WithEvents myBrowser As WebBrowser
    Private Const appId As String = "Film Info! Organizer"
    Private Const ProgId As String = "Film Info! Organizer"

    Public cancel_DG_selection As Boolean = False
    Dim Exp_Öffnen As ToolStripButton
    Property restart As Boolean = False
    Property restart_path As String = ""



    Public SelectedMovie As Movie
    Public SelectedEpisode As Episode
    Public SelectedSeason As Season
    Public SelectedSeries As Series
    ReadOnly Property SelectedItem As Object
        Get
            If Not SelectedMovie Is Nothing Then
                Return SelectedMovie
            End If
            If Not SelectedEpisode Is Nothing Then
                Return SelectedEpisode
            End If
            If Not SelectedSeason Is Nothing Then
                Return SelectedSeason
            End If
            If Not SelectedSeries Is Nothing Then
                Return SelectedSeries
            End If
            Return Nothing
        End Get
    End Property





    Public Sub New()
        'SetStyle(ControlStyles.UserPaint, True)
        'SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        'SetStyle(ControlStyles.DoubleBuffer, True)



        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        treeNode_Serien = Navigationsleiste.Nodes(2)
        '
        '[ImageList]'
        TreeviewImagelist.Images.Clear()
        TreeviewImagelist.Images.Add(Toolbar16.tree_default)
        TreeviewImagelist.Images.Add(Toolbar16.Folder124)
        TreeviewImagelist.Images.Add(Toolbar16.Favoriten)
        TreeviewImagelist.Images.Add(Toolbar16.Favoriten)
        TreeviewImagelist.Images.Add(Toolbar16.Favoriten)
        TreeviewImagelist.Images.Add(Toolbar16.Favoriten)
        TreeviewImagelist.Images.Add(Toolbar16.Download_aktive)


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

        'Me.Font = SystemFonts.MessageBoxFont
        AddHandler DownloadManager.ItemCompleted, AddressOf Downloads_Item_Completed
        AddHandler DownloadManager.Started, AddressOf Downloads_Started
        AddHandler DownloadManager.TimerChanged, AddressOf Downloads_Info_Changed
        AddHandler DownloadManager.Completed, AddressOf Downloads_Completed










        ContextMenu_Flags.Renderer = New MyNativRenderer


        ContextMenu_Export.Renderer = New MyNativRenderer


        ContextMenu_Cover.Renderer = New MyNativRenderer
        ContextMenu_Columns.Renderer = New MyNativRenderer
        ContextMenu_Rows.Renderer = New MyNativRenderer
        DropDownMenu_Cover.Renderer = New MyNativRenderer
        DropDownMenu_Suche.Renderer = New MyNativRenderer


        'Nov_Main_alt.ForeColor = Color.White
        Nav_Download.Renderer = New MyNativRenderer
        DropDown_Trailer.Renderer = New MyNativRenderer
        MyBrowserHelpbar.Renderer = New MyNativRenderer
        ContextMenu_Sammlung.Renderer = New MyNativRenderer
        ContextMenu_TextBox.Renderer = New MyNativRenderer

        ContextMenuStrip_Textbox_Genre.Renderer = New MyNativRenderer
        Nov_line_browser.Renderer = New MyNativRenderer
        Nav_Menu.Renderer = New MyNativRenderer
        Nov_Main_alt.Renderer = New MyNativRenderer
        ContextMenu_Overwrite.Renderer = New MyNativRenderer
        Nav_Datagrid.Renderer = New MyNativRenderer

        Nav_Treeview.Renderer = New MyNativRenderer
        Nov_Main.Renderer = New MyNativRenderer
        MyStatusStrip.Renderer = New clsVistaToolStripRenderer

        Is_New_OpenDialog_supported = CommonFileDialog.IsPlatformSupported
        Is_Taskbar_progress_supported = TaskbarManager.IsPlatformSupported
        If Is_New_OpenDialog_supported = True Then
            Exp_Öffnen_XP.Visible = False
            Exp_Öffnen_better.Visible = True
        Else
            Exp_Öffnen_better.Visible = False
            Exp_Öffnen_XP.Visible = True
        End If

        If Is_Taskbar_progress_supported Then
            windowsTaskbar = TaskbarManager.Instance
            windowsTaskbar.ApplicationId = appId
        End If

        If Not StartupPath.StartsWith(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)) Then
            Einstellungen.ChachePath = IO.Path.Combine(StartupPath, "Cache")
            Einstellungen.SettingsPath = IO.Path.Combine(StartupPath, "User")
        Else
            Einstellungen.ChachePath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Film Info! Organizer")
            Einstellungen.SettingsPath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Film Info! Organizer")
        End If
        If Not IO.Directory.Exists(Einstellungen.ChachePath) Then
            IO.Directory.CreateDirectory(Einstellungen.ChachePath)
        End If
        'Form1_Load(Me, New EventArgs)
        'Me.PerformAutoScale()
        'Me.ResumeLayout(False)
        'Me.PerformLayout()

    End Sub

    Public Sub AddFolder(ByVal path() As String)

        ' For each string that is passed in, create a child window that uses the string
        ' as it's title. This is just to illustrate the passing of data between running
        ' instances...

        If path.Length > 0 Then
            Dim pr As New Progress_LoadFolder(path)
            pr.Run()

        End If
        'MainForm.BringToFront()
    End Sub

    ' Delegate for use with Invoke statements across threads...
    Public Delegate Sub AddFolderDelegate(ByVal path() As String)



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ExpTree1.ShowTree()
        'Dialog1.Show()
        'Me.Font = SystemFonts.MenuFont
        'Explorer1.Show()
        'NativeMethods.SetWindowTheme(Me.Handle, "explorer", Nothing)


        'Dim m As New FolderBrowserDialog
        'm.ShowDialog()
        'Throw New Exception("WAAA")
        'Dialog_Trailer.Show()

        Einstellungen.LoadfromFile()
        'Einstellungen.LoadUI()
        refresh_UI_byPlugin()
        InfoPanel_Movie1.AfterINI()

        'Einstellungen.UserInterFace.Load()
        'Einstellungen.Columns.Load()
        Dim x As Integer = Movie_GridView.Width - 30 - Panel_Overlay_useImage.Size.Width
        Panel_Overlay_useImage.Location = New Point(x, Nov_line_browser.Height)
        Panel_ask_selectmovie.Location = New Point(x, Nov_line_browser.Height)
        Panel_flagquestion.Location = New Point(x, 44)
        Panel_q_Trailer.Location = New Point(x, Nov_line_browser.Height)
        If IO.File.Exists(IO.Path.Combine(Einstellungen.SettingsPath, "Config.xml")) Then
            Dim xml As System.Xml.XmlDocument
            xml = New System.Xml.XmlDocument
            xml.Load(IO.Path.Combine(Einstellungen.SettingsPath, "Config.xml"))
            Einstellungen.Config_Overwrite.Load(xml)
        End If

        If Not ToolStripTextBox1.Text = "" And Not ToolStripTextBox1.Text = "Suchen" Then

            ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
            ToolStripTextBox1.ForeColor = SystemColors.MenuText
        Else
            If Not ToolStripTextBox1.Selected = True Then
                ToolStripTextBox1.Text = "Suchen"
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.GrayText
                Filter_Dropdown_OPT.ForeColor = SystemColors.GrayText
            Else
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.MenuText
                Filter_Dropdown_OPT.ForeColor = SystemColors.MenuText
            End If
        End If

        'Glass.SetGlass(Me, False, 60, 0, 0, 0)


        'Dim r As String = "D:\lol\"
        'MsgBox(r.LastIndexOf("\"))
        'If r.LastIndexOf("\") = 2 Then
        '    r = r.Substring(0, r.LastIndexOf("\"))
        'Else
        '    r = r.Substring(0, 3)
        'End If
        'Dialog1.Show()

        'Me.Refresh()
        'Einstellungen.Config_Scrapper.Scrapper_TMDB_dominant_ScrapperValues.Add(Scrapper_Valuetype.Genre)


        'Font = SystemFonts.MessageBoxFont
        'ExpTree1.ShowTree()

        'MsgBox(Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu)
        'Einstellungen.Load()
        'm.a = "Hallo"
        'ListView1.Items.Add(m.lm)



        '





        'If IO.File.Exists(IO.Path.Combine(Einstellungen.ChachePath, "updater.exe")) Then
        '    Try
        '        IO.File.Delete(IO.Path.Combine(Einstellungen.ChachePath, "updater.exe"))
        '    Catch ex As Exception

        '    End Try
        '    MsgBox("Das Programm wurde erfolgreich auf die Version: " & String.Format("{0}", My.Application.Info.Version.ToString) & " " & My.Application.Info.Description & " aktualisiert", MsgBoxStyle.Information)
        'End If

        'Dim c As String = Einstellungen.ChachePath
        'If IO.Directory.Exists(c) Then
        '    For Each fi In IO.Directory.GetFiles(c)
        '        Try
        '            IO.File.Delete(fi)
        '        Catch ex As Exception

        '        End Try
        '    Next
        'End If



        ''For x As Integer = 0 To 10
        ''    Threading.Thread.Sleep(20)
        ''    Me.Opacity = x / 10

        ''Next        
        ''If Settings.Visible = True Then
        ''    Settings.Focus()
        ''    Settings.Refresh()
        ''    Settings.ShowDialog()

        ''End If
        'Me.Opacity = 1
        SplitContainer_Infopanel.SplitterWidth = 2



        'Dim p(1) As String
        'p(0) = "D:\Eigene Videos\Meine Filme"




    End Sub

    Private Sub Refresh_Toolbar_States_alt()
        Toolbar_Timer.Enabled = False
        Toolbar_Timer.Stop()
        If Movie_GridView.SelectedRows.Count = 0 Then
            exp_menu_backup.Visible = False
            exp_menu_delet.Visible = False
            exp_menu_edit.Visible = False
            exp_menu_export.Visible = False
            exp_menu_save.Visible = False
            exp_menu_saveas.Visible = False
            exp_menu_sep_file_big.Visible = False
            exp_menu_copy.Visible = False
            exp_menu_cut.Visible = False
            exp_menu_kopieren.Visible = False
            exp_menu_verschieben.Visible = False
            exp_sep_file1.Visible = False
            Exp_Abrufen.Visible = False
            exp_sep.Visible = False
            Exp_Play.Visible = False
            exp_Download.Visible = False
            Exp_Suche.Visible = False
            Exp_MediaInfo.Visible = False
            Exp_Rename.Visible = False
            exp_menu_Sammlung.Visible = False




            exp_speichern.Visible = False

            If Is_New_OpenDialog_supported = True Then
                Exp_Öffnen_better.Visible = True
                Exp_Öffnen_XP.Visible = False
            Else
                Exp_Öffnen_XP.Visible = True
                Exp_Öffnen_better.Visible = False
            End If


        ElseIf Movie_GridView.SelectedRows.Count = 1 Then

            Dim c As Boolean = False
            If Einstellungen.Config_Design.alwaysExplore = True Then
                c = True
            End If
            If Is_New_OpenDialog_supported = True Then
                Exp_Öffnen_better.Visible = c
            Else
                Exp_Öffnen_XP.Visible = c
            End If


            exp_menu_Sammlung.Visible = True
            Toolbar_Timer.Enabled = True
            exp_speichern.Visible = False

            exp_menu_backup.Visible = True
            exp_menu_delet.Visible = True
            exp_menu_edit.Visible = True
            exp_menu_export.Visible = True
            exp_menu_save.Visible = True
            exp_menu_saveas.Visible = True
            exp_menu_sep_file_big.Visible = True
            exp_menu_copy.Visible = True
            exp_menu_cut.Visible = True
            exp_menu_kopieren.Visible = True
            exp_menu_verschieben.Visible = True
            exp_sep_file1.Visible = True
            Exp_Abrufen.Visible = True

            exp_sep.Visible = True

            If Not SelectedMovie Is Nothing Then


                If SelectedMovie.Files.Length > 0 And Not IsNothing(SelectedMovie.Files(0)) Then
                    Exp_Play.Image = clsFileIcon.GetDefaultIcon(SelectedMovie.Files(0)).ToBitmap
                    Exp_Play.Visible = True
                Else
                    Exp_Play.Visible = False


                End If
            End If


            'If DataGridView1.SelectedRows(0).Cells(Column_Rate_Backdrops.Index).Value.ToString = "2" And DataGridView1.SelectedRows(0).Cells(Column_Rate_Cover.Index).Value.ToString = "2" Then
            '    exp_Download.Visible = False
            'Else
            '    exp_Download.Visible = True
            'End If
            'If DataGridView1.SelectedRows(0).Cells(Column_Rate_Info.Index).Value.ToString = "2" Then
            '    Exp_Suche.Visible = False
            'Else
            '    Exp_Suche.Visible = True
            'End If
            'If DataGridView1.SelectedRows(0).Cells(Column_Rate_MediaInfo.Index).Value.ToString = "2" Then
            '    Exp_MediaInfo.Visible = False
            'Else
            '    Exp_MediaInfo.Visible = True
            'End If
            'If DataGridView1.SelectedRows(0).Cells(Column_Rate_Ordner.Index).Value.ToString = "2" Then
            '    Exp_Rename.Visible = False
            'Else
            '    Exp_Rename.Visible = True
            'End If

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then

            Toolbar_Timer.Enabled = True
            exp_menu_Sammlung.Visible = True
            exp_speichern.Visible = False
            Dim c As Boolean = False
            If Einstellungen.Config_Design.alwaysExplore = True Then
                c = True
            End If
            If Is_New_OpenDialog_supported = True Then
                Exp_Öffnen_better.Visible = c
            Else
                Exp_Öffnen_XP.Visible = c
            End If
            exp_menu_backup.Visible = True
            exp_menu_delet.Visible = True
            exp_menu_edit.Visible = True
            exp_menu_export.Visible = True
            exp_menu_save.Visible = True
            exp_menu_saveas.Visible = True
            exp_menu_sep_file_big.Visible = True
            exp_menu_copy.Visible = True
            exp_menu_cut.Visible = True
            exp_menu_kopieren.Visible = True
            exp_menu_verschieben.Visible = True
            exp_sep_file1.Visible = True
            Exp_Abrufen.Visible = True
            Exp_Play.Visible = False

            exp_sep.Visible = True


        End If
    End Sub

    Public Sub Refresh_Toolbar_States()

        If Nov_Main_alt.Visible = True Then
            Refresh_Toolbar_States_alt()
        Else
            Toolbar_Timer.Enabled = False
            Toolbar_Timer.Stop()
        End If





        If Movie_GridView.SelectedRows.Count = 0 Then
            KonvertierenToolStripMenuItem.Enabled = False

            CoverUndFanartLöschenToolStripMenuItem.Enabled = False


            MarkierungToolStripMenuItem.Visible = False
            MarkierungToolStripMenuItem1.Enabled = False
            SicherungToolStripMenuItem.Enabled = False
            MediaInfoToolStripMenuItem.Enabled = False

            FilmeZusammenfügenToolStripMenuItem.Enabled = False
            Speichern_Tool.Enabled = False
            openselfolder_tool.Enabled = False
            MediaInfo_tool.Enabled = False
            ToolStrip_Suche.Enabled = False
            Cover_Tool.Enabled = False
            Apspielen_tool.Enabled = False
            Tool_Rename.Enabled = False
            ToolStripMainItem_Info.Enabled = False
            ToolStripMainItem_Bearbeiten.Enabled = False
            ToolStripMainItem_Extras.Enabled = True
            ToolStripMainItem_Hilfe.Enabled = True
            ToolStripMainItem_Datei.Enabled = True
            ToolStripMenuItem_Abspielen.Enabled = False
            ToolStripMenuItem_CoverFanart.Enabled = False
            ToolStripMenuItem_CoverFanartauto.Enabled = False
            ToolStripMenuItem_Exportieren.Enabled = False
            ToolStripMenuItem_MediaInfo.Enabled = False
            ToolStripMenuItem29.Enabled = False
            ToolStripMenuItem30.Enabled = False
            ToolStripMenuItem31.Enabled = False
            ToolStripMenuItem_Ordnerdurchsuchen.Enabled = False
            ToolStripMenuItem_Speichern.Enabled = False
            ToolStripMenuItem_Speichern_unter.Enabled = False
            FeldBearbeitenToolStripMenuItem.Enabled = False

            InfoPanel_Movie1.ToolStripButton3.Visible = False
            InfoPanel_Movie1.InfoslöschenToolStripButton3.Enabled = False
            InfoPanel_Movie1.ToolStripButton_Rückgängig.Enabled = False
            InfoPanel_Movie1.ToolStripButton_Ergebnisbearbeiten.Visible = False
            InfoPanel_Movie1.ToolStripButton22.Enabled = False

    
            KonvertierenToolStripMenuItem.Enabled = True

        ElseIf Movie_GridView.SelectedRows.Count = 1 Then
            KonvertierenToolStripMenuItem.Enabled = True
            CoverUndFanartLöschenToolStripMenuItem.Enabled = True
            MarkierungToolStripMenuItem.Visible = True
            MarkierungToolStripMenuItem1.Enabled = True
            If SelectedMovie.Files.Length > 1 Then
                FilmeZusammenfügenToolStripMenuItem.Enabled = True
            Else
                FilmeZusammenfügenToolStripMenuItem.Enabled = False
            End If

            SicherungToolStripMenuItem.Enabled = True
            MediaInfoToolStripMenuItem.Enabled = False
            FeldBearbeitenToolStripMenuItem.Enabled = True
            Tool_Rename.Enabled = True
            Speichern_Tool.Enabled = True
            openselfolder_tool.Enabled = True
            MediaInfo_tool.Enabled = True
            ToolStrip_Suche.Enabled = True
            Cover_Tool.Enabled = True
            Apspielen_tool.Enabled = True

            ToolStripMainItem_Info.Enabled = True
            ToolStripMainItem_Bearbeiten.Enabled = True
            ToolStripMainItem_Extras.Enabled = True
            ToolStripMainItem_Hilfe.Enabled = True
            ToolStripMainItem_Datei.Enabled = True

            ToolStripMenuItem_CoverFanart.Enabled = True
            ToolStripMenuItem_CoverFanartauto.Enabled = True
            ToolStripMenuItem_Exportieren.Enabled = True
            ToolStripMenuItem_MediaInfo.Enabled = True
            ToolStripMenuItem29.Enabled = True
            ToolStripMenuItem30.Enabled = True
            ToolStripMenuItem31.Enabled = True
            ToolStripMenuItem_Ordnerdurchsuchen.Enabled = True
            ToolStripMenuItem_Speichern.Enabled = True
            ToolStripMenuItem_Speichern_unter.Enabled = True

            If Not SelectedMovie Is Nothing Then


                If SelectedMovie.Files.Length > 0 And Not IsNothing(SelectedMovie.Files(0)) Then

                    ToolStripMenuItem_Abspielen.Enabled = True
                Else
                    ToolStripMenuItem_Abspielen.Enabled = False


                End If
            End If


            InfoPanel_Movie1.ToolStripButton22.Enabled = True
            InfoPanel_Movie1.InfoslöschenToolStripButton3.Enabled = True
            InfoPanel_Movie1.ToolStripButton_Rückgängig.Enabled = True

            InfoPanel_Movie1.ToolStripButton_Ergebnisbearbeiten.Visible = Not IsNothing(SelectedResult)

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then

            CoverUndFanartLöschenToolStripMenuItem.Enabled = True
            MarkierungToolStripMenuItem.Visible = True
            MarkierungToolStripMenuItem1.Enabled = True
            FilmeZusammenfügenToolStripMenuItem.Enabled = True

            Tool_Rename.Enabled = True

            SicherungToolStripMenuItem.Enabled = True
            MediaInfoToolStripMenuItem.Enabled = True

            FeldBearbeitenToolStripMenuItem.Enabled = True

            Speichern_Tool.Enabled = True
            openselfolder_tool.Enabled = False
            MediaInfo_tool.Enabled = True
            ToolStrip_Suche.Enabled = True
            Cover_Tool.Enabled = True
            Apspielen_tool.Enabled = False

            ToolStripMainItem_Info.Enabled = True
            ToolStripMainItem_Bearbeiten.Enabled = True
            ToolStripMainItem_Extras.Enabled = True
            ToolStripMainItem_Hilfe.Enabled = True
            ToolStripMainItem_Datei.Enabled = True

            ToolStripMenuItem_Abspielen.Enabled = False
            ToolStripMenuItem_CoverFanart.Enabled = True
            ToolStripMenuItem_CoverFanartauto.Enabled = True
            ToolStripMenuItem_Exportieren.Enabled = True
            ToolStripMenuItem_MediaInfo.Enabled = True
            ToolStripMenuItem29.Enabled = True
            ToolStripMenuItem30.Enabled = True
            ToolStripMenuItem31.Enabled = True
            ToolStripMenuItem_Ordnerdurchsuchen.Enabled = False
            ToolStripMenuItem_Speichern.Enabled = True
            ToolStripMenuItem_Speichern_unter.Enabled = True

            InfoPanel_Movie1.InfoslöschenToolStripButton3.Enabled = False
            InfoPanel_Movie1.ToolStripButton22.Enabled = False
            InfoPanel_Movie1.ToolStripButton3.Visible = False
            InfoPanel_Movie1.ToolStripButton_Rückgängig.Enabled = False
            InfoPanel_Movie1.ToolStripButton_Ergebnisbearbeiten.Visible = False
        End If
    End Sub
    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Movie_GridView.CellPainting
        If e.Handled = True Then
            Exit Sub
        End If


        If e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Rate_Cover.Index Then
            Dim InfoIcon As Image = Toolbar16.staty_16_cover_test
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Rate_Backdrops.Index Then
            Dim InfoIcon As Image = Toolbar16.staty_16_fanart
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Rate_Info.Index Then
            Dim InfoIcon As Image = Toolbar16.staty_16_info
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Rate_MediaInfo.Index Then
            Dim InfoIcon As Image = Toolbar16.staty_16_mediainfo
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Fortschritt.Index Then
            Dim InfoIcon As Image = Toolbar16.progress
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Rate_Ordner.Index Then
            Dim InfoIcon As Image = Toolbar16.Folder129
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Flags.Index Then
            'Dim InfoIcon As Image = Toolbar16.progress
            e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            'Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            'e.Graphics.DrawImage(InfoIcon, c)
            e.Handled = True
        ElseIf e.ColumnIndex = -1 Then
            'Dim InfoIcon As Image = Toolbar16.progress
            'e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border And Not DataGridViewPaintParts.)
            'Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
            'e.Graphics.DrawImage(InfoIcon, c)
            'e.Handled = True
        End If

    End Sub




    Public Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Movie_GridView.SelectionChanged

        If Movie_GridView.SelectedRows.Count = 0 Then
            Debug.WriteLine("Kein Film ausgewählt")
            If actRows.Count = Movie_GridView.RowCount Then
                Count_Movies.Text = "0 | " & Movie_GridView.RowCount & " Filme"
            Else
                Count_Movies.Text = "0 | " & Movie_GridView.RowCount & " (" & actRows.Count & ")" & " Filme"
            End If
            InfoPanel_Movie1.Panel_Clear()
            Refresh_Toolbar_States()
        ElseIf Movie_GridView.SelectedRows.Count = 1 Then


            Debug.WriteLine("1 Film")
            'Debug.WriteLine("mehrere Filme")
            Dim m As Movie
            m = CType(Movie_GridView.SelectedRows(0).Tag, Movie)

            If cancel_DG_selection = True Then

                If Not IsNothing(m) Then
                    If m Is SelectedMovie Then
                        cancel_DG_selection = False
                        Refresh_Toolbar_States()
                    End If
                End If
            Else

                If Check_for_changedInformations() = False Then
                    ShowPanel_Movie()
                    If Not IsNothing(m) Then
                        If IO.Directory.Exists(m.Pfad) Then
                            SelectedMovie = m
                            SelectedResult = Nothing
                            InfoPanel_Movie1.Load_item(m)
                            'ToPanelTimer.Enabled = True
                        Else

                            For Each s In MoviesColl
                                If s.Movies.Contains(m) Then
                                    s.Movies.Remove(m)
                                End If
                            Next
                            For Each s In FavMoviesColl
                                If s.Movies.Contains(m) Then
                                    s.Movies.Remove(m)
                                End If
                            Next
                            actRows.Remove(m.Row)
                            Movie_GridView.Rows.Remove(m.Row)
                        End If
                        'Dim cd As String = MyFunctions.FormatSeconds(CLng(CDbl(XMLModule.Converttoabsmin(m.Spieldauer)) * 60))

                        If actRows.Count = Movie_GridView.RowCount Then
                            Count_Movies.Text = "1 | " & Movie_GridView.RowCount & " Filme"
                        Else
                            Count_Movies.Text = "1 | " & Movie_GridView.RowCount & " (" & actRows.Count & ")" & " Filme"
                        End If 'If Not cd Is Nothing Then

                        '    Count_Movies.Text &= " " & "(" & cd & ")"
                        'End If


                    End If
                    Refresh_Toolbar_States()
                End If


            End If
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then



            'Count_Movies.Text = DataGridView1.SelectedRows.Count & " | " & DataGridView1.RowCount & " Filme"



            Debug.WriteLine("mehrere Filme")
            If Check_for_changedInformations() = False Then
                'ShowPanel_Multi()

                SelectedMovie = Nothing
                InfoPanel_Movie1.Panel_Clear()
                If actRows.Count = Movie_GridView.RowCount Then
                    Count_Movies.Text = Movie_GridView.SelectedRows.Count & " | " & Movie_GridView.RowCount & " Filme"
                Else
                    Count_Movies.Text = Movie_GridView.SelectedRows.Count & " | " & Movie_GridView.RowCount & " (" & actRows.Count & ")" & " Filme"
                End If
                Dim filelen As Long = 0
                For Each s As DataGridViewRow In Movie_GridView.SelectedRows
                    filelen += CLng(s.Cells(Column_SizeFolder.Index).Value)
                Next
                Count_Movies.Text = "~" & WebFunctions.FormatKiloBytes(filelen) & "     " & Count_Movies.Text
                Refresh_Toolbar_States()
            End If
            'PictureBox1.Image = My.Resources.imageres143



        End If
    End Sub

    Private Function Check_for_changedInformations() As Boolean
        Dim r As Boolean = False
        If Not cancel_DG_selection = True Then
            If Not IsNothing(SelectedMovie) Then
                If InfoPanel_Movie1.Panel_info_changed() = True Then
                    Debug.WriteLine("....wurde geändert")
                    Dim result As MsgBoxResult
                    result = MsgBox("Möchten Sie die Änderungen an dem Film """ & InfoPanel_Movie1.lbl_selectedmovie.Text & """ speichern?", MsgBoxStyle.YesNoCancel, "Änderungen speichern?")
                    If result = MsgBoxResult.Yes Then
                        SelectedMovie.Save()
                    End If
                    If result = MsgBoxResult.Cancel Then
                        Debug.WriteLine("Frage abgeborchen")
                        Dim mo As Movie = SelectedMovie
                        cancel_DG_selection = True
                        Movie_GridView.ClearSelection()
                        mo.Row.Selected = True
                        Debug.WriteLine("ok")
                        r = True
                    End If
                End If
            End If
        End If
        Return r
    End Function







    Private Sub DVDInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DVDInfoToolStripMenuItem.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            XMLModule.SaveASDvdinfo(SelectedMovie)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
                Dim m As Movie
                m = CType(Movie_GridView.Rows(x).Tag, Movie)
                If Not IsNothing(m) Then
                    XMLModule.SaveASDvdinfo(m)
                End If
            Next
        End If
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenüleisteToolStripMenuItem.Click, ToolStripMenuItem54.Click, ToolStripMenuItem6.Click
        Nav_Menu.Visible = Not Nav_Menu.Visible
    End Sub
    Private Sub OptionenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionenToolStripMenuItem.Click, Einstellungen_Tool.ButtonClick, OptionenToolStripMenuItem1.Click, ToolStripMenuItem51.Click
        Einstellungen.Show()
        Settings.BringToFront()
    End Sub

    Private Sub Treeinout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click, NavigationsleisteToolStripMenuItem.Click, exp_navbar.Click, ToolStripMenuItem56.Click, ToolStripMenuItem5.Click
        SplitContainer_treepanel.Visible = False
        SplitContainer_treepanel.Refresh()
        SplitContainer_treepanel.Panel1Collapsed = Not SplitContainer_treepanel.Panel1Collapsed
        SplitContainer_treepanel.Visible = True
        SplitContainer_treepanel.Refresh()
        If SplitContainer_treepanel.Panel1Collapsed = True Then
            exp_navbar.Image = Toolbar16.Tree_in
            ToolStripButton11.Image = Toolbar16.Tree_in
        Else
            exp_navbar.Image = Toolbar16.Tree_out
            ToolStripButton11.Image = Toolbar16.Tree_out
        End If
    End Sub
    Private Sub Infobaranzeigen_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Infobaranzeigen_tool.Click, InfoPanelToolStripMenuItem.Click, exp_InfoPanel.Click, ToolStripMenuItem57.Click, ToolStripMenuItem2.Click
        SplitContainer_Infopanel.Panel2Collapsed = Not SplitContainer_Infopanel.Panel2Collapsed
        If SplitContainer_Infopanel.Panel2Collapsed = True Then
            exp_InfoPanel.Image = Toolbar16.Panel_in
            Infobaranzeigen_tool.Image = Toolbar16.Panel_in
        Else
            exp_InfoPanel.Image = Toolbar16.Panel_out
            Infobaranzeigen_tool.Image = Toolbar16.Panel_out

        End If
    End Sub

    Private Sub Ordnerladen_Tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordnerladen_Tool.Click, OrdnerLadenToolStripMenuItem.Click, ToolStripMenuItem77.Click, ToolStripMenuItem65.Click
        If CommonFileDialog.IsPlatformSupported = True Then
            Dim m As New CommonOpenFileDialog
            m.IsFolderPicker = True



            'Try
            '    m.InitialDirectoryShellContainer = TryCast(KnownFolders.VideosLibrary, ShellContainer)
            'Catch ex As Exception

            'End Try

            m.Multiselect = True

            Dim groupBox As New CommonFileDialogGroupBox("Bei einem neuen Film")
            Dim checkA As New CommonFileDialogCheckBox("chkOptionA", "Online-Suche", Einstellungen.Config_Laden.Laden_Ordner_Suche)
            Dim checkB As New CommonFileDialogCheckBox("chkOptionB", "MediaInfo", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            Dim checkC As New CommonFileDialogCheckBox("chkOptionB", "neue Ordner erstellen", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            checkA.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_Suche
            checkB.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_MediaInfo
            checkC.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner
            groupBox.Items.Add(checkA)
            groupBox.Items.Add(checkB)
            groupBox.Items.Add(checkC)
            m.Controls.Add(New CommonFileDialogSeparator())
            m.Controls.Add(groupBox)
            m.Controls.Add(New CommonFileDialogSeparator())


            Dim optBox As New CommonFileDialogGroupBox("Suchmodus")
            Dim rlist As New CommonFileDialogRadioButtonList

            Dim radioA As New CommonFileDialogRadioButtonListItem("Schnelle Suche")
            Dim radioB As New CommonFileDialogRadioButtonListItem("Normale Suche")
            Dim radioC As New CommonFileDialogRadioButtonListItem("Ausführliche Suche")
            rlist.Items.Add(radioA)
            rlist.Items.Add(radioB)
            rlist.Items.Add(radioC)
            rlist.SelectedIndex = Einstellungen.Config_Laden.Laden_Ordner_suchmodus

            'rlist.SelectedIndex = 0
            optBox.Items.Add(rlist)



            'Dim Favcheck As New CommonFileDialogCheckBox("chkOptionA", "Zu Favorieten hinzufügen", True)


            m.Controls.Add(optBox)
            'm.Controls.Add(New CommonFileDialogSeparator())
            'm.Controls.Add(Favcheck)
            'Favcheck.IsChecked = False
            If m.ShowDialog = CommonFileDialogResult.OK Then
                Clear_DG(True)
                Einstellungen.Config_Laden.Laden_Ordner_Suche = checkA.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = checkB.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = checkC.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_suchmodus = rlist.SelectedIndex
                's(0) = m.FileNames
                If m.FileNames.Count > 0 Then
                    Dim s(1) As String
                    ReDim s(m.FileNames.Count)
                    For x As Integer = 0 To m.FileNames.Count - 1
                        s(x) = m.FileNames(x)
                        'MsgBox(m.FileNames(x))
                    Next
                    'If Favcheck.IsChecked = False Then
                    Dim dl As New Progress_LoadFolder(s)
                    dl.Run()
                    'Else
                    '    Dim dl As New Progress_LoadFavFolder(s)
                    '    dl.Run()
                    'End If

                    'DatenLaden.Paths = s
                    'Laden.Show()
                    'DatenLaden.Worker.RunWorkerAsync()
                End If

                'set_HV()

            End If
        Else
            Dim fol As New FolderBrowserDialog
            'fol.SelectedPath = "D:\Eigene Videos\Video"
            If fol.ShowDialog = Windows.Forms.DialogResult.OK Then
                Clear_DG(True)
                Dim s(1) As String
                s(0) = fol.SelectedPath
                'set_HV()
                If Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu = True Then
                    Dim dl As New Dialog_LoadingMethode
                    dl.TopMost = True
                    dl.p = s
                    dl.ShowDialog()
                Else
                    Dim Datenlader As New Progress_LoadFolder(s)
                    Datenlader.Run()
                End If
                'DatenLaden.Paths = s
                'Laden.Show()
                'DatenLaden.Worker.RunWorkerAsync()
            End If
        End If
    End Sub
    Function GetselectedMovies() As List(Of Movie)
        Dim li As New List(Of Movie)
        For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
            Dim m As Movie = CType(Movie_GridView.SelectedRows(x).Tag, Movie)
            li.Add(m)
        Next
        Return li
    End Function




    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Movie_GridView.ClearSelection()
        If Not IsNothing(SelectedMovie) Then
            SelectedMovie.Row.Selected = True
        End If

    End Sub



    Private Sub refresh_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refresh_tool.Click, ZuToolStripMenuItem.Click, ToolStripMenuItem67.Click
        If TypeOf TreeViewVista1.SelectedNode.Tag Is MovieCollection = True Then
            Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Tag, MovieCollection)
            Dim s(1) As String
            s(0) = mColl.Pfad
            Clear_DG(False)
            Movie_GridView.Rows.Clear()
            mColl.Movies.Clear()
            mColl.Node.Remove()
            If FavMoviesColl.Contains(mColl) Then
                FavMoviesColl.Remove(mColl)
                Dim Datenlader As New Progress_LoadFavFolder(s)
                Datenlader.Run()
            Else
                MoviesColl.Remove(mColl)
                Dim Datenlader As New Progress_LoadFolder(s)
                Datenlader.Run()
            End If




        ElseIf IsNothing(TreeViewVista1.SelectedNode.Tag) Then
            Clear_DG(False)
            If TreeViewVista1.SelectedNode.Nodes.Count > 0 Then
                Dim s(TreeViewVista1.SelectedNode.Nodes.Count) As String

                For x As Integer = 0 To TreeViewVista1.SelectedNode.Nodes.Count - 1
                    If TypeOf TreeViewVista1.SelectedNode.Nodes(x).Tag Is MovieCollection = True Then

                        Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Nodes(x).Tag, MovieCollection)
                        s(x) = mColl.Pfad
                        mColl.Movies.Clear()
                    ElseIf TypeOf TreeViewVista1.SelectedNode.Nodes(x).Tag Is String = True Then
                        Dim mColl As String = CType(TreeViewVista1.SelectedNode.Nodes(x).Tag, String)
                        s(x) = mColl
                    End If
                Next
                TreeViewVista1.SelectedNode.Nodes.Clear()
                If TreeViewVista1.SelectedNode.Index = 1 Then
                    FavMoviesColl.Clear()
                    Dim Datenlader As New Progress_LoadFavFolder(s)
                    Datenlader.Run()
                Else
                    MoviesColl.Clear()
                    Dim Datenlader As New Progress_LoadFolder(s)
                    Datenlader.Run()
                End If

            End If
        End If


        'If MoviesColl.Count > 0 Then
        '    Dim s(MoviesColl.Count) As String

        '    For x As Integer = 0 To MoviesColl.Count - 1
        '        s(x) = MoviesColl(x).Pfad
        '        'MsgBox(m.FileNames(x))
        '    Next
        '    Clear_DG(True)
        '    Dim Datenlader As New Progress_LoadFolder(s)
        '    Datenlader.Run()
        'End If
    End Sub
    Private Sub Listeleeren_Tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Listeleeren_Tool.Click, menutool_listeleeren.Click, ToolStripMenuItem68.Click, ToolStripMenuItem34.Click
        Clear_DG(True)

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If TypeOf TreeViewVista1.SelectedNode.Tag Is MovieCollection = True Then
            Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Tag, MovieCollection)

            'If Not SelectedMovie Is Nothing Then
            InfoPanel_Movie1.Panel_Clear()
            'End If
            'For Each r As DataGridViewRow In DataGridView1.Rows
            '    Dim m As Movie = CType(r.Tag, Movie)
            '    If mColl.Movies.Contains(m) Then
            '        r.Dispose()

            '    End If

            'Next
            Movie_GridView.Rows.Clear()
            mColl.Movies.Clear()
            FavMoviesColl.Remove(mColl)
            MoviesColl.Remove(mColl)
            mColl.Node.Remove()
            'Fill_DG(mColl)
        ElseIf TypeOf TreeViewVista1.SelectedNode.Tag Is String = True Then
            TreeViewVista1.SelectedNode.Remove()
        End If

    End Sub
    Private Sub Clear_DG(ByVal Clearnodes As Boolean)
        InfoPanel_Movie1.Panel_Clear()

        Movie_GridView.Rows.Clear()
        actRows.Clear()

        'cancel_DG_selection = False
        Refresh_Toolbar_States()
        If Clearnodes = True Then
            MoviesColl.Clear()
            TreeViewVista1.Nodes(0).Nodes.Clear()
        End If


    End Sub


    Private Sub NormaleSucheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem25.Click, ToolStripMenuItem30.Click, ToolStripMenuItem45.Click, NormaleSuche_DropDownMenu_Item.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal
            'ToolStrip_Suche.Image = Toolbar16.Suche_datenbank


            'Dim m As Movie = CType(DataGridView1.SelectedRows(0).Tag, Movie)

            ToolStrip_Suche.Image = Toolbar16.loadingani2
            Exp_Suche.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Search(SelectedMovie, InfoPanel_Movie1.TB_IMDB_ID.Text, InfoPanel_Movie1.TB_Titel.Text, InfoPanel_Movie1.TB_Produktionsjahr.Text, Einstellungen.UserAbrufen.Suche_Mode)
            p.Run()


            'MetaScrapper.Suche(m, TB_Titel.Text, TB_IMDB_ID.Text, TB_Produktionsjahr.Text)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then

            Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal
            ToolStrip_Suche.Image = Toolbar16.Suche_datenbank
            Exp_Suche.Image = Toolbar16.Suche_datenbank
            Dim m As New Progress_Search(GetselectedMovies)
            m.Run()

            'MetaScrapper.Suche(li)
        End If
    End Sub
    Private Sub AusführlicheSucheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem26.Click, ToolStripMenuItem29.Click, ToolStripMenuItem46.Click, ExacteSuche_DropDownMenu_Item.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Exact
            'ToolStrip_Suche.Image = Toolbar16.search_exact1
            ToolStrip_Suche.Image = Toolbar16.loadingani2
            Exp_Suche.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Search(SelectedMovie, InfoPanel_Movie1.TB_IMDB_ID.Text, InfoPanel_Movie1.TB_Titel.Text, InfoPanel_Movie1.TB_Produktionsjahr.Text, Einstellungen.UserAbrufen.Suche_Mode)
            p.Run()

            'Dim m As Movie = CType(DataGridView1.SelectedRows(0).Tag, Movie)
            'MetaScrapper.Suche(m, TB_Titel.Text, TB_IMDB_ID.Text, TB_Produktionsjahr.Text)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then

            Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Exact
            ToolStrip_Suche.Image = Toolbar16.search_exact1
            Exp_Suche.Image = Toolbar16.search_exact1
            Dim li As New List(Of Movie)
            For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
                Dim m As Movie = CType(Movie_GridView.SelectedRows(x).Tag, Movie)
                li.Add(m)
            Next
            MetaScrapper.Suche(li)
        End If


    End Sub
    Private Sub ToolStrip_Suche_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStrip_Suche.ButtonClick, Exp_Suche.ButtonClick
        If Movie_GridView.SelectedRows.Count = 1 Then

            ToolStrip_Suche.Image = Toolbar16.loadingani2
            Exp_Suche.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Search(SelectedMovie, InfoPanel_Movie1.TB_IMDB_ID.Text, InfoPanel_Movie1.TB_Titel.Text, InfoPanel_Movie1.TB_Produktionsjahr.Text, Einstellungen.UserAbrufen.Suche_Mode)
            p.Run()
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            If Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch Then
                Dim m As New Progress_Quicksearch(GetselectedMovies)
                m.Run()
            Else
                Dim m As New Progress_Search(GetselectedMovies)
                m.Run()
            End If
        End If
        'If DataGridView1.SelectedRows.Count = 1 Then
        '    Cursor = Cursors.WaitCursor
        '    Dialog_OnlineSuche.List.Clear()
        '    Dim m As Movie = CType(DataGridView1.SelectedRows(0).Tag, Movie)
        '    Dialog_OnlineSuche.movie = m
        '    Meta.Vorschau_erstellen(TB_Titel.Text)
        '    Dialog_OnlineSuche.List.Add(m)
        '    Dialog_OnlineSuche.ToolStripButton_Abbrechen.Visible = False
        '    If Dialog_OnlineSuche.results.Count = 1 Then
        '        Meta.LoadInformations(Dialog_OnlineSuche.results(0))
        '        Meta.Save(m, Dialog_OnlineSuche.results(0))
        '    Else
        '        Cursor = Cursors.Default
        '        Dialog_OnlineSuche.Show()
        '    End If

        'ElseIf DataGridView1.SelectedRows.Count > 1 Then
        '    Dialog_OnlineSuche.List.Clear()
        '    Cursor = Cursors.WaitCursor
        '    For x As Integer = 0 To DataGridView1.SelectedRows.Count - 1
        '        Dim m As Movie = CType(DataGridView1.SelectedRows(x).Tag, Movie)
        '        Dialog_OnlineSuche.List.Add(m)
        '    Next
        '    Dialog_OnlineSuche.ToolStripButton_Abbrechen.Visible = True
        '    Dialog_OnlineSuche.ToolStripButton_Abbrechen.Text = "Alle Abbrechen (" & Dialog_OnlineSuche.List.Count & ")"
        '    Dialog_OnlineSuche.movie = Dialog_OnlineSuche.List(0)
        '    Meta.Vorschau_erstellen(Dialog_OnlineSuche.movie.Titel)
        '    Cursor = Cursors.Default
        '    Dialog_OnlineSuche.Show()

        'End If


    End Sub


    Private Sub DataGridView1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Movie_GridView.DragLeave
        SplitContainer_treepanel.Panel2.BackColor = SystemColors.Window
        Movie_GridView.BackColor = SystemColors.Window
        MyToolTip.Hide(Me)
    End Sub

    Private Sub DataGridView1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Movie_GridView.DragEnter
        Me.Focus()

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If IO.Directory.Exists(filePaths(0)) Then
                SplitContainer_treepanel.Panel2.BackColor = Color.FromArgb(242, 251, 255)
                Movie_GridView.BackColor = Color.FromArgb(242, 251, 255)
                If e.KeyState = 9 Then
                    e.Effect = DragDropEffects.Copy

                    'MyToolTip.Show(" ", Me, New Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 50))

                Else
                    e.Effect = DragDropEffects.Move

                    'MyToolTip.Show(" ", Me, New Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 50))
                End If
            End If

        Else
            MyToolTip.Hide(Me)
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Dim draghemmer As Integer = 0
    Private Sub DataGridView1_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Movie_GridView.DragOver
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            If IO.Directory.Exists(filePaths(0)) Then
                SplitContainer_treepanel.Panel2.BackColor = Color.FromArgb(242, 251, 255)
                Movie_GridView.BackColor = Color.FromArgb(242, 251, 255)
                If e.KeyState = 9 Then


                    e.Effect = DragDropEffects.Copy
                    'MyToolTip.ToolTipTitle = "Hinzufügen.."
                    'If draghemmer < 10 Then
                    '    draghemmer += 1
                    'Else
                    '    draghemmer = 0
                    '    MyToolTip.Show(" ", Me, New Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 50))

                    'End If


                Else
                    e.Effect = DragDropEffects.Move
                    'MyToolTip.ToolTipTitle = "Öffnen.."
                    'If draghemmer < 10 Then
                    '    draghemmer += 1
                    'Else
                    '    draghemmer = 0
                    '    MyToolTip.Show(" ", Me, New Point(PointToClient(MousePosition).X, PointToClient(MousePosition).Y + 50))
                    'End If
                End If
            End If

        Else
            e.Effect = DragDropEffects.None
            MyToolTip.Hide(Me)
        End If
    End Sub

    Private Sub DataGridView1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Movie_GridView.DragDrop
        'Dim m As New ToolTip
        'm.Show("Hinzufügen..", Me, PointToClient(MousePosition))
        'SplitContainer_treepanel.Panel2.BackColor = SystemColors.Window
        'DataGridView1.BackColor = SystemColors.Window
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim filePaths As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            'If IO.Directory.Exists(filePaths(0)) Then

            If e.KeyState <> 8 Then
                If Movie_GridView.RowCount > 0 Then
                    Clear_DG(True)
                End If
            End If



            If Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu = True Then
                Dim dl As New Dialog_LoadingMethode
                dl.TopMost = True
                dl.p = filePaths
                dl.ShowDialog()
            Else
                Dim Datenlader As New Progress_LoadFolder(filePaths)
                Datenlader.Run()
            End If


            'If e.KeyState <> 8 Then
            '    Daten.array.Resize(Geladeneverzeichnisse, 1)
            '    Geladeneverzeichnisse(Geladeneverzeichnisse.Length - 1) = FolderBrowserDialog1.SelectedPath
            'Else
            'Dim vorhanden As Boolean = False


            'nextx:      set_HV()
            '            'If vorhanden = False Then
            '            Enabler(False)





            'End If






        End If
    End Sub

    Public Sub TreeViewVista1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewVista1.AfterSelect

        'MsgBox(TreeViewVista1.SelectedNode.Tag.ToString)
        If TypeOf TreeViewVista1.SelectedNode.Tag Is String = True Then


            Dim st As String = CType(TreeViewVista1.SelectedNode.Tag, String)
            Dim s(1) As String
            Clear_DG(False)


            If IO.Directory.Exists(st) Then
                s(0) = st
                TreeViewVista1.SelectedNode.Remove()
                Dim Datenlader As New Progress_LoadFavFolder(s)
                Datenlader.Run()
            Else
                TreeViewVista1.SelectedNode.ImageIndex = 5
                TreeViewVista1.SelectedNode.SelectedImageIndex = 5
            End If


        ElseIf TypeOf TreeViewVista1.SelectedNode.Tag Is MovieCollection = True Then


            Movie_GridView.BringToFront()

            Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Tag, MovieCollection)
            Clear_DG(False)
            Fill_DG(mColl)

            Try
                RowFilter.run(actRows, Filter_Dropdown_OPT.Text, ToolStripTextBox1.Text)

            Catch ex As Exception

            End Try
            Me.Refresh()
            'DataGridView1.Visible = True

            Me.Cursor = Cursors.Default
            ToolStripButton_Add_Fav.Enabled = True
            ToolStripButton_del_fav.Visible = False
            If TreeViewVista1.Nodes(1).Nodes.Contains(TreeViewVista1.SelectedNode) Then
                ToolStripButton_Add_Fav.Enabled = False
                ToolStripButton_del_fav.Visible = True
            ElseIf TreeViewVista1.Nodes(1).Nodes.Count > 0 Then
                For x As Integer = 0 To TreeViewVista1.Nodes(1).Nodes.Count - 1
                    If TreeViewVista1.Nodes(1).Nodes(x).Tag.Equals(TreeViewVista1.SelectedNode.Tag) Then
                        ToolStripButton_Add_Fav.Enabled = False
                        ToolStripButton_del_fav.Visible = False
                    End If
                Next
            End If


        ElseIf IsNothing(TreeViewVista1.SelectedNode.Tag) Then
            Movie_GridView.BringToFront()
            ToolStripButton_Add_Fav.Enabled = False
            ToolStripButton_del_fav.Visible = False
            Clear_DG(False)
            If TreeViewVista1.SelectedNode.Nodes.Count > 0 Then

                For x As Integer = 0 To TreeViewVista1.SelectedNode.Nodes.Count - 1
                    If TypeOf TreeViewVista1.SelectedNode.Nodes(x).Tag Is MovieCollection = True Then

                        Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Nodes(x).Tag, MovieCollection)

                        Fill_DG(mColl)
                    End If
                Next
                Try
                    RowFilter.run(actRows, Filter_Dropdown_OPT.Text, ToolStripTextBox1.Text)

                Catch ex As Exception

                End Try
                Me.Refresh()
                'DataGridView1.Visible = True

                Me.Cursor = Cursors.Default
            End If

        End If

    End Sub

    Private Sub Fill_DG(ByVal mColl As MovieCollection)
        Me.Cursor = Cursors.AppStarting

        'DataGridView1.Visible = False

        Me.Refresh()
        Dim li As New List(Of DataGridViewRow)
        If mColl.Movies.Count > 0 Then
            For y As Integer = 0 To mColl.Movies.Count - 1
                'Dim r As New DataGridViewRow
                'r.Tag = mColl.Movies(y)
                li.Add(mColl.Movies(y).Row)
                ''Me.DataGridView1.Refresh()
                'mColl.Movies(y).Row = Me.DataGridView1.Rows(DataGridView1.Rows.Count - 1)
                'mColl.Movies(y).Refresh()
            Next
        End If
        actRows.AddRange(li.ToArray)
        Movie_GridView.ClearSelection()


    End Sub

    Private Sub Add_Fav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Add_Fav.Click
        If Not IsNothing(TreeViewVista1.SelectedNode.Tag) Then
            If TypeOf TreeViewVista1.SelectedNode.Tag Is MovieCollection = True Then
                Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Tag, MovieCollection)
                FavMoviesColl.Add(mColl)
                MoviesColl.Remove(mColl)
                Dim nNode As TreeNode = CType(TreeViewVista1.SelectedNode.Clone, TreeNode)
                mColl.Node = nNode
                TreeViewVista1.SelectedNode.Remove()
                TreeViewVista1.Nodes(1).Nodes.Add(nNode)
                TreeViewVista1.Nodes(1).Expand()
                ToolStripButton_Add_Fav.Enabled = False

            End If
        End If


    End Sub

    Private Sub ToolStripButton_del_fav_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_del_fav.Click
        If Not IsNothing(TreeViewVista1.SelectedNode.Tag) Then
            If TypeOf TreeViewVista1.SelectedNode.Tag Is MovieCollection = True Then
                Dim mColl As MovieCollection = CType(TreeViewVista1.SelectedNode.Tag, MovieCollection)
                FavMoviesColl.Remove(mColl)
                MoviesColl.Add(mColl)
                Dim nNode As TreeNode = CType(TreeViewVista1.SelectedNode.Clone, TreeNode)
                mColl.Node = nNode
                TreeViewVista1.SelectedNode.Remove()
                TreeViewVista1.Nodes(0).Nodes.Add(nNode)
                TreeViewVista1.Nodes(0).Expand()
                ToolStripButton_Add_Fav.Enabled = False
                'MsgBox(mColl.Node.ToString)

            End If
        End If

    End Sub

    Private Sub openselfolder_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openselfolder_tool.Click, ToolStripMenuItem_Ordnerdurchsuchen.Click, OrdnerDurchsuchenToolStripcontextitem.Click, ToolStripMenuItem50.Click
        If Not IsNothing(SelectedMovie) Then

            Try

                Process.Start(SelectedMovie.Pfad)
            Catch ex As Exception

            End Try
            'Try
            '    EnablerforWeb()
            '    myBrowser.Navigate(SelectedMovie.Pfad)
            'Catch ex As Exception

            'End Try
        End If

    End Sub

    Private Sub Apspielen_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Apspielen_tool.Click, ToolStripMenuItem_Abspielen.Click, AbspielenToolStripContextitem.Click, Exp_Play.ButtonClick, WiedergebenToolStripMenuItem.Click
        If Not SelectedItem Is Nothing Then
            If TypeOf SelectedItem Is Movie Then
                Try

                    Process.Start(SelectedMovie.Files(0))
                Catch ex As Exception

                End Try
            ElseIf TypeOf SelectedItem Is Episode Then
                Try

                    Process.Start(SelectedEpisode.files(0))
                Catch ex As Exception

                End Try

            End If
        End If


        'If Movie_GridView.SelectedRows.Count = 1 Then
        '    If Not IsNothing(SelectedMovie) Then



        '    End If
        'ElseIf Movie_GridView.SelectedRows.Count > 1 Then
        '    For Each m In GetselectedMovies()
        '        Try
        '            Process.Start(m.Files(0))
        '        Catch ex As Exception

        '        End Try
        '    Next

        'End If


    End Sub


    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'Try
        'Einstellungen.Save()
        Einstellungen.SavetoFile()
        Clear_Cache()

        'Catch ex As Exception
        '    MsgBox(ex.Message & vbCrLf & ex.StackTrace)

        'End Try

    End Sub
    Public Sub Clear_InfoCache()
        Dim c As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache")
        If IO.Directory.Exists(c) Then
            For Each fi In IO.Directory.GetFiles(c)
                Try
                    IO.File.Delete(fi)
                Catch ex As Exception

                End Try
            Next
            For Each fi In IO.Directory.GetDirectories(c)
                Try
                    IO.Directory.Delete(fi, True)

                Catch ex As Exception

                End Try
            Next
        End If



    End Sub

    Private Sub Clear_Cache()

        Dim c As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache")
        If IO.Directory.Exists(c) Then
            If Einstellungen.Config_Cache.Cache_Automatisch = True Then
                Dim d As Long = FolderSize.GetFolderSize(c)
                d = CLng(d / 1024)
                d = CLng(d / 1024)
                If d > Einstellungen.Config_Cache.Cache_MaxSize Then
                    Clear_InfoCache()
                End If
            Else
                Clear_InfoCache()
            End If
        End If


        c = IO.Path.Combine(Einstellungen.ChachePath, "Downloads")
        If IO.Directory.Exists(c) Then
            For Each fi In IO.Directory.GetFiles(c)
                Try
                    IO.File.Delete(fi)
                Catch ex As Exception

                End Try
            Next
        End If
        c = IO.Path.Combine(Einstellungen.ChachePath, "MovieSheet")
        If IO.Directory.Exists(c) Then
            For Each fi In IO.Directory.GetDirectories(c)
                For Each fi2 In IO.Directory.GetFiles(fi)
                    Try
                        IO.File.Delete(fi2)
                    Catch ex As Exception

                    End Try
                Next
                Try
                    IO.Directory.Delete(fi)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub


    Private Sub Main_LocationChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.LocationChanged
        If Me.WindowState = FormWindowState.Normal Then
            If Me.Location.X >= 0 And Me.Location.Y >= 0 Then

                Einstellungen.UserInterFace.win_x = Me.Location.X
                Einstellungen.UserInterFace.win_y = Me.Location.Y
                Einstellungen.UserInterFace.win_h = Me.Size.Height
                Einstellungen.UserInterFace.win_w = Me.Size.Width
            End If

            'If Dialog_OnlineSuche.Docked = True Then
            '    Dialog_OnlineSuche.Location = New Point(Me.Location.X + Me.Size.Width, Dialog_OnlineSuche.Location.Y)

            'End If
        End If

    End Sub

    Private Sub Main_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged

        If Me.WindowState = FormWindowState.Normal Then
            If Me.Location.X >= 0 And Me.Location.Y >= 0 Then

                Einstellungen.UserInterFace.win_x = Me.Location.X
                Einstellungen.UserInterFace.win_y = Me.Location.Y
                Einstellungen.UserInterFace.win_h = Me.Size.Height
                Einstellungen.UserInterFace.win_w = Me.Size.Width
            End If
        End If
    End Sub

    Private Sub InfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoToolStripMenuItem.Click, ToolStripMenuItem71.Click
        Dialog_About.ShowDialog()

    End Sub


    Private Sub Cover_Tool_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CoverFanart.Click, ToolStripMenuItem27.Click, ToolStripMenuItem44.Click, ToolStripMenuItem43.Click
        Einstellungen.UserAbrufen.Download_Mode = OnlineSearchmode.Normal
        If Movie_GridView.SelectedRows.Count = 1 Then
            'Me.IsMdiContainer = True
            'Dialog_Fanart.MdiParent = Me
            'Dialog_Fanart.TopMost = True
            'SplitContainer_treepanel.Visible = False



            exp_Download.Image = Toolbar16.loadingani2
            Cover_Tool.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Backs(SelectedMovie, InfoPanel_Movie1.TB_IMDB_ID.Text)
            p.Run()


            'Cursor = Cursors.AppStarting
            'TMDBImages.Get_ImageLinks(SelectedMovie, TB_IMDB_ID.Text, Fanartsearchmode.Dialog)
            ''Dim m As Movie = CType(DataGridView1.SelectedRows(0).Tag, Movie)
            ''Dialog_OnlineSuche.movie = m
            ''Meta.Vorschau_erstellen(TB_Titel.Text)
            ''Dialog_OnlineSuche.List.Add(m)
            ''Dialog_OnlineSuche.ToolStripButton_Abbrechen.Visible = False
            'Cursor = Cursors.Default
            'If Dialog_OnlineSuche.results.Count = 1 Then
            '    Meta.LoadInformations(Dialog_OnlineSuche.results(0))
            '    Meta.Save(m, Dialog_OnlineSuche.results(0))
            'Else
            '    
            '    Dialog_OnlineSuche.Show()
            'End If

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then

            exp_Download.Image = Toolbar16.View_extragroß
            Cover_Tool.Image = Toolbar16.View_extragroß
            Dim li As New List(Of Movie)
            For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
                Dim m As Movie = CType(Movie_GridView.SelectedRows(x).Tag, Movie)
                li.Add(m)
            Next
            TMDBImages.Get_ImageLinks(li)
        End If
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog_LoadingMethode.ShowDialog()
    End Sub

    Private Sub Ordnerhinzufügen_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordnerhinzufügen_tool.Click, OrdnerhinzufügenToolStripMenuItem.Click, ToolStripMenuItem52.Click, Exp_Öffnen_better.Click, ToolStripMenuItem66.Click

        If CommonFileDialog.IsPlatformSupported = True Then
            Dim m As New CommonOpenFileDialog
            m.IsFolderPicker = True


            'm.InitialDirectoryShellContainer = TryCast(KnownFolders.VideosLibrary, ShellContainer)
            m.Multiselect = True

            Dim groupBox As New CommonFileDialogGroupBox("Bei einem neuen Film")
            Dim checkA As New CommonFileDialogCheckBox("chkOptionA", "Online-Suche", Einstellungen.Config_Laden.Laden_Ordner_Suche)
            Dim checkB As New CommonFileDialogCheckBox("chkOptionB", "MediaInfo", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            Dim checkC As New CommonFileDialogCheckBox("chkOptionB", "neue Ordner erstellen", Einstellungen.Config_Laden.Laden_Ordner_MediaInfo)
            checkA.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_Suche
            checkB.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_MediaInfo
            checkC.IsChecked = Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner
            groupBox.Items.Add(checkA)
            groupBox.Items.Add(checkB)
            groupBox.Items.Add(checkC)
            m.Controls.Add(New CommonFileDialogSeparator())
            m.Controls.Add(groupBox)
            m.Controls.Add(New CommonFileDialogSeparator())


            Dim optBox As New CommonFileDialogGroupBox("Suchmodus")
            Dim rlist As New CommonFileDialogRadioButtonList

            Dim radioA As New CommonFileDialogRadioButtonListItem("Schnelle Suche")
            Dim radioB As New CommonFileDialogRadioButtonListItem("Normale Suche")
            Dim radioC As New CommonFileDialogRadioButtonListItem("Ausführliche Suche")
            rlist.Items.Add(radioA)
            rlist.Items.Add(radioB)
            rlist.Items.Add(radioC)

            rlist.SelectedIndex = Einstellungen.Config_Laden.Laden_Ordner_suchmodus

            'rlist.SelectedIndex = 0
            optBox.Items.Add(rlist)
            m.Controls.Add(New CommonFileDialogSeparator())
            Dim menu As New CommonFileDialogButton("Liste leeren")
            AddHandler menu.Click, AddressOf Listeleeren_Tool_Click
            If actRows.Count > 0 Then
                menu.Enabled = True
            Else
                menu.Enabled = False

            End If
            'Dim replaceList As New CommonFileDialogCheckBox("Die vorhandene Liste ersetzen")
            'Dim Favcheck As New CommonFileDialogCheckBox("chkOptionA", "Zu Favorieten hinzufügen", False)


            m.Controls.Add(optBox)


            m.Controls.Add(menu)

            'm.Controls.Add(replaceList)
            'm.Controls.Add(New CommonFileDialogSeparator())
            'm.Controls.Add(Favcheck)
            If m.ShowDialog = CommonFileDialogResult.OK Then
                Einstellungen.Config_Laden.Laden_Ordner_Suche = checkA.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = checkB.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = checkC.IsChecked
                Einstellungen.Config_Laden.Laden_Ordner_suchmodus = rlist.SelectedIndex
                's(0) = m.FileNames
                If m.FileNames.Count > 0 Then
                    Dim s(1) As String
                    ReDim s(m.FileNames.Count)
                    For x As Integer = 0 To m.FileNames.Count - 1
                        s(x) = m.FileNames(x)
                        'MsgBox(m.FileNames(x))
                    Next
                    'If Favcheck.IsChecked = False Then
                    Dim dl As New Progress_LoadFolder(s)
                    dl.Run()

                    'Else
                    '    Dim dl As New Progress_LoadFavFolder(s)
                    '    dl.Run()
                    'End If
                End If

                'set_HV()

            End If

        Else
            Dim fol As New FolderBrowserDialog
            'fol.SelectedPath = "D:\Eigene Videos\Video"
            If fol.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s(1) As String
                s(0) = fol.SelectedPath
                'set_HV()
                If Einstellungen.Config_Laden.Laden_Ordner_Einstellungenimmerneu = True Then
                    Dim dl As New Dialog_LoadingMethode
                    dl.TopMost = True
                    dl.p = s
                    dl.ShowDialog()
                Else
                    Dim Datenlader As New Progress_LoadFolder(s)
                    Datenlader.Run()
                End If
            End If

        End If


    End Sub



    Private Sub MediaInfo_tool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaInfo_tool.Click, ToolStripMenuItem_MediaInfo.Click, MediaInfoAbrufenToolStripMenuItem.Click, Exp_MediaInfo.Click, ToolStripMenuItem49.Click

        If Movie_GridView.SelectedRows.Count > 0 Then
            Dim p As New Progress_MediaInfo(GetselectedMovies)
            p.Run()
        End If

    End Sub





    Private Sub Click_CoverBackdrops_Automatisch(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CoverFanartauto.Click, ToolStripMenuItem28.Click, ToolStripMenuItem47.Click, ToolStripMenuItem72.Click
        If Movie_GridView.SelectedRows.Count >= 1 Then
            Einstellungen.UserAbrufen.Download_Mode = OnlineSearchmode.Automatisch
            exp_Download.Image = Toolbar16.Fanart_search_fast
            Cover_Tool.Image = Toolbar16.Fanart_search_fast
            Dim p As New Progress_BacksAuto(GetselectedMovies)
            p.Run()
        End If
    End Sub




#Region "Überschreiben"
    Private Sub AutomatischToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_AutomatischToolStripMenuItem.Click
        InfoPanel_Movie1.Tool_Overwrite.Text = "Automatisch"
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Automatisch
        Radio_AutomatischToolStripMenuItem.Checked = True
        Radio_ErgänzenToolStripMenuItem.Checked = False
        Radio_ErsetzenToolStripMenuItem.Checked = False
        Radio_BenutzerdefiniertToolStripMenuItem.Checked = False
        ContextMenu_Overwrite.Close()
        Einstellungen.Config_Overwrite.Save()

    End Sub
    Private Sub ErgänzenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_ErgänzenToolStripMenuItem.Click
        InfoPanel_Movie1.Tool_Overwrite.Text = "Ergänzen"
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Ergänzen
        Radio_AutomatischToolStripMenuItem.Checked = False
        Radio_ErgänzenToolStripMenuItem.Checked = True
        Radio_ErsetzenToolStripMenuItem.Checked = False
        Radio_BenutzerdefiniertToolStripMenuItem.Checked = False
        ContextMenu_Overwrite.Close()
        Einstellungen.Config_Overwrite.Save()
    End Sub


    Private Sub ErsetzenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_ErsetzenToolStripMenuItem.Click
        InfoPanel_Movie1.Tool_Overwrite.Text = "Ersetzen"
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Ersetzen
        Radio_AutomatischToolStripMenuItem.Checked = False
        Radio_ErgänzenToolStripMenuItem.Checked = False
        Radio_ErsetzenToolStripMenuItem.Checked = True
        Radio_BenutzerdefiniertToolStripMenuItem.Checked = False
        ContextMenu_Overwrite.Close()
        Einstellungen.Config_Overwrite.Save()
    End Sub


    Private Sub BenutzerdefiniertToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_BenutzerdefiniertToolStripMenuItem.Click
        InfoPanel_Movie1.Tool_Overwrite.Text = "Benutzerdefiniert"
        Einstellungen.Config_Overwrite.Mode = Overwritemode.Benutzerdefiniert
        Radio_AutomatischToolStripMenuItem.Checked = False
        Radio_ErgänzenToolStripMenuItem.Checked = False
        Radio_ErsetzenToolStripMenuItem.Checked = False
        Radio_BenutzerdefiniertToolStripMenuItem.Checked = True
        SetUserOverwriteVisible(True)
    End Sub
    Private Sub ContextMenu_Overwrite_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu_Overwrite.MouseLeave
        'Einstellungen.Config_Overwrite.Save()
        'ContextMenu_Overwrite.Close()
        ContextMenu_Overwrite.AutoClose = True
    End Sub
#End Region





    Private Sub SetUserOverwriteVisible(ByVal b As Boolean)
        ToolStripLabel3.Visible = b
        ToolStripSeparator3.Visible = b
        OverwriteMenuItem_Titel.Visible = b
        OverwriteMenuItem_Originaltitel.Visible = b
        OverwriteMenuItem_IMDB_ID.Visible = b
        OverwriteMenuItem_Darsteller.Visible = b
        OverwriteMenuItem_Regisseur.Visible = b
        OverwriteMenuItem_Autoren.Visible = b
        OverwriteMenuItem_Studios.Visible = b
        OverwriteMenuItem_Produktionsjahr.Visible = b
        OverwriteMenuItem_Produktionsland.Visible = b
        OverwriteMenuItem_Genre.Visible = b
        OverwriteMenuItem_FSK.Visible = b
        OverwriteMenuItem_Bewertung.Visible = b
        OverwriteMenuItem_Inhalt.Visible = b
        OverwriteMenuItem_Sort.Visible = b
    End Sub


    Private Sub ContextMenu_Overwrite_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_Overwrite.Opening

        Radio_AutomatischToolStripMenuItem.Checked = False
        Radio_ErgänzenToolStripMenuItem.Checked = False
        Radio_ErsetzenToolStripMenuItem.Checked = False
        Radio_BenutzerdefiniertToolStripMenuItem.Checked = False
        Select Case Einstellungen.Config_Overwrite.Mode
            Case Is = Overwritemode.Automatisch
                Radio_AutomatischToolStripMenuItem.Checked = True
                SetUserOverwriteVisible(False)
            Case Is = Overwritemode.Ergänzen
                Radio_ErgänzenToolStripMenuItem.Checked = True
                SetUserOverwriteVisible(False)
            Case Is = Overwritemode.Ersetzen
                Radio_ErsetzenToolStripMenuItem.Checked = True
                SetUserOverwriteVisible(False)
            Case Is = Overwritemode.Benutzerdefiniert
                Radio_BenutzerdefiniertToolStripMenuItem.Checked = True
                SetUserOverwriteVisible(True)
        End Select
        Einstellungen.Config_Overwrite.Load()
    End Sub




    Private Sub IMDbIDVerwendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem76.Click, IMDBVerwenden_DropDownMenu_Item.Click
        Dim s As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If Not s Is Nothing Then
            Einstellungen.UserAbrufen.useImdb = s.Checked
        End If

    End Sub

    Private Sub OrdnerUmbenennenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdnerUmbenennenToolStripMenuItem.Click, Exp_Rename.Click, ToolStripMenuItem63.Click, Tool_Rename.Click

        If Movie_GridView.SelectedRows.Count = 1 Then


            Dim m As Movie = CType(Movie_GridView.SelectedRows(0).Tag, Movie)
            Renamer.ChangeFolderName(m)
            Renamer.ChangeFileName(m)


            m.Refresh()
            InfoPanel_Movie1.TB_Ordner.Text = m.Ordner
            InfoPanel_Movie1.TB_Pfad.Text = m.Pfad
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then


            Dim p As New Progress_Rename(GetselectedMovies)
            p.Run()
        End If

    End Sub
#Region "Webbrowser"

    Public Sub OpenWebLink(ByVal s As String)
        If Einstellungen.Config_BrowserSuche.BrowserSuche_external_Browsing = False Then
            EnablerforWeb()
            myBrowser.Navigate(s)
        Else
            Try
                Process.Start(s)
            Catch ex As Exception

            End Try
        End If


    End Sub

    Private Sub EnablerforWeb(Optional ByVal s As String = "")
        'WebBrowser1.Visible = True
        Nav_Datagrid.Visible = False
        'ToolStripButton7.Image = clsFileIcon.GetDefaultIcon(clsFileIcon.defaultbrowser).ToBitmap
        'ToolStripButton7.Image = clsFileIcon.GetDefaultIcon(IO.Path.Combine(Application.StartupPath, "export.html")).ToBitmap
        ToolStripButton7.Image = clsFileIcon.GetDefaultIcon(clsFileIcon.LaunchNewBrowser).ToBitmap



        'DataGridView1.Visible = False
        Nov_line_browser.Visible = True
        Nov_line_browser.Refresh()
        If IsNothing(myBrowser) Then


            Dim wb As New WebBrowser
            SplitContainer_Infopanel.Panel1.Controls.Add(wb)
            'ListView1.Visible = False
            'DataGridView1.Visible = False

            wb.Dock = DockStyle.Fill
            wb.BringToFront()
            'myBrowser.Navigate(TreeView2.SelectedNode.Tag.ToString.Remove(0, 1))
            wb.ScriptErrorsSuppressed = True

            myBrowser = wb
        End If
        'Browser_Navigationtb.fr
        'End If

        'If s = "" Then
        '    myBrowser.Navigate(s)
        'End If
        myBrowser.Focus()
        myBrowser.Visible = True



        'Browsernavigation.Visible = True
        'Listviewnavigation.Visible = False

    End Sub

    Private Sub TableLayoutPanel1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If Movie_GridView.SelectedRows.Count = 1 Then

            'Dim iarr As Integer = get_iarr(DataGridView1.SelectedRows(0).Index)
            'rhtml = e.Data.GetData(DataFormats.Html)

            ASKCover(CStr(e.Data.GetData(DataFormats.Html)))
            'My.Computer.FileSystem.WriteAllText("export.html", CStr(e.Data.GetData(DataFormats.Html)), False)
            'Process.Start("export.html")
            'Dim pfad As String = Path.Combine(TB_Pfad.Text, "folder.jpg")
            'If File.Exists(pfad) And ReplaceCover.Checked = True Then
            '    Cover_ersetzen.Visible = True
            '    '    If MsgBox("Möchten Sie das Vorhandene Cover ersetzen?", MsgBoxStyle.YesNoCancel, "Ersetzen?") = MsgBoxResult.Yes Then
            '    '        GoTo OK
            '    '    Else
            '    '        GoTo ende
            '    '    End If
            'Else
            '    ASKCover()

            'End If
OK:
        End If
    End Sub
    Private Sub TableLayoutPanel1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Html) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub TableLayoutPanel1_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.Html) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub ASKCover(ByVal rhtml As String)

        Try
            'Dim iarr As Integer = get_iarr(DataGridView1.SelectedRows(0).Index)


            Dim pfad As String = IO.Path.Combine(InfoPanel_Movie1.TB_Pfad.Text, "folder.jpg")

            'TextBox1.Text = e.Data.GetData(DataFormats.Html)
            If rhtml.Contains("<!--StartFragment-->") Then
                Dim sp1() As String = Split(rhtml, "<!--StartFragment-->")
                If sp1.Length > 0 Then
                    Dim sp2() As String = Split(sp1(1), "<!--EndFragment-->")
                    rhtml = sp2(0)
                    'MsgBox(myresultlink)


                End If
            End If




            Dim r As String = rhtml


            Dim myresultlink As String = ""
            If r.Contains("imgurl") Then
                Dim sp1() As String = Split(r, "imgurl=")

                If sp1.Length > 0 Then
                    Dim sp2() As String = Split(sp1(1), "&")
                    myresultlink = sp2(0)
                    'MsgBox(myresultlink)


                End If
                If myresultlink = "" Then

                    GoTo normal
                End If
            Else

normal:
                If r.Contains("src") Then
                    'Dim sp1() As String = Split(r, "src=")
                    Dim match As System.Text.RegularExpressions.Match = Regex.Match(r, "src=""([^""]*)""")
                    'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
                    If match.Success = True Then
                        myresultlink = match.Groups(1).Value
                        'MsgBox(myresultlink)
                    End If
                    'If sp1.Length > 0 Then
                    '    Dim sp2() As String = Split(sp1(1), """")
                    '    myresultlink = sp2(0)



                    'End If
                    'If myresultlink = "" Then

                    '    GoTo normal
                    'End If
                End If

            End If


            'Dim myResultmovEx As New System.Text.RegularExpressions.Regex("src=""(.*)""")


            'If Not r = vbNullString Then
            '    If myResultmovEx.IsMatch(r) Then
            '        myresultlink = myResultmovEx.Match(r).Groups("titel").ToString()
            '        myresultlink = myResultmovEx.Match(r).Groups(0).ToString


            '        MsgBox(myresultlink)
            '    End If

            'Else

            'End If
            'If myresultlink.StartsWith("http://www.moviemaze.de") And Not myresultlink.Contains("poster_lg") Then
            '    myresultlink = myresultlink.Replace("poster", "poster_lg")
            'End If


            Dim dl As New Net.WebClient
            dl.DownloadFile(myresultlink, pfad)
            SelectedMovie.Cover = pfad
            SelectedMovie.RefreshCover()
            'PictureBox1.Image = img(iarr)
            'DataGridView1.SelectedRows(0).Cells(Column_Cover.Index).Value = img(iarr)

            'Dim filePaths As String = CType(e.Data.GetData(DataFormats.Html), String)

        Catch ex As Exception

        End Try
Ende:
    End Sub
    Private Sub DisablerforWeb()
        Panel_ask_selectmovie.Visible = False
        Panel_Overlay_useImage.Visible = False

        Nav_Datagrid.Visible = True
        Nov_line_browser.Visible = False
        myBrowser.Visible = False
        myBrowser.Dispose()
        myBrowser = Nothing
        MyBrowserHelpbar.Visible = False
        Me.Refresh()
    End Sub

    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        myBrowser.GoBack()
    End Sub

    Private Sub ToolStripButton6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        myBrowser.GoForward()
    End Sub

    Private Sub Nav_browser_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nov_line_browser.SizeChanged
        Browser_Navigationtb.Size = New Size(Nov_line_browser.Size.Width - 340, Browser_Navigationtb.Size.Height)
    End Sub
    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        Try
            myBrowser.Navigate(Browser_Navigationtb.Text)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub WebBrowser1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myBrowser.StatusTextChanged
        If myBrowser.StatusText = "" Then
            StatusLabel_Browser.Text = myBrowser.StatusText
        Else

            StatusLabel_Browser.Text = myBrowser.StatusText
        End If

    End Sub
    Private Sub MyBrowser_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBrowser_Close.Click
        DisablerforWeb()
    End Sub

    Private Sub ToolStripButton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.Click

        Nav_Datagrid.Visible = True
        Nov_line_browser.Visible = False
        Panel_ask_selectmovie.Visible = False
        Panel_Overlay_useImage.Visible = False
        myBrowser.Visible = False
        'myBrowser = Nothing
    End Sub
    Private Sub WebBrowser1_Navigated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles myBrowser.Navigated

        If Not Browser_Navigationtb.Items.Contains(myBrowser.Url.ToString.Replace("http://", "").Replace("www.", "")) Then
            Browser_Navigationtb.Items.Add(myBrowser.Url.ToString.Replace("http://", "").Replace("www.", ""))
        End If

        Browser_Navigationtb.Text = myBrowser.Url.ToString
        AnalyseAktUrl()

        'If Browser_Navigationtb.Text = "about:blank" Then
        '    myBrowser.Navigate("www.google.de")
        'End If
        Dim url As Uri = New Uri(Browser_Navigationtb.Text)

        If url.HostNameType = UriHostNameType.Dns Then

            ' Get the URL of the favicon
            ' url.Host will return such string as www.google.com


            Try
                Dim iconURL = "http://" & url.Host & "/favicon.ico"

                ' Download the favicon
                Dim request As System.Net.WebRequest = System.Net.HttpWebRequest.Create(iconURL)
                Dim response As System.Net.HttpWebResponse = CType(request.GetResponse(), Net.HttpWebResponse)
                Dim stream As System.IO.Stream = response.GetResponseStream()
                Dim favicon = Image.FromStream(stream)

                ' Display the favicon on PictureBox1
                MyBrowser_Favicon.Image = favicon
            Catch ex As Exception

            End Try


        Else
            MyBrowser_Favicon.Image = Toolbar16.Links
        End If

    End Sub

    Private Sub WebBrowser1_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles myBrowser.Navigating
        MyBrowser_Favicon.Image = Toolbar16.Download_aktive
        If Einstellungen.UserInterFace.myBrowser_Plugins_show = True Then


            If myBrowser.StatusText.ToString.StartsWith("download:") And Movie_GridView.SelectedRows.Count = 1 Then
                'MsgBox(e.Url.AbsolutePath.ToString)
                'Dim iarr As Integer = get_iarr(DataGridView1.SelectedRows(0).Index)
                Dim myresultlink As String = e.Url.AbsolutePath.ToString
                Dim pfad As String = IO.Path.Combine(InfoPanel_Movie1.TB_Pfad.Text, "folder.jpg")

                Dim dl As New Net.WebClient
                dl.DownloadFile(myresultlink, pfad)
                SelectedMovie.RefreshCover()

                'PictureBox1.Image = img(iarr)
                'DataGridView1.SelectedRows(0).Cells(Column_Cover.Index).Value = img(iarr)

                e.Cancel = True
            ElseIf myBrowser.StatusText.ToString.StartsWith("http://www.moviemaze.de/media/trailer/") Then
                If Not SelectedMovie Is Nothing Then
                    Dim nui As String = myBrowser.StatusText

                    Dim tags As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(myBrowser.StatusText, "(\d*),([^\.]*)\.html")
                    If tags.Success = True Then
                        nui = "http://www.moviemaze.de/media/trailer/" & tags.Groups(1).Value & ",15," & tags.Groups(2).Value & ".html"
                    End If

                    Dim s As New Progress_MovieMazeTrailer(nui)
                    s.Run()
                    s.mi = SelectedMovie

                    e.Cancel = True
                End If
            End If
        End If





    End Sub

    Private Sub WebBrowser1_NewWindow(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles myBrowser.NewWindow

        e.Cancel = True


    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles myBrowser.DocumentCompleted





        'Farbe
        'If e.Url.AbsoluteUri.ToString.StartsWith("http://filminfoorganizer") Then
        '    Nav_browser.BackColor = Color.FromArgb(18, 19, 21)
        'Else
        '    Nav_browser.BackColor = SystemColors.Window

        'End If


        'If e.Url.AbsoluteUri.ToString.StartsWith("http://www.google.de/images") Then


        '    'WebBrowser1.DocumentText = WebBrowser1.DocumentText.Replace("<img", "<img")
        '    'WebBrowser1.Refresh()
        '    Dim r As String = WebBrowser1.DocumentText

        '    'Dim sp1() As String = Split(r, "<img style=""border:1px solid #ccc;padding:1px;vertical-align:bottom"" src=""")
        '    Dim sp1() As String = Split(r, "<a c3e9adedb5186e3=""true"" ")
        '    '  style="border:1px solid #ccc;padding:1px;vertical-align:bottom" src="http://t0.gstatic.com/images?q=tbn:-GTEc1Abd9Ia3M:http://www.filme-welt.com/bilder/Avatar-Aufbruch-nach-Pandora-4.jpg" id=ipf-GTEc1Abd9Ia3M: width=140 height=79
        '    If sp1.Length > 1 Then
        '        MsgBox(sp1.Length)
        '        For x As Integer = 1 To sp1.Length - 2

        '            Dim sp2() As String = Split(sp1(x), ">")
        '            If sp2(0).ToString.StartsWith("href=""/imgres?imgurl=""") Then
        '                Dim http1() As String = Split(sp2(0), "href=""/imgres?imgurl=""")
        '                Dim http2() As String = Split(http1(1), "imgrefurl=http://")
        '                Dim rep() As String = Split(http2(0), "http://")
        '                r.Replace(sp2(0), "href=""" & http2(0) & """")

        '                TextBox1.Text &= vbCrLf & sp2(0)

        '            End If

        '        Next


        '        'myresultlink = sp2(0)
        '        'MsgBox(myresultlink)
        '    End If
        '    WebBrowser1.DocumentText = r
        'End If
        'If e.Url.AbsoluteUri.ToString.StartsWith("http://www.imdb.de/") Then
        '    Dim id As String = ""
        '    For x As Integer = 0 To myBrowser.Document.Links.Count - 1
        '        'WebBrowser1.Document.Links(x).InnerText
        '        'MsgBox(myBrowser.Document.Links(x).OuterHtml)

        '        Dim s As String = myBrowser.Document.Links(x).OuterHtml
        '        Dim t As String = ""
        '        If myBrowser.Document.Links(x).OuterHtml.ToLower.StartsWith("<a href=""/filme/") Then



        '            Dim myResultmovEx As New System.Text.RegularExpressions.Regex("<a href=""/filme/(.*)\.html", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or RegexOptions.Multiline)
        '            If myResultmovEx.IsMatch(s) Then
        '                id = myResultmovEx.Match(s).Groups(1).ToString
        '            End If
        '            myBrowser.Document.Links(x).OuterHtml &= "<span style=""color: #6aa84f;"">  <a href=""/media/poster/" & id & ".html""><img src=""http://2.bp.blogspot.com/_DirvctEVGZM/TCXiIDaVFuI/AAAAAAAAANo/BAPqPyQOTPQ/s1600/staty_16_cover_test.png"" border=""0"">Poster</a></span>"
        '        End If

        '        If myBrowser.Document.Links(x).OuterHtml.ToLower.StartsWith("<a href=""/media/wallpaper/") And Not id = "" Then

        '            't = _
        '            '       New Regex( _
        '            '           "/media/wallpaper/.*\.html", _
        '            '           RegexOptions.IgnoreCase Or RegexOptions.Multiline _
        '            '       ).Replace(s, "http://www.moviemaze.de/media/poster/" & id & ".html")
        '            myBrowser.Document.Links(x).OuterHtml = "<a href=""/media/poster/" & id & ".html"">Poster</a>"

        '        End If
        '        'WebBrowser1.Refresh()

        '        'http://www.moviemaze.de/filme/3367/poster_lg02.jpg


        '        'MsgBox("Vorher: " & vbCrLf & s & vbCrLf & vbCrLf & "Nachher: " & vbCrLf & t)
        '        ' myBrowser.Document.Links(x).OuterHtml = "<a href=""downloadhttp://www.moviemaze.de/filme/" & id & "/poster_lg" & number & ".jpg""><img src=""http://lh6.ggpht.com/_DirvctEVGZM/Szqv-ZEujlI/AAAAAAAAABY/QNb7NBoN1vM/App030.png""></a>" & t & ""
        '        'myBrowser.Document.Links(x).OuterHtml = "<table width=""150"" height=""213"" border=""0"" cellpadding=""0"" cellspacing=""0"" background=""http://www.moviemaze.de/filme/" & id & "/poster" & number & ".jpg"">" & vbCrLf & _
        '        '                                            "<tr>" & vbCrLf & _
        '        '                                                "<td width=""126"" height=""189"">&nbsp;</td>" & vbCrLf & _
        '        '                                                "<td width=""24"">&nbsp;</td>" & vbCrLf & _
        '        '                                            "</tr>" & vbCrLf & _
        '        '                                            "<tr>" & vbCrLf & _
        '        '                                                "<td height=""24"">&nbsp;</td>" & vbCrLf & _
        '        '                                                "<td><img src=""file:///D|/Eigene Dokumente/Html/Anleitung/status1.png"" width=""24"" height=""24""/></td>" & vbCrLf & _
        '        '                                            "</tr>" & vbCrLf & _
        '        '                                        "</table>"

        '    Next
        'End If
        If Einstellungen.UserInterFace.myBrowser_Plugins_show = True Then


            If e.Url.AbsoluteUri.ToString.StartsWith("http://www.moviemaze.de/suche/result.phtml") Then
                Dim id As String = ""
                For x As Integer = 0 To myBrowser.Document.Links.Count - 1
                    'WebBrowser1.Document.Links(x).InnerText
                    'MsgBox(myBrowser.Document.Links(x).OuterHtml)

                    Dim s As String = myBrowser.Document.Links(x).OuterHtml
                    Dim t As String = ""
                    If myBrowser.Document.Links(x).OuterHtml.ToLower.StartsWith("<a href=""/filme/") Then



                        Dim myResultmovEx As New System.Text.RegularExpressions.Regex("<a href=""/filme/(.*)\.html", System.Text.RegularExpressions.RegexOptions.IgnoreCase Or RegexOptions.Multiline)
                        If myResultmovEx.IsMatch(s) Then
                            id = myResultmovEx.Match(s).Groups(1).ToString
                        End If
                        myBrowser.Document.Links(x).OuterHtml &= "<span style=""color: #6aa84f;"">  <a href=""/media/poster/" & id & ".html""><img src=""http://2.bp.blogspot.com/_DirvctEVGZM/TCXiIDaVFuI/AAAAAAAAANo/BAPqPyQOTPQ/s1600/staty_16_cover_test.png"" border=""0"">Poster</a></span>"
                    End If

                    If myBrowser.Document.Links(x).OuterHtml.ToLower.StartsWith("<a href=""/media/wallpaper/") And Not id = "" Then

                        't = _
                        '       New Regex( _
                        '           "/media/wallpaper/.*\.html", _
                        '           RegexOptions.IgnoreCase Or RegexOptions.Multiline _
                        '       ).Replace(s, "http://www.moviemaze.de/media/poster/" & id & ".html")
                        myBrowser.Document.Links(x).OuterHtml = "<a href=""/media/poster/" & id & ".html"">Poster</a>"

                    End If
                    'WebBrowser1.Refresh()

                    'http://www.moviemaze.de/filme/3367/poster_lg02.jpg


                    'MsgBox("Vorher: " & vbCrLf & s & vbCrLf & vbCrLf & "Nachher: " & vbCrLf & t)
                    ' myBrowser.Document.Links(x).OuterHtml = "<a href=""downloadhttp://www.moviemaze.de/filme/" & id & "/poster_lg" & number & ".jpg""><img src=""http://lh6.ggpht.com/_DirvctEVGZM/Szqv-ZEujlI/AAAAAAAAABY/QNb7NBoN1vM/App030.png""></a>" & t & ""
                    'myBrowser.Document.Links(x).OuterHtml = "<table width=""150"" height=""213"" border=""0"" cellpadding=""0"" cellspacing=""0"" background=""http://www.moviemaze.de/filme/" & id & "/poster" & number & ".jpg"">" & vbCrLf & _
                    '                                            "<tr>" & vbCrLf & _
                    '                                                "<td width=""126"" height=""189"">&nbsp;</td>" & vbCrLf & _
                    '                                                "<td width=""24"">&nbsp;</td>" & vbCrLf & _
                    '                                            "</tr>" & vbCrLf & _
                    '                                            "<tr>" & vbCrLf & _
                    '                                                "<td height=""24"">&nbsp;</td>" & vbCrLf & _
                    '                                                "<td><img src=""file:///D|/Eigene Dokumente/Html/Anleitung/status1.png"" width=""24"" height=""24""/></td>" & vbCrLf & _
                    '                                            "</tr>" & vbCrLf & _
                    '                                        "</table>"

                Next
            End If

            If e.Url.AbsoluteUri.ToString.StartsWith("http://www.moviemaze.de/media/poster/") Then

                For x As Integer = 0 To myBrowser.Document.Links.Count - 1
                    'WebBrowser1.Document.Links(x).InnerText
                    If myBrowser.Document.Links(x).OuterHtml.ToLower.StartsWith("<a href=""/media/poster/") Then
                        Dim s As String = myBrowser.Document.Links(x).OuterHtml
                        Dim t As String = ""
                        Dim id As String = ""
                        Dim number As String = ""
                        Dim myResultmovEx As New System.Text.RegularExpressions.Regex("src=""/filme/(\d{4})/poster(\d{2})", RegexOptions.IgnoreCase Or RegexOptions.Multiline)

                        If myResultmovEx.IsMatch(s) Then
                            id = myResultmovEx.Match(s).Groups(1).ToString
                            number = myResultmovEx.Match(s).Groups(2).ToString
                            '   MsgBox(number & vbCrLf & id)

                        End If

                        'http://www.moviemaze.de/filme/3367/poster_lg02.jpg
                        t = _
                               New System.Text.RegularExpressions.Regex( _
                                   "/media/poster/.*\.html", _
                                   System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Multiline _
                               ).Replace(s, "http://www.moviemaze.de/filme/" & id & "/poster_lg" & number & ".jpg")

                        'MsgBox("Vorher: " & vbCrLf & s & vbCrLf & vbCrLf & "Nachher: " & vbCrLf & t)
                        ' myBrowser.Document.Links(x).OuterHtml = "<a href=""downloadhttp://www.moviemaze.de/filme/" & id & "/poster_lg" & number & ".jpg""><img src=""http://lh6.ggpht.com/_DirvctEVGZM/Szqv-ZEujlI/AAAAAAAAABY/QNb7NBoN1vM/App030.png""></a>" & t & ""
                        'myBrowser.Document.Links(x).OuterHtml = "<table width=""150"" height=""213"" border=""0"" cellpadding=""0"" cellspacing=""0"" background=""http://www.moviemaze.de/filme/" & id & "/poster" & number & ".jpg"">" & vbCrLf & _
                        '                                            "<tr>" & vbCrLf & _
                        '                                                "<td width=""126"" height=""189"">&nbsp;</td>" & vbCrLf & _
                        '                                                "<td width=""24"">&nbsp;</td>" & vbCrLf & _
                        '                                            "</tr>" & vbCrLf & _
                        '                                            "<tr>" & vbCrLf & _
                        '                                                "<td height=""24"">&nbsp;</td>" & vbCrLf & _
                        '                                                "<td><img src=""file:///D|/Eigene Dokumente/Html/Anleitung/status1.png"" width=""24"" height=""24""/></td>" & vbCrLf & _
                        '                                            "</tr>" & vbCrLf & _
                        '                                        "</table>"
                        myBrowser.Document.Links(x).OuterHtml = "<p>" & t & "</p><p><a href=""download:http://www.moviemaze.de/filme/" & id & "/poster_lg" & number & ".jpg""><img src=""" & DLBoxHTMlImage.AbsoluteUri & """ border=""0""></a></p>"
                    End If
                    'WebBrowser1.Refresh()

                Next
            End If

            'WebBrowser1.Document.OpenNew(True)
            'WebBrowser1.DocumentText = r


        End If
    End Sub
    Private Function DLBoxHTMlImage() As Uri
        Dim s As String = IO.Path.Combine(Einstellungen.ChachePath, "dlicon.png")
        Try
            If IO.File.Exists(s) Then
                Return New Uri(s)
            Else
                Dim i As Image = My.Resources.Downloadboxbig
                i.Save(s, System.Drawing.Imaging.ImageFormat.Png)
                i.Dispose()
                Return New Uri(s)
            End If
        Catch ex As Exception
            Return New Uri(s)
        End Try
    End Function
#End Region









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










    Private Sub MovienfoXBMCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovienfoXBMCToolStripMenuItem.Click, ToolStripMenuItem10.Click, ToolStripMenuItem37.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.Save(Savemode.nfo)
            InfoPanel_Movie1.Load_item(SelectedMovie)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Saver(GetselectedMovies, Savemode.nfo)

            p.Run()
        End If
    End Sub

    Private Sub MoviesheetVorbereitenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem75.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.SaveFile(Savemode.nfo)
            If Not IO.File.Exists(IO.Path.Combine(SelectedMovie.Pfad, "fanart.jpg")) Then
                SelectedMovie.Backdrops = Backdropsarr(SelectedMovie.Pfad)
                If SelectedMovie.Backdrops.Count > 0 Then
                    IO.File.Copy(SelectedMovie.Backdrops(0), IO.Path.Combine(SelectedMovie.Pfad, "fanart.jpg"))
                End If
            End If


        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Me.Cursor = Cursors.WaitCursor
            Dim li As New List(Of Movie)
            For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
                Dim m As Movie = CType(Movie_GridView.SelectedRows(x).Tag, Movie)
                m.SaveFile(Savemode.nfo)
                If Not IO.File.Exists(IO.Path.Combine(m.Pfad, "fanart.jpg")) Then
                    m.Backdrops = Backdropsarr(m.Pfad)
                    If m.Backdrops.Count > 0 Then
                        IO.File.Copy(m.Backdrops(0), IO.Path.Combine(m.Pfad, "fanart.jpg"))
                    End If
                End If
            Next
            Me.Cursor = Cursors.Default
            MsgBox("Es wurden " & Movie_GridView.SelectedRows.Count & " Filme vorbereitet.")
        End If
    End Sub

    Private Sub ThumbnailCreatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThumbnailsErstellenToolStripMenuItem.Click, ToolStripMenuItem48.Click, ToolStripMenuItem73.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            exp_Download.Image = Toolbar16.loadingani2
            Cover_Tool.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Thumb(SelectedMovie)
            p.Run()

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            'Me.Cursor = Cursors.WaitCursor
            Dim sh As New Progress_SheetCreat(GetselectedMovies)

            sh.Run()
            'For x As Integer = 0 To DataGridView1.SelectedRows.Count - 1
            '    Dim m As Movie = CType(DataGridView1.SelectedRows(x).Tag, Movie)
            '    m.SaveFile(Savemode.nfo)
            '    If Not IO.File.Exists(IO.Path.Combine(m.Pfad, "fanart.jpg")) Then
            '        m.Backdrops = Backdropsarr(m.Pfad)
            '        If m.Backdrops.Count > 0 Then
            '            IO.File.Copy(m.Backdrops(0), IO.Path.Combine(m.Pfad, "fanart.jpg"))
            '        End If
            '    End If
            'Next
            'Me.Cursor = Cursors.Default
            'MsgBox("Es wurden " & DataGridView1.SelectedRows.Count & " Filme vorbereitet.")
        End If
    End Sub
    'Private Sub DataGridView1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.MouseLeave
    '    MyToolTip.Hide(Me)
    'End Sub
    'Private Sub DataGridView1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.MouseMove, DataGridView1.MouseEnter

    '    Dim hti As DataGridView.HitTestInfo = DataGridView1.HitTest(MousePosition.X, MousePosition.Y)

    '    If hti.Type = DataGridViewHitTestType.Cell Then
    '        Dim m As Movie = CType(DataGridView1.Rows(hti.RowIndex).Tag, Movie)
    '        'MsgBox("LOL")

    '        If Not hti.RowIndex = CDbl(MyToolTip.Tag) Then

    '            MyToolTip.Tag = hti.RowIndex
    '            MyToolTip.ToolTipTitle = m.Titel
    '            MyToolTip.Hide(Me)
    '            MyToolTip.Show(m.State_Cover_tip & vbCrLf & m.State_Backdrop_tip & vbCrLf & m.State_Info_tip & vbCrLf & m.State_MediaInfo_tip, Me, _
    '                           New Point(MousePosition.X + 60, MousePosition.Y + 60))

    '        End If
    '        'If DataGridView1.Rows(hti.RowIndex).Selected = False Then
    '        '    DataGridView1.ClearSelection()
    '        '    DataGridView1.Rows(hti.RowIndex).Selected = True
    '        'End If
    '        'If DataGridView1.SelectedRows.Count = 1 Then
    '        '    AbspielenToolStripContextitem.Enabled = True
    '        '    OrdnerDurchsuchenToolStripcontextitem.Enabled = True
    '        'Else
    '        '    AbspielenToolStripContextitem.Enabled = False
    '        '    OrdnerDurchsuchenToolStripcontextitem.Enabled = False
    '        'End If
    '        'ContextMenu_Rows.Show(DataGridView1.PointToScreen(e.Location))

    '    End If
    'End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Movie_GridView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim hti As DataGridView.HitTestInfo = Movie_GridView.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then

                If Movie_GridView.Rows(hti.RowIndex).Selected = False Then
                    Movie_GridView.ClearSelection()
                    Movie_GridView.Rows(hti.RowIndex).Selected = True
                End If
                If Movie_GridView.SelectedRows.Count = 1 Then
                    AbspielenToolStripContextitem.Enabled = True
                    OrdnerDurchsuchenToolStripcontextitem.Enabled = True
                Else
                    AbspielenToolStripContextitem.Enabled = False
                    OrdnerDurchsuchenToolStripcontextitem.Enabled = False
                End If

                If hti.ColumnIndex = 0 Then
                    ContextMenu_Flags.Show(Movie_GridView.PointToScreen(e.Location))
                Else
                    ContextMenu_Rows.Show(Movie_GridView.PointToScreen(e.Location))
                End If
            ElseIf hti.Type = DataGridViewHitTestType.ColumnHeader Then
                ContextMenu_Columns.Items.Clear()
                ContextMenu_Columns.Items.Add("Spalten...", Nothing, AddressOf SpaltenToolStripMenuItem1_Click)
                Dim tr As New ToolStripSeparator
                ContextMenu_Columns.Items.Add(tr)
                For x As Integer = 0 To Movie_GridView.Columns.Count - 1

                    Dim d As New System.Windows.Forms.ToolStripMenuItem
                    d.Text = Movie_GridView.Columns(x).HeaderText
                    d.Checked = Movie_GridView.Columns(x).Visible
                    d.Tag = x
                    AddHandler d.Click, AddressOf ColumnVisChange
                    ContextMenu_Columns.Items.Add(d)
                Next
                ContextMenu_Columns.Show(Movie_GridView.PointToScreen(e.Location))
            End If
        ElseIf e.Button = Windows.Forms.MouseButtons.Left Then

            Dim hti As DataGridView.HitTestInfo = Movie_GridView.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then
                If hti.ColumnIndex = 0 Then
                    If Movie_GridView.Rows(hti.RowIndex).Cells(hti.ColumnIndex).Value.ToString = "0" Then
                        Dim m As Movie = CType(Movie_GridView.Rows(hti.RowIndex).Tag, Movie)
                        If Not m Is Nothing Then
                            m.flag = 3
                            m.Refresh()
                            Panel_flagquestion.Visible = False
                        End If
                    Else
                        Dim m As Movie = CType(Movie_GridView.Rows(hti.RowIndex).Tag, Movie)
                        If Not m Is Nothing Then
                            m.flag = 0
                            m.Refresh()
                            Panel_flagquestion.Visible = False
                        End If
                    End If
                End If
            End If


        End If
    End Sub
#Region "Spalten"
    Private Function GetDisplayColumn(ByVal Index As Integer) As DataGridViewColumn
        For x As Integer = 0 To Movie_GridView.ColumnCount - 1
            If Movie_GridView.Columns(x).DisplayIndex = Index Then
                Return Movie_GridView.Columns(x)
            End If
        Next
        Return Nothing

    End Function

    Private Sub TreeViewVista1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView_Opt_Columns.DragOver
        Dim loc As Point = (CType(sender, TreeView)).PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
        Dim destNode As TreeNode = (CType(sender, TreeView)).GetNodeAt(loc)

        If Not node Is destNode Then

            If Not node.Index = destNode.Index + 1 Then



                If node.Parent Is Nothing Then
                    node.TreeView.Nodes.Remove(node)
                Else
                    node.Parent.Nodes.Remove(node)
                End If

                If destNode.Parent Is Nothing Then
                    destNode.TreeView.Nodes.Insert(destNode.Index + 1, node)
                Else
                    destNode.Parent.Nodes.Insert(destNode.Index + 1, node)
                End If
                TreeView_Opt_Columns.SelectedNode = node
                TreeView_Opt_Columns.Refresh()
                Dim r As DataGridViewColumn = CType(node.Tag, DataGridViewColumn)
                Movie_GridView.Columns(r.Index).DisplayIndex = node.Index
            End If
        End If
    End Sub
    Private Sub tvw_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles TreeView_Opt_Columns.ItemDrag
        TreeView_Opt_Columns.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvw_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_Opt_Columns.DragEnter
        e.Effect = DragDropEffects.Move

    End Sub

    Private Sub tvw_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_Opt_Columns.DragDrop
        Dim loc As Point = (CType(sender, TreeView)).PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
        Dim destNode As TreeNode = (CType(sender, TreeView)).GetNodeAt(loc)

        If Not node Is destNode Then



            If node.Parent Is Nothing Then
                node.TreeView.Nodes.Remove(node)
            Else
                node.Parent.Nodes.Remove(node)
            End If

            If destNode.Parent Is Nothing Then
                destNode.TreeView.Nodes.Insert(destNode.Index + 1, node)
            Else
                destNode.Parent.Nodes.Insert(destNode.Index + 1, node)
            End If
            TreeView_Opt_Columns.SelectedNode = node
            Dim r As DataGridViewColumn = CType(node.Tag, DataGridViewColumn)
            Movie_GridView.Columns(r.Index).DisplayIndex = node.Index
            'r.DisplayIndex = node.Index
        End If
    End Sub

    Private Sub TreeViewVista1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_Opt_Columns.AfterCheck
        Dim r As DataGridViewColumn = CType(e.Node.Tag, DataGridViewColumn)
        Movie_GridView.Columns(r.Index).Visible = e.Node.Checked
    End Sub
    Private Sub SpaltenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpaltenToolStripMenuItem1.Click, ToolStripButton13.Click, SpaltenToolStripMenuItem.Click, SpaltenToolStripMenuItem2.Click, ToolStripMenuItem53.Click
        If TreeView_Opt_Columns.Visible = False Then
            ToolStripButton13.Checked = True
            TreeView_Opt_Columns.Nodes.Clear()
            For x As Integer = 0 To Movie_GridView.ColumnCount - 1
                Dim r As DataGridViewColumn = GetDisplayColumn(x)
                Dim m As New TreeNode
                m.Text = r.HeaderText
                m.Tag = r
                m.Checked = r.Visible

                TreeView_Opt_Columns.Nodes.Add(m)
            Next
            TreeView_Opt_Columns.Visible = True
            TreeViewVista1.Visible = False
            SplitContainer_treepanel.Panel1Collapsed = False
            SplitContainer_Infopanel.Panel2Collapsed = True
            Nov_Main.Enabled = False
            Nav_Menu.Enabled = False
            Nav_Treeview.Enabled = False
        Else
            TreeViewVista1.Visible = True
            ToolStripButton13.Checked = False
            TreeView_Opt_Columns.Visible = False
            Nov_Main.Enabled = True
            Nav_Menu.Enabled = True
            Nav_Treeview.Enabled = True
            SplitContainer_treepanel.Panel1Collapsed = False
            SplitContainer_Infopanel.Panel2Collapsed = False
            Me.Update()
            Me.Refresh()
        End If


    End Sub
#End Region



    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatusleisteToolStripMenuItem.Click, ToolStripMenuItem55.Click, ToolStripMenuItem7.Click
        MyStatusStrip.Visible = Not MyStatusStrip.Visible
    End Sub

    Private Sub WerkzeugleisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WerkzeugleisteToolStripMenuItem1.Click, WerkzeugeToolStripMenuItem.Click, WerkzeugleisteToolStripMenuItem.Click
        If Nov_Main.Visible Or Nov_Main_alt.Visible Then
            Einstellungen.Config_Design.Dynamische = Nov_Main_alt.Visible
            Nov_Main.Visible = False
            Nov_Main_alt.Visible = False
        Else
            Nov_Main.Visible = Not Einstellungen.Config_Design.Dynamische
            Nov_Main_alt.Visible = Einstellungen.Config_Design.Dynamische
        End If
        'Nov_Main.Visible = Not Nov_Main.Visible

        'Nov_Main_alt.Visible = Not Nov_Main_alt.Visible
        'Refresh_Toolbar_States()
    End Sub

    Private Sub Selectletter(ByVal a As String)
        If Movie_GridView.RowCount > 0 Then
            For x As Integer = 0 To Movie_GridView.RowCount - 1
                If Movie_GridView.Rows(x).Cells(Column_Titel.Index).Value.ToString.ToLower.StartsWith(a) Then
                    Movie_GridView.ClearSelection()
                    Movie_GridView.Rows(x).Selected = True
                    Movie_GridView.FirstDisplayedScrollingRowIndex = Movie_GridView.Rows(x).Index
                    Exit Sub
                End If
            Next
        End If

    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Movie_GridView.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            Exit Sub
        End If
        If e.Control = False And e.Alt = False Then


            Select Case e.KeyCode
                Case Is = Keys.A
                    Selectletter("a")
                Case Is = Keys.B
                    Selectletter("b")
                Case Is = Keys.C
                    Selectletter("c")
                Case Is = Keys.D
                    Selectletter("d")
                Case Is = Keys.E
                    Selectletter("e")
                Case Is = Keys.F
                    Selectletter("f")
                Case Is = Keys.G
                    Selectletter("g")
                Case Is = Keys.H
                    Selectletter("h")
                Case Is = Keys.I
                    Selectletter("i")
                Case Is = Keys.J
                    If Panel_flagquestion.Visible = True Then
                        If Not IsNothing(SelectedMovie) Then
                            SelectedMovie.flag = 0
                            SelectedMovie.Refresh()
                        End If
                        Panel_flagquestion.Visible = False
                    Else
                        Selectletter("j")
                    End If
                Case Is = Keys.K
                    Selectletter("k")
                Case Is = Keys.L
                    Selectletter("l")
                Case Is = Keys.M
                    Selectletter("m")
                Case Is = Keys.N
                    If Panel_flagquestion.Visible = True Then
                        Panel_flagquestion.Visible = False
                    Else
                        Selectletter("n")
                    End If

                Case Is = Keys.O
                    Selectletter("o")
                Case Is = Keys.P
                    Selectletter("p")
                Case Is = Keys.Q
                    Selectletter("q")
                Case Is = Keys.R
                    Selectletter("r")
                Case Is = Keys.S
                    Selectletter("s")
                Case Is = Keys.T
                    Selectletter("t")
                Case Is = Keys.U
                    Selectletter("u")
                Case Is = Keys.V
                    Selectletter("v")
                Case Is = Keys.W
                    Selectletter("w")
                Case Is = Keys.X
                    Selectletter("x")
                Case Is = Keys.Y
                    Selectletter("y")
                Case Is = Keys.Z
                    Selectletter("z")
                Case Is = Keys.Apps
                    Try
                        ContextMenu_Rows.Show(Movie_GridView.RectangleToScreen(Movie_GridView.GetRowDisplayRectangle(Movie_GridView.SelectedRows(0).Index, True)).X, Movie_GridView.RectangleToScreen(Movie_GridView.GetRowDisplayRectangle(Movie_GridView.SelectedRows(0).Index, True)).Y + Movie_GridView.RowTemplate.Height)

                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub


    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog_MovetoNewFolder.ShowDialog()

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        Try
            Process.Start(myBrowser.Url.ToString)
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ToolStripButton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton14.Click
        If myBrowser Is Nothing Then

            Try
                OpenWebLink("http://filminfoorganizer.blogspot.com")
            Catch ex As Exception

            End Try
        Else
            EnablerforWeb()
            myBrowser.Visible = True
            AnalyseAktUrl()
        End If
    End Sub

    Private Sub UpdateToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem1.Click, UpdateToolStripMenuItem.Click, ToolStripMenuItem69.Click
        If Panel_Update.Visible = False Then
            Dim p As New Progress_CheckForUpdates
            p.Dialog = True
            p.Run()
        Else
            Dialog_Update.Show()

        End If



        'Updater.Check_For_Updates(True)


    End Sub


    Private Sub DataGridView1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Movie_GridView.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then


            If Not Movie_GridView.SortedColumn Is Nothing Then
                For x As Integer = 0 To Movie_GridView.RowCount - 1
                    If Movie_GridView.Rows(x).Displayed = True Then
                        Dim t As String = ""
                        Select Case Movie_GridView.SortedColumn.Index
                            Case Is = Column_Rate_Backdrops.Index 'Or Column_Rate_Cover.Index Or Column_Rate_Info.Index Or Column_Rate_MediaInfo.Index
                            Case Is = Column_Rate_Cover.Index
                            Case Is = Column_Rate_Info.Index
                            Case Is = Column_Rate_MediaInfo.Index
                            Case Is = Column_Flags.Index
                            Case Is = Column_Fortschritt.Index
                            Case Else
                                If Not Movie_GridView.Rows(x).Cells(Movie_GridView.SortedColumn.Index).Value Is Nothing And Not Movie_GridView.Rows(x).Cells(Movie_GridView.SortedColumn.Index).Value.ToString = "" Then
                                    t = Movie_GridView.Rows(x).Cells(Movie_GridView.SortedColumn.Index).Value.ToString.Substring(0, 1)
                                End If
                        End Select



                        MyToolTip.ToolTipIcon = ToolTipIcon.None

                        MyToolTip.ToolTipTitle = ""
                        If Not t = "" Then
                            MyToolTip.Show(t, SplitContainer_Infopanel, Movie_GridView.Location.X + Movie_GridView.Size.Width - 20, Movie_GridView.Location.Y, 100)

                        End If

                        Exit For

                    End If
                Next
            End If
        End If
    End Sub

    Private Sub SchnelleSucheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem24.Click, ToolStripMenuItem31.Click, ToolStripMenuItem33.Click, SchnelleSuche_DropDownMenu_Item.Click
        Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch

        If Movie_GridView.SelectedRows.Count = 1 Then
            ToolStrip_Suche.Image = Toolbar16.loadingani2
            Exp_Suche.Image = Toolbar16.loadingani2
            Dim p As New Progress_one_Search(SelectedMovie, InfoPanel_Movie1.TB_IMDB_ID.Text, InfoPanel_Movie1.TB_Titel.Text, InfoPanel_Movie1.TB_Produktionsjahr.Text, Einstellungen.UserAbrufen.Suche_Mode)
            p.Run()
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Exp_Suche.Image = Toolbar16.search_schnell1
            ToolStrip_Suche.Image = Toolbar16.search_schnell1
            Dim dl As New Progress_Quicksearch(GetselectedMovies)
            dl.Run()
        End If






    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNothing(SelectedMovie) Then
            SelectedMovie.flag = 0
            SelectedMovie.Refresh()
        End If
        Panel_flagquestion.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            AusführlicheSucheToolStripMenuItem_Click(Me, New EventArgs)
        End If
        Panel_flagquestion.Visible = False
    End Sub

    Private Sub GenreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem79.Click, Genre_DropDownMenu_Item.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            'Einstellungen.UserAbrufen.sMode = OnlineSearchmode.Normal
            'ToolStrip_Suche.Image = Toolbar16.Suche_datenbank
            Dim g As String = MetaScrapper.GetGenres(InfoPanel_Movie1.TB_IMDB_ID.Text)
            If g = "" Then
            Else
                InfoPanel_Movie1.TB_Genre.Text = Einstellungen.GenreFilter.ChangeGenre(g)

            End If

            'Dim m As Movie = CType(DataGridView1.SelectedRows(0).Tag, Movie)
            'Meta.Suche(m, TB_Titel.Text, TB_IMDB_ID.Text)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            'Dim dl As New Laden
            'dl.Text = "Genre"
            'dl.ProgressBar1.Value = 0
            'dl.Label1.Text = "Rufe Genre ab..."
            'dl.Refresh()
            'dl.Show()
            Dim li As New List(Of Movie)
            For x As Integer = 0 To Movie_GridView.SelectedRows.Count - 1
                'Laden.ProgressBar1.Value = 0
                'Laden.Label1.Text = "Rufe Genre ab..."

                Dim m As Movie = CType(Movie_GridView.SelectedRows(x).Tag, Movie)
                li.Add(m)
            Next
            'For x As Integer = 0 To li.Count - 1
            '    dl.ProgressBar1.Value = CInt(((x + 1) / li.Count) * 100)
            '    dl.Label1.Text = "Rufe Genre ab... " & x & "/" & li.Count
            '    dl.Refresh()
            '    Dim g As String = Meta.GetGenres(li(x).IMDB_ID)
            '    If g = "" Then
            '    Else
            '        li(x).Genre = g
            '        li(x).Refresh()
            '        li(x).SaveFile()
            '    End If
            'Next
            'dl.Hide()
            'dl.Dispose()
            Dim dl As New Progress_Genre(li)
            dl.Run()
            'Meta.Suche(li)
        End If
    End Sub

    Private Sub ToolStripButton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For x As Integer = 0 To Movie_GridView.Rows.Count - 1
            Movie_GridView.Rows(x).Visible = False
            Me.Refresh()
            For y As Integer = 0 To Movie_GridView.Rows.Count - 1
                If Not x = y Then


                    If Movie_GridView.Rows(x).Cells(Column_IMDB_ID.Index).Value.ToString = Movie_GridView.Rows(y).Cells(Column_IMDB_ID.Index).Value.ToString Or _
                       Movie_GridView.Rows(x).Cells(Column_Titel.Index).Value.ToString = Movie_GridView.Rows(y).Cells(Column_Titel.Index).Value.ToString Then

                        Movie_GridView.Rows(x).Visible = True
                        Exit For
                    End If
                End If
            Next
        Next
        MsgBox("Filter wurde angewendet")
    End Sub
#Region "Speichern"

    Private Sub Save_As_Info(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoxmlToolStripMenuItem.Click, ToolStripMenuItem3.Click, ToolStripMenuItem35.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.Save(Savemode.Info)
            InfoPanel_Movie1.Load_item(SelectedMovie)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Saver(GetselectedMovies, Savemode.Info)

            p.Run()
        End If
    End Sub

    Private Sub MymoviesxmlToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MymoviesxmlToolStripMenuItem.Click, ToolStripMenuItem9.Click, ToolStripMenuItem36.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.Save(Savemode.mymovies)
            InfoPanel_Movie1.Load_item(SelectedMovie)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Saver(GetselectedMovies, Savemode.mymovies)

            p.Run()
        End If
    End Sub

    Private Sub MoviedvdidxmlWindowsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoviedvdidxmlWindowsToolStripMenuItem.Click, ToolStripMenuItem11.Click, ToolStripMenuItem38.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.Save(Savemode.DVDInfo)
            InfoPanel_Movie1.Load_item(SelectedMovie)
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Saver(GetselectedMovies, Savemode.DVDInfo)

            p.Run()
        End If
    End Sub
    Private Sub Speichern_Tool_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Speichern_Tool.ButtonClick, ToolStripMenuItem1.Click, ToolStripMenuItem_Speichern.Click, exp_speichern.Click, exp_menu_save.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(True)
            InfoPanel_Movie1.Load_item(SelectedMovie)

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Saver(GetselectedMovies, Einstellungen.Config_MediaCenter.Default_local_Source)

            p.Run()
        End If
    End Sub

#End Region



    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Me.Close()
    End Sub


    Private Sub FehlerMeldenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FehlerMeldenToolStripMenuItem.Click, ToolStripMenuItem70.Click


        OpenWebLink("http://polldaddy.com/s/29BF54CD9728B76F")

    End Sub


    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog_Download.Show()

    End Sub





    Private Sub Main_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If restart = True Then
            Dim dest As String = restart_path
            If IO.File.Exists(dest) Then
                Dim sheet As New Process
                sheet.StartInfo.FileName = dest
                sheet.StartInfo.Arguments = """" & StartupPath & """"
                'sheet.StartInfo.UseShellExecute = False
                'sheet.StartInfo.RedirectStandardOutput = True
                'sheet.StartInfo.CreateNoWindow = True
                sheet.Start()
                'sheet.WaitForExit()
                'Try
                '    Process.Start(Application.ExecutablePath)
                'Catch ex As Exception

                'End Try
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog_Download.Show()

    End Sub





    Private Sub Einstellungen_Tool_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Einstellungen_Tool.DropDownOpening

        WerkzeugeToolStripMenuItem.Checked = Nov_Main.Visible Or Nov_Main_alt.Visible

        If Nov_Main_alt.Visible = True Then
            Radio_dToolbar.Checked = True
            Radio_nToolbar.Checked = False
        ElseIf Nov_Main.Visible = True Then
            Radio_dToolbar.Checked = False
            Radio_nToolbar.Checked = True
        Else
            Radio_dToolbar.Checked = False
            Radio_nToolbar.Checked = False
        End If



        MenüleisteToolStripMenuItem.Checked = Nav_Menu.Visible
        StatusleisteToolStripMenuItem.Checked = MyStatusStrip.Visible

        If SplitContainer_Infopanel.Panel2Collapsed = True Then
            InfoPanelToolStripMenuItem.Image = Toolbar16.Panel_in
        Else
            InfoPanelToolStripMenuItem.Image = Toolbar16.Panel_out
        End If
        If SplitContainer_treepanel.Panel1Collapsed = True Then
            NavigationsleisteToolStripMenuItem.Image = Toolbar16.Tree_in
        Else
            NavigationsleisteToolStripMenuItem.Image = Toolbar16.Tree_out
        End If
    End Sub

    Private Sub AlphaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("http://fio.uservoice.com/forums/45595-general")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub Ordnerhinzufügen_tool_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordnerhinzufügen_tool.MouseHover

    '    MyToolTip.ToolTipTitle = "Ordner hinzufügen..."
    '    'MsgBox(Nov_Main.Size.Height & vbCrLf & Nov_Main.Location.Y & vbCrLf & Nav_Menu.Height)
    '    Dim y As Integer = Nov_Main.Size.Height * 2 + 4
    '    If Nav_Menu.Visible = True Then
    '        y += Nav_Menu.Height
    '    End If
    '    MyToolTip.Show("Ordner hinzufügen...", Me, New Point(20, y))
    'End Sub
    'Private Sub Ordnerladen_tool_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordnerladen_Tool.MouseHover

    '    MyToolTip.ToolTipTitle = "Ordner laden..."
    '    'MsgBox(Nov_Main.Size.Height & vbCrLf & Nov_Main.Location.Y & vbCrLf & Nav_Menu.Height)
    '    Dim y As Integer = Nov_Main.Size.Height * 2 + 4
    '    If Nav_Menu.Visible = True Then
    '        y += Nav_Menu.Height
    '    End If
    '    MyToolTip.Show("Ordner laden...", Me, New Point(20, y))
    'End Sub
    'Private Sub Nov_Main_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nov_Main.MouseLeave
    '    MyToolTip.Hide(Me)
    'End Sub

    Private Sub BackdropToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_useasBackdrop.Click
        If myBrowser.Url.AbsoluteUri.ToString.ToLower.EndsWith(".jpg") Then
            If Not SelectedMovie Is Nothing Then
                Dim ld As New Laden_Dialog
                ld.aCancel = False
                ld.ProgressBar1.Style = ProgressBarStyle.Marquee
                ld.aDetails = False
                ld.Text = "Download"
                ld.Labelstring = "Lade Backdrop"
                ld.Show()
                Dim wc As New Net.WebClient
                Dim des As String = ""
                des = ImageDestinations.Fanart(SelectedMovie.Pfad)
                Try
                    wc.DownloadFile(myBrowser.Url, des)
                    InfoPanel_Movie1.RefreshFolderPrev(SelectedMovie.Pfad)
                    InfoPanel_Movie1.arr_to_Panel_Backdrops(SelectedMovie)
                    InfoPanel_Movie1.arr_to_Panel_Refresh(SelectedMovie)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                ld.closallowed = True
                ld.Close()
                ld.Dispose()
                Panel_Overlay_useImage.Visible = False
            End If
        End If
    End Sub

    Private Sub CoverToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_useasCover.Click
        If myBrowser.Url.AbsoluteUri.ToString.ToLower.EndsWith(".jpg") Then
            If Not SelectedMovie Is Nothing Then
                Dim ld As New Laden_Dialog
                ld.aCancel = False
                ld.ProgressBar1.Style = ProgressBarStyle.Marquee
                ld.aDetails = False
                ld.Text = "Download"
                ld.Labelstring = "Lade Backdrop"
                ld.Show()
                Dim wc As New Net.WebClient

                Dim des As String = ""
                des = ImageDestinations.Cover(SelectedMovie.Pfad)
                Try
                    wc.DownloadFile(myBrowser.Url, des)
                    InfoPanel_Movie1.RefreshFolderPrev(SelectedMovie.Pfad)
                    InfoPanel_Movie1.arr_to_Panel_Cover(SelectedMovie)
                    InfoPanel_Movie1.arr_to_Panel_Refresh(SelectedMovie)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                wc.Dispose()

                ld.closallowed = True
                ld.Close()
                ld.Dispose()
                Panel_Overlay_useImage.Visible = False
            End If
        End If
    End Sub

    Public Sub GenreHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenreHinzufügenToolStripMenuItem.Click, BearbeitenToolStripMenuItem.Click, ToolStripMenuItem62.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            Dim d As New Dialog_GenreSelect
            d.Fill(InfoPanel_Movie1.TB_Genre.Text)
            d.RadioButton_Rep.Visible = False
            d.RadioButton_Add.Visible = False
            If d.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim s As New List(Of String)
                For Each t As TreeNode In d.TreeViewVista1.Nodes
                    s.Add(CStr(t.Text))
                Next

                InfoPanel_Movie1.TB_Genre.Text = ""
                For Each g In s
                    If InfoPanel_Movie1.TB_Genre.Text = "" Then
                        InfoPanel_Movie1.TB_Genre.Text = g
                    Else
                        InfoPanel_Movie1.TB_Genre.Text &= ", " & g
                    End If
                Next
                'If Not d.ListBox1.SelectedItem.ToString() = "" Then


                'End If

            End If
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim d As New Dialog_GenreSelect
            d.list = GetselectedMovies()
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




    Private Sub ToolStripButton_Downloads_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Downloads.Click
        Dialog_Download.Show()
        Dialog_Download.Focus()

    End Sub

#Region "Make AutoCompleSource"



    Private Function AutoComplete_Fortschritt() As String()

        Dim acm As New List(Of String)
        Dim s As String = "000"
        acm.Add("<" & s)
        acm.Add("=" & s)
        acm.Add(">" & s)
        For x As Integer = 1 To 9
            s = "0" & x * 10
            acm.Add("<" & s)
            acm.Add("=" & s)
            acm.Add(">" & s)
        Next
        s = "100"
        acm.Add("<" & s)
        acm.Add("=" & s)
        acm.Add(">" & s)
        Dim arr As String()
        arr = acm.ToArray
        Array.Sort(arr)
        Return arr

    End Function
    Private Function AutoComplete_Genre() As String()

        Dim acm As New List(Of String)

        For Each x In actRows
            Dim a As String = x.Cells(Column_Genre.Index).Value.ToString

            Dim d() As String = a.Split(CChar(","))
            If d.Length > 0 Then
                For y As Integer = 0 To d.Length - 1
                    If Not acm.Contains(d(y).Trim) Then
                        acm.Add(d(y).Trim)
                    End If
                Next
            End If
        Next

        Dim arr As String()
        arr = acm.ToArray
        Array.Sort(arr)
        Return arr

    End Function
    Private Function AutoComplete_personen() As String()

        Dim acm As New List(Of String)

        For Each x In actRows
            Dim a As String = x.Cells(Column_Autoren.Index).Value.ToString
            Dim r As String = x.Cells(Column_Regie.Index).Value.ToString
            Dim t As String = x.Cells(Column_Darsteller.Index).Value.ToString
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
        Next
        Dim arr As String()
        arr = acm.ToArray
        Array.Sort(arr)
        Return arr

    End Function

#End Region
    Private Sub PersonenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonenToolStripMenuItem.Click
        Filter_Dropdown_OPT.Text = "Personen"
        ToolStripTextBox1.Items.Clear()
        ToolStripTextBox1.Items.AddRange(AutoComplete_personen)
    End Sub
    Private Sub GenreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenreToolStripMenuItem1.Click
        Filter_Dropdown_OPT.Text = "Genre"
        ToolStripTextBox1.Items.Clear()
        ToolStripTextBox1.Items.AddRange(AutoComplete_Genre)
    End Sub

    Private Sub SammlungToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SammlungToolStripMenuItem1.Click
        If sender Is SammlungToolStripMenuItem1 And SammlungToolStripMenuItem1.DropDownItems.Count = 0 Then
        Else
            Filter_Dropdown_OPT.Text = "Sammlung"
            ToolStripTextBox1.Items.Clear()
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                ToolStripTextBox1.Items.AddRange(SammlungFunctions.SammlungenListe.ToArray)
            Else
                ToolStripTextBox1.Items.AddRange(SammlungFunctions.SetListe.ToArray)
            End If

        End If

    End Sub

    Private Sub JahrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JahrToolStripMenuItem.Click
        Filter_Dropdown_OPT.Text = "Jahr"
        ToolStripTextBox1.Items.Clear()
    End Sub

    Private Sub FortschrittToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FortschrittToolStripMenuItem1.Click
        Filter_Dropdown_OPT.Text = "Fortschritt"
        ToolStripTextBox1.Items.Clear()
        ToolStripTextBox1.Items.AddRange(AutoComplete_Fortschritt)
    End Sub





    Private Sub TitelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelToolStripMenuItem.Click
        Filter_Dropdown_OPT.Text = "Titel"
        ToolStripTextBox1.Items.Clear()
        ToolStripTextBox1.Items.AddRange(AutoComplete_Titel)
    End Sub

  

    Private Sub ToolStripButton19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton19.Click
        Dialog_Download.Show()
        Dialog_Download.Focus()

    End Sub

    Private Sub Downloads_Item_Completed(ByVal item As DownloadItem)
        If Not item.DestMovie Is Nothing Then
            item.DestMovie.RefreshCover()
            item.DestMovie.Refresh()
        End If
    End Sub

    Private Sub Downloads_Started()
        exp_Downloads.Image = Toolbar16.Download_aktive
        exp_Downloads.Visible = True
        ToolStripButton_Downloads.Image = Toolbar16.Download_aktive
        exp_menu_downloads.Image = Toolbar16.Download_aktive
        Download_Panel.Visible = True
        exp_dl_Fortschritt.Visible = True
        exp_dl_size.Visible = True
        exp_dl_time.Visible = True
        exp_dl_speed.Visible = True
        If Is_Taskbar_progress_supported Then
            windowsTaskbar.SetOverlayIcon(Me.Handle, Toolbar16.downoverlayicon, "Down")
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.Normal)
        End If
    End Sub

    Dim Downloads_Info_Changed_old_orecentage As Integer = 0
    Private Sub Downloads_Info_Changed()
        Download_info_Absolut.Text = DownloadManager.tm_TotalBytes
        Download_info_Geladen.Text = DownloadManager.tm_RecievedBytes
        Download_info_Prozent.Text = DownloadManager.tm_Precentage
        Download_Info_Restzeit.Text = DownloadManager.tm_TimeLeft
        Download_info_Speed.Text = DownloadManager.tm_KBytesPerSecound
        ProgressBar1.Value = Einstellungen.toInt(DownloadManager.tm_Precentage, 0)
        If Exp_Organisieren.Pressed = True Then
            exp_dl_Fortschritt.Text = DownloadManager.tm_Precentage & "%"
            exp_dl_size.Text = DownloadManager.tm_RecievedBytes & DownloadManager.tm_TotalBytes
            exp_dl_time.Text = DownloadManager.tm_TimeLeft
            exp_dl_speed.Text = DownloadManager.tm_KBytesPerSecound
        End If
        If Is_Taskbar_progress_supported Then

            Dim ne As Integer = Einstellungen.toInt(DownloadManager.tm_Precentage, 0)

            If Not ne = 100 Then


                windowsTaskbar.SetProgressValue(ne, 100)

            End If

            'windowsTaskbar.SetProgressValue(Einstellungen.toInt(DownloadManager.tm_Precentage, 0), 100)
        End If
    End Sub

    Private Sub Downloads_Completed()
        If Is_Taskbar_progress_supported Then
            windowsTaskbar.SetProgressValue(0, 100)
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)

            windowsTaskbar.SetOverlayIcon(Me.Handle, Nothing, Nothing)
            Downloads_Info_Changed_old_orecentage = 0
        End If
        exp_menu_downloads.Image = Toolbar16.Down
        exp_menu_downloads.Image = Toolbar16.Down
        ToolStripButton_Downloads.Image = Toolbar16.Down
        exp_Downloads.Image = Toolbar16.Down
        Download_Panel.Visible = False
        exp_dl_Fortschritt.Visible = False
        exp_dl_size.Visible = False
        exp_dl_time.Visible = False
        exp_dl_speed.Visible = False
        MyToolTip.ToolTipIcon = ToolTipIcon.Info
        MyToolTip.ToolTipTitle = "Download komplett"
        MyToolTip.Show("Es wurden alle Dateien heruntergeladen.", Me, 20, 40, 2000)

        exp_Downloads.Visible = False
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

    Private Function AutoComplete_Titel() As String()

        Dim acm As New List(Of String)

        For Each x In actRows
            Dim a As String = x.Cells(Column_Titel.Index).Value.ToString


            If Not acm.Contains(a.Trim) Then
                acm.Add(a.Trim)
            End If
        Next

        Dim arr As String()
        arr = acm.ToArray
        Array.Sort(arr)
        Return arr
    End Function


    Private Sub ToolStripTextBox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Movie_GridView.ClearSelection()
            RowFilter.run(actRows, Filter_Dropdown_OPT.Text, ToolStripTextBox1.Text)
        End If
    End Sub



    Private Sub DoppelteFilmeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoppelteFilmeToolStripMenuItem.Click
        ToolStripTextBox1.Text = "%doppelt"
        ToolStripTextBox1.Focus()

    End Sub

    Private Sub HilfeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HilfeToolStripMenuItem1.Click, ToolStripMenuItem58.Click
        Try
            Process.Start("http://www.fiohelp.blogspot.com/")
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Panel5_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel5.MouseEnter
        If Panel_Update_more.Visible = False Then
            Panel_Update_more.Visible = True
            For x As Integer = 0 To 90 Step 10
                Panel_Update_more.Location = New System.Drawing.Point(Panel_Update_more.Location.X, x - 60)
                Threading.Thread.Sleep(10)
                Panel_Update_more.Refresh()
            Next
        End If

    End Sub

    Private Sub Update_Link_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update_Link.Click
        Dialog_Update.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        restart = True
        Me.Close()
    End Sub



    Private Sub MediaInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaInfoToolStripMenuItem.Click, ToolStripMenuItem64.Click
        If Movie_GridView.SelectedRows.Count > 1 Then


            Dim d As New Dialog_MediaInfo_Edit
            d.list = GetselectedMovies()

            If d.ShowDialog = Windows.Forms.DialogResult.OK Then

                Dim p As New Progress_ChangeMediaInfo(d.list)
                p.sVideoAuflösung = d.TB_VideoAuflösung.Text.Trim
                p.sVideoSeitenverhältnis = d.TB_VideoSeitenverhältnis.Text.Trim
                p.sVideoBildwiederholungsrate = d.TB_VideoBildwiederholungsrate.Text.Trim
                p.sVideoCodec = d.TB_VideoCodec.Text.Trim
                p.sAudioKanäle = d.TB_AudioKanäle.Text.Trim
                p.sAudioCodec = d.TB_AudioCodec.Text.Trim
                p.sAudioSprachen = d.TB_AudioSprachen.Text.Trim

                p.Run()
                'If Not d.ListBox1.SelectedItem.ToString() = "" Then


                'End If

            End If
        End If
    End Sub

    Private Sub SortierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SortierenToolStripMenuItem.Click
        Dialog_Sortieren_Wizard.Show()

    End Sub


    Private Sub WiederherstellenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WiederherstellenToolStripMenuItem1.Click, ToolStripMenuItem61.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            Dim m As New Movie With {.Pfad = SelectedMovie.Pfad}

            XMLModule.Backup_Load(m)
            SelectedMovie.flag = 0
            'SelectedMovie.Save(True)
            InfoPanel_Movie1.backup_to_Panel(m)
            InfoPanel_Movie1.ToolStripButton22.Image = Toolbar16.securenormal
        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim d As New Progress_Backup_Load(GetselectedMovies)
            d.Run()
        End If
    End Sub

    Private Sub SichrungErstellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SichrungErstellenToolStripMenuItem.Click, ToolStripMenuItem60.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(True)
            InfoPanel_Movie1.Load_item(SelectedMovie)
            XMLModule.Backup_Save(SelectedMovie)
            InfoPanel_Movie1.SicherungLöschenToolStripMenuItem.Enabled = True
            InfoPanel_Movie1.WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & XMLModule.Backup_Date(SelectedMovie.Pfad).ToShortDateString & ")"
            InfoPanel_Movie1.WiederherstellenToolStripMenuItem.Enabled = True
            InfoPanel_Movie1.ToolStripButton22.Image = Toolbar16.securenormal
        Else
            Dim d As New Progress_Backup_Save(GetselectedMovies)
            d.replace = True
            d.Run()
        End If
    End Sub


    Private Sub ContextMenu_Overwrite_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenu_Overwrite.MouseEnter
        ContextMenu_Overwrite.AutoClose = False
    End Sub

    Private Sub ContextMenu_Overwrite_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles ContextMenu_Overwrite.Closing
        Einstellungen.Config_Overwrite.Save()
    End Sub

    Public Sub HTMLPRev(ByVal text As String)
        EnablerforWeb()
        myBrowser.DocumentText = text
        myBrowser.Print()
        myBrowser.ShowPrintDialog()
        myBrowser.ShowPrintPreviewDialog()
        myBrowser.ShowPageSetupDialog()
    End Sub

    Public Sub RemoveMovieFromList(ByVal m As Movie)

        For Each s In MoviesColl
            If s.Movies.Contains(m) Then
                s.Movies.Remove(m)
            End If
        Next
        For Each s In FavMoviesColl
            If s.Movies.Contains(m) Then
                s.Movies.Remove(m)
            End If
        Next
        actRows.Remove(m.Row)
        Movie_GridView.Rows.Remove(m.Row)
    End Sub


    Private Sub HtmlExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dialog_Export_Wizard.Show()
    End Sub

    Private Sub FilmordnerLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilmordnerLöschenToolStripMenuItem.Click, exp_menu_delet.Click, ToolStripMenuItem40.Click
        'If DataGridView1.SelectedRows.Count = 1 Then
        '    If MsgBox("Möchten Sie den Ordner wirklich in den Papierkorb verschieben?", MsgBoxStyle.YesNoCancel, "Löschen") = MsgBoxResult.Yes Then
        '        Try
        '            Papiekorb.MoveToBin(SelectedMovie.Pfad)
        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        '        End Try
        '        DataGridView1_SelectionChanged(Me, New EventArgs)
        '    End If
        If Movie_GridView.SelectedRows.Count >= 1 Then
            'If MsgBox("Möchten Sie die Ordner der ausgewählten Filme wirklich in den Papierkorb verschieben?", MsgBoxStyle.YesNoCancel, "Löschen") = MsgBoxResult.Yes Then
            Dim p As New Progress_FileDelet(GetselectedMovies)
            p.Run()
            'End If
        End If
    End Sub

    Private Sub ToolStripButton23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripTextBox1.Text = ""

    End Sub

    Private Sub SicherungErstellenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SicherungErstellenToolStripMenuItem1.Click, ToolStripMenuItem59.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(True)
            InfoPanel_Movie1.Load_item(SelectedMovie)
            XMLModule.Backup_Save(SelectedMovie)
            InfoPanel_Movie1.SicherungLöschenToolStripMenuItem.Enabled = True
            InfoPanel_Movie1.WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & XMLModule.Backup_Date(SelectedMovie.Pfad).ToShortDateString & ")"
            InfoPanel_Movie1.WiederherstellenToolStripMenuItem.Enabled = True
            InfoPanel_Movie1.ToolStripButton22.Image = Toolbar16.securenormal
        Else
            Dim d As New Progress_Backup_Save(GetselectedMovies)
            d.replace = False
            d.Run()
        End If
    End Sub

    Private Sub ToolStripMainItem_Bearbeiten_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMainItem_Bearbeiten.DropDownOpening
        If IO.File.Exists(StartupPath & "\Plugins\moviesheet\mtn.exe") Then
            ThumbnailsErstellenToolStripMenuItem.Enabled = True
        Else
            ThumbnailsErstellenToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Panel_Update_more_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Update_more.Paint

    End Sub

    Private Sub Panel_Update_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Update.Paint

    End Sub


    Private Sub ToPanelTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToPanelTimer.Tick
        InfoPanel_Movie1.Load_item(SelectedMovie)
        'ToPanelTimer.Stop()
        ToPanelTimer.Enabled = False
    End Sub

    Private Sub ToolbarstatesTimer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Toolbar_Timer.Tick
        Dim fan As Boolean = False
        Dim suc As Boolean = False
        Dim min As Boolean = False
        Dim ren As Boolean = False

        For Each r As DataGridViewRow In Movie_GridView.SelectedRows
            If r.Cells(Column_Rate_Backdrops.Index).Value.ToString = "2" And r.Cells(Column_Rate_Cover.Index).Value.ToString = "2" Then
            Else
                fan = True
            End If
            If r.Cells(Column_Rate_Info.Index).Value.ToString = "2" Then
            Else
                suc = True
            End If

            If r.Cells(Column_Rate_MediaInfo.Index).Value.ToString = "2" Then
            Else
                min = True
            End If
            If r.Cells(Column_Rate_Ordner.Index).Value.ToString = "2" Then
            Else
                ren = True
            End If
            If ren = True And min = True And suc = True And fan = True Then
                Exit For
            End If
        Next
        If Einstellungen.Config_Save.Save_Rename_Filepat = "" And Einstellungen.Config_Save.Save_Rename_Folderpat = "" Then
            ren = False
        End If
        If Movie_GridView.SelectedRows.Count = 1 Then
            exp_speichern.Visible = InfoPanel_Movie1.Panel_info_changed()
        Else
            exp_speichern.Visible = False
        End If

        exp_Download.Visible = fan
        Exp_Suche.Visible = suc
        Exp_MediaInfo.Visible = min
        Exp_Rename.Visible = ren

    End Sub

    Private Sub DownloadsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_downloads.Click
        Dialog_Download.Show()
    End Sub


    Private Sub LayoutToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayoutToolStripMenuItem.DropDownOpening
        ToolStripMenuItem54.Checked = Nav_Menu.Visible
        ToolStripMenuItem55.Checked = MyStatusStrip.Visible

        If Nov_Main_alt.Visible = True Then
            Radio_DynamischeWerkzeugleisteToolStripMenuItem.Checked = True
            Radio_NormaleWerkzeugleisteToolStripMenuItem.Checked = False
        ElseIf Nov_Main.Visible = True Then
            Radio_DynamischeWerkzeugleisteToolStripMenuItem.Checked = False
            Radio_NormaleWerkzeugleisteToolStripMenuItem.Checked = True
        Else
            Radio_DynamischeWerkzeugleisteToolStripMenuItem.Checked = False
            Radio_NormaleWerkzeugleisteToolStripMenuItem.Checked = False
        End If
        WerkzeugleisteToolStripMenuItem1.Checked = Nov_Main.Visible Or Nov_Main_alt.Visible
        If SplitContainer_Infopanel.Panel2Collapsed = True Then
            ToolStripMenuItem57.Image = Toolbar16.Panel_in
        Else
            ToolStripMenuItem57.Image = Toolbar16.Panel_out
        End If
        If SplitContainer_treepanel.Panel1Collapsed = True Then
            ToolStripMenuItem56.Image = Toolbar16.Tree_in
        Else
            ToolStripMenuItem56.Image = Toolbar16.Tree_out
        End If
    End Sub

    Private Sub Radio_DynamischeWerkzeugleisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_DynamischeWerkzeugleisteToolStripMenuItem.Click, Radio_dToolbar.Click, Radio_DynToolbar.Click
        Nov_Main.Visible = False
        Nov_Main_alt.Visible = True
        Refresh_Toolbar_States()
    End Sub
    Private Sub Radio_NormaleWerkzeugleisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_NormaleWerkzeugleisteToolStripMenuItem.Click, Radio_nToolbar.Click, Radio_NorToolbar.Click
        Nov_Main.Visible = True
        Nov_Main_alt.Visible = False
        Refresh_Toolbar_States()
    End Sub
    Private Sub DynamischeWerkzeugleisteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If s.Text = "Normale Werkzeugleiste" Then
            Nov_Main.Visible = True
            Nov_Main_alt.Visible = False
            Refresh_Toolbar_States()
        Else
            Nov_Main.Visible = False
            Nov_Main_alt.Visible = True
            Refresh_Toolbar_States()
        End If
    End Sub
    Private Sub Main_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        If Is_Taskbar_progress_supported Then
            windowsTaskbar.SetProgressState(TaskbarProgressBarState.NoProgress)
        End If
        'RegistrationHelper.RegisterFileAssociations(ProgId, False, appId, Application.ExecutablePath & " ""%1""", "Folder")

        'jumpList = jumpList.CreateJumpList
        'jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Frequent
        'jumpList.Refresh()
        'comboBoxKnownCategoryType.SelectedItem = "Recent"
        '
        Dim tspan As New TimeSpan
        tspan = Date.Today.Subtract(Einstellungen.Config_Update.Update_last)
        If Einstellungen.Config_Update.Update_Auto = True Then
            If tspan.TotalDays >= 0 Then
                Dim m As New Progress_CheckForUpdates
                m.Run()
                'Updater.Check_For_Updates(False)
                Einstellungen.Config_Update.Update_last = Now
            End If
        End If

        If Einstellungen.Config_Favoriten.paths.Count > 0 Then
            If Einstellungen.Config_Laden.Laden_Favs_Autostart = True Then
                Dim p(Einstellungen.Config_Favoriten.paths.Count) As String
                For i As Integer = 0 To Einstellungen.Config_Favoriten.paths.Count - 1
                    If IO.Directory.Exists(Einstellungen.Config_Favoriten.paths(i)) Then
                        p(i) = Einstellungen.Config_Favoriten.paths(i)
                    Else
                        Dim nNode As New TreeNode
                        nNode.Text = IO.Path.GetFileName(Einstellungen.Config_Favoriten.paths(i))
                        nNode.Tag = Einstellungen.Config_Favoriten.paths(i)
                        nNode.ImageIndex = 5
                        Me.TreeViewVista1.Nodes(1).Nodes.Add(nNode)
                        Me.TreeViewVista1.Nodes(1).Expand()
                    End If


                Next
                Dim fala As New Progress_LoadFavFolder(p)
                fala.Run()
            Else
                For i As Integer = 0 To Einstellungen.Config_Favoriten.paths.Count - 1
                    Dim nNode As New TreeNode
                    nNode.Text = IO.Path.GetFileName(Einstellungen.Config_Favoriten.paths(i))
                    nNode.Tag = Einstellungen.Config_Favoriten.paths(i)
                    Me.TreeViewVista1.Nodes(1).Nodes.Add(nNode)
                    Me.TreeViewVista1.Nodes(1).Expand()
                Next
            End If
        End If


        Try
            Dim pat As List(Of String)
            Dim args As String()
            args = Environment.GetCommandLineArgs
            pat = args.ToList()
            pat.RemoveAt(0)
            AddFolder(pat.ToArray)


        Catch ex As Exception

        End Try


    End Sub



    Private Sub ToolStripTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.TextChanged



        If ToolStripTextBox1.Text = "Suchen" Then

        Else
            If Not ToolStripTextBox1.Text = "" Or Not Movie_GridView.RowCount = actRows.Count Then
                Movie_GridView.ClearSelection()
                DataGridView1_SelectionChanged(Me, New EventArgs)
                RowFilter.run(actRows, Filter_Dropdown_OPT.Text, ToolStripTextBox1.Text)
            End If


        End If




    End Sub

    Private Sub ToolStripTextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.Leave

        If Not ToolStripTextBox1.Text = "" And Not ToolStripTextBox1.Text = "Suchen" Then

            ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
            ToolStripTextBox1.ForeColor = SystemColors.MenuText
            Filter_Dropdown_OPT.ForeColor = SystemColors.MenuText

            'If ToolStripTextBox1.Selected = True Then
            '    ToolStripTextBox1.SelectAll()
            '    'PB_suchen_Löschen.Visible = True
            'End If
        Else

            If Not ToolStripTextBox1.Focused = True Then
                ToolStripTextBox1.Text = "Suchen"
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.GrayText
                Filter_Dropdown_OPT.ForeColor = SystemColors.GrayText
            Else
                ToolStripTextBox1.Text = ""
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.MenuText
                Filter_Dropdown_OPT.ForeColor = SystemColors.MenuText
            End If

        End If
    End Sub

    Private Sub ToolStripTextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox1.Enter

        If ToolStripTextBox1.Text = "Suchen" Then
            ToolStripTextBox1.Text = ""
        End If
        If ToolStripTextBox1.Text = "" Or ToolStripTextBox1.Text = "Suchen" Then


            If Not ToolStripTextBox1.Focused = True Then
                ToolStripTextBox1.Text = "Suchen"
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.GrayText
                Filter_Dropdown_OPT.ForeColor = SystemColors.GrayText
            Else
                ToolStripTextBox1.Text = ""
                ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
                ToolStripTextBox1.ForeColor = SystemColors.MenuText
                Filter_Dropdown_OPT.ForeColor = SystemColors.MenuText
            End If
            'If ToolStripTextBox1.Focused = True Then
            '    ToolStripTextBox1.Select(ToolStripTextBox1.Text.Length, 0)
            '    PB_suchen_Löschen.Visible = True
            'End If
        Else
            'If Not ToolStripTextBox1.Focused = True Then
            '    'ToolStripTextBox1.Text = "Suchen"
            '    ToolStripTextBox1.Font = New Font(SchnelleSucheToolStripMenuItem.Font, FontStyle.Italic)
            '    ToolStripTextBox1.ForeColor = SystemColors.GrayText
            '    Filter_Dropdown_OPT.ForeColor = SystemColors.GrayText
            'Else
            ToolStripTextBox1.Font = New Font(ToolStripTextBox1.Font, ToolStripTextBox1.Font.Style And Not FontStyle.Italic)
            ToolStripTextBox1.ForeColor = SystemColors.MenuText
            Filter_Dropdown_OPT.ForeColor = SystemColors.MenuText

        End If
    End Sub

    Private Sub MyBrowser_Close_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBrowser_Close.MouseLeave
        MyBrowser_Close.Image = Toolbar16.exit_normal
    End Sub

    Private Sub MyBrowser_Close_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBrowser_Close.MouseEnter
        MyBrowser_Close.Image = Toolbar16.exiticon
    End Sub

    Private Sub Browser_Navigationtb_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Browser_Navigationtb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                myBrowser.Navigate(Browser_Navigationtb.Text)

            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub AnalyseAktUrl()
        If Not SelectedMovie Is Nothing And Not Einstellungen.UserInterFace.myBrowser_Plugins_show = False Then
            Dim url As String = myBrowser.Url.AbsoluteUri.ToString.ToLower
            If url.EndsWith(".jpg") Then
                Panel_Overlay_useImage.Visible = True
                Panel_Overlay_useImage.BringToFront()
            Else
                Panel_Overlay_useImage.Visible = False
            End If

            MyBrowser_Close.Enabled = True

            Dim myresultlink As String = ""
            Dim myResultmovEx As New System.Text.RegularExpressions.Regex("http://www.imdb.com/title/(?<titel>(.*))/")
            Dim myResultmovEx2 As New System.Text.RegularExpressions.Regex("http://www.imdb.de/title/(?<titel>(.*))/")
            If Not Browser_Navigationtb.Text = "" Then

                If myResultmovEx.IsMatch(url) Then
                    myresultlink = myResultmovEx.Match(url).Groups("titel").ToString()
                End If
                If myResultmovEx2.IsMatch(url) Then
                    myresultlink = myResultmovEx2.Match(url).Groups("titel").ToString()
                End If
                If Not myresultlink = "" And Not myresultlink = InfoPanel_Movie1.TB_IMDB_ID.Text Then
                    Panel_ask_selectmovie.Visible = True
                    Panel_ask_selectmovie.BringToFront()
                Else
                    Panel_ask_selectmovie.Visible = False

                End If
            End If

            Panel_q_Trailer.Visible = False
            'If url.StartsWith("http://www.moviemaze.de/media/trailer/") Then
            '    Panel_q_Trailer.Visible = True
            '    Panel_q_Trailer.BringToFront()
            'End If

            If url.StartsWith("https://") Then
                url = "http://" & url.Substring(8)
            ElseIf Not url.StartsWith("http://") Then
                url = "http://" & url
            End If
            url = url.Replace("www.youtube.com", "youtube.com")

            If url.StartsWith("http://youtube.com/v/") Then
                url = url.Replace("youtube.com/v/", "youtube.com/watch?v=")
            ElseIf url.StartsWith("http://youtube.com/watch#") Then
                url = url.Replace("youtube.com/watch#", "youtube.com/watch?")
            End If

            If url.StartsWith("http://youtube.com/watch") Then
                'If url.Contains("&") Then
                '    url = url.Substring(0, url.IndexOf("&"))
                'End If
                Panel_q_Trailer.Visible = True
                Panel_q_Trailer.BringToFront()
                Button_Download_Trailer.Tag = url


            End If




        Else
            Panel_q_Trailer.Visible = False
            Panel_ask_selectmovie.Visible = False
            Panel_Overlay_useImage.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton23_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton23.Click
        Einstellungen.UserInterFace.myBrowser_Plugins_show = Not Einstellungen.UserInterFace.myBrowser_Plugins_show
        If Einstellungen.UserInterFace.myBrowser_Plugins_show = True Then
            ToolStripButton23.Image = Toolbar16.plugins
            AnalyseAktUrl()
        Else
            ToolStripButton23.Image = Toolbar16.plugins_gray
            Panel_ask_selectmovie.Visible = False
            Panel_Overlay_useImage.Visible = False
        End If
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Not SelectedMovie Is Nothing Then
            Dim myresultlink As String = ""
            Dim myResultmovEx As New System.Text.RegularExpressions.Regex("http://www.imdb.de/title/(?<titel>(.*))/")
            Dim myResultmovEx2 As New System.Text.RegularExpressions.Regex("http://www.imdb.com/title/(?<titel>(.*))/")
            If Not myBrowser.Url.ToString = vbNullString Then
                If myResultmovEx.IsMatch(myBrowser.Url.ToString) Then
                    myresultlink = myResultmovEx.Match(myBrowser.Url.ToString).Groups("titel").ToString()
                End If
                If myResultmovEx2.IsMatch(myBrowser.Url.AbsolutePath) Then
                    myresultlink = myResultmovEx2.Match(myBrowser.Url.ToString).Groups("titel").ToString()
                End If
            End If
            If Not myresultlink = "" Then
                InfoPanel_Movie1.TB_IMDB_ID.Text = myresultlink
            End If
            Panel_ask_selectmovie.Visible = False
            Einstellungen.UserAbrufen.useImdb = True
            ToolStrip_Suche_ButtonClick(Me, New EventArgs)
        End If
    End Sub

    'Private Sub Exp_Play_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exp_Play.DropDownOpening
    '    ToolStripMenuItem50.Visible = False

    'End Sub



    Private Sub OptionenToolStripMenuItem2_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionenToolStripMenuItem2.DropDownOpening
        ToolStripMenuItem76.Checked = Einstellungen.UserAbrufen.useImdb
    End Sub

    Private Sub DropDownMenu_Suche_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DropDownMenu_Suche.Opening
        IMDBVerwenden_DropDownMenu_Item.Checked = Einstellungen.UserAbrufen.useImdb
        If Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch Then
            SchnelleSuche_DropDownMenu_Item.Font = New Font(SchnelleSuche_DropDownMenu_Item.Font, FontStyle.Bold)
            ExacteSuche_DropDownMenu_Item.Font = New Font(ExacteSuche_DropDownMenu_Item.Font, ExacteSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)
            NormaleSuche_DropDownMenu_Item.Font = New Font(NormaleSuche_DropDownMenu_Item.Font, NormaleSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)

        ElseIf Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
            SchnelleSuche_DropDownMenu_Item.Font = New Font(SchnelleSuche_DropDownMenu_Item.Font, SchnelleSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)
            ExacteSuche_DropDownMenu_Item.Font = New Font(ExacteSuche_DropDownMenu_Item.Font, ExacteSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)
            NormaleSuche_DropDownMenu_Item.Font = New Font(NormaleSuche_DropDownMenu_Item.Font, FontStyle.Bold)
        Else
            SchnelleSuche_DropDownMenu_Item.Font = New Font(SchnelleSuche_DropDownMenu_Item.Font, SchnelleSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)
            ExacteSuche_DropDownMenu_Item.Font = New Font(ExacteSuche_DropDownMenu_Item.Font, FontStyle.Bold)
            NormaleSuche_DropDownMenu_Item.Font = New Font(NormaleSuche_DropDownMenu_Item.Font, NormaleSuche_DropDownMenu_Item.Font.Style And Not FontStyle.Bold)
        End If
    End Sub

    Private Sub DarstellerbilderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem74.Click, DarstellerbilderToolStripMenuItem.Click, ToolStripMenuItem32.Click
        If Movie_GridView.SelectedRows.Count >= 1 Then

            Dim p As New Progress_Darsteller(GetselectedMovies)
            p.Run()
        End If
    End Sub






    Private Sub exp_Download_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_Download.ButtonClick, Cover_Tool.ButtonClick
        If Einstellungen.UserAbrufen.Download_Mode = OnlineSearchmode.Normal Then
            Cover_Tool_ButtonClick(Me, New EventArgs)
        Else
            Click_CoverBackdrops_Automatisch(Me, New EventArgs)
        End If
    End Sub

    Private Sub DropDownMenu_Cover_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DropDownMenu_Cover.Opening
        If IO.File.Exists(StartupPath & "\Plugins\moviesheet\mtn.exe") Then
            ToolStripMenuItem73.Enabled = True
        Else
            ToolStripMenuItem73.Enabled = False
        End If
        If IO.Directory.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName) Then
            ToolStripMenuItem74.Enabled = True
        Else
            ToolStripMenuItem74.Enabled = False
        End If
    End Sub



    Private Sub Exp_Abrufen_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exp_Abrufen.DropDownOpening
        If IO.File.Exists(StartupPath & "\Plugins\moviesheet\mtn.exe") Then
            ToolStripMenuItem48.Enabled = True
        Else
            ToolStripMenuItem48.Enabled = False
        End If
        If IO.Directory.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName) Then
            DarstellerbilderToolStripMenuItem.Enabled = True
        Else
            DarstellerbilderToolStripMenuItem.Enabled = False
        End If
    End Sub

  



    Public Sub OpenFileInWindowsExplorer(ByVal fileName As String)
        Try
            Process.Start("explorer.exe", "/e,/select," & fileName)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub OrdnerpfadÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdnerpfadÖffnenToolStripMenuItem.Click, ToolStripMenuItem39.Click
        If Not SelectedMovie Is Nothing Then
            OpenFileInWindowsExplorer(SelectedMovie.Pfad)
        End If
    End Sub

    Private Sub KopierenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_kopieren.Click, ToolStripMenuItem_copyto.Click
        If Not Movie_GridView.SelectedRows.Count = 0 Then
            Dim dest As String = ChooseFolder()
            If Not dest = "" Then
                Dim p As New Progress_MovieCopy(GetselectedMovies, dest)
                p.Run()
            End If
        End If

    End Sub

    Private Sub VerschiebenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_verschieben.Click, ToolStripMenuItem_moveto.Click
        If Not Movie_GridView.SelectedRows.Count = 0 Then
            Dim dest As String = ChooseFolder()
            If Not dest = "" Then
                Dim p As New Progress_MovieMove(GetselectedMovies, dest)
                p.Run()
            End If
        End If

    End Sub

    Private Sub KopierenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_copy.Click, ToolStripMenuItem_Copy.Click, ToolStripMenuItem42.Click
        Try


            Clipboard.Clear()
            Dim l As New System.Collections.Specialized.StringCollection
            For Each m In GetselectedMovies()
                l.Add(m.Pfad)
            Next
            Clipboard.SetFileDropList(l)
            With Me
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Kopieren"
                .MyToolTip.Show("Filme wurden erfolgreich in die Zwischenablage kopiert.", Me, 20, 40, 2000)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AusscheidenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_cut.Click, ToolStripMenuItem_Cut.Click, ToolStripMenuItem41.Click
        Try
            Clipboard.Clear()
            Dim l As New List(Of String)
            For Each m In GetselectedMovies()
                l.Add(m.Pfad)
            Next
            Dim data As IDataObject = New DataObject(DataFormats.FileDrop, l.ToArray)
            Dim memo As New IO.MemoryStream(4)
            Dim bytes As Byte() = New Byte() {CByte(If(True, 2, 5)), 0, 0, 0}
            memo.Write(bytes, 0, bytes.Length)
            data.SetData("Preferred DropEffect", memo)
            Clipboard.SetDataObject(data)
            With Me
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Ausscheiden"
                .MyToolTip.Show("Filme wurden erfolgreich in die Zwischenablage kopiert.", Me, 20, 40, 2000)
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LöschenToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem2.Click, LöschenToolStripMenuItem3.Click
        If Movie_GridView.SelectedRows.Count > 0 Then
            If MsgBox("Möchten Sie die Sicherungen wirklich endgültig löschen?", MsgBoxStyle.YesNoCancel, "Wirlich löschen?") = MsgBoxResult.Yes Then
                Dim p As New Progress_Backup_Delet(GetselectedMovies)
                p.Run()
            End If
        End If
    End Sub



    Private Sub ContextMenu_Export_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_Export.Opening

        ContextMenu_Export.Items.Clear()
        ContextMenu_Export.Items.Add("Moviesheets vorbereiten", Nothing, AddressOf MoviesheetVorbereitenToolStripMenuItem_Click)
        Dim tr As New ToolStripSeparator
        ContextMenu_Export.Items.Add(tr)
        If IO.Directory.Exists(Einstellungen.SettingsPath & "\Export") Then
            Dim m As String() = IO.Directory.GetDirectories(Einstellungen.SettingsPath & "\Export")
            Array.Sort(m)
            If m.Length = 0 Then
                ContextMenu_Export.Items.Add("Keine Vorlagen gefunden", Nothing)
                ContextMenu_Export.Items(ContextMenu_Export.Items.Count - 1).Enabled = False
            Else
                For Each i In m
                    Dim img As Image = MyFunctions.ImageFromJpeg(IO.Path.Combine(i, "icon.png"))
                    ContextMenu_Export.Items.Add(IO.Path.GetFileName(i), img, AddressOf Export_Item)
                Next
            End If

        End If

        tr = New ToolStripSeparator
        ContextMenu_Export.Items.Add(tr)
        ContextMenu_Export.Items.Add("Ordner öffnen...", Toolbar16.Normal_durchsuchen, AddressOf Export_Open)
        tr = New ToolStripSeparator
        ContextMenu_Export.Items.Add(tr)
        ContextMenu_Export.Items.Add("Standard-Vorlagen erstellen", Nothing, AddressOf Export_CreateStandard)
        ContextMenu_Export.Items.Add("Vorlagen Online finden...", Nothing, AddressOf Export_Online)
    End Sub

    Private Sub Export_Open(ByVal sender As Object, ByVal e As EventArgs)
        Try

            Process.Start(Einstellungen.SettingsPath & "\Export")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Export_Item(ByVal sender As Object, ByVal e As EventArgs)
        If Movie_GridView.SelectedRows.Count > 0 Then
            MyFunctions.ExportChoose(Einstellungen.SettingsPath & "\Export\" & sender.ToString)

        End If
    End Sub
    Private Sub Export_Online(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Process.Start("http://filminfoorganizer.blogspot.com/p/export.html")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Export_CreateStandard(ByVal sender As Object, ByVal e As EventArgs)
        StandardExporterstellen()
    End Sub

    Private Sub StandardExporterstellen()
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim po As String = Einstellungen.SettingsPath & "\Export"

            IO.Directory.CreateDirectory(po)

            Dim s As String = IO.Path.Combine(po, "export.zip")

            Dim Res() As Byte = My.Resources.Export
            IO.File.WriteAllBytes(s, Res)


            Dim cu As New ClassUnzip(s, po)
            AddHandler cu.UnzipFinishd, AddressOf Unziped
            cu.UnzipNow()
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Unziped()
        If IO.File.Exists(Einstellungen.SettingsPath & "\Export\export.zip") Then
            IO.File.Delete(Einstellungen.SettingsPath & "\Export\export.zip")
        End If
        MyToolTip.ToolTipIcon = ToolTipIcon.Info
        MyToolTip.ToolTipTitle = "Export"
        MyToolTip.Show("Standard Export-Vorlagen wurden erstellt.", Me, 20, 40, 2000)
    End Sub




    Private Sub ColumnVisChange(ByVal sender As Object, ByVal e As EventArgs)
        For x As Integer = 0 To Movie_GridView.Columns.Count - 1
            If sender.ToString = Movie_GridView.Columns(x).HeaderText Then
                Movie_GridView.Columns(x).Visible = Not Movie_GridView.Columns(x).Visible
                Exit Sub
            End If
        Next

    End Sub


    Private Sub TrailerLadenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrailerLadenToolStripMenuItem.Click, TrailerLadenToolStripMenuItem2.Click, TrailerLadenToolStripMenuItem1.Click
        Dim pr As New Progress_Trailer(GetselectedMovies)
        pr.id = InfoPanel_Movie1.TB_IMDB_ID.Text
        pr.Run()


    End Sub









    Private Sub VideosVergleichenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideosVergleichenToolStripMenuItem.Click
        If Movie_GridView.SelectedRows.Count = 2 Then
            Dim p As New Player

            Dim m1 As Movie = CType(Movie_GridView.SelectedRows(0).Tag, Movie)
            Dim m2 As Movie = CType(Movie_GridView.SelectedRows(1).Tag, Movie)
            p.m1 = m1
            p.m2 = m2
            p.Show()
        End If

    End Sub

    Private Sub ContextMenu_Sammlung_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_Sammlung.Opening

        If ContextMenu_Sammlung.Items.Count > 3 Then
            Do Until ContextMenu_Sammlung.Items.Count = 3
                Dim t As ToolStripItem
                t = ContextMenu_Sammlung.Items(ContextMenu_Sammlung.Items.Count - 1)
                ContextMenu_Sammlung.Items.Remove(t)
            Loop
        End If






        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then

            HinzufügenToolStripMenuItem.Text = "Hinzufügen..."
            ToolStripTextBox2.Text = ""
            If SammlungFunctions.SammlungenListe.Count > 0 Then
                Dim t As New ToolStripSeparator
                ContextMenu_Sammlung.Items.Add(t)

            End If


            For Each s In SammlungFunctions.SammlungenListe

                ContextMenu_Sammlung.Items.Add(s, Nothing, AddressOf sammlungen_ADD)
                Dim t As ToolStripMenuItem
                t = CType(ContextMenu_Sammlung.Items(ContextMenu_Sammlung.Items.Count - 1), ToolStripMenuItem)
                If Not SelectedMovie Is Nothing Then
                    If InfoPanel_Movie1.TB_Sort.Text.Contains(s) Then
                        t.Checked = True
                    End If
                End If
            Next



            If Not SammlungFunctions.List_i(InfoPanel_Movie1.TB_Sort.Text) = "" Or Movie_GridView.SelectedRows.Count > 1 Then
                Dim t As New ToolStripSeparator
                ContextMenu_Sammlung.Items.Add(t)
                ContextMenu_Sammlung.Items.Add("<keine Sammlung>", Nothing, AddressOf sammlungen_sam_clear)
            End If
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then


            If SammlungFunctions.SetListe.Count > 0 Then
                Dim t As New ToolStripSeparator
                ContextMenu_Sammlung.Items.Add(t)
            End If

            HinzufügenToolStripMenuItem.Text = "Ändern..."
            If Movie_GridView.SelectedRows.Count = 1 Then
                ToolStripTextBox2.Text = InfoPanel_Movie1.TB_set.Text
            Else
                ToolStripTextBox2.Text = ""
            End If



            For Each s In SammlungFunctions.SetListe
                ContextMenu_Sammlung.Items.Add(s, Nothing, AddressOf sammlungen_Set)
                Dim t As ToolStripMenuItem
                t = CType(ContextMenu_Sammlung.Items(ContextMenu_Sammlung.Items.Count - 1), ToolStripMenuItem)
                t.Name = "Radio_" & t.Name
                If Not SelectedMovie Is Nothing Then
                    If InfoPanel_Movie1.TB_set.Text = s Then
                        t.Checked = True
                    End If
                End If
            Next
            If Not InfoPanel_Movie1.TB_set.Text = "" Or Movie_GridView.SelectedRows.Count > 1 Then
                Dim t As New ToolStripSeparator
                ContextMenu_Sammlung.Items.Add(t)
                ContextMenu_Sammlung.Items.Add("<kein Set>", Nothing, AddressOf sammlungen_set_clear)
            End If


        End If
    End Sub

    Private Sub HinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HinzufügenToolStripMenuItem.Click
        If Not SelectedMovie Is Nothing Then
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                If Not ToolStripTextBox2.Text = "" Then
                    SammlungFunctions.AddtoList_n(ToolStripTextBox2.Text)
                End If
                InfoPanel_Movie1.TB_set.Text = ToolStripTextBox2.Text
            ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                If Not ToolStripTextBox2.Text = "" Then
                    InfoPanel_Movie1.TB_Sort.Text = SammlungFunctions.AddSammlung(InfoPanel_Movie1.TB_Sort.Text, ToolStripTextBox2.Text)
                    SammlungFunctions.AddtoList_i(InfoPanel_Movie1.TB_Sort.Text)

                End If
            End If
        Else
            If Not ToolStripTextBox2.Text = "" Then
                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                    SammlungFunctions.AddtoList_n(ToolStripTextBox2.Text)
                ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                    SammlungFunctions.AddtoList_i(InfoPanel_Movie1.TB_Sort.Text)
                End If
                Dim pr As New Progress_Edit_Sammlung(GetselectedMovies)
                pr.ClearThem = False
                pr.gen = ToolStripTextBox2.Text
                pr.Run()
            End If


        End If
    End Sub


    Private Sub sammlungen_Set(ByVal sender As Object, ByVal e As EventArgs)
        Dim t As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If Not t Is Nothing Then
            If Not SelectedMovie Is Nothing Then
                If t.Checked = True Then
                    InfoPanel_Movie1.TB_set.Text = ""
                    ContextMenu_Sammlung.Close()
                    InfoPanel_Movie1.ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
                Else
                    InfoPanel_Movie1.TB_set.Text = t.Text
                    ContextMenu_Sammlung.Close()
                    InfoPanel_Movie1.ToolStripDropDownButton2.Image = Toolbar16.Papergrp
                End If
            Else
                Dim pr As New Progress_Edit_Sammlung(GetselectedMovies)
                pr.ClearThem = False
                pr.gen = t.Text
                pr.Run()
            End If


        End If
    End Sub

    Private Sub sammlungen_ADD(ByVal sender As Object, ByVal e As EventArgs)

        Dim t As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
        If Not t Is Nothing Then
            If Not SelectedMovie Is Nothing Then
                If t.Checked = True Then
                    InfoPanel_Movie1.TB_Sort.Text = InfoPanel_Movie1.TB_Sort.Text.Replace("{" & t.Text & "}", "").Trim

                Else
                    InfoPanel_Movie1.TB_Sort.Text = SammlungFunctions.AddSammlung(InfoPanel_Movie1.TB_Sort.Text, t.Text)

                End If
                If InfoPanel_Movie1.TB_Sort.Text.Contains("{") Then
                    InfoPanel_Movie1.ToolStripDropDownButton2.Image = Toolbar16.Papergrp
                Else
                    InfoPanel_Movie1.ToolStripDropDownButton2.Image = Toolbar16.Papergrp_no
                End If
                ContextMenu_Sammlung.Close()
            Else
                Dim pr As New Progress_Edit_Sammlung(GetselectedMovies)
                pr.ClearThem = False
                pr.gen = t.Text
                pr.Run()
            End If



        End If
    End Sub



    Private Sub exp_menu_Sammlung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exp_menu_Sammlung.Click, SammlungToolStripMenuItem.Click
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
            If Not Movie_GridView.SelectedRows.Count = 0 Then
                Dim d As String = ChooseFolder()
                If Not d = "" Then
                    Dim v As New ClassUnzip
                    For Each i In GetselectedMovies()
                        Dim r As Boolean = v.CreateShortcut(IO.Path.Combine(d, IO.Path.GetFileName(i.Pfad)) & ".lnk", i.Pfad)
                    Next
                    Process.Start(d)
                End If

            End If
        End If
    End Sub

    Public Sub refresh_UI_byPlugin()
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            exp_menu_Sammlung.DropDown = ContextMenu_Sammlung
            SammlungToolStripMenuItem.DropDown = ContextMenu_Sammlung
            exp_menu_Sammlung.Text = "Sammlung"
            SammlungToolStripMenuItem.Text = "Sammlung"

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
            exp_menu_Sammlung.DropDown = ContextMenu_Sammlung
            SammlungToolStripMenuItem.DropDown = ContextMenu_Sammlung
            exp_menu_Sammlung.Text = "Set"
            SammlungToolStripMenuItem.Text = "Set"

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then
            exp_menu_Sammlung.DropDown = Nothing
            SammlungToolStripMenuItem.DropDown = Nothing
            exp_menu_Sammlung.Text = "SetBox erstellen..."
            SammlungToolStripMenuItem.Text = "SetBox erstellen..."

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.DVDInfo Then
            exp_menu_Sammlung.Enabled = False
            SammlungToolStripMenuItem.Enabled = False

            exp_menu_Sammlung.Text = "Sammlung"
            SammlungToolStripMenuItem.Text = "Sammlung"

        End If
        InfoPanel_Movie1.refresh_UI_byPlugin()
        InfoPanel_Episode1.refresh_UI_byPlugin()
    End Sub

    Private Sub sammlungen_set_clear(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SelectedMovie Is Nothing Then
            InfoPanel_Movie1.TB_set.Text = ""
        Else
            Dim pr As New Progress_Edit_Sammlung(GetselectedMovies)
            pr.ClearThem = True

            pr.Run()
        End If

    End Sub

    Private Sub sammlungen_sam_clear(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not SelectedMovie Is Nothing Then
            InfoPanel_Movie1.TB_Sort.Text = SammlungFunctions.ClearSammlung(InfoPanel_Movie1.TB_Sort.Text)
        Else
            Dim pr As New Progress_Edit_Sammlung(GetselectedMovies)
            pr.ClearThem = True

            pr.Run()
        End If

    End Sub

    Private Sub Filter_Dropdown_OPT_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filter_Dropdown_OPT.DropDownOpening
        SammlungToolStripMenuItem1.DropDownItems.Clear()
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            SammlungToolStripMenuItem1.Visible = True
            For Each s In SammlungFunctions.SammlungenListe
                SammlungToolStripMenuItem1.DropDownItems.Add(s, Nothing, AddressOf sammlungen_Filter)
            Next

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then

            SammlungToolStripMenuItem1.Visible = True
            For Each s In SammlungFunctions.SetListe
                SammlungToolStripMenuItem1.DropDownItems.Add(s, Nothing, AddressOf sammlungen_Filter)

            Next

        Else
            SammlungToolStripMenuItem1.Visible = False
        End If
    End Sub

    Private Sub sammlungen_Filter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ToolStripTextBox1.Text = sender.ToString
        ToolStripTextBox1.Focus()
        'ToolStripTextBox1_Enter(sender, e)
        SammlungToolStripMenuItem1_Click(sender, e)

    End Sub

    Private Sub Exp_Play_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exp_Play.DropDownOpening
        WiedergebenToolStripMenuItem.Image = Exp_Play.Image

        If Not SelectedMovie Is Nothing Then
            TrailerWiedergebenToolStripMenuItem.Enabled = Not SelectedMovie.File_Trailer = ""
        End If

    End Sub

    Private Sub TrailerWiedergebenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrailerWiedergebenToolStripMenuItem.Click
        If Not IsNothing(SelectedMovie) Then
            Try

                Process.Start(SelectedMovie.File_Trailer)
            Catch ex As Exception

            End Try


        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub Button_Download_Trailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Download_Trailer.Click
        If Not SelectedMovie Is Nothing Then
            Panel_q_Trailer.Visible = False

            'Dim pr As New Progress_MovieMazeTrailer(myBrowser.Url.AbsoluteUri)





            SelectedMovie.TrailerURL = myBrowser.Url.AbsoluteUri
            Dim pr As New Progress_Trailer(GetselectedMovies)

            pr.hptext = myBrowser.DocumentText
            pr.Run()
        End If










        'Dim str As New IO.StreamReader(myBrowser.DocumentStream)

        'Dim htq As String = str.ReadToEnd

        'Dim tr As New TrailerLoader(myBrowser.Url.AbsoluteUri, htq)

        'MsgBox(tr.Result.Count)
        'Dim t As String = ""
        'For Each s In tr.Result
        '    t &= vbCrLf & s.URL
        'Next
        'Clipboard.SetText(t)

        'Dim text As String = ""

        'Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(myBrowser.DocumentText, "&amp;fmt_url_map=([^&]*)&amp")
        'If match.Success = True Then
        '    text = match.Groups(1).Value
        'End If
        'text = WebFunctions.URLDecode(text)
        'Dim arr() As String = Split(text, ",")
        'For Each s In arr
        '    'Dim q As TrailerQuality = TrailerQuality.NoQ
        '    'If s.StartsWith("18") Then
        '    '    q = TrailerQuality.SD360
        '    'ElseIf s.StartsWith("22") Then
        '    '    q = TrailerQuality.HD720
        '    'ElseIf s.StartsWith("37") Then
        '    '    q = TrailerQuality.HD1080
        '    'End If
        '    'If Not q = TrailerQuality.NoQ Then
        '    Dim uri As String = ""

        '    Dim urimatch As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(s, "\d*\|(.*)")
        '    If urimatch.Success = True Then
        '        uri = urimatch.Groups(1).Value
        '    End If
        '    MsgBox(uri)
        '    'If Not uri = "" Then
        '    '    Result.Add(New TrailerFile(q, uri))
        '    'End If
        '    'End If
        'Next
    End Sub

    Private Sub ToolStripMainItem_Info_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMainItem_Info.DropDownOpening
        If Movie_GridView.SelectedRows.Count = 2 Then
            VideosVergleichenToolStripMenuItem.Visible = True
        Else
            VideosVergleichenToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub FilmeZusammenfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilmeZusammenfügenToolStripMenuItem.Click


        Dim p As New Progress_AviMuxCombineMovies(GetselectedMovies)
        p.Run()

    End Sub

    Private Sub AnsichtToolStripMenuItem_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnsichtToolStripMenuItem.DropDownOpening
        ToolStripMenuItem6.Checked = Nav_Menu.Visible
        ToolStripMenuItem7.Checked = MyStatusStrip.Visible
        WerkzeugleisteToolStripMenuItem.Checked = Nov_Main.Visible Or Nov_Main_alt.Visible

        If Nov_Main_alt.Visible = True Then
            Radio_DynToolbar.Checked = True
            Radio_NorToolbar.Checked = False
        ElseIf Nov_Main.Visible = True Then
            Radio_DynToolbar.Checked = False
            Radio_NorToolbar.Checked = True
        Else
            Radio_DynToolbar.Checked = False
            Radio_NorToolbar.Checked = False
        End If
        If SplitContainer_Infopanel.Panel2Collapsed = True Then
            ToolStripMenuItem2.Checked = False
            ToolStripMenuItem2.Image = Toolbar16.Panel_out

            'ToolStripMenuItem2.Image = Toolbar16.Panel_in
        Else
            ToolStripMenuItem2.Checked = True
            ToolStripMenuItem2.Image = Nothing
        End If
        If SplitContainer_treepanel.Panel1Collapsed = True Then
            ToolStripMenuItem5.Checked = False
            ToolStripMenuItem5.Image = Toolbar16.Tree_out
        Else
            ToolStripMenuItem5.Checked = True
            ToolStripMenuItem5.Image = Nothing
        End If
    End Sub

    Private Sub ContextMenu_Flags_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ContextMenu_Flags.ItemClicked
        Dim i As Integer = ContextMenu_Flags.Items.IndexOf(e.ClickedItem)
        If i > 3 Then
            i -= 1
        End If
        For Each m In GetselectedMovies()
            m.flag = i
            m.Refresh()
        Next

    End Sub


    Private Sub Navigationsleiste_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles Navigationsleiste.BeforeSelect
        If e.Node.Text = "" Then
            e.Cancel = True
        End If
    End Sub

    Private Sub SerienLadenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SerienLadenToolStripMenuItem.Click
        Dim fol As New FolderBrowserDialog
        'fol.SelectedPath = "D:\Eigene Videos\Video"
        If fol.ShowDialog = Windows.Forms.DialogResult.OK Then
            Clear_DG(True)
            Dim s(1) As String
            s(0) = fol.SelectedPath
            'set_HV()

            Dim Datenlader As New Progress_LoadFolder_Serien(s)
            Datenlader.Run()

            'DatenLaden.Paths = s
            'Laden.Show()
            'DatenLaden.Worker.RunWorkerAsync()
        End If
    End Sub

    Private Sub Navigationsleiste_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles Navigationsleiste.AfterSelect
        If TypeOf Navigationsleiste.SelectedNode.Tag Is Series = True Then
            Dim mSer As Series = CType(Navigationsleiste.SelectedNode.Tag, Series)
            Clear_SeriesGrid(False)
            Fill_DG(mSer)
            'Try
            '    RowFilter.run(actRows, Filter_Dropdown_OPT.Text, ToolStripTextBox1.Text)

            'Catch ex As Exception

            'End Try
            'Me.Refresh()
            'DataGridView1.Visible = True

            Me.Cursor = Cursors.Default
            'ToolStripButton_Add_Fav.Enabled = True
            'ToolStripButton_del_fav.Visible = False
            'If TreeViewVista1.Nodes(1).Nodes.Contains(TreeViewVista1.SelectedNode) Then
            '    ToolStripButton_Add_Fav.Enabled = False
            '    ToolStripButton_del_fav.Visible = True
            'ElseIf TreeViewVista1.Nodes(1).Nodes.Count > 0 Then
            '    For x As Integer = 0 To TreeViewVista1.Nodes(1).Nodes.Count - 1
            '        If TreeViewVista1.Nodes(1).Nodes(x).Tag.Equals(TreeViewVista1.SelectedNode.Tag) Then
            '            ToolStripButton_Add_Fav.Enabled = False
            '            ToolStripButton_del_fav.Visible = False
            '        End If
            '    Next
            'End If
        ElseIf IsNothing(Navigationsleiste.SelectedNode.Tag) Then
            If Navigationsleiste.SelectedNode.Text = "Serien" Then
                Clear_SeriesGrid(False)
                '    Serien_Grid_View.BringToFront()
                For Each s As TreeNode In Navigationsleiste.SelectedNode.Nodes
                    Dim mSer As Series = CType(s.Tag, Series)
                    Fill_DG(mSer)
                Next

            End If

        End If
    End Sub

    Private Sub Fill_DG(ByVal mSer As Series)
        'Dim node As TreeGridNode = Serien_Grid_View.Nodes.Add(1, 3, 4, 5, 6)
        'node.ImageIndex = 0
        ''node.DefaultCellStyle.Font = boldFont
        'node = node.Nodes.Add(Nothing, "Re: Using DataView filter when binding to DataGridView", "tab", "10/19/2005 1:02 AM")
        'node.ImageIndex = 1
        'Dim boldfont As New Font(Serien_Grid_View.DefaultCellStyle.Font, FontStyle.Bold)

        'Dim master As New TreeGridNode
        'master.DefaultCellStyle.BackColor = Color.LightGray
        ''       master.CreateCells(Serien_Grid_View, {0, 0, 0, 0, 0, 0, mSer.Titel, mSer.Pfad})
        'master.Tag = mSer

        'For Each sea In mSer.Seasons
        '    Dim n As New TreeGridNode
        '    'Dim n As TreeGridNode = Serien_Grid_View.Nodes.Add(sea.Num, 10, sea.Title & "(" & sea.Episodes.Count & ")")
        '    sea.Node = n
        '    n.ImageIndex = 1
        '    n.Tag = sea

        '    'n.DefaultCellStyle.Font = boldfont

        '    'n.DefaultCellStyle.BackColor = Color.LightGray

        '    'n.CreateCells(Serien_Grid_View)
        '    'n.Cells(Column_Ser_Titel.Index).Value = sea.Title
        '    'n.Cells(0).Value = sea.Num
        '    For Each se In sea.Episodes
        '        Dim ns As New TreeGridNode
        '        se.Node = ns
        '        se.refresh()
        '        ns.Tag = se
        '        ns.ImageIndex = 2
        '        'Dim cc As New DataGridViewCellCollection(ns)
        '        'cc.Add(Serien_Grid_View.Columns(0).CellTemplate)
        '        'cc.Add(Serien_Grid_View.Columns(1).CellTemplate)
        '        'cc.Add(Serien_Grid_View.Columns(2).CellTemplate)

        '        '


        '        n.Nodes.Add(ns)

        '    Next
        '    sea.refresh()
        '    master.ImageIndex = 0
        '    master.Nodes.Add(n)



        'Next
        'Serien_Grid_View.Nodes.Add(master)
        'master.Expand()
    End Sub

    Private Sub Clear_SeriesGrid(ByVal p1 As Boolean)
        'Serien_Grid_View.Nodes.Clear()
    End Sub


    'Private Sub Serien_Grid_View_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Serien_Grid_View.MouseDoubleClick
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        Dim hti As DataGridView.HitTestInfo = Serien_Grid_View.HitTest(e.X, e.Y)

    '        If hti.Type = DataGridViewHitTestType.Cell Then

    '            If Not hti.ColumnIndex = 0 Then


    '                Dim n As TreeGridNode = Serien_Grid_View.GetNodeForRow(hti.RowIndex)
    '                If n.HasChildren Then


    '                    If n.Nodes(0).Displayed = True Then
    '                        n.Collapse()

    '                    Else
    '                        n.Expand()
    '                    End If

    '                End If
    '                'End If
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub Serien_Grid_View_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles Serien_Grid_View.CellPainting
    '    If e.Handled = True Then
    '        Exit Sub
    '    End If


    '    If e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Serien_RateCover.Index Then
    '        Dim InfoIcon As Image = Toolbar16.staty_16_cover_test
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        e.Graphics.DrawImage(InfoIcon, c)
    '        e.Handled = True
    '    ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Serien_RateInhalt.Index Then
    '        Dim InfoIcon As Image = Toolbar16.staty_16_info
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        e.Graphics.DrawImage(InfoIcon, c)
    '        e.Handled = True
    '    ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Serien_RateMediaInfo.Index Then
    '        Dim InfoIcon As Image = Toolbar16.staty_16_mediainfo
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        e.Graphics.DrawImage(InfoIcon, c)
    '        e.Handled = True
    '    ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Ser_Progress.Index Then
    '        Dim InfoIcon As Image = Toolbar16.progress
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        e.Graphics.DrawImage(InfoIcon, c)
    '        e.Handled = True
    '    ElseIf e.RowIndex = -1 AndAlso e.ColumnIndex = Column_Serien_RateFilename.Index Then
    '        Dim InfoIcon As Image = Toolbar16.Folder129
    '        e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
    '        Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        e.Graphics.DrawImage(InfoIcon, c)
    '        e.Handled = True
    '    ElseIf e.ColumnIndex = -1 Then
    '        'Dim InfoIcon As Image = Toolbar16.progress
    '        'e.Paint(e.CellBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.Border And Not DataGridViewPaintParts.)
    '        'Dim c As New Rectangle(CInt((e.CellBounds.Width / 2) - 8) + e.CellBounds.X, CInt((e.CellBounds.Height / 2) - 8) + e.CellBounds.Y, 16, 16)
    '        'e.Graphics.DrawImage(InfoIcon, c)
    '        'e.Handled = True
    '    End If
    'End Sub


    'Private Sub Serien_Grid_View_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Serien_Grid_View.SelectionChanged
    '    If disableselectinga = False Then


    '        If Serien_Grid_View.SelectedRows.Count = 1 Then

    '            If Not Serien_Grid_View.SelectedRows(0).Tag Is Nothing Then
    '                If TypeOf Serien_Grid_View.SelectedRows(0).Tag Is Episode Then
    '                    showPanel_Episode()

    '                    SelectedEpisode = CType(Serien_Grid_View.SelectedRows(0).Tag, Episode)
    '                    InfoPanel_Episode1.Load_item(SelectedEpisode)
    '                End If
    '            End If
    '        Else





    '        End If
    '    End If
    'End Sub
    'Dim disableselectinga As Boolean = False
    'Private Sub Serien_Grid_View_NodeExpanding(ByVal sender As Object, ByVal e As AdvancedDataGridView.ExpandingEventArgs) Handles Serien_Grid_View.NodeExpanding
    '    disableselectinga = True
    'End Sub

    'Private Sub Serien_Grid_View_NodeCollapsing(ByVal sender As Object, ByVal e As AdvancedDataGridView.CollapsingEventArgs) Handles Serien_Grid_View.NodeCollapsing
    '    disableselectinga = True
    'End Sub

    'Private Sub Serien_Grid_View_NodeExpanded(ByVal sender As Object, ByVal e As AdvancedDataGridView.ExpandedEventArgs) Handles Serien_Grid_View.NodeExpanded
    '    disableselectinga = False
    'End Sub

    'Private Sub Serien_Grid_View_NodeCollapsed(ByVal sender As Object, ByVal e As AdvancedDataGridView.CollapsedEventArgs) Handles Serien_Grid_View.NodeCollapsed
    '    disableselectinga = False
    'End Sub


    Private Sub ShowPanel_Movie()

        InfoPanel_Movie1.Visible = True
        InfoPanel_Movie1.BringToFront()

        InfoPanel_Episode1.Visible = False

        SplitContainer_Infopanel.Panel2.Refresh()
    End Sub

    Private Sub showPanel_Episode()

        InfoPanel_Episode1.Visible = True
        InfoPanel_Episode1.BringToFront()

        InfoPanel_Movie1.Visible = False

    End Sub


    Private Sub ZuXBMCKonvertierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZuXBMCKonvertierenToolStripMenuItem.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(Savemode.nfo)
            MovieCoverConverter.ConvertImages(Savemode.nfo, SelectedMovie, True)
            InfoPanel_Movie1.Load_item(SelectedMovie)

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Convert(GetselectedMovies, Savemode.nfo  )
            p.mode = Savemode.nfo
            p.deleteold = True

            p.Run()
        End If
    End Sub

    Private Sub ZuXBMCKopierenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ZuXBMCKopierenToolStripMenuItem.Click
        If Movie_GridView.SelectedRows.Count = 1 Then
            SelectedMovie.flag = 0
            SelectedMovie.Save(Savemode.nfo)
            MovieCoverConverter.ConvertImages(Savemode.nfo, SelectedMovie, False)
            InfoPanel_Movie1.Load_item(SelectedMovie)

        ElseIf Movie_GridView.SelectedRows.Count > 1 Then
            Dim p As New Progress_Convert(GetselectedMovies, Savemode.nfo)
            p.mode = Savemode.nfo
            p.deleteold = False

            p.Run()
        End If
    End Sub

    Private Sub CoverUndFanartLöschenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CoverUndFanartLöschenToolStripMenuItem.Click
        If MsgBox("Sind Sie sicher, dass sie für die ausgewählten Filme alle Covers und Fanarts (unwiederruflich) löschen möchten?", MsgBoxStyle.YesNoCancel, "Löschen?") = MsgBoxResult.Yes Then
            If Movie_GridView.SelectedRows.Count = 1 Then
                SelectedMovie.flag = 0
                '  SelectedMovie.Save(Savemode.neu)
                MovieCoverConverter.DeleteImages(SelectedMovie)
                InfoPanel_Movie1.Load_item(SelectedMovie)

            ElseIf Movie_GridView.SelectedRows.Count > 1 Then
                Dim p As New Progress_Convert(GetselectedMovies, Savemode.neu)
                p.mode = Savemode.neu
                p.deleteold = False

                p.Run()
            End If
        End If

    End Sub
End Class

