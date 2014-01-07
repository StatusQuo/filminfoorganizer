Public Class VistaButton
    Dim sChecked As Boolean
    Dim stool As String
    Dim ms As ToolTip

    Public Property Tooltip As String
        Get
            Return stool
        End Get
        Set(ByVal value As String)
            stool = value
        End Set
    End Property

    Public Property Image As Image
        Get
            Return PictureBox1.Image
        End Get
        Set(ByVal value As Image)
            PictureBox1.Image = value
        End Set
    End Property
    Public Property sText As String
        Get
            Return Label1.Text
        End Get
        Set(ByVal value As String)
            Label1.Text = value
        End Set
    End Property
    'Dim sCheckstate As CheckState
    'Public Property CheckState As CheckState
    '    Get
    '        Return sCheckstate
    '    End Get
    '    Set(ByVal value As CheckState)
    '        sCheckstate = value

    '        If sCheckstate = Windows.Forms.CheckState.Checked Then
    '            Checked = True
    '        End If
    '    End Set
    'End Property

    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, Panel1.MouseLeave
        If Not IsNothing(ms) Then
            ms.Hide(Me.ParentForm)
        End If

        Me.BackColor = SystemColors.GrayText
        Panel1.BackColor = SystemColors.Control
        Label1.ForeColor = SystemColors.GrayText

    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, PictureBox1.MouseEnter, Panel1.MouseEnter, Label1.MouseEnter

        Me.BackColor = Color.FromArgb(2, 135, 197)
        Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Label1.ForeColor = Color.FromArgb(2, 135, 197)

    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        Me.BackColor = Color.FromArgb(2, 135, 197)
        Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Label1.ForeColor = Color.FromArgb(2, 135, 197)
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Me.BackColor = SystemColors.GrayText
        Panel1.BackColor = SystemColors.Control
        Label1.ForeColor = SystemColors.GrayText

    End Sub
    'Sub Checkit(ByVal Change As Boolean)
    '    If Change = True Then
    '        Me.Checked = Not Checked
    '        Me.Select()

    '    End If



    '    If Checked = True Then
    '        Me.BackColor = Color.FromArgb(2, 135, 197)
    '        Panel1.BackColor = Color.FromArgb(227, 245, 254)
    '        CheckBox1.Checked = True
    '    Else
    '        CheckBox1.Checked = False
    '        Me.BackColor = Color.Transparent
    '        Panel1.BackColor = Color.Transparent
    '    End If


    'End Sub






End Class
