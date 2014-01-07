Module ModMain

    Private m_Handler As New SingleInstanceHandler()
    Public MainForm As MForm

    Public StartupPath As String
    Public StartupExePath As String
    Public Sub Main(ByVal args() As String)
        'Add the startup call back

        AddHandler m_Handler.StartUpEvent, AddressOf StartUp
        m_Handler.Run(args)
    End Sub





    Public Sub StartUp(ByVal sender As Object,
                       ByVal event_args As StartUpEventArgs)
        If event_args.NewInstance Then ' This is the first instance, create the main form and addd the child forms
            StartupPath = Application.StartupPath
            StartupExePath = Application.ExecutablePath
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf My.Application.MyDomain_AssemblyResolve
            AddHandler Application.ThreadException, AddressOf Fehler
            MainForm = New MForm()
            'Application.Run(AeroForm)
            Application.Run(MainForm)
            'Catch ex As Exception
            '    MyExceptionxxx.Fehler(ex)
            'End Try


        Else
            Try
                MainForm.Invoke(New MForm.AddFolderDelegate(AddressOf MainForm.AddFolder), New Object() {event_args.Args})

            Catch ex As Exception

            End Try

        End If



    End Sub

    Private Sub Fehler(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)
        MyExceptionxxx.Fehler(e.Exception)
    End Sub

End Module
