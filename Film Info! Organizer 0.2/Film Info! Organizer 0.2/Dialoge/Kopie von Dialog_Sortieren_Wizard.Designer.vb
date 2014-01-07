<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Export_Wizard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Export_Wizard))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Zurück = New System.Windows.Forms.Button()
        Me.Vorwärts = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.Page_1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button_Auswahlübernehmen = New System.Windows.Forms.Button()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Select_Auswahl = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Page2 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel21 = New Film_Info__Organizer.wyDay.Controls.LinkLabel2()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Page_1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Page2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel2.Controls.Add(Me.PictureBox16)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 388)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(627, 49)
        Me.Panel2.TabIndex = 11
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.Zurück, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Vorwärts, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(335, 8)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(280, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Zurück
        '
        Me.Zurück.BackColor = System.Drawing.Color.Transparent
        Me.Zurück.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Zurück.Location = New System.Drawing.Point(3, 3)
        Me.Zurück.Name = "Zurück"
        Me.Zurück.Size = New System.Drawing.Size(87, 23)
        Me.Zurück.TabIndex = 2
        Me.Zurück.Text = "< Zurück"
        Me.Zurück.UseVisualStyleBackColor = False
        '
        'Vorwärts
        '
        Me.Vorwärts.BackColor = System.Drawing.Color.Transparent
        Me.Vorwärts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Vorwärts.Location = New System.Drawing.Point(96, 3)
        Me.Vorwärts.Name = "Vorwärts"
        Me.Vorwärts.Size = New System.Drawing.Size(87, 23)
        Me.Vorwärts.TabIndex = 0
        Me.Vorwärts.Text = "Weiter >"
        Me.Vorwärts.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.BackColor = System.Drawing.Color.Transparent
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Cancel_Button.Location = New System.Drawing.Point(189, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(88, 23)
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
        Me.PictureBox16.Size = New System.Drawing.Size(627, 41)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 66
        Me.PictureBox16.TabStop = False
        '
        'Page_1
        '
        Me.Page_1.Controls.Add(Me.GroupBox2)
        Me.Page_1.Controls.Add(Me.GroupBox3)
        Me.Page_1.Controls.Add(Me.GroupBox1)
        Me.Page_1.Controls.Add(Me.Label1)
        Me.Page_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Page_1.Location = New System.Drawing.Point(0, 0)
        Me.Page_1.Name = "Page_1"
        Me.Page_1.Size = New System.Drawing.Size(627, 437)
        Me.Page_1.TabIndex = 20
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton1)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Location = New System.Drawing.Point(282, 220)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(333, 113)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bilder"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(12, 22)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(299, 23)
        Me.RadioButton1.TabIndex = 12
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Bilder in das Ausgabeverzeichnis kopieren"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(12, 51)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(240, 23)
        Me.RadioButton2.TabIndex = 13
        Me.RadioButton2.Text = "keine Bilder kopieren"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button_Auswahlübernehmen)
        Me.GroupBox3.Controls.Add(Me.RadioButton4)
        Me.GroupBox3.Controls.Add(Me.Select_Auswahl)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 220)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 113)
        Me.GroupBox3.TabIndex = 22
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Auswahl"
        '
        'Button_Auswahlübernehmen
        '
        Me.Button_Auswahlübernehmen.Enabled = False
        Me.Button_Auswahlübernehmen.Location = New System.Drawing.Point(111, 80)
        Me.Button_Auswahlübernehmen.Name = "Button_Auswahlübernehmen"
        Me.Button_Auswahlübernehmen.Size = New System.Drawing.Size(141, 23)
        Me.Button_Auswahlübernehmen.TabIndex = 14
        Me.Button_Auswahlübernehmen.Text = "Auswahl übernehmen"
        Me.Button_Auswahlübernehmen.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Location = New System.Drawing.Point(12, 22)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(240, 23)
        Me.RadioButton4.TabIndex = 12
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Alle Filme in der Liste"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Select_Auswahl
        '
        Me.Select_Auswahl.Location = New System.Drawing.Point(12, 51)
        Me.Select_Auswahl.Name = "Select_Auswahl"
        Me.Select_Auswahl.Size = New System.Drawing.Size(240, 23)
        Me.Select_Auswahl.TabIndex = 13
        Me.Select_Auswahl.Text = "Nur ausgewählte Filme"
        Me.Select_Auswahl.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 64)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ausgabepfad"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(491, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Durchsuchen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(15, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(470, 23)
        Me.TextBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(24, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(575, 93)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Willkommen zum Export-Wizard." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Zu Erst müssen Sie das Zielausgabeverzeichnis und " & _
            "die zu exprtierenden Filme wählen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bestätigen Sie ihre Auswahl mit ""Weiter""."
        '
        'Page2
        '
        Me.Page2.Controls.Add(Me.GroupBox5)
        Me.Page2.Controls.Add(Me.GroupBox4)
        Me.Page2.Controls.Add(Me.Label2)
        Me.Page2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Page2.Location = New System.Drawing.Point(0, 0)
        Me.Page2.Name = "Page2"
        Me.Page2.Size = New System.Drawing.Size(627, 388)
        Me.Page2.TabIndex = 21
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(449, 23)
        Me.ComboBox1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(24, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(575, 24)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Bitte wählen Sie eine Designvorlage aus."
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button2)
        Me.GroupBox4.Controls.Add(Me.ComboBox1)
        Me.GroupBox4.Location = New System.Drawing.Point(27, 63)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(582, 70)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Vorlage"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(461, 28)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Ordner öffnen"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.LinkLabel21)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.PictureBox1)
        Me.GroupBox5.Location = New System.Drawing.Point(27, 140)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(582, 234)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Info"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(28, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(149, 142)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(191, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(191, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Autor"
        '
        'LinkLabel21
        '
        Me.LinkLabel21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel21.HoverColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Image = Nothing
        Me.LinkLabel21.Location = New System.Drawing.Point(10, 206)
        Me.LinkLabel21.Name = "LinkLabel21"
        Me.LinkLabel21.RegularColor = System.Drawing.Color.Empty
        Me.LinkLabel21.Size = New System.Drawing.Size(67, 16)
        Me.LinkLabel21.TabIndex = 3
        Me.LinkLabel21.Text = "Homepage"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(490, 199)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Vorschau"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(194, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(372, 103)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Label5"
        '
        'Dialog_Export_Wizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(627, 437)
        Me.Controls.Add(Me.Page2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Page_1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Dialog_Export_Wizard"
        Me.Text = "Exportieren"
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Page_1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Page2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Zurück As System.Windows.Forms.Button
    Friend WithEvents Vorwärts As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents Page_1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button_Auswahlübernehmen As System.Windows.Forms.Button
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents Select_Auswahl As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Page2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents LinkLabel21 As Film_Info__Organizer.wyDay.Controls.LinkLabel2
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
