Imports System.Drawing.Drawing2D
'Public Shared Sub ExportPage2(ByVal ms As List(Of Movie))
'    Dim r As Bitmap = New Bitmap(2480, 3508)
'    Dim g As Graphics = Graphics.FromImage(r)
'    Dim f As Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'    g.InterpolationMode = InterpolationMode.HighQualityBicubic
'    g.SmoothingMode = SmoothingMode.AntiAlias
'    '260 (12)
'    For x As Integer = 0 To ms.Count - 1
'        Dim yloc As Integer = 150 + x * 260
'        If Not ms(x).Cover = "" Then
'            g.DrawImage(MyFunctions.ImageFromJpeg(ms(x).Cover), 30, yloc + 5, 170, 250)
'        Else
'            g.DrawImage(My.Resources.no_cover_bg, yloc, 30, 170, 250)
'        End If
'        g.DrawString(ms(x).Genre, f, Brushes.Black, New Point(300, yloc + 10))
'        g.DrawString(ms(x).Regisseur, f, Brushes.Black, New Point(300, yloc + 50))
'        g.DrawString(ms(x).Produktionsland, f, Brushes.Black, New Point(300, yloc + 90))
'        g.DrawString(ms(x).Inhalt, f, Brushes.Black, New Point(600, yloc + 90))
'        g.FillRectangle(Brushes.Gray, 30, yloc + 255, 2480 - 60, 2)
'    Next

'    'g.dr

'    g.Dispose()



