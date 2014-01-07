Public Class InfoPanel_MultiSelected
    Public Labels() As TextBox
    Property isLoaded As Boolean

    Public Property SelectedEpisode As Episode


    Private Sub MoviemazeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            OpenWebLink("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)

            'Process.Start("http://www.moviemaze.de/suche/result.phtml?searchword=" & TB_Titel.Text)

        Catch ex As Exception

        End Try
    End Sub

#Region "TabControl"
    Private Sub InfoTabs3_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles InfoTabs3.DragOver
        Dim p As Point = InfoTabs3.PointToClient(MousePosition)
        e.Effect = DragDropEffects.Link
        For n As Integer = 0 To InfoTabs3.TabCount - 1
            Dim rc As Rectangle = InfoTabs3.GetTabRect(n)
            If rc.Contains(p) Then
                If Not n = 4 Then
                    InfoTabs3.SelectedIndex = n
                Else
                    MyFunctions.SetHandCursor()

                End If

                Exit For
            End If
        Next
    End Sub


#End Region

#Region "Text_Change"

    Private Sub TB_Titel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Titel.TextChanged
        If Not IsNothing(TB_Titel.Tag) Then
            If TB_Titel.Text = "" Then
                Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Titel.Text = TB_Titel.Tag.ToString Then
                Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Titel.BackgroundImage = Nothing
            End If
        End If
        'exp_speichern.Visible = Panel_info_changed()
    End Sub


    Private Sub TB_Regisseur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Regisseur.TextChanged
        If Not IsNothing(TB_Regisseur.Tag) Then
            If TB_Regisseur.Text = "" Then
                Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Regisseur.Text = TB_Regisseur.Tag.ToString Then
                Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Regisseur.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Autoren_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Autoren.TextChanged
        If Not IsNothing(TB_Autoren.Tag) Then
            If TB_Autoren.Text = "" Then
                Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Autoren.Text = TB_Autoren.Tag.ToString Then
                Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Autoren.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Produktionsjahr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Produktionsjahr.TextChanged
        If Not IsNothing(TB_Produktionsjahr.Tag) Then
            If TB_Produktionsjahr.Text = "" Then
                Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Produktionsjahr.Text = TB_Produktionsjahr.Tag.ToString Then
                Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Produktionsjahr.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Bewertung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Bewertung.TextChanged
        If Not IsNothing(TB_Bewertung.Tag) Then
            If TB_Bewertung.Text = "" Then
                Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Bewertung.Text = TB_Bewertung.Tag.ToString Then
                Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Bewertung.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_Spieldauer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Spieldauer.TextChanged
        If Not IsNothing(TB_Spieldauer.Tag) Then
            If TB_Spieldauer.Text = "" Then
                Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_Spieldauer.Text = TB_Spieldauer.Tag.ToString Then
                Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_Spieldauer.BackgroundImage = Nothing
            End If
        End If
    End Sub


    Private Sub TB_VideoAuflösung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoAuflösung.TextChanged
        If Not IsNothing(TB_VideoAuflösung.Tag) Then
            If TB_VideoAuflösung.Text = "" Then
                Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoAuflösung.Text = TB_VideoAuflösung.Tag.ToString Then
                Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoAuflösung.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoSeitenverhältnis_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoSeitenverhältnis.TextChanged
        If Not IsNothing(TB_VideoSeitenverhältnis.Tag) Then
            If TB_VideoSeitenverhältnis.Text = "" Then
                Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoSeitenverhältnis.Text = TB_VideoSeitenverhältnis.Tag.ToString Then
                Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoSeitenverhältnis.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoBildwiederholungsrate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoBildwiederholungsrate.TextChanged
        If Not IsNothing(TB_VideoBildwiederholungsrate.Tag) Then
            If TB_VideoBildwiederholungsrate.Text = "" Then
                Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoBildwiederholungsrate.Text = TB_VideoBildwiederholungsrate.Tag.ToString Then
                Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoBildwiederholungsrate.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_VideoCodec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_VideoCodec.TextChanged
        If Not IsNothing(TB_VideoCodec.Tag) Then
            If TB_VideoCodec.Text = "" Then
                Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_VideoCodec.Text = TB_VideoCodec.Tag.ToString Then
                Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_VideoCodec.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioKanäle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioKanäle.TextChanged
        If Not IsNothing(TB_AudioKanäle.Tag) Then
            If TB_AudioKanäle.Text = "" Then
                Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioKanäle.Text = TB_AudioKanäle.Tag.ToString Then
                Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioKanäle.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioCodec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioCodec.TextChanged
        If Not IsNothing(TB_AudioCodec.Tag) Then
            If TB_AudioCodec.Text = "" Then
                Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioCodec.Text = TB_AudioCodec.Tag.ToString Then
                Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioCodec.BackgroundImage = Nothing
            End If
        End If
    End Sub
    Private Sub TB_AudioSprachen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_AudioSprachen.TextChanged
        If Not IsNothing(TB_AudioSprachen.Tag) Then
            If TB_AudioSprachen.Text = "" Then
                Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            ElseIf Not TB_AudioSprachen.Text = TB_AudioSprachen.Tag.ToString Then
                Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_orange
            Else
                Table_AudioSprachen.BackgroundImage = Nothing
            End If
        End If
    End Sub

#End Region

#Region "Drag&Drop Textbox"
    Private Sub Textboxes_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragEnter, TB_Spieldauer.DragEnter, TB_Regisseur.DragEnter, TB_Produktionsjahr.DragEnter, TB_Bewertung.DragEnter, TB_Autoren.DragEnter, TB_VideoCodec.DragEnter, TB_AudioSprachen.DragEnter, TB_VideoSeitenverhältnis.DragEnter, TB_Inhalt.DragEnter, TB_VideoBildwiederholungsrate.DragEnter, TB_VideoAuflösung.DragEnter, TB_AudioCodec.DragEnter, TB_AudioKanäle.DragEnter, InfoTabs3.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub


    Private Sub Textboxes_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragOver, TB_Spieldauer.DragOver, TB_Regisseur.DragOver, TB_Produktionsjahr.DragOver, TB_Bewertung.DragOver, TB_Autoren.DragOver, TB_VideoCodec.DragOver, TB_AudioSprachen.DragOver, TB_VideoSeitenverhältnis.DragOver, TB_Inhalt.DragOver, TB_VideoBildwiederholungsrate.DragOver, TB_VideoAuflösung.DragOver, TB_AudioCodec.DragOver, TB_AudioKanäle.DragOver, InfoTabs3.DragOver
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub TB_Titel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Titel.DragDrop
        If isLoaded Then
            TB_Titel.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub


    Private Sub TB_Regisseur_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Regisseur.DragDrop
        If isLoaded Then
            TB_Regisseur.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Autoren_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Autoren.DragDrop
        If isLoaded Then
            TB_Autoren.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub

    Private Sub TB_Produktionsjahr_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Produktionsjahr.DragDrop
        If isLoaded Then
            TB_Produktionsjahr.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub


    Private Sub TB_Bewertung_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Bewertung.DragDrop
        If isLoaded Then
            TB_Bewertung.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Spieldauer_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Spieldauer.DragDrop
        If isLoaded Then
            TB_Spieldauer.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_Inhalt_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_Inhalt.DragDrop
        If isLoaded Then
            TB_Inhalt.Text = CStr(e.Data.GetData(DataFormats.Text).ToString)
        End If
    End Sub
    Private Sub TB_VideoAuflösung_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoAuflösung.DragDrop
        If isLoaded Then
            TB_VideoAuflösung.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoSeitenverhältnis_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoSeitenverhältnis.DragDrop
        If isLoaded Then
            TB_VideoSeitenverhältnis.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoBildwiederholungsrate_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoBildwiederholungsrate.DragDrop
        If isLoaded Then
            TB_VideoBildwiederholungsrate.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_VideoCodec_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_VideoCodec.DragDrop
        If isLoaded Then
            TB_VideoCodec.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioKanäle_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioKanäle.DragDrop
        If isLoaded Then
            TB_AudioKanäle.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioCodec_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioCodec.DragDrop
        If isLoaded Then
            TB_AudioCodec.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub
    Private Sub TB_AudioSprachen_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TB_AudioSprachen.DragDrop
        If isLoaded Then
            TB_AudioSprachen.Text = CStr(e.Data.GetData(DataFormats.Text))
        End If
    End Sub


#End Region

#Region "ContextMenu Textbox"



    Private Sub TB_Titel_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Titel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Titel
        End If
    End Sub


    'Private Sub TB_Darsteller_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Darsteller.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        ContextMenu_TextBox.Tag = TB_Darsteller
    '    End If
    'End Sub
    Private Sub TB_Regisseur_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Regisseur.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Regisseur
        End If
    End Sub
    Private Sub TB_Autoren_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Autoren.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Autoren
        End If
    End Sub

    Private Sub TB_Produktionsjahr_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Produktionsjahr.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Produktionsjahr
        End If
    End Sub


    'Private Sub TB_FSK_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_FSK.MouseUp
    '    If e.Button = Windows.Forms.MouseButtons.Right Then
    '        ContextMenu_TextBox.Tag = TB_FSK
    '    End If
    'End Sub
    Private Sub TB_Bewertung_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Bewertung.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Bewertung
        End If
    End Sub
    Private Sub TB_Spieldauer_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Spieldauer.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Spieldauer
        End If
    End Sub
    Private Sub TB_Inhalt_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB_Inhalt.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenu_TextBox.Tag = TB_Inhalt
        End If
    End Sub



    Private Sub RückgäningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RückgäningToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Undo()
        End If
    End Sub

    Private Sub KopierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Copy()
        End If
    End Sub
    Private Sub EinfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EinfügenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Paste()
        End If
    End Sub
    Private Sub AusschneidenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusschneidenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then
            m.Cut()
        End If
    End Sub

    Private Sub FSKHomepageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FSKHomepageToolStripMenuItem.Click
        If isLoaded Then

            '    '  myBrowser.Navigate("http://www.spio.de/index.asp?SeitID=70&txtFilmtitel=" & TB_Titel.Text & "&selFilmart=ALLE&Sort=az&pagenum=1&pnum=11573a%28VV%29&lineindex=1&VVID=101468")
            OpenWebLink(" http://www.spio.de/index.asp?SeitID=491&TID=70&search=search&txtFilmtitel=" & TB_Titel.Text)
        End If
    End Sub
    Private Sub SuchenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuchenToolStripMenuItem.Click
        Dim m As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)
        If Not IsNothing(m) Then

            '    '  myBrowser.Navigate("http://www.spio.de/index.asp?SeitID=70&txtFilmtitel=" & TB_Titel.Text & "&selFilmart=ALLE&Sort=az&pagenum=1&pnum=11573a%28VV%29&lineindex=1&VVID=101468")
            OpenWebLink("http://www.google.de/#hl=de&source=hp&q=" & TB_Titel.Text & " " & m.Name.Replace("TB_", "") & "&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=&fp=ebbd8e4827c4c9bc")
        End If
    End Sub
    Private Sub GoogleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleToolStripMenuItem1.Click

        Try

            OpenWebLink("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Produktionsjahr.Text & "&btnG=Suche&aq=f&oq=&start=0")
            'Process.Start("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Jahr.Text & "&btnG=Suche&aq=f&oq=&start=0")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SuchenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuchenToolStripMenuItem1.Click

        Try

            OpenWebLink("http://www.google.de/#hl=de&source=hp&q=" & TB_Titel.Text & " " & "FSK" & "&meta=&aq=f&aqi=&aql=&oq=&gs_rfai=&fp=ebbd8e4827c4c9bc")
            'Process.Start("http://images.google.com/images?um=1&hl=de&tbs=isch%3A1&sa=1&q=" & TB_Titel.Text & " " & TB_Jahr.Text & "&btnG=Suche&aq=f&oq=&start=0")

        Catch ex As Exception

        End Try
    End Sub
#End Region
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
ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DarstellerView.RowPostPaint

        drawRectOnDGV(DarstellerView, 1, Color.FromArgb(2, 135, 197), e)
    End Sub
    Private Sub LöschenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LöschenToolStripMenuItem1.Click
        If Not IsNothing(SelectedEpisode) Then


            If MsgBox("Möchten Sie das ausgewählte Bild wirklich löschen?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then

                If IO.File.Exists(SelectedEpisode.bild) Then
                    Try
                        IO.File.Delete(SelectedEpisode.bild)
                        SelectedEpisode.bild = ""

                        PictureBox1.Image = My.Resources.no_cover_bg
                        SelectedEpisode.refresh()

                    Catch ex As Exception

                    End Try
                End If
            End If
        End If
    End Sub


#Region "Toolbar"
 


    Private Sub ToolStripButton_Rückgängig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Rückgängig.Click
        Load_item(SelectedEpisode)
    End Sub
    Private Sub InfoslöschenToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoslöschenToolStripButton3.Click
        If MainForm.cancel_DG_selection = False Then
            'BackdropSB.Visible = False
            'SelectedMovie = Nothing
            'SelectedResult = Nothing
            'PictureBox1.Image.Dispose()
            'PictureBox1.Image = My.Resources.no_cover_bg
            DarstellerView.Rows.Clear()
            'lbl_selectedmovie.Text = 


            For x As Integer = 0 To 23
                Labels(x).Text = ""
                Labels(x).Tag = ""
            Next
            TB_Produktionsjahr.Text = ""
            TB_Titel.Text = ""
            TB_Ordner.Text = IO.Path.GetFileName(SelectedEpisode.Pfad)
            TB_Pfad.Text = SelectedEpisode.Pfad
            TB_Videoheightwidth.Text = ""
            'Reset_tableColors()
            Count_Darsteller.Text = ""
            MainForm.Panel_flagquestion.Visible = False
            MainForm.MyBrowserHelpbar.Visible = False
        End If
    End Sub
    Private Sub ToolStripButton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton18.Click

        If ToolStripButton18.Tag.ToString = "0" Then
            ToolStripButton18.Image = Toolbar16.watched_yes
            ToolStripButton18.Tag = 1
            For Each i In MainForm.GetselectedMovies()
                i.Gesehen = "True"
                i.Datum = CStr(Today.Date)
                i.Refresh()
            Next


        Else
            ToolStripButton18.Image = Toolbar16.watched_no
            ToolStripButton18.Tag = 0
            For Each i In MainForm.GetselectedMovies()
                i.Gesehen = "False"
                i.Datum = ""
                i.Refresh()
            Next
        End If

    End Sub

    Private Sub SicherungErstellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SicherungErstellenToolStripMenuItem.Click
        'If isLoaded Then
        '    SelectedMovie.flag = 0
        '    SelectedEpisode.Save(True)
        '    Load_item(SelectedEpisode)
        '    XMLModule.Backup_Save(SelectedMovie)
        '    SicherungLöschenToolStripMenuItem.Enabled = True
        '    WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & XMLModule.Backup_Date(SelectedMovie.Pfad).ToShortDateString & ")"
        '    WiederherstellenToolStripMenuItem.Enabled = True
        '    ToolStripButton22.Image = Toolbar16.securenormal
        'End If


    End Sub

    Private Sub WiederherstellenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WiederherstellenToolStripMenuItem.Click
        'If isLoaded Then
        '    Dim m As New Movie With {.Pfad = SelectedMovie.Pfad}

        '    XMLModule.Backup_Load(m)
        '    SelectedMovie.flag = 0
        '    'SelectedMovie.Save(True)
        '    backup_to_Panel(m)
        '    ToolStripButton22.Image = Toolbar16.securenormal
        'End If
    End Sub

    Private Sub SicherungLöschenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SicherungLöschenToolStripMenuItem.Click
        'If isLoaded Then
        '    If MsgBox("Möchten Sie die gesicherten Daten wirklich (endgültig) entfernen?", MsgBoxStyle.YesNoCancel, "Sicherung löschen?") = MsgBoxResult.Yes Then
        '        XMLModule.Backup_Delet(SelectedMovie.Pfad)
        '        SicherungLöschenToolStripMenuItem.Enabled = False
        '        WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
        '        WiederherstellenToolStripMenuItem.Enabled = False
        '        ToolStripButton22.Image = Toolbar16.securegray
        '    End If

        'End If
    End Sub

#End Region

    Private Sub DarstellerView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DarstellerView.SelectionChanged




        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies And Not Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName = "" Then

            If DarstellerView.SelectedRows.Count = 1 Then
                If Not DarstellerView.SelectedRows(0).Cells(0).Value Is Nothing Then
                    Dim actor_pfad As String = IO.Path.Combine(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName, Renamer.CheckInvalid_F(CStr(DarstellerView.SelectedRows(0).Cells(0).Value)))
                    If IO.Directory.Exists(actor_pfad) Then
                        If IO.File.Exists(IO.Path.Combine(actor_pfad, "folder.jpg")) Then
                            PictureBox4.Image = MyFunctions.ImageFromJpeg(IO.Path.Combine(actor_pfad, "folder.jpg"))
                            PictureBox4.Visible = True
                        Else
                            PictureBox4.Image = Nothing
                            PictureBox4.Visible = False
                        End If
                    Else
                        PictureBox4.Image = Nothing
                        PictureBox4.Visible = False
                    End If
                Else
                    PictureBox4.Image = Nothing
                    PictureBox4.Visible = False
                End If
            Else
                PictureBox4.Image = Nothing
                PictureBox4.Visible = False
            End If
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            If DarstellerView.SelectedRows.Count = 1 Then


                If Not DarstellerView.SelectedRows(0).Cells(0).Value Is Nothing Then

                    Dim s As String = Renamer.CheckInvalid_F(CStr(DarstellerView.SelectedRows(0).Cells(0).Value))
                    If IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & "\folder.jpg") Then
                        PictureBox4.Image = MyFunctions.ImageFromJpeg(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & "\folder.jpg")
                        PictureBox4.Visible = True
                    ElseIf IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & ".jpg") Then
                        PictureBox4.Image = MyFunctions.ImageFromJpeg(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & s & ".jpg")
                        PictureBox4.Visible = True
                    Else
                        PictureBox4.Image = Nothing
                        PictureBox4.Visible = False
                    End If

                Else
                    PictureBox4.Image = Nothing
                    PictureBox4.Visible = False
                End If
            Else
                PictureBox4.Image = Nothing
                PictureBox4.Visible = False
            End If
        Else
            PictureBox4.Image = Nothing
            PictureBox4.Visible = False
        End If

    End Sub

    Private Sub ContextMenu_TextBox_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenu_TextBox.Opening
        If ContextMenu_TextBox.Items.Count > 7 Then
            Do Until ContextMenu_TextBox.Items.Count = 7
                ContextMenu_TextBox.Items.Remove(ContextMenu_TextBox.Items(7))
            Loop
        End If
        If ContextMenu_TextBox.Tag Is TB_Regisseur Or ContextMenu_TextBox.Tag Is TB_Autoren Then
            Dim tb As TextBox = CType(ContextMenu_TextBox.Tag, TextBox)

            If tb.Text = "" Then

            Else
                Dim tr As New ToolStripSeparator
                ContextMenu_TextBox.Items.Add(tr)
                Dim s() As String = tb.Text.Split(CChar(","))
                If s.Length > 0 Then
                    For x As Integer = 0 To s.Length - 1
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                        ContextMenu_TextBox.Items.Add(s(x).Trim, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)

                    Next
                Else
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                    ContextMenu_TextBox.Items.Add(s(0).Trim, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)
                End If
            End If
        End If
    End Sub
    Private Sub WIKI_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)



            OpenWebLink("http://de.wikipedia.org/w/index.php?search=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub IMDB_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)
            Dim s As String = "de"
            If Einstellungen.Config_BrowserSuche.BrowserSuche_Use_IMDB_COM = True Then
                s = "com"
            End If


            OpenWebLink("http://www.imdb." & s & "/find?s=nm&q=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub tmdb_Darsteller(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim item As ToolStripItem
            item = CType(sender, ToolStripItem)



            OpenWebLink("http://www.themoviedb.org/search?search=" & item.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DarstellerView_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DarstellerView.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim hti As DataGridView.HitTestInfo = DarstellerView.HitTest(e.X, e.Y)

            If hti.Type = DataGridViewHitTestType.Cell Then
                If DarstellerView.Rows(hti.RowIndex).Selected = False Then
                    DarstellerView.ClearSelection()
                    DarstellerView.Rows(hti.RowIndex).Selected = True
                End If
                ContextMenu_Darsteller.Items.Clear()
                If Not DarstellerView.Rows(hti.RowIndex).Cells(0).Value Is Nothing Then
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.imdb, AddressOf IMDB_Darsteller)
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.tmdb, AddressOf tmdb_Darsteller)
                    ContextMenu_Darsteller.Items.Add(DarstellerView.Rows(hti.RowIndex).Cells(0).Value.ToString, My.Icons.OnlineQuellen.wiki, AddressOf WIKI_Darsteller)

                    ContextMenu_Darsteller.Show(DarstellerView.PointToScreen(e.Location))
                End If


            End If


        End If
    End Sub

    Private Sub Nav_Statybar_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nav_Statybar.SizeChanged
        If Nav_Statybar.Size.Width > 400 Then
            Tool_Overwrite.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        Else

            Tool_Overwrite.DisplayStyle = ToolStripItemDisplayStyle.Image
        End If
    End Sub

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()


        Nav_Statybar.Renderer = New MyNativRenderer
        ContextMenu_FSK.Renderer = New MyNativRenderer
        ContextMenu_Folder.Renderer = New MyNativRenderer
        ContextMenu_Cover.Renderer = New MyNativRenderer
        ContextMenu_TextBox.Renderer = New MyNativRenderer

        TabImages.Images.Clear()
        TabImages.Images.Add(InfoTabIcons._2)
        TabImages.Images.Add(InfoTabIcons._2grey)
        TabImages.Images.Add(InfoTabIcons._3)
        TabImages.Images.Add(InfoTabIcons._3grey)
        TabImages.Images.Add(InfoTabIcons._1)
        TabImages.Images.Add(InfoTabIcons._1grey)
        TabImages.Images.Add(InfoTabIcons._4)
        TabImages.Images.Add(InfoTabIcons._4grey)
        TabImages.Images.Add(InfoTabIcons._5)
        TabImages.Images.Add(InfoTabIcons._5grey)
        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        ReDim Labels(23)


        Labels(0) = TB_Pfad
        Labels(1) = TB_Ordner
        'jatz die xml werte:
        Labels(2) = TB_Titel

        'Labels(5) = TB_Darsteller
        Labels(5) = TB_Regisseur
        Labels(6) = TB_Autoren

        Labels(8) = TB_Produktionsjahr


        Labels(12) = TB_Bewertung
        Labels(13) = TB_Spieldauer
        'Labels(15) = TB_Kurzbeschreibung
        Labels(14) = TB_Inhalt
        'Labels(17) = 'media info hat keine textbax ;)



        Labels(16) = TB_VideoAuflösung
        Labels(17) = TB_VideoSeitenverhältnis
        Labels(18) = TB_VideoBildwiederholungsrate
        Labels(19) = TB_VideoCodec
        Labels(20) = TB_AudioKanäle
        Labels(21) = TB_AudioCodec
        Labels(22) = TB_AudioSprachen

    End Sub

    Public Sub refresh_UI_byPlugin()
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            TableLayoutPanel8.Controls.Remove(Table_Bewertung)
            TableLayoutPanel8.Controls.Remove(Table_Produktionsjahr)
            TableLayoutPanel3.Controls.Remove(Table_Regisseur)
            TableLayoutPanel3.Controls.Remove(Table_Autoren)
            TableLayoutPanel8.SetColumnSpan(Table_Pfad, 3)
        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.mymovies Then

        ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.DVDInfo Then

        End If
    End Sub


    Public Function Panel_info_changed() As Boolean
        If isLoaded = False Then
            Return False
        End If
        Dim r As Boolean = False
        For x As Integer = 2 To 23
            If Not CStr(Labels(x).Tag) = Labels(x).Text Then
                r = True
                GoTo re
            End If
        Next
        Dim darsteller As String = ""
        If DarstellerView.RowCount - 1 > 0 Then
            For x As Integer = 0 To DarstellerView.RowCount - 1
                If Not IsNothing(DarstellerView.Rows(x).Cells(0).Value) Then
                    If darsteller = "" Then
                        darsteller = CStr(DarstellerView.Rows(x).Cells(0).Value)
                    Else
                        darsteller &= ", " & DarstellerView.Rows(x).Cells(0).Value.ToString
                    End If
                    If Not IsNothing(DarstellerView.Rows(x).Cells(1).Value) Then
                        If Not DarstellerView.Rows(x).Cells(1).Value.ToString = "" Then
                            darsteller &= " [" & DarstellerView.Rows(x).Cells(1).Value.ToString & "]"
                        End If
                    End If

                End If
            Next
        End If
        If Not CStr(DarstellerView.Tag) = darsteller Then

            r = True
        End If


