Public Class Laden_Dialog


    Dim oTime As New System.Diagnostics.Stopwatch
    'Dim times As New List(Of Long)
    Dim times As Long = 0
    Dim timesc As Long = 0
    Dim restdauer As Long
    Property Timecounter As Boolean = True
    Property Aktuell As Integer = 0
    Property Gesamtzahl As Integer = 0
    Property Labelstring As String = ""
    Property Cancel As Boolean = False
    Property closallowed As Boolean = False
    Property advLabelstring As String = ""
    Property IntroductionText As String
        Get
            Return Label2.Text
        End Get
        Set(ByVal value As String)
            Label2.Text = value
        End Set
    End Property
    Property aDetails As Boolean
        Get
            Return CheckBox1.Visible
        End Get
        Set(ByVal value As Boolean)
            CheckBox1.Visible = False
        End Set
    End Property
    Property aCancel As Boolean
        Get

            Return Button1.Enabled

        End Get
        Set(ByVal value As Boolean)
            Button1.Enabled = value
            Me.ControlBox = value
        End Set
    End Property

    Property costumlabel As Boolean = False

    Sub Aktualisieren()
        If Not Gesamtzahl = 0 Then
            Label1.Text = Labelstring & "... " & Aktuell & "/" & Gesamtzahl

            If Aktuell <= Gesamtzahl Then
                ProgressBar1.Value = CInt((Aktuell / Gesamtzahl) * 100)
            End If

            Me.Refresh()
        End If

    End Sub
    Sub Aktualisieren(ByVal p As Integer)
        If Cancel = False Then
            If costumlabel = False Then
            Else
                Label1.Text = Labelstring

            End If
            Label1.Text = Labelstring
            If Not Gesamtzahl = 0 Then
                Label3.Text = Aktuell & " von " & Gesamtzahl
            End If

            If Not advLabelstring = "" Then
                Label5.Text = advLabelstring
            End If
            'Label1.Text = CStr(p)
            If Timecounter = True Then
                restzeit()
            End If

            If Aktuell <= Gesamtzahl Then

                ProgressBar1.Value = p
            End If

            Me.Refresh()

        End If

    End Sub
    Sub Nächster()
        If Not Aktuell = 0 Then
            oTime.Stop()
            times += oTime.ElapsedMilliseconds
            timesc += 1
            'times.Add(oTime.ElapsedMilliseconds)
            oTime.Reset()

        End If



        Aktuell += 1
        If Timecounter = True Then
            oTime.Start()
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cancel = True
        Button1.Enabled = False
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Label1.Text = "Vorgang wird abgebrochen..."
        Me.Refresh()
    End Sub

    Private Sub Laden_Dialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        'Font = SystemFonts.MessageBoxFont
        'Me.Refresh()
        If IntroductionText = "Laden" Then
            IntroductionText = Me.Text
        End If
        TopMost = False
        'If Timecounter = True Then
        '    Timer1.Start()
        'End If

    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        'Me.Font = SystemFonts.MessageBoxFont
        TableLayoutPanel1.AutoSize = False
        TableLayoutPanel2.AutoSize = False
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Delegate Sub TimeDelegant(ByVal s As String)

    Public Sub TimeChange(ByVal s As String)
        Timelabel.Text = s
    End Sub
    Private Sub Laden_Dialog_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If closallowed = False Then
            Cancel = True
            Button1.Enabled = False
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Label1.Text = "Vorgang wird abgebrochen..."
            Me.Refresh()

            e.Cancel = True
        End If

    End Sub

    Public Sub RefreshMovie(ByVal m As Movie)
        m.Refresh()
    End Sub

    Private Function addnull(ByVal i As Integer) As String
        If i < 10 Then
            Return "0" & i
        Else
            Return CStr(i)
        End If
    End Function
    Private Sub restzeit()
        If timesc > 0 Then


            'Dim li As List(Of Long) = times
            'Dim g As Long = times
            Dim avarage As Long = CLng(times / timesc)
            Dim rest As Long = CLng((avarage * (Gesamtzahl - Aktuell)) / 1000)
            restdauer = rest
            Timelabel.Text = BuildReststring()
        End If

    End Sub
    Private Function BuildReststring() As String
        If timesc = 0 Then
            Return ""
        End If
        Dim r As String = "Noch "
        Dim h As String = MyFunctions.FormatSeconds(restdauer, "HH")
        Dim m As String = MyFunctions.FormatSeconds(restdauer, "mm")
        Dim s As String = MyFunctions.FormatSeconds(restdauer, "ss")
        If Not h = "00" Then
            r &= remnull(h)
            If h = "01" Then
                r &= " Stunde"
            Else
                r &= " Stunden"
            End If
        ElseIf Not m = "00" Then
            r &= remnull(m)
            If m = "01" Then
                r &= " Minute"
            Else
                r &= " Minuten"
            End If
        Else
            'r &= remnull(s)
            'If s = "01" Then
            '    r &= " Sekunde"
            'Else
            '    r &= " Sekunden"
            'End If
            r &= "wenige Sekunden"
        End If
        Return r
    End Function
    Private Function remnull(ByVal s As String) As String
        Dim r As String = "s"
        If s.StartsWith("0") Then
            r = s.Remove(0, 1)
        End If
        Return r
    End Function
    Private Function summe(ByVal f As List(Of Long)) As Long

        Dim r As Long = 0
        For Each i In f
            r += i
        Next
        Return r
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.IsHandleCreated Then
            Dim s As String = BuildReststring()
            Me.Timelabel.Invoke(New TimeDelegant(AddressOf TimeChange), New Object() {s})
            'Timelabel.Text = "Restzeit: " & MyFunctions.FormatSeconds(restdauer, "HH") & "h " & MyFunctions.FormatSeconds(CLng(restdauer), "mm") & "m " & MyFunctions.FormatSeconds(restdauer, "ss") & "s"
            Timelabel.Refresh()
        End If

    End Sub


    Private Sub Laden_Dialog_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class