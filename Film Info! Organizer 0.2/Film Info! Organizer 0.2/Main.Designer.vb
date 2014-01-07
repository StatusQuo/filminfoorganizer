<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MForm))
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ordner", 1, 1)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Favoriten", 3, 3)
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Filme")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("", -2, -2)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Serien", 2, 2)
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TreeviewImagelist = New System.Windows.Forms.ImageList(Me.components)
        Me.Nov_Main = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.Infobaranzeigen_tool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.ToolStripButton_Downloads = New System.Windows.Forms.ToolStripButton()
        Me.Speichern_Tool = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoxmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MymoviesxmlToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MovienfoXBMCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoviedvdidxmlWindowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Export = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem75 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Exportieren = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaInfo_tool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip_Suche = New System.Windows.Forms.ToolStripSplitButton()
        Me.DropDownMenu_Suche = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SchnelleSuche_DropDownMenu_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.NormaleSuche_DropDownMenu_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExacteSuche_DropDownMenu_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator52 = New System.Windows.Forms.ToolStripSeparator()
        Me.IMDBVerwenden_DropDownMenu_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.Genre_DropDownMenu_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exp_Suche = New System.Windows.Forms.ToolStripSplitButton()
        Me.Cover_Tool = New System.Windows.Forms.ToolStripSplitButton()
        Me.DropDownMenu_Cover = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem43 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem72 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem73 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem74 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator63 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrailerLadenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tool_Rename = New System.Windows.Forms.ToolStripButton()
        Me.openselfolder_tool = New System.Windows.Forms.ToolStripButton()
        Me.Apspielen_tool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.Ordnerladen_Tool = New System.Windows.Forms.ToolStripButton()
        Me.Ordnerhinzufügen_tool = New System.Windows.Forms.ToolStripButton()
        Me.refresh_tool = New System.Windows.Forms.ToolStripButton()
        Me.Listeleeren_Tool = New System.Windows.Forms.ToolStripButton()
        Me.Einstellungen_Tool = New System.Windows.Forms.ToolStripSplitButton()
        Me.OptionenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpaltenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenüleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WerkzeugeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator19 = New System.Windows.Forms.ToolStripSeparator()
        Me.Radio_nToolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_dToolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator59 = New System.Windows.Forms.ToolStripSeparator()
        Me.NavigationsleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoPanelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator43 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.exp_menu_export = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_Download = New System.Windows.Forms.ToolStripSplitButton()
        Me.DropDown_Trailer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrailerAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomatischToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator62 = New System.Windows.Forms.ToolStripSeparator()
        Me.YoutubeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nav_Menu = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMainItem_Datei = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Speichern = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Speichern_unter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripMenuItem()
        Me.KonvertierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BilderInfosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuXBMCKonvertierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuXBMCKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuFilmePluginKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuMediaBrowserKopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.OrdnerLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerienLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerhinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menutool_listeleeren = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMainItem_Bearbeiten = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_CoverFanart = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_CoverFanartauto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThumbnailsErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem32 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CoverUndFanartLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator33 = New System.Windows.Forms.ToolStripSeparator()
        Me.TrailerLadenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator51 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_Copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_copyto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_moveto = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilmordnerLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator54 = New System.Windows.Forms.ToolStripSeparator()
        Me.OrdnerUmbenennenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeldBearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenreHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SammlungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Sammlung = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripLabel_SammlungenOPT = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.HinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_Sammlung = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkierungToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Flags = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.KeineMarkierungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FragezeichenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NeuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkiertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator60 = New System.Windows.Forms.ToolStripSeparator()
        Me.CoverToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FanartToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WichtigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarkierungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator34 = New System.Windows.Forms.ToolStripSeparator()
        Me.SicherungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SicherungErstellenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SichrungErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator35 = New System.Windows.Forms.ToolStripSeparator()
        Me.WiederherstellenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator50 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SortierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMainItem_Info = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem31 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem30 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem29 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator32 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem_MediaInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Abspielen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Ordnerdurchsuchen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem39 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VideosVergleichenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnsichtToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WerkzeugleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator58 = New System.Windows.Forms.ToolStripSeparator()
        Me.Radio_NorToolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_DynToolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator20 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMainItem_Extras = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilmeZusammenfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpaltenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMainItem_Hilfe = New System.Windows.Forms.ToolStripMenuItem()
        Me.HilfeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FehlerMeldenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator28 = New System.Windows.Forms.ToolStripSeparator()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabImages = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenu_TextBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RückgäningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.SuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Cover = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EinfügenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackdropAusZwischenablageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.GoogleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoviemazeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Overwrite = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.Radio_AutomatischToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_ErgänzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_ErsetzenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_BenutzerdefiniertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.OverwriteMenuItem_Titel = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Originaltitel = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Sort = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Produktionsjahr = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_IMDB_ID = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Bewertung = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_FSK = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Studios = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Genre = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Regisseur = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Produktionsland = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Autoren = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Darsteller = New System.Windows.Forms.ToolStripMenuItem()
        Me.OverwriteMenuItem_Inhalt = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nav_Treeview = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Add_Fav = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_del_fav = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer_treepanel = New System.Windows.Forms.SplitContainer()
        Me.Panel_treepadding = New System.Windows.Forms.Panel()
        Me.TreeViewVista1 = New Film_Info__Organizer.TreeViewVista()
        Me.TreeView_Opt_Columns = New Film_Info__Organizer.TreeViewVista()
        Me.Navigationsleiste = New Film_Info__Organizer.TreeViewVista()
        Me.Download_Panel = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Download_info_Prozent = New System.Windows.Forms.Label()
        Me.Download_Info_Restzeit = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Download_info_Absolut = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Download_info_Geladen = New System.Windows.Forms.Label()
        Me.Download_info_Speed = New System.Windows.Forms.Label()
        Me.Nav_Download = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Download_anzeige_change = New System.Windows.Forms.ToolStripDropDownButton()
        Me.FortschrittToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeschwindigkeitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestzeitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatenmengeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator14 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloadStartenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadAbbrechenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListeLeerenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator21 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloadAutomatischStarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator22 = New System.Windows.Forms.ToolStripSeparator()
        Me.DownloadoptionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImFensterStartenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer_Infopanel = New System.Windows.Forms.SplitContainer()
        Me.Panel_Overlay_useImage = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button_useasCover = New System.Windows.Forms.Button()
        Me.Button_useasBackdrop = New System.Windows.Forms.Button()
        Me.Panel_q_Trailer = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Button_Download_Trailer = New System.Windows.Forms.Button()
        Me.Panel_flagquestion = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel_ask_selectmovie = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Movie_GridView = New System.Windows.Forms.DataGridView()
        Me.Column_Flags = New Film_Info__Organizer.DataGridViewFlagColumn()
        Me.Column_Fortschritt = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.Column_Rate_Cover = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Rate_Backdrops = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Rate_Info = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Rate_MediaInfo = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Rate_Ordner = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Pfad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Ordner = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Titel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Originaltitel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_IMDB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Darsteller = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Regie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Autoren = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Studios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Produktionsjahr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Produktionsland = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Genre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_FSK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Bewertung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Spieldauer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Kurzbeschreibung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Inhalt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_MediaInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Position = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Datum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Sort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Auflösung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Seitenverhältnis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_VideoBildwiederholungsrate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_VideoCodec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_AudioKanäle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_AudioCodec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Sprachen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_FilesCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_SizeFolder = New Film_Info__Organizer.DataGridViewSizeColumn()
        Me.Column_watched = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column_Trailer = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column_Set = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Depth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nov_line_browser = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator53 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.MyBrowser_Favicon = New System.Windows.Forms.ToolStripLabel()
        Me.Browser_Navigationtb = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.MyBrowser_Close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator15 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
        Me.Nav_Datagrid = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.Filter_Dropdown_OPT = New System.Windows.Forms.ToolStripDropDownButton()
        Me.TitelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GenreToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.JahrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator23 = New System.Windows.Forms.ToolStripSeparator()
        Me.FortschrittToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SammlungToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DummyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator24 = New System.Windows.Forms.ToolStripSeparator()
        Me.WeitereFunktionenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DoppelteFilmeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyBrowserHelpbar = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.InfoPanel_Movie1 = New Film_Info__Organizer.InfoPanel_Movie()
        Me.InfoPanel_Episode1 = New Film_Info__Organizer.InfoPanel_Episode()
        Me.Column_Ser_Progress = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.Column_Serien_RateCover = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Serien_RateInhalt = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Serien_RateMediaInfo = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Serien_RateFilename = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.Column_Ser_Titel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_Ser_Pfad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImageList_SerienGrid = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip_Textbox_Genre = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem23 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem20 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem22 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem21 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator()
        Me.BearbeitenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator27 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenu_Rows = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem24 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem25 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem26 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator30 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem27 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem28 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator31 = New System.Windows.Forms.ToolStripSeparator()
        Me.MediaInfoAbrufenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator17 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbspielenToolStripContextitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerDurchsuchenToolStripcontextitem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator61 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem40 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem41 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem42 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Columns = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SpaltenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundDownloader = New System.ComponentModel.BackgroundWorker()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Tool_Speichern = New System.Windows.Forms.ToolStripSplitButton()
        Me.SpeichernToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernAlsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilmePluginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MediaBrowserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DVDInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XBMCToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.Panel_Update = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label_Update = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel_Update_more = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Update_Link = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.Label_Update_State = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Nov_Main_alt = New System.Windows.Forms.ToolStrip()
        Me.exp_navbar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator48 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.Exp_Organisieren = New System.Windows.Forms.ToolStripDropDownButton()
        Me.exp_menu_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_saveas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem35 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem36 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem37 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem38 = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_backup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem59 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem60 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator41 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem61 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator55 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem62 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem64 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem63 = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_sep_file1 = New System.Windows.Forms.ToolStripSeparator()
        Me.exp_menu_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_kopieren = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_verschieben = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_delet = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_menu_sep_file_big = New Film_Info__Organizer.ToolStripSeperator2()
        Me.ToolStripMenuItem65 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem66 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem67 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem68 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator36 = New System.Windows.Forms.ToolStripSeparator()
        Me.LayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem54 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WerkzeugleisteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem55 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator44 = New System.Windows.Forms.ToolStripSeparator()
        Me.Radio_NormaleWerkzeugleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Radio_DynamischeWerkzeugleisteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator40 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem57 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem56 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator57 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem53 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem51 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator45 = New System.Windows.Forms.ToolStripSeparator()
        Me.exp_menu_downloads = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_dl_Fortschritt = New System.Windows.Forms.ToolStripLabel()
        Me.exp_dl_speed = New System.Windows.Forms.ToolStripLabel()
        Me.exp_dl_size = New System.Windows.Forms.ToolStripLabel()
        Me.exp_dl_time = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator39 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem58 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator46 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem69 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem70 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator47 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem71 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exp_Öffnen_XP = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem77 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem52 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator56 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem34 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exp_Öffnen_better = New System.Windows.Forms.ToolStripButton()
        Me.exp_sep = New Film_Info__Organizer.ToolStripSeperator2()
        Me.Exp_Play = New System.Windows.Forms.ToolStripSplitButton()
        Me.WiedergebenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrailerWiedergebenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator42 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem50 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerpfadÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Exp_Abrufen = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItem33 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem45 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem46 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem76 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem79 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator37 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem44 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem47 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem48 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DarstellerbilderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrailerLadenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator38 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem49 = New System.Windows.Forms.ToolStripMenuItem()
        Me.exp_speichern = New System.Windows.Forms.ToolStripButton()
        Me.Exp_MediaInfo = New System.Windows.Forms.ToolStripButton()
        Me.Exp_Rename = New System.Windows.Forms.ToolStripButton()
        Me.exp_InfoPanel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator49 = New Film_Info__Organizer.ToolStripSeperator2()
        Me.exp_Downloads = New System.Windows.Forms.ToolStripButton()
        Me.ToPanelTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Toolbar_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewFlagColumn1 = New Film_Info__Organizer.DataGridViewFlagColumn()
        Me.DataGridViewProgressColumn1 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.DataGridViewRateColumn1 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn2 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn3 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn4 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn5 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewSizeColumn1 = New Film_Info__Organizer.DataGridViewSizeColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewProgressColumn2 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.DataGridViewRateColumn6 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn7 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn8 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewProgressColumn3 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.DataGridViewRateColumn9 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn10 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn11 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn12 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewProgressColumn4 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.DataGridViewRateColumn13 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn14 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn15 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn16 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewProgressColumn5 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.DataGridViewRateColumn17 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn18 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn19 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewRateColumn20 = New Film_Info__Organizer.DataGridViewRateColumn()
        Me.DataGridViewStatusColumn1 = New Film_Info__Organizer.DataGridViewStatusColumn()
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.MyStatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel_Browser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Count_size = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Count_Movies = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ContextMenu_BoxSets = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nov_Main.SuspendLayout()
        Me.ContextMenu_Export.SuspendLayout()
        Me.DropDownMenu_Suche.SuspendLayout()
        Me.DropDownMenu_Cover.SuspendLayout()
        Me.DropDown_Trailer.SuspendLayout()
        Me.Nav_Menu.SuspendLayout()
        Me.ContextMenu_Sammlung.SuspendLayout()
        Me.ContextMenu_Flags.SuspendLayout()
        Me.ContextMenu_TextBox.SuspendLayout()
        Me.ContextMenu_Cover.SuspendLayout()
        Me.ContextMenu_Overwrite.SuspendLayout()
        Me.Nav_Treeview.SuspendLayout()
        CType(Me.SplitContainer_treepanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_treepanel.Panel1.SuspendLayout()
        Me.SplitContainer_treepanel.Panel2.SuspendLayout()
        Me.SplitContainer_treepanel.SuspendLayout()
        Me.Panel_treepadding.SuspendLayout()
        Me.Download_Panel.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Nav_Download.SuspendLayout()
        CType(Me.SplitContainer_Infopanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer_Infopanel.Panel1.SuspendLayout()
        Me.SplitContainer_Infopanel.Panel2.SuspendLayout()
        Me.SplitContainer_Infopanel.SuspendLayout()
        Me.Panel_Overlay_useImage.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel_q_Trailer.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel_flagquestion.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.Panel_ask_selectmovie.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Movie_GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Nov_line_browser.SuspendLayout()
        Me.Nav_Datagrid.SuspendLayout()
        Me.MyBrowserHelpbar.SuspendLayout()
        Me.ContextMenuStrip_Textbox_Genre.SuspendLayout()
        Me.ContextMenu_Rows.SuspendLayout()
        Me.ContextMenu_Columns.SuspendLayout()
        Me.Panel_Update.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Update_more.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Nov_Main_alt.SuspendLayout()
        Me.MyStatusStrip.SuspendLayout()
        Me.ContextMenu_BoxSets.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeviewImagelist
        '
        Me.TreeviewImagelist.ImageStream = CType(resources.GetObject("TreeviewImagelist.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TreeviewImagelist.TransparentColor = System.Drawing.Color.Transparent
        Me.TreeviewImagelist.Images.SetKeyName(0, "tree_default.png")
        Me.TreeviewImagelist.Images.SetKeyName(1, "Folder124.png")
        Me.TreeviewImagelist.Images.SetKeyName(2, "Tag_Tag.png")
        Me.TreeviewImagelist.Images.SetKeyName(3, "Favoriten.png")
        Me.TreeviewImagelist.Images.SetKeyName(4, "calender.png")
        Me.TreeviewImagelist.Images.SetKeyName(5, "Löschen.png")
        Me.TreeviewImagelist.Images.SetKeyName(6, "Download_aktive.gif")
        '
        'Nov_Main
        '
        Me.Nov_Main.BackColor = System.Drawing.Color.Transparent
        Me.Nov_Main.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Nov_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nov_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton11, Me.Infobaranzeigen_tool, Me.ToolStripSeparator2, Me.ToolStripButton_Downloads, Me.Speichern_Tool, Me.MediaInfo_tool, Me.ToolStrip_Suche, Me.Cover_Tool, Me.Tool_Rename, Me.openselfolder_tool, Me.Apspielen_tool, Me.ToolStripSeparator6, Me.Ordnerladen_Tool, Me.Ordnerhinzufügen_tool, Me.refresh_tool, Me.Listeleeren_Tool, Me.Einstellungen_Tool, Me.ToolStripSeparator43})
        Me.Nov_Main.Location = New System.Drawing.Point(0, 57)
        Me.Nov_Main.Name = "Nov_Main"
        Me.Nov_Main.Padding = New System.Windows.Forms.Padding(0)
        Me.Nov_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Nov_Main.Size = New System.Drawing.Size(1096, 32)
        Me.Nov_Main.TabIndex = 13
        Me.Nov_Main.Text = "ToolStrip1"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Margin = New System.Windows.Forms.Padding(3, 3, 0, 3)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStripButton11.Size = New System.Drawing.Size(30, 26)
        Me.ToolStripButton11.Text = "Navigationsbereich"
        '
        'Infobaranzeigen_tool
        '
        Me.Infobaranzeigen_tool.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Infobaranzeigen_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Infobaranzeigen_tool.Image = CType(resources.GetObject("Infobaranzeigen_tool.Image"), System.Drawing.Image)
        Me.Infobaranzeigen_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Infobaranzeigen_tool.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Infobaranzeigen_tool.Name = "Infobaranzeigen_tool"
        Me.Infobaranzeigen_tool.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Infobaranzeigen_tool.Size = New System.Drawing.Size(30, 28)
        Me.Infobaranzeigen_tool.Text = "Info!-Panel anzeigen"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2._height = 0
        Me.ToolStripSeparator2._width = 8
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(8, 32)
        Me.ToolStripSeparator2.Visible = False
        '
        'ToolStripButton_Downloads
        '
        Me.ToolStripButton_Downloads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Downloads.Image = CType(resources.GetObject("ToolStripButton_Downloads.Image"), System.Drawing.Image)
        Me.ToolStripButton_Downloads.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Downloads.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton_Downloads.Name = "ToolStripButton_Downloads"
        Me.ToolStripButton_Downloads.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton_Downloads.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton_Downloads.Text = "Downloads"
        '
        'Speichern_Tool
        '
        Me.Speichern_Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Speichern_Tool.DropDownButtonWidth = 16
        Me.Speichern_Tool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.SpeichernUnterToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.Speichern_Tool.Image = CType(resources.GetObject("Speichern_Tool.Image"), System.Drawing.Image)
        Me.Speichern_Tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Speichern_Tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Speichern_Tool.Name = "Speichern_Tool"
        Me.Speichern_Tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Speichern_Tool.Size = New System.Drawing.Size(49, 26)
        Me.Speichern_Tool.Text = "Speichern"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.ToolStripMenuItem1.Text = "Speichern"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InfoxmlToolStripMenuItem, Me.MymoviesxmlToolStripMenuItem, Me.MovienfoXBMCToolStripMenuItem, Me.MoviedvdidxmlWindowsToolStripMenuItem})
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter..."
        '
        'InfoxmlToolStripMenuItem
        '
        Me.InfoxmlToolStripMenuItem.Image = CType(resources.GetObject("InfoxmlToolStripMenuItem.Image"), System.Drawing.Image)
        Me.InfoxmlToolStripMenuItem.Name = "InfoxmlToolStripMenuItem"
        Me.InfoxmlToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.InfoxmlToolStripMenuItem.Text = "Info.xml (Plugin Filme)"
        '
        'MymoviesxmlToolStripMenuItem
        '
        Me.MymoviesxmlToolStripMenuItem.Image = CType(resources.GetObject("MymoviesxmlToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MymoviesxmlToolStripMenuItem.Name = "MymoviesxmlToolStripMenuItem"
        Me.MymoviesxmlToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MymoviesxmlToolStripMenuItem.Text = "mymovies.xml (Media Browser)"
        '
        'MovienfoXBMCToolStripMenuItem
        '
        Me.MovienfoXBMCToolStripMenuItem.Image = CType(resources.GetObject("MovienfoXBMCToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MovienfoXBMCToolStripMenuItem.Name = "MovienfoXBMCToolStripMenuItem"
        Me.MovienfoXBMCToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MovienfoXBMCToolStripMenuItem.Text = "movie.nfo (XBMC)"
        '
        'MoviedvdidxmlWindowsToolStripMenuItem
        '
        Me.MoviedvdidxmlWindowsToolStripMenuItem.Image = CType(resources.GetObject("MoviedvdidxmlWindowsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoviedvdidxmlWindowsToolStripMenuItem.Name = "MoviedvdidxmlWindowsToolStripMenuItem"
        Me.MoviedvdidxmlWindowsToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MoviedvdidxmlWindowsToolStripMenuItem.Text = "movie.dvdid.xml (Windows)"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.DropDown = Me.ContextMenu_Export
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ExportToolStripMenuItem.Text = "Exportieren"
        '
        'ContextMenu_Export
        '
        Me.ContextMenu_Export.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem75})
        Me.ContextMenu_Export.Name = "ContextMenu_Export"
        Me.ContextMenu_Export.OwnerItem = Me.exp_menu_export
        Me.ContextMenu_Export.Size = New System.Drawing.Size(199, 26)
        '
        'ToolStripMenuItem75
        '
        Me.ToolStripMenuItem75.Name = "ToolStripMenuItem75"
        Me.ToolStripMenuItem75.Size = New System.Drawing.Size(198, 22)
        Me.ToolStripMenuItem75.Text = "Moviesheet vorbereiten"
        '
        'ToolStripMenuItem_Exportieren
        '
        Me.ToolStripMenuItem_Exportieren.DropDown = Me.ContextMenu_Export
        Me.ToolStripMenuItem_Exportieren.Image = CType(resources.GetObject("ToolStripMenuItem_Exportieren.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Exportieren.Name = "ToolStripMenuItem_Exportieren"
        Me.ToolStripMenuItem_Exportieren.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem_Exportieren.Text = "Exportieren"
        '
        'MediaInfo_tool
        '
        Me.MediaInfo_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MediaInfo_tool.Image = CType(resources.GetObject("MediaInfo_tool.Image"), System.Drawing.Image)
        Me.MediaInfo_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MediaInfo_tool.Margin = New System.Windows.Forms.Padding(3)
        Me.MediaInfo_tool.Name = "MediaInfo_tool"
        Me.MediaInfo_tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.MediaInfo_tool.Size = New System.Drawing.Size(32, 26)
        Me.MediaInfo_tool.Text = "Media Info laden"
        Me.MediaInfo_tool.ToolTipText = "Media Info laden..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ruft die Medien-Informationen aus der Video-Datei." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Installi" & _
    "ertes Media-Info-Plugin notwendig (Siehe Einstellungen)"
        '
        'ToolStrip_Suche
        '
        Me.ToolStrip_Suche.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStrip_Suche.DropDown = Me.DropDownMenu_Suche
        Me.ToolStrip_Suche.DropDownButtonWidth = 16
        Me.ToolStrip_Suche.Image = CType(resources.GetObject("ToolStrip_Suche.Image"), System.Drawing.Image)
        Me.ToolStrip_Suche.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStrip_Suche.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStrip_Suche.Name = "ToolStrip_Suche"
        Me.ToolStrip_Suche.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStrip_Suche.Size = New System.Drawing.Size(49, 26)
        Me.ToolStrip_Suche.Tag = "1"
        Me.ToolStrip_Suche.Text = "Datenbank-Suche"
        '
        'DropDownMenu_Suche
        '
        Me.DropDownMenu_Suche.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SchnelleSuche_DropDownMenu_Item, Me.NormaleSuche_DropDownMenu_Item, Me.ExacteSuche_DropDownMenu_Item, Me.ToolStripSeparator52, Me.IMDBVerwenden_DropDownMenu_Item, Me.Genre_DropDownMenu_Item})
        Me.DropDownMenu_Suche.Name = "DropDownMenu_Suche"
        Me.DropDownMenu_Suche.OwnerItem = Me.ToolStrip_Suche
        Me.DropDownMenu_Suche.Size = New System.Drawing.Size(181, 120)
        '
        'SchnelleSuche_DropDownMenu_Item
        '
        Me.SchnelleSuche_DropDownMenu_Item.Image = CType(resources.GetObject("SchnelleSuche_DropDownMenu_Item.Image"), System.Drawing.Image)
        Me.SchnelleSuche_DropDownMenu_Item.Name = "SchnelleSuche_DropDownMenu_Item"
        Me.SchnelleSuche_DropDownMenu_Item.Size = New System.Drawing.Size(180, 22)
        Me.SchnelleSuche_DropDownMenu_Item.Text = "Schnelle Suche"
        '
        'NormaleSuche_DropDownMenu_Item
        '
        Me.NormaleSuche_DropDownMenu_Item.Image = CType(resources.GetObject("NormaleSuche_DropDownMenu_Item.Image"), System.Drawing.Image)
        Me.NormaleSuche_DropDownMenu_Item.Name = "NormaleSuche_DropDownMenu_Item"
        Me.NormaleSuche_DropDownMenu_Item.Size = New System.Drawing.Size(180, 22)
        Me.NormaleSuche_DropDownMenu_Item.Text = "Normale Suche"
        '
        'ExacteSuche_DropDownMenu_Item
        '
        Me.ExacteSuche_DropDownMenu_Item.Image = CType(resources.GetObject("ExacteSuche_DropDownMenu_Item.Image"), System.Drawing.Image)
        Me.ExacteSuche_DropDownMenu_Item.Name = "ExacteSuche_DropDownMenu_Item"
        Me.ExacteSuche_DropDownMenu_Item.Size = New System.Drawing.Size(180, 22)
        Me.ExacteSuche_DropDownMenu_Item.Text = "Ausführliche Suche"
        '
        'ToolStripSeparator52
        '
        Me.ToolStripSeparator52.Name = "ToolStripSeparator52"
        Me.ToolStripSeparator52.Size = New System.Drawing.Size(177, 6)
        '
        'IMDBVerwenden_DropDownMenu_Item
        '
        Me.IMDBVerwenden_DropDownMenu_Item.Checked = True
        Me.IMDBVerwenden_DropDownMenu_Item.CheckOnClick = True
        Me.IMDBVerwenden_DropDownMenu_Item.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IMDBVerwenden_DropDownMenu_Item.Name = "IMDBVerwenden_DropDownMenu_Item"
        Me.IMDBVerwenden_DropDownMenu_Item.Size = New System.Drawing.Size(180, 22)
        Me.IMDBVerwenden_DropDownMenu_Item.Text = "IMDb-ID verwenden"
        '
        'Genre_DropDownMenu_Item
        '
        Me.Genre_DropDownMenu_Item.Name = "Genre_DropDownMenu_Item"
        Me.Genre_DropDownMenu_Item.Size = New System.Drawing.Size(180, 22)
        Me.Genre_DropDownMenu_Item.Text = "Genre"
        '
        'Exp_Suche
        '
        Me.Exp_Suche.AutoToolTip = False
        Me.Exp_Suche.DropDown = Me.DropDownMenu_Suche
        Me.Exp_Suche.DropDownButtonWidth = 16
        Me.Exp_Suche.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Suche.Image = CType(resources.GetObject("Exp_Suche.Image"), System.Drawing.Image)
        Me.Exp_Suche.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Suche.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Suche.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Suche.Name = "Exp_Suche"
        Me.Exp_Suche.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Suche.Size = New System.Drawing.Size(95, 26)
        Me.Exp_Suche.Text = "Suchen"
        Me.Exp_Suche.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'Cover_Tool
        '
        Me.Cover_Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Cover_Tool.DropDown = Me.DropDownMenu_Cover
        Me.Cover_Tool.DropDownButtonWidth = 16
        Me.Cover_Tool.Image = CType(resources.GetObject("Cover_Tool.Image"), System.Drawing.Image)
        Me.Cover_Tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Cover_Tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Cover_Tool.Name = "Cover_Tool"
        Me.Cover_Tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Cover_Tool.Size = New System.Drawing.Size(49, 26)
        Me.Cover_Tool.Text = "Download"
        '
        'DropDownMenu_Cover
        '
        Me.DropDownMenu_Cover.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem43, Me.ToolStripMenuItem72, Me.ToolStripSeparator9, Me.ToolStripMenuItem73, Me.ToolStripMenuItem74, Me.ToolStripSeparator63, Me.TrailerLadenToolStripMenuItem2})
        Me.DropDownMenu_Cover.Name = "DropDownMenu_Cover"
        Me.DropDownMenu_Cover.OwnerItem = Me.exp_Download
        Me.DropDownMenu_Cover.Size = New System.Drawing.Size(177, 126)
        '
        'ToolStripMenuItem43
        '
        Me.ToolStripMenuItem43.Image = CType(resources.GetObject("ToolStripMenuItem43.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem43.Name = "ToolStripMenuItem43"
        Me.ToolStripMenuItem43.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem43.Text = "Cover und Fanart"
        '
        'ToolStripMenuItem72
        '
        Me.ToolStripMenuItem72.Image = CType(resources.GetObject("ToolStripMenuItem72.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem72.Name = "ToolStripMenuItem72"
        Me.ToolStripMenuItem72.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem72.Text = "Automatisch"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItem73
        '
        Me.ToolStripMenuItem73.Name = "ToolStripMenuItem73"
        Me.ToolStripMenuItem73.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem73.Text = "Thumbnail-Creator"
        '
        'ToolStripMenuItem74
        '
        Me.ToolStripMenuItem74.Image = Global.Film_Info__Organizer.Toolbar16.darsteller
        Me.ToolStripMenuItem74.Name = "ToolStripMenuItem74"
        Me.ToolStripMenuItem74.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem74.Text = "Darstellerbilder"
        '
        'ToolStripSeparator63
        '
        Me.ToolStripSeparator63.Name = "ToolStripSeparator63"
        Me.ToolStripSeparator63.Size = New System.Drawing.Size(173, 6)
        '
        'TrailerLadenToolStripMenuItem2
        '
        Me.TrailerLadenToolStripMenuItem2.Name = "TrailerLadenToolStripMenuItem2"
        Me.TrailerLadenToolStripMenuItem2.Size = New System.Drawing.Size(176, 22)
        Me.TrailerLadenToolStripMenuItem2.Text = "Trailer laden"
        '
        'Tool_Rename
        '
        Me.Tool_Rename.AutoToolTip = False
        Me.Tool_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_Rename.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Tool_Rename.Image = CType(resources.GetObject("Tool_Rename.Image"), System.Drawing.Image)
        Me.Tool_Rename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_Rename.Margin = New System.Windows.Forms.Padding(3)
        Me.Tool_Rename.Name = "Tool_Rename"
        Me.Tool_Rename.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Tool_Rename.Size = New System.Drawing.Size(32, 26)
        Me.Tool_Rename.Text = "Umbenennen"
        '
        'openselfolder_tool
        '
        Me.openselfolder_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.openselfolder_tool.Image = CType(resources.GetObject("openselfolder_tool.Image"), System.Drawing.Image)
        Me.openselfolder_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.openselfolder_tool.Margin = New System.Windows.Forms.Padding(3)
        Me.openselfolder_tool.Name = "openselfolder_tool"
        Me.openselfolder_tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.openselfolder_tool.Size = New System.Drawing.Size(32, 26)
        Me.openselfolder_tool.Text = "Ordner durchsuchen"
        '
        'Apspielen_tool
        '
        Me.Apspielen_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Apspielen_tool.Image = CType(resources.GetObject("Apspielen_tool.Image"), System.Drawing.Image)
        Me.Apspielen_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Apspielen_tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Apspielen_tool.Name = "Apspielen_tool"
        Me.Apspielen_tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Apspielen_tool.Size = New System.Drawing.Size(32, 26)
        Me.Apspielen_tool.Text = "Film abspielen"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6._height = 0
        Me.ToolStripSeparator6._width = 8
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(8, 32)
        '
        'Ordnerladen_Tool
        '
        Me.Ordnerladen_Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Ordnerladen_Tool.Image = CType(resources.GetObject("Ordnerladen_Tool.Image"), System.Drawing.Image)
        Me.Ordnerladen_Tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Ordnerladen_Tool.Name = "Ordnerladen_Tool"
        Me.Ordnerladen_Tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Ordnerladen_Tool.Size = New System.Drawing.Size(32, 26)
        Me.Ordnerladen_Tool.Text = "Ordner laden..."
        Me.Ordnerladen_Tool.ToolTipText = "Ordner laden..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Laden Sie einen neuen Ordner und ersetzen sie dabei die bestehen" & _
    "de Liste."
        '
        'Ordnerhinzufügen_tool
        '
        Me.Ordnerhinzufügen_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Ordnerhinzufügen_tool.Image = CType(resources.GetObject("Ordnerhinzufügen_tool.Image"), System.Drawing.Image)
        Me.Ordnerhinzufügen_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Ordnerhinzufügen_tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Ordnerhinzufügen_tool.Name = "Ordnerhinzufügen_tool"
        Me.Ordnerhinzufügen_tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Ordnerhinzufügen_tool.Size = New System.Drawing.Size(32, 26)
        Me.Ordnerhinzufügen_tool.Text = "Ordner hinzufügen..."
        Me.Ordnerhinzufügen_tool.ToolTipText = "Ordner hinzufügen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fügen Sie der Liste einen weiteren Ordner hinzu."
        '
        'refresh_tool
        '
        Me.refresh_tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.refresh_tool.Image = CType(resources.GetObject("refresh_tool.Image"), System.Drawing.Image)
        Me.refresh_tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.refresh_tool.Margin = New System.Windows.Forms.Padding(3)
        Me.refresh_tool.Name = "refresh_tool"
        Me.refresh_tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.refresh_tool.Size = New System.Drawing.Size(32, 26)
        Me.refresh_tool.Text = "Aktualisieren"
        '
        'Listeleeren_Tool
        '
        Me.Listeleeren_Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Listeleeren_Tool.Image = Global.Film_Info__Organizer.Toolbar16.folder_close
        Me.Listeleeren_Tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Listeleeren_Tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Listeleeren_Tool.Name = "Listeleeren_Tool"
        Me.Listeleeren_Tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Listeleeren_Tool.Size = New System.Drawing.Size(32, 26)
        Me.Listeleeren_Tool.Text = "Liste leeren"
        '
        'Einstellungen_Tool
        '
        Me.Einstellungen_Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Einstellungen_Tool.DropDownButtonWidth = 16
        Me.Einstellungen_Tool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionenToolStripMenuItem1, Me.UpdateToolStripMenuItem1, Me.SpaltenToolStripMenuItem2, Me.ToolStripSeparator4, Me.MenüleisteToolStripMenuItem, Me.WerkzeugeToolStripMenuItem, Me.StatusleisteToolStripMenuItem, Me.ToolStripSeparator19, Me.Radio_nToolbar, Me.Radio_dToolbar, Me.ToolStripSeparator59, Me.NavigationsleisteToolStripMenuItem, Me.InfoPanelToolStripMenuItem})
        Me.Einstellungen_Tool.Image = CType(resources.GetObject("Einstellungen_Tool.Image"), System.Drawing.Image)
        Me.Einstellungen_Tool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Einstellungen_Tool.Margin = New System.Windows.Forms.Padding(3)
        Me.Einstellungen_Tool.Name = "Einstellungen_Tool"
        Me.Einstellungen_Tool.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Einstellungen_Tool.Size = New System.Drawing.Size(49, 26)
        Me.Einstellungen_Tool.Text = "Einstellungen"
        '
        'OptionenToolStripMenuItem1
        '
        Me.OptionenToolStripMenuItem1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptionenToolStripMenuItem1.Image = CType(resources.GetObject("OptionenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.OptionenToolStripMenuItem1.Name = "OptionenToolStripMenuItem1"
        Me.OptionenToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.OptionenToolStripMenuItem1.Text = "Optionen"
        '
        'UpdateToolStripMenuItem1
        '
        Me.UpdateToolStripMenuItem1.Image = CType(resources.GetObject("UpdateToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.UpdateToolStripMenuItem1.Name = "UpdateToolStripMenuItem1"
        Me.UpdateToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.UpdateToolStripMenuItem1.Text = "Update..."
        '
        'SpaltenToolStripMenuItem2
        '
        Me.SpaltenToolStripMenuItem2.Image = CType(resources.GetObject("SpaltenToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.SpaltenToolStripMenuItem2.Name = "SpaltenToolStripMenuItem2"
        Me.SpaltenToolStripMenuItem2.Size = New System.Drawing.Size(221, 22)
        Me.SpaltenToolStripMenuItem2.Text = "Spalten"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(218, 6)
        '
        'MenüleisteToolStripMenuItem
        '
        Me.MenüleisteToolStripMenuItem.Name = "MenüleisteToolStripMenuItem"
        Me.MenüleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.MenüleisteToolStripMenuItem.Text = "Menüleiste"
        '
        'WerkzeugeToolStripMenuItem
        '
        Me.WerkzeugeToolStripMenuItem.Name = "WerkzeugeToolStripMenuItem"
        Me.WerkzeugeToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.WerkzeugeToolStripMenuItem.Text = "Werkzeuge"
        '
        'StatusleisteToolStripMenuItem
        '
        Me.StatusleisteToolStripMenuItem.Name = "StatusleisteToolStripMenuItem"
        Me.StatusleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.StatusleisteToolStripMenuItem.Text = "Statusleiste"
        '
        'ToolStripSeparator19
        '
        Me.ToolStripSeparator19.Name = "ToolStripSeparator19"
        Me.ToolStripSeparator19.Size = New System.Drawing.Size(218, 6)
        '
        'Radio_nToolbar
        '
        Me.Radio_nToolbar.Name = "Radio_nToolbar"
        Me.Radio_nToolbar.Size = New System.Drawing.Size(221, 22)
        Me.Radio_nToolbar.Text = "Normale Werkzeugleiste"
        '
        'Radio_dToolbar
        '
        Me.Radio_dToolbar.Name = "Radio_dToolbar"
        Me.Radio_dToolbar.Size = New System.Drawing.Size(221, 22)
        Me.Radio_dToolbar.Text = "Dynamische Werkzeugleiste"
        '
        'ToolStripSeparator59
        '
        Me.ToolStripSeparator59.Name = "ToolStripSeparator59"
        Me.ToolStripSeparator59.Size = New System.Drawing.Size(218, 6)
        '
        'NavigationsleisteToolStripMenuItem
        '
        Me.NavigationsleisteToolStripMenuItem.Name = "NavigationsleisteToolStripMenuItem"
        Me.NavigationsleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.NavigationsleisteToolStripMenuItem.Text = "Navigationsleiste"
        '
        'InfoPanelToolStripMenuItem
        '
        Me.InfoPanelToolStripMenuItem.Name = "InfoPanelToolStripMenuItem"
        Me.InfoPanelToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.InfoPanelToolStripMenuItem.Text = "Info!-Panel"
        '
        'ToolStripSeparator43
        '
        Me.ToolStripSeparator43._height = 0
        Me.ToolStripSeparator43._width = 8
        Me.ToolStripSeparator43.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator43.AutoSize = False
        Me.ToolStripSeparator43.Name = "ToolStripSeparator43"
        Me.ToolStripSeparator43.Size = New System.Drawing.Size(8, 32)
        Me.ToolStripSeparator43.Visible = False
        '
        'exp_menu_export
        '
        Me.exp_menu_export.DropDown = Me.ContextMenu_Export
        Me.exp_menu_export.Image = Global.Film_Info__Organizer.Toolbar16.Export
        Me.exp_menu_export.Name = "exp_menu_export"
        Me.exp_menu_export.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_export.Text = "Exportieren"
        Me.exp_menu_export.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'exp_Download
        '
        Me.exp_Download.AutoToolTip = False
        Me.exp_Download.DropDown = Me.DropDownMenu_Cover
        Me.exp_Download.DropDownButtonWidth = 16
        Me.exp_Download.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.exp_Download.Image = CType(resources.GetObject("exp_Download.Image"), System.Drawing.Image)
        Me.exp_Download.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.exp_Download.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exp_Download.Margin = New System.Windows.Forms.Padding(3)
        Me.exp_Download.Name = "exp_Download"
        Me.exp_Download.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_Download.Size = New System.Drawing.Size(110, 26)
        Me.exp_Download.Text = "Download"
        Me.exp_Download.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'DropDown_Trailer
        '
        Me.DropDown_Trailer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrailerAuswählenToolStripMenuItem, Me.AutomatischToolStripMenuItem, Me.ToolStripSeparator62, Me.YoutubeToolStripMenuItem})
        Me.DropDown_Trailer.Name = "DropDown_Trailer"
        Me.DropDown_Trailer.Size = New System.Drawing.Size(167, 76)
        '
        'TrailerAuswählenToolStripMenuItem
        '
        Me.TrailerAuswählenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Media015
        Me.TrailerAuswählenToolStripMenuItem.Name = "TrailerAuswählenToolStripMenuItem"
        Me.TrailerAuswählenToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.TrailerAuswählenToolStripMenuItem.Text = "Trailer auswählen"
        '
        'AutomatischToolStripMenuItem
        '
        Me.AutomatischToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.trailer_fast
        Me.AutomatischToolStripMenuItem.Name = "AutomatischToolStripMenuItem"
        Me.AutomatischToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AutomatischToolStripMenuItem.Text = "Automatisch"
        Me.AutomatischToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator62
        '
        Me.ToolStripSeparator62.Name = "ToolStripSeparator62"
        Me.ToolStripSeparator62.Size = New System.Drawing.Size(163, 6)
        '
        'YoutubeToolStripMenuItem
        '
        Me.YoutubeToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.pw_yt
        Me.YoutubeToolStripMenuItem.Name = "YoutubeToolStripMenuItem"
        Me.YoutubeToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.YoutubeToolStripMenuItem.Text = "Youtube"
        '
        'Nav_Menu
        '
        Me.Nav_Menu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMainItem_Datei, Me.ToolStripMainItem_Bearbeiten, Me.ToolStripMainItem_Info, Me.AnsichtToolStripMenuItem, Me.ToolStripMainItem_Extras, Me.ToolStripMainItem_Hilfe})
        Me.Nav_Menu.Location = New System.Drawing.Point(0, 0)
        Me.Nav_Menu.Name = "Nav_Menu"
        Me.Nav_Menu.Padding = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.Nav_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Nav_Menu.Size = New System.Drawing.Size(1096, 25)
        Me.Nav_Menu.TabIndex = 14
        Me.Nav_Menu.Text = "MenuStrip1"
        '
        'ToolStripMainItem_Datei
        '
        Me.ToolStripMainItem_Datei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Speichern, Me.ToolStripMenuItem_Speichern_unter, Me.KonvertierenToolStripMenuItem, Me.ToolStripMenuItem_Exportieren, Me.ToolStripSeparator7, Me.OrdnerLadenToolStripMenuItem, Me.SerienLadenToolStripMenuItem, Me.OrdnerhinzufügenToolStripMenuItem, Me.ZuToolStripMenuItem, Me.menutool_listeleeren, Me.ToolStripSeparator1, Me.ToolStripMenuItem4})
        Me.ToolStripMainItem_Datei.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripMainItem_Datei.Name = "ToolStripMainItem_Datei"
        Me.ToolStripMainItem_Datei.Size = New System.Drawing.Size(46, 19)
        Me.ToolStripMainItem_Datei.Text = "&Datei"
        Me.ToolStripMainItem_Datei.ToolTipText = "Fügen Sie der Liste einen weiteren Ordner hinzu."
        '
        'ToolStripMenuItem_Speichern
        '
        Me.ToolStripMenuItem_Speichern.Image = CType(resources.GetObject("ToolStripMenuItem_Speichern.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Speichern.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripMenuItem_Speichern.Name = "ToolStripMenuItem_Speichern"
        Me.ToolStripMenuItem_Speichern.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem_Speichern.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem_Speichern.Text = "&Speichern"
        '
        'ToolStripMenuItem_Speichern_unter
        '
        Me.ToolStripMenuItem_Speichern_unter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem3, Me.ToolStripMenuItem9, Me.ToolStripMenuItem10, Me.ToolStripMenuItem11})
        Me.ToolStripMenuItem_Speichern_unter.Name = "ToolStripMenuItem_Speichern_unter"
        Me.ToolStripMenuItem_Speichern_unter.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem_Speichern_unter.Text = "Speichern unter.."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem3.Text = "Info.xml (Plugin Filme)"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem9.Text = "movie.xml (Media Browser)"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Image = CType(resources.GetObject("ToolStripMenuItem10.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem10.Text = "movie.nfo (XBMC)"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Image = CType(resources.GetObject("ToolStripMenuItem11.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(222, 22)
        Me.ToolStripMenuItem11.Text = "movie.dvdid.xml (Windows)"
        '
        'KonvertierenToolStripMenuItem
        '
        Me.KonvertierenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BilderInfosToolStripMenuItem, Me.ZuXBMCKonvertierenToolStripMenuItem, Me.ZuXBMCKopierenToolStripMenuItem, Me.ZuToolStripMenuItem1, Me.ZuFilmePluginKopierenToolStripMenuItem, Me.ZuToolStripMenuItem2, Me.ZuMediaBrowserKopierenToolStripMenuItem})
        Me.KonvertierenToolStripMenuItem.Name = "KonvertierenToolStripMenuItem"
        Me.KonvertierenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.KonvertierenToolStripMenuItem.Text = "Konvertieren"
        Me.KonvertierenToolStripMenuItem.Visible = False
        '
        'BilderInfosToolStripMenuItem
        '
        Me.BilderInfosToolStripMenuItem.Enabled = False
        Me.BilderInfosToolStripMenuItem.Name = "BilderInfosToolStripMenuItem"
        Me.BilderInfosToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.BilderInfosToolStripMenuItem.Text = "Bilder und Backdrops"
        '
        'ZuXBMCKonvertierenToolStripMenuItem
        '
        Me.ZuXBMCKonvertierenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Save_xbmc
        Me.ZuXBMCKonvertierenToolStripMenuItem.Name = "ZuXBMCKonvertierenToolStripMenuItem"
        Me.ZuXBMCKonvertierenToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ZuXBMCKonvertierenToolStripMenuItem.Text = "zu XBMC konvertieren"
        '
        'ZuXBMCKopierenToolStripMenuItem
        '
        Me.ZuXBMCKopierenToolStripMenuItem.Name = "ZuXBMCKopierenToolStripMenuItem"
        Me.ZuXBMCKopierenToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ZuXBMCKopierenToolStripMenuItem.Text = "zu XBMC kopieren"
        '
        'ZuToolStripMenuItem1
        '
        Me.ZuToolStripMenuItem1.Image = Global.Film_Info__Organizer.Toolbar16.Save_Filme
        Me.ZuToolStripMenuItem1.Name = "ZuToolStripMenuItem1"
        Me.ZuToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.ZuToolStripMenuItem1.Text = "zu Filme Plugin konvertieren"
        '
        'ZuFilmePluginKopierenToolStripMenuItem
        '
        Me.ZuFilmePluginKopierenToolStripMenuItem.Name = "ZuFilmePluginKopierenToolStripMenuItem"
        Me.ZuFilmePluginKopierenToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ZuFilmePluginKopierenToolStripMenuItem.Text = "zu Filme Plugin kopieren"
        '
        'ZuToolStripMenuItem2
        '
        Me.ZuToolStripMenuItem2.Image = Global.Film_Info__Organizer.Toolbar16.Save_mymovies
        Me.ZuToolStripMenuItem2.Name = "ZuToolStripMenuItem2"
        Me.ZuToolStripMenuItem2.Size = New System.Drawing.Size(233, 22)
        Me.ZuToolStripMenuItem2.Text = "zu MediaBrowser konvertieren"
        '
        'ZuMediaBrowserKopierenToolStripMenuItem
        '
        Me.ZuMediaBrowserKopierenToolStripMenuItem.Name = "ZuMediaBrowserKopierenToolStripMenuItem"
        Me.ZuMediaBrowserKopierenToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.ZuMediaBrowserKopierenToolStripMenuItem.Text = "zu MediaBrowser kopieren"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(225, 6)
        '
        'OrdnerLadenToolStripMenuItem
        '
        Me.OrdnerLadenToolStripMenuItem.Image = CType(resources.GetObject("OrdnerLadenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OrdnerLadenToolStripMenuItem.Name = "OrdnerLadenToolStripMenuItem"
        Me.OrdnerLadenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.OrdnerLadenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OrdnerLadenToolStripMenuItem.Text = "Ordner laden..."
        Me.OrdnerLadenToolStripMenuItem.ToolTipText = "Ordner laden..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Laden Sie einen neuen Ordner und ersetzen sie dabei die bestehen" & _
    "de Liste."
        '
        'SerienLadenToolStripMenuItem
        '
        Me.SerienLadenToolStripMenuItem.Name = "SerienLadenToolStripMenuItem"
        Me.SerienLadenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.SerienLadenToolStripMenuItem.Text = "Serien laden..."
        Me.SerienLadenToolStripMenuItem.Visible = False
        '
        'OrdnerhinzufügenToolStripMenuItem
        '
        Me.OrdnerhinzufügenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Normal_hinzufügen1
        Me.OrdnerhinzufügenToolStripMenuItem.Name = "OrdnerhinzufügenToolStripMenuItem"
        Me.OrdnerhinzufügenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.OrdnerhinzufügenToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.OrdnerhinzufügenToolStripMenuItem.Text = "Ordner hinzufügen..."
        Me.OrdnerhinzufügenToolStripMenuItem.ToolTipText = "Ordner hinzufügen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fügen Sie der Liste einen weiteren Ordner hinzu."
        '
        'ZuToolStripMenuItem
        '
        Me.ZuToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.normal_aktualisieren_new1
        Me.ZuToolStripMenuItem.Name = "ZuToolStripMenuItem"
        Me.ZuToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ZuToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ZuToolStripMenuItem.Text = "Aktualisieren"
        '
        'menutool_listeleeren
        '
        Me.menutool_listeleeren.Image = Global.Film_Info__Organizer.Toolbar16.folder_close
        Me.menutool_listeleeren.Name = "menutool_listeleeren"
        Me.menutool_listeleeren.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.menutool_listeleeren.Size = New System.Drawing.Size(228, 22)
        Me.menutool_listeleeren.Text = "Liste leeren"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(225, 6)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem4.Text = "Schließen"
        '
        'ToolStripMainItem_Bearbeiten
        '
        Me.ToolStripMainItem_Bearbeiten.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_CoverFanart, Me.ToolStripMenuItem_CoverFanartauto, Me.ThumbnailsErstellenToolStripMenuItem, Me.ToolStripMenuItem32, Me.CoverUndFanartLöschenToolStripMenuItem, Me.ToolStripSeparator33, Me.TrailerLadenToolStripMenuItem, Me.ToolStripSeparator51, Me.ToolStripMenuItem_Copy, Me.ToolStripMenuItem_Cut, Me.ToolStripMenuItem_copyto, Me.ToolStripMenuItem_moveto, Me.FilmordnerLöschenToolStripMenuItem, Me.ToolStripSeparator54, Me.OrdnerUmbenennenToolStripMenuItem, Me.FeldBearbeitenToolStripMenuItem, Me.SammlungToolStripMenuItem, Me.MarkierungToolStripMenuItem1, Me.ToolStripSeparator34, Me.SicherungToolStripMenuItem, Me.SortierenToolStripMenuItem})
        Me.ToolStripMainItem_Bearbeiten.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripMainItem_Bearbeiten.Name = "ToolStripMainItem_Bearbeiten"
        Me.ToolStripMainItem_Bearbeiten.Size = New System.Drawing.Size(75, 19)
        Me.ToolStripMainItem_Bearbeiten.Text = "&Bearbeiten"
        '
        'ToolStripMenuItem_CoverFanart
        '
        Me.ToolStripMenuItem_CoverFanart.Image = CType(resources.GetObject("ToolStripMenuItem_CoverFanart.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_CoverFanart.Name = "ToolStripMenuItem_CoverFanart"
        Me.ToolStripMenuItem_CoverFanart.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem_CoverFanart.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_CoverFanart.Text = "Cover und Fanart"
        '
        'ToolStripMenuItem_CoverFanartauto
        '
        Me.ToolStripMenuItem_CoverFanartauto.Image = CType(resources.GetObject("ToolStripMenuItem_CoverFanartauto.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_CoverFanartauto.Name = "ToolStripMenuItem_CoverFanartauto"
        Me.ToolStripMenuItem_CoverFanartauto.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem_CoverFanartauto.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_CoverFanartauto.Text = "Cover und Fanart automatisch"
        '
        'ThumbnailsErstellenToolStripMenuItem
        '
        Me.ThumbnailsErstellenToolStripMenuItem.Name = "ThumbnailsErstellenToolStripMenuItem"
        Me.ThumbnailsErstellenToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ThumbnailsErstellenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.ThumbnailsErstellenToolStripMenuItem.Text = "Thumbnails erstellen"
        '
        'ToolStripMenuItem32
        '
        Me.ToolStripMenuItem32.Image = Global.Film_Info__Organizer.Toolbar16.darsteller
        Me.ToolStripMenuItem32.Name = "ToolStripMenuItem32"
        Me.ToolStripMenuItem32.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem32.Text = "Darstellerbilder"
        '
        'CoverUndFanartLöschenToolStripMenuItem
        '
        Me.CoverUndFanartLöschenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.CoverUndFanartLöschenToolStripMenuItem.Name = "CoverUndFanartLöschenToolStripMenuItem"
        Me.CoverUndFanartLöschenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.CoverUndFanartLöschenToolStripMenuItem.Text = "Cover und Fanart löschen"
        '
        'ToolStripSeparator33
        '
        Me.ToolStripSeparator33.Name = "ToolStripSeparator33"
        Me.ToolStripSeparator33.Size = New System.Drawing.Size(306, 6)
        '
        'TrailerLadenToolStripMenuItem
        '
        Me.TrailerLadenToolStripMenuItem.Name = "TrailerLadenToolStripMenuItem"
        Me.TrailerLadenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.TrailerLadenToolStripMenuItem.Text = "Trailer laden"
        '
        'ToolStripSeparator51
        '
        Me.ToolStripSeparator51.Name = "ToolStripSeparator51"
        Me.ToolStripSeparator51.Size = New System.Drawing.Size(306, 6)
        '
        'ToolStripMenuItem_Copy
        '
        Me.ToolStripMenuItem_Copy.Image = Global.Film_Info__Organizer.Toolbar16.ordner_copy
        Me.ToolStripMenuItem_Copy.Name = "ToolStripMenuItem_Copy"
        Me.ToolStripMenuItem_Copy.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_Copy.Text = "Kopieren"
        '
        'ToolStripMenuItem_Cut
        '
        Me.ToolStripMenuItem_Cut.Image = Global.Film_Info__Organizer.Toolbar16.ordner_ausscheiden
        Me.ToolStripMenuItem_Cut.Name = "ToolStripMenuItem_Cut"
        Me.ToolStripMenuItem_Cut.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_Cut.Text = "Ausscheiden"
        '
        'ToolStripMenuItem_copyto
        '
        Me.ToolStripMenuItem_copyto.Image = Global.Film_Info__Organizer.Toolbar16.Ordner_kopieren
        Me.ToolStripMenuItem_copyto.Name = "ToolStripMenuItem_copyto"
        Me.ToolStripMenuItem_copyto.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_copyto.Text = "In Ordner kopieren..."
        '
        'ToolStripMenuItem_moveto
        '
        Me.ToolStripMenuItem_moveto.Image = Global.Film_Info__Organizer.Toolbar16.Ordner_verschieben
        Me.ToolStripMenuItem_moveto.Name = "ToolStripMenuItem_moveto"
        Me.ToolStripMenuItem_moveto.Size = New System.Drawing.Size(309, 22)
        Me.ToolStripMenuItem_moveto.Text = "In Ordner verschieben..."
        '
        'FilmordnerLöschenToolStripMenuItem
        '
        Me.FilmordnerLöschenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.FilmordnerLöschenToolStripMenuItem.Name = "FilmordnerLöschenToolStripMenuItem"
        Me.FilmordnerLöschenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.FilmordnerLöschenToolStripMenuItem.Text = "Ordner Löschen"
        '
        'ToolStripSeparator54
        '
        Me.ToolStripSeparator54.Name = "ToolStripSeparator54"
        Me.ToolStripSeparator54.Size = New System.Drawing.Size(306, 6)
        '
        'OrdnerUmbenennenToolStripMenuItem
        '
        Me.OrdnerUmbenennenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Normal_hinzufuegen
        Me.OrdnerUmbenennenToolStripMenuItem.Name = "OrdnerUmbenennenToolStripMenuItem"
        Me.OrdnerUmbenennenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.OrdnerUmbenennenToolStripMenuItem.Text = "Ordner/Dateinamen umbenennen"
        '
        'FeldBearbeitenToolStripMenuItem
        '
        Me.FeldBearbeitenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenreHinzufügenToolStripMenuItem, Me.MediaInfoToolStripMenuItem})
        Me.FeldBearbeitenToolStripMenuItem.Name = "FeldBearbeitenToolStripMenuItem"
        Me.FeldBearbeitenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.FeldBearbeitenToolStripMenuItem.Text = "Feld bearbeiten"
        '
        'GenreHinzufügenToolStripMenuItem
        '
        Me.GenreHinzufügenToolStripMenuItem.Name = "GenreHinzufügenToolStripMenuItem"
        Me.GenreHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.GenreHinzufügenToolStripMenuItem.Text = "Genre"
        '
        'MediaInfoToolStripMenuItem
        '
        Me.MediaInfoToolStripMenuItem.Name = "MediaInfoToolStripMenuItem"
        Me.MediaInfoToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MediaInfoToolStripMenuItem.Text = "MediaInfo"
        '
        'SammlungToolStripMenuItem
        '
        Me.SammlungToolStripMenuItem.DropDown = Me.ContextMenu_Sammlung
        Me.SammlungToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Papergrp
        Me.SammlungToolStripMenuItem.Name = "SammlungToolStripMenuItem"
        Me.SammlungToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.SammlungToolStripMenuItem.Text = "Sammlung"
        '
        'ContextMenu_Sammlung
        '
        Me.ContextMenu_Sammlung.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel_SammlungenOPT, Me.ToolStripTextBox2, Me.HinzufügenToolStripMenuItem})
        Me.ContextMenu_Sammlung.Name = "ContextMenu_Export"
        Me.ContextMenu_Sammlung.OwnerItem = Me.SammlungToolStripMenuItem
        Me.ContextMenu_Sammlung.Size = New System.Drawing.Size(211, 69)
        '
        'ToolStripLabel_SammlungenOPT
        '
        Me.ToolStripLabel_SammlungenOPT.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ToolStripLabel_SammlungenOPT.Name = "ToolStripLabel_SammlungenOPT"
        Me.ToolStripLabel_SammlungenOPT.Size = New System.Drawing.Size(39, 15)
        Me.ToolStripLabel_SammlungenOPT.Text = "Name"
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(150, 23)
        '
        'HinzufügenToolStripMenuItem
        '
        Me.HinzufügenToolStripMenuItem.Name = "HinzufügenToolStripMenuItem"
        Me.HinzufügenToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
        Me.HinzufügenToolStripMenuItem.Text = "Hinzufügen"
        '
        'exp_menu_Sammlung
        '
        Me.exp_menu_Sammlung.DropDown = Me.ContextMenu_Sammlung
        Me.exp_menu_Sammlung.Image = Global.Film_Info__Organizer.Toolbar16.Papergrp
        Me.exp_menu_Sammlung.Name = "exp_menu_Sammlung"
        Me.exp_menu_Sammlung.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_Sammlung.Text = "Sammlung"
        '
        'MarkierungToolStripMenuItem1
        '
        Me.MarkierungToolStripMenuItem1.DropDown = Me.ContextMenu_Flags
        Me.MarkierungToolStripMenuItem1.Name = "MarkierungToolStripMenuItem1"
        Me.MarkierungToolStripMenuItem1.Size = New System.Drawing.Size(309, 22)
        Me.MarkierungToolStripMenuItem1.Text = "Markierung"
        '
        'ContextMenu_Flags
        '
        Me.ContextMenu_Flags.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KeineMarkierungToolStripMenuItem, Me.FragezeichenToolStripMenuItem, Me.NeuToolStripMenuItem, Me.MarkiertToolStripMenuItem, Me.ToolStripSeparator60, Me.CoverToolStripMenuItem, Me.FanartToolStripMenuItem, Me.InfoToolStripMenuItem1, Me.DownloadToolStripMenuItem, Me.WichtigToolStripMenuItem})
        Me.ContextMenu_Flags.Name = "ContextMenu_Flags"
        Me.ContextMenu_Flags.OwnerItem = Me.MarkierungToolStripMenuItem1
        Me.ContextMenu_Flags.Size = New System.Drawing.Size(168, 208)
        '
        'KeineMarkierungToolStripMenuItem
        '
        Me.KeineMarkierungToolStripMenuItem.Name = "KeineMarkierungToolStripMenuItem"
        Me.KeineMarkierungToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.KeineMarkierungToolStripMenuItem.Text = "Keine Markierung"
        '
        'FragezeichenToolStripMenuItem
        '
        Me.FragezeichenToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.flag_new_qm
        Me.FragezeichenToolStripMenuItem.Name = "FragezeichenToolStripMenuItem"
        Me.FragezeichenToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FragezeichenToolStripMenuItem.Text = "Fragezeichen"
        '
        'NeuToolStripMenuItem
        '
        Me.NeuToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.flag_new
        Me.NeuToolStripMenuItem.Name = "NeuToolStripMenuItem"
        Me.NeuToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.NeuToolStripMenuItem.Text = "Neu"
        '
        'MarkiertToolStripMenuItem
        '
        Me.MarkiertToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Favoriten
        Me.MarkiertToolStripMenuItem.Name = "MarkiertToolStripMenuItem"
        Me.MarkiertToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.MarkiertToolStripMenuItem.Text = "Markiert"
        '
        'ToolStripSeparator60
        '
        Me.ToolStripSeparator60.Name = "ToolStripSeparator60"
        Me.ToolStripSeparator60.Size = New System.Drawing.Size(164, 6)
        '
        'CoverToolStripMenuItem
        '
        Me.CoverToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_cover_test
        Me.CoverToolStripMenuItem.Name = "CoverToolStripMenuItem"
        Me.CoverToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.CoverToolStripMenuItem.Text = "Cover"
        '
        'FanartToolStripMenuItem
        '
        Me.FanartToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_fanart
        Me.FanartToolStripMenuItem.Name = "FanartToolStripMenuItem"
        Me.FanartToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FanartToolStripMenuItem.Text = "Fanart"
        '
        'InfoToolStripMenuItem1
        '
        Me.InfoToolStripMenuItem1.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_info
        Me.InfoToolStripMenuItem1.Name = "InfoToolStripMenuItem1"
        Me.InfoToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.InfoToolStripMenuItem1.Text = "Info"
        '
        'DownloadToolStripMenuItem
        '
        Me.DownloadToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.Down
        Me.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem"
        Me.DownloadToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DownloadToolStripMenuItem.Text = "Download"
        '
        'WichtigToolStripMenuItem
        '
        Me.WichtigToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.flag_wichtig
        Me.WichtigToolStripMenuItem.Name = "WichtigToolStripMenuItem"
        Me.WichtigToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.WichtigToolStripMenuItem.Text = "Wichtig"
        '
        'MarkierungToolStripMenuItem
        '
        Me.MarkierungToolStripMenuItem.DropDown = Me.ContextMenu_Flags
        Me.MarkierungToolStripMenuItem.Name = "MarkierungToolStripMenuItem"
        Me.MarkierungToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.MarkierungToolStripMenuItem.Text = "Markierung"
        '
        'ToolStripSeparator34
        '
        Me.ToolStripSeparator34.Name = "ToolStripSeparator34"
        Me.ToolStripSeparator34.Size = New System.Drawing.Size(306, 6)
        '
        'SicherungToolStripMenuItem
        '
        Me.SicherungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SicherungErstellenToolStripMenuItem1, Me.SichrungErstellenToolStripMenuItem, Me.ToolStripSeparator35, Me.WiederherstellenToolStripMenuItem1, Me.ToolStripSeparator50, Me.LöschenToolStripMenuItem2})
        Me.SicherungToolStripMenuItem.Image = CType(resources.GetObject("SicherungToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SicherungToolStripMenuItem.Name = "SicherungToolStripMenuItem"
        Me.SicherungToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.SicherungToolStripMenuItem.Text = "Sicherung"
        '
        'SicherungErstellenToolStripMenuItem1
        '
        Me.SicherungErstellenToolStripMenuItem1.Name = "SicherungErstellenToolStripMenuItem1"
        Me.SicherungErstellenToolStripMenuItem1.Size = New System.Drawing.Size(276, 22)
        Me.SicherungErstellenToolStripMenuItem1.Text = "Sicherung erstellen"
        '
        'SichrungErstellenToolStripMenuItem
        '
        Me.SichrungErstellenToolStripMenuItem.Name = "SichrungErstellenToolStripMenuItem"
        Me.SichrungErstellenToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.SichrungErstellenToolStripMenuItem.Text = "Sicherung erstellen und überschreiben"
        '
        'ToolStripSeparator35
        '
        Me.ToolStripSeparator35.Name = "ToolStripSeparator35"
        Me.ToolStripSeparator35.Size = New System.Drawing.Size(273, 6)
        '
        'WiederherstellenToolStripMenuItem1
        '
        Me.WiederherstellenToolStripMenuItem1.Name = "WiederherstellenToolStripMenuItem1"
        Me.WiederherstellenToolStripMenuItem1.Size = New System.Drawing.Size(276, 22)
        Me.WiederherstellenToolStripMenuItem1.Text = "Wiederherstellen"
        '
        'ToolStripSeparator50
        '
        Me.ToolStripSeparator50.Name = "ToolStripSeparator50"
        Me.ToolStripSeparator50.Size = New System.Drawing.Size(273, 6)
        '
        'LöschenToolStripMenuItem2
        '
        Me.LöschenToolStripMenuItem2.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.LöschenToolStripMenuItem2.Name = "LöschenToolStripMenuItem2"
        Me.LöschenToolStripMenuItem2.Size = New System.Drawing.Size(276, 22)
        Me.LöschenToolStripMenuItem2.Text = "Löschen"
        '
        'SortierenToolStripMenuItem
        '
        Me.SortierenToolStripMenuItem.Name = "SortierenToolStripMenuItem"
        Me.SortierenToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.SortierenToolStripMenuItem.Text = "Sortieren"
        Me.SortierenToolStripMenuItem.Visible = False
        '
        'ToolStripMainItem_Info
        '
        Me.ToolStripMainItem_Info.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem31, Me.ToolStripMenuItem30, Me.ToolStripMenuItem29, Me.ToolStripSeparator32, Me.ToolStripMenuItem_MediaInfo, Me.ToolStripMenuItem_Abspielen, Me.ToolStripMenuItem_Ordnerdurchsuchen, Me.ToolStripMenuItem39, Me.VideosVergleichenToolStripMenuItem})
        Me.ToolStripMainItem_Info.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripMainItem_Info.Name = "ToolStripMainItem_Info"
        Me.ToolStripMainItem_Info.Size = New System.Drawing.Size(40, 19)
        Me.ToolStripMainItem_Info.Text = "&Info"
        '
        'ToolStripMenuItem31
        '
        Me.ToolStripMenuItem31.Image = CType(resources.GetObject("ToolStripMenuItem31.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem31.Name = "ToolStripMenuItem31"
        Me.ToolStripMenuItem31.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem31.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem31.Text = "Schnelle Suche"
        '
        'ToolStripMenuItem30
        '
        Me.ToolStripMenuItem30.Image = CType(resources.GetObject("ToolStripMenuItem30.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem30.Name = "ToolStripMenuItem30"
        Me.ToolStripMenuItem30.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem30.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem30.Text = "Normale Suche"
        '
        'ToolStripMenuItem29
        '
        Me.ToolStripMenuItem29.Image = CType(resources.GetObject("ToolStripMenuItem29.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem29.Name = "ToolStripMenuItem29"
        Me.ToolStripMenuItem29.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
            Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem29.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem29.Text = "Ausführliche Suche"
        '
        'ToolStripSeparator32
        '
        Me.ToolStripSeparator32.Name = "ToolStripSeparator32"
        Me.ToolStripSeparator32.Size = New System.Drawing.Size(277, 6)
        '
        'ToolStripMenuItem_MediaInfo
        '
        Me.ToolStripMenuItem_MediaInfo.Image = CType(resources.GetObject("ToolStripMenuItem_MediaInfo.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_MediaInfo.Name = "ToolStripMenuItem_MediaInfo"
        Me.ToolStripMenuItem_MediaInfo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem_MediaInfo.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem_MediaInfo.Text = "Media Info"
        Me.ToolStripMenuItem_MediaInfo.ToolTipText = "Media Info anzeigen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Zeigt alle Informationen zur Film-Datei."
        '
        'ToolStripMenuItem_Abspielen
        '
        Me.ToolStripMenuItem_Abspielen.Image = CType(resources.GetObject("ToolStripMenuItem_Abspielen.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Abspielen.Name = "ToolStripMenuItem_Abspielen"
        Me.ToolStripMenuItem_Abspielen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem_Abspielen.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem_Abspielen.Text = "Film abspielen"
        '
        'ToolStripMenuItem_Ordnerdurchsuchen
        '
        Me.ToolStripMenuItem_Ordnerdurchsuchen.Image = CType(resources.GetObject("ToolStripMenuItem_Ordnerdurchsuchen.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem_Ordnerdurchsuchen.Name = "ToolStripMenuItem_Ordnerdurchsuchen"
        Me.ToolStripMenuItem_Ordnerdurchsuchen.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem_Ordnerdurchsuchen.Text = "Ordner durchsuchen"
        '
        'ToolStripMenuItem39
        '
        Me.ToolStripMenuItem39.Name = "ToolStripMenuItem39"
        Me.ToolStripMenuItem39.Size = New System.Drawing.Size(280, 22)
        Me.ToolStripMenuItem39.Text = "Ordnerpfad öffnen"
        '
        'VideosVergleichenToolStripMenuItem
        '
        Me.VideosVergleichenToolStripMenuItem.Name = "VideosVergleichenToolStripMenuItem"
        Me.VideosVergleichenToolStripMenuItem.Size = New System.Drawing.Size(280, 22)
        Me.VideosVergleichenToolStripMenuItem.Text = "Videos vergleichen"
        '
        'AnsichtToolStripMenuItem
        '
        Me.AnsichtToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6, Me.WerkzeugleisteToolStripMenuItem, Me.ToolStripMenuItem7, Me.ToolStripSeparator58, Me.Radio_NorToolbar, Me.Radio_DynToolbar, Me.ToolStripSeparator20, Me.ToolStripMenuItem2, Me.ToolStripMenuItem5})
        Me.AnsichtToolStripMenuItem.Name = "AnsichtToolStripMenuItem"
        Me.AnsichtToolStripMenuItem.Size = New System.Drawing.Size(59, 19)
        Me.AnsichtToolStripMenuItem.Text = "Ansicht"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.ShortcutKeys = System.Windows.Forms.Keys.F12
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem6.Text = "Menüleiste"
        '
        'WerkzeugleisteToolStripMenuItem
        '
        Me.WerkzeugleisteToolStripMenuItem.Name = "WerkzeugleisteToolStripMenuItem"
        Me.WerkzeugleisteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.WerkzeugleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.WerkzeugleisteToolStripMenuItem.Text = "Werkzeugleiste"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.ShortcutKeys = System.Windows.Forms.Keys.F11
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem7.Text = "Statusleiste"
        '
        'ToolStripSeparator58
        '
        Me.ToolStripSeparator58.Name = "ToolStripSeparator58"
        Me.ToolStripSeparator58.Size = New System.Drawing.Size(218, 6)
        '
        'Radio_NorToolbar
        '
        Me.Radio_NorToolbar.Name = "Radio_NorToolbar"
        Me.Radio_NorToolbar.Size = New System.Drawing.Size(221, 22)
        Me.Radio_NorToolbar.Text = "Normale Werkzeugleiste"
        '
        'Radio_DynToolbar
        '
        Me.Radio_DynToolbar.Name = "Radio_DynToolbar"
        Me.Radio_DynToolbar.Size = New System.Drawing.Size(221, 22)
        Me.Radio_DynToolbar.Text = "Dynamische Werkzeugleiste"
        '
        'ToolStripSeparator20
        '
        Me.ToolStripSeparator20.Name = "ToolStripSeparator20"
        Me.ToolStripSeparator20.Padding = New System.Windows.Forms.Padding(0, 1, 0, 1)
        Me.ToolStripSeparator20.Size = New System.Drawing.Size(218, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F9
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem2.Text = "Info!-Panel"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem5.Text = "Navigationsleiste"
        '
        'ToolStripMainItem_Extras
        '
        Me.ToolStripMainItem_Extras.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilmeZusammenfügenToolStripMenuItem, Me.ToolStripSeparator8, Me.SpaltenToolStripMenuItem, Me.OptionenToolStripMenuItem})
        Me.ToolStripMainItem_Extras.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripMainItem_Extras.Name = "ToolStripMainItem_Extras"
        Me.ToolStripMainItem_Extras.Size = New System.Drawing.Size(49, 19)
        Me.ToolStripMainItem_Extras.Text = "E&xtras"
        '
        'FilmeZusammenfügenToolStripMenuItem
        '
        Me.FilmeZusammenfügenToolStripMenuItem.Name = "FilmeZusammenfügenToolStripMenuItem"
        Me.FilmeZusammenfügenToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.FilmeZusammenfügenToolStripMenuItem.Text = "Filme zusammenfügen"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(192, 6)
        '
        'SpaltenToolStripMenuItem
        '
        Me.SpaltenToolStripMenuItem.Image = CType(resources.GetObject("SpaltenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SpaltenToolStripMenuItem.Name = "SpaltenToolStripMenuItem"
        Me.SpaltenToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.SpaltenToolStripMenuItem.Text = "&Spalten"
        '
        'OptionenToolStripMenuItem
        '
        Me.OptionenToolStripMenuItem.Image = CType(resources.GetObject("OptionenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionenToolStripMenuItem.Name = "OptionenToolStripMenuItem"
        Me.OptionenToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.OptionenToolStripMenuItem.Text = "&Optionen..."
        '
        'ToolStripMainItem_Hilfe
        '
        Me.ToolStripMainItem_Hilfe.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HilfeToolStripMenuItem1, Me.toolStripSeparator5, Me.UpdateToolStripMenuItem, Me.FehlerMeldenToolStripMenuItem, Me.ToolStripSeparator28, Me.InfoToolStripMenuItem})
        Me.ToolStripMainItem_Hilfe.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStripMainItem_Hilfe.Name = "ToolStripMainItem_Hilfe"
        Me.ToolStripMainItem_Hilfe.Size = New System.Drawing.Size(44, 19)
        Me.ToolStripMainItem_Hilfe.Text = "&Hilfe"
        '
        'HilfeToolStripMenuItem1
        '
        Me.HilfeToolStripMenuItem1.Name = "HilfeToolStripMenuItem1"
        Me.HilfeToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HilfeToolStripMenuItem1.Size = New System.Drawing.Size(158, 22)
        Me.HilfeToolStripMenuItem1.Text = "Hilfe..."
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New System.Drawing.Size(155, 6)
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Image = CType(resources.GetObject("UpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.UpdateToolStripMenuItem.Text = "&Update..."
        '
        'FehlerMeldenToolStripMenuItem
        '
        Me.FehlerMeldenToolStripMenuItem.Name = "FehlerMeldenToolStripMenuItem"
        Me.FehlerMeldenToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.FehlerMeldenToolStripMenuItem.Text = "Fehler melden..."
        '
        'ToolStripSeparator28
        '
        Me.ToolStripSeparator28.Name = "ToolStripSeparator28"
        Me.ToolStripSeparator28.Size = New System.Drawing.Size(155, 6)
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.InfoToolStripMenuItem.Text = "Über..."
        '
        'TabImages
        '
        Me.TabImages.ImageStream = CType(resources.GetObject("TabImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TabImages.TransparentColor = System.Drawing.Color.Transparent
        Me.TabImages.Images.SetKeyName(0, "2.png")
        Me.TabImages.Images.SetKeyName(1, "2grey.png")
        Me.TabImages.Images.SetKeyName(2, "3.png")
        Me.TabImages.Images.SetKeyName(3, "3grey.png")
        Me.TabImages.Images.SetKeyName(4, "1.png")
        Me.TabImages.Images.SetKeyName(5, "1grey.png")
        Me.TabImages.Images.SetKeyName(6, "Unbenannt-1.png")
        '
        'ContextMenu_TextBox
        '
        Me.ContextMenu_TextBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RückgäningToolStripMenuItem, Me.ToolStripSeparator10, Me.KopierenToolStripMenuItem, Me.EinfügenToolStripMenuItem, Me.AusschneidenToolStripMenuItem, Me.ToolStripSeparator11, Me.SuchenToolStripMenuItem})
        Me.ContextMenu_TextBox.Name = "ContextMenuStrip1"
        Me.ContextMenu_TextBox.Size = New System.Drawing.Size(149, 126)
        '
        'RückgäningToolStripMenuItem
        '
        Me.RückgäningToolStripMenuItem.Name = "RückgäningToolStripMenuItem"
        Me.RückgäningToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.RückgäningToolStripMenuItem.Text = "Rückgäning"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(145, 6)
        '
        'KopierenToolStripMenuItem
        '
        Me.KopierenToolStripMenuItem.Name = "KopierenToolStripMenuItem"
        Me.KopierenToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.KopierenToolStripMenuItem.Text = "Kopieren"
        '
        'EinfügenToolStripMenuItem
        '
        Me.EinfügenToolStripMenuItem.Name = "EinfügenToolStripMenuItem"
        Me.EinfügenToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.EinfügenToolStripMenuItem.Text = "Einfügen"
        '
        'AusschneidenToolStripMenuItem
        '
        Me.AusschneidenToolStripMenuItem.Name = "AusschneidenToolStripMenuItem"
        Me.AusschneidenToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.AusschneidenToolStripMenuItem.Text = "Ausschneiden"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(145, 6)
        '
        'SuchenToolStripMenuItem
        '
        Me.SuchenToolStripMenuItem.Image = CType(resources.GetObject("SuchenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SuchenToolStripMenuItem.Name = "SuchenToolStripMenuItem"
        Me.SuchenToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SuchenToolStripMenuItem.Text = "Suchen..."
        '
        'ContextMenu_Cover
        '
        Me.ContextMenu_Cover.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinfügenToolStripMenuItem1, Me.BackdropAusZwischenablageToolStripMenuItem, Me.ToolStripSeparator12, Me.GoogleToolStripMenuItem1, Me.MoviemazeToolStripMenuItem, Me.ToolStripSeparator16, Me.LöschenToolStripMenuItem1})
        Me.ContextMenu_Cover.Name = "ContextMenu_Cover"
        Me.ContextMenu_Cover.Size = New System.Drawing.Size(234, 126)
        '
        'EinfügenToolStripMenuItem1
        '
        Me.EinfügenToolStripMenuItem1.Name = "EinfügenToolStripMenuItem1"
        Me.EinfügenToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.EinfügenToolStripMenuItem1.Text = "Cover aus Zwischenablage"
        '
        'BackdropAusZwischenablageToolStripMenuItem
        '
        Me.BackdropAusZwischenablageToolStripMenuItem.Name = "BackdropAusZwischenablageToolStripMenuItem"
        Me.BackdropAusZwischenablageToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.BackdropAusZwischenablageToolStripMenuItem.Text = "Backdrop aus Zwischenablage"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(230, 6)
        '
        'GoogleToolStripMenuItem1
        '
        Me.GoogleToolStripMenuItem1.Image = CType(resources.GetObject("GoogleToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.GoogleToolStripMenuItem1.Name = "GoogleToolStripMenuItem1"
        Me.GoogleToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.GoogleToolStripMenuItem1.Text = "Google"
        '
        'MoviemazeToolStripMenuItem
        '
        Me.MoviemazeToolStripMenuItem.Image = CType(resources.GetObject("MoviemazeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MoviemazeToolStripMenuItem.Name = "MoviemazeToolStripMenuItem"
        Me.MoviemazeToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.MoviemazeToolStripMenuItem.Text = "Moviemaze"
        '
        'ToolStripSeparator16
        '
        Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
        Me.ToolStripSeparator16.Size = New System.Drawing.Size(230, 6)
        '
        'LöschenToolStripMenuItem1
        '
        Me.LöschenToolStripMenuItem1.Image = CType(resources.GetObject("LöschenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.LöschenToolStripMenuItem1.Name = "LöschenToolStripMenuItem1"
        Me.LöschenToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.LöschenToolStripMenuItem1.Text = "Löschen"
        '
        'ContextMenu_Overwrite
        '
        Me.ContextMenu_Overwrite.AutoClose = False
        Me.ContextMenu_Overwrite.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.Radio_AutomatischToolStripMenuItem, Me.Radio_ErgänzenToolStripMenuItem, Me.Radio_ErsetzenToolStripMenuItem, Me.Radio_BenutzerdefiniertToolStripMenuItem, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.OverwriteMenuItem_Titel, Me.OverwriteMenuItem_Originaltitel, Me.OverwriteMenuItem_Sort, Me.OverwriteMenuItem_Produktionsjahr, Me.OverwriteMenuItem_IMDB_ID, Me.OverwriteMenuItem_Bewertung, Me.OverwriteMenuItem_FSK, Me.OverwriteMenuItem_Studios, Me.OverwriteMenuItem_Genre, Me.OverwriteMenuItem_Regisseur, Me.OverwriteMenuItem_Produktionsland, Me.OverwriteMenuItem_Autoren, Me.OverwriteMenuItem_Darsteller, Me.OverwriteMenuItem_Inhalt})
        Me.ContextMenu_Overwrite.Name = "ContextMenu_Overwrite"
        Me.ContextMenu_Overwrite.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenu_Overwrite.Size = New System.Drawing.Size(165, 442)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(94, 15)
        Me.ToolStripLabel2.Text = "Schreibmethode"
        '
        'Radio_AutomatischToolStripMenuItem
        '
        Me.Radio_AutomatischToolStripMenuItem.Name = "Radio_AutomatischToolStripMenuItem"
        Me.Radio_AutomatischToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.Radio_AutomatischToolStripMenuItem.Text = "Automatisch"
        '
        'Radio_ErgänzenToolStripMenuItem
        '
        Me.Radio_ErgänzenToolStripMenuItem.Name = "Radio_ErgänzenToolStripMenuItem"
        Me.Radio_ErgänzenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.Radio_ErgänzenToolStripMenuItem.Text = "Ergänzen"
        '
        'Radio_ErsetzenToolStripMenuItem
        '
        Me.Radio_ErsetzenToolStripMenuItem.Name = "Radio_ErsetzenToolStripMenuItem"
        Me.Radio_ErsetzenToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.Radio_ErsetzenToolStripMenuItem.Text = "Ersetzen"
        '
        'Radio_BenutzerdefiniertToolStripMenuItem
        '
        Me.Radio_BenutzerdefiniertToolStripMenuItem.Name = "Radio_BenutzerdefiniertToolStripMenuItem"
        Me.Radio_BenutzerdefiniertToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.Radio_BenutzerdefiniertToolStripMenuItem.Text = "Benutzerdefiniert"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(161, 6)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(86, 15)
        Me.ToolStripLabel3.Text = "Überschreiben:"
        '
        'OverwriteMenuItem_Titel
        '
        Me.OverwriteMenuItem_Titel.Checked = True
        Me.OverwriteMenuItem_Titel.CheckOnClick = True
        Me.OverwriteMenuItem_Titel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.OverwriteMenuItem_Titel.Name = "OverwriteMenuItem_Titel"
        Me.OverwriteMenuItem_Titel.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Titel.Text = "Titel"
        '
        'OverwriteMenuItem_Originaltitel
        '
        Me.OverwriteMenuItem_Originaltitel.CheckOnClick = True
        Me.OverwriteMenuItem_Originaltitel.Name = "OverwriteMenuItem_Originaltitel"
        Me.OverwriteMenuItem_Originaltitel.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Originaltitel.Text = "Originaltitel"
        '
        'OverwriteMenuItem_Sort
        '
        Me.OverwriteMenuItem_Sort.CheckOnClick = True
        Me.OverwriteMenuItem_Sort.Name = "OverwriteMenuItem_Sort"
        Me.OverwriteMenuItem_Sort.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Sort.Text = "Sortierung"
        '
        'OverwriteMenuItem_Produktionsjahr
        '
        Me.OverwriteMenuItem_Produktionsjahr.CheckOnClick = True
        Me.OverwriteMenuItem_Produktionsjahr.Name = "OverwriteMenuItem_Produktionsjahr"
        Me.OverwriteMenuItem_Produktionsjahr.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Produktionsjahr.Text = "Produktionsjahr"
        '
        'OverwriteMenuItem_IMDB_ID
        '
        Me.OverwriteMenuItem_IMDB_ID.CheckOnClick = True
        Me.OverwriteMenuItem_IMDB_ID.Name = "OverwriteMenuItem_IMDB_ID"
        Me.OverwriteMenuItem_IMDB_ID.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_IMDB_ID.Text = "IMDB_ID"
        '
        'OverwriteMenuItem_Bewertung
        '
        Me.OverwriteMenuItem_Bewertung.CheckOnClick = True
        Me.OverwriteMenuItem_Bewertung.Name = "OverwriteMenuItem_Bewertung"
        Me.OverwriteMenuItem_Bewertung.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Bewertung.Text = "Bewertung"
        '
        'OverwriteMenuItem_FSK
        '
        Me.OverwriteMenuItem_FSK.CheckOnClick = True
        Me.OverwriteMenuItem_FSK.Name = "OverwriteMenuItem_FSK"
        Me.OverwriteMenuItem_FSK.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_FSK.Text = "FSK"
        '
        'OverwriteMenuItem_Studios
        '
        Me.OverwriteMenuItem_Studios.CheckOnClick = True
        Me.OverwriteMenuItem_Studios.Name = "OverwriteMenuItem_Studios"
        Me.OverwriteMenuItem_Studios.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Studios.Text = "Studios"
        '
        'OverwriteMenuItem_Genre
        '
        Me.OverwriteMenuItem_Genre.CheckOnClick = True
        Me.OverwriteMenuItem_Genre.Name = "OverwriteMenuItem_Genre"
        Me.OverwriteMenuItem_Genre.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Genre.Text = "Genre"
        '
        'OverwriteMenuItem_Regisseur
        '
        Me.OverwriteMenuItem_Regisseur.CheckOnClick = True
        Me.OverwriteMenuItem_Regisseur.Name = "OverwriteMenuItem_Regisseur"
        Me.OverwriteMenuItem_Regisseur.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Regisseur.Text = "Regisseur"
        '
        'OverwriteMenuItem_Produktionsland
        '
        Me.OverwriteMenuItem_Produktionsland.CheckOnClick = True
        Me.OverwriteMenuItem_Produktionsland.Name = "OverwriteMenuItem_Produktionsland"
        Me.OverwriteMenuItem_Produktionsland.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Produktionsland.Text = "Produktionsland"
        '
        'OverwriteMenuItem_Autoren
        '
        Me.OverwriteMenuItem_Autoren.CheckOnClick = True
        Me.OverwriteMenuItem_Autoren.Name = "OverwriteMenuItem_Autoren"
        Me.OverwriteMenuItem_Autoren.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Autoren.Text = "Autoren"
        '
        'OverwriteMenuItem_Darsteller
        '
        Me.OverwriteMenuItem_Darsteller.CheckOnClick = True
        Me.OverwriteMenuItem_Darsteller.Name = "OverwriteMenuItem_Darsteller"
        Me.OverwriteMenuItem_Darsteller.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Darsteller.Text = "Darsteller"
        '
        'OverwriteMenuItem_Inhalt
        '
        Me.OverwriteMenuItem_Inhalt.CheckOnClick = True
        Me.OverwriteMenuItem_Inhalt.Name = "OverwriteMenuItem_Inhalt"
        Me.OverwriteMenuItem_Inhalt.Size = New System.Drawing.Size(164, 22)
        Me.OverwriteMenuItem_Inhalt.Text = "Inhalt"
        '
        'Nav_Treeview
        '
        Me.Nav_Treeview.BackColor = System.Drawing.Color.Transparent
        Me.Nav_Treeview.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_Treeview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton_Add_Fav, Me.ToolStripButton_del_fav})
        Me.Nav_Treeview.Location = New System.Drawing.Point(0, 0)
        Me.Nav_Treeview.Name = "Nav_Treeview"
        Me.Nav_Treeview.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_Treeview.Size = New System.Drawing.Size(164, 25)
        Me.Nav_Treeview.TabIndex = 7
        Me.Nav_Treeview.Text = "ToolStrip1"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.Film_Info__Organizer.Toolbar16.folder_close
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Löschen"
        '
        'ToolStripButton_Add_Fav
        '
        Me.ToolStripButton_Add_Fav.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Add_Fav.Image = CType(resources.GetObject("ToolStripButton_Add_Fav.Image"), System.Drawing.Image)
        Me.ToolStripButton_Add_Fav.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Add_Fav.Name = "ToolStripButton_Add_Fav"
        Me.ToolStripButton_Add_Fav.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Add_Fav.Text = "Zu den Favoriten hinzufügen"
        '
        'ToolStripButton_del_fav
        '
        Me.ToolStripButton_del_fav.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_del_fav.Image = CType(resources.GetObject("ToolStripButton_del_fav.Image"), System.Drawing.Image)
        Me.ToolStripButton_del_fav.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_del_fav.Name = "ToolStripButton_del_fav"
        Me.ToolStripButton_del_fav.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_del_fav.Text = "Aus den Favoriten entfernen"
        '
        'SplitContainer_treepanel
        '
        Me.SplitContainer_treepanel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.SplitContainer_treepanel.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.SplitContainer_treepanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_treepanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer_treepanel.Location = New System.Drawing.Point(0, 89)
        Me.SplitContainer_treepanel.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer_treepanel.Name = "SplitContainer_treepanel"
        '
        'SplitContainer_treepanel.Panel1
        '
        Me.SplitContainer_treepanel.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer_treepanel.Panel1.Controls.Add(Me.Panel_treepadding)
        Me.SplitContainer_treepanel.Panel1.Controls.Add(Me.Download_Panel)
        Me.SplitContainer_treepanel.Panel1.Controls.Add(Me.Nav_Treeview)
        Me.SplitContainer_treepanel.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'SplitContainer_treepanel.Panel2
        '
        Me.SplitContainer_treepanel.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer_treepanel.Panel2.Controls.Add(Me.SplitContainer_Infopanel)
        Me.SplitContainer_treepanel.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer_treepanel.Size = New System.Drawing.Size(1096, 517)
        Me.SplitContainer_treepanel.SplitterDistance = 164
        Me.SplitContainer_treepanel.SplitterWidth = 2
        Me.SplitContainer_treepanel.TabIndex = 11
        '
        'Panel_treepadding
        '
        Me.Panel_treepadding.AutoScroll = True
        Me.Panel_treepadding.Controls.Add(Me.TreeViewVista1)
        Me.Panel_treepadding.Controls.Add(Me.TreeView_Opt_Columns)
        Me.Panel_treepadding.Controls.Add(Me.Navigationsleiste)
        Me.Panel_treepadding.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_treepadding.Location = New System.Drawing.Point(0, 25)
        Me.Panel_treepadding.Name = "Panel_treepadding"
        Me.Panel_treepadding.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel_treepadding.Size = New System.Drawing.Size(164, 321)
        Me.Panel_treepadding.TabIndex = 16
        '
        'TreeViewVista1
        '
        Me.TreeViewVista1._Autosize = False
        Me.TreeViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewVista1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewVista1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.TreeViewVista1.FullRowSelect = True
        Me.TreeViewVista1.HideSelection = False
        Me.TreeViewVista1.HotTracking = True
        Me.TreeViewVista1.ImageIndex = 0
        Me.TreeViewVista1.ImageList = Me.TreeviewImagelist
        Me.TreeViewVista1.ItemHeight = 20
        Me.TreeViewVista1.Location = New System.Drawing.Point(2, 2)
        Me.TreeViewVista1.Name = "TreeViewVista1"
        TreeNode6.ImageIndex = 1
        TreeNode6.Name = "Knoten1"
        TreeNode6.SelectedImageIndex = 1
        TreeNode6.Text = "Ordner"
        TreeNode7.ImageIndex = 3
        TreeNode7.Name = "Knoten0"
        TreeNode7.SelectedImageIndex = 3
        TreeNode7.Text = "Favoriten"
        Me.TreeViewVista1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7})
        Me.TreeViewVista1.SelectedImageIndex = 0
        Me.TreeViewVista1.ShowLines = False
        Me.TreeViewVista1.Size = New System.Drawing.Size(160, 317)
        Me.TreeViewVista1.TabIndex = 17
        '
        'TreeView_Opt_Columns
        '
        Me.TreeView_Opt_Columns._Autosize = False
        Me.TreeView_Opt_Columns.AllowDrop = True
        Me.TreeView_Opt_Columns.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView_Opt_Columns.CheckBoxes = True
        Me.TreeView_Opt_Columns.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView_Opt_Columns.FullRowSelect = True
        Me.TreeView_Opt_Columns.HideSelection = False
        Me.TreeView_Opt_Columns.HotTracking = True
        Me.TreeView_Opt_Columns.ItemHeight = 20
        Me.TreeView_Opt_Columns.Location = New System.Drawing.Point(2, 2)
        Me.TreeView_Opt_Columns.Name = "TreeView_Opt_Columns"
        Me.TreeView_Opt_Columns.ShowLines = False
        Me.TreeView_Opt_Columns.Size = New System.Drawing.Size(160, 317)
        Me.TreeView_Opt_Columns.TabIndex = 18
        Me.TreeView_Opt_Columns.Visible = False
        '
        'Navigationsleiste
        '
        Me.Navigationsleiste._Autosize = False
        Me.Navigationsleiste.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Navigationsleiste.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll
        Me.Navigationsleiste.FullRowSelect = True
        Me.Navigationsleiste.HideSelection = False
        Me.Navigationsleiste.HotTracking = True
        Me.Navigationsleiste.ImageIndex = 0
        Me.Navigationsleiste.ImageList = Me.TreeviewImagelist
        Me.Navigationsleiste.ItemHeight = 20
        Me.Navigationsleiste.Location = New System.Drawing.Point(2, 52)
        Me.Navigationsleiste.Name = "Navigationsleiste"
        TreeNode1.Name = "Knoten0"
        TreeNode1.Text = "Filme"
        TreeNode2.ImageIndex = -2
        TreeNode2.Name = "Knoten1"
        TreeNode2.SelectedImageIndex = -2
        TreeNode2.Text = ""
        TreeNode8.ImageIndex = 2
        TreeNode8.Name = "Se"
        TreeNode8.SelectedImageIndex = 2
        TreeNode8.Text = "Serien"
        Me.Navigationsleiste.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode8})
        Me.Navigationsleiste.SelectedImageIndex = 0
        Me.Navigationsleiste.ShowLines = False
        Me.Navigationsleiste.Size = New System.Drawing.Size(157, 256)
        Me.Navigationsleiste.TabIndex = 19
        Me.Navigationsleiste.Visible = False
        '
        'Download_Panel
        '
        Me.Download_Panel.AutoSize = True
        Me.Download_Panel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Download_Panel.Controls.Add(Me.TableLayoutPanel5)
        Me.Download_Panel.Controls.Add(Me.Nav_Download)
        Me.Download_Panel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Download_Panel.Location = New System.Drawing.Point(0, 346)
        Me.Download_Panel.Name = "Download_Panel"
        Me.Download_Panel.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.Download_Panel.Size = New System.Drawing.Size(164, 171)
        Me.Download_Panel.TabIndex = 12
        Me.Download_Panel.Visible = False
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.BackColor = System.Drawing.SystemColors.Window
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.ProgressBar1, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label24, 0, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.Download_info_Prozent, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Download_Info_Restzeit, 0, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.Label28, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Download_info_Absolut, 0, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.Label27, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Download_info_Geladen, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Download_info_Speed, 0, 3)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 28)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 9
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(164, 143)
        Me.TableLayoutPanel5.TabIndex = 16
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBar1.Location = New System.Drawing.Point(8, 3)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(148, 9)
        Me.ProgressBar1.TabIndex = 11
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label24.Location = New System.Drawing.Point(3, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label24.Size = New System.Drawing.Size(70, 15)
        Me.Label24.TabIndex = 8
        Me.Label24.Text = "Verbleibend"
        '
        'Download_info_Prozent
        '
        Me.Download_info_Prozent.AutoSize = True
        Me.Download_info_Prozent.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Download_info_Prozent.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Download_info_Prozent.Location = New System.Drawing.Point(3, 15)
        Me.Download_info_Prozent.Name = "Download_info_Prozent"
        Me.Download_info_Prozent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Download_info_Prozent.Size = New System.Drawing.Size(20, 17)
        Me.Download_info_Prozent.TabIndex = 2
        Me.Download_info_Prozent.Tag = "0"
        Me.Download_info_Prozent.Text = "..."
        '
        'Download_Info_Restzeit
        '
        Me.Download_Info_Restzeit.AutoSize = True
        Me.Download_Info_Restzeit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Download_Info_Restzeit.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Download_Info_Restzeit.Location = New System.Drawing.Point(3, 111)
        Me.Download_Info_Restzeit.Name = "Download_Info_Restzeit"
        Me.Download_Info_Restzeit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Download_Info_Restzeit.Size = New System.Drawing.Size(20, 17)
        Me.Download_Info_Restzeit.TabIndex = 7
        Me.Download_Info_Restzeit.Text = "..."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label28.Location = New System.Drawing.Point(3, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label28.Size = New System.Drawing.Size(61, 15)
        Me.Label28.TabIndex = 3
        Me.Label28.Text = "Fortschritt"
        '
        'Download_info_Absolut
        '
        Me.Download_info_Absolut.AutoSize = True
        Me.Download_info_Absolut.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Download_info_Absolut.Location = New System.Drawing.Point(3, 96)
        Me.Download_info_Absolut.Name = "Download_info_Absolut"
        Me.Download_info_Absolut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Download_info_Absolut.Size = New System.Drawing.Size(40, 15)
        Me.Download_info_Absolut.TabIndex = 5
        Me.Download_info_Absolut.Text = "Von ..."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.Label27.Location = New System.Drawing.Point(3, 64)
        Me.Label27.Name = "Label27"
        Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label27.Size = New System.Drawing.Size(39, 15)
        Me.Label27.TabIndex = 6
        Me.Label27.Text = "Speed"
        '
        'Download_info_Geladen
        '
        Me.Download_info_Geladen.AutoSize = True
        Me.Download_info_Geladen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Download_info_Geladen.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Download_info_Geladen.Location = New System.Drawing.Point(3, 79)
        Me.Download_info_Geladen.Name = "Download_info_Geladen"
        Me.Download_info_Geladen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Download_info_Geladen.Size = New System.Drawing.Size(20, 17)
        Me.Download_info_Geladen.TabIndex = 4
        Me.Download_info_Geladen.Text = "..."
        '
        'Download_info_Speed
        '
        Me.Download_info_Speed.AutoSize = True
        Me.Download_info_Speed.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Download_info_Speed.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Download_info_Speed.Location = New System.Drawing.Point(3, 47)
        Me.Download_info_Speed.Name = "Download_info_Speed"
        Me.Download_info_Speed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Download_info_Speed.Size = New System.Drawing.Size(20, 17)
        Me.Download_info_Speed.TabIndex = 0
        Me.Download_info_Speed.Text = "..."
        '
        'Nav_Download
        '
        Me.Nav_Download.BackColor = System.Drawing.SystemColors.Window
        Me.Nav_Download.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_Download.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.Download_anzeige_change, Me.ToolStripButton19})
        Me.Nav_Download.Location = New System.Drawing.Point(0, 3)
        Me.Nav_Download.Name = "Nav_Download"
        Me.Nav_Download.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_Download.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Nav_Download.Size = New System.Drawing.Size(164, 25)
        Me.Nav_Download.TabIndex = 10
        Me.Nav_Download.Text = "ToolStrip3"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(0, 22)
        '
        'Download_anzeige_change
        '
        Me.Download_anzeige_change.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Download_anzeige_change.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Download_anzeige_change.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FortschrittToolStripMenuItem, Me.GeschwindigkeitToolStripMenuItem, Me.RestzeitToolStripMenuItem, Me.DatenmengeToolStripMenuItem, Me.ToolStripSeparator14, Me.DownloadStartenToolStripMenuItem, Me.DownloadAbbrechenToolStripMenuItem, Me.ListeLeerenToolStripMenuItem, Me.ToolStripSeparator21, Me.DownloadAutomatischStarToolStripMenuItem, Me.ToolStripSeparator22, Me.DownloadoptionenToolStripMenuItem, Me.ImFensterStartenToolStripMenuItem})
        Me.Download_anzeige_change.Image = CType(resources.GetObject("Download_anzeige_change.Image"), System.Drawing.Image)
        Me.Download_anzeige_change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Download_anzeige_change.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Download_anzeige_change.Name = "Download_anzeige_change"
        Me.Download_anzeige_change.ShowDropDownArrow = False
        Me.Download_anzeige_change.Size = New System.Drawing.Size(20, 22)
        Me.Download_anzeige_change.Text = "Downloads"
        Me.Download_anzeige_change.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Download_anzeige_change.Visible = False
        '
        'FortschrittToolStripMenuItem
        '
        Me.FortschrittToolStripMenuItem.Name = "FortschrittToolStripMenuItem"
        Me.FortschrittToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.FortschrittToolStripMenuItem.Text = "Fortschritt"
        '
        'GeschwindigkeitToolStripMenuItem
        '
        Me.GeschwindigkeitToolStripMenuItem.Name = "GeschwindigkeitToolStripMenuItem"
        Me.GeschwindigkeitToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.GeschwindigkeitToolStripMenuItem.Text = "Geschwindigkeit"
        '
        'RestzeitToolStripMenuItem
        '
        Me.RestzeitToolStripMenuItem.Name = "RestzeitToolStripMenuItem"
        Me.RestzeitToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.RestzeitToolStripMenuItem.Text = "Restzeit"
        '
        'DatenmengeToolStripMenuItem
        '
        Me.DatenmengeToolStripMenuItem.Name = "DatenmengeToolStripMenuItem"
        Me.DatenmengeToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.DatenmengeToolStripMenuItem.Text = "Datenmenge"
        '
        'ToolStripSeparator14
        '
        Me.ToolStripSeparator14.Name = "ToolStripSeparator14"
        Me.ToolStripSeparator14.Size = New System.Drawing.Size(238, 6)
        '
        'DownloadStartenToolStripMenuItem
        '
        Me.DownloadStartenToolStripMenuItem.Name = "DownloadStartenToolStripMenuItem"
        Me.DownloadStartenToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.DownloadStartenToolStripMenuItem.Text = "Download starten"
        '
        'DownloadAbbrechenToolStripMenuItem
        '
        Me.DownloadAbbrechenToolStripMenuItem.Name = "DownloadAbbrechenToolStripMenuItem"
        Me.DownloadAbbrechenToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.DownloadAbbrechenToolStripMenuItem.Text = "Download abbrechen"
        '
        'ListeLeerenToolStripMenuItem
        '
        Me.ListeLeerenToolStripMenuItem.Name = "ListeLeerenToolStripMenuItem"
        Me.ListeLeerenToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ListeLeerenToolStripMenuItem.Text = "Liste leeren"
        '
        'ToolStripSeparator21
        '
        Me.ToolStripSeparator21.Name = "ToolStripSeparator21"
        Me.ToolStripSeparator21.Size = New System.Drawing.Size(238, 6)
        '
        'DownloadAutomatischStarToolStripMenuItem
        '
        Me.DownloadAutomatischStarToolStripMenuItem.Name = "DownloadAutomatischStarToolStripMenuItem"
        Me.DownloadAutomatischStarToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.DownloadAutomatischStarToolStripMenuItem.Text = "Downloads automatisch starten"
        '
        'ToolStripSeparator22
        '
        Me.ToolStripSeparator22.Name = "ToolStripSeparator22"
        Me.ToolStripSeparator22.Size = New System.Drawing.Size(238, 6)
        '
        'DownloadoptionenToolStripMenuItem
        '
        Me.DownloadoptionenToolStripMenuItem.Name = "DownloadoptionenToolStripMenuItem"
        Me.DownloadoptionenToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.DownloadoptionenToolStripMenuItem.Text = "Downloadoptionen"
        '
        'ImFensterStartenToolStripMenuItem
        '
        Me.ImFensterStartenToolStripMenuItem.Name = "ImFensterStartenToolStripMenuItem"
        Me.ImFensterStartenToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ImFensterStartenToolStripMenuItem.Text = "Im Fenster starten"
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.Image = CType(resources.GetObject("ToolStripButton19.Image"), System.Drawing.Image)
        Me.ToolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton19.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripButton19.Text = "Downloads"
        '
        'SplitContainer_Infopanel
        '
        Me.SplitContainer_Infopanel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.SplitContainer_Infopanel.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.SplitContainer_Infopanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer_Infopanel.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer_Infopanel.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer_Infopanel.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer_Infopanel.Name = "SplitContainer_Infopanel"
        '
        'SplitContainer_Infopanel.Panel1
        '
        Me.SplitContainer_Infopanel.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Panel_Overlay_useImage)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Panel_q_Trailer)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Panel_flagquestion)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Panel_ask_selectmovie)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Movie_GridView)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Nov_line_browser)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.Nav_Datagrid)
        Me.SplitContainer_Infopanel.Panel1.Controls.Add(Me.MyBrowserHelpbar)
        Me.SplitContainer_Infopanel.Panel1.Cursor = System.Windows.Forms.Cursors.Default
        '
        'SplitContainer_Infopanel.Panel2
        '
        Me.SplitContainer_Infopanel.Panel2.AutoScroll = True
        Me.SplitContainer_Infopanel.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer_Infopanel.Panel2.Controls.Add(Me.InfoPanel_Movie1)
        Me.SplitContainer_Infopanel.Panel2.Controls.Add(Me.InfoPanel_Episode1)
        Me.SplitContainer_Infopanel.Panel2.Cursor = System.Windows.Forms.Cursors.Default
        Me.SplitContainer_Infopanel.Size = New System.Drawing.Size(930, 517)
        Me.SplitContainer_Infopanel.SplitterDistance = 699
        Me.SplitContainer_Infopanel.SplitterWidth = 2
        Me.SplitContainer_Infopanel.TabIndex = 7
        '
        'Panel_Overlay_useImage
        '
        Me.Panel_Overlay_useImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Overlay_useImage.AutoSize = True
        Me.Panel_Overlay_useImage.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_Overlay_useImage.Controls.Add(Me.Panel8)
        Me.Panel_Overlay_useImage.Location = New System.Drawing.Point(301, 143)
        Me.Panel_Overlay_useImage.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_Overlay_useImage.Name = "Panel_Overlay_useImage"
        Me.Panel_Overlay_useImage.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.Panel_Overlay_useImage.Size = New System.Drawing.Size(217, 51)
        Me.Panel_Overlay_useImage.TabIndex = 15
        Me.Panel_Overlay_useImage.Visible = False
        '
        'Panel8
        '
        Me.Panel8.AutoSize = True
        Me.Panel8.BackColor = System.Drawing.SystemColors.Info
        Me.Panel8.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(1, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(215, 50)
        Me.Panel8.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_useasCover, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button_useasBackdrop, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(215, 50)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Dieses Bild verwenden als..."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button_useasCover
        '
        Me.Button_useasCover.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button_useasCover.Location = New System.Drawing.Point(3, 24)
        Me.Button_useasCover.Name = "Button_useasCover"
        Me.Button_useasCover.Size = New System.Drawing.Size(101, 23)
        Me.Button_useasCover.TabIndex = 0
        Me.Button_useasCover.Text = "Cover"
        Me.Button_useasCover.UseVisualStyleBackColor = True
        '
        'Button_useasBackdrop
        '
        Me.Button_useasBackdrop.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button_useasBackdrop.Location = New System.Drawing.Point(110, 24)
        Me.Button_useasBackdrop.Name = "Button_useasBackdrop"
        Me.Button_useasBackdrop.Size = New System.Drawing.Size(102, 23)
        Me.Button_useasBackdrop.TabIndex = 1
        Me.Button_useasBackdrop.Text = "Backdrop"
        Me.Button_useasBackdrop.UseVisualStyleBackColor = True
        '
        'Panel_q_Trailer
        '
        Me.Panel_q_Trailer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_q_Trailer.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_q_Trailer.Controls.Add(Me.Panel9)
        Me.Panel_q_Trailer.Location = New System.Drawing.Point(301, 306)
        Me.Panel_q_Trailer.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_q_Trailer.Name = "Panel_q_Trailer"
        Me.Panel_q_Trailer.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.Panel_q_Trailer.Size = New System.Drawing.Size(217, 37)
        Me.Panel_q_Trailer.TabIndex = 16
        Me.Panel_q_Trailer.Visible = False
        '
        'Panel9
        '
        Me.Panel9.AutoSize = True
        Me.Panel9.BackColor = System.Drawing.SystemColors.Info
        Me.Panel9.Controls.Add(Me.Button_Download_Trailer)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(1, 0)
        Me.Panel9.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel9.Size = New System.Drawing.Size(215, 36)
        Me.Panel9.TabIndex = 9
        '
        'Button_Download_Trailer
        '
        Me.Button_Download_Trailer.AutoSize = True
        Me.Button_Download_Trailer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button_Download_Trailer.Location = New System.Drawing.Point(5, 5)
        Me.Button_Download_Trailer.Margin = New System.Windows.Forms.Padding(5)
        Me.Button_Download_Trailer.Name = "Button_Download_Trailer"
        Me.Button_Download_Trailer.Size = New System.Drawing.Size(205, 26)
        Me.Button_Download_Trailer.TabIndex = 1
        Me.Button_Download_Trailer.Text = "Diesen Trailer herunterladen"
        Me.Button_Download_Trailer.UseVisualStyleBackColor = True
        '
        'Panel_flagquestion
        '
        Me.Panel_flagquestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_flagquestion.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_flagquestion.Controls.Add(Me.Panel2)
        Me.Panel_flagquestion.Location = New System.Drawing.Point(301, 241)
        Me.Panel_flagquestion.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_flagquestion.Name = "Panel_flagquestion"
        Me.Panel_flagquestion.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel_flagquestion.Size = New System.Drawing.Size(217, 59)
        Me.Panel_flagquestion.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Info
        Me.Panel2.Controls.Add(Me.TableLayoutPanel7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(215, 57)
        Me.Panel2.TabIndex = 9
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.AutoSize = True
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.Button2, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Button1, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(215, 57)
        Me.TableLayoutPanel7.TabIndex = 16
        '
        'Button2
        '
        Me.Button2.AutoSize = True
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(166, 26)
        Me.Button2.Margin = New System.Windows.Forms.Padding(5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(44, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Nein"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.AutoSize = True
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(5, 26)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ja"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.TableLayoutPanel7.SetColumnSpan(Me.Label13, 2)
        Me.Label13.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label13.Location = New System.Drawing.Point(5, 3)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 15)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Ist das der richtige Film?"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_ask_selectmovie
        '
        Me.Panel_ask_selectmovie.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_ask_selectmovie.BackColor = System.Drawing.SystemColors.GrayText
        Me.Panel_ask_selectmovie.Controls.Add(Me.Panel7)
        Me.Panel_ask_selectmovie.Location = New System.Drawing.Point(301, 87)
        Me.Panel_ask_selectmovie.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel_ask_selectmovie.Name = "Panel_ask_selectmovie"
        Me.Panel_ask_selectmovie.Padding = New System.Windows.Forms.Padding(1, 0, 1, 1)
        Me.Panel_ask_selectmovie.Size = New System.Drawing.Size(217, 37)
        Me.Panel_ask_selectmovie.TabIndex = 14
        Me.Panel_ask_selectmovie.Visible = False
        '
        'Panel7
        '
        Me.Panel7.AutoSize = True
        Me.Panel7.BackColor = System.Drawing.SystemColors.Info
        Me.Panel7.Controls.Add(Me.Button6)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(1, 0)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel7.Size = New System.Drawing.Size(215, 36)
        Me.Panel7.TabIndex = 9
        '
        'Button6
        '
        Me.Button6.AutoSize = True
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button6.Location = New System.Drawing.Point(5, 5)
        Me.Button6.Margin = New System.Windows.Forms.Padding(5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(205, 26)
        Me.Button6.TabIndex = 1
        Me.Button6.Text = "Diesen Film auswählen"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Movie_GridView
        '
        Me.Movie_GridView.AllowDrop = True
        Me.Movie_GridView.AllowUserToAddRows = False
        Me.Movie_GridView.AllowUserToDeleteRows = False
        Me.Movie_GridView.AllowUserToOrderColumns = True
        Me.Movie_GridView.AllowUserToResizeRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Movie_GridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.Movie_GridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.Movie_GridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Movie_GridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Movie_GridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.Movie_GridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Movie_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Movie_GridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column_Flags, Me.Column_Fortschritt, Me.Column_Rate_Cover, Me.Column_Rate_Backdrops, Me.Column_Rate_Info, Me.Column_Rate_MediaInfo, Me.Column_Rate_Ordner, Me.Column_Pfad, Me.Column_Ordner, Me.Column_Titel, Me.Column_Originaltitel, Me.Column_IMDB_ID, Me.Column_Darsteller, Me.Column_Regie, Me.Column_Autoren, Me.Column_Studios, Me.Column_Produktionsjahr, Me.Column_Produktionsland, Me.Column_Genre, Me.Column_FSK, Me.Column_Bewertung, Me.Column_Spieldauer, Me.Column_Kurzbeschreibung, Me.Column_Inhalt, Me.Column_MediaInfo, Me.Column_Position, Me.Column_Datum, Me.Column_Sort, Me.Column_Auflösung, Me.Column_Seitenverhältnis, Me.Column_VideoBildwiederholungsrate, Me.Column_VideoCodec, Me.Column_AudioKanäle, Me.Column_AudioCodec, Me.Column_Sprachen, Me.Column_FilesCount, Me.Column_SizeFolder, Me.Column_watched, Me.Column_Trailer, Me.Column_Set, Me.Column_Depth})
        Me.Movie_GridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Movie_GridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Movie_GridView.Location = New System.Drawing.Point(0, 25)
        Me.Movie_GridView.Margin = New System.Windows.Forms.Padding(2)
        Me.Movie_GridView.Name = "Movie_GridView"
        Me.Movie_GridView.ReadOnly = True
        Me.Movie_GridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Movie_GridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Movie_GridView.RowHeadersWidth = 30
        Me.Movie_GridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Movie_GridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Movie_GridView.RowTemplate.Height = 28
        Me.Movie_GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Movie_GridView.ShowCellErrors = False
        Me.Movie_GridView.ShowEditingIcon = False
        Me.Movie_GridView.ShowRowErrors = False
        Me.Movie_GridView.Size = New System.Drawing.Size(699, 492)
        Me.Movie_GridView.TabIndex = 6
        '
        'Column_Flags
        '
        Me.Column_Flags.FillWeight = 30.0!
        Me.Column_Flags.HeaderText = "Flags"
        Me.Column_Flags.MinimumWidth = 16
        Me.Column_Flags.Name = "Column_Flags"
        Me.Column_Flags.ReadOnly = True
        Me.Column_Flags.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Flags.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Flags.Width = 30
        '
        'Column_Fortschritt
        '
        Me.Column_Fortschritt.HeaderText = "Fortschritt (%)"
        Me.Column_Fortschritt.Name = "Column_Fortschritt"
        Me.Column_Fortschritt.ReadOnly = True
        Me.Column_Fortschritt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Fortschritt.Width = 60
        '
        'Column_Rate_Cover
        '
        Me.Column_Rate_Cover.FillWeight = 30.0!
        Me.Column_Rate_Cover.HeaderText = "Cover (Status)"
        Me.Column_Rate_Cover.MinimumWidth = 16
        Me.Column_Rate_Cover.Name = "Column_Rate_Cover"
        Me.Column_Rate_Cover.ReadOnly = True
        Me.Column_Rate_Cover.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Rate_Cover.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Rate_Cover.Width = 30
        '
        'Column_Rate_Backdrops
        '
        Me.Column_Rate_Backdrops.FillWeight = 30.0!
        Me.Column_Rate_Backdrops.HeaderText = "Backdrops  (Status)"
        Me.Column_Rate_Backdrops.MinimumWidth = 16
        Me.Column_Rate_Backdrops.Name = "Column_Rate_Backdrops"
        Me.Column_Rate_Backdrops.ReadOnly = True
        Me.Column_Rate_Backdrops.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Rate_Backdrops.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Rate_Backdrops.Width = 30
        '
        'Column_Rate_Info
        '
        Me.Column_Rate_Info.FillWeight = 30.0!
        Me.Column_Rate_Info.HeaderText = "Info (Status)"
        Me.Column_Rate_Info.MinimumWidth = 16
        Me.Column_Rate_Info.Name = "Column_Rate_Info"
        Me.Column_Rate_Info.ReadOnly = True
        Me.Column_Rate_Info.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Rate_Info.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Rate_Info.Width = 30
        '
        'Column_Rate_MediaInfo
        '
        Me.Column_Rate_MediaInfo.FillWeight = 30.0!
        Me.Column_Rate_MediaInfo.HeaderText = "Media Info (Status)"
        Me.Column_Rate_MediaInfo.MinimumWidth = 16
        Me.Column_Rate_MediaInfo.Name = "Column_Rate_MediaInfo"
        Me.Column_Rate_MediaInfo.ReadOnly = True
        Me.Column_Rate_MediaInfo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Rate_MediaInfo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Rate_MediaInfo.Width = 30
        '
        'Column_Rate_Ordner
        '
        Me.Column_Rate_Ordner.FillWeight = 30.0!
        Me.Column_Rate_Ordner.HeaderText = "Ordner (Status)"
        Me.Column_Rate_Ordner.MinimumWidth = 16
        Me.Column_Rate_Ordner.Name = "Column_Rate_Ordner"
        Me.Column_Rate_Ordner.ReadOnly = True
        Me.Column_Rate_Ordner.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column_Rate_Ordner.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_Rate_Ordner.Width = 30
        '
        'Column_Pfad
        '
        Me.Column_Pfad.HeaderText = "Pfad"
        Me.Column_Pfad.Name = "Column_Pfad"
        Me.Column_Pfad.ReadOnly = True
        Me.Column_Pfad.Visible = False
        '
        'Column_Ordner
        '
        Me.Column_Ordner.HeaderText = "Ordner"
        Me.Column_Ordner.Name = "Column_Ordner"
        Me.Column_Ordner.ReadOnly = True
        Me.Column_Ordner.Visible = False
        '
        'Column_Titel
        '
        Me.Column_Titel.HeaderText = "Titel"
        Me.Column_Titel.Name = "Column_Titel"
        Me.Column_Titel.ReadOnly = True
        '
        'Column_Originaltitel
        '
        Me.Column_Originaltitel.HeaderText = "Originaltitel"
        Me.Column_Originaltitel.Name = "Column_Originaltitel"
        Me.Column_Originaltitel.ReadOnly = True
        Me.Column_Originaltitel.Visible = False
        '
        'Column_IMDB_ID
        '
        Me.Column_IMDB_ID.HeaderText = "IMDB_ID"
        Me.Column_IMDB_ID.Name = "Column_IMDB_ID"
        Me.Column_IMDB_ID.ReadOnly = True
        Me.Column_IMDB_ID.Visible = False
        '
        'Column_Darsteller
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_Darsteller.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column_Darsteller.HeaderText = "Darsteller"
        Me.Column_Darsteller.Name = "Column_Darsteller"
        Me.Column_Darsteller.ReadOnly = True
        Me.Column_Darsteller.Visible = False
        '
        'Column_Regie
        '
        Me.Column_Regie.HeaderText = "Regie"
        Me.Column_Regie.Name = "Column_Regie"
        Me.Column_Regie.ReadOnly = True
        Me.Column_Regie.Visible = False
        '
        'Column_Autoren
        '
        Me.Column_Autoren.HeaderText = "Autoren"
        Me.Column_Autoren.Name = "Column_Autoren"
        Me.Column_Autoren.ReadOnly = True
        Me.Column_Autoren.Visible = False
        '
        'Column_Studios
        '
        Me.Column_Studios.HeaderText = "Studios"
        Me.Column_Studios.Name = "Column_Studios"
        Me.Column_Studios.ReadOnly = True
        Me.Column_Studios.Visible = False
        '
        'Column_Produktionsjahr
        '
        Me.Column_Produktionsjahr.HeaderText = "Jahr"
        Me.Column_Produktionsjahr.Name = "Column_Produktionsjahr"
        Me.Column_Produktionsjahr.ReadOnly = True
        Me.Column_Produktionsjahr.Visible = False
        '
        'Column_Produktionsland
        '
        Me.Column_Produktionsland.HeaderText = "Land"
        Me.Column_Produktionsland.Name = "Column_Produktionsland"
        Me.Column_Produktionsland.ReadOnly = True
        Me.Column_Produktionsland.Visible = False
        '
        'Column_Genre
        '
        Me.Column_Genre.HeaderText = "Genre"
        Me.Column_Genre.Name = "Column_Genre"
        Me.Column_Genre.ReadOnly = True
        Me.Column_Genre.Visible = False
        '
        'Column_FSK
        '
        Me.Column_FSK.HeaderText = "FSK"
        Me.Column_FSK.Name = "Column_FSK"
        Me.Column_FSK.ReadOnly = True
        Me.Column_FSK.Visible = False
        '
        'Column_Bewertung
        '
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "1,00"
        Me.Column_Bewertung.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column_Bewertung.HeaderText = "Bewertung"
        Me.Column_Bewertung.Name = "Column_Bewertung"
        Me.Column_Bewertung.ReadOnly = True
        Me.Column_Bewertung.Visible = False
        '
        'Column_Spieldauer
        '
        Me.Column_Spieldauer.HeaderText = "Dauer"
        Me.Column_Spieldauer.Name = "Column_Spieldauer"
        Me.Column_Spieldauer.ReadOnly = True
        Me.Column_Spieldauer.Visible = False
        '
        'Column_Kurzbeschreibung
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_Kurzbeschreibung.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column_Kurzbeschreibung.HeaderText = "Kurzbeschreibung"
        Me.Column_Kurzbeschreibung.Name = "Column_Kurzbeschreibung"
        Me.Column_Kurzbeschreibung.ReadOnly = True
        Me.Column_Kurzbeschreibung.Visible = False
        '
        'Column_Inhalt
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_Inhalt.DefaultCellStyle = DataGridViewCellStyle19
        Me.Column_Inhalt.HeaderText = "Inhalt"
        Me.Column_Inhalt.Name = "Column_Inhalt"
        Me.Column_Inhalt.ReadOnly = True
        Me.Column_Inhalt.Visible = False
        '
        'Column_MediaInfo
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_MediaInfo.DefaultCellStyle = DataGridViewCellStyle20
        Me.Column_MediaInfo.HeaderText = "Media Info"
        Me.Column_MediaInfo.Name = "Column_MediaInfo"
        Me.Column_MediaInfo.ReadOnly = True
        Me.Column_MediaInfo.Visible = False
        '
        'Column_Position
        '
        Me.Column_Position.HeaderText = "Position"
        Me.Column_Position.Name = "Column_Position"
        Me.Column_Position.ReadOnly = True
        Me.Column_Position.Visible = False
        '
        'Column_Datum
        '
        Me.Column_Datum.HeaderText = "Datum"
        Me.Column_Datum.Name = "Column_Datum"
        Me.Column_Datum.ReadOnly = True
        Me.Column_Datum.Visible = False
        '
        'Column_Sort
        '
        Me.Column_Sort.HeaderText = "Sortierung"
        Me.Column_Sort.Name = "Column_Sort"
        Me.Column_Sort.ReadOnly = True
        '
        'Column_Auflösung
        '
        Me.Column_Auflösung.HeaderText = "Auflösung"
        Me.Column_Auflösung.Name = "Column_Auflösung"
        Me.Column_Auflösung.ReadOnly = True
        Me.Column_Auflösung.Visible = False
        '
        'Column_Seitenverhältnis
        '
        Me.Column_Seitenverhältnis.HeaderText = "Seitenverhältnis"
        Me.Column_Seitenverhältnis.Name = "Column_Seitenverhältnis"
        Me.Column_Seitenverhältnis.ReadOnly = True
        Me.Column_Seitenverhältnis.Visible = False
        '
        'Column_VideoBildwiederholungsrate
        '
        Me.Column_VideoBildwiederholungsrate.HeaderText = "Framerate"
        Me.Column_VideoBildwiederholungsrate.Name = "Column_VideoBildwiederholungsrate"
        Me.Column_VideoBildwiederholungsrate.ReadOnly = True
        Me.Column_VideoBildwiederholungsrate.Visible = False
        '
        'Column_VideoCodec
        '
        Me.Column_VideoCodec.HeaderText = "Video-Codec"
        Me.Column_VideoCodec.Name = "Column_VideoCodec"
        Me.Column_VideoCodec.ReadOnly = True
        Me.Column_VideoCodec.Visible = False
        '
        'Column_AudioKanäle
        '
        Me.Column_AudioKanäle.HeaderText = "Audio-Kanäle"
        Me.Column_AudioKanäle.Name = "Column_AudioKanäle"
        Me.Column_AudioKanäle.ReadOnly = True
        Me.Column_AudioKanäle.Visible = False
        '
        'Column_AudioCodec
        '
        Me.Column_AudioCodec.HeaderText = "Audio-Codec"
        Me.Column_AudioCodec.Name = "Column_AudioCodec"
        Me.Column_AudioCodec.ReadOnly = True
        Me.Column_AudioCodec.Visible = False
        '
        'Column_Sprachen
        '
        Me.Column_Sprachen.HeaderText = "Sprache"
        Me.Column_Sprachen.Name = "Column_Sprachen"
        Me.Column_Sprachen.ReadOnly = True
        Me.Column_Sprachen.Visible = False
        '
        'Column_FilesCount
        '
        Me.Column_FilesCount.HeaderText = "Dateien"
        Me.Column_FilesCount.Name = "Column_FilesCount"
        Me.Column_FilesCount.ReadOnly = True
        Me.Column_FilesCount.Visible = False
        '
        'Column_SizeFolder
        '
        Me.Column_SizeFolder.HeaderText = "Ordnergröße"
        Me.Column_SizeFolder.Name = "Column_SizeFolder"
        Me.Column_SizeFolder.ReadOnly = True
        Me.Column_SizeFolder.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_SizeFolder.Visible = False
        '
        'Column_watched
        '
        Me.Column_watched.HeaderText = "Gesehen"
        Me.Column_watched.Name = "Column_watched"
        Me.Column_watched.ReadOnly = True
        Me.Column_watched.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column_watched.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column_watched.Visible = False
        '
        'Column_Trailer
        '
        Me.Column_Trailer.HeaderText = "Trailer"
        Me.Column_Trailer.Name = "Column_Trailer"
        Me.Column_Trailer.ReadOnly = True
        Me.Column_Trailer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Column_Set
        '
        Me.Column_Set.HeaderText = "Set"
        Me.Column_Set.Name = "Column_Set"
        Me.Column_Set.ReadOnly = True
        '
        'Column_Depth
        '
        Me.Column_Depth.HeaderText = "Tiefe"
        Me.Column_Depth.Name = "Column_Depth"
        Me.Column_Depth.ReadOnly = True
        Me.Column_Depth.Visible = False
        '
        'Nov_line_browser
        '
        Me.Nov_line_browser.BackColor = System.Drawing.SystemColors.Window
        Me.Nov_line_browser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nov_line_browser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton8, Me.ToolStripButton6, Me.ToolStripSeparator53, Me.MyBrowser_Favicon, Me.Browser_Navigationtb, Me.ToolStripButton10, Me.ToolStripButton12, Me.MyBrowser_Close, Me.ToolStripSeparator15, Me.ToolStripButton7, Me.ToolStripButton23})
        Me.Nov_line_browser.Location = New System.Drawing.Point(0, 25)
        Me.Nov_line_browser.Name = "Nov_line_browser"
        Me.Nov_line_browser.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nov_line_browser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Nov_line_browser.Size = New System.Drawing.Size(609, 32)
        Me.Nov_line_browser.TabIndex = 10
        Me.Nov_line_browser.Text = "ToolStrip4"
        Me.Nov_line_browser.Visible = False
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.Film_Info__Organizer.Toolbar16.back
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton8.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton8.Text = "Zurück"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = Global.Film_Info__Organizer.Toolbar16.forward
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton6.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton6.Text = "Weiter"
        '
        'ToolStripSeparator53
        '
        Me.ToolStripSeparator53._height = 0
        Me.ToolStripSeparator53._width = 8
        Me.ToolStripSeparator53.AutoSize = False
        Me.ToolStripSeparator53.Name = "ToolStripSeparator53"
        Me.ToolStripSeparator53.Size = New System.Drawing.Size(6, 32)
        '
        'MyBrowser_Favicon
        '
        Me.MyBrowser_Favicon.AutoSize = False
        Me.MyBrowser_Favicon.BackColor = System.Drawing.Color.Transparent
        Me.MyBrowser_Favicon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MyBrowser_Favicon.Margin = New System.Windows.Forms.Padding(3)
        Me.MyBrowser_Favicon.Name = "MyBrowser_Favicon"
        Me.MyBrowser_Favicon.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.MyBrowser_Favicon.Size = New System.Drawing.Size(22, 22)
        Me.MyBrowser_Favicon.Text = "MyBrowser_Favicon"
        '
        'Browser_Navigationtb
        '
        Me.Browser_Navigationtb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Browser_Navigationtb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Browser_Navigationtb.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Browser_Navigationtb.Name = "Browser_Navigationtb"
        Me.Browser_Navigationtb.Size = New System.Drawing.Size(230, 32)
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton10.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton10.Text = "Go"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton12.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton12.Text = "Browser anzeigen"
        '
        'MyBrowser_Close
        '
        Me.MyBrowser_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.MyBrowser_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.MyBrowser_Close.Image = CType(resources.GetObject("MyBrowser_Close.Image"), System.Drawing.Image)
        Me.MyBrowser_Close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MyBrowser_Close.Margin = New System.Windows.Forms.Padding(3)
        Me.MyBrowser_Close.Name = "MyBrowser_Close"
        Me.MyBrowser_Close.Padding = New System.Windows.Forms.Padding(6, 3, 20, 3)
        Me.MyBrowser_Close.Size = New System.Drawing.Size(46, 26)
        Me.MyBrowser_Close.Text = "Schließen"
        '
        'ToolStripSeparator15
        '
        Me.ToolStripSeparator15._height = 0
        Me.ToolStripSeparator15._width = 8
        Me.ToolStripSeparator15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator15.AutoSize = False
        Me.ToolStripSeparator15.Name = "ToolStripSeparator15"
        Me.ToolStripSeparator15.Size = New System.Drawing.Size(8, 32)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton7.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton7.Text = "In externem Browser öffnen"
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton23.Image = Global.Film_Info__Organizer.Toolbar16.plugins
        Me.ToolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton23.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton23.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton23.Text = "Hilfefunktionen"
        '
        'Nav_Datagrid
        '
        Me.Nav_Datagrid.BackColor = System.Drawing.SystemColors.Window
        Me.Nav_Datagrid.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_Datagrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton14, Me.ToolStripButton13, Me.ToolStripTextBox1, Me.Filter_Dropdown_OPT})
        Me.Nav_Datagrid.Location = New System.Drawing.Point(0, 0)
        Me.Nav_Datagrid.Name = "Nav_Datagrid"
        Me.Nav_Datagrid.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_Datagrid.Size = New System.Drawing.Size(699, 25)
        Me.Nav_Datagrid.TabIndex = 7
        Me.Nav_Datagrid.Text = "ToolStrip1"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = CType(resources.GetObject("ToolStripButton14.Image"), System.Drawing.Image)
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Margin = New System.Windows.Forms.Padding(0, 1, 3, 2)
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton14.Text = "Browser anzeigen"
        '
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = Global.Film_Info__Organizer.Toolbar16.config
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton13.Text = "Spalten bearbeiten"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ToolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ToolStripTextBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(230, 25)
        '
        'Filter_Dropdown_OPT
        '
        Me.Filter_Dropdown_OPT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Filter_Dropdown_OPT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Filter_Dropdown_OPT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TitelToolStripMenuItem, Me.PersonenToolStripMenuItem, Me.GenreToolStripMenuItem1, Me.JahrToolStripMenuItem, Me.ToolStripSeparator23, Me.FortschrittToolStripMenuItem1, Me.SammlungToolStripMenuItem1, Me.ToolStripSeparator24, Me.WeitereFunktionenToolStripMenuItem})
        Me.Filter_Dropdown_OPT.Image = CType(resources.GetObject("Filter_Dropdown_OPT.Image"), System.Drawing.Image)
        Me.Filter_Dropdown_OPT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Filter_Dropdown_OPT.Name = "Filter_Dropdown_OPT"
        Me.Filter_Dropdown_OPT.Size = New System.Drawing.Size(43, 22)
        Me.Filter_Dropdown_OPT.Text = "Titel"
        '
        'TitelToolStripMenuItem
        '
        Me.TitelToolStripMenuItem.Name = "TitelToolStripMenuItem"
        Me.TitelToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.TitelToolStripMenuItem.Text = "Titel"
        '
        'PersonenToolStripMenuItem
        '
        Me.PersonenToolStripMenuItem.Name = "PersonenToolStripMenuItem"
        Me.PersonenToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.PersonenToolStripMenuItem.Text = "Personen"
        '
        'GenreToolStripMenuItem1
        '
        Me.GenreToolStripMenuItem1.Name = "GenreToolStripMenuItem1"
        Me.GenreToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.GenreToolStripMenuItem1.Text = "Genre"
        '
        'JahrToolStripMenuItem
        '
        Me.JahrToolStripMenuItem.Name = "JahrToolStripMenuItem"
        Me.JahrToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.JahrToolStripMenuItem.Text = "Jahr"
        '
        'ToolStripSeparator23
        '
        Me.ToolStripSeparator23.Name = "ToolStripSeparator23"
        Me.ToolStripSeparator23.Size = New System.Drawing.Size(174, 6)
        '
        'FortschrittToolStripMenuItem1
        '
        Me.FortschrittToolStripMenuItem1.Name = "FortschrittToolStripMenuItem1"
        Me.FortschrittToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.FortschrittToolStripMenuItem1.Text = "Fortschritt"
        '
        'SammlungToolStripMenuItem1
        '
        Me.SammlungToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DummyToolStripMenuItem})
        Me.SammlungToolStripMenuItem1.Name = "SammlungToolStripMenuItem1"
        Me.SammlungToolStripMenuItem1.Size = New System.Drawing.Size(177, 22)
        Me.SammlungToolStripMenuItem1.Text = "Sammlung"
        '
        'DummyToolStripMenuItem
        '
        Me.DummyToolStripMenuItem.Name = "DummyToolStripMenuItem"
        Me.DummyToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DummyToolStripMenuItem.Text = "dummy"
        '
        'ToolStripSeparator24
        '
        Me.ToolStripSeparator24.Name = "ToolStripSeparator24"
        Me.ToolStripSeparator24.Size = New System.Drawing.Size(174, 6)
        '
        'WeitereFunktionenToolStripMenuItem
        '
        Me.WeitereFunktionenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DoppelteFilmeToolStripMenuItem})
        Me.WeitereFunktionenToolStripMenuItem.Name = "WeitereFunktionenToolStripMenuItem"
        Me.WeitereFunktionenToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.WeitereFunktionenToolStripMenuItem.Text = "Weitere Funktionen"
        '
        'DoppelteFilmeToolStripMenuItem
        '
        Me.DoppelteFilmeToolStripMenuItem.Name = "DoppelteFilmeToolStripMenuItem"
        Me.DoppelteFilmeToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.DoppelteFilmeToolStripMenuItem.Text = "Doppelte Filme"
        '
        'MyBrowserHelpbar
        '
        Me.MyBrowserHelpbar.AutoSize = False
        Me.MyBrowserHelpbar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.ToolStripButton16, Me.ToolStripButton15})
        Me.MyBrowserHelpbar.Location = New System.Drawing.Point(0, 265)
        Me.MyBrowserHelpbar.Name = "MyBrowserHelpbar"
        Me.MyBrowserHelpbar.Padding = New System.Windows.Forms.Padding(1, 0, 10, 0)
        Me.MyBrowserHelpbar.Size = New System.Drawing.Size(840, 119)
        Me.MyBrowserHelpbar.SizingGrip = False
        Me.MyBrowserHelpbar.TabIndex = 11
        Me.MyBrowserHelpbar.Text = "StatusStrip1"
        Me.MyBrowserHelpbar.Visible = False
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AutoSize = False
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.Image = CType(resources.GetObject("ToolStripStatusLabel2.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(48, 114)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(673, 114)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Ist das der richtige Film?"
        Me.ToolStripStatusLabel1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton16.AutoSize = False
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = CType(resources.GetObject("ToolStripButton16.Image"), System.Drawing.Image)
        Me.ToolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton16.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.Padding = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton16.Size = New System.Drawing.Size(48, 111)
        Me.ToolStripButton16.Text = "Aktualisieren"
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton15.AutoSize = False
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton15.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.Padding = New System.Windows.Forms.Padding(5)
        Me.ToolStripButton15.Size = New System.Drawing.Size(48, 111)
        Me.ToolStripButton15.Text = "Aktualisieren"
        '
        'InfoPanel_Movie1
        '
        Me.InfoPanel_Movie1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoPanel_Movie1.isLoaded = False
        Me.InfoPanel_Movie1.Location = New System.Drawing.Point(0, 0)
        Me.InfoPanel_Movie1.Name = "InfoPanel_Movie1"
        Me.InfoPanel_Movie1.SelectedResult = Nothing
        Me.InfoPanel_Movie1.ShowLinkBar = False
        Me.InfoPanel_Movie1.Size = New System.Drawing.Size(229, 517)
        Me.InfoPanel_Movie1.TabIndex = 0
        '
        'InfoPanel_Episode1
        '
        Me.InfoPanel_Episode1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoPanel_Episode1.isLoaded = False
        Me.InfoPanel_Episode1.Location = New System.Drawing.Point(0, 0)
        Me.InfoPanel_Episode1.Name = "InfoPanel_Episode1"
        Me.InfoPanel_Episode1.SelectedEpisode = Nothing
        Me.InfoPanel_Episode1.Size = New System.Drawing.Size(229, 517)
        Me.InfoPanel_Episode1.TabIndex = 18
        Me.InfoPanel_Episode1.Visible = False
        '
        'Column_Ser_Progress
        '
        Me.Column_Ser_Progress.HeaderText = "Fortschritt"
        Me.Column_Ser_Progress.Name = "Column_Ser_Progress"
        '
        'Column_Serien_RateCover
        '
        Me.Column_Serien_RateCover.FillWeight = 30.0!
        Me.Column_Serien_RateCover.HeaderText = "Cover"
        Me.Column_Serien_RateCover.MinimumWidth = 16
        Me.Column_Serien_RateCover.Name = "Column_Serien_RateCover"
        Me.Column_Serien_RateCover.Width = 30
        '
        'Column_Serien_RateInhalt
        '
        Me.Column_Serien_RateInhalt.FillWeight = 30.0!
        Me.Column_Serien_RateInhalt.HeaderText = "Inhalt"
        Me.Column_Serien_RateInhalt.MinimumWidth = 16
        Me.Column_Serien_RateInhalt.Name = "Column_Serien_RateInhalt"
        Me.Column_Serien_RateInhalt.Width = 30
        '
        'Column_Serien_RateMediaInfo
        '
        Me.Column_Serien_RateMediaInfo.FillWeight = 30.0!
        Me.Column_Serien_RateMediaInfo.HeaderText = "Media Info"
        Me.Column_Serien_RateMediaInfo.MinimumWidth = 16
        Me.Column_Serien_RateMediaInfo.Name = "Column_Serien_RateMediaInfo"
        Me.Column_Serien_RateMediaInfo.Width = 30
        '
        'Column_Serien_RateFilename
        '
        Me.Column_Serien_RateFilename.FillWeight = 30.0!
        Me.Column_Serien_RateFilename.HeaderText = "Dateiname"
        Me.Column_Serien_RateFilename.MinimumWidth = 16
        Me.Column_Serien_RateFilename.Name = "Column_Serien_RateFilename"
        Me.Column_Serien_RateFilename.Width = 30
        '
        'Column_Ser_Titel
        '
        Me.Column_Ser_Titel.HeaderText = "Titel"
        Me.Column_Ser_Titel.Name = "Column_Ser_Titel"
        Me.Column_Ser_Titel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column_Ser_Titel.Width = 150
        '
        'Column_Ser_Pfad
        '
        Me.Column_Ser_Pfad.HeaderText = "Pfad"
        Me.Column_Ser_Pfad.Name = "Column_Ser_Pfad"
        Me.Column_Ser_Pfad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ImageList_SerienGrid
        '
        Me.ImageList_SerienGrid.ImageStream = CType(resources.GetObject("ImageList_SerienGrid.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_SerienGrid.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_SerienGrid.Images.SetKeyName(0, "serie.png")
        Me.ImageList_SerienGrid.Images.SetKeyName(1, "staffel.png")
        Me.ImageList_SerienGrid.Images.SetKeyName(2, "Episode.png")
        '
        'ContextMenuStrip_Textbox_Genre
        '
        Me.ContextMenuStrip_Textbox_Genre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem23, Me.ToolStripSeparator25, Me.ToolStripMenuItem20, Me.ToolStripMenuItem22, Me.ToolStripMenuItem21, Me.ToolStripSeparator26, Me.BearbeitenToolStripMenuItem, Me.ToolStripSeparator27, Me.ToolStripMenuItem19})
        Me.ContextMenuStrip_Textbox_Genre.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip_Textbox_Genre.Size = New System.Drawing.Size(149, 154)
        '
        'ToolStripMenuItem23
        '
        Me.ToolStripMenuItem23.Name = "ToolStripMenuItem23"
        Me.ToolStripMenuItem23.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem23.Text = "Rückgäning"
        '
        'ToolStripSeparator25
        '
        Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
        Me.ToolStripSeparator25.Size = New System.Drawing.Size(145, 6)
        '
        'ToolStripMenuItem20
        '
        Me.ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        Me.ToolStripMenuItem20.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem20.Text = "Ausschneiden"
        '
        'ToolStripMenuItem22
        '
        Me.ToolStripMenuItem22.Name = "ToolStripMenuItem22"
        Me.ToolStripMenuItem22.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem22.Text = "Kopieren"
        '
        'ToolStripMenuItem21
        '
        Me.ToolStripMenuItem21.Name = "ToolStripMenuItem21"
        Me.ToolStripMenuItem21.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem21.Text = "Einfügen"
        '
        'ToolStripSeparator26
        '
        Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
        Me.ToolStripSeparator26.Size = New System.Drawing.Size(145, 6)
        '
        'BearbeitenToolStripMenuItem
        '
        Me.BearbeitenToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BearbeitenToolStripMenuItem.Name = "BearbeitenToolStripMenuItem"
        Me.BearbeitenToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.BearbeitenToolStripMenuItem.Text = "Bearbeiten"
        '
        'ToolStripSeparator27
        '
        Me.ToolStripSeparator27.Name = "ToolStripSeparator27"
        Me.ToolStripSeparator27.Size = New System.Drawing.Size(145, 6)
        '
        'ToolStripMenuItem19
        '
        Me.ToolStripMenuItem19.Image = CType(resources.GetObject("ToolStripMenuItem19.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        Me.ToolStripMenuItem19.Size = New System.Drawing.Size(148, 22)
        Me.ToolStripMenuItem19.Text = "Suchen..."
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Serie.png")
        Me.ImageList1.Images.SetKeyName(1, "staffel.png")
        Me.ImageList1.Images.SetKeyName(2, "folge.png")
        Me.ImageList1.Images.SetKeyName(3, "error.png")
        '
        'ContextMenu_Rows
        '
        Me.ContextMenu_Rows.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem24, Me.ToolStripMenuItem25, Me.ToolStripMenuItem26, Me.ToolStripSeparator30, Me.ToolStripMenuItem27, Me.ToolStripMenuItem28, Me.ToolStripSeparator31, Me.MediaInfoAbrufenToolStripMenuItem, Me.ToolStripSeparator17, Me.AbspielenToolStripContextitem, Me.OrdnerDurchsuchenToolStripcontextitem, Me.ToolStripSeparator61, Me.ToolStripMenuItem40, Me.ToolStripMenuItem41, Me.ToolStripMenuItem42})
        Me.ContextMenu_Rows.Name = "Rows_Contextmenu"
        Me.ContextMenu_Rows.Size = New System.Drawing.Size(184, 270)
        '
        'ToolStripMenuItem24
        '
        Me.ToolStripMenuItem24.Image = CType(resources.GetObject("ToolStripMenuItem24.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem24.Name = "ToolStripMenuItem24"
        Me.ToolStripMenuItem24.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem24.Text = "Schnelle Suche"
        '
        'ToolStripMenuItem25
        '
        Me.ToolStripMenuItem25.Image = CType(resources.GetObject("ToolStripMenuItem25.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem25.Name = "ToolStripMenuItem25"
        Me.ToolStripMenuItem25.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem25.Text = "Normale Suche"
        '
        'ToolStripMenuItem26
        '
        Me.ToolStripMenuItem26.Image = CType(resources.GetObject("ToolStripMenuItem26.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem26.Name = "ToolStripMenuItem26"
        Me.ToolStripMenuItem26.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem26.Text = "Ausführliche Suche"
        '
        'ToolStripSeparator30
        '
        Me.ToolStripSeparator30.Name = "ToolStripSeparator30"
        Me.ToolStripSeparator30.Size = New System.Drawing.Size(180, 6)
        '
        'ToolStripMenuItem27
        '
        Me.ToolStripMenuItem27.Image = CType(resources.GetObject("ToolStripMenuItem27.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem27.Name = "ToolStripMenuItem27"
        Me.ToolStripMenuItem27.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem27.Text = "Cover und Fanart"
        '
        'ToolStripMenuItem28
        '
        Me.ToolStripMenuItem28.Image = CType(resources.GetObject("ToolStripMenuItem28.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem28.Name = "ToolStripMenuItem28"
        Me.ToolStripMenuItem28.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem28.Text = "Automatisch"
        '
        'ToolStripSeparator31
        '
        Me.ToolStripSeparator31.Name = "ToolStripSeparator31"
        Me.ToolStripSeparator31.Size = New System.Drawing.Size(180, 6)
        '
        'MediaInfoAbrufenToolStripMenuItem
        '
        Me.MediaInfoAbrufenToolStripMenuItem.Image = CType(resources.GetObject("MediaInfoAbrufenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MediaInfoAbrufenToolStripMenuItem.Name = "MediaInfoAbrufenToolStripMenuItem"
        Me.MediaInfoAbrufenToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.MediaInfoAbrufenToolStripMenuItem.Text = "MediaInfo abrufen"
        '
        'ToolStripSeparator17
        '
        Me.ToolStripSeparator17.Name = "ToolStripSeparator17"
        Me.ToolStripSeparator17.Size = New System.Drawing.Size(180, 6)
        '
        'AbspielenToolStripContextitem
        '
        Me.AbspielenToolStripContextitem.Image = CType(resources.GetObject("AbspielenToolStripContextitem.Image"), System.Drawing.Image)
        Me.AbspielenToolStripContextitem.Name = "AbspielenToolStripContextitem"
        Me.AbspielenToolStripContextitem.Size = New System.Drawing.Size(183, 22)
        Me.AbspielenToolStripContextitem.Text = "Abspielen"
        '
        'OrdnerDurchsuchenToolStripcontextitem
        '
        Me.OrdnerDurchsuchenToolStripcontextitem.Image = CType(resources.GetObject("OrdnerDurchsuchenToolStripcontextitem.Image"), System.Drawing.Image)
        Me.OrdnerDurchsuchenToolStripcontextitem.Name = "OrdnerDurchsuchenToolStripcontextitem"
        Me.OrdnerDurchsuchenToolStripcontextitem.Size = New System.Drawing.Size(183, 22)
        Me.OrdnerDurchsuchenToolStripcontextitem.Text = "Ordner durchsuchen"
        '
        'ToolStripSeparator61
        '
        Me.ToolStripSeparator61.Name = "ToolStripSeparator61"
        Me.ToolStripSeparator61.Size = New System.Drawing.Size(180, 6)
        '
        'ToolStripMenuItem40
        '
        Me.ToolStripMenuItem40.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.ToolStripMenuItem40.Name = "ToolStripMenuItem40"
        Me.ToolStripMenuItem40.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem40.Text = "Löschen"
        '
        'ToolStripMenuItem41
        '
        Me.ToolStripMenuItem41.Image = Global.Film_Info__Organizer.Toolbar16.ordner_ausscheiden
        Me.ToolStripMenuItem41.Name = "ToolStripMenuItem41"
        Me.ToolStripMenuItem41.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem41.Text = "Ausscheiden"
        '
        'ToolStripMenuItem42
        '
        Me.ToolStripMenuItem42.Image = Global.Film_Info__Organizer.Toolbar16.ordner_copy
        Me.ToolStripMenuItem42.Name = "ToolStripMenuItem42"
        Me.ToolStripMenuItem42.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItem42.Text = "Kopieren"
        '
        'ContextMenu_Columns
        '
        Me.ContextMenu_Columns.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpaltenToolStripMenuItem1})
        Me.ContextMenu_Columns.Name = "ContextMenu_Columns"
        Me.ContextMenu_Columns.Size = New System.Drawing.Size(123, 26)
        '
        'SpaltenToolStripMenuItem1
        '
        Me.SpaltenToolStripMenuItem1.Name = "SpaltenToolStripMenuItem1"
        Me.SpaltenToolStripMenuItem1.Size = New System.Drawing.Size(122, 22)
        Me.SpaltenToolStripMenuItem1.Text = "Spalten..."
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpeichernToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.SpeichernToolStripMenuItem.Text = "Speichern"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'Tool_Speichern
        '
        Me.Tool_Speichern.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tool_Speichern.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SpeichernToolStripMenuItem1, Me.SpeichernAlsToolStripMenuItem})
        Me.Tool_Speichern.Image = CType(resources.GetObject("Tool_Speichern.Image"), System.Drawing.Image)
        Me.Tool_Speichern.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_Speichern.Name = "Tool_Speichern"
        Me.Tool_Speichern.Size = New System.Drawing.Size(32, 22)
        Me.Tool_Speichern.Text = "ToolStripSplitButton2"
        '
        'SpeichernToolStripMenuItem1
        '
        Me.SpeichernToolStripMenuItem1.Name = "SpeichernToolStripMenuItem1"
        Me.SpeichernToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.SpeichernToolStripMenuItem1.Text = "Speichern"
        '
        'SpeichernAlsToolStripMenuItem
        '
        Me.SpeichernAlsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilmePluginToolStripMenuItem, Me.MediaBrowserToolStripMenuItem, Me.DVDInfoToolStripMenuItem, Me.XBMCToolStripMenuItem})
        Me.SpeichernAlsToolStripMenuItem.Name = "SpeichernAlsToolStripMenuItem"
        Me.SpeichernAlsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SpeichernAlsToolStripMenuItem.Text = "Speichern als"
        '
        'FilmePluginToolStripMenuItem
        '
        Me.FilmePluginToolStripMenuItem.Name = "FilmePluginToolStripMenuItem"
        Me.FilmePluginToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.FilmePluginToolStripMenuItem.Text = "Filme Plugin (Info.xml)"
        '
        'MediaBrowserToolStripMenuItem
        '
        Me.MediaBrowserToolStripMenuItem.Name = "MediaBrowserToolStripMenuItem"
        Me.MediaBrowserToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.MediaBrowserToolStripMenuItem.Text = "Media Browser (mymovies.xml)"
        '
        'DVDInfoToolStripMenuItem
        '
        Me.DVDInfoToolStripMenuItem.Name = "DVDInfoToolStripMenuItem"
        Me.DVDInfoToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.DVDInfoToolStripMenuItem.Text = "DVD-Info (*.dvdid.xml)"
        '
        'XBMCToolStripMenuItem
        '
        Me.XBMCToolStripMenuItem.Name = "XBMCToolStripMenuItem"
        Me.XBMCToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.XBMCToolStripMenuItem.Text = "XBMC (*.nfo)"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'Panel_Update
        '
        Me.Panel_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Update.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_Update.Controls.Add(Me.Panel5)
        Me.Panel_Update.Location = New System.Drawing.Point(769, -35)
        Me.Panel_Update.Name = "Panel_Update"
        Me.Panel_Update.Padding = New System.Windows.Forms.Padding(1, 0, 0, 1)
        Me.Panel_Update.Size = New System.Drawing.Size(327, 35)
        Me.Panel_Update.TabIndex = 13
        Me.Panel_Update.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label_Update)
        Me.Panel5.Controls.Add(Me.PictureBox2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(326, 34)
        Me.Panel5.TabIndex = 0
        '
        'Label_Update
        '
        Me.Label_Update.AutoSize = True
        Me.Label_Update.Location = New System.Drawing.Point(29, 9)
        Me.Label_Update.Name = "Label_Update"
        Me.Label_Update.Size = New System.Drawing.Size(182, 15)
        Me.Label_Update.TabIndex = 1
        Me.Label_Update.Text = "Updates werden heruntergeladen"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(5, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel_Update_more
        '
        Me.Panel_Update_more.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Update_more.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_Update_more.Controls.Add(Me.Panel6)
        Me.Panel_Update_more.Location = New System.Drawing.Point(769, -104)
        Me.Panel_Update_more.Name = "Panel_Update_more"
        Me.Panel_Update_more.Padding = New System.Windows.Forms.Padding(1, 0, 0, 1)
        Me.Panel_Update_more.Size = New System.Drawing.Size(327, 104)
        Me.Panel_Update_more.TabIndex = 14
        Me.Panel_Update_more.Visible = False
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.Window
        Me.Panel6.Controls.Add(Me.Update_Link)
        Me.Panel6.Controls.Add(Me.Label_Update_State)
        Me.Panel6.Controls.Add(Me.Button3)
        Me.Panel6.Controls.Add(Me.PictureBox3)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(1, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(326, 103)
        Me.Panel6.TabIndex = 0
        '
        'Update_Link
        '
        Me.Update_Link.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Update_Link.HoverColor = System.Drawing.Color.Empty
        Me.Update_Link.Image = Nothing
        Me.Update_Link.Location = New System.Drawing.Point(14, 66)
        Me.Update_Link.Name = "Update_Link"
        Me.Update_Link.RegularColor = System.Drawing.Color.Empty
        Me.Update_Link.Size = New System.Drawing.Size(74, 16)
        Me.Update_Link.TabIndex = 49
        Me.Update_Link.Text = "Änderungen"
        '
        'Label_Update_State
        '
        Me.Label_Update_State.AutoSize = True
        Me.Label_Update_State.Location = New System.Drawing.Point(10, 30)
        Me.Label_Update_State.Name = "Label_Update_State"
        Me.Label_Update_State.Size = New System.Drawing.Size(16, 15)
        Me.Label_Update_State.TabIndex = 48
        Me.Label_Update_State.Text = "..."
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(164, 59)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(148, 30)
        Me.Button3.TabIndex = 46
        Me.Button3.Tag = "v"
        Me.Button3.Text = "Installieren"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(326, 17)
        Me.PictureBox3.TabIndex = 45
        Me.PictureBox3.TabStop = False
        '
        'Nov_Main_alt
        '
        Me.Nov_Main_alt.BackColor = System.Drawing.Color.Transparent
        Me.Nov_Main_alt.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nov_Main_alt.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exp_navbar, Me.ToolStripSeparator48, Me.Exp_Organisieren, Me.Exp_Öffnen_XP, Me.Exp_Öffnen_better, Me.exp_sep, Me.Exp_Play, Me.Exp_Abrufen, Me.exp_speichern, Me.Exp_MediaInfo, Me.Exp_Suche, Me.exp_Download, Me.Exp_Rename, Me.exp_InfoPanel, Me.ToolStripSeparator49, Me.exp_Downloads})
        Me.Nov_Main_alt.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.Nov_Main_alt.Location = New System.Drawing.Point(0, 25)
        Me.Nov_Main_alt.Name = "Nov_Main_alt"
        Me.Nov_Main_alt.Padding = New System.Windows.Forms.Padding(0)
        Me.Nov_Main_alt.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nov_Main_alt.Size = New System.Drawing.Size(1096, 32)
        Me.Nov_Main_alt.TabIndex = 16
        Me.Nov_Main_alt.Text = "ToolStrip1"
        '
        'exp_navbar
        '
        Me.exp_navbar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.exp_navbar.Image = CType(resources.GetObject("exp_navbar.Image"), System.Drawing.Image)
        Me.exp_navbar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exp_navbar.Margin = New System.Windows.Forms.Padding(3)
        Me.exp_navbar.Name = "exp_navbar"
        Me.exp_navbar.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_navbar.Size = New System.Drawing.Size(32, 26)
        Me.exp_navbar.Text = "Navigationsbereich"
        Me.exp_navbar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripSeparator48
        '
        Me.ToolStripSeparator48._height = 0
        Me.ToolStripSeparator48._width = 8
        Me.ToolStripSeparator48.AutoSize = False
        Me.ToolStripSeparator48.Name = "ToolStripSeparator48"
        Me.ToolStripSeparator48.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripSeparator48.Size = New System.Drawing.Size(8, 32)
        Me.ToolStripSeparator48.Visible = False
        '
        'Exp_Organisieren
        '
        Me.Exp_Organisieren.AutoToolTip = False
        Me.Exp_Organisieren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Exp_Organisieren.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.exp_menu_save, Me.exp_menu_saveas, Me.exp_menu_export, Me.exp_menu_backup, Me.exp_menu_edit, Me.exp_menu_Sammlung, Me.MarkierungToolStripMenuItem, Me.exp_sep_file1, Me.exp_menu_copy, Me.exp_menu_cut, Me.exp_menu_kopieren, Me.exp_menu_verschieben, Me.exp_menu_delet, Me.exp_menu_sep_file_big, Me.ToolStripMenuItem65, Me.ToolStripMenuItem66, Me.ToolStripMenuItem67, Me.ToolStripMenuItem68, Me.ToolStripSeparator36, Me.LayoutToolStripMenuItem, Me.ToolStripMenuItem51, Me.ToolStripSeparator45, Me.exp_menu_downloads, Me.exp_dl_Fortschritt, Me.exp_dl_speed, Me.exp_dl_size, Me.exp_dl_time, Me.ToolStripSeparator39, Me.ToolStripSplitButton3})
        Me.Exp_Organisieren.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Organisieren.Image = CType(resources.GetObject("Exp_Organisieren.Image"), System.Drawing.Image)
        Me.Exp_Organisieren.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Organisieren.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Organisieren.Name = "Exp_Organisieren"
        Me.Exp_Organisieren.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Organisieren.Size = New System.Drawing.Size(99, 26)
        Me.Exp_Organisieren.Text = "Organisieren"
        Me.Exp_Organisieren.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'exp_menu_save
        '
        Me.exp_menu_save.Image = CType(resources.GetObject("exp_menu_save.Image"), System.Drawing.Image)
        Me.exp_menu_save.Name = "exp_menu_save"
        Me.exp_menu_save.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_save.Text = "Speichern"
        '
        'exp_menu_saveas
        '
        Me.exp_menu_saveas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem35, Me.ToolStripMenuItem36, Me.ToolStripMenuItem37, Me.ToolStripMenuItem38})
        Me.exp_menu_saveas.Name = "exp_menu_saveas"
        Me.exp_menu_saveas.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_saveas.Text = "Speichern unter..."
        '
        'ToolStripMenuItem35
        '
        Me.ToolStripMenuItem35.Image = Global.Film_Info__Organizer.Toolbar16.Save_Filme
        Me.ToolStripMenuItem35.Name = "ToolStripMenuItem35"
        Me.ToolStripMenuItem35.Size = New System.Drawing.Size(240, 22)
        Me.ToolStripMenuItem35.Text = "Info.xml (Plugin Filme)"
        '
        'ToolStripMenuItem36
        '
        Me.ToolStripMenuItem36.Image = Global.Film_Info__Organizer.Toolbar16.Save_mymovies
        Me.ToolStripMenuItem36.Name = "ToolStripMenuItem36"
        Me.ToolStripMenuItem36.Size = New System.Drawing.Size(240, 22)
        Me.ToolStripMenuItem36.Text = "mymovies.xml (Media Browser)"
        '
        'ToolStripMenuItem37
        '
        Me.ToolStripMenuItem37.Image = Global.Film_Info__Organizer.Toolbar16.Save_xbmc
        Me.ToolStripMenuItem37.Name = "ToolStripMenuItem37"
        Me.ToolStripMenuItem37.Size = New System.Drawing.Size(240, 22)
        Me.ToolStripMenuItem37.Text = "movie.nfo (XBMC)"
        '
        'ToolStripMenuItem38
        '
        Me.ToolStripMenuItem38.Image = Global.Film_Info__Organizer.Toolbar16.save_windows
        Me.ToolStripMenuItem38.Name = "ToolStripMenuItem38"
        Me.ToolStripMenuItem38.Size = New System.Drawing.Size(240, 22)
        Me.ToolStripMenuItem38.Text = "movie.dvdid.xml (Windows)"
        '
        'exp_menu_backup
        '
        Me.exp_menu_backup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem59, Me.ToolStripMenuItem60, Me.ToolStripSeparator41, Me.ToolStripMenuItem61, Me.ToolStripSeparator55, Me.LöschenToolStripMenuItem3})
        Me.exp_menu_backup.Image = CType(resources.GetObject("exp_menu_backup.Image"), System.Drawing.Image)
        Me.exp_menu_backup.Name = "exp_menu_backup"
        Me.exp_menu_backup.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_backup.Text = "Sicherung"
        '
        'ToolStripMenuItem59
        '
        Me.ToolStripMenuItem59.Name = "ToolStripMenuItem59"
        Me.ToolStripMenuItem59.Size = New System.Drawing.Size(276, 22)
        Me.ToolStripMenuItem59.Text = "Sicherung erstellen"
        '
        'ToolStripMenuItem60
        '
        Me.ToolStripMenuItem60.Name = "ToolStripMenuItem60"
        Me.ToolStripMenuItem60.Size = New System.Drawing.Size(276, 22)
        Me.ToolStripMenuItem60.Text = "Sicherung erstellen und überschreiben"
        '
        'ToolStripSeparator41
        '
        Me.ToolStripSeparator41.Name = "ToolStripSeparator41"
        Me.ToolStripSeparator41.Size = New System.Drawing.Size(273, 6)
        '
        'ToolStripMenuItem61
        '
        Me.ToolStripMenuItem61.Name = "ToolStripMenuItem61"
        Me.ToolStripMenuItem61.Size = New System.Drawing.Size(276, 22)
        Me.ToolStripMenuItem61.Text = "Wiederherstellen"
        '
        'ToolStripSeparator55
        '
        Me.ToolStripSeparator55.Name = "ToolStripSeparator55"
        Me.ToolStripSeparator55.Size = New System.Drawing.Size(273, 6)
        '
        'LöschenToolStripMenuItem3
        '
        Me.LöschenToolStripMenuItem3.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.LöschenToolStripMenuItem3.Name = "LöschenToolStripMenuItem3"
        Me.LöschenToolStripMenuItem3.Size = New System.Drawing.Size(276, 22)
        Me.LöschenToolStripMenuItem3.Text = "Löschen"
        '
        'exp_menu_edit
        '
        Me.exp_menu_edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem62, Me.ToolStripMenuItem64, Me.ToolStripMenuItem63})
        Me.exp_menu_edit.Name = "exp_menu_edit"
        Me.exp_menu_edit.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_edit.Text = "Bearbeiten"
        '
        'ToolStripMenuItem62
        '
        Me.ToolStripMenuItem62.Name = "ToolStripMenuItem62"
        Me.ToolStripMenuItem62.Size = New System.Drawing.Size(254, 22)
        Me.ToolStripMenuItem62.Text = "Genre"
        '
        'ToolStripMenuItem64
        '
        Me.ToolStripMenuItem64.Name = "ToolStripMenuItem64"
        Me.ToolStripMenuItem64.Size = New System.Drawing.Size(254, 22)
        Me.ToolStripMenuItem64.Text = "MediaInfo"
        '
        'ToolStripMenuItem63
        '
        Me.ToolStripMenuItem63.Image = Global.Film_Info__Organizer.Toolbar16.Normal_hinzufuegen
        Me.ToolStripMenuItem63.Name = "ToolStripMenuItem63"
        Me.ToolStripMenuItem63.Size = New System.Drawing.Size(254, 22)
        Me.ToolStripMenuItem63.Text = "Ordner/Dateinamen umbenennen"
        '
        'exp_sep_file1
        '
        Me.exp_sep_file1.Name = "exp_sep_file1"
        Me.exp_sep_file1.Size = New System.Drawing.Size(225, 6)
        '
        'exp_menu_copy
        '
        Me.exp_menu_copy.Image = Global.Film_Info__Organizer.Toolbar16.ordner_copy
        Me.exp_menu_copy.Name = "exp_menu_copy"
        Me.exp_menu_copy.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_copy.Text = "Kopieren"
        '
        'exp_menu_cut
        '
        Me.exp_menu_cut.Image = Global.Film_Info__Organizer.Toolbar16.ordner_ausscheiden
        Me.exp_menu_cut.Name = "exp_menu_cut"
        Me.exp_menu_cut.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_cut.Text = "Ausscheiden"
        '
        'exp_menu_kopieren
        '
        Me.exp_menu_kopieren.Image = Global.Film_Info__Organizer.Toolbar16.Ordner_kopieren
        Me.exp_menu_kopieren.Name = "exp_menu_kopieren"
        Me.exp_menu_kopieren.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_kopieren.Text = "In Ordner kopieren..."
        '
        'exp_menu_verschieben
        '
        Me.exp_menu_verschieben.Image = Global.Film_Info__Organizer.Toolbar16.Ordner_verschieben
        Me.exp_menu_verschieben.Name = "exp_menu_verschieben"
        Me.exp_menu_verschieben.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_verschieben.Text = "In Ordner verschieben..."
        '
        'exp_menu_delet
        '
        Me.exp_menu_delet.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.exp_menu_delet.Name = "exp_menu_delet"
        Me.exp_menu_delet.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_delet.Text = "Löschen"
        '
        'exp_menu_sep_file_big
        '
        Me.exp_menu_sep_file_big._height = 8
        Me.exp_menu_sep_file_big._width = 0
        Me.exp_menu_sep_file_big.AutoSize = False
        Me.exp_menu_sep_file_big.Name = "exp_menu_sep_file_big"
        Me.exp_menu_sep_file_big.Size = New System.Drawing.Size(225, 8)
        '
        'ToolStripMenuItem65
        '
        Me.ToolStripMenuItem65.Image = CType(resources.GetObject("ToolStripMenuItem65.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem65.Name = "ToolStripMenuItem65"
        Me.ToolStripMenuItem65.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem65.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem65.Text = "Ordner laden..."
        Me.ToolStripMenuItem65.ToolTipText = "Ordner laden..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Laden Sie einen neuen Ordner und ersetzen sie dabei die bestehen" & _
    "de Liste."
        '
        'ToolStripMenuItem66
        '
        Me.ToolStripMenuItem66.Image = CType(resources.GetObject("ToolStripMenuItem66.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem66.Name = "ToolStripMenuItem66"
        Me.ToolStripMenuItem66.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem66.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem66.Text = "Ordner hinzufügen..."
        Me.ToolStripMenuItem66.ToolTipText = "Ordner hinzufügen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fügen Sie der Liste einen weiteren Ordner hinzu."
        '
        'ToolStripMenuItem67
        '
        Me.ToolStripMenuItem67.Image = CType(resources.GetObject("ToolStripMenuItem67.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem67.Name = "ToolStripMenuItem67"
        Me.ToolStripMenuItem67.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ToolStripMenuItem67.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem67.Text = "Aktualisieren"
        '
        'ToolStripMenuItem68
        '
        Me.ToolStripMenuItem68.Image = Global.Film_Info__Organizer.Toolbar16.folder_close
        Me.ToolStripMenuItem68.Name = "ToolStripMenuItem68"
        Me.ToolStripMenuItem68.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem68.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem68.Text = "Liste leeren"
        '
        'ToolStripSeparator36
        '
        Me.ToolStripSeparator36.Name = "ToolStripSeparator36"
        Me.ToolStripSeparator36.Size = New System.Drawing.Size(225, 6)
        '
        'LayoutToolStripMenuItem
        '
        Me.LayoutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem54, Me.WerkzeugleisteToolStripMenuItem1, Me.ToolStripMenuItem55, Me.ToolStripSeparator44, Me.Radio_NormaleWerkzeugleisteToolStripMenuItem, Me.Radio_DynamischeWerkzeugleisteToolStripMenuItem, Me.ToolStripSeparator40, Me.ToolStripMenuItem57, Me.ToolStripMenuItem56, Me.ToolStripSeparator57, Me.ToolStripMenuItem53})
        Me.LayoutToolStripMenuItem.Image = CType(resources.GetObject("LayoutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LayoutToolStripMenuItem.Name = "LayoutToolStripMenuItem"
        Me.LayoutToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.LayoutToolStripMenuItem.Text = "Layout"
        '
        'ToolStripMenuItem54
        '
        Me.ToolStripMenuItem54.Name = "ToolStripMenuItem54"
        Me.ToolStripMenuItem54.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem54.Text = "Menüleiste"
        '
        'WerkzeugleisteToolStripMenuItem1
        '
        Me.WerkzeugleisteToolStripMenuItem1.Name = "WerkzeugleisteToolStripMenuItem1"
        Me.WerkzeugleisteToolStripMenuItem1.Size = New System.Drawing.Size(221, 22)
        Me.WerkzeugleisteToolStripMenuItem1.Text = "Werkzeugleiste"
        '
        'ToolStripMenuItem55
        '
        Me.ToolStripMenuItem55.Name = "ToolStripMenuItem55"
        Me.ToolStripMenuItem55.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem55.Text = "Statusleiste"
        '
        'ToolStripSeparator44
        '
        Me.ToolStripSeparator44.Name = "ToolStripSeparator44"
        Me.ToolStripSeparator44.Size = New System.Drawing.Size(218, 6)
        '
        'Radio_NormaleWerkzeugleisteToolStripMenuItem
        '
        Me.Radio_NormaleWerkzeugleisteToolStripMenuItem.Name = "Radio_NormaleWerkzeugleisteToolStripMenuItem"
        Me.Radio_NormaleWerkzeugleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.Radio_NormaleWerkzeugleisteToolStripMenuItem.Text = "Normale Werkzeugleiste"
        '
        'Radio_DynamischeWerkzeugleisteToolStripMenuItem
        '
        Me.Radio_DynamischeWerkzeugleisteToolStripMenuItem.Name = "Radio_DynamischeWerkzeugleisteToolStripMenuItem"
        Me.Radio_DynamischeWerkzeugleisteToolStripMenuItem.Size = New System.Drawing.Size(221, 22)
        Me.Radio_DynamischeWerkzeugleisteToolStripMenuItem.Text = "Dynamische Werkzeugleiste"
        '
        'ToolStripSeparator40
        '
        Me.ToolStripSeparator40.Name = "ToolStripSeparator40"
        Me.ToolStripSeparator40.Size = New System.Drawing.Size(218, 6)
        '
        'ToolStripMenuItem57
        '
        Me.ToolStripMenuItem57.Name = "ToolStripMenuItem57"
        Me.ToolStripMenuItem57.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem57.Text = "Info!-Panel"
        '
        'ToolStripMenuItem56
        '
        Me.ToolStripMenuItem56.Name = "ToolStripMenuItem56"
        Me.ToolStripMenuItem56.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem56.Text = "Navigationsleiste"
        '
        'ToolStripSeparator57
        '
        Me.ToolStripSeparator57.Name = "ToolStripSeparator57"
        Me.ToolStripSeparator57.Size = New System.Drawing.Size(218, 6)
        '
        'ToolStripMenuItem53
        '
        Me.ToolStripMenuItem53.Image = Global.Film_Info__Organizer.Toolbar16.config
        Me.ToolStripMenuItem53.Name = "ToolStripMenuItem53"
        Me.ToolStripMenuItem53.Size = New System.Drawing.Size(221, 22)
        Me.ToolStripMenuItem53.Text = "Spalten"
        '
        'ToolStripMenuItem51
        '
        Me.ToolStripMenuItem51.Name = "ToolStripMenuItem51"
        Me.ToolStripMenuItem51.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem51.Text = "Optionen"
        '
        'ToolStripSeparator45
        '
        Me.ToolStripSeparator45.Name = "ToolStripSeparator45"
        Me.ToolStripSeparator45.Size = New System.Drawing.Size(225, 6)
        '
        'exp_menu_downloads
        '
        Me.exp_menu_downloads.Image = CType(resources.GetObject("exp_menu_downloads.Image"), System.Drawing.Image)
        Me.exp_menu_downloads.Name = "exp_menu_downloads"
        Me.exp_menu_downloads.Size = New System.Drawing.Size(228, 22)
        Me.exp_menu_downloads.Text = "Downloads"
        '
        'exp_dl_Fortschritt
        '
        Me.exp_dl_Fortschritt.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exp_dl_Fortschritt.Name = "exp_dl_Fortschritt"
        Me.exp_dl_Fortschritt.Size = New System.Drawing.Size(16, 15)
        Me.exp_dl_Fortschritt.Text = "..."
        Me.exp_dl_Fortschritt.Visible = False
        '
        'exp_dl_speed
        '
        Me.exp_dl_speed.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exp_dl_speed.Name = "exp_dl_speed"
        Me.exp_dl_speed.Size = New System.Drawing.Size(16, 15)
        Me.exp_dl_speed.Text = "..."
        Me.exp_dl_speed.Visible = False
        '
        'exp_dl_size
        '
        Me.exp_dl_size.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exp_dl_size.Name = "exp_dl_size"
        Me.exp_dl_size.Size = New System.Drawing.Size(16, 15)
        Me.exp_dl_size.Text = "..."
        Me.exp_dl_size.Visible = False
        '
        'exp_dl_time
        '
        Me.exp_dl_time.ForeColor = System.Drawing.SystemColors.GrayText
        Me.exp_dl_time.Name = "exp_dl_time"
        Me.exp_dl_time.Size = New System.Drawing.Size(16, 15)
        Me.exp_dl_time.Text = "..."
        Me.exp_dl_time.Visible = False
        '
        'ToolStripSeparator39
        '
        Me.ToolStripSeparator39.Name = "ToolStripSeparator39"
        Me.ToolStripSeparator39.Size = New System.Drawing.Size(225, 6)
        '
        'ToolStripSplitButton3
        '
        Me.ToolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem58, Me.ToolStripSeparator46, Me.ToolStripMenuItem69, Me.ToolStripMenuItem70, Me.ToolStripSeparator47, Me.ToolStripMenuItem71})
        Me.ToolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton3.Name = "ToolStripSplitButton3"
        Me.ToolStripSplitButton3.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripSplitButton3.Text = "Hilfe"
        '
        'ToolStripMenuItem58
        '
        Me.ToolStripMenuItem58.Name = "ToolStripMenuItem58"
        Me.ToolStripMenuItem58.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ToolStripMenuItem58.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem58.Text = "Hilfe..."
        '
        'ToolStripSeparator46
        '
        Me.ToolStripSeparator46.Name = "ToolStripSeparator46"
        Me.ToolStripSeparator46.Size = New System.Drawing.Size(155, 6)
        '
        'ToolStripMenuItem69
        '
        Me.ToolStripMenuItem69.Name = "ToolStripMenuItem69"
        Me.ToolStripMenuItem69.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem69.Text = "&Update..."
        '
        'ToolStripMenuItem70
        '
        Me.ToolStripMenuItem70.Name = "ToolStripMenuItem70"
        Me.ToolStripMenuItem70.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem70.Text = "Fehler melden..."
        '
        'ToolStripSeparator47
        '
        Me.ToolStripSeparator47.Name = "ToolStripSeparator47"
        Me.ToolStripSeparator47.Size = New System.Drawing.Size(155, 6)
        '
        'ToolStripMenuItem71
        '
        Me.ToolStripMenuItem71.Name = "ToolStripMenuItem71"
        Me.ToolStripMenuItem71.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuItem71.Text = "Über..."
        '
        'Exp_Öffnen_XP
        '
        Me.Exp_Öffnen_XP.AutoToolTip = False
        Me.Exp_Öffnen_XP.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem77, Me.ToolStripMenuItem52, Me.ToolStripSeparator56, Me.ToolStripMenuItem34})
        Me.Exp_Öffnen_XP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Öffnen_XP.Image = CType(resources.GetObject("Exp_Öffnen_XP.Image"), System.Drawing.Image)
        Me.Exp_Öffnen_XP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Öffnen_XP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Öffnen_XP.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Öffnen_XP.Name = "Exp_Öffnen_XP"
        Me.Exp_Öffnen_XP.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Öffnen_XP.Size = New System.Drawing.Size(94, 26)
        Me.Exp_Öffnen_XP.Text = "Öffnen..."
        Me.Exp_Öffnen_XP.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripMenuItem77
        '
        Me.ToolStripMenuItem77.Image = CType(resources.GetObject("ToolStripMenuItem77.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem77.Name = "ToolStripMenuItem77"
        Me.ToolStripMenuItem77.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem77.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem77.Text = "Ordner laden..."
        Me.ToolStripMenuItem77.ToolTipText = "Ordner laden..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Laden Sie einen neuen Ordner und ersetzen sie dabei die bestehen" & _
    "de Liste."
        '
        'ToolStripMenuItem52
        '
        Me.ToolStripMenuItem52.Image = CType(resources.GetObject("ToolStripMenuItem52.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem52.Name = "ToolStripMenuItem52"
        Me.ToolStripMenuItem52.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem52.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem52.Text = "Ordner hinzufügen..."
        Me.ToolStripMenuItem52.ToolTipText = "Ordner hinzufügen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fügen Sie der Liste einen weiteren Ordner hinzu."
        '
        'ToolStripSeparator56
        '
        Me.ToolStripSeparator56.Name = "ToolStripSeparator56"
        Me.ToolStripSeparator56.Size = New System.Drawing.Size(225, 6)
        '
        'ToolStripMenuItem34
        '
        Me.ToolStripMenuItem34.Image = Global.Film_Info__Organizer.Toolbar16.folder_close
        Me.ToolStripMenuItem34.Name = "ToolStripMenuItem34"
        Me.ToolStripMenuItem34.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ToolStripMenuItem34.Size = New System.Drawing.Size(228, 22)
        Me.ToolStripMenuItem34.Text = "Liste leeren"
        '
        'Exp_Öffnen_better
        '
        Me.Exp_Öffnen_better.AutoToolTip = False
        Me.Exp_Öffnen_better.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Öffnen_better.Image = CType(resources.GetObject("Exp_Öffnen_better.Image"), System.Drawing.Image)
        Me.Exp_Öffnen_better.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Öffnen_better.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Öffnen_better.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Öffnen_better.Name = "Exp_Öffnen_better"
        Me.Exp_Öffnen_better.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Öffnen_better.Size = New System.Drawing.Size(85, 26)
        Me.Exp_Öffnen_better.Text = "Öffnen..."
        Me.Exp_Öffnen_better.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'exp_sep
        '
        Me.exp_sep._height = 0
        Me.exp_sep._width = 8
        Me.exp_sep.AutoSize = False
        Me.exp_sep.Name = "exp_sep"
        Me.exp_sep.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_sep.Size = New System.Drawing.Size(8, 32)
        '
        'Exp_Play
        '
        Me.Exp_Play.AutoToolTip = False
        Me.Exp_Play.DropDownButtonWidth = 16
        Me.Exp_Play.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WiedergebenToolStripMenuItem, Me.TrailerWiedergebenToolStripMenuItem, Me.ToolStripSeparator42, Me.ToolStripMenuItem50, Me.OrdnerpfadÖffnenToolStripMenuItem})
        Me.Exp_Play.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Play.Image = Global.Film_Info__Organizer.Toolbar16.Play
        Me.Exp_Play.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Play.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Play.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Play.Name = "Exp_Play"
        Me.Exp_Play.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Play.Size = New System.Drawing.Size(119, 26)
        Me.Exp_Play.Text = "Wiedergabe"
        Me.Exp_Play.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Play.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'WiedergebenToolStripMenuItem
        '
        Me.WiedergebenToolStripMenuItem.Name = "WiedergebenToolStripMenuItem"
        Me.WiedergebenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.WiedergebenToolStripMenuItem.Text = "Wiedergabe"
        '
        'TrailerWiedergebenToolStripMenuItem
        '
        Me.TrailerWiedergebenToolStripMenuItem.Name = "TrailerWiedergebenToolStripMenuItem"
        Me.TrailerWiedergebenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.TrailerWiedergebenToolStripMenuItem.Text = "Trailer wiedergeben"
        '
        'ToolStripSeparator42
        '
        Me.ToolStripSeparator42.Name = "ToolStripSeparator42"
        Me.ToolStripSeparator42.Size = New System.Drawing.Size(175, 6)
        '
        'ToolStripMenuItem50
        '
        Me.ToolStripMenuItem50.Image = Global.Film_Info__Organizer.Toolbar16.Normal_durchsuchen
        Me.ToolStripMenuItem50.Name = "ToolStripMenuItem50"
        Me.ToolStripMenuItem50.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem50.Text = "Dateipfad öffnen"
        '
        'OrdnerpfadÖffnenToolStripMenuItem
        '
        Me.OrdnerpfadÖffnenToolStripMenuItem.Name = "OrdnerpfadÖffnenToolStripMenuItem"
        Me.OrdnerpfadÖffnenToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.OrdnerpfadÖffnenToolStripMenuItem.Text = "Ordnerpfad öffnen"
        '
        'Exp_Abrufen
        '
        Me.Exp_Abrufen.AutoToolTip = False
        Me.Exp_Abrufen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Exp_Abrufen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem33, Me.ToolStripMenuItem45, Me.ToolStripMenuItem46, Me.OptionenToolStripMenuItem2, Me.ToolStripSeparator37, Me.ToolStripMenuItem44, Me.ToolStripMenuItem47, Me.ToolStripMenuItem48, Me.DarstellerbilderToolStripMenuItem, Me.TrailerLadenToolStripMenuItem1, Me.ToolStripSeparator38, Me.ToolStripMenuItem49})
        Me.Exp_Abrufen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Abrufen.Image = CType(resources.GetObject("Exp_Abrufen.Image"), System.Drawing.Image)
        Me.Exp_Abrufen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Abrufen.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Abrufen.Name = "Exp_Abrufen"
        Me.Exp_Abrufen.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Abrufen.Size = New System.Drawing.Size(75, 26)
        Me.Exp_Abrufen.Text = "Abrufen"
        Me.Exp_Abrufen.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'ToolStripMenuItem33
        '
        Me.ToolStripMenuItem33.Image = CType(resources.GetObject("ToolStripMenuItem33.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem33.Name = "ToolStripMenuItem33"
        Me.ToolStripMenuItem33.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem33.Text = "Schnelle Suche"
        '
        'ToolStripMenuItem45
        '
        Me.ToolStripMenuItem45.Image = CType(resources.GetObject("ToolStripMenuItem45.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem45.Name = "ToolStripMenuItem45"
        Me.ToolStripMenuItem45.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem45.Text = "Normale Suche"
        '
        'ToolStripMenuItem46
        '
        Me.ToolStripMenuItem46.Image = CType(resources.GetObject("ToolStripMenuItem46.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem46.Name = "ToolStripMenuItem46"
        Me.ToolStripMenuItem46.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem46.Text = "Ausführliche Suche"
        '
        'OptionenToolStripMenuItem2
        '
        Me.OptionenToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem76, Me.ToolStripMenuItem79})
        Me.OptionenToolStripMenuItem2.Name = "OptionenToolStripMenuItem2"
        Me.OptionenToolStripMenuItem2.Size = New System.Drawing.Size(176, 22)
        Me.OptionenToolStripMenuItem2.Text = "Erweitert"
        '
        'ToolStripMenuItem76
        '
        Me.ToolStripMenuItem76.Checked = True
        Me.ToolStripMenuItem76.CheckOnClick = True
        Me.ToolStripMenuItem76.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ToolStripMenuItem76.Name = "ToolStripMenuItem76"
        Me.ToolStripMenuItem76.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem76.Text = "IMDb-ID verwenden"
        '
        'ToolStripMenuItem79
        '
        Me.ToolStripMenuItem79.Name = "ToolStripMenuItem79"
        Me.ToolStripMenuItem79.Size = New System.Drawing.Size(180, 22)
        Me.ToolStripMenuItem79.Text = "Genre"
        '
        'ToolStripSeparator37
        '
        Me.ToolStripSeparator37.Name = "ToolStripSeparator37"
        Me.ToolStripSeparator37.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItem44
        '
        Me.ToolStripMenuItem44.Image = CType(resources.GetObject("ToolStripMenuItem44.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem44.Name = "ToolStripMenuItem44"
        Me.ToolStripMenuItem44.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem44.Text = "Cover und Fanart"
        '
        'ToolStripMenuItem47
        '
        Me.ToolStripMenuItem47.Image = CType(resources.GetObject("ToolStripMenuItem47.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem47.Name = "ToolStripMenuItem47"
        Me.ToolStripMenuItem47.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem47.Text = "Automatisch"
        '
        'ToolStripMenuItem48
        '
        Me.ToolStripMenuItem48.Name = "ToolStripMenuItem48"
        Me.ToolStripMenuItem48.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem48.Text = "Thumbnail-Creator"
        '
        'DarstellerbilderToolStripMenuItem
        '
        Me.DarstellerbilderToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.darsteller
        Me.DarstellerbilderToolStripMenuItem.Name = "DarstellerbilderToolStripMenuItem"
        Me.DarstellerbilderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DarstellerbilderToolStripMenuItem.Text = "Darstellerbilder"
        '
        'TrailerLadenToolStripMenuItem1
        '
        Me.TrailerLadenToolStripMenuItem1.Name = "TrailerLadenToolStripMenuItem1"
        Me.TrailerLadenToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.TrailerLadenToolStripMenuItem1.Text = "Trailer laden"
        '
        'ToolStripSeparator38
        '
        Me.ToolStripSeparator38.Name = "ToolStripSeparator38"
        Me.ToolStripSeparator38.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItem49
        '
        Me.ToolStripMenuItem49.Image = CType(resources.GetObject("ToolStripMenuItem49.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem49.Name = "ToolStripMenuItem49"
        Me.ToolStripMenuItem49.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem49.Text = "Media Info"
        Me.ToolStripMenuItem49.ToolTipText = "Media Info anzeigen..." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Zeigt alle Informationen zur Film-Datei."
        '
        'exp_speichern
        '
        Me.exp_speichern.AutoToolTip = False
        Me.exp_speichern.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.exp_speichern.Image = CType(resources.GetObject("exp_speichern.Image"), System.Drawing.Image)
        Me.exp_speichern.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.exp_speichern.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exp_speichern.Margin = New System.Windows.Forms.Padding(3)
        Me.exp_speichern.Name = "exp_speichern"
        Me.exp_speichern.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_speichern.Size = New System.Drawing.Size(91, 26)
        Me.exp_speichern.Text = "Speichern"
        Me.exp_speichern.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'Exp_MediaInfo
        '
        Me.Exp_MediaInfo.AutoToolTip = False
        Me.Exp_MediaInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_MediaInfo.Image = CType(resources.GetObject("Exp_MediaInfo.Image"), System.Drawing.Image)
        Me.Exp_MediaInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_MediaInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_MediaInfo.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_MediaInfo.Name = "Exp_MediaInfo"
        Me.Exp_MediaInfo.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_MediaInfo.Size = New System.Drawing.Size(93, 26)
        Me.Exp_MediaInfo.Text = "MediaInfo"
        Me.Exp_MediaInfo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'Exp_Rename
        '
        Me.Exp_Rename.AutoToolTip = False
        Me.Exp_Rename.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Exp_Rename.Image = CType(resources.GetObject("Exp_Rename.Image"), System.Drawing.Image)
        Me.Exp_Rename.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Exp_Rename.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Exp_Rename.Margin = New System.Windows.Forms.Padding(3)
        Me.Exp_Rename.Name = "Exp_Rename"
        Me.Exp_Rename.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.Exp_Rename.Size = New System.Drawing.Size(111, 26)
        Me.Exp_Rename.Text = "Umbenennen"
        '
        'exp_InfoPanel
        '
        Me.exp_InfoPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.exp_InfoPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.exp_InfoPanel.Image = CType(resources.GetObject("exp_InfoPanel.Image"), System.Drawing.Image)
        Me.exp_InfoPanel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exp_InfoPanel.Margin = New System.Windows.Forms.Padding(3)
        Me.exp_InfoPanel.Name = "exp_InfoPanel"
        Me.exp_InfoPanel.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_InfoPanel.Size = New System.Drawing.Size(32, 26)
        Me.exp_InfoPanel.Text = "Info!-Panel anzeigen"
        '
        'ToolStripSeparator49
        '
        Me.ToolStripSeparator49._height = 0
        Me.ToolStripSeparator49._width = 8
        Me.ToolStripSeparator49.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator49.AutoSize = False
        Me.ToolStripSeparator49.Name = "ToolStripSeparator49"
        Me.ToolStripSeparator49.Size = New System.Drawing.Size(8, 32)
        Me.ToolStripSeparator49.Visible = False
        '
        'exp_Downloads
        '
        Me.exp_Downloads.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.exp_Downloads.AutoToolTip = False
        Me.exp_Downloads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.exp_Downloads.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.exp_Downloads.Image = CType(resources.GetObject("exp_Downloads.Image"), System.Drawing.Image)
        Me.exp_Downloads.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.exp_Downloads.Margin = New System.Windows.Forms.Padding(3)
        Me.exp_Downloads.Name = "exp_Downloads"
        Me.exp_Downloads.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.exp_Downloads.Size = New System.Drawing.Size(32, 26)
        Me.exp_Downloads.Text = "Downloads"
        Me.exp_Downloads.Visible = False
        '
        'ToPanelTimer
        '
        '
        'Toolbar_Timer
        '
        '
        'DataGridViewFlagColumn1
        '
        Me.DataGridViewFlagColumn1.FillWeight = 30.0!
        Me.DataGridViewFlagColumn1.HeaderText = "Flags"
        Me.DataGridViewFlagColumn1.MinimumWidth = 16
        Me.DataGridViewFlagColumn1.Name = "DataGridViewFlagColumn1"
        Me.DataGridViewFlagColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewFlagColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewFlagColumn1.Width = 30
        '
        'DataGridViewProgressColumn1
        '
        Me.DataGridViewProgressColumn1.HeaderText = "Fortschritt (%)"
        Me.DataGridViewProgressColumn1.Name = "DataGridViewProgressColumn1"
        Me.DataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressColumn1.Width = 60
        '
        'DataGridViewRateColumn1
        '
        Me.DataGridViewRateColumn1.HeaderText = "Cover (Status)"
        Me.DataGridViewRateColumn1.MinimumWidth = 16
        Me.DataGridViewRateColumn1.Name = "DataGridViewRateColumn1"
        Me.DataGridViewRateColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn1.Width = 30
        '
        'DataGridViewRateColumn2
        '
        Me.DataGridViewRateColumn2.HeaderText = "Backdrops  (Status)"
        Me.DataGridViewRateColumn2.MinimumWidth = 16
        Me.DataGridViewRateColumn2.Name = "DataGridViewRateColumn2"
        Me.DataGridViewRateColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn2.Width = 30
        '
        'DataGridViewRateColumn3
        '
        Me.DataGridViewRateColumn3.HeaderText = "Info (Status)"
        Me.DataGridViewRateColumn3.MinimumWidth = 16
        Me.DataGridViewRateColumn3.Name = "DataGridViewRateColumn3"
        Me.DataGridViewRateColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn3.Width = 30
        '
        'DataGridViewRateColumn4
        '
        Me.DataGridViewRateColumn4.HeaderText = "Media Info (Status)"
        Me.DataGridViewRateColumn4.MinimumWidth = 16
        Me.DataGridViewRateColumn4.Name = "DataGridViewRateColumn4"
        Me.DataGridViewRateColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn4.Width = 30
        '
        'DataGridViewRateColumn5
        '
        Me.DataGridViewRateColumn5.HeaderText = "Ordner (Status)"
        Me.DataGridViewRateColumn5.MinimumWidth = 16
        Me.DataGridViewRateColumn5.Name = "DataGridViewRateColumn5"
        Me.DataGridViewRateColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn5.Width = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Pfad"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ordner"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Titel"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 400
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Originaltitel"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 31
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "IMDB_ID"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 31
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn6.HeaderText = "Darsteller"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 32
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Regie"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        Me.DataGridViewTextBoxColumn7.Width = 31
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Autoren"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 31
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Studios"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Visible = False
        Me.DataGridViewTextBoxColumn9.Width = 32
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Jahr"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 31
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Land"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        Me.DataGridViewTextBoxColumn11.Width = 31
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Genre"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 32
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = "FSK"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 31
        '
        'DataGridViewTextBoxColumn14
        '
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "1,00"
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn14.HeaderText = "Bewertung"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        Me.DataGridViewTextBoxColumn14.Width = 31
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Dauer"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        Me.DataGridViewTextBoxColumn15.Width = 31
        '
        'DataGridViewTextBoxColumn16
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle23
        Me.DataGridViewTextBoxColumn16.HeaderText = "Kurzbeschreibung"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Visible = False
        Me.DataGridViewTextBoxColumn16.Width = 32
        '
        'DataGridViewTextBoxColumn17
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle24
        Me.DataGridViewTextBoxColumn17.HeaderText = "Inhalt"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        Me.DataGridViewTextBoxColumn17.Width = 31
        '
        'DataGridViewTextBoxColumn18
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn18.DefaultCellStyle = DataGridViewCellStyle25
        Me.DataGridViewTextBoxColumn18.HeaderText = "Media Info"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Visible = False
        Me.DataGridViewTextBoxColumn18.Width = 31
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.HeaderText = "Position"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.HeaderText = "Datum"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Visible = False
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.HeaderText = "Sortierung"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.HeaderText = "Auflösung"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Visible = False
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.HeaderText = "Seitenverhältnis"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Visible = False
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.HeaderText = "Framerate"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.Visible = False
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.HeaderText = "Video-Codec"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.Visible = False
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.HeaderText = "Audio-Kanäle"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.Visible = False
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.HeaderText = "Audio-Codec"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        Me.DataGridViewTextBoxColumn27.Visible = False
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.HeaderText = "Sprache"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        Me.DataGridViewTextBoxColumn28.Visible = False
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.HeaderText = "Dateien"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewSizeColumn1
        '
        Me.DataGridViewSizeColumn1.HeaderText = "Ordnergröße"
        Me.DataGridViewSizeColumn1.Name = "DataGridViewSizeColumn1"
        Me.DataGridViewSizeColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.FillWeight = 127.1766!
        Me.DataGridViewTextBoxColumn30.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        Me.DataGridViewTextBoxColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn30.Width = 146
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.FillWeight = 127.1766!
        Me.DataGridViewTextBoxColumn31.HeaderText = "Rolle"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        Me.DataGridViewTextBoxColumn31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn31.Width = 146
        '
        'DataGridViewProgressColumn2
        '
        Me.DataGridViewProgressColumn2.HeaderText = "%"
        Me.DataGridViewProgressColumn2.Name = "DataGridViewProgressColumn2"
        Me.DataGridViewProgressColumn2.ReadOnly = True
        Me.DataGridViewProgressColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressColumn2.Width = 60
        '
        'DataGridViewRateColumn6
        '
        Me.DataGridViewRateColumn6.HeaderText = "Backdrops"
        Me.DataGridViewRateColumn6.MinimumWidth = 16
        Me.DataGridViewRateColumn6.Name = "DataGridViewRateColumn6"
        Me.DataGridViewRateColumn6.ReadOnly = True
        Me.DataGridViewRateColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn6.Width = 30
        '
        'DataGridViewRateColumn7
        '
        Me.DataGridViewRateColumn7.HeaderText = "Info"
        Me.DataGridViewRateColumn7.MinimumWidth = 16
        Me.DataGridViewRateColumn7.Name = "DataGridViewRateColumn7"
        Me.DataGridViewRateColumn7.ReadOnly = True
        Me.DataGridViewRateColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn7.Width = 30
        '
        'DataGridViewRateColumn8
        '
        Me.DataGridViewRateColumn8.HeaderText = "Media Info"
        Me.DataGridViewRateColumn8.MinimumWidth = 16
        Me.DataGridViewRateColumn8.Name = "DataGridViewRateColumn8"
        Me.DataGridViewRateColumn8.ReadOnly = True
        Me.DataGridViewRateColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn8.Width = 30
        '
        'DataGridViewProgressColumn3
        '
        Me.DataGridViewProgressColumn3.HeaderText = "%"
        Me.DataGridViewProgressColumn3.Name = "DataGridViewProgressColumn3"
        Me.DataGridViewProgressColumn3.ReadOnly = True
        Me.DataGridViewProgressColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressColumn3.Width = 60
        '
        'DataGridViewRateColumn9
        '
        Me.DataGridViewRateColumn9.HeaderText = "Cover"
        Me.DataGridViewRateColumn9.MinimumWidth = 16
        Me.DataGridViewRateColumn9.Name = "DataGridViewRateColumn9"
        Me.DataGridViewRateColumn9.ReadOnly = True
        Me.DataGridViewRateColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn9.Width = 30
        '
        'DataGridViewRateColumn10
        '
        Me.DataGridViewRateColumn10.HeaderText = "Backdrops"
        Me.DataGridViewRateColumn10.MinimumWidth = 16
        Me.DataGridViewRateColumn10.Name = "DataGridViewRateColumn10"
        Me.DataGridViewRateColumn10.ReadOnly = True
        Me.DataGridViewRateColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn10.Width = 30
        '
        'DataGridViewRateColumn11
        '
        Me.DataGridViewRateColumn11.HeaderText = "Info"
        Me.DataGridViewRateColumn11.MinimumWidth = 16
        Me.DataGridViewRateColumn11.Name = "DataGridViewRateColumn11"
        Me.DataGridViewRateColumn11.ReadOnly = True
        Me.DataGridViewRateColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn11.Width = 30
        '
        'DataGridViewRateColumn12
        '
        Me.DataGridViewRateColumn12.HeaderText = "Media Info"
        Me.DataGridViewRateColumn12.MinimumWidth = 16
        Me.DataGridViewRateColumn12.Name = "DataGridViewRateColumn12"
        Me.DataGridViewRateColumn12.ReadOnly = True
        Me.DataGridViewRateColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn12.Width = 30
        '
        'DataGridViewProgressColumn4
        '
        Me.DataGridViewProgressColumn4.HeaderText = "%"
        Me.DataGridViewProgressColumn4.Name = "DataGridViewProgressColumn4"
        Me.DataGridViewProgressColumn4.ReadOnly = True
        Me.DataGridViewProgressColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressColumn4.Width = 60
        '
        'DataGridViewRateColumn13
        '
        Me.DataGridViewRateColumn13.HeaderText = "Cover"
        Me.DataGridViewRateColumn13.MinimumWidth = 16
        Me.DataGridViewRateColumn13.Name = "DataGridViewRateColumn13"
        Me.DataGridViewRateColumn13.ReadOnly = True
        Me.DataGridViewRateColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn13.Width = 30
        '
        'DataGridViewRateColumn14
        '
        Me.DataGridViewRateColumn14.HeaderText = "Backdrops"
        Me.DataGridViewRateColumn14.MinimumWidth = 16
        Me.DataGridViewRateColumn14.Name = "DataGridViewRateColumn14"
        Me.DataGridViewRateColumn14.ReadOnly = True
        Me.DataGridViewRateColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn14.Width = 30
        '
        'DataGridViewRateColumn15
        '
        Me.DataGridViewRateColumn15.HeaderText = "Info"
        Me.DataGridViewRateColumn15.MinimumWidth = 16
        Me.DataGridViewRateColumn15.Name = "DataGridViewRateColumn15"
        Me.DataGridViewRateColumn15.ReadOnly = True
        Me.DataGridViewRateColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn15.Width = 30
        '
        'DataGridViewRateColumn16
        '
        Me.DataGridViewRateColumn16.HeaderText = "Media Info"
        Me.DataGridViewRateColumn16.MinimumWidth = 16
        Me.DataGridViewRateColumn16.Name = "DataGridViewRateColumn16"
        Me.DataGridViewRateColumn16.ReadOnly = True
        Me.DataGridViewRateColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn16.Width = 30
        '
        'DataGridViewProgressColumn5
        '
        Me.DataGridViewProgressColumn5.HeaderText = "%"
        Me.DataGridViewProgressColumn5.Name = "DataGridViewProgressColumn5"
        Me.DataGridViewProgressColumn5.ReadOnly = True
        Me.DataGridViewProgressColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewProgressColumn5.Width = 60
        '
        'DataGridViewRateColumn17
        '
        Me.DataGridViewRateColumn17.HeaderText = "Cover"
        Me.DataGridViewRateColumn17.MinimumWidth = 16
        Me.DataGridViewRateColumn17.Name = "DataGridViewRateColumn17"
        Me.DataGridViewRateColumn17.ReadOnly = True
        Me.DataGridViewRateColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn17.Width = 30
        '
        'DataGridViewRateColumn18
        '
        Me.DataGridViewRateColumn18.HeaderText = "Backdrops"
        Me.DataGridViewRateColumn18.MinimumWidth = 16
        Me.DataGridViewRateColumn18.Name = "DataGridViewRateColumn18"
        Me.DataGridViewRateColumn18.ReadOnly = True
        Me.DataGridViewRateColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn18.Width = 30
        '
        'DataGridViewRateColumn19
        '
        Me.DataGridViewRateColumn19.HeaderText = "Info"
        Me.DataGridViewRateColumn19.MinimumWidth = 16
        Me.DataGridViewRateColumn19.Name = "DataGridViewRateColumn19"
        Me.DataGridViewRateColumn19.ReadOnly = True
        Me.DataGridViewRateColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn19.Width = 30
        '
        'DataGridViewRateColumn20
        '
        Me.DataGridViewRateColumn20.HeaderText = "Media Info"
        Me.DataGridViewRateColumn20.MinimumWidth = 16
        Me.DataGridViewRateColumn20.Name = "DataGridViewRateColumn20"
        Me.DataGridViewRateColumn20.ReadOnly = True
        Me.DataGridViewRateColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRateColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewRateColumn20.Width = 30
        '
        'DataGridViewStatusColumn1
        '
        Me.DataGridViewStatusColumn1.Frozen = True
        Me.DataGridViewStatusColumn1.HeaderText = ""
        Me.DataGridViewStatusColumn1.MinimumWidth = 32
        Me.DataGridViewStatusColumn1.Name = "DataGridViewStatusColumn1"
        Me.DataGridViewStatusColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewStatusColumn1.Visible = False
        Me.DataGridViewStatusColumn1.Width = 32
        '
        'DataGridViewImageColumn1
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.NullValue = ".Resources.no_cover_bg"
        Me.DataGridViewImageColumn1.DefaultCellStyle = DataGridViewCellStyle26
        Me.DataGridViewImageColumn1.Frozen = True
        Me.DataGridViewImageColumn1.HeaderText = "Cover"
        Me.DataGridViewImageColumn1.Image = CType(resources.GetObject("DataGridViewImageColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Visible = False
        Me.DataGridViewImageColumn1.Width = 31
        '
        'MyStatusStrip
        '
        Me.MyStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel_Browser, Me.Count_size, Me.Count_Movies})
        Me.MyStatusStrip.Location = New System.Drawing.Point(0, 606)
        Me.MyStatusStrip.Name = "MyStatusStrip"
        Me.MyStatusStrip.Size = New System.Drawing.Size(1096, 22)
        Me.MyStatusStrip.TabIndex = 16
        Me.MyStatusStrip.Text = "StatusStrip1"
        '
        'StatusLabel_Browser
        '
        Me.StatusLabel_Browser.AutoSize = False
        Me.StatusLabel_Browser.BackColor = System.Drawing.Color.Transparent
        Me.StatusLabel_Browser.Name = "StatusLabel_Browser"
        Me.StatusLabel_Browser.Size = New System.Drawing.Size(1081, 17)
        Me.StatusLabel_Browser.Spring = True
        Me.StatusLabel_Browser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Count_size
        '
        Me.Count_size.BackColor = System.Drawing.Color.Transparent
        Me.Count_size.Name = "Count_size"
        Me.Count_size.Size = New System.Drawing.Size(0, 17)
        Me.Count_size.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Count_Movies
        '
        Me.Count_Movies.BackColor = System.Drawing.Color.Transparent
        Me.Count_Movies.Name = "Count_Movies"
        Me.Count_Movies.Size = New System.Drawing.Size(0, 17)
        Me.Count_Movies.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ContextMenu_BoxSets
        '
        Me.ContextMenu_BoxSets.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem12})
        Me.ContextMenu_BoxSets.Name = "ContextMenu_Export"
        Me.ContextMenu_BoxSets.Size = New System.Drawing.Size(166, 26)
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(165, 22)
        Me.ToolStripMenuItem12.Text = "BoxSet erstellen..."
        '
        'MForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1096, 628)
        Me.Controls.Add(Me.Panel_Update)
        Me.Controls.Add(Me.Panel_Update_more)
        Me.Controls.Add(Me.SplitContainer_treepanel)
        Me.Controls.Add(Me.Nov_Main)
        Me.Controls.Add(Me.Nov_Main_alt)
        Me.Controls.Add(Me.Nav_Menu)
        Me.Controls.Add(Me.MyStatusStrip)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MForm"
        Me.Text = "Film Info! Organizer"
        Me.Nov_Main.ResumeLayout(False)
        Me.Nov_Main.PerformLayout()
        Me.ContextMenu_Export.ResumeLayout(False)
        Me.DropDownMenu_Suche.ResumeLayout(False)
        Me.DropDownMenu_Cover.ResumeLayout(False)
        Me.DropDown_Trailer.ResumeLayout(False)
        Me.Nav_Menu.ResumeLayout(False)
        Me.Nav_Menu.PerformLayout()
        Me.ContextMenu_Sammlung.ResumeLayout(False)
        Me.ContextMenu_Sammlung.PerformLayout()
        Me.ContextMenu_Flags.ResumeLayout(False)
        Me.ContextMenu_TextBox.ResumeLayout(False)
        Me.ContextMenu_Cover.ResumeLayout(False)
        Me.ContextMenu_Overwrite.ResumeLayout(False)
        Me.Nav_Treeview.ResumeLayout(False)
        Me.Nav_Treeview.PerformLayout()
        Me.SplitContainer_treepanel.Panel1.ResumeLayout(False)
        Me.SplitContainer_treepanel.Panel1.PerformLayout()
        Me.SplitContainer_treepanel.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_treepanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_treepanel.ResumeLayout(False)
        Me.Panel_treepadding.ResumeLayout(False)
        Me.Download_Panel.ResumeLayout(False)
        Me.Download_Panel.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.Nav_Download.ResumeLayout(False)
        Me.Nav_Download.PerformLayout()
        Me.SplitContainer_Infopanel.Panel1.ResumeLayout(False)
        Me.SplitContainer_Infopanel.Panel1.PerformLayout()
        Me.SplitContainer_Infopanel.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer_Infopanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer_Infopanel.ResumeLayout(False)
        Me.Panel_Overlay_useImage.ResumeLayout(False)
        Me.Panel_Overlay_useImage.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.Panel_q_Trailer.ResumeLayout(False)
        Me.Panel_q_Trailer.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel_flagquestion.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.Panel_ask_selectmovie.ResumeLayout(False)
        Me.Panel_ask_selectmovie.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.Movie_GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Nov_line_browser.ResumeLayout(False)
        Me.Nov_line_browser.PerformLayout()
        Me.Nav_Datagrid.ResumeLayout(False)
        Me.Nav_Datagrid.PerformLayout()
        Me.MyBrowserHelpbar.ResumeLayout(False)
        Me.MyBrowserHelpbar.PerformLayout()
        Me.ContextMenuStrip_Textbox_Genre.ResumeLayout(False)
        Me.ContextMenu_Rows.ResumeLayout(False)
        Me.ContextMenu_Columns.ResumeLayout(False)
        Me.Panel_Update.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Update_more.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Nov_Main_alt.ResumeLayout(False)
        Me.Nov_Main_alt.PerformLayout()
        Me.MyStatusStrip.ResumeLayout(False)
        Me.MyStatusStrip.PerformLayout()
        Me.ContextMenu_BoxSets.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Movie_GridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewStatusColumn1 As Film_Info__Organizer.DataGridViewStatusColumn
    Friend WithEvents TreeviewImagelist As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SpeichernToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tool_Speichern As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SpeichernToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernAlsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DVDInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents XBMCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilmePluginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediaBrowserToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer_Infopanel As System.Windows.Forms.SplitContainer
    Friend WithEvents Nav_Treeview As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridViewProgressColumn1 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents Infobaranzeigen_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Speichern_Tool As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoxmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MymoviesxmlToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MediaInfo_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip_Suche As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Cover_Tool As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents openselfolder_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Apspielen_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ordnerladen_Tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ordnerhinzufügen_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents refresh_tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Listeleeren_Tool As System.Windows.Forms.ToolStripButton
    Friend WithEvents Einstellungen_Tool As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Nav_Menu As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMainItem_Datei As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Speichern As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Speichern_unter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Exportieren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OrdnerLadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerhinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menutool_listeleeren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMainItem_Bearbeiten As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_CoverFanart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_CoverFanartauto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMainItem_Info As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_MediaInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Abspielen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Ordnerdurchsuchen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMainItem_Extras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpaltenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMainItem_Hilfe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HilfeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FehlerMeldenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nav_Datagrid As System.Windows.Forms.ToolStrip
    Friend WithEvents UpdateToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpaltenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenüleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MovienfoXBMCToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoviedvdidxmlWindowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton_Add_Fav As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabImages As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripButton_del_fav As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer_treepanel As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripButton_Downloads As System.Windows.Forms.ToolStripButton
    Friend WithEvents Nov_Main As System.Windows.Forms.ToolStrip
    Friend WithEvents MyToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents Radio_AutomatischToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_ErgänzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_ErsetzenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_BenutzerdefiniertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Titel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Originaltitel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OverwriteMenuItem_Sort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Produktionsjahr As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_IMDB_ID As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Bewertung As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_FSK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Studios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Genre As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Regisseur As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Produktionsland As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Autoren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Darsteller As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OverwriteMenuItem_Inhalt As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ContextMenu_Overwrite As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OrdnerUmbenennenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nov_line_browser As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MyBrowser_Favicon As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MyBrowser_Close As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ContextMenu_TextBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RückgäningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SuchenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewRateColumn1 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn2 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn3 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn4 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewProgressColumn2 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents DataGridViewRateColumn5 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn6 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn7 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn8 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewProgressColumn3 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents DataGridViewRateColumn9 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn10 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn11 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn12 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewProgressColumn4 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents DataGridViewRateColumn13 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn14 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn15 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn16 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewProgressColumn5 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents DataGridViewRateColumn17 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn18 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn19 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents DataGridViewRateColumn20 As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents ContextMenu_Cover As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GoogleToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoviemazeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinfügenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenu_Rows As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MediaInfoAbrufenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator17 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbspielenToolStripContextitem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerDurchsuchenToolStripcontextitem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_Columns As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SpaltenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BackgroundDownloader As System.ComponentModel.BackgroundWorker
    Friend WithEvents MyBrowserHelpbar As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LöschenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_flagquestion As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewFlagColumn1 As Film_Info__Organizer.DataGridViewFlagColumn
    Friend WithEvents ToolStripSeparator19 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NavigationsleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoPanelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FeldBearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenreHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Download_Panel As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Download_Info_Restzeit As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Download_info_Absolut As System.Windows.Forms.Label
    Friend WithEvents Download_info_Geladen As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Download_info_Prozent As System.Windows.Forms.Label
    Friend WithEvents Download_info_Speed As System.Windows.Forms.Label
    Friend WithEvents Nav_Download As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Download_anzeige_change As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents FortschrittToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GeschwindigkeitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestzeitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatenmengeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadStartenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadAbbrechenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListeLeerenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator21 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadAutomatischStarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator22 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DownloadoptionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImFensterStartenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Filter_Dropdown_OPT As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents PersonenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenreToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JahrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator23 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FortschrittToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TitelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BackdropAusZwischenablageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator24 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WeitereFunktionenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DoppelteFilmeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip_Textbox_Genre As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BearbeitenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem20 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem22 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem21 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator27 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem19 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_Update As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label_Update As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_Update_more As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label_Update_State As System.Windows.Forms.Label
    Friend WithEvents Update_Link As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents MediaInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator28 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SortierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SicherungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SichrungErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WiederherstellenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewSizeColumn1 As Film_Info__Organizer.DataGridViewSizeColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripMenuItem24 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem25 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem26 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator30 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem27 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem28 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator31 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilmordnerLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator34 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SicherungErstellenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator35 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem31 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem30 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem29 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator32 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ThumbnailsErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nov_Main_alt As System.Windows.Forms.ToolStrip
    Friend WithEvents Exp_Organisieren As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents exp_menu_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_saveas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem35 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem36 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem37 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem38 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_export As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator36 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Exp_Abrufen As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem33 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem45 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem46 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator37 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem44 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem47 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem48 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator38 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem49 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Exp_Play As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripMenuItem50 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_backup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem59 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem60 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator41 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem61 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem62 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem64 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem63 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_delet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Exp_MediaInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents Exp_Rename As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem65 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem66 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem67 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem68 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_navbar As System.Windows.Forms.ToolStripButton
    Friend WithEvents exp_InfoPanel As System.Windows.Forms.ToolStripButton
    Friend WithEvents LayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem54 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator40 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem55 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem57 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem56 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator39 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents exp_menu_downloads As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_Download As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents ToolStripSeparator44 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem53 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem51 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator45 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem58 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator46 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem69 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem70 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator47 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem71 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_speichern As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToPanelTimer As System.Windows.Forms.Timer
    Friend WithEvents Toolbar_Timer As System.Windows.Forms.Timer
    Friend WithEvents exp_dl_time As System.Windows.Forms.ToolStripLabel
    Friend WithEvents exp_dl_Fortschritt As System.Windows.Forms.ToolStripLabel
    Friend WithEvents exp_dl_speed As System.Windows.Forms.ToolStripLabel
    Friend WithEvents exp_dl_size As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Exp_Suche As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents Radio_DynamischeWerkzeugleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WerkzeugeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Browser_Navigationtb As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Panel_ask_selectmovie As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel_Overlay_useImage As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
    Friend WithEvents exp_Downloads As System.Windows.Forms.ToolStripButton
    Friend WithEvents Exp_Öffnen_XP As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem77 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem52 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Exp_Öffnen_better As System.Windows.Forms.ToolStripButton
    Friend WithEvents TrailerLadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator51 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem76 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem79 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator43 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator48 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents exp_sep As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator49 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator6 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator53 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents ToolStripSeparator15 As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents exp_menu_sep_file_big As Film_Info__Organizer.ToolStripSeperator2
    Friend WithEvents DropDownMenu_Suche As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SchnelleSuche_DropDownMenu_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NormaleSuche_DropDownMenu_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExacteSuche_DropDownMenu_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator52 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents IMDBVerwenden_DropDownMenu_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Genre_DropDownMenu_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DropDownMenu_Cover As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem43 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem72 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem73 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem74 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator33 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DarstellerbilderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel_treepadding As System.Windows.Forms.Panel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents OrdnerpfadÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WiedergebenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator42 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents exp_menu_kopieren As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_sep_file1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents exp_menu_verschieben As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_Cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_copyto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem_moveto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator54 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator50 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LöschenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator55 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LöschenToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem32 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator56 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem34 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem39 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_Export As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem75 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MyStatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel_Browser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Count_Movies As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Tool_Rename As System.Windows.Forms.ToolStripButton
    Friend WithEvents Count_size As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Radio_NormaleWerkzeugleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator57 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WerkzeugleisteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_nToolbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_dToolbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator59 As System.Windows.Forms.ToolStripSeparator

    Friend WithEvents TreeViewVista1 As Film_Info__Organizer.TreeViewVista
    Friend WithEvents TreeView_Opt_Columns As Film_Info__Organizer.TreeViewVista
    Friend WithEvents VideosVergleichenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_Sammlung As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel_SammlungenOPT As System.Windows.Forms.ToolStripLabel
    Friend WithEvents HinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SammlungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exp_menu_Sammlung As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_BoxSets As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SammlungToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DummyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents TrailerWiedergebenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrailerLadenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrailerLadenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_q_Trailer As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Button_Download_Trailer As System.Windows.Forms.Button
    Friend WithEvents AnsichtToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WerkzeugleisteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator58 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Radio_NorToolbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Radio_DynToolbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator20 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilmeZusammenfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenu_Flags As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FragezeichenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkiertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator60 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CoverToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FanartToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WichtigToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineMarkierungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkierungToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator61 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem40 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem41 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem42 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkierungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DropDown_Trailer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrailerAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomatischToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator62 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents YoutubeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator63 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Navigationsleiste As Film_Info__Organizer.TreeViewVista
    Friend WithEvents SerienLadenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InfoPanel_Movie1 As Film_Info__Organizer.InfoPanel_Movie
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button_useasCover As System.Windows.Forms.Button
    Friend WithEvents Button_useasBackdrop As System.Windows.Forms.Button
    Friend WithEvents InfoPanel_Episode1 As Film_Info__Organizer.InfoPanel_Episode
    '  Friend WithEvents Column_serien As AdvancedDataGridView.TreeGridColumn
    Friend WithEvents Column_Ser_Progress As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents Column_Serien_RateCover As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Serien_RateInhalt As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Serien_RateMediaInfo As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Serien_RateFilename As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Ser_Titel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Ser_Pfad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImageList_SerienGrid As System.Windows.Forms.ImageList
    Friend WithEvents KonvertierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BilderInfosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuXBMCKonvertierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuXBMCKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CoverUndFanartLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Column_Flags As Film_Info__Organizer.DataGridViewFlagColumn
    Friend WithEvents Column_Fortschritt As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents Column_Rate_Cover As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Rate_Backdrops As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Rate_Info As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Rate_MediaInfo As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Rate_Ordner As Film_Info__Organizer.DataGridViewRateColumn
    Friend WithEvents Column_Pfad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Ordner As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Titel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Originaltitel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_IMDB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Darsteller As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Regie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Autoren As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Studios As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Produktionsjahr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Produktionsland As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Genre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_FSK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Bewertung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Spieldauer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Kurzbeschreibung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Inhalt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_MediaInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Position As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Datum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Sort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Auflösung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Seitenverhältnis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_VideoBildwiederholungsrate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_VideoCodec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_AudioKanäle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_AudioCodec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Sprachen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_FilesCount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_SizeFolder As Film_Info__Organizer.DataGridViewSizeColumn
    Friend WithEvents Column_watched As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column_Trailer As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column_Set As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_Depth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ZuToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuFilmePluginKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZuMediaBrowserKopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


End Class
