<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Update
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Update))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Blog = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.newText = New System.Windows.Forms.Label()
        Me.newVersion = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.oldVersion = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkLabel21 = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.OK_Button)
        Me.Panel2.Controls.Add(Me.Blog)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 404)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(434, 58)
        Me.Panel2.TabIndex = 68
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Enabled = False
        Me.OK_Button.Image = Global.Film_Info__Organizer.Toolbar16.shield
        Me.OK_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK_Button.Location = New System.Drawing.Point(295, 20)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(127, 26)
        Me.OK_Button.TabIndex = 68
        Me.OK_Button.Tag = "v"
        Me.OK_Button.Text = "Installieren"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Blog
        '
        Me.Blog.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Blog.HoverColor = System.Drawing.Color.Empty
        Me.Blog.Image = Nothing
        Me.Blog.Location = New System.Drawing.Point(12, 27)
        Me.Blog.Name = "Blog"
        Me.Blog.RegularColor = System.Drawing.Color.Empty
        Me.Blog.Size = New System.Drawing.Size(32, 16)
        Me.Blog.TabIndex = 67
        Me.Blog.Text = "Blog"
        '
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(434, 51)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'newText
        '
        Me.newText.AutoSize = True
        Me.newText.ForeColor = System.Drawing.SystemColors.GrayText
        Me.newText.Location = New System.Drawing.Point(12, 43)
        Me.newText.Name = "newText"
        Me.newText.Size = New System.Drawing.Size(232, 15)
        Me.newText.TabIndex = 71
        Me.newText.Text = "Es wurde eine aktuellere Version gefunden."
        '
        'newVersion
        '
        Me.newVersion.AutoSize = True
        Me.newVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.newVersion.Location = New System.Drawing.Point(34, 89)
        Me.newVersion.Name = "newVersion"
        Me.newVersion.Size = New System.Drawing.Size(116, 15)
        Me.newVersion.TabIndex = 72
        Me.newVersion.Text = "Neue Version: 0.2.0.4"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.Film_Info__Organizer.My.Resources.Resources.line
        Me.PictureBox5.Location = New System.Drawing.Point(0, 36)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(411, 2)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 74
        Me.PictureBox5.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(411, 27)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Update"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'oldVersion
        '
        Me.oldVersion.AutoSize = True
        Me.oldVersion.ForeColor = System.Drawing.SystemColors.GrayText
        Me.oldVersion.Location = New System.Drawing.Point(34, 67)
        Me.oldVersion.Name = "oldVersion"
        Me.oldVersion.Size = New System.Drawing.Size(95, 15)
        Me.oldVersion.TabIndex = 75
        Me.oldVersion.Text = "Aktuelle Version:"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox1.Location = New System.Drawing.Point(37, 141)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(374, 256)
        Me.TextBox1.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label6.Location = New System.Drawing.Point(34, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Letzte Änderungen:"
        '
        'LinkLabel21
        '
        Me.LinkLabel21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel21.HoverColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Image = Nothing
        Me.LinkLabel21.Location = New System.Drawing.Point(294, 114)
        Me.LinkLabel21.Name = "LinkLabel21"
        Me.LinkLabel21.RegularColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Size = New System.Drawing.Size(128, 16)
        Me.LinkLabel21.TabIndex = 78
        Me.LinkLabel21.Text = "Kompletter Changelog"
        '
        'Dialog_Update
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(434, 462)
        Me.Controls.Add(Me.oldVersion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LinkLabel21)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.newVersion)
        Me.Controls.Add(Me.newText)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_Update"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents newText As System.Windows.Forms.Label
    Friend WithEvents newVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents oldVersion As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel21 As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents Blog As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents OK_Button As System.Windows.Forms.Button

End Class