'    g = Nothing
'    r.Save("D:\123.jpg")
'    Process.Start("D:\123.jpg")
'End Sub
'Public Shared Sub ExportPage(ByVal ms As List(Of Movie))
'    Dim r As Bitmap = New Bitmap(758, 140)
'    Dim g As Graphics = Graphics.FromImage(r)
'    Dim f As Font = New System.Drawing.Font("Sogeu UI", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'    Dim f2 As Font = New System.Drawing.Font("Sogeu UI", 32.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'    g.InterpolationMode = InterpolationMode.HighQualityBicubic
'    g.SmoothingMode = SmoothingMode.AntiAlias
'    '260 (12)
'    For x As Integer = 0 To ms.Count - 1
'        Dim xloc As Integer = x * 60
'        If Not ms(x).Cover = "" Then
'            g.DrawImage(MyFunctions.ImageFromJpeg(ms(x).Cover), xloc, 0, 100, 140)
'        Else
'            'g.DrawImage(My.Resources.no_cover_bg, yloc, 30, 170, 250)
'        End If
'        g.DrawString("Banner", f2, Brushes.Black, New Point(295, 95))
'        g.DrawString("Banner", f, Brushes.White, New Point(300, 100))



'        'g.DrawString(ms(x).Regisseur, f, Brushes.Black, New Point(300, yloc + 50))
'        'g.DrawString(ms(x).Produktionsland, f, Brushes.Black, New Point(300, yloc + 90))
'        'g.DrawString(ms(x).Inhalt, f, Brushes.Black, New Point(600, yloc + 90))
'        'g.FillRectangle(Brushes.Gray, 30, yloc + 255, 2480 - 60, 2)
'    Next

'    'g.dr

'    g.Dispose()



'    g = Nothing
'    r.Save("D:\123.jpg")
'    Process.Start("D:\123.jpg")
'End Sub

Public MustInherit Class ExportAction
    Property SourceFile As String
    Property DestFile As String
    Property DestFolder As String
    Property bCount As String
    Property imgh As Integer
    Property imgw As Integer
    Property de As DataExport
    Sub New()

    End Sub

    MustOverride Sub Start(ByVal li As List(Of Movie))

End Class
'Public Class ExportAction_Cover
'    Inherits ExportAction
'    Structure ImageLoopItem
'        Property Path As String
'        Property Width As Integer
'        Property Height As Integer
'        Property isOriginal As Boolean
'    End Structure
'    Dim sizes As New List(Of ImageLoopItem)
'    Sub New(ByVal c As String, ByVal d As DataExport)
'        de = d
'        Dim arr As String() = IO.Directory.GetFiles(c, "*%LoopCover%*", IO.SearchOption.AllDirectories)
'        Dim sizes As New List(Of ImageLoopItem)
'        For x As Integer = 0 To UBound(arr)
'            Dim img As Image = MyFunctions.ImageFromJpeg(arr(x))
'            If Not img Is Nothing Then
'                Dim s As New ImageLoopItem
'                s.Path = arr(x)
'                s.Height = img.Height
'                s.Width = img.Width
'                s.isOriginal = False
'                img.Dispose()
'                sizes.Add(s)
'            End If
'        Next
'        arr = IO.Directory.GetFiles(c, "*%LoopOriginalCover%*", IO.SearchOption.AllDirectories)
'        For x As Integer = 0 To UBound(arr)
'            Dim s As New ImageLoopItem
'            s.Path = arr(x)
'            s.Height = 0
'            s.Width = 0
'            s.isOriginal = True
'            sizes.Add(s)
'        Next
'    End Sub

'    Public Overrides Sub Start(ByVal li As List(Of Movie))

'        de.l.Aktuell = 0

'        For Each m In li
'            de.l.Nächster()
'            de.worker.ReportProgress(CInt(((li.IndexOf(m) + 1) / li.Count) * 100))
'            If Not m.Cover = "" Then
'                Using img As Image = MyFunctions.ImageFromJpeg(m.Cover)

'                    For Each s In sizes
'                        de.l.advLabelstring = IO.Path.GetFileName(s.Path)
'                        If img.Width > s.Width And img.Height > s.Height Then
'                            CreateCoverFromImage(s.Path, m.DVDChacheID, img, s.Width, s.Height)
'                        Else
'                            Dim v As String = Dest & s.Path.Replace(Vorlage, "")
'                            Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), de.ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
'                            IO.File.Copy(s.Path, d)
'                        End If

'                    Next



'                End Using

'            Else
'                For Each s In sizes
'                    Dim v As String = Dest & s.Path.Replace(Vorlage, "")
'                    Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
'                    If IO.File.Exists(d) Then
'                        IO.File.Delete(d)
'                    End If
'                    IO.File.Copy(s.Path, d)
'                Next
'            End If
'        Next


'        For x As Integer = 0 To UBound(arr)
'            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
'            If IO.File.Exists(v) Then
'                IO.File.Delete(v)
'            End If
'        Next




'        arr = IO.Directory.GetFiles(Vorlage, "*%LoopOriginalCover%*", IO.SearchOption.AllDirectories)
'        For x As Integer = 0 To UBound(arr)

'            l.Aktuell = 0
'            l.advLabelstring = IO.Path.GetFileName(arr(x))
'            For Each m In li
'                l.Nächster()
'                worker.ReportProgress(CInt(((li.IndexOf(m) + 1) / li.Count) * 100))
'                CreateCovers(arr(x), m)
'            Next
'            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
'            If IO.File.Exists(v) Then
'                IO.File.Delete(v)
'            End If
'        Next

'    End Sub
'End Class

Public Class DataExport
    Property li As New List(Of Movie)
    Property Vorlage As String
    Property l As Laden_Dialog
    Property worker As System.ComponentModel.BackgroundWorker
    Property Dest As String
    Property repalceCover As Boolean = True
    Property repalceBacks As Boolean = True
    Dim starter As String = ""
    Shared Property exportetBackdrops As Integer = 0
    Property replacer As New List(Of MyFunctions.ReplaceItem)

    Sub StartResult()
        If IO.File.Exists(Vorlage & "\run.txt") Then
            Dim readere As IO.StreamReader = New IO.StreamReader(Vorlage & "\run.txt")
            Dim text As String = readere.ReadToEnd
            readere.Close()
            Dim prr() As String = Split(text, vbCrLf)
            If prr.Length > 0 Then
                For Each p In prr
                    p = ReplaceCVals(p)
                    If p = "" Then
                        Process.Start(Dest)
                    ElseIf IO.File.Exists(Dest & "\" & p) Then
                        Try
                            Process.Start(Dest & "\" & p)
                        Catch ex As Exception

                        End Try

                    End If
                Next
            Else
                Process.Start(Dest)
            End If

        End If
    End Sub
    Sub New(ByVal Movies As List(Of Movie), ByVal P As String, ByVal d As String)
        Vorlage = P
        li = Movies
        Dest = d
        li.Sort(AddressOf Sort)
    End Sub
    Private Function Sort(ByVal x As Movie, ByVal y _
As Movie) As Integer
        Dim c1 As Integer = x.Titel.CompareTo(y.Titel)
        If c1 <> 0 Then Return c1
        Return x.Titel.CompareTo(y.Titel)
    End Function
    Sub Pages()
        Dim arr As String() = IO.Directory.GetFiles(Vorlage, "*%Page%*", IO.SearchOption.AllDirectories)
        For x As Integer = 0 To UBound(arr)
            l.advLabelstring = IO.Path.GetFileName(arr(x))
            CratePage(arr(x))
        Next
    End Sub


    Structure ImageLoopItem
        Property Path As String
        Property Width As Integer
        Property Height As Integer
        Property isOriginal As Boolean
        Property Count As Integer
    End Structure


    Sub Covers()
        Dim arr As String() = IO.Directory.GetFiles(Vorlage, "*%LoopCover%*", IO.SearchOption.AllDirectories)
        Dim sizes As New List(Of ImageLoopItem)
        Dim LoadCoverInCache As Boolean = False

        For x As Integer = 0 To UBound(arr)
            Dim img As Image = MyFunctions.ImageFromJpeg(arr(x))
            If Not img Is Nothing Then
                LoadCoverInCache = True
                Dim s As New ImageLoopItem
                s.Path = arr(x)
                s.Height = img.Height
                s.Width = img.Width
                s.isOriginal = False
                img.Dispose()
                sizes.Add(s)
            End If
        Next

        For x As Integer = 0 To UBound(arr)
            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
            If IO.File.Exists(v) Then
                IO.File.Delete(v)
            End If
        Next

        'OriginalCover holen
        arr = IO.Directory.GetFiles(Vorlage, "*%LoopOriginalCover%*", IO.SearchOption.AllDirectories)
        For x As Integer = 0 To UBound(arr)
            Dim s As New ImageLoopItem
            s.Path = arr(x)
            s.Height = 0
            s.Width = 0
            s.isOriginal = True
            sizes.Add(s)
        Next


        For x As Integer = 0 To UBound(arr)
            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
            If IO.File.Exists(v) Then
                IO.File.Delete(v)
            End If
        Next


        l.Aktuell = 0

        For Each m In li
            l.Nächster()
            worker.ReportProgress(CInt(((li.IndexOf(m) + 1) / li.Count) * 100))
            If Not m.Cover = "" Then
                'wenn Cover vorhanden

                For Each s In sizes
                    'Fortschritt aktualisieren
                    l.advLabelstring = IO.Path.GetFileName(s.Path)
                    If s.isOriginal Then
                        CreateCovers(s.Path, m)
                    Else
                        Using img As Image = MyFunctions.ImageFromJpeg(m.Cover)
                            If img.Width > s.Width And img.Height > s.Height Then
                                CreateCoverFromImage(s.Path, m.DVDChacheID, img, s.Width, s.Height)
                            Else
                                Dim v As String = Dest & s.Path.Replace(Vorlage, "")
                                Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
                                IO.File.Copy(m.Cover, d)
                            End If
                        End Using
                    End If
                Next
            Else
                For Each s In sizes
                    If s.isOriginal Then
                        CreateCovers(s.Path, m)
                    Else

                        Dim v As String = Dest & s.Path.Replace(Vorlage, "")
                        Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
                        If IO.File.Exists(d) Then
                            IO.File.Delete(d)
                        End If
                        IO.File.Copy(s.Path, d)
                    End If

                Next
            End If
        Next




    End Sub
    Sub Singles()
        Try
            Dim arr As String() = IO.Directory.GetFiles(Vorlage, "*%Loop%*", IO.SearchOption.AllDirectories)
            For x As Integer = 0 To UBound(arr)
                l.Aktuell = 0
                l.advLabelstring = IO.Path.GetFileName(arr(x))
                Dim t As String = ""
                Dim readere As IO.StreamReader = New IO.StreamReader(arr(x))
                t = readere.ReadToEnd
                readere.Close()
                If Not t = "" Then
                    For Each m In li
                        l.Nächster()
                        worker.ReportProgress(CInt(((li.IndexOf(m) + 1) / li.Count) * 100))
                        CreatSingle(m, t, arr(x))
                    Next
                End If
                Dim v As String = Dest & arr(x).Replace(Vorlage, "")
                If IO.File.Exists(v) Then
                    IO.File.Delete(v)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Backs()
        Dim arr As String() = IO.Directory.GetFiles(Vorlage, "*%LoopBackdrops(*)%*", IO.SearchOption.AllDirectories)
        Dim sizes As New List(Of ImageLoopItem)
        Dim LoadCoverInCache As Boolean = False

        For x As Integer = 0 To UBound(arr)
            'anzahl der Backdrops auslesen
            Dim c As Integer = 0
            Dim match As System.Text.RegularExpressions.Match = _
                System.Text.RegularExpressions.Regex.Match(ReplaceCVals(IO.Path.GetFileName(arr(x))), "%LoopBackdrops\((\d*)\)%")
            If match.Success = True Then
                c = CInt(match.Groups(1).Value)
                If exportetBackdrops < c Then
                    exportetBackdrops = c
                End If
            End If
            'maxgröße auslesen
            Dim img As Image = MyFunctions.ImageFromJpeg(arr(x))
            If Not img Is Nothing Then
                LoadCoverInCache = True
                Dim s As New ImageLoopItem
                s.Path = arr(x)
                s.Count = c
                s.Height = img.Height
                s.Width = img.Width
                s.isOriginal = False
                img.Dispose()
                sizes.Add(s)
            End If
        Next
        For x As Integer = 0 To UBound(arr)
            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
            If IO.File.Exists(v) Then
                IO.File.Delete(v)
            End If
        Next
        arr = IO.Directory.GetFiles(Vorlage, "*%LoopOriginalBackdrops(*)%*", IO.SearchOption.AllDirectories)
        For x As Integer = 0 To UBound(arr)
            Dim c As Integer = 0
            Dim match As System.Text.RegularExpressions.Match = _
                System.Text.RegularExpressions.Regex.Match(ReplaceCVals(IO.Path.GetFileName(arr(x))), "%LoopOriginalBackdrops\((\d*)\)%")
            If match.Success = True Then
                c = CInt(match.Groups(1).Value)
                If exportetBackdrops < c Then
                    exportetBackdrops = c
                End If
            End If
            Dim s As New ImageLoopItem
            s.Path = arr(x)
            s.Height = 0
            s.Width = 0
            s.Count = c
            s.isOriginal = True
            sizes.Add(s)
        Next
        For x As Integer = 0 To UBound(arr)
            Dim v As String = Dest & arr(x).Replace(Vorlage, "")
            If IO.File.Exists(v) Then
                IO.File.Delete(v)
            End If
        Next
        l.Aktuell = 0

        For Each m In li
            l.Nächster()
            worker.ReportProgress(CInt(((li.IndexOf(m) + 1) / li.Count) * 100))

            For Each s In sizes
                l.advLabelstring = IO.Path.GetFileName(s.Path)
                If m.Backdrops.Length > 0 Then


                    If s.isOriginal Then
                        CreateBacks(s.Path, m, s.Count)
                    Else
                        ''Größe ändern
                        CreateBacks(s.Path, m, s)
                    End If
                End If
            Next
        Next


    End Sub

    Private Sub CreateBacks(ByVal p As String, ByVal m As Movie, ByVal s As ImageLoopItem)
        Dim v As String = Dest & p.Replace(Vorlage, "")
        Dim d1 As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileNameWithoutExtension(v)).Replace("%LoopBackdrops(" & s.Count & ")%", m.DVDChacheID))
        Dim d2 As String = ".jpg"
        Dim d As String = ""

        If m.Backdrops.Length > 0 Then

            Dim max As Integer

            If m.Backdrops.Length >= s.Count Then
                max = s.Count
            Else
                max = m.Backdrops.Length
            End If


            For x As Integer = 0 To max - 1
                d = d1 & "_" & (x + 1) & d2
                If IO.File.Exists(d) Then
                    If repalceBacks = True Then
                        IO.File.Delete(d)
                    Else
                        Exit Sub
                    End If
                End If

                Try
                    Using img As Image = MyFunctions.ImageFromJpeg(m.Backdrops(x))
                        If img.Width > s.Width And img.Height > s.Height Then
                            Dim isg As Image = AutoSizeImage(img, s.Width, s.Height)

                            isg.Save(d, System.Drawing.Imaging.ImageFormat.Jpeg)
                            isg.Dispose()
                        Else
                            Try
                                IO.File.Copy(m.Backdrops(x), d)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        End If

                    End Using

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next

        End If
    End Sub

    Private Sub CreateBacks(ByVal p As String, ByVal m As Movie, ByVal i As Integer)
        Dim v As String = Dest & p.Replace(Vorlage, "")
        Dim d1 As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileNameWithoutExtension(v)).Replace("%LoopOriginalBackdrops(" & i & ")%", m.DVDChacheID))
        Dim d2 As String = ".jpg"
        Dim d As String = ""

        If m.Backdrops.Length > 0 Then
            If m.Backdrops.Length >= i Then
                For x As Integer = 0 To i - 1
                    d = d1 & "_" & (x + 1) & d2
                    If IO.File.Exists(d) Then
                        If repalceBacks = True Then
                            IO.File.Delete(d)
                        Else
                            Exit Sub
                        End If
                    End If
                    Try
                        IO.File.Copy(m.Backdrops(x), d)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            Else
                For x As Integer = 0 To m.Backdrops.Length - 1
                    d = d1 & "_" & (x + 1) & d2
                    If IO.File.Exists(d) Then
                        If repalceBacks = True Then
                            IO.File.Delete(d)
                        Else
                            Exit Sub
                        End If
                    End If
                    Try
                        IO.File.Copy(m.Backdrops(x), d)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            End If
        End If

    End Sub
    Sub CreateCovers(ByVal p As String, ByVal m As Movie)
        Dim v As String = Dest & p.Replace(Vorlage, "")
        Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopOriginalCover%", m.DVDChacheID)))
        If IO.File.Exists(d) Then
            If repalceCover = True Then
                IO.File.Delete(d)
            Else
                Exit Sub
            End If
        End If
        If Not m.Cover = "" Then
            Try


                IO.File.Copy(m.Cover, d)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else


            IO.File.Copy(p, d)
        End If

    End Sub

    Sub CreateCoverFromImage(ByVal p As String, ByVal id As String, ByVal i As Image, ByVal w As Integer, ByVal h As Integer)

        Try
            Dim isg As Image = AutoSizeImage(i, w, h)
            Dim v As String = Dest & p.Replace(Vorlage, "")
            Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", id)))
            isg.Save(d, System.Drawing.Imaging.ImageFormat.Jpeg)
            isg.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CreateCovers(ByVal p As String, ByVal m As Movie, ByVal w As Integer, ByVal h As Integer)
        If Not m.Cover = "" Then
            Try
                Using img As Image = MyFunctions.ImageFromJpeg(m.Cover)
                    Dim isg As Image = AutoSizeImage(img, w, h)
                    Dim v As String = Dest & p.Replace(Vorlage, "")
                    Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
                    isg.Save(d, System.Drawing.Imaging.ImageFormat.Jpeg)
                    isg.Dispose()
                End Using


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim v As String = Dest & p.Replace(Vorlage, "")
            Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%LoopCover%", m.DVDChacheID)))
            IO.File.Copy(p, d)
        End If

    End Sub



    Sub CratePage(ByVal p As String)
        Try
            l.Aktuell = 0
            Dim text As String = ""
            Dim r As String = ""
            Dim readere As IO.StreamReader = New IO.StreamReader(p)
            text = readere.ReadToEnd
            readere.Close()
            text = ReplaceCVals(text)

            'Dim loopreg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("(?<head>[^(?(%StartLoop%))]*)%StartLoop%(?<content>[^(%EndLoop%)]*)%EndLoop%")

            'For Each m In loopreg.Matches(text)



            'Next


            Dim i As String() = Split(text, "%StartLoop%")
            r = text
            If i.Length > 1 Then
                Dim s As String() = Split(i(1), "%EndLoop%")
                If s.Length > 1 Then
                    Dim t As String = s(0)
                    r = i(0)
                    For Each x In li
                        l.Nächster()
                        worker.ReportProgress(CInt(((li.IndexOf(x) + 1) / li.Count) * 100))
                        Dim d As String = ReplaceTags(t, x)

                        r &= d
                    Next
                    r &= s(1)
                End If
            End If
            Dim v As String = Dest & p.Replace(Vorlage, "")
            If IO.File.Exists(v) Then
                IO.File.Delete(v)
            End If

            Dim u As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%Page%", "")))
            starter = u
            My.Computer.FileSystem.WriteAllText(u, r, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub CreatSingle(ByVal ms As Movie, ByVal txt As String, ByVal p As String)
        Dim text As String = txt

        text = ReplaceTags(text, ms)


        Dim v As String = Dest & p.Replace(Vorlage, "")
        Dim d As String = IO.Path.Combine(MyFunctions.GetPathofFile(v), ReplaceCVals(IO.Path.GetFileName(v).Replace("%Loop%", ms.DVDChacheID)))
        My.Computer.FileSystem.WriteAllText(d, text, False)
    End Sub
    Sub Run()
        For Each m In li
            If m.DVDChacheID = "" Then
                m.DVDChacheID = m.IMDB_ID
            End If
            If m.DVDChacheID = "" Then
                m.DVDChacheID = IO.Path.GetRandomFileName
            End If
        Next

        If Not l Is Nothing Then
            l.Labelstring = "Kopieren"
        End If
        Copy()
        If Not l Is Nothing Then
            l.Labelstring = "Erstelle Covers"
        End If
        Covers()
        If Not l Is Nothing Then
            l.Labelstring = "Erstelle Backdrops"
        End If
        Backs()
        If Not l Is Nothing Then
            l.Labelstring = "Erstelle einzelne Seiten"
        End If
        Singles()
        If Not l Is Nothing Then
            l.Labelstring = "Erstelle komplette Seiten"
        End If
        Pages()

    End Sub

    Sub CopyFile(ByVal p As String)
        Dim g As String = p.Replace(Vorlage, "").Replace("%", "")
        Dim v As String = Dest & g
        Try
            Dim ep As New ExplorerActions
            ep.fCopy(Vorlage, Dest, True)
            IO.Directory.Move(IO.Path.Combine(Dest, IO.Path.GetFileName(Vorlage)), Dest)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub CopyDir(ByVal p As String)
        If Not IO.Path.GetFileName(p) = "CVals" Then
            Dim d As String = Dest & p.Replace(Vorlage, "")
            If Not IO.Directory.Exists(d) Then
                IO.Directory.CreateDirectory(d)
            End If
            For Each c In IO.Directory.GetFiles(p)
                If Not IO.Path.GetFileName(c) = "icon.png" And Not IO.Path.GetFileName(c) = "run.txt" And Not IO.Path.GetFileName(c) = "Thumbs.db" Then
                    Dim cd As String = Dest & c.Replace(Vorlage, "")
                    If IO.File.Exists(cd) Then
                        IO.File.Delete(cd)
                    End If
                    Try
                        IO.File.Copy(c, cd)
                    Catch ex As Exception

                    End Try

                End If
            Next
            For Each c In IO.Directory.GetDirectories(p)
                CopyDir(c)
            Next
        End If
    End Sub
    Sub Copy()
        CopyDir(Vorlage)
    End Sub

    Public Function ReplaceCVals(ByVal s As String) As String
        For Each c In replacer
            s = s.Replace("%" & c.Pattern & "%", c.Value)
        Next
        Return s
    End Function

    Public Shared Function ReplaceTags(ByVal text As String, ByVal m As Movie) As String
        text = text.Replace("%Pfad%", m.Pfad) _
      .Replace("%Ordner%", m.Ordner) _
      .Replace("%Titel%", m.Titel) _
.Replace("%Originaltitel%", m.Originaltitel) _
.Replace("%IMDB_ID%", m.IMDB_ID) _
.Replace("%Darsteller%", m.Darsteller) _
.Replace("%Regisseur%", m.Regisseur) _
.Replace("%Autoren%", m.Autoren) _
.Replace("%Studios%", m.Studios) _
.Replace("%Produktionsjahr%", m.Produktionsjahr) _
.Replace("%Produktionsland%", m.Produktionsland) _
.Replace("%Genre%", m.Genre) _
.Replace("%FSK%", m.FSK) _
.Replace("%Bewertung%", m.Bewertung) _
.Replace("%Spieldauer%", m.Spieldauer) _
.Replace("%Kurzbeschreibung%", m.Kurzbeschreibung) _
.Replace("%Inhalt%", m.Inhalt) _
.Replace("%Sort%", m.Sort) _
.Replace("%VideoAuflösung%", m.VideoAuflösung) _
.Replace("%VideoSeitenverhältnis%", m.VideoSeitenverhältnis) _
.Replace("%VideoBildwiederholungsrate%", m.VideoBildwiederholungsrate) _
.Replace("%VideoCodec%", m.VideoCodec) _
.Replace("%AudioKanäle%", m.AudioKanäle) _
.Replace("%AudioCodec%", m.AudioCodec) _
.Replace("%AudioSprachen%", m.AudioSprachen) _
  .Replace("%cacheID%", m.DVDChacheID) _
  .Replace("%VideoBreite%", m.VideoBreite) _
  .Replace("%VideoHöhe%", m.VideoHöhe)



        text = text.Replace("%FavName%", m.Favname).Replace("%FavPath%", m.Favpath)


        Dim i As String() = Split(text, "%StartBacksLoop%")
        If i.Length > 1 Then
            Dim s As String() = Split(i(1), "%EndBacksLoop%")
            If s.Length > 1 Then
                Dim t As String = s(0)
                text = i(0)
                Dim max As Integer = exportetBackdrops
                If m.Backdrops.Length >= max Then
                    For x As Integer = 0 To max - 1
                        Dim ds As String = t.Replace("%BackdropNum%", CStr((x + 1)))
                        text &= ds
                    Next
                Else
                    For x As Integer = 0 To UBound(m.Backdrops)
                        Dim ds As String = t.Replace("%BackdropNum%", CStr((x + 1)))
                        text &= ds
                    Next
                End If

                text &= s(1)
            End If
        End If

        i = Split(text, "%StartActors(")

        Dim match As System.Text.RegularExpressions.Match = System.Text.RegularExpressions.Regex.Match(text, "%StartActors\((\d*)\)%")
        'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")
        Dim c As Integer = 0
        If match.Success = True Then
            c = CInt(match.Groups(1).Value)
        End If

        If i.Length > 1 Then
            Dim s As String() = Split(i(1).Remove(0, c.ToString.Length + 2), "%EndActors%")
            If s.Length > 1 Then
                Dim t As String = s(0)
                text = i(0)

                If Not m.Darsteller = "" Then
                    Dim Darsteller() As String = m.Darsteller.Split(CChar(","))
                    Dim arr(3, Darsteller.Length) As String
                    If Darsteller.Length > 0 Then
                        For x As Integer = 0 To Darsteller.Length - 1
                            Dim DSname_S As String = ""
                            Dim DSrole_S As String = ""
                            Dim DSpath_S As String = ""
                            If Darsteller(x).Contains("[") Then
                                Dim DSname() As String = Darsteller(x).Split(CChar("["))
                                DSname_S = Trim(DSname(0))
                                DSrole_S = Trim(DSname(1)).Replace("]", "")
                                DSrole_S = DSrole_S.Replace("...", "")
                                DSrole_S = Trim(DSrole_S)
                            Else
                                DSname_S = Trim(Darsteller(x))
                            End If
                            Dim ac As String = Renamer.CheckInvalid_F(CStr(DSname_S))
                            If IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & ac & "\folder.jpg") Then
                                DSpath_S = Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & ac & "\folder.jpg"
                            ElseIf IO.File.Exists(Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & ac & ".jpg") Then
                                DSpath_S = Einstellungen.Config_MediaCenter.MediaBrowser_ImagesByName & "\" & ac & ".jpg"
                            Else
                                DSpath_S = ""
                            End If
                            arr(0, x) = DSname_S
                            arr(1, x) = DSrole_S
                            arr(2, x) = DSpath_S
                            arr(3, x) = "file:///" & DSpath_S.Replace("\", "/")
                        Next
                    End If
                    If Not c = 0 Then
                        Dim max As Integer = 0
                        Dim l As Integer = arr.GetLength(1)
                        If l <= c Then
                            max = l
                        Else
                            max = c
                        End If
                        For x As Integer = 0 To max - 1
                            Dim ds As String = t.Replace("%ActorName%", arr(0, x)) _
                                               .Replace("%ActorRole%", arr(1, x)) _
                                               .Replace("%ActorPath%", arr(2, x)) _
                                               .Replace("%ActorUrl%", arr(3, x))

                            text &= ds
                        Next
                    End If




                End If

                text &= s(1)
            End If
        End If



        Return text

    End Function
    Public Shared Sub ExportHtml(ByVal ms As List(Of Movie))
        Dim text As String = _
"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbCrLf & _
"<html xmlns=""http://www.w3.org/1999/xhtml"">" & vbCrLf & _
"<head>" & vbCrLf & _
"<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8""/>" & vbCrLf & _
"<title>" & "FI!O HTML Export" & "</title>" & vbCrLf & _
"<style type=""text/css"">" & vbCrLf & _
    "<!--" & vbCrLf & _
".test { " & vbCrLf & _
"border-top-width: 0px; " & vbCrLf & _
"border-right-width: 0px;" & vbCrLf & _
"border-bottom-width: 1px; " & vbCrLf & _
"border-left-width: 0px; " & vbCrLf & _
"border-top-style: solid; " & vbCrLf & _
"border-right-style: solid; " & vbCrLf & _
"border-bottom-style: solid; " & vbCrLf & _
"border-left-style: solid;" & vbCrLf & _
"border-top-color: #000;" & vbCrLf & _
"border-right-color: #000;" & vbCrLf & _
"border-bottom-color: #000;" & vbCrLf & _
"border-left-color: #000;" & vbCrLf & _
"}" & vbCrLf & _
".beschreibung { " & vbCrLf & _
"word-spacing: 0em;" & vbCrLf & _
"margin: 0px; " & vbCrLf & _
"padding: 0px; " & vbCrLf & _
"}" & vbCrLf & _
"-->" & vbCrLf & _
"</style>" & vbCrLf & _
"</head>" & vbCrLf & _
"<body>"
        For x As Integer = 0 To ms.Count - 1


            text &= _
"<table width=""400"" border=""0"" cellpadding=""0"" cellspacing=""0""  border=""0"" class=""test"">" & vbCrLf & _
"<tr>" & vbCrLf & _
    "<td width=""120"" height=""89""><img src=""file:///" & ms(x).Cover & """ width=""70"" height=""100""/></td> " & vbCrLf & _
    "<td width=""50""><table width=""400"" border=""0"">" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).Titel & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).Ordner & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).Produktionsjahr & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "</table></td>" & vbCrLf & _
   "<td width=""8""><table width=""400"" border=""0"">" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).Genre & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).Bewertung & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "<tr>" & vbCrLf & _
            "<td>" & ms(x).IMDB_ID & "</td>" & vbCrLf & _
        "</tr>" & vbCrLf & _
        "</table></td>" & vbCrLf & _
"</tr>" & vbCrLf & _
"</table>"

            '"<td width=""297"" valign=""top""><pre class=""beschreibung"">" & rows(x).Cells.Item(KInhalt_Column.Index).Value & "</pre></td>" & vbCrLf & _

            'End If
        Next
        MainForm.HTMLPRev(text)
        My.Computer.FileSystem.WriteAllText("export.html", text, False)
        'Process.Start(Application.StartupPath & "\export.html")
    End Sub

    Public Shared Function AutoSizeImage(ByVal oBitmap As Image, _
  ByVal maxWidth As Integer, _
  ByVal maxHeight As Integer, _
  Optional ByVal bStretch As Boolean = False) As Image

        ' Größenverhältnis der max. Dimension
        Dim maxRatio As Single = CSng(maxWidth / maxHeight)

        ' Bildgröße und aktuelles Größenverhältnis
        Dim imgWidth As Integer = oBitmap.Width
        Dim imgHeight As Integer = oBitmap.Height
        Dim imgRatio As Single = CSng(imgWidth / imgHeight)

        ' Bild anpassen?
        If (imgWidth > maxWidth Or imgHeight > maxHeight) Or (bStretch) Then
            If imgRatio <= maxRatio Then
                ' Größenverhältnis des Bildes ist kleiner als die
                ' maximale Größe, in der das Bild angezeigt werden kann.
                ' In diesem Fall muss die Bildbreite angepasst werden.
                imgWidth = CInt(imgWidth / (imgHeight / maxHeight))
                imgHeight = maxHeight
            Else
                ' Größenverhältnis des Bildes ist größer als die 
                ' maximale Größe, in der das Bild angezeigt werden kann.
                ' In diesem Fall muss die Bildhöhe angepasst werden.
                imgHeight = CInt(imgHeight / (imgWidth / maxWidth))
                imgWidth = maxWidth
            End If

            ' Bitmap-Objekt in der neuen Größe erstellen
            Dim oImage As New Bitmap(imgWidth, imgHeight)

            ' Bild interpolieren, damit die Qualität erhalten bleibt
            Using g As Graphics = Graphics.FromImage(oImage)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(oBitmap, New Rectangle(0, 0, imgWidth, imgHeight))
            End Using

            ' neues Bitmap zurückgeben
            Return oImage
        Else
            ' unverändertes Originalbild zurückgeben
            Return oBitmap
        End If
    End Function



End Class
