Public Class Player

    Property m1 As Movie

    Property m2 As Movie


    Private Sub Player_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Player1.Sound(s1.Checked)
        Player2.Sound(s2.Checked)
        Player1.Play(m1.Files(0))
        Player2.Play(m2.Files(0))
        v1.Text = "Video: " & m1.VideoBreite & "x" & m1.VideoHöhe & "   " & m1.VideoCodec & "   " & m1.VideoSeitenverhältnis & "   " & m1.VideoBildwiederholungsrate & "fps"
        v2.Text = "Video: " & m2.VideoBreite & "x" & m2.VideoHöhe & "   " & m2.VideoCodec & "   " & m2.VideoSeitenverhältnis & "   " & m2.VideoBildwiederholungsrate & "fps"
        a1.Text = "Audio: " & m1.AudioCodec & "   " & m1.AudioKanäle & " Kanäle"
        a2.Text = "Audio: " & m2.AudioCodec & "   " & m2.AudioKanäle & " Kanäle"
    End Sub

    Private Sub Player_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        di()

    End Sub

    Private Sub s1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s1.CheckedChanged
        s2.Checked = Not s1.Checked
        Player1.Sound(s1.Checked)
        Player2.Sound(s2.Checked)
    End Sub

    Private Sub s2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s2.CheckedChanged
        s1.Checked = Not s2.Checked
        Player1.Sound(s1.Checked)
        Player2.Sound(s2.Checked)
    End Sub
    Sub di()
        Player1.unload()
        Player2.unload()
        ElementHost1.Dispose()
        ElementHost2.Dispose()

    End Sub
    Private Sub l1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l1.Click
        di()

        'If MsgBox("Möchten Sie die Ordner der ausgewählten Filme wirklich in den Papierkorb verschieben?", MsgBoxStyle.YesNoCancel, "Löschen") = MsgBoxResult.Yes Then
        Dim p As New Progress_FileDelet(New List(Of Movie) From {m1})
        p.Run()
        Me.Close()

    End Sub

    Private Sub l2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles l2.Click
        di()

        'If MsgBox("Möchten Sie die Ordner der ausgewählten Filme wirklich in den Papierkorb verschieben?", MsgBoxStyle.YesNoCancel, "Löschen") = MsgBoxResult.Yes Then
        Dim p As New Progress_FileDelet(New List(Of Movie) From {m2})
        p.Run()
        Me.Close()
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        Player1.ShowControls = False
        Player1.ShowControls = True

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
End Class