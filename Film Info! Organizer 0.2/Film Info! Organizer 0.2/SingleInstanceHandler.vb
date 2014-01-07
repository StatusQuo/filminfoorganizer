Public Class SingleInstanceHandler
    Inherits MarshalByRefObject

    Private m_Mutex As System.Threading.Mutex
    Private m_UniqueIdentifier As String
    Private m_TCPChannel As System.Runtime.Remoting.Channels.Tcp.TcpChannel

    Public Sub Run(ByVal args() As String)
        ' Create a Unique Identifier for the Mutex object and the SingletonCommunicator
        ' We are using the executable path for the application because we want to ensure
        ' that the instances are unique based on installation locations.
        ' Hack: Attempting to create a Mutex with an identifier that looks like a path
        '       will cause a path not found exception. So simply replace the '\'s with
        '       underscores and this should still be a unique identifier for this app
        '       based on the running location.
        m_UniqueIdentifier = Application.ExecutablePath.Replace("\", "_")

        ' Create the Mutex class
        m_Mutex = New System.Threading.Mutex(False, m_UniqueIdentifier)
        ' Attempt to lock the Mutex
        If m_Mutex.WaitOne(1, True) Then ' We locked it! We are the first instance!!!
            CreateInstanceChannel()
            ' Raise the StartUpEvent as a NewInstance
            Dim event_args As New StartUpEventArgs(True, args)
            RaiseStartUpEvent(event_args)
        Else ' Not the first instance!!!
            ' Raise the StartUpEvent through the SingletonCommunicator not as a NewInstance
            Dim event_args As New StartUpEventArgs(False, args)
            UseInstanceChannel(event_args)
        End If
    End Sub

    Private Sub CreateInstanceChannel()
        System.Runtime.Remoting.RemotingServices.Marshal(Me, m_UniqueIdentifier)
        Dim tcp_properties As IDictionary = New Hashtable(2)
        tcp_properties("bindTo") = "127.0.0.1"
        tcp_properties("port") = 0
        m_TCPChannel = New System.Runtime.Remoting.Channels.Tcp.TcpChannel(tcp_properties, Nothing, Nothing)
        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(m_TCPChannel)

        Dim key As Microsoft.Win32.RegistryKey = Application.UserAppDataRegistry()
        key.SetValue(m_UniqueIdentifier, m_TCPChannel.GetUrlsForUri(m_UniqueIdentifier)(0))
    End Sub

    Private Sub UseInstanceChannel(ByVal event_args As StartUpEventArgs)
        Dim key As Microsoft.Win32.RegistryKey = Application.UserAppDataRegistry()
        Dim remote_component As SingleInstanceHandler = CType(System.Runtime.Remoting.RemotingServices.Connect(GetType(SingleInstanceHandler), _
                                                        CStr(key.GetValue(m_UniqueIdentifier))), SingleInstanceHandler)
        If Not remote_component Is Nothing Then
            remote_component.RaiseStartUpEvent(event_args)
        End If

    End Sub

    Public Sub RaiseStartUpEvent(ByVal event_args As StartUpEventArgs)
        RaiseEvent StartUpEvent(Me, event_args)
    End Sub

    Public Event StartUpEvent As StartUpEventArgsHandler
End Class

<Serializable()> _
Public Class StartUpEventArgs
    Inherits EventArgs
    Public Sub New(ByVal new_instance As Boolean, ByVal the_args() As String)
        NewInstance = new_instance
        Args = the_args
    End Sub

    Public NewInstance As Boolean
    Public Args() As String
End Class

Public Delegate Sub StartUpEventArgsHandler(ByVal sender As Object, ByVal event_args As StartUpEventArgs)