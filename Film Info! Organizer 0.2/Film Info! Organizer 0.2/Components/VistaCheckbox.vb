Public Class VistaTextCheck
    Dim sChecked As Boolean
    Dim stool As String
    Dim ms As ToolTip
    Public Property Checked As Boolean
        Get
            Return sChecked
        End Get
        Set(ByVal value As Boolean)
            sChecked = value
            Checkit(False)
        End Set
    End Property
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
            Return CheckBox1.Image
        End Get
        Set(ByVal value As Image)
            CheckBox1.Image = value
        End Set
    End Property
    Public Property sText As String
        Get
            Return CheckBox1.Text
        End Get
        Set(ByVal value As String)
            CheckBox1.Text = value
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
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click, Me.Click
        Checkit(True)


    End Sub

    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, CheckBox1.MouseLeave
        If Not IsNothing(ms) Then
            ms.Hide(Me.ParentForm)
        End If
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If

    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, CheckBox1.MouseEnter
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus, CheckBox1.GotFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            'Me.BackColor = Color.FromArgb(201, 234, 247)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, CheckBox1.LostFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If
    End Sub
    Sub Checkit(ByVal Change As Boolean)
        If Change = True Then
            Me.Checked = Not Checked
            Me.Select()

        End If



        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If


    End Sub
    Private Sub PreviewCover_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Space Then
            Checkit(True)
        End If
    End Sub



    Private Sub CheckBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.MouseHover
        Dim m As New ToolTip

        m.ToolTipIcon = ToolTipIcon.Info
        m.ToolTipTitle = "Ordner"
        ms = m
        m.Show(stool, Me.ParentForm, New Point(Me.Location.X, Me.Location.Y + Me.Size.Height * 2))
    End Sub

End Class
