<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Player
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Player))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.v1 = New System.Windows.Forms.Label()
        Me.a1 = New System.Windows.Forms.Label()
        Me.l1 = New System.Windows.Forms.Button()
        Me.s1 = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.s2 = New System.Windows.Forms.RadioButton()
        Me.l2 = New System.Windows.Forms.Button()
        Me.a2 = New System.Windows.Forms.Label()
        Me.v2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.Player1 = New Film_Info__Organizer.UserControl2()
        Me.ElementHost2 = New System.Windows.Forms.Integration.ElementHost()
        Me.Player2 = New Film_Info__Organizer.UserControl2()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.50267!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1016, 426)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ElementHost2)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(508, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(508, 426)
        Me.Panel3.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ElementHost1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(508, 426)
        Me.Panel2.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel4.Controls.Add(Me.s1)
        Me.Panel4.Controls.Add(Me.l1)
        Me.Panel4.Controls.Add(Me.a1)
        Me.Panel4.Controls.Add(Me.v1)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 346)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(508, 80)
        Me.Panel4.TabIndex = 4
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox2.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(508, 47)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 66
        Me.PictureBox2.TabStop = False
        '
        'v1
        '
        Me.v1.AutoSize = True
        Me.v1.Location = New System.Drawing.Point(15, 8)
        Me.v1.Name = "v1"
        Me.v1.Size = New System.Drawing.Size(40, 15)
        Me.v1.TabIndex = 67
        Me.v1.Text = "Video:"
        '
        'a1
        '
        Me.a1.AutoSize = True
        Me.a1.Location = New System.Drawing.Point(14, 32)
        Me.a1.Name = "a1"
        Me.a1.Size = New System.Drawing.Size(42, 15)
        Me.a1.TabIndex = 68
        Me.a1.Text = "Audio:"
        '
        'l1
        '
        Me.l1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l1.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.l1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.l1.Location = New System.Drawing.Point(319, 37)
        Me.l1.Name = "l1"
        Me.l1.Size = New System.Drawing.Size(183, 31)
        Me.l1.TabIndex = 69
        Me.l1.Text = "Diesen Film löschen"
        Me.l1.UseVisualStyleBackColor = True
        '
        's1
        '
        Me.s1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.s1.AutoSize = True
        Me.s1.Checked = True
        Me.s1.Location = New System.Drawing.Point(453, 10)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(46, 19)
        Me.s1.TabIndex = 70
        Me.s1.TabStop = True
        Me.s1.Text = "Ton"
        Me.s1.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel5.Controls.Add(Me.s2)
        Me.Panel5.Controls.Add(Me.l2)
        Me.Panel5.Controls.Add(Me.a2)
        Me.Panel5.Controls.Add(Me.v2)
        Me.Panel5.Controls.Add(Me.PictureBox3)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 346)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(508, 80)
        Me.Panel5.TabIndex = 5
        '
        's2
        '
        Me.s2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.s2.AutoSize = True
        Me.s2.Location = New System.Drawing.Point(453, 10)
        Me.s2.Name = "s2"
        Me.s2.Size = New System.Drawing.Size(46, 19)
        Me.s2.TabIndex = 70
        Me.s2.TabStop = True
        Me.s2.Text = "Ton"
        Me.s2.UseVisualStyleBackColor = True
        '
        'l2
        '
        Me.l2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.l2.Image = Global.Film_Info__Organizer.Toolbar16.Löschen
        Me.l2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.l2.Location = New System.Drawing.Point(319, 37)
        Me.l2.Name = "l2"
        Me.l2.Size = New System.Drawing.Size(183, 31)
        Me.l2.TabIndex = 69
        Me.l2.Text = "Diesen Film löschen"
        Me.l2.UseVisualStyleBackColor = True
        '
        'a2
        '
        Me.a2.AutoSize = True
        Me.a2.Location = New System.Drawing.Point(14, 32)
        Me.a2.Name = "a2"
        Me.a2.Size = New System.Drawing.Size(42, 15)
        Me.a2.TabIndex = 68
        Me.a2.Text = "Audio:"
        '
        'v2
        '
        Me.v2.AutoSize = True
        Me.v2.Location = New System.Drawing.Point(15, 8)
        Me.v2.Name = "v2"
        Me.v2.Size = New System.Drawing.Size(40, 15)
        Me.v2.TabIndex = 67
        Me.v2.Text = "Video:"
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox3.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(508, 47)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 66
        Me.PictureBox3.TabStop = False
        '
        'ElementHost1
        '
        Me.ElementHost1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElementHost1.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(508, 346)
        Me.ElementHost1.TabIndex = 2
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Me.Player1
        '
        'ElementHost2
        '
        Me.ElementHost2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ElementHost2.Location = New System.Drawing.Point(0, 0)
        Me.ElementHost2.Margin = New System.Windows.Forms.Padding(0)
        Me.ElementHost2.Name = "ElementHost2"
        Me.ElementHost2.Size = New System.Drawing.Size(508, 346)
        Me.ElementHost2.TabIndex = 2
        Me.ElementHost2.Text = "ElementHost2"
        Me.ElementHost2.Child = Me.Player2
        '
        'Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.WindowText
        Me.ClientSize = New System.Drawing.Size(1016, 426)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Player"
        Me.Text = "Player"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ElementHost2 As System.Windows.Forms.Integration.ElementHost
    Friend Player2 As Film_Info__Organizer.UserControl2
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend Player1 As Film_Info__Organizer.UserControl2
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents s1 As System.Windows.Forms.RadioButton
    Friend WithEvents l1 As System.Windows.Forms.Button
    Friend WithEvents a1 As System.Windows.Forms.Label
    Friend WithEvents v1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents s2 As System.Windows.Forms.RadioButton
    Friend WithEvents l2 As System.Windows.Forms.Button
    Friend WithEvents a2 As System.Windows.Forms.Label
    Friend WithEvents v2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
