Public NotInheritable Class Dialog_About

    Private Sub AboutBox2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Panel1.AutoScroll = True
        'Font = SystemFonts.MessageBoxFont
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Über {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        ' TODO: Customize the application's assembly information in the "Application" pane of the project 
        '    properties dialog (under the "Project" menu).
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString) & " " & My.Application.Info.Description
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Button1.FlatAppearance.BorderColor = Color.FromArgb(200, 212, 252)
        'Button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(220, 232, 252)
        'Button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 251)
        ''Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub LinkLabel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel21.Click
        Try
            Process.Start("http://wyday.com/linklabel2/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel23.Click
        Try
            Process.Start("http://www.ofdb.de/view.php?page=start")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel22.Click
        Try
            Process.Start("http://www.imdb.de/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel25.Click
        Try
            Process.Start("http://www.xrel.to/home.html")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel26.Click
        Try
            Process.Start("http://mediainfo.sourceforge.net/de")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel24.Click
        Try
            Process.Start("http://www.themoviedb.org/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel27.Click
        Try
            Process.Start("http://www.vbarchiv.net/home/index.php")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel28.Click
        Try
            Process.Start("http://www.mce-community.de/portal/")
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        Panel1.Focus()

    End Sub

    Private Sub Blog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Blog.Click
        Try
            Process.Start("http://www.filminfoorganizer.blogspot.com")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Forum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Forum.Click
        Try
            Process.Start("http://www.mce-community.de/forum/index.php?showtopic=38085")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Hilfe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hilfe.Click
        Try
            Process.Start("http://www.fiohelp.blogspot.com/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Kontakt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Kontakt.Click
        Try
            Process.Start("mailto:sbastianhumann@gmx.de")
        Catch ex As Exception
            Try
                Clipboard.SetText("sbastianhumann@gmx.de")
            Catch ex2 As Exception

            End Try
            MsgBox("Es ist ein Fehler aufgetreten." & vbCrLf & "Die Support Mailadresse wurde in die Zwischenablage kopiert")
        End Try
    End Sub

    Private Sub LinkLabel29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel29.Click
        Try
            Process.Start("http://www.moviemaze.de/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Changelog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Process.Start("http://www.filminfoorganizer.blogspot.com/p/changelog.html")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel210_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel210.Click
        Try
            Process.Start("http://www.zelluloid.de/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel211_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel211.Click
        Try
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=HW6E84CV4XH2Q")
        Catch ex As Exception

        End Try
    End Sub
End Class
