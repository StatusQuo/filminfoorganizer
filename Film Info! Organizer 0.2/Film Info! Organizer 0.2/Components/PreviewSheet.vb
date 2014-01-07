


Public Class PreviewSheet
    Dim sProvider As CoverProvider
    Dim sPrevImage As Prev_Sheet
    Dim sChecked As Boolean = False
    Dim sQualität As Integer
    Dim rate As Double
    Dim type As ImageType
    Public Property Checked As Boolean
        Get
            Return sChecked
        End Get
        Set(ByVal value As Boolean)
            sChecked = value
            Checkit(False)
        End Set
    End Property
    Public Property Picdest As PictureBox

    Public Sub refreshimage()
        If Not IsNothing(sPrevImage.Image) Then

            PictureBox1.Image = sPrevImage.Image

        Else

            PictureBox1.Image = My.Resources.no_cover_bg

        End If


    End Sub
    Public Property _Result As Prev_Sheet
        Get
            Return sPrevImage
        End Get
        Set(ByVal value As Prev_Sheet)
            sPrevImage = value
            'type = value.Type
            'Label1.Text = value.Width & "x" & value.Height
            'If value.Type = ImageType.Cover Then
            '    rate = 1.5
            'Else
            rate = 0.6
            'End If
            If Not IsNothing(sPrevImage.image) Then


                rate = sPrevImage.image.Height / sPrevImage.image.Width
                PictureBox1.Image = sPrevImage.image
            Else


            End If

            Imagewith = 150
        End Set
    End Property
    Public Property Imagewith As Integer
        Get
            Return PictureBox1.Width
        End Get
        Set(ByVal value As Integer)
            Me.Visible = False
            Me.Size = New Size(value, CInt(value * rate) + 30)

            PictureBox1.Size = New Size(PictureBox1.Width, CInt(value * rate))
            Me.Visible = True
            'Me.Refresh()
        End Set
    End Property
    

    Public Property _Provider As CoverProvider
        Get
            Return sProvider
        End Get
        Set(ByVal value As CoverProvider)
            sProvider = value
            Select Case value
                Case Is = CoverProvider.tmdb
                    _providerlogo.Image = Toolbar16.pw_tmdb
                Case Is = CoverProvider.mp
                    _providerlogo.Image = Toolbar16.pw_moviepilot
                Case Is = CoverProvider.moviemaze
                    _providerlogo.Image = Toolbar16.moviemaze
                Case Is = CoverProvider.file
                    _providerlogo.Image = Toolbar16.pw_file
            End Select

        End Set
    End Property

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _providerlogo.Click, Me.Click, PictureBox1.Click
        'Checkit(True)
        Dialog_Sheet.Panel1.Show()
        Dialog_Sheet.PictureBox2.Image = sPrevImage.image

    End Sub

    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, PictureBox1.MouseLeave, _providerlogo.MouseLeave, Panel1.MouseLeave
        PictureBox3.Image = Nothing
        'If Checked = True Then
        '    Me.BackColor = Color.FromArgb(2, 135, 197)
        '    Panel1.BackColor = Color.FromArgb(227, 245, 254)
        'Else
        Me.BackColor = Color.Transparent
        Panel1.BackColor = Color.Transparent
        'End If

    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, PictureBox1.MouseEnter, _providerlogo.MouseEnter, Panel1.MouseEnter
        PictureBox3.Image = Toolbar16.exit_normal
        'If Checked = True Then
        Me.BackColor = Color.FromArgb(2, 135, 197)
        Panel1.BackColor = Color.FromArgb(227, 245, 254)
        'Else
        'Me.BackColor = Color.FromArgb(100, 2, 135, 197)
        'Panel1.BackColor = Color.FromArgb(242, 251, 255)
        'End If
    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus

        Me.BackColor = Color.FromArgb(2, 135, 197)
        Panel1.BackColor = Color.FromArgb(227, 245, 254)
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        'If Checked = True Then
        '    Me.BackColor = Color.FromArgb(2, 135, 197)
        '    Panel1.BackColor = Color.FromArgb(227, 245, 254)
        'Else
        Me.BackColor = Color.Transparent
        Panel1.BackColor = Color.Transparent
        'End If
    End Sub
    Sub Checkit(ByVal Change As Boolean)
        If Change = True Then
            Me.Checked = Not Checked
            Me.Select()
        End If



        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
            If type = ImageType.Cover Then
                Dialog_Fanart.Label1.Text = 1 & "/" & Dialog_Fanart.Covers.Count
                If Dialog_Fanart.Covers.Count > 0 Then
                    'Dim i As Integer = Dialog_Fanart.Covers.IndexOf(Me)
                    For x As Integer = 0 To Dialog_Fanart.Covers.Count - 1
                        'If Not x = i Then
                        '    Dialog_Fanart.Covers(x).Checked = False
                        'End If
                    Next
                End If
            ElseIf type = ImageType.Fanart Then



            End If



        Else
            Dim r As Integer = 0

            If Dialog_Fanart.Backdrops.Count > 0 Then
                'Dim i As Integer = Dialog_Fanart.Backdrops.IndexOf(Me)
                For x As Integer = 0 To Dialog_Fanart.Backdrops.Count - 1
                    If Dialog_Fanart.Backdrops(x).Checked Then
                        r += 1
                    End If
                    'If Not x = i Then
                    '    Dialog_Fanart.Backdrops(x).Checked = False
                    'End If
                Next
            End If
            Dialog_Fanart.Label2.Text = r & "/" & Dialog_Fanart.Backdrops.Count
            Dialog_Fanart.Label1.Text = 1 & "/" & Dialog_Fanart.Covers.Count
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If


    End Sub
    Private Sub PreviewCover_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Delete Then

            Dim index As Integer = Dialog_Sheet.FlowLayoutPanel1.Controls.IndexOf(Me)
            If index = 0 Then
                If Dialog_Sheet.FlowLayoutPanel1.Controls.Count > 0 Then
                    Dialog_Sheet.FlowLayoutPanel1.Controls(0).Focus()
                End If
            Else
                If Dialog_Sheet.FlowLayoutPanel1.Controls.Count >= index Then
                    Dialog_Sheet.FlowLayoutPanel1.Controls(index - 1).Focus()
                End If
            End If
            For Each i In Dialog_Sheet.Sheetresults
                If i.Results.Contains(Me._Result) Then
                    i.Results.Remove(Me._Result)
                End If
            Next
            Dialog_Sheet.FlowLayoutPanel1.Controls.Remove(Me)
            Dialog_Sheet.Sheets.Remove(Me)
            sPrevImage.Dispose()

            'Checkit(True)
        End If
    End Sub




    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.FromArgb(2, 135, 197)
    End Sub
    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = SystemColors.GrayText
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = Toolbar16.exiticon

        Me.BackColor = Color.FromArgb(2, 135, 197)
        Panel1.BackColor = Color.FromArgb(227, 245, 254)

    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = Toolbar16.exit_normal
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        For Each i In Dialog_Sheet.Sheetresults
            If i.Results.Contains(Me._Result) Then
                i.Results.Remove(Me._Result)
            End If
        Next
        Dialog_Sheet.FlowLayoutPanel1.Controls.Remove(Me)
        Dialog_Sheet.Sheets.Remove(Me)
        sPrevImage.Dispose()

    End Sub
End Class
