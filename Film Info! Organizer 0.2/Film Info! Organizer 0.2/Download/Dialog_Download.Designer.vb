<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Download
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Download))
        Me.all_dls = New System.Windows.Forms.Label()
        Me.Akt_DLs = New System.Windows.Forms.Label()
        Me.NochKB = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Nochzeit = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.KBperSec = New System.Windows.Forms.Label()
        Me.KBges = New System.Windows.Forms.Label()
        Me.KB = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PRC = New System.Windows.Forms.Label()
        Me.MainList = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.fail_dls = New System.Windows.Forms.Label()
        Me.Nav_dummy = New System.Windows.Forms.ToolStrip()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Column_titel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column_DetStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewDownloadProgressColumn1 = New Film_Info__Organizer.DataGridViewDownloadProgressColumn()
        Me.DataGridViewProgressColumn1 = New Film_Info__Organizer.DataGridViewProgressColumn()
        Me.Tools_1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Ersetzen = New System.Windows.Forms.ToolStripButton()
        Me.MainColumn_Progress = New Film_Info__Organizer.DataGridViewDownloadProgressColumn()
        Me.MainColumn_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainColumn_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MainColumn_Geladen = New Film_Info__Organizer.DataGridViewSizeColumn()
        Me.MainColumn_Gesamt = New Film_Info__Organizer.DataGridViewSizeColumn()
        CType(Me.MainList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tools_1.SuspendLayout()
        Me.SuspendLayout()
        '
        'all_dls
        '
        Me.all_dls.ForeColor = System.Drawing.SystemColors.GrayText
        Me.all_dls.Location = New System.Drawing.Point(404, 47)
        Me.all_dls.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.all_dls.Name = "all_dls"
        Me.all_dls.Size = New System.Drawing.Size(135, 15)
        Me.all_dls.TabIndex = 38
        Me.all_dls.Text = "von 0 Dateien"
        '
        'Akt_DLs
        '
        Me.Akt_DLs.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Akt_DLs.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Akt_DLs.Location = New System.Drawing.Point(260, 40)
        Me.Akt_DLs.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.Akt_DLs.Name = "Akt_DLs"
        Me.Akt_DLs.Size = New System.Drawing.Size(143, 24)
        Me.Akt_DLs.TabIndex = 37
        Me.Akt_DLs.Text = "0"
        Me.Akt_DLs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NochKB
        '
        Me.NochKB.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NochKB.ForeColor = System.Drawing.SystemColors.Highlight
        Me.NochKB.Location = New System.Drawing.Point(625, 8)
        Me.NochKB.Name = "NochKB"
        Me.NochKB.Size = New System.Drawing.Size(231, 24)
        Me.NochKB.TabIndex = 36
        Me.NochKB.Text = "0 KB"
        Me.NochKB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label9.Location = New System.Drawing.Point(583, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 15)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Noch"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label7.Location = New System.Drawing.Point(583, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 15)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Noch"
        '
        'Nochzeit
        '
        Me.Nochzeit.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nochzeit.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Nochzeit.Location = New System.Drawing.Point(625, 40)
        Me.Nochzeit.Name = "Nochzeit"
        Me.Nochzeit.Size = New System.Drawing.Size(231, 24)
        Me.Nochzeit.TabIndex = 33
        Me.Nochzeit.Text = "0 Sekunden"
        Me.Nochzeit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label5.Location = New System.Drawing.Point(404, 13)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "/Sekunde"
        '
        'KBperSec
        '
        Me.KBperSec.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KBperSec.ForeColor = System.Drawing.SystemColors.Highlight
        Me.KBperSec.Location = New System.Drawing.Point(255, 8)
        Me.KBperSec.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.KBperSec.Name = "KBperSec"
        Me.KBperSec.Size = New System.Drawing.Size(148, 24)
        Me.KBperSec.TabIndex = 31
        Me.KBperSec.Text = "0 KB"
        Me.KBperSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'KBges
        '
        Me.KBges.AutoSize = True
        Me.KBges.ForeColor = System.Drawing.SystemColors.GrayText
        Me.KBges.Location = New System.Drawing.Point(148, 47)
        Me.KBges.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.KBges.Name = "KBges"
        Me.KBges.Size = New System.Drawing.Size(43, 15)
        Me.KBges.TabIndex = 30
        Me.KBges.Tag = "100"
        Me.KBges.Text = "/100kb"
        '
        'KB
        '
        Me.KB.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KB.ForeColor = System.Drawing.SystemColors.Highlight
        Me.KB.Location = New System.Drawing.Point(3, 40)
        Me.KB.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.KB.Name = "KB"
        Me.KB.Size = New System.Drawing.Size(145, 24)
        Me.KB.TabIndex = 29
        Me.KB.Text = "10kb"
        Me.KB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(148, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Gesamtfortschritt"
        '
        'PRC
        '
        Me.PRC.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PRC.ForeColor = System.Drawing.SystemColors.Highlight
        Me.PRC.Location = New System.Drawing.Point(8, 8)
        Me.PRC.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.PRC.Name = "PRC"
        Me.PRC.Size = New System.Drawing.Size(140, 24)
        Me.PRC.TabIndex = 27
        Me.PRC.Tag = "0"
        Me.PRC.Text = "50"
        Me.PRC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MainList
        '
        Me.MainList.AllowUserToAddRows = False
        Me.MainList.AllowUserToDeleteRows = False
        Me.MainList.AllowUserToResizeRows = False
        Me.MainList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.MainList.BackgroundColor = System.Drawing.SystemColors.Control
        Me.MainList.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MainList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.MainList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.MainList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MainList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MainColumn_Progress, Me.MainColumn_Name, Me.MainColumn_Status, Me.MainColumn_Geladen, Me.MainColumn_Gesamt})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(254, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MainList.DefaultCellStyle = DataGridViewCellStyle1
        Me.MainList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainList.Location = New System.Drawing.Point(0, 151)
        Me.MainList.MultiSelect = False
        Me.MainList.Name = "MainList"
        Me.MainList.ReadOnly = True
        Me.MainList.RowHeadersVisible = False
        Me.MainList.RowTemplate.Height = 28
        Me.MainList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MainList.Size = New System.Drawing.Size(915, 317)
        Me.MainList.TabIndex = 40
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Nav_dummy)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(915, 117)
        Me.Panel3.TabIndex = 42
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.fail_dls)
        Me.Panel6.Controls.Add(Me.Nochzeit)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.KBperSec)
        Me.Panel6.Controls.Add(Me.NochKB)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.PRC)
        Me.Panel6.Controls.Add(Me.KBges)
        Me.Panel6.Controls.Add(Me.all_dls)
        Me.Panel6.Controls.Add(Me.KB)
        Me.Panel6.Controls.Add(Me.Akt_DLs)
        Me.Panel6.Location = New System.Drawing.Point(14, 27)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(875, 76)
        Me.Panel6.TabIndex = 51
        '
        'fail_dls
        '
        Me.fail_dls.AutoSize = True
        Me.fail_dls.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fail_dls.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.fail_dls.Location = New System.Drawing.Point(450, 62)
        Me.fail_dls.Name = "fail_dls"
        Me.fail_dls.Size = New System.Drawing.Size(0, 13)
        Me.fail_dls.TabIndex = 39
        '
        'Nav_dummy
        '
        Me.Nav_dummy.AutoSize = False
        Me.Nav_dummy.BackColor = System.Drawing.SystemColors.Window
        Me.Nav_dummy.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_dummy.Location = New System.Drawing.Point(0, 0)
        Me.Nav_dummy.Name = "Nav_dummy"
        Me.Nav_dummy.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_dummy.Size = New System.Drawing.Size(915, 23)
        Me.Nav_dummy.TabIndex = 50
        Me.Nav_dummy.Text = "ToolStrip1"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(915, 1)
        Me.Panel2.TabIndex = 45
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.Controls.Add(Me.PictureBox3)
        Me.Panel4.Controls.Add(Me.DataGridView2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 468)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(915, 166)
        Me.Panel4.TabIndex = 47
        Me.Panel4.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.Image = Global.Film_Info__Organizer.Toolbar16.exit_normal
        Me.PictureBox3.Location = New System.Drawing.Point(895, 18)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 49
        Me.PictureBox3.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.ColumnHeadersVisible = False
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column_titel, Me.Column_DetStatus})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.GridColor = System.Drawing.SystemColors.Window
        Me.DataGridView2.Location = New System.Drawing.Point(0, 40)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(915, 126)
        Me.DataGridView2.TabIndex = 47
        '
        'Column_titel
        '
        Me.Column_titel.FillWeight = 80.0!
        Me.Column_titel.HeaderText = "Name"
        Me.Column_titel.Name = "Column_titel"
        Me.Column_titel.ReadOnly = True
        '
        'Column_DetStatus
        '
        Me.Column_DetStatus.FillWeight = 20.0!
        Me.Column_DetStatus.HeaderText = "Status"
        Me.Column_DetStatus.Name = "Column_DetStatus"
        Me.Column_DetStatus.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(0, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(915, 22)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.BackgroundImage = Global.Film_Info__Organizer.My.Resources.Resources.shadow_gray_up
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(915, 17)
        Me.PictureBox2.TabIndex = 46
        Me.PictureBox2.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Window
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 150)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(915, 1)
        Me.Panel5.TabIndex = 48
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'DataGridViewDownloadProgressColumn1
        '
        Me.DataGridViewDownloadProgressColumn1.HeaderText = "Fortschritt"
        Me.DataGridViewDownloadProgressColumn1.Name = "DataGridViewDownloadProgressColumn1"
        Me.DataGridViewDownloadProgressColumn1.Width = 175
        '
        'DataGridViewProgressColumn1
        '
        Me.DataGridViewProgressColumn1.HeaderText = "Fortschritt"
        Me.DataGridViewProgressColumn1.Name = "DataGridViewProgressColumn1"
        Me.DataGridViewProgressColumn1.Width = 170
        '
        'Tools_1
        '
        Me.Tools_1.BackColor = System.Drawing.SystemColors.Window
        Me.Tools_1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tools_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.Ersetzen})
        Me.Tools_1.Location = New System.Drawing.Point(0, 0)
        Me.Tools_1.Name = "Tools_1"
        Me.Tools_1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tools_1.ShowItemToolTips = False
        Me.Tools_1.Size = New System.Drawing.Size(915, 33)
        Me.Tools_1.TabIndex = 49
        Me.Tools_1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStripButton1.Size = New System.Drawing.Size(81, 25)
        Me.ToolStripButton1.Text = "Aufräumen"
        '
        'Ersetzen
        '
        Me.Ersetzen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Ersetzen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Ersetzen.Image = CType(resources.GetObject("Ersetzen.Image"), System.Drawing.Image)
        Me.Ersetzen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Ersetzen.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.Ersetzen.Name = "Ersetzen"
        Me.Ersetzen.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Ersetzen.Size = New System.Drawing.Size(58, 25)
        Me.Ersetzen.Text = "Starten"
        '
        'MainColumn_Progress
        '
        Me.MainColumn_Progress.HeaderText = "Fortschritt"
        Me.MainColumn_Progress.Name = "MainColumn_Progress"
        Me.MainColumn_Progress.ReadOnly = True
        '
        'MainColumn_Name
        '
        Me.MainColumn_Name.HeaderText = "Name"
        Me.MainColumn_Name.Name = "MainColumn_Name"
        Me.MainColumn_Name.ReadOnly = True
        '
        'MainColumn_Status
        '
        Me.MainColumn_Status.HeaderText = "Status"
        Me.MainColumn_Status.Name = "MainColumn_Status"
        Me.MainColumn_Status.ReadOnly = True
        '
        'MainColumn_Geladen
        '
        Me.MainColumn_Geladen.HeaderText = "Geladen"
        Me.MainColumn_Geladen.Name = "MainColumn_Geladen"
        Me.MainColumn_Geladen.ReadOnly = True
        Me.MainColumn_Geladen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'MainColumn_Gesamt
        '
        Me.MainColumn_Gesamt.HeaderText = "Gesamt"
        Me.MainColumn_Gesamt.Name = "MainColumn_Gesamt"
        Me.MainColumn_Gesamt.ReadOnly = True
        Me.MainColumn_Gesamt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Dialog_Download
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(915, 634)
        Me.Controls.Add(Me.MainList)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Tools_1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(931, 419)
        Me.Name = "Dialog_Download"
        Me.Text = "Download"
        CType(Me.MainList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tools_1.ResumeLayout(False)
        Me.Tools_1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents all_dls As System.Windows.Forms.Label
    Friend WithEvents Akt_DLs As System.Windows.Forms.Label
    Friend WithEvents NochKB As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Nochzeit As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents KBperSec As System.Windows.Forms.Label
    Friend WithEvents KBges As System.Windows.Forms.Label
    Friend WithEvents KB As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PRC As System.Windows.Forms.Label
    Friend WithEvents MainList As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewProgressColumn1 As Film_Info__Organizer.DataGridViewProgressColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Column_titel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column_DetStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DataGridViewDownloadProgressColumn1 As Film_Info__Organizer.DataGridViewDownloadProgressColumn
    Friend WithEvents Tools_1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Ersetzen As System.Windows.Forms.ToolStripButton
    Friend WithEvents Nav_dummy As System.Windows.Forms.ToolStrip
    Friend WithEvents fail_dls As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents MainColumn_Progress As Film_Info__Organizer.DataGridViewDownloadProgressColumn
    Friend WithEvents MainColumn_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainColumn_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MainColumn_Geladen As Film_Info__Organizer.DataGridViewSizeColumn
    Friend WithEvents MainColumn_Gesamt As Film_Info__Organizer.DataGridViewSizeColumn
End Class
