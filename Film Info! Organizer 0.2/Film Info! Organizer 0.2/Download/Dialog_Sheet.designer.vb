<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Sheet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Sheet))
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Loadimages = New System.ComponentModel.BackgroundWorker()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Tools_1 = New System.Windows.Forms.ToolStrip()
        Me.vorschau = New System.Windows.Forms.ToolStripSplitButton()
        Me.KleineSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MittelgroßeSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroßeSymboleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtragroßrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Tools_1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 51)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(660, 245)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Dock = System.Windows.Forms.DockStyle.Top
        Me.ProgressBar2.Location = New System.Drawing.Point(0, 0)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(660, 12)
        Me.ProgressBar2.TabIndex = 10
        Me.ProgressBar2.Visible = False
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(462, 321)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'Tools_1
        '
        Me.Tools_1.AutoSize = False
        Me.Tools_1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.Tools_1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.vorschau, Me.ToolStripLabel1})
        Me.Tools_1.Location = New System.Drawing.Point(0, 12)
        Me.Tools_1.Name = "Tools_1"
        Me.Tools_1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.Tools_1.ShowItemToolTips = False
        Me.Tools_1.Size = New System.Drawing.Size(660, 39)
        Me.Tools_1.TabIndex = 8
        Me.Tools_1.Text = "ToolStrip1"
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
        Me.vorschau.Padding = New System.Windows.Forms.Padding(5)
        Me.vorschau.Size = New System.Drawing.Size(31, 31)
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(208, 36)
        Me.ToolStripLabel1.Text = "Löschen Sie ungewünschte Backdrops"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox1.Location = New System.Drawing.Point(0, 296)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(660, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(17, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
        Me.Panel1.Size = New System.Drawing.Size(609, 205)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(607, 203)
        Me.Panel2.TabIndex = 0
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.Image = Global.Film_Info__Organizer.Toolbar16.exit_normal
        Me.PictureBox3.Location = New System.Drawing.Point(583, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 51
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Location = New System.Drawing.Point(3, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(600, 172)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Dialog_Sheet
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(660, 362)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Tools_1)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(676, 400)
        Me.Name = "Dialog_Sheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MovieSheets"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Tools_1.ResumeLayout(False)
        Me.Tools_1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Tools_1 As System.Windows.Forms.ToolStrip
    Friend WithEvents vorschau As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents GroßeSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KleineSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ExtragroßrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents Loadimages As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MittelgroßeSymboleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel

End Class
