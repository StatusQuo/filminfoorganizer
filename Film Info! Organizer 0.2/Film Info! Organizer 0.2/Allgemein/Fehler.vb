Imports Microsoft.WindowsAPICodePack
Imports Microsoft.WindowsAPICodePack.Dialogs
Imports System.Net
Public Class MyExceptionxxx
    Private Shared tdError As TaskDialog = Nothing
    Private Shared tdSend As TaskDialog = Nothing
    Private Shared myex As Exception
    Public Shared Sub Fehler(ByVal ex As Exception)
        If TaskDialog.IsPlatformSupported Then
            tdError = New TaskDialog()
            tdError.StandardButtons = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogStandardButtons.Close
            'Dim button1 As New TaskDialogButton("button1", "Anwendung beenden")
            'AddHandler button1.Click, AddressOf button1_Click
            'button1.Default = True
            'tdError.Controls.Add(button1)
            tdError.Text = ex.Message
            tdError.InstructionText = "Es ist ein unerwarteter Fehler aufgetreten." & vbCrLf & "Bitte senden Sie uns ein Feedback!"
            tdError.DetailsExpandedLabel = "Details verstecken"
            tdError.DetailsCollapsedLabel = "Details anzeigen"
            tdError.DetailsExpandedText = ex.StackTrace
            tdError.Icon = TaskDialogStandardIcon.Error
            myex = ex
            tdError.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter

            Dim sendButton As New TaskDialogCommandLink("sendButton", "Fehler melden" & Constants.vbLf & "Ich bin in Geber-Laune")
            AddHandler sendButton.Click, AddressOf sendButton_Click

            Dim dontSendButton As New TaskDialogCommandLink("dontSendButton", "Nein, danke" & Constants.vbLf & "Ich möchte lieber nicht Helfen")
            AddHandler dontSendButton.Click, AddressOf dontSendButton_Click

            Dim closeButton As New TaskDialogCommandLink("closeButton", "Anwendung beenden" & Constants.vbLf & "Ein Neustart wirkt oft Wunder.")
            AddHandler closeButton.Click, AddressOf button1_Click


            tdError.Controls.Add(sendButton)
            tdError.Controls.Add(dontSendButton)
            tdError.Controls.Add(closeButton)
            tdError.Show()
        Else

        End If
    End Sub
    Public Shared Sub Fehler2()
        If Microsoft.WindowsAPICodePack.Dialogs.TaskDialog.IsPlatformSupported Then
            tdError = New TaskDialog()
            tdError.DetailsExpanded = False
            tdError.Cancelable = True
            tdError.Icon = TaskDialogStandardIcon.Error
            tdError.FooterIcon = TaskDialogStandardIcon.Error
            'tdError.StandardButtons = TaskDialogStandardButtons.Close
            tdError.Caption = "Fehler"
            tdError.InstructionText = "Es ist ein unerwarteter Fehler aufgetreten. Bitte senden Sie uns ein Feedback!"
            tdError.Text = "Error message goes here..."
            tdError.DetailsExpandedLabel = "Details verstecken"
            tdError.DetailsCollapsedLabel = "Details anzeigen"
            tdError.DetailsExpandedText = "Stack trace goes here..."

            tdError.FooterCheckBoxChecked = False
            tdError.FooterCheckBoxText = "Nichtmehr fragen"

            tdError.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter

            Dim sendButton As New TaskDialogCommandLink("sendButton", "Fehler melden" & Constants.vbLf & "Ich bin in Geber-Laune")
            'AddHandler sendButton.Click, AddressOf sendButton_Click

            Dim dontSendButton As New TaskDialogCommandLink("dontSendButton", "Nein, danke" & Constants.vbLf & "Ich möchte lieber nicht Helfen")
            'AddHandler dontSendButton.Click, AddressOf dontSendButton_Click

            tdError.Controls.Add(sendButton)
            tdError.Controls.Add(dontSendButton)

            tdError.Show()
            tdError = Nothing
        Else

        End If
    End Sub
    Private Shared sendFeedbackProgressBar As TaskDialogProgressBar
    Private Shared MaxRange As Integer = 5000
    Private Shared Sub sendButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Send feedback button
        'Dim tdSendFeedback As New TaskDialog()
        'tdSendFeedback.Cancelable = False
        ''tdSendFeedback.StandardButtons = False
        'tdSendFeedback.Caption = "Send Feedback Dialog"
        'tdSendFeedback.Text = "Sending your feedback ....."

        '' Show a progressbar
        'sendFeedbackProgressBar = New TaskDialogProgressBar()
        'sendFeedbackProgressBar.State = TaskDialogProgressBarState.Marquee
        'tdSendFeedback.ProgressBar = sendFeedbackProgressBar




        ' Subscribe to the tick event, so we can update the title/caption also close the dialog when done
        'AddHandler tdSendFeedback.Tick, AddressOf tdSendFeedback_Tick
        'tdSendFeedback.Show()
        'tdError.InstructionText = "Sende Fehlerbericht"
        'tdError.Controls.Clear()
        'Dim pb As New TaskDialogProgressBar
        'pb.State = TaskDialogProgressBarState.Marquee
        'tdError.Controls.Add(pb)
        'tdError.Text = ""
        ' Send feedback button
        Dim tdSendFeedback As New TaskDialog()
        tdSendFeedback.Cancelable = True

        tdSendFeedback.Caption = "Fehlerbericht senden"
        tdSendFeedback.Text = "Sende Bericht..."

        ' Show a progressbar
        sendFeedbackProgressBar = New TaskDialogProgressBar(0, MaxRange, 0)
        tdSendFeedback.ProgressBar = sendFeedbackProgressBar

        ' Subscribe to the tick event, so we can update the title/caption also close the dialog when done
        AddHandler tdSendFeedback.Tick, AddressOf tdSendFeedback_Tick
        'AddHandler tdSendFeedback.Opene, AddressOf FeedbackOpend
        tdSendFeedback.Show()

        If tdError IsNot Nothing Then
            tdError.Close(TaskDialogResult.Ok)

        End If



        'If tdError IsNot Nothing Then
        '    tdError.Close(TaskDialogResult.Ok)
        'End If
    End Sub
    Private Shared Sended As Boolean = False
    Private Shared Sending As Boolean = False
    Private Shared Sub tdSendFeedback_Tick(ByVal sender As Object, ByVal e As TaskDialogTickEventArgs)
        If Sending = False Then
            sendIT()
        End If
        If MaxRange >= e.Ticks Then
            CType(sender, TaskDialog).InstructionText = String.Format("Sende ....{0}", e.Ticks)
            CType(sender, TaskDialog).ProgressBar.Value = e.Ticks
        ElseIf Sended = True Then
            CType(sender, TaskDialog).InstructionText = "Danke für Ihr Feedback!"
            CType(sender, TaskDialog).Text = "Wir werden versuchen eine Lösung für ihr Problem zu finden..."
            CType(sender, TaskDialog).ProgressBar.Value = MaxRange
        Else
            CType(sender, TaskDialog).ProgressBar.State = TaskDialogProgressBarState.Marquee

        End If

    End Sub

    Private Shared Sub dontSendButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        tdError.Close()
    End Sub


    Private Shared Sub SendeFeedback2(ByVal myex As Exception)
        Dim q As String = "https://spreadsheets.google.com/spreadsheet/viewform?formkey=dFNQVWZOOG9naWJIUFRBUXFTRm5SWFE6MQ"
        Dim xml As New Xml.XmlDocument
        Dim httpRequest As System.Net.HttpWebRequest = CType(HttpWebRequest.Create(New Uri(q)), HttpWebRequest)
        'httpRequest.Timeout = 10000000
        httpRequest.Method = "POST"
        Dim ostyp As String = ""
        If OS.GetOSType = OS.OSType.Is32Bit Then
            ostyp = "32Bit"
        Else
            ostyp = "64Bit"
        End If

        Dim Post As String = "&entry_0=" & myex.Message
        If Not myex.StackTrace Is Nothing Then
            Post &= "&entry_1=" & myex.StackTrace.Replace("&", """UNDZEICHEN""").Replace("=", """GLEICHZEICHEN""")
        End If
        Post &= "&entry_2=" & My.Computer.Info.OSFullName & ostyp & vbCrLf & My.Computer.Info.OSPlatform & vbCrLf & My.Computer.Info.OSVersion
        Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
        httpRequest.ContentType = "application/x-www-form-urlencoded"

        Dim DataStream As IO.Stream = httpRequest.GetRequestStream()
        'DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Close()


        Dim httpResponse As HttpWebResponse
        httpResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
    End Sub

    Private Shared Sub SendeFeedback(ByVal myex As Exception)
        Dim q As String = "http://polldaddy.com/s/5A084A1916E7CFCA"
        Dim xml As New Xml.XmlDocument
        Dim httpRequest As System.Net.HttpWebRequest = CType(HttpWebRequest.Create(New Uri(q)), HttpWebRequest)
        'httpRequest.Timeout = 10000000
        httpRequest.Method = "POST"
        Dim ostyp As String = ""
        If OS.GetOSType = OS.OSType.Is32Bit Then
            ostyp = "32Bit"
        Else
            ostyp = "64Bit"
        End If

        Dim Post As String = "q_1455561[text]=" & myex.Message
        If Not myex.StackTrace Is Nothing Then
            Post &= "&q_1413628[text]=" & myex.StackTrace.Replace("&", """UNDZEICHEN""").Replace("=", """GLEICHZEICHEN""")
        End If
        Post &= "&q_1455562[text]=" & My.Computer.Info.OSFullName & ostyp & vbCrLf & My.Computer.Info.OSPlatform & vbCrLf & My.Computer.Info.OSVersion
        Dim byteArray() As Byte = System.Text.Encoding.UTF8.GetBytes(Post)
        httpRequest.ContentType = "application/x-www-form-urlencoded"

        Dim DataStream As IO.Stream = httpRequest.GetRequestStream()
        'DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Write(byteArray, 0, byteArray.Length)
        DataStream.Close()


        Dim httpResponse As HttpWebResponse
        httpResponse = CType(httpRequest.GetResponse(), HttpWebResponse)
    End Sub

    Private Shared Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Application.ExitThread()
    End Sub

    Private Shared Sub FeedbackOpend(ByVal sender As Object, ByVal e As EventArgs)
        SendeFeedback(myex)
        Sended = True
    End Sub
    Private Shared Sub sendIT()
        Sending = True
        SendeFeedback(myex)
        Sended = True
    End Sub

