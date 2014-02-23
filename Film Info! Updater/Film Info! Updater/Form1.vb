Public Class Form1
    Dim p As String
    Dim temp As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AdminRights.hasRight()
        System.Reflection.Assembly.Load(My.Resources.Interop_Shell32)


    End Sub
    Public Sub ExecuteParams()
        Dim args As String()
        args = Environment.GetCommandLineArgs()

        'bei 1 starten, weil das Programm IMMER seinen eigenen 
        'FULLPATH als ersten Parameter erkennt!
        'MsgBox(args.Length)
        Threading.Thread.Sleep(200)
        If args.Length > 1 Then
            For i As Integer = 1 To args.Length - 1
                If IO.Directory.Exists(args(i)) Then
                    Reg.Updatevernum()

                    Dim s As String = IO.Path.Combine(Application.StartupPath, "updater.zip")
                    temp = s
                    Dim Res() As Byte = My.Resources.Film_Info__Organizer
                    IO.File.WriteAllBytes(s, Res)
                    p = IO.Path.Combine(args(i), "Film Info! Organizer.exe")
                    If IO.File.Exists(p) Then
                        Try
                            IO.File.Delete(p)
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    End If
                    If IO.File.Exists(IO.Path.Combine(args(i), "Microsoft.WindowsAPICodePack.dll")) Then
                        Try
                            IO.File.Delete(IO.Path.Combine(args(i), "Microsoft.WindowsAPICodePack.dll"))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    End If
                    If IO.File.Exists(IO.Path.Combine(args(i), "ExpandableGridView.dll")) Then
                        Try
                            IO.File.Delete(IO.Path.Combine(args(i), "ExpandableGridView.dll"))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    End If
                    If IO.File.Exists(IO.Path.Combine(args(i), "Microsoft.WindowsAPICodePack.Shell.dll")) Then
                        Try
                            IO.File.Delete(IO.Path.Combine(args(i), "Microsoft.WindowsAPICodePack.Shell.dll"))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    End If
                    If IO.File.Exists(IO.Path.Combine(args(i), "Newtonsoft.Json.dll")) Then
                        Try
                            IO.File.Delete(IO.Path.Combine(args(i), "Newtonsoft.Json.dll"))
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
                            Exit Sub
                        End Try
                    End If
                    Dim cu As New ClassUnzip(s, args(i))
                    AddHandler cu.UnzipFinishd, AddressOf Unziped
                    cu.UnzipNow()
                End If
            Next
        Else
        Dim m As New FolderBrowserDialog
        If m.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim t As String = IO.Path.Combine(Application.StartupPath, "updater.zip")
            Dim Res() As Byte = My.Resources.Film_Info__Organizer
            IO.File.WriteAllBytes(t, Res)
            Dim cu As New ClassUnzip(t, Application.StartupPath)
            AddHandler cu.UnzipFinishd, AddressOf Unziped
            cu.UnzipNow()
            'compression()
        End If

        End If

    End Sub
    Private Sub Unziped()
        delet()
        Try
            Process.Start(p)
        Catch ex As Exception

        End Try
        Me.Close()
    End Sub

    Private Sub Start()
        Try
            Process.Start(p)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        ExecuteParams()

    End Sub

    Private Sub delet()
        If IO.File.Exists(temp) Then
            Try
                IO.File.Delete(temp)
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
