<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviewSheet
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me._providerlogo = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._providerlogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me._providerlogo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel1.Size = New System.Drawing.Size(185, 291)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(165, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 50
        Me.PictureBox3.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoEllipsis = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(27, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PictureBox1.Location = New System.Drawing.Point(4, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(177, 264)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        '_providerlogo
        '
        Me._providerlogo.Location = New System.Drawing.Point(3, 3)
        Me._providerlogo.Name = "_providerlogo"
        Me._providerlogo.Size = New System.Drawing.Size(18, 18)
        Me._providerlogo.TabIndex = 1
        Me._providerlogo.TabStop = False
        Me._providerlogo.Visible = False
        '
        'PreviewSheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Name = "PreviewSheet"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(187, 293)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._providerlogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents _providerlogo As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox

End Class