End Class

Public Enum MyException_Type
    _Error
    _Warning
End Enum

Public Class MyException
    Property ex As Exception
    Property type As MyException_Type
    Sub New()

    End Sub

End Class
Public Class ExceptionManager
    Dim li As New List(Of MyException)
    Dim Count_Error As Integer = 0
    Dim Count_Warn As Integer = 0
    ReadOnly Property error_count As Integer
        Get
            Return Count_Error
        End Get
    End Property
    ReadOnly Property warning_count As Integer
        Get
            Return Count_Warn
        End Get
    End Property
    Sub Add(ByVal ex As Exception)
        CheckForKnownexeption(ex)

    End Sub

    Private Sub CheckForKnownexeption(ByVal ex As Exception)

    End Sub


End Class

'Public Class Progress_SendFeedback

'    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
'    Dim l As New Laden_Dialog
'    Delegate Sub Refresh_Movie(ByVal m As Movie)
'    Sub New(ByVal lm As List(Of Movie))
'        Worker.WorkerReportsProgress = True
'        Worker.WorkerSupportsCancellation = True
'        li = lm
'        l.Text = "Sicherung wiederherstellen"
'        l.Labelstring = "Sicherung laden"
'        l.aDetails = False
'        l.aCancel = True
'        l.Gesamtzahl = li.Count
'        'laden = l

