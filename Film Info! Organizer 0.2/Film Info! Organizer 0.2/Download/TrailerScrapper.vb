Imports Film_Info__Organizer.MoviemazeSearchProvider
Imports System.Text.RegularExpressions

Public Class TrailerScrapper
    Public Shared MySearch As New MoviemazeSearchProvider
    Public Shared List As New List(Of Movie)

    Public Shared Sub DoSearch(ByVal li As List(Of Movie))
        List = li
        If li.Count > 0 Then
            BuildDialog(li(0), li(0).Titel)

        End If
    End Sub
    Public Shared Sub BuildDialog(ByVal m As Movie, ByVal s As String)
        With Dialog_Trailer

            .ToolStripTextBox_Suche.Text = s
            Dialog_Trailer.mvo = m
            Dim result As MoviemazeSearchResult = MySearch.Search(s)
            If Not result.Exact Is Nothing Then
                .Cursor = Cursors.WaitCursor
                .TrailerLoad(New TrailerLoader(result.Exact.sTrailerURI))
                .Cursor = Cursors.Default

                .Panel_trailer.BringToFront()


                .ToolStripTextBox_Suche.Visible = False
                .ToolStripButton1.Visible = False
                .ToolStripButton2.Visible = True
            Else
                .Panel_Suche.BringToFront()

                .ToolStripTextBox_Suche.Visible = True
                .ToolStripButton1.Visible = True
                .ToolStripButton2.Visible = False

            End If

            .ListViewVista1.Items.Clear()


            Dim ilist As New List(Of ListViewItem)
            For Each t As mm_Result In result.Li
                Dim li As New ListViewItem
                li.Text = t.Titel
                li.Tag = t.TrailerURI
                li.Group = .ListViewVista1.Groups(t.Genauigkeit)
                ilist.Add(li)
            Next



            .Text = "Trailer wählen - " & .mvo.Ordner
            .ToolStripButton3.DropDownItems.Clear()
            If list.Count > 0 Then
                For x As Integer = 0 To list.Count - 1
                    .ToolStripButton3.DropDownItems.Add(List(x).Titel)
                Next
            End If
            .ToolStripButton3.Text = CStr(List.Count)







            .ListViewVista1.Items.AddRange(ilist.ToArray)

            .BringToFront()
            .Show()

        End With


    End Sub
    Public Shared Sub NextMovie()
        If List.Count > 0 Then
            BuildDialog(List(0), List(0).Titel)
        End If
    End Sub

End Class
''' <summary>
''' This class implements string comparison algorithm
''' based on character pair similarity
''' Source: http://www.catalysoft.com/articles/StrikeAMatch.html
''' </summary>
Public Class SimilarityTool
    ''' <summary>
    ''' Compares the two strings based on letter pair matches
    ''' </summary>
    ''' <param name="str1"></param>
    ''' <param name="str2"></param>
    ''' <returns>The percentage match from 0.0 to 1.0 where 1.0 is 100%</returns>
    Public Function CompareStrings(ByVal str1 As String, ByVal str2 As String) As Double
        Dim pairs1 As List(Of String) = WordLetterPairs(str1.ToUpper())
        Dim pairs2 As List(Of String) = WordLetterPairs(str2.ToUpper())

        Dim intersection As Integer = 0
        Dim union As Integer = pairs1.Count + pairs2.Count

        For i As Integer = 0 To pairs1.Count - 1
            For j As Integer = 0 To pairs2.Count - 1
                If pairs1(i) = pairs2(j) Then
                    intersection += 1
                    pairs2.RemoveAt(j)
                    'Must remove the match to prevent "GGGG" from appearing to match "GG" with 100% success
                    Exit For
                End If
            Next
        Next

        Return (2.0 * intersection) / union
    End Function

    ''' <summary>
    ''' Gets all letter pairs for each
    ''' individual word in the string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Private Function WordLetterPairs(ByVal str As String) As List(Of String)
        Dim AllPairs As New List(Of String)()

        ' Tokenize the string and put the tokens/words into an array
        Dim Words As String() = Regex.Split(str, "\s")

        ' For each word
        For w As Integer = 0 To Words.Length - 1
            If Not String.IsNullOrEmpty(Words(w)) Then
                ' Find the pairs of characters
                Dim PairsInWord As [String]() = LetterPairs(Words(w))

                For p As Integer = 0 To PairsInWord.Length - 1
                    AllPairs.Add(PairsInWord(p))
                Next
            End If
        Next

        Return AllPairs
    End Function

    ''' <summary>
    ''' Generates an array containing every 
    ''' two consecutive letters in the input string
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Private Function LetterPairs(ByVal str As String) As String()
        Dim numPairs As Integer = str.Length - 1

        Dim pairs As String() = New String(numPairs - 1) {}

        For i As Integer = 0 To numPairs - 1
            pairs(i) = str.Substring(i, 2)
        Next

        Return pairs
    End Function
End Class
