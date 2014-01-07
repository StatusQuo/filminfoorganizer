Public Class Dialog_Download
    Dim oldprc_save As Integer = 0
    Private Sub Dialog_Download2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler DownloadManager.ItemCompleted, AddressOf Item_Completed
        RemoveHandler DownloadManager.ItemAdded, AddressOf Item_Added
        RemoveHandler DownloadManager.ItemProgress, AddressOf Item_Progress
        RemoveHandler DownloadManager.TimerChanged, AddressOf Timer_Changed
    End Sub

    ''' <summary>
    ''' Zeichnen eines Rechtecks um die selektierte Zeile eines Datagridview
    ''' </summary>
    ''' <param name="theDGV">das DatagridView</param>
    ''' <param name="lineWidth">die Linienstärke</param>
    ''' <param name="lineColor">die Linienfarbe</param>
    ''' <param name="e">DataGridViewRowPostPaintEventArgs des RowPostPaint-Ereignisses</param>
    Public Sub drawRectOnDGV(ByVal theDGV As DataGridView, _
      ByVal lineWidth As Short, _
      ByVal lineColor As Color, _
      ByVal e As DataGridViewRowPostPaintEventArgs)

        ' Anwenden im RowPostPaint-Ereignis des betreffenden Datagridview
        Dim rect As Rectangle
        With theDGV
            If .Rows(e.RowIndex).Selected Then  ' ist die Zeile selektiert?
                rect = .GetRowDisplayRectangle(e.RowIndex, False) ' das Rechteck der aktuellen Zeile
                ' Rechteck für den Rahmen erzeugen
                Dim rec As Rectangle = New Rectangle(rect.X, rect.Y, _
                calcDGVWidth(theDGV) - 1, rect.Height)
                ' Zeichnen des Rahmens
                ControlPaint.DrawBorder(e.Graphics, rec, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid, _
                  lineColor, lineWidth, ButtonBorderStyle.Solid)
            End If
        End With
    End Sub
    ''' <summary>
    ''' Berechnen der aktuellen Breite eines Datagridview 
    ''' </summary>
    ''' <param name="theDGV">das DatagridView</param>
    ''' <returns>Breite des DatagridView</returns>
    Public Function calcDGVWidth(ByVal theDGV As DataGridView) As Integer
        Dim theWidth As Integer
        With theDGV
            For Each c As DataGridViewColumn In .Columns
                If c.Visible = True Then theWidth += c.Width ' nur sichtbare Spaltenbreiten addieren
            Next
            If .RowHeadersVisible Then theWidth += .RowHeadersWidth
            If .Controls(1).Visible Then    ' ist die vertikale Scrollbar aktuell sichtbar?
                'theWidth -= SystemInformation.VerticalScrollBarWidth  ' Breite der Scrollbar
            End If
        End With
        Return theWidth
    End Function
    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, _
  ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) _
  Handles MainList.RowPostPaint
        drawRectOnDGV(MainList, 1, Color.FromArgb(2, 135, 197), e)
    End Sub



    Private Sub Dialog_Download2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler DownloadManager.ItemCompleted, AddressOf Item_Completed
        AddHandler DownloadManager.ItemAdded, AddressOf Item_Added
        AddHandler DownloadManager.ItemProgress, AddressOf Item_Progress
        AddHandler DownloadManager.TimerChanged, AddressOf Timer_Changed

        'Font = SystemFonts.MessageBoxFont
        Timer_Changed()

        Tools_1.Renderer = New MyNativRenderer
        Nav_dummy.Renderer = New MyNativRenderer
        If DownloadManager.Items.Count > 0 Then
            For x As Integer = 0 To DownloadManager.Items.Count - 1
                If DownloadManager.Items(x).Status = DLState.Moving Or DownloadManager.Items(x).Status = DLState.Finished Then
                    DownloadManager.Items(x).Row.Cells(MainColumn_Progress.Index).Value = DownloadManager.Items(x).Precantage * 100
                Else
                    DownloadManager.Items(x).Row.Cells(MainColumn_Progress.Index).Value = (DownloadManager.Items(x)._Info_Loadedsize / DownloadManager.Items(x)._Info_Filesize) * 100
                End If
                'DownloadManager.Items(x).Row.Cells(MainColumn_Progress.Index).Value = (DownloadManager.Items(x)._Info_Loadedsize / DownloadManager.Items(x)._Info_Filesize) * 100
                DownloadManager.Items(x).Row.Cells(MainColumn_Geladen.Index).Value = DownloadManager.Items(x)._Info_Loadedsize
                DownloadManager.Items(x).Row.Cells(MainColumn_Gesamt.Index).Value = DownloadManager.Items(x)._Info_Filesize
                DownloadManager.Items(x).Row.Cells(MainColumn_Status.Index).Value = StatustoString(DownloadManager.Items(x).Status)
                MainList.Rows.Add(DownloadManager.Items(x).Row)
            Next
        End If

        'DataGridView1.Rows.Add(56, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(76, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(87, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView1.Rows.Add(0, "was", "wo", "iew", "iew")
        'DataGridView2.Rows.Add("was", "wo")
        'DataGridView2.Rows.Add("was", "wo")
    End Sub


    Private Sub DataGridView1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainList.SelectionChanged
        If MainList.SelectedRows.Count = 1 Then
            DataGridView2.Rows.Clear()

            Panel4.Visible = True

            Dim m As DownloadItem = CType(MainList.SelectedRows(0).Tag, DownloadItem)
            Label1.Text = m.Titel
            For Each n In m.List
                DataGridView2.Rows.Add(IO.Path.GetFileName(n.Destination), StatustoString(n.Status))
            Next
        Else
            Panel4.Visible = False
        End If
    End Sub
    Public Sub Item_Completed(ByVal item As DownloadItem)

        item.Row.Cells(MainColumn_Status.Index).Value = StatustoString(item.Status)
    End Sub
    Private Sub Panel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click
        MainList.ClearSelection()
    End Sub

    Private Sub Item_Added(ByVal row As DataGridViewRow)
        MainList.Rows.Add(row)
    End Sub

    Private Sub Item_Progress(ByVal item As DownloadItem)
        If item.Status = DLState.Moving Or item.Status = DLState.Finished Then
            item.Row.Cells(MainColumn_Progress.Index).Value = item.Precantage * 100
        Else
            item.Row.Cells(MainColumn_Progress.Index).Value = (item._Info_Loadedsize / item._Info_Filesize) * 100
        End If
        DataGridView1_SelectionChanged(Me, New EventArgs)
        item.Row.Cells(MainColumn_Geladen.Index).Value = item._Info_Loadedsize
        item.Row.Cells(MainColumn_Gesamt.Index).Value = item._Info_Filesize
        item.Row.Cells(MainColumn_Status.Index).Value = StatustoString(item.Status)


        'If item.Row.Selected = True Then
        '    DataGridView2.Rows.Clear()
        '    Panel4.Visible = True
        '    Dim m As DownloadItem = CType(MainList.SelectedRows(0).Tag, DownloadItem)
        '    For Each n In m.List
        '        DataGridView2.Rows.Add(IO.Path.GetFileName(n.Destination), n.Status)
        '    Next
        'End If
        'Me.Refresh()
    End Sub

    Private Sub Timer_Changed()
        Akt_DLs.Text = DownloadManager.tm_active_Downloads
        all_dls.Text = DownloadManager.tm_all_Downloads
        fail_dls.Text = DownloadManager.tm_fail_Downloads
        KBges.Text = DownloadManager.tm_TotalBytes
        KB.Text = DownloadManager.tm_RecievedBytes
        NochKB.Text = DownloadManager.tm_BytesRemains
        KBperSec.Text = DownloadManager.tm_KBytesPerSecound
        Nochzeit.Text = DownloadManager.tm_TimeLeft
        PRC.Text = DownloadManager.tm_Precentage
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        Dim absolutkb As Long = DownloadManager.Count_TotalBytesToReceive
        Dim absolutkb_geladen As Long = DownloadManager.Count_BytesReceived


        Dim prcs As Integer = 0

        'Fortschritt
        If absolutkb_geladen = 0 Or absolutkb = 0 Then
        Else
            'Debug.WriteLine((absolutkb_geladen / absolutkb) * 100)
            prcs = CInt((absolutkb_geladen / absolutkb) * 100)
        End If



        If prcs = 100 Then
            'Dateien
            DownloadManager.CountFileTypes()
            Akt_DLs.Text = CStr(DownloadManager._Count_Allfiles)
            all_dls.Text = "von " & CStr(DownloadManager._Count_Allfiles) & " Dateien"
            If DownloadManager._Count_Failedfiles = 0 Then
                fail_dls.Text = ""
            Else
                fail_dls.Text = CStr(DownloadManager._Count_Failedfiles) & " Fehler"
            End If
            'Kilobyte
            KBges.Text = "/" & WebFunctions.FormatKiloBytes(absolutkb)
            KB.Text = WebFunctions.FormatKiloBytes(absolutkb)
            NochKB.Text = "0 KB"
            KBperSec.Text = "0 KB"
            Nochzeit.Text = "0 Sekunden"
            PRC.Text = "100"
            'Panel3.Visible = False
            Timer1.Stop()
        Else
            'Dateien
            DownloadManager.CountFileTypes()
            Akt_DLs.Text = CStr(DownloadManager._Count_Finishedfiles)
            all_dls.Text = "von " & CStr(DownloadManager._Count_Allfiles) & " Dateien"
            If DownloadManager._Count_Failedfiles = 0 Then
                fail_dls.Text = ""
            Else
                fail_dls.Text = CStr(DownloadManager._Count_Failedfiles) & " Fehler"
            End If

            'Kilobyte
            KBges.Text = "/" & WebFunctions.FormatKiloBytes(absolutkb)
            KB.Text = WebFunctions.FormatKiloBytes(absolutkb_geladen)
            NochKB.Text = WebFunctions.FormatKiloBytes(absolutkb - absolutkb_geladen)
            Dim old As Integer = CInt(Timer1.Tag)

            Dim ans As Integer = CInt((absolutkb_geladen - old) / (Timer1.Interval / 1000))
            If ans > 0 Then
                ' MsgBox("")

                'Speed
                KBperSec.Text = ans & "KB"
                KBperSec.Tag = ans
            Else
                KBperSec.Text = "0 KB"
            End If






            'If Not prcs * 10 - 10 < 0 And Not ProgressBar1.Value = prcs * 10 Then
            '    ProgressBar1.Value = prcs * 10 - 10
            '    ProgressBar1.Value = prcs * 10 - 8
            '    ProgressBar1.Value = prcs * 10 - 6
            '    ProgressBar1.Value = prcs * 10 - 4
            '    ProgressBar1.Value = prcs * 10 - 2
            'End If
            'Label1.Text = prcs
            'ProgressBar1.Value = prcs * 10

            PRC.Text = CStr(prcs)
            'Akt_DLs.Text = wbl.Count(DLState.Finished)
            'all_dls.Text = wbl.Count(DLState.Ready) & " in der Warteschlange"
            PRC.Tag = PRC
            Dim oldprc As Integer = oldprc_save
            oldprc_save = prcs

            'Dim difprc As Integer = CInt((prcs - oldprc))
            Dim difprc As Integer = 0
            If Not ans = 0 Then
                difprc = CInt((absolutkb - absolutkb_geladen) / ans)
            End If
            PRC.Tag = prcs

            If prcs = 100 Then Timer1.Stop()

            If difprc > 0 Then


                'Dim time As Integer = difprc * (100 - prcs)

                Nochzeit.Text = BuildReststring(difprc)

                'If time > 3600 Then
                '    Nochzeit.Text = FormatSeconds(time)
                'ElseIf time >= 60 Then
                '    Nochzeit.Text = FormatSeconds(time, "mm ""Minuten"" ss ""Sekunden""")
                'Else
                '    Nochzeit.Text = FormatSeconds(time, "ss ""Sekunden""")
                'End If


            Else

            End If

            Timer1.Tag = absolutkb_geladen
            'Me.Refresh()
        End If

    End Sub
    Private Function remnull(ByVal s As String) As String
        Dim r As String = "s"
        If s.StartsWith("0") Then
            r = s.Remove(0, 1)
        End If
        Return r
    End Function
    Private Function BuildReststring(ByVal restdauer As Integer) As String
        'If times.Count = 0 Then
        '    Return ""
        'End If
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
            r &= "einige Minuten"
            'r &= remnull(m)

            'If m = "01" Then
            '    r &= " Minute"
            'Else
            '    r &= " Minuten"
            'End If
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
    Public Function FormatSeconds(ByVal nSeconds As Long, _
  Optional ByVal sFormat As String = "HH:mm:ss") As String

        Return CDate("00:00:00").AddSeconds(nSeconds).ToString(sFormat)
    End Function

    Private Sub Ersetzen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ersetzen.Click
        If DownloadManager.isRunning = False Then
            DownloadManager.Run()
        End If

        'DownloadManager.Run()
        'DownloadManager.Run()

        'DownloadManager.Run()
        'DownloadManager.Run()
        'DownloadManager.Run()
        'Panel3.Visible = True
        'Timer1.Start()
    End Sub

    Private Function StatustoString(ByVal s As DLState) As String
        Dim r As String = ""
        If s = DLState.Ready Then
            r = "Bereit"
        ElseIf s = DLState.Finished Then
            r = "Fertig"
        ElseIf s = DLState.Loading Then
            r = "Lädt..."
        ElseIf s = DLState.Loaded Then
            r = "Heruntergeladen"
        ElseIf s = DLState.Moving Then
            r = "Verschieben..."
        End If

        Return r
    End Function


    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = Toolbar16.exiticon

    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = Toolbar16.exit_normal
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        MainList.ClearSelection()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        MainList.Rows.Clear()
        Dim i As New List(Of DownloadItem)
        If DownloadManager.Items.Count > 0 Then
            For x As Integer = 0 To DownloadManager.Items.Count - 1
                If Not DownloadManager.Items(x).Status = DLState.Finished Then
                    DownloadManager.Items(x).Row.Cells(MainColumn_Progress.Index).Value = (DownloadManager.Items(x)._Info_Loadedsize / DownloadManager.Items(x)._Info_Filesize) * 100
                    DownloadManager.Items(x).Row.Cells(MainColumn_Geladen.Index).Value = DownloadManager.Items(x)._Info_Loadedsize
                    DownloadManager.Items(x).Row.Cells(MainColumn_Gesamt.Index).Value = DownloadManager.Items(x)._Info_Filesize
                    DownloadManager.Items(x).Row.Cells(MainColumn_Status.Index).Value = StatustoString(DownloadManager.Items(x).Status)
                    MainList.Rows.Add(DownloadManager.Items(x).Row)
                Else
                    i.Add(DownloadManager.Items(x))
                End If
            Next
        End If
        For Each tiem In i
            DownloadManager.Items.Remove(tiem)
        Next

    End Sub

    Private Sub Dialog_Download2_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Panel6.Location = New System.Drawing.Point(CInt((Panel3.Width - Panel6.Width) / 2), CInt((Panel3.Height - Panel6.Height) / 2))
    End Sub


End Class