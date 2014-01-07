Imports System.Windows.Media.Imaging
Imports System.Windows.Input
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Animation
Imports System.Windows.Media

Public Class UserControl2

    Public Shared Event _DoubleClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
    Public Property ShowControls As Boolean
        Get
            If Grid1.Visibility = Windows.Visibility.Hidden Then
                Return False
            Else
                Return True
            End If
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                MediaElement1.LoadedBehavior = Windows.Controls.MediaState.Manual
                Grid1.Visibility = Windows.Visibility.Visible
            Else
                MediaElement1.LoadedBehavior = Windows.Controls.MediaState.Play
                Grid1.Visibility = Windows.Visibility.Collapsed
            End If
        End Set
    End Property


    Sub Play(ByVal p As String)
        MediaElement1.Source = New Uri(p)

        If ShowControls Then
            Image4.Visibility = Windows.Visibility.Visible
            MediaElement1.LoadedBehavior = Windows.Controls.MediaState.Manual
        Else
            MediaElement1.LoadedBehavior = Windows.Controls.MediaState.Play
        End If

        MediaElement1.UnloadedBehavior = Windows.Controls.MediaState.Close
        Playing = True
        Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_ppause_normal.png", UriKind.Absolute))
        'MediaElement1.Play()

    End Sub
    Sub Sound(ByVal b As Boolean)
        If b = False Then
            MediaElement1.Volume = 0
        Else
            MediaElement1.Volume = 1
        End If


    End Sub
    Sub Unload()
        MediaElement1.Source = Nothing
    End Sub
    Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        'Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_fulls_normal.png", UriKind.Absolute))
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
    Property Lautstärke As Double
        Get
            Return MediaElement1.Volume
        End Get
        Set(ByVal value As Double)
            MediaElement1.Volume = value
        End Set
    End Property


    Private Sub MediaElement1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDoubleClick
        'If e.ClickCount = 2 Then


        'End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        RaiseEvent _DoubleClick(sender, e)
    End Sub


    Property isFullScreen As Boolean = False
    Public Event FullScreeStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
    Private Sub Image1_MouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image1.MouseEnter
        If isFullScreen = False Then
            Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_fulls_hover.png", UriKind.Absolute))
        Else
            Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_nofulls_hover.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image1_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image1.MouseLeave
        If isFullScreen = False Then
            Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_fulls_normal.png", UriKind.Absolute))
        Else
            Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_nofulls_normal.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Image1.MouseDown
        If e.LeftButton = MouseButtonState.Pressed Then
            isFullScreen = Not isFullScreen
            RaiseEvent FullScreeStateChanged(sender, e)
            If isFullScreen = False Then
                Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_fulls_hover.png", UriKind.Absolute))
            Else
                Image1.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_nofulls_hover.png", UriKind.Absolute))

            End If
        End If
    End Sub

    Property Playing As Boolean = True
    Dim pos As TimeSpan


    Private Sub Image2_MouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image2.MouseEnter
        If Playing = False Then
            Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_play_hover.png", UriKind.Absolute))
        Else
            Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_ppause_hover.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image2_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image2.MouseLeave
        If Playing = False Then
            Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_play_normal.png", UriKind.Absolute))
        Else
            Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_ppause_normal.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Image2.MouseDown
        If e.LeftButton = MouseButtonState.Pressed Then
            MediaElement1.LoadedBehavior = Windows.Controls.MediaState.Manual
            pos = MediaElement1.Position
            If Playing = False Then
                Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_ppause_hover.png", UriKind.Absolute))
                MediaElement1.Position = pos
                MediaElement1.Play()

                Playing = True
            Else
                Image2.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_play_hover.png", UriKind.Absolute))
                pos = MediaElement1.Position
                MediaElement1.Pause()
                Playing = False
            End If
        End If
    End Sub

    Private Sub Image3_MouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image3.MouseEnter
        If MediaElement1.Volume = 0 Then
            Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundoff_hover.png", UriKind.Absolute))
        Else
            Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundon_hover.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image3_MouseLeave(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs) Handles Image3.MouseLeave
        If MediaElement1.Volume = 0 Then
            Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundoff_normal.png", UriKind.Absolute))
        Else
            Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundon_normal.png", UriKind.Absolute))

        End If
    End Sub

    Private Sub Image3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Image3.MouseDown
        If e.LeftButton = MouseButtonState.Pressed Then


            If MediaElement1.Volume = 0 Then
                Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundon_hover.png", UriKind.Absolute))
                MediaElement1.Volume = 1
            Else
                Image3.Source = New BitmapImage(New Uri("pack://application:,,,/Images/but_soundoff_hover.png", UriKind.Absolute))
                MediaElement1.Volume = 0
            End If
        End If
    End Sub

    Private Sub MediaElement1_BufferingStarted(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MediaElement1.BufferingStarted
        Image4.Visibility = Windows.Visibility.Visible

    End Sub

    Private Sub MediaElement1_BufferingEnded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MediaElement1.BufferingEnded
        Image4.Visibility = Windows.Visibility.Hidden

    End Sub

    Private Sub MediaElement1_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles MediaElement1.Loaded
        MediaElement1.Play()





        Image4.Visibility = Windows.Visibility.Hidden




    End Sub

End Class