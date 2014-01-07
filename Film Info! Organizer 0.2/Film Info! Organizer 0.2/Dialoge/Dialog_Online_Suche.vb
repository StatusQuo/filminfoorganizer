Imports System.Windows.Forms

Public Class Dialog_OnlineSuche
    'Public results As New List(Of Search_Result)
    'Public List As New List(Of Movie)
    'Public movie As Movie
    Public Docked As Boolean = False

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If ListViewVista1.SelectedItems.Count = 1 Then
            If TypeOf ListViewVista1.SelectedItems(0).Tag Is Search_Result = True Then
                'Me.Cursor = Cursors.WaitCursor
                Dim s As Search_Result = CType(ListViewVista1.SelectedItems(0).Tag, Search_Result)
                MetaScrapper.movie.flag = 0
                'Meta.Save(movie, s)

                'Meta.List.Remove(movie)

                MetaScrapper.BackgroundComplete(MetaScrapper.movie, s)
                Me.Enabled = False
                'Meta.NextMovie()
                'If Meta.List.Count > 0 Then
                '    If Meta.List.Count = 1 Then
                '        ToolStripButton_Abbrechen.Visible = False
                '    End If
                '    ToolStripButton_Abbrechen.Text = "Alle Abbrechen (" & Meta.List.Count & ")"
                '    movie = Meta.List(0)
                '    Meta.Vorschau_erstellen(movie.Titel)
                '    Me.Cursor = Cursors.Default
                'Else
                '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                '    Me.Close()
                'End If
            End If
        End If

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        MetaScrapper.List.Remove(MetaScrapper.movie)
        MetaScrapper.NextMovie()

        'If List.Count > 0 Then
        '    Me.Cursor = Cursors.WaitCursor
        '    If List.Count = 1 Then
        '        ToolStripButton_Abbrechen.Visible = False
        '    End If
        '    ToolStripButton_Abbrechen.Text = "Alle Abbrechen (" & List.Count & ")"
        '    movie = List(0)
        '    Meta.Vorschau_erstellen(movie.Titel)
        '    Me.Cursor = Cursors.Default
        'Else
        '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        '    Me.Close()
        'End If

    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        ToolStripDropDownButton1.DropDown = MainForm.ContextMenu_Overwrite
        ToolStrip1.Renderer = New MyNativRenderer
        Nav_Datagrid.Renderer = New MyNativRenderer
        'Font = SystemFonts.MessageBoxFont

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If ListViewVista1.SelectedItems.Count = 1 Then
            TMDBImages.Get_ImageLinks(MetaScrapper.movie, TryCast(ListViewVista1.SelectedItems(0).Tag, Search_Result).IMDB_ID, Fanartsearchmode.Dialog)
        End If


    End Sub

    Public Sub ListViewVista1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListViewVista1.SelectedIndexChanged
        If ListViewVista1.SelectedItems.Count = 0 Then
            OK_Button.Enabled = False
            ToolStripButton2.Enabled = False
            ToolStripButton4.Enabled = False
        ElseIf ListViewVista1.SelectedItems.Count = 1 Then
            OK_Button.Enabled = True
            ToolStripButton2.Enabled = True
            ToolStripButton4.Enabled = True
            If TypeOf ListViewVista1.SelectedItems(0).Tag Is Search_Result = True Then
                Dim s As Search_Result = CType(ListViewVista1.SelectedItems(0).Tag, Search_Result)
                If s.meta_loaded = True Then
                    If Not IsNothing(s.pic) Then
                        PictureBox1.Image = s.pic
                    Else
                        PictureBox1.Image = My.Resources.no_cover_bg

                    End If
                    PictureBox4.Visible = False
                    lbl_titel.Text = s.Titel
                    lbl_jahr.Text = s.Produktionsjahr
                    lbl_Ordner.Text = MetaScrapper.movie.Ordner

                    lbl_bewertung.Text = s.Bewertung
                    lbl_darsteller.Text = s.Darsteller.Replace(", ", vbCrLf)
                    lbl_imdbid.Text = s.IMDB_ID
                    lbl_imdbid.Tag = "http://www.imdb.com/title/tt" & s.IMDB_ID
                    lbl_inhaltfull.Text = s.Inhalt
                    lbl_Land.Text = s.Produktionsland
                    lbl_Regie.Text = s.Regisseur
                    lbl_otitel.Text = s.Originaltitel

                    Panel2.Visible = CheckBox1.Checked
                    CheckBox1.Visible = True

                    lbl_Genre.Text = s.Genre
                    lbl_Inhalt.Text = s.Kurzbeschreibung

                Else
                    PictureBox4.Visible = True
                    PictureBox1.Image = My.Resources.no_cover_bg
                    lbl_titel.Text = s.Titel
                    lbl_jahr.Text = s.Produktionsjahr

                    lbl_Genre.Text = ""
                    lbl_Inhalt.Text = ""
                    lbl_bewertung.Text = ""
                    lbl_darsteller.Text = ""
                    lbl_imdbid.Text = ""
                    lbl_inhaltfull.Text = ""
                    lbl_Land.Text = ""
                    lbl_Regie.Text = ""
                    lbl_otitel.Text = ""

                    Panel2.Visible = False
                    CheckBox1.Visible = False

                    lbl_Ordner.Text = MetaScrapper.movie.Ordner
                    s.litem.ImageIndex = 1
                    'Dim bgw As New Meta_backgroundloader
                    'bgw.s = s
                    'bgw.m = movie
                    'bgw.Worker.RunWorkerAsync()
                    MetaScrapper.BackgroundLoading(s)

                End If

            End If
        End If
    End Sub

    Private Sub ToolStripButton_Abbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Abbrechen.Click



        'List.Clear()
        'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        'Me.Close()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(MetaScrapper.movie.Row) Then
            MainForm.Movie_GridView.ClearSelection()
            MetaScrapper.movie.Row.Selected = True

        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If Not ToolStripTextBox_Suche.Text = "" Then
            MetaScrapper.BackgroundSearching(ToolStripTextBox_Suche.Text)
        End If

    End Sub



    Private Sub CheckBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CheckBox1.Checked = Not CheckBox1.Checked
        Panel2.Visible = CheckBox1.Checked
        'PictureBox5.Visible = CheckBox1.Checked
    End Sub

    Private Sub lbl_imdbid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_imdbid.Click
        Try
            Process.Start(lbl_imdbid.Tag.ToString)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not ToolStripTextBox_Suche.Text = "" Then
            MetaScrapper.BackgroundSearching(ToolStripTextBox_Suche.Text)
        End If

    End Sub

    Private Sub Panel4_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        Panel4.Location = New System.Drawing.Point(CInt((Panel3.Width - Panel4.Width) / 2), CInt((Panel3.Height - Panel4.Height) / 2))
    End Sub

    Private Sub Dialog_OnlineSuche_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        'If Me.Location.X > Main.Location.X + Main.Size.Width - 50 And Me.Location.X < Main.Location.X + Main.Size.Width + 50 Then
        '    Me.Location = New Point(Main.Location.X + Main.Size.Width, Me.Location.Y)
        '    Me.Docked = True
        'End If
    End Sub

    Private Sub Dialog_OnlineSuche_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Panel4.Location = New System.Drawing.Point(CInt((Panel3.Width - Panel4.Width) / 2), CInt((Panel3.Height - Panel4.Height) / 2))
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        If ListViewVista1.SelectedItems.Count = 1 Then
            Dim d As New Dialog_Online_Save
            d.m = MetaScrapper.movie
            If TypeOf ListViewVista1.SelectedItems(0).Tag Is Search_Result = True Then
                Dim s As Search_Result = CType(ListViewVista1.SelectedItems(0).Tag, Search_Result)
                If s.meta_loaded = True Then
                    d.r = s
                    If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        d.modifyResult()
                        MetaScrapper.BackgroundComplete(MetaScrapper.movie, s)

                    End If

                End If


            End If



        End If


    End Sub



    Private Sub LightButton1_Checkchanged() Handles CheckBox1.Checkchanged
        Panel2.Visible = CheckBox1.Checked
    End Sub

    Private Sub Dialog_OnlineSuche_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        MetaScrapper.List.Clear()

        MainForm.Select()
    End Sub




    'Private Sub ToolStripTextBox_Suche_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        MetaScrapper.BackgroundSearching(ToolStripTextBox_Suche.Text)
    '    End If
    '    If e.KeyCode = Keys.Down Then
    '        ContextMenuStrip1.Show(ToolStripTextBox_Suche.Control, 0, ToolStrip1.Height - 5)
    '    End If
    'End Sub

    'Private Sub ContextMenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '    ToolStripTextBox_Suche.Text = e.ClickedItem.Text
    '    MetaScrapper.BackgroundSearching(ToolStripTextBox_Suche.Text)
    'End Sub

    Private Sub ListViewVista1_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewVista1.ColumnClick
    
        ' Create an instance of the ColHeader class. 
        Dim clickedCol As ColHeader = CType(Me.ListViewVista1.Columns(e.Column), ColHeader)

        ' Set the ascending property to sort in the opposite order.
        clickedCol.ascending = Not clickedCol.ascending

        ' Get the number of items in the list.
        Dim numItems As Integer = Me.ListViewVista1.Items.Count

        ' Turn off display while data is repoplulated.
        Me.ListViewVista1.BeginUpdate()

        ' Populate an ArrayList with a SortWrapper of each list item.
        Dim SortArray As New ArrayList
        Dim i As Integer
        For i = 0 To numItems - 1
            SortArray.Add(New SortWrapper(Me.ListViewVista1.Items(i), e.Column))
        Next i

        ' Sort the elements in the ArrayList using a new instance of the SortComparer
        ' class. The parameters are the starting index, the length of the range to sort,
        ' and the IComparer implementation to use for comparing elements. Note that
        ' the IComparer implementation (SortComparer) requires the sort  
        ' direction for its constructor; true if ascending, othwise false.
        SortArray.Sort(0, SortArray.Count, New SortWrapper.SortComparer(clickedCol.ascending))

        ' Clear the list, and repopulate with the sorted items.
        Me.ListViewVista1.Items.Clear()
        Dim z As Integer
        For z = 0 To numItems - 1
            Me.ListViewVista1.Items.Add(CType(SortArray(z), SortWrapper).sortItem)
        Next z
        ' Turn display back on.
        Me.ListViewVista1.EndUpdate()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        If Not IsNothing(MetaScrapper.movie) Then
            Try
                Process.Start(MetaScrapper.movie.Files(0))
            Catch ex As Exception

            End Try
        End If
    End Sub



    Private Sub ToolStripButton_Abbrechen_DropDownOpening(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Abbrechen.DropDownOpening
        ToolStripButton_Abbrechen.DropDownItems.Clear()
        Dim l As ToolStripLabel
        If Not MetaScrapper.movie Is Nothing Then
            l = New ToolStripLabel
            l.Text = MetaScrapper.movie.Titel
            ToolStripButton_Abbrechen.DropDownItems.Add(l)
        End If
        If Not MetaScrapper.List Is Nothing Then
            For Each m In MetaScrapper.List
                If Not m Is MetaScrapper.movie Then
                    l = New ToolStripLabel
                    l.Text = m.Titel
                    l.ForeColor = SystemColors.GrayText
                    ToolStripButton_Abbrechen.DropDownItems.Add(l)
                End If

            Next
        End If
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()
        ImageList1.Images.Clear()
        ImageList1.Images.Add(Toolbar16.Ok)
        ImageList1.Images.Add(Toolbar16.Download_aktive)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub
End Class
