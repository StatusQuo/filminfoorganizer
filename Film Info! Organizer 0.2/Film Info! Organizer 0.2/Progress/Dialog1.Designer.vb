<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog1))
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Unerwartete Fehler", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Probleme", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Objekt nicht festgelegt", "bei blablalba"}, 1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Ordner existiert bereits", "Pfad: blabla"}, 0)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel_nothigselected = New System.Windows.Forms.Panel()
        Me.Panel_selected = New System.Windows.Forms.Panel()
        Me.EX_Message = New System.Windows.Forms.Label()
        Me.EX_Type = New System.Windows.Forms.Label()
        Me.ex_Stacktrace = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.sfgp = New System.Windows.Forms.GroupBox()
        Me.LinkLabel21 = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.ListViewVista1 = New Film_Info__Organizer.ListViewVista()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_nothigselected.SuspendLayout()
        Me.Panel_selected.SuspendLayout()
        Me.sfgp.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 495)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(748, 58)
        Me.Panel2.TabIndex = 69
        '
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(748, 51)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(550, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(186, 29)
        Me.TableLayoutPanel2.TabIndex = 67
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.Location = New System.Drawing.Point(96, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Abbrechen"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "exception_Warning.png")
        Me.ImageList1.Images.SetKeyName(1, "exception_Error.png")
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(487, 24)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Bericht"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Panel_nothigselected)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Panel_selected)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(448, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(300, 495)
        Me.Panel1.TabIndex = 72
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1, 495)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(82, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Wählen sie ein Element aus"
        '
        'Panel_nothigselected
        '
        Me.Panel_nothigselected.Controls.Add(Me.Label1)
        Me.Panel_nothigselected.Location = New System.Drawing.Point(3, 3)
        Me.Panel_nothigselected.Name = "Panel_nothigselected"
        Me.Panel_nothigselected.Size = New System.Drawing.Size(294, 489)
        Me.Panel_nothigselected.TabIndex = 2
        '
        'Panel_selected
        '
        Me.Panel_selected.Controls.Add(Me.LinkLabel21)
        Me.Panel_selected.Controls.Add(Me.sfgp)
        Me.Panel_selected.Controls.Add(Me.ex_Stacktrace)
        Me.Panel_selected.Controls.Add(Me.EX_Type)
        Me.Panel_selected.Controls.Add(Me.EX_Message)
        Me.Panel_selected.Location = New System.Drawing.Point(3, 3)
        Me.Panel_selected.Name = "Panel_selected"
        Me.Panel_selected.Size = New System.Drawing.Size(294, 489)
        Me.Panel_selected.TabIndex = 73
        '
        'EX_Message
        '
        Me.EX_Message.AutoSize = True
        Me.EX_Message.Location = New System.Drawing.Point(13, 15)
        Me.EX_Message.Name = "EX_Message"
        Me.EX_Message.Size = New System.Drawing.Size(41, 15)
        Me.EX_Message.TabIndex = 0
        Me.EX_Message.Text = "Label3"
        '
        'EX_Type
        '
        Me.EX_Type.AutoSize = True
        Me.EX_Type.Location = New System.Drawing.Point(13, 39)
        Me.EX_Type.Name = "EX_Type"
        Me.EX_Type.Size = New System.Drawing.Size(41, 15)
        Me.EX_Type.TabIndex = 1
        Me.EX_Type.Text = "Label3"
        '
        'ex_Stacktrace
        '
        Me.ex_Stacktrace.AutoEllipsis = True
        Me.ex_Stacktrace.Location = New System.Drawing.Point(13, 64)
        Me.ex_Stacktrace.Name = "ex_Stacktrace"
        Me.ex_Stacktrace.Size = New System.Drawing.Size(269, 272)
        Me.ex_Stacktrace.TabIndex = 2
        Me.ex_Stacktrace.Text = "Label3"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.Location = New System.Drawing.Point(69, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Fehler melden"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.Location = New System.Drawing.Point(9, 56)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(254, 23)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Fehler in die Zwischenablage kopieren"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'sfgp
        '
        Me.sfgp.Controls.Add(Me.Button3)
        Me.sfgp.Controls.Add(Me.Button5)
        Me.sfgp.Location = New System.Drawing.Point(16, 339)
        Me.sfgp.Name = "sfgp"
        Me.sfgp.Size = New System.Drawing.Size(269, 89)
        Me.sfgp.TabIndex = 7
        Me.sfgp.TabStop = False
        Me.sfgp.Text = "Fehler melden"
        '
        'LinkLabel21
        '
        Me.LinkLabel21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel21.HoverColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Image = Nothing
        Me.LinkLabel21.Location = New System.Drawing.Point(180, 462)
        Me.LinkLabel21.Name = "LinkLabel21"
        Me.LinkLabel21.RegularColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Size = New System.Drawing.Size(105, 16)
        Me.LinkLabel21.TabIndex = 8
        Me.LinkLabel21.Text = "Hilfe durchsuchen"
        '
        'ListViewVista1
        '
        Me.ListViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewVista1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        ListViewGroup1.Header = "Unerwartete Fehler"
        ListViewGroup1.Name = "ListViewGroup1"
        ListViewGroup2.Header = "Probleme"
        ListViewGroup2.Name = "ListViewGroup2"
        Me.ListViewVista1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup2
        Me.ListViewVista1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
        Me.ListViewVista1.LargeImageList = Me.ImageList1
        Me.ListViewVista1.Location = New System.Drawing.Point(12, 36)
        Me.ListViewVista1.Name = "ListViewVista1"
        Me.ListViewVista1.Size = New System.Drawing.Size(430, 453)
        Me.ListViewVista1.TabIndex = 70
        Me.ListViewVista1.TileSize = New System.Drawing.Size(410, 34)
        Me.ListViewVista1.UseCompatibleStateImageBehavior = False
        Me.ListViewVista1.View = System.Windows.Forms.View.Tile
        '
        'Dialog1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(748, 553)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListViewVista1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_nothigselected.ResumeLayout(False)
        Me.Panel_nothigselected.PerformLayout()
        Me.Panel_selected.ResumeLayout(False)
        Me.Panel_selected.PerformLayout()
        Me.sfgp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ListViewVista1 As Film_Info__Organizer.ListViewVista
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_nothigselected As System.Windows.Forms.Panel
    Friend WithEvents Panel_selected As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel21 As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents sfgp As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ex_Stacktrace As System.Windows.Forms.Label
    Friend WithEvents EX_Type As System.Windows.Forms.Label
    Friend WithEvents EX_Message As System.Windows.Forms.Label

End Class
