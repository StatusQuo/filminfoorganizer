<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_MediaInfo_Edit
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
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
        Me.Table_AudioSprachen = New System.Windows.Forms.TableLayoutPanel()
        Me.TB_AudioSprachen = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Table_VideoAuflösung.SuspendLayout()
        Me.Table_VideoSeitenverhältnis.SuspendLayout()
        Me.Table_VideoBildwiederholungsrate.SuspendLayout()
        Me.Table_VideoCodec.SuspendLayout()
        Me.Table_AudioKanäle.SuspendLayout()
        Me.Table_AudioCodec.SuspendLayout()
        Me.Table_AudioSprachen.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(319, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.AutoSize = True
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(87, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.AutoSize = True
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(96, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(87, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Table_VideoAuflösung
        '
        Me.Table_VideoAuflösung.AutoSize = True
        Me.Table_VideoAuflösung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_VideoAuflösung.ColumnCount = 1
        Me.Table_VideoAuflösung.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_VideoAuflösung.Controls.Add(Me.TB_VideoAuflösung, 0, 1)
        Me.Table_VideoAuflösung.Controls.Add(Me.Label1, 0, 0)
        Me.Table_VideoAuflösung.Location = New System.Drawing.Point(7, 21)
        Me.Table_VideoAuflösung.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoAuflösung.Name = "Table_VideoAuflösung"
        Me.Table_VideoAuflösung.RowCount = 2
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoAuflösung.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_VideoAuflösung.Size = New System.Drawing.Size(226, 43)
        Me.Table_VideoAuflösung.TabIndex = 21
        '
        'TB_VideoAuflösung
        '
        Me.TB_VideoAuflösung.AllowDrop = True
        Me.TB_VideoAuflösung.AutoCompleteCustomSource.AddRange(New String() {"1080", "1920x1080", "1280x720", "1080i", "1080p", "480", "480i", "480p", "540", "540i", "540p", "576i", "576p", "720", "720i", "720p", "sd"})
        Me.TB_VideoAuflösung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_VideoAuflösung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_VideoAuflösung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_VideoAuflösung.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoAuflösung.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoAuflösung.Name = "TB_VideoAuflösung"
        Me.TB_VideoAuflösung.Size = New System.Drawing.Size(222, 23)
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
        Me.Table_VideoSeitenverhältnis.Location = New System.Drawing.Point(7, 118)
        Me.Table_VideoSeitenverhältnis.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoSeitenverhältnis.Name = "Table_VideoSeitenverhältnis"
        Me.Table_VideoSeitenverhältnis.RowCount = 2
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoSeitenverhältnis.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_VideoSeitenverhältnis.Size = New System.Drawing.Size(226, 43)
        Me.Table_VideoSeitenverhältnis.TabIndex = 22
        '
        'TB_VideoSeitenverhältnis
        '
        Me.TB_VideoSeitenverhältnis.AllowDrop = True
        Me.TB_VideoSeitenverhältnis.AutoCompleteCustomSource.AddRange(New String() {"4:3", "16:9", "21:9"})
        Me.TB_VideoSeitenverhältnis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_VideoSeitenverhältnis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_VideoSeitenverhältnis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_VideoSeitenverhältnis.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoSeitenverhältnis.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoSeitenverhältnis.Name = "TB_VideoSeitenverhältnis"
        Me.TB_VideoSeitenverhältnis.Size = New System.Drawing.Size(222, 23)
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
        Me.Table_VideoBildwiederholungsrate.Location = New System.Drawing.Point(7, 165)
        Me.Table_VideoBildwiederholungsrate.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoBildwiederholungsrate.Name = "Table_VideoBildwiederholungsrate"
        Me.Table_VideoBildwiederholungsrate.RowCount = 2
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoBildwiederholungsrate.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_VideoBildwiederholungsrate.Size = New System.Drawing.Size(226, 43)
        Me.Table_VideoBildwiederholungsrate.TabIndex = 23
        '
        'TB_VideoBildwiederholungsrate
        '
        Me.TB_VideoBildwiederholungsrate.AllowDrop = True
        Me.TB_VideoBildwiederholungsrate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_VideoBildwiederholungsrate.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoBildwiederholungsrate.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoBildwiederholungsrate.Name = "TB_VideoBildwiederholungsrate"
        Me.TB_VideoBildwiederholungsrate.Size = New System.Drawing.Size(222, 23)
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
        Me.Table_VideoCodec.Location = New System.Drawing.Point(7, 68)
        Me.Table_VideoCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_VideoCodec.Name = "Table_VideoCodec"
        Me.Table_VideoCodec.RowCount = 2
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_VideoCodec.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_VideoCodec.Size = New System.Drawing.Size(226, 43)
        Me.Table_VideoCodec.TabIndex = 24
        '
        'TB_VideoCodec
        '
        Me.TB_VideoCodec.AllowDrop = True
        Me.TB_VideoCodec.AutoCompleteCustomSource.AddRange(New String() {"3iv2", "avc1", "div2", "div3", "divx 4", "divx", "dx50", "flv", "flv1", "fmp4", "h.264", "h264", "microsoft", "mp42", "mp43", "mp4v", "mpeg video", "mpeg-4 visual", "mpeg", "mpeg1", "mpeg1video", "mpeg2", "mpeg2video", "mpeg4", "mpg4", "quicktime", "sorenson 3", "svq3", "vc-1", "wmv", "wmv2", "wmvhd", "wvc1", "x.264", "xvid"})
        Me.TB_VideoCodec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_VideoCodec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_VideoCodec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_VideoCodec.Location = New System.Drawing.Point(2, 17)
        Me.TB_VideoCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_VideoCodec.Name = "TB_VideoCodec"
        Me.TB_VideoCodec.Size = New System.Drawing.Size(222, 23)
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
        Me.Table_AudioKanäle.Location = New System.Drawing.Point(7, 68)
        Me.Table_AudioKanäle.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioKanäle.Name = "Table_AudioKanäle"
        Me.Table_AudioKanäle.RowCount = 2
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioKanäle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_AudioKanäle.Size = New System.Drawing.Size(226, 43)
        Me.Table_AudioKanäle.TabIndex = 25
        '
        'TB_AudioKanäle
        '
        Me.TB_AudioKanäle.AllowDrop = True
        Me.TB_AudioKanäle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_AudioKanäle.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioKanäle.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioKanäle.Name = "TB_AudioKanäle"
        Me.TB_AudioKanäle.Size = New System.Drawing.Size(222, 23)
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
        Me.Table_AudioCodec.Location = New System.Drawing.Point(7, 21)
        Me.Table_AudioCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioCodec.Name = "Table_AudioCodec"
        Me.Table_AudioCodec.RowCount = 2
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioCodec.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_AudioCodec.Size = New System.Drawing.Size(226, 43)
        Me.Table_AudioCodec.TabIndex = 26
        '
        'TB_AudioCodec
        '
        Me.TB_AudioCodec.AllowDrop = True
        Me.TB_AudioCodec.AutoCompleteCustomSource.AddRange(New String() {"aac", "dd20", "dd40", "dd41", "dd51", "dd71", "dolby20", "dolbydigital", "dolbypro", "dolbytruehd", "dts", "dts51", "dts71", "dtsma", "flac", "lpcm", "mono", "mp2", "mp3", "mpeg audio", "ogg", "pcm", "wav", "wma", "wmahd"})
        Me.TB_AudioCodec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TB_AudioCodec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TB_AudioCodec.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_AudioCodec.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioCodec.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioCodec.Name = "TB_AudioCodec"
        Me.TB_AudioCodec.Size = New System.Drawing.Size(222, 23)
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
        'Table_AudioSprachen
        '
        Me.Table_AudioSprachen.AutoSize = True
        Me.Table_AudioSprachen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Table_AudioSprachen.ColumnCount = 1
        Me.Table_AudioSprachen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.Table_AudioSprachen.Controls.Add(Me.TB_AudioSprachen, 0, 1)
        Me.Table_AudioSprachen.Controls.Add(Me.Label22, 0, 0)
        Me.Table_AudioSprachen.Location = New System.Drawing.Point(7, 118)
        Me.Table_AudioSprachen.Margin = New System.Windows.Forms.Padding(2)
        Me.Table_AudioSprachen.Name = "Table_AudioSprachen"
        Me.Table_AudioSprachen.RowCount = 2
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.Table_AudioSprachen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.Table_AudioSprachen.Size = New System.Drawing.Size(226, 43)
        Me.Table_AudioSprachen.TabIndex = 27
        '
        'TB_AudioSprachen
        '
        Me.TB_AudioSprachen.AllowDrop = True
        Me.TB_AudioSprachen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TB_AudioSprachen.Location = New System.Drawing.Point(2, 17)
        Me.TB_AudioSprachen.Margin = New System.Windows.Forms.Padding(2)
        Me.TB_AudioSprachen.Name = "TB_AudioSprachen"
        Me.TB_AudioSprachen.Size = New System.Drawing.Size(222, 23)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Table_VideoAuflösung)
        Me.GroupBox1.Controls.Add(Me.Table_VideoCodec)
        Me.GroupBox1.Controls.Add(Me.Table_VideoSeitenverhältnis)
        Me.GroupBox1.Controls.Add(Me.Table_VideoBildwiederholungsrate)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(243, 218)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Video"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Table_AudioCodec)
        Me.GroupBox2.Controls.Add(Me.Table_AudioKanäle)
        Me.GroupBox2.Controls.Add(Me.Table_AudioSprachen)
        Me.GroupBox2.Location = New System.Drawing.Point(264, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(241, 218)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Audio"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 249)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(517, 49)
        Me.Panel2.TabIndex = 30
        '
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(517, 41)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'Dialog_MediaInfo_Edit
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(517, 298)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_MediaInfo_Edit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "MediaInfo bearbeiten"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
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
        Me.Table_AudioSprachen.ResumeLayout(False)
        Me.Table_AudioSprachen.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
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
    Friend WithEvents Table_AudioSprachen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TB_AudioSprachen As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox

End Class
