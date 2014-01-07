<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Fanart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Fanart))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Loadimages = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Tools_1 = New System.Windows.Forms.ToolStrip()
        Me.switcher_logo = New System.Windows.Forms.ToolStripLabel()
        Me.SwitchButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.alle = New System.Windows.Forms.ToolStripButton()
        Me.keine = New System.Windows.Forms.ToolStripButton()
        Me.random = New System.Windows.Forms.ToolStripButton()
        Me.vorschau = New System.Windows.Forms.ToolStripSplitButton()
        Me.KleineSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MittelgroßeSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroßeSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtragroßrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton_Liste = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Ersetzen = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FlowLayoutPanel3 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Tools_1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 46)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(784, 426)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar2.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(784, 12)
        Me.ProgressBar2.TabIndex = 10
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 46)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(784, 426)
        Me.FlowLayoutPanel2.TabIndex = 4
        '
        'Loadimages
        '
        Me.Loadimages.WorkerReportsProgress = True
        Me.Loadimages.WorkerSupportsCancellation = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(586, 497)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Tools_1
        '
        Me.Tools_1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tools_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.switcher_logo, Me.SwitchButton, Me.ToolStripSeparator1, Me.alle, Me.keine, Me.random, Me.vorschau, Me.ToolStripButton_Liste, Me.Ersetzen, Me.ToolStripButton1})
        Me.Tools_1.Location = New System.Drawing.Point(0, 12)
        Me.Tools_1.Name = "Tools_1"
        Me.Tools_1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tools_1.ShowItemToolTips = False
        Me.Tools_1.Size = New System.Drawing.Size(784, 34)
        Me.Tools_1.TabIndex = 8
        Me.Tools_1.Text = "ToolStrip1"
        '
        'switcher_logo
        '
        Me.switcher_logo.BackColor = System.Drawing.Color.Transparent
        Me.switcher_logo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.switcher_logo.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_cover_test
        Me.switcher_logo.Margin = New System.Windows.Forms.Padding(4, 1, 0, 2)
        Me.switcher_logo.Name = "switcher_logo"
        Me.switcher_logo.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.switcher_logo.Size = New System.Drawing.Size(26, 31)
        Me.switcher_logo.Text = "ToolStripLabel1"
        Me.switcher_logo.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'SwitchButton
        '
        Me.SwitchButton.AutoSize = False
        Me.SwitchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.SwitchButton.Image = CType(resources.GetObject("SwitchButton.Image"), System.Drawing.Image)
        Me.SwitchButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SwitchButton.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.SwitchButton.Name = "SwitchButton"
        Me.SwitchButton.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.SwitchButton.Size = New System.Drawing.Size(150, 26)
        Me.SwitchButton.Text = "Backdrops"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'alle
        '
        Me.alle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.alle.Image = CType(resources.GetObject("alle.Image"), System.Drawing.Image)
        Me.alle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.alle.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.alle.Name = "alle"
        Me.alle.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.alle.Size = New System.Drawing.Size(41, 26)
        Me.alle.Text = "Alle"
        '
        'keine
        '
        Me.keine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.keine.Image = CType(resources.GetObject("keine.Image"), System.Drawing.Image)
        Me.keine.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.keine.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.keine.Name = "keine"
        Me.keine.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.keine.Size = New System.Drawing.Size(50, 26)
        Me.keine.Text = "Keine"
        '
        'random
        '
        Me.random.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.random.Image = CType(resources.GetObject("random.Image"), System.Drawing.Image)
        Me.random.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.random.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.random.Name = "random"
        Me.random.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.random.Size = New System.Drawing.Size(51, 26)
        Me.random.Text = "Zufall"
        '
        'vorschau
        '
        Me.vorschau.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.vorschau.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.vorschau.DropDownButtonWidth = 16
        Me.vorschau.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.KleineSymboleToolStripMenuItem, Me.MittelgroßeSymboleToolStripMenuItem, Me.GroßeSymboleToolStripMenuItem, Me.ExtragroßrToolStripMenuItem})
        Me.vorschau.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.vorschau.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.vorschau.Name = "vorschau"
        Me.vorschau.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.vorschau.Size = New System.Drawing.Size(31, 26)
        Me.vorschau.Tag = "0"
        Me.vorschau.Text = "ToolStripDropDownButton1"
        '
        'KleineSymboleToolStripMenuItem
        '
        Me.KleineSymboleToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.View_klein
        Me.KleineSymboleToolStripMenuItem.Name = "KleineSymboleToolStripMenuItem"
        Me.KleineSymboleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.KleineSymboleToolStripMenuItem.Text = "Kleine Symbole"
        '
        'MittelgroßeSymboleToolStripMenuItem
        '
        Me.MittelgroßeSymboleToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.View_mittel
        Me.MittelgroßeSymboleToolStripMenuItem.Name = "MittelgroßeSymboleToolStripMenuItem"
        Me.MittelgroßeSymboleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.MittelgroßeSymboleToolStripMenuItem.Text = "Mittelgroße Symbole"
        '
        'GroßeSymboleToolStripMenuItem
        '
        Me.GroßeSymboleToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.View_groß
        Me.GroßeSymboleToolStripMenuItem.Name = "GroßeSymboleToolStripMenuItem"
        Me.GroßeSymboleToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.GroßeSymboleToolStripMenuItem.Text = "Große Symbole"
        '
        'ExtragroßrToolStripMenuItem
        '
        Me.ExtragroßrToolStripMenuItem.Image = Global.Film_Info__Organizer.Toolbar16.View_extragroß
        Me.ExtragroßrToolStripMenuItem.Name = "ExtragroßrToolStripMenuItem"
        Me.ExtragroßrToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ExtragroßrToolStripMenuItem.Text = "Extragroße Symbole"
        '
        'ToolStripButton_Liste
        '
        Me.ToolStripButton_Liste.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton_Liste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton_Liste.Image = CType(resources.GetObject("ToolStripButton_Liste.Image"), System.Drawing.Image)
        Me.ToolStripButton_Liste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Liste.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton_Liste.Name = "ToolStripButton_Liste"
        Me.ToolStripButton_Liste.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStripButton_Liste.Size = New System.Drawing.Size(23, 26)
        '
        'Ersetzen
        '
        Me.Ersetzen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.Ersetzen.CheckOnClick = True
        Me.Ersetzen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.Ersetzen.Image = CType(resources.GetObject("Ersetzen.Image"), System.Drawing.Image)
        Me.Ersetzen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Ersetzen.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.Ersetzen.Name = "Ersetzen"
        Me.Ersetzen.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Ersetzen.Size = New System.Drawing.Size(64, 26)
        Me.Ersetzen.Text = "Ersetzen"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(3, 3, 3, 5)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.ToolStripButton1.Size = New System.Drawing.Size(47, 26)
        Me.ToolStripButton1.Text = "Auto"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox1.Location = New System.Drawing.Point(0, 472)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(784, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Label1.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_cover_test
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(14, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Label2.Image = Global.Film_Info__Organizer.Toolbar16.staty_16_fanart
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(14, 508)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 18)
        Me.Label2.TabIndex = 16
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FlowLayoutPanel3
        '
        Me.FlowLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.FlowLayoutPanel3.Location = New System.Drawing.Point(93, 479)
        Me.FlowLayoutPanel3.Name = "FlowLayoutPanel3"
        Me.FlowLayoutPanel3.Size = New System.Drawing.Size(487, 51)
        Me.FlowLayoutPanel3.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 426)
        Me.Panel1.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(169, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(243, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Es wurden keine Cover gefunden"
        '
        'Dialog_Fanart
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(784, 538)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Tools_1)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "Dialog_Fanart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cover - Backdrop"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Tools_1.ResumeLayout(False)
        Me.Tools_1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tools_1 As System.Windows.Forms.ToolStrip
    Friend WithEvents keine As System.Windows.Forms.ToolStripButton
    Friend WithEvents alle As System.Windows.Forms.ToolStripButton
    Friend WithEvents random As System.Windows.Forms.ToolStripButton
    Friend WithEvents vorschau As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents GroßeSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KleineSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ExtragroßrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Loadimages As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SwitchButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents MittelgroßeSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel3 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ToolStripButton_Liste As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents switcher_logo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Ersetzen As System.Windows.Forms.ToolStripButton

End Class
