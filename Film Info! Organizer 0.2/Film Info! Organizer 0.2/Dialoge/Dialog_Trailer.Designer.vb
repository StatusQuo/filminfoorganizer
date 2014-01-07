<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Trailer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Trailer))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("genaue Ergebnisse", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ähnliche Ergebnisse", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("ungefähre Ergebnisse", System.Windows.Forms.HorizontalAlignment.Left)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel_trailer = New System.Windows.Forms.Panel()
        Me.TreeViewVista1 = New Film_Info__Organizer.TreeViewVista()
        Me.Panel_Suche = New System.Windows.Forms.Panel()
        Me.ListViewVista1 = New Film_Info__Organizer.ListViewVista()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTextBox_Suche = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Player = New Film_Info__Organizer.UserControl2()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_trailer.SuspendLayout()
        Me.Panel_Suche.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 385)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(835, 49)
        Me.Panel2.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(12, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(612, 32)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Bei drücken auf ""OK"" wird dieser Trailer in der besten verfügbaren Qualität herun" & _
            "tergeladen."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(637, 8)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel2.TabIndex = 67
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
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(835, 41)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Label1.Size = New System.Drawing.Size(81, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Trailer wählen"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "dum.png")
        Me.ImageList1.Images.SetKeyName(1, "de.png")
        Me.ImageList1.Images.SetKeyName(2, "gb.png")
        Me.ImageList1.Images.SetKeyName(3, "us.png")
        Me.ImageList1.Images.SetKeyName(4, "qu_hd.png")
        Me.ImageList1.Images.SetKeyName(5, "qu_hq.png")
        Me.ImageList1.Images.SetKeyName(6, "qu_sd.png")
        '
        'Panel_trailer
        '
        Me.Panel_trailer.BackColor = System.Drawing.SystemColors.Window
        Me.Panel_trailer.Controls.Add(Me.TreeViewVista1)
        Me.Panel_trailer.Controls.Add(Me.Label1)
        Me.Panel_trailer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_trailer.Location = New System.Drawing.Point(0, 0)
        Me.Panel_trailer.Name = "Panel_trailer"
        Me.Panel_trailer.Size = New System.Drawing.Size(200, 351)
        Me.Panel_trailer.TabIndex = 24
        '
        'TreeViewVista1
        '
        Me.TreeViewVista1._Autosize = False
        Me.TreeViewVista1.BackColor = System.Drawing.SystemColors.Window
        Me.TreeViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewVista1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewVista1.FullRowSelect = True
        Me.TreeViewVista1.HideSelection = False
        Me.TreeViewVista1.HotTracking = True
        Me.TreeViewVista1.ImageIndex = 0
        Me.TreeViewVista1.ImageList = Me.ImageList1
        Me.TreeViewVista1.Location = New System.Drawing.Point(0, 25)
        Me.TreeViewVista1.Name = "TreeViewVista1"
        Me.TreeViewVista1.SelectedImageIndex = 0
        Me.TreeViewVista1.ShowLines = False
        Me.TreeViewVista1.Size = New System.Drawing.Size(200, 326)
        Me.TreeViewVista1.TabIndex = 13
        '
        'Panel_Suche
        '
        Me.Panel_Suche.BackColor = System.Drawing.SystemColors.Window
        Me.Panel_Suche.Controls.Add(Me.ListViewVista1)
        Me.Panel_Suche.Controls.Add(Me.Label2)
        Me.Panel_Suche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Suche.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Suche.Name = "Panel_Suche"
        Me.Panel_Suche.Size = New System.Drawing.Size(200, 351)
        Me.Panel_Suche.TabIndex = 28
        '
        'ListViewVista1
        '
        Me.ListViewVista1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListViewVista1.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewVista1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.ListViewVista1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewVista1.FullRowSelect = True
        ListViewGroup1.Header = "genaue Ergebnisse"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "ähnliche Ergebnisse"
        ListViewGroup2.Name = "ListViewGroup2"
        ListViewGroup3.Header = "ungefähre Ergebnisse"
        ListViewGroup3.Name = "ListViewGroup3"
        Me.ListViewVista1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        Me.ListViewVista1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListViewVista1.HideSelection = False
        Me.ListViewVista1.HotTracking = True
        Me.ListViewVista1.HoverSelection = True
        Me.ListViewVista1.LabelWrap = False
        Me.ListViewVista1.Location = New System.Drawing.Point(0, 25)
        Me.ListViewVista1.Name = "ListViewVista1"
        Me.ListViewVista1.Size = New System.Drawing.Size(200, 326)
        Me.ListViewVista1.TabIndex = 31
        Me.ListViewVista1.UseCompatibleStateImageBehavior = False
        Me.ListViewVista1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 180
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 5)
        Me.Label2.Size = New System.Drawing.Size(71, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Film wählen"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel_Suche)
        Me.Panel1.Controls.Add(Me.Panel_trailer)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 34)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 351)
        Me.Panel1.TabIndex = 29
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.Image = Global.Film_Info__Organizer.My.Resources.Resources.threepixline_l
        Me.PictureBox1.Location = New System.Drawing.Point(200, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(3, 351)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox_Suche, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(835, 34)
        Me.ToolStrip1.TabIndex = 31
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripTextBox_Suche
        '
        Me.ToolStripTextBox_Suche.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ToolStripTextBox_Suche.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ToolStripTextBox_Suche.Margin = New System.Windows.Forms.Padding(2, 0, 4, 0)
        Me.ToolStripTextBox_Suche.Name = "ToolStripTextBox_Suche"
        Me.ToolStripTextBox_Suche.Size = New System.Drawing.Size(230, 34)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Film_Info__Organizer.Toolbar16.Suche
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton1.Size = New System.Drawing.Size(32, 26)
        Me.ToolStripButton1.Text = " Suchen"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ToolStripButton2.Image = Global.Film_Info__Organizer.Toolbar16.back
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton2.Size = New System.Drawing.Size(76, 26)
        Me.ToolStripButton2.Text = "Zurück"
        Me.ToolStripButton2.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Padding = New System.Windows.Forms.Padding(6, 3, 6, 3)
        Me.ToolStripButton3.Size = New System.Drawing.Size(38, 26)
        Me.ToolStripButton3.Text = "8"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ElementHost1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(203, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(632, 351)
        Me.Panel3.TabIndex = 33
        '
        'ElementHost1
        '
        Me.ElementHost1.BackColor = System.Drawing.Color.Black
        Me.ElementHost1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(632, 351)
        Me.ElementHost1.TabIndex = 15
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.Player
        '
        'Dialog_Trailer
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(835, 434)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "Dialog_Trailer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trailer wählen"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_trailer.ResumeLayout(False)
        Me.Panel_trailer.PerformLayout()
        Me.Panel_Suche.ResumeLayout(False)
        Me.Panel_Suche.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents TreeViewVista1 As Film_Info__Organizer.TreeViewVista
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents Player As Film_Info__Organizer.UserControl2
    Friend WithEvents Panel_trailer As System.Windows.Forms.Panel
    Friend WithEvents Panel_Suche As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListViewVista1 As Film_Info__Organizer.ListViewVista
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripTextBox_Suche As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripDropDownButton

End Class
