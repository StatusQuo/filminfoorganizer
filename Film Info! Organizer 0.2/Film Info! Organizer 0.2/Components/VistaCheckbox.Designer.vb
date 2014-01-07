<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VistaTextCheck
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CheckBox1.Location = New System.Drawing.Point(5, 0)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(164, 31)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel1.Size = New System.Drawing.Size(174, 31)
        Me.Panel1.TabIndex = 1
        '
        'VistaTextCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "VistaTextCheck"
        Me.Padding = New System.Windows.Forms.Padding(1)
        Me.Size = New System.Drawing.Size(176, 33)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
