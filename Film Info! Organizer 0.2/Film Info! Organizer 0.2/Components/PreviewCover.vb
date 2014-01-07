


Public Class PreviewCover
    Dim sProvider As CoverProvider
    Dim sPrevImage As PrevImage
    Dim sChecked As Boolean = False
    Dim sQualität As Integer
    Dim sLang As String
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
    Public Property _Result As PrevImage
        Get
            Return sPrevImage
        End Get
        Set(ByVal value As PrevImage)
            sPrevImage = value
            type = value.Type
            Label1.Text = value.Width & "x" & value.Height & " | " & Math.Round((value.Width / value.Height), 2)
            If value.Type = ImageType.Cover Then
                rate = 1.5
            Else
                rate = 0.6
            End If
            If Not IsNothing(sPrevImage.Image) Then



                PictureBox1.Image = sPrevImage.Image
            Else


            End If

            Imagewith = 150
        End Set
    End Property
    Public Sub refreshimage()
        If Not IsNothing(sPrevImage.Image) Then

            PictureBox1.Image = sPrevImage.Image

        Else

            PictureBox1.Image = My.Resources.no_cover_bg

        End If


    End Sub
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
    Public Property _CoverQuality As Integer
        Get
            Return sQualität

        End Get
        Set(ByVal value As Integer)
            sQualität = value
            'If sQualität = 0 Then
            '    _quality.Image = Toolbar16.qualy_0
            'ElseIf sQualität = 1 Then
            '    _quality.Image = Toolbar16.qualy_1
            'ElseIf sQualität = 2 Then
            '    _quality.Image = Toolbar16.qualy_3
            'End If

        End Set
    End Property
    Public Property _Language As String
        Get
            Return sLang

        End Get
        Set(ByVal value As String)
            sLang = value
            If sLang = "de" Then
                _quality.Image = My.Resources.lngicons.de
            ElseIf sLang = "en" Then
                _quality.Image = My.Resources.lngicons.us
            Else
                _quality.Image = Nothing
            End If

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
        Checkit(True)


    End Sub

    Private Sub PreviewCover_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, PictureBox1.MouseLeave, _providerlogo.MouseLeave
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.Transparent
            Panel1.BackColor = Color.Transparent
        End If

    End Sub
    Private Sub PreviewCover_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, PictureBox1.MouseEnter, _providerlogo.MouseEnter
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If Checked = True Then
            Me.BackColor = Color.FromArgb(2, 135, 197)
            Panel1.BackColor = Color.FromArgb(227, 245, 254)
        Else
            Me.BackColor = Color.FromArgb(100, 2, 135, 197)
            'Me.BackColor = Color.FromArgb(201, 234, 247)
            Panel1.BackColor = Color.FromArgb(242, 251, 255)
        End If
    End Sub

    Private Sub PreviewCover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
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
            If type = ImageType.Cover Then
                Dialog_Fanart.Label1.Text = 1 & "/" & Dialog_Fanart.Covers.Count
                If Dialog_Fanart.Covers.Count > 0 Then
                    Dim i As Integer = Dialog_Fanart.Covers.IndexOf(Me)
                    For x As Integer = 0 To Dialog_Fanart.Covers.Count - 1
                        If Not x = i Then
                            Dialog_Fanart.Covers(x).Checked = False
                        End If
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
        If e.KeyCode = Keys.Space Then
            Checkit(True)
        End If
    End Sub

  
    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Process.Start(_Result.Original)
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.FromArgb(2, 135, 197)
    End Sub
    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = SystemColors.GrayText
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Process.Start(_Result.Original)
    End Sub

End Class
