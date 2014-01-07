<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_MovetoNewFolder
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.TreeViewVista1 = New Film_Info__Organizer.TreeViewVista()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(227, 14)
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 350)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(425, 55)
        Me.Panel2.TabIndex = 67
        '
        'PictureBox16
        '
        Me.PictureBox16.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox16.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox16.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox16.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(425, 59)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'TreeViewVista1
        '
        Me.TreeViewVista1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewVista1.CheckBoxes = True
        Me.TreeViewVista1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TreeViewVista1.FullRowSelect = True
        Me.TreeViewVista1.HotTracking = True
        Me.TreeViewVista1.ItemHeight = 19
        Me.TreeViewVista1.Location = New System.Drawing.Point(0, 51)
        Me.TreeViewVista1.Name = "TreeViewVista1"
        Me.TreeViewVista1.ShowLines = False
        Me.TreeViewVista1.ShowPlusMinus = False
        Me.TreeViewVista1.ShowRootLines = False
        Me.TreeViewVista1.Size = New System.Drawing.Size(425, 299)
        Me.TreeViewVista1.TabIndex = 68
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(3, 31)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 69
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(364, 15)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Welche Dateien sollen in einen eigenen Ornder verschoben werden?"
        '
        'Dialog_MovetoNewFolder
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(425, 405)
        Me.Controls.Add(Me.TreeViewVista1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_MovetoNewFolder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents TreeViewVista1 As Film_Info__Organizer.TreeViewVista
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
