Public Class Form1
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

        If args.Length > 1 Then


            For i As Integer = 1 To args.Length - 1
                Dim c As Integer = 0
                If IO.Directory.Exists(args(i)) Then
                    Dim p As String = IO.Path.Combine(IO.Path.Combine(args(i), "Plugins"), "moviesheet")
                    If Not IO.Directory.Exists(p) Then
                        IO.Directory.CreateDirectory(p)
                    Else
                        IO.Directory.Delete(p, True)
                        IO.Directory.CreateDirectory(p)
                    End If
                    Dim Res() As Byte = My.Resources.MTN
                    Dim s As String = IO.Path.Combine(Application.StartupPath, "mtn.zip")
                    temp = s
                    IO.File.WriteAllBytes(s, Res)



                    Dim cu As New ClassUnzip(s, p)
                    AddHandler cu.UnzipFinishd, AddressOf Unziped
                    cu.UnzipNow()


             
                End If
            Next
        End If
    End Sub
    Private Sub Unziped()
        If IO.File.Exists(temp) Then
            Try
                IO.File.Delete(temp)
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
