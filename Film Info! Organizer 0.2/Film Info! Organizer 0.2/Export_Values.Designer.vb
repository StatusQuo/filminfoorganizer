<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Export
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel2.Controls.Add(Me.PictureBox26)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 420)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(592, 49)
        Me.Panel2.TabIndex = 30
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(416, 8)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(164, 29)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.BackColor = System.Drawing.Color.Transparent
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OK_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(76, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(85, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(76, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Abbrechen"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'PictureBox26
        '
        Me.PictureBox26.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox26.Image = Global.Film_Info__Organizer.My.Resources.Resources.infobar
        Me.PictureBox26.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox26.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(592, 41)
        Me.PictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox26.TabIndex = 66
        Me.PictureBox26.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(592, 420)
        Me.FlowLayoutPanel1.TabIndex = 31
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(12, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 23)
        Me.Button1.TabIndex = 67
        Me.Button1.Text = "Speichern"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Dialog_Export
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(592, 469)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_Export"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