'        l.Refresh()
'        l.Show()

'    End Sub
'    Public Sub Run()
'        Worker.RunWorkerAsync()
'    End Sub

'    Dim pushlist As New List(Of String)

'    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
'        'Dim l As New Laden_Dialog

'        For x As Integer = 0 To li.Count - 1
'            If l.Cancel = False Then
'                l.Nächster()
'                'pushlist.Add("Lade..." & li(x).Titel)
'                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
'                'Threading.Thread.Sleep(200)
'                'Renamer.ChangeFolderName(li(x))
'                'Renamer.ChangeFileName(li(x))
'                'Dim s As String = "Fertig..." & li(x).Titel
'                'l.Push(LoggerWriteLiType.Fehler, li(x).Titel, "Media Info", "Lädt")
'                Try

'                    XMLModule.Backup_Load(li(x))

'                    li(x).SaveFile()
'                    l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})

'                Catch ex As Exception
'                    MsgBox("Fehler" & vbCrLf & ex.Message)
'                End Try
'            Else
'                Exit For
'            End If

'        Next


'    End Sub

'    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
'        l.Aktualisieren(e.ProgressPercentage)

'        'pushlist.Clear()
'    End Sub

'    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
'        'laden.Close()
'        For x As Integer = 0 To li.Count - 1
'            li(x).Refresh()
'        Next
'        l.closallowed = True
'        l.Close()
'        l.Dispose()
'        Worker.Dispose()
'    End Sub
'End Class