Imports System.Text.RegularExpressions
Public Class FileNameFilter
    Public Shared Function ReplaceFolderName(ByVal s As String) As String
        Dim r As String = s
        For Each d In Einstellungen.CostumFilter.List
            Try
                r = Regex.Replace(r, d, "", RegexOptions.IgnoreCase)
            Catch ex As Exception

            End Try
        Next
        r = r.Trim
        Return r
    End Function
    Public Shared Function GetYearinFolderName(ByVal s As String) As String
        Dim matches As System.Text.RegularExpressions.MatchCollection = Regex.Matches(s, "[ _.-]\(?(\d{4})\)?.*")
        'Dim match As System.Text.RegularExpressions.Match = Regex.Match(S, """" & Name & """\:""(.*)[^\\]?""")


        If matches.Count > 0 Then

            Dim ye As Integer = Einstellungen.toInt(matches(matches.Count - 1).Groups(1).Value)

            If ye > 1900 And ye <= Today.Year Then
                Return CStr(ye)
            Else : Return ""
            End If

        Else : Return ""
        End If
    End Function
End Class
