Imports System.Windows.Forms
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class Settings
    WithEvents mIDownloader As New Net.WebClient
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Einstellungen.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Einstellungen.Load()
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub MediaInfoCheck()
        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML("http://fio.square7.ch/Download/MediaInfo/update.xml", "")
        If Not xml Is Nothing Then
            Dim online As String
            online = If(xml.SelectNodes("//Version").Count > 0, xml.SelectSingleNode("//Version").InnerText, "")
            'MediaInfo_Online.Text = "Online Version: " & online
        End If


        If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
            Dim mi As New MediaInfo

            Dim To_Display As String = mi.Option_("Info_Version", "0.7.0.0")
            mi.Close()

            If (To_Display.Length() = 0) Then
                MediaInfoVersion.Text = "MediaInfo.Dll: Diese Version wird nicht unterstüzt"
                MediaInfoPic.Image = Toolbar16.Abbrechen
            Else
                MediaInfoVersion.Text = "Version: " & To_Display
                MediaInfoPic.Image = Toolbar16.Ok
            End If
            MediaInfo_Download.Enabled = True
        Else
            MediaInfoVersion.Text = "MediaInfo.Dll nicht installiert."
            MediaInfoPic.Image = Toolbar16.Abbrechen
            MediaInfo_Download.Enabled = True
        End If


        'If To_Display.EndsWith(online) Then
        '    MediaInfo_Download.Enabled = False
        'Else
        '    MediaInfo_Download.Enabled = True
        'End If
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TreeViewVista1.SelectedNode = TreeViewVista1.Nodes(0)
        TreeViewVista1.ExpandAll()
        TreeViewVista1.HideSelection = False
        Font = SystemFonts.MenuFont


        If ExplorerContextMenu.isRegisterd("Folder", "Film Info! Organizer") Then

            Exp_Context_reg.Text = "Entfernen"
        Else
            Exp_Context_reg.Text = "Erstellen"
        End If
        'If Not Einstellungen.Settings_dialog_selectednode Is Nothing Then

        '    'TreeViewVista1.Select()
        '    'TreeViewVista1.Se

        '    If Einstellungen.Settings_dialog_selectednode.IsSelected Then
        '        'MsgBox("Hallo")
        '    End If

        'End If
        If Genre_language.SelectedIndex = -1 Then
            Genre_language.SelectedIndex = 0
        End If
        Dim m As New Progress_CheckMediaInfo
        m.Run()


        Dim c As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache")
        Dim d As Long = 0
        If IO.Directory.Exists(c) Then
            d = FolderSize.GetFolderSize(c)
        End If

        Label60.Text = "Größe: " & WebFunctions.FormatBytes(d)
        'MediaInfoCheck()
        Moviethumbcheck()
        FFProbecheck()
        ContextMenu_RenameFormat.Renderer = New MyNativRenderer

        'PictureBox_logo.BackColor = Color.FromArgb(241, 245, 251)
        TableLayoutPanel1.BackColor = Color.FromArgb(241, 245, 251)
        Button7.Enabled = Fortschritt_modus_Eigene.Checked
        'If banner_default.Checked = True Then
        '    LoadBanner(Application.StartupPath & "\Bannerbilder")
        '    Bannerpath.Text = Application.StartupPath & "\Bannerbilder"
        'Else
        '    LoadBanner(Bannerpath.Text)
        'End If
        'TreeViewVista1.SelectedNode = TreeViewVista1.Nodes(2)
        Me.Refresh()
        Einstellungen.Load()
        Me.Refresh()

    End Sub

    'Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Select Case ComboBox6.SelectedIndex
    '        Case Is = 0
    '            ComboBox_new_XML.SelectedIndex = 0
    '            ComboBox_new_Dir.SelectedIndex = 0
    '            ComboBox_Auto_OFDB.SelectedIndex = 0
    '            ComboBox_Auto_mediainfo.SelectedIndex = 0
    '            ComboBox_Auto_update.SelectedIndex = 0
    '            ComboBox_xml_autosave.SelectedIndex = 0
    '        Case Is = 1
    '            ComboBox_new_XML.SelectedIndex = 0
    '            ComboBox_new_Dir.SelectedIndex = 1
    '            ComboBox_Auto_OFDB.SelectedIndex = 1
    '            ComboBox_Auto_mediainfo.SelectedIndex = 1
    '            ComboBox_Auto_update.SelectedIndex = 0
    '            ComboBox_xml_autosave.SelectedIndex = 1
    '        Case Is = 2
    '            ComboBox_new_XML.SelectedIndex = 2
    '            ComboBox_new_Dir.SelectedIndex = 2
    '            ComboBox_Auto_OFDB.SelectedIndex = 2
    '            ComboBox_Auto_mediainfo.SelectedIndex = 2
    '            ComboBox_Auto_update.SelectedIndex = 2
    '            ComboBox_xml_autosave.SelectedIndex = 2
    '        Case Is = 4
    '            ComboBox_Auto_OFDB.SelectedIndex = 0
    '            ComboBox_Auto_update.SelectedIndex = 0
    '        Case Is = 3
    '            ComboBox_Auto_OFDB.SelectedIndex = 2
    '            ComboBox_Auto_update.SelectedIndex = 2

    '    End Select
    'End Sub

    Private Sub Settings_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Einstellungen.Settings_dialog_selectednode = TreeViewVista1.SelectedNode




        'Try
        '    PictureBox1.Image.Dispose()

        'Catch ex As Exception

        'End Try
        'Try
        '    PictureBox2.Image.Dispose()
        'Catch ex As Exception

        'End Try
        'Einstellungen.toOpt()


    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Laden_Dateien_List.Items.Remove(Laden_Dateien_List.SelectedItem)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox1.Text <> "" Then
            Laden_Dateien_List.Items.Add(TextBox1.Text)
        End If

    End Sub


    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Abrufen_MediaInfo_Pfad.Text = OpenFileDialog1.FileName


        End If

    End Sub


    'Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ListBox2.SelectedItems.Count = 1 Then
    '        'MsgBox(ListBox2.SelectedItems.Item(0).ToString)


    '        If IO.File.Exists(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\KategorieBanner.jpg") Then
    '            PictureBox1.Image = Image.FromFile(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\KategorieBanner.jpg")
    '        ElseIf IO.File.Exists(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\KategorieBanner.png") Then
    '            PictureBox1.Image = Image.FromFile(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\KategorieBanner.png")
    '        Else
    '            Try
    '                PictureBox1.Image.Dispose()
    '                PictureBox1.Image = Nothing
    '            Catch ex As Exception

    '            End Try

    '        End If
    '        If IO.File.Exists(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\poster.jpg") Then
    '            PictureBox2.Image = Image.FromFile(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\poster.jpg")
    '        ElseIf IO.File.Exists(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\poster.png") Then

    '            PictureBox2.Image = Image.FromFile(Bannerpath.Text & "\" & ListBox2.SelectedItems.Item(0).ToString & "\poster.png")
    '        Else
    '            Try
    '                PictureBox2.Image.Dispose()
    '                PictureBox2.Image = Nothing
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    End If
    'End Sub
    'Public Sub LoadBanner(ByVal path As String)
    '    ListBox2.Items.Clear()
    '    If IO.Directory.Exists(path) Then


    '        Dim bannerfolder() As String = IO.Directory.GetDirectories(path)
    '        For x As Integer = 0 To bannerfolder.Length - 1
    '            If IO.File.Exists(bannerfolder(x) & "\KategorieBanner.jpg") Or _
    '                IO.File.Exists(bannerfolder(x) & "\Poster.jpg") Or _
    '                IO.File.Exists(bannerfolder(x) & "\Poster.png") Or _
    '                IO.File.Exists(bannerfolder(x) & "\KategorieBanner.png") Then
    '                ListBox2.Items.Add(IO.Path.GetFileName(bannerfolder(x)))



    '            End If
    '        Next
    '    End If

    'End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub











    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try


            Process.Start("http://www.mediabrowser.tv/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try


            Process.Start("http://www.mce-community.de/forum/index.php?showtopic=29114")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Filme_plgin.CheckedChanged
    '    If Filme_plgin.Checked = True Then

    '        f1.Enabled = True
    '        f2.Enabled = True
    '        mb1.Enabled = False
    '        mb2.Enabled = False
    '        mb3.Enabled = False
    '    Else
    '        f1.Enabled = False
    '        f2.Enabled = False
    '        mb1.Enabled = True
    '        mb2.Enabled = True
    '        mb3.Enabled = True
    '    End If
    'End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim folderbw As New FolderBrowserDialog
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            'DataGridView1.Rows.Add(IO.Path.GetFileNameWithoutExtension(FolderBrowserDialog1.SelectedPath), FolderBrowserDialog1.SelectedPath)
        End If
        'folderbw.Dispose()

    End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For Each rw As DataGridViewRow In DataGridView1.SelectedRows
    '        DataGridView1.Rows.Remove(rw)

    '    Next
    '    DataGridView1.Select()



    'End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.


        InitializeComponent()


        Genre_language.SelectedIndex = 0
        Laden_Ordner_suchmodus.SelectedIndex = 0
        Laden_Favs_Suchmodus.SelectedIndex = 0

        If Kon_plugin_Filme.Checked = True Then

            lbl_plugin_info.Text = "Info.xml"

            Label63.Text = "folder.jpg"
            'Backdrops
            PictureBox35.Image = Toolbar16.Ok
            Label66.Text = "im Unterordner ""Fanart"""
            'trailer
            PictureBox37.Image = Toolbar16.Ok
            Label64.Text = "im Unterordner ""Trailer"""
            'Darsteller
            PictureBox36.Image = Toolbar16.Ok
            Label68.Text = "Darstller-Pfad unter ""Darsteller"" festlegen"
        End If

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub TreeViewVista1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewVista1.AfterSelect
        If TypeOf TreeViewVista1.SelectedNode.Tag Is Panel = True Then
            Dim p As Panel
            p = CType(TreeViewVista1.SelectedNode.Tag, Panel)
            p.Show()
            p.BringToFront()
            my_lineh.BringToFront()
        Else
            If TypeOf TreeViewVista1.SelectedNode.FirstNode.Tag Is Panel = True Then
                Dim p As Panel
                p = CType(TreeViewVista1.SelectedNode.FirstNode.Tag, Panel)
                p.Show()
                p.BringToFront()
                my_lineh.BringToFront()
            End If
        End If


    End Sub

    Private Sub Kon_plugin_Filme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kon_plugin_Filme.CheckedChanged
        If Kon_plugin_Filme.Checked = True Then

            lbl_plugin_info.Text = "Info.xml"

            Label63.Text = "folder.jpg"
            'Backdrops
            PictureBox35.Image = Toolbar16.Ok
            Label66.Text = "im Unterordner ""Fanart"""
            'trailer
            PictureBox37.Image = Toolbar16.Ok
            Label64.Text = "im Unterordner ""Trailer"""
            'Darsteller
            PictureBox36.Image = Toolbar16.Ok
            Label68.Text = "Darstller-Pfad unter ""Darsteller"" festlegen"
        End If
    End Sub

    Private Sub Kon_plugin_Mediabrowser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kon_plugin_Mediabrowser.CheckedChanged
        If Kon_plugin_Mediabrowser.Checked = True Then

            lbl_plugin_info.Text = "mymovies.xml"

            Label63.Text = "folder.jpg (folder.png wird erkannt)"
            'Backdrops
            PictureBox35.Image = Toolbar16.Ok
            Label66.Text = "Backdrop(n).jpg"
            'trailer
            PictureBox37.Image = Toolbar16.Ok
            Label64.Text = "moviename-trailer.avi"
            'Darsteller
            PictureBox36.Image = Toolbar16.Ok
            Label68.Text = "ImagesByName unter ""Darsteller"" festlegen"
        End If
    End Sub

    Private Sub Kon_plugin_XBMC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kon_plugin_XBMC.CheckedChanged
        If Kon_plugin_XBMC.Checked = True Then

            lbl_plugin_info.Text = "movie.nfo"

            Label63.Text = "movie.tbn"
            'Backdrops
            PictureBox35.Image = Toolbar16.Ok
            Label66.Text = "fanart.jpg (mehrere im Unterordner ""extrathumbs"")"
            'trailer
            PictureBox37.Image = Toolbar16.Ok
            Label64.Text = "moviename-trailer.avi"
            'Darsteller
            PictureBox36.Image = Toolbar16.Ok_gray
            Label68.Text = "wird nicht unterstützt"
        End If
    End Sub

    Private Sub Kon_plugin_WindowsFilme_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kon_plugin_WindowsFilme.CheckedChanged
        If Kon_plugin_WindowsFilme.Checked = True Then

            lbl_plugin_info.Text = """movie.dvdinfo.xml""-Datei gespeichert. Außerdem wird in dem Cache des Windows Media Centers eine Datei erstellt."

            Label63.Text = "folder.jpg"
            'Backdrops
            PictureBox35.Image = Toolbar16.Ok_gray
            Label66.Text = "wird nicht unterstützt"
            'trailer
            PictureBox37.Image = Toolbar16.Ok_gray
            Label64.Text = "wird nicht unterstützt"
            'Darsteller
            PictureBox36.Image = Toolbar16.Ok_gray
            Label68.Text = "wird nicht unterstützt"
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaInfo_Download.Click
        Dim dl As New Progress_InstallMediaInfo
        If MediaInfo_Download.Text = "Download" Then
            dl.needrestart = False
        Else
            dl.needrestart = True
        End If
        If dl.needrestart = True Then
            If MsgBox("Das Programm muss nach dem Download neu gestartet werden. Möchten Sie fortfahren?", MsgBoxStyle.YesNoCancel, "MediaInfo") = MsgBoxResult.Yes Then
                dl.Run()
            End If
        Else
            dl.Run()
        End If





        ''Dim m As New Net.WebClient
        'Dim b32 As New Uri("http://fio.square7.ch/Download/MediaInfo/MediaInfo32.dll")
        'Dim b64 As New Uri("http://fio.square7.ch/Download/MediaInfo/MediaInfo64.dll")
        ''If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
        ''    IO.File.Delete(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll"))
        ''End If
        'If Not IO.Directory.Exists(Einstellungen.ChachePath) Then
        '    IO.Directory.CreateDirectory(Einstellungen.ChachePath)
        'End If
        'If OS.GetOSType = OS.OSType.Is64Bit Then
        '    mIDownloader.DownloadFileAsync(b64, IO.Path.Combine(Einstellungen.ChachePath, "MediaInfo.dll"))
        'Else
        '    mIDownloader.DownloadFileAsync(b32, IO.Path.Combine(Einstellungen.ChachePath, "MediaInfo.dll"))
        'End If
        ''AddHandler m.DownloadProgressChanged, m_DownloadProgressChanged(m, m.System.Net.DownloadDataCompletedEventArgs)
        'laden = New Laden_Dialog
        'laden.Timecounter = False
        'laden.aCancel = False
        'laden.aDetails = False
        'laden.Labelstring = "Download"
        'laden.Text = "Download von MediaInfo-Plugin"
        'laden.Show()
    End Sub
    Dim laden As Laden_Dialog
    Private Sub mIDownloader_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles mIDownloader.DownloadFileCompleted



        laden.closallowed = True
        laden.Dispose()
        laden.Close()
        If MsgBox("Das Programm muss neu gestartet werden um die Änderungen wirksam zu machen" & vbCrLf & "Jetzt neu starten?", vbYesNoCancel) = MsgBoxResult.Yes Then
            Me.Close()
            MainForm.restart = True

            MainForm.Close()

        End If

        'MediaInfoCheck()

    End Sub

    Private Sub m_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles mIDownloader.DownloadProgressChanged
        'laden.Aktualisieren(e.ProgressPercentage)
        laden.ProgressBar1.Value = e.ProgressPercentage
        Laden.Label1.Text = e.BytesReceived & "/" & e.TotalBytesToReceive
    End Sub

    Private Sub Button4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        ContextMenu_RenameFormat.Tag = Save_rename_Folderpat
        ContextMenu_RenameFormat.Show(Button4, New Point(0, Button4.Height + 2))
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        ContextMenu_RenameFormat.Tag = Save_rename_Filepat
        ContextMenu_RenameFormat.Show(Button6, New Point(0, Button6.Height + 2))
    End Sub

    Private Sub TitelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%titel%"
            tb.Focus()
        End If
    End Sub

    Private Sub OriginaltitelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OriginaltitelToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%o_titel%"
            tb.Focus()
        End If
    End Sub

    Private Sub SortierungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SortierungToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%s_titel%"
            tb.Focus()
        End If
    End Sub

    Private Sub JahrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JahrToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%jahr%"
            tb.Focus()
        End If
    End Sub

    Private Sub KanäleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KanäleToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%a_channels%"
            tb.Focus()
        End If
    End Sub

    Private Sub CodecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodecToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%a_codec%"
            tb.Focus()
        End If
    End Sub

    Private Sub FramerateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FramerateToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%v_framerate%"
            tb.Focus()
        End If
    End Sub

    Private Sub AuflösungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuflösungToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%v_aufloesung%"

            tb.Focus()
        End If
    End Sub

    Private Sub CodecToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CodecToolStripMenuItem1.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%v_codec%"

            tb.Focus()
        End If
    End Sub

    Private Sub IfNullxyzToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IfNullxyzToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%ifnull(*zu überprüfende Wert*,*normalesFormat*,*nullFormat*)"
            tb.Focus()
        End If
    End Sub

    Private Sub TitelJahrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelJahrToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.Text = "%titel% (%jahr%)"
            tb.Focus()
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_rename_Folderpat.TextChanged
        If Save_rename_Folderpat.Text = "" Then
            Label31.Text = "Ordner wird nicht umbenannt"
        Else
            Label31.Text = Renamer.Formatget(Save_rename_Folderpat.Text)
        End If
    End Sub

    Private Sub TitelOriginaltitelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelOriginaltitelToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.Text = "%titel% (%o_titel%)"
            tb.Focus()
        End If
    End Sub

    Private Sub TitelJahrVideoAuflösungVideoCodecAudioCodecAudioKanäleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelJahrVideoAuflösungVideoCodecAudioCodecAudioKanäleToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            'tb.Text = "%titel%%ifnull(%jahr%, (%jahr%),)%ifnull(%v_aufloesung%, [%v_aufloesung%%ifnull(%v_codec%, {%v_codec%}],]), %ifnull(%v_codec%, [%v_codec%],))"
            tb.Text = "%titel% (%jahr%) [%v_aufloesung% {%v_codec%}] [%a_codec% {%a_channels%}]"
            tb.Focus()
        End If
    End Sub


    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_rename_Filepat.TextChanged
        If Save_rename_Filepat.Text = "" Then
            Label32.Text = "Datei wird nicht umbenannt"
            If Save_Rename_moreFiles.Checked = False Then
                Save_rename_Filespat.Text = ""
            End If

        Else
            Label32.Text = Renamer.Formatget(Save_rename_Filepat.Text) & ".avi"
            If Save_Rename_moreFiles.Checked = False Then
                Save_rename_Filespat.Text = Save_rename_Filepat.Text & " Teil " & "{n}"
            End If
        End If



    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Fortschritt_modus_Eigene.CheckedChanged
        Button7.Enabled = Fortschritt_modus_Eigene.Checked
        Fortschritt_Ordner.Enabled = Not Fortschritt_modus_Eigene.Checked
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Einstellungen.Config_Fortschritt.LoadtoDialog()

        If Bewertungsmuster.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Einstellungen.Config_Fortschritt.SavefromDialog()
        End If

    End Sub



    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not TextBox1.Text = "" Then
            Laden_Dateien_List.Items.Add(TextBox1.Text)
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            Process.Start("http://xbmc.org/")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MediaCenter_Windows_pfad.Text = ChooseFolder(MediaCenter_Windows_pfad.Text)
        Me.Focus()

    End Sub
    Private Function ChooseFolder(Optional ByVal StartFolder As String = "") As String
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
            If m.ShowDialog = CommonFileDialogResult.OK Then
                'Clear_DG(True)
                'Einstellungen.Config_Laden.Laden_Ordner_Suche = checkA.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = checkB.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = checkC.IsChecked
                'Einstellungen.Config_Laden.Laden_Ordner_suchmodus = rlist.SelectedIndex
                's(0) = m.FileNames
                r = m.FileName

            End If
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


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Einstellungen.Config_Update.Update_last = Now

        Update_Last.Text = Einstellungen.Config_Update.Update_last.ToString
        Dim p As New Progress_CheckForUpdates
        p.Dialog = True
        p.Run()
    End Sub


    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dialog_Filterbearbeiten.DataGridView1.Rows.Clear()

        If Genre_language.SelectedIndex = -1 Then
            Einstellungen.Config_Genre.Genre_language = 0
        Else
            Einstellungen.Config_Genre.Genre_language = Genre_language.SelectedIndex
        End If
        If Einstellungen.GenreFilter.FilterList.Count > 0 Then

            Dim rc(Einstellungen.GenreFilter.FilterList.Count - 1) As DataGridViewRow
            For x As Integer = 0 To Einstellungen.GenreFilter.FilterList.Count - 1
                Dim r As New DataGridViewRow

                r.CreateCells(Dialog_Filterbearbeiten.DataGridView1)
                r.Cells(0).Value = Einstellungen.GenreFilter.FilterList(x).id
                r.Cells(1).Value = Einstellungen.GenreFilter.FilterList(x).Name
                r.Cells(2).Value = Einstellungen.GenreFilter.FilterList(x).Filter
                r.Cells(3).Value = Einstellungen.GenreFilter.FilterList(x).altName
                rc(x) = r

            Next
            Dialog_Filterbearbeiten.DataGridView1.Rows.AddRange(rc)
        End If

        If Dialog_Filterbearbeiten.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim glnew As New List(Of Einstellungen.gFilter)
            If Dialog_Filterbearbeiten.DataGridView1.Rows.Count > 0 Then
                For x As Integer = 0 To Dialog_Filterbearbeiten.DataGridView1.Rows.Count - 1
                    Dim g As New Einstellungen.gFilter
                    With Dialog_Filterbearbeiten.DataGridView1.Rows(x)
                        g.Name = CStr(.Cells(1).Value)
                        g.id = CStr(.Cells(0).Value)
                        g.Filter = CStr(.Cells(2).Value)
                        g.altName = CStr(.Cells(3).Value)
                        glnew.Add(g)

                    End With

                Next
                Einstellungen.GenreFilter.FilterList = glnew
            End If


        End If

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If Not TreeView_filter.SelectedNode Is Nothing Then
            TreeView_filter.Nodes.Remove(TreeView_filter.SelectedNode)
        End If



    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        TreeView_filter.Nodes.Add("")
        TreeView_filter.SelectedNode = TreeView_filter.Nodes(TreeView_filter.Nodes.Count - 1)
        TextBox2.Text = ""
    End Sub

    Private Sub HöheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HöheToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%v_höhe%"

            tb.Focus()
        End If
    End Sub

    Private Sub BreiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BreiteToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%v_breite%"

            tb.Focus()
        End If
    End Sub

    Private Sub GenreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenreToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%genre%"

            tb.Focus()
        End If
    End Sub

    Private Sub ProduktionslandToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduktionslandToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%land%"

            tb.Focus()
        End If
    End Sub

    Private Sub Regisseur1NameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Regisseur1NameToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%regie%"

            tb.Focus()
        End If
    End Sub
    Private Sub TitelJahrVideoAuflösungVideoCodecAudioCodecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitelJahrVideoAuflösungVideoCodecAudioCodecToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            'tb.Text = "%titel%%ifnull(%jahr%, (%jahr%),)%ifnull(%v_aufloesung%, [%v_aufloesung%%ifnull(%v_codec%, {%v_codec%}],]), %ifnull(%v_codec%, [%v_codec%],))"
            tb.Text = "%titel% (%jahr%) [%v_aufloesung% (%v_codec%)] [%a_codec%]"
            tb.Focus()
        End If
    End Sub

    Private Sub JahrTitelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JahrTitelToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            'tb.Text = "%titel%%ifnull(%jahr%, (%jahr%),)%ifnull(%v_aufloesung%, [%v_aufloesung%%ifnull(%v_codec%, {%v_codec%}],]), %ifnull(%v_codec%, [%v_codec%],))"
            tb.Text = "%jahr% - %titel%"
            tb.Focus()
        End If
    End Sub

    Public Sub Moviethumbcheck()
        If IO.File.Exists(Application.StartupPath & "\Plugins\moviesheet\mtn.exe") Then
            Moviethumbnailerinfopic.Image = Toolbar16.Ok
            MoviesheetInstalled.Text = "Moviethumbnailer ist installiert"
            Button12.Enabled = False
        Else
            Moviethumbnailerinfopic.Image = Toolbar16.Abbrechen
            MoviesheetInstalled.Text = "Moviethumbnailer ist nicht installiert"
            Button12.Enabled = True
        End If
    End Sub
    Public Sub FFProbecheck()
        If IO.File.Exists(Application.StartupPath & "\Plugins\ffprobe\ffprobe.exe") Then
            FFProbeinfopic.Image = Toolbar16.Ok
            FFProbeInstalled.Text = "FFProbe ist installiert"
            FFProbeinstallbut.Enabled = False
        Else
            FFProbeinfopic.Image = Toolbar16.Abbrechen
            FFProbeInstalled.Text = "FFProbe ist nicht installiert"
            FFProbeinstallbut.Enabled = True

        End If
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim g As New Progress_InstallMovieSheet
        g.Run()
    End Sub

    Private Sub LinkLabel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel21.Click
        Try
            Process.Start("http://mediainfo.sourceforge.net/de/Download/Windows")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel22.Click
        Try
            Process.Start("http://moviethumbnail.sourceforge.net/")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub TreeViewVista1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeViewVista1.MouseEnter
    '    'Me.BackColor = SystemColors.Control
    '    Panel1.BackColor = SystemColors.Window
    '    TreeViewVista1.BackColor = SystemColors.Window
    'End Sub

    'Private Sub TreeViewVista1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TreeViewVista1.MouseLeave
    '    'Me.BackColor = SystemColors.Window
    '    Panel1.BackColor = SystemColors.Control
    '    TreeViewVista1.BackColor = SystemColors.Control
    'End Sub

    Private Sub LinkLabel23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel23.Click
        If Not TreeViewVista1.SelectedNode Is Nothing Then


            Select Case TreeViewVista1.SelectedNode.Text
                Case Is = "Speichern"
                    Einstellungen.Config_Save.Standard_Artikel()
                Case Is = "Artikel"
                    Einstellungen.Config_Save.Standard_Artikel()
                Case Is = "Genre"
                    Einstellungen.Config_Genre.Standard()
                Case Is = "Film-Informationen"
                    Einstellungen.Config_Genre.Standard()
                Case Is = "Abrufen"
                    Einstellungen.Config_Abrufen.Standard_Backdrops()
                Case Is = "Cover & Backdrops"
                    Einstellungen.Config_Abrufen.Standard_Backdrops()
                Case Is = "Media Info"
                    Einstellungen.Config_Abrufen.Standard_MediaInfo()
                Case Is = "Media Info"
                    Einstellungen.Config_Abrufen.Standard_MediaInfo()
                Case Is = "Media Center"
                    Einstellungen.Config_MediaCenter.Standard_MediaCenter()
                Case Is = "Filmbibliothek"
                    Einstellungen.Config_MediaCenter.Standard_Windows()
                Case Is = "Laden"
                    Einstellungen.Config_Laden.Standard_Ordner()
                Case Is = "Ordner"
                    Einstellungen.Config_Laden.Standard_Ordner()
                Case Is = "Favoriten"
                    Einstellungen.Config_Laden.Standard_Favs()
                Case Is = "Dateitypen"
                    Einstellungen.Config_Laden.Standard_Dateien()
                Case Is = "Umbenennen"
                    Einstellungen.Config_Save.Standard_Rename()
                Case Is = "Filter"
                    Einstellungen.Config_Filter.Standard()
                Case Is = "Fortschritt"
                    Einstellungen.Config_Fortschritt.Standard()
                Case Is = "MovieSheets"
                    Einstellungen.Config_Abrufen.Standard_Moviesheet()
                Case Is = "Darstellung"
                    Einstellungen.Config_Design.Standard()
                Case Is = "Trailer"
                    Einstellungen.Config_Trailer.Standard()
            End Select
        End If
    End Sub

    Private Sub TreeViewVista1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TreeView_filter.DragOver
        Dim loc As Point = (CType(sender, TreeView)).PointToClient(New Point(e.X, e.Y))
        Dim node As TreeNode = CType(e.Data.GetData(GetType(TreeNode)), TreeNode)
        Dim destNode As TreeNode = (CType(sender, TreeView)).GetNodeAt(loc)
        If Not destNode Is Nothing And Not node Is Nothing Then

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
                    TreeView_filter.SelectedNode = node
                    TreeView_filter.Refresh()

                End If
            End If
        End If
    End Sub
    Private Sub tvw_ItemDrag(ByVal sender As Object, ByVal e As ItemDragEventArgs) Handles TreeView_filter.ItemDrag
        TreeView_filter.DoDragDrop(e.Item, DragDropEffects.Move)
    End Sub

    Private Sub tvw_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_filter.DragEnter
        e.Effect = DragDropEffects.Move

    End Sub

    Private Sub tvw_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles TreeView_filter.DragDrop
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
            TreeView_filter.SelectedNode = node

            'r.DisplayIndex = node.Index
        End If
    End Sub

    Private Sub TreeView_filter_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_filter.AfterSelect
        If Not TreeView_filter.SelectedNode Is Nothing Then
            TextBox2.Text = TreeView_filter.SelectedNode.Text
        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If Not TreeView_filter.SelectedNode Is Nothing Then
            TreeView_filter.SelectedNode.Text = TextBox2.Text
        End If
    End Sub

    Private Sub TreeView_filter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TreeView_filter.KeyDown
        If e.Alt = False And e.Control = False And e.KeyCode = Keys.Delete Then
            If Not TreeView_filter.SelectedNode Is Nothing Then
                TreeView_filter.Nodes.Remove(TreeView_filter.SelectedNode)
            End If

        End If
    End Sub

    Private Sub Config_Design_rand_hervorheben_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Config_Design_rand_hervorheben.CheckedChanged
        'With Me
        '    MainForm.ToolStripSeparator2.Visible = .Config_Design_rand_hervorheben.Checked
        '    MainForm.ToolStripSeparator43.Visible = .Config_Design_rand_hervorheben.Checked
        '    MainForm.ToolStripSeparator48.Visible = .Config_Design_rand_hervorheben.Checked
        '    MainForm.ToolStripSeparator49.Visible = .Config_Design_rand_hervorheben.Checked
        'End With
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        'With MainForm


        '    If RadioButton2.Checked = False Then
        '        .Nov_Main.Visible = False
        '        .Nov_Main_alt.Visible = True
        '        .Refresh_Toolbar_States()
        '    Else
        '        .Nov_Main.Visible = True
        '        .Nov_Main_alt.Visible = False
        '        .Refresh_Toolbar_States()
        '    End If
        'End With
        'GroupBox39.Enabled = Not RadioButton2.Checked
        'GroupBox38.Enabled = Not RadioButton2.Checked
    End Sub


    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged, RadioButton6.CheckedChanged, RadioButton5.CheckedChanged
        'With Me
        '    If .RadioButton7.Checked = True Then
        '        MainForm.SplitContainer_Infopanel.Panel2.BackColor = SystemColors.Control
        '    ElseIf .RadioButton5.Checked = True Then
        '        MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.White
        '    ElseIf .RadioButton6.Checked = True Then
        '        MainForm.SplitContainer_Infopanel.Panel2.BackColor = Color.FromArgb(241, 245, 251)
        '    End If
        'End With
    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        'If RadioButton10.Checked Then
        '    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Text
        'Else
        '    MainForm.Exp_Organisieren.DisplayStyle = ToolStripItemDisplayStyle.Image
        'End If

    End Sub


    Private Sub alwaysExplore_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles alwaysExplore.CheckedChanged
        'Einstellungen.Config_Design.alwaysExplore = alwaysExplore.Checked
        'MainForm.Refresh_Toolbar_States()

    End Sub

    Private Sub TextBox3_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_rename_Filespat.TextChanged
        If Save_rename_Filespat.Text = "" Then
            Label21.Text = "Dateien werden nicht umbenannt"
            Label21.ForeColor = SystemColors.GrayText
        Else
            If Save_rename_Filespat.Text.Contains("{n}") = True Then
                Label21.Text = Renamer.Formatget(Save_rename_Filespat.Text).Replace("{n}", "1").Replace("{g}", "3") & ".avi"
                Label21.ForeColor = SystemColors.GrayText
            Else
                Label21.Text = "Es muss {n} für die Nummerierung vorhanden sein."
                Label21.ForeColor = Color.Red
            End If
        End If



    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        ContextMenu_RenameFormat.Tag = Save_rename_Filespat
        ContextMenu_RenameFormat.Show(Button13, New Point(0, Button13.Height + 2))
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save_Rename_moreFiles.CheckedChanged
        Save_rename_Filespat.Enabled = Save_Rename_moreFiles.Checked
        Button13.Enabled = Save_Rename_moreFiles.Checked
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exp_Context_reg.Click
        If Exp_Context_reg.Text = "Erstellen" Then
            ExplorerContextMenu.AddToExplorerContextMenu("Folder", _
      "Film Info! Organizer", Application.ExecutablePath & " ""%1""")
            Exp_Context_reg.Text = "Entfernen"
        Else
            ExplorerContextMenu.RemoveFromExplorerContextMenu("Folder", _
    "Film Info! Organizer")
            Exp_Context_reg.Text = "Erstellen"
        End If


    End Sub

    Private Sub Button14_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        MediaBrowser_ImagesByName.Text = ChooseFolder(MediaBrowser_ImagesByName.Text)
        Me.Focus()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MainForm.clear_infoCache()
        Dim c As String = IO.Path.Combine(Einstellungen.ChachePath, "Cache")
        Dim d As Long = FolderSize.GetFolderSize(c)
        Label60.Text = "Größe: " & WebFunctions.FormatBytes(d)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Avimux_pfad.Text = OpenFileDialog1.FileName

        End If





        Me.Focus()
    End Sub

    Private Sub IMDbIDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IMDbIDToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%imdbid%"

            tb.Focus()
        End If
    End Sub

    Private Sub FFProbeinstallbut_Click(sender As Object, e As EventArgs) Handles FFProbeinstallbut.Click
        Dim g As New Progress_InstallFFProbe
        g.Run()
    End Sub

    Private Sub BewertungToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BewertungToolStripMenuItem.Click
        Dim tb As TextBox = TryCast(ContextMenu_RenameFormat.Tag, TextBox)
        If tb IsNot Nothing Then
            tb.SelectedText = "%bewertung%"

            tb.Focus()
        End If
    End Sub
End Class
