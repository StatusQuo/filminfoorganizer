<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoPanel_MultiSelected
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoPanel_MultiSelected))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Table_VideoAuflösung = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_VideoAuflösung = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Table_VideoSeitenverhältnis = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_VideoSeitenverhältnis = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Table_VideoBildwiederholungsrate = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_VideoBildwiederholungsrate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Table_VideoCodec = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_VideoCodec = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Table_AudioKanäle = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_AudioKanäle = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Table_AudioCodec = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_AudioCodec = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Videoheightwidth = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Table_AudioSprachen = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_AudioSprachen = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Table_Spieldauer = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Spieldauer = New System.Windows.Forms.TextBox()
        Me.ContextMenu_TextBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RückgäningToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.KopierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusschneidenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.SuchenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Table_Produktionsjahr = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Produktionsjahr = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Table_Bewertung = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Bewertung = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Table_Pfad = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Pfad = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Table_Regisseur = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Regisseur = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Table_Titel = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Titel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Table_Autoren = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Autoren = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Table_Ordner = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_Ordner = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cover_Panel = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenu_Cover = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EinfügenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackdropAusZwischenablageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.GoogleToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoviemazeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbl_selectedmovie = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.InfoTabs3 = New System.Windows.Forms.TabControl()
        Me.Inhalttap = New System.Windows.Forms.TabPage()
        Me.TB_Inhalt = New System.Windows.Forms.TextBox()
        Me.Count_words = New System.Windows.Forms.Label()
        Me.Darstellertab = New System.Windows.Forms.TabPage()
        Me.DarstellerView = New System.Windows.Forms.DataGridView()
        Me.DarstellerNameColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DarstellerRolleColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Count_Darsteller = New System.Windows.Forms.Label()
        Me.TabImages = New System.Windows.Forms.ImageList(Me.components)
        Me.FolderListImages = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenu_FSK = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuchenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FSKHomepageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nav_Statybar = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton_Rückgängig = New System.Windows.Forms.ToolStripButton()
        Me.InfoslöschenToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SicherungErstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WiederherstellenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator29 = New System.Windows.Forms.ToolStripSeparator()
        Me.SicherungLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tool_Overwrite = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ContextMenu_Folder = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator()
        Me.LöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenu_Darsteller = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label_Gesamt = New System.Windows.Forms.Label()
        Me.Elemente = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label_Filelen = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Table_VideoAuflösung.SuspendLayout()
        Me.Table_VideoSeitenverhältnis.SuspendLayout()
        Me.Table_VideoBildwiederholungsrate.SuspendLayout()
        Me.Table_VideoCodec.SuspendLayout()
        Me.Table_AudioKanäle.SuspendLayout()
        Me.Table_AudioCodec.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.Table_AudioSprachen.SuspendLayout()
        Me.Table_Spieldauer.SuspendLayout()
        Me.ContextMenu_TextBox.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.Table_Produktionsjahr.SuspendLayout()
        Me.Table_Bewertung.SuspendLayout()
        Me.Table_Pfad.SuspendLayout()
        Me.Table_Regisseur.SuspendLayout()
        Me.Table_Titel.SuspendLayout()
        Me.Table_Autoren.SuspendLayout()
        Me.Table_Ordner.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Cover_Panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenu_Cover.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.InfoTabs3.SuspendLayout()
        Me.Inhalttap.SuspendLayout()
        Me.Darstellertab.SuspendLayout()
        CType(Me.DarstellerView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenu_FSK.SuspendLayout()
        Me.Nav_Statybar.SuspendLayout()
        Me.ContextMenu_Folder.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 25)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.94976!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.05024!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(485, 872)
        Me.TableLayoutPanel1.TabIndex = 6
        Me.TableLayoutPanel1.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoSize = True
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_VideoAuflösung)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_VideoSeitenverhältnis)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_VideoBildwiederholungsrate)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_VideoCodec)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_AudioKanäle)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_AudioCodec)
        Me.FlowLayoutPanel2.Controls.Add(Me.TableLayoutPanel4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_AudioSprachen)
        Me.FlowLayoutPanel2.Controls.Add(Me.Table_Spieldauer)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(2, 731)
        Me.FlowLayoutPanel2.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(481, 139)
        Me.FlowLayoutPanel2.TabIndex = 7
        '
        'Table_VideoAuflösung
        '
        Me.Table_VideoAuflösung.AutoSize = True
        Me.Table_VideoAuflösung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_VideoAuflösung.ColumnCount = 1
        Me.Table_VideoAuflösung.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_VideoAuflösung.Controls.Add(Me.TB_VideoAuflösung, 0, 1)
        Me.Table_VideoAuflösung.Controls.Add(Me.Label1, 0, 0)
        Me.Table_VideoAuflösung.Location = New System.Drawing.Point(2, 2)
        Me.Table_VideoAuflösung.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoAuflösung.Name = "Table_VideoAuflösung"
        Me.Table_VideoAuflösung.RowCount = 2
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_VideoAuflösung.Size = New System.Drawing.Size(113, 42)
        Me.Table_VideoAuflösung.TabIndex = 21
        '
        'TB_VideoAuflösung
        '
        Me.TB_VideoAuflösung.AllowDrop = True
        Me.TB_VideoAuflösung.AutoCompleteCustomSource.AddRange(New String() {"1080", "1920x1080", "1280x720", "1080i", "1080p", "480", "480i", "480p", "540", "540i", "540p", "576i", "576p", "720", "720i", "720p", "sd"})
        Me.TB_VideoAuflösung.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoAuflösung.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoAuflösung.Name = "TB_VideoAuflösung"
        Me.TB_VideoAuflösung.Size = New System.Drawing.Size(109, 23)
        Me.TB_VideoAuflösung.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Auflösung"
        '
        'Table_VideoSeitenverhältnis
        '
        Me.Table_VideoSeitenverhältnis.AutoSize = True
        Me.Table_VideoSeitenverhältnis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_VideoSeitenverhältnis.ColumnCount = 1
        Me.Table_VideoSeitenverhältnis.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_VideoSeitenverhältnis.Controls.Add(Me.TB_VideoSeitenverhältnis, 0, 1)
        Me.Table_VideoSeitenverhältnis.Controls.Add(Me.Label17, 0, 0)
        Me.Table_VideoSeitenverhältnis.Location = New System.Drawing.Point(119, 2)
        Me.Table_VideoSeitenverhältnis.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoSeitenverhältnis.Name = "Table_VideoSeitenverhältnis"
        Me.Table_VideoSeitenverhältnis.RowCount = 2
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_VideoSeitenverhältnis.Size = New System.Drawing.Size(113, 42)
        Me.Table_VideoSeitenverhältnis.TabIndex = 22
        '
        'TB_VideoSeitenverhältnis
        '
        Me.TB_VideoSeitenverhältnis.AllowDrop = True
        Me.TB_VideoSeitenverhältnis.AutoCompleteCustomSource.AddRange(New String() {"4:3", "16:9", "21:9"})
        Me.TB_VideoSeitenverhältnis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_VideoSeitenverhältnis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_VideoSeitenverhältnis.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoSeitenverhältnis.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoSeitenverhältnis.Name = "TB_VideoSeitenverhältnis"
        Me.TB_VideoSeitenverhältnis.Size = New System.Drawing.Size(109, 23)
        Me.TB_VideoSeitenverhältnis.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(2, 0)
        Me.Label17.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 15)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Seitenverhältnis"
        '
        'Table_VideoBildwiederholungsrate
        '
        Me.Table_VideoBildwiederholungsrate.AutoSize = True
        Me.Table_VideoBildwiederholungsrate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_VideoBildwiederholungsrate.ColumnCount = 1
        Me.Table_VideoBildwiederholungsrate.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_VideoBildwiederholungsrate.Controls.Add(Me.TB_VideoBildwiederholungsrate, 0, 1)
        Me.Table_VideoBildwiederholungsrate.Controls.Add(Me.Label18, 0, 0)
        Me.Table_VideoBildwiederholungsrate.Location = New System.Drawing.Point(236, 2)
        Me.Table_VideoBildwiederholungsrate.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoBildwiederholungsrate.Name = "Table_VideoBildwiederholungsrate"
        Me.Table_VideoBildwiederholungsrate.RowCount = 2
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_VideoBildwiederholungsrate.Size = New System.Drawing.Size(113, 42)
        Me.Table_VideoBildwiederholungsrate.TabIndex = 23
        '
        'TB_VideoBildwiederholungsrate
        '
        Me.TB_VideoBildwiederholungsrate.AllowDrop = True
        Me.TB_VideoBildwiederholungsrate.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoBildwiederholungsrate.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoBildwiederholungsrate.Name = "TB_VideoBildwiederholungsrate"
        Me.TB_VideoBildwiederholungsrate.Size = New System.Drawing.Size(109, 23)
        Me.TB_VideoBildwiederholungsrate.TabIndex = 16
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 0)
        Me.Label18.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 15)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Framerate"
        '
        'Table_VideoCodec
        '
        Me.Table_VideoCodec.AutoSize = True
        Me.Table_VideoCodec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_VideoCodec.ColumnCount = 1
        Me.Table_VideoCodec.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_VideoCodec.Controls.Add(Me.TB_VideoCodec, 0, 1)
        Me.Table_VideoCodec.Controls.Add(Me.Label19, 0, 0)
        Me.Table_VideoCodec.Location = New System.Drawing.Point(353, 2)
        Me.Table_VideoCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoCodec.Name = "Table_VideoCodec"
        Me.Table_VideoCodec.RowCount = 2
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_VideoCodec.Size = New System.Drawing.Size(113, 42)
        Me.Table_VideoCodec.TabIndex = 24
        '
        'TB_VideoCodec
        '
        Me.TB_VideoCodec.AllowDrop = True
        Me.TB_VideoCodec.AutoCompleteCustomSource.AddRange(New String() {"3iv2", "avc1", "div2", "div3", "divx 4", "divx", "dx50", "flv", "flv1", "fmp4", "h.264", "h264", "microsoft", "mp42", "mp43", "mp4v", "mpeg video", "mpeg-4 visual", "mpeg", "mpeg1", "mpeg1video", "mpeg2", "mpeg2video", "mpeg4", "mpg4", "quicktime", "sorenson 3", "svq3", "vc-1", "wmv", "wmv2", "wmvhd", "wvc1", "x.264", "xvid"})
        Me.TB_VideoCodec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_VideoCodec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_VideoCodec.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoCodec.Name = "TB_VideoCodec"
        Me.TB_VideoCodec.Size = New System.Drawing.Size(109, 23)
        Me.TB_VideoCodec.TabIndex = 16
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(2, 0)
        Me.Label19.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(74, 15)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Video Codec"
        '
        'Table_AudioKanäle
        '
        Me.Table_AudioKanäle.AutoSize = True
        Me.Table_AudioKanäle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_AudioKanäle.ColumnCount = 1
        Me.Table_AudioKanäle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_AudioKanäle.Controls.Add(Me.TB_AudioKanäle, 0, 1)
        Me.Table_AudioKanäle.Controls.Add(Me.Label20, 0, 0)
        Me.Table_AudioKanäle.Location = New System.Drawing.Point(2, 48)
        Me.Table_AudioKanäle.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioKanäle.Name = "Table_AudioKanäle"
        Me.Table_AudioKanäle.RowCount = 2
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_AudioKanäle.Size = New System.Drawing.Size(113, 42)
        Me.Table_AudioKanäle.TabIndex = 25
        '
        'TB_AudioKanäle
        '
        Me.TB_AudioKanäle.AllowDrop = True
        Me.TB_AudioKanäle.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioKanäle.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioKanäle.Name = "TB_AudioKanäle"
        Me.TB_AudioKanäle.Size = New System.Drawing.Size(109, 23)
        Me.TB_AudioKanäle.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(2, 0)
        Me.Label20.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 15)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Audio Kanäle"
        '
        'Table_AudioCodec
        '
        Me.Table_AudioCodec.AutoSize = True
        Me.Table_AudioCodec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_AudioCodec.ColumnCount = 1
        Me.Table_AudioCodec.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_AudioCodec.Controls.Add(Me.TB_AudioCodec, 0, 1)
        Me.Table_AudioCodec.Controls.Add(Me.Label21, 0, 0)
        Me.Table_AudioCodec.Location = New System.Drawing.Point(119, 48)
        Me.Table_AudioCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioCodec.Name = "Table_AudioCodec"
        Me.Table_AudioCodec.RowCount = 2
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_AudioCodec.Size = New System.Drawing.Size(113, 42)
        Me.Table_AudioCodec.TabIndex = 26
        '
        'TB_AudioCodec
        '
        Me.TB_AudioCodec.AllowDrop = True
        Me.TB_AudioCodec.AutoCompleteCustomSource.AddRange(New String() {"aac", "dd20", "dd40", "dd41", "dd51", "dd71", "dolby20", "dolbydigital", "dolbypro", "dolbytruehd", "dts", "dts51", "dts71", "dtsma", "flac", "lpcm", "mono", "mp2", "mp3", "mpeg audio", "ogg", "pcm", "wav", "wma", "wmahd"})
        Me.TB_AudioCodec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_AudioCodec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_AudioCodec.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioCodec.Name = "TB_AudioCodec"
        Me.TB_AudioCodec.Size = New System.Drawing.Size(109, 23)
        Me.TB_AudioCodec.TabIndex = 16
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(2, 0)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(76, 15)
        Me.Label21.TabIndex = 17
        Me.Label21.Text = "Audio Codec"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.TB_Videoheightwidth, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(236, 48)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(113, 42)
        Me.TableLayoutPanel4.TabIndex = 29
        '
        'TB_Videoheightwidth
        '
        Me.TB_Videoheightwidth.AllowDrop = True
        Me.TB_Videoheightwidth.AutoCompleteCustomSource.AddRange(New String() {"aac", "dd20", "dd40", "dd41", "dd51", "dd71", "dolby20", "dolbydigital", "dolbypro", "dolbytruehd", "dts", "dts51", "dts71", "dtsma", "flac", "lpcm", "mono", "mp2", "mp3", "mpeg audio", "ogg", "pcm", "wav", "wma", "wmahd"})
        Me.TB_Videoheightwidth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_Videoheightwidth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_Videoheightwidth.Location = New System.Drawing.Point(2, 17)
        Me.TB_Videoheightwidth.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Videoheightwidth.Name = "TB_Videoheightwidth"
        Me.TB_Videoheightwidth.ReadOnly = True
        Me.TB_Videoheightwidth.Size = New System.Drawing.Size(109, 23)
        Me.TB_Videoheightwidth.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Höhe x Breite"
        '
        'Table_AudioSprachen
        '
        Me.Table_AudioSprachen.AutoSize = True
        Me.Table_AudioSprachen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_AudioSprachen.ColumnCount = 1
        Me.Table_AudioSprachen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_AudioSprachen.Controls.Add(Me.TB_AudioSprachen, 0, 1)
        Me.Table_AudioSprachen.Controls.Add(Me.Label22, 0, 0)
        Me.Table_AudioSprachen.Location = New System.Drawing.Point(353, 48)
        Me.Table_AudioSprachen.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioSprachen.Name = "Table_AudioSprachen"
        Me.Table_AudioSprachen.RowCount = 2
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_AudioSprachen.Size = New System.Drawing.Size(113, 42)
        Me.Table_AudioSprachen.TabIndex = 27
        '
        'TB_AudioSprachen
        '
        Me.TB_AudioSprachen.AllowDrop = True
        Me.TB_AudioSprachen.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioSprachen.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioSprachen.Name = "TB_AudioSprachen"
        Me.TB_AudioSprachen.Size = New System.Drawing.Size(109, 23)
        Me.TB_AudioSprachen.TabIndex = 16
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(2, 0)
        Me.Label22.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 15)
        Me.Label22.TabIndex = 17
        Me.Label22.Text = "Sprache"
        '
        'Table_Spieldauer
        '
        Me.Table_Spieldauer.AutoSize = True
        Me.Table_Spieldauer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Spieldauer.ColumnCount = 1
        Me.Table_Spieldauer.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Spieldauer.Controls.Add(Me.TB_Spieldauer, 0, 1)
        Me.Table_Spieldauer.Controls.Add(Me.Label14, 0, 0)
        Me.Table_Spieldauer.Location = New System.Drawing.Point(2, 94)
        Me.Table_Spieldauer.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_Spieldauer.Name = "Table_Spieldauer"
        Me.Table_Spieldauer.RowCount = 2
        Me.Table_Spieldauer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Spieldauer.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Spieldauer.Size = New System.Drawing.Size(113, 42)
        Me.Table_Spieldauer.TabIndex = 10
        '
        'TB_Spieldauer
        '
        Me.TB_Spieldauer.AllowDrop = True
        Me.TB_Spieldauer.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Spieldauer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Spieldauer.Location = New System.Drawing.Point(2, 17)
        Me.TB_Spieldauer.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Spieldauer.Name = "TB_Spieldauer"
        Me.TB_Spieldauer.Size = New System.Drawing.Size(109, 23)
        Me.TB_Spieldauer.TabIndex = 0
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(2, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 15)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Spieldauer"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoScroll = True
        Me.TableLayoutPanel3.AutoSize = True
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel8, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Table_Regisseur, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Table_Titel, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Table_Autoren, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Table_Ordner, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(2, 217)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(481, 126)
        Me.TableLayoutPanel3.TabIndex = 10
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.AutoSize = True
        Me.TableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel3.SetColumnSpan(Me.TableLayoutPanel8, 2)
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.Table_Produktionsjahr, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Table_Bewertung, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Table_Pfad, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 84)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(481, 42)
        Me.TableLayoutPanel8.TabIndex = 8
        '
        'Table_Produktionsjahr
        '
        Me.Table_Produktionsjahr.AutoSize = True
        Me.Table_Produktionsjahr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Produktionsjahr.ColumnCount = 1
        Me.Table_Produktionsjahr.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.Table_Produktionsjahr.Controls.Add(Me.TB_Produktionsjahr, 0, 1)
        Me.Table_Produktionsjahr.Controls.Add(Me.Label7, 0, 0)
        Me.Table_Produktionsjahr.Dock = System.Windows.Forms.DockStyle.Top
        Me.Table_Produktionsjahr.Location = New System.Drawing.Point(384, 0)
        Me.Table_Produktionsjahr.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Produktionsjahr.Name = "Table_Produktionsjahr"
        Me.Table_Produktionsjahr.RowCount = 2
        Me.Table_Produktionsjahr.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Produktionsjahr.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Produktionsjahr.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_Produktionsjahr.Size = New System.Drawing.Size(97, 42)
        Me.Table_Produktionsjahr.TabIndex = 5
        '
        'TB_Produktionsjahr
        '
        Me.TB_Produktionsjahr.AllowDrop = True
        Me.TB_Produktionsjahr.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Produktionsjahr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Produktionsjahr.Location = New System.Drawing.Point(2, 17)
        Me.TB_Produktionsjahr.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Produktionsjahr.Name = "TB_Produktionsjahr"
        Me.TB_Produktionsjahr.Size = New System.Drawing.Size(93, 23)
        Me.TB_Produktionsjahr.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(2, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Jahr"
        '
        'Table_Bewertung
        '
        Me.Table_Bewertung.AutoSize = True
        Me.Table_Bewertung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Bewertung.ColumnCount = 1
        Me.Table_Bewertung.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.Table_Bewertung.Controls.Add(Me.TB_Bewertung, 0, 1)
        Me.Table_Bewertung.Controls.Add(Me.Label9, 0, 0)
        Me.Table_Bewertung.Dock = System.Windows.Forms.DockStyle.Top
        Me.Table_Bewertung.Location = New System.Drawing.Point(288, 0)
        Me.Table_Bewertung.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Bewertung.Name = "Table_Bewertung"
        Me.Table_Bewertung.RowCount = 2
        Me.Table_Bewertung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Bewertung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Bewertung.Size = New System.Drawing.Size(96, 42)
        Me.Table_Bewertung.TabIndex = 4
        '
        'TB_Bewertung
        '
        Me.TB_Bewertung.AllowDrop = True
        Me.TB_Bewertung.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Bewertung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Bewertung.Location = New System.Drawing.Point(2, 17)
        Me.TB_Bewertung.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Bewertung.Name = "TB_Bewertung"
        Me.TB_Bewertung.Size = New System.Drawing.Size(92, 23)
        Me.TB_Bewertung.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Location = New System.Drawing.Point(2, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Bewertung"
        '
        'Table_Pfad
        '
        Me.Table_Pfad.AutoSize = True
        Me.Table_Pfad.ColumnCount = 1
        Me.Table_Pfad.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Pfad.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.Table_Pfad.Controls.Add(Me.TB_Pfad, 0, 1)
        Me.Table_Pfad.Controls.Add(Me.Label16, 0, 0)
        Me.Table_Pfad.Dock = System.Windows.Forms.DockStyle.Top
        Me.Table_Pfad.Location = New System.Drawing.Point(0, 0)
        Me.Table_Pfad.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Pfad.Name = "Table_Pfad"
        Me.Table_Pfad.RowCount = 2
        Me.Table_Pfad.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Pfad.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Pfad.Size = New System.Drawing.Size(288, 42)
        Me.Table_Pfad.TabIndex = 12
        '
        'TB_Pfad
        '
        Me.TB_Pfad.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Pfad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Pfad.Location = New System.Drawing.Point(2, 17)
        Me.TB_Pfad.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Pfad.Name = "TB_Pfad"
        Me.TB_Pfad.ReadOnly = True
        Me.TB_Pfad.Size = New System.Drawing.Size(284, 23)
        Me.TB_Pfad.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(2, 0)
        Me.Label16.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(31, 15)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Pfad"
        '
        'Table_Regisseur
        '
        Me.Table_Regisseur.AutoSize = True
        Me.Table_Regisseur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Regisseur.ColumnCount = 1
        Me.Table_Regisseur.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Regisseur.Controls.Add(Me.TB_Regisseur, 0, 1)
        Me.Table_Regisseur.Controls.Add(Me.Label12, 0, 0)
        Me.Table_Regisseur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Table_Regisseur.Location = New System.Drawing.Point(240, 42)
        Me.Table_Regisseur.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Regisseur.Name = "Table_Regisseur"
        Me.Table_Regisseur.RowCount = 2
        Me.Table_Regisseur.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Regisseur.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Regisseur.Size = New System.Drawing.Size(241, 42)
        Me.Table_Regisseur.TabIndex = 9
        '
        'TB_Regisseur
        '
        Me.TB_Regisseur.AllowDrop = True
        Me.TB_Regisseur.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Regisseur.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Regisseur.Location = New System.Drawing.Point(2, 17)
        Me.TB_Regisseur.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Regisseur.Name = "TB_Regisseur"
        Me.TB_Regisseur.Size = New System.Drawing.Size(237, 23)
        Me.TB_Regisseur.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(2, 0)
        Me.Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 15)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Regisseur"
        '
        'Table_Titel
        '
        Me.Table_Titel.AutoSize = True
        Me.Table_Titel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Titel.ColumnCount = 1
        Me.Table_Titel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Titel.Controls.Add(Me.TB_Titel, 0, 1)
        Me.Table_Titel.Controls.Add(Me.Label2, 0, 0)
        Me.Table_Titel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Table_Titel.Location = New System.Drawing.Point(0, 0)
        Me.Table_Titel.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Titel.Name = "Table_Titel"
        Me.Table_Titel.RowCount = 2
        Me.Table_Titel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Titel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Titel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.Table_Titel.Size = New System.Drawing.Size(240, 42)
        Me.Table_Titel.TabIndex = 0
        '
        'TB_Titel
        '
        Me.TB_Titel.AllowDrop = True
        Me.TB_Titel.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Titel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Titel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TB_Titel.Location = New System.Drawing.Point(2, 17)
        Me.TB_Titel.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Titel.Name = "TB_Titel"
        Me.TB_Titel.Size = New System.Drawing.Size(236, 23)
        Me.TB_Titel.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(2, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Titel"
        '
        'Table_Autoren
        '
        Me.Table_Autoren.AutoSize = True
        Me.Table_Autoren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Autoren.ColumnCount = 1
        Me.Table_Autoren.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Autoren.Controls.Add(Me.TB_Autoren, 0, 1)
        Me.Table_Autoren.Controls.Add(Me.Label15, 0, 0)
        Me.Table_Autoren.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Table_Autoren.Location = New System.Drawing.Point(0, 42)
        Me.Table_Autoren.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Autoren.Name = "Table_Autoren"
        Me.Table_Autoren.RowCount = 2
        Me.Table_Autoren.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Autoren.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Autoren.Size = New System.Drawing.Size(240, 42)
        Me.Table_Autoren.TabIndex = 11
        '
        'TB_Autoren
        '
        Me.TB_Autoren.AllowDrop = True
        Me.TB_Autoren.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Autoren.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Autoren.Location = New System.Drawing.Point(2, 17)
        Me.TB_Autoren.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Autoren.Name = "TB_Autoren"
        Me.TB_Autoren.Size = New System.Drawing.Size(236, 23)
        Me.TB_Autoren.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(2, 0)
        Me.Label15.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Autoren"
        '
        'Table_Ordner
        '
        Me.Table_Ordner.AutoSize = True
        Me.Table_Ordner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_Ordner.ColumnCount = 1
        Me.Table_Ordner.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_Ordner.Controls.Add(Me.TB_Ordner, 0, 1)
        Me.Table_Ordner.Controls.Add(Me.Label5, 0, 0)
        Me.Table_Ordner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Table_Ordner.Location = New System.Drawing.Point(240, 0)
        Me.Table_Ordner.Margin = New System.Windows.Forms.Padding(0)
        Me.Table_Ordner.Name = "Table_Ordner"
        Me.Table_Ordner.RowCount = 2
        Me.Table_Ordner.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Ordner.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_Ordner.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.Table_Ordner.Size = New System.Drawing.Size(241, 42)
        Me.Table_Ordner.TabIndex = 3
        '
        'TB_Ordner
        '
        Me.TB_Ordner.ContextMenuStrip = Me.ContextMenu_TextBox
        Me.TB_Ordner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Ordner.Location = New System.Drawing.Point(2, 17)
        Me.TB_Ordner.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Ordner.Name = "TB_Ordner"
        Me.TB_Ordner.ReadOnly = True
        Me.TB_Ordner.Size = New System.Drawing.Size(237, 23)
        Me.TB_Ordner.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(2, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(237, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Dateiname"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Cover_Panel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(485, 215)
        Me.Panel3.TabIndex = 18
        '
        'Cover_Panel
        '
        Me.Cover_Panel.AllowDrop = True
        Me.Cover_Panel.Controls.Add(Me.PictureBox1)
        Me.Cover_Panel.Controls.Add(Me.lbl_selectedmovie)
        Me.Cover_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cover_Panel.Location = New System.Drawing.Point(0, 0)
        Me.Cover_Panel.Margin = New System.Windows.Forms.Padding(2)
        Me.Cover_Panel.Name = "Cover_Panel"
        Me.Cover_Panel.Size = New System.Drawing.Size(485, 215)
        Me.Cover_Panel.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenu_Cover
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 23)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(485, 192)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
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
        'lbl_selectedmovie
        '
        Me.lbl_selectedmovie.AutoEllipsis = True
        Me.lbl_selectedmovie.BackColor = System.Drawing.Color.Transparent
        Me.lbl_selectedmovie.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl_selectedmovie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_selectedmovie.Location = New System.Drawing.Point(0, 0)
        Me.lbl_selectedmovie.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_selectedmovie.Name = "lbl_selectedmovie"
        Me.lbl_selectedmovie.Size = New System.Drawing.Size(485, 23)
        Me.lbl_selectedmovie.TabIndex = 2
        Me.lbl_selectedmovie.Text = "-"
        Me.lbl_selectedmovie.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.InfoTabs3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(2, 347)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 380)
        Me.Panel1.TabIndex = 7
        '
        'InfoTabs3
        '
        Me.InfoTabs3.AllowDrop = True
        Me.InfoTabs3.Controls.Add(Me.Inhalttap)
        Me.InfoTabs3.Controls.Add(Me.Darstellertab)
        Me.InfoTabs3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InfoTabs3.HotTrack = True
        Me.InfoTabs3.ImageList = Me.TabImages
        Me.InfoTabs3.Location = New System.Drawing.Point(0, 0)
        Me.InfoTabs3.Margin = New System.Windows.Forms.Padding(2)
        Me.InfoTabs3.Name = "InfoTabs3"
        Me.InfoTabs3.SelectedIndex = 0
        Me.InfoTabs3.Size = New System.Drawing.Size(481, 380)
        Me.InfoTabs3.TabIndex = 0
        '
        'Inhalttap
        '
        Me.Inhalttap.Controls.Add(Me.TB_Inhalt)
        Me.Inhalttap.Controls.Add(Me.Count_words)
        Me.Inhalttap.ImageIndex = 2
        Me.Inhalttap.Location = New System.Drawing.Point(4, 24)
        Me.Inhalttap.Margin = New System.Windows.Forms.Padding(2)
        Me.Inhalttap.Name = "Inhalttap"
        Me.Inhalttap.Padding = New System.Windows.Forms.Padding(2)
        Me.Inhalttap.Size = New System.Drawing.Size(473, 352)
        Me.Inhalttap.TabIndex = 3
        Me.Inhalttap.Tag = "Inhalt"
        Me.Inhalttap.UseVisualStyleBackColor = True
        '
        'TB_Inhalt
        '
        Me.TB_Inhalt.AllowDrop = True
        Me.TB_Inhalt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TB_Inhalt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_Inhalt.Location = New System.Drawing.Point(2, 17)
        Me.TB_Inhalt.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_Inhalt.Multiline = True
        Me.TB_Inhalt.Name = "TB_Inhalt"
        Me.TB_Inhalt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TB_Inhalt.Size = New System.Drawing.Size(469, 333)
        Me.TB_Inhalt.TabIndex = 21
        '
        'Count_words
        '
        Me.Count_words.AutoSize = True
        Me.Count_words.Dock = System.Windows.Forms.DockStyle.Top
        Me.Count_words.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Count_words.Location = New System.Drawing.Point(2, 2)
        Me.Count_words.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Count_words.Name = "Count_words"
        Me.Count_words.Size = New System.Drawing.Size(0, 15)
        Me.Count_words.TabIndex = 22
        Me.Count_words.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Darstellertab
        '
        Me.Darstellertab.BackColor = System.Drawing.SystemColors.Window
        Me.Darstellertab.Controls.Add(Me.DarstellerView)
        Me.Darstellertab.Controls.Add(Me.PictureBox4)
        Me.Darstellertab.Controls.Add(Me.Count_Darsteller)
        Me.Darstellertab.Cursor = System.Windows.Forms.Cursors.Default
        Me.Darstellertab.ImageIndex = 0
        Me.Darstellertab.Location = New System.Drawing.Point(4, 24)
        Me.Darstellertab.Margin = New System.Windows.Forms.Padding(2)
        Me.Darstellertab.Name = "Darstellertab"
        Me.Darstellertab.Padding = New System.Windows.Forms.Padding(2)
        Me.Darstellertab.Size = New System.Drawing.Size(473, 371)
        Me.Darstellertab.TabIndex = 1
        Me.Darstellertab.Tag = "Darsteller"
        Me.Darstellertab.ToolTipText = "Darsteller"
        Me.Darstellertab.UseVisualStyleBackColor = True
        '
        'DarstellerView
        '
        Me.DarstellerView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DarstellerView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DarstellerView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DarstellerView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DarstellerView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DarstellerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DarstellerView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DarstellerNameColumn, Me.DarstellerRolleColumn})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DarstellerView.DefaultCellStyle = DataGridViewCellStyle1
        Me.DarstellerView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DarstellerView.Location = New System.Drawing.Point(157, 15)
        Me.DarstellerView.Margin = New System.Windows.Forms.Padding(2)
        Me.DarstellerView.MultiSelect = False
        Me.DarstellerView.Name = "DarstellerView"
        Me.DarstellerView.RowHeadersVisible = False
        Me.DarstellerView.RowHeadersWidth = 28
        Me.DarstellerView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DarstellerView.RowTemplate.Height = 28
        Me.DarstellerView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DarstellerView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DarstellerView.Size = New System.Drawing.Size(314, 354)
        Me.DarstellerView.TabIndex = 7
        '
        'DarstellerNameColumn
        '
        Me.DarstellerNameColumn.FillWeight = 127.1766!
        Me.DarstellerNameColumn.HeaderText = "Name"
        Me.DarstellerNameColumn.Name = "DarstellerNameColumn"
        Me.DarstellerNameColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DarstellerRolleColumn
        '
        Me.DarstellerRolleColumn.FillWeight = 127.1766!
        Me.DarstellerRolleColumn.HeaderText = "Rolle"
        Me.DarstellerRolleColumn.Name = "DarstellerRolleColumn"
        Me.DarstellerRolleColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PictureBox4
        '
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox4.Location = New System.Drawing.Point(2, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Padding = New System.Windows.Forms.Padding(0, 0, 6, 0)
        Me.PictureBox4.Size = New System.Drawing.Size(155, 354)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 16
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'Count_Darsteller
        '
        Me.Count_Darsteller.AutoSize = True
        Me.Count_Darsteller.Dock = System.Windows.Forms.DockStyle.Top
        Me.Count_Darsteller.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Count_Darsteller.Location = New System.Drawing.Point(2, 2)
        Me.Count_Darsteller.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Count_Darsteller.Name = "Count_Darsteller"
        Me.Count_Darsteller.Size = New System.Drawing.Size(0, 15)
        Me.Count_Darsteller.TabIndex = 8
        Me.Count_Darsteller.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'FolderListImages
        '
        Me.FolderListImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.FolderListImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.FolderListImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'ContextMenu_FSK
        '
        Me.ContextMenu_FSK.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SuchenToolStripMenuItem1, Me.FSKHomepageToolStripMenuItem})
        Me.ContextMenu_FSK.Name = "ContextMenuStrip1"
        Me.ContextMenu_FSK.Size = New System.Drawing.Size(158, 48)
        '
        'SuchenToolStripMenuItem1
        '
        Me.SuchenToolStripMenuItem1.Image = CType(resources.GetObject("SuchenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.SuchenToolStripMenuItem1.Name = "SuchenToolStripMenuItem1"
        Me.SuchenToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.SuchenToolStripMenuItem1.Text = "Suchen..."
        '
        'FSKHomepageToolStripMenuItem
        '
        Me.FSKHomepageToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.FSK_Logo
        Me.FSKHomepageToolStripMenuItem.Name = "FSKHomepageToolStripMenuItem"
        Me.FSKHomepageToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.FSKHomepageToolStripMenuItem.Text = "FSK-Homepage"
        '
        'Nav_Statybar
        '
        Me.Nav_Statybar.BackColor = System.Drawing.Color.Transparent
        Me.Nav_Statybar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Nav_Statybar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_Statybar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Rückgängig, Me.InfoslöschenToolStripButton3, Me.ToolStripButton18, Me.ToolStripButton22, Me.Tool_Overwrite})
        Me.Nav_Statybar.Location = New System.Drawing.Point(0, 0)
        Me.Nav_Statybar.Name = "Nav_Statybar"
        Me.Nav_Statybar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_Statybar.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Nav_Statybar.Size = New System.Drawing.Size(485, 25)
        Me.Nav_Statybar.TabIndex = 11
        Me.Nav_Statybar.Text = "ToolStrip3"
        '
        'ToolStripButton_Rückgängig
        '
        Me.ToolStripButton_Rückgängig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton_Rückgängig.Enabled = False
        Me.ToolStripButton_Rückgängig.Image = CType(resources.GetObject("ToolStripButton_Rückgängig.Image"), System.Drawing.Image)
        Me.ToolStripButton_Rückgängig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Rückgängig.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripButton_Rückgängig.Name = "ToolStripButton_Rückgängig"
        Me.ToolStripButton_Rückgängig.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton_Rückgängig.Text = "Rückgängig"
        '
        'InfoslöschenToolStripButton3
        '
        Me.InfoslöschenToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.InfoslöschenToolStripButton3.Image = CType(resources.GetObject("InfoslöschenToolStripButton3.Image"), System.Drawing.Image)
        Me.InfoslöschenToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.InfoslöschenToolStripButton3.Name = "InfoslöschenToolStripButton3"
        Me.InfoslöschenToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.InfoslöschenToolStripButton3.Text = "Alle Felder löschen"
        Me.InfoslöschenToolStripButton3.ToolTipText = "Alle Felder löschen"
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = Global.Film_Info__Organizer.Toolbar16.watched_no
        Me.ToolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton18.Tag = "0"
        Me.ToolStripButton18.Text = "Gesehen"
        Me.ToolStripButton18.ToolTipText = "Gesehen"
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton22.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SicherungErstellenToolStripMenuItem, Me.WiederherstellenToolStripMenuItem, Me.ToolStripSeparator29, Me.SicherungLöschenToolStripMenuItem})
        Me.ToolStripButton22.Image = CType(resources.GetObject("ToolStripButton22.Image"), System.Drawing.Image)
        Me.ToolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton22.Tag = "0"
        Me.ToolStripButton22.Text = "Sicherung"
        '
        'SicherungErstellenToolStripMenuItem
        '
        Me.SicherungErstellenToolStripMenuItem.Name = "SicherungErstellenToolStripMenuItem"
        Me.SicherungErstellenToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SicherungErstellenToolStripMenuItem.Text = "Speichern und Sichern"
        '
        'WiederherstellenToolStripMenuItem
        '
        Me.WiederherstellenToolStripMenuItem.Name = "WiederherstellenToolStripMenuItem"
        Me.WiederherstellenToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
        '
        'ToolStripSeparator29
        '
        Me.ToolStripSeparator29.Name = "ToolStripSeparator29"
        Me.ToolStripSeparator29.Size = New System.Drawing.Size(189, 6)
        '
        'SicherungLöschenToolStripMenuItem
        '
        Me.SicherungLöschenToolStripMenuItem.Name = "SicherungLöschenToolStripMenuItem"
        Me.SicherungLöschenToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SicherungLöschenToolStripMenuItem.Text = "Sicherung löschen"
        '
        'Tool_Overwrite
        '
        Me.Tool_Overwrite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Tool_Overwrite.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Tool_Overwrite.Image = CType(resources.GetObject("Tool_Overwrite.Image"), System.Drawing.Image)
        Me.Tool_Overwrite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Tool_Overwrite.Name = "Tool_Overwrite"
        Me.Tool_Overwrite.Size = New System.Drawing.Size(104, 22)
        Me.Tool_Overwrite.Text = "Automatisch"
        '
        'ContextMenu_Folder
        '
        Me.ContextMenu_Folder.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÖffnenToolStripMenuItem, Me.ToolStripSeparator13, Me.LöschenToolStripMenuItem})
        Me.ContextMenu_Folder.Name = "ContextMenu_Folder"
        Me.ContextMenu_Folder.Size = New System.Drawing.Size(119, 54)
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(115, 6)
        '
        'LöschenToolStripMenuItem
        '
        Me.LöschenToolStripMenuItem.Name = "LöschenToolStripMenuItem"
        Me.LöschenToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.LöschenToolStripMenuItem.Text = "Löschen"
        '
        'ContextMenu_Darsteller
        '
        Me.ContextMenu_Darsteller.Name = "ContextMenu_Darsteller"
        Me.ContextMenu_Darsteller.Size = New System.Drawing.Size(61, 4)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(485, 872)
        Me.Panel2.TabIndex = 12
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Elemente, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(485, 872)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSize = True
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label_Gesamt, 1, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 434)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(479, 17)
        Me.TableLayoutPanel6.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(233, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Gesamt:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_Gesamt
        '
        Me.Label_Gesamt.AutoSize = True
        Me.Label_Gesamt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Gesamt.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Gesamt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label_Gesamt.Location = New System.Drawing.Point(242, 0)
        Me.Label_Gesamt.Name = "Label_Gesamt"
        Me.Label_Gesamt.Size = New System.Drawing.Size(234, 17)
        Me.Label_Gesamt.TabIndex = 3
        Me.Label_Gesamt.Text = "..."
        Me.Label_Gesamt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Elemente
        '
        Me.Elemente.AutoSize = True
        Me.Elemente.Dock = System.Windows.Forms.DockStyle.Top
        Me.Elemente.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Elemente.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Elemente.Location = New System.Drawing.Point(3, 383)
        Me.Elemente.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Elemente.Name = "Elemente"
        Me.Elemente.Size = New System.Drawing.Size(479, 20)
        Me.Elemente.TabIndex = 0
        Me.Elemente.Text = "..."
        Me.Elemente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label_Filelen, 1, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 411)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(479, 17)
        Me.TableLayoutPanel5.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Größe:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label_Filelen
        '
        Me.Label_Filelen.AutoSize = True
        Me.Label_Filelen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label_Filelen.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Filelen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.Label_Filelen.Location = New System.Drawing.Point(242, 0)
        Me.Label_Filelen.Name = "Label_Filelen"
        Me.Label_Filelen.Size = New System.Drawing.Size(234, 17)
        Me.Label_Filelen.TabIndex = 3
        Me.Label_Filelen.Text = "..."
        Me.Label_Filelen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 127.1766!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 208
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 127.1766!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Rolle"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 207
        '
        'InfoPanel_MultiSelected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Nav_Statybar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "InfoPanel_MultiSelected"
        Me.Size = New System.Drawing.Size(485, 897)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.Table_VideoAuflösung.ResumeLayout(False)
        Me.Table_VideoAuflösung.PerformLayout()
        Me.Table_VideoSeitenverhältnis.ResumeLayout(False)
        Me.Table_VideoSeitenverhältnis.PerformLayout()
        Me.Table_VideoBildwiederholungsrate.ResumeLayout(False)
        Me.Table_VideoBildwiederholungsrate.PerformLayout()
        Me.Table_VideoCodec.ResumeLayout(False)
        Me.Table_VideoCodec.PerformLayout()
        Me.Table_AudioKanäle.ResumeLayout(False)
        Me.Table_AudioKanäle.PerformLayout()
        Me.Table_AudioCodec.ResumeLayout(False)
        Me.Table_AudioCodec.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.Table_AudioSprachen.ResumeLayout(False)
        Me.Table_AudioSprachen.PerformLayout()
        Me.Table_Spieldauer.ResumeLayout(False)
        Me.Table_Spieldauer.PerformLayout()
        Me.ContextMenu_TextBox.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.Table_Produktionsjahr.ResumeLayout(False)
        Me.Table_Produktionsjahr.PerformLayout()
        Me.Table_Bewertung.ResumeLayout(False)
        Me.Table_Bewertung.PerformLayout()
        Me.Table_Pfad.ResumeLayout(False)
        Me.Table_Pfad.PerformLayout()
        Me.Table_Regisseur.ResumeLayout(False)
        Me.Table_Regisseur.PerformLayout()
        Me.Table_Titel.ResumeLayout(False)
        Me.Table_Titel.PerformLayout()
        Me.Table_Autoren.ResumeLayout(False)
        Me.Table_Autoren.PerformLayout()
        Me.Table_Ordner.ResumeLayout(False)
        Me.Table_Ordner.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Cover_Panel.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenu_Cover.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.InfoTabs3.ResumeLayout(False)
        Me.Inhalttap.ResumeLayout(False)
        Me.Inhalttap.PerformLayout()
        Me.Darstellertab.ResumeLayout(False)
        Me.Darstellertab.PerformLayout()
        CType(Me.DarstellerView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenu_FSK.ResumeLayout(False)
        Me.Nav_Statybar.ResumeLayout(False)
        Me.Nav_Statybar.PerformLayout()
        Me.ContextMenu_Folder.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Table_Bewertung As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Bewertung As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Table_Produktionsjahr As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Produktionsjahr As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Table_Titel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Titel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Table_Autoren As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Autoren As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Table_Spieldauer As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Spieldauer As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Table_Regisseur As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Regisseur As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Table_Ordner As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Ordner As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Table_Pfad As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Pfad As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Cover_Panel As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_selectedmovie As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents InfoTabs3 As System.Windows.Forms.TabControl
    Friend WithEvents Darstellertab As System.Windows.Forms.TabPage
    Friend WithEvents DarstellerView As System.Windows.Forms.DataGridView
    Friend WithEvents DarstellerNameColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DarstellerRolleColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Count_Darsteller As System.Windows.Forms.Label
    Friend WithEvents Inhalttap As System.Windows.Forms.TabPage
    Friend WithEvents TB_Inhalt As System.Windows.Forms.TextBox
    Friend WithEvents Count_words As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Table_VideoAuflösung As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_VideoAuflösung As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Table_VideoSeitenverhältnis As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_VideoSeitenverhältnis As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Table_VideoBildwiederholungsrate As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_VideoBildwiederholungsrate As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Table_VideoCodec As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_VideoCodec As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Table_AudioKanäle As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_AudioKanäle As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Table_AudioCodec As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_AudioCodec As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_Videoheightwidth As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Table_AudioSprachen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_AudioSprachen As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ContextMenu_TextBox As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RückgäningToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KopierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AusschneidenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SuchenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Nav_Statybar As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Rückgängig As System.Windows.Forms.ToolStripButton
    Friend WithEvents InfoslöschenToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents SicherungErstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WiederherstellenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator29 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SicherungLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tool_Overwrite As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ContextMenu_FSK As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SuchenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FSKHomepageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_Cover As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EinfügenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackdropAusZwischenablageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GoogleToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoviemazeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LöschenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabImages As System.Windows.Forms.ImageList
    Friend WithEvents ContextMenu_Folder As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenu_Darsteller As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FolderListImages As System.Windows.Forms.ImageList
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Elemente As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label_Filelen As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label_Gesamt As System.Windows.Forms.Label

End Class
