Imports System.Windows.Forms

Public Class Dialog_Trailer
    Property mvo As Movie

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim item As New DownloadItem
        item.Type = Downloaditemtype.Trailer
        item.DestMovie = mvo

        Dim ts As New WebFile
        Dim tf As TrailerLoader.TrailerFile = CType(TreeViewVista1.SelectedNode.Tag, TrailerLoader.TrailerFile)



        ts.Source = New Uri(WebFunctions.GetResponseURI(tf.URL))

        If ts.Get_Filesize = True Then
            If ts.Info_Filesize > 1 Then
                ts.Destination = WebFunctions.Get_TrailerDes(ts, True)
                item.List.Add(ts)
            End If

        End If
        If Not item.List.Count = 0 Then
            item.Status = DLState.Ready
            DownloadManager.Add(item)
        End If
        If Not DownloadManager.isRunning Then
            DownloadManager.Run()
        End If

        If TrailerScrapper.List.Count > 0 Then
            TrailerScrapper.List.Remove(mvo)
            TrailerScrapper.NextMovie()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        TrailerScrapper.List.Remove(mvo)
        If TrailerScrapper.List.Count > 0 Then

            TrailerScrapper.NextMovie()
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub
    Public Sub TrailerLoad(ByVal tr As TrailerLoader)
        TreeViewVista1.Nodes.Clear()
        For Each s In tr.Result
            Dim pn As New TreeNode
            pn.Text = s.displayTitle
            If s.lng = "de" Then
                pn.SelectedImageIndex = 1
                pn.ImageIndex = 1
            ElseIf s.lng = "en" Then
                pn.SelectedImageIndex = 3
                pn.ImageIndex = 3
            End If
            pn.Tag = s.Files(0).URL
            For Each t In s.Files
                Dim n As New TreeNode
                n.Text = CStr(t.Qualityi)
                n.Tag = t
                pn.Nodes.Add(n)
                If t.Quality = TrailerLoader.TrailerQuality.HD1080 Or t.Quality = TrailerLoader.TrailerQuality.HD720 Then
                    n.SelectedImageIndex = 4
                    n.ImageIndex = 4
                ElseIf t.Quality = TrailerLoader.TrailerQuality.SD360 Then
                    n.SelectedImageIndex = 5
                    n.ImageIndex = 5
                Else
                    n.SelectedImageIndex = 6
                    n.ImageIndex = 6
                End If





            Next
            TreeViewVista1.Nodes.Add(pn)
        Next
        TreeViewVista1.ExpandAll()
        If TreeViewVista1.Nodes.Count > 0 Then
            TreeViewVista1.SelectedNode = TreeViewVista1.Nodes(0)
        End If



    End Sub


    Private Sub TreeViewVista1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewVista1.AfterSelect
        If TypeOf TreeViewVista1.SelectedNode.Tag Is String Then
            Try
                Player.Play(WebFunctions.GetResponseURI(CStr(TreeViewVista1.SelectedNode.Tag)))
                'UserControl21.Play("http://downloads.paramount.com/mp/Thor/Thor_Trl1_1080.mov")
            Catch ex As Exception

            End Try
            OK_Button.Enabled = False
        ElseIf TypeOf TreeViewVista1.SelectedNode.Tag Is TrailerLoader.TrailerFile Then
            Dim tf As TrailerLoader.TrailerFile = CType(TreeViewVista1.SelectedNode.Tag, TrailerLoader.TrailerFile)
            Player.Play(WebFunctions.GetResponseURI(CStr(tf.URL)))

            OK_Button.Enabled = True
        End If



    End Sub



    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click

        Panel_Suche.BringToFront()

        ToolStripTextBox_Suche.Visible = True
        ToolStripButton1.Visible = True
        ToolStripButton2.Visible = False

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim list As New List(Of ListViewItem)
        ListViewVista1.Items.Clear()
        For Each s In TrailerScrapper.MySearch.Search(ToolStripTextBox_Suche.Text).Li
            Dim li As New ListViewItem
            li.Text = s.Titel
            li.Tag = s.TrailerURI
            li.Group = ListViewVista1.Groups(s.Genauigkeit)
            list.Add(li)
        Next
        ListViewVista1.Items.AddRange(list.ToArray)
    End Sub

    Private Sub ListViewVista1_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewVista1.ItemActivate

        If ListViewVista1.SelectedItems.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            TrailerLoad(New TrailerLoader(CStr(ListViewVista1.SelectedItems(0).Tag)))
            Me.Cursor = Cursors.Default

            Panel_trailer.BringToFront()


            ToolStripTextBox_Suche.Visible = False
            ToolStripButton1.Visible = False
            ToolStripButton2.Visible = True
        End If


    End Sub


    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        ToolStrip1.Renderer = New MyNativRenderer
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Player.ShowControls = True
    End Sub

    Private Sub Dialog_Trailer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler Player.FullScreeStateChanged, AddressOf UserControl21__DoubleClick
    End Sub

    Private Sub Dialog_Trailer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddHandler Player.FullScreeStateChanged, AddressOf UserControl21__DoubleClick
    End Sub




    Private Sub ToolStripTextBox_Suche_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Suche.TextChanged
        ListViewVista1.Items.Clear()


        Dim list As New List(Of ListViewItem)
        If Not TrailerScrapper.MySearch.Search(ToolStripTextBox_Suche.Text).Li.Count > 100 Then
            For Each s In TrailerScrapper.MySearch.Search(ToolStripTextBox_Suche.Text).Li
                Dim li As New ListViewItem
                li.Text = s.Titel
                li.Tag = s.TrailerURI
                li.Group = ListViewVista1.Groups(s.Genauigkeit)
                list.Add(li)
            Next
            ListViewVista1.Items.AddRange(list.ToArray)


        End If

    End Sub

    Private Sub UserControl21__DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        If Player.isFullScreen Then
            Me.SuspendLayout()
            ToolStrip1.Visible = False
            Panel1.Visible = False
            Panel2.Visible = False
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.WindowState = FormWindowState.Maximized
            PictureBox1.Visible = False
            Me.ResumeLayout()
        Else
            Me.SuspendLayout()
            ToolStrip1.Visible = True
            Panel1.Visible = True
            Panel2.Visible = True
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.WindowState = FormWindowState.Normal
            PictureBox1.Visible = True
            Me.ResumeLayout()
        End If
    End Sub

    'Private Sub PictureBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ToolStrip1.Visible Then
    '        PictureBox2.Image = My.Resources.but_fulls_hover
    '    Else
    '        PictureBox2.Image = My.Resources.but_nofulls_hover
    '    End If


    'End Sub

    'Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ToolStrip1.Visible Then
    '        PictureBox2.Image = My.Resources.but_fulls_normal
    '    Else
    '        PictureBox2.Image = My.Resources.but_nofulls_normal
    '    End If
    'End Sub

    'Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If ToolStrip1.Visible Then
    '        ToolStrip1.Visible = False
    '        Panel1.Visible = False
    '        Panel2.Visible = False
    '    Else
    '        ToolStrip1.Visible = True
    '        Panel1.Visible = True
    '        Panel2.Visible = True
    '    End If
    '    If ToolStrip1.Visible Then
    '        PictureBox2.Image = My.Resources.but_fulls_hover
    '    Else
    '        PictureBox2.Image = My.Resources.but_nofulls_hover
    '    End If
    'End Sub


    'Private Sub Panel3_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.SizeChanged
    '    PictureBox2.Invalidate()
    'End Sub

    Private Sub ToolStripTextBox_Suche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripTextBox_Suche.Click

    End Sub
End Class
