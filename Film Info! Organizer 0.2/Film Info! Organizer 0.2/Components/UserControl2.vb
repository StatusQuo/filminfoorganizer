Public Class LightButton
    Dim s_Enabled As Boolean = True
    Dim sChecked As Boolean = False
    Public Property _Enabled As Boolean
        Get
            Return s_Enabled

        End Get
        Set(ByVal value As Boolean)
            s_Enabled = value
        End Set
    End Property
    Public Property Checked As Boolean
        Get
            Return sChecked
        End Get
        Set(ByVal value As Boolean)
            sChecked = value
            'Checkit(False)
        End Set
    End Property


    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, PictureBox1.MouseLeave

        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            PictureBox1.BackColor = Color.FromArgb(227, 245, 254)
        Else

        End If
        Me.BackColor = Color.Transparent
        PictureBox1.BackColor = Color.Transparent
    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, PictureBox1.MouseEnter
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            PictureBox1.BackColor = Color.FromArgb(227, 245, 254)
        Else

        End If

        Me.BackColor = Color.FromArgb(100, 2, 135, 197)
        PictureBox1.BackColor = Color.FromArgb(242, 251, 255)
    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus, PictureBox1.GotFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            PictureBox1.BackColor = Color.FromArgb(227, 245, 254)
        Else

        End If

        Me.BackColor = Color.FromArgb(100, 2, 135, 197)
        'Me.BackColor = Color.FromArgb(201, 234, 247)
        PictureBox1.BackColor = Color.FromArgb(242, 251, 255)
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus, PictureBox1.LostFocus


        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            PictureBox1.BackColor = Color.FromArgb(227, 245, 254)
        Else

        End If
        Me.BackColor = Color.Transparent
        PictureBox1.BackColor = Color.Transparent

    End Sub
    Sub Checkit(ByVal Change As Boolean)



        'Me.BackColor = Color.Transparent
        'PictureBox1.BackColor = Color.Transparent

        If Checked = True Then


            'Me.BackColor = Color.FromArgb(2, 135, 197)
            'PictureBox1.BackColor = Color.FromArgb(227, 245, 254)
            PictureBox1.Image = Toolbar16.lightbutton1
        Else


            PictureBox1.Image = Toolbar16.lightbutton2
        End If


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Checked = Not Checked
        RaiseEvent Checkchanged()

        Checkit(True)
    End Sub
    Public Event Checkchanged()
End Class
