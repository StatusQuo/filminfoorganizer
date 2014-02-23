Public Class Form1
    Dim p As String = ""
    Dim temp As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AdminRights.hasRight()
        ExecuteParams()

        Me.Close()
    End Sub
    Public Sub ExecuteParams()
        Dim args As String()
        args = Environment.GetCommandLineArgs()

        'bei 1 starten, weil das Programm IMMER seinen eigenen 
        'FULLPATH als ersten Parameter erkennt!
        'MsgBox(args.Length)

        For i As Integer = 1 To args.Length - 1
            If IO.Directory.Exists(args(i)) Then
                Dim Res() As Byte = My.Resources.MediaInfo
                p = IO.Path.Combine(args(i), "Film Info! Organizer.exe")
                Dim d As String = IO.Path.Combine(args(i), "MediaInfo.dll")
                Dim s As String = IO.Path.Combine(Application.StartupPath, "minfo.zip")
                temp = s
                IO.File.WriteAllBytes(s, Res)


                If IO.File.Exists(d) Then
                    Try
                        IO.File.Delete(d)
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
    End Sub
    Private Sub delet()
        If IO.File.Exists(temp) Then
            Try
                IO.File.Delete(temp)
            Catch ex As Exception

            End Try
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
    'Private Sub Start()
    '    Try
    '        Process.Start(p)
    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
