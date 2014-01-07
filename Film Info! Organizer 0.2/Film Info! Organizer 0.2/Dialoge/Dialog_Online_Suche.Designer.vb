<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_OnlineSuche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_OnlineSuche))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("IMDb-ID", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("themoviedb", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Online Film Datenbank", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("IMDb", System.Windows.Forms.HorizontalAlignment.Left)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTextBox_Suche = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.exp_sep = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton_Abbrechen = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Genre = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_Inhalt = New System.Windows.Forms.RichTextBox()
        Me.lbl_jahr = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbl_titel = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Regie = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_bewertung = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.lbl_Land = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lbl_otitel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl_darsteller = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_inhaltfull = New System.Windows.Forms.RichTextBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Nav_Datagrid = New System.Windows.Forms.ToolStrip()
        Me.lbl_Ordner = New System.Windows.Forms.ToolStripLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.ListViewVista1 = New Film_Info__Organizer.ListViewVista()
        Me.ColumnHeader1 = CType(New Film_Info__Organizer.ColHeader(), Film_Info__Organizer.ColHeader)
        Me.ColumnHeader2 = CType(New Film_Info__Organizer.ColHeader(), Film_Info__Organizer.ColHeader)
        Me.lbl_imdbid = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.CheckBox1 = New Film_Info__Organizer.LightButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Nav_Datagrid.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(804, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
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
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox_Suche, Me.ToolStripButton1, Me.exp_sep, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripButton_Abbrechen, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripDropDownButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(1002, 36)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripTextBox_Suche
        '
        Me.ToolStripTextBox_Suche.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ToolStripTextBox_Suche.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripTextBox_Suche.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ToolStripTextBox_Suche.Name = "ToolStripTextBox_Suche"
        Me.ToolStripTextBox_Suche.Size = New System.Drawing.Size(250, 36)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Film_Info__Organizer.Toolbar16.Suche
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton1.Size = New System.Drawing.Size(81, 28)
        Me.ToolStripButton1.Text = " Suchen"
        '
        'exp_sep
        '
        Me.exp_sep.AutoSize = False
        Me.exp_sep.Name = "exp_sep"
        Me.exp_sep.Size = New System.Drawing.Size(8, 36)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.Film_Info__Organizer.Toolbar16.search_exact
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton3.Size = New System.Drawing.Size(32, 28)
        Me.ToolStripButton3.Text = "Aktuellen Film auswählen"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Film_Info__Organizer.Toolbar16.View_extragroß
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton2.Size = New System.Drawing.Size(32, 28)
        Me.ToolStripButton2.Text = "Cover & Backdrops..."
        '
        'ToolStripButton_Abbrechen
        '
        Me.ToolStripButton_Abbrechen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton_Abbrechen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Abbrechen.Image = Global.Film_Info__Organizer.Toolbar16.exiticon
        Me.ToolStripButton_Abbrechen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Abbrechen.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton_Abbrechen.Name = "ToolStripButton_Abbrechen"
        Me.ToolStripButton_Abbrechen.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton_Abbrechen.Size = New System.Drawing.Size(124, 28)
        Me.ToolStripButton_Abbrechen.Text = "Alle Abbrechen ()"
        Me.ToolStripButton_Abbrechen.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.Film_Info__Organizer.Toolbar16.check_result
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton4.Size = New System.Drawing.Size(32, 28)
        Me.ToolStripButton4.Text = "Suchergebnis bearbeiten..."
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.Film_Info__Organizer.Toolbar16.Play
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton5.Size = New System.Drawing.Size(32, 28)
        Me.ToolStripButton5.Text = "Abspielen"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = Global.Film_Info__Organizer.Toolbar16.Write001
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(41, 28)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Menu
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(629, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(373, 536)
        Me.Panel1.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.Controls.Add(Me.CheckBox1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(2)
        Me.Panel6.Size = New System.Drawing.Size(27, 536)
        Me.Panel6.TabIndex = 5
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lbl_Inhalt, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.lbl_jahr, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.PictureBox1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lbl_titel, 0, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(31, 8)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(330, 516)
        Me.TableLayoutPanel3.TabIndex = 24
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoSize = True
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.lbl_Genre, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 339)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(330, 15)
        Me.TableLayoutPanel4.TabIndex = 25
        '
        'lbl_Genre
        '
        Me.lbl_Genre.AutoEllipsis = True
        Me.lbl_Genre.AutoSize = True
        Me.lbl_Genre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Genre.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Genre.Location = New System.Drawing.Point(41, 0)
        Me.lbl_Genre.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_Genre.Name = "lbl_Genre"
        Me.lbl_Genre.Size = New System.Drawing.Size(289, 15)
        Me.lbl_Genre.TabIndex = 5
        Me.lbl_Genre.Text = "..."
        Me.lbl_Genre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Genre:"
        '
        'lbl_Inhalt
        '
        Me.lbl_Inhalt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_Inhalt.BackColor = System.Drawing.SystemColors.Menu
        Me.lbl_Inhalt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbl_Inhalt.Location = New System.Drawing.Point(3, 375)
        Me.lbl_Inhalt.Name = "lbl_Inhalt"
        Me.lbl_Inhalt.Size = New System.Drawing.Size(324, 138)
        Me.lbl_Inhalt.TabIndex = 20
        Me.lbl_Inhalt.Text = ""
        '
        'lbl_jahr
        '
        Me.lbl_jahr.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_jahr.AutoSize = True
        Me.lbl_jahr.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_jahr.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_jahr.Location = New System.Drawing.Point(311, 21)
        Me.lbl_jahr.Name = "lbl_jahr"
        Me.lbl_jahr.Size = New System.Drawing.Size(16, 15)
        Me.lbl_jahr.TabIndex = 17
        Me.lbl_jahr.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(0, 357)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Beschreibung: "
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.Film_Info__Organizer.My.Resources.Resources.no_cover_bg
        Me.PictureBox1.Location = New System.Drawing.Point(3, 39)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(324, 294)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'lbl_titel
        '
        Me.lbl_titel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_titel.AutoEllipsis = True
        Me.lbl_titel.AutoSize = True
        Me.lbl_titel.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titel.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.lbl_titel.Location = New System.Drawing.Point(3, 0)
        Me.lbl_titel.Name = "lbl_titel"
        Me.lbl_titel.Size = New System.Drawing.Size(324, 21)
        Me.lbl_titel.TabIndex = 16
        Me.lbl_titel.Text = "..."
        Me.lbl_titel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.Image = Global.Film_Info__Organizer.My.Resources.Resources.ajaxloaderbig
        Me.PictureBox4.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 23
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Ok.png")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Menu
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Controls.Add(Me.PictureBox5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(331, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(297, 536)
        Me.Panel2.TabIndex = 12
        Me.Panel2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = Global.Film_Info__Organizer.My.Resources.Resources.shadow_gray_left
        Me.PictureBox3.Location = New System.Drawing.Point(281, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 536)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 14
        Me.PictureBox3.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel8, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel7, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_otitel, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_darsteller, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.lbl_inhaltfull, 0, 8)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 8)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 9
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(271, 516)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.AutoSize = True
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.Label10, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.lbl_imdbid, 1, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0, 9, 0, 3)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(271, 16)
        Me.TableLayoutPanel8.TabIndex = 29
        '
        'Label10
        '
        Me.Label10.AutoEllipsis = True
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Margin = New System.Windows.Forms.Padding(0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Online:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.AutoSize = True
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Controls.Add(Me.lbl_Regie, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(0, 46)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(271, 15)
        Me.TableLayoutPanel7.TabIndex = 28
        '
        'lbl_Regie
        '
        Me.lbl_Regie.AutoEllipsis = True
        Me.lbl_Regie.AutoSize = True
        Me.lbl_Regie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Regie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Regie.Location = New System.Drawing.Point(39, 0)
        Me.lbl_Regie.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_Regie.Name = "lbl_Regie"
        Me.lbl_Regie.Size = New System.Drawing.Size(232, 15)
        Me.lbl_Regie.TabIndex = 5
        Me.lbl_Regie.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoEllipsis = True
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Margin = New System.Windows.Forms.Padding(0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Regie:"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.AutoSize = True
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.lbl_bewertung, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label8, 0, 0)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 88)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 1
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(271, 15)
        Me.TableLayoutPanel5.TabIndex = 26
        '
        'lbl_bewertung
        '
        Me.lbl_bewertung.AutoEllipsis = True
        Me.lbl_bewertung.AutoSize = True
        Me.lbl_bewertung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_bewertung.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_bewertung.Location = New System.Drawing.Point(67, 0)
        Me.lbl_bewertung.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_bewertung.Name = "lbl_bewertung"
        Me.lbl_bewertung.Size = New System.Drawing.Size(204, 15)
        Me.lbl_bewertung.TabIndex = 5
        Me.lbl_bewertung.Text = "..."
        '
        'Label8
        '
        Me.Label8.AutoEllipsis = True
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Bewertung:"
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSize = True
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.lbl_Land, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(0, 67)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(271, 15)
        Me.TableLayoutPanel6.TabIndex = 27
        '
        'lbl_Land
        '
        Me.lbl_Land.AutoEllipsis = True
        Me.lbl_Land.AutoSize = True
        Me.lbl_Land.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_Land.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_Land.Location = New System.Drawing.Point(97, 0)
        Me.lbl_Land.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_Land.Name = "lbl_Land"
        Me.lbl_Land.Size = New System.Drawing.Size(174, 15)
        Me.lbl_Land.TabIndex = 5
        Me.lbl_Land.Text = "..."
        '
        'Label9
        '
        Me.Label9.AutoEllipsis = True
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Produktionsland:"
        '
        'lbl_otitel
        '
        Me.lbl_otitel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_otitel.AutoEllipsis = True
        Me.lbl_otitel.AutoSize = True
        Me.lbl_otitel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_otitel.Location = New System.Drawing.Point(3, 0)
        Me.lbl_otitel.Name = "lbl_otitel"
        Me.lbl_otitel.Size = New System.Drawing.Size(265, 15)
        Me.lbl_otitel.TabIndex = 19
        Me.lbl_otitel.Text = "..."
        Me.lbl_otitel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoEllipsis = True
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(0, 311)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Inhalt: "
        '
        'lbl_darsteller
        '
        Me.lbl_darsteller.BackColor = System.Drawing.SystemColors.Menu
        Me.lbl_darsteller.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbl_darsteller.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_darsteller.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_darsteller.Location = New System.Drawing.Point(3, 124)
        Me.lbl_darsteller.Name = "lbl_darsteller"
        Me.lbl_darsteller.ReadOnly = True
        Me.lbl_darsteller.Size = New System.Drawing.Size(265, 184)
        Me.lbl_darsteller.TabIndex = 27
        Me.lbl_darsteller.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label7.Location = New System.Drawing.Point(0, 106)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Darsteller: "
        '
        'lbl_inhaltfull
        '
        Me.lbl_inhaltfull.BackColor = System.Drawing.SystemColors.Menu
        Me.lbl_inhaltfull.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbl_inhaltfull.Cursor = System.Windows.Forms.Cursors.Default
        Me.lbl_inhaltfull.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_inhaltfull.Location = New System.Drawing.Point(3, 329)
        Me.lbl_inhaltfull.Name = "lbl_inhaltfull"
        Me.lbl_inhaltfull.ReadOnly = True
        Me.lbl_inhaltfull.Size = New System.Drawing.Size(265, 184)
        Me.lbl_inhaltfull.TabIndex = 29
        Me.lbl_inhaltfull.Text = ""
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox5.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(1, 536)
        Me.PictureBox5.TabIndex = 11
        Me.PictureBox5.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Menu
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(331, 511)
        Me.Panel3.TabIndex = 13
        Me.Panel3.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Menu
        Me.Panel4.Controls.Add(Me.PictureBox6)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Location = New System.Drawing.Point(14, 249)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(406, 90)
        Me.Panel4.TabIndex = 4
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.Film_Info__Organizer.My.Resources.Resources.warning
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(264, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(134, 27)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Nochmals versuchen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(63, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Kein Verbindungsaufbau möglich"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(64, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(320, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Sie besitzen möglicherweise keine Verbindung zum Internet"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Location = New System.Drawing.Point(628, 36)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1, 536)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'Nav_Datagrid
        '
        Me.Nav_Datagrid.BackColor = System.Drawing.SystemColors.Window
        Me.Nav_Datagrid.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Nav_Datagrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Ordner})
        Me.Nav_Datagrid.Location = New System.Drawing.Point(0, 36)
        Me.Nav_Datagrid.Name = "Nav_Datagrid"
        Me.Nav_Datagrid.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Nav_Datagrid.Size = New System.Drawing.Size(331, 25)
        Me.Nav_Datagrid.TabIndex = 14
        Me.Nav_Datagrid.Text = "ToolStrip1"
        '
        'lbl_Ordner
        '
        Me.lbl_Ordner.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Ordner.Image = Global.Film_Info__Organizer.Toolbar16.Folder124
        Me.lbl_Ordner.Name = "lbl_Ordner"
        Me.lbl_Ordner.Size = New System.Drawing.Size(16, 22)
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel5.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel5.Controls.Add(Me.PictureBox26)
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 572)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1002, 49)
        Me.Panel5.TabIndex = 30
        '
        'PictureBox26
        '
        Me.PictureBox26.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox26.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox26.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox26.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(1002, 41)
        Me.PictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox26.TabIndex = 66
        Me.PictureBox26.TabStop = False
        '
        'ListViewVista1
        '
        Me.ListViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewVista1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewVista1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewVista1.FullRowSelect = True
        ListViewGroup1.Header = "IMDb-ID"
        ListViewGroup1.Name = "IMDBID"
        ListViewGroup2.Header = "themoviedb"
        ListViewGroup2.Name = "tmdb"
        ListViewGroup3.Header = "Online Film Datenbank"
        ListViewGroup3.Name = "OFDb.de"
        ListViewGroup4.Header = "IMDb"
        ListViewGroup4.Name = "Group_IMDb"
        Me.ListViewVista1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.ListViewVista1.Location = New System.Drawing.Point(0, 61)
        Me.ListViewVista1.MultiSelect = False
        Me.ListViewVista1.Name = "ListViewVista1"
        Me.ListViewVista1.Size = New System.Drawing.Size(331, 511)
        Me.ListViewVista1.SmallImageList = Me.ImageList1
        Me.ListViewVista1.TabIndex = 9
        Me.ListViewVista1.UseCompatibleStateImageBehavior = False
        Me.ListViewVista1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Titel"
        Me.ColumnHeader1.Width = 300
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Jahr"
        '
        'lbl_imdbid
        '
        Me.lbl_imdbid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbl_imdbid.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbl_imdbid.HoverColor = System.Drawing.Color.Empty
        Me.lbl_imdbid.Image = Nothing
        Me.lbl_imdbid.Location = New System.Drawing.Point(45, 0)
        Me.lbl_imdbid.Margin = New System.Windows.Forms.Padding(0)
        Me.lbl_imdbid.Name = "lbl_imdbid"
        Me.lbl_imdbid.RegularColor = System.Drawing.Color.Empty
        Me.lbl_imdbid.Size = New System.Drawing.Size(226, 16)
        Me.lbl_imdbid.TabIndex = 30
        Me.lbl_imdbid.Text = "..."
        '
        'CheckBox1
        '
        Me.CheckBox1._Enabled = True
        Me.CheckBox1.Checked = False
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.CheckBox1.Location = New System.Drawing.Point(2, 2)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(5)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Padding = New System.Windows.Forms.Padding(1)
        Me.CheckBox1.Size = New System.Drawing.Size(23, 532)
        Me.CheckBox1.TabIndex = 14
        Me.CheckBox1.Visible = False
        '
        'Dialog_OnlineSuche
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1002, 621)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ListViewVista1)
        Me.Controls.Add(Me.Nav_Datagrid)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(673, 651)
        Me.Name = "Dialog_OnlineSuche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Nav_Datagrid.ResumeLayout(False)
        Me.Nav_Datagrid.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListViewVista1 As Film_Info__Organizer.ListViewVista
    Friend WithEvents lbl_Inhalt As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbl_jahr As System.Windows.Forms.Label
    Friend WithEvents lbl_titel As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbl_otitel As System.Windows.Forms.Label
    Friend WithEvents lbl_inhaltfull As System.Windows.Forms.RichTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_darsteller As System.Windows.Forms.RichTextBox
    Friend WithEvents lbl_imdbid As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CheckBox1 As Film_Info__Organizer.LightButton
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripButton_Abbrechen As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ColumnHeader1 As Film_Info__Organizer.ColHeader
    Friend WithEvents ColumnHeader2 As Film_Info__Organizer.ColHeader
    Friend WithEvents Nav_Datagrid As System.Windows.Forms.ToolStrip
    Friend WithEvents lbl_Ordner As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents exp_sep As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox_Suche As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Genre As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Regie As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_bewertung As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lbl_Land As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel

End Class
