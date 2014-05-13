Imports System.IO
Imports Film_Info__Organizer.MyFunctions
Imports System.Xml
Imports System.Text.RegularExpressions
Imports Microsoft.WindowsAPICodePack.Dialogs

Public Class Progress_Rename
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Umbenennen"
        l.Labelstring = "Film wird umbenannt"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                'Threading.Thread.Sleep(200)
                Renamer.ChangeFolderName(li(x))
                Renamer.ChangeFileName(li(x))
                'Dim g As String = Meta.GetGenres(li(x).IMDB_ID)
                'If g = "" Then
                'Else
                '    li(x).Genre = g
                '    li(x).Refresh()
                '    li(x).SaveFile()
                'End If
            Else
                Exit For
            End If

        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Export
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Exportieren"
        l.Labelstring = "Film wird gespeichert"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()


    End Sub
    Property Vorlage As String
    Property path As String
    Dim exoprter As DataExport

    Property replace As New List(Of ReplaceItem)

    Public Sub Run()
        exoprter = New DataExport(li, Vorlage, path)
        exoprter.l = l
        exoprter.worker = Worker
        exoprter.replacer = replace
        l.Show()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        exoprter.Run()


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        exoprter.StartResult()

        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Genre
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Genre abrufen"
        l.Labelstring = "Rufe Genre ab"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                'pushlist.Add("Lade..." & li(x).Titel)
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                'Threading.Thread.Sleep(200)
                'Renamer.ChangeFolderName(li(x))
                'Renamer.ChangeFileName(li(x))
                'Dim s As String = "Fertig..." & li(x).Titel
                'l.Push("Lade..." & li(x).Titel)

                Dim g As String = MetaScrapper.GetGenres(li(x).IMDB_ID)
                If g = "" Then
                    'l.Push("Genre geändert..." & g)
                    'l.Push("Nicht gefunden..." & li(x).Titel)
                    Dim g2 As String = Einstellungen.GenreFilter.ChangeGenre(li(x).Genre)
                    If Not li(x).Genre = g2 Then
                        li(x).Genre = g2
                        li(x).SaveFile()
                    End If
                Else
                    li(x).Genre = Einstellungen.GenreFilter.ChangeGenre(g)

                    li(x).SaveFile()
                    'l.Push("Genre geändert..." & g)
                    'l.Push("Fertig..." & li(x).Titel)
                End If


            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_one_Thumb
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property m As Movie
    Dim r As Boolean = False
    Dim sh As New MoviesheetCreator
    Sub New(ByVal mo As Movie)
        m = mo
        Worker.WorkerReportsProgress = False
        Worker.WorkerSupportsCancellation = True

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork


        sh.Creat(m)
        If sh.Results.Count > 0 Then
            r = True
        End If

    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        MainForm.exp_Download.Image = Toolbar16.View_extragroß
        MainForm.Cover_Tool.Image = Toolbar16.View_extragroß
        If r = True Then
            sh.Builddialog()
        Else
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Warning
                .MyToolTip.ToolTipTitle = "Fehlgeschlagen"
                .MyToolTip.Show("Es konnten keine Thumbnails für diesen Film erstellt werden", MainForm, 20, 40, 2000)
            End With

        End If
    End Sub
End Class
Public Class Progress_one_Backs
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property m As Movie
    Property id As String
    Dim r As Boolean = False
    Sub New(ByVal mo As Movie, ByVal ido As String)
        m = mo
        id = ido
        Worker.WorkerReportsProgress = False
        Worker.WorkerSupportsCancellation = True

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        r = TMDBImages.Get_ImageLinks(id)
    End Sub
    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        If Einstellungen.UserAbrufen.Download_Mode = OnlineSearchmode.Normal Then
            MainForm.exp_Download.Image = Toolbar16.View_extragroß
            MainForm.Cover_Tool.Image = Toolbar16.View_extragroß
        Else
            MainForm.exp_Download.Image = Toolbar16.Fanart_search_fast
            MainForm.Cover_Tool.Image = Toolbar16.Fanart_search_fast
        End If

        If r = True Then
            Dialog_Fanart.movie = m
            TMDBImages.BuildDialog()
        Else
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Warning
                .MyToolTip.ToolTipTitle = "Film nicht gefunden"
                .MyToolTip.Show("Es konnten keine Bilder für diesen Film gefunden werden", MainForm, 20, 40, 2000)
            End With
        End If
    End Sub