re:
        Return r
    End Function


    Private Sub OpenWebLink(ByVal p1 As String)
        MainForm.OpenWebLink(p1)
    End Sub
    Public Sub Panel_Clear()
        If MainForm.cancel_DG_selection = False Then
            SicherungLöschenToolStripMenuItem.Enabled = False
            WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
            WiederherstellenToolStripMenuItem.Enabled = False
            ToolStripButton22.Image = Toolbar16.securegray


            PictureBox1.Image.Dispose()
            PictureBox1.Image = My.Resources.no_cover_bg
            DarstellerView.Rows.Clear()
            lbl_selectedmovie.Text = ""


            For x As Integer = 0 To 23
                Labels(x).Text = ""
                Labels(x).Tag = ""
            Next


            TB_Videoheightwidth.Text = ""
            Reset_tableColors()
            Count_Darsteller.Text = ""
            MainForm.Panel_flagquestion.Visible = False
            MainForm.MyBrowserHelpbar.Visible = False
            isLoaded = False
        End If
    End Sub
    Public Sub Reset_tableColors()
        Table_Titel.BackgroundImage = Nothing

        Table_Regisseur.BackgroundImage = Nothing
        Table_Autoren.BackgroundImage = Nothing

        Table_Produktionsjahr.BackgroundImage = Nothing
        Table_Bewertung.BackgroundImage = Nothing
        Table_Spieldauer.BackgroundImage = Nothing


        Table_VideoAuflösung.BackgroundImage = Nothing
        Table_VideoSeitenverhältnis.BackgroundImage = Nothing
        Table_VideoBildwiederholungsrate.BackgroundImage = Nothing
        Table_VideoCodec.BackgroundImage = Nothing
        Table_AudioKanäle.BackgroundImage = Nothing
        Table_AudioCodec.BackgroundImage = Nothing
        Table_AudioSprachen.BackgroundImage = Nothing




    End Sub

