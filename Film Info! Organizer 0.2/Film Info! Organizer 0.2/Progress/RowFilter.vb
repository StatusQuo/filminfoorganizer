Public Class RowFilter

    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Public actRows As New List(Of DataGridViewRow)
    Public remRows As List(Of DataGridViewRow)
    Public addRows As List(Of DataGridViewRow)
    Public _filter As String
    Public _text As String
    Dim Thread As New Threading.Thread(AddressOf Filtern)


    ''' <summary>
    ''' Startet den Filter und bricht aktive filterung ab
    ''' </summary>
    ''' <param name="p">Rowlist</param>
    ''' <param name="s">Filtermodus</param>
    ''' <param name="t">Succhstring</param>
    ''' <remarks></remarks>
    Sub run(ByVal p As List(Of DataGridViewRow), ByVal s As String, ByVal t As String)

        actRows = p
        _filter = s
        _text = t.ToLower.Replace("_", " ").Trim
        remRows = New List(Of DataGridViewRow)
        addRows = New List(Of DataGridViewRow)
        'Do Until Worker.IsBusy = False
        '    'Application.DoEvents()
        'Loop
        If _text = "" Or _text = "suchen" Then
            addRows = actRows
            'For Each i In actRows
            '    If Not Main.DataGridView1.Rows.Contains(i) Then
            '        'i.Selected = False
            '        addRows.Add(i)
            '    End If
            'Next
            'Main.DataGridView1.Rows.Clear()
            'Main.DataGridView1.Rows.AddRange(actRows.ToArray)
        Else
            Filtern()

        End If
        'Main.DataGridView1.Rows.AddRange(actRows.ToArray)


        MainForm.Movie_GridView.Rows.Clear()
        For Each i In addRows
            If Not MainForm.Movie_GridView.Rows.Contains(i) Then
                i.Selected = False
                MainForm.Movie_GridView.Rows.Add(i)
            End If
        Next


        'Main.DataGridView1.Rows.AddRange(addRows.ToArray)

        'Main.DataGridView1.Rows.Add(addRows.ToArray)

        'For Each i In remRows
        '    If Main.DataGridView1.Rows.Contains(i) Then
        '        Main.DataGridView1.Rows.Remove(i)
        '    End If
        'Next

        If Not MainForm.Movie_GridView.SortedColumn Is Nothing Then
            If MainForm.Movie_GridView.SortOrder = SortOrder.Ascending Then
                MainForm.Movie_GridView.Sort(MainForm.Movie_GridView.SortedColumn, System.ComponentModel.ListSortDirection.Ascending)
            Else
                MainForm.Movie_GridView.Sort(MainForm.Movie_GridView.SortedColumn, System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
        If actRows.Count = MainForm.Movie_GridView.RowCount Then
            MainForm.Count_Movies.Text = MainForm.Movie_GridView.SelectedRows.Count & " | " & MainForm.Movie_GridView.RowCount & " Filme"
        Else
            MainForm.Count_Movies.Text = MainForm.Movie_GridView.SelectedRows.Count & " | " & MainForm.Movie_GridView.RowCount & " (" & actRows.Count & ")" & " Filme"
        End If


        If MainForm.Movie_GridView.RowCount = 0 And Not actRows.Count = 0 Then
            MainForm.ToolStripTextBox1.BackColor = Color.Tomato
        Else
            MainForm.ToolStripTextBox1.BackColor = Color.White
        End If


        'MsgBox("no")
        'Thread.Start()
        'MsgBox("jo")
        'Worker.RunWorkerAsync()
    End Sub
    Sub run(ByVal p As DataGridViewRow, ByVal s As String, ByVal t As String)

        actRows.Add(p)
        _filter = s
        _text = t.ToLower.Trim.Replace("_", " ")
        remRows = New List(Of DataGridViewRow)
        addRows = New List(Of DataGridViewRow)
        'Do Until Worker.IsBusy = False
        '    'Application.DoEvents()
        'Loop



        If Not _text = "%doppelt" Then
            Filtern()

            For Each i In remRows
                If MainForm.Movie_GridView.Rows.Contains(i) Then
                    MainForm.Movie_GridView.Rows.Remove(i)
                End If
            Next
            For Each i In addRows
                If Not MainForm.Movie_GridView.Rows.Contains(i) Then
                    i.Selected = False
                    MainForm.Movie_GridView.Rows.Add(i)
                End If
            Next
        End If


        If MainForm.Movie_GridView.RowCount = 0 And Not actRows.Count = 0 Then
            MainForm.ToolStripTextBox1.BackColor = Color.Tomato
        Else
            MainForm.ToolStripTextBox1.BackColor = Color.White
        End If

        'Main.DataGridView1.Rows.Clear()



        'Main.DataGridView1.Rows.Add(addRows.ToArray)


        'MsgBox("no")
        'Thread.Start()
        'MsgBox("jo")
        'Worker.RunWorkerAsync()
    End Sub

    Public Sub Filtern()
        If actRows.Count > 0 Then
            If _text = "%doppelt" Then
                For x As Int64 = 0 To actRows.Count - 1
                    For y As Int64 = 0 To actRows.Count - 1
                        If actRows(CInt(x)).Cells(MainForm.Column_IMDB_ID.Index).Value.ToString.ToLower = "" Then
                            remRows.Add(actRows(CInt(x)))
                        ElseIf Not x = y Then
                            If actRows(CInt(x)).Cells(MainForm.Column_IMDB_ID.Index).Value.ToString.ToLower = actRows(CInt(y)).Cells(MainForm.Column_IMDB_ID.Index).Value.ToString.ToLower Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))
                            End If
                        Else
                            remRows.Add(actRows(CInt(x)))
                        End If
                    Next

                Next



            Else






                If _filter = "Personen" Then
                    'Dim remM As New List(Of DataGridViewRow)
                    'Dim addM As New List(Of DataGridViewRow)

                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If .Cells(13).Value.ToString.ToLower.Contains(_text) Or _
                                .Cells(12).Value.ToString.ToLower.Contains(_text) Or _
                                .Cells(11).Value.ToString.ToLower.Contains(_text) Or _
                               Trim(_text) = "" Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))
                            End If
                        End With
                    Next
                ElseIf _filter = "Sammlung" Then

                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If .Cells(MainForm.Column_Set.Index).Value.ToString.ToLower.Contains(_text) Or _
                                 Trim(_text) = "" Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))
                            End If
                        End With
                    Next

                ElseIf _filter = "Genre" Then

                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If .Cells(MainForm.Column_Genre.Index).Value.ToString.ToLower.Contains(_text) Or _
                                 Trim(_text) = "" Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))

                            End If
                        End With
                    Next
                ElseIf _filter = "Jahr" Then

                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If .Cells(MainForm.Column_Produktionsjahr.Index).Value.ToString.ToLower.Contains(_text) Or _
                                 Trim(_text) = "" Then

                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))

                            End If
                        End With
                    Next

                ElseIf _filter = "Fortschritt" Then
                    'Unterschiedlich
                    'min 
                    If _text.StartsWith(">") Then
                        Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                        For x As Int64 = 0 To actRows.Count - 1
                            With actRows(CInt(x))
                                If i = -1 Then
                                    addRows.Add(actRows(CInt(x)))
                                Else
                                    If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) > i Then
                                        addRows.Add(actRows(CInt(x)))
                                    Else
                                        remRows.Add(actRows(CInt(x)))
                                    End If
                                End If
                            End With
                        Next
                    ElseIf _text.StartsWith("=") Then
                        Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                        For x As Int64 = 0 To actRows.Count - 1
                            With actRows(CInt(x))
                                If i = -1 Then
                                    addRows.Add(actRows(CInt(x)))
                                Else
                                    If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) = i Then
                                        addRows.Add(actRows(CInt(x)))
                                    Else

                                        remRows.Add(actRows(CInt(x)))
                                    End If
                                End If
                            End With
                        Next
                    ElseIf _text.StartsWith("<") Then
                        Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                        For x As Int64 = 0 To actRows.Count - 1
                            With actRows(CInt(x))
                                If i = -1 Then
                                    addRows.Add(actRows(CInt(x)))
                                Else
                                    If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) < i Then
                                        addRows.Add(actRows(CInt(x)))
                                    Else
                                        remRows.Add(actRows(CInt(x)))
                                    End If
                                End If
                            End With
                        Next

                    End If
                Else
                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If .Cells(MainForm.Column_Titel.Index).Value.ToString.ToLower.Contains(_text) Or _
                                .Cells(MainForm.Column_Originaltitel.Index).Value.ToString.ToLower.Contains(_text) Or _
                                .Cells(MainForm.Column_Ordner.Index).Value.ToString.ToLower.Contains(_text) Or _
                               Trim(_text) = "" Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                remRows.Add(actRows(CInt(x)))
                            End If
                        End With
                    Next
                End If

            End If


        End If




    End Sub


    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        If actRows.Count > 0 Then
            If _filter = "Personen" Then
                'Dim remM As New List(Of DataGridViewRow)
                'Dim addM As New List(Of DataGridViewRow)

                For x As Int64 = 0 To actRows.Count - 1
                    With actRows(CInt(x))
                        If .Cells(13).Value.ToString.ToLower.Contains(_text) Or _
                            .Cells(12).Value.ToString.ToLower.Contains(_text) Or _
                            .Cells(11).Value.ToString.ToLower.Contains(_text) Or _
                           Trim(_text) = "" Then
                            addRows.Add(actRows(CInt(x)))
                        Else
                            remRows.Add(actRows(CInt(x)))
                        End If
                    End With
                Next


            ElseIf _filter = "Genre" Then

                For x As Int64 = 0 To actRows.Count - 1
                    With actRows(CInt(x))
                        If .Cells(MainForm.Column_Genre.Index).Value.ToString.ToLower.Contains(_text) Or _
                             Trim(_text) = "" Then
                            addRows.Add(actRows(CInt(x)))
                        Else
                            remRows.Add(actRows(CInt(x)))

                        End If
                    End With
                Next
            ElseIf _filter = "Jahr" Then

                For x As Int64 = 0 To actRows.Count - 1
                    With actRows(CInt(x))
                        If .Cells(MainForm.Column_Produktionsjahr.Index).Value.ToString.ToLower.Contains(_text) Or _
                             Trim(_text) = "" Then

                            addRows.Add(actRows(CInt(x)))
                        Else
                            remRows.Add(actRows(CInt(x)))

                        End If
                    End With
                Next
            ElseIf _filter = "Fortschritt" Then
                'Unterschiedlich
                'min 
                If _text.StartsWith(">") Then
                    Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If i = -1 Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) > i Then
                                    addRows.Add(actRows(CInt(x)))
                                Else
                                    remRows.Add(actRows(CInt(x)))
                                End If
                            End If
                        End With
                    Next
                ElseIf _text.StartsWith("=") Then
                    Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If i = -1 Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) = i Then
                                    addRows.Add(actRows(CInt(x)))
                                Else

                                    remRows.Add(actRows(CInt(x)))
                                End If
                            End If
                        End With
                    Next
                ElseIf _text.StartsWith("<") Then
                    Dim i As Integer = Einstellungen.toInt(_text.Remove(0, 1))
                    For x As Int64 = 0 To actRows.Count - 1
                        With actRows(CInt(x))
                            If i = -1 Then
                                addRows.Add(actRows(CInt(x)))
                            Else
                                If Einstellungen.toInt(CStr(.Cells(MainForm.Column_Fortschritt.Index).Value)) < i Then
                                    addRows.Add(actRows(CInt(x)))
                                Else
                                    remRows.Add(actRows(CInt(x)))
                                End If
                            End If
                        End With
                    Next

                End If
            Else
                For x As Int64 = 0 To actRows.Count - 1
                    With actRows(CInt(x))
                        If .Cells(MainForm.Column_Titel.Index).Value.ToString.ToLower.Contains(_text) Or _
                            .Cells(MainForm.Column_Originaltitel.Index).Value.ToString.ToLower.Contains(_text) Or _
                            .Cells(MainForm.Column_Ordner.Index).Value.ToString.ToLower.Contains(_text) Or _
                           Trim(_text) = "" Then
                            addRows.Add(actRows(CInt(x)))
                        Else
                            remRows.Add(actRows(CInt(x)))
                        End If
                    End With
                Next
            End If

        End If


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged

    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        If Not e.Cancelled = True Then
            MainForm.Movie_GridView.Rows.Clear()
            For Each i In addRows
                If Not MainForm.Movie_GridView.Rows.Contains(i) Then
                    i.Selected = False
                    MainForm.Movie_GridView.Rows.Add(i)
                End If
            Next


            'Main.DataGridView1.Rows.Add(addRows.ToArray)

            'For Each i In remRows
            '    If Main.DataGridView1.Rows.Contains(i) Then
            '        Main.DataGridView1.Rows.Remove(i)
            '    End If
            'Next

            If Not MainForm.Movie_GridView.SortedColumn Is Nothing Then
                If MainForm.Movie_GridView.SortOrder = SortOrder.Ascending Then
                    MainForm.Movie_GridView.Sort(MainForm.Movie_GridView.SortedColumn, System.ComponentModel.ListSortDirection.Ascending)
                Else
                    MainForm.Movie_GridView.Sort(MainForm.Movie_GridView.SortedColumn, System.ComponentModel.ListSortDirection.Descending)
                End If
            End If
            If actRows.Count = MainForm.Movie_GridView.RowCount Then
                MainForm.Count_Movies.Text = MainForm.Movie_GridView.SelectedRows.Count & " | " & MainForm.Movie_GridView.RowCount & " Filme"
            Else
                MainForm.Count_Movies.Text = MainForm.Movie_GridView.SelectedRows.Count & " | " & MainForm.Movie_GridView.RowCount & " (" & actRows.Count & ")" & " Filme"
            End If
        End If
    End Sub

End Class