End Class
Public Class Progress_one_Search
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property m As Movie
    Property id As String
    Property titel As String
    Property jahr As String
    Property sMode As OnlineSearchmode
    Dim r As Boolean = False
    Dim sr As Search_Result = Nothing
    Sub New(ByVal mo As Movie, ByVal ido As String, ByVal Titels As String, ByVal Jahrs As String, ByVal mode As OnlineSearchmode)
        m = mo
        id = ido
        jahr = Jahrs
        titel = Titels
        sMode = mode
        Worker.WorkerReportsProgress = False
        Worker.WorkerSupportsCancellation = True

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        If sMode = OnlineSearchmode.Automatisch Then
            sr = MetaScrapper.Suche_Schnell(m, titel)
            'If MetaScrapper.Results.Count > 0 Then
            '    r = True
            'End If
        Else
            sr = MetaScrapper.Suche(m, titel, id, jahr)
            If MetaScrapper.Results.Count > 0 Then
                r = True
            End If
        End If





    End Sub
    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        Dim i As Image = Toolbar16.Suche_datenbank
        If Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch Then
            i = Toolbar16.search_schnell1
        ElseIf Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Exact Then
            i = Toolbar16.search_exact1
        ElseIf Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Normal Then
            i = Toolbar16.Suche_datenbank
        End If
        MainForm.ToolStrip_Suche.Image = i
        MainForm.Exp_Suche.Image = i

        If sr Is Nothing Then
            If Einstellungen.UserAbrufen.Suche_Mode = OnlineSearchmode.Automatisch Then
                With MainForm
                    .MyToolTip.ToolTipIcon = ToolTipIcon.Warning
                    .MyToolTip.ToolTipTitle = "Film nicht gefunden"
                    .MyToolTip.Show("Der Film mit dem Titel """ & titel & """ konnte nicht gefunden werden", MainForm, 20, 40, 2000)
                End With
            Else
                MetaScrapper.BuildDialog(titel)
            End If
        Else
            MetaScrapper.BackgroundComplete(m, sr)
        End If


    End Sub
End Class
Public Class Progress_BacksAuto
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Dim actMovie As String = ""
    Private Shared tdLoading As TaskDialog = Nothing
    Private Shared sendFeedbackProgressBar As TaskDialogProgressBar
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Bilder"

        l.Labelstring = "Suche Cover und Backdrops"
        l.IntroductionText = "Suche Cover und Backdrops"
        l.costumlabel = True
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()




    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of DownloadItem)

    Private Sub Worker_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Worker.Disposed
        l.Close()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                'actMovie = 
                'pushlist.Add("Lade..." & li(x).Titel)
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                'l.Push("Laden")

                Dim c As DownloadItem = TMDBImages.Automatisch(li(x), li(x).IMDB_ID)
                If Not c Is Nothing Then
                    result.Add(c)
                End If

                'l.Push("fertig")

            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged

        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For Each i In result
            DownloadManager.Add(i)
        Next
        If DownloadManager.isRunning = False Then
            DownloadManager.Run()
        End If
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
        result.Clear()

    End Sub
End Class
Public Class Progress_Darsteller
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Darsteller-Bilder"
        l.IntroductionText = "Suche nach Darstellern"
        l.Labelstring = "Suche nach Darstellern"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = 0
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim result As New List(Of DownloadItem)

    Private Sub Worker_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Worker.Disposed
        l.Close()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        Dim actors As New List(Of String)
        Dim pfad As String = Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName
        If IO.Directory.Exists(pfad) Then


            For x As Integer = 0 To li.Count - 1
                Dim sc() As String = TMDBImages.GetActorArray(li(x).Darsteller, li(x).Regisseur, li(x).Autoren)
                If sc.Length > 0 Then
                    For y As Integer = 0 To sc.Length - 1
                        If Not actors.Contains(sc(y)) Then
                            actors.Add(sc(y))
                        End If
                    Next
                End If
            Next
            l.Gesamtzahl = actors.Count
            Dim item As New DownloadItem
            item.Type = Downloaditemtype.Actors
            item.Titel = "Darsteller-Bilder"
            For x As Integer = 0 To actors.Count - 1
                If l.Cancel = False Then
                    l.Nächster()
                    l.Labelstring = actors(x)
                    'pushlist.Add("Lade..." & li(x).Titel)
                    Worker.ReportProgress(CInt(((x + 1) / actors.Count) * 100))

                    'l.Push("Laden")

                    Dim actor_pfad As String = IO.Path.Combine(pfad, Renamer.CheckInvalid_F(actors(x)))
                    'If IO.Directory.Exists(actor_pfad) = False Then
                    '    IO.Directory.CreateDirectory(actor_pfad)
                    'End If
                    Dim r As Boolean = True
                    If IO.File.Exists(IO.Path.Combine(actor_pfad, "folder.jpg")) Then
                        r = False
                    End If
                    If Not r = False Then
                        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                            If IO.File.Exists(actor_pfad & ".jpg") Then
                                r = False
                            End If
                        End If
                    End If



                    If Not r = False Then
                        Dim pi As WebFile = TMDBImages.GetActorImage(actors(x))
                        'If pi Is Nothing Then
                        '    pi = Actorimages.GetActorImage(actors(x))
                        'End If
                        If Not pi Is Nothing Then
                            item.List.Add(pi)
                        Else
                            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                                If IO.File.Exists(IO.Path.Combine(pfad, "Fehlt.png")) Then
                                    IO.File.Copy(IO.Path.Combine(pfad, "Fehlt.png"), actor_pfad & ".jpg")
                                End If
                            End If
                        End If
                        'IO.File.Delete(IO.Path.Combine(actor_pfad, "folder.jpg"))

                    End If


                    'l.Push("fertig")

                Else
                    Exit For
                End If

            Next
            If Not item.List.Count = 0 Then
                item.Status = DLState.Ready
                result.Add(item)
            End If
            'result.Add(item)

            'For x As Integer = 0 To li.Count - 1
            '    If l.Cancel = False Then
            '        l.Nächster()
            '        'pushlist.Add("Lade..." & li(x).Titel)
            '        Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

            '        'l.Push("Laden")

            '        Dim c As DownloadItem = TMDBImages.DarstellerBilder(li(x), li(x).IMDB_ID)
            '        If Not c Is Nothing Then
            '            result.Add(c)
            '        End If

            '        'l.Push("fertig")

            '    Else
            '        Exit For
            '    End If

            'Next

        End If

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For Each i In result
            DownloadManager.Add(i)
        Next
        If DownloadManager.isRunning = False Then
            DownloadManager.Run()
        End If
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
        result.Clear()

    End Sub
End Class
Public Class Progress_Quicksearch
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property ri As New List(Of Movie)
    Dim l As New Laden_Dialog
    Delegate Sub Save_Movie(ByVal m As Movie, ByVal s As Search_Result)
    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        'l.Worker = Worker
        l.Text = "Suche Film mit Hilfe von Google"
        l.IntroductionText = "Suche (Google)"
        l.Labelstring = "Suche"
        'l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'l.advGesamtzahl = 8
        'laden = l
        'l.Timecounter = False
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                Try
                    Dim s As Search_Result = MetaScrapper.Suche_Schnell_Progress(li(x), l, Worker, CInt(((x + 1) / li.Count) * 100))
                    If s Is Nothing Then
                        'Dim s2 As Search_Result = MetaScrapper.Suche_Progress(li(x), l, Worker, CInt(((x + 1) / li.Count) * 100))
                        'If s2 Is Nothing Then
                        ri.Add(li(x))
                        'Else

                        '    MetaScrapper.Complete_Progress(s2, l, Worker, CInt(((x + 1) / li.Count) * 100))
                        '    l.Invoke(New Save_Movie(AddressOf MetaScrapper.Save), New Object() {li(x), s2})
                        '    l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})
                        'End If
                    Else

                        MetaScrapper.Complete_Progress(s, l, Worker, CInt(((x + 1) / li.Count) * 100))
                        l.Invoke(New Save_Movie(AddressOf MetaScrapper.Save), New Object() {li(x), s})
                        l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Unbehandelter Fehler")
                End Try


            End If
        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()

        MetaScrapper.Suche(ri)
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Saver
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property mode As Savemode
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie), ByVal m As Savemode)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        Dim t As String = ""
        mode = m
        Select Case mode
            Case Is = Savemode.DVDInfo
                t = "in Windows Chache"
            Case Is = Savemode.Info
                t = "als Info.xml"
            Case Is = Savemode.mymovies
                t = "als mymovies.xml"
            Case Is = Savemode.nfo
                t = "als movie.nfo"
        End Select
        l.Text = "Speichern " & t
        l.Labelstring = "Speichern"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                li(x).SaveFile(mode)

                'Meta.SchnelleSuche(li(x))

                'l.Push("fertig")

            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Convert
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property mode As Savemode
    Property deleteold As Boolean
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie), ByVal m As Savemode)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        Dim t As String = ""
        mode = m
        Select Case mode
            Case Is = Savemode.DVDInfo
                t = "zu WindowsCache"
            Case Is = Savemode.Info
                t = "zu FilmePlugin"
            Case Is = Savemode.mymovies
                t = "zu Media Browser"
            Case Is = Savemode.nfo
                t = "zu XBMC"
        End Select
        l.Text = "Konvertiere " & t
        l.Labelstring = "Konvertiere"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                If mode = Savemode.neu Then
                    DeleteImages(li(x))
                Else
                    li(x).SaveFile(mode)
                    ConvertImages(mode, li(x), deleteold)
                End If


                'Meta.SchnelleSuche(li(x))

                'l.Push("fertig")

            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_LoadFolder_Serien
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    'Property li As List(Of Movie)
    Public Paths() As String
    Property mode As Savemode
    'Public MYmoviecoo As List(Of MovieCollection)
    Public MYsericoo As New List(Of SeriesCollection)
    Dim l As New Laden_Dialog
    Sub New(ByVal p() As String)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        Paths = p

        l.Text = "Ordner laden"
        l.Labelstring = "Ordner laden"
        l.aDetails = False
        l.aCancel = True
        l.Timecounter = False
        'l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Worker.Disposed
        'If MYmoviecoo.Count = 1 Then
        '    MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(0).Nodes(MainForm.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        'ElseIf MYmoviecoo.Count > 1 Then
        '    MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(0)
        '    'Main.TreeViewVista1_AfterSelect(Me, New TreeViewEventArgs(Main.TreeViewVista1.Nodes(0)))
        'End If
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Dim oTime As New System.Diagnostics.Stopwatch
        oTime.Start()

        If Paths.Length > 0 Then
            'MYmoviecoo = New List(Of MovieCollection)
            For y As Integer = 0 To Paths.Length - 1
                If IO.Directory.Exists(Paths(y)) Then
                    'l.Push(Paths(y))
                    Dim f As New System.IO.FileInfo(Paths(y))
                    If f.Attributes = FileAttributes.Hidden Or f.Attributes = FileAttributes.System Then
                    Else
                        LoadFolder(Paths(y))
                    End If
                End If
            Next
        End If
        oTime.Stop()
        'MsgBox((oTime.ElapsedMilliseconds / 1000) & " Sekunden")
    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted

        'Main.DataGridView1.Visible = False





        If MYsericoo.Count > 0 Then

            For x As Integer = 0 To MYsericoo.Count - 1

                For Each s In MYsericoo(x).Serien
                    Dim nNode As New TreeNode
                    nNode.Text = s.Titel
                    nNode.Tag = s
                    MainForm.treeNode_Serien.Nodes.Add(nNode)
                    MYsericoo(x).Node = MainForm.treeNode_Serien.Nodes(MainForm.treeNode_Serien.Nodes.Count - 1)
                    MainForm.treeNode_Serien.Expand()
                Next

                'Main.DataGridView1.Rows.AddRange(rc)




            Next
        End If
        'MainForm.DataGridView1.ClearSelection()


        'If Not Main.DataGridView1.SortedColumn Is Nothing Then
        '    If Main.DataGridView1.SortOrder = SortOrder.Ascending Then
        '        Main.DataGridView1.Sort(Main.DataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Ascending)
        '    Else
        '        Main.DataGridView1.Sort(Main.DataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Descending)
        '    End If
        'End If


        'Main.DataGridView1.Visible = True

        'MainForm.MoviesColl.AddRange(MYmoviecoo)
        'If Main.MoviesColl.Count > 0 Then
        '    For x As Integer = 0 To Main.MoviesColl.Count - 1

        '        If Main.MoviesColl(x).Movies.Count > 0 Then
        '            Dim rc(Main.MoviesColl.Item(x).Movies.Count - 1) As DataGridViewRow
        '            For y As Integer = 0 To Main.MoviesColl.Item(x).Movies.Count - 1
        '                Dim r As New DataGridViewRow
        '                r.Tag = Main.MoviesColl(x).Movies(y)
        '                r.CreateCells(Main.DataGridView1)
        '                'Main.DataGridView1.Rows.Add(r)
        '                'Main.DataGridView1.Refresh()
        '                Main.MoviesColl(x).Movies(y).Row = r
        '                Main.MoviesColl(x).Movies(y).Refresh()

        '                rc(y) = r
        '            Next
        '            Main.DataGridView1.Rows.AddRange(rc)
        '            Dim nNode As New TreeNode
        '            nNode.Text = IO.Path.GetFileName(Main.MoviesColl(x).Pfad)
        '            nNode.Tag = Main.MoviesColl(x)
        '            Main.TreeViewVista1.Nodes(0).Nodes.Add(nNode)
        '            Main.MoviesColl(x).Node = Main.TreeViewVista1.Nodes(0).Nodes(Main.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        '            Main.TreeViewVista1.Nodes(0).Expand()
        '            If MYmoviecoo.Count = 1 Then
        '                Main.TreeViewVista1.SelectedNode = Main.TreeViewVista1.Nodes(0).Nodes(Main.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        '            End If
        '        End If
        '    Next
        'End If


        'If MYsericoo.Count > 1 Then
        '    MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(0)
        'End If

        'Main.DataGridView1_SelectionChanged(Main.DataGridView1, New EventArgs)
        'Main.DataGridView1.Visible = True


        'If MsgBoxadv(Settings.ComboBox_new_XML, "Möchten Sie für den Film: """ & """ eine Standard Info.xml erstellen?", "XML Erstellen?") = True Then
        '    MsgBox("Ja")
        'Else
        '    MsgBox("Nein")
        'End If

        'Laden.Hide()
        'ToolStripProgressBar1.Visible = False
        'Main.DataGridView1.Visible = False

        'Main.Status_label.Text = "Fertig"
        'Settings.ComboBox_new_XML.SelectedIndex = CHV(0)
        'Settings.ComboBox_new_Dir.SelectedIndex = CHV(1)
        'Settings.ComboBox_Auto_mediainfo.SelectedIndex = CHV(2)
        'Settings.ComboBox_Auto_OFDB.SelectedIndex = CHV(3)
        'Main.DataGridView1.Visible = False
        'Main.Text = Main.Tag
        'Dim start As Integer = 0
        'If Main.DataGridView1.RowCount > 0 Then
        '    start = Main.DataGridView1.RowCount
        'End If

        'If Daten.arr.GetLength(1) > 0 Then

        '    For a As Integer = start To Daten.arr.GetLength(1) - 1

        '        'Laden.ProgressBar1.Value = (((a + 1) / Daten.arr.GetLength(1)) * 100)
        '        Main.DataGridView1.Rows.Add()
        '        'Me.Refresh()

        '        For b As Integer = 0 To 27
        '            'MsgBox(DataGridView1.Columns(b).Name.ToString.IndexOf("_") + 1)
        '            Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(b + 1).Value = Daten.arr(b, a)
        '        Next b
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(Main.Column_Titel.Index).Tag = Daten.arr(28, a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(Main.Column_Cover.Index).Value = img(a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(29).Value = If(Not Daten.arr(30, a) = "", Daten.arr(30, a) = "")
        '        'MsgBox(Daten.arr(31, a))
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(30).Value = Daten.arr(31, a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(31).Value = Daten.arr(37, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(20).Value = Daten.arr(22, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(21).Value = Daten.arr(23, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(22).Value = Daten.arr(24, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(23).Value = Daten.arr(25, a)
        '    Next a

        '    
        '    'DataGridView1_ColumnWidthChanged(DataGridView1, New EventArgs)

        'If Not IsNothing(newMovies) Then
        '    neueFilme()
        'End If

        'End If
        'Main.DataGridView1.Visible = True

        MainForm.SeriesColl.AddRange(MYsericoo)


        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
        'Dim rf As New RowFilter
        'MainForm.RowFilter.run(MainForm.actRows, MainForm.Filter_Dropdown_OPT.Text, MainForm.ToolStripTextBox1.Text)
        ''Main.Enabler(True)
        'If Main.WindowState = FormWindowState.Minimized Then
        '    Main.WindowState = FormWindowState.Normal
        'End If
        'Main.Anzahl.Text = Main.DataGridView1.RowCount & " Filme"
        'Main.DataGridView1.Visible = True
        'Main.Refresh()

    End Sub

    ''' <summary>
    ''' Lädt den Ordner in die standard ARRAY
    ''' </summary>
    ''' <param name="Pathstring">Pfad zum Ordner</param>
    ''' <remarks></remarks>
    Public Sub LoadFolder(ByVal Pathstring As String)
        Dim nColl As New SeriesCollection
        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
            Dim ser() As String = IO.Directory.GetFiles(Pathstring, "SerienBanner.jpg", SearchOption.AllDirectories)
            Array.Sort(ser)
            For Each d In ser
                'Serie:nSer
                Dim nSer As New Series
                'eigenschaften:
                Dim sTitel As String = IO.Path.GetFileName(d)
                nSer.Pfad = GetPathofFile(d)

                XMLModule.Load_Series_Info(nSer, Einstellungen.Config_MediaCenter.Default_local_Source)




                Dim sea() As String = IO.Directory.GetFiles(GetPathofFile(d), "StaffelBanner.jpg", SearchOption.AllDirectories)
                Array.Sort(sea)
                For Each e In sea
                    Dim nSea As New Season
                    nSea.Pfad = GetPathofFile(e)
                    nSea.Title = IO.Path.GetFileName(nSea.Pfad)
                    nSea.Num = Get_SeasonNumber(nSea.Title)
                    Dim epi() As String = IO.Directory.GetDirectories(nSea.Pfad, "Folge*", SearchOption.TopDirectoryOnly)
                    Array.Sort(epi)
                    For Each i In epi
                        Dim nEpi As New Episode
                        nEpi.Pfad = i
                        nEpi.Num = CStr(Get_SeasonNumber(IO.Path.GetFileName(i)))
                        XMLModule.Load_Episode_Info(nEpi, i, Einstellungen.Config_MediaCenter.Default_local_Source)
                        nSea.Episodes.Add(nEpi)
                    Next
                    nSer.Seasons.Add(nSea)
                Next
                nColl.Serien.Add(nSer)
            Next





        End If

        MYsericoo.Add(nColl)

    End Sub

    Private Function Get_SeasonNumber(ByVal e As String) As Integer
        Dim match As System.Text.RegularExpressions.Match = Regex.Match(e, "(\d{2})")

        'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
        If match.Success = True Then
            Return Einstellungen.toInt(match.Groups(1).Value)
        Else
            Return 0
        End If

    End Function

End Class
Public Class Progress_LoadFolder
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    'Property li As List(Of Movie)
    Public Paths() As String
    Property mode As Savemode
    Public MYmoviecoo As List(Of MovieCollection)
    Private newMovies As List(Of Movie)
    Dim l As New Laden_Dialog
    Private Function Sort(ByVal x As Fio_FileType, ByVal y _
As Fio_FileType) As Integer
        Dim c1 As Integer = x.Name.CompareTo(y.Name)
        If c1 <> 0 Then Return c1
        Return x.Name.CompareTo(y.Name)
    End Function
    Sub New(ByVal p() As String)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        Paths = p

        l.Text = "Ordner laden"
        l.IntroductionText = "Verzeichnis wird eingelesen"
        l.Labelstring = "Ordner laden"
        l.costumlabel = True
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = 0
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Worker.Disposed
        If MYmoviecoo.Count = 1 Then
            MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(0).Nodes(MainForm.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        ElseIf MYmoviecoo.Count > 1 Then
            MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(0)
            'Main.TreeViewVista1_AfterSelect(Me, New TreeViewEventArgs(Main.TreeViewVista1.Nodes(0)))
        End If
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Dim oTime As New System.Diagnostics.Stopwatch
        oTime.Start()
        If Paths.Length > 0 Then
            MYmoviecoo = New List(Of MovieCollection)
            For y As Integer = 0 To Paths.Length - 1
                If IO.Directory.Exists(Paths(y)) Then
                    'l.Push(Paths(y))
                    Dim f As New System.IO.FileInfo(Paths(y))
                    If f.Attributes = FileAttributes.Hidden Or f.Attributes = FileAttributes.System Then
                    Else
                        LoadFolder(Paths(y))
                    End If
                End If
            Next
        End If
        oTime.Stop()
        'MsgBox((oTime.ElapsedMilliseconds / 1000) & " Sekunden")
    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted

        'Main.DataGridView1.Visible = False
        If MYmoviecoo.Count > 0 Then
            For x As Integer = 0 To MYmoviecoo.Count - 1

                If MYmoviecoo(x).Movies.Count > 0 Then
                    Dim rc(MYmoviecoo(x).Movies.Count - 1) As DataGridViewRow
                    For y As Integer = 0 To MYmoviecoo(x).Movies.Count - 1
                        Dim r As New DataGridViewRow
                        r.Tag = MYmoviecoo(x).Movies(y)
                        r.CreateCells(ModMain.MainForm.Movie_GridView)
                        'Main.DataGridView1.Rows.Add(r)
                        'Main.DataGridView1.Refresh()
                        MYmoviecoo(x).Movies(y).Row = r
                        MYmoviecoo(x).Movies(y).Refresh()

                        rc(y) = r
                    Next
                    'Main.DataGridView1.Rows.AddRange(rc)
                    MainForm.actRows.AddRange(rc)

                    Dim nNode As New TreeNode
                    nNode.Text = IO.Path.GetFileName(MYmoviecoo(x).Pfad)
                    nNode.Tag = MYmoviecoo(x)
                    MainForm.TreeViewVista1.Nodes(0).Nodes.Add(nNode)
                    MYmoviecoo(x).Node = MainForm.TreeViewVista1.Nodes(0).Nodes(MainForm.TreeViewVista1.Nodes(0).Nodes.Count - 1)
                    MainForm.TreeViewVista1.Nodes(0).Expand()

                End If
            Next
        End If
        MainForm.Movie_GridView.ClearSelection()


        'If Not Main.DataGridView1.SortedColumn Is Nothing Then
        '    If Main.DataGridView1.SortOrder = SortOrder.Ascending Then
        '        Main.DataGridView1.Sort(Main.DataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Ascending)
        '    Else
        '        Main.DataGridView1.Sort(Main.DataGridView1.SortedColumn, System.ComponentModel.ListSortDirection.Descending)
        '    End If
        'End If


        'Main.DataGridView1.Visible = True

        MainForm.MoviesColl.AddRange(MYmoviecoo)
        'If Main.MoviesColl.Count > 0 Then
        '    For x As Integer = 0 To Main.MoviesColl.Count - 1

        '        If Main.MoviesColl(x).Movies.Count > 0 Then
        '            Dim rc(Main.MoviesColl.Item(x).Movies.Count - 1) As DataGridViewRow
        '            For y As Integer = 0 To Main.MoviesColl.Item(x).Movies.Count - 1
        '                Dim r As New DataGridViewRow
        '                r.Tag = Main.MoviesColl(x).Movies(y)
        '                r.CreateCells(Main.DataGridView1)
        '                'Main.DataGridView1.Rows.Add(r)
        '                'Main.DataGridView1.Refresh()
        '                Main.MoviesColl(x).Movies(y).Row = r
        '                Main.MoviesColl(x).Movies(y).Refresh()

        '                rc(y) = r
        '            Next
        '            Main.DataGridView1.Rows.AddRange(rc)
        '            Dim nNode As New TreeNode
        '            nNode.Text = IO.Path.GetFileName(Main.MoviesColl(x).Pfad)
        '            nNode.Tag = Main.MoviesColl(x)
        '            Main.TreeViewVista1.Nodes(0).Nodes.Add(nNode)
        '            Main.MoviesColl(x).Node = Main.TreeViewVista1.Nodes(0).Nodes(Main.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        '            Main.TreeViewVista1.Nodes(0).Expand()
        '            If MYmoviecoo.Count = 1 Then
        '                Main.TreeViewVista1.SelectedNode = Main.TreeViewVista1.Nodes(0).Nodes(Main.TreeViewVista1.Nodes(0).Nodes.Count - 1)
        '            End If
        '        End If
        '    Next
        'End If


        'If MYmoviecoo.Count > 1 Then
        '    Main.TreeViewVista1.SelectedNode = Main.TreeViewVista1.Nodes(0)
        'End If

        'Main.DataGridView1_SelectionChanged(Main.DataGridView1, New EventArgs)
        'Main.DataGridView1.Visible = True


        'If MsgBoxadv(Settings.ComboBox_new_XML, "Möchten Sie für den Film: """ & """ eine Standard Info.xml erstellen?", "XML Erstellen?") = True Then
        '    MsgBox("Ja")
        'Else
        '    MsgBox("Nein")
        'End If

        'Laden.Hide()
        'ToolStripProgressBar1.Visible = False
        'Main.DataGridView1.Visible = False

        'Main.Status_label.Text = "Fertig"
        'Settings.ComboBox_new_XML.SelectedIndex = CHV(0)
        'Settings.ComboBox_new_Dir.SelectedIndex = CHV(1)
        'Settings.ComboBox_Auto_mediainfo.SelectedIndex = CHV(2)
        'Settings.ComboBox_Auto_OFDB.SelectedIndex = CHV(3)
        'Main.DataGridView1.Visible = False
        'Main.Text = Main.Tag
        'Dim start As Integer = 0
        'If Main.DataGridView1.RowCount > 0 Then
        '    start = Main.DataGridView1.RowCount
        'End If

        'If Daten.arr.GetLength(1) > 0 Then

        '    For a As Integer = start To Daten.arr.GetLength(1) - 1

        '        'Laden.ProgressBar1.Value = (((a + 1) / Daten.arr.GetLength(1)) * 100)
        '        Main.DataGridView1.Rows.Add()
        '        'Me.Refresh()

        '        For b As Integer = 0 To 27
        '            'MsgBox(DataGridView1.Columns(b).Name.ToString.IndexOf("_") + 1)
        '            Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(b + 1).Value = Daten.arr(b, a)
        '        Next b
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(Main.Column_Titel.Index).Tag = Daten.arr(28, a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(Main.Column_Cover.Index).Value = img(a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(29).Value = If(Not Daten.arr(30, a) = "", Daten.arr(30, a) = "")
        '        'MsgBox(Daten.arr(31, a))
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(30).Value = Daten.arr(31, a)
        '        Main.DataGridView1.Rows(Main.DataGridView1.Rows.Count - 1).Cells(31).Value = Daten.arr(37, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(20).Value = Daten.arr(22, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(21).Value = Daten.arr(23, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(22).Value = Daten.arr(24, a)
        '        'DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(23).Value = Daten.arr(25, a)
        '    Next a

        '    
        '    'DataGridView1_ColumnWidthChanged(DataGridView1, New EventArgs)

        If Not IsNothing(newMovies) Then
            neueFilme()
        End If

        'End If
        'Main.DataGridView1.Visible = True
        'Laden.Hide()
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
        'Dim rf As New RowFilter
        MainForm.RowFilter.run(MainForm.actRows, MainForm.Filter_Dropdown_OPT.Text, MainForm.ToolStripTextBox1.Text)
        ''Main.Enabler(True)
        'If Main.WindowState = FormWindowState.Minimized Then
        '    Main.WindowState = FormWindowState.Normal
        'End If
        'Main.Anzahl.Text = Main.DataGridView1.RowCount & " Filme"
        'Main.DataGridView1.Visible = True
        'Main.Refresh()
    End Sub

    ''' <summary>
    ''' Lädt den Ordner in die standard ARRAY
    ''' </summary>
    ''' <param name="Pathstring">Pfad zum Ordner</param>
    ''' <remarks></remarks>
    Public Sub LoadFolder(ByVal Pathstring As String)
        'Erstmal gucken ob so viedeos im ordner sind :
        '------------------
        'Array mit Videos erstellen
        'Dim a As List(Of String)
        'Try
        '    a.Add("lol")
        'Catch ex As Exception : Exeption.Fehler(ex)

        'End Try

        If Einstellungen.Config_Laden.Laden_Ordner_neuerOrdner = True Then
            Dim moviesinpath() As String = Get_Moviepaths_in_array(Pathstring)
            If moviesinpath.Length >= 1 And Not moviesinpath(0) = "" Then
                Dim Movedialog As New Dialog_MovetoNewFolder
                'Movedialog.Owner = Main
                For mv As Integer = 0 To moviesinpath.Length - 1
                    If Not Directory.Exists(Path.Combine(Path.GetDirectoryName(moviesinpath(mv)), Path.GetFileNameWithoutExtension(moviesinpath(mv)))) Then

                        Dim n As New TreeNode
                        n.Text = Path.GetFileNameWithoutExtension(moviesinpath(mv))
                        n.Tag = moviesinpath(mv)
                        Movedialog.TreeViewVista1.Nodes.Add(n)
                    End If
nextmv:
                Next

                If Movedialog.TreeViewVista1.Nodes.Count > 0 Then


                    Movedialog.TopMost = True
                    Movedialog.TopLevel = True
                    If Movedialog.ShowDialog = DialogResult.OK Then

                        For mv As Integer = 0 To Movedialog.TreeViewVista1.Nodes.Count - 1
                            If Movedialog.TreeViewVista1.Nodes(mv).Checked = True Then



                                Try
                                    Dim s As String = CStr(Movedialog.TreeViewVista1.Nodes(mv).Tag)
                                    MkDir(Path.Combine(Path.GetDirectoryName(s), Path.GetFileNameWithoutExtension(s)))
                                    File.Move(s, Path.Combine(Path.GetDirectoryName(s), Path.GetFileNameWithoutExtension(s)) & "\" & Path.GetFileName(s))
                                Catch ex As Exception
                                    MsgBox("Es ist folgender Fehler aufgetreten: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation, "Unbekannter Fehler")
                                End Try
                            End If
                        Next
                    End If
                    'Main.Enabled = True

                End If

            End If
        End If





        Dim sta As List(Of Fio_FileType) = Get_Moviepaths_in_array_depht(Pathstring)
        sta.Sort(AddressOf Sort)

        'Abbrechen boolean = False setzten

        l.Gesamtzahl = sta.Count
        l.Aktuell = 0

        'ob bereits filme hinzugefügt wurden
        'Dim i As Integer = Main.DataGridView1.RowCount - 1

        'für jeden ordner im verzeichnis


        If sta.Count > 0 Then
            Dim nColl As New MovieCollection
            nColl.Pfad = Pathstring
            newMovies = New List(Of Movie)
            Dim fn As String = IO.Path.GetFileName(Pathstring)
            MYmoviecoo.Add(nColl)
            For x As Integer = 0 To sta.Count - 1
                'ob abgebrochen wurde?
                If l.Cancel = False Then
                    l.Labelstring = IO.Path.GetFileName(sta(x).Name)
                    l.Nächster()
                    'l.Aktuell = x + 1
                    'akt_var = x

                    'BGW.ReportProgress(CInt(((x + 1) / (sta.Length)) * 100))
                    'künstliche verzögerung
                    'If sta.Length > 50 Then
                    '    'Threading.Thread.Sleep(50)
                    'End If
                    Dim Folderpath As String = sta(x).Name
                    'auf xml prüfen
                    'Dim xmlfile As String = "info.xml"

                    'If Einstellungen.mcplugin = 1 Then
                    'xmlfile = "mymovies.xml"
                    'End If
                    Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                    Dim m As New Movie
                    m.Favname = fn
                    m.Favpath = Pathstring
                    nColl.Movies.Add(m)
                    If XMLModule.Exist(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source) Then

                        XMLModule.Load(m, Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source)
                        m.Check_Artikel_Genre()
                    Else
                        If XMLModule.Exist(Folderpath, Savemode.Info) Then
                            XMLModule.Load(m, Folderpath, Savemode.Info)
                            m.Check_Artikel_Genre()
                        ElseIf XMLModule.Exist(Folderpath, Savemode.mymovies) Then
                            XMLModule.Load(m, Folderpath, Savemode.mymovies)

                            m.Check_Artikel_Genre()
                        ElseIf XMLModule.Exist(Folderpath, Savemode.nfo) Then

                            XMLModule.Load(m, Folderpath, Savemode.nfo)

                            m.Check_Artikel_Genre()
                        ElseIf XMLModule.Exist(Folderpath, Savemode.DVDInfo) Then

                            XMLModule.Load(m, Folderpath, Savemode.DVDInfo)

                            m.Check_Artikel_Genre()
                        ElseIf XMLModule.Exist(Folderpath, Savemode.oldmymovies) Then

                            XMLModule.Load(m, Folderpath, Savemode.oldmymovies)

                            m.Check_Artikel_Genre()

                        Else

                            newMovies.Add(m)
                            XMLModule.Load(m, Folderpath, Savemode.neu)
                            If Einstellungen.Config_Laden.Laden_Ordner_MediaInfo = True Then
                                'If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
                                Try
                                    Dim prov As New MediaInfoProvider
                                    prov.Get_Info(m)
                                Catch ex As Exception

                                End Try

                                'End If
                            End If
                            m.SaveFile()
                        End If
                    End If


                End If
            Next



        End If



        'End If

    End Sub


    Private Sub neueFilme()

        If newMovies.Count > 0 Then

            If Einstellungen.Config_Laden.Laden_Ordner_Suche = True Then
                If Einstellungen.Config_Laden.Laden_Ordner_suchmodus = 0 Then
                    Dim s As New Progress_Quicksearch(newMovies)
                    s.Run()

                    'Laden.Hide()
                    Exit Sub
                ElseIf Einstellungen.Config_Laden.Laden_Ordner_suchmodus = 1 Then

                    Dim s As New Progress_Search(newMovies)
                    s.Run()

                    'Laden.Hide()
                    Exit Sub
                ElseIf Einstellungen.Config_Laden.Laden_Ordner_suchmodus = 2 Then
                    MetaScrapper.Suche(newMovies)
                Else

                End If
            End If

        End If
    End Sub
End Class
Public Class Progress_LoadFavFolder
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    'Property li As List(Of Movie)
    Public Paths() As String
    Public MYmoviecoo As List(Of MovieCollection)
    Private newMovies As List(Of Movie)
    'Dim l As New Laden_Dialog
    Dim ln As New TreeNode
    Private Function Sort(ByVal x As Fio_FileType, ByVal y _
As Fio_FileType) As Integer
        Dim c1 As Integer = x.Name.CompareTo(y.Name)
        If c1 <> 0 Then Return c1
        Return x.Name.CompareTo(y.Name)
    End Function
    Sub New(ByVal p() As String)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        Paths = p

        ln.Text = "Lädt..."
        ln.ImageIndex = 6
        MainForm.TreeViewVista1.Nodes(1).Nodes.Add(ln)
        MainForm.TreeViewVista1.Nodes(1).Expand()
        MainForm.Refresh()
        'l.Text = "Favoriten laden"
        'l.Labelstring = "Favoriten laden"
        'l.aDetails = True
        'l.aCancel = True
        'l.Timecounter = False
        ''l.Gesamtzahl = li.Count
        ''laden = l
        'l.Refresh()
        'l.Show()
        'l.TopMost = True
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        If Paths.Length > 0 Then
            MYmoviecoo = New List(Of MovieCollection)
            For y As Integer = 0 To Paths.Length - 1
                If IO.Directory.Exists(Paths(y)) Then
                    'l.Push(Paths(y))
                    Dim f As New System.IO.FileInfo(Paths(y))
                    If f.Attributes = FileAttributes.Hidden Or f.Attributes = FileAttributes.System Then
                    Else
                        LoadFolder(Paths(y))
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        'l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted

        'Main.DataGridView1.Visible = False
        ln.Remove()
        If MYmoviecoo.Count > 0 Then
            For x As Integer = 0 To MYmoviecoo.Count - 1
                If MYmoviecoo(x).Movies.Count > 0 Then
                    For y As Integer = 0 To MYmoviecoo(x).Movies.Count - 1
                        Dim r As New DataGridViewRow
                        r.Tag = MYmoviecoo(x).Movies(y)
                        r.CreateCells(MainForm.Movie_GridView)
                        'Main.DataGridView1.Rows.Add(r)
                        'Main.DataGridView1.Refresh()
                        MYmoviecoo(x).Movies(y).Row = r
                        MYmoviecoo(x).Movies(y).Refresh()
                    Next
                    Dim nNode As New TreeNode
                    nNode.Text = IO.Path.GetFileName(MYmoviecoo(x).Pfad)
                    nNode.Tag = MYmoviecoo(x)
                    MainForm.TreeViewVista1.Nodes(1).Nodes.Add(nNode)
                    MYmoviecoo(x).Node = MainForm.TreeViewVista1.Nodes(1).Nodes(MainForm.TreeViewVista1.Nodes(1).Nodes.Count - 1)
                    MainForm.TreeViewVista1.Nodes(1).Expand()
                    If MYmoviecoo.Count = 1 Then
                        MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(1).Nodes(MainForm.TreeViewVista1.Nodes(1).Nodes.Count - 1)
                    End If
                End If
            Next
        End If


        If MYmoviecoo.Count > 1 Then
            MainForm.TreeViewVista1.SelectedNode = MainForm.TreeViewVista1.Nodes(1)
            MainForm.TreeViewVista1_AfterSelect(Me, New TreeViewEventArgs(MainForm.TreeViewVista1.Nodes(1)))
        End If

        MainForm.Movie_GridView.Visible = True
        MainForm.FavMoviesColl.AddRange(MYmoviecoo)


        If Not IsNothing(newMovies) Then
            neueFilme()
        End If


        Worker.Dispose()

    End Sub

    ''' <summary>
    ''' Lädt den Ordner in die standard ARRAY
    ''' </summary>
    ''' <param name="Pathstring">Pfad zum Ordner</param>
    ''' <remarks></remarks>
    Public Sub LoadFolder(ByVal Pathstring As String)
        'Erstmal gucken ob so viedeos im ordner sind :
        '------------------
        'Array mit Videos erstellen



        Dim sta As List(Of Fio_FileType) = Get_Moviepaths_in_array_depht(Pathstring)
        sta.Sort(AddressOf Sort)
        'Abbrechen boolean = False setzten

        'l.Gesamtzahl = sta.Length
        'l.Aktuell = 0

        'ob bereits filme hinzugefügt wurden
        'Dim i As Integer = Main.DataGridView1.RowCount - 1

        'für jeden ordner im verzeichnis


        If sta.Count > 0 Then
            Dim nColl As New MovieCollection
            nColl.Pfad = Pathstring
            newMovies = New List(Of Movie)
            Dim fn As String = IO.Path.GetFileName(Pathstring)
            MYmoviecoo.Add(nColl)
            For x As Integer = 0 To sta.Count - 1
                'ob abgebrochen wurde?
                'If l.Cancel = False Then
                '    l.Nächster()
                'l.Aktuell = x + 1
                'akt_var = x

                'BGW.ReportProgress(CInt(((x + 1) / (sta.Length)) * 100))
                'künstliche verzögerung
                'If sta.Length > 50 Then
                '    'Threading.Thread.Sleep(50)
                'End If
                Dim Folderpath As String = sta(x).Name
                'auf xml prüfen
                'Dim xmlfile As String = "info.xml"

                'If Einstellungen.mcplugin = 1 Then
                'xmlfile = "mymovies.xml"
                'End If

                If XMLModule.Exist(Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source) Then
                    Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                    Dim m As New Movie
                    m.Favname = fn
                    m.Favpath = Pathstring
                    nColl.Movies.Add(m)
                    XMLModule.Load(m, Folderpath, Einstellungen.Config_MediaCenter.Default_local_Source)

                    m.Check_Artikel_Genre()
                Else
                    If XMLModule.Exist(Folderpath, Savemode.Info) Then
                        Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                        Dim m As New Movie
                        m.Favname = fn
                        m.Favpath = Pathstring
                        nColl.Movies.Add(m)
                        XMLModule.Load(m, Folderpath, Savemode.Info)

                        m.Check_Artikel_Genre()
                    ElseIf XMLModule.Exist(Folderpath, Savemode.mymovies) Then
                        Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                        Dim m As New Movie
                        m.Favname = fn
                        m.Favpath = Pathstring
                        nColl.Movies.Add(m)
                        XMLModule.Load(m, Folderpath, Savemode.mymovies)

                        m.Check_Artikel_Genre()
                    ElseIf XMLModule.Exist(Folderpath, Savemode.nfo) Then

                        Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                        Dim m As New Movie
                        m.Favname = fn
                        m.Favpath = Pathstring
                        nColl.Movies.Add(m)
                        XMLModule.Load(m, Folderpath, Savemode.nfo)

                        m.Check_Artikel_Genre()
                    ElseIf XMLModule.Exist(Folderpath, Savemode.DVDInfo) Then

                        Dim m As New Movie
                        m.Favname = fn
                        m.Favpath = Pathstring
                        nColl.Movies.Add(m)
                        XMLModule.Load(m, Folderpath, Savemode.DVDInfo)

                        m.Check_Artikel_Genre()
                    Else
                        Worker.ReportProgress(CInt(((x + 1) / (sta.Count)) * 100))
                        Dim m As New Movie
                        m.Favname = fn
                        m.Favpath = Pathstring
                        nColl.Movies.Add(m)
                        newMovies.Add(m)
                        XMLModule.Load(m, Folderpath, Savemode.neu)
                        If Einstellungen.Config_Laden.Laden_Favs_MediaInfo = True Then
                            If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
                                Dim prov As New MediaInfoProvider
                                prov.Get_Info(m)
                            End If
                        End If
                        m.SaveFile()
                    End If
                End If


                'End If
            Next



        End If



        'End If

    End Sub


    Private Sub neueFilme()

        If newMovies.Count > 0 Then

            If Einstellungen.Config_Laden.Laden_Favs_Suche = True Then
                If Einstellungen.Config_Laden.Laden_Favs_Suchmodus = 0 Then
                    Dim s As New Progress_Quicksearch(newMovies)
                    s.Run()

                    'Laden.Hide()
                    Exit Sub
                ElseIf Einstellungen.Config_Laden.Laden_Favs_Suchmodus = 1 Then

                    Dim s As New Progress_Search(newMovies)
                    s.Run()

                    'Laden.Hide()
                    Exit Sub
                ElseIf Einstellungen.Config_Laden.Laden_Favs_Suchmodus = 2 Then
                    MetaScrapper.Suche(newMovies)
                Else

                End If
            End If

        End If
    End Sub
End Class



Public Class Progress_MovieMazeTrailer
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    'Property li As List(Of Movie)
    'Dim l As New Laden_Dialog

    Property mi As Movie
    Property hptext As String = ""

    Property myur As String
    Dim res As New List(Of DownloadItem)
    Dim tr As TrailerLoader



    Sub New(ByVal url As String)
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True

        myur = url


    End Sub
    Public Sub Run()

        Worker.RunWorkerAsync()


    End Sub


    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork

        'If li.Count = 1 Then
        '    If li(0).File_Trailer = "" Then
        '        If Not hptext = "" Then
        '            GoTo frombrowser
        '        End If
        '        If li(0).TrailerURL = "" Then
        '            Dim s As New Search_Result
        '            Dim t As New TMDB_Scrapper
        '            s.IMDB_ID = id
        '            t.fromIMDB(s)
        '            li(0).TrailerURL = s.trailer
        '        End If

        'If Not li(0).TrailerURL = "" Then


        tr = New TrailerLoader(myur)
    
   

    End Sub



    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        Dim d As New Dialog_Trailer
        d.TrailerLoad(tr)
        d.Show()

        d.mvo = mi


        Worker.Dispose()
    End Sub
End Class





Public Class Progress_Trailer
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Property id As String = ""

    Property hptext As String = ""

    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Dim notFound As New List(Of Movie)
    Dim res As New List(Of DownloadItem)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True

        li = lm
        If li.Count = 1 Then
            MainForm.exp_Download.Image = Toolbar16.loadingani2
            MainForm.Cover_Tool.Image = Toolbar16.loadingani2
        Else
            l.Text = "Trailer abrufen"
            l.Labelstring = "Rufe Trailer ab"
            l.aDetails = False
            l.aCancel = True
            l.Gesamtzahl = li.Count
            l.Refresh()
            l.Show()
        End If




    End Sub
    Public Sub Run()

        Worker.RunWorkerAsync()


    End Sub


    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        If li.Count = 1 Then
            ''EIN Film:
            'moviemaze


            If li(0).TrailerURL = "" Then
                Dim s As New Search_Result
                Dim t As New TMDB_Scrapper
                s.IMDB_ID = li(0).IMDB_ID
                t.fromIMDB(s)
                li(0).TrailerURL = s.trailer
            End If
            If Not li(0).TrailerURL = "" Then
                Dim item As New DownloadItem
                item.Type = Downloaditemtype.Trailer
                item.DestMovie = li(0)

                Dim man As New TrailerLoader(li(0).TrailerURL)
                Dim ur As String = ""
                For Each fe In man.Result
                    For Each d In fe.Files
                        If d.Quality = TrailerLoader.TrailerQuality.HD1080 Then
                            ur = d.URL
                            GoTo ex2
                        ElseIf d.Quality = TrailerLoader.TrailerQuality.HD720 Then
                            ur = d.URL
                        ElseIf d.Quality = TrailerLoader.TrailerQuality.SD360 Then
                            If ur = "" Then
                                ur = d.URL
                            End If
                        End If
                    Next
                Next

ex2:
                If Not ur = "" Then
                    Dim ts As New WebFile
                    ts.Source = New Uri(ur)
                    If ts.Get_Filesize = True Then
                        ts.Destination = WebFunctions.Get_TrailerDes(ts, False)
                        item.List.Add(ts)
                    End If
                End If
                If Not item.List.Count = 0 Then
                    item.Status = DLState.Ready
                    res.Add(item)
                End If
            End If

        Else
        ''Mehrere Filme:
        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                Try

                    If li(x).File_Trailer = "" Then
                        If li(x).TrailerURL = "" Then
                            Dim s As New Search_Result
                            Dim t As New TMDB_Scrapper
                            s.IMDB_ID = li(x).IMDB_ID
                            t.fromIMDB(s)
                            li(x).TrailerURL = s.trailer
                        End If
                        If Not li(x).TrailerURL = "" Then
                            Dim item As New DownloadItem
                            item.Type = Downloaditemtype.Trailer
                            item.DestMovie = li(x)

                            Dim man As New TrailerLoader(li(x).TrailerURL)
                            Dim ur As String = ""
                            For Each fe In man.Result
                                For Each d In fe.Files
                                    If d.Quality = TrailerLoader.TrailerQuality.HD1080 Then
                                        ur = d.URL
                                        GoTo ex
                                    ElseIf d.Quality = TrailerLoader.TrailerQuality.HD720 Then
                                        ur = d.URL
                                    ElseIf d.Quality = TrailerLoader.TrailerQuality.SD360 Then
                                        If ur = "" Then
                                            ur = d.URL
                                        End If
                                    End If
                                Next
                            Next

ex:
                            If Not ur = "" Then
                                Dim ts As New WebFile
                                ts.Source = New Uri(ur)
                                If ts.Get_Filesize = True Then
                                    ts.Destination = WebFunctions.Get_TrailerDes(ts, False)
                                    item.List.Add(ts)
                                End If
                            End If
                            If Not item.List.Count = 0 Then
                                item.Status = DLState.Ready
                                res.Add(item)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Exit For
            End If
        Next
            End If

Finish:


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If li.Count = 1 Then
            If res.Count > 0 Then
                With MainForm
                    .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                    .MyToolTip.ToolTipTitle = "Trailer gefunden"
                    .MyToolTip.Show("Treiler wird geladen", MainForm, 20, 40, 2000)
                End With
                DownloadManager.Add(res(0))
                If Not DownloadManager.isRunning Then
                    DownloadManager.Run()
                End If
            Else
                With MainForm
                    .MyToolTip.ToolTipIcon = ToolTipIcon.Warning
                    .MyToolTip.ToolTipTitle = "Kein Trailer gefunden"
                    .MyToolTip.Show("Es konnte kein Trailer gefunden werden.", MainForm, 20, 40, 2000)
                End With
            End If
            If Einstellungen.UserAbrufen.Download_Mode = OnlineSearchmode.Normal Then
                MainForm.exp_Download.Image = Toolbar16.View_extragroß
                MainForm.Cover_Tool.Image = Toolbar16.View_extragroß
            Else
                MainForm.exp_Download.Image = Toolbar16.Fanart_search_fast
                MainForm.Cover_Tool.Image = Toolbar16.Fanart_search_fast
            End If

        Else
            For Each s In res
                DownloadManager.Add(s)
            Next
            If Not DownloadManager.isRunning Then
                DownloadManager.Run()
            End If
            l.closallowed = True
            l.Close()
            l.Dispose()
        End If

        Worker.Dispose()
    End Sub
End Class
Public Class Progress_MediaInfo
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Dim prov As New MediaInfoProvider
    Dim ffprov As New FFProbe
    Dim able As Boolean = True
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True

        Try
            Dim mi As New MediaInfo

            Dim To_Display As String = mi.Option_("Info_Version", "0.7.0.0")
            mi.Close()
            If (To_Display.Length() = 0) Then
                MsgBox("Diese Version von MediaInfo wird nicht unterstüzt" & vbCrLf & "Bitte prüfen Sie die Einstellungen (Optionen->MediaInfo)")
                able = False
                Exit Sub
            End If
        Catch ex As Exception
            If ex.Message = "Es wurde versucht, eine Datei mit einem falschen Format zu laden. (Ausnahme von HRESULT: 0x8007000B)" Then
                MsgBox("Diese Version von MediaInfo wird nicht unterstüzt" & vbCrLf & "Bitte prüfen Sie die Einstellungen (Optionen->MediaInfo)")
                able = False
                Exit Sub
            Else
                MsgBox("Es wurde keine Version der MediaInfo-Lib gefunden" & vbCrLf & "Bitte prüfen Sie die Einstellungen (Optionen->MediaInfo)")
                able = False
                Exit Sub
            End If
        End Try
        li = lm
        If li.Count = 1 Then
            MainForm.MediaInfo_tool.Image = Toolbar16.loadingani2
            MainForm.Exp_MediaInfo.Image = Toolbar16.loadingani2
        Else
            l.Text = "MediaInfo abrufen"
            l.Labelstring = "Rufe MediaInfo ab"
            l.aDetails = False
            l.aCancel = True
            l.Gesamtzahl = li.Count
            l.Refresh()
            l.Show()
        End If




    End Sub
    Public Sub Run()
        If able = True Then
            Worker.RunWorkerAsync()
        Else

            l.closallowed = True
            l.Close()
            l.Dispose()


            Worker.Dispose()
        End If

    End Sub

    Dim pushlist As New List(Of String)

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        If li.Count = 1 Then
            If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                ffprov.Inform(li(0), True)
            Else
                prov.Inform(li(0), True)
            End If


        Else
            For x As Integer = 0 To li.Count - 1
                If l.Cancel = False Then
                    l.Nächster()
                    l.Labelstring = li(x).Titel
                    Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                    Try

                        If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                            ffprov.Inform(li(x))
                        Else
                            prov.Inform(li(x))
                        End If


                        li(x).SaveFile()
                        l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Else
                    Exit For
                End If
            Next
        End If




    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If li.Count = 1 Then
            If MainForm.SelectedMovie Is li(0) Then
                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                    ffprov.WritetoPanel()
                Else
                    prov.WritetoPanel()
                End If
                MainForm.InfoPanel_Movie1.InfoTabs3.SelectTab(2)
            Else
                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                    prov.WritetoMovie(li(0))
                Else
                    prov.WritetoMovie(li(0))
                End If

                li(0).SaveFile()
                li(0).Refresh()
            End If
            MainForm.MediaInfo_tool.Image = Toolbar16.mediainfoicon161
            MainForm.Exp_MediaInfo.Image = Toolbar16.mediainfoicon161
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Erfolgreich"
                .MyToolTip.Show("Die Informationen zur Filmdateie wurden abgerufen.", MainForm, 20, 40, 2000)
            End With
        Else
            l.closallowed = True
            l.Close()
            l.Dispose()
        End If

        Worker.Dispose()
    End Sub
End Class
Public Class Progress_AviMuxCombineMovies
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm



    End Sub
    Public Sub Run()

        Worker.RunWorkerAsync()

    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork



        For x As Integer = 0 To li.Count - 1
            If li(x).Files.Length > 1 Then
                If li(x).Files(0).EndsWith(".avi") And li(x).Files(1).EndsWith(".avi") Then


                    Dim txt As String = ""
                    txt &= "CLEAR" & vbCrLf
                    txt &= "LOAD " & li(x).Files(0) & vbCrLf
                    txt &= "LOAD " & li(x).Files(1) & vbCrLf
                    txt &= "SELECT FILE 0" & vbCrLf
                    txt &= "ADD VIDEOSOURCE" & vbCrLf
                    txt &= "START " & li(x).Pfad & "\completed.avi"
                    Dim tmp As String = Einstellungen.ChachePath & "\" & IO.Path.GetRandomFileName & ".txt"

                    My.Computer.FileSystem.WriteAllText(tmp, txt, False)
                    Dim sheet As New Process
                    sheet.StartInfo.FileName = MyFunctions.shortpath(Einstellungen.Config_Avimux.Avimux_pfad)

                    'D:\Downloads\mtn-200808a-win32\mtn-200808a-win32\mtn.exe -s 65 -c 1 -r 1 -i -t "D:\123.avi"
                    'sheet.StartInfo.Arguments = "-c 1 -r 1 -w 0 -i -t " + shortpath(path)

                    'MsgBox(dpath)
                    'MsgBox(shortpath(path))
                    sheet.StartInfo.Arguments = " " & MyFunctions.shortpath(tmp)
                    'Process.Start(dpath)
                    sheet.StartInfo.UseShellExecute = False
                    sheet.StartInfo.WindowStyle = ProcessWindowStyle.Minimized

                    sheet.StartInfo.RedirectStandardOutput = False

                    sheet.StartInfo.CreateNoWindow = True

                    sheet.Start()

                End If
            End If
        Next
        'End If



    End Sub



    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted

        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Backup_Delet
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog


    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Sicherung löschen"
        l.Labelstring = "Sicherung löschen"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l

        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                'pushlist.Add("Lade..." & li(x).Titel)
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                Try

                    XMLModule.Backup_Delet(li(x).Pfad)


                Catch ex As Exception
                    MsgBox("Fehler" & vbCrLf & ex.Message)
                End Try
            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Backup_Save
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog

    Property replace As Boolean = True

    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Sicherung erstellen"
        l.Labelstring = "Sicherung speichern"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l

        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                'pushlist.Add("Lade..." & li(x).Titel)
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                'Threading.Thread.Sleep(200)
                'Renamer.ChangeFolderName(li(x))
                'Renamer.ChangeFileName(li(x))
                'Dim s As String = "Fertig..." & li(x).Titel
                'l.Push(LoggerWriteLiType.Fehler, li(x).Titel, "Media Info", "Lädt")
                Try
                    If replace = False Then
                        If Not XMLModule.Backup_Exists(li(x).Pfad, Einstellungen.Config_MediaCenter.Default_local_Source) Then
                            XMLModule.Backup_Save(li(x))
                        End If
                    Else
                        XMLModule.Backup_Save(li(x))
                    End If



                    'li(x).SaveFile()
                    'l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})

                Catch ex As Exception
                    MsgBox("Fehler" & vbCrLf & ex.Message)
                End Try
            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Backup_Load
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Dim l As New Laden_Dialog
    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        l.Text = "Sicherung wiederherstellen"
        l.Labelstring = "Sicherung laden"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l

        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog

        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                'pushlist.Add("Lade..." & li(x).Titel)
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                'Threading.Thread.Sleep(200)
                'Renamer.ChangeFolderName(li(x))
                'Renamer.ChangeFileName(li(x))
                'Dim s As String = "Fertig..." & li(x).Titel
                'l.Push(LoggerWriteLiType.Fehler, li(x).Titel, "Media Info", "Lädt")
                Try

                    XMLModule.Backup_Load(li(x))

                    li(x).SaveFile()
                    l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})

                Catch ex As Exception
                    MsgBox("Fehler" & vbCrLf & ex.Message)
                End Try
            Else
                Exit For
            End If

        Next


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_GenreListDownload
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property po1 As String
    Property po2 As String
    Property forDialog As Boolean
    Dim l As New Laden_Dialog

    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Public Shared gList As New List(Of Einstellungen.gFilter)
    Private Sub getGenres()
        Dim i, j As Integer    ' Hilfsvariablen
        Dim xml As Xml.XmlDocument
        Dim xpath As String
        Dim xmln As XmlNode
        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Genres.getList/" & "de" & "/xml/5fe800e9f7891b9131c0059be62a36d0", "")

        If IsNothing(xml) Then
            Exit Sub
        End If
        'xml.Save("D:\test.xml")


        xpath = "//genre"
        ' Container für unseren aktiven Knoten

        ' Für den Fall das wir mehrere Knoten haben auf die unser 
        ' XPath zutrifft
        j = xml.SelectNodes(xpath).Count
        If j > 0 Then
            For i = 0 To j - 1 Step 1
                If l.Cancel = True Then
                    Exit Sub
                End If
                xmln = xml.SelectNodes(xpath).Item(i)
                Dim r As New Einstellungen.gFilter
                'r.CreateCells(DataGridView1)
                r.Name_DE = xmln.Attributes(0).Value
                'r.Filter = xmln.Attributes(0).Value
                r.id = xmln.ChildNodes(0).InnerText
                gList.Add(r)
            Next i

        End If


    End Sub
    Private Sub addGenres()
        Dim i, j As Integer    ' Hilfsvariablen
        Dim xml As Xml.XmlDocument
        Dim xpath As String
        Dim xmln As XmlNode
        xml = MyFunctions.HttploadXML(Einstellungen.UserAbrufen.tmdbapiroot & "Genres.getList/" & "en" & "/xml/5fe800e9f7891b9131c0059be62a36d0", "")
        If IsNothing(xml) Then
            Exit Sub
        End If
        xpath = "//genre"

        ' Für den Fall das wir mehrere Knoten haben auf die unser 
        ' XPath zutrifft
        j = xml.SelectNodes(xpath).Count
        If j > 0 Then
            For i = 0 To j - 1 Step 1
                If l.Cancel = True Then
                    Exit Sub
                End If
                Dim id As String = ""
                xmln = xml.SelectNodes(xpath).Item(i)
                id = xmln.ChildNodes(0).InnerText
                For Each gf In gList
                    If gf.id = id Then

                        gf.Name_EN = xmln.Attributes(0).Value
                    End If
nexxt:
                Next


                'r.CreateCells(DataGridView1)
                'r.Cells(0).Value = xmln.Attributes(0).Value
                'r.Cells(2).Value = xmln.Attributes(0).Value
                'r.Cells(1).Value = xmln.ChildNodes(0).InnerText

                'DataGridView1.Rows.Add(r)
            Next i

        End If
    End Sub
    Sub New(ByVal p1 As String, ByVal p2 As String, ByVal b As Boolean)
        po1 = p1
        po2 = p2
        forDialog = b
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True

        l.Text = "Download Liste von Genres"
        l.Labelstring = "Lädt Genre"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = 0
        l.ProgressBar1.Style = ProgressBarStyle.Marquee

        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        getGenres()
        addGenres()


    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        'l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If forDialog = True Then
            If gList.Count > 0 Then
                Dim rc(gList.Count - 1) As DataGridViewRow
                For x As Integer = 0 To gList.Count - 1
                    Dim r As New DataGridViewRow

                    r.CreateCells(Dialog_Filterbearbeiten.DataGridView1)
                    r.Cells(0).Value = gList(x).id
                    r.Cells(1).Value = gList(x).Name
                    r.Cells(2).Value = gList(x).altName
                    r.Cells(3).Value = gList(x).Filter
                    rc(x) = r

                Next
                Dialog_Filterbearbeiten.DataGridView1.Rows.AddRange(rc)
            End If
        Else
            Einstellungen.GenreFilter.FilterList = gList
        End If


        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_ChangeMediaInfo
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property sVideoAuflösung As String = ""
    Property sVideoSeitenverhältnis As String = ""
    Property sVideoBildwiederholungsrate As String = ""
    Property sVideoCodec As String = ""
    Property sAudioKanäle As String = ""
    Property sAudioCodec As String = ""
    Property sAudioSprachen As String = ""

    Property removeold As Boolean
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Informationsfeld wird bearbeitet"
        l.Labelstring = "Bearbeite MediaInfo"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub



    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                If Not sVideoAuflösung = "" Then
                    li(x).VideoAuflösung = sVideoAuflösung
                End If
                If Not sVideoSeitenverhältnis = "" Then
                    li(x).VideoSeitenverhältnis = sVideoSeitenverhältnis
                End If
                If Not sVideoBildwiederholungsrate = "" Then
                    li(x).VideoBildwiederholungsrate = sVideoBildwiederholungsrate
                End If
                If Not sVideoCodec = "" Then
                    li(x).VideoCodec = sVideoCodec
                End If
                If Not sAudioKanäle = "" Then
                    li(x).AudioKanäle = sAudioKanäle
                End If
                If Not sAudioCodec = "" Then
                    li(x).AudioCodec = sAudioCodec
                End If
                If Not sAudioSprachen = "" Then
                    li(x).AudioSprachen = sAudioSprachen
                End If



                li(x).SaveFile()

            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Edit_Sammlung
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property gen As String = ""
    Property removeold As Boolean
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Informationsfeld wird bearbeitet"
        l.Labelstring = "Ändere Sammlung/Set"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub

    Property ClearThem As Boolean



    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.Info Then
                    If ClearThem = True Then
                        li(x).Sort = SammlungFunctions.ClearSammlung(li(x).Sort)
                    Else
                        li(x).Sort = SammlungFunctions.AddSammlung(li(x).Sort, gen)
                    End If
                ElseIf Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                    If ClearThem = True Then
                        li(x).Setbox = SammlungFunctions.ClearSammlung(li(x).Sort)
                    Else

                        li(x).Setbox = gen

                    End If
                End If



                li(x).SaveFile()

            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class

Public Class Progress_Add_Genre
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property gen As List(Of String)
    Property removeold As Boolean
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Informationsfeld wird bearbeitet"
        l.Labelstring = "Füge Genre hinzu"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub



    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Labelstring = li(x).Titel
                l.Nächster()
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))
                If removeold = True Then
                    li(x).Genre = ""
                End If
                For Each s In gen
                    If li(x).Genre = "" Then
                        li(x).Genre = s
                    Else
                        li(x).Genre &= ", " & s
                    End If
                Next

                li(x).Genre = Einstellungen.GenreFilter.ChangeGenre(li(x).Genre)
                li(x).SaveFile()

            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For x As Integer = 0 To li.Count - 1
            li(x).Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_SheetMove
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Sheet_Result)
    Property creator As New MoviesheetCreator
    Dim l As New Laden_Dialog
    Delegate Sub Refresh_Movie(ByVal m As Movie)
    Sub New(ByVal lm As List(Of Sheet_Result))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Moviesheets verschieben"
        l.Labelstring = "Verschiebe Thumbnails"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).movie.Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                creator.MoveImages(li(x))
                l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x).movie})
            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()

        'creator.Builddialog()
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_SheetCreat
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property creator As New MoviesheetCreator
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Moviesheets erstellen"
        l.Labelstring = "Erstelle Thumbnails"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()

                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                creator.Creat(li(x))

            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()

        creator.Builddialog()
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_Search
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property ri As New List(Of Movie)
    Dim l As New Laden_Dialog
    Delegate Sub Save_Movie(ByVal m As Movie, ByVal s As Search_Result)
    Delegate Sub Refresh_Movie(ByVal m As Movie)


    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm
        'l.Worker = Worker
        l.Text = "Suche Film in der Datenbank"
        l.Labelstring = "Suche"
        'l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'l.advGesamtzahl = 8
        'laden = l
        'l.Timecounter = False
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    'Dim pushlist As New List(Of String)
    'Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then
                l.Nächster()
                l.Labelstring = li(x).Titel
                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))

                'Try
                Dim s As Search_Result = MetaScrapper.Suche_Progress(li(x), l, Worker, CInt(((x + 1) / li.Count) * 100))
                If s Is Nothing Then
                    ri.Add(li(x))
                Else

                    MetaScrapper.Complete_Progress(s, l, Worker, CInt(((x + 1) / li.Count) * 100))
                    l.Invoke(New Save_Movie(AddressOf MetaScrapper.Save), New Object() {li(x), s})
                    l.Invoke(New Refresh_Movie(AddressOf l.RefreshMovie), New Object() {li(x)})
                End If
                'Catch ex As Exception
                '    MsgBox(ex.Message, MsgBoxStyle.Critical, "Unbehandelter Fehler")
                'End Try


            End If
        Next
    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        For Each i In li
            i.Refresh()
        Next
        l.closallowed = True
        l.Close()
        l.Dispose()

        MetaScrapper.Suche(ri)
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_InstallFFProbe
    Property li As List(Of Movie)
    Property mode As Savemode
    Property filesize As Long = 0
    Property filesize_loaded As Long = 0
    Property source As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20FFProbe.exe"
    Property dest As String = IO.Path.Combine(Einstellungen.ChachePath, "Plugin_FFProbe.exe")
    Dim b32 As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20FFProbe%2032.exe"
    Dim b64 As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20FFProbe%2064.exe"
    Public WithEvents WC As New System.Net.WebClient
    Dim l As New Laden_Dialog
    Sub New()

        If OS.GetOSType = OS.OSType.Is64Bit Then
            source = b64
        Else
            source = b32
        End If

        'li = lm
        l.costumlabel = True
        l.Text = "Download Plugin"
        l.Labelstring = "Download"
        l.aDetails = False
        l.aCancel = False
        'l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()

        l.Show()
        WC.DownloadFileAsync(New Uri(source), dest)

        'Worker.RunWorkerAsync()
    End Sub
    Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        'form1.ProgressBar2.Value = e.ProgressPercentage
        Dim TotalBytes As Long = CLng(e.TotalBytesToReceive / 1024)
        'Dim TotalBytes2 As Long = WebFunctions.WebFileSize(_aktive_File.Source.AbsolutePath)
        'MsgBox(TotalBytes & vbCrLf & TotalBytes2)
        Dim Bytes As Long = CLng(e.BytesReceived / 1024)
        If TotalBytes < 1 Then TotalBytes = 1
        If Bytes < 1 Then Bytes = 1
        filesize_loaded = Bytes
        filesize = TotalBytes
        l.Labelstring = "Download ... " & WebFunctions.FormatKiloBytes(filesize_loaded) & "/" & WebFunctions.FormatKiloBytes(filesize)
        l.Aktualisieren(e.ProgressPercentage)

        'If Not TotalBytes = _aktive_File.Info_Filesize_old Then
        '    MsgBox(TotalBytes & vbCrLf & _aktive_File.Info_Filesize_old)
        'End If

        'RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
  ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

        If Not e.Error Is Nothing Then
            MsgBox("Fehler beim Download aufgetreten" & vbCrLf & e.Error.Message, MsgBoxStyle.Exclamation, "Fehler")
        Else
            Dim psi As New System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)

            Dim sheet As New Process
            sheet.StartInfo.FileName = dest
            sheet.StartInfo.Arguments = """" & Application.StartupPath & """"
            sheet.StartInfo.UseShellExecute = False

            sheet.StartInfo.RedirectStandardOutput = True

            sheet.StartInfo.CreateNoWindow = True


            sheet.Start()





            sheet.WaitForExit()
            'Process.Start(psi)

            Application.DoEvents()

            Threading.Thread.Sleep(1000)
            If Settings.Visible = True Then
                Settings.FFProbecheck()
            End If
        End If

        '
        '    RaiseEvent ItemDownloadProgressChanged(Me)
        'Else
        '    If IO.File.Exists(_aktive_File.Destination) Then
        '        _aktive_File.Status = DLState.Loaded
        '        _aktive_File.Info_Loadedsize = _aktive_File.Info_Filesize
        '    Else
        '        _aktive_File.Status = DLState.Failed
        '        _aktive_File.Info_Loadedsize = 0
        '    End If
        '    Run()
        'End If



        'C:\Windows\Media\Windows-Benachrichtigung.wav
        'If canceld = True Then
        '    _aktive_File.Status = DLState.Canaceld
        '    _Subnode.Text = "Bilder Abgebrochen"
        '    _Subnode.BackColor = Color.Silver
        '    Status = DLState.Canaceld
        '    form1.wbl._act_downloads = -1
        '    form1.wbl.RunDownload()
        '    canceld = False
        'Else
        '    _aktive_File.Status = DLState.Finished
        '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
        '    Dim p As Integer = m / Files.Count * 100
        '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
        '    Dim ps As String = p
        '    If ps.Length = 1 Then
        '        ps = "00" & p
        '    End If
        '    If ps.Length = 2 Then
        '        ps = "0" & p
        '    End If
        '    _Node.Text = "| " & ps & " | " & _Node.Tag

        '    If m = Files.Count Then
        '        dlclient.Dispose()
        '        Status = DLState.Finished
        '        form1.wbl._act_downloads = -1
        '        form1.wbl.RunDownload()
        '        _Node.Text = _Node.Tag
        '        _Node.BackColor = Color.FromArgb(192, 255, 192)
        '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
        '        _Node.Collapse()
        '    Else
        '        Run() 'Nächsten Download starten"
        '    End If
        'End If

        'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
        'form1.Refresh()
        l.closallowed = True
        l.Close()
        l.Dispose()
        'Worker.Dispose()


        'dls(x).Dispose()
        'actDLs -= 1
        'Timer1.Stop()
        'If actDLs = 0 Then
        '    'Warteschlage()
        'End If

        'NextDownloadStart()
        'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    End Sub


End Class
Public Class Progress_InstallMovieSheet
    Property li As List(Of Movie)
    Property mode As Savemode
    Property filesize As Long = 0
    Property filesize_loaded As Long = 0
    Property source As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20MovieThumbnailer.exe"
    Property dest As String = IO.Path.Combine(Einstellungen.ChachePath, "Plugin_MovieThumb.exe")

    Public WithEvents WC As New System.Net.WebClient
    Dim l As New Laden_Dialog
    Sub New()

        'li = lm
        l.costumlabel = True
        l.Text = "Download Moviesheet"
        l.Labelstring = "Download"
        l.aDetails = False
        l.aCancel = False
        'l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()

        l.Show()
        WC.DownloadFileAsync(New Uri(source), dest)

        'Worker.RunWorkerAsync()
    End Sub
    Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        'form1.ProgressBar2.Value = e.ProgressPercentage
        Dim TotalBytes As Long = CLng(e.TotalBytesToReceive / 1024)
        'Dim TotalBytes2 As Long = WebFunctions.WebFileSize(_aktive_File.Source.AbsolutePath)
        'MsgBox(TotalBytes & vbCrLf & TotalBytes2)
        Dim Bytes As Long = CLng(e.BytesReceived / 1024)
        If TotalBytes < 1 Then TotalBytes = 1
        If Bytes < 1 Then Bytes = 1
        filesize_loaded = Bytes
        filesize = TotalBytes
        l.Labelstring = "Download ... " & WebFunctions.FormatKiloBytes(filesize_loaded) & "/" & WebFunctions.FormatKiloBytes(filesize)
        l.Aktualisieren(e.ProgressPercentage)

        'If Not TotalBytes = _aktive_File.Info_Filesize_old Then
        '    MsgBox(TotalBytes & vbCrLf & _aktive_File.Info_Filesize_old)
        'End If

        'RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
  ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted

        If Not e.Error Is Nothing Then
            MsgBox("Fehler beim Download aufgetreten" & vbCrLf & e.Error.Message, MsgBoxStyle.Exclamation, "Fehler")
        Else
            Dim psi As New System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)

            Dim sheet As New Process
            sheet.StartInfo.FileName = dest
            sheet.StartInfo.Arguments = """" & Application.StartupPath & """"
            sheet.StartInfo.UseShellExecute = False

            sheet.StartInfo.RedirectStandardOutput = True

            sheet.StartInfo.CreateNoWindow = True


            sheet.Start()





            sheet.WaitForExit()
            'Process.Start(psi)

            Application.DoEvents()

            Threading.Thread.Sleep(1000)
            If Settings.Visible = True Then
                Settings.Moviethumbcheck()
            End If
        End If

        '
        '    RaiseEvent ItemDownloadProgressChanged(Me)
        'Else
        '    If IO.File.Exists(_aktive_File.Destination) Then
        '        _aktive_File.Status = DLState.Loaded
        '        _aktive_File.Info_Loadedsize = _aktive_File.Info_Filesize
        '    Else
        '        _aktive_File.Status = DLState.Failed
        '        _aktive_File.Info_Loadedsize = 0
        '    End If
        '    Run()
        'End If



        'C:\Windows\Media\Windows-Benachrichtigung.wav
        'If canceld = True Then
        '    _aktive_File.Status = DLState.Canaceld
        '    _Subnode.Text = "Bilder Abgebrochen"
        '    _Subnode.BackColor = Color.Silver
        '    Status = DLState.Canaceld
        '    form1.wbl._act_downloads = -1
        '    form1.wbl.RunDownload()
        '    canceld = False
        'Else
        '    _aktive_File.Status = DLState.Finished
        '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
        '    Dim p As Integer = m / Files.Count * 100
        '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
        '    Dim ps As String = p
        '    If ps.Length = 1 Then
        '        ps = "00" & p
        '    End If
        '    If ps.Length = 2 Then
        '        ps = "0" & p
        '    End If
        '    _Node.Text = "| " & ps & " | " & _Node.Tag

        '    If m = Files.Count Then
        '        dlclient.Dispose()
        '        Status = DLState.Finished
        '        form1.wbl._act_downloads = -1
        '        form1.wbl.RunDownload()
        '        _Node.Text = _Node.Tag
        '        _Node.BackColor = Color.FromArgb(192, 255, 192)
        '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
        '        _Node.Collapse()
        '    Else
        '        Run() 'Nächsten Download starten"
        '    End If
        'End If

        'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
        'form1.Refresh()
        l.closallowed = True
        l.Close()
        l.Dispose()
        'Worker.Dispose()


        'dls(x).Dispose()
        'actDLs -= 1
        'Timer1.Stop()
        'If actDLs = 0 Then
        '    'Warteschlage()
        'End If

        'NextDownloadStart()
        'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    End Sub


End Class
Public Class Progress_InstallMediaInfo
    Property filesize As Long = 0
    Property filesize_loaded As Long = 0
    Property source As String = ""
    Property dest As String = IO.Path.Combine(Einstellungen.ChachePath, "Plugin-MediaInfo.exe")
    Property needrestart As Boolean
    Public WithEvents WC As New System.Net.WebClient
    Dim l As New Laden_Dialog
    Sub New()

        Dim b32 As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20MediaInfo%2032.exe"
        Dim b64 As String = "http://dl.dropbox.com/u/6880006/Update/Plugins/Film%20Info%21%20MediaInfo%2064.exe"
        If OS.GetOSType = OS.OSType.Is64Bit Then
            source = b64
        Else
            source = b32
        End If


        l.Text = "Download MediaInfo"
        l.IntroductionText = "Download MediaInfo"
        l.Timecounter = False
        l.costumlabel = True
        l.aDetails = False
        l.aCancel = False
        'l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()

        'l.Show()
        WC.DownloadFileAsync(New Uri(source), dest)

        'Worker.RunWorkerAsync()
    End Sub
    Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        'form1.ProgressBar2.Value = e.ProgressPercentage
        Dim TotalBytes As Long = CLng(e.TotalBytesToReceive / 1024)
        'Dim TotalBytes2 As Long = WebFunctions.WebFileSize(_aktive_File.Source.AbsolutePath)
        'MsgBox(TotalBytes & vbCrLf & TotalBytes2)
        Dim Bytes As Long = CLng(e.BytesReceived / 1024)
        If TotalBytes < 1 Then TotalBytes = 1
        If Bytes < 1 Then Bytes = 1
        filesize_loaded = Bytes
        filesize = TotalBytes
        l.Labelstring = "Download ... " & WebFunctions.FormatKiloBytes(filesize_loaded) & "/" & WebFunctions.FormatKiloBytes(filesize)
        l.Aktualisieren(e.ProgressPercentage)

        'If Not TotalBytes = _aktive_File.Info_Filesize_old Then
        '    MsgBox(TotalBytes & vbCrLf & _aktive_File.Info_Filesize_old)
        'End If

        'RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
  ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        Dim psi As New System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)
        If Not e.Error Is Nothing Then
            MsgBox("Fehler beim Download aufgetreten" & vbCrLf & e.Error.Message, MsgBoxStyle.Exclamation, "Fehler")
        Else

            If needrestart = True Then
                MainForm.restart = True
                MainForm.restart_path = dest
                MainForm.Close()

            Else
                Dim sheet As New Process
                sheet.StartInfo.FileName = dest
                sheet.StartInfo.Arguments = """" & Application.StartupPath & """"
                sheet.StartInfo.UseShellExecute = False
                sheet.StartInfo.RedirectStandardOutput = True
                sheet.StartInfo.CreateNoWindow = True
                sheet.Start()
                sheet.WaitForExit()
                Application.DoEvents()
                Threading.Thread.Sleep(1000)
                Settings.GroupBox_MediaiNfo.Enabled = False
                If Settings.Visible = True Then
                    Dim cr As New Progress_CheckMediaInfo
                    cr.Run()

                    Settings.Show()
                    Settings.BringToFront()
                End If

            End If

        End If
        'If Not e.Error Is Nothing Then
        '    RaiseEvent ItemDownloadProgressChanged(Me)
        'Else
        '    If IO.File.Exists(_aktive_File.Destination) Then
        '        _aktive_File.Status = DLState.Loaded
        '        _aktive_File.Info_Loadedsize = _aktive_File.Info_Filesize
        '    Else
        '        _aktive_File.Status = DLState.Failed
        '        _aktive_File.Info_Loadedsize = 0
        '    End If
        '    Run()
        'End If



        'C:\Windows\Media\Windows-Benachrichtigung.wav
        'If canceld = True Then
        '    _aktive_File.Status = DLState.Canaceld
        '    _Subnode.Text = "Bilder Abgebrochen"
        '    _Subnode.BackColor = Color.Silver
        '    Status = DLState.Canaceld
        '    form1.wbl._act_downloads = -1
        '    form1.wbl.RunDownload()
        '    canceld = False
        'Else
        '    _aktive_File.Status = DLState.Finished
        '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
        '    Dim p As Integer = m / Files.Count * 100
        '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
        '    Dim ps As String = p
        '    If ps.Length = 1 Then
        '        ps = "00" & p
        '    End If
        '    If ps.Length = 2 Then
        '        ps = "0" & p
        '    End If
        '    _Node.Text = "| " & ps & " | " & _Node.Tag

        '    If m = Files.Count Then
        '        dlclient.Dispose()
        '        Status = DLState.Finished
        '        form1.wbl._act_downloads = -1
        '        form1.wbl.RunDownload()
        '        _Node.Text = _Node.Tag
        '        _Node.BackColor = Color.FromArgb(192, 255, 192)
        '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
        '        _Node.Collapse()
        '    Else
        '        Run() 'Nächsten Download starten"
        '    End If
        'End If

        'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
        'form1.Refresh()
        l.closallowed = True
        l.Close()
        l.Dispose()
        'Worker.Dispose()


        'dls(x).Dispose()
        'actDLs -= 1
        'Timer1.Stop()
        'If actDLs = 0 Then
        '    'Warteschlage()
        'End If

        'NextDownloadStart()
        'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    End Sub

End Class
Public Class Progress_InstallUpdates
    Property filesize As Long = 0
    Property filesize_loaded As Long = 0
    Property source As String = ""
    Property dest As String = IO.Path.Combine(Einstellungen.ChachePath, "updater.exe")
    Property needrestart As Boolean = True
    Public WithEvents WC As New System.Net.WebClient
    'Dim l As New Laden_Dialog
    Sub New(ByVal s As String, ByVal t As String)

        Dim chan() As String = t.Split(CChar(vbCrLf))
        MainForm.Update_Link.Text = chan.Length & " Änderungen"
        MainForm.Update_Link.Tag = t

        MainForm.Panel_Update.Location = New System.Drawing.Point(MainForm.Panel_Update.Location.X, -30)
        MainForm.Panel_Update.Visible = True
        MainForm.Panel_Update.Refresh()
        For x As Integer = 0 To 30 Step 10
            MainForm.Panel_Update.Location = New System.Drawing.Point(MainForm.Panel_Update.Location.X, x - 30)
            Threading.Thread.Sleep(10)
            MainForm.Refresh()
        Next
        source = s


    End Sub
    Public Sub Run()

        'l.Show()
        WC.DownloadFileAsync(New Uri(source), dest)

        'Worker.RunWorkerAsync()
    End Sub
    Private Sub httpClient_DownloadProgressChanged(ByVal sender As Object, _
ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles WC.DownloadProgressChanged
        'form1.ProgressBar2.Value = e.ProgressPercentage
        Dim TotalBytes As Long = CLng(e.TotalBytesToReceive / 1024)
        'Dim TotalBytes2 As Long = WebFunctions.WebFileSize(_aktive_File.Source.AbsolutePath)
        'MsgBox(TotalBytes & vbCrLf & TotalBytes2)
        Dim Bytes As Long = CLng(e.BytesReceived / 1024)
        If TotalBytes < 1 Then TotalBytes = 1
        If Bytes < 1 Then Bytes = 1
        filesize_loaded = Bytes
        filesize = TotalBytes
        MainForm.Label_Update_State.Text = "Download ... " & WebFunctions.FormatKiloBytes(filesize_loaded) & "/" & WebFunctions.FormatKiloBytes(filesize)
        MainForm.Panel_Update_more.Refresh()
        'l.Aktualisieren(e.ProgressPercentage)

        'If Not TotalBytes = _aktive_File.Info_Filesize_old Then
        '    MsgBox(TotalBytes & vbCrLf & _aktive_File.Info_Filesize_old)
        'End If

        'RaiseEvent ItemDownloadProgressChanged(Me)
    End Sub
    Private Sub httpClient_DownloadFileCompleted(ByVal sender As Object, _
  ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles WC.DownloadFileCompleted
        Dim psi As New System.Diagnostics.ProcessStartInfo(Application.ExecutablePath)
        If Not e.Error Is Nothing Then
            MsgBox("Fehler beim Download aufgetreten" & vbCrLf & e.Error.Message, MsgBoxStyle.Exclamation, "Fehler")
            MainForm.Label_Update.Text = "Updates fehlgeschlagen"
            MainForm.PictureBox2.Image = Toolbar16.Abbrechen
            MainForm.Label_Update_State.Text = "Fehler aufgetreten"
        Else
            MainForm.PictureBox2.Image = Toolbar16.Ok
            MainForm.Label_Update.Text = "Updates bereit"
            MainForm.Label_Update_State.Text = "Download komplett"
            If MainForm.Panel_Update_more.Visible = False Then
                MainForm.Panel_Update_more.Visible = True
                For x As Integer = 0 To 90 Step 10
                    MainForm.Panel_Update_more.Location = New System.Drawing.Point(MainForm.Panel_Update_more.Location.X, x - 60)
                    Threading.Thread.Sleep(10)
                    MainForm.Panel_Update_more.Refresh()
                Next
            End If
            Einstellungen.UserUpdate.Updateready = True
            If Dialog_Update.Visible = True Then
                Dialog_Update.OK_Button.Enabled = True
            End If
            MainForm.Button3.Enabled = True
            MainForm.restart = True
            MainForm.restart_path = dest
            'If needrestart = True Then
            '    Main.restart = True
            '    Main.Close()

            'Else
            '    Dim sheet As New Process
            '    sheet.StartInfo.FileName = dest
            '    sheet.StartInfo.Arguments = """" & Application.StartupPath & """"
            '    sheet.StartInfo.UseShellExecute = False
            '    sheet.StartInfo.RedirectStandardOutput = True
            '    sheet.StartInfo.CreateNoWindow = True
            '    sheet.Start()
            '    sheet.WaitForExit()
            '    Application.DoEvents()
            '    Threading.Thread.Sleep(1000)
            '    Settings.GroupBox_MediaiNfo.Enabled = False
            '    If Settings.Visible = True Then
            '        Dim cr As New Progress_CheckMediaInfo
            '        cr.Run()

            '        Settings.Show()
            '        Settings.BringToFront()
            '    End If

            'End If

        End If
        'If Not e.Error Is Nothing Then
        '    RaiseEvent ItemDownloadProgressChanged(Me)
        'Else
        '    If IO.File.Exists(_aktive_File.Destination) Then
        '        _aktive_File.Status = DLState.Loaded
        '        _aktive_File.Info_Loadedsize = _aktive_File.Info_Filesize
        '    Else
        '        _aktive_File.Status = DLState.Failed
        '        _aktive_File.Info_Loadedsize = 0
        '    End If
        '    Run()
        'End If



        'C:\Windows\Media\Windows-Benachrichtigung.wav
        'If canceld = True Then
        '    _aktive_File.Status = DLState.Canaceld
        '    _Subnode.Text = "Bilder Abgebrochen"
        '    _Subnode.BackColor = Color.Silver
        '    Status = DLState.Canaceld
        '    form1.wbl._act_downloads = -1
        '    form1.wbl.RunDownload()
        '    canceld = False
        'Else
        '    _aktive_File.Status = DLState.Finished
        '    Dim m As Integer = Count(DLState.Finished, DLState.Failed)
        '    Dim p As Integer = m / Files.Count * 100
        '    _Subnode.Text = "Bilder " & m & "/" & Files.Count
        '    Dim ps As String = p
        '    If ps.Length = 1 Then
        '        ps = "00" & p
        '    End If
        '    If ps.Length = 2 Then
        '        ps = "0" & p
        '    End If
        '    _Node.Text = "| " & ps & " | " & _Node.Tag

        '    If m = Files.Count Then
        '        dlclient.Dispose()
        '        Status = DLState.Finished
        '        form1.wbl._act_downloads = -1
        '        form1.wbl.RunDownload()
        '        _Node.Text = _Node.Tag
        '        _Node.BackColor = Color.FromArgb(192, 255, 192)
        '        _Subnode.BackColor = Color.FromArgb(192, 255, 192)
        '        _Node.Collapse()
        '    Else
        '        Run() 'Nächsten Download starten"
        '    End If
        'End If

        'form1.DataGridView1.Rows(0).Cells(5).Value = "Fertig"
        'form1.Refresh()
        'l.closallowed = True
        'l.Close()
        'l.Dispose()
        'Worker.Dispose()


        'dls(x).Dispose()
        'actDLs -= 1
        'Timer1.Stop()
        'If actDLs = 0 Then
        '    'Warteschlage()
        'End If

        'NextDownloadStart()
        'sndPlaySound("C:\Windows\Media\Windows-Benachrichtigung.wav", SND_ASYNC)

    End Sub

End Class
Public Class Progress_CheckMediaInfo
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property mode As Savemode
    Property myVersion As String
    Property onlineVersion As String
    Sub New()
        Worker.WorkerReportsProgress = False
        Worker.WorkerSupportsCancellation = True



    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog
        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML("http://fio.square7.ch/Download/MediaInfo/update.xml", "")
        If Not xml Is Nothing Then
            Dim online As String
            online = If(xml.SelectNodes("//Version").Count > 0, xml.SelectSingleNode("//Version").InnerText, "")
            onlineVersion = online
        Else
            onlineVersion = "Fehler"
        End If


        'If IO.File.Exists(IO.Path.Combine(Application.StartupPath, "MediaInfo.dll")) Then
        Try
            Dim mi As New MediaInfo

            Dim To_Display As String = mi.Option_("Info_Version", "0.7.0.0")
            mi.Close()

            If (To_Display.Length() = 0) Then
                myVersion = "Diese Version wird nicht unterstüzt"
            Else
                myVersion = To_Display.Replace("MediaInfoLib - ", "")
            End If
        Catch ex As Exception
            If ex.Message = "Es wurde versucht, eine Datei mit einem falschen Format zu laden. (Ausnahme von HRESULT: 0x8007000B)" Then
                myVersion = "Diese Version wird nicht unterstüzt"
            Else
                myVersion = ""
            End If
        End Try

        'Else
        'myVersion = ""
        'End If

    End Sub
    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If Settings.Visible = True Then
            Dim s As String = "Download"
            If myVersion = "" Then
                Settings.MediaInfoVersion.Text = "MediaInfo ist nicht installiert"
                Settings.MediaInfoPic.Image = Toolbar16.Abbrechen
                s = "Download"
            ElseIf myVersion = "Diese Version wird nicht unterstüzt" Then
                Settings.MediaInfoVersion.Text = "MediaInfo ist nicht installiert (falsche Version)"
                Settings.MediaInfoPic.Image = Toolbar16.Abbrechen
                s = "Aktualisieren"
            Else
                Settings.MediaInfoVersion.Text = "MediaInfo ist installiert (" & myVersion & ")"
                Settings.MediaInfoPic.Image = Toolbar16.Ok
                s = "Aktualisieren"
            End If
            Settings.GroupBox_MediaiNfo.Enabled = True
            If myVersion = onlineVersion Or onlineVersion = "Fehler" Then
                Settings.MediaInfo_Download.Enabled = False
            Else
                Settings.MediaInfo_Download.Enabled = True
                Settings.MediaInfo_Download.Text = s
            End If
            'Settings.MediaInfo_Online.Text = onlineVersion
            Settings.BringToFront()
        End If
        Worker.Dispose()
    End Sub

End Class
Public Class Progress_CheckForUpdates
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Dim neuer As Boolean = False
    Dim Source As String = ""
    Dim Changes As String = ""
    Public Dialog As Boolean = False
    Sub New()
        Worker.WorkerReportsProgress = False
        Worker.WorkerSupportsCancellation = True



    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Shared Function toDbl(ByVal s As String) As Double
        Dim r As Double = -1
        Try
            r = CDbl(s)
        Catch ex As Exception

        End Try
        Return r
    End Function
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        'Dim i, j As Integer    ' Hilfsvariablen
        'Dim xml As Xml.XmlDocument
        'Xml = MyFunctions.HttploadXML("http://fio.square7.ch/legend/update/update.xml")
        ' '' xml = MyFunctions.HttploadXML("http://dl.dropbox.com/u/6880006/update.xml")
        'If IsNothing(xml) Then
        '    MsgBox("Keine Verbindung")
        '    Exit Sub
        'End If

        Dim maj As Double
        Dim min As Double
        Dim bui As Double
        Dim rev As Double

        Dim xml As Xml.XmlDocument
        xml = MyFunctions.HttploadXML("http://dl.dropbox.com/u/6880006/Update/update.xml", "")
        'xml = MyFunctions.HttploadXML("http://fio.square7.ch/legend/update/update.xml")
        Dim nxml As Xml.XmlNode
        If Not xml Is Nothing Then

            nxml = xml.SelectSingleNode("//Version")

            maj = toDbl(nxml.Attributes("Version_Major").Value)
            min = toDbl(nxml.Attributes("Version_Minor").Value)
            bui = toDbl(nxml.Attributes("Version_Build").Value)
            rev = toDbl(nxml.Attributes("Version_Revision").Value)
            If maj > My.Application.Info.Version.Major Then
                neuer = True
            ElseIf maj = My.Application.Info.Version.Major Then
                If min > My.Application.Info.Version.Minor Then
                    neuer = True
                ElseIf min = My.Application.Info.Version.Minor Then
                    If bui > My.Application.Info.Version.Build Then
                        neuer = True
                    ElseIf bui = My.Application.Info.Version.Build Then
                        If rev > My.Application.Info.Version.Revision Then
                            neuer = True
                        End If
                    End If
                End If
            End If



            Source = If(xml.SelectNodes("//Source").Count > 0, xml.SelectSingleNode("//Source").InnerText, "")
            Dim j As Integer = xml.SelectNodes("//Change").Count
            If j > 0 Then
                For x As Integer = 0 To j - 1
                    If Changes = "" Then
                        Changes = xml.SelectNodes("//Change").Item(x).InnerText
                    Else
                        Changes &= vbCrLf & xml.SelectNodes("//Change").Item(x).InnerText
                    End If
                Next
            End If
            Einstellungen.UserUpdate.Aktueller = neuer
            Einstellungen.UserUpdate.Changes = Changes
            Einstellungen.UserUpdate.NewVersion = maj & "." & min & "." & bui & "." & rev
            Einstellungen.UserUpdate.OldVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
            'Changes = If(xml.SelectNodes("//Change").Count > 0, xml.SelectSingleNode("//Change").InnerText, "")
        Else
        End If



    End Sub
    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If Dialog = True Then
            Dialog_Update.Show()
        End If
        If neuer = True Then
            Dim dl As New Progress_InstallUpdates(Source, Changes)
            dl.Run()
        End If
        Worker.Dispose()
    End Sub


End Class
Public Class Progress_FileMove
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Dim arg() As String
    Property dest As String
    Property re As Integer = 0
    Sub New(ByVal args() As String, ByVal s As String)
        arg = args
        dest = s
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Try
            Dim ep As New ExplorerActions
            re = CInt(ep.fmanyMove(arg, dest))
        Catch ex As Exception
            MsgBox("Fehler" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        Worker.Dispose()
        If Not MainForm.SelectedMovie Is Nothing Then
            MainForm.InfoPanel_Movie1.RefreshFolderPrev(MainForm.SelectedMovie.Pfad)
        End If
    End Sub
End Class
Public Class Progress_FileCopy
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Dim arg() As String
    Property dest As String
    Property re As Integer = 0
    Sub New(ByVal args() As String, ByVal D As String)
        arg = args
        dest = D
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Try
            Dim ep As New ExplorerActions
            re = CInt(ep.fmanyCopy(arg, dest))
        Catch ex As Exception
            MsgBox("Fehler" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        Worker.Dispose()
        If Not MainForm.SelectedMovie Is Nothing Then
            MainForm.InfoPanel_Movie1.RefreshFolderPrev(MainForm.SelectedMovie.Pfad)
        End If

    End Sub
End Class
Public Class Progress_MovieMove
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property dest As String
    Property re As Integer = 0
    Sub New(ByVal lm As List(Of Movie), ByVal s As String)
        li = lm
        dest = s
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Try
            If li.Count = 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fMove(li(0).Pfad, IO.Path.Combine(dest, IO.Path.GetFileName(li(0).Pfad))))

            ElseIf li.Count > 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fmanyMove(li, dest))
            End If
        Catch ex As Exception
            MsgBox("Fehler" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If re = 0 Then
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Erfolgreich"
                .MyToolTip.Show("Filme wurden erfolgreich verschoben.", MainForm, 20, 40, 2000)
            End With
        End If
        MainForm.DataGridView1_SelectionChanged(Me, New EventArgs)
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_MovieCopy
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property dest As String
    Property re As Integer = 0
    Sub New(ByVal lm As List(Of Movie), ByVal s As String)
        li = lm
        dest = s
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Try
            If li.Count = 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fCopy(li(0).Pfad, IO.Path.Combine(dest, IO.Path.GetFileName(li(0).Pfad)), False))
            ElseIf li.Count > 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fmanyCopy(li, dest, False))
            End If
        Catch ex As Exception
            MsgBox("Fehler" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        If re = 0 Then
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Erfolgreich"
                .MyToolTip.Show("Filme wurden erfolgreich kopiert.", MainForm, 20, 40, 2000)
            End With
        End If
        Worker.Dispose()
    End Sub
End Class
Public Class Progress_FileDelet
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property re As Integer = 0
    Sub New(ByVal lm As List(Of Movie))
        li = lm
    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Try
            If li.Count = 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fDelete(li(0).Pfad, True, True))

            ElseIf li.Count > 0 Then
                Dim ep As New ExplorerActions
                re = CInt(ep.fmanyDelete(li, True, True))
            End If
        Catch ex As Exception
            MsgBox("Fehler" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        If re = 0 Then
            With MainForm
                .MyToolTip.ToolTipIcon = ToolTipIcon.Info
                .MyToolTip.ToolTipTitle = "Erfolgreich"
                .MyToolTip.Show("Filme wurden erfolgreich in den Papierkorb verschoben.", MainForm, 20, 40, 2000)
            End With
        End If

        For Each m In li
            MainForm.RemoveMovieFromList(m)
        Next


        MainForm.DataGridView1_SelectionChanged(Me, New EventArgs)
        Worker.Dispose()
    End Sub
End Class

Public Class Progress_Vorlage
    Public WithEvents Worker As System.ComponentModel.BackgroundWorker = New System.ComponentModel.BackgroundWorker
    Property li As List(Of Movie)
    Property mode As Savemode
    Dim l As New Laden_Dialog
    Sub New(ByVal lm As List(Of Movie))
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        li = lm

        l.Text = "Informationsfeld wird bearbeitet"
        l.Labelstring = "Füge Genre hinzu"
        l.aDetails = False
        l.aCancel = True
        l.Gesamtzahl = li.Count
        'laden = l
        l.Refresh()
        l.Show()

    End Sub
    Public Sub Run()
        Worker.RunWorkerAsync()
    End Sub

    Dim pushlist As New List(Of String)
    Dim result As New List(Of CoverDownload)
    Private Sub Worker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'Dim l As New Laden_Dialog


        For x As Integer = 0 To li.Count - 1
            If l.Cancel = False Then

                Worker.ReportProgress(CInt(((x + 1) / li.Count) * 100))



            End If
        Next

    End Sub

    Private Sub Worker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker.ProgressChanged
        l.Aktualisieren(e.ProgressPercentage)

        'pushlist.Clear()
    End Sub

    Private Sub Worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker.RunWorkerCompleted
        'laden.Close()
        l.closallowed = True
        l.Close()
        l.Dispose()
        Worker.Dispose()
    End Sub
End Class
