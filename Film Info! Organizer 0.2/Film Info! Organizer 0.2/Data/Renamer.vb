Imports System.IO
Imports Film_Info__Organizer.MyFunctions
Public Class Renamer
    Public Shared invalidFChars As Char() = Path.GetInvalidFileNameChars
    Public Shared invalidPChars As Char() = Path.GetInvalidPathChars
    Public Shared TrimmChars As Char() = {CChar(" "), CChar(".")}
    ''' <summary>
    ''' Liefert den Zielordnernamen/Zieldateinamen(ohne ext) auf Basis der Einstellungen.
    ''' inkl. überprüfung auf ungültige Zeichen!
    ''' </summary>
    ''' <param name="m">Movie</param>
    ''' <param name="folder">False=Datei/True=Ordner</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Formatof(ByVal m As Movie, ByVal folder As Boolean, Optional ByVal Files As Boolean = False) As String

        Dim s As String = ""
        If folder = True Then
            s = Einstellungen.Config_Save.Save_Rename_Folderpat
        Else
            s = Einstellungen.Config_Save.Save_Rename_Filepat
        End If
        If Files = True Then
            s = Einstellungen.Config_Save.Save_Rename_Filespat
        End If
        s = s.Replace("%titel%", m.Titel)
        s = s.Replace("%o_titel%", m.Originaltitel)
        s = s.Replace("%s_titel%", m.Sort)
        s = s.Replace("%jahr%", m.Produktionsjahr)
        s = s.Replace("%v_höhe%", m.VideoHöhe)
        s = s.Replace("%v_breite%", m.VideoBreite)
        s = s.Replace("%genre%", m.Genre)
        s = s.Replace("%land%", m.Produktionsland)
        s = s.Replace("%v_codec%", m.VideoCodec)
        s = s.Replace("%v_aufloesung%", m.VideoAuflösung)
        s = s.Replace("%v_framerate%", m.VideoBildwiederholungsrate)
        s = s.Replace("%a_channels%", m.AudioKanäle)
        s = s.Replace("%a_codec%", m.AudioCodec)
        s = s.Replace("%imdbid%", m.IMDB_ID)
        s = s.Replace("%regie%", If(m.Regisseur.Contains(","), m.Regisseur.Substring(0, m.Regisseur.IndexOf(",")), m.Regisseur))
        s = CheckInvalid_F(s)



        Return s
    End Function
    Public Shared Function ChangeFileName(ByVal m As Movie) As Boolean
        m.Files = Get_Moviepaths_in_array(m.Pfad)

        If m.Files.Length = 1 Then


            If File.Exists(m.Files(0)) Then
                Dim newpath As String = m.Pfad
                Dim folder As String = Formatof(m, False)
                If folder = "" Then

                    Return False

                End If


                If Einstellungen.Config_MediaCenter.Default_local_Source = Savemode.nfo Then
                    If IO.File.Exists(m.File_Trailer) Then
                        newpath = IO.Path.Combine(m.Pfad, folder & "-trailer" & Path.GetExtension(m.File_Trailer))
                        DateiUmbenennen(m.File_Trailer, newpath, m.Pfad)
                    End If
                End If


                newpath = IO.Path.Combine(m.Pfad, folder & Path.GetExtension(m.Files(0)))
                DateiUmbenennen(m.Files(0), newpath, m.Pfad)
                Untertitel(m.Files(0), m.Pfad, folder)



            End If



        ElseIf m.Files.Length > 1 Then
            If Einstellungen.Config_Save.Save_Rename_Filespat.Contains("{n}") Then


                For x As Integer = 0 To m.Files.Length - 1
                    If File.Exists(m.Files(x)) Then
                        Dim newpath As String = m.Pfad
                        Dim folder As String = Formatof(m, True, True).Replace("{n}", CStr((x + 1))).Replace("{g}", CStr(m.Files.Length))
                        If folder = "" Then
                            Return False
                        End If
                        newpath = IO.Path.Combine(newpath, folder & Path.GetExtension(m.Files(x)))
                        If Not newpath.ToLower = m.Files(x).ToLower Then
                            Try
                                IO.File.Move(m.Files(x), newpath)
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                        ElseIf Not newpath = m.Files(x) Then
                            Dim cP As String = IO.Path.Combine(m.Pfad, IO.Path.GetRandomFileName)
                            Do Until IO.File.Exists(cP) = False
                                cP = IO.Path.Combine(m.Pfad, IO.Path.GetRandomFileName)
                            Loop
                            Try
                                IO.File.Move(m.Files(x), cP)
                                IO.File.Move(cP, newpath)
                                'm.Pfad = newpath
                                'PathAnalyse_Info(m)
                                'If m.focused = True Then
                                '    Main.TB_Pfad.Text = m.Pfad
                                '    Main.TB_Ordner.Text = m.Ordner
                                'End If
                            Catch ex As Exception
                                MsgBox(ex.Message & vbCrLf & newpath & vbCrLf & m.Pfad)
                            End Try
                        End If
                        Untertitel(m.Files(x), m.Pfad, folder)



                    End If
                Next
            End If
        Else
            Return False
        End If
        PathAnalyse(m)

    End Function
    Public Shared Function ChangeFolderName(ByVal m As Movie) As Boolean
        Dim parent As String = GetPathofFile(m.Pfad)
        Dim newpath As String = GetPathofFile(m.Pfad)
        Dim folder As String = Formatof(m, True)
        If folder = "" Then

            Return False

        End If
        newpath = IO.Path.Combine(newpath, folder)

        'MsgBox(newpath & vbCrLf & m.Pfad)

        If Not newpath.ToLower = m.Pfad.ToLower And Not (newpath.Contains("ß") Or m.Pfad.Contains("ß")) Then
            newpath = CheckInvalid_P(newpath)
            If Directory.Exists(newpath) Then
                MsgBox("Ordner existiert bereits. " & vbCrLf & newpath)
            Else

                '    Directory.CreateDirectory(newpath)

                Try
                    IO.Directory.Move(m.Pfad, newpath)
                    m.Pfad = newpath
                    PathAnalyse_Info(m)
                    'If m.focused = True Then
                    '    Main.TB_Pfad.Text = m.Pfad
                    '    Main.TB_Ordner.Text = m.Ordner
                    'End If
                Catch ex As Exception
                    MsgBox(ex.Message & vbCrLf & newpath & vbCrLf & m.Pfad)
                End Try

            End If
        ElseIf Not newpath = m.Pfad Then
            newpath = CheckInvalid_P(newpath)
            Dim cP As String = IO.Path.Combine(parent, IO.Path.GetRandomFileName)
            Do Until IO.Directory.Exists(cP) = False
                cP = IO.Path.Combine(parent, IO.Path.GetRandomFileName)
            Loop
            Try
                IO.Directory.Move(m.Pfad, cP)
                IO.Directory.Move(cP, newpath)
                m.Pfad = newpath
                PathAnalyse_Info(m)
                'If m.focused = True Then
                '    Main.TB_Pfad.Text = m.Pfad
                '    Main.TB_Ordner.Text = m.Ordner
                'End If
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & newpath & vbCrLf & m.Pfad)
            End Try
        End If





    End Function

    Public Shared Function GetPathofFile(ByVal s As String) As String
        Dim r As String = ""
        'Debug.WriteLine("Vorher: " & s)
        Try
            'MsgBox(r.LastIndexOf("\"))
            If Not s.LastIndexOf("\") = 2 Then
                r = s.Substring(0, s.LastIndexOf("\"))
            Else
                r = s.Substring(0, 3)
            End If

        Catch ex As Exception

        End Try
        'Debug.WriteLine("Nachher: " & r)
        Return r
    End Function

    Public Shared Function CheckInvalid_F(ByVal s As String) As String
        For Each invalidPChar In invalidFChars
            s = s.Replace(invalidPChar, "")
        Next
        Return s.Trim(TrimmChars)
    End Function
    Public Shared Function CheckInvalid_P(ByVal s As String) As String
        For Each invalidPChar In invalidPChars
            s = s.Replace(invalidPChar, "")
        Next
        Return s.Trim(TrimmChars)
    End Function
    Public Shared Function Formatget(ByVal r As String) As String
        Dim s As String = r

        s = s.Replace("%titel%", "Titel")
        s = s.Replace("%o_titel%", "OriginalTitel")
        s = s.Replace("%s_titel%", "Sortierung")
        s = s.Replace("%jahr%", "2009")
        s = s.Replace("%v_höhe%", "1080")
        s = s.Replace("%v_breite%", "1920")
        s = s.Replace("%genre%", "Action")
        s = s.Replace("%land%", "USA")
        s = s.Replace("%v_codec%", "XviD")
        s = s.Replace("%v_aufloesung%", "720")
        s = s.Replace("%v_framerate%", "25")
        s = s.Replace("%a_channels%", "6")
        s = s.Replace("%a_codec%", "DTS")
        s = s.Replace("{n}", "1")
        s = s.Replace("%regie%", "Regisseur")
        s = s.Replace("imdbid", "tt123456")
        'If s.Contains("%ifnull") Then
        '    Dim myResultmovEx As New System.Text.RegularExpressions.Regex("%ifnull\((?<x>(.*)),(?<y>(.*)),(?<z>(.*))\)")
        '    'myresultlink = myResultmovEx.Match(au1(1)).Groups("titel").Value
        '    Dim i As Integer = myResultmovEx.Matches(s).Count
        '    If i > 0 Then
        '        For t As Integer = 0 To i - 1
        '            Dim xval As String = myResultmovEx.Matches(s).Item(t).Groups("x").Value
        '            Dim yval As String = myResultmovEx.Matches(s).Item(t).Groups("y").Value
        '            Dim zval As String = myResultmovEx.Matches(s).Item(t).Groups("z").Value
        '            MsgBox(xval & vbCrLf & yval & vbCrLf & zval)
        '            If Not myResultmovEx.Matches(s).Item(t).Groups("x").Value.ToString.Trim = "" Then
        '                s = s.Replace("%ifnull(" & xval & "," & yval & "," & zval & ")", yval)
        '            Else
        '                s = s.Replace("%ifnull(" & xval & "," & yval & "," & zval & ")", zval)
        '            End If
        '        Next


        '    End If
        'End If


        'ListBox1.Items.Add("Result:" & myResultmovEx.Matches(au1(1)).Item(x).Groups("titel").Value)
        Return s


    End Function

    Private Shared Sub DateiUmbenennen(ByVal p1 As String, ByVal newpath As String, ByVal path As String)
        If Not newpath.ToLower = p1.ToLower Then
            Try
                IO.File.Move(p1, newpath)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf Not newpath = p1 Then
            Dim cP As String = IO.Path.Combine(path, IO.Path.GetRandomFileName)
            Do Until IO.File.Exists(cP) = False
                cP = IO.Path.Combine(path, IO.Path.GetRandomFileName)
            Loop
            Try
                IO.File.Move(p1, cP)
                IO.File.Move(cP, newpath)
                'm.Pfad = newpath
                'PathAnalyse_Info(m)
                'If m.focused = True Then
                '    Main.TB_Pfad.Text = m.Pfad
                '    Main.TB_Ordner.Text = m.Ordner
                'End If
            Catch ex As Exception
                MsgBox(ex.Message & vbCrLf & newpath & vbCrLf & path)
            End Try
        End If
    End Sub


    Private Shared Sub Untertitel(ByVal filename As String, ByVal path As String, ByVal folder As String)
        filename = IO.Path.GetFileNameWithoutExtension(filename)
        If Einstellungen.Config_Save.Save_Rename_Sub_Files = True Then

            For Each ext In New String() {".idx", ".sub", ".str"}
                If IO.File.Exists(IO.Path.Combine(path, filename) & ext) Then
                    DateiUmbenennen(IO.Path.Combine(path, filename) & ext, IO.Path.Combine(path, folder) & ext, path)
                Else
                    Dim arr() As String = IO.Directory.GetFiles(path, "*" & ext)
                    If arr.Length > 1 Then
                        For x As Integer = 0 To arr.Length - 1
                            DateiUmbenennen(arr(x), IO.Path.Combine(path, folder) & (x + 1) & ext, path)
                        Next
                    ElseIf arr.Length = 1 Then
                        DateiUmbenennen(arr(0), IO.Path.Combine(path, folder) & ext, path)
                    End If
                End If
            Next




        End If
    End Sub

End Class