#Region "Loading"
    Sub Load_item(ByVal m As Episode)
        With Me


            If Not IsNothing(.PictureBox1.Image) Then
                .PictureBox1.Image.Dispose()
                .PictureBox1.Image = My.Resources.no_cover_bg

            End If
            'If iarr = Daten.arr(19, iarr) Then


            .lbl_selectedmovie.Text = m.Titel

            .TB_AudioKanäle.Text = m.AudioKanäle

            .TB_AudioCodec.Text = m.AudioCodec
            .TB_VideoAuflösung.Text = m.VideoAuflösung
            .TB_Autoren.Text = m.Autoren
            .TB_Bewertung.Text = m.Bewertung
            .TB_VideoBildwiederholungsrate.Text = m.VideoBildwiederholungsrate
            .TB_Inhalt.Text = m.Inhalt
            .TB_Produktionsjahr.Text = m.Jahr
            '.TB_Kurzbeschreibung.Text = m.Kurzbeschreibung
            .TB_Ordner.Text = IO.Path.GetFileName(m.Pfad)
            .TB_Pfad.Text = m.Pfad
            .TB_VideoSeitenverhältnis.Text = m.VideoSeitenverhältnis
            .TB_Regisseur.Text = m.Regisseur

            .TB_Spieldauer.Text = m.Spieldauer
            .TB_AudioSprachen.Text = m.AudioSprachen

            .TB_Titel.Text = m.Titel
            .TB_VideoCodec.Text = m.VideoCodec

            .TB_Videoheightwidth.Text = m.VideoBreite & "x" & m.VideoHöhe





            .lbl_selectedmovie.Tag = m.Titel


            .TB_AudioKanäle.Tag = m.AudioKanäle
            .TB_AudioCodec.Tag = m.AudioCodec
            .TB_VideoAuflösung.Tag = m.VideoAuflösung
            .TB_Autoren.Tag = m.Autoren
            .TB_Bewertung.Tag = m.Bewertung
            .TB_VideoBildwiederholungsrate.Tag = m.VideoBildwiederholungsrate

            .TB_Inhalt.Tag = m.Inhalt
            .TB_Produktionsjahr.Tag = m.Jahr
            '.TB_Kurzbeschreibung.Tag = m.Kurzbeschreibung

            .TB_Ordner.Tag = TB_Ordner.Text

            .TB_Pfad.Tag = m.Pfad
            .TB_VideoSeitenverhältnis.Tag = m.VideoSeitenverhältnis
            .TB_Regisseur.Tag = m.Regisseur

            .TB_Spieldauer.Tag = m.Spieldauer
            .TB_AudioSprachen.Tag = m.AudioSprachen

            .TB_Titel.Tag = m.Titel
            .TB_VideoCodec.Tag = m.VideoCodec



            If m.Gesehen = "True" Then
                .ToolStripButton18.Image = Toolbar16.watched_yes
                .ToolStripButton18.Tag = 1
            Else
                If m.Gesehen = "" Or m.Gesehen = "False" Then
                    .ToolStripButton18.Image = Toolbar16.watched_no
                    .ToolStripButton18.Tag = 0
                Else
                    m.Gesehen = "True"
                    .ToolStripButton18.Image = Toolbar16.watched_yes
                    .ToolStripButton18.Tag = 1
                End If
            End If




            .DarstellerView.Rows.Clear()
            .DarstellerView.Tag = m.Darsteller
            'TB_Darsteller.Text = Daten.arr(5, iarr)
            If Not m.Darsteller = "" Then
                Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
                If Darsteller.Length > 0 Then
                    For x As Integer = 0 To Darsteller.Length - 1
                        Dim DSname_S As String = ""
                        Dim DSrole_S As String = ""
                        If Darsteller(x).Contains("[") Then
                            Dim DSname() As String = Darsteller(x).Split(CChar("["))
                            DSname_S = Trim(DSname(0))
                            DSrole_S = Trim(DSname(1)).Replace("]", "")
                            DSrole_S = DSrole_S.Replace("...", "")
                            DSrole_S = Trim(DSrole_S)
                        Else
                            DSname_S = Trim(Darsteller(x))
                        End If
                        DarstellerView.Rows.Add(DSname_S, DSrole_S)
                    Next
                End If
            End If
            .Count_Darsteller.Text = CStr(DarstellerView.Rows.Count - 1) & " Darsteller"
            .Count_words.Text = CStr(MyFunctions.GetStringWordCount(.TB_Inhalt.Text)) & " Wörter"






            If .DarstellerView.Rows.Count - 1 = 0 Then
                .Darstellertab.ImageIndex = 1
            Else
                .Darstellertab.ImageIndex = 0
            End If

            If .TB_Inhalt.Text = "" Then
                .Inhalttap.ImageIndex = 3
            Else
                .Inhalttap.ImageIndex = 2
            End If
            '.MediaInfotab.ImageIndex = 4
            'For x As Integer = 16 To 22
            '    If .Labels(x).Text = "" Then
            '        .MediaInfotab.ImageIndex = 5
            '    End If
            'Next


            '//////////////////////





            .Reset_tableColors()


            If .TB_Titel.Text = "" Then
                .Table_Titel.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            'If .TB_Darsteller.Text = "" Then
            '    .Table_Darsteller.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            'End If
            If .TB_Regisseur.Text = "" Then
                .Table_Regisseur.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Autoren.Text = "" Then
                .Table_Autoren.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If

            If .TB_Produktionsjahr.Text = "" Then
                .Table_Produktionsjahr.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If



            If .TB_Bewertung.Text = "" Then
                .Table_Bewertung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_Spieldauer.Text = "" Then
                .Table_Spieldauer.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If

            'If .TB_Inhalt.Text = "" Then
            '    .Table_Inhalt.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            'End If

            If .TB_VideoAuflösung.Text = "" Then
                .Table_VideoAuflösung.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoSeitenverhältnis.Text = "" Then
                .Table_VideoSeitenverhältnis.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoBildwiederholungsrate.Text = "" Then
                .Table_VideoBildwiederholungsrate.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_VideoCodec.Text = "" Then
                .Table_VideoCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioKanäle.Text = "" Then
                .Table_AudioKanäle.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioCodec.Text = "" Then
                .Table_AudioCodec.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If
            If .TB_AudioSprachen.Text = "" Then
                .Table_AudioSprachen.BackgroundImage = My.Resources.Infopanel_Table_Backgrounds_red
            End If



            '///////////////////////////


            If XMLModule.Backup_Exists(m.Pfad) Then
                Dim d As Date = XMLModule.Backup_Date(m.Pfad)
                .SicherungLöschenToolStripMenuItem.Enabled = True
                .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen (" & d.ToShortDateString & ")"
                .WiederherstellenToolStripMenuItem.Enabled = True
                .ToolStripButton22.Image = Toolbar16.securenormal
            Else
                .SicherungLöschenToolStripMenuItem.Enabled = False
                .WiederherstellenToolStripMenuItem.Text = "Wiederherstellen"
                .WiederherstellenToolStripMenuItem.Enabled = False
                .ToolStripButton22.Image = Toolbar16.securegray
            End If


            'arr_to_Panel_Backdrops(m)

            'arr_to_Panel_Refresh(m)
            isLoaded = True

        End With

    End Sub


    Public Sub backup_to_Panel(ByVal m As Movie)
        With Me
            .lbl_selectedmovie.Text = m.Titel

            .TB_AudioKanäle.Text = m.AudioKanäle

            .TB_AudioCodec.Text = m.AudioCodec
            .TB_VideoAuflösung.Text = m.VideoAuflösung
            .TB_Autoren.Text = m.Autoren
            .TB_Bewertung.Text = m.Bewertung
            .TB_VideoBildwiederholungsrate.Text = m.VideoBildwiederholungsrate

            .TB_Inhalt.Text = m.Inhalt
            .TB_Produktionsjahr.Text = m.Produktionsjahr
            '.TB_Kurzbeschreibung.Text = m.Kurzbeschreibung

            .TB_Ordner.Text = m.Ordner

            .TB_Pfad.Text = m.Pfad
            .TB_VideoSeitenverhältnis.Text = m.VideoSeitenverhältnis
            .TB_Regisseur.Text = m.Regisseur

            .TB_Spieldauer.Text = m.Spieldauer
            .TB_AudioSprachen.Text = m.AudioSprachen

            .TB_Titel.Text = m.Titel
            .TB_VideoCodec.Text = m.VideoCodec


            If m.Gesehen = "True" Then
                .ToolStripButton18.Image = Toolbar16.watched_yes
                .ToolStripButton18.Tag = 1
            Else
                If m.Gesehen = "" Then
                    .ToolStripButton18.Image = Toolbar16.watched_no
                    .ToolStripButton18.Tag = 0
                Else
                    m.Gesehen = "True"
                    .ToolStripButton18.Image = Toolbar16.watched_yes
                    .ToolStripButton18.Tag = 1
                End If

            End If


            .DarstellerView.Rows.Clear()
            .DarstellerView.Tag = m.Darsteller
            'TB_Darsteller.Text = Daten.arr(5, iarr)
            If Not m.Darsteller = "" Then
                Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
                If Darsteller.Length > 0 Then
                    For x As Integer = 0 To Darsteller.Length - 1
                        Dim DSname_S As String = ""
                        Dim DSrole_S As String = ""
                        If Darsteller(x).Contains("[") Then
                            Dim DSname() As String = Darsteller(x).Split(CChar("["))
                            DSname_S = Trim(DSname(0))
                            DSrole_S = Trim(DSname(1)).Replace("]", "")
                            DSrole_S = DSrole_S.Replace("...", "")
                            DSrole_S = Trim(DSrole_S)
                        Else
                            DSname_S = Trim(Darsteller(x))
                        End If
                        DarstellerView.Rows.Add(DSname_S, DSrole_S)
                    Next
                End If
            End If
            .Count_Darsteller.Text = CStr(DarstellerView.Rows.Count - 1) & " Darsteller"
            .Count_words.Text = CStr(MyFunctions.GetStringWordCount(.TB_Inhalt.Text)) & " Wörter"



        End With
    End Sub


    Public Sub arr_to_Panel_Refresh(ByVal m As Episode)


        m.Refresh()

    End Sub


#End Region

    'Private Sub InfoPanel_Movie_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Me.Tool_Overwrite.DropDown = MainForm.ContextMenu_Overwrite

    'End Sub


End Class
