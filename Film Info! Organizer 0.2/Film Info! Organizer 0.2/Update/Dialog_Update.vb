Imports System.Windows.Forms

Public Class Dialog_Update
    Private WithEvents Download As New Net.WebClient

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If OK_Button.Text = "Download" Then
            'Me.Size = New System.Drawing.Size(440, 200)
            MainForm.Visible = False

            For x As Integer = 200 To 560 Step 20
                Me.Size = New System.Drawing.Size(440, x)
                Threading.Thread.Sleep(10)
                Me.Refresh()
            Next
            Try
                Download.DownloadFileAsync(New Uri(Updater.Source), Updater.Dest)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End Try
            OK_Button.Enabled = False
            OK_Button.Text = "Installieren"
        Else

            MainForm.Opacity = 0
            MainForm.Visible = True
            Process.Start(Updater.Dest)
            MainForm.Close()

        End If
        'Me.DialogResult = System.Windows.Forms.DialogResult.OK
        'Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Download_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles Download.DownloadFileCompleted
        OK_Button.Enabled = True

    End Sub

    Private Sub Download_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles Download.DownloadProgressChanged
        'ProgressBar1.Value = e.ProgressPercentage
        'If Not e.BytesReceived = 0 Then
        '    Dim i1 As Integer = CInt(CInt(e.BytesReceived / 1024) / 10)
        '    Dim i2 As Integer = CInt(CInt(e.TotalBytesToReceive / 1024) / 10)
        '    Label1.Text = i1 / 100 & "Mb / " & i2 / 100 & "Mb"
        'End If

        'Me.Refresh()
    End Sub

    Private Sub Dialog_Update_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Font = SystemFonts.MessageBoxFont
        Me.oldVersion.Text = "Aktuelle Version: " & String.Format("{0}", My.Application.Info.Version.ToString) & " " & My.Application.Info.Description
        If Einstellungen.UserUpdate.Aktueller = True Then
            newVersion.Text = "Neue Version: " & Einstellungen.UserUpdate.NewVersion
            TextBox1.Text = Einstellungen.UserUpdate.Changes

        Else
            Me.Size = New System.Drawing.Size(440, 200)
            newVersion.Text = ""
            OK_Button.Enabled = False
            newText.Text = "Sie besitzen bereits die aktuellste Version."


        End If
        OK_Button.Enabled = Einstellungen.UserUpdate.Updateready





    End Sub

    Private Sub Blog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Blog.Click
        Try
            Process.Start("http://www.filminfoorganizer.blogspot.com/")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkLabel21.Click
        Try
            Process.Start("http://filminfoorganizer.blogspot.com/p/changelog.html")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        MainForm.restart = True
        MainForm.Close()

    End Sub
End Class
