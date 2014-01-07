<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_GenreSelect
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
        Me.TreeViewVista1 = New Film_Info__Organizer.TreeViewVista()
        Me.TreeViewVista2 = New Film_Info__Organizer.TreeViewVista()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton_Add = New System.Windows.Forms.RadioButton()
        Me.RadioButton_Rep = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(472, 8)
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
        'TreeViewVista1
        '
        Me.TreeViewVista1.AllowDrop = True
        Me.TreeViewVista1.FullRowSelect = True
        Me.TreeViewVista1.ItemHeight = 20
        Me.TreeViewVista1.Location = New System.Drawing.Point(14, 27)
        Me.TreeViewVista1.Name = "TreeViewVista1"
        Me.TreeViewVista1.ShowLines = False
        Me.TreeViewVista1.ShowPlusMinus = False
        Me.TreeViewVista1.ShowRootLines = False
        Me.TreeViewVista1.Size = New System.Drawing.Size(300, 440)
        Me.TreeViewVista1.TabIndex = 2
        '
        'TreeViewVista2
        '
        Me.TreeViewVista2.AllowDrop = True
        Me.TreeViewVista2.FullRowSelect = True
        Me.TreeViewVista2.ItemHeight = 20
        Me.TreeViewVista2.Location = New System.Drawing.Point(358, 27)
        Me.TreeViewVista2.Name = "TreeViewVista2"
        Me.TreeViewVista2.ShowLines = False
        Me.TreeViewVista2.ShowPlusMinus = False
        Me.TreeViewVista2.ShowRootLines = False
        Me.TreeViewVista2.Size = New System.Drawing.Size(300, 440)
        Me.TreeViewVista2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Genre, die hinzugefügt werden"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(355, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Alle Genre"
        '
        'Button1
        '
        Me.Button1.Image = Global.Film_Info__Organizer.Toolbar16.lightbutton2
        Me.Button1.Location = New System.Drawing.Point(320, 397)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.Film_Info__Organizer.Toolbar16.lightbutton1
        Me.Button2.Location = New System.Drawing.Point(320, 435)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RadioButton_Add
        '
        Me.RadioButton_Add.AutoSize = True
        Me.RadioButton_Add.Checked = True
        Me.RadioButton_Add.Location = New System.Drawing.Point(18, 14)
        Me.RadioButton_Add.Name = "RadioButton_Add"
        Me.RadioButton_Add.Size = New System.Drawing.Size(87, 19)
        Me.RadioButton_Add.TabIndex = 8
        Me.RadioButton_Add.TabStop = True
        Me.RadioButton_Add.Text = "Hinzufügen"
        Me.RadioButton_Add.UseVisualStyleBackColor = True
        '
        'RadioButton_Rep
        '
        Me.RadioButton_Rep.AutoSize = True
        Me.RadioButton_Rep.Location = New System.Drawing.Point(111, 14)
        Me.RadioButton_Rep.Name = "RadioButton_Rep"
        Me.RadioButton_Rep.Size = New System.Drawing.Size(81, 19)
        Me.RadioButton_Rep.TabIndex = 9
        Me.RadioButton_Rep.Text = "Bearbeiten"
        Me.RadioButton_Rep.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.RadioButton_Add)
        Me.Panel2.Controls.Add(Me.RadioButton_Rep)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 473)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(670, 49)
        Me.Panel2.TabIndex = 10
        '
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(670, 41)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'Dialog_GenreSelect
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(670, 522)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeViewVista2)
        Me.Controls.Add(Me.TreeViewVista1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_GenreSelect"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Genre bearbeiten"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents TreeViewVista1 As Film_Info__Organizer.TreeViewVista
    Friend WithEvents TreeViewVista2 As Film_Info__Organizer.TreeViewVista
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents RadioButton_Add As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton_Rep As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox

End Class
